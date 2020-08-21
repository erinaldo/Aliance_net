using CamadaDados.Financeiro.Cartao;
using FormBusca;
using System;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFCarregarCartaoPrePago : Form
    {
        public TRegistro_CarregaCartaoPre rCarregar => bsCarregarPrePago.Current as TRegistro_CarregaCartaoPre ?? null;
        public TFCarregarCartaoPrePago()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFCarregarCartaoPrePago_Load(object sender, EventArgs e)
        {
            bsCarregarPrePago.AddNew();
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

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cartao|Cartão|200;" +
                              "a.nr_cartao|Nº Cartão|100;" +
                              "a.nomeusuario|Titular|100;" +
                              "a.id_cartao|Id. cartão|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_cartao, nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito(), "a.st_prepago|=|'S'");
        }

        private void id_cartao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cartao|=|" + id_cartao.Text +
                            ";a.st_prepago|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cartao, nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito());
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                            "a.st_contacartao|=|1;" +
                            "a.st_contacompensacao|=|'N';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Codigo|80";
            string vParam = "a.st_contacartao|=|1;" +
                            "a.st_contacompensacao|=|'N';" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFCarregarCartaoPrePago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
