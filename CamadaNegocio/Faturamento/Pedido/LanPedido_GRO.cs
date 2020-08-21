using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Faturamento.Pedido;


namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido_GRO
    {
        public static TList_RegLanPedido_GRO Busca(Int64 vNr_Pedido)
        {
            TCD_LanPedido_GRO cd = new TCD_LanPedido_GRO();
            TpBusca[] filtro = new TpBusca[1];

            filtro[0].vNM_Campo = "a.Nr_Pedido";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = vNr_Pedido.ToString();

            return cd.Select(filtro, 0, "");
        }
        public static string GravaPedido(TRegistro_LanPedido_GRO val)
        {
            TCD_LanPedido_GRO cd = new TCD_LanPedido_GRO();
            return cd.Grava(val);
        }
        public static void DeletaPedido_Item_GRO(TRegistro_LanPedido_GRO val)
        {
            //Deletar Item do pedido GRAOS
            TCD_LanPedido_GRO CD = new TCD_LanPedido_GRO();
            CD.Deleta(val);

        }


    }
}
