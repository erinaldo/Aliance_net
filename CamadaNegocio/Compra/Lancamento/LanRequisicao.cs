using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_Requisicao
    {
        public static TList_Requisicao Buscar(string Id_requisicao,
                                              string Cd_empresa,
                                              string Cd_produto,
                                              string Cd_clifor_requisitante,
                                              string Cd_fornecedor,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string St_requisicao,
                                              bool St_ordemcompra,
                                              bool St_pedido,
                                              bool St_requisicaoUsuario,
                                              string Tp_requisicao,
                                              bool St_saldoAlmox,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_requisicao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_requisicao;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Cd_clifor_requisitante.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor_requisitante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor_requisitante.Trim() + "'";
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_CMP_Cotacao x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_requisicao = a.id_requisicao " +
                                                      "and x.cd_fornecedor = '" + Cd_fornecedor.Trim() + "')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_requisicao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_requisicao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (St_requisicao.Trim() != string.Empty || St_ordemcompra || St_pedido)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = !string.IsNullOrEmpty(St_requisicao) ? "a.st_requisicao" : string.Empty;
                filtro[filtro.Length - 1].vOperador = !string.IsNullOrEmpty(St_requisicao) ? "in" : string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = (!string.IsNullOrEmpty(St_requisicao) ? "(" + St_requisicao.Trim() + ")" : string.Empty) +
                                                      (St_ordemcompra ? (!string.IsNullOrEmpty(St_requisicao) ? " or " : string.Empty) +
                                                      " (a.st_requisicao = 'OC' and not exists (select 1 from TB_FAT_Pedido_Itens x " +
                                                                                                    "inner join TB_CMP_OrdemCompra_X_PedItem y " +
                                                                                                    "on x.CD_Produto = y.CD_Produto " +
                                                                                                    "and x.Nr_Pedido = y.Nr_Pedido " +
                                                                                                    "and x.ID_PedidoItem = y.ID_PedidoItem " +
                                                                                                    "inner join TB_CMP_OrdemCompra h " +
                                                                                                    "on y.ID_OC = h.ID_OC " +
                                                                                                    "where a.CD_Empresa = h.CD_Empresa " +
                                                                                                    "and a.ID_Requisicao = h.ID_Requisicao " +
                                                                                                    "and a.CD_Produto = x.CD_Produto " +
                                                                                                    "and h.ST_Registro <> 'C' " +
                                                                                                    "and x.ST_Registro <> 'C')) " : string.Empty) +
                                                     (St_pedido ? (St_ordemcompra || !string.IsNullOrEmpty(St_requisicao) ? " or " : string.Empty) +
                                                     " exists (select 1 from TB_FAT_Pedido_Itens x " +
                                                                                                    "inner join TB_CMP_OrdemCompra_X_PedItem y " +
                                                                                                    "on x.CD_Produto = y.CD_Produto " +
                                                                                                    "and x.Nr_Pedido = y.Nr_Pedido " +
                                                                                                    "and x.ID_PedidoItem = y.ID_PedidoItem " +
                                                                                                    "inner join TB_CMP_OrdemCompra h " +
                                                                                                    "on y.ID_OC = h.ID_OC " +
                                                                                                    "where a.CD_Empresa = h.CD_Empresa " +
                                                                                                    "and a.ID_Requisicao = h.ID_Requisicao " +
                                                                                                    "and a.CD_Produto = x.CD_Produto " +
                                                                                                    "and h.ST_Registro <> 'C' " +
                                                                                                    "and x.ST_Registro <> 'C')" : string.Empty);
            }
            if (St_requisicaoUsuario)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                                      "where x.cd_clifor_cmp = a.cd_clifor_requisitante " +
                                                      "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Tp_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_tprequisicao x " +
                                                      "where x.id_tprequisicao = a.id_tprequisicao " +
                                                      "and x.tp_requisicao in (" + Tp_requisicao.Trim() + "))";
            }
            if (St_saldoAlmox)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qtd_aprovada - a.qtd_almox";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_Requisicao(banco).Select(filtro, 0, string.Empty, "a.dt_cad desc");
        }

        public static string GravarRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_req = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_req.CriarBanco_Dados(true);
                else
                    qtb_req.Banco_Dados = banco;
                //Gravar requisicao
                string retorno = qtb_req.GravarRequisicao(val);
                val.Id_requisicao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_REQUISICAO"));
                //Gravar Cotação
                val.lCotacoes.ForEach(p =>
                {
                    p.Id_requisicao = val.Id_requisicao;
                    TCN_Cotacao.GravarCotacao(p, qtb_req.Banco_Dados);
                });
                //Gravar negociacao
                val.lReqneg.ForEach(p =>
                    {
                        p.Id_requisicao = val.Id_requisicao;
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_Requisicao_X_Negociacao.GravarRequisicao_X_Negociacao(p, qtb_req.Banco_Dados);
                    });
                val.lOrdemProd.ForEach(p =>
                    {
                        p.Id_requisicao = val.Id_requisicao;
                        p.Cd_empresa = val.Cd_empresa;
                        CamadaNegocio.Producao.Producao.TCN_OrdemProducao_X_Requisicao.Gravar(p, qtb_req.Banco_Dados);
                    });
                //Deletar Negociacao
                val.lregnegdel.ForEach(p => TCN_Requisicao_X_Negociacao.DeletarRequisicao_X_Negociacao(p, qtb_req.Banco_Dados));
                if (st_transacao)
                    qtb_req.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_req.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_req.deletarBanco_Dados();
            }
        }

        public static string AlterarRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_req = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_req.CriarBanco_Dados(true);
                else
                    qtb_req.Banco_Dados = banco;
                //Gravar requisicao
                string retorno = qtb_req.GravarRequisicao(val);
                if (st_transacao)
                    qtb_req.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_req.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_req.deletarBanco_Dados();
            }
        }

        public static string DeletarRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_req = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_req.CriarBanco_Dados(true);
                else
                    qtb_req.Banco_Dados = banco;
                if (val.St_requisicao.Trim().ToUpper().Equals("AC") && val.Id_ordem == null)
                {
                    //Deletar negociacao
                    val.lregnegdel.ForEach(p => TCN_Requisicao_X_Negociacao.DeletarRequisicao_X_Negociacao(p, qtb_req.Banco_Dados));
                    val.lReqneg.ForEach(p =>
                        {
                            p.Id_requisicao = val.Id_requisicao;
                            TCN_Requisicao_X_Negociacao.DeletarRequisicao_X_Negociacao(p, qtb_req.Banco_Dados);
                        });
                    //Verificar se Requisição for originada pelo modulo empreendimento
                    CamadaDados.Empreendimento.TList_CompraEmpreendimento lEmpCompra =
                        CamadaNegocio.Empreendimento.TCN_CompraEmpreendimento.Buscar(val.Cd_empresa,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     val.Id_requisicao.ToString(),
                                                                                     qtb_req.Banco_Dados);
                    //Excluir Compra Empreendimento.
                    lEmpCompra.ForEach(p => CamadaNegocio.Empreendimento.TCN_CompraEmpreendimento.Excluir(p, qtb_req.Banco_Dados));
                    //Deletar Cotacao
                    val.lCotacoes.ForEach(p=> TCN_Cotacao.DeletarCotacao(p, qtb_req.Banco_Dados));
                    //Gravar requisicao
                    qtb_req.DeletarRequisicao(val);
                }
                else
                {
                    //Altera o status para CA - Cancelada
                    val.St_requisicao = "CA";
                    AlterarRequisicao(val, qtb_req.Banco_Dados);
                }
                if (st_transacao)
                    qtb_req.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_req.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_req.deletarBanco_Dados();
            }
        }

        public static void FecharCotacoesRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_req = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_req.CriarBanco_Dados(true);
                else
                    qtb_req.Banco_Dados = banco;
                //Verificar se existe configuracao de compra para a empresa da requisicao
                CamadaDados.Compra.TList_CFGCompra lCfg =
                    CamadaNegocio.Compra.TCN_CFGCompra.Buscar(val.Cd_empresa,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              0,
                                                              string.Empty,
                                                              qtb_req.Banco_Dados);
                //Verificar se existem cotacoes
                if (val.lCotacoes.Count.Equals(0))
                    val.lCotacoes = CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                                       string.Empty,
                                                                                       val.Cd_empresa,
                                                                                       val.Id_requisicao.ToString(),
                                                                                       0,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       null);
                if (lCfg.Count > 0)
                    if (lCfg[0].Qtd_min_cotacao > 0)
                        if (lCfg[0].Qtd_min_cotacao > val.lCotacoes.Count)
                            throw new Exception("Configuração de compras da empresa " + val.Cd_empresa.Trim() + " exige no minimo " + lCfg[0].Qtd_min_cotacao.ToString() + " para fechar cotações.");
                //Alterar status da requisicao para AA - Aguardando Aprovacao
                val.St_requisicao = "AA";
                AlterarRequisicao(val, qtb_req.Banco_Dados);
                if (st_transacao)
                    qtb_req.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_req.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro fechar cotações requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_req.deletarBanco_Dados();
            }
        }

        public static void ProcessarRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_requisicao = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_requisicao.CriarBanco_Dados(true);
                else
                    qtb_requisicao.Banco_Dados = banco;
                if (val.St_requisicao.Trim().ToUpper().Equals("AP"))
                {
                    //Aprovar requisicao
                    val.lReqneg.ForEach(p =>
                        {
                            if (p.St_processar)
                            {
                                p.St_NegReq = "A";//Negociacao aprovada para a compra
                                TCN_Requisicao_X_Negociacao.GravarRequisicao_X_Negociacao(p, qtb_requisicao.Banco_Dados);
                            }
                            else
                            {
                                p.St_NegReq = "R";//Negociacao reprovada para a compra
                                TCN_Requisicao_X_Negociacao.GravarRequisicao_X_Negociacao(p, qtb_requisicao.Banco_Dados);
                            }
                        });
                    val.lCotacoes.ForEach(p =>
                        {
                            if (p.St_integrar)
                            {
                                p.St_registro = "P";//Aprovada
                                TCN_Cotacao.GravarCotacao(p, qtb_requisicao.Banco_Dados);
                            }
                            else
                            {
                                p.St_registro = "R";//Reprovada
                                TCN_Cotacao.GravarCotacao(p, qtb_requisicao.Banco_Dados);
                            }
                        });
                }
                else if (val.St_requisicao.Trim().ToUpper().Equals("RE"))
                {
                    //Reprovar requisicao
                    val.lReqneg.ForEach(p =>
                        {
                            p.St_NegReq = "R";//Negociacao reprovada para a compra
                            TCN_Requisicao_X_Negociacao.GravarRequisicao_X_Negociacao(p, qtb_requisicao.Banco_Dados);
                        });
                    //Reprovar cotacoes
                    val.lCotacoes.ForEach(p =>
                        {
                            p.St_registro = "R";//Reprovada
                            TCN_Cotacao.GravarCotacao(p, qtb_requisicao.Banco_Dados);
                        });
                }
                //Alterar requisicao
                //Buscar usuario que esta aprovando a requisicao
                CamadaDados.Compra.TList_CadUsuarioCompra lUser =
                    CamadaNegocio.Compra.TCN_CadUsuarioCompra.Busca(string.Empty,
                                                                    Utils.Parametros.pubLogin,
                                                                    false,
                                                                    false,
                                                                    true,
                                                                    false,
                                                                    0,
                                                                    string.Empty,
                                                                    qtb_requisicao.Banco_Dados);
                if (lUser.Count < 1)
                    throw new Exception("Não existe usuario para APROVAR configurado para o login " + Utils.Parametros.pubLogin.Trim().ToUpper() + ".");
                val.Cd_clifor_aprovador = lUser[0].Cd_clifor_cmp;
                AlterarRequisicao(val, qtb_requisicao.Banco_Dados);
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_requisicao.deletarBanco_Dados();
            }
        }

        public static void EstornarProcessamentoRequisicao(TRegistro_Requisicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_requisicao = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_requisicao.CriarBanco_Dados(true);
                else
                    qtb_requisicao.Banco_Dados = banco;
                //Verificar se o usuario que realizou o processamento e o mesmo que esta tentando estornar
                CamadaDados.Compra.TList_CadUsuarioCompra lUser =
                    CamadaNegocio.Compra.TCN_CadUsuarioCompra.Busca(val.Cd_clifor_aprovador,
                                                                    Utils.Parametros.pubLogin,
                                                                    false,
                                                                    false,
                                                                    true,
                                                                    false,
                                                                    1,
                                                                    string.Empty,
                                                                    qtb_requisicao.Banco_Dados);
                if (lUser.Count.Equals(0))
                    throw new Exception("Só é permitido estornar processamento realizado pelo usuario atual logado no sistema.\r\n" +
                                        "Login: " + Utils.Parametros.pubLogin.Trim() + ".");
                //Alterar registro requisicao
                val.Qtd_aprovada = decimal.Zero;
                val.St_requisicao = "AA";
                AlterarRequisicao(val, qtb_requisicao.Banco_Dados);
                //Alterar status das negociacoes
                val.lReqneg.ForEach(p =>
                    {
                        p.St_NegReq = "S";//StandBy
                        TCN_Requisicao_X_Negociacao.GravarRequisicao_X_Negociacao(p, qtb_requisicao.Banco_Dados);
                    });
                //Alterar status das cotacoes
                val.lCotacoes.ForEach(p =>
                    {
                        p.St_registro = "A";//Aberta
                        TCN_Cotacao.GravarCotacao(p, qtb_requisicao.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento requisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_requisicao.deletarBanco_Dados();
            }
        }

        public static void ProcessarOrdemCompra(List<TRegistro_Requisicao> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao qtb_requisicao = new TCD_Requisicao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_requisicao.CriarBanco_Dados(true);
                else
                    qtb_requisicao.Banco_Dados = banco;
                //Verificar se existe usuario de compra para o login corrente
                CamadaDados.Compra.TList_CadUsuarioCompra lUser =
                    TCN_CadUsuarioCompra.Busca(string.Empty,
                                               Utils.Parametros.pubLogin,
                                               false,
                                               false,
                                               false,
                                               true,
                                               1,
                                               string.Empty,
                                               qtb_requisicao.Banco_Dados);
                if (lUser.Count < 1)
                    throw new Exception("Não existe usuario de compra configurado para o login " + Utils.Parametros.pubLogin.Trim());
                val.ForEach(p =>
                    {
                        //Para cada requisicao criar um objeto ordem compra
                        TRegistro_OrdemCompra rOc = new TRegistro_OrdemCompra();
                        rOc.Id_oc = null;
                        rOc.Id_requisicao = p.Id_requisicao;
                        if (p.lCotacoes.Count > 0)
                        {
                            TRegistro_Cotacao rCot = p.lCotacoes.Find(v=> v.St_registro.Trim().ToUpper().Equals("P"));
                            if (rCot != null)
                            {
                                rOc.Cd_empresa = rCot.Cd_empresa;
                                rOc.Cd_fornecedor = rCot.Cd_fornecedor;
                                rOc.Cd_endfornecedor = rCot.Cd_endfornecedor;
                                rOc.Cd_condpgto = rCot.Cd_condpgto;
                                rOc.Cd_moeda = rCot.Cd_moeda;
                                rOc.Cd_portador = rCot.Cd_portador;
                                rOc.Cd_transportadora = rCot.Cd_transportadora;
                                rOc.Cd_endtransportadora = rCot.Cd_endtransportadora;
                                rOc.Tp_frete = rCot.Tp_frete;
                                rOc.Vl_frete = rCot.Vl_frete;
                                rOc.Prazo_entrega = rCot.Prazo_entrega;
                                rOc.Quantidade = p.Qtd_aprovada;
                                rOc.Vl_unitario = rCot.Vl_unitario_cotado;
                                rOc.Dt_oc = DateTime.Now;
                                rOc.St_registro = "A";
                            }
                        }
                        else if (p.lReqneg.Count > 0)
                        {
                            TRegistro_Requisicao_X_Negociacao rReqNeg = p.lReqneg.Find(v => v.St_registro.Trim().ToUpper().Equals("A"));
                            if(rReqNeg != null)
                            {
                                rOc.Cd_empresa = rReqNeg.Cd_empresa;
                                rOc.Cd_fornecedor = rReqNeg.Cd_fornecedor;
                                rOc.Cd_endfornecedor = rReqNeg.Cd_endfornecedor;
                                rOc.Cd_condpgto = rReqNeg.Cd_condpgto;
                                rOc.Cd_moeda = rReqNeg.Cd_moeda;
                                rOc.Cd_portador = rReqNeg.Cd_portador;
                                TRegistro_PrazoEntrega rEntrega = rReqNeg.lPrazoEntrega.Find(x=> x.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()));
                                if(rEntrega != null)
                                {
                                    rOc.Cd_transportadora = rEntrega.Cd_transportadora;
                                    rOc.Cd_endtransportadora = rEntrega.Cd_endtransportadora;
                                    rOc.Tp_frete = rEntrega.Tp_frete;
                                    rOc.Prazo_entrega = rEntrega.Prazo_entrega;
                                }
                                rOc.Quantidade = p.Qtd_aprovada;
                                rOc.Vl_unitario = rReqNeg.Vl_unitario_negociado;
                                rOc.Dt_oc = DateTime.Now;
                                rOc.St_registro = "A";
                            }
                        }
                        TCN_OrdemCompra.Gravar(rOc, qtb_requisicao.Banco_Dados);
                        //Alterar status da requisicao para ordem compra
                        p.St_requisicao = "OC";
                        p.Cd_clifor_comprador = lUser[0].Cd_clifor_cmp;
                        AlterarRequisicao(p, qtb_requisicao.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_requisicao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar ordem compra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_requisicao.deletarBanco_Dados();
            }
        }
    }
}
