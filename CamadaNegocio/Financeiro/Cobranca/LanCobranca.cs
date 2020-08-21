using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cobranca;

namespace CamadaNegocio.Financeiro.Cobranca
{
    #region "Classe Cobranca"
    public class TCN_Cobranca
    {
        public static TList_CobrancaClifor Buscar(decimal id_cobranca,
                                                  string login,
                                                  string dt_cobranca,
                                                  string ds_historico,
                                                  string nm_contato,
                                                  string fone_contato,
                                                  string dt_agendamento,
                                                  Parcelas[] parcelas,
                                                  int vTop,
                                                  string vNm_campo,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (id_cobranca > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cobranca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cobranca.ToString();
            }
            if (login.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + login.Trim() + "'";
            }
            if ((dt_cobranca.Trim() != string.Empty) && (dt_cobranca.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_cobranca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_cobranca).ToString("yyyyMMdd")) + "'";
            }
            if (ds_historico.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_historico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_historico.Trim() + "%')";
            }
            if (nm_contato.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_contato";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + nm_contato.Trim() + "%')";
            }
            if (fone_contato.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.fone_contato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + fone_contato.Trim() + "'";
            }
            if ((dt_agendamento.Trim() != string.Empty) && (dt_agendamento.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_agendamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_agendamento).ToString("yyyyMMdd")) + "'";
            }
            if (parcelas != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                string cond = string.Empty;
                string op = string.Empty;
                for (int i = 0; i < parcelas.Length; i++)
                {
                    cond += op + "((x.CD_Empresa = '" + parcelas[i].vCd_empresa + "')" +
                             "and(x.NR_Lancto = " + parcelas[i].vNr_lancto.ToString() + ")" +
                             "and(x.CD_Parcela = " + parcelas[i].vCd_parcela.ToString() + "))";
                    op = " or ";
                }
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_cobranca_x_parcelas x " +
                                                      "where x.id_cobranca = a.id_cobranca " +
                                                      "and " + cond + ")";
            }

            TCD_CobrancaClifor qtb_cobranca = new TCD_CobrancaClifor();
            qtb_cobranca.Banco_Dados = banco;
            return qtb_cobranca.Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCobranca(TRegistro_CobrancaClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CobrancaClifor qtb_cobranca = new TCD_CobrancaClifor();
            try
            {
                if (banco == null)
                {
                    qtb_cobranca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cobranca.Banco_Dados = banco;
                //Gravar Cobranca clifor
                string retorno = qtb_cobranca.GravarCobranca(val);
                val.Id_cobranca = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_COBRANCA"));
                //Parcelas
                val.lParcelas.ForEach(p =>
                {
                    //Cobrança x Parcela
                    p.Id_cobranca = val.Id_cobranca;
                    TCN_Cobranca_X_Parcelas.GravarCobranca_x_parcelas(p, qtb_cobranca.Banco_Dados);
                });
                
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cobranca.deletarBanco_Dados();
            }
        }

        public static string DeletarCobranca(TRegistro_CobrancaClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CobrancaClifor qtb_cobranca = new TCD_CobrancaClifor();
            try
            {
                if (banco == null)
                {
                    qtb_cobranca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cobranca.Banco_Dados = banco;
                //Deletar parcelas da cobranca
                foreach (TRegistro_Cobranca_X_Parcelas parcelas in val.lParcelas)
                    TCN_Cobranca_X_Parcelas.DeletarCobranca_x_parcelas(parcelas, qtb_cobranca.Banco_Dados);
                //Deletar Cobranca
                qtb_cobranca.DeletarCobranca(val);
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cobranca.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Cobranca X Parcelas"
    public class TCN_Cobranca_X_Parcelas
    {
        public static TList_Cobranca_X_Parcelas Buscar(decimal id_cobranca,
                                                       string cd_empresa,
                                                       decimal nr_lancto,
                                                       decimal cd_parcela,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (id_cobranca > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cobranca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cobranca.ToString();
            }
            if (cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (nr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_lancto.ToString();
            }
            if (cd_parcela > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_parcela.ToString();
            }
            TCD_Cobranca_X_Parcelas qtb_cobranca = new TCD_Cobranca_X_Parcelas();
            qtb_cobranca.Banco_Dados = banco;
            return qtb_cobranca.Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCobranca_x_parcelas(TRegistro_Cobranca_X_Parcelas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cobranca_X_Parcelas qtb_cobranca = new TCD_Cobranca_X_Parcelas();
            try
            {
                if (banco == null)
                {
                    qtb_cobranca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cobranca.Banco_Dados = banco;
                string retorno = qtb_cobranca.GravarCobranca_X_Parcelas(val);
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cobranca.deletarBanco_Dados();
            }
        }

        public static string DeletarCobranca_x_parcelas(TRegistro_Cobranca_X_Parcelas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cobranca_X_Parcelas qtb_cobranca = new TCD_Cobranca_X_Parcelas();
            try
            {
                if (banco == null)
                {
                    qtb_cobranca.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cobranca.Banco_Dados = banco;
                qtb_cobranca.DeletarCobranca_X_Parcelas(val);
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cobranca.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cobranca.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
