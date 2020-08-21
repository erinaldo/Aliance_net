using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Bloqueto;
using Utils;

namespace Financeiro
{
    public partial class TFLan_Remessa : Form
    {
        public TFLan_Remessa()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_lote.Clear();
            cbConfig.SelectedIndex = -1;
            DT_Inicial.Clear();
            DT_Final.Clear();
            cbAberto.Checked = false;
            cbFaturado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFLoteRemessa fLote = new TFLoteRemessa())
            {
                if(fLote.ShowDialog() == DialogResult.OK)
                    if (fLote.rLote != null)
                    {
                        try
                        {
                            TCN_LoteRemessa.Gravar(fLote.rLote, null);
                            MessageBox.Show("Lote remessa gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            id_lote.Text = fLote.rLote.Id_lotestr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterExclui()
        {
            if (bsLoteRemessa.Current != null)
            {
                if ((bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Exists(p=> p.Status_remessa.Trim().ToUpper().Equals("ACEITO")))
                {
                    MessageBox.Show("Não é permitido excluir lote que contenha titulo com status ACEITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do lote selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LoteRemessa.Excluir(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa, null);
                        MessageBox.Show("Lote remessa excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote remessa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                cond = "'A'";
                virg = ",";
            }
            if (cbFaturado.Checked)
                cond += virg + "'P'";
            bsLoteRemessa.DataSource = TCN_LoteRemessa.Buscar(id_lote.Text,
                                                              cbConfig.SelectedValue != null ? cbConfig.SelectedValue.ToString() : string.Empty,
                                                              nosso_numero.Text,
                                                              cond,
                                                              DT_Inicial.Text,
                                                              DT_Final.Text,
                                                              st_rejeitados.Checked,
                                                              null);
            bsLoteRemessa_PositionChanged(this, new EventArgs());
        }

        private bool ValidacaoCEP()
        {
            string msg = string.Empty;
            (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.ForEach(p =>
            {
                if (!p.Sacado.Endereco.CEP.SoNumero().Length.Equals(8))
                {
                    if (string.IsNullOrEmpty(msg))
                        msg = "Bloquetos com cliente com CEP inválido:\r\n";
                    msg += "Nº Docto: " + p.NumeroDocumento + "\r\n" +
                           "Nosso Numero: " + p.Nosso_numero.Trim() + "\r\n" +
                           "Parcela: " + p.Cd_parcela + "\r\n" +
                           "Cliente: " + p.Nm_sacado.Trim() + "\r\n\r\n";
                }
            });

            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else return true;
        }

        private void ProcessarLote()
        {
            if (bsLoteRemessa.Current != null)
            {
                //Validar CEP 
                if (!ValidacaoCEP())
                    return;
                //Validar Dt. Vencimento
                if ((bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa)
                    .lTitulos
                    .Exists(x => x.Dt_vencimento < CamadaDados.UtilData.Data_Servidor()))
                {
                    MessageBox.Show("O lote selecionado possui títulos vencidos, não será possivel processar a remessa.", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).St_registro.Trim().ToUpper().Equals("P"))
                    if (MessageBox.Show("Lote PROCESSADO. Deseja gerar novo arquivo deste lote?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        return;
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Salvar Arquivo Remessa";
                    fbd.ShowNewFolderButton = true;
                    if (!string.IsNullOrEmpty(SettingsUtils.Default.PATH_REMESSA))
                        fbd.SelectedPath = SettingsUtils.Default.PATH_REMESSA;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Path_remessa = fbd.SelectedPath;
                            TCN_LoteRemessa.ProcessarRemessa(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa, null);
                            MessageBox.Show("Lote Remessa  processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Buscar configuracao
                            CamadaDados.Financeiro.Cadastros.TList_CadCFGBanco lCfg =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadCFGBanco.Buscar(string.Empty,
                                                                                          string.Empty,
                                                                                          (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Cd_empresa,
                                                                                          string.Empty,
                                                                                          "CR",
                                                                                          (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Cd_contager,
                                                                                          "A",
                                                                                          string.Empty,
                                                                                          1,
                                                                                          null);
                            LimparFiltros();
                            id_lote.Text = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Id_lotestr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            SettingsUtils.Default.PATH_REMESSA = fbd.SelectedPath;
                            SettingsUtils.Default.Save();
                        }
                    }
                    else MessageBox.Show("Obrigatorio informar PATH para salvar arquivo REMESSA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para processar remessa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirTitulo()
        {
            if (bsLoteRemessa.Current != null)
            {
                if ((bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido inserir titulo em lote PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLocalizarBloquetos fLocalizar = new TFLocalizarBloquetos())
                {
                    fLocalizar.Text = "Localizar Bloquetos Gerar Remessa";
                    fLocalizar.pCd_empresa = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Cd_empresa;
                    fLocalizar.pNm_empresa = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Nm_empresa;
                    fLocalizar.St_remessa = true;
                    fLocalizar.pId_Config = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Id_configstr;
                    fLocalizar.pDs_config = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Ds_config;
                    fLocalizar.Tp_instrucao = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Tp_instrucao;
                    if (fLocalizar.ShowDialog() == DialogResult.OK)
                        if (fLocalizar.lBloquetos != null)
                        {
                            fLocalizar.lBloquetos.ForEach(p =>
                            {
                                if (!(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Exists(v => v.Nosso_numero.Trim().Equals(p.Nosso_numero.Trim())))
                                    (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Add(p);
                            });
                            try
                            {
                                TCN_LoteRemessa.Gravar(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa, null);
                                MessageBox.Show("Titulos incluidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsLoteRemessa.ResetCurrentItem();
                                vl_total_bloqueto.Value = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Sum(p => p.Vl_documento);    
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para inserir titulo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirTitulo()
        {
            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Status_remessa.Trim().ToUpper().Equals("ACEITO"))
                {
                    MessageBox.Show("Não é permitido excluir titulo aceito em um lote de remessa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do titulo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulosDel.Add(
                            dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo);
                        dsBloqueto.RemoveCurrent();
                        TCN_LoteRemessa.Gravar(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa, null);
                        MessageBox.Show("Titulo excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_total_bloqueto.Value = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Sum(p => p.Vl_documento);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar titulo para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FLan_Remessa_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gBloqueto);
            ShapeGrid.RestoreShape(this, gLote);
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bsLoteRemessa_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteRemessa.Current != null)
            {
                (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos =
                    TCN_LoteRemessa_X_Titulo.BuscarTitulos((bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Id_lotestr, null);
                bsLoteRemessa.ResetCurrentItem();
                vl_total_bloqueto.Value = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).lTitulos.Sum(p => p.Vl_atual);
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            ProcessarLote();
        }

        private void TFLan_Remessa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ProcessarLote();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirTitulo();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirTitulo();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirTitulo();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirTitulo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gLote_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    gLote.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gLote.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void TFLan_Remessa_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gBloqueto);
            ShapeGrid.SaveShape(this, gLote);
        }

        private void gBloqueto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ACEITO"))
                        gBloqueto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REJEITADO"))
                        gBloqueto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gBloqueto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gLote_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLote.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLoteRemessa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa());
            CamadaDados.Financeiro.Bloqueto.TList_LoteRemessa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Bloqueto.TList_LoteRemessa(lP.Find(gLote.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLote.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Bloqueto.TList_LoteRemessa(lP.Find(gLote.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLote.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLoteRemessa.List as CamadaDados.Financeiro.Bloqueto.TList_LoteRemessa).Sort(lComparer);
            bsLoteRemessa.ResetBindings(false);
            gLote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao; 
        }

        private void bb_atualizaseq_Click(object sender, EventArgs e)
        {
            if(bsLoteRemessa.Current != null)
                using (TFAtualizaSeqRemessa fAtualiza = new TFAtualizaSeqRemessa())
                {
                    fAtualiza.pId_config = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Id_configstr;
                    fAtualiza.pDs_config = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Ds_config;
                    fAtualiza.pNr_seqatual = (bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa).Nr_arqRemessa;
                    if(fAtualiza.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LoteRemessa.AlterarSeqRemessa(bsLoteRemessa.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteRemessa, fAtualiza.Nr_seqremessa, null);
                            MessageBox.Show("Sequencial alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void btn_CorrigirEndereco_Click(object sender, EventArgs e)
        {
            if (dsBloqueto.Current != null)
            {
                //Buscar cadastro cliente
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_sacado, null);
                //Buscar endereco
                rClifor.lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rClifor.Cd_clifor,
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
                                                                                              string.Empty,
                                                                                              0,
                                                                                              null);
                //Buscar Contatos
                rClifor.lContato = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                  rClifor.Cd_clifor,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  false,
                                                                                                  false,
                                                                                                  false,
                                                                                                  string.Empty,
                                                                                                  0,
                                                                                                  null);
                //Buscar Dados bancario
                rClifor.lDadosBanc = CamadaNegocio.Financeiro.Cadastros.TCN_CadDados_Bancarios_Clifor.Busca(rClifor.Cd_clifor,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);

                using (Financeiro.Cadastros.TFClifor fClifor = new Financeiro.Cadastros.TFClifor())
                {
                    fClifor.rClifor = rClifor;
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                MessageBox.Show("Cadastro Cliente/Fornecedor atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
    }
}
