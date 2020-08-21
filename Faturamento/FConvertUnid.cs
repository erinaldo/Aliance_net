using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFConvertUnid : Form
    {
        public string pCd_unid_orig
        { get; set; }
        public string pDs_unid_orig
        { get; set; }
        public string pCd_unid_dest
        { get; set; }
        public string pDs_unid_dest
        { get; set; }
        public decimal pValor
        { get { return valor.Value; } }
        public bool pSt_multiplica
        { get { return rbMultiplica.Checked; } }
        public bool pSt_divide
        { get { return rbDivide.Checked; } }

        public TFConvertUnid()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (valor.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatório informar valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor.Focus();
                return;
            }
            if (!rbDivide.Checked && !rbMultiplica.Checked)
            {
                MessageBox.Show("Obrigatório selecionar operador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFConvertUnid_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_unidade_orig.Text = pCd_unid_orig;
            ds_unidade_orig.Text = pDs_unid_orig;
            cd_unidade_dest.Text = pCd_unid_dest;
            ds_unidade_dest.Text = pDs_unid_dest;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFConvertUnid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
