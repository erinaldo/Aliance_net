using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadCidade
    {
        public static TList_CadCidade Buscar(string vCd_cidade,
                                             string vDs_cidade,
                                             string vUf,
                                             string vNm_campo,
                                             int vTop,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_cidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Cidade";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_cidade.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_cidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Cidade";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_cidade.ToString().Trim().Replace("'", "''") + "%' COLLATE Latin1_General_CI_AI )";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vUf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.UF";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vUf.ToString().Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            
            return new TCD_CadCidade(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TRegistro_CadCidade BuscarCidade(string vCd_cidade,
                                                       string vDs_cidade,
                                                       string vDistrito,
                                                       string vUf,
                                                       string vNm_campo,
                                                       int vTop,
                                                       TObjetoBanco banco)
        {
            TList_CadCidade lCidade = Buscar(vCd_cidade, vDs_cidade, vUf, vNm_campo, vTop, banco);
            if (lCidade.Count > 0)
                return lCidade[0];
            else
                return new TRegistro_CadCidade();
        }

        public static string Gravar(TRegistro_CadCidade val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCidade qtb_cidade = new TCD_CadCidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cidade.CriarBanco_Dados(true);
                else
                    qtb_cidade.Banco_Dados = banco;
                //Gravar Cidade
                string retorno = qtb_cidade.Gravar(val);
                if (st_transacao)
                    qtb_cidade.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cidade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cidade: " + ex.Message);
            }
                finally
            {
                if (st_transacao)
                    qtb_cidade.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadCidade val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCidade qtb_cidade = new TCD_CadCidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cidade.CriarBanco_Dados(true);
                else
                    qtb_cidade.Banco_Dados = banco;
                //Deletar Cidade
                qtb_cidade.Excluir(val);
                if (st_transacao)
                    qtb_cidade.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cidade.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cidade: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cidade.deletarBanco_Dados();
            }
        }
    }
}
