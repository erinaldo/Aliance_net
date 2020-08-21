using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Graos;
using CamadaNegocio.Almoxarifado;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Producao.Producao;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFaturamento
    {
        public static TList_RegLanFaturamento Busca(string vCD_Empresa,
                                                    string vNR_NotaFiscal,
                                                    string vNR_Serie,
                                                    string vNR_LanctoFiscal,
                                                    string vDT_Emissao,
                                                    string vDT_SaiEnt,
                                                    decimal vNR_Pedido,
                                                    string vCD_Clifor,
                                                    string vCD_Endereco,
                                                    string vInsc_estadual,
                                                    string vCD_Movimentacao,
                                                    string Cd_cfop,
                                                    string vCd_cmi,
                                                    string vCD_Produto,
                                                    string vTP_Movimento,
                                                    bool vSt_NFE,
                                                    string vChave_Acesso_NFE,
                                                    string vSt_EnviadoNFe,
                                                    string vST_Transmitido_NFE,
                                                    string vST_TransCanc_NFE,
                                                    string vST_Registro,
                                                    string vTp_data,
                                                    string vDt_ini,
                                                    string vDt_fin,
                                                    decimal vVl_ini,
                                                    decimal vVl_fin,
                                                    string vLOGIN,
                                                    string vTp_nota,
                                                    string vTp_serie,
                                                    bool St_ProcessadoReceita,
                                                    string CooVinculado,
                                                    string Vr_origem,
                                                    string Os_Origem,
                                                    short vTop, 
                                                    string vNM_Campo, 
                                                    TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vNR_NotaFiscal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_NotaFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_NotaFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_Serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Serie";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Serie + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNR_LanctoFiscal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if(!string.IsNullOrEmpty(vDT_Emissao.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Emissao).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDT_SaiEnt.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_SaiEnt)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_SaiEnt).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Pedido > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                vLOGIN = (Parametros.pubLogin != null ? Parametros.pubLogin.Trim() : vLOGIN);


                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                      "inner join tb_fat_cfgpedido y " +
                                                      "on x.cfg_pedido = y.cfg_pedido " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and exists(select 1 from tb_div_usuario_x_cfgpedido z " +
                                                      "         where z.cfg_pedido = y.cfg_pedido " +
                                                      "         and((z.login = '" + vLOGIN + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos w " +
                                                      "         where w.logingrp = z.login and w.loginusr = '" + vLOGIN + "')))))";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Endereco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Endereco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Endereco.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vInsc_estadual))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "i.insc_estadual";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vInsc_estadual.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Movimentacao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Movimentacao.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_cfop))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and x.cd_cfop = '" + Cd_cfop.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(vCd_cmi))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_CMI";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_cmi.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 From TB_FAT_NotaFiscal_Item x Where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.NR_LanctoFiscal = a.NR_LanctoFiscal and x.CD_Produto = '" + vCD_Produto.Trim() + "')";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vSt_NFE)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_modelo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'55'";
            }
            if (!string.IsNullOrEmpty(vChave_Acesso_NFE))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Chave_Acesso_NFE";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vChave_Acesso_NFE.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vSt_EnviadoNFe))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_EnviadoNFe, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_EnviadoNFe.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Transmitido_NFE))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_protocolo";
                vBusca[vBusca.Length - 1].vOperador = vST_Transmitido_NFE.Trim().ToUpper().Equals("S") ? "is not" : "is";
                vBusca[vBusca.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vST_TransCanc_NFE))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_transcanc_nfe, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_TransCanc_NFE.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDt_ini.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + 
                    (vTp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_processamento" : "a.dt_saient") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd HH:mm:ss") + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (!string.IsNullOrEmpty(vDt_fin.SoNumero()))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : vTp_data.Trim().ToUpper().Equals("L") ? "a.dt_processamento" : "a.dt_saient") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd HH:mm:ss") + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (vVl_ini > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.vl_totalnota";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (vVl_fin > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.vl_totalnota";
                vBusca[vBusca.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(vTp_nota))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_nota";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vTp_nota.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(vTp_serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "e.tp_serie";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vTp_serie.Trim() + ")";
            }
            if (St_ProcessadoReceita)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and x.status in (100, 110, 205, 233, 234, 301, 302, 303))";
            }
            if (!string.IsNullOrEmpty(CooVinculado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_FAT_ECFVinculadoNF x " +
                                                      "inner join tb_pdv_nfce y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_cupom = y.id_nfce " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and y.nr_nfce = " + CooVinculado + ")";
            }
            if (!string.IsNullOrEmpty(Vr_origem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                      "inner join TB_PDV_Pedido_X_VendaRapida y " +
                                                      "on x.nr_pedido = y.nr_pedido " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_pedidoitem = y.id_pedidoitem " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and y.id_vendarapida = " + Vr_origem + ")";
            }
            if (!string.IsNullOrEmpty(Os_Origem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_OSE_Servico_X_PedidoItem x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.Nr_pedido = a.Nr_pedido " +
                                                      "and x.id_os = " + Os_Origem + ")";
            }

            return new TCD_LanFaturamento(banco).Select(vBusca, vTop, vNM_Campo);
        }

        public static TRegistro_LanFaturamento BuscarNF(string Cd_empresa,
                                                        string Nr_lanctofiscal,
                                                        TObjetoBanco banco)
        {
            TList_RegLanFaturamento lFat =
            new TCD_LanFaturamento(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_lanctofiscal",
                        vOperador = "=",
                        vVL_Busca = Nr_lanctofiscal
                    }
                }, 1, string.Empty);
            if(lFat.Count > 0)
                return lFat[0];
            else return null;
        }

        public static string ProcessarEstoqueNf(TRegistro_LanFaturamento val,
                                                TRegistro_LanFaturamento_Item Item,
                                                TRegistro_CadCFGPedido rCFG_Pedido,
                                                bool ProcessarTaxas,
                                                bool st_exigirconferenciaentrega,
                                                TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TRegistro_LanEstoque reg_estoque = new TRegistro_LanEstoque();
            //Verificar se o item e servico
            if (new TCD_CadProduto(banco).ItemServico(Item.Cd_produto))
                return string.Empty;


            //Verificar se o item e consumo interno
            if (new TCD_CadProduto(banco).ProdutoConsumoInterno(Item.Cd_produto) && rCFG_Pedido.St_integraralmoxbool)
            {
                //Buscar alocacao do item
                TList_EntregaPedido lEntrega =
                    TCN_LanEntregaPedido.Busca(string.Empty,
                                               Item.Nr_pedido.ToString(),
                                               Item.Cd_produto,
                                               Item.Id_pedidoitemstr,
                                               true,
                                               "P",
                                               banco);
                if (lEntrega.Count > 0)
                {
                    retorno +=
                    TCN_Movimentacao.Gravar(
                        new TRegistro_Movimentacao()
                        {
                            Cd_empresa = val.Cd_empresa,
                            LoginAlmoxarife = lEntrega[0].Login,
                            Id_almox = lEntrega[0].Id_almox,
                            Cd_produto = Item.Cd_produto,
                            Dt_movimento = (val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao),
                            Tp_movimento = val.Tp_movimento,
                            Quantidade = Item.Quantidade,
                            Vl_unitario = Item.Vl_unitario + Item.Vl_freteitem - 
                            (Item.St_gerarcreditoCofins ? Item.Vl_cofins : decimal.Zero) -
                            (Item.St_gerarcreditoICMS ? Item.Vl_icms : decimal.Zero) -
                            (Item.St_gerarcreditoIPI ? Item.Vl_ipi : decimal.Zero) -
                            (Item.St_gerarcreditoISS ? Item.Vl_iss : decimal.Zero) -
                            (Item.St_gerarcreditoPIS ? Item.Vl_pis : decimal.Zero),
                            Ds_observacao = !val.Cminf[0].St_devolucaobool ?
                                "MOVIMENTACAO GRAVADA AUTOMATICAMENTE PELA EMISSAO DE NF" :
                                "MOVIMENTACAO GRAVADA AUTOMATICAMENTE PELA DEVOLUÇÃO DE NF",
                            St_registro = "A",
                            rNFItem = new TRegistro_Mov_X_NFItem()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Nr_lanctofiscal = val.Nr_lanctofiscal,
                                Id_nfitem = Item.Id_nfitem
                            }
                        }, banco);
                    return retorno;
                }
                else
                    throw new Exception("Obrigatorio alocar item " + Item.Cd_produto.Trim() + "-" + Item.Ds_produto.Trim() + " ao almoxarifado para gravar NF.");
                                                                              
            }
            //Verificar se o item foi compra para consumo e a empresa nao utiliza almoxarifado
            if (Item.St_usoconsumo)
                return string.Empty;
            bool st_gravar_estoque = false;
            //Regras para gravar estoque
            //Regra 1: Nota Fiscal Normal
            if ((!val.Cminf[0].St_devolucaobool) &&
                (!val.Cminf[0].St_retornobool) &&
                (!val.Cminf[0].St_complementarbool) &&
                (!val.Cminf[0].St_mestrabool) &&
                (!val.Cminf[0].St_simplesremessabool) &&
                (Item.Quantidade > 0))
                st_gravar_estoque = Item.Quantidade > decimal.Zero;
            //Regra 2: Nota Fiscal de Devolucao
            if (val.Cminf[0].St_devolucaobool || val.Cminf[0].St_retornobool)
                if (val.Tp_movimento.Trim().ToUpper().Equals("S"))
                {
                    decimal saldo = decimal.Zero;
                    TCN_LanEstoque.SaldoEstoqueLocal(val.Cd_empresa, Item.Cd_produto, Item.Cd_local, ref saldo, banco);
                    st_gravar_estoque = saldo > decimal.Zero && ((Item.Quantidade > decimal.Zero) || (Item.Vl_subtotal > decimal.Zero));
                }
                else
                    st_gravar_estoque = Item.Quantidade > decimal.Zero;
            //Regra 3: Nota Fiscal de Complemento
            if (val.Cminf[0].St_complementarbool)
                if (val.Tp_movimento.Trim().ToUpper().Equals("E"))
                    st_gravar_estoque = Item.Quantidade > decimal.Zero || Item.Vl_subtotal > decimal.Zero;
                else st_gravar_estoque = Item.Quantidade > decimal.Zero;
            //Regra 4: Nota Fiscal de Remessa
            if (val.Cminf[0].St_simplesremessabool)
                st_gravar_estoque = Item.Quantidade > decimal.Zero;
            //Regra 5: Item possui romaneio de entrega
            decimal qtd_entrega = decimal.Zero;
            object obj_entrega =
            new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio(banco).BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.nr_pedido",
                        vOperador = "=",
                        vVL_Busca = Item.Nr_pedido.ToString()
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_produto",
                        vOperador = "=",
                        vVL_Busca = "'" + Item.Cd_produto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_pedidoitem",
                        vOperador = "=",
                        vVL_Busca = Item.Id_pedidoitemstr
                    }
                }, "a.Quantidade");
            if (obj_entrega != null)
            {
                st_gravar_estoque = Item.Quantidade > decimal.Parse(obj_entrega.ToString());
                qtd_entrega = decimal.Parse(obj_entrega.ToString());
            }

             
            //verifica se tem grade
            TList_PedidoGrade lpedgrad = new TList_PedidoGrade(); 
            lpedgrad = TCN_PedidoGrade.Busca(Item.Nr_pedido.ToString(),string.Empty,string.Empty,string.Empty,Item.Cd_produto,banco);
            lpedgrad.ForEach(p =>
            {
                Item.lGrade.Add(
                    new TRegistro_ValorCaracteristica()
                    {
                        Id_caracteristica = p.id_caracteristica,
                        Id_item = p.id_item,
                        Vl_mov = p.quantidade
                    }); 
            });
            //Gravar estoque
            if (st_gravar_estoque)
            {
                TList_EntregaPedido lEntrega = new TList_EntregaPedido();
                if ((Item.lEntrega == null ? false : Item.lEntrega.Count > 0))
                    lEntrega = Item.lEntrega;
                else
                {
                    if (st_exigirconferenciaentrega && 
                        (!val.Cminf[0].St_devolucaobool) && 
                        (!val.Cminf[0].St_retornobool) && 
                        (!val.Cminf[0].St_complementarbool))
                    {
                        //Buscar lista de entregas com saldo para o item da nf 
                        lEntrega = TCN_LanEntregaPedido.Busca(string.Empty,
                                                              Item.Nr_pedido.ToString(),
                                                              Item.Cd_produto,
                                                              Item.Id_pedidoitemstr,
                                                              true,
                                                              "P",
                                                              banco);
                        if(lEntrega.Count.Equals(0))
                            throw new Exception("Nota fiscal não sera gravada. \r\nConfiguração do pedido exige lançamento de conferência para emissão de nota fiscal normal.");
                    }
                }
                decimal saldo_estoque_item = decimal.Zero;
                if (lEntrega.Count > decimal.Zero)
                {
                    if (new TCD_CadProduto(banco).ProdutoComposto(Item.Cd_produto) && 
                        Item.Quantidade_estoque.Equals(0) && 
                        Item.Quantidade.Equals(0))
                    {
                        //Complementar valor do produto acabado
                        //Lista ficha tecnica e formula
                        //Montar ficha tecnica do produto composto
                        TList_FichaTecItemPed lFichaTec =
                            TCN_FichaTecItemPed.Buscar(Item.Nr_pedido.ToString(),
                                                       Item.Cd_produto,
                                                       Item.Id_pedidoitemstr,
                                                       string.Empty,
                                                       banco);
                        if (lFichaTec.Count > 0)
                        {
                            //Fazer rateio do valor
                            if (lFichaTec.Exists(p => p.Vl_custo.Equals(decimal.Zero)))
                            {
                                throw new Exception("Produto sem custo no estoque para ratear valor do complemento.\r\n" +
                                                    "Produto: " + lFichaTec.Find(p => p.Vl_custo.Equals(decimal.Zero)).Cd_item.Trim() + "-"+
                                                    lFichaTec.Find(p=> p.Vl_custo.Equals(decimal.Zero)).Ds_item.Trim());
                            }
                            decimal vl_totalcusto = lFichaTec.Sum(v => v.Vl_custo);
                            lFichaTec.ForEach(p =>
                            {
                                decimal vl_rateio = Math.Round((Item.Vl_subtotal_estoque > 0 ? Item.Vl_subtotal_estoque : Item.Vl_subtotal) * Math.Round(p.Vl_custo / vl_totalcusto * 100, 2) / 100, 2);
                                //Gravar estoque
                                string retestoque = TCN_LanEstoque.GravarEstoque(new TRegistro_LanEstoque()
                                    {
                                        Cd_empresa = Item.Cd_empresa,
                                        Cd_produto = p.Cd_produto,
                                        Cd_local = Item.Cd_local,
                                        Dt_lancto = (val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao),
                                        Tp_movimento = val.Tp_movimento,
                                        Qtd_entrada = decimal.Zero,
                                        Qtd_saida = decimal.Zero,
                                        Vl_unitario = vl_rateio * p.Quantidade,
                                        Vl_subtotal = vl_rateio * p.Quantidade,
                                        Tp_lancto = "L"
                                    }, banco);
                                if (!string.IsNullOrEmpty(retestoque))
                                {
                                    //Gravar Nota Fiscal Item X Estoque
                                    TCN_Faturamento_Item_X_Estoque.GravarFaturamentoItem_X_Estoque(new TRegistro_Faturamento_Item_X_Estoque()
                                    {
                                        Cd_empresa = Item.Cd_empresa,
                                        Cd_produto = p.Cd_produto,
                                        Id_entrega = null,
                                        Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retestoque, "@@P_ID_LANCTOESTOQUE")),
                                        Id_nfitem = Item.Id_nfitem,
                                        Nr_lanctofiscal = Item.Nr_lanctofiscal
                                    }, banco);
                                }
                            });
                        }
                        else
                            throw new Exception("Não existe formula de" + (val.Tp_movimento.Trim().ToUpper().Equals("E") ? " decomposição " : " composição ") +
                                                    "cadastrada para o produto composto " + Item.Cd_produto.Trim() + "-" + Item.Ds_produto.Trim());
                    }
                    else
                    {
                        saldo_estoque_item = (Item.Quantidade_estoque > 0 ? Item.Quantidade_estoque : Item.Quantidade) - qtd_entrega;
                        int ind = 0;
                        while ((ind < lEntrega.Count) && (saldo_estoque_item > 0))
                        {
                            reg_estoque.Cd_empresa = val.Cd_empresa;
                            reg_estoque.Cd_produto = lEntrega[ind].Cd_produto;
                            reg_estoque.Id_variedade = Item.Id_variedade;
                            reg_estoque.Cd_local = Item.Cd_local;
                            reg_estoque.Dt_lancto = (val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao);
                            reg_estoque.Tp_movimento = val.Tp_movimento;
                            if (val.Tp_movimento.Trim().Equals("E"))
                            {
                                reg_estoque.Qtd_entrada = saldo_estoque_item > lEntrega[ind].Saldo ? lEntrega[ind].Saldo : saldo_estoque_item;
                                reg_estoque.Qtd_saida = 0;
                            }
                            else if (val.Tp_movimento.Trim().Equals("S"))
                            {
                                reg_estoque.Qtd_saida = saldo_estoque_item > lEntrega[ind].Saldo ? lEntrega[ind].Saldo : saldo_estoque_item;
                                reg_estoque.Qtd_entrada = 0;
                            }
                            if (val.Tp_movimento.Trim().Equals("E") && (Item.St_bonificacao || Item.St_remessa || Item.St_retorno))
                            {
                                decimal vl_estoque = 0;
                                TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, Item.Cd_produto, ref vl_estoque, banco);
                                reg_estoque.Vl_subtotal = vl_estoque > decimal.Zero ? Item.Quantidade * vl_estoque : Item.Vl_subtotal;
                                reg_estoque.Vl_unitario = vl_estoque > decimal.Zero ? vl_estoque : Item.Vl_unitario;
                            }
                            else
                            {
                                reg_estoque.Vl_subtotal = Item.Vl_subtotal +
                                                          Item.Vl_freteitem +
                                                          Item.Vl_outrasdesp -
                                                          Item.Vl_desconto +
                                                          Item.Vl_ICMSST +
                                                          Item.Vl_FCPST +
                                                          Item.Vl_ImpCustoEst;
                                if ((Item.Quantidade > 0) && (Item.Vl_subtotal > 0))
                                    reg_estoque.Vl_unitario = Math.Round((Item.Vl_subtotal + 
                                                                          Item.Vl_freteitem + 
                                                                          Item.Vl_outrasdesp -
                                                                          Item.Vl_desconto +
                                                                          Item.Vl_ImpCustoEst) / 
                                                                          Item.Quantidade, 7);
                                else
                                    reg_estoque.Vl_unitario = Item.Vl_subtotal + 
                                                              Item.Vl_freteitem +
                                                              Item.Vl_outrasdesp -
                                                              Item.Vl_desconto +
                                                              Item.Vl_ImpCustoEst;
                            }

                            reg_estoque.Tp_lancto = val.Cminf[0].St_devolucaobool || val.Cminf[0].St_retornobool || val.Cminf[0].St_complementarbool ? "L" : "N"; //VALORES: (I)=INVENTARIO (N)=NORMAL (P)=PROVISAO (M)=MANUAL (L)=COMPLEMENTO/DEVOLUCAO
                            //Gravar Estoque
                            string retestoque = TCN_LanEstoque.GravarEstoque(reg_estoque, banco);
                            Item.rEstoque = reg_estoque;
                            retorno = retorno + "|" + retestoque;
                            if (!string.IsNullOrEmpty(retestoque))
                            {
                                //Gravar Nota Fiscal Item X Estoque
                                TCN_Faturamento_Item_X_Estoque.GravarFaturamentoItem_X_Estoque(new TRegistro_Faturamento_Item_X_Estoque()
                                {
                                    Cd_empresa = Item.Cd_empresa,
                                    Cd_produto = Item.Cd_produto,
                                    Id_entrega = lEntrega[ind].Id_entrega,
                                    Id_lanctoestoque = reg_estoque.Id_lanctoestoque,
                                    Id_nfitem = Item.Id_nfitem,
                                    Nr_lanctofiscal = Item.Nr_lanctofiscal
                                }, banco);
                                //Gravar Pedido Item X Estoque
                                TCN_LanPedidoItem_X_Estoque.GravarPedidoItensXEstoque(new TRegistro_LanPedido_Item_X_Estoque()
                                {
                                    Nr_Pedido = Item.Nr_pedido,
                                    Id_pedidoitem = Item.Id_pedidoitem.Value,
                                    CD_Empresa = val.Cd_empresa,
                                    CD_Produto = Item.Cd_produto,
                                    ID_LanctoEstoque = reg_estoque.Id_lanctoestoque
                                }, banco);
                                //Grade Produto
                                Item.lGrade.ForEach(v => TCN_GradeEstoque.Gravar(
                                    new TRegistro_GradeEstoque
                                    {
                                        Cd_empresa = Item.Cd_empresa,
                                        Cd_produto = Item.Cd_produto,
                                        Id_lanctoestoque = reg_estoque.Id_lanctoestoque,
                                        Id_caracteristica = v.Id_caracteristica,
                                        Id_item = v.Id_item,
                                        quantidade = v.Vl_mov
                                    }, banco));
                            }
                            saldo_estoque_item -= saldo_estoque_item > lEntrega[ind].Saldo ? lEntrega[ind].Saldo : saldo_estoque_item;
                            ind++;
                        }
                    }
                }
                else
                {
                    string id_entrega = string.Empty;
                    //Gravar registro na tabela de entrega
                    if ((!val.Cminf[0].St_complementarbool) && (!val.Cminf[0].St_devolucaobool) && (!val.Cminf[0].St_retornobool))
                        id_entrega = TCN_LanEntregaPedido.Gravar(new TRegistro_EntregaPedido()
                        {
                            Id_entrega = 0,
                            Nr_pedido = Item.Nr_pedido,
                            Cd_produto = Item.Cd_produto,
                            Id_pedidoitem = Item.Id_pedidoitem,
                            Qtd_entregue = (saldo_estoque_item > 0 ? saldo_estoque_item : Item.Quantidade_estoque > 0 ? Item.Quantidade_estoque : Item.Quantidade) - qtd_entrega,
                            Dt_entrega = val.Dt_saient,
                            Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA EMISSAO DA NF: " + val.Nr_notafiscalstr,
                            St_registro = "P"
                        }, banco);

                    if (new TCD_CadProduto(banco).ProdutoComposto(Item.Cd_produto) && 
                        Item.Quantidade.Equals(0) && 
                        Item.Quantidade_estoque.Equals(0))
                    {
                        //Complementar estoque do produto acabado
                        //Buscar ficha tecnica do kit
                        //Montar ficha tecnica do produto composto
                        TList_FichaTecItemPed lFichaTec =
                            TCN_FichaTecItemPed.Buscar(Item.Nr_pedido.ToString(),
                                                       Item.Cd_produto,
                                                       Item.Id_pedidoitemstr,
                                                       string.Empty,
                                                       banco);
                        if (lFichaTec.Count > 0)
                        {
                            //Fazer rateio do valor
                            if (lFichaTec.Exists(p => p.Vl_custo.Equals(decimal.Zero)))
                            {
                                throw new Exception("Produto sem custo no estoque para ratear valor do complemento.\r\n" +
                                                "Produto: " + lFichaTec.Find(p => p.Vl_custo.Equals(decimal.Zero)).Cd_item.Trim() + "-" +
                                                lFichaTec.Find(p => p.Vl_custo.Equals(decimal.Zero)).Ds_item.Trim());
                            }
                            decimal vl_totalcusto = lFichaTec.Sum(v => v.Vl_custo);
                            lFichaTec.ForEach(p =>
                                {
                                    decimal vl_rateio = Math.Round((Item.Vl_subtotal_estoque > 0 ? Item.Vl_subtotal_estoque : Item.Vl_subtotal) * Math.Round(p.Vl_custo / vl_totalcusto * 100, 2) / 100, 2);
                                    //Gravar estoque
                                    string retestoque = TCN_LanEstoque.GravarEstoque(new TRegistro_LanEstoque()
                                    {
                                        Cd_empresa = Item.Cd_empresa,
                                        Cd_produto = p.Cd_produto,
                                        Cd_local = Item.Cd_local,
                                        Dt_lancto = (val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao),
                                        Tp_movimento = val.Tp_movimento,
                                        Qtd_entrada = decimal.Zero,
                                        Qtd_saida = decimal.Zero,
                                        Vl_unitario = vl_rateio * p.Quantidade,
                                        Vl_subtotal = vl_rateio * p.Quantidade,
                                        Tp_lancto = "L"
                                    }, banco);
                                    if (retestoque.Trim().Replace("\r\n", "") != string.Empty)
                                    {
                                        //Gravar Nota Fiscal Item X Estoque
                                        TCN_Faturamento_Item_X_Estoque.GravarFaturamentoItem_X_Estoque(new TRegistro_Faturamento_Item_X_Estoque()
                                        {
                                            Cd_empresa = Item.Cd_empresa,
                                            Cd_produto = p.Cd_produto,
                                            Id_entrega = null,
                                            Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retestoque, "@@P_ID_LANCTOESTOQUE")),
                                            Id_nfitem = Item.Id_nfitem,
                                            Nr_lanctofiscal = Item.Nr_lanctofiscal
                                        }, banco);
                                    }
                                });
                        }
                        else
                            throw new Exception("Não existe formula de" + (val.Tp_movimento.Trim().ToUpper().Equals("E") ? " decomposição " : " composição ") +
                                                "cadastrada para o produto composto " + Item.Cd_produto.Trim() + "-" + Item.Ds_produto.Trim());
                    }
                    else
                    {
                        //Criar registro estoque
                        reg_estoque.Cd_empresa = val.Cd_empresa;
                        reg_estoque.Cd_produto = Item.Cd_produto;
                        reg_estoque.Id_variedade = Item.Id_variedade;
                        reg_estoque.Cd_local = Item.Cd_local;
                        reg_estoque.Dt_lancto = (val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao);
                        reg_estoque.Tp_movimento = val.Tp_movimento;
                        if (val.Tp_movimento.Trim().Equals("E"))
                        {
                            reg_estoque.Qtd_entrada = saldo_estoque_item > 0 ? saldo_estoque_item : Item.Quantidade_estoque > 0 ? Item.Quantidade_estoque : Item.Quantidade;
                            reg_estoque.Qtd_saida = decimal.Zero;
                        }
                        else if (val.Tp_movimento.Trim().Equals("S"))
                        {
                            reg_estoque.Qtd_saida = (saldo_estoque_item > 0 ? saldo_estoque_item : Item.Quantidade_estoque > 0 ? Item.Quantidade_estoque : Item.Quantidade) - qtd_entrega;
                            reg_estoque.Qtd_entrada = decimal.Zero;
                        }
                        //Valor do estoque
                        if (val.Tp_movimento.Trim().ToUpper().Equals("E") && (Item.St_remessa || Item.St_retorno || Item.St_devolucao))
                        {
                            if (Item.St_remessa)//Entrar pelo valor medio do estoque para não influenciar no custo
                            {
                                decimal vl_estoque = decimal.Zero;
                                TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, Item.Cd_produto, ref vl_estoque, banco);
                                reg_estoque.Vl_subtotal = vl_estoque > decimal.Zero ? Item.Quantidade * vl_estoque : Item.Vl_subtotal;
                                reg_estoque.Vl_unitario = vl_estoque > decimal.Zero ? vl_estoque : Item.Vl_unitario;
                            }
                            else
                            {
                                //Se item devolucao/retorno entrar pelo valor do estoque da nf de saida
                                List<decimal> custo = new List<decimal>();
                                Item.lNfcompdev.ForEach(x =>
                                {
                                    try
                                    {
                                        object obj = new TCD_LanEstoque(banco).BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                        new TpBusca
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_FAT_NotaFiscal_Item_X_Estoque x " +
                                                                        "where a.CD_Empresa = x.CD_Empresa " +
                                                                        "and a.CD_Produto = x.CD_Produto " +
                                                                        "and a.Id_LanctoEstoque = x.Id_LanctoEstoque " +
                                                                        "and ISNULL(a.ST_Registro, 'A') <> 'C' " +
                                                                        "and x.CD_Empresa = '" + x.Cd_empresa.Trim() + "' " +
                                                                        "and x.Nr_LanctoFiscal = " + x.Nr_lanctofiscal_origem.ToString() + " " +
                                                                        "and x.ID_NFItem = " + x.Id_nfitem_origem.ToString() + ")"
                                                        }
                                                        }, "isnull(a.Vl_Subtotal, 0) / ISNULL(a.QTD_Saida, 0)");
                                        if (obj != null)
                                            custo.Add(decimal.Parse(obj.ToString()));
                                    }
                                    catch { }
                                });
                                reg_estoque.Vl_unitario = custo.Count > 0 ? custo.Average() : Item.Vl_unitario;
                                reg_estoque.Vl_subtotal = Item.Quantidade * reg_estoque.Vl_unitario;
                            }
                        }
                        else
                        {
                            if (new TCD_CadProduto(banco).ProdutoComposto(Item.Cd_produto))
                            {
                                decimal vl_estoque = decimal.Zero;
                                TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, Item.Cd_produto, ref vl_estoque, banco);
                                reg_estoque.Vl_subtotal = vl_estoque > decimal.Zero ? Item.Quantidade * vl_estoque : Item.Vl_subtotal;
                                reg_estoque.Vl_unitario = vl_estoque > decimal.Zero ? vl_estoque : Item.Vl_unitario;
                            }
                            else
                            {
                                reg_estoque.Vl_subtotal = Item.Vl_subtotal_estoque > 0 ? Item.Vl_subtotal_estoque : Item.Vl_subtotal +
                                                                                                                    Item.Vl_freteitem +
                                                                                                                    Item.Vl_outrasdesp -
                                                                                                                    Item.Vl_desconto +
                                                                                                                    Item.Vl_ImpCustoEst;
                                if ((Item.Vl_subtotal_estoque > 0) && (Item.Quantidade_estoque > 0))
                                    reg_estoque.Vl_unitario = Math.Round(Item.Vl_subtotal_estoque / Item.Quantidade_estoque, 7);
                                else
                                    reg_estoque.Vl_unitario = Item.Quantidade > 0 ?
                                        Math.Round((Item.Vl_subtotal + Item.Vl_freteitem + Item.Vl_outrasdesp - Item.Vl_desconto +
                                        Item.Vl_ImpCustoEst) / Item.Quantidade, 7) :
                                        Item.Vl_subtotal +
                                        Item.Vl_freteitem +
                                        Item.Vl_outrasdesp -
                                        Item.Vl_desconto +
                                        Item.Vl_ImpCustoEst;
                            }
                        }
                        reg_estoque.Tp_lancto = val.Cminf[0].St_devolucaobool || val.Cminf[0].St_retornobool || val.Cminf[0].St_complementarbool ? "L" : "N"; //VALORES: (I)=INVENTARIO (N)=NORMAL (P)=PROVISAO (M)=MANUAL (L)=COMPLEMENTO/DEVOLUCAO
                        //Gravar Estoque
                        string retestoque = TCN_LanEstoque.GravarEstoque(reg_estoque, banco);
                        Item.rEstoque = reg_estoque;
                        retorno = retorno + "|" + retestoque;
                        if (!string.IsNullOrEmpty(retestoque))
                        {
                            decimal? id_ent = null;
                            try
                            {
                                id_ent = decimal.Parse(id_entrega);
                            }
                            catch { }
                            string cd_empTransf = TCN_CadParamGer.BuscaVL_String_Empresa("TRANS_ESTOQUE_EMP", reg_estoque.Cd_empresa);
                            decimal? id_transf = null;
                            //Condição para realizar transferencia de estoque entre empresa dsenvolvido para CHAVES BRASIL.
                            if (!string.IsNullOrEmpty(cd_empTransf) && val.Tp_movimento.Trim().ToUpper().Equals("E"))
                            {
                                //Buscar Cd_local destino 
                                object cd_localDest =
                                    new TCD_CadLocalArm_X_Empresa(banco).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + reg_estoque.Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.cd_local");
                                if (cd_localDest == null ? true : string.IsNullOrEmpty(cd_localDest.ToString()))
                                    throw new Exception("Empresa de destino não possui local de armazenagem para transferência!");
                                string id_transferencia = TCN_TransfLocal.Gravar(
                                        new TRegistro_TransfLocal()
                                        {
                                            Ds_transf = "TRANSFERENCIA GRAVADA PELA AUTOMATICAMNETE PELA ENTRADA DE NF.",
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Cd_produto = reg_estoque.Cd_produto,
                                            Cd_empresaorigem = reg_estoque.Cd_empresa,
                                            Cd_localorigem = reg_estoque.Cd_local,
                                            Cd_empresadestino = cd_empTransf.Trim(),
                                            Cd_localdestino = cd_localDest.ToString(),
                                            Quantidade = reg_estoque.Qtd_entrada
                                        }, banco);
                                try
                                {
                                    id_transf = decimal.Parse(id_transferencia);
                                }
                                catch { }
                            }
                            //Gravar Nota Fiscal Item X Estoque
                            TCN_Faturamento_Item_X_Estoque.GravarFaturamentoItem_X_Estoque(new TRegistro_Faturamento_Item_X_Estoque()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_produto = Item.Cd_produto,
                                Id_entrega = id_ent,
                                Id_lanctoestoque = reg_estoque.Id_lanctoestoque,
                                Id_nfitem = Item.Id_nfitem,
                                Nr_lanctofiscal = val.Nr_lanctofiscal,
                                Id_transf = id_transf
                            }, banco);
                            //Gravar Pedido Item X Estoque
                            TCN_LanPedidoItem_X_Estoque.GravarPedidoItensXEstoque(new TRegistro_LanPedido_Item_X_Estoque()
                            {
                                CD_Empresa = val.Cd_empresa,
                                CD_Produto = Item.Cd_produto,
                                ID_LanctoEstoque = reg_estoque.Id_lanctoestoque,
                                Id_pedidoitem = Item.Id_pedidoitem.Value,
                                Nr_Pedido = Item.Nr_pedido
                            }, banco);
                            //Grade Produto
                            Item.lGrade.ForEach(v => TCN_GradeEstoque.Gravar(
                                new TRegistro_GradeEstoque
                                {
                                    Cd_empresa = Item.Cd_empresa,
                                    Cd_produto = Item.Cd_produto,
                                    Id_lanctoestoque = reg_estoque.Id_lanctoestoque,
                                    Id_caracteristica = v.Id_caracteristica,
                                    Id_item = v.Id_item,
                                    quantidade = v.Vl_mov
                                }, banco));
                        }
                    }
                    //Somente Processa as taxas de deposito quando a nota fiscal gerada nao tem nada
                    //relacionado com romaneios (entrada / saida) 
                    //as taxas geradas nesse caso somente serao referenciadas de lancamentos que nao envolvam 
                    //classificacao de graos
                    if ((ProcessarTaxas) && (rCFG_Pedido.St_depositobool))
                    {
                        //Gravar Movimento Deposito
                        Graos.TCN_MovDeposito.GravarMovDeposito(new CamadaDados.Graos.TRegistro_MovDeposito()
                        {
                            Id_Movto = 0,
                            Nr_Pedido = Item.Nr_pedido,
                            CD_Produto = Item.Cd_produto,
                            CD_Empresa = val.Cd_empresa,
                            Id_LanctoEstoque = reg_estoque.Id_lanctoestoque,
                            Id_pedidoitem = Item.Id_pedidoitem.Value
                        }, banco);
                    }
                }
            }
            return retorno;
        }

        public static void ProcessarProdutoComposto(TRegistro_LanFaturamento val,
                                                    TRegistro_LanFaturamento_Item it,
                                                    TObjetoBanco banco)
        {
            //Produzir kit
            //Registro Apontamento
            TRegistro_ApontamentoProducao rApontamento = new TRegistro_ApontamentoProducao();
            rApontamento.Cd_empresa = val.Cd_empresa;
            rApontamento.Dt_apontamento = val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao;
            rApontamento.Dt_validade = val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient : val.Dt_emissao;
            rApontamento.Qtd_batch = 1;
            //Criar formula
            rApontamento.LFormulaApontamento = new TList_FormulaApontamento()
                                                {
                                                    TCN_FormulaApontamento.CriarFormulaApontamento(val.Cd_empresa,
                                                                                                   it.Nr_pedido.ToString(),
                                                                                                   it.Cd_produto,
                                                                                                   it.Cd_unidade,
                                                                                                   it.Cd_unidEst,
                                                                                                   it.Cd_local,
                                                                                                   it.Id_pedidoitemstr,
                                                                                                   it.Quantidade_estoque > 0 ? it.Quantidade_estoque : it.Quantidade,
                                                                                                   banco)
                                                };
            if (rApontamento.LFormulaApontamento[0].LFichaTec_MPrima.Count.Equals(0))
                throw new Exception("Produto composto(" + it.Cd_produto.Trim() + "-" + it.Ds_produto.Trim() + ")não possui ficha tecnica para gerar estoque.");
            //Calcular custo MPD
            if (val.Tp_movimento.Trim().ToUpper().Equals("S"))
                TCN_ApontamentoProducao.CalcularCustoMPD(rApontamento, banco);
            else
            {
                if(val.Cminf[0].St_devolucaobool)
                {
                    if(it.lNfcompdev.Count > 0)
                    {
                        rApontamento.LFormulaApontamento[0].LFichaTec_MPrima.ForEach(p =>
                        {
                            //Buscar Id do apontamento
                            object obj = new TCD_LanFaturamento_Item(banco).BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + it.lNfcompdev[0].Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                    vOperador = "=",
                                                    vVL_Busca = it.lNfcompdev[0].Nr_lanctofiscal_origem.ToString()
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_nfitem",
                                                    vOperador = "=",
                                                    vVL_Busca = it.lNfcompdev[0].Id_nfitem_origem.ToString()
                                                }
                                            }, "a.id_apontamento");
                            if (obj != null)
                            {
                                //Buscar valor de saida do item 
                                obj = new TCD_LanEstoque(banco).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_prd_apontamento_x_estoque x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.cd_produto = a.cd_produto " +
                                                            "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                            "and x.id_apontamento = " + obj.ToString() + ")"
                                            }
                                        }, "a.vl_subtotal / a.qtd_saida");
                                p.Vl_unitario = obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
                            }
                        });
                    }
                }
                else
                    rApontamento.LFormulaApontamento[0].LFichaTec_MPrima.ForEach(p => p.Vl_unitario = Math.Round(decimal.Divide(it.Vl_subtotal, rApontamento.LFormulaApontamento[0].LFichaTec_MPrima.Count), 5, MidpointRounding.AwayFromZero));
            }
            //Calcular custo fixo
            TCN_ApontamentoProducao.CalcularCustoFixo(rApontamento, banco);
            //Remover todos os custo criados automaticamente
            if (rApontamento.LFormulaApontamento.Count > 0)
                rApontamento.LFormulaApontamento[0].LCustoFixo.RemoveAll(p => p.Id_custo == null);
            rApontamento.LFormulaApontamento[0].St_decomposicao = val.Tp_movimento.Trim().ToUpper().Equals("E");
            //Gravar apontamento producao
            it.Id_apontamento = Convert.ToDecimal(TCN_ApontamentoProducao.Gravar(rApontamento, 
                                                                                 banco));
        }
                
        public static string GravarFaturamento(TList_RegLanFaturamento val, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            if (val.Count > 0)
            {
                for (int i = 0; i < val.Count; i++)
                    retorno += "|" + GravarFaturamento(val[i], null, banco);
                return retorno;
            }
            else
                return string.Empty;
        }

        public static string GravarFaturamento(TRegistro_LanFaturamento val,    
                                               ThreadEspera tEspera,                               
                                               TObjetoBanco banco)
        {
            return GravarFaturamento(val, true, tEspera, banco);
        }

        public static string GravarFaturamento(TRegistro_LanFaturamento val,
                                               bool ProcessarTaxas,
                                               ThreadEspera tEspera,
                                               TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    if(tEspera != null)
                        tEspera.Msg("Criando a conexão com o banco de dados...");
                    pode_liberar = qtb_faturamento.CriarBanco_Dados(true);
                }
                else
                    qtb_faturamento.Banco_Dados = banco;
                //Inicio do processo de Gravação da nota fiscal
                //Gravar numero da nota fiscal na tabela TB_FAT_SequenciaNF
                TList_CadSerieNF lSerie = TCN_CadSerieNF.Busca(val.Nr_serie,
                                                               val.Cd_modelo,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               qtb_faturamento.Banco_Dados);
                if (lSerie.Count < 1)
                    throw new Exception("Serie Nº " + val.Nr_serie.Trim() + " não existe no sistema.\r\n" +
                                        "Verifique o cadastro de serie.");
                if (string.IsNullOrEmpty(val.Cd_modelo))
                    if (!string.IsNullOrEmpty(lSerie[0].CD_Modelo))
                        val.Cd_modelo = lSerie[0].CD_Modelo;
                    else
                        throw new Exception("Erro: Não é permitido gravar nota fiscal sem Modelo Fiscal.");
                if (val.Cd_modelo.Trim().Equals("55") &&
                    val.Tp_nota.Trim().ToUpper().Equals("T") &&
                    !lSerie[0].Tp_serie.Trim().ToUpper().Equals("S") &&
                    string.IsNullOrEmpty(val.Chave_acesso_nfe))
                    throw new Exception("Erro: Não é permitido gravar nota fiscal TERCEIRO sem informar CHAVE ACESSO.");
                if (val.Dt_emissao == null)
                    throw new Exception("Erro: Data de Emissão é obrigatória !");
                if (val.Dt_saient == null)
                    throw new Exception("Erro: Data de Saida/Entrada é obrigatória !");
                DateTime dt_servidor = CamadaDados.UtilData.Data_Servidor();
                if (val.Dt_emissao.Value.Date > val.Dt_saient)
                    throw new Exception("Erro: Data de Emissão não pode ser maior que data de Saida/Entrada !");
                if (dt_servidor < val.Dt_saient && val.Tp_movimento.ToUpper().Equals("E"))
                    throw new Exception("Erro: Data de Entrada não pode ser maior que a data atual !");
                //Obs Fiscal
                if (val.ItensNota.Exists(x=> x.Vl_difal > decimal.Zero))
                    val.Obsfiscal += (string.IsNullOrEmpty(val.Obsfiscal) ? string.Empty : "\r\n") + "Valor DIFAL: " + val.ItensNota.Sum(x => x.Vl_difal).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                if (val.ItensNota.Exists(x=> x.Vl_FCP > decimal.Zero))
                    val.Obsfiscal += (string.IsNullOrEmpty(val.Obsfiscal) ? string.Empty : "\r\n") + "Valor FCP: " + val.ItensNota.Sum(x => x.Vl_FCP).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                if(val.ItensNota.Exists(x=> x.Vl_FCPST > decimal.Zero))
                    val.Obsfiscal += (string.IsNullOrEmpty(val.Obsfiscal) ? string.Empty : "\r\n") + "Valor FCP ST: " + val.ItensNota.Sum(x => x.Vl_FCPST).ToString("N2", new System.Globalization.CultureInfo("en-US", true));
                if (val.Cd_clifor == null)
                    throw new Exception("Erro: Cliente / Fornecedor é obrigatório !");
                //Verificar se a serie gera Sintegra
                if (lSerie[0].St_gerasintegrabool &&
                    new TCD_CadEndereco(qtb_faturamento.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_endereco",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_endereco.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_cidade",
                            vOperador = "=",
                            vVL_Busca = "'9999999'"//Venda Exterior
                        }
                    }, "1") == null)
                {
                    //Buscar registro clifor
                    TRegistro_CadClifor rClifor = TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, qtb_faturamento.Banco_Dados);
                    
                    if (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        CNPJ_Valido.nr_CNPJ = rClifor.Nr_cgc;
                        if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                            throw new Exception("Não é permitido emitir NF-e para Cliente/Fornecedor(" + rClifor.Cd_clifor.Trim() + "-" + rClifor.Nm_clifor.Trim() + ")com CNPJ invalido.");
                    }
                    else if (rClifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        CPF_Valido.nr_CPF = rClifor.Nr_cpf;
                        if (string.IsNullOrEmpty(CPF_Valido.nr_CPF))
                            throw new Exception("Não é permitido emitir NF-e para Cliente/Fornecedor(" + rClifor.Cd_clifor.Trim() + "-" + rClifor.Nm_clifor.Trim() + ")com CPF invalido.");
                    }
                }
                if((!lSerie[0].ST_SequenciaAutoBool) || val.Tp_nota.Trim().ToUpper().Equals("T"))
                    if (!val.Nr_notafiscal.HasValue)
                        throw new Exception("Erro: Obrigatório informar numero da nota fiscal.");
                    else
                    {
                        //Verificar se o numero da nota ja nao existe no sistema
                        TRegistro_LanFaturamento rFatexiste = existeNumeroNota(val.Nr_notafiscalstr,
                                                                               val.Nr_serie,
                                                                               val.Cd_empresa,
                                                                               val.Cd_clifor,
                                                                               val.Insc_estadualclifor,
                                                                               val.Tp_nota,
                                                                               qtb_faturamento.Banco_Dados);
                        if (rFatexiste != null)
                            if (rFatexiste.St_registro.Trim().ToUpper().Equals("C"))
                            {
                                if (!ExcluirNotaFiscal(rFatexiste, qtb_faturamento.Banco_Dados))
                                    throw new Exception("Nota fiscal Nº " + val.Nr_notafiscalstr + " ja existe no sistema com status <CANCELADA>.\r\n" +
                                                        "Sistema não conseguiu excluir a nota cancelada.");
                            }
                            else
                                throw new Exception("Nota fiscal Nº " + val.Nr_notafiscalstr + " ja existe no sistema com status <PROCESSADA>.");
                    }

                //Buscar Configuracao do PEDIDO
                TRegistro_CadCFGPedido rCFG_Pedido =
                    new TCD_CadCFGPedido(qtb_faturamento.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + val.Nr_pedidostring + ")"
                        }
                    }, 1, string.Empty)[0];
                
                if (val.ItensNota.Count.Equals(0))
                    throw new Exception("ERRO: Não é permitido gravar nota fiscal sem itens!");
                if(tEspera != null)
                    tEspera.Msg("Gravando objeto nota fiscal...");
                //Verificar se NF propria/NFe e tem imposto aproximado
                if (val.Tp_nota.Trim().ToUpper().Equals("P") &&
                    val.Cd_modelo.Trim().Equals("55") &&
                    (val.ItensNota.Sum(p => p.Vl_imposto_Aprox) > decimal.Zero))
                    val.Dadosadicionais += " Valor aproximado de tributos federais, estaduais e municipais: R$" + 
                        val.ItensNota.Sum(p => p.Vl_imposto_Aprox).ToString("N2", new System.Globalization.CultureInfo("en-US")) +
                        "(" + val.ItensNota.Average(p => p.Pc_imposto_Aprox).ToString("N2", new System.Globalization.CultureInfo("en-US")) + "%)  Conforme Lei nº 12.741/2012 (Fonte: IBPT)";

                //Gravar Nota Fiscal                
                retorno = qtb_faturamento.GravaNotaFiscal(val);
                //Valor campo NR_NotaFiscal
                val.Nr_notafiscalstr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_NOTAFISCAL");
                //Valor campo NR_LanctoFiscal
                val.Nr_lanctofiscalstr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTOFISCAL");
                //Se o numero da nota for automatico

                if (!string.IsNullOrEmpty(val.rDuplicata.Cd_clifor))
                {
                    val.rDuplicata.Nr_lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTOFISCAL"));
                    TCN_LanDuplicata.GravarDuplicata(val.rDuplicata, false, qtb_faturamento.Banco_Dados);
                }

               // val.nr_lanctostr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_NR_LANCTO");


                //Gerar numero da nota
                if (lSerie[0].ST_SequenciaAutoBool && val.Tp_nota.Trim().ToUpper().Equals("P"))
                {
                    if (tEspera != null)
                        tEspera.Msg("Gravando numero da nota fiscal...");
                    qtb_faturamento.incSeqNotaFiscal(val);
                }
                //Verificar se NF de Remessa Transporte
                if (val.rNFVendaRT != null)
                {
                    System.Collections.Hashtable param = new System.Collections.Hashtable();
                    param.Add("@P_CD_EMPRESA", val.rNFVendaRT.Cd_empresa);
                    param.Add("@P_NR_LANCTOFISCAL", val.rNFVendaRT.Nr_lanctofiscal);
                    param.Add("@P_NR_LANCTOFISCALRT", val.Nr_lanctofiscal);
                    qtb_faturamento.executarSql("update tb_fat_notafiscal set nr_lanctofiscalRT = @P_NR_LANCTOFISCALRT " +
                                                "where cd_empresa = @P_CD_EMPRESA and nr_lanctofiscal = @P_NR_LANCTOFISCAL", param);
                }
                //Verificar se NFSe e PROPRIA
                if (val.Tp_nota.Trim().ToUpper().Equals("P") &&
                    lSerie[0].CD_Modelo.Trim().Equals("55") &&
                    lSerie[0].Tp_serie.Trim().ToUpper().Equals("S"))
                {
                    //Gerar Lote RPS
                    if (tEspera != null)
                        tEspera.Msg("Gravando numero RPS...");
                    qtb_faturamento.IncSeqRPS(val);
                }
                //Gravar Cupom Fiscal Vinculado
                val.lCupom.ForEach(p => TCN_ECFVinculadoNF.Gravar(new TRegistro_ECFVinculadoNF()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctofiscal = val.Nr_lanctofiscal,
                        Id_cupom = p.Id_nfce
                    }, qtb_faturamento.Banco_Dados));
                if (val.Cminf.Count < 1)
                {
                    //Buscar configuracao cmi
                    TRegistro_CadCMI rCmi = TCN_CadCMI.Busca(val.Cd_cmi.Value.ToString(),
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
                                                            qtb_faturamento.Banco_Dados)[0];
                    val.Cminf.Add(new TRegistro_LanFaturamento_CMI()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctofiscal = val.Nr_lanctofiscal.Value,
                        St_mestra = rCmi.St_mestra,
                        St_devolucao = rCmi.St_devolucao,
                        St_complementar = rCmi.St_complementar,
                        St_geraestoque = rCmi.St_geraestoque,
                        St_simplesremessa = rCmi.St_simplesremessa,
                        St_compdevimposto = rCmi.St_compdevimposto,
                        St_retorno = rCmi.St_retorno
                    });
                }
                else
                {
                    //Buscar configuracao cmi
                    TRegistro_CadCMI rCmi = TCN_CadCMI.Busca(val.Cd_cmi.Value.ToString(),
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
                                                            qtb_faturamento.Banco_Dados)[0];
                    val.Cminf[0].Cd_empresa = val.Cd_empresa;
                    val.Cminf[0].Nr_lanctofiscal = val.Nr_lanctofiscal.Value;
                    val.Cminf[0].St_mestra = rCmi.St_mestra;
                    val.Cminf[0].St_devolucao = rCmi.St_devolucao;
                    val.Cminf[0].St_complementar = rCmi.St_complementar;
                    val.Cminf[0].St_geraestoque = rCmi.St_geraestoque;
                    val.Cminf[0].St_simplesremessa = rCmi.St_simplesremessa;
                    val.Cminf[0].St_compdevimposto = rCmi.St_compdevimposto;
                    val.Cminf[0].St_retorno = rCmi.St_retorno;
                }
                if(tEspera != null)
                    tEspera.Msg("Gravando CMI da Nota Fiscal...");
                //Gravar Configuracao do CMI da Nota Fiscal
                TCN_LanFaturamento_CMI.Gravar(val.Cminf[0], qtb_faturamento.Banco_Dados);
                //Devolver Financeiro
                if (val.Cminf[0].St_devolucaobool && val.lParcDev.Count > 0)
                {
                    if (val.Vl_totalnota > decimal.Zero)
                    {
                        //Buscar Config Adto
                        TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             1,
                                                                             string.Empty,
                                                                             qtb_faturamento.Banco_Dados);
                        if (lCfgAdto.Count.Equals(0))
                            throw new Exception("Não existe configuração adiantamento para gerar credito.");
                        //Gerar Credito do valor devolvido
                        CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                        rAdto.Cd_clifor = val.Cd_clifor;
                        rAdto.Cd_empresa = val.Cd_empresa;
                        rAdto.CD_Endereco = val.Cd_endereco;
                        rAdto.Ds_adto = val.Tp_movimento.ToUpper().Equals("S") ? "CREDITO CONCEBIDO DEVOLUÇÃO NF" : "CREDITO RECEBIDO DEVOLUÇÃO NF";
                        rAdto.Tp_movimento = val.Tp_movimento.ToUpper().Equals("S") ? "C" : "R";
                        rAdto.Dt_lancto = val.Dt_emissao;
                        rAdto.Vl_adto = val.Vl_totalnota;
                        rAdto.ST_ADTO = "A";
                        rAdto.TP_Lancto = "F";//Financeiro
                        Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, qtb_faturamento.Banco_Dados);
                        //Quitar adiantamento
                        rAdto.List_Caixa.Add(new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = lCfgAdto[0].Cd_contagerDEV_CV,
                            Cd_Empresa = val.Cd_empresa,
                            Cd_Historico = val.Tp_movimento.ToUpper().Equals("S") ? lCfgAdto[0].Cd_historico_ADTO_C : lCfgAdto[0].Cd_historico_ADTO_R,
                            Cd_LanctoCaixa = decimal.Zero,
                            ComplHistorico = (val.Tp_movimento.ToUpper().Equals("S") ? "CREDITO CONCEBIDO DEVOLUÇÃO FINANCEIRO NFº " : "CREDITO RECEBIDO DEVOLUÇÃO FINANCEIRO NFº ") + val.Nr_notafiscal,
                            Dt_lancto = val.Dt_emissao,
                            Login = Parametros.pubLogin,
                            Nr_Docto = "DEVFINNF",
                            St_Estorno = "N",
                            St_Titulo = "N",
                            Vl_PAGAR = val.Tp_movimento.ToUpper().Equals("S") ? rAdto.Vl_adto : decimal.Zero,
                            Vl_RECEBER = val.Tp_movimento.ToUpper().Equals("S") ? decimal.Zero : rAdto.Vl_adto,
                            NM_Clifor = val.Nm_clifor
                        });
                        Financeiro.Adiantamento.TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_faturamento.Banco_Dados);
                        //Atualizar Adto Quitado
                        rAdto = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento(qtb_faturamento.Banco_Dados)
                            .Select(new TpBusca[]
                            {
                                new TpBusca{vNM_Campo = "a.id_adto", vOperador = "=", vVL_Busca = rAdto.Id_adto.ToString() }
                            }, 1, string.Empty)[0];
                        //Liquidar duplicatas em aberto com credito gerado
                        decimal tot_devolver = val.Vl_totalnota;
                        foreach (TRegistro_LanParcela rParc in val.lParcDev.FindAll(x => x.cVl_atual > decimal.Zero))
                        {
                            if (tot_devolver > decimal.Zero)
                            {
                                //Criar objeto liquidacao
                                TRegistro_LanLiquidacao regLiquidacao = new TRegistro_LanLiquidacao();
                                regLiquidacao.Cd_empresa = rParc.Cd_empresa;
                                regLiquidacao.Cd_clifor = rParc.Cd_clifor;
                                regLiquidacao.Nr_lancto = rParc.Nr_lancto;
                                regLiquidacao.Nr_docto = rParc.Nr_docto;
                                regLiquidacao.Dt_Liquidacao = val.Dt_emissao;
                                regLiquidacao.Cd_contager = lCfgAdto[0].Cd_contagerDEV_CV;
                                object obj = new TCD_CadConfigAdto(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                                new TpBusca[]
                                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                                }, rParc.Tp_mov.Trim().ToUpper().Equals("P") ? "a.cd_historico_devadto_C" : "a.cd_historico_devadto_R");
                                if (obj == null)
                                    throw new Exception("Não existe historico de devolução configurado.");
                                else regLiquidacao.Cd_historico = obj.ToString();
                                regLiquidacao.ComplHistorico = rParc.complHistorico;
                                regLiquidacao.Tp_mov = rParc.Tp_mov;
                                regLiquidacao.Cd_portador = lCfgAdto[0].CD_Portador;
                                regLiquidacao.cVl_Atual = rParc.cVl_atual < tot_devolver ? rParc.cVl_atual : tot_devolver;
                                regLiquidacao.cVl_descontoconcedido = decimal.Zero;
                                regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                                regLiquidacao.cVl_juroliquidar = decimal.Zero;
                                regLiquidacao.cVl_JuroTotal = decimal.Zero;
                                regLiquidacao.cVl_Liquidado = decimal.Zero;
                                regLiquidacao.cVl_Nominal = rParc.cVl_atual < tot_devolver ? rParc.cVl_atual : tot_devolver;
                                regLiquidacao.Cvl_aliquidar_padrao = rParc.cVl_atual < tot_devolver ? rParc.cVl_atual : tot_devolver;
                                regLiquidacao.cVl_adiantamento = rParc.cVl_atual < tot_devolver ? rParc.cVl_atual : tot_devolver;
                                regLiquidacao.lCred = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> { rAdto };
                                //Gravar liquidacao do adiantamento
                                TCN_LanLiquidacao.GravarLiquidacao(new List<TRegistro_LanParcela> { rParc },
                                                                   regLiquidacao,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   qtb_faturamento.Banco_Dados);
                                tot_devolver -= tot_devolver < rParc.cVl_atual ? tot_devolver : rParc.cVl_atual;
                            }
                            else break;
                        }
                        //Lancamento Caixa Devolução
                        string ret = Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                        new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                        {
                                            Cd_ContaGer = lCfgAdto[0].Cd_contagerDEV_CV,
                                            Cd_Empresa = val.Cd_empresa,
                                            Cd_Historico = val.Tp_movimento.Trim().ToUpper().Equals("S") ? lCfgAdto[0].Cd_historicoDEV_Compra : lCfgAdto[0].Cd_historicoDEV_Venda,
                                            Cd_LanctoCaixa = decimal.Zero,
                                            ComplHistorico = "ESTORNO DEVOLUÇÃO FINANCEIRO",
                                            Dt_lancto = val.Dt_emissao,
                                            Login = Parametros.pubLogin,
                                            Nr_Docto = "DEVFINNF",
                                            St_Estorno = "N",
                                            St_Titulo = "N",
                                            Vl_PAGAR = val.Tp_movimento.Trim().ToUpper().Equals("S") ? decimal.Zero : rAdto.Vl_adto,
                                            Vl_RECEBER = val.Tp_movimento.Trim().ToUpper().Equals("S") ? rAdto.Vl_adto : decimal.Zero,
                                            NM_Clifor = val.Nm_clifor
                                        }, qtb_faturamento.Banco_Dados);
                        //Gravar registro Devolução
                        TCN_DevolucaoFIN.Gravar(
                            new TRegistro_DevolucaoFIN()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Nr_lanctofiscal = val.Nr_lanctofiscal,
                                Id_adto = rAdto.Id_adto,
                                Cd_contager = lCfgAdto[0].Cd_contagerDEV_CV,
                                Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA"),
                                Vl_devolvido = rAdto.Vl_adto
                            }, qtb_faturamento.Banco_Dados);
                    }
                }     
                //Verificar se a movimentacao gera sped pis/cofins
                bool st_movgerasped = new TCD_CadMovimentacao(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_movimentacao",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Cd_movimentacaostring.Trim() + "'"
                                            }
                                        }, "isnull(a.st_gerarspedpiscofins, 'N')").ToString().Trim().ToUpper().Equals("S");
                //Verificar se a empresa gera sped pis/cofins
                bool st_empgerasped = new CamadaDados.Diversos.TCD_CadEmpresa(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.tp_atividadespedpiscofins",
                                                vOperador = "is",
                                                vVL_Busca = "not null"
                                            }
                                        }, "1") != null;
                //Gravar Itens da Nota Fiscal
                val.ItensNota.ForEach(it =>
                {
                    it.St_devolucao = val.Cminf[0].St_devolucaobool;
                    it.St_retorno = val.Cminf[0].St_retornobool;
                    //Verificar se e NFe Propria ou 
                    if (val.Tp_nota.Trim().ToUpper().Equals("P") && val.Cd_modelo.Trim().Equals("55"))
                    {
                        if (lSerie[0].ST_GeraSintegra.Trim().ToUpper().Equals("S"))
                            if ((!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)) &&
                                (string.IsNullOrWhiteSpace(it.Cd_ST_ICMS)))
                                throw new Exception("Erro: Não é permitido gravar Nota Fiscal com Serie configurada para gerar SINTEGRA,\r\n" +
                                                    "sem gerar imposto ICMS para todos os itens que não sejam SERVIÇO.");
                        //Verificar se existe PIS
                        if (string.IsNullOrWhiteSpace(it.Cd_ST_PIS) &&
                            (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)))
                            throw new Exception("Erro: Falta configuração fiscal do imposto PIS para emitir NFE.\r\n" +
                                                "Imposto: PIS\r\n" +
                                                "Cond. Fiscal Clifor: " + val.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + it.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "Cd. Movimentação: " + val.Cd_movimentacaostring.Trim() + "\r\n" +
                                                "TP. Pessoa: " + val.Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                "TP. Movimento: " + val.Tp_movimento.Trim().ToUpper() + "\r\n" +
                                                "Cd. Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.");
                        //Verificar se existe COFINS
                        if (string.IsNullOrWhiteSpace(it.Cd_ST_COFINS) &&
                            (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)))
                            throw new Exception("Erro: Falta configuração fiscal do imposto COFINS para emitir NFE.\r\n" +
                                                "Imposto: COFINS\r\n" +
                                                "Cond. Fiscal Clifor: " + val.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + it.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "Cd. Movimentação: " + val.Cd_movimentacaostring.Trim() + "\r\n" +
                                                "TP. Pessoa: " + val.Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                "TP. Movimento: " + val.Tp_movimento.Trim().ToUpper() + "\r\n" +
                                                "Cd. Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.");

                        //Verificar se existe ISSQN
                        if (it.Vl_iss.Equals(decimal.Zero) && 
                            it.Vl_issretido.Equals(decimal.Zero) && 
                            (val.Nr_serie.Trim().Equals("F")) &&
                            (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)))
                            throw new Exception("Erro: Falta configuração fiscal do imposto ISSQN para gravar NF Serviço.\r\n" +
                                                "Imposto: ISSQN\r\n" +
                                                "Cond. Fiscal Clifor: " + val.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + it.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "Cd. Movimentação: " + val.Cd_movimentacaostring.Trim() + "\r\n" +
                                                "Municicio serviço: " + val.Ds_municipioexecservico.Trim() + "\r\n" +
                                                "TP. Pessoa: " + val.Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                "TP. Movimento: " + val.Tp_movimento.Trim().ToUpper() + "\r\n" +
                                                "Cd. Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.");
                    }
                    else if (val.Tp_nota.Trim().ToUpper().Equals("T") && st_empgerasped && st_movgerasped)
                    {
                        //Verificar se existe PIS
                        if (string.IsNullOrWhiteSpace(it.Cd_ST_PIS) &&
                            (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)))
                            throw new Exception("Erro: Falta configuração fiscal do imposto PIS para gravar NF Entrada.\r\n" +
                                                "Imposto: PIS\r\n" +
                                                "Cond. Fiscal Clifor: " + val.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + it.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "Cd. Movimentação: " + val.Cd_movimentacaostring.Trim() + "\r\n" +
                                                "TP. Pessoa: " + val.Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                "TP. Movimento: " + val.Tp_movimento.Trim().ToUpper() + "\r\n" +
                                                "Cd. Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.");
                        //Verificar se existe COFINS
                        if (string.IsNullOrWhiteSpace(it.Cd_ST_COFINS) &&
                            (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(it.Cd_produto)))
                            throw new Exception("Erro: Falta configuração fiscal do imposto COFINS para gravar NF Entrada.\r\n" +
                                                "Imposto: COFINS\r\n" +
                                                "Cond. Fiscal Clifor: " + val.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + it.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "Cd. Movimentação: " + val.Cd_movimentacaostring.Trim() + "\r\n" +
                                                "TP. Pessoa: " + val.Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                                "TP. Movimento: " + val.Tp_movimento.Trim().ToUpper() + "\r\n" +
                                                "Cd. Empresa: " + val.Cd_empresa.Trim() + "\r\n" +
                                                "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                                "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.");

                    }
                    if (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoComposto(it.Cd_produto))
                    {
                        //Se o item da NF nao for Kit
                        decimal saldoQuantidade = 0;
                        decimal saldoValor = 0;
                        if (val.Cminf[0].St_devolucaobool || val.Cminf[0].St_retornobool)
                        {
                            //Validar saldo devolucao
                            string tp_mod = string.Empty;
                            if (val.Tp_movimento.Trim().Equals("E"))
                                tp_mod = "de entrada";
                            else if (val.Tp_movimento.Trim().Equals("S"))
                                tp_mod = "de saida";
                            TCN_LanPedido_Item.BuscaSaldoDevolucao(it.Nr_pedido.ToString(), it.Cd_produto, it.Id_pedidoitemstr, string.Empty, ref saldoQuantidade, ref saldoValor, 1, "", qtb_faturamento.Banco_Dados);
                            if ((it.Quantidade > 0) && (it.Vl_subtotal > 0))
                            {
                                if ((it.Quantidade > saldoQuantidade) && (it.Vl_subtotal > saldoValor))
                                    throw new Exception("Saldo de notas fiscais " + tp_mod + " insuficiente para emitir nota fiscal de devolução.\r\n" +
                                                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                                                        "Produto: " + it.Cd_produto + "\r\n" +
                                                        "Saldo Notas " + tp_mod + " (Qtd): " + saldoQuantidade.ToString("##0.00") + "\r\n" +
                                                        "Saldo Notas " + tp_mod + " (Vlr): " + saldoValor.ToString("##0.00") + "\r\n" +
                                                        "Qtd Item: " + it.Quantidade.ToString("##0.00") + "\r\n" +
                                                        "Vlr Item: " + it.Vl_subtotal.ToString("##0.00"));
                            }
                            else if (it.Quantidade > 0)
                            {
                                if (it.Quantidade > saldoQuantidade)
                                    throw new Exception("Saldo de notas fiscais " + tp_mod + " insuficiente para emitir nota fiscal de devolução.\r\n" +
                                                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                                                        "Produto: " + it.Cd_produto + "\r\n" +
                                                        "Saldo Notas " + tp_mod + " (Qtd): " + saldoQuantidade.ToString("##0.00") + "\r\n" +
                                                        "Qtd Item: " + it.Quantidade.ToString("##0.00"));
                            }
                            else if (it.Vl_subtotal > 0)
                                if (it.Vl_subtotal > saldoValor)
                                    throw new Exception("Saldo de notas fiscais " + tp_mod + " insuficiente para emitir nota fiscal de devolução.\r\n" +
                                                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                                                        "Produto: " + it.Cd_produto + "\r\n" +
                                                        "Saldo Notas " + tp_mod + " (Vlr): " + saldoValor.ToString("##0.00") + "\r\n" +
                                                        "Vlr Item: " + it.Vl_subtotal.ToString("##0.00"));
                        }
                        else if (val.Cminf[0].St_mestrabool)
                        {
                            //Verificar se o pedido confere saldo
                            if (val.St_confere_saldo && val.Cminf[0].St_geraestoquebool)
                            {
                                //Validar saldo mestra
                                TCN_LanPedido_Item.BuscaSaldoMestra(it.Nr_pedido.ToString(), it.Cd_produto, string.Empty, ref saldoQuantidade, ref saldoValor, 1, "", qtb_faturamento.Banco_Dados);
                                if ((it.Quantidade > saldoQuantidade) && (it.Vl_subtotal > saldoValor))
                                    throw new Exception("Saldo do pedido insuficiente para emitir nota mestra.\r\n" +
                                                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                                                        "Produto: " + it.Cd_produto + "\r\n" +
                                                        "Saldo Pedido (Qtd): " + saldoQuantidade.ToString("##0.00") + "\r\n" +
                                                        "Saldo Pedido (Vlr): " + saldoValor.ToString("##0.00") + "\r\n" +
                                                        "Qtd Item: " + it.Quantidade.ToString("##0.00") + "\r\n" +
                                                        "Vlr Item: " + it.Vl_subtotal.ToString("##0.00"));
                            }
                        }
                        else if (val.Cminf[0].St_simplesremessabool)
                        {
                            //Metodo estava tratando somente uma NF Mestra por remessa, comentado devido ao posto utilizar mais de uma mestra para mesma remessa
                            //Validar saldo simples remessa
                            //TCN_LanPedido_Item.BuscaSaldoSimplesRemessa(it.Nr_pedido.ToString(), it.Cd_produto, it.Id_pedidoitemstr, string.Empty, ref saldoQuantidade, ref saldoValor, 1, string.Empty, qtb_faturamento.Banco_Dados);
                            //if ((it.Quantidade > saldoQuantidade) && (it.Vl_subtotal > saldoValor))
                            //    throw new Exception("Saldo de nota mestra insuficiente para emitir nota simples remessa.\r\n" +
                            //                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                            //                        "Produto: " + it.Cd_produto + "\r\n" +
                            //                        "Saldo Nota Mestra (Qtd): " + saldoQuantidade.ToString("##0.00") + "\r\n" +
                            //                        "Saldo Nota Mestra (Vlr): " + saldoValor.ToString("##0.00") + "\r\n" +
                            //                        "Qtd Item: " + it.Quantidade.ToString("##0.00") + "\r\n" +
                            //                        "Vlr Item: " + it.Vl_subtotal.ToString("##0.00"));
                        }
                        else
                            //Verificar se o pedido confere saldo
                            if (val.St_confere_saldo && val.Cminf[0].St_geraestoquebool)
                            {
                                //Validar saldo complemento e normal
                                TCN_LanPedido_Item.BuscaSaldoNFNormal(it.Nr_pedido.ToString(), it.Cd_produto, it.Id_pedidoitemstr, string.Empty, ref saldoQuantidade, ref saldoValor, 1, string.Empty, qtb_faturamento.Banco_Dados);
                                if ((it.Quantidade > saldoQuantidade) && (it.Vl_subtotal > saldoValor))
                                    throw new Exception("Saldo do pedido insuficiente para emitir nota fiscal.\r\n" +
                                                        "Pedido: " + it.Nr_pedido.ToString() + "\r\n" +
                                                        "Produto: " + it.Cd_produto + "\r\n" +
                                                        "Saldo Pedido (Qtd): " + saldoQuantidade.ToString("##0.00") + "\r\n" +
                                                        "Saldo Pedido (Vlr): " + saldoValor.ToString("##0.00") + "\r\n" +
                                                        "Qtd Item: " + it.Quantidade.ToString("##0.00") + "\r\n" +
                                                        "Vlr Item: " + it.Vl_subtotal.ToString("##0.00"));
                            }
                        if ((it.Quantidade > 0) && (!val.Cminf[0].St_devolucaobool) && (!val.Cminf[0].St_retornobool))
                            //Verificar se o item e semente e a empresa gera apontamento de producao na venda
                            if (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoSemente(it.Cd_produto) &&
                                ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", val.Cd_empresa, qtb_faturamento.Banco_Dados).Trim().ToUpper().Equals("S"))
                            {
                                //Produzir semente
                                it.lLoteSemente.ForEach(lSem =>
                                    {
                                        //Buscar registro lote
                                        Sementes.TCN_LoteSemente.ProcessarApontamentoProducaoLoteSemente(
                                            new CamadaDados.Sementes.TCD_LoteSemente(qtb_faturamento.Banco_Dados).Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_lote",
                                                    vOperador = "=",
                                                    vVL_Busca = lSem.Id_lote.ToString()
                                                }
                                            }, 1, string.Empty)[0],
                                            lSem.Quantidade,
                                            qtb_faturamento.Banco_Dados);
                                    });
                            }
                    }
                    else
                        //Se for produto composto
                        if (val.Cminf[0].St_geraestoquebool && //Gerar Estoque
                            (val.Tp_movimento.Trim().ToUpper().Equals("S") || 
                            (val.Tp_movimento.Trim().ToUpper().Equals("E") && val.rCmi.St_devolucaobool)) && 
                            ((it.Quantidade_estoque > 0 ? it.Quantidade_estoque : it.Quantidade) > 0))
                        {
                            if (tEspera != null)
                                tEspera.Msg("Processando Produto composto...");
                            ProcessarProdutoComposto(val, it, qtb_faturamento.Banco_Dados);
                        }
                    it.Cd_empresa = val.Cd_empresa;
                    it.Nr_lanctofiscal = val.Nr_lanctofiscal.Value;
                    it.Dt_emissao = val.Dt_emissao;
                });
                if(tEspera != null)
                    tEspera.Msg("Gravando itens da nota fiscal...");
                TCN_LanFaturamento_Item.GravarFaturamentoItem(val.ItensNota, qtb_faturamento.Banco_Dados);
                                
                //Gravar Financeiro
                if (val.Duplicata.Count > 0)
                {
                    if(tEspera != null)
                        tEspera.Msg("Gravando financeiro da nota fiscal...");
                    //Uma nota não pode gerar mais que uma duplicata
                    if (string.IsNullOrEmpty(val.Duplicata[0].Nr_docto) || 
                        val.St_sequenciaauto)
                        val.Duplicata[0].Nr_docto = val.Nr_notafiscalstr;
                    //Gravar Duplicatas e Parcelas
                    if (val.lParcAgrupar.Count > 0)
                        TCN_LanDuplicata.AgruparDuplicata(val.Duplicata[0], val.lParcAgrupar, decimal.Zero, decimal.Zero, qtb_faturamento.Banco_Dados);
                    else
                        TCN_LanDuplicata.GravarDuplicata(val.Duplicata[0], false, qtb_faturamento.Banco_Dados);
                    //Gravar Nota Fiscal X Duplicatas
                    GravarFaturamentoXDuplicata(val, val.Duplicata[0], qtb_faturamento.Banco_Dados);
                }

                //Gravar Custo CMV
                if (!string.IsNullOrEmpty(val.Cd_centroresultCMV))
                {
                    //Buscar valor custo itens
                    decimal tot_cmv = decimal.Zero;
                    val.ItensNota.ForEach(p =>
                        {
                            decimal vl_cmv = decimal.Zero;
                            TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, p.Cd_produto, ref vl_cmv, qtb_faturamento.Banco_Dados);
                            tot_cmv += vl_cmv;
                        });
                    //Gravar Centro resultado
                    string id_ccustolan =
                    Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_centroresult = val.Cd_centroresultCMV,
                            Vl_lancto = tot_cmv,
                            Dt_lancto = val.Dt_emissao,
                            Tp_registro = "A"
                        }, qtb_faturamento.Banco_Dados);
                    //Faturamento x centro resultado
                    TCN_FaturamentoCCusto.Gravar(new TRegistro_FaturamentoCCusto()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctofiscal = val.Nr_lanctofiscal,
                        Id_ccustolan = decimal.Parse(id_ccustolan)
                    }, qtb_faturamento.Banco_Dados);
                }

                //Gravar Estoque
                if (val.Cminf[0].St_geraestoquebool)
                    if (val.ItensNota != null)
                    {
                        if(tEspera != null)
                            tEspera.Msg("Gravando estoque da nota fiscal...");
                        val.ItensNota.ForEach(p =>
                            {
                                ProcessarEstoqueNf(val,
                                                   p,
                                                   rCFG_Pedido,
                                                   ProcessarTaxas,
                                                   rCFG_Pedido.St_ExigirConferenciaEntregaBool,
                                                   qtb_faturamento.Banco_Dados);
                                if (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoComposto(p.Cd_produto) &&
                                    val.Tp_movimento.Trim().ToUpper().Equals("E") &&
                                    ((p.Quantidade_estoque > 0 ? p.Quantidade_estoque : p.Quantidade) > 0))
                                {
                                    //Processar Produto composto
                                    ProcessarProdutoComposto(val, p, qtb_faturamento.Banco_Dados);
                                    //Gravar Apontamento Item Nota
                                    TCN_LanFaturamento_Item.AlterarFaturamentoItem(p, qtb_faturamento.Banco_Dados);
                                }
                                //Verificar se a nota e de devolucao e movimenta quantidade
                                if ((val.Cminf[0].St_devolucaobool || val.Cminf[0].St_retornobool) && (p.Quantidade > 0))
                                    //Verificar se o item e semente e a empresa gera apontamento de producao na venda
                                    if (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoSemente(p.Cd_produto) &&
                                        TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", val.Cd_empresa, qtb_faturamento.Banco_Dados).Trim().ToUpper().Equals("S"))
                                    {
                                        //Estornar semente
                                        p.lLoteSemente.ForEach(lSem =>
                                        {
                                            CamadaDados.Sementes.TRegistro_LoteSemente rSem = 
                                                new CamadaDados.Sementes.TCD_LoteSemente(qtb_faturamento.Banco_Dados).Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_lote",
                                                            vOperador = "=",
                                                            vVL_Busca = lSem.Id_lote.ToString()
                                                        }
                                                    }, 1, string.Empty)[0];
                                            rSem.Id_formestorno = lSem.Id_formestorno;
                                            //Buscar registro lote
                                            Sementes.TCN_LoteSemente.ProcessarEstornoLoteSemente(rSem,
                                                                                                 lSem.Quantidade,
                                                                                                 qtb_faturamento.Banco_Dados);
                                        });
                                    }
                            });
                    }
                //Gravar Movimento Fiscal Pedido
                if (!val.Cminf[0].St_mestrabool)
                {
                    if(tEspera != null)
                        tEspera.Msg("Gravando movimento fiscal do pedido...");
                    TList_RegLanFaturamentoMovFiscal_Pedido lista = new TList_RegLanFaturamentoMovFiscal_Pedido();
                    for (int i = 0; i < val.ItensNota.Count; i++)
                    {
                        TRegistro_LanFaturamentoMovFiscal_Pedido reg_movfiscal = new TRegistro_LanFaturamentoMovFiscal_Pedido();
                        reg_movfiscal.Nr_lanctofiscal = val.Nr_lanctofiscal;
                        reg_movfiscal.Cd_empresa = val.Cd_empresa;
                        reg_movfiscal.Id_nfitem = val.ItensNota[i].Id_nfitem;
                        reg_movfiscal.Nr_pedido = val.ItensNota[i].Nr_pedido;
                        reg_movfiscal.Cd_produto = val.ItensNota[i].Cd_produto;
                        reg_movfiscal.Id_pedidoitem = val.ItensNota[i].Id_pedidoitem.Value;
                        reg_movfiscal.Tp_movimento = val.Tp_movimento;
                        reg_movfiscal.Quantidade = val.ItensNota[i].Quantidade;
                        reg_movfiscal.Vl_subtotal = val.ItensNota[i].Vl_subtotal;
                        lista.Add(reg_movfiscal);
                    }
                    TCN_LanFaturamentoMovFiscal_Pedido.GravaMovFiscal_Pedido(lista, qtb_faturamento.Banco_Dados);
                }
                //Processar Retencao Royalties GMO
                if (rCFG_Pedido.St_commodittiesbool && 
                    (!rCFG_Pedido.St_depositobool) &&
                    (rCFG_Pedido.St_valoresfixosbool || ((!rCFG_Pedido.St_valoresfixosbool) && 
                                                            (!val.Cminf[0].St_complementarbool) &&
                                                            (!val.Cminf[0].St_devolucaobool) &&
                                                            (!val.Cminf[0].St_retornobool))))
                {
                    if (tEspera != null)
                        tEspera.Msg("Gravando dados GMO da nota fiscal...");
                    TCN_LanRoyaltiesGMO.GravaGMO(val.ItensNota, false, false, val.Tp_movimento, qtb_faturamento.Banco_Dados);
                }
                //Gravar Contabilidade
                List<TRegistro_Lan_ProcFaturamento> lProcFat =
                TCN_Lan_ProcContabil.BuscaProc_Faturamento(val.Cd_empresa,
                                                           string.Empty,
                                                           string.Empty,
                                                           val.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           string.Empty,
                                                           false,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           decimal.Zero,
                                                           decimal.Zero,
                                                           qtb_faturamento.Banco_Dados);
                if (lProcFat.Count > 0)
                    if (lProcFat.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                    {
                        if (tEspera != null)
                            tEspera.Msg("Processando Contabilidade...");
                        TCN_LanContabil.ProcessaCTB_Faturamento(lProcFat.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_faturamento.Banco_Dados);
                    }
                //Gravar Contabilidade CMV
                List<TRegistro_Lan_ProcCMV> lProcCMV =
                    TCN_Lan_ProcContabil.BuscaProc_CMV(val.Cd_empresa,
                                                       string.Empty,
                                                       string.Empty,
                                                       val.Nr_lanctofiscalstr,
                                                       string.Empty,
                                                       string.Empty,
                                                       false,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       string.Empty,
                                                       decimal.Zero,
                                                       decimal.Zero,
                                                       qtb_faturamento.Banco_Dados);
                if (lProcCMV.Count > 0)
                    if (lProcCMV.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                    {
                        if (tEspera != null)
                            tEspera.Msg("Processando Contabilidade CMV...");
                        TCN_LanContabil.ProcessaCTB_CMV(lProcCMV.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_faturamento.Banco_Dados);
                    }
                //Gravar Ordem X Expedicao
                val.lOrdem.ForEach(p =>
                    {
                        p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                        TCN_Ordem_X_Expedicao.Gravar(p, qtb_faturamento.Banco_Dados);
                    });
                //Gravar Estoque NF Acessórios
                val.lNfAcessorios_X_Estoque.ForEach(p =>
                {
                    //Buscar Vl.Médio
                    decimal vl_unit = TCN_LanEstoque.Valor_Medio_Est_Produto(p.Cd_empresa,
                                                                                                   p.Cd_produto,
                                                                                                   qtb_faturamento.Banco_Dados);
                    //Gravar estoque
                    string retestoque = TCN_LanEstoque.GravarEstoque(new TRegistro_LanEstoque()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Cd_produto = p.Cd_produto,
                        Cd_local =  p.Cd_local,
                        Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                        Tp_movimento = val.Tp_movimento,
                        Qtd_entrada = decimal.Zero,
                        Qtd_saida = p.Quantidade,
                        Vl_unitario = vl_unit * p.Quantidade,
                        Vl_subtotal = vl_unit * p.Quantidade,
                        Tp_lancto = "L"
                    }, qtb_faturamento.Banco_Dados);
                    if (!string.IsNullOrEmpty(retestoque))
                    {
                        //Gravar Nota Fiscal Item X Estoque
                        TCN_NFAcessorios_X_Estoque.GravarNFAcessorios_X_Estoque(new TRegistro_NFAcessorios_X_Estoque()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retestoque, "@@P_ID_LANCTOESTOQUE")),
                            Nr_lanctofiscal = val.Nr_lanctofiscal
                        }, qtb_faturamento.Banco_Dados);
                    }
                });
                //Se NF-e de Terceiro, verificar se existe Evento ja registrado para a mesma
                if (val.Tp_nota.Trim().ToUpper().Equals("T") && val.Cd_modelo.Trim().Equals("55"))
                    new CamadaDados.Faturamento.NFE.TCD_EventoNFe(qtb_faturamento.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.chave_acesso",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Chave_acesso_nfe.Trim() + "'"
                            }
                        }, 0, string.Empty).ForEach(p =>
                        {
                            p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                            NFE.TCN_EventoNFe.Gravar(p, qtb_faturamento.Banco_Dados);
                        });
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_faturamento.deletarBanco_Dados();
            }
            return "@P_CD_EMPRESA:" + val.Cd_empresa.Trim() + "|@P_NR_LANCTOFISCAL: " + val.Nr_lanctofiscal.ToString().Trim() + "|@P_NR_NOTAFISCAL:" + val.Nr_notafiscalstr;
        }

        public static string AlterarFaturamento(TRegistro_LanFaturamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                {
                    qtb_faturamento.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_faturamento.Banco_Dados = banco;
                //Alterar campos Nota Fiscal
                string retorno = qtb_faturamento.AlteraNotaFiscal(val);
                //Alterar itens da nota
                val.ItensNota.ForEach(p => TCN_LanFaturamento_Item.AlterarFaturamentoItem(p, qtb_faturamento.Banco_Dados));
                if (st_transacao)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao alterar: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_faturamento.deletarBanco_Dados();
            }
        }

        public static void GravarNfDenegada(TRegistro_LanFaturamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                {
                    qtb_faturamento.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_faturamento.Banco_Dados = banco;
                val.St_registro = "D";
                qtb_faturamento.GravaNotaFiscal(val);
                //Verificar se não existe lançamento financeiro para a nf
                TList_RegLanDuplicata lDup = new TCD_LanDuplicata(qtb_faturamento.Banco_Dados).Select(
                                                new TpBusca[]
                                                {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                vOperador = "<>",
                                                                vVL_Busca = "'C'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                                            "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")"
                                                            }
                                                }, 0, string.Empty);
                if (lDup.Count > 0)
                    TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_faturamento.Banco_Dados);
                //Cancelar estoque
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("update tb_est_estoque set st_registro = 'C', dt_alt = getdate() ");
                sql.AppendLine("from tb_est_estoque as a, tb_fat_notafiscal_item_x_estoque as b, ");
                sql.AppendLine("tb_fat_notafiscal_item as c ");
                sql.AppendLine("Where a.cd_empresa = b.cd_empresa ");
                sql.AppendLine("and a.cd_produto = b.cd_produto ");
                sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                sql.AppendLine("and b.cd_empresa = c.cd_empresa ");
                sql.AppendLine("and b.nr_lanctofiscal = c.nr_lanctofiscal ");
                sql.AppendLine("and b.id_nfitem = c.id_nfitem ");
                sql.AppendLine("and c.cd_empresa = '" + val.Cd_empresa + "' ");
                sql.AppendLine("and c.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                //Cancelar NF Acessórios
                sql.AppendLine("update tb_est_estoque set st_registro = 'C', dt_alt = getdate() ");
                sql.AppendLine("from tb_est_estoque as a, ");
                sql.AppendLine("TB_FAT_NFAcessorios_X_Estoque as b ");
                sql.AppendLine("Where a.cd_empresa = b.cd_empresa ");
                sql.AppendLine("and a.cd_produto = b.cd_produto ");
                sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                sql.AppendLine("and b.cd_empresa = '" + val.Cd_empresa + "' ");
                sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                //Excluir faturamento Ordem X Expedição
                sql.AppendLine("update TB_FAT_Ordem_X_Expedicao set Nr_LanctoFiscal = null, DT_Alt = GETDATE() ");
                sql.AppendLine("where cd_empresa = '" + val.Cd_empresa + "' ");
                sql.AppendLine("and Nr_LanctoFiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                qtb_faturamento.executarSql(sql.ToString(), null);
                if (st_transacao)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro ao alterar: " + ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_faturamento.deletarBanco_Dados();
            }
        }

        public static string CancelarFaturamento(TRegistro_LanFaturamento val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_faturamento.CriarBanco_Dados(true);
                else
                    qtb_faturamento.Banco_Dados = banco;
                //Lista de Apontamento de Producao para excluir
                TList_ApontamentoProducao lApontamento = new TList_ApontamentoProducao();
                //Buscar CMI da nota fiscal
                TList_RegLanFaturamento_CMI lFatCmi = TCN_LanFaturamento_CMI.Busca(val.Cd_empresa, 
                                                                                   val.Nr_lanctofiscal.ToString(), 
                                                                                   1, 
                                                                                   string.Empty, 
                                                                                   qtb_faturamento.Banco_Dados);
                string retorno = string.Empty;
                //Verificar se NF possui Remessa Transporte
                if (val.Nr_lanctofiscalRT.HasValue)
                    throw new Exception("Nota Fiscal possui REMESSA PARA TRANSPORTE vinculada.\r\n" +
                                        "Para cancelar NF obrigatório antes cancelar REMESSA PARA TRANSPORTE<" + val.Nr_lanctofiscalRTstr + ">.");
                //Verificar se e NF-e
                if (val.Cd_modelo.Trim().Equals("55") && val.Tp_nota.Trim().ToUpper().Equals("P") && (val.Dt_processamento != null) && (val.St_registro.Trim() != "D"))
                {
                    object prazo = new TCD_CfgNfe(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                        }
                                    }, "isnull(HorasCancNfe, 0)");
                    if (prazo == null ? false : Convert.ToDecimal(prazo.ToString()) > 0)
                        if (CamadaDados.UtilData.Data_Servidor().Subtract(val.Dt_processamento.Value).Hours >= Convert.ToInt32(prazo.ToString()))
                            throw new Exception("Erro cancelar NF-e\r\n" +
                                                "Data Autorização..: " + val.Dt_processamento.Value.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n" +
                                                "Data Atual........: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy HH:mm:ss") + "\r\n" +
                                                "Prazo Cancelamento: " + prazo.ToString() + " Hora(s)");

                }
                if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR CANCELAR NOTAS FISCAIS", banco))
                {
                        //Verificar se o pedido não esta fechado
                        if (new TCD_Pedido(qtb_faturamento.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_pedido",
                                    vOperador = "=",
                                    vVL_Busca = val.Nr_pedido.HasValue ? val.Nr_pedido.ToString() : ""
                                }
                            }, "isNull(ST_Pedido, 'A')").ToString().Trim().ToUpper().Equals("P"))
                        {
                            //Verificar se o usuario nao tem permissao para acessar a tela de pedido
                            if((Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Parametros.pubLogin, "Faturamento.TFLan_Pedido") == null) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                                (!Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                                throw new Exception("Não é permitido cancelar uma nota fiscal de um pedido ENCERRADO.\r\n" +
                                                    "Pedido: " + (val.Nr_pedido.HasValue ? val.Nr_pedido.Value.ToString() : string.Empty) + "\r\n" +
                                                    "Para cancelar a nota fiscal é necessário reabrir o pedido.");
                        }
                        object obj = new CamadaDados.Graos.TCD_Transferencia(qtb_faturamento.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_gro_transf_x_pedido x "+
                                                "where x.id_transf = a.id_transf "+
                                                "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")"
                                }
                            }, "1");
                        if (obj != null)
                            if (obj.ToString().Trim().Equals("1"))
                                throw new Exception("Nota Fiscal possui amarração com a transferência de contratos.\r\nEsta nota somente poderá ser cancelada pela tela de transferência de contratos.");

                        //Verificar se a nota fiscal nao esta amarrada a um conhecimento de frete ativo ou processado
                        obj = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete(qtb_faturamento.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ctr_notafiscal x "+
                                                "where x.cd_empresa = a.cd_empresa "+
                                                "and x.nr_lanctoctr = a.nr_lanctoctr "+
                                                "and x.cd_empresa = '"+val.Cd_empresa.Trim()+"' "+
                                                "and x.nr_lanctofiscal = "+val.Nr_lanctofiscal+")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "in",
                                    vVL_Busca = "('A', 'P')"
                                }
                            }, "a.nr_ctrc");
                        if (obj != null)
                            if (obj.ToString().Trim() != string.Empty)
                                throw new Exception("Nota fiscal possui amarração com o conhecimento de frete Nº" + obj.ToString().Trim() + ".\r\n" +
                                                    "Necessario desamarrar a nota do conhecimento de frete antes.");
                        //Verificar se a nota possui comissao faturada
                        if (new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_faturamento.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctofiscal",
                                    vOperador = "=",
                                    vVL_Busca = val.Nr_lanctofiscal.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_comissao_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_comissao = a.id_comissao)"
                                }
                            }, "1") != null)
                            throw new Exception("Nota Fiscal possui comissão faturada.\r\n" +
                                                "Necessário cancelar duplicata de pagamento da comissão.");

                        //Verificar se não existe lançamento financeiro para a nf
                        TList_RegLanDuplicata lDup = new TCD_LanDuplicata(qtb_faturamento.Banco_Dados).Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                vOperador = "<>",
                                                                vVL_Busca = "'C'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                                                                            "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")"
                                                            }
                                                        }, 0, string.Empty);
                        if (lDup.Count > 0)
                        {
                            //Verificar se duplicata está agrupada
                            TList_RegLanDuplicata lDupAgp = new TCD_LanDuplicata(qtb_faturamento.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FIN_VincularDup x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and a.Nr_Lancto = x.Nr_Lancto " +
                                                                "and x.NR_LanctoVinculado = " + lDup[0].Nr_lancto + ") "
                                                }
                                    }, 1, string.Empty);
                            if (lDupAgp.Count > 0)
                                throw new Exception("\r\nNão é permitido cancelar uma nota fiscal com duplicata agrupada.\r\n" +
                                                     "Empresa................: " + val.Cd_empresa + "\r\n" +
                                                     "Nº Documento agrupador.: " + lDupAgp[0].Nr_docto + "\r\n" +
                                                     "Nº Duplicata agrupadora: " + lDupAgp[0].Nr_lancto.ToString() + "\r\n" +
                                                     "Para cancelar a nota fiscal é necessário cancelar primeiro a duplicata agrupadora!");
                            //Verificar se o usuario tem acesso a tela de duplicata
                            if ((Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                                        (!Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                                        (!Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                                        throw new Exception("Não é permitido cancelar uma nota fiscal com movimentação financeira.\r\n" +
                                                            "Empresa.....: " + val.Cd_empresa + "\r\n" +
                                                            "Nº Documento: " + lDup[0].Nr_docto.Trim() + "\r\n" +
                                                            "Nº Duplicata: " + lDup[0].Nr_lancto.ToString() + "\r\n" +
                                                            "Para cancelar a nota fiscal é necessário cancelar primeiro o financeiro.");
                            else
                                TCN_LanDuplicata.CancelarDuplicata(lDup[0], qtb_faturamento.Banco_Dados);
                        }
                        //Verificar se a nota não esta amarrada a nenhuma nota de devolução ou complemento
                        TList_LanFat_ComplementoDevolucao lNfCompDev = TCN_LanFat_ComplementoDevolucao.Buscar(val.Cd_empresa,
                                                                                                              val.Nr_lanctofiscal.ToString(),
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              decimal.Zero,
                                                                                                              decimal.Zero,
                                                                                                              0,
                                                                                                              string.Empty,
                                                                                                              qtb_faturamento.Banco_Dados);



                        if (lNfCompDev.Count.Equals(0))
                        {
                            //Iniciar o processo de cancelamento da nota fiscal
                            StringBuilder sql = new StringBuilder();
                            //Remessa Transporte
                            sql.AppendLine("update tb_fat_notafiscal set  ");
                            sql.AppendLine("nr_lanctofiscalRT = null ");
                            sql.AppendLine("where CD_Empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and NR_LanctoFiscalRT = " + val.Nr_lanctofiscal.ToString() + " ");
                            //Excluir MovFiscal X Pedido
                            sql.AppendLine("Delete From TB_FAT_MovFiscal_Pedido ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("And NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString());

                            //Excluir Aplicação X Nota Fiscal
                            sql.AppendLine("Delete From TB_FAT_Aplicacao_X_NotaFiscal ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            //Excluir Lançamento Contabil Nota Fiscal
                            sql.AppendLine("Delete TB_CTB_LanctosCTB ");
                            sql.AppendLine("From TB_CTB_LanctosCTB a ");
                            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
                            sql.AppendLine("On a.CD_Empresa = b.CD_Empresa ");
                            sql.AppendLine("and a.ID_LoteCTB = b.ID_LoteCTB_Fat ");
                            sql.AppendLine("Where b.CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and b.NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            //Excluir Lançamento Contabil CMV
                            sql.AppendLine("Delete TB_CTB_LanctosCTB ");
                            sql.AppendLine("From TB_CTB_LanctosCTB a ");
                            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
                            sql.AppendLine("On a.CD_Empresa = b.CD_Empresa ");
                            sql.AppendLine("and a.ID_LoteCTB = b.ID_LoteCTB_CMV ");
                            sql.AppendLine("Where b.CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and b.NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                                                        
                            //Excluir Originacao X LANCTO HEADGE
                            sql.AppendLine("Delete  TB_GRO_Lancto_NFHeadge ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscal + " ");

                            sql.AppendLine("Delete TB_GRO_Lancto_NFHeadge ");
                            sql.AppendLine("from TB_GRO_Lancto_NFHeadge k ");
                            sql.AppendLine("join tb_gro_originacao_x_faturamento a on k.cd_empresa = a.cd_empresa and k.nr_lanctofiscal = a.nr_lanctofiscal and k.id_nfitem = a.id_nfitem ");
                            sql.AppendLine("join tb_gro_originacao b on a.id_originacao = b.id_originacao ");
                            sql.AppendLine("Where b.CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and b.NR_LanctoFiscal = " + val.Nr_lanctofiscal + " ");

                            //Excluir Originacao X FATURAMENTO
                            sql.AppendLine("Delete tb_gro_originacao_x_faturamento ");
                            sql.AppendLine("from tb_gro_originacao_x_faturamento a  ");
                            sql.AppendLine("join tb_gro_originacao b on a.id_originacao = b.id_originacao ");
                            sql.AppendLine("Where b.CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and b.NR_LanctoFiscal = " + val.Nr_lanctofiscal + " ");

                            //Excluir Originacao
                            sql.AppendLine("Delete From tb_gro_originacao ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscal + " ");

                            //Alterar status das Taxas Processadas para Aberta
                            sql.AppendLine("update TB_GRO_Lancto_TaxaDeposito ");
                            sql.AppendLine("set ST_Registro = 'A' ");
                            sql.AppendLine("from TB_GRO_Lancto_TaxaDeposito a ");
                            sql.AppendLine("inner join TB_GRO_FatQuebraTec b ");
                            sql.AppendLine("on a.ID_LanTaxa = b.ID_LanTaxa ");
                            sql.AppendLine("where b.CD_Empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            //Excluir Processamento Quebra Tecnica
                            sql.AppendLine("Delete TB_GRO_FatQuebraTec ");
                            sql.AppendLine("where CD_Empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            //Excluir Serie Devolvida
                            sql.AppendLine("Delete TB_PRD_SerieDevolvida ");
                            sql.AppendLine("where CD_Empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscalstr);

                            //Cancelar Transferencia de estoque entre empresas - CHAVES BRASIL
                            TList_RegLanEstoque lEstoque =
                            new TCD_LanEstoque(qtb_faturamento.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_EST_TransfLocal_X_Estoque x " +
                                                    "             where x.cd_empresa = a.CD_Empresa " +
                                                    "             and x.Id_LanctoEstoque = a.Id_LanctoEstoque " +
                                                    "             and x.CD_Produto = a.CD_Produto " +
                                                    "             and exists (select 1 from tb_fat_notafiscal_item_x_estoque y " +
                                                    "                         where y.ID_Transf = x.ID_Transf " +
                                                    "                         and y.CD_Empresa = '" + val.Cd_empresa + "' " +
                                                    "                         and y.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")) " 
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty);
                                lEstoque.ForEach(p =>
                                {
                                    //Verificar se existe estoque para cancelar a nota fiscal
                                    decimal saldo = decimal.Zero;
                                    if (TCN_LanEstoque.BloquearEstoqueNegativo(p.Cd_empresa, p.Cd_produto, p.Cd_local,
                                        p.Qtd_entrada, ref saldo, qtb_faturamento.Banco_Dados) && p.Tp_movimento.ToUpper().Equals("E"))
                                    {
                                        throw new Exception("Não existe saldo no estoque para cancelar Nota Fiscal.\r\n" +
                                                        "Empresa: " + p.Cd_empresa.Trim() + " - " + p.Nm_empresa.Trim() + "\r\n" +
                                                        "Produto: " + p.Cd_produto.Trim() + " - " + p.Ds_produto.Trim() + "\r\n" +
                                                        "Local: " + p.Cd_local.Trim() + " - " + p.Ds_local.Trim() + "\r\n" +
                                                        "Saldo Disponivel: " + string.Format("{0:N3}", saldo) + "\r\n" +
                                                        "Saldo Requerido: " + string.Format("{0:N3}", p.Qtd_entrada) + "\r\n" +
                                                        "Informe o Depto Contabil para lançamento  da provisão de estoque !");
                                    }
                                    CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_faturamento.Banco_Dados);
                                });

                        //Cancelar estoque
                        if (lFatCmi[0].St_geraestoque.Trim().ToUpper().Equals("S"))
                                val.ItensNota.ForEach(p =>
                                    {
                                        if (p.Quantidade > 0)
                                        {
                                            if (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoComposto(p.Cd_produto))
                                            {
                                                //Buscar registro Producao
                                                TRegistro_ApontamentoProducao rApontamento =
                                                    TCN_ApontamentoProducao.Buscar(p.Id_apontamento.Value.ToString(),
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
                                                                                                                   string.Empty,
                                                                                                                   qtb_faturamento.Banco_Dados)[0];
                                                rApontamento.LApontamentoEstoque =
                                                    TCN_Apontamento_Estoque.Buscar(rApontamento.Id_apontamentostr,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   0,
                                                                                                                   string.Empty,
                                                                                                                   qtb_faturamento.Banco_Dados);
                                                rApontamento.LCustoFixo = TCN_Apontamento_CustoFixo.Buscar(rApontamento.Id_apontamentostr,
                                                                                                           string.Empty,
                                                                                                           0,
                                                                                                           string.Empty,
                                                                                                           qtb_faturamento.Banco_Dados);
                                                //Buscar Materia Prima Apontamento
                                                rApontamento.lMPrimaApontamento = TCN_Apontamento_MPrima.Buscar(rApontamento.Id_apontamentostr, qtb_faturamento.Banco_Dados);
                                                //Buscar Custo Fixo Apontamento
                                                rApontamento.LCustoFixo = TCN_Apontamento_CustoFixo.Buscar(rApontamento.Id_apontamentostr, string.Empty, 0, string.Empty, qtb_faturamento.Banco_Dados);
                                                lApontamento.Add(rApontamento);
                                                //Script para desamarrar apontamento do item da nota
                                                sql.AppendLine("update tb_fat_notafiscal_item set id_apontamento = null, dt_alt = getdate() ");
                                                sql.AppendLine("where cd_empresa = '" + p.Cd_empresa.Trim() + "' ");
                                                sql.AppendLine("and nr_lanctofiscal = " + p.Nr_lanctofiscal.ToString());
                                            }
                                            else
                                                if (val.Tp_movimento.Trim().ToUpper().Equals("E") && 
                                                    (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ItemServico(p.Cd_produto)) &&
                                                    (!new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoConsumoInterno(p.Cd_produto)))
                                                {
                                                    //Verificar se existe estoque para cancelar a nota fiscal
                                                    decimal saldo = decimal.Zero;
                                                    if (TCN_LanEstoque.BloquearEstoqueNegativo(val.Cd_empresa, p.Cd_produto, p.Cd_local,
                                                        p.Quantidade_estoque, ref saldo, qtb_faturamento.Banco_Dados))
                                                    {
                                                        throw new Exception("Não existe saldo no estoque para cancelar Nota Fiscal.\r\n" +
                                                                        "Produto: " + p.Cd_produto.Trim() + " - " + p.Ds_produto.Trim() + "\r\n" +
                                                                        "Local: " + p.Cd_local.Trim() + " - " + p.Ds_local.Trim() + "\r\n" +
                                                                        "Saldo Disponivel: " + string.Format("{0:N3}", saldo) + "\r\n" +
                                                                        "Saldo Requerido: " + string.Format("{0:N3}", p.Quantidade_estoque) + "\r\n" +
                                                                        "Informe o Depto Contabil para lançamento  da provisão de estoque !");
                                                    }
                                                }
                                                else if (new TCD_CadProduto(qtb_faturamento.Banco_Dados).ProdutoConsumoInterno(p.Cd_produto))
                                                {
                                                    obj = new TCD_Movimentacao(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from tb_amx_mov_x_nfitem x " +
                                                                                "where x.id_movimento = a.id_movimento " +
                                                                                "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                                "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " " +
                                                                                "and x.id_nfitem = " + p.Id_nfitem.ToString() + " " +
                                                                                "and isnull(a.st_registro, 'A') <> 'C')"
                                                                }
                                                            }, "a.id_almox");
                                                    if(obj != null)
                                                    {
                                                        //Verificar se existe saldo almoxarifado para cancelar item nf
                                                        decimal saldo = TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(val.Cd_empresa, obj.ToString(), p.Cd_produto, qtb_faturamento.Banco_Dados);
                                                        if (saldo < p.Quantidade_estoque)
                                                            throw new Exception("Não existe saldo no almoxarifado para cancelar Nota Fiscal.\r\n" +
                                                                                "Produto: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                                                                "Saldo Disponivel: " + string.Format("{0:N3}", saldo) + "\r\n" +
                                                                                "Saldo Requerido: " + string.Format("{0:N3}", p.Quantidade_estoque) + ".");
                                                    }
                                                }
                                                
                                        }
                                    });
                            //Cancelar estoque
                            sql.AppendLine("update tb_est_estoque set st_registro = 'C', dt_alt = getdate() ");
                            sql.AppendLine("from tb_est_estoque as a, tb_fat_notafiscal_item_x_estoque as b, ");
                            sql.AppendLine("tb_fat_notafiscal_item as c ");
                            sql.AppendLine("Where a.cd_empresa = b.cd_empresa ");
                            sql.AppendLine("and a.cd_produto = b.cd_produto ");
                            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                            sql.AppendLine("and b.cd_empresa = c.cd_empresa ");
                            sql.AppendLine("and b.nr_lanctofiscal = c.nr_lanctofiscal ");
                            sql.AppendLine("and b.id_nfitem = c.id_nfitem ");
                            sql.AppendLine("and c.cd_empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and c.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                            //Cancelar NF Acessórios
                            sql.AppendLine("update tb_est_estoque set st_registro = 'C', dt_alt = getdate() ");
                            sql.AppendLine("from tb_est_estoque as a, ");
                            sql.AppendLine("TB_FAT_NFAcessorios_X_Estoque as b ");
                            sql.AppendLine("Where a.cd_empresa = b.cd_empresa ");
                            sql.AppendLine("and a.cd_produto = b.cd_produto ");
                            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                            sql.AppendLine("and b.cd_empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            sql.AppendLine("delete TB_FAT_NFAcessorios_X_Estoque ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and Nr_lanctofiscal = " + val.Nr_lanctofiscalstr);
                            //Cancelar Almoxarifado
                            sql.AppendLine("update tb_amx_movimentacao ");
                            sql.AppendLine("set st_registro = 'C', dt_alt = getdate() ");
                            sql.AppendLine("from tb_amx_movimentacao a ");
                            sql.AppendLine("inner join tb_amx_mov_x_nfitem b ");
                            sql.AppendLine("on a.id_movimento = b.id_movimento ");
                            sql.AppendLine("where b.cd_empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString());
                            //Excluir Nota Fiscal Devolução / Complemento
                            sql.AppendLine("Delete From TB_FAT_CompDevol_NF ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and ((NR_LanctoFiscal_Origem = " + val.Nr_lanctofiscal.ToString() + ") ");
                            sql.AppendLine("or(NR_LanctoFiscal_Destino = " + val.Nr_lanctofiscal.ToString() + ")) ");

                            //Cancelar Nota Fiscal
                            sql.AppendLine("update tb_fat_notafiscal ");
                            sql.AppendLine("set st_registro = '" + (val.St_registro.Trim().ToUpper().Equals("D") ? "D" : "C") +"', ");
                            sql.AppendLine("dt_alt = getdate() ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa + "' ");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + "");

                            //Buscar TB_GRO_Lancto_TaxaDeposito
                            CamadaDados.Graos.TList_TaxaDeposito lTaxaDeposito = new CamadaDados.Graos.TCD_LanTaxaDeposito(qtb_faturamento.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_gro_saldocarenciataxa x " +
                                                    "inner join tb_gro_movdeposito y " +
                                                    "on x.id_movto = y.id_movto " +
                                                    "inner join tb_fat_notafiscal_item_x_estoque z " +
                                                    "on y.cd_empresa = z.cd_empresa " +
                                                    "and y.cd_produto = z.cd_produto " +
                                                    "and y.id_lanctoestoque = z.id_lanctoestoque " +
                                                    "where x.id_lantaxa = a.id_lantaxa " +
                                                    "and z.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                    "and z.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")"
                                    }
                                }, 0, string.Empty);
                            if (lTaxaDeposito.Exists(p => p.St_registro.Trim().ToUpper().Equals("P")))
                                throw new Exception("Existe taxa de deposito processada para a nota fiscal.\r\n" +
                                                    "Para cancelar a nota é necessario cancelar antes o pedido de faturamento das taxas.");
                            //Excluir Tabela TB_GRO_SaldoCarenciaTaxa
                            sql.AppendLine("delete tb_gro_saldocarenciataxa ");
                            sql.AppendLine("from tb_gro_saldocarenciataxa a ");
                            sql.AppendLine("inner join tb_gro_movdeposito b ");
                            sql.AppendLine("on a.id_movto = b.id_movto ");
                            sql.AppendLine("inner join tb_fat_notafiscal_item_x_estoque c ");
                            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
                            sql.AppendLine("and b.cd_produto = c.cd_produto ");
                            sql.AppendLine("and b.id_lanctoestoque = c.id_lanctoestoque ");
                            sql.AppendLine("where c.cd_empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and c.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");

                            //Excluir Tabela TB_GRO_MovDeposito
                            sql.AppendLine("delete tb_gro_movdeposito ");
                            sql.AppendLine("from tb_gro_movdeposito a ");
                            sql.AppendLine("inner join tb_fat_notafiscal_item_x_estoque b ");
                            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                            sql.AppendLine("and a.cd_produto = b.cd_produto ");
                            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                            sql.AppendLine("where b.cd_empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + " ");
                            //Excluir Tabela TB_BAL_Aplicacao_Pedido
                            sql.AppendLine("delete tb_Bal_Aplicacao_Pedido");
                            sql.AppendLine("From tb_Bal_Aplicacao_Pedido a ");
                            sql.AppendLine("inner join TB_FAT_Notafiscal_Item_X_Estoque b ");
                            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                            sql.AppendLine("and a.cd_produto = b.cd_produto ");
                            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                            sql.AppendLine("where b.cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscalstr);

                            //Excluir Pedido X Estoque
                            sql.AppendLine("Delete TB_FAT_Pedido_X_Estoque ");
                            sql.AppendLine("From TB_FAT_Pedido_X_Estoque a ");
                            sql.AppendLine("inner join TB_FAT_Notafiscal_Item_X_Estoque b ");
                            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                            sql.AppendLine("and a.cd_produto = b.cd_produto ");
                            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
                            sql.AppendLine("where b.cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and b.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString());

                            //Excluir Nota Fiscal X Estoque
                            sql.AppendLine("Delete From TB_FAT_NotaFiscal_Item_X_Estoque ");
                            sql.AppendLine("Where CD_Empresa = '" + val.Cd_empresa.Trim() + "' ");
                            sql.AppendLine("and NR_LanctoFiscal = " + val.Nr_lanctofiscal.ToString());

                            //Excluir Aplicacao X Nota Fiscal
                            sql.AppendLine("delete tb_fat_aplicacao_x_notafiscal ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString());
                            //Excluir GMO
                            new CamadaDados.Graos.TCD_LanRoyaltiesGMO(qtb_faturamento.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_gro_notafiscalGMO x " +
                                                    "where x.id_lanctogmo = a.id_lanctogmo " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                    "and x.nr_lanctofiscal = " + val.Nr_lanctofiscalstr + ")"
                                    }
                                }, 0, string.Empty).ForEach(p => Graos.TCN_LanRoyaltiesGMO.DeletarLanRoyaltiesGMO(p, qtb_faturamento.Banco_Dados));
                            //Excluir TB_FAT_ECFVinculadoNF
                            sql.AppendLine("delete tb_fat_ecfvinculadonf ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString());
                            //Excluir Comissao
                            sql.AppendLine("delete tb_fat_fechamento_comissao ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString());
                            //Cancelar Aplicacao Pesagem Diversas
                            sql.AppendLine("update TB_BAL_PsDiversas set NR_LanctoFiscal = null, ID_NFItem = null ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscalstr);
                            //Cancelar Faturamento do Pedido Ordem X Expedicao
                            sql.AppendLine("update TB_FAT_Ordem_X_Expedicao set NR_LanctoFiscal = null, Dt_Alt = GETDATE() ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and nr_lanctofiscal = " + val.Nr_lanctofiscalstr);
                            //Excluir Remessa ITENS CARGA AVULSA
                            sql.AppendLine("update TB_FAT_ITENSCARGAAVULSA set  Nr_LanctoFiscalS = null, ID_NFItemS = null, Dt_Alt = GETDATE() ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and Nr_LanctoFiscalS = " + val.Nr_lanctofiscal.ToString());
                            //Excluir Devolução ITENS CARGA AVULSA
                            sql.AppendLine("update TB_FAT_ITENSCARGAAVULSA set  Nr_LanctoFiscalD = null, ID_NFItemD = null, Dt_Alt = GETDATE() ");
                            sql.AppendLine("where cd_empresa = '" + val.Cd_empresa.Trim() + "'");
                            sql.AppendLine("and Nr_LanctoFiscalD = " + val.Nr_lanctofiscal.ToString());
                            //Excluir centro resultado
                            TList_FaturamentoCCusto lCCusto =
                            new TCD_FaturamentoCCusto(qtb_faturamento.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FIN_NotaFiscal_X_CCusto x " +
                                                    "where x.id_ccustolan = a.id_ccustolan " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                    "and x.nr_lanctofiscal = " + val.Nr_lanctofiscalstr + ")"
                                    }
                                }, 0, string.Empty);
                            //Excluir Nota Fiscal X Centro Resultado
                            if (lCCusto.Count > 0)
                            {
                                sql.AppendLine("delete TB_FIN_NotaFiscal_X_CCusto ");
                                sql.AppendLine("where x.cd_empresa = '" + val.Cd_empresa.Trim() + "' ");
                                sql.AppendLine("and x.nr_lanctofiscal = " + val.Nr_lanctofiscalstr);
                            }
                            //Executar Script
                            qtb_faturamento.executarSql(sql.ToString(), null);
                            //Excluir taxas de deposito
                            lTaxaDeposito.ForEach(p => Graos.TCN_LanTaxas_Deposito.Excluir(p, qtb_faturamento.Banco_Dados));
                            //Excluir Apontamento Producao
                            lApontamento.ForEach(p => TCN_ApontamentoProducao.Deletar(p, qtb_faturamento.Banco_Dados));
                            //Excluir Centro Resultado
                            lCCusto.ForEach(p => TCN_FaturamentoCCusto.Excluir(p, qtb_faturamento.Banco_Dados));
                            //Excluir devolucao financeira
                            TCN_DevolucaoFIN.Buscar(val.Cd_empresa,
                                                    val.Nr_lanctofiscalstr,
                                                    string.Empty,
                                                    string.Empty,
                                                    qtb_faturamento.Banco_Dados).ForEach(p =>
                                                        {
                                                            if (p.Id_adto.HasValue)
                                                                Financeiro.Adiantamento.TCN_LanAdiantamento.Excluir(
                                                                    Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(p.Id_adtostr,
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
                                                                                                                       string.Empty,
                                                                                                                       string.Empty,
                                                                                                                       1,
                                                                                                                       string.Empty,
                                                                                                                       qtb_faturamento.Banco_Dados)[0], qtb_faturamento.Banco_Dados);
                                                            TCN_DevolucaoFIN.Excluir(p, qtb_faturamento.Banco_Dados);
                                                        });
                            //Se Nota de Terceiro, excluir a nota direto
                            if (val.Tp_nota.Trim().ToUpper().Equals("T") ||
                                (val.Tp_nota.Trim().ToUpper().Equals("P") &&
                                val.Cd_modelo.Trim().Equals("55") &&
                                string.IsNullOrEmpty(val.Nr_protocolo)))
                                ExcluirNotaFiscal(val, qtb_faturamento.Banco_Dados);
                            if (pode_liberar)
                                qtb_faturamento.Banco_Dados.Commit_Tran();
                            return retorno;

                        }
                        else
                        {
                            string nfCompDev = string.Empty;
                            for (int i = 0; i < lNfCompDev.Count; i++)
                            {
                                nfCompDev = "Empresa: " + lNfCompDev[i].Cd_empresa + "\r\n" +
                                            "Lancto Fiscal: " + lNfCompDev[i].Nr_lanctofiscal_destino.ToString() + "\r\n";
                                if (lNfCompDev[i].Tp_operacao.Trim().Equals("D"))
                                    nfCompDev += "Operação: Devolução\r\n\r\n";
                                else if (lNfCompDev[i].Tp_operacao.Trim().Equals("C"))
                                    nfCompDev += "Operação: Complemento\r\n\r\n";
                                else if (lNfCompDev[i].Tp_operacao.Trim().ToUpper().Equals("E"))
                                    nfCompDev += "Operação: Entrega Futura\r\n\r\n";
                            }
                            throw new Exception("Não é permitido cancelar uma nota fiscal que possui notas fiscais de devolução/complemento/entrega futura.\r\n" +
                                            "----------Notas Fiscais de Complemento/Devolução----------\r\n" + nfCompDev +
                                            "Para cancelar a nota fiscal é necessário cancelar primeiro as notas de devolução/complemento/entrega futura.");
                        }
                    }
                    else
                        throw new Exception("Usuário não tem permissão para cancelar nota fiscal.\r\n" +
                                            "Login: " + Parametros.pubLogin.Trim().ToUpper() + "\r\n" +
                                            "Solução: Para o login " + Parametros.pubLogin.Trim().ToUpper() + " poder cancelar nota fiscal é necessário dar acesso ao mesmo\r\n" +
                                            "através da regra especial <PERMITIR CANCELAR NOTAS FISCAIS>, localizado no cadastro de usuário.");
                //}
                //else
                //    throw new Exception("Não é permitido cancelar uma nota fiscal com data de emissão menor que a data do ultimo fechamento contábil.\r\n" +
                //                        "Data emissão NF: " + (val.Dt_emissao.HasValue ? val.Dt_emissao.Value.ToString("dd/MM/yyyy") : string.Empty) + "\r\n" +
                //                        "Data ultimo fechamento contábil: " + dt_fechamento.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar Nota Fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_faturamento.deletarBanco_Dados();
            }
        }

        public static bool ExcluirNotaFiscal(TRegistro_LanFaturamento val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_nf = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nf.CriarBanco_Dados(true);
                else
                    qtb_nf.Banco_Dados = banco;
                //Verificar se NFe e se a mesma foi cancelada junto a receita
                if (val.Cd_modelo.Trim().Equals("55") && 
                    (new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal(qtb_nf.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_lanctofiscal",
                            vOperador = "=",
                            vVL_Busca = val.Nr_lanctofiscal.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.status",
                            vOperador = "in",
                            vVL_Busca = "('100', '110')"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "d.tp_ambiente",
                            vOperador = "<>",
                            vVL_Busca = "'2'"//Producao
                        }
                    }, "1") != null))
                    throw new Exception("Não é permitido excluir Nota Fiscal Eletronica ACEITA ou DENEGADA pela receita.");
                int mes = 0;
                int ano = 0;
                //Verificar se a nota fiscal esta dentro do mes corrente
                if (val.Tp_movimento.Trim().ToUpper().Equals("E"))
                {
                    mes = val.Dt_saient.Value.Month;
                    ano = val.Dt_saient.Value.Year;
                }
                else
                {
                    mes = val.Dt_emissao.Value.Month;
                    ano = val.Dt_emissao.Value.Year;
                }
                if (CamadaDados.UtilData.Data_Servidor().Month.Equals(val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient.Value.Month : val.Dt_emissao.Value.Month) &&
                    CamadaDados.UtilData.Data_Servidor().Year.Equals(val.Tp_movimento.Trim().ToUpper().Equals("E") ? val.Dt_saient.Value.Year : val.Dt_emissao.Value.Year))
                    qtb_nf.ExcluirNotaFiscal(val);
                else if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUIR NOTA FISCAL FORA PERIODO", banco))
                    qtb_nf.ExcluirNotaFiscal(val);
                else
                    throw new Exception("Usuario " + Parametros.pubLogin.Trim() +" não é tem permissão para excluir nota fiscal com data movimentação fora do mês corrente.");
                if (st_transacao)
                    qtb_nf.Banco_Dados.Commit_Tran();
                return true;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir nota fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nf.deletarBanco_Dados();
            }
        }

        public static TList_RegLanDuplicata BuscaDuplicataXFaturamento(string vCD_Empresa,
                                                                       string vNR_LanctoFiscal,
                                                                       int vTop,
                                                                       string vNM_Campo,
                                                                       bool BuscarParcelas,
                                                                       TObjetoBanco banco)
        {
            TList_RegLanDuplicata lDup = new TCD_LanDuplicata(banco).Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                                "and x.cd_empresa = '" + vCD_Empresa.Trim() + "' " +
                                                                "and x.nr_lanctofiscal = " + vNR_LanctoFiscal + ")"
                                                }
                                            }, 1, string.Empty);
            //Buscar Parcelas Duplicata
            lDup.ForEach(p => p.Parcelas = TCN_LanParcela.Busca(p.Cd_empresa,
                                                                                                   p.Nr_lancto,
                                                                                                   decimal.Zero,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   0,
                                                                                                   string.Empty,
                                                                                                   banco));
            return lDup;
        }

        public static string GravarFaturamentoXDuplicata(TRegistro_LanFaturamento vNotaFiscal, TRegistro_LanDuplicata vDuplicata, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                {
                    qtb_faturamento.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_faturamento.Banco_Dados = banco;
                string retorno = qtb_faturamento.GravaNotaFiscalXDuplicata(vNotaFiscal, vDuplicata);
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                return string.Empty;
            }
            finally
            {
                if (pode_liberar)
                    qtb_faturamento.deletarBanco_Dados();
            }
        }

        public static string DeletarFaturamentoXDuplicata(TRegistro_LanFaturamento vNotaFiscal, TRegistro_LanDuplicata vDuplicata, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanFaturamento qtb_faturamento = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                {
                    qtb_faturamento.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_faturamento.Banco_Dados = banco;
                return qtb_faturamento.DeletaNotaFiscalXDuplicata(vNotaFiscal, vDuplicata);
            }
            catch
            {
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.RollBack_Tran();
                return string.Empty;
            }
            finally
            {
                if(pode_liberar)
                    qtb_faturamento.deletarBanco_Dados();
            }
        }

        public static int validarST_Nota(string vTP_Movto,
                                         string vTP_Pessoa,
                                         bool vST_Equiparado_PJ,
                                         bool vST_Equiparado_PF)
        {
            int retorno = -1;
            if (vTP_Movto.Trim().Equals("S"))
                return 0; //Propria
            else if (vTP_Movto.Trim().Equals("E"))
            {
                if (vTP_Pessoa.Trim().Equals("F"))
                    if (vST_Equiparado_PJ)
                        return 1; //Terceiro
                    else
                        return 0; //Propria
                else if (vTP_Pessoa.Trim().Equals("J"))
                    if (vST_Equiparado_PF)
                        return 0; //Propria
                    else
                        return 1; //Terceiro
            }
            return retorno;
        }

        public static TRegistro_LanFaturamento existeNumeroNota(string vNR_NotaFiscal,
                                                                string vNR_Serie,
                                                                string vCD_Empresa,
                                                                string vCD_Clifor,
                                                                string vInsc_estadual,
                                                                string vTP_Nota,
                                                                TObjetoBanco banco)
        {
            if (vNR_NotaFiscal.Equals(0))
                return null;
            TList_RegLanFaturamento lista = new TList_RegLanFaturamento();
            if (vTP_Nota.Trim().Equals("P"))
                lista = Busca(vCD_Empresa, 
                              vNR_NotaFiscal, 
                              vNR_Serie, 
                              string.Empty, 
                              string.Empty, 
                              string.Empty, 
                              decimal.Zero, 
                              string.Empty, 
                              string.Empty, 
                              string.Empty, 
                              string.Empty, 
                              string.Empty,
                              string.Empty,
                              string.Empty, 
                              string.Empty, 
                              false, 
                              string.Empty, 
                              string.Empty,
                              string.Empty, 
                              string.Empty, 
                              string.Empty,
                              string.Empty, 
                              string.Empty, 
                              string.Empty, 
                              decimal.Zero, 
                              decimal.Zero, 
                              string.Empty,
                              "'P'",//Propria
                              string.Empty,
                              false,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              1, 
                              string.Empty, 
                              banco);
            else if (vTP_Nota.Trim().Equals("T"))
                lista = Busca(vCD_Empresa,
                              vNR_NotaFiscal,
                              vNR_Serie,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              vCD_Clifor,
                              string.Empty,
                              vInsc_estadual,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              false,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              decimal.Zero,
                              decimal.Zero,
                              string.Empty,
                              "'T'",//Terceiro
                              string.Empty,
                              false,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              1,
                              string.Empty,
                              banco);

            if ((vTP_Nota.Trim() == "P") || (vTP_Nota.Trim() == "T"))
            {
                if (lista.Count > 0)
                    return lista[0];
                else
                    return null;
            }
            else
                return null;
        }

        public static string ProcessarEstoqueFazenda(TRegistro_LanEstoque reg_estoque, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanEstoque lanEstoque = new TCD_LanEstoque();
            try
            {
                if (banco == null)
                    pode_liberar = lanEstoque.CriarBanco_Dados(true);
                else
                    lanEstoque.Banco_Dados = banco;
                string retorno = lanEstoque.GravaEstoque(reg_estoque);
                if (pode_liberar)
                    lanEstoque.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    lanEstoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar estoque fazenda: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    lanEstoque.deletarBanco_Dados();
            } 
        }

        public static void ReprocessarEstoqueNf(TRegistro_LanFaturamento val,
                                                TObjetoBanco banco)
        {
            if (val == null)
                return;
            bool st_transacao = false;
            TCD_LanFaturamento qtb_fat = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Verificar se o CMI movimenta estoque
                if (!val.Cd_cmi.HasValue)
                    throw new Exception("Objeto Nota Fiscal não possui CMI.");
                TRegistro_CadCMI rCmi = TCN_CadCMI.Busca(val.Cd_cmi.Value.ToString(),
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
                                                         qtb_fat.Banco_Dados)[0];
                if (!rCmi.St_geraestoquebool)
                    throw new Exception("CMI " + rCmi.Cd_cmiString.Trim() + " não esta configurado para gerar estoque.");
                //Verificar se a nota fiscal ja nao tem estoque gravado
                object obj = new TCD_LanEstoque(qtb_fat.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.cd_produto = a.cd_produto " +
                                                    "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                    "and x.nr_lanctofiscal = " + val.Nr_lanctofiscal.ToString() + ")"
                                    }
                                }, "1");
                if (obj != null)
                    throw new Exception("Não é permitido reprocessar estoque de um documento fiscal que ja possui estoque.");

                //Buscar Configuracao do PEDIDO
                TRegistro_CadCFGPedido rCFG_Pedido =
                    new TCD_CadCFGPedido(qtb_fat.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                        "where x.cfg_pedido = a.cfg_pedido " +
                                        "and x.nr_pedido = " + val.Nr_pedidostring + ")"
                        }
                    }, 1, string.Empty)[0];
                //Alterar CMI da nota
                if (val.Cminf.Count < 1)
                {
                    val.Cminf.Add(new TRegistro_LanFaturamento_CMI()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_lanctofiscal = val.Nr_lanctofiscal.Value,
                        St_mestra = rCmi.St_mestra,
                        St_devolucao = rCmi.St_devolucao,
                        St_complementar = rCmi.St_complementar,
                        St_geraestoque = rCmi.St_geraestoque,
                        St_simplesremessa = rCmi.St_simplesremessa,
                        St_retorno = rCmi.St_retorno
                    });
                }
                else
                {
                    val.Cminf[0].St_mestra = rCmi.St_mestra;
                    val.Cminf[0].St_devolucao = rCmi.St_devolucao;
                    val.Cminf[0].St_complementar = rCmi.St_complementar;
                    val.Cminf[0].St_geraestoque = rCmi.St_geraestoque;
                    val.Cminf[0].St_simplesremessa = rCmi.St_simplesremessa;
                }
                //Reprocessar o estoque
                val.ItensNota.ForEach(p =>
                    {
                        if ((!new TCD_CadProduto(qtb_fat.Banco_Dados).ItemServico(p.Cd_produto)) &&
                            (!new TCD_CadProduto(qtb_fat.Banco_Dados).ProdutoConsumoInterno(p.Cd_produto)))
                        {
                            if (new TCD_CadProduto(qtb_fat.Banco_Dados).ProdutoComposto(p.Cd_produto) && //Produto Composto
                                rCmi.St_geraestoquebool && //Gerar Estoque
                                val.Tp_movimento.Trim().ToUpper().Equals("S") && //Nota Saida
                                ((p.Quantidade_estoque > 0 ? p.Quantidade_estoque : p.Quantidade) > 0))
                                ProcessarProdutoComposto(val, p, qtb_fat.Banco_Dados);

                            //Processar o estoque
                            ProcessarEstoqueNf(val,
                                               p,
                                               rCFG_Pedido,
                                               false,
                                               rCFG_Pedido.St_ExigirConferenciaEntregaBool,
                                               qtb_fat.Banco_Dados);
                            if (new TCD_CadProduto(qtb_fat.Banco_Dados).ProdutoComposto(p.Cd_produto) && //Produto Composto
                                rCmi.St_geraestoquebool && //Gerar Estoque
                                val.Tp_movimento.Trim().ToUpper().Equals("E") &&
                                ((p.Quantidade_estoque > 0 ? p.Quantidade_estoque : p.Quantidade) > 0))
                            {
                                //Processar Produto composto
                                ProcessarProdutoComposto(val, p, qtb_fat.Banco_Dados);
                                //Gravar Apontamento Item Nota
                                TCN_LanFaturamento_Item.AlterarFaturamentoItem(p, qtb_fat.Banco_Dados);
                            }
                            //Verificar se a nota e de devolucao e movimenta quantidade
                            if ((rCmi.St_devolucaobool || rCmi.St_retornobool) && (p.Quantidade > 0))
                                //Verificar se o item e semente e a empresa gera apontamento de producao na venda
                                if (new TCD_CadProduto(qtb_fat.Banco_Dados).ProdutoSemente(p.Cd_produto) &&
                                    ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", val.Cd_empresa, qtb_fat.Banco_Dados).Trim().ToUpper().Equals("S"))
                                {
                                    //Estornar semente
                                    p.lLoteSemente.ForEach(lSem =>
                                    {
                                        CamadaDados.Sementes.TRegistro_LoteSemente rSem =
                                            new CamadaDados.Sementes.TCD_LoteSemente(qtb_fat.Banco_Dados).Select(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_lote",
                                                            vOperador = "=",
                                                            vVL_Busca = lSem.Id_lote.ToString()
                                                        }
                                                    }, 1, string.Empty)[0];
                                        rSem.Id_formestorno = lSem.Id_formestorno;
                                        //Buscar registro lote
                                        Sementes.TCN_LoteSemente.ProcessarEstornoLoteSemente(rSem,
                                                                                             lSem.Quantidade,
                                                                                             qtb_fat.Banco_Dados);
                                    });
                                }
                        }
                    });
                //Alterar CMI da Nota
                TCN_LanFaturamento_CMI.Gravar(val.Cminf[0], qtb_fat.Banco_Dados);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reprocessar estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static TRegistro_LanFaturamento ProcessarNotaFiscalRetornoConserto(CamadaDados.Servicos.TList_LanServico lOs)
        {
            //Buscar pedido de remessa da primeira os
            TList_Pedido lPedRemessa = new TCD_Pedido().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_pedido, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x "+
                                    "where x.nr_pedido = a.nr_pedido "+
                                    "and x.tp_pedido = 'RM' "+
                                    "and x.cd_empresa = '" + lOs[0].Cd_empresa.Trim() + "' " +
                                    "and x.id_os = " + lOs[0].Id_os.ToString() + ")"
                    }
                }, 1, string.Empty);
            if (lPedRemessa.Count.Equals(0))
                throw new Exception("Não existe pedido de remessa amarrado a ordem de serviço.");
            //Buscar configuracao fiscal do pedido da primeira ordem
            TList_CadCFGPedidoFiscal lPedFiscal = new TCD_CadCFGPedidoFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cfg_pedido",
                        vOperador = "=",
                        vVL_Busca = "'" + lPedRemessa[0].CFG_Pedido.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_fiscal",
                        vOperador = "=",
                        vVL_Busca = "'DV'"
                    }
                }, 1, string.Empty);
            if (lPedFiscal.Count.Equals(0))
                throw new Exception("Não existe configuração fiscal de devolução para o tipo de pedido de remessa das ordens de serviço.");
            if(lPedFiscal[0].Cd_modelo.Trim().Equals(string.Empty))
                throw new Exception("Configuração de modelo de nota é obriatório para o tipo de pedido " + lPedFiscal[0].Cfg_pedido.ToString());
            //Preencher o objeto nota fiscal
            TRegistro_LanFaturamento rNf = new TRegistro_LanFaturamento();
            rNf.Cd_empresa = lPedRemessa[0].CD_Empresa;
            rNf.Cd_clifor = lPedRemessa[0].CD_Clifor;
            rNf.Nm_clifor = lPedRemessa[0].NM_Clifor;
            rNf.Cd_endereco = lPedRemessa[0].CD_Endereco;
            rNf.Cd_cmi = lPedFiscal[0].Cd_cmi;
            rNf.Cd_movimentacao = lPedFiscal[0].Cd_movto;
            rNf.lCFGFiscal = lPedFiscal;
            rNf.Cd_modelo = lPedFiscal[0].Cd_modelo;
            rNf.Uf_empresa = lPedRemessa[0].Uf_empresa;
            rNf.Uf_clifor = lPedRemessa[0].UF_Cliente;
            rNf.Cd_condfiscal_clifor = lPedRemessa[0].Cd_condfiscal_clifor;

            rNf.Tp_duplicata = lPedFiscal[0].Tp_duplicata;
            rNf.Ds_tpduplicata = lPedFiscal[0].Ds_tpduplicata;
            rNf.Nr_pedido = lPedRemessa[0].Nr_pedido;
            rNf.Tp_movimento = "S";
            rNf.Tp_pessoa = lPedRemessa[0].Tp_pessoa;
            rNf.Tp_nota = "P";//Nota Propria
            rNf.Nr_serie = lPedFiscal[0].Nr_serie.Trim();
            rNf.St_sequenciaauto = lPedFiscal[0].ST_SequenciaAuto.Equals("S");
            rNf.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
            rNf.Dt_saient = rNf.Dt_emissao;
            //Criar a lista de itens da nota fiscal
            lOs.ForEach(p =>
                {
                    //Buscar pedidos de remessa da os
                    CamadaDados.Servicos.TList_Servico_X_PedidoItem lPedItem =
                        Servicos.TCN_Servico_X_PedidoItem.Buscar(p.Id_os.ToString(),
                                                                 p.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 "RM",
                                                                 1,
                                                                 string.Empty,
                                                                 null);
                    if(lPedItem.Count.Equals(0))
                        throw new Exception("Não existe pedido de remessa amarrado a ordem de serviço.");
                    //Verificar se o produto ja existe na lista de itens da nota
                    if (rNf.ItensNota.Exists(v => v.Cd_produto.Trim().Equals(lPedItem[0].Cd_produto.Trim()) &&
                                                  v.Nr_pedido.Equals(lPedItem[0].Nr_pedido) &&
                                                  v.Id_pedidoitem.Equals(lPedItem[0].Id_pedidoitem)))
                    {
                        rNf.ItensNota.Find(v => v.Cd_produto.Trim().Equals(lPedItem[0].Cd_produto.Trim()) &&
                                                  v.Nr_pedido.Equals(lPedItem[0].Nr_pedido) &&
                                                  v.Id_pedidoitem.Equals(lPedItem[0].Id_pedidoitem)).Quantidade += 1;
                    }
                    else
                    {
                        //Buscar condicao fiscal do produto
                        object obj = new TCD_CadProduto().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lPedItem[0].Cd_produto.Trim() + "'"
                                }
                            }, "a.cd_condfiscal_produto");
                        if (obj == null)
                            throw new Exception("Não existe condição fiscal cadastrada para o produto " + lPedItem[0].Cd_produto.Trim() + ".");
                        TRegistro_LanFaturamento_Item itensnf = new TRegistro_LanFaturamento_Item();
                        itensnf.Cd_empresa = rNf.Cd_empresa;
                        itensnf.Cd_produto = lPedItem[0].Cd_produto;
                        itensnf.Cd_local = string.Empty;
                        itensnf.Cd_condfiscal_produto = obj.ToString();
                        itensnf.Cd_unidade = p.Cd_unidOS;
                        itensnf.Cd_unidEst = p.Cd_unidOS;
                        itensnf.Nr_pedido = lPedItem[0].Nr_pedido.Value;
                        itensnf.Id_pedidoitem = lPedItem[0].Id_pedidoitem;
                        itensnf.Quantidade = 1;
                        itensnf.Quantidade_estoque = 1;
                        //Buscar cfop do item
                        bool st_dentroestado = rNf.Uf_clifor.Trim().Equals(rNf.Uf_empresa.Trim());
                        TRegistro_CadCFOP rCfop = null;
                        if (TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                      lPedItem[0].Cd_condfiscal_produto,
                                                      rNf.Cd_uf_clifor.Trim().Equals("99") ? "I" : rNf.Cd_uf_clifor.Trim().Equals(rNf.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                      rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa,
                                                      rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor,
                                                      rNf.Tp_movimento,
                                                      rNf.Cd_condfiscal_clifor,
                                                      rNf.Cd_empresa,
                                                      ref rCfop,
                                                      null))
                        {
                            itensnf.Cd_cfop = rCfop.CD_CFOP;
                            itensnf.Ds_cfop = rCfop.DS_CFOP;
                            itensnf.St_bonificacao = rCfop.St_bonificacaobool;
                        }
                        else
                            throw new Exception("Não existe CFOP " + (rNf.Cd_uf_clifor.Trim().Equals("99") ? "internacional" : rNf.Cd_uf_clifor.Trim().Equals(rNf.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + lPedItem[0].Cd_condfiscal_produto);
                        //Procurar Impostos Estaduais para o Item
                        string vobsfiscal = string.Empty;
                        TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(rNf.Cd_empresa,
                                                                                               rNf.Cd_uf_empresa,
                                                                                               rNf.Cd_uf_clifor,
                                                                                               rNf.Cd_movimentacao.Value.ToString(),
                                                                                               rNf.Tp_movimento,
                                                                                               rNf.Cd_condfiscal_clifor,
                                                                                               itensnf.Cd_condfiscal_produto,
                                                                                               itensnf.Vl_basecalcImposto,
                                                                                               itensnf.Quantidade,
                                                                                               ref vobsfiscal,
                                                                                               rNf.Dt_emissao,
                                                                                               itensnf.Cd_produto,
                                                                                               rNf.Tp_nota,
                                                                                               rNf.Nr_serie,
                                                                                               null);
                        if (lImpUf.Count > 0)
                        {
                            TCN_LanFaturamento_Item.PreencherICMS(lImpUf[0], itensnf);
                            rNf.Obsfiscal += string.IsNullOrEmpty(rNf.Obsfiscal) ? vobsfiscal.Trim() : "\r\n" + vobsfiscal.Trim();
                        }
                        else if (TCN_LanFaturamento_Item.ObrigImformarICMS(itensnf.Cd_produto, rNf.Nr_serie, null))
                            throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                "Tipo Movimento: SAIDA\r\n" +
                                                "Movimentação: " + rNf.Cd_movimentacao.Value.ToString() + "\r\n" +
                                                "Cond. Fiscal Clifor: " + rNf.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Cond. Fiscal Produto: " + itensnf.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "UF Origem: " + rNf.Cd_uf_empresa.Trim() + "\r\n" +
                                                "UF Destino: " + rNf.Cd_uf_clifor.Trim());
                        
                        //Procurar impostos sobre os itens da nota fiscal de destino
                        TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                            TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                                  itensnf.Cd_condfiscal_produto,
                                                                                  rNf.Cd_movimentacao.Value.ToString(),
                                                                                  rNf.Tp_movimento,
                                                                                  rNf.Tp_pessoa,
                                                                                  rNf.Cd_empresa,
                                                                                  rNf.Nr_serie,
                                                                                  rNf.Cd_clifor,
                                                                                  itensnf.Cd_unidEst,
                                                                                  rNf.Dt_emissao,
                                                                                  itensnf.Quantidade,
                                                                                  itensnf.Vl_subtotal,
                                                                                  rNf.Tp_nota,
                                                                                  string.Empty,
                                                                                  null), itensnf, rNf.Tp_movimento);
                        rNf.ItensNota.Add(itensnf);
                    }});
            return rNf;
        }

        public static decimal CalcTotalFinNota(TRegistro_LanFaturamento val)
        {
            decimal total = decimal.Zero;
            if (val != null)
                total = val.ItensNota.Where(p => !p.St_bonificacao).Sum(p => p.Vl_subtotal - 
                                                                             p.Vl_desconto + 
                                                                             p.Vl_freteitem + 
                                                                             p.Vl_juro_fin +
                                                                             p.Vl_seguro +
                                                                             p.Vl_outrasdesp +
                                                                             p.Vl_FCPST +
                                                                             p.Vl_ICMSST -
                                                                             p.Vl_ICMSRetido -
                                                                             p.Vl_retidoCofins -
                                                                             p.Vl_retidoCSLL -
                                                                             p.Vl_retidoFunrural -
                                                                             p.Vl_retidoINSS -
                                                                             p.Vl_retidoIRRF -
                                                                             p.Vl_retidoPIS -
                                                                             p.Vl_issretido -
                                                                             p.Vl_retidoSenar +
                                                                             (p.St_totalnotaCofins.Trim().ToUpper().Equals("S") ? p.Vl_cofins :
                                                                             p.St_totalnotaCofins.Trim().ToUpper().Equals("D") ? p.Vl_cofins * (-1) : decimal.Zero) +
                                                                             (p.St_totalnotaIPI.Trim().ToUpper().Equals("S") ? p.Vl_ipi :
                                                                             p.St_totalnotaIPI.Trim().ToUpper().Equals("D") ? p.Vl_ipi * (-1) : decimal.Zero) +
                                                                             (p.St_totalnotaISS.Trim().ToUpper().Equals("S") ? p.Vl_iss :
                                                                             p.St_totalnotaISS.Trim().ToUpper().Equals("D") ? p.Vl_iss * (-1) : decimal.Zero) +
                                                                             (p.St_totalnotaPIS.Trim().ToUpper().Equals("S") ? p.Vl_pis :
                                                                             p.St_totalnotaPIS.Trim().ToUpper().Equals("D") ? p.Vl_pis * (-1) : decimal.Zero)) +
                        val.Vl_acrescimo_fin - val.Vl_desconto_fin;
            return Math.Round(total, 2);
        }

        public static decimal CalcTotalNota(TRegistro_LanFaturamento val)
        {
            decimal total = decimal.Zero;
            if (val != null)
                total = val.ItensNota.Sum(p => p.Vl_subtotal -
                                               p.Vl_desconto +
                                               p.Vl_freteitem +
                                               p.Vl_juro_fin +
                                               p.Vl_seguro +
                                               p.Vl_outrasdesp +
                                               p.Vl_FCPST +
                                               p.Vl_ICMSST -
                                               p.Vl_ICMSRetido -
                                               p.Vl_retidoCofins -
                                               p.Vl_retidoCSLL -
                                               p.Vl_retidoFunrural -
                                               p.Vl_retidoINSS -
                                               p.Vl_retidoIRRF -
                                               p.Vl_retidoPIS -
                                               p.Vl_retidoSenar +
                                               (p.St_totalnotaCofins.Trim().ToUpper().Equals("S") ? p.Vl_cofins :
                                               p.St_totalnotaCofins.Trim().ToUpper().Equals("D") ? p.Vl_cofins * (-1) : decimal.Zero) +
                                               (p.St_totalnotaIPI.Trim().ToUpper().Equals("S") ? p.Vl_ipi :
                                               p.St_totalnotaIPI.Trim().ToUpper().Equals("D") ? p.Vl_ipi * (-1) : decimal.Zero) +
                                               (p.St_totalnotaISS.Trim().ToUpper().Equals("S") ? p.Vl_iss :
                                               p.St_totalnotaISS.Trim().ToUpper().Equals("D") ? p.Vl_iss * (-1) : decimal.Zero) +
                                               (p.St_totalnotaPIS.Trim().ToUpper().Equals("S") ? p.Vl_pis :
                                               p.St_totalnotaPIS.Trim().ToUpper().Equals("D") ? p.Vl_pis * (-1) : decimal.Zero));
            return Math.Round(total, 2);
        }

        public static decimal CalcTotalProdServ(TRegistro_LanFaturamento val)
        {
            decimal total = decimal.Zero;
            if (val != null)
                total = Math.Round(val.ItensNota.Sum(p => p.Vl_subtotal), 2);
            return total;
        }

        public static decimal CalcTotalImpCalc(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_icms +
                                              p.Vl_pis +
                                              p.Vl_cofins +
                                              p.Vl_ipi +
                                              p.VL_INSS +
                                              p.VL_IRRF +
                                              p.VL_CSLL +
                                              p.Vl_iss +
                                              p.Vl_funrural +
                                              p.Vl_senar +
                                              p.VL_IRRF +
                                              p.VL_CSLL +
                                              p.VL_INSS);
            else return decimal.Zero;
        }

        public static decimal CalcTotalBaseCalc(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_basecalcICMS);
            else return decimal.Zero;
        }

        public static decimal CalcTotalICMS(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_icms);
            else return decimal.Zero;
        }

        public static decimal CalcTotalICMSSubst(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_ICMSST);
            else return decimal.Zero;
        }

        public static decimal CalcTotalFCPST(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_FCPST);
            else return decimal.Zero;
        }

        public static decimal CalcTotalIPI(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_ipi);
            else return decimal.Zero;
        }

        public static decimal CalcTotalImpRet(TRegistro_LanFaturamento val)
        {
            if (val != null)
                return val.ItensNota.Sum(p => p.Vl_retidoCofins +
                                              p.Vl_retidoCSLL +
                                              p.Vl_retidoFunrural +
                                              p.Vl_retidoINSS +
                                              p.Vl_retidoIRRF +
                                              p.Vl_retidoPIS +
                                              p.Vl_retidoSenar +
                                              p.Vl_issretido +
                                              p.Vl_ICMSRetido);
            else return decimal.Zero;
        }

        public static decimal UltimaCompra(string Cd_empresa, string Cd_produto, TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_produto)))
            {
                CamadaDados.TDataQuery query = new CamadaDados.TDataQuery(banco);
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_CD_EMPRESA", Cd_empresa);
                hs.Add("@P_CD_PRODUTO", Cd_produto);
                return decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(query.executarProc("F_FAT_ULTIMACOMPRA", hs), "@RETURN_VALUE"));
            }
            else return decimal.Zero;
        }

        public static void ProcessarFisicoFiscal(TList_RegLanFaturamento lNf, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_fat = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                lNf.ForEach(p => GravarFaturamento(p, null, qtb_fat.Banco_Dados));
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar fisico/fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static TRegistro_LanFaturamento ProcessarXMLNFeEntrada(string Cd_empresa,
                                                                      string Cd_fornecedor,
                                                                      string Cd_endFornecedor,
                                                                      string Cd_condfiscal_clifor,
                                                                      string Tp_pessoa,
                                                                      string Cfg_pedido,
                                                                      string Tp_frete,
                                                                      string Nr_serie,
                                                                      string Cd_modelo,
                                                                      string Nr_notafiscal,
                                                                      string Dt_emissao,
                                                                      string Dt_entrada,
                                                                      string Chave_acesso,
                                                                      string Tp_duplicata,
                                                                      string Tp_docto,
                                                                      string Cd_condpgto,
                                                                      string Cd_historico,
                                                                      string Cd_cmi,
                                                                      bool St_financeiro,
                                                                      decimal Vl_acrescimo_fin,
                                                                      decimal Vl_desconto_fin,
                                                                      TRegistro_Pedido rPedido,
                                                                      List<TRegistro_ItensXMLNFe> lItens,
                                                                      TList_Parcelas lParc,
                                                                      TRegistro_LanDuplicata rDupVista,
                                                                      CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLancto,
                                                                      CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLanctoDel,
                                                                      TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_fat = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Buscar configuracao fiscal do pedido
                TList_CadCFGPedidoFiscal lCfgPed =
                    new TCD_CadCFGPedidoFiscal(qtb_fat.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + Cfg_pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "=",
                            vVL_Busca = "'NO'"
                        }
                    }, 1, string.Empty);
                if (lCfgPed.Count.Equals(0))
                    throw new Exception("Não existe configuração fiscal NORMAL para o tipo pedido " + Cfg_pedido.Trim());
                //Pedido
                TRegistro_Pedido rPed = new TRegistro_Pedido();
                //Verificar se existe Pedido existente
                if (rPedido == null)
                {
                    rPed.CD_Empresa = Cd_empresa;
                    rPed.CFG_Pedido = Cfg_pedido;
                    rPed.CD_Clifor = Cd_fornecedor;
                    rPed.CD_Endereco = Cd_endFornecedor;
                    rPed.CD_CondPGTO = Cd_condpgto;
                    rPed.TP_Movimento = lCfgPed[0].Tp_movimento;
                    rPed.St_registro = "P";
                    rPed.ST_Pedido = "P";
                    rPed.DT_Pedido = DateTime.Parse(Dt_entrada);
                    rPed.Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", Cd_empresa, qtb_fat.Banco_Dados);
                    rPed.Tp_frete = Tp_frete;
                }
                else
                    rPed = rPedido;
                lItens.ForEach(p =>
                    {
                        if (rPedido == null)
                        {
                            //Item Pedido
                            rPed.Pedido_Itens.Add(new TRegistro_LanPedido_Item()
                            {
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Cd_local = p.Cd_local,
                                Cd_unidade_valor = p.rProd.CD_Unidade,
                                Cd_unidade_est = p.rProd.CD_Unidade,
                                Quantidade = p.Quantidade,
                                Vl_unitario = p.Vl_unitario,
                                Vl_subtotal = p.Vl_subtotal,
                                Vl_freteitem = p.Vl_frete,
                                Vl_desc = p.Vl_desconto,
                                Vl_acrescimo = p.Vl_outrasdesp,
                                rItemXML = p,
                            });
                        }
                        else
                        {
                            if (rPed.Pedido_Itens.Exists(x => x.Cd_produto.Equals(p.Cd_produto)))
                                rPed.Pedido_Itens.Find(x => x.Cd_produto.Equals(p.Cd_produto)).rItemXML = p;
                            else
                                throw new Exception("Produto Nº" + p.Cd_produto.Trim() + " informado na importação é inexistente no Pedido!");
                        }
                        //Gravar configuracao produto x fornecedor
                        Estoque.Cadastros.TCN_Produto_X_Fornecedor.Gravar(
                            new TRegistro_Produto_X_Fornecedor()
                            {
                                Cd_fornecedor = rPed.CD_Clifor,
                                Cd_produto = p.Cd_produto,
                                Cd_unidade_fornec = p.Cd_unidade_fornec,
                                Codigo_fornecedor = p.Cd_produto_xml,
                                Cd_local = p.Cd_local
                            }, qtb_fat.Banco_Dados);
                    });
                //Gravar pedido
                if (rPedido == null)
                    TCN_Pedido.Grava_Pedido(rPed, qtb_fat.Banco_Dados);

                //Verificar se Item é consumo interno
                //Buscar Almoxarifado
                TList_CadAlmoxarifado lAlmox = new TCD_CadAlmoxarifado().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                                    "where x.id_almox = a.id_almox " +
                                                                    "and x.cd_empresa = '" + rPed.CD_Empresa.Trim() + "')"
                                                    }
                                                }, 0, string.Empty);
                rPed.Pedido_Itens.ForEach(p =>
                    {
                        if (new TCD_CadProduto(banco).ProdutoConsumoInterno(p.Cd_produto) && rPed.TP_Movimento.Trim().ToUpper().Equals("E"))
                        {
                            if (lAlmox.Count.Equals(0))
                                throw new Exception("Não existe almoxarifado configurado para a empresa " + 
                                    rPed.CD_Empresa.Trim() + "-" + rPed.Nm_Empresa);
                            TCN_AlocacaoItem.AlocarItem(
                                               new TRegistro_EntregaPedido()
                                               {
                                                   Nr_pedido = p.Nr_pedido,
                                                   Cd_produto = p.Cd_produto,
                                                   Id_pedidoitem = p.Id_pedidoitem,
                                                   Login = Parametros.pubLogin,
                                                   Qtd_entregue = p.Quantidade,
                                                   Dt_entrega = CamadaDados.UtilData.Data_Servidor(),
                                                   Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA ALOCACAO ITEM NO ALMOXARIFADO",
                                                   Id_almoxstr = lAlmox[0].Id_almoxString,
                                                   St_registro = "P"
                                               }
                                               , qtb_fat.Banco_Dados);
                        }
                    });
                //Gerar nota fiscal
                TRegistro_LanFaturamento rNf = new TRegistro_LanFaturamento();
                rNf.Cd_empresa = rPed.CD_Empresa;
                rNf.Cd_clifor = rPed.CD_Clifor;
                rNf.Cd_endereco = rPed.CD_Endereco;
                rNf.Cd_cmistring = !string.IsNullOrEmpty(Cd_cmi) ? Cd_cmi : lCfgPed[0].Cd_cmistring;
                rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNf.lCFGFiscal = lCfgPed;
                //Buscar uf empresa
                object uf = new CamadaDados.Diversos.TCD_CadEmpresa(qtb_fat.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rPed.CD_Empresa.Trim() + "'"
                                        }
                                    }, "c.cd_uf");
                if (uf != null)
                    rNf.Cd_uf_empresa = uf.ToString();
                //Buscar uf fornecedor
                uf = new TCD_CadEndereco(qtb_fat.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo= "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CD_Clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CD_Endereco.Trim() + "'"
                            }
                        }, "a.cd_uf");
                if(uf != null)
                    rNf.Cd_uf_clifor = uf.ToString();
                rNf.Cd_condfiscal_clifor = Cd_condfiscal_clifor;
                rNf.Tp_duplicata = Tp_duplicata;
                rNf.Cd_condpgto = Cd_condpgto;
                rNf.Nr_pedido = rPed.Nr_pedido;
                rNf.Tp_movimento = lCfgPed[0].Tp_movimento;
                rNf.Tp_pessoa = Tp_pessoa;
                rNf.Tp_nota = "T";
                rNf.Nr_serie = Nr_serie;
                rNf.Nr_notafiscalstr = Nr_notafiscal;
                rNf.Chave_acesso_nfe = Chave_acesso;
                rNf.Cd_modelo = Cd_modelo;
                rNf.St_sequenciaauto = false;
                rNf.Dt_emissao = DateTime.Parse(Dt_emissao);
                rNf.Dt_saient = DateTime.Parse(Dt_entrada);
                rNf.Tp_frete = Tp_frete;
                rNf.Vl_acrescimo_fin = Vl_acrescimo_fin;
                rNf.Vl_desconto_fin = Vl_desconto_fin;
                lItens.ForEach(item =>
                {
                    //Item da nota fiscal
                    TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                    rItem.Cd_empresa = rPed.CD_Empresa;
                    rItem.Cd_produto = item.Cd_produto;
                    rItem.Ds_produto = item.Ds_produto;
                    rItem.Cd_local = item.Cd_local;
                    rItem.Cd_condfiscal_produto = item.rProd.CD_CondFiscal_Produto;
                    rItem.Cd_unidade = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Cd_unidade_valor;
                    rItem.Cd_unidEst = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Cd_unidade_est;
                    rItem.Nr_pedido = rPed.Nr_pedido;
                    rItem.Id_pedidoitem = rPed.Pedido_Itens.Find(p=> p.Cd_produto.Equals(item.Cd_produto)).Id_pedidoitem;
                    rItem.Quantidade = item.Quantidade;
                    rItem.Vl_subtotal = item.Quantidade * (item.Vl_subtotal / item.Quantidade); ;
                    rItem.Vl_unitario = item.Vl_unitario;
                    rItem.Vl_desconto = item.Quantidade * (item.Vl_desconto / item.Quantidade);
                    rItem.Vl_freteitem = item.Quantidade * (item.Vl_frete / item.Quantidade);
                    rItem.Vl_juro_fin = item.Quantidade * (rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Vl_juro_fin / item.Quantidade);
                    rItem.Vl_outrasdesp = item.Quantidade * (item.Vl_outrasdesp / item.Quantidade); ;
                    rItem.Pc_imposto_Aprox = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Pc_imposto_Aprox;
                    rItem.Cd_cfop = item.Cfop;
                    rItem.lMov = item.lMov;
                    //Grade
                    item.lGrade.Where(v=> v.Vl_mov > decimal.Zero).ToList().ForEach(v => rItem.lGrade.Add(v));
                    //Impostos do item
                    if (item.lImpostos.Exists(v => v.Imposto.St_ICMS))
                        TCN_LanFaturamento_Item.PreencherICMS(item.lImpostos.Find(v => v.Imposto.St_ICMS), rItem);
                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(item.lImpostos, rItem, rNf.Tp_movimento);
                    rNf.ItensNota.Add(rItem);
                });
                //Duplicata á vista
                if (rDupVista != null && St_financeiro)
                    rNf.Duplicata.Add(rDupVista);
                //Duplicata da nota
                if (lParc != null && St_financeiro)
                    if ((lParc.Count > 0) && (!string.IsNullOrEmpty(Tp_duplicata)))
                    {
                        TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                        rDup.Cd_empresa = rPed.CD_Empresa;
                        rDup.Cd_historico = Cd_historico;
                        rDup.Tp_doctostring = Tp_docto;
                        rDup.Tp_duplicata = Tp_duplicata;
                        rDup.Cd_clifor = rPed.CD_Clifor;
                        rDup.Cd_endereco = rPed.CD_Endereco;
                        rDup.Cd_moeda = rPed.Cd_moeda;
                        rDup.DupCotacao.Cd_moedaresult = rPed.Cd_moeda;
                        rDup.Cd_condpgto = Cd_condpgto;
                        rDup.Nr_docto = Nr_notafiscal;
                        rDup.Vl_documento = lParc.Sum(p => p.Vl_parcela);
                        rDup.Vl_documento_padrao = rDup.Vl_documento;
                        rDup.Dt_emissao = DateTime.Parse(Dt_emissao);
                        rDup.Qt_parcelas = lParc.Count;
                        decimal cd_parcela = 1;
                        lParc.ForEach(v => rDup.Parcelas.Add(new TRegistro_LanParcela()
                        {
                            Cd_parcela = cd_parcela++,
                            Dt_vencto = v.Dt_vencimento,
                            Vl_parcela = v.Vl_parcela,
                            Vl_parcela_padrao = v.Vl_parcela
                        }));
                        rNf.Duplicata.Add(rDup);
                        rDup.lCustoLancto = lCustoLancto;
                        rDup.lCustoLanctoDel = lCustoLanctoDel;
                    }
                //Gravar Nota Fiscal
                GravarFaturamento(rNf, null, qtb_fat.Banco_Dados);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return rNf;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        //Processar XMLNFeEntrada com informações adicionais de frete/transportadora
        public static TRegistro_LanFaturamento ProcessarXMLNFeEntrada(string Cd_empresa,
                                                                      string Cd_fornecedor,
                                                                      string Cd_endFornecedor,
                                                                      string Cd_condfiscal_clifor,
                                                                      string Tp_pessoa,
                                                                      string Cfg_pedido,
                                                                      string Tp_frete,
                                                                      string Nr_serie,
                                                                      string Cd_modelo,
                                                                      string Nr_notafiscal,
                                                                      string Dt_emissao,
                                                                      string Dt_entrada,
                                                                      string Chave_acesso,
                                                                      string Tp_duplicata,
                                                                      string Tp_docto,
                                                                      string Cd_condpgto,
                                                                      string Cd_historico,
                                                                      string Cd_cmi,
                                                                      bool St_financeiro,
                                                                      decimal Vl_acrescimo_fin,
                                                                      decimal Vl_desconto_fin,
                                                                      TRegistro_LanFaturamento rFrete,
                                                                      TRegistro_Pedido rPedido,
                                                                      List<TRegistro_ItensXMLNFe> lItens,
                                                                      TList_Parcelas lParc,
                                                                      TRegistro_LanDuplicata rDupVista,
                                                                      CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLancto,
                                                                      CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCustoLanctoDel,
                                                                      TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_fat = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Buscar configuracao fiscal do pedido
                TList_CadCFGPedidoFiscal lCfgPed =
                    new TCD_CadCFGPedidoFiscal(qtb_fat.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + Cfg_pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "=",
                            vVL_Busca = "'NO'"
                        }
                    }, 1, string.Empty);
                if (lCfgPed.Count.Equals(0))
                    throw new Exception("Não existe configuração fiscal NORMAL para o tipo pedido " + Cfg_pedido.Trim());
                //Pedido
                TRegistro_Pedido rPed = new TRegistro_Pedido();
                //Verificar se existe Pedido existente
                if (rPedido == null)
                {
                    rPed.CD_Empresa = Cd_empresa;
                    rPed.CFG_Pedido = Cfg_pedido;
                    rPed.CD_Clifor = Cd_fornecedor;
                    rPed.CD_Endereco = Cd_endFornecedor;
                    rPed.CD_CondPGTO = Cd_condpgto;
                    rPed.TP_Movimento = lCfgPed[0].Tp_movimento;
                    rPed.St_registro = "P";
                    rPed.ST_Pedido = "P";
                    rPed.DT_Pedido = DateTime.Parse(Dt_entrada);
                    rPed.Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", Cd_empresa, qtb_fat.Banco_Dados);
                    rPed.Tp_frete = Tp_frete;
                }
                else
                    rPed = rPedido;
                lItens.ForEach(p =>
                {
                    if (rPedido == null)
                    {
                        //Item Pedido
                        rPed.Pedido_Itens.Add(new TRegistro_LanPedido_Item()
                        {
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Cd_local = p.Cd_local,
                            Cd_unidade_valor = p.rProd.CD_Unidade,
                            Cd_unidade_est = p.rProd.CD_Unidade,
                            Quantidade = p.Quantidade,
                            Vl_unitario = p.Vl_unitario,
                            Vl_subtotal = p.Vl_subtotal,
                            Vl_freteitem = p.Vl_frete,
                            Vl_desc = p.Vl_desconto,
                            Vl_acrescimo = p.Vl_outrasdesp,
                            rItemXML = p,
                        });
                    }
                    else
                    {
                        if (rPed.Pedido_Itens.Exists(x => x.Cd_produto.Equals(p.Cd_produto)))
                            rPed.Pedido_Itens.Find(x => x.Cd_produto.Equals(p.Cd_produto)).rItemXML = p;
                        else
                            throw new Exception("Produto Nº" + p.Cd_produto.Trim() + " informado na importação é inexistente no Pedido!");
                    }
                    //Gravar configuracao produto x fornecedor
                    Estoque.Cadastros.TCN_Produto_X_Fornecedor.Gravar(
                        new TRegistro_Produto_X_Fornecedor()
                        {
                            Cd_fornecedor = rPed.CD_Clifor,
                            Cd_produto = p.Cd_produto,
                            Cd_unidade_fornec = p.Cd_unidade_fornec,
                            Codigo_fornecedor = p.Cd_produto_xml,
                            Cd_local = p.Cd_local
                        }, qtb_fat.Banco_Dados);
                });
                //Gravar pedido
                if (rPedido == null)
                    TCN_Pedido.Grava_Pedido(rPed, qtb_fat.Banco_Dados);

                //Verificar se Item é consumo interno
                //Buscar Almoxarifado
                TList_CadAlmoxarifado lAlmox = new TCD_CadAlmoxarifado().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                                    "where x.id_almox = a.id_almox " +
                                                                    "and x.cd_empresa = '" + rPed.CD_Empresa.Trim() + "')"
                                                    }
                                                }, 0, string.Empty);
                rPed.Pedido_Itens.ForEach(p =>
                {
                    if (new TCD_CadProduto(banco).ProdutoConsumoInterno(p.Cd_produto) && rPed.TP_Movimento.Trim().ToUpper().Equals("E"))
                    {
                        if (lAlmox.Count.Equals(0))
                            throw new Exception("Não existe almoxarifado configurado para a empresa " +
                                rPed.CD_Empresa.Trim() + "-" + rPed.Nm_Empresa);
                        TCN_AlocacaoItem.AlocarItem(
                                           new TRegistro_EntregaPedido()
                                           {
                                               Nr_pedido = p.Nr_pedido,
                                               Cd_produto = p.Cd_produto,
                                               Id_pedidoitem = p.Id_pedidoitem,
                                               Login = Parametros.pubLogin,
                                               Qtd_entregue = p.Quantidade,
                                               Dt_entrega = CamadaDados.UtilData.Data_Servidor(),
                                               Ds_observacao = "ENTREGA GRAVADA AUTOMATICAMENTE PELA ALOCACAO ITEM NO ALMOXARIFADO",
                                               Id_almoxstr = lAlmox[0].Id_almoxString,
                                               St_registro = "P"
                                           }
                                           , qtb_fat.Banco_Dados);
                    }
                });
                //Gerar nota fiscal
                TRegistro_LanFaturamento rNf = new TRegistro_LanFaturamento();
                rNf.Cd_empresa = rPed.CD_Empresa;
                rNf.Cd_clifor = rPed.CD_Clifor;
                rNf.Cd_endereco = rPed.CD_Endereco;
                rNf.Cd_cmistring = !string.IsNullOrEmpty(Cd_cmi) ? Cd_cmi : lCfgPed[0].Cd_cmistring;
                rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                rNf.lCFGFiscal = lCfgPed;
                //Frete
                rNf.Cpf_transp = rFrete.Cpf_transp;
                rNf.Insc_estadualtransp = rFrete.Insc_estadualtransp;
                rNf.Quantidade = rFrete.Quantidade;
                rNf.Especie = rFrete.Especie;
                rNf.Marca = rFrete.Marca;
                rNf.Pesoliquido = rFrete.Pesoliquido;
                rNf.Pesobruto = rFrete.Pesobruto;
                //Buscar uf empresa
                object uf = new CamadaDados.Diversos.TCD_CadEmpresa(qtb_fat.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rPed.CD_Empresa.Trim() + "'"
                                        }
                                    }, "c.cd_uf");
                if (uf != null)
                    rNf.Cd_uf_empresa = uf.ToString();
                //Buscar uf fornecedor
                uf = new TCD_CadEndereco(qtb_fat.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo= "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CD_Clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CD_Endereco.Trim() + "'"
                            }
                        }, "a.cd_uf");
                if (uf != null)
                    rNf.Cd_uf_clifor = uf.ToString();
                rNf.Cd_condfiscal_clifor = Cd_condfiscal_clifor;
                rNf.Tp_duplicata = Tp_duplicata;
                rNf.Cd_condpgto = Cd_condpgto;
                rNf.Nr_pedido = rPed.Nr_pedido;
                rNf.Tp_movimento = lCfgPed[0].Tp_movimento;
                rNf.Tp_pessoa = Tp_pessoa;
                rNf.Tp_nota = "T";
                rNf.Nr_serie = Nr_serie;
                rNf.Nr_notafiscalstr = Nr_notafiscal;
                rNf.Chave_acesso_nfe = Chave_acesso;
                rNf.Cd_modelo = Cd_modelo;
                rNf.St_sequenciaauto = false;
                rNf.Dt_emissao = DateTime.Parse(Dt_emissao);
                rNf.Dt_saient = DateTime.Parse(Dt_entrada);
                rNf.Tp_frete = Tp_frete;
                rNf.Vl_acrescimo_fin = Vl_acrescimo_fin;
                rNf.Vl_desconto_fin = Vl_desconto_fin;
                lItens.ForEach(item =>
                {
                    //Item da nota fiscal
                    TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                    rItem.Cd_empresa = rPed.CD_Empresa;
                    rItem.Cd_produto = item.Cd_produto;
                    rItem.Ds_produto = item.Ds_produto;
                    rItem.Cd_local = item.Cd_local;
                    rItem.Cd_condfiscal_produto = item.rProd.CD_CondFiscal_Produto;
                    rItem.Cd_unidade = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Cd_unidade_valor;
                    rItem.Cd_unidEst = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Cd_unidade_est;
                    rItem.Nr_pedido = rPed.Nr_pedido;
                    rItem.Id_pedidoitem = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Id_pedidoitem;
                    rItem.Quantidade = item.Quantidade;
                    rItem.Vl_subtotal = item.Quantidade * (item.Vl_subtotal / item.Quantidade); ;
                    rItem.Vl_unitario = item.Vl_unitario;
                    rItem.Vl_desconto = item.Quantidade * (item.Vl_desconto / item.Quantidade);
                    rItem.Vl_freteitem = item.Quantidade * (item.Vl_frete / item.Quantidade);
                    rItem.Vl_juro_fin = item.Quantidade * (rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Vl_juro_fin / item.Quantidade);
                    rItem.Vl_outrasdesp = item.Quantidade * (item.Vl_outrasdesp / item.Quantidade); ;
                    rItem.Pc_imposto_Aprox = rPed.Pedido_Itens.Find(p => p.Cd_produto.Equals(item.Cd_produto)).Pc_imposto_Aprox;
                    rItem.Cd_cfop = item.Cfop;
                    rItem.lMov = item.lMov;
                    //Grade
                    item.lGrade.Where(v => v.Vl_mov > decimal.Zero).ToList().ForEach(v => rItem.lGrade.Add(v));
                    //Impostos do item
                    if (item.lImpostos.Exists(v => v.Imposto.St_ICMS))
                        TCN_LanFaturamento_Item.PreencherICMS(item.lImpostos.Find(v => v.Imposto.St_ICMS), rItem);
                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(item.lImpostos, rItem, rNf.Tp_movimento);
                    rNf.ItensNota.Add(rItem);
                });
                //Duplicata á vista
                if (rDupVista != null && St_financeiro)
                    rNf.Duplicata.Add(rDupVista);
                //Duplicata da nota
                if (lParc != null && St_financeiro)
                    if ((lParc.Count > 0) && (!string.IsNullOrEmpty(Tp_duplicata)))
                    {
                        TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                        rDup.Cd_empresa = rPed.CD_Empresa;
                        rDup.Cd_historico = Cd_historico;
                        rDup.Tp_doctostring = Tp_docto;
                        rDup.Tp_duplicata = Tp_duplicata;
                        rDup.Cd_clifor = rPed.CD_Clifor;
                        rDup.Cd_endereco = rPed.CD_Endereco;
                        rDup.Cd_moeda = rPed.Cd_moeda;
                        rDup.DupCotacao.Cd_moedaresult = rPed.Cd_moeda;
                        rDup.Cd_condpgto = Cd_condpgto;
                        rDup.Nr_docto = Nr_notafiscal;
                        rDup.Vl_documento = lParc.Sum(p => p.Vl_parcela);
                        rDup.Vl_documento_padrao = rDup.Vl_documento;
                        rDup.Dt_emissao = DateTime.Parse(Dt_emissao);
                        rDup.Qt_parcelas = lParc.Count;
                        decimal cd_parcela = 1;
                        lParc.ForEach(v => rDup.Parcelas.Add(new TRegistro_LanParcela()
                        {
                            Cd_parcela = cd_parcela++,
                            Dt_vencto = v.Dt_vencimento,
                            Vl_parcela = v.Vl_parcela,
                            Vl_parcela_padrao = v.Vl_parcela
                        }));
                        rNf.Duplicata.Add(rDup);
                        rDup.lCustoLancto = lCustoLancto;
                        rDup.lCustoLanctoDel = lCustoLanctoDel;
                    }
                //Gravar Nota Fiscal
                GravarFaturamento(rNf, null, qtb_fat.Banco_Dados);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return rNf;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static void ProcessarXMLNFePropria(TRegistro_LanFaturamento nfe, 
                                                  TRegistro_CFGVendasExterna rCfg,
                                                  TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento qtb_fat = new TCD_LanFaturamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else qtb_fat.Banco_Dados = banco;
                if (string.IsNullOrWhiteSpace(rCfg.Cfg_pedido))
                    throw new Exception("Não existe pedido configurado para processar XML Vendas Externa.");
                //Buscar CFG Pedido
                //Buscar configuracao fiscal do pedido
                TList_CadCFGPedidoFiscal lCfgPed =
                    new TCD_CadCFGPedidoFiscal(qtb_fat.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + rCfg.Cfg_pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "=",
                            vVL_Busca = "'NO'"
                        }
                    }, 1, string.Empty);
                if (lCfgPed.Count.Equals(0))
                    throw new Exception("Não existe configuração fiscal NORMAL para o tipo pedido " + rCfg.Cfg_pedido.Trim());
                //Pedido
                TRegistro_Pedido rPed = new TRegistro_Pedido();
                rPed.CD_Empresa = nfe.Cd_empresa;
                rPed.CFG_Pedido = rCfg.Cfg_pedido;
                rPed.CD_Clifor = nfe.Cd_clifor;
                rPed.CD_Endereco = nfe.Cd_endereco;
                rPed.CD_CondPGTO = nfe.Cd_condpgto;
                rPed.TP_Movimento = lCfgPed[0].Tp_movimento;
                rPed.St_registro = "P";
                rPed.ST_Pedido = "P";
                rPed.DT_Pedido = nfe.Dt_emissao;
                rPed.Cd_moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", nfe.Cd_empresa, qtb_fat.Banco_Dados);
                rPed.Tp_frete = nfe.Freteporconta;
                nfe.ItensNota.ForEach(p =>
                {
                    //Item Pedido
                    rPed.Pedido_Itens.Add(new TRegistro_LanPedido_Item()
                    {
                        Cd_produto = p.Cd_produto,
                        Ds_produto = p.Ds_produto,
                        Cd_local = p.Cd_local,
                        Cd_unidade_valor = p.Cd_unidade,
                        Cd_unidade_est = p.Cd_unidade,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_subtotal = p.Vl_subtotal,
                        Vl_freteitem = p.Vl_freteitem,
                        Vl_desc = p.Vl_desconto,
                        Vl_acrescimo = p.Vl_outrasdesp
                    });
                });
                //Gravar pedido
                TCN_Pedido.Grava_Pedido(rPed, qtb_fat.Banco_Dados);
                //Gravar Nota
                nfe.Nr_pedido = rPed.Nr_pedido;
                nfe.Cd_movimentacao = lCfgPed[0].Cd_movto;
                nfe.Cd_cmi = lCfgPed[0].Cd_cmi;
                nfe.Tp_movimento = "S";
                nfe.ItensNota.ForEach(x =>
                {
                    x.Nr_pedido = rPed.Nr_pedido;
                    x.Id_pedidoitem = nfe.ItensNota.IndexOf(x) + 1;
                });
                GravarFaturamento(nfe, null, qtb_fat.Banco_Dados);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar XML: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }
    }
}
