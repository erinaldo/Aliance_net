using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadHeadge
    {


        public static TList_CadHeadge Busca(decimal vID_Headge,
                                             string vDS_Headge,
                                             string vTP_Headge)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vID_Headge > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Headge";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Headge.ToString() + "'";
            }

            if (vDS_Headge.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Headge";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Headge + "%')";
            }

            if (vTP_Headge.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Headge";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Headge + "'";
            }

            TCD_CadHeadge cd = new TCD_CadHeadge();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava_CadHeadge(TRegistro_CadHeadge val)
        {
            TCD_CadHeadge cd = new TCD_CadHeadge();
            return cd.Grava(val);
        }

        public static void Deleta_CadHeadge(TRegistro_CadHeadge val)
        {
            TCD_CadHeadge cd = new TCD_CadHeadge();
            cd.Deleta(val);
        }

        
    }
}

