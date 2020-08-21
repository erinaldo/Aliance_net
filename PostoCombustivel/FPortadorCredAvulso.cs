using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFPortadorCredAvulso : Form
    {
        public string Tp_portador
        { get; set; }
        public TFPortadorCredAvulso()
        {
            InitializeComponent();
        }

        private void bb_dinheiro_Click(object sender, EventArgs e)
        {
            Tp_portador = "DH";
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cheque_Click(object sender, EventArgs e)
        {
            Tp_portador = "CH";
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            Tp_portador = "CC";
            this.DialogResult = DialogResult.OK;
        }

        private void TFPortadorCredAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
            {
                Tp_portador = "DH";
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F2))
            {
                Tp_portador = "CH";
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F3))
            {
                Tp_portador = "CC";
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.F4))
            {
                Tp_portador = "CD";
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cartaoDeb_Click(object sender, EventArgs e)
        {
            Tp_portador = "CD";
            this.DialogResult = DialogResult.OK;
        }
    }
}
