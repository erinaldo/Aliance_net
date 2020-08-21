using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFPainelCTe : Form
    {
        public string pCd_empresa
        { get; set; }

        private bool Altera_Relatorio = false;

        public TFPainelCTe()
        {
            InitializeComponent();
        }

        private void enviarCTe()
        {
            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração FROTA para emitir CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFListaCTeEnviar fLista = new TFListaCTeEnviar())
            {
                fLista.Cd_transportadora = transportadora.SelectedValue.ToString();
                fLista.ShowDialog();
                if(fLista.lCte != null)
                    if (fLista.lCte.Count > 0)
                    {
                        //Gerar e assinar Arquivos xml
                        try
                        {
                            CTe.EnviaArq.TEnviaArq.EnviarLoteCte(fLista.lCte, lCfg[0]);
                            MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Consultar lote
                            CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro enviar CTe: " + ex.Message);
                        }
                    }
            }
        }

        private void consultarCTe()
        {
            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
            if (lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração FROTA para emitir CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                this.afterBusca();
            }
            catch (Exception ex)
            { MessageBox.Show("Erro consultar CTe: " + ex.Message.Trim()); }
        }

        private void InutilizatCTe()
        {
            if (transportadora.SelectedValue != null)
            {
                using (TFInutilizarNfe fInutilizar = new TFInutilizarNfe())
                {
                    fInutilizar.Cd_empresa = transportadora.SelectedValue.ToString();
                    fInutilizar.Nm_empresa = transportadora.Text;
                    fInutilizar.St_inutilizarCte = true;
                    if (fInutilizar.ShowDialog() == DialogResult.OK)
                    {
                        //Buscar CfgNfe
                        CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fInutilizar.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null)[0];
                        try
                        {
                            CTe.Inutilizar.TInutilizarCte.InutilizarCte(rCfg.Cd_uf_empresa,
                                                                        rCfg.Cnpj_empresa,
                                                                        fInutilizar.Nr_serie,
                                                                        fInutilizar.Cd_modelo,
                                                                        fInutilizar.Ano.ToString(),
                                                                        fInutilizar.Nfeini,
                                                                        fInutilizar.Nfefin,
                                                                        fInutilizar.Justificativa,
                                                                        rCfg);
                            MessageBox.Show("Sequencia CTe inutilizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe transportadora configurada para inutilizar sequencia CTe", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            bsLoteCTe.DataSource = CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Buscar(transportadora.SelectedValue.ToString(),
                                                                                     string.Empty,
                                                                                     dt_inicial.Text,
                                                                                     dt_final.Text,
                                                                                     string.Empty,
                                                                                     nr_ctrc.Text,
                                                                                     cd_destinatario.Text,
                                                                                     "a.id_lote desc",
                                                                                     null);
            bsLoteCTe_PositionChanged(this, new EventArgs());
        }

        private void AtualizarCamposTela()
        {
            if (transportadora.SelectedValue != null)
            {
                object obj = new CamadaDados.Frota.Cadastros.TCD_CfgFrota().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + transportadora.SelectedValue.ToString().Trim() + "'"
                                    }
                                }, "a.tp_ambiente");
                if (obj != null)
                    lblAmbiente.Text = obj.ToString().Trim().Equals("1") ? "PRODUÇÃO" : "HOMOLOGAÇÃO";
            }
        }

        private void ConsultaStatusServico()
        {
            if (transportadora.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar transportadora.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transportadora.Focus();
                return;
            }
            CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfgCte =
                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  null)[0];
            if (CTe.StatusServico.TStatusServico.StatusServico(rCfgCte, false).Trim().Equals("107"))
                tsStatus.Text = "SERVIÇO EM OPERAÇÃO";
            else if (CTe.StatusServico.TStatusServico.StatusServico(rCfgCte, true).Trim().Equals("107"))
                tsStatus.Text = "CONTINGENCIA " + rCfgCte.Tipo_ambientecont + " EM OPERAÇÃO";
            else
                tsStatus.Text = "SERVIÇO INDISPONIVEL NO MOMENTO.";
        }

        private void ReabrirLoteProcessar()
        {
            if (bsCTe.Current != null)
            {
                if ((bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Status.Equals(103) ||
                    (bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Status.Equals(105))
                {
                    MessageBox.Show("Não é permitido REABRIR CTe de um lote ainda não processado pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Status.ToString().Trim().Equals("100") &&
                    (bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Tp_ambiente.Trim().Equals("1"))
                {
                    MessageBox.Show("Não é permitido REABRIR CTe aceita pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Status.ToString().Trim().Equals("110") &&
                    (bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Tp_ambiente.Trim().Equals("1"))
                {
                    MessageBox.Show("Não é permitido REABRIR CTe DENEGADA pela receita no ambiente de produção.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.ReabrirCteProcessar(
                        bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe, null);
                    MessageBox.Show("CTe pronto para ser processado novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (bsLoteCTe.Current != null)
            {
                try
                {
                    CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Excluir(bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe, null);
                    MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterPrintDacte()
        {
            if (bsCTe.Current != null)
            {
                if (!(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Status.ToString().Trim().Equals("100"))
                {
                    MessageBox.Show("Permitido imprimir DACTE somente de CT-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BinDados = new BindingSource();
                    CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCTE =
                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Cd_empresa,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Nr_lanctoctrstr,
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
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    0,
                                                                                    string.Empty,
                                                                                    null);
                    //Buscar Detalhes do CTe
                    //Buscar notas fiscais
                    lCTE[0].lNfCTe =
                        CamadaNegocio.Faturamento.CTRC.TCN_CTRNotaFiscal.Buscar(lCTE[0].Cd_empresa,
                                                                                 lCTE[0].Nr_lanctoCTRC.ToString(),
                                                                                 string.Empty,
                                                                                 0,
                                                                                 string.Empty,
                                                                                 null);



                    //Buscar Evento
                    lCTE[0].lEvento =
                        CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Buscar(lCTE[0].Cd_empresa,
                                                                             lCTE[0].Nr_lanctoCTRC.ToString(),
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             null);
                    //Buscar Quantidade
                    lCTE[0].lQtdeCarga =
                        CamadaNegocio.Faturamento.CTRC.TCN_CTRQtdeCarga.Buscar(lCTE[0].Cd_empresa,
                                                                               lCTE[0].Nr_lanctoCTRC.Value.ToString(),
                                                                               null);
                    //Busca Componente
                    lCTE[0].lCompValorFrete =
                        CamadaNegocio.Faturamento.CTRC.TCN_CTRCompValorFrete.Buscar(lCTE[0].Cd_empresa,
                                                                                    lCTE[0].Nr_lanctoCTRC.Value.ToString(),
                                                                                    null);
                    //Buscar Impostos
                    lCTE[0].lImpostos =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Buscar(string.Empty,
                                                                                   lCTE[0].Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   lCTE[0].Nr_lanctoCTRC.Value.ToString(),
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   false,
                                                                                   string.Empty,
                                                                                   null);
                    BinDados.DataSource = lCTE;
                    Rel.DTS_Relatorio = BinDados;

                    //Buscar ENDEREÇO Emitente
                    BindingSource bs_endEmitente = new BindingSource();
                    bs_endEmitente.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_transportadora,
                                                                                  lCTE[0].Cd_endtransportadora,
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

                    //Buscar ENDEREÇO Remetente
                    BindingSource bs_endRemetente = new BindingSource();
                    bs_endRemetente.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_remetente,
                                                                                  lCTE[0].Cd_endremetente,
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
                    //Buscar ENDEREÇO Expedidor
                    BindingSource bs_endExpedidor = new BindingSource();
                    if ((!string.IsNullOrEmpty(lCTE[0].Cd_expedidor)) &&
                        (!string.IsNullOrEmpty(lCTE[0].Cd_endexpedidor)))
                        bs_endExpedidor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_expedidor,
                                                                                      lCTE[0].Cd_endexpedidor,
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
                    else bs_endExpedidor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar ENDEREÇO Destinatario
                    BindingSource bs_endDest = new BindingSource();
                    bs_endDest.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_destinatario,
                                                                                  lCTE[0].Cd_enddestinatario,
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
                    //Buscar ENDEREÇO Recebedor
                    BindingSource bs_endRecebedor = new BindingSource();
                    if ((!string.IsNullOrEmpty(lCTE[0].Cd_recebedor)) &&
                        (!string.IsNullOrEmpty(lCTE[0].Cd_endrecebedor)))
                        bs_endRecebedor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_recebedor,
                                                                                      lCTE[0].Cd_endrecebedor,
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
                    else bs_endRecebedor.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar Endereco Tomador
                    BindingSource bs_endTomador = new BindingSource();
                    if ((!string.IsNullOrEmpty(lCTE[0].Cd_tomador)) &&
                        (!string.IsNullOrEmpty(lCTE[0].Cd_endtomador)))
                        bs_endTomador.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCTE[0].Cd_tomador,
                                                                                      lCTE[0].Cd_endtomador,
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
                    else bs_endTomador.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    //Buscar NF-e 
                    BindingSource BD_NF = new BindingSource();
                    BD_NF.DataSource = new CamadaDados.Faturamento.CTRC.TCD_CTRNotaFiscal().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lCTE[0].Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.NR_lanctoCTR",
                                vOperador = "=",
                                vVL_Busca = "'" + lCTE[0].Nr_lanctoCTRC.ToString().Trim() + "'"
                            }
                        },0, string.Empty);

                    //Buscar CFG Frota
                    BindingSource bs_CFG = new BindingSource();
                    bs_CFG.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(lCTE[0].Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                    //Buscar Empresa
                    BindingSource bs_empresa = new BindingSource();
                    bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCTE[0].Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);


                    Rel.Adiciona_DataSource("EMPRESA", bs_empresa);
                    Rel.Adiciona_DataSource("CFGFROTA", bs_CFG);
                    Rel.Adiciona_DataSource("BD_NF", BD_NF);
                    Rel.Adiciona_DataSource("ENDEMITENTE", bs_endEmitente);
                    Rel.Adiciona_DataSource("ENDREMETENTE", bs_endRemetente);
                    Rel.Adiciona_DataSource("ENDEXPEDIDOR", bs_endExpedidor);
                    Rel.Adiciona_DataSource("ENDDEST", bs_endDest);
                    Rel.Adiciona_DataSource("ENDRECEBEDOR", bs_endRecebedor);
                    Rel.Adiciona_DataSource("ENDTOMADOR", bs_endTomador);

                    //Buscar financeiro da CTE
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                    "inner join TB_CTR_Duplicata y " +
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                    "where isnull(x.st_registro, 'A') <> 'C' " +
                                                    "and x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and y.cd_empresa = '" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Cd_empresa.Trim() + "' " +
                                                    "and y.nr_lanctoCTR = " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Nr_lanctoctr+ ")"
                                    }
                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    if (lParc.Count > 0)
                        for (int i = 0; i < lParc.Count; i++)
                        {
                            if (i < 8)
                            {
                                Rel.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                Rel.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                            }
                            else
                                break;
                        }
                    //Montar Parametros QTD
                    if (lCTE[0].lQtdeCarga.Count > 0)
                        for (int i = 0; i < lCTE[0].lQtdeCarga.Count; i++)
                        {
                            if (i < 3)
                            {
                                Rel.Parametros_Relatorio.Add("UND_MED" + i.ToString(), lCTE[0].lQtdeCarga[i].Tp_medida);
                                Rel.Parametros_Relatorio.Add("QTD" + i.ToString(), lCTE[0].lQtdeCarga[i].Qt_carga + " ");
                            }
                            else
                                break;
                        }
                    //Montar Parametros Complemento Frete
                    if (lCTE[0].lCompValorFrete.Count > 0)
                        for (int i = 0; i < lCTE[0].lCompValorFrete.Count; i++)
                        {
                            if (i < 8)
                            {
                                Rel.Parametros_Relatorio.Add("NOMECOMP" + i.ToString(), lCTE[0].lCompValorFrete[i].Nm_componente);
                                Rel.Parametros_Relatorio.Add("VL_COMP" + i.ToString(), lCTE[0].lCompValorFrete[i].Vl_componente);
                            }
                            else
                                break;
                        }
                    Rel.Nome_Relatorio = "TFLanCTE_Dacte";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "FRT";
                    Rel.Ident = "TFLanCTE_Dacte";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "CTE";
                    //Verificar se existe logo configurada para a empresa
                    object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lCTE[0].Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.logoEmpresa");
                    if (log != null)
                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
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
                                           "CTE",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        fImp.pCd_clifor = lCTE[0].Cd_destinatario;
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
                                    //Buscar CFG Frota
                                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                       CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         null);
                                    //Gerar XML Periodo
                                    CTe.GerarArq.TGerarArq.GerarArquivoXmlPeriodo(path_anexo, lCTE, lCfg[0]);
                                }
                                catch { }
                                if (System.IO.File.Exists(path_anexo + lCTE[0].Chaveacesso.Trim().Remove(0, 3) + "-cte.xml"))
                                {
                                    //Ler arquivo gerado
                                    Anexo = new List<string>();
                                    Anexo.Add(path_anexo + lCTE[0].Chaveacesso.Trim().Remove(0, 3) + "-cte.xml");
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
                                           "CTE",
                                           fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void GerarXmlCTe()
        {
            using (TFGerarXMLCTe fXml = new TFGerarXMLCTe())
            {
                fXml.ShowDialog();
            }
        }

        private void TFPainelCTe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            transportadora.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "EXISTS",
                                                vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_frt_cfgfrota x "+
                                                            "where x.cd_empresa = a.cd_empresa)"
                                            }
                                        }, 0, string.Empty);
            transportadora.DisplayMember = "NM_Empresa";
            transportadora.ValueMember = "CD_Empresa";
            if (!string.IsNullOrEmpty(pCd_empresa))
                transportadora.SelectedValue = pCd_empresa; 
            transportadora_SelectedIndexChanged(this, new EventArgs());
            this.ConsultaStatusServico();
            tmStatus.Enabled = true;
        }

        private void transportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AtualizarCamposTela();
            this.afterBusca();
        }

        private void bsLoteCTe_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteCTe.Current != null)
            {
                (bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).lCTe =
                    CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Buscar((bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Cd_empresa,
                                                                         (bsLoteCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe).Id_lotestr,
                                                                         string.Empty,
                                                                         null);
                bsLoteCTe.ResetCurrentItem();
            }
        }

        private void bb_destinatario_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_destinatario }, string.Empty);
        }

        private void cd_destinatario_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_destinatario.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_destinatario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.enviarCTe();
        }

        private void gCTe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().Equals("100"))
                        gCTe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gCTe.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void tmStatus_Tick(object sender, EventArgs e)
        {
            this.ConsultaStatusServico();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.consultarCTe();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.ReabrirLoteProcessar();
        }

        private void TFPainelCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.enviarCTe();
            else if (e.KeyCode.Equals(Keys.F3))
                this.consultarCTe();
            else if (e.KeyCode.Equals(Keys.F5))
                this.ReabrirLoteProcessar();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrintDacte();
            else if (e.KeyCode.Equals(Keys.F9))
                this.InutilizatCTe();
            else if (e.KeyCode.Equals(Keys.F10))
                this.GerarXmlCTe();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.InutilizatCTe();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrintDacte();
        }

        private void bb_xmlCTe_Click(object sender, EventArgs e)
        {
            this.GerarXmlCTe();
        }

        private void bb_consultaCTe_Click(object sender, EventArgs e)
        {
            if (bsCTe.Current != null)
                if (!string.IsNullOrEmpty((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).ChaveAcesso) &&
                    !string.IsNullOrEmpty((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Tp_ambiente))
                {
                    if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Status.HasValue)
                        if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Status.Value.Equals(100))
                        {
                            MessageBox.Show("CT-e já esta com status 100-Autorizado o uso do CT-e", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    //Buscar CfgNfe
                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                    try
                    {
                        string ret = CTe.ConsultaChave.TConsultaChave.ConsultaChave((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).ChaveAcesso,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Tp_ambiente,
                                                                                    lCfg[0]);
                        if (string.IsNullOrEmpty(ret))
                            MessageBox.Show("CT-e não encontrado para a chave de acesso: " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).ChaveAcesso,
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            string[] v = ret.Split(new char[] { '|' });
                            if (v.Length > 0)
                                try
                                {
                                    CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.AtualizarDadosCTe((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Cd_empresa,
                                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Id_lotestr,
                                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Nr_lanctoctrstr,
                                                                                                    v[0],
                                                                                                    v[1],
                                                                                                    v[2],
                                                                                                    v[3],
                                                                                                    v[4],
                                                                                                    v[5],
                                                                                                    null);
                                    MessageBox.Show("CT-e atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro consultar CT-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bbCalcChaveCTe_Click(object sender, EventArgs e)
        {
            if (bsCTe.Current != null)
                if (string.IsNullOrEmpty((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).ChaveAcesso))
                    try
                    {
                        //Buscar CfgNfe
                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(transportadora.SelectedValue.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                        //Buscar CTe
                        CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lCte =
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Cd_empresa,
                                                                                        (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe).Nr_lanctoctrstr,
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
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        1,
                                                                                        string.Empty,
                                                                                        null);
                        if (lCte.Count > 0)
                        {
                            lCte[0].Chaveacesso = CTe.GerarArq.TGerarArq.MontarChaveAcessoCte(lCte[0],
                                                                                              CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCte[0].Cd_empresa,
                                                                                                                                          string.Empty,
                                                                                                                                          string.Empty,
                                                                                                                                          null)[0],
                                                                                              lCfg[0]);
                            lCte[0].Chaveacesso += CTe.GerarArq.TGerarArq.CalcularDigitoChave(lCte[0].Chaveacesso);
                            System.Collections.Hashtable hs = new System.Collections.Hashtable();
                            hs.Add("@CD_EMPRESA", lCte[0].Cd_empresa);
                            hs.Add("@NR_LANCTOCTR", lCte[0].Nr_lanctoCTRC);
                            hs.Add("@CHAVE_ACESSO", lCte[0].Chaveacesso);
                            new CamadaDados.TDataQuery().executarSql("update tb_ctr_conhecimentofrete set chaveacesso = @CHAVE_ACESSO " +
                                                                     "where cd_empresa = @CD_EMPRESA and nr_lanctoctr = @NR_LANCTOCTR", hs);
                            MessageBox.Show("Chave Acesso calculada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsLoteCTe_PositionChanged(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro calcular chave acesso CT-e: " + ex.Message.Trim()); }
        }
    }
}
