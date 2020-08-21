using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Usuario_TpRequisicao
    {
        public static TList_Usuario_TpRequisicao Buscar(string Login,
                                                        string Id_tprequisicao,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_tprequisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tprequisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tprequisicao;
            }
            return new TCD_Usuario_TpRequisicao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Usuario_TpRequisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_TpRequisicao qtb_user = new TCD_Usuario_TpRequisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                string retorno = qtb_user.Gravar(val);
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Usuario_TpRequisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_TpRequisicao qtb_user = new TCD_Usuario_TpRequisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                qtb_user.Excluir(val);
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }
    }
}
