using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CadCFGPedidoFiscal
    {
        public static TList_CadCFGPedidoFiscal Buscar(string vCfg_pedido,
                                                      string vTp_fiscal,
                                                      string vNr_serie,
                                                      decimal vCd_cmi,
                                                      decimal vCd_movto,
                                                      int vTop,
                                                      string vNm_campo,
                                                      TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vCfg_pedido.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCfg_pedido.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vTp_fiscal.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Fiscal";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_fiscal.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vNr_serie.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_Serie";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_serie.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_cmi > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CMI";
                filtro[filtro.Length - 1].vVL_Busca = vCd_cmi.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_movto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Movto";
                filtro[filtro.Length - 1].vVL_Busca = vCd_movto.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_CadCFGPedidoFiscal(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadCFGPedidoFiscal val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFGPedidoFiscal qtb_cfg = new TCD_CadCFGPedidoFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;

                string retorno = qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração fiscal pedido: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadCFGPedidoFiscal val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFGPedidoFiscal qtb_cfg = new TCD_CadCFGPedidoFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração fiscal pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
