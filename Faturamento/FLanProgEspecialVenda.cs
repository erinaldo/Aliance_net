using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFLanProgEspecialVenda : Form
    {
        public TFLanProgEspecialVenda()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFProgEspecialVenda fProg = new TFProgEspecialVenda())
            {
                if(fProg.ShowDialog() == DialogResult.OK)
                    if(fProg.rProg != null)
                        try
                        {
                            CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.Gravar(fProg.rProg, fProg.lGrupo, null);
                            MessageBox.Show("Programação Especial de Venda gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cd_empresa.Text = fProg.rProg.Cd_empresa;
                            id_categoriaclifor.Text = fProg.rProg.Id_categoriacliforstr;
                            cd_grupo.Text = fProg.lGrupo?.Count > 0 ? string.Empty : fProg.rProg.Cd_grupo;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterAltera()
        {
            if(bsProgEspecialVenda.Current != null)
                using (TFProgEspecialVenda fProg = new TFProgEspecialVenda())
                {
                    fProg.rProg = bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda;
                    if(fProg.ShowDialog() == DialogResult.OK)
                        if(fProg.rProg != null)
                            try
                            {
                                CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.Gravar(fProg.rProg, null, null);
                                MessageBox.Show("Programação alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_empresa.Text = fProg.rProg.Cd_empresa;
                                id_categoriaclifor.Text = fProg.rProg.Id_categoriacliforstr;
                                cd_grupo.Text = fProg.rProg.Cd_grupo;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsProgEspecialVenda.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.Excluir(
                            bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda, null);
                        MessageBox.Show("Programação excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsProgEspecialVenda.DataSource = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.Buscar(cd_empresa.Text,
                                                                                                                      id_categoriaclifor.Text,
                                                                                                                      cd_grupo.Text,
                                                                                                                      cd_clifor.Text,
                                                                                                                      cd_produto.Text,
                                                                                                                      cd_tabpreco.Text,
                                                                                                                      null);
        }

        private void DuplicatarProg()
        {
            if (bsProgEspecialVenda.Current != null)
                using (TFProgEspecialVenda fProg = new TFProgEspecialVenda())
                {
                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = new CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda();
                    rProg.Cd_clifor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Cd_clifor;
                    rProg.Cd_empresa = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Cd_empresa;
                    rProg.Cd_grupo = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Cd_grupo;
                    rProg.Cd_produto = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Cd_produto;
                    rProg.Cd_tabelapreco = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Cd_tabelapreco;
                    rProg.Ds_categoriaclifor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Ds_categoriaclifor;
                    rProg.Ds_grupo = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Ds_grupo;
                    rProg.Ds_produto = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Ds_produto;
                    rProg.Ds_tabelapreco = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Ds_tabelapreco;
                    rProg.Id_categoriaclifor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Id_categoriaclifor;
                    rProg.Nm_clifor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Nm_clifor;
                    rProg.Nm_empresa = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Nm_empresa;
                    rProg.Tp_acresdesc = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Tp_acresdesc;
                    rProg.Tp_preco = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Tp_preco;
                    rProg.Tp_valor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Tp_valor;
                    rProg.Valor = (bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda).Valor;
                    fProg.rProg = rProg;
                    if(fProg.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.Gravar(fProg.rProg, null, null);
                            MessageBox.Show("Programação especial venda gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar programação especial venda para duplicar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanProgEspecialVenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gProgEspecialVenda);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "Ds_CategoriaCliFor|Categoria Cliente|200;" +
                              "Id_CategoriaCliFor|Id. Categoria|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_categoriaclifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void id_categoriaclifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_categoriaclifor|=|" + id_categoriaclifor.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_categoriaclifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), "a.tp_grupo|=|'A'");
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';" +
                            "a.tp_grupo|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFLanProgEspecialVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                DuplicatarProg();
        }

        private void gProgEspecialVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProgEspecialVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProgEspecialVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda());
            CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProgEspecialVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProgEspecialVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda(lP.Find(gProgEspecialVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProgEspecialVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda(lP.Find(gProgEspecialVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProgEspecialVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProgEspecialVenda.List as CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda).Sort(lComparer);
            bsProgEspecialVenda.ResetBindings(false);
            gProgEspecialVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanProgEspecialVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gProgEspecialVenda);
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabpreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabpreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabpreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabpreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_duplicar_Click(object sender, EventArgs e)
        {
            DuplicatarProg();
        }

        private void gProgEspecialVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADO"))
                        gProgEspecialVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ATIVAR"))
                        gProgEspecialVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gProgEspecialVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; 
                }
        }
    }
}
