using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Estoque
{
    public partial class TFTransfEstoque : Form
    {
        public CamadaDados.Estoque.TRegistro_TransfLocal rTransf
        {
            get
            {
                if (bsTransf.Current != null)
                    return bsTransf.Current as CamadaDados.Estoque.TRegistro_TransfLocal;
                else
                    return null;
            }
        }

        public TFTransfEstoque()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        public void validaSaldo()
        {
            if (Qtde_localOrigem.Value < 1)
            {
                MessageBox.Show("O Local: " + NM_Local_Origem.Text + " escolhido não possui saldo! \nProduto: "
                    + DS_Produto.Text + " não encontrado!");
                CD_Local_Orig.Text = string.Empty; 
                NM_Local_Origem.Text = string.Empty;
                CD_Local_Orig.Focus();
            }
        }

        private void Busca_Saldo_Local_Origem()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)) &&
                (!string.IsNullOrEmpty(CD_Local_Orig.Text)))
            {
                Qtde_localOrigem.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local_Orig.Text, null);
                validaSaldo();
            }

        }

        private void Busca_Saldo_Local_Destino()
        {
            if ((!string.IsNullOrEmpty(cd_empresadest.Text)) &&
                (!string.IsNullOrEmpty(CD_Produto.Text)) &&
                (!string.IsNullOrEmpty(CD_Local_Dest.Text)))
                Qtde_localDestino.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(CD_Empresa.Text, CD_Produto.Text, CD_Local_Dest.Text, null);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, string.Empty);
            this.Busca_Saldo_Local_Destino();
            this.Busca_Saldo_Local_Origem();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            this.Busca_Saldo_Local_Destino();
            this.Busca_Saldo_Local_Origem();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string empresa_aux = "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                               "(exists(select 1 from tb_div_usuario_x_grupos y " +
                               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local_Orig.Text))
                empresa_aux += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                               "            where x.cd_empresa = a.cd_empresa " +
                               "            and x.cd_local = '" + CD_Local_Orig.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), empresa_aux);
            this.Busca_Saldo_Local_Origem();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                                " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if(!string.IsNullOrEmpty(CD_Local_Orig.Text))
                vColunas += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                               "            where x.cd_empresa = a.cd_empresa " +
                               "            and x.cd_local = '" + CD_Local_Orig.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            this.Busca_Saldo_Local_Origem();
        }

        private void BB_Local_Origem_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);

            UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                , new Componentes.EditDefault[] { CD_Local_Orig, NM_Local_Origem }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text), "isnull(a.st_registro, 'A')|<>|'C'");
            this.Busca_Saldo_Local_Origem();
        }

        private void CD_Local_Orig_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local_Orig.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'",
                                    new Componentes.EditDefault[] { CD_Local_Orig, NM_Local_Origem },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text));
            this.Busca_Saldo_Local_Origem();
        }

        private void bb_empresadest_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Descrição Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string empresa_aux = "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                               " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                               "(exists(select 1 from tb_div_usuario_x_grupos y " +
                               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local_Dest.Text))
                empresa_aux += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                               "            where x.cd_empresa = a.cd_empresa " +
                               "            and x.cd_local = '" + CD_Local_Dest.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresadest, nm_empresadest },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), empresa_aux);
            this.Busca_Saldo_Local_Destino();
        }

        private void cd_empresadest_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresadest.Text + "';" +
                "|exists|(select 1 from tb_div_usuario_x_empresa x" +
                                " where x.cd_empresa = a.cd_empresa and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local_Dest.Text))
                vColunas += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                               "            where x.cd_empresa = a.cd_empresa " +
                               "            and x.cd_local = '" + CD_Local_Dest.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresadest, nm_empresadest },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            this.Busca_Saldo_Local_Destino();
        }

        private void BB_LocalDest_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);

            UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                , new Componentes.EditDefault[] { CD_Local_Dest, NM_Local_Dest }, new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, cd_empresadest.Text), "isnull(a.st_registro, 'A')|<>|'C'");
            this.Busca_Saldo_Local_Destino();
        }

        private void CD_Local_Dest_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local_Dest.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'",
                                    new Componentes.EditDefault[] { CD_Local_Dest, NM_Local_Dest },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, cd_empresadest.Text));
            this.Busca_Saldo_Local_Destino();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            if ((CD_Local_Orig.Text != CD_Local_Dest.Text) && (CD_Local_Orig.Text != "") && (CD_Local_Dest.Text != ""))
            {
                if ((Quantidade.Value > Qtde_localOrigem.Value) && (Qtde_localOrigem.Value >= 0))
                {
                    while (Quantidade.Value > Qtde_localOrigem.Value)
                    {
                        MessageBox.Show("Quantidade Requisitada é Maior que o Saldo do Local de Origem!");
                        Quantidade.Value = 0;
                        Quantidade.Focus();
                    }
                }
            }
            else
                if ((CD_Local_Orig.Text == CD_Local_Dest.Text) || (CD_Local_Orig.Text == "") || (CD_Local_Dest.Text == ""))
                {
                    MessageBox.Show("Local de Destino Não Pode Ser igual ao Local De Origem e Não Pode Ser Nulo!");
                    CD_Local_Dest.Clear();
                    NM_Local_Dest.Clear();
                    CD_Local_Orig.Clear();
                    NM_Local_Origem.Clear();
                    CD_Local_Orig.Focus();
                }
        }

        private void TFTransfEstoque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            bsTransf.AddNew();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTransfEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
