using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_MetodoAnalise
    {
        public static TList_MetodoAnalise Buscar(string Id_metodo,
                                                 string Ds_metodo,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_metodo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_metodo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_metodo;
            }
            if (!string.IsNullOrEmpty(Ds_metodo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_metodo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_metodo.Trim() + "%')";
            }
            return new TCD_MetodoAnalise(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MetodoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MetodoAnalise qtb_metodo = new TCD_MetodoAnalise();
            try
            {
                if (banco == null)
                    st_transacao = qtb_metodo.CriarBanco_Dados(true);
                else
                    qtb_metodo.Banco_Dados = banco;
                string retorno = qtb_metodo.Gravar(val);
                if (st_transacao)
                    qtb_metodo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_metodo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_metodo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MetodoAnalise val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MetodoAnalise qtb_metodo = new TCD_MetodoAnalise();
            try
            {
                if (banco == null)
                    st_transacao = qtb_metodo.CriarBanco_Dados(true);
                else
                    qtb_metodo.Banco_Dados = banco;
                qtb_metodo.Excluir(val);
                if (st_transacao)
                    qtb_metodo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_metodo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_metodo.deletarBanco_Dados();
            }
        }
    }
}
