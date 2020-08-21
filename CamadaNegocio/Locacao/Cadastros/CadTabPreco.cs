using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Locacao.Cadastros;

namespace CamadaNegocio.Locacao.Cadastros
{
    public class TCN_CadTabPreco
    {
        public static TList_CadTabPreco Buscar(string Id_tabela,
                                          string Ds_tabela,
                                          string Tp_tabela,
                                          BancoDados.TObjetoBanco banco,
                                          bool cbxCancelados = false)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_tabela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tabela;
            }
            if (!string.IsNullOrEmpty(Ds_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Ds_tabela";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_tabela.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Tp_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_tabela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_tabela.Trim() + "'";
            }

            if (cbxCancelados == true)
                Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.cancelado, 0)", "1");
            else
                Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.cancelado, 0)", "0");


            return new TCD_CadTabPreco(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadTabPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTabPreco qtb_tabpreco = new TCD_CadTabPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tabpreco.CriarBanco_Dados(true);
                else
                    qtb_tabpreco.Banco_Dados = banco;
                string retorno = qtb_tabpreco.Gravar(val);
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tabela preco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tabpreco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadTabPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTabPreco qtb_tabpreco = new TCD_CadTabPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tabpreco.CriarBanco_Dados(true);
                else
                    qtb_tabpreco.Banco_Dados = banco;
                qtb_tabpreco.Excluir(val);
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tabela preco: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tabpreco.deletarBanco_Dados();
            }
        }

        public static void Cancelar(TRegistro_CadTabPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTabPreco qtb_tabpreco = new TCD_CadTabPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tabpreco.CriarBanco_Dados(true);
                else
                    qtb_tabpreco.Banco_Dados = banco;

                val.Cancelado = true;
                qtb_tabpreco.Gravar(val);
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tabpreco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao cancelar a tabela de preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tabpreco.deletarBanco_Dados();
            }
        }
    }
}
