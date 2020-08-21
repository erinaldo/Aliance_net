using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_Taxa_X_PedidoItem
    {
        public static TList_Taxa_X_PedidoItem Buscar(string Id_lantaxa,
                                                     string Nr_pedido,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_lantaxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lantaxa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lantaxa;
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            return new TCD_Taxa_X_PedidoItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Taxa_X_PedidoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Taxa_X_PedidoItem qtb_taxa = new TCD_Taxa_X_PedidoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                string retorno = qtb_taxa.Gravar(val);
                if (st_transacao)
                    qtb_taxa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar taxa x pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Taxa_X_PedidoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Taxa_X_PedidoItem qtb_taxa = new TCD_Taxa_X_PedidoItem();
            try
            {
                if(banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                qtb_taxa.Excluir(val);
                if(st_transacao)
                    qtb_taxa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir taxa x pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }
    }
}
