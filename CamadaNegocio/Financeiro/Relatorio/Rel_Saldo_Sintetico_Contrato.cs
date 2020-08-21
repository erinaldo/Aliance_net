using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using CamadaDados.Financeiro.Relatorio;
using System.Collections;

namespace CamadaNegocio.Financeiro.Relatorio
{
    public static class TCN_Rel_Saldo_Sintetico_Contrato
    {
        public static DataTable Buscar(string vCD_Empresa,
                                       string vNR_Contrato,
                                       short vTop,
                                       string vNM_Campo,
                                       string vGroup,
                                       string vOrder,
                                       Hashtable vParametros
            )
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vNR_Contrato.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Contrato";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Contrato + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            
            TCD_Rel_Saldo_Sintetico_Contrato qtb_Saldo_Sintetico_Contrato = new TCD_Rel_Saldo_Sintetico_Contrato("SqlCodeBusca_Saldo_Sintetico_Contrato");
            return qtb_Saldo_Sintetico_Contrato.Buscar(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros);
        }
    }
}
