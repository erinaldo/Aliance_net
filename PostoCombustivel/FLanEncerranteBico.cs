using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.PostoCombustivel;
using CamadaNegocio.PostoCombustivel;

namespace PostoCombustivel
{
    public partial class TFLanEncerranteBico : Form
    {
        public TFLanEncerranteBico()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_bico.Clear();
            id_encerrante.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            st_abertura.Checked = false;
            st_fechamento.Checked = false;
            st_intervencao.Checked = false;
        }

        private void afterNovo()
        {
            using (TFEncerranteBico fEnc = new TFEncerranteBico())
            {
                if(fEnc.ShowDialog() == DialogResult.OK)
                    if(fEnc.rEncerrante != null)
                        try
                        {
                            TCN_EncerranteBico.Gravar(fEnc.rEncerrante, null);
                            MessageBox.Show("Encerrante gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_encerrante.Text = fEnc.rEncerrante.Id_encerrantestr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsEncerrante.Current != null)
                using (TFEncerranteBico fEnc = new TFEncerranteBico())
                {
                    fEnc.rEncerrante = bsEncerrante.Current as TRegistro_EncerranteBico;
                    if(fEnc.ShowDialog() == DialogResult.OK)
                        if(fEnc.rEncerrante != null)
                            try
                            {
                                TCN_EncerranteBico.Gravar(fEnc.rEncerrante, null);
                                MessageBox.Show("Encerrante alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_encerrante.Text = fEnc.rEncerrante.Id_encerrantestr;
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsEncerrante.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_EncerranteBico.Excluir(bsEncerrante.Current as TRegistro_EncerranteBico, null);
                        MessageBox.Show("Encerrante excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch
                        (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string tp_encerrante = string.Empty;
            string virg = string.Empty;
            if (st_abertura.Checked)
            {
                tp_encerrante = "'A'";
                virg = ",";
            }
            if (st_fechamento.Checked)
            {
                tp_encerrante += virg + "'F'";
                virg = ",";
            }
            if (st_intervencao.Checked)
                tp_encerrante += virg + "'I'";
            bsEncerrante.DataSource = TCN_EncerranteBico.Buscar(id_encerrante.Text,
                                                                id_bico.Text,
                                                                cd_combustivel.Text,
                                                                tp_encerrante,
                                                                dt_ini.Text,
                                                                dt_fin.Text,
                                                                null);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanEncerranteBico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEncerrante);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_bico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|Id. Bico|60;" +
                              "a.ds_label|Label Bico|80;" +
                              "a.enderecofisicobico|Endereço Bico|80;" +
                              "c.ds_produto|Combustivel|200;" +
                              "d.nm_empresa|Empresa|200";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(), "isnull(f.st_lubrificante, 'N')|<>|'S'");
        }

        private void id_bico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|=|" + id_bico.Text + ";isnull(f.st_lubrificante, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFLanEncerranteBico_KeyDown(object sender, KeyEventArgs e)
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

        private void gEncerrante_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEncerrante.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEncerrante.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_EncerranteBico());
            TList_EncerranteBico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEncerrante.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEncerrante.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_EncerranteBico(lP.Find(gEncerrante.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEncerrante.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_EncerranteBico(lP.Find(gEncerrante.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEncerrante.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEncerrante.List as TList_EncerranteBico).Sort(lComparer);
            bsEncerrante.ResetBindings(false);
            gEncerrante.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanEncerranteBico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEncerrante);
        }

        private void bb_combustivel_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_combustivel }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_combustivel_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_combustivel.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_combustivel },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
