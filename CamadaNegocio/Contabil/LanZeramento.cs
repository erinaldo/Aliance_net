using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public class TCN_Zeramento
    {
        public static TList_Zeramento Buscar(string Cd_empresa,
                                             string Id_zeramento,
                                             string Dt_ini,
                                             string Dt_fin,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_zeramento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_zeramento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_zeramento;
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10))))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10))))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_Zeramento(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Zeramento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento qtb_zeramento = new TCD_Zeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zeramento.CriarBanco_Dados(true);
                else qtb_zeramento.Banco_Dados = banco;
                val.Id_zeramentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_zeramento.Gravar(val), "@P_ID_ZERAMENTO");
                if(st_transacao)
                    qtb_zeramento.Banco_Dados.Commit_Tran();
                return val.Id_zeramentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar zeramento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zeramento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Zeramento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento qtb_zeramento = new TCD_Zeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zeramento.CriarBanco_Dados(true);
                else qtb_zeramento.Banco_Dados = banco;
                qtb_zeramento.Excluir(val);
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.Commit_Tran();
                return val.Id_zeramentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir zeramento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zeramento.deletarBanco_Dados();
            }
        }

        public static void Zeramento(CamadaDados.Contabil.Cadastro.TRegistro_Cad_CTB_ParamZeramento rParam,
                                     DateTime? Dt_ini,
                                     DateTime? Dt_fin,
                                     string Complemento,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento qtb_zeramento = new TCD_Zeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zeramento.CriarBanco_Dados(true);
                else qtb_zeramento.Banco_Dados = banco;
                //Gerar Balanco no Periodo
                List<TRegistro_BalancoSintetico> Balanco =
                    TCN_LanContabil.GerarBalanco(rParam.Cd_empresa, string.Empty, string.Empty, Dt_ini, Dt_fin, true, false, string.Empty, false, false);
                
                //Lista Lancamento Contabeis Gerados
                TList_Zeramento_X_Lote lLoteZeramento = new TList_Zeramento_X_Lote();
                //Zerar Receitas
                Balanco.Where(p=> p.Tp_conta.Trim().ToUpper().Equals("A") &&
                                  p.Classificacao.Trim().StartsWith(rParam.Cd_classifreceitas.Trim())).ToList().ForEach(p =>
                    {
                        //Gravar Lote
                        string id_loteCTB = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "ZR" }, qtb_zeramento.Banco_Dados);
                        //Gravar Lancamentos Contabeis
                        TCN_LanContabil.GravarContabil(
                            new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(p.Vl_atual),
                                    Cd_conta_ctb = p.Vl_atual > decimal.Zero ? p.Cd_contaCTB : rParam.Cd_contaresultado
                                }
                            },
                            new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(p.Vl_atual),
                                    Cd_conta_ctb = p.Vl_atual > decimal.Zero ? rParam.Cd_contaresultado : p.Cd_contaCTB
                                }
                            }, false, qtb_zeramento.Banco_Dados);
                        lLoteZeramento.Add(new TRegistro_Zeramento_X_Lote() { Cd_empresa = rParam.Cd_empresa, Id_loteCTBstr = id_loteCTB });
                    });
                //Zerar Despesas
                Balanco.Where(p => p.Tp_conta.Trim().ToUpper().Equals("A") &&
                                   p.Classificacao.Trim().StartsWith(rParam.Cd_classifdespesas.Trim())).ToList().ForEach(p =>
                {
                    //Gravar Lote
                    string id_loteCTB = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "ZR" }, qtb_zeramento.Banco_Dados);
                    //Gravar Lancamentos Contabeis
                    TCN_LanContabil.GravarContabil(
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(p.Vl_atual),
                                    Cd_conta_ctb = p.Vl_atual > decimal.Zero ? rParam.Cd_contaresultado : p.Cd_contaCTB
                                }
                            },
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(p.Vl_atual),
                                    Cd_conta_ctb = p.Vl_atual > decimal.Zero ? p.Cd_contaCTB : rParam.Cd_contaresultado
                                }
                            }, false, qtb_zeramento.Banco_Dados);
                    lLoteZeramento.Add(new TRegistro_Zeramento_X_Lote() { Cd_empresa = rParam.Cd_empresa, Id_loteCTBstr = id_loteCTB });
                });
                //Zerar Custos
                Balanco.Where(p => p.Tp_conta.Trim().ToUpper().Equals("A") &&
                                   p.Classificacao.Trim().StartsWith(rParam.Cd_classifcusto.Trim())).ToList().ForEach(p =>
                                  {
                                      //Gravar Lote
                                      string id_loteCTB = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "ZR" }, qtb_zeramento.Banco_Dados);
                                      //Gravar Lancamentos Contabeis
                                      TCN_LanContabil.GravarContabil(
                                          new List<TRegistro_LanctosCTB>()
                                            {
                                                new TRegistro_LanctosCTB()
                                                {
                                                    Cd_empresa = rParam.Cd_empresa,
                                                    Data = Dt_fin,
                                                    Ds_compl_historico = "Zeramento",
                                                    Nr_docto = "ZR",
                                                    Id_lotectbstr = id_loteCTB,
                                                    Valor = Math.Abs(p.Vl_atual),
                                                    Cd_conta_ctb = p.Vl_atual > decimal.Zero ? rParam.Cd_contaresultado : p.Cd_contaCTB
                                                }
                                            },
                                          new List<TRegistro_LanctosCTB>()
                                              {
                                        new TRegistro_LanctosCTB()
                                        {
                                            Cd_empresa = rParam.Cd_empresa,
                                            Data = Dt_fin,
                                            Ds_compl_historico = "Zeramento",
                                            Nr_docto = "ZR",
                                            Id_lotectbstr = id_loteCTB,
                                            Valor = Math.Abs(p.Vl_atual),
                                            Cd_conta_ctb = p.Vl_atual > decimal.Zero ? p.Cd_contaCTB : rParam.Cd_contaresultado
                                        }
                                              }, false, qtb_zeramento.Banco_Dados);
                                      lLoteZeramento.Add(new TRegistro_Zeramento_X_Lote() { Cd_empresa = rParam.Cd_empresa, Id_loteCTBstr = id_loteCTB });
                                  });
                decimal resultado = Balanco.Find(p => p.Classificacao.Trim().Equals(rParam.Cd_classifreceitas.Trim())).Vl_atual -
                                    Balanco.Find(p => p.Classificacao.Trim().Equals(rParam.Cd_classifdespesas.Trim())).Vl_atual -
                                    Balanco.Find(p => p.Classificacao.Trim().Equals(rParam.Cd_classifcusto.Trim())).Vl_atual;
                if (resultado > decimal.Zero && rParam.Cd_cResultadoL.HasValue)
                {
                    //Gravar Lote
                    string id_loteCTB = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "ZR" }, qtb_zeramento.Banco_Dados);
                    //Gravar Lancamentos Contabeis
                    TCN_LanContabil.GravarContabil(
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = resultado,
                                    Cd_conta_ctb = rParam.Cd_contaresultado
                                }
                            },
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = resultado,
                                    Cd_conta_ctb = rParam.Cd_cResultadoL
                                }
                            }, false, qtb_zeramento.Banco_Dados);
                    lLoteZeramento.Add(new TRegistro_Zeramento_X_Lote() { Cd_empresa = rParam.Cd_empresa, Id_loteCTBstr = id_loteCTB });
                }
                else if (resultado < decimal.Zero && rParam.Cd_cResultadoP.HasValue)
                {
                    //Gravar Lote
                    string id_loteCTB = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "ZR" }, qtb_zeramento.Banco_Dados);
                    //Gravar Lancamentos Contabeis
                    TCN_LanContabil.GravarContabil(
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(resultado),
                                    Cd_conta_ctb = rParam.Cd_cResultadoP
                                }
                            },
                        new List<TRegistro_LanctosCTB>()
                            {
                                new TRegistro_LanctosCTB()
                                {
                                    Cd_empresa = rParam.Cd_empresa,
                                    Data = Dt_fin,
                                    Ds_compl_historico = "Zeramento",
                                    Nr_docto = "ZR",
                                    Id_lotectbstr = id_loteCTB,
                                    Valor = Math.Abs(resultado),
                                    Cd_conta_ctb = rParam.Cd_contaresultado
                                }
                            }, false, qtb_zeramento.Banco_Dados);
                    lLoteZeramento.Add(new TRegistro_Zeramento_X_Lote() { Cd_empresa = rParam.Cd_empresa, Id_loteCTBstr = id_loteCTB });
                }
                //Gravar Registro Zeramento
                string id_zeramento = Gravar(new TRegistro_Zeramento()
                {
                    Cd_empresa = rParam.Cd_empresa,
                    Dt_zeramento = Dt_fin,
                    Complemento = Complemento
                }, qtb_zeramento.Banco_Dados);
                lLoteZeramento.ForEach(p =>
                    {
                        p.Id_zeramentostr = id_zeramento;
                        TCN_Zeramento_X_Lote.Gravar(p, qtb_zeramento.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar zeramento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zeramento.deletarBanco_Dados();
            }
        }

        public static bool BuscarUltimoFechamento(string Cd_empresa,
                                                  DateTime data,
                                                  BancoDados.TObjetoBanco banco)
        {
            object obj = new TCD_Zeramento(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                }
                            }, "a.dt_zeramento", string.Empty, "a.dt_zeramento desc", null);
            return obj == null ? true : DateTime.Parse(obj.ToString()).Date < data.Date;
        }

        public static void ExcluirUltimoZeramento(TRegistro_Zeramento val,
                                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento qtb_zer = new TCD_Zeramento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zer.CriarBanco_Dados(true);
                else qtb_zer.Banco_Dados = banco;
                qtb_zer.ExcluirLoteZeramento(val);
                if (st_transacao)
                    qtb_zer.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zer.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir zeramento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zer.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Zeramento_X_Lote
    {
        public static TList_Zeramento_X_Lote Buscar(string Cd_empresa,
                                                    string Id_zeramento,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_zeramento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_zeramento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_zeramento;
            }
            return new TCD_Zeramento_X_Lote(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Zeramento_X_Lote val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento_X_Lote qtb_zeramento = new TCD_Zeramento_X_Lote();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zeramento.CriarBanco_Dados(true);
                else qtb_zeramento.Banco_Dados = banco;
                string ret = qtb_zeramento.Gravar(val);
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zeramento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Zeramento_X_Lote val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Zeramento_X_Lote qtb_zeramento = new TCD_Zeramento_X_Lote();
            try
            {
                if (banco == null)
                    st_transacao = qtb_zeramento.CriarBanco_Dados(true);
                else qtb_zeramento.Banco_Dados = banco;
                qtb_zeramento.Excluir(val);
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_zeramento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_zeramento.deletarBanco_Dados();
            }
        }
    }
}
