using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    #region Lote Fiscal

    public class TCN_LoteImposto
    {
        public static TList_LoteImposto Buscar(string Id_lotefis,
                                               string Cd_imposto,
                                               string Cd_empresa,
                                               string Dt_inilote,
                                               string Dt_finlote,
                                               string St_registro,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lotefis))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotefis";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lotefis;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_inilote)) && (Dt_inilote.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_inilote).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_finlote)) && (Dt_finlote.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lote";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_finlote).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_LoteImposto(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static bool VerificarLoteImposto(string Cd_empresa,
                                                string Cd_imposto,
                                                string Data,
                                                BancoDados.TObjetoBanco banco)
        {
            object obj = new CamadaDados.Fiscal.TCD_LoteImposto(banco).BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_imposto",
                                    vOperador = "=",
                                    vVL_Busca = Cd_imposto
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_lote)))",
                                    vOperador = ">=",
                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Data).ToString("yyyyMMdd")) + "'"
                                }
                            }, "1");
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public static void ProcessarImposto(TRegistro_LoteImposto val,
                                            BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteImposto qtb_lote = new TCD_LoteImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                if (VerificarLoteImposto(val.Cd_empresa, val.Cd_impostostr, val.Dt_lotestr, qtb_lote.Banco_Dados))
                    throw new Exception("Imposto ja se encontra processado para a data: " + val.Dt_lotestr);
                //Gravar lote fiscal
                Gravar(val, qtb_lote.Banco_Dados);
                //Buscar registros fiscais para processar
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp = 
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Buscar(string.Empty,
                                                                               val.Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               val.Cd_impostostr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               val.Dt_lotestr,
                                                                               string.Empty,
                                                                               true,
                                                                               string.Empty,
                                                                               qtb_lote.Banco_Dados);
                lImp.ForEach(p =>
                    {
                        p.Id_lotefis = val.Id_lotefis;
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Gravar(p, qtb_lote.Banco_Dados);
                    });
                //Buscar Outros Creditos/Debitos
                CamadaDados.Fiscal.TList_LanctoImposto lOutrosImp =
                    new CamadaDados.Fiscal.TCD_LanctoImposto().Select(
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
                                vNM_Campo = "a.cd_imposto",
                                vOperador = "=",
                                vVL_Busca = val.Cd_impostostr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.dt_lancto",
                                vOperador = "<=",
                                vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), val.Dt_lote.Value.ToString("yyyyMMdd")) + " 23:59:59'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_lotefis",
                                vOperador = "is",
                                vVL_Busca = "null"
                            }
                        }, 0, string.Empty);
                lOutrosImp.ForEach(p =>
                    {
                        p.Id_lotefis = val.Id_lotefis;
                        CamadaNegocio.Fiscal.TCN_LanctoImposto.Processar(p, qtb_lote.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar registros fiscais: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_LoteImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteImposto qtb_lote = new TCD_LoteImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                val.Id_lotefis = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LOTEFIS"));
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteImposto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteImposto qtb_lote = new TCD_LoteImposto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                //Buscar lotes a excluir
                TList_LoteImposto lFechamento = Buscar(string.Empty,
                                                       val.Cd_impostostr,
                                                       val.Cd_empresa,
                                                       val.Dt_lotestr,
                                                       string.Empty,
                                                       string.Empty,
                                                       qtb_lote.Banco_Dados);
                if (lFechamento.Exists(p => p.St_registro.Trim().ToUpper().Equals("P")))
                    throw new Exception("Não é permitido excluir lote fiscal processado.\r\n" +
                                        "Necessario antes cancelar o pedido faturado.");
                lFechamento.ForEach(p => 
                    {
                        //Buscar todos os lancamentos de impostos pertencentes ao lote
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Buscar(string.Empty,
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
                                                                                       false,
                                                                                       p.Id_lotefis.Value.ToString(),
                                                                                       qtb_lote.Banco_Dados);
                        lImp.ForEach(v =>
                            {
                                v.Id_lotefis = null;
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_ImpostosNF.Gravar(v, qtb_lote.Banco_Dados);
                            });
                        //Buscar todos os lancamentos avulsos do lote
                        CamadaDados.Fiscal.TList_LanctoImposto lImpAvulso =
                            CamadaNegocio.Fiscal.TCN_LanctoImposto.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          p.Id_lotefis.Value.ToString(),
                                                                          qtb_lote.Banco_Dados);
                        lImpAvulso.ForEach(v =>
                            {
                                v.Id_lotefis = null;
                                CamadaNegocio.Fiscal.TCN_LanctoImposto.Gravar(v, qtb_lote.Banco_Dados);
                            });
                        qtb_lote.Excluir(p);
                    });
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }

    #endregion

    #region Lote Fiscal X Duplicata
    public class TCN_Lote_X_Duplicata
    {
        public static TList_Lote_X_Duplicata Buscar(string Id_lotefis,
                                                    string Cd_empresa,
                                                    string Nr_lancto,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lotefis))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotefis";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lotefis;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_Lote_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lote_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Duplicata qtb_lote = new TCD_Lote_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote x duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lote_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_Duplicata qtb_lote = new TCD_Lote_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
