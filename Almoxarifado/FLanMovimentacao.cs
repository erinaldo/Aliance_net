using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Almoxarifado
{
    public partial class TFLanMovimentacao : Form
    {
        public TFLanMovimentacao()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFMovAvulso fMov = new TFMovAvulso())
            {
                if(fMov.ShowDialog() == DialogResult.OK)
                    if(fMov.rMov != null)
                        try
                        {
                            CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(fMov.rMov, null);
                            MessageBox.Show("Movimentação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if(bsMovimentacao.Current != null)
                if (MessageBox.Show("Confirma cancelamento movimento almoxarifado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Almoxarifado.TCN_Movimentacao.Cancelar(bsMovimentacao.Current as CamadaDados.Almoxarifado.TRegistro_Movimentacao, null);
                        MessageBox.Show("Movimento cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpSintetico))
            {
                bsSaldoAlmox.DataSource = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Buscar(cd_empresa.Text,
                                                                                                  id_almox.Text,
                                                                                                  cd_produto.Text,
                                                                                                  false,
                                                                                                  null);
                //Buscar Requisições com requisição interna
                bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Requisicao.Buscar(string.Empty,
                                                                                            cd_empresa.Text,
                                                                                            cd_produto.Text,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            false,
                                                                                            false,
                                                                                            false,
                                                                                            "'I'",
                                                                                            true,
                                                                                            null);
            }
            else
            {
                string tp_mov = string.Empty;
                string virg = string.Empty;
                if (st_entrada.Checked)
                {
                    tp_mov = "'E'";
                    virg = ",";
                }
                if (st_saida.Checked)
                    tp_mov += virg + "'S'";
                string status = string.Empty;
                virg = string.Empty;
                if (st_ativo.Checked)
                {
                    status = "'A'";
                    virg = ",";
                }
                if (st_cancelado.Checked)
                    status += virg + "'C'";
                bsMovimentacao.DataSource = CamadaNegocio.Almoxarifado.TCN_Movimentacao.Buscar(id_movimentacao.Text,
                                                                                               cd_empresa.Text,
                                                                                               string.Empty,
                                                                                               id_almox.Text,
                                                                                               cd_produto.Text,
                                                                                               DT_Inicial.Text,
                                                                                               DT_Final.Text,
                                                                                               tp_mov,
                                                                                               status,
                                                                                               null);
            }
        }

        private void AlocarItens()
        {
            using (TFAlocacaoItemAlmox fAloc = new TFAlocacaoItemAlmox())
            {
                fAloc.ShowDialog();
                this.afterBusca();
            }
        }

        private void RetirarItens()
        {
            using (TFMovRequisicao fMov = new TFMovRequisicao())
            {
                fMov.ShowDialog();
                this.afterBusca();
            }
        }

        private void TFLanMovimentacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMovimento);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            BB_Novo.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                           "PERMITIR MOVIMENTACAO AVULSA",
                                                                                           null);
            BB_Excluir.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                              "PERMITIR CANCELAR MOVIMENTACAO",
                                                                                              null) &&
                                                                                              tcCentral.SelectedTab.Equals(tpAnalitico);
            bb_alocar.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                             "PERMITIR ALOCACAO ITENS ALMOXARIFADO",
                                                                                             null);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_consumointerno, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_consumointerno, 'N')|=|'S'");
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

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            BB_Excluir.Visible = tcCentral.SelectedTab.Equals(tpAnalitico) &&
                                 CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin,
                                                                                              "PERMITIR CANCELAR MOVIMENTACAO",
                                                                                              null);
        }

        private void bb_alocar_Click(object sender, EventArgs e)
        {
            this.AlocarItens();
        }

        private void gSaldo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gSaldo.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsSaldoAlmox.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_SaldoAlmoxarifado());
            CamadaDados.Almoxarifado.TList_SaldoAlmoxarifado lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gSaldo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gSaldo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_SaldoAlmoxarifado(lP.Find(gSaldo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gSaldo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_SaldoAlmoxarifado(lP.Find(gSaldo.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gSaldo.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsSaldoAlmox.List as CamadaDados.Almoxarifado.TList_SaldoAlmoxarifado).Sort(lComparer);
            bsSaldoAlmox.ResetBindings(false);
            gSaldo.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gMovimento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gMovimento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsMovimentacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Almoxarifado.TRegistro_Movimentacao());
            CamadaDados.Almoxarifado.TList_Movimentacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gMovimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gMovimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Almoxarifado.TList_Movimentacao(lP.Find(gMovimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gMovimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Almoxarifado.TList_Movimentacao(lP.Find(gMovimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gMovimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsMovimentacao.List as CamadaDados.Almoxarifado.TList_Movimentacao).Sort(lComparer);
            bsMovimentacao.ResetBindings(false);
            gMovimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gMovimento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gMovimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gMovimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {

        }

        private void bb_retirar_Click(object sender, EventArgs e)
        {
            this.RetirarItens();
        }

        private void TFLanMovimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9) && bb_alocar.Visible)
                this.AlocarItens();
            else if (e.KeyCode.Equals(Keys.F10))
                this.RetirarItens();
        }

        private void TFLanMovimentacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMovimento);
        }

        private void gRequisicao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gRequisicao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsRequisicao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Compra.Lancamento.TRegistro_Requisicao());
            CamadaDados.Compra.Lancamento.TList_Requisicao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Compra.Lancamento.TList_Requisicao(lP.Find(gRequisicao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gRequisicao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsRequisicao.List as CamadaDados.Compra.Lancamento.TList_Requisicao).Sort(lComparer);
            bsRequisicao.ResetBindings(false);
            gRequisicao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gRequisicao_DoubleClick(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
                using (TFRetRequisicao fRet = new TFRetRequisicao())
                {
                    fRet.Saldo_retirar = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Sd_retirar_almox;
                    fRet.Cd_empresa = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa;
                    fRet.Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto;
                    if (fRet.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(
                                new CamadaDados.Almoxarifado.TRegistro_Movimentacao()
                                {
                                    Cd_empresa = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                    Id_almox = fRet.Id_almox,
                                    Cd_produto = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_produto,
                                    Dt_movimento = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_movimento = "S",
                                    Quantidade = fRet.Qtd_retirar,
                                    St_registro = "A",
                                    Ds_observacao = "RETIRADA PRODUTO PELA REQUISICAO Nº" + (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                    rRequisicao = new CamadaDados.Almoxarifado.TRegistro_Mov_X_Requisicao()
                                    {
                                        Id_requisicao = (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao
                                    }
                                }, null);
                            MessageBox.Show("Movimentação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void gRequisicao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if ((bsRequisicao[e.RowIndex] as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).SaldoAtualAlmox.Equals(decimal.Zero))
                        gRequisicao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gRequisicao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}
