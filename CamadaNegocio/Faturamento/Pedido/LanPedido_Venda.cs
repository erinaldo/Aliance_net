using System;
using System.Collections.Generic;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;


namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido_Venda
    {
        public static TList_RegLanPedidoVenda Busca(decimal vNr_Pedido)
        {
            TCD_LanPedido_Venda cd = new TCD_LanPedido_Venda();
            TpBusca[] filtro = new TpBusca[1];

            filtro[0].vNM_Campo = "a.Nr_Pedido";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = vNr_Pedido.ToString();

            return cd.Select(filtro, 0, "");
        }
        public static string GravaPedido_Venda(TRegistro_LanPedidoVenda val)
        {
            TCD_LanPedido_Venda cd = new TCD_LanPedido_Venda();
            return cd.Grava(val);
        }
        public static void DeletaPedido_Venda(TRegistro_LanPedidoVenda val)
        {
            TCD_LanPedido_Venda cd = new TCD_LanPedido_Venda();
            cd.Deleta(val);
        }
    }
}
