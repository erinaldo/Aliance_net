using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadCliforInativo
    {
        public static TList_CadCliforInativo Buscar(string ID_Inativo,
                                                    string DS_Complemento,
                                                    int vTop,
                                                    string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (ID_Inativo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ID_Inativo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + ID_Inativo.Trim() + "'";
            }
            if (DS_Complemento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "DS_Complemento";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + DS_Complemento.Trim() + "%')";
            }
            return new TCD_CadCliforInativo().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadCliforInativo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCliforInativo qtb_cliforinativo = new TCD_CadCliforInativo();
            try
            {
                if (banco == null)
                {
                    qtb_cliforinativo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cliforinativo.Banco_Dados = banco;
                string retorno = qtb_cliforinativo.GravarCliforInativo(val);
                if (st_transacao)
                    qtb_cliforinativo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cliforinativo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cliforinativo.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_CadCliforInativo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCliforInativo qtb_cliforinativo = new TCD_CadCliforInativo();
            try
            {
                if (banco == null)
                {
                    qtb_cliforinativo.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_cliforinativo.Banco_Dados = banco;
                qtb_cliforinativo.DeletarCliforInativo(val);
                if (st_transacao)
                    qtb_cliforinativo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cliforinativo.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cliforinativo.deletarBanco_Dados();
            }
        }
    }
}
