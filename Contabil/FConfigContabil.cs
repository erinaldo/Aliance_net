using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using Utils;
using FormBusca;
using FormCadPadrao;

namespace Contabil
{
    public partial class TFConfigContabil : FFormCadPadrao
    {
        public TFConfigContabil()
        {
            InitializeComponent();
            DTS = BS_Financeiro;


            Array.Resize(ref vPanel, tcCentral.TabCount);
            vIndexPanel = 0;
            base.vPanel[1] = pFaturamento;
            base.vPanel[2] = pCfgImpostos;
            base.vPanel[3] = pCfgCMV;
            base.vPanel[4] = pCaixas;
            base.vPanel[5] = pCheque;
            base.vPanel[6] = pProvisaoEstoque;
            base.vPanel[7] = pPatrimonio;

            pDados.set_FormatZero();
            pFaturamento.set_FormatZero();
            pCfgImpostos.set_FormatZero();
            pCfgCMV.set_FormatZero();
            pCaixas.set_FormatZero();
            pCheque.set_FormatZero();
            pProvisaoEstoque.set_FormatZero();
            pPatrimonio.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
            pFaturamento.HabilitarControls(value, this.vTP_Modo);
            pCfgImpostos.HabilitarControls(value, this.vTP_Modo);
            pCfgCMV.HabilitarControls(value, this.vTP_Modo);
            pCaixas.HabilitarControls(value, this.vTP_Modo);
            pCheque.HabilitarControls(value, this.vTP_Modo);
            pPatrimonio.HabilitarControls(value, this.vTP_Modo);
            pProvisaoEstoque.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterNovo()
        {
            vTP_Modo = TTpModo.tm_Insert;
            RemoveTabControl();
            habilitarControls(true);
            this.modoBotoes(true, false, true, false, true, true, false);

            if (tcCentral.SelectedTab != null)
            {
                if (tcCentral.SelectedTab.Equals(tpPadrao))
                {
                    BS_Financeiro.Clear();
                    BS_Financeiro.AddNew();
                    TP_Duplicata_Financeiro.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabImpostos))
                {
                    bsImpostosFat.Clear();
                    bsImpostosFat.AddNew();
                    cd_mov_imposto.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabCMV))
                {
                    bsCMV.Clear();
                    bsCMV.AddNew();
                    cd_mov_cmv.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabCaixa))
                {
                    BS_Caixa.Clear();
                    BS_Caixa.AddNew();
                    CD_Empresa_Caixa.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabCheque))
                {
                    BS_Cheque.Clear();
                    BS_Cheque.AddNew();
                    CD_ContaGer_Entrada_Cheque.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabFaturamento))
                {
                    BS_Faturamento.Clear();
                    BS_Faturamento.AddNew();
                    CD_Empresa.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabPatrimonio))
                {
                    BS_Patrimonio.Clear();
                    BS_Patrimonio.AddNew();
                    ID_Patrimonio.Focus();
                }
                else if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
                {
                    BS_Provisao.Clear();
                    BS_Provisao.AddNew();
                    CD_Produto_Estoque.Focus();
                }
            }
        }

        public override void afterCancela()
        {
            int TB_Atual = 0;
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                BS_Financeiro.Clear();
                TB_Atual = 0;
               
            }

            if (tcCentral.SelectedTab.Equals(tabFaturamento))
            {
                BS_Faturamento.Clear();
                TB_Atual = 1;

            }

            if (tcCentral.SelectedTab.Equals(tabImpostos))
            {
                bsImpostosFat.Clear();
                TB_Atual = 2;
            }

            if (tcCentral.SelectedTab.Equals(tabCMV))
            {
                bsCMV.Clear();
                TB_Atual = 3;
            }

            if (tcCentral.SelectedTab.Equals(tabCaixa))
            {
                BS_Caixa.Clear();
                TB_Atual = 4;

            }

            if (tcCentral.SelectedTab.Equals(tabCheque))
            {
                BS_Cheque.Clear();
                TB_Atual = 5;

            }
                        
            if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
            {
                BS_Provisao.Clear();
                TB_Atual = 6;

            }

            if (tcCentral.SelectedTab.Equals(tabPatrimonio))
            {
                BS_Patrimonio.Clear();
                TB_Atual = 7;
            }
                        

            vTP_Modo = TTpModo.tm_Standby;
            RemoveTabControl();
            habilitarControls(false);
            this.modoBotoes(true, false, false, false, false, true, false);
            tcCentral.SelectedIndex = TB_Atual;
            
        }

        public override void afterAltera()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                if (BS_Financeiro.Current != null)
                {
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }


            if (tcCentral.SelectedTab.Equals(tabCaixa))
            {
                TList_CTB_CFGCaixa Lista_Caixa = TCN_CTB_CFGCaixa.Busca(string.Empty);

                if ((Lista_Caixa != null) && (Lista_Caixa.Count > 0))
                {
                    BS_Caixa.Clear();
                    BS_Caixa.DataSource = Lista_Caixa;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabFaturamento))
            {
                TList_CTB_CFGFaturamento Lista_Faturamento = TCN_CTB_CFGFaturamento.Busca(string.Empty);

                if ((Lista_Faturamento != null) && (Lista_Faturamento.Count > 0))
                {
                    BS_Faturamento.Clear();
                    BS_Faturamento.DataSource = Lista_Faturamento;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabImpostos))
            {
                TList_CFGImpostoFaturamento Lista_Impostos = TCN_CFGImpostoFaturamento.Buscar(string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                if (Lista_Impostos.Count > 0)
                {
                    bsImpostosFat.Clear();
                    bsImpostosFat.DataSource = Lista_Impostos;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabCMV))
            {
                TList_CFGCMV Lista_CMV = TCN_CFGCMV.Buscar(string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           null);
                if (Lista_CMV.Count > 0)
                {
                    bsCMV.Clear();
                    bsCMV.DataSource = Lista_CMV;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
            {
                TList_CTB_CFGProvisao_Estoque Lista_Provisao = TCN_CTB_CFGProvisao_Estoque.Busca(string.Empty);

                if ((Lista_Provisao != null) && (Lista_Provisao.Count > 0))
                {
                    BS_Provisao.Clear();
                    BS_Provisao.DataSource = Lista_Provisao;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabPatrimonio))
            {
                TList_CTB_CFGPatrimonio Lista_Patrimonio = TCN_CTB_CFGPatrimonio.Busca(string.Empty);

                if ((Lista_Patrimonio != null) && (Lista_Patrimonio.Count > 0))
                {
                    BS_Patrimonio.Clear();
                    BS_Patrimonio.DataSource = Lista_Patrimonio;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabCheque))
            {
                TList_CTB_CFGCheque_Compensado Lista_Cheque = TCN_CTB_CFGChequeCompensado.Busca(string.Empty);

                if ((Lista_Cheque != null) && (Lista_Cheque.Count > 0))
                {
                    BS_Cheque.Clear();
                    BS_Cheque.DataSource = Lista_Cheque;
                    this.vTP_Modo = TTpModo.tm_Edit;
                    RemoveTabControl();
                    habilitarControls(true);
                    this.modoBotoes(false, false, true, false, true, false, false);
                }
            }
            
        }
        
        public override void afterExclui()
        {
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                try
                {
                    if (BS_Financeiro.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil do Financeiro?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==   
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGFinanceiro.Deleta_CTB_CFGFinanceiro(BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabCaixa))
            {
                try
                {
                    if (BS_Caixa.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil do Caixa?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGCaixa.Deleta_CTB_CFGCaixa(BS_Caixa.Current as TRegistro_CTB_CFGCaixa, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

            }

            if (tcCentral.SelectedTab.Equals(tabCheque))
            {
                try
                {
                    if (BS_Cheque.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil do Cheque?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGChequeCompensado.Deleta_CTB_CFGCheque_Compensado(BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

            }

            if (tcCentral.SelectedTab.Equals(tabFaturamento))
            {
                try
                {
                    if (BS_Faturamento.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil do Faturamento?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGFaturamento.Deleta_CTB_CFGFaturamento(BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabImpostos))
            {
                try
                {
                    if (bsImpostosFat.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil dos Impostos?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CFGImpostoFaturamento.Excluir(bsImpostosFat.Current as TRegistro_CFGImpostoFaturamento, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabCMV))
            {
                try
                {
                    if (bsCMV.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil CMV?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CFGCMV.Excluir(bsCMV.Current as TRegistro_CFGCMV, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            if (tcCentral.SelectedTab.Equals(tabPatrimonio))
            {
                try
                {
                    if (BS_Patrimonio.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil do Patrimônio?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGPatrimonio.Deleta_CTB_CFGPatrimonio(BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

           
            if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
            {
                try
                {
                    if (BS_Provisao.Count > 0)
                    {
                        if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                        {
                            if (MessageBox.Show("Confirma Exclusão da Configuração Contábil da Provisão de Estoque?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                            {
                                TCN_CTB_CFGProvisao_Estoque.Deleta_CTB_CFGProvisao_Estoque(BS_Provisao.Current as TRegistro_CTB_CFGProvisao_Estoque, null);
                                MessageBox.Show("Configuração Contábil excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                afterCancela();
                            }
                        }
                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Excluir Configuração: \r\n " + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

           
            
            

        }

        public override int buscarRegistros()
        {
            
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                TList_CTB_CFGFinanceiro Lista_Financeiro = TCN_CTB_CFGFinanceiro.Busca(string.Empty,
                                                                                       TP_Duplicata_Financeiro.Text,
                                                                                       CD_Historico_Financeiro.Text,
                                                                                       CD_Clifor_Financeiro.Text,
                                                                                       CD_CONTA_CTB_DEB_Financeiro.Text,
                                                                                       CD_CONTA_CTB_CRED_Financeiro.Text,
                                                                                       null);
                if ((Lista_Financeiro != null) && (Lista_Financeiro.Count > 0))
                {
                    BS_Financeiro.DataSource = Lista_Financeiro;
                    AddTabControl();
                    tcCentral.SelectedTab = tpPadrao;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                    if (this.vTP_Modo != TTpModo.tm_Edit)
                        afterCancela();
             }

            if (tcCentral.SelectedTab.Equals(tabCaixa))
            {
                TList_CTB_CFGCaixa Lista_Caixa = TCN_CTB_CFGCaixa.Busca(string.Empty);

                if ((Lista_Caixa != null) && (Lista_Caixa.Count > 0))
                {
                    BS_Caixa.DataSource = Lista_Caixa;
                    AddTabControl();
                    tcCentral.SelectedTab = tabCaixa;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                {
                    
                    afterCancela();
                }

            }

            if (tcCentral.SelectedTab.Equals(tabFaturamento))
            {
                TList_CTB_CFGFaturamento Lista_Faturamento = TCN_CTB_CFGFaturamento.Busca(string.Empty);

                if ((Lista_Faturamento != null) && (Lista_Faturamento.Count > 0))
                {
                    BS_Faturamento.DataSource = Lista_Faturamento;
                    AddTabControl();
                    tcCentral.SelectedTab = tabFaturamento;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                {
                    
                    afterCancela();
                }

            }

            if (tcCentral.SelectedTab.Equals(tabImpostos))
            {
                TList_CFGImpostoFaturamento Lista_Impostos = TCN_CFGImpostoFaturamento.Buscar(string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                if (Lista_Impostos.Count > 0)
                {
                    bsImpostosFat.DataSource = Lista_Impostos;
                    AddTabControl();
                    tcCentral.SelectedTab = tabImpostos;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                    afterCancela();
            }

            if (tcCentral.SelectedTab.Equals(tabCMV))
            {
                TList_CFGCMV Lista_CMV = TCN_CFGCMV.Buscar(string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           null);
                if (Lista_CMV.Count > 0)
                {
                    bsCMV.DataSource = Lista_CMV;
                    AddTabControl();
                    tcCentral.SelectedTab = tabCMV;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                    afterCancela();
            }

            if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
            {
                TList_CTB_CFGProvisao_Estoque Lista_ProvisaoEstoque = TCN_CTB_CFGProvisao_Estoque.Busca(string.Empty);

                if ((Lista_ProvisaoEstoque != null) && (Lista_ProvisaoEstoque.Count > 0))
                {
                    BS_Provisao.DataSource = Lista_ProvisaoEstoque;
                    AddTabControl();
                    tcCentral.SelectedTab = tabProvisaoEstoque;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                {
                    
                    afterCancela();
                }

            }

            if (tcCentral.SelectedTab.Equals(tabCheque))
            {
                TList_CTB_CFGCheque_Compensado Lista_ChequeCompensado = TCN_CTB_CFGChequeCompensado.Busca(string.Empty);

                if ((Lista_ChequeCompensado != null) && (Lista_ChequeCompensado.Count > 0))
                {
                    BS_Cheque.DataSource = Lista_ChequeCompensado;
                    AddTabControl();
                    tcCentral.SelectedTab = tabCheque;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                {
                    
                    afterCancela();
                }

            }

            if (tcCentral.SelectedTab.Equals(tabPatrimonio))
            {
                TList_CTB_CFGPatrimonio Lista_Patrimonio = TCN_CTB_CFGPatrimonio.Busca(string.Empty);

                if ((Lista_Patrimonio != null) && (Lista_Patrimonio.Count > 0))
                {
                    BS_Patrimonio.DataSource = Lista_Patrimonio;
                    AddTabControl();
                    tcCentral.SelectedTab = tabPatrimonio;
                    this.modoBotoes(true, true, false, true, false, true, true);
                }
                else
                {
                 
                    afterCancela();
                }

            }

            return 0;
        }

        public override string gravarRegistro()
        {
            
            if (tcCentral.SelectedTab.Equals(tpPadrao))
            {
                try
                {
                    if (pDados.validarCampoObrigatorio())
                    {                        
                        TCN_CTB_CFGFinanceiro.Grava_CTB_CFGFinanceiro((BS_Financeiro.Current as TRegistro_CTB_CFGFinanceiro), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tpPadrao;
                        habilitarControls(false);
                        afterBusca();

                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil \r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }


            if (tcCentral.SelectedTab.Equals(tabCaixa))
            {
                try
                {
                    if (pCaixas.validarCampoObrigatorio())
                    {
                        
                        TCN_CTB_CFGCaixa.Grava_CTB_CFGCaixa((BS_Caixa.Current as TRegistro_CTB_CFGCaixa), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabCaixa;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }

            if (tcCentral.SelectedTab.Equals(tabFaturamento))
            {
                try
                {
                    if (pFaturamento.validarCampoObrigatorio())
                    {
                        TCN_CTB_CFGFaturamento.Grava_CTB_CFGFaturamento((BS_Faturamento.Current as TRegistro_CTB_CFGFaturamento), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabFaturamento;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }

            if (tcCentral.SelectedTab.Equals(tabImpostos))
            {
                try
                {
                    if (pCfgImpostos.validarCampoObrigatorio())
                    {
                        TCN_CFGImpostoFaturamento.Gravar((bsImpostosFat.Current as TRegistro_CFGImpostoFaturamento), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabImpostos;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return string.Empty;
            }

            if (tcCentral.SelectedTab.Equals(tabCMV))
            {
                try
                {
                    if (pCfgCMV.validarCampoObrigatorio())
                    {
                        TCN_CFGCMV.Gravar((bsCMV.Current as TRegistro_CFGCMV), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabCMV;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return string.Empty;
            }

            if (tcCentral.SelectedTab.Equals(tabCheque))
            {
                try
                {
                    if (pCheque.validarCampoObrigatorio())
                    {
                        TCN_CTB_CFGChequeCompensado.Grava_CTB_CFGCheque_Compensado((BS_Cheque.Current as TRegistro_CTB_CFGCheque_Compensado), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabCheque;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }


            if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
            {
                try
                {
                    if (pProvisaoEstoque.validarCampoObrigatorio())
                    {
                        
                        TCN_CTB_CFGProvisao_Estoque.Grava_CTB_CFGProvisao_Estoque((BS_Provisao.Current as TRegistro_CTB_CFGProvisao_Estoque), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabProvisaoEstoque;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }

            if (tcCentral.SelectedTab.Equals(tabPatrimonio))
            {
                try
                {
                    if (pPatrimonio.validarCampoObrigatorio())
                    {
                        
                        TCN_CTB_CFGPatrimonio.Grava_CTB_CFGPatrimonio((BS_Patrimonio.Current as TRegistro_CTB_CFGPatrimonio), null);
                        MessageBox.Show("Configuração Contábil gravada com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AddTabControl();
                        tcCentral.SelectedTab = tabPatrimonio;
                        habilitarControls(false);
                        afterBusca();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Erro ao gravar Configuração Contábil\r\n" + e.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                return "";
            }

            return "";

        }

        public override void afterPrint()
        {
            base.afterPrint();
        }

        public override void afterGrava()
        {
           gravarRegistro();
        }

        private void BTN_CONTA_CTB_DEB_Financeiro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Financeiro, DS_CONTA_CTB_DEB_Financeiro, CD_Classificacao_Deb_Financeiro },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_DEB_Caixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Caixa, DS_CONTA_CTB_DEB_Caixa, CD_Classificacao_Deb_Caixa },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_DEB_Cheque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Cheque, DS_CONTA_CTB_DEB_Cheque, CD_Classificacao_Deb_Cheque },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_DEB_Faturamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Faturamento, DS_CONTA_CTB_DEB_Faturamento, CD_Classificacao_Deb_Faturamento },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }
                    
        private void BTN_CONTA_CTB_DEB_Estoque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Estoque, DS_CONTA_CTB_DEB_Estoque, CD_Classificacao_Deb_Provisao },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_CRED_Financeiro_Click(object sender, EventArgs e)
        {
            string vColunas = "A.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Crédito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Financeiro, DS_CONTA_CTB_CRED_Financeiro, CD_Classificacao_Cred_Financeiro },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_CRED_Caixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Caixa, DS_CONTA_CTB_CRED_Caixa, CD_Classificacao_Cred_Caixa },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_CRED_Cheque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Cheque, DS_CONTA_CTB_CRED_Cheque, CD_Classificacao_Cred_Cheque },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_CONTA_CTB_CRED_Faturamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Faturamento, DS_CONTA_CTB_CRED_Faturamento, CD_Classificacao_Cred_Faturamento },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }
        
        private void BTN_CONTA_CTB_CRED_Estoque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Estoque, DS_CONTA_CTB_CRED_Estoque, CD_Classificacao_Cred_Provisao },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void BTN_ContaGer_Financeiro_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição Histórico|350;a.CD_Historico|Código|100",
            new Componentes.EditDefault[] { CD_Historico_Financeiro, DS_Historico_Financeiro }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void BTN_ContaGer_Caixa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição Conta Gerencial|350;a.CD_ContaGer|Código|100",
            new Componentes.EditDefault[] { CD_ContaGer_Caixa, DS_ContaGer_Caixa }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void BTN_ContaGer_Entrada_Cheque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { CD_ContaGer_Entrada_Cheque, DS_ContaGer_Entrada_Cheque }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void BTN_ContaGer_Saida_Cheque_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            UtilPesquisa.BTN_BUSCA(vColunas,
                                   new Componentes.EditDefault[] { CD_ContaGer_Saida_Cheque, DS_ContaGer_Saida_Cheque }, 
                                   new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void Btn_TP_Duplicata_Financeiro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_TPDuplicata|Descrição Tipo Duplicata|350;" +
                              "a.TP_Duplicata|TP. Duplicata|100;" +
                              "a.tp_mov|Tipo Movimento|80";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(tp_mov_historico_financeiro.Text))
                vParam = "a.tp_mov|=|'" + tp_mov_historico_financeiro.Text.Trim().ToUpper() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Duplicata_Financeiro, DS_TP_Duplicata_Financeiro, tp_mov_duplicata_financeiro }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void Btn_Clifor_Financeiro_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Financeiro, NM_Clifor_Financeiro }, string.Empty);
        }

        private void Btn_Clifor_Faturmento_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Faturamento, NM_Clifor_Faturamento }, string.Empty);
        }

        private void BTN_Empresa_Caixa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa_Caixa, NM_Empresa_Caixa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void Btn_Historico_Caixa_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_historico|Histórico|350;a.CD_Historico|Código|150";
            string vParam = "((isnull(d.st_caixagerencial, 'N') = 'S') or (isnull(d.st_quitacoes, 'N') = 'S'))||";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_Historico_Caixa, DS_Historico_Caixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void Btn_Movimentacao_Faturamento_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Movientacao_Faturamento, DS_Movimentacao_Faturamento },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }
        
        private void Btn_Produto_Faturamento_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_Faturamento, DS_Produto_Faturamento },"");
        }
        
        private void Btn_Produto_Estoque_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_Estoque, DS_Produto_Estoque },"");
        }
        
        public void CD_CONTA_CTB_DEB_Financeiro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_ctb|=|" + CD_CONTA_CTB_DEB_Financeiro.Text + ";" +
                            "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Financeiro, DS_CONTA_CTB_DEB_Financeiro, CD_Classificacao_Deb_Financeiro, CD_Classificacao_Deb_Financeiro }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_DEB_Caixa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_DEB_Caixa.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Caixa, DS_CONTA_CTB_DEB_Caixa, CD_Classificacao_Deb_Caixa }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());

            
        }

        public void CD_CONTA_CTB_DEB_Cheque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_DEB_Cheque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Cheque, DS_CONTA_CTB_DEB_Cheque, CD_Classificacao_Deb_Cheque }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_DEB_Faturamento_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_DEB_Faturamento.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Faturamento, DS_CONTA_CTB_DEB_Faturamento, CD_Classificacao_Deb_Faturamento }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_DEB_Estoque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_DEB_Estoque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Estoque, DS_CONTA_CTB_DEB_Estoque, CD_Classificacao_Deb_Provisao }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Financeiro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_ctb|=|" + CD_CONTA_CTB_CRED_Financeiro.Text + ";" +
                            "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Financeiro, DS_CONTA_CTB_CRED_Financeiro, CD_Classificacao_Cred_Financeiro }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Caixa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_CRED_Caixa.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Caixa, DS_CONTA_CTB_CRED_Caixa, CD_Classificacao_Cred_Caixa }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Cheque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_CRED_Cheque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Cheque, DS_CONTA_CTB_CRED_Cheque,CD_Classificacao_Cred_Cheque }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Faturamento_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_CRED_Faturamento.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Faturamento, DS_CONTA_CTB_CRED_Faturamento, CD_Classificacao_Cred_Faturamento }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Estoque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_CRED_Estoque.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Estoque, DS_CONTA_CTB_CRED_Estoque, CD_Classificacao_Cred_Provisao }, 
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_ContaGer_Caixa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_ContaGer|=|'" + CD_ContaGer_Caixa.Text + "'",
            new Componentes.EditDefault[] { CD_ContaGer_Caixa, DS_ContaGer_Caixa }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());

            if (CD_ContaGer_Caixa.Text.Trim() == "")
            {
                DS_ContaGer_Caixa.Text = "";
            }
        }

        public void CD_ContaGer_Entrada_Cheque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_ContaGer|=|'" + CD_ContaGer_Entrada_Cheque.Text.Trim() + "'",
            new Componentes.EditDefault[] { CD_ContaGer_Entrada_Cheque, DS_ContaGer_Entrada_Cheque }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        public void CD_ContaGer_Saida_Cheque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_ContaGer|=|'" + CD_ContaGer_Saida_Cheque.Text.Trim() + "'",
            new Componentes.EditDefault[] { CD_ContaGer_Saida_Cheque, DS_ContaGer_Saida_Cheque }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        public void TP_Duplicata_Financeiro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + TP_Duplicata_Financeiro.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(tp_mov_historico_financeiro.Text))
                vParam += ";a.tp_mov|=|'" + tp_mov_historico_financeiro.Text.Trim().ToUpper() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { TP_Duplicata_Financeiro, DS_TP_Duplicata_Financeiro, tp_mov_duplicata_financeiro }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        public void CD_Clifor_Financeiro_Leave(object sender, EventArgs e)
        {
           UtilPesquisa.EDIT_LEAVE("a.cd_Clifor|=|'" + CD_Clifor_Financeiro.Text.Trim() + "'"
                                    , new Componentes.EditDefault[] { CD_Clifor_Financeiro, NM_Clifor_Financeiro }, 
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        public void CD_Clifor_Faturamento_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_Clifor|=|'" + CD_Clifor_Faturamento.Text + "'"
            , new Componentes.EditDefault[] { CD_Clifor_Faturamento, NM_Clifor_Faturamento }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());

            if (CD_Clifor_Faturamento.Text.Trim() == "")
            {
                NM_Clifor_Faturamento.Text = "";
            }
        }

        public void CD_Empresa_Caixa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Caixa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa_Caixa, NM_Empresa_Caixa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        public void Cd_Historico_Caixa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + Cd_Historico_Caixa.Text + "';" +
                                    "((isnull(d.st_caixagerencial, 'N') = 'S') or (isnull(d.st_quitacoes, 'N') = 'S'))||"
            , new Componentes.EditDefault[] { Cd_Historico_Caixa, DS_Historico_Caixa }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        public void CD_Movientacao_Faturamento_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + CD_Movientacao_Faturamento.Text + "'"
            , new Componentes.EditDefault[] { CD_Movientacao_Faturamento, DS_Movimentacao_Faturamento }, new CamadaDados.Fiscal.TCD_CadMovimentacao());

            if (CD_Movientacao_Faturamento.Text.Trim() == "")
            {
                DS_Movimentacao_Faturamento.Text = "";
            }
        }

        public void CD_Produto_Faturamento_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto_Faturamento.Text + "'"
            , new Componentes.EditDefault[] { CD_Produto_Faturamento, DS_Produto_Faturamento }, 
            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());

            if (CD_Produto_Faturamento.Text.Trim() == "")
            {
                DS_Produto_Faturamento.Text = "";
            }
        }

        public void CD_Produto_Estoque_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto_Estoque.Text + "'"
            , new Componentes.EditDefault[] { CD_Produto_Estoque, DS_Produto_Estoque }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());

            if (CD_Produto_Estoque.Text.Trim() == "")
            {
                DS_Produto_Estoque.Text = "";
            }
        }
        
        public void RemoveTabControl()
        {
            if ((vTP_Modo == TTpModo.tm_Edit) || (vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_busca))
            {
                if (tcCentral.SelectedTab.Equals(tpPadrao))
                {
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else
                if (tcCentral.SelectedTab.Equals(tabCaixa))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else
                if (tcCentral.SelectedTab.Equals(tabCheque))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else
                if (tcCentral.SelectedTab.Equals(tabFaturamento))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabCaixa);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else
                if (tcCentral.SelectedTab.Equals(tabPatrimonio))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else
                if (tcCentral.SelectedTab.Equals(tabProvisaoEstoque))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabImpostos);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else if (tcCentral.SelectedTab.Equals(tabImpostos))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    //tcCentral.TabPages.Remove(tabCMV);
                }
                else if (tcCentral.SelectedTab.Equals(tabCMV))
                {
                    tcCentral.TabPages.Remove(tpPadrao);
                    tcCentral.TabPages.Remove(tabCheque);
                    tcCentral.TabPages.Remove(tabFaturamento);
                    //tcCentral.TabPages.Remove(tabPatrimonio);
                    tcCentral.TabPages.Remove(tabCaixa);
                    tcCentral.TabPages.Remove(tabProvisaoEstoque);
                    tcCentral.TabPages.Remove(tabImpostos);
                }
            }
            else
                AddTabControl();
        }

        public void AddTabControl()
        {
            if (!tcCentral.TabPages.Contains(tpPadrao))
                tcCentral.TabPages.Add(tpPadrao);
            if (!tcCentral.TabPages.Contains(tabCaixa))
                tcCentral.TabPages.Add(tabCaixa);
            if (!tcCentral.TabPages.Contains(tabCheque))
                tcCentral.TabPages.Add(tabCheque);
            if (!tcCentral.TabPages.Contains(tabFaturamento))
                tcCentral.TabPages.Add(tabFaturamento);
            if (!tcCentral.TabPages.Contains(tabProvisaoEstoque))
                tcCentral.TabPages.Add(tabProvisaoEstoque);
            //if (!tcCentral.TabPages.Contains(tabPatrimonio))
            //    tcCentral.TabPages.Add(tabPatrimonio);
            if (!tcCentral.TabPages.Contains(tabImpostos))
                tcCentral.TabPages.Add(tabImpostos);
            //if (!tcCentral.TabPages.Contains(tabCMV))
            //    tcCentral.TabPages.Add(tabCMV);

            tcCentral.TabPages[0] = tpPadrao;
            tcCentral.TabPages[1] = tabFaturamento;
            tcCentral.TabPages[2] = tabImpostos;
            //tcCentral.TabPages[3] = tabCMV;
            tcCentral.TabPages[3] = tabCaixa;
            tcCentral.TabPages[4] = tabCheque;
            tcCentral.TabPages[5] = tabProvisaoEstoque;
            //tcCentral.TabPages[7] = tabPatrimonio;
        }

        public void modoBotoes(bool vNovo, bool vAlterar, bool vGravar, bool vExcluir,
                                bool vCancelar, bool vBuscar, bool vImprimir)
        {
            BB_Novo.Visible = vNovo;
            BB_Alterar.Visible = vAlterar;
            BB_Buscar.Visible = vBuscar;
            BB_Cancelar.Visible = vCancelar;
            BB_Excluir.Visible = vExcluir;
            BB_Fechar.Visible = true;
            BB_Gravar.Visible = vGravar;
            BB_Imprimir.Visible = vImprimir;
        }
        
        private void BTN_Historico_Financeiro_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Historico|Descrição|350;a.CD_Historico|Cód. Histórico|150;a.tp_mov|Tipo Movimento|80";
            string vParam = "((isnull(d.st_financeiro, 'N') = 'S') or (isnull(d.st_faturamento, 'N') = 'S'))||";
            if (!string.IsNullOrEmpty(tp_mov_duplicata_financeiro.Text))
                vParam += ";a.tp_mov|=|'" + tp_mov_duplicata_financeiro.Text.Trim().ToUpper() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico_Financeiro, DS_Historico_Financeiro, tp_mov_historico_financeiro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        public void CD_Historico_Financeiro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + CD_Historico_Financeiro.Text.Trim() + "';" +
                            "((isnull(d.st_financeiro, 'N') = 'S') or (isnull(d.st_faturamento, 'N') = 'S'))||";
            if (!string.IsNullOrEmpty(tp_mov_duplicata_financeiro.Text))
                vParam += ";a.tp_mov|=|'" + tp_mov_duplicata_financeiro.Text.Trim().ToUpper() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Historico_Financeiro, DS_Historico_Financeiro }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        public void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void btn_CFOP_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_CFOP|CFOP|350;a.CD_CFOP|Cód. CFOP|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CFOP, DS_CFOP},
                                    new CamadaDados.Fiscal.TCD_CadCFOP(), "");
        }

        public void CD_CFOP_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_CFOP|=|'" + CD_CFOP.Text + "'",
            new Componentes.EditDefault[] { CD_CFOP, DS_CFOP }, new CamadaDados.Fiscal.TCD_CadCFOP());
        }

        private void btn_Patrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Patrimonio|Patrimônio|350;a.ID_Patrimonio|Cód. Patrimônio|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Patrimonio, DS_Patrimonio },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPatrimonio(), "");
        }

        private void btn_GrupoPatrim_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_GrupoPatrim|Grupo Patrimônio|350;a.ID_GrupoPatrim|Cód. Grupo Patrimônio|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadGrupoPatrimonio(), "");
        }

        public void ID_Patrimonio_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_Patrimonio|=|'" + ID_Patrimonio.Text + "'",
            new Componentes.EditDefault[] { ID_Patrimonio, DS_Patrimonio }, new CamadaDados.Contabil.Cadastro.TCD_CadPatrimonio());
        }

        public void ID_GrupoPatrim_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_GrupoPatrim|=|'" + ID_GrupoPatrim.Text + "'",
            new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim }, new CamadaDados.Contabil.Cadastro.TCD_CadGrupoPatrimonio());
        }

        private void btn_Deb_patrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Patrimonio, DS_Conta_DEB_Patrimonio, CD_Classificacao_Deb_Patrimonio },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), "a.st_Registro|=|'A';a.TP_Conta|=|'A'");
        }

        private void btn_Cred_patrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Patrimonio, DS_Conta_CRED_Patrimonio, CD_Classificacao_Cred_Patr },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), "a.st_Registro|=|'A';a.TP_Conta|=|'A'");
        }

        public void CD_CONTA_CTB_DEB_Patrimonio_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_DEB_Patrimonio.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_DEB_Patrimonio, DS_Conta_DEB_Patrimonio, CD_Classificacao_Deb_Patrimonio }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        public void CD_CONTA_CTB_CRED_Patrimonio_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + CD_CONTA_CTB_CRED_Patrimonio.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { CD_CONTA_CTB_CRED_Patrimonio, DS_Conta_CRED_Patrimonio, CD_Classificacao_Cred_Patr }, new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void TFConfigContabil_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void TFConfigContabil_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCaixa);
            Utils.ShapeGrid.RestoreShape(this, gCfgCmv);
            Utils.ShapeGrid.RestoreShape(this, gCheque);
            Utils.ShapeGrid.RestoreShape(this, gCMV);
            Utils.ShapeGrid.RestoreShape(this, gFaturamento);
            Utils.ShapeGrid.RestoreShape(this, gFinanceiro);
            Utils.ShapeGrid.RestoreShape(this, gImpostos);
            Utils.ShapeGrid.RestoreShape(this, gPatrimonio);
            Utils.ShapeGrid.RestoreShape(this, gProvisao_Estoque);
            panelDados12.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados23.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados29.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados35.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados53.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelDados56.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            panelTpPagamento.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados21.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados33.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            tcCentral.TabPages.Remove(tabCMV);
            tcCentral.TabPages.Remove(tabPatrimonio);
        }

        private void bb_mov_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movimentação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_mov_imposto, ds_mov_imposto },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_mov_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_mov_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_mov_imposto, ds_mov_imposto },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_imposto|Imposto|200;" +
                              "a.cd_imposto|Cd. Imposto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                    new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_imposto|=|" + cd_imposto.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_imposto, ds_imposto },
                                new CamadaDados.Fiscal.TCD_CadImposto());
        }

        private void bb_clifor_imposto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_imposto, nm_clifor_imposto }, string.Empty);
        }

        private void cd_clifor_imposto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_Clifor|=|'" + cd_clifor_imposto.Text + "'"
            , new Componentes.EditDefault[] { cd_clifor_imposto, nm_clifor_imposto }, 
            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_imposto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto_imposto, ds_produto_imposto }, string.Empty);
        }

        private void cd_produto_imposto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + cd_produto_imposto.Text + "'"
            , new Componentes.EditDefault[] { cd_produto_imposto, ds_produto_imposto },
            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_conta_deb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_conta_deb_imposto, ds_conta_deb_imposto, cd_classificacao_deb_imposto },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_conta_deb_imposto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_conta_deb_imposto.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_conta_deb_imposto, ds_conta_deb_imposto, cd_classificacao_deb_imposto },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_conta_cred_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_conta_cred_imposto, ds_conta_cred_imposto, cd_classificacao_cred_imposto },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_conta_cred_imposto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_conta_cred_imposto.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_conta_cred_imposto, ds_conta_cred_imposto, cd_classificacao_cred_imposto },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_mov_cmv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;" +
                              "a.cd_movimentacao|Cd. Movimentação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_mov_cmv, ds_mov_cmv },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_mov_cmv_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_movimentacao|=|" + cd_mov_cmv.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_mov_cmv, ds_mov_cmv },
                                    new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_produto_cmv_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto_cmv, ds_produto_cmv }, string.Empty);
        }

        private void cd_produto_cmv_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + cd_produto_cmv.Text + "'"
            , new Componentes.EditDefault[] { cd_produto_cmv, ds_produto_cmv },
            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_conta_deb_cmv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_conta_deb_cmv, ds_conta_deb_cmv, cd_classificacao_deb_cmv },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_conta_deb_cmv_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_conta_deb_cmv.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_conta_deb_cmv, ds_conta_deb_cmv, cd_classificacao_deb_cmv },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_conta_cred_cmv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Classificacao|Classificação|80;A.DS_ContaCTB|Descrição|350;a.CD_Conta_CTB|Conta Débito|150;a.TP_Conta|Tipo Conta|40";
            string vParam = "a.tp_conta|=|'A';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_conta_cred_cmv, ds_conta_cred_cmv, cd_classificacao_cred_cmv },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_conta_cred_cmv_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("A.CD_Conta_CTB|=|'" + cd_conta_cred_cmv.Text + "';a.st_Registro|=|'A';a.TP_Conta|=|'A' "
            , new Componentes.EditDefault[] { cd_conta_cred_cmv, ds_conta_cred_cmv, cd_classificacao_cred_cmv },
            new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void TFConfigContabil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCaixa);
            Utils.ShapeGrid.SaveShape(this, gCfgCmv);
            Utils.ShapeGrid.SaveShape(this, gCheque);
            Utils.ShapeGrid.SaveShape(this, gCMV);
            Utils.ShapeGrid.SaveShape(this, gFaturamento);
            Utils.ShapeGrid.SaveShape(this, gFinanceiro);
            Utils.ShapeGrid.SaveShape(this, gImpostos);
            Utils.ShapeGrid.SaveShape(this, gPatrimonio);
            Utils.ShapeGrid.SaveShape(this, gProvisao_Estoque);
        }
    }
}
