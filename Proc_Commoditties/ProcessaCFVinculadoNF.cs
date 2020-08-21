using System;
using System.Collections.Generic;

namespace Proc_Commoditties
{
    public class TProcessaCFVinculadoNF
    {
        public static CamadaDados.Faturamento.Pedido.TRegistro_Pedido ProcessarPedido(List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lCupom,
                                                                                      string Cd_empresa,
                                                                                      string Cd_cliente)
        {
            if ((lCupom != null) &&
                (!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_cliente)))
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
                                            vVL_Busca = "'" + Cd_cliente.Trim() + "'"
                                        }
                                    }, "a.cd_endereco");
                if (obj_end == null)
                    throw new Exception("Cliente " + Cd_cliente + " não possui endereço cadastrado.");
                //Buscar Configuracao cupom
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfgCupom =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(Cd_empresa, null);
                if (lCfgCupom.Count < 1)
                    throw new Exception("Não existe configuração cupom fiscal para a empresa " + Cd_empresa);
                if (string.IsNullOrEmpty(lCfgCupom[0].Cfg_pedidovinculado))
                    throw new Exception("Não existe tipo pedido vinculado configurado para a empresa " + Cd_empresa);
                //Criar objeto pedido
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPed.CD_Empresa = Cd_empresa;
                rPed.CD_Clifor = Cd_cliente;
                rPed.CD_Endereco = obj_end.ToString();
                rPed.Cd_moeda = moeda;
                rPed.CFG_Pedido = lCfgCupom[0].Cfg_pedidovinculado;
                rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                rPed.TP_Movimento = "S"; //Pedido de saida
                rPed.ST_Pedido = "F"; //Pedido fechado
                rPed.ST_Registro = "F"; //Pedido fechado
                //Montar itens do pedido
                lCupom.ForEach(p =>
                {
                    //Buscar itens do cupom
                    p.lItem = CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(p.Id_nfcestr, p.Cd_empresa, string.Empty, null);
                    p.lItem.ForEach(v =>
                    {
                        //Verificar se existe item no pedido
                        if (rPed.Pedido_Itens.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())) &&
                            (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("AGRUPAR_ITENS_IGUAIS_NF_DIRETA", p.Cd_empresa, null) == "S"))
                        {
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Quantidade += v.Quantidade;
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_subtotal += v.Vl_subtotal;
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_descCupom += v.Vl_desconto;
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_juroCupom += v.Vl_acrescimo;
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_unitario = 
                                Math.Round(rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Vl_subtotal /
                                rPed.Pedido_Itens.Find(x => x.Cd_produto.Trim().Equals(v.Cd_produto.Trim())).Quantidade, 7);
                        }
                        else
                            rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                            {
                                Cd_Empresa = p.Cd_empresa,
                                Cd_produto = v.Cd_produto,
                                Ds_produto = v.Ds_produto,
                                Cd_condfiscal_produto = v.Cd_condfiscal_produto,
                                Cd_unidade_est = v.Cd_unidade,
                                Cd_unidade_valor = string.Empty,
                                Quantidade = v.Quantidade,
                                Vl_unitario = v.Vl_unitario,
                                Vl_subtotal = v.Vl_subtotal,
                                Vl_descCupom = v.Vl_desconto,
                                Vl_juroCupom = v.Vl_acrescimo
                            });
                    });
                });
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
