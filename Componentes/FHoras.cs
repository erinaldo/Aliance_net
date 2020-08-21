using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Componentes
{
    public partial class TFHoras : Form
    {
        public string pHoras
        { get { return horas.Text; } }

        public string Ds_label
        { get; set; }

        public TFHoras()
        {
            InitializeComponent();
            this.Ds_label = string.Empty;
        }

        private void Confirmar()
        {
            if (string.IsNullOrEmpty(horas.Text))
            {
                MessageBox.Show("Obrigatorio informar " + Ds_label.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                horas.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFHoras_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Ds_label))
                lblQtde.Text = Ds_label;
        }

        private void TFHoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.Confirmar();
            else if (e.KeyCode.Equals(Keys.Escape))
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

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            this.Confirmar();
        }

        private void lblCancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void horas_KeyDown(object sender, KeyEventArgs e)
        {
            if (horas.SelectionStart == 2 || horas.SelectionStart == 3)
            {
                if (e.KeyValue > 101 && e.KeyValue <= 109)
                    e.SuppressKeyPress = true;
                else if (e.KeyValue > 53 && e.KeyValue <= 57)
                    e.SuppressKeyPress = true;
            }
        }
    }
}
