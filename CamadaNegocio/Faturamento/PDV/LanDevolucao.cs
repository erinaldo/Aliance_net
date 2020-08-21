using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_Devolucao
    {
        public static TList_Devolucao Buscar(string Cd_empresa,
                                             string Id_devolucao,
                                             string Id_cupom,
                                             string Cd_produto,
                                             string Dt_ini,
                                             string Dt_fin,
                                             bool St_buscarDetalhes,
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
            if (!string.IsNullOrEmpty(Id_devolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devolucao;
            }
            if ((!string.IsNullOrEmpty(Id_cupom)) || (!string.IsNullOrEmpty(Cd_produto)))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_itensdevolvidos x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_devolucao = a.id_devolucao ";
                if (!string.IsNullOrEmpty(Id_cupom))
                    filtro[filtro.Length - 1].vVL_Busca += "and x.id_cupom = " + Id_cupom + " ";
                if (!string.IsNullOrEmpty(Cd_produto))
                    filtro[filtro.Length - 1].vVL_Busca += "and x.cd_produto = '" + Cd_produto.Trim() + "' ";
                filtro[filtro.Length - 1].vVL_Busca += ")";
            }
            if((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_devolucao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_devolucao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            TList_Devolucao lDev = new TCD_Devolucao(banco).Select(filtro, 0, string.Empty, string.Empty);
            if (St_buscarDetalhes)
                lDev.ForEach(p =>
                    {
                        p.lItensDev = TCN_ItensDevolvidos.Buscar(p.Cd_empresa, p.Id_devolucaostr, string.Empty, null);
                        p.lDevFin = TCN_DevolucaoFIN.Buscar(p.Cd_empresa, p.Id_devolucaostr, string.Empty, string.Empty, null);
                    });
            return lDev;
        }

        public static string Gravar(TRegistro_Devolucao val,
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc, 
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Devolucao qtb_dev = new TCD_Devolucao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else
                    qtb_dev.Banco_Dados = banco;
                decimal tot_devolver = Math.Round(val.lItens.Sum(p => p.Qtd_devolver * (p.Vl_subtotalliquido / p.Quantidade)), 2);
                TList_DevolucaoFIN lDevFin = new TList_DevolucaoFIN();
                if (lParc?.Count > 0)
                {
                    foreach (CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela p in lParc)
                    {
                        if (tot_devolver > decimal.Zero)
                        {
                            lDevFin.Add(new TRegistro_DevolucaoFIN()
                            {
                                Nr_lancto = p.Nr_lancto,
                                Cd_parcela = p.Cd_parcela,
                                Vl_devolvido = tot_devolver < p.cVl_atual ? tot_devolver : p.cVl_atual
                            });
                            tot_devolver -= tot_devolver < p.cVl_atual ? tot_devolver : p.cVl_atual;
                        }
                        else break;
                    }
                }
                if (tot_devolver > decimal.Zero)
                {
                    //Buscar Config Adto
                    CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lCfgAdto =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    1,
                                                                                    string.Empty,
                                                                                    qtb_dev.Banco_Dados);
                    if (lCfgAdto.Count.Equals(0))
                        throw new Exception("Não existe configuração adiantamento para gerar credito.");
                    //Gerar Credito do valor devolvido
                    CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                    rAdto.Cd_clifor = val.Cd_clifor;
                    rAdto.Cd_empresa = val.Cd_empresa;
                    //Buscar endereco
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                                    }
                                }, "a.cd_endereco");
                    rAdto.CD_Endereco = obj == null ? string.Empty : obj.ToString();
                    rAdto.Ds_adto = "CREDITO RECEBIDO DEVOLUÇÃO VENDA";
                    rAdto.Tp_movimento = "R";
                    rAdto.Dt_lancto = val.Dt_devolucao;
                    rAdto.Vl_adto = tot_devolver;
                    rAdto.ST_ADTO = "A";
                    rAdto.TP_Lancto = "T";//Frente Caixa
                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, qtb_dev.Banco_Dados);
                    //Quitar adiantamento
                    rAdto.List_Caixa.Add(new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                    {
                        Cd_ContaGer = lCfgAdto[0].Cd_contagerDEV_CV,
                        Cd_Empresa = val.Cd_empresa,
                        Cd_Historico = lCfgAdto[0].Cd_historico_ADTO_R,
                        Cd_LanctoCaixa = decimal.Zero,
                        ComplHistorico = "CREDITO RECEBIDO DEVOLUÇÃO VENDA",
                        Dt_lancto = val.Dt_devolucao,
                        Login = Utils.Parametros.pubLogin,
                        Nr_Docto = "DEVPDV",
                        St_Estorno = "N",
                        St_Titulo = "N",
                        Vl_PAGAR = decimal.Zero,
                        Vl_RECEBER = rAdto.Vl_adto,
                        NM_Clifor = val.Nm_clifor
                    });
                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_dev.Banco_Dados);
                    val.Id_adto = rAdto.Id_adto;
                    //Dar saida do valor do credito para não duplicar o valor
                    string ret =
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                        new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = lCfgAdto[0].Cd_contagerDEV_CV,
                            Cd_Empresa = val.Cd_empresa,
                            Cd_Historico = lCfgAdto[0].Cd_historicoDEV_Venda,
                            Cd_LanctoCaixa = decimal.Zero,
                            ComplHistorico = "DEVOLUÇÃO VENDA",
                            Dt_lancto = val.Dt_devolucao,
                            Login = Utils.Parametros.pubLogin,
                            Nr_Docto = "DEVPDV",
                            St_Estorno = "N",
                            St_Titulo = "N",
                            Vl_PAGAR = rAdto.Vl_adto,
                            Vl_RECEBER = decimal.Zero,
                            NM_Clifor = val.Nm_clifor
                        }, qtb_dev.Banco_Dados);
                    val.Cd_contager = lCfgAdto[0].Cd_contagerDEV_CV;
                    val.Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA");
                }
                //Gravar devolucao
                val.Id_devolucaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_dev.Gravar(val), "@P_ID_DEVOLUCAO");
                lDevFin.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_devolucao = val.Id_devolucao;
                        TCN_DevolucaoFIN.Gravar(p, qtb_dev.Banco_Dados);
                    });
                //Gravar Itens Devolvidos
                val.lItens.ForEach(p =>
                    {
                        decimal vl_unit = decimal.Zero;
                        //Buscar Vl.Unitario
                        object objVl_unit = new TCD_LanEstoque(qtb_dev.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_Item_X_Estoque x " +
                                                    "where a.Id_LanctoEstoque = x.Id_LanctoEstoque " +
                                                    "and a.cd_empresa = x.cd_empresa " +
                                                    "and a.cd_produto = x.cd_produto " +
                                                    "and x.id_lancto = " + p.Id_lanctovenda.ToString() + " " +
                                                    "and x.id_cupom = " + p.Id_vendarapida.ToString() + " " +
                                                    "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                    "and x.cd_produto = '" + p.Cd_produto.Trim() + "')"
                                    }
                                }, "a.vl_unitario");
                        if (objVl_unit == null || string.IsNullOrEmpty(objVl_unit.ToString()))
                            vl_unit = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(val.Cd_empresa, p.Cd_produto, qtb_dev.Banco_Dados);
                        else
                            vl_unit = decimal.Parse(objVl_unit.ToString());
                        //dar entrada novamente no estoque
                        string id_lanctoestoque = CamadaDados.TDataQuery.getPubVariavel(
                        TCN_LanEstoque.GravarEstoque(
                            new TRegistro_LanEstoque()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_produto = p.Cd_produto,
                                Cd_local = p.Cd_local,
                                Dt_lancto = val.Dt_devolucao,
                                Tp_movimento = "E",
                                Qtd_entrada = p.Qtd_devolver,
                                Qtd_saida = decimal.Zero,
                                Vl_unitario = vl_unit,
                                Vl_subtotal = vl_unit,
                                Tp_lancto = "L",
                                St_registro = "A",
                                Ds_observacao = "DEVOLUCAO VENDA FRENTE CAIXA Nº" + p.Id_vendarapida.Value.ToString()
                            }, qtb_dev.Banco_Dados), "@@P_ID_LANCTOESTOQUE");
                        //gravar itens devolvidos
                        TCN_ItensDevolvidos.Gravar(new TRegistro_ItensDevolvidos()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_devolucao = val.Id_devolucao,
                            Id_lancto = p.Id_lanctovenda,
                            Id_cupom = p.Id_vendarapida,
                            Cd_produto = p.Cd_produto,
                            Id_lanctoestoquestr = id_lanctoestoque
                        }, qtb_dev.Banco_Dados);
                        //Grade Produto
                        p.lGrade.ForEach(v =>
                        {
                            if (v.Vl_mov > decimal.Zero)
                            {
                                TCN_GradeEstoque.Gravar(
                                    new TRegistro_GradeEstoque
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_produto = p.Cd_produto,
                                        Id_lanctoestoque = decimal.Parse(id_lanctoestoque),
                                        Id_caracteristica = v.Id_caracteristica,
                                        Id_item = v.Id_item,
                                        quantidade = v.Vl_mov
                                    }, qtb_dev.Banco_Dados);
                            }
                        });
                    });
                //Reprocessar Comissão
                       new TCD_VendaRapida_Item(qtb_dev.Banco_Dados).Select(
                        new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_vendarapida",
                                        vOperador = "=",
                                        vVL_Busca = val.lItens[0].Id_vendarapida.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    }
                                }, 0, string.Empty, string.Empty).ForEach(p => PDV.TCN_VendaRapida_Item.ProcessarComissao(p, qtb_dev.Banco_Dados));
                       if (val.lItens.Count > 0)
                       {
                           //Recalcular Pontos Fidelidade
                           new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade(qtb_dev.Banco_Dados).Select(
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
                                       vVL_Busca = val.lItens[0].Id_vendarapida.ToString()
                                   }
                               }, 0, string.Empty, string.Empty).ForEach(x =>
                                       {
                                           System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
                                           hs.Add("@P_CD_EMPRESA", x.Cd_empresa);
                                           hs.Add("@P_ID_CUPOM", x.Id_cupomstr);
                                           hs.Add("@P_QTD_DEVOLVER", val.lItens.Sum(p => p.Qtd_devolver * (x.Qt_pontos / p.Quantidade)));
                                           qtb_dev.executarSql("update TB_FAT_PontosFidelidade set QT_Pontos = QT_Pontos - @P_QTD_DEVOLVER" +
                                               " where cd_empresa = @P_CD_EMPRESA" +
                                               " and id_cupom = @P_ID_CUPOM" , hs);
                                       });

                           //Recalcular Resgate
                           new CamadaDados.Faturamento.Fidelizacao.TCD_ResgatePontos(qtb_dev.Banco_Dados).Select(
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
                                       vVL_Busca = val.lItens[0].Id_vendarapida.ToString()
                                   }
                               }, 0, string.Empty).ForEach(x =>
                                       {
                                           System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
                                           hs.Add("@P_CD_EMPRESA", x.Cd_empresa);
                                           hs.Add("@P_ID_CUPOM", x.Id_cupomstr);
                                           hs.Add("@P_ID_PONTO", x.Id_pontostr);
                                           hs.Add("@P_QTD_DEVOLVER", val.lItens.Sum(p => p.Qtd_devolver * (x.Qt_pontos / p.Quantidade)));
                                           qtb_dev.executarSql("update TB_FAT_ResgatePontos set QT_Pontos = QT_Pontos - @P_QTD_DEVOLVER" +
                                                " where cd_empresa = @P_CD_EMPRESA" +
                                                " and id_cupom = @P_ID_CUPOM" +
                                                " and id_ponto = @P_ID_PONTO", hs);
                                       });
                       }
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return val.Id_devolucaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar devolução:" + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Devolucao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Devolucao qtb_dev = new TCD_Devolucao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else
                    qtb_dev.Banco_Dados = banco;
                //Excluir Adiantamentos
                val.lAdto.ForEach(p => CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Excluir(p, qtb_dev.Banco_Dados));
                //Excluir Itens 
                val.lItensDev.ForEach(p => TCN_ItensDevolvidos.Excluir(p, qtb_dev.Banco_Dados));
                //Excluir Devolução
                qtb_dev.Excluir(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return val.Id_devolucaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensDevolvidos
    {
        public static TList_ItensDevolvidos Buscar(string Cd_empresa,
                                                   string Id_devolucao,
                                                   string Id_cupom,
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
            if (!string.IsNullOrEmpty(Id_devolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devolucao;
            }
            if(!string.IsNullOrWhiteSpace(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            return new TCD_ItensDevolvidos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensDevolvidos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDevolvidos qtb_item = new TCD_ItensDevolvidos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                string retorno = qtb_item.Gravar(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item devolvido: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensDevolvidos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensDevolvidos qtb_item = new TCD_ItensDevolvidos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                //Buscar registro estoque
                CamadaDados.Estoque.TList_RegLanEstoque lEstoque =
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_item.Banco_Dados).Select(
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
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_produto.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_lanctoestoque",
                                vOperador = "=",
                                vVL_Busca = val.Id_lanctoestoquestr
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                //Excluir estoque
                lEstoque.ForEach(p => CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_item.Banco_Dados));
                qtb_item.Excluir(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item devolvido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }
    }
}
