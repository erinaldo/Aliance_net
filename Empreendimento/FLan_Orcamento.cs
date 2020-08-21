using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormRelPadrao;

namespace Empreendimento
{
    public partial class TFLan_Orcamento : Form
    {
        private bool Altera_Relatorio = false;
        public TFLan_Orcamento()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            cd_empresa.Clear();
            id_orcamento.Clear();
            nr_versao.Clear();
            cd_clifor.Clear();
            cbAberto.Checked = false;
            cbNegociacao.Checked = false;

            cbReprovado.Checked = false;
            cbCancelado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFOrcamento fOrcamento = new TFOrcamento())
            {
                if (fOrcamento.ShowDialog() == DialogResult.OK)
                    if (fOrcamento.rOrcamento != null)
                        try
                        {
                            TList_CadDespesa lDespesa = TCN_CadDespesa.Busca(string.Empty, string.Empty, null);
                            lDespesa.ForEach(p =>
                            {
                                TRegistro_Despesas desp = new TRegistro_Despesas();
                                desp.Id_despesastr = p.Id_despesastr;
                                desp.Cd_empresa = fOrcamento.rOrcamento.Cd_empresa;
                                desp.Nr_versao = fOrcamento.rOrcamento.Nr_versao;
                                desp.Id_orcamentostr = fOrcamento.rOrcamento.Id_orcamentostr;
                                fOrcamento.rOrcamento.lDespesas.Add(desp);
                            });
                            TCN_Orcamento.Evoluir(fOrcamento.rOrcamento, null);
                            MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresa.Text = fOrcamento.rOrcamento.Cd_empresa;
                            id_orcamento.Text = fOrcamento.rOrcamento.Id_orcamentostr;
                            nr_versao.Text = fOrcamento.rOrcamento.Nr_versaostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("A") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N"))
                {
                    MessageBox.Show("Permitido alterar somente orçamento ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if ((bsOrcamento.Current as TRegistro_Orcamento).Dt_validade != null &&
                   (bsOrcamento.Current as TRegistro_Orcamento).Dt_validade < CamadaDados.UtilData.Data_Servidor())
                {
                    MessageBox.Show("Não é permitido alterar orçamento vencido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFOrcamento fOrc = new TFOrcamento())
                {
                    fOrc.rOrcamento = bsOrcamento.Current as TRegistro_Orcamento;
                    if (fOrc.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_Orcamento.Evoluir(fOrc.rOrcamento, null);
                            MessageBox.Show("Orçamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    LimparFiltros();
                    cd_empresa.Text = fOrc.rOrcamento.Cd_empresa;
                    id_orcamento.Text = fOrc.rOrcamento.Id_orcamentostr;
                    nr_versao.Text = fOrc.rOrcamento.Nr_versaostr;
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("A") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Permitido alterar somente orçamento ABERTO, em NEGOCIAÇÃO ou PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("P"))
                    if (new TCD_Orcamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_orc",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_versaoorc",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Não é permitido CANCELAR orçamento PROCESSADO com PROJETO ATIVO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                if (MessageBox.Show("Confirma CANCELAMENTO do orçamento corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Orcamento.Cancelar(bsOrcamento.Current as TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento CANCELADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "C";
                        bsOrcamento.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbNegociacao.Checked)
            {
                status += virg + "'N'";
                virg = ",";
            }
            if (cbEmOrcamento.Checked)
            {
                status += virg + "'O'";
                virg = ",";
            }
            if (cbReprovado.Checked)
            {
                status += virg + "'R'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                status += virg + "'C'";
                virg = ",";
            }
            if (cbHomologacao.Checked)
            {
                status += virg + "'H'";
                virg = ",";
            }
            if (cbAprovado.Checked)
            {
                status += virg + "'P'";
                virg = ",";
            }
            if (string.IsNullOrEmpty(status))
                status = "'A','N','H','R','O','P'";
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_orcamento.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_versao.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_versao.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(status))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + status + ")";
            }
            if (!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'", ">=");
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'", "<=");
            bsOrcamento.DataSource = new TCD_Orcamento().Select(filtro, 100, string.Empty);
            bsOrcamento.ResetCurrentItem();
        }

        private void OtimizarOrcamento()
        {
            if (bsOrcamento.Current == null)
                return;
            else if (MessageBox.Show("Deseja gerar nova versão do orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N"))
            {
                //Verificar se orçamento possui versão em Aberto 
                if (new TCD_Orcamento().BuscarEscalar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                    }, "1") != null)
                {
                    MessageBox.Show("Orçamento possui versão disponível para OTIMIZAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string ds_tarefa = string.Empty;
                using (TFTarefas fTarefa = new TFTarefas())
                {
                    if (fTarefa.ShowDialog() == DialogResult.OK)
                        ds_tarefa = fTarefa.pDs_tarefa;
                }

                //Atualizar o valor dos materiais
                using (TFMateriais fMateriais = new TFMateriais())
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(r => fMateriais.lFicha.AddRange(r.lFicha));
                    DialogResult result = fMateriais.ShowDialog();
                    if (result == DialogResult.OK)
                        atualizarFicha();
                    else if (result == DialogResult.Abort)
                        return;
                    else if (MessageBox.Show("O processo de atualização dos valores unitários foi cancelado, deseja gerar a nova versão?", 
                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                try
                {
                    TRegistro_Orcamento aux = TCN_Orcamento.GerarNovaVersao(bsOrcamento.Current as TRegistro_Orcamento, ds_tarefa, null);
                    MessageBox.Show("Nova versão gerada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparFiltros();
                    cd_empresa.Text = aux.Cd_empresa;
                    id_orcamento.Text = aux.Id_orcamentostr;
                    nr_versao.Text = aux.Nr_versaostr;
                    cbAberto.Checked = true;
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Permitido otimizar somente orçamento que estiver em NEGOCIAÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void atualizarFicha()
        {
            (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
            {
                p.lFicha = TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                      (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                      (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                      p.Id_projetostr,
                                      string.Empty,
                                      string.Empty,
                                      null);
            });
            bsOrcamento.ResetBindings(true);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLan_Orcamento_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();

            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO ORCAMENTISTA", null))
            {
                bbbOrcamento.Visible = true;
            }
            else
                bbbOrcamento.Visible = false;
            Utils.ShapeGrid.RestoreShape(this, gOrcamento);

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
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gOrcamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOrcamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrcamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Orcamento());
            TList_Orcamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrcamento.List as TList_Orcamento).Sort(lComparer);
            bsOrcamento.ResetBindings(false);
            gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLan_Orcamento_KeyDown(object sender, KeyEventArgs e)
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
                toolStripButton3_Click_1(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F9))
                toolStripButton2_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F10))
                bbOtimizar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F11))
                bbConcluir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12))
            {
                toolStripButton1_Click_1(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.P) && e.Control)
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void bbOtimizar_Click(object sender, EventArgs e)
        {
            OtimizarOrcamento();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {

            if (bsOrcamento.Current != null)
            {
                //Buscar Atividades
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);

                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          p.Id_projetostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
                });
                (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos = TCN_RequisitoORc.Buscar(string.Empty,
                                                                            (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                            (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr, null);



                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas =
                    TCN_Despesas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
                (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos =
                    TCN_RequisitoORc.Buscar(string.Empty, (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          null);

                bsOrcamento.ResetCurrentItem();
            }
        }

        private void bbAprovar_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current) != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                {
                    if (MessageBox.Show("Deseja evoluir para aguardando aprovação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "H";
                            TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                            // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //LimparFiltros();
                            cd_empresa.Text = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            id_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                            cbHomologacao.Checked = true;
                            afterBusca();
                            MessageBox.Show("Orçamento está aguardando aprovação.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Não pode evoluir este orçamento! deve ser em orçamento", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current) != null)
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    if (MessageBox.Show("Deseja evoluir o orçamento para em execução?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                            TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                            cd_empresa.Text = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            id_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                            afterBusca();
                            MessageBox.Show("Orçamento evoluido em execução com sucesso.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Orçamento deve estar em negociação para evoluir para em execução", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void nFRemessaTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nFServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nFEntregaFuturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FExecucao exe = new FExecucao())
            {

                if (bsOrcamento.Current != null)
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A"))
                    {
                        using (TFLan_EvoluirOrcamento orc = new TFLan_EvoluirOrcamento())
                        {
                            orc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                            if (orc.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    TCN_Orcamento.Evoluir(orc.rOrcamento, null);
                                    MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                        MessageBox.Show("Apenas Orçamento em requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void bbConcluir_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                bool flag = true;
                string mensagem = string.Empty;
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O")
                    || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                    {
                        flag = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR FATURAMENTO DIRETO", null));
                        mensagem = "Não tem permissão para otimizar o orcamento como orcamentista.";
                    }
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                    {
                        flag = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null));
                        mensagem = "Não tem permissão para otimizar o orcamento como projetista.";
                    }
                    if (flag)
                    {
                        using (TFLan_EvoluirOrcamento orc = new TFLan_EvoluirOrcamento())
                        {
                            orc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                            if (orc.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "O";
                                    TCN_Orcamento.Evoluir(orc.rOrcamento, null);
                                    MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                                    {
                                        cbEmOrcamento.Checked = true;
                                        cbAberto.Checked = true;
                                    }
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                        MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Apenas Orçamento em requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("H") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    using (FOrcamentoDetalhado orc = new FOrcamentoDetalhado())
                    {
                        orc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                        if (orc.ShowDialog() == DialogResult.OK)
                        {
                            cbNegociacao.Checked = true;
                            afterBusca();
                            Printorcamento();
                        }
                    }
                }
                else
                    MessageBox.Show("Só pode visualizar orçamento em aguardando aprovação.", "Visualizar apenas com status aguardando aprovação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pFiltro_Paint(object sender, PaintEventArgs e)
        {

        }


        private void buscaOrcCompleto()
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                        TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha =
                            TCN_FichaTec.Buscar(p.Cd_empresa,
                                                p.Id_orcamentostr,
                                                p.Nr_versaostr,
                                                p.Id_projetostr,
                                                p.Id_registrostr,
                                                string.Empty,
                                                null);


                });
                //Buscar Despesas
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas =
                    TCN_Despesas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        string.Empty,
                                        string.Empty,
                                        null);
                //Buscar Tarefas
                (bsOrcamento.Current as TRegistro_Orcamento).lTarefas =
                    TCN_Tarefas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        null);
                //Buscar mao obra
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra =
                    TCN_CadMaoObra.Busca(
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        string.Empty,
                                        null);
                //Buscar encargos
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                    TCN_OrcamentoEncargo.Buscar(
                                        string.Empty,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        null);
            }
        }

        private bool validaorcamento()
        {

            bool gravar = true;

            TList_CadCFGEmpreendimento lcfg = new TCD_CadCFGEmpreendimento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" +  (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                    }
                }, 0, string.Empty);

            if (lcfg.Count > 0)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_cofins = lcfg[0].Pc_Cofins;
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_pis = lcfg[0].Pc_PIS;
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont = lcfg[0].Pc_margemcont;
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_irpj = lcfg[0].Pc_IRPJ;
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_csll = lcfg[0].Pc_CSLL;
            }
            bool bol = false;
            if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                {
                    if (o.lFicha.Count <= 0)
                        bol = true;
                });
                if (bol)
                {
                    if (MessageBox.Show("Existe atividade sem item! Deseja evoluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gravar = true;
                    }
                    else
                        return false;
                }
            }
            if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                {
                    o.lFicha.ForEach(p =>
                    {
                        if (p.Vl_subtotal <= decimal.Zero)
                        {
                            gravar = false;
                        }
                    });
                });
                if (!gravar)
                {
                    MessageBox.Show("Existe um item sem valor total.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                {
                    o.lFicha.ForEach(p =>
                    {
                        if (p.Vl_unitario <= decimal.Zero)
                        {
                            gravar = false;
                        }
                    });
                });
                if (!gravar)
                {
                    MessageBox.Show("Existe um item sem valor unitario.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }

            return gravar;

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current) != null)
            {
                bsOrcamento_PositionChanged(this, new EventArgs());
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A"))
                {
                    MessageBox.Show("Não pode evoluir orçamento de requisição.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("H"))
                {
                    MessageBox.Show("Não pode evoluir orçamento que etiver aguardando aprovação.", "Homologação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                {
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO ORCAMENTISTA", null))
                    {
                        if (MessageBox.Show("Orcamento está em " + (bsOrcamento.Current as TRegistro_Orcamento).Status + ", Deseja evoluir para aguardando aprovação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                if (!validaorcamento())
                                    return;
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "H";
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                                // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //LimparFiltros();
                                cd_empresa.Text = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                id_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                cbHomologacao.Checked = true;
                                afterBusca();
                                MessageBox.Show("Orçamento está aguardando aprovação.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        MessageBox.Show("Usuario não possui permissão de orcamentista para esta evolução.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N") &&
                    (bsOrcamento.Current as TRegistro_Orcamento).Dt_validade == null)
                {
                    MessageBox.Show("Orçamento não possui data de validade não será possível evoluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }else if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N") &&
                    (bsOrcamento.Current as TRegistro_Orcamento).Dt_validade < CamadaDados.UtilData.Data_Servidor())
                {
                    MessageBox.Show("Não é permitido evoluir orçamento vencido. Será necessário gerar uma nova versão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    if ((CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR APROVAR", null)))
                    {

                        bool evoluir = true;

                        TRegistro_Orcamento orcamento = new TRegistro_Orcamento();
                        orcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                        object qtd_orc = new TCD_Orcamento().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_orcamento",
                                    vOperador = "=",
                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.dt_validade",
                                    vOperador = ">",
                                    vVL_Busca = "getdate()"
                                }
                            }, "count(a.nr_versao)");
                        if (qtd_orc != null)
                        {
                            if (Convert.ToDecimal(qtd_orc.ToString()) > 1)
                                using (FCompararVersao vers = new FCompararVersao())
                                {
                                    vers.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                    vers.vId_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                    DialogResult result = vers.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        orcamento = vers.rOrc;
                                        orcamento.lOrcProjeto.ForEach(p =>
                                        {
                                            p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa, p.Id_orcamentostr, p.Nr_versaostr, p.Id_projetostr, string.Empty, string.Empty, null);
                                        });
                                    }
                                    else if (result == DialogResult.Abort)
                                    {
                                        reprova();
                                        return;
                                    }
                                    else
                                    {
                                        evoluir = false;
                                        return;
                                    }
                                }
                        }
                        if (orcamento.Equals(new TRegistro_Orcamento()))
                        {
                            orcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                        }
                        if (evoluir)
                            if (MessageBox.Show("Orcamento está em " + (bsOrcamento.Current as TRegistro_Orcamento).Status +
                                ", Deseja evoluir para negociado? as outras versões serão reprovadas e esta será a oficial.", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                try
                                {
                                    using (FDesconto a = new FDesconto())
                                    {
                                        a.rEmpreendimento = orcamento;
                                        if (a.ShowDialog() == DialogResult.OK)
                                        {

                                            //a.rEmpreendimento.vl_orcamento = a.rEmpreendimento.total_orcamento;
                                            orcamento = a.rEmpreendimento;
                                            //TCN_Orcamento.Gravar(a.rEmpreendimento, null);
                                        }
                                        else
                                            return;
                                    }

                                    //gera uma nova versão como aprovado
                                    orcamento.St_registro = "P";
                                    buscaOrcCompleto();
                                    TCN_Orcamento.Gravar(orcamento, null);

                                    TRegistro_Orcamento aux = orcamento;
                                    //aux nova versão, correcao dos valores
                                    aux.St_registro = "T";
                                    aux.Nr_versaoOrc = aux.Nr_versao;
                                    aux.Nr_versao = null;
                                    aux.Id_orc = aux.Id_orcamento;
                                    aux.Id_orcamento = null;
                                    //aux.calcular_comissao = true;
                                    TCN_Orcamento.Evoluir(aux, null);

                                    //reprova outras vercoes
                                    TList_Orcamento listaReprovar = new TCD_Orcamento().Select(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.st_registro",
                                        vOperador = "<>",
                                        vVL_Busca = "('P')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_orcamento",
                                        vOperador = "=",
                                        vVL_Busca = aux.Id_orc.ToString()
                                    }
                                    }
                                    , 100, string.Empty);
                                    listaReprovar.ForEach(p =>
                                    {
                                        p.St_registro = "R";
                                        new TCD_Orcamento().Gravar(p);
                                    });







                                    // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //LimparFiltros();
                                    pFiltro.set_FormatZero();

                                    afterBusca();
                                    MessageBox.Show("Orçamento está aguardando aprovação.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                    }
                    else
                        MessageBox.Show("Usuário sem permissão para aprovar orçamento.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else

                //if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                //{
                //    if (MessageBox.Show("Orcamento está em " + (bsOrcamento.Current as TRegistro_Orcamento).Status + ", evoluir para projeto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                //           MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //    {

                //        TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                //        cbEmProjeto.Checked = true;
                //        cd_empresa.Text = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                //        id_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                //        nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                //        MessageBox.Show("Orçamento está em projeto.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        afterBusca();
                //    }
                //}
                //else
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                {
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null))
                    {
                        if (MessageBox.Show("Orcamento está em " + (bsOrcamento.Current as TRegistro_Orcamento).Status + ", Deseja finalizar o projeto e evoluir para execução?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                                // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                //cbHomologacao.Checked = true;
                                afterBusca();
                                MessageBox.Show("Orçamento está aguardando em execução.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        MessageBox.Show("Usuário não tem permissão de projetista para esta evolução.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {

        }

        private void gOrcamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsOrcamento.Current != null)
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O")
                       || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                {
                    bbConcluir_Click(this, new EventArgs());
                }
                else if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("H") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    toolStripButton1_Click_1(this, new EventArgs());
                }
        }

        private void toolStripDropDown_Relatorios_Click(object sender, EventArgs e)
        {

        }

        private void Print()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("H") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                    //Buscar Atividades
                    orcamento.lOrcProjeto =
                        TCN_OrcProjeto.Buscar(orcamento.Cd_empresa,
                                              orcamento.Id_orcamentostr,
                                              orcamento.Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                    //Buscar requisitos
                    orcamento.lRequisitos =
                        TCN_RequisitoORc.Buscar(string.Empty,
                                              orcamento.Cd_empresa,
                                              orcamento.Id_orcamentostr,
                                              orcamento.Nr_versaostr,
                                              null);
                    //Buscar Despesas
                    orcamento.lDespesas =
                        TCN_Despesas.Buscar(orcamento.Cd_empresa,
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            string.Empty,
                                            string.Empty,
                                            null);
                    //Buscar Tarefas
                    orcamento.lTarefas =
                        TCN_Tarefas.Buscar(orcamento.Cd_empresa,
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            null);
                    //Buscar mao obra
                    orcamento.lMaoObra =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            orcamento.Cd_empresa,
                                            string.Empty,
                                            null);


                    //Buscar encargos
                    orcamento.lOEncargo =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(
                                            string.Empty,
                                            orcamento.Cd_empresa,
                                            orcamento.Nr_versaostr,
                                            orcamento.Id_orcamentostr,
                                            null);
                    // preenche itens
                    orcamento.lOrcProjeto.ForEach(p =>
                    {
                        p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa,
                                                    p.Id_orcamentostr,
                                                    p.Nr_versaostr,
                                                    p.Id_projetostr,
                                                    p.Id_registrostr,
                                                    string.Empty,
                                                    null);
                    });


                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
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
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      1,
                                                                      null);

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                    orcamento.Cd_endereco,
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
                                                                    1,
                                                                    null);

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
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

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               orcamento.Cd_clifor,
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

                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");

                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Orcamento lista = new TList_Orcamento();
                    lista.Add(orcamento);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista;
                    bsOrcamento.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_OrcEmpreendimento";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = orcamento.Cd_clifor;
                            fImp.pCd_representante = orcamento.Cd_vendedor;
                            fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
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
        }

        private void RelItensAtividade()
        {
            if (bsOrcamento.Current != null)
            {

                TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                //Buscar Atividades
                orcamento.lOrcProjeto =
                    TCN_OrcProjeto.Buscar(orcamento.Cd_empresa,
                                          orcamento.Id_orcamentostr,
                                          orcamento.Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);


                //Buscar produtos
                orcamento.lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa, p.Id_orcamentostr, p.Nr_versaostr,
                        p.Id_projetostr, string.Empty, string.Empty, null);
                });


                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             null);

                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
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
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  1,
                                                                  null);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                orcamento.Cd_endereco,
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
                                                                1,
                                                                null);

                BindingSource BinEndEntrega = new BindingSource();
                BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                    }, 1, string.Empty);


                object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                    }, "a.cd_clifor");

                BindingSource BinContatos = new BindingSource();
                BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                     cliforEmpresa.ToString(),
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

                BindingSource BinContatosClifor = new BindingSource();
                BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                           orcamento.Cd_clifor,
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

                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                }, "a.tp_imppedido");

                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                TList_Orcamento lista = new TList_Orcamento();
                lista.Add(orcamento);
                BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = lista;
                bsOrcamento.ResetCurrentItem();
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                Relatorio.DTS_Relatorio = meu_bind;

                Relatorio.Ident = "FLan_OrcItensAtividade";
                if (BinEmpresa.Current != null)
                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = orcamento.Cd_clifor;
                        fImp.pCd_representante = orcamento.Cd_vendedor;
                        fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
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

        private void RelGrupoAtividade()
        {
            if (bsOrcamento.Current != null)
            {

                TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                //Buscar Atividades
                orcamento.lOrcProjeto =
                    TCN_OrcProjeto.Buscar(orcamento.Cd_empresa,
                                          orcamento.Id_orcamentostr,
                                          orcamento.Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);


                //Buscar produtos
                orcamento.lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa, p.Id_orcamentostr, p.Nr_versaostr,
                        string.Empty, string.Empty, string.Empty, null);
                });


                BindingSource BinEmpresa = new BindingSource();
                BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             null);

                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
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
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  1,
                                                                  null);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                orcamento.Cd_endereco,
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
                                                                1,
                                                                null);

                BindingSource BinEndEntrega = new BindingSource();
                BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                    }, 1, string.Empty);


                object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                    }, "a.cd_clifor");

                BindingSource BinContatos = new BindingSource();
                BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                     cliforEmpresa.ToString(),
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

                BindingSource BinContatosClifor = new BindingSource();
                BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                           orcamento.Cd_clifor,
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

                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                }, "a.tp_imppedido");

                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                TList_Orcamento lista = new TList_Orcamento();
                lista.Add(orcamento);
                BindingSource meu_bind = new BindingSource();
                meu_bind.DataSource = lista;
                bsOrcamento.ResetCurrentItem();
                Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                Relatorio.DTS_Relatorio = meu_bind;

                Relatorio.Ident = "FLan_OrcItensGrupo";
                if (BinEmpresa.Current != null)
                    if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = orcamento.Cd_clifor;
                        fImp.pCd_representante = orcamento.Cd_vendedor;
                        fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
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


        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void fichaDeAcompanhamentoDoTanqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelItensAtividade();
        }

        private void TFLan_Orcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOrcamento);
        }

        private void relatórioDeMateriaisPorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelGrupoAtividade();
        }

        private void relatórioGeralDoOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printorcamento();
        }

        private decimal calculavalor(decimal val, decimal tot, decimal tot_final)
        {
            decimal ret = decimal.Zero;
            try
            {
                ret = decimal.Divide(decimal.Multiply(decimal.Divide(decimal.Multiply(val, 100), tot), tot_final), 100);
                return ret;
            }
            catch
            {
                return ret;
            }
        }

        private void Printorcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("H")
                    || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    TRegistro_Orcamento orcamento = (bsOrcamento.Current as TRegistro_Orcamento);


                    //Buscar Atividades
                    orcamento.lOrcProjeto =
                        TCN_OrcProjeto.Buscar(orcamento.Cd_empresa,
                                              orcamento.Id_orcamentostr,
                                              orcamento.Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                    //Buscar requisitos
                    orcamento.lRequisitos =
                        TCN_RequisitoORc.Buscar(string.Empty,
                                              orcamento.Cd_empresa,
                                              orcamento.Id_orcamentostr,
                                              orcamento.Nr_versaostr,
                                              null);
                    //Buscar Despesas
                    orcamento.lDespesas =
                        TCN_Despesas.Buscar(orcamento.Cd_empresa,
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            string.Empty,
                                            string.Empty,
                                            null);
                    orcamento.lDespesas.ForEach(p =>
                    {
                        p.Vl_unitario = calculavalor(p.Vl_unitario, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                        p.Vl_subtotal = calculavalor(p.Vl_subtotal, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                    });
                    //Buscar Tarefas
                    orcamento.lTarefas =
                        TCN_Tarefas.Buscar(orcamento.Cd_empresa,
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            null);
                    //Buscar mao obra
                    orcamento.lMaoObra =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(
                                            orcamento.Id_orcamentostr,
                                            orcamento.Nr_versaostr,
                                            orcamento.Cd_empresa,
                                            string.Empty,
                                            null);

                    orcamento.lMaoObra.ForEach(p =>
                    {
                        p.vl_unitario = calculavalor(p.vl_unitario, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                        p.vl_subtotal = calculavalor(p.vl_subtotal, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                    });

                    //Buscar encargos
                    orcamento.lOEncargo =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(
                                            string.Empty,
                                            orcamento.Cd_empresa,
                                            orcamento.Nr_versaostr,
                                            orcamento.Id_orcamentostr,
                                            null);

                    orcamento.lOEncargo.ForEach(p =>
                    {
                        p.vl_encargo = calculavalor(p.vl_encargo, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                    });
                    // preenche itens
                    orcamento.lOrcProjeto.ForEach(p =>
                    {
                        p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa,
                                                    p.Id_orcamentostr,
                                                    p.Nr_versaostr,
                                                    p.Id_projetostr,
                                                    p.Id_registrostr,
                                                    string.Empty,
                                                    null);
                    });
                    orcamento.lOrcProjeto.ForEach(p =>
                    {
                        p.lFicha.ForEach(o =>
                        {
                            o.Vl_unitario = calculavalor(o.Vl_unitario, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                            o.Vl_subtotal = calculavalor(o.Vl_subtotal, orcamento.Custo_Empreendimento, orcamento.total_orcdesc);
                        });
                    });


                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(orcamento.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(orcamento.Cd_clifor,
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
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      1,
                                                                      null);

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(orcamento.Cd_clifor,
                                                                    orcamento.Cd_endereco,
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
                                                                    1,
                                                                    null);

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + orcamento.Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + orcamento.Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
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

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               orcamento.Cd_clifor,
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

                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imppedido");

                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Orcamento lista = new TList_Orcamento();
                    lista.Add(orcamento);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista;
                    bsOrcamento.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "FLan_OrcEmpreendimento";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = orcamento.Cd_clifor;
                            fImp.pCd_representante = orcamento.Cd_vendedor;
                            fImp.pMensagem = ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(orcamento.Id_orcamentostr.ToString(),
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("ORÇAMENTO Nº " + orcamento.Id_orcamentostr.ToString() + " VERSÃO Nº " + orcamento.Nr_versaostr),
                                                         fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }

                }
                else
                    MessageBox.Show("Orcamento deve ser em negociacao ou aprovacao!", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void reprova()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                {
                    TList_Orcamento orca = new TList_Orcamento();
                    orca = TCN_Orcamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null);
                    orca.ForEach(p =>
                    {
                        p.St_registro = "R";
                        TCN_Orcamento.Gravar(p, null);
                    });
                    MessageBox.Show("Orcamento reprovado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    afterBusca();
                }
                else
                {
                    MessageBox.Show("Para reprovar apenas orcamentos em negociacao!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dejesa reprovar todas as versões?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                reprova();
        }

        private void gOrcamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("NEGOCIADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    else gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                }
        }

        private void gOrcamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
