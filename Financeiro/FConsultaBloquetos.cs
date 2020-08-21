using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Bloqueto;
using FormRelPadrao;

namespace Financeiro
{
    public partial class TFConsultaBloquetos : Form
    {
        public bool Altera_Relatorio = false;

        public TFConsultaBloquetos()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFLan_Bloqueto fBloqueto = new TFLan_Bloqueto())
            {
                if (fBloqueto.ShowDialog() == DialogResult.OK)
                    afterBusca();
            }
        }

        private void afterBusca()
        {
            string st_reg = string.Empty;
            string virg = string.Empty;
            if (CB_Abertas.Checked)
            {
                st_reg += virg + "'A'";
                virg = ",";
            }
            if (CB_Liquidadas.Checked)
            {
                st_reg += virg + "'P'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                st_reg += virg + "'C'";
                virg = ",";
            }
            if (cbDescontado.Checked)
            {
                st_reg += virg + "'D'";
                virg = ",";
            }
            blListaTitulo lista = TCN_Titulo.Buscar(CD_Empresa.Text, 
                                                    decimal.Zero, 
                                                    decimal.Zero, 
                                                    decimal.Zero,
                                                    cd_contager.Text,
                                                    cd_banco.Text,
                                                    string.Empty,
                                                    cd_clifor_sacado.Text,
                                                    NR_Docto.Text,
                                                    VL_Inicial.Value,
                                                    VL_Final.Value,
                                                    rgData.NM_Valor,
                                                    DT_Inicial.Text,
                                                    DT_Final.Text,
                                                    CB_Vencidas.Checked ? "V" : string.Empty,
                                                    CB_AVencer.Checked ? "AV" : string.Empty,
                                                    st_reg,
                                                    string.Empty, 
                                                    string.Empty,
                                                    nosso_numero.Text, 
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    st_protestado.Checked,
                                                    0, 
                                                    null);
            //Totalizar titulo abertos
            if (lista.Count > 0)
            {
                tot_doc_aberto.Value = lista.Where(p => p.St_registro.Trim().ToUpper().Equals("A") || p.St_registro.Trim().ToUpper().Equals("D")).Sum(v => v.Vl_atual);
                //Totalizar titulo compensado
                tot_doc_compensado.Value = lista.Where(p => p.St_registro.Trim().ToUpper().Equals("P")).Sum(v => v.Vl_nominal);
                //Totalizar despesas cobranca
                tot_despcob.Value = lista.Sum(v => v.Vl_despesa_cobranca);
                tot_documento.Value = tot_doc_aberto.Value + tot_doc_compensado.Value;
            }
            dsBloqueto.DataSource = lista;
            dsBloqueto_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Bloqueto ja se encontra CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir um bloqueto compensado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string msg = string.Empty;
                if (new TCD_LoteRemessa().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_cob_loteremessa_x_titulo x " +
                                        "where x.id_lote = a.id_lote " +
                                        "and x.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                        "and x.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.Value.ToString() + " " +
                                        "and x.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.Value.ToString() + " " +
                                        "and x.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.Value.ToString() + " " +
                                        "and isnull(x.ST_LoteRemessa, 'B') <> 'B' " + ") "
                        }
                    }, "1") != null)
                    msg = "Boleto ja enviado para o banco.";
                if (MessageBox.Show((string.IsNullOrEmpty(msg) ? string.Empty : msg + "\r\n") +
                                    "Confirma a exclusão do Bloqueto?\r\n" +
                                    "Obs.: A exclusão do boleto não ira cancelar o financeiro utilizado para gerar o mesmo.\r\n" +
                                    "Para cancelar o financeiro utilize a tela de <CONTAS A PAGAR/RECEBER>.\r\n", 
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_Titulo.Excluir((dsBloqueto.Current as blTitulo), null);
                        MessageBox.Show("Bloqueto excluido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void afterPrint()
        {
            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Bloqueto encontra-se cancelado. Não sera possivel realizar a compensação do mesmo!", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido reimprimir bloqueto COMPENSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Altera_Relatorio)
                {
                    //Chamar tela de impressao para o bloqueto
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                        fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                new blListaTitulo(){dsBloqueto.Current as blTitulo},
                                                                fImp.pSt_imprimir,
                                                                fImp.pSt_visualizar,
                                                                fImp.pSt_enviaremail,
                                                                fImp.pSt_exportPdf,
                                                                fImp.Path_exportPdf,
                                                                fImp.pDestinatarios,
                                                                "BLOQUETO Nº " + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim(),
                                                                fImp.pDs_mensagem,
                                                                false);
                    }
                }
                else
                    TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                        new blListaTitulo(){(dsBloqueto.Current as blTitulo)},
                                                        false,
                                                        false,
                                                        false,
                                                        false,
                                                        string.Empty,
                                                        null,
                                                        string.Empty,
                                                        string.Empty,
                                                        false);

                Altera_Relatorio = false;
            }
        }

        private void printRelGeralBloquetos()
        {
            if (dsBloqueto.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = dsBloqueto;
                    Rel.Nome_Relatorio = "TFRel_GeralBloquetos";
                    Rel.Ident = "TFRel_GeralBloquetos";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO GERAL DE BLOQUETOS";

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
                                           "RELATORIO GERAL DE BLOQUETOS",
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
                                               "RELATORIO GERAL DE BLOQUETOS",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void afterDesconta()
        {
            using (TFDescontarBloqueto fDesconta = new TFDescontarBloqueto())
            {
                fDesconta.ShowDialog();
            }
        }

        private void ProtestarTitulo()
        {
            if (dsBloqueto.Current != null)
            {
                if (!(dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Permitido protestar somente titulo ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as blTitulo).St_protestadobool)
                {
                    MessageBox.Show("Titulo ja se encontra PROTESTADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma protesto do titulo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    InputBox inp = new InputBox("00/00/0000", "Data Protesto.");
                    inp.Text = "Informar Data Protesto Titulo.";
                    DateTime dt_protesto;
                    try
                    {
                        dt_protesto = DateTime.Parse(inp.ShowDialog());
                    }
                    catch { dt_protesto = CamadaDados.UtilData.Data_Servidor(); }
                    try
                    {
                        (dsBloqueto.Current as blTitulo).St_protestado = "S";
                        (dsBloqueto.Current as blTitulo).Dt_protesto = dt_protesto;
                        TCN_Titulo.Gravar(dsBloqueto.Current as blTitulo, null);
                        MessageBox.Show("Titulo Protestado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void AtualizarTitulo()
        {
            if (dsBloqueto.Current != null)
            {
                if (!(dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Permitido atualizar somente titulo ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAtualizaBoleto fAtualiza = new TFAtualizaBoleto())
                {
                    fAtualiza.rBloqueto = dsBloqueto.Current as blTitulo;
                    if(fAtualiza.ShowDialog() == DialogResult.OK)
                        try
                        {
                            (dsBloqueto.Current as blTitulo).Vl_multacalc = fAtualiza.pVl_multacalc;
                            (dsBloqueto.Current as blTitulo).Vl_jurocalc += fAtualiza.pVl_jurocalc;
                            TCN_Titulo.AtualizarBoleto(dsBloqueto.Current as blTitulo, fAtualiza.pDt_atualizada, null);
                            if (MessageBox.Show("Boleto atualizado com sucesso.\r\nDeseja Imprimir Boleto?", "Pergunta", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                (dsBloqueto.Current as blTitulo).Dt_vencimento = fAtualiza.pDt_atualizada;
                                afterPrint();
                            }
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
        
        private void TFConsultaBloquetos_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gBloquetos);
            ShapeGrid.RestoreShape(this, gLiquidacoes);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tlpDetalhes.ColumnStyles[1].Width = 0;
            ShapeGrid.RestoreShape(this, gBloquetos);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_banco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Banco|Nome Banco|250;" +
                              "a.CD_Banco|Cód. Banco|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_banco },
                                    new TCD_CadBanco(), "");
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Banco|=|'" + cd_banco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_banco }, new TCD_CadBanco());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaContaGer(new Componentes.EditDefault[] { cd_contager }, string.Empty);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveContaGer("a.cd_contager|=|'" + cd_contager.Text.Trim() + "'", new Componentes.EditDefault[] { cd_contager });
        }

        private void bb_clifor_sacado_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Clifor|Nome Sacado|250;" +
                              "a.CD_Clifor|Cód. Clifor|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_clifor_sacado },
                                    new TCD_CadClifor(), "");
        }

        private void cd_clifor_sacado_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + cd_clifor_sacado.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor_sacado }, new TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void CB_Abertas_Click(object sender, EventArgs e)
        {
            if (CB_Abertas.Checked)
                cbCancelado.Checked = false;
            cbCancelado.Enabled = !CB_Abertas.Checked;
        }

        private void CB_Liquidadas_Click(object sender, EventArgs e)
        {
            if (CB_Liquidadas.Checked)
            {
                CB_AVencer.Checked = false;
                CB_Vencidas.Checked = false;
                cbCancelado.Checked = false;
            }
            CB_AVencer.Enabled = !CB_Liquidadas.Checked;
            CB_Vencidas.Enabled = !CB_Liquidadas.Checked;
            cbCancelado.Enabled = !CB_Liquidadas.Checked;
        }

        private void CB_Vencidas_Click(object sender, EventArgs e)
        {
            if (CB_Vencidas.Checked)
            {
                CB_AVencer.Checked = false;
                CB_Liquidadas.Checked = false;
                cbCancelado.Checked = false;
                cbDescontado.Checked = false;
            }
            CB_AVencer.Enabled = !CB_Vencidas.Checked;
            CB_Liquidadas.Enabled = !CB_Vencidas.Checked;
            cbCancelado.Enabled = !CB_Vencidas.Checked;
            cbDescontado.Enabled = !CB_Vencidas.Checked;
        }

        private void CB_AVencer_Click(object sender, EventArgs e)
        {
            if (CB_AVencer.Checked)
            {
                CB_Vencidas.Checked = false;
                CB_Liquidadas.Checked = false;
                cbCancelado.Checked = false;
                cbDescontado.Checked = false;
            }
            CB_Vencidas.Enabled = !CB_AVencer.Checked;
            CB_Liquidadas.Enabled = !CB_AVencer.Checked;
            cbCancelado.Enabled = !CB_AVencer.Checked;
            cbDescontado.Enabled = !CB_AVencer.Checked;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();    
        }

        private void bb_transferir_Click(object sender, EventArgs e)
        {
            using (TFLan_Remessa fRemessa = new TFLan_Remessa())
            {
                fRemessa.ShowDialog();
            }
        }

        private void BB_Retorno_Click(object sender, EventArgs e)
        {
            using (TFLan_COB_Retorno fRetorno = new TFLan_COB_Retorno())
            {
                fRetorno.ShowDialog();
            }
        }

        private void gBloquetos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("COMPENSADO"))
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcCentral.SelectedTab.Equals(tpCaixa))
                if (dsBloqueto.Current != null)
                    bsLiquidacoes.DataSource = TCN_LanLiquidacao.Busca((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_empresa,
                                                                        (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Nr_lancto.Value,
                                                                        (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_parcela.Value, 
                                                                        0, 
                                                                        string.Empty, 
                                                                        decimal.Zero, 
                                                                        decimal.Zero, 
                                                                        decimal.Zero, 
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        false, 
                                                                        "A", 
                                                                        0, 
                                                                        string.Empty, 
                                                                        null);
        }

        private void cbCancelado_Click(object sender, EventArgs e)
        {
            if (cbCancelado.Checked)
            {
                CB_Abertas.Checked = false;
                CB_AVencer.Checked = false;
                CB_Vencidas.Checked = false;
                CB_Liquidadas.Checked = false;
                cbDescontado.Checked = false;
            }
            CB_Abertas.Enabled = !cbCancelado.Checked;
            CB_AVencer.Enabled = !cbCancelado.Checked;
            CB_Vencidas.Enabled = !cbCancelado.Checked;
            CB_Liquidadas.Enabled = !cbCancelado.Checked;
            cbDescontado.Enabled = !cbCancelado.Checked;
        }

        private void gBloquetos_DoubleClick(object sender, EventArgs e)
        {
            if (dsBloqueto.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.dsBloqueto.Add(dsBloqueto.Current as blTitulo);
                    fRastrear.TRastrear = TP_Rastrear.tm_bloqueto;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void TFConsultaBloquetos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterDesconta();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F9))
                bb_transferir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F10))
                BB_Retorno_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F11))
                ProtestarTitulo();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar", "Mensagem");
            }
        }

        private void BB_Descontar_Click(object sender, EventArgs e)
        {
            afterDesconta();
        }

        private void cbDescontado_Click(object sender, EventArgs e)
        {
            if (cbDescontado.Checked)
            {
                cbCancelado.Checked = false;
                CB_Vencidas.Checked = false;
                CB_AVencer.Checked = false;
            }
            cbCancelado.Enabled = !cbDescontado.Checked;
            CB_Vencidas.Enabled = !cbDescontado.Checked;
            CB_AVencer.Enabled = !cbDescontado.Checked;
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printRelGeralBloquetos();
        }

        private void TFConsultaBloquetos_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShapeGrid.SaveShape(this, gBloquetos);
        }

        private void TFConsultaBloquetos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gBloquetos);
            ShapeGrid.SaveShape(this, gLiquidacoes);
        }

        private void gBloquetos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBloquetos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (dsBloqueto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new blTitulo());
            blListaTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new blListaTitulo(lP.Find(gBloquetos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBloquetos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new blListaTitulo(lP.Find(gBloquetos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBloquetos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (dsBloqueto.List as blListaTitulo).Sort(lComparer);
            dsBloqueto.ResetBindings(false);
            gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_protestar_Click(object sender, EventArgs e)
        {
            ProtestarTitulo();
        }

        private void bb_atualizar_Click(object sender, EventArgs e)
        {
            AtualizarTitulo();
        }

        private void dsBloqueto_PositionChanged(object sender, EventArgs e)
        {
            if(dsBloqueto.Current != null)
            {
                bsAtVencto.DataSource = TCN_AtVenctoParcela.Busca((dsBloqueto.Current as blTitulo).Cd_empresa,
                                                                  (dsBloqueto.Current as blTitulo).Nr_lancto.Value.ToString(),
                                                                  (dsBloqueto.Current as blTitulo).Cd_parcela.Value.ToString(),
                                                                  string.Empty,
                                                                  null);
                if (bsAtVencto.Count > 0)
                    tlpDetalhes.ColumnStyles[1].Width = 200;
                else tlpDetalhes.ColumnStyles[1].Width = 0;
            }
            else
            {
                bsAtVencto.Clear();
                tlpDetalhes.ColumnStyles[1].Width = 0;
            }
        }

        private void imprimirCarnêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFImpCarne fImp = new TFImpCarne())
                fImp.ShowDialog();
        }
    }
}
