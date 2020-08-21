using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessarNFCondicional
    {
        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessarCondicional(string Cd_clifor,
                                                                                                       List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens)
        {
            if(new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lItens[0].Cd_empresa.Trim() + "'"
                                }
                            }, "a.cfg_pedcondicional") == null)
                throw new Exception("Não existe configuração para emitir NF Condicional para a empresa " + lItens[0].Cd_empresa.Trim());
            //Buscar configuracao fiscal do pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_PDV_CFGCupomFiscal x " +
                                    "where a.cfg_pedido = x.cfg_pedcondicional " +
                                    "and x.cd_empresa = '" + lItens[0].Cd_empresa.Trim() + "')"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'NO'"
                    }
                }, 1, string.Empty);
            if (lCfgPed.Count.Equals(0))
                throw new Exception("Não existe condição fiscal para o tipo pedido condicional.");
            //Objeto Nota Fiscal
            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
            //Buscar registro empresa
            CamadaDados.Diversos.TRegistro_CadEmpresa rEmpresa =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lItens[0].Cd_empresa, string.Empty, string.Empty, null)[0];
            rNf.Cd_empresa = rEmpresa.Cd_empresa;
            rNf.Cd_uf_empresa = rEmpresa.rEndereco.Cd_uf;
            rNf.Uf_empresa = rEmpresa.rEndereco.UF;
            //Buscar registro clifor
            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(Cd_clifor, null);
            rNf.Cd_clifor = rCliente.Cd_clifor;
            rNf.Cd_condfiscal_clifor = rCliente.Cd_condfiscal_clifor;
            //Buscar endereco cliente
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndereco =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_clifor,
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
            rNf.Cd_endereco = rEndereco.Cd_endereco;
            rNf.Cd_uf_clifor = rEndereco.Cd_uf;
            rNf.Uf_clifor = rEndereco.UF;
            rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
            rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
            rNf.lCFGFiscal = lCfgPed;
            rNf.Tp_duplicata = lCfgPed[0].Tp_duplicata;
            rNf.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
            rNf.Cd_condpgto = lCfgPed[0].CD_CondPgto;
            rNf.Tp_movimento = "S";
            rNf.Tp_pessoa = rCliente.Tp_pessoa;
            rNf.Tp_nota = (rNf.Tp_pessoa.Trim().ToUpper().Equals("J") && rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
            rNf.Nr_serie = lCfgPed[0].Nr_serie;
            rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
            rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
            rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rNf.Dt_saient = rNf.Dt_emissao;
            rNf.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                 rNf.Cd_movimentacaostring,
                                                                 rEndereco.UF.Trim().Equals(rEmpresa.rEndereco.UF.Trim()));
            rNf.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                           rNf.Cd_movimentacaostring,
                                                           rEndereco.UF.Trim().Equals(rEmpresa.rEndereco.UF.Trim()));
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
                    fNumero.pInsc_estadual = rEndereco.Insc_estadual;
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
                    rNf.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                    rNf.Cpf_transp = fNumero.pCnpjCpfTransp;
                    rNf.Placaveiculo = fNumero.pPlacaVeiculo;
                    rNf.Tp_frete = fNumero.pTp_frete;
                    rNf.Especie = fNumero.pEspecie;
                    rNf.Quantidade = fNumero.pQuantidade;
                    rNf.Pesobruto = fNumero.pPsbruto;
                    rNf.Pesoliquido = fNumero.pPsliquido;
                    rNf.Vl_frete = fNumero.pVl_frete;
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
            //Itens da Nota
            lItens.ForEach(item =>
            {
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                rItem.Cd_empresa = item.Cd_empresa;
                rItem.Cd_produto = item.Cd_produto;
                rItem.Cd_local = item.Cd_local;
                rItem.Cd_condfiscal_produto = item.Cd_condfiscal_produto;
                rItem.Cd_unidade = item.Cd_unidade;
                rItem.Cd_unidEst = item.Cd_unidade;
                rItem.Quantidade = item.Qtd_faturar;
                rItem.Quantidade_estoque = item.Qtd_faturar;
                rItem.Vl_subtotal = item.Qtd_faturar * item.Vl_unitario;
                rItem.Vl_subtotal_estoque = item.Qtd_faturar * item.Vl_unitario;
                rItem.Vl_unitario = item.Vl_unitario;
                rItem.Pc_imposto_Aprox = item.Pc_aprox_imposto;
                //Buscar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                bool st_dentroestado = rEndereco.Cd_uf.Trim().Equals(rEmpresa.rEndereco.Cd_uf.Trim());
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                   item.Cd_condfiscal_produto,
                                                                   rEndereco.Cd_uf.Trim().Equals("99") ? "I" :
                                                                   rEndereco.Cd_uf.Trim().Equals(rEmpresa.rEndereco.Cd_uf.Trim()) ? "D" : "F",
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
                    throw new Exception("Não existe CFOP " + (rEndereco.Cd_uf.Trim().Equals("99") ? "internacional" : rEndereco.Cd_uf.Trim().Equals(rEmpresa.rEndereco.Cd_uf.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
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
                rItem.rItemCondicional = item;
                rNf.ItensNota.Add(rItem);
            });
            return rNf;
        }

        public static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento ProcessarNfDevolucao(string Cd_clifor,
                                                                                                       List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens)
        {
            if (new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lItens[0].Cd_empresa.Trim() + "'"
                                }
                            }, "a.cfg_pedcondicional") == null)
                throw new Exception("Não existe configuração para emitir NF Condicional para a empresa " + lItens[0].Cd_empresa.Trim());
            //Buscar configuracao fiscal do pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_PDV_CFGCupomFiscal x " +
                                    "where a.cfg_pedido = x.cfg_pedcondicional " +
                                    "and x.cd_empresa = '" + lItens[0].Cd_empresa.Trim() + "')"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'DV'"
                    }
                }, 1, string.Empty);
            if (lCfgPed.Count.Equals(0))
                throw new Exception("Não existe configuração fiscal de devolução para o tipo pedido condicional.");
            //Objeto Nota Fiscal
            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
            //Buscar registro empresa
            CamadaDados.Diversos.TRegistro_CadEmpresa rEmpresa =
                CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lItens[0].Cd_empresa, string.Empty, string.Empty, null)[0];
            rNf.Cd_empresa = rEmpresa.Cd_empresa;
            rNf.Cd_uf_empresa = rEmpresa.rEndereco.Cd_uf;
            rNf.Uf_empresa = rEmpresa.rEndereco.UF;
            //Buscar registro clifor
            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliente =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(Cd_clifor, null);
            rNf.Cd_clifor = rCliente.Cd_clifor;
            rNf.Cd_condfiscal_clifor = rCliente.Cd_condfiscal_clifor;
            //Buscar endereco cliente
            CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndereco =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_clifor,
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
            rNf.Cd_endereco = rEndereco.Cd_endereco;
            rNf.Cd_uf_clifor = rEndereco.Cd_uf;
            rNf.Uf_clifor = rEndereco.UF;
            rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
            rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
            rNf.lCFGFiscal = lCfgPed;
            rNf.Tp_duplicata = lCfgPed[0].Tp_duplicata;
            rNf.Ds_tpduplicata = lCfgPed[0].Ds_tpduplicata;
            rNf.Cd_condpgto = lCfgPed[0].CD_CondPgto;
            rNf.Tp_movimento = "E";
            rNf.Tp_pessoa = rCliente.Tp_pessoa;
            rNf.Tp_nota = (rNf.Tp_pessoa.Trim().ToUpper().Equals("J") && rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? "T" : "P");
            rNf.Nr_serie = lCfgPed[0].Nr_serie;
            rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
            rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
            rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rNf.Dt_saient = rNf.Dt_emissao;
            rNf.Dadosadicionais = ProcessaAplicacao.BuscarObsMov("D",
                                                                 rNf.Cd_movimentacaostring,
                                                                 rEndereco.UF.Trim().Equals(rEmpresa.rEndereco.UF.Trim()));
            rNf.Obsfiscal = ProcessaAplicacao.BuscarObsMov("F",
                                                           rNf.Cd_movimentacaostring,
                                                           rEndereco.UF.Trim().Equals(rEmpresa.rEndereco.UF.Trim()));
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
                    fNumero.pInsc_estadual = rEndereco.Insc_estadual;
                if (fNumero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rNf.Chave_acesso_nfe = fNumero.pChave_Acesso_NFe;
                    if (!string.IsNullOrEmpty(fNumero.pNr_notafiscal))
                        rNf.Nr_notafiscal = decimal.Parse(fNumero.pNr_notafiscal);
                    else
                        rNf.Nr_notafiscal = null;
                    rNf.Tp_nota = fNumero.pTp_nota;
                    rNf.Nr_serie = fNumero.pNr_serie;
                    rNf.Cd_modelo = fNumero.pCd_modelo;
                    rNf.Dt_emissao = fNumero.pDt_emissao;
                    rNf.Dt_saient = fNumero.pDt_saient;
                    rNf.Obsfiscal = fNumero.pDs_obsfiscal;
                    rNf.Dadosadicionais = fNumero.pDs_dadosadic;
                    rNf.Cd_transportadora = fNumero.pCd_transportadora;
                    rNf.Nm_razaosocialtransp = fNumero.pNm_transportadora;
                    rNf.Cpf_transp = fNumero.pCnpjCpfTransp;
                    rNf.Placaveiculo = fNumero.pPlacaVeiculo;
                    rNf.Tp_frete = fNumero.pTp_frete;
                    rNf.Especie = fNumero.pEspecie;
                    rNf.Quantidade = fNumero.pQuantidade;
                    rNf.Pesobruto = fNumero.pPsbruto;
                    rNf.Pesoliquido = fNumero.pPsliquido;
                    rNf.Vl_frete = fNumero.pVl_frete;
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
            //Itens da Nota
            lItens.ForEach(item =>
            {
                //Item da nota fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rItem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                rItem.Cd_empresa = item.Cd_empresa;
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
                rItem.Pc_imposto_Aprox = item.Pc_aprox_imposto;
                //Buscar cfop do item
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                   item.Cd_condfiscal_produto,
                                                                   rEndereco.Cd_uf.Trim().Equals("99") ? "I" : rEndereco.Cd_uf.Trim().Equals(rEmpresa.rEndereco.Cd_uf.Trim()) ? "D" : "F",
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
                    throw new Exception("Não existe CFOP " + (rEndereco.Cd_uf.Trim().Equals("99") ? "internacional" : rEndereco.Cd_uf.Trim().Equals(rEmpresa.rEndereco.Cd_uf.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + item.Cd_condfiscal_produto);
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
                //Buscar lista de itens nf com saldo para devolver
                List<CamadaDados.Faturamento.NotaFiscal.TRegistro_NFCompDev> lItenDev =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFat_ComplementoDevolucao().SelectNFCompDev(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_itenscondicional_x_nfitem x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                        "and x.id_nfitem = a.id_nfitem " +
                                        "and x.cd_empresa = '" + item.Cd_empresa.Trim() + "' " +
                                        "and x.id_condicional = " + item.Id_condicionalstr + " " +
                                        "and x.id_item = " + item.Id_itemstr + ")"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.quantidade - a.qtd_devolvido",
                            vOperador = ">",
                            vVL_Busca = "0"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    });
                if (lItenDev.Count.Equals(0))
                    throw new Exception("Não existe NF com saldo disponivel para gerar NF de devolução.");
                if (lItenDev.Sum(p => p.Quantidade - p.Qtd_devolvido) < item.Qtd_devolver)
                    throw new Exception("Não existe saldo NF suficiente para gerar NF de devolução.");
                decimal saldo_devolver = item.Qtd_devolver;
                StringBuilder obs = null;
                foreach (CamadaDados.Faturamento.NotaFiscal.TRegistro_NFCompDev r in lItenDev)
                {
                    if (saldo_devolver > decimal.Zero)
                    {
                        rItem.lNfcompdev.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                        {
                            Cd_empresa = r.Cd_empresa,
                            Nr_notafiscal_origem = r.Nr_notafiscal,
                            Nr_serie_origem = r.Nr_serie,
                            Nr_lanctofiscal_origem = r.Nr_lanctofiscal,
                            Id_nfitem_origem = r.Id_nfitem,
                            Qtd_lancto = (r.Quantidade - r.Qtd_devolvido > saldo_devolver ? saldo_devolver : r.Quantidade - r.Qtd_devolvido),
                            Vl_lancto = (r.Quantidade - r.Qtd_devolvido > saldo_devolver ? saldo_devolver : r.Quantidade - r.Qtd_devolvido) * item.Vl_unitario,
                            Tp_operacao = "D"
                        });
                        //Observação do Item com os dados das notas de origem
                        obs = new StringBuilder();
                        obs.Append((r.Nr_notafiscal.ToString() + "/" + r.Nr_serie).PadRight(21, ' ') +
                                    ((r.Quantidade - r.Qtd_devolvido > saldo_devolver ? saldo_devolver : r.Quantidade - r.Qtd_devolvido).ToString("N3", new System.Globalization.CultureInfo("en-US", true))).PadRight(15, ' ') +
                                    ((r.Quantidade - r.Qtd_devolvido > saldo_devolver ? saldo_devolver : r.Quantidade - r.Qtd_devolvido) * item.Vl_unitario).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).PadRight(12, ' ') + "\r\n");
                        saldo_devolver -= (r.Quantidade - r.Qtd_devolvido > saldo_devolver ? saldo_devolver : r.Quantidade - r.Qtd_devolvido);
                    }
                }
                if (!string.IsNullOrEmpty(obs.ToString()))
                    rItem.Observacao_item = "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obs.ToString();
                rItem.rItemCondicional = item;
                rNf.ItensNota.Add(rItem);
            });
            return rNf;
        }
    }
}
