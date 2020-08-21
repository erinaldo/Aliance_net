using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Proc_Commoditties
{
    public class TProcessaQuebraTec
    {
        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessaQuebraTec(CamadaDados.Balanca.TRegistro_PedidoAplicacao rPedAplic,
                                                                                                    List<CamadaDados.Graos.TRegistro_TaxaDeposito> lTaxas,
                                                                                                    string Tp_taxa)
        {
            //Buscar config taxa
            //Buscar configuracao para o tipo de taxa que esta sendo faturada
            CamadaDados.Graos.TList_CFGTaxa CfgTaxa = CamadaNegocio.Graos.TCN_CFGTaxa.Buscar(Tp_taxa,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             null);
            //Verificar se existe configuracao fiscal
            if (string.IsNullOrEmpty(CfgTaxa[0].Tp_fiscal))
                throw new Exception("Não existe configuração fiscal para o tipo de taxa por PESO.");
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
                                                "and x.nr_pedido = " + rPedAplic.Nr_pedidostring + ")"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CfgTaxa[0].Tp_fiscal.Trim().ToUpper() + "'"
                                }
                            }, 1, string.Empty);
            if (lCfgPed.Count > 0)
            {
                //Buscar pedido
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfDev = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
                rNfDev.Cd_empresa = rPedAplic.Cd_empresa;
                rNfDev.Cd_clifor = rPedAplic.Cd_clifor;
                rNfDev.Nm_clifor = rPedAplic.Nm_clifor;
                rNfDev.Cd_endereco = rPedAplic.Cd_endereco;
                rNfDev.Cd_cmi = lCfgPed[0].Cd_cmi;
                rNfDev.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNfDev.lCFGFiscal = lCfgPed;
                rNfDev.Cd_uf_empresa = rPedAplic.Cd_uf_empresa;
                rNfDev.Uf_empresa = rPedAplic.Uf_empresa;
                rNfDev.Cd_uf_clifor = rPedAplic.Cd_uf_clifor;
                rNfDev.Uf_clifor = rPedAplic.Uf_clifor;
                rNfDev.Cd_condfiscal_clifor = rPedAplic.Cd_condfiscal_clifor;
                rNfDev.Tp_duplicata = lCfgPed[0].Tp_duplicata;
                rNfDev.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
                rNfDev.Cd_condpgto = rPedAplic.Cd_condpgto;
                rNfDev.Nr_pedido = rPedAplic.Nr_pedido;
                rNfDev.Tp_movimento = rPedAplic.Tp_movimento.Trim().ToUpper().Equals("E") ? "S" : "E";
                rNfDev.Tp_pessoa = rPedAplic.Tp_pessoa;
                rNfDev.Tp_nota = (rNfDev.Tp_pessoa.Trim().ToUpper().Equals("J") && rNfDev.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
                rNfDev.Nr_serie = lCfgPed[0].Nr_serie;
                rNfDev.Cd_modelo = lCfgPed[0].Cd_modelo;
                rNfDev.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                rNfDev.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rNfDev.Dt_saient = rNfDev.Dt_emissao;
                rNfDev.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                        rNfDev.Cd_movimentacaostring,
                                                                        rPedAplic.Uf_clifor.Trim().Equals(rPedAplic.Uf_empresa.Trim()));
                rNfDev.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                                  rNfDev.Cd_movimentacaostring,
                                                                  rPedAplic.Uf_empresa.Trim().Equals(rPedAplic.Uf_clifor.Trim()));
                rNfDev.Pesoliquido = lTaxas.Sum(p => p.Ps_Taxa);
                //Buscar tipo frete no pedido
                object obj = new CamadaDados.Faturamento.Pedido.TCD_Pedido().BuscarEscalar(
                                new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = rPedAplic.Nr_pedidostring
                                                }
                                            }, "a.tp_frete");
                rNfDev.Tp_frete = obj == null ? string.Empty : obj.ToString();
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
                rItemDev.Cd_empresa = rPedAplic.Cd_empresa;
                rItemDev.Cd_produto = rPedAplic.Cd_produto;
                rItemDev.Cd_local = rPedAplic.Cd_local;
                rItemDev.Cd_condfiscal_produto = rPedAplic.Cd_condfiscal_produto;
                rItemDev.Cd_unidade = rPedAplic.Cd_unidade;
                rItemDev.Cd_unidEst = rPedAplic.Cd_unidade_estoque;
                rItemDev.Nr_pedido = rPedAplic.Nr_pedido.Value;
                rItemDev.Id_pedidoitem = rPedAplic.Id_pedidoitem;
                rItemDev.Quantidade = lTaxas.Sum(v=> v.Ps_Taxa);
                rItemDev.Quantidade_estoque = rItemDev.Quantidade;
                rItemDev.Vl_subtotal = lTaxas.Sum(v=> v.Ps_Taxa) * rPedAplic.Vl_unitario;
                rItemDev.Vl_subtotal_estoque = rItemDev.Vl_subtotal;
                rItemDev.Vl_unitario = rPedAplic.Vl_unitario;
                //Procurar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNfDev.Cd_movimentacaostring,
                                                                   rPedAplic.Cd_condfiscal_produto,
                                                                   rPedAplic.Cd_uf_clifor.Trim().Equals("99") ? "I" :
                                                                   rPedAplic.Cd_uf_clifor.Trim().Equals(rPedAplic.Cd_uf_empresa.Trim()) ? "D" : "F",
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
                    throw new Exception("Não existe CFOP " + (rPedAplic.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rPedAplic.Cd_uf_clifor.Trim().Equals(rPedAplic.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNfDev.Cd_movimentacaostring + " condição fiscal do produto " + rPedAplic.Cd_condfiscal_produto);
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
                    rNfDev.Obsfiscal += vObsFiscal.Trim();
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
                rNfDev.ItensNota.Add(rItemDev);
                return rNfDev;
            }
            else
                throw new Exception("Não existe configuração fiscal para o pedido Nº " + rPedAplic.Nr_pedidostring);
        }
    }
}
