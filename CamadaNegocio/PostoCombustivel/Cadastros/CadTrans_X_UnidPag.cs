using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_Trans_X_UnidPag
    {
        public static TList_Trans_X_UnidPag Buscar(string CD_Transportadora,
                                            string CD_UnidPagadora,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Transportadora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Transportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Transportadora + "'";
            }
            if (!string.IsNullOrEmpty(CD_UnidPagadora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_UnidPagadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_UnidPagadora.Trim() + "'";
            }
            return new TCD_Trans_X_UnidPag(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_Trans_X_UnidPag val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Trans_X_UnidPag qtb_unid = new TCD_Trans_X_UnidPag();
            try
            {
                if (banco == null)
                    st_transacao = qtb_unid.CriarBanco_Dados(true);
                else
                    qtb_unid.Banco_Dados = banco;
                string retorno = qtb_unid.Gravar(val);
                if (st_transacao)
                    qtb_unid.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_unid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_unid.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Trans_X_UnidPag val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Trans_X_UnidPag qtb_unid = new TCD_Trans_X_UnidPag();
            try
            {
                if (banco == null)
                    st_transacao = qtb_unid.CriarBanco_Dados(true);
                else
                    qtb_unid.Banco_Dados = banco;
                qtb_unid.Excluir(val);
                if (st_transacao)
                    qtb_unid.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_unid.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_unid.deletarBanco_Dados();
            }
        }
    }
}
