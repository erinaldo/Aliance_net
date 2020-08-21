using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;

namespace Proc_Commoditties
{
    public class TProcessaPedFaturar
    {
        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessaPedFaturar(CamadaDados.Faturamento.Pedido.TRegistro_Pedido val,
                                                                                                     bool St_agruparFin,
                                                                                                     decimal Vl_financeiro)
        {
            //Buscar configuracao fiscal do pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cfg_pedido",
                        vOperador = "=",
                        vVL_Busca = "'" + val.CFG_Pedido.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = string.IsNullOrEmpty(val.Cd_cliforent) ? "'NO'" : "'RT'"
                    }
                }, 1, string.Empty);
            if (lCfgPed.Count > 0)
            {
                //Verificar se o pedido integra almoxarifado
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + val.CFG_Pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_integraralmox, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") != null)
                {
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALOCACAO ITENS ALMOXARIFADO", null))
                        //Buscar os itens que nao tem alocacao no almoxarifado
                        new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = val.Nr_pedido.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "not exists",
                                    vVL_Busca = "(select 1 from tb_fat_entregapedido x " +
                                                "where x.nr_pedido = a.nr_pedido " +
                                                "and x.cd_produto = a.cd_produto " +
                                                "and x.id_pedidoitem = a.id_pedidoitem)"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty).ForEach(p =>
                                {
                                    using ( TFAlocarItem fAloc = new TFAlocarItem())
                                    {
                                        fAloc.Cd_empresa = p.Cd_Empresa;
                                        fAloc.Cd_produto = p.Cd_produto;
                                        fAloc.Ds_produto = p.Ds_produto;
                                        fAloc.Sigla_unidade = p.Sg_unidade_est;
                                        if (fAloc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            try
                                            {
                                                CamadaNegocio.Almoxarifado.TCN_AlocacaoItem.AlocarItem(
                                                    new CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido()
                                                    {
                                                        Nr_pedido = p.Nr_pedido,
                                                        Cd_produto = p.Cd_produto,
                                                        Id_pedidoitem = p.Id_pedidoitem,
                                                        Login = Utils.Parametros.pubLogin,
                                                        Qtd_entregue = fAloc.Quantidade,
                                                        Dt_entrega = CamadaDados.UtilData.Data_Servidor(),
                                                        Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA ALOCACAO ITEM NO ALMOXARIFADO",
                                                        Id_almoxstr = fAloc.Id_almox,
                                                        St_registro = "P"
                                                    }
                                                    , null);
                                            }
                                            catch (Exception ex)
                                            { System.Windows.Forms.MessageBox.Show(ex.Message.Trim(), "Erro", 
                                                                                    System.Windows.Forms.MessageBoxButtons.OK,
                                                                                    System.Windows.Forms.MessageBoxIcon.Error);
                                            }
                                    }
                                });
                    else
                        throw new Exception("Obrigatorio alocar itens no almoxarifado antes de realizar o faturamento.");
                }
                //Objeto Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                rNf.Cd_empresa = val.CD_Empresa;
                rNf.Cd_clifor = string.IsNullOrEmpty(val.Cd_cliforent) ? val.CD_Clifor : val.Cd_cliforent;
                rNf.Nm_clifor = string.IsNullOrEmpty(val.Cd_cliforent) ? val.NM_Clifor : val.Nm_cliforent;
                rNf.Cd_endereco = string.IsNullOrEmpty(val.Cd_cliforent) ? val.CD_Endereco : val.Cd_enderecoent;
                rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
                rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNf.lCFGFiscal = lCfgPed;
                rNf.Cd_uf_empresa = val.Cd_uf_empresa;
                rNf.Uf_empresa = val.Uf_empresa;
                rNf.Cd_uf_clifor = string.IsNullOrEmpty(val.Cd_cliforent) ? val.Cd_uf_cliente : val.Cd_uf_ent;
                rNf.Uf_clifor = string.IsNullOrEmpty(val.Cd_cliforent) ? val.UF_Cliente : val.Uf_ent;
                rNf.Cd_condfiscal_clifor = string.IsNullOrEmpty(val.Cd_cliforent) ? val.Cd_condfiscal_clifor : val.Cd_condfiscalent;
                rNf.Cd_municipioexecservico = string.IsNullOrEmpty(val.Cd_municipioexecservico) ? val.Cd_cidade_emp : val.Cd_municipioexecservico;
                rNf.Ds_municipioexecservico = string.IsNullOrEmpty(val.Ds_municipioexecservico) ? val.Ds_cidade_emp : val.Ds_municipioexecservico;
                rNf.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                rNf.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                rNf.Cd_condpgto = string.IsNullOrEmpty(val.CD_CondPGTO) ? lCfgPed[0].CD_CondPgto : val.CD_CondPGTO;
                rNf.Nr_pedido = val.Nr_pedido;
                rNf.Tp_movimento = val.TP_Movimento;
                rNf.Tp_pessoa = string.IsNullOrEmpty(val.Cd_cliforent) ? val.Tp_pessoa : val.Tp_pessoaent;
                rNf.Tp_nota = (rNf.Tp_pessoa.Trim().ToUpper().Equals("J") && rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                rNf.Nr_serie = lCfgPed[0].Nr_serie;
                rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
                rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rNf.Dt_saient = rNf.Dt_emissao;
                rNf.Quantidade = val.QUANTIDADENF;
                rNf.Pesoliquido = val.PesoLiquido;
                rNf.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                     rNf.Cd_movimentacaostring,
                                                                     val.UF_Cliente.Trim().Equals(val.Uf_empresa.Trim()));
                rNf.Obsfiscal = !string.IsNullOrEmpty(val.DS_Observacao) ? val.DS_Observacao : ProcessaAplicacao.BuscarObsMov("F",
                                                                                                rNf.Cd_movimentacaostring,
                                                                                                val.UF_Cliente.Trim().Equals(val.Uf_empresa.Trim()));
                rNf.Freteporconta = val.Tp_frete;
                rNf.Cd_transportadora = val.CD_TRANSPORTADORA;
                rNf.Nm_razaosocialtransp = val.NM_TRANSPORTADORA;
                rNf.Cpf_transp = val.NR_CCG_CPF_TRANSP;
                rNf.Placaveiculo = val.Placaveiculo;
                //Abrir tela para capturar dados da nota fiscal            
                using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                {
                    fNumero.pCd_empresa = rNf.Cd_empresa;
                    fNumero.pNm_empresa = rNf.Nm_empresa;
                    fNumero.pCd_clifor = rNf.Cd_clifor;
                    fNumero.pNm_clifor = rNf.Nm_clifor;
                    fNumero.pTp_pessoa = rNf.Tp_pessoa;
                    fNumero.pTp_movimento = rNf.Tp_movimento;
                    fNumero.pTp_nota = rNf.Tp_nota;
                    fNumero.pChave_Acesso_NFe = rNf.Chave_acesso_nfe;
                    fNumero.pNr_serie = rNf.Nr_serie;
                    fNumero.pDs_serie = rNf.Ds_serienf;
                    fNumero.pCd_modelo = rNf.Cd_modelo;
                    fNumero.pDt_emissao = rNf.Dt_emissao;
                    fNumero.pST_NotaUnica = false;
                    fNumero.pNr_notafiscal = rNf.Nr_notafiscal.HasValue ? rNf.Nr_notafiscal.Value.ToString() : string.Empty;
                    fNumero.pDt_saient = rNf.Dt_saient;
                    fNumero.pDs_dadosadic = rNf.Dadosadicionais;
                    fNumero.pDs_obsfiscal = rNf.Obsfiscal;
                    fNumero.pSt_sequenciaauto = rNf.St_sequenciaauto;
                    fNumero.pCd_movto = rNf.Cd_movimentacaostring;
                    fNumero.pCd_cmi = rNf.Cd_cmistring;
                    fNumero.pQuantidade = rNf.Quantidade;
                    fNumero.pPsliquido = rNf.Pesoliquido;
                    fNumero.pSt_servico = lCfgPed.Count > 0 ? lCfgPed[0].St_servico : false;
                    if (rNf.Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        //Buscar inscricao estadual do clifor da nota
                        object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                            new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_clifor.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_endereco",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_endereco.Trim() + "'"
                                                        }
                                                    }, "a.insc_estadual");
                        fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                    }
                    fNumero.pTp_frete = rNf.Freteporconta;
                    fNumero.pCd_transportadora = rNf.Cd_transportadora;
                    fNumero.pNm_transportadora = rNf.Nm_razaosocialtransp;
                    fNumero.pCnpjCpfTransp = rNf.Cpf_transp;
                    fNumero.pPlacaVeiculo = rNf.Placaveiculo;
                    fNumero.pVl_frete = val.Pedido_Itens.Sum(p => p.Vl_freteitem);
                    if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rNf.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                        if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                            rNf.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                        else
                            rNf.Nr_notafiscal = null;
                        rNf.Nr_serie = fNumero.pNr_serie;
                        rNf.Cd_modelo = fNumero.pCd_modelo;
                        rNf.Dt_emissao = fNumero.pDt_emissao;
                        rNf.Dt_saient = fNumero.pDt_saient;
                        rNf.Obsfiscal = fNumero.pDs_obsfiscal;
                        rNf.Dadosadicionais = fNumero.pDs_dadosadic;
                        rNf.Cd_transportadora = fNumero.pCd_transportadora;
                        rNf.Cd_enderecotransp = fNumero.pCd_endtransportadora;
                        rNf.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                        rNf.Cpf_transp = fNumero.pCnpjCpfTransp;
                        rNf.Placaveiculo = fNumero.pPlacaVeiculo;
                        rNf.Freteporconta = fNumero.pTp_frete;
                        rNf.Especie = fNumero.pEspecie;
                        rNf.Quantidade = fNumero.pQuantidade;
                        rNf.Pesobruto = fNumero.pPsbruto;
                        rNf.Pesoliquido = fNumero.pPsliquido;
                        rNf.Vl_frete = fNumero.pVl_frete;
                        rNf.Cd_municipioexecservico = fNumero.pCd_municipioexecservico;
                        rNf.Ds_municipioexecservico = fNumero.pNm_municipioexecservico;
                        rNf.Cd_ufsaidaex = fNumero.pCd_ufsaidaex;
                        rNf.Ds_ufsaidaex = fNumero.pDs_ufsaidaex;
                        rNf.Uf_saidaex = fNumero.pUf_saidaex;
                        rNf.Ds_localex = fNumero.pDs_localex;
                        if (rNf.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                            rNf.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                            {
                                St_compdevimposto = rCmi.St_compdevimposto,
                                St_complementar = rCmi.St_complementar,
                                St_devolucao = rCmi.St_devolucao,
                                St_geraestoque = rCmi.St_geraestoque,
                                St_mestra = rCmi.St_mestra,
                                St_simplesremessa = rCmi.St_simplesremessa,
                                St_retorno = rCmi.St_retorno
                            });
                            rNf.Cd_cmistring = fNumero.pCd_cmi;
                            rNf.Ds_cmi = rCmi.Ds_cmi;
                            rNf.Tp_duplicata = rCmi.Tp_duplicata;
                            rNf.Ds_tpduplicata = rCmi.ds_tpduplicata;
                        }
                    }
                    else
                        throw new Exception("Obrigatorio informar numero da nota fiscal.");
                }
                if (rNf.Nr_notafiscal.HasValue)
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNf.Nr_notafiscal.ToString(),
                                                                                                 rNf.Nr_serie,
                                                                                                 rNf.Cd_empresa,
                                                                                                 rNf.Cd_clifor,
                                                                                                 string.Empty,
                                                                                                 rNf.Tp_nota,
                                                                                                 null);
                    if (rFat != null)
                        if (rFat.St_registro.Trim().ToUpper().Equals("C"))
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra cancelada.\r\n" +
                                                "Para poder utilizar o mesmo numero e necessario excluir a nota fiscal cancelada.\r\n" +
                                                "Dica: Menu FATURAMENTO->Emissão de Notas Fiscais / NFe, localize a nota fiscal cancelada e exclua a mesma.\r\n" +
                                                "Obs.: Para excluir a nota fiscal cancelada é necessario que o usuario tenha permissão.");
                        else
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra ativa.\r\n" +
                                                "Não é permitido gerar nota fiscal com mesmo numero.");
                }
                val.Pedido_Itens.ForEach(item =>
                    {
                        //Item da nota fiscal
                        if (lCfgPed[0].Tp_serie.Trim().ToUpper().Equals("P") && item.St_servico)
                            throw new Exception("Série " + rNf.Nr_serie.Trim() + " não permite faturar SERVIÇO.\r\n" +
                                                "Item " + item.Cd_produto.Trim() + "-" + item.Ds_produto.Trim() + " esta configurado como SERVIÇO.");
                        if (lCfgPed[0].Tp_serie.Trim().ToUpper().Equals("S") && (!item.St_servico))
                            throw new Exception("Série " + rNf.Nr_serie.Trim() + " permite faturar somente SERVIÇO.\r\n" +
                                                "Item " + item.Cd_produto.Trim() + "-" + item.Ds_produto.Trim() + " não esta configurado como SERVIÇO.");
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                        rItem.Cd_empresa = val.CD_Empresa;
                        rItem.Cd_produto = item.Cd_produto;
                        rItem.Cd_local = item.Cd_local;
                        rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                        rItem.Cd_unidade = item.Cd_unidade_valor;
                        rItem.Cd_unidEst = item.Cd_unidade_est;
                        rItem.Nr_pedido = val.Nr_pedido;
                        rItem.Cd_vendedor = val.Cd_vendedor;
                        rItem.Id_pedidoitem = item.Id_pedidoitem;
                        rItem.Quantidade = item.Quantidade;
                        rItem.Quantidade_estoque = item.Quantidade;
                        rItem.Vl_subtotal = item.Vl_subtotal;
                        rItem.Vl_subtotal_estoque = item.Vl_subtotal;
                        rItem.Vl_unitario = item.Vl_unitario;
                        rItem.Pc_desconto = item.Pc_desc;
                        rItem.Vl_desconto = item.Vl_desc;
                        rItem.Vl_freteitem = TCN_LanPedido_Item.RatearFreteItemNF(val.Nr_pedido.ToString(),
                                                         item.Cd_produto,
                                                         item.Id_pedidoitem.ToString(),
                                                         item.Quantidade,
                                                         null);
                        rItem.Pc_juro_fin = item.Pc_juro_fin;
                        rItem.Vl_juro_fin = item.Vl_juro_fin;
                        rItem.Vl_outrasdesp = item.Vl_acrescimo;
                        rItem.Pc_imposto_Aprox = item.Pc_imposto_Aprox;
                        rItem.Observacao_item = item.Ds_observacaoitem;
                        rItem.lItensCargaAvulsa = item.lItensCargaAvulsa;
                        //Buscar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                           item.Cd_condfiscal_produto,
                                                                           val.Cd_uf_cliente.Trim().Equals("99") ? "I" : val.Cd_uf_cliente.Trim().Equals(val.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                           rNf.Tp_movimento,
                                                                           rNf.Cd_condfiscal_clifor,
                                                                           rNf.Cd_empresa,
                                                                           ref rCfop,
                                                                           null))
                        {
                            rItem.Cd_cfop = rCfop.CD_CFOP;
                            rItem.Ds_cfop = rCfop.DS_CFOP;
                            rItem.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (val.Cd_uf_cliente.Trim().Equals("99") ? "I" : val.Cd_uf_cliente.Trim().Equals(val.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNf.Cd_empresa,
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                                              rNf.Cd_movimentacaostring,
                                                                                                              rNf.Tp_movimento,
                                                                                                              rNf.Cd_condfiscal_clifor,
                                                                                                              rItem.Cd_condfiscal_produto,
                                                                                                              rItem.Vl_basecalcImposto,
                                                                                                              rItem.Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rNf.Dt_emissao,
                                                                                                              rItem.Cd_produto,
                                                                                                              rNf.Tp_nota,
                                                                                                              rNf.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                        {
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItem);
                            rNf.Obsfiscal += vObsFiscal.Trim();
                        }
                        else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, rNf.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + rNf.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + rNf.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + rNf.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_clifor.Trim() : rNf.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_empresa.Trim() : rNf.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                                                                       rItem.Cd_condfiscal_produto,
                                                                                                                       rNf.Cd_movimentacaostring,
                                                                                                                       rNf.Tp_movimento,
                                                                                                                       rNf.Tp_pessoa,
                                                                                                                       rNf.Cd_empresa,
                                                                                                                       rNf.Nr_serie,
                                                                                                                       rNf.Cd_clifor,
                                                                                                                       rItem.Cd_unidEst,
                                                                                                                       rNf.Dt_emissao,
                                                                                                                       rItem.Quantidade,
                                                                                                                       rItem.Vl_basecalcImposto,
                                                                                                                       rNf.Tp_nota,
                                                                                                                       rNf.Cd_municipioexecservico,
                                                                                                                       null), rItem, rNf.Tp_movimento);
                        string obs_ret = string.Empty;
                        string linha = string.Empty;
                        if (rItem.Vl_ICMSRetido > decimal.Zero)
                        {
                            obs_ret += linha + "ICMS RETIDO " + rItem.Vl_ICMSRetido.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCofins > decimal.Zero)
                        {
                            obs_ret += linha + "COFINS RETIDO " + rItem.Vl_retidoCofins.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCSLL > decimal.Zero)
                        {
                            obs_ret += linha + "CSLL RETIDO " + rItem.Vl_retidoCSLL.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoFunrural > decimal.Zero)
                        {
                            obs_ret += linha + "FUNRURAL RETIDO " + rItem.Vl_retidoFunrural.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoINSS > decimal.Zero)
                        {
                            obs_ret += linha + "INSS RETIDO " + rItem.Vl_retidoINSS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoIRRF > decimal.Zero)
                        {
                            obs_ret += linha + "IRFF RETIDO " + rItem.Vl_retidoIRRF.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoPIS > decimal.Zero)
                        {
                            obs_ret += linha + "PIS RETIDO " + rItem.Vl_retidoPIS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoSenar > decimal.Zero)
                        {
                            obs_ret += linha + "SENAR RETIDO " + rItem.Vl_retidoSenar.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (!string.IsNullOrEmpty(obs_ret))
                            rNf.Obsfiscal += (string.IsNullOrEmpty(rNf.Obsfiscal) ? string.Empty : "\r\n") + obs_ret.Trim();
                        rNf.ItensNota.Add(rItem);
                    });
                //Gerar financeiro
                if ((!string.IsNullOrEmpty(rNf.Tp_duplicata)) &&
                    (St_agruparFin ? Vl_financeiro > decimal.Zero : true))
                {
                    //Buscar historico da movimentacao
                    CamadaDados.Fiscal.TList_CadMovimentacao lMov = new CamadaDados.Fiscal.TCD_CadMovimentacao().Select(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_movimentacao",
                                                                            vVL_Busca = "'" + rNf.Cd_movimentacaostring + "'",
                                                                            vOperador = "="
                                                                        }
                                                                    }, 1, string.Empty);

                    //Buscar Configurações da Condição de Pagamento
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond = null;
                    if(!string.IsNullOrEmpty(rNf.Cd_condpgto))
                        rCond = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rNf.Cd_condpgto,
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
                                                                                          null)[0];
                    //buscar tipo duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup = 
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadTpDuplicata.Buscar(rNf.Tp_duplicata.ToString().Trim(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                    //Abrir tela de lançamento de duplicata
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        fDuplicata.vNr_pedido = val.Nr_pedido;
                        fDuplicata.vSt_notafiscal = true;
                        fDuplicata.vCd_empresa = rNf.Cd_empresa.Trim();
                        fDuplicata.vNm_empresa = rNf.Nm_empresa.Trim();
                        fDuplicata.vCd_clifor = rNf.Cd_clifor.Trim();
                        fDuplicata.vNm_clifor = rNf.Nm_clifor.Trim();
                        fDuplicata.vCd_endereco = rNf.Cd_endereco.Trim();
                        fDuplicata.vDs_endereco = rNf.Ds_endereco.Trim();
                        if (lMov.Count > 0)
                        {
                            fDuplicata.vCd_historico = lMov[0].cd_historico;
                            fDuplicata.vDs_historico = lMov[0].ds_historico;
                        }
                        //Dados CMI
                        fDuplicata.vTp_duplicata = lTpDup[0].Tp_duplicata.Trim();
                        fDuplicata.vDs_tpduplicata = lTpDup[0].Ds_tpduplicata.Trim();
                        fDuplicata.vTp_mov = rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                      rNf.Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                        fDuplicata.vTp_docto = rNf.lCFGFiscal[0].Tp_docto.HasValue ? rNf.lCFGFiscal[0].Tp_docto.Value.ToString() : string.Empty;
                        //Configuracao para emissao de bloqueto automaticamente
                        if(lTpDup[0].Id_configboleto.HasValue)
                        {
                            fDuplicata.vId_configBoleto = lTpDup[0].Id_configboletostr;
                            fDuplicata.vDs_configBoleto = lTpDup[0].Ds_configboleto;
                        }
                        if (rCond != null)
                        {
                            fDuplicata.vCd_condpgto = rCond.Cd_condpgto.Trim();
                            fDuplicata.vDs_condpgto = rCond.Ds_condpgto.Trim();
                            fDuplicata.vSt_comentrada = rCond.St_comentrada.Trim();
                            fDuplicata.vCd_juro = rCond.Cd_juro.Trim();
                            fDuplicata.vDs_juro = rCond.Ds_juro.Trim();
                            fDuplicata.vTp_juro = rCond.Tp_juro.Trim();
                            //Moeda do pedido
                            fDuplicata.vCd_moeda = val.Cd_moeda;
                            fDuplicata.vDs_moeda = val.Ds_moeda;
                            fDuplicata.vSigla_moeda = val.Sigla;

                            fDuplicata.vQt_dias_desdobro = rCond.Qt_diasdesdobro;
                            fDuplicata.vQt_parcelas = rCond.Qt_parcelas;
                            fDuplicata.vPc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                            fDuplicata.vCd_portador = rCond.Cd_portador.Trim();
                            fDuplicata.vDs_portador = rCond.Ds_portador.Trim();
                            fDuplicata.vSt_solicitardtvencto = rCond.St_solicitardtvenctobool;
                        }
                        fDuplicata.vNr_docto = rNf.Nr_notafiscal.ToString();
                        fDuplicata.vDt_emissao = rNf.Dt_saient.HasValue ? rNf.Dt_saientstring : CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vVl_documento = Vl_financeiro > decimal.Zero ? Vl_financeiro : CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CalcTotalFinNota(rNf);
                        if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            rNf.Duplicata.Clear();
                            for (int j = 0; j < fDuplicata.dsDuplicata.Count; j++)
                                rNf.Duplicata.Add(fDuplicata.dsDuplicata[j] as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                        }
                        else
                            throw new Exception("Obrigatório informar financeiro para gravar nota fiscal.");
                    }
                }
                //Verificar se a nota e de devolucao
                if (lCfgPed[0].ST_SimplesRemessa.ToString().Trim().ToUpper().Equals("S"))
                {
                    //Para cada item da nota 
                    //amarrar a nota de entrada
                    TList_LanFat_ComplementoDevolucao lista = new TList_LanFat_ComplementoDevolucao();
                    rNf.ItensNota.ForEach(v =>
                    {
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = rNf.Cd_empresa;
                            fCompDevol.Nr_pedido = rNf.Nr_pedidostring;
                            fCompDevol.Cd_produto = v.Cd_produto;
                            fCompDevol.Cd_clifor = rNf.Cd_clifor;
                            fCompDevol.Tp_operacao = "E";
                            fCompDevol.Tp_movimento = rNf.Tp_movimento;
                            fCompDevol.Quantidade = v.Quantidade;
                            fCompDevol.Valor = v.Vl_subtotal;
                            fCompDevol.lCompDevMemoria = lista;
                            if (fCompDevol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                v.lNfcompdev = fCompDevol.ListaCompDev;
                                v.lNfcompdev.ForEach(x => lista.Add(x));
                            }
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
                return rNf;
            }
            else
                throw new Exception("Não existe configuração fiscal para o pedido Nº" + val.Nr_pedido.ToString());
        }

        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessaPedFaturarServico(CamadaDados.Faturamento.Pedido.TRegistro_Pedido val,
                                                                                                            string CFG_Pedido,
                                                                                                            bool St_agruparFin,
                                                                                                            decimal Vl_financeiro)
        {
            //Buscar configuracao fiscal do pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cfg_pedido",
                        vOperador = "=",
                        vVL_Busca = "'" + CFG_Pedido.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'NO'"
                    }
                }, 1, string.Empty);
            if (lCfgPed.Count > 0)
            {
                //Objeto Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                rNf.Cd_empresa = val.CD_Empresa;
                rNf.Cd_clifor = val.CD_Clifor;
                rNf.Nm_clifor = val.NM_Clifor;
                rNf.Cd_endereco = val.CD_Endereco;
                rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
                rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNf.lCFGFiscal = lCfgPed;
                rNf.Cd_uf_empresa = val.Cd_uf_empresa;
                rNf.Uf_empresa = val.Uf_empresa;
                rNf.Cd_uf_clifor = val.Cd_uf_cliente;
                rNf.Uf_clifor = val.UF_Cliente;
                rNf.Cd_condfiscal_clifor = val.Cd_condfiscal_clifor;
                rNf.Cd_municipioexecservico = string.IsNullOrEmpty(val.Cd_municipioexecservico) ? val.CD_Cidade : val.Cd_municipioexecservico;
                rNf.Ds_municipioexecservico = string.IsNullOrEmpty(val.Cd_municipioexecservico) ? val.DS_Cidade : val.Ds_municipioexecservico;
                rNf.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                rNf.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                rNf.Cd_condpgto = string.IsNullOrEmpty(val.CD_CondPGTO) ? lCfgPed[0].CD_CondPgto : val.CD_CondPGTO;
                rNf.Nr_pedido = val.Nr_pedido;
                rNf.Tp_movimento = val.TP_Movimento;
                rNf.Tp_pessoa = val.Tp_pessoa;
                rNf.Tp_nota = (rNf.Tp_pessoa.Trim().ToUpper().Equals("J") && rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                rNf.Nr_serie = lCfgPed[0].Nr_serie;
                rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
                rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rNf.Dt_saient = rNf.Dt_emissao;
                rNf.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                     rNf.Cd_movimentacaostring,
                                                                     val.UF_Cliente.Trim().Equals(val.Uf_empresa.Trim()));
                rNf.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                               rNf.Cd_movimentacaostring,
                                                               val.UF_Cliente.Trim().Equals(val.Uf_empresa.Trim()));
                rNf.Freteporconta = val.Tp_frete;
                rNf.Cd_transportadora = val.CD_TRANSPORTADORA;
                rNf.Nm_razaosocialtransp = val.NM_TRANSPORTADORA;
                rNf.Cpf_transp = val.NR_CCG_CPF_TRANSP;
                rNf.Placaveiculo = val.Placaveiculo;
                //Abrir tela para capturar dados da nota fiscal            
                using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                {
                    fNumero.pCd_empresa = rNf.Cd_empresa;
                    fNumero.pNm_empresa = rNf.Nm_empresa;
                    fNumero.pCd_clifor = rNf.Cd_clifor;
                    fNumero.pNm_clifor = rNf.Nm_clifor;
                    fNumero.pTp_pessoa = rNf.Tp_pessoa;
                    fNumero.pTp_movimento = rNf.Tp_movimento;
                    fNumero.pTp_nota = rNf.Tp_nota;
                    fNumero.pChave_Acesso_NFe = rNf.Chave_acesso_nfe;
                    fNumero.pNr_serie = rNf.Nr_serie;
                    fNumero.pDs_serie = rNf.Ds_serienf;
                    fNumero.pCd_modelo = rNf.Cd_modelo;
                    fNumero.pDt_emissao = rNf.Dt_emissao;
                    fNumero.pST_NotaUnica = false;
                    fNumero.pNr_notafiscal = rNf.Nr_notafiscal.HasValue ? rNf.Nr_notafiscal.Value.ToString() : string.Empty;
                    fNumero.pDt_saient = rNf.Dt_saient;
                    fNumero.pDs_dadosadic = rNf.Dadosadicionais;
                    fNumero.pDs_obsfiscal = rNf.Obsfiscal;
                    fNumero.pSt_sequenciaauto = rNf.St_sequenciaauto;
                    fNumero.pCd_movto = rNf.Cd_movimentacaostring;
                    fNumero.pCd_cmi = rNf.Cd_cmistring;
                    if (rNf.Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        //Buscar inscricao estadual do clifor da nota
                        object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                            new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_clifor.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_endereco",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_endereco.Trim() + "'"
                                                        }
                                                    }, "a.insc_estadual");
                        fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                    }
                    fNumero.pTp_frete = rNf.Freteporconta;
                    fNumero.pCd_transportadora = rNf.Cd_transportadora;
                    fNumero.pNm_transportadora = rNf.Nm_razaosocialtransp;
                    fNumero.pCnpjCpfTransp = rNf.Cpf_transp;
                    fNumero.pPlacaVeiculo = rNf.Placaveiculo;
                    fNumero.pVl_frete = val.Pedido_Itens.Sum(p => p.Vl_freteitem);
                    if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rNf.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                        if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                            rNf.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                        else
                            rNf.Nr_notafiscal = null;
                        rNf.Nr_serie = fNumero.pNr_serie;
                        rNf.Cd_modelo = fNumero.pCd_modelo;
                        rNf.Dt_emissao = fNumero.pDt_emissao;
                        rNf.Dt_saient = fNumero.pDt_saient;
                        rNf.Obsfiscal = fNumero.pDs_obsfiscal;
                        rNf.Dadosadicionais = fNumero.pDs_dadosadic;
                        rNf.Cd_transportadora = fNumero.pCd_transportadora;
                        rNf.Cd_enderecotransp = fNumero.pCd_endtransportadora;
                        rNf.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                        rNf.Cpf_transp = fNumero.pCnpjCpfTransp;
                        rNf.Placaveiculo = fNumero.pPlacaVeiculo;
                        rNf.Freteporconta = fNumero.pTp_frete;
                        rNf.Especie = fNumero.pEspecie;
                        rNf.Quantidade = fNumero.pQuantidade;
                        rNf.Pesobruto = fNumero.pPsbruto;
                        rNf.Pesoliquido = fNumero.pPsliquido;
                        rNf.Vl_frete = fNumero.pVl_frete;
                        rNf.Cd_municipioexecservico = fNumero.pCd_municipioexecservico;
                        rNf.Ds_municipioexecservico = fNumero.pNm_municipioexecservico;
                        rNf.Cd_ufsaidaex = fNumero.pCd_ufsaidaex;
                        rNf.Ds_ufsaidaex = fNumero.pDs_ufsaidaex;
                        rNf.Uf_saidaex = fNumero.pUf_saidaex;
                        rNf.Ds_localex = fNumero.pDs_localex;
                        if (rNf.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                            rNf.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                            {
                                St_compdevimposto = rCmi.St_compdevimposto,
                                St_complementar = rCmi.St_complementar,
                                St_devolucao = rCmi.St_devolucao,
                                St_geraestoque = rCmi.St_geraestoque,
                                St_mestra = rCmi.St_mestra,
                                St_simplesremessa = rCmi.St_simplesremessa,
                                St_retorno = rCmi.St_retorno
                            });
                            rNf.Cd_cmistring = fNumero.pCd_cmi;
                            rNf.Ds_cmi = rCmi.Ds_cmi;
                            rNf.Tp_duplicata = rCmi.Tp_duplicata;
                            rNf.Ds_tpduplicata = rCmi.ds_tpduplicata;
                        }
                    }
                    else
                        throw new Exception("Obrigatorio informar numero da nota fiscal.");
                }
                if (rNf.Nr_notafiscal.HasValue)
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNf.Nr_notafiscal.ToString(),
                                                                                                 rNf.Nr_serie,
                                                                                                 rNf.Cd_empresa,
                                                                                                 rNf.Cd_clifor,
                                                                                                 string.Empty,
                                                                                                 rNf.Tp_nota,
                                                                                                 null);
                    if (rFat != null)
                        if (rFat.St_registro.Trim().ToUpper().Equals("C"))
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra cancelada.\r\n" +
                                                "Para poder utilizar o mesmo numero e necessario excluir a nota fiscal cancelada.\r\n" +
                                                "Dica: Menu FATURAMENTO->Emissão de Notas Fiscais / NFe, localize a nota fiscal cancelada e exclua a mesma.\r\n" +
                                                "Obs.: Para excluir a nota fiscal cancelada é necessario que o usuario tenha permissão.");
                        else
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra ativa.\r\n" +
                                                "Não é permitido gerar nota fiscal com mesmo numero.");
                }
                val.Pedido_Itens.ForEach(item =>
                {
                    //Item da nota fiscal
                    if (lCfgPed[0].Tp_serie.Trim().ToUpper().Equals("S") && (item.St_servico))
                    {
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                        rItem.Cd_empresa = val.CD_Empresa;
                        rItem.Cd_produto = item.Cd_produto;
                        rItem.Cd_local = item.Cd_local;
                        rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                        rItem.Cd_unidade = item.Cd_unidade_valor;
                        rItem.Cd_unidEst = item.Cd_unidade_est;
                        rItem.Nr_pedido = val.Nr_pedido;
                        rItem.Cd_vendedor = val.Cd_vendedor;
                        rItem.Id_pedidoitem = item.Id_pedidoitem;
                        rItem.Quantidade = item.Quantidade;
                        rItem.Quantidade_estoque = item.Quantidade;
                        rItem.Vl_subtotal = item.Vl_subtotal;
                        rItem.Vl_subtotal_estoque = item.Vl_subtotal;
                        rItem.Vl_unitario = item.Vl_unitario;
                        rItem.Pc_desconto = item.Pc_desc;
                        rItem.Vl_desconto = item.Vl_desc;
                        rItem.Vl_freteitem = item.Vl_freteitem;
                        rItem.Pc_juro_fin = item.Pc_juro_fin;
                        rItem.Vl_juro_fin = item.Vl_juro_fin;
                        rItem.Vl_outrasdesp = item.Vl_acrescimo;
                        rItem.Pc_imposto_Aprox = item.Pc_imposto_Aprox;
                        rItem.Observacao_item = item.Ds_observacaoitem;
                        //Buscar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                           item.Cd_condfiscal_produto,
                                                                           val.Cd_uf_cliente.Trim().Equals("99") ? "I" : val.Cd_uf_cliente.Trim().Equals(val.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                           rNf.Tp_movimento,
                                                                           rNf.Cd_condfiscal_clifor,
                                                                           rNf.Cd_empresa,
                                                                           ref rCfop,
                                                                           null))
                        {
                            rItem.Cd_cfop = rCfop.CD_CFOP;
                            rItem.Ds_cfop = rCfop.DS_CFOP;
                            rItem.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (val.Cd_uf_cliente.Trim().Equals("99") ? "I" : val.Cd_uf_cliente.Trim().Equals(val.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNf.Cd_empresa,
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                                              rNf.Cd_movimentacaostring,
                                                                                                              rNf.Tp_movimento,
                                                                                                              rNf.Cd_condfiscal_clifor,
                                                                                                              rItem.Cd_condfiscal_produto,
                                                                                                              rItem.Vl_subtotal,
                                                                                                              rItem.Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rNf.Dt_emissao,
                                                                                                              rItem.Cd_produto,
                                                                                                              rNf.Tp_nota,
                                                                                                              rNf.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                        {
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItem);
                            rNf.Obsfiscal += vObsFiscal.Trim();
                        }
                        else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, rNf.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + rNf.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + rNf.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + rNf.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_clifor.Trim() : rNf.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_empresa.Trim() : rNf.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                                                                       rItem.Cd_condfiscal_produto,
                                                                                                                       rNf.Cd_movimentacaostring,
                                                                                                                       rNf.Tp_movimento,
                                                                                                                       rNf.Tp_pessoa,
                                                                                                                       rNf.Cd_empresa,
                                                                                                                       rNf.Nr_serie,
                                                                                                                       rNf.Cd_clifor,
                                                                                                                       rItem.Cd_unidEst,
                                                                                                                       rNf.Dt_emissao,
                                                                                                                       rItem.Quantidade,
                                                                                                                       rItem.Vl_subtotal,
                                                                                                                       rNf.Tp_nota,
                                                                                                                       rNf.Cd_municipioexecservico,
                                                                                                                       null), rItem, rNf.Tp_movimento);
                        string obs_ret = string.Empty;
                        string linha = string.Empty;
                        if (rItem.Vl_ICMSRetido > decimal.Zero)
                        {
                            obs_ret += linha + "ICMS RETIDO " + rItem.Vl_ICMSRetido.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCofins > decimal.Zero)
                        {
                            obs_ret += linha + "COFINS RETIDO " + rItem.Vl_retidoCofins.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCSLL > decimal.Zero)
                        {
                            obs_ret += linha + "CSLL RETIDO " + rItem.Vl_retidoCSLL.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoFunrural > decimal.Zero)
                        {
                            obs_ret += linha + "FUNRURAL RETIDO " + rItem.Vl_retidoFunrural.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoINSS > decimal.Zero)
                        {
                            obs_ret += linha + "INSS RETIDO " + rItem.Vl_retidoINSS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoIRRF > decimal.Zero)
                        {
                            obs_ret += linha + "IRFF RETIDO " + rItem.Vl_retidoIRRF.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoPIS > decimal.Zero)
                        {
                            obs_ret += linha + "PIS RETIDO " + rItem.Vl_retidoPIS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoSenar > decimal.Zero)
                        {
                            obs_ret += linha + "SENAR RETIDO " + rItem.Vl_retidoSenar.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (!string.IsNullOrEmpty(obs_ret))
                            rNf.Obsfiscal += (string.IsNullOrEmpty(rNf.Obsfiscal) ? string.Empty : "\r\n") + obs_ret.Trim();
                        rNf.ItensNota.Add(rItem);
                    }
                });
                //Gerar financeiro
                if ((!string.IsNullOrEmpty(rNf.Tp_duplicata)) &&
                    (St_agruparFin ? Vl_financeiro > decimal.Zero : true))
                {
                    //Buscar historico da movimentacao
                    CamadaDados.Fiscal.TList_CadMovimentacao lMov = new CamadaDados.Fiscal.TCD_CadMovimentacao().Select(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_movimentacao",
                                                                            vVL_Busca = "'" + rNf.Cd_movimentacaostring + "'",
                                                                            vOperador = "="
                                                                        }
                                                                    }, 1, string.Empty);

                    //Buscar Configurações da Condição de Pagamento
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond = null;
                    if (!string.IsNullOrEmpty(rNf.Cd_condpgto))
                        rCond = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rNf.Cd_condpgto,
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
                                                                                          null)[0];
                    //buscar tipo duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadTpDuplicata.Buscar(rNf.Tp_duplicata.ToString().Trim(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                    //Abrir tela de lançamento de duplicata
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        fDuplicata.vNr_pedido = val.Nr_pedido;
                        fDuplicata.vSt_notafiscal = true;
                        fDuplicata.vCd_empresa = rNf.Cd_empresa.Trim();
                        fDuplicata.vNm_empresa = rNf.Nm_empresa.Trim();
                        fDuplicata.vCd_clifor = rNf.Cd_clifor.Trim();
                        fDuplicata.vNm_clifor = rNf.Nm_clifor.Trim();
                        fDuplicata.vCd_endereco = rNf.Cd_endereco.Trim();
                        fDuplicata.vDs_endereco = rNf.Ds_endereco.Trim();
                        if (lMov.Count > 0)
                        {
                            fDuplicata.vCd_historico = lMov[0].cd_historico;
                            fDuplicata.vDs_historico = lMov[0].ds_historico;
                        }
                        //Dados CMI
                        fDuplicata.vTp_duplicata = lTpDup[0].Tp_duplicata.Trim();
                        fDuplicata.vDs_tpduplicata = lTpDup[0].Ds_tpduplicata.Trim();
                        fDuplicata.vTp_mov = rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                      rNf.Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                        fDuplicata.vTp_docto = rNf.lCFGFiscal[0].Tp_docto.HasValue ? rNf.lCFGFiscal[0].Tp_docto.Value.ToString() : string.Empty;
                        //Configuracao para emissao de bloqueto automaticamente
                        if (lTpDup[0].Id_configboleto.HasValue)
                        {
                            fDuplicata.vId_configBoleto = lTpDup[0].Id_configboletostr;
                            fDuplicata.vDs_configBoleto = lTpDup[0].Ds_configboleto;
                        }
                        if (rCond != null)
                        {
                            fDuplicata.vCd_condpgto = rCond.Cd_condpgto.Trim();
                            fDuplicata.vDs_condpgto = rCond.Ds_condpgto.Trim();
                            fDuplicata.vSt_comentrada = rCond.St_comentrada.Trim();
                            fDuplicata.vCd_juro = rCond.Cd_juro.Trim();
                            fDuplicata.vDs_juro = rCond.Ds_juro.Trim();
                            fDuplicata.vTp_juro = rCond.Tp_juro.Trim();
                            //Moeda do pedido
                            fDuplicata.vCd_moeda = val.Cd_moeda;
                            fDuplicata.vDs_moeda = val.Ds_moeda;
                            fDuplicata.vSigla_moeda = val.Sigla;

                            fDuplicata.vQt_dias_desdobro = rCond.Qt_diasdesdobro;
                            fDuplicata.vQt_parcelas = rCond.Qt_parcelas;
                            fDuplicata.vPc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                            fDuplicata.vCd_portador = rCond.Cd_portador.Trim();
                            fDuplicata.vDs_portador = rCond.Ds_portador.Trim();
                            fDuplicata.vSt_solicitardtvencto = rCond.St_solicitardtvenctobool;
                        }
                        fDuplicata.vNr_docto = rNf.Nr_notafiscal.ToString();
                        fDuplicata.vDt_emissao = rNf.Dt_saient.HasValue ? rNf.Dt_saientstring : CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vVl_documento = Vl_financeiro > decimal.Zero ? Vl_financeiro : CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CalcTotalFinNota(rNf);
                        if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            rNf.Duplicata.Clear();
                            for (int j = 0; j < fDuplicata.dsDuplicata.Count; j++)
                                rNf.Duplicata.Add(fDuplicata.dsDuplicata[j] as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                        }
                        else
                            throw new Exception("Obrigatório informar financeiro para gravar nota fiscal.");
                    }
                }
                //Verificar se a nota e de devolucao
                if (lCfgPed[0].ST_SimplesRemessa.ToString().Trim().ToUpper().Equals("S"))
                {
                    //Para cada item da nota 
                    //amarrar a nota de entrada
                    rNf.ItensNota.ForEach(v =>
                    {
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = rNf.Cd_empresa;
                            fCompDevol.Nr_pedido = rNf.Nr_pedidostring;
                            fCompDevol.Cd_produto = v.Cd_produto;
                            fCompDevol.Cd_clifor = rNf.Cd_clifor;
                            fCompDevol.Tp_operacao = "E";
                            fCompDevol.Tp_movimento = rNf.Tp_movimento;
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
                return rNf;
            }
            else
                throw new Exception( "Não existe configuração fiscal " + (string.IsNullOrEmpty(val.Cd_cliforent) ? string.Empty : "REMESSA P/ TRANSPORTE ") + "para o pedido Nº" + val.Nr_pedido.ToString());
        }


        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessaPedFaturarServicoEmpreendimento(CamadaDados.Empreendimento.TRegistro_Orcamento rOrc,
                                                                                                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                                                                                            CamadaDados.Empreendimento.Cadastro.TList_CadCFGEmpreendimento cfg,
                                                                                                            CamadaDados.Empreendimento.TList_FichaTec lFicha,
                                                                                                            string CFG_Pedido,
                                                                                                            bool St_agruparFin,
                                                                                                            decimal Vl_financeiro)
        { 
            //Buscar configuracao fiscal do pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cfg_pedido",
                        vOperador = "=",
                        vVL_Busca = "'" + CFG_Pedido.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'NO'"
                    }
                }, 1, string.Empty);
            if (lCfgPed.Count > 0)
            {
                //Objeto Nota Fiscal
                //Objeto Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                rNf.Nr_pedidostring = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                rNf.Cd_empresa = rPed.CD_Empresa;
                rNf.Cd_clifor = rPed.CD_Clifor;
                rNf.Nm_clifor = rPed.NM_Clifor;
                rNf.Cd_endereco = rPed.CD_Endereco;
                rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
                rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNf.lCFGFiscal = lCfgPed;
                rNf.Cd_uf_empresa = rPed.Cd_uf_empresa;
                rNf.Uf_empresa = rPed.Uf_empresa;
                rNf.Cd_uf_clifor = rPed.Cd_uf_cliente;
                rNf.Uf_clifor = rPed.UF_Cliente;
                rNf.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                rNf.Cd_municipioexecservico = string.IsNullOrEmpty(rPed.Cd_municipioexecservico) ? rPed.CD_Cidade : rPed.Cd_municipioexecservico;
                rNf.Ds_municipioexecservico = string.IsNullOrEmpty(rPed.Cd_municipioexecservico) ? rPed.DS_Cidade : rPed.Ds_municipioexecservico;
                rNf.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                rNf.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                rNf.Cd_condpgto = string.IsNullOrEmpty(rPed.CD_CondPGTO) ? lCfgPed[0].CD_CondPgto : rPed.CD_CondPGTO;
                rNf.Nr_pedido = rPed.Nr_pedido;
                rNf.Tp_movimento = rPed.TP_Movimento;
                rNf.Tp_pessoa = rPed.Tp_pessoa;
                rNf.Tp_nota = (rNf.Tp_pessoa.Trim().ToUpper().Equals("J") && rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                rNf.Nr_serie = lCfgPed[0].Nr_serie;
                rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
                rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rNf.Dt_saient = rNf.Dt_emissao;
                rNf.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                     rNf.Cd_movimentacaostring,
                                                                     rPed.UF_Cliente.Trim().Equals(rPed.Uf_empresa.Trim()));
                rNf.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                               rNf.Cd_movimentacaostring,
                                                               rPed.UF_Cliente.Trim().Equals(rPed.Uf_empresa.Trim()));
                rNf.Freteporconta = rPed.Tp_frete;
                rNf.Cd_transportadora = rPed.CD_TRANSPORTADORA;
                rNf.Nm_razaosocialtransp = rPed.NM_TRANSPORTADORA;
                rNf.Cpf_transp = rPed.NR_CCG_CPF_TRANSP;
                rNf.Placaveiculo = rPed.Placaveiculo;
                //Abrir tela para capturar dados da nota fiscal            
                using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                {
                    fNumero.pCd_empresa = rNf.Cd_empresa;
                    fNumero.pNm_empresa = rNf.Nm_empresa;
                    fNumero.pCd_clifor = rNf.Cd_clifor;
                    fNumero.pNm_clifor = rNf.Nm_clifor;
                    fNumero.pTp_pessoa = rNf.Tp_pessoa;
                    fNumero.pTp_movimento = rNf.Tp_movimento;
                    fNumero.pTp_nota = rNf.Tp_nota;
                    fNumero.pChave_Acesso_NFe = rNf.Chave_acesso_nfe;
                    fNumero.pNr_serie = rNf.Nr_serie;
                    fNumero.pDs_serie = rNf.Ds_serienf;
                    fNumero.pCd_modelo = rNf.Cd_modelo;
                    fNumero.pDt_emissao = rNf.Dt_emissao;
                    fNumero.pST_NotaUnica = false;
                    fNumero.pNr_notafiscal = rNf.Nr_notafiscal.HasValue ? rNf.Nr_notafiscal.Value.ToString() : string.Empty;
                    fNumero.pDt_saient = rNf.Dt_saient;
                    fNumero.pDs_dadosadic = rNf.Dadosadicionais;
                    fNumero.pDs_obsfiscal = rNf.Obsfiscal;
                    fNumero.pSt_sequenciaauto = rNf.St_sequenciaauto;
                    fNumero.pCd_movto = rNf.Cd_movimentacaostring;
                    fNumero.pCd_cmi = rNf.Cd_cmistring;
                    if (rNf.Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        //Buscar inscricao estadual do clifor da nota
                        object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                            new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_clifor.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_endereco",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNf.Cd_endereco.Trim() + "'"
                                                        }
                                                    }, "a.insc_estadual");
                        fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                    }
                    fNumero.pTp_frete = rNf.Freteporconta;
                    fNumero.pCd_transportadora = rNf.Cd_transportadora;
                    fNumero.pNm_transportadora = rNf.Nm_razaosocialtransp;
                    fNumero.pCnpjCpfTransp = rNf.Cpf_transp;
                    fNumero.pPlacaVeiculo = rNf.Placaveiculo;
                    fNumero.pVl_frete = rPed.Pedido_Itens.Sum(p => p.Vl_freteitem);
                    if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rNf.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                        if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                            rNf.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                        else
                            rNf.Nr_notafiscal = null;
                        rNf.Nr_serie = fNumero.pNr_serie;
                        rNf.Cd_modelo = fNumero.pCd_modelo;
                        rNf.Dt_emissao = fNumero.pDt_emissao;
                        rNf.Dt_saient = fNumero.pDt_saient;
                        rNf.Obsfiscal = fNumero.pDs_obsfiscal;
                        rNf.Dadosadicionais = fNumero.pDs_dadosadic;
                        rNf.Cd_transportadora = fNumero.pCd_transportadora;
                        rNf.Cd_enderecotransp = fNumero.pCd_endtransportadora;
                        rNf.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                        rNf.Cpf_transp = fNumero.pCnpjCpfTransp;
                        rNf.Placaveiculo = fNumero.pPlacaVeiculo;
                        rNf.Freteporconta = fNumero.pTp_frete;
                        rNf.Especie = fNumero.pEspecie;
                        rNf.Quantidade = fNumero.pQuantidade;
                        rNf.Pesobruto = fNumero.pPsbruto;
                        rNf.Pesoliquido = fNumero.pPsliquido;
                        rNf.Vl_frete = fNumero.pVl_frete;
                        rNf.Cd_municipioexecservico = fNumero.pCd_municipioexecservico;
                        rNf.Ds_municipioexecservico = fNumero.pNm_municipioexecservico;
                        rNf.Cd_ufsaidaex = fNumero.pCd_ufsaidaex;
                        rNf.Ds_ufsaidaex = fNumero.pDs_ufsaidaex;
                        rNf.Uf_saidaex = fNumero.pUf_saidaex;
                        rNf.Ds_localex = fNumero.pDs_localex;
                        if (rNf.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                            rNf.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                            {
                                St_compdevimposto = rCmi.St_compdevimposto,
                                St_complementar = rCmi.St_complementar,
                                St_devolucao = rCmi.St_devolucao,
                                St_geraestoque = rCmi.St_geraestoque,
                                St_mestra = rCmi.St_mestra,
                                St_simplesremessa = rCmi.St_simplesremessa,
                                St_retorno = rCmi.St_retorno
                            });
                            rNf.Cd_cmistring = fNumero.pCd_cmi;
                            rNf.Ds_cmi = rCmi.Ds_cmi;
                            rNf.Tp_duplicata = rCmi.Tp_duplicata;
                            rNf.Ds_tpduplicata = rCmi.ds_tpduplicata;
                        }
                    }
                    else
                        throw new Exception("Obrigatorio informar numero da nota fiscal.");
                }
                if (rNf.Nr_notafiscal.HasValue)
                {
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNf.Nr_notafiscal.ToString(),
                                                                                                 rNf.Nr_serie,
                                                                                                 rNf.Cd_empresa,
                                                                                                 rNf.Cd_clifor,
                                                                                                 string.Empty,
                                                                                                 rNf.Tp_nota,
                                                                                                 null);
                    if (rFat != null)
                        if (rFat.St_registro.Trim().ToUpper().Equals("C"))
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra cancelada.\r\n" +
                                                "Para poder utilizar o mesmo numero e necessario excluir a nota fiscal cancelada.\r\n" +
                                                "Dica: Menu FATURAMENTO->Emissão de Notas Fiscais / NFe, localize a nota fiscal cancelada e exclua a mesma.\r\n" +
                                                "Obs.: Para excluir a nota fiscal cancelada é necessario que o usuario tenha permissão.");
                        else
                            throw new Exception("Nota Fiscal Nº " + rFat.Nr_notafiscal.ToString() + " ja existe no sistema e se encontra ativa.\r\n" +
                                                "Não é permitido gerar nota fiscal com mesmo numero.");
                }
                rPed.Pedido_Itens.ForEach(item =>
                {
                    //Item da nota fiscal
                    if (lCfgPed[0].Tp_serie.Trim().ToUpper().Equals("S") && (item.St_servico))
                    {
                        TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                        rItem.Cd_empresa = rPed.CD_Empresa;
                        if (item.ImpostosItens.Exists(v => v.Imposto.St_ICMS))
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(item.ImpostosItens.Find(v => v.Imposto.St_ICMS), rItem);
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(item.ImpostosItens, rItem, rNf.Tp_movimento);
                        rItem.Cd_produto = item.Cd_produto;
                        rItem.Cd_local = item.Cd_local;
                        rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                        rItem.Cd_unidade = item.Cd_unidade_valor;
                        rItem.Cd_unidEst = item.Cd_unidade_est;
                        rItem.Nr_pedido = rPed.Nr_pedido;
                        rItem.Cd_vendedor = rPed.Cd_vendedor;
                        rItem.Id_pedidoitem = item.Id_pedidoitem;
                        rItem.Quantidade = item.Quantidade;
                        rItem.Quantidade_estoque = item.Quantidade;
                        rItem.Vl_subtotal = item.Vl_subtotal;
                        rItem.Vl_subtotal_estoque = item.Vl_subtotal;
                        rItem.Vl_unitario = item.Vl_unitario;
                        rItem.Pc_desconto = item.Pc_desc;
                        rItem.Vl_desconto = item.Vl_desc;
                        rItem.Vl_freteitem = item.Vl_freteitem;
                        rItem.Pc_juro_fin = item.Pc_juro_fin;
                        rItem.Vl_juro_fin = item.Vl_juro_fin;
                        rItem.Vl_outrasdesp = item.Vl_acrescimo;
                        rItem.Pc_imposto_Aprox = item.Pc_imposto_Aprox;
                        rItem.Observacao_item = item.Ds_observacaoitem;
                        //Buscar cfop do item
                        CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                        if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                           item.Cd_condfiscal_produto,
                                                                           rPed.Cd_uf_cliente.Trim().Equals("99") ? "I" : rPed.Cd_uf_cliente.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                           (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                           rNf.Tp_movimento,
                                                                           rNf.Cd_condfiscal_clifor,
                                                                           rNf.Cd_empresa,
                                                                           ref rCfop,
                                                                           null))
                        {
                            rItem.Cd_cfop = rCfop.CD_CFOP;
                            rItem.Ds_cfop = rCfop.DS_CFOP;
                            rItem.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (rPed.Cd_uf_cliente.Trim().Equals("99") ? "I" : rPed.Cd_uf_cliente.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        TList_ImpostosNF lImpUf =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNf.Cd_empresa,
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                                              (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                                              rNf.Cd_movimentacaostring,
                                                                                                              rNf.Tp_movimento,
                                                                                                              rNf.Cd_condfiscal_clifor,
                                                                                                              rItem.Cd_condfiscal_produto,
                                                                                                              rItem.Vl_subtotal,
                                                                                                              rItem.Quantidade,
                                                                                                              ref vObsFiscal,
                                                                                                              rNf.Dt_emissao,
                                                                                                              rItem.Cd_produto,
                                                                                                              rNf.Tp_nota,
                                                                                                              rNf.Nr_serie,
                                                                                                              null);
                        if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                        {
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItem);
                            rNf.Obsfiscal += vObsFiscal.Trim();
                        }
                        else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, rNf.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + rNf.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + rNf.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + rNf.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_clifor.Trim() : rNf.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_empresa.Trim() : rNf.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                                                                       rItem.Cd_condfiscal_produto,
                                                                                                                       rNf.Cd_movimentacaostring,
                                                                                                                       rNf.Tp_movimento,
                                                                                                                       rNf.Tp_pessoa,
                                                                                                                       rNf.Cd_empresa,
                                                                                                                       rNf.Nr_serie,
                                                                                                                       rNf.Cd_clifor,
                                                                                                                       rItem.Cd_unidEst,
                                                                                                                       rNf.Dt_emissao,
                                                                                                                       rItem.Quantidade,
                                                                                                                       rItem.Vl_subtotal,
                                                                                                                       rNf.Tp_nota,
                                                                                                                       rNf.Cd_municipioexecservico,
                                                                                                                       null), rItem, rNf.Tp_movimento);
                        string obs_ret = string.Empty;
                        string linha = string.Empty;
                        if (rItem.Vl_ICMSRetido > decimal.Zero)
                        {
                            obs_ret += linha + "ICMS RETIDO " + rItem.Vl_ICMSRetido.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCofins > decimal.Zero)
                        {
                            obs_ret += linha + "COFINS RETIDO " + rItem.Vl_retidoCofins.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoCSLL > decimal.Zero)
                        {
                            obs_ret += linha + "CSLL RETIDO " + rItem.Vl_retidoCSLL.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoFunrural > decimal.Zero)
                        {
                            obs_ret += linha + "FUNRURAL RETIDO " + rItem.Vl_retidoFunrural.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoINSS > decimal.Zero)
                        {
                            obs_ret += linha + "INSS RETIDO " + rItem.Vl_retidoINSS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoIRRF > decimal.Zero)
                        {
                            obs_ret += linha + "IRFF RETIDO " + rItem.Vl_retidoIRRF.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoPIS > decimal.Zero)
                        {
                            obs_ret += linha + "PIS RETIDO " + rItem.Vl_retidoPIS.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (rItem.Vl_retidoSenar > decimal.Zero)
                        {
                            obs_ret += linha + "SENAR RETIDO " + rItem.Vl_retidoSenar.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                            linha = "\r\n";
                        }
                        if (!string.IsNullOrEmpty(obs_ret))
                            rNf.Obsfiscal += (string.IsNullOrEmpty(rNf.Obsfiscal) ? string.Empty : "\r\n") + obs_ret.Trim();
                        rNf.ItensNota.Add(rItem);
                    }
                });
                //Gerar financeiro
                if ((!string.IsNullOrEmpty(rNf.Tp_duplicata)) &&
                    (St_agruparFin ? Vl_financeiro > decimal.Zero : true))
                {
                    //Buscar historico da movimentacao
                    CamadaDados.Fiscal.TList_CadMovimentacao lMov = new CamadaDados.Fiscal.TCD_CadMovimentacao().Select(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_movimentacao",
                                                                            vVL_Busca = "'" + rNf.Cd_movimentacaostring + "'",
                                                                            vOperador = "="
                                                                        }
                                                                    }, 1, string.Empty);

                    //Buscar Configurações da Condição de Pagamento
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond = null;
                    if (!string.IsNullOrEmpty(rNf.Cd_condpgto))
                        rCond = CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(rNf.Cd_condpgto,
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
                                                                                          null)[0];
                    //buscar tipo duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadTpDuplicata.Buscar(rNf.Tp_duplicata.ToString().Trim(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                    //Abrir tela de lançamento de duplicata
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        fDuplicata.vNr_pedido = rPed.Nr_pedido;
                        fDuplicata.vSt_notafiscal = true;
                        fDuplicata.vCd_empresa = rNf.Cd_empresa.Trim();
                        fDuplicata.vNm_empresa = rNf.Nm_empresa.Trim();
                        fDuplicata.vCd_clifor = rNf.Cd_clifor.Trim();
                        fDuplicata.vNm_clifor = rNf.Nm_clifor.Trim();
                        fDuplicata.vCd_endereco = rNf.Cd_endereco.Trim();
                        fDuplicata.vDs_endereco = rNf.Ds_endereco.Trim();
                        if (lMov.Count > 0)
                        {
                            fDuplicata.vCd_historico = lMov[0].cd_historico;
                            fDuplicata.vDs_historico = lMov[0].ds_historico;
                        }
                        //Dados CMI
                        fDuplicata.vTp_duplicata = lTpDup[0].Tp_duplicata.Trim();
                        fDuplicata.vDs_tpduplicata = lTpDup[0].Ds_tpduplicata.Trim();
                        fDuplicata.vTp_mov = rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "P" :
                                      rNf.Tp_movimento.Trim().ToUpper().Equals("S") ? "R" : string.Empty;
                        fDuplicata.vTp_docto = rNf.lCFGFiscal[0].Tp_docto.HasValue ? rNf.lCFGFiscal[0].Tp_docto.Value.ToString() : string.Empty;
                        //Configuracao para emissao de bloqueto automaticamente
                        if (lTpDup[0].Id_configboleto.HasValue)
                        {
                            fDuplicata.vId_configBoleto = lTpDup[0].Id_configboletostr;
                            fDuplicata.vDs_configBoleto = lTpDup[0].Ds_configboleto;
                        }
                        if (rCond != null)
                        {
                            fDuplicata.vCd_condpgto = rCond.Cd_condpgto.Trim();
                            fDuplicata.vDs_condpgto = rCond.Ds_condpgto.Trim();
                            fDuplicata.vSt_comentrada = rCond.St_comentrada.Trim();
                            fDuplicata.vCd_juro = rCond.Cd_juro.Trim();
                            fDuplicata.vDs_juro = rCond.Ds_juro.Trim();
                            fDuplicata.vTp_juro = rCond.Tp_juro.Trim();
                            //Moeda do pedido
                            fDuplicata.vCd_moeda = rPed.Cd_moeda;
                            fDuplicata.vDs_moeda = rPed.Ds_moeda;
                            fDuplicata.vSigla_moeda = rPed.Sigla;

                            fDuplicata.vQt_dias_desdobro = rCond.Qt_diasdesdobro;
                            fDuplicata.vQt_parcelas = rCond.Qt_parcelas;
                            fDuplicata.vPc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                            fDuplicata.vCd_portador = rCond.Cd_portador.Trim();
                            fDuplicata.vDs_portador = rCond.Ds_portador.Trim();
                            fDuplicata.vSt_solicitardtvencto = rCond.St_solicitardtvenctobool;
                        }
                        fDuplicata.vNr_docto = rNf.Nr_notafiscal.ToString() + " O:" + rOrc.Id_orcamentostr + " V:"+rOrc.Nr_versaostr;
                        fDuplicata.vDt_emissao = rNf.Dt_saient.HasValue ? rNf.Dt_saientstring : CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vVl_documento =   CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CalcTotalFinNota(rNf);
                        if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            rNf.Duplicata.Clear();
                            for (int j = 0; j < fDuplicata.dsDuplicata.Count; j++)
                                rNf.Duplicata.Add(fDuplicata.dsDuplicata[j] as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                           


                        }
                        else
                            throw new Exception("Obrigatório informar financeiro para gravar nota fiscal.");
                    }
                }
                //Verificar se a nota e de devolucao
                if (lCfgPed[0].ST_SimplesRemessa.ToString().Trim().ToUpper().Equals("S"))
                {
                    //Para cada item da nota 
                    //amarrar a nota de entrada
                    rNf.ItensNota.ForEach(v =>
                    {
                        using (TFLanCompDevol_NF fCompDevol = new TFLanCompDevol_NF())
                        {
                            fCompDevol.Cd_empresa = rNf.Cd_empresa;
                            fCompDevol.Nr_pedido = rNf.Nr_pedidostring;
                            fCompDevol.Cd_produto = v.Cd_produto;
                            fCompDevol.Cd_clifor = rNf.Cd_clifor;
                            fCompDevol.Tp_operacao = "E";
                            fCompDevol.Tp_movimento = rNf.Tp_movimento;
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
                rNf.Nr_pedido = rPed.Nr_pedido;
                return rNf;
            }
            else
                throw new Exception("Não existe configuração fiscal " + (string.IsNullOrEmpty(rPed.Cd_cliforent) ? string.Empty : "REMESSA P/ TRANSPORTE ") + "para o pedido Nº" + rPed.Nr_pedido.ToString());
        }
    }
}
