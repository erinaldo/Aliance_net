using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CadCFGPedido
    {
        public static TList_CadCFGPedido Buscar(string vCfg_pedidoString,
                                                string vDs_tipopedido,
                                                string vTp_movimento,
                                                string vSt_deposito,
                                                string vSt_confere_saldo,
                                                string vSt_valoresfixos,
                                                string vSt_permite_pedidoparcial,
                                                string vSt_permitetransf,
                                                string vSt_comissaoped,
                                                string vSt_comissaofat,
                                                string vSt_servico,
                                                decimal vNr_pedido,
                                                int vTop,
                                                string vNm_campo,
                                                
                                                TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCfg_pedidoString))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCfg_pedidoString + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_tipopedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_TipoPedido";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_tipopedido.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vTp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Movimento";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_movimento.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_deposito))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_Deposito, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_deposito.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_confere_saldo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_Confere_Saldo, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_confere_saldo.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_valoresfixos))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_ValoresFixos, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_valoresfixos.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_permite_pedidoparcial))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_Permite_PedidoParcial, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_permite_pedidoparcial.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_permitetransf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_PermiteTransf, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_permitetransf.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_comissaoped))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_ComissaoPed, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_comissaoped.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_comissaofat))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_ComissaoFat, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_comissaofat.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vSt_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isNull(a.ST_Servico, 'N')";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vSt_servico.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
           
           
            if (vNr_pedido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                      "where x.cfg_pedido = a.cfg_pedido " +
                                                      "and x.nr_pedido = " + vNr_pedido.ToString() + ")";
                filtro[filtro.Length - 1].vOperador = "EXISTS";
            }

            return new TCD_CadCFGPedido(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TRegistro_CadCFGPedido BuscarRegistro(string vCfg_pedidoString,
                                                            string vDs_tipopedido,
                                                            string vTp_movimento,
                                                            string vSt_deposito,
                                                            string vSt_confere_saldo,
                                                            string vSt_valoresfixos,
                                                            string vSt_permite_pedidoparcial,
                                                            string vSt_permitetransf,
                                                            string vSt_comissaoped,
                                                            string vSt_comissaofat,
                                                            string vSt_servico,                                                            
                                                            decimal vNr_pedido,
                                                            int vTop,
                                                            string vNm_campo,
                                                            TObjetoBanco banco)
        {
            TList_CadCFGPedido lCfg = Buscar(vCfg_pedidoString, 
                                             vDs_tipopedido, 
                                             vTp_movimento, 
                                             vSt_deposito,
                                             vSt_confere_saldo, 
                                             vSt_valoresfixos, 
                                             vSt_permite_pedidoparcial,
                                             vSt_permitetransf, 
                                             vSt_comissaoped, 
                                             vSt_comissaofat,
                                             vSt_servico,
                                             vNr_pedido, 
                                             vTop, 
                                             vNm_campo, 
                                             banco);
            return lCfg.Count > 0 ? lCfg[0] : null;
        }

        public static string Gravar(TRegistro_CadCFGPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFGPedido qtb_cfgpedido = new TCD_CadCFGPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfgpedido.CriarBanco_Dados(true);
                else
                    qtb_cfgpedido.Banco_Dados = banco;
                string retorno = qtb_cfgpedido.Gravar(val);
                if (st_transacao)
                    qtb_cfgpedido.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_cfgpedido.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cfgpedido.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadCFGPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadCFGPedido qtb_cfgpedido = new TCD_CadCFGPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfgpedido.CriarBanco_Dados(true);
                else
                    qtb_cfgpedido.Banco_Dados = banco;
                qtb_cfgpedido.Excluir(val);
                if (st_transacao)
                    qtb_cfgpedido.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_cfgpedido.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cfgpedido.deletarBanco_Dados();
            }
        }
    }
}
