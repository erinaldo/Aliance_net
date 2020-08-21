using CamadaDados.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Proc_Commoditties
{
    public class TProcessaPedidoCargaAvulsa
    {

        public static void GerarPedidoCarga(ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                             CamadaDados.Faturamento.Entrega.TRegistro_CargaAvulsa rCarga,
                                             CamadaDados.Diversos.TRegistro_CfgEmpresa rParam)
        {
            if (!string.IsNullOrEmpty(rParam.CFG_PedRemCargaAvulsa))
            {
                if (rPed == null)
                {
                    rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                    rPed.CD_Empresa = rCarga.Cd_empresa;
                    rPed.DT_Pedido = DateTime.Now;
                    rPed.CFG_Pedido = rParam.CFG_PedRemCargaAvulsa;
                    rPed.TP_Movimento = "S"; //Pedido de saida
                    rPed.ST_Pedido = "F"; //Pedido fechado
                    rPed.ST_Registro = "F"; //Pedido fechado
                    rPed.CD_Clifor = rParam.Cd_clifor;
                    rPed.CD_Endereco = rParam.Cd_endereco;
                    //Buscar Moeda Padrao
                    TList_Moeda tabela =
                        CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(rCarga.Cd_empresa, null);
                    if (tabela != null)
                        if (tabela.Count > 0)
                            rPed.Cd_moeda = tabela[0].Cd_moeda;
                }
                //Buscar Local Arm
                object LocalArm = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rCarga.Cd_empresa.Trim() + "'"
                        }
                    }, "a.CD_Local");
                if (LocalArm == null)
                    throw new Exception("Não existe Local de armazenagem configurado para Empresa" + rCarga.Cd_empresa.Trim() + "!");
                for (int i= 0; i < rCarga.lItens.Count; i++) 
                {
                    //Buscar Preço
                    decimal vl_preco = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rCarga.Cd_empresa,
                                                                                                            rCarga.lItens[i].Cd_produto,
                                                                                                            rParam.Cd_tabelapreco,
                                                                                                            null);
                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = rCarga.lItens[i].Cd_empresa;
                    reg.Cd_local = LocalArm.ToString();
                    reg.Cd_produto = rCarga.lItens[i].Cd_produto;
                    reg.Ds_produto = rCarga.lItens[i].Ds_produto;
                    reg.Cd_unidade_est = rCarga.lItens[i].Cd_unidade;
                    reg.Quantidade = rCarga.lItens[i].Quantidade;
                    reg.Vl_unitario = vl_preco;
                    reg.Vl_subtotal = vl_preco * rCarga.lItens[i].Quantidade;
                    rPed.Pedido_Itens.Add(reg);
                }
            }
            else
                throw new Exception("Não existe configuracao para emitir pedido de remessa para a Empresa " + rCarga.Cd_empresa);
        }
    }
}
