using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.NFE;
using System.Xml;
using CamadaDados.Faturamento.PDV;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Financeiro.Duplicata;

namespace Proc_Commoditties
{
    public partial class TFLanConsultaNFe : Form
    {
        private bool Altera_Relatorio = false;

        public string Tp_documento
        { get; set; }

        public TFLanConsultaNFe()
        {
            InitializeComponent();
            Tp_documento = string.Empty;
        }

        private void afterBusca(bool NaoAceita)
        {
            if (empresa.SelectedValue != null)
            {
                if (tcNf.SelectedTab.Equals(tpNfe))
                {
                    if (tcNfe.SelectedTab.Equals(tpLoteNfe))
                    {
                        //Buscar lote 
                        bsLoteNFE.DataSource = CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE.Buscar(id_lote.Text,
                                                                                                   string.Empty,
                                                                                                   empresa.SelectedValue.ToString(),
                                                                                                   nr_notafiscal.Text,
                                                                                                   CD_Clifor.Text,
                                                                                                   cbAmbienteBusca.Text.Trim().Equals("HOMOLOGAÇÃO") ?
                                                                                                   "2" : cbAmbienteBusca.Text.Trim().Equals("PRODUÇÃO") ?
                                                                                                   "1" : string.Empty,
                                                                                                   dt_inicial.Text,
                                                                                                   dt_final.Text,
                                                                                                   status_lote.Text,
                                                                                                   st_aberto.Checked ? "A" :
                                                                                                   st_processado.Checked ? "P" : string.Empty,
                                                                                                   NaoAceita,
                                                                                                   Convert.ToInt32(Utils.Parametros.pubTopMax),
                                                                                                   null);
                        bsLoteNFE_PositionChanged(this, new EventArgs());
                        //Buscar NFe não Enviadas
                        object obj = new TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + empresa.SelectedValue.ToString() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.status, 0)",
                                                vOperador = " not in ",
                                                vVL_Busca = "(100, 110, 205, 301, 302, 303)"
                                            }
                                        }, "count(*)");
                        nfeNaoAceita.Text = obj == null ? string.Empty : obj.ToString();
                    }
                    else if (tcNfe.SelectedTab.Equals(tpNfeEnviar))
                    {
                        bsNFeEnviar.DataSource = TCN_LanFaturamento.Busca(empresa.SelectedValue.ToString(),
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            decimal.Zero,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            true,
                                                                            string.Empty,
                                                                            "N",
                                                                            "N",
                                                                            string.Empty,
                                                                            "A",
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            decimal.Zero,
                                                                            decimal.Zero,
                                                                            "MASTER",
                                                                            "'P'",
                                                                            "'P', 'M'",
                                                                            false,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
                        bsNFeEnviar.ResetBindings(true);
                    }
                }
                else if (tcNf.SelectedTab.Equals(tpNFCe))
                {
                    if (tcNFCe.SelectedTab.Equals(tpLoteNFCe))
                    {
                        bsLoteNFCe.DataSource = CamadaNegocio.Faturamento.NFCe.TCN_LoteNFCe.Buscar(empresa.SelectedValue.ToString(),
                                                                                                   id_lote.Text,
                                                                                                   dt_inicial.Text,
                                                                                                   dt_final.Text,
                                                                                                   cbAmbienteBusca.Text.Trim().Equals("HOMOLOGAÇÃO") ?
                                                                                                   "2" : cbAmbienteBusca.Text.Trim().Equals("PRODUÇÃO") ?
                                                                                                   "1" : string.Empty,
                                                                                                   nr_notafiscal.Text,
                                                                                                   CD_Clifor.Text,
                                                                                                   status_lote.Text,
                                                                                                   st_aberto.Checked ? "A" :
                                                                                                   st_processado.Checked ? "P" : string.Empty,
                                                                                                   NaoAceita,
                                                                                                   Convert.ToInt32(Utils.Parametros.pubTopMax),
                                                                                                   null);
                        bsLoteNFCe_PositionChanged(this, new EventArgs());
                        //Buscar NFCe não Enviadas
                        object obj = new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + empresa.SelectedValue.ToString() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.status, 0)",
                                                vOperador = "not in",
                                                vVL_Busca = "(100, 150, 302)"
                                            }
                                        }, "count(*)");
                        nfceNaoAceita.Text = obj == null ? string.Empty : obj.ToString();
                    }
                    else if (tcNFCe.SelectedTab.Equals(tpNFCeEnviar))
                        bsNFCeEnviar.DataSource = new TCD_NFCe().SelectNFCeEnviar(empresa.SelectedValue.ToString());
                }
                else if (tcNf.SelectedTab.Equals(tpNfse))
                {
                    if (tcNfse.SelectedTab.Equals(tpLoteRps))
                    {
                        //Buscar Lote RPS
                        bsLoteRPS.DataSource = CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Buscar(id_lote.Text,
                                                                                                 empresa.SelectedValue.ToString(),
                                                                                                 nr_notafiscal.Text,
                                                                                                 CD_Clifor.Text,
                                                                                                 dt_inicial.Text,
                                                                                                 dt_final.Text,
                                                                                                 string.Empty,
                                                                                                 cbAmbienteBusca.Text.Trim().Equals("HOMOLOGAÇÃO") ? "H" :
                                                                                                 cbAmbienteBusca.Text.Trim().Equals("PRODUÇÃO") ? "P" : string.Empty,
                                                                                                 string.Empty,
                                                                                                 null);
                        bsLoteRPS_PositionChanged(this, new EventArgs());
                    }
                    else if (tcNfse.SelectedTab.Equals(tpNfseEnviar))
                        bsNFSeEnviar.DataSource =
                            TCN_LanFaturamento.Busca(empresa.SelectedValue.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          true,
                                                                                          string.Empty,
                                                                                          "N",
                                                                                          "N",
                                                                                          string.Empty,
                                                                                          "A",
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          decimal.Zero,
                                                                                          decimal.Zero,
                                                                                          "MASTER",
                                                                                          "'P'",
                                                                                          "'S'",
                                                                                          false,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);
                }
            }
        }

        private void EnviarNfe()
        {
            if (empresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                empresa.Focus();
                return;
            }
            //Buscar CfgNfe
            TRegistro_CfgNfe rCfgNfe =
                TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null)[0];
            if (tcNf.SelectedTab.Equals(tpNfe))
            {
                List<TRegistro_LanFaturamento> lNfEnviar = null;
                if (bsNFeEnviar.Count > 0)
                    if ((bsNFeEnviar.List as TList_RegLanFaturamento).Exists(p => p.St_formarlotectrc))
                        lNfEnviar = (bsNFeEnviar.List as TList_RegLanFaturamento).FindAll(p => p.St_formarlotectrc).Take(50).ToList();
                //Gerar e assinar Arquivos xml
                try
                {
                    srvNFE.EnviaArq.TEnviarArq2.EnviarLoteNfe2(0, lNfEnviar, rCfgNfe);
                    tcNfe.SelectedTab = tpLoteNfe;
                    afterBusca(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro enviar NF-e: " + ex.Message);
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNFCe))
            {
                List<TRegistro_NFCe> lNFCEnviar = new List<TRegistro_NFCe>();
                if (bsNFCeEnviar.Count > 0)
                    if ((bsNFCeEnviar.List as TList_NFCe).Exists(p => p.St_processar))
                        (bsNFCeEnviar.List as TList_NFCe).FindAll(p => p.St_processar).Take(50).ToList().ForEach(p =>
                            lNFCEnviar.Add(CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(p.Cd_empresa, p.Id_nfcestr, null)));
                //Gerar e assinar Arquivos xml
                try
                {
                    NFCe.EnviaArq.TEnviaArq.EnviarLote(null, lNFCEnviar);
                    tcNFCe.SelectedTab = tpLoteNFCe;
                    afterBusca(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro enviar NF-e: " + ex.Message);
                }
            }
            else
            {
                List<TRegistro_LanFaturamento> lNfseEnviar = null;
                if (bsNFSeEnviar.Count > 0)
                    if ((bsNFSeEnviar.DataSource as TList_RegLanFaturamento).Exists(p => p.St_formarlotectrc))
                        lNfseEnviar = (bsNFSeEnviar.DataSource as TList_RegLanFaturamento).FindAll(p => p.St_formarlotectrc);
                try
                {
                    NFES.TGerarRPS.CriarArquivoRPS(rCfgNfe, lNfseEnviar);
                    tcNfse.SelectedTab = tpLoteRps;
                    afterBusca(false);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void ConsultaStatusServico()
        {
            if (tcNf.SelectedTab.Equals(tpNfe))
            {
                if (empresa.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    empresa.Focus();
                    return;
                }
                TRegistro_CfgNfe rCfgNfe =
                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                      string.Empty,
                                      string.Empty,
                                      null)[0];
                string retorno = srvNFE.ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, false);
                if (retorno.Trim().Equals("107"))
                    tsStatus.Text = "SERVIÇO EM OPERAÇÃO";
                else
                {
                    string ret_cont = srvNFE.ConsultaStatusServico.ConsultaStatusServico.StatusServico(rCfgNfe, true);
                    if (ret_cont.Trim().Equals("107"))
                        tsStatus.Text = "SERVIÇO EM OPERAÇÃO - MODO CONTINGENCIA(" + rCfgNfe.Tipo_ambientecont.Trim() + ")";
                    else
                        tsStatus.Text = "SERVIÇO INDISPONIVEL NO MOMENTO.";
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNFCe))
            {
                if (empresa.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    empresa.Focus();
                    return;
                }
                TRegistro_CfgNfe rCfgNfe =
                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null)[0];
                string retorno = NFCe.ConsultaStatusServico.TConsultaStatusServico.StatusServico(rCfgNfe);
                if (retorno.Trim().Equals("107"))
                    tsStatus.Text = "SERVIÇO EM OPERAÇÃO";
                else tsStatus.Text = "SERVIÇO INDISPONIVEL NO MOMENTO.";
            }
        }

        private void ConsultarLoteNfe()
        {
            if (empresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                empresa.Focus();
                return;
            }
            TRegistro_CfgNfe rCfgNfe =
                TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null)[0];
            if (tcNf.SelectedTab.Equals(tpNfe))
            {
                try
                {
                    srvNFE.NFERecepcao.TRetRecepcao2.ConsultaNFERecepcao2(rCfgNfe);
                    afterBusca(false);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcNf.SelectedTab.Equals(tpNFCe))
            {
                try
                {
                    NFCe.RetAutoriza.TRetAutoriza.ConsultaNFERecepcao(rCfgNfe);
                    afterBusca(false);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else if (tcNf.SelectedTab.Equals(tpNfse))
            {
                try
                {
                    NFES.TConsultarSitLoteRPS.ConsultarSitLoteRPS(rCfgNfe);
                    afterBusca(false);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro consultar lote RPS: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ReabrirLoteProcessar()
        {
            if (tcNf.SelectedTab.Equals(tpNfe))
            {
                if (bsLoteNFE_X_NotaFiscal.Current != null)
                {
                    if ((bsLoteNFE.Current as TRegistro_LanLoteNFE).Status.Equals(103) ||
                        (bsLoteNFE.Current as TRegistro_LanLoteNFE).Status.Equals(105))
                    {
                        MessageBox.Show("Não é permitido REABRIR NF-e de um lote ainda não processado pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("100") &&
                        (bsLoteNFE.Current as TRegistro_LanLoteNFE).Tp_ambiente.Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido REABRIR NF-e aceita pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("110") ||
                        (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("205") ||
                        (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("301") ||
                        (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("302") ||
                        (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("303")) &&
                        (bsLoteNFE.Current as TRegistro_LanLoteNFE).Tp_ambiente.Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido REABRIR NF-e DENEGADA pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE_X_NotaFiscal.ReabrirNfeProcessar(
                            bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal, null);
                        MessageBox.Show("NF-e pronta para ser processada novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNFCe))
            {
                if (bsLote_x_NFCe.Current != null)
                {
                    if ((bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Status.Equals(103) ||
                        (bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Status.Equals(105))
                    {
                        MessageBox.Show("Não é permitido REABRIR NFC-e de um lote ainda não processado pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("100") ||
                         (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("150")) &&
                        (bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Tp_ambiente.Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido REABRIR NFC-e aceita pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("110") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("205") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("233") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("234") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("301") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("302") ||
                        (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("303")) &&
                        (bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Tp_ambiente.Trim().Equals("1"))
                    {
                        MessageBox.Show("Não é permitido REABRIR NFC-e DENEGADA pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Faturamento.NFCe.TCN_Lote_X_NFCe.ReabrirNFCeProcessar(
                            bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe, null);
                        MessageBox.Show("NFC-e pronta para ser processada novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNfse))
            {
                if (bsLoteRPS.Current != null)
                {
                    if (!string.IsNullOrEmpty((bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Nr_protocolo))
                    {
                        MessageBox.Show("Permitido excluir somente lote não enviado para prefeitura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.ReabrirLoteRPS(bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS, null);
                        MessageBox.Show("Lote RPS EXCLUIDO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca(false);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void InutilizarNfe()
        {
            if (empresa.SelectedValue != null)
            {
                using (TFInutilizarNfe fInutilizar = new TFInutilizarNfe())
                {
                    fInutilizar.Cd_empresa = empresa.SelectedValue.ToString();
                    fInutilizar.Nm_empresa = empresa.Text;
                    if (fInutilizar.ShowDialog() == DialogResult.OK)
                    {
                        //Buscar CfgNfe
                        TRegistro_CfgNfe rCfg =
                            TCN_CfgNfe.Buscar(fInutilizar.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null)[0];
                        try
                        {
                            if (fInutilizar.Cd_modelo.Trim().Equals("55"))
                            {
                                srvNFE.InutilizarNFE.InutilizarNFE2.InutilizarNfe2(rCfg.Cd_uf_empresa,
                                                                                   rCfg.Cnpj_empresa,
                                                                                   fInutilizar.Nr_serie,
                                                                                   fInutilizar.Cd_modelo,
                                                                                   fInutilizar.Ano.ToString(),
                                                                                   fInutilizar.Nfeini,
                                                                                   fInutilizar.Nfefin,
                                                                                   fInutilizar.Justificativa,
                                                                                   rCfg);
                                MessageBox.Show("Sequencia NF-e inutilizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                NFCe.InutilizaNFCe.TInutilizaNFCe.InutilizarNFCe(rCfg.Cd_uf_empresa,
                                                                                 rCfg.Cnpj_empresa,
                                                                                 fInutilizar.Nr_serie,
                                                                                 fInutilizar.Cd_modelo,
                                                                                 fInutilizar.Ano.ToString(),
                                                                                 fInutilizar.Nfeini,
                                                                                 fInutilizar.Nfefin,
                                                                                 fInutilizar.Justificativa,
                                                                                 rCfg);
                                MessageBox.Show("Sequencia NFC-e inutilizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe empresa configurada para inutilizar sequencia NF-e", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GerarArqXmlNfe()
        {
            using (TFGerarXmlNfe fXmlNfe = new TFGerarXmlNfe())
            {
                fXmlNfe.St_nfce = tcNf.SelectedTab.Equals(tpNFCe);
                fXmlNfe.ShowDialog();
            }
        }

        private void afterPrint()
        {
            if (tcNf.SelectedTab.Equals(tpNfe))
            {
                if (bsLoteNFE_X_NotaFiscal.Current != null)
                {
                    if (!(bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.ToString().Trim().Equals("100"))
                    {
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource BinDados = new BindingSource();
                        TRegistro_LanFaturamento rNf =
                            TCN_LanFaturamento.BuscarNF(
                                                (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Cd_empresa,
                                                (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Nr_lanctofiscal.ToString(),
                                                null);
                        //Buscar itens da nota fiscal
                        rNf.ItensNota = TCN_LanFaturamento_Item.Busca(rNf.Cd_empresa,
                                                                      rNf.Nr_lanctofiscalstr,
                                                                      string.Empty,
                                                                      null);
                        if (rNf.rEmpresa.rEndereco == null)
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco emp = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();

                            emp = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rNf.rEmpresa.Cd_clifor, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 1, null);

                            if (emp.Count > 0)
                                rNf.rEmpresa.rEndereco = emp[0];
                        }
                        Rel.Parametros_Relatorio.Add("VL_IPI", rNf.ItensNota.Sum(v => v.Vl_ipi));
                        Rel.Parametros_Relatorio.Add("VL_ICMS", rNf.ItensNota.Sum(v => v.Vl_icms + v.Vl_FCP));
                        Rel.Parametros_Relatorio.Add("VL_BASEICMS", rNf.ItensNota.Sum(v => v.Vl_basecalcICMS));
                        Rel.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNf.ItensNota.Sum(v => v.Vl_basecalcSTICMS));
                        Rel.Parametros_Relatorio.Add("VL_ICMSSUBST", rNf.ItensNota.Sum(v => v.Vl_ICMSST + v.Vl_FCPST));
                        //Buscar conf impressao da nota fiscal
                        object obj = new TCD_CFGImpNF().BuscarEscalar(
                                        new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rNf.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_serie",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rNf.Nr_serie.Trim() + "'"
                                    }
                                }, "a.QT_ItensNota");
                        if (obj != null)
                            if (rNf.ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                while (rNf.ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                    rNf.ItensNota.Add(new TRegistro_LanFaturamento_Item());
                        BinDados.DataSource = new TList_RegLanFaturamento() { rNf };
                        Rel.DTS_Relatorio = BinDados;
                        //Buscar financeiro da DANFE
                        TList_RegLanParcela lParc =
                            new TCD_LanParcela().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'L'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                "inner join tb_fat_notafiscal_x_duplicata y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                                "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and y.cd_empresa = '" + rNf.Cd_empresa.Trim() + "' " +
                                                                "and y.nr_lanctofiscal = " + rNf.Nr_lanctofiscalstr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                        if (lParc.Count == 0)
                        {
                            //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                            lParc =
                                new TCD_LanParcela().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'L'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                    "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.nr_lancto = y.nr_lancto " +
                                                                    "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                                    "on y.cd_empresa = k.cd_empresa " +
                                                                    "and y.id_cupom = k.id_vendarapida " +
                                                                    "inner join TB_FAT_ECFVinculadoNF z " +
                                                                    "on k.cd_empresa = z.cd_empresa " +
                                                                    "and k.id_cupom = z.id_cupom " +
                                                                    "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                    "and x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and z.cd_empresa = '" + rNf.Cd_empresa.Trim() + "' " +
                                                                    "and z.nr_lanctofiscal = " + rNf.Nr_lanctofiscalstr + ")"
                                                    }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            if (lParc.Count == 0)
                            {
                                //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                                lParc =
                                    new TCD_LanParcela().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNf.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNf.Nr_lanctofiscalstr + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            }
                            if (lParc.Count == 0 &&
                                new TCD_LanFaturamento_CMI().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rNf.Cd_empresa.Trim() + "'" },
                                        new TpBusca{ vNM_Campo = "a.nr_lanctofiscal", vOperador = "=", vVL_Busca = rNf.Nr_lanctofiscalstr },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_devolucao, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_complementar, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_simplesremessa, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_compdevimposto, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_remessatransp, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                                        new TpBusca{ vNM_Campo = "isnull(a.st_retorno, 'N')", vOperador = "<>", vVL_Busca = "'S'" }

                                    }, "1") != null)
                            {
                                //Verificar se pedido de origem gerou financeiro
                                lParc = new TCD_LanParcela().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca{ vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'L'" },
                                        new TpBusca
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.nr_pedido = " + rNf.Nr_pedidostring + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            }
                        }
                        if (lParc.Count > 0)
                        {
                            for (int i = 0; i < lParc.Count; i++)
                            {
                                if (i < 12)
                                {
                                    Rel.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                    Rel.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                                }
                                else
                                    break;
                            }
                        }
                        Rel.Nome_Relatorio = "TFLanFaturamento_Danfe";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = "FAT";
                        Rel.Ident = "TFLanFaturamento_Danfe";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "DANFE";
                        fImp.St_danfe = false;
                        if (rNf.rEmpresa.Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", rNf.rEmpresa.Img);
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
                                               "DANFE",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                        }
                        else
                            fImp.pCd_clifor = (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Cd_clifor;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        {
                            List<string> Anexo = null;
                            if (fImp.St_receberXmlNfe)
                            {
                                string path_anexo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                                if (!string.IsNullOrEmpty(path_anexo))
                                {
                                    if (!System.IO.Directory.Exists(path_anexo))
                                        System.IO.Directory.CreateDirectory(path_anexo);
                                    if (!path_anexo.EndsWith("\\"))
                                        path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();
                                    try
                                    {
                                        srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(path_anexo,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      rNf.Cd_empresa,
                                                                                      rNf.Nr_notafiscal.ToString(),
                                                                                      TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                                                                                            string.Empty,
                                                                                                                                            string.Empty,
                                                                                                                                            null)[0]);
                                    }
                                    catch { }
                                    if (System.IO.File.Exists(path_anexo + rNf.Chave_acesso_nfe.Trim() + "-nfe.xml"))
                                    {
                                        //Ler arquivo gerado
                                        Anexo = new List<string>();
                                        Anexo.Add(path_anexo + rNf.Chave_acesso_nfe.Trim() + "-nfe.xml");
                                    }
                                }
                            }
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               Anexo,
                                               "DANFE",
                                               fImp.pDs_mensagem);
                        }
                    }
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNFCe))
            {
                if (tcNFCe.SelectedTab.Equals(tpLoteNFCe))
                {
                    if (bsLote_x_NFCe.Current != null)
                    {
                        if (!(bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("100") &&
                            !(bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.ToString().Trim().Equals("150"))
                        {
                            MessageBox.Show("Permitido imprimir DANFE somente de NFC-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            BindingSource dts = new BindingSource();
                            dts.DataSource = new TList_NFCe_Item();
                            Rel.DTS_Relatorio = dts;// bsItens;
                                                    //DTS Cupom
                            BindingSource bsNFCe = new BindingSource();
                            bsNFCe.DataSource = new TList_NFCe
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
                                                                                  (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr,
                                                                                  null)
                            };
                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                            //Buscar Empresa
                            BindingSource bsEmpresa = new BindingSource();
                            bsEmpresa.DataSource = new TList_CadEmpresa() { (bsNFCe.Current as TRegistro_NFCe).rEmpresa };
                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                            //Forma Pagamento
                            BindingSource bsPagto = new BindingSource();
                            if ((bsNFCe.Current as TRegistro_NFCe).lDup.Count > 0)
                                (bsNFCe.Current as TRegistro_NFCe).lPagto.Add(new TRegistro_MovCaixa()
                                {
                                    Tp_portador = "05",
                                    Vl_recebido = (bsNFCe.Current as TRegistro_NFCe).lDup[0].Vl_documento
                                });
                            if ((bsNFCe.Current as TRegistro_NFCe).lPagto.Count.Equals(0))
                                (bsNFCe.Current as TRegistro_NFCe).lPagto.Add(new TRegistro_MovCaixa()
                                {
                                    Tp_portador = "01",
                                    Vl_recebido = (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(r => r.Vl_subtotal)
                                });
                            bsPagto.DataSource = (bsNFCe.Current as TRegistro_NFCe).lPagto;
                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                            //Parametros
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                            object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_lote = a.id_lote " +
                                                                "and x.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + " " +
                                                                "and x.status = '100')"
                                                }
                                            }, "a.tp_ambiente");
                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                  (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                  null);
                            string placarel = string.Empty;
                            if (!string.IsNullOrEmpty(dadoscf))
                            {
                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                string km = string.Empty;
                                string frota = string.Empty;
                                string requisicao = string.Empty;
                                string nm_motorista = string.Empty;
                                string cpf_motorista = string.Empty;
                                string media = string.Empty;
                                string virg = string.Empty;
                                foreach (string s in linhas)
                                {
                                    string[] colunas = s.Split(new char[] { '/' });
                                    if (colunas.Length >= 1)
                                        placarel += virg + colunas[0];
                                    if (colunas.Length >= 2)
                                        km += virg + colunas[1];
                                    if (colunas.Length >= 3)
                                        frota += virg + colunas[2];
                                    if (colunas.Length >= 4)
                                        requisicao += virg + colunas[3];
                                    if (colunas.Length >= 5)
                                        nm_motorista += virg + colunas[4];
                                    if (colunas.Length >= 6)
                                        cpf_motorista += virg + colunas[5];
                                    if (colunas.Length >= 7)
                                        media += virg + colunas[6];
                                    virg = ",";
                                }
                                if (!string.IsNullOrEmpty(placarel))
                                    Rel.Parametros_Relatorio.Add("PLACA", placarel);
                                if (!string.IsNullOrEmpty(km))
                                    Rel.Parametros_Relatorio.Add("KM", km);
                                if (!string.IsNullOrEmpty(media))
                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                if (!string.IsNullOrEmpty(frota))
                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                if (!string.IsNullOrEmpty(requisicao))
                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                if (!string.IsNullOrEmpty(nm_motorista))
                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                if (!string.IsNullOrEmpty(cpf_motorista))
                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                            }

                            //Pontos Fidelidade
                            object pontos_fidelidade = null;
                            if (bsNFCe.Count > 0 && !string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Cd_clifor))
                                pontos_fidelidade = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = (bsNFCe.Current as TRegistro_NFCe).Cd_clifor
                                    },
                                    new TpBusca()
                                    {
                                        vOperador = "convert",
                                        vVL_Busca = "(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    }
                                    }, "sum(a.qt_pontos - a.pontos_res)");
                            if (!string.IsNullOrEmpty(placarel))
                                pontos_fidelidade = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.placa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + placarel + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vOperador = "convert",
                                        vVL_Busca = "(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    }
                                    }, "sum(a.qt_pontos - a.pontos_res)");
                            if (pontos_fidelidade != null && !string.IsNullOrEmpty(pontos_fidelidade.ToString()))
                                Rel.Parametros_Relatorio.Add("PONTOS_FIDELIDADE", pontos_fidelidade.ToString());

                            Rel.Nome_Relatorio = "DANFE_NFCE";
                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "DANFE_NFCE";
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "DANFE NFC-e";
                            fImp.St_danfenfce = true;
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
                                                   "DANFE NFC-e",
                                                   fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                            else
                            {
                                fImp.pCd_clifor = (bsNFCe.Current as TRegistro_NFCe).Cd_clifor;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                {
                                    if (fImp.St_danfenfcedetalhada)
                                    {
                                        BindingSource bsItens = new BindingSource();
                                        bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                        Rel.DTS_Relatorio = bsItens;
                                    }
                                    if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                        fImp.St_viaestabelecimento)
                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                        else
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                    Rel.Gera_Relatorio(string.Empty,
                                                       fImp.pSt_imprimir,
                                                       fImp.pSt_visualizar,
                                                       fImp.pSt_enviaremail,
                                                       fImp.pSt_exportPdf,
                                                       fImp.Path_exportPdf,
                                                       fImp.pDestinatarios,
                                                       null,
                                                       "DANFE NFC-e",
                                                       fImp.pDs_mensagem);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (bsNFCeEnviar.Current != null)
                    {
                        if (!(bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                        {
                            MessageBox.Show("Permitido reimprimir somente NFC-e emitida em contingencia.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            BindingSource dts = new BindingSource();
                            dts.DataSource = new TList_NFCe_Item();
                            Rel.DTS_Relatorio = dts;// bsItens;
                                                    //DTS Cupom
                            BindingSource bsNFCe = new BindingSource();
                            bsNFCe.DataSource = new TList_NFCe
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                                  (bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                  null)
                            };
                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                            //Buscar Empresa
                            BindingSource bsEmpresa = new BindingSource();
                            bsEmpresa.DataSource = new TList_CadEmpresa() { (bsNFCe.Current as TRegistro_NFCe).rEmpresa };
                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                            //Forma Pagamento
                            BindingSource bsPagto = new BindingSource();
                            if ((bsNFCe.Current as TRegistro_NFCe).lDup.Count > 0)
                                (bsNFCe.Current as TRegistro_NFCe).lPagto.Add(new TRegistro_MovCaixa()
                                {
                                    Tp_portador = "05",
                                    Vl_recebido = (bsNFCe.Current as TRegistro_NFCe).lDup[0].Vl_documento
                                });
                            bsPagto.DataSource = (bsNFCe.Current as TRegistro_NFCe).lPagto;
                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                            //Parametros
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", "1");//Produção
                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                  (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                  null);
                            string placarel = string.Empty;
                            if (!string.IsNullOrEmpty(dadoscf))
                            {
                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                string km = string.Empty;
                                string frota = string.Empty;
                                string requisicao = string.Empty;
                                string nm_motorista = string.Empty;
                                string cpf_motorista = string.Empty;
                                string media = string.Empty;
                                string virg = string.Empty;
                                foreach (string s in linhas)
                                {
                                    string[] colunas = s.Split(new char[] { '/' });
                                    placarel += virg + colunas[0];
                                    km += virg + colunas[1];
                                    frota += virg + colunas[2];
                                    requisicao += virg + colunas[3];
                                    nm_motorista += virg + colunas[4];
                                    cpf_motorista += virg + colunas[5];
                                    media += virg + colunas[6];
                                    virg = ",";
                                }
                                if (!string.IsNullOrEmpty(placarel))
                                    Rel.Parametros_Relatorio.Add("PLACA", placarel);
                                if (!string.IsNullOrEmpty(km))
                                    Rel.Parametros_Relatorio.Add("KM", km);
                                if (!string.IsNullOrEmpty(media))
                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                if (!string.IsNullOrEmpty(frota))
                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                if (!string.IsNullOrEmpty(requisicao))
                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                if (!string.IsNullOrEmpty(nm_motorista))
                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                if (!string.IsNullOrEmpty(cpf_motorista))
                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                            }

                            //Pontos Fidelidade
                            object pontos_fidelidade = null;
                            if (bsNFCe.Count > 0 && !string.IsNullOrEmpty((bsNFCe.Current as TRegistro_NFCe).Cd_clifor))
                                pontos_fidelidade = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = (bsNFCe.Current as TRegistro_NFCe).Cd_clifor
                                    },
                                    new TpBusca()
                                    {
                                        vOperador = "convert",
                                        vVL_Busca = "(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    }
                                    }, "sum(a.qt_pontos - a.pontos_res)");
                            if (!string.IsNullOrEmpty(placarel))
                                pontos_fidelidade = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.placa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + placarel + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vOperador = "convert",
                                        vVL_Busca = "(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    }
                                    }, "sum(a.qt_pontos - a.pontos_res)");
                            if (pontos_fidelidade != null && !string.IsNullOrEmpty(pontos_fidelidade.ToString()))
                                Rel.Parametros_Relatorio.Add("PONTOS_FIDELIDADE", pontos_fidelidade.ToString());

                            Rel.Nome_Relatorio = "DANFE_NFCE";
                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "DANFE_NFCE";
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "DANFE NFC-e";
                            fImp.St_danfenfce = true;
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
                                                   "DANFE NFC-e",
                                                   fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                            else
                            {
                                fImp.pCd_clifor = (bsNFCe.Current as TRegistro_NFCe).Cd_clifor;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                {
                                    if (fImp.St_danfenfcedetalhada)
                                    {
                                        BindingSource bsItens = new BindingSource();
                                        bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                        Rel.DTS_Relatorio = bsItens;
                                    }
                                    if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                        fImp.St_viaestabelecimento)
                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                        else
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                    Rel.Gera_Relatorio(string.Empty,
                                                       fImp.pSt_imprimir,
                                                       fImp.pSt_visualizar,
                                                       fImp.pSt_enviaremail,
                                                       fImp.pSt_exportPdf,
                                                       fImp.Path_exportPdf,
                                                       fImp.pDestinatarios,
                                                       null,
                                                       "DANFE NFC-e",
                                                       fImp.pDs_mensagem);
                                }
                            }
                        }
                    }
                }
            }
            else if (tcNf.SelectedTab.Equals(tpNfse))
            {
                if (bsNfes.Current != null)
                {
                    if (string.IsNullOrEmpty((bsNfes.Current as TRegistro_LanFaturamento).Nr_protocolo))
                    {
                        MessageBox.Show("Não é permitido imprimir NFS-e sem Nº DE AUTENTIÇÃO.\r\n" +
                                        "Clique no botão <Consultar Autenticação NFS-e> para obter o Nº AUTENTICAÇÃO.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsNfes.Current as TRegistro_LanFaturamento).ItensNota =
                        TCN_LanFaturamento_Item.Busca(
                        (bsNfes.Current as TRegistro_LanFaturamento).Cd_empresa,
                        (bsNfes.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString(),
                        string.Empty,
                        null);
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {

                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;

                        BindingSource BinDadosNFSE = new BindingSource();
                        BinDadosNFSE.DataSource = new TList_RegLanFaturamento() { bsNfes.Current as TRegistro_LanFaturamento };

                        Rel.DTS_Relatorio = BinDadosNFSE;
                        (bsNfes.Current as TRegistro_LanFaturamento).rClifor =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsNfes.Current as TRegistro_LanFaturamento).Cd_clifor, null);

                        (bsNfes.Current as TRegistro_LanFaturamento).rClifor.lEndereco =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsNfes.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                      (bsNfes.Current as TRegistro_LanFaturamento).Cd_endereco,
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
                        (bsNfes.Current as TRegistro_LanFaturamento).rEmpresa =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsNfes.Current as TRegistro_LanFaturamento).Cd_empresa, string.Empty, string.Empty, null)[0];
                        //Buscar Imposto ISS
                        //(bsNfes.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                        //    {
                        //        TRegistro_ImpostosNF rISS = p.ImpostosItens.Where(x => x.Imposto.St_issqnbool).FirstOrDefault();
                        //        if (rISS != null)
                        //        {
                        //            if (rISS.Pc_reducaobasecalc > decimal.Zero)
                        //            {
                        //                p.vl_de Vl_deducaoISS = Math.Round(decimal.Multiply(rISS.Vl_basecalc, decimal.Divide(rISS.Pc_reducaobasecalc, 100)), 2, MidpointRounding.AwayFromZero);
                        //                p.Vl_basecalcISS = rISS.Vl_basecalc - p.Vl_deducaoISS;
                        //            }
                        //            else
                        //                p.Vl_basecalcISS = rISS.Vl_basecalc;
                        //            p.Pc_aliquotaISS = rISS.Pc_aliquota;
                        //            p.Vl_iss = rISS.Vl_impostocalc + rISS.Vl_impostoretido;
                        //            p.Vl_ISS_Ret = rISS.Vl_impostoretido;
                        //            p.Ds_deducaoISS = rISS.Ds_deducao;
                        //        }
                        //    });
                        Rel.Parametros_Relatorio.Add("TOT_ISS", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_iss));
                        Rel.Parametros_Relatorio.Add("TOT_ISS_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_issretido));
                        Rel.Parametros_Relatorio.Add("TOT_COFINS_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_retidoCofins));
                        Rel.Parametros_Relatorio.Add("TOT_PIS_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_retidoPIS));
                        Rel.Parametros_Relatorio.Add("TOT_IRRF_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_retidoIRRF));
                        Rel.Parametros_Relatorio.Add("TOT_CSLL_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_retidoCSLL));
                        Rel.Parametros_Relatorio.Add("TOT_INSS_RET", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota.Sum(p => p.Vl_retidoINSS));
                        Rel.Parametros_Relatorio.Add("TP_NATUREZAOPERACAOISS", (bsNfes.Current as TRegistro_LanFaturamento).ItensNota[0].Tp_naturezaOperacaoISS);
                        Rel.Nome_Relatorio = "TFLanConsultaNFe";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = "FAT";
                        Rel.Ident = "TFLanFaturamento_NFSE";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNfes.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NFSE";

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
                                               "NFSE",
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
                                               "NFSE",
                                               fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void AtualizarCamposTela()
        {
            if (empresa.SelectedValue != null)
            {
                TList_CfgNfe lCfg =
                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                if (lCfg.Count > 0)
                {
                    if (string.IsNullOrEmpty(lCfg[0].Tp_ambiente))
                        if (tcNf.TabPages.Contains(tpNfe))
                            tcNf.TabPages.Remove(tpNfe);
                    if (string.IsNullOrEmpty(lCfg[0].Tp_ambiente_nfce))
                        if (tcNf.TabPages.Contains(tpNFCe))
                            tcNf.TabPages.Remove(tpNFCe);
                    if (string.IsNullOrEmpty(lCfg[0].Tp_ambiente_nfes))
                        if (tcNf.TabPages.Contains(tpNfse))
                            tcNf.TabPages.Remove(tpNfse);
                }
                if (tcNf.SelectedTab.Equals(tpNfe))
                {
                    object obj = new TCD_CfgNfe().BuscarEscalar(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                                }
                            }, "a.tp_ambiente + '-' + a.cd_versao");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    {
                        string[] part = obj.ToString().Split(new char[] { '-' });
                        lblAmbiente.Text = part[0].Trim().ToUpper().Equals("H") ? "HOMOLOGAÇÃO" : "PRODUÇÃO";
                        tsVersao.Text = part[1].Trim();
                    }
                }
                else if (tcNf.SelectedTab.Equals(tpNFCe))
                {
                    object obj = new TCD_CfgNfe().BuscarEscalar(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                                }
                            }, "a.tp_ambiente_nfce + '-' + a.cd_versaonfce");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    {
                        string[] part = obj.ToString().Split(new char[] { '-' });
                        lblAmbiente.Text = part[0].Trim().ToUpper().Equals("1") ? "PRODUÇÃO" : "HOMOLOGAÇÃO";
                        tsVersao.Text = part[1].Trim();
                    }
                }
                else if (tcNf.SelectedTab.Equals(tpNfse))
                {
                    object obj = new TCD_CfgNfe().BuscarEscalar(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + empresa.SelectedValue.ToString().Trim() + "'"
                                }
                            }, "a.tp_ambiente_nfes");
                    if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    {
                        lblAmbiente.Text = obj.ToString().Trim().ToUpper().Equals("H") ? "HOMOLOGAÇÃO" : "PRODUÇÃO";
                        tsVersao.Text = string.Empty;
                        tsStatus.Text = string.Empty;
                    }
                }
                afterBusca(false);
            }
        }

        private void ReprocessarImpostos(bool St_nfce)
        {
            if (St_nfce)
            {
                (bsNFCeEnviar.Current as TRegistro_NFCe).lItem.ForEach(p =>
                {
                    //Buscar config cupom fiscal
                    TList_CFGCupomFiscal lCfg =
                        TCN_CFGCupomFiscal.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa, null);
                    //Reprocessar impostos da nota
                    TList_ImpostosNF lImpNf =
                        TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lCfg[0].Cd_condfiscal_clifor,
                                                                            p.Cd_condfiscal_produto,
                                                                            (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_movimentacaostr,
                                                                            "S",
                                                                            lCfg[0].Tp_pessoa,
                                                                            (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                            (bsNFCeEnviar.Current as TRegistro_NFCe).Nr_serie,
                                                                            lCfg[0].Cd_clifor,
                                                                            string.Empty,
                                                                            (bsNFCeEnviar.Current as TRegistro_NFCe).Dt_emissao,
                                                                            decimal.Zero,
                                                                            p.Vl_subtotalliquido,
                                                                            "P",
                                                                            string.Empty,
                                                                            null);
                    if (lImpNf.Count > 0)
                    {
                        p.Cd_icms = lImpNf.First().Cd_imposto;
                        p.Cd_st_icms = lImpNf.First().Cd_st;
                        p.Pc_aliquotaICMS = lImpNf.First().Pc_aliquota;
                        p.Vl_icms = lImpNf.First().Vl_impostocalc;
                        p.Vl_basecalcICMS = lImpNf.First().Vl_basecalc;
                        p.St_gerarCredito = lImpNf.First().St_gerarcreditobool;
                        p.Tp_situacao = lImpNf.First().Tp_situacao;
                        p.Tp_modbasecalc = lImpNf.First().Tp_modbasecalc;
                        p.Tp_modbasecalcST = lImpNf.First().Tp_modbasecalcST;
                    }
                    string vObsFiscal = string.Empty;
                    lImpNf.Concat(TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_uf_empresa,
                                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_uf_empresa,
                                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_movimentacaostr,
                                                                                                                    "S",
                                                                                                                    lCfg[0].Cd_condfiscal_clifor,
                                                                                                                    p.Cd_condfiscal_produto,
                                                                                                                    p.Vl_subtotalliquido,
                                                                                                                    p.Quantidade,
                                                                                                                    ref vObsFiscal,
                                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Dt_emissao,
                                                                                                                    string.Empty,
                                                                                                                    "P",
                                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Nr_serie,
                                                                                                                    null));
                    if (lImpNf.Count > 0)
                    {
                        //Procurar PIS
                        TRegistro_ImpostosNF rPIS = lImpNf.Find(x => x.Imposto.St_PIS);
                        p.Cd_pis = rPIS.Cd_imposto;
                        p.Cd_st_pis = rPIS.Cd_st;
                        p.Id_tpcontribuicaoPIS = rPIS.Id_tpcontribuicao;
                        p.Id_detrecisentaPIS = rPIS.Id_detrecisenta;
                        p.Id_receitaPIS = rPIS.Id_receita;
                        p.Pc_aliquotaPIS = rPIS.Pc_aliquota;
                        p.Vl_pis = rPIS.Vl_impostocalc;
                        p.Vl_basecalcPIS = rPIS.Vl_basecalc;
                        p.St_gerarCredito = rPIS.St_gerarcreditobool;
                        p.Tp_situacao = rPIS.Tp_situacao;
                        //Procurar COFINS
                        TRegistro_ImpostosNF rCofins = lImpNf.Find(x => x.Imposto.St_Cofins);
                        p.Cd_cofins = rCofins.Cd_imposto;
                        p.Cd_st_cofins = rCofins.Cd_st;
                        p.Id_tpcontribuicaoCOFINS = rCofins.Id_tpcontribuicao;
                        p.Id_detrecisentaCofins = rCofins.Id_detrecisenta;
                        p.Id_receitaCofins = rCofins.Id_receita;
                        p.Pc_aliquotaCofins = rCofins.Pc_aliquota;
                        p.Vl_cofins = rCofins.Vl_impostocalc;
                        p.Vl_basecalcCofins = rCofins.Vl_basecalc;
                        p.St_gerarCredito = rCofins.St_gerarcreditobool;
                        p.Tp_situacao = rCofins.Tp_situacao;
                    }
                });
                try
                {
                    TCN_ImpostosNF.ReprocessarImpostos(null,
                                                       null,
                                                       bsNFCeEnviar.Current as TRegistro_NFCe,
                                                       (bsNFCeEnviar.Current as TRegistro_NFCe).Vl_cupom,
                                                       null);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                (bsNFeEnviar.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                {
                    //Reprocessar impostos da nota
                    TList_ImpostosNF lImpNf =
                        TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                                                   p.Cd_condfiscal_produto,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_pessoa,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                                                   p.Cd_unidEst,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                                                   p.Quantidade,
                                                                                                                   p.Vl_basecalcImposto,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_municipioexecservico,
                                                                                                                   null);
                    string vObsFiscal = string.Empty;
                    lImpNf.Concat(TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ?
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_uf_clifor :
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_uf_empresa,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ?
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_uf_empresa :
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_uf_clifor,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                                                    p.Cd_condfiscal_produto,
                                                                                                                    p.Vl_basecalcImposto,
                                                                                                                    p.Quantidade,
                                                                                                                    ref vObsFiscal,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                                                    string.Empty,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                                                    (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                                                    null));
                    //Verificar se item da nota teve origem FIXAÇÃO
                    if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper().Equals("E"))
                    {
                        object obj = new CamadaDados.Graos.TCD_Fixacao_NF().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_lanctofiscal",
                                                vOperador = "=",
                                                vVL_Busca = p.Nr_lanctofiscal.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_nfitem",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_nfitem.ToString()
                                            }
                                        }, "isnull(a.vl_fixacao, 0)");
                        if (obj == null ? false : decimal.Parse(obj.ToString()) > decimal.Zero)
                        {
                            decimal vl_baseret = decimal.Parse(obj.ToString());
                            //Buscar numero contrato
                            obj = new CamadaDados.Graos.TCD_CadContrato().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_pedido.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pedidoitem",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_pedidoitemstr
                                        }
                                    }, "a.nr_contrato");
                            if (obj != null)
                            {
                                List<CamadaDados.Graos.TRegistro_ImpostosReter> lImpRet =
                                    TProcessaFixacao.CalcularImpostoReter(obj.ToString(), vl_baseret);
                                //Concatenar Impostos Reter Funrural/Senar com a base de calculo no valor total da fixação.
                                lImpRet.ForEach(x =>
                                {
                                    lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Vl_basecalc = x.Vl_basecalc;
                                    lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Pc_retencao = x.Pc_retencao;
                                    lImpNf.Find(v => v.Cd_imposto.Equals(x.Cd_imposto)).Vl_impostoretido = x.Vl_rentecao;
                                });
                            }
                        }
                    }
                    if (lImpNf.Exists(v => v.Imposto.St_ICMS))
                        TCN_LanFaturamento_Item.PreencherICMS(lImpNf.Find(v => v.Imposto.St_ICMS), p);
                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(lImpNf, p, (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_movimento);
                });
                TCN_ImpostosNF.ReprocessarImpostos(bsNFeEnviar.Current as TRegistro_LanFaturamento,
                                                   null,
                                                   null,
                                                   TCN_LanFaturamento.CalcTotalNota(bsNFeEnviar.Current as TRegistro_LanFaturamento),
                                                   null);
            }
        }

        private void TFLanConsultaNFe_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItensNota);
            ShapeGrid.RestoreShape(this, gNfeEnviar);
            ShapeGrid.RestoreShape(this, gNfseEnviar);
            ShapeGrid.RestoreShape(this, gLoteNfe);
            ShapeGrid.RestoreShape(this, gLote_X_NFe);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            pFiltro.set_FormatZero();
            Icon = ResourcesUtils.TecnoAliance_ICO;

            empresa.DataSource = new TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "EXISTS",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_cfgnfe x "+
                                                        "where x.cd_empresa = a.cd_empresa)"
                                        }
                                    }, 0, string.Empty);
            empresa.DisplayMember = "NM_Empresa";
            empresa.ValueMember = "CD_Empresa";
            if (Tp_documento.Trim().ToUpper().Equals("NFE"))
                tcNf.SelectedTab = tpNfe;
            else if (Tp_documento.Trim().ToUpper().Equals("NFCE"))
                tcNf.SelectedTab = tpNFCe;
            if ((empresa.DataSource as TList_CadEmpresa).Count > 0)
            {
                empresa.SelectedIndex = 0;
                empresa_SelectedIndexChanged(this, new EventArgs());
            }
            ConsultaStatusServico();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            EnviarNfe();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            ConsultarLoteNfe();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            ReabrirLoteProcessar();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca(false);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            InutilizarNfe();
        }

        private void BB_GerarXmlNfe_Click(object sender, EventArgs e)
        {
            GerarArqXmlNfe();
        }

        private void bsLoteNFE_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteNFE.Current != null)
            {
                TpBusca[] filtro = new TpBusca[0];
                if (!string.IsNullOrEmpty((bsLoteNFE.Current as TRegistro_LanLoteNFE).Id_lote.ToString()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = (bsLoteNFE.Current as TRegistro_LanLoteNFE).Id_lote.ToString();
                }
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Status";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'205'";


                (bsLoteNFE.Current as TRegistro_LanLoteNFE).lNfe = new TCD_LanLoteNFE_X_NotaFiscal().Select(filtro, 0, string.Empty);
                bsLoteNFE.ResetCurrentItem();
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFLanConsultaNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                EnviarNfe();
            else if (e.KeyCode.Equals(Keys.F3))
                ConsultarLoteNfe();
            else if (e.KeyCode.Equals(Keys.F5))
                ReabrirLoteProcessar();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca(false);
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                InutilizarNfe();
            else if (e.KeyCode.Equals(Keys.F10))
                GerarArqXmlNfe();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCamposTela();
        }

        private void tcNf_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCamposTela();
            bb_inutilizar.Visible = tcNf.SelectedTab.Equals(tpNfe) || tcNf.SelectedTab.Equals(tpNFCe);
            BB_GerarXmlNfe.Visible = tcNf.SelectedTab.Equals(tpNfe) || tcNf.SelectedTab.Equals(tpNFCe);
            bb_confDivida.Visible = tcNf.SelectedTab.Equals(tpNFCe);
            ConsultaStatusServico();
        }

        private void bsLoteRPS_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteRPS.Current != null)
            {
                //Buscar Notas
                (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).lNfes =
                    CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.BuscarNfes(
                    (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Id_lotestr,
                    (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Cd_empresa,
                    null);
                //Buscar Mensagens
                (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).lMsgRPS =
                    CamadaNegocio.Faturamento.NFES.TCN_MsgRetornoRPS.Buscar(
                    (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Id_lotestr,
                    (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Cd_empresa,
                    null);
                bsLoteRPS.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsNFeEnviar.Count > 0)
            {
                (bsNFeEnviar.DataSource as TList_RegLanFaturamento).ForEach(p => p.St_formarlotectrc = cbTodos.Checked);
                bsNFeEnviar.ResetBindings(true);
            }
        }

        private void gNfeEnviar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsNFeEnviar.Current as TRegistro_LanFaturamento).St_formarlotectrc =
                    !(bsNFeEnviar.Current as TRegistro_LanFaturamento).St_formarlotectrc;
                bsNFeEnviar.ResetCurrentItem();
            }
        }

        private void cbTodosNfse_Click(object sender, EventArgs e)
        {
            if (bsNFSeEnviar.Count > 0)
            {
                (bsNFSeEnviar.DataSource as TList_RegLanFaturamento).ForEach(p => p.St_formarlotectrc = cbTodos.Checked);
                bsNFSeEnviar.ResetBindings(true);
            }
        }

        private void gNfseEnviar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsNFSeEnviar.Current as TRegistro_LanFaturamento).St_formarlotectrc =
                    !(bsNFSeEnviar.Current as TRegistro_LanFaturamento).St_formarlotectrc;
                bsNFSeEnviar.ResetCurrentItem();
            }
        }

        private void tcNfse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcNfse.SelectedTab.Equals(tpNfseEnviar))
                afterBusca(false);
        }

        private void tcNfe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcNfe.SelectedTab.Equals(tpNfeEnviar))
                afterBusca(false);
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gNfeEnviar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gNfeEnviar.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsNFeEnviar.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanFaturamento());
            TList_RegLanFaturamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gNfeEnviar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gNfeEnviar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanFaturamento(lP.Find(gNfeEnviar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gNfeEnviar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanFaturamento(lP.Find(gNfeEnviar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gNfeEnviar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsNFeEnviar.List as TList_RegLanFaturamento).Sort(lComparer);
            bsNFeEnviar.ResetBindings(false);
            gNfeEnviar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gItensNota_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensNota.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensNota.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanFaturamento_Item());
            TList_RegLanFaturamento_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensNota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensNota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanFaturamento_Item(lP.Find(gItensNota.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensNota.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanFaturamento_Item(lP.Find(gItensNota.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensNota.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensNota.List as TList_RegLanFaturamento_Item).Sort(lComparer);
            bsItensNota.ResetBindings(false);
            gItensNota.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            if (bsNFeEnviar.Current != null)
            {
                //Buscar cadastro cliente
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_clifor, null);
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
                                afterBusca(false);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_cadproduto_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Current != null)
                using (TFAtualizaCadProduto fAtualiza = new TFAtualizaCadProduto())
                {
                    //Buscar cadastro produto
                    fAtualiza.rProd =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto, null);
                    if (fAtualiza.ShowDialog() == DialogResult.OK)
                        if (fAtualiza.rProd != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                                ReprocessarImpostos(false);
                                MessageBox.Show("Cadastro item atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca(false);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
        }

        private void TFLanConsultaNFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItensNota);
            ShapeGrid.SaveShape(this, gNfeEnviar);
            ShapeGrid.SaveShape(this, gNfseEnviar);
            ShapeGrid.SaveShape(this, gLoteNfe);
            ShapeGrid.SaveShape(this, gLote_X_NFe);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            //Coletar lixo memoria
            GC.Collect();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bsNFSeEnviar_PositionChanged(object sender, EventArgs e)
        {
            if (bsNFSeEnviar.Current != null)
                if ((bsNFSeEnviar.Current as TRegistro_LanFaturamento).ItensNota.Count.Equals(0))
                {
                    (bsNFSeEnviar.Current as TRegistro_LanFaturamento).ItensNota =
                        TCN_LanFaturamento_Item.Busca((bsNFSeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                           (bsNFSeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                                           string.Empty,
                                                                                           null);
                    bsNFSeEnviar.ResetCurrentItem();
                }
        }

        private void gLoteNfe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLoteNfe.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLoteNFE.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanLoteNFE());
            TList_LanLoteNFE lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLoteNfe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLoteNfe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanLoteNFE(lP.Find(gLoteNfe.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLoteNfe.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanLoteNFE(lP.Find(gLoteNfe.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLoteNfe.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLoteNFE.List as TList_LanLoteNFE).Sort(lComparer);
            bsLoteNFE.ResetBindings(false);
            gLoteNfe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void tsStatus_Click(object sender, EventArgs e)
        {
            ConsultaStatusServico();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bsNfes.Current != null)
            {
                if ((bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).St_lote.Trim() != "3")
                {
                    MessageBox.Show("Permitido consultar NFSe somente de lote PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsNfes.Current as TRegistro_LanFaturamento).Nr_protocolo))
                    try
                    {
                        TRegistro_CfgNfe rCfgNfe =
                                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null)[0];
                        CamadaDados.Faturamento.NFES.TRegistro_LoteRPS_X_NFES RPS =
                            CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.Buscar((bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Id_lotestr,
                                                                                     (bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Cd_empresa,
                                                                                     (bsNfes.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                                     null)[0];
                        string ret = NFES.TConsultarNfes.ConsultarNFSePorRPS(RPS.Nr_rps.Value, rCfgNfe);
                        if (!string.IsNullOrEmpty(ret))
                        {
                            XmlDocument documento = new XmlDocument();
                            documento.LoadXml(ret);
                            if (documento["es:esConsultarNfsePorRpsResposta"].ChildNodes.Count > 0)
                            {
                                RPS.Cd_autenticacao = documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["cdAutenticacao"].InnerText;
                                try
                                {
                                    RPS.Dt_autorizacao = DateTime.Parse(documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["dtEmissaoNfs"].InnerText);
                                }
                                catch { }
                                try
                                {
                                    RPS.Nr_nfse = decimal.Parse(documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["nrNfse"].InnerText);
                                }
                                catch { }
                                CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.Gravar(RPS, null);
                                CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.CorrigirNumeroNFSe(RPS, null);
                            }
                        }
                        afterBusca(false);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void gNFCeEnviar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsNFCeEnviar.Current as TRegistro_NFCe).St_processar =
                    !(bsNFCeEnviar.Current as TRegistro_NFCe).St_processar;
                bsNFCeEnviar.ResetCurrentItem();
            }
        }

        private void stTodosNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Count > 0)
            {
                (bsNFCeEnviar.List as TList_NFCe).ForEach(p => p.St_processar = cbTodos.Checked);
                bsNFCeEnviar.ResetBindings(true);
            }
        }

        private void tcNFCe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcNFCe.SelectedTab.Equals(tpNFCeEnviar))
                afterBusca(false);
        }

        private void bsLoteNFCe_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteNFCe.Current != null)
            {
                (bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).lLoteNCFe =
                    CamadaNegocio.Faturamento.NFCe.TCN_Lote_X_NFCe.Buscar((bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Cd_empresa,
                                                                          (bsLoteNFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe).Id_lotestr,
                                                                          string.Empty,
                                                                          null);
                bsLoteNFCe.ResetCurrentItem();
            }
        }

        private void gLoteNFCe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gLoteNFCe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gLoteNFCe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_confDivida_Click(object sender, EventArgs e)
        {
            if (bsLote_x_NFCe.Current != null)
                if ((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.HasValue)
                    if ((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.Value.Equals(100))
                    {
                        TList_RegLanDuplicata lDup =
                            new TCD_LanDuplicata().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                "on x.cd_empresa = y.cd_empresa " +
                                                "and x.id_cupom = y.id_vendarapida " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                "and y.cd_empresa = '" + (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa.Trim() + "' " +
                                                "and y.id_cupom = " + (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr + ")"
                                }
                            }, 1, string.Empty);
                        if (lDup.Count > 0)
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                Rel.Altera_Relatorio = Altera_Relatorio;
                                BindingSource dts = new BindingSource();
                                dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr,
                                                                                               string.Empty,
                                                                                               (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
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
                                                                                               false,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               1,
                                                                                               null);
                                Rel.DTS_Relatorio = dts;
                                //DTS Cupom
                                BindingSource bsItensNFCe = new BindingSource();
                                bsItensNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr,
                                                                                                            (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            null);
                                Rel.Adiciona_DataSource("DTS_ITENS", bsItensNFCe);
                                //Buscar Empresa
                                BindingSource bsEmpresa = new BindingSource();
                                bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   null);
                                Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                //Buscar Cliente Cupom 
                                if (!string.IsNullOrEmpty((dts.Current as TRegistro_NFCe).Cd_clifor))
                                {
                                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((dts.Current as TRegistro_NFCe).Cd_clifor, null);
                                    Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                                    Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                                }
                                else
                                {
                                    Rel.Parametros_Relatorio.Add("NM_CLIENTE", (dts.Current as TRegistro_NFCe).Nm_clifor);
                                    Rel.Parametros_Relatorio.Add("CPF_CLIENTE", (dts.Current as TRegistro_NFCe).Nr_cgc_cpf);
                                }
                                if (!string.IsNullOrEmpty((dts.Current as TRegistro_NFCe).Cd_clifor) &&
                                    !string.IsNullOrEmpty((dts.Current as TRegistro_NFCe).Cd_endereco))
                                {
                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((dts.Current as TRegistro_NFCe).Cd_clifor,
                                                                                              (dts.Current as TRegistro_NFCe).Cd_endereco,
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
                                    Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                                }
                                else Rel.Parametros_Relatorio.Add("ENDERECO", (dts.Current as TRegistro_NFCe).Ds_endereco.Trim());
                                string dadosdi = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((dts.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                      (dts.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                      null);
                                if (!string.IsNullOrEmpty(dadosdi))
                                {
                                    string[] linhas = dadosdi.Split(new char[] { ':' });
                                    string placa = string.Empty;
                                    string km = string.Empty;
                                    string frota = string.Empty;
                                    string requisicao = string.Empty;
                                    string nm_motorista = string.Empty;
                                    string cpf_motorista = string.Empty;
                                    string media = string.Empty;
                                    string virg = string.Empty;
                                    foreach (string s in linhas)
                                    {
                                        string[] colunas = s.Split(new char[] { '/' });
                                        placa += virg + colunas[0];
                                        km += virg + colunas[1];
                                        frota += virg + colunas[2];
                                        requisicao += virg + colunas[3];
                                        nm_motorista += virg + colunas[4];
                                        cpf_motorista += virg + colunas[5];
                                        media += virg + colunas[6];
                                        virg = ",";
                                    }
                                    if (!string.IsNullOrEmpty(placa))
                                        Rel.Parametros_Relatorio.Add("PLACA", placa);
                                    if (!string.IsNullOrEmpty(km))
                                        Rel.Parametros_Relatorio.Add("KM", km);
                                    if (!string.IsNullOrEmpty(media))
                                        Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                    if (!string.IsNullOrEmpty(frota))
                                        Rel.Parametros_Relatorio.Add("FROTA", frota);
                                    if (!string.IsNullOrEmpty(requisicao))
                                        Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                    if (!string.IsNullOrEmpty(nm_motorista))
                                        Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                    if (!string.IsNullOrEmpty(cpf_motorista))
                                        Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                }
                                //Buscar Valor Pago
                                decimal vl_pago = decimal.Zero;
                                List<TRegistro_MovCaixa> lPagto = new TCD_CaixaPDV().SelectMovCaixa(
                                                                                                new TpBusca[]
                                                                                                {
                                                                                                    new TpBusca()
                                                                                                    {
                                                                                                        vNM_Campo = string.Empty,
                                                                                                        vOperador = "exists",
                                                                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                                                                    "and x.cd_empresa = '" + (dts.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                                                                    "and x.id_cupom = " + (dts.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                                                                    }
                                                                                                }, string.Empty);
                                if (lPagto.Count > 0)
                                    vl_pago = lPagto.Sum(p => p.Vl_recebidoliq);
                                vl_pago += lDup.Sum(p => p.Vl_liquidado);
                                Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                                Rel.Parametros_Relatorio.Add("VL_PAGAR", lDup.Sum(p => p.Vl_atual));
                                Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", (dts.Current as TRegistro_NFCe).NR_NFCestr);
                                Rel.Parametros_Relatorio.Add("DT_EMISSAO", (dts.Current as TRegistro_NFCe).Dt_emissaostr);
                                Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", (dts.Current as TRegistro_NFCe).Chave_acesso);
                                Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", "0");//1-NF-e;0-NFC-e
                                Rel.Nome_Relatorio = "CONFISSAO_DIVIDA";
                                Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                Rel.Modulo = "FAT";
                                Rel.Ident = "CONFISSAO_DIVIDA";
                                fImp.pCd_clifor = (dts.Current as TRegistro_NFCe).Cd_clifor;
                                fImp.pMensagem = "CONFISSÃO DIVIDA";
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
                                                       "CONFISSÃO DIVIDA",
                                                       fImp.pDs_mensagem);
                                    Altera_Relatorio = false;
                                }
                                else
                                {
                                    fImp.pCd_clifor = (dts.Current as TRegistro_NFCe).Cd_clifor;
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    {
                                        Rel.Gera_Relatorio(string.Empty,
                                                           fImp.pSt_imprimir,
                                                           fImp.pSt_visualizar,
                                                           fImp.pSt_enviaremail,
                                                           fImp.pSt_exportPdf,
                                                           fImp.Path_exportPdf,
                                                           fImp.pDestinatarios,
                                                           null,
                                                           "CONFISSÃO DIVIDA",
                                                           fImp.pDs_mensagem);
                                    }
                                }
                            }
                        else MessageBox.Show("NFC-e não gerou duplicata para imprimir CONFISSÃO DE DIVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
        }

        private void bb_consultanfce_Click(object sender, EventArgs e)
        {
            if (bsLote_x_NFCe.Current != null)
                if (!string.IsNullOrEmpty((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Chave_acesso) &&
                    !string.IsNullOrEmpty((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Tp_ambiente))
                {
                    if ((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.HasValue)
                        if ((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Status.Value.Equals(100))
                        {
                            MessageBox.Show("NFC-e já esta com status 100-Autorizado o uso da NF-e", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    //Buscar CfgNfe
                    TRegistro_CfgNfe rCfgNfe =
                        TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                          string.Empty,
                                          string.Empty,
                                          null)[0];
                    try
                    {
                        string ret = NFCe.ConsultaChave.TConsultaChave.ConsultaChave((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Chave_acesso,
                                                                                    (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Tp_ambiente,
                                                                                    rCfgNfe);
                        if (string.IsNullOrEmpty(ret))
                            MessageBox.Show("NFC-e não encontrado para a chave de acesso: " + (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Chave_acesso,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            string[] v = ret.Split(new char[] { '|' });
                            if (v.Length > 0)
                                try
                                {
                                    CamadaNegocio.Faturamento.NFCe.TCN_Lote_X_NFCe.AtualizarDadosNFCe((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
                                                                                                      (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_lotestr,
                                                                                                      (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr,
                                                                                                      v[0],
                                                                                                      v[1],
                                                                                                      v[2],
                                                                                                      v[3],
                                                                                                      v[4],
                                                                                                      v[5],
                                                                                                      null);
                                    MessageBox.Show("NFC-e atualizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca(false);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro consultar NFCe: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_consultaNFe_Click(object sender, EventArgs e)
        {
            if (bsLoteNFE_X_NotaFiscal.Current != null)
                if (!string.IsNullOrEmpty((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Chave_acesso_nfe) &&
                    !string.IsNullOrEmpty((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Tp_ambiente))
                {
                    if ((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.HasValue)
                        if ((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Status.Value.Equals(100))
                        {
                            MessageBox.Show("NF-e já esta com status 100-Autorizado o uso da NF-e", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    //Buscar CfgNfe
                    TRegistro_CfgNfe rCfgNfe =
                        TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                          string.Empty,
                                          string.Empty,
                                          null)[0];
                    try
                    {
                        string ret = srvNFE.ConsultaChave.TConsultaChave.ConsultaChave((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Chave_acesso_nfe,
                                                                                       (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Tp_ambiente,
                                                                                       rCfgNfe);
                        if (string.IsNullOrEmpty(ret))
                            MessageBox.Show("NF-e não encontrado para a chave de acesso: " + (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Chave_acesso_nfe,
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            string[] v = ret.Split(new char[] { '|' });
                            if (v.Length > 0)
                                try
                                {
                                    CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE_X_NotaFiscal.AtualizarDadosNFe((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Cd_empresa,
                                                                                                                (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Id_lote.ToString(),
                                                                                                                (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Nr_lanctofiscal.ToString(),
                                                                                                                v[0],
                                                                                                                v[1],
                                                                                                                v[2],
                                                                                                                v[3],
                                                                                                                v[4],
                                                                                                                v[5],
                                                                                                                null);
                                    MessageBox.Show("NF-e atualizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca(false);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro consultar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_calcchave_Click(object sender, EventArgs e)
        {
            if (bsLoteNFE_X_NotaFiscal.Current != null)
                if (string.IsNullOrEmpty((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Chave_acesso_nfe))
                    try
                    {
                        //Buscar CfgNfe
                        TRegistro_CfgNfe rCfgNfe =
                            TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null)[0];
                        //Buscar Nota Fiscal
                        TRegistro_LanFaturamento rFat =
                            TCN_LanFaturamento.BuscarNF((bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Cd_empresa,
                                                                                             (bsLoteNFE_X_NotaFiscal.Current as TRegistro_LanLoteNFE_X_NotaFiscal).Nr_lanctofiscal.ToString(),
                                                                                             null);
                        if (rFat != null)
                        {
                            rFat.Chave_acesso_nfe = srvNFE.GerarArq.TGerarArq2.MontarChaveAcessoNfe(rFat, rCfgNfe);
                            rFat.Chave_acesso_nfe += srvNFE.GerarArq.TGerarArq2.CalcularDigitoChave(rFat.Chave_acesso_nfe);
                            System.Collections.Hashtable hs = new System.Collections.Hashtable();
                            hs.Add("@CD_EMPRESA", rFat.Cd_empresa);
                            hs.Add("@LANCTOFISCAL", rFat.Nr_lanctofiscal);
                            hs.Add("@CHAVE_ACESSO", rFat.Chave_acesso_nfe);
                            new CamadaDados.TDataQuery().executarSql("update tb_fat_notafiscal set chave_acesso_nfe = @CHAVE_ACESSO " +
                                                                     "where cd_empresa = @CD_EMPRESA and nr_lanctofiscal = @LANCTOFISCAL", hs);
                            MessageBox.Show("Chave Acesso calculada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteNFE_PositionChanged(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro calcular chave acesso NF-e: " + ex.Message.Trim()); }
        }

        private void bb_cadcliforNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Current != null)
            {
                //Buscar cadastro cliente
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_clifor, null);
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
                                afterBusca(false);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bbCalcChaveNFCe_Click(object sender, EventArgs e)
        {
            if (bsLote_x_NFCe.Current != null)
                if (string.IsNullOrEmpty((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Chave_acesso))
                    try
                    {
                        //Buscar CfgNfe
                        TRegistro_CfgNfe rCfgNfe =
                            TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null)[0];
                        //Buscar Cupom Fiscal
                        TRegistro_NFCe rCF =
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarCupom((bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Cd_empresa,
                                                                               (bsLote_x_NFCe.Current as CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe).Id_cupomstr,
                                                                               null);
                        if (rCF != null)
                        {
                            rCF.rEmpresa = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(empresa.SelectedValue.ToString(),
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       null)[0];
                            rCF.Chave_acesso = NFCe.GerarXML.TGerarXML.MontarChaveAcessoNfe(rCF, true);
                            System.Collections.Hashtable hs = new System.Collections.Hashtable();
                            hs.Add("@CD_EMPRESA", rCF.Cd_empresa);
                            hs.Add("@ID_NFCE", rCF.Id_nfcestr);
                            hs.Add("@CHAVE_ACESSO", rCF.Chave_acesso);
                            new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set chave_acesso = @CHAVE_ACESSO " +
                                                                     "where cd_empresa = @CD_EMPRESA and id_nfce = @ID_NFCE", hs);
                            MessageBox.Show("Chave Acesso calculada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteNFCe_PositionChanged(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro calcular chave acesso NFC-e: " + ex.Message.Trim()); }
        }

        private void bbConsultaLote_Click(object sender, EventArgs e)
        {
            if (bsLoteRPS.Current != null)
            {
                //Buscar CfgNfe
                TRegistro_CfgNfe rCfgNfe =
                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null)[0];
                try
                {
                    string ret = NFES.TConsultaLoteRPS.ConsultarLoteRPS((bsLoteRPS.Current as CamadaDados.Faturamento.NFES.TRegistro_LoteRPS).Id_lotestr, rCfgNfe);
                    if (!string.IsNullOrEmpty(ret))
                        MessageBox.Show(ret, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro consultar lote: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Não existe lote disponivel para consultar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nfeNaoAceita_Click(object sender, EventArgs e)
        {
            afterBusca(true);
        }

        private void nfceNaoAceita_Click(object sender, EventArgs e)
        {
            afterBusca(true);
        }

        private void bbConsultarRPS_Click(object sender, EventArgs e)
        {
            using (Componentes.TFQuantidade fRPS = new Componentes.TFQuantidade())
            {
                fRPS.Ds_label = "Nº RPS";
                fRPS.Casas_decimais = 0;
                if (fRPS.ShowDialog() == DialogResult.OK)
                    if (fRPS.Quantidade > decimal.Zero)
                    {
                        TRegistro_CfgNfe rCfgNfe =
                                    TCN_CfgNfe.Buscar(empresa.SelectedValue.ToString(),
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null)[0];
                        string ret = NFES.TConsultarNfes.ConsultarNFSePorRPS(fRPS.Quantidade, rCfgNfe);
                        if (!string.IsNullOrEmpty(ret))
                        {
                            XmlDocument documento = new XmlDocument();
                            documento.LoadXml(ret);
                            if (documento["es:esConsultarNfsePorRpsResposta"].ChildNodes.Count > 0)
                                if (documento["es:esConsultarNfsePorRpsResposta"].LastChild.Name.Trim().Equals("nfse"))
                                    MessageBox.Show("Nº RPS já foi convertido em NFS-e: \r\n" +
                                                    "Nº NFE-s: " + documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["nrNfse"].InnerText + "\r\n" +
                                                    "Autenticação: " + documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["cdAutenticacao"].InnerText + "\r\n" +
                                                    "Data Autorização: " + documento["es:esConsultarNfsePorRpsResposta"]["nfse"]["dtEmissaoNfs"].InnerText, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show("Nº RPS <" + fRPS.Quantidade.ToString() + "> ainda não foi convertido em NFS-e.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
            }
        }

        private void gLote_X_NFe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gLote_X_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gLote_X_NFe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_cancelarNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Current != null)
            {
                if ((bsNFCeEnviar.Current as TRegistro_NFCe).St_registro.Trim().ToUpper().Equals("C") &&
                    (!(bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue ||
                    ((bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                        (bsNFCeEnviar.Current as TRegistro_NFCe).St_transmitidocancnfce)))
                {
                    MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                    !(bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo.HasValue)
                {
                    MessageBox.Show("Não é permitido CANCELAR NFC-e emitida em CONTINGÊNCIA OFFLINE sem antes transmitir a mesma para receita.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Verificar se NFCe não esta vinculada a NFe
                        if (new TCD_ECFVinculadoNF().BuscarEscalar(
                            new TpBusca[]
                            {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_cupom",
                                        vOperador = "=",
                                        vVL_Busca = (bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfcestr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                    "and isnull(x.st_registro, 'A') <> 'C')"
                                    }
                            }, "1") != null)
                        {
                            MessageBox.Show("Para cancelar NFCe vinculada a NFe, obrigatório antes cancelar a NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        bool st_cancelar = true;
                        if ((bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo.HasValue ||
                            (bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                        {
                            string motivo = string.Empty;
                            TList_CfgNfe lCfg = null;
                            TList_Evento lEv = null;
                            //Verificar evento
                            TList_EventoNFCe lEvento =
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                    string.Empty,
                                                                                    null);
                            if (lEvento.Count.Equals(0))
                            {
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Motivo Cancelamento NFCe";
                                    motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (motivo.Trim().Length < 15)
                                    {
                                        MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                //Buscar evento Cancelamento
                                if (lEv == null)
                                    lEv = TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                if (lEv.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar NFe Receita
                                TRegistro_EventoNFCe rEvento = new TRegistro_EventoNFCe();
                                rEvento.Cd_empresa = (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa;
                                rEvento.Id_cupom = (bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfce;
                                rEvento.Chave_acesso_nfce = (bsNFCeEnviar.Current as TRegistro_NFCe).Chave_acesso;
                                rEvento.Nr_protocoloNFCe = (bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Justificativa = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Gravar(rEvento, null);
                                lEvento.Add(rEvento);
                            }
                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T") &&
                                (bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo.HasValue)
                            {
                                //Buscar CfgNfe para a empresa
                                if (lCfg == null)
                                    lCfg = TCN_CfgNfe.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    string ret = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + ret.Trim() + ".",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        st_cancelar = false;
                                    }
                                }
                            }
                        }
                        if (st_cancelar)
                        {
                            if (!(bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo.HasValue &&
                                !(bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                !string.IsNullOrEmpty((bsNFCeEnviar.Current as TRegistro_NFCe).Chave_acesso))
                            {
                                //Buscar CfgNfe para a empresa
                                TList_CfgNfe lCfgNfCe =
                                    TCN_CfgNfe.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                      string.Empty,
                                                      string.Empty,
                                                      null);
                                if (lCfgNfCe.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração NFC-e para a empresa " + (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    //Consultar Chave
                                    string ret = NFCe.ConsultaChave.TConsultaChave.ConsultaChave((bsNFCeEnviar.Current as TRegistro_NFCe).Chave_acesso,
                                                                                                    "1",
                                                                                                    lCfgNfCe[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Não é permtido excluir cupom com chave de acesso existente na receita.\r\n" + ret, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe.CancelarCF(bsNFCeEnviar.Current as TRegistro_NFCe, null);
                            MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!(bsNFCeEnviar.Current as TRegistro_NFCe).Nr_protocolo.HasValue &&
                                !(bsNFCeEnviar.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                            {
                                TList_CadSequenciaNF lSeq =
                                    TCN_CadSequenciaNF.Busca((bsNFCeEnviar.Current as TRegistro_NFCe).Nr_serie,
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_modelo,
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                    null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals((bsNFCeEnviar.Current as TRegistro_NFCe).NR_NFCe))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        TList_CfgNfe lCfgNfe =
                                            TCN_CfgNfe.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
                                        if (lCfgNfe.Count > 0)
                                        {
                                            try
                                            {
                                                //Inutilizar numero nota
                                                NFCe.InutilizaNFCe.TInutilizaNFCe.InutilizarNFCe(lCfgNfe[0].Cd_uf_empresa,
                                                                                                    lCfgNfe[0].Cnpj_empresa,
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Nr_serie,
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_modelo,
                                                                                                    DateTime.Now.Year.ToString(),
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).NR_NFCe.Value,
                                                                                                    (bsNFCeEnviar.Current as TRegistro_NFCe).NR_NFCe.Value,
                                                                                                    "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFCe",
                                                                                                    lCfgNfe[0]);
                                                MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                            }
                            tcNFCe_SelectedIndexChanged(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_cancelarNFe_Click(object sender, EventArgs e)
        {
            if (bsNFeEnviar.Current != null)
            {
                if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("D"))
                {
                    MessageBox.Show("Não é permitido CANCELAR NFe DENEGADA pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento Nota Fiscal?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Verificar se a nota nao esta amarrada a nenhuma fixacao
                    if (new CamadaDados.Graos.TCD_Fixacao_NF().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(fx.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                }, "1") != null)
                    {
                        MessageBox.Show("Nota Fiscal possui amarração com a fixação de contratos\r\nEsta nota somente poderá ser cancelada pela tela de fixação.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        TCN_LanFaturamento.CancelarFaturamento((bsNFeEnviar.Current as TRegistro_LanFaturamento), null);
                        MessageBox.Show("Nota Fiscal Cancelada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55") &&
                            (bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("P"))
                            if (!(bsNFeEnviar.Current as TRegistro_LanFaturamento).St_transmitidoNFe)
                            {
                                TList_CadSequenciaNF lSeq = TCN_CadSequenciaNF.Busca((bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                     (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                     (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                 null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals((bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_notafiscal))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).Tp_serie.Trim().ToUpper() != "S")//Não for nota de servico
                                    {
                                        //Buscar configuracao nfe
                                        TList_CfgNfe lCfgNfe = TCN_CfgNfe.Buscar((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                                        if (lCfgNfe.Count > 0)
                                        {
                                            try
                                            {
                                                //Inutilizar numero nota
                                                srvNFE.InutilizarNFE.InutilizarNFE2.InutilizarNfe2(lCfgNfe[0].Cd_uf_empresa,
                                                                                                   lCfgNfe[0].Cnpj_empresa,
                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_modelo,
                                                                                                   DateTime.Now.Year.ToString(),
                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                                   (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_notafiscal.Value,
                                                                                                   "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFE",
                                                                                                   lCfgNfe[0]);
                                                MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch
                                            { MessageBox.Show("Erro ao INUTILIZAR numero junto a receita.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                            }
                        tcNfe_SelectedIndexChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }

                }
            }
        }

        private void tcNFCeEnviar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcNFCeEnviar.SelectedTab.Equals(tpItensNFCeEnv))
                if (bsNFCeEnviar.Current != null)
                    if ((bsNFCeEnviar.Current as TRegistro_NFCe).lItem.Count.Equals(0))
                    {
                        (bsNFCeEnviar.Current as TRegistro_NFCe).lItem =
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfcestr,
                                                                               (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                                                               string.Empty,
                                                                               null);
                        bsNFCeEnviar.ResetCurrentItem();
                    }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpItensNFe))
                if (bsNFeEnviar.Current != null)
                    if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).ItensNota.Count.Equals(0))
                    {
                        (bsNFeEnviar.Current as TRegistro_LanFaturamento).ItensNota =
                            TCN_LanFaturamento_Item.Busca((bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                          (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                          string.Empty,
                                                          null);
                        bsNFeEnviar.ResetCurrentItem();
                    }
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            if (bsItensNFCeEnviar.Current != null)
                using (TFAtualizaCadProduto fAtualiza = new TFAtualizaCadProduto())
                {
                    //Buscar cadastro produto
                    fAtualiza.rProd =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo((bsItensNFCeEnviar.Current as TRegistro_NFCe_Item).Cd_produto, null);
                    if (fAtualiza.ShowDialog() == DialogResult.OK)
                        if (fAtualiza.rProd != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fAtualiza.rProd, null);
                                ReprocessarImpostos(true);
                                MessageBox.Show("Cadastro item atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca(false);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
        }

        private void bbReprocessarFiscalNFe_Click(object sender, EventArgs e)
        {
            if (bsNFeEnviar.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    if ((bsNFeEnviar.Current as TRegistro_LanFaturamento).ItensNota.Count.Equals(0))
                    {
                        (bsNFeEnviar.Current as TRegistro_LanFaturamento).ItensNota =
                            TCN_LanFaturamento_Item.Busca(
                                (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa,
                                (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                string.Empty,
                                null);
                        bsNFeEnviar.ResetCurrentItem();
                    }
                    fReprocessa.rNf = bsNFeEnviar.Current as TRegistro_LanFaturamento;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(fReprocessa.rNf,
                                                               null,
                                                               null,
                                                               TCN_LanFaturamento.CalcTotalNota(fReprocessa.rNf),
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca(false);
                            //Verificar se Valor da nota é diferente do valor da duplicata desde que a mesma esteja sem liquidação.
                            if (new TCD_LanDuplicata().BuscarEscalar(
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
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_LanctoDuplicata = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'" +
                                                        "and x.nr_lanctofiscal = " + (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr + ") "
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.vl_documento",
                                            vOperador = "<>",
                                            vVL_Busca = (bsNFeEnviar.Current as TRegistro_LanFaturamento).Vl_totalnota.ToString().Replace(",", ".")
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and isnull(x.st_registro, 'A') <> 'C') "
                                        }
                                    }, "1") != null)
                            {
                                TList_RegLanDuplicata lDup =
                                    new TCD_LanDuplicata().Select(
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
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_LanctoDuplicata = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + (bsNFeEnviar.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'" +
                                                        "and x.nr_lanctofiscal = " + (bsNFeEnviar.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr + ") "
                                        }
                                    }, 1, string.Empty);

                                if (lDup.Count > 0)
                                    try
                                    {
                                        lDup[0].Vl_documento = (bsNFeEnviar.Current as TRegistro_LanFaturamento).Vl_totalnota;
                                        lDup[0].Vl_documento_padrao = (bsNFeEnviar.Current as TRegistro_LanFaturamento).Vl_totalnota;
                                        lDup[0].Parcelas.Clear();
                                        lDup[0].Parcelas = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(lDup[0], null);
                                        CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.AlterarDuplicata(lDup[0], null);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void bbReprocessarFiscalNFCe_Click(object sender, EventArgs e)
        {
            if (bsNFCeEnviar.Current != null)
            {
                using (TFReprocessarFiscal fReprocessa = new TFReprocessarFiscal())
                {
                    if ((bsNFCeEnviar.Current as TRegistro_NFCe).lItem.Count.Equals(0))
                    {
                        (bsNFCeEnviar.Current as TRegistro_NFCe).lItem =
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(
                                (bsNFCeEnviar.Current as TRegistro_NFCe).Id_nfcestr,
                                (bsNFCeEnviar.Current as TRegistro_NFCe).Cd_empresa,
                                string.Empty,
                                null);
                        bsNFCeEnviar.ResetCurrentItem();
                    }
                    fReprocessa.rNFCe = bsNFCeEnviar.Current as TRegistro_NFCe;
                    if (fReprocessa.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_ImpostosNF.ReprocessarImpostos(null,
                                                               null,
                                                               fReprocessa.rNFCe,
                                                               fReprocessa.rNFCe.Vl_cupom,
                                                               null);
                            MessageBox.Show("Impostos reprocessados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca(false);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void bbGerarXML_Click(object sender, EventArgs e)
        {
            new TCD_NFCe().Select(
                new TpBusca[]
                {
                    new TpBusca
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new TpBusca
                    {
                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                        vOperador = ">=",
                        vVL_Busca = "'20180901'"
                    },
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "not exists",
                        vVL_Busca = "(select 1 from TB_PDV_XML_NFCe x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_nfce = a.id_nfce)"
                    },
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_cupom = a.id_nfce " +
                                    "and x.status = '100')"
                    }
                }, 0, string.Empty, string.Empty)
                .ForEach(p => NFCe.GerarXML.TGerarXML.GerarXMLRegistro(p));
        }
    }
}
