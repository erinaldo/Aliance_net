using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque.Cadastros;

namespace Estoque
{
    public partial class TFLanAcertarVlMedio : Form
    {
        public TRegistro_LanEstoque rEstoque
        {
            get
            {
                if (BS_Lan_Estoque.Current != null)
                    return (BS_Lan_Estoque.Current as TRegistro_LanEstoque);
                else
                    return null;
            }
        }

        public TFLanAcertarVlMedio()
        {
            InitializeComponent();
        }

        private void buscarLocalArm()
        {
            TList_CadLocalArm_X_Empresa lLocal = TCN_CadLocalArm_X_Empresa.Busca(string.Empty, CD_Empresa.Text, string.Empty, string.Empty, null);
            if (lLocal.Count > 0)
            {
                CD_Local.Text = lLocal[0].CD_Local;
                DS_Local.Text = lLocal[0].DS_Local;
            }
        }

        public void busca_Valor_Unitario()
        {
            if (BS_Lan_Estoque.Current != null)
                if (((BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_empresa != "") && ((BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto != ""))
                {
                    decimal Tot_Entrada = decimal.Zero;
                    decimal Tot_Saida = decimal.Zero;
                    decimal Tot_Saldo = decimal.Zero;
                    decimal VL_Estoque_ent = decimal.Zero;
                    decimal VL_Estoque_sai = decimal.Zero;
                    decimal VL_SaldoEstoque = decimal.Zero;
                    decimal VL_Medio = decimal.Zero;

                    TCN_LanEstoque.Valores_EstoqueLocal((BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_empresa, 
                                                        (BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto, 
                                                        (BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_local,
                                                         ref Tot_Entrada, 
                                                         ref Tot_Saida,
                                                         ref Tot_Saldo, 
                                                         ref VL_Estoque_ent, 
                                                         ref VL_Estoque_sai, 
                                                         ref VL_SaldoEstoque, 
                                                         ref VL_Medio,
                                                         null);


                    TOT_SALDO.Text = Tot_Saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                    VL_SALDO.Text = VL_SaldoEstoque.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    VL_MEDIO.Text = VL_Medio.ToString("N7", new System.Globalization.CultureInfo("pt-BR", true));
                }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanAcertarVlMedio_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            BS_Lan_Estoque.AddNew();
            DT_Lancamento.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), vParam);
            buscarLocalArm();
            busca_Valor_Unitario();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());
            buscarLocalArm();
            busca_Valor_Unitario();
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vParamFix = "e.ST_Servico |<>| 'S'";
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto }, vParamFix);
            busca_Valor_Unitario();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "';e.ST_Servico |<>| 'S'";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto },
                                    new TCD_CadProduto());
            busca_Valor_Unitario();
        }

        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            UtilPesquisa.BTN_BUSCA("DS_Local|Local|300;CD_Local|Código|80"
                               , new Componentes.EditDefault[] { CD_Local, DS_Local },
                               new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text), "isnull(a.st_registro, 'A')|<>|'C'");
            busca_Valor_Unitario();
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);

            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text + "';isnull(a.st_registro, 'A')|<>|'C'",
                new Componentes.EditDefault[] { CD_Local, DS_Local },
                new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text));
            busca_Valor_Unitario();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanAcertarVlMedio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
