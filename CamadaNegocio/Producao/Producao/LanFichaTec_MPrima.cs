using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Producao;
using System.Data;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_FichaTec_MPrima
    {
        public static TList_FichaTec_MPrima Buscar(string Cd_empresa,
                                                   string Id_formulacao,
                                                   string Cd_produto,
                                                   string Cd_unidade,
                                                   string Cd_local,
                                                   int vTop,
                                                   string vNm_campo,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Id_formulacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_formulacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_formulacao.Trim();
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Cd_unidade.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_unidade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_unidade.Trim() + "'";
            }
            if (Cd_local.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_local.Trim() + "'";
            }
            return new TCD_FichaTec_MPrima(banco).Select(filtro, vTop, vNm_campo);
        }

        public static TList_Apontamento_Estoque ProcessarEstoqueFichaTec_MPrima(TList_FichaTec_MPrima val, 
                                                                                decimal Qtd_batch,
                                                                                DateTime? Dt_estoque,
                                                                                bool St_decomposicao,
                                                                                BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec_MPrima qtb_ficha = new TCD_FichaTec_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                TList_Apontamento_Estoque lEstoque = new TList_Apontamento_Estoque();
                val.ForEach(p =>
                    {
                        #region if produto composto e formula for nula
                        if ((new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_ficha.Banco_Dados).ProdutoComposto(p.Cd_produto)) && (p.Id_formulacao_mprima == null))
                        {
                            TRegistro_ApontamentoProducao rApontamento = new TRegistro_ApontamentoProducao();
                            rApontamento.Cd_empresa = p.Cd_empresa;
                            rApontamento.Dt_apontamento = Dt_estoque;
                            rApontamento.Dt_validade = Dt_estoque;
                            rApontamento.Qtd_batch = p.Qtd_produto * Qtd_batch;
                            rApontamento.LFormulaApontamento = new TList_FormulaApontamento() {
                                TCN_FormulaApontamento.CriarFormulaApontamentoProd(p.Cd_empresa,
                                                                                    p.Cd_produto,
                                                                                    p.Cd_unidade,
                                                                                    p.Cd_local,
                                                                                    //St_decomposicao,
                                                                                    qtb_ficha.Banco_Dados)};
                            //Gravar Formula Apontamento
                            rApontamento.LFormulaApontamento.ForEach(x=>
                            {
                                x.St_decomposicao = St_decomposicao;
                                TCN_FormulaApontamento.Gravar(x, qtb_ficha.Banco_Dados);
                            });
                            //Calcular custo MPD
                            TCN_ApontamentoProducao.CalcularCustoMPD(rApontamento, qtb_ficha.Banco_Dados);
                            //Calcular custo fixo
                            TCN_ApontamentoProducao.CalcularCustoFixo(rApontamento, qtb_ficha.Banco_Dados);
                            //Chamar metodo Gravar Apontamento recursivamente
                            p.Id_apontamentomprima = Convert.ToDecimal(TCN_ApontamentoProducao.Gravar(rApontamento, 
                                                                                                      qtb_ficha.Banco_Dados));
                        }
                        #endregion
                        #region else if formula diferente de nulll
                        else if (p.Id_formulacao_mprima != null)
                        {
                            //Buscar formula apontamento
                            TRegistro_ApontamentoProducao rApontamento = new TRegistro_ApontamentoProducao();
                            rApontamento.Cd_empresa = p.Cd_empresa;
                            rApontamento.Dt_apontamento = Dt_estoque;
                            rApontamento.Dt_validade = Dt_estoque;
                            rApontamento.Qtd_batch = p.Qtd_produto * Qtd_batch;
                            rApontamento.LFormulaApontamento = TCN_FormulaApontamento.Buscar(p.Cd_empresa,
                                                                                             p.Id_formulacao_mprimastr,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             0,
                                                                                             string.Empty,
                                                                                             qtb_ficha.Banco_Dados);
                            //Buscar ficha tecnica da formula
                            rApontamento.LFormulaApontamento[0].LFichaTec_MPrima =
                            TCN_FichaTec_MPrima.Buscar(p.Cd_empresa,
                                                       p.Id_formulacao_mprimastr,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       0,
                                                       string.Empty,
                                                       qtb_ficha.Banco_Dados);
                            //Buscar Custo
                            rApontamento.LFormulaApontamento[0].LCustoFixo =
                            TCN_CustoFixo_Direto.Buscar(p.Cd_empresa,
                                                        p.Id_formulacao_mprimastr,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        0,
                                                        string.Empty,
                                                        qtb_ficha.Banco_Dados);

                            rApontamento.Qtd_batch = Math.Round(p.Qtd_produto / TCN_CadConvUnidade.ConvertUnid(rApontamento.LFormulaApontamento[0].Cd_unidade, 
                                                                                                    rApontamento.LFormulaApontamento[0].Cd_unidProduto, 
                                                                                                    rApontamento.LFormulaApontamento[0].Qt_produto,
                                                                                                    3, qtb_ficha.Banco_Dados), 0);
                            //Calcular custo MPD
                            TCN_ApontamentoProducao.CalcularCustoMPD(rApontamento, qtb_ficha.Banco_Dados);
                            //Calcular custo fixo
                            TCN_ApontamentoProducao.CalcularCustoFixo(rApontamento, qtb_ficha.Banco_Dados);
                            //Chamar metodo Gravar Apontamento recursivamente
                            p.Id_apontamentomprima = Convert.ToDecimal(TCN_ApontamentoProducao.Gravar(rApontamento, 
                                                                                                      qtb_ficha.Banco_Dados));
                        }
                        #endregion

                        //Gravar estoque
                        TRegistro_LanEstoque rEstoque = new TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = p.Cd_empresa;
                        rEstoque.Cd_local = p.Cd_local;
                        rEstoque.Cd_produto = p.Cd_produto;
                        rEstoque.Ds_observacao = "ESTOQUE GRAVADO AUTOMATICAMENTE PELO APONTAMENTO DE PRODUCAO";
                        rEstoque.Dt_lancto = Dt_estoque;
                        rEstoque.Tp_movimento = !St_decomposicao ? "S" : "E";
                        rEstoque.Qtd_entrada = St_decomposicao ? TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade,
                                                                                               p.Cd_unid_produto,
                                                                                               p.Qtd_produto * Qtd_batch,
                                                                                               3,
                                                                                               qtb_ficha.Banco_Dados) : decimal.Zero;
                        rEstoque.Qtd_saida = !St_decomposicao ? TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade,
                                                                                               p.Cd_unid_produto,
                                                                                               p.Qtd_produto * Qtd_batch,
                                                                                               3,
                                                                                               qtb_ficha.Banco_Dados) : decimal.Zero;
                        rEstoque.Vl_unitario = p.Vl_unitario;
                        rEstoque.Vl_subtotal = rEstoque.Vl_unitario * (St_decomposicao ? rEstoque.Qtd_entrada : rEstoque.Qtd_saida);
                        rEstoque.Tp_lancto = "N";
                        TCN_LanEstoque.GravarEstoque(rEstoque, qtb_ficha.Banco_Dados);
                        lEstoque.Add(new TRegistro_Apontamento_Estoque()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Id_lanctoestoque = rEstoque.Id_lanctoestoque,
                            Vl_custocontabil = p.Vl_custo
                        });
                    });
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return lEstoque;
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

        public static string Gravar(TList_FichaTec_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            try
            {
                if(banco == null)
                {
                    banco = new BancoDados.TObjetoBanco();
                    banco.CriarObjetosBanco(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                    banco.Conexao.Open();
                    banco.Start_Tran(IsolationLevel.ReadCommitted);
                    banco.Comando.Transaction = banco.Transac;
                    st_transacao = true;
                }
                string retorno = string.Empty;
                val.ForEach(p => retorno += Gravar(p, banco));
                if (st_transacao)
                    banco.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if(st_transacao)
                    banco.RollBack_Tran();
                throw new Exception("Erro gravar ficha tecnica: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                {
                    if (banco.Conexao.State == ConnectionState.Open)
                        banco.Conexao.Close();
                    banco = null;
                }
            }
        }

        public static string Gravar(TRegistro_FichaTec_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec_MPrima qtb_ficha = new TCD_FichaTec_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                //Gravar Ficha Tecnica MPrima
                string retorno = qtb_ficha.GravarFichaTec_MPrima(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTec_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTec_MPrima qtb_ficha = new TCD_FichaTec_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                //Deletar Ficha Tecnica MPrima
                qtb_ficha.DeletarFichaTec_MPrima(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }
    }
}
