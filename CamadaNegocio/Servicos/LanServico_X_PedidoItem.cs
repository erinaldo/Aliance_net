using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public static class TCN_Servico_X_PedidoItem
    {
        public static TList_Servico_X_PedidoItem Buscar(string Id_os,
                                                        string Cd_empresa,
                                                        string Nr_pedido,
                                                        string Cd_produto,
                                                        string Id_pedidoitem,
                                                        string Tp_pedido,
                                                        int vTop,
                                                        string vNm_campo,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pedidoitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pedidoitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pedidoitem;
            }
            if (!string.IsNullOrEmpty(Tp_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pedido.Trim() + "'";
            }
            return new TCD_Servico_X_PedidoItem(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Faturamento.Pedido.TList_Pedido BuscarPedidos(string Cd_empresa,
                                                                                string Id_os,
                                                                                BancoDados.TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) && 
                (!string.IsNullOrEmpty(Id_os)))
                return new CamadaDados.Faturamento.Pedido.TCD_Pedido(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_pedido, 'F')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + Id_os + ")"
                        }
                    }, 0, string.Empty);
            else
                return null;
        }

        public static string Gravar(TRegistro_Servico_X_PedidoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Servico_X_PedidoItem qtb_ped = new TCD_Servico_X_PedidoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Gravar servico x pedido
                string retorno = qtb_ped.GravarServicoXPedidoItem(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pedido serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Servico_X_PedidoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Servico_X_PedidoItem qtb_ped = new TCD_Servico_X_PedidoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Excluir servico x pedido
                qtb_ped.DeletarServicoXPedidoItem(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar pedido serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }
    }
}
