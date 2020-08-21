using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadMoega
    {
        public static TList_CadMoega Busca(string vCD_Moega,
                                           string vDS_Moega,
                                           string vST_Registro)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Moega.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Moega";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Moega + "'";
            };

            if (vDS_Moega.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Moega";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Moega + "%')";
            };

            if (vST_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro + "'";
            };

            TCD_CadMoega cd = new TCD_CadMoega();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava_CadMoega(TRegistro_CadMoega val)
        {
            TCD_CadMoega cd = new TCD_CadMoega();
            return cd.Grava(val);
        }

        public static void Deleta_CadMoega(TRegistro_CadMoega val)
        {
            TCD_CadMoega cd = new TCD_CadMoega();
            cd.Deleta(val);

        }

    }
}
