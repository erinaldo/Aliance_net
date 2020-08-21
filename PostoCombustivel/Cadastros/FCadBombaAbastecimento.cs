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
    public partial class TFCadBombaAbastecimento : Form
    {
        public TFCadBombaAbastecimento()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_bomba.Clear();
            ds_bomba.Clear();
            cd_fabricante.Clear();
        }

        private void afterNovo()
        {
            using (TFCadBomba fBomba = new TFCadBomba())
            {
                if(fBomba.ShowDialog() == DialogResult.OK)
                    if(fBomba.rBomba != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.Cadastros.TCN_BombaAbastecimento.Gravar(fBomba.rBomba, null);
                            MessageBox.Show("Bomba combustivel gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_bomba.Text = fBomba.rBomba.Id_bombastr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsBomba.Current != null)
                using (TFCadBomba fBomba = new TFCadBomba())
                {
                    fBomba.rBomba = bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento;
                    if (fBomba.ShowDialog() == DialogResult.OK)
                    {
                        if (fBomba.rBomba != null)
                            try
                            {
                                CamadaNegocio.PostoCombustivel.Cadastros.TCN_BombaAbastecimento.Gravar(fBomba.rBomba, null);
                                this.LimparFiltros();
                                id_bomba.Text = fBomba.rBomba.Id_bombastr;
                                this.afterBusca();
                                MessageBox.Show("Bomba alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        this.LimparFiltros();
                        id_bomba.Text = fBomba.rBomba.Id_bombastr;
                        this.afterBusca();
                    }
                }
        }

        private void afterExclui()
        {
            if(bsBomba.Current != null)
                if (MessageBox.Show("Confirma exclusão da bomba selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.PostoCombustivel.Cadastros.TCN_BombaAbastecimento.Excluir(
                            bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento, null);
                        MessageBox.Show("Bomba combustivel excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsBomba.DataSource = CamadaNegocio.PostoCombustivel.Cadastros.TCN_BombaAbastecimento.Buscar(id_bomba.Text,
                                                                                                        cd_emp.Text,
                                                                                                        cd_fabricante.Text,
                                                                                                        ds_bomba.Text,
                                                                                                        cd_produto.Text,
                                                                                                        null);
            bsBomba_PositionChanged(this, new EventArgs());
        }

        private void TFCadBombaAbastecimento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bsBomba_PositionChanged(object sender, EventArgs e)
        {
            if (bsBomba.Current != null)
            {
                //Buscar bico bomba
                (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lBico =
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_BicoBomba.Buscar(string.Empty,
                                                                                  (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).Id_bombastr,
                                                                                  (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                //Buscar lacre
                (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).lLacre =
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_LacreBomba.Buscar(string.Empty,
                                                                                   (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).Id_bombastr,
                                                                                   (bsBomba.Current as CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento).Cd_empresa,
                                                                                   null);
                bsBomba.ResetCurrentItem();
                bsBico.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
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

        private void TFCadBombaAbastecimento_KeyDown(object sender, KeyEventArgs e)
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

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_emp }, string.Empty);
        }

        private void cd_emp_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_emp.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_emp });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + ";isnull(e.st_combustivel, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gBomba_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBomba.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBomba.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_BombaAbastecimento());
            CamadaDados.PostoCombustivel.Cadastros.TList_BombaAbastecimento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBomba.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBomba.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BombaAbastecimento(lP.Find(gBomba.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBomba.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BombaAbastecimento(lP.Find(gBomba.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBomba.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBomba.List as CamadaDados.PostoCombustivel.Cadastros.TList_BombaAbastecimento).Sort(lComparer);
            bsBomba.ResetBindings(false);
            gBomba.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsBico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_BicoBomba());
            CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba(lP.Find(gBico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsBico.List as CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba).Sort(lComparer);
            bsBico.ResetBindings(false);
            gBico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gLacre_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLacre.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLacre.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.Cadastros.TRegistro_LacreBomba());
            CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba(lP.Find(gLacre.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLacre.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba(lP.Find(gLacre.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLacre.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLacre.List as CamadaDados.PostoCombustivel.Cadastros.TList_LacreBomba).Sort(lComparer);
            bsLacre.ResetBindings(false);
            gLacre.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gBico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gBico.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
