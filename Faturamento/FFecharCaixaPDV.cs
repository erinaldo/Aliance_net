using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFFecharCaixaPDV : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rcaixa;
        public CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa
        {
            get
            {
                if (bsCaixa.Current != null)
                    return bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV;
                else
                    return null;
            }
            set { rcaixa = value; }
        }

        public TFFecharCaixaPDV()
        {
            InitializeComponent();
        }
                
        private void afterBusca()
        {
            if(bsCaixa.Current != null)
            {
                (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa =
                CamadaNegocio.Faturamento.PDV.TCN_FechamentoCaixa.Buscar((bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                         string.Empty,
                                                                         "'A'",
                                                                         null);
                tot_credito.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_credito);
                bsCaixa.ResetCurrentItem();
                List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lMov =
                    new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(new Utils.TpBusca[]
                                                                                    {
                                                                                        new Utils.TpBusca()
                                                                                        {
                                                                                            vNM_Campo = "a.id_caixa",
                                                                                            vOperador = "=",
                                                                                            vVL_Busca = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                                                        },
                                                                                        new Utils.TpBusca()
                                                                                        {
                                                                                            vNM_Campo = "a.cd_portador",
                                                                                            vOperador = "=",
                                                                                            vVL_Busca = string.IsNullOrEmpty(cd_portador.Text) ? "a.cd_portador" : ("'" + cd_portador.Text.Trim() + "'")
                                                                                        }
                                                                                    }, "cd_portador, id_cupom");
                vl_suprimento.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_suprimento);
                vl_retirada.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_retirada + p.Vl_emprestimo);
                vl_caixa.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_liquido);
                vl_auditado.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_auditado);
                vl_diferenca.Value = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lFechamentoCaixa.Sum(p => p.Vl_diferencaAudit);
                bsMovCaixa.DataSource = lMov;

                bsResumoCartao.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectResumoCartao(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.ID_Caixa",
                                                        vOperador = "=",
                                                        vVL_Busca = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                                    }
                                                });

                //BUSCAR PLACAS BLOQUEADS

                tListPlacaBloqPontosBindingSource.DataSource = CamadaNegocio.PostoCombustivel.TCN_PlacaBloqPontos.Buscar(string.Empty, null);


                //Buscar Duplicatas
                bsDuplicata.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "exists(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and x.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") or " +
                                                                "exists(select 1 from tb_pdv_emprestimoconcedido x " +
                                                                "inner join tb_pdv_retiradacaixa y " +
                                                                "on x.id_retirada = y.id_retirada " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and y.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")"
                                                }
                                            }, 0, string.Empty).OrderBy(p => p.Dt_emissao).OrderBy(p => p.Nr_lancto).ToList();
                vl_carteira.Value = (bsDuplicata.DataSource as List<CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata>).Sum(p => p.Vl_documento_padrao);
                //Buscar financeiro recebido caixa
                bsLiqRecebido.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanLiquidacao().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'R'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_caixa_x_liquidacao y " +
                                                            "where y.cd_empresa = a.cd_empresa " +
                                                            "and y.nr_lancto = a.nr_lancto " +
                                                            "and y.cd_parcela = a.cd_parcela " +
                                                            "and y.id_liquid = a.id_liquid " +
                                                            "and y.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")"
                                            }
                                        }, 0, string.Empty).OrderBy(p=> p.Cd_clifor).ToList();
                if (bsLiqRecebido.Count > 0)
                    tot_recebido.Value = (bsLiqRecebido.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_LanLiquidacao>).Sum(p => p.Vl_liquidado_padrao);
                //Buscar financeiro pago caixa
                bsLiqPago.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanLiquidacao().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "t.tp_mov",
                                                vOperador = "=",
                                                vVL_Busca = "'P'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_caixa_x_liquidacao y " +
                                                            "where y.cd_empresa = a.cd_empresa " +
                                                            "and y.nr_lancto = a.nr_lancto " +
                                                            "and y.cd_parcela = a.cd_parcela " +
                                                            "and y.id_liquid = a.id_liquid " +
                                                            "and y.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")"
                                            }
                                        }, 0, string.Empty).OrderBy(p => p.Cd_clifor).ToList();
                if (bsLiqPago.Count > 0)
                    tot_pago.Value = (bsLiqPago.List as List<CamadaDados.Financeiro.Duplicata.TRegistro_LanLiquidacao>).Sum(p => p.Vl_liquidado_padrao);
                //Buscar itens venda do caixa
                bsItens.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().SelectCFAuditCaixa(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "(exists(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.id_cupom = a.id_vendarapida " +
                                                            "and x.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")) or " +
                                                            "(exists(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "				where x.CD_Empresa = a.cd_empresa " +
                                                            "				and x.Id_Cupom = a.id_vendarapida " +
                                                            "and x.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + "))"
                                            }
                                        });
                //Sintetizar Venda Recebida Caixa
                bsSinteticoVendas.DataSource = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).GroupBy(p => p.Ds_produto,
                (aux, venda) =>
                new
                {
                    produto = aux,
                    quantidade = venda.Sum(x => x.Quantidade),
                    vl_unitario = venda.Average(x => x.Vl_unitario),
                    vl_subtotal = venda.Sum(x => x.Vl_subtotal),
                    vl_desconto = venda.Sum(x => x.Vl_desconto),
                    vl_acrescimo = venda.Sum(x=> x.Vl_acrescimo),
                    vl_liquido = venda.Sum(x => x.Vl_subtotalliquido)
                }).OrderBy(p=> p.produto).ToList();
                bsSinteticoGrupoProd.DataSource = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).GroupBy(p => p.Ds_grupo,
                    (aux, venda) =>
                        new
                        {
                            grupo = aux.Trim(),
                            quantidade = venda.Sum(x => x.Quantidade),
                            vl_unitario = venda.Average(x => x.Vl_unitario),
                            vl_subtotal = venda.Sum(x => x.Vl_subtotal),
                            vl_desconto = venda.Sum(x => x.Vl_desconto),
                            vl_acrescimo = venda.Sum(x => x.Vl_acrescimo),
                            vl_liquido = venda.Sum(x => x.Vl_subtotalliquido)
                        }).OrderBy(p => p.grupo).ToList();
                //Totalizar Venda
                tot_venda.Value = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p => p.Vl_desconto);
                tot_acrescimo.Value = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p => p.Vl_acrescimo);
                tot_liquido.Value = (bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p => p.Vl_subtotalliquido);
                //Buscar retiradas caixa
                (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).lRetiradas =
                    CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Buscar(string.Empty,
                                                                           (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                           "'S', 'R'",
                                                                           string.Empty,
                                                                           null);
                //Buscar emprestimos concedidos
                bsEmprestimo.DataSource = CamadaNegocio.Faturamento.PDV.TCN_EmprestimoConcedido.Buscar(string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       null);
                //Buscar credito avulso
                bsCredAvulso.DataSource = CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           decimal.Zero,
                                                                                                           string.Empty,
                                                                                                           string.Empty,
                                                                                                           decimal.Zero,
                                                                                                           decimal.Zero,
                                                                                                           false,
                                                                                                           false,
                                                                                                           false,
                                                                                                           string.Empty,
                                                                                                           false,
                                                                                                           false,
                                                                                                           (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                           string.Empty,
                                                                                                           0,
                                                                                                           string.Empty,
                                                                                                           null);
                //Dev Credito Avulso
                bsCaixaDevCredAvulso.DataSource = CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_DevCredAvulso.Buscar(string.Empty,
                                                                                                                 (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 null);
                //Buscar Cheque Troco
                bsChTroco.DataSource = CamadaNegocio.Faturamento.PDV.TCN_TrocoCH.BuscarCh((bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr,
                                                                                          null);
                vl_chTroco.Value = (bsChTroco.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Sum(p => p.Vl_titulo);
                //Buscar Cheque Recebido
                bsChRecebido.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca { vNM_Campo = "isnull(a.status_compensado, 'N')", vOperador = "<>", vVL_Busca = "'C'" },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "exists(select 1 from TB_FIN_Titulo_X_Caixa x " +
				                                                            "inner join TB_PDV_Cupom_X_MovCaixa y " +
				                                                            "on x.CD_ContaGer = y.CD_ContaGer " +
				                                                            "and x.CD_LanctoCaixa = y.CD_LanctoCaixa " +
				                                                            "where x.CD_Empresa = a.cd_empresa " +
				                                                            "and x.CD_Banco = a.cd_banco " +
				                                                            "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
				                                                            "and y.ID_Caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") or " +
	                                                             "exists(select 1 from TB_FIN_Titulo_X_Caixa x " +
				                                                            "inner join TB_PDV_Cupom_X_DevCredito y " +
				                                                            "on x.CD_ContaGer = y.CD_ContaGer " +
				                                                            "and x.CD_LanctoCaixa = y.CD_LanctoCaixa_Dev " +
				                                                            "where x.CD_Empresa = a.cd_empresa " +
				                                                            "and x.CD_Banco = a.cd_banco " +
				                                                            "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
				                                                            "and y.ID_Caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") or " +
	                                                             "exists(select 1 from TB_FIN_Titulo_X_Caixa x " +
				                                                            "inner join TB_FIN_Liquidacao y " +
				                                                            "on x.CD_ContaGer = y.CD_ContaGer " +
				                                                            "and x.CD_LanctoCaixa = y.CD_LanctoCaixa " +
				                                                            "inner join TB_PDV_Caixa_X_Liquidacao z " +
				                                                            "on y.CD_Empresa = z.CD_Empresa " +
				                                                            "and y.Nr_Lancto = z.Nr_Lancto " +
				                                                            "and y.CD_Parcela = z.CD_Parcela " +
				                                                            "and y.ID_Liquid = z.ID_Liquid " +
				                                                            "where x.CD_Empresa = a.cd_empresa " +
				                                                            "and x.CD_Banco = a.cd_banco " +
				                                                            "and x.Nr_LanctoCheque = a.nr_lanctocheque " +
				                                                            "and z.ID_Caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") or " +
	                                                             "exists(select 1 from TB_PDV_TrocaEspecie x " +
				                                                            "where x.CD_Empresa = a.cd_empresa " +
				                                                            "and x.CD_Banco = a.cd_banco " +
				                                                            "and x.Nr_LanctoCheque = a.Nr_LanctoCheque " +
				                                                            "and x.ID_Caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") "
                                                }
                                            }, 0, string.Empty, string.Empty);

                //buscarabastecidas 
                bsPontosFidelidade.DataSource = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from VTB_PDV_MovCaixa x where x.id_Cupom = a.Id_Cupom and a.CD_Empresa = x.CD_Empresa "+
                                        " and x.id_caixa = "+(bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr+")"
                        },
                        new Utils.TpBusca {vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                    } ,0,string.Empty, string.Empty);
                bsPontosFidelidade.ResetCurrentItem();
                BuscarCartaFrete();
                vl_cartafrete.Value = (bsCartaFrete.List as CamadaDados.PostoCombustivel.TList_CartaFrete).Sum(p => p.Vl_documento);
                bsCaixa.ResetCurrentItem();
            }
        }

        private void BuscarCartaFrete()
        {
            //Buscar Carta Frete
            bsCartaFrete.DataSource = new CamadaDados.PostoCombustivel.TCD_CartaFrete(null).Select(
                                        new Utils.TpBusca[]
                                        {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = string.Empty,
                                                    vVL_Busca = "(g.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ") or " +
                                                                "exists(select 1 from tb_fin_liquidcartafrete x " +
                                                                "       inner join tb_fin_liquidacao y " +
                                                                "       on x.cd_contager = y.cd_contager " +
                                                                "       and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                                "       inner join tb_pdv_caixa_x_liquidacao z " +
                                                                "       on x.CD_Empresa = a.CD_Empresa " +
                                                                "       and x.ID_CartaFrete = a.ID_CartaFrete " +
                                                                "       and y.cd_empresa = z.cd_empresa " +
                                                                "       and y.nr_lancto = z.nr_lancto " +
                                                                "       and y.cd_parcela = z.cd_parcela " +
                                                                "       and y.id_liquid = z.id_liquid " +
                                                                "       where z.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")or " +
                                                                "exists(select 1 from tb_pdv_trocaespecie x " +
                                                                "       where x.cd_empresa = a.cd_empresa " +
                                                                "       and x.id_cartafrete = a.id_cartafrete " +
                                                                "       and x.id_caixa = " + (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr + ")"

                                                }
                                        }, 0, string.Empty);
        }

        private void InserirRetirada()
        {
            using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
            {
                fRetirar.pId_caixa = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                if (fRetirar.ShowDialog() == DialogResult.OK)
                    if (fRetirar.rRetirada != null)
                    {
                        try
                        {
                            fRetirar.rRetirada.Id_caixastr = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                            fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                            CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                            MessageBox.Show("Retirada gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
            }
        }

        private void CancelarRetirada()
        {
            if (bsRetirada.Current != null)
            {
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido CANCELAR retirada PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Retirada ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma cancelamento da retirada selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Cancelar((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa), null);
                        MessageBox.Show("Retirada CANCELADA com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar retirada para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarRetirada()
        {
            if (bsRetirada.Current != null)
            {
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido processar retirada cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Retirada ja se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirmar processamento da retidada?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (Proc_Commoditties.TFProcessarRetiradaCaixa fProc = new Proc_Commoditties.TFProcessarRetiradaCaixa())
                    {
                        fProc.Vl_processar = (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Vl_retirada;
                        fProc.Id_caixa = (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Id_caixastr;
                        if (fProc.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).lPortador = fProc.lPortador;
                                CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.ProcessarRetirada(bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa, null);
                                MessageBox.Show("Retirada processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar retirada para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReprocessarFinCupom()
        {
            if (bsMovCaixa.Current != null)
            {
                if ((bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Id_cupom == null)
                {
                    MessageBox.Show("Não é permitido reprocessar financeiro de CONTAS RECEBER.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Vl_DevCredito > decimal.Zero)
                {
                    MessageBox.Show("Não é permitido reprocessar financeiro de CUPOM com DEVOLUÇÃO DE CRÉDITOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Id_movimento.HasValue)
                {
                    MessageBox.Show("Permitido reprocessar financeiro somente de recebimento de VENDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                {
                    //Buscar registro cupom
                    fFechar.rCupom = 
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar((bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Id_cupom.Value.ToString(),
                                                                             (bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Cd_empresa,
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
                                                                             string.Empty,
                                                                             0,
                                                                             null)[0];
                    fFechar.rCupom.lItem =
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(fFechar.rCupom.Id_vendarapidastr,
                                                                                  fFechar.rCupom.Cd_empresa,
                                                                                  false,
                                                                                  string.Empty,
                                                                                  null);
                    //Buscar Cfg Empresa
                    CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                        CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(fFechar.rCupom.Cd_empresa, null);
                    if (lCfg.Count > 0)
                        fFechar.rCfg = lCfg[0];
                    else
                    {
                        MessageBox.Show("Não existe configuração de cupom fiscal para a empresa " + fFechar.rCupom.Cd_empresa.Trim(),
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    fFechar.pCd_empresa = fFechar.rCupom.Cd_empresa;
                    fFechar.pNm_empresa = fFechar.rCupom.Nm_empresa;
                    fFechar.pCd_clifor = fFechar.rCupom.Cd_clifor;
                    fFechar.pNm_clifor = fFechar.rCupom.Nm_clifor;
                    fFechar.pVl_receber = (bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Vl_recebido;
                    fFechar.pVl_outrosrec = (bsMovCaixa.List as List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>).Where(p => p.Cd_empresa.Trim().Equals(fFechar.rCupom.Cd_empresa.Trim()) &&
                                                                                                                                p.Id_cupom.Equals(fFechar.rCupom.Id_vendarapida) &&
                                                                                                                                p.Cd_portador.Trim() != (bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa).Cd_portador.Trim()).Sum(p => p.Vl_recebido);
                    
                    fFechar.St_ReprocessaFin = true;
                    fFechar.LoginPDV = Utils.Parametros.pubLogin;
                    fFechar.Id_caixaPDV = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                    if (fFechar.ShowDialog() == DialogResult.OK)
                        if (fFechar.lPortador != null)
                            try
                            {
                                fFechar.rCupom.lPortador = fFechar.lPortador;
                                CamadaNegocio.Faturamento.PDV.TCN_Cupom_X_MovCaixa.ReprocessarFin(bsMovCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_MovCaixa, 
                                                                                                  fFechar.rCupom,
                                                                                                  null);
                                afterBusca();

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void InserirFechamento()
        {
            using (TFFechamentoCaixaPDV fFechar = new TFFechamentoCaixaPDV())
            {
                fFechar.Id_caixa = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr;
                if(fFechar.ShowDialog() == DialogResult.OK)
                    if(fFechar.rFechamento != null)
                        try
                        {
                            fFechar.rFechamento.Loginaudit = Utils.Parametros.pubLogin;
                            CamadaNegocio.Faturamento.PDV.TCN_FechamentoCaixa.Gravar(fFechar.rFechamento, null);
                            MessageBox.Show("Fechamento de caixa gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void ExcluirFechamento()
        {
            if(bsResumo.Current != null)
                if(MessageBox.Show("Confirma exclusão do fechamento selecionado?", "Mensagem", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_FechamentoCaixa.Cancelar(bsResumo.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa, null);
                        MessageBox.Show("Fechamento caixa excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), "tp_portadorpdv|=|'A'");
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "tp_portadorpdv|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFFecharCaixaPDV_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gMovCaixa);
            Utils.ShapeGrid.RestoreShape(this, gLiquidaLancFin);
            Utils.ShapeGrid.RestoreShape(this, g_Consulta);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault6);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pBuscaPortador.set_FormatZero();
            bsCaixa.DataSource = new CamadaDados.Faturamento.PDV.TList_CaixaPDV() { rcaixa };
            afterBusca();
            if (rcaixa.St_registro.Trim().ToUpper().Equals("P"))
            {
                bb_inutilizar.Enabled = false;
                bb_novofechamento.Enabled = false;
                bb_excluifechamento.Enabled = false;
                bb_reprocessarfin.Enabled = false;
                btn_Inserir_Item.Enabled = false;
                BB_Alterar_Item.Enabled = false;
                btn_Deleta_Item.Enabled = false;
                bb_alterarUnidPagadora.Enabled = false;

            }
            else
                vl_auditresumo.Focus();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            //Verificar se existe suprimento/retirada a processar
            if(bsRetirada.Count > 0)
                if ((bsRetirada.List as CamadaDados.Faturamento.PDV.TList_RetiradaCaixa).Exists(p => p.St_registro.Trim().ToUpper().Equals("A")))
                {
                    MessageBox.Show("Não é permitido AUDITAR caixa com SUPRIMENTO/RETIRADA a PROCESSAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            //Verificar se existe fechamento de caixa para todos os portadores movimentados
            object obj = new CamadaDados.Faturamento.PDV.TCD_Cupom_X_MovCaixa().BuscarEscalar(
                            new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_caixa",
                                        vOperador = "=",
                                        vVL_Busca = (bsCaixa.Current as CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV).Id_caixastr
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(c.st_cartafrete, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_pdv_fechamentocaixa x " +
                                                    "where x.id_caixa = a.id_caixa " +
                                                    "and x.cd_portador = a.cd_portador " +
                                                    "and isnull(x.st_registro, 'A') <> 'C')"
                                    }
                                }, "a.cd_portador");
            if (obj != null)
                if (MessageBox.Show("Existe portador(" + obj.ToString() + ") com movimento de caixa e sem fechamento.\r\n" +
                                   "Confirma AUDITORIA mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
            DialogResult = DialogResult.OK;
        }

        private void TFFecharCaixaPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4) && bb_inutilizar.Enabled)
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tlpMov.SelectedTab.Equals(tpMovRetirada) && btn_Inserir_Item.Enabled)
                InserirRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tlpMov.SelectedTab.Equals(tpMovRetirada) && BB_Alterar_Item.Enabled)
                ProcessarRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tlpMov.SelectedTab.Equals(tpMovRetirada) && btn_Deleta_Item.Enabled)
                CancelarRetirada();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tlpMov.SelectedTab.Equals(tpMovResumo) && bb_novofechamento.Enabled)
                InserirFechamento();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tlpMov.SelectedTab.Equals(tpMovResumo) && bb_excluifechamento.Enabled)
                ExcluirFechamento();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            if (bsResumo.Current != null)
                (bsResumo.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).Vl_auditado = vl_auditresumo.Value;
            bsResumo.MovePrevious();

            vl_auditresumo.Focus();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            if (bsResumo.Current != null)
                (bsResumo.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).Vl_auditado = vl_auditresumo.Value;
            bsResumo.MoveNext();
            vl_auditresumo.Focus();
        }

        private void bb_reprocessarfin_Click(object sender, EventArgs e)
        {
            ReprocessarFinCupom();
        }

        private void bsResumo_PositionChanged(object sender, EventArgs e)
        {
            if (bsResumo.Current != null)
                vl_auditresumo.Enabled = (!rcaixa.St_registro.Trim().ToUpper().Equals("P")) &&  
                                        (!(bsResumo.Current as CamadaDados.Faturamento.PDV.TRegistro_FechamentoCaixa).St_cartao);
        }

        private void bb_novofechamento_Click(object sender, EventArgs e)
        {
            InserirFechamento();
        }

        private void bb_excluifechamento_Click(object sender, EventArgs e)
        {
            ExcluirFechamento();
        }

        private void gRetirada_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    gRetirada.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            CancelarRetirada();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            ProcessarRetirada();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirRetirada();
        }

        private void vl_auditresumo_EnabledChanged(object sender, EventArgs e)
        {
            ds_observacao.Enabled = vl_auditresumo.Enabled;
        }

        private void TFFecharCaixaPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gMovCaixa);
            Utils.ShapeGrid.SaveShape(this, gLiquidaLancFin);
            Utils.ShapeGrid.SaveShape(this, g_Consulta);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault6);
        }

        private void gEmprestimos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    gEmprestimos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gEmprestimos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bb_alterarUnidPagadora_Click(object sender, EventArgs e)
        {
            if (bsCartaFrete.Current != null)
            {
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);

                //Alterar Unidade pagadora
                if (linha != null)
                    try
                    {
                        (bsCartaFrete.Current as CamadaDados.PostoCombustivel.TRegistro_CartaFrete).Cd_unidpagadora = linha["cd_clifor"].ToString();
                        CamadaNegocio.PostoCombustivel.TCN_CartaFrete.AlterarUnidPagadora(bsCartaFrete.Current as CamadaDados.PostoCombustivel.TRegistro_CartaFrete, null);
                        MessageBox.Show("Unidade Pagadora alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarCartaFrete();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            CamadaDados.PostoCombustivel.TRegistro_PlacaBloqPontos placa = new CamadaDados.PostoCombustivel.TRegistro_PlacaBloqPontos();
            Utils.InputBox ibp = new Utils.InputBox("AAA-0000","Informe a placa"); 
            placa.Placa = ibp.ShowDialog();
            if (!string.IsNullOrEmpty(placa.Placa))
            {
                tListPlacaBloqPontosBindingSource.ResetCurrentItem();
                CamadaNegocio.PostoCombustivel.TCN_PlacaBloqPontos.Gravar(placa, null);
                tListPlacaBloqPontosBindingSource.Add(placa);
            }
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja excluir placa?","Mensagem",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                CamadaNegocio.PostoCombustivel.TCN_PlacaBloqPontos.Excluir((tListPlacaBloqPontosBindingSource.Current as CamadaDados.PostoCombustivel.TRegistro_PlacaBloqPontos), null);
                tListPlacaBloqPontosBindingSource.RemoveCurrent();
            }
        }

        private void tsbBloqPlaca_Click(object sender, EventArgs e)
        {
            if((bsPontosFidelidade.Current != null))
            {
                try
                {
                    CamadaNegocio.PostoCombustivel.TCN_PlacaBloqPontos.Gravar(
                        new CamadaDados.PostoCombustivel.TRegistro_PlacaBloqPontos { Placa = (bsPontosFidelidade.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade).Placa }, null);
                    MessageBox.Show("Placa bloqueada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
