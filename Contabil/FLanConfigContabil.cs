using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Contabil
{
    public partial class TFLanConfigContabil : Form
    {
        public TFLanConfigContabil()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            if (tcCentral.SelectedTab.Equals(tpFat))
                using (TFCFGFaturamento fCfg = new TFCFGFaturamento())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rFat != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Gravar(fCfg.rFat, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if (tcCentral.SelectedTab.Equals(tpImpostos))
                using (TFCFGImpostos fCfg = new TFCFGImpostos())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rImp != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Gravar(fCfg.rImp, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
                using (TFCFGFinanceiro fCfg = new TFCFGFinanceiro())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rFin != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Gravar(fCfg.rFin, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
                using (TFCFGCaixa fCfg = new TFCFGCaixa())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rCaixa != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Gravar(fCfg.rCaixa, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if (tcCentral.SelectedTab.Equals(tpChComp))
                using (TFCFGChequeComp fCfg = new TFCFGChequeComp())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rCheque != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Gravar(fCfg.rCheque, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if (tcCentral.SelectedTab.Equals(tpProvisao))
                using (TFCFGProvisaoEst fCfg = new TFCFGProvisaoEst())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rProv != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGProvisao_Estoque.Gravar(fCfg.rProv, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else  if(tcCentral.SelectedTab.Equals(tpCMV))
                using (TFCFGCMV fCfg = new TFCFGCMV())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rCmv != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGCMV.Gravar(fCfg.rCmv, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if(tcCentral.SelectedTab.Equals(tpComp))
                using (TFCFGCompFixar fCfg = new TFCFGCompFixar())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rComp != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGCompFixar.Gravar(fCfg.rComp, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if(tcCentral.SelectedTab.Equals(tpAdto))
                using (TFCFGAdiantamento fCfg = new TFCFGAdiantamento())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rAdto != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGAdiantamento.Gravar(fCfg.rAdto, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if(tcCentral.SelectedTab.Equals(tpCartao))
                using (TFCFGCartao_DC fCfg = new TFCFGCartao_DC())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rCartao != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGCartao_DC.Gravar(fCfg.rCartao, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch(Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else if(tcCentral.SelectedTab.Equals(tpNFCe))
                using (TFCFGNFCe fCfg = new TFCFGNFCe())
                {
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rFat != null)
                            try
                            {
                                CamadaNegocio.Contabil.TCN_CTB_CFGNFCe.Gravar(fCfg.rFat, null);
                                MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch(Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterAltera()
        {
            if (tcCentral.SelectedTab.Equals(tpFat))
            {
                if (bsFaturamento.Current != null)
                    using (TFCFGFaturamento fCfg = new TFCFGFaturamento())
                    {
                        fCfg.rFat = bsFaturamento.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rFat != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Gravar(fCfg.rFat, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpImpostos))
            {
                if (bsImpostos.Current != null)
                    using (TFCFGImpostos fCfg = new TFCFGImpostos())
                    {
                        fCfg.rImp = bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rImp != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Gravar(fCfg.rImp, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
            {
                if (bsFinanceiro.Current != null)
                    using (TFCFGFinanceiro fCfg = new TFCFGFinanceiro())
                    {
                        fCfg.rFin = bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rFin != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Gravar(fCfg.rFin, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
            {
                if (bsCaixa.Current != null)
                    using (TFCFGCaixa fCfg = new TFCFGCaixa())
                    {
                        fCfg.rCaixa = bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rCaixa != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Gravar(fCfg.rCaixa, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpChComp))
            {
                if (bsCheque.Current != null)
                    using (TFCFGChequeComp fCfg = new TFCFGChequeComp())
                    {
                        fCfg.rCheque = bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rCheque != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Gravar(fCfg.rCheque, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpProvisao))
            {
                if (bsProvisao.Current != null)
                    using (TFCFGProvisaoEst fCfg = new TFCFGProvisaoEst())
                    {
                        fCfg.rProv = bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rProv != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGProvisao_Estoque.Gravar(fCfg.rProv, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpCMV))
            {
                if (bsCMV.Current != null)
                    using (TFCFGCMV fCfg = new TFCFGCMV())
                    {
                        fCfg.rCmv = bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rCmv != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGCMV.Gravar(fCfg.rCmv, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpComp))
            {
                if (bsComp.Current != null)
                    using (TFCFGCompFixar fCfg = new TFCFGCompFixar())
                    {
                        fCfg.rComp = bsComp.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rComp != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGCompFixar.Gravar(fCfg.rComp, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpAdto))
            {
                if (bsAdto.Current != null)
                    using (TFCFGAdiantamento fCfg = new TFCFGAdiantamento())
                    {
                        fCfg.rAdto = bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rAdto != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGAdiantamento.Gravar(fCfg.rAdto, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpCartao))
            {
                if (bsCartao.Current != null)
                    using (TFCFGCartao_DC fCfg = new TFCFGCartao_DC())
                    {
                        fCfg.rCartao = bsCartao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCartao_DC;
                        if (fCfg.ShowDialog() == DialogResult.OK)
                            if (fCfg.rCartao != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGCartao_DC.Gravar(fCfg.rCartao, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpNFCe))
            {
                if (bsNFCe.Current != null)
                    using (TFCFGNFCe fCfg = new TFCFGNFCe())
                    {
                        fCfg.rFat = bsNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe;
                        if(fCfg.ShowDialog() == DialogResult.OK)
                            if(fCfg.rFat != null)
                                try
                                {
                                    CamadaNegocio.Contabil.TCN_CTB_CFGNFCe.Gravar(fCfg.rFat, null);
                                    MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch(Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
            }
        }

        private void afterExclui()
        {
            if (tcCentral.SelectedTab.Equals(tpFat))
            {
                if (bsFaturamento.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Excluir(bsFaturamento.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsFaturamento.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpImpostos))
            {
                if (bsImpostos.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Excluir(bsImpostos.Current as CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsImpostos.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
            {
                if (bsFinanceiro.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Excluir(bsFinanceiro.Current as CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsFinanceiro.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
            {
                if (bsCaixa.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Excluir(bsCaixa.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCaixa, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCaixa.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpChComp))
            {
                if (bsCheque.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Excluir(bsCheque.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCheque.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpProvisao))
            {
                if (bsProvisao.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGProvisao_Estoque.Excluir(bsProvisao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsProvisao.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpCMV))
            {
                if (bsCMV.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCMV.Excluir(bsCMV.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCMV, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCMV.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpComp))
            {
                if (bsComp.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCompFixar.Excluir(bsComp.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCompFixacao, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsComp.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpAdto))
            {
                if (bsAdto.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGAdiantamento.Excluir(bsAdto.Current as CamadaDados.Contabil.TRegistro_CTB_CFGAdiantamento, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsAdto.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcCentral.SelectedTab.Equals(tpCartao))
            {
                if (bsCartao.Current != null)
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGCartao_DC.Excluir(bsCartao.Current as CamadaDados.Contabil.TRegistro_CTB_CFGCartao_DC, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCartao.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if(tcCentral.SelectedTab.Equals(tpNFCe))
            {
                if(bsNFCe.Current != null)
                    if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Contabil.TCN_CTB_CFGNFCe.Excluir(bsNFCe.Current as CamadaDados.Contabil.TRegistro_CTB_CFGNFCe, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsNFCe.RemoveCurrent();
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpFat))
                bsFaturamento.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGFaturamento.Buscar(string.Empty,
                                                                                                CD_Empresa.Text,
                                                                                                cd_movimentacao.Text,
                                                                                                null);
            else if (tcCentral.SelectedTab.Equals(tpImpostos))
                bsImpostos.DataSource = CamadaNegocio.Contabil.TCN_CFGImpostoFaturamento.Buscar(string.Empty,
                                                                                                cd_empimposto.Text,
                                                                                                cd_movimposto.Text,
                                                                                                cd_imposto.Text,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                null);
            else if (tcCentral.SelectedTab.Equals(tpFinanceiro))
                bsFinanceiro.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGFinanceiro.Busca(string.Empty,
                                                                                             cd_empfin.Text,
                                                                                             tp_duplicata.Text,
                                                                                             cd_historico.Text,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             null);
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
                bsCaixa.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGCaixa.Busca(string.Empty,
                                                                                   cd_empcx.Text,
                                                                                   cd_contagercx.Text,
                                                                                   cd_historicocx.Text,
                                                                                   cd_conta_debcx.Text,
                                                                                   cd_conta_credcx.Text,
                                                                                   null);
            else if (tcCentral.SelectedTab.Equals(tpChComp))
                bsCheque.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGChequeCompensado.Busca(string.Empty,
                                                                                               cd_empch.Text,
                                                                                               cd_contagerentch.Text,
                                                                                               cd_contagersaich.Text,
                                                                                               null);
            else if (tcCentral.SelectedTab.Equals(tpProvisao))
                bsProvisao.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGProvisao_Estoque.Busca(string.Empty,
                                                                                                 cd_empresaprov.Text,
                                                                                                 cd_produto.Text,
                                                                                                 null);
            else if (tcCentral.SelectedTab.Equals(tpCMV))
                bsCMV.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGCMV.Buscar(string.Empty,
                                                                                cd_empresacmv.Text,
                                                                                cd_movcmv.Text,
                                                                                cd_produtocmv.Text,
                                                                                null);
            else if (tcCentral.SelectedTab.Equals(tpComp))
                bsComp.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGCompFixar.Buscar(string.Empty,
                                                                                       cd_empcomp.Text,
                                                                                       string.Empty,
                                                                                       cd_prodComp.Text,
                                                                                       null);
            else if (tcCentral.SelectedTab.Equals(tpAdto))
                bsAdto.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGAdiantamento.Buscar(string.Empty,
                                                                                          cd_empadto.Text,
                                                                                          cd_historicoadto.Text,
                                                                                          cd_contageradto.Text,
                                                                                          string.Empty,
                                                                                          cd_cliforadto.Text,
                                                                                          null);
            else if (tcCentral.SelectedTab.Equals(tpCartao))
                bsCartao.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGCartao_DC.Busca(string.Empty,
                                                                                        cd_empCartao.Text,
                                                                                        cd_contagerCartaoE.Text,
                                                                                        cd_contagerCartaoS.Text,
                                                                                        null);
            else if (tcCentral.SelectedTab.Equals(tpNFCe))
                bsNFCe.DataSource = CamadaNegocio.Contabil.TCN_CTB_CFGNFCe.Buscar(string.Empty,
                                                                                  cd_empNFCe.Text,
                                                                                  cd_cfop.Text,
                                                                                  null);
        }

        private void TFLanConfigContabil_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltroFat.set_FormatZero();
            pFiltroCh.set_FormatZero();
            pFiltrocx.set_FormatZero();
            pFiltroFin.set_FormatZero();
            pFiltroImp.set_FormatZero();
            pFiltroProv.set_FormatZero();
            pFiltroCMV.set_FormatZero();
            pFiltroAdto.set_FormatZero();
            pFiltroNFCe.set_FormatZero();
        }

        private void btn_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_movimentacao_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimentacao },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimentacao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + cd_movimentacao.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_movimentacao }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLanConfigContabil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gFaturamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFaturamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFaturamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGFaturamento());
            CamadaDados.Contabil.TList_CTB_CFGFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGFaturamento(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGFaturamento(lP.Find(gFaturamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFaturamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFaturamento.List as CamadaDados.Contabil.TList_CTB_CFGFaturamento).Sort(lComparer);
            bsFaturamento.ResetBindings(false);
            gFaturamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gImpostos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gImpostos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsImpostos.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CFGImpostoFaturamento());
            CamadaDados.Contabil.TList_CFGImpostoFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CFGImpostoFaturamento(lP.Find(gImpostos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gImpostos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CFGImpostoFaturamento(lP.Find(gImpostos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gImpostos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsImpostos.List as CamadaDados.Contabil.TList_CFGImpostoFaturamento).Sort(lComparer);
            bsImpostos.ResetBindings(false);
            gImpostos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empimposto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empimposto }, string.Empty);
        }

        private void cd_empimposto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empimposto.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empimposto });
        }

        private void bb_movimposto_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Movimentacao|Movimentação|350;a.CD_Movimentacao|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movimposto },
                                            new CamadaDados.Fiscal.TCD_CadMovimentacao(), string.Empty);
        }

        private void cd_movimposto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|'" + cd_movimposto.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_movimposto }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_imposto_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_imposto|Imposto|350;a.cd_imposto|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_imposto },
                                            new CamadaDados.Fiscal.TCD_CadImposto(), string.Empty);
        }

        private void cd_imposto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_imposto|=|'" + cd_imposto.Text.Trim() + "'"
            , new Componentes.EditDefault[] { cd_imposto }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void gFinanceiro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFinanceiro.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFinanceiro.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGFinanceiro());
            CamadaDados.Contabil.TList_CTB_CFGFinanceiro lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGFinanceiro(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGFinanceiro(lP.Find(gFinanceiro.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFinanceiro.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFinanceiro.List as CamadaDados.Contabil.TList_CTB_CFGFinanceiro).Sort(lComparer);
            bsFinanceiro.ResetBindings(false);
            gFinanceiro.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empfin_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empfin }, string.Empty);
        }

        private void cd_empfin_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empfin.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empfin });
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata }, string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveTpDuplicata("a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "'",
                new Componentes.EditDefault[] { tp_duplicata });
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Historico|Descrição|350;a.CD_Historico|Cód. Histórico|150;a.tp_mov|Tipo Movimento|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void gCaixa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCaixa.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCaixa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGCaixa());
            CamadaDados.Contabil.TList_CTB_CFGCaixa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCaixa(lP.Find(gCaixa.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCaixa.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCaixa.List as CamadaDados.Contabil.TList_CTB_CFGCaixa).Sort(lComparer);
            bsCaixa.ResetBindings(false);
            gCaixa.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empcx_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empcx }, string.Empty);
        }

        private void cd_empcx_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empcx.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empcx });
        }

        private void bb_contagercx_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição Conta Gerencial|350;a.CD_ContaGer|Código|100",
            new Componentes.EditDefault[] { cd_contagercx },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagercx_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagercx.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagercx }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_historicocx_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_historico|Histórico|350;a.CD_Historico|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicocx },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historicocx_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historicocx.Text + "'"
            , new Componentes.EditDefault[] { cd_historicocx }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void gCheque_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCheque.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCheque.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGCheque_Compensado());
            CamadaDados.Contabil.TList_CTB_CFGCheque_Compensado lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCheque_Compensado(lP.Find(gCheque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCheque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCheque_Compensado(lP.Find(gCheque.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCheque.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCheque.List as CamadaDados.Contabil.TList_CTB_CFGCheque_Compensado).Sort(lComparer);
            bsCheque.ResetBindings(false);
            gCheque.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empch_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empch }, string.Empty);
        }

        private void cd_empch_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empch.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empch });
        }

        private void bb_contagerentch_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagerentch },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerentch_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerentch.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerentch },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contagersaich_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagersaich },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagersaich_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagersaich.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagersaich },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void gProvisao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProvisao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProvisao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGProvisao_Estoque());
            CamadaDados.Contabil.TList_CTB_CFGProvisao_Estoque lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGProvisao_Estoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGProvisao_Estoque(lP.Find(gProvisao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProvisao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProvisao.List as CamadaDados.Contabil.TList_CTB_CFGProvisao_Estoque).Sort(lComparer);
            bsProvisao.ResetBindings(false);
            gProvisao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_empresaprov_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresaprov }, string.Empty);
        }

        private void cd_empresaprov_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresaprov.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresaprov });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_empresacmv_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresacmv }, string.Empty);
        }

        private void cd_empresacmv_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresacmv.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresacmv });
        }

        private void bb_movcmv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_movimentacao|Movimentação Comercial|200;a.cd_movimentacao|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_movcmv },
                new CamadaDados.Fiscal.TCD_CadMovimentacao(), "a.tp_movimento|=|'S'");
        }

        private void cd_movcmv_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_movimentacao|=|" + cd_movcmv.Text + ";a.tp_movimento|=|'S'",
                new Componentes.EditDefault[] { cd_movcmv }, new CamadaDados.Fiscal.TCD_CadMovimentacao());
        }

        private void bb_produtocmv_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produtocmv }, string.Empty);
        }

        private void cd_produtocmv_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produtocmv.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produtocmv }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_empcomp_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empcomp }, string.Empty);
        }

        private void cd_empcomp_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empcomp.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empcomp });
        }
                
        private void bb_empadto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empadto }, string.Empty);
        }

        private void cd_empadto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empadto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empadto });
        }

        private void bb_cliforadto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforadto }, string.Empty);
        }

        private void cd_cliforadto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforadto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliforadto }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_historicoadto_Click(object sender, EventArgs e)
        {
            string vColunas = "A.ds_historico|Histórico|350;a.CD_Historico|Código|150";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicoadto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_historicoadto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historicoadto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historicoadto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição Conta Gerencial|350;a.CD_ContaGer|Código|100",
            new Componentes.EditDefault[] { cd_contageradto },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contageradto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contageradto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contageradto }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_conta_debcx_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                cd_conta_debcx.Text = rConta.Cd_conta_ctbstr;
        }

        private void cd_conta_debcx_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cd_conta_debcx.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta_debcx },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_conta_credcx_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
                FormBusca.UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
                cd_conta_credcx.Text = rConta.Cd_conta_ctbstr;
        }

        private void cd_conta_credcx_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cd_conta_credcx.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta_credcx },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bbProdComp_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_prodComp }, string.Empty);
        }

        private void cd_prodComp_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_prodComp.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_prodComp }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bbempCartao_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empCartao }, string.Empty);
        }

        private void cd_empCartao_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empCartao.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empCartao });
        }

        private void bbcontagerCartaoE_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagerCartaoE },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void bbcontagerCartaoS_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|350;" +
                              "a.cd_contager|Cd. Conta|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_contagerCartaoS },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contagerCartaoE_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerCartaoE.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerCartaoE },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void cd_contagerCartaoS_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contagerCartaoS.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_contagerCartaoS },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void gCartao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCartao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCartao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Contabil.TRegistro_CTB_CFGCartao_DC());
            CamadaDados.Contabil.TList_CTB_CFGCartao_DC lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCartao_DC(lP.Find(gCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Contabil.TList_CTB_CFGCartao_DC(lP.Find(gCartao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCartao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCartao.List as CamadaDados.Contabil.TList_CTB_CFGCartao_DC).Sort(lComparer);
            bsCartao.ResetBindings(false);
            gCartao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bbEmpNFCe_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empNFCe }, string.Empty);
        }

        private void cd_empNFCe_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empNFCe.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empNFCe });
        }

        private void bb_cfop_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cfop|CFOP|350;" +
                              "a.cd_cfop|Cd. CFOP|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
            new Componentes.EditDefault[] { cd_cfop },
            new CamadaDados.Fiscal.TCD_CadCFOP(), string.Empty);
        }

        private void cd_cfop_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_cfop|=|'" + cd_cfop.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cfop },
                new CamadaDados.Fiscal.TCD_CadCFOP());
        }
    }
}
