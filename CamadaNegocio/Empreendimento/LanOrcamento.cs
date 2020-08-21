using System;
using System.Linq;
using Utils;
using CamadaDados.Empreendimento;
using CamadaDados.Faturamento.Comissao;

namespace CamadaNegocio.Empreendimento
{
    public class TCN_Orcamento
    {
        public static TList_Orcamento Buscar(string Cd_empresa,
                                             string Id_orcamento,
                                             string Nr_versao,
                                             string Cd_clifor,
                                             string Cd_vendedor,
                                             string Tp_data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string St_registro,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "('" + St_registro.Trim() + "')";
            }
            return new TCD_Orcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.loginorc = Parametros.pubLogin;
                string ret = qtb_orc.Gravar(val);
                val.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ORCAMENTO");
                val.Nr_versaostr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_VERSAO");
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        public static string GravarOrcReq(TRegistro_Orcamento val, TList_FichaTec litens, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.loginorc = Parametros.pubLogin;
                string ret = qtb_orc.Gravar(val);
                val.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ORCAMENTO");
                val.Nr_versaostr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_VERSAO");
                if (val.St_registro.Equals("E"))
                {
                    TCN_CompraEmpreendimento.GravarDireto(val, null, qtb_orc.Banco_Dados);
                    TCN_CompraEmpreendimento.GravarDireto(val, litens, qtb_orc.Banco_Dados);
                }
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        public static void Cancelar(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_item = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                CamadaDados.Empreendimento.Cadastro.TList_CadCFGEmpreendimento lcfg = new CamadaDados.Empreendimento.Cadastro.TList_CadCFGEmpreendimento();
                lcfg = Cadastro.TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);


                //Verificar se ja existe comissao
                TList_Fechamento_Comissao lComissao =
                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
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
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      val.Id_orcamentostr,
                                                                                      val.Nr_versaostr,
                                                                                      qtb_item.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    lComissao.ForEach(p =>
                    {
                        //Verificar se comissao possui faturamento
                        if (new TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                       vNM_Campo = string.Empty,
                                       vOperador = "exists",
                                       vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.id_comissao = x.id_comissao " +
                                                    "and x.id_orcamento = " + val.Id_orcamentostr +
                                                    "and x.nr_Versao = " + val.Nr_versaostr + ")"
                                    }
                            }, "1") == null)
                            Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados);
                        else
                            throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                    });
                }
                if (!string.IsNullOrEmpty(val.Cd_vendedor))
                {
                    decimal vl_basecalc = (val.total_orcamento);
                    decimal pc_comissao = val.Pc_comissao;
                    string tp_comissao = "P";
                    decimal vl_comissao = decimal.Zero;

                    if (pc_comissao > decimal.Zero)
                    {
                        vl_comissao = decimal.Multiply(val.total_orcamento, decimal.Divide(pc_comissao, 100));
                    }
                    else
                    {

                        CamadaDados.Faturamento.Cadastros.TList_Vendedor_X_Empresa lVendedor =
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Buscar(val.Cd_vendedor, val.Cd_empresa, banco);
                        if (lVendedor.Count > 0)
                        {
                            vl_comissao = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                                                                val.Cd_vendedor,
                                                                                                                                lcfg[0].Cd_tabelapreco,
                                                                                                                                val.cd_condpgto,
                                                                                                                                string.Empty,
                                                                                                                                1,
                                                                                                                                ref vl_basecalc,
                                                                                                                                ref pc_comissao,
                                                                                                                                ref tp_comissao,
                                                                                                                                qtb_item.Banco_Dados);
                        }
                        else
                            return;
                    }
                    if (pc_comissao > decimal.Zero)
                        CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                                new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_vendedor = val.Cd_vendedor,
                                    Id_orcamento = val.Id_orcamento,
                                    Nr_versaostr = val.Nr_versaostr,
                                    Dt_lancto = val.Dt_proposta,
                                    Tp_comissao = tp_comissao,
                                    Pc_comissao = pc_comissao,
                                    Vl_basecalc = vl_basecalc,
                                    Vl_comissao = vl_comissao
                                }, qtb_item.Banco_Dados);

                    if (st_transacao)
                        qtb_item.Banco_Dados.Commit_Tran();
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void Evoluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                #region Atividades
                //Calcular Valor Orçamento
                //val.vl_orcamento = CalcVlOrcamento(val);
                string retorno = qtb_orc.Gravar(val);
                val.Nr_versaostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_VERSAO");
                val.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ORCAMENTO");

                val.lTarefas.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    TCN_Tarefas.Gravar(p, qtb_orc.Banco_Dados);
                });

                val.lOEncargoDel.ForEach(p => Cadastro.TCN_OrcamentoEncargo.Excluir(p, qtb_orc.Banco_Dados));
                val.lOEncargo.ForEach(p =>
                {
                    p.Cd_empresastr = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    decimal total_folha = val.lMaoObra.Sum(o => o.vl_subtotal);
                    p.vl_encargo = total_folha * (p.pc_encargo / 100);
                    Cadastro.TCN_OrcamentoEncargo.Gravar(p, qtb_orc.Banco_Dados);
                });

                val.lMaoObraDel.ForEach(p => Cadastro.TCN_CadMaoObra.Excluir(p, qtb_orc.Banco_Dados));
                val.lMaoObra.ForEach(p =>
                {
                    p.Id_empresastr = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    Cadastro.TCN_CadMaoObra.Gravar(p, qtb_orc.Banco_Dados);
                });

                val.lOrcProjeto.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    TCN_OrcProjeto.Gravar(p, qtb_orc.Banco_Dados);
                    #region Ficha Tecnica
                    p.lFicha.ForEach(v =>
                    {
                        v.Cd_empresa = p.Cd_empresa;
                        v.Id_orcamento = p.Id_orcamento;
                        v.Nr_versao = p.Nr_versao;
                        v.Id_projeto = p.Id_projeto;
                        p.Id_registro = val.Id_registro;
                        TCN_FichaTec.Gravar(v, qtb_orc.Banco_Dados);
                        #region Ficha Item
                        v.lfichaItens.ForEach(x =>
                        {
                            x.Cd_empresa = v.Cd_empresa;
                            x.Id_orcamento = v.Id_orcamento;
                            x.Nr_versao = v.Nr_versao;
                            x.Id_projeto = v.Id_projeto;
                            x.Id_ficha = v.Id_ficha;
                            TCN_FichaItens.Gravar(x, qtb_orc.Banco_Dados);
                        });
                        v.lfichaItensDel.ForEach(x => TCN_FichaItens.Excluir(x, qtb_orc.Banco_Dados));
                        #endregion
                    });
                    p.lFichaDel.ForEach(v => TCN_FichaTec.Excluir(v, qtb_orc.Banco_Dados));
                    #endregion
                });
                val.lOrcProjetoDel.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));

                val.lRequisitos.ForEach(p =>
                {
                    p.id_orcamento = Convert.ToDecimal(val.Id_orcamentostr);
                    p.nr_versao = Convert.ToDecimal(val.Nr_versao);
                    p.cd_empresa = val.Cd_empresa;
                    TCN_RequisitoORc.Gravar(p, qtb_orc.Banco_Dados);
                });
                val.lDelRequisitos.ForEach(p =>
                {
                    TCN_RequisitoORc.Excluir(p, qtb_orc.Banco_Dados);
                });

                #endregion
                #region despesa
                val.lDespesas.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    TCN_Despesas.Gravar(p, qtb_orc.Banco_Dados);
                });
                val.lDespesasDel.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                #endregion

                //Processar Comissao
                if (val.St_registro.Trim().ToUpper().Equals("T"))// && val.calcular_comissao)
                    TCN_Orcamento.ProcessarComissao(val, qtb_orc.Banco_Dados);

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro evoluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        public static void ProcessarNFEmpreendimento(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, CamadaDados.Empreendimento.Cadastro.TRegistro_CadCFGEmpreendimento cfg, TRegistro_Orcamento rOrca, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_cond = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                //Buscar moeda padrao
                string moeda = ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", rNf.Cd_empresa, qtb_cond.Banco_Dados);
                if (string.IsNullOrEmpty(moeda))
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + rNf.Cd_empresa);
                //Gravar Pedido
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPed.CD_Empresa = rNf.Cd_empresa;
                rPed.CD_Clifor = rNf.Cd_clifor;
                rPed.CD_Endereco = rNf.Cd_endereco;
                rPed.Cd_moeda = moeda;
                rPed.Cd_moeda = moeda;
                rPed.CFG_Pedido = rNf.lCFGFiscal[0].Cfg_pedido;
                rPed.DT_Pedido = rNf.Dt_emissao;
                rPed.TP_Movimento = rNf.Tp_movimento; //Pedido de saida
                rPed.ST_Pedido = "F"; //Pedido fechado
                rPed.ST_Registro = "F"; //Pedido fechado
                //Montar itens do pedido
                rNf.ItensNota.ForEach(p =>
                {
                    rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                    {
                        Cd_Empresa = p.Cd_empresa,
                        Cd_local = cfg.cd_local,
                        Cd_produto = p.Cd_produto,
                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                        Cd_unidade_est = p.Cd_unidade,
                        Cd_unidade_valor = p.Cd_unidade,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_subtotal = p.Vl_subtotal
                    });
                });
                Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, qtb_cond.Banco_Dados);
                //Gravar Nota Fiscal
                rNf.Nr_pedido = rPed.Nr_pedido;
                for (int i = 0; i < rPed.Pedido_Itens.Count; i++)
                {
                    rNf.ItensNota[i].Nr_pedido = rPed.Pedido_Itens[i].Nr_pedido.Value;
                    rNf.ItensNota[i].Id_pedidoitem = rPed.Pedido_Itens[i].Id_pedidoitem;
                }
                Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_cond.Banco_Dados);
                //Amarrar Itens NF a Itens Condicional
                rNf.ItensNota.ForEach(p =>
                    TCN_RemessaNf.Gravar(new TRegistro_RemessaNf()
                    {
                        Cd_empresa = p.rItemFichaTec.Cd_empresa,
                        Id_orcamento = p.rItemFichaTec.Id_orcamento,
                        Nr_versao = p.rItemFichaTec.Nr_versao,
                        Id_registro = p.rItemFichaTec.Id_registro,
                        nr_lanctofiscal = p.Nr_lanctofiscal.ToString(),
                        id_nfitem = p.Id_pedidoitem.ToString(),
                        id_projeto = Convert.ToDecimal(p.rItemFichaTec.Id_projeto),
                        id_ficha = Convert.ToDecimal(p.rItemFichaTec.Id_ficha)
                    }, qtb_cond.Banco_Dados));
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar NF Projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                // Excluir despesas
                val.lDespesas.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                val.lDespesasDel.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                //    Excluir Projetos
                val.lDelRequisitos.ForEach(p =>
                {
                    TCN_RequisitoORc.Excluir(p, qtb_orc.Banco_Dados);
                });
                val.lOrcProjeto.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                val.lOrcProjetoDel.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                //  Excluir Orcamento
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        public static TRegistro_Orcamento GerarNovaVersao(TRegistro_Orcamento val,
                                                          string Ds_tarefa,
                                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                TRegistro_Orcamento orca = new TRegistro_Orcamento();

                orca = val;

                orca.lDespesas = TCN_Despesas.Buscar(val.Cd_empresa,
                                    val.Id_orcamentostr,
                                    val.Nr_versaostr,
                                    string.Empty,
                                    string.Empty,
                                    qtb_orc.Banco_Dados);
                orca.lMaoObra = CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(val.Id_orcamentostr,
                                    val.Nr_versaostr,
                                    val.Cd_empresa,
                                    string.Empty,
                                    qtb_orc.Banco_Dados);
                orca.lOEncargo = CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(string.Empty,
                                    val.Cd_empresa,
                                    val.Nr_versaostr,
                                    val.Id_orcamentostr,
                                    qtb_orc.Banco_Dados);
                orca.lTarefas = CamadaNegocio.Empreendimento.TCN_Tarefas.Buscar(
                                     val.Cd_empresa,
                                     val.Id_orcamentostr,
                                     val.Nr_versaostr,
                                     qtb_orc.Banco_Dados);
                orca.lRequisitos = CamadaNegocio.Empreendimento.TCN_RequisitoORc.Buscar(
                                     string.Empty,
                                     val.Cd_empresa,
                                     val.Id_orcamentostr,
                                     val.Nr_versaostr,
                                     qtb_orc.Banco_Dados);
                orca.lOrcProjeto = TCN_OrcProjeto.Buscar(val.Cd_empresa,
                                      val.Id_orcamentostr,
                                      val.Nr_versaostr,
                                      string.Empty,
                                      string.Empty,
                                      qtb_orc.Banco_Dados);
                orca.lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar(val.Cd_empresa, val.Id_orcamentostr, val.Nr_versaostr, p.Id_projetostr, p.Id_registrostr, string.Empty, null);
                    p.lFicha.ForEach(o =>
                    {
                        o.lfichaItens = TCN_FichaItens.Buscar(o.Cd_empresa,
                                                                o.Id_orcamentostr,
                                                                o.Nr_versaostr,
                                                                o.Id_projetostr,
                                                                o.Id_fichastr,
                                                                string.Empty,
                                                                qtb_orc.Banco_Dados);

                    });


                });

                //Gravar copia
                //orca.Id_orcamentostr = string.Empty;
                orca.Id_registrostr = string.Empty;
                orca.Nr_versaostr = null;
                orca.St_registro = "A";

                string retorno = qtb_orc.Gravar(orca);
                orca.Nr_versaostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_VERSAO");
                orca.Id_orcamentostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ORCAMENTO");
                //Gravar Atividades
                orca.lOrcProjeto.ForEach(p =>
                {
                    p.Nr_versao = orca.Nr_versao;
                    p.Id_orcamentostr = orca.Id_orcamentostr;
                    // p.Id_projeto = null;
                    TCN_OrcProjeto.Gravar(p, qtb_orc.Banco_Dados);
                });

                orca.lRequisitos.ForEach(p =>
                {
                    p.nr_versao = Convert.ToDecimal(orca.Nr_versao);
                    p.id_orcamento = Convert.ToDecimal(orca.Id_orcamentostr);
                    p.cd_empresa = orca.Cd_empresa;
                    // p.Id_projeto = null;
                    TCN_RequisitoORc.Gravar(p, qtb_orc.Banco_Dados);
                });
                //Gravar Despesas
                orca.lDespesas.ForEach(p =>
                {
                    p.Nr_versao = orca.Nr_versao;
                    p.Id_orcamentostr = orca.Id_orcamentostr;
                    TCN_Despesas.Gravar(p, qtb_orc.Banco_Dados);
                });
                //Gravar folha
                orca.lMaoObra.ForEach(p =>
                {
                    p.Nr_versao = orca.Nr_versao;
                    p.Id_orcamentostr = orca.Id_orcamentostr;
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Gravar(p, qtb_orc.Banco_Dados);
                });
                //Gravar tarefa
                orca.lTarefas.ForEach(p =>
                {
                    p.Nr_versao = orca.Nr_versao;
                    p.Id_orcamentostr = orca.Id_orcamentostr;
                    CamadaNegocio.Empreendimento.TCN_Tarefas.Gravar(p, qtb_orc.Banco_Dados);
                });
                //Gravar encargos
                orca.lOEncargo.ForEach(p =>
                {
                    p.Nr_versao = orca.Nr_versao;
                    p.Id_orcamentostr = orca.Id_orcamentostr;
                    CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Gravar(p, qtb_orc.Banco_Dados);
                });
                if (!string.IsNullOrEmpty(Ds_tarefa))
                    TCN_Tarefas.Gravar(new TRegistro_Tarefas()
                    {
                        Cd_empresa = orca.Cd_empresa,
                        Id_orcamento = orca.Id_orcamento,
                        Nr_versao = orca.Nr_versao,
                        Ds_tarefa = Ds_tarefa
                    }, qtb_orc.Banco_Dados);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return orca;

                //            //TRegistro_Orcamento copia = (TRegistro_Orcamento)val.Clone();
                //            //TCN_Despesas.Buscar(copia.Cd_empresa,
                //            //                    copia.Id_orcamentostr,
                //            //                    copia.Nr_versaostr,
                //            //                    string.Empty,
                //            //                    string.Empty,
                //            //                    qtb_orc.Banco_Dados).ForEach(p => copia.lDespesas.Add((TRegistro_Despesas)p.Clone()));
                //            //TCN_OrcProjeto.Buscar(copia.Cd_empresa,
                //            //                      copia.Id_orcamentostr,
                //            //                      copia.Nr_versaostr,
                //            //                      string.Empty,
                //            //                      string.Empty,
                //            //                      qtb_orc.Banco_Dados).ForEach(p =>
                //            //                        {
                //            //                            TRegistro_OrcProjeto orc = (TRegistro_OrcProjeto)p.Clone();
                //            //                            TCN_FichaTec.Buscar(p.Cd_empresa,
                //            //                                                p.Id_orcamentostr,
                //            //                                                p.Nr_versaostr,
                //            //                                                p.Id_projetostr,
                //            //                                                string.Empty,
                //            //                                                qtb_orc.Banco_Dados).ForEach(v =>
                //            //                                                {
                //            //                                                    TRegistro_FichaTec ficha = (TRegistro_FichaTec)v.Clone();
                //            //                                                    TCN_FichaItens.Buscar(v.Cd_empresa,
                //            //                                                                          v.Id_orcamentostr,
                //            //                                                                          v.Nr_versaostr,
                //            //                                                                          v.Id_projetostr,
                //            //                                                                          v.Id_fichastr,
                //            //                                                                          string.Empty,
                //            //                                                                          qtb_orc.Banco_Dados).ForEach(x => ficha.lfichaItens.Add((TRegistro_FichaItens)x.Clone()));
                //            //                                                    orc.lFicha.Add(ficha);
                //            //                                                });
                //            //                            copia.lOrcProjeto.Add(orc);
                //            //                        });
                //            //CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(copia.Id_orcamentostr,
                //            //                    copia.Nr_versaostr,
                //            //                    copia.Cd_empresa,
                //            //                    string.Empty,
                //            //                    qtb_orc.Banco_Dados).ForEach(p => copia.lMaoObra.Add((CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra)p.Clone()));
                //            //CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(string.Empty,
                //            //                    copia.Cd_empresa,
                //            //                    copia.Nr_versaostr,
                //            //                    copia.Id_orcamentostr,
                //            //                    qtb_orc.Banco_Dados).ForEach(p => copia.lOEncargo.Add((CamadaDados.Empreendimento.Cadastro.TRegistro_OrcamentoEncargo)p.Clone()));
                //            //CamadaNegocio.Empreendimento.TCN_Tarefas.Buscar(
                //            //                     copia.Cd_empresa,
                //            //                     copia.Id_orcamentostr,
                //            //                     copia.Nr_versaostr,
                //            //                     qtb_orc.Banco_Dados).ForEach(p => copia.lTarefas.Add((CamadaDados.Empreendimento.TRegistro_Tarefas)p.Clone()));

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar nova versão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
    public class TCN_Despesas
    {
        public static TList_Despesas Buscar(string Cd_empresa,
                                            string Id_orcamento,
                                            string Nr_versao,
                                            string Id_despesa,
                                            string Ds_despesa,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Id_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_despesa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_despesa;
            }
            if (!string.IsNullOrEmpty(Ds_despesa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_despesa";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_despesa.Trim() + "%'";
            }
            return new TCD_Despesas(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Despesas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesas qtb_desp = new TCD_Despesas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                val.Id_despesastr = CamadaDados.TDataQuery.getPubVariavel(qtb_desp.Gravar(val), "@P_ID_DESPESA");
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_Despesas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Despesas qtb_desp = new TCD_Despesas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                qtb_desp.Excluir(val);
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
                return val.Id_despesastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir despesa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }
    public class TCN_OrcProjeto
    {
        public static TList_OrcProjeto Buscar(string Cd_empresa,
                                              string Id_orcamento,
                                              string Nr_versao,
                                              string Id_projeto,
                                              string Ds_projeto,
                                              string st_registro_finalizado,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Id_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_projeto;
            }
            if (!string.IsNullOrEmpty(Ds_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.ds_atividade";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_projeto.Trim() + "%'";
            }
            if (st_registro_finalizado.Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'F'";
            }
            return new TCD_OrcProjeto(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_OrcProjeto Buscar(string Cd_empresa,
                                              string Id_orcamento,
                                              string Nr_versao,
                                              string Id_projeto,
                                              string Ds_projeto,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Id_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_projeto;
            }
            if (!string.IsNullOrEmpty(Ds_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_projeto";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_projeto.Trim() + "%'";
            }
            return new TCD_OrcProjeto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrcProjeto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrcProjeto qtb_orc = new TCD_OrcProjeto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                string retorno = qtb_orc.Gravar(val);
                val.Id_projetostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ATIVIDADE");
                val.Id_registrostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_REGISTRO");
                //Gravar Ficha
                val.lFicha.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_orcamento = val.Id_orcamento;
                        p.Nr_versao = val.Nr_versao;
                        p.Id_projeto = val.Id_projeto;
                        p.Id_registro = val.Id_registro;
                        TCN_FichaTec.Gravar(p, qtb_orc.Banco_Dados);
                    });

                //Excluir Ficha
                val.lFichaDel.ForEach(p => TCN_FichaTec.Excluir(p, qtb_orc.Banco_Dados));
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_projetostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrcProjeto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrcProjeto qtb_orc = new TCD_OrcProjeto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Excluir Ficha
                val.lFicha.ForEach(p => TCN_FichaTec.Excluir(p, qtb_orc.Banco_Dados));
                val.lFichaDel.ForEach(p => TCN_FichaTec.Excluir(p, qtb_orc.Banco_Dados));
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_projetostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir projeto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
    public class TCN_FichaTec
    {
        public static TList_FichaTec Buscar(string Cd_empresa,
                                            string Id_orcamento,
                                            string Nr_versao,
                                            string Id_projeto,
                                            string Id_Registro,
                                            string St_afaturar,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            if (!string.IsNullOrEmpty(Id_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_projeto;
            }
            if (!string.IsNullOrEmpty(Id_Registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_Registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_Registro;
            }
            if (St_afaturar.Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = " isnull(a.quantidade - a.qtd_faturada,0) ";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            return new TCD_FichaTec(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec qtb_ficha = new TCD_FichaTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else qtb_ficha.Banco_Dados = banco;

                val.Id_fichastr = CamadaDados.TDataQuery.getPubVariavel(qtb_ficha.Gravar(val), "@P_ID_FICHA");
                //Gravar itens ficha
                //Excluir Ficha
                val.lfichaItensDel.ForEach(p => TCN_FichaItens.Excluir(p, qtb_ficha.Banco_Dados));

                val.lfichaItens.ForEach(p =>
                {
                    p.Id_fichastr = val.Id_fichastr;
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_orcamento = val.Id_orcamento;
                    p.Nr_versao = val.Nr_versao;
                    p.Id_projeto = val.Id_projeto;
                    p.Id_registro = val.Id_registro;
                    TCN_FichaItens.Gravar(p, qtb_ficha.Banco_Dados);
                });
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return val.Id_fichastr;
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

        public static string Excluir(TRegistro_FichaTec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec qtb_ficha = new TCD_FichaTec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else qtb_ficha.Banco_Dados = banco;
                val.lfichaItens.ForEach(p => TCN_FichaItens.Excluir(p, qtb_ficha.Banco_Dados));
                val.lfichaItensDel.ForEach(p => TCN_FichaItens.Excluir(p, qtb_ficha.Banco_Dados));
                qtb_ficha.Excluir(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return val.Id_fichastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ficha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }
    }
    public static class TCN_RemessaNf
    {
        public static TList_RemessaNf Buscar(string Cd_empresa,
                                               string Id_orcamento,
                                               string Nr_versao,
                                               string Cd_clifor,
                                               string nr_lancto,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_orcamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_versao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_lancto.Trim() + "'";
            }



            return new TCD_RemessaNf(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_RemessaNf val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RemessaNf qtb_orc = new TCD_RemessaNf();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
    public class TCN_Tarefas
    {
        public static TList_Tarefas Buscar(string Cd_empresa,
                                           string Id_orcamento,
                                           string Nr_versao,
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
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }
            return new TCD_Tarefas(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Tarefas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Tarefas qtb_tarefa = new TCD_Tarefas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tarefa.CriarBanco_Dados(true);
                else qtb_tarefa.Banco_Dados = banco;
                val.Id_tarefastr = CamadaDados.TDataQuery.getPubVariavel(qtb_tarefa.Gravar(val), "@P_ID_TAREFA");
                if (st_transacao)
                    qtb_tarefa.Banco_Dados.Commit_Tran();
                return val.Id_tarefastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tarefa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tarefa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tarefa.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_Tarefas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Tarefas qtb_tarefa = new TCD_Tarefas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tarefa.CriarBanco_Dados(true);
                else qtb_tarefa.Banco_Dados = banco;
                qtb_tarefa.Excluir(val);
                if (st_transacao)
                    qtb_tarefa.Banco_Dados.Commit_Tran();
                return val.Id_tarefastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tarefa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tarefa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tarefa.deletarBanco_Dados();
            }
        }
    }



    public class TCN_RequisitoORc
    {
        public static TList_RequisitoORc Buscar(
                                              string id_REQUISITO,
                                              string cd_empresa,
                                              string id_orcamento,
                                              string nr_versao,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_REQUISITO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_REQUISITO";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_REQUISITO;
            }
            if (!string.IsNullOrEmpty(nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_versao;
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_orcamento;
            }
            return new TCD_RequisitoOrc(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_RequisitoOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RequisitoOrc qtb_cad = new TCD_RequisitoOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                val.id_requisito = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_cad.Gravar(val), "@P_ID_REQUISITO"));
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.id_requisito.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Requisito: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_RequisitoOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RequisitoOrc qtb_cad = new TCD_RequisitoOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cad.CriarBanco_Dados(true);
                else qtb_cad.Banco_Dados = banco;
                qtb_cad.Excluir(val);
                if (st_transacao)
                    qtb_cad.Banco_Dados.Commit_Tran();
                return val.id_requisito.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cad.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cad.deletarBanco_Dados();
            }
        }
    }
}
