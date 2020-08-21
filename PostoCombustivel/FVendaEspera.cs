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
    public partial class TFVendaEspera : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Login
        { get; set; }
        public List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda
        {
            get
            {
                if (bsVendaCombustivel.Count > 0)
                    return (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFVendaEspera()
        {
            InitializeComponent();
        }

        private void RetirarVendaEspera()
        {
            if (bsVendaCombustivel.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda =
                    (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar);
                if(lVenda.Count > 0)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.RetirarVendaEspera(lVenda, null);
                        this.afterBusca();
                        tot_faturar.Value = tot_faturar.Minimum;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            bsVendaCombustivel.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                                       Cd_empresa,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       "'E'",
                                                                                                       string.Empty,
                                                                                                       false,
                                                                                                       Login,
                                                                                                       string.Empty,
                                                                                                       "a.dt_abastecimento desc",
                                                                                                       null);
            if (bsVendaCombustivel.Count > 0)
                tot_venda.Value = (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Vl_subtotal);
        }

        private void TFVendaEspera_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gVenda);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsVendaCombustivel.Count > 0)
            {
                (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).ForEach(p => p.St_processar = cbProcessar.Checked);
                tot_faturar.Value = (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
                bsVendaCombustivel.ResetBindings(true);
            }
        }

        private void gVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar =
                    !(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar;
                bsVendaCombustivel.ResetCurrentItem();
                if (bsVendaCombustivel.Count > 0)
                    tot_faturar.Value = (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFVendaEspera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.RetirarVendaEspera();
        }

        private void bb_retirarespera_Click(object sender, EventArgs e)
        {
            this.RetirarVendaEspera();
        }

        private void gVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVendaCombustivel.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel());
            CamadaDados.PostoCombustivel.TList_VendaCombustivel lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_VendaCombustivel(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_VendaCombustivel(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sort(lComparer);
            bsVendaCombustivel.ResetBindings(false);
            gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFVendaEspera_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gVenda);
        }
    }
}
