using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_Variedade
    {
        public static TList_Variedade Buscar(string Cd_produto,
                                             string Id_variedade,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_variedade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_variedade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_variedade;
            }
            return new TCD_Variedade().Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Variedade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Variedade qtb_variedade = new TCD_Variedade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_variedade.CriarBanco_Dados(true);
                else qtb_variedade.Banco_Dados = banco;
                val.Id_variedadestr = CamadaDados.TDataQuery.getPubVariavel(qtb_variedade.Gravar(val), "@P_ID_VARIEDADE");
                if (st_transacao)
                    qtb_variedade.Banco_Dados.Commit_Tran();
                return val.Id_variedadestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_variedade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar variedade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_variedade.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Variedade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Variedade qtb_variedade = new TCD_Variedade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_variedade.CriarBanco_Dados(true);
                else qtb_variedade.Banco_Dados = banco;
                qtb_variedade.Excluir(val);
                if (st_transacao)
                    qtb_variedade.Banco_Dados.Commit_Tran();
                return val.Id_variedadestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_variedade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir variedade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_variedade.deletarBanco_Dados();
            }
        }
    }
}
