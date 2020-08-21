using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.CompraAvulsa;
using CamadaNegocio.Faturamento.CompraAvulsa;

namespace Faturamento
{
    public partial class TFLanCompraAvulsa : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanCompraAvulsa()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_compra.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
            cd_produto.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            NR_compra.Clear();
        }

        private void afterNovo()
        {
            using (TFCompraAvulsa fCompra = new TFCompraAvulsa())
            {
                if(fCompra.ShowDialog() == DialogResult.OK)
                    if(fCompra.rCompra != null)
                        try
                        {
                            TCN_CompraAvulsa.Gravar(fCompra.rCompra, null);
                            MessageBox.Show("Compra gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_compra.Text = fCompra.rCompra.Id_comprastr;
                            cd_empresa.Text = fCompra.rCompra.Cd_empresa;
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
            if (bsCompraAvulsa.Current != null)
            {
                if ((bsCompraAvulsa.Current as TRegistro_CompraAvulsa).St_registro.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido alterar romaneio Faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCompraAvulsa fCompra = new TFCompraAvulsa())
                {
                    fCompra.rCompra = bsCompraAvulsa.Current as TRegistro_CompraAvulsa;
                    if(fCompra.ShowDialog() == DialogResult.OK)
                        if(fCompra.rCompra != null)
                            try
                            {
                                TCN_CompraAvulsa.Gravar(fCompra.rCompra, null);
                                MessageBox.Show("Romaneio Compra alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    LimparFiltros();
                    id_compra.Text = fCompra.rCompra.Id_comprastr;
                    cd_empresa.Text = fCompra.rCompra.Cd_empresa;
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsCompraAvulsa.Current != null)
                if (MessageBox.Show("Confirma exclusão do romaneio selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_CompraAvulsa.Excluir(bsCompraAvulsa.Current as TRegistro_CompraAvulsa, null);
                        MessageBox.Show("Romaneio excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbFaturado.Checked)
                status += virg + "'F'";
            bsCompraAvulsa.DataSource = TCN_CompraAvulsa.Buscar(cd_empresa.Text,
                                                                NR_compra.Text,
                                                                id_compra.Text,
                                                                cd_clifor.Text,
                                                                cd_produto.Text,
                                                                dt_ini.Text,
                                                                dt_fin.Text,
                                                                status,
                                                                null);
            bsCompraAvulsa_PositionChanged(this, new EventArgs());
        }

        private void Print()
        {
            if (bsCompraAvulsa.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsCompraAvulsa;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLan_CompraAvulsa";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                           "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void AlocarItemOS()
        {
            if (bsCompraAvulsa.Current != null)
                using (TFItemCompraXOS fItem = new TFItemCompraXOS())
                {
                    fItem.Cd_empresa = (bsCompraAvulsa.Current as TRegistro_CompraAvulsa).Cd_empresa;
                    fItem.Id_compra = (bsCompraAvulsa.Current as TRegistro_CompraAvulsa).Id_comprastr;
                    fItem.ShowDialog();
                    LimparFiltros();
                    id_compra.Text = fItem.Id_compra;
                    cd_empresa.Text = fItem.Cd_empresa;
                    afterBusca();
                }
            else
                MessageBox.Show("Obrigatorio selecionar romaneio de compra para realizar alocação do item a OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FaturarRomaneio()
        {
            using (TFFaturarRomaneioCompra fFat = new TFFaturarRomaneioCompra())
            {
                if (fFat.ShowDialog() == DialogResult.OK)
                    if (fFat.lCompra != null)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        try
                        {
                            rPed = Proc_Commoditties.TProcessarRomaneioCompra.ProcessarPedido(fFat.lCompra,
                                                                                              fFat.Cd_empresa,
                                                                                              fFat.Cd_clifor);
                            //Gravar Pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            try
                            {
                                //Buscar pedido
                                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                                //Gerar Nota Fiscal
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                                //Gravar Nota Fiscal
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                MessageBox.Show("Nota Fiscal gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Gravar preço automaticamente
                                CamadaNegocio.Estoque.Cadastros.TCN_AtualizaPrecoPerc.AtualizarPreco(rFat.ItensNota, null);
                            }
                            catch
                            {
                                throw new Exception("Pedido compra gravado com sucesso.\r\n" +
                                                    "Erro gravar nota fiscal.\r\n" +
                                                    "Localize o pedido de compra Nº" + rPed.Nr_pedido.ToString() + " e fature novamente.");
                            }
                            
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
        }

        private void TFLanCompraAvulsa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCompraAvulsa);
            Utils.ShapeGrid.RestoreShape(this, gItensCompra);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void gCompraAvulsa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCompraAvulsa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCompraAvulsa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CompraAvulsa());
            TList_CompraAvulsa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCompraAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCompraAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CompraAvulsa(lP.Find(gCompraAvulsa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCompraAvulsa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CompraAvulsa(lP.Find(gCompraAvulsa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCompraAvulsa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCompraAvulsa.List as TList_CompraAvulsa).Sort(lComparer);
            bsCompraAvulsa.ResetBindings(false);
            gCompraAvulsa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'", new Componentes.EditDefault[] { cd_clifor },
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

        private void bsCompraAvulsa_PositionChanged(object sender, EventArgs e)
        {
            if (bsCompraAvulsa.Current != null)
            {
                (bsCompraAvulsa.Current as TRegistro_CompraAvulsa).lItens =
                    TCN_Compra_Itens.Buscar((bsCompraAvulsa.Current as TRegistro_CompraAvulsa).Cd_empresa,
                                            (bsCompraAvulsa.Current as TRegistro_CompraAvulsa).Id_comprastr,
                                            null);
                bsCompraAvulsa.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_os_Click(object sender, EventArgs e)
        {
            AlocarItemOS();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            FaturarRomaneio();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLanCompraAvulsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                Print();
            else if (e.KeyCode.Equals(Keys.F9))
                AlocarItemOS();
            else if (e.KeyCode.Equals(Keys.F10))
                FaturarRomaneio();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void gCompraAvulsa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADO"))
                        gCompraAvulsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gCompraAvulsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void TFLanCompraAvulsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCompraAvulsa);
            Utils.ShapeGrid.SaveShape(this, gItensCompra);
        }
    }
}
