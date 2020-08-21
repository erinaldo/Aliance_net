using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedidoItem_X_Estoque
    {
        public static TList_RegLanPedido_Item_X_Estoque Buscar(string Nr_pedido,
                                                               string Cd_produto,
                                                               string Id_pedidoitem,
                                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }
            return new TCD_LanPedido_Item_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarPedidoItensXEstoque(TRegistro_LanPedido_Item_X_Estoque val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPedido_Item_X_Estoque qtb_itensXEstoque = new TCD_LanPedido_Item_X_Estoque();
            try
            {
                //Startar Transação
                if (banco == null)
                {
                    qtb_itensXEstoque.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_itensXEstoque.Banco_Dados = banco;

                string retorno = qtb_itensXEstoque.Grava(val);
                if (pode_liberar)
                    qtb_itensXEstoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_itensXEstoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pedido x estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_itensXEstoque.deletarBanco_Dados();
            }
        }

        public static string DeletaPedidoItensXEstoque(TRegistro_LanPedido_Item_X_Estoque val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanPedido_Item_X_Estoque qtb_itensXEstoque = new TCD_LanPedido_Item_X_Estoque();
            try
            {
                //Startar Transação
                if (banco == null)
                {
                    qtb_itensXEstoque.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_itensXEstoque.Banco_Dados = banco;

                if (pode_liberar)
                    qtb_itensXEstoque.Banco_Dados.Commit_Tran();

                return qtb_itensXEstoque.Deleta(val);
            }
            catch
            {
                qtb_itensXEstoque.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    qtb_itensXEstoque.deletarBanco_Dados();
            }
        }

        public static void saldoPedidoXEstoque(string vNR_Pedido, string vCD_Produto, ref decimal tQuantidade, ref decimal tValor, TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            bool pode_liberar = false;
            TCD_LanPedido_Item_X_Estoque qtb_itensEstoque = new TCD_LanPedido_Item_X_Estoque();
            try
            {
                //Startar Transação
                if (banco == null)
                {
                    qtb_itensEstoque.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_itensEstoque.Banco_Dados = banco;
                DataTable tabela = qtb_itensEstoque.Buscar(vBusca, 1, "isNull(sum(isNull(b.QTD_Entrada,0) - isNull(b.QTD_Saida,0)),0) as QTD_Saldo, isNull(sum(case when b.tp_movimento = 'S' then -1 else 1 end * isNull(b.vl_subtotal,0)),0) as Vl_Saldo");
                if (tabela != null)
                    if (tabela.Rows.Count > 0)
                    {
                        try
                        {
                            tQuantidade = Convert.ToDecimal(tabela.Rows[0]["QTD_Saldo"].ToString());
                        }
                        catch
                        { tQuantidade = 0; }
                        try
                        {
                            tValor = Convert.ToDecimal(tabela.Rows[0]["Vl_Saldo"].ToString());
                        }
                        catch
                        { tValor = 0; }
                    }
            }
            finally
            {
                if (pode_liberar)
                    qtb_itensEstoque.deletarBanco_Dados();
            }
        }
    }
}
