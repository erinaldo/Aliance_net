/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Campo
    {
        public static TList_Cad_Campo Busca(decimal vID_Campo, string vID_Consulta, string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Campo > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_Campo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Campo.ToString() + "'";
            }
            if (vNM_Campo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Campo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_Campo + "%'";
            }
            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta + "'";
            }

            TCD_Cad_Campo cd = new TCD_Cad_Campo();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaCampo(TRegistro_Cad_Campo val)
        {
            TCD_Cad_Campo cd = new TCD_Cad_Campo();
            return cd.Grava(val);

        }

        public static string DeletaCampo(TRegistro_Cad_Campo val)
        {
            TCD_Cad_Campo CD = new TCD_Cad_Campo();
            return CD.Deleta(val);
        }

        public static string DeletaTodosCampo(string vID_Consulta)
        {
            TCD_Cad_Campo CD = new TCD_Cad_Campo();
            return CD.DeletaTodos(vID_Consulta);
        }
    }
}
