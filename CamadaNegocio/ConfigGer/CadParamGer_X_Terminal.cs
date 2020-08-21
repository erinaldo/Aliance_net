using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using CamadaDados.ConfigGer;

namespace CamadaNegocio.ConfigGer
{
    public class TCN_CadParamGer_X_Terminal
    {
        public static TList_RegParamGer_X_Terminal Busca(string vID_Parametro,
                                              string vCD_Terminal,
                                              int vTop,
                                              string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if ((vID_Parametro.Trim() != "")&&(vID_Parametro.Trim() != "0"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Parametro";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Parametro;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Terminal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Terminal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Terminal.Replace("'", "''") + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_ParamGer_X_Terminal qtb_param = new TCD_ParamGer_X_Terminal();
            return qtb_param.Select(vBusca, vTop, vNM_Campo);
        }
    

        public static string GravaParamGer_X_Terminal(TRegistro_ParamGer_X_Terminal val)
        {
            TCD_ParamGer_X_Terminal qtb_param = new TCD_ParamGer_X_Terminal();
            return qtb_param.GravarParamGer(val);           
        }

        public static string DeletaParamGer(TRegistro_ParamGer_X_Terminal val)
        {
            TCD_ParamGer_X_Terminal qtb_param = new TCD_ParamGer_X_Terminal();
            return qtb_param.DeletarParamGer(val);
        }
    }
}
