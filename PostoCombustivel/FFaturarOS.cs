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
    public partial class TFFaturarOS : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico> lItem
        { 
            get 
        {
            if (bsItens.Count > 0)
                return (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).FindAll(p => p.St_processar);
            else
                return new List<CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico>();
            } 
        }

        public string pCd_empresa
        { get; set; }

        public TFFaturarOS()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(id_ordem.Text) &&
                string.IsNullOrEmpty(cd_cliente.Text))
            {
                MessageBox.Show("Obrigatorio informar Nº OS ou CLIENTE para realizar FATURAMENTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bsItens.DataSource = CamadaNegocio.PostoCombustivel.TCN_ItensOrdemServico.Buscar(pCd_empresa,
                                                                                             id_ordem.Text,
                                                                                             string.Empty,
                                                                                             cd_produto.Text,
                                                                                             cd_cliente.Text,
                                                                                             true,
                                                                                             null);
            tot_subtotal.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Sum(p => p.Vl_subtotal);
            tot_desconto.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Sum(p => p.Vl_desconto);
        }

        private void bb_cliente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliente }, string.Empty);
        }

        private void TFFaturarOS_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void cd_cliente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliente.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_cliente },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void st_marcar_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).ForEach(p => p.St_processar = st_marcar.Checked);
                bsItens.ResetBindings(true);
                tot_faturar.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
                tot_descfat.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_desconto);
                tot_fatliquido.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_subtotal - p.Vl_desconto);
            }
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico());
            CamadaDados.PostoCombustivel.TList_ItensOrdemServico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_ItensOrdemServico(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_ItensOrdemServico(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Sort(lComparer);
            bsItens.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).St_processar =
                    !(bsItens.Current as CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico).St_processar;
                bsItens.ResetCurrentItem();
                tot_faturar.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
                tot_descfat.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_desconto);
                tot_fatliquido.Value = (bsItens.List as CamadaDados.PostoCombustivel.TList_ItensOrdemServico).Where(p => p.St_processar).Sum(p => p.Vl_subtotal - p.Vl_desconto);
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

        private void TFFaturarOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFFaturarOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
