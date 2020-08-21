using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFat_ComplementoDevolucao
    {
        public static List<TRegistro_NFCompDev> Buscar(string vCD_Empresa,
                                                       string vNR_Pedido,
                                                       string vCD_Produto,
                                                       string vCD_Clifor,
                                                       string vTP_Movimento,
                                                       string vTP_Operacao,
                                                       bool vSt_devContratoFixar,
                                                       short vTop,
                                                       string vNM_Campo,
                                                       TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Pedido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vSt_devContratoFixar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "not exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_GRO_Fixacao_NF x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal)";
            }
            if(!string.IsNullOrEmpty(vTP_Operacao))
                if (vTP_Operacao.Trim().ToUpper().Equals("D"))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                    vBusca[vBusca.Length - 1].vOperador = string.Empty;
                    vBusca[vBusca.Length - 1].vVL_Busca = "((a.quantidade - a.qtd_devolvido - a.qtd_fixacao > 0) or (a.vl_subtotal - a.vl_devolvido - a.vl_fixacao > 0))";
                }
                else if (vTP_Operacao.Trim().ToUpper().Equals("E"))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 2);
                    vBusca[vBusca.Length - 2].vNM_Campo = "isnull(d.ST_Mestra, 'N')";
                    vBusca[vBusca.Length - 2].vOperador = "=";
                    vBusca[vBusca.Length - 2].vVL_Busca = "'S'";

                    vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                    vBusca[vBusca.Length - 1].vOperador = string.Empty;
                    vBusca[vBusca.Length - 1].vVL_Busca = "((a.quantidade - a.QTD_EntregaFutura > 0) or (a.vl_subtotal - a.Vl_EntregaFutura > 0))";
                }
            return new TCD_LanFat_ComplementoDevolucao(banco).SelectNFCompDev(vBusca);
        }

        public static TList_LanFat_ComplementoDevolucao Buscar(string vCD_Empresa,
                                                               string vNR_LanctoFiscal_Origem,
                                                               string vID_NFItem_Origem,
                                                               string vNR_LanctoFiscal_Destino,
                                                               string vID_NFItem_Destino,
                                                               string vTP_Operacao,
                                                               decimal vQtd_Lancto,
                                                               decimal vVl_lancto,
                                                               short vTop,
                                                               string vNM_Campo,
                                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_LanctoFiscal_Origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_LanctoFiscal_Origem";
                filtro[filtro.Length - 1].vVL_Busca = vNR_LanctoFiscal_Origem;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vID_NFItem_Origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFItem_Origem";
                filtro[filtro.Length - 1].vVL_Busca = vID_NFItem_Origem;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_LanctoFiscal_Destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_LanctoFiscal_Destino";
                filtro[filtro.Length - 1].vVL_Busca = vNR_LanctoFiscal_Destino;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vID_NFItem_Destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_NFItem_Destino";
                filtro[filtro.Length - 1].vVL_Busca = vID_NFItem_Destino;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Operacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Operacao";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTP_Operacao.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vQtd_Lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.QTD_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = vQtd_Lancto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = vVl_lancto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_LanFat_ComplementoDevolucao(banco).Select(filtro, 0, string.Empty);
        }
        
        public static string Gravar(TRegistro_LanFat_ComplementoDevolucao val, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            bool pode_liberar = false;
            TCD_LanFat_ComplementoDevolucao qtb_comdev = new TCD_LanFat_ComplementoDevolucao();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_comdev.CriarBanco_Dados(true);
                else
                    qtb_comdev.Banco_Dados = banco;
                retorno = qtb_comdev.Gravar(val);
                if (pode_liberar)
                    qtb_comdev.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_comdev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar complemento/devolução/entrega futura: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_comdev.deletarBanco_Dados();
            }
        }
    }
}
