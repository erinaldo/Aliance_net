using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFDesconto : Form
    {
        public decimal Vl_venda
        { get; set; }
        public bool St_valor
        { get { return rbValor.Checked; } }
        public decimal Desconto
        { get { return vl_desconto.Value; } }
        public bool pRb_Valor { get; set; } = false;

        public TFDesconto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (rbPerc.Checked && vl_desconto.Value >= 100)
            {
                MessageBox.Show("Não é permitido dar desconto maior ou igual a 100%.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rbValor.Checked && vl_desconto.Value >= Vl_venda)
            {
                MessageBox.Show("Não é permitido dar desconto maior ou igual ao valor da venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void rbPerc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPerc.Checked)
            {
                vl_desconto.Maximum = 100;
                lblLabel.Text = "% Desconto";
                vl_desconto.Value = vl_desconto.Minimum;
                vl_desconto.DecimalPlaces = 2;
            }   
        }

        private void rbValor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValor.Checked)
            {
                vl_desconto.Maximum = 999999999999999;
                lblLabel.Text = "Valor Desconto";
                vl_desconto.Value = vl_desconto.Minimum;
                vl_desconto.DecimalPlaces = 5;
            }
        }

        private void TFDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.V))
                rbValor.Checked = true;
            else if (e.KeyCode.Equals(Keys.P))
                rbPerc.Checked = true;
            else if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void lblConfirma_MouseLeave(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.None;
            lblConfirma.Cursor = Cursors.Default;
            lblConfirma.ForeColor = Color.Black;
        }

        private void lblConfirma_MouseEnter(object sender, EventArgs e)
        {
            lblConfirma.BorderStyle = BorderStyle.FixedSingle;
            lblConfirma.Cursor = Cursors.Hand;
            lblConfirma.ForeColor = Color.Blue;
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

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFDesconto_Load(object sender, EventArgs e)
        {
            if (pRb_Valor) rbValor.Checked = true;

            if (rbPerc.Checked)
            {
                vl_desconto.Maximum = 100;
                lblLabel.Text = "% Desconto";
                vl_desconto.Value = vl_desconto.Minimum;
            }
            else
            {
                vl_desconto.Maximum = 999999999999999;
                lblLabel.Text = "Valor Desconto";
                vl_desconto.Value = vl_desconto.Minimum;
            }
        }
    }
}
