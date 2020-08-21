using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadPais
    {
        public static TList_CadPais Buscar(
                                         string vCd_pais,
                                         string vNm_Pais,
                                         string vNm_campo,
                                         int vTop,
                                         TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            
            if (vCd_pais.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_pais";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_pais.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            if (vNm_Pais.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nm_Pais";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNm_Pais + "%'";
                filtro[filtro.Length - 1].vOperador = "LIKE";
            }
            TCD_CadPais qtb_pais = new TCD_CadPais();
            return qtb_pais.Select(filtro, vTop, vNm_campo);
        }

        public static string GravarPais(TRegistro_CadPais val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPais qtb_pais = new TCD_CadPais();
            try
            {
                if (banco == null)
                {
                    qtb_pais.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_pais.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_pais.GravarPais(val);
                if (st_transacao)
                    qtb_pais.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pais.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_pais.deletarBanco_Dados();
            }
        }

        public static string DeletarPais(TRegistro_CadPais val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPais qtb_pais = new TCD_CadPais();
            try
            {
                if (banco == null)
                {
                    qtb_pais.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_pais.Banco_Dados = banco;
                //Deletar Uf
                qtb_pais.DeletarPais(val);
                if (st_transacao)
                    qtb_pais.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pais.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_pais.deletarBanco_Dados();
            }
        }
    }
}
