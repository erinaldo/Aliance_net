using System;
using CamadaDados.PostoCombustivel;
using BancoDados;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_CartaFrete
    {
        public static TList_CartaFrete Buscar(string Cd_empresa,
                                              string Id_cartafrete,
                                              string Cd_transportadora,
                                              string Cd_unidPagadora,
                                              string Nr_cartafrete,
                                              string Tp_data,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string Id_caixa,
                                              TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_cartafrete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cartafrete";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cartafrete;
            }
            if (!string.IsNullOrEmpty(Cd_transportadora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_transportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_transportadora.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_unidPagadora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_unidpagadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_unidPagadora.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_cartafrete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cartafrete";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_cartafrete.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + 
                                                        (Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencimento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                                                        (Tp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencimento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "g.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            return new TCD_CartaFrete(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CartaFrete val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaFrete qtb_cf = new TCD_CartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Buscar config carta frete posto
                CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto lCfg =
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPosto.Buscar(val.Cd_empresa, qtb_cf.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para a empresa " + val.Cd_empresa.Trim());
                if (string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                    throw new Exception("Não existe tipo duplicata configurado para a empresa " + val.Cd_empresa.Trim());
                if (!lCfg[0].Tp_docto.HasValue)
                    throw new Exception("Não existe tipo documento configurado para a empresa " + val.Cd_empresa.Trim());
                //Buscar condicao pagamento
                CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              qtb_cf.Banco_Dados);
                if (lCond.Count.Equals(0))
                    throw new Exception("Não existe condição pagamento cadastrado com quantidade parcela igual 1");
                //Criar duplicata
                CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                rDup.Cd_empresa = val.Cd_empresa;
                rDup.Cd_historico = lCfg[0].Cd_historico;
                rDup.Tp_docto = lCfg[0].Tp_docto;
                rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                rDup.Cd_clifor = string.IsNullOrEmpty(val.Cd_unidpagadora) ? val.Cd_transportadora : val.Cd_unidpagadora;
                rDup.Cd_endereco = string.IsNullOrEmpty(val.Cd_unidpagadora) ? val.Cd_enderecotransp : val.Cd_endunidpagadora;
                rDup.Cd_juro = lCond[0].Cd_juro;
                rDup.Cd_moeda = lCond[0].Cd_moeda;
                rDup.Cd_condpgto = lCond[0].Cd_condpgto;
                rDup.Nr_docto = "CARTAF" + val.Nr_cartafrete;
                rDup.Vl_documento = val.Vl_documento;
                rDup.Vl_documento_padrao = val.Vl_documento;
                rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rDup.Qt_parcelas = 1;
                rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                rDup.St_comentrada = lCond[0].St_comentrada;
                rDup.Tp_juro = lCond[0].Tp_juro;
                rDup.Pc_jurodiario_atrazo = lCond[0].Pc_jurodiario_atrazo;
                //Cotacao
                rDup.DupCotacao = new CamadaDados.Financeiro.Duplicata.TRegistro_DuplicataCotacao()
                {
                    Cd_moedaresult = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", rDup.Cd_empresa, qtb_cf.Banco_Dados)
                };
                //Parcela
                rDup.Parcelas.Add(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela()
                {
                    Cd_empresa = val.Cd_empresa,
                    Cd_parcela = 1,
                    Dt_vencto = val.Dt_vencimento,
                    Vl_parcela = val.Vl_documento,
                    Vl_parcela_padrao = val.Vl_documento
                });
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_cf.Banco_Dados);
                val.Nr_lancto = rDup.Nr_lancto;
                val.Id_cartafretestr = CamadaDados.TDataQuery.getPubVariavel(qtb_cf.Gravar(val), "@P_ID_CARTAFRETE");
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
                return val.Id_cartafretestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CartaFrete val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaFrete qtb_cf = new TCD_CartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Cancelar duplicata
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.Busca(val.Cd_empresa,
                                                                          val.Nr_lanctostr,
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
                                                                          false,
                                                                          1,
                                                                          string.Empty,
                                                                          qtb_cf.Banco_Dados).ForEach(p =>
                                                                              CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_cf.Banco_Dados));
                //Exclusão logica, a venda de origem não esta mais sendo excluida
                val.St_registro = "C";
                qtb_cf.Gravar(val);
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
                return val.Id_cartafretestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static string AlterarUnidPagadora(TRegistro_CartaFrete val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaFrete qtb_cf = new TCD_CartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Buscar Endereco CD.Unidade Pagadora
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(qtb_cf.Banco_Dados).BuscarEscalar(
                     new Utils.TpBusca[]
                     {
                         new Utils.TpBusca()
                         {
                             vNM_Campo = "a.cd_clifor",
                             vOperador = "=",
                             vVL_Busca = "'" + val.Cd_unidpagadora.Trim() + "'"
                         }
                     }, "a.cd_endereco");
                if (obj != null)
                    val.Cd_endunidpagadora = obj.ToString();
                //Verificar se DUPLICATA ESTA AGRUPADA
                if (new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lanctostr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.vl_agrupado",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                        }, "1") != null)
                    throw new Exception("Carta frete possui duplicata agrupada!");
                //Verificar se PARCELA ESTA LIQUIDADA
                if (new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = val.Nr_lanctostr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.vl_liquidado",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                        }, "1") != null)
                    throw new Exception("Carta frete possui parcela liquidada!");
                qtb_cf.Gravar(val);
                //Buscar Duplicata
                qtb_cf.executarSql("update TB_FIN_Duplicata set CD_Clifor = '" + val.Cd_unidpagadora.Trim() + "', " +
                                   "CD_Endereco = '" + val.Cd_endunidpagadora.Trim() + "', DT_Alt = GETDATE() " +
                                   "where CD_Empresa = '" + val.Cd_empresa.Trim() + "' " +
                                   "and Nr_Lancto = " + val.Nr_lanctostr, null);
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
                return val.Id_cartafretestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }
    }
}
