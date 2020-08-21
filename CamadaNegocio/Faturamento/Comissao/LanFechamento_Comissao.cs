using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.Comissao;

namespace CamadaNegocio.Faturamento.Comissao
{
    public class TCN_Fechamento_Comissao
    {
        public static TList_Fechamento_Comissao Buscar(string Id_comissao,
                                                       string Cd_empresa,
                                                       string id_viagem,
                                                       string Cd_vendedor,
                                                       string Nr_lanctofiscal,
                                                       string Id_nfitem,
                                                       string Nr_notafiscal,
                                                       string Id_cupom,
                                                       string Id_lancto,
                                                       string Id_os,
                                                       string Id_peca,
                                                       string Nr_pedido,
                                                       string Cd_produto,
                                                       string Id_pedidoitem,
                                                       string Nr_cte,
                                                       string Id_receita,
                                                       string Id_locacao,
                                                       string Id_item,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       string Faturado_ComSaldo,
                                                       string id_orcamento,
                                                       string nr_Versao,
                                                       BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(nr_Versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_Versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_Versao;
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_orcamento;
            }
            if (!string.IsNullOrEmpty(Id_comissao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_comissao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_comissao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            if (!string.IsNullOrEmpty(Nr_notafiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.nr_notafiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_notafiscal;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            if (!string.IsNullOrEmpty(Dt_ini.Replace("/", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.Replace("/", "").Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Faturado_ComSaldo)) && (Faturado_ComSaldo.Trim().ToUpper() != "T"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_comissao - a.vl_faturado";
                filtro[filtro.Length - 1].vOperador = Faturado_ComSaldo.Trim().ToUpper().Equals("F") ? "=" : ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
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
            if (!string.IsNullOrEmpty(Nr_cte))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_conhecimentofrete x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and x.nr_ctrc = " + Nr_cte + ")";
            } 
            if (!string.IsNullOrEmpty(id_viagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ctr_conhecimentofrete x " +
                                                      " join TB_FRT_Viagem_X_Frete y on x.NR_LanctoCTR = y.NR_LanctoCTR " +
                                                      " join tb_frt_viagem z on z.id_viagem = y.id_viagem " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                      "and z.id_viagem = " + id_viagem + ")" +

                                                      "or exists" +
                                                      "(select 1 from tb_frt_outrasreceitas x " +
                                                      " join tb_frt_viagem z on z.id_viagem = x.id_viagem " +
                                                      "where " +
                                                      " x.id_viagem = " + id_viagem + ")";

            }
            if (!string.IsNullOrEmpty(Id_receita))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_receita";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_receita;
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_itemloc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }

            return new TCD_Fechamento_Comissao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Fechamento_Comissao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtb_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                //Verificar se nao existe fechamento de comissao para o item
                if (val.Nr_lanctofiscal.HasValue)
                {
                    object obj = new TCD_Fechamento_Comissao(qtb_comissao.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = val.Nr_lanctofiscalstr
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_nfitem",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_nfitemstr
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        }
                                    }, "a.id_comissao");
                    if (obj != null)
                        val.Id_comissaostr = obj.ToString();
                }
                if (val.Id_cupom.HasValue)
                {
                    object obj = new TCD_Fechamento_Comissao(qtb_comissao.Banco_Dados).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_cupom",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_cupomstr
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_lancto",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_lanctostr
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_vendedor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                        }
                                    }, "a.id_comissao");
                    if (obj != null)
                        val.Id_comissaostr = obj.ToString();
                }
                if (val.Vl_comissao > decimal.Zero)
                {
                    val.Id_comissaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_comissao.Gravar(val), "@P_ID_COMISSAO");
                    //Calcular Fechamento Comissão Gerente
                    TCN_Fechamento_Comissao.CalcularComissaoGerenteXRepresentante(val, qtb_comissao.Banco_Dados);
                }
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();
                return val.Id_comissaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Fechamento_Comissao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtb_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                //Verificar se comissao possui faturamento
                if (new TCD_Comissao_X_Duplicata(qtb_comissao.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_comissao",
                            vOperador = "=",
                            vVL_Busca = val.Id_comissaostr
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir comissão que possui faturamento.");
                //Excluir transf. comissão
                TCN_TransfComissao.Buscar(val.Cd_empresa,
                                          val.Id_comissaostr,
                                          qtb_comissao.Banco_Dados).ForEach(p => TCN_TransfComissao.Excluir(p, qtb_comissao.Banco_Dados));
                qtb_comissao.Excluir(val);
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();
                return val.Id_comissaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }

        public static decimal CalcularComissao(string Cd_empresa,
                                               string Cd_vendedor,
                                               string Cd_tabelapreco,
                                               string Cd_condpgto,
                                               string Cd_produto,
                                               decimal Quantidade,
                                               ref decimal Vl_basecalc,
                                               ref decimal Pc_comissao,
                                               ref string Tp_comissao,
                                               BancoDados.TObjetoBanco banco)
        {
            decimal vl_comissao = decimal.Zero;
            //Buscar dados vendedor
            CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa lVendedor =
                CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Buscar(Cd_vendedor, Cd_empresa, banco);
            if (lVendedor.Count > 0)
            {
                if (lVendedor[0].St_recebimento)
                {
                    //Fixo por Vendedor
                    Pc_comissao = lVendedor[0].Pc_fixocomissao;
                    vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                }
                else if (!CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("GERAR_COMISSAO_METAS", Cd_empresa, banco).Equals("S"))
                {
                    //Verificar se condicao de pagamento reduz base calculo comissao
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto(banco).BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_vendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cd_vendedor.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_condpgto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Cd_condpgto.Trim() + "'"
                                    }
                                    }, "isnull(a.pc_basecalc_comissao, 0)");
                    if (obj != null)
                        if ((decimal.Parse(obj.ToString()) > decimal.Zero) &&
                            (decimal.Parse(obj.ToString()) < 100))
                            Vl_basecalc = Math.Round(Vl_basecalc * decimal.Parse(obj.ToString()) / 100, 2);
                    //Buscar Comissao Produto
                    CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd =
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo(Cd_produto, banco);
                    if (rProd.Pc_Comissao > decimal.Zero)
                    {
                        Pc_comissao = rProd.Pc_Comissao;
                        if (rProd.Tp_comissao.Trim().ToUpper().Equals("V"))
                        {
                            vl_comissao = Math.Round(Quantidade * rProd.Pc_Comissao, 5);
                            Tp_comissao = "V";
                            Vl_basecalc = Quantidade;
                        }
                        else
                            vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                    }
                    else
                    {
                        //Buscar config vendedor x Grupo Produto
                        obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_GrupoProd(banco).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_vendedor.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_est_produto x " +
                                                "where a.cd_grupo = x.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "') "
                                }
                                }, "isnull(a.pc_comissao, 0)");
                        if (obj != null)
                        {
                            Pc_comissao = decimal.Parse(obj.ToString());
                            vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                        }
                        else
                        {
                            //Buscar config vendedor x tabela preco
                            obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco(banco).BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_vendedor.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_tabelapreco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'"
                                }
                                }, "isnull(a.pc_comissao, 0)");
                            if (obj != null)
                            {
                                Pc_comissao = decimal.Parse(obj.ToString());
                                vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                            }
                            else
                            {
                                //Fixo por Vendedor
                                Pc_comissao = lVendedor[0].Pc_fixocomissao;
                                vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                            }
                        }
                    }
                }
                return vl_comissao;
            }
            return vl_comissao;
        }

        public static void ProcessarComissao(List<TRegistro_Fechamento_Comissao> lComissao,
                                             CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtb_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                //Gravar duplicata
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(rDup, false, qtb_comissao.Banco_Dados);
                //Gravar Comissao X Duplicata
                lComissao.ForEach(p => TCN_Comissao_X_Duplicata.Gravar(new TRegistro_Comissao_X_Duplicata()
                {
                    Id_comissao = p.Id_comissao,
                    Cd_empresa = p.Cd_empresa,
                    Nr_lancto = rDup.Nr_lancto,
                    Vl_faturado = p.Vl_saldofaturar
                }, qtb_comissao.Banco_Dados));
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }

        public static void ReprocessarComissao(List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lNf,
                                               List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lVenda,
                                               List<CamadaDados.Servicos.TRegistro_LanServicosPecas> lPecasOS,
                                               List<CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item> lPed,
                                               List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lCte,
                                               List<CamadaDados.Frota.TRegistro_OutrasReceitas> lReceita,
                                               List<CamadaDados.Locacao.TRegistro_ItensLocacao> lItensLocacao,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtb_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                //Reprocessar comissao Pedido
                if (lPed != null)
                    lPed.ForEach(p => Pedido.TCN_LanPedido_Item.ProcessarComissao(p, qtb_comissao.Banco_Dados));
                //Reprocessar comissao Nota Fiscal
                if (lNf != null)
                    lNf.ForEach(p => NotaFiscal.TCN_LanFaturamento_Item.ProcessarComissao(p, qtb_comissao.Banco_Dados));
                //Reprocessar comissao Venda Rapida
                if (lVenda != null)
                    lVenda.ForEach(p => PDV.TCN_VendaRapida_Item.ProcessarComissao(p, qtb_comissao.Banco_Dados));
                //Reprocessar comissao Ordem Servico
                if(lPecasOS != null)
                    lPecasOS.ForEach(p =>
                    {
                        //Verificar se ja existe comissao
                        TList_Fechamento_Comissao lComissao = Buscar(string.Empty,
                                                                     p.Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     p.Id_osstr,
                                                                     p.Id_pecastr,
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
                                                                     qtb_comissao.Banco_Dados);
                        if (lComissao.Count > 0)
                        {
                            lComissao.ForEach(x =>
                                {
                                    //Verificar se comissao possui faturamento
                                    if (new TCD_Comissao_X_Duplicata(qtb_comissao.Banco_Dados).BuscarEscalar(
                                        new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + x.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_comissao = x.id_comissao " +
                                                        "and x.id_os = " + p.Id_osstr +
                                                        "and x.id_peca = " + p.Id_pecastr + ")"
                                        }
                                    }, "1") == null)
                                    {
                                        //Excluir comissao existente
                                        Excluir(x, qtb_comissao.Banco_Dados);
                                        //Processar comissao
                                        Servicos.TCN_LanServico.ProcessarComissao(p, qtb_comissao.Banco_Dados);
                                    }
                                });
                        }
                        else
                            Servicos.TCN_LanServico.ProcessarComissao(p, qtb_comissao.Banco_Dados);
                    });
                //Reprocessar comissao CTe
                if (lCte != null)
                    lCte.ForEach(p => CTRC.TCN_ConhecimentoFrete.ProcessarComissao(p, qtb_comissao.Banco_Dados));
                //Reprocessar comissao Outras Receitas
                if (lReceita != null)
                    lReceita.ForEach(p => Frota.TCN_OutrasReceitas.ProcessarComissao(p, qtb_comissao.Banco_Dados));
                //Reprocesar Comissão Locação
                if (lItensLocacao != null)
                {
                    if (lItensLocacao.Count > 0)
                    {
                        //Buscar 
                        CamadaDados.Locacao.TList_ParcelaLocacao lParc =
                        new CamadaDados.Locacao.TCD_ParcelaLocacao(qtb_comissao.Banco_Dados).Select(
                            new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lItensLocacao[0].Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = lItensLocacao[0].Id_locacaostr
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_faturado, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 0, string.Empty);
                        if (lParc.Count > 0)
                            lParc.ForEach(x => lItensLocacao.ForEach(p => CamadaNegocio.Locacao.TCN_ItensLocacao.ProcessarComissao(p, x, qtb_comissao.Banco_Dados)));
                        else
                            lItensLocacao.ForEach(p => CamadaNegocio.Locacao.TCN_ItensLocacao.ProcessarComissao(p, null, qtb_comissao.Banco_Dados));
                    }
                }
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprocessar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }

        public static void GerarComissaoMetas(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item val,
                                              decimal Pc_comissao,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtd_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtd_comissao.CriarBanco_Dados(true);
                else qtd_comissao.Banco_Dados = banco;
                //Verificar se ja existe comissao
                TList_Fechamento_Comissao lComissao = Buscar(string.Empty,
                                                             val.Cd_empresa,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             val.Id_vendarapida.Value.ToString(),
                                                             val.Id_lanctovenda.Value.ToString(),
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
                                                             qtd_comissao.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    //Verificar se comissao possui faturamento
                    lComissao.ForEach(x =>
                    {
                        if (new TCD_Comissao_X_Duplicata(qtd_comissao.Banco_Dados).BuscarEscalar(
                            new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_comissao = x.id_comissao " +
                                                        "and x.id_cupom = " + val.Id_vendarapida +
                                                        "and x.Id_lancto = " + val.Id_lanctovenda + ")"
                                        }
                                    }, "1") == null)
                            Excluir(x, qtd_comissao.Banco_Dados);
                        else
                            throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                    });
                }
                //Vl.Base Calc
                decimal Vl_basecalc = Math.Round(val.Vl_subtotalliquido - (val.Qtd_devolvida * (val.Vl_subtotalliquido / val.Quantidade)), 2);
                decimal vl_comissao = decimal.Zero;
                //Buscar dados vendedor
                TList_Vendedor_X_Empresa lVendedor =
                    Cadastros.TCN_Vendedor_X_Empresa.Buscar(val.Cd_vendedor, val.Cd_empresa, banco);
                if (lVendedor.Count > 0)
                {
                    //Buscar Comissao Produto
                    CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd =
                        Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo(val.Cd_produto, banco);
                    if (rProd.Pc_Comissao > decimal.Zero)
                    {
                        Pc_comissao = rProd.Pc_Comissao;
                        vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                            
                    }
                    else
                    {
                        //Buscar config vendedor x Grupo Produto
                      object obj = new TCD_Vendedor_X_GrupoProd(banco).BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_est_produto x " +
                                                "where a.cd_grupo = x.cd_grupo " +
                                                "and x.cd_produto = '" + val.Cd_produto.Trim() + "') "
                                }
                            }, "isnull(a.pc_comissao, 0)");
                        if (obj != null)
                        {
                            Pc_comissao = decimal.Parse(obj.ToString());
                            vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                        }
                        else
                        {
                            //Buscar config vendedor x tabela preco
                            obj = new TCD_Vendedor_X_TabelaPreco(banco).BuscarEscalar(
                                    new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_vendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_tabelapreco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_tabelapreco.Trim() + "'"
                                }
                            }, "isnull(a.pc_comissao, 0)");
                            if (obj != null)
                            {
                                Pc_comissao = decimal.Parse(obj.ToString());
                                vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                            }
                            else
                                vl_comissao = Math.Round(Vl_basecalc * Pc_comissao / 100, 5);
                        }
                    }
                }
                if (vl_comissao > decimal.Zero)
                {
                    //Gravar fechamento comissao
                    Gravar(
                        new TRegistro_Fechamento_Comissao()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_vendedor = val.Cd_vendedor,
                            Cd_produto = val.Cd_produto,
                            Dt_lancto = val.Dt_emissao.HasValue ? val.Dt_emissao : CamadaDados.UtilData.Data_Servidor(qtd_comissao.Banco_Dados),
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Tp_comissao = "P",
                            Pc_comissao = Pc_comissao,
                            Vl_basecalc = Vl_basecalc,
                            Vl_comissao = vl_comissao
                        }, qtd_comissao.Banco_Dados);
                }
                
                if (st_transacao)
                    qtd_comissao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtd_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtd_comissao.deletarBanco_Dados();
            }
        }

        public static void CalcularComissaoGerenteXRepresentante(TRegistro_Fechamento_Comissao val,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Fechamento_Comissao qtb_comissao = new TCD_Fechamento_Comissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                //Buscar dados vendedor
                TList_Gerente_X_Vendedor lGerente =
                    Cadastros.TCN_Gerente_X_Vendedor.Buscar(string.Empty, val.Cd_vendedor, val.Cd_empresa, banco);
                if (lGerente.Count > 0)
                {
                    //Calcular vl.comissão
                    val.Id_comissao = null;
                    val.Vl_comissao = Math.Round(val.Vl_basecalc * lGerente[0].Pc_comissao / 100, 5);
                    val.Pc_comissao = lGerente[0].Pc_comissao;
                    val.Cd_vendedor = lGerente[0].Cd_gerente;
                    //Gravar Comissão
                    qtb_comissao.Gravar(val);
                }
                //Verificar se venda possui representante
                if (!string.IsNullOrEmpty(val.Cd_representante))
                {
                    //Buscar dados representante
                    TList_Vendedor_X_Empresa lRep =
                        Cadastros.TCN_Vendedor_X_Empresa.Buscar(val.Cd_representante, val.Cd_empresa, banco);
                    if (lRep.Count > 0)
                    {
                        //Calcular vl.comissão
                        val.Id_comissao = null;
                        val.Vl_comissao = Math.Round(val.Vl_basecalc * lRep[0].Pc_fixocomissao / 100, 5);
                        val.Pc_comissao = lRep[0].Pc_fixocomissao;
                        val.Cd_vendedor = val.Cd_representante;
                        //Gravar Comissão
                        qtb_comissao.Gravar(val);
                    }
                }
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
         }
    }

    public class TCN_Comissao_X_Duplicata
    {
        public static TList_Comissao_X_Duplicata Buscar(string Id_comissao,
                                                        string Cd_empresa,
                                                        string Nr_lancto,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_comissao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_comissao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_comissao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }

            return new TCD_Comissao_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanParcela BuscarParc(string Cd_empresa,
                                                                                      string Id_comissao,
                                                                                      BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanParcela(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(dup.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_comissao_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_comissao = " + Id_comissao + ")"
                    }
                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
        }

        public static string Gravar(TRegistro_Comissao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Comissao_X_Duplicata qtb_comissao = new TCD_Comissao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                string retorno = qtb_comissao.Gravar(val);
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar duplicata comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Comissao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Comissao_X_Duplicata qtb_comissao = new TCD_Comissao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_comissao.CriarBanco_Dados(true);
                else
                    qtb_comissao.Banco_Dados = banco;
                qtb_comissao.Excluir(val);
                if (st_transacao)
                    qtb_comissao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comissao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir duplicata comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_comissao.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TransfComissao
    {
        public static TList_TransfComissao Buscar(string Cd_empresa,
                                                  string Id_comissao,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_comissao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_comissao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_comissao;
            }
            return new TCD_TransfComissao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TransfComissao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfComissao qtb_transf = new TCD_TransfComissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else qtb_transf.Banco_Dados = banco;
                val.Id_transfstr = CamadaDados.TDataQuery.getPubVariavel(qtb_transf.Gravar(val), "@P_ID_TRANSF");
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
                return val.Id_transfstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar transf: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TransfComissao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfComissao qtb_transf = new TCD_TransfComissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else qtb_transf.Banco_Dados = banco;
                qtb_transf.Excluir(val);
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
                return val.Id_transfstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir transf: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }

        public static void TransfComissao(List<TRegistro_Fechamento_Comissao> lComissao,
                                          string Cd_vendTransf,
                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfComissao qtb_transf = new TCD_TransfComissao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else qtb_transf.Banco_Dados = banco;
                lComissao.ForEach(p =>
                    {
                        qtb_transf.Gravar(new TRegistro_TransfComissao()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_comissao = p.Id_comissao,
                            Cd_vendedorold = p.Cd_vendedor,
                            Logintransfvend = Utils.Parametros.pubLogin,
                            Dt_transfvend = CamadaDados.UtilData.Data_Servidor(qtb_transf.Banco_Dados)
                        });
                        p.Cd_vendedor = Cd_vendTransf;
                        new TCD_Fechamento_Comissao(qtb_transf.Banco_Dados).Gravar(p);
                    });
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar transf: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }
    }
}
