using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal
{
    public partial class TFImportDominio : Form
    {
        public bool St_cliente
        { get { return cbCliente.Checked; } }
        public bool St_fornecedor
        { get { return cbFornecedor.Checked; } }
        public bool St_remetdest
        { get { return cbRemetDest.Checked; } }

        public TFImportDominio()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cbCliente.Checked ||
                cbFornecedor.Checked ||
                cbRemetDest.Checked)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Obrigatorio selecionar pelo menos uma opção de filtro para gerar arquivo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFImportDominio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFImportDominio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
