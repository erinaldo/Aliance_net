using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using Utils;


namespace CamadaNegocio.Diversos
{
   public  class TCN_CadTipoTransporte
    {
       public static TList_CadTipoTransporte Busca(decimal vId_TpTransp, 
                                                   string vDs_TpTransp,
                                                   string vCd_transportadora)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (vId_TpTransp > 0)
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_tptransp";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_TpTransp + "'";
           }
           if (vDs_TpTransp.Trim() != "")
           {
               Array.Resize(ref vBusca,vBusca.Length+1);
               vBusca[vBusca.Length-1].vNM_Campo="a.ds_tptransp";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDs_TpTransp.Replace("'", "''") + "'";
           }
           if (vCd_transportadora.Trim() != string.Empty)
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_transportadora";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_transportadora.Trim() + "'";
           }

           TCD_CadTipoTransporte cd = new TCD_CadTipoTransporte();
           return cd.Select(vBusca, 0, "");
       }
       public static string GravaCadTipoTransporte(TRegistro_CadTipoTransporte val)
       {
           TCD_CadTipoTransporte cd = new TCD_CadTipoTransporte();
           return cd.GravaCadTipoTranporte(val);
       }
       public static string DeletaCadTipoTransporte(TRegistro_CadTipoTransporte val)
       {
           TCD_CadTipoTransporte cd = new TCD_CadTipoTransporte();
           return cd.DeletaCadTipoTransporte(val);
       }

    }
}
