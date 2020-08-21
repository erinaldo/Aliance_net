using System;
using System.Collections.Generic;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;
using BancoDados;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido_Fiscal
    {
        public static TList_RegLanPedidoFiscal Busca(decimal vNr_Pedido,
                                                     string vTp_fiscal)
        {
            
            TpBusca[] filtro = new TpBusca[0];
            if (vNr_Pedido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido.ToString();
            }
            if (vTp_fiscal.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Fiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_fiscal.Trim() + "'";
            }

            TCD_LanPedido_Fiscal cd = new TCD_LanPedido_Fiscal();
            return cd.Select(filtro, 0, string.Empty);
        }
        public static string GravaPedido_Fiscal(TRegistro_LanPedidoFiscal val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Fiscal qtb_Pedido_Fiscal = new TCD_LanPedido_Fiscal();
            try
            {
                if (banco == null)
                {
                    qtb_Pedido_Fiscal.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Pedido_Fiscal.Banco_Dados = banco;

                string retorno = qtb_Pedido_Fiscal.Grava(val);
                if (st_transacao)
                    qtb_Pedido_Fiscal.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_Fiscal.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_Fiscal.deletarBanco_Dados();
            }
        }
        public static string DeletaPedido_Fiscal(TRegistro_LanPedidoFiscal val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPedido_Fiscal qtb_Pedido_Fiscal = new TCD_LanPedido_Fiscal();
            try
            {
                if (banco == null)
                {
                    qtb_Pedido_Fiscal.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Pedido_Fiscal.Banco_Dados = banco;

                string retorno = qtb_Pedido_Fiscal.Deleta(val);
                if (st_transacao)
                    qtb_Pedido_Fiscal.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_Fiscal.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_Fiscal.deletarBanco_Dados();
            }  
        }

    }
}
