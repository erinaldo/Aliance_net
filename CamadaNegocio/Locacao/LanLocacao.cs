using System;
using System.Linq;
using CamadaDados.Locacao;
using Utils;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;

namespace CamadaNegocio.Locacao
{
    public class TCN_Locacao
    {
        public static TList_Locacao buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Nr_contrato,
                                             string Cd_clifor,
                                             string Cd_vendedor,
                                             string Nr_patrimonio,
                                             string Id_tabela,
                                             string Cd_grupo,
                                             string Id_venda,
                                             string Tp_frete,
                                             string vTp_data,
                                             string vDt_ini,
                                             string vDt_fin,
                                             string St_registro,
                                             string vOrder,
                                             BancoDados.TObjetoBanco banco,
                                             string cd_motorista = "")
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(cd_motorista))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(SELECT 1 FROM TB_LOC_ColetaEntrega x " +
                                                       "inner join TB_LOC_Vistoria_X_ColEnt y " +
                                                       "on x.CD_Empresa = y.CD_Empresa " +
                                                       "and x.ID_Coleta= y.ID_Coleta " +
                                                       "where y.CD_Empresa = a.CD_Empresa " +
                                                       "and y.ID_Locacao = a.ID_Locacao " +
                                                       "and x.cd_motorista = '" + cd_motorista.Trim() + "')";
            }
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
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_vendedor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_LOC_ItensLocacao x " +
                                                      "inner join tb_est_patrimonio y " +
                                                      "on x.cd_produto = y.CD_Patrimonio " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and y.nr_patrimonio = '" + Nr_patrimonio.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_tabela))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_LOC_ItensLocacao x " +
                                                      "where a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and x.id_tabela = " + Id_tabela + ")";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from VTB_LOC_ItensLocacao x " +
                                                      "where a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and x.Cd_grupo = '" + Cd_grupo.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_PDV_VendaRapida x " +
                                                      "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_vendarapida = y.id_cupom " +
                                                      "inner join TB_LOC_Itens_X_PreVenda h " +
                                                      "on h.cd_empresa = y.cd_empresa " +
                                                      "and h.id_prevenda = y.id_prevenda " +
                                                      "and h.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                                      "where a.cd_empresa = h.cd_empresa " +
                                                      "and a.id_locacao = h.id_locacao " +
                                                      "and x.id_vendarapida = " + Id_venda + ") ";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Id_locacao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Tp_frete))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_frete";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_frete.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_LOC_ItensLocacao x " +
                                                      "where a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and " + (vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_locacao" :
                                                                vTp_data.Trim().ToUpper().Equals("R") ? "x.dt_retirada" :
                                                                vTp_data.Trim().ToUpper().Equals("P") ? "x.dt_prevdev" :
                                                                vTp_data.Trim().ToUpper().Equals("D") ? "x.dt_devolucao" : "a.dt_saient") +
                                                                " >= " +
                                                                "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd 00:00:00") + "')";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_LOC_ItensLocacao x " +
                                                      "where a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and " + (vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_locacao" :
                                                                vTp_data.Trim().ToUpper().Equals("R") ? "x.dt_retirada" :
                                                                vTp_data.Trim().ToUpper().Equals("P") ? "x.dt_prevdev" :
                                                                vTp_data.Trim().ToUpper().Equals("D") ? "x.dt_devolucao" : "a.dt_saient") +
                                                                " <= " +
                                                                "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd 23:59:59") + "')";
            }
            if (!string.IsNullOrEmpty(St_registro))
                Estruturas.CriarParametro(ref vBusca, "isnull(a.st_registro, '0')", "(" + St_registro.Trim() + ")", "in");

            return new TCD_Locacao(banco).Select(vBusca, 0, string.Empty, vOrder);
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
                //Itens
                val.Id_locacaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_LOCACAO");
                val.lItensDel.ForEach(p => TCN_ItensLocacao.Excluir(p, qtb_locacao.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    if (p.Vl_desconto < 0)
                        throw new Exception("Vl.Desconto está negativo, refaça a operação!");
                    p.Id_locacao = val.Id_locacao;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_ItensLocacao.Gravar(p, qtb_locacao.Banco_Dados);
                });
                //Gravar Histórico
                val.lHist.ForEach(p =>
                {
                    p.Id_locacao = val.Id_locacao;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_Historico.Gravar(p, qtb_locacao.Banco_Dados);
                });
                //Parcelas
                val.lParcDel.ForEach(p => TCN_ParcelaLocacao.Excluir(p, qtb_locacao.Banco_Dados));
                val.lParc.ForEach(p =>
                {
                    p.Id_locacao = val.Id_locacao;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_ParcelaLocacao.Gravar(p, qtb_locacao.Banco_Dados);
                });
                //Gravar Adiantamento
                if (val.St_comEntrada)
                {
                    string Id_adtostr =
                    Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(
                        new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento()
                        {
                            Cd_clifor = val.Cd_clifor,
                            Cd_empresa = val.Cd_empresa,
                            CD_Endereco = val.Cd_endereco,
                            Ds_adto = "CREDITO RECEBIDO LOCAÇÃO Nº" + val.Id_locacaostr,
                            Tp_movimento = "R",
                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                            Vl_adto = val.Vl_entrada,
                            ST_ADTO = "A",
                            TP_Lancto = "F",//Financeiro
                        }, qtb_locacao.Banco_Dados);
                    //Gravar Adto Locacao
                    TCN_AdtoLocacao.Gravar(new TRegistro_AdtoLocacao()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_locacao = val.Id_locacao,
                        Id_adtostr = CamadaDados.TDataQuery.getPubVariavel(Id_adtostr, "@P_ID_ADTO"),
                    }, qtb_locacao.Banco_Dados);
                }
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
                //Cancelar Estoque acessorios
                qtb_loc.executarSql("update tb_est_estoque set st_registro = 'C', dt_alt = getdate() " +
                                             "from tb_est_estoque a " +
                                             "where exists(select 1 from TB_LOC_AcessoriosItem x " +
                                             "             where a.cd_empresa = x.cd_empresa " +
                                             "             and a.CD_Produto = x.CD_Produto " +
                                             "             and a.Id_LanctoEstoque = x.Id_LanctoEstoque_S " +
                                             "             and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                             "             and x.id_locacao = " + val.Id_locacaostr + ") ", null);
                //Buscar Adiantamento
                CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdto =
                            new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                                            "where x.Id_adto = a.Id_adto " +
                                                            "and x.id_locacao = " + val.Id_locacaostr + " " +
                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "') "
                                            }
                                        }, 1, string.Empty);
                //Excluir Adto
                lAdto.ForEach(p => Financeiro.Adiantamento.TCN_LanAdiantamento.Excluir(p, qtb_loc.Banco_Dados));
                //Exclusão Lógica
                val.St_registro = "8";
                qtb_loc.Gravar(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void Faturar(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Criar Pre-Venda
                //Buscar CFG
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                   Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_loc.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração frente de caixa para realizar locação na empresa ");

                //Gerar item pre venda
                if (!val.St_registro.ToUpper().Equals("2")//Entregue
                    && val.lItens.Where(p => p.St_processar
                    && !string.IsNullOrEmpty(p.Dt_devolucaostr)).ToList().Exists(p => p.BaseCalc > decimal.Zero
                    && p.St_processar
                    && !p.Tp_tabela.Equals("4")))
                {
                    //Gerar PreVenda
                    CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                    rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                    rPreVenda.Cd_empresa = val.Cd_empresa;
                    rPreVenda.Cd_clifor = val.Cd_clifor;
                    rPreVenda.Nm_clifor = val.Nm_clifor;
                    rPreVenda.Id_pessoa = val.Id_pessoa;
                    rPreVenda.Nm_pessoa = val.Nm_pessoa;
                    rPreVenda.Cd_tabelaPreco = lCfg[0].Cd_tabelapreco;
                    rPreVenda.Cd_portador = val.Cd_portador;
                    rPreVenda.Cd_condPgto = val.Cd_condPgto;
                    rPreVenda.Cd_endereco = val.Cd_endereco;
                    rPreVenda.Ds_endereco = val.Ds_endereco;
                    rPreVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rPreVenda.Ds_observacao = val.Ds_obs;
                    rPreVenda.Vl_devcred = val.Vl_entrada;
                    rPreVenda.St_registro = "A";

                    RatearAcresc(val, val.lOutrasDesp.Sum(p => p.Vl_despesa));
                    val.lItens.Where(p => p.BaseCalc > decimal.Zero &&
                                          (p.Vl_unitario - p.Vl_desconto) > decimal.Zero &&
                                          p.St_processar &&
                                       !p.Tp_tabela.Equals("4")).ToList().ForEach(p =>
                                       {
                                           rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                                           {
                                               Cd_produto = p.Cd_produto,
                                               Ds_produto = p.Ds_produto,
                                               Quantidade = p.BaseCalc * p.QTDItem,
                                               Vl_unitario = p.Vl_unitario - p.Vl_desconto,
                                               Id_itemLoc = p.Id_itemloc,
                                               Vl_frete = p.Vl_frete,
                                               Vl_acrescimo = p.Vl_acresc
                                           });
                                       });
                    //Criar Pré-venda Acessorios
                    val.lItens.Where(p => p.St_processar && !p.Tp_tabela.Equals("4")).ToList().ForEach(p =>
                    {
                        p.lAcessorio.ForEach(x =>
                        {
                            //Adicionar somente acesssorios que foram utilizados.
                            if (x.QTD_Gasta > decimal.Zero)
                            {
                                rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                                {
                                    Cd_produto = x.Cd_produto,
                                    Ds_produto = x.Ds_produto,
                                    Quantidade = x.QTD_Gasta,
                                    Cd_tabelaPreco = lCfg[0].Cd_tabelapreco,
                                    Vl_unitario = x.Vl_unitario,
                                    Id_itemLoc = x.Id_itemloc
                                });
                            }
                        });
                    });
                    val.lPreVenda.Add(rPreVenda);
                    //Gravar PreVenda
                    Faturamento.PDV.TCN_PreVenda.Gravar(val.lPreVenda[0], qtb_loc.Banco_Dados);
                    //Amarrar Itens_X_PreVenda
                    val.lPreVenda[0].lItens.Where(p => string.IsNullOrEmpty(p.Cd_tabelaPreco)).ToList().ForEach(p => TCN_Itens_X_PreVenda.Gravar(
                                                            new TRegistro_Itens_X_PreVenda()
                                                            {
                                                                Cd_empresa = val.Cd_empresa,
                                                                Id_locacao = val.Id_locacao,
                                                                Id_prevenda = val.lPreVenda[0].Id_prevenda,
                                                                Id_itemprevenda = p.Id_itemprevenda,
                                                                Id_itemloc = p.Id_itemLoc
                                                            }, qtb_loc.Banco_Dados));

                    val.lItens.ForEach(p =>
                        {
                            p.lAcessorio.ForEach(x =>
                                {
                                    if (x.QTD_Gasta > 0)
                                    {
                                        //Amarrar Acessorios_X_PreVenda
                                        TCN_Acessorios_X_PreVenda.Gravar(new TRegistro_Acessorios_X_PreVenda()
                                        {
                                            Cd_empresa = x.Cd_empresa,
                                            Id_locacao = x.Id_locacao,
                                            Id_prevenda = val.lPreVenda[0].Id_prevenda,
                                            Id_itemprevenda = val.lPreVenda[0].lItens.Find(y => x.Cd_produto.Equals(y.Cd_produto)).Id_itemprevenda,
                                            Id_itemloc = x.Id_itemloc,
                                            Id_acessorio = x.Id_acessorio
                                        }, qtb_loc.Banco_Dados);
                                    }
                                });
                        });
                    //Baixa Itens Locacao
                    BaixaPatrimonio(val, qtb_loc.Banco_Dados);
                }
                else if (!val.St_registro.ToUpper().Equals("2")//Entregue
                        && val.lItens.Where(p => p.St_processar
                        && !string.IsNullOrEmpty(p.Dt_fechamentostr)
                        && !string.IsNullOrEmpty(p.Dt_devolucaostr)).ToList().Exists(p => p.BaseCalc > decimal.Zero
                                                                                     && p.St_processar
                                                                                     && p.Tp_tabela.Equals("4")))
                {
                    //Buscar data calculo de parcelas
                    object obj = new TCD_LanParcela(qtb_loc.Banco_Dados).BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_locacao = " + val.Id_locacaostr + ") )order by a.DT_Vencto desc -- "
                                                        }
                                                    }, "a.DT_Vencto");
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                        val.Dt_parcela = Convert.ToDateTime(obj);
                    else
                        val.Dt_parcela = val.Dt_locacao;
                    DateTime? dt_ini = val.lItens.Where(p =>
                    p.Tp_tabela.Equals("4")).Min(p => string.IsNullOrEmpty(p.Dt_retiradastr) ? p.Dt_locacao : p.Dt_retirada);
                    DateTime? dt_fin = val.lItens.Where(p =>
                        p.Tp_tabela.Equals("4")).Max(p => string.IsNullOrEmpty(p.Dt_fechamentostr) ?
                                                         (p.Dt_prevdev < CamadaDados.UtilData.Data_Servidor() ? CamadaDados.UtilData.Data_Servidor() : p.Dt_prevdev) :
                                                         p.Dt_fechamento);
                    TimeSpan ts = dt_fin.Value.Subtract(dt_ini.Value);
                    //Buscar Saldo Atual atualizado
                    object SaldofaturarAtual = new TCD_Locacao(qtb_loc.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa + "'",
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = val.Id_locacaostr,
                            }
                        }, "isnull(a.vl_locacao - a.vl_faturado, 0)");
                    decimal SaldoFaturar = decimal.Zero;
                    if (SaldofaturarAtual != null && !string.IsNullOrEmpty(SaldofaturarAtual.ToString()))
                        SaldoFaturar = decimal.Parse(SaldofaturarAtual.ToString());
                    //Calcular valor total
                    decimal valor = decimal.Zero;
                    if (SaldoFaturar > decimal.Zero)
                    {
                        valor = SaldoFaturar;
                        //Valor parcela
                        decimal vl_parcela = val.lItens.FindAll(p =>
                        p.Tp_tabela.Equals("4")).Sum(p => (p.QTDItem * p.Vl_unitario) - p.Vl_desconto);

                        //Calcular QTD.Parcelas 
                        decimal Qtd_parcFat = (Math.Round(decimal.Parse(ts.TotalDays.ToString()), 2) / 30) -
                                    val.lDup.Where(p => p.St_registro.ToUpper().Equals("A")).Count();
                        if (Qtd_parcFat < 1)
                            Qtd_parcFat = 1;
                        val.lParcDel = val.lParc;
                        val.lParc = Calcula_Parcelas(val, Qtd_parcFat, vl_parcela, valor, false, false);
                        val.St_registro = "7";//Devolvido

                        Gravar(val, qtb_loc.Banco_Dados);
                        if (val.lParc.Count > 0 &&
                            SaldoFaturar > 0)
                        {
                            TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                            CamadaDados.Locacao.Cadastros.TList_CFGLocacao lParam = new CamadaDados.Locacao.Cadastros.TList_CFGLocacao();
                            lParam = Cadastros.TCN_CFGLocacao.buscar(val.Cd_empresa, string.Empty, qtb_loc.Banco_Dados);
                            rDup.Cd_empresa = val.Cd_empresa;
                            rDup.Nm_empresa = val.Nm_empresa;
                            rDup.Cd_clifor = val.Cd_clifor;
                            rDup.Nm_clifor = val.Nm_clifor;
                            rDup.Cd_endereco = val.Cd_endereco;
                            rDup.Ds_endereco = val.Ds_endereco;
                            if (lParam.Count > 0)
                            {
                                rDup.Tp_docto = lParam[0].Tp_docto;
                                rDup.Ds_tpdocto = lParam[0].Ds_tpdocto;
                                rDup.Tp_duplicata = lParam[0].Tp_duplicata;
                                rDup.Ds_tpduplicata = lParam[0].Ds_tpduplicata;
                                rDup.Tp_mov = "R";
                                rDup.Cd_historico = lParam[0].Cd_historico;
                                rDup.Ds_historico = lParam[0].Ds_historico;
                                rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_centroresult = val.Tp_tabela.Equals("4") ? lParam[0].Cd_centroresultmes : val.Tp_tabela.Equals("5") ? lParam[0].Cd_centroresultsem : val.Tp_tabela.Equals("6") ? lParam[0].Cd_centroresultquinz : lParam[0].Cd_centroresultdia,
                                    Vl_lancto = val.lParc.Sum(p => p.Vl_parcela),
                                    Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_registro = "A"
                                });
                                //Buscar Moeda Padrao
                                CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                                    ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(val.Cd_empresa, qtb_loc.Banco_Dados);
                                if (tabela != null)
                                    if (tabela.Count > 0)
                                    {
                                        rDup.Cd_moeda = tabela[0].Cd_moeda;
                                        rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                                        rDup.Sigla_moeda = tabela[0].Sigla;
                                    }
                                decimal vl_devolver = decimal.Zero;
                                //Verificar vl.devolver no adiantamento da locação
                                if (val.Vl_entrada > decimal.Zero)
                                {
                                    object obj_devolver = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(qtb_loc.Banco_Dados).BuscarEscalar(
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
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                                            "where x.Id_adto = a.Id_adto " +
                                                            "and x.id_locacao = " + val.Id_locacaostr + " " +
                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "') "
                                            }
                                        }, "case when a.tp_movimento = 'C' then round(isnull(isnull(a.VL_Pagar, 0) - isnull(a.VL_Receber, 0), 0), 2) else round(isnull(isnull(a.VL_Receber, 0) - isnull(a.VL_Pagar, 0), 0), 2) end");
                                    vl_devolver = decimal.Parse(obj_devolver.ToString());
                                }
                                rDup.cVl_adiantamento = vl_devolver;
                                rDup.Vl_documento = val.lParc.Sum(p => p.Vl_parcela);
                                rDup.Ds_observacao = "LOCAÇÃO MENSAL REFERENTE AO MÊS " + CamadaDados.UtilData.Data_Servidor().ToString("MM/yyyy");
                                rDup.Dt_emissaostring = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                rDup.Nr_docto = "LOC" + val.Id_locacaostr + "-" +
                                   CamadaDados.UtilData.Data_Servidor().ToString("MM/yyyy");
                                //Buscar cond pagamento
                                CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                                    Financeiro.Cadastros.TCN_CadCondPgto.Buscar(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                decimal.Zero,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                string.Empty,
                                                                                qtb_loc.Banco_Dados);
                                if (lCond.Count > 0)
                                {
                                    rDup.Cd_condpgto = lCond[0].Cd_condpgto;
                                    rDup.Qt_parcelas = lCond[0].Qt_parcelas;
                                    rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                                }
                                rDup.Parcelas.Add(new TRegistro_LanParcela()
                                {
                                    Cd_parcela = 1,
                                    Dt_vencto = CamadaDados.UtilData.Data_Servidor().AddDays(30),
                                    Vl_parcela = val.lParc.Sum(p => p.Vl_parcela),
                                    Vl_parcela_padrao = val.lParc.Sum(p => p.Vl_parcela)
                                });
                                val.lDup.Clear();
                                val.lDup.Add(rDup);
                                GravaDuplicata(val, qtb_loc.Banco_Dados);
                            }
                        }
                    }
                    //Baixa Itens Locacao
                    BaixaPatrimonio(val, qtb_loc.Banco_Dados);
                }
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void DevolverAcessorios(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Buscar Empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                   Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_loc.Banco_Dados);
                //Buscar Local Arm
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_loc.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                //Gravar Acessorios
                val.lItens.Where(p => p.St_processar && !string.IsNullOrEmpty(p.Dt_devolucaostr)).ToList().ForEach(p =>
                    p.lAcessorio.Where(x => x.Qtd_baixa.Equals(0)).ToList().ForEach(x =>
                     {
                         if (x.QTD_Devolvida > decimal.Zero)
                         {
                             //Buscar Vl.Médio
                             decimal vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa,
                                                                                               x.Cd_produto,
                                                                                               qtb_loc.Banco_Dados);
                             //Gravar Estoque
                             string ret_est =
                                 Estoque.TCN_LanEstoque.GravarEstoque(
                                     new CamadaDados.Estoque.TRegistro_LanEstoque()
                                     {
                                         Cd_empresa = val.Cd_empresa,
                                         Cd_produto = x.Cd_produto,
                                         Cd_local = obj.ToString(),
                                         Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                         Tp_movimento = "E",
                                         //se for locação mensal devolve a QTD_Devolvida senão devolve tudo e da saida na qtd.gasta na prevenda.
                                         Qtd_entrada = !p.Tp_tabela.Equals("4") ? x.Quantidade : x.QTD_Devolvida,
                                         Qtd_saida = decimal.Zero,
                                         Vl_unitario = vl_unit,
                                         Vl_subtotal = vl_unit * (!p.Tp_tabela.Equals("4") ? x.Quantidade : x.QTD_Devolvida),
                                         Tp_lancto = "N",
                                         St_registro = "A",
                                         Ds_observacao = "DEVOLUÇÃO DE ACESSORIOS LOCAÇÃO Nº " + val.Id_locacaostr,
                                     }, qtb_loc.Banco_Dados);
                             x.Id_lanctoestoque_estr = CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE");
                             //Buscar Vl.Unitário
                             object vl_precoacessorio = new CamadaDados.Estoque.TCD_LanPrecoItem(qtb_loc.Banco_Dados).BuscarEscalar(
                                   new TpBusca[]
                                   {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + x.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + x.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_tabelapreco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCfg[0].Cd_tabelapreco.Trim() + "'"
                                }
                                   }, "a.Vl_PrecoVenda");
                             if (x.Vl_unitario.Equals(0))
                                 x.Vl_unitario = vl_precoacessorio == null || string.IsNullOrEmpty(vl_precoacessorio.ToString()) ? decimal.Zero : decimal.Parse(vl_precoacessorio.ToString());
                         }
                         //Gravar Acessorios
                         TCN_AcessoriosItem.Gravar(x, qtb_loc.Banco_Dados);
                     }));
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static string GravaDuplicata(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Marcar parcelas como faturadas
                val.lParc.ForEach(p =>
                    {
                        p.St_faturado = "S";
                        TCN_ParcelaLocacao.Gravar(p, qtb_loc.Banco_Dados);
                        //Gravar Comissão
                        val.lItens = TCN_ItensLocacao.buscar(val.Cd_empresa, val.Id_locacaostr, "A", qtb_loc.Banco_Dados);
                        val.lItens.ForEach(x =>
                        TCN_ItensLocacao.ProcessarComissao(x, p, qtb_loc.Banco_Dados));
                    });
                //Gravar Duplicata
                TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_loc.Banco_Dados);
                //Gerar Numero Recibo
                CamadaDados.Locacao.Cadastros.TList_CFGLocacao lCfg =
                    Cadastros.TCN_CFGLocacao.buscar(val.Cd_empresa, string.Empty, qtb_loc.Banco_Dados);
                TCN_Locacao_X_Duplicata.Gravar(new TRegistro_Locacao_X_Duplicata()
                {
                    Id_locacao = val.Id_locacao,
                    Cd_empresa = val.Cd_empresa,
                    Nr_lancto = val.lDup[0].Nr_lancto,
                    Nr_recibo = ++lCfg[0].Nr_seqrecibo,
                }, qtb_loc.Banco_Dados);
                Cadastros.TCN_CFGLocacao.Gravar(lCfg[0], qtb_loc.Banco_Dados);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static string GerarContrato(TRegistro_Locacao val, string Obs, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Buscar Ultimo Numero da sequencia
                decimal contrato = decimal.Zero;
                object obj = new TCD_Contrato().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            }
                        }, "max(a.nr_contrato)");
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    contrato = decimal.Parse(obj.ToString()) + 1;
                else
                    contrato = 1;
                //Gravar Contrato              
                TCN_Contrato.Gravar(new TRegistro_Contrato()
                {
                    Cd_empresa = val.Cd_empresa,
                    Id_locacao = val.Id_locacao,
                    Nr_contrato = contrato,
                    Dt_contrato = CamadaDados.UtilData.Data_Servidor(),
                    Obs = Obs
                }, qtb_loc.Banco_Dados);
                qtb_loc.Gravar(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void RatearFrete(TRegistro_Locacao val, decimal Vl_frete)
        {
            if (val != null)
            {
                val.lItens.ForEach(p =>
                {
                    p.Vl_frete = Math.Round(decimal.Divide(Vl_frete, val.lItens.Count), 2, MidpointRounding.AwayFromZero);
                });
                val.lItens[val.lItens.Count - 1].Vl_frete += Vl_frete - val.lItens.Sum(p => p.Vl_frete);
            }
        }

        public static void RatearDesconto(TRegistro_Locacao val, decimal Vl_desconto)
        {
            if (val != null)
            {
                if (val.lItens.Count > 0)
                {
                    val.lItens.ForEach(p =>
                    {
                        p.Vl_desconto = Math.Round(decimal.Divide(Vl_desconto, val.lItens.Count), 2, MidpointRounding.AwayFromZero);
                    });
                    val.lItens[val.lItens.Count - 1].Vl_desconto += Vl_desconto - val.lItens.Sum(p => p.Vl_desconto);
                }
            }
        }

        public static void RatearAcresc(TRegistro_Locacao val, decimal Vl_acresc)
        {
            if (val != null)
                if (val.lItens.Count > 0)
                {
                    val.lItens.ForEach(p => p.Vl_acresc = Math.Round(decimal.Divide(Vl_acresc, val.lItens.Count), 2, MidpointRounding.AwayFromZero));
                    val.lItens[val.lItens.Count - 1].Vl_acresc += Vl_acresc - val.lItens.Sum(p => p.Vl_acresc);
                }
        }

        public static void RatearDescontoLocacao(TRegistro_Locacao val, decimal Tot_desconto, decimal Pc_desconto)
        {
            if (val != null)
            {
                if (val.lItens.Count > 0)
                {
                    decimal tot_total = val.lItens.Sum(p => p.Vl_unitario);
                    if (Pc_desconto.Equals(decimal.Zero))
                        Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(Tot_desconto, 100), tot_total), 2, MidpointRounding.AwayFromZero);
                    if (Tot_desconto.Equals(decimal.Zero))
                        Tot_desconto = Math.Round(decimal.Multiply(Pc_desconto, decimal.Divide(tot_total, 100)), 2, MidpointRounding.AwayFromZero);
                    val.lItens.ForEach(p =>
                    {
                        p.Vl_desconto = Math.Round(decimal.Multiply(p.Vl_unitario, decimal.Divide(Pc_desconto, 100)), 2, MidpointRounding.AwayFromZero);
                    });
                    val.lItens[val.lItens.Count - 1].Vl_desconto += Tot_desconto - val.lItens.Sum(p => p.Vl_desconto);
                }
            }
        }

        public static void RecalcularParc(TRegistro_Locacao val, decimal valor)
        {
            if (val != null)
            {
                val.lParc.ForEach(p =>
                {
                    p.Vl_parcela = Math.Round(decimal.Divide(valor, val.lParc.Count), 2, MidpointRounding.AwayFromZero);
                });
                val.lParc[val.lParc.Count - 1].Vl_parcela += valor - val.lParc.Sum(p => p.Vl_parcela);
            }
        }

        public static void EstornarFinalizacao(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Buscar Pré-Venda
                CamadaDados.Faturamento.PDV.TList_PreVenda lPrevenda =
                    new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_loc.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_Itens_X_PreVenda x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_prevenda = a.id_prevenda " +
                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                            "and x.id_locacao = " + val.Id_locacaostr + ") or " +
                                            "              exists(select 1 from TB_LOC_Acessorios_X_PreVenda y " +
                                            "              where y.cd_empresa = a.cd_empresa " +
                                            "              and y.id_prevenda = a.id_prevenda " +
                                            "              and y.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                            "              and y.id_locacao = " + val.Id_locacaostr + ") "
                            }
                        }, 0, string.Empty, string.Empty);
                //Cancelar Pré-Venda
                lPrevenda.ForEach(p =>
                {
                    //Verificar se pre venda ja esta faturada
                    if (!p.St_faturada)
                    {
                        p.St_registro = "C";
                        Faturamento.PDV.TCN_PreVenda.Gravar(p, qtb_loc.Banco_Dados);
                    }
                    else
                        throw new Exception("Não é possivel estornar a finalização da Locação Nº " + p.Id_locacao.ToString().Trim() + "!\r\n" +
                                            "Pré-venda Nº " + p.Id_prevendastr.Trim() + " já está faturada!\r\n" +
                                            "Necessário excluir o faturamento da Pré-venda para fazer o estorno.");
                });
                //Estornar Locação
                string dev = string.Empty;
                //Se locação for a Ultima deste mesmo patrimônio, estornar devolução senão manter dt.devolução
                val.lItens.ForEach(p =>
                {
                    if (new TCD_ItensLocacao(qtb_loc.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(loc.st_registro, '0')",
                                    vOperador = "in",
                                    vVL_Busca = "('0', '2', '3')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.dt_retirada, loc.DT_Locacao)",
                                    vOperador = ">",
                                    vVL_Busca = "'" + Convert.ToDateTime(p.Dt_devolucao).ToString("yyyyMMdd HH:mm:ss") + "'"
                                }
                            }, "1") == null)
                    {
                        dev += "update TB_LOC_ItensLocacao set dt_devolucao = null, DT_Alt = GETDATE()  " +
                        "FROM TB_LOC_ItensLocacao a " +
                        "where a.id_locacao = " + val.Id_locacaostr + " " +
                        "and a.ID_ItemLoc = " + p.Id_itemlocstr + " " +
                        "and a.cd_empresa = '" + val.Cd_empresa.Trim() + "' ";
                    }
                });
                qtb_loc.executarSql("delete TB_LOC_DevItensLocacao where id_locacao = " + val.Id_locacaostr +
                                    "and cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    //Estornar acessórios
                                    "update TB_LOC_AcessoriosItem set QTD_Gasta = 0, QTD_Baixa = 0, Id_LanctoEstoque_E = null, DT_Alt = GETDATE() " +
                                    "where id_locacao = " + val.Id_locacaostr +
                                    "and cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    //Cancelar estoque acessorios
                                    "update TB_EST_Estoque set ST_Registro = 'C', DT_Alt = GETDATE() " +
                                    "from TB_LOC_AcessoriosItem a " +
                                    "inner join TB_EST_Estoque b " +
                                    "on a.CD_Empresa = b.CD_Empresa " +
                                    "and a.CD_Produto = b.CD_Produto " +
                                    "and a.Id_LanctoEstoque_E = b.id_lanctoestoque " +
                                    "where a.id_locacao = " + val.Id_locacao +
                                    "and a.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    ////Status para entregue
                                    "update TB_LOC_Locacao set St_registro = '2', DT_Alt = GETDATE()  " +
                                    "where id_locacao = " + val.Id_locacaostr +
                                    "and cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    dev +
                                    //Estornar finalização itens
                                    "update TB_LOC_ItensLocacao set DT_Fechamento = null, quantidade = 0, DT_Alt = GETDATE()  " +
                                             "from TB_LOC_ItensLocacao a " +
                                             "where a.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                             "and a.id_locacao = " + val.Id_locacaostr, null);
                //Verificar se existe comissao na locacao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_loc.Banco_Dados).Select(
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
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = val.Id_locacaostr
                            }
                        }, 0, string.Empty);
                //Excluir Comissao
                if (lComissao.Count > 0)
                    lComissao.ForEach(p => Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_loc.Banco_Dados));
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estorno finalização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void BaixaPatrimonio(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_loc = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //verificar se acessorio possui baixa
                bool ST_BaixaAcec =
                new CamadaDados.Locacao.TCD_AcessoriosItem(qtb_loc.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = val.Id_locacaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.QTD_Baixa",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                    }, "1") != null;
                //Baixa Patrimonio
                if (val.lItens.Exists(p => p.Qtd_baixada > decimal.Zero) || val.lItens.Exists(p => p.St_baixa) || ST_BaixaAcec)
                {
                    //Buscar Empresa
                    CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_loc.Banco_Dados);
                    CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                    rPreVenda.Cd_empresa = val.Cd_empresa;
                    rPreVenda.Cd_clifor = val.Cd_clifor;
                    rPreVenda.Nm_clifor = val.Nm_clifor;
                    rPreVenda.Id_pessoa = val.Id_pessoa;
                    rPreVenda.Nm_pessoa = val.Nm_pessoa;
                    rPreVenda.Cd_tabelaPreco = lCfg[0].Cd_tabelapreco;
                    rPreVenda.Cd_portador = val.Cd_portador;
                    rPreVenda.Cd_endereco = val.Cd_endereco;
                    rPreVenda.Ds_endereco = val.Ds_endereco;
                    rPreVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rPreVenda.Ds_observacao = "PRÉ-VENDA REFERENTE À COBRANÇA DE PATRIMÔNIO NÃO DEVOLVIDOS NA LOCAÇÃO Nº " +
                        val.Id_locacaostr;
                    rPreVenda.St_registro = "A";
                    val.lPreVenda.Add(rPreVenda);
                    if (val.lItens.Exists(p => string.IsNullOrEmpty(p.Dt_devolucaostr)))
                    {
                        val.lItens.FindAll(p => string.IsNullOrEmpty(p.Dt_devolucaostr)).ForEach(p =>
                        {
                            val.lPreVenda[val.lPreVenda.Count == 1 ? 0 : 1].lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                            {
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Quantidade = p.QTDItem,
                                Vl_unitario = p.Vl_patrimonio,
                                Id_itemLoc = p.Id_itemloc,
                                St_baixapatrimoniobool = true
                            });
                        });
                    }
                    else
                    {
                        val.lItens.FindAll(p => p.SaldoDevolver > decimal.Zero || p.Qtd_baixada > decimal.Zero).ForEach(p =>
                        {
                            val.lPreVenda[val.lPreVenda.Count == 1 ? 0 : 1].lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                            {
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Quantidade = p.SaldoDevolver > 0 ? p.SaldoDevolver : p.Qtd_baixada,
                                Vl_unitario = p.Vl_patrimonio,
                                Id_itemLoc = p.Id_itemloc,
                                St_baixapatrimoniobool = true
                            });
                        });
                    }
                    if (ST_BaixaAcec)
                    {
                        //Adicionar a Pré-Venda QTD Acessórios Baixada.
                        new CamadaDados.Locacao.TCD_AcessoriosItem(qtb_loc.Banco_Dados).Select(
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
                                        vNM_Campo = "a.id_locacao",
                                        vOperador = "=",
                                        vVL_Busca = val.Id_locacaostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.QTD_Baixa",
                                        vOperador = ">",
                                        vVL_Busca = "0"
                                    }
                            }, 0, string.Empty).ForEach(p =>
                            {
                                val.lPreVenda[val.lPreVenda.Count == 1 ? 0 : 1].lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                                {
                                    Cd_produto = p.Cd_produto,
                                    Ds_produto = p.Ds_produto,
                                    Quantidade = p.Qtd_baixa,
                                    Vl_unitario = p.Vl_baixa,
                                    Id_itemLoc = p.Id_itemloc,
                                    St_baixapatrimoniobool = true
                                });
                            });
                    }
                    //Gravar Pré-venda
                    val.lPreVenda.ForEach(p =>
                        {
                            Faturamento.PDV.TCN_PreVenda.Gravar(p, qtb_loc.Banco_Dados);
                            //Gravar Itens X Prevenda
                            p.lItens.ForEach(x =>
                                {
                                    TCN_Itens_X_PreVenda.Gravar(
                                                    new TRegistro_Itens_X_PreVenda()
                                                    {
                                                        Cd_empresa = val.Cd_empresa,
                                                        Id_locacao = val.Id_locacao,
                                                        Id_prevenda = p.Id_prevenda,
                                                        Id_itemprevenda = x.Id_itemprevenda,
                                                        Id_itemloc = x.Id_itemLoc
                                                    }, qtb_loc.Banco_Dados);
                                    ////Gravar baixa
                                    //TCN_DevItensLocacao.Gravar(new TRegistro_DevItensLocacao()
                                    //{
                                    //    Cd_empresa = val.Cd_empresa,
                                    //    Id_locacao = val.Id_locacao,
                                    //    Id_itemloc = x.Id_itemLoc,
                                    //    Qtd_baixada = x.Quantidade
                                    //}, qtb_loc.Banco_Dados);
                                    //Verificar se Patrimonio é quantidade 1 para cancelar senão pular processo
                                    //qtb_loc.executarSql(x.Quantidade > 0 ? "update TB_EST_Patrimonio set Quantidade -= " + x.Quantidade + 
                                    //                        "where cd_patrimonio = '" + x.Cd_produto.Trim() + "' " +
                                    //                        "and quantidade > 1 " :

                                    //                        "update TB_EST_Produto set St_registro = 'C' " +
                                    //                        "where cd_produto = '" + x.Cd_produto.Trim() + "' ", null);
                                });
                        });
                }
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir estorno finalização: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static TList_ParcelaLocacao Calcula_Parcelas(TRegistro_Locacao val,
                                                           decimal QTD_Parcelas,
                                                           decimal Vl_locacao,
                                                           decimal vl_total,
                                                           bool st_recalcular,
                                                           bool st_ratearFrete)
        {
            //Valor Unitario = vl_locacao
            //Valor Total Calculado = vl_total
            decimal valor = vl_total;
            decimal vl_frete = decimal.Zero;
            TList_ParcelaLocacao retorno = new TList_ParcelaLocacao();
            if ((Vl_locacao > 0) && (QTD_Parcelas > 0))
            {
                TList_Parcelas Lista_Parcela = TLanCalcParcelas.CalcularParcelas(!st_recalcular ? Vl_locacao : vl_total,
                                                                                 !st_recalcular ? Vl_locacao : vl_total,
                                                                                 val.Dt_parcela.Value,
                                                                                 QTD_Parcelas,
                                                                                 30);
                for (int i = 0; i < Lista_Parcela.Count; i++)
                {
                    DateTime dt_vencto = val.Dt_parcela.Value.AddMonths(i + 1);
                    TCN_LanDuplicata.validaFeriado(true, ref dt_vencto);
                    Lista_Parcela[i].Dt_vencimento = dt_vencto;
                }
                int cont = 1;
                if (!st_ratearFrete && val.Vl_faturado.Equals(decimal.Zero))
                    vl_frete = val.lItens.FindAll(p => p.Tp_tabela.Equals("4")).Sum(p => p.Vl_frete);
                Lista_Parcela.ForEach(p =>
                {
                    if ((!st_recalcular ? (valor >= Vl_locacao ? Vl_locacao : valor) : p.Vl_parcela) > 0)
                    {
                        Vl_locacao += vl_frete;
                        retorno.Add(
                            new TRegistro_ParcelaLocacao()
                            {
                                Dt_locacao = val.Dt_locacao,
                                DiasVencto = p.Dt_vencimento.Value.Subtract(val.Dt_locacao.Value).Days,
                                Vl_parcela = !st_recalcular ? (valor >= Vl_locacao ? Vl_locacao : valor) : p.Vl_parcela,
                                id_parcela = cont++
                            });
                        //Colocar valor do frete na primeira parcela 
                        //se não estiver opção marcada para ratear
                        Vl_locacao = Vl_locacao - vl_frete;
                        valor = valor - Vl_locacao - vl_frete;
                        vl_frete = decimal.Zero;
                    }
                });
                //Calcular comissao
                decimal vl_basecalc = val.Vl_locacao - val.Vl_frete - val.lItens.Sum(x => x.Vl_acessorios) - val.lItens.Sum(x => x.Vl_Baixa);
                for (int i = 0; i < retorno.Count; i++)
                {
                    decimal vl_parcela = Math.Round(vl_basecalc / retorno.Count, 2);
                    retorno[i].Vl_comissao = vl_parcela;
                }
                retorno[retorno.Count - 1].Vl_comissao += vl_basecalc - retorno.Sum(p => p.Vl_comissao);
            }
            return retorno;
        }

        public static void RecalcDiaVencto(TList_ParcelaLocacao val, int index)
        {
            for (
                int i = (index + 1); i < val.Count; i++)
            {
                DateTime venctoant = val[i - 1].Dt_vencto;
                DateTime dt_atual = venctoant.AddMonths(1);
                int diavenctoatual = dt_atual.Subtract(venctoant).Days;
                val[i].DiasVencto = val[i - 1].DiasVencto + diavenctoatual;
            }
        }

        public static void FinalizarLocacao(TRegistro_Locacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                val.lItensDel.ForEach(p => TCN_ItensLocacao.Excluir(p, qtb_locacao.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    p.Id_locacao = val.Id_locacao;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_ItensLocacao.Gravar(p, qtb_locacao.Banco_Dados);
                });
                //Faturar Locação
                if (val.lItens.Exists(p => !string.IsNullOrEmpty(p.Dt_fechamentostr)))
                {
                    //Faturar Locação
                    Faturar(val, qtb_locacao.Banco_Dados);
                    //Processar Comissão
                    val.lItens.FindAll(p => !string.IsNullOrEmpty(p.Dt_fechamentostr)).ForEach(p =>
                     TCN_ItensLocacao.ProcessarComissao(p, null, qtb_locacao.Banco_Dados));
                }
                //Verificar se Locação pode ser finalizada
                System.Collections.Hashtable h = new System.Collections.Hashtable();
                h.Add("@P_ID_LOCACAO", val.Id_locacao);
                h.Add("@OBS", val.Ds_obs);
                h.Add("@STATUS", val.St_registro.Trim().Equals("9") ? "7" : val.lItens.Exists(p => !p.Dt_fechamento.HasValue) ? "6" : "3");
                qtb_locacao.executarSql("update TB_LOC_Locacao set ST_REGISTRO = @STATUS, DS_Obs = @OBS, dt_alt = getdate() " +
                                        "where ID_LOCACAO = @P_ID_LOCACAO", h);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static void ConfirmarEntrega(TRegistro_Locacao val, TRegistro_ColetaEntrega entrega, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao qtb_locacao = new TCD_Locacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Status Locacao
                val.St_registro = "2";//Entregue
                qtb_locacao.Gravar(val);
                TCN_ColetaEntrega.GravarColEnt(entrega, qtb_locacao.Banco_Dados);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro confirmar entrega: " + ex.Message.Trim());
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
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.St_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }

            return new TCD_ItensLocacao(banco).Select(vBusca, 0, string.Empty, false);
        }

        public static string Gravar(TRegistro_ItensLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_itens = new TCD_ItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemlocstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEMLOC");
                //Verificar se item controla horas
                if (val.St_controlehorabool)
                {
                    System.Collections.Hashtable hs = new System.Collections.Hashtable();
                    hs.Add("@P_QTD_HORAS", val.Qtd_horasAtual);
                    hs.Add("@P_CD_PRODUTO", val.Cd_produto);
                    qtb_itens.executarSql("update TB_EST_Patrimonio set qtd_horas = @P_QTD_HORAS, dt_alt = getdate() " +
                                            "where CD_Patrimonio = @P_CD_PRODUTO", hs);
                }
                //Buscar Local Arm
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal(qtb_itens.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                    }
                    }, "a.CD_Local");
                if (obj == null)
                    throw new Exception("Não existe Local de armazenagem configurado para locação!");
                val.lAcessoriosDel.ForEach(p => TCN_AcessoriosItem.Excluir(p, qtb_itens.Banco_Dados));
                val.lAcessorio.Where(x => string.IsNullOrEmpty(x.Id_lanctoestoque_sstr)).ToList().ForEach(p =>
                {
                    if (p.St_gerarLanctoS)
                    {
                    //Buscar Vl.Médio
                    decimal vl_unit = Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa,
                                                                                            p.Cd_produto,
                                                                                            qtb_itens.Banco_Dados);
                    //Gravar Estoque
                    string ret_est = Estoque.TCN_LanEstoque.GravarEstoque(
                                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                                        {
                                            Cd_empresa = val.Cd_empresa,
                                            Cd_produto = p.Cd_produto,
                                            Cd_local = obj.ToString(),
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Tp_movimento = "S",
                                            Qtd_entrada = decimal.Zero,
                                            Qtd_saida = p.Quantidade,
                                            Vl_unitario = vl_unit,
                                            Vl_subtotal = vl_unit * p.Quantidade,
                                            Tp_lancto = "N",
                                            St_registro = "A",
                                            Ds_observacao = "LANÇAMENTO DE ACESSORIOS LOCAÇÃO Nº " + val.Id_locacaostr,
                                        }, qtb_itens.Banco_Dados);
                        p.Id_lanctoestoque_sstr = CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE");
                    }

                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_locacao = val.Id_locacao;
                    p.Id_itemloc = val.Id_itemloc;
                //Gravar Acessorios
                TCN_AcessoriosItem.Gravar(p, qtb_itens.Banco_Dados);
                });

                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemlocstr;
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
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
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

        public static string TrocaItem(TRegistro_ItensLocacao val, TRegistro_ItensLocacao val1, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_loc = new TCD_ItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Gravar OS
                if (val.rOs != null)
                    Servicos.TCN_LanServico.Gravar(val.rOs, qtb_loc.Banco_Dados);
                //Se item estiver retirado, nao registrar a troca, somente trocar o item da locação.
                if (!string.IsNullOrEmpty(val.Dt_retiradastr))
                {
                    //Gravar Itens
                    val.St_registro = "C";
                    val.Dt_devolucao = CamadaDados.UtilData.Data_Servidor();
                    val.Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                    //Gravar Novo Item
                    val1.Id_itemlocstr = CamadaDados.TDataQuery.getPubVariavel(qtb_loc.Gravar(val1), "@P_ID_ITEMLOC");
                    ////Verificar se item trocado tinha acessorios
                    //TCN_AcessoriosItem.buscar(val.Cd_empresa,
                    //                          val.Id_locacaostr,
                    //                          val.Id_itemlocstr,
                    //                          string.Empty,
                    //                          qtb_loc.Banco_Dados).ForEach(p =>
                    //                          {
                    //                              p.Id_itemloc = val1.Id_itemloc;
                    //                              TCN_AcessoriosItem.Gravar(p, qtb_loc.Banco_Dados);
                    //                          });
                    //Gravar Itens Troca
                    TCN_ItensTroca.Gravar(new TRegistro_ItensTroca()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_locacao = val.Id_locacao,
                        Id_itemloc = val.Id_itemloc,
                        Id_itemlocDest = val1.Id_itemloc
                    }, qtb_loc.Banco_Dados);
                }
                else
                    val.Cd_produto = val1.Cd_produto;
                qtb_loc.Gravar(val);
                //Verificar se item controla horas
                if (val1.St_controlehorabool)
                {
                    System.Collections.Hashtable hs = new System.Collections.Hashtable();
                    hs.Add("@P_QTD_HORAS", val1.Qtd_horasAtual);
                    hs.Add("@P_CD_PRODUTO", val1.Cd_produto);
                    qtb_loc.executarSql("update TB_EST_Patrimonio set qtd_horas = @P_QTD_HORAS, dt_alt = getdate() " +
                                            "where CD_Patrimonio = @P_CD_PRODUTO", hs);
                }
                //Buscar Valor Atualizado da locação a faturar
                object obj = new TCD_Locacao(qtb_loc.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"},
                                new TpBusca{vNM_Campo = "a.id_locacao", vOperador = "=", vVL_Busca = val.Id_locacaostr }
                                }, "isnull(a.vl_locacao, 0) - isnull(a.vl_faturado, 0)");
                if (obj != null)
                {
                    //Buscar parcelas em aberto
                    TList_ParcelaLocacao lParc = new TCD_ParcelaLocacao(qtb_loc.Banco_Dados)
                        .Select(
                        new TpBusca[]
                        {
                        new TpBusca{vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"},
                        new TpBusca{vNM_Campo = "a.id_locacao", vOperador = "=", vVL_Busca = val.Id_locacaostr },
                        new TpBusca{vNM_Campo = "isnull(a.st_faturado, 'N')", vOperador = "<>", vVL_Busca = "'S'"}
                        }, 0, string.Empty);
                    if (lParc.Count > 0)
                    {
                        //Atualizar valor das parcelas em Aberto
                        lParc.ForEach(p => p.Vl_parcela = Math.Round(decimal.Divide(decimal.Parse(obj.ToString()), lParc.Count), 2, MidpointRounding.AwayFromZero));
                        lParc[lParc.Count - 1].Vl_parcela += decimal.Parse(obj.ToString()) - lParc.Sum(p => p.Vl_parcela);
                        lParc.ForEach(p => TCN_ParcelaLocacao.Gravar(p, qtb_loc.Banco_Dados));
                    }
                }
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();

                return val1.Id_itemlocstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar trocar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_ItensLocacao val, TRegistro_ParcelaLocacao parc, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_itens = new TCD_ItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                        val.Cd_empresa,
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
                                                                        val.Id_locacaostr,
                                                                        val.Id_itemlocstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        qtb_itens.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    //Verificar se comissao possui faturamento
                    if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_itens.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lComissao[0].Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_comissao",
                                        vOperador = "=",
                                        vVL_Busca = lComissao[0].Id_comissaostr
                                    }
                                    }, "1") == null)
                        Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(lComissao[0], qtb_itens.Banco_Dados);
                    else
                        throw new Exception("Locação possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                }
                if (!string.IsNullOrEmpty(val.Cd_vendedor))
                {
                    decimal vl_basecalc = decimal.Zero;
                    if (parc != null)
                    {
                        //Buscar Valor Total da Locacao
                        object obj = new TCD_ItensLocacao(qtb_itens.Banco_Dados).BuscarEscalar(
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
                                            vNM_Campo = "a.id_locacao",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_locacaostr
                                        }
                                        }, "ISNULL(SUM(ISNULL(a.qtditem, 1) * (a.Base_Calc * (a.vl_unitario - ISNULL(a.vl_desconto, 0)))), 0)");
                        //se o valor calculado da locação for 0 zerar a base de calculo
                        if (obj == null ? true : decimal.Parse(obj.ToString()).Equals(decimal.Zero))
                            vl_basecalc = decimal.Zero;
                        else
                        {
                            decimal perc = (val.Vl_locacao - val.Vl_frete - val.Vl_Baixa) * 100 / decimal.Parse(obj.ToString());
                            vl_basecalc = parc.Vl_comissao * perc / 100;
                        }
                    }
                    else
                        vl_basecalc = Math.Round((val.QTDItem * (val.BaseCalc * (val.Vl_unitario - val.Vl_desconto))), 2);
                    decimal pc_comissao = decimal.Zero;
                    string tp_comissao = "P";
                    decimal vl_comissao = Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                                        val.Cd_vendedor,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        val.Cd_produto,
                                                                                                        decimal.Zero,
                                                                                                        ref vl_basecalc,
                                                                                                        ref pc_comissao,
                                                                                                        ref tp_comissao,
                                                                                                        qtb_itens.Banco_Dados);
                    //Gravar fechamento comissao
                    if (vl_comissao > decimal.Zero)
                    {
                        Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                            new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_vendedor = val.Cd_vendedor,
                                Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_itens.Banco_Dados),
                                Id_locacao = val.Id_locacao,
                                Id_item = val.Id_itemloc,
                                Tp_comissao = tp_comissao,
                                Pc_comissao = pc_comissao,
                                Vl_basecalc = vl_basecalc,
                                Vl_comissao = vl_comissao
                            }, qtb_itens.Banco_Dados);
                        if (st_transacao)
                            qtb_itens.Banco_Dados.Commit_Tran();
                    }
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void TrocarTabelaPreco(TRegistro_Locacao val, string Id_tabela, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocacao qtb_loc = new TCD_ItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else qtb_loc.Banco_Dados = banco;
                val.lItens.ForEach(p =>
                {
                //Buscar preco do item
                object obj = new CamadaDados.Locacao.Cadastros.TCD_CadPrecoItens(qtb_loc.Banco_Dados).BuscarEscalar(
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
                                        vNM_Campo = "a.id_tabela",
                                        vOperador = "=",
                                        vVL_Busca = Id_tabela
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    }
                                    }, "a.vl_preco");
                    if (obj != null)
                    {
                        p.Id_tabelastr = Id_tabela;
                        p.Vl_unitario = decimal.Parse(obj.ToString());
                    //Calcular desconto
                    CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = null;
                    //Verificar se existe programacao especial de venda 
                    rProg = Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(val.Cd_empresa,
                                                                                                val.Cd_clifor,
                                                                                                p.Cd_produto,
                                                                                                string.Empty,
                                                                                                null);
                        if (rProg != null)
                            if (rProg.Valor > decimal.Zero)
                            {
                                if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                                    p.Vl_desconto = rProg.Valor;
                                else
                                    p.Vl_desconto = p.Vl_unitario * rProg.Valor / 100;
                            }
                            else p.Vl_desconto = decimal.Zero;
                        else p.Vl_desconto = decimal.Zero;
                        qtb_loc.Gravar(p);
                    }
                    else throw new Exception("Item " + p.Cd_produto.Trim() + " não possui preço cadastrado na tabela " + Id_tabela);
                });
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar tabela locação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Locacao_X_Duplicata
    {
        public static TList_Locacao_X_Duplicata Buscar(string Id_locacao,
                                                        string Cd_empresa,
                                                        string Nr_lancto,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
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
            return new TCD_Locacao_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanDuplicata BuscarDup(string Cd_empresa,
                                                        string Id_locacao,
                                                        BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanDuplicata(banco).Select(
                new TpBusca[]
                {
                new TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from TB_LOC_LOCACAO_X_DUPLICATA x " +
                                "where x.cd_empresa = a.cd_empresa " +
                                "and x.nr_lancto = a.nr_lancto " +
                                "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                "and x.id_locacao = '" + Id_locacao.Trim() + "')"
                }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Locacao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao_X_Duplicata qtb_os = new TCD_Locacao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Locacao_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Locacao_X_Duplicata qtb_os = new TCD_Locacao_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ParcelaLocacao
    {
        public static TList_ParcelaLocacao Buscar(string Id_locacao,
                                                    string Cd_empresa,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_ParcelaLocacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ParcelaLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelaLocacao qtb_pre = new TCD_ParcelaLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                string retorno = qtb_pre.Gravar(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar financeiro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ParcelaLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ParcelaLocacao qtb_pre = new TCD_ParcelaLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pre.CriarBanco_Dados(true);
                else
                    qtb_pre.Banco_Dados = banco;
                qtb_pre.Excluir(val);
                if (st_transacao)
                    qtb_pre.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pre.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir financeiro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pre.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AdtoLocacao
    {
        public static TList_AdtoLocacao Buscar(string Id_locacao,
                                                string Cd_empresa,
                                                string Id_adto,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_adto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_adto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_adto;
            }
            return new TCD_AdtoLocacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AdtoLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoLocacao qtb_os = new TCD_AdtoLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AdtoLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AdtoLocacao qtb_os = new TCD_AdtoLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_DevItensLocacao
    {
        public static TList_DevItensLocacao buscar(string Cd_empresa,
                                                    string Id_locacao,
                                                    string Id_itemloc,
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
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }

            return new TCD_DevItensLocacao(banco).Select(vBusca, 0, string.Empty);


        }

        public static string Gravar(TRegistro_DevItensLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevItensLocacao qtb_itens = new TCD_DevItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_devolucaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_DEVOLUCAO");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_devolucaostr;
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

        public static string Excluir(TRegistro_DevItensLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevItensLocacao qtb_itens = new TCD_DevItensLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
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

    public class TCN_Contrato
    {
        public static TList_Contrato Buscar(string Id_locacao,
                                            string Cd_empresa,
                                            string Id_contrato,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_contrato;
            }
            return new TCD_Contrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_os = new TCD_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                val.Id_contratostr = CamadaDados.TDataQuery.getPubVariavel(qtb_os.Gravar(val), "@P_ID_CONTRATO");
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return val.Id_contratostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_os = new TCD_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensTroca
    {
        public static TList_ItensTroca buscar(string Cd_empresa,
                                                string Id_locacao,
                                                string Id_itemloc,
                                                string Id_itemlocDest,
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
            if (!string.IsNullOrEmpty(Id_itemloc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemloc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemloc;
            }
            if (!string.IsNullOrEmpty(Id_itemlocDest))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemlocDest";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemlocDest;
            }

            return new TCD_ItensTroca(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensTroca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensTroca qtb_itens = new TCD_ItensTroca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static string Excluir(TRegistro_ItensTroca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensTroca qtb_itens = new TCD_ItensTroca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
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

    public class TCN_Historico
    {
        public static TList_Historico buscar(string Cd_empresa,
                                                string Id_locacao,
                                                string Id_historico,
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
            if (!string.IsNullOrEmpty(Id_historico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_historico";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_historico;
            }

            return new TCD_Historico(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Historico qtb_itens = new TCD_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_historicostr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_HISTORICO");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_historicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar historico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Historico qtb_itens = new TCD_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir historico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_OutrasDesp
        {
            public static TList_OutrasDesp buscar(string Cd_empresa,
                                                  string Id_locacao,
                                                  string Id_despesa,
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
                if (!string.IsNullOrEmpty(Id_despesa))
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_despesa";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                    vBusca[vBusca.Length - 1].vVL_Busca = Id_despesa;
                }

                return new TCD_OutrasDesp(banco).Select(vBusca, 0, string.Empty);
            }

            public static string Gravar(TRegistro_OutrasDesp val, BancoDados.TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_OutrasDesp qtb_itens = new TCD_OutrasDesp();
                try
                {
                    if (banco == null)
                        st_transacao = qtb_itens.CriarBanco_Dados(true);
                    else
                        qtb_itens.Banco_Dados = banco;
                    val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_DESPESA");
                    if (st_transacao)
                        qtb_itens.Banco_Dados.Commit_Tran();
                    return val.Id_despesastr;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_itens.Banco_Dados.RollBack_Tran();
                    throw new Exception("Erro gravar despesa: " + ex.Message.Trim());
                }
                finally
                {
                    if (st_transacao)
                        qtb_itens.deletarBanco_Dados();
                }
            }

            public static string Excluir(TRegistro_OutrasDesp val, BancoDados.TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_OutrasDesp qtb_itens = new TCD_OutrasDesp();
                try
                {
                    if (banco == null)
                        st_transacao = qtb_itens.CriarBanco_Dados(true);
                    else
                        qtb_itens.Banco_Dados = banco;
                    qtb_itens.Excluir(val);
                    if (st_transacao)
                        qtb_itens.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_itens.Banco_Dados.RollBack_Tran();
                    throw new Exception("Erro excluir despesa: " + ex.Message.Trim());
                }
                finally
                {
                    if (st_transacao)
                        qtb_itens.deletarBanco_Dados();
                }
            }
        }
}
