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
    public partial class TFProvisao : Form
    {
        public CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque rProv
        {
            get
            {
                if (bsProvisao.Current != null)
                    return bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque;
                else
                    return null;
            }
        }

        public TFProvisao()
        {
            InitializeComponent();
        }
        
        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local.Text))
                vParam += "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.cd_local = '" + CD_Local.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
            VL_Unitario.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(CD_Empresa.Text, cd_produto.Text, null);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local.Text))
                vColunas += "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_local = '" + CD_Local.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
            VL_Unitario.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(CD_Empresa.Text, cd_produto.Text, null);
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vParamFix = "isnull(e.ST_Servico, 'N')|<>|'S'";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, DS_Produto, sigla_unidade }, vParamFix);
            VL_Unitario.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(CD_Empresa.Text, cd_produto.Text, null);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.ST_Servico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { cd_produto, DS_Produto, sigla_unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            VL_Unitario.Value = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(CD_Empresa.Text, cd_produto.Text, null);
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);
            UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { CD_Local, DS_Local },
                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, CD_Empresa.Text), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto List_Local_x_Produto = new CamadaDados.Estoque.Cadastros.TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(cd_produto.Text))
                List_Local_x_Produto = CamadaNegocio.Estoque.Cadastros.TCN_CadLocalArm_X_Produto.Busca(string.Empty, cd_produto.Text);

            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text + "';isnull(a.st_registro, 'A')|<>|'C'",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? cd_produto.Text : string.Empty, CD_Empresa.Text));
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProvisao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFProvisao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsProvisao.AddNew();
        }
    }
}
