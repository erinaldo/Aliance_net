using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaDados.Estoque;
using System.Data;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Balanca;
using CamadaNegocio.Balanca;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Estoque.Cadastros;

namespace CamadaNegocio.Graos
{
    public class TCN_LanRoyaltiesGMO
    {
        public static TList_LanRoyaltiesGMO Buscar(string vID_LanctoGMO,
                                                   string Nr_contrato,
                                                   string vNr_Pedido,
                                                   string Cd_clifor,
                                                   string vCD_Produto,
                                                   string vTP_Lancto,
                                                   string vTP_GMO, 
                                                   TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(vID_LanctoGMO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoGMO";
                filtro[filtro.Length - 1].vVL_Busca = vID_LanctoGMO;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }

            if (!string.IsNullOrEmpty(vNr_Pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.Nr_Pedido";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Pedido;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "d.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.CD_Produto";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vTP_Lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Lancto";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vTP_Lancto.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }

            if (!string.IsNullOrEmpty(vTP_GMO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_GMO";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vTP_GMO.Trim() + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }

            return new TCD_LanRoyaltiesGMO(banco).Select(filtro, 0, string.Empty);
        }


        public static string GravaGMO(TList_RegLanFaturamento_Item val, 
                                      bool vTpGMOTestado,
                                      bool vTpGMODeclarado, 
                                      string vTP_Movimento, 
                                      TObjetoBanco banco)
        {
            TCD_LanRoyaltiesGMO cd = new TCD_LanRoyaltiesGMO();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;

                decimal ID_LanctoGMO = decimal.Zero;

                val.ForEach(p =>
                {
                    if (vTP_Movimento.Equals("E"))
                    {
                        //PROCURAR O PEDIDO E O CONTRATO PRA VER SE HE GMO NA CLASSE TCD_CadContratoxPedidoItem
                        //SE FOR GMO QUER DIZER QUE HE DECLARADO *** O TESTADO NUNCA VAI EXISTIR NESSA CONDICAO
                        // vST_GMOTestado = "N"; vST_GMODeclarado = ao que deu no contrato
                        TList_CadContrato lContrato = TCN_CadContrato.BuscarContrato(string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     p.Nr_pedido.ToString(),
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     p.Cd_produto,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     banco);
                        if (lContrato.Count > 0)
                            if (lContrato[0].Tp_prodcontrato.Trim().ToUpper().Equals("ID") || 
                                vTpGMOTestado || 
                                vTpGMODeclarado)
                            {
                                //GRAVA OS DESCONTOS DE GMO
                                ID_LanctoGMO = Convert.ToDecimal(Gravar(new CamadaDados.Graos.TRegistro_LanRoyaltiesGMO()
                                {
                                    CD_Produto = p.Cd_produto,
                                    Nr_Contrato = lContrato[0].Nr_contrato,
                                    TP_Lancto = "N",
                                    Tp_gmo = vTpGMOTestado ? "T" : "D",
                                    QTD_Credito = decimal.Zero,
                                    QTD_Debito = p.Quantidade_estoque > 0 ? p.Quantidade_estoque : p.Quantidade,
                                }, banco));
                                //GRAVAR  GMO NOTA
                                CamadaNegocio.Graos.TCN_Lan_NotaFiscalGMO.Gravar(new CamadaDados.Graos.TRegistro_Lan_NotaFiscalGMO()
                                {
                                    id_LanctoGmo = ID_LanctoGMO,
                                    cd_Empresa = p.Cd_empresa,
                                    nr_LanctoFiscal = p.Nr_lanctofiscal,
                                    id_NfItem = p.Id_nfitem
                                }, banco);

                                processaFinanceiroGMO(lContrato[0].Nr_contratostr, ID_LanctoGMO, banco);
                            }
                    }
                });

                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();

                return ID_LanctoGMO.ToString();

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Royalties: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        
        public static string GravaPesagemGMO(TRegistro_LanFaturamento_Item val, 
                                             string vTp_Movimento, 
                                             TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TList_RegLanAplicacao_NotaFiscal lPesagemGmo = TCN_LanAplicacao_NotaFiscal.Buscar(val.Cd_empresa, 
                                                                                              val.Nr_lanctofiscal.ToString(), 
                                                                                              val.Id_nfitem.ToString(), 
                                                                                              string.Empty, 
                                                                                              false, 
                                                                                              banco);

            if (lPesagemGmo.Count > 0)
            {
                TList_LanAplicacaoPedido lAplicPedido = TCN_LanAplicacaoPedido.Buscar(lPesagemGmo[0].Id_aplicacao.ToString(), 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, banco);
                if (lAplicPedido.Count > 0)
                {

                    TList_RegLanPesagemGraos lPsgraos = CamadaNegocio.Balanca.TCN_LanPesagemGraos.Busca(lAplicPedido[0].Cd_empresa,
                                                                                                        lAplicPedido[0].Id_ticket.ToString(),
                                                                                                        lAplicPedido[0].Tp_pesagem,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        decimal.Zero,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        0,
                                                                                                        string.Empty,
                                                                                                        banco);
                    if (lPsgraos.Count > 0)
                    {
                        //procurar GRAVA GMO NOTA
                        TList_Lan_NotaFiscalGMO NfGMO = TCN_Lan_NotaFiscalGMO.Buscar(string.Empty,
                                                                                     lAplicPedido[0].Cd_empresa,
                                                                                     val.Nr_lanctofiscal.ToString(),
                                                                                     val.Id_nfitem.ToString(),
                                                                                     banco);
                        decimal Id_lanctoGMO = decimal.Zero;
                        if (lPsgraos[0].Tp_prodpesagem.Trim().ToUpper().Equals("ID") && NfGMO.Count > 0)
                            Id_lanctoGMO = NfGMO[0].id_LanctoGmo.Value;
                        else if (lPsgraos[0].Tp_prodpesagem.Trim().ToUpper().Equals("IT"))
                            Id_lanctoGMO = Convert.ToDecimal(GravaGMO(new TList_RegLanFaturamento_Item() { val }, true, false, vTp_Movimento, banco));
                        else if (lPsgraos[0].Tp_prodpesagem.Trim().ToUpper().Equals("ID") && (NfGMO.Count < 1))
                            Id_lanctoGMO = Convert.ToDecimal(GravaGMO(new TList_RegLanFaturamento_Item() { val }, false, true, vTp_Movimento, banco));

                        if ((!string.IsNullOrEmpty(lAplicPedido[0].Cd_empresa)) &&
                            (lAplicPedido[0].Id_ticket > 0) &&
                            (!string.IsNullOrEmpty(lAplicPedido[0].Tp_pesagem)) &&
                            (Id_lanctoGMO > 0))
                        {
                            //    GRAVA O LANCTO DO PESAGEM GMO
                            retorno += CamadaNegocio.Graos.TCN_LanPesagemGMO.Gravar(new CamadaDados.Graos.TRegistro_LanPesagemGMO()
                            {
                                ID_Ticket = lAplicPedido[0].Id_ticket,
                                CD_Empresa = lAplicPedido[0].Cd_empresa,
                                TP_Pesagem = lAplicPedido[0].Tp_pesagem,
                                ID_LanctoGMO = Id_lanctoGMO
                            }, banco);
                        }
                    }
                }
            }
            return retorno;
        }

        public static string Gravar(TRegistro_LanRoyaltiesGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanRoyaltiesGMO qtb_LanRoyaltiesGMO = new TCD_LanRoyaltiesGMO();
            try
            {
                if (banco == null)
                    st_transacao = qtb_LanRoyaltiesGMO.CriarBanco_Dados(true);
                else
                    qtb_LanRoyaltiesGMO.Banco_Dados = banco;

                val.Id_lanctoGMO = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_LanRoyaltiesGMO.Gravar(val), "@P_ID_LANCTOGMO"));

                if (st_transacao)
                    qtb_LanRoyaltiesGMO.Banco_Dados.Commit_Tran();

                return val.Id_lanctoGMOstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanRoyaltiesGMO.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar royalties: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_LanRoyaltiesGMO.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanRoyaltiesGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanRoyaltiesGMO qtb_gmo = new TCD_LanRoyaltiesGMO();
            try
            {
                if (banco == null)
                    st_transacao = qtb_gmo.CriarBanco_Dados(true);
                else
                    qtb_gmo.Banco_Dados = banco;
                qtb_gmo.Excluir(val);
                if (st_transacao)
                    qtb_gmo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_gmo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Royalties: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_gmo.deletarBanco_Dados();
            }
        }

        public static string DeletarLanRoyaltiesGMO(TRegistro_LanRoyaltiesGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanRoyaltiesGMO Qtb_LanRoyaltiesGMO = new TCD_LanRoyaltiesGMO();
            try
            {
                if (banco == null)
                {
                    Qtb_LanRoyaltiesGMO.CriarBanco_Dados(true);
                    banco = Qtb_LanRoyaltiesGMO.Banco_Dados;
                    st_transacao = true;
                }
                else
                    Qtb_LanRoyaltiesGMO.Banco_Dados = banco;
                //Deletar Uf
                TList_Lan_RetencaoFinanceiraGMO lRgmo = TCN_Lan_RetencaoFinanceiraGMO.Buscar(val.Id_lanctoGMO.Value.ToString(), 
                                                                                             string.Empty, 
                                                                                             string.Empty, 
                                                                                             string.Empty, 
                                                                                             string.Empty,
                                                                                             string.Empty, 
                                                                                             string.Empty, 
                                                                                             banco);
                if (lRgmo.Count > 0)
                TCN_Lan_RetencaoFinanceiraGMO.Deletar(lRgmo[0], banco);
                
                TList_LanPesagemGMO lPsgGmo = TCN_LanPesagemGMO.Buscar(val.Id_lanctoGMO.Value.ToString(), 
                                                                       string.Empty,
                                                                       string.Empty, 
                                                                       string.Empty,
                                                                       banco);
                if (lPsgGmo.Count > 0) 
                TCN_LanPesagemGMO.Excluir(lPsgGmo[0], banco);

                TList_Lan_NotaFiscalGMO lNfGmo = TCN_Lan_NotaFiscalGMO.Buscar(val.Id_lanctoGMO.Value.ToString(), 
                                                                              string.Empty, 
                                                                              string.Empty, 
                                                                              string.Empty, 
                                                                              banco);
                if (lNfGmo.Count > 0) 
                TCN_Lan_NotaFiscalGMO.Excluir(lNfGmo[0], banco);


                Qtb_LanRoyaltiesGMO.Excluir(val);
                if (st_transacao)
                    Qtb_LanRoyaltiesGMO.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    Qtb_LanRoyaltiesGMO.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    Qtb_LanRoyaltiesGMO.deletarBanco_Dados();
            }
        }

        public static List<TRegistro_SaldoContratoGMO> processaFinanceiroGMO(string Nr_contrato, 
                                                                             decimal id_LanctoGmo, 
                                                                             TObjetoBanco banco)
        {
            //Buscar saldo pedido GMO
            List<TRegistro_SaldoContratoGMO> lSaldoContrato =
                new TCD_LanRoyaltiesGMO(banco).SelectSaldoContratoGMO(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "p.nr_contrato",
                            vOperador = "=",
                            vVL_Busca = Nr_contrato
                        }
                    }, 0);
            //Buscar Saldo NF GMO
            List<TRegistro_SaldoNFGMO> lSaldoNf =
                new TCD_LanRoyaltiesGMO(banco).SelectSaldoNFGMO(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "contrato.nr_contrato",
                            vOperador = "=",
                            vVL_Busca = Nr_contrato
                        }
                    }, 0);

            decimal pc_gmo_declarado = ConfigGer.TCN_CadParamGer.BuscaVlNumerico("PC_GMO_DECLARADO", banco);
            decimal pc_gmo_testado = ConfigGer.TCN_CadParamGer.BuscaVlNumerico("PC_GMO_TESTADO", banco);

            TList_RegLanLiquidacao liq = new TList_RegLanLiquidacao();
            //credito/debito de todas as notas fiscais do pedido
            lSaldoContrato.ForEach(p =>
                {
                    if ((p.Saldo_debito - p.Saldo_credito) > 0)
                    {
                        //Credito/Debito da nota fiscal atual
                        lSaldoNf.ForEach(v =>
                            {
                                if ((v.Saldo_debito - v.Saldo_credito) > 0)
                                {
                                    if (v.Tp_gmo.Trim().ToUpper().Equals("D") && pc_gmo_declarado.Equals(decimal.Zero))
                                        throw new Exception("Não existe configuração percentual de GMO declarado configurado.\r\n" +
                                                            "Va em PARAMETROS->CONFIGURAÇÕES->CONFIGURAÇÕES GERAIS  e configure o percentual GMO declarado.");
                                    if(v.Tp_gmo.Trim().ToUpper().Equals("T") && pc_gmo_testado.Equals(decimal.Zero))
                                        throw new Exception("Não existe configuração percentual de GMO testado configurado.\r\n" +
                                                            "Va em PARAMETROS->CONFIGURAÇÕES->CONFIGURAÇÕES GERAIS  e configure o percentual GMO testado.");
                                    decimal qtd_lancto = decimal.Zero;
                                    if ((p.Saldo_debito - p.Saldo_credito) >= (v.Saldo_debito - v.Saldo_credito))
                                        qtd_lancto = v.Saldo_debito - v.Saldo_credito;
                                    else
                                        qtd_lancto = p.Saldo_debito - p.Saldo_credito;
                                    //Calcular impostos Retidos da Nota
                                    TList_RegLanFaturamento lNf =
                                        TCN_LanFaturamento.Busca(v.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 v.Nr_lanctofiscal.ToString(),
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 false,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 decimal.Zero,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 false,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 1,
                                                                 string.Empty,
                                                                 banco);
                                    decimal vl_liquidar = decimal.Zero;
                                    if (lNf.Count > 0)
                                    {
                                        //Buscar Item da Nota
                                        TList_RegLanFaturamento_Item lItem =
                                            TCN_LanFaturamento_Item.Busca(v.Cd_empresa,
                                                                          v.Nr_lanctofiscal.Value.ToString(),
                                                                          v.Id_nfitem.Value.ToString(),
                                                                          banco);
                                        if (lItem.Count > 0)
                                        {
                                            //Calcular Impostos Retidos
                                            TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lNf[0].Cd_condfiscal_clifor,
                                                                                                  lItem[0].Cd_condfiscal_produto,
                                                                                                  lNf[0].Cd_movimentacaostring,
                                                                                                  lNf[0].Tp_movimento,
                                                                                                  lNf[0].Tp_pessoa,
                                                                                                  lNf[0].Cd_empresa,
                                                                                                  lNf[0].Nr_serie,
                                                                                                  lNf[0].Cd_clifor,
                                                                                                  lItem[0].Cd_unidEst,
                                                                                                  lNf[0].Dt_emissao,
                                                                                                  qtd_lancto,
                                                                                                  TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade,
                                                                                                                                 p.Cd_unidade_valor,
                                                                                                                                 (qtd_lancto * v.Vl_unitario),
                                                                                                                                 2,
                                                                                                                                 banco),
                                                                                                  lNf[0].Tp_nota,
                                                                                                  lNf[0].Cd_municipioexecservico,
                                                                                                  banco), lItem[0], lNf[0].Tp_movimento);
                                            lNf[0].ItensNota = lItem;
                                        }
                                        TCN_LanFaturamento.CalcTotalNota(lNf[0]);
                                        vl_liquidar = lNf[0].Vl_totalnota * ((v.Tp_gmo.Trim().ToUpper().Equals("D") ? pc_gmo_declarado : pc_gmo_testado) / 100);
                                    }
                                    else
                                        //Valor liquidar
                                        vl_liquidar = TCN_CadConvUnidade.ConvertUnid(p.Cd_unidade,
                                                                                     p.Cd_unidade_valor,
                                                                                     (qtd_lancto * v.Vl_unitario),
                                                                                     2,
                                                                                     banco) *
                                            ((v.Tp_gmo.Trim().ToUpper().Equals("D") ? pc_gmo_declarado : pc_gmo_testado) / 100);
                                    //Liquidar duplicata
                                    liquidaDuplicatas(v,
                                                      p, 
                                                      vl_liquidar, 
                                                      qtd_lancto,
                                                      banco);
                                }
                            });
                    }
                });
            
            return lSaldoContrato;
        }

        public static TList_RegLanParcela liquidaDuplicatas(TRegistro_SaldoNFGMO rSaldoNf,
                                                             TRegistro_SaldoContratoGMO rSaldoPed,
                                                             decimal vl_Liquidar, 
                                                             decimal qtdLancto,
                                                             TObjetoBanco banco)
        {            

            TList_RegLanParcela lParcelas = 
                Financeiro.Duplicata.TCN_LanParcela.Busca(rSaldoNf.Cd_empresa,
                                                          rSaldoNf.Nr_lanctoduplicata.Value,
                                                          decimal.Zero,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          0,
                                                          string.Empty,
                                                          banco);

            TRegistro_LanLiquidacao liquid = new TRegistro_LanLiquidacao();
            TList_Cad_ParamGMO lParamGMO = TCN_Cad_ParamGMO.Buscar(rSaldoNf.Cd_empresa,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   banco);
            if (lParamGMO.Count > 0)
            {
                lParcelas.ForEach(p =>
                {
                    liquid = new TRegistro_LanLiquidacao();
                    liquid.Cd_empresa = rSaldoNf.Cd_empresa;
                    liquid.Nr_lancto = rSaldoNf.Nr_lanctoduplicata.Value;
                    liquid.Cd_parcela = p.Cd_parcela;
                    liquid.cVl_Atual = vl_Liquidar;
                    liquid.Cd_contager = lParamGMO[0].Cd_contager;
                    liquid.Cvl_aliquidar_padrao = vl_Liquidar;
                    liquid.Nr_docto = p.Nr_docto;
                    liquid.Ds_contaGer = lParamGMO[0].Ds_contager;
                    liquid.Cd_portador = lParamGMO[0].Cd_portador;
                    liquid.Ds_portador = lParamGMO[0].Ds_portador;
                    liquid.Cd_historico = lParamGMO[0].Cd_historico_pgto;
                    liquid.Ds_historico = lParamGMO[0].Ds_historico_pgto;
                    liquid.Dt_Liquidacao = rSaldoNf.Dt_saient;
                    liquid.Tp_mov = p.Tp_mov;
                    liquid.Vl_parcela = p.Vl_parcela;
                    liquid.Vl_atual = p.Vl_atual;
                    liquid.Vl_difcamb_at = decimal.Zero;
                    liquid.Vl_difcamb_pa = decimal.Zero;
                    liquid.Vl_Liquidado = p.Vl_liquidado;
                    liquid.Vl_liquidado_padrao = p.Vl_liquidado;
                    liquid.Vl_DescontoBonus = decimal.Zero;
                    liquid.Vl_JuroAcrescimo = decimal.Zero;
                    liquid.st_registro = "A";
                    liquid.cVl_Nominal = decimal.Zero;
                    liquid.cVl_Liquidado = p.Vl_liquidado;
                    liquid.cVl_JuroTotal = decimal.Zero;
                    liquid.cVl_DescontoTotal = decimal.Zero;

                    Financeiro.Duplicata.TCN_LanLiquidacao.GravarLiquidacao(lParcelas, 
                                                                            liquid, 
                                                                            null, 
                                                                            null, 
                                                                            null, 
                                                                            null,
                                                                            banco);

                    //Cria registro para gravar lançamento de caixa.
                    TRegistro_LanCaixa lCx = new TRegistro_LanCaixa();
                    lCx.Cd_ContaGer = lParamGMO[0].Cd_contager;
                    lCx.Cd_LanctoCaixa = decimal.Zero;
                    lCx.Cd_Empresa = lParamGMO[0].Cd_empresa;
                    lCx.Cd_Historico = lParamGMO[0].Cd_historico_retencao;
                    lCx.Vl_RECEBER = vl_Liquidar;
                    lCx.Vl_PAGAR = decimal.Zero;
                    lCx.Vl_Atual = decimal.Zero;
                    lCx.Vl_Anterior = decimal.Zero;
                    lCx.Nr_Docto = p.Nr_docto;
                    lCx.Dt_lancto = rSaldoNf.Dt_saient;
                    lCx.ComplHistorico = string.Empty;

                    string vLanctoCx = Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(lCx, banco);
                    decimal lanctoCx = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(vLanctoCx, "@P_CD_LANCTOCAIXA"));

                    if (liquid.Id_liquid.Equals(decimal.Zero) || lanctoCx.Equals(decimal.Zero))
                        throw new Exception("Erro ao gravar Liquidação/Caixa ");

                    string credroy = Gravar(new TRegistro_LanRoyaltiesGMO()
                    {
                        CD_Produto = rSaldoPed.Cd_produto,
                        DS_Observacao = "Crédito Retido GMO nota fiscal Número " + p.Nr_docto,
                        Id_lanctoGMO = decimal.Zero,
                        Nr_Contrato = rSaldoPed.Nr_contrato,
                        QTD_Credito = qtdLancto,
                        QTD_Debito = decimal.Zero,
                        Tp_gmo = rSaldoPed.Tp_gmo,
                        TP_Lancto = "N"
                    }, banco);

                    //Cria registro da retencao financeira
                    TRegistro_Lan_RetencaoFinanceiraGMO lRGmo = new TRegistro_Lan_RetencaoFinanceiraGMO();
                    lRGmo.Id_Liquid = liquid.Id_liquid;
                    lRGmo.Id_LanctoGMO = Convert.ToDecimal(credroy);
                    lRGmo.Nr_Lancto = rSaldoNf.Nr_lanctoduplicata;
                    lRGmo.Cd_ContaGer = lParamGMO[0].Cd_contager;
                    lRGmo.Cd_Empresa = rSaldoNf.Cd_empresa;
                    lRGmo.Cd_LanctoCaixa = lanctoCx;
                    lRGmo.Cd_Parcela = p.Cd_parcela;

                    TCN_Lan_RetencaoFinanceiraGMO.Gravar(lRGmo, banco);
                    if((rSaldoNf.Nr_lanctofiscal != null) && (rSaldoNf.Id_nfitem != null))
                        TCN_Lan_NotaFiscalGMO.Gravar(
                            new TRegistro_Lan_NotaFiscalGMO()
                            {
                                cd_Empresa = rSaldoNf.Cd_empresa,
                                id_LanctoGmo = Convert.ToDecimal(credroy),
                                id_NfItem = rSaldoNf.Id_nfitem,
                                nr_LanctoFiscal = rSaldoNf.Nr_lanctofiscal
                            }, banco);
                });
            }
            else
                throw new Exception("Não existem parâmetros de GMO configurados para a empresa " + rSaldoNf.Cd_empresa.Trim());
            return lParcelas;
        }
    }
}