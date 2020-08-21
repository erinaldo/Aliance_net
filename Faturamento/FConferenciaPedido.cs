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
    public partial class TFConferenciaPedido : Form
    {
        public TFConferenciaPedido()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsEntregaPedido.Count > 0)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFConferenciaPedido_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
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

        private void TFConferenciaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_proximo_Click(object sender, EventArgs e)
        {
            bsEntregaPedido.MoveNext();
            qtd_entregue.Focus();
        }

        private void bsEntregaPedido_PositionChanged(object sender, EventArgs e)
        {
            if (bsEntregaPedido.Current != null)
                qtd_entregue.Enabled = (bsEntregaPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido).St_registro.Trim().ToUpper() != "P";
        }

        private void TFConferenciaPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
