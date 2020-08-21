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
        public static TList_CadCategoriaCliFor Buscar(
                                         string vId_CategoriaCliFor,
                                         string vDs_CategoriaCliFor,
                                         string vNm_campo,
                                         int vTop,
                                         TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            
            if (vId_CategoriaCliFor.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_CategoriaCliFor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vId_CategoriaCliFor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            if (vDs_CategoriaCliFor.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ds_CategoriaCliFor";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vDs_CategoriaCliFor + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            TCD_CadCategoriaCliFor qtb_CategoriaCliFor = new TCD_CadCategoriaCliFor();
            return qtb_CategoriaCliFor.Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCategoriaCliFor(TRegistro_CadCategoriaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCategoriaCliFor qtb_CategoriaCliFor = new TCD_CadCategoriaCliFor();
            try
            {
                if (banco == null)
                {
                    qtb_CategoriaCliFor.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_CategoriaCliFor.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_CategoriaCliFor.GravarCategoriaCliFor(val);
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.deletarBanco_Dados();
            }
        }

        public static string DeletarCategoriaCliFor(TRegistro_CadCategoriaCliFor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCategoriaCliFor qtb_CategoriaCliFor = new TCD_CadCategoriaCliFor();
            try
            {
                if (banco == null)
                {
                    qtb_CategoriaCliFor.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_CategoriaCliFor.Banco_Dados = banco;
                
                qtb_CategoriaCliFor.DeletarCategoriaCliFor(val);
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor.deletarBanco_Dados();
            }
        }
    }
}
