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
    public partial class TFItemCancelar : Form
    {
        public string Id_cupom
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_CupomFiscal_Item rItem
        { get { return (bsItensCupom.DataSource as CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item).Find(p => p.Nr_sequencial_ecf.Value.ToString().Equals(nr_itemecf.Text)); } }

        public TFItemCancelar()
        {
            InitializeComponent();
        }

        private void Confirmar()
        {
            if (bsItensCupom.Count > 0)
                if ((bsItensCupom.DataSource as CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item).Exists(p => p.Nr_sequencial_ecf.Value.ToString().Equals(nr_itemecf.Text)))
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFItemCancelar_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Id_cupom))
                bsItensCupom.DataSource = CamadaNegocio.Faturamento.PDV.TCN_CupomFiscal_Item.Buscar(Id_cupom, Cd_empresa, false, string.Empty, null);
            nr_itemecf.Focus();
        }

        private void TFItemCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.Confirmar();
        }

        private void bb_confirmar_Click(object sender, EventArgs e)
        {
            this.Confirmar();
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensCupom.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.PDV.TRegistro_CupomFiscal_Item());
            CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensCupom.List as CamadaDados.Faturamento.PDV.TList_CupomFiscal_Item).Sort(lComparer);
            bsItensCupom.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFItemCancelar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
