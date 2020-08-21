using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadTbPreco
    {
        public static TList_CadTbPreco Busca(string vCD_TabelaPreco, 
                                             string vDS_TabelaPreco, 
                                             string vST_Registro)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_TabelaPreco.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaPreco + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vDS_TabelaPreco.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_TabelaPreco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_TabelaPreco + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vST_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ST_Registro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_CadTbPreco cadPreco = new TCD_CadTbPreco();
            return cadPreco.Select(vBusca, 0, "");
        }

        public static string GravarTbPreco(TRegistro_CadTbPreco val)
        {
            TCD_CadTbPreco cadPreco = new TCD_CadTbPreco();
            return cadPreco.GravarPreco(val);
        }

        public static string DeletarTbPreco(TRegistro_CadTbPreco val)
        {
            TCD_CadTbPreco cadPreco = new TCD_CadTbPreco();
            return cadPreco.DeletarPreco(val);
        }
    }
}
