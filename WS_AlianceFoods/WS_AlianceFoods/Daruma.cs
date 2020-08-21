using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace WS_AlianceFoods
{
    public class TDaruma
    {
        [DllImport("DarumaFrameWork.dll")]
        public static extern int regAlterarValor_Daruma(string pszChave, string pszValor);
        [DllImport("DarumaFrameWork.dll")]
        public static extern int regPortaComunicacao_DUAL_DarumaFramework(System.String stParametro);
        [DllImport("DarumaFrameWork.dll")]
        public static extern int iImprimirTexto_DUAL_DarumaFramework(string stTexto, int iTam);
        [DllImport("DarumaFrameWork.dll")]
        public static extern int rConsultaStatusImpressora_DUAL_DarumaFramework(string stIndice, string stTipoRetorno, System.Text.StringBuilder rRetorno);
        [DllImport("DarumaFrameWork.dll")]
        public static extern int rStatusImpressora_DUAL_DarumaFramework();
    }
}
