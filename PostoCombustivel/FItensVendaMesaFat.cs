using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFItensVendaMesaFat : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Id_venda
        { get; set; }
        public List<CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv> lItens
        {
            get
            {
                if (bsItensVenda.Count > 0)
                    return (bsItensVenda.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).FindAll(p => p.St_faturar);
                else
                    return null;
            }
        }


        public TFItensVendaMesaFat()
        {
            InitializeComponent();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensVenda.Count > 0)
            {
                (bsItensVenda.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).ForEach(p => p.St_faturar = cbTodos.Checked);
                bsItensVenda.ResetBindings(true);
            }
        }

        private void gItensVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv());
            CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensVenda.List as CamadaDados.PostoCombustivel.TList_ItensVendaMesaConv).Sort(lComparer);
            bsItensVenda.ResetBindings(false);
            gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;

        }

        private void gItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensVenda.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).St_faturar =
                    !(bsItensVenda.Current as CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv).St_faturar;
                bsItensVenda.ResetCurrentItem();
            }
        }

        private void TFItensVendaMesaFat_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensVenda);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsItensVenda.DataSource = CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(Id_venda,
                                                                                                   Cd_empresa,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   true,
                                                                                                   null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFItensVendaMesaFat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFItensVendaMesaFat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensVenda);
        }
    }
}
