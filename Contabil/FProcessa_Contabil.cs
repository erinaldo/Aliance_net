using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using CamadaDados.Contabil.Cadastro;
using CamadaDados.Estoque.Cadastros;

namespace Contabil
{
    public partial class TFProcessa_Contabil : FormPadrao.FFormPadrao
    {
        public TFProcessa_Contabil()
        {
            InitializeComponent();
            this.BB_Gravar.Visible = true;
            this.BB_Gravar.Text = "(F4)\r\nProcessar";
            this.BB_Gravar.ToolTipText = "Processar Contabilidade";
            this.BB_Gravar.Width = 105;
            this.BB_Alterar.Visible = true;
            this.BB_Alterar.Text = "(F3)\r\nConfiguração";
            this.BB_Alterar.ToolTipText = "Configuração Contábil";
            this.BB_Alterar.Width = 115;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            pDados.LimparRegistro();
            tabControl.SelectedIndex = 0;
            DT_Inicial.Focus();
            pDadosFiltroCaixa.LimparRegistro();
            pDadosTot.LimparRegistro();
            pDadosFiltroFAT.LimparRegistro();
            pDadosFiltroFIN.LimparRegistro();
            pDadosFiltroCH.LimparRegistro();
            rb_Todos.Checked = true;
            rb_TodosFin.Checked = true;
            rb_TodosFAT.Checked = true;
        }

