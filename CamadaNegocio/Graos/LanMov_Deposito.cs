using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaDados.Estoque;
using System.Data;
using CamadaNegocio.Estoque.Cadastros;

namespace CamadaNegocio.Graos
{
    public class TCN_MovDeposito
    {
        public static TList_MovDeposito Buscar(
                                         decimal vId_Movto,
                                         decimal vNR_Pedido,
                                         string vCD_Produto,
                                         int vTop,
                                         TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (vId_Movto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vId_Movto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vNR_Pedido > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_pedido";
                filtro[filtro.Length - 1].vVL_Busca = vNR_Pedido.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            TCD_MovDeposito qtb_MovDeposito = new TCD_MovDeposito();
            return qtb_MovDeposito.Select(filtro, vTop, "");
        }

        public static string GravarMovDeposito(TRegistro_MovDeposito vMovDep, TObjetoBanco banco)
        {                        
            bool st_transacao = false;
            TCD_MovDeposito qtb_MovDeposito = new TCD_MovDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_MovDeposito.CriarBanco_Dados(true);
                else
                    qtb_MovDeposito.Banco_Dados = banco;                
                
                string r_movDeposito = qtb_MovDeposito.Grava(vMovDep);
                vMovDep.Id_Movto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(r_movDeposito, "@P_ID_MOVTO"));
                    TCD_CadContrato qtb_contrato = new TCD_CadContrato();
                    qtb_contrato.Banco_Dados = banco;
                TList_CadContrato l = new TCD_CadContrato(qtb_MovDeposito.Banco_Dados).Select(new Utils.TpBusca[]
                                                                                                {
                                                                                                    new Utils.TpBusca 
                                                                                                    {
                                                                                                        vNM_Campo = "a.NR_Pedido",
                                                                                                        vOperador = "=",
                                                                                                        vVL_Busca = vMovDep.Nr_Pedido.ToString()
                                                                                                    },
                                                                                                    new Utils.TpBusca
                                                                                                    {
                                                                                                        vNM_Campo = "a.CD_Produto",
                                                                                                        vOperador = "=",
                                                                                                        vVL_Busca = "'" + vMovDep.CD_Produto.Trim() + "'"
                                                                                                    },
                                                                                                    new Utils.TpBusca()
                                                                                                    {
                                                                                                        vNM_Campo = "a.id_pedidoitem",
                                                                                                        vOperador = "=",
                                                                                                        vVL_Busca = vMovDep.Id_pedidoitem.ToString()
                                                                                                    }
                                                                                                }, 1, string.Empty);
                    
                if (l.Count > 0)
                {
                        //Gravar SaldoCarenciaTaxa
                        List<TRegistro_EstDeposito> vEstoqueDeposito = qtb_MovDeposito.Buscar_EstDeposito(vMovDep.CD_Empresa, vMovDep.CD_Produto, vMovDep.Id_LanctoEstoque);
                        //Gravar Taxa de Armazenagem do Contrato
                        GravarSaldoCarenciaTaxa(vMovDep ,l[0] ,vEstoqueDeposito ,banco);
                }

                if (st_transacao)
                    qtb_MovDeposito.Banco_Dados.Commit_Tran();

                return r_movDeposito;
            }
            catch(Exception ex) 
            {
                if (st_transacao)
                    qtb_MovDeposito.Banco_Dados.RollBack_Tran();

                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_MovDeposito.deletarBanco_Dados();
            }            
        }

