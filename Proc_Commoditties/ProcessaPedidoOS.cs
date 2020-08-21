using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessaPedidoOS
    {
        public static List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido> ProcessarOS(List<CamadaDados.Servicos.TRegistro_LanServico> lOS)
        {
            if (lOS.Count.Equals(0))
                throw new Exception("Não existe OS selecionada para PROCESSAR.");
            CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                        CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(lOS[0].Tp_ordemstr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
            if (lParam.Count > 0)
            {
                List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido> lRet = new List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido>();
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia = null;
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedPecas = null;
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServ = null;
                lOS.ForEach(p =>
                    {
                        //Buscar Pecas/Servicos da OS
                        p.lPecas = CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                                                     p.Cd_empresa,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     false,
                                                                                     0,
                                                                                     null);
                        //Verificar se existe peca para faturar em garantia
                        if (p.lPecas.Exists(v => v.St_atendimentogarantiabool))
                            //Gerar pedido das pecas em garantia
                            TProcessaPedidoOS.GerarPedidoGarantia(ref rPedGarantia, p, p.lPecas.FindAll(v => v.St_atendimentogarantiabool && (!v.St_servicobool)), lParam[0]);
                        if (lParam[0].St_gerarpedidoservicoseparadobool)
                        {
                            if (p.lPecas.Exists(v => (!v.St_atendimentogarantiabool) && v.St_servicobool))
                                TProcessaPedidoOS.GerarPedidoServico(ref rPedServ, p, p.lPecas.FindAll(v => (!v.St_atendimentogarantiabool) && v.St_servicobool), lParam[0]);
                            if (p.lPecas.Exists(v => (!v.St_atendimentogarantiabool) && (!v.St_servicobool)))
                                TProcessaPedidoOS.GerarPedidoPecas(ref rPedPecas, p, p.lPecas.FindAll(v => (!v.St_atendimentogarantiabool) && (!v.St_servicobool)), lParam[0]);
                        }
                        else if (p.lPecas.Exists(v => !v.St_atendimentogarantiabool))
                            TProcessaPedidoOS.GerarPedidoPecas(ref rPedPecas, p, p.lPecas.FindAll(v => !v.St_atendimentogarantiabool), lParam[0]);
                    });
                if (rPedGarantia != null)
                    lRet.Add(rPedGarantia);
                if (rPedPecas != null)
                {
                    //Gerar Financeiro do pedido
                    using (TFCondPgtoPedido fCond = new TFCondPgtoPedido())
                    {
                        fCond.rPed = rPedPecas;
                        fCond.ShowDialog();
                    }
                    lRet.Add(rPedPecas);
                }
                if (rPedServ != null)
                {
                    //Gerar Financeiro do pedido
                    using (TFCondPgtoPedido fCond = new TFCondPgtoPedido())
                    {
                        fCond.rPed = rPedServ;
                        fCond.ShowDialog();
                    }
                    lRet.Add(rPedServ);
                }
                return lRet;
            }
            else
                throw new Exception("Não existe configuração para o tipo de OS.");
        }

        private static CamadaDados.Faturamento.Pedido.TRegistro_Pedido GerarPedidoRemessa(CamadaDados.Servicos.TRegistro_LanServico val,
                                                                                         bool St_nfterceiro,
                                                                                         decimal Quantidade,
                                                                                         decimal Vl_unitario)
        {
            if (val != null)
            {
                //Buscar configuracao para emitir pedido de remessa 
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                    CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(val.Tp_ordemstr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            1,
                                                                            string.Empty,
                                                                            null);
                if (lParam.Count > 0)
                {
                    if (!string.IsNullOrEmpty(lParam[0].Cfg_pedido_transpremessa))
                    {
                        //Verificar se nao existe um pedido de remessa em aberto para este cliente
                        CamadaDados.Faturamento.Pedido.TList_Pedido lPed = 
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca(val.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              val.Cd_clifor,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              lParam[0].Cfg_pedido_transpremessa,
                                                                              false,
                                                                              true,
                                                                              false,
                                                                              true,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              1,
                                                                              string.Empty,
                                                                              null);
                        if (lPed.Count > 0)
                        {
                            if (St_nfterceiro)
                            {
                                if (Vl_unitario > 0)
                                {
                                    CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItem = 
                                        CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.Busca(string.Empty,
                                                                                                  string.Empty,
                                                                                                  val.CD_ProdutoOS,
                                                                                                  lPed[0].Nr_pedido.ToString(),
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  false,
                                                                                                  null);
                                    if (lItem.Count > 0)
                                        if (Math.Round(lItem[0].Vl_unitario, 2).Equals(Math.Round(Vl_unitario)))
                                        {
                                            lItem[0].Quantidade += Quantidade;
                                            lPed[0].Pedido_Itens.Add(lItem[0]);
                                        }
                                        else
                                        {
                                            //Incluir novo item no pedido com valor unitario diferente
                                            lPed[0].Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                            {
                                                Cd_Empresa = val.Cd_empresa,
                                                Cd_local = string.Empty,
                                                Cd_produto = val.CD_ProdutoOS,
                                                Ds_produto = val.DS_ProdutoOS,
                                                Cd_unidade_est = val.Cd_unidOS,
                                                Cd_unidade_valor = val.Cd_unidOS,
                                                Quantidade = Quantidade,
                                                Vl_unitario = Vl_unitario,
                                                Vl_subtotal = Quantidade * Vl_unitario
                                            });
                                        }
                                    else
                                    {
                                        //Incluir novo item no pedido com valor unitario diferente
                                        lPed[0].Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                        {
                                            Cd_Empresa = val.Cd_empresa,
                                            Cd_local = string.Empty,
                                            Cd_produto = val.CD_ProdutoOS,
                                            Ds_produto = val.DS_ProdutoOS,
                                            Cd_unidade_est = val.Cd_unidOS,
                                            Cd_unidade_valor = val.Cd_unidOS,
                                            Quantidade = Quantidade,
                                            Vl_unitario = Vl_unitario,
                                            Vl_subtotal = Quantidade * Vl_unitario
                                        });
                                    }
                                }
                                else
                                {
                                    //Incluir novo item no pedido
                                    lPed[0].Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                    {
                                        Cd_Empresa = val.Cd_empresa,
                                        Cd_local = string.Empty,
                                        Cd_produto = val.CD_ProdutoOS,
                                        Ds_produto = val.DS_ProdutoOS,
                                        Cd_unidade_est = val.Cd_unidOS,
                                        Cd_unidade_valor = val.Cd_unidOS,
                                        Quantidade = Quantidade,
                                        Vl_unitario = Vl_unitario,
                                        Vl_subtotal = Quantidade * Vl_unitario
                                    });
                                }
                                lPed[0].Tp_pedido = "RM";//Pedido de Remessa
                                return lPed[0];
                            }
                            else
                            {
                                CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItem = 
                                    CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.Busca(string.Empty,
                                                                                              string.Empty,
                                                                                              val.CD_ProdutoOS,
                                                                                              lPed[0].Nr_pedido.ToString(),
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              null);
                                if (lItem.Count > 0)
                                {
                                    lItem[0].Quantidade += Quantidade;
                                    lPed[0].Pedido_Itens.Add(lItem[0]);
                                    lPed[0].Tp_pedido = "RM";//Pedido de Remessa
                                    return lPed[0];
                                }
                                else
                                {
                                    decimal vl_unitario = decimal.Zero;
                                    //Buscar valor medio do estoque
                                    CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, val.CD_ProdutoOS, ref vl_unitario, null);
                                    //Buscar valor da ultima compra
                                    if (vl_unitario.Equals(decimal.Zero))
                                    {
                                        CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras lUltimaCompra =
                                            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                        new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_movimento",
                                                        vOperador = "=",
                                                        vVL_Busca = "'E'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "b.cd_produto",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + val.CD_ProdutoOS.Trim() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'N'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'N'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'S'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                }, 1);
                                        if (lUltimaCompra.Count > 0)
                                            vl_unitario = lUltimaCompra[0].Vl_unitario;
                                    }
                                    //Incluir novo item no pedido
                                    lPed[0].Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                    {
                                        Cd_Empresa = val.Cd_empresa,
                                        Cd_local = string.Empty,
                                        Cd_produto = val.CD_ProdutoOS,
                                        Ds_produto = val.DS_ProdutoOS,
                                        Cd_unidade_est = val.Cd_unidOS,
                                        Cd_unidade_valor = val.Cd_unidOS,
                                        Quantidade = Quantidade,
                                        Vl_unitario = vl_unitario,
                                        Vl_subtotal = Quantidade * vl_unitario
                                    });
                                    lPed[0].Tp_pedido = "RM";//Pedido de Remessa
                                    return lPed[0];
                                }
                            }
                        }
                        else
                        {
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                            rPed.CD_Empresa = val.Cd_empresa;
                            rPed.DT_Pedido = val.Dt_abertura;
                            rPed.CFG_Pedido = lParam[0].Cfg_pedido_transpremessa;
                            rPed.TP_Movimento = "E"; //Pedido de entrada
                            rPed.ST_Pedido = "F"; //Pedido fechado
                            rPed.ST_Registro = "F"; //Pedido fechado
                            rPed.CD_Clifor = val.Cd_clifor;
                            rPed.CD_Endereco = val.Cd_endereco;
                            rPed.Cd_moeda = lParam[0].Cd_moeda;
                            rPed.CD_TRANSPORTADORA = lParam[0].Cd_transportadora;
                            rPed.CD_ENDERECOTRANSP = lParam[0].Cd_enderecoTransp;
                            //Buscar valor medio do estoque
                            if (!St_nfterceiro)
                            {
                                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, val.CD_ProdutoOS, ref Vl_unitario, null);
                                //Buscar valor da ultima compra
                                if (Vl_unitario.Equals(decimal.Zero))
                                {
                                    CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras lUltimaCompra =
                                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                    new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_movimento",
                                                        vOperador = "=",
                                                        vVL_Busca = "'E'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "b.cd_produto",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + val.CD_ProdutoOS.Trim() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'N'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'N'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'S'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                }, 1);
                                    if (lUltimaCompra.Count > 0)
                                        Vl_unitario = lUltimaCompra[0].Vl_unitario;
                                }
                            }
                            rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                            {
                                Cd_Empresa = val.Cd_empresa,
                                Cd_local = string.Empty,
                                Cd_produto = val.CD_ProdutoOS,
                                Ds_produto = val.DS_ProdutoOS,
                                Cd_unidade_est = val.Cd_unidOS,
                                Cd_unidade_valor = val.Cd_unidOS,
                                Quantidade = Quantidade,
                                Vl_unitario = Vl_unitario,
                                Vl_subtotal = Quantidade * Vl_unitario
                            });
                            rPed.Tp_pedido = "RM"; //Pedido de remessa
                            return rPed;
                        }

                    }
                    else
                        throw new Exception("Não existe configuração para emitir pedido de remessa para o tipo de ordem " + val.Tp_ordemstr);
                }
                else
                    throw new Exception("Não existe configuração para o tipo de ordem " + val.Tp_ordemstr);
            }
            else
                return null;
        }

        public static void GerarPedidoGarantia(ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                                CamadaDados.Servicos.TRegistro_LanServico rOs,
                                                List<CamadaDados.Servicos.TRegistro_LanServicosPecas> lPecas,
                                                CamadaDados.Servicos.Cadastros.TRegistro_OSE_ParamOS rParam)
        {
            if (!string.IsNullOrEmpty(rParam.Cfg_pedido_garantia))
            {
                if (rPed == null)
                {
                    rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPed.CD_Empresa = rOs.Cd_empresa;
                    rPed.DT_Pedido = DateTime.Now;
                    rPed.CFG_Pedido = rParam.Cfg_pedido_garantia;
                    rPed.TP_Movimento = "S"; //Pedido de saida
                    rPed.ST_Pedido = "F"; //Pedido fechado
                    rPed.ST_Registro = "F"; //Pedido fechado
                    rPed.CD_Clifor = rOs.Cd_clifor;
                    rPed.CD_Endereco = rOs.Cd_endereco;
                    rPed.Cd_moeda = rParam.Cd_moeda;
                    rPed.CD_TRANSPORTADORA = rParam.Cd_transportadora;
                    rPed.CD_ENDERECOTRANSP = rParam.Cd_enderecoTransp;
                }
                foreach(CamadaDados.Servicos.TRegistro_LanServicosPecas p in lPecas)
                {
                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = rOs.Cd_empresa;
                    reg.Cd_local = p.Cd_local;
                    reg.Cd_vendedor = p.Cd_tecnico;
                    reg.Cd_produto = p.Cd_produto;
                    reg.Ds_produto = p.Ds_produto;
                    reg.Cd_unidade_est = p.Cd_unidproduto;
                    reg.Cd_unidade_valor = p.Cd_unidproduto;
                    reg.Quantidade = p.Quantidade;
                    reg.Vl_unitario = p.Vl_unitario;
                    reg.Vl_subtotal = p.Vl_subtotal;
                    reg.Vl_desc = p.Vl_desconto;
                    reg.Vl_acrescimo = p.Vl_acrescimo;
                    reg.Tp_pedOS = "GR";
                    reg.lPecaOS.Add(p);
                    rPed.Pedido_Itens.Add(reg);
                }
            }
            else
                throw new Exception("Não existe configuracao para emitir pedido de garantia para o tipo de ordem " + rOs.Tp_ordemstr);
        }

        public static void GerarPedidoServico(ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                               CamadaDados.Servicos.TRegistro_LanServico rOs,
                                               List<CamadaDados.Servicos.TRegistro_LanServicosPecas> lServicos,
                                               CamadaDados.Servicos.Cadastros.TRegistro_OSE_ParamOS rParam)
        {
            if (!string.IsNullOrEmpty(rParam.Cfg_pedido_servico))
            {
                if (rPed == null)
                {
                    rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPed.CD_Empresa = rOs != null ? rOs.Cd_empresa : string.Empty;
                    rPed.DT_Pedido = DateTime.Now;
                    rPed.CFG_Pedido = rParam.Cfg_pedido_servico;
                    rPed.Cd_vendedor = rOs != null ? rOs.lEvolucao.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico)) ? rOs.lEvolucao.FindLast(p => !string.IsNullOrEmpty(p.Cd_tecnico)).Cd_tecnico : string.Empty : string.Empty;
                    rPed.TP_Movimento = "S"; //Pedido de saida
                    rPed.ST_Pedido = "F"; //Pedido fechado
                    rPed.ST_Registro = "F"; //Pedido fechado
                    rPed.CD_Clifor = rOs != null ? rOs.Cd_clifor : string.Empty;
                    rPed.CD_Endereco = rOs != null ? rOs.Cd_endereco : string.Empty;
                    rPed.Cd_moeda = rParam.Cd_moeda;
                    rPed.CD_TRANSPORTADORA = rParam.Cd_transportadora;
                    rPed.CD_ENDERECOTRANSP = rParam.Cd_enderecoTransp;
                }
                foreach(CamadaDados.Servicos.TRegistro_LanServicosPecas p in lServicos)
                {
                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = p.Cd_empresa;
                    reg.Cd_local = p.Cd_local;
                    reg.Cd_vendedor = p.Cd_tecnico;
                    reg.Cd_produto = p.Cd_produto;
                    reg.Ds_produto = p.Ds_produto;
                    reg.Cd_unidade_est = p.Cd_unidproduto;
                    reg.Cd_unidade_valor = p.Cd_unidproduto;
                    reg.Quantidade = p.Quantidade;
                    if (rParam.St_sum_d_a_unitbool)
                    {
                        reg.Vl_unitario = p.Vl_unitario - decimal.Round(decimal.Divide(p.Vl_desconto, p.Quantidade), 5, MidpointRounding.AwayFromZero) +
                                            decimal.Round(decimal.Divide(p.Vl_acrescimo, p.Quantidade), 5, MidpointRounding.AwayFromZero);
                        reg.Vl_subtotal = reg.Vl_unitario * p.Quantidade;
                        reg.Vl_desc = decimal.Zero;
                        reg.Vl_acrescimo = decimal.Zero;
                    }
                    else
                    {
                        reg.Vl_unitario = p.Vl_unitario;
                        reg.Vl_subtotal = p.Vl_subtotal;
                        reg.Vl_desc = p.Vl_desconto;
                        reg.Vl_acrescimo = p.Vl_acrescimo;
                    }
                    reg.Tp_pedOS = "SV";
                    reg.lPecaOS.Add(p);
                    rPed.Pedido_Itens.Add(reg);
                }
            }
            else
                throw new Exception("Não existe configuracao para emitir pedido de serviço para o tipo de ordem " + rOs.Tp_ordemstr);
        }

        public static void GerarPedidoPecas(ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                             CamadaDados.Servicos.TRegistro_LanServico rOs,
                                             List<CamadaDados.Servicos.TRegistro_LanServicosPecas> lPecas,
                                             CamadaDados.Servicos.Cadastros.TRegistro_OSE_ParamOS rParam)
        {
            if (!string.IsNullOrEmpty(rParam.Cfg_pedido_item))
            {
                if (rPed == null)
                {
                    rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPed.CD_Empresa = rOs != null ? rOs.Cd_empresa : string.Empty;
                    rPed.DT_Pedido = DateTime.Now;
                    rPed.CFG_Pedido = rParam.Cfg_pedido_item;
                    rPed.Cd_vendedor = rOs != null ? rOs.lEvolucao.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico)) ? rOs.lEvolucao.FindLast(p => !string.IsNullOrEmpty(p.Cd_tecnico)).Cd_tecnico : string.Empty : string.Empty;
                    rPed.TP_Movimento = "S"; //Pedido de saida
                    rPed.ST_Pedido = "F"; //Pedido fechado
                    rPed.ST_Registro = "F"; //Pedido fechado
                    rPed.CD_Clifor = rOs != null ? rOs.Cd_clifor : string.Empty;
                    rPed.CD_Endereco = rOs != null ? rOs.Cd_endereco : string.Empty;
                    rPed.Cd_moeda = rParam.Cd_moeda;
                    rPed.CD_TRANSPORTADORA = rParam.Cd_transportadora;
                    rPed.CD_ENDERECOTRANSP = rParam.Cd_enderecoTransp;
                }
                foreach(CamadaDados.Servicos.TRegistro_LanServicosPecas p in lPecas)
                {
                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = p.Cd_empresa;
                    reg.Cd_local = p.Cd_local;
                    reg.Cd_vendedor = p.Cd_tecnico;
                    reg.Cd_produto = p.Cd_produto;
                    reg.Ds_produto = p.Ds_produto;
                    reg.Cd_unidade_est = p.Cd_unidproduto;
                    reg.Cd_unidade_valor = p.Cd_unidproduto;
                    reg.Quantidade = p.Qtd_faturar > decimal.Zero ? p.Qtd_faturar : p.Quantidade;
                    if (rParam.St_sum_d_a_unitbool)
                    {
                        reg.Vl_unitario = p.Vl_unitario - decimal.Round(decimal.Divide(p.Vl_desconto, p.Quantidade), 5, MidpointRounding.AwayFromZero) +
                                            decimal.Round(decimal.Divide(p.Vl_acrescimo, p.Quantidade), 5, MidpointRounding.AwayFromZero);
                        reg.Vl_subtotal = reg.Vl_unitario * p.Qtd_faturar > decimal.Zero ? p.Qtd_faturar : p.Quantidade;
                        reg.Vl_desc = decimal.Zero;
                        reg.Vl_acrescimo = decimal.Zero;
                    }
                    else
                    {
                        reg.Vl_unitario = p.Vl_unitario;
                        reg.Vl_subtotal = p.Vl_unitario * (p.Qtd_faturar > decimal.Zero ? p.Qtd_faturar : p.Quantidade);
                        reg.Vl_desc = p.Vl_desconto;
                        reg.Vl_acrescimo = p.Vl_acrescimo;
                    }
                    reg.Tp_pedOS = "IT";
                    reg.lPecaOS.Add(p);
                    rPed.Pedido_Itens.Add(reg);
                }
            }
            else
                throw new Exception("Não existe configuracao para emitir pedido de peças para o tipo de ordem " + rOs.Tp_ordemstr);
        }
    }
}
