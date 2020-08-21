using CamadaDados.Faturamento.Entrega;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFCargaAvulsa : Form
    {
        private TRegistro_CargaAvulsa rcarga;
        public TRegistro_CargaAvulsa rCarga
        {
            get
            {
                if (bsCarga.Current != null)
                    return bsCarga.Current as TRegistro_CargaAvulsa;
                else return null;
            }
            set { rcarga = value; }
        }
        public TFCargaAvulsa()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsItens.Count == 0)
                {
                    MessageBox.Show("Obrigatório inserir itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void BuscarProduto()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[3];
            //Retirar Patrimônios
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "not exists";
            filtro[0].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                  "where a.cd_produto = x.cd_patrimonio " +
                                  "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "') ";
            //Retirar Serviço
            filtro[1].vNM_Campo = "isnull(e.st_servico, 'N')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'S'";
            //Retirar Consumo Interno
            filtro[2].vNM_Campo = "isnull(e.st_consumointerno, 'N')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'S'";

            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            if (string.IsNullOrEmpty(cd_produto.Text.Trim()))
                rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             cbEmpresa.SelectedValue.ToString(),
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             filtro);
            else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                rProd = FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             cbEmpresa.SelectedValue.ToString(),
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             filtro);
            else
            {
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                            "(a.Codigo_Alternativo = '" + (cd_produto.TextOld != null ? cd_produto.TextOld.ToString() : cd_produto.Text.Trim()) + "') or " +
                                            "(exists(select 1 from tb_est_codbarra x " +
                                            "           where x.cd_produto = a.cd_produto " +
                                            "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca =  "(select 1 from TB_EST_Patrimonio x " +
                                             "where a.cd_produto = x.cd_patrimonio " +
                                             "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "') "
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_servico, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(e.st_consumointerno, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lProd.Count > 0)
                    rProd = lProd[0];
            }
            if (rProd != null)
            {
                bsItens.AddNew();
                (bsItens.Current as TRegistro_ItensCargaAvulsa).Cd_produto = rProd.CD_Produto;
                (bsItens.Current as TRegistro_ItensCargaAvulsa).Ds_produto = rProd.DS_Produto;
                (bsItens.Current as TRegistro_ItensCargaAvulsa).Quantidade = 1;
                if (!BuscarSaldoLocal(cbEmpresa.SelectedValue.ToString(), 
                                     (bsItens.Current as TRegistro_ItensCargaAvulsa).Cd_produto,
                                     false))
                {
                    cd_produto.Clear();
                    bsItens.ResetCurrentItem();
                    cd_produto.Focus();
                    return;
                }

            }
            cd_produto.Clear();
            Quantidade.Value = 1;
            Quantidade.Focus();
            bsItens.ResetCurrentItem();
        }

        private void ExcluirItem()
        {
            if (bsItens.Current != null)
            {
                if ((bsItens.Current as TRegistro_ItensCargaAvulsa).Id_lanctoEstoqueD != null)
                {
                    MessageBox.Show("Não é possível alterar item que possui devolução de estoque!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_produto.Focus();
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsCarga.Current as TRegistro_CargaAvulsa).lItensDel.Add(bsItens.Current as TRegistro_ItensCargaAvulsa);
                    bsItens.RemoveCurrent();
                    bsItens.ResetCurrentItem();
                }
            }
        }

        private void AlterarQTD()
        {
            if (bsItens.Current != null)
            {
                if ((bsItens.Current as TRegistro_ItensCargaAvulsa).Id_lanctoEstoqueS != null)
                {
                    MessageBox.Show("Não é possível alterar item que possui lançamento de estoque!\r\n" +
                                    "Para exclua o item e lance novamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_produto.Focus();
                    return;
                }
                (bsItens.Current as TRegistro_ItensCargaAvulsa).Quantidade = Quantidade.Value;
                if (!BuscarSaldoLocal(cbEmpresa.SelectedValue.ToString(),
                                     (bsItens.Current as TRegistro_ItensCargaAvulsa).Cd_produto,
                                     true))
                {
                    Quantidade.Focus();
                    return;
                }
                bsItens.ResetCurrentItem();
                cd_produto.Focus();
            }
        }

        private bool BuscarSaldoLocal(string pCd_empresa, string pCd_produto, bool AlterarQTD)
        {
            if ((!string.IsNullOrEmpty(pCd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)))
            {
                //Buscar Local Arm
                CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Empresa lLocal = 
                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + pCd_empresa.Trim() + "'"
                        }
                    }, 1, string.Empty);
                if (lLocal.Count.Equals(0))
                {
                    MessageBox.Show("Não existe Local de armazenagem configurado para Empresa" + pCd_empresa.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(pCd_empresa,
                                                                       pCd_produto,
                                                                       lLocal[0].CD_Local,
                                                                       ref saldo,
                                                                       null);
                if (saldo < (bsCarga.Current as TRegistro_CargaAvulsa).lItens
                    .FindAll(p=> p.Cd_produto.Equals((bsItens.Current as TRegistro_ItensCargaAvulsa).Cd_produto)).Sum(p=> p.Quantidade))
                {
                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                    "Empresa.........: " + pCd_empresa.Trim() + "-" + (bsCarga.Current as TRegistro_CargaAvulsa).Nm_empresa.Trim() + "\r\n" +
                                    "Produto.........: " + pCd_produto.Trim() + "-" + (bsItens.Current as TRegistro_ItensCargaAvulsa).Ds_produto.Trim() + "\r\n" +
                                    "Local Arm.......: " + lLocal[0].CD_Local.Trim() + "-" + lLocal[0].DS_Local + "\r\n" +
                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (AlterarQTD)
                    {
                        Quantidade.Value = saldo;
                        (bsItens.Current as TRegistro_ItensCargaAvulsa).Quantidade = Quantidade.Value;
                        Quantidade.Focus();
                    }
                    else
                        bsItens.RemoveCurrent();
                    return false;
                }
                else return true;
            }
            else
                return false;
        }

        private void TFCargaAvulsa_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            pProduto.set_FormatZero();
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rcarga != null)
            {
                bsCarga.DataSource = new TList_CargaAvulsa() { rcarga };
                cbEmpresa.Enabled = false;
            }
            else
                bsCarga.AddNew();
            //Buscar Empresa
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

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                BuscarProduto();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text.Trim()))
                BuscarProduto();
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "d.ds_veiculo|Veiculo|100;" +
                              "d.placa|Placa|80;" +
                              "a.categoria_cnh|Categoria CNH|80;" +
                              "a.dt_vencimento_cnh|Vencimento CNH|100";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void bb_excluirItem_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void ds_observacao_Leave(object sender, EventArgs e)
        {
            cd_produto.Focus();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Existem dados não salvos\r\n" +
                                "Confirma o fechamento da tela?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                DialogResult = DialogResult.Cancel;
        }

        private void TFCargaAvulsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F3))
            {
                if (bsItens.Current != null)
                    Quantidade.Value = (bsItens.Current as TRegistro_ItensCargaAvulsa).Quantidade;
                Quantidade.Focus();
            }
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12))
                BuscarProduto();
        }

        private void Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                AlterarQTD();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            AlterarQTD();
        }

        private void Id_rota_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_rota|=|'" + Id_rota.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_rota, ds_rota },
                                            new CamadaDados.Diversos.TCD_CadRota());
        }

        private void bb_rota_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_rota|Rota|200;" +
                             "a.id_rota|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_rota, ds_rota },
                new CamadaDados.Diversos.TCD_CadRota(),
               string.Empty);
        }
    }
}
