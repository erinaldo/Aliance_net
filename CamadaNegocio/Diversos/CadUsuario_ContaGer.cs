using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Usuario_ContaGer
    {
        public static TList_Usuario_ContaGer Buscar(string Login,
                                                    string Cd_contager,
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
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            return new TCD_Usuario_ContaGer(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Usuario_ContaGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_ContaGer qtb_cg = new TCD_Usuario_ContaGer();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cg.CriarBanco_Dados(true);
                else
                    qtb_cg.Banco_Dados = banco;
                string retorno = qtb_cg.Gravar(val);
                if (st_transacao)
                    qtb_cg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar conta ger.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Usuario_ContaGer val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_ContaGer qtb_cg = new TCD_Usuario_ContaGer();
            try
            {
                if(banco == null)
                    st_transacao = qtb_cg.CriarBanco_Dados(true);
                else
                    qtb_cg.Banco_Dados = banco;
                qtb_cg.Excluir(val);
                if(st_transacao)
                    qtb_cg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir conta ger.: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cg.deletarBanco_Dados();
            }
        }
    }
}
