using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadCategoriaCliFor_X_TabelaPreco
    {
        public static TList_RegCategoriaCliFor_X_TabelaPreco Busca(string vID_CategoriaCliFor,
                                              string vCD_TabelaPreco,
                                              int vTop,
                                              string vNM_Campo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if ((vID_CategoriaCliFor.Trim() != "")&&(vID_CategoriaCliFor.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_CATEGORIACLIFOR";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_CategoriaCliFor;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_TabelaPreco.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TABELAPRECO";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaPreco + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_CategoriaCliFor_X_TabelaPreco(banco).Select(vBusca, vTop, vNM_Campo);
        }
    

        public static string GravaCategoriaCliFor_X_TabelaPreco(TRegistro_CategoriaCliFor_X_TabelaPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CategoriaCliFor_X_TabelaPreco qtb_CategoriaCliFor_X_TabelaPreco = new TCD_CategoriaCliFor_X_TabelaPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CategoriaCliFor_X_TabelaPreco.CriarBanco_Dados(true);
                else
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados = banco;
                string retorno = qtb_CategoriaCliFor_X_TabelaPreco.GravarCategoriaCliFor_X_TabelaPreco(val);
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.deletarBanco_Dados();
            }
        }

        public static string DeletaCategoriaCliFor_X_TabelaPreco(TRegistro_CategoriaCliFor_X_TabelaPreco val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CategoriaCliFor_X_TabelaPreco qtb_CategoriaCliFor_X_TabelaPreco = new TCD_CategoriaCliFor_X_TabelaPreco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_CategoriaCliFor_X_TabelaPreco.CriarBanco_Dados(true);
                else
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados = banco;
                qtb_CategoriaCliFor_X_TabelaPreco.DeletarCategoriaCliFor_X_TabelaPreco(val);
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_CategoriaCliFor_X_TabelaPreco.deletarBanco_Dados();
            }
        }
    }
}
