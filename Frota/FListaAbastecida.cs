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
    public partial class TFListaAbastecida : Form
    {
        public string Cd_empresa
        { get; set; }
        public CamadaDados.Frota.TRegistro_Abastecidas rAbast
        {
            get
            {
                if (bsAbastecidas.Current != null)
                    return bsAbastecidas.Current as CamadaDados.Frota.TRegistro_Abastecidas;
                else
                    return null;
            }
        }

        public TFListaAbastecida()
        {
            InitializeComponent();
        }

        private void TFListaAbastecida_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar abastecidas
            bsAbastecidas.DataSource = new CamadaDados.Frota.TCD_Abastecidas().Select(
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
                                                vNM_Campo = "a.id_abastecimento",
                                                vOperador = "is",
                                                vVL_Busca = "null"
                                            }
                                        }, 0, string.Empty);
        }

        private void TFListaAbastecida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gAbastecidas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAbastecidas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAbastecidas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_Abastecidas());
            CamadaDados.Frota.TList_Abastecidas lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAbastecidas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAbastecidas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_Abastecidas(lP.Find(gAbastecidas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAbastecidas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_Abastecidas(lP.Find(gAbastecidas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAbastecidas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAbastecidas.List as CamadaDados.Frota.TList_Abastecidas).Sort(lComparer);
            bsAbastecidas.ResetBindings(false);
            gAbastecidas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gAbastecidas_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
