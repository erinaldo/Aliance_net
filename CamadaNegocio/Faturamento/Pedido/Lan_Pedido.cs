using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;
using System.Globalization;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using System.IO;
using System.Windows.Forms;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Servicos;
using CamadaDados.Faturamento.Orcamento;
using CamadaNegocio.Faturamento.Orcamento;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Financeiro.Adiantamento;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_Pedido
    {
        private static void VerificarItemSaldoEstoque(TRegistro_Pedido val, TObjetoBanco banco)
        {
            //Verificar se o pedido possui cmi que movimenta estoque
            object objestoque = new TCD_CadCFGPedidoFiscal(banco).BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cfg_pedido",
                        vOperador = "=",
                        vVL_Busca = "'" + val.CFG_Pedido.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'N'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(d.st_geraEstoque, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, "1");
            if (objestoque != null)
                if (objestoque.ToString().Trim().Equals("1"))
                    val.Pedido_Itens.ForEach(p =>
                    {
                        //Verificar se nao e servico
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(banco).ItemServico(p.Cd_produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(banco).ProdutoConsumoInterno(p.Cd_produto)))
                        {
                            //Verificar se e produto industrializado
                            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto(banco).ProdutoComposto(p.Cd_produto))
                            {
                                //Buscar itens do produto industrializado
                                CamadaDados.Producao.Producao.TList_FichaTec_MPrima lFichaTec =
                                new CamadaDados.Producao.Producao.TCD_FichaTec_MPrima(banco).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_prd_formula_apontamento x "+
                                                    "inner join tb_prd_fichatec_acabado y "+
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.id_formulacao = y.id_formulacao "+
                                                    "where x.cd_empresa = a.cd_empresa "+
                                                    "and x.id_formulacao = a.id_formulacao "+
                                                    "and y.cd_empresa = '" + val.CD_Empresa.Trim() + "' "+
                                                    "and y.cd_produto = '" + p.Cd_produto.Trim() + "')"
                                    }
                                }, 0, string.Empty);
                                lFichaTec.ForEach(v =>
                                {
                                    decimal saldo = decimal.Zero;
                                    CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(val.CD_Empresa,
                                                                                           v.Cd_produto,
                                                                                           v.Cd_local,
                                                                                           ref saldo,
                                                                                           banco);
                                    CamadaDados.Estoque.TList_ReservaEstoque lReserva =
                                        CamadaNegocio.Estoque.TCN_LanEstoque.BuscarReservaEstoque(val.CD_Empresa,
                                                                                                  v.Cd_produto,
                                                                                                  v.Cd_local,
                                                                                                  banco);
                                    decimal saldo_real = saldo;
                                    if (lReserva.Count > 0)
                                        saldo_real = saldo - lReserva[0].Qtd_reservada;
                                    decimal qtd_pedido = decimal.Zero;
                                    val.Pedido_Itens.ForEach(x =>
                                        {
                                            if (x.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))
                                                qtd_pedido += p.Quantidade;
                                        });
                                    if (saldo_real < (v.Qtd_produto * qtd_pedido))
                                        throw new Exception("Pedido não podera ser fechado.\r\n" +
                                                            "Produto........: " + v.Cd_produto.Trim() + "-" + v.Ds_produto.Trim() + "\r\n" +
                                                            "Local Arm......: " + v.Cd_local.Trim() + "-" + v.Ds_local.Trim() + "\r\n" +
                                                            "Saldo Estoque..: " + (saldo).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n" +
                                                            "Qtd. Reservada.: " + (lReserva.Count > 0 ? lReserva[0].Qtd_saldoreserva.ToString("N0", new System.Globalization.CultureInfo("en-US", true)) : string.Empty) + "\r\n" +
                                                            "Saldo Real.....: " + (saldo_real).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n" +
                                                            "Qtd. Faturar...: " + (v.Qtd_produto * qtd_pedido).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n\r\n");
                                });
                            }
                            else
                            {
                                decimal saldo = decimal.Zero;
                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(val.CD_Empresa,
                                                                                       p.Cd_produto,
                                                                                       p.Cd_local,
                                                                                       ref saldo,
                                                                                       banco);
                                CamadaDados.Estoque.TList_ReservaEstoque lReserva =
                                    CamadaNegocio.Estoque.TCN_LanEstoque.BuscarReservaEstoque(val.CD_Empresa,
                                                                                              p.Cd_produto,
                                                                                              p.Cd_local,
                                                                                              banco);
                                decimal saldo_real = saldo;
                                if (lReserva.Count > 0)
                                    saldo_real = saldo - lReserva[0].Qtd_reservada;
                                decimal qtd_pedido = decimal.Zero;
                                val.Pedido_Itens.ForEach(x =>
                                    {
                                        if (x.Cd_produto.Trim().Equals(p.Cd_produto.Trim()))
                                            qtd_pedido += x.Quantidade;
                                    });
                                if (saldo_real < qtd_pedido)
                                    throw new Exception("Pedido não podera ser fechado.\r\n" +
                                                        "Produto........: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                                        "Local Arm......: " + p.Cd_local.Trim() + "-" + p.Ds_local.Trim() + "\r\n" +
                                                        "Saldo Estoque..: " + (saldo).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n" +
                                                        "Qtd. Reservada.: " + (lReserva.Count > 0 ? lReserva[0].Qtd_saldoreserva.ToString("N0", new System.Globalization.CultureInfo("en-US", true)) : string.Empty) + "\r\n" +
                                                        "Saldo Real.....: " + (saldo_real).ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n" +
                                                        "Qtd. Faturar...: " + qtd_pedido.ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n\r\n");
                            }
                        }
                    });
        }

        public static void GerarOrdemProducao(TRegistro_Pedido val, TObjetoBanco banco)
        {
            val.Pedido_Itens.ForEach(p =>
            {
                //Verificar se o item e do tipo INDUSTRIALIZADO
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(banco).BuscarEscalar(
                         new TpBusca[]
                         {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_tpproduto x " +
                                                    "where x.tp_produto = a.tp_produto " +
                                                    "and isnull(x.st_industrializado, 'N') = 'S')"
                                    }
                         }, "1");
                if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                {
                    //Verificar se ja nao existe ordem gerada para o item
                    obj = new TCD_OrdemProducao_X_PedItem(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_PedidoString
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pedidoitem",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_pedidoitem.ToString()
                                        }
                            }, "1");
                    if (obj == null)
                    {
                        //Montar Formula Apontamento
                        TList_FichaTec_MPrima lMPrima = new TList_FichaTec_MPrima();
                        p.lFichaTec.ForEach(x =>
                                lMPrima.Add(new TRegistro_FichaTec_MPrima()
                                {
                                    Cd_empresa = p.Cd_Empresa,
                                    Cd_produto = x.Cd_item,
                                    Cd_unidade = x.Cd_unditem,
                                    Cd_local = p.Cd_local,
                                    Qtd_produto = x.Quantidade
                                }));
                        //Gravar Formula Apontamento
                        TRegistro_FormulaApontamento rFormula =
                        new TRegistro_FormulaApontamento();
                        rFormula.Cd_empresa = p.Cd_Empresa;
                        rFormula.Ds_formula = "FÓRMULA APONTAMENTO GERADA PELO ITEM DO ORÇAMENTO.";
                        rFormula.Cd_produto = p.Cd_produto;
                        rFormula.Cd_unidade = p.Cd_unidade_est;
                        rFormula.Cd_local = p.Cd_local;
                        rFormula.Qt_produto = p.Quantidade;
                        rFormula.LFichaTec_MPrima = lMPrima;
                        TCN_FormulaApontamento.Gravar(rFormula, banco);
                        //Gerar ordem de producao para o item
                        TCN_OrdemProducao.Gravar(new TRegistro_OrdemProducao()
                        {
                            Cd_empresa = val.CD_Empresa,
                            Cd_produto = p.Cd_produto,
                            Id_formulacao = rFormula.Id_formulacao,
                            Cd_unidade = p.Cd_unidade_est,
                            Ds_observacao = "ORDEM PRODUCAO GERADA AUTOMATICAMENTE PELO PEDIDO Nº " + val.Nr_pedido.ToString(),
                            Dt_ordem = val.DT_Pedido,
                            Qtd_batch = Convert.ToInt32(p.Quantidade),
                            lPedItem = new TList_OrdemProducao_X_PedItem()
                                                    {
                                                        new TRegistro_OrdemProducao_X_PedItem()
                                                        {
                                                            Cd_produto = p.Cd_produto,
                                                            Nr_pedido = p.Nr_pedido,
                                                            Id_pedidoitem = p.Id_pedidoitem
                                                        }
                                                    }
                        }, banco);
                    }
                }
            });

        }

        public static void GerarOrdemProducaoFat(TRegistro_Pedido val, TObjetoBanco banco)
        {
            val.Pedido_Itens.ForEach(p =>
            {
                //Verificar se o item e do tipo INDUSTRIALIZADO
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(banco).BuscarEscalar(
                         new TpBusca[]
                         {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_est_tpproduto x " +
                                                "where x.tp_produto = a.tp_produto " +
                                                "and isnull(x.st_industrializado, 'N') = 'S')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "exists",
                                    vOperador = "(select 1 from TB_FAT_CFGPedido xxx " +
                                                "where xxx.cfg_pedido = '" + val.CFG_Pedido + "' " +
                                                "and isnull(xxx.st_gerarOP, 'N') = 'S')"
                                }
                         }, "1");
                if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                {
                    //Verificar se ja nao existe ordem gerada para o item
                    obj = new TCD_OrdemProducao_X_PedItem(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_PedidoString
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pedidoitem",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_pedidoitem.ToString()
                                        }
                            }, "1");
                    if (obj == null)
                    {
                        //Buscar Formula de apontamento
                        TList_FormulaApontamento lFormula = TCN_FormulaApontamento.Buscar(p.Cd_Empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          p.Cd_produto,
                                                                                          string.Empty,
                                                                                          0,
                                                                                          string.Empty,
                                                                                          null);
                        if (lFormula.Count.Equals(0))
                            throw new Exception("O produto de código: " + p.Cd_produto + "\n\n " +
                                "Descrição: " + p.Ds_produto + "\n\n " +
                                "Não possui formula de apontamento, não será possível finalizar a opção.");
                        TRegistro_FormulaApontamento rFormula = null;
                        rFormula = lFormula[0];

                        //Buscar ficha tecnica da formula selecionada
                        TList_FichaTec_MPrima lFichaP = TCN_FichaTec_MPrima.Buscar(rFormula.Cd_empresa,
                                                                                   rFormula.Id_formulacaostr,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   0,
                                                                                   string.Empty,
                                                                                   null);
                        if (lFichaP.Count.Equals(0))
                            throw new Exception("O produto de código: " + p.Cd_produto + "\n\n " +
                                "Descrição: " + p.Ds_produto + "\n\n " +
                                "Formula: " + rFormula.Id_formulacaostr + "\n\n " +
                                "Não possui ficha técnica, não será possível finalizar a opção.");

                        TList_Ordem_MPrima _Ordem_MPrimas = new TList_Ordem_MPrima();
                        lFichaP.ForEach(q =>
                        {
                            _Ordem_MPrimas.Add(
                                new TRegistro_Ordem_MPrima
                                {
                                    CD_Empresa = p.Cd_Empresa,
                                    ID_Formulacao_MPrima = q.Id_formulacao,
                                    Cd_produto = q.Cd_produto,
                                    Ds_produto = q.Ds_produto,
                                    Cd_unidade = q.Cd_unidade,
                                    Ds_unidade = q.Sigla_unid_produto,
                                    Sigla_unidade = q.Sigla_unid_produto,
                                    Cd_local = q.Cd_local,
                                    Ds_local = q.Ds_local,
                                    Qtd_produto = q.Qtd_produto * p.Quantidade,
                                    Qtd_produto_calc = q.Qtd_produto * p.Quantidade,
                                    SaldoEstoque = Estoque.TCN_LanEstoque.Busca_Saldo_Local(p.Cd_Empresa, p.Cd_produto, p.Cd_local, banco)
                                });
                        });

                        //Gerar ordem de producao para o item
                        TCN_OrdemProducao.Gravar(new TRegistro_OrdemProducao()
                        {
                            Cd_empresa = val.CD_Empresa,
                            Cd_produto = p.Cd_produto,
                            Cd_unidade = p.Cd_unidade_est,
                            Ds_observacao = "ORDEM PRODUCÃO GERADA AUTOMATICAMENTE PELO PEDIDO Nº " + val.Nr_pedido.ToString(),
                            Dt_ordem = val.DT_Pedido,
                            Id_formulacaostr = rFormula.Id_formulacaostr,
                            Qtd_batch = Convert.ToInt32(p.Quantidade),
                            lOrdem_MPrima = _Ordem_MPrimas,
                            lPedItem = new TList_OrdemProducao_X_PedItem()
                                {
                                    new TRegistro_OrdemProducao_X_PedItem()
                                    {
                                        Cd_produto = p.Cd_produto,
                                        Nr_pedido = p.Nr_pedido,
                                        Id_pedidoitem = p.Id_pedidoitem
                                    }
                                }
                        }, banco);
                    }
                }
            });

        }

        public static TList_Pedido Busca(string vCD_Empresa,
                                        string vTp_Movimento,
                                        string vNr_Pedido,
                                        string vCD_Clifor,
                                        string vCD_Produto,
                                        string vCD_Endereco,
                                        string vDS_ObsPedido,
                                        string vNr_PedidoOrigem,
                                        string vDT_Pedido,
                                        string vCFG_Pedido,
                                        bool vST_Pedido_Cancelado,
                                        bool vST_Pedido_Fechado,
                                        bool vST_Pedido_Encerrado,
                                        bool vST_Pedido_Ativo,
                                        bool vST_Pedido_Expirado,
                                        bool vST_Pedido_Parcial,
                                        bool vSt_pedido_sem_saldo_valor,
                                        bool St_conferenciaprocessada,
                                        string vDT_Inicial,
                                        string vDT_Final,
                                        string vProduto_Existente_Pedido,
                                        string vCd_condpgto,
                                        string vCd_tabelapreco,
                                        string vCd_vendedor,
                                        string vCd_moeda,
                                        string vCd_representante,
                                        String Cd_grupo,
                                        decimal vVl_inicial,
                                        decimal vVl_final,
                                        string nr_orcamento,
                                        string st_registro_etapa,
                                        bool St_origemproposta,
                                        int vTop,
                                        string vNM_Campo,
                                        TObjetoBanco banco,
                                        string vCategoriaClifor = "")
        {
            TpBusca[] filtro = new TpBusca[0];

            if ((vDT_Inicial.Trim() != string.Empty) && (vDT_Inicial.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Inicial).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((vDT_Final.Trim() != string.Empty) && (vDT_Final.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Final).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (vTp_Movimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_Movimento.Trim() + "'";
            }
            if (vCD_Empresa != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vNr_Pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido;
            }
            if (vCD_Clifor != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor + "'";
            }
            if (vCD_Produto != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Pedido_Itens x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_produto = '" + vCD_Produto.Trim() + "')";
            }
            if (vCD_Endereco != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Endereco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Endereco + "'";
            }
            if (vDS_ObsPedido != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vDS_ObsPedido + "'";
            }
            if (vNr_PedidoOrigem != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_PedidoOrigem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_PedidoOrigem + "'";
            }
            if ((vDT_Pedido.Trim() != "") && (vDT_Pedido.Trim() != "/  /") && (vDT_Pedido.Trim() != "01/01/0001 00:00:00") && (vDT_Pedido.Trim() != "__/__/____"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime(vDT_Pedido).ToString("yyyyMMdd") + "'");
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCFG_Pedido != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCFG_Pedido + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_cfgpedido x " +
                                                      "where x.cfg_pedido = a.cfg_pedido " +
                                                      "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            }

            if (vST_Pedido_Ativo ||
                vST_Pedido_Cancelado ||
                vST_Pedido_Fechado ||
                vST_Pedido_Encerrado ||
                vST_Pedido_Expirado ||
                vST_Pedido_Parcial)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_Pedido";
                filtro[filtro.Length - 1].vOperador = "IN";

                string Virgula = "";
                string IN = "( ";

                if (vST_Pedido_Cancelado)
                {
                    IN += Virgula + "'C'";
                    Virgula = ",";
                }

                if (vST_Pedido_Fechado || vST_Pedido_Expirado || vST_Pedido_Parcial)
                {
                    IN += Virgula + "'F'";
                    Virgula = ",";
                }

                if (vST_Pedido_Encerrado)
                {
                    IN += Virgula + "'P'";
                    Virgula = ",";
                }

                if (vST_Pedido_Ativo)
                {
                    IN += Virgula + "'A'";
                    Virgula = ",";
                }
                filtro[filtro.Length - 1].vVL_Busca = IN + ")";
                if (vST_Pedido_Expirado)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "(isnull(a.dt_entregapedido, getdate())";
                    filtro[filtro.Length - 1].vOperador = "<";
                    filtro[filtro.Length - 1].vVL_Busca = "getdate())";
                }
                if (vST_Pedido_Parcial)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = string.Empty;
                    filtro[filtro.Length - 1].vVL_Busca = "a.vl_totalpedido - (case when a.tp_movimento = 'E' then " +
                                                          "vl_totalfat_entrada - vl_totalfat_saida else " +
                                                          "vl_totalfat_saida - vl_totalfat_entrada end) > 0 and " +
                                                          "a.vl_totalpedido - (case when a.tp_movimento = 'E' then " +
                                                          "vl_totalfat_entrada - vl_totalfat_saida else " +
                                                          "vl_totalfat_saida - vl_totalfat_entrada end) < a.vl_totalpedido";
                }
            }
            if (vSt_pedido_sem_saldo_valor)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.vl_totalpedido - (case when a.tp_movimento = 'E' then " +
                                                      "vl_totalfat_entrada - vl_totalfat_saida else " +
                                                      "vl_totalfat_saida - vl_totalfat_entrada end) <= 0";
            }
            if (vProduto_Existente_Pedido != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = " 	exists(select top 1 1 from TB_Fat_Pedido_Itens x where x.nr_pedido = a.nr_Pedido and x.cd_produto  ";
                filtro[filtro.Length - 1].vOperador = " = ";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vProduto_Existente_Pedido + "' )";
            }
            if (vCd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_condpgto.Trim() + "'";
            }
            if (vCd_tabelapreco.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_tabelapreco.Trim() + "'";
            }
            if (vCd_vendedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_vendedor.Trim() + "'";
            }
            if (vCd_moeda.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_moeda.Trim() + "'";
            }
            if (vVl_inicial > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_totalpedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), vVl_inicial.ToString());
            }
            if (vVl_final > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_totalpedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), vVl_final.ToString());
            }
            if (St_conferenciaprocessada)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "((exists(select 1 from tb_fat_entregapedido x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and isnull(x.st_registro, 'A') = 'P')) or ( " +
                                                      "isnull(c.st_exigirconferenciaentrega, 'N') = 'N'))";
            }
            if (nr_orcamento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(exists( select 1 from tb_fat_pedido_itens x" +
                                                        " where x.nr_pedido = a.nr_pedido" +
                                                        " and x.nr_orcamento = '" + nr_orcamento.Trim() + "'))";



            }
            if (nr_orcamento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "( select 1 from tb_fat_pedido_itens x" +
                                                        " where x.nr_pedido = a.nr_pedido" +
                                                        " and x.nr_orcamento = '" + nr_orcamento.Trim() + "')";
            }

            if (st_registro_etapa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "not exists(select 1 from TB_FAT_pedido_etapa x" +
                                                       " where x.nr_pedido = a.nr_pedido " +
                                                       " and isnull(x.st_registro, '" + st_registro_etapa + "') = '" + st_registro_etapa + "')";



            }
            if (!string.IsNullOrEmpty(vCd_representante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_representante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_representante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                                      "inner join tb_est_produto y " +
                                                      "on x.cd_produto = y.cd_produto " +
                                                      "and y.cd_grupo like '" + Cd_grupo.Trim() + "%'" +
                                                      "and x.nr_pedido = a.nr_pedido)";
            }
            if (St_origemproposta)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro[filtro.Length - 1].vOperador = "is not";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }

            if (!string.IsNullOrEmpty(vCategoriaClifor.Trim()))
                Estruturas.CriarParametro(ref filtro, "d.Id_CategoriaCliFor", vCategoriaClifor.Trim());

            return new TCD_Pedido(banco).Select(filtro, vTop, vNM_Campo);
        }

        public static TList_Pedido BuscarPedidoConferencia(string Nr_pedido,
                                                           string Cd_empresa,
                                                           string Cd_clifor,
                                                           string Cfg_pedido,
                                                           string Cd_vendedor,
                                                           string Cd_comprador,
                                                           string Tp_movimento,
                                                           string Dt_ini,
                                                           string Dt_fin,
                                                           bool St_pedconfaberta,
                                                           bool St_pedconfprocessada,
                                                           bool St_pedconfrecontar,
                                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[2];
            //Pedido Fechado
            filtro[0].vNM_Campo = "a.ST_Pedido";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'F'";
            //Tipo Pedido Exige Conferencia
            filtro[1].vNM_Campo = "isnull(c.st_exigirconferenciaentrega, 'N')";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
            if (Nr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            }
            if (Cd_clifor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (Cfg_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido.Trim() + "'";
            }
            if (Tp_movimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            }
            if (St_pedconfaberta)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_entregapedido x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and isnull(x.st_registro, 'A') = 'A')";
            }
            if (St_pedconfprocessada)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_entregapedido x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and isnull(x.st_registro, 'A') = 'P')";
            }
            if (St_pedconfrecontar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_entregapedido x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and isnull(x.st_registro, 'A') = 'R')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (Cd_vendedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (Cd_comprador.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor_comprador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_comprador.Trim() + "'";
            }

            return new TCD_Pedido(banco).Select(filtro, 0, string.Empty);
        }

        public static TRegistro_Pedido Busca_Registro_Pedido(string NR_Pedido, TObjetoBanco banco)
        {
            return new TCD_Pedido(banco).Select(
                new TpBusca[]
                {
                   new TpBusca()
                   {
                       vNM_Campo = "a.nr_pedido",
                       vOperador = "=",
                       vVL_Busca = NR_Pedido
                   }
                }, 0, string.Empty)[0];
        }

        public static void Busca_Pedido_Itens(TRegistro_Pedido val,
                                              bool St_detalhes,
                                              TObjetoBanco banco)
        {

            if (val != null)
                if (val.Nr_pedido > 0)
                {
                    val.Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                val.Nr_pedido.ToString(),
                                                                string.Empty,
                                                                string.Empty,
                                                                "a.id_pedidoitem",
                                                                false,
                                                                banco);
                    if (St_detalhes)
                        val.Pedido_Itens.ForEach(p =>
                        {
                            p.lFichaTec = TCN_FichaTecItemPed.Buscar(p.Nr_PedidoString,
                                                                     p.Cd_produto,
                                                                     p.Id_pedidoitem.ToString(),
                                                                     string.Empty,
                                                                     banco);
                        });
                }
        }

        public static string Deleta_Pedido(TRegistro_Pedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido QTB_Pedido = new TCD_Pedido();
            try
            {
                if (banco == null)
                    st_transacao = QTB_Pedido.CriarBanco_Dados(true);
                else
                    QTB_Pedido.Banco_Dados = banco;
                //Verificar se existe nota fiscal para o pedido
                object obj = new TCD_LanFaturamento_Item(QTB_Pedido.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = val.Nr_pedido.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, "1");
                if (obj == null)
                {
                    CamadaDados.Servicos.TList_LanServico lOs = TCN_LanServico.Buscar(string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      val.Nr_pedido.ToString(),
                                                                                      false,
                                                                                      false,
                                                                                      false,
                                                                                      false,
                                                                                      false,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      QTB_Pedido.Banco_Dados);
                    lOs.ForEach(p =>
                        {
                            p.Nr_pedidointegra = null;
                            p.St_os = "PR";
                            TCN_LanServico.Alterar(p, QTB_Pedido.Banco_Dados);
                        });
                    //Verificar se o pedido movimenta orcamento
                    if (val.Pedido_Itens.Exists(p => p.Nr_orcamento != null))
                    {
                        TList_Orcamento lOrc = TCN_Orcamento.Buscar(val.Pedido_Itens.Find(p => p.Nr_orcamento != null).Nr_orcamento.Value.ToString(),
                                                                    string.Empty,
                                                                    string.Empty,
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
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    false,
                                                                    false,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    false,
                                                                    false,
                                                                    QTB_Pedido.Banco_Dados);
                        lOrc.ForEach(p =>
                        {
                            if (!p.Id_os.HasValue)
                            {
                                p.St_registro = "AB";
                                System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
                                hs.Add("@P_NR_ORCAMENTO", p.Nr_orcamentostr);
                                new TCD_Orcamento(QTB_Pedido.Banco_Dados).executarSql("update tb_fat_orcamento set st_registro = 'AB', dt_alt = getdate() where nr_orcamento = @P_NR_ORCAMENTO", hs);
                            }
                        });
                    }
                    //Excluir os itens do pedido
                    val.Pedido_Itens.ForEach(p =>
                        {
                            p.St_registro = "C";
                            p.Nr_orcamento = null;
                            p.Id_itemorc = null;
                            TCN_LanPedido_Item.GravaPedido_Item(p, QTB_Pedido.Banco_Dados);
                        });
                    //Excluir duplicata
                    //Verificar se usuario tem permissão para excluir duplicata
                    TList_RegLanDuplicata lDup = TCN_LanPedido_X_Duplicata.BuscarDup(val.Nr_pedido, QTB_Pedido.Banco_Dados);
                    if (lDup.Count > 0)
                    {
                        if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", banco))
                        {
                            //Verificar se o usuario tem acesso a tela de duplicata
                            if ((Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                                throw new Exception("Não é permitido cancelar uma nota fiscal com movimentação financeira.\r\n" +
                                                    "Para cancelar a nota fiscal é necessário cancelar primeiro o financeiro.");
                            else
                            {
                                lDup.ForEach(p =>
                                    {
                                        TCN_LanPedido_X_Duplicata.Excluir(new TRegistro_LanPedido_X_Duplicata()
                                        {
                                            Nr_pedido = val.Nr_pedido,
                                            Cd_empresa = val.CD_Empresa,
                                            Nr_lancto = p.Nr_lancto
                                        }, QTB_Pedido.Banco_Dados);
                                        TCN_LanDuplicata.CancelarDuplicata(p, QTB_Pedido.Banco_Dados);
                                    });
                            }
                        }
                        else
                            throw new Exception("Usuário não tem permissão para cancelar Duplicata!");
                    }
                    //Excluir pedido
                    QTB_Pedido.Deletar_Pedido(val);
                    if (st_transacao)
                        QTB_Pedido.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                else
                    throw new Exception("Existe nota fiscal emitida para o pedido, obrigatorio cancelar antes a nota fiscal.");
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    QTB_Pedido.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    QTB_Pedido.deletarBanco_Dados();
            }
        }

        public static string Grava_Pedido(TRegistro_Pedido val,
                                          TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido qtb_ped = new TCD_Pedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Verificar se o pedido tem configuracao fiscal para emitir nota fiscal
                object obj = new TCD_CadCFGPedidoFiscal(qtb_ped.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.CFG_Pedido.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    }
                                }, "1");
                if (obj == null ? false : obj.ToString().Trim() != "1")
                    throw new Exception("Não é permitido gravar pedido sem configuração fiscal.");
                //Verificar se o usuario tem permissao para fechar pedido sem saldo em estoque
                if ((!Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR FECHAR PEDIDO COM ITEM SEM SALDO ESTOQUE", qtb_ped.Banco_Dados)) &&
                    val.TP_Movimento.Trim().ToUpper().Equals("S"))
                    VerificarItemSaldoEstoque(val, qtb_ped.Banco_Dados);
                val.Nr_pedido = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ped.Gravar_Pedido(val), "@P_NR_PEDIDO"));
                //Deletar itens do pedido
                val.Deleta_Pedido_Itens.ForEach(p =>
                {
                    try
                    {
                        TCN_LanPedido_Item.DeletaPedido_Item(p, qtb_ped.Banco_Dados);
                    }
                    catch
                    {
                        p.St_registro = "C";
                        TCN_LanPedido_Item.GravaPedido_Item(p, qtb_ped.Banco_Dados);
                    }
                });
                //Gravar itens do pedido
                val.Pedido_Itens.ForEach(p =>
                {
                    if ((!string.IsNullOrEmpty(val.Cd_vendedor)) && string.IsNullOrEmpty(p.Cd_vendedor))
                        p.Cd_vendedor = val.Cd_vendedor;
                    p.Nr_pedido = val.Nr_pedido;
                    p.Cd_Empresa = val.CD_Empresa;
                    p.Cd_condpgto = val.CD_CondPGTO;
                    p.Dt_pedido = val.DT_Pedido;
                    p.Cd_vendedor = val.Cd_vendedor;
                    p.Nomevendedor = val.Nomevendedor;
                    decimal vl_estoque = decimal.Zero;
                    Estoque.TCN_LanEstoque.VlMedioEstoque(val.CD_Empresa, p.Cd_produto, ref vl_estoque, qtb_ped.Banco_Dados);
                    p.Vl_custoitem = vl_estoque;
                    TCN_LanPedido_Item.GravaPedido_Item(p, qtb_ped.Banco_Dados);
                });
                //Gravar financeiro do pedido
                val.Deleta_Pedidos_DT_Vencto.ForEach(p => TCN_LanPedido_DT_Vencto.Excluir(p, qtb_ped.Banco_Dados));
                val.Pedidos_DT_Vencto.ForEach(p =>
                    {
                        p.Nr_Pedido = val.Nr_pedido;
                        TCN_LanPedido_DT_Vencto.Gravar(p, qtb_ped.Banco_Dados);
                    });
                //Gravar Etapas do Pedido
                val.lEtapa.ForEach(p =>
                    {
                        p.Nr_pedido = val.Nr_pedido;
                        TCN_EtapaPedido.Gravar(p, qtb_ped.Banco_Dados);
                    });
                //Deletar Acessorios
                val.lAcessoriosDel.ForEach(p => TCN_AcessoriosPed.Excluir(p, qtb_ped.Banco_Dados));
                //Gravar Acessorios
                val.lAcessorios.ForEach(p =>
                {
                    p.Nr_pedido = val.Nr_pedido;
                    TCN_AcessoriosPed.Gravar(p, qtb_ped.Banco_Dados);
                });

                //Gerar Ordem de Producao para o pedido
                GerarOrdemProducaoFat(val, qtb_ped.Banco_Dados);

                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();

                return val.Nr_pedido.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string GravaDuplicata(TRegistro_Pedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido qtb_ped = new TCD_Pedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Gravar Duplicata
                TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_ped.Banco_Dados);
                TCN_LanPedido_X_Duplicata.Gravar(new TRegistro_LanPedido_X_Duplicata()
                {
                    Nr_pedido = val.Nr_pedido,
                    Cd_empresa = val.CD_Empresa,
                    Nr_lancto = val.lDup[0].Nr_lancto
                }, qtb_ped.Banco_Dados);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string AlterarItemPedido(TRegistro_Pedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido qtb_ped = new TCD_Pedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Gravar itens do pedido
                val.Pedido_Itens.ForEach(p =>
                {
                    if ((!string.IsNullOrEmpty(val.Cd_vendedor)) && string.IsNullOrEmpty(p.Cd_vendedor))
                        p.Cd_vendedor = val.Cd_vendedor;
                    p.Nr_pedido = val.Nr_pedido;
                    p.Cd_Empresa = val.CD_Empresa;
                    p.Cd_condpgto = val.CD_CondPGTO;
                    p.Dt_pedido = val.DT_Pedido;
                    p.Cd_vendedor = val.Cd_vendedor;
                    p.Nomevendedor = val.Nomevendedor;
                    TCN_LanPedido_Item.GravaPedido_Item(p, qtb_ped.Banco_Dados);
                });
                //Gravar Duplicata
                if (val.lDup.Count > 0)
                {
                    TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_ped.Banco_Dados);
                    TCN_LanPedido_X_Duplicata.Gravar(new TRegistro_LanPedido_X_Duplicata()
                    {
                        Nr_pedido = val.Nr_pedido,
                        Cd_empresa = val.CD_Empresa,
                        Nr_lancto = val.lDup[0].Nr_lancto
                    }, qtb_ped.Banco_Dados);
                }
                //Gravar Adiantamento
                val.lAdiant.ForEach(p => TCN_LanAdiantamento.Gravar(p, qtb_ped.Banco_Dados));
                //Verificar se existe Pedido possui Ordem de Carregamento
                TList_OrdemCarregamento lOrdem =
                    new TCD_OrdemCarregamento(qtb_ped.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                            "inner join TB_FAT_Ordem_X_Expedicao y " +
                                            "on x.CD_Empresa = y.CD_Empresa " +
                                            "and x.ID_Expedicao = y.ID_Expedicao " +
                                            "where a.CD_Empresa = y.CD_Empresa " +
                                            "and a.ID_Ordem = y.ID_Ordem " +
                                            "and x.Nr_pedido = " + val.Nr_pedido + " " +
                                            "and x.ID_PedidoItem = " + val.Deleta_Pedido_Itens[0].Id_pedidoitem + ") "
                            }
                        }, 0, string.Empty);
                //Excluir Ordem de Carregamento
                lOrdem.ForEach(p => TCN_OrdemCarregamento.Excluir(p, qtb_ped.Banco_Dados));
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string Consulta_Dados_Clifor(TRegistro_Pedido val)
        {
            if (val != null)
            {
                if (val.CD_Clifor != "")
                {
                    //DataTable TB_Clifor_Credito = new TCD_BloqueioCredito().BuscarDadosClifor(val.CD_Clifor);
                    //if (TB_Clifor_Credito != null)
                    //    if (TB_Clifor_Credito.Rows.Count > 0)
                    //    {
                    //        try
                    //        {
                    //            val.Limite_Credito = Convert.ToDecimal(TB_Clifor_Credito.Rows[0]["vl_limitecredito"].ToString());
                    //        }
                    //        catch { val.Limite_Credito = 0; }
                    //        try
                    //        {
                    //            val.Credito_Uso = Convert.ToDecimal(TB_Clifor_Credito.Rows[0]["vl_debito_aberto"].ToString());
                    //        }
                    //        catch { val.Credito_Uso = 0; }
                    //        try
                    //        {
                    //            val.Debito_Vencidos = Convert.ToDecimal(TB_Clifor_Credito.Rows[0]["vl_debito_vencido"].ToString());
                    //        }
                    //        catch { val.Debito_Vencidos = 0; }
                    //        val.St_bloq_debitovencido = TB_Clifor_Credito.Rows[0]["st_bloq_debitovencido"].ToString().Trim().ToUpper().Equals("S");
                    //        try
                    //        {
                    //            val.ADTO_Valor = Convert.ToDecimal(TB_Clifor_Credito.Rows[0]["VL_Adiantado"].ToString());
                    //        }
                    //        catch { val.ADTO_Valor = 0; }
                    //        try
                    //        {
                    //            val.ADTO_Devolvido = Convert.ToDecimal(TB_Clifor_Credito.Rows[0]["VL_Devolvido"].ToString());
                    //        }
                    //        catch { val.ADTO_Devolvido = 0; }
                    //    }
                }
            }
            return "";
        }

        public static void Calcula_Parcelas(TRegistro_Pedido val)
        {
            if (val.Pedido_Itens.Count > 0)
            {
                if (val.Vl_totalpedido_liquido > 0)
                {
                    if (!string.IsNullOrEmpty(val.CD_CondPGTO.Trim()))
                    {
                        TRegistro_LanDuplicata Lan_Duplicata = new TRegistro_LanDuplicata();
                        Lan_Duplicata.Qt_parcelas = val.QTD_Parcelas;
                        Lan_Duplicata.Vl_documento = val.Vl_totalpedido_liquido;
                        Lan_Duplicata.Vl_documento_padrao = val.Vl_totalpedido_liquido;
                        Lan_Duplicata.Dt_emissao = val.DT_Pedido;
                        Lan_Duplicata.Vl_entrada = val.Vl_entrada;
                        Lan_Duplicata.Vl_entrada_padrao = val.Vl_entrada;
                        Lan_Duplicata.St_comentrada = val.Parcelas_Entrada;
                        Lan_Duplicata.Qt_dias_desdobro = val.Parcelas_Dias_Desdobro;
                        Lan_Duplicata.Cd_condpgto = val.CD_CondPGTO;
                        Lan_Duplicata.St_venctoferiado = "S";

                        TList_RegLanParcela Lista_Parcela = TCN_LanDuplicata.calcularParcelas(Lan_Duplicata, null);
                        val.Pedidos_DT_Vencto.ForEach(p => val.Deleta_Pedidos_DT_Vencto.Add(p));
                        val.Pedidos_DT_Vencto.Clear();
                        Lista_Parcela.ForEach(p =>
                            {
                                val.Pedidos_DT_Vencto.Add(
                                    new TRegistro_Pedido_DT_Vencto()
                                    {
                                        Dt_vencto = p.Dt_vencto,
                                        VL_Parcela = p.Vl_parcela
                                    });
                            });
                        //Entrada
                        SetValorEntrada(val);
                    }
                }
            }
        }

        public static void SetValorEntrada(TRegistro_Pedido val)
        {
            val.Pedidos_DT_Vencto.ForEach(p => p.VL_Entrada = val.Parcelas_Entrada.Trim().ToUpper().Equals("S") ? p.VL_Parcela : decimal.Zero);
        }

        public static void Recalcula_Parcelas(TRegistro_Pedido val, int Position)
        {
            //Armazena Datas das Parcelas
            TList_Pedido_DT_Vencto Lista_Data_Parcelas = new TList_Pedido_DT_Vencto();
            for (int x = 0; x < val.Pedidos_DT_Vencto.Count; x++)
            {
                TRegistro_Pedido_DT_Vencto Reg_Data_Parcelas = new TRegistro_Pedido_DT_Vencto();
                Reg_Data_Parcelas.Dt_vencto = val.Pedidos_DT_Vencto[x].Dt_vencto;
                Lista_Data_Parcelas.Add(Reg_Data_Parcelas);
            }

            //Carrego o Duplicata para poder usar a Camada de Negocio da Duplicata
            TRegistro_LanDuplicata Lan_Duplicata = new TRegistro_LanDuplicata();
            Lan_Duplicata.Qt_parcelas = val.QTD_Parcelas;
            Lan_Duplicata.Vl_documento = val.Vl_totalpedido_liquido;//val.Pedido_Itens[0].VL_Total_Itens;
            Lan_Duplicata.Vl_documento_padrao = val.Vl_totalpedido_liquido;
            Lan_Duplicata.Vl_entrada = val.Vl_entrada;

            //Populo as Parcelas da Duplicata
            TList_RegLanParcela Lista_Parcela = new TList_RegLanParcela();
            for (int x = 0; x < val.Pedidos_DT_Vencto.Count; x++)
            {
                TRegistro_LanParcela reg_Parcela = new TRegistro_LanParcela();
                reg_Parcela.Vl_parcela = val.Pedidos_DT_Vencto[x].VL_Parcela;
                Lista_Parcela.Add(reg_Parcela);
            }

            //Retorno o List das Parcelas Calculadas 
            Lan_Duplicata.Parcelas = Lista_Parcela;
            TList_RegLanParcela Lista_Parcela_Retorno = new TList_RegLanParcela();
            Lista_Parcela_Retorno = TCN_LanDuplicata.Recalcula_Parcelas_List(Lan_Duplicata, Position);


            //Preencho as Parcelas do Pedido
            val.Pedidos_DT_Vencto.Clear();
            for (int x = 0; x < Lista_Parcela_Retorno.Count; x++)
            {
                TRegistro_Pedido_DT_Vencto Parcela_Pedido_Financeiro = new TRegistro_Pedido_DT_Vencto();
                Parcela_Pedido_Financeiro.VL_Parcela = Lista_Parcela_Retorno[x].Vl_parcela;
                Parcela_Pedido_Financeiro.Dt_vencto = Lista_Data_Parcelas[x].Dt_vencto;
                val.Pedidos_DT_Vencto.Add(Parcela_Pedido_Financeiro);
            }
            //Entrada
            SetValorEntrada(val);
        }

        public static void Busca_CFG_Fiscal(TRegistro_Pedido val)
        {
            if (val != null)
                if (!string.IsNullOrEmpty(val.CFG_Pedido))
                    val.Pedido_Fiscal = TCN_CadCFGPedidoFiscal.Buscar(val.CFG_Pedido,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      0,
                                                                      string.Empty,
                                                                      null);
        }

        public static void Rateia_Desconto_Itens(TRegistro_Pedido val, bool St_perc)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.Pedido_Itens.Sum(p => p.Vl_subtotal);
                if (!St_perc)
                    val.Pc_descgeral = Math.Round(decimal.Divide(decimal.Multiply(val.Vl_descontogeral, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                val.Pedido_Itens.FindAll(p => p.St_registro.Trim().ToUpper() != "C").ForEach(p =>
                     {
                         p.Vl_desc = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(val.Pc_descgeral, 100)), 2, MidpointRounding.AwayFromZero);
                         p.Pc_desc = val.Pc_descgeral;
                     });
                if ((!St_perc) && (val.Vl_descontogeral > val.Pedido_Itens.Sum(p => p.Vl_desc)))
                    val.Pedido_Itens.FindLast(p => p.St_registro.Trim().ToUpper() != "C").Vl_desc += val.Vl_descontogeral - val.Pedido_Itens.Sum(p => p.Vl_desc);
            }
        }

        public static void Rateia_Frete(TRegistro_Pedido val)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.Pedido_Itens.Sum(p => p.Vl_subtotal);
                val.Pedido_Itens.ForEach(p =>
                {
                    if ((tot_subtotal > decimal.Zero) && (p.St_registro != "C"))
                        p.Vl_freteitem = Math.Round((Math.Round((Math.Round(p.Vl_subtotal, 2, MidpointRounding.AwayFromZero)
                            * Math.Round(val.Vl_frete, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)
                            / Math.Round(tot_subtotal, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero);
                });
                val.Pedido_Itens.FindLast(p => p.St_registro.Trim().ToUpper() != "C").Vl_freteitem += val.Vl_frete - val.Pedido_Itens.Sum(p => p.Vl_freteitem);
            }
        }

        public static void Rateia_Acrescimo(TRegistro_Pedido val)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.Pedido_Itens.Sum(p => p.Vl_subtotal);
                val.Pedido_Itens.ForEach(p =>
                    {
                        if ((tot_subtotal > decimal.Zero) && (p.St_registro.Trim() != "C"))
                            p.Vl_acrescimo = Math.Round((Math.Round((Math.Round(p.Vl_subtotal, 2) * Math.Round(val.Vl_acrescimogeral, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) / Math.Round(tot_subtotal, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero);
                    });
                val.Pedido_Itens.FindLast(p => p.St_registro.Trim().ToUpper() != "C").Vl_acrescimo += val.Vl_acrescimogeral - val.Pedido_Itens.Sum(p => p.Vl_acrescimo);
            }
        }

        public static bool Verifica_Disponibilidade_Pedido(string Nr_pedido)
        {
            if (!string.IsNullOrEmpty(Nr_pedido.Trim()))
            {
                object obj_NR_Pedido = new TCD_LanFaturamento_Item().BuscarEscalar(
                  new TpBusca[]
                  {
                      new TpBusca()
                      {
                          vNM_Campo = "a.nr_pedido",
                          vOperador = "=",
                          vVL_Busca = Nr_pedido
                      },
                      new TpBusca()
                      {
                          vNM_Campo = "isnull(nf.st_registro, 'A')",
                          vOperador = "<>",
                          vVL_Busca = "'C'"
                      }
                  }, "1");
                return obj_NR_Pedido == null ? false : obj_NR_Pedido.ToString().Trim().Equals("1");
            }
            else
                return false;
        }

        public static bool Verifica_Pedido_Contrato(string Nr_pedido)
        {
            object obj = new CamadaDados.Graos.TCD_CadContrato().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_pedido",
                        vOperador = "=",
                        vVL_Busca = Nr_pedido
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, "1");
            if (obj != null)
                return obj.ToString().Trim().Equals("1");
            else
                return false;
        }

        public static bool Itens_Igual_Financeiro(TRegistro_Pedido val)
        {
            bool retorno = true;
            if (val != null)
            {
                val.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(val.Nr_pedido, null);
                Busca_Pedido_Itens(val, false, null);

                if ((val.Pedidos_DT_Vencto.Count > 0) && (val.Pedido_Itens.Count > 0))
                    retorno = val.Pedidos_DT_Vencto.Sum(p => p.VL_Parcela).Equals(val.Pedido_Itens.Sum(p => p.Vl_subtotal));
            }

            return retorno;
        }

        public static bool VerificaRestricaoCredito(TRegistro_Pedido val)
        {
            if (val != null)
            {
                bool retorno = false;
                if (val.TP_Movimento.Trim().ToUpper().Equals("S"))
                {
                    if (val.Limite_Credito > 0)
                        retorno = val.Saldo_Credito <= 0;
                    if (val.St_bloq_debitovencido)
                        retorno = val.Debito_Vencidos > 0;
                }
                return retorno;
            }
            else
                return false;
        }

        public static void GerarConferenciaPedido(List<TRegistro_LanPedido_Item> val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido qtb_pedido = new TCD_Pedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pedido.CriarBanco_Dados(true);
                else
                    qtb_pedido.Banco_Dados = banco;

                //Gerar conferencia
                val.ForEach(p =>
                    {
                        CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Gravar(
                            new TRegistro_EntregaPedido()
                            {
                                Cd_produto = p.Cd_produto,
                                Ds_observacao = "CONFERENCIA DO PEDIDO " + p.Nr_PedidoString,
                                Dt_entrega = null,
                                Id_entrega = null,
                                Id_pedidoitem = p.Id_pedidoitem,
                                Login = Parametros.pubLogin,
                                Nr_pedido = p.Nr_pedido,
                                Qtd_entregue = decimal.Zero
                            }, qtb_pedido.Banco_Dados);
                    });

                if (st_transacao)
                    qtb_pedido.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pedido.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar conferencia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pedido.deletarBanco_Dados();
            }
        }

        public static bool FaturarPedidoDireto(string Nr_pedido)
        {
            TList_CadCFGPedido lCfg =
                new TCD_CadCFGPedido().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                    "where x.cfg_pedido = a.cfg_pedido "+
                                    "and x.nr_pedido = " + Nr_pedido + ")"
                    }
                }, 0, string.Empty);
            return lCfg.Count.Equals(0) ? false : lCfg[0].St_valoresfixosbool && (!lCfg[0].St_permite_pedidoparcialbool);
        }

        public static void MontarFichaTecItem(string Cd_empresa,
                                              string Cd_local,
                                              TRegistro_LanPedido_Item rItem,
                                              TList_RegLanPedido_Item val)
        {
            object ds_local = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_local",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_local.Trim() + "'"
                                            }
                                        }, "a.ds_local");
            if (rItem != null)
            {
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(rItem.Cd_produto))
                {
                    //Buscar ficha tecnica do item
                    TList_FichaTecItemPed lFicha = TCN_FichaTecItemPed.Buscar(rItem.Nr_PedidoString,
                                                                              rItem.Cd_produto,
                                                                              rItem.Id_pedidoitem.ToString(),
                                                                              string.Empty,
                                                                              null);
                    lFicha.ForEach(p =>
                    {
                        p.Quantidade = Math.Round(decimal.Multiply(Math.Round(decimal.Divide(p.Quantidade, p.Qtd_itemPed), 3, MidpointRounding.AwayFromZero), rItem.Quantidade), 3, MidpointRounding.AwayFromZero);
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_item)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_item)))
                            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_item))
                            {
                                val.Add(new TRegistro_LanPedido_Item()
                                {
                                    Cd_produto = p.Cd_item,
                                    Ds_produto = p.Ds_item,
                                    Sg_unidade_est = p.Sg_unditem,
                                    Quantidade = p.Quantidade,
                                    Cd_local = Cd_local,
                                    Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                    Qtd_estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, p.Cd_item, Cd_local, null)
                                });
                                MontarFichaTecItem(Cd_empresa, Cd_local, null, val);
                            }
                            else if (val.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_item.Trim())))
                                val.Find(v => v.Cd_produto.Trim().Equals(p.Cd_item.Trim())).Quantidade += p.Quantidade;
                            else
                                val.Add(new TRegistro_LanPedido_Item()
                                {
                                    Cd_produto = p.Cd_item,
                                    Ds_produto = p.Ds_item,
                                    Sg_unidade_est = p.Sg_unditem,
                                    Quantidade = p.Quantidade,
                                    Cd_local = Cd_local,
                                    Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                    Qtd_estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, p.Cd_item, Cd_local, null)
                                });
                    });
                }
                else
                    return;
            }
            else
                val.ForEach(p =>
                {
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                    {

                        //Buscar Ficha Tecnica do Produto
                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto,
                                                                                       string.Empty,
                                                                                       null);
                        //Remover da lista
                        val.Remove(p);
                        lFicha.ForEach(v =>
                        {
                            if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_item)) &&
                                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_item)))
                                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                {
                                    val.Add(new TRegistro_LanPedido_Item()
                                    {
                                        Cd_produto = v.Cd_item,
                                        Ds_produto = v.Ds_item,
                                        Quantidade = p.Quantidade * v.Quantidade,
                                        Sg_unidade_est = v.Sg_unditem,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, v.Cd_item, Cd_local, null)
                                    });
                                    //Chamada Recursiva
                                    MontarFichaTecItem(Cd_empresa, Cd_local, null, val);
                                }
                                else if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                    val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += p.Quantidade * v.Quantidade;
                                else
                                    val.Add(new TRegistro_LanPedido_Item()
                                    {
                                        Cd_produto = v.Cd_item,
                                        Ds_produto = v.Ds_item,
                                        Quantidade = p.Quantidade * v.Quantidade,
                                        Sg_unidade_est = v.Sg_unditem,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_estoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, v.Cd_item, Cd_local, null)
                                    });
                        });
                    }
                });
        }

        public static void MontarListaSeparacaoPed(string Nr_pedido,
                                                   TList_RegLanPedido_Item val)
        {
            if (Nr_pedido != null)
            {
                TList_RegLanPedido_Item lItens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          Nr_pedido,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          false,
                                                                          null);
                lItens.ForEach(p =>
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                            {
                                val.Add(p);
                                MontarListaSeparacaoPed(null, val);
                            }
                            else if (val.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())))
                                val.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Quantidade += p.Quantidade;
                            else
                                val.Add(p);
                    });
            }
            else
                val.ForEach(p =>
                    {
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                        {
                            if (!string.IsNullOrEmpty(p.Nr_PedidoString))
                            {
                                //buscar lista ficha tecnica do pedido
                                TList_FichaTecItemPed lFicha = TCN_FichaTecItemPed.Buscar(p.Nr_PedidoString,
                                                                                          p.Cd_produto,
                                                                                          p.Id_pedidoitem.ToString(),
                                                                                          string.Empty,
                                                                                          null);
                                //Remove o item da lista
                                val.Remove(p);
                                lFicha.ForEach(v =>
                                {
                                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_item)) &&
                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_item)))
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                        {
                                            val.Add(new TRegistro_LanPedido_Item()
                                            {
                                                Cd_produto = v.Cd_item,
                                                Ds_produto = v.Ds_item,
                                                ncm = v.Ncm,
                                                Cest = v.Cest,
                                                Quantidade = v.Quantidade,
                                                Sg_unidade_est = v.Sg_unditem
                                            });
                                            //Chamada Recursiva
                                            MontarListaSeparacaoPed(null, val);
                                        }
                                        else if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                            val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += v.Quantidade;
                                        else
                                            val.Add(new TRegistro_LanPedido_Item()
                                            {
                                                Cd_produto = v.Cd_item,
                                                Ds_produto = v.Ds_item,
                                                ncm = v.Ncm,
                                                Cest = v.Cest,
                                                Quantidade = v.Quantidade,
                                                Sg_unidade_est = v.Sg_unditem
                                            });
                                });
                            }
                            else
                            {
                                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto,
                                                                                               string.Empty,
                                                                                               null);
                                //Remover da lista
                                val.Remove(p);
                                lFicha.ForEach(v =>
                                {
                                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_item)) &&
                                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_item)))
                                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                        {
                                            val.Add(new TRegistro_LanPedido_Item()
                                            {
                                                Cd_produto = v.Cd_item,
                                                Ds_produto = v.Ds_item,
                                                ncm = v.Ncmitem,
                                                Cest = v.Cestitem,
                                                Quantidade = p.Quantidade * v.Quantidade,
                                                Sg_unidade_est = v.Sg_unditem
                                            });
                                            //Chamada Recursiva
                                            MontarListaSeparacaoPed(null, val);
                                        }
                                        else if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                            val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += p.Quantidade * v.Quantidade;
                                        else
                                            val.Add(new TRegistro_LanPedido_Item()
                                            {
                                                Cd_produto = v.Cd_item,
                                                Ds_produto = v.Ds_item,
                                                ncm = v.Ncmitem,
                                                Cest = v.Cestitem,
                                                Quantidade = p.Quantidade * v.Quantidade,
                                                Sg_unidade_est = v.Sg_unditem
                                            });
                                });
                            }
                        }
                    });
        }

        public static void ImprimirPedido(TRegistro_Pedido val,
                                          CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor,
                                          CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnderecoClifor,
                                          CamadaDados.Diversos.TRegistro_CadEmpresa rEmpresa)
        {
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Parametros.pubTerminal.Trim() + "'"
                                }
                            }, "a.porta_imptick");
            if (obj == null)
                throw new Exception("Não existe porta de impressão configurada para o terminal " + Parametros.pubTerminal.Trim());

            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Abertura.txt");
            w = f.CreateText();

            int numParcela = 1;

            //Setar porta impressao
            try
            {
                w.WriteLine("******************************PEDIDO DE VENDA******************************");
                w.WriteLine("Pedido Numero: " + val.Nr_pedido + "                                 Data do Pedido: " + val.DT_Pedido_String);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("EMPRESA:  " + rEmpresa.Nm_empresa.Trim().ToUpper().FormatStringDireita(48, ' ') + "- CNPJ: " + rEmpresa.rClifor.Nr_cgc);
                w.WriteLine("ENDERECO: " + rEmpresa.Ds_endereco.Trim().ToUpper() + " - " + rEmpresa.rEndereco.Bairro.Trim() + " - " + rEmpresa.rEndereco.Numero);
                w.WriteLine("CIDADE: " + rEmpresa.rEndereco.DS_Cidade.Trim().ToUpper() + " - " + rEmpresa.rEndereco.UF + " - " + rEmpresa.rEndereco.NM_Pais);
                w.WriteLine();
                w.WriteLine("CLIENTE: " + rClifor.Nm_clifor.Trim().ToUpper() + " - CNPJ/CPF: " + (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? rClifor.Nr_cgc : rClifor.Nr_cpf));
                w.WriteLine("ENDERECO: " + rEnderecoClifor.Ds_endereco.FormatStringDireita(30, ' ') + "     N: " + rEnderecoClifor.Numero);
                w.WriteLine("BAIRRO: " + rEnderecoClifor.Bairro.Trim().ToUpper() + "    CIDADE : " + rEnderecoClifor.DS_Cidade.Trim() + " - " + rEnderecoClifor.UF.Trim() + "    FONE: " + rEnderecoClifor.Fone);
                w.WriteLine();
                w.WriteLine("PRODUTO                                QTD UND  VALOR UNIT  VAL DESC.  SUBTOTAL");
                w.WriteLine("--------------------------------------------------------------------------------");
                val.Pedido_Itens.ForEach(p =>
                {
                    w.WriteLine((p.Cd_produto.Trim() + "-" + p.Ds_produto).FormatStringDireita(32, ' '));
                    w.WriteLine(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine(" ");
                    w.WriteLine(p.Sg_unidade_est.FormatStringDireita(3, ' '));
                    w.WriteLine(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.WriteLine(p.Vl_desc.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    w.WriteLine(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine();
                    if (!string.IsNullOrEmpty(p.Ds_observacaoitem))
                        w.WriteLine(p.Ds_observacaoitem.FormatStringDireita(79, ' '));
                });
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("****************DESCONTO FRETE  TOTAL ITENS  IMPOSTO (+)  IMPOSTO (-)  TOTAL PED");
                w.WriteLine("--------------------------------------------------------------------------------");
                w.WriteLine(val.Vl_descontogeral.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(9, ' '));
                w.WriteLine(val.Vl_frete.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(7, ' '));
                w.WriteLine(val.Vl_totalItens.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(13, ' '));
                //w.WriteLine(val.Vl_impostosomar.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(13, ' '));
                //w.WriteLine(val.Vl_impostosubtrair.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(13, ' '));
                w.WriteLine(val.Vl_totalpedido.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(11, ' '));
                w.WriteLine();
                w.WriteLine();

                w.WriteLine("                             PARCELAS");
                w.WriteLine();
                w.WriteLine("PARCELA         VALOR           DATA VENCTO");
                w.WriteLine("--------------------------------------------------------------------------------");
                val.Pedidos_DT_Vencto.ForEach(p =>
                {
                    w.Write(numParcela.FormatStringEsquerda(7, ' '));
                    w.Write(p.VL_Parcela.FormatStringEsquerda(14, ' '));
                    w.Write(p.Dt_venctostr.FormatStringEsquerda(22, ' '));
                    numParcela++;
                    w.WriteLine();

                });
                w.WriteLine("--------------------------------------------------------------------------------");

                w.WriteLine();
                w.WriteLine("OBSERVACOES: " + val.DS_Observacao);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("-----------------------------------        -------------------------------------");
                w.WriteLine("CLIENTE                                    VENDEDOR                             ");
                w.WriteLine(val.NM_Clifor.Trim().ToUpper().FormatStringDireita(43, ' '));
                w.WriteLine(val.Nomevendedor.Trim().ToUpper().FormatStringDireita(47, ' '));
                w.WriteLine();
                w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                w.Write(Convert.ToChar(12));
                w.Write(Convert.ToChar(27));
                w.Write(Convert.ToChar(109));
                w.Flush();
                f.CopyTo(obj.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show("Erro impressão Pedido: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                w.Dispose();
                f = null;
            }

        }
    }

    public class TCN_AnexoPedido
    {
        public static TList_AnexoPedido Buscar(string Nr_pedido,
                                               string Id_etapa,
                                               string Id_processo,
                                               string Id_anexo,
                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (!string.IsNullOrEmpty(Id_etapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_etapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_etapa;
            }
            if (!string.IsNullOrEmpty(Id_processo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_processo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_processo;
            }
            if (!string.IsNullOrEmpty(Id_anexo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_anexo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_anexo;
            }
            return new TCD_AnexoPedido(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AnexoPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoPedido qtb_anexo = new TCD_AnexoPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else qtb_anexo.Banco_Dados = banco;
                val.Id_anexostr = CamadaDados.TDataQuery.getPubVariavel(qtb_anexo.Grava(val), "@P_ID_ANEXO");
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return val.Id_anexostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AnexoPedido val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoPedido qtb_anexo = new TCD_AnexoPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else qtb_anexo.Banco_Dados = banco;
                qtb_anexo.Deleta(val);
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }
    }
}