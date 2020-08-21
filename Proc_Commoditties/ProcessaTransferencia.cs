using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using NumeroNota;

namespace Proc_Commoditties
{
    public class TProcessaTransferencia
    {
        public static void GerarTransferencia(CamadaDados.Graos.TRegistro_Transferencia rTransf)
        {
            rTransf.Reg_Clifor_Destino = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rTransf.Transf_X_Contrato_Destino[0].CD_Clifor, null);
            rTransf.Reg_Clifor_Origem = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rTransf.Transf_X_Contrato_Origem[0].CD_Clifor, null);

            using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
            {
                fCompDevol.Cd_empresa = rTransf.Transf_X_Contrato_Origem[0].CD_Empresa;
                fCompDevol.Nr_pedido = rTransf.Transf_X_Contrato_Origem[0].Nr_pedido.ToString();
                fCompDevol.Cd_produto = rTransf.Transf_X_Contrato_Origem[0].Cd_produto;
                fCompDevol.Cd_clifor = rTransf.Transf_X_Contrato_Origem[0].CD_Clifor;

                fCompDevol.Tp_operacao = "D";
                fCompDevol.Tp_movimento = "E";
                fCompDevol.Quantidade = rTransf.QTD_Transf;
                fCompDevol.Valor = rTransf.VL_Sub_Total_Origem;

                if (fCompDevol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rTransf.Complemento_Devolucao = fCompDevol.ListaCompDev;

                    #region Nota Fiscal Origem
                    //Buscar registro contrato de origem
                    rTransf.Contrato_Origem =
                        CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                           rTransf.Transf_X_Contrato_Origem[0].NR_Contrato.ToString(),
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
                        
                    rTransf.rNfOrigem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                    CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lSerieOrigem =
                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                        new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                    "where x.cfg_pedido = a.cfg_pedido "+
                                                    "and x.nr_pedido = "+ rTransf.Transf_X_Contrato_Origem[0].Nr_pedido.ToString() +")"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'DF'"//Devolução Fiscal, não movimenta estoque
                                    }
                                }, 1, string.Empty);

                    if (lSerieOrigem.Count > 0)
                    {
                        rTransf.rNfOrigem.Nr_serie = lSerieOrigem[0].Nr_serie;
                        rTransf.rNfOrigem.Ds_serienf = lSerieOrigem[0].Ds_serienf;
                        rTransf.rNfOrigem.Cd_modelo = lSerieOrigem[0].Cd_modelo;
                        rTransf.rNfOrigem.Cd_movimentacao = lSerieOrigem[0].Cd_movto;
                        rTransf.rNfOrigem.Cd_cmi = lSerieOrigem[0].Cd_cmi;
                        rTransf.rNfOrigem.Tp_movimento = "S";
                        rTransf.rNfOrigem.Tp_nota = "P";
                        rTransf.rNfOrigem.Dt_emissao = rTransf.DT_Lancto;
                        rTransf.rNfOrigem.Dt_saient = rTransf.DT_Lancto;
                        using (TFNumero_Nota Numero_Nota = new TFNumero_Nota())
                        {
                            Numero_Nota.Text = "Dados Nota Fiscal Devolução";
                            Numero_Nota.pCd_empresa = rTransf.Transf_X_Contrato_Origem[0].CD_Empresa;
                            Numero_Nota.pNm_empresa = rTransf.Transf_X_Contrato_Origem[0].NM_Empresa;
                            Numero_Nota.pCd_clifor = rTransf.Transf_X_Contrato_Origem[0].CD_Clifor;
                            Numero_Nota.pNm_clifor = rTransf.Transf_X_Contrato_Origem[0].NM_Clifor;
                            Numero_Nota.pNr_serie = lSerieOrigem[0].Nr_serie;
                            Numero_Nota.pDs_serie = lSerieOrigem[0].Ds_serienf;
                            Numero_Nota.pCd_modelo = lSerieOrigem[0].Cd_modelo;
                            Numero_Nota.pTp_movimento = "S";
                            Numero_Nota.pTp_nota = "P";
                            Numero_Nota.pDt_emissao = rTransf.DT_Lancto;
                            Numero_Nota.pDt_saient = rTransf.DT_Lancto;
                            Numero_Nota.pSt_sequenciaauto = lSerieOrigem[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                            Numero_Nota.pTp_pessoa = rTransf.Reg_Clifor_Origem.Tp_pessoa;
                            Numero_Nota.pCd_movto = rTransf.rNfOrigem.Cd_movimentacaostring;
                            Numero_Nota.pCd_cmi = rTransf.rNfOrigem.Cd_cmistring;
                            //Buscar insc. estadual origem
                            object obj_inscorigem = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rTransf.Contrato_Origem.Cd_clifor.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_endereco",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rTransf.Contrato_Origem.Cd_endereco.Trim() + "'"
                                            }
                                        }, "a.insc_estadual");
                            if (obj_inscorigem != null)
                                Numero_Nota.pInsc_estadual = obj_inscorigem.ToString();
                            if (Numero_Nota.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                rTransf.rNfOrigem.Nr_serie = Numero_Nota.pNr_serie;
                                rTransf.rNfOrigem.Cd_modelo = Numero_Nota.pCd_modelo;
                                rTransf.rNfOrigem.Tp_movimento = Numero_Nota.pTp_movimento;
                                rTransf.rNfOrigem.Tp_nota = Numero_Nota.pTp_nota;
                                rTransf.rNfOrigem.Dt_emissao = Numero_Nota.pDt_emissao;
                                rTransf.rNfOrigem.Dt_saient = Numero_Nota.pDt_saient;
                                rTransf.rNfOrigem.St_sequenciaauto = Numero_Nota.pSt_sequenciaauto; ;
                                rTransf.rNfOrigem.Obsfiscal = Numero_Nota.pDs_obsfiscal;
                                rTransf.rNfOrigem.Dadosadicionais = Numero_Nota.pDs_dadosadic;
                                rTransf.rNfOrigem.Chave_acesso_nfe = Numero_Nota.pChave_Acesso_NFe;
                                if (!string.IsNullOrEmpty(Numero_Nota.pNr_notafiscal))
                                    rTransf.rNfOrigem.Nr_notafiscal = decimal.Parse(Numero_Nota.pNr_notafiscal);
                                else
                                    rTransf.rNfOrigem.Nr_notafiscal = null;
                                if (rTransf.rNfOrigem.Cd_cmistring.Trim() != Numero_Nota.pCd_cmi.Trim())
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
                                    rTransf.rNfOrigem.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                    {
                                        St_compdevimposto = rCmi.St_compdevimposto,
                                        St_complementar = rCmi.St_complementar,
                                        St_devolucao = rCmi.St_devolucao,
                                        St_geraestoque = rCmi.St_geraestoque,
                                        St_mestra = rCmi.St_mestra,
                                        St_simplesremessa = rCmi.St_simplesremessa,
                                        St_retorno = rCmi.St_retorno
                                    });
                                    rTransf.rNfOrigem.Cd_cmistring = Numero_Nota.pCd_cmi;
                                    rTransf.rNfOrigem.Ds_cmi = rCmi.Ds_cmi;
                                    rTransf.rNfOrigem.Tp_duplicata = rCmi.Tp_duplicata;
                                    rTransf.rNfOrigem.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                }
                            }
                            else
                                throw new Exception("Obrigatorio informar numero da nota fiscal de origem.");
                        }
                    }
                    else
                        throw new Exception("Não existe configuração fiscal de TRANSFERENCIA para o contrato de origem " +
                            rTransf.Transf_X_Contrato_Origem[0].NR_Contrato.ToString() + ".");
                    #endregion

                    #region Nota Fiscal Destino
                    //Buscar pedido destino
                    rTransf.Contrato_Destino =
                        CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                           rTransf.Transf_X_Contrato_Destino[0].Nr_contratostr,
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

                    rTransf.rNfDestino = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                    CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lSerieDestino =
                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                        new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                    "where x.cfg_pedido = a.cfg_pedido "+
                                                    "and x.nr_pedido = " + rTransf.Transf_X_Contrato_Destino[0].Nr_pedido.ToString() + ")"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'TF'"
                                    }
                                }, 1, string.Empty);

                    if (lSerieDestino.Count > 0)
                    {
                        rTransf.rNfDestino.Nr_serie = lSerieDestino[0].Nr_serie;
                        rTransf.rNfDestino.Ds_serienf = lSerieDestino[0].Ds_serienf;
                        rTransf.rNfDestino.Cd_modelo = lSerieDestino[0].Cd_modelo;
                        rTransf.rNfDestino.Cd_movimentacao = lSerieDestino[0].Cd_movto;
                        rTransf.rNfDestino.Cd_cmi = lSerieDestino[0].Cd_cmi;
                        rTransf.rNfDestino.Tp_movimento = "E";
                        rTransf.rNfDestino.Dt_emissao = rTransf.DT_Lancto;
                        rTransf.rNfDestino.Dt_saient = rTransf.DT_Lancto;
                        using (TFNumero_Nota Numero_Nota_Destino = new TFNumero_Nota())
                        {
                            Numero_Nota_Destino.Text = "Dados Nota Fiscal Entrada";
                            Numero_Nota_Destino.pCd_empresa = rTransf.Transf_X_Contrato_Destino[0].CD_Empresa;
                            Numero_Nota_Destino.pNm_empresa = rTransf.Transf_X_Contrato_Destino[0].NM_Empresa;
                            Numero_Nota_Destino.pCd_clifor = rTransf.Transf_X_Contrato_Destino[0].CD_Clifor;
                            Numero_Nota_Destino.pNm_clifor = rTransf.Transf_X_Contrato_Destino[0].NM_Clifor;
                            Numero_Nota_Destino.pNr_serie = lSerieDestino[0].Nr_serie;
                            Numero_Nota_Destino.pDs_serie = lSerieDestino[0].Ds_serienf;
                            Numero_Nota_Destino.pCd_modelo = lSerieDestino[0].Cd_modelo;
                            Numero_Nota_Destino.pTp_movimento = "E";
                            Numero_Nota_Destino.pDt_emissao = rTransf.DT_Lancto;
                            Numero_Nota_Destino.pDt_saient = rTransf.DT_Lancto;
                            Numero_Nota_Destino.pSt_sequenciaauto = lSerieDestino[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                            Numero_Nota_Destino.pTp_pessoa = rTransf.Reg_Clifor_Destino.Tp_pessoa;
                            Numero_Nota_Destino.pCd_movto = rTransf.rNfDestino.Cd_movimentacaostring;
                            Numero_Nota_Destino.pCd_cmi = rTransf.rNfDestino.Cd_cmistring;
                            //Buscar insc. estadual origem
                            object obj_inscdestino = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rTransf.Contrato_Destino.Cd_clifor.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_endereco",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rTransf.Contrato_Destino.Cd_endereco.Trim() + "'"
                                            }
                                        }, "a.insc_estadual");
                            if (obj_inscdestino != null)
                                Numero_Nota_Destino.pInsc_estadual = obj_inscdestino.ToString();
                            Numero_Nota_Destino.pTp_nota = (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.validarST_Nota("E", Numero_Nota_Destino.pTp_pessoa, rTransf.Reg_Clifor_Destino.St_equiparado_pjbool, rTransf.Reg_Clifor_Destino.St_agropecuariabool).Equals(0) ? "P" : "T");
                            if (Numero_Nota_Destino.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                rTransf.rNfDestino.Nr_serie = Numero_Nota_Destino.pNr_serie;
                                rTransf.rNfDestino.Cd_modelo = Numero_Nota_Destino.pCd_modelo;
                                rTransf.rNfDestino.Tp_movimento = Numero_Nota_Destino.pTp_movimento;
                                rTransf.rNfDestino.Tp_nota = Numero_Nota_Destino.pTp_nota;
                                rTransf.rNfDestino.Dt_emissao = Numero_Nota_Destino.pDt_emissao;
                                rTransf.rNfDestino.Dt_saient = Numero_Nota_Destino.pDt_saient;
                                rTransf.rNfDestino.Obsfiscal = Numero_Nota_Destino.pDs_obsfiscal;
                                rTransf.rNfDestino.Dadosadicionais = Numero_Nota_Destino.pDs_dadosadic;
                                rTransf.rNfDestino.Chave_acesso_nfe = Numero_Nota_Destino.pChave_Acesso_NFe;
                                if (!string.IsNullOrEmpty(Numero_Nota_Destino.pNr_notafiscal))
                                    rTransf.rNfDestino.Nr_notafiscal = decimal.Parse(Numero_Nota_Destino.pNr_notafiscal);
                                else
                                    rTransf.rNfDestino.Nr_notafiscal = null;
                                rTransf.rNfDestino.St_sequenciaauto = Numero_Nota_Destino.pSt_sequenciaauto;
                                if (rTransf.rNfDestino.Cd_cmistring.Trim() != Numero_Nota_Destino.pCd_cmi.Trim())
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
                                    rTransf.rNfDestino.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                    {
                                        St_compdevimposto = rCmi.St_compdevimposto,
                                        St_complementar = rCmi.St_complementar,
                                        St_devolucao = rCmi.St_devolucao,
                                        St_geraestoque = rCmi.St_geraestoque,
                                        St_mestra = rCmi.St_mestra,
                                        St_simplesremessa = rCmi.St_simplesremessa,
                                        St_retorno = rCmi.St_retorno
                                    });
                                    rTransf.rNfDestino.Cd_cmistring = Numero_Nota_Destino.pCd_cmi;
                                    rTransf.rNfDestino.Ds_cmi = rCmi.Ds_cmi;
                                    rTransf.rNfDestino.Tp_duplicata = rCmi.Tp_duplicata;
                                    rTransf.rNfDestino.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                }
                            }
                            else
                                throw new Exception("Obrigatorio informar numero da nota fiscal de destino.");
                        }
                    }
                    else
                        throw new Exception("Não existe configuração fiscal NORMAL para o contrato de destino " +
                            rTransf.Transf_X_Contrato_Destino[0].NR_Contrato.ToString() + ".");
                    #endregion

                    rTransf.Duplicata_Origem = TProcessaDevAquisicao.Gera_Financeiro(rTransf.Transf_X_Contrato_Origem[0],
                                                                                                   rTransf.VL_Sub_Total_Origem,
                                                                                                   rTransf.DT_Lancto,
                                                                                                   "O");
                    rTransf.Duplicata_Destino = TProcessaDevAquisicao.Gera_Financeiro(rTransf.Transf_X_Contrato_Destino[0],
                                                                                                    rTransf.VL_Sub_Total_Destino,
                                                                                                    rTransf.DT_Lancto,
                                                                                                    "D");

                    if ((rTransf.Duplicata_Origem != null) && (rTransf.Duplicata_Destino != null))
                    {
                        rTransf.Contrato_Origem.Pedido_Fiscal = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                        "and x.nr_pedido = " + rTransf.Contrato_Origem.Nr_pedido.ToString() + ")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'DF'"
                                        }
                                    }, 1, string.Empty);
                        rTransf.Reg_Produto_Origem =
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo(rTransf.Transf_X_Contrato_Origem[0].Cd_produto, null);
                        rTransf.Reg_Empresa_Origem =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rTransf.Transf_X_Contrato_Origem[0].CD_Empresa,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       null)[0];
                        CamadaDados.Faturamento.Pedido.TList_Pedido List_Contrato_Destino = new CamadaDados.Faturamento.Pedido.TList_Pedido();

                        rTransf.Contrato_Destino.Pedido_Fiscal = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                        "where x.cfg_pedido = a.cfg_pedido "+
                                                        "and x.nr_pedido = " + rTransf.Transf_X_Contrato_Destino[0].Nr_pedido.ToString() + ")"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'TF'"
                                        }
                                    }, 1, string.Empty);
                        rTransf.Reg_Produto_Destino =
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo(rTransf.Transf_X_Contrato_Destino[0].Cd_produto, null);
                        rTransf.Reg_Empresa_Destino =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rTransf.Transf_X_Contrato_Destino[0].CD_Empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null)[0];
                    }
                    else
                        throw new Exception("Verifique os dados das Duplicatas.");
                }
                else
                    throw new Exception("Obrigatório informar as notas a serem Devolvidas.");
            }
        }

        public static CamadaDados.Graos.TRegistro_Transferencia ProcessarTransferencia()
        {
            using (TFTransfContrato fTransf = new TFTransfContrato())
            {
                if (fTransf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return fTransf.rTransf;
                else
                    return null;
            }
        }
    }
}
