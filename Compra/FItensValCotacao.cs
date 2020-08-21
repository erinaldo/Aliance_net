using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compra
{
    public partial class TFItensValCotacao : Form
    {
        public decimal pQTD_requisitada
        { get; set; }
        private decimal pQuantidade;
        public decimal Quantidade
        {
            get { return quantidade.Value; }
            set { pQuantidade = value; }
        }
        private decimal pVl_unitCotado;
        public decimal Vl_unitCotado
        {
            get { return vl_unitCotado.Value; }
            set { pVl_unitCotado = value; }
        }
        private decimal pVl_ipi;
        public decimal Vl_ipi
        {
            get { return vl_ipi.Value; }
            set { pVl_ipi = value; }
        }
        private decimal pVl_icmssubst;
        public decimal Vl_icmssubst
        {
            get { return vl_icmssubst.Value; }
            set { pVl_icmssubst = value; }
        }
        private decimal pPc_icms;
        public decimal Pc_icms
        {
            get { return pc_icms.Value; }
            set { pPc_icms = value; }
        }

        public TFItensValCotacao()
        {
            InitializeComponent();
        }

        private void Confirmar()
        {
            if (quantidade.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if (vl_unitCotado.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar vl.unitário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_unitCotado.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFItensValCotacao_Load(object sender, EventArgs e)
        {
            pQuantidade = pQTD_requisitada;
            quantidade.Value = pQuantidade;
            vl_unitCotado.Value = pVl_unitCotado;
            vl_ipi.Value = pVl_ipi;
            vl_icmssubst.Value = pVl_icmssubst;
            pc_icms.Value = pPc_icms;
            quantidade.Focus();
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            this.Confirmar();
        }

        private void TFItensValCotacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.Confirmar();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lblConfirma_MouseEnter(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.FixedSingle;
            lblConfirma.Cursor = Cursors.Hand;
            lblConfirma.ForeColor = Color.Blue;
        }

        private void lblConfirma_MouseLeave(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.None;
            lblConfirma.Cursor = Cursors.Default;
            lblConfirma.ForeColor = Color.Black;
        }

        private void lblCancela_MouseEnter(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.FixedSingle;
            lblCancela.Cursor = Cursors.Hand;
            lblCancela.ForeColor = Color.Blue;
        }

        private void lblCancela_MouseLeave(object sender, EventArgs e)
        {
            lblCancela.BorderStyle = BorderStyle.None;
            lblCancela.Cursor = Cursors.Default;
            lblCancela.ForeColor = Color.Black;
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            if (quantidade.Value > pQTD_requisitada)
                quantidade.Value = pQTD_requisitada;
        }
    }
}
