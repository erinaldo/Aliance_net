using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Usuario_TpDuplicata
    {
        public static TList_Usuario_TpDuplicata Buscar(string Login,
                                                       string Tp_duplicata,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_duplicata.Trim() + "'";
            }
            return new TCD_Usuario_TpDuplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Usuario_TpDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_TpDuplicata qtb_tp = new TCD_Usuario_TpDuplicata();
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

        public static string Excluir(TRegistro_Usuario_TpDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_TpDuplicata qtb_tp = new TCD_Usuario_TpDuplicata();
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
