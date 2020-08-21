using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil;
using Utils;

namespace CamadaNegocio.Contabil
{
    public class TCN_LanMultiplo
    {
        public static TList_Lan_CTB_LanMultiplo Buscar(string Id_lan,
                                                       string Id_lotectb,
                                                       string Cd_empresa,
                                                       string Nr_docto,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       string St_registro,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lan;
            }
            if (!string.IsNullOrEmpty(Id_lotectb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lotectb;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_docto.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lan";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lan";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_Lan_CTB_LanMultiplo().Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lan_CTB_LanMultiplo val, bool St_processar, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_CTB_LanMultiplo qtb_lan = new TCD_Lan_CTB_LanMultiplo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lan.CriarBanco_Dados(true);
                else
                    qtb_lan.Banco_Dados = banco;
                //Gravar Lancto Multiplo
                string retorno = qtb_lan.Grava(val);
                val.Id_lan = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LAN"));
                //Excluir lancamentos a debito e credito avulso
                val.lLanctoAvulsoDel.ForEach(p => TCN_LanctoAvulso.Excluir(p, qtb_lan.Banco_Dados));
                //Gravar lancamentos a debito e credito avulso
                val.lLanctoAvulso.ForEach(p =>
                    {
                        p.Id_lan = val.Id_lan;
                        TCN_LanctoAvulso.Gravar(p, qtb_lan.Banco_Dados);
                    });
                if (St_processar)
                    ProcessarContabilAvulso(val, qtb_lan.Banco_Dados);
                if (st_transacao)
                    qtb_lan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lan.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lan_CTB_LanMultiplo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_CTB_LanMultiplo qtb_lan = new TCD_Lan_CTB_LanMultiplo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lan.CriarBanco_Dados(true);
                else
                    qtb_lan.Banco_Dados = banco;
                //Excluir registros avulsos
                val.lLanctoAvulso.ForEach(p => TCN_LanctoAvulso.Excluir(p, qtb_lan.Banco_Dados));
                val.lLanctoAvulsoDel.ForEach(p => TCN_LanctoAvulso.Excluir(p, qtb_lan.Banco_Dados));
                //Excluir lote avulso
                qtb_lan.Deleta(val);
                if (st_transacao)
                    qtb_lan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lan.deletarBanco_Dados();
            }
        }

        public static void ImplantarSaldo(TRegistro_Lan_CTB_LanMultiplo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_CTB_LanMultiplo query = new TCD_Lan_CTB_LanMultiplo();
            try
            {
                if (banco == null)
                    st_transacao = query.CriarBanco_Dados(true);
                else query.Banco_Dados = banco;
                //Gravar lancamento avulso
                Gravar(val, false, query.Banco_Dados);
                //Processar lancamento avulso
                val.Id_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "IS" }, query.Banco_Dados);
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                val.lLanctoAvulso.ForEach(p =>
                {
                    if (p.D_C.Trim().ToUpper().Equals("D"))
                    {
                        listaDeb.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Data = val.Dt_lan,
                            Ds_compl_historico = val.Complhistorico,
                            Nr_docto = val.Nr_docto,
                            ID_LoteCTB = val.Id_lotectb,
                            Valor = p.Vl_lancto,
                            D_c = "D",
                            Cd_conta_ctb = p.Cd_conta_ctb
                        });
                    }
                    else if (p.D_C.Trim().ToUpper().Equals("C"))
                    {
                        listaCre.Add(new TRegistro_LanctosCTB()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Data = val.Dt_lan,
                            Ds_compl_historico = val.Complhistorico,
                            Nr_docto = val.Nr_docto,
                            ID_LoteCTB = val.Id_lotectb,
                            Valor = p.Vl_lancto,
                            D_c = "C",
                            Cd_conta_ctb = p.Cd_conta_ctb
                        });
                    }
                });
                TCN_LanContabil.GravarContabil(listaDeb, listaCre, true, query.Banco_Dados);
                val.St_registro = "P";//Processado
                query.Grava(val);
                if (st_transacao)
                    query.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    query.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro implatar saldo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    query.deletarBanco_Dados();
            }
        }

        public static void ProcessarContabilAvulso(TRegistro_Lan_CTB_LanMultiplo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_CTB_LanMultiplo qtb_lan = new TCD_Lan_CTB_LanMultiplo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lan.CriarBanco_Dados(true);
                else
                    qtb_lan.Banco_Dados = banco;
                //Gravar lote
                if (!val.Id_lotectb.HasValue)
                    val.Id_lotectbstr = TCN_LoteCTB.Gravar(new TRegistro_LoteCTB() { Tp_integracao = "AV" }, qtb_lan.Banco_Dados);
                //Criar lista de lancamentos contabeis
                TList_LanContabil listaCre = new TList_LanContabil();
                TList_LanContabil listaDeb = new TList_LanContabil();
                val.lLanctoAvulso.ForEach(p =>
                    {
                        if (p.D_C.Trim().ToUpper().Equals("D"))
                        {
                            listaDeb.Add(new TRegistro_LanctosCTB()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Data = val.Dt_lan,
                                Ds_compl_historico = val.Complhistorico,
                                Nr_docto = val.Nr_docto,
                                ID_LoteCTB = val.Id_lotectb,
                                Valor = p.Vl_lancto,
                                D_c = "D",
                                Cd_conta_ctb = p.Cd_conta_ctb
                            });
                        }
                        else if (p.D_C.Trim().ToUpper().Equals("C"))
                        {
                            listaCre.Add(new TRegistro_LanctosCTB()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Data = val.Dt_lan,
                                Ds_compl_historico = val.Complhistorico,
                                Nr_docto = val.Nr_docto,
                                ID_LoteCTB = val.Id_lotectb,
                                Valor = p.Vl_lancto,
                                D_c = "C",
                                Cd_conta_ctb = p.Cd_conta_ctb
                            });
                        }
                    });
                //Grava registro contabil
                TCN_LanContabil.GravarContabil(listaDeb, listaCre, false, qtb_lan.Banco_Dados);
                //Altera status lan multiplo para processado
                val.St_registro = "P";//Processado
                qtb_lan.Grava(val);
                if (st_transacao)
                    qtb_lan.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lan.deletarBanco_Dados();
            }
        }
    }
}