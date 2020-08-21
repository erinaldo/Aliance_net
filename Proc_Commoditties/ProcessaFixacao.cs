using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Proc_Commoditties
{
    public class TProcessaFixacao
    {
        public static List<CamadaDados.Graos.TRegistro_ImpostosReter> CalcularImpostoReter(string Nr_contrato,
                                                                                           decimal Vl_fixacao)
        {
            List<CamadaDados.Graos.TRegistro_ImpostosReter> ret = new List<CamadaDados.Graos.TRegistro_ImpostosReter>();
            CamadaDados.Graos.TList_CadContrato lContrato =
                CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                   Nr_contrato,
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
                                                                   null);
            if(lContrato.Count > 0)
            {
                //Buscar Movimentacao Comercial CFG Pedido
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lContrato[0].Cfg_pedido.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "in",
                                        vVL_Busca = "('CF', 'DF')"
                                    }
                                }, "a.cd_movto");
                if (obj != null)
                {
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lContrato[0].Cd_condfiscal_clifor,
                                                                                                               lContrato[0].Cd_condfiscal_produto,
                                                                                                               obj.ToString(),
                                                                                                               lContrato[0].Tp_movimento,
                                                                                                               lContrato[0].Tp_pessoa,
                                                                                                               lContrato[0].Cd_empresa,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               null,
                                                                                                               decimal.Zero,
                                                                                                               Vl_fixacao,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               null);
                    if (lImp.Count > 0)
                        lImp.FindAll(p => p.Vl_impostoretido > decimal.Zero).ForEach(p =>
                            ret.Add(new CamadaDados.Graos.TRegistro_ImpostosReter()
                            {
                                Cd_imposto = p.Cd_imposto,
                                Ds_imposto = p.Ds_imposto,
                                Vl_basecalc = p.Vl_basecalc,
                                Pc_retencao = p.Pc_retencao,
                                Vl_rentecao = p.Vl_impostoretido
                            }));
                }
            }
            return ret;
        }
        
        public static void ProcessarFixacao(CamadaDados.Balanca.TRegistro_PedidoAplicacao rPed,
                                            CamadaDados.Graos.TRegistro_LanFixacao rFixacao)
        {
            decimal pc_gmo_declarado = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("PC_GMO_DECLARADO", null);
            decimal pc_gmo_testado = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("PC_GMO_TESTADO", null);
            decimal qtd_lancto = decimal.Zero;
            //Somar Impostos Retidos das Notas de Pauta
            rFixacao.lFixacaonf.ForEach(p =>
                {
                    CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(p.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  p.Nr_lanctofiscal.ToString(),
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
                                                                                  null);
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CONTROLAR_GMO", rPed.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                    {
                        //Verificar se a NF de Pauta teve origem numa pesagem GMO (Declarada ou Testada)
                        CamadaDados.Balanca.TList_RegLanPesagemGraos lPs =
                            new CamadaDados.Balanca.TCD_LanPesagemGraos().Select(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_gro_pesagemGMO x " +
                                            "inner join tb_gro_notafiscalGMO y " +
                                            "on x.id_lanctogmo = y.id_lanctogmo " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_ticket = a.id_ticket " +
                                            "and x.tp_pesagem = a.tp_pesagem " +
                                            "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                            "and y.nr_lanctofiscal = " + p.Nr_lanctofiscal.Value.ToString() + " " +
                                            "and y.id_nfitem = " + p.Id_nfitem.Value.ToString() + ")"
                            }
                            }, string.Empty, string.Empty, 1, string.Empty);
                        if (lPs.Count > 0)
                        {
                            //Buscar saldo pedido GMO
                            List<CamadaDados.Graos.TRegistro_SaldoContratoGMO> lSaldoContrato =
                                new CamadaDados.Graos.TCD_LanRoyaltiesGMO().SelectSaldoContratoGMO(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "p.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = rPed.Nr_contratostr
                                    }
                                    }, 0);
                            if ((lSaldoContrato.Sum(v => v.Saldo_debito) - lSaldoContrato.Sum(v => v.Saldo_credito)) > 0)
                            {
                                if ((lSaldoContrato.Sum(v => v.Saldo_debito) - lSaldoContrato.Sum(v => v.Saldo_credito)) > p.Qtd_fixacao)
                                    qtd_lancto = p.Qtd_fixacao;
                                else
                                    qtd_lancto = lSaldoContrato.Sum(v => v.Saldo_debito) - lSaldoContrato.Sum(v => v.Saldo_credito);
                                lNf[0].ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(lNf[0].Cd_empresa,
                                                                                                                      lNf[0].Nr_lanctofiscalstr,
                                                                                                                      string.Empty,
                                                                                                                      null);
                                //Buscar Impostos Retidos para Quantidade royalties
                                decimal vl_impret =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(lNf[0].Cd_condfiscal_clifor,
                                                                                                                           lNf[0].ItensNota[0].Cd_condfiscal_produto,
                                                                                                                           lNf[0].Cd_movimentacaostring,
                                                                                                                           lNf[0].Tp_movimento,
                                                                                                                           lNf[0].Tp_pessoa,
                                                                                                                           lNf[0].Cd_empresa,
                                                                                                                           lNf[0].Nr_serie,
                                                                                                                           lNf[0].Cd_clifor,
                                                                                                                           lNf[0].ItensNota[0].Cd_unidEst,
                                                                                                                           lNf[0].Dt_emissao,
                                                                                                                           qtd_lancto,
                                                                                                                           CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(lNf[0].ItensNota[0].Cd_unidEst,
                                                                                                                                                                                          lNf[0].ItensNota[0].Cd_unidade,
                                                                                                                                                                                          (qtd_lancto * lNf[0].ItensNota[0].Vl_unitario),
                                                                                                                                                                                          2,
                                                                                                                                                                                          null),
                                                                                                                           lNf[0].Tp_nota,
                                                                                                                           lNf[0].Cd_municipioexecservico,
                                                                                                                           null).Sum(v => v.Vl_impostoretido);
                                if (lPs[0].Tp_prodpesagem.Trim().ToUpper().Equals("ID") ||
                                    lPs[0].Tp_prodpesagem.Trim().ToUpper().Equals("IT"))
                                {
                                    if (pc_gmo_testado.Equals(decimal.Zero))
                                        throw new Exception("Não existe configuração percentual de GMO testado configurado.\r\n" +
                                                                    "Va em PARAMETROS->CONFIGURAÇÕES->CONFIGURAÇÕES GERAIS  e configure o percentual GMO testado.");
                                    if (pc_gmo_declarado.Equals(decimal.Zero))
                                        throw new Exception("Não existe configuração percentual de GMO declarado configurado.\r\n" +
                                                                    "Va em PARAMETROS->CONFIGURAÇÕES->CONFIGURAÇÕES GERAIS  e configure o percentual GMO declarado.");
                                    rFixacao.Qtd_gmo_testado += qtd_lancto;
                                    //Valor Royalties
                                    rFixacao.Vl_royalties_testado += (CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(lNf[0].ItensNota[0].Cd_unidEst,
                                                                                                                                     lNf[0].ItensNota[0].Cd_unidade,
                                                                                                                                     (qtd_lancto * lNf[0].ItensNota[0].Vl_unitario),
                                                                                                                                     2,
                                                                                                                                     null) - vl_impret) * (pc_gmo_testado / 100);
                                }
                            }
                        }
                    }
                });
            //Processar Fiscal da Fixacao
            #region Nota Fiscal Complemento
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lPedFiscal = null;
            if (rFixacao.lFixacaonf.Exists(p => p.Vl_complemento > decimal.Zero))
            {
                //Verificar se existe configuracao fiscal pedido para emitir nf complemento
                 lPedFiscal = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = " + rPed.Nr_pedidostring + ")"
                                        },
                                        new TpBusca
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'CF'"
                                        }
                                    }, 1, string.Empty);
                if(lPedFiscal.Count.Equals(0))
                    throw new Exception("Não existe configuração fiscal de complemento de valor para o pedido Nº " + rPed.Nr_pedidostring + ".");
            }
            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfComplemento = null;
            rFixacao.lFixacaonf.Where(p => p.Vl_complemento > decimal.Zero).ToList().ForEach(p =>
                {
                    //Criar nota fiscal de complemento
                    if (rNfComplemento == null || rNfComplemento.Tp_nota.Trim().ToUpper().Equals("P"))
                    {
                        rNfComplemento = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                        rNfComplemento.Cd_empresa = rPed.Cd_empresa;
                        rNfComplemento.Cd_clifor = rPed.Cd_clifor;
                        rNfComplemento.Nm_clifor = rPed.Nm_clifor;
                        rNfComplemento.Cd_endereco = rPed.Cd_endereco;
                        rNfComplemento.Cd_cmi = lPedFiscal[0].Cd_cmi;
                        rNfComplemento.Cd_movimentacao = lPedFiscal[0].Cd_movto;
                        rNfComplemento.lCFGFiscal = lPedFiscal;
                        rNfComplemento.Cd_uf_empresa = rPed.Cd_uf_empresa;
                        rNfComplemento.Uf_empresa = rPed.Uf_empresa;
                        rNfComplemento.Cd_uf_clifor = rPed.Cd_uf_clifor;
                        rNfComplemento.Uf_clifor = rPed.Uf_clifor;
                        rNfComplemento.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                        rNfComplemento.Tp_duplicata = lPedFiscal[0].Tp_duplicata;
                        rNfComplemento.Ds_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
                        rNfComplemento.Cd_condpgto = rPed.Cd_condpgto;
                        rNfComplemento.Nr_pedido = rPed.Nr_pedido;
                        rNfComplemento.Tp_movimento = rPed.Tp_movimento;
                        rNfComplemento.Tp_pessoa = rPed.Tp_pessoa;
                        rNfComplemento.Tp_nota = rNfComplemento.Tp_pessoa.Trim().ToUpper().Equals("J") && rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P";
                        rNfComplemento.Nr_serie = lPedFiscal[0].Nr_serie;
                        rNfComplemento.Cd_modelo = lPedFiscal[0].Cd_modelo;
                        rNfComplemento.St_sequenciaauto = lPedFiscal[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                        rNfComplemento.Dt_emissao = rFixacao.Dt_fixacao;
                        rNfComplemento.Dt_saient = rFixacao.Dt_fixacao;
                        rNfComplemento.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                                        rNfComplemento.Cd_movimentacaostring,
                                                                                        rPed.Uf_clifor.Trim().Equals(rPed.Uf_empresa.Trim()));
                        rNfComplemento.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                                                  rNfComplemento.Cd_movimentacaostring,
                                                                                  rPed.Uf_empresa.Trim().Equals(rPed.Uf_clifor.Trim()));
                        //Calcular Impostos Reter Fixacao
                        string obs = string.Empty;
                        string virg = string.Empty;
                        decimal tot_retencao = decimal.Zero;
                        List<CamadaDados.Graos.TRegistro_ImpostosReter> lImpRet = TProcessaFixacao.CalcularImpostoReter(rFixacao.Nr_contratostr, p.Vl_fixacao);
                        lImpRet.ForEach(v =>
                            {
                                obs += virg + v.Ds_imposto.Trim() + " RETIDO R$" + v.Vl_rentecao.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                                virg = "\r\n";
                                tot_retencao += v.Vl_rentecao;
                            });
                        obs += virg + "LIQUIDO A RECEBER R$" + (p.Vl_fixacao - tot_retencao).ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                               "VALOR UNITARIO R$" + rFixacao.Vl_unitario.ToString("N5", new System.Globalization.CultureInfo("pt-BR")) + " POR " + rFixacao.Sigla_unidvalor.Trim();
                        rNfComplemento.Obsfiscal += (string.IsNullOrEmpty(rNfComplemento.Obsfiscal) ? string.Empty : "\r\n") + obs.Trim();
                        rNfComplemento.Pesoliquido = p.Qtd_fixacao;
                        //Buscar tipo frete no pedido
                        object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = rPed.Nr_pedidostring
                                                }
                                            }, "a.tp_frete");
                        rNfComplemento.Tp_frete = obj == null ? "9" : obj.ToString();
                        #region Numero Nota
                        if (rNfComplemento.Tp_nota.Trim().ToUpper().Equals("T") || !rNfComplemento.St_sequenciaauto)
                            using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                            {
                                fNumero.pCd_empresa = rNfComplemento.Cd_empresa;
                                fNumero.pNm_empresa = rNfComplemento.Nm_empresa;
                                fNumero.pCd_clifor = rNfComplemento.Cd_clifor;
                                fNumero.pNm_clifor = rNfComplemento.Nm_clifor;
                                fNumero.pTp_pessoa = rNfComplemento.Tp_pessoa;
                                fNumero.pTp_movimento = rNfComplemento.Tp_movimento;
                                fNumero.pTp_nota = rNfComplemento.Tp_nota;
                                fNumero.pChave_Acesso_NFe = rNfComplemento.Chave_acesso_nfe;
                                fNumero.pNr_serie = rNfComplemento.Nr_serie;
                                fNumero.pDs_serie = rNfComplemento.Ds_serienf;
                                fNumero.pCd_modelo = rNfComplemento.Cd_modelo;
                                fNumero.pDt_emissao = rNfComplemento.Dt_emissao;
                                fNumero.pST_NotaUnica = false;
                                fNumero.pNr_notafiscal = rNfComplemento.Nr_notafiscal.HasValue ? rNfComplemento.Nr_notafiscal.Value.ToString() : string.Empty;
                                fNumero.pDt_emissao = rNfComplemento.Dt_emissao;
                                fNumero.pDt_saient = rNfComplemento.Dt_saient;
                                fNumero.pDs_dadosadic = rNfComplemento.Dadosadicionais;
                                fNumero.pDs_obsfiscal = rNfComplemento.Obsfiscal;
                                fNumero.pSt_sequenciaauto = rNfComplemento.St_sequenciaauto;
                                fNumero.pCd_movto = rNfComplemento.Cd_movimentacaostring;
                                fNumero.pCd_cmi = rNfComplemento.Cd_cmistring;
                                if (rNfComplemento.Tp_nota.Trim().ToUpper().Equals("T"))
                                {
                                    //Buscar inscricao estadual do clifor da nota
                                    object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                        new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_clifor",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNfComplemento.Cd_clifor.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_endereco",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNfComplemento.Cd_endereco.Trim() + "'"
                                                                }
                                                            }, "a.insc_estadual");
                                    fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                                }
                                fNumero.pTp_frete = rNfComplemento.Tp_frete;
                                if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rNfComplemento.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                                    if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                                        rNfComplemento.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                                    else
                                        rNfComplemento.Nr_notafiscal = null;
                                    rNfComplemento.Tp_nota = fNumero.pTp_nota;
                                    rNfComplemento.Nr_serie = fNumero.pNr_serie;
                                    rNfComplemento.Cd_modelo = fNumero.pCd_modelo;
                                    rNfComplemento.Dt_emissao = fNumero.pDt_emissao;
                                    rNfComplemento.Dt_saient = fNumero.pDt_saient;
                                    rNfComplemento.Obsfiscal = fNumero.pDs_obsfiscal;
                                    rNfComplemento.Dadosadicionais = fNumero.pDs_dadosadic;
                                    rNfComplemento.Cd_transportadora = fNumero.pCd_transportadora;
                                    rNfComplemento.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                                    rNfComplemento.Cpf_transp = fNumero.pCnpjCpfTransp;
                                    rNfComplemento.Placaveiculo = fNumero.pPlacaVeiculo;
                                    rNfComplemento.Tp_frete = fNumero.pTp_frete;
                                    rNfComplemento.Especie = fNumero.pEspecie;
                                    rNfComplemento.Quantidade = fNumero.pQuantidade;
                                    rNfComplemento.Pesobruto = fNumero.pPsbruto;
                                    rNfComplemento.Pesoliquido = fNumero.pPsliquido;
                                    rNfComplemento.Vl_frete = fNumero.pVl_frete;
                                    if (rNfComplemento.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
                                    {
                                        CamadaDados.Fiscal.TRegistro_CadCMI rCmi =
                                            CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fNumero.pCd_cmi,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  false,
                                                                                  false,
                                                                                  false,
                                                                                  false,
                                                                                  false,
                                                                                  false,
                                                                                  null)[0];
                                        rNfComplemento.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                        {
                                            St_compdevimposto = rCmi.St_compdevimposto,
                                            St_complementar = rCmi.St_complementar,
                                            St_devolucao = rCmi.St_devolucao,
                                            St_geraestoque = rCmi.St_geraestoque,
                                            St_mestra = rCmi.St_mestra,
                                            St_simplesremessa = rCmi.St_simplesremessa,
                                            St_retorno = rCmi.St_retorno
                                        });
                                        rNfComplemento.Cd_cmistring = fNumero.pCd_cmi;
                                        rNfComplemento.Ds_cmi = rCmi.Ds_cmi;
                                        rNfComplemento.Tp_duplicata = rCmi.Tp_duplicata;
                                        rNfComplemento.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                    }
                                }
                                else
                                    throw new Exception("Obrigatorio informar numero da nota fiscal.");
                            }
                        if (rNfComplemento.Nr_notafiscal.HasValue)
                        {
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNfComplemento.Nr_notafiscalstr,
                                                                                                         rNfComplemento.Nr_serie,
                                                                                                         rNfComplemento.Cd_empresa,
                                                                                                         rNfComplemento.Cd_clifor,
                                                                                                         string.Empty,
                                                                                                         rNfComplemento.Tp_nota,
                                                                                                         null);
                            if (rFat != null)
                                if (rFat.St_registro.Trim().ToUpper().Equals("C"))
                                    throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra cancelada.\r\n" +
                                                        "Para poder utilizar o mesmo numero e necessario excluir a nota fiscal cancelada.\r\n" +
                                                        "Dica: Menu FATURAMENTO->Emissão de Notas Fiscais / NFe, localize a nota fiscal cancelada e exclua a mesma.\r\n" +
                                                        "Obs.: Para excluir a nota fiscal cancelada é necessario que o usuario tenha permissão.");
                                else
                                    throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se econtra ativa.\r\n" +
                                                        "Não é permitido gerar nota fiscal com mesmo numero.");
                        }
                        #endregion

                        #region Itens Complemento
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItemComp = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                        rItemComp.Cd_empresa = rPed.Cd_empresa;
                        rItemComp.Cd_produto = rPed.Cd_produto;
                        rItemComp.Id_variedade = p.Id_variedade;
                        rItemComp.Cd_local = rPed.Cd_local;
                        rItemComp.Cd_condfiscal_produto = rPed.Cd_condfiscal_produto;
                        rItemComp.Cd_unidade = rPed.Cd_unidade;
                        rItemComp.Cd_unidEst = rPed.Cd_unidade_estoque;
                        rItemComp.Nr_pedido = rPed.Nr_pedido.Value;
                        rItemComp.Id_pedidoitem = rPed.Id_pedidoitem;
                        rItemComp.Quantidade = decimal.Zero;//Complemento de Valor
                        rItemComp.Quantidade_estoque = decimal.Zero;//Complemento de Valor
                        rItemComp.Vl_subtotal = p.Vl_complemento;
                        rItemComp.Vl_subtotal_estoque = rItemComp.Vl_subtotal;
                        rItemComp.Vl_unitario = decimal.Zero;//Complemento de Valor
                        //Procurar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNfComplemento.Cd_movimentacaostring,
                                                                           rPed.Cd_condfiscal_produto,
                                                                           rPed.Cd_uf_clifor.Trim().Equals("99") ? "I" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                           (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_clifor : rNfComplemento.Cd_uf_empresa),
                                                                           (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_empresa : rNfComplemento.Cd_uf_clifor),
                                                                           rNfComplemento.Tp_movimento,
                                                                           rNfComplemento.Cd_condfiscal_clifor,
                                                                           rNfComplemento.Cd_empresa,
                                                                           ref rCfop,
                                                                           null))
                        {
                            rItemComp.Cd_cfop = rCfop.CD_CFOP;
                            rItemComp.Ds_cfop = rCfop.DS_CFOP;
                            rItemComp.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (rPed.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNfComplemento.Cd_movimentacaostring + " condição fiscal do produto " + rPed.Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNfComplemento.Cd_empresa,
                                                                                                              (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_clifor : rNfComplemento.Cd_uf_empresa),
                                                                                                              (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_empresa : rNfComplemento.Cd_uf_clifor),
                                                                                                              rNfComplemento.Cd_movimentacaostring,
                                                                                                              rNfComplemento.Tp_movimento,
                                                                                                              rNfComplemento.Cd_condfiscal_clifor,
                                                                                                              rItemComp.Cd_condfiscal_produto,
                                                                                                              rItemComp.Vl_subtotal,
                                                                                                              rItemComp.Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rNfComplemento.Dt_emissao,
                                                                                                              rItemComp.Cd_produto,
                                                                                                              rNfComplemento.Tp_nota,
                                                                                                              rNfComplemento.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Exists(v=>v.Imposto.St_ICMS))
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItemComp);
                        else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItemComp.Cd_produto, rNfComplemento.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + rNfComplemento.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + rNfComplemento.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + rNfComplemento.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rItemComp.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Uf_clifor.Trim() : rNfComplemento.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Uf_empresa.Trim() : rNfComplemento.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNfComplemento.Cd_condfiscal_clifor,
                                                                                                                       rItemComp.Cd_condfiscal_produto,
                                                                                                                       rNfComplemento.Cd_movimentacaostring,
                                                                                                                       rNfComplemento.Tp_movimento,
                                                                                                                       rNfComplemento.Tp_pessoa,
                                                                                                                       rNfComplemento.Cd_empresa,
                                                                                                                       rNfComplemento.Nr_serie,
                                                                                                                       rNfComplemento.Cd_clifor,
                                                                                                                       rItemComp.Cd_unidEst,
                                                                                                                       rNfComplemento.Dt_emissao,
                                                                                                                       rItemComp.Quantidade,
                                                                                                                       rItemComp.Vl_subtotal,
                                                                                                                       rNfComplemento.Tp_nota,
                                                                                                                       string.Empty,
                                                                                                                       null), rItemComp, rNfComplemento.Tp_movimento);
                        //Concatenar Impostos Reter Funrural/Senar com a base de calculo no valor total da fixação.
                        lImpRet.ForEach(x =>
                            {
                                CamadaDados.Fiscal.TRegistro_CadImposto imposto =
                                    new CamadaDados.Fiscal.TCD_CadImposto().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_imposto", vOperador = "=", vVL_Busca = x.Cd_imposto.Value.ToString() },
                                    }, 1, string.Empty)[0];
                                if (imposto.St_Funrural)
                                {
                                    rItemComp.Vl_basecalcFunrural = x.Vl_basecalc;
                                    rItemComp.Pc_retencaoFunrural = x.Pc_retencao;
                                    rItemComp.Vl_retidoFunrural = x.Vl_rentecao;
                                }
                                else if (imposto.St_Senar)
                                {
                                    rItemComp.Vl_basecalcSenar = x.Vl_basecalc;
                                    rItemComp.Pc_retencaoSenar = x.Pc_retencao;
                                    rItemComp.Vl_retidoSenar = x.Vl_rentecao;
                                }
                            });
                        rItemComp.lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nr_notafiscal_origem = p.Nr_notafiscal,
                            Nr_serie_origem = p.Nr_serie,
                            Nr_lanctofiscal_origem = p.Nr_lanctofiscal.Value,
                            Id_nfitem_origem = p.Id_nfitem.Value,
                            Qtd_lancto = p.Qtd_fixacao,
                            Vl_lancto = p.Vl_complemento,
                            Tp_operacao = "C"
                        });
                        rItemComp.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" +
                                                     (p.Nr_notafiscal.ToString() + "/" + p.Nr_serie).FormatStringDireita(21, ' ') +
                                                     (p.Qtd_fixacao.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                                     p.Sigla_unidade.Trim()).FormatStringDireita(15, ' ') +
                                                     (p.Qtd_fixacao * p.Vl_pauta).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ');
                        rNfComplemento.ItensNota.Add(rItemComp);
                        #endregion

                        p.rNfComplemento = rNfComplemento;
                    }
                    else
                    {
                        rNfComplemento.ItensNota[0].Vl_subtotal += p.Vl_complemento;
                        rNfComplemento.ItensNota[0].Vl_subtotal_estoque += p.Vl_complemento;
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNfComplemento.Cd_empresa,
                                                                                                              (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_clifor : rNfComplemento.Cd_uf_empresa),
                                                                                                              (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Cd_uf_empresa : rNfComplemento.Cd_uf_clifor),
                                                                                                              rNfComplemento.Cd_movimentacaostring,
                                                                                                              rNfComplemento.Tp_movimento,
                                                                                                              rNfComplemento.Cd_condfiscal_clifor,
                                                                                                              rNfComplemento.ItensNota[0].Cd_condfiscal_produto,
                                                                                                              rNfComplemento.ItensNota[0].Vl_subtotal,
                                                                                                              rNfComplemento.ItensNota[0].Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rNfComplemento.Dt_emissao,
                                                                                                              rNfComplemento.ItensNota[0].Cd_produto,
                                                                                                              rNfComplemento.Tp_nota,
                                                                                                              rNfComplemento.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rNfComplemento.ItensNota[0]);
                        else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rNfComplemento.ItensNota[0].Cd_produto, rNfComplemento.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + rNfComplemento.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + rNfComplemento.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + rNfComplemento.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rNfComplemento.ItensNota[0].Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Uf_clifor.Trim() : rNfComplemento.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (rNfComplemento.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComplemento.Uf_empresa.Trim() : rNfComplemento.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNfComplemento.Cd_condfiscal_clifor,
                                                                                                                       rNfComplemento.ItensNota[0].Cd_condfiscal_produto,
                                                                                                                       rNfComplemento.Cd_movimentacaostring,
                                                                                                                       rNfComplemento.Tp_movimento,
                                                                                                                       rNfComplemento.Tp_pessoa,
                                                                                                                       rNfComplemento.Cd_empresa,
                                                                                                                       rNfComplemento.Nr_serie,
                                                                                                                       rNfComplemento.Cd_clifor,
                                                                                                                       rNfComplemento.ItensNota[0].Cd_unidEst,
                                                                                                                       rNfComplemento.Dt_emissao,
                                                                                                                       rNfComplemento.ItensNota[0].Quantidade,
                                                                                                                       rNfComplemento.ItensNota[0].Vl_subtotal,
                                                                                                                       rNfComplemento.Tp_nota,
                                                                                                                       string.Empty,
                                                                                                                       null), rNfComplemento.ItensNota[0], rNfComplemento.Tp_movimento);
                        rNfComplemento.ItensNota[0].lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nr_notafiscal_origem = p.Nr_notafiscal,
                            Nr_serie_origem = p.Nr_serie,
                            Nr_lanctofiscal_origem = p.Nr_lanctofiscal.Value,
                            Id_nfitem_origem = p.Id_nfitem.Value,
                            Qtd_lancto = p.Qtd_fixacao,
                            Vl_lancto = p.Vl_complemento,
                            Tp_operacao = "C"
                        });
                        rNfComplemento.ItensNota[0].Observacao_item += (p.Nr_notafiscal.ToString() + "/" + p.Nr_serie).FormatStringDireita(21, ' ') +
                                                                       (p.Qtd_fixacao.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                                                       p.Sigla_unidade.Trim()).FormatStringDireita(15, ' ') +
                                                                       (p.Qtd_fixacao * p.Vl_pauta).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ');
                    }
                    //Calcular Royalties sobre nota de complemento
                    if ((rFixacao.Qtd_gmo_declarado > 0) || (rFixacao.Qtd_gmo_testado > 0))
                    {
                        decimal pc_declarado = rFixacao.Qtd_gmo_declarado / qtd_lancto;
                        decimal pc_testado = rFixacao.Qtd_gmo_testado / qtd_lancto;
                        if ((pc_declarado + pc_testado) > 1)
                            pc_testado -= (pc_declarado + pc_testado) - 1;
                        else if ((pc_declarado + pc_testado) < 1)
                            pc_declarado += 1 - (pc_declarado + pc_testado);

                        decimal vl_impret = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNfComplemento.Cd_condfiscal_clifor,
                                                                                                                                       rNfComplemento.ItensNota[0].Cd_condfiscal_produto,
                                                                                                                                       rNfComplemento.Cd_movimentacaostring,
                                                                                                                                       rNfComplemento.Tp_movimento,
                                                                                                                                       rNfComplemento.Tp_pessoa,
                                                                                                                                       rNfComplemento.Cd_empresa,
                                                                                                                                       rNfComplemento.Nr_serie,
                                                                                                                                       rNfComplemento.Cd_clifor,
                                                                                                                                       rNfComplemento.ItensNota[0].Cd_unidEst,
                                                                                                                                       rNfComplemento.Dt_emissao,
                                                                                                                                       qtd_lancto,
                                                                                                                                       CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(rNfComplemento.ItensNota[0].Cd_unidEst,
                                                                                                                                                                                                      rNfComplemento.ItensNota[0].Cd_unidade,
                                                                                                                                                                                                      (qtd_lancto *
                                                                                                                                                                                                      (rFixacao.lFixacaonf.Sum(v => v.Vl_complemento) / rFixacao.Ps_fixado_total)),
                                                                                                                                                                                                      2,
                                                                                                                                                                                                      null),
                                                                                                                                       rNfComplemento.Tp_nota,
                                                                                                                                       string.Empty,
                                                                                                                                       null).Sum(v => v.Vl_impostoretido);

                        if (pc_declarado > 0)
                            rFixacao.Vl_royalties_declarado += ((CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(rNfComplemento.ItensNota[0].Cd_unidEst,
                                                                                                                                rNfComplemento.ItensNota[0].Cd_unidade,
                                                                                                                                (qtd_lancto *
                                                                                                                                (rFixacao.lFixacaonf.Sum(v => v.Vl_complemento) / rFixacao.Ps_fixado_total)),
                                                                                                                                2,
                                                                                                                                null) - vl_impret) *
                                                                pc_declarado) * (pc_gmo_declarado / 100);
                        if (pc_testado > 0)
                            rFixacao.Vl_royalties_testado += (CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(rNfComplemento.ItensNota[0].Cd_unidEst,
                                                                                                                             rNfComplemento.ItensNota[0].Cd_unidade,
                                                                                                                             (qtd_lancto * rFixacao.Vl_unitario),
                                                                                                                             2,
                                                                                                                             null) * pc_testado) * (pc_gmo_testado / 100);
                    }
                });
            #endregion

            #region Nota Fiscal Devolucao
            if(rFixacao.lFixacaonf.Exists(p=> p.Vl_devolucao > decimal.Zero))
            {
                //Verificar se existe configuracao fiscal pedido para emitir nf devolucao
                lPedFiscal = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                                new TpBusca[]
                                {
                                        new TpBusca
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = " + rPed.Nr_pedidostring + ")"
                                        },
                                        new TpBusca
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'DF'"
                                        }
                                }, 1, string.Empty);
                if (lPedFiscal.Count.Equals(0))
                    throw new Exception("Não existe configuração fiscal de devolução fiscal para o pedido Nº " + rPed.Nr_pedidostring + ".");
                rFixacao.rNfDev = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                rFixacao.rNfDev.Cd_empresa = rPed.Cd_empresa;
                rFixacao.rNfDev.Cd_clifor = rPed.Cd_clifor;
                rFixacao.rNfDev.Nm_clifor = rPed.Nm_clifor;
                rFixacao.rNfDev.Cd_endereco = rPed.Cd_endereco;
                rFixacao.rNfDev.Cd_cmi = lPedFiscal[0].Cd_cmi;
                rFixacao.rNfDev.Cd_movimentacao = lPedFiscal[0].Cd_movto;
                rFixacao.rNfDev.lCFGFiscal = lPedFiscal;
                rFixacao.rNfDev.Cd_uf_empresa = rPed.Cd_uf_empresa;
                rFixacao.rNfDev.Uf_empresa = rPed.Uf_empresa;
                rFixacao.rNfDev.Cd_uf_clifor = rPed.Cd_uf_clifor;
                rFixacao.rNfDev.Uf_clifor = rPed.Uf_clifor;
                rFixacao.rNfDev.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                rFixacao.rNfDev.Tp_duplicata = lPedFiscal[0].Tp_duplicata;
                rFixacao.rNfDev.Ds_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
                rFixacao.rNfDev.Cd_condpgto = rPed.Cd_condpgto;
                rFixacao.rNfDev.Nr_pedido = rPed.Nr_pedido;
                rFixacao.rNfDev.Tp_movimento = rPed.Tp_movimento.Trim().ToUpper().Equals("E") ? "S" : "E";
                rFixacao.rNfDev.Tp_pessoa = rPed.Tp_pessoa;
                rFixacao.rNfDev.Tp_nota = rFixacao.rNfDev.Tp_pessoa.Trim().ToUpper().Equals("J") && rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P";
                rFixacao.rNfDev.Nr_serie = lPedFiscal[0].Nr_serie;
                rFixacao.rNfDev.Cd_modelo = lPedFiscal[0].Cd_modelo;
                rFixacao.rNfDev.St_sequenciaauto = lPedFiscal[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                rFixacao.rNfDev.Dt_emissao = rFixacao.Dt_fixacao;
                rFixacao.rNfDev.Dt_saient = rFixacao.rNfDev.Dt_emissao;
                rFixacao.rNfDev.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                                 rFixacao.rNfDev.Cd_movimentacaostring,
                                                                                 rPed.Uf_clifor.Trim().Equals(rPed.Uf_empresa.Trim()));
                rFixacao.rNfDev.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                                           rFixacao.rNfDev.Cd_movimentacaostring,
                                                                           rPed.Uf_empresa.Trim().Equals(rPed.Uf_clifor.Trim()));
                //Calcular Impostos Reter Fixacao
                string obs = string.Empty;
                string virg = string.Empty;
                decimal tot_retencao = decimal.Zero;
                List<CamadaDados.Graos.TRegistro_ImpostosReter> lImpRet = CalcularImpostoReter(rFixacao.Nr_contratostr, rFixacao.lFixacaonf.Where(p => p.Vl_devolucao > decimal.Zero).Sum(p=> p.Vl_fixacao));
                lImpRet.ForEach(v =>
                {
                    obs += virg = v.Ds_imposto.Trim() + " RETIDO R$" + v.Vl_rentecao.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    virg = "\r\n";
                    tot_retencao += v.Vl_rentecao;
                });
                obs += virg + "LIQUIDO A RECEBER R$" + (rFixacao.lFixacaonf.Where(p => p.Vl_devolucao > decimal.Zero).Sum(p => p.Vl_fixacao) - tot_retencao).ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                       "VALOR UNITARIO R$" + rFixacao.Vl_unitario.ToString("N5", new System.Globalization.CultureInfo("pt-BR")) + " POR " + rFixacao.Sigla_unidvalor.Trim();
                rFixacao.rNfDev.Obsfiscal += (string.IsNullOrEmpty(rFixacao.rNfDev.Obsfiscal) ? string.Empty : "\r\n") + obs.Trim();
                rFixacao.rNfDev.Pesoliquido = rFixacao.lFixacaonf.Where(p => p.Vl_devolucao > decimal.Zero).Sum(p => p.Qtd_fixacao);
                //Buscar tipo frete no pedido
                object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = rPed.Nr_pedidostring
                                                }
                                        }, "a.tp_frete");
                rFixacao.rNfDev.Tp_frete = obj == null ? "9" : obj.ToString();
                #region Dados da Nota
                if (rFixacao.rNfDev.Tp_nota.Trim().ToUpper().Equals("T") || !rFixacao.rNfDev.St_sequenciaauto)
                    using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                    {
                        fNumero.pCd_empresa = rFixacao.rNfDev.Cd_empresa;
                        fNumero.pNm_empresa = rFixacao.rNfDev.Nm_empresa;
                        fNumero.pCd_clifor = rFixacao.rNfDev.Cd_clifor;
                        fNumero.pNm_clifor = rFixacao.rNfDev.Nm_clifor;
                        fNumero.pTp_pessoa = rFixacao.rNfDev.Tp_pessoa;
                        fNumero.pTp_movimento = rFixacao.rNfDev.Tp_movimento;
                        fNumero.pTp_nota = rFixacao.rNfDev.Tp_nota;
                        fNumero.pChave_Acesso_NFe = rFixacao.rNfDev.Chave_acesso_nfe;
                        fNumero.pNr_serie = rFixacao.rNfDev.Nr_serie;
                        fNumero.pDs_serie = rFixacao.rNfDev.Ds_serienf;
                        fNumero.pCd_modelo = rFixacao.rNfDev.Cd_modelo;
                        fNumero.pDt_emissao = rFixacao.rNfDev.Dt_emissao;
                        fNumero.pST_NotaUnica = false;
                        fNumero.pNr_notafiscal = rFixacao.rNfDev.Nr_notafiscalstr;
                        fNumero.pDt_emissao = rFixacao.rNfDev.Dt_emissao;
                        fNumero.pDt_saient = rFixacao.rNfDev.Dt_saient;
                        fNumero.pDs_dadosadic = rFixacao.rNfDev.Dadosadicionais;
                        fNumero.pDs_obsfiscal = rFixacao.rNfDev.Obsfiscal;
                        fNumero.pSt_sequenciaauto = rFixacao.rNfDev.St_sequenciaauto;
                        fNumero.pCd_movto = rFixacao.rNfDev.Cd_movimentacaostring;
                        fNumero.pCd_cmi = rFixacao.rNfDev.Cd_cmistring;
                        if (rFixacao.rNfDev.Tp_nota.Trim().ToUpper().Equals("T"))
                        {
                            //Buscar inscricao estadual do clifor da nota
                            object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                new TpBusca[]
                                                        {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_clifor",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rFixacao.rNfDev.Cd_clifor.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_endereco",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rFixacao.rNfDev.Cd_endereco.Trim() + "'"
                                                                }
                                                        }, "a.insc_estadual");
                            fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                        }
                        fNumero.pTp_frete = rFixacao.rNfDev.Tp_frete;
                        if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            rFixacao.rNfDev.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                            if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                                rFixacao.rNfDev.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                            else rFixacao.rNfDev.Nr_notafiscal = null;
                            rFixacao.rNfDev.Tp_nota = fNumero.pTp_nota;
                            rFixacao.rNfDev.Nr_serie = fNumero.pNr_serie;
                            rFixacao.rNfDev.Cd_modelo = fNumero.pCd_modelo;
                            rFixacao.rNfDev.Dt_emissao = fNumero.pDt_emissao;
                            rFixacao.rNfDev.Dt_saient = fNumero.pDt_saient;
                            rFixacao.rNfDev.Obsfiscal = fNumero.pDs_obsfiscal;
                            rFixacao.rNfDev.Dadosadicionais = fNumero.pDs_dadosadic;
                            rFixacao.rNfDev.Cd_transportadora = fNumero.pCd_transportadora;
                            rFixacao.rNfDev.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                            rFixacao.rNfDev.Cpf_transp = fNumero.pCnpjCpfTransp;
                            rFixacao.rNfDev.Placaveiculo = fNumero.pPlacaVeiculo;
                            rFixacao.rNfDev.Tp_frete = fNumero.pTp_frete;
                            rFixacao.rNfDev.Especie = fNumero.pEspecie;
                            rFixacao.rNfDev.Quantidade = fNumero.pQuantidade;
                            rFixacao.rNfDev.Pesobruto = fNumero.pPsbruto;
                            rFixacao.rNfDev.Pesoliquido = fNumero.pPsliquido;
                            rFixacao.rNfDev.Vl_frete = fNumero.pVl_frete;
                            if (rFixacao.rNfDev.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
                            {
                                CamadaDados.Fiscal.TRegistro_CadCMI rCmi =
                                    CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fNumero.pCd_cmi,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          null)[0];
                                rFixacao.rNfDev.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                {
                                    St_compdevimposto = rCmi.St_compdevimposto,
                                    St_complementar = rCmi.St_complementar,
                                    St_devolucao = rCmi.St_devolucao,
                                    St_geraestoque = rCmi.St_geraestoque,
                                    St_mestra = rCmi.St_mestra,
                                    St_simplesremessa = rCmi.St_simplesremessa,
                                    St_retorno = rCmi.St_retorno
                                });
                                rFixacao.rNfDev.Cd_cmistring = fNumero.pCd_cmi;
                                rFixacao.rNfDev.Ds_cmi = rCmi.Ds_cmi;
                                rFixacao.rNfDev.Tp_duplicata = rCmi.Tp_duplicata;
                                rFixacao.rNfDev.Ds_tpduplicata = rCmi.ds_tpduplicata;
                            }
                        }
                        else
                            throw new Exception("Obrigatorio informar numero da nota fiscal.");
                    }
                if (rFixacao.rNfDev.Nr_notafiscal.HasValue)
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rFixacao.rNfDev.Nr_notafiscalstr,
                                                                                                 rFixacao.rNfDev.Nr_serie,
                                                                                                 rFixacao.rNfDev.Cd_empresa,
                                                                                                 rFixacao.rNfDev.Cd_clifor,
                                                                                                 string.Empty,
                                                                                                 rFixacao.rNfDev.Tp_nota,
                                                                                                 null);
                    if (rFat != null)
                        if (rFat.St_registro.Trim().ToUpper().Equals("C"))
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra cancelada.\r\n" +
                                                "Para poder utilizar o mesmo numero e necessario excluir a nota fiscal cancelada.\r\n" +
                                                "Dica: Menu FATURAMENTO->Emissão de Notas Fiscais / NFe, localize a nota fiscal cancelada e exclua a mesma.\r\n" +
                                                "Obs.: Para excluir a nota fiscal cancelada é necessario que o usuario tenha permissão.");
                        else
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se econtra ativa.\r\n" +
                                                "Não é permitido gerar nota fiscal com mesmo numero.");
                }
                #region Itens Nota
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItemDev = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                rItemDev.Cd_empresa = rPed.Cd_empresa;
                rItemDev.Cd_produto = rPed.Cd_produto;
                rItemDev.Id_variedade = rFixacao.lFixacaonf.Where(p=> p.Vl_devolucao > decimal.Zero).First().Id_variedade;
                rItemDev.Cd_local = rPed.Cd_local;
                rItemDev.Cd_condfiscal_produto = rPed.Cd_condfiscal_produto;
                rItemDev.Cd_unidade = rPed.Cd_unidade;
                rItemDev.Cd_unidEst = rPed.Cd_unidade_estoque;
                rItemDev.Nr_pedido = rPed.Nr_pedido.Value;
                rItemDev.Id_pedidoitem = rPed.Id_pedidoitem;
                rItemDev.Quantidade = decimal.Zero;//Devolucao somente Valor
                rItemDev.Quantidade_estoque = decimal.Zero;//Devolucao somente Valor
                rItemDev.Vl_subtotal = rFixacao.lFixacaonf.Where(p => p.Vl_devolucao > decimal.Zero).Sum(p => p.Vl_devolucao);
                rItemDev.Vl_subtotal_estoque = rItemDev.Vl_subtotal;
                rItemDev.Vl_unitario = decimal.Zero;//Devolucao somente Valor
                                                    //Procurar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rFixacao.rNfDev.Cd_movimentacaostring,
                                                                   rPed.Cd_condfiscal_produto,
                                                                   rPed.Cd_uf_clifor.Trim().Equals("99") ? "I" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                   (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Cd_uf_clifor : rFixacao.rNfDev.Cd_uf_empresa),
                                                                   (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Cd_uf_empresa : rFixacao.rNfDev.Cd_uf_clifor),
                                                                   rFixacao.rNfDev.Tp_movimento,
                                                                   rFixacao.rNfDev.Cd_condfiscal_clifor,
                                                                   rFixacao.rNfDev.Cd_empresa,
                                                                   ref rCfop,
                                                                   null))
                {
                    rItemDev.Cd_cfop = rCfop.CD_CFOP;
                    rItemDev.Ds_cfop = rCfop.DS_CFOP;
                    rItemDev.St_bonificacao = rCfop.St_bonificacaobool;
                }
                else
                    throw new Exception("Não existe CFOP " + (rPed.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rFixacao.rNfDev.Cd_movimentacaostring + " condição fiscal do produto " + rPed.Cd_condfiscal_produto);
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rFixacao.rNfDev.Cd_empresa,
                                                                                                      (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Cd_uf_clifor : rFixacao.rNfDev.Cd_uf_empresa),
                                                                                                      (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Cd_uf_empresa : rFixacao.rNfDev.Cd_uf_clifor),
                                                                                                      rFixacao.rNfDev.Cd_movimentacaostring,
                                                                                                      rFixacao.rNfDev.Tp_movimento,
                                                                                                      rFixacao.rNfDev.Cd_condfiscal_clifor,
                                                                                                      rItemDev.Cd_condfiscal_produto,
                                                                                                      rItemDev.Vl_subtotal,
                                                                                                      rItemDev.Quantidade,
                                                                                                      ref vObsFiscal,
                                                                                                      rFixacao.rNfDev.Dt_emissao,
                                                                                                      rItemDev.Cd_produto,
                                                                                                      rFixacao.rNfDev.Tp_nota,
                                                                                                      rFixacao.rNfDev.Nr_serie,
                                                                                                      null);
                if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                {
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItemDev);
                    rFixacao.rNfDev.Obsfiscal += vObsFiscal.Trim();
                }
                else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItemDev.Cd_produto, rFixacao.rNfDev.Nr_serie, null))
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                            "Tipo Movimento: " + rFixacao.rNfDev.Tipo_movimento.Trim() + "\r\n" +
                                            "Movimentação: " + rFixacao.rNfDev.Cd_movimentacao.ToString() + "\r\n" +
                                            "Cond. Fiscal Clifor: " + rFixacao.rNfDev.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + rItemDev.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "UF Origem: " + (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Uf_clifor.Trim() : rFixacao.rNfDev.Uf_empresa.Trim()) + "\r\n" +
                                            "UF Destino: " + (rFixacao.rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rFixacao.rNfDev.Uf_empresa.Trim() : rFixacao.rNfDev.Uf_clifor.Trim()));

                //Procurar impostos sobre os itens da nota fiscal de destino
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rFixacao.rNfDev.Cd_condfiscal_clifor,
                                                                                                               rItemDev.Cd_condfiscal_produto,
                                                                                                               rFixacao.rNfDev.Cd_movimentacaostring,
                                                                                                               rFixacao.rNfDev.Tp_movimento,
                                                                                                               rFixacao.rNfDev.Tp_pessoa,
                                                                                                               rFixacao.rNfDev.Cd_empresa,
                                                                                                               rFixacao.rNfDev.Nr_serie,
                                                                                                               rFixacao.rNfDev.Cd_clifor,
                                                                                                               rItemDev.Cd_unidEst,
                                                                                                               rFixacao.rNfDev.Dt_emissao,
                                                                                                               rItemDev.Quantidade,
                                                                                                               rItemDev.Vl_subtotal,
                                                                                                               rFixacao.rNfDev.Tp_nota,
                                                                                                               string.Empty,
                                                                                                               null), rItemDev, rFixacao.rNfDev.Tp_movimento);
                //Concatenar Impostos Reter Funrural/Senar com a base de calculo no valor total da fixação.
                lImpRet.ForEach(x =>
                {
                    CamadaDados.Fiscal.TRegistro_CadImposto imposto =
                    new CamadaDados.Fiscal.TCD_CadImposto().Select(
                        new TpBusca[]
                        {
                            new TpBusca { vNM_Campo = "a.cd_imposto", vOperador = "=", vVL_Busca = x.Cd_imposto.Value.ToString() },
                        }, 1, string.Empty)[0];
                    if (imposto.St_Funrural)
                    {
                        rItemDev.Vl_basecalcFunrural = x.Vl_basecalc;
                        rItemDev.Pc_retencaoFunrural = x.Pc_retencao;
                        rItemDev.Vl_retidoFunrural = x.Vl_rentecao;
                    }
                    else if(imposto.St_Senar)
                    {
                        rItemDev.Vl_basecalcSenar = x.Vl_basecalc;
                        rItemDev.Pc_retencaoSenar = x.Pc_retencao;
                        rItemDev.Vl_retidoSenar = x.Vl_rentecao;
                    }
                });
                string obsItem = "NF/Serie Origem      Quantidade     Valor(R$)";
                rFixacao.lFixacaonf.Where(p => p.Vl_devolucao > decimal.Zero).ToList().ForEach(p =>
                 {
                     rItemDev.lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                     {
                         Cd_empresa = p.Cd_empresa,
                         Nr_notafiscal_origem = p.Nr_notafiscal,
                         Nr_serie_origem = p.Nr_serie,
                         Nr_lanctofiscal_origem = p.Nr_lanctofiscal.Value,
                         Id_nfitem_origem = p.Id_nfitem.Value,
                         Qtd_lancto = p.Qtd_fixacao,
                         Vl_lancto = p.Vl_devolucao,
                         Tp_operacao = "D"
                     });
                     obsItem += "\r\n" + (p.Nr_notafiscal.ToString() + "/" + p.Nr_serie).FormatStringDireita(21, ' ') +
                                         (p.Qtd_fixacao.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                         p.Sigla_unidade.Trim()).FormatStringDireita(15, ' ') +
                                         p.Vl_devolucao.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ');
                 });

                rItemDev.Observacao_item += obsItem;
                #endregion
                rFixacao.rNfDev.ItensNota.Add(rItemDev);
                //Calcular Royalties sobre nota de complemento
                if ((rFixacao.Qtd_gmo_testado > 0) || (rFixacao.Qtd_gmo_declarado > 0))
                {
                    decimal pc_declarado = rFixacao.Qtd_gmo_declarado / rFixacao.Ps_fixado_total;
                    decimal pc_testado = rFixacao.Qtd_gmo_testado / rFixacao.Ps_fixado_total;
                    if ((pc_declarado + pc_testado) > 100)
                        pc_testado -= (pc_declarado + pc_testado) - 100;
                    else if ((pc_declarado + pc_testado) < 100)
                        pc_declarado += 100 - (pc_declarado + pc_testado);
                    if (pc_declarado > 0)
                        rFixacao.Vl_royalties_declarado -= (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CalcTotalNota(rFixacao.rNfDev) *
                                                            pc_declarado) * (pc_gmo_declarado / 100);
                    if (pc_testado > 0)
                        rFixacao.Vl_royalties_testado -= (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CalcTotalNota(rFixacao.rNfDev) *
                                                            pc_testado) * (pc_gmo_testado / 100);
                }
                #endregion
            }
            #endregion

            //Processar Financeiro Fixacao
            #region Financeiro Fixacao
            CamadaDados.Graos.TRegistro_CadContrato rContrato = 
                CamadaNegocio.Graos.TCN_CadContrato.Buscar(rPed.Nr_contratostr,
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
                                                           1,
                                                           null)[0];
            if(!string.IsNullOrEmpty(rContrato.Tp_duplicata_fix))
            {
                using(Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                {
                    fDuplicata.vNr_pedido = null;
                    fDuplicata.vSt_notafiscal = true;
                    fDuplicata.vCd_empresa = rPed.Cd_empresa;
                    fDuplicata.vNm_empresa = rPed.Nm_empresa;
                    fDuplicata.vCd_clifor = rPed.Cd_clifor;
                    fDuplicata.vNm_clifor = rPed.Nm_clifor;
                    fDuplicata.vCd_endereco = rPed.Cd_endereco;
                    fDuplicata.vCd_historico = rContrato.Cd_historico_fix;
                    fDuplicata.vDs_historico = rContrato.Ds_historico_fix;
                    fDuplicata.vTp_duplicata = rContrato.Tp_duplicata_fix;
                    fDuplicata.vDs_tpduplicata = rContrato.Ds_tpduplicata_fix;
                    fDuplicata.vTp_mov = rContrato.Tp_mov_duplicata_fix;
                    fDuplicata.vTp_docto = rContrato.Tp_docto_fix.HasValue ? rContrato.Tp_docto_fix.Value.ToString() : string.Empty;
                    fDuplicata.vDs_tpdocto = rContrato.Ds_tpdocto_fix;
                    //Buscar tipo duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadTpDuplicata.Buscar(rContrato.Tp_duplicata_fix,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     null);
                    if(lTpDup[0].Id_configboleto.HasValue)
                    {
                        fDuplicata.vId_configBoleto = lTpDup[0].Id_configboletostr;
                        fDuplicata.vDs_configBoleto = lTpDup[0].Ds_configboleto;
                    }
                    //Buscar condicao pagamento
                    if(!string.IsNullOrEmpty(rContrato.Cd_condpgto_fix))
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCondPgto =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rContrato.Cd_condpgto_fix,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1, 
                                                                                      string.Empty,
                                                                                      null);
                        fDuplicata.vCd_condpgto = lCondPgto[0].Cd_condpgto;
                        fDuplicata.vDs_condpgto = lCondPgto[0].Ds_condpgto;
                        fDuplicata.vSt_comentrada = lCondPgto[0].St_comentrada;
                        fDuplicata.vCd_juro = lCondPgto[0].Cd_juro;
                        fDuplicata.vDs_juro = lCondPgto[0].Ds_juro;
                        fDuplicata.vTp_juro = lCondPgto[0].Tp_juro;

                        fDuplicata.vCd_moeda = rPed.Cd_moeda;
                        fDuplicata.vDs_moeda = rPed.Ds_moeda;
                        fDuplicata.vSigla_moeda = rPed.Sigla_moeda;

                        fDuplicata.vQt_dias_desdobro = lCondPgto[0].Qt_diasdesdobro;
                        fDuplicata.vQt_parcelas = lCondPgto[0].Qt_parcelas;
                        fDuplicata.vPc_jurodiario_atrazo = lCondPgto[0].Pc_jurodiario_atrazo;
                        fDuplicata.vSt_solicitardtvencto = lCondPgto[0].St_solicitardtvenctobool;

                        if(lCondPgto[0].Qt_parcelas < 1)
                        {
                            fDuplicata.vCd_portador = string.IsNullOrEmpty(rContrato.Cd_portador_fix) ? lCondPgto[0].Cd_portador : rContrato.Cd_portador_fix;
                            fDuplicata.vDs_portador = string.IsNullOrEmpty(rContrato.Ds_portador_fix) ? lCondPgto[0].Ds_portador : rContrato.Ds_portador_fix;
                            fDuplicata.vCd_contagerliq = rContrato.Cd_contager_fix;
                        }
                    }
                    fDuplicata.vNr_docto = "0";
                    fDuplicata.vDt_emissao = rFixacao.Dt_fixacaostr;
                    fDuplicata.vVl_documento = rFixacao.Vl_financeiro;
                    if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rFixacao.rDup = fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                        if((rFixacao.Vl_financeiro - Math.Round(rFixacao.Vl_royalties_declarado, 2) - 
                                                     Math.Round(rFixacao.Vl_royalties_testado, 2)) < rFixacao.rDup.cVl_adiantamento)
                            throw new Exception("O valor financeiro da fixação é menor que o valor do adiantamento que esta sendo devolvido,\r\n"+
                                                "pois existem royalties a serem retidos sobre o financeiro.\r\n"+
                                                "Valor adiantamento possivel para devolução: " + (rFixacao.Vl_financeiro - 
                                                                                                   Math.Round(rFixacao.Vl_royalties_declarado, 2) - 
                                                                                                   Math.Round(rFixacao.Vl_royalties_testado, 2)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true))); 
                        rFixacao.Vl_adiantamento = rFixacao.rDup.cVl_adiantamento;
                    }
                    else
                        throw new Exception("Obrigatorio informar financeiro para gravar fixação.");
                }
            }
            else
                throw new Exception("Obrigatorio configurar dados financeiros da fixação no cadastro do contrato Nº " + rPed.Nr_contratostr + ".");
            #endregion           
        }   
    }
}
