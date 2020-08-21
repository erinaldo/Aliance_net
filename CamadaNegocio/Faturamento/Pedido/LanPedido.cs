using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;
using System.Windows.Forms;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido
    {

        public static TList_RegLanPedido Busca(string vCD_Empresa,
                                        bool vTp_Movimento_Ent,
                                        bool vTp_Movimento_Sai,
                                        Int64 vNr_Pedido,                                        
                                        string vCD_Clifor,
                                        string vCD_Endereco,
                                        string vDS_ObsPedido,
                                        string vNr_PedidoOrigem,
                                        string vDT_Pedido,
                                        string vCFG_Pedido)
        {
            TCD_LanPedido cd = new TCD_LanPedido();
            TpBusca[] filtro = new TpBusca[0];

            if (vTp_Movimento_Ent)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'E'";
            };            
            if (vTp_Movimento_Sai)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            };
            if (vCD_Empresa != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
            };
            if (vNr_Pedido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido.ToString();
            };
            if (vCD_Clifor != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
            };
            if (vCD_Endereco != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Endereco + "'";
            };
            if (vDS_ObsPedido != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDS_ObsPedido + "'";
            };
            if (vNr_PedidoOrigem != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_PedidoOrigem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_PedidoOrigem + "'";
            };
            if (vDT_Pedido != "  /  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDT_Pedido.ToString() + "'";
            };
            if (vCFG_Pedido != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCFG_Pedido + "'";
            };
                        
            return cd.Select(filtro, 0, "");
        }

        public static string GravaPedido(TRegistro_LanPedido vPedido, TObjetoBanco banco)
        {
            string ret = "";
            TCD_LanPedido qtb_pedido = new TCD_LanPedido();
            TCD_LanPedido_Fiscal qtb_pedidoFiscal = new TCD_LanPedido_Fiscal();
            TCD_LanPedido_GRO qtb_pedidoGRO = new TCD_LanPedido_GRO();
            TCD_LanPedido_Venda qtb_Venda = new TCD_LanPedido_Venda();

            try
            {
                if (banco == null)
                {
                    qtb_pedido.CriarBanco_Dados(true);
                    banco = qtb_pedido.Banco_Dados;
                }
                else
                    qtb_pedido.Banco_Dados = banco;

                ret = qtb_pedido.Grava(vPedido);  //GRAVA O PEDIDO E OS ITENS
                
                //if (vPedido.PedidoFinan.Count > 0)
                //{
                //    qtb_pedidoFinan.Banco_Dados = banco;
                //    for (int x = 0; x < vPedido.PedidoFinan.Count; x ++)
                //      qtb_pedidoFinan.Grava (vPedido.PedidoFinan[x]);
                //};
                if (vPedido.PedidoFiscal.Count > 0)
                {
                    qtb_pedidoFiscal.Banco_Dados = banco;
                    for (int x = 0; x < vPedido.PedidoFiscal.Count; x++)
                      qtb_pedidoFiscal.Grava(vPedido.PedidoFiscal[x]);
                };
                if (vPedido.PedidoGRO.Count > 0)
                {
                    qtb_pedidoGRO.Banco_Dados = banco;                    
                    qtb_pedidoGRO.Grava(vPedido.PedidoGRO[0]); //SO TERA UM REGISTRO
                };
                if (vPedido.PedidoVenda.Count > 0)
                {
                    qtb_Venda.Banco_Dados = banco;
                    qtb_Venda.Grava(vPedido.PedidoVenda[0]);
                };

                qtb_pedido.Banco_Dados.Commit_Tran();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro! Registro não foi gravado !");
                qtb_pedido.Banco_Dados.RollBack_Tran();
            }
            finally
            {
                qtb_pedido.deletarBanco_Dados();
            };

            return ret;
        }
    }
}
