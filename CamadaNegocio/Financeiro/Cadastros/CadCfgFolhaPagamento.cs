using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CfgFolhaPagamento
    {
        public static TList_CfgFolhaPagamento Buscar(string Cd_empresa,
                                                     string Cd_historico,
                                                     string Cd_condpgto,
                                                     string Tp_duplicata,
                                                     string Tp_docto,
                                                     string Cd_contager,
                                                     string Cd_portador,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_condpgto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_docto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }

            return new TCD_CfgFolhaPagamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgFolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgFolhaPagamento qtb_folha = new TCD_CfgFolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                string retorno = qtb_folha.Gravar(val);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgFolhaPagamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgFolhaPagamento qtb_folha = new TCD_CfgFolhaPagamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_folha.CriarBanco_Dados(true);
                else
                    qtb_folha.Banco_Dados = banco;
                qtb_folha.Excluir(val);
                if (st_transacao)
                    qtb_folha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_folha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_folha.deletarBanco_Dados();
            }
        }
    }
}
