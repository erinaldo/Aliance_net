using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadCondFiscalClifor
    {
        public static TList_CadConFiscalClifor Busca(string Cd_condFiscal_clifor, string Ds_condFiscal, string st_registro)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (Cd_condFiscal_clifor.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "Cd_condFiscal_clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_condFiscal_clifor + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (Ds_condFiscal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "Ds_condFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Ds_condFiscal + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (st_registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "St_Registro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + st_registro + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_CadConFiscalClifor fiscalClifor = new TCD_CadConFiscalClifor();
            return fiscalClifor.Select(vBusca, 0, "");
        }
        
        public static string GravarFiscalClifor(TRegistro_CadCondFiscalClifor val)
        {
            TCD_CadConFiscalClifor fiscalClifor = new TCD_CadConFiscalClifor();
            return fiscalClifor.GravarConFisc(val);
        }
        
        public static string DeletarFiscalClifor(TRegistro_CadCondFiscalClifor val)
        {
            TCD_CadConFiscalClifor fiscalClifor = new TCD_CadConFiscalClifor();
            return fiscalClifor.DeletarConFisc(val);
        }
    }
}
