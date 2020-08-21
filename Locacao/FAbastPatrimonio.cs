using FormBusca;
using System;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFAbastPatrimonio : Form
    {
        public TFAbastPatrimonio()
        {
            InitializeComponent();
        }

        private void BuscarProduto()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TpBusca[] filtro = new TpBusca[1];
            //Descartar produtos cancelados
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text))
                rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                   cbEmpresa.SelectedValue.ToString(),
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   filtro);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                   cbEmpresa.SelectedValue.ToString(),
                                                   string.Empty,
                                                   string.Empty,
                                                   null,
                                                   filtro);
            else
            {
                //Buscar Produto
                Estruturas.CriarParametro(ref filtro,
                                          string.Empty,
                                          "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                               "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                               "(exists(select 1 from tb_est_codbarra x " +
                                               "           where x.cd_produto = a.cd_produto " +
                                               "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))", string.Empty);
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                CdProduto.Text = rProd.CD_Produto;
                dsProduto.Text = rProd.DS_Produto;
                dtAbast.Focus();
            }
            else
                cd_produto.Focus();
            cd_produto.Clear();
        }

        private void TFAbastPatrimonio_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelDados4.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbEmpresa.SelectedItem != null)
            //{
            //    bsPatrimonio.DataSource =
            //        new CamadaDados.Locacao.TCD_ItensLocTerceiro().Select(
            //            new TpBusca[]
            //            {
            //                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'" },
            //                new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
            //                new TpBusca { vNM_Campo = string.Empty, vOperador = "exists",
            //                    vVL_Busca = "(select 1 from tb_loc_locterceiro x " +
            //                                "where x.cd_empresa = a.cd_empresa " +
            //                                "and x.id_loc = a.id_loc " +
            //                                "and isnull(x.st_registro, 'A') = 'A')"}
            //            }, 0, string.Empty);
            //}
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()))
                BuscarProduto();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void dtAbast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                quantidade.Focus();
        }

        private void quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                bbGravar.Focus();
        }

        private void bbCancelar_Click(object sender, EventArgs e)
        {
            cd_produto.Clear();
            dsProduto.Clear();
            CdProduto.Clear();
            quantidade.Clear();
            cd_produto.Focus();
        }

        private void bbGravar_Click(object sender, EventArgs e)
        {
            if(bsPatrimonio.Current == null)
            {
                MessageBox.Show("Obrigatório selecionar patrimonio para alocar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(string.IsNullOrWhiteSpace(CdProduto.Text))
            {
                MessageBox.Show("Obrigatório selecionar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            if(!dtAbast.Text.IsDateTime())
            {
                MessageBox.Show("Obrigatório informar data abastecimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtAbast.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(quantidade.Text))
            {
                MessageBox.Show("Obrigatório informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            try
            {
                //Buscar lista de itens com saldo
                CamadaDados.Faturamento.Entrega.TList_ItensCargaAvulsa lItens =
                    new CamadaDados.Faturamento.Entrega.TCD_ItensCargaAvulsa().Select(
                        new TpBusca[]
                        {
                            new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsPatrimonio.Current as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Cd_empresa.Trim() + "'" },
                            new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + CdProduto.Text.Trim() + "'" },
                            new TpBusca { vNM_Campo = "a.Quantidade - a.Qtd_devolvida - a.Qtd_consumida", vOperador = ">", vVL_Busca = "0" }
                        }, 0, string.Empty);
                if(lItens.Sum(x=> x.Saldo) < decimal.Parse(quantidade.Text))
                {
                    MessageBox.Show("Não existe saldo suficiente para alocar no patrimonio.\r\n" +
                                    "Saldo disponivel: " + lItens.Sum(x => x.Saldo).ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaNegocio.Locacao.TCN_AbastItens.Gravar(
                    new CamadaDados.Locacao.TRegistro_AbastItens
                    {
                        Cd_empresa = (bsPatrimonio.Current as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Cd_empresa,
                        Id_loc = (bsPatrimonio.Current as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Id_loc,
                        Id_item = (bsPatrimonio.Current as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Id_item,
                        Dt_abast = DateTime.Parse(dtAbast.Text),
                        Quantidade = decimal.Parse(quantidade.Text)
                    },
                    lItens, null).ForEach(x => (bsPatrimonio.Current as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).AbastItens.Add(x));
                bsPatrimonio.ResetBindings(true);
                MessageBox.Show("Item alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbCancelar_Click(this, new EventArgs());
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbExcluir_Click(object sender, EventArgs e)
        {
            if(bsAbastItens.Current != null)
                if(MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_AbastItens.Excluir(bsAbastItens.Current as CamadaDados.Locacao.TRegistro_AbastItens, null);
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsAbastItens.RemoveCurrent();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_clifor, Nm_clifor}, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            atualiza_bsPatrimonio();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor, Nm_clifor}, string.Empty);
            atualiza_bsPatrimonio();
        }

        private void atualiza_bsPatrimonio()
        {
            if ((cbEmpresa.SelectedItem != null) && (!string.IsNullOrEmpty(Cd_clifor.Text)))
            {
                bsPatrimonio.DataSource =
                    new CamadaDados.Locacao.TCD_ItensLocTerceiro().Select(
                        new TpBusca[]
                        {
                            new TpBusca {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_loc_locterceiro x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_loc = a.id_loc " +
                                            "and isnull(x.st_registro, 'A') = 'A' " +
                                            "and x.cd_fornecedor = " + Cd_clifor.Text.Trim() + ")"
                            }
                        }, 0, string.Empty);
            }
        }
    }
}
