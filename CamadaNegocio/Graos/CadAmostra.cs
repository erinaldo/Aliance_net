using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CadAmostra
    {

    
        public static TList_CadAmostra Busca(string vCD_TipoAmostra,
                                             string vDS_Amostra,
                                             string vOrdem)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_TipoAmostra.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TipoAmostra";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TipoAmostra + "'";
            }

            if (vDS_Amostra.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Amostra";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Amostra + "%')";
            }

            if (vOrdem.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Ordem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vOrdem + "'";
            }

            TCD_CadAmostra cd = new TCD_CadAmostra();
            return cd.Select(vBusca,0,"");
        }

        public static string Grava_CadAmostra(TRegistro_CadAmostra val)
        {
            TCD_CadAmostra cd = new TCD_CadAmostra();
            return cd.Grava(val);
        }

        public static void Deleta_CadAmostra(TRegistro_CadAmostra val)
        {
            TCD_CadAmostra cd = new TCD_CadAmostra();
            cd.Deleta(val);
        }

        public static TList_CadAmostra Busca(string p, string p_2, bool p_3)
        {
            throw new NotImplementedException();
        }
    }
}

