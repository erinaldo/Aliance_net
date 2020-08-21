using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFListaImpressoras : Form
    {
        public string Impressora
        { get { return lbImpressoras.SelectedItem != null ? lbImpressoras.SelectedItem.ToString() : string.Empty; } }

        public TFListaImpressoras()
        {
            InitializeComponent();
        }

        private void ListaImpressoras()
        {
            lbImpressoras.Items.Clear();
            //Buscar Lista Impressoras
            for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
                lbImpressoras.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters[i]);

            //Seleciono o primeiro da listagem visando agilizar o processo
            if (lbImpressoras.Items.Count > 0)
                lbImpressoras.SelectedIndex = 0;
        }

        private void TFListaImpressoras_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.ListaImpressoras();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaImpressoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                this.ListaImpressoras();
        }

        private void bb_atualizar_Click(object sender, EventArgs e)
        {
            this.ListaImpressoras();
        }
    }
}
