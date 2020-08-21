using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Frota
{
    public partial class TFLanCTe : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_CfgFrota rCfg
        { get; set; }
        private bool Altera_Relatorio = false;
        private string pathSource = string.Empty;

        public TFLanCTe()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            cd_empresa.Clear();
            nr_ctrc.Clear();
            cd_remetente.Clear();
            cd_destinatario.Clear();
            chaveAcessoNFe.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            rbTransmitir.Checked = true;
        }

        private void afterNovo()
        {
            using (TFCTe fCte = new TFCTe())
            {
                //Buscar empresa padrao do login
                CamadaDados.Diversos.TList_CadEmpresa lEmp =
                new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
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
                            vVL_Busca = "(select 1 from TB_FRT_CfgFrota x " +
                                        "where x.cd_empresa = a.cd_empresa)"
                        }
                    }, 0, string.Empty);
                if (lEmp.Count > 0)
                    if (lEmp.Count.Equals(1))
                        fCte.pCd_empresa = lEmp[0].Cd_empresa;
                    else
                        using (Proc_Commoditties.TFListaEmpresa fEmp = new Proc_Commoditties.TFListaEmpresa())
                        {
                            fEmp.lEmp = lEmp;
                            if (fEmp.ShowDialog() == DialogResult.OK)
                                if (fEmp.rEmp != null)
                                    fCte.pCd_empresa = fEmp.rEmp.Cd_empresa;
                        }
                if (fCte.ShowDialog() == DialogResult.OK)
                    if (fCte.rCte != null)
                    {
                        //Verificar se o CMI gera financeiro
                        CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCte.rCte.Cd_cmistr,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     null);
                        if (lCmi.Count > 0)
                            if (!string.IsNullOrEmpty(lCmi[0].Tp_duplicata))
                            {
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = fCte.rCte.Cd_empresa;
                                    fDuplicata.vNm_empresa = fCte.rCte.Nm_empresa;
                                    fDuplicata.vCd_clifor = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Cd_destinatario : fCte.rCte.Cd_remetente;
                                    fDuplicata.vNm_clifor = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Nm_destinatario : fCte.rCte.Nm_remetente;
                                    fDuplicata.vCd_endereco = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Cd_enddestinatario : fCte.rCte.Cd_endremetente;
                                    fDuplicata.vDs_endereco = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Ds_enddestinatario : fCte.rCte.Ds_endremetente;
                                    fDuplicata.vNr_docto = fCte.rCte.Nr_ctrcstr;
                                    fDuplicata.vDt_emissao = fCte.rCte.Dt_emissao.Value.ToString("dd/MM/yyyy");
                                    fDuplicata.vVl_documento = fCte.rCte.Vl_receber;
                                    fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                    fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                    fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                    fDuplicata.vCd_historico = lCmi[0].Cd_historico;
                                    fDuplicata.vDs_historico = lCmi[0].Ds_historico;
                                    fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                    fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                    fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                    fDuplicata.vCd_moeda = lCmi[0].Cd_moeda;
                                    fDuplicata.vDs_moeda = lCmi[0].Ds_moeda;
                                    fDuplicata.vSigla_moeda = lCmi[0].Sigla;
                                    fDuplicata.vSt_ctrc = true;
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        if (fDuplicata.dsDuplicata.Current != null)
                                        {
                                            fCte.rCte.rDuplicata =
                                                fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        try
                        {
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(fCte.rCte, false, null);
                            if (MessageBox.Show("CTe gravado com sucesso.\r\nDeseja enviar o mesmo para receita?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fCte.rCte.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                                if (lCfg.Count > 0)
                                    //Gerar e assinar Arquivos xml
                                    try
                                    {
                                        CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { fCte.rCte }, lCfg[0]);
                                        MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Consultar lote
                                        CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                        LimparFiltros();
                                        cd_empresa.Text = fCte.rCte.Cd_empresa;
                                        nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                        rbTodos.Checked = true;
                                        afterBusca();
                                        if (bsCTe.Current != null)
                                            if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.ToString().Equals("100"))
                                                afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, true);
                                            else
                                                using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                {
                                                    fPainel.pCd_empresa = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                                    fPainel.ShowDialog();
                                                }
                                        else
                                            using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                fPainel.ShowDialog();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro enviar CTe: " + ex.Message);
                                    }
                            }
                            else
                            {
                                LimparFiltros();
                                cd_empresa.Text = fCte.rCte.Cd_empresa;
                                nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                afterBusca();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsCTe.Current != null)
            {
                if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é possivel corrigir CTe CANCELADA!", " Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Valida se CTe tem origem de importação
                bool importacao = false;
                object id_lote = new CamadaDados.Faturamento.CTRC.TCD_Lote_X_CTe().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.NR_lanctoCTR",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.ToString().Trim() + "'"
                                            }
                                        }, "a.id_lote");
                if (id_lote != null)
                {
                    object ds_lote = new CamadaDados.Faturamento.CTRC.TCD_LoteCTe().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.id_lote",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + id_lote.ToString().Trim() + "'"
                                                                        }
                                                                    }, "a.ds_mensagem");
                    if (ds_lote != null)
                        if (ds_lote.ToString().Trim().Equals("LOTE PROCESSADO POR IMPORTACAO"))
                            importacao = true;
                }
                else if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é possivel corrigir CTe PROCESSADO!", " Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (new CamadaDados.Faturamento.CTRC.TCD_Lote_X_CTe().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.NR_lanctoCTR",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.ToString().Trim() + "'"
                                            }
                                        }, string.Empty) == null || importacao)
                {
                    using (TFCTe fCte = new TFCTe())
                    {
                        fCte.rCte = bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete;
                        if (fCte.ShowDialog() == DialogResult.OK)
                            if (fCte.rCte != null)
                            {
                                try
                                {
                                    CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(fCte.rCte, true, null);
                                    bsCTe.ResetCurrentItem();
                                    if (MessageBox.Show("CTe gravado com sucesso.\r\nDeseja enviar o mesmo para receita?",
                                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                        CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fCte.rCte.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                                        if (lCfg.Count > 0)
                                            //Gerar e assinar Arquivos xml
                                            try
                                            {
                                                CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { fCte.rCte }, lCfg[0]);
                                                MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //Consultar lote
                                                CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                                LimparFiltros();
                                                cd_empresa.Text = fCte.rCte.Cd_empresa;
                                                nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                                afterBusca();
                                                if (bsCTe.Current != null)
                                                    if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.ToString().Equals("100"))
                                                        afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, true);
                                                    else
                                                        using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                        {
                                                            fPainel.pCd_empresa = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                                            fPainel.ShowDialog();
                                                        }
                                                else
                                                    using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                    {
                                                        fPainel.pCd_empresa = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                                        fPainel.ShowDialog();
                                                    }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Erro enviar CTe: " + ex.Message);
                                            }
                                    }
                                    else
                                    {
                                        LimparFiltros();
                                        cd_empresa.Text = fCte.rCte.Cd_empresa;
                                        nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                        afterBusca();
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                }
                else
                {
                    if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.HasValue ?
                        (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.Value.Equals(100) : false)
                    {
                        //Buscar evento Carta Correcao
                        CamadaDados.Faturamento.Cadastros.TList_Evento lEvento =
                            CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CC", null);
                        if (lEvento.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe evento de CARTA CORREÇÃO cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (TFCartaCorrecao fCCe = new TFCartaCorrecao())
                        {
                            if (fCCe.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    fCCe.rEvento.Cd_empresa = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                    fCCe.rEvento.Nr_lanctoctr = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC;
                                    fCCe.rEvento.Chaveacesso = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Chaveacesso;
                                    fCCe.rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                    fCCe.rEvento.Cd_eventostr = lEvento[0].Cd_eventostr;
                                    fCCe.rEvento.Ds_evento = lEvento[0].Ds_evento;
                                    fCCe.rEvento.Tp_evento = lEvento[0].Tp_evento;
                                    fCCe.rEvento.St_registro = "A";
                                    CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Gravar(fCCe.rEvento, null);
                                    if (MessageBox.Show("Carta correção eletronica gravada com sucesso.\r\n" +
                                                    "Deseja enviar a mesma para a receita?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                    {
                                        //Buscar CfgNfe para a empresa
                                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                        if (lCfg.Count.Equals(0))
                                            MessageBox.Show("Não existe configuração para envio de CCe para a empresa " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + ".",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            try
                                            {
                                                string msg = CTe.Evento.TEventoCTe.EnviarEvento(fCCe.rEvento, lCfg[0]);
                                                if (!string.IsNullOrEmpty(msg))
                                                    MessageBox.Show("Erro ao enviar CCe para a receita. Aguarde um tempo e tente novamente.\r\n" +
                                                                    "Erro: " + msg.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                else
                                                {
                                                    MessageBox.Show("CCe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    afterBusca();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não é possivel executar a correção será necessário reabrir o CTe para alterar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            //Processados
            if (rbProcessados.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'C')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'P'";
            }
            //Cancelado
            if (rbCancelado.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'C')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
            }
            //Anulado
            if (rbAnulado.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_anulado, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            //Transmitido
            if (rbTransmitido.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_anulado, 'N')";
                filtro[filtro.Length - 2].vOperador = "=";
                filtro[filtro.Length - 2].vVL_Busca = "'N'";
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and x.status = '100')";
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'C'", "<>");
            }
            //Transmitir
            if (rbTransmitir.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_lote_x_cte x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and x.status = '100')";
                Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'C'", "<>");
            }
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_ctrc.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_ctrc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_ctrc.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_remetente.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_remetente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_remetente.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_destinatario.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_destinatario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_destinatario.Text.Trim() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(chaveAcessoNFe.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_notafiscal x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and x.chave_acesso_nfe = '" + chaveAcessoNFe.Text.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(cd_motorista.Text))
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_motorista", "'" + cd_motorista.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(id_veiculo.Text))
                Utils.Estruturas.CriarParametro(ref filtro, "a.id_veiculo", "'" + id_veiculo.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(cdtomador.Text))
                Utils.Estruturas.CriarParametro(ref filtro, "a.cd_tomador", "'" + cdtomador.Text.Trim() + "'");
            bsCTe.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(filtro, 0, string.Empty);
            bsCTe_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsCTe.Current != null)
                if (!(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.HasValue ? true :
                    !(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.Value.Equals(100))
                {
                    //Excluir CTe
                    if (MessageBox.Show("Confirma exclusão do CTe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.ExcluiCTe(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, null);
                        MessageBox.Show("CTe excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                            CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_serie,
                                                                                         (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_modelo,
                                                                                         (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                         null);

                        //Verifica se Cte é importado, caso seja não altera sequencia na base, nem cfg
                        var obj = new CamadaDados.Faturamento.CTRC.TCD_Lote_X_CTe().BuscarEscalar(
                            new TpBusca[] {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctoctr",
                                            vOperador = "=",
                                            vVL_Busca = " '" + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC + "' "
                                        }
                            }, "a.nr_protocolo");
                        if (obj == null && (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_registro.Equals("P"))
                        {
                            afterBusca();
                            return;
                        }
                        if (lSeq.Count > 0)
                            if (lSeq[0].Seq_NotaFiscal.Equals((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_ctrc))
                            {
                                lSeq[0].Seq_NotaFiscal--;
                                CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                //Buscar configuracao cte
                                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfgCte =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                                if (lCfgCte.Count > 0)
                                {
                                    try
                                    {
                                        //Inutilizar numero nota
                                        CTe.Inutilizar.TInutilizarCte.InutilizarCte(lCfgCte[0].Cd_uf_empresa,
                                                                                    lCfgCte[0].Cnpj_empresa,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_serie,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_modelo,
                                                                                    DateTime.Now.Year.ToString(),
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_ctrc.Value,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_ctrc.Value,
                                                                                    "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DO CTE",
                                                                                    lCfgCte[0]);
                                        MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch
                                    { MessageBox.Show("Erro ao INUTILIZAR numero junto a receita.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        afterBusca();
                    }
                }
                else
                {
                    //Cancelar CTe
                    if (MessageBox.Show("Confirma cancelamento CTe?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        //Verificar se CTe ja nao foi cancelado junto a receita
                        CamadaDados.Faturamento.CTRC.TList_EventoCTe lEvento =
                            CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.Value.ToString(),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                        if (lEvento.Count.Equals(0) ? false : lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                        {
                            //Cancelar somente CTe no Aliance.NET
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.CancelarCTe((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete), null);
                            MessageBox.Show("CTe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        else
                        {
                            if (lEvento.Count.Equals(0))
                            {
                                Utils.InputBox ibp = new Utils.InputBox();
                                ibp.Text = "Motivo Cancelamento CTe";
                                string motivo = ibp.ShowDialog();
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    MessageBox.Show("Obrigatorio informar motivo de cancelamento do CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (motivo.Trim().Length < 15)
                                {
                                    MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Buscar evento Carta Correcao
                                CamadaDados.Faturamento.Cadastros.TList_Evento lEv =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                if (lEv.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe evento de CANCELAMENTO CTe cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar CTe Receita
                                CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe rEvento = new CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe();
                                rEvento.Cd_empresa = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa;
                                rEvento.Nr_lanctoctr = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC;
                                rEvento.Chaveacesso = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Chaveacesso;
                                rEvento.Nr_protocolo_cte = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Ds_evento = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.Justificativa = motivo;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Gravar(rEvento, null);
                                if (MessageBox.Show("Evento de CANCELAMENTO gravado com sucesso.\r\n" +
                                                    "Deseja enviar o mesmo para a receita?", "Pergunta",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        == DialogResult.Yes)
                                {
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                        CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfg.Count.Equals(0))
                                        MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + ".",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        string msg = CTe.Evento.TEventoCTe.EnviarEvento(rEvento, lCfg[0]);
                                        if (!string.IsNullOrEmpty(msg))
                                            MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                            "Aguarde um tempo e tente novamente.\r\n" +
                                                            "Erro: " + msg.Trim() + "\r\n" +
                                                            "Obs.: O CTe não será cancelado no sistema Aliance.NET enquanto o mesmo não for cancelado junto a receita.",
                                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        else
                                        {
                                            MessageBox.Show("Evento registrado e vinculado a CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.CancelarCTe((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete), null);
                                            MessageBox.Show("CTe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            afterBusca();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Buscar CfgNfe para a empresa
                                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    lEvento[0].Nr_protocolo_cte = (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_protocolo;
                                    string msg = CTe.Evento.TEventoCTe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(msg))
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + msg.Trim() + "\r\n" +
                                                        "Obs.: O CTe não será cancelado no sistema Aliance.NET enquanto o mesmo não for cancelado junto a receita.",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        MessageBox.Show("Evento registrado e vinculado a CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.CancelarCTe((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete), null);
                                        MessageBox.Show("CTe cancelado com sucesso no sistema Aliance.NET", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                }
                            }
                        }
                    }
                }
        }

        private void afterPrintDacte(CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCTe, bool St_dacte)
        {
            if (bsCTe.Current != null)
            {
                if (!rCTe.Status_cte.ToString().Trim().Equals("100"))
                {
                    MessageBox.Show("Permitido imprimir DACTE somente de CT-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource BinDados = new BindingSource();
                    BinDados.DataSource = rCTe;
                    Rel.DTS_Relatorio = BinDados;

                    //Buscar ENDEREÇO Emitente
                    BindingSource bs_endEmitente = new BindingSource();
                    bs_endEmitente.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_transportadora,
                                                                                  rCTe.Cd_endtransportadora,
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
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_remetente,
                                                                                  rCTe.Cd_endremetente,
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
                    if ((!string.IsNullOrEmpty(rCTe.Cd_expedidor)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endexpedidor)))
                        bs_endExpedidor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_expedidor,
                                                                                      rCTe.Cd_endexpedidor,
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
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_destinatario,
                                                                                  rCTe.Cd_enddestinatario,
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
                    if ((!string.IsNullOrEmpty(rCTe.Cd_recebedor)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endrecebedor)))
                        bs_endRecebedor.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_recebedor,
                                                                                      rCTe.Cd_endrecebedor,
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
                    if ((!string.IsNullOrEmpty(rCTe.Cd_tomador)) &&
                        (!string.IsNullOrEmpty(rCTe.Cd_endtomador)))
                        bs_endTomador.DataSource =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCTe.Cd_tomador,
                                                                                      rCTe.Cd_endtomador,
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
                                vVL_Busca = "'" + rCTe.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.NR_lanctoCTR",
                                vOperador = "=",
                                vVL_Busca = "'" + rCTe.Nr_lanctoCTRC.ToString().Trim() + "'"
                            }
                        }, 0, string.Empty);

                    //Buscar CFG Frota
                    BindingSource bs_CFG = new BindingSource();
                    bs_CFG.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(rCTe.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
                    //Buscar Empresa
                    BindingSource bs_empresa = new BindingSource();
                    bs_empresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCTe.Cd_empresa,
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
                                                    "and y.cd_empresa = '" + rCTe.Cd_empresa.Trim() + "' " +
                                                    "and y.nr_lanctoCTR = " + rCTe.Nr_lanctoCTRC+ ")"
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
                    if (rCTe.lQtdeCarga.Count > 0)
                        for (int i = 0; i < rCTe.lQtdeCarga.Count; i++)
                        {
                            if (i < 3)
                            {
                                Rel.Parametros_Relatorio.Add("UND_MED" + i.ToString(), rCTe.lQtdeCarga[i].Tp_medida);
                                Rel.Parametros_Relatorio.Add("QTD" + i.ToString(), rCTe.lQtdeCarga[i].Qt_carga + " ");
                            }
                            else
                                break;
                        }
                    //Montar Parametros Complemento Frete
                    if (rCTe.lCompValorFrete.Count > 0)
                        for (int i = 0; i < rCTe.lCompValorFrete.Count; i++)
                        {
                            if (i < 8)
                            {
                                Rel.Parametros_Relatorio.Add("NOMECOMP" + i.ToString(), rCTe.lCompValorFrete[i].Nm_componente);
                                Rel.Parametros_Relatorio.Add("VL_COMP" + i.ToString(), rCTe.lCompValorFrete[i].Vl_componente);
                            }
                            else
                                break;
                        }
                    Rel.Nome_Relatorio = "TFLanCTE_Dacte";
                    Rel.NM_Classe = "TFPainelCTe";
                    Rel.Modulo = "FRT";
                    Rel.Ident = "TFLanCTE_Dacte";
                    fImp.St_enabled_enviaremail = true;
                    fImp.St_receberXmlNfe = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.St_danfe = St_dacte;
                    fImp.pMensagem = "CTE";
                    //Verificar se existe logo configurada para a empresa
                    object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCTe.Cd_empresa.Trim() + "'"
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
                        fImp.pCd_clifor = rCTe.Cd_destinatario;
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
                                       CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(rCTe.Cd_empresa,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         null);
                                    //Gerar XML Periodo
                                    CTe.GerarArq.TGerarArq.GerarArquivoXmlPeriodo(path_anexo,
                                                                                  new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete() { rCTe },
                                                                                  lCfg[0]);
                                }
                                catch { }
                                if (System.IO.File.Exists(path_anexo + rCTe.Chaveacesso.Trim().Remove(0, 3) + "-cte.xml"))
                                {
                                    //Ler arquivo gerado
                                    Anexo = new List<string>();
                                    Anexo.Add(path_anexo + rCTe.Chaveacesso.Trim().Remove(0, 3) + "-cte.xml");
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
            if (bsCTe.Current == null ? false : MessageBox.Show("Deseja Gerar XML do CTe corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //Buscar novamente para carregar XML que estão no banco
                afterBusca();
                //Buscar CFG CTE
                rCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null)[0];
                string path_Xml = string.Empty;
                using (FolderBrowserDialog path = new FolderBrowserDialog())
                {
                    if (path.ShowDialog() == DialogResult.OK)
                        path_Xml = path.SelectedPath.Trim();
                    else
                        return;
                }

                //Limpar diretorio path arquivo
                string[] arq = System.IO.Directory.GetFiles(path_Xml.Trim(), "*.xml");
                if (arq.Length > 0)
                    if (MessageBox.Show("Existe arquivo XML antigo no path para salvar os novos arquivos.\r\n" +
                                        "Deseja excluir os arquivos antigos?", "Pergunta", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        for (int i = 0; i < arq.Length; i++)
                            System.IO.File.Delete(arq[i].Trim());
                try
                {
                    string msg = CTe.GerarArq.TGerarArq.GerarArquivoXmlPeriodo(path_Xml,
                                                                               new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete { bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete },
                                                                               rCfg);
                    MessageBox.Show("Arquivos gerados com sucesso." + (!string.IsNullOrEmpty(msg) ? "\r\n" + "Alguns arquivos não puderam ser gerados por inconsistencias.\r\n" + msg.Trim() : string.Empty), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                using (Proc_Commoditties.TFGerarXMLCTe fXml = new Proc_Commoditties.TFGerarXMLCTe())
                {
                    fXml.ShowDialog();
                }
        }

        private void AnularCTe()
        {
            if (bsCTe.Current != null)
            {
                //Verificar se CTe esta transmitido
                if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status.Trim().Equals("TRANSMITIDO"))
                {
                    Utils.InputBox ibp = new Utils.InputBox();
                    ibp.Text = "Motivo Anulação CTe";
                    string motivo = ibp.ShowDialog();
                    try
                    {
                        CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCte =
                        CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.AnularCTe(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, motivo, null);
                        MessageBox.Show("CTe de anulação gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Buscar CTe
                        rCte = CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.Buscar(rCte.Cd_empresa,
                                                                                           rCte.Nr_lanctoCTRC.Value.ToString(),
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
                                                                                           null)[0];
                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                        CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(rCte.Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                        if (lCfg.Count > 0)
                            //Gerar e assinar Arquivos xml
                            try
                            {
                                CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { rCte }, lCfg[0]);
                                MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Consultar lote
                                CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                {
                                    fPainel.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro enviar CTe: " + ex.Message);
                            }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else MessageBox.Show("Permitido gerar CTe de Anulação somente para CTe TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Obrigatorio selecionar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DuplicataCTe()
        {
            if (bsCTe.Current != null)
                using (TFCTe fCte = new TFCTe())
                {
                    fCte.St_duplicarCTe = true;
                    fCte.rCte = bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete;
                    if (fCte.ShowDialog() == DialogResult.OK)
                        if (fCte.rCte != null)
                        {
                            //Verificar se o CMI gera financeiro
                            CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCte.rCte.Cd_cmistr,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         false,
                                                                                                         false,
                                                                                                         false,
                                                                                                         false,
                                                                                                         false,
                                                                                                         false,
                                                                                                         false,
                                                                                                         null);
                            if (lCmi.Count > 0)
                                if (!string.IsNullOrEmpty(lCmi[0].Tp_duplicata))
                                {
                                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                    {
                                        fDuplicata.vCd_empresa = fCte.rCte.Cd_empresa;
                                        fDuplicata.vNm_empresa = fCte.rCte.Nm_empresa;
                                        fDuplicata.vCd_clifor = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Cd_destinatario : fCte.rCte.Cd_remetente;
                                        fDuplicata.vNm_clifor = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Nm_destinatario : fCte.rCte.Nm_remetente;
                                        fDuplicata.vCd_endereco = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Cd_enddestinatario : fCte.rCte.Cd_endremetente;
                                        fDuplicata.vDs_endereco = fCte.rCte.Tp_tomador.Equals("3") ? fCte.rCte.Ds_enddestinatario : fCte.rCte.Ds_endremetente;
                                        fDuplicata.vNr_docto = fCte.rCte.Nr_ctrcstr;
                                        fDuplicata.vDt_emissao = fCte.rCte.Dt_emissao.Value.ToString("dd/MM/yyyy");
                                        fDuplicata.vVl_documento = fCte.rCte.Vl_receber;
                                        fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                        fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                        fDuplicata.vCd_historico = lCmi[0].Cd_historico;
                                        fDuplicata.vDs_historico = lCmi[0].Ds_historico;
                                        fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                        fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                        fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                        fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                        fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                        fDuplicata.vCd_moeda = lCmi[0].Cd_moeda;
                                        fDuplicata.vDs_moeda = lCmi[0].Ds_moeda;
                                        fDuplicata.vSigla_moeda = lCmi[0].Sigla;
                                        //Buscar moeda Padrao

                                        fDuplicata.vSt_ctrc = true;
                                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                                            if (fDuplicata.dsDuplicata.Current != null)
                                            {
                                                fCte.rCte.rDuplicata =
                                                    fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                            try
                            {
                                CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(fCte.rCte, false, null);
                                if (MessageBox.Show("CTe gravado com sucesso.\r\nDeseja enviar o mesmo para receita?",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fCte.rCte.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                                    if (lCfg.Count > 0)
                                        //Gerar e assinar Arquivos xml
                                        try
                                        {
                                            CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { fCte.rCte }, lCfg[0]);
                                            MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Consultar lote
                                            CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                            LimparFiltros();
                                            cd_empresa.Text = fCte.rCte.Cd_empresa;
                                            nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                            afterBusca();
                                            if (bsCTe.Current != null)
                                                if ((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Status_cte.ToString().Equals("100"))
                                                    afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, true);
                                                else
                                                    using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                    {
                                                        fPainel.ShowDialog();
                                                    }
                                            else
                                                using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
                                                {
                                                    fPainel.ShowDialog();
                                                }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Erro enviar CTe: " + ex.Message);
                                        }
                                }
                                else
                                {
                                    LimparFiltros();
                                    cd_empresa.Text = fCte.rCte.Cd_empresa;
                                    nr_ctrc.Text = fCte.rCte.Nr_ctrcstr;
                                    afterBusca();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    afterBusca();
                }
        }

        private void ImportarXml()
        {
            XmlDocument xml = new XmlDocument();
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Documentos XML|*.xml";
                op.InitialDirectory = "c:";
                op.Title = "Selecione XML CTe";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(op.FileName))
                    {
                        pathSource = op.FileName;
                        xml.Load(op.FileName);
                    }
                }
            }

            CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCte = new CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete();
            CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga CTRCarga;
            CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete CTRComp;
            CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF rImpNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();
            //CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF ImpNF = new CamadaDados.Faturamento.NotaFiscal.TRegistro_ImpostosNF();

            #region Chave Acesso Informação Cte
            XmlNodeList lNo = xml.GetElementsByTagName("infCte");
            if (lNo.Count > 0)
            {
                rCte.Chaveacesso = lNo[0].Attributes.GetNamedItem("Id").InnerText.Remove(0, 3).ToString();
                //Verificar se já existe CTe
                object obj = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_CTR_ConhecimentoFrete ca " +
                                                    "where ca.ChaveAcesso = '" + rCte.Chaveacesso.ToString() + "')"
                                    }
                                }, "1");
                if (obj != null)
                {
                    MessageBox.Show("Xml já foi importado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Xml inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion



            #region Identificacao NFe
            lNo = xml.GetElementsByTagName("ide");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("cUF"))
                        rCte.Cd_uf_ini = no.InnerText;
                    if (no.LocalName.Equals("CFOP"))
                        rCte.Cd_cfop = no.InnerText;
                    else if (no.LocalName.Equals("natOp"))
                    {
                        rCte.Ds_movimentacao = no.InnerText;
                        var objCfop = new CamadaDados.Fiscal.TCD_CadCFOP().BuscarEscalar(new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_CFOP",
                                vOperador = "=",
                                vVL_Busca = "'" + rCte.Cd_cfop.ToString().Trim() + "'"
                            }
                        }, "a.CD_CFOP");
                        if (objCfop == null)
                        {
                            CamadaDados.Fiscal.TRegistro_CadCFOP rCadCFOP = new CamadaDados.Fiscal.TRegistro_CadCFOP();
                            rCadCFOP.CD_CFOP = rCte.Cd_cfop;
                            rCadCFOP.DS_CFOP = rCte.Ds_movimentacao;
                            CamadaNegocio.Fiscal.TCN_CadCFOP.Gravar(rCadCFOP, null);
                        }
                    }
                    else if (no.LocalName.Equals("mod"))
                        rCte.Cd_modelo = no.InnerText;
                    else if (no.LocalName.Equals("serie"))
                    {
                        rCte.Nr_serie = no.InnerText;
                        object objMod_x_Serie = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_serie",
                            vOperador = "=",
                            vVL_Busca = "'" + rCte.Nr_serie + "' "
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_modelo",
                            vOperador = "=",
                            vVL_Busca = "'" + rCte.Cd_modelo + "' "
                        }
                        }, "a.nr_serie");
                        if (objMod_x_Serie == null)
                        {
                            CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF rCadModelo = new CamadaDados.Faturamento.Cadastros.TRegistro_CadModeloNF();
                            rCadModelo.CD_Modelo = rCte.Cd_modelo;
                            rCadModelo.DS_Modelo = "TRANSPORTE ELETRONICO";
                            rCadModelo.ST_Registro = "A";
                            new CamadaDados.Faturamento.Cadastros.TCD_CadModeloNF().Grava(rCadModelo);

                            CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF rCadSerie = new CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF();
                            rCadSerie.Nr_Serie = rCte.Nr_serie;
                            rCadSerie.CD_Modelo = rCte.Cd_modelo;
                            rCadSerie.DS_SerieNf = "CTE";
                            rCadSerie.Tp_serie = "S";
                            rCadSerie.ST_SequenciaAuto = "S";
                            rCadSerie.ST_GeraSintegra = "S";
                            rCadSerie.ST_Registro = "A";
                            new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().Grava(rCadSerie);
                        }
                    }
                    else if (no.LocalName.Equals("nCT"))
                        rCte.Nr_ctrc = decimal.Parse(no.InnerText);
                    else if (no.LocalName.Equals("dhEmi"))
                        rCte.Dt_emissao = Convert.ToDateTime(no.InnerText);
                    else if (no.LocalName.Equals("tpEmis"))
                        rCte.Tp_emissao = no.InnerText;
                    else if (no.LocalName.Equals("tpCTe"))
                        rCte.Tp_cte = no.InnerText;
                    else if (no.LocalName.Equals("modal"))
                        rCte.Tp_modalidade = no.InnerText;
                    else if (no.LocalName.Equals("tpServ"))
                        rCte.Tp_servico = no.InnerText;
                    else if (no.LocalName.Equals("cMunIni"))
                        rCte.Cd_cidade_ini = no.InnerText;
                    else if (no.LocalName.Equals("xMunEnv"))
                        rCte.Ds_cidade_ini = no.InnerText;
                    else if (no.LocalName.Equals("UFIni"))
                        rCte.Uf_ini = no.InnerText;
                    else if (no.LocalName.Equals("cMunFim"))
                        rCte.Cd_cidade_fin = no.InnerText;
                    else if (no.LocalName.Equals("xMunFim"))
                        rCte.Ds_cidade_fin = no.InnerText;
                    else if (no.LocalName.Equals("UFFim"))
                        rCte.Uf_fin = no.InnerText;
                    else if (no.LocalName.Equals("retira"))
                        rCte.St_receberretira = no.InnerText;
                    else if (no.LocalName.Equals("toma0") ||
                        no.LocalName.Equals("toma1") ||
                        no.LocalName.Equals("toma2") ||
                        no.LocalName.Equals("toma3"))
                        foreach (XmlNode x in no.ChildNodes)
                        {
                            if (x.LocalName.Equals("toma"))
                                rCte.Tp_tomador = x.InnerText;
                        }
                    else if (no.LocalName.Equals("toma4"))
                    {
                        #region Controle tomador outros
                        string cd_tom = string.Empty, cep_tom = string.Empty, num_tom = string.Empty;

                        #region Busca na base cd_remetente
                        foreach (XmlNode t4 in no.ChildNodes)
                        {
                            if (string.IsNullOrEmpty(cd_tom))
                            {
                                if (t4.LocalName.Equals("CPF"))
                                {
                                    var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cpf",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Convert.ToUInt64(t4.InnerText).ToString(@"000\.000\.000\-00") + "' "
                                    }
                                        }, "a.cd_clifor");
                                    if (obj != null) cd_tom = obj.ToString();
                                }
                                else if (t4.LocalName.Equals("CNPJ"))
                                {
                                    var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cgc",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Convert.ToUInt64(t4.InnerText).ToString(@"00\.000\.000\/0000\-00")  + "'"
                                }
                                        }, "a.cd_clifor");
                                    if (obj != null) cd_tom = obj.ToString();
                                }
                            }

                            if (!string.IsNullOrEmpty(cd_tom))
                            {
                                rCte.Cd_tomador = cd_tom;
                                if (t4.LocalName.Equals("xNome"))
                                    rCte.Nm_tomador = t4.InnerText;
                                if (t4.LocalName.Equals("CNPJ"))
                                    rCte.Cnpj_tomador = t4.InnerText;
                                if (t4.LocalName.Equals("enderToma"))
                                    foreach (XmlNode x in t4.ChildNodes)
                                    {
                                        if (x.LocalName.Equals("nro"))
                                            num_tom = x.InnerText;
                                        if (x.LocalName.Equals("CEP"))
                                            cep_tom = x.InnerText;
                                    }
                            }
                        }
                        #endregion

                        #region Recupera clifor existente na base e atribui ao Cte
                        if (!string.IsNullOrEmpty(cd_tom))
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadClifor lCliforTom =
                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_tom  + "' "
                                }
                            }, 0, string.Empty);
                            rCte.Cd_condfiscal_tomador = lCliforTom[0].Cd_condfiscal_clifor;
                            rCte.Cd_tomador = lCliforTom[0].Cd_clifor;
                            rCte.Nm_tomador = lCliforTom[0].Nm_clifor;
                            rCte.Cnpj_tomador = lCliforTom[0].Tp_pessoa == "J" ? lCliforTom[0].Nr_cgc : string.Empty;

                            if (lCliforTom[0].St_registro.Equals("C"))
                            {
                                lCliforTom[0].St_registro = "A";
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(lCliforTom[0], null);
                            }
                        }
                        #endregion

                        #region Busca na base por CEP e NUM, caso tenha atribui a CTe
                        if (!string.IsNullOrEmpty(cep_tom) && (!string.IsNullOrEmpty(num_tom)))
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cep_tom.SoNumero()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.numero",
                                    vOperador = "=",
                                    vVL_Busca = "'" + num_tom.ToString()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_tom.ToString()  + "' "
                                }
                            }, 0, string.Empty);
                            if (lEndereco.Count > 0)
                                lEndereco.ForEach(p =>
                                {
                                    rCte.Cd_uf_tomador = p.Cd_uf;
                                    rCte.Uf_tomador = p.UF;
                                    rCte.Cd_endtomador = p.Cd_endereco;
                                });
                            else
                                cep_tom = string.Empty;
                        }
                        #endregion

                        #region tenho cliente, mas n tenho endereco
                        if (!string.IsNullOrEmpty(cd_tom) && (string.IsNullOrEmpty(cep_tom)))
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco end = new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                            end.Cd_clifor = cd_tom;
                            end.St_registro = "A";
                            if (lNo.Count > 0)
                            {
                                foreach (XmlNode t4 in no.ChildNodes)
                                {
                                    if (t4.LocalName.Equals("CPF"))
                                        end.cpf = t4.InnerText;
                                    else if (t4.LocalName.Equals("IE"))
                                        end.Insc_estadual = t4.InnerText;
                                    else if (t4.LocalName.Equals("xNome"))
                                        end.Nm_clifor = t4.InnerText;
                                    else if (t4.LocalName.Equals("fone"))
                                        end.Fone = t4.InnerText;
                                    else if (t4.LocalName.Equals("enderToma"))
                                        foreach (XmlNode x in t4.ChildNodes)
                                        {
                                            if (x.LocalName.Equals("xLgr"))
                                                end.Ds_endereco = x.InnerText;
                                            else if (x.LocalName.Equals("nro"))
                                                end.Numero = x.InnerText;
                                            else if (x.LocalName.Equals("xCpl"))
                                                end.Ds_complemento = x.InnerText;
                                            else if (x.LocalName.Equals("xBairro"))
                                                end.Bairro = x.InnerText;
                                            else if (x.LocalName.Equals("cMun"))
                                                end.Cd_cidade = x.InnerText;
                                            else if (x.LocalName.Equals("cPais"))
                                                end.CD_Pais = x.InnerText;
                                            else if (x.LocalName.Equals("CEP"))
                                                end.Cep = x.InnerText;
                                        }
                                }
                            }
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(end, null);
                            rCte.Cd_uf_tomador = end.Cd_uf;
                            rCte.Uf_tomador = end.UF;
                            rCte.Cd_endtomador = end.Cd_endereco;
                        }
                        #endregion

                        #region n tenho cliente, nem endereco
                        if (string.IsNullOrEmpty(cd_tom))
                        {
                            if (lNo.Count > 0)
                            {
                                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                                {
                                    foreach (XmlNode t4 in no.ChildNodes)
                                    {
                                        if (t4.LocalName.Equals("CPF"))
                                        {
                                            fClifor.pNR_CPF = t4.InnerText;
                                            fClifor.pTp_pessoa = "F";
                                        }
                                        else if (t4.LocalName.Equals("CNPJ"))
                                        {
                                            fClifor.pNR_CNPJ = t4.InnerText;
                                            fClifor.pTp_pessoa = "J";
                                        }
                                        else if (t4.LocalName.Equals("xNome"))
                                            fClifor.pNm_clifor = t4.InnerText;
                                        else if (t4.LocalName.Equals("fone"))
                                            fClifor.pFone_comercial = t4.InnerText;
                                        else if (t4.LocalName.Equals("enderToma"))
                                            foreach (XmlNode x in t4.ChildNodes)
                                            {
                                                if (x.LocalName.Equals("xLgr"))
                                                    fClifor.pDs_endereco = x.InnerText;
                                                else if (x.LocalName.Equals("nro"))
                                                    fClifor.pNumero = x.InnerText;
                                                else if (x.LocalName.Equals("xCpl"))
                                                    fClifor.pDs_complemento = x.InnerText;
                                                else if (x.LocalName.Equals("xBairro"))
                                                    fClifor.pBairro = x.InnerText;
                                                else if (x.LocalName.Equals("cMun"))
                                                    fClifor.pCd_cidade = x.InnerText;
                                                else if (x.LocalName.Equals("xMun"))
                                                    fClifor.pCidade = x.InnerText;
                                                else if (x.LocalName.Equals("CEP"))
                                                    fClifor.pCep = x.InnerText;
                                                else if (x.LocalName.Equals("UF"))
                                                    fClifor.pUF = x.InnerText;
                                            }
                                    }
                                    MessageBox.Show("O tomador disponibilizado no documento de importação não consta no sistema, para concluir será necessário efetuar o cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (fClifor.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                            rCte.Cd_condfiscal_tomador = fClifor.rClifor.Cd_condfiscal_clifor;
                                            rCte.Cd_tomador = fClifor.rClifor.Cd_clifor;
                                            rCte.Cd_endtomador = (string)new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new TpBusca[]
                                            {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fClifor.pCep.SoNumero()  + "' "
                                        },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.numero",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fClifor.pNumero.ToString()  + "' "
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fClifor.rClifor.Cd_clifor.ToString()  + "' "
                                    }
                                            }, "a.cd_endereco");
                                            rCte.Nm_tomador = fClifor.pNm_clifor;
                                            rCte.Cd_uf_tomador = fClifor.pCd_cidade;
                                            rCte.Uf_tomador = fClifor.pUF;
                                            rCte.Cnpj_tomador = fClifor.pTp_pessoa == "J" ? fClifor.pNR_CNPJ : string.Empty;
                                            cd_tom = fClifor.rClifor.Cd_clifor;
                                            MessageBox.Show("Tomador gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                    else
                                    {
                                        MessageBox.Show("A operação de importação foi cancelada, pois não foi efetuado o cadastro do tomador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                        #endregion

                        rCte.Tp_tomador = "4";

                        #endregion
                    }
                }
            }
            #endregion

            #region compl
            lNo = xml.GetElementsByTagName("compl");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("xObs"))
                    {
                        rCte.Ds_observacoes = no.InnerText;
                    }
                }
            }
            #endregion

            #region Emitente
            lNo = xml.GetElementsByTagName("emit");
            string cd_emit = string.Empty, cep_emit = string.Empty, num_emit = string.Empty;
            if (lNo.Count > 0)
            {

                #region Busca na base cd_emit
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (string.IsNullOrEmpty(cd_emit))
                    {
                        if (no.LocalName.Equals("CPF"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cpf",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"000\.000\.000\-00") + "' "
                                    }
                                }, "a.cd_clifor");
                            if (obj != null) cd_emit = obj.ToString();
                        }
                        else if (no.LocalName.Equals("CNPJ"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cgc",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"00\.000\.000\/0000\-00")  + "'"
                                }
                                }, "a.cd_clifor");
                            if (obj != null) cd_emit = obj.ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(cd_emit))
                    {
                        rCte.Cd_transportadora = cd_emit;
                        if (no.LocalName.Equals("xNome"))
                            rCte.Nm_transportadora = no.InnerText;
                        if (no.LocalName.Equals("CNPJ"))
                            rCte.Cnpj_transp = no.InnerText;
                        if (no.LocalName.Equals("enderEmit"))
                            foreach (XmlNode x in no.ChildNodes)
                            {
                                if (x.LocalName.Equals("nro"))
                                    num_emit = x.InnerText;
                                if (x.LocalName.Equals("CEP"))
                                    cep_emit = x.InnerText;
                            }
                    }
                }
                #endregion

                #region Recupera clifor existente na base e atribui ao Cte
                if (!string.IsNullOrEmpty(cd_emit))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lCliforEmit =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_emit  + "' "
                                }
                    }, 0, string.Empty);
                    rCte.Cd_condfiscal_transportadora = lCliforEmit[0].Cd_condfiscal_clifor;
                    rCte.Cd_transportadora = lCliforEmit[0].Cd_clifor;
                    rCte.Nm_transportadora = lCliforEmit[0].Nm_clifor;
                    rCte.Cnpj_transp = lCliforEmit[0].Tp_pessoa == "J" ? lCliforEmit[0].Nr_cgc : string.Empty;

                    if (lCliforEmit[0].St_registro.Equals("C"))
                    {
                        lCliforEmit[0].St_registro = "A";
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(lCliforEmit[0], null);
                    }
                }
                #endregion

                #region Busca na base por CEP e NUM, caso tenha atribui a CTe
                if (!string.IsNullOrEmpty(cep_emit) && (!string.IsNullOrEmpty(num_emit)))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cep_emit.SoNumero()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.numero",
                                    vOperador = "=",
                                    vVL_Busca = "'" + num_emit.ToString()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_emit.ToString()  + "' "
                                }
                    }, 0, string.Empty);
                    if (lEndereco.Count > 0)
                        lEndereco.ForEach(p =>
                        {
                            rCte.Cd_uf_transportadora = p.Cd_uf;
                            rCte.Uf_transportadora = p.UF;
                            rCte.Cd_endtransportadora = p.Cd_endereco;
                        });
                    else
                        cep_emit = string.Empty;
                }
                #endregion

                #region tenho cliente, mas n tenho endereco
                if (!string.IsNullOrEmpty(cd_emit) && (string.IsNullOrEmpty(cep_emit)))
                {
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco end = new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                    end.Cd_clifor = cd_emit;
                    end.St_registro = "A";
                    if (lNo.Count > 0)
                    {
                        foreach (XmlNode no in lNo[0].ChildNodes)
                        {
                            if (no.LocalName.Equals("CPF"))
                                end.cpf = no.InnerText;
                            else if (no.LocalName.Equals("IE"))
                                end.Insc_estadual = no.InnerText;
                            else if (no.LocalName.Equals("xNome"))
                                end.Nm_clifor = no.InnerText;

                            else if (no.LocalName.Equals("enderEmit"))
                                foreach (XmlNode x in no.ChildNodes)
                                {
                                    if (x.LocalName.Equals("xLgr"))
                                        end.Ds_endereco = x.InnerText;
                                    else if (x.LocalName.Equals("nro"))
                                        end.Numero = x.InnerText;
                                    else if (x.LocalName.Equals("xCpl"))
                                        end.Ds_complemento = x.InnerText;
                                    else if (x.LocalName.Equals("xBairro"))
                                        end.Bairro = x.InnerText;
                                    else if (x.LocalName.Equals("cMun"))
                                        end.Cd_cidade = x.InnerText;
                                    else if (x.LocalName.Equals("xMun"))
                                        end.DS_Cidade = x.InnerText;
                                    else if (x.LocalName.Equals("cPais"))
                                        end.CD_Pais = x.InnerText;
                                    else if (x.LocalName.Equals("CEP"))
                                        end.Cep = x.InnerText;
                                    else if (no.LocalName.Equals("fone"))
                                        end.Fone = no.InnerText;
                                }
                        }
                    }
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(end, null);
                    rCte.Cd_uf_transportadora = end.Cd_uf;
                    rCte.Uf_transportadora = end.UF;
                    rCte.Cd_endtransportadora = end.Cd_endereco;
                }
                #endregion

                #region n tenho cliente, nem endereco
                if (string.IsNullOrEmpty(cd_emit))
                {
                    if (lNo.Count > 0)
                    {
                        using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CPF"))
                                {
                                    fClifor.pNR_CPF = no.InnerText;
                                    fClifor.pTp_pessoa = "F";
                                }
                                else if (no.LocalName.Equals("CNPJ"))
                                {
                                    fClifor.pNR_CNPJ = no.InnerText;
                                    fClifor.pTp_pessoa = "J";
                                }
                                else if (no.LocalName.Equals("xNome"))
                                    fClifor.pNm_clifor = no.InnerText;
                                else if (no.LocalName.Equals("enderEmit"))
                                    foreach (XmlNode x in no.ChildNodes)
                                    {
                                        if (x.LocalName.Equals("xLgr"))
                                            fClifor.pDs_endereco = x.InnerText;
                                        else if (x.LocalName.Equals("nro"))
                                            fClifor.pNumero = x.InnerText;
                                        else if (x.LocalName.Equals("xCpl"))
                                            fClifor.pDs_complemento = x.InnerText;
                                        else if (x.LocalName.Equals("xBairro"))
                                            fClifor.pBairro = x.InnerText;
                                        else if (x.LocalName.Equals("cMun"))
                                            fClifor.pCd_cidade = x.InnerText;
                                        else if (x.LocalName.Equals("xMun"))
                                            fClifor.pCidade = x.InnerText;
                                        else if (x.LocalName.Equals("CEP"))
                                            fClifor.pCep = x.InnerText;
                                        else if (x.LocalName.Equals("UF"))
                                            fClifor.pUF = x.InnerText;
                                        else if (x.LocalName.Equals("fone"))
                                            fClifor.pFone_residencial = x.InnerText;
                                    }
                            }
                            MessageBox.Show("O emitente disponibilizado no documento de importação não consta no sistema, para concluir será necessário efetuar o cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (fClifor.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                    rCte.Cd_condfiscal_transportadora = fClifor.rClifor.Cd_condfiscal_clifor;
                                    rCte.Cd_transportadora = fClifor.rClifor.Cd_clifor;
                                    rCte.Nm_transportadora = fClifor.pNm_clifor;
                                    rCte.Cd_uf_transportadora = fClifor.pCd_cidade;
                                    rCte.Uf_transportadora = fClifor.pUF;
                                    rCte.Cnpj_transp = fClifor.pTp_pessoa == "J" ? fClifor.pNR_CNPJ : string.Empty;
                                    cd_emit = fClifor.rClifor.Cd_clifor;
                                    MessageBox.Show("Emitente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                            {
                                MessageBox.Show("A operação de importação foi cancelada, pois não foi efetuado o cadastro do emitente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region Remetente 
            lNo = xml.GetElementsByTagName("rem");
            string cd_rem = string.Empty, cep_rem = string.Empty, num_rem = string.Empty;
            if (lNo.Count > 0)
            {
                #region Busca na base cd_remetente
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (string.IsNullOrEmpty(cd_rem))
                    {
                        if (no.LocalName.Equals("CPF"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cpf",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"000\.000\.000\-00") + "' "
                                    }
                                }, "a.cd_clifor");
                            if (obj != null) cd_rem = obj.ToString();
                        }
                        else if (no.LocalName.Equals("CNPJ"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cgc",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"00\.000\.000\/0000\-00")  + "'"
                                }
                                }, "a.cd_clifor");
                            if (obj != null) cd_rem = obj.ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(cd_rem))
                    {
                        rCte.Cd_remetente = cd_rem;
                        if (no.LocalName.Equals("xNome"))
                            rCte.Nm_remetente = no.InnerText;
                        if (no.LocalName.Equals("CNPJ"))
                            rCte.Cnpj_remetente = no.InnerText;
                        if (no.LocalName.Equals("enderReme"))
                            foreach (XmlNode x in no.ChildNodes)
                            {
                                if (x.LocalName.Equals("nro"))
                                    num_rem = x.InnerText;
                                if (x.LocalName.Equals("CEP"))
                                    cep_rem = x.InnerText;
                            }
                    }
                }
                #endregion

                #region Recupera clifor existente na base e atribui ao Cte
                if (!string.IsNullOrEmpty(cd_rem))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lCliforRem =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_rem  + "' "
                                }
                    }, 0, string.Empty);
                    rCte.Cd_condfiscal_remetente = lCliforRem[0].Cd_condfiscal_clifor;
                    rCte.Cd_remetente = lCliforRem[0].Cd_clifor;
                    rCte.Nm_remetente = lCliforRem[0].Nm_clifor;
                    rCte.Cnpj_remetente = lCliforRem[0].Tp_pessoa == "J" ? lCliforRem[0].Nr_cgc : string.Empty;

                    if (lCliforRem[0].St_registro.Equals("C"))
                    {
                        lCliforRem[0].St_registro = "A";
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(lCliforRem[0], null);
                    }
                }
                #endregion

                #region Busca na base por CEP e NUM, caso tenha atribui a CTe
                if (!string.IsNullOrEmpty(cep_rem) && (!string.IsNullOrEmpty(num_rem)))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cep_rem.SoNumero()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.numero",
                                    vOperador = "=",
                                    vVL_Busca = "'" + num_rem.ToString()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_rem.ToString()  + "' "
                                }
                    }, 0, string.Empty);
                    if (lEndereco.Count > 0)
                        lEndereco.ForEach(p =>
                        {
                            rCte.Cd_uf_remetente = p.Cd_uf;
                            rCte.Uf_remetente = p.UF;
                            rCte.Cd_endremetente = p.Cd_endereco;
                        });
                    else
                        cep_rem = string.Empty;
                }
                #endregion

                #region tenho cliente, mas n tenho endereco
                if (!string.IsNullOrEmpty(cd_rem) && (string.IsNullOrEmpty(cep_rem)))
                {
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco end = new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                    end.Cd_clifor = cd_rem;
                    end.St_registro = "A";
                    if (lNo.Count > 0)
                    {
                        foreach (XmlNode no in lNo[0].ChildNodes)
                        {
                            if (no.LocalName.Equals("CPF"))
                                end.cpf = no.InnerText;
                            else if (no.LocalName.Equals("IE"))
                                end.Insc_estadual = no.InnerText;
                            else if (no.LocalName.Equals("xNome"))
                                end.Nm_clifor = no.InnerText;
                            else if (no.LocalName.Equals("fone"))
                                end.Fone = no.InnerText;
                            else if (no.LocalName.Equals("enderReme"))
                                foreach (XmlNode x in no.ChildNodes)
                                {
                                    if (x.LocalName.Equals("xLgr"))
                                        end.Ds_endereco = x.InnerText;
                                    else if (x.LocalName.Equals("nro"))
                                        end.Numero = x.InnerText;
                                    else if (x.LocalName.Equals("xCpl"))
                                        end.Ds_complemento = x.InnerText;
                                    else if (x.LocalName.Equals("xBairro"))
                                        end.Bairro = x.InnerText;
                                    else if (x.LocalName.Equals("cMun"))
                                        end.Cd_cidade = x.InnerText;
                                    else if (x.LocalName.Equals("cPais"))
                                        end.CD_Pais = x.InnerText;
                                    else if (x.LocalName.Equals("CEP"))
                                        end.Cep = x.InnerText;
                                }
                        }
                    }
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(end, null);
                    rCte.Cd_uf_remetente = end.Cd_uf;
                    rCte.Uf_remetente = end.UF;
                    rCte.Cd_endremetente = end.Cd_endereco;
                }
                #endregion

                #region n tenho cliente, nem endereco
                if (string.IsNullOrEmpty(cd_rem))
                {
                    if (lNo.Count > 0)
                    {
                        using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CPF"))
                                {
                                    fClifor.pNR_CPF = no.InnerText;
                                    fClifor.pTp_pessoa = "F";
                                }
                                else if (no.LocalName.Equals("CNPJ"))
                                {
                                    fClifor.pNR_CNPJ = no.InnerText;
                                    fClifor.pTp_pessoa = "J";
                                }
                                else if (no.LocalName.Equals("xNome"))
                                    fClifor.pNm_clifor = no.InnerText;
                                else if (no.LocalName.Equals("fone"))
                                    fClifor.pFone_comercial = no.InnerText;
                                else if (no.LocalName.Equals("enderReme"))
                                    foreach (XmlNode x in no.ChildNodes)
                                    {
                                        if (x.LocalName.Equals("xLgr"))
                                            fClifor.pDs_endereco = x.InnerText;
                                        else if (x.LocalName.Equals("nro"))
                                            fClifor.pNumero = x.InnerText;
                                        else if (x.LocalName.Equals("xCpl"))
                                            fClifor.pDs_complemento = x.InnerText;
                                        else if (x.LocalName.Equals("xBairro"))
                                            fClifor.pBairro = x.InnerText;
                                        else if (x.LocalName.Equals("cMun"))
                                            fClifor.pCd_cidade = x.InnerText;
                                        else if (x.LocalName.Equals("xMun"))
                                            fClifor.pCidade = x.InnerText;
                                        else if (x.LocalName.Equals("CEP"))
                                            fClifor.pCep = x.InnerText;
                                        else if (x.LocalName.Equals("UF"))
                                            fClifor.pUF = x.InnerText;
                                    }
                            }
                            MessageBox.Show("O remetente disponibilizado no documento de importação não consta no sistema, para concluir será necessário efetuar o cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (fClifor.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                    rCte.Cd_condfiscal_remetente = fClifor.rClifor.Cd_condfiscal_clifor;
                                    rCte.Cd_remetente = fClifor.rClifor.Cd_clifor;
                                    rCte.Cd_endremetente = (string)new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fClifor.pCep.SoNumero()  + "' "
                                        },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.numero",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fClifor.pNumero.ToString()  + "' "
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fClifor.rClifor.Cd_clifor.ToString()  + "' "
                                    }
                                    }, "a.cd_endereco");
                                    rCte.Nm_remetente = fClifor.pNm_clifor;
                                    rCte.Cd_uf_remetente = fClifor.pCd_cidade;
                                    rCte.Uf_remetente = fClifor.pUF;
                                    rCte.Cnpj_remetente = fClifor.pTp_pessoa == "J" ? fClifor.pNR_CNPJ : string.Empty;
                                    cd_rem = fClifor.rClifor.Cd_clifor;
                                    MessageBox.Show("Remetente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                            {
                                MessageBox.Show("A operação de importação foi cancelada, pois não foi efetuado o cadastro do remetente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region Destinatário
            lNo = xml.GetElementsByTagName("dest");
            string cd_dest = string.Empty, cep_dest = string.Empty, num_dest = string.Empty;
            if (lNo.Count > 0)
            {
                #region Busca na base cd_destinatário
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (string.IsNullOrEmpty(cd_dest))
                    {
                        if (no.LocalName.Equals("CPF"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cpf",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"000\.000\.000\-00") + "' "
                                }
                            }, "a.cd_clifor");
                            if (obj != null) cd_dest = obj.ToString();
                        }
                        else if (no.LocalName.Equals("CNPJ"))
                        {
                            var obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cgc",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Convert.ToUInt64(no.InnerText).ToString(@"00\.000\.000\/0000\-00")  + "'"
                                }
                                }, "a.cd_clifor");
                            if (obj != null) cd_dest = obj.ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(cd_dest))
                    {
                        rCte.Cd_destinatario = cd_dest;
                        if (no.LocalName.Equals("xNome"))
                            rCte.Nm_destinatario = no.InnerText;
                        if (no.LocalName.Equals("CNPJ"))
                            rCte.Cnpj_destinatario = no.InnerText;
                        if (no.LocalName.Equals("enderDest"))
                            foreach (XmlNode x in no.ChildNodes)
                            {
                                if (x.LocalName.Equals("nro"))
                                    num_dest = x.InnerText;
                                if (x.LocalName.Equals("CEP"))
                                    cep_dest = x.InnerText;
                            }
                    }

                }
                #endregion

                #region Recupera clifor existente na base e atribui ao Cte
                if (!string.IsNullOrEmpty(cd_dest))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lCliforDest =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_dest  + "' "
                                }
                    }, 0, string.Empty);
                    rCte.Cd_condfiscal_destinatario = lCliforDest[0].Cd_condfiscal_clifor;
                    rCte.Cd_destinatario = lCliforDest[0].Cd_clifor;
                    rCte.Nm_destinatario = lCliforDest[0].Nm_clifor;
                    rCte.Cnpj_destinatario = lCliforDest[0].Tp_pessoa == "J" ? lCliforDest[0].Nr_cgc : string.Empty;

                    if (lCliforDest[0].St_registro.Equals("C"))
                    {
                        lCliforDest[0].St_registro = "A";
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(lCliforDest[0], null);
                    }
                }
                #endregion

                #region Busca na base por CEP e NUM, se localizado atribui a CTe
                if (!string.IsNullOrEmpty(cep_dest) && (!string.IsNullOrEmpty(num_dest)))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndereco =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(new TpBusca[] {
                                new TpBusca()
                                {
                                    vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cep_dest.SoNumero() + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.numero",
                                    vOperador = "=",
                                    vVL_Busca = "'" + num_dest.ToString()  + "' "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_dest.ToString()  + "' "
                                }
                    }, 0, string.Empty);
                    if (lEndereco.Count > 0)
                        lEndereco.ForEach(p =>
                        {
                            cd_dest = p.Cd_clifor;
                            rCte.Cd_uf_destinatario = p.Cd_uf;
                            rCte.Uf_destinatario = p.UF;
                            rCte.Cd_enddestinatario = p.Cd_endereco;
                        });
                    else
                        cep_dest = string.Empty;
                }
                #endregion

                #region tenho cliente, mas n tenho endereco
                if (!string.IsNullOrEmpty(cd_dest) && (string.IsNullOrEmpty(cep_dest)))
                {
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco endDest = new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco();
                    endDest.Cd_clifor = cd_dest;
                    endDest.St_registro = "A";
                    if (lNo.Count > 0)
                    {
                        foreach (XmlNode no in lNo[0].ChildNodes)
                        {
                            if (no.LocalName.Equals("CPF"))
                                endDest.cpf = no.InnerText;
                            else if (no.LocalName.Equals("IE"))
                                endDest.Insc_estadual = no.InnerText;
                            else if (no.LocalName.Equals("xNome"))
                                endDest.Nm_clifor = no.InnerText;
                            else if (no.LocalName.Equals("fone"))
                                endDest.Fone = no.InnerText;
                            else if (no.LocalName.Equals("enderDest"))
                                foreach (XmlNode x in no.ChildNodes)
                                {
                                    if (x.LocalName.Equals("xLgr"))
                                        endDest.Ds_endereco = x.InnerText;
                                    else if (x.LocalName.Equals("nro"))
                                        endDest.Numero = x.InnerText;
                                    else if (x.LocalName.Equals("xCpl"))
                                        endDest.Ds_complemento = x.InnerText;
                                    else if (x.LocalName.Equals("xBairro"))
                                        endDest.Bairro = x.InnerText;
                                    else if (x.LocalName.Equals("cMun"))
                                        endDest.Cd_cidade = x.InnerText;
                                    else if (x.LocalName.Equals("cPais"))
                                        endDest.CD_Pais = x.InnerText;
                                    else if (x.LocalName.Equals("CEP"))
                                        endDest.Cep = x.InnerText;
                                    else if (x.LocalName.Equals("UF"))
                                        endDest.UF = x.InnerText;
                                }
                        }
                    }
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(endDest, null);
                    rCte.Cd_uf_destinatario = endDest.Cd_uf;
                    rCte.Uf_destinatario = endDest.UF;
                    rCte.Cd_enddestinatario = endDest.Cd_endereco;
                }
                #endregion

                #region n tenho cliente, nem endereco
                if (string.IsNullOrEmpty(cd_dest))
                {
                    if (lNo.Count > 0)
                    {
                        using (Financeiro.Cadastros.TFCadCliforResumido fCliforDest = new Financeiro.Cadastros.TFCadCliforResumido())
                        {
                            foreach (XmlNode no in lNo[0].ChildNodes)
                            {
                                if (no.LocalName.Equals("CPF"))
                                {
                                    fCliforDest.pNR_CPF = no.InnerText;
                                    fCliforDest.pTp_pessoa = "F";
                                }
                                else if (no.LocalName.Equals("CNPJ"))
                                {
                                    fCliforDest.pNR_CNPJ = no.InnerText;
                                    fCliforDest.pTp_pessoa = "J";
                                }
                                else if (no.LocalName.Equals("xNome"))
                                    fCliforDest.pNm_clifor = no.InnerText;
                                else if (no.LocalName.Equals("enderDest"))
                                    foreach (XmlNode x in no.ChildNodes)
                                    {
                                        if (x.LocalName.Equals("xLgr"))
                                            fCliforDest.pDs_endereco = x.InnerText;
                                        else if (x.LocalName.Equals("nro"))
                                            fCliforDest.pNumero = x.InnerText;
                                        else if (x.LocalName.Equals("xCpl"))
                                            fCliforDest.pDs_complemento = x.InnerText;
                                        else if (x.LocalName.Equals("xBairro"))
                                            fCliforDest.pBairro = x.InnerText;
                                        else if (x.LocalName.Equals("cMun"))
                                            fCliforDest.pCd_cidade = x.InnerText;
                                        else if (x.LocalName.Equals("xMun"))
                                            fCliforDest.pCidade = x.InnerText;
                                        else if (x.LocalName.Equals("CEP"))
                                            fCliforDest.pCep = x.InnerText;
                                        else if (x.LocalName.Equals("UF"))
                                            fCliforDest.pUF = x.InnerText;
                                    }
                            }
                            MessageBox.Show("O destinatário disponibilizado no documento de importação não consta no sistema, para concluir será necessário efetuar o cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (fCliforDest.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fCliforDest.rClifor, null);
                                    cd_dest = fCliforDest.rClifor.Cd_clifor;
                                    rCte.Cd_condfiscal_destinatario = fCliforDest.rClifor.Cd_condfiscal_clifor;
                                    rCte.Cd_destinatario = fCliforDest.rClifor.Cd_clifor;
                                    rCte.Cd_enddestinatario = (string)new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "dbo.FVALIDA_NUMEROS(a.cep)",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fCliforDest.pCep.SoNumero()  + "' "
                                        },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.numero",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fCliforDest.pNumero.ToString()  + "' "
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + fCliforDest.rClifor.Cd_clifor.ToString()  + "' "
                                    }
                                    }, "a.cd_endereco");
                                    rCte.Nm_destinatario = fCliforDest.pNm_clifor;
                                    rCte.Cd_uf_destinatario = fCliforDest.pCd_cidade;
                                    rCte.Uf_destinatario = fCliforDest.pUF;
                                    rCte.Cnpj_destinatario = fCliforDest.pTp_pessoa == "J" ? fCliforDest.pNR_CNPJ : string.Empty;
                                    MessageBox.Show("Destinatário gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            else
                            {
                                MessageBox.Show("A operação de importação foi cancelada, pois não foi efetuado o cadastro do destinatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region vPrest
            lNo = xml.GetElementsByTagName("vPrest");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("vTPrest"))
                        rCte.Vl_frete = decimal.Parse(no.InnerText.ToString().Replace(".", ","));
                    if (no.LocalName.Equals("vRec"))
                        rCte.Vl_receber = decimal.Parse(no.InnerText.ToString().Replace(".", ","));
                    if (no.LocalName.Equals("Comp"))
                    {
                        CTRComp = new CamadaDados.Faturamento.CTRC.TRegistro_CTRCompValorFrete();
                        foreach (XmlNode x in no.ChildNodes)
                        {
                            if (x.LocalName.Equals("xNome"))
                                CTRComp.Nm_componente = x.InnerText;
                            if (x.LocalName.Equals("vComp"))
                                CTRComp.Vl_componente = decimal.Parse(x.InnerText.ToString().Replace(".", ","));
                        }
                        rCte.lCompValorFrete.Add(CTRComp);
                    }
                }
            }
            #endregion

            #region imp
            lNo = xml.GetElementsByTagName("imp");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("ICMS"))
                    {
                        foreach (XmlNode x in no.ChildNodes)
                        {
                            #region ICMSSN
                            if (x.LocalName.Equals("ICMSSN"))
                            {
                                foreach (XmlNode y in x.ChildNodes)
                                {
                                    if (y.LocalName.Equals("CST")) { rCte.Cd_st = rImpNf.Cd_st = y.InnerText; }
                                    if (y.LocalName.Equals("indSN")) rCte.Cd_cmi = decimal.Parse(y.InnerText);
                                }
                                //Valida existencia do imposto informado
                                CamadaDados.Fiscal.TList_CadSitTribut lSit = new CamadaDados.Fiscal.TCD_CadSitTribut()
                                    .Select(new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_st", vOperador = "=", vVL_Busca = "'" + rCte.Cd_st.Trim() + "'"},
                                        new TpBusca {vNM_Campo = "b.st_icms", vOperador = "=", vVL_Busca = "1" }
                                    }, 1, string.Empty);
                                if (lSit.Count > 0)
                                {
                                    rImpNf.Cd_imposto = lSit[0].Cd_imposto;
                                    rImpNf.Ds_imposto = lSit[0].Ds_imposto;
                                    rImpNf.Ds_situacao = lSit[0].Ds_situacao;
                                }
                                else
                                {
                                    MessageBox.Show("O imposto de classificação tributária de serviço "
                                                    + rImpNf.Cd_st + " não está cadastrado no sistema. Não será possível finalizar a operação.", "Mensagem",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                rCte.lImpostos.Add(rImpNf);

                            }
                            #endregion
                            #region ICMS00
                            if (x.LocalName.Equals("ICMS00"))
                            {
                                foreach (XmlNode y in x.ChildNodes)
                                {
                                    if (y.LocalName.Equals("CST")) rCte.Cd_st = rImpNf.Cd_st = y.InnerText;
                                    if (y.LocalName.Equals("vBC")) rCte.Vl_baseICMS = rImpNf.Vl_basecalc = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                    if (y.LocalName.Equals("pICMS")) rCte.Pc_aliquotaICMS = rImpNf.Pc_aliquota = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                    if (y.LocalName.Equals("vICMS")) rCte.Vl_ICMS = rImpNf.Vl_impostocalc = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                }
                                //Valida existencia do imposto informado
                                CamadaDados.Fiscal.TList_CadSitTribut lSit = new CamadaDados.Fiscal.TCD_CadSitTribut()
                                    .Select(new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_st", vOperador = "=", vVL_Busca = "'" + rCte.Cd_st.Trim() + "'"},
                                        new TpBusca {vNM_Campo = "b.st_icms", vOperador = "=", vVL_Busca = "1" }
                                    }, 1, string.Empty);
                                if (lSit.Count > 0)
                                {
                                    rImpNf.Cd_imposto = lSit[0].Cd_imposto;
                                    rImpNf.Ds_imposto = lSit[0].Ds_imposto;
                                    rImpNf.Ds_situacao = lSit[0].Ds_situacao;
                                }
                                else
                                {
                                    MessageBox.Show("O imposto de classificação tributária de serviço "
                                                    + rImpNf.Cd_st + " não está cadastrado no sistema. Não será possível finalizar a operação.", "Mensagem",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                rCte.lImpostos.Add(rImpNf);

                            }
                            #endregion
                            #region ICMSOutraUF
                            if (x.LocalName.Equals("ICMSOutraUF"))
                            {
                                foreach (XmlNode y in x.ChildNodes)
                                {
                                    if (y.LocalName.Equals("CST")) rCte.Cd_st = rImpNf.Cd_st = y.InnerText;
                                    if (y.LocalName.Equals("vBCOutraUF")) rCte.Vl_baseICMS = rImpNf.Vl_basecalc = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                    if (y.LocalName.Equals("pICMSOutraUF")) rCte.Pc_aliquotaICMS = rImpNf.Pc_aliquota = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                    if (y.LocalName.Equals("vICMSOutraUF")) rCte.Vl_ICMS = rImpNf.Vl_impostocalc = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                }
                                //Valida existencia do imposto informado
                                CamadaDados.Fiscal.TList_CadSitTribut lSit = new CamadaDados.Fiscal.TCD_CadSitTribut()
                                    .Select(new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_st", vOperador = "=", vVL_Busca = "'" + rCte.Cd_st.Trim() + "'"},
                                        new TpBusca {vNM_Campo = "b.st_icms", vOperador = "=", vVL_Busca = "1" }
                                    }, 1, string.Empty);
                                if (lSit.Count > 0)
                                {
                                    rImpNf.Cd_imposto = lSit[0].Cd_imposto;
                                    rImpNf.Ds_imposto = lSit[0].Ds_imposto;
                                    rImpNf.Ds_situacao = lSit[0].Ds_situacao;
                                }
                                else
                                {
                                    MessageBox.Show("O imposto de classificação tributária de serviço "
                                                    + rImpNf.Cd_st + " não está cadastrado no sistema. Não será possível finalizar a operação.", "Mensagem",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                rCte.lImpostos.Add(rImpNf);

                            }
                            #endregion
                            #region ICMS60
                            if (x.LocalName.Equals("ICMS60"))
                            {
                                foreach (XmlNode y in x.ChildNodes)
                                {
                                    if (y.LocalName.Equals("CST")) { rCte.Cd_st = rImpNf.Cd_st = y.InnerText; }
                                    if (y.LocalName.Equals("vBCSTRet")) { rCte.Vl_baseICMS = rImpNf.Vl_basecalc = decimal.Parse(y.InnerText.ToString().Replace(".", ",")); }
                                    if (y.LocalName.Equals("vICMSSTRet")) { rCte.Vl_ICMS = rImpNf.Vl_impostocalc = decimal.Parse(y.InnerText.ToString().Replace(".", ",")); }
                                    if (y.LocalName.Equals("pICMSSTRet")) { rCte.Pc_aliquotaICMS = rImpNf.Pc_aliquota = decimal.Parse(y.InnerText.ToString().Replace(".", ",")); }
                                    //if (y.LocalName.Equals("vCred")) { rCte.Vl_credpresumido = rImpNf.Vl_credpresumido = decimal.Parse(y.InnerText.ToString().Replace(".", ",")); }
                                }
                                //Valida existencia do imposto informado
                                CamadaDados.Fiscal.TList_CadSitTribut lSit = new CamadaDados.Fiscal.TCD_CadSitTribut()
                                    .Select(new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_st", vOperador = "=", vVL_Busca = "'" + rCte.Cd_st.Trim() + "'"},
                                        new TpBusca {vNM_Campo = "b.st_icms", vOperador = "=", vVL_Busca = "1" }
                                    }, 1, string.Empty);
                                if (lSit.Count > 0)
                                {
                                    rImpNf.Cd_imposto = lSit[0].Cd_imposto;
                                    rImpNf.Ds_imposto = lSit[0].Ds_imposto;
                                    rImpNf.Ds_situacao = lSit[0].Ds_situacao;
                                }
                                else
                                {
                                    MessageBox.Show("O imposto de classificação tributária de serviço "
                                                    + rImpNf.Cd_st + " não está cadastrado no sistema. Não será possível finalizar a operação.", "Mensagem",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                rCte.lImpostos.Add(rImpNf);

                            }
                            #endregion
                        }

                        if (no.LocalName.Equals("vTotTrib"))
                            rCte.Vl_ICMS = decimal.Parse(no.InnerText.ToString().Replace(".", ","));
                        if (no.LocalName.Equals("infAdFisco"))
                            rCte.Ds_cmi = no.InnerText;
                    }

                }
            }
            #endregion

            #region infCTeNorm
            lNo = xml.GetElementsByTagName("infCTeNorm");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("infCarga"))
                        foreach (XmlNode x in no.ChildNodes)
                        {
                            if (x.LocalName.Equals("vCarga"))
                                rCte.Vl_carga = decimal.Parse(x.InnerText.ToString().Replace(".", ","));
                            if (x.LocalName.Equals("proPred"))
                                rCte.Ds_prodpredominante = x.InnerText;
                            if (x.LocalName.Equals("xOutCat"))
                                rCte.OutrasCaracCarga = x.InnerText;
                            if (x.LocalName.Equals("infQ"))
                            {
                                CTRCarga = new CamadaDados.Faturamento.CTRC.TRegistro_CTRQtdeCarga();
                                foreach (XmlNode y in x.ChildNodes)
                                {
                                    if (y.LocalName.Equals("cUnid"))
                                        CTRCarga.cUnid = y.InnerText;
                                    if (y.LocalName.Equals("tpMed"))
                                        CTRCarga.Tp_medida = y.InnerText;
                                    if (y.LocalName.Equals("qCarga"))
                                        CTRCarga.Qt_carga = decimal.Parse(y.InnerText.ToString().Replace(".", ","));
                                }
                                rCte.lQtdeCarga.Add(CTRCarga);
                            }
                        }
                    if (no.LocalName.Equals("infModal"))
                        foreach (XmlNode x in no.ChildNodes)
                            if (x.LocalName.Equals("rodo"))
                                foreach (XmlNode y in x.ChildNodes)
                                    if (y.LocalName.Equals("RNTRC"))
                                        rCte.Rntrc = y.InnerText;
                }

            }
            #endregion

            #region protCTe
            lNo = xml.GetElementsByTagName("protCTe");
            if (lNo.Count > 0)
            {
                foreach (XmlNode no in lNo[0].ChildNodes)
                {
                    if (no.LocalName.Equals("infProt"))
                        foreach (XmlNode x in no.ChildNodes)
                        {
                            if (x.LocalName.Equals("cStat"))
                            {
                                rCte.Status_cte = decimal.Parse(x.InnerText);
                                rCte.Status = "PROCESSADO";
                            }
                            if (x.LocalName.Equals("nProt"))
                                rCte.Nr_protocolo = decimal.Parse(x.InnerText);
                            if (x.LocalName.Equals("xMotivo"))
                                rCte.Msg_status = x.InnerText;
                            if (x.LocalName.Equals("digVal"))
                                rCte.digVal = x.InnerText;
                            if (x.LocalName.Equals("chCTe"))
                                rCte.Chaveacesso = x.InnerText;
                            if (x.LocalName.Equals("dhRecbto"))
                                rCte.Dt_recebimentostr = x.InnerText;
                        }
                }
            }

            rCte.Cd_empresa = (string)new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(new TpBusca[]
            {
                new TpBusca()
                {
                    vNM_Campo = "dbo.FVALIDA_NUMEROS(b.nr_cgc)",
                    vOperador = "=",
                    vVL_Busca =  "'" + rCte.Cnpj_transp.SoNumero() + "' "
                }
            }, "a.cd_Empresa");

            rCte.St_registro = "P";
            #endregion

            #region Listas da CTe

            #region lNfCTe
            CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal rCtrNf = new CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal();
            rCtrNf.Chave_acesso_nfe = rCte.Chaveacesso;
            rCtrNf.Dt_documento = rCte.Dt_emissao;
            rCtrNf.Vl_documento = rCte.Vl_frete;
            rCte.lNfCTe.Add(rCtrNf);
            rCte.lNfCTeDel.Add(rCtrNf);
            #endregion

            #endregion

            #region Veiculo e Motorista
            string vColuna = "a.ID_veiculo|Código|80;" +
                             "a.ds_veiculo|Descrição Veículo|200;" +
                             "a.placa|Placa|100";
            DataRowView rVeiculo = FormBusca.UtilPesquisa.BTN_BUSCA(vColuna, null,
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), null);
            if (rVeiculo != null)
            {
                rCte.Id_veiculo = decimal.Parse(rVeiculo.Row.ItemArray.GetValue(1).ToString());
                rCte.Ds_veiculo = rVeiculo.Row.ItemArray.GetValue(12).ToString();
                rCte.Placa = rVeiculo.Row.ItemArray.GetValue(15).ToString();
            }

            DataRowView rMotorista = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, "a.tp_pessoa|=|'F'");
            if (rMotorista != null)
            {
                rCte.Cd_motorista = rMotorista.Row.ItemArray.GetValue(0).ToString();
                rCte.Nm_motorista = rMotorista.Row.ItemArray.GetValue(1).ToString();
            }

            #endregion
            try
            {
                #region Emissão de duplicata
                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                {
                    fDuplicata.vCd_empresa = rCte.Cd_empresa;
                    fDuplicata.vNm_empresa = rCte.Nm_empresa;
                    fDuplicata.vCd_clifor = rCte.Tp_tomador.Equals("3") ? rCte.Cd_destinatario : rCte.Cd_remetente;
                    fDuplicata.vNm_clifor = rCte.Tp_tomador.Equals("3") ? rCte.Nm_destinatario : rCte.Nm_remetente;
                    fDuplicata.vCd_endereco = rCte.Tp_tomador.Equals("3") ? rCte.Cd_enddestinatario : rCte.Cd_endremetente;
                    fDuplicata.vDs_endereco = rCte.Tp_tomador.Equals("3") ? rCte.Ds_enddestinatario : rCte.Ds_endremetente;
                    fDuplicata.vNr_docto = rCte.Nr_ctrcstr;
                    fDuplicata.vDt_emissao = rCte.Dt_emissao.Value.ToString("dd/MM/yyyy");
                    fDuplicata.vVl_documento = rCte.Vl_receber;
                    fDuplicata.vTp_duplicata = "02";
                    fDuplicata.vDs_tpduplicata = "CONTAS A RECEBER";
                    fDuplicata.vTp_mov = "R";
                    fDuplicata.vSt_ctrc = false;
                    fDuplicata.vSt_alterar = false;
                    object condpgto = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().BuscarEscalar(null, "a.cd_condpgto");
                    fDuplicata.vCd_condpgto = condpgto != null?condpgto.ToString():"";
                    object moeda = new CamadaDados.Financeiro.Cadastros.TCD_Moeda().BuscarEscalar(null, "a.cd_moeda");
                    fDuplicata.vCd_moeda = moeda != null ? moeda.ToString() : "";
                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                    {
                        if (fDuplicata.dsDuplicata.Current != null)
                            rCte.rDuplicata = fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                        else
                        {
                            MessageBox.Show("Obrigatório informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion

                    #region Movimentacao x CMI
                    CamadaDados.Frota.Cadastros.TList_CfgFrota lConfig =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fDuplicata.vCd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                    if (lConfig.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe configuração de frota para a empresa. Efetuar configuração para finalizar a importação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (lConfig.Count > 0)
                    {
                        if (!lConfig[0].Cd_movcte.HasValue)
                        {
                            MessageBox.Show("Não existe movimentação de cte pré-configurado para a empresa. Efetuar configuração para finalizar a importação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (string.IsNullOrEmpty(lConfig[0].Nr_seriecte))
                        {
                            MessageBox.Show("Não existe número de série de cte pré-configurado para a empresa. Efetuar configuração para finalizar a importação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        rCte.Cd_movimentacao = lConfig[0].Cd_movcte;
                        object obj = new CamadaDados.Fiscal.TCD_CadMov_x_CMI().BuscarEscalar(
                            new TpBusca[] 
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_movimentacao",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rCte.Cd_movimentacao.ToString().Trim() + "'"
                                }
                            }, "a.cd_cmi");
                        if (obj.Equals(null))
                        {
                            MessageBox.Show("Não existe número de CMI cadastrado para a movimentação "+ rCte.Cd_movimentacao.ToString().Trim() + ". Efetuar cadastrado para finalizar a importação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        rCte.Cd_cmi = decimal.Parse(obj.ToString());
                    }
                        

                    #endregion

                    CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(rCte, false, null);

                    //Instancia LoteCTe
                    string id_lote = CamadaNegocio.Faturamento.CTRC.TCN_LoteCTe.Gravar(new CamadaDados.Faturamento.CTRC.TRegistro_LoteCTe()
                    {
                        Cd_empresa = rCte.Cd_empresa,
                        Dt_recebimento = rCte.Dt_recebimento,
                        Status = 104,
                        Ds_mensagem = "LOTE PROCESSADO POR IMPORTACAO",  //de forma alguma alterar está descrição, utilizado em opção corrigir cte
                        Tp_ambiente = "1"
                    }, null);
                    //Instancia Lote_x_CTe
                    CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Gravar(new CamadaDados.Faturamento.CTRC.TRegistro_Lote_X_CTe()
                    {
                        Cd_empresa = rCte.Cd_empresa,
                        Id_lotestr = id_lote,
                        Nr_lanctoctr = rCte.Nr_lanctoCTRC,
                        Dt_processamento = rCte.Dt_recebimento,
                        Nr_protocolo = rCte.Nr_protocolo,
                        Digval = rCte.digVal,
                        Status = rCte.Status_cte,
                        Ds_mensagem = rCte.Msg_status
                    }, null);

                    MessageBox.Show("Documentado gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_ctrc.Text = rCte.Nr_ctrcstr;
                    rbProcessados.Checked = true;
                    afterBusca();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanCTe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            Utils.ShapeGrid.RestoreShape(this, gCte);
            Utils.ShapeGrid.RestoreShape(this, gNF);
            Utils.ShapeGrid.RestoreShape(this, gSeguros);
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            Utils.ShapeGrid.RestoreShape(this, gEvento);
        }

        private void bb_cte_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFPainelCTe fPainel = new Proc_Commoditties.TFPainelCTe())
            {
                fPainel.ShowDialog();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_remetente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_remetente }, string.Empty);
        }

        private void cd_remetente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_remetente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_remetente }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
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

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLanCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && (bsCTe.Current != null))
                afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, false);
            else if (e.KeyCode.Equals(Keys.F9))
                DuplicataCTe();
            else if (e.KeyCode.Equals(Keys.F10))
                GerarXmlCTe();
            else if (e.KeyCode.Equals(Keys.F11))
                AnularCTe();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            if (bsCTe.Current != null)
                afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, false);
        }

        private void gCte_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().Equals("TRANSMITIDO"))
                        gCte.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gCte.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ANULADO"))
                        gCte.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else
                        gCte.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bsCTe_PositionChanged(object sender, EventArgs e)
        {
            if (bsCTe.Current != null)
            {
                //Buscar financeiro
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lParcelas =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_ctr_duplicata x "+
                                            "where x.cd_empresa = a.cd_empresa "+
                                            "and x.nr_lanctoduplicata = a.nr_lancto "+
                                            "and x.cd_empresa = '"+(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim()+"' "+
                                            "and x.nr_lanctoctr = "+(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC+")"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(d.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);

                //Buscar notas fiscais
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lNfCTe =
                    CamadaNegocio.Faturamento.CTRC.TCN_CTRNotaFiscal.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                             (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.ToString(),
                                                                             string.Empty,
                                                                             0,
                                                                             string.Empty,
                                                                             null);



                //Buscar Evento
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lEvento =
                    CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                         (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                //Buscar Quantidade
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lQtdeCarga =
                    CamadaNegocio.Faturamento.CTRC.TCN_CTRQtdeCarga.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                           (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.Value.ToString(),
                                                                           null);
                //Busca Componente
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lCompValorFrete =
                    CamadaNegocio.Faturamento.CTRC.TCN_CTRCompValorFrete.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.Value.ToString(),
                                                                                null);
                //Buscar Impostos
                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lImpostos =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Buscar(string.Empty,
                                                                               (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.Value.ToString(),
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               false,
                                                                               string.Empty,
                                                                               null);
                bsCTe.ResetCurrentItem();
            }
        }

        private void TFLanCTe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCte);
            Utils.ShapeGrid.SaveShape(this, gNF);
            Utils.ShapeGrid.SaveShape(this, gSeguros);
            Utils.ShapeGrid.SaveShape(this, gParcelas);
            Utils.ShapeGrid.SaveShape(this, gEvento);
        }

        private void bb_exclui_evento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Não é permitido excluir evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do evento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Excluir(bsEvento.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe, null);
                        MessageBox.Show("Evento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsEvento.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_enviarevento_Click(object sender, EventArgs e)
        {
            if (bsEvento.Current != null)
            {
                if ((bsEvento.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe).St_registro.Trim().ToUpper().Equals("T"))
                {
                    MessageBox.Show("Evento TRANSMITIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvento.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe).Tp_evento.Trim().ToUpper().Equals("CA"))
                    afterExclui();
                else
                {
                    //Buscar configuracao cte
                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfgCte =
                        CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                    if (lCfgCte.Count.Equals(0))
                        MessageBox.Show("Não existe configuração para envio de EVENTO para a empresa " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        try
                        {
                            string msg = CTe.Evento.TEventoCTe.EnviarEvento(bsEvento.Current as CamadaDados.Faturamento.CTRC.TRegistro_EventoCTe, lCfgCte[0]);
                            if (!string.IsNullOrEmpty(msg))
                                MessageBox.Show("Não existe configuração para envio de EVENTO para a empresa " + (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                MessageBox.Show("EVENTO enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).lEvento =
                                CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Buscar((bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                                                                                    (bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void BB_GerarXmlCTe_Click(object sender, EventArgs e)
        {
            GerarXmlCTe();
        }

        private void bb_dacte_Click(object sender, EventArgs e)
        {
            if (bsCTe.Current != null)
                afterPrintDacte(bsCTe.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete, false);
        }

        private void bb_listaCTe_Click(object sender, EventArgs e)
        {
            if (bsCTe.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = "TFLan_ListagemCTe";
                    Rel.Ident = "TFLan_ListagemCTe";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);

                    Rel.DTS_Relatorio = bsCTe;

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
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void gCte_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCte.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCTe.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete());
            CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCte.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCte.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCte.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCte.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete(lP.Find(gCte.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCte.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sort(lComparer);
            bsCTe.ResetBindings(false);
            gCte.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_anularCTe_Click(object sender, EventArgs e)
        {
            AnularCTe();
        }

        private void bb_duplicar_Click(object sender, EventArgs e)
        {
            DuplicataCTe();
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, "a.tp_pessoa|=|'F'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';a.tp_pessoa|=|'F'",
                new Componentes.EditDefault[] { cd_motorista }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_veiculo|Veiculo|150;a.placa|Placa|50;a.id_veiculo|Código|50",
                new Componentes.EditDefault[] { id_veiculo }, new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), string.Empty);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.id_veiculo|=|" + id_veiculo.Text,
                new Componentes.EditDefault[] { id_veiculo },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void cdtomador_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cdtomador.Text.Trim() + "'",
                new Componentes.EditDefault[] { cdtomador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tomador_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cdtomador }, string.Empty);
        }

        private void bb_importXml_Click(object sender, EventArgs e)
        {
            ImportarXml();
        }

    }
}
