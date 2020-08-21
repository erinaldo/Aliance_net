using System;
using System.Collections.Generic;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Balanca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Estoque.Cadastros;
using System.Linq;
using NumeroNota;

namespace Proc_Commoditties
{
    public class ProcessaAplicacao
    {
        //metodos auxiliares
        private static decimal CalcularFrete(TRegistro_LanFaturamento_Item rItem)
        {
            return decimal.Zero;
            /*if (rItem != null)
            {
                //Buscar dados do pedido para calcular frete
                CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                    new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = rItem.Nr_pedido.ToString()
                        }
                    }, 0, string.Empty);
                if (lPed.Count > 0)
                {
                    if (lPed[0].Vl_frete > decimal.Zero)
                    {
                        if (lPed[0].Tp_vlfrete.Trim().ToUpper().Equals("T"))
                        {
                            //Buscar codigo da unidade Tonelada
                            string Unidade_Tonelada = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("CD_UNIDADE_TONELADA", null);
                            if (!string.IsNullOrEmpty(Unidade_Tonelada))
                                return Math.Round((Math.Round(lPed[0].Vl_frete, 2) * Math.Round(CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(rItem.Cd_unidEst, Unidade_Tonelada, rItem.Quantidade_estoque, null), 2)), 2);
                            else
                                throw new Exception("Necessario configurar unidade tonelada no cadastro de configurações gerenciais.");
                        }
                        else
                            return decimal.Zero;
                    }
                    else
                        return decimal.Zero;
                }
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;*/
        }

