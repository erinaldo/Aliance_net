using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_LanEntregaPedido
    {
        public static TList_EntregaPedido Busca(string vID_Entrega,
                                                string vNr_pedido,
                                                string vCd_produto,
                                                string vId_pedidoitem,
                                                bool vSt_Saldo,
                                                string St_conferencia,   
                                                TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Entrega.Trim()!= string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Entrega";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Entrega.ToString();
            }
            if (vNr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_pedido";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNr_pedido;
            }
            if (vCd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto + "'";
            }
            if (vId_pedidoitem.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_pedidoitem;
            }
            if (vSt_Saldo)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.qtd_entregue";
                vBusca[vBusca.Length - 1].vOperador = ">";
                vBusca[vBusca.Length - 1].vVL_Busca = "(abs(isnull((select isnull(sum(isnull(qtd_entrada,0) - isnull(qtd_saida,0)),0) " +
                                                      "from tb_est_estoque x "+
                                                      "inner join tb_fat_notafiscal_item_x_estoque y "+
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                      "where isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and y.id_entrega = a.id_entrega), 0)))";
            }
            if (St_conferencia.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + St_conferencia.Trim() + "'";
            }

            return new TCD_EntregaPedido(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EntregaPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido cd = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;

                val.Id_entregastr = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_ENTREGA");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_entregastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar entrega: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_Pedido rPed, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                string retorno = Gravar(rPed.lEntregaPedido, qtb_entrega.Banco_Dados);
                //Alterar dados do pedido
                TCN_Pedido.Grava_Pedido(rPed, qtb_entrega.Banco_Dados);
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string Gravar(TList_EntregaPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.ForEach(p => 
                    {
                        p.Dt_entrega = CamadaDados.UtilData.Data_Servidor();
                        Gravar(p, qtb_entrega.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EntregaPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido cd = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void ProcessarEntregaPedido(TList_EntregaPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        if (p.St_recontar)
                        {
                            p.St_registro = "P";//Conferencia processada
                            Gravar(p, qtb_entrega.Banco_Dados);
                            //Verificar se a quantidade contada e maior que a quantidade do pedido
                            if (p.Qtd_pedido < p.Qtd_entregue)
                            {
                                //Buscar item do pedido
                                CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItem =
                                    CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.Busca(string.Empty,
                                                                                              string.Empty,
                                                                                              p.Cd_produto,
                                                                                              p.Nr_pedidostr,
                                                                                              p.Id_pedidoitemstr,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              qtb_entrega.Banco_Dados);
                                if (lItem.Count > 0)
                                {
                                    lItem[0].Quantidade += p.Qtd_entregue - p.Qtd_pedido;
                                    lItem[0].Ds_observacaoitem += (lItem[0].Ds_observacaoitem.Trim() != string.Empty ? "\r\n" : string.Empty) +
                                                                   "Item incrementado quantidade em " +
                                                                   (p.Qtd_entregue - p.Qtd_pedido).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) +
                                                                   " " + p.Sigla_unidade.Trim() + " devido diferença na conferência.";
                                    CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.GravaPedido_Item(lItem[0],
                                                                                                         qtb_entrega.Banco_Dados);
                                }
                            }
                        }
                    });
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar conferência: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static void ProcessarEntregaPedido(TRegistro_Pedido rPed, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                ProcessarEntregaPedido(rPed.lEntregaPedido, qtb_entrega.Banco_Dados);
                TCN_Pedido.Grava_Pedido(rPed, qtb_entrega.Banco_Dados);
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar entrega: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string EstornarConferenciaPedido(TList_EntregaPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            string retorno = string.Empty;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        if (p.St_registro.Trim().ToUpper().Equals("P"))
                        {
                            //Verificar se a reserva ja foi faturada
                            object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(qtb_entrega.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x "+
                                                "where x.cd_empresa = a.cd_empresa "+
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                                "and x.id_entrega = " + p.Id_entrega.Value.ToString() + ")"
                                }
                            }, "a.nr_notafiscal");
                            if (obj == null)
                            {
                                p.St_registro = "A";
                                p.Qtd_entregue = decimal.Zero;
                                p.Login = string.Empty;
                                Gravar(p, qtb_entrega.Banco_Dados);
                            }
                            else
                                retorno += "Entrega: " + p.Id_entrega.ToString() + " ja se encontra faturada.\r\n" +
                                           "Nota Fiscal: " + obj.ToString().Trim() + "\r\n";
                        }
                    });
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar conferencia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }

        public static string GravarRecontagem(TList_EntregaPedido val, BancoDados.TObjetoBanco banco)
        {
            string retorno = string.Empty;
            bool st_transacao = false;
            TCD_EntregaPedido qtb_entrega = new TCD_EntregaPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_entrega.CriarBanco_Dados(true);
                else
                    qtb_entrega.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        if (p.St_recontar)
                        {
                            //Verificar se a conferencia ja nao foi utilizada pelo faturamento
                            object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_Faturamento_Item_X_Estoque(qtb_entrega.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_entrega",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_entrega.Value.ToString()
                                    }
                                }, "1");
                            if (obj == null)
                            {
                                p.St_registro = "R";
                                qtb_entrega.Gravar(p);
                            }
                            else
                                retorno += "Id. Entrega: " + p.Id_entrega.Value.ToString() + "\r\n";
                        }
                    });
                if (st_transacao)
                    qtb_entrega.Banco_Dados.Commit_Tran();
                if (retorno.Trim() != string.Empty)
                    retorno = "As seguintes entregas ja foram consumidas pelo faturamento, portanto não podem mais ser recontadas.\r\n" + retorno.Trim();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_entrega.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro recontar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_entrega.deletarBanco_Dados();
            }
        }
    }
}