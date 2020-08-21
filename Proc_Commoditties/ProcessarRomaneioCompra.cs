using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessarRomaneioCompra
    {
        public static CamadaDados.Faturamento.Pedido.TRegistro_Pedido ProcessarPedido(List<CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa> lCompra,
                                                                                      string Cd_empresa,
                                                                                      string Cd_clifor)
        {
            if ((lCompra != null) &&
                (!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_clifor)))
            {
                //Buscar moeda padrao
                string moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", Cd_empresa);
                if (string.IsNullOrEmpty(moeda))
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + Cd_empresa);
                //Buscar Endereco clifor
                object obj_end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Cd_clifor.Trim() + "'"
                                        }
                                    }, "a.cd_endereco");
                if (obj_end == null)
                    throw new Exception("Cliente " + Cd_clifor + " não possui endereço cadastrado.");
                //Buscar config do romaneio de compra
                CamadaDados.Faturamento.Cadastros.TList_CfgCompraAvulsa lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CfgCompraAvulsa.Buscar(Cd_empresa, null);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração romaneio de compra para a empresa " + Cd_empresa);
                //Criar objeto pedido
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPed.CD_Empresa = Cd_empresa;
                rPed.CD_Clifor = Cd_clifor;
                rPed.CD_Endereco = obj_end.ToString();
                rPed.Cd_moeda = moeda;
                rPed.CFG_Pedido = lCfg[0].Cfg_pedido;
                rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                rPed.TP_Movimento = "E"; //Pedido de saida
                rPed.ST_Pedido = "F"; //Pedido fechado
                rPed.ST_Registro = "F"; //Pedido fechado
                //Montar itens do pedido
                lCompra.ForEach(p =>
                    //Buscar itens da compra
                    CamadaNegocio.Faturamento.CompraAvulsa.TCN_Compra_Itens.Buscar(p.Cd_empresa,
                                                                                   p.Id_comprastr,
                                                                                   null).ForEach(v=>
                                                                                       {
                                                                                           //Verificar se existe item no pedido
                                                                                           if (rPed.Pedido_Itens.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())))
                                                                                           {
                                                                                               rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Quantidade += v.Quantidade;
                                                                                               rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_subtotal += v.Vl_subtotal;
                                                                                               rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_descCupom += v.Vl_desconto;
                                                                                               rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).lItensCompra.Add(v);
                                                                                           }
                                                                                           else
                                                                                               rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                                                                               {
                                                                                                   Cd_Empresa = v.Cd_empresa,
                                                                                                   Cd_local = v.Cd_local,
                                                                                                   Cd_produto = v.Cd_produto,
                                                                                                   Ds_produto = v.Ds_produto,
                                                                                                   Cd_unidade_est = v.Cd_unidade,
                                                                                                   Cd_unidade_valor = string.Empty,
                                                                                                   Quantidade = v.Quantidade,
                                                                                                   Vl_unitario = v.Vl_unitario,
                                                                                                   Vl_subtotal = v.Vl_subtotal,
                                                                                                   Vl_descCupom = v.Vl_desconto,
                                                                                                   lItensCompra = new CamadaDados.Faturamento.CompraAvulsa.TList_Compra_Itens() { v }
                                                                                               });
                                                                                       })
                    );
                rPed.Pedido_Itens.ForEach(p =>
                {
                    p.Cd_unidade_valor = p.Cd_unidade_est;
                    p.Vl_juro_fin = p.Vl_juroCupom;
                    p.Vl_desc = p.Vl_descCupom;
                });
                return rPed;
            }
            else
                return null;
        }
    }
}
