using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadSitTribut
    {
        public static TList_CadSitTribut Busca(string cd_st, 
                                               string ds_situacao, 
                                               string cd_imposto,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_st))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_st";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_st.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ds_situacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_situacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_situacao.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_imposto;
            }

            return new TCD_CadSitTribut(banco).Select(filtro, 0, string.Empty);
        }

        public static string gravaSitTrib(TRegistro_CadSitTribut val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSitTribut qtb_st = new TCD_CadSitTribut();
            try
            {
                if (banco == null)
                    st_transacao = qtb_st.CriarBanco_Dados(true);
                else
                    qtb_st.Banco_Dados = banco;
                string retorno = qtb_st.gravarSitTribut(val);
                if (st_transacao)
                    qtb_st.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_st.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar situacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_st.deletarBanco_Dados();
            }
        }

        public static string deletaSitTrib(TRegistro_CadSitTribut val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSitTribut qtb_st = new TCD_CadSitTribut();
            try
            {
                if (banco == null)
                    st_transacao = qtb_st.CriarBanco_Dados(true);
                else
                    qtb_st.Banco_Dados = banco;
                qtb_st.deletarSitTribut(val);
                if (st_transacao)
                    qtb_st.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_st.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir situacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_st.deletarBanco_Dados();
            }
        }

    }
}
