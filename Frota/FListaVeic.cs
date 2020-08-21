using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFListaVeic : Form
    {
        public List<CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo> lVeic
        {
            get
            {
                if (bsVeiculo.Count > 0)
                    return (bsVeiculo.List as CamadaDados.Frota.Cadastros.TList_CadVeiculo).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFListaVeic()
        {
            InitializeComponent();
        }

        private void TFListaVeic_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsVeiculo.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Buscar(string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "'A'",
                                                                                       null);
        }

        private void gVeiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).St_processar =
                    !(bsVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo).St_processar;
                bsVeiculo.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsVeiculo.Count > 0)
            {
                (bsVeiculo.List as CamadaDados.Frota.Cadastros.TList_CadVeiculo).ForEach(p => p.St_processar = cbTodos.Checked);
                bsVeiculo.ResetBindings(true);
            }
        }

        private void gVeiculo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gVeiculo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVeiculo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_CadVeiculo());
            CamadaDados.Frota.Cadastros.TList_CadVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_CadVeiculo(lP.Find(gVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_CadVeiculo(lP.Find(gVeiculo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gVeiculo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVeiculo.List as CamadaDados.Frota.Cadastros.TList_CadVeiculo).Sort(lComparer);
            bsVeiculo.ResetBindings(false);
            gVeiculo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaVeic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
