using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Graos
{
    public class TCN_CadContratoxPedidoItem
    {
        public static TList_CadContratoxPedidoItem Buscar(string vNr_Contrato,
                                                          string vNr_Pedido,
                                                          string vCd_produto,
                                                          string vNm_campo,
                                                          int vTop,
                                                          TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            
            if (!string.IsNullOrEmpty(vNr_Contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Contrato";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Contrato;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vNr_Pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido;
                filtro[filtro.Length - 1].vOperador = "=" ;
            }

            return new TCD_CadContratoxPedidoItem(banco).Select(filtro, vTop, vNm_campo);
        }


        public static TList_RegLanPedido_Item BuscarItensContrato(string Nr_contrato,
                                                                  BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(Nr_contrato.Trim()))
                return new TCD_LanPedido_Item(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_gro_contrato_x_pedidoitem x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.nr_contrato = " + Nr_contrato + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
            else
                return new TList_RegLanPedido_Item();

        }

        public static TList_Pedido BuscarPedContrato(string Nr_contrato,
                                                     BancoDados.TObjetoBanco banco)
        {
            if (!string.IsNullOrEmpty(Nr_contrato.Trim()))
                return new TCD_Pedido(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_gro_contrato_x_pedidoitem x "+
                                        "where x.nr_pedido = a.nr_pedido "+
                                        "and x.nr_contrato = "+Nr_contrato+")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_pedido, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 0, string.Empty);
            else
                return new TList_Pedido();
        }

        public static string GravarContratoxPedidoItem(TRegistro_CadContratoxPedidoItem val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoxPedidoItem qtb_ContratoxPedidoItem = new TCD_CadContratoxPedidoItem();
            try
            {
                if (banco == null)
                {
                    qtb_ContratoxPedidoItem.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ContratoxPedidoItem.Banco_Dados = banco;
                //Gravar Item Contrato
                string retorno = qtb_ContratoxPedidoItem.GravarContratoxPedidoItem(val);
                //Excluir Desdobro Especial
                val.lDesdEspecialDel.ForEach(p => TCN_ContratoItem_X_DesdEspecial.Excluir(p, qtb_ContratoxPedidoItem.Banco_Dados));
                //Gravar Desdobro Especial
                val.lDesdEspecial.ForEach(p =>
                    {
                        p.Nr_contratoorig = val.Nr_contrato;
                        p.Nr_pedidoorig = val.Nr_pedido;
                        p.Cd_produtoorig = val.Cd_produto;
                        p.Id_pedidoitemorig = val.Id_pedidoitem;
                        TCN_ContratoItem_X_DesdEspecial.Gravar(p, qtb_ContratoxPedidoItem.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.deletarBanco_Dados();
            }
        }

        public static string DeletarContratoxPedidoItem(TRegistro_CadContratoxPedidoItem val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoxPedidoItem qtb_ContratoxPedidoItem = new TCD_CadContratoxPedidoItem();
            try
            {
                if (banco == null)
                {
                    qtb_ContratoxPedidoItem.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ContratoxPedidoItem.Banco_Dados = banco;
                //Deletar Item Contrato
                qtb_ContratoxPedidoItem.DeletarContratoxPedidoItem(val);
                //A Stored Procedure ira excluir os desdobros automaticamente
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.deletarBanco_Dados();
            }
        }

        public static string DeletarTodosContratoxPedidoItem(decimal nr_pedido, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoxPedidoItem qtb_ContratoxPedidoItem = new TCD_CadContratoxPedidoItem();
            try
            {
                if (banco == null)
                {
                    qtb_ContratoxPedidoItem.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_ContratoxPedidoItem.Banco_Dados = banco;
                //Deletar Itens do Contrato
                qtb_ContratoxPedidoItem.DeletarTodosContratoxPedidoItem(nr_pedido);
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ContratoxPedidoItem.deletarBanco_Dados();
            }
        }

        public static void GravarDesdobroContratoXPedidoItem(TList_CadContratoxPedidoItem val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContratoxPedidoItem qtb_reg = new TCD_CadContratoxPedidoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else
                    qtb_reg.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        //Excluir desdobros
                        p.lDesdEspecialDel.ForEach(v => TCN_ContratoItem_X_DesdEspecial.Excluir(v, qtb_reg.Banco_Dados));
                        //Inserir/Alterar desdobros
                        p.lDesdEspecial.ForEach(v =>
                            {
                                v.Nr_contratoorig = p.Nr_contrato;
                                v.Nr_pedidoorig = p.Nr_pedido;
                                v.Cd_produtoorig = p.Cd_produto;
                                v.Id_pedidoitemorig = p.Id_pedidoitem;
                                TCN_ContratoItem_X_DesdEspecial.Gravar(v, qtb_reg.Banco_Dados);
                            });
                    });
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }
    }
}
