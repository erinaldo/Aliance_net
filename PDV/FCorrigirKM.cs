using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFCorrigirKM : Form
    {
        public decimal Ultimo_km
        { get; set; }
        public decimal Km_atual
        { get; set; }
        public decimal Km_corrigido
        { get { return km_corrigido.Value; } }

        public TFCorrigirKM()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (km_corrigido.Value > km_atual.Value)
            {
                MessageBox.Show("KM corrigido não pode ser maior que KM atual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                km_corrigido.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCorrigirKM_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            ultimo_km.Value = this.Ultimo_km;
            km_atual.Value = this.Km_atual;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCorrigirKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
