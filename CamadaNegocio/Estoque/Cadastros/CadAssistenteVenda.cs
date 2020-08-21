using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadAssistenteVenda
    {
        public static TList_CadAssistenteVenda Busca(string vCD_Produto,
                                                   string vCD_ProdVenda,
                                                   BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }

            if (vCD_ProdVenda.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_ProdVenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_ProdVenda.Trim() + "'";
            }

            return new TCD_CadAssistenteVenda(banco).Select(vBusca, 0, "");
        }

        public static string Gravar(TRegistro_CadAssistenteVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAssistenteVenda cd = new TCD_CadAssistenteVenda();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Assistente Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadAssistenteVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAssistenteVenda cd = new TCD_CadAssistenteVenda();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Assistente Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
