using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadObservacaoFiscal
    {
        public static TList_CadObservacaoFiscal Busca(string CD_ObservacaoFiscal, string DS_ObservacaoFiscal, string ST_Registro)
        {
            TpBusca[] vBusca = new TpBusca[0];
            
            if (CD_ObservacaoFiscal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_ObservacaoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_ObservacaoFiscal + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            
            if (DS_ObservacaoFiscal.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_ObservacaoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DS_ObservacaoFiscal + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (ST_Registro.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ST_Registro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ST_Registro + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_CadObservacaoFiscal ob = new TCD_CadObservacaoFiscal();
            return ob.Select(vBusca, 0, "");
        }

        public static string gravarObFiscal(TRegistro_CadObservacaoFiscal val)
        {
            TCD_CadObservacaoFiscal ob = new TCD_CadObservacaoFiscal();
            return ob.gravarObFiscal(val);
        }

        public static string deletarObFiscal(TRegistro_CadObservacaoFiscal val)
        {
            TCD_CadObservacaoFiscal ob = new TCD_CadObservacaoFiscal();
            return ob.deletarObFiscal(val);
        }
    }
}
