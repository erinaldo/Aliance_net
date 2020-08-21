using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_ProximaEtapa
    {
        public static TList_ProximaEtapa Buscar(string Id_etapa,
                                                string Id_proximaetapa,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_etapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_etapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_etapa;
            }
            if (!string.IsNullOrEmpty(Id_proximaetapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_proximaetapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_proximaetapa;
            }
            return new TCD_ProximaEtapa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProximaEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProximaEtapa qtb_prox = new TCD_ProximaEtapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prox.CriarBanco_Dados(true);
                else
                    qtb_prox.Banco_Dados = banco;
                string retorno = qtb_prox.Gravar(val);
                if (st_transacao)
                    qtb_prox.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prox.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prox.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProximaEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProximaEtapa qtb_prox = new TCD_ProximaEtapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prox.CriarBanco_Dados(true);
                else
                    qtb_prox.Banco_Dados = banco;
                qtb_prox.Excluir(val);
                if (st_transacao)
                    qtb_prox.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prox.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prox.deletarBanco_Dados();
            }
        }
    }
}
