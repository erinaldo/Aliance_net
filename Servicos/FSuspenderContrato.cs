using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFSuspenderContrato : Form
    {
        public string pDs_motivo
        { get { return ds_motivo.Text; } }
        public string pDt_prevtermsusp
        { get { return dt_prevtermsusp.Text; } }

        public TFSuspenderContrato()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(ds_motivo.Text))
            {
                MessageBox.Show("Obrigatório informar motivo suspender contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds_motivo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_prevtermsusp.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data prevista terminar suspensão contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_prevtermsusp.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFSuspenderContrato_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFSuspenderContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
