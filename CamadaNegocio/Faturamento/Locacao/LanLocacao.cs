using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.Locacao;

namespace CamadaNegocio.Faturamento.Locacao
{
    public class TCN_Locacao
    {
        public static TList_Locacao buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Cd_clifor,
                                             string vTp_data,
                                             string vDt_ini,
                                             string vDt_fin,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_locacao" : vTp_data.Trim().ToUpper().Equals("R") ? "a.dt_retirada" :
                     vTp_data.Trim().ToUpper().Equals("P") ? "a.dt_prevdevolucao" : vTp_data.Trim().ToUpper().Equals("D") ? "a.dt_devolucao" : "a.dt_saient") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_locacao" : vTp_data.Trim().ToUpper().Equals("R") ? "a.dt_retirada" :
                     vTp_data.Trim().ToUpper().Equals("P") ? "a.dt_prevdevolucao" : vTp_data.Trim().ToUpper().Equals("D") ? "a.dt_devolucao" : "a.dt_saient") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Locacao(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.Id_locacaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_LOCACAO");
                val.lItensDel.ForEach(p => TCN_ItensLocacao.Excluir(p, qtb_locacao.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    p.Id_locacao = val.Id_locacao;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_ItensLocacao.Gravar(p, qtb_locacao.Banco_Dados);
                });
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_locacaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                val.lItensDel.ForEach(p => TCN_ItensLocacao.Excluir(p, qtb_loc.Banco_Dados));
                val.lItens.ForEach(p => TCN_ItensLocacao.Excluir(p, qtb_loc.Banco_Dados));
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return val.Id_locacaostr;
            }catch (Exception ex)
            {
                if(st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir locacao: " + ex.Message.Trim());
            }finally
            {
                if(st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void EstornaRetirada(TRegistro_Locacao val,
                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Verificar se a pre venda esta faturada
                CamadaDados.Faturamento.PDV.TList_ItensPreVenda lItemPreVenda =
                    new CamadaDados.Faturamento.PDV.TCD_ItensPreVenda(qtb_locacao.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_locacao_x_prevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.id_itemprevenda = a.id_itemprevenda " +
                                        "and isnull(x.tp_locacao, 'R') = 'R' " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_locacao = " + val.Id_locacaostr + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.id_itemprevenda = a.id_itemprevenda)"
                        }
                    }, 0, string.Empty);
                if (lItemPreVenda.Count.Equals(0))
                    throw new Exception("Locação possui pre venda faturada.\r\nObrigatorio estornar faturamento da pre venda primeiro.");
                //Excluir Locacao X PreVenda
                TCN_Locacao_X_PreVenda.Excluir(new TRegistro_Locacao_X_PreVenda()
                {
                    Cd_empresa = val.Cd_empresa,
                    Id_locacao = val.Id_locacao,
                    Id_prevenda = lItemPreVenda[0].Id_prevenda,
                    Id_itemprevenda = lItemPreVenda[0].Id_itemprevenda
                }, qtb_locacao.Banco_Dados);
                //Excluir item pre venda
                CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Excluir(lItemPreVenda[0], qtb_locacao.Banco_Dados);
                //Verificar se existe mais itens na pre venda
                CamadaDados.Faturamento.PDV.TList_PreVenda lPreVenda =
                    new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_locacao.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lItemPreVenda[0].Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_prevenda",
                            vOperador = "=",
                            vVL_Busca = lItemPreVenda[0].Id_prevendastr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdv_itensprevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda)"
                        }
                    }, 0, string.Empty, string.Empty);
                if (lPreVenda.Count > 0)
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(lPreVenda, qtb_locacao.Banco_Dados);
                //Cancelar estoque
                val.lItens.ForEach(p =>
                    {
                        new CamadaDados.Estoque.TCD_LanEstoque(qtb_locacao.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_itenslocacao_x_estoque x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_locacao = " + p.Id_locacaostr + " " +
                                                "and x.id_item = " + p.Id_itemstr + ")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(v =>
                                {
                                    //Cancelar o estoque
                                    CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(v, qtb_locacao.Banco_Dados);
                                    //Excluir ItemLocacao X Estoque
                                    TCN_ItensLocacao_X_Estoque.Excluir(new TRegistro_ItensLocacao_X_Estoque()
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Id_locacao = p.Id_locacao,
                                        Id_item = p.Id_item,
                                        Cd_produto = v.Cd_produto,
                                        Id_lanctoestoque = v.Id_lanctoestoque
                                    }, qtb_locacao.Banco_Dados);
                                });
                    });
                //Mudar status locacao Aberta
                val.St_registro = "A";
                val.Dt_retirada = null;
                qtb_locacao.Gravar(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static void EstornaDevolucao(TRegistro_Locacao val,
                                            BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Verificar se a pre venda esta faturada
                CamadaDados.Faturamento.PDV.TList_ItensPreVenda lItemPreVenda =
                    new CamadaDados.Faturamento.PDV.TCD_ItensPreVenda(qtb_locacao.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_locacao_x_prevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.id_itemprevenda = a.id_itemprevenda " +
                                        "and isnull(x.tp_locacao, 'R') = 'M' " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_locacao = " + val.Id_locacaostr + ")"
                        }
                    }, 0, string.Empty);
                if (lItemPreVenda.Count > 0)
                {
                    //Verificar se esta pre venda esta faturada
                    if(new CamadaDados.Faturamento.PDV.TCD_PreVenda_X_VendaRapida(qtb_locacao.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lItemPreVenda[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = lItemPreVenda[0].Id_prevendastr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_itemprevenda",
                                vOperador = "=",
                                vVL_Busca = lItemPreVenda[0].Id_itemprevendastr
                            }
                        }, "1") != null)
                        throw new Exception("Locação possui pre venda faturada.\r\nObrigatorio estornar faturamento da pre venda primeiro.");
                    //Excluir Locacao X PreVenda
                    TCN_Locacao_X_PreVenda.Excluir(new TRegistro_Locacao_X_PreVenda()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_locacao = val.Id_locacao,
                        Id_prevenda = lItemPreVenda[0].Id_prevenda,
                        Id_itemprevenda = lItemPreVenda[0].Id_itemprevenda
                    }, qtb_locacao.Banco_Dados);
                    //Excluir item pre venda
                    CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Excluir(lItemPreVenda[0], qtb_locacao.Banco_Dados);
                    //Verificar se existe mais itens na pre venda
                    CamadaDados.Faturamento.PDV.TList_PreVenda lPreVenda =
                        new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_locacao.Banco_Dados).Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lItemPreVenda[0].Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_prevenda",
                            vOperador = "=",
                            vVL_Busca = lItemPreVenda[0].Id_prevendastr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdv_itensprevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda)"
                        }
                    }, 0, string.Empty, string.Empty);
                    if (lPreVenda.Count > 0)
                        CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(lPreVenda, qtb_locacao.Banco_Dados);
                }
                val.lItens.ForEach(p =>
                {
                    //Cancelar estoque
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_locacao.Banco_Dados).Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_itenslocacao_x_estoque x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_locacao = " + p.Id_locacaostr + " " +
                                                "and x.id_item = " + p.Id_itemstr + ")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_movimento",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(v =>
                            {
                                //Cancelar o estoque
                                CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(v, qtb_locacao.Banco_Dados);
                                //Excluir ItemLocacao X Estoque
                                TCN_ItensLocacao_X_Estoque.Excluir(new TRegistro_ItensLocacao_X_Estoque()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Id_locacao = p.Id_locacao,
                                    Id_item = p.Id_item,
                                    Cd_produto = v.Cd_produto,
                                    Id_lanctoestoque = v.Id_lanctoestoque
                                }, qtb_locacao.Banco_Dados);
                            });
                    //Cancelar faturamento de item perdido
                    lItemPreVenda = new CamadaDados.Faturamento.PDV.TCD_ItensPreVenda(qtb_locacao.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_itenslocacao_x_prevenda x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_prevenda = a.id_prevenda " +
                                                        "and x.id_itemprevenda = a.id_itemprevenda " +
                                                        "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                        "and x.id_locacao = " + p.Id_locacaostr + " " +
                                                        "and x.id_item = " + p.Id_itemstr + ")"
                                        }
                                    }, 0, string.Empty);
                    if (lItemPreVenda.Count > 0)
                    {
                        //Verificar se esta pre venda esta faturada
                        if (new CamadaDados.Faturamento.PDV.TCD_PreVenda_X_VendaRapida(qtb_locacao.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lItemPreVenda[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = lItemPreVenda[0].Id_prevendastr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_itemprevenda",
                                    vOperador = "=",
                                    vVL_Busca = lItemPreVenda[0].Id_itemprevendastr
                                }
                            }, "1") != null)
                            throw new Exception("Locação possui pre venda faturada.\r\nObrigatorio estornar faturamento da pre venda primeiro.");
                        //Excluir Locacao X PreVenda
                        TCN_ItensLocacao_X_PreVenda.Excluir(new TRegistro_ItensLocacao_X_PreVenda()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_locacao = p.Id_locacao,
                            Id_item = p.Id_item,
                            Id_prevenda = lItemPreVenda[0].Id_prevenda,
                            Id_itemprevenda = lItemPreVenda[0].Id_itemprevenda
                        }, qtb_locacao.Banco_Dados);
                        //Excluir item pre venda
                        CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Excluir(lItemPreVenda[0], qtb_locacao.Banco_Dados);
                        //Verificar se existe mais itens na pre venda
                        CamadaDados.Faturamento.PDV.TList_PreVenda lPreVenda =
                            new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_locacao.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lItemPreVenda[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "=",
                                    vVL_Busca = lItemPreVenda[0].Id_prevendastr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "not exists",
                                    vVL_Busca = "(select 1 from tb_pdv_itensprevenda x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_prevenda = a.id_prevenda)"
                                }
                            }, 0, string.Empty, string.Empty);
                        if (lPreVenda.Count > 0)
                            CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(lPreVenda, qtb_locacao.Banco_Dados);
                    }
                });
                //Mudar status locacao Aberta
                val.St_registro = "R";
                val.Dt_devolucao = null;
                qtb_locacao.Gravar(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static void RetirarLocacao(TRegistro_Locacao val, 
                                          ref CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda,
                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Buscar Cfg Locacao
                CamadaDados.Faturamento.Cadastros.TList_CFGLocacao lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar(val.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              qtb_locacao.Banco_Dados);
                if(lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração de locação para a empresa " + val.Cd_empresa.Trim());
                //Alterar status, data retirada e data prev devolucao da locacao
                val.St_registro = "R";
                val.Dt_retirada = CamadaDados.UtilData.Data_Servidor(qtb_locacao.Banco_Dados);
                val.Dt_prevdevolucao = val.Dt_retirada.Value.AddDays(Convert.ToDouble(lCfg[0].Qtd_diasdevolucao));
                qtb_locacao.Gravar(val);
                //Processar estoque dos itens
                val.lItens.ForEach(p =>
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_locacao.Banco_Dados).ProdutoComposto(p.Cd_produto))
                        {
                            //Criar objeto estoque
                            CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                            rEstoque.Cd_empresa = val.Cd_empresa;
                            rEstoque.Cd_produto = p.Cd_produto;
                            rEstoque.Cd_local = lCfg[0].Cd_local;
                            rEstoque.Dt_lancto = val.Dt_retirada;
                            rEstoque.Tp_movimento = "S";
                            rEstoque.Qtd_entrada = decimal.Zero;
                            rEstoque.Qtd_saida = p.Quantidade;
                            rEstoque.Vl_unitario = p.Vl_unitario;
                            rEstoque.Vl_subtotal = p.Vl_subtotal;
                            rEstoque.Tp_lancto = "N";
                            rEstoque.St_registro = "A";
                            //Gravar estoque
                            CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_locacao.Banco_Dados);
                            //Amarrar estoque X Item Locacao
                            TCN_ItensLocacao_X_Estoque.Gravar(
                                new TRegistro_ItensLocacao_X_Estoque()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Id_locacao = p.Id_locacao,
                                    Id_item = p.Id_item,
                                    Cd_produto = rEstoque.Cd_produto,
                                    Id_lanctoestoque = rEstoque.Id_lanctoestoque
                                }, qtb_locacao.Banco_Dados);
                        }
                        else
                        {
                            TCN_FichaTecItensLoc.Buscar(p.Cd_empresa, p.Id_locacaostr, p.Id_itemstr, string.Empty, qtb_locacao.Banco_Dados).ForEach(v =>
                                {
                                    //Criar objeto estoque
                                    CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                                    rEstoque.Cd_empresa = val.Cd_empresa;
                                    rEstoque.Cd_produto = v.Cd_item;
                                    rEstoque.Cd_local = lCfg[0].Cd_local;
                                    rEstoque.Dt_lancto = val.Dt_retirada;
                                    rEstoque.Tp_movimento = "S";
                                    rEstoque.Qtd_entrada = decimal.Zero;
                                    rEstoque.Qtd_saida = v.Quantidade;
                                    rEstoque.Vl_unitario = v.Vl_custo;
                                    rEstoque.Vl_subtotal = v.Vl_totalcusto;
                                    rEstoque.Tp_lancto = "N";
                                    rEstoque.St_registro = "A";
                                    //Gravar estoque
                                    CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_locacao.Banco_Dados);
                                    //Amarrar estoque X Item Locacao
                                    TCN_ItensLocacao_X_Estoque.Gravar(
                                        new TRegistro_ItensLocacao_X_Estoque()
                                        {
                                            Cd_empresa = v.Cd_empresa,
                                            Id_locacao = v.Id_locacao,
                                            Id_item = v.Id_item,
                                            Cd_produto = rEstoque.Cd_produto,
                                            Id_lanctoestoque = rEstoque.Id_lanctoestoque
                                        }, qtb_locacao.Banco_Dados);
                                });
                        }
                    });
                //Gerar pre venda da locacao
                if (rPreVenda == null)
                {
                    rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                    rPreVenda.Cd_empresa = val.Cd_empresa;
                    rPreVenda.Cd_clifor = val.Cd_clifor;
                    rPreVenda.Nm_clifor = val.Nm_clifor;
                    rPreVenda.Dt_emissao = val.Dt_retirada;
                    rPreVenda.Ds_observacao = val.Ds_observacao;
                    rPreVenda.Cd_vendedor = val.Cd_vendedor;
                    rPreVenda.St_registro = "A";
                }
                //Gerar item pre venda
                rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                {
                    Cd_produto = lCfg[0].Cd_produto,
                    Ds_produto = lCfg[0].Ds_produto,
                    Sigla_unidade = lCfg[0].Sigla_unidade,
                    Quantidade = 1,
                    Vl_unitario = val.lItens.Sum(p=> p.Vl_liquido),
                    Vl_subtotal = val.lItens.Sum(p=> p.Vl_liquido),
                    Vl_liquido = val.lItens.Sum(p=> p.Vl_liquido),
                    St_itemLocacao = true
                });
                //Gravar PreVenda
                CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Gravar(rPreVenda, qtb_locacao.Banco_Dados);
                decimal? id_prevenda = rPreVenda.Id_prevenda;
                //Amarrar Locacao X Item PreVenda
                rPreVenda.lItens.FindAll(p=> p.St_itemLocacao).ForEach(p =>
                                                                        TCN_Locacao_X_PreVenda.Gravar(
                                                                            new TRegistro_Locacao_X_PreVenda()
                                                                            {
                                                                                Cd_empresa = val.Cd_empresa,
                                                                                Id_locacao = val.Id_locacao,
                                                                                Id_prevenda = id_prevenda,
                                                                                Id_itemprevenda = p.Id_itemprevenda,
                                                                                Tp_locacao = "R"
                                                                            }, qtb_locacao.Banco_Dados));

                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro retirar locação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static void ProcessarLocacaoPreVenda(TRegistro_Locacao val,
                                                    ref CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda,
                                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Gravar locacao
                Gravar(val, qtb_locacao.Banco_Dados);
                //Retirar Locacao
                RetirarLocacao(val, ref rPreVenda, qtb_locacao.Banco_Dados);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar locação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }   

        public static void DevolverLocacao(TRegistro_Locacao val, 
                                           ref CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda,
                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Buscar Cfg Locacao
                CamadaDados.Faturamento.Cadastros.TList_CFGLocacao lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGLocacao.buscar(val.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              qtb_locacao.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração de locação para a empresa " + val.Cd_empresa.Trim());
                //Mudar status e data devolucao Locacao
                val.St_registro = "D";
                val.Dt_devolucao = CamadaDados.UtilData.Data_Servidor(qtb_locacao.Banco_Dados);
                qtb_locacao.Gravar(val);
                //Retornar itens locados para o estoque
                val.lItens.ForEach(p =>
                {
                    if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_locacao.Banco_Dados).ProdutoComposto(p.Cd_produto))
                    {
                        //Criar objeto estoque
                        CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = val.Cd_empresa;
                        rEstoque.Cd_produto = p.Cd_produto;
                        rEstoque.Cd_local = lCfg[0].Cd_local;
                        rEstoque.Dt_lancto = val.Dt_retirada;
                        rEstoque.Tp_movimento = "E";
                        rEstoque.Qtd_entrada = p.Quantidade;
                        rEstoque.Qtd_saida = decimal.Zero;
                        rEstoque.Vl_unitario = p.Vl_custo;
                        rEstoque.Vl_subtotal = p.Vl_totalcusto;
                        rEstoque.Tp_lancto = "N";
                        rEstoque.St_registro = "A";
                        //Gravar estoque
                        CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_locacao.Banco_Dados);
                        //Amarrar estoque X Item Locacao
                        TCN_ItensLocacao_X_Estoque.Gravar(
                            new TRegistro_ItensLocacao_X_Estoque()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_locacao = p.Id_locacao,
                                Id_item = p.Id_item,
                                Cd_produto = rEstoque.Cd_produto,
                                Id_lanctoestoque = rEstoque.Id_lanctoestoque
                            }, qtb_locacao.Banco_Dados);
                    }
                    else
                    {
                        TCN_FichaTecItensLoc.Buscar(p.Cd_empresa, p.Id_locacaostr, p.Id_itemstr, string.Empty, qtb_locacao.Banco_Dados).ForEach(v =>
                            {
                                //Criar objeto estoque
                                CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                                rEstoque.Cd_empresa = val.Cd_empresa;
                                rEstoque.Cd_produto = v.Cd_item;
                                rEstoque.Cd_local = lCfg[0].Cd_local;
                                rEstoque.Dt_lancto = val.Dt_retirada;
                                rEstoque.Tp_movimento = "E";
                                rEstoque.Qtd_entrada = v.Quantidade;
                                rEstoque.Qtd_saida = decimal.Zero;
                                rEstoque.Vl_unitario = v.Vl_custo;
                                rEstoque.Vl_subtotal = v.Vl_totalcusto;
                                rEstoque.Tp_lancto = "N";
                                rEstoque.St_registro = "A";
                                //Gravar estoque
                                CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_locacao.Banco_Dados);
                                //Amarrar estoque X Item Locacao
                                TCN_ItensLocacao_X_Estoque.Gravar(
                                    new TRegistro_ItensLocacao_X_Estoque()
                                    {
                                        Cd_empresa = v.Cd_empresa,
                                        Id_locacao = v.Id_locacao,
                                        Id_item = v.Id_item,
                                        Cd_produto = rEstoque.Cd_produto,
                                        Id_lanctoestoque = rEstoque.Id_lanctoestoque
                                    }, qtb_locacao.Banco_Dados);
                            });
                    }
                });
                //Calculamos Multa
                if ((val.Dt_devolucao.Value.Date > val.Dt_prevdevolucao.Value.Date) &&
                    (lCfg[0].Pc_multa > decimal.Zero))
                {
                    decimal vl_multa = decimal.Zero;
                    if (lCfg[0].Tp_multa.Trim().ToUpper().Equals("D"))
                        vl_multa = (val.lItens.Sum(p => p.Vl_liquido) * lCfg[0].Pc_multa / 100) * (val.Dt_devolucao.Value.Date - val.Dt_prevdevolucao.Value.Date).Days;
                    else
                        vl_multa = val.lItens.Sum(p => p.Vl_liquido) * lCfg[0].Pc_multa / 100;
                    //Gerar PreVenda Multa
                    if (rPreVenda == null)
                    {
                        rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                        rPreVenda.Cd_empresa = val.Cd_empresa;
                        rPreVenda.Cd_clifor = val.Cd_clifor;
                        rPreVenda.Nm_clifor = val.Nm_clifor;
                        rPreVenda.Dt_emissao = val.Dt_retirada;
                        rPreVenda.Ds_observacao = val.Ds_observacao;
                        rPreVenda.Cd_vendedor = val.Cd_vendedor;
                        rPreVenda.St_registro = "A";
                    }
                    //Gerar item pre venda
                    rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                    {
                        Cd_produto = lCfg[0].Cd_produto,
                        Ds_produto = lCfg[0].Ds_produto,
                        Sigla_unidade = lCfg[0].Sigla_unidade,
                        Quantidade = 1,
                        Vl_unitario = vl_multa,
                        St_itemLocacao = true
                    });
                    //Gravar PreVenda
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Gravar(rPreVenda, qtb_locacao.Banco_Dados);
                    decimal? id_prevenda = rPreVenda.Id_prevenda;
                    //Amarrar Locacao X Item PreVenda
                    rPreVenda.lItens.FindAll(p=> p.St_itemLocacao).ForEach(p =>
                                                                            TCN_Locacao_X_PreVenda.Gravar(
                                                                                new TRegistro_Locacao_X_PreVenda()
                                                                                {
                                                                                    Cd_empresa = val.Cd_empresa,
                                                                                    Id_locacao = val.Id_locacao,
                                                                                    Id_prevenda = id_prevenda,
                                                                                    Id_itemprevenda = p.Id_itemprevenda,
                                                                                    Tp_locacao = "M"
                                                                                }, qtb_locacao.Banco_Dados));
                }
                //Verificamos se esta faltando itens, caso sim, lancamos prevenda
                if (val.lItens.Exists(p => p.Sd_devolver > decimal.Zero))
                {
                    //Gerar PreVenda Itens Faltando
                    if (rPreVenda == null)
                    {
                        rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                        rPreVenda.Cd_empresa = val.Cd_empresa;
                        rPreVenda.Cd_clifor = val.Cd_clifor;
                        rPreVenda.Nm_clifor = val.Nm_clifor;
                        rPreVenda.Dt_emissao = val.Dt_retirada;
                        rPreVenda.Ds_observacao = val.Ds_observacao;
                        rPreVenda.Cd_vendedor = val.Cd_vendedor;
                        rPreVenda.St_registro = "A";
                    }
                    CamadaDados.Faturamento.PDV.TList_ItensPreVenda lItens = new CamadaDados.Faturamento.PDV.TList_ItensPreVenda();
                    val.lItens.FindAll(p => p.Sd_devolver > decimal.Zero).ForEach(p =>
                        {
                            lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                            {
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Sigla_unidade = p.Sigla_unidade,
                                Quantidade = p.Sd_devolver,
                                Vl_unitario = p.Vl_custo,
                                rItemLocacao = p
                            });
                        });
                    for (int i = 0; i < lItens.Count; i++)
                        rPreVenda.lItens.Add(lItens[i]);
                    //Gravar PreVenda, o metodo ira gravar tambem na TB_FAT_ItensLocacao_X_PreVenda
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Gravar(rPreVenda, qtb_locacao.Banco_Dados);
                }
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver locação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensLocacao
    {
        public static TList_ItensLocacao buscar(string Cd_empresa,
                                                string Id_locacao,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }

            return new TCD_ItensLocacao(banco).Select(vBusca, 0, string.Empty); 


        }

        public static string Gravar(TRegistro_ItensLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_itens = new TCD_ItensLocacao();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEM");
                //Excluir item Ficha Tecnica
                val.lFichaTecDel.ForEach(p => TCN_FichaTecItensLoc.Excluir(p, qtb_itens.Banco_Dados));
                //Gravar Item Ficha Tecnica
                val.lFichaTec.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_locacao = val.Id_locacao;
                    p.Id_item = val.Id_item;
                    TCN_FichaTecItensLoc.Gravar(p, qtb_itens.Banco_Dados);
                });
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_itens = new TCD_ItensLocacao();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                //Excluir Item Ficha Tecnica
                val.lFichaTec.ForEach(p => TCN_FichaTecItensLoc.Excluir(p, qtb_itens.Banco_Dados));
                val.lFichaTecDel.ForEach(p => TCN_FichaTecItensLoc.Excluir(p, qtb_itens.Banco_Dados));
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Locacao_X_PreVenda
    {
        public static TList_Locacao_X_PreVenda buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_prevenda,
                                             string Id_itemprevenda,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_prevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_itemprevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemprevenda;
            }

            return new TCD_Locacao_X_PreVenda(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Locacao_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao_X_PreVenda qtb_locacao_x_prevenda = new TCD_Locacao_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao_x_prevenda.CriarBanco_Dados(true);
                else
                    qtb_locacao_x_prevenda.Banco_Dados = banco;
                string retorno = qtb_locacao_x_prevenda.Gravar(val);
                if (st_transacao)
                    qtb_locacao_x_prevenda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao_x_prevenda.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao_x_prevenda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Locacao_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao_X_PreVenda qtb_x = new TCD_Locacao_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_x.CriarBanco_Dados(true);
                else
                    qtb_x.Banco_Dados = banco;
                qtb_x.Excluir(val);
                if (st_transacao)
                    qtb_x.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_x.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_x.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensLocacao_X_Estoque
    {
        public static TList_ItensLocacao_X_Estoque buscar(string Cd_empresa,
                                                string Id_locacao,
                                                string Id_item,
                                                string Cd_produto,
                                                string Id_lanctoestoque,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_lanctoestoque))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_lanctoestoque";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_lanctoestoque;
            }

            return new TCD_ItensLocacao_X_Estoque(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_ItensLocacao_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao_X_Estoque qtb_itens_x_estoque = new TCD_ItensLocacao_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens_x_estoque.CriarBanco_Dados(true);
                else
                    qtb_itens_x_estoque.Banco_Dados = banco;
                string retorno = qtb_itens_x_estoque.Gravar(val);
                if (st_transacao)
                    qtb_itens_x_estoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens_x_estoque.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_itens_x_estoque.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensLocacao_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao_X_Estoque qtb_itens_x_estoque = new TCD_ItensLocacao_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens_x_estoque.CriarBanco_Dados(true);
                else
                    qtb_itens_x_estoque.Banco_Dados = banco;
                qtb_itens_x_estoque.Excluir(val);
                if (st_transacao)
                    qtb_itens_x_estoque.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens_x_estoque.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_itens_x_estoque.deletarBanco_Dados();
            }
        }

    }

    public class TCN_ItensLocacao_X_PreVenda
    {
        public static TList_ItensLocacao_X_PreVenda buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Id_item,
                                             string Id_prevenda,
                                             string Id_itemprevenda,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_prevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_itemprevenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemprevenda;
            }

            return new TCD_ItensLocacao_X_PreVenda(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensLocacao_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao_X_PreVenda qtb_itenslocacao_x_prevenda = new TCD_ItensLocacao_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itenslocacao_x_prevenda.CriarBanco_Dados(true);
                else
                    qtb_itenslocacao_x_prevenda.Banco_Dados = banco;
                string retorno = qtb_itenslocacao_x_prevenda.Gravar(val);
                if (st_transacao)
                    qtb_itenslocacao_x_prevenda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itenslocacao_x_prevenda.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_itenslocacao_x_prevenda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensLocacao_X_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao_X_PreVenda qtb_x = new TCD_ItensLocacao_X_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_x.CriarBanco_Dados(true);
                else
                    qtb_x.Banco_Dados = banco;
                qtb_x.Excluir(val);
                if (st_transacao)
                    qtb_x.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_x.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_x.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FichaTecItensLoc
    {
        public static TList_FichaTecItensLoc Buscar(string Cd_empresa,
                                                    string Id_locacao,
                                                    string Id_item,
                                                    string Cd_item,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }
            return new TCD_FichaTecItensLoc(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTecItensLoc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecItensLoc qtb_ficha = new TCD_FichaTecItensLoc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                string retorno = qtb_ficha.Gravar(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ficha tecnica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTecItensLoc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecItensLoc qtb_ficha = new TCD_FichaTecItensLoc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                qtb_ficha.Excluir(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ficha tecnica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static TList_FichaTecItensLoc MontarFichaTecItemLoc(string Cd_empresa,
                                                                   string Cd_produto,
                                                                   decimal Quantidade,
                                                                   BancoDados.TObjetoBanco banco)
        {
            //Buscar ficha tecnica do produto
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(Cd_produto,
                                                                           string.Empty,
                                                                           banco);
            if (lFicha.Count > 0)
            {
                TList_FichaTecItensLoc lFichaLoc = new TList_FichaTecItensLoc();
                lFicha.ForEach(p =>
                    lFichaLoc.Add(new TRegistro_FichaTecItensLoc()
                    {
                        Cd_item = p.Cd_item,
                        Sigla_item = p.Sg_unditem,
                        Ds_item = p.Ds_item,
                        Quantidade = Quantidade * p.Quantidade,
                        Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(Cd_empresa, p.Cd_item, banco)
                    }));
                return lFichaLoc;
            }
            else throw new Exception("Não existe ficha tecnica cadastrada para o produto " + Cd_produto.Trim());
        }
    }
}
