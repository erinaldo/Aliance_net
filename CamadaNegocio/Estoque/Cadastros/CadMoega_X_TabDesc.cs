using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadMoega_X_TabDesc
    {
            public static TList_CadMoega_X_TabDesc Busca(string vCD_Moega,
                                                         string vCD_TabelaDesconto,
                                                         string vST_Registro)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Moega.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Moega";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Moega + "'";
            }

            if (vCD_TabelaDesconto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_tabelaDesconto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto + "'";
            }

           if (vST_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro + "'";
            }


           TCD_CadMoega_X_TabDesc cd = new TCD_CadMoega_X_TabDesc();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava_CadMoega_X_TabDesc(TRegistro_CadMoega_X_TabDesc val)
        {
            TCD_CadMoega_X_TabDesc cd = new TCD_CadMoega_X_TabDesc();
            return cd.Grava(val);
        }

        public static void Deleta_CadMoega_X_TabDesc(TRegistro_CadMoega_X_TabDesc val)
        {
            TCD_CadMoega_X_TabDesc cd = new TCD_CadMoega_X_TabDesc();
            cd.Deleta(val);

        }
    }
} 