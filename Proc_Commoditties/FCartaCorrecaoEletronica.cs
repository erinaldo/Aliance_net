using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFCartaCorrecaoEletronica : Form
    {
        public string Ds_correcao
        { get { return ds_correcao.Text; } }

        public TFCartaCorrecaoEletronica()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (ds_correcao.Text.Trim().Length < 15)
                MessageBox.Show("Obrigatorio informar pelo menos 15 caracteres no campo correção.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.DialogResult = DialogResult.OK;
        }

        private void TFCartaCorrecaoEletronica_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCartaCorrecaoEletronica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
