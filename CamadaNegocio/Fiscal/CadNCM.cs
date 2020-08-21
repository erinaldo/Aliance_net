using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;



namespace CamadaNegocio.Fiscal
{

    public class TCN_CadNCM
    {
        public static TList_CadNCM Busca(String NCM, 
                                         String Ds_NCM, 
                                         decimal Pc_Aliquota)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (NCM.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = " a.NCM ";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + NCM.Replace("'", "''") + "'";
                vBusca[vBusca.Length - 1].vOperador = " = ";
            }
            if (Ds_NCM.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_NCM";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + Ds_NCM.Replace("'", "''") + "%'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (Pc_Aliquota>0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.PC_ALIQUOTA";
                vBusca[vBusca.Length - 1].vVL_Busca = "" + Pc_Aliquota.ToString().Replace(",",".") + "";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            
            return new TCD_CadNCM().Select(vBusca, 0, "");
        }
        public static string GravarNCM(TRegistro_CadNCM val)
        {
            return new TCD_CadNCM().GravarNCM(val);
        }
        public static string DeletarNCM(TRegistro_CadNCM val)
        {
            return new TCD_CadNCM().DeletarNCM(val);
        }
    }
}
