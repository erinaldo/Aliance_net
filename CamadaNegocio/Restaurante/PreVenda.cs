using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using CamadaDados.Restaurante;
using System.Text;

namespace CamadaNegocio.Restaurante
{
    #region prevenda
    public class TCN_PreVenda
    {
        public static TList_PreVenda Buscar(string Cd_empresa,
                                          string id_cartao,
                                          string id_preventa,
                                          string cd_garcon,
                                          string ds_garcon,
                                          string st_registro,
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
            if (!string.IsNullOrEmpty(ds_garcon))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_garcon.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(id_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cartao;// + " or ( b.id_orc = '" + Id_orcamento + "')";
            }
            if (!string.IsNullOrEmpty(id_preventa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_preventa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_preventa;
            }
            if (!string.IsNullOrEmpty(cd_garcon))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_garcon";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_garcon.Trim() + "'";
            }

            if (string.IsNullOrEmpty(st_registro))
                st_registro = "A";

            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
            filtro[filtro.Length - 1].vOperador = "in";
            filtro[filtro.Length - 1].vVL_Busca = "('" + st_registro + "') " + (st_registro.Equals("A") ? "or a.St_Registro is null" : string.Empty);

            return new TCD_PreVenda(banco).Select(filtro, 0, string.Empty, string.Empty);
        }
        public static string TransferirMesa(TRegistro_Cartao val, CamadaDados.Restaurante.Cadastro.TRegistro_Cfg cfg, string id_cartao, BancoDados.TObjetoBanco banco)
        {


            bool st_transacao = false;
            TCD_PreVenda qtb_orc = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                if (cfg.Tp_cartao.Equals("1"))
                {

                    TList_PreVenda futura_mesa = new TList_PreVenda();
                    futura_mesa = TCN_PreVenda.Buscar(val.Cd_empresa, id_cartao, string.Empty, string.Empty, string.Empty, string.Empty, banco);
                    futura_mesa.ForEach(p =>
                    {
                        p.lItens = TCN_PreVenda_Item.Buscar(p.Cd_empresa, p.id_prevenda.ToString(), string.Empty, string.Empty, banco);
                        val.lPreVenda.ForEach(pi =>
                        {
                            int i = p.lItens.Count;
                            pi.lItens.ForEach(o =>
                            {
                                TRegistro_PreVenda_Item item = new TRegistro_PreVenda_Item();
                                item.casasdecimais = o.casasdecimais;
                                item.cd_condfiscal_produto = o.cd_condfiscal_produto;
                                item.Cd_empresa = p.Cd_empresa;
                                item.cd_produto = o.cd_produto;
                                item.ds_grupo = o.ds_grupo;
                                item.ds_produto = o.ds_produto;
                                item.id_cartao = p.id_cartao;
                                item.id_portaimp = o.id_portaimp;
                                item.id_prevenda = p.id_prevenda;
                                item.obsItem = o.obsItem;
                                item.porta_imp = o.porta_imp;
                                item.quantidade = o.quantidade;
                                item.vl_desconto = o.vl_desconto;
                                item.vl_liquido = o.vl_liquido;
                                item.vl_subtotal = o.vl_subtotal;
                                item.vl_unitario = o.vl_unitario;
                                item.lSabores = o.lSabores;
                                //i++;
                                item.id_item = o.id_item + i;
                                if (!string.IsNullOrWhiteSpace(o.id_itemPaiAdic.ToString()))
                                    item.id_itemPaiAdic = o.id_itemPaiAdic + i;
                                //item.id_item = i;
                                p.lItens.Add(item);
                            });
                        });
                    });

                    val.St_registro = "C";
                    val.lPreVenda.ForEach(p =>
                    {
                    // p.motivo = "junção de mesa :" + val.Id_mesa + " local " + val.id_local + " com a mesa " + mesa.id_mesa + " local " + mesa.id_local;
                    p.st_ativo = "C";
                    });
                    TCN_Cartao.Gravar(val, banco);
                    futura_mesa.ForEach(p =>
                    {
                        TCN_PreVenda.Gravar(p, banco);
                    });


                }
                else if (cfg.Tp_cartao.Equals("0") && cfg.bool_mesacartao)
                {

                    TCN_Cartao.Gravar(val, banco);
                }

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return string.Empty;// val.id_prevenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        public static string Gravar(TRegistro_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_orc = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                string ret = qtb_orc.Gravar(val);
                val.id_prevenda = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_PREVENDA"));
                
                //Comentado pos item já esta sendo cancelado pela tela de pre-venda do restaurante,
                //Código poderá ser reaproveitado quando item não for gravado na hora do lançamento.
                //val.lDelItens.ForEach(p =>
                //{
                //    p.id_prevenda = val.id_prevenda;
                //    TCN_PreVenda_Item.Excluir(p, qtb_orc.Banco_Dados);
                //});

                val.lItens.ForEach(p =>
                {
                    p.id_prevenda = val.id_prevenda;
                    TCN_PreVenda_Item.Gravar(p, qtb_orc.Banco_Dados);
                    p.lSabores.ForEach(o =>
                    {
                        o.Id_PreVenda = val.id_prevenda;
                        o.Cd_Empresa = val.Cd_empresa;
                        if (!string.IsNullOrEmpty(o.Id_ItemStr))
                            TCN_SaboresItens.Gravar(o, qtb_orc.Banco_Dados);

                    });
                });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_prevenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string CancelarPreVenda(TRegistro_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_orc = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                val.lItens.ForEach(p =>
                {
                    p.st_registro = "C";
                    TCN_PreVenda_Item.Gravar(p, qtb_orc.Banco_Dados);
                });
                val.st_ativo = "C";
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_orc = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Verificar se venda possui cupom emitido pelo delivery
                if (new TCD_ItensPreVenda_X_ItensCupom(qtb_orc.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.CD_Empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.ID_PreVenda",
                                    vOperador = "=",
                                    vVL_Busca = val.id_prevenda.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_PDV_NFCe x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_nfce = a.id_cupom) "
                                }
                            }, "1") == null)
                {
                    //Se não tiver excluir venda rápida
                    CamadaDados.Faturamento.PDV.TList_VendaRapida lVendaRapida =
                    new CamadaDados.Faturamento.PDV.TCD_VendaRapida(qtb_orc.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_RES_ItensPreVenda_X_ItensCupom x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_vendarapida = a.id_vendarapida " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.id_prevenda = " + val.id_prevenda.ToString() + ") "
                            }
                        }, 0, string.Empty, string.Empty);
                    //Exclui Venda Rápida
                    if (lVendaRapida.Count > 0)
                        Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(lVendaRapida, qtb_orc.Banco_Dados);
                }
                else
                    throw new Exception("Não é permitido cancelar venda que possui cupom fiscal!\r\n" +
                                        "Para excluir cupom fiscal acesse:\r\n" +
                                        "Faturamento>>Frente Caixa>>>Consulta - Venda Frente Caixa.");
                val.lDelItens.ForEach(p =>
                {
                    p.st_registro = "C";
                    TCN_PreVenda_Item.Gravar(p, qtb_orc.Banco_Dados);
                });
                val.lItens.ForEach(p =>
                {
                    p.st_registro = "C";
                    TCN_PreVenda_Item.Gravar(p, qtb_orc.Banco_Dados);
                });
                //St_registro
                val.st_ativo = "C";

                //Cancelamento do cartao
                qtb_orc.executarEscalar("update TB_RES_Cartao " +
                    "set ST_Registro = 'C' " +
                    "where ID_Cartao = " + val.id_cartao + " " +
                    "update TB_RES_Cartao " +
                    "set dt_fechamento = GETDATE() " +
                    "where ID_Cartao = " + val.id_cartao + " ", null);
                

                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string FecharComanda(TRegistro_PreVenda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda qtb_orc = new TCD_PreVenda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Gravar Venda Restaurante
                val.lVenda.ForEach(p =>
                {
                    p.st_restaurante = true;
                    Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(p,
                                                                      null,
                                                                      null, 
                                                                      qtb_orc.Banco_Dados);
                });
                //Mudar status Delivery para fechado
                //todo aqui
                qtb_orc.executarSql("update TB_RES_PreVenda set ST_Delivery = 'F', Dt_Alt = GETDATE() " +
                                    "where cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    "and id_prevenda = " + val.id_prevenda.ToString(), null);
                
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_prevenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
    #endregion

    #region prevendaitem
    public class TCN_PreVenda_Item
    {
        public static TList_PreVenda_Item Buscar(string Cd_empresa,
                                          string id_preventa,
                                          string nr_cartao,
                                          string st_registro,
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
            if (!string.IsNullOrEmpty(id_preventa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_preventa;
            }
            if (!string.IsNullOrEmpty(nr_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.nr_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_cartao.Trim() + "'";

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.st_registro";
                filtro[filtro.Length - 1].vOperador = "IN";
                filtro[filtro.Length - 1].vVL_Busca = "('A')";
            }

            if (string.IsNullOrEmpty(st_registro))
            {
                st_registro = "A";
            }
            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
            filtro[filtro.Length - 1].vOperador = "in";
            filtro[filtro.Length - 1].vVL_Busca = "('" + st_registro + "') " + (st_registro.Equals("A") ? "or a.St_Registro is null" : string.Empty);

            return new TCD_PreVenda_Item(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_PreVenda_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_Item qtb_orc = new TCD_PreVenda_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                if (val.tapTransactions != null)
                    val.Ch_torneira = val.tapTransactions.cardId.ToString() + "|" + val.tapTransactions.tstStart.ToString() + "|" + val.tapTransactions.plu.ToString();
                string ret = qtb_orc.Gravar(val);
                val.id_prevenda = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_PREVENDA"));
                val.id_item = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ITEM"));

                val.lSabores.ForEach(p =>
                {
                    p.Cd_Empresa = val.Cd_empresa;
                    p.Id_PreVenda = val.id_prevenda;
                    p.Id_Item = val.id_item;
                    
                    if (!string.IsNullOrEmpty(p.ID_Sabor.ToString()))
                        TCN_SaboresItens.Gravar(p, qtb_orc.Banco_Dados);
                });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_prevenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PreVenda_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_Item qtb_orc = new TCD_PreVenda_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Verificar se existir itens filhos
                new TCD_PreVenda_Item(qtb_orc.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ID_PreVenda",
                            vOperador = "=",
                            vVL_Busca = val.id_prevenda.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ID_ItemPaiAdic",
                            vOperador = "=",
                            vVL_Busca = val.id_item.ToString()
                        }//Excluir Itens Filhos
                    }, 0, string.Empty).ForEach(p =>
                    {
                        p.st_registro = "C";
                        qtb_orc.Gravar(p);
                    });
                val.lSabores.ForEach(p =>
                {
                    TCN_SaboresItens.Excluir(p, qtb_orc.Banco_Dados);
                });

                //Cancelamento das movimentações boliche
                TList_MovBoliche _MovBoliches = TCN_MovBoliche.Buscar(val.Cd_empresa, 
                                                                      string.Empty, 
                                                                      string.Empty, 
                                                                      string.Empty, 
                                                                      val.id_prevenda.ToString(), 
                                                                      val.id_item.ToString(), 
                                                                      null);
                _MovBoliches.ForEach(r => 
                {
                    r.Cancelado = true;
                    r.LoginCanc = val.LoginCanc;
                    new TCD_MovBoliche(qtb_orc.Banco_Dados).Gravar(r);
                });

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string ExcluirC(TRegistro_PreVenda_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PreVenda_Item qtb_orc = new TCD_PreVenda_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Verificar se existir itens filhos
                new TCD_PreVenda_Item(qtb_orc.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ID_PreVenda",
                            vOperador = "=",
                            vVL_Busca = val.id_prevenda.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ID_ItemPaiAdic",
                            vOperador = "=",
                            vVL_Busca = val.id_item.ToString()
                        }//Excluir Itens Filhos
                    }, 0, string.Empty).ForEach(p =>
                    {
                        p.st_registro = "C";
                        qtb_orc.Gravar(p);
                    });
                val.lSabores.ForEach(p =>
                {
                    TCN_SaboresItens.Excluir(p, qtb_orc.Banco_Dados);
                });

                //Cancelamento das movimentações boliche
                TList_MovBoliche _MovBoliches = TCN_MovBoliche.Buscar(val.Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      val.id_prevenda.ToString(),
                                                                      val.id_item.ToString(),
                                                                      null);
                _MovBoliches.ForEach(r =>
                {
                    r.Cancelado = true;
                    r.LoginCanc = val.LoginCanc;
                    new TCD_MovBoliche(qtb_orc.Banco_Dados).Gravar(r);
                });

                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
    #endregion

    #region SaboresItens
    public class TCN_SaboresItens
    {
        public static TList_SaboresItens Buscar(string Cd_empresa,
                                          string id_preventa,
                                          string id_item,
                                          string id_sabor,
                                          BancoDados.TObjetoBanco banco)
        {


            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_sabor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_sabor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_sabor;
            }
            if (!string.IsNullOrEmpty(id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_item;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_preventa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_preventa;
            }

            return new TCD_SaboresItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_SaboresItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SaboresItens qtb_orc = new TCD_SaboresItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;


                string ret = qtb_orc.Gravar(val);
                //val.id_ = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_PREVENDA"));

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_PreVenda.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pre venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_SaboresItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SaboresItens qtb_orc = new TCD_SaboresItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pre venda item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

    }
    #endregion
}
