using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using Utils;
using NumeroNota;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaDados.Fiscal;
using CamadaDados.Graos;

namespace Proc_Commoditties
{
    public class TProcessaDevAquisicao
    {
        public static TList_RegLanDuplicata Gera_Financeiro(TRegistro_Transf_X_Contrato PedTransf,
                                                            decimal Valor,
                                                            DateTime? Dt_emissao,
                                                            string Origem_Destino)
        {
            TList_RegLanDuplicata Duplicata = new TList_RegLanDuplicata();

            if (PedTransf != null)
            {
                TRegistro_Pedido Pedido = TCN_Pedido.Busca_Registro_Pedido(PedTransf.Nr_pedido.ToString(), null);

                TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + PedTransf.Nr_pedido.ToString() + ")"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "=",
                            vVL_Busca = Origem_Destino.Trim().ToUpper().Equals("D") ? "'NO'" : "'DV'"
                        }
                    }, 0, string.Empty);

                if (lPedFiscal.Count > 0)
                {
                    if (!string.IsNullOrEmpty(lPedFiscal[0].Tp_duplicata))
                    {
                        TList_CadMovimentacao List_Movimentacao = new TCD_CadMovimentacao().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_movimentacao",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lPedFiscal[0].Cd_movtostring + "'"
                                }
                            }, 1, string.Empty);

                        TList_CadCondPgto List_CondPagamento = TCN_CadCondPgto.Buscar(Pedido.CD_CondPGTO,
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
                        if (List_CondPagamento.Count > 0)
                            List_CondPagamento[0].lCondPgto_X_Parcelas = TCN_CadCondPgto_X_Parcelas.Buscar(List_CondPagamento[0].Cd_condpgto, null);

                        TRegistro_LanDuplicata Reg_Duplicata = new TRegistro_LanDuplicata();
                        TList_CadTpDuplicata List_TPDuplicata = TCN_CadTpDuplicata.Buscar(lPedFiscal[0].Tp_duplicata, string.Empty, string.Empty, null);
                        if ((lPedFiscal[0].ST_Devolucao.Trim().ToUpper() != "S") &&
                            (!List_CondPagamento[0].St_solicitardtvenctobool) &&
                            (List_CondPagamento[0].lCondPgto_X_Parcelas.Count > 0) &&
                            (List_Movimentacao[0].cd_historico.Trim() != string.Empty))
                        {
                            Reg_Duplicata.Cd_empresa = Pedido.CD_Empresa.Trim();
                            Reg_Duplicata.Nm_empresa = Pedido.Nm_Empresa.Trim();
                            Reg_Duplicata.Cd_clifor = Pedido.CD_Clifor.Trim();
                            Reg_Duplicata.Nm_clifor = Pedido.NM_Clifor.Trim();
                            Reg_Duplicata.Cd_endereco = Pedido.CD_Endereco.Trim();
                            Reg_Duplicata.Ds_endereco = Pedido.DS_Endereco.Trim();

                            Reg_Duplicata.Cd_historico = List_Movimentacao[0].cd_historico.Trim();
                            Reg_Duplicata.Ds_historico = List_Movimentacao[0].ds_historico.Trim();

                            Reg_Duplicata.Tp_duplicata = lPedFiscal[0].Tp_duplicata;
                            Reg_Duplicata.Ds_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
                            Reg_Duplicata.Tp_mov = lPedFiscal[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                          lPedFiscal[0].Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                            Reg_Duplicata.Tp_docto = lPedFiscal[0].Tp_docto.HasValue ? lPedFiscal[0].Tp_docto.Value : decimal.Zero;
                            Reg_Duplicata.Ds_tpdocto = lPedFiscal[0].Ds_tpdocto;

                            Reg_Duplicata.Cd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                            Reg_Duplicata.Ds_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                            Reg_Duplicata.St_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                            Reg_Duplicata.Cd_juro = List_CondPagamento[0].Cd_juro.Trim();
                            Reg_Duplicata.Ds_juro = List_CondPagamento[0].Ds_juro.Trim();
                            Reg_Duplicata.Tp_juro = List_CondPagamento[0].Tp_juro.Trim();

                            Reg_Duplicata.Cd_moeda = Pedido.Cd_moeda.Trim();
                            Reg_Duplicata.Ds_moeda = Pedido.Ds_moeda.Trim();
                            Reg_Duplicata.Sigla_moeda = Pedido.Sigla.Trim();
                            Reg_Duplicata.Qt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                            Reg_Duplicata.Qt_parcelas = List_CondPagamento[0].Qt_parcelas;
                            Reg_Duplicata.Pc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                            Reg_Duplicata.Cd_portador = List_CondPagamento[0].Cd_portador.Trim();
                            Reg_Duplicata.Ds_portador = List_CondPagamento[0].Ds_portador.Trim();
                            Reg_Duplicata.Nr_docto = string.Empty;
                            Reg_Duplicata.Dt_emissao = Dt_emissao;
                            Reg_Duplicata.Vl_documento = Valor;
                            Reg_Duplicata.Vl_documento_padrao = Valor;

                            decimal vl_saldoadto = TCN_LanAdiantamento.Buscar(string.Empty,
                                                                              Pedido.CD_Empresa.Trim(), 
                                                                              Pedido.CD_Clifor.Trim(), 
                                                                              string.Empty,
                                                                              Pedido.TP_Movimento.Trim().ToUpper().Equals("E") ? "'C'" : "'R'",
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              decimal.Zero,
                                                                              decimal.Zero,
                                                                              false,
                                                                              false,
                                                                              true,
                                                                              string.Empty,
                                                                              false,
                                                                              true,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              null).Sum(p=> p.Vl_total_devolver);

                            if (Reg_Duplicata.Vl_documento_padrao > 0)
                                if (Reg_Duplicata.Vl_documento_padrao > vl_saldoadto)
                                    Reg_Duplicata.cVl_adiantamento = vl_saldoadto;
                                else
                                    Reg_Duplicata.cVl_adiantamento = Reg_Duplicata.Vl_documento_padrao;
                            else
                                Reg_Duplicata.cVl_adiantamento = 0;

                            Reg_Duplicata.Parcelas = TCN_LanDuplicata.calcularParcelas(Reg_Duplicata, null);

                        }
                        else
                        {

                            using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                            {
                                fDuplicata.vNr_pedido = null;
                                fDuplicata.vSt_notafiscal = true;
                                fDuplicata.vCd_empresa = Pedido.CD_Empresa.Trim();
                                fDuplicata.vNm_empresa = Pedido.Nm_Empresa.Trim();
                                fDuplicata.vCd_clifor = Pedido.CD_Clifor.Trim();
                                fDuplicata.vNm_clifor = Pedido.NM_Clifor.Trim();
                                fDuplicata.vCd_endereco = Pedido.CD_Endereco.Trim();
                                fDuplicata.vDs_endereco = Pedido.DS_Endereco.Trim();
                                if (List_Movimentacao.Count > 0)
                                {
                                    fDuplicata.vCd_historico = List_Movimentacao[0].cd_historico;
                                    fDuplicata.vDs_historico = List_Movimentacao[0].ds_historico;
                                }

                                fDuplicata.vTp_duplicata = lPedFiscal[0].Tp_duplicata;
                                fDuplicata.vDs_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
                                fDuplicata.vTp_mov = lPedFiscal[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                              lPedFiscal[0].Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                                fDuplicata.vTp_docto = lPedFiscal[0].Tp_doctostr;
                                fDuplicata.vDs_tpdocto = lPedFiscal[0].Ds_tpdocto;
                                if (List_TPDuplicata[0].Id_configboleto.HasValue)
                                {
                                    fDuplicata.vId_configBoleto = List_TPDuplicata[0].Id_configboletostr;
                                    fDuplicata.vDs_configBoleto = List_TPDuplicata[0].Ds_configboleto;
                                }
                                if (List_CondPagamento.Count > 0)
                                {
                                    fDuplicata.vCd_condpgto = List_CondPagamento[0].Cd_condpgto.Trim();
                                    fDuplicata.vDs_condpgto = List_CondPagamento[0].Ds_condpgto.Trim();
                                    fDuplicata.vSt_comentrada = List_CondPagamento[0].St_comentrada.Trim();
                                    fDuplicata.vCd_juro = List_CondPagamento[0].Cd_juro.Trim();
                                    fDuplicata.vDs_juro = List_CondPagamento[0].Ds_juro.Trim();
                                    fDuplicata.vTp_juro = List_CondPagamento[0].Tp_juro.Trim();

                                    fDuplicata.vCd_moeda = Pedido.Cd_moeda;
                                    fDuplicata.vDs_moeda = Pedido.Ds_moeda;
                                    fDuplicata.vSigla_moeda = Pedido.Sigla;

                                    fDuplicata.vQt_dias_desdobro = List_CondPagamento[0].Qt_diasdesdobro;
                                    fDuplicata.vQt_parcelas = List_CondPagamento[0].Qt_parcelas;
                                    fDuplicata.vPc_jurodiario_atrazo = List_CondPagamento[0].Pc_jurodiario_atrazo;
                                    fDuplicata.vCd_portador = List_CondPagamento[0].Cd_portador.Trim();
                                    fDuplicata.vDs_portador = List_CondPagamento[0].Ds_portador.Trim();
                                    fDuplicata.vSt_solicitardtvencto = List_CondPagamento[0].St_solicitardtvenctobool;
                                }
                                fDuplicata.vNr_docto = "0";
                                fDuplicata.vDt_emissao = Dt_emissao.HasValue ? Dt_emissao.Value.ToString("dd/MM/yyyy") : string.Empty;
                                fDuplicata.vVl_documento = Valor;

                                if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    Reg_Duplicata = (fDuplicata.dsDuplicata[0] as TRegistro_LanDuplicata);
                                else
                                    throw new Exception("Obrigatório informar financeiro.");
                            }
                        }
                        Duplicata.Add(Reg_Duplicata);
                        return Duplicata;
                    }
                    return Duplicata;
                }
            }
            return Duplicata;
        }

        public static TRegistro_DevAquisicao ProcessarDevAquisicao(string Cd_empresa,
                                                                   string Cd_produto,
                                                                   decimal Quantidade)
        {
            using (TFDevAquisicao fDevAquisicao = new TFDevAquisicao())
            {
                fDevAquisicao.pCd_empresa = Cd_empresa;
                fDevAquisicao.pCd_produto = Cd_produto;
                fDevAquisicao.pQuantidade = Quantidade;
                if (fDevAquisicao.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (fDevAquisicao.rDevAquisicao != null)
                    {
                        TList_LanFat_ComplementoDevolucao Devolucao = new TList_LanFat_ComplementoDevolucao();
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Empresa;
                            fCompDevol.Nr_pedido = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].Nr_pedido.ToString();
                            fCompDevol.Cd_produto = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].Cd_produto;
                            fCompDevol.Cd_clifor = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Clifor;

                            fCompDevol.Tp_operacao = "D";
                            fCompDevol.Tp_movimento = "E";
                            fCompDevol.Quantidade = fDevAquisicao.rDevAquisicao.Quantidade;
                            fCompDevol.Valor = fDevAquisicao.rDevAquisicao.Vl_subtotal_origem;

                            if (fCompDevol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                fDevAquisicao.rDevAquisicao.Devolucao = fCompDevol.ListaCompDev;

                                #region Nota Fiscal Origem
                                //Buscar registro contrato de origem
                                fDevAquisicao.rDevAquisicao.Contrato_Origem =
                                    CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                                       fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].NR_Contrato.ToString(),
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
                                                                                       null)[0];

                                TList_CadCFGPedidoFiscal lSerieOrigem = new TCD_CadCFGPedidoFiscal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = "+ fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].Nr_pedido.ToString() +")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'DV'"
                                        }
                                    }, 1, string.Empty);

                                if (lSerieOrigem.Count > 0)
                                {
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Nr_serie = lSerieOrigem[0].Nr_serie;
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Ds_serienf = lSerieOrigem[0].Ds_serienf;
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Tp_movimento = "S";
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Tp_nota = "P";
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Dt_emissao = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Dt_saient = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                    if (!lSerieOrigem[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S"))
                                    {
                                        using (TFNumero_Nota Numero_Nota = new TFNumero_Nota())
                                        {
                                            Numero_Nota.Text = "Dados Nota Fiscal Devolução";
                                            Numero_Nota.pCd_empresa = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Empresa;
                                            Numero_Nota.pNm_empresa = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].NM_Empresa;
                                            Numero_Nota.pCd_clifor = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Clifor;
                                            Numero_Nota.pNm_clifor = fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].NM_Clifor;
                                            Numero_Nota.pNr_serie = lSerieOrigem[0].Nr_serie;
                                            Numero_Nota.pDs_serie = lSerieOrigem[0].Ds_serienf;
                                            Numero_Nota.pCd_modelo = lSerieOrigem[0].Cd_modelo;
                                            Numero_Nota.pTp_movimento = "S";
                                            Numero_Nota.pTp_nota = "P";
                                            Numero_Nota.pDt_emissao = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                            Numero_Nota.pDt_saient = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                            Numero_Nota.pCd_movto = fDevAquisicao.rDevAquisicao.rNfOrigem.Cd_movimentacaostring;
                                            Numero_Nota.pCd_cmi = fDevAquisicao.rDevAquisicao.rNfOrigem.Cd_cmistring;
                                            //Buscar tipo pessoa  do clifor
                                            object obj_pessoaorigem = new TCD_CadClifor().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Clifor + "'"
                                                    }
                                                }, "a.tp_pessoa");
                                            if (obj_pessoaorigem != null)
                                                Numero_Nota.pTp_pessoa = obj_pessoaorigem.ToString();
                                            //Buscar insc. estadual origem
                                            object obj_inscorigem = new TCD_CadEndereco().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_Origem.Cd_clifor.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_endereco",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_Origem.Cd_endereco.Trim() + "'"
                                                    }
                                                }, "a.insc_estadual");
                                            if (obj_inscorigem != null)
                                                Numero_Nota.pInsc_estadual = obj_inscorigem.ToString();
                                            if (Numero_Nota.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            {
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Nr_serie = Numero_Nota.pNr_serie;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Cd_modelo = Numero_Nota.pCd_modelo;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Tp_movimento = Numero_Nota.pTp_movimento;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Tp_nota = Numero_Nota.pTp_nota;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Dt_emissao = Numero_Nota.pDt_emissao;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Dt_saient = Numero_Nota.pDt_saient;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.St_sequenciaauto = false;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Obsfiscal = Numero_Nota.pDs_obsfiscal;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Dadosadicionais = Numero_Nota.pDs_dadosadic;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Chave_acesso_nfe = Numero_Nota.pChave_Acesso_NFe;
                                                fDevAquisicao.rDevAquisicao.rNfOrigem.Nr_notafiscal = decimal.Parse(Numero_Nota.pNr_notafiscal);
                                                if (fDevAquisicao.rDevAquisicao.rNfOrigem.Cd_cmistring.Trim() != Numero_Nota.pCd_cmi.Trim())
                                                {
                                                    CamadaDados.Fiscal.TRegistro_CadCMI rCmi =
                                                        CamadaNegocio.Fiscal.TCN_CadCMI.Busca(Numero_Nota.pCd_cmi,
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
                                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                                    {
                                                        St_compdevimposto = rCmi.St_compdevimposto,
                                                        St_complementar = rCmi.St_complementar,
                                                        St_devolucao = rCmi.St_devolucao,
                                                        St_geraestoque = rCmi.St_geraestoque,
                                                        St_mestra = rCmi.St_mestra,
                                                        St_simplesremessa = rCmi.St_simplesremessa,
                                                        St_retorno = rCmi.St_retorno
                                                    });
                                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Cd_cmistring = Numero_Nota.pCd_cmi;
                                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Ds_cmi = rCmi.Ds_cmi;
                                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Tp_duplicata = rCmi.Tp_duplicata;
                                                    fDevAquisicao.rDevAquisicao.rNfOrigem.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                                }
                                            }
                                            else
                                                throw new Exception("Obrigatorio informar numero da nota fiscal de origem.");
                                        }
                                    }
                                    else
                                        fDevAquisicao.rDevAquisicao.rNfOrigem.St_sequenciaauto = true;
                                }
                                else
                                    throw new Exception("Não existe configuração fiscal de DEVOLUÇÃO para o contrato de origem " +
                                        fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].NR_Contrato.ToString() + ".");
                                #endregion

                                #region Nota Fiscal Destino
                                //Buscar pedido destino
                                fDevAquisicao.rDevAquisicao.Contrato_Destino =
                                    CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                                       fDevAquisicao.rDevAquisicao.Contrato_compra[0].NR_Contrato.ToString(),
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
                                                                                       null)[0];
                                TList_CadCFGPedidoFiscal lSerieDestino = new TCD_CadCFGPedidoFiscal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = " + fDevAquisicao.rDevAquisicao.Contrato_compra[0].Nr_pedido.ToString() + ")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'NO'"
                                        }
                                    }, 1, string.Empty);

                                if (lSerieDestino.Count > 0)
                                {
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Nr_serie = lSerieDestino[0].Nr_serie;
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Ds_serienf = lSerieDestino[0].Ds_serienf;
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Tp_movimento = "E";
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Tp_nota = "P";
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Dt_emissao = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                    fDevAquisicao.rDevAquisicao.rNfDestino.Dt_saient = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                    if (!lSerieDestino[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S"))
                                    {
                                        using (TFNumero_Nota Numero_Nota_Destino = new TFNumero_Nota())
                                        {
                                            Numero_Nota_Destino.Text = "Dados Nota Fiscal Entrada";
                                            Numero_Nota_Destino.pCd_empresa = fDevAquisicao.rDevAquisicao.Contrato_compra[0].CD_Empresa;
                                            Numero_Nota_Destino.pNm_empresa = fDevAquisicao.rDevAquisicao.Contrato_compra[0].NM_Empresa;
                                            Numero_Nota_Destino.pCd_clifor = fDevAquisicao.rDevAquisicao.Contrato_compra[0].CD_Clifor;
                                            Numero_Nota_Destino.pNm_clifor = fDevAquisicao.rDevAquisicao.Contrato_compra[0].NM_Clifor;
                                            Numero_Nota_Destino.pNr_serie = lSerieDestino[0].Nr_serie;
                                            Numero_Nota_Destino.pDs_serie = lSerieDestino[0].Ds_serienf;
                                            Numero_Nota_Destino.pCd_modelo = lSerieDestino[0].Cd_modelo;
                                            Numero_Nota_Destino.pTp_movimento = "E";
                                            Numero_Nota_Destino.pTp_nota = string.Empty;
                                            Numero_Nota_Destino.pDt_emissao = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                            Numero_Nota_Destino.pDt_saient = fDevAquisicao.rDevAquisicao.Dt_lancto;
                                            Numero_Nota_Destino.pCd_movto = fDevAquisicao.rDevAquisicao.rNfDestino.Cd_movimentacaostring;
                                            Numero_Nota_Destino.pCd_cmi = fDevAquisicao.rDevAquisicao.rNfDestino.Cd_cmistring;
                                            //Buscar tipo pessoa  do clifor
                                            object obj_pessoadestino = new TCD_CadClifor().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_compra[0].CD_Clifor + "'"
                                                    }
                                                }, "a.tp_pessoa");
                                            if (obj_pessoadestino != null)
                                                Numero_Nota_Destino.pTp_pessoa = obj_pessoadestino.ToString();
                                            //Buscar insc. estadual origem
                                            object obj_inscdestino = new TCD_CadEndereco().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_Destino.Cd_clifor.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_endereco",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + fDevAquisicao.rDevAquisicao.Contrato_Destino.Cd_endereco.Trim() + "'"
                                                    }
                                                }, "a.insc_estadual");
                                            if (obj_inscdestino != null)
                                                Numero_Nota_Destino.pInsc_estadual = obj_inscdestino.ToString();
                                            if (Numero_Nota_Destino.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            {
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Nr_serie = Numero_Nota_Destino.pNr_serie;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Cd_modelo = Numero_Nota_Destino.pCd_modelo;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Tp_movimento = Numero_Nota_Destino.pTp_movimento;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Tp_nota = Numero_Nota_Destino.pTp_nota;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Dt_emissao = Numero_Nota_Destino.pDt_emissao;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Dt_saient = Numero_Nota_Destino.pDt_saient;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.St_sequenciaauto = false;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Obsfiscal = Numero_Nota_Destino.pDs_obsfiscal;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Dadosadicionais = Numero_Nota_Destino.pDs_dadosadic;
                                                fDevAquisicao.rDevAquisicao.rNfDestino.Chave_acesso_nfe = Numero_Nota_Destino.pChave_Acesso_NFe;
                                                if (!string.IsNullOrEmpty(Numero_Nota_Destino.pNr_notafiscal))
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Nr_notafiscal = decimal.Parse(Numero_Nota_Destino.pNr_notafiscal);
                                                else
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Nr_notafiscal = null;
                                                if (fDevAquisicao.rDevAquisicao.rNfDestino.Cd_cmistring.Trim() != Numero_Nota_Destino.pCd_cmi.Trim())
                                                {
                                                    CamadaDados.Fiscal.TRegistro_CadCMI rCmi =
                                                        CamadaNegocio.Fiscal.TCN_CadCMI.Busca(Numero_Nota_Destino.pCd_cmi,
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
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                                    {
                                                        St_compdevimposto = rCmi.St_compdevimposto,
                                                        St_complementar = rCmi.St_complementar,
                                                        St_devolucao = rCmi.St_devolucao,
                                                        St_geraestoque = rCmi.St_geraestoque,
                                                        St_mestra = rCmi.St_mestra,
                                                        St_simplesremessa = rCmi.St_simplesremessa,
                                                        St_retorno = rCmi.St_retorno
                                                    });
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Cd_cmistring = Numero_Nota_Destino.pCd_cmi;
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Ds_cmi = rCmi.Ds_cmi;
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Tp_duplicata = rCmi.Tp_duplicata;
                                                    fDevAquisicao.rDevAquisicao.rNfDestino.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                                }
                                            }
                                            else
                                                throw new Exception("Obrigatorio informar numero da nota fiscal de destino.");
                                        }
                                    }
                                    else
                                        fDevAquisicao.rDevAquisicao.rNfDestino.St_sequenciaauto = true;
                                }
                                else
                                    throw new Exception("Não existe configuração fiscal NORMAL para o contrato de destino " +
                                        fDevAquisicao.rDevAquisicao.Contrato_compra[0].NR_Contrato.ToString() + ".");
                                #endregion

                                fDevAquisicao.rDevAquisicao.Duplicata_Origem = Gera_Financeiro(fDevAquisicao.rDevAquisicao.Contrato_devolucao[0], 
                                                                                               fDevAquisicao.rDevAquisicao.Vl_subtotal_origem,
                                                                                               fDevAquisicao.rDevAquisicao.Dt_lancto, 
                                                                                               "O");
                                fDevAquisicao.rDevAquisicao.Duplicata_Destino = Gera_Financeiro(fDevAquisicao.rDevAquisicao.Contrato_compra[0], 
                                                                                                fDevAquisicao.rDevAquisicao.Vl_subtotal_destino,
                                                                                                fDevAquisicao.rDevAquisicao.Dt_lancto, 
                                                                                                "D");

                                if ((fDevAquisicao.rDevAquisicao.Duplicata_Origem != null) && (fDevAquisicao.rDevAquisicao.Duplicata_Destino != null))
                                {
                                    fDevAquisicao.rDevAquisicao.Contrato_Origem.Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                            "where x.cfg_pedido = a.cfg_pedido " +
                                                            "and x.nr_pedido = " + fDevAquisicao.rDevAquisicao.Contrato_Origem.Nr_pedido.ToString() + ")"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.tp_fiscal",
                                                vOperador = "=",
                                                vVL_Busca = "'DV'"
                                            }
                                        }, 1, string.Empty);
                                    fDevAquisicao.rDevAquisicao.Reg_Clifor_Origem = TCN_CadClifor.Busca_Clifor_Codigo(fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Clifor, null);
                                    fDevAquisicao.rDevAquisicao.Reg_Produto_Origem = TCN_CadProduto.Busca_Produto_Codigo(fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].Cd_produto, null);
                                    fDevAquisicao.rDevAquisicao.Reg_Empresa_Origem = TCN_CadEmpresa.Busca(fDevAquisicao.rDevAquisicao.Contrato_devolucao[0].CD_Empresa,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   null)[0];
                                    fDevAquisicao.rDevAquisicao.Contrato_Destino.Pedido_Fiscal = new TCD_CadCFGPedidoFiscal().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                            "where x.cfg_pedido = a.cfg_pedido "+
                                                            "and x.nr_pedido = " + fDevAquisicao.rDevAquisicao.Contrato_compra[0].Nr_pedido.ToString() + ")"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.tp_fiscal",
                                                vOperador = "=",
                                                vVL_Busca = "'NO'"
                                            }
                                        }, 1, string.Empty);
                                    fDevAquisicao.rDevAquisicao.Reg_Clifor_Destino = TCN_CadClifor.Busca_Clifor_Codigo(fDevAquisicao.rDevAquisicao.Contrato_compra[0].CD_Clifor, null);
                                    fDevAquisicao.rDevAquisicao.Reg_Produto_Destino = TCN_CadProduto.Busca_Produto_Codigo(fDevAquisicao.rDevAquisicao.Contrato_compra[0].Cd_produto, null);
                                    fDevAquisicao.rDevAquisicao.Reg_Empresa_Destino = TCN_CadEmpresa.Busca(fDevAquisicao.rDevAquisicao.Contrato_compra[0].CD_Empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null)[0];
                                    return fDevAquisicao.rDevAquisicao;
                                }
                                else
                                    throw new Exception("Verifique os dados das Duplicatas.");
                            }
                            else
                                throw new Exception("Obrigatório informar as notas a serem Devolvidas.");
                        }
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
    }
}
