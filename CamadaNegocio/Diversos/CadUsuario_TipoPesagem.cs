using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario_TipoPesagem
    {
        public static TList_CadUsuario_TipoPesagem Busca(string login, 
                                                         string tp_pesagem,
                                                         BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(login))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.login";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + login.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(tp_pesagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + tp_pesagem.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_CadUsuario_TipoPesagem(banco).Select(vBusca, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadUsuario_TipoPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_TipoPesagem qtb_tp = new TCD_CadUsuario_TipoPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                string retorno = qtb_tp.GravaTipoPesagem(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadUsuario_TipoPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_TipoPesagem qtb_tp = new TCD_CadUsuario_TipoPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.DeletaTipoPesagem(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tipo pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
