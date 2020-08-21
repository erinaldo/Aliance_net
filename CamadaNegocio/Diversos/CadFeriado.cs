using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using Utils;

namespace CamadaNegocio.Diversos
{
   public class TCN_CadFeriado
    {
       public static TList_CadFeriado Busca(string vIdFeriado, string vDs_Feriado,
                                            string vDtFeriado, string vSt_RepeteAnual)
       {

           TpBusca[] vBusca = new TpBusca[0];

           if (vIdFeriado.Trim() !="")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "Id_Feriado";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vIdFeriado + "'";

           }
           if (vDs_Feriado.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "Ds_Feriado";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDs_Feriado + "'";
           }
           if (vDtFeriado.Trim() != "/  /")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "dt_Feriado";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDtFeriado).ToString("yyyyMMdd")) + "'";
           }
           
           TCD_CadFeriado cd = new TCD_CadFeriado();
           return cd.Select(vBusca, 0, "");
       }
       public static string Grava_CadFeriado(TRegistro_CadFeriado val)
       {
           TCD_CadFeriado cd = new TCD_CadFeriado();
           return cd.Grava(val);
       }
       public static string Deleta_CadFeriado(TRegistro_CadFeriado val)
       {
           TCD_CadFeriado cd = new TCD_CadFeriado();
           return cd.Deleta(val);
       }

    }
}
