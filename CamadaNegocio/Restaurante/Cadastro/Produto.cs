using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Restaurante.Cadastro;
using BancoDados;

namespace CamadaNegocio.Restaurante.Cadastro
{
    public class TCN_Produto
    {

        public static string Gravar(TRegistro_CadProduto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadProduto qtb_produto = new TCD_CadProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_produto.CriarBanco_Dados(true);
                else
                    qtb_produto.Banco_Dados = banco;
                TList_CFG cfg = TCN_CFG.Buscar(string.Empty, qtb_produto.Banco_Dados);


                val.CD_Produto = CamadaDados.TDataQuery.getPubVariavel(qtb_produto.Grava(val), "@P_CD_PRODUTO");

                //monta objeto
                CamadaDados.Estoque.TRegistro_LanPrecoItem preco = new CamadaDados.Estoque.TRegistro_LanPrecoItem();
                preco.CD_Empresa = cfg[0].cd_empresa;
                preco.CD_TabelaPreco = cfg[0].cd_tabelapreco;
                preco.CD_Produto = val.CD_Produto;
                preco.VL_PrecoVenda = val.Vl_precovenda;
                CamadaDados.Estoque.TList_LanPrecoItem lista = new CamadaDados.Estoque.TList_LanPrecoItem();
                lista.Add(preco);

                TCN_LanPrecoItem.Grava_LanPrecoItem(lista, qtb_produto.Banco_Dados);

                if (st_transacao)
                    qtb_produto.Banco_Dados.Commit_Tran();
                return val.CD_Produto;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_produto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_produto.deletarBanco_Dados();
            }
        }


    }
}
