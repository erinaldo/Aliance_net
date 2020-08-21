using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadDescontoxProduto
    {
    


        public static TList_CadDescontoxProduto Busca(string vCd_TabelaDesconto,
                                                         string vCd_Produto,
                                                         string vSt_Registro)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCd_TabelaDesconto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_TabelaDesconto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_TabelaDesconto + "'";
            }

            if (vCd_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Produto + "'";
            }

            if (vSt_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.St_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_Registro + "'";
            }

            TCD_CadDescontoxProdutos cd = new TCD_CadDescontoxProdutos();
            return cd.Select( vBusca, 0, "");
        }

        public static string Grava_CadDescontoProduto(TRegistro_CadDescontoxProduto val)
        {
            TCD_CadDescontoxProdutos cd = new TCD_CadDescontoxProdutos();
            return cd.Grava(val);
        }

        public static void Deleta_CadDescontoxProduto(TRegistro_CadDescontoxProduto val)
        {
            TCD_CadDescontoxProdutos cd = new TCD_CadDescontoxProdutos();
            cd.Deleta(val);
        }
    }
}

