using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    #region Tipo Data
    public class TCN_TpData
    {
        public static TList_TpData Buscar(string ID_TpData,
                                               string DS_TpData,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(ID_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_TpData;
            }
            if (!string.IsNullOrEmpty(DS_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DS_TpData.Trim() + "'";
            }

            return new TCD_TpData(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpData val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpData qtb_data = new TCD_TpData();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                //Gravar
                val.Id_TpDataStr = CamadaDados.TDataQuery.getPubVariavel(qtb_data.Gravar(val), "@P_ID_TPDATA");
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return val.Id_TpDataStr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Tipo Data: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpData val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpData qtb_data = new TCD_TpData();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                qtb_data.Excluir(val);
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Tipo Data: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Data Clifor
    public class TCN_DataClifor
    {
        public static TList_DataClifor Buscar(string CD_Clifor,
                                               string ID_TpData,
                                               string DS_TpData,
                                               string TP_Clifor,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ID_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_TpData;
            }
            if (!string.IsNullOrEmpty(DS_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DS_TpData.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(TP_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + TP_Clifor.Trim() + "'";
            }

            return new TCD_DataClifor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DataClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DataClifor qtb_data = new TCD_DataClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                //Gravar
                string retorno = qtb_data.Gravar(val);
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Data Clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DataClifor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DataClifor qtb_data = new TCD_DataClifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                qtb_data.Excluir(val);
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Data Clifor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Data Contato
    public class TCN_DataContato
    {
        public static TList_DataContato Buscar(string ID_Contato,
                                               string CD_Clifor,
                                               string ID_TpData,
                                               string DS_TpData,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(ID_Contato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Contato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Contato;
            }
            if (!string.IsNullOrEmpty(CD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ID_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_TpData;
            }
            if (!string.IsNullOrEmpty(DS_TpData))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_TpData";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DS_TpData.Trim() + "'";
            }

            return new TCD_DataContato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DataContato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DataContato qtb_data = new TCD_DataContato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                //Gravar
                string retorno = qtb_data.Gravar(val);
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Data Contato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DataContato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DataContato qtb_data = new TCD_DataContato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_data.CriarBanco_Dados(true);
                else
                    qtb_data.Banco_Dados = banco;
                qtb_data.Excluir(val);
                if (st_transacao)
                    qtb_data.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_data.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Data Contato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_data.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
