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
    public partial class TFEstornarQuitacaoFatura : Form
    {
        public string Id_fatura
        { get; set; }
        public CamadaDados.Financeiro.Cartao.TList_Quitarfatura lQuitar
        {
            get
            {
                if (bsQuitar.Count > 0)
                {
                    List<CamadaDados.Financeiro.Cartao.TRegistro_Quitarfatura> aux =
                        (bsQuitar.DataSource as CamadaDados.Financeiro.Cartao.TList_Quitarfatura).FindAll(p => p.St_estornar);
                    if (aux.Count > 0)
                    {
                        CamadaDados.Financeiro.Cartao.TList_Quitarfatura retorno = new CamadaDados.Financeiro.Cartao.TList_Quitarfatura();
                        aux.ForEach(p => retorno.Add(p));
                        return retorno;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public TFEstornarQuitacaoFatura()
        {
            InitializeComponent();
        }

        private void TFEstornarQuitacaoFatura_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFEstornarQuitacaoFatura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bsQuitar_PositionChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMarcar_Click(object sender, EventArgs e)
        {
            if (bsQuitar.Count > 0)
            {
                (bsQuitar.DataSource as CamadaDados.Financeiro.Cartao.TList_Quitarfatura).ForEach(p => p.St_estornar = cbMarcar.Checked);
                bsQuitar.ResetBindings(true);
            }
        }

        private void dataGridDefault1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsQuitar.Current as CamadaDados.Financeiro.Cartao.TRegistro_Quitarfatura).St_estornar =
                    !(bsQuitar.Current as CamadaDados.Financeiro.Cartao.TRegistro_Quitarfatura).St_estornar;
                bsQuitar.ResetCurrentItem();
            }
        }

        private void gridCaixa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridCaixa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCaixa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa());
            CamadaDados.Financeiro.Caixa.TList_LanCaixa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gridCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gridCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Caixa.TList_LanCaixa(lP.Find(gridCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gridCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Caixa.TList_LanCaixa(lP.Find(gridCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gridCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Sort(lComparer);
            bsCaixa.ResetBindings(false);
            gridCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gQuitar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gQuitar.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsQuitar.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cartao.TRegistro_Quitarfatura());
            CamadaDados.Financeiro.Cartao.TList_Quitarfatura lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gQuitar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gQuitar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_Quitarfatura(lP.Find(gQuitar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gQuitar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_Quitarfatura(lP.Find(gQuitar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gQuitar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsQuitar.List as CamadaDados.Financeiro.Cartao.TList_Quitarfatura).Sort(lComparer);
            bsQuitar.ResetBindings(false);
            gQuitar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
