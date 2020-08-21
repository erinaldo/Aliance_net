using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadTpImposto_x_SitTrib
    {
        public static TList_CadTpImposto_x_SitTrib Busca(string tp_imposto, 
                                                         string cd_st,
                                                         string cd_imposto,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(tp_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_imposto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_st))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_st";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_st.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_imposto;
            }
            return new TCD_CadTpImposto_x_SitTrib(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarTpImposto(TRegistro_CadTpImposto_x_SitTrib val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpImposto_x_SitTrib qtb_st = new TCD_CadTpImposto_x_SitTrib();
            try
            {
                if (banco == null)
                    st_transacao = qtb_st.CriarBanco_Dados(true);
                else
                    qtb_st.Banco_Dados = banco;
                string retorno = qtb_st.GravarImposto(val);
                if (st_transacao)
                    qtb_st.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_st.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_st.deletarBanco_Dados();
            }
        }

        public static string DeletarTpImposto(TRegistro_CadTpImposto_x_SitTrib val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpImposto_x_SitTrib qtb_st = new TCD_CadTpImposto_x_SitTrib();
            try
            {
                if (banco == null)
                    st_transacao = qtb_st.CriarBanco_Dados(true);
                else
                    qtb_st.Banco_Dados = banco;
                qtb_st.DeletarImposto(val);
                if (st_transacao)
                    qtb_st.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_st.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_st.deletarBanco_Dados();
            }
        }
    }
}
