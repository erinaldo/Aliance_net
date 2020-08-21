using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Estoque.Cadastros
{
    #region Classe Produto
    public class TCN_CadProduto
    {
        public static TList_CadProduto Busca(string vCD_Produto,
                                             string vCD_Unidade,
                                             string vCD_Grupo,                                             
                                             string vDS_Produto,                                            
                                             string vCD_CondFiscal_Produto,
                                             string vSigla,
                                             string vDS_AbreviadaProduto,
                                             string vST_Registro,
                                             string Codigo_alternativo,
                                             string Ncm,
                                             string vTp_produto,
                                             string vCodBarra,
                                             string Cd_marca,
                                             string Nr_patrimonio,
                                             int vTop,
                                             string vGroup,
                                             string vOrder,
                                             TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Unidade))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Unidade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Unidade.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Grupo.Trim() + "'";
            }
           
            if (!string.IsNullOrEmpty(vDS_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Produto";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Produto.Trim() + "%' COLLATE Latin1_General_CI_AI  )";
            }

           if (!string.IsNullOrEmpty(vCD_CondFiscal_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CondFiscal_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CondFiscal_Produto.Trim() + "'";
            }

           
            if (!string.IsNullOrEmpty(vSigla))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Sigla";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSigla.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vDS_AbreviadaProduto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_AbreviadaProduto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_AbreviadaProduto.Trim() + "'";
            }
            
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isNull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Codigo_alternativo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.codigo_alternativo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + Codigo_alternativo.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Ncm))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ncm";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Ncm.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTp_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCodBarra))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_EST_CodBarra x " +
                                                      "where x.cd_produto = a.cd_produto " +
                                                      "and x.cd_codbarra like '%" + vCodBarra.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_marca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_marca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_marca;
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                      "where x.CD_Patrimonio = a.CD_Produto " +
                                                      "and x.NR_Patrimonio = '" + Nr_patrimonio.Trim() + "') ";
            }
            
            return new TCD_CadProduto(banco).Select(vBusca, vTop , string.Empty, vGroup, vOrder);
        }

        public static List<TRegistro_ProdutoPDV> BuscarProdutoPDV(string Cd_produto,
                                                                  string Cd_codbarra,
                                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg,
                                                                  TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = string.Empty;
            filtro[0].vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                  "(exists (select 1 from tb_est_codbarra x " +
                                  "         where x.cd_produto = a.cd_produto " +
                                  "         and x.cd_codbarra = '" + Cd_codbarra.Trim() + "'))";
            //Tabela Preco
            filtro[1].vNM_Campo = "c.cd_tabelapreco";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = rCfg.Cd_tabelapreco;

            //Empresa Preco
            filtro[2].vNM_Campo = "c.cd_empresa";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + rCfg.Cd_empresa.Trim() + "'";
            return new TCD_CadProduto(banco).SelectProdutoPDV(filtro);
        }

        public static List<TRegistro_ProdutoLocacao> BuscarProdutoLocacao(string Cd_produto,
                                                                          string Cd_grupo,
                                                                          string Cd_empresa,
                                                                          bool St_patrimonio,
                                                                          string Dt_locacao,
                                                                          TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            if (St_patrimonio)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                      "where a.cd_produto = x.CD_Patrimonio  " +
                                                      "and x.cd_empresa = '" + Cd_empresa.Trim() + "') ";
            }
            return new TCD_CadProduto(banco).SelectProdutoLocacao(vBusca, Dt_locacao);
        }

        public static TList_CadProduto BuscarProdutoVendaRapida(string Cd_produto, 
                                                                string Cd_codbarra,
                                                                TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = string.Empty;
            filtro[1].vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                    "(exists (select 1 from tb_est_codbarra x " +
                                    "           where x.cd_produto = a.cd_produto " +
                                    "           and x.cd_codbarra = '" + Cd_codbarra.Trim() + "'))";
            filtro[2].vNM_Campo = "isnull(e.st_combustivel, 'N')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'S'";
            return new TCD_CadProduto(banco).Select(filtro, 1, string.Empty, string.Empty, string.Empty);
        }

        public static TRegistro_CadProduto Busca_Produto_Codigo(string vCD_Produto, TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
            }

            return new TCD_CadProduto(banco).Select(vBusca, 0, string.Empty, string.Empty, string.Empty)[0];
        }
        
        public static string Gravar(TRegistro_CadProduto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadProduto qtb_produto = new TCD_CadProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_produto.CriarBanco_Dados(true);
                else
                    qtb_produto.Banco_Dados = banco;
                
                val.CD_Produto = CamadaDados.TDataQuery.getPubVariavel(qtb_produto.Grava(val), "@P_CD_PRODUTO");
                //Deletar imagens se existir na lista para deletar
                val.lImagensApagar.ForEach(p => TCN_CadProduto_Imagens.Deletar(p, qtb_produto.Banco_Dados));
                //Gravar imagens do produto
                val.LImagens.ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_CadProduto_Imagens.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //deletar acessorios
                val.AcessoriosApagar.ForEach(p => TCN_CadAcessoriosProduto.DeletaCadAcessoriosProdutos(p, qtb_produto.Banco_Dados));
                //Gravar Acessorios
                val.Acessorios.ForEach(p =>
                    {
                        p.cd_produto = val.CD_Produto;
                        TCN_CadAcessoriosProduto.GravaCadAcessoriosProduto(p, qtb_produto.Banco_Dados);
                    });
                //Deletar Item Ficha Tecnica
                val.lFichaApagar.ForEach(p => TCN_FichaTecProduto.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar Item Ficha Tecnica
                val.lFicha.FindAll(p=> p.Cd_item != val.CD_Produto).ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_FichaTecProduto.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //Deletar Qtd Estoque
                val.lQtdEstoqueDel.ForEach(p => TCN_Produto_QtdEstoque.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar Qtd Estoque
                val.lQtdEstoque.ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_Produto_QtdEstoque.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //Deletar Codigo Barra
                val.lCodBarraDel.ForEach(p => TCN_CodBarra.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar codigo barra
                val.lCodBarra.ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_CodBarra.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //Deletar Fornecedor
                val.lFornecDel.ForEach(p => TCN_Produto_X_Fornecedor.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar Fornecedor
                val.lFornec.ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_Produto_X_Fornecedor.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //Gravar Patrimonio
                val.lPatrimonio.ForEach(p =>
                {
                    p.CD_Patrimonio = val.CD_Produto;
                    TCN_CadPatrimonio.Gravar(p, qtb_produto.Banco_Dados);
                });
                //Excluir variedade
                val.lVariedadeDel.ForEach(p => TCN_Variedade.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar variedade
                val.lVariedade.ForEach(p =>
                    {
                        p.Cd_produto = val.CD_Produto;
                        TCN_Variedade.Gravar(p, qtb_produto.Banco_Dados);
                    });
                //Gravar Preço Ficha Técnica
                val.lPreco.FindAll(p=> p.Vl_venda > 0).ForEach(p =>
                {
                    p.Cd_produto = val.CD_Produto;
                    TCN_PrecoItemFicha.Gravar(p, qtb_produto.Banco_Dados);
                });
                //Gravar Implantacao Saldo Estoque
                if (val.rSaldoEst != null)
                {
                    val.rSaldoEst.Cd_produto = val.CD_Produto;
                    TCN_LanEstoque.GravarEstoque(val.rSaldoEst, qtb_produto.Banco_Dados);
                }
                //Gravar Preco Venda
                val.lPrecoItem.ForEach(p =>
                {
                    p.CD_Produto = val.CD_Produto;
                    TCN_LanPrecoItem.Grava_LanPrecoItem(p, qtb_produto.Banco_Dados);
                });
                //Gravar Implantação Saldo Almoxarifado
                if (val.rSaldoAlmox != null)
                {
                    val.rSaldoAlmox.Cd_produto = val.CD_Produto;
                    Almoxarifado.TCN_Movimentacao.Gravar(val.rSaldoAlmox, qtb_produto.Banco_Dados);
                }
                //Excluir Ficha OP
                val.lFichaOPDel.ForEach(p => TCN_FichaOP.Excluir(p, qtb_produto.Banco_Dados));
                //Gravar Ficha OP
                val.lFichaOP.ForEach(p =>
                {
                    p.Cd_produto = val.CD_Produto;
                    TCN_FichaOP.Gravar(p, qtb_produto.Banco_Dados);
                });
                if (st_transacao)
                    qtb_produto.Banco_Dados.Commit_Tran();
                return val.CD_Produto;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_produto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_produto.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadProduto val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadProduto qtb_produto = new TCD_CadProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_produto.CriarBanco_Dados(true);
                else
                    qtb_produto.Banco_Dados = banco;
                //Deletar imagens da lista de excluir
                val.lImagensApagar.ForEach(p => TCN_CadProduto_Imagens.Deletar(p, qtb_produto.Banco_Dados));
                val.LImagens.ForEach(p => TCN_CadProduto_Imagens.Deletar(p, qtb_produto.Banco_Dados));
                //Deletar Acessorios
                val.Acessorios.ForEach(p => TCN_CadAcessoriosProduto.DeletaCadAcessoriosProdutos(p, qtb_produto.Banco_Dados));
                val.AcessoriosApagar.ForEach(p => TCN_CadAcessoriosProduto.DeletaCadAcessoriosProdutos(p, qtb_produto.Banco_Dados));
                //Deletar Ficha
                val.lFicha.ForEach(p => TCN_FichaTecProduto.Excluir(p, qtb_produto.Banco_Dados));
                val.lFichaApagar.ForEach(p => TCN_FichaTecProduto.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar Qtd Estoque
                val.lQtdEstoque.ForEach(p => TCN_Produto_QtdEstoque.Excluir(p, qtb_produto.Banco_Dados));
                val.lQtdEstoqueDel.ForEach(p => TCN_Produto_QtdEstoque.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar codigo barras
                val.lCodBarra.ForEach(p => TCN_CodBarra.Excluir(p, qtb_produto.Banco_Dados));
                val.lCodBarraDel.ForEach(p => TCN_CodBarra.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar fornecedor
                val.lFornec.ForEach(p => TCN_Produto_X_Fornecedor.Excluir(p, qtb_produto.Banco_Dados));
                val.lFornecDel.ForEach(p => TCN_Produto_X_Fornecedor.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar variedade
                val.lVariedade.ForEach(p => TCN_Variedade.Excluir(p, qtb_produto.Banco_Dados));
                val.lVariedadeDel.ForEach(p => TCN_Variedade.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar ficha OP
                val.lFichaOP.ForEach(p => TCN_FichaOP.Excluir(p, qtb_produto.Banco_Dados));
                val.lFichaOPDel.ForEach(p => TCN_FichaOP.Excluir(p, qtb_produto.Banco_Dados));
                //Deletar produto
                qtb_produto.Deleta(val);
                if (st_transacao)
                    qtb_produto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                try
                {
                    val.ST_Registro = "C";
                    qtb_produto.Grava(val);
                    if (st_transacao)
                        qtb_produto.Banco_Dados.Commit_Tran();
                    return "OK";
                }
                catch 
                {
                    if (st_transacao)
                        qtb_produto.Banco_Dados.RollBack_Tran();
                    throw new Exception("Erro excluir produto: " + ex.Message.Trim()); 
                }
            }
            finally
            {
                if (st_transacao)
                    qtb_produto.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Classe Produto Imagens
    public class TCN_CadProduto_Imagens
    {
        public static TList_CadProduto_Imagens Buscar(decimal vId_imagem,
                                                      string vCd_produto)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (vId_imagem > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Imagem";
                filtro[filtro.Length - 1].vVL_Busca = vId_imagem.ToString();
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vCd_produto.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            return new TCD_CadProduto_Imagens().Select(filtro, 0, "");
        }

        public static string Gravar(TRegistro_CadProduto_Imagens val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadProduto_Imagens qtb_imagem = new TCD_CadProduto_Imagens();
            try
            {
                if (banco == null)
                {
                    qtb_imagem.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_imagem.Banco_Dados = banco;
                //Gravar imagem
                string retorno = qtb_imagem.Grava(val);
                if (st_transacao)
                    qtb_imagem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imagem.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_imagem.deletarBanco_Dados();
            }
        }

        public static string Deletar(TRegistro_CadProduto_Imagens val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadProduto_Imagens qtb_imagem = new TCD_CadProduto_Imagens();
            try
            {
                if (banco == null)
                {
                    qtb_imagem.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_imagem.Banco_Dados = banco;
                qtb_imagem.Deleta(val);
                if (st_transacao)
                    qtb_imagem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_imagem.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_imagem.deletarBanco_Dados();
            }
            
        }
    }
    #endregion

    #region Classe Codigo Barra
    public class TCN_CodBarra
    {
        public static TList_CodBarra Buscar(string Cd_produto,
                                            string Cd_codbarra,
                                            TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_codbarra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_codbarra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_codbarra.Trim() + "'";
            }

            return new TCD_CodBarra(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CodBarra val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CodBarra qtb_cod = new TCD_CodBarra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cod.CriarBanco_Dados(true);
                else
                    qtb_cod.Banco_Dados = banco;
                string retorno = qtb_cod.Gravar(val);
                if (st_transacao)
                    qtb_cod.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar codigo barra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CodBarra val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CodBarra qtb_cod = new TCD_CodBarra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cod.CriarBanco_Dados(true);
                else
                    qtb_cod.Banco_Dados = banco;
                qtb_cod.Excluir(val);
                if (st_transacao)
                    qtb_cod.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir codigo barra: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cod.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Classe Ficha Tecnica Produto
    public class TCN_FichaTecProduto
    {
        public static TList_FichaTecProduto Buscar(string Cd_produto,
                                                   string Cd_item,
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }
            return new TCD_FichaTecProduto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTecProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecProduto qtb_ficha = new TCD_FichaTecProduto();
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

        public static string Excluir(TRegistro_FichaTecProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecProduto qtb_ficha = new TCD_FichaTecProduto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;

                qtb_ficha.executarSql("delete TB_EST_PrecoItemFicha " +
                                      "where CD_Produto = '" + val.Cd_produto.Trim() + "' " +
                                      "and CD_Item = '" + val.Cd_item.Trim() + "'", null);
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

        public static void MontarFichaTec(string Cd_empresa,
                                          string Cd_tabelapreco,
                                          TList_FichaTecProduto val,
                                          TObjetoBanco banco)
        {
            val.ForEach(p =>
                {
                    if (new TCD_CadProduto(banco).ProdutoComposto(p.Cd_item))
                    {
                        //Buscar Ficha Tecnica do Produto
                        TList_FichaTecProduto lFicha =
                            TCN_FichaTecProduto.Buscar(p.Cd_item,
                                                       string.Empty,
                                                       banco);
                        lFicha.ForEach(v =>
                        {
                            if ((!new TCD_CadProduto(banco).ItemServico(v.Cd_item)) &&
                                (!new TCD_CadProduto(banco).ProdutoConsumoInterno(v.Cd_item)))
                                if (new TCD_CadProduto(banco).ProdutoComposto(v.Cd_item))
                                {
                                    val.Add(new TRegistro_FichaTecProduto()
                                    {
                                        Cd_produto = p.Cd_item,
                                        Ds_produto = p.Ds_item,
                                        Cd_item = v.Cd_item,
                                        Ds_item = v.Ds_item,
                                        Sg_unditem = v.Sg_unditem,
                                        Quantidade = p.Quantidade * v.Quantidade
                                    });
                                }
                                else if (val.Exists(x => x.Cd_item.Trim().Equals(v.Cd_item.Trim())))
                                    val.Find(x => x.Cd_item.Trim().Equals(v.Cd_item.Trim())).Quantidade += p.Quantidade * v.Quantidade;
                                else
                                    val.Add(new TRegistro_FichaTecProduto()
                                    {
                                        Cd_produto = p.Cd_produto,
                                        Ds_produto = p.Ds_produto,
                                        Cd_item = v.Cd_item,
                                        Ds_item = v.Ds_item,
                                        Sg_unditem = v.Sg_unditem,
                                        Quantidade = p.Quantidade * v.Quantidade,
                                        Vl_custoservico = string.IsNullOrEmpty(Cd_empresa) ? decimal.Zero : TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, v.Cd_item, banco),
                                        Vl_precovenda = (!string.IsNullOrEmpty(Cd_empresa)) && (!string.IsNullOrEmpty(Cd_tabelapreco)) ?
                                                            TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, v.Cd_item, Cd_tabelapreco, banco) : decimal.Zero
                                    });
                        });
                    }
                    else
                    {
                        p.Vl_custoservico = string.IsNullOrEmpty(Cd_empresa) ? decimal.Zero : TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, p.Cd_item, banco);
                        p.Vl_precovenda = (!string.IsNullOrEmpty(Cd_empresa)) && (!string.IsNullOrEmpty(Cd_tabelapreco)) ?
                                                            TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, p.Cd_item, Cd_tabelapreco, banco) : decimal.Zero;
                    }
                });
            int index = 0;
            while (index < val.Count)
            {
                if (new TCD_CadProduto(banco).ProdutoComposto(val[index].Cd_item))
                    val.Remove(val[index]);
                else
                    index++;
            }
        }
    }
    #endregion

    #region Preço Item Ficha
    public class TCN_PrecoItemFicha
    {
        public static TList_PrecoItemFicha Buscar(string Cd_produto,
                                                   string Cd_item,
                                                   string Cd_tabelapreco,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_item.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            return new TCD_PrecoItemFicha(banco).Select(filtro, 0, string.Empty);
        }

        public static decimal Busca_ConsultaPreco(string vCD_Produto, string vCD_Item, string vCD_TabelaPreco, BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Item.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_TabelaPreco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaPreco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaPreco.Trim() + "'";
            }

            object obj_ConsultaPreco = new TCD_PrecoItemFicha(banco).BuscarEscalar(vBusca, "a.Vl_venda");
            return obj_ConsultaPreco == null ? decimal.Zero : Convert.ToDecimal(obj_ConsultaPreco.ToString());
        }

        public static string Gravar(TRegistro_PrecoItemFicha val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoItemFicha qtb_ficha = new TCD_PrecoItemFicha();
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

        public static string GravarLista(TList_PrecoItemFicha val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoItemFicha qtb_ficha = new TCD_PrecoItemFicha();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                //Gravar
                val.FindAll(p=> p.Vl_venda > 0).ForEach(p => qtb_ficha.Gravar(p));
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
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

        public static string Excluir(TRegistro_PrecoItemFicha val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoItemFicha qtb_ficha = new TCD_PrecoItemFicha();
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
    }
    #endregion

    #region Classe Produto Qtde Estoque
    public class TCN_Produto_QtdEstoque
    {
        public static TList_Produto_QtdEstoque Buscar(string Cd_produto,
                                                      string Cd_empresa,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_Produto_QtdEstoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Produto_QtdEstoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Produto_QtdEstoque qtb_prod = new TCD_Produto_QtdEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                string retorno = qtb_prod.Gravar(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Produto_QtdEstoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Produto_QtdEstoque qtb_prod = new TCD_Produto_QtdEstoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                qtb_prod.Excluir(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Classe Produto X Fornecedor
    public class TCN_Produto_X_Fornecedor
    {
        public static TList_Produto_X_Fornecedor Buscar(string Cd_produto,
                                                        string Cd_fornecedor,
                                                        string Codigo_fornecedor,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_fornecedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Codigo_fornecedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.codigo_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Codigo_fornecedor.Trim() + "'";
            }
            return new TCD_Produto_X_Fornecedor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Produto_X_Fornecedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Produto_X_Fornecedor qtb_prod = new TCD_Produto_X_Fornecedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                string retorno = qtb_prod.Gravar(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Produto_X_Fornecedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Produto_X_Fornecedor qtb_prod = new TCD_Produto_X_Fornecedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                qtb_prod.Excluir(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Atualiza Preço Percentual
    public class TCN_AtualizaPrecoPerc
    {
        public static TList_AtualizaPrecoPerc Buscar(string Cd_empresa,
                                                     string Cd_produto,
                                                     string Cd_tabelapreco,
                                                     string Cd_grupo,
                                                     string Tp_produto,
                                                     TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto x " +
                                                      "where a.cd_produto = x.cd_produto " +
                                                      "and x.cd_grupo = '" + Cd_grupo.Trim() + "') ";
            }
            if (!string.IsNullOrEmpty(Tp_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto x " +
                                                      "where a.cd_produto = x.cd_produto " +
                                                      "and x.Tp_produto = '" + Tp_produto.Trim() + "') ";
            }

            return new TCD_AtualizaPrecoPerc(banco).Select(filtro, 0, string.Empty);
        }

        public static string AtualizarPreco(TList_RegLanFaturamento_Item lItensNota, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaPrecoPerc qtb_perc = new TCD_AtualizaPrecoPerc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else
                    qtb_perc.Banco_Dados = banco;
                lItensNota.ForEach(p =>
                {
                    p.St_atualizaprecovenda = true;
                    //Buscar % Atualização do Produto
                    new TCD_AtualizaPrecoPerc(qtb_perc.Banco_Dados).Select(
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
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                }
                            }, 0, string.Empty).ForEach(x =>
                            {
                                p.St_atualizaprecovenda = false;
                                //Buscar Vl.Ultima compra
                                decimal ultimacompra = Faturamento.NotaFiscal.TCN_LanFaturamento.UltimaCompra(p.Cd_empresa, p.Cd_produto, qtb_perc.Banco_Dados);
                                //Gravar Preço.
                                TCN_LanPrecoItem.Grava_LanPrecoItem(
                                    new CamadaDados.Estoque.TRegistro_LanPrecoItem()
                                    {
                                        CD_Empresa = p.Cd_empresa,
                                        CD_Produto = p.Cd_produto,
                                        CD_TabelaPreco = x.Cd_tabelapreco,
                                        Dt_preco = CamadaDados.UtilData.Data_Servidor(),
                                        Vl_NovoPreco = ultimacompra + Math.Round(decimal.Divide(decimal.Multiply(ultimacompra, x.Pc_ajuste), 100), 2)
                                    }, qtb_perc.Banco_Dados);
                            });
                });
                if (st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Percentual preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }

        public static string Gravar(List<TRegistro_AtualizaPrecoPerc> val, decimal perc, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaPrecoPerc qtb_perc = new TCD_AtualizaPrecoPerc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else
                    qtb_perc.Banco_Dados = banco;
                val.ForEach(p =>
                {
                    p.Pc_ajuste = perc;
                    qtb_perc.Gravar(p);
                });
                if (st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Percentual preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AtualizaPrecoPerc val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AtualizaPrecoPerc qtb_perc = new TCD_AtualizaPrecoPerc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_perc.CriarBanco_Dados(true);
                else
                    qtb_perc.Banco_Dados = banco;
                qtb_perc.Excluir(val);
                if (st_transacao)
                    qtb_perc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_perc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Percentual preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_perc.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Ficha OP
    public static class TCN_FichaOP
    {
        public static TList_FichaOP Buscar(string Cd_produto,
                                           string Id_item,
                                           string Ds_item,
                                           string Tp_item,
                                           TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
                Estruturas.CriarParametro(ref filtro, "a.cd_produto", "'" + Cd_produto.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_item))
                Estruturas.CriarParametro(ref filtro, "a.id_item", Id_item);
            if (!string.IsNullOrEmpty(Ds_item))
                Estruturas.CriarParametro(ref filtro, "a.ds_item", "'" + Ds_item.Trim() + "'", "like");
            if (!string.IsNullOrEmpty(Tp_item))
                Estruturas.CriarParametro(ref filtro, "a.tp_item", "'" + Tp_item.Trim() + "'");
            return new TCD_FichaOP(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaOP val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaOP qtb_prod = new TCD_FichaOP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                val.Id_item = int.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_prod.Gravar(val), "@P_ID_ITEM"));
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return val.Id_item.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaOP val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaOP qtb_prod = new TCD_FichaOP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prod.CriarBanco_Dados(true);
                else
                    qtb_prod.Banco_Dados = banco;
                qtb_prod.Excluir(val);
                if (st_transacao)
                    qtb_prod.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prod.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prod.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
