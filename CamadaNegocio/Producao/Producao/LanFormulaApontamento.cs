using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Estoque.Cadastros;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_FormulaApontamento
    {
        public static TList_FormulaApontamento Buscar(string Cd_empresa,
                                                      string Id_formulacao,
                                                      string Ds_observacoes,
                                                      string Ds_indicacao,
                                                      string Ds_formula,
                                                      string Cd_produto,
                                                      string Cd_materiaprima,
                                                      int vTop,
                                                      string vNm_campo,
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
            if (!string.IsNullOrEmpty(Id_formulacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_formulacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_formulacao;
            }
            if (!string.IsNullOrEmpty(Ds_observacoes))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacoes";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacoes.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Ds_indicacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_indicacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_indicacao.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Ds_formula))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_formula";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_formula.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_materiaprima))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_prd_fichatec_mprima x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_formulacao = a.id_formulacao " +
                                                      "and x.cd_produto = '" + Cd_materiaprima.Trim() + "')";
            }

            return new TCD_FormulaApontamento(banco).Select(filtro, vTop, vNm_campo);
        }
        
        public static void BuscarFormula(TRegistro_ApontamentoProducao val,
                                         BancoDados.TObjetoBanco banco)
        {
            if (val.Cd_empresa.Trim().Equals(string.Empty))
                return;
            else
            {
                TRegistro_FormulaApontamento rFormula = new TRegistro_FormulaApontamento();
                rFormula = Buscar(val.Cd_empresa,
                                  val.Id_formulacaostr,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  1,
                                  string.Empty,
                                  banco)[0];
                //Buscar ficha tecnica materia-prima
                TCN_Ordem_MPrima.Buscar(val.Id_ordemstr, banco).ForEach(x =>
                {
                    rFormula.LFichaTec_MPrima.Add(new TRegistro_FichaTec_MPrima
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_formulacao_mprima = x.ID_Formulacao_MPrima,
                        Cd_local = x.Cd_local,
                        Cd_produto = x.Cd_produto,
                        Ds_produto = x.Ds_produto,
                        Cd_unidade = x.Cd_unidade,
                        Ds_unidade = x.Ds_unidade,
                        Cd_unid_produto = x.Cd_unid_produto,
                        Pc_quebra_tec = x.Pc_quebratec,
                        Qtd_produto = x.Qtd_produto
                    });
                });
                //Buscar custo fixo direto
                rFormula.LCustoFixo = TCN_CustoFixo_Direto.Buscar(val.Cd_empresa,
                                                                  val.Id_formulacaostr,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  0,
                                                                  string.Empty,
                                                                  banco);
                val.LFormulaApontamento.Add(rFormula);
            }
        }
        
        public static string Gravar(TRegistro_FormulaApontamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FormulaApontamento qtb_formula = new TCD_FormulaApontamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_formula.CriarBanco_Dados(true);
                else
                    qtb_formula.Banco_Dados = banco;
                //Gravar Formula Apontamento
                val.Id_formulacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_formula.Gravar(val), "@P_ID_FORMULACAO"));
                //Deletar Ficha Tecnica MPrima
                val.LFichaTec_MPrimaDel.ForEach(p => TCN_FichaTec_MPrima.Excluir(p, qtb_formula.Banco_Dados));
                //Gravar Ficha Tecnica MPrima
                val.LFichaTec_MPrima.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_formulacao = val.Id_formulacao;
                        TCN_FichaTec_MPrima.Gravar(p, qtb_formula.Banco_Dados);
                    });
                //Deletar Custo Fixo Direto
                val.LCustoFixoDel.ForEach(p => TCN_CustoFixo_Direto.DeletarCustoFixo_Direto(p, qtb_formula.Banco_Dados));
                //Gravar Custo Fixo Direto
                val.LCustoFixo.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_formulacao = val.Id_formulacao;
                        TCN_CustoFixo_Direto.GravarCustoFixo_Direto(p, qtb_formula.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_formula.Banco_Dados.Commit_Tran();
                return val.Id_formulacaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_formula.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_formula.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FormulaApontamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FormulaApontamento qtb_formula = new TCD_FormulaApontamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_formula.CriarBanco_Dados(true);
                else
                    qtb_formula.Banco_Dados = banco;
                //Deletar custo fixo
                val.LCustoFixo.ForEach(p => TCN_CustoFixo_Direto.DeletarCustoFixo_Direto(p, qtb_formula.Banco_Dados));
                val.LCustoFixoDel.ForEach(p => TCN_CustoFixo_Direto.DeletarCustoFixo_Direto(p, qtb_formula.Banco_Dados));
                //Deletar Ficha Tecnica MPrima
                val.LFichaTec_MPrima.ForEach(p => TCN_FichaTec_MPrima.Excluir(p, qtb_formula.Banco_Dados));
                val.LFichaTec_MPrimaDel.ForEach(p => TCN_FichaTec_MPrima.Excluir(p, qtb_formula.Banco_Dados));
                //Deletar Formula Apontamento
                qtb_formula.Excluir(val);
                if (st_transacao)
                    qtb_formula.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_formula.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_formula.deletarBanco_Dados();
            }
        }

        public static decimal CalcularCustoProducao(TRegistro_FormulaApontamento val)
        {
            return TCN_MPrima.MontarListaMPrima(val.Cd_empresa,
                                                val.Id_formulacaostr,
                                                1,
                                                null,
                                                null).Sum(p => p.Vl_custo) +
                    TCN_CustoFixo_Direto.Buscar(val.Cd_empresa,
                                                val.Id_formulacaostr,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                0,
                                                string.Empty,
                                                null).Sum(p => p.Vl_custo);
        }

        public static void CalcularCustoFixo(TList_CustoFixo_Direto val, 
                                             decimal Qtd_batch,
                                             DateTime Dt_apontamento,
                                             BancoDados.TObjetoBanco banco)
        {
            val.ForEach(p =>
            {
                if (p.Vl_custo > 0)
                {
                    string moeda_padrao = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", p.Cd_empresa, banco);
                    if (moeda_padrao.Trim().Equals(string.Empty))
                        throw new Exception("Erro calcular custo fixo: falta configurar moeda padrão.");
                    if (p.Cd_moeda.Trim().Equals(moeda_padrao.Trim()))
                        p.Vl_custo_calculado = p.Vl_custo * Qtd_batch;
                    else
                    {
                        decimal indice = decimal.Zero;
                        p.Vl_custo_calculado = CamadaNegocio.Financeiro.Cadastros.TCN_CotacaoMoeda.ConvertMoeda(p.Cd_moeda,
                                                                                                                moeda_padrao,
                                                                                                                Dt_apontamento,
                                                                                                                false,
                                                                                                                p.Vl_custo,
                                                                                                                ref indice,
                                                                                                                banco) * Qtd_batch;
                        p.Indice_monetario = indice;
                    }
                }
            });
        }

        public static TRegistro_FormulaApontamento CriarFormulaApontamento(string Cd_empresa,
                                                                           string Nr_pedido,
                                                                           string Cd_produto,
                                                                           string Cd_unidade,
                                                                           string Cd_unidproduto,
                                                                           string Cd_local,
                                                                           string Id_pedidoitem,
                                                                           decimal Quantidade,
                                                                           //bool St_decomposicao,
                                                                           BancoDados.TObjetoBanco banco)
        {
            TRegistro_FormulaApontamento rFormula = new TRegistro_FormulaApontamento();
            rFormula.Cd_empresa = Cd_empresa;
            rFormula.Cd_produto = Cd_produto;
            rFormula.Cd_unidade = Cd_unidade;
            rFormula.Cd_unidProduto = Cd_unidproduto;
            rFormula.Cd_local = Cd_local;
            rFormula.Qt_produto = Quantidade;
            TList_FichaTecItemPed lFicha = TCN_FichaTecItemPed.Buscar(Nr_pedido,
                                                                        Cd_produto,
                                                                        Id_pedidoitem,
                                                                        string.Empty,
                                                                        banco);
            lFicha.ForEach(p =>
                {
                    if ((!new TCD_CadProduto(banco).ItemServico(p.Cd_item)) &&
                        (!new TCD_CadProduto(banco).ProdutoConsumoInterno(p.Cd_item)))
                        //Lista Materia Prima
                        rFormula.LFichaTec_MPrima.Add(new TRegistro_FichaTec_MPrima()
                        {
                            Cd_empresa = Cd_empresa,
                            Cd_produto = p.Cd_item,
                            Cd_unid_produto = p.Cd_unditem,
                            Cd_unidade = p.Cd_unditem,
                            Cd_local = Cd_local,
                            Qtd_produto = Math.Round(decimal.Multiply(decimal.Divide(p.Quantidade, p.Qtd_itemPed), Quantidade), 3, MidpointRounding.AwayFromZero)
                        });
                    else
                    {
                        string moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", Cd_empresa, banco);
                        if (!string.IsNullOrEmpty(moeda))
                        {
                            //Buscar custo 
                            rFormula.LCustoFixo.Add(new TRegistro_CustoFixo_Direto()
                            {
                                Cd_empresa = Cd_empresa,
                                Cd_moeda = moeda,
                                Cd_unidade = p.Cd_unditem,
                                Vl_custo = p.Vl_custo,
                                Tp_custo = "F"//Fixo
                            });
                        }
                    }
                });
            return rFormula;
        }

        public static TRegistro_FormulaApontamento CriarFormulaApontamentoProd(string Cd_empresa,
                                                                               string Cd_produto,
                                                                               string Cd_unidade,
                                                                               string Cd_local,
                                                                               //bool St_decomposicao,
                                                                               BancoDados.TObjetoBanco banco)
        {
            TRegistro_FormulaApontamento rFormula = new TRegistro_FormulaApontamento();
            rFormula.Cd_empresa = Cd_empresa;
            //if (!St_decomposicao)
            {
                rFormula.Cd_produto = Cd_produto;
                rFormula.Cd_unidProduto = Cd_unidade;
                rFormula.Cd_unidade = Cd_unidade;
                rFormula.Cd_local = Cd_local;
                rFormula.Qt_produto = 1;
                
                TList_FichaTecProduto lFicha = TCN_FichaTecProduto.Buscar(Cd_produto,
                                                                          string.Empty,
                                                                          banco);
                lFicha.ForEach(p =>
                {
                    rFormula.LFichaTec_MPrima.Add(new TRegistro_FichaTec_MPrima()
                    {
                        Cd_empresa = Cd_empresa,
                        Cd_produto = p.Cd_item,
                        Cd_unid_produto = p.Cd_unditem,
                        Cd_unidade = p.Cd_unditem,
                        Cd_local = Cd_local,
                        Qtd_produto = p.Quantidade
                    });
                });
            }
            //else
            //{
            //    //Produto Acabado
            //    CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
            //        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(Cd_produto,
            //                                                                   string.Empty,
            //                                                                   banco);
            //    lFicha.ForEach(p =>
            //    {
            //        rFormula.LFichaTec_Acabado.Add(new TRegistro_FichaTec_Acabado()
            //        {
            //            Cd_empresa = Cd_empresa,
            //            Cd_produto = p.Cd_item,
            //            Cd_unid_produto = p.Cd_unditem,
            //            Cd_unidade = p.Cd_unditem,
            //            Cd_local = Cd_local,
            //            Qtd_produto = p.Quantidade,
            //            Pc_rateiocusto = 100
            //        });
            //    });
            //    //Materia Prima
            //    rFormula.LFichaTec_MPrima.Add(new TRegistro_FichaTec_MPrima()
            //    {
            //        Cd_empresa = Cd_empresa,
            //        Cd_produto = Cd_produto,
            //        Cd_unid_produto = Cd_unidade,
            //        Cd_unidade = Cd_unidade,
            //        Cd_local = Cd_local,
            //        Qtd_produto = 1
            //    });
            //}
            return rFormula;
        }
    }
}
