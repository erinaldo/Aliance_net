using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_LanFechamentoOperacao
    {
        public static TList_CadContratoHeadge BuscarContrato(decimal vNr_Contrato,
                                                             string vCD_Empresa,
                                                             string vAnoSafra,
                                                             decimal vNr_Pedido,
                                                             string vCD_Produto,
                                                             string vCD_Clifor)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vNr_Contrato > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vAnoSafra.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.AnoSafra";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vAnoSafra + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_Pedido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.Nr_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCD_Clifor.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_LanFechamentoOperacao().SelectContrato(filtro);
        }

        public static TList_CadNotaFiscalHeadge BuscarNotaFiscal(decimal vNr_Contrato,
                                                                 decimal vNR_LanctoFiscal)
        {

            TpBusca[] filtro = new TpBusca[0];

            if ((vNr_Contrato > 0))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.Nr_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vNR_LanctoFiscal > 0))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                filtro[filtro.Length - 1].vVL_Busca = vNR_LanctoFiscal + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_LanFechamentoOperacao().SelectNotaFiscal(filtro);
        }

        public static TList_CadNotaFiscalHeadge BuscarNotaFiscalEntrada(string vCD_Empresa,
                                                                        decimal vNR_LanctoFiscal,
                                                                        decimal vID_NFItem)
        {

            TpBusca[] filtro = new TpBusca[0];

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vNR_LanctoFiscal > 0))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.NR_LanctoFiscal";
                filtro[filtro.Length - 1].vVL_Busca = vNR_LanctoFiscal + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if ((vID_NFItem > 0))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.ID_NFItem";
                filtro[filtro.Length - 1].vVL_Busca = vID_NFItem + "";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_LanFechamentoOperacao().SelectNotaFiscalEntrada(filtro);
        }
    }
}
