using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Estoque.Cadastros;

namespace Producao
{
    public partial class TFLanOrdemProducao : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanOrdemProducao()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_ordem.Clear();
            cd_empresa_busca.Clear();
            cd_produto.Clear();
            id_formulacao.Clear();
            DT_Inicial.Clear();
            DT_Final.Clear();
            cbAtrazoIni.Checked = false;
        }

        private void afterNovo()
        {
            using (TFOrdemProducao fOrdem = new TFOrdemProducao())
            {
                fOrdem.Text = "NOVA ORDEM PRODUÇÃO";
                if(fOrdem.ShowDialog() == DialogResult.OK)
                    if (fOrdem.rOrdem != null)
                        try
                        {
                            TCN_OrdemProducao.Gravar(fOrdem.rOrdem, null);
                            MessageBox.Show("Ordem Produção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_ordem.Text = fOrdem.rOrdem.Id_ordem.Value.ToString();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsOrdemProducao.Current != null)
            {
                if (!(bsOrdemProducao.Current as TRegistro_OrdemProducao).Status.Equals("ABERTA"))
                {
                    MessageBox.Show("Apenas é possível alterar ordem de produção com sts. ABERTA.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (TFOrdemProducao fOrdem = new TFOrdemProducao())
                {
                    fOrdem.Text = "ALTERANDO ORDEM PRODUÇÃO Nº " + (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                    fOrdem.rOrdem = bsOrdemProducao.Current as TRegistro_OrdemProducao;
                    if(fOrdem.ShowDialog() == DialogResult.OK)
                        if (fOrdem.rOrdem != null)
                            try
                            {
                                TCN_OrdemProducao.Gravar(fOrdem.rOrdem, null);
                                MessageBox.Show("Ordem Produção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_ordem.Text = fOrdem.rOrdem.Id_ordem.Value.ToString();
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsOrdemProducao.Current != null)
            {
                if(MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_OrdemProducao.Excluir(bsOrdemProducao.Current as TRegistro_OrdemProducao, null);
                        MessageBox.Show("Ordem Produção excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
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
            if (cbAberta.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbProducao.Checked)
                status = "'P'";
            bsOrdemProducao.DataSource = TCN_OrdemProducao.Buscar(id_ordem.Text,
                                                                  cd_empresa_busca.Text,
                                                                  cd_produto.Text,
                                                                  id_formulacao.Text,
                                                                  nr_pedido.Text,
                                                                  status,
                                                                  rbPrevIniProd.Checked ? "PI" :
                                                                  rbPrevFinProd.Checked ? "PF":
                                                                  rbIniProd.Checked ? "IP":
                                                                  rbFinProd.Checked ? "FP": string.Empty,
                                                                  DT_Inicial.Text,
                                                                  DT_Final.Text,
                                                                  st_parcial.Checked,
                                                                  st_produzida.Checked,
                                                                  cbAtrazoIni.Checked,
                                                                  cbAtrazoFin.Checked,
                                                                  null);
            bsOrdemProducao_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsOrdemProducao.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrdemProducao;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Ident = "REL_PRD_OrdemProducao";
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
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
        }

        private void IniciarProducao()
        {
            if (bsOrdemProducao.Current != null)
            {
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).St_registro.Trim().ToUpper() != "A")
                {
                    MessageBox.Show("Permitido INICIAR PRODUÇÃO somente de ordem com status ABERTA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    bool st_serie = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GERAR_SERIE_APONTAMENTO",
                          (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_empresa, null).Equals("S");
                    if (st_serie)
                        using (TFSerieProduto fSerie = new TFSerieProduto())
                        {
                            object obj = new TCD_SerieProduto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                       vNM_Campo = "a.Nr_serie",
                                       vOperador = "<>",
                                       vVL_Busca = "SEM SÉRIE"
                                    }
                                }, "max(nr_serie)");
                            decimal numeroserie = decimal.Zero;
                            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                numeroserie = decimal.Parse(obj.ToString());
                            for (int i = 0; (bsOrdemProducao.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir > i; i++)
                                fSerie.lSerie.Add(new TRegistro_SerieProduto()
                                {
                                    Cd_empresa = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_empresa,
                                    Cd_produto = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_produto,
                                    Ds_produto = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Ds_produto,
                                    Nr_serie = (numeroserie += 1).ToString()
                                });
                            if (fSerie.ShowDialog() == DialogResult.OK)
                            {
                                if (fSerie.lSerie != null)
                                    if (fSerie.lSerie.Count > 0)
                                        (bsOrdemProducao.Current as TRegistro_OrdemProducao).lSerie = fSerie.lSerie;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Nº Série!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    TCN_OrdemProducao.IniciarProducao(bsOrdemProducao.Current as TRegistro_OrdemProducao, null);
                    if (st_serie)
                        TCN_OrdemProducao.GerarExcel(bsOrdemProducao.Current as TRegistro_OrdemProducao);
                    MessageBox.Show("Ordem Produção iniciada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void EstornarIniProd()
        {
            if (bsOrdemProducao.Current != null)
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).Status.Trim().ToUpper().Equals("EM PRODUÇÃO"))
                    try
                    {
                        TCN_OrdemProducao.EstornarIniProducao(bsOrdemProducao.Current as TRegistro_OrdemProducao, null);
                        MessageBox.Show("Inicio produção estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else MessageBox.Show("Permitido estornar somente ordem com status <EM PRODUÇÃO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApontarOrdem()
        {
            if (bsOrdemProducao.Current != null)
            {
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Permitido apontar somente ordem com status <EM PRODUÇÃO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir <= 0)
                {
                    MessageBox.Show("Ordem Produção não tem saldo para apontamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFApontamentoProducao fApontamento = new TFApontamentoProducao())
                {
                    fApontamento.Id_ordem = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                    if (fApontamento.ShowDialog() == DialogResult.OK)
                        if (fApontamento.rApontamento != null)
                            try
                            {
                                TCN_ApontamentoProducao.Gravar2(fApontamento.rApontamento, 
                                                                null);
                                MessageBox.Show("Apontamento Produção gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_ordem.Text = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString();
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void VerificarDisponibilidadeMPrima()
        {
            if (bsOrdemProducao.Current != null)
                if ((bsOrdemProducao.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir > decimal.Zero)
                    using (Proc_Commoditties.TFDisponibilidadeMPrima fDisponibilidade = new Proc_Commoditties.TFDisponibilidadeMPrima())
                    {
                        fDisponibilidade.pCd_empresa = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_empresa;
                        fDisponibilidade.pCd_produto = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_produto;
                        fDisponibilidade.pCd_unidade = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_unidade;
                        fDisponibilidade.pId_formulacao = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_formulacaostr;
                        fDisponibilidade.pDs_formula = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Ds_formula;
                        fDisponibilidade.pId_ordem = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.ToString();
                        fDisponibilidade.pQtd_programada = (bsOrdemProducao.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir;

                        fDisponibilidade.ShowDialog();
                    }
                else
                    MessageBox.Show("Ordem produção não possui saldo para produzir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirRomaneioProducao()
        {
            if (bsOrdemProducao.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new TList_OrdemProducao() { bsOrdemProducao.Current as TRegistro_OrdemProducao };
                    Rel.DTS_Relatorio = bs;
                    //Montar lista de materia prima
                    BindingSource bsMPrima = new BindingSource();
                    bsMPrima.DataSource = TCN_MPrima.MontarListaMPrima((bsOrdemProducao.Current as TRegistro_OrdemProducao).Cd_empresa,
                                                                                                       (bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_formulacaostr,
                                                                                                       (bsOrdemProducao.Current as TRegistro_OrdemProducao).Qtd_saldoproduzir,
                                                                                                       null,
                                                                                                       null);
                    Rel.Adiciona_DataSource("DTS_FICHA", bsMPrima);
                    Rel.Nome_Relatorio = "REL_PRD_ROMANEIOPRODUCAO";
                    Rel.NM_Classe = Name;
                    Rel.Ident = "REL_PRD_ROMANEIOPRODUCAO";
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ROMANEIO DE PRODUÇÃO";

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
                                           "ROMANEIO DE PRODUÇÃO",
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
                                               "ROMANEIO DE PRODUÇÃO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void TFLanOrdemProducao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, gOrdemProducao);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLanOrdemProducao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                IniciarProducao();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                EstornarIniProd();
            else if (e.KeyCode.Equals(Keys.F9))
                VerificarDisponibilidadeMPrima();
            else if (e.KeyCode.Equals(Keys.F10))
                ApontarOrdem();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_disponibilidade_Click(object sender, EventArgs e)
        {
            VerificarDisponibilidadeMPrima();
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa_busca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_busca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa_busca.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_produto },
                                              new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_formula_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_formula|Formula|200;a.id_formulacao|Id. Formula|80",
                                             new Componentes.EditDefault[] { id_formulacao },
                                             new TCD_FormulaApontamento(),
                                             string.Empty);
        }

        private void id_formulacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_formulacao|=|" + id_formulacao.Text,
                                              new Componentes.EditDefault[] { id_formulacao },
                                              new TCD_FormulaApontamento());
        }

        private void bsOrdemProducao_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemProducao.Current != null)
            {
                //Buscar Ficha Ordem
                (bsOrdemProducao.Current as TRegistro_OrdemProducao).lOrdem_MPrima =
                    TCN_Ordem_MPrima.Buscar((bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString(), null);
                //Buscar Apontamento Ordem
                (bsOrdemProducao.Current as TRegistro_OrdemProducao).lApontamento =
                    TCN_OrdemProducao_X_Apontamento.BuscarApontamento((bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString(), null);
                //Buscar Origem Pedido
                (bsOrdemProducao.Current as TRegistro_OrdemProducao).lItem =
                    TCN_OrdemProducao_X_PedItem.BuscarItem((bsOrdemProducao.Current as TRegistro_OrdemProducao).Id_ordem.Value.ToString(), null);
                bsOrdemProducao.ResetCurrentItem();
            }
        }

        private void gOrdemProducao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EM PRODUÇÃO"))
                        gOrdemProducao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                        gOrdemProducao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PRODUZIDA"))
                        gOrdemProducao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gOrdemProducao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_apontar_Click(object sender, EventArgs e)
        {
            ApontarOrdem();
        }

        private void miListaOrdemProducao_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void miRomaneioProducao_Click(object sender, EventArgs e)
        {
            ImprimirRomaneioProducao();
        }

        private void TFLanOrdemProducao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, gOrdemProducao);
        }

        private void st_parcial_CheckedChanged(object sender, EventArgs e)
        {
            if (st_parcial.Checked)
            {
                st_produzida.Checked = false;
                cbProducao.Checked = false;
                cbAberta.Checked = false;
            }
        }

        private void st_produzida_CheckedChanged(object sender, EventArgs e)
        {
            if (st_produzida.Checked)
            {
                st_parcial.Checked = false;
                cbAberta.Checked = false;
                cbProducao.Checked = false;
            }
        }

        private void cbAberta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAberta.Checked)
            {
                st_parcial.Checked = false;
                st_produzida.Checked = false;
                cbProducao.Checked = false;
            }
        }

        private void cbProducao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProducao.Checked)
            {
                st_produzida.Checked = false;
                st_parcial.Checked = false;
                cbAberta.Checked = false;
            }
        }

        private void bbIniProd_Click(object sender, EventArgs e)
        {
            IniciarProducao();
        }

        private void bbEstornarIniProd_Click(object sender, EventArgs e)
        {
            EstornarIniProd();
        }
    }
}
