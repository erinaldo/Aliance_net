using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadCategoriaCliFor
    {
        public static TList_CadCategoriaCliFor Buscar(string vId_CategoriaCliFor,
                                                      string vDs_CategoriaCliFor,
                                                      string vNm_campo,
                                                      int vTop,
                                                      TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            
            if (!string.IsNullOrEmpty(vId_CategoriaCliFor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_CategoriaCliFor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vId_CategoriaCliFor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            if (!string.IsNullOrEmpty(vDs_CategoriaCliFor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ds_CategoriaCliFor";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vDs_CategoriaCliFor + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            return new TCD_CadCategoriaCliFor(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadCategoriaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCategoriaCliFor qtb_CategoriaCliFor = new TCD_CadCategoriaCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CategoriaCliFor.CriarBanco_Dados(true);
                else
                    qtb_CategoriaCliFor.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_CategoriaCliFor.Gravar(val);
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadCategoriaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCategoriaCliFor qtb_CategoriaCliFor = new TCD_CadCategoriaCliFor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CategoriaCliFor.CriarBanco_Dados(true);
                else
                    qtb_CategoriaCliFor.Banco_Dados = banco;
                
                qtb_CategoriaCliFor.Excluir(val);
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.RollBack_Tran();
                    throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.deletarBanco_Dados();
            }
        }
    }
}
