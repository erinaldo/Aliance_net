using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFLoteIndice : Form
    {
        public decimal Pc_ini_resultado
        { get { return pc_ini_resultado.Value; } }
        public decimal Pc_fin_resultado
        { get { return pc_fin_resultado.Value; } }
        public decimal Intervalo_resultado
        { get { return intervalo_resultado.Value; } }
        public decimal Pc_desconto_apartir
        { get { return pc_desc_apartir.Value; } }
        public decimal Pc_desconto_inicial
        { get { return pc_desc_inicial.Value; } }
        public decimal Intervalo_desconto
        { get { return intervalo_desconto.Value; } }

        public TFLoteIndice()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLoteIndice_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLoteIndice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
