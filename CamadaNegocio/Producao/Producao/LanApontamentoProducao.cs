using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using CamadaDados.Producao.Producao;
using CamadaNegocio.ConfigGer;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Estoque;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Estoque;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_ApontamentoProducao
    {
        public static TList_ApontamentoProducao Buscar(string Id_apontamento,
                                                       string Cd_empresa,
                                                       string Nr_loteproducao,
                                                       string Id_turno,
                                                       string Id_ordem,
                                                       string Dt_apontamento,
                                                       string Dt_validade,
                                                       string Tp_data,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       string St_registro,
                                                       int vTop,
                                                       string vNm_campo,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_apontamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_loteproducao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_loteproducao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_loteproducao;
            }
            if (!string.IsNullOrEmpty(Id_turno))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_turno";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_turno;
            }
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_prd_ordemproducao_x_apontamento x " +
                                                      "where x.id_apontamento = a.id_apontamento " +
                                                      "and x.id_ordem = " + Id_ordem + ")";
            }
            if ((!string.IsNullOrEmpty(Dt_apontamento)) && (Dt_apontamento.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_apontamento).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_validade)) && (Dt_validade.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_validade).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_apontamento" : "a.dt_validade";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_apontamento" : "a.dt_validade";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            return new TCD_ApontamentoProducao(banco).Select(filtro, vTop, vNm_campo);
        }

        private static decimal CalcularCustoMPD(TList_FichaTec_MPrima val,
                                                string Dt_apontamento,
                                                decimal Qtd_batch,
                                                BancoDados.TObjetoBanco banco)
        {
            val.ForEach(p =>
                {
                    if (p.Id_formulacao_mprima != null)
                    {
                        //Buscar lista de materia-prima
                        TList_FichaTec_MPrima lMPrima = TCN_FichaTec_MPrima.Buscar(p.Cd_empresa,
                                                                                   p.Id_formulacao_mprimastr,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   0,
                                                                                   string.Empty,
                                                                                   banco);
                        //Chamar o metodo CalcularCustoMPD recursivamente
                        p.Vl_custo = CalcularCustoMPD(lMPrima, Dt_apontamento, Qtd_batch, banco);
                        p.Vl_customedio = Math.Round(p.Vl_custo / p.Qtd_produto / Qtd_batch, 2);
                    }
                    else
                    {
                        p.Vl_customedio = TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade,
                                                                         p.Cd_unid_produto,
                                                                         TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.Cd_empresa, p.Cd_produto, banco), 5, banco);
                        p.Vl_custo = Math.Round(p.Vl_customedio * p.Qtd_produto * Qtd_batch, 2);
                    }
                });
            return val.Sum(p => p.Vl_custo);
        }

        public static void CalcularCustoMPD(TRegistro_ApontamentoProducao val, BancoDados.TObjetoBanco banco)
        {
            if (val != null)
                if(val.Dt_apontamento != null)
                    if (val.LFormulaApontamento.Count > 0)
                        val.Vl_custo_mpd = CalcularCustoMPD(val.LFormulaApontamento[0].LFichaTec_MPrima, val.Dt_apontamentostr, val.Qtd_batch, banco);
        }

        public static void CalcularCustoFixo(TRegistro_ApontamentoProducao val, BancoDados.TObjetoBanco banco)
        {
            if (val != null)
                if (val.LFormulaApontamento.Count > 0)
                {
                    val.LFormulaApontamento[0].LCustoFixo.ForEach(p =>
                        {
                            if (p.Vl_custo > 0)
                            {
                                string moeda_padrao = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", val.Cd_empresa, banco);
                                if (moeda_padrao.Trim().Equals(string.Empty))
                                    throw new Exception("Erro calcular custo fixo: falta configurar moeda padrão.");
                                if(p.Cd_moeda.Trim().Equals(moeda_padrao.Trim()))
                                    p.Vl_custo_calculado = p.Vl_custo * val.Qtd_batch;
                                else if (val.Dt_apontamento != null)
                                {
                                    decimal indice = decimal.Zero;
                                    p.Vl_custo_calculado = TCN_CotacaoMoeda.ConvertMoeda(p.Cd_moeda,
                                                                                         moeda_padrao,
                                                                                         val.Dt_apontamento.Value,
                                                                                         false,
                                                                                         p.Vl_custo,
                                                                                         ref indice,
                                                                                         banco) * val.Qtd_batch;
                                    p.Indice_monetario = indice;
                                }
                            }
                        });
                    val.Vl_custo_fixodireto = val.LFormulaApontamento[0].LCustoFixo.Sum(p => p.Vl_custo_calculado);
                }
        }
                
        public static string Gravar(TRegistro_ApontamentoProducao val, 
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ApontamentoProducao qtb_apontamento = new TCD_ApontamentoProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                if(val.LFormulaApontamento.Count < 1)
                    throw new Exception("Erro: Não existe formula apontamento para processar apontamento produção.");
                //Verificar custo fixo
                string moeda_padrao = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", val.Cd_empresa, qtb_apontamento.Banco_Dados);
                if (moeda_padrao.Trim().Equals(string.Empty))
                    throw new Exception("Erro gravar apontamento produção: falta configurar moeda padrão para realizar calculo do custo fixo.");
                //Gravar apontamento producao
                val.St_registro = "1";
                val.Id_apontamento = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_apontamento.Gravar(val), "@P_ID_APONTAMENTO"));
                List<TRegistro_CustoFixo_Direto> lCustoMoeda = val.LFormulaApontamento[0].LCustoFixo.FindAll(p => p.Cd_moeda.Trim() != moeda_padrao.Trim());
                lCustoMoeda.ForEach(p =>
                    {
                        //Verificar se existe cotacao para este custo
                        object obj = new TCD_CotacaoMoeda(qtb_apontamento.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_moeda",
                                    vOperador = "=",
                                    vVL_Busca = "'"+p.Cd_moeda.Trim()+"'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_moedaresult",
                                    vOperador = "=",
                                    vVL_Busca = "'"+moeda_padrao.Trim()+"'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.data",
                                    vOperador = "=",
                                    vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(val.Dt_apontamento.Value).ToString("yyyyMMdd"))+"'"
                                }
                            }, "1");
                        if (obj != null)
                        {
                            if (!obj.ToString().Equals("1"))
                                throw new Exception("Erro gravar apontamento produção: Não existe cotação para a moeda de origem " + p.Cd_moeda.Trim() + ", \r\n" +
                                                    "moeda de destino " + moeda_padrao.Trim() + ", data de cotação " + val.Dt_apontamentostr.Trim());
                        }
                        else
                            throw new Exception("Erro gravar apontamento produção: Não existe cotação para a moeda de origem " + p.Cd_moeda.Trim() + ", \r\n" +
                                                    "moeda de destino " + moeda_padrao.Trim() + ", data de cotação " + val.Dt_apontamentostr.Trim());
                    });
                CalcularCustoMPD(val, qtb_apontamento.Banco_Dados);
                //Processar estoque produto acabado
                ProcessarEstoqueProdutoAcabado(val, val.Qtd_batch, val.Vl_custo_mpd, qtb_apontamento.Banco_Dados);
                //Processar estoque materia-prima
                TCN_FichaTec_MPrima.ProcessarEstoqueFichaTec_MPrima(val.LFormulaApontamento[0].LFichaTec_MPrima,
                                                                    val.Qtd_batch,
                                                                    val.Dt_apontamento,
                                                                    val.LFormulaApontamento[0].St_decomposicao,
                                                                    qtb_apontamento.Banco_Dados).ForEach(p => val.LApontamentoEstoque.Add(p));
                //Gravar apontamento X Estoque
                val.LApontamentoEstoque.ForEach(p =>
                {
                    p.Id_apontamento = val.Id_apontamento;
                    TCN_Apontamento_Estoque.GravarApontamentoEstoque(p, qtb_apontamento.Banco_Dados);
                });
                
      
                //Gravar apontamento X Custo Fixo
                val.LFormulaApontamento[0].LCustoFixo.ForEach(p =>
                    {
                        TCN_Apontamento_CustoFixo.GravarApontamentoCustoFixo(
                            new TRegistro_Apontamento_CustoFixo()
                            {
                                Id_apontamento = val.Id_apontamento,
                                Id_custo = p.Id_custo,
                                Vl_custo = p.Vl_custo_calculado,
                                Indice_monetario = p.Indice_monetario
                            }, qtb_apontamento.Banco_Dados);
                    });
                //Gravar Formula Materia Prima
                val.LFormulaApontamento[0].LFichaTec_MPrima.ForEach(p =>
                        TCN_Apontamento_MPrima.Gravar(new TRegistro_Apontamento_MPrima()
                        {
                            Id_apontamento = val.Id_apontamento.HasValue ? val.Id_apontamento.Value : decimal.Zero,
                            Id_mprima = decimal.Zero,
                            Cd_produto = p.Cd_produto,
                            Cd_unidade = p.Cd_unidade,
                            Cd_local = p.Cd_local,
                            Qtd_produto = p.Qtd_produto,
                            Pc_quebratec = p.Pc_quebra_tec,
                            Id_apontamentomprima = p.Id_apontamentomprima
                        }, qtb_apontamento.Banco_Dados));
                if (val.Id_ordem != null)
                    //Gravar Apontamento X Ordem de Producao
                    TCN_OrdemProducao_X_Apontamento.Gravar(
                        new TRegistro_OrdemProducao_X_Apontamento()
                        {
                            Id_apontamento = val.Id_apontamento,
                            Id_ordem = val.Id_ordem
                        }, qtb_apontamento.Banco_Dados);            
                //Gravar Mov Rastreabilidade
                val.lMov.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_apontamento = val.Id_apontamento;
                        TCN_MovRastreabilidade.Gravar(p, qtb_apontamento.Banco_Dados);
                    });
                if (val.Id_ordem.HasValue)
                {
                    //Buscar Nº Série
                    TList_SerieProduto lSerie =
                        new TCD_SerieProduto(qtb_apontamento.Banco_Dados).Select(
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
                                    vNM_Campo = "a.id_ordem",
                                    vOperador = "=",
                                    vVL_Busca = val.Id_ordemstr
                                }
                            }, 0, string.Empty);
                    //Processar Numero se Serie
                    if (lSerie.Count > 0)
                        lSerie.ForEach(p =>
                        {
                            p.St_registro = "P";
                            TCN_SerieProduto.Gravar(p, qtb_apontamento.Banco_Dados);
                        });
                }
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return val.Id_apontamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }

        public static string Gravar2(TRegistro_ApontamentoProducao val,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ApontamentoProducao qtb_ap = new TCD_ApontamentoProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ap.CriarBanco_Dados(true);
                else qtb_ap.Banco_Dados = banco;
                //Gravar apontamento
                val.St_registro = "1";
                val.Id_apontamento = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_ap.Gravar(val), "@P_ID_APONTAMENTO"));
                decimal custo = decimal.Zero;
                //Baixar estoque ficha tecnica
                TCN_Ordem_MPrima.Buscar(val.Id_ordemstr, qtb_ap.Banco_Dados)
                    .ForEach(v =>
                    {
                        //Incluir apontamento
                        TCN_Apontamento_MPrima.Gravar(
                            new TRegistro_Apontamento_MPrima
                            {
                                Id_apontamento = val.Id_apontamento.Value,
                                Cd_produto = v.Cd_produto,
                                Cd_unidade = v.Cd_unidade,
                                Cd_local = v.Cd_local,
                                Qtd_produto = v.Qtd_produto,
                                Pc_quebratec = v.Pc_quebratec
                            }, qtb_ap.Banco_Dados);
                        //Gravar estoque
                        TRegistro_LanEstoque rEstoque = new TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = v.CD_Empresa;
                        rEstoque.Cd_local = v.Cd_local;
                        rEstoque.Cd_produto = v.Cd_produto;
                        rEstoque.Ds_observacao = "ESTOQUE GRAVADO AUTOMATICAMENTE PELO APONTAMENTO DE PRODUCAO";
                        rEstoque.Dt_lancto = val.Dt_apontamento;
                        rEstoque.Tp_movimento = "S";
                        rEstoque.Qtd_entrada = decimal.Zero;
                        rEstoque.Qtd_saida = v.Qtd_produto;
                        rEstoque.Vl_unitario = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(v.CD_Empresa, v.Cd_produto, qtb_ap.Banco_Dados);
                        rEstoque.Vl_subtotal = v.Qtd_produto * rEstoque.Vl_unitario;
                        rEstoque.Tp_lancto = "N";
                        custo += rEstoque.Vl_subtotal;
                        TCN_LanEstoque.GravarEstoque(rEstoque, qtb_ap.Banco_Dados);
                        //Apontamento x estoque
                        TCN_Apontamento_Estoque.GravarApontamentoEstoque(
                            new TRegistro_Apontamento_Estoque
                            {
                                Id_apontamento = val.Id_apontamento,
                                Cd_empresa = rEstoque.Cd_empresa,
                                Cd_produto = rEstoque.Cd_produto,
                                Id_lanctoestoque = rEstoque.Id_lanctoestoque,
                                Vl_custocontabil = rEstoque.Vl_subtotal
                            }, qtb_ap.Banco_Dados);
                    });
                //Dar entrada estoque produto acabado
                TRegistro_OrdemProducao rOrdem =
                    TCN_OrdemProducao.Buscar(val.Id_ordemstr,
                                             val.Cd_empresa,
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
                                             false,
                                             qtb_ap.Banco_Dados)[0];
                TRegistro_LanEstoque rEstAcab = new TRegistro_LanEstoque();
                rEstAcab.Cd_empresa = rOrdem.Cd_empresa;
                rEstAcab.Cd_local = rOrdem.Cd_local;
                rEstAcab.Cd_produto = rOrdem.Cd_produto;
                rEstAcab.Ds_observacao = "ESTOQUE GRAVADO AUTOMATICAMENTE PELO APONTAMENTO DE PRODUCAO";
                rEstAcab.Dt_lancto = val.Dt_apontamento;
                rEstAcab.Tp_movimento = "E";
                rEstAcab.Qtd_entrada = rOrdem.Qtd_saldoproduzir;
                rEstAcab.Qtd_saida = decimal.Zero;
                rEstAcab.Vl_unitario = Math.Round(decimal.Divide(custo, rOrdem.Qtd_saldoproduzir), 7, MidpointRounding.AwayFromZero) ;
                rEstAcab.Vl_subtotal = custo;
                rEstAcab.Tp_lancto = "N";
                TCN_LanEstoque.GravarEstoque(rEstAcab, qtb_ap.Banco_Dados);
                //Apontamento x estoque
                TCN_Apontamento_Estoque.GravarApontamentoEstoque(
                    new TRegistro_Apontamento_Estoque
                    {
                        Id_apontamento = val.Id_apontamento,
                        Cd_empresa = rEstAcab.Cd_empresa,
                        Cd_produto = rEstAcab.Cd_produto,
                        Id_lanctoestoque = rEstAcab.Id_lanctoestoque,
                        Vl_custocontabil = custo
                    }, qtb_ap.Banco_Dados);
                //Gravar Ordem x Apontamento
                TCN_OrdemProducao_X_Apontamento.Gravar(
                    new TRegistro_OrdemProducao_X_Apontamento
                    {
                        Id_apontamento = val.Id_apontamento,
                        Id_ordem = val.Id_ordem
                    }, qtb_ap.Banco_Dados);
                //Alterar status serie para P-Processada
                TCN_SerieProduto.Buscar(string.Empty,
                                        string.Empty,
                                        string.Empty,
                                        val.Id_ordemstr,
                                        qtb_ap.Banco_Dados)
                                        .ForEach(p => { p.St_registro = "P"; TCN_SerieProduto.Gravar(p, qtb_ap.Banco_Dados); });
                //Gravar custo total materia prima
                val.Vl_custo_mpd = custo;
                qtb_ap.Gravar(val);
                if (st_transacao)
                    qtb_ap.Banco_Dados.Commit_Tran();
                return val.Id_apontamentostr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_ap.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar apontamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ap.deletarBanco_Dados();
            }
        }

        public static void ProcessarEstoqueProdutoAcabado(TRegistro_ApontamentoProducao val,
                                                          decimal Qtd_batch,
                                                          decimal TotalCusto,
                                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ApontamentoProducao qtb_ficha = new TCD_ApontamentoProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_ficha.Banco_Dados).ItemServico(val.LFormulaApontamento[0].Cd_produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_ficha.Banco_Dados).ProdutoConsumoInterno(val.LFormulaApontamento[0].Cd_produto)))
                {
                    //Entrada produto acabado no estoque
                    CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                    rEstoque.Cd_empresa = val.Cd_empresa;
                    rEstoque.Cd_local = val.LFormulaApontamento[0].Cd_local;
                    rEstoque.Cd_produto = val.LFormulaApontamento[0].Cd_produto;
                    rEstoque.Ds_observacao = "ESTOQUE GRAVADO AUTOMATICAMENTE PELA PRODUCAO DO ITEM: " + val.LFormulaApontamento[0].Cd_produto.Trim();
                    rEstoque.Dt_lancto = val.Dt_apontamento;
                    rEstoque.Qtd_entrada = !val.LFormulaApontamento[0].St_decomposicao ? TCN_CadConvUnidade.ConvertUnid(val.LFormulaApontamento[0].Cd_unidade,
                                                                                                          val.LFormulaApontamento[0].Cd_unidProduto,
                                                                                                          val.Qtd_batch * val.LFormulaApontamento[0].Qt_produto,
                                                                                                          3,
                                                                                                          qtb_ficha.Banco_Dados) : decimal.Zero;
                    rEstoque.Qtd_saida = val.LFormulaApontamento[0].St_decomposicao ? TCN_CadConvUnidade.ConvertUnid(val.LFormulaApontamento[0].Cd_unidade,
                                                                                                          val.LFormulaApontamento[0].Cd_unidProduto,
                                                                                                          val.Qtd_batch * val.LFormulaApontamento[0].Qt_produto,
                                                                                                          3,
                                                                                                          qtb_ficha.Banco_Dados) : decimal.Zero;
                    rEstoque.Tp_lancto = "N";
                    rEstoque.Tp_movimento = !val.LFormulaApontamento[0].St_decomposicao ? "E" : "S";
                    rEstoque.Vl_subtotal = TotalCusto;
                    rEstoque.Vl_unitario = rEstoque.Vl_subtotal>0?(rEstoque.Vl_subtotal / (val.LFormulaApontamento[0].St_decomposicao ? rEstoque.Qtd_saida : rEstoque.Qtd_entrada)):0;
                    string ret_estoque = TCN_LanEstoque.GravarEstoque(rEstoque, qtb_ficha.Banco_Dados);
                    val.LApontamentoEstoque.Add(new TRegistro_Apontamento_Estoque()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Cd_produto = val.LFormulaApontamento[0].Cd_produto,
                        Id_lanctoestoque = rEstoque.Id_lanctoestoque,
                        Vl_custocontabil = rEstoque.Vl_subtotal
                    });
                }
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }
        
        public static string Deletar(TRegistro_ApontamentoProducao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ApontamentoProducao qtb_apontamento = new TCD_ApontamentoProducao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apontamento.CriarBanco_Dados(true);
                else
                    qtb_apontamento.Banco_Dados = banco;
                //Excluir Apontamento MPrima
                val.lMPrimaApontamento.ForEach(p => TCN_Apontamento_MPrima.Excluir(p, qtb_apontamento.Banco_Dados));
                val.LApontamentoEstoque.ForEach(p => 
                        //Excluir apontamento X Estoque
                        //O metodo deletarapontamento ja vai cancelar os estoques correspondentes
                        TCN_Apontamento_Estoque.DeletarApontamentoEstoque(p, qtb_apontamento.Banco_Dados));
                //Excluir Apontamento Custo Fixo
                val.LCustoFixo.ForEach(p => TCN_Apontamento_CustoFixo.DeletarApontamentoCustoFixo(p, qtb_apontamento.Banco_Dados));
                //Excluir Ordem Producao X Apontamento
                val.lOrdem.ForEach(p =>
                        TCN_OrdemProducao_X_Apontamento.Excluir(
                            new TRegistro_OrdemProducao_X_Apontamento()
                            {
                                Id_apontamento = val.Id_apontamento,
                                Id_ordem = p.Id_ordem
                            }, qtb_apontamento.Banco_Dados)
                    );
                //Excluir Numero Serie
                val.lSerie.ForEach(p =>
                {
                    if (new CamadaDados.Faturamento.Pedido.TCD_ItensExpedicao(qtb_apontamento.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_serie",
                                vOperador = "=",
                                vVL_Busca = p.Id_seriestr
                            }
                        }, "1") != null)
                        throw new Exception("Numero série <" + p.Nr_serie.Trim() + ">, ja foi utilizado no faturamento.");
                    TCN_SerieProduto.Excluir(p, qtb_apontamento.Banco_Dados);
                });
                //Deletar apontamento producao
                qtb_apontamento.Deletar(val);
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apontamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_apontamento.deletarBanco_Dados();
            }
        }
    }
}
