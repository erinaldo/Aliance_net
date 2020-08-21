using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFListaCombustivel : Form
    {
        public bool St_produtounicio { get; set; } = false;
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto> lCombustivel
        {
            get
            {
                if (bsProduto.Count > 0)
                    return (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFListaCombustivel()
        {
            InitializeComponent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFListaCombustivel_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar combustivel
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdc_tanque x " +
                                                        "where x.cd_produto = a.cd_produto)"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
            cbTodos.Visible = !St_produtounicio;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFListaCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void gProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(St_produtounicio && !(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar)
                {
                    (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).ForEach(p => p.St_processar = false);
                    bsProduto.ResetBindings(true);
                }
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar =
                    !(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar;
                bsProduto.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsProduto.Count > 0)
            {
                (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).ForEach(p => p.St_processar = cbTodos.Checked);
                bsProduto.ResetBindings(true);
            }
        }

        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProduto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto());
            CamadaDados.Estoque.Cadastros.TList_CadProduto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).Sort(lComparer);
            bsProduto.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
