using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadMarca
    {
        public static TList_CadMarca Busca(string vCd_Marca, string vDs_Marca)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCd_Marca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Marca+ "'";
            }
            if (vDs_Marca.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDs_Marca+ "'";
            }
            TCD_CadMarca cd = new TCD_CadMarca();
            return cd.Select(vBusca, 0, "");
        }
        public static string Grava_CadMarca(TRegistro_CadMarca val)
        {
            TCD_CadMarca cd = new TCD_CadMarca();
            return cd.GravaCadMarca(val);
        }
        public static string Deleta_CadMarca(TRegistro_CadMarca val)
        {
            TCD_CadMarca cd = new TCD_CadMarca();
            return cd.DeletaCadMarca(val);
        }
    }
     
}


