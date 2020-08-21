using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;
using BancoDados;


namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanDadosPedido
    {
        public static TList_LanDadosPedido Busca(decimal vNr_Pedido)
        {
            TCD_LanDadosPedido cd = new TCD_LanDadosPedido();
            TpBusca[] filtro = new TpBusca[1];

            filtro[0].vNM_Campo = "a.Nr_Pedido";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = vNr_Pedido.ToString();

            return cd.Select(filtro, 0, "");
        }
        public static string GravaPedido_Dados(TRegistro_LanDadosPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanDadosPedido qtb_Pedido_Dados = new TCD_LanDadosPedido();
            try
            {
                if (banco == null)
                {
                    qtb_Pedido_Dados.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Pedido_Dados.Banco_Dados = banco;

                string retorno = qtb_Pedido_Dados.GravarDadosPedido(val);
                if (st_transacao)
                    qtb_Pedido_Dados.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Pedido_Dados.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Pedido_Dados.deletarBanco_Dados();
            }
        }
        public static void DeletaPedido_Dados(TRegistro_LanDadosPedido val)
        {
            TCD_LanDadosPedido cd = new TCD_LanDadosPedido();
            cd.DeletarDadosPedido(val);
        }

    }
}
