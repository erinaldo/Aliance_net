using System;
using CamadaDados.Faturamento.CTRC;
using Utils;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using System.Collections.Generic;

namespace CamadaNegocio.Faturamento.CTRC
{
    public static class TCN_ConhecimentoFrete
    {
        public static TList_ConhecimentoFrete Buscar(string Cd_empresa,
                                                     string Nr_lanctoctr,
                                                     string Nr_ctrc,
                                                     string Cd_transportadora,
                                                     string Cd_endtransportadora,
                                                     string Cd_remetente,
                                                     string Cd_endremetente,
                                                     string Cd_destinatario,
                                                     string Cd_enddestinatario,
                                                     string Cd_movimentacao,
                                                     string Cd_cmi,
                                                     string Nr_serie,
                                                     string Tp_data,
                                                     string Dt_ini,
                                                     string Dt_fin,
                                                     string St_registro,
                                                     string Nr_nfTransp,
                                                     short vTop,
                                                     string vNm_campo,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctoctr.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (Nr_ctrc.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_ctrc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_ctrc;
            }
            if (Cd_transportadora.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_transportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_transportadora.Trim() + "'";
            }
            if (Cd_endtransportadora.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endtransportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endtransportadora.Trim() + "'";
            }
            if (Cd_remetente.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_remetente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_remetente.Trim() + "'";
            }
            if (Cd_endremetente.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_endremetente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_endremetente.Trim() + "'";
            }
            if (Cd_destinatario.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_destinatario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_destinatario.Trim() + "'";
            }
            if (Cd_enddestinatario.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_enddestinatario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_enddestinatario.Trim() + "'";
            }
            if (Cd_movimentacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_movimentacao;
            }
            if (Cd_cmi.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_cmi";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_cmi;
            }
            if (Nr_serie.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_saient";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_saient";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnulL(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_nfTransp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_notafiscal x " +
                                                      "inner join tb_fat_notafiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and y.nr_notafiscal = " + Nr_nfTransp + ")";
            }

            return new TCD_ConhecimentoFrete(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_ctrc = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Gravar conhecimento frete
                val.St_registro = "P";
                string retorno = qtb_ctrc.Gravar(val);
                val.Nr_lanctoCTRC = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTOCTR"));
                //Deletar Nf
                val.lNfDel.ForEach(p => TCN_CTRNotaFiscal.Excluir(
                    new TRegistro_CTRNotaFiscal()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctoctr = val.Nr_lanctoCTRC,
                        Nr_lanctofiscal = p.Nr_lanctofiscal
                    }, qtb_ctrc.Banco_Dados));
                //Gravar Nf
                val.lNf.ForEach(p => TCN_CTRNotaFiscal.Gravar(
                    new TRegistro_CTRNotaFiscal()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctoctr = val.Nr_lanctoCTRC,
                        Nr_lanctofiscal = p.Nr_lanctofiscal
                    }, qtb_ctrc.Banco_Dados));
                //Buscar impostos CTRC que foram gravados automaticamente
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpCtr =
                    TCN_ImpostosNF.Buscar(string.Empty,
                                          val.Cd_empresa,
                                          string.Empty,
                                          string.Empty,
                                          val.Nr_lanctoCTRC.Value.ToString(),
                                          string.Empty,
                                          string.Empty,
                                          string.Empty,
                                          string.Empty,
                                          string.Empty,
                                          "A",
                                          false,
                                          string.Empty,
                                          qtb_ctrc.Banco_Dados);
                lImpCtr.ForEach(p => TCN_ImpostosNF.Excluir(p, qtb_ctrc.Banco_Dados));
                //Excluir impostos Manual se houver
                val.lImpDel.ForEach(p => TCN_ImpostosNF.Excluir(p, qtb_ctrc.Banco_Dados));
                //Gravar Imposto 
                val.lImpostos.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoctr = val.Nr_lanctoCTRC;
                        TCN_ImpostosNF.Gravar(p, qtb_ctrc.Banco_Dados);
                    });
                //Processar CTRC
                Processar(val, qtb_ctrc.Banco_Dados);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static void Alterar(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_ctr = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctr.CriarBanco_Dados(true);
                else
                    qtb_ctr.Banco_Dados = banco;
                qtb_ctr.Gravar(val);
                if (st_transacao)
                    qtb_ctr.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar conhecimento frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_ctrc = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                if (val.St_registro.Trim().ToUpper().Equals("P"))
                {
                    if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR CANCELAR CTRC", qtb_ctrc.Banco_Dados))
                    {
                        //Verificar financeiro ativo
                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                               new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_ctrc.Banco_Dados).Select(
                               new TpBusca[]
                               {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ctr_duplicata x "+
                                                "where x.cd_empresa = a.cd_empresa "+
                                                "and x.nr_lanctoduplicata = a.nr_lancto "+
                                                "and x.cd_empresa = '"+val.Cd_empresa+"' "+
                                                "and x.nr_lanctoctr = "+val.Nr_lanctoCTRC.Value.ToString()+")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                }
                               }, 0, string.Empty);
                        if (lDup.Count == 0)
                            //Chamar procedimento para cancelar o conhecimento frete
                            qtb_ctrc.Cancelar(val);
                        else
                        {
                            //Verificar se o usuario tem acesso a tela de duplicata
                            if ((Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                                throw new Exception("Não é permitido cancelar uma nota fiscal com movimentação financeira.\r\n" +
                                                    "Empresa.....: " + val.Cd_empresa + "\r\n" +
                                                    "Nº Documento: " + lDup[0].Nr_docto.Trim() + "\r\n" +
                                                    "Nº Duplicata: " + lDup[0].Nr_lancto.ToString() + "\r\n" +
                                                    "Para cancelar a nota fiscal é necessário cancelar primeiro o financeiro.");
                            else
                            {
                                Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_ctrc.Banco_Dados);
                                //Chamar procedimento para cancelar o conhecimento frete
                                qtb_ctrc.Cancelar(val);
                            }
                        }
                    }
                    else
                        throw new Exception("Usuário não tem permissão para cancelar conhecimento frete.\r\n" +
                                    "Login: " + Parametros.pubLogin.Trim().ToUpper() + "\r\n" +
                                    "Solução: Para o login " + Parametros.pubLogin.Trim().ToUpper() + " poder cancelar conhecimento frete é necessário dar acesso ao mesmo\r\n" +
                                    "através da regra especial <PERMITIR CANCELAR CTRC>, localizado no cadastro de usuário.");
                }
                //Se for Emissão de Terceiro Excluir
                if (val.Tp_emissao.Trim().ToUpper().Equals("T"))
                    qtb_ctrc.Excluir(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static void Processar(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_ctrc = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Gravar financeiro do conhecimento frete
                if (val.rDuplicata != null)
                {
                    string ret_dup = Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDuplicata, false, qtb_ctrc.Banco_Dados);
                    val.rDuplicata.Nr_lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_dup, "@P_NR_LANCTO"));
                    TCN_CTRDuplicata.GravarCTRDuplicata(new TRegistro_CTRDuplicata()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctoctr = val.Nr_lanctoCTRC,
                        Nr_lanctoduplicata = val.rDuplicata.Nr_lancto
                    }, qtb_ctrc.Banco_Dados);
                }
                if (val.rCmi != null)
                    //Processar estoque do conhecimento frete
                    if (val.rCmi.St_geraestoquebool && val.Tp_movimento.Trim().ToUpper().Equals("E"))
                        TCN_CTREstoque.Processar(val, qtb_ctrc.Banco_Dados);
                //Gravar Contabilidade
                List<TRegistro_ProcConhecimentoFrete> lProcFat =
                TCN_Lan_ProcContabil.BuscaProc_Frete(val.Cd_empresa,
                                                     val.Nr_ctrcstr,
                                                     val.Nr_lanctoCTRC.ToString(),
                                                     string.Empty,
                                                     string.Empty,
                                                     string.Empty,
                                                     false,
                                                     string.Empty,
                                                     string.Empty,
                                                     string.Empty,
                                                     decimal.Zero,
                                                     decimal.Zero,
                                                     qtb_ctrc.Banco_Dados);
                if (lProcFat.Count > 0)
                    if (lProcFat.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                        TCN_LanContabil.ProcessaCTB_Frete(lProcFat.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_ctrc.Banco_Dados);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar conhecimento frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static void GravarCTe(TRegistro_ConhecimentoFrete val,
                                     bool St_alterar,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_cte = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else qtb_cte.Banco_Dados = banco;
                if (!St_alterar && string.IsNullOrEmpty(val.Nr_ctrc.ToString()))
                {
                    //Verificar sequencia
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(qtb_cte.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_serie",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Nr_serie.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_modelo",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_modelo.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_sequenciaauto, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") != null)
                    {
                        object obj_cte = new CamadaDados.Faturamento.Cadastros.TCD_CadSequenciaNF(qtb_cte.Banco_Dados).BuscarEscalar(
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
                                                   vNM_Campo = "a.nr_serie",
                                                   vOperador = "=",
                                                   vVL_Busca = "'" + val.Nr_serie.Trim() + "'"
                                               },
                                               new TpBusca()
                                               {
                                                   vNM_Campo = "a.cd_modelo",
                                                   vOperador = "=",
                                                   vVL_Busca = "'" + val.Cd_modelo.Trim() + "'"
                                               }
                                            }, "isnull(a.seq_notafiscal, 0)");
                            val.Nr_ctrc = obj_cte == null ? 1 : decimal.Parse(obj_cte.ToString()) + 1;
                    }
                }
                //Gravar Sequencia de Série
                Cadastros.TCN_CadSequenciaNF.Gravar(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF()
                        {
                            CD_Empresa = val.Cd_empresa,
                            Nr_Serie = val.Nr_serie,
                            Cd_modelo = val.Cd_modelo,
                            Seq_NotaFiscal = val.Nr_ctrc.Value
                        }, qtb_cte.Banco_Dados);
                val.Tp_emissao = "P";//Proprio
                val.Tp_movimento = "S";//Saida
                //Buscar % Imposto Aproximado
                object obj = new CamadaDados.Frota.Cadastros.TCD_CfgFrota(qtb_cte.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    }
                                }, "a.pc_impaprox");
                if (obj != null)
                {
                    decimal valor = decimal.Zero;
                    decimal.TryParse(obj.ToString(), out valor);
                    val.Pc_impAprox = valor;
                }
                val.Nr_lanctoCTRC = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_cte.Gravar(val), "@P_NR_LANCTOCTR"));
                if (val.rDuplicata != null)
                {
                    //Gravar financeiro
                    val.rDuplicata.Nr_docto = val.Nr_ctrcstr;
                    Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.rDuplicata, false, qtb_cte.Banco_Dados);
                    TCN_CTRDuplicata.GravarCTRDuplicata(new TRegistro_CTRDuplicata()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctoctr = val.Nr_lanctoCTRC,
                        Nr_lanctoduplicata = val.rDuplicata.Nr_lancto
                    }, qtb_cte.Banco_Dados);
                }
                //Deletar Impostos
                val.lImpDel.ForEach(p => TCN_ImpostosNF.Excluir(p, qtb_cte.Banco_Dados));
                //Gravar impostos
                val.lImpostos.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Nr_lanctoctr = val.Nr_lanctoCTRC;
                    TCN_ImpostosNF.Gravar(p, qtb_cte.Banco_Dados);
                });
                //Deletar Nota Fiscal
                val.lNfCTeDel.ForEach(p => TCN_CTRNotaFiscal.Excluir(p, qtb_cte.Banco_Dados));
                //Gravar nota fiscal
                val.lNfCTe.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoctr = val.Nr_lanctoCTRC;
                        TCN_CTRNotaFiscal.Gravar(p, qtb_cte.Banco_Dados);
                    });
                //Deletar Qtde Carga
                val.lQtdeCargaDel.ForEach(p => TCN_CTRQtdeCarga.Excluir(p, qtb_cte.Banco_Dados));
                //Gravar Qtde Carga
                val.lQtdeCarga.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoCTR = val.Nr_lanctoCTRC;
                        TCN_CTRQtdeCarga.Gravar(p, qtb_cte.Banco_Dados);
                    });
                //Deletar Comp. Valor
                val.lCompValorFreteDel.ForEach(p => TCN_CTRCompValorFrete.Excluir(p, qtb_cte.Banco_Dados));
                //Gravar Comp. Valor
                val.lCompValorFrete.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoctr = val.Nr_lanctoCTRC;
                        TCN_CTRCompValorFrete.Gravar(p, qtb_cte.Banco_Dados);
                    });
                //Excluir Ordem Coleta
                val.lOrdemColetadel.ForEach(p => TCN_CTROrdemColeta.Excluir(p, qtb_cte.Banco_Dados));
                //Gravar Ordem Coleta
                val.lOrdemColeta.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoctr = val.Nr_lanctoCTRC;
                        TCN_CTROrdemColeta.Gravar(p, qtb_cte.Banco_Dados);
                    });
                //Amarrar Cte a Viagem
                if (val.Id_viagem.HasValue)
                    Frota.TCN_Viagem_X_Frete.Gravar(
                        new CamadaDados.Frota.TRegistro_Viagem_X_Frete()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_viagem = val.Id_viagem,
                            Nr_lanctoCTRC = val.Nr_lanctoCTRC
                        }, qtb_cte.Banco_Dados);
                //Amarrar Cte á Mudança
                if (val.Id_mudanca.HasValue)
                    Mudanca.TCN_Mudanca_X_CTe.Gravar(
                        new CamadaDados.Mudanca.TRegistro_Mudanca_X_CTe()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_mudanca = val.Id_mudanca,
                            Nr_lanctoCTRC = val.Nr_lanctoCTRC
                        }, qtb_cte.Banco_Dados);
                //Processar Comissao
                ProcessarComissao(val, qtb_cte.Banco_Dados);
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CTe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }

        public static void ExcluiCTe(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_cte = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else
                    qtb_cte.Banco_Dados = banco;
                if (new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_cte.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "a.nr_lanctoctr",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lanctoCTRC.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_comissao_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_comissao = a.id_comissao)"
                            }
                        }, "1") != null)
                    throw new Exception("CTe possui comissão faturada.\r\n" +
                                        "Necessário cancelar duplicata de pagamento da comissão.");
                qtb_cte.Excluir(val);
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir CTe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }

        public static void CancelarCTe(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_cte = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else qtb_cte.Banco_Dados = banco;
                //Verificar se existe financeiro
                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_cte.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_ctr_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctoduplicata = a.nr_lancto " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.nr_lanctoctr = " + val.Nr_lanctoCTRC.Value.ToString() + ")"
                            }
                        }, 1, string.Empty);
                if (lDup.Count > 0)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_cte.Banco_Dados);
                //Cancelar Comissao
                CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                  val.Cd_empresa,
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
                                                                                  val.Nr_ctrcstr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                  string.Empty,
                                                                                  qtb_cte.Banco_Dados).ForEach(p =>
                                                                                      CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_cte.Banco_Dados));
                qtb_cte.Cancelar(val);
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar CTe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }

        public static TRegistro_ConhecimentoFrete AnularCTe(TRegistro_ConhecimentoFrete val,
                                                            string MotivoAnulacao,
                                                            BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_cte = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else
                    qtb_cte.Banco_Dados = banco;
                //Buscar config Frota
                CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                    CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(val.Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      qtb_cte.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração frota para a empresa " + val.Cd_empresa.Trim());
                if (!lCfg[0].Cd_movanulacao.HasValue)
                    throw new Exception("Não existe movimentação de anulação configurada para a empresa " + val.Cd_empresa.Trim());
                if (!lCfg[0].Cd_cmianulacao.HasValue)
                    throw new Exception("Não existe cmi de anulação configurada para a empresa " + val.Cd_empresa.Trim());
                //Verificar se CTe de Origem possui duplicata
                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_cte.Banco_Dados).Select(
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
                            vVL_Busca = "(select 1 from tb_ctr_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctoduplicata = a.nr_lancto " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.nr_lanctoCTR = " + val.Nr_lanctoCTRC.Value.ToString() + ")"
                        }
                    }, 1, string.Empty);
                if (lDup.Count > 0)
                    CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_cte.Banco_Dados);
                TRegistro_ConhecimentoFrete rCTe = new TRegistro_ConhecimentoFrete();
                //Verificar sequencia
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(qtb_cte.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_serie",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Nr_serie.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_sequenciaauto, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") != null)
                {
                    object obj_cte = new CamadaDados.Faturamento.Cadastros.TCD_CadSequenciaNF(qtb_cte.Banco_Dados).BuscarEscalar(
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
                                               vNM_Campo = "a.nr_serie",
                                               vOperador = "=",
                                               vVL_Busca = "'" + val.Nr_serie.Trim() + "'"
                                           }
                                        }, "isnull(a.seq_notafiscal, 0)");
                    rCTe.Nr_ctrc = obj_cte == null ? 1 : decimal.Parse(obj_cte.ToString()) + 1;
                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(
                        new CamadaDados.Faturamento.Cadastros.TRegistro_CadSequenciaNF()
                        {
                            CD_Empresa = val.Cd_empresa,
                            Cd_modelo = val.Cd_modelo,
                            Nr_Serie = val.Nr_serie,
                            Seq_NotaFiscal = val.Nr_ctrc.Value
                        }, qtb_cte.Banco_Dados);
                }
                else throw new Exception("Serie não esta configurada com sequencia automatica.");
                rCTe.Cd_empresa = val.Cd_empresa;
                rCTe.Cd_transportadora = val.Cd_transportadora;
                rCTe.Cd_endtransportadora = val.Cd_endtransportadora;
                rCTe.Cd_remetente = val.Cd_remetente;
                rCTe.Cd_endremetente = val.Cd_endremetente;
                rCTe.Cd_destinatario = val.Cd_destinatario;
                rCTe.Cd_enddestinatario = val.Cd_enddestinatario;
                rCTe.Cd_expedidor = val.Cd_expedidor;
                rCTe.Cd_endexpedidor = val.Cd_endexpedidor;
                rCTe.Cd_recebedor = val.Cd_recebedor;
                rCTe.Cd_endrecebedor = val.Cd_endrecebedor;
                rCTe.Cd_movimentacao = lCfg[0].Cd_movanulacao;
                rCTe.Cd_cmi = lCfg[0].Cd_cmianulacao;
                rCTe.Nr_serie = val.Nr_serie;
                rCTe.Cd_modelo = val.Cd_modelo;
                //Buscar CFOP Movimentacao
                CamadaDados.Fiscal.TList_Mov_X_CFOP lMovCfop =
                    CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.Buscar(lCfg[0].Cd_movanulacaostr,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               null);
                if (lMovCfop.Count > 0)
                    rCTe.Cd_cfop = val.Cd_uf_transportadora.Trim().Equals(val.Cd_uf_destinatario.Trim()) ?
                        lMovCfop[0].Cd_cfop_dentroestado : lMovCfop[0].Cd_cfop_foraestado;
                else
                    throw new Exception("Não existe CFOP configurado para movimentação " + lCfg[0].Cd_movanulacaostr);
                rCTe.Cd_cidade_ini = val.Cd_cidade_ini;
                rCTe.Cd_cidade_fin = val.Cd_cidade_fin;
                rCTe.Dt_emissao = CamadaDados.UtilData.Data_Servidor(qtb_cte.Banco_Dados);
                rCTe.Vl_frete = val.Vl_frete;
                rCTe.Tp_movimento = "E";
                rCTe.Tp_emissao = val.Tp_emissao;
                rCTe.Tp_modalidade = val.Tp_modalidade;
                rCTe.Tp_servico = val.Tp_servico;
                rCTe.Tp_cte = "2";//CTe de Anulacao
                rCTe.St_receberretira = val.St_receberretira;
                rCTe.Ds_retira = val.Ds_retira;
                rCTe.Tp_tomador = val.Tp_tomador;
                rCTe.Obsfiscal = "CTe de anulação de valores relativo à prestação de serviço de transporte tomados " +
                                 "por meio do conhecimento de transporte eletrônico (CT-e), n.º " + val.Nr_ctrcstr + ", série " + val.Nr_serie +
                                 ", chave de acesso eletrônica " + val.Chaveacesso.Trim() + ", emitido em " + val.Dt_emissaostr +
                                 ", no valor de " + val.Vl_frete.ToString("C2", new System.Globalization.CultureInfo("en-US")) +
                                 (string.IsNullOrEmpty(MotivoAnulacao) ? string.Empty : "Motivo Anulação: " + MotivoAnulacao.Trim());
                rCTe.St_registro = "A";
                //Buscar Impostos
                string vObsFiscal = string.Empty;
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpostos =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(val.Cd_empresa,
                                                                                                      val.Cd_uf_transportadora,
                                                                                                      val.Cd_uf_destinatario,
                                                                                                      lCfg[0].Cd_movanulacaostr,
                                                                                                      "E",
                                                                                                      val.Cd_condfiscal_transportadora,
                                                                                                      string.Empty,
                                                                                                      val.Vl_frete,
                                                                                                      decimal.Zero,
                                                                                                      ref vObsFiscal,
                                                                                                      rCTe.Dt_emissao,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      null);
                if (lImpostos.Count > 0)
                    rCTe.lImpostos.Concat(lImpostos);
                else
                    if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(string.Empty, val.Nr_serie, qtb_cte.Banco_Dados))
                    throw new Exception("Não existe condição fiscal para: \r\n" +
                                        "Tipo Movimento: ENTRADA\r\n" +
                                        "Movimentação Comercial: " + lCfg[0].Cd_movanulacaostr + " - " + lCfg[0].Ds_movanulacao.Trim() + "\r\n" +
                                        "Condição Fiscal Clifor: " + val.Cd_condfiscal_transportadora.Trim() + "\r\n" +
                                        "UF Origem: " + val.Cd_uf_transportadora + "\r\n" +
                                        "UF Destino: " + val.Cd_uf_destinatario);
                //CTe Anulado
                rCTe.Nr_lanctoCTRAnulado = val.Nr_lanctoCTRC;
                //Gravar objeto CTe Anulado
                rCTe.Nr_lanctoCTRC = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_cte.Gravar(rCTe), "@P_NR_LANCTOCTR"));
                //Gravar impostos
                rCTe.lImpostos.ForEach(p =>
                {
                    p.Cd_empresa = rCTe.Cd_empresa;
                    p.Nr_lanctoctr = rCTe.Nr_lanctoCTRC;
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Gravar(p, qtb_cte.Banco_Dados);
                });
                if (st_transacao)
                    qtb_cte.Banco_Dados.Commit_Tran();
                return rCTe;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro anular CTe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_ConhecimentoFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConhecimentoFrete qtb_cte = new TCD_ConhecimentoFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cte.CriarBanco_Dados(true);
                else
                    qtb_cte.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                            val.Cd_empresa,
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
                                                            val.Nr_ctrcstr,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            qtb_cte.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    //Verificar se comissao possui faturamento
                    if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_cte.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lComissao[0].Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_comissao",
                                            vOperador = "=",
                                            vVL_Busca = lComissao[0].Id_comissaostr
                                        }
                                    }, "1") == null)
                        Comissao.TCN_Fechamento_Comissao.Excluir(lComissao[0], qtb_cte.Banco_Dados);
                    else
                        throw new Exception("CTe possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_cte.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cte.deletarBanco_Dados();
            }
        }
    }
}
