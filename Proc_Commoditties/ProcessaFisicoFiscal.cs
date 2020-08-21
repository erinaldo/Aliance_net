using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Proc_Commoditties
{
    public class TProcessaFisicoFiscal
    {
        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento ProcessarFisicoFiscal(CamadaDados.Balanca.TRegistro_PedidoAplicacao rPed,
                                                                                                       List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lDev,
                                                                                                       List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lCom)
        {
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            if (rPed != null)
            {
                #region Nota Devolucao
                if (lDev != null)
                    if(lDev.Count > 0)
                    {
                        //Buscar configuracao fiscal do pedido
                        CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                "where x.cfg_pedido = a.cfg_pedido " +
                                                "and x.nr_pedido = " + rPed.Nr_pedidostring + ")"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'DF'"
                                }
                            }, 1, string.Empty);
                        if (lCfgPed.Count > 0)
                        {
                            //Objeto Nota Fiscal de Devolução
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfDev = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                            rNfDev.Cd_empresa = rPed.Cd_empresa;
                            rNfDev.Cd_clifor = rPed.Cd_clifor;
                            rNfDev.Nm_clifor = rPed.Nm_clifor;
                            rNfDev.Cd_endereco = rPed.Cd_endereco;
                            rNfDev.Cd_cmi = lCfgPed[0].Cd_cmi;
                            rNfDev.Cd_movimentacao = lCfgPed[0].Cd_movto;
                            rNfDev.lCFGFiscal = lCfgPed;
                            rNfDev.Cd_uf_empresa = rPed.Cd_uf_empresa;
                            rNfDev.Uf_empresa = rPed.Uf_empresa;
                            rNfDev.Cd_uf_clifor = rPed.Cd_uf_clifor;
                            rNfDev.Uf_clifor = rPed.Uf_clifor;
                            rNfDev.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                            rNfDev.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                            rNfDev.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                            rNfDev.Cd_condpgto = rPed.Cd_condpgto;
                            rNfDev.Nr_pedido = rPed.Nr_pedido;
                            rNfDev.Tp_movimento = rPed.Tp_movimento.Trim().ToUpper().Equals("E") ? "S" : "E";
                            rNfDev.Tp_pessoa = rPed.Tp_pessoa;
                            rNfDev.Tp_nota = (rNfDev.Tp_pessoa.Trim().ToUpper().Equals("J") && rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                            rNfDev.Nr_serie = lCfgPed[0].Nr_serie;
                            rNfDev.Cd_modelo = lCfgPed[0].Cd_modelo;
                            rNfDev.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                            rNfDev.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            rNfDev.Dt_saient = rNfDev.Dt_emissao;
                            rNfDev.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                                    rNfDev.Cd_movimentacaostring,
                                                                                    rPed.Uf_clifor.Trim().Equals(rPed.Uf_empresa.Trim()));
                            rNfDev.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                                              rNfDev.Cd_movimentacaostring,
                                                                              rPed.Uf_empresa.Trim().Equals(rPed.Uf_clifor.Trim()));
                            rNfDev.Pesoliquido = lDev.Sum(p => p.Sd_qtdfiscaldevolver);
                            //Buscar tipo frete no pedido
                            object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = rPed.Nr_pedidostring
                                                }
                                            }, "a.tp_frete");
                            rNfDev.Tp_frete = obj == null ? "9" : obj.ToString();
                            //Abrir tela para capturar dados da nota fiscal            
                            using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                            {
                                fNumero.pCd_empresa = rNfDev.Cd_empresa;
                                fNumero.pNm_empresa = rNfDev.Nm_empresa;
                                fNumero.pCd_clifor = rNfDev.Cd_clifor;
                                fNumero.pNm_clifor = rNfDev.Nm_clifor;
                                fNumero.pTp_pessoa = rNfDev.Tp_pessoa;
                                fNumero.pTp_movimento = rNfDev.Tp_movimento;
                                fNumero.pTp_nota = rNfDev.Tp_nota;
                                fNumero.pChave_Acesso_NFe = rNfDev.Chave_acesso_nfe;
                                fNumero.pNr_serie = rNfDev.Nr_serie;
                                fNumero.pDs_serie = rNfDev.Ds_serienf;
                                fNumero.pCd_modelo = rNfDev.Cd_modelo;
                                fNumero.pDt_emissao = rNfDev.Dt_emissao;
                                fNumero.pST_NotaUnica = false;
                                fNumero.pNr_notafiscal = rNfDev.Nr_notafiscal.HasValue ? rNfDev.Nr_notafiscal.Value.ToString() : string.Empty;
                                fNumero.pDt_emissao = rNfDev.Dt_emissao;
                                fNumero.pDt_saient = rNfDev.Dt_saient;
                                fNumero.pDs_dadosadic = rNfDev.Dadosadicionais;
                                fNumero.pDs_obsfiscal = rNfDev.Obsfiscal;
                                fNumero.pSt_sequenciaauto = rNfDev.St_sequenciaauto;
                                fNumero.pCd_movto = rNfDev.Cd_movimentacaostring;
                                fNumero.pCd_cmi = rNfDev.Cd_cmistring;
                                if (rNfDev.Tp_nota.Trim().ToUpper().Equals("T"))
                                {
                                    //Buscar inscricao estadual do clifor da nota
                                    object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_clifor",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNfDev.Cd_clifor.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_endereco",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNfDev.Cd_endereco.Trim() + "'"
                                                            }
                                                        }, "a.insc_estadual");
                                    fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                                }
                                fNumero.pTp_frete = rNfDev.Tp_frete;
                                if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rNfDev.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                                    if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                                        rNfDev.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                                    else
                                        rNfDev.Nr_notafiscal = null;
                                    rNfDev.Nr_serie = fNumero.pNr_serie;
                                    rNfDev.Cd_modelo = fNumero.pCd_modelo;
                                    rNfDev.Dt_emissao = fNumero.pDt_emissao;
                                    rNfDev.Dt_saient = fNumero.pDt_saient;
                                    rNfDev.Obsfiscal = fNumero.pDs_obsfiscal;
                                    rNfDev.Dadosadicionais = fNumero.pDs_dadosadic;
                                    rNfDev.Cd_transportadora = fNumero.pCd_transportadora;
                                    rNfDev.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                                    rNfDev.Cpf_transp = fNumero.pCnpjCpfTransp;
                                    rNfDev.Placaveiculo = fNumero.pPlacaVeiculo;
                                    rNfDev.Tp_frete = fNumero.pTp_frete;
                                    rNfDev.Especie = fNumero.pEspecie;
                                    rNfDev.Quantidade = fNumero.pQuantidade;
                                    rNfDev.Pesobruto = fNumero.pPsbruto;
                                    rNfDev.Pesoliquido = fNumero.pPsliquido;
                                    rNfDev.Vl_frete = fNumero.pVl_frete;
                                    if (rNfDev.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                                        rNfDev.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                        {
                                            St_compdevimposto = rCmi.St_compdevimposto,
                                            St_complementar = rCmi.St_complementar,
                                            St_devolucao = rCmi.St_devolucao,
                                            St_geraestoque = rCmi.St_geraestoque,
                                            St_mestra = rCmi.St_mestra,
                                            St_simplesremessa = rCmi.St_simplesremessa,
                                            St_retorno = rCmi.St_retorno
                                        });
                                        rNfDev.Cd_cmistring = fNumero.pCd_cmi;
                                        rNfDev.Ds_cmi = rCmi.Ds_cmi;
                                        rNfDev.Tp_duplicata = rCmi.Tp_duplicata;
                                        rNfDev.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                    }
                                }
                                else
                                    throw new Exception("Obrigatorio informar numero da nota fiscal.");
                            }
                            if (rNfDev.Nr_notafiscal.HasValue)
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNfDev.Nr_notafiscal.ToString(),
                                                                                                             rNfDev.Nr_serie,
                                                                                                             rNfDev.Cd_empresa,
                                                                                                             rNfDev.Cd_clifor,
                                                                                                             string.Empty,
                                                                                                             rNfDev.Tp_nota,
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
                            //Item da nota fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItemDev = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                            rItemDev.Cd_empresa = rPed.Cd_empresa;
                            rItemDev.Cd_produto = rPed.Cd_produto;
                            rItemDev.Cd_local = rPed.Cd_local;
                            rItemDev.Cd_condfiscal_produto = rPed.Cd_condfiscal_produto;
                            rItemDev.Cd_unidade = rPed.Cd_unidade;
                            rItemDev.Cd_unidEst = rPed.Cd_unidade_estoque;
                            rItemDev.Nr_pedido = rPed.Nr_pedido.Value;
                            rItemDev.Id_pedidoitem = rPed.Id_pedidoitem;
                            rItemDev.Quantidade = lDev.Sum(p => p.Sd_qtdfiscaldevolver);
                            rItemDev.Quantidade_estoque = rItemDev.Quantidade;
                            rItemDev.Vl_subtotal = lDev.Sum(p => p.Sd_vlfiscaldevolver);
                            rItemDev.Vl_subtotal_estoque = rItemDev.Vl_subtotal;
                            rItemDev.Vl_unitario = rItemDev.Quantidade > 0 ? Math.Round(rItemDev.Vl_subtotal / rItemDev.Quantidade, 5) : rItemDev.Vl_subtotal;
                            //Buscar cfop do item
                            CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                            if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNfDev.Cd_movimentacaostring,
                                                                               rPed.Cd_condfiscal_produto,
                                                                               rPed.Cd_uf_clifor.Trim().Equals("99") ? "I" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                               (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_clifor : rNfDev.Cd_uf_empresa),
                                                                               (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_empresa : rNfDev.Cd_uf_clifor),
                                                                               rNfDev.Tp_movimento,
                                                                               rNfDev.Cd_condfiscal_clifor,
                                                                               rNfDev.Cd_empresa,
                                                                               ref rCfop,
                                                                               null))
                            {
                                rItemDev.Cd_cfop = rCfop.CD_CFOP;
                                rItemDev.Ds_cfop = rCfop.DS_CFOP;
                                rItemDev.St_bonificacao = rCfop.St_bonificacaobool;
                            }
                            else
                                throw new Exception("Não existe CFOP " + (rPed.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNfDev.Cd_movimentacaostring + " condição fiscal do produto " + rPed.Cd_condfiscal_produto);
                            //Procurar Impostos Estaduais para o Item
                            string vObsFiscal = string.Empty;
                            CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNfDev.Cd_empresa,
                                                                                                                   (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_clifor : rNfDev.Cd_uf_empresa),
                                                                                                                   (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_empresa : rNfDev.Cd_uf_clifor),
                                                                                                                   rNfDev.Cd_movimentacaostring,
                                                                                                                   rNfDev.Tp_movimento,
                                                                                                                   rNfDev.Cd_condfiscal_clifor,
                                                                                                                   rItemDev.Cd_condfiscal_produto,
                                                                                                                   rItemDev.Vl_subtotal,
                                                                                                                   rItemDev.Quantidade,
                                                                                                                   ref vObsFiscal,
                                                                                                                   rNfDev.Dt_emissao,
                                                                                                                   rItemDev.Cd_produto,
                                                                                                                   rNfDev.Tp_nota,
                                                                                                                   rNfDev.Nr_serie,
                                                                                                                   null);
                            if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                            {
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItemDev);
                                rNfDev.Obsfiscal += string.IsNullOrEmpty(rNfDev.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                            }
                            else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItemDev.Cd_produto, rNfDev.Nr_serie, null))
                                throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                        "Tipo Movimento: " + rNfDev.Tipo_movimento.Trim() + "\r\n" +
                                                        "Movimentação: " + rNfDev.Cd_movimentacao.ToString() + "\r\n" +
                                                        "Cond. Fiscal Clifor: " + rNfDev.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                        "Cond. Fiscal Produto: " + rItemDev.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                        "UF Origem: " + (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Uf_clifor.Trim() : rNfDev.Uf_empresa.Trim()) + "\r\n" +
                                                        "UF Destino: " + (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Uf_empresa.Trim() : rNfDev.Uf_clifor.Trim()));

                            //Procurar impostos sobre os itens da nota fiscal de destino
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNfDev.Cd_condfiscal_clifor,
                                                                                                                           rItemDev.Cd_condfiscal_produto,
                                                                                                                           rNfDev.Cd_movimentacaostring,
                                                                                                                           rNfDev.Tp_movimento,
                                                                                                                           rNfDev.Tp_pessoa,
                                                                                                                           rNfDev.Cd_empresa,
                                                                                                                           rNfDev.Nr_serie,
                                                                                                                           rNfDev.Cd_clifor,
                                                                                                                           rItemDev.Cd_unidEst,
                                                                                                                           rNfDev.Dt_emissao,
                                                                                                                           rItemDev.Quantidade,
                                                                                                                           rItemDev.Vl_subtotal,
                                                                                                                           rNfDev.Tp_nota,
                                                                                                                           string.Empty,
                                                                                                                           null), rItemDev, rNfDev.Tp_movimento);
                            string obsitem = string.Empty;
                            lDev.ForEach(p =>
                                {
                                    rItemDev.lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Nr_notafiscal_origem = p.Nr_notafiscal,
                                        Nr_serie_origem = p.Nr_serie,
                                        Nr_lanctofiscal_origem = p.Nr_lanctofiscal,
                                        Id_nfitem_origem = p.Id_nfitem,
                                        Qtd_lancto = p.Sd_qtdfiscaldevolver,
                                        Vl_lancto = p.Sd_vlfiscaldevolver,
                                        Tp_operacao = "D"
                                    });
                                    obsitem += (p.Nr_notafiscal.ToString() + "/" + p.Nr_serie).FormatStringDireita(21, ' ') + 
                                                (p.Sd_qtdfiscaldevolver.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                                p.Sigla_unidade_estoque.Trim()).FormatStringDireita(15, ' ') + 
                                                p.Sd_vlfiscaldevolver.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n";
                                });
                            rItemDev.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obsitem;
                            rNfDev.ItensNota.Add(rItemDev);
                            lNf.Add(rNfDev);
                        }
                        else
                            throw new Exception("Não existe configuração fiscal de DEVOLUÇÃO para o pedido Nº" + rPed.Nr_pedidostring);
                    }
                #endregion

                #region Nota Complemento
                if (lCom != null)
                    if(lCom.Count > 0)
                    {
                        //Buscar configuracao fiscal do pedido
                        CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                            new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                "where x.cfg_pedido = a.cfg_pedido " +
                                                "and x.nr_pedido = " + rPed.Nr_pedidostring + ")"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'CF'"
                                }
                            }, 1, string.Empty);
                        if (lCfgPed.Count > 0)
                        {
                            //Objeto Nota Fiscal de Devolução
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfComp = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                            rNfComp.Cd_empresa = rPed.Cd_empresa;
                            rNfComp.Cd_clifor = rPed.Cd_clifor;
                            rNfComp.Nm_clifor = rPed.Nm_clifor;
                            rNfComp.Cd_endereco = rPed.Cd_endereco;
                            rNfComp.Cd_cmi = lCfgPed[0].Cd_cmi;
                            rNfComp.Cd_movimentacao = lCfgPed[0].Cd_movto;
                            rNfComp.lCFGFiscal = lCfgPed;
                            rNfComp.Cd_uf_empresa = rPed.Cd_uf_empresa;
                            rNfComp.Uf_empresa = rPed.Uf_empresa;
                            rNfComp.Cd_uf_clifor = rPed.Cd_uf_clifor;
                            rNfComp.Uf_clifor = rPed.Uf_clifor;
                            rNfComp.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                            rNfComp.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                            rNfComp.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                            rNfComp.Cd_condpgto = rPed.Cd_condpgto;
                            rNfComp.Nr_pedido = rPed.Nr_pedido;
                            rNfComp.Tp_movimento = rPed.Tp_movimento;
                            rNfComp.Tp_pessoa = rPed.Tp_pessoa;
                            rNfComp.Tp_nota = (rNfComp.Tp_pessoa.Trim().ToUpper().Equals("J") && rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                            rNfComp.Nr_serie = lCfgPed[0].Nr_serie;
                            rNfComp.Cd_modelo = lCfgPed[0].Cd_modelo;
                            rNfComp.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                            rNfComp.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                            rNfComp.Dt_saient = rNfComp.Dt_emissao;
                            rNfComp.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                                     rNfComp.Cd_movimentacaostring,
                                                                                     rPed.Uf_clifor.Trim().Equals(rPed.Uf_empresa.Trim()));
                            rNfComp.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                                               rNfComp.Cd_movimentacaostring,
                                                                               rPed.Uf_empresa.Trim().Equals(rPed.Uf_clifor.Trim()));
                            rNfComp.Pesoliquido = lCom.Sum(p => p.Sd_qtdfiscalcomplementar);
                            //Buscar tipo frete no pedido
                            object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = rPed.Nr_pedidostring
                                                }
                                            }, "a.tp_frete");
                            rNfComp.Tp_frete = obj == null ? "9" : obj.ToString();
                            //Abrir tela para capturar dados da nota fiscal            
                            using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                            {
                                fNumero.pCd_empresa = rNfComp.Cd_empresa;
                                fNumero.pNm_empresa = rNfComp.Nm_empresa;
                                fNumero.pCd_clifor = rNfComp.Cd_clifor;
                                fNumero.pNm_clifor = rNfComp.Nm_clifor;
                                fNumero.pTp_pessoa = rNfComp.Tp_pessoa;
                                fNumero.pTp_movimento = rNfComp.Tp_movimento;
                                fNumero.pTp_nota = rNfComp.Tp_nota;
                                fNumero.pChave_Acesso_NFe = rNfComp.Chave_acesso_nfe;
                                fNumero.pNr_serie = rNfComp.Nr_serie;
                                fNumero.pDs_serie = rNfComp.Ds_serienf;
                                fNumero.pCd_modelo = rNfComp.Cd_modelo;
                                fNumero.pDt_emissao = rNfComp.Dt_emissao;
                                fNumero.pST_NotaUnica = false;
                                fNumero.pNr_notafiscal = rNfComp.Nr_notafiscalstr;
                                fNumero.pDt_emissao = rNfComp.Dt_emissao;
                                fNumero.pDt_saient = rNfComp.Dt_saient;
                                fNumero.pDs_dadosadic = rNfComp.Dadosadicionais;
                                fNumero.pDs_obsfiscal = rNfComp.Obsfiscal;
                                fNumero.pSt_sequenciaauto = rNfComp.St_sequenciaauto;
                                fNumero.pCd_movto = rNfComp.Cd_movimentacaostring;
                                fNumero.pCd_cmi = rNfComp.Cd_cmistring;
                                if (rNfComp.Tp_nota.Trim().ToUpper().Equals("T"))
                                {
                                    //Buscar inscricao estadual do clifor da nota
                                    object obj_insc = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_clifor",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNfComp.Cd_clifor.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_endereco",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNfComp.Cd_endereco.Trim() + "'"
                                                            }
                                                        }, "a.insc_estadual");
                                    fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                                }
                                fNumero.pTp_frete = rNfComp.Tp_frete;
                                if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    rNfComp.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                                    if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                                        rNfComp.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                                    else
                                        rNfComp.Nr_notafiscal = null;
                                    rNfComp.Nr_serie = fNumero.pNr_serie;
                                    rNfComp.Cd_modelo = fNumero.pCd_modelo;
                                    rNfComp.Dt_emissao = fNumero.pDt_emissao;
                                    rNfComp.Dt_saient = fNumero.pDt_saient;
                                    rNfComp.Obsfiscal = fNumero.pDs_obsfiscal;
                                    rNfComp.Dadosadicionais = fNumero.pDs_dadosadic;
                                    rNfComp.Cd_transportadora = fNumero.pCd_transportadora;
                                    rNfComp.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                                    rNfComp.Cpf_transp = fNumero.pCnpjCpfTransp;
                                    rNfComp.Placaveiculo = fNumero.pPlacaVeiculo;
                                    rNfComp.Tp_frete = fNumero.pTp_frete;
                                    rNfComp.Especie = fNumero.pEspecie;
                                    rNfComp.Quantidade = fNumero.pQuantidade;
                                    rNfComp.Pesobruto = fNumero.pPsbruto;
                                    rNfComp.Pesoliquido = fNumero.pPsliquido;
                                    rNfComp.Vl_frete = fNumero.pVl_frete;
                                    if (rNfComp.Cd_cmistring.Trim() != fNumero.pCd_cmi.Trim())
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
                                        rNfComp.Cminf.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_CMI()
                                        {
                                            St_compdevimposto = rCmi.St_compdevimposto,
                                            St_complementar = rCmi.St_complementar,
                                            St_devolucao = rCmi.St_devolucao,
                                            St_geraestoque = rCmi.St_geraestoque,
                                            St_mestra = rCmi.St_mestra,
                                            St_simplesremessa = rCmi.St_simplesremessa,
                                            St_retorno = rCmi.St_retorno
                                        });
                                        rNfComp.Cd_cmistring = fNumero.pCd_cmi;
                                        rNfComp.Ds_cmi = rCmi.Ds_cmi;
                                        rNfComp.Tp_duplicata = rCmi.Tp_duplicata;
                                        rNfComp.Ds_tpduplicata = rCmi.ds_tpduplicata;
                                    }
                                }
                                else
                                    throw new Exception("Obrigatorio informar numero da nota fiscal.");
                            }
                            if (rNfComp.Nr_notafiscal.HasValue)
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.existeNumeroNota(rNfComp.Nr_notafiscalstr,
                                                                                                             rNfComp.Nr_serie,
                                                                                                             rNfComp.Cd_empresa,
                                                                                                             rNfComp.Cd_clifor,
                                                                                                             string.Empty,
                                                                                                             rNfComp.Tp_nota,
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
                            //Item da nota fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItemComp = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                            rItemComp.Cd_empresa = rPed.Cd_empresa;
                            rItemComp.Cd_produto = rPed.Cd_produto;
                            rItemComp.Cd_local = rPed.Cd_local;
                            rItemComp.Cd_condfiscal_produto = rPed.Cd_condfiscal_produto;
                            rItemComp.Cd_unidade = rPed.Cd_unidade;
                            rItemComp.Cd_unidEst = rPed.Cd_unidade_estoque;
                            rItemComp.Nr_pedido = rPed.Nr_pedido.Value;
                            rItemComp.Id_pedidoitem = rPed.Id_pedidoitem;
                            rItemComp.Quantidade = lCom.Sum(p => p.Sd_qtdfiscalcomplementar);
                            rItemComp.Quantidade_estoque = rItemComp.Quantidade;
                            rItemComp.Vl_subtotal = lCom.Sum(p => p.Sd_vlfiscalcomplementar);
                            rItemComp.Vl_subtotal_estoque = rItemComp.Vl_subtotal;
                            rItemComp.Vl_unitario = rItemComp.Quantidade > 0 ? rItemComp.Vl_subtotal / rItemComp.Quantidade : rItemComp.Vl_subtotal;
                            //Procurar cfop do item
                            CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                            if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNfComp.Cd_movimentacaostring,
                                                                               rPed.Cd_condfiscal_produto,
                                                                               rPed.Cd_uf_clifor.Trim().Equals("99") ? "I" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                               (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Cd_uf_clifor : rNfComp.Cd_uf_empresa),
                                                                               (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Cd_uf_empresa : rNfComp.Cd_uf_clifor),
                                                                               rNfComp.Tp_movimento,
                                                                               rNfComp.Cd_condfiscal_clifor,
                                                                               rNfComp.Cd_empresa,
                                                                               ref rCfop,
                                                                               null))
                            {
                                rItemComp.Cd_cfop = rCfop.CD_CFOP;
                                rItemComp.Ds_cfop = rCfop.DS_CFOP;
                                rItemComp.St_bonificacao = rCfop.St_bonificacaobool;
                            }
                            else
                                throw new Exception("Não existe CFOP " + (rPed.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rPed.Cd_uf_clifor.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNfComp.Cd_movimentacaostring + " condição fiscal do produto " + rPed.Cd_condfiscal_produto);
                            //Procurar Impostos Estaduais para o Item
                            string vObsFiscal = string.Empty;
                            CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpUf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf(rNfComp.Cd_empresa,
                                                                                                                   (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Cd_uf_clifor : rNfComp.Cd_uf_empresa),
                                                                                                                   (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Cd_uf_empresa : rNfComp.Cd_uf_clifor),
                                                                                                                   rNfComp.Cd_movimentacaostring,
                                                                                                                   rNfComp.Tp_movimento,
                                                                                                                   rNfComp.Cd_condfiscal_clifor,
                                                                                                                   rItemComp.Cd_condfiscal_produto,
                                                                                                                   rItemComp.Vl_subtotal,
                                                                                                                   rItemComp.Quantidade,
                                                                                                                   ref vObsFiscal,
                                                                                                                   rNfComp.Dt_emissao,
                                                                                                                   rItemComp.Cd_produto,
                                                                                                                   rNfComp.Tp_nota,
                                                                                                                   rNfComp.Nr_serie,
                                                                                                                   null);
                            if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                            {
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItemComp);
                                rNfComp.Obsfiscal += string.IsNullOrEmpty(rNfComp.Obsfiscal) ? vObsFiscal : "\r\n" + vObsFiscal;
                            }
                            else if (CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.ObrigImformarICMS(rItemComp.Cd_produto, rNfComp.Nr_serie, null))
                                throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                        "Tipo Movimento: " + rNfComp.Tipo_movimento.Trim() + "\r\n" +
                                                        "Movimentação: " + rNfComp.Cd_movimentacao.ToString() + "\r\n" +
                                                        "Cond. Fiscal Clifor: " + rNfComp.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                        "Cond. Fiscal Produto: " + rItemComp.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                        "UF Origem: " + (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Uf_clifor.Trim() : rNfComp.Uf_empresa.Trim()) + "\r\n" +
                                                        "UF Destino: " + (rNfComp.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfComp.Uf_empresa.Trim() : rNfComp.Uf_clifor.Trim()));

                            //Procurar impostos sobre os itens da nota fiscal de destino
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNfComp.Cd_condfiscal_clifor,
                                                                                                                           rItemComp.Cd_condfiscal_produto,
                                                                                                                           rNfComp.Cd_movimentacaostring,
                                                                                                                           rNfComp.Tp_movimento,
                                                                                                                           rNfComp.Tp_pessoa,
                                                                                                                           rNfComp.Cd_empresa,
                                                                                                                           rNfComp.Nr_serie,
                                                                                                                           rNfComp.Cd_clifor,
                                                                                                                           rItemComp.Cd_unidEst,
                                                                                                                           rNfComp.Dt_emissao,
                                                                                                                           rItemComp.Quantidade,
                                                                                                                           rItemComp.Vl_subtotal,
                                                                                                                           rNfComp.Tp_nota,
                                                                                                                           string.Empty,
                                                                                                                           null), rItemComp, rNfComp.Tp_movimento);
                            string obsitem = string.Empty;
                            lCom.ForEach(p =>
                            {
                                rItemComp.lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Nr_notafiscal_origem = p.Nr_notafiscal,
                                    Nr_serie_origem = p.Nr_serie,
                                    Nr_lanctofiscal_origem = p.Nr_lanctofiscal,
                                    Id_nfitem_origem = p.Id_nfitem,
                                    Qtd_lancto = p.Sd_qtdfiscalcomplementar,
                                    Vl_lancto = p.Sd_vlfiscalcomplementar,
                                    Tp_operacao = "C"
                                });
                                obsitem += (p.Nr_notafiscal.ToString() + "/" + p.Nr_serie).FormatStringDireita(21, ' ') + 
                                            (p.Sd_qtdfiscalcomplementar.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                            p.Sigla_unidade_estoque.Trim()).FormatStringDireita(15, ' ') + 
                                            p.Sd_vlfiscalcomplementar.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n";
                            });
                            rItemComp.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obsitem;
                            rNfComp.ItensNota.Add(rItemComp);
                            lNf.Add(rNfComp);
                        }
                        else
                            throw new Exception("Não existe configuração fiscal de COMPLEMENTO para o pedido Nº" + rPed.Nr_pedidostring);
                    }
                #endregion
            }
            return lNf;
        }
    }
}
