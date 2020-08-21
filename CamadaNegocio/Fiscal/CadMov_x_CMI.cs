using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadMov_x_CMI
    {
        public static TList_CadMov_x_CMI Busca(decimal vcd_movimentacao, decimal vcd_cmi, string vst_registro)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if(vcd_movimentacao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_movimentacao";
                vBusca[vBusca.Length - 1].vVL_Busca = vcd_movimentacao.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if(vcd_cmi > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_cmi";
                vBusca[vBusca.Length - 1].vVL_Busca = vcd_cmi.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if(vst_registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.st_registro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vst_registro + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_CadMov_x_CMI movCMI = new TCD_CadMov_x_CMI();
            return movCMI.Select(vBusca, 0, "");
       } 
       public static string GravarMovCMI(TRegistro_CadMov_x_CMI val)
       {
            TCD_CadMov_x_CMI movCMI = new TCD_CadMov_x_CMI();
            return movCMI.GravarMovCMI(val);
       }
       public static string DeletarMovCMI(TRegistro_CadMov_x_CMI val)
       {
            TCD_CadMov_x_CMI movCMI = new TCD_CadMov_x_CMI();
            return movCMI.DeletarMovCMI(val);
       }
    }
}