using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Locacao.Cadastros;

namespace CamadaNegocio.Locacao.Cadastros
{
    public class TCN_CadPrecoItens
    {
        public static TList_CadPrecoItens Buscar(string Id_tabela,
                                          string Cd_empresa,
                                          string Cd_produto,
                                          string Nr_patrimonio,
                                          string Cd_grupo,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_tabela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tabela;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                      "where x.CD_Patrimonio = a.CD_Produto " +
                                                      "and x.NR_Patrimonio = '" + Nr_patrimonio.Trim() + "') ";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto x " +
                                                      "where x.CD_Produto = a.CD_Produto " +
                                                      "and x.Cd_grupo = '" + Cd_grupo.Trim() + "') ";
            }
            return new TCD_CadPrecoItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadPrecoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPrecoItens qtb_preco = new TCD_CadPrecoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                string retorno = qtb_preco.Gravar(val);
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tabela preco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadPrecoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPrecoItens qtb_preco = new TCD_CadPrecoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                qtb_preco.Excluir(val);
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tabela preco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }
    }
}
