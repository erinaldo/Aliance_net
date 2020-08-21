using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFaturamentoMovFiscal_Pedido
    {
        public static TList_RegLanFaturamentoMovFiscal_Pedido Busca(decimal vNR_LanctoFiscal,
                                                                    string vCD_Empresa,
                                                                    decimal vID_NfItem,
                                                                    decimal vNR_Pedido,
                                                                    string vCD_Produto,
                                                                    string vTP_Movimento,
                                                                    int vTop,
                                                                    string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vNR_LanctoFiscal > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_NfItem > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_NfItem";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_NfItem.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Pedido > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_Movimento.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_LanFaturamentoMovFiscal_Pedido qtb_movfiscal = new TCD_LanFaturamentoMovFiscal_Pedido();
            return qtb_movfiscal.Select(vBusca, vTop, vNM_Campo);
        }

        public static string GravaMovFiscal_Pedido(TList_RegLanFaturamentoMovFiscal_Pedido val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = string.Empty;
                for (int i = 0; i < val.Count; i++)
                    retorno += GravaMovFiscal_Pedido(val[i], banco);
                return retorno;
            }
            else
                return string.Empty;
        }
        
        public static string GravaMovFiscal_Pedido(TRegistro_LanFaturamentoMovFiscal_Pedido val, TObjetoBanco banco)
        {
            TCD_LanFaturamentoMovFiscal_Pedido qtb_movfiscal = new TCD_LanFaturamentoMovFiscal_Pedido();
            qtb_movfiscal.Banco_Dados = banco;
            return qtb_movfiscal.GravaMovFiscal_Pedido(val);
        }

        public static string DeletaFaturamentoCMI(TRegistro_LanFaturamentoMovFiscal_Pedido val, TObjetoBanco banco)
        {
            TCD_LanFaturamentoMovFiscal_Pedido qtb_movfiscal = new TCD_LanFaturamentoMovFiscal_Pedido();
            qtb_movfiscal.Banco_Dados = banco;
            return qtb_movfiscal.DeletaMovFiscal_Pedido(val);
        }
    }
}
