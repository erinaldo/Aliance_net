using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Bloqueto;
using System.ComponentModel;

namespace Financeiro
{
    public partial class TFDescontarBloqueto : Form
    {
        private bool Altera_Relatorio = false;

        public TFDescontarBloqueto()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFLoteBoletoDescontar fLote = new TFLoteBoletoDescontar())
            {
                if(fLote.ShowDialog() == DialogResult.OK)
                    if(fLote.rLote != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Bloqueto.TCN_LoteBloqueto.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        
        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if(cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbProcessado.Checked)
                status += virg + "'P'";
            bsLote.DataSource = CamadaNegocio.Financeiro.Bloqueto.TCN_LoteBloqueto.Buscar(id_lote.Text,
                                                                                          ds_lotebusca.Text,
                                                                                          cd_empresa.Text,
                                                                                          cbConfig.SelectedValue == null ? string.Empty : cbConfig.SelectedValue.ToString(),
                                                                                          DT_Inicial.Text,
                                                                                          DT_Final.Text,
                                                                                          status,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);            
            bsLote_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsLote.Current != null)
                if ((bsLote.Current as TRegistro_LoteBloqueto).St_registro.Trim().ToUpper().Equals("A"))
                {
                    if (MessageBox.Show("Confirma exclusão do registro?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Bloqueto.TCN_LoteBloqueto.Excluir(bsLote.Current as TRegistro_LoteBloqueto, null);
                            afterBusca();
                            MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro excluir lote: " + ex.Message);
                        }
                    }
                }
                else
                        MessageBox.Show("Não é permitido excluir lote processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterPrint()
        {
            if (bsLote.Count > 0)
            {
                (bsLote.DataSource as TList_LoteBloqueto).ForEach(p => p.ListaBloqueto = CamadaNegocio.Financeiro.Bloqueto.TCN_Lote_X_Titulo.BuscarBloquetos(p.Id_lote, 0, string.Empty, null));
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsLote;
                    Rel.Nome_Relatorio = "TFDescontarBloqueto";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "TFRel_LoteBloqueto";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LOTE BLOQUETO DESCONTAR";

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
                                           "RELATORIO LOTE BLOQUETO DESCONTAR",
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
                                               "RELATORIO LOTE BLOQUETO DESCONTAR",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void ProcessarLote()
        {
            if (bsLote.Current != null)
                if ((bsLote.Current as TRegistro_LoteBloqueto).St_registro.Trim().ToUpper().Equals("A"))
                {
                    using (TFProcessarLoteBloqueto fProcessar = new TFProcessarLoteBloqueto())
                    {
                        fProcessar.Vl_totalbloqueto = (bsLote.Current as TRegistro_LoteBloqueto).ListaBloqueto.Sum(p => p.Vl_atual);
                        fProcessar.Id_lote = (bsLote.Current as TRegistro_LoteBloqueto).Id_lotestr;
                        fProcessar.Ds_lote = (bsLote.Current as TRegistro_LoteBloqueto).Ds_lote;
                        if (fProcessar.ShowDialog() == DialogResult.OK)
                        {
                            (bsLote.Current as TRegistro_LoteBloqueto).Dt_processamento = fProcessar.Dt_processamento;
                            (bsLote.Current as TRegistro_LoteBloqueto).Vl_taxa = fProcessar.Vl_taxa;
                            try
                            {
                                CamadaNegocio.Financeiro.Bloqueto.TCN_LoteBloqueto.ProcessarLote(bsLote.Current as TRegistro_LoteBloqueto, null);
                                MessageBox.Show("Lote processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro processar lote: " + ex.Message);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Lote ja se encontra processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstornarLote()
        {
            if (bsLote.Current != null)
            {
                if (MessageBox.Show("Confirma estorno do processamento do lote?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    if ((bsLote.Current as TRegistro_LoteBloqueto).ListaCaixa.Count < 1)
                        (bsLote.Current as TRegistro_LoteBloqueto).ListaCaixa =
                            CamadaNegocio.Financeiro.Bloqueto.TCN_Bloqueto_X_Caixa.BuscarCaixa((bsLote.Current as TRegistro_LoteBloqueto).Id_lote.Value,
                            0, string.Empty, null);
                    try
                    {
                        CamadaNegocio.Financeiro.Bloqueto.TCN_LoteBloqueto.EstornarLote((bsLote.Current as TRegistro_LoteBloqueto), null);
                        MessageBox.Show("Lote estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro estornar lote: " + ex.Message);
                    }
                }
            }
        }

        private void localizarBloquetos()
        {
            if (bsLote.Current != null)
            {
                if ((bsLote.Current as TRegistro_LoteBloqueto).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido incluir bloquetos em lote PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLocalizarBloquetos fLocalizar = new TFLocalizarBloquetos())
                {
                    fLocalizar.pCd_empresa = (bsLote.Current as TRegistro_LoteBloqueto).Cd_empresa;
                    fLocalizar.pNm_empresa = (bsLote.Current as TRegistro_LoteBloqueto).Nm_empresa;
                    fLocalizar.pId_Config = (bsLote.Current as TRegistro_LoteBloqueto).Id_configstr;
                    fLocalizar.pDs_config = (bsLote.Current as TRegistro_LoteBloqueto).Ds_config;
                    if (fLocalizar.ShowDialog() == DialogResult.OK)
                    {
                        TList_Lote_X_Titulo lTitulo = new TList_Lote_X_Titulo();
                        foreach (var v in fLocalizar.lBloquetos)
                        {
                            if ((bsLote.Current as TRegistro_LoteBloqueto).ListaBloqueto.Exists(p => p.Cd_empresa.Trim().Equals(v.Cd_empresa)
                                                                                                    && p.Nr_lancto.Equals(v.Nr_lancto)
                                                                                                    && p.Cd_parcela.Equals(v.Cd_parcela)
                                                                                                    && p.Id_cobranca.Equals(v.Id_cobranca)))
                                continue;
                            lTitulo.Add(new TRegistro_Lote_X_Titulo()
                                {
                                    Cd_empresa = v.Cd_empresa,
                                    Cd_parcela = v.Cd_parcela,
                                    Id_cobranca = v.Id_cobranca,
                                    Id_lote = (bsLote.Current as TRegistro_LoteBloqueto).Id_lote,
                                    Nr_lancto = v.Nr_lancto
                                });
                        }
                        if (lTitulo.Count > 0)
                        {
                            try
                            {
                                CamadaNegocio.Financeiro.Bloqueto.TCN_Lote_X_Titulo.GravarTitulosLote(lTitulo, null);
                                MessageBox.Show("Titulos gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsLote_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe lote para amarrar bloquetos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirBloquetos()
        {
            if (dsBloqueto.Current != null)
            {
                if ((bsLote.Current as TRegistro_LoteBloqueto).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir titulo de lote PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma exclusão do titulo selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Financeiro.Bloqueto.TCN_Lote_X_Titulo.Excluir(new TRegistro_Lote_X_Titulo()
                        {
                            Cd_empresa = (dsBloqueto.Current as blTitulo).Cd_empresa,
                            Cd_parcela = (dsBloqueto.Current as blTitulo).Cd_parcela,
                            Id_cobranca = (dsBloqueto.Current as blTitulo).Id_cobranca,
                            Id_lote = (bsLote.Current as TRegistro_LoteBloqueto).Id_lote,
                            Nr_lancto = (dsBloqueto.Current as blTitulo).Nr_lancto
                        }, null);
                        MessageBox.Show("Titulo excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLote_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ReimprimirBloquetos()
        {
            if (dsBloqueto.Current != null)
            {
                //Chamar tela de impressao para a nota fiscal
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                    fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                            new blListaTitulo(){(dsBloqueto.Current as blTitulo)},
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
        }

        private void TFDescontarBloqueto_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gLote);
            ShapeGrid.RestoreShape(this, gCaixa);
            ShapeGrid.RestoreShape(this, gBloqueto);
            ShapeGrid.RestoreShape(this, gBloquetos);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbConfig.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_cobranca",
                                            vOperador = "=",
                                            vVL_Busca = "'CR'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
            cbConfig.DisplayMember = "ds_config";
            cbConfig.ValueMember = "id_config";
        }

        private void BB_LocalizarTitulo_Click(object sender, EventArgs e)
        {
            localizarBloquetos();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void TFDescontarBloqueto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                ProcessarLote();
            else if (e.KeyCode.Equals(Keys.F10))
                EstornarLote();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gLote_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_ProcessarLote_Click(object sender, EventArgs e)
        {
            ProcessarLote();
        }

        private void bsLote_PositionChanged(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
            {
                (bsLote.Current as TRegistro_LoteBloqueto).ListaBloqueto = CamadaNegocio.Financeiro.Bloqueto.TCN_Lote_X_Titulo.BuscarBloquetos((bsLote.Current as TRegistro_LoteBloqueto).Id_lote, 0, string.Empty, null);
                (bsLote.Current as TRegistro_LoteBloqueto).ListaCaixa =
                                CamadaNegocio.Financeiro.Bloqueto.TCN_Bloqueto_X_Caixa.BuscarCaixa((bsLote.Current as TRegistro_LoteBloqueto).Id_lote.Value, 0, string.Empty, null);
                bsLote.ResetCurrentItem();
                tot_taxa.Text = (bsLote.Current as TRegistro_LoteBloqueto).Vl_taxa.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_titulo.Text = (bsLote.Current as TRegistro_LoteBloqueto).ListaBloqueto.Sum(p => p.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                tot_liquido.Text = ((bsLote.Current as TRegistro_LoteBloqueto).ListaBloqueto.Sum(p => p.Vl_atual) - (bsLote.Current as TRegistro_LoteBloqueto).Vl_taxa).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            }
        }

        private void BB_Estornar_Click(object sender, EventArgs e)
        {
            EstornarLote();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void tsBB_Reimpressao_Click(object sender, EventArgs e)
        {
            ReimprimirBloquetos();
        }

        private void TFDescontarBloqueto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gLote);
            ShapeGrid.SaveShape(this, gCaixa);
            ShapeGrid.SaveShape(this, gBloqueto);
            ShapeGrid.SaveShape(this, gBloquetos);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }
        
        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            localizarBloquetos();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirBloquetos();
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

        private void gLote_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLote.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (dsBloqueto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LoteBloqueto());
            TList_LoteBloqueto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LoteBloqueto(lP.Find(gLote.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLote.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LoteBloqueto(lP.Find(gLote.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLote.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLote.List as TList_LoteBloqueto).Sort(lComparer);
            bsLote.ResetBindings(false);
            gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
