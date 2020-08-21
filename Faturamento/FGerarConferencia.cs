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
    public partial class TFGerarConferencia : Form
    {
        public string Nr_pedido
        { get; set; }

        public List<CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item> lItensPed
        {
            get
            {
                if (BS_Itens.Count > 0)
                    return (BS_Itens.DataSource as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).FindAll(p => p.St_gerarConferencia);
                else
                    return null;
            }
        }

        public TFGerarConferencia()
        {
            InitializeComponent();
            this.Nr_pedido = string.Empty;
        }

        private void TFGerarConferencia_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar itens do pedido disponiveis para gerar conferencia
            BS_Itens.DataSource = CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.BuscarItemConferencia(Nr_pedido, null);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFGerarConferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if (BS_Itens.Current != null)
                    (BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia =
                        !(BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia;
        }

        private void TFGerarConferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
