using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Balanca;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Estoque.Cadastros;
using System.Linq;
using NumeroNota;
using CamadaNegocio.Balanca;

namespace Proc_Commoditties
{
    public class TProcessarPedPSDiversos
    {
        public static TRegistro_LanFaturamento ProcessarAplicPsDiversos(List<TRegistro_PesagemDiversas> lTicket)
        {
            if (lTicket.Count > 0)
            {
                using (TFPedidoPsDiversa fPed = new TFPedidoPsDiversa())
                {
                    fPed.pTp_movimento = lTicket[0].Tp_movimento;
                    fPed.pCd_empresa = lTicket[0].Cd_empresa;
                    fPed.pNm_empresa = lTicket[0].Nm_empresa;
                    fPed.pCd_clifor = lTicket[0].Cd_clifor;
                    fPed.pNm_clifor = lTicket[0].Nm_clifor;
                    fPed.pCd_produto = lTicket[0].Cd_produto;
                    fPed.pDs_produto = lTicket[0].Ds_produto;
                    fPed.pCd_unidade = lTicket[0].Cd_unidade;
                    fPed.pSg_produto = lTicket[0].Sg_produto;
                    string und_balanca = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("UND_BALANCA", lTicket[0].Cd_empresa);
                    if (!string.IsNullOrEmpty(und_balanca))
                        fPed.pQuantidade = TCN_CadConvUnidade.ConvertUnid(und_balanca, lTicket[0].Cd_unidade, lTicket.Sum(p => p.Ps_liquidobruto), 3, null);
                    else fPed.pQuantidade = lTicket.Sum(p => p.Ps_liquidobruto);
                    if (fPed.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                        try
                        {
                            rPed.TP_Movimento = lTicket[0].Tp_movimento;
                            rPed.CD_Empresa = fPed.pCd_empresa;
                            rPed.CFG_Pedido = fPed.cfg_pedido;
                            rPed.CD_Clifor = fPed.pCd_clifor;
                            rPed.CD_Endereco = fPed.cd_endereco;
                            rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                            rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                            {
                                Cd_produto = fPed.pCd_produto,
                                Cd_unidade_valor = fPed.cd_unidade,
                                Cd_local = fPed.cd_local,
                                Quantidade = fPed.quantidade,
                                Vl_unitario = fPed.vl_unitario,
                                Vl_subtotal = fPed.vl_subtotal
                            });
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            //Buscar pedido
                            rPed = TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            TRegistro_LanFaturamento rNota = Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                            rNota.Placaveiculo = lTicket[0].Placacarreta;
                            rNota.Pesobruto = lTicket.Sum(p => p.Ps_bruto);
                            rNota.Pesoliquido = lTicket.Sum(p => p.Ps_liquidobruto);
                            rNota.Cd_transportadora = lTicket[0].Cd_transp;
                            rNota.Nm_razaosocialtransp = lTicket[0].Nm_transp;
                            return rNota;
                        }
                        catch (Exception ex)
                        {
                            TCN_Pedido.Deleta_Pedido(rPed, null);
                            throw new Exception(ex.Message.Trim());
                        }
                    }
                    else return null;
                }
            }
            else return null;
        }
    }
}
