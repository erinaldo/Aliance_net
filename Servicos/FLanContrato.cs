using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace Servicos
{
    public partial class TFLanContrato : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanContrato()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            nr_contrato.Clear();
            cd_empresa.Clear();
            cd_contratante.Clear();
            cd_vendedor.Clear();
            DT_Final.Clear();
            DT_Inicial.Clear();
            cbAberta.Checked = false;
            cbEncerrado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFContrato fContrato = new TFContrato())
            {
                if(fContrato.ShowDialog() == DialogResult.OK)
                    if (fContrato.rContrato != null)
                    {
                        try
                        {
                            CamadaNegocio.Servicos.TCN_Contrato.Gravar(fContrato.rContrato, null);
                            MessageBox.Show("Contrato gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            nr_contrato.Text = fContrato.rContrato.Nr_contratostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsContrato.Current != null)
            {
                using (TFContrato fContrato = new TFContrato())
                {
                    fContrato.rContrato = bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato;
                    if(fContrato.ShowDialog() == DialogResult.OK)
                        if (fContrato.rContrato != null)
                            try
                            {
                                CamadaNegocio.Servicos.TCN_Contrato.Gravar(fContrato.rContrato, null);
                                MessageBox.Show("Contrato alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    LimparFiltros();
                    nr_contrato.Text = fContrato.rContrato.Nr_contratostr;
                    afterBusca();
                }
            }
            else
                MessageBox.Show("Não existe contrato disponivel para alterar.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir contrato encerrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do contrato selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Servicos.TCN_Contrato.Excluir(bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato, null);
                        MessageBox.Show("Contrato excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Não existe contrato selecionado para excluir.", "Mensagem",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbEncerrado.Checked)
                status += virg + "'E'";
            bsContrato.DataSource = CamadaNegocio.Servicos.TCN_Contrato.Buscar(nr_contrato.Text,
                                                                               cd_empresa.Text,
                                                                               cd_contratante.Text,
                                                                               cd_vendedor.Text,
                                                                               string.Empty,
                                                                               rbDtInicio.Checked ? "A" : "E",
                                                                               DT_Inicial.Text,
                                                                               DT_Final.Text,
                                                                               cbCarne.Checked,
                                                                               false,
                                                                               status,
                                                                               null);
            tslTotal.Text = (bsContrato.List as CamadaDados.Servicos.TList_Contrato).Sum(p => p.Vl_contrato).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            bsContrato_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsContrato.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name.Trim();
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                Relatorio.DTS_Relatorio = bsContrato;
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "RELATÓRIO CONTRATO SERVIÇO";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO CONTRATO SERVIÇO",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void FaturarLote()
        {
            using (TFProcLoteContrato fProc = new TFProcLoteContrato())
            {
                if(fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lContratos != null)
                    {
                        Utils.ThreadEspera tEspera = new Utils.ThreadEspera("Inicio processamento lote.");
                        string ret = string.Empty;
                        try
                        {
                            ret = CamadaNegocio.Servicos.TCN_Contrato.ProcessarLote(fProc.lContratos, fProc.Dt_referencia, tEspera, null);
                        }
                        finally
                        {
                            tEspera.Fechar();
                            tEspera = null;
                        }
                        MessageBox.Show("Lote processado com sucesso." + (string.IsNullOrEmpty(ret) ? string.Empty : "\r\nOs seguintes contratos não foram processados:\r\n" + ret.Trim()), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lLote = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
                        //Buscar CfgNfe para a empresa
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(fProc.lContratos[0].Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                            if (lCfgNfe.Count.Equals(0))
                                MessageBox.Show("Não existe configuração para envio de NFS-e para a empresa " + fProc.lContratos[0].Cd_empresa.Trim() + ".",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                fProc.lContratos.ForEach(p =>
                                    {
                                        if (p.lNF.Count > 0)
                                            if (p.lNF[0].Cd_modelo.Trim().Equals("55"))
                                                lLote.Add(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(p.lNF[0].Cd_empresa, p.lNF[0].Nr_lanctofiscalstr, null));
                                        if (lLote.Count.Equals(50))
                                        {
                                            NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0], lLote);
                                            MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            lLote.Clear();
                                        }
                                    });
                                if (lLote.Count > 0)
                                {

                                    NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0], lLote);
                                    MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        //Imprimir boletos
                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloq = new CamadaDados.Financeiro.Bloqueto.blListaTitulo();
                        fProc.lContratos.ForEach(p =>
                            {
                                if (p.lNF.Count > 0)
                                    if (p.lNF[0].Duplicata.Count > 0)
                                        CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(p.lNF[0].Cd_empresa,
                                                                                            p.lNF[0].Duplicata[0].Nr_lancto,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            decimal.Zero,
                                                                                            decimal.Zero,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty, 
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            false,
                                                                                            0,
                                                                                            null).ForEach(v => lBloq.Add(v));
                            });
                        if(lBloq.Count > 0)
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                              lBloq,
                                                                              false,
                                                                              true,
                                                                              false,
                                                                              false,
                                                                              string.Empty,
                                                                              null,
                                                                              "BLOQUETO(S) CONTRATO SERVIÇO",
                                                                              string.Empty,
                                                                              false);
                    }
            }
        }

        private void GerarCarne()
        {
            using (TFProcLoteContrato fProc = new TFProcLoteContrato())
            {
                fProc.St_gerarCarne = true;
                if (fProc.ShowDialog() == DialogResult.OK)
                    if (fProc.lContratos != null)
                    {
                        try
                        {
                            CamadaNegocio.Servicos.TCN_Contrato.GerarCarne(fProc.lContratos, fProc.Dt_referencia, null);
                            MessageBox.Show("Lote processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void SuspenderContrato()
        {
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_registro.Trim().ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido suspender contrato ENCERRADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_registro.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Contrato já se encontra SUSPENSO", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFSuspenderContrato fSusp = new TFSuspenderContrato())
                {
                    if (fSusp.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_Contrato.SuspenderContrato(bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato,
                                                                                  fSusp.pDs_motivo,
                                                                                  DateTime.Parse(fSusp.pDt_prevtermsusp),
                                                                                  null);
                            MessageBox.Show("Contrato SUSPENSO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void EncerrarSuspensao()
        {
            if (bsContrato.Current != null)
            {
                if ((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_registro.Trim().ToUpper() != "S")
                {
                    MessageBox.Show("Contrato não se encontra suspenso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Servicos.TCN_Contrato.EncerrarSuspensao(bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato, null);
                    MessageBox.Show("Contrato ATIVADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanContrato_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, gContrato);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Buscar contratos carne vencidos
            object obj = new CamadaDados.Servicos.TCD_Contrato().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.cd_condpgtocarne, '')",
                                    vOperador = "<>",
                                    vVL_Busca = "''"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "not exists",
                                    vVL_Busca = "(select 1 from tb_ose_contrato_x_carne x " +
                                                "inner join tb_fin_duplicata y " +
                                                "on x.cd_empresa = y.cd_empresa " +
                                                "and x.nr_lancto = y.nr_lancto " +
                                                "and isnull(y.st_registro, 'A') <> 'C' " +
                                                "inner join tb_fin_parcela z " +
                                                "on x.cd_empresa = z.cd_empresa " +
                                                "and x.nr_lancto = z.nr_lancto " +
                                                "and month(z.dt_vencto) >= month(getdate()) " + 
                                                "and year(z.dt_vencto) >= year(getdate()) " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_contrato = a.nr_contrato)"
                                }
                            }, "count(a.nr_contrato)");
            tslCarneVenc.Text = obj == null ? string.Empty : obj.ToString();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_contratante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_contratante }, string.Empty);
        }

        private void cd_contratante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_contratante.Text.Trim() + "'",
                                          new Componentes.EditDefault[] { cd_contratante },
                                          new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bsContrato_PositionChanged(object sender, EventArgs e)
        {
            if (bsContrato.Current != null)
            {
                //Buscar itens
                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lItens =
                    CamadaNegocio.Servicos.TCN_Contrato_Itens.Buscar(
                    (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Nr_contratostr,
                    (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_empresa,
                    string.Empty,
                    null);
                //Buscar faturamento
                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lNF =
                    CamadaNegocio.Servicos.TCN_Contrato_X_NF.BuscarNF((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Nr_contratostr,
                                                                      (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_empresa,
                                                                      null);
                //Buscar Carne
                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lCarne =
                    CamadaNegocio.Servicos.TCN_Contrato_X_Carne.Buscar((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_empresa,
                                                                       (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Nr_contratostr,
                                                                       null);
                //Buscar Suspenso
                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).lSuspenso =
                    CamadaNegocio.Servicos.TCN_SuspContrato.Buscar((bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Nr_contratostr,
                                                                   (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_empresa,
                                                                   null);
                bsContrato.ResetCurrentItem();
                bsCarne_PositionChanged(this, new EventArgs());
            }
            else bsCarne.Clear();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void gContrato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                    gContrato.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else if (e.Value.ToString().Trim().ToUpper().Equals("SUSPENSO"))
                    gContrato.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                else if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADO"))
                    gContrato.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gContrato.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void TFLanContrato_KeyDown(object sender, KeyEventArgs e)
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
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                FaturarLote();
            else if (e.KeyCode.Equals(Keys.F10))
                SuspenderContrato();
            else if (e.KeyCode.Equals(Keys.F11))
                EncerrarSuspensao();
            else if (e.KeyCode.Equals(Keys.F12))
                GerarCarne();
        }

        private void bb_lote_Click(object sender, EventArgs e)
        {
            FaturarLote();
        }

        private void TFLanContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, gContrato);
        }

        private void gContrato_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gContrato.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsContrato.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Servicos.TRegistro_Contrato());
            CamadaDados.Servicos.TList_Contrato lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Servicos.TList_Contrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Servicos.TList_Contrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsContrato.List as CamadaDados.Servicos.TList_Contrato).Sort(lComparer);
            bsContrato.ResetBindings(false);
            gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gNotaFiscal_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gNotaFiscal.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNotaFiscal.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento());
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento(lP.Find(gNotaFiscal.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gNotaFiscal.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento(lP.Find(gNotaFiscal.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gNotaFiscal.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNotaFiscal.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento).Sort(lComparer);
            bsNotaFiscal.ResetBindings(false);
            gNotaFiscal.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_suspender_Click(object sender, EventArgs e)
        {
            SuspenderContrato();    
        }

        private void bb_encerrarsusp_Click(object sender, EventArgs e)
        {
            EncerrarSuspensao();    
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bsCarne_PositionChanged(object sender, EventArgs e)
        {
            if(bsCarne.Current != null)
            {
                (bsCarne.Current as CamadaDados.Servicos.TRegistro_Contrato_X_Carne).lParc =
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanParcela.Busca((bsCarne.Current as CamadaDados.Servicos.TRegistro_Contrato_X_Carne).Cd_empresa,
                                                                            (bsCarne.Current as CamadaDados.Servicos.TRegistro_Contrato_X_Carne).Nr_lancto.Value,
                                                                            decimal.Zero,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
                bsCarne.ResetCurrentItem();
            }
        }

        private void gParcelas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 4)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("LIQUIDADA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("VENCIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PERDIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROTESTADO"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Indigo;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("AGRUPADA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                    else
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bbCarne_Click(object sender, EventArgs e)
        {
            GerarCarne();
        }

        private void bbImpBoleto_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                if (string.IsNullOrEmpty((bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Nossonumero))
                {
                    MessageBox.Show("Parcela não possui boleto vinculado para emitir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBoleto = CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_empresa,
                                                                                                                            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Nr_lancto.Value,
                                                                                                                            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Cd_parcela.Value,
                                                                                                                            decimal.Zero,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            decimal.Zero,
                                                                                                                            decimal.Zero,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            false,
                                                                                                                            1,
                                                                                                                            null);
                if (lBoleto.Count > 0)
                {
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de impressao para o bloqueto
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = lBoleto[0].Cd_sacado;
                            fImp.pMensagem = "BLOQUETO Nº" + lBoleto[0].Nosso_numero.Trim();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                                  lBoleto,
                                                                                  fImp.pSt_imprimir,
                                                                                  fImp.pSt_visualizar,
                                                                                  fImp.pSt_enviaremail,
                                                                                  fImp.pSt_exportPdf,
                                                                                  fImp.Path_exportPdf,
                                                                                  fImp.pDestinatarios,
                                                                                  "BLOQUETO Nº " + lBoleto[0].Nosso_numero,
                                                                                  fImp.pDs_mensagem,
                                                                                  false);
                        }
                    }
                    else
                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                          lBoleto,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          string.Empty,
                                                                          null,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          false);
                }
                Altera_Relatorio = false;
            }
        }

        private void tslCarneVenc_Click(object sender, EventArgs e)
        {
            bsContrato.DataSource = CamadaNegocio.Servicos.TCN_Contrato.Buscar(string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               true,
                                                                               true,
                                                                               "'A'",
                                                                               null);
        }

        private void bbAddCarne_Click(object sender, EventArgs e)
        {
            if(bsContrato.Current != null)
                using (TFListaDuplicata fCarne = new TFListaDuplicata())
                {
                    fCarne.Cd_empresa = (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_empresa;
                    fCarne.Cd_clifor = (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Cd_contratante;
                    if(fCarne.ShowDialog() == DialogResult.OK)
                        if(fCarne.rDup != null)
                            try
                            {
                                CamadaNegocio.Servicos.TCN_Contrato_X_Carne.Gravar(
                                    new CamadaDados.Servicos.TRegistro_Contrato_X_Carne()
                                    {
                                        Cd_empresa = fCarne.rDup.Cd_empresa,
                                        Nr_contrato = (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).Nr_contrato,
                                        Nr_lancto = fCarne.rDup.Nr_lancto
                                    }, null);
                                MessageBox.Show("Carnê incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsContrato_PositionChanged(this, new EventArgs());
                            }
                            catch(Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }
    }
}
