using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessarPedidoVendaRapida
    {
        public static void ProcessarPedido(string Cd_clifor,
                                           string Cd_endereco,
                                           bool St_nfconsumo,
                                           string Placa,
                                           CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg,
                                           List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItens,
                                           ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedPproduto,
                                           ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico)
        {
            if (lItens.Count > 0)
            {
                //Buscar moeda padrao
                string moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", lItens[0].Cd_empresa);
                if (string.IsNullOrEmpty(moeda))
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + lItens[0].Cd_empresa);
                if ((!St_nfconsumo) && string.IsNullOrEmpty(rCfg.Cfg_pedido))
                    throw new Exception("Não existe configuração para emitir NF direta venda para a empresa " + lItens[0].Cd_empresa.Trim());
                if (St_nfconsumo && string.IsNullOrEmpty(rCfg.Cfg_pedvendaconsumo))
                    throw new Exception("Não existe configuração para emitir NF venda consumo para a empresa " + lItens[0].Cd_empresa.Trim());
                if (string.IsNullOrEmpty(rCfg.Cd_local))
                    throw new Exception("Não existe local armazenagem configurado para a empresa " + lItens[0].Cd_empresa.Trim());
                //Verificar se existe servico na lista de itens
                List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItemServico =
                    lItens.FindAll(p => new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto));
                if ((lItemServico.Count > 0) &&
                    string.IsNullOrEmpty(rCfg.Cfg_pedservico))
                    throw new Exception("Não existe configuração para emitir NF de serviço para a empresa " + lItens[0].Cd_empresa.Trim());
                if (lItemServico.Count > 0)
                {
                    //Remover itens servico da lista de itens
                    lItemServico.ForEach(p => lItens.Remove(p));
                    //Criar objeto pedido servico
                    rPedServico = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPedServico.CD_Empresa = lItemServico[0].Cd_empresa;
                    rPedServico.CD_Clifor = Cd_clifor.Trim();
                    rPedServico.CD_Endereco = Cd_endereco.Trim();
                    rPedServico.Cd_moeda = moeda;
                    rPedServico.Cd_vendedor = string.Empty;
                    rPedServico.CFG_Pedido = rCfg.Cfg_pedservico;
                    //Buscar cidade da empresa
                    CamadaDados.Financeiro.Cadastros.TList_CadCidade lCid =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadCidade().Select(
                        new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_endereco x " +
                                                "inner join tb_div_empresa y " +
                                                "on x.cd_clifor = y.cd_clifor " +
                                                "and x.cd_endereco = y.cd_endereco " +
                                                "where x.cd_cidade = a.cd_cidade " +
                                                "and y.cd_empresa = '" + rPedServico.CD_Empresa.Trim() + "')"
                                }
                            }, 1, string.Empty);
                    if (lCid.Count > 0)
                    {
                        rPedServico.Cd_municipioexecservico = lCid[0].Cd_cidade;
                        rPedServico.Ds_municipioexecservico = lCid[0].Ds_cidade;
                    }
                    rPedServico.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                    rPedServico.TP_Movimento = "S"; //Pedido de saida
                    rPedServico.ST_Pedido = "F"; //Pedido fechado
                    rPedServico.ST_Registro = "F"; //Pedido fechado
                    //Montar itens do pedido
                    foreach(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item p in lItemServico)
                    {
                        rPedServico.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                        {
                            Cd_Empresa = p.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Cd_unidade_est = p.Cd_unidade,
                            Cd_unidade_valor = string.Empty,
                            Quantidade = p.Quantidade,
                            Vl_unitario = p.Vl_unitario,
                            Vl_subtotal = p.Vl_subtotal,
                            Vl_descCupom = p.Vl_desconto,
                            Vl_juroCupom = p.Vl_acrescimo
                        });
                        rPedServico.Pedido_Itens[rPedServico.Pedido_Itens.Count - 1].lItemCF.Add(p);
                    }
                    rPedServico.Pedido_Itens.ForEach(p =>
                    {
                        p.Cd_unidade_valor = p.Cd_unidade_est;
                        p.Vl_juro_fin = p.Vl_juroCupom;
                        p.Vl_desc = p.Vl_descCupom;
                    });
                }
                //Criar objeto pedido
                if (lItens.Count > 0)
                {
                    rPedPproduto = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPedPproduto.CD_Empresa = lItens[0].Cd_empresa;
                    rPedPproduto.CD_Clifor = Cd_clifor.Trim();
                    rPedPproduto.CD_Endereco = Cd_endereco;
                    rPedPproduto.Cd_moeda = moeda;
                    rPedPproduto.Cd_vendedor = string.Empty;
                    rPedPproduto.CFG_Pedido = St_nfconsumo ? rCfg.Cfg_pedvendaconsumo : rCfg.Cfg_pedido;
                    rPedPproduto.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                    rPedPproduto.TP_Movimento = "S"; //Pedido de saida
                    rPedPproduto.ST_Pedido = "F"; //Pedido fechado
                    rPedPproduto.ST_Registro = "F"; //Pedido fechado
                    rPedPproduto.Tp_frete = lItens.Exists(x => x.Vl_frete > decimal.Zero) ? "1" : "9";
                    //Montar itens do pedido
                    foreach(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item p in lItens)
                    {
                        //Buscar Movimentacao Lote Anvisa
                        string obs_item = string.Empty;
                        string enter = string.Empty;
                        CamadaNegocio.Faturamento.LoteAnvisa.TCN_MovLoteAnvisa.Buscar(p.Cd_empresa,
                                                                                      string.Empty,
                                                                                      p.Id_vendarapida.Value.ToString(),
                                                                                      p.Id_lanctovenda.Value.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null).ForEach(v=>
                                                                                          {
                                                                                              obs_item += enter + "Lote=" + v.Nr_lote.Trim() +
                                                                                                          " Qtd=" + v.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) +
                                                                                                          " Fab=" + (v.Dt_fabric.HasValue ? v.Dt_fabric.Value.ToString("dd/MM/yyyy") : string.Empty) +
                                                                                                          " Val=" + (v.Dt_validade.HasValue ? v.Dt_validade.Value.ToString("dd/MM/yyyy") : "INDETERMINADO");
                                                                                              enter = "\r\n";
                                                                                          });
                        if (!string.IsNullOrEmpty(p.Cd_anp))
                            obs_item += enter + "ANP: " + p.Cd_anp.Trim();
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto))
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_cupom",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_vendarapida.Value.ToString()
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_lancto",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_lanctovenda.Value.ToString()
                                    }
                                }, 0, string.Empty, string.Empty).ForEach(v =>
                                    {
                                        obs_item += enter + "#B" + v.Ds_label.Trim() + "##EI" + (v.Encerrantebico - v.Volumeabastecido).ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                                    "##EF" + v.Encerrantebico.ToString("N3", new System.Globalization.CultureInfo("en-US", true));
                                        enter = "\r\n";
                                    });
                        if (rPedPproduto.Pedido_Itens.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())) &&
                            (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("AGRUPAR_ITENS_IGUAIS_NF_DIRETA", p.Cd_empresa, null) == "S"))
                        {
                            rPedPproduto.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Quantidade += p.Quantidade;
                            rPedPproduto.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_subtotal += p.Vl_subtotal;
                            rPedPproduto.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_descCupom += p.Vl_desconto;
                            rPedPproduto.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_juroCupom += p.Vl_acrescimo;
                            rPedPproduto.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Vl_freteitem += p.Vl_frete;
                            rPedPproduto.Pedido_Itens.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).lItemCF.Add(p);
                        }
                        else
                        {
                            rPedPproduto.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                            {
                                Cd_Empresa = p.Cd_empresa,
                                Cd_local = rCfg.Cd_local,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                Cd_unidade_est = p.Cd_unidade,
                                Cd_unidade_valor = string.Empty,
                                Quantidade = p.Quantidade,
                                Vl_unitario = p.Vl_unitario,
                                Vl_subtotal = p.Vl_subtotal,
                                Vl_descCupom = p.Vl_desconto,
                                Vl_juroCupom = p.Vl_acrescimo,
                                Vl_freteitem = p.Vl_frete,
                                Ds_observacaoitem = obs_item
                            });
                            rPedPproduto.Pedido_Itens[rPedPproduto.Pedido_Itens.Count - 1].lItemCF.Add(p);
                        }
                    }
                    rPedPproduto.Pedido_Itens.ForEach(p =>
                    {
                        p.Cd_unidade_valor = p.Cd_unidade_est;
                        p.Vl_juro_fin = p.Vl_juroCupom;
                        p.Vl_desc = p.Vl_descCupom;
                    });
                }
            }
        }
    }
}