        public static void ReprocessarTaxasContrato(CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item rPedItem, 
                                                    Utils.ThreadEspera tEspera,
                                                    TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovDeposito qtb_mov = new TCD_MovDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                if (tEspera != null)
                    tEspera.Msg("Buscar estoques amarrados ao contrato...");
                //Buscar todos os estoques amarrados a este item do pedido
                CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item_X_Estoque lItemEstoque =
                    CamadaNegocio.Faturamento.Pedido.TCN_LanPedidoItem_X_Estoque.Buscar(rPedItem.Nr_PedidoString,
                                                                                        rPedItem.Cd_produto,
                                                                                        rPedItem.Id_pedidoitem.ToString(),
                                                                                        qtb_mov.Banco_Dados);
                if (lItemEstoque.Count > 0)
                {
                    if (tEspera != null)
                    {
                        tEspera.Msg("Excluindo movimentaçao de deposito...");
                        tEspera.Msg("Excluindo taxas de deposito...\r\n"+
                                    "(Serão excluidas somente as taxas que não foram processadas e que não seja lançado manual.)");
                    }
                    lItemEstoque.ForEach(p =>
                        {
                            //Buscar lancto taxa deposito
                            TList_TaxaDeposito lTaxas = new TCD_LanTaxaDeposito(qtb_mov.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_gro_saldocarenciataxa x " +
                                                    "inner join tb_gro_movdeposito y " +
                                                    "on x.id_movto = y.id_movto " +
                                                    "where x.id_lantaxa = a.id_lantaxa " +
                                                    "and y.nr_pedido = " + p.Nr_Pedido.ToString() + " " +
                                                    "and y.cd_produto = '" + p.CD_Produto.Trim() + "' " +
                                                    "and y.id_pedidoitem = " + p.Id_pedidoitem.ToString() + " " +
                                                    "and y.cd_empresa = '" + p.CD_Empresa.Trim() + "' " +
                                                    "and y.id_lanctoestoque = " + p.ID_LanctoEstoque.ToString() + ")"
                                    }
                                }, 0, string.Empty);
                            if (lTaxas.Count > 0)
                            {
                                if (!lTaxas.Exists(v => v.St_registro.Trim().ToUpper().Equals("P")))
                                {
                                    //Excluir saldo carencia
                                        new TCD_SaldoCarenciaTaxa(qtb_mov.Banco_Dados).Select(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_gro_movdeposito x "+
                                                        "where x.id_movto = a.id_movto "+
                                                        "and x.nr_pedido = "+p.Nr_Pedido.ToString()+" "+
                                                        "and x.cd_produto = '"+p.CD_Produto.Trim() + "' "+
                                                        "and x.id_pedidoitem = "+p.Id_pedidoitem.ToString()+" "+
                                                        "and x.cd_empresa = '"+p.CD_Empresa.Trim() + "' "+
                                                        "and x.id_lanctoestoque = "+p.ID_LanctoEstoque.ToString()+")"
                                        }
                                    }, 0, string.Empty).ForEach(v => new TCD_SaldoCarenciaTaxa(qtb_mov.Banco_Dados).Deleta(v));
                                    //Excluir Movto Deposito
                                        new TCD_MovDeposito(qtb_mov.Banco_Dados).Select(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_Pedido.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.CD_Produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pedidoitem",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_pedidoitem.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.CD_Empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lanctoestoque",
                                            vOperador = "=",
                                            vVL_Busca = p.ID_LanctoEstoque.ToString()
                                        }
                                    }, 0, string.Empty).ForEach(v => TCN_MovDeposito.DeletarMovDeposito(v, qtb_mov.Banco_Dados));
                                    //Excluir lancto taxa deposito
                                    lTaxas.ForEach(v =>
                                        {
                                            //Somente se a taxa for automatica
                                            if(v.Tp_Lancto.Trim().ToUpper().Equals("A"))
                                                new TCD_LanTaxaDeposito(qtb_mov.Banco_Dados).Excluir(v);
                                        });
                                    //Chamar metodo GravarMovDeposito
                                    GravarMovDeposito(new TRegistro_MovDeposito()
                                    {
                                        Id_Movto = 0,
                                        Nr_Pedido = p.Nr_Pedido,
                                        CD_Produto = p.CD_Produto,
                                        CD_Empresa = p.CD_Empresa,
                                        Id_LanctoEstoque = p.ID_LanctoEstoque,
                                        Id_pedidoitem = p.Id_pedidoitem
                                    }, qtb_mov.Banco_Dados);
                                }
                            }
                            else
                            {
                                //Excluir saldo carencia
                                    new TCD_SaldoCarenciaTaxa(qtb_mov.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_gro_movdeposito x "+
                                                        "where x.id_movto = a.id_movto "+
                                                        "and x.nr_pedido = "+p.Nr_Pedido.ToString()+" "+
                                                        "and x.cd_produto = '"+p.CD_Produto.Trim() + "' "+
                                                        "and x.id_pedidoitem = "+p.Id_pedidoitem.ToString()+" "+
                                                        "and x.cd_empresa = '"+p.CD_Empresa.Trim() + "' "+
                                                        "and x.id_lanctoestoque = "+p.ID_LanctoEstoque.ToString()+")"
                                        }
                                    }, 0, string.Empty).ForEach(v => new TCD_SaldoCarenciaTaxa(qtb_mov.Banco_Dados).Deleta(v));
                                //Excluir Movto Deposito
                                    new TCD_MovDeposito(qtb_mov.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_pedido",
                                            vOperador = "=",
                                            vVL_Busca = p.Nr_Pedido.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.CD_Produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_pedidoitem",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_pedidoitem.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.CD_Empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lanctoestoque",
                                            vOperador = "=",
                                            vVL_Busca = p.ID_LanctoEstoque.ToString()
                                        }
                                    }, 0, string.Empty).ForEach(v => TCN_MovDeposito.DeletarMovDeposito(v, qtb_mov.Banco_Dados));
                                    //Chamar metodo GravarMovDeposito
                                    GravarMovDeposito(new TRegistro_MovDeposito()
                                    {
                                        Id_Movto = 0,
                                        Nr_Pedido = p.Nr_Pedido,
                                        CD_Produto = p.CD_Produto,
                                        CD_Empresa = p.CD_Empresa,
                                        Id_LanctoEstoque = p.ID_LanctoEstoque,
                                        Id_pedidoitem = p.Id_pedidoitem
                                    }, qtb_mov.Banco_Dados);
                            }
                        });
                    if (st_transacao)
                        qtb_mov.Banco_Dados.Commit_Tran();
                }
                else
                    throw new Exception("Não existe estoque amarrado ao item do pedido para reprocessar taxas.");
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprocessar taxas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static decimal FaturarTaxasContrato(CamadaDados.Balanca.TRegistro_PedidoAplicacao rPedAplic, 
                                                                                           List<TRegistro_TaxaDeposito> lTaxas,
                                                                                           string Tp_taxa,
                                                                                           CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat,
                                                                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTaxaDeposito qtb_taxa = new TCD_LanTaxaDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                if (lTaxas.Count > 0)
                {
                    //Buscar configuracao para o tipo de taxa que esta sendo faturada
                    CamadaDados.Graos.TList_CFGTaxa CfgTaxa = CamadaNegocio.Graos.TCN_CFGTaxa.Buscar(Tp_taxa,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     qtb_taxa.Banco_Dados);
                    if (CfgTaxa.Count.Equals(0))
                        throw new Exception("Não existe configuração para o tipo de taxa.");
                    decimal retorno = decimal.Zero;
                    if (Tp_taxa.Trim().ToUpper().Equals("V"))
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                        //Criar pedido para faturar
                        rPed.CD_Empresa = rPedAplic.Cd_empresa;
                        rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                        rPed.CFG_Pedido = CfgTaxa[0].Cfg_pedido;
                        rPed.TP_Movimento = "S"; //Pedido de entrada
                        rPed.ST_Pedido = "F"; //Pedido fechado
                        rPed.ST_Registro = "F"; //Pedido fechado
                        rPed.CD_Clifor = rPedAplic.Cd_clifor;
                        rPed.CD_Endereco = rPedAplic.Cd_endereco;
                        rPed.Cd_moeda = CfgTaxa[0].Cd_moeda;
                        //Criar itens do pedido
                        rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                        {
                            Cd_Empresa = rPedAplic.Cd_empresa,
                            Cd_local = rPedAplic.Cd_local,
                            Cd_produto = CfgTaxa[0].Cd_produto.Trim() != string.Empty ? CfgTaxa[0].Cd_produto : rPedAplic.Cd_produto,
                            Ds_produto = CfgTaxa[0].Cd_produto.Trim() != string.Empty ? CfgTaxa[0].Ds_produto : rPedAplic.Ds_produto,
                            Cd_unidade_est = (Tp_taxa.Trim().ToUpper().Equals("P") ? rPedAplic.Cd_unidade_estoque : CfgTaxa[0].Cd_unidproduto),
                            Cd_unidade_valor = (Tp_taxa.Trim().ToUpper().Equals("P") ? rPedAplic.Cd_unidade : CfgTaxa[0].Cd_unidproduto),
                            Quantidade = (Tp_taxa.Trim().ToUpper().Equals("P") ? lTaxas.Sum(p => p.Ps_Taxa) : 1),
                            Vl_unitario = (Tp_taxa.Trim().ToUpper().Equals("P") ? rPedAplic.Vl_unitario : lTaxas.Sum(p => p.Vl_Taxa)),
                            Vl_subtotal = (Tp_taxa.Trim().ToUpper().Equals("P") ? lTaxas.Sum(p => p.Ps_Taxa) * rPedAplic.Vl_unitario : lTaxas.Sum(p => p.Vl_Taxa))
                        });
                        //Gravar pedido
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, qtb_taxa.Banco_Dados);
                        lTaxas.ForEach(p =>
                            {
                                //Gravar taxa x pedido item
                                TCN_Taxa_X_PedidoItem.Gravar(new TRegistro_Taxa_X_PedidoItem()
                                {
                                    Cd_produto = rPed.Pedido_Itens[0].Cd_produto,
                                    Id_lantaxa = p.Id_LanTaxa,
                                    Id_pedidoitem = rPed.Pedido_Itens[0].Id_pedidoitem,
                                    Nr_pedido = rPed.Nr_pedido
                                }, qtb_taxa.Banco_Dados);
                                //Alterar status das taxas para P - Processado
                                p.St_registro = "P";
                                qtb_taxa.Gravar(p);
                            });
                        retorno = rPed.Nr_pedido;
                    }
                    else if (rFat != null)
                    {
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, false, null, qtb_taxa.Banco_Dados);
                        lTaxas.ForEach(p =>
                            {
                                //Gravar Taxa X Nota Fiscal
                                TCN_FatQuebraTec.Gravar(new TRegistro_FatQuebraTec()
                                {
                                    Cd_empresa = rFat.Cd_empresa,
                                    Nr_lanctofiscal = rFat.Nr_lanctofiscal,
                                    Id_nfitem = rFat.ItensNota[0].Id_nfitem,
                                    Id_lantaxa = p.Id_LanTaxa
                                }, qtb_taxa.Banco_Dados);
                                //Alterar status das taxas para P - Processado
                                p.St_registro = "P";
                                qtb_taxa.Gravar(p);
                            });
                        retorno = rFat.Nr_lanctofiscal.Value;
                    }
                    if(st_transacao)
                        qtb_taxa.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                else
                    throw new Exception("Não existe taxas para faturar.");
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro faturar taxas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }

        private static void CalcularTaxasEntrada(TRegistro_EstDeposito rEstDeposito,
                                                 TRegistro_CadContratoTaxaDeposito rTaxa,
                                                 TRegistro_CadContrato vContrato,
                                                 TRegistro_MovDeposito vMovDep,
                                                 TList_SaldoCarenciaTaxa lSaldoCarencia,
                                                 TObjetoBanco banco)
        {
            //Converter quantidade que esta entradando para unidade da taxa
            decimal QTD_Convertida = TCN_CadConvUnidade.ConvertUnid(rEstDeposito.CD_Unidade, rTaxa.Cd_unidadetaxa, rEstDeposito.QTD_Entrada, 3, banco);
            decimal? vID_LanTaxa = null;
            //se for uma taxa que somente sera cobrada com classificacao limitada por faixa
            if (!string.IsNullOrEmpty(rTaxa.Cd_tipoamostra))
            {
                //se for um lancto por balanca/aplicacao testar os limites de classificacao para taxar ou nao
                if ((rEstDeposito.ID_Ticket > 0) && (!string.IsNullOrEmpty(rEstDeposito.CD_Empresa)))
                {
                    rEstDeposito.Classif.ForEach(x =>
                    {
                        if (rTaxa.Cd_tipoamostra.Trim().Equals(x.Cd_tipoamostra))
                        {
                            if ((x.Pc_resultado_local >= rTaxa.Pc_result_maiorque) && (x.Pc_resultado_local <= rTaxa.Pc_result_menorque))
                            {
                                if ((rTaxa.St_gerartxsomente.Trim().ToUpper().Equals("R") ? "E" : "S").Equals(rEstDeposito.Tp_Movimento.Trim().ToUpper()))
                                    vID_LanTaxa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(
                                        TCN_LanTaxas_Deposito.Gravar(new TRegistro_TaxaDeposito()
                                        {
                                            Cd_empresa = rEstDeposito.CD_Empresa,
                                            Id_ticket = rEstDeposito.ID_Ticket,
                                            Tp_pesagem = rEstDeposito.Tp_Pesagem,
                                            Id_LanTaxa = decimal.Zero,
                                            Nr_Contrato = rTaxa.Nr_contrato.Value,
                                            Cd_produto = vContrato.Cd_produto,
                                            Id_Reg = rTaxa.Id_reg,
                                            Id_Taxa = rTaxa.Id_taxa.Value,
                                            DT_Lancto = rEstDeposito.DT_Lancto,
                                            Ps_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("P") ? Math.Round(QTD_Convertida * rTaxa.Valortaxa / 100, 0) : 0),
                                            Vl_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("V") ? QTD_Convertida * rTaxa.Valortaxa : 0),
                                            Tp_Lancto = "A",
                                            D_c = "D"
                                        }, banco), "@P_ID_LANTAXA"));
                            }
                        }
                    });
                }
            }
            else
            {
                if ((rTaxa.St_gerartxsomente.Trim().ToUpper().Equals("R") ? "E" : "S").Equals(rEstDeposito.Tp_Movimento.Trim().ToUpper()))
                {
                    vID_LanTaxa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(
                        TCN_LanTaxas_Deposito.Gravar(new TRegistro_TaxaDeposito()
                        {
                            Cd_empresa = rEstDeposito.CD_Empresa,
                            Id_ticket = rEstDeposito.ID_Ticket,
                            Tp_pesagem = rEstDeposito.Tp_Pesagem,
                            Id_LanTaxa = 0,
                            Nr_Contrato = rTaxa.Nr_contrato.Value,
                            Cd_produto = vContrato.Cd_produto,
                            Id_Reg = rTaxa.Id_reg,
                            Id_Taxa = rTaxa.Id_taxa.Value,
                            DT_Lancto = rEstDeposito.DT_Lancto,
                            Ps_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("P") ? Math.Round(QTD_Convertida * rTaxa.Valortaxa / 100, 0) : 0),
                            Vl_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("V") ? QTD_Convertida * rTaxa.Valortaxa : 0),
                            Tp_Lancto = "A",
                            D_c = "D"
                        }, banco), "@P_ID_LANTAXA"));
                }
            }
            if (!lSaldoCarencia.Exists(q => q.Id_Taxa.Equals(rTaxa.Id_taxa.Value) && q.Id_Movto.Equals(vMovDep.Id_Movto)))
                lSaldoCarencia.Add(new TRegistro_SaldoCarenciaTaxa()
                {
                    Id_Taxa = rTaxa.Id_taxa.Value,
                    Id_Movto = vMovDep.Id_Movto,
                    Id_LanTaxa = vID_LanTaxa,
                    QTD_Lancto = rEstDeposito.QTD_Entrada,
                    DT_Saldo = rEstDeposito.DT_Lancto,
                    ST_Carencia = "N"
                });
            else if (vID_LanTaxa != null)
                if (lSaldoCarencia.Exists(q => q.Id_Taxa.Equals(rTaxa.Id_taxa.Value) && q.Id_Movto.Equals(vMovDep.Id_Movto) && (q.Id_LanTaxa == null)))
                    lSaldoCarencia.Find(q => q.Id_Taxa.Equals(rTaxa.Id_taxa.Value) && q.Id_Movto.Equals(vMovDep.Id_Movto) && (q.Id_LanTaxa == null)).Id_LanTaxa = vID_LanTaxa;
        }

        private static void CalcularTaxasExpedicao(TRegistro_EstDeposito rEstDeposito,
                                                   TRegistro_CadContratoTaxaDeposito rTaxa,
                                                   TRegistro_CadContrato vContrato,
                                                   TRegistro_MovDeposito vMovDep,
                                                   TList_SaldoCarenciaTaxa lSaldoCarencia,
                                                   TObjetoBanco banco)
        {
            decimal? vID_LanTaxa = null;
            List<TRegistro_ViewSaldoCarencia> SaldoCarencia =
                            new TCD_SaldoCarenciaTaxa(banco).BuscarSaldoCarencia(vMovDep.CD_Empresa,
                                                                                 rTaxa.Id_taxastr,
                                                                                 rTaxa.Nr_contratostr,
                                                                                 vMovDep.CD_Produto);

            decimal tmpSaldoExp = rEstDeposito.QTD_Saida;
            decimal tmpSaldoLan = decimal.Zero;
            decimal tmpTotDiasExpirado = decimal.Zero;
            foreach (TRegistro_ViewSaldoCarencia rSaldoCarencia in SaldoCarencia)
            {
                if (tmpSaldoExp > 0)
                {
                    if (rSaldoCarencia.Tot_Saldo >= tmpSaldoExp)
                        tmpSaldoLan = tmpSaldoExp;
                    else
                        tmpSaldoLan = rSaldoCarencia.Tot_Saldo;
                    tmpTotDiasExpirado = rEstDeposito.DT_Lancto.Subtract(rSaldoCarencia.DT_Saldo.Date).Subtract(TimeSpan.FromDays(Convert.ToDouble(rTaxa.Periodocarencia.ToString()))).Days;

                    decimal QTD_Convertida = TCN_CadConvUnidade.ConvertUnid(rEstDeposito.CD_Unidade, rTaxa.Cd_unidadetaxa, tmpSaldoLan, 3, banco);
                    if ((tmpTotDiasExpirado > 0) && (rTaxa.St_gerartxsomente.Trim().ToUpper().Equals("R") ? "E" : "S").Equals(rEstDeposito.Tp_Movimento.Trim().ToUpper()))
                    {
                        decimal m = ((tmpTotDiasExpirado % rTaxa.Frequencia) > 0 ? 1 : 0);
                        decimal t = (Math.Floor(tmpTotDiasExpirado / rTaxa.Frequencia) + m);
                        decimal k = (rTaxa.Frequencia > 0 ? t : 1);

                        vID_LanTaxa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(
                            TCN_LanTaxas_Deposito.Gravar(new TRegistro_TaxaDeposito()
                                {
                                    Cd_empresa = rEstDeposito.CD_Empresa,
                                    Id_ticket = rEstDeposito.ID_Ticket,
                                    Tp_pesagem = rEstDeposito.Tp_Pesagem,
                                    Id_LanTaxa = 0,
                                    Nr_Contrato = rTaxa.Nr_contrato.Value,
                                    Cd_produto = vContrato.Cd_produto,
                                    Id_Reg = rTaxa.Id_reg,
                                    Id_Taxa = rTaxa.Id_taxa.Value,
                                    DT_Lancto = rEstDeposito.DT_Lancto,
                                    Ps_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("P") ? Math.Round(tmpSaldoLan * rTaxa.Valortaxa * k / 100, 0) : 0),
                                    Vl_Taxa = (rTaxa.Tp_taxa.Trim().ToUpper().Equals("V") ? QTD_Convertida * rTaxa.Valortaxa * k : 0),
                                    Tp_Lancto = "A",
                                    D_c = "D"
                                }, banco), "@P_ID_LANTAXA"));
                    }
                    //Controlar saldo
                    tmpSaldoExp -= tmpSaldoLan;
                    rSaldoCarencia.Tot_Saldo -= tmpSaldoLan;
                    lSaldoCarencia.Add(new TRegistro_SaldoCarenciaTaxa()
                    {
                        Id_Taxa = rTaxa.Id_taxa.Value,
                        Id_Movto = vMovDep.Id_Movto,
                        Id_LanTaxa = vID_LanTaxa,
                        QTD_Lancto = tmpSaldoLan,
                        DT_Saldo = rSaldoCarencia.DT_Saldo,
                        ST_Carencia = "N"
                    });
                    vID_LanTaxa = null;
                }
                else
                    break;
            }
        }

        private static string GravarSaldoCarenciaTaxa(TRegistro_MovDeposito vMovDep, 
                                                     TRegistro_CadContrato vContrato, 
                                                     List<TRegistro_EstDeposito> lEstDeposito,
                                                     TObjetoBanco banco)
        {
            string retorno = string.Empty;
            lEstDeposito.ForEach(p =>
            {
                //Buscar lista de taxas configuradas para o contrato
                TCD_CadContratoTaxaDeposito qtb_taxa = new TCD_CadContratoTaxaDeposito();
                qtb_taxa.Banco_Dados = banco;
                TList_CadContratoTaxaDeposito lTaxasContrato = new TCD_CadContratoTaxaDeposito(qtb_taxa.Banco_Dados).Select(
                    new TpBusca[]                            
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.Nr_Contrato", 
                                    vOperador = "=", 
                                    vVL_Busca = vContrato.Nr_contrato.ToString()
                                }
                            }, 0, string.Empty);

                TList_SaldoCarenciaTaxa lSaldoCarencia = new TList_SaldoCarenciaTaxa();
                lTaxasContrato.ForEach(v =>
                {
                    //Se for Entrada de Produtos em deposito
                    if (p.Tp_Movimento.Trim().ToUpper().Equals("E"))
                        CalcularTaxasEntrada(p,
                                             v,
                                             vContrato,
                                             vMovDep,
                                             lSaldoCarencia,
                                             qtb_taxa.Banco_Dados);
                    else  //EXPEDICAO
                        CalcularTaxasExpedicao(p,
                                               v,
                                               vContrato,
                                               vMovDep,
                                               lSaldoCarencia,
                                               qtb_taxa.Banco_Dados);
                });
                lSaldoCarencia.ForEach(i => new TCD_SaldoCarenciaTaxa(banco).Grava(i));
            });
            return retorno;
        }
                
        public static TList_TaxaDeposito CalcularTaxasExpedicaoPendentes(string Cd_empresa,
                                                                         string Nr_contrato,
                                                                         string Cd_produto,
                                                                         DateTime Dt_calctaxa,
                                                                         string Id_taxa)
        {
            //Buscar lista de taxas de expedicao configurada para o contrato
            TList_CadContratoTaxaDeposito lTaxasContrato = new TCD_CadContratoTaxaDeposito().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.nr_contrato",
                                                                    vOperador = "=",
                                                                    vVL_Busca = Nr_contrato
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.st_gerartxsomente",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'E'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.id_taxa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = string.IsNullOrEmpty(Id_taxa) ? "a.id_taxa" : Id_taxa
                                                                }
                                                            }, 0, string.Empty);
            TList_TaxaDeposito lTaxaDeposito = new TList_TaxaDeposito();
            lTaxasContrato.ForEach(p =>
                {
                    //Para cada taxa buscar saldo carencia
                    List<TRegistro_ViewSaldoCarencia> SaldoCarencia =
                            new TCD_SaldoCarenciaTaxa().BuscarSaldoCarencia(Cd_empresa,
                                                                            p.Id_taxastr,
                                                                            p.Nr_contratostr,
                                                                            Cd_produto);
                    decimal tmpTotDiasExpirado = decimal.Zero;
                    SaldoCarencia.ForEach(v =>
                        {
                            tmpTotDiasExpirado = Dt_calctaxa.Subtract(v.DT_Saldo.Date).Subtract(TimeSpan.FromDays(Convert.ToDouble(p.Periodocarencia.ToString()))).Days;
                            if (tmpTotDiasExpirado > 0)
                            {
                                //Buscar unidade do estoque
                                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_produto",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Cd_produto.Trim() + "'"
                                                }
                                            }, "a.cd_unidade");
                                if (obj == null)
                                    throw new Exception("Produto " + Cd_produto.Trim() + " sem unidade cadastrada.");
                                decimal QTD_Convertida = TCN_CadConvUnidade.ConvertUnid(obj.ToString(), p.Cd_unidadetaxa, v.Tot_Saldo, 3, null);
                                decimal m = ((tmpTotDiasExpirado % p.Frequencia) > 0 ? 1 : 0);
                                decimal t = (Math.Floor(tmpTotDiasExpirado / p.Frequencia) + m);
                                decimal k = (p.Frequencia > 0 ? t : 1);

                                lTaxaDeposito.Add(new TRegistro_TaxaDeposito()
                                {
                                    Id_LanTaxa = 0,
                                    Nr_Contrato = p.Nr_contrato.Value,
                                    Cd_produto = Cd_produto,
                                    Id_Reg = p.Id_reg,
                                    Id_Taxa = p.Id_taxa.Value,
                                    Ds_taxa = p.Ds_taxa,
                                    Sigla_produto = p.Sg_unidadetaxa,
                                    DT_Lancto = v.DT_Saldo,
                                    Ps_Taxa = (p.Tp_taxa.Trim().ToUpper().Equals("P") ? Math.Round(v.Tot_Saldo * p.Valortaxa * k / 100, 0) : 0),
                                    Vl_Taxa = (p.Tp_taxa.Trim().ToUpper().Equals("V") ? QTD_Convertida * p.Valortaxa * k : 0),
                                    Tp_Lancto = "A",
                                    D_c = "D"
                                });
                            }
                        });
                });
            List<TRegistro_TaxaDeposito> lTaxa = lTaxaDeposito.OrderBy(p => p.DT_Lancto).ToList();
            lTaxaDeposito.Clear();
            lTaxa.ForEach(p => lTaxaDeposito.Add(p));
            return lTaxaDeposito;
        }

        public static string DeletarMovDeposito(TRegistro_MovDeposito val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovDeposito Qtb_MovDeposito = new TCD_MovDeposito();
            try
            {
                if (banco == null)
                    st_transacao = Qtb_MovDeposito.CriarBanco_Dados(true);
                else
                    Qtb_MovDeposito.Banco_Dados = banco;
                //Deletar Movimento Deposito
                Qtb_MovDeposito.Deleta(val);
                if (st_transacao)
                    Qtb_MovDeposito.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    Qtb_MovDeposito.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    Qtb_MovDeposito.deletarBanco_Dados();
            }
        }
    }
}