        public override void afterBusca()
        {
            if (tabControl.SelectedTab.Equals(tabCaixaBancos))
                BuscaProcCaixa();
            else if (tabControl.SelectedTab.Equals(tabFaturamento))
                BuscaProcFaturamento();
            else if (tabControl.SelectedTab.Equals(tabChequeComp))
                BuscaProcChequeCompensado();
            else if (tabControl.SelectedTab.Equals(tabFinanceiro))
                BuscaProcFinanceiro();
            else if (tabControl.SelectedTab.Equals(tabProvisaoEstoque))
                BuscaProcProvEstoque();
            else if (tabControl.SelectedTab.Equals(tabPatrimonio))
                BuscaProcPatrimonio();
        }
        /*
        public override void afterAltera()
        {
            frameConfigContabil.MdiParent = this.MdiParent;
            frameConfigContabil.Show();

            if (tabControl.SelectedIndex == 0)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 0;
                if (BS_ProcFinanceiro.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_Lan_ProcFinanceiro reg_ProcFinanceiro = BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro;
                    (frameConfigContabil.BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro).Cd_clifor = reg_ProcFinanceiro.CD_Clifor;
                    (frameConfigContabil.BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro).Cd_historico = reg_ProcFinanceiro.CD_Historico;
                    (frameConfigContabil.BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro).Tp_duplicata = reg_ProcFinanceiro.TP_Duplicata;
                    if (reg_ProcFinanceiro.CD_ContaCre > 0)
                        (frameConfigContabil.BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro).Cd_conta_ctb_cred = reg_ProcFinanceiro.CD_ContaCre;
                    if (reg_ProcFinanceiro.CD_ContaDeb > 0)
                        (frameConfigContabil.BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro).Cd_conta_ctb_deb = reg_ProcFinanceiro.CD_ContaDeb;
                    frameConfigContabil.BS_Financeiro.ResetBindings(true);

                    frameConfigContabil.CD_Clifor_Financeiro_Leave(null, null);
                    frameConfigContabil.CD_Historico_Financeiro_Leave(null, null);
                    frameConfigContabil.TP_Duplicata_Financeiro_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Financeiro_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Financeiro_Leave(null, null);
                }
            }
            else if (tabControl.SelectedIndex == 1)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 1;

                if (BS_ProcFaturamento.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_Lan_ProcFaturamento reg_ProcFaturamento = BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento;
                    (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Empresa = reg_ProcFaturamento.CD_Empresa;
                    (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Movimentacao = reg_ProcFaturamento.CD_Movto;
                    (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Clifor = reg_ProcFaturamento.CD_Clifor;
                    (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Produto = reg_ProcFaturamento.CD_Produto;
                    if (reg_ProcFaturamento.CD_ContaCre > 0)
                        (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Conta_CTB_CRED_String = reg_ProcFaturamento.CD_ContaCre.ToString();
                    if (reg_ProcFaturamento.CD_ContaDeb > 0)
                        (frameConfigContabil.BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento).CD_Conta_CTB_DEB_String = reg_ProcFaturamento.CD_ContaDeb.ToString();
                    frameConfigContabil.BS_Faturamento.ResetBindings(true);

                    frameConfigContabil.CD_Empresa_Leave(null, null);
                    frameConfigContabil.CD_Movientacao_Faturamento_Leave(null, null);
                    frameConfigContabil.CD_Clifor_Faturamento_Leave(null, null);
                    frameConfigContabil.CD_Produto_Faturamento_Leave(null, null);
                    frameConfigContabil.CD_CFOP_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Faturamento_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Faturamento_Leave(null, null);
                }
            }
            else if (tabControl.SelectedIndex == 2)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 2;
                
            }
            else if (tabControl.SelectedIndex == 3)
            {
                 
                
            }
            else if (tabControl.SelectedIndex == 4)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 4;
                if (BS_ProcCaixa.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_Lan_ProcCaixa reg_ProcCaixa = BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa;
                    (frameConfigContabil.BS_Caixa.Current as TRegistro_CTB_CFGCaixa).CD_Empresa = reg_ProcCaixa.CD_Empresa;
                    (frameConfigContabil.BS_Caixa.Current as TRegistro_CTB_CFGCaixa).CD_ContaGer = reg_ProcCaixa.CD_ContaGer;
                    (frameConfigContabil.BS_Caixa.Current as TRegistro_CTB_CFGCaixa).CD_Historico = reg_ProcCaixa.CD_Historico;
                    if (reg_ProcCaixa.CD_ContaCre > 0)
                        (frameConfigContabil.BS_Caixa.Current as TRegistro_CTB_CFGCaixa).CD_Conta_CTB_CRED = reg_ProcCaixa.CD_ContaCre;
                    if (reg_ProcCaixa.CD_ContaDeb > 0)
                        (frameConfigContabil.BS_Caixa.Current as TRegistro_CTB_CFGCaixa).CD_Conta_CTB_DEB = reg_ProcCaixa.CD_ContaDeb;

                    if (reg_ProcCaixa.TP_Movimento == "R")
                    {
                        frameConfigContabil.Recebimento.Checked = true;
                        frameConfigContabil.Pagamento.Checked = false;
                    }
                    else
                    {
                        frameConfigContabil.Recebimento.Checked = false;
                        frameConfigContabil.Pagamento.Checked = true;
                    }

                    frameConfigContabil.BS_Caixa.ResetBindings(true);
                    frameConfigContabil.CD_Empresa_Caixa_Leave(null, null);
                    frameConfigContabil.CD_ContaGer_Caixa_Leave(null, null);
                    frameConfigContabil.Cd_Historico_Caixa_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Caixa_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Caixa_Leave(null, null);
                }
            }
            else if (tabControl.SelectedIndex == 5)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 5;

                if (BS_ProcChequeCompensado.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_Lan_ProcChequeCompensado reg_ProcChequeCompensado = BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado;
                    (frameConfigContabil.BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado).Cd_contager_entrada = reg_ProcChequeCompensado.CD_ContaGerOrig;
                    (frameConfigContabil.BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado).Cd_contager_saida = reg_ProcChequeCompensado.CD_ContaGerDest;
                    if (reg_ProcChequeCompensado.Cd_contacred > 0)
                        (frameConfigContabil.BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado).Cd_conta_ctb_credstr = reg_ProcChequeCompensado.Cd_contacred.ToString();
                    if (reg_ProcChequeCompensado.Cd_contadeb > 0)
                        (frameConfigContabil.BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado).Cd_conta_ctb_debstr = reg_ProcChequeCompensado.Cd_contadeb.ToString();
                    if (reg_ProcChequeCompensado.TP_Movimento == "R")
                    {
                        frameConfigContabil.ckRecebimento_Cheque.Checked = true;
                        frameConfigContabil.ckPagamento_Cheque.Checked = false;
                    }
                    else
                    {
                        frameConfigContabil.ckRecebimento_Cheque.Checked = false;
                        frameConfigContabil.ckPagamento_Cheque.Checked = true;
                    }

                    frameConfigContabil.BS_Cheque.ResetBindings(true);

                    frameConfigContabil.CD_ContaGer_Entrada_Cheque_Leave(null, null);
                    frameConfigContabil.CD_ContaGer_Saida_Cheque_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Cheque_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Cheque_Leave(null, null);
                }
            }
            else if (tabControl.SelectedIndex == 6)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 6;

                if (BS_ProcFinanceiro.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_Lan_ProcProvEstoque reg_ProcProvEstoque = BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque;
                    (frameConfigContabil.BS_Provisao.Current as TRegistro_CTB_CFGProvisao_Estoque).CD_Produto = reg_ProcProvEstoque.CD_Produto;
                    if (reg_ProcProvEstoque.CD_ContaCre > 0)
                        (frameConfigContabil.BS_Provisao.Current as TRegistro_CTB_CFGProvisao_Estoque).CD_Conta_CTB_CRED_String = reg_ProcProvEstoque.CD_ContaCre.ToString();
                    if (reg_ProcProvEstoque.CD_ContaDeb > 0)
                        (frameConfigContabil.BS_Provisao.Current as TRegistro_CTB_CFGProvisao_Estoque).CD_Conta_CTB_DEB_String = reg_ProcProvEstoque.CD_ContaDeb.ToString();
                    if (reg_ProcProvEstoque.TP_Movimento == "E")
                    {
                        frameConfigContabil.ck_Entrada.Checked = true;
                        frameConfigContabil.ck_Saida.Checked = false;
                    }
                    else
                    {
                        frameConfigContabil.ck_Entrada.Checked = false;
                        frameConfigContabil.ck_Saida.Checked = true;
                    }

                    frameConfigContabil.BS_Provisao.ResetBindings(true);

                    frameConfigContabil.CD_Produto_Estoque_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Estoque_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Estoque_Leave(null, null);
                }
            }
            else if (tabControl.SelectedIndex == 7)
            {
                frameConfigContabil.tcCentral.SelectedIndex = 7;

                if (BS_ProcPatrimonio.Current != null)
                {
                    frameConfigContabil.afterNovo();
                    TRegistro_LanPatrimonio reg_ProcPatrimonio = BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio;
                    (frameConfigContabil.BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio).ID_Patrimonio = reg_ProcPatrimonio.ID_Patrimonio;
                    (frameConfigContabil.BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio).ID_GrupoPatrim = reg_ProcPatrimonio.ID_GrupoPatrim;
                    if (reg_ProcPatrimonio.CD_ContaCre > 0)
                        (frameConfigContabil.BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio).CD_Conta_CTB_CRED_String = reg_ProcPatrimonio.CD_ContaCre.ToString();
                    if (reg_ProcPatrimonio.CD_ContaDeb > 0)
                        (frameConfigContabil.BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio).CD_Conta_CTB_DEB_String = reg_ProcPatrimonio.CD_ContaDeb.ToString();
                    if (reg_ProcPatrimonio.TP_Lancto == "D")
                    {
                        frameConfigContabil.rbDeteriorizacao.Checked = true;
                    }
                    else if (reg_ProcPatrimonio.TP_Lancto == "P")
                    {
                        frameConfigContabil.rbPerca.Checked = true;
                    }
                    else if (reg_ProcPatrimonio.TP_Lancto == "V")
                    {
                        frameConfigContabil.rbVenda.Checked = true;
                    }
                    else
                    {
                        frameConfigContabil.rbRealivacao.Checked = true;
                    }

                    frameConfigContabil.BS_Patrimonio.ResetBindings(true);

                    frameConfigContabil.ID_Patrimonio_Leave(null, null);
                    frameConfigContabil.ID_GrupoPatrim_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_CRED_Patrimonio_Leave(null, null);
                    frameConfigContabil.CD_CONTA_CTB_DEB_Patrimonio_Leave(null, null);
                }
            }
        }
        */
        public override void afterGrava()
        {
            if (tabControl.SelectedTab.Equals(tabCaixaBancos))
                ProcessaCaixa();
            else if (tabControl.SelectedTab.Equals(tabFaturamento))
                ProcessaFaturamento();
            else if (tabControl.SelectedTab.Equals(tabChequeComp))
                ProcessaChequeCompensado();
            else if (tabControl.SelectedTab.Equals(tabFinanceiro))
                ProcessaFinanceiro();
            else if (tabControl.SelectedTab.Equals(tabProvisaoEstoque))
                ProcessaProvEstoque();
            else if (tabControl.SelectedTab.Equals(tabPatrimonio))
                ProcessaPatrimonio();
        }
        
