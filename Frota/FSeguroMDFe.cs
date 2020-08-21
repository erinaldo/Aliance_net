using System;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFSeguroMDFe : Form
    {
        private CamadaDados.Frota.TRegistro_MDFe_Seguro _rSeguro;
        public CamadaDados.Frota.TRegistro_MDFe_Seguro rSeguro
        {
            get { return bsSeguro.Current as CamadaDados.Frota.TRegistro_MDFe_Seguro; }
            set { _rSeguro = value; }
        }

        public TFSeguroMDFe()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMITENTE MDF-E", "1"));
            cbx.Add(new Utils.TDataCombo("CONTRATANTE MDF-E", "2"));
            tp_responsavel.DataSource = cbx;
            tp_responsavel.DisplayMember = "Display";
            tp_responsavel.ValueMember = "Value";
        }
        
        private void afterGrava()
        {
            if(tp_responsavel.SelectedIndex == 1 && string.IsNullOrWhiteSpace(cd_responsavel.Text))
            {
                MessageBox.Show("Obrigatório informar responsavel pelo seguro quando for por conta do contratante.", "Mensagem",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_responsavel.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(cd_seguradora.Text))
            {
                MessageBox.Show("Obrigatório informar seguradora.", "Mensagem",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_seguradora.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(nr_apolice.Text))
            {
                MessageBox.Show("Obrigatório informar Nº Apólice.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_apolice.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFSeguroMDFe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (_rSeguro != null)
                bsSeguro.DataSource = new CamadaDados.Frota.TList_MDFe_Seguro { _rSeguro };
            else bsSeguro.AddNew();
        }

        private void tp_responsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tp_responsavel.SelectedIndex == 0)
            {
                cd_responsavel.Clear();
                nm_responsavel.Clear();
                cd_responsavel.Enabled = false;
                bb_responsavel.Enabled = false;
            }
            else
            {
                cd_responsavel.Enabled = true;
                bb_responsavel.Enabled = true;
            }
        }

        private void bb_responsavel_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_responsavel, nm_responsavel }, string.Empty);
        }

        private void cd_responsavel_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_responsavel.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_responsavel, nm_responsavel }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_seguradora_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_seguradora, nm_seguradora }, string.Empty);
        }

        private void cd_seguradora_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_seguradora.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_seguradora, nm_seguradora }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFSeguroMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
