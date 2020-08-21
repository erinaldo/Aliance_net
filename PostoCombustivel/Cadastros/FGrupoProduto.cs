using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel.Cadastros
{
    public partial class TFGrupoProduto : Form
    {
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto> lGrupo
        {
            get
            {
                if (bsGrupoProduto.Count > 0)
                    return (bsGrupoProduto.List as CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFGrupoProduto()
        {
            InitializeComponent();
        }

        private void gGrupoProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).St_processar =
                    !(bsGrupoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto).St_processar;
                bsGrupoProduto.ResetCurrentItem();
            }
        }

        private void TFGrupoProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Grupo Produto
            bsGrupoProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.tp_grupo",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        }, 0, string.Empty);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsGrupoProduto.Count > 0)
            {
                (bsGrupoProduto.List as CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto).ForEach(p => p.St_processar = cbTodos.Checked);
                bsGrupoProduto.ResetBindings(true);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFGrupoProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gGrupoProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gGrupoProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsGrupoProduto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto());
            CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gGrupoProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gGrupoProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto(lP.Find(gGrupoProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gGrupoProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto(lP.Find(gGrupoProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gGrupoProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsGrupoProduto.List as CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto).Sort(lComparer);
            bsGrupoProduto.ResetBindings(false);
            gGrupoProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
