using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadSitTrib_Piscofins
    {
        public static TList_CadSitTrib_Piscofins Busca(string cd_sittrib, string ds_sittrib)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (cd_sittrib.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "cd_sittrib";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_sittrib + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (ds_sittrib.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ds_sittrib";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ds_sittrib + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_CadSitTrib_Piscofins piscofins = new TCD_CadSitTrib_Piscofins();
            return piscofins.Select(vBusca, 0, "");
            
        }
        
        public static string GravarPiscofins(TRegistro_CadSitTrib_Piscofins val)
        {
            TCD_CadSitTrib_Piscofins piscofins = new TCD_CadSitTrib_Piscofins();
            return piscofins.GravarCofins(val);
            
        }

        public static string DeletarPiscofins(TRegistro_CadSitTrib_Piscofins val)
        {
            TCD_CadSitTrib_Piscofins piscofins = new TCD_CadSitTrib_Piscofins();
            return piscofins.DeletarCofins(val);
        }
    }
}
