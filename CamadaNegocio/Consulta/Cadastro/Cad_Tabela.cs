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
    #region "Tabela"
        public class TCN_Cad_Tabela
        {
            public static TList_Cad_Tabela Busca()
            {
                TCD_Cad_Tabela cd = new TCD_Cad_Tabela();
                return cd.Select();
            }
        }
    #endregion

    #region "Campo"
        public class TCN_Cad_Campo_Tabela
        {
            public static TList_Cad_Campo_Tabela Busca(string vNM_Tabela, string vID_Consulta)
            {
                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "so.Name";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNM_Tabela + "'";

                TCD_Cad_Campo_Tabela cd = new TCD_Cad_Campo_Tabela();
                return cd.Select(vBusca, 0, vID_Consulta.ToString());
            }
        }
    #endregion

    #region "Foreign_Key"

        public class TCN_Cad_Foreign_Key
        {
            public static TList_Cad_Foreign_Key Busca(string vNM_Campo_Base, string vNM_Campo_Estrangeiro, decimal vID_Consulta)
            {
                TpBusca[] filtro = new TpBusca[0];

                if (vNM_Campo_Base.Trim().Length > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "c.name";
                    filtro[filtro.Length - 1].vVL_Busca = "" + vNM_Campo_Base.Trim() + "";
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                if (vNM_Campo_Estrangeiro.Trim().Length > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "p.name";
                    filtro[filtro.Length - 1].vVL_Busca = "" + vNM_Campo_Estrangeiro.Trim() + "";
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                TCD_Cad_Foreign_Key cd = new TCD_Cad_Foreign_Key();
                return cd.Select(filtro, 0, vID_Consulta.ToString());
            }
        }
    
    #endregion
}