using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils; 

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadEmpresa_X_Moega 
    {
        public static TList_CadEmpresa_X_Moega Busca(string vCD_Moega,
                                                      string vCD_Empresa,
                                                      string vST_Registro)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Moega.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Moega";
                vBusca[vBusca.Length - 1].vOperador = " = ";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Moega + "'";
            }
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = " = ";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
            };
            if (vST_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = " = ";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro + "'";
            };

            TCD_CadEmpresa_X_Moega cd = new TCD_CadEmpresa_X_Moega ();
            return cd.Select (vBusca,0, "");
        }
        public static string Grava_CadEmpresa_X_Moega(TRegistro_CadEmpresa_X_Moega val)
        {
            TCD_CadEmpresa_X_Moega cd = new TCD_CadEmpresa_X_Moega ();
            return cd.Grava(val);
        }
      
        public static void Deleta_CadEmpresa_X_Moega(TRegistro_CadEmpresa_X_Moega val)
        {
            TCD_CadEmpresa_X_Moega cd = new TCD_CadEmpresa_X_Moega ();
            cd.Deleta(val);
        }
    }
}

