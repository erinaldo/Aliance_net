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
    public class TCN_Cad_Operador
    {
        public static TList_Cad_Operador Busca(decimal vID_Operador, string vNM_Operador, string vSigla_Operador)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Operador > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_operador";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Operador.ToString() + "'";
            }
            if (vNM_Operador.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_Operador";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_Operador.Replace("'", "''") + "%'";
            }
            if (vSigla_Operador.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Sigla_Operador";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vSigla_Operador.Replace("'", "''") + "%'";
            }

            TCD_Cad_Operador cd = new TCD_Cad_Operador();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaOperador(TRegistro_Cad_Operador val)
        {
            TCD_Cad_Operador cd = new TCD_Cad_Operador();
            return cd.Grava(val);

        }

        public static string DeletaOperador(TRegistro_Cad_Operador val)
        {
            TCD_Cad_Operador CD = new TCD_Cad_Operador();
            return CD.Deleta(val);
        }
    }
}
