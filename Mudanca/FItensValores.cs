using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mudanca
{
    public partial class TFItensValores : Form
    {
        private decimal pQuantidade;
        public decimal Quantidade
        { 
            get { return quantidade.Value; }
            set { pQuantidade = value; }
        }
        private decimal pVl_seguro;
        public decimal Vl_seguro
        { 
            get { return vl_seguro.Value; }
            set { pVl_seguro = value; }
        }
        public TFItensValores()
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
            this.DialogResult = DialogResult.OK;
        }

        private void TFItensValores_Load(object sender, EventArgs e)
        {
            quantidade.Value = pQuantidade;
            vl_seguro.Value = pVl_seguro;
            tot_seguro.Value = pQuantidade * pVl_seguro;
            quantidade.Focus();
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            this.Confirmar();
        }

        private void TFItensValores_KeyDown(object sender, KeyEventArgs e)
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
            tot_seguro.Value = quantidade.Value * vl_seguro.Value;
        }

        private void vl_seguro_Leave(object sender, EventArgs e)
        {
            tot_seguro.Value = quantidade.Value * vl_seguro.Value;
        }
    }
}
