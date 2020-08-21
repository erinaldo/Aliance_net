using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_TpOrdem_X_Etapa
    {
        public static TList_TpOrdem_X_Etapa Buscar(string Id_etapa,
                                                   string Tp_ordem,
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
            if (!string.IsNullOrEmpty(Tp_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Tp_ordem;
            }
            return new TCD_TpOrdem_X_Etapa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpOrdem_X_Etapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpOrdem_X_Etapa qtb_tp = new TCD_TpOrdem_X_Etapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                string retorno = qtb_tp.Gravar(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpOrdem_X_Etapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpOrdem_X_Etapa qtb_tp = new TCD_TpOrdem_X_Etapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
