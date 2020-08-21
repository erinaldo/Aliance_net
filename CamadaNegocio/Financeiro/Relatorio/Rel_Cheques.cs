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
    public static class TCN_Rel_Cheques
    {
        public static DataTable Buscar(string vDataInicial,
                                       string vDataFinal,
                                       string vDatas,
                                       string vTP_Conta,
                                       string vCD_Empresa,
                                       string vCD_Banco,
                                       bool vCompensadas,
                                       short vTop,
                                       string vNM_Campo,
                                       string vGroup,
                                       string vOrder,
                                       Hashtable vParametros
            )
        {
            TpBusca[] vBusca = new TpBusca[0];

            if ((vDataInicial.Trim() != "/  /") && (vDataFinal.Trim() != "/  /"))
            {
                if (vDatas.Trim() == "V")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Vencto"; ;
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDataInicial + "' and '" + vDataFinal + "'";
                    vBusca[vBusca.Length - 1].vOperador = "between";
                }

                if (vDatas.Trim() == "E")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao"; ;
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDataInicial + "' and '" + vDataFinal + "'";
                    vBusca[vBusca.Length - 1].vOperador = "between";
                }

                if (vDatas.Trim() == "C")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Compensacao";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDataInicial + "' and '" + vDataFinal + "'";
                    vBusca[vBusca.Length - 1].vOperador = "between";
                }
            }


            if ((vTP_Conta.Trim() != "T") && (vTP_Conta.Trim() != ""))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Conta + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCD_Banco.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Banco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Banco + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCompensadas == true)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Banco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Banco + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }


            TCD_Rel_Cheques qtb_Cheques = new TCD_Rel_Cheques();
            return qtb_Cheques.Buscar(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros);
        }
    }

}
