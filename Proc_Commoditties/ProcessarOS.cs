using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{
    public class TProcessarOS
    {
        public static CamadaDados.Faturamento.PDV.TRegistro_PreVenda ProcessarOSPeca(CamadaDados.Servicos.TRegistro_LanServico val,
                                                                                     ref CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia)
        {
            CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
            if (val.lPecas.Exists(p => !p.St_atendimentogarantiabool))
            {
                //Buscar config OS
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                    CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(val.Tp_ordemstr,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            1,
                                                                            string.Empty,
                                                                            null);
                if (lParam.Count > 0)
                {
                    rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                    rPreVenda.Cd_empresa = val.Cd_empresa;
                    rPreVenda.Cd_clifor = val.Cd_clifor;
                    rPreVenda.Nm_clifor = val.Nm_clifor;
                    rPreVenda.Cd_endereco = val.Cd_endereco;
                    rPreVenda.Cd_vendedor = val.lEvolucao.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico)) ? val.lEvolucao.FindLast(p => !string.IsNullOrEmpty(p.Cd_tecnico)).Cd_tecnico : string.Empty;
                    rPreVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rPreVenda.St_registro = "A";
                    rPreVenda.Ds_observacao = val.Ds_observacoesgerais;
                    val.lPecas.Where(p => !p.St_atendimentogarantiabool).ToList().ForEach(p =>
                        {
                            if (string.IsNullOrEmpty(p.Cd_produto))
                            {
                                object obj = new CamadaDados.Faturamento.CompraAvulsa.TCD_Compra_Itens().BuscarEscalar(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_compraitens_x_pecaOS x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_compra = a.id_compra " +
                                                                    "and x.id_itemcompra = a.id_itemcompra " +
                                                                    "and x.id_os = " + p.Id_osstr + " " +
                                                                    "and x.id_peca = " + p.Id_pecastr + ")"
                                                    }
                                                }, "a.cd_produto");
                                if (obj != null)
                                    p.Cd_produto = obj.ToString();
                                else if (!string.IsNullOrEmpty(lParam[0].Cd_servicopadrao))
                                    p.Cd_produto = lParam[0].Cd_servicopadrao;
                                else
                                    throw new Exception("Não existe serviço padrão configurado para faturar peça avulsa.");
                            }
                            rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                            {
                                Cd_produto = p.Cd_produto,
                                Quantidade = p.Quantidade,
                                Vl_unitario = p.Vl_unitario,
                                Vl_desconto = p.Vl_desconto,
                                Vl_acrescimo = p.Vl_acrescimo,
                                lPecasOS = new CamadaDados.Servicos.TList_LanServicosPecas() { p }
                            });
                        });
                }
                else
                    throw new Exception("Não existe configuração OS para a empresa " + val.Cd_empresa.Trim());
            }
            if (val.lPecas.Exists(p => p.St_atendimentogarantiabool))
            {
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                        CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(val.Tp_ordemstr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
                if(lParam.Count.Equals(0))
                    throw new Exception("Não existe configuração para o tipo de OS.");
                rPedGarantia = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPedGarantia.CD_Empresa = val.Cd_empresa;
                rPedGarantia.DT_Pedido = DateTime.Now;
                rPedGarantia.CFG_Pedido = lParam[0].Cfg_pedido_garantia;
                rPedGarantia.TP_Movimento = "S"; //Pedido de saida
                rPedGarantia.ST_Pedido = "F"; //Pedido fechado
                rPedGarantia.ST_Registro = "F"; //Pedido fechado
                rPedGarantia.CD_Clifor = val.Cd_clifor;
                rPedGarantia.CD_Endereco = val.Cd_endereco;
                rPedGarantia.Cd_moeda = lParam[0].Cd_moeda;
                rPedGarantia.CD_TRANSPORTADORA = lParam[0].Cd_transportadora;
                rPedGarantia.CD_ENDERECOTRANSP = lParam[0].Cd_enderecoTransp;
                foreach(CamadaDados.Servicos.TRegistro_LanServicosPecas p in val.lPecas.FindAll(v=> v.St_atendimentogarantiabool))
                {
                    CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item reg = new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item();
                    reg.Cd_Empresa = val.Cd_empresa;
                    reg.Cd_local = p.Cd_local;
                    reg.Cd_vendedor = p.Cd_tecnico;
                    reg.Cd_produto = p.Cd_produto;
                    reg.Ds_produto = p.Ds_produto;
                    reg.Cd_unidade_est = p.Cd_unidproduto;
                    reg.Cd_unidade_valor = p.Cd_unidproduto;
                    reg.Quantidade = p.Quantidade;
                    reg.Vl_unitario = p.Vl_unitario;
                    reg.Vl_subtotal = p.Vl_subtotal;
                    reg.Vl_desc = p.Vl_desconto;
                    reg.Vl_acrescimo = p.Vl_acrescimo;
                    reg.Tp_pedOS = "GR";
                    reg.lPecaOS.Add(p);
                    rPedGarantia.Pedido_Itens.Add(reg);
                }
            }
            return rPreVenda;
        }

        public static CamadaDados.Faturamento.PDV.TRegistro_PreVenda ProcessarOSServico(CamadaDados.Servicos.TRegistro_LanServico val)
        {
            CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
            //Buscar config OS
            CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(val.Tp_ordemstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        1,
                                                                        string.Empty,
                                                                        null);
            if (lParam.Count > 0)
            {
                rPreVenda = new CamadaDados.Faturamento.PDV.TRegistro_PreVenda();
                rPreVenda.Cd_empresa = val.Cd_empresa;
                rPreVenda.Cd_clifor = val.Cd_clifor;
                rPreVenda.Nm_clifor = val.Nm_clifor;
                rPreVenda.Cd_endereco = val.Cd_endereco;
                rPreVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rPreVenda.St_registro = "A";
                rPreVenda.Ds_observacao = val.Ds_observacoesgerais;
                val.lServico.ForEach(p =>
                {
                    if (string.IsNullOrEmpty(p.Cd_produto))
                    {
                        object obj = new CamadaDados.Faturamento.CompraAvulsa.TCD_Compra_Itens().BuscarEscalar(
                                        new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fat_compraitens_x_pecaOS x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_compra = a.id_compra " +
                                                                "and x.id_itemcompra = a.id_itemcompra " +
                                                                "and x.id_os = " + p.Id_osstr + " " +
                                                                "and x.id_peca = " + p.Id_pecastr + ")"
                                                }
                                            }, "a.cd_produto");
                        if (obj != null)
                            p.Cd_produto = obj.ToString();
                        else if (!string.IsNullOrEmpty(lParam[0].Cd_servicopadrao))
                            p.Cd_produto = lParam[0].Cd_servicopadrao;
                        else
                            throw new Exception("Não existe serviço padrão configurado para faturar peça avulsa.");
                    }
                    rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                    {
                        Cd_produto = p.Cd_produto,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_desconto = p.Vl_desconto,
                        Vl_acrescimo = p.Vl_acrescimo,
                        lPecasOS = new CamadaDados.Servicos.TList_LanServicosPecas() { p }
                    });
                });
                val.lPecas.ForEach(p =>
                {
                    if (string.IsNullOrEmpty(p.Cd_produto))
                    {
                        object obj = new CamadaDados.Faturamento.CompraAvulsa.TCD_Compra_Itens().BuscarEscalar(
                                        new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fat_compraitens_x_pecaOS x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_compra = a.id_compra " +
                                                                "and x.id_itemcompra = a.id_itemcompra " +
                                                                "and x.id_os = " + p.Id_osstr + " " +
                                                                "and x.id_peca = " + p.Id_pecastr + ")"
                                                }
                                            }, "a.cd_produto");
                        if (obj != null)
                            p.Cd_produto = obj.ToString();
                        else if (!string.IsNullOrEmpty(lParam[0].Cd_servicopadrao))
                            p.Cd_produto = lParam[0].Cd_servicopadrao;
                        else
                            throw new Exception("Não existe serviço padrão configurado para faturar peça avulsa.");
                    }
                    rPreVenda.lItens.Add(new CamadaDados.Faturamento.PDV.TRegistro_ItensPreVenda()
                    {
                        Cd_produto = p.Cd_produto,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_desconto = p.Vl_desconto,
                        Vl_acrescimo = p.Vl_acrescimo,
                        lPecasOS = new CamadaDados.Servicos.TList_LanServicosPecas() { p }
                    });
                });
            }
            else
                throw new Exception("Não existe configuração OS para a empresa " + val.Cd_empresa.Trim());
            return rPreVenda;
        }
    }
}
