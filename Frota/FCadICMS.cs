using System;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFCadICMS : Form
    {
        public string Cd_st
        { get { return cbSt.SelectedValue.ToString(); } }
        public decimal pAliquota
        { get { return PC_Aliquota_ICMS.Value; } }
        public string Cd_imposto
        { get; set; }
        public decimal pAliquotaDest
        { get { return pc_aliquotadest.Value; } }

        public TFCadICMS()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cbSt.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar Situação Tributária!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSt.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
                
        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadICMS_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbSt.DataSource = new CamadaDados.Fiscal.TCD_CadSitTribut().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_imposto",
                                        vOperador = "=",
                                        vVL_Busca = Cd_imposto
                                    }
                                }, 0, string.Empty);
            cbSt.DisplayMember = "cd_ds";
            cbSt.ValueMember = "cd_st";
        }

        private void TFCadICMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
