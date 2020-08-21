using System;
using System.Drawing;
using System.Windows.Forms;

namespace Componentes
{
    public partial class TFDebitoCredito : Form
    {
        public string D_C
        { get; set; }

        public TFDebitoCredito()
        {
            InitializeComponent();
            D_C = string.Empty;
        }

        private void TFDebitoCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
            {
                D_C = "D";
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F2))
            {
                D_C = "C";
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F3))
            {
                D_C = "R";
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
        }

        private void lblCancelar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblCancelar_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lblDebito_Click(object sender, EventArgs e)
        {
            D_C = "D";
            DialogResult = DialogResult.OK;
        }

        private void lblDebito_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblDebito_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void lblCredito_Click(object sender, EventArgs e)
        {
            D_C = "C";
            DialogResult = DialogResult.OK;
        }

        private void lblCredito_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblCredito_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            D_C = "R";
            DialogResult = DialogResult.OK;
        }
    }
}
