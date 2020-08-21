using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_OrdemCompra
    {
        public static TList_OrdemCompra Buscar(string Id_oc,
                                               string Cd_empresa,
                                               string Cd_produto,
                                               string Cd_fornecedor,
                                               string Cd_condpgto,
                                               string Cd_moeda,
                                               string Cd_portador,
                                               string Cd_transportadora,
                                               string St_registro,
                                               string Nr_pedido,
                                               int vTop,
                                               string vNm_campo,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_oc.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_oc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_oc;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = b.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (Cd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            if (Cd_moeda.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (Cd_portador.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            if (Cd_transportadora.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_transportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_transportadora.Trim() + "'";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (Nr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_ordemcompra_x_peditem x " +
                                                      "where x.id_oc = a.id_oc " +
                                                      "and x.nr_pedido = " + Nr_pedido + ")";
            }

            return new TCD_OrdemCompra(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_OrdemCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra qtb_ordem = new TCD_OrdemCompra();
            try
            {
                if(banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                string retorno = qtb_ordem.Gravar(val);
                if(st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ordem compra: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra qtb_ordem = new TCD_OrdemCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                qtb_ordem.Excluir(val);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ordem compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static void Estornar(TRegistro_OrdemCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra qtb_ordem = new TCD_OrdemCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ordem.CriarBanco_Dados(true);
                else
                    qtb_ordem.Banco_Dados = banco;
                //Buscar requisicao amarrada a ordem compra
                if (val.Id_requisicao != null)
                {
                    TRegistro_Requisicao rReq = TCN_Requisicao.Buscar(val.Id_requisicao.Value.ToString(),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      "'E'",
                                                                      false,
                                                                      qtb_ordem.Banco_Dados)[0];
                    rReq.St_requisicao = "AP";
                    TCN_Requisicao.AlterarRequisicao(rReq, qtb_ordem.Banco_Dados);
                }
                //Cancelar Ordem Compra
                val.St_registro = "C";
                Gravar(val, qtb_ordem.Banco_Dados);
                if (st_transacao)
                    qtb_ordem.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ordem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar ordem compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ordem.deletarBanco_Dados();
            }
        }

        public static void ProcessarPedido(List<TRegistro_OrdemCompra> val, 
                                           string Cfg_pedido,
                                           CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup,
                                           byte[] anexo_pedido,
                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCompra qtb_oc = new TCD_OrdemCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_oc.CriarBanco_Dados(true);
                else
                    qtb_oc.Banco_Dados = banco;
                //Verificar se existe configuracao para gerar pedido
                TRegistro_Requisicao rReq = TCN_Requisicao.Buscar(val[0].Id_requisicaostr,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  "'E'",
                                                                  false,
                                                                  qtb_oc.Banco_Dados)[0];
                CamadaDados.Compra.TList_CFGCompra lCfg =
                    TCN_CFGCompra.Buscar(rReq.Cd_empresa,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         0,
                                         string.Empty,
                                         qtb_oc.Banco_Dados);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração do modulo de compras para a empresa " + rReq.Cd_empresa.Trim());
                if ((!lCfg[0].St_utilizarmoedaocbool) && lCfg[0].Cd_moeda.Trim().Equals(string.Empty))
                    throw new Exception("Não existe moeda configurada para gerar o pedido.");
                //Gravar pedido
                string retorno = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(
                                    new CamadaDados.Faturamento.Pedido.TRegistro_Pedido()
                                    {
                                        CD_Empresa = rReq.Cd_empresa,
                                        CD_CondPGTO = val[0].Cd_condpgto,
                                        DT_Pedido = DateTime.Now,
                                        TP_Movimento = "E",
                                        CFG_Pedido = string.IsNullOrEmpty(Cfg_pedido) ? lCfg[0].Cfg_pedidocompra : Cfg_pedido,
                                        CD_Clifor = val[0].Cd_fornecedor,
                                        CD_Endereco = val[0].Cd_endfornecedor,
                                        ST_Pedido = "F",
                                        ST_Registro = "A",
                                        Cd_moeda = lCfg[0].St_utilizarmoedaocbool ? val[0].Cd_moeda : lCfg[0].Cd_moeda,
                                        CD_TRANSPORTADORA = val[0].Cd_transportadora,
                                        CD_ENDERECOTRANSP = val[0].Cd_endtransportadora,
                                        Tp_frete = val[0].Tp_frete,
                                        Vl_frete = val.Sum(p=> p.Vl_frete),
                                        Cd_clifor_comprador = rReq.Cd_clifor_comprador,
                                        Anexo_compra = anexo_pedido
                                    }, qtb_oc.Banco_Dados);
                //grava duplicata
                object st_dup = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                    null, "a.st_gerarfin");
                if (st_dup != null && rDup != null)
                    if (st_dup.Equals("S"))
                    {
                        rDup.Nr_pedido =  Convert.ToDecimal(retorno.ToString()) ; 

                        rDup.Nr_docto = rDup.Nr_pedido.ToString();
                        string rtn = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_oc.Banco_Dados);

                        CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_X_Duplicata reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_X_Duplicata();
                        reg.Cd_empresa = lCfg[0].Cd_empresa;
                        reg.Nr_pedido = rDup.Nr_pedido;
                        reg.Nr_lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(rtn, "@P_NR_LANCTO"));
                        CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_X_Duplicata.Gravar(reg, qtb_oc.Banco_Dados);
                    }

                //Gravar itens do pedido
                val.ForEach(p =>
                {
                    //Buscar unidade do produto para gravar no pedido
                    object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_oc.Banco_Dados).BuscarEscalar(
                        new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    }
                                }, "a.cd_unidade");
                    if (obj == null)
                        throw new Exception("Não foi possivel localizar produto " + p.Cd_produto.Trim() + " no cadastro de produto.");
                    if (obj.ToString().Trim().Equals(string.Empty))
                        throw new Exception("Não existe unidade cadastrada para o produto " + p.Cd_produto.Trim() + ".");
                    string ret_item = CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.GravaPedido_Item(
                                        new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                        {
                                            Cd_Empresa = rReq.Cd_empresa,
                                            Cd_local = !string.IsNullOrEmpty(rReq.Cd_local) ? rReq.Cd_local : lCfg[0].Cd_local,
                                            Cd_produto = p.Cd_produto,
                                            Nr_pedido = Convert.ToDecimal(retorno),
                                            Cd_unidade_est = obj.ToString(),
                                            Cd_unidade_valor = obj.ToString(),
                                            Quantidade = p.Quantidade,
                                            Vl_unitario = p.Vl_unitConvertido,
                                            Vl_subtotal = p.Vl_Convertido,
                                            Ds_observacaoitem = p.ObsRequisicao
                                        }, qtb_oc.Banco_Dados);
                    //Alterar status da OC para F - Faturada
                    p.St_registro = "F";
                    TCN_OrdemCompra.Gravar(p, qtb_oc.Banco_Dados);
                    //Gravar OC X Pedido
                    TCN_OrdemCompra_X_PedItem.GravarOC_X_PedItem(
                        new TRegistro_OrdemCompra_X_PedItem()
                        {
                            Cd_produto = p.Cd_produto,
                            Id_oc = p.Id_oc,
                            Id_pedidoitem = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_item, "@P_ID_PEDIDOITEM")),
                            Nr_pedido = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_item, "@P_NR_PEDIDO"))
                        }, qtb_oc.Banco_Dados);
                    p.Nr_pedido = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_item, "@P_NR_PEDIDO"));
                });
                if (st_transacao)
                    qtb_oc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_oc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_oc.deletarBanco_Dados();
            }
        }
    }
}