        #region "FILTROS PRINCIPAIS"

            private void bb_empresa_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
                    , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
                    "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
            }

            private void cd_empresa_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
                            , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
            }

        #endregion

        #region "FILTROS AÇOES TAB CAIXA"

            private void MarcarDesmarcarTodosRegCaixa()
            {
                if (BS_ProcCaixa.Count > 0)
                {
                    (BS_ProcCaixa.DataSource as List<TRegistro_Lan_ProcCaixa>).ForEach(p =>
                        {
                            if ((p.Cd_contacrestr.Trim() != string.Empty) &&
                                (p.Cd_contadebstr.Trim() != string.Empty))
                                p.St_processar = cbMarcaCaixa.Checked;
                        });
                    BS_ProcCaixa.ResetBindings(true);
                }
            }

            public void ProcessaCaixa()
            {
                if (BS_ProcCaixa.Count > 0)
                {
                    if (!(BS_ProcCaixa.DataSource as List<TRegistro_Lan_ProcCaixa>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro CAIXA para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_Caixa(
                            (BS_ProcCaixa.DataSource as List<TRegistro_Lan_ProcCaixa>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil CAIXA concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros CAIXA para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcCaixa()
            {
                List<TRegistro_Lan_ProcCaixa> lista = new List<TRegistro_Lan_ProcCaixa>();

                //lista = TCN_Lan_ProcContabil.BuscaProc_Caixa(cd_empresa.Text,
                //                                             CD_ContaGer.Text.Equals("") ? 0 : Convert.ToDecimal(CD_ContaGer.Text),
                //                                             0,
                //                                             DT_Inicial.Text,
                //                                             DT_Final.Text,
                //                                             cb_ReprocessarMovto.Checked,
                //                                             CD_LoteCTB.Text.Equals("") ? 0 : Convert.ToDecimal(CD_LoteCTB.Text),
                //                                             Valor.Value,
                //                                             Docto.Text,
                //                                             cd_clifor.Text,
                //                                             rb_Pagar.Checked ? "P" : rb_Receber.Checked ? "R" : "",
                //                                             cd_historico_caixa.Text);

                BS_ProcCaixa.DataSource = lista;
                BS_ProcCaixa_PositionChanged(this, new EventArgs());
            }

            public void BuscaClassificacaoCaixa()
            {
                if (BS_ProcCaixa.Current != null)
                {
                    if ((BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaCre > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaCre.ToString() + "'";
                        CD_CRE.Text = (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaCre.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }
                    else
                    {
                        CD_CRE.Text = "";
                        DS_CRE.Text = "";
                    }

                    if ((BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaDeb > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaDeb.ToString() + "'";
                        CD_DEB.Text = (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaDeb.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                    else
                    {
                        CD_DEB.Text = "";
                        DS_DEB.Text = "";
                    }
                }
            }

            private void bb_clifor_Click(object sender, EventArgs e)
            {
                string vParamFixo = "";
                UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, vParamFixo);
            }

            private void cd_clifor_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            }

            private void bb_ContaGer_Click(object sender, EventArgs e)
            {
                string vCond = "";
                if (cd_empresa.Text != "")
                    vCond = "|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_empresa.Text.Trim() + "' )|";

                string vColunas = "a.ds_contager|Conta|350;" +
                                  "a.CD_ContaGer|Cód. Conta|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaGer },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
            }

            private void CD_ContaGer_Enter(object sender, EventArgs e)
            {
                string vCond = "CD_ContaGer|=|'" + CD_ContaGer.Text + "'";
                if (cd_empresa.Text != "")
                    vCond += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_empresa.Text + "')|";

                UtilPesquisa.EDIT_LEAVE(vCond, new Componentes.EditDefault[] { CD_ContaGer },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
            }

        #endregion

        #region "FILTROS AÇOES TAB FATURAMENTO"

            private void MarcarDesmarcarTodosRegFaturamento()
            {
                if (BS_ProcFaturamento.Count > 0)
                {
                    (BS_ProcFaturamento.DataSource as List<TRegistro_Lan_ProcFaturamento>).ForEach(p =>
                    {
                        if ((p.Cd_contacrestr.Trim() != string.Empty) &&
                            (p.Cd_contadebstr.Trim() != string.Empty))
                            p.St_processar = cbMarcaFaturamento.Checked;
                    });
                    BS_ProcFaturamento.ResetBindings(true);
                }
            }

            public void ProcessaFaturamento()
            {
                if (BS_ProcFaturamento.Count > 0)
                {
                    if (!(BS_ProcFaturamento.DataSource as List<TRegistro_Lan_ProcFaturamento>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro FATURAMENTO para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_Faturamento(
                            (BS_ProcFaturamento.DataSource as List<TRegistro_Lan_ProcFaturamento>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil FATURAMENTO concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros FATURAMENTO para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcFaturamento()
            {
                List<TRegistro_Lan_ProcFaturamento> lista = new List<TRegistro_Lan_ProcFaturamento>();
                BS_ProcFaturamento.DataSource = lista;
            }

            public void BuscaClassificacaoFaturamento()
            {
                if (BS_ProcFaturamento.Current != null)
                {
                    if ((BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaCre > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaCre.ToString() + "'";
                        CD_CRE.Text = (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaCre.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }

                    if ((BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaDeb > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaDeb.ToString() + "'";
                        CD_DEB.Text = (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_ContaDeb.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                }
            }

            private void bb_CliforFAT_Click(object sender, EventArgs e)
            {
                string vParamFixo = "";
                UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CliforFat }, vParamFixo);
            }

            private void CD_CliforFat_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + CD_CliforFat.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CliforFat },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            }

            private void bb_ProdutoFAT_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto },"");
            }

            private void CD_Produto_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Produto },
                                        new TCD_CadProduto());
            }

            private void bb_Movto_Click(object sender, EventArgs e)
            {
                string vColunas = "a.DS_Movimentacao|Movimentação Comercial|350;" +
                              "a.CD_Movimentacao|Cód. Movimentação|100";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movto },
                                        new CamadaDados.Fiscal.TCD_CadMovimentacao(), "");
            }

            private void CD_Movto_Leave(object sender, EventArgs e)
            {
                if (CD_Movto.Text.Trim() != "")
                {
                    string vColunas = "a." + CD_Movto.NM_CampoBusca + "|=|'" + CD_Movto.Text + "'";
                    UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Movto },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao());
                }
            }

        #endregion

        #region "FILTROS AÇOES TAB CHEQUE"

            private void MarcarDesmarcarTodosRegCh()
            {
                if (BS_ProcChequeCompensado.Count > 0)
                {
                    (BS_ProcChequeCompensado.DataSource as List<TRegistro_Lan_ProcChequeCompensado>).ForEach(p =>
                    {
                        if ((p.Cd_contacredstr.Trim() != string.Empty) &&
                            (p.Cd_contadebstr.Trim() != string.Empty))
                            p.St_processar = cbMarcaCh.Checked;
                    });
                    BS_ProcChequeCompensado.ResetBindings(true);
                }
            }

            public void ProcessaChequeCompensado()
            {
                if (BS_ProcChequeCompensado.Count > 0)
                {
                    if (!(BS_ProcChequeCompensado.DataSource as List<TRegistro_Lan_ProcChequeCompensado>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro cheques compensados para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_ChequeCompensado(
                            (BS_ProcChequeCompensado.DataSource as List<TRegistro_Lan_ProcChequeCompensado>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil dos Cheques Compensados concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros cheques compensados para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcChequeCompensado()
            {
                List<TRegistro_Lan_ProcChequeCompensado> lista = new List<TRegistro_Lan_ProcChequeCompensado>();

                lista = TCN_Lan_ProcContabil.BuscaProc_ChequeCompensado(cd_empresa.Text,
                                                                                DT_Inicial.Text,
                                                                                DT_Final.Text,
                                                                                cb_ReprocessarMovto.Checked,
                                                                                CD_LoteCTB.Text.Equals("") ? 0 : Convert.ToDecimal(CD_LoteCTB.Text),
                                                                                CD_ContaCre_Cheque.Text,
                                                                                CD_ContaDeb_Cheque.Text,
                                                                                Nr_DocCheque.Text.Equals("") ? 0 : Convert.ToDecimal(Nr_DocCheque.Text),
                                                                                Nr_ChequeCH.Text,
                                                                                ComplementoCheque.Text,
                                                                                ValorCheque.Value);

                BS_ProcChequeCompensado.DataSource = lista;
                BS_ProcChequeCompensado_PositionChanged(this, new EventArgs());
            }

            public void BuscaClassificacaoChequeComp()
            {
                if (BS_ProcChequeCompensado.Current != null)
                {
                    if ((BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contacred != null)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contacred.Value.ToString() + "'";
                        CD_CRE.Text = (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contacred.Value.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }

                    if ((BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contadeb != null)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contadeb.Value.ToString() + "'";
                        CD_DEB.Text = (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contadeb.Value.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                }
            }

            private void bb_ContaDeb_Cheque_Click(object sender, EventArgs e)
            {
                string vColunas = "A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaDeb_Cheque },
                                        new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), "a.st_Registro|=|'A';a.TP_Conta|=|'A' ");
            }

            private void bb_ContaCre_Cheque_Click(object sender, EventArgs e)
            {
                string vColunas = "A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Crédito|150";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_ContaCre_Cheque },
                                        new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), "a.st_Registro|=|'A';a.TP_Conta|=|'A' ");
            }

            private void CD_ContaDeb_Cheque_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_ContaDeb_Cheque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' ",
                                        new Componentes.EditDefault[] { CD_ContaDeb_Cheque }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
            }

            private void CD_ContaCre_Cheque_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_ContaCre_Cheque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' ",
                                        new Componentes.EditDefault[] { CD_ContaCre_Cheque }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
            }

        #endregion

        #region "FILTROS AÇOES TAB FINANCEIRO"

            private void MarcarDesmarcarTodosRegFinanceiro()
            {
                if (BS_ProcFinanceiro.Count > 0)
                {
                    (BS_ProcFinanceiro.DataSource as List<TRegistro_Lan_ProcFinanceiro>).ForEach(p =>
                    {
                        if ((p.Cd_contacrestr.Trim() != string.Empty) &&
                            (p.Cd_contadebstr.Trim() != string.Empty))
                            p.St_processar = cbMarcaFinanceiro.Checked;
                    });
                    BS_ProcFinanceiro.ResetBindings(true);
                }
            }

            public void ProcessaFinanceiro()
            {
                if (BS_ProcFinanceiro.Count > 0)
                {
                    if (!(BS_ProcFinanceiro.DataSource as List<TRegistro_Lan_ProcFinanceiro>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro financeiro para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_Financeiro(
                            (BS_ProcFinanceiro.DataSource as List<TRegistro_Lan_ProcFinanceiro>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil do Financeiro Avulso concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros financeiros para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcFinanceiro()
            {
                //List<TRegistro_Lan_ProcFinanceiro> lista = new List<TRegistro_Lan_ProcFinanceiro>();

                //lista = TCN_Lan_ProcContabil.BuscaProc_Financeiro(cd_empresa.Text,
                //                                                  DT_Inicial.Text,
                //                                                  DT_Final.Text,
                //                                                  Nr_DoctoFin.Text.Equals("") ? 0 : Convert.ToDecimal(Nr_DoctoFin.Text),
                //                                                  CD_CliforFin.Text,
                //                                                  CD_HitoricoFin.Text,
                //                                                  CD_LoteCTB.Text.Equals("") ? 0 : Convert.ToDecimal(CD_LoteCTB.Text),
                //                                                  cb_ReprocessarMovto.Checked,
                //                                                  rb_PagarFin.Checked ? "P" : rb_ReceberFin.Checked ? "R" : "",
                //                                                  ValorCheque.Value);

                //BS_ProcFinanceiro.DataSource = lista;
                //BS_ProcFinanceiro_PositionChanged(this, new EventArgs());
            }

            public void BuscaClassificacaoFinanceiro()
            {
                if (BS_ProcFinanceiro.Current != null)
                {
                    if ((BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaCre > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaCre.ToString() + "'";
                        CD_CRE.Text = (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaCre.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }

                    if ((BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaDeb > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaDeb.ToString() + "'";
                        CD_DEB.Text = (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_ContaDeb.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                }
            }

            private void bb_CliforFin_Click(object sender, EventArgs e)
            {
                string vParamFixo = "";
                UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_CliforFin, NM_CliforFin }, vParamFixo);
            }

            private void CD_CliforFin_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_Clifor|=|'" + cd_clifor.Text + "'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CliforFin, NM_CliforFin },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            }

            private void bb_HistoricoFin_Click(object sender, EventArgs e)
            {
                string vColunas = "a.ds_Historico|Historico|350;" +
                              "a.CD_Historico|Cód. Historico|100";
                string vParamFixo = "(isNull(d.ST_CaixaGerencial,'N') = 'S')||;";
                if (rb_PagarFin.Checked)
                    vParamFixo += "a.TP_Mov|=|'P'";
                else if (rb_ReceberFin.Checked)
                    vParamFixo += "a.TP_Mov|=|'R'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_HitoricoFin, DS_HistoricoFin },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
            }

            private void CD_HitoricoFin_Leave(object sender, EventArgs e)
            {
                string vColunas = "a.CD_HISTORICO|=|'" + CD_HitoricoFin.Text + "';" +
                              "(isNull(d.ST_CaixaGerencial,'N') = 'S')||;";
                if (rb_PagarFin.Checked)
                    vColunas += "a.TP_Mov|=|'P'";
                else if (rb_ReceberFin.Checked)
                    vColunas += "a.TP_Mov|=|'R'";
                UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_HitoricoFin, DS_HistoricoFin },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
            }

        #endregion

        #region "FILTROS AÇOES TAB PROVESTOQUE"

            private void MarcarDesmarcarTodosRegProvEst()
            {
                if (BS_ProcProvEstoque.Count > 0)
                {
                    (BS_ProcProvEstoque.DataSource as List<TRegistro_Lan_ProcProvEstoque>).ForEach(p =>
                    {
                        if ((p.Cd_contacrestr.Trim() != string.Empty) &&
                            (p.Cd_contadebstr.Trim() != string.Empty))
                            p.St_processar = cbMarcaProvEst.Checked;
                    });
                    BS_ProcProvEstoque.ResetBindings(true);
                }
            }

            public void ProcessaProvEstoque()
            {
                if (BS_ProcProvEstoque.Count > 0)
                {
                    if (!(BS_ProcProvEstoque.DataSource as List<TRegistro_Lan_ProcProvEstoque>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro provisão estoque para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_ProvEstoque(
                            (BS_ProcProvEstoque.DataSource as List<TRegistro_Lan_ProcProvEstoque>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil de Provisão Estoque concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros provisão estoque para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcProvEstoque()
            {
                List<TRegistro_Lan_ProcProvEstoque> lista = new List<TRegistro_Lan_ProcProvEstoque>();

                lista = TCN_Lan_ProcContabil.BuscaProc_ProvEstoque(cd_empresa.Text,
                                                                  DT_Inicial.Text,
                                                                  DT_Final.Text,
                                                                  CD_LoteCTB.Text.Equals("") ? 0 : Convert.ToDecimal(CD_LoteCTB.Text),
                                                                  cb_ReprocessarMovto.Checked);

                BS_ProcProvEstoque.DataSource = lista;
            }

            public void BuscaClassificacaoProvEstoque()
            {
                if (BS_ProcProvEstoque.Current != null)
                {
                    if ((BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaCre > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaCre.ToString() + "'";
                        CD_CRE.Text = (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaCre.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }

                    if ((BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaDeb > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaDeb.ToString() + "'";
                        CD_DEB.Text = (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_ContaDeb.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                }
            }

        #endregion

        #region "FILTROS AÇOES TAB PATRIMONIO"

            private void MarcarDesmarcarTodosRegPatrimonio()
            {
                if (BS_ProcPatrimonio.Count > 0)
                {
                    (BS_ProcPatrimonio.DataSource as List<TRegistro_LanPatrimonio>).ForEach(p =>
                    {
                        if ((p.Cd_contacrestr.Trim() != string.Empty) &&
                            (p.Cd_contadebstr.Trim() != string.Empty))
                            p.St_processar = cbMarcaPatrimonio.Checked;
                    });
                    BS_ProcPatrimonio.ResetBindings(true);
                }
            }

            public void ProcessaPatrimonio()
            {
                if (BS_ProcPatrimonio.Count > 0)
                {
                    if (!(BS_ProcPatrimonio.DataSource as List<TRegistro_LanPatrimonio>).Exists(p => p.St_processar))
                    {
                        MessageBox.Show("Obrigatorio selecionar registro PATRIMONIO para processar contabilidade.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanContabil.ProcessaCTB_Patrimonio(
                            (BS_ProcPatrimonio.DataSource as List<TRegistro_LanPatrimonio>).FindAll(p => p.St_processar), null);
                        MessageBox.Show("Processamento Contábil PATRIMONIO concluido com sucesso.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Não existe registros PATRIMONIO para processar contabilidade.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void BuscaProcPatrimonio()
            {
                List<TRegistro_LanPatrimonio> lista = new List<TRegistro_LanPatrimonio>();

                lista = TCN_LanPatrimonio.Busca("", "", cd_empresa.Text,
                                                DT_Inicial.Text,
                                                DT_Final.Text,
                                                true,
                                                cb_ReprocessarMovto.Checked,
                                                CD_LoteCTB.Text.Equals("") ? 0 : Convert.ToDecimal(CD_LoteCTB.Text),
                                                rb_Detoriazacao.Checked ? "D" : rb_PercaDepre.Checked ? "P" : rb_Venda.Checked ? "V" : rb_Reavaliacao.Checked ? "R" : "");

                BS_ProcPatrimonio.DataSource = lista;
            }

            public void BuscaClassificacaoPatrimonio()
            {
                if (BS_ProcPatrimonio.Current != null)
                {
                    if ((BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaCre > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaCre.ToString() + "'";
                        CD_CRE.Text = (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaCre.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CRE, DS_CRE },
                                                new TCD_CadPlanoContas());
                    }

                    if ((BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaDeb > 0)
                    {
                        string vColunas = "a.cd_conta_CTB|=|'" + (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaDeb.ToString() + "'";
                        CD_DEB.Text = (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_ContaDeb.ToString();
                        UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_DEB, DS_DEB },
                                                new TCD_CadPlanoContas());
                    }
                }
            }

        #endregion

        private void grid_ProcFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcFinanceiro.Current != null))
            {
                if (!(BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).St_processar)
                {
                    if ((BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).Cd_contacrestr.Trim().Equals(string.Empty) &&
                        (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Tipo Duplicata: " + (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).TP_Duplicata.Trim() + "\r\n" +
                                        "Historico: " + (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).CD_Historico.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).St_processar = true;
                }
                else
                    (BS_ProcFinanceiro.Current as TRegistro_Lan_ProcFinanceiro).St_processar = false;
                BS_ProcFinanceiro.ResetCurrentItem();
            }
        }

        private void BS_ProcFinanceiro_PositionChanged(object sender, EventArgs e)
        {
            BuscaClassificacaoFinanceiro();
        }

        private void grid_ProcChequeCompensado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcChequeCompensado.Current != null))
            {
                if (!(BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).St_processar)
                {
                    if ((BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contacredstr.Trim().Equals(string.Empty) &&
                        (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Conta Ger. Entrada: " + (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).CD_ContaGerOrig.Trim() + "\r\n" +
                                        "Conta Ger. Saida: " + (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).CD_ContaGerDest.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).St_processar = true;
                }
                else
                    (BS_ProcChequeCompensado.Current as TRegistro_Lan_ProcChequeCompensado).St_processar = false;
                BS_ProcChequeCompensado.ResetCurrentItem();
            }
        }

        private void BS_ProcChequeCompensado_PositionChanged(object sender, EventArgs e)
        {
            BuscaClassificacaoChequeComp();
        }

        private void BS_ProcCaixa_PositionChanged(object sender, EventArgs e)
        {
            BuscaClassificacaoCaixa();
        }

        private void grid_ProcCaixa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcCaixa.Current != null))
            {
                if (!(BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).St_processar)
                {
                    if ((BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).Cd_contacrestr.Trim().Equals(string.Empty) &&
                        (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_Empresa.Trim() + "\r\n" +
                                        "Conta Gerencial: " + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_ContaGer.Trim() + "\r\n" +
                                        "Historico: " + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).CD_Historico.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).St_processar = true;
                }
                else
                    (BS_ProcCaixa.Current as TRegistro_Lan_ProcCaixa).St_processar = false;
                BS_ProcCaixa.ResetCurrentItem();
            }            
        }

        private void bb_historico_caixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Historico|Historico|350;" +
                              "a.CD_Historico|Cód. Historico|100";
            string vParam = "((isnull(d.st_caixagerencial, 'N') = 'S') or (isnull(d.st_quitacoes, 'N') = 'S'))||";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_caixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_caixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_caixa.Text.Trim() + "';" +
                            "((isnull(d.st_caixagerencial, 'N') = 'S') or (isnull(d.st_quitacoes, 'N') = 'S'))||";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_caixa },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void grid_ProcFaturamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcFaturamento.Current != null))
            {
                if (!(BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).St_processar)
                {
                    if ((BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).Cd_contacrestr.Trim().Equals(string.Empty) &&
                        (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).CD_Empresa.Trim() + "\r\n" +
                                        "Movimentação: " + (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).Cd_movtostr.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).St_processar = true;
                }
                else
                    (BS_ProcFaturamento.Current as TRegistro_Lan_ProcFaturamento).St_processar = false;
                BS_ProcFaturamento.ResetCurrentItem();
            }
        }

        private void BS_ProcFaturamento_PositionChanged(object sender, EventArgs e)
        {
            BuscaClassificacaoFaturamento();
        }

        private void cbMarcaCaixa_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegCaixa();
        }

        private void cbMarcaFaturamento_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegFaturamento();
        }

        private void cbMarcaCh_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegCh();
        }

        private void cbMarcaFinanceiro_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegFinanceiro();
        }

        private void cbMarcaProvEst_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegProvEst();
        }

        private void grid_ProcProvEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcProvEstoque.Current != null))
            {
                if (!(BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).St_processar)
                {
                    if ((BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).Cd_contacrestr.Trim().Equals(string.Empty) &&
                        (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Produto: " + (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).CD_Produto.Trim() + "\r\n" +
                                        "Tipo Movimento: " + (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).TP_Movimento.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).St_processar = true;
                }
                else
                    (BS_ProcProvEstoque.Current as TRegistro_Lan_ProcProvEstoque).St_processar = false;
                BS_ProcProvEstoque.ResetCurrentItem();
            }
        }

        private void cbMarcaPatrimonio_Click(object sender, EventArgs e)
        {
            this.MarcarDesmarcarTodosRegPatrimonio();
        }

        private void grid_ProcPatrimonio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (BS_ProcPatrimonio.Current != null))
            {
                if (!(BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).St_processar)
                {
                    if ((BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).Cd_contacrestr.Trim().Equals(string.Empty) &&
                        (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).Cd_contadebstr.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Não existe configuração para contabilizar o registro.\r\n" +
                                        "Empresa: " + (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).CD_Empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).St_processar = true;
                }
                else
                    (BS_ProcPatrimonio.Current as TRegistro_LanPatrimonio).St_processar = false;
                BS_ProcPatrimonio.ResetCurrentItem();
            }
        }

        private void TFProcessa_Contabil_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_ProcCaixa);
            Utils.ShapeGrid.RestoreShape(this, grid_ProcChequeCompensado);
            Utils.ShapeGrid.RestoreShape(this, grid_ProcFaturamento);
            Utils.ShapeGrid.RestoreShape(this, grid_ProcFinanceiro);
            Utils.ShapeGrid.RestoreShape(this, grid_ProcPatrimonio);
            Utils.ShapeGrid.RestoreShape(this, grid_ProcProvEstoque);
            Utils.ShapeGrid.RestoreShape(this, gridImpostos);
            pDadosFiltroCaixa.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            rg_TPMovtoCaixa.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pDadosFiltroFAT.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            rg_TPMovtoFAT.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pDadosFiltroCH.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            rg_TPMovtoFin.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pDadosFiltroFIN.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados3.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            rg_TPPatrim.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);

            tabControl.TabPages.Remove(tabCmv);
            tabControl.TabPages.Remove(tabPatrimonio);
        }

        private void TFProcessa_Contabil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_ProcCaixa);
            Utils.ShapeGrid.SaveShape(this, grid_ProcChequeCompensado);
            Utils.ShapeGrid.SaveShape(this, grid_ProcFaturamento);
            Utils.ShapeGrid.SaveShape(this, grid_ProcFinanceiro);
            Utils.ShapeGrid.SaveShape(this, grid_ProcPatrimonio);
            Utils.ShapeGrid.SaveShape(this, grid_ProcProvEstoque);
            Utils.ShapeGrid.SaveShape(this, gridImpostos);
        }
    }
}
