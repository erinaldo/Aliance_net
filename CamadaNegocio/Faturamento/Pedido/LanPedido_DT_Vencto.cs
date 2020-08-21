using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;
using BancoDados;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanPedido_DT_Vencto
    {
        public static TList_Pedido_DT_Vencto Busca(decimal vNr_Pedido, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "a.Nr_Pedido";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = vNr_Pedido.ToString();

            return new TCD_Pedido_DT_Vencto(banco).Select(filtro, 0, "");
        }

        public static string Gravar(TRegistro_Pedido_DT_Vencto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido_DT_Vencto qtb_Pedido_DTVencto = new TCD_Pedido_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Pedido_DTVencto.CriarBanco_Dados(true);
                else qtb_Pedido_DTVencto.Banco_Dados = banco;

                string retorno = qtb_Pedido_DTVencto.Gravar(val);
                if (st_transacao)
                    qtb_Pedido_DTVencto.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_DTVencto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar financeiro pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_DTVencto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pedido_DT_Vencto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido_DT_Vencto qtb_Pedido_DTVencto = new TCD_Pedido_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Pedido_DTVencto.CriarBanco_Dados(true);
                else qtb_Pedido_DTVencto.Banco_Dados = banco;

                qtb_Pedido_DTVencto.Excluir(val);
                if (st_transacao)
                    qtb_Pedido_DTVencto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_DTVencto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir financeiro pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_DTVencto.deletarBanco_Dados();
            }
        }
    }
}
