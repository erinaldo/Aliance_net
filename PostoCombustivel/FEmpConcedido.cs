using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFEmpConcedido : Form
    {
        public CamadaDados.Faturamento.PDV.TRegistro_EmprestimoConcedido rEmp
        {
            get
            {
                if (bsEmprestimo.Current != null)
                    return bsEmprestimo.Current as CamadaDados.Faturamento.PDV.TRegistro_EmprestimoConcedido;
                else return null;
            }
        }
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }

        public TFEmpConcedido()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFEmpConcedido_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsEmprestimo.AddNew();
            cd_empresa.Text = pCd_empresa;
            nm_empresa.Text = pNm_empresa;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_pdc_convenio_x_clifor x " +
                            "           inner join tb_pdc_convenio y " +
                            "           on x.cd_empresa = y.cd_empresa " +
                            "           and x.id_convenio = y.id_convenio " +
                            "           inner join tb_fin_portador z " +
                            "           on y.cd_portador = z.cd_portador " +
                            "           where x.cd_clifor = a.cd_clifor " +
                            "           and z.TP_PortadorPDV = 'P' " +
                            "           and isnull(y.st_registro, 'A') <> 'E' " +
                            "           and convert(datetime, floor(convert(decimal(30,10), case when ISNULL(DiasValidade, 0) > 0 then DATEADD(DAY, DiasValidade, DT_Convenio) else GETDATE() end))) >= convert(datetime, floor(convert(decimal(30,10), GETDATE()))))";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, vParam);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_pdc_convenio_x_clifor x " +
                            "           inner join tb_pdc_convenio y " +
                            "           on x.cd_empresa = y.cd_empresa " +
                            "           and x.id_convenio = y.id_convenio " +
                            "           inner join tb_fin_portador z " +
                            "           on y.cd_portador = z.cd_portador " +
                            "           where x.cd_clifor = a.cd_clifor " +
                            "           and z.TP_PortadorPDV = 'P' " +
                            "           and isnull(y.st_registro, 'A') <> 'E' " +
                            "           and convert(datetime, floor(convert(decimal(30,10), case when ISNULL(DiasValidade, 0) > 0 then DATEADD(DAY, DiasValidade, DT_Convenio) else GETDATE() end))) >= convert(datetime, floor(convert(decimal(30,10), GETDATE()))))";
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEmpConcedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_motorista }, string.Empty);
        }
    }
}
