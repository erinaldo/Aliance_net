using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFFaturarComissao : Form
    {
        public List<CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao> lComissao
        {
            get
            {
                if (bsComissao.Count > 0)
                    return (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFFaturarComissao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Obrigatorio informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_CompVend.Focus();
                return;
            }
            bsComissao.DataSource = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                                      CD_Empresa.Text,
                                                                                                      id_viagem.Text,
                                                                                                      CD_CompVend.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      nr_notafiscal.Text,
                                                                                                      id_cupom.Text,
                                                                                                      string.Empty,
                                                                                                      id_ordem.Text,
                                                                                                      string.Empty,
                                                                                                      nr_pedido.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      nr_cte.Text,
                                                                                                      id_receita.Text,
                                                                                                      id_locacao.Text,
                                                                                                      string.Empty,
                                                                                                      dt_ini.Text,
                                                                                                      dt_fin.Text,
                                                                                                      "C",
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                                      null);
            tot_comissao.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_comissao);
            tot_faturado.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_faturado);
            tot_saldofat.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sum(p => p.Vl_saldofaturar);
        }

        private void TFFaturarComissao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gComissao);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsComissao.Count > 0)
            {
                (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).ForEach(p => p.St_processar = cbProcessar.Checked);
                bsComissao.ResetBindings(true);
                vl_faturar.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Where(p => p.St_processar).Sum(p => p.Vl_saldofaturar);
            }
        }

        private void gComissao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).St_processar =
                    !(bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).St_processar;
                bsComissao.ResetCurrentItem();
                vl_faturar.Value = (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Where(p => p.St_processar).Sum(p => p.Vl_saldofaturar);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFFaturarComissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gComissao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gComissao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsComissao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao());
            CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao(lP.Find(gComissao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gComissao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao(lP.Find(gComissao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gComissao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).Sort(lComparer);
            bsComissao.ResetBindings(false);
            gComissao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFFaturarComissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gComissao);
        }
    }
}
