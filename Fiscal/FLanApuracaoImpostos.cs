using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Fiscal
{
    public partial class TFLanApuracaoImpostos : Form
    {
        public TFLanApuracaoImpostos()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (DT_Inicial.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Inicial.Focus();
                return;
            }
            if (DT_Final.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Final.Focus();
                return;
            }
            //Buscar sintetico
            bsSintetico.DataSource = CamadaNegocio.Fiscal.TCN_ApurarImpostos.BuscarSintetico(cd_empresa.Text,
                                                                                             cd_imposto.Text,
                                                                                             DT_Inicial.Text,
                                                                                             DT_Final.Text);
            //Totalizar impostos Retidos
            lbl_totdeb_retido.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("RETIDO")).Sum(p => p.Vl_debito).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            lbl_totcred_retido.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("RETIDO")).Sum(p => p.Vl_credito).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            lbl_totliq_retido.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("RETIDO")).Sum(p => p.Vl_SaldoPagar).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            //Totalizar impostos calculados
            lbl_totdeb_calc.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("CALCULADO")).Sum(p => p.Vl_debito).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            lbl_totcred_calc.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("CALCULADO")).Sum(p => p.Vl_credito).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
            lbl_totliq_calc.Text = (bsSintetico.DataSource as CamadaDados.Fiscal.TList_SinteticoImpostos).Where(p => p.Tp_imposto.Trim().ToUpper().Equals("CALCULADO")).Sum(p => p.Vl_SaldoPagar).ToString("N2", new System.Globalization.CultureInfo("en-US", true));

            //Buscar analitico
            bsAnalitico.DataSource = CamadaNegocio.Fiscal.TCN_ApurarImpostos.BuscarAnalitico(cd_empresa.Text,
                                                                                             cd_imposto.Text,
                                                                                             DT_Inicial.Text,
                                                                                             DT_Final.Text);
            bsAnalitico_PositionChanged(this, new EventArgs());
        }   

        private void FLaTnApuracaoImpostos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|250;" +
                              "a.cd_imposto|Cd. Imposto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|'" + cd_imposto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsAnalitico_PositionChanged(object sender, EventArgs e)
        {
            if (bsAnalitico.Current != null)
            {
                //Buscar nota fiscal
                bsNotaFiscal.DataSource =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca((bsAnalitico.Current as CamadaDados.Fiscal.TRegistro_AnaliticoImpostos).Cd_empresa,
                                                                                  (bsAnalitico.Current as CamadaDados.Fiscal.TRegistro_AnaliticoImpostos).Nr_lanctofiscal,
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  decimal.Zero,
                                                                                  decimal.Zero,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  null);
                bsNotaFiscal_PositionChanged(this, new EventArgs());
            }
        }

        private void bsNotaFiscal_PositionChanged(object sender, EventArgs e)
        {
            if (bsNotaFiscal.Current != null)
                //Buscar itens da nota
                bsItensNota.DataSource =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(
                    new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item()
                    {
                        Cd_empresa = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Cd_empresa,
                        Nr_lanctofiscal = (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).Nr_lanctofiscal
                    }, 0, string.Empty, null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanApuracaoImpostos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
