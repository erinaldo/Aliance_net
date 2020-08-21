using System;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFCRMOrcamento : Form
    {
        public DateTime? Dt_agendamento { get; set; }
        public string pCd_clifor
        { get { return cd_clifor.Text; } }
        public string pNm_clifor
        { get { return nm_clifor.Text; } }
        public string pDs_historico
        { get { return ds_historico.Text; } }
        public string pDt_evento
        { get { return dt_agendamento.Text; } }
        public string pHr_evento
        { get { return hr_agendamento.Text; } }
        public string pNm_contato
        { get { return nm_contato.Text; } }
        public string pFone
        { get { return fone_contato.Text; } }

        public TFCRMOrcamento()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(string.IsNullOrEmpty(nm_clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nm_clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ds_historico.Text))
            {
                MessageBox.Show("Obrigatório informar histórico evento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_historico.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_agendamento.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_agendamento.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFCRMOrcamento_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            ds_historico.CharacterCasing = CharacterCasing.Normal;
            if (Dt_agendamento.HasValue)
                dt_agendamento.Text = Dt_agendamento.Value.ToString("dd/MM/yyyy");
        }

        private void fone_contato_TextChanged(object sender, EventArgs e)
        {
            if (fone_contato.Text.SoNumero().Length.Equals(10))
            {
                fone_contato.Text = "(" + fone_contato.Text.SoNumero().Substring(0, 2) + ")" + fone_contato.Text.SoNumero().Substring(2, 4) + "-" + fone_contato.Text.SoNumero().Substring(6, 4);
                fone_contato.SelectionStart = fone_contato.Text.Length;
            }
            else if (fone_contato.Text.SoNumero().Length.Equals(11))
                if (fone_contato.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    fone_contato.Text = "(" + fone_contato.Text.SoNumero().Substring(0, 3) + ")" + fone_contato.Text.SoNumero().Substring(3, 4) + "-" + fone_contato.Text.SoNumero().Substring(7, 4);
                    fone_contato.SelectionStart = fone_contato.Text.Length;
                }
                else
                {
                    fone_contato.Text = "(" + fone_contato.Text.SoNumero().Substring(0, 2) + ")" + fone_contato.Text.SoNumero().Substring(2, 5) + "-" + fone_contato.Text.SoNumero().Substring(7, 4);
                    fone_contato.SelectionStart = fone_contato.Text.Length;
                }
            else if (fone_contato.Text.SoNumero().Length.Equals(12))
            {
                fone_contato.Text = "(" + fone_contato.Text.SoNumero().Substring(0, 3) + ")" + fone_contato.Text.SoNumero().Substring(3, 5) + "-" + fone_contato.Text.SoNumero().Substring(8, 4);
                fone_contato.SelectionStart = fone_contato.Text.Length;
            }
        }

        private void bbContato_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                string vColunas = "a.NM_Contato|Nome Contato|250;" +
                                  "a.Fone|Fone Contato|60";
                string vParam = string.Empty;
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                    vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
                FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nm_contato, fone_contato },
                    new CamadaDados.Financeiro.Cadastros.TCD_CadContatoCliFor(), vParam);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCRMOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bbClifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            if (!string.IsNullOrEmpty(cd_clifor.Text))
                bbContato_Click(this, new EventArgs());
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'", new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_clifor.Text))
                bbContato_Click(this, new EventArgs());
        }

        private void cd_clifor_TextChanged(object sender, EventArgs e)
        {
            nm_clifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
        }
    }
}
