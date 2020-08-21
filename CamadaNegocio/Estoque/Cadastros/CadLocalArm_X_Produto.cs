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
    public class TCN_CadLocalArm_X_Produto
    {
        public static TList_CadLocalArm_X_Produto Busca(string vCD_Local,
                                                        string vCD_Produto
                                                        )
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Local.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Local + "'";
            };

            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
            };
            TCD_CadLocalArm_X_Produto cd = new TCD_CadLocalArm_X_Produto();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava_CadLocalArm_X_Produto(TRegistro_CadLocalArm_X_Produto val)
        {
            TCD_CadLocalArm_X_Produto cd = new TCD_CadLocalArm_X_Produto();
            return cd.Grava(val);
        }

        public static void Deleta_CadLocalArm_X_Produto(TRegistro_CadLocalArm_X_Produto val)
        {
            TCD_CadLocalArm_X_Produto cd = new TCD_CadLocalArm_X_Produto();
            cd.Deleta(val);

        }
    }
}
