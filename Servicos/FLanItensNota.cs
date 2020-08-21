using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFLanItensNota : Form
    {
        public CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItens
        { get; set; }

        public TFLanItensNota()
        {
            InitializeComponent();
            lItens = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item();
        }

        private void afterGrava()
        {
            if (lItens.Exists(p => p.Vl_unitario.Equals(decimal.Zero)))
            {
                MessageBox.Show("Existe item do pedido com valor zero.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFLanItensNota_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItensPedido.DataSource = lItens;
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void vl_unitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                bsItensPedido.MoveNext();
            else if (e.KeyCode.Equals(Keys.Escape))
                bsItensPedido.MovePrevious();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanItensNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void TFLanItensNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
