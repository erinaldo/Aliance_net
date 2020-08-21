using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFHistorico : Form
    {
        public bool St_visualizar
        { get; set; }
        private string pds_mensagem;
        public string pDs_mensagem
        {
            get {return ds_mensagem.Text; }
            set { pds_mensagem = value; }
        }
        public TFHistorico()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_mensagem.Text))
            {
                MessageBox.Show("Obrigatório informar Mensagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lblConfirma_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void lbCancela_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFHistorico_Load(object sender, EventArgs e)
        {
            if (St_visualizar)
            {
                ds_mensagem.ReadOnly = true;
                lblConfirma.Enabled = false;
                ds_mensagem.Text = pds_mensagem;
            }
            else
                ds_mensagem.Focus();
        }

        private void TFHistorico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && !St_visualizar)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
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

        private void lbCancela_MouseEnter(object sender, EventArgs e)
        {
            lbCancela.BorderStyle = BorderStyle.FixedSingle;
            lbCancela.Cursor = Cursors.Hand;
            lbCancela.ForeColor = Color.Blue;
        }

        private void lbCancela_MouseLeave(object sender, EventArgs e)
        {
            lbCancela.BorderStyle = BorderStyle.None;
            lbCancela.Cursor = Cursors.Default;
            lbCancela.ForeColor = Color.Black;
        }
    }
}
