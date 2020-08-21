using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque
{
    public partial class TFConsultaProvisao : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaProvisao()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_provisao.Clear();
            CD_Empresa.Clear();
            cd_produto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            st_provsaldo.Checked = false;
        }

        private void afterNovo()
        {
            using (TFProvisao fProv = new TFProvisao())
            {
                if(fProv.ShowDialog() == DialogResult.OK)
                    if (fProv.rProv != null)
                    {
                        try
                        {
                            CamadaNegocio.Estoque.TCN_Lan_Provisao_Estoque.Gravar(fProv.rProv, null);
                            MessageBox.Show("Provisão estoque gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_provisao.Text = fProv.rProv.Id_provisao.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterBusca()
        {
            bsProvisao.DataSource = CamadaNegocio.Estoque.TCN_Lan_Provisao_Estoque.Buscar(id_provisao.Text,
                                                                                          string.Empty,
                                                                                          CD_Empresa.Text,
                                                                                          cd_produto.Text,
                                                                                          dt_ini.Text,
                                                                                          dt_fin.Text,
                                                                                          st_provsaldo.Checked,
                                                                                          null);
            bsProvisao_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsProvisao.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsProvisao;
                    Rel.Nome_Relatorio = "TFLan_Provisao_Estoque";
                    Rel.NM_Classe = "TFLan_Provisao_Estoque";
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "RELATORIO " + this.Text.Trim(),
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + this.Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe registros para gerar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BaixarProvisao()
        {
            if (bsProvisao.Current != null)
            {
                if ((bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque).Saldo_Provisao > 0)
                {
                    if (MessageBox.Show("Confirma baixa da provisão selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Estoque.TCN_Lan_Provisao_Estoque.Baixar(bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque, null);
                            MessageBox.Show("Baixa realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_provisao.Text = (bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque).Id_provisao.Value.ToString();
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                    MessageBox.Show("Provisão sem saldo para baixar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TFConsultaProvisao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gEstoque);
            Utils.ShapeGrid.RestoreShape(this, gProvisao);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bsProvisao_PositionChanged(object sender, EventArgs e)
        {
            if (bsProvisao.Current != null)
            {
                (bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque).Lan_Estoque =
                    new CamadaDados.Estoque.TCD_LanEstoque().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_prov_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_provisao = " + (bsProvisao.Current as CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque).Id_provisao.Value.ToString() + ")"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                bsProvisao.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFConsultaProvisao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.BaixarProvisao();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void bb_baixar_Click(object sender, EventArgs e)
        {
            this.BaixarProvisao();
        }

        private void gProvisao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 4))
                if (Convert.ToDecimal(e.Value.ToString()).Equals(decimal.Zero))
                    gProvisao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gProvisao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void gProvisao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProvisao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProvisao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_Lan_Provisao_Estoque());
            CamadaDados.Estoque.TList_Lan_Provisao_Estoque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_Lan_Provisao_Estoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_Lan_Provisao_Estoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProvisao.List as CamadaDados.Estoque.TList_Lan_Provisao_Estoque).Sort(lComparer);
            bsProvisao.ResetBindings(false);
            gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gEstoque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gEstoque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsEstoque.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.TRegistro_LanEstoque());
            CamadaDados.Estoque.TList_RegLanEstoque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.TList_RegLanEstoque(lP.Find(gEstoque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gEstoque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.TList_RegLanEstoque(lP.Find(gEstoque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gEstoque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsEstoque.List as CamadaDados.Estoque.TList_RegLanEstoque).Sort(lComparer);
            bsEstoque.ResetBindings(false);
            gEstoque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFConsultaProvisao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gEstoque);
            Utils.ShapeGrid.SaveShape(this, gProvisao);
        }
    }
}
