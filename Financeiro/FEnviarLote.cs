using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFEnviarLote : Form
    {
        public string Nr_lote
        { get { return nr_lote.Text; } }
        public DateTime? Dt_lote
        { get { try { return DateTime.Parse(dt_lote.Text); } catch { return null; } } }

        public TFEnviarLote()
        {
            InitializeComponent();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFEnviarLote_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            dt_lote.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFEnviarLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
