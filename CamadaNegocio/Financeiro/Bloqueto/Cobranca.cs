using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Duplicata;

namespace CamadaNegocio.Financeiro.Bloqueto
{
    public class TCN_Titulo
    {
        //implementado para teste
        private static string ProcRetorno085(blListaTitulo lBloquetos,
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco,
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("26"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("10"))//Baixa Simples / Baixa conforme instrução banco
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("05") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            if (rPar.Vl_atual > rLiq.Cvl_aliquidar_padrao)
                            {
                                rLiq.Cvl_aliquidar_padrao += rPar.Vl_atual - rLiq.Cvl_aliquidar_padrao;
                                rLiq.cVl_Atual = rLiq.Cvl_aliquidar_padrao;
                                rLiq.cVl_descontoconcedido += rPar.Vl_atual - (lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento);
                            }
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno748(blListaTitulo lBloquetos, 
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco, 
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    //Buscar Bloqueto correpondente a linha do arquivo
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("24"))//Entrada confirmada
                    {
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim().Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                                {
                                    p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                    p.Ds_motivo = lBloquetos[i].Ds_motivo;
                                    retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                                });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09"))//Baixa Simples / Baixa conforme instrução banco
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "in",
                                    vVL_Busca = "('RT', 'PB')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                        blListaTitulo lTitulo =
                            new TCD_Titulo(qtb_bloqueto.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lBloquetos[i].Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nossonumero",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lBloquetos[i].Nosso_numero.Trim() + "'"
                                    }
                                }, 1, string.Empty);
                        if (lTitulo.Count > 0)
                        {
                            //Cancelar Bloqueto
                            Excluir(lTitulo[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("15") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))
                    {
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                    decimal.Zero,
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
                                                    "'A', 'D'",
                                                    string.Empty,
                                                    string.Empty,
                                                    lBloquetos[i].Nosso_numero.Trim(),
                                                    string.Empty,
                                                    string.Empty,
                                                    rCfgBanco.Id_configstr,
                                                    false,
                                                    1,
                                                    qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar, 
                                                                   rLiq, 
                                                                   null, 
                                                                   null, 
                                                                   null,
                                                                   null, 
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("19"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(rCfgBanco.Empresa.Cd_empresa,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno756(blListaTitulo lBloquetos, 
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco, 
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("26"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("10"))//Baixa Simples / Baixa conforme instrução banco
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("05") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                             lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            if (rPar.Vl_atual > rLiq.Cvl_aliquidar_padrao)
                            {
                                rLiq.Cvl_aliquidar_padrao += rPar.Vl_atual - rLiq.Cvl_aliquidar_padrao;
                                rLiq.cVl_Atual = rLiq.Cvl_aliquidar_padrao;
                                rLiq.cVl_descontoconcedido += rPar.Vl_atual - (lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas - lBloquetos[i].Vl_abatimento);
                            }
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros + lBloquetos[i].vl_outros_creditos + lBloquetos[i].Vl_outras_despesas;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno341(blListaTitulo lBloquetos, 
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco, 
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("32"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno237(blListaTitulo lBloquetos, 
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco, 
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("24") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("32"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("19"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno099(blListaTitulo lBloquetos,
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco,
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("24") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("32"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("19"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno001(blListaTitulo lBloquetos, 
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco, 
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03"))//Entrada confirmada/recusada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("10"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("05") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("07") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("08") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("15"))//Liquidação Sem Registro ou Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                    decimal.Zero,
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
                                                    "'A', 'D'",
                                                    string.Empty,
                                                    string.Empty,
                                                    lBloquetos[i].Nosso_numero,
                                                    string.Empty,
                                                    string.Empty,
                                                    rCfgBanco.Id_configstr,
                                                    false,
                                                    1,
                                                    qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno104(blListaTitulo lBloquetos,
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco,
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("03"))//Entrada confirmada/recusada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09") ||
                                lBloquetos[i].Cd_ocorrencia.Trim().Equals("10"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06"))//Liquidação
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Utils.Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno033(blListaTitulo lBloquetos,
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco,
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("07") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("08") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("17"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("15"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        private static string ProcRetorno422(blListaTitulo lBloquetos,
                                             TRegistro_CadCFGBanco rCfgBanco,
                                             TObjetoBanco banco,
                                             ref string msg)
        {
            msg = string.Empty;
            bool st_transacao = false;
            TCD_Titulo qtb_bloqueto = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bloqueto.CriarBanco_Dados(true);
                else
                    qtb_bloqueto.Banco_Dados = banco;
                string retorno = string.Empty;
                for (int i = 0; i < lBloquetos.Count; i++)
                {
                    if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("02"))//Entrada confirmada
                        //Localizar registro de titulo no lote envio de remessa para registro
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = lBloquetos[i].Cd_ocorrencia.Trim().Equals("02") ? "A" : "R";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("09") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("10"))//Baixa Simples
                    {
                        new TCD_LoteRemessa_X_Titulo(qtb_bloqueto.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "b.tp_instrucao",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_parcela = a.cd_parcela " +
                                                "and x.id_cobranca = a.id_cobranca " +
                                                "and x.cd_empresa = '" + rCfgBanco.Empresa.Cd_empresa.Trim() + "' " +
                                                "and x.id_config = " + rCfgBanco.Id_configstr + " " +
                                                "and x.nossonumero = '" + lBloquetos[i].Nosso_numero.Trim() + "')"
                                }

                            }, 0, string.Empty).ForEach(p =>
                            {
                                p.St_loteremessa = "B";
                                p.Ds_motivo = lBloquetos[i].Ds_motivoocorrencia;
                                retorno = TCN_LoteRemessa_X_Titulo.Gravar(p, qtb_bloqueto.Banco_Dados);
                            });
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("06") ||
                        lBloquetos[i].Cd_ocorrencia.Trim().Equals("15"))//Liquidacao Normal
                    {
                        //Buscar Bloqueto correpondente a linha do arquivo
                        TRegistro_LanParcela rPar = null;
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("P"))
                                continue;
                            //Buscar parcela que gerou o bloqueto
                            rPar = TCN_LanParcela.Busca(lBloq[0].Cd_empresa,
                                                        lBloq[0].Nr_lancto.Value,
                                                        lBloq[0].Cd_parcela.Value,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_bloqueto.Banco_Dados)[0];
                        }
                        else
                        {
                            msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " encontra-se cancelado ou compensado.\r\n";
                            continue;
                        }
                        if (rPar != null)
                        {
                            //Criar o objeto liquidacao
                            TRegistro_LanLiquidacao rLiq = new TRegistro_LanLiquidacao();
                            rLiq.Cd_contager = lBloq[0].Cd_contager;
                            rLiq.Cd_empresa = lBloq[0].Cd_empresa;
                            if (rPar.Cd_historico.Trim().Equals(string.Empty))
                                throw new Exception("Histórico " + rPar.Cd_historico.Trim() + " - " + rPar.Ds_historico.Trim() + " não tem histórico de quitação configurado.");
                            rLiq.Cd_historico = rPar.Cd_historico;
                            rLiq.Cd_historico_desc = rPar.Cd_historico_desconto;
                            rLiq.Cd_historico_juro = rPar.Cd_historico_juro;
                            rLiq.Cd_lanctocaixa = null;
                            rLiq.Cd_lanctocaixa_dcamb_at = null;
                            rLiq.Cd_lanctocaixa_dcamb_pa = null;
                            rLiq.Cd_lanctocaixa_Desc = null;
                            rLiq.Cd_lanctocaixa_Juro = null;
                            rLiq.Cd_parcela = rPar.Cd_parcela;
                            if (lBloq[0].Cd_portador.Trim().Equals(string.Empty))
                                throw new Exception("Não existe portador configurado para a Empresa: " + lBloq[0].Cd_empresa.Trim() + " Banco: " + lBloq[0].Cd_banco.Trim() + " Cedente: " + lBloq[0].Cedente.CodigoCedente.Trim());
                            rLiq.Cd_portador = lBloq[0].Cd_portador;
                            rLiq.ComplHistorico = "LIQUIDACAO BLOQUETO NR. " + lBloq[0].Nosso_numero.Trim();
                            rLiq.cVl_Nominal = lBloquetos[i].Vl_documento - lBloquetos[i].Vl_abatimento;
                            rLiq.Cvl_aliquidar_padrao = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_Atual = lBloquetos[i].Vl_documento + lBloquetos[i].Vl_morajuros - lBloquetos[i].Vl_abatimento;
                            rLiq.cVl_descontoconcedido = lBloquetos[i].Vl_desconto;
                            rLiq.cVl_juroliquidar = (lBloquetos[i].Vl_documento - lBloq[0].Vl_documento) + lBloquetos[i].Vl_morajuros;
                            rLiq.Dt_Liquidacao = lBloquetos[i].Dt_credito;
                            rLiq.Id_liquid = null;
                            rLiq.lCotacao = new TRegistro_LiquidacaoCotacao()
                            {
                                Cd_empresa = lBloq[0].Cd_empresa,
                                Nr_lancto = lBloq[0].Nr_lancto,
                                Cd_parcela = lBloq[0].Cd_parcela,
                                Id_liquid = null,
                                Cd_moeda = rPar.Cd_moeda,
                                Cd_moedaresult = rPar.Cd_moedaresult,
                                Dt_cotacao = lBloquetos[i].Dt_credito,
                                Operador = rPar.Operador,
                                Vl_cotacao = rPar.Vl_cotacao,
                                Login = Parametros.pubLogin
                            };
                            rLiq.Nr_docto = rPar.Nr_docto;
                            rLiq.Nr_lancto = lBloq[0].Nr_lancto;
                            rLiq.Tp_mov = rPar.Tp_mov;
                            //Parametro importante para diferenciar se a liquidacao esta ocorrendo
                            //pela tela de liquidacao ou pela conciliacao automatica de retorno
                            //Se for pela tela de liquidacao o bloqueto devera ser cancelado
                            rLiq.St_BloqLiquidacao = false;
                            //Chamar procedimento liquidar
                            TList_RegLanParcela lPar = new TList_RegLanParcela();
                            lPar.Add(rPar);
                            try
                            {
                                TCN_LanLiquidacao.GravarLiquidacao(lPar,
                                                                   rLiq,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_bloqueto.Banco_Dados);
                            }
                            catch (Exception ex)
                            {
                                msg += "Bloqueto Nº " + lBloquetos[i].Nosso_numero.Trim() + " não foi consolidado, Erro: " + ex.Message.Trim();
                                continue;
                            }
                            //Verificar se o bloqueto esta descontado
                            if (lBloq[0].St_registro.Trim().ToUpper().Equals("D"))
                            {
                                //Gravar lancamento de caixa de baixa desconto
                                if (rCfgBanco.Cd_historico_baixadesc.Trim().Equals(string.Empty))
                                    throw new Exception("Não existe historico de baixa de desconto de bloquetos configurado para " +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Conta Gerencial: " + lBloq[0].Cd_contager.Trim());
                                //Buscar Lote x Titulo
                                TList_Lote_X_Titulo lLoteBloqueto = TCN_Lote_X_Titulo.Buscar(null,
                                                                                             lBloq[0].Cd_empresa,
                                                                                             lBloq[0].Nr_lancto,
                                                                                             lBloq[0].Cd_parcela,
                                                                                             lBloq[0].Id_cobranca,
                                                                                             1,
                                                                                             string.Empty,
                                                                                             qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto.Count < 1)
                                    throw new Exception("Bloqueto não esta amarrado a nenhum lote de desconto.\r\n" +
                                                        "Empresa: " + lBloq[0].Cd_empresa.Trim() + "\r\n" +
                                                        "Duplicata: " + lBloq[0].Nr_lancto.ToString() + "/" + lBloq[0].Cd_parcela.ToString() + "\r\n" +
                                                        "Id. Cobranca: " + lBloq[0].Id_cobranca.ToString() + "\r\n" +
                                                        "Nosso Numero: " + lBloq[0].Nosso_numero.Trim());

                                //Gravar lancamento de caixa baixa
                                string cd_lanctocaixabaixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                {
                                                                    Cd_ContaGer = lBloq[0].Cd_contager,
                                                                    Cd_Empresa = lBloq[0].Cd_empresa,
                                                                    Cd_Historico = rCfgBanco.Cd_historico_baixadesc,
                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                    ComplHistorico = "BAIXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    Dt_lancto = lBloquetos[i].Dt_credito,
                                                                    Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                    St_Estorno = "N",
                                                                    Vl_PAGAR = Math.Round(lBloquetos[i].Vl_documento - lLoteBloqueto[0].Vl_taxa, 2),
                                                                    Vl_RECEBER = decimal.Zero
                                                                }, qtb_bloqueto.Banco_Dados);
                                //Amarrar lancamento de caixa da baixa com o bloqueto
                                TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                {
                                    Cd_contager = lBloq[0].Cd_contager,
                                    Cd_empresa = lBloq[0].Cd_empresa,
                                    Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixabaixa, "@P_CD_LANCTOCAIXA")),
                                    Cd_parcela = lBloq[0].Cd_parcela,
                                    Id_lancto = null,
                                    Id_liquid = rLiq.Id_liquid,
                                    Nr_lancto = lBloq[0].Nr_lancto
                                }, qtb_bloqueto.Banco_Dados);
                                if (lLoteBloqueto[0].Vl_taxa > 0)
                                {
                                    //Gravar lancamento de caixa da taxa
                                    string cd_lanctocaixataxa = Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                    {
                                                                        Cd_ContaGer = lBloq[0].Cd_contager,
                                                                        Cd_Empresa = lBloq[0].Cd_empresa,
                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxadesc,
                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                        ComplHistorico = "TAXA DESCONTO BLOQUETOS DO LOTE " + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        Dt_lancto = lBloquetos[i].Dt_credito,
                                                                        Nr_Docto = "LOTE" + lLoteBloqueto[0].Id_lote.ToString(),
                                                                        St_Estorno = "N",
                                                                        Vl_PAGAR = Math.Round(lLoteBloqueto[0].Vl_taxa, 2),
                                                                        Vl_RECEBER = decimal.Zero
                                                                    }, qtb_bloqueto.Banco_Dados);
                                    //Amarrar lancamento de caixa da taxa com o bloqueto
                                    TCN_LanLiquidacao_X_DescDup.GravarLiquidacao_X_DescDup(new TRegistro_LanLiquidacao_X_DescDup()
                                    {
                                        Cd_contager = lBloq[0].Cd_contager,
                                        Cd_empresa = lBloq[0].Cd_empresa,
                                        Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_lanctocaixataxa, "@P_CD_LANCTOCAIXA")),
                                        Cd_parcela = lBloq[0].Cd_parcela,
                                        Id_lancto = null,
                                        Id_liquid = rLiq.Id_liquid,
                                        Nr_lancto = lBloq[0].Nr_lancto
                                    }, qtb_bloqueto.Banco_Dados);
                                }
                            }
                            //Gravar Dados do registro do arquivo na tabela de bloqueto
                            lBloq[0].Dt_baixa = lBloquetos[i].Dt_baixa;
                            lBloq[0].Dt_credito = lBloquetos[i].Dt_credito;
                            lBloq[0].Dt_ocorrencia = lBloquetos[i].Dt_ocorrencia;
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_protesto;
                            lBloq[0].Vl_abatimento = lBloquetos[i].Vl_abatimento;
                            lBloq[0].Vl_desconto = lBloquetos[i].Vl_desconto;
                            lBloq[0].Vl_despesa_cobranca = lBloquetos[i].Vl_despesa_cobranca;
                            lBloq[0].Vl_iof = lBloquetos[i].Vl_iof;
                            lBloq[0].Vl_morajuros = lBloquetos[i].Vl_morajuros;
                            lBloq[0].Vl_outras_despesas = lBloquetos[i].Vl_outras_despesas;
                            lBloq[0].vl_outros_creditos = lBloquetos[i].vl_outros_creditos;
                            lBloq[0].St_registro = "P";
                            retorno = qtb_bloqueto.Gravar(lBloq[0]);
                        }
                        else
                        {
                            msg += "Não foi possivel localizar parcela para ser liquidada para o bloqueto com o nosso numero: " + lBloquetos[i].Nosso_numero.Trim() + "\r\n";
                            continue;
                        }
                    }
                    else if (lBloquetos[i].Cd_ocorrencia.Trim().Equals("19"))//Titulo Protestado
                    {
                        blListaTitulo lBloq = Buscar(string.Empty,
                                                     decimal.Zero,
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
                                                     "'A', 'D'",
                                                     string.Empty,
                                                     string.Empty,
                                                     lBloquetos[i].Nosso_numero,
                                                     string.Empty,
                                                     string.Empty,
                                                     rCfgBanco.Id_configstr,
                                                     false,
                                                     1,
                                                     qtb_bloqueto.Banco_Dados);
                        if (lBloq.Count > 0)
                        {
                            lBloq[0].St_protestado = "S";
                            lBloq[0].Dt_protesto = lBloquetos[i].Dt_ocorrencia;
                            Gravar(lBloq[0], qtb_bloqueto.Banco_Dados);
                        }
                    }
                }

                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bloqueto.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_bloqueto.deletarBanco_Dados();
            }
        }

        public static string GerarInstrucoes(string Tp_multa,
                                             decimal Pc_multa,
                                             decimal Nr_diasmulta,
                                             string Tp_jurodia,
                                             decimal Pc_jurodia,
                                             string Tp_desconto,
                                             decimal Pc_desconto,
                                             decimal Nr_diasdesconto,
                                             bool St_protestoauto,
                                             decimal Nr_diasprotesto,
                                             string Ds_instrucoes,
                                             decimal Vl_parcela,
                                             DateTime Dt_vencimento)
        {
            string retorno = Ds_instrucoes.Trim();
            if (Pc_multa > 0)
                retorno += (string.IsNullOrEmpty(retorno) ? string.Empty : "\r\n") + "Multa de    R$ " + string.Format("{0:N2}", Tp_multa.Trim().Equals("P") ? ((Vl_parcela * Pc_multa) / 100) : Pc_multa) + "    APOS " + Dt_vencimento.AddDays(Convert.ToDouble(Nr_diasmulta)).ToString("dd/MM/yyyy");
            if (Pc_jurodia > 0)
                retorno += (string.IsNullOrEmpty(retorno) ? string.Empty : "\r\n") + "Juro de     R$ " + string.Format("{0:N2}", Tp_jurodia.Trim().Equals("P") ? ((Vl_parcela * Pc_jurodia) / 100) : Pc_jurodia) + "    ao dia.";
            if (Pc_desconto > 0)
                retorno += (string.IsNullOrEmpty(retorno) ? string.Empty : "\r\n") + "Desconto de R$ " + 
                    string.Format("{0:N2}", Tp_desconto.Trim().Equals("P") ? ((Vl_parcela * Pc_desconto) / 100) : Pc_desconto) + "    ATE " +
                            Dt_vencimento.AddDays(Convert.ToDouble(Nr_diasdesconto * -1)).ToString("dd/MM/yyyy");
            if (St_protestoauto)
                retorno += (string.IsNullOrEmpty(retorno) ? string.Empty : "\r\n") + "PROTESTAR APOS " + (Nr_diasprotesto.Equals(decimal.Zero) ? "5" : Nr_diasprotesto.ToString()) + " DIAS";
            return retorno;
        }

        public static blListaTitulo Buscar(string vCd_empresa,
                                           decimal vNr_lancto,
                                           decimal vCd_parcela,
                                           decimal vId_cobranca,
                                           string vCd_contager,
                                           string vCd_banco,
                                           string vCd_cedente,
                                           string vCd_sacado,
                                           string vNr_docto,
                                           decimal vVl_inicial,
                                           decimal vVl_final,
                                           string vTp_data,
                                           string vDt_ini,
                                           string vDt_fin,
                                           string vVencidos,
                                           string vAvencer,
                                           string vSt_registro,
                                           string vCd_clifor,
                                           string vNm_campo,
                                           string vNossonumero,
                                           string vTp_duplicata,
                                           string vNr_contacorrente,
                                           string vId_config,
                                           bool St_protestado,
                                           int vTop,
                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (vNr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lancto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_parcela > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Parcela";
                filtro[filtro.Length - 1].vVL_Busca = vCd_parcela.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vId_cobranca > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Cobranca";
                filtro[filtro.Length - 1].vVL_Busca = vId_cobranca.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "f.CD_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_contager.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.CD_Banco";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_banco.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_cedente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "f.CodigoCedente";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_cedente.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_sacado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "sacado.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_sacado.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNr_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.NR_Docto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_docto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_inicial > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.Vl_Parcela_Padrao";
                filtro[filtro.Length - 1].vVL_Busca = vVl_inicial.ToString(new System.Globalization.CultureInfo("en-US"));
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if (vVl_final > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.Vl_Parcela_Padrao";
                filtro[filtro.Length - 1].vVL_Busca = vVl_final.ToString(new System.Globalization.CultureInfo("en-US"));
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                        (vTp_data.Trim().ToUpper().Equals("E") ? "a.DT_EmissaoBloqueto" :
                        vTp_data.Trim().ToUpper().Equals("V") ? "b.DT_Vencto" : "a.DT_Credito") + ")))";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                    filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("E") ? "a.DT_EmissaoBloqueto" :
                    vTp_data.Trim().ToUpper().Equals("V") ? "b.DT_Vencto" : "a.DT_Credito") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(vSt_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vSt_registro.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
                if (vSt_registro.Trim().ToUpper().Equals("'A'") && (!St_protestado))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_protestado, 'N')";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'S'";
                }
            }
            if (!string.IsNullOrEmpty(vVencidos))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "('A', 'D')";
                filtro[filtro.Length - 2].vOperador = "in";
                filtro[filtro.Length - 1].vNM_Campo = "b.DT_Vencto";
                filtro[filtro.Length - 1].vVL_Busca = "getDate()";
                filtro[filtro.Length - 1].vOperador = "<=";
                if (!St_protestado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_protestado, 'N')";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'S'";
                }
            }
            if (!string.IsNullOrEmpty(vAvencer))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 2].vVL_Busca = "('A', 'D')";
                filtro[filtro.Length - 2].vOperador = "in";
                filtro[filtro.Length - 1].vNM_Campo = "b.DT_Vencto";
                filtro[filtro.Length - 1].vVL_Busca = "getDate()";
                filtro[filtro.Length - 1].vOperador = ">";
                if (!St_protestado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_protestado, 'N')";
                    filtro[filtro.Length - 1].vOperador = "<>";
                    filtro[filtro.Length - 1].vVL_Busca = "'S'";
                }
            }
            if (!string.IsNullOrEmpty(vCd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_clifor = '" + vCd_clifor.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(vNossonumero))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nossonumero";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vNossonumero.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(vTp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.tp_duplicata = '" + vTp_duplicata.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(vNr_contacorrente))
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                filtro[filtro.Length - 2].vNM_Campo = "d.nr_contacorrente";
                filtro[filtro.Length - 2].vOperador = "=";
                filtro[filtro.Length - 2].vVL_Busca = "'" + vNr_contacorrente.Trim() + "'";
                filtro[filtro.Length - 1].vNM_Campo = "isnull(d.st_contacompensacao, 'N')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if(!string.IsNullOrEmpty(vId_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_config";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_config;
            }
            return new TCD_Titulo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static blListaTitulo LerRetorno(string Cd_empresa,
                                               string Cd_banco,
                                               string path_retorno,
                                               string Cd_bancocorrespondente,
                                               string[] files)
        {
            blListaTitulo lTitulo = new blCobranca().LerRetorno(path_retorno, Cd_banco, Cd_bancocorrespondente, files);
            if(lTitulo != null)
                lTitulo.ForEach(p => p.Cd_empresa = Cd_empresa);
            return lTitulo;
        }

        public static blListaTitulo GerarBloqueto(string vId_config, 
                                                  List<TRegistro_LanParcela> lParcelas, 
                                                  TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vId_config))
                throw new Exception("Erro gerar bloqueto. Falta configuração.");
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                //Buscar Config de Cobranca
                TList_CadCFGBanco lCfgbanco = TCN_CadCFGBanco.Buscar(vId_config,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     "A",
                                                                     string.Empty,
                                                                     0,
                                                                     qtb_titulo.Banco_Dados);
                decimal Nosso_numero = lCfgbanco[0].Nossonumero;
                //Gerar Boleto Bancario
                blListaTitulo lTitulos = new blListaTitulo();
                lParcelas.ForEach(p =>
                {
                    if (!p.St_registro.Trim().ToUpper().Equals("L"))
                    {
                        blTitulo rTitulo = new blTitulo();
                        rTitulo.Cd_empresa = p.Cd_empresa.Trim();
                        rTitulo.Nr_lancto = p.Nr_lancto;
                        rTitulo.Cd_parcela = p.Cd_parcela;
                        rTitulo.Id_config = lCfgbanco[0].Id_config;
                        rTitulo.Cd_contager = lCfgbanco[0].Cd_contager;
                        rTitulo.Tp_cobranca = lCfgbanco[0].Tp_cobranca;
                        rTitulo.Dt_emissaobloqueto = p.Dt_emissao;
                        //Regra especifica do Sicredi
                        //Verificar se o banco e 748
                        //Verificar se o ano ainda e o mesmo
                        if (lCfgbanco[0].Banco.Cd_banco.Trim().Equals("748"))
                            if (lCfgbanco[0].Ano.Trim() != DateTime.Now.ToString("dd/MM/yyyy").Substring(6, 4).Trim())
                            {
                                //Alterar o ano do cadastro de configuração
                                lCfgbanco[0].Ano = DateTime.Now.ToString("dd/MM/yyyy").Substring(6, 4).Trim();
                                Nosso_numero = decimal.Zero;
                            }
                        rTitulo.Nosso_numero = rTitulo.CalcularNossoNumero(string.IsNullOrEmpty(lCfgbanco[0].Cd_bancocorrespondente) ? lCfgbanco[0].Banco.Cd_banco : lCfgbanco[0].Cd_bancocorrespondente, 
                                                                           Nosso_numero, 
                                                                           lCfgbanco[0].Banco.Cd_banco.Trim().Equals("085") ? lCfgbanco[0].Nr_contacorrente : lCfgbanco[0].ConvenioCobranca, 
                                                                           lCfgbanco[0].Banco.Cd_banco.Trim().Equals("085") ? lCfgbanco[0].Digitoconta : lCfgbanco[0].Codigocedente, 
                                                                           lCfgbanco[0].Tp_carteira);
                        if(new TCD_Titulo(qtb_titulo.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.CD_ContaGer",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCfgbanco[0].Cd_contager.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.codigocedente",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCfgbanco[0].Codigocedente.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nossonumero",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rTitulo.Nosso_numero.Trim() + "'"
                                }
                            }, "1") != null)
                            throw new Exception("Ja existe um boleto no sistema com o nosso numero " + rTitulo.Nosso_numero.Trim() + ".");
                        rTitulo.Aceite_documento = lCfgbanco[0].Aceite_sn.Trim().ToUpper().Equals("S") ? TAceiteDocumento.adSim : TAceiteDocumento.adNao;
                        rTitulo.Carteira = lCfgbanco[0].Tp_carteira;
                        rTitulo.Local_pagamento = lCfgbanco[0].Ds_localpagamento;
                        rTitulo.Instrucoes = GerarInstrucoes(lCfgbanco[0].Tp_multa,
                                                             lCfgbanco[0].Pc_multa,
                                                             lCfgbanco[0].Nr_diasmulta,
                                                             lCfgbanco[0].Tp_jurodia,
                                                             lCfgbanco[0].Pc_jurodia,
                                                             lCfgbanco[0].Tp_desconto,
                                                             lCfgbanco[0].Pc_desconto,
                                                             lCfgbanco[0].Nr_diasdesconto,
                                                             lCfgbanco[0].St_protestoautobool,
                                                             lCfgbanco[0].Nr_diasprotesto,
                                                             lCfgbanco[0].Ds_instrucoes,
                                                             p.Vl_parcela_padrao, 
                                                             p.Dt_vencto.Value);
                        rTitulo.Especie_documento = blTitulo.RetornarEspecieDocumento(Convert.ToInt32(lCfgbanco[0].EspecieDocumento));
                        rTitulo.Cedente.CodigoCedente = lCfgbanco[0].Codigocedente;
                        if (lCfgbanco[0].Nr_diasprotesto > 0)
                            rTitulo.Dt_protesto = p.Dt_vencto.Value.AddDays(Convert.ToDouble(lCfgbanco[0].Nr_diasprotesto));
                        //Gravar o Titulo
                        string retorno = qtb_titulo.Gravar(rTitulo);
                        rTitulo.Id_cobranca = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_COBRANCA"));
                        lTitulos.Add(rTitulo);
                        //Incrementar Nosso Numero
                        Nosso_numero++;
                    }
                });
                //Gravar nosso numero atual na config
                lCfgbanco[0].Nossonumero = Nosso_numero;
                TCN_CadCFGBanco.Gravar(lCfgbanco[0], qtb_titulo.Banco_Dados);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return lTitulos;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar bloqueto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static void AtualizarBoleto(blTitulo titulo,
                                           DateTime Dt_atualizada,
                                           TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else qtb_titulo.Banco_Dados = banco;
                //Alterar data vencimento da parcela
                TRegistro_LanParcela rParc =
                TCN_LanParcela.BuscarParcela(titulo.Cd_empresa,
                                             titulo.Nr_lancto.Value.ToString(),
                                             titulo.Cd_parcela.Value.ToString(),
                                             qtb_titulo.Banco_Dados);
                DateTime dt_original = rParc.Dt_vencto.Value;
                rParc.Dt_vencto = Dt_atualizada;
                //Gravar Atualização Parcela
                TCN_AtVenctoParcela.Gravar(new TRegistro_AtVenctoParcela()
                {
                    Cd_empresa = titulo.Cd_empresa,
                    Nr_lancto = titulo.Nr_lancto,
                    Cd_parcela = titulo.Cd_parcela,
                    LoginAtualiza = Utils.Parametros.pubLogin,
                    Dt_vencto = dt_original,
                    Vl_parcela = rParc.Vl_parcela

                }, qtb_titulo.Banco_Dados);
                TCN_LanParcela.AlterarParcela(rParc, qtb_titulo.Banco_Dados);
                //Buscar Atualização Parcela
                TList_AtVenctoParcela lAt =
                    new TCD_AtVenctoParcela(qtb_titulo.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + titulo.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = titulo.Nr_lancto.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_parcela",
                                vOperador = "=",
                                vVL_Busca = titulo.Cd_parcela.ToString() 
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                //Gravar alteração titulo (Multa e Juro Calculado)
                TList_CadCFGBanco lCfg = TCN_CadCFGBanco.Buscar(titulo.Id_config.Value.ToString(),
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                1,
                                                                qtb_titulo.Banco_Dados);
                if(lCfg.Count > 0)
                {
                    titulo.Instrucoes = lCfg[0].Ds_instrucoes.Trim();
                    if(lCfg[0].St_protestoautobool)
                        titulo.Instrucoes += (string.IsNullOrWhiteSpace(titulo.Instrucoes) ? string.Empty : "\r\n") +
                                                "PROTESTAR APOS " + (lCfg[0].Nr_diasprotesto.Equals(decimal.Zero) ? "5" : lCfg[0].Nr_diasprotesto.ToString()) + " DIAS";
                }
                titulo.Instrucoes += (string.IsNullOrWhiteSpace(titulo.Instrucoes) ? string.Empty : "\r\n") +
                                    "VÁLIDO PARA PAGAMENTO SOMENTE ATÉ O DIA " + Dt_atualizada.ToString("dd/MM/yyyy") + "\r\n" +
                                    "BOLETO REEMITIDO COM DATA DE VENCTO E VALOR ATUALIZADOS\r\n" +
                                    "(VALOR ORIGINAL + ENCARGOS)\r\n" +
                                    "VENCIMENTO ORIGINAL: " + (lAt.Count > 0 ? lAt[0].Dt_venctostring : dt_original.ToString("dd/MM/yyyy")) + "\r\n" +
                                    "VALOR ORIGINAL: " + (lAt.Count > 0 ? lAt[0].Vl_parcela : rParc.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                                    "ENCARGOS: " + (titulo.Vl_atual - (lAt.Count > 0 ? lAt[0].Vl_parcela : rParc.Vl_atual)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                qtb_titulo.Gravar(titulo);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar boleto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string Gravar(blTitulo titulo, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                string retorno = qtb_titulo.Gravar(titulo);
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar bloqueto: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string ConciliarRetorno(blListaTitulo lBloquetos, 
                                              TRegistro_CadCFGBanco rCfgBanco,
                                              TObjetoBanco banco, ref string msg)
        {
            if (lBloquetos.Count > 0)
            {
                if (lBloquetos[0].Cd_banco.Trim().Equals("001"))
                    return ProcRetorno001(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("033"))
                    return ProcRetorno033(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("104"))
                    return ProcRetorno104(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("237"))
                    return ProcRetorno237(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("422"))
                    return ProcRetorno422(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("748"))
                    return ProcRetorno748(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("756"))
                    return ProcRetorno756(lBloquetos, rCfgBanco, banco, ref msg);
                else if (lBloquetos[0].Cd_banco.Trim().Equals("341"))
                    return ProcRetorno341(lBloquetos, rCfgBanco, banco, ref msg);
                //implementado para teste
                else if (lBloquetos[0].Cd_banco.Trim().Equals("085"))
                    return ProcRetorno085(lBloquetos, rCfgBanco, banco, ref msg);
                else return string.Empty;
            }
            else return string.Empty;
        }

        public static void GravarTarifas(blListaTitulo lBloquetos, 
                                         TRegistro_CadCFGBanco rCfgBanco, 
                                         TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                if (lBloquetos.Count < 1)
                    throw new Exception("Não existe bloqueto para lançar taxa.");
                if (rCfgBanco.Cd_historico_taxacob.Trim().Equals(string.Empty))
                    throw new Exception("Não existe historico de taxa de cobrança configurado para \r\n" +
                                        "Empresa: " + rCfgBanco.Empresa.Cd_empresa.Trim() + "\r\n" +
                                        "Banco: " + rCfgBanco.Banco.Cd_banco.Trim() + "\r\n" +
                                        "Cedente: " + rCfgBanco.Codigocedente.Trim());
                lBloquetos.Where(p => (p.Vl_despesa_cobranca > decimal.Zero)).GroupBy(p => p.Dt_creditotaxa.Value,
                                                                    (aux, bloq) =>
                                                                        new
                                                                        {
                                                                            dt_creditotaxa = aux,
                                                                            vl_taxa = bloq.Sum(x => x.Vl_despesa_cobranca)
                                                                        }).ToList().ForEach(p =>
                                                                            {
                                                                                //Gravar lancamento de caixa para taxa
                                                                                string id_caixa =
                                                                                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                                    {
                                                                                        Cd_ContaGer = rCfgBanco.Cd_contager,
                                                                                        Cd_Empresa = rCfgBanco.Empresa.Cd_empresa,
                                                                                        Cd_Historico = rCfgBanco.Cd_historico_taxacob,
                                                                                        Cd_LanctoCaixa = decimal.Zero,
                                                                                        ComplHistorico = "TARIFA DE COBRANCA",
                                                                                        Dt_lancto = p.dt_creditotaxa,
                                                                                        Nr_Docto = "TARIFACOB",
                                                                                        St_Estorno = "N",
                                                                                        St_avulso = "S",
                                                                                        Vl_PAGAR = p.vl_taxa,
                                                                                        Vl_RECEBER = decimal.Zero
                                                                                    }, qtb_titulo.Banco_Dados);
                                                                                if (!string.IsNullOrEmpty(rCfgBanco.Cd_centroresultTXCob))
                                                                                {
                                                                                    //Centro Resultado
                                                                                    string id_custo =
                                                                                    CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                                                                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                                                        {
                                                                                            Cd_empresa = rCfgBanco.Empresa.Cd_empresa,
                                                                                            Cd_centroresult = rCfgBanco.Cd_centroresultTXCob,
                                                                                            Vl_lancto = p.vl_taxa,
                                                                                            Dt_lancto = p.dt_creditotaxa,
                                                                                            Tp_registro = "A"
                                                                                        }, qtb_titulo.Banco_Dados);
                                                                                    //Centro Resultado x Caixa
                                                                                    CamadaNegocio.Financeiro.Caixa.TCN_Caixa_X_CCusto.Gravar(
                                                                                        new CamadaDados.Financeiro.Caixa.TRegistro_Caixa_X_CCusto()
                                                                                        {
                                                                                            Cd_contager = rCfgBanco.Cd_contager,
                                                                                            Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(id_caixa, "@P_CD_LANCTOCAIXA"),
                                                                                            Id_ccustolan = decimal.Parse(id_custo)
                                                                                        }, qtb_titulo.Banco_Dados);
                                                                                }
                                                                            });
                lBloquetos.Where(p => (p.Vl_despesa_cobranca.Equals(decimal.Zero))).GroupBy(p => p.Dt_credito.Value,
                                                                    (aux, bloq) =>
                                                                        new
                                                                        {
                                                                            dt_creditotaxa = aux,
                                                                            vl_taxa = bloq.Count() * rCfgBanco.Vl_taxa
                                                                        }).ToList().ForEach(p =>
                                                                        {
                                                                            //Gravar lancamento de caixa para taxa
                                                                            string id_caixa =
                                                                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                                                                new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                                                                {
                                                                                    Cd_ContaGer = rCfgBanco.Cd_contager,
                                                                                    Cd_Empresa = rCfgBanco.Empresa.Cd_empresa,
                                                                                    Cd_Historico = rCfgBanco.Cd_historico_taxacob,
                                                                                    Cd_LanctoCaixa = decimal.Zero,
                                                                                    ComplHistorico = "TARIFA DE COBRANCA",
                                                                                    Dt_lancto = p.dt_creditotaxa,
                                                                                    Nr_Docto = "TARIFACOB",
                                                                                    St_Estorno = "N",
                                                                                    St_avulso = "S",
                                                                                    Vl_PAGAR = p.vl_taxa,
                                                                                    Vl_RECEBER = decimal.Zero
                                                                                }, qtb_titulo.Banco_Dados);
                                                                            if (!string.IsNullOrEmpty(rCfgBanco.Cd_centroresultTXCob))
                                                                            {
                                                                                //Centro Resultado
                                                                                string id_custo =
                                                                                CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                                                                                    new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                                                    {
                                                                                        Cd_empresa = rCfgBanco.Empresa.Cd_empresa,
                                                                                        Cd_centroresult = rCfgBanco.Cd_centroresultTXCob,
                                                                                        Vl_lancto = p.vl_taxa,
                                                                                        Dt_lancto = p.dt_creditotaxa,
                                                                                        Tp_registro = "A"
                                                                                    }, qtb_titulo.Banco_Dados);
                                                                                //Centro Resultado x Caixa
                                                                                CamadaNegocio.Financeiro.Caixa.TCN_Caixa_X_CCusto.Gravar(
                                                                                    new CamadaDados.Financeiro.Caixa.TRegistro_Caixa_X_CCusto()
                                                                                    {
                                                                                        Cd_contager = rCfgBanco.Cd_contager,
                                                                                        Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(id_caixa, "@P_CD_LANCTOCAIXA"),
                                                                                        Id_ccustolan = decimal.Parse(id_custo)
                                                                                    }, qtb_titulo.Banco_Dados);
                                                                            }
                                                                        });
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string Excluir(blListaTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                val.ForEach(p => Excluir(p, qtb_titulo.Banco_Dados));
                if (st_transacao)
                    qtb_titulo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }

        public static string Excluir(blTitulo val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Titulo qtb_titulo = new TCD_Titulo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_titulo.CriarBanco_Dados(true);
                else
                    qtb_titulo.Banco_Dados = banco;
                //Verificar se o bloqueto pertence a um lote descontar
                TList_LoteBloqueto lLoteDesc =
                    new TCD_LoteBloqueto(qtb_titulo.Banco_Dados).Select(
                        new TpBusca[]
                        {
                           new TpBusca()
                           {
                               vNM_Campo = string.Empty,
                               vOperador = "exists",
                               vVL_Busca = "(select 1 from tb_cob_lote_x_titulo x " +
                                           "where x.id_lote = a.id_lote " + 
                                           "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                           "and x.nr_lancto = " + val.Nr_lancto.ToString() + " " +
                                           "and x.cd_parcela = " + val.Cd_parcela.ToString() + " " +
                                           "and x.id_cobranca = " + val.Id_cobranca.ToString() + " " + ")"
                           }
                        }, 0, string.Empty);
                if (lLoteDesc.Count > 0)
                {
                    if (lLoteDesc[0].St_registro.Trim().ToUpper().Equals("P"))
                        throw new Exception("Não é permitido excluir titulo com lote desconto processado.");
                    //Excluir titulo do lote
                    TCN_Lote_X_Titulo.Excluir(
                        new TRegistro_Lote_X_Titulo()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_parcela = val.Cd_parcela,
                            Id_cobranca = val.Id_cobranca,
                            Id_lote = lLoteDesc[0].Id_lote.Value,
                            Nr_lancto = val.Nr_lancto
                        }, qtb_titulo.Banco_Dados);
                }
                //Verificar se o bloqueto pertence a um lote de envio de remessa 
                //Excluir titulo lote remessa
                new TCD_LoteRemessa_X_Titulo(qtb_titulo.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lancto.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_parcela",
                            vOperador = "=",
                            vVL_Busca = val.Cd_parcela.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cobranca",
                            vOperador = "=",
                            vVL_Busca = val.Id_cobranca.Value.ToString()
                        }
                    }, 0, string.Empty).ForEach(p=>
                        {
                            //Excluir titulo do lote
                            TCN_LoteRemessa_X_Titulo.Excluir(p, qtb_titulo.Banco_Dados);
                            //Verificar se lote nao possui mais titulos
                            if (new TCD_LoteRemessa_X_Titulo(qtb_titulo.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_lote",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_lote.Value.ToString()
                                    }
                                }, "1") == null)
                                TCN_LoteRemessa.Excluir(new TRegistro_LoteRemessa() { Id_lote = p.Id_lote }, qtb_titulo.Banco_Dados);

                        });
                //Cancelar Titulo
                val.St_registro = "C";
                qtb_titulo.Gravar(val);
                    if (st_transacao)
                        qtb_titulo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_titulo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir bloqueto: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_titulo.deletarBanco_Dados();
            }
        }
    }
}
