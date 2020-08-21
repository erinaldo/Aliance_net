using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public class TCN_CTROrdemColeta
    {
        public static TList_CTROrdemColeta Buscar(string Cd_empresa,
                                                  string Nr_lanctoctr,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            return new TCD_CTROrdemColeta(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CTROrdemColeta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTROrdemColeta qtb_oc = new TCD_CTROrdemColeta();
            try
            {
                if (banco == null)
                    st_transacao = qtb_oc.CriarBanco_Dados(true);
                else qtb_oc.Banco_Dados = banco;
                string retorno = qtb_oc.Gravar(val);
                if (st_transacao)
                    qtb_oc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_oc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ordem coleta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_oc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTROrdemColeta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTROrdemColeta qtb_oc = new TCD_CTROrdemColeta();
            try
            {
                if (banco == null)
                    st_transacao = qtb_oc.CriarBanco_Dados(true);
                else qtb_oc.Banco_Dados = banco;
                qtb_oc.Excluir(val);
                if (st_transacao)
                    qtb_oc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_oc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ordem coleta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_oc.deletarBanco_Dados();
            }
        }
    }
}
