using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using NumeroNota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Proc_Commoditties
{
    public class TGerarDevolucaoNF
    {
        public static void DevolverNF(TRegistro_LanFaturamento val)
        {
            if (val != null)
            {
                //Verificar se Nf é de devolução
                if (new TCD_LanFat_ComplementoDevolucao().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.NR_LanctoFiscal_Destino",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lanctofiscalstr
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Não é possivel devolver NF Devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDevolverNF fDev = new TFDevolverNF())
                {
                    fDev.rNf = val;
                    if (fDev.ShowDialog() == DialogResult.OK)
                        if (fDev.rNf != null)
                            try
                            {
                                TRegistro_LanFaturamento rFat = GerarDevolucao(fDev.rNf);
                                TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                //Enviar NFe Destino
                                if (rFat != null)
                                {
                                    //Buscar nota fiscal de destino
                                    TRegistro_LanFaturamento rNf =
                                        TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                    rFat.Nr_lanctofiscalstr,
                                                                    null);
                                    //Se for nota propria e NF-e
                                    if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && rNf.Cd_modelo.Trim().Equals("55"))
                                    {
                                        if (MessageBox.Show("Deseja enviar NF-e Devolução para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            try
                                            {
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = rNf;
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
        public static TRegistro_LanFaturamento GerarDevolucao(TRegistro_LanFaturamento rNf)
        {
            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Reg_Clifor = 
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rNf.Cd_clifor, null);
            #region Nota Fiscal Devolução
            TRegistro_LanFaturamento rNfDev = new TRegistro_LanFaturamento();
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPedido =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                            "where x.cfg_pedido = a.cfg_pedido "+
                                            "and x.nr_pedido = " + rNf.Nr_pedido.ToString() + ")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_fiscal",
                                vOperador = "=",
                                vVL_Busca = "'DV'"
                            }
                        }, 1, string.Empty);

            if (lCfgPedido.Count > 0)
            {
                rNfDev.Cd_empresa = rNf.Cd_empresa;
                rNfDev.Nr_serie = lCfgPedido[0].Nr_serie;
                rNfDev.Ds_serienf = lCfgPedido[0].Ds_serienf;
                rNfDev.Cd_modelo = lCfgPedido[0].Cd_modelo;
                rNfDev.Cd_movimentacao = lCfgPedido[0].Cd_movto;
                rNfDev.Cd_cmi = lCfgPedido[0].Cd_cmi;
                rNfDev.Tp_movimento = lCfgPedido[0].Tp_movimento.ToUpper().Equals("S") ? "E" : "S";
                rNfDev.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rNfDev.Dt_saient = CamadaDados.UtilData.Data_Servidor();
                rNfDev.Cd_uf_clifor = rNf.Cd_uf_clifor;
                rNfDev.Cd_uf_empresa = rNf.Cd_uf_empresa;
                rNfDev.Cd_condfiscal_clifor = rNf.Cd_condfiscal_clifor;
                rNfDev.rEndereco = rNf.rEndereco;
                rNfDev.Cd_clifor = rNf.Cd_clifor;
                rNfDev.Cd_endereco = rNf.Cd_endereco;
                rNfDev.Nr_pedido = rNf.Nr_pedido;
                using (TFNumero_Nota fNumero = new TFNumero_Nota())
                {
                    fNumero.Text = "Dados Nota Fiscal Devolução";
                    fNumero.pCd_empresa = rNf.Cd_empresa;
                    fNumero.pNm_empresa = rNf.Nm_empresa;
                    fNumero.pCd_clifor = rNf.Cd_clifor;
                    fNumero.pNm_clifor = rNf.Nm_clifor;
                    fNumero.pTp_pessoa = rNf.Tp_pessoa;
                    fNumero.pNr_serie = lCfgPedido[0].Nr_serie;
                    fNumero.pDs_serie = lCfgPedido[0].Ds_serienf;
                    fNumero.pCd_modelo = lCfgPedido[0].Cd_modelo;
                    fNumero.pTp_movimento = lCfgPedido[0].Tp_movimento.ToUpper().Equals("S") ? "E" : "S";
                    fNumero.pNr_notafiscal = string.Empty;
                    fNumero.pDt_emissao = rNfDev.Dt_emissao;
                    fNumero.pDt_saient = rNfDev.Dt_saient;
                    fNumero.pSt_sequenciaauto = lCfgPedido[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                    fNumero.pCd_movto = rNfDev.Cd_movimentacaostring;
                    fNumero.pCd_cmi = rNfDev.Cd_cmistring;
                    //Buscar insc. estadual origem
                    object obj_inscdestino = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
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
                    if (obj_inscdestino != null)
                        fNumero.pInsc_estadual = obj_inscdestino.ToString();
                    fNumero.pTp_nota = (TCN_LanFaturamento.validarST_Nota(fNumero.pTp_movimento, fNumero.pTp_pessoa, Reg_Clifor.St_equiparado_pjbool, Reg_Clifor.St_agropecuariabool).Equals(0) ? "P" : "T");
                    if (fNumero.ShowDialog() == DialogResult.OK)
                    {
                        rNfDev.Nr_serie = fNumero.pNr_serie;
                        rNfDev.Tp_pessoa = fNumero.pTp_pessoa;
                        rNfDev.Cd_modelo = fNumero.pCd_modelo;
                        rNfDev.Tp_movimento = fNumero.pTp_movimento;
                        rNfDev.Tp_nota = fNumero.pTp_nota;
                        rNfDev.Dt_emissao = fNumero.pDt_emissao;
                        rNfDev.Dt_saient = fNumero.pDt_saient;
                        rNfDev.Obsfiscal = fNumero.pDs_obsfiscal;
                        rNfDev.Dadosadicionais = fNumero.pDs_dadosadic;
                        rNfDev.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                        if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                            rNfDev.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                        else
                            rNfDev.Nr_notafiscal = null;
                        rNfDev.St_sequenciaauto = fNumero.pSt_sequenciaauto;
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
                            rNfDev.Cminf.Add(new TRegistro_LanFaturamento_CMI()
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
                        //Dados Frete
                        rNfDev.Cd_transportadora = fNumero.pCd_transportadora;
                        rNfDev.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                        rNfDev.Cpf_transp = fNumero.pCnpjCpfTransp;
                        rNfDev.Cd_enderecotransp = fNumero.pCd_endtransportadora;
                        rNfDev.Especie = fNumero.pEspecie;
                        rNfDev.Placaveiculo = fNumero.pPlacaVeiculo;
                        rNfDev.Freteporconta = fNumero.pTp_frete;
                        rNfDev.Vl_frete = fNumero.pVl_frete;
                        rNfDev.Quantidade = fNumero.pQuantidade;
                        rNfDev.Pesobruto = fNumero.pPsbruto;
                        rNfDev.Pesoliquido = fNumero.pPsliquido;
                        //Dados Exportacao
                        rNfDev.Cd_ufsaidaex = fNumero.pCd_ufsaidaex;
                        rNfDev.Ds_ufsaidaex = fNumero.pDs_ufsaidaex;
                        rNfDev.Uf_saidaex = fNumero.pUf_saidaex;
                        rNfDev.Ds_localex = fNumero.pDs_localex;
                    }
                    else
                        throw new Exception("Obrigatorio informar numero da nota fiscal de destino.");
                }
            }
            else
                throw new Exception("Não existe configuração fiscal Devolução para tipo de pedido!");
            //Itens da Nota
            rNf.ItensNota.FindAll(p=> p.St_processar).ForEach(item =>
            {
                //Item da nota fiscal
                TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                rItem.Cd_empresa = item.Cd_empresa;
                rItem.Nr_pedido = item.Nr_pedido;
                rItem.Id_pedidoitem = item.Id_pedidoitem;
                rItem.Cd_produto = item.Cd_produto;
                rItem.Cd_local = item.Cd_local;
                rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                rItem.Cd_unidade = item.Cd_unidade;
                rItem.Cd_unidEst = item.Cd_unidade;
                rItem.Quantidade = item.Qtd_devolver;
                rItem.Quantidade_estoque = item.Qtd_devolver;
                rItem.Vl_subtotal = item.Qtd_devolver * item.Vl_unitario;
                rItem.Vl_subtotal_estoque = item.Qtd_devolver * item.Vl_unitario;
                rItem.Vl_unitario = item.Vl_unitario;
                rItem.Vl_desconto = (item.Vl_desconto / item.Quantidade) * item.Qtd_devolver;
                rItem.Vl_juro_fin = (item.Vl_juro_fin / item.Quantidade) * item.Qtd_devolver;

                //Buscar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNfDev.Cd_movimentacaostring,
                                                                   item.Cd_condfiscal_produto,
                                                                   rNfDev.rEndereco.Cd_uf.Trim().Equals("99") ? "I" : rNfDev.Cd_uf_clifor.Trim().Equals(rNfDev.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                   (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_clifor : rNfDev.Cd_uf_empresa),
                                                                   (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNfDev.Cd_uf_empresa : rNfDev.Cd_uf_clifor),
                                                                   rNfDev.Tp_movimento,
                                                                   rNfDev.Cd_condfiscal_clifor,
                                                                   rItem.Cd_empresa,
                                                                   ref rCfop,
                                                                   null))
                {
                    rItem.Cd_cfop = rCfop.CD_CFOP;
                    rItem.Ds_cfop = rCfop.DS_CFOP;
                    rItem.St_bonificacao = rCfop.St_bonificacaobool;
                }
                else
                    throw new Exception("Não existe CFOP " + (rNf.rEndereco.Cd_uf.Trim().Equals("99") ? "internacional" : rNf.rEndereco.Cd_uf.Trim().Equals(rNf.rEndereco.Cd_uf.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(rItem.Cd_empresa,
                                                                                       (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                       (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                       rNfDev.Cd_movimentacaostring,
                                                                                       rNfDev.Tp_movimento,
                                                                                       rNfDev.Cd_condfiscal_clifor,
                                                                                       rItem.Cd_condfiscal_produto,
                                                                                       rItem.Vl_subtotal,
                                                                                       rItem.Quantidade,
                                                                                       ref vObsFiscal,
                                                                                       rNfDev.Dt_emissao,
                                                                                       rItem.Cd_produto,
                                                                                       rNfDev.Tp_nota,
                                                                                       rNfDev.Nr_serie,
                                                                                       null);
                if (lImpUf.Exists(v=>v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItem);
                    rNf.Obsfiscal += vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, rNf.Nr_serie, null))
                    throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                            "Tipo Movimento: " + rNfDev.Tp_movimento + "\r\n" +
                                            "Movimentação: " + rNfDev.Cd_movimentacao.ToString() + "\r\n" +
                                            "Cond. Fiscal Clifor: " + rNfDev.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "UF Origem: " + (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_clifor.Trim() : rNf.Uf_empresa.Trim()) + "\r\n" +
                                            "UF Destino: " + (rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_empresa.Trim() : rNf.Uf_clifor.Trim()));

                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                            rItem.Cd_condfiscal_produto,
                                                                            rNfDev.Cd_movimentacaostring,
                                                                            rNfDev.Tp_movimento,
                                                                            rNfDev.Tp_pessoa,
                                                                            rNfDev.Cd_empresa,
                                                                            rNfDev.Nr_serie,
                                                                            rNfDev.Cd_clifor,
                                                                            rItem.Cd_unidEst,
                                                                            rNfDev.Dt_emissao,
                                                                            rItem.Quantidade,
                                                                            rItem.Vl_subtotal,
                                                                            rNfDev.Tp_nota,
                                                                            rNf.Cd_municipioexecservico,
                                                                            null), rItem, rNfDev.Tp_movimento);
                // Formar Itens a devolver
                rItem.lNfcompdev.Add(new TRegistro_LanFat_ComplementoDevolucao()
                {
                    Cd_empresa = item.Cd_empresa,
                    Nr_notafiscal_origem = rNf.Nr_notafiscal,
                    Nr_serie_origem = rNf.Nr_serie,
                    Nr_lanctofiscal_origem = rNf.Nr_lanctofiscal,
                    Id_nfitem_origem = item.Id_nfitem,
                    Qtd_lancto = item.Qtd_devolver,
                    Vl_lancto = item.Quantidade * item.Vl_unitario,
                    Tp_operacao = "D"
                });
                //Observação do Item com os dados das notas de orig
                rItem.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" +
                                         (rNf.Nr_notafiscalstr + rNf.Nr_serie).FormatStringDireita(21, ' ') +
                                         item.Qtd_devolver.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                         rItem.Sigla_unidade_estoque.Trim().FormatStringDireita(15, ' ') +
                                         decimal.Multiply(item.Quantidade, item.Vl_unitario).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n";
                rNfDev.ItensNota.Add(rItem);
            });
            return rNfDev;
            #endregion
        }
    }
}
