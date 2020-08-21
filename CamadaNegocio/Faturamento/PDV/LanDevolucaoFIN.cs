using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_DevolucaoFIN
    {
        public static TList_DevolucaoFIN Buscar(string Cd_empresa,
                                                string Id_devolucao,
                                                string Nr_lancto,
                                                string Cd_parcela,
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
            if (!string.IsNullOrEmpty(Id_devolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devolucao;
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            if (!string.IsNullOrEmpty(Cd_parcela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela;
            }
            return new TCD_DevolucaoFIN(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DevolucaoFIN val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoFIN qtb_dev = new TCD_DevolucaoFIN();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                string retorno = qtb_dev.Gravar(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DevolucaoFIN val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoFIN qtb_dev = new TCD_DevolucaoFIN();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                qtb_dev.Excluir(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }
    }
}
