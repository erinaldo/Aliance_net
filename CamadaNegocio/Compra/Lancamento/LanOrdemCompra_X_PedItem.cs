using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_OrdemCompra_X_PedItem
    {
        public static TList_OrdemCompra_X_PedItem Buscar(string Id_oc,
                                                         string Nr_pedido,
                                                         string Id_pedidoitem,
                                                         int vTop,
                                                         string vNm_campo,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if(Id_oc.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_oc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_oc;
            }
            if(Nr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if(Id_pedidoitem.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }
            return new TCD_OrdemCompra_X_PedItem(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarOC_X_PedItem(TRegistro_OrdemCompra_X_PedItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra_X_PedItem qtb_oc = new TCD_OrdemCompra_X_PedItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_oc.CriarBanco_Dados(true);
                else
                    qtb_oc.Banco_Dados = banco;
                string retorno = qtb_oc.GravarOC_XPedItem(val);
                if (st_transacao)
                    qtb_oc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_oc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_oc.deletarBanco_Dados();
            }
        }

        public static string DeletarOC_X_PedItem(TRegistro_OrdemCompra_X_PedItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra_X_PedItem qtb_oc = new TCD_OrdemCompra_X_PedItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_oc.CriarBanco_Dados(true);
                else
                    qtb_oc.Banco_Dados = banco;
                qtb_oc.DeletarOC_X_PedItem(val);
                if (st_transacao)
                    qtb_oc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_oc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_oc.deletarBanco_Dados();
            }
        }
    }
}
