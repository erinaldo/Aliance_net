using System;
using Utils;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFNFProdutorRural : Form
    {
        public string Nr_contrato
        { get; set; }
        public string Cd_contratante
        { get; set; }
        public string Nm_contratante
        { get; set; }
        public string Id_ticket { get; set; }
        private string pNr_nfprodutor;
        public string Nr_nfprodutor
        { get { return nr_notaprodutor.Text; } set { pNr_nfprodutor = value; } }
        private DateTime? pDt_emissao;
        public DateTime? Dt_emissao
        { get { try { return Convert.ToDateTime(dt_emissaonfprodutor.Text); } catch { return null; } } set { pDt_emissao = value; } }
        private DateTime? pDt_venctonfprodutor;
        public DateTime? Dt_venctonfprodutor
        { get { try { return DateTime.Parse(dt_venctonfprodutor.Text); }catch { return null; } } set { pDt_venctonfprodutor = value; } }
        private decimal pQtd_nfprodutor;
        public decimal Qtd_nfprodutor
        { get { return qt_nfprodutor.Value; } set { pQtd_nfprodutor = value; } }
        private decimal pVl_nfprodutor;
        public decimal Vl_nfprodutor
        { get { return vl_nfprodutor.Value; } set { pVl_nfprodutor = value; } }

        public TFNFProdutorRural()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(nr_notaprodutor.Text))
            {
                MessageBox.Show("Obrigatorio informar numero nota fiscal produtor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_notaprodutor.Focus();
                return;
            }
            if(string.IsNullOrEmpty(dt_venctonfprodutor.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data vencimento nota fiscal produtor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_venctonfprodutor.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFNFProdutorRural_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            nr_contrato.Text = Nr_contrato;
            nm_contratante.Text = Cd_contratante.Trim() + "-" + Nm_contratante.Trim();
            id_ticket.Text = Id_ticket;
            nr_notaprodutor.Text = pNr_nfprodutor;
            dt_emissaonfprodutor.Text = pDt_emissao.HasValue ? pDt_emissao.Value.ToString("dd/MM/yyyy") : string.Empty;
            dt_venctonfprodutor.Text = pDt_venctonfprodutor.HasValue ? pDt_venctonfprodutor.Value.ToString("dd/MM/yyyy") : string.Empty;
            qt_nfprodutor.Value = pQtd_nfprodutor;
            vl_nfprodutor.Value = pVl_nfprodutor;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFNFProdutorRural_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
