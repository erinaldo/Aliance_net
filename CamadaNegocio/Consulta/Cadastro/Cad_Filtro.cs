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
    public class TCN_Cad_Filtro
    {
        public static TList_Cad_Filtro Busca(decimal vID_Filtro, string vID_Consulta, string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Filtro > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_Filtro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Filtro.ToString() + "'";
            }
            if (vID_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
            }
            if (vNM_Campo.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Campo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_Campo + "%'";
            }

            TCD_Cad_Filtro cd = new TCD_Cad_Filtro();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaFiltro(TRegistro_Cad_Filtro val)
        {
            TCD_Cad_Filtro cd = new TCD_Cad_Filtro();
            return cd.Grava(val);

        }

        public static string DeletaFiltro(TRegistro_Cad_Filtro val)
        {
            TCD_Cad_Filtro CD = new TCD_Cad_Filtro();
            return CD.Deleta(val);
        }
    }
}
