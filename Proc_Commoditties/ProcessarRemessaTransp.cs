using System;
using System.Linq;
using Utils;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;

namespace Proc_Commoditties
{
    public class TProcessarRemessaTransp
    {
        public static TRegistro_LanFaturamento ProcessarNF(TRegistro_Pedido rPedido)
        {
            //Buscar Configuração Fiscal Pedido
            TList_CadCFGPedidoFiscal lCfgPed = new TCD_CadCFGPedidoFiscal().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cfg_pedido",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rPedido.CFG_Pedido + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_fiscal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'RT'"
                                                    }
                                                }, 1, string.Empty);
            if(lCfgPed.Count > 0)
            {
                //Buscar Notas Vendas Sem Remessa
                TList_RegLanFaturamento lNFV = new TCD_LanFaturamento().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_pedido",
                                                        vOperador = "=",
                                                        vVL_Busca = rPedido.Nr_pedido.ToString()
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(cmi.st_remessatransp, 'N')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'S'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lanctofiscalRT",
                                                        vOperador = "is",
                                                        vVL_Busca = "null"
                                                    }
                                                }, 0, string.Empty);
                if(lNFV.Count.Equals(0))
                    throw new Exception("Pedido não possui nota venda disponivel para gerar REMESSA TRANSPORTE.");
                TRegistro_LanFaturamento rNF = null;
                if(lNFV.Count > 1)
                    using(TFListaNF fNF = new TFListaNF())
                    {
                        fNF.lFat = lNFV;
                        if(fNF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            if(fNF.rFat != null)
                                rNF = fNF.rFat;
                    }
                else rNF = lNFV[0];
                if(rNF == null)
                    throw new Exception("Obrigório selecionar nota fiscal para gerar REMESSA TRANSPORTE.");
                TRegistro_LanFaturamento ret = new TRegistro_LanFaturamento();
                ret.Cd_empresa = rNF.Cd_empresa;
                ret.Cd_clifor = !string.IsNullOrEmpty(rPedido.Cd_cliforent) ? rPedido.Cd_cliforent : rNF.Cd_clifor;
                ret.Nm_clifor = !string.IsNullOrEmpty(rPedido.Nm_cliforent) ? rPedido.Nm_cliforent : rNF.Nm_clifor;
                ret.Cd_endereco = !string.IsNullOrEmpty(rPedido.Cd_enderecoent) ? rPedido.Cd_enderecoent : rNF.Cd_endereco;
                ret.Cd_cmi = lCfgPed[0].Cd_cmi;
                ret.Cd_movimentacao = lCfgPed[0].Cd_movto;
                ret.lCFGFiscal = lCfgPed;
                ret.Cd_uf_empresa = rNF.Cd_uf_empresa;
                ret.Uf_empresa = rNF.Uf_empresa;
                ret.Uf_clifor = rNF.Uf_clifor;
                ret.Cd_condfiscal_clifor = !string.IsNullOrEmpty(rPedido.Cd_cliforent) ? rPedido.Cd_condfiscalent : rNF.Cd_condfiscal_clifor;
                ret.Cd_uf_clifor = !string.IsNullOrEmpty(rPedido.Cd_cliforent) ? rPedido.Cd_uf_ent : rNF.Cd_uf_clifor;
                ret.Nr_pedido = rNF.Nr_pedido;
                ret.Tp_movimento = rNF.Tp_movimento;
                ret.Tp_pessoa = rNF.Tp_pessoa;
                ret.Tp_nota = rNF.Tp_nota;
                ret.Nr_serie = lCfgPed[0].Nr_serie;
                ret.Cd_modelo = lCfgPed[0].Cd_modelo;
                ret.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                ret.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                ret.Dt_saient = ret.Dt_emissao;
                ret.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                     ret.Cd_movimentacaostring,
                                                                     rNF.Uf_clifor.Trim().Equals(rNF.Uf_empresa.Trim()));
                ret.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                               ret.Cd_movimentacaostring,
                                                               rNF.Uf_clifor.Trim().Equals(rNF.Uf_empresa.Trim()));
                ret.Freteporconta = rNF.Tp_frete;
                ret.Cd_transportadora = rNF.Cd_transportadora;
                ret.Nm_razaosocialtransp = rNF.Nm_razaosocialtransp;
                ret.Cpf_transp = rNF.Cpf_transp;
                ret.Placaveiculo = rNF.Placaveiculo;
                //Abrir tela para capturar dados da nota fiscal            
                using (NumeroNota.TFNumero_Nota fNumero = new NumeroNota.TFNumero_Nota())
                {
                    fNumero.pCd_empresa = ret.Cd_empresa;
                    fNumero.pNm_empresa = ret.Nm_empresa;
                    fNumero.pCd_clifor = ret.Cd_clifor;
                    fNumero.pNm_clifor = ret.Nm_clifor;
                    fNumero.pTp_pessoa = ret.Tp_pessoa;
                    fNumero.pTp_movimento = ret.Tp_movimento;
                    fNumero.pTp_nota = ret.Tp_nota;
                    fNumero.pChave_Acesso_NFe = ret.Chave_acesso_nfe;
                    fNumero.pNr_serie = ret.Nr_serie;
                    fNumero.pDs_serie = ret.Ds_serienf;
                    fNumero.pCd_modelo = ret.Cd_modelo;
                    fNumero.pDt_emissao = ret.Dt_emissao;
                    fNumero.pST_NotaUnica = false;
                    fNumero.pNr_notafiscal = ret.Nr_notafiscal.HasValue ? ret.Nr_notafiscal.Value.ToString() : string.Empty;
                    fNumero.pDt_saient = ret.Dt_saient;
                    fNumero.pDs_dadosadic = ret.Dadosadicionais;
                    fNumero.pDs_obsfiscal = ret.Obsfiscal;
                    fNumero.pSt_sequenciaauto = ret.St_sequenciaauto;
                    fNumero.pCd_movto = ret.Cd_movimentacaostring;
                    fNumero.pCd_cmi = ret.Cd_cmistring;
                    fNumero.pSt_servico = lCfgPed.Count > 0 ? lCfgPed[0].St_servico : false;
                    if (ret.Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        //Buscar inscricao estadual do clifor da nota
                        object obj_insc = new TCD_CadEndereco().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + ret.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_endereco",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + ret.Cd_endereco.Trim() + "'"
                                                }
                                            }, "a.insc_estadual");
                        fNumero.pInsc_estadual = obj_insc == null ? string.Empty : obj_insc.ToString();
                    }
                    fNumero.pTp_frete = ret.Freteporconta;
                    fNumero.pCd_transportadora = ret.Cd_transportadora;
                    fNumero.pNm_transportadora = ret.Nm_razaosocialtransp;
                    fNumero.pCnpjCpfTransp = ret.Cpf_transp;
                    fNumero.pPlacaVeiculo = ret.Placaveiculo;
                    fNumero.pVl_frete = rNF.ItensNota.Sum(p => p.Vl_freteitem);
                    if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ret.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                        if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                            ret.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                        else
                            ret.Nr_notafiscal = null;
                        ret.Nr_serie = fNumero.pNr_serie;
                        ret.Cd_modelo = fNumero.pCd_modelo;
                        ret.Dt_emissao = fNumero.pDt_emissao;
                        ret.Dt_saient = fNumero.pDt_saient;
                        ret.Obsfiscal = fNumero.pDs_obsfiscal;
                        ret.Dadosadicionais = fNumero.pDs_dadosadic;
                        ret.Cd_transportadora = fNumero.pCd_transportadora;
                        ret.Cd_enderecotransp = fNumero.pCd_endtransportadora;
                        ret.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                        ret.Cpf_transp = fNumero.pCnpjCpfTransp;
                        ret.Placaveiculo = fNumero.pPlacaVeiculo;
                        ret.Freteporconta = fNumero.pTp_frete;
                        ret.Especie = fNumero.pEspecie;
                        ret.Quantidade = fNumero.pQuantidade;
                        ret.Pesobruto = fNumero.pPsbruto;
                        ret.Pesoliquido = fNumero.pPsliquido;
                        ret.Vl_frete = fNumero.pVl_frete;
                        ret.Cd_municipioexecservico = fNumero.pCd_municipioexecservico;
                        ret.Ds_municipioexecservico = fNumero.pNm_municipioexecservico;
                        //Preencher objeto CMI
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
                        ret.Cminf.Add(new TRegistro_LanFaturamento_CMI()
                        {
                            St_compdevimposto = rCmi.St_compdevimposto,
                            St_complementar = rCmi.St_complementar,
                            St_devolucao = rCmi.St_devolucao,
                            St_geraestoque = rCmi.St_geraestoque,
                            St_mestra = rCmi.St_mestra,
                            St_simplesremessa = rCmi.St_simplesremessa,
                            St_retorno = rCmi.St_retorno,
                            St_remessatransp = "S"
                        });
                        ret.Cd_cmistring = fNumero.pCd_cmi;
                        ret.Ds_cmi = rCmi.Ds_cmi;
                        ret.Tp_duplicata = rCmi.Tp_duplicata;
                        ret.Ds_tpduplicata = rCmi.ds_tpduplicata;
                    }
                    else
                        throw new Exception("Obrigatorio informar numero da nota fiscal.");
                }
                if (ret.Nr_notafiscal.HasValue)
                {
                    TRegistro_LanFaturamento rFat = TCN_LanFaturamento.existeNumeroNota(ret.Nr_notafiscal.ToString(),
                                                                                        ret.Nr_serie,
                                                                                        ret.Cd_empresa,
                                                                                        ret.Cd_clifor,
                                                                                        string.Empty,
                                                                                        ret.Tp_nota,
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
                TCN_LanFaturamento_Item.Busca(rNF.Cd_empresa,
                                              rNF.Nr_lanctofiscal.Value.ToString(),
                                              string.Empty,
                                              null).ForEach(item =>
                    {
                        TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                        rItem.Cd_empresa = rNF.Cd_empresa;
                        rItem.Cd_produto = item.Cd_produto;
                        rItem.Cd_local = item.Cd_local;
                        rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                        rItem.Cd_unidade = item.Cd_unidade;
                        rItem.Cd_unidEst = item.Cd_unidEst;
                        rItem.Nr_pedido = item.Nr_pedido;
                        rItem.Id_pedidoitem = item.Id_pedidoitem;
                        rItem.Quantidade = item.Quantidade;
                        rItem.Quantidade_estoque = item.Quantidade;
                        rItem.Vl_subtotal = item.Vl_subtotal;
                        rItem.Vl_subtotal_estoque = item.Vl_subtotal;
                        rItem.Vl_unitario = item.Vl_unitario;
                        rItem.Pc_desconto = item.Pc_desconto;
                        rItem.Vl_desconto = item.Vl_desconto;
                        rItem.Vl_freteitem = item.Vl_freteitem;
                        rItem.Pc_juro_fin = item.Pc_juro_fin;
                        rItem.Vl_juro_fin = item.Vl_juro_fin;
                        rItem.Vl_outrasdesp = item.Vl_outrasdesp;
                        rItem.Pc_imposto_Aprox = item.Pc_imposto_Aprox;
                        rItem.Observacao_item = item.Observacao_item;
                        //Buscar cfop do item
                        TRegistro_CadCFOP rCfop = null;
                        if (TCN_Mov_X_CFOP.BuscarCFOP(ret.Cd_movimentacaostring,
                                                      item.Cd_condfiscal_produto,
                                                      ret.Cd_uf_clifor.Trim().Equals("99") ? "I" : ret.Cd_uf_clifor.Trim().Equals(ret.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                      (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Cd_uf_clifor : ret.Cd_uf_empresa),
                                                      (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Cd_uf_empresa : ret.Cd_uf_clifor),
                                                      ret.Tp_movimento,
                                                      ret.Cd_condfiscal_clifor,
                                                      ret.Cd_empresa,
                                                      ref rCfop,
                                                      null))
                        {
                            rItem.Cd_cfop = rCfop.CD_CFOP;
                            rItem.Ds_cfop = rCfop.DS_CFOP;
                            rItem.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (ret.Cd_uf_clifor.Trim().Equals("99") ? "I" : ret.Cd_uf_clifor.Trim().Equals(ret.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + ret.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vObsFiscal = string.Empty;
                        TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(ret.Cd_empresa,
                                                                                               (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Cd_uf_clifor : ret.Cd_uf_empresa),
                                                                                               (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Cd_uf_empresa : ret.Cd_uf_clifor),
                                                                                               ret.Cd_movimentacaostring,
                                                                                               ret.Tp_movimento,
                                                                                               ret.Cd_condfiscal_clifor,
                                                                                               rItem.Cd_condfiscal_produto,
                                                                                               rItem.Vl_subtotal,
                                                                                               rItem.Quantidade,
                                                                                               ref vObsFiscal,
                                                                                               ret.Dt_emissao,
                                                                                               rItem.Cd_produto,
                                                                                               ret.Tp_nota,
                                                                                               ret.Nr_serie,
                                                                                               null);
                        if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                        {
                            TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), rItem);
                            ret.Obsfiscal += vObsFiscal.Trim();
                        }
                        else if (TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, ret.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                    "Tipo Movimento: " + ret.Tipo_movimento.Trim() + "\r\n" +
                                                    "Movimentação: " + ret.Cd_movimentacao.ToString() + "\r\n" +
                                                    "Cond. Fiscal Clifor: " + ret.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                    "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                    "UF Origem: " + (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Uf_clifor.Trim() : ret.Uf_empresa.Trim()) + "\r\n" +
                                                    "UF Destino: " + (ret.Tp_movimento.Trim().ToUpper().Equals("E") ? ret.Uf_empresa.Trim() : ret.Uf_clifor.Trim()));

                        //Procurar impostos sobre os itens da nota fiscal de destino
                        TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(ret.Cd_condfiscal_clifor,
                                                                                  rItem.Cd_condfiscal_produto,
                                                                                  ret.Cd_movimentacaostring,
                                                                                  ret.Tp_movimento,
                                                                                  ret.Tp_pessoa,
                                                                                  ret.Cd_empresa,
                                                                                  ret.Nr_serie,
                                                                                  ret.Cd_clifor,
                                                                                  rItem.Cd_unidEst,
                                                                                  ret.Dt_emissao,
                                                                                  rItem.Quantidade,
                                                                                  rItem.Vl_subtotal,
                                                                                  ret.Tp_nota,
                                                                                  ret.Cd_municipioexecservico,
                                                                                  null), rItem, ret.Tp_movimento);
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
                            ret.Obsfiscal += (string.IsNullOrEmpty(ret.Obsfiscal) ? string.Empty : "\r\n") + obs_ret.Trim();
                        ret.ItensNota.Add(rItem);
                    });
                ret.rNFVendaRT = rNF;
                return ret;
            }
            else 
                throw new Exception("Não existe configuração fiscal pedido para gerar REMESSA TRANSPORTE.");
        }
    }
}
