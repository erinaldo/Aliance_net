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
    public partial class TFEntrega : Form
    {
        public bool St_cliente
        { get; set; }
        public TFEntrega()
        {
            InitializeComponent();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            this.St_cliente = false;
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cliente_Click(object sender, EventArgs e)
        {
            this.St_cliente = true;
            this.DialogResult = DialogResult.OK;
        }

        private void TFEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.St_cliente = false;
            else if (e.KeyCode.Equals(Keys.F3))
                this.St_cliente = true;
        }
    }
}
