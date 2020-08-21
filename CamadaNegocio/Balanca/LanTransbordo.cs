using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_LanTransbordo
    {
        public static TList_LanTransbordo Buscar(decimal Id_transbordo,
                                          string Cd_empresaorig,
                                          decimal Id_ticketorig,
                                          string Tp_pesagemorig,
                                          string Cd_empresadest,
                                          decimal Id_ticketdest,
                                          string Tp_pesagemdest,
                                          int vTop,
                                          string vNm_campo)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_transbordo > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_transbordo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_transbordo.ToString();
            }
            if (Cd_empresaorig.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresaorig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresaorig.Trim() + "'";
            }
            if (Id_ticketorig > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticketorig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticketorig.ToString();
            }
            if (Tp_pesagemorig.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagemorig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagemorig.Trim() + "'";
            }
            if (Cd_empresadest.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresadest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresadest.Trim() + "'";
            }
            if (Id_ticketdest > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticketdest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticketdest.ToString();
            }
            if (Tp_pesagemdest.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagemdest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagemdest.Trim() + "'";
            }

            return new TCD_LanTransbordo().Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTransbordo(TRegistro_LanTransbordo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTransbordo qtb_transbordo = new TCD_LanTransbordo();
            try
            {
                if (banco == null)
                {
                    qtb_transbordo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_transbordo.Banco_Dados = banco;
                //Gravar Transbordo
                string retorno = qtb_transbordo.GravarTransbordo(val);
                if (st_transacao)
                    qtb_transbordo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transbordo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_transbordo.deletarBanco_Dados();
            }
        }

        public static string DeletarTransbordo(TRegistro_LanTransbordo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTransbordo qtb_transbordo = new TCD_LanTransbordo();
            try
            {
                if (banco == null)
                {
                    qtb_transbordo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_transbordo.Banco_Dados = banco;
                //Deletar Transbordo
                qtb_transbordo.DeletarTransbordo(val);
                if (st_transacao)
                    qtb_transbordo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transbordo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_transbordo.deletarBanco_Dados();
            }
        }
    }
}