        public static string BuscarObsMov(string Obs_DadosAdic, 
                                          string Cd_movimentacao,
                                          bool St_dentroestado)
        {
            if ((!string.IsNullOrEmpty(Obs_DadosAdic)) && 
                (!string.IsNullOrEmpty(Cd_movimentacao)))
            {
                //Buscar movimentacao comercial
                CamadaDados.Fiscal.TList_CadMovimentacao lMov =
                    CamadaNegocio.Fiscal.TCN_CadMovimentacao.Busca(Cd_movimentacao,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   null);
                if(lMov.Count > 0)
                    if (Obs_DadosAdic.Trim().ToUpper().Equals("F"))
                    {
                        //Buscar observacao fiscal
                        object obj = new CamadaDados.Fiscal.TCD_CadObservacaoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "cd_observacaofiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (St_dentroestado ? lMov[0].cd_obsfiscal_dentroestado.Trim() : lMov[0].cd_obsfiscal_foraestado.Trim()) + "'"
                                }
                            }, "ds_observacaofiscal");
                        if (obj != null)
                            return obj.ToString();
                        else
                            return string.Empty;
                    }
                    else if (Obs_DadosAdic.Trim().ToUpper().Equals("D"))
                    {
                        //Buscar dados adicionais
                        object obj = new CamadaDados.Fiscal.TCD_CadObservacaoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "cd_observacaofiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (St_dentroestado ? lMov[0].cd_dadosAdicionais_dentroestado.Trim() : lMov[0].cd_dadosAdicionais_foraestado.Trim()) + "'"
                                }
                            }, "ds_observacaofiscal");
                        if (obj != null)
                            return obj.ToString();
                        else
                            return string.Empty;
                    }
                    else
                        return string.Empty;
                        else
                return string.Empty;
            }
            else
                return string.Empty;
        }
        
        private static void PreencherNotaFiscal(ref TRegistro_LanFaturamento regFaturamento, 
                                                TRegistro_LanPesagemGraos rTicketAplicar,
                                                bool St_notaunica)
        {
            TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(new TpBusca[]
            {
                new TpBusca
                {
                    vNM_Campo = string.Empty,
                    vOperador = "EXISTS",
                    vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                "where x.cfg_pedido = a.cfg_pedido "+
                                "and x.nr_pedido = " + rTicketAplicar.Nr_pedidostr + ")"
                },
                new TpBusca
                {
                    vNM_Campo = "a.tp_fiscal",
                    vOperador = "=",
                    vVL_Busca = rTicketAplicar.Tp_movcontrato.Trim().ToUpper().Equals(rTicketAplicar.Tp_movimento.Trim().ToUpper()) ? "'NO'" : "'DV'"
                }
            }, 1, string.Empty);



            if (lPedFiscal.Count < 1)
                throw new Exception("Falta configuração fiscal " + (rTicketAplicar.Tp_movcontrato.Trim().ToUpper().Equals(rTicketAplicar.Tp_movimento.Trim().ToUpper()) ? "NORMAL" : "DEVOLUÇÃO") + " para o contrato.");
            else
                if (string.IsNullOrEmpty(lPedFiscal[0].Cd_modelo))
                    throw new Exception("Configuração de modelo de nota é obriatório para o tipo de pedido "+lPedFiscal[0].Cfg_pedido.ToString());

            //Objeto Faturamento   
            regFaturamento = new TRegistro_LanFaturamento();
            regFaturamento.Cd_empresa = rTicketAplicar.Cd_empresa;
            regFaturamento.Cd_clifor = rTicketAplicar.CD_Contratante;
            regFaturamento.Nm_clifor = rTicketAplicar.NM_Contratante;
            regFaturamento.Cd_endereco = rTicketAplicar.CD_EndContratante;
            regFaturamento.Cd_cmi = lPedFiscal[0].Cd_cmi;
            regFaturamento.Cminf = new TList_RegLanFaturamento_CMI() { new TRegistro_LanFaturamento_CMI() { St_devolucao = lPedFiscal[0].ST_Devolucao, 
                                                                                                            St_retorno = lPedFiscal[0].ST_Retorno,
                                                                                                            St_mestra = lPedFiscal[0].ST_Mestra,
                                                                                                            St_complementar = lPedFiscal[0].ST_Complementar,
                                                                                                            St_geraestoque = lPedFiscal[0].St_geraestoque,
                                                                                                            St_simplesremessa = lPedFiscal[0].ST_SimplesRemessa} };
            regFaturamento.Cd_movimentacao = lPedFiscal[0].Cd_movto;
            regFaturamento.lCFGFiscal = lPedFiscal;
            regFaturamento.Cd_uf_empresa = rTicketAplicar.Cd_ufemp;
            regFaturamento.Cd_uf_clifor = rTicketAplicar.Cd_ufcontratante;
            regFaturamento.Cd_condfiscal_clifor = rTicketAplicar.Cd_condfiscal_contratante;
            
            regFaturamento.Tp_duplicata = lPedFiscal[0].Tp_duplicata;
            regFaturamento.Ds_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
            regFaturamento.Cd_condpgto = lPedFiscal[0].CD_CondPgto;
            regFaturamento.Nr_pedido = rTicketAplicar.Nr_pedido;
            regFaturamento.Tp_movimento = rTicketAplicar.Tp_movimento;
            regFaturamento.Tp_pessoa = rTicketAplicar.Tp_pessoa_contratante.ToUpper().Trim();
            regFaturamento.Tp_nota = (rTicketAplicar.Tp_pessoa_contratante.Trim().Equals("J") &&
                                      rTicketAplicar.Tp_movimento.Trim().ToUpper().Equals("E") && (!St_notaunica)) ? "T" : "P";
            regFaturamento.Nr_serie = lPedFiscal[0].Nr_serie.ToString();
            regFaturamento.Cd_modelo = lPedFiscal[0].Cd_modelo.ToString();
            regFaturamento.St_sequenciaauto = lPedFiscal[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
            if (rTicketAplicar.Tp_pessoa_contratante.Trim().Equals("J") && rTicketAplicar.Tp_movimento.Trim().ToUpper().Equals("E") && (!St_notaunica) && string.IsNullOrEmpty(rTicketAplicar.Nr_notaprodutor))
                throw new Exception("Obrigatorio informar nota fiscal produtor quando pesagem for ENTRADA e o contratante for pessoa JURIDICA.");
            regFaturamento.Nr_notafiscal = (rTicketAplicar.Tp_pessoa_contratante.Trim().Equals("J") && rTicketAplicar.Tp_movimento.Trim().ToUpper().Equals("E") && (!St_notaunica)) ?
                                   Convert.ToDecimal(rTicketAplicar.Nr_notaprodutor) : regFaturamento.Nr_notafiscal;

            regFaturamento.Dt_emissao = (rTicketAplicar.Tp_pessoa_contratante.Trim().ToUpper().Equals("J") && rTicketAplicar.Tp_movimento.Trim().ToUpper().Equals("E") ? 
                                            rTicketAplicar.Dt_emissaonfprodutor : CamadaDados.UtilData.Data_Servidor());
            regFaturamento.Dt_saient = (rTicketAplicar.Tp_pessoa_contratante.Trim().ToUpper().Equals("J") && rTicketAplicar.Tp_movimento.Trim().ToUpper().Equals("E") ?
                (rTicketAplicar.Tp_movimento.Equals("E") ? rTicketAplicar.Dt_tara : rTicketAplicar.Dt_bruto) : regFaturamento.Dt_emissao);
            //Buscar observacao fiscal e dados adicionais da movimentacao comercial
            
            regFaturamento.Dadosadicionais += (regFaturamento.Dadosadicionais.Trim() != string.Empty ? "\r\n" : string.Empty) + 
                                               rTicketAplicar.Ds_observacao.Trim() +
                                               BuscarObsMov("D",
                                                            regFaturamento.Cd_movimentacaostring,
                                                            rTicketAplicar.Cd_ufcontratante.Trim().Equals(rTicketAplicar.Cd_ufemp.Trim()));
            regFaturamento.Obsfiscal += (regFaturamento.Obsfiscal.Trim() != string.Empty ? "\r\n" : string.Empty) +
                                        BuscarObsMov("F",
                                                     regFaturamento.Cd_movimentacaostring,
                                                     rTicketAplicar.Cd_ufcontratante.Trim().Equals(rTicketAplicar.Cd_ufemp.Trim()));
            //Dados frete da nota fiscal
            regFaturamento.Cd_transportadora = rTicketAplicar.Cd_transp;
            regFaturamento.Nm_razaosocialtransp = rTicketAplicar.Nm_motorista;
            regFaturamento.Cpf_transp = rTicketAplicar.Cpf_cnpj_mot;
            regFaturamento.Placaveiculo = rTicketAplicar.Placacarreta;
            regFaturamento.Freteporconta = rTicketAplicar.Freteporconta;
            regFaturamento.lTicketAplicar.Add(rTicketAplicar);

            //Abrir tela para capturar dados da nota fiscal            
            using (TFNumero_Nota fNumero = new TFNumero_Nota())
            {
                fNumero.pCd_empresa = regFaturamento.Cd_empresa;
                fNumero.pNm_empresa = regFaturamento.Nm_empresa;
                fNumero.pCd_clifor = regFaturamento.Cd_clifor;
                fNumero.pNm_clifor = regFaturamento.Nm_clifor;
                fNumero.pTp_pessoa = regFaturamento.Tp_pessoa;
                fNumero.pTp_movimento = regFaturamento.Tp_movimento;
                fNumero.pTp_nota = regFaturamento.Tp_nota;
                fNumero.pChave_Acesso_NFe = regFaturamento.Chave_acesso_nfe;
                fNumero.pNr_serie = regFaturamento.Nr_serie;
                fNumero.pDs_serie = regFaturamento.Ds_serienf;
                fNumero.pCd_modelo = regFaturamento.Cd_modelo;
                fNumero.pDt_emissao = regFaturamento.Dt_emissao;
                fNumero.pST_NotaUnica = St_notaunica;
                fNumero.pNr_notafiscal = regFaturamento.Nr_notafiscal.HasValue ? regFaturamento.Nr_notafiscal.Value.ToString() : string.Empty;
                fNumero.pDt_emissao = regFaturamento.Dt_emissao;
                fNumero.pDt_saient = regFaturamento.Dt_saient;
                fNumero.pDs_dadosadic = regFaturamento.Dadosadicionais;
                fNumero.pDs_obsfiscal = regFaturamento.Obsfiscal;
                fNumero.pSt_sequenciaauto = regFaturamento.St_sequenciaauto;
                fNumero.pCd_movto = regFaturamento.Cd_movimentacaostring;
                fNumero.pCd_cmi = regFaturamento.Cd_cmistring;
                if (regFaturamento.Tp_nota.Trim().ToUpper().Equals("T"))
                {
                    //Buscar inscricao estadual do clifor da nota
                    object obj_insc = new TCD_CadEndereco().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + regFaturamento.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + regFaturamento.Cd_endereco.Trim() + "'"
                            }
                        }, "a.insc_estadual");
                    if (obj_insc != null)
                        fNumero.pInsc_estadual = obj_insc.ToString();
                }
                fNumero.pCd_transportadora = regFaturamento.Cd_transportadora;
                fNumero.pNm_transportadora = regFaturamento.Nm_razaosocialtransp;
                fNumero.pCnpjCpfTransp = regFaturamento.Cpf_transp;
                fNumero.pPlacaVeiculo = regFaturamento.Placaveiculo;
                fNumero.pTp_frete = regFaturamento.Freteporconta;
                if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    regFaturamento.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                    if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                        regFaturamento.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                    else
                        regFaturamento.Nr_notafiscal = null;
                    regFaturamento.Nr_serie = fNumero.pNr_serie;
                    regFaturamento.Cd_modelo = fNumero.pCd_modelo;
                    regFaturamento.Dt_emissao = fNumero.pDt_emissao;
                    regFaturamento.Dt_saient = fNumero.pDt_saient;
                    regFaturamento.Obsfiscal = fNumero.pDs_obsfiscal;
                    regFaturamento.Dadosadicionais = fNumero.pDs_dadosadic;
                    regFaturamento.Tp_nota = fNumero.pTp_nota;
                    regFaturamento.Cd_transportadora = fNumero.pCd_transportadora;
                    regFaturamento.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                    regFaturamento.Cpf_transp = fNumero.pCnpjCpfTransp;
                    regFaturamento.Placaveiculo = fNumero.pPlacaVeiculo;
                    regFaturamento.Freteporconta = fNumero.pTp_frete;
                    regFaturamento.Especie = fNumero.pEspecie;
                    regFaturamento.Quantidade = fNumero.pQuantidade;
                    regFaturamento.Pesobruto = fNumero.pPsbruto;
                    regFaturamento.Pesoliquido = fNumero.pPsliquido;
                    regFaturamento.Vl_frete = fNumero.pVl_frete;
                    if (regFaturamento.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                        regFaturamento.Cminf.Add(new TRegistro_LanFaturamento_CMI()
                        {
                            St_compdevimposto = rCmi.St_compdevimposto,
                            St_complementar = rCmi.St_complementar,
                            St_devolucao = rCmi.St_devolucao,
                            St_geraestoque = rCmi.St_geraestoque,
                            St_mestra = rCmi.St_mestra,
                            St_simplesremessa = rCmi.St_simplesremessa,
                            St_retorno = rCmi.St_retorno
                        });
                        regFaturamento.Cd_cmistring = fNumero.pCd_cmi;
                        regFaturamento.Ds_cmi = rCmi.Ds_cmi;
                        regFaturamento.Tp_duplicata = rCmi.Tp_duplicata;
                        regFaturamento.Ds_tpduplicata = rCmi.ds_tpduplicata;
                    }
                }
                else
                    throw new Exception("Obrigatorio informar numero da nota fiscal.");
            }
            if (regFaturamento.Nr_notafiscal.HasValue)
            {
                TRegistro_LanFaturamento rFat = TCN_LanFaturamento.existeNumeroNota(regFaturamento.Nr_notafiscal.ToString(), regFaturamento.Nr_serie, regFaturamento.Cd_empresa,
                                                                regFaturamento.Cd_clifor, string.Empty, regFaturamento.Tp_nota, null);
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
        }

        private static void InserirItemNf(TRegistro_LanPesagemGraos rTicketAplicar,
                                          TRegistro_LanFaturamento regFaturamento,
                                          decimal vQuantidade,
                                          decimal vVl_SubTotal,
                                          decimal vQuantidadeEstoque,
                                          decimal vVl_SubTotalEstoque)
        {

            if (!rTicketAplicar.NR_Contrato.HasValue)
                throw new Exception("ERRO: Não é permitido aplicar ticket sem CONTRATO!");
            
            if (regFaturamento.ItensNota.Exists(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())))
            {
                decimal auxtotal = regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_subtotal;
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Quantidade += vQuantidade;
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Quantidade_estoque += vQuantidadeEstoque;
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_subtotal = (auxtotal + vVl_SubTotal);
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_subtotal_estoque += vVl_SubTotalEstoque;
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_freteitem =
                    CalcularFrete(regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())));
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(regFaturamento.Cd_empresa,
                                                                                       (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_clifor:regFaturamento.Cd_uf_empresa),
                                                                                       (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_empresa:regFaturamento.Cd_uf_clifor),
                                                                                       regFaturamento.Cd_movimentacao.Value.ToString(),
                                                                                       regFaturamento.Tp_movimento,
                                                                                       regFaturamento.Cd_condfiscal_clifor,
                                                                                       rTicketAplicar.Cd_condfiscal_produto,
                                                                                       (auxtotal + vVl_SubTotal),
                                                                                       vQuantidade,
                                                                                       ref vObsFiscal,
                                                                                       regFaturamento.Dt_emissao,
                                                                                       rTicketAplicar.Cd_produto,
                                                                                       regFaturamento.Tp_nota,
                                                                                       regFaturamento.Nr_serie,
                                                                                       null);
                if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())));
                    regFaturamento.Obsfiscal += string.IsNullOrEmpty(regFaturamento.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(rTicketAplicar.Cd_produto, regFaturamento.Nr_serie, null))
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                            "Tipo Movimento: " + regFaturamento.Tipo_movimento + "\r\n" +
                                            "Movimentação: " + regFaturamento.Cd_movimentacao.ToString() + "\r\n" +
                                            "Cond. Fiscal Clifor: " + regFaturamento.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + rTicketAplicar.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "UF Origem: " + (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_clifor.Trim() : regFaturamento.Cd_uf_empresa.Trim()) + "\r\n" +
                                            "UF Destino: " + (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_empresa.Trim() : regFaturamento.Cd_uf_clifor.Trim()));
                
                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(regFaturamento.Cd_condfiscal_clifor,
                                                                          regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Cd_condfiscal_produto,
                                                                          regFaturamento.Cd_movimentacao.Value.ToString(),
                                                                          regFaturamento.Tp_movimento,
                                                                          regFaturamento.Tp_pessoa,
                                                                          regFaturamento.Cd_empresa,
                                                                          regFaturamento.Nr_serie,
                                                                          regFaturamento.Cd_clifor,
                                                                          regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Cd_unidEst,
                                                                          regFaturamento.Dt_emissao,
                                                                          regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Quantidade,
                                                                          (auxtotal + vVl_SubTotal),
                                                                          regFaturamento.Tp_nota,
                                                                          string.Empty,
                                                                          null),
                    regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())), regFaturamento.Tp_movimento);
                decimal vl_ret = regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_ICMSRetido +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoCofins +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoCSLL +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoFunrural +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoINSS +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoIRRF +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoPIS +
                                 regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).Vl_retidoSenar;
                if (vl_ret > decimal.Zero)
                    regFaturamento.Obsfiscal += string.IsNullOrEmpty(regFaturamento.Obsfiscal) ? vObsFiscal.Trim() : "\r\nImpostos Retidos: " + vl_ret.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                regFaturamento.ItensNota.Find(p => p.Cd_produto.Trim().Equals(rTicketAplicar.Cd_produto.Trim())).lTicketAplicar.Add(rTicketAplicar);
            }
            else
            {
                //Novo Item da Nota Fiscal
                TRegistro_LanFaturamento_Item itensnf = new TRegistro_LanFaturamento_Item();
                itensnf.Cd_empresa = rTicketAplicar.Cd_empresa;
                itensnf.Cd_produto = rTicketAplicar.Cd_produto;
                itensnf.Id_variedade = rTicketAplicar.Id_variedade;
                itensnf.Cd_local = rTicketAplicar.Cd_local;
                itensnf.Cd_condfiscal_produto = rTicketAplicar.Cd_condfiscal_produto;
                itensnf.Cd_unidade = rTicketAplicar.Cd_unid_contrato;
                itensnf.Cd_unidEst = rTicketAplicar.Cd_unid_produto;
                itensnf.Nr_pedido = rTicketAplicar.Nr_pedido.Value;
                itensnf.Id_pedidoitem = rTicketAplicar.Id_pedidoitem;
                itensnf.Quantidade = vQuantidade;
                itensnf.Quantidade_estoque = vQuantidadeEstoque;
                itensnf.Vl_subtotal = vVl_SubTotal;
                itensnf.Vl_subtotal_estoque = vVl_SubTotalEstoque;
                itensnf.Vl_unitario = rTicketAplicar.Vl_unit_contrato;
                //Frete do Item
                itensnf.Vl_freteitem = CalcularFrete(itensnf);
                //Procurar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(regFaturamento.Cd_movimentacaostring,
                                                                   rTicketAplicar.Cd_condfiscal_produto,
                                                                   regFaturamento.Cd_uf_clifor.Trim().Equals("99") ? "I" : regFaturamento.Cd_uf_empresa.Trim().Equals(regFaturamento.Cd_uf_clifor.Trim()) ? "D" : "F",
                                                                   (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_clifor : regFaturamento.Cd_uf_empresa),
                                                                   (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_empresa : regFaturamento.Cd_uf_clifor),
                                                                   regFaturamento.Tp_movimento,
                                                                   regFaturamento.Cd_condfiscal_clifor,
                                                                   regFaturamento.Cd_empresa,
                                                                   ref rCfop,
                                                                   null))
                {
                    if (regFaturamento.Cminf[0].St_devolucaobool && (!rCfop.St_devolucaobool))
                        throw new Exception("Permitido emitir NF-e de DEVOLUÇÃO somente utilizando CFOP de DEVOLUÇÃO.");
                    else if ((!regFaturamento.Cminf[0].St_devolucaobool) && rCfop.St_devolucaobool)
                        throw new Exception("Não é permitido emitir NF-e NORMAL utilizando CFOP de DEVOLUÇÃO.");
                    else if (regFaturamento.Cminf[0].St_retornobool && (!rCfop.St_retornobool))
                        throw new Exception("Permitido emitir NF-e de RETORNO somente utilizando CFOP de RETORNO.");
                    else
                    {
                        itensnf.Cd_cfop = rCfop.CD_CFOP;
                        itensnf.Ds_cfop = rCfop.DS_CFOP;
                        itensnf.St_bonificacao = rCfop.St_bonificacaobool;
                        itensnf.St_devolucao = rCfop.St_devolucaobool;
                        itensnf.St_retorno = rCfop.St_retornobool;
                        itensnf.St_usoconsumo = rCfop.St_usoconsumobool;
                    }
                }
                else
                    throw new Exception("Não existe CFOP " + (regFaturamento.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : regFaturamento.Cd_uf_empresa.Trim().Equals(regFaturamento.Cd_uf_clifor.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + regFaturamento.Cd_movimentacaostring + " condição fiscal do produto " + rTicketAplicar.Cd_condfiscal_produto);
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(regFaturamento.Cd_empresa,
                                                                                       (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_clifor : regFaturamento.Cd_uf_empresa),
                                                                                       (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_empresa : regFaturamento.Cd_uf_clifor),
                                                                                       regFaturamento.Cd_movimentacaostring,
                                                                                       regFaturamento.Tp_movimento,
                                                                                       regFaturamento.Cd_condfiscal_clifor,
                                                                                       rTicketAplicar.Cd_condfiscal_produto,
                                                                                       vVl_SubTotal,
                                                                                       vQuantidade,
                                                                                       ref vObsFiscal,
                                                                                       regFaturamento.Dt_emissao,
                                                                                       rTicketAplicar.Cd_produto,
                                                                                       regFaturamento.Tp_nota,
                                                                                       regFaturamento.Nr_serie,
                                                                                       null);
                if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), itensnf);
                    regFaturamento.Obsfiscal += string.IsNullOrEmpty(regFaturamento.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(itensnf.Cd_produto, regFaturamento.Nr_serie, null))
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                            "Tipo Movimento: " + regFaturamento.Tipo_movimento.Trim() + "\r\n" +
                                            "Movimentação: " + regFaturamento.Cd_movimentacao.ToString() + "\r\n" +
                                            "Cond. Fiscal Clifor: " + regFaturamento.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + rTicketAplicar.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "UF Origem: " + (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_clifor.Trim() : regFaturamento.Cd_uf_empresa.Trim()) + "\r\n" +
                                            "UF Destino: " + (regFaturamento.Tp_movimento.Trim().ToUpper().Equals("E") ? regFaturamento.Cd_uf_empresa.Trim() : regFaturamento.Cd_uf_clifor.Trim()));
                
                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(regFaturamento.Cd_condfiscal_clifor,
                                                                            itensnf.Cd_condfiscal_produto,
                                                                            regFaturamento.Cd_movimentacaostring,
                                                                            regFaturamento.Tp_movimento,
                                                                            regFaturamento.Tp_pessoa,
                                                                            regFaturamento.Cd_empresa,
                                                                            regFaturamento.Nr_serie,
                                                                            regFaturamento.Cd_clifor,
                                                                            itensnf.Cd_unidEst,
                                                                            regFaturamento.Dt_emissao,
                                                                            itensnf.Quantidade,
                                                                            itensnf.Vl_subtotal,
                                                                            regFaturamento.Tp_nota,
                                                                            string.Empty, null), itensnf, regFaturamento.Tp_movimento);
                decimal vl_ret = itensnf.Vl_ICMSRetido +
                                 itensnf.Vl_retidoCofins +
                                 itensnf.Vl_retidoCSLL +
                                 itensnf.Vl_retidoFunrural +
                                 itensnf.Vl_retidoINSS +
                                 itensnf.Vl_retidoIRRF +
                                 itensnf.Vl_retidoPIS +
                                 itensnf.Vl_retidoSenar;
                if(vl_ret > decimal.Zero)
                    regFaturamento.Obsfiscal += string.IsNullOrEmpty(regFaturamento.Obsfiscal) ? vObsFiscal.Trim() : "\r\nImpostos Retidos: " + vl_ret.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
                itensnf.lTicketAplicar.Add(rTicketAplicar);
                regFaturamento.ItensNota.Add(itensnf);
            }
        }
        
        private static void preparaNf(TRegistro_LanPesagemGraos rTicketAplicar,
                                      TRegistro_LanFaturamento rNotaFiscal,
                                      bool St_notaunica)
        {
            if (rTicketAplicar.Tp_movimento.Trim().Equals("E"))
            {
                #region Movimento ENTRADA
                if (rTicketAplicar.Tp_pessoa_contratante.Trim().Equals("F"))
                    #region Fisica
                    InserirItemNf(rTicketAplicar,
                                  rNotaFiscal,
                                  rTicketAplicar.Ps_Aplicar,
                                  TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                                 rTicketAplicar.Cd_unid_contrato,
                                                                 (rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato),
                                                                 2,
                                                                 null),
                                  rTicketAplicar.Ps_Aplicar,
                                  TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                                 rTicketAplicar.Cd_unid_contrato,
                                                                 (rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato),
                                                                 2,
                                                                 null));
                    #endregion
                else if (rTicketAplicar.Tp_pessoa_contratante.Trim().Equals("J"))
                    #region Juridica
                    InserirItemNf(rTicketAplicar,
                                  rNotaFiscal,
                                  (St_notaunica || rNotaFiscal.Tp_nota.Trim().ToUpper().Equals("P") ? rTicketAplicar.Ps_Aplicar : rTicketAplicar.Qt_nfprodutor),
                                  (St_notaunica || rNotaFiscal.Tp_nota.Trim().ToUpper().Equals("P") ? TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                                 rTicketAplicar.Cd_unid_contrato,
                                                                 rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato,
                                                                 2,
                                                                 null) : rTicketAplicar.Vl_nfprodutor),
                                  rTicketAplicar.Ps_Aplicar,
                                  TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                                 rTicketAplicar.Cd_unid_contrato,
                                                                 rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato,
                                                                 2,
                                                                 null));
                    #endregion
                #endregion
            }
            else if (rTicketAplicar.Tp_movimento.Trim().Equals("S"))
                #region MOVIMENTO SAIDA
                InserirItemNf(rTicketAplicar,
                              rNotaFiscal,
                              rTicketAplicar.Ps_Aplicar,
                              TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                             rTicketAplicar.Cd_unid_contrato,
                                                             rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato,
                                                             2,
                                                             null),
                              rTicketAplicar.Ps_Aplicar,
                              TCN_CadConvUnidade.ConvertUnid(rTicketAplicar.Cd_unid_produto,
                                                             rTicketAplicar.Cd_unid_contrato,
                                                             rTicketAplicar.Ps_Aplicar * rTicketAplicar.Vl_unit_contrato,
                                                             2,
                                                             null));
                #endregion
        }
        
        public static bool VerificarSaldoAutoriz(string Id_autoriz,
                                                 decimal QT_SaldoAplicar)
        {
            object obj = new CamadaDados.Graos.TCD_Autoriz_RetDeposito().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_autoriz",
                        vOperador = "=",
                        vVL_Busca = Id_autoriz
                    }
                },
                "(a.qtd_retirar - dbo.F_CONVERTE_UNID(c.cd_unidade, a.cd_unidade, " +
                "                        isnull((select sum(isnull(w.qtd_saida, 0)) from tb_bal_aplicacao_pedido x " +
                "                        inner join tb_fat_aplicacao_x_notafiscal y " +
                "                        on x.id_aplicacao = y.id_aplicacao " +
                "                        inner join tb_fat_notafiscal_item_x_estoque z " +
                "                        on y.cd_empresa = z.cd_empresa " +
                "                        and y.nr_lanctofiscal = z.nr_lanctofiscal " +
                "                        and y.id_nfitem = z.id_nfitem " +
                "                        inner join tb_est_estoque w " +
                "                        on z.cd_empresa = w.cd_empresa " +
                "                        and z.cd_produto = w.cd_produto " +
                "                        and z.id_lanctoestoque = w.id_lanctoestoque " +
                "                        where x.id_autoriz = a.id_autoriz " +
                "                        and isnull(w.st_registro, 'A') <> 'C'), 0)))");
            if (obj == null)
                return false;
            decimal saldo = Convert.ToDecimal(obj.ToString());
            return saldo >= QT_SaldoAplicar;
        }
        
        public static TList_RegLanFaturamento ProcessarAplicacao(bool St_notaunica, 
                                                                 decimal QT_SaldoAplicar, 
                                                                 List<TRegistro_LanPesagemGraos> lTicketAplicar)
        {
            TList_RegLanFaturamento lNotas = new TList_RegLanFaturamento();
            TRegistro_LanFaturamento rNf = null;
            string obsTicket = string.Empty;
            string obsNfProd = string.Empty;
            string virg = string.Empty;
            if(St_notaunica)
                PreencherNotaFiscal(ref rNf, lTicketAplicar[0], St_notaunica);
            lTicketAplicar.ForEach(p =>
                {
                    if (!St_notaunica)
                    {
                        rNf = null;
                        PreencherNotaFiscal(ref rNf, p, St_notaunica);
                        rNf.Pesobruto = p.Ps_bruto;
                        rNf.Pesoliquido = p.Ps_Aplicar;
                        rNf.Quantidade = p.Ps_Aplicar;
                        preparaNf(p, rNf, St_notaunica);
                        rNf.Dadosadicionais = "Ref. Romaneio: " + p.Id_ticketstr + (!string.IsNullOrEmpty(p.Nr_notaprodutor) ? " Ref. NF. Produtor: " + p.Nr_notaprodutor.Trim() : string.Empty) + " " + rNf.Dadosadicionais.Trim();
                        lNotas.Add(rNf);
                    }
                    else
                    {
                        rNf.Pesobruto += p.Ps_bruto;
                        rNf.Pesoliquido += p.Ps_Aplicar;
                        rNf.Quantidade += p.Ps_Aplicar;
                        preparaNf(p, rNf, St_notaunica);
                        obsTicket += virg + p.Id_ticketstr;
                        if (!string.IsNullOrEmpty(p.Nr_notaprodutor))
                            obsNfProd += virg + p.Nr_notaprodutor.Trim();
                        virg = ",";
                    }
                });
            if (St_notaunica)
            {
                rNf.Dadosadicionais = "Ref. Romaneios: " + obsTicket.Trim() + (!string.IsNullOrEmpty(obsNfProd) ? " Ref. NFs. Produtor: " + obsNfProd.Trim() : string.Empty) + " " + rNf.Dadosadicionais.Trim();
                lNotas.Add(rNf);
            }
            lNotas.ForEach(p =>
            {
                //Gerar financeiro
                if (!string.IsNullOrEmpty(p.Tp_duplicata))
                {
                    //Verificar se o pedido possui financeiro
                    TList_Pedido_DT_Vencto lParcPedido = TCN_LanPedido_DT_Vencto.Busca(Convert.ToDecimal(p.Nr_pedido), null);
                    //Buscar historico da movimentacao
                    CamadaDados.Fiscal.TList_CadMovimentacao lMov = new CamadaDados.Fiscal.TCD_CadMovimentacao().Select(
                        new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_movimentacao",
                                        vVL_Busca = "'" + p.Cd_movimentacao.ToString().Trim() + "'",
                                        vOperador = "="
                                    }
                                }, 1, string.Empty);

                    //Buscar Configurações da Condição de Pagamento
                    TList_CadCondPgto lCondPgto = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(p.Cd_condpgto,
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
                    //Buscar parcelas da condicao de pagamento
                    //somente se o pedido nao tiver financeiro
                    if (lParcPedido.Count.Equals(0))
                        lCondPgto[0].lCondPgto_X_Parcelas = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto_X_Parcelas.Buscar(lCondPgto[0].Cd_condpgto, null);

                    //Buscar moeda do pedido
                    CamadaDados.Financeiro.Cadastros.TList_Moeda lMoedaPed = new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from vtb_fat_pedido x " +
                                            "where x.cd_moeda = a.cd_moeda " +
                                            "and x.nr_pedido = " + p.Nr_pedidostring + ")"
                            }
                        }, 1, string.Empty);

                    //buscar tipo duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup = CamadaNegocio.Financeiro.Cadastros.TCN_CadTpDuplicata.Buscar(p.Tp_duplicata.ToString().Trim(),
                                                                                                                                                string.Empty,
                                                                                                                                                string.Empty,
                                                                                                                                                null);
                    //Abrir tela de lançamento de duplicata
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        if ((!p.lCFGFiscal[0].ST_Complementar.Trim().ToUpper().Equals("S")) &&
                            (!p.lCFGFiscal[0].ST_Devolucao.Trim().ToUpper().Equals("S")))
                            fDuplicata.vNr_pedido = p.Nr_pedido;

                        fDuplicata.vSt_notafiscal = true;
                        fDuplicata.vCd_empresa = p.Cd_empresa.Trim();
                        fDuplicata.vNm_empresa = p.Nm_empresa.Trim();
                        fDuplicata.vCd_clifor = p.Cd_clifor.Trim();
                        fDuplicata.vNm_clifor = p.Nm_clifor.Trim();
                        fDuplicata.vCd_endereco = p.Cd_endereco.Trim();
                        fDuplicata.vDs_endereco = p.Ds_endereco.Trim();
                        //Buscar Historico do Cliente
                        TList_CadHistorico lHist = new TCD_CadHistorico().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_clifor x " +
                                                                        "where " + (p.Tp_movimento.Trim().ToUpper().Equals("S") ? "x.cd_historicorec" : "x.cd_historicopag") + " = a.cd_historico " +
                                                                        "and x.cd_clifor = '" + p.Cd_clifor.Trim() + "')"
                                                        }
                                                    }, 1, string.Empty);
                        if (lHist.Count > 0)
                        {
                            fDuplicata.vCd_historico = lHist[0].Cd_historico;
                            fDuplicata.vDs_historico = lHist[0].Ds_historico;
                        }
                        else if (lMov.Count > 0)
                        {
                            fDuplicata.vCd_historico = lMov[0].cd_historico;
                            fDuplicata.vDs_historico = lMov[0].ds_historico;
                        }
                        //Dados CMI
                        fDuplicata.vTp_duplicata = p.Tp_duplicata.Trim();
                        fDuplicata.vDs_tpduplicata = p.Ds_tpduplicata.Trim();
                        fDuplicata.vTp_mov = p.Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                      p.Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                        fDuplicata.vTp_docto = p.lCFGFiscal[0].Tp_docto.HasValue ? p.lCFGFiscal[0].Tp_docto.Value.ToString() : string.Empty;
                        if(lTpDup[0].Id_configboleto.HasValue)
                        {
                            fDuplicata.vId_configBoleto = lTpDup[0].Id_configboletostr;
                            fDuplicata.vDs_configBoleto = lTpDup[0].Ds_configboleto;
                        }
                        if (lCondPgto.Count > 0)
                        {
                            fDuplicata.vCd_condpgto = lCondPgto[0].Cd_condpgto.Trim();
                            fDuplicata.vDs_condpgto = lCondPgto[0].Ds_condpgto.Trim();
                            fDuplicata.vSt_comentrada = lCondPgto[0].St_comentrada.Trim();
                            fDuplicata.vCd_juro = lCondPgto[0].Cd_juro.Trim();
                            fDuplicata.vDs_juro = lCondPgto[0].Ds_juro.Trim();
                            fDuplicata.vTp_juro = lCondPgto[0].Tp_juro.Trim();
                            //Moeda do pedido
                            fDuplicata.vCd_moeda = lMoedaPed[0].Cd_moeda;
                            fDuplicata.vDs_moeda = lMoedaPed[0].Ds_moeda_singular;
                            fDuplicata.vSigla_moeda = lMoedaPed[0].Sigla;

                            fDuplicata.vQt_dias_desdobro = lCondPgto[0].Qt_diasdesdobro;
                            fDuplicata.vQt_parcelas = lCondPgto[0].Qt_parcelas;
                            fDuplicata.vPc_jurodiario_atrazo = lCondPgto[0].Pc_jurodiario_atrazo;
                            fDuplicata.vCd_portador = lCondPgto[0].Cd_portador.Trim();
                            fDuplicata.vDs_portador = lCondPgto[0].Ds_portador.Trim();
                            fDuplicata.vSt_solicitardtvencto = lCondPgto[0].St_solicitardtvenctobool;
                        }
                        fDuplicata.vNr_docto = p.Nr_notafiscal.ToString();
                        fDuplicata.vDt_emissao = p.Dt_saient.HasValue ? p.Dt_saientstring : CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vVl_documento = TCN_LanFaturamento.CalcTotalFinNota(p);
                        if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            p.Duplicata.Clear();
                            for (int j = 0; j < fDuplicata.dsDuplicata.Count; j++)
                                p.Duplicata.Add(fDuplicata.dsDuplicata[j] as TRegistro_LanDuplicata);
                        }
                        else
                            throw new Exception("Obrigatório informar financeiro para gravar aplicação.");
                    }
                }
                //Verificar se a nota e de devolucao
                if (p.lCFGFiscal[0].ST_Devolucao.Trim().ToUpper().Equals("S") ||
                    p.lCFGFiscal[0].ST_Retorno.Trim().ToUpper().Equals("S"))
                {
                    //Para cada item da nota 
                    //amarrar a nota de entrada
                    p.ItensNota.ForEach(v =>
                    {
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = p.Cd_empresa;
                            fCompDevol.Nr_pedido = p.Nr_pedidostring;
                            fCompDevol.Cd_produto = v.Cd_produto;
                            fCompDevol.Cd_clifor = p.Cd_clifor;
                            fCompDevol.Tp_operacao = "D";
                            if (p.Tp_movimento.Trim().Equals("E"))
                                fCompDevol.Tp_movimento = "S";
                            else if (p.Tp_movimento.Trim().Equals("S"))
                                fCompDevol.Tp_movimento = "E";
                            fCompDevol.Quantidade = v.Quantidade;
                            fCompDevol.Valor = v.Vl_subtotal;
                            if (fCompDevol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                v.lNfcompdev = fCompDevol.ListaCompDev;
                            else
                                throw new Exception("Obrigatorio informar notas a serem devolvidas.");
                            //Observação do Item com os dados das notas de origem
                            string obsitem = string.Empty;
                            for (int ind = 0; ind < fCompDevol.ListaCompDev.Count; ind++)
                                obsitem += (fCompDevol.ListaCompDev[ind].Nr_notafiscal_origem.ToString() + "/" + fCompDevol.ListaCompDev[ind].Nr_serie_origem).FormatStringDireita(21, ' ') + 
                                            (fCompDevol.ListaCompDev[ind].Qtd_lancto.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) +
                                            v.Sigla_unidade_estoque.Trim()).FormatStringDireita(15, ' ') + 
                                            fCompDevol.ListaCompDev[ind].Vl_lancto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).FormatStringDireita(12, ' ') + "\r\n";
                            v.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obsitem;
                        }
                    });
                }
            });
            return lNotas;
        }
    }
}
