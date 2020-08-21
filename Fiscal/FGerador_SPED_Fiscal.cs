using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Querys.Diversos;
using Querys.Financeiro;
using Querys.Fiscal;
using Querys.Faturamento;
using Utils;
using Querys;
using FormBusca;
using SPED.ProcessarSPED;

namespace Fiscal
{
    public partial class TFGerador_SPED_Fiscal : FormPadrao.FFormPadrao
    {
        public TFGerador_SPED_Fiscal()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
        }

        public override void afterBusca()
        {
            try
            {
                SPEDFiscal SPEDFiscal = new SPEDFiscal();
                SPEDFiscal.CD_Empresa = cd_empresa.Text;
                SPEDFiscal.DTInicio = Convert.ToDateTime(DT_Inicio.Text);
                SPEDFiscal.DTFinal = Convert.ToDateTime(DT_Final.Text);

                if (rb_Original.Checked)
                    SPEDFiscal.CD_Finalidade = "0";
                else
                    SPEDFiscal.CD_Finalidade = "1";

                if (rb_PerfilA.Checked)
                    SPEDFiscal.IND_Perfil = "A";
                else if (rb_PerfilB.Checked)
                    SPEDFiscal.IND_Perfil = "B";
                else
                    SPEDFiscal.IND_Perfil = "C";

                if (rb_Industrial.Checked)
                    SPEDFiscal.IND_Atividade = "0";
                else
                    SPEDFiscal.IND_Atividade = "1";

                SPEDFiscal.ProcessaSPEDFiscal();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #region "FILTROS BUSCA"

            private void cd_empresa_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("cd_empresa|=|'" + cd_empresa.Text + "';" +
                "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
                , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new TDatEmpresa());

            }

            private void bb_empresa_busca_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new TDatEmpresa(),
               "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");

            }

        #endregion
    }
}
