using System;
using System.Data;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Compra
{
    public partial class TFRequisicao : Form
    {
        private CamadaDados.Compra.Lancamento.TRegistro_Requisicao rreq;
        public CamadaDados.Compra.Lancamento.TRegistro_Requisicao rReq
        {
            get
            {
                if (bsRequisicao.Current != null)
                    return bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao;
                else
                    return null;
            }
            set
            { rreq = value; }
        }

        public TFRequisicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(string.IsNullOrEmpty(cd_produto.Text) && string.IsNullOrEmpty(ds_produto.Text))
                {
                    MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_produto.Focus();
                    return;
                }
                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Tp_requisicao =
                        (cbRequisicao.SelectedItem as CamadaDados.Compra.TRegistro_TpRequisicao).Tp_requisicao;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFRequisicao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bb_addProduto.Enabled = new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.ID_Menu",
                                                vOperador = "=",
                                                vVL_Busca = "'025800'"//Codigo do Menu Cadastro de Produto
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.Login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                            }
                                        }, "1") != null;
            //Empresas
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
            //Requisitante
            cbRequisitante.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                                            "where x.cd_clifor_cmp = a.cd_clifor " +
                                                            "and isnull(x.st_requisitar, 'N') = 'S' " +
                                                            (rreq == null ? "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "'" : "") + ")"
                                            }
                                        }, 0, string.Empty);
            cbRequisitante.DisplayMember = "NM_Clifor";
            cbRequisitante.ValueMember = "CD_Clifor";
            pDados.set_FormatZero();
            if (rreq != null)
            {
                bsRequisicao.DataSource = new CamadaDados.Compra.Lancamento.TList_Requisicao() { rreq };
                cbEmpresa.Enabled = false;
                cbRequisitante.Enabled = false;
                cbRequisicao.Enabled = new CamadaDados.Compra.Lancamento.TCD_Requisicao().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "not exists(select 1 from tb_cmp_cotacao x " +
                                                            "where x.cd_empresa = '" + rreq.Cd_empresa.Trim() + "' " +
                                                            "and x.id_requisicao = " + rreq.Id_requisicao.Value.ToString() + ") and " +
                                                            "not exists(select 1 from tb_cmp_requisicao_x_negociacao x " +
                                                            "where x.cd_empresa = '" + rreq.Cd_empresa.Trim() + "' " +
                                                            "and x.id_requisicao = " + rreq.Id_requisicao.Value.ToString() + ")"
                                            }
                                        }, "1") != null;
                cbRequisitante.Focus();
            }
            else
            {
                bsRequisicao.AddNew();
                cbEmpresa.SelectedIndex = 0;
                if (cbRequisitante.Items.Count > 0)
                {
                    cbRequisitante.SelectedIndex = 0;
                    cbRequisicao.Focus();

                }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
                
        private void bb_produto_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (cbRequisicao.SelectedItem != null)
                if ((cbRequisicao.SelectedItem as CamadaDados.Compra.TRegistro_TpRequisicao).Tp_requisicao.Trim().ToUpper().Equals("I"))
                    vParam = "isnull(e.st_consumointerno, 'N')|=|'S'";
                else vParam = "isnull(e.st_industrializado, 'N')|<>|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, vParam);
            if (linha != null)
                sigla_unidade.Text = linha["sigla_unidade"].ToString();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            if (cbRequisicao.SelectedItem != null)
                if ((cbRequisicao.SelectedItem as CamadaDados.Compra.TRegistro_TpRequisicao).Tp_requisicao.Trim().ToUpper().Equals("I"))
                    vColunas += ";isnull(e.st_consumointerno, 'N')|=|'S'";
                else vColunas += ";isnull(e.st_industrializado, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { cd_produto, ds_produto, sigla_unidade },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
            {
                string vColunas = "DS_Local|Local Armazenagem|200;" +
                                  "CD_Local|Cd. Local|80";
                string vParam = "|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                                "           where x.cd_local = a.cd_local " +
                                "           and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString() + "');" +
                                "isnull(a.st_registro, 'A')|<>|'C'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
            }
            else MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue != null)
            {
                string vParam = "cd_local|=|'" + cd_local.Text.Trim() + "';" +
                                "|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                                "           where x.cd_local = a.cd_local " +
                                "           and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString() + "');" +
                                "isnull(a.st_registro, 'A')|<>|'C'";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                                        new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
            }
            else MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_addProduto_Click(object sender, EventArgs e)
        {
            if (!CamadaNegocio.Diversos.TCN_CadAcesso.AcessarMenu(025800))
            {
                MessageBox.Show("Usuário sem permissão de menu para acessar funcionalidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Proc_Commoditties.TFAtualizaCadProduto fProd = new Proc_Commoditties.TFAtualizaCadProduto())
            {
                if (fProd.ShowDialog() == DialogResult.OK)
                    if (fProd.rProd != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                            MessageBox.Show("Produto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Buscar registro produto
                            cd_produto.Text = fProd.rProd.CD_Produto;
                            ds_produto.Text = fProd.rProd.DS_Produto;
                            cd_local.Focus();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cbRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRequisitante.SelectedItem != null)
            {
                string tp_requisicao = string.Empty;
                if(bsRequisicao.Current != null)
                    tp_requisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_tprequisicaostr;
                cbRequisicao.DataSource = new CamadaDados.Compra.TCD_TpRequisicao().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_div_usuario_x_tprequisicao x " +
                                                                "where x.id_tprequisicao = a.id_tprequisicao " +
                                                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                                }
                                            }, 0, string.Empty);
                cbRequisicao.ValueMember = "id_tprequisicao";
                cbRequisicao.DisplayMember = "ds_tprequisicao";
                if (!string.IsNullOrEmpty(tp_requisicao))
                {
                    (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_tprequisicaostr = tp_requisicao;
                    bsRequisicao.ResetCurrentItem();
                }
            }
        }

        private void cd_produto_TextChanged(object sender, EventArgs e)
        {
            ds_produto.Enabled = string.IsNullOrEmpty(cd_produto.Text);
        }

        private void cbRequisicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd_produto.Clear();
            ds_produto.Clear();
            cd_local.Clear();
            ds_local.Clear();
        }
    }
}
