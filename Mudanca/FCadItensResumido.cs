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
    public partial class TFCadItensResumido : Form
    {
        public string Ds_item
        { get { return ds_item.Text; } }
        public decimal MetragemCubica
        { get { return metragemcubica.Value; } }

        public TFCadItensResumido()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_item.Text))
            {
                MessageBox.Show("Obrigatorio informar descrição do item.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_item.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadItensResumido_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadItensResumido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
