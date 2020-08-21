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
    public partial class TFLanOrdemServico : Form
    {
        public TFLanOrdemServico()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_ordem.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
            cd_vendedor.Clear();
            ds_veiculo.Clear();
            marca_veiculo.Clear();
            modelo.Clear();
            placa.Clear();
            ano.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFOrdemServico fOs = new TFOrdemServico())
            {
                if(fOs.ShowDialog() == DialogResult.OK)
                    if(fOs.rOs != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_OrdemServico.Gravar(fOs.rOs, null);
                            MessageBox.Show("Ordem Serviço gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            cd_empresa.Text = fOs.rOs.Cd_empresa;
                            id_ordem.Text = fOs.rOs.Id_ordemstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).Status.Trim().ToUpper().Equals("FATURADA"))
                {
                    MessageBox.Show("Não é permitido alterar Ordem Serviço FATURADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFOrdemServico fOs = new TFOrdemServico())
                {
                    fOs.rOs = bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico;
                    if(fOs.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_OrdemServico.Gravar(fOs.rOs, null);
                            MessageBox.Show("Ordem Serviço alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_ordem.Text = fOs.rOs.Id_ordemstr;
                            cd_empresa.Text = fOs.rOs.Cd_empresa;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar ordem para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).Status.Trim().ToUpper().Equals("FATURADA"))
                {
                    MessageBox.Show("Não é permitido excluir ordem serviço faturada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma exclusão da ordem serviço selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.TCN_OrdemServico.Excluir(bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico, null);
                        MessageBox.Show("Ordem Serviço excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar ordem serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsOrdemServico.DataSource = CamadaNegocio.PostoCombustivel.TCN_OrdemServico.Buscar(cd_empresa.Text,
                                                                                               id_ordem.Text,
                                                                                               cd_clifor.Text,
                                                                                               cd_vendedor.Text,
                                                                                               ds_veiculo.Text,
                                                                                               marca_veiculo.Text,
                                                                                               placa.Text,
                                                                                               ano.Text,
                                                                                               modelo.Text,
                                                                                               dt_ini.Text,
                                                                                               dt_fin.Text,
                                                                                               st_aberta.Checked,
                                                                                               st_faturada.Checked,
                                                                                               null);
            tot_os.Value = (bsOrdemServico.List as CamadaDados.PostoCombustivel.TList_OrdemServico).Sum(p => p.Vl_ordem);
            tot_desconto.Value = (bsOrdemServico.List as CamadaDados.PostoCombustivel.TList_OrdemServico).Sum(p => p.Vl_desconto);
            tot_comissao.Value = (bsOrdemServico.List as CamadaDados.PostoCombustivel.TList_OrdemServico).Sum(p => p.Vl_comissao);
            bsOrdemServico_PositionChanged(this, new EventArgs());
        }

        private void TFLanOrdemServico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOrdemServico);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsOrdemServico_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemServico.Current != null)
            {
                (bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).lItens =
                    CamadaNegocio.PostoCombustivel.TCN_ItensOrdemServico.Buscar((bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).Cd_empresa,
                                                                                (bsOrdemServico.Current as CamadaDados.PostoCombustivel.TRegistro_OrdemServico).Id_ordemstr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                false,
                                                                                null);
                bsOrdemServico.ResetCurrentItem();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void TFLanOrdemServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void gOrdemServico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADA"))
                        gOrdemServico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gOrdemServico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void gOrdemServico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOrdemServico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrdemServico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_OrdemServico());
            CamadaDados.PostoCombustivel.TList_OrdemServico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_OrdemServico(lP.Find(gOrdemServico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOrdemServico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_OrdemServico(lP.Find(gOrdemServico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOrdemServico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrdemServico.List as CamadaDados.PostoCombustivel.TList_OrdemServico).Sort(lComparer);
            bsOrdemServico.ResetBindings(false);
            gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
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

        private void TFLanOrdemServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOrdemServico);
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADA"))
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
