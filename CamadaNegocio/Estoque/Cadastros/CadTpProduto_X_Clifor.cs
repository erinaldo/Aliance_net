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
    public class TCN_CadTpProduto_X_Clifor
    {
        public static TList_CadTpProduto_X_Clifor Busca(string vCD_Clifor,
                                                        string vTp_Produto)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (vCD_Clifor.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
            };

            if (vTp_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_Produto + "'";
            };

            TCD_CadTpProduto_X_Clifor cd = new TCD_CadTpProduto_X_Clifor();
            return cd.Select(vBusca, 0, "");

        }

        public static string Grava_CadTpProduto_X_Clifor(TRegistro_CadTpProduto_X_Clifor val)
        {
            TCD_CadTpProduto_X_Clifor cd = new TCD_CadTpProduto_X_Clifor();
            return cd.Grava(val);
        }

        public static string Deleta_CadTpProduto_X_Clifor(TRegistro_CadTpProduto_X_Clifor val)
        {
            TCD_CadTpProduto_X_Clifor cd = new TCD_CadTpProduto_X_Clifor();
            return cd.Deleta(val);
        }
    }
}
