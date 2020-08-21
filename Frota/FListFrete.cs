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
    public partial class TFListFrete : Form
    {
        public string Cd_empresa
        { get; set; }
        public List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lFreteF
        {
            get
            {
                if (bsCTRC.Count > 0)
                    return (bsCTRC.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFListFrete()
        {
            InitializeComponent();
        }

        private void TFListFrete_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCTRC);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsCTRC.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.status_cte",
                                                vOperador = "=",
                                                vVL_Busca = "'100'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "not exists",
                                                vVL_Busca = "(select 1 from tb_frt_viagem_x_frete x " +
                                                            "where x.nr_lanctoctr = a.nr_lanctoctr " +
                                                            "and x.cd_empresa = a.cd_empresa) "
                                            }
                                        }, 0, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFListFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsCTRC.Count > 0)
            {
                (bsCTRC.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).ForEach(p => p.St_processar = cbTodos.Checked);
                bsCTRC.ResetBindings(true);
            }
        }

        private void gFrete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar =
                    !(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar;
                bsCTRC.ResetCurrentItem();
            }
        }

        private void TFListFrete_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utils.ShapeGrid.SaveShape(this, gCTRC);
        }

        private void gCTRC_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCTRC.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCTRC.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete());
            CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCTRC.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCTRC.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCTRC.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCTRC.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCTRC.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sort(lComparer);
            bsCTRC.ResetBindings(false);
            gCTRC.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_localizar_Click(object sender, EventArgs e)
        {
            DataGridViewRow linha = gCTRC.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pNr_ctrc"].Value.ToString().Contains(nr_cte.Text)).First();
            if (linha != null)
            {
                gCTRC.Rows[linha.Index].Selected = true;
                bsCTRC.Position = linha.Index;
            }
        }
    }
}
