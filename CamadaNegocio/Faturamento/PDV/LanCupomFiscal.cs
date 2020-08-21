using System;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Faturamento.PDV;
using System.IO;
using Utils;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Adiantamento;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Titulo;
using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaDados.Financeiro.Titulo;
using CamadaNegocio.Financeiro.CCustoLan;
using CamadaDados.Financeiro.CCustoLan;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Contabil;
using CamadaDados.Contabil;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_VendaRapida
    {
        public static TList_VendaRapida Buscar(string Id_vendarapida,
                                               string Cd_empresa,
                                               string Cd_vendedor,
                                               string Id_pdv,
                                               string Nm_clifor,
                                               string Dt_ini,
                                               string Dt_fin,
                                               decimal Vl_ini,
                                               decimal Vl_fin,
                                               string Cd_produto,
                                               string Nr_requisicao,
                                               string Id_locacao,
                                               string St_registro,
                                               int vTop,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_vendarapida))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vendarapida;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_clifor.Trim() + "%')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /       :") && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Dt_ini + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /       :") && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + (Dt_fin) + "'";
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(select ISNULL(SUM(ISNULL(x.Vl_SubTotal, 0) + ISNULL(x.Vl_Acrescimo, 0) - ISNULL(x.Vl_Desconto, 0)), 0) " +
                                                      "from TB_PDV_VendaRapida_Item x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.Id_VendaRapida = a.Id_VendaRapida " +
                                                      "and ISNULL(x.ST_Registro, 'A') <> 'C') >= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(select ISNULL(SUM(ISNULL(x.Vl_SubTotal, 0) + ISNULL(x.Vl_Acrescimo, 0) - ISNULL(x.Vl_Desconto, 0)), 0) " +
                                                      "from TB_PDV_VendaRapida_Item x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.Id_VendaRapida = a.Id_VendaRapida " +
                                                      "and ISNULL(x.ST_Registro, 'A') <> 'C') <= " + Vl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_vendarapida_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_vendarapida = a.id_vendarapida " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Nr_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_requisicao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_LOC_Locacao x " +
                                                      "inner join TB_LOC_Itens_X_PreVenda y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_locacao = y.id_locacao " +
                                                      "inner join TB_PDV_PreVenda_X_VendaRapida h " +
                                                      "on h.cd_empresa = y.cd_empresa " +
                                                      "and h.id_prevenda = y.id_prevenda " +
                                                      "and h.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                                      "where h.cd_empresa = a.cd_empresa " +
                                                      "and h.id_cupom = a.id_cupom " +
                                                      "and x.id_locacao = " + Id_locacao + ") ";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_VendaRapida(banco).Select(filtro, vTop, string.Empty, string.Empty);
        }



        public static string Gravar(TRegistro_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_cupom = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                val.Id_vendarapidastr = CamadaDados.TDataQuery.getPubVariavel(qtb_cupom.Gravar(val), "@P_ID_VENDARAPIDA");
                val.lItem.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_vendarapida = val.Id_vendarapida;
                        if (string.IsNullOrEmpty(p.Cd_vendedor))
                            p.Cd_vendedor = val.Cd_vend;
                        p.Cd_representante = val.Cd_representante;
                        TCN_VendaRapida_Item.Gravar(p, qtb_cupom.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
                return val.Id_vendarapidastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }

        public static void GravarVendaRapida(TRegistro_VendaRapida val,
                                             List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVendaComb,
                                             TRegistro_LanFaturamento rNfEntregaF,
                                             BancoDados.TObjetoBanco banco)
        {
            val.Dt_emissao = CamadaDados.UtilData.Data_Servidor(banco);
            bool st_movestoque = new TCD_CFGCupomFiscal(banco).BuscarEscalar(
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
                                                vNM_Campo = "isnull(a.st_movestoque, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "1") != null;
            bool st_transacao = false;
            TCD_VendaRapida qtb_cf = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Gravar Venda
                Gravar(val, qtb_cf.Banco_Dados);
                //Gravar Itens Venda
                val.lItem.ForEach(p =>
                    {
                        p.Id_vendarapida = val.Id_vendarapida;
                        p.Cd_empresa = val.Cd_empresa;
                        if (string.IsNullOrEmpty(p.Cd_vendedor))
                            p.Cd_vendedor = val.Cd_vend;
                        p.Cd_representante = val.Cd_representante;
                        TCN_VendaRapida_Item.Gravar(p,
                                                    (st_movestoque ? (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_cf.Banco_Dados).ItemServico(p.Cd_produto)) &&
                                                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_cf.Banco_Dados).ProdutoConsumoInterno(p.Cd_produto)) : false),
                                                    qtb_cf.Banco_Dados);
                    });
                //grava restaurante 
                //todo aqui gerar itens prevenda x itens cupom
                CamadaDados.Restaurante.TList_ItensPreVenda_X_ItensCupom rItemPrevendaItemCupom = new CamadaDados.Restaurante.TList_ItensPreVenda_X_ItensCupom();
                if (val.st_restaurante)
                {
                    val.lItem.ForEach(p =>
                    {
                        CamadaDados.Restaurante.TRegistro_ItensPreVenda_X_ItensCupom item = new CamadaDados.Restaurante.TRegistro_ItensPreVenda_X_ItensCupom();
                        item.Cd_Empresa = val.Cd_empresa;
                        item.Id_VendaRapida = val.Id_vendarapida.Value;
                        item.Id_LanctoVenda = p.Id_lanctovenda.Value;
                        item.Id_Item = p.id_item;
                        item.Id_PreVenda = p.id_prevenda;
                        rItemPrevendaItemCupom = CamadaNegocio.Restaurante.TCN_ItensPreVenda_X_ItensCupom.Buscar(item.Cd_Empresa,
                                                                                                                 item.Id_PreVenda.ToString(),
                                                                                                                 string.Empty,
                                                                                                                 string.Empty,
                                                                                                                 item.Id_Item.ToString(),
                                                                                                                 qtb_cf.Banco_Dados);
                        if (rItemPrevendaItemCupom.Count > 0)
                        {
                            item.Id_NFCE = rItemPrevendaItemCupom[0].Id_NFCE;
                            item.Id_LanctoNFCe = rItemPrevendaItemCupom[0].Id_LanctoNFCe;
                            item.Id_Registro = rItemPrevendaItemCupom[0].Id_Registro;
                        }

                        Restaurante.TCN_ItensPreVenda_X_ItensCupom.Gravar(item, qtb_cf.Banco_Dados);
                    });
                }
                //Fechar Venda
                if ((val.lPortador != null) &&
                    (new TCD_Cupom_X_MovCaixa(qtb_cf.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapidastr
                        }
                    }, "1") == null))
                    FecharVenda(val, null, qtb_cf.Banco_Dados);
                if (lVendaComb != null)
                    lVendaComb.ForEach(p =>
                        {
                            PostoCombustivel.TCN_VendaCombustivel.Gravar(p, qtb_cf.Banco_Dados);
                            //Gravar pontos fidelizacao
                            if (p.rPontosFid != null)
                            {
                                p.rPontosFid.Id_cupom = val.Id_vendarapida;
                                Fidelizacao.TCN_PontosFidelidade.Gravar(p.rPontosFid, qtb_cf.Banco_Dados);
                            }
                        });
                if (val.lItem.Exists(p => p.rItemOrcamento != null))
                {
                    CamadaDados.Faturamento.Orcamento.TList_Orcamento lOrc =
                        new CamadaDados.Faturamento.Orcamento.TCD_Orcamento(qtb_cf.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_orcamento",
                                vOperador = "=",
                                vVL_Busca = val.lItem.Find(p=> p.rItemOrcamento != null).rItemOrcamento.Nr_orcamento.Value.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from vtb_fat_orcamento_item x " +
                                            "where x.nr_orcamento = a.nr_orcamento " +
                                            "and x.quantidade - x.qtd_faturada > 0)"
                            }
                        }, 1, string.Empty);
                    if (lOrc.Count > 0)
                    {
                        lOrc[0].lParcelas = Orcamento.TCN_Orcamento_DT_Vencto.Buscar(lOrc[0].Nr_orcamentostr, qtb_cf.Banco_Dados);
                        lOrc[0].St_registro = "FT";//Faturado
                        Orcamento.TCN_Orcamento.Gravar(lOrc[0], qtb_cf.Banco_Dados);
                    }
                }
                if (rNfEntregaF != null)
                {
                    //Gravar nota entrega futura
                    NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNfEntregaF, null, qtb_cf.Banco_Dados);
                    //Amarrar venda a nota
                    TCN_VendaRapida_X_EntregaFutura.Gravar(new TRegistro_VendaRapida_X_EntregaFutura()
                    {
                        Cd_empresa = rNfEntregaF.Cd_empresa,
                        Nr_lanctofiscal = rNfEntregaF.Nr_lanctofiscal,
                        Id_nfitem = rNfEntregaF.ItensNota[0].Id_nfitem,
                        Id_cupom = val.Id_vendarapida,
                        Id_lancto = val.lItem[0].Id_lanctovenda
                    }, qtb_cf.Banco_Dados);
                }
                //Resgatar Pontos Fidelidade
                if (val.lItem.Exists(p => p.Qt_pontosutilizados > decimal.Zero))
                {
                    //Buscar listagem de pontos com saldo a recuperar
                    CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lPontos =
                        new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade(qtb_cf.Banco_Dados).Select(
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
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                        }, 0, string.Empty, string.Empty);
                    val.lItem.Where(p => p.Qt_pontosutilizados > decimal.Zero).ToList().ForEach(p =>
                    {
                        decimal pontos_resgatar = p.Qt_pontosutilizados;
                        decimal pontos = decimal.Zero;
                        DateTime dt_atual = CamadaDados.UtilData.Data_Servidor(qtb_cf.Banco_Dados);
                        foreach (CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto in lPontos.OrderBy(v => v.Dt_registro).ToList())
                        {
                            if (pontos_resgatar > decimal.Zero)
                            {
                                pontos = pontos_resgatar < rPonto.SD_Pontos ? pontos_resgatar : rPonto.SD_Pontos;
                                Fidelizacao.TCN_ResgatePontos.Gravar(
                                    new CamadaDados.Faturamento.Fidelizacao.TRegistro_ResgatePontos()
                                    {
                                        Cd_empresa = rPonto.Cd_empresa,
                                        Id_ponto = rPonto.Id_ponto,
                                        Login = Parametros.pubLogin,
                                        Qt_pontos = pontos,
                                        Dt_resgate = dt_atual,
                                        Id_cupom = val.Id_vendarapida,
                                        Id_lancto = p.Id_lanctovenda,
                                        St_registro = "A"
                                    }, qtb_cf.Banco_Dados);
                                pontos_resgatar -= pontos;
                                rPonto.Pontos_res += pontos;
                            }
                            else break;
                        }
                    });
                }
                //Gerar Pontos Fidelizacao
                if (string.IsNullOrEmpty(val.Cd_clifor) ? false :
                    val.Cd_clifor.Trim() != new TCD_CFGCupomFiscal(qtb_cf.Banco_Dados).BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                    },
                                                }, "a.cd_clifor").ToString())
                {
                    CamadaDados.Faturamento.Fidelizacao.TList_ProgFidelidade lProg =
                    Fidelizacao.TCN_ProgFidelidade.Buscar(val.Cd_empresa, qtb_cf.Banco_Dados);
                    if (lProg.Count > 0)
                    {
                        if (lProg[0].Tp_vl_pc.Trim().ToUpper().Equals("V")) //Valor
                        {

                            decimal base_calc = val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor;
                            //Gravar pontos cliente
                            CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                            rPonto.Cd_empresa = val.Cd_empresa;
                            rPonto.Cd_clifor = val.Cd_clifor;
                            rPonto.Id_cupom = val.Id_vendarapida;
                            rPonto.Dt_registro = val.Dt_emissao;
                            if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                            rPonto.Qt_pontos = (val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor) * lProg[0].Qt_pontos;
                            rPonto.St_registro = "A";
                            Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            if (!string.IsNullOrEmpty(val.Cd_cliforInd) && (lProg[0].Qt_pontosind > decimal.Zero))
                            {
                                rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                                rPonto.Cd_empresa = val.Cd_empresa;
                                rPonto.Cd_clifor = val.Cd_cliforInd;
                                rPonto.Id_cupom = val.Id_vendarapida;
                                rPonto.Dt_registro = val.Dt_emissao;
                                if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                    rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                                rPonto.Qt_pontos = (val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor) * lProg[0].Qt_pontosind;
                                rPonto.St_registro = "A";
                                Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            }
                        }
                        else //Percentual
                        {
                            //Gravar Pontos Cliente
                            CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                            rPonto.Cd_empresa = val.Cd_empresa;
                            rPonto.Cd_clifor = val.Cd_clifor;
                            rPonto.Id_cupom = val.Id_vendarapida;
                            rPonto.Dt_registro = val.Dt_emissao;
                            if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                            rPonto.Qt_pontos = Math.Round(decimal.Divide(decimal.Multiply(val.lItem.Sum(p => p.Vl_subtotalliquido), lProg[0].Qt_pontos), 100), 2);
                            rPonto.St_registro = "A";
                            Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            if (!string.IsNullOrEmpty(val.Cd_cliforInd) && (lProg[0].Qt_pontosind > decimal.Zero))
                            {
                                rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                                rPonto.Cd_empresa = val.Cd_empresa;
                                rPonto.Cd_clifor = val.Cd_cliforInd;
                                rPonto.Id_cupom = val.Id_vendarapida;
                                rPonto.Dt_registro = val.Dt_emissao;
                                if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                    rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                                rPonto.Qt_pontos = Math.Round(decimal.Divide(decimal.Multiply(val.lItem.Sum(p => p.Vl_subtotalliquido), lProg[0].Qt_pontosind), 100), 2);
                                rPonto.St_registro = "A";
                                Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            }
                        }
                    }
                }
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static void GravarCup(TRegistro_VendaRapida val,
                                     List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVendaComb,
                                     CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfEntregaF,
                                     ThreadEspera tEspera,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_cf = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Gravar Venda
                if (tEspera != null)
                    tEspera.Msg("Gravando Venda Rapida...");
                val.Dt_emissao = CamadaDados.UtilData.Data_Servidor(qtb_cf.Banco_Dados);
                //Gravar Itens Venda
                bool st_movestoque = new TCD_CFGCupomFiscal(qtb_cf.Banco_Dados).BuscarEscalar(
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
                                                vNM_Campo = "isnull(a.st_movestoque, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "1") != null;
                if (tEspera != null)
                    tEspera.Msg("Gravando itens Venda...");
                //Fechar Venda
                if (tEspera != null)
                    tEspera.Msg("Gravando financeiro Venda...");
                if ((val.lPortador != null) && (new TCD_Cupom_X_MovCaixa(qtb_cf.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "a.id_cupom",
                                vOperador = "=",
                                vVL_Busca = val.Id_vendarapidastr
                            }
                        }, "1") == null)
                    )
                    if (lVendaComb != null)
                        lVendaComb.ForEach(p =>
                        {
                            PostoCombustivel.TCN_VendaCombustivel.Gravar(p, qtb_cf.Banco_Dados);
                            //Gravar pontos fidelizacao
                            if (p.rPontosFid != null)
                            {
                                p.rPontosFid.Id_cupom = val.Id_vendarapida;
                                Fidelizacao.TCN_PontosFidelidade.Gravar(p.rPontosFid, qtb_cf.Banco_Dados);
                            }
                        });
                if (val.lItem.Exists(p => p.rItemOrcamento != null))
                {
                    CamadaDados.Faturamento.Orcamento.TList_Orcamento lOrc =
                        new CamadaDados.Faturamento.Orcamento.TCD_Orcamento(qtb_cf.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_orcamento",
                                vOperador = "=",
                                vVL_Busca = val.lItem.Find(p=> p.rItemOrcamento != null).rItemOrcamento.Nr_orcamento.Value.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from vtb_fat_orcamento_item x " +
                                            "where x.nr_orcamento = a.nr_orcamento " +
                                            "and x.quantidade - x.qtd_faturada > 0)"
                            }
                        }, 1, string.Empty);
                    if (lOrc.Count > 0)
                    {
                        lOrc[0].lParcelas = Orcamento.TCN_Orcamento_DT_Vencto.Buscar(lOrc[0].Nr_orcamentostr, qtb_cf.Banco_Dados);
                        lOrc[0].St_registro = "FT";//Faturado
                        Orcamento.TCN_Orcamento.Gravar(lOrc[0], qtb_cf.Banco_Dados);
                    }
                }
                if (rNfEntregaF != null)
                {
                    if (tEspera != null)
                        tEspera.Msg("Gravando Nota Entrega Futura...");
                    //Gravar nota entrega futura
                    NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNfEntregaF, tEspera, qtb_cf.Banco_Dados);
                    //Amarrar venda a nota
                    TCN_VendaRapida_X_EntregaFutura.Gravar(new TRegistro_VendaRapida_X_EntregaFutura()
                    {
                        Cd_empresa = rNfEntregaF.Cd_empresa,
                        Nr_lanctofiscal = rNfEntregaF.Nr_lanctofiscal,
                        Id_nfitem = rNfEntregaF.ItensNota[0].Id_nfitem,
                        Id_cupom = val.Id_vendarapida,
                        Id_lancto = val.lItem[0].Id_lanctovenda
                    }, qtb_cf.Banco_Dados);
                }
                //Resgatar Pontos Fidelidade
                if (val.lItem.Exists(p => p.Qt_pontosutilizados > decimal.Zero))
                {
                    //Buscar listagem de pontos com saldo a recuperar
                    CamadaDados.Faturamento.Fidelizacao.TList_PontosFidelidade lPontos =
                        new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade(qtb_cf.Banco_Dados).Select(
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
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = string.Empty,
                                        vVL_Busca = "a.dt_validade is null or convert(datetime, floor(convert(decimal(30,10), a.dt_validade))) >= convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                        }, 0, string.Empty, string.Empty);
                    val.lItem.Where(p => p.Qt_pontosutilizados > decimal.Zero).ToList().ForEach(p =>
                    {
                        decimal pontos_resgatar = p.Qt_pontosutilizados;
                        decimal pontos = decimal.Zero;
                        DateTime dt_atual = CamadaDados.UtilData.Data_Servidor(qtb_cf.Banco_Dados);
                        foreach (CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto in lPontos.OrderBy(v => v.Dt_registro).ToList())
                        {
                            if (pontos_resgatar > decimal.Zero)
                            {
                                pontos = pontos_resgatar < rPonto.SD_Pontos ? pontos_resgatar : rPonto.SD_Pontos;
                                Fidelizacao.TCN_ResgatePontos.Gravar(
                                    new CamadaDados.Faturamento.Fidelizacao.TRegistro_ResgatePontos()
                                    {
                                        Cd_empresa = rPonto.Cd_empresa,
                                        Id_ponto = rPonto.Id_ponto,
                                        Login = Parametros.pubLogin,
                                        Qt_pontos = pontos,
                                        Dt_resgate = dt_atual,
                                        Id_cupom = val.Id_vendarapida,
                                        Id_lancto = p.Id_lanctovenda,
                                        St_registro = "A"
                                    }, qtb_cf.Banco_Dados);
                                pontos_resgatar -= pontos;
                                rPonto.Pontos_res += pontos;
                            }
                            else break;
                        }
                    });
                }
                //Gerar Pontos Fidelizacao
                if (string.IsNullOrEmpty(val.Cd_clifor) ? false :
                    val.Cd_clifor.Trim() != new TCD_CFGCupomFiscal(qtb_cf.Banco_Dados).BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                    },
                                                }, "a.cd_clifor").ToString())
                {
                    CamadaDados.Faturamento.Fidelizacao.TList_ProgFidelidade lProg = Fidelizacao.TCN_ProgFidelidade.Buscar(val.Cd_empresa, qtb_cf.Banco_Dados);
                    if (lProg.Count > 0)
                    {
                        if (lProg[0].Tp_vl_pc.Trim().ToUpper().Equals("V")) //Valor
                        {

                            decimal base_calc = val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor;
                            //Gravar pontos cliente
                            CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                            rPonto.Cd_empresa = val.Cd_empresa;
                            rPonto.Cd_clifor = val.Cd_clifor;
                            rPonto.Id_cupom = val.Id_vendarapida;
                            rPonto.Dt_registro = val.Dt_emissao;
                            if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                            rPonto.Qt_pontos = (val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor) * lProg[0].Qt_pontos;
                            rPonto.St_registro = "A";
                            Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            if (!string.IsNullOrEmpty(val.Cd_cliforInd) && (lProg[0].Qt_pontosind > decimal.Zero))
                            {
                                rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                                rPonto.Cd_empresa = val.Cd_empresa;
                                rPonto.Cd_clifor = val.Cd_cliforInd;
                                rPonto.Id_cupom = val.Id_vendarapida;
                                rPonto.Dt_registro = val.Dt_emissao;
                                if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                    rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                                rPonto.Qt_pontos = (val.lItem.Sum(p => p.Vl_subtotalliquido) % lProg[0].Valor) * lProg[0].Qt_pontosind;
                                rPonto.St_registro = "A";
                                Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            }
                        }
                        else //Percentual
                        {
                            //Gravar Pontos Cliente
                            CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                            rPonto.Cd_empresa = val.Cd_empresa;
                            rPonto.Cd_clifor = val.Cd_clifor;
                            rPonto.Id_cupom = val.Id_vendarapida;
                            rPonto.Dt_registro = val.Dt_emissao;
                            if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                            rPonto.Qt_pontos = Math.Round(decimal.Divide(decimal.Multiply(val.lItem.Sum(p => p.Vl_subtotalliquido), lProg[0].Qt_pontos), 100), 2);
                            rPonto.St_registro = "A";
                            Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            if (!string.IsNullOrEmpty(val.Cd_cliforInd) && (lProg[0].Qt_pontosind > decimal.Zero))
                            {
                                rPonto = new CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade();
                                rPonto.Cd_empresa = val.Cd_empresa;
                                rPonto.Cd_clifor = val.Cd_cliforInd;
                                rPonto.Id_cupom = val.Id_vendarapida;
                                rPonto.Dt_registro = val.Dt_emissao;
                                if (lProg[0].Nr_diasvalidade > decimal.Zero)
                                    rPonto.Dt_validade = val.Dt_emissao.Value.AddDays(Convert.ToDouble(lProg[0].Nr_diasvalidade));
                                rPonto.Qt_pontos = Math.Round(decimal.Divide(decimal.Multiply(val.lItem.Sum(p => p.Vl_subtotalliquido), lProg[0].Qt_pontosind), 100), 2);
                                rPonto.St_registro = "A";
                                Fidelizacao.TCN_PontosFidelidade.Gravar(rPonto, qtb_cf.Banco_Dados);
                            }
                        }
                    }
                }
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_cupom = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                qtb_cupom.Excluir(val);
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
                return val.Id_vendarapidastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }

        public static void RatearDescontoVRapida(TRegistro_VendaRapida val, decimal Tot_desconto, decimal Pc_desconto, bool st_rateioservico = false)
        {
            if (val != null)
            {
                string LoginDesconto = string.Empty;
                decimal tot_subtotal = val.lItem.Where(p => !p.st_servico).Sum(p => p.Vl_subtotal);
                if (Pc_desconto.Equals(decimal.Zero))
                    Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(Tot_desconto, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                if (Tot_desconto.Equals(decimal.Zero))
                    Tot_desconto = Math.Round(decimal.Multiply(Pc_desconto, decimal.Divide(tot_subtotal, 100)), 2, MidpointRounding.AwayFromZero);
                val.lItem.Where(p => !p.st_servico).ToList().ForEach(p =>
                {
                    p.Vl_desconto = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(Pc_desconto, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Pc_desconto = Pc_desconto;
                });
                decimal dif = Tot_desconto - val.lItem.Sum(p => p.Vl_desconto);
                if (dif != decimal.Zero)
                    val.lItem.Where(p => !p.st_servico).ToList().FindLast(p => p.Vl_desconto + dif >= decimal.Zero).Vl_desconto += dif;

            }
        }

        public static void RatearAcrescimoVRapida(TRegistro_VendaRapida val, decimal Tot_acrescimo, decimal Pc_acrescimo)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lItem.Sum(p => p.Vl_subtotal);
                if (Pc_acrescimo.Equals(decimal.Zero))
                    Pc_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(Tot_acrescimo, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                if (Tot_acrescimo.Equals(decimal.Zero))
                    Tot_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(Pc_acrescimo, tot_subtotal), 100), 2, MidpointRounding.AwayFromZero);
                val.lItem.ForEach(p =>
                {
                    p.Vl_acrescimo = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(Pc_acrescimo, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Pc_acrescimo = Pc_acrescimo;
                });
                decimal dif = Tot_acrescimo - val.lItem.Sum(p => p.Vl_acrescimo);
                if (dif != decimal.Zero)
                    val.lItem.FindLast(p => p.Vl_acrescimo + dif >= decimal.Zero).Vl_acrescimo += dif;
            }
        }

        public static void RatearFreteVRapida(TRegistro_VendaRapida val, decimal Tot_frete)
        {
            if (val != null)
            {
                //Ratear Frete de acordo com a % do Item
                val.lItem.ForEach(p =>
                {
                    decimal pc_frete = Math.Round(decimal.Multiply(decimal.Divide(p.Vl_subtotal, val.lItem.Sum(x => x.Vl_subtotal)), 100), 2, MidpointRounding.AwayFromZero);
                    p.Vl_frete = Math.Round(decimal.Divide(decimal.Multiply(Tot_frete, pc_frete), 100), 2, MidpointRounding.AwayFromZero);
                });
                val.lItem[val.lItem.Count - 1].Vl_frete += Tot_frete - val.lItem.Sum(p => p.Vl_frete);
            }
        }

        public static void RatearJuroFinVRapida(TRegistro_VendaRapida val, decimal Tot_jurofin)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lItem.Sum(p => p.Vl_subtotal);
                decimal pc_juro = Math.Round(decimal.Divide(decimal.Multiply(Tot_jurofin, 100), tot_subtotal), 2, MidpointRounding.AwayFromZero);
                val.lItem.ForEach(p => p.Vl_juro_fin = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(pc_juro, 100)), 2, MidpointRounding.AwayFromZero));
                val.lItem[val.lItem.Count - 1].Vl_juro_fin += Tot_jurofin - val.lItem.Sum(p => p.Vl_juro_fin);
            }
        }

        public static void FecharVenda(TRegistro_VendaRapida val,
                                       decimal? Id_caixa,
                                       BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_cupom = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                //Buscar Config. PDV
                TList_CFGCupomFiscal lCfg = TCN_CFGCupomFiscal.Buscar(val.Cd_empresa, qtb_cupom.Banco_Dados);
                if (lCfg.Count < 1)
                    throw new Exception("Não existe configuração PDV para empresa " + val.Cd_empresa);
                if (Id_caixa == null)
                {
                    string where = string.Empty;
                    if (!string.IsNullOrEmpty(val.Id_pdvstr))
                        where += " and x.id_pdv = " + val.Id_pdvstr;
                    if (!string.IsNullOrEmpty(val.Id_sessaostr))
                        where += " and x.id_sessao = " + val.Id_sessaostr;

                    //Buscar caixa aberto do PDV
                    object obj_caixa = new TCD_CaixaPDV(qtb_cupom.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = " isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_sessao x " +
                                                "where x.login = a.login " + where + ")"
                                }
                            }, "a.id_caixa");
                    if (obj_caixa == null)
                        throw new Exception("Não existe caixa aberto para o Usuario");
                    Id_caixa = decimal.Parse(obj_caixa.ToString());
                }
                val.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero).ForEach(p =>
                     {
                         string ret_caixa = string.Empty;
                         string ret_troco = string.Empty;
                         string ret_cred = string.Empty;
                         if (p.St_controletitulobool)//Cheque
                        {
                             TRegistro_Cupom_X_MovCaixa rMov = null;
                             int index = 0;
                            //Cheque
                            p.lCheque.ForEach(v =>
                             {
                                //Gravar Caixa
                                ret_caixa = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = v.Cd_contager,
                                     Cd_Historico = lCfg[0].Cd_historicocaixa,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "RECEBIMENTO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = decimal.Zero,
                                     Vl_RECEBER = (p.Vl_credTroco > decimal.Zero) && index.Equals(p.lCheque.Count - 1) ? v.Vl_titulo - p.Vl_credTroco : v.Vl_titulo
                                 }, qtb_cupom.Banco_Dados);

                                 v.Cd_empresa = val.Cd_empresa;
                                 TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                //Gravar Caixa X Cheque
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                     new TRegistro_LanTituloXCaixa()
                                     {
                                         Cd_banco = v.Cd_banco,
                                         Cd_contager = v.Cd_contager,
                                         Cd_empresa = v.Cd_empresa,
                                         Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                         Nr_lanctocheque = v.Nr_lanctocheque,
                                         Tp_lancto = "OR",//Lancamento de origem do cheque, registro de caixa que deve ser compensado
                                        Tp_caixa = "S"
                                     }, qtb_cupom.Banco_Dados);
                                //Gravar Cupom X MovCaixa
                                rMov = new TRegistro_Cupom_X_MovCaixa();
                                 rMov.Cd_contager = v.Cd_contager;
                                 rMov.Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA");
                                 rMov.Cd_lanctocaixa_trocostr = string.Empty;
                                 rMov.Cd_portador = p.Cd_portador;
                                 rMov.Id_cupom = val.Id_vendarapida;
                                 rMov.Cd_empresa = val.Cd_empresa;
                                 rMov.Id_caixastr = Id_caixa.Value.ToString();
                                 TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             });
                             if (p.Vl_trocoPDV > 0)//Troco Dinheiro
                            {
                                //Gravar Caixa
                                ret_troco = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = p.lCheque[p.lCheque.Count - 1].Cd_contager,
                                     Cd_Historico = lCfg[0].Cd_historico_troco,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "TROCO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = p.Vl_trocoPDV,
                                     Vl_RECEBER = decimal.Zero
                                 }, qtb_cupom.Banco_Dados);
                                //Alterar Movto Caixa
                                rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                                 TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             }
                             if (p.Vl_credTroco > decimal.Zero)//Troco Credito
                            {
                                //Gerar Adiantamento em Aberto para o Cliente
                                TRegistro_LanAdiantamento rAdto = new TRegistro_LanAdiantamento();
                                 rAdto.Cd_clifor = val.Cd_clifor;
                                 rAdto.Cd_empresa = val.Cd_empresa;
                                 rAdto.CD_Endereco = val.Cd_endereco;
                                 rAdto.Ds_adto = string.IsNullOrEmpty(p.Ds_mensagemCredito) ?
                                     "CREDITO RECEBIDO CHEQUE Nº " + p.lCheque[p.lCheque.Count - 1].Nr_cheque :
                                     p.Ds_mensagemCredito;
                                 rAdto.Tp_movimento = "R";
                                 rAdto.Dt_lancto = val.Dt_emissao;
                                 rAdto.Vl_adto = p.Vl_credTroco;
                                 rAdto.ST_ADTO = "A";
                                 rAdto.TP_Lancto = "T";//Frente Caixa
                                TCN_LanAdiantamento.Gravar(rAdto, qtb_cupom.Banco_Dados);
                                //Buscar Config Adto
                                TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      qtb_cupom.Banco_Dados);
                                 if (lCfgAdto.Count.Equals(0))
                                     throw new Exception("Não existe configuração adiantamento para gerar credito.");
                                 rAdto.List_Caixa.Add(new TRegistro_LanCaixa()
                                 {
                                     Cd_ContaGer = p.lCheque[p.lCheque.Count - 1].Cd_contager,
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_Historico = lCfgAdto[0].Cd_historico_ADTO_R,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "CREDITO RECEBIDO PELO CHEQUE Nº " + p.lCheque[p.lCheque.Count - 1].Nr_cheque,
                                     Dt_lancto = val.Dt_emissao,
                                     Login = Parametros.pubLogin,
                                     Nr_Docto = "CH" + p.lCheque[p.lCheque.Count - 1].Nr_cheque,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = decimal.Zero,
                                     Vl_RECEBER = p.Vl_credTroco,
                                     NM_Clifor = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? val.Nm_clifor : p.Ds_mensagemCredito
                                 });
                                //Quitar Adiantamento
                                TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_cupom.Banco_Dados);
                                //Gravar Caixa Adiantamento X Cheque
                                TCN_TituloXCaixa.GravarTituloCaixa(
                                     new TRegistro_LanTituloXCaixa()
                                     {
                                         Cd_banco = p.lCheque[p.lCheque.Count - 1].Cd_banco,
                                         Cd_contager = p.lCheque[p.lCheque.Count - 1].Cd_contager,
                                         Cd_empresa = val.Cd_empresa,
                                         Cd_lanctocaixa = rAdto.List_Caixa[0].Cd_LanctoCaixa,
                                         Nr_lanctocheque = p.lCheque[p.lCheque.Count - 1].Nr_lanctocheque,
                                         Tp_lancto = "OR",//Lancamento de origem do cheque, registro de caixa que deve ser compensado
                                        Tp_caixa = "S"
                                     }, qtb_cupom.Banco_Dados);
                                 rMov.Id_adto = rAdto.Id_adto;
                                 TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             }
                             if (p.lChTroco.Count > 0)//Troco Cheque Proprio/Terceiro
                                p.lChTroco.ForEach(v =>
                                     {
                                         if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                                         {
                                             v.St_lancarcaixa = true;
                                             v.Status_compensado = "T";
                                             TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                         }
                                        //Gravar Troco CH
                                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                         {
                                             Id_movimento = rMov.Id_movimento,
                                             Cd_empresa = val.Cd_empresa,
                                             Id_caixa = Id_caixa,
                                             Nr_lanctocheque = v.Nr_lanctocheque,
                                             Cd_banco = v.Cd_banco
                                         }, qtb_cupom.Banco_Dados);
                                     });
                         }
                         else if (p.St_cartaocreditobool)//Cartao Credito/Debito
                        {
                             TRegistro_Cupom_X_MovCaixa rMov = null;
                            //Cartao
                            if (p.lFatura.Count > 0)
                             {
                                 p.lFatura.ForEach(v =>
                                 {
                                    //Gravar Caixa do Portador
                                    ret_caixa = TCN_LanCaixa.GravaLanCaixa(
                                                 new TRegistro_LanCaixa()
                                                 {
                                                     Cd_Empresa = val.Cd_empresa,
                                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                                     Cd_Historico = lCfg[0].Cd_historicocaixa,
                                                     Cd_LanctoCaixa = decimal.Zero,
                                                     ComplHistorico = "RECEBIMENTO VENDA RAPIDA " + val.Id_vendarapidastr,
                                                     NM_Clifor = val.Nm_clifor,
                                                     Dt_lancto = val.Dt_emissao,
                                                     Nr_Docto = val.Id_vendarapidastr,
                                                     St_Estorno = "N",
                                                     St_Titulo = "N",
                                                     Vl_PAGAR = decimal.Zero,
                                                     Vl_RECEBER = v.Vl_fatura
                                                 }, qtb_cupom.Banco_Dados);
                                    //Gravar Fatura
                                    TCN_FaturaCartao.Gravar(v, qtb_cupom.Banco_Dados);
                                    //Gravar Fatura X Caixa
                                    TCN_FaturaCartao_X_Caixa.Gravar(
                                         new TRegistro_FaturaCartao_X_Caixa()
                                         {
                                             Cd_contager = lCfg[0].Cd_contaoperacional,
                                             Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA")),
                                             Id_fatura = v.Id_fatura
                                         }, qtb_cupom.Banco_Dados);
                                    //Gravar Cupom X MovCaixa
                                    rMov = new TRegistro_Cupom_X_MovCaixa();
                                     rMov.Cd_contager = lCfg[0].Cd_contaoperacional;
                                     rMov.Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA");
                                     rMov.Cd_lanctocaixa_trocostr = string.Empty;
                                     rMov.Cd_portador = p.Cd_portador;
                                     rMov.Id_cupom = val.Id_vendarapida;
                                     rMov.Cd_empresa = val.Cd_empresa;
                                     rMov.Id_caixastr = Id_caixa.Value.ToString();
                                     TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                                 });

                                 if (p.Vl_trocoPDV > 0)//Troco Dinheiro
                                {
                                    //Gravar Caixa
                                    ret_troco = TCN_LanCaixa.GravaLanCaixa(
                                     new TRegistro_LanCaixa()
                                     {
                                         Cd_Empresa = val.Cd_empresa,
                                         Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                         Cd_Historico = lCfg[0].Cd_historico_troco,
                                         Cd_LanctoCaixa = decimal.Zero,
                                         ComplHistorico = "TROCO VENDA RAPIDA " + val.Id_vendarapidastr,
                                         NM_Clifor = val.Nm_clifor,
                                         Dt_lancto = val.Dt_emissao,
                                         Nr_Docto = val.Id_vendarapidastr,
                                         St_Estorno = "N",
                                         St_Titulo = "N",
                                         Vl_PAGAR = p.Vl_trocoPDV,
                                         Vl_RECEBER = decimal.Zero
                                     }, qtb_cupom.Banco_Dados);
                                    //Alterar Movto Caixa
                                    rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                                     TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                                 }
                                 if (p.Vl_credTroco > decimal.Zero)//Troco Credito
                                {
                                    //Gerar Adiantamento em Aberto para o Cliente
                                    TRegistro_LanAdiantamento rAdto = new TRegistro_LanAdiantamento();
                                     rAdto.Cd_clifor = val.Cd_clifor;
                                     rAdto.Cd_empresa = val.Cd_empresa;
                                     rAdto.CD_Endereco = val.Cd_endereco;
                                     rAdto.Ds_adto = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO CARTAO CREDITO/DEBITO" : p.Ds_mensagemCredito;
                                     rAdto.Tp_movimento = "R";
                                     rAdto.Dt_lancto = val.Dt_emissao;
                                     rAdto.Vl_adto = p.Vl_credTroco;
                                     rAdto.ST_ADTO = "A";
                                     rAdto.TP_Lancto = "T";//Frente Caixa
                                    TCN_LanAdiantamento.Gravar(rAdto, qtb_cupom.Banco_Dados);
                                    //Buscar Config Adto
                                    TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          1,
                                                                                          string.Empty,
                                                                                          qtb_cupom.Banco_Dados);
                                     if (lCfgAdto.Count.Equals(0))
                                         throw new Exception("Não existe configuração adiantamento para gerar credito.");
                                     rAdto.List_Caixa.Add(new TRegistro_LanCaixa()
                                     {
                                         Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                         Cd_Empresa = val.Cd_empresa,
                                         Cd_Historico = lCfgAdto[0].Cd_historico_ADTO_R,
                                         Cd_LanctoCaixa = decimal.Zero,
                                         ComplHistorico = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO CARTAO CREDITO/DEBITO" : p.Ds_mensagemCredito,
                                         Dt_lancto = val.Dt_emissao,
                                         Login = Parametros.pubLogin,
                                         Nr_Docto = "FATURA",
                                         St_Estorno = "N",
                                         St_Titulo = "N",
                                         Vl_PAGAR = decimal.Zero,
                                         Vl_RECEBER = p.Vl_credTroco,
                                         NM_Clifor = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? val.Nm_clifor : p.Ds_mensagemCredito
                                     });
                                    //Quitar Adiantamento
                                    TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_cupom.Banco_Dados);
                                    //Gravar Caixa X Fatura
                                    TCN_FaturaCartao_X_Caixa.Gravar(
                                                 new TRegistro_FaturaCartao_X_Caixa()
                                                 {
                                                     Cd_contager = lCfg[0].Cd_contaoperacional,
                                                     Cd_lanctocaixa = rAdto.List_Caixa[0].Cd_LanctoCaixa,
                                                     Id_fatura = p.lFatura[p.lFatura.Count - 1].Id_fatura
                                                 },
                                                 qtb_cupom.Banco_Dados);
                                     rMov.Id_adto = rAdto.Id_adto;
                                     TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                                 }
                                 if (p.lChTroco.Count > 0)//Troco Cheque Proprio/Terceiro
                                    p.lChTroco.ForEach(v =>
                                     {
                                         if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                                         {
                                             v.St_lancarcaixa = true;
                                             v.Status_compensado = "T";
                                             TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                         }
                                        //Gravar Troco CH
                                        TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                         {
                                             Id_movimento = rMov.Id_movimento,
                                             Cd_empresa = val.Cd_empresa,
                                             Id_caixa = Id_caixa,
                                             Nr_lanctocheque = v.Nr_lanctocheque,
                                             Cd_banco = v.Cd_banco
                                         }, qtb_cupom.Banco_Dados);
                                     });
                             }
                             else
                                 throw new Exception("Obrigatorio informar fatura.");
                         }
                         else if (p.Tp_portadorpdv.Trim().ToUpper().Equals("P"))//Duplicata
                        {
                            //Duplicata
                            if (p.lDup.Count > 0)
                             {
                                 if (string.IsNullOrEmpty(p.lDup[0].Nr_docto) || p.lDup[0].Nr_docto.Equals("PDC123"))
                                     p.lDup[0].Nr_docto = "VR" + val.Id_vendarapidastr;
                                //Gravar Duplicata
                                TCN_LanDuplicata.GravarDuplicata(p.lDup[0], false, qtb_cupom.Banco_Dados);
                                //Gravar Cupom X Duplicata
                                TCN_CupomFiscal_X_Duplicata.Gravar(
                                     new TRegistro_CupomFiscal_X_Duplicata()
                                     {
                                         Cd_empresa = val.Cd_empresa,
                                         Id_cupom = val.Id_vendarapida,
                                         Nr_lancto = p.lDup[0].Nr_lancto,
                                         Id_caixa = Id_caixa.Value
                                     }, qtb_cupom.Banco_Dados);
                             }
                             else
                                 throw new Exception("Portador exige duplicata.");
                         }
                         else if (p.St_cartafretebool && p.lCartaFrete.Count > 0)
                         {
                             TRegistro_Cupom_X_MovCaixa rMov = null;
                             p.lCartaFrete.ForEach(v =>
                                 {
                                    //Gravar carta frete
                                    PostoCombustivel.TCN_CartaFrete.Gravar(v, qtb_cupom.Banco_Dados);
                                    //Gravar movimento caixa
                                    rMov = new TRegistro_Cupom_X_MovCaixa();
                                     rMov.Cd_portador = p.Cd_portador;
                                     rMov.Id_cupom = val.Id_vendarapida;
                                     rMov.Cd_empresa = val.Cd_empresa;
                                     rMov.Id_caixa = Id_caixa;
                                     rMov.Id_cartafrete = v.Id_cartafrete;
                                     TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                                 });
                             if (p.Vl_trocoPDV > 0)//Troco Dinheiro
                            {
                                //Gravar Caixa
                                ret_troco = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Historico = lCfg[0].Cd_historico_troco,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "TROCO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = p.Vl_trocoPDV,
                                     Vl_RECEBER = decimal.Zero
                                 }, qtb_cupom.Banco_Dados);
                                //Alterar Movto Caixa
                                rMov.Cd_contager = lCfg[0].Cd_contaoperacional;
                                 rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                                //Gravar movimento caixa
                                TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             }
                             if (p.lChTroco.Count > 0)//Troco Cheque Proprio/Terceiro
                                p.lChTroco.ForEach(v =>
                                 {
                                     if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                                     {
                                         v.St_lancarcaixa = true;
                                         v.Status_compensado = "T";
                                         TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                     }
                                    //Gravar Troco CH
                                    TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                     {
                                         Id_movimento = rMov.Id_movimento,
                                         Cd_empresa = val.Cd_empresa,
                                         Id_caixa = Id_caixa,
                                         Nr_lanctocheque = v.Nr_lanctocheque,
                                         Cd_banco = v.Cd_banco
                                     }, qtb_cupom.Banco_Dados);
                                 });
                         }
                         else if (p.St_devcreditobool)//Devolver credito
                        {
                            //Buscar config adiantamento
                            TList_ConfigAdto lConfig =
                                 TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          1,
                                                          string.Empty,
                                                          qtb_cupom.Banco_Dados);
                             if (lConfig.Count.Equals(0))
                                 throw new Exception("Não existe configuração de credito para a empresa " + val.Cd_empresa.Trim() + "!");
                             if (string.IsNullOrEmpty(lConfig[0].CD_Portador))
                                 throw new Exception("Não existe portador configurado para devolução de credito.");
                             if (string.IsNullOrEmpty(lConfig[0].Cd_historico_DEVADTO_R))
                                 throw new Exception("Não existe configuração de histórico de devolução de credito recebido.");
                            //Devolucao credito
                            decimal vl_devolver = p.lCred.Sum(v => v.Vl_processar);
                             p.lCred.ForEach(v =>
                             {
                                 if (vl_devolver > decimal.Zero)
                                 {
                                     decimal valor = vl_devolver > v.Vl_total_devolver ? v.Vl_total_devolver : vl_devolver;
                                    //Gravar caixa devolucao
                                    string cd_caixa_dev =
                                     TCN_LanCaixa.GravaLanCaixa(
                                         new TRegistro_LanCaixa()
                                         {
                                             Cd_ContaGer = v.Cd_contager_qt,
                                             Cd_Empresa = v.Cd_empresa,
                                             Cd_Historico = lConfig[0].Cd_historico_DEVADTO_R,
                                             ComplHistorico = "DEVOLUCAO CREDITO " + v.Id_adto.ToString(),
                                             NM_Clifor = val.Nm_clifor,
                                             Dt_lancto = val.Dt_emissao,
                                             Nr_Docto = "DEVCRED" + v.Id_adto.ToString(),
                                             St_Titulo = "N",
                                             St_Estorno = "N",
                                             Vl_PAGAR = valor,
                                             Vl_RECEBER = decimal.Zero
                                         }, qtb_cupom.Banco_Dados);
                                    //Gravar Adiantamento X Caixa
                                    TCN_LanAdiantamentoXCaixa.Gravar(
                                         new TRegistro_LanAdiantamentoXCaixa()
                                         {
                                             Cd_contager = v.Cd_contager_qt,
                                             Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(cd_caixa_dev, "@P_CD_LANCTOCAIXA")),
                                             Id_adto = v.Id_adto
                                         }, qtb_cupom.Banco_Dados);
                                    //Gravar centro resultado da devolucao
                                    if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                  val.Cd_empresa,
                                                                  qtb_cupom.Banco_Dados).Trim().ToUpper().Equals("S"))
                                     {
                                        //Buscar centro resultado devolucao adiantamento recebido
                                        object obj = new TCD_CadConfigAdto(qtb_cupom.Banco_Dados).BuscarEscalar(
                                                         new TpBusca[]
                                                             {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                                }
                                                             }, "a.cd_centroresult_devadto_r");
                                         if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                         {
                                             string id_lan = TCN_LanCCustoLancto.Gravar(
                                                 new TRegistro_LanCCustoLancto()
                                                 {
                                                     Cd_empresa = val.Cd_empresa,
                                                     Cd_centroresult = obj.ToString(),
                                                     Vl_lancto = valor,
                                                     Dt_lancto = val.Dt_emissao
                                                 }, qtb_cupom.Banco_Dados);
                                            //Gravar Emprestimo X CCusto
                                            TCN_Adiantamento_X_CCusto.Gravar(
                                                 new TRegistro_Adiantamento_X_CCusto()
                                                 {
                                                     Id_adto = v.Id_adto,
                                                     Id_ccustolan = decimal.Parse(id_lan)
                                                 }, qtb_cupom.Banco_Dados);
                                         }
                                     }
                                    //Gravar caixa recebimento do cupom fiscal
                                    string cd_caixa =
                                         TCN_LanCaixa.GravaLanCaixa(
                                         new TRegistro_LanCaixa()
                                         {
                                             Cd_ContaGer = v.Cd_contager_qt,
                                             Cd_Empresa = v.Cd_empresa,
                                             Cd_Historico = lCfg[0].Cd_historicocaixa,
                                             ComplHistorico = "RECEBIMENTO DEVOLUCAO CREDITO " + v.Id_adto.ToString(),
                                             NM_Clifor = val.Nm_clifor,
                                             Dt_lancto = val.Dt_emissao,
                                             Nr_Docto = "RECDEVCRED" + v.Id_adto.ToString(),
                                             St_Titulo = "N",
                                             St_Estorno = "N",
                                             Vl_PAGAR = decimal.Zero,
                                             Vl_RECEBER = valor
                                         }, qtb_cupom.Banco_Dados);
                                    //Gravar Cupom X Devolucao Adiantamento
                                    TCN_Cupom_X_DevCredito.Gravar(new TRegistro_Cupom_X_DevCredito()
                                     {
                                         Cd_contager = v.Cd_contager_qt,
                                         Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_caixa, "@P_CD_LANCTOCAIXA")),
                                         Cd_lanctocaixa_dev = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(cd_caixa_dev, "@P_CD_LANCTOCAIXA")),
                                         Id_cupom = val.Id_vendarapida,
                                         Cd_empresa = val.Cd_empresa,
                                         Id_caixa = Id_caixa,
                                         Cd_portador = p.Cd_portador
                                     }, qtb_cupom.Banco_Dados);
                                     vl_devolver -= valor;
                                 }
                             });
                             TRegistro_Cupom_X_MovCaixa rMov = null;
                            //Gravar Cupom X MovCaixa
                            rMov = new TRegistro_Cupom_X_MovCaixa();
                             rMov.Cd_contager = lCfg[0].Cd_contaoperacional;
                             rMov.Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA");
                             rMov.Cd_lanctocaixa_trocostr = string.Empty;
                             rMov.Cd_portador = p.Cd_portador;
                             rMov.Id_cupom = val.Id_vendarapida;
                             rMov.Cd_empresa = val.Cd_empresa;
                             rMov.Id_caixastr = Id_caixa.Value.ToString();
                             if (p.Vl_trocoPDV > 0)//Troco Dinheiro
                            {
                                //Gravar Caixa
                                ret_troco = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Historico = lCfg[0].Cd_historico_troco,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "TROCO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = p.Vl_trocoPDV,
                                     Vl_RECEBER = decimal.Zero
                                 }, qtb_cupom.Banco_Dados);
                                //Alterar Movto Caixa
                                rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                                 TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             }
                             if (p.Vl_credTroco > decimal.Zero)//Troco Credito
                            {
                                //Gerar Adiantamento em Aberto para o Cliente
                                TRegistro_LanAdiantamento rAdto = new TRegistro_LanAdiantamento();
                                 rAdto.Cd_clifor = val.Cd_clifor;
                                 rAdto.Cd_empresa = val.Cd_empresa;
                                 rAdto.CD_Endereco = val.Cd_endereco;
                                 rAdto.Ds_adto = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO" : p.Ds_mensagemCredito;
                                 rAdto.Tp_movimento = "R";
                                 rAdto.Dt_lancto = val.Dt_emissao;
                                 rAdto.Vl_adto = p.Vl_credTroco;
                                 rAdto.ST_ADTO = "A";
                                 rAdto.TP_Lancto = "T";//Frente Caixa
                                TCN_LanAdiantamento.Gravar(rAdto, qtb_cupom.Banco_Dados);
                                //Buscar Config Adto
                                TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      qtb_cupom.Banco_Dados);
                                 if (lCfgAdto.Count.Equals(0))
                                     throw new Exception("Não existe configuração adiantamento para gerar credito.");
                                 rAdto.List_Caixa.Add(new TRegistro_LanCaixa()
                                 {
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_Historico = lCfgAdto[0].Cd_historico_ADTO_R,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO CARTAO CREDITO/DEBITO" : p.Ds_mensagemCredito,
                                     Dt_lancto = val.Dt_emissao,
                                     Login = Parametros.pubLogin,
                                     Nr_Docto = "FATURA",
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = decimal.Zero,
                                     Vl_RECEBER = p.Vl_credTroco,
                                     NM_Clifor = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? val.Nm_clifor : p.Ds_mensagemCredito
                                 });
                                //Quitar Adiantamento
                                TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_cupom.Banco_Dados);
                                 rMov.Id_adto = rAdto.Id_adto;
                                 TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             }
                             if (p.lChTroco.Count > 0)//Troco Cheque Proprio/Terceiro
                                p.lChTroco.ForEach(v =>
                                 {
                                     if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                                     {
                                         v.St_lancarcaixa = true;
                                         v.Status_compensado = "T";
                                         TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                     }
                                    //Gravar Troco CH
                                    TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                     {
                                         Id_movimento = rMov.Id_movimento,
                                         Cd_empresa = val.Cd_empresa,
                                         Id_caixa = Id_caixa,
                                         Nr_lanctocheque = v.Nr_lanctocheque,
                                         Cd_banco = v.Cd_banco
                                     }, qtb_cupom.Banco_Dados);
                                 });
                         }
                         else if (p.St_entregafuturabool)//Entrega Futura
                            TCN_Cupom_X_MovCaixa.Gravar(new TRegistro_Cupom_X_MovCaixa()
                             {
                                 Cd_portador = p.Cd_portador,
                                 Id_cupom = val.Id_vendarapida,
                                 Cd_empresa = val.Cd_empresa,
                                 Id_caixastr = Id_caixa.Value.ToString()
                             }, qtb_cupom.Banco_Dados);
                         else //Dinheiro
                        {
                            //Gravar Caixa
                            ret_caixa = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Historico = lCfg[0].Cd_historicocaixa,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "RECEBIMENTO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = decimal.Zero,
                                     Vl_RECEBER = p.Vl_credTroco > decimal.Zero ? p.Vl_pagtoPDV - p.Vl_credTroco : p.Vl_pagtoPDV
                                 }, qtb_cupom.Banco_Dados);
                            //Movimento caixa
                            TRegistro_Cupom_X_MovCaixa rMov = new TRegistro_Cupom_X_MovCaixa();
                             rMov.Cd_contager = lCfg[0].Cd_contaoperacional;
                             rMov.Cd_lanctocaixastr = CamadaDados.TDataQuery.getPubVariavel(ret_caixa, "@P_CD_LANCTOCAIXA");
                             rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                             rMov.Cd_portador = p.Cd_portador;
                             rMov.Id_cupom = val.Id_vendarapida;
                             rMov.Cd_empresa = val.Cd_empresa;
                             rMov.Id_caixastr = Id_caixa.Value.ToString();
                             rMov.Id_adtostr = ret_cred;
                             if (p.Vl_trocoPDV > 0)//Troco Dinheiro
                            {
                                //Gravar Caixa
                                ret_troco = TCN_LanCaixa.GravaLanCaixa(
                                 new TRegistro_LanCaixa()
                                 {
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Historico = lCfg[0].Cd_historico_troco,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = "TROCO VENDA RAPIDA " + val.Id_vendarapidastr,
                                     NM_Clifor = val.Nm_clifor,
                                     Dt_lancto = val.Dt_emissao,
                                     Nr_Docto = val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = p.Vl_trocoPDV,
                                     Vl_RECEBER = decimal.Zero
                                 }, qtb_cupom.Banco_Dados);
                                //Alterar Movto Caixa
                                rMov.Cd_lanctocaixa_trocostr = CamadaDados.TDataQuery.getPubVariavel(ret_troco, "@P_CD_LANCTOCAIXA");
                             }
                             if (p.Vl_credTroco > decimal.Zero)//Troco Credito
                            {
                                //Gerar Adiantamento em Aberto para o Cliente
                                TRegistro_LanAdiantamento rAdto = new TRegistro_LanAdiantamento();
                                 rAdto.Cd_clifor = val.Cd_clifor;
                                 rAdto.Cd_empresa = val.Cd_empresa;
                                 rAdto.CD_Endereco = val.Cd_endereco;
                                 rAdto.Ds_adto = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO VENDA RAPIDA" + val.Id_vendarapidastr : p.Ds_mensagemCredito;
                                 rAdto.Tp_movimento = "R";
                                 rAdto.Dt_lancto = val.Dt_emissao;
                                 rAdto.Vl_adto = p.Vl_credTroco;
                                 rAdto.ST_ADTO = "A";
                                 rAdto.TP_Lancto = "T";//Frente Caixa
                                TCN_LanAdiantamento.Gravar(rAdto, qtb_cupom.Banco_Dados);
                                //Buscar Config Adto
                                TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(val.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      qtb_cupom.Banco_Dados);
                                 if (lCfgAdto.Count.Equals(0))
                                     throw new Exception("Não existe configuração adiantamento para gerar credito.");
                                 rAdto.List_Caixa.Add(new TRegistro_LanCaixa()
                                 {
                                     Cd_ContaGer = lCfg[0].Cd_contaoperacional,
                                     Cd_Empresa = val.Cd_empresa,
                                     Cd_Historico = lCfgAdto[0].Cd_historico_ADTO_R,
                                     Cd_LanctoCaixa = decimal.Zero,
                                     ComplHistorico = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? "CREDITO RECEBIDO VENDA RAPIDA" + val.Id_vendarapidastr : p.Ds_mensagemCredito,
                                     Dt_lancto = val.Dt_emissao,
                                     Login = Parametros.pubLogin,
                                     Nr_Docto = "VR" + val.Id_vendarapidastr,
                                     St_Estorno = "N",
                                     St_Titulo = "N",
                                     Vl_PAGAR = decimal.Zero,
                                     Vl_RECEBER = p.Vl_credTroco,
                                     NM_Clifor = string.IsNullOrEmpty(p.Ds_mensagemCredito) ? val.Nm_clifor : p.Ds_mensagemCredito
                                 });
                                //Quitar Adiantamento
                                TCN_LanAdiantamentoXCaixa.Quitar_Adiantamento(rAdto, qtb_cupom.Banco_Dados);
                                 rMov.Id_adto = rAdto.Id_adto;
                             }
                            //Gravar Cupom X MovCaixa
                            TCN_Cupom_X_MovCaixa.Gravar(rMov, qtb_cupom.Banco_Dados);
                             if (p.lChTroco.Count > 0)//Troco Cheque Proprio/Terceiro
                                p.lChTroco.ForEach(v =>
                                 {
                                     if (v.Tp_titulo.Trim().ToUpper().Equals("P") && v.Nr_lanctocheque.Equals(decimal.Zero))
                                     {
                                         v.St_lancarcaixa = true;
                                         v.Status_compensado = "T";
                                         TCN_LanTitulo.GravarTitulo(v, qtb_cupom.Banco_Dados);
                                     }
                                     else
                                     {
                                        //Compensar Cheque Terceiro
                                        v.Cd_contager_destino = lCfg[0].Cd_contaoperacional;
                                         v.Dt_compensacao = val.Dt_emissao;
                                         TCN_LanTitulo.CompensarCheques(new List<TRegistro_LanTitulo>() { v }, qtb_cupom.Banco_Dados);
                                     }
                                    //Gravar Troco CH
                                    TCN_TrocoCH.Gravar(new TRegistro_TrocoCH()
                                     {
                                         Id_movimento = rMov.Id_movimento,
                                         Cd_empresa = val.Cd_empresa,
                                         Id_caixa = Id_caixa,
                                         Nr_lanctocheque = v.Nr_lanctocheque,
                                         Cd_banco = v.Cd_banco
                                     }, qtb_cupom.Banco_Dados);
                                 });
                         }
                     });
                //Verificar se a empresa utiliza rateio na provisao
                if (ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                            val.Cd_empresa,
                                                            qtb_cupom.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    //Gravar Lancamento Vl.Liquido venda sem frete
                    if (val.lCusto != null)
                        val.lCusto.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            p.Id_cupom = val.Id_vendarapida;
                            TCN_LanCCustoLancto.Gravar(p, qtb_cupom.Banco_Dados);
                            //Cupom X Centro Resultado
                            TCN_Cupom_X_CCusto.Gravar(new TRegistro_Cupom_X_CCusto
                            {
                                Cd_empresa = val.Cd_empresa,
                                Id_cupom = val.Id_vendarapida,
                                Id_ccustolan = p.Id_ccustolan
                            }, qtb_cupom.Banco_Dados);
                        });
                    if (val.lItem.Sum(p => p.Vl_frete) > decimal.Zero &&
                        !string.IsNullOrEmpty(lCfg[0].Cd_CentroResultFrete))
                    {
                        //Gravar Lancamento Frete centro de resultado
                        string id_ccustolanfrete =
                        TCN_LanCCustoLancto.Gravar(
                            new TRegistro_LanCCustoLancto
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_CentroResultFrete,
                                Vl_lancto = val.lItem.Sum(p => p.Vl_frete),
                                Dt_lancto = val.Dt_emissao
                            }, qtb_cupom.Banco_Dados);
                        //Cupom X Centro Resultado
                        TCN_Cupom_X_CCusto.Gravar(new TRegistro_Cupom_X_CCusto()
                        {
                            Id_ccustolan = decimal.Parse(id_ccustolanfrete),
                            Id_cupom = val.Id_vendarapida,
                            Cd_empresa = val.Cd_empresa
                        }, qtb_cupom.Banco_Dados);
                    }
                    if (val.lItem.Where(p => p.St_baixapatrimoniobool).Sum(p => p.Vl_subtotalliquido - p.Vl_frete) > decimal.Zero &&
                        !string.IsNullOrEmpty(lCfg[0].Cd_CentroResultBaixaPat))
                    {
                        //Gravar Lancamento Baixa Patrimonio centro de resultado
                        string id_ccustolanbaixa =
                        TCN_LanCCustoLancto.Gravar(
                            new TRegistro_LanCCustoLancto
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_CentroResultBaixaPat,
                                Vl_lancto = val.lItem.Where(p => p.St_baixapatrimoniobool).Sum(p => p.Vl_subtotalliquido - p.Vl_frete),
                                Dt_lancto = val.Dt_emissao
                            }, qtb_cupom.Banco_Dados);
                        //Cupom X Centro Resultado
                        TCN_Cupom_X_CCusto.Gravar(new TRegistro_Cupom_X_CCusto()
                        {
                            Id_ccustolan = decimal.Parse(id_ccustolanbaixa),
                            Id_cupom = val.Id_vendarapida,
                            Cd_empresa = val.Cd_empresa
                        }, qtb_cupom.Banco_Dados);
                    }
                }
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro fechar cupom: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }

        public static void ImprimirVendaRapida(TRegistro_VendaRapida val)
        {
            object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Parametros.pubTerminal.Trim() + "'"
                                }
                            }, "a.porta_imptick");
            if (obj == null)
                throw new Exception("Não existe porta de impressão configurada para o terminal " + Parametros.pubTerminal.Trim());
            //Buscar dados da empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                              string.Empty,
                                              string.Empty,
                                              null);
            if (lEmpresa.Count < 1)
                throw new Exception("Não foi possivel localizar empresa " + val.Cd_empresa);


            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Orcamento.txt");
            w = f.CreateText();
            try
            {
                w.WriteLine("                            ORCAMENTO VENDA                Numero: " + val.Id_vendarapidastr);
                w.WriteLine("                                                           Data: " + val.Dt_emissaostr);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("EMPRESA:  " + lEmpresa[0].Nm_empresa.Trim().ToUpper().FormatStringDireita(38, ' ') + "- CNPJ: " + lEmpresa[0].rClifor.Nr_cgc);
                w.WriteLine("ENDERECO: " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + " - " + lEmpresa[0].rEndereco.Bairro.Trim() + " - " + lEmpresa[0].rEndereco.Numero);
                w.WriteLine("CIDADE: " + lEmpresa[0].rEndereco.DS_Cidade.Trim().ToUpper() + " - " + lEmpresa[0].rEndereco.UF + " - " + lEmpresa[0].rEndereco.NM_Pais);
                w.WriteLine();
                w.WriteLine("CLIENTE: " + val.Nm_clifor.Trim().ToUpper());
                w.WriteLine();
                w.WriteLine("                               ITENS ORCAMENTO");
                w.WriteLine();
                w.WriteLine("PRODUTO                                            QTD UND  VALOR UNIT  SUBTOTAL");
                w.WriteLine("--------------------------------------------------------------------------------");

                val.lItem.ForEach(p =>
                {
                    w.Write((p.Cd_produto.Trim() + "-" + p.Ds_produto).FormatStringDireita(44, ' '));
                    w.Write(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.Write(" ");
                    w.Write(p.Sigla_unidade.FormatStringEsquerda(3, ' '));
                    w.Write(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.Write(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine();
                    if (p.Vl_desconto > decimal.Zero)
                        w.WriteLine(" VALOR DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    if (p.Vl_acrescimo > decimal.Zero)
                        w.WriteLine(" VALOR ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    if (p.Vl_juro_fin > decimal.Zero)
                        w.WriteLine(" JURO FINANCEIRO: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                });

                w.WriteLine();
                w.WriteLine();
                w.WriteLine(" TOTAL ITENS    FRETE       TOTAL ORCAMENTO");
                w.WriteLine("--------------------------------------------------------------------------------");
                w.Write(val.lItem.Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                w.Write(val.lItem.Sum(p => p.Vl_frete).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(7, ' '));
                w.Write(val.lItem.Sum(p => p.Vl_subtotalliquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(31, ' '));
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("-----------------------------------        -------------------------------------");
                w.WriteLine("CLIENTE                                    VENDEDOR                             ");
                w.Write(val.Nm_clifor.Trim().ToUpper().FormatStringDireita(43, ' '));
                //Buscar Nome Vendedor
                obj = new TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_vendarapida_item x " +
                                            "where x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                            "and x.id_vendarapida = " + val.Id_vendarapidastr + " " +
                                            "and x.cd_vendedor = a.cd_clifor)"
                            }
                        }, "a.nm_clifor");
                if (obj != null)
                    w.Write(obj.ToString().Trim().ToUpper().FormatStringDireita(47, ' '));

                w.Write(Convert.ToChar(12));
                w.Flush();

                f.CopyTo(obj.ToString());
            }
            catch (Exception ex)
            { throw new Exception("Erro na impressao: " + ex.Message.Trim()); }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void ImprimirReduzido(TRegistro_VendaRapida val,
                                      string ClientePadrao,
                                      bool St_impCPF_CNPJ,
                                      string porta)
        {
            //Buscar dados da empresa
            CamadaDados.Diversos.TList_CadEmpresa lEmpresa = Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
            if (lEmpresa.Count < 1)
                throw new Exception("Não foi possivel localizar empresa " + val.Cd_empresa);

            //Buscar Portador da Venda
            List<TRegistro_MovCaixa> lPort =
                new TCD_CaixaPDV().SelectMovCaixa(
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
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc = null;
            if (lPort.Count < 1)
                //Buscar Parcelas
                lParc = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                       {
                           new TpBusca()
                           {
                               vNM_Campo = string.Empty,
                               vOperador = "exists",
                               vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                           "where x.cd_empresa = a.cd_empresa " +
                                           "and x.nr_lancto = a.nr_lancto " +
                                           "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                           "and x.id_cupom = "  + val.Id_vendarapidastr + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);

            //Buscar Parcelas Cartao
            TList_FaturaCartao lCartao = new TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);

            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Orcamento.txt");
            w = f.CreateText();
            try
            {
                w.WriteLine("  VENDA  Nº " + (val.Id_vendarapidastr) + "  " + val.Dt_emissaostr);
                w.WriteLine(" =========================================");
                w.WriteLine("               DADOS EMPRESA              ");
                w.WriteLine(" =========================================");
                w.WriteLine("  " + lEmpresa[0].Nm_empresa.Trim().ToUpper());
                w.WriteLine("  " + lEmpresa[0].Ds_endereco.Trim().ToUpper() + "," + lEmpresa[0].rEndereco.Numero);
                w.WriteLine("  " + lEmpresa[0].rEndereco.Bairro.Trim().ToUpper());
                w.WriteLine("  Fone: " + lEmpresa[0].rEndereco.Fone.Trim().ToUpper());
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("               DADOS CLIENTE              ");
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  " + val.Cd_clifor.Trim() + "-" + val.Nm_clifor.Trim().ToUpper());
                if ((!string.IsNullOrEmpty(val.Cd_clifor)) && (ClientePadrao.Trim() != val.Cd_clifor.Trim()))
                {
                    //Buscar dados cliente
                    TRegistro_CadClifor rCliente = TCN_CadClifor.Busca_Clifor_Codigo(val.Cd_clifor, null);
                    if (!string.IsNullOrEmpty(rCliente.Nm_fantasia))
                        w.WriteLine("  " + rCliente.Nm_fantasia.Trim().ToUpper());
                    if (St_impCPF_CNPJ)
                    {
                        if ((!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero())) ||
                            (!string.IsNullOrEmpty(rCliente.Nr_cpf.SoNumero())))
                            w.WriteLine("  CNPJ/CPF: " + (!string.IsNullOrEmpty(rCliente.Nr_cgc.SoNumero()) ? rCliente.Nr_cgc : rCliente.Nr_cpf));
                    }
                }
                w.Write("  " + val.Ds_endereco.Trim().ToUpper());
                if ((ClientePadrao != val.Cd_clifor) && (!string.IsNullOrEmpty(val.Cd_clifor)))
                {
                    //Buscar Endereco do cliente
                    TList_CadEndereco lEndereco =
                        new TCD_CadEndereco().Select(
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
                            }
                        }, 0, string.Empty);
                    if (lEndereco.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(lEndereco[0].Numero))
                            w.WriteLine(", " + lEndereco[0].Numero.Trim().ToUpper());
                        if (!string.IsNullOrEmpty(lEndereco[0].Bairro))
                            w.WriteLine("  " + lEndereco[0].Bairro.Trim().ToUpper());
                        if (!string.IsNullOrEmpty(lEndereco[0].DS_Cidade))
                            w.WriteLine("  " + lEndereco[0].DS_Cidade.Trim().ToUpper() + " - " + lEndereco[0].UF);
                        if (!string.IsNullOrEmpty(lEndereco[0].Fone.SoNumero()))
                        {
                            w.WriteLine("  " + lEndereco[0].Fone.Trim().ToUpper() +
                                (!string.IsNullOrEmpty(lEndereco[0].Celular.SoNumero()) ? "/" + lEndereco[0].Celular.Trim().ToUpper() : string.Empty));
                        }
                        if (!string.IsNullOrEmpty(lEndereco[0].Cep.SoNumero()))
                            w.WriteLine("  CEP: " + lEndereco[0].Cep);
                        if (!string.IsNullOrEmpty(lEndereco[0].Proximo))
                            w.WriteLine("  " + lEndereco[0].Proximo.Trim().ToUpper());
                    }
                }
                else
                {
                    w.WriteLine();
                    w.WriteLine();
                }
                w.WriteLine(("  VENDEDOR: " + val.lItem[0].Nm_vendedor.Trim()).FormatStringDireita(42, ' '));
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  PRODUTO  QTD      VAL.UNIT  SUBTOTAL");
                w.WriteLine(" -----------------------------------------");

                val.lItem.ForEach(p =>
                {
                    w.WriteLine("  " + (p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim().ToUpper()));
                    w.Write(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(13, ' ') + "x");
                    w.Write(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' '));
                    w.Write(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine();
                    if (p.Vl_desconto > decimal.Zero)
                        w.WriteLine(" DESCONTO: " + p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    if (p.Vl_acrescimo > decimal.Zero)
                        w.WriteLine(" ACRESCIMO: " + p.Vl_acrescimo.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                    if (p.Vl_juro_fin > decimal.Zero)
                        w.WriteLine(" JURO FIN.: " + p.Vl_juro_fin.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                });

                w.WriteLine(" -----------------------------------------");
                w.WriteLine("  ACRESC.   JUROS  FRETE DESCONTO  LIQUIDO");
                w.Write(val.lItem.Sum(p => p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                w.Write(val.lItem.Sum(p => p.Vl_juro_fin).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(8, ' '));
                w.Write(val.lItem.Sum(p => p.Vl_frete).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(7, ' '));
                w.Write(val.lItem.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                w.WriteLine(val.lItem.Sum(p => p.Vl_subtotalliquido).ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(9, ' '));
                w.WriteLine(" -----------------------------------------");
                if (lPort.Count > 0)
                    lPort.ForEach(p =>
                    {
                        w.WriteLine("  FORMA PGTO : " + p.Ds_portador.Trim());
                        w.WriteLine("  VALOR: " + p.Vl_recebido.ToString("C2", new System.Globalization.CultureInfo("pt-BR")));
                    });
                else if (lParc != null)
                {
                    //Buscar descricao portador a prazo
                    object portador = new TCD_CadPortador().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.TP_PortadorPDV",
                                                vOperador = "=",
                                                vVL_Busca = "'P'"
                                            }
                                        }, "a.ds_portador");
                    w.WriteLine("  FORMA PGTO : " + (portador != null ? portador.ToString().Trim().ToUpper() : "A PRAZO"));
                    w.WriteLine("  VENCIMENTO          VALOR ");
                    lParc.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                        w.WriteLine("  " + p.Dt_venctostring.FormatStringDireita(20, ' ') + p.Vl_parcela.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))));
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine("  ----------------------------------- ");
                    w.WriteLine("                Cliente               ");
                    w.WriteLine();
                    w.WriteLine();
                }
                if (lCartao != null)
                {
                    if (lCartao.Count > 0)
                        if (lCartao[0].Tp_cartao.Trim().ToUpper().Equals("C"))
                        {
                            w.WriteLine();
                            w.WriteLine("  BANDEIRA         VENCIMENTO     PARCELA");
                            lCartao.OrderBy(p => p.Dt_vencto).ToList().ForEach(p =>
                                         w.WriteLine("  " + p.Ds_bandeira.FormatStringDireita(17, ' ') + p.Dt_venctostr.FormatStringDireita(13, ' ') +
                                         p.Vl_fatura.ToString("C2", new System.Globalization.CultureInfo("pt-BR", true))));
                            w.WriteLine();
                        }
                }
                //Imprimir troco
                decimal vl_portador = lPort.Sum(p => p.Vl_recebido);
                if (lParc != null)
                    vl_portador += lParc.Sum(p => p.Vl_parcela);
                if (vl_portador > val.lItem.Sum(p => p.Vl_subtotalliquido))
                    w.WriteLine("  TROCO: " + (vl_portador - val.lItem.Sum(p => p.Vl_subtotal - p.Vl_desconto)).ToString("C2", new System.Globalization.CultureInfo("pt-BR")));

                //Imprimir observacao cupom
                if (!string.IsNullOrEmpty(val.Ds_observacao))
                {
                    string obs = val.Ds_observacao.Trim();
                    w.WriteLine(" -----------------------------------------");
                    w.WriteLine("              OBSERVAÇÕES                 ");
                    w.WriteLine(" -----------------------------------------");
                    while (true)
                    {
                        if (obs.Length <= 40)
                        {
                            w.WriteLine("  " + obs);
                            break;
                        }
                        else
                        {
                            w.WriteLine("  " + obs.Substring(0, 40));
                            obs = obs.Remove(0, 40);
                        }
                    }
                }
                w.WriteLine(" -----------------------------------------");
                w.WriteLine("      Este recibo nao tem valor Fiscal    ");

                w.Write(Convert.ToChar(12));
                w.Write(Convert.ToChar(27));
                w.Write(Convert.ToChar(109));
                w.Flush();

                decimal copias = ConfigGer.TCN_CadParamGer.VlNumericoEmpresa("QTD_VIA_REC_ECF", val.Cd_empresa, null);
                if (copias.Equals(decimal.Zero))
                    copias = 1;
                if (copias.Equals(1) && (lParc != null))
                    copias++;//Imprimir duas vias
                for (int i = 0; i < copias; i++)
                    f.CopyTo(porta);
            }

            catch (Exception ex)
            { throw new Exception("Erro na impressao: " + ex.Message.Trim()); }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void ExcluirVendaRapida(List<TRegistro_VendaRapida> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_cf = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        //Verificar se existe cupom fiscal para a venda
                        if (new TCD_NFCe(qtb_cf.Banco_Dados).BuscarEscalar(
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
                                    vVL_Busca = "(select 1 from TB_PDV_Cupom_X_VendaRapida x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_cupom = a.id_nfce " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_vendarapida = " + p.Id_vendarapidastr + ")"
                                }
                            }, "1") != null)
                            throw new Exception("Não é permitido excluir venda rapida que possui NFC-e.");
                        //Verificar se existe nfe para a venda
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(qtb_cf.Banco_Dados).BuscarEscalar(
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
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                "inner join tb_pdv_pedido_x_vendarapida y " +
                                                "on x.nr_pedido = y.nr_pedido " +
                                                "and x.cd_produto = y.cd_produto " +
                                                "and x.id_pedidoitem = y.id_pedidoitem " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and y.id_vendarapida = " + p.Id_vendarapidastr + ")"
                                }
                            }, "1") != null)
                            throw new Exception("Não é permitido excluir venda que possui NFe.");
                        //Verificar se existe NFe Entrega Futura para a venda
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(qtb_cf.Banco_Dados).BuscarEscalar(
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
                                    vVL_Busca = "(select 1 from tb_pdv_vendarapida_x_entregafutura x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                "and x.id_cupom = " + p.Id_vendarapidastr + ")"
                                }
                            }, "1") != null)
                            throw new Exception("Não é permitido excluir venda que possui NFe ENTREGA FUTURA.");
                        //Verificar se o caixa operacional da venda ja esta AUDITADO ou PROCESSADO
                        object obj_caixa = new TCD_CaixaPDV(qtb_cf.Banco_Dados).BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('D', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                                "where x.id_caixa = a.id_caixa " +
                                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + p.Id_vendarapidastr + ")"
                                                }
                                            }, "a.id_caixa");
                        if (obj_caixa != null)
                            throw new Exception("Não é permitido excluir venda de um caixa operacional AUDITADO ou PROCESSADO.\r\n" +
                                                "Caixa Operacional Nº" + obj_caixa.ToString());

                        //busca cupom restaurante
                        Restaurante.TCN_ItensPreVenda_X_ItensCupom.Buscar(p.Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          p.Id_vendarapidastr,
                                                                          string.Empty,
                                                                          qtb_cf.Banco_Dados)
                        .ForEach(o => Restaurante.TCN_ItensPreVenda_X_ItensCupom.Excluir(o, qtb_cf.Banco_Dados));

                        //Excluir venda rapida x orcamento
                        TList_VendaRapida_X_Orcamento lOrc =
                            TCN_VendaRapida_X_Orcamento.Buscar(p.Cd_empresa,
                                                               p.Id_vendarapidastr,
                                                               string.Empty,
                                                               string.Empty,
                                                               string.Empty,
                                                               qtb_cf.Banco_Dados);
                        if (lOrc.Count > 0)
                        {
                            //Alterar status do orcamento
                            CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento rOrc =
                            Orcamento.TCN_Orcamento.Buscar(lOrc[0].Nr_orcamento.Value.ToString(),
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
                                                           decimal.Zero,
                                                           decimal.Zero,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           false,
                                                           false,
                                                           string.Empty,
                                                           string.Empty,
                                                           false,
                                                           false,
                                                           qtb_cf.Banco_Dados)[0];
                            rOrc.lParcelas = Orcamento.TCN_Orcamento_DT_Vencto.Buscar(rOrc.Nr_orcamentostr, qtb_cf.Banco_Dados);
                            rOrc.St_registro = "AB";//Aberto
                            Orcamento.TCN_Orcamento.Gravar(rOrc, qtb_cf.Banco_Dados);
                            //Excluir orcamento x venda rapida
                            lOrc.ForEach(v => TCN_VendaRapida_X_Orcamento.Excluir(v, qtb_cf.Banco_Dados));
                        }
                        //Excluir cupom x venda rapida
                        TCN_Cupom_X_VendaRapida.Buscar(string.Empty,
                                                       p.Cd_empresa,
                                                       p.Id_vendarapidastr,
                                                       qtb_cf.Banco_Dados).ForEach(v => TCN_Cupom_X_VendaRapida.Excluir(v, qtb_cf.Banco_Dados));
                        //Excluir pedido x venda rapida
                        TCN_Pedido_X_VendaRapida.Buscar(p.Id_vendarapidastr,
                                                        p.Cd_empresa,
                                                        string.Empty,
                                                        qtb_cf.Banco_Dados).ForEach(v =>
                                                            {
                                                                //Cancelar pedido
                                                                Pedido.TCN_Pedido.Deleta_Pedido(
                                                                    new CamadaDados.Faturamento.Pedido.TRegistro_Pedido()
                                                                    {
                                                                        Nr_pedido = v.Nr_pedido.Value
                                                                    }, qtb_cf.Banco_Dados);
                                                                //Excluir pedido x venda rapida
                                                                TCN_Pedido_X_VendaRapida.Excluir(v, qtb_cf.Banco_Dados);
                                                            });
                        //Excluir Cupom X Centro Resultado
                        TCN_Cupom_X_CCusto.Buscar(p.Id_vendarapidastr,
                                                  p.Cd_empresa,
                                                  string.Empty,
                                                  qtb_cf.Banco_Dados).ForEach(v =>
                                                      {
                                                          //Excluir Cupom X Centro Resultado
                                                          TCN_Cupom_X_CCusto.Excluir(v, qtb_cf.Banco_Dados);
                                                          //Cancelar lancamento centro resultado
                                                          TCN_LanCCustoLancto.Excluir(
                                                              new TRegistro_LanCCustoLancto { Id_ccustolan = v.Id_ccustolan }, qtb_cf.Banco_Dados);
                                                      });
                        //Cancelar caixa
                        TList_Cupom_X_MovCaixa lMovCaixa = TCN_Cupom_X_MovCaixa.Buscar(string.Empty,
                                                                                       p.Id_vendarapidastr,
                                                                                       p.Cd_empresa,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       qtb_cf.Banco_Dados);
                        lMovCaixa.ForEach(v =>
                            {
                                if (!string.IsNullOrEmpty(v.Cd_lanctocaixastr))
                                {
                                    //Buscar lancamento de caixa
                                    TList_LanCaixa lCaixa = TCN_LanCaixa.Busca(v.Cd_contager,
                                                                               v.Cd_lanctocaixastr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               "N",
                                                                               false,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               false,
                                                                               qtb_cf.Banco_Dados);
                                    if (lCaixa.Count > 0)
                                        TCN_LanCaixa.EstornarCaixa(lCaixa[0], null, qtb_cf.Banco_Dados);
                                }
                                //Estornar caixa troco
                                if (!string.IsNullOrEmpty(v.Cd_lanctocaixa_trocostr))
                                {
                                    TList_LanCaixa lCaixa = TCN_LanCaixa.Busca(v.Cd_contager,
                                                                               v.Cd_lanctocaixa_trocostr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               decimal.Zero,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               "N",
                                                                               false,
                                                                               string.Empty,
                                                                               decimal.Zero,
                                                                               false,
                                                                               qtb_cf.Banco_Dados);
                                    if (lCaixa.Count > 0)
                                        TCN_LanCaixa.EstornarCaixa(lCaixa[0], null, qtb_cf.Banco_Dados);
                                }
                                //Cheque Troco
                                TCN_TrocoCH.Buscar(string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   v.Id_movimentostr,
                                                   null).ForEach(x => TCN_TrocoCH.Excluir(x, qtb_cf.Banco_Dados));
                                CamadaDados.PostoCombustivel.TList_CartaFrete lCartaF = null;
                                //Excluir carta frete
                                if (v.Id_cartafrete.HasValue)
                                {
                                    lCartaF = PostoCombustivel.TCN_CartaFrete.Buscar(v.Cd_empresa,
                                                                                     v.Id_cartafretestr,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     qtb_cf.Banco_Dados);
                                }
                                if (v.Id_adto.HasValue)
                                {
                                    TList_LanAdiantamento ladiantamento = new TCD_LanAdiantamento(qtb_cf.Banco_Dados).Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo =  "a.id_adto",
                                                    vOperador= "=",
                                                    vVL_Busca = v.Id_adto.ToString()
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo =  "a.cd_empresa",
                                                    vOperador= "=",
                                                    vVL_Busca = v.Cd_empresa.ToString()
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo =  "a.cd_contager",
                                                    vOperador= "=",
                                                    vVL_Busca = v.Cd_contager.ToString()
                                                }
                                            }, 0, string.Empty);
                                    if (ladiantamento.Count > 0)
                                        TCN_LanAdiantamento.Excluir(ladiantamento[0], qtb_cf.Banco_Dados);
                                }
                                //Excluir Cupom X MovCaixa
                                //Código comentado por causa do cancelamento da venda Ticket Nº 5996 29/06/2017
                                //TCN_Cupom_X_MovCaixa.Excluir(v, qtb_cf.Banco_Dados);
                                if (lCartaF != null)
                                    lCartaF.ForEach(x => PostoCombustivel.TCN_CartaFrete.Excluir(x, qtb_cf.Banco_Dados));
                            });
                        //Cancelar estoque
                        TList_CupomFiscal_Item_X_Estoque lEstoque =
                            TCN_CupomFiscal_Item_X_Estoque.Buscar(p.Id_vendarapidastr, p.Cd_empresa, string.Empty, qtb_cf.Banco_Dados);
                        lEstoque.ForEach(v =>
                            {
                                CamadaDados.Estoque.TList_RegLanEstoque lEst =
                                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_cf.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + v.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + v.Cd_produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lanctoestoque",
                                            vOperador = "=",
                                            vVL_Busca = v.Id_lanctoestoque.Value.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
                                if (lEst.Count > 0)
                                    Estoque.TCN_LanEstoque.CancelarEstoque(lEst[0], qtb_cf.Banco_Dados);
                                //Excluir Cupom X Estoque
                                //Código comentado por causa do cancelamento da venda Ticket Nº 5996 29/06/2017
                                //TCN_CupomFiscal_Item_X_Estoque.Excluir(v, qtb_cf.Banco_Dados);
                            });
                        //Buscar lista duplicata para cancelar
                        TList_CupomFiscal_X_Duplicata lCfDup = TCN_CupomFiscal_X_Duplicata.Buscar(p.Id_vendarapidastr,
                                                                                                  p.Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  qtb_cf.Banco_Dados);
                        //Excluir Cupom X Duplicata
                        //Código comentado por causa do cancelamento da venda Ticket Nº 5996 29/06/2017
                        //lCfDup.ForEach(v => TCN_CupomFiscal_X_Duplicata.Excluir(v, qtb_cf.Banco_Dados));
                        //Buscar lista de dev credito para cancelar
                        TList_Cupom_X_DevCredito lDevCredito = TCN_Cupom_X_DevCredito.Buscar(string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             p.Id_vendarapidastr,
                                                                                             p.Cd_empresa,
                                                                                             string.Empty,
                                                                                             qtb_cf.Banco_Dados);
                        //Excluir Cupom X DevCredito
                        lDevCredito.ForEach(v => TCN_Cupom_X_DevCredito.Excluir(v, qtb_cf.Banco_Dados));
                        //Buscar itens da venda rapida
                        TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr, p.Cd_empresa, false, string.Empty, qtb_cf.Banco_Dados)
                            .ForEach(v => TCN_VendaRapida_Item.Excluir(v, qtb_cf.Banco_Dados));
                        //Excluir venda rapida x entrega futura
                        TCN_VendaRapida_X_EntregaFutura.Buscar(p.Cd_empresa,
                                                               string.Empty,
                                                               string.Empty,
                                                               p.Id_vendarapidastr,
                                                               string.Empty,
                                                               qtb_cf.Banco_Dados).ForEach(v => TCN_VendaRapida_X_EntregaFutura.Excluir(v, qtb_cf.Banco_Dados));
                        //Excluir pontos fidelizacao
                        Fidelizacao.TCN_PontosFidelidade.Buscar(p.Cd_empresa,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                p.Id_vendarapidastr,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                qtb_cf.Banco_Dados).ForEach(v =>
                                                                    {
                                                                        v.LoginCanc = p.LoginCancPontos;
                                                                        Fidelizacao.TCN_PontosFidelidade.Excluir(v, qtb_cf.Banco_Dados);
                                                                    });

                        //Excluir cupom
                        p.LoginCanc = Parametros.pubLogin;
                        p.St_registro = "C";
                        qtb_cf.Gravar(p);
                        //Cancelar duplicata
                        lCfDup.ForEach(v =>
                        {
                            TCN_LanDuplicata.Busca(v.Cd_empresa,
                                                   v.Nr_lancto.Value.ToString(),
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
                                                   "A",
                                                   string.Empty,
                                                   string.Empty,
                                                   false,
                                                   0,
                                                   string.Empty,
                                                   qtb_cf.Banco_Dados)
                                                   .ForEach(x => TCN_LanDuplicata.CancelarDuplicata(x, qtb_cf.Banco_Dados));
                        });
                        //Cancelar caixa devolucao credito
                        lDevCredito.ForEach(v =>
                            {
                                //Buscar Caixa
                                TList_LanCaixa lCaixa = TCN_LanCaixa.Busca(v.Cd_contager,
                                                                           v.Cd_lanctocaixastr,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           decimal.Zero,
                                                                           decimal.Zero,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           "N",
                                                                           false,
                                                                           string.Empty,
                                                                           decimal.Zero,
                                                                           false,
                                                                           qtb_cf.Banco_Dados);
                                if (lCaixa.Count > 0)
                                    TCN_LanCaixa.EstornarCaixa(lCaixa[0], null, qtb_cf.Banco_Dados);
                                //Buscar caixa devolucao
                                lCaixa = TCN_LanCaixa.Busca(v.Cd_contager,
                                                            v.Cd_lanctocaixa_devstr,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            decimal.Zero,
                                                            decimal.Zero,
                                                            string.Empty,
                                                            string.Empty,
                                                            "N",
                                                            false,
                                                            string.Empty,
                                                            decimal.Zero,
                                                            false,
                                                            qtb_cf.Banco_Dados);
                                if (lCaixa.Count > 0)
                                    TCN_LanCaixa.EstornarCaixa(lCaixa[0], null, qtb_cf.Banco_Dados);
                            });
                    });
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static string BuscarPlacaKM(string Cd_empresa,
                                           string Id_cupom,
                                           BancoDados.TObjetoBanco banco)
        {
            TCD_VendaRapida qtb_cf = new TCD_VendaRapida(banco);
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", Cd_empresa);
            hs.Add("@P_ID_CUPOM", Id_cupom);
            hs.Add("@P_ST_CUPOM", "N");
            return CamadaDados.TDataQuery.getPubVariavel(qtb_cf.executarProc("F_PDV_PLACAKMECF", hs), "@RETURN_VALUE");
        }

        public static void TrocarVendedor(string Cd_vendedor,
                                          List<TRegistro_VendaRapida> lVenda,
                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida qtb_vr = new TCD_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else qtb_vr.Banco_Dados = banco;
                //Trocar Vendedor da Venda
                List<TRegistro_VendaRapida_Item> lItem = new List<TRegistro_VendaRapida_Item>();
                lVenda.ForEach(p =>
                    {
                        TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                    p.Cd_empresa,
                                                    false,
                                                    string.Empty,
                                                    qtb_vr.Banco_Dados).ForEach(v =>
                                                        {
                                                            v.Cd_vendedor = Cd_vendedor;
                                                            lItem.Add(v);
                                                            System.Collections.Hashtable hs = new System.Collections.Hashtable();
                                                            hs.Add("@P_CD_VENDEDOR", Cd_vendedor);
                                                            hs.Add("@P_CD_EMPRESA", v.Cd_empresa);
                                                            hs.Add("@P_ID_VENDARAPIDA", v.Id_vendarapida);
                                                            hs.Add("@P_ID_LANCTOVENDA", v.Id_lanctovenda);
                                                            qtb_vr.executarSql("update tb_pdv_vendarapida_item set cd_vendedor = @P_CD_VENDEDOR, dt_alt = getdate() " +
                                                                               "where cd_empresa = @P_CD_EMPRESA and id_vendarapida = @P_ID_VENDARAPIDA and id_lanctovenda = @P_ID_LANCTOVENDA", hs);
                                                        });
                    });
                //Reprocessar comissão
                Comissao.TCN_Fechamento_Comissao.ReprocessarComissao(null,
                                                                     lItem,
                                                                     null,
                                                                     null,
                                                                     null,
                                                                     null,
                                                                     null,
                                                                     qtb_vr.Banco_Dados);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro trocar vendedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }
    }

    public class TCN_VendaRapida_Item
    {
        public static TList_VendaRapida_Item Buscar(string Id_vendarapida,
                                                    string Cd_empresa,
                                                    bool St_saldoDev,
                                                    string St_registro,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_vendarapida))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vendarapida;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (St_saldoDev)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.quantidade - a.qtd_devolvida";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_VendaRapida_Item(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_VendaRapida_Item val,
                                    bool St_estoque,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_Item qtb_item = new TCD_VendaRapida_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                val.Id_lanctovenda = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_item.Gravar(val), "@P_ID_LANCTOVENDA"));
                //Receber venda combustivel
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_item.Banco_Dados).ProdutoCombustivel(val.Cd_produto))
                {
                    if (val.rVendaCombustivel != null)
                    {
                        //Verificar se abastecida já foi faturada
                        object cupom = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel(qtb_item.Banco_Dados).BuscarEscalar(
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
                                    vNM_Campo = "a.id_venda",
                                    vOperador = "=",
                                    vVL_Busca = val.rVendaCombustivel.Id_vendastr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "is not",
                                    vVL_Busca = "null"
                                }
                                }, "a.id_cupom");
                        if (cupom == null ? false : !string.IsNullOrEmpty(cupom.ToString()))
                            throw new Exception("Abastecida já está faturada Nº Venda: " + cupom.ToString());
                        val.rVendaCombustivel.Id_cupom = val.Id_vendarapida;
                        val.rVendaCombustivel.Id_lancto = val.Id_lanctovenda;
                        val.rVendaCombustivel.Cd_empresa = val.Cd_empresa;
                        PostoCombustivel.TCN_VendaCombustivel.ReceberVendaCombustivel(val.rVendaCombustivel, qtb_item.Banco_Dados);
                    }
                    else
                        throw new Exception("Venda com Item Combustível " + val.Ds_produto.Trim() + " não possui abastecida!");
                }
                //Gravar Item Cupom X Venda Rapida pelo delivery - venda é gerada depois do cupom
                //Amarração só será realizada se já existe cupom emitido 
                //todo aqui
                if (val.rItemVRDelivery != null ? val.rItemVRDelivery.Id_cupom != null : false)
                {
                    val.rItemVRDelivery.Cd_empresa = val.Cd_empresa;
                    val.rItemVRDelivery.Id_vendarapida = val.Id_vendarapida;
                    val.rItemVRDelivery.Id_lanctovenda = val.Id_lanctovenda;
                    TCN_Cupom_X_VendaRapida.Gravar(val.rItemVRDelivery, qtb_item.Banco_Dados);
                }
                //Gravar Troca Item 
                val.lTrocaItem.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_cupom = val.Id_vendarapida;
                    TCN_TrocaItem.Gravar(p, qtb_item.Banco_Dados);
                });
                //Verificar se item teve origem pre venda com romaneio de entrega
                object obj = new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio(qtb_item.Banco_Dados).BuscarEscalar(
                               new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_PDV_ItensPreVenda x " +
                                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                                    "on x.cd_empresa = y.cd_empresa " +
                                                    "and x.id_prevenda = y.id_prevenda " +
                                                    "and x.id_itemprevenda = y.id_itemprevenda " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.ID_PreVenda = a.id_prevenda " +
                                                    "and x.ID_ItemPreVenda = a.id_itemprevenda " +
                                                    "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                    "and y.id_cupom = " + val.Id_vendarapida.Value.ToString() + " " +
                                                    "and y.id_lancto = " + val.Id_lanctovenda.Value.ToString() + ")"
                                    }
                                }, "a.quantidade");
                if (obj == null || decimal.Parse(obj.ToString()) < val.Quantidade)
                {
                    if (St_estoque &&
                        (new TCD_CupomFiscal_Item_X_Estoque(qtb_item.Banco_Dados).BuscarEscalar(
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
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = val.Id_vendarapida.Value.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_lancto",
                                    vOperador = "=",
                                    vVL_Busca = val.Id_lanctovenda.Value.ToString()
                                }
                            }, "1") == null))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_item.Banco_Dados).ProdutoComposto(val.Cd_produto) &&
                             !new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_item.Banco_Dados).ProdutoPatrimonio(val.Cd_produto))
                        {

                            //Gravar estoque
                            CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                            rEstoque.Cd_empresa = val.Cd_empresa;
                            rEstoque.Cd_produto = val.Cd_produto;
                            rEstoque.Cd_local = val.Cd_local;
                            rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_item.Banco_Dados);
                            rEstoque.Tp_movimento = "S";
                            rEstoque.Qtd_entrada = decimal.Zero;
                            rEstoque.Qtd_saida = obj != null ? val.Quantidade - decimal.Parse(obj.ToString()) : val.Quantidade;
                            rEstoque.Vl_unitario = val.Vl_unitario;
                            rEstoque.Vl_subtotal = obj != null ? val.Quantidade - decimal.Parse(obj.ToString()) * val.Vl_unitario : val.Vl_subtotal;
                            rEstoque.Tp_lancto = "N";
                            val.lGrade.ForEach(p => rEstoque.lGrade.Add(p));

                            string retestoque = Estoque.TCN_LanEstoque.GravarEstoque(rEstoque, qtb_item.Banco_Dados);
                            //Gravar Item PDV X Estoque
                            TCN_CupomFiscal_Item_X_Estoque.Gravar(
                                new TRegistro_CupomFiscal_Item_X_Estoque()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Cd_produto = val.Cd_produto,
                                    Id_cupom = val.Id_vendarapida,
                                    Id_lancto = val.Id_lanctovenda,
                                    Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retestoque, "@@P_ID_LANCTOESTOQUE"))
                                }, qtb_item.Banco_Dados);
                        }
                        else
                        {
                            //Buscar ficha tecnica produto composto
                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                Estoque.Cadastros.TCN_FichaTecProduto.Buscar(val.Cd_produto, string.Empty, qtb_item.Banco_Dados);
                            lFicha.ForEach(p => p.Quantidade = p.Quantidade * (obj != null ? val.Quantidade - decimal.Parse(obj.ToString()) : val.Quantidade));
                            Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, qtb_item.Banco_Dados);
                            lFicha.ForEach(p =>
                                {
                                    //Gravar estoque
                                    string retestoque = CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(
                                        new CamadaDados.Estoque.TRegistro_LanEstoque()
                                        {
                                            Cd_empresa = val.Cd_empresa,
                                            Cd_produto = p.Cd_item,
                                            Cd_local = val.Cd_local,
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Tp_movimento = "S",
                                            Qtd_entrada = decimal.Zero,
                                            Qtd_saida = p.Quantidade,
                                            Vl_unitario = val.Vl_unitario,
                                            Vl_subtotal = p.Quantidade * val.Vl_unitario,
                                            Tp_lancto = "N"
                                        }, qtb_item.Banco_Dados);
                                    //Gravar Item PDV X Estoque
                                    TCN_CupomFiscal_Item_X_Estoque.Gravar(
                                        new TRegistro_CupomFiscal_Item_X_Estoque()
                                        {
                                            Cd_empresa = val.Cd_empresa,
                                            Cd_produto = p.Cd_item,
                                            Id_cupom = val.Id_vendarapida,
                                            Id_lancto = val.Id_lanctovenda,
                                            Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retestoque, "@@P_ID_LANCTOESTOQUE"))
                                        }, qtb_item.Banco_Dados);
                                });
                        }
                    }
                }

                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_lanctovenda.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void Gravar(TRegistro_VendaRapida_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_Item qtb_item = new TCD_VendaRapida_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                val.Id_lanctovenda = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_item.Gravar(val), "@P_ID_LANCTOVENDA"));
                //Gravar Item Venda Mesa X Item Venda Rapida
                if (val.rItensVendaMesaConv != null)
                    PostoCombustivel.TCN_VendaMesa_X_VendaRapida.Gravar(
                        new CamadaDados.PostoCombustivel.TRegistro_VendaMesa_X_VendaRapida()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Id_venda = val.rItensVendaMesaConv.Id_venda,
                            Id_item = val.rItensVendaMesaConv.Id_item
                        }, qtb_item.Banco_Dados);
                //Gravar Item OS X Venda Rapida
                if (val.rItemOS != null)
                    PostoCombustivel.TCN_Ordem_X_VendaRapida.Gravar(
                        new CamadaDados.PostoCombustivel.TRegistro_Ordem_X_VendaRapida()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Id_ordem = val.rItemOS.Id_ordem,
                            Id_item = val.rItemOS.Id_item
                        }, qtb_item.Banco_Dados);
                //Gravar Item Pre Venda X Venda Rapida
                if (val.rItemPreVenda != null)
                    TCN_PreVenda_X_VendaRapida.Gravar(
                        new TRegistro_PreVenda_X_VendaRapida()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Id_prevenda = val.rItemPreVenda.Id_prevenda,
                            Id_itemprevenda = val.rItemPreVenda.Id_itemprevenda
                        }, qtb_item.Banco_Dados);
                //Gravar Item Orcamento X Venda Rapida
                if (val.rItemOrcamento != null)
                    TCN_VendaRapida_X_Orcamento.Gravar(

                        new TRegistro_VendaRapida_X_Orcamento()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Nr_orcamento = val.rItemOrcamento.Nr_orcamento,
                            Id_item = val.rItemOrcamento.Id_item
                        }, qtb_item.Banco_Dados);
                //Gravar Item Condicional X Venda Rapida
                if (val.rItemCond != null)
                    TCN_ItensCondicional_X_VendaRapida.Gravar(
                        new TRegistro_ItensCondicional_X_VendaRapida()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_cupom = val.Id_vendarapida,
                            Id_lancto = val.Id_lanctovenda,
                            Id_condicional = val.rItemCond.Id_condicional,
                            Id_item = val.rItemCond.Id_item
                        }, qtb_item.Banco_Dados);
                //Gravar Lote Anvisa
                val.lMovLoteAnvisa.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_cupom = val.Id_vendarapida;
                        p.Id_lancto = val.Id_lanctovenda;
                        LoteAnvisa.TCN_MovLoteAnvisa.Gravar(p, qtb_item.Banco_Dados);
                    });
                //Processar Comissao
                ProcessarComissao(val, qtb_item.Banco_Dados);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaRapida_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_Item qtb_item = new TCD_VendaRapida_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                //Verificar se o item esta amarrado a um abastecimento
                new CamadaDados.PostoCombustivel.TCD_VendaCombustivel(qtb_item.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapida.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Id_lanctovenda.Value.ToString()
                        }
                    }, 0, string.Empty, string.Empty).ForEach(p =>
                    {
                        p.Id_cupom = null;
                        p.Id_lancto = null;
                        p.St_registro = "A";
                        p.Placaveiculo = string.Empty;
                        p.Km_atual = decimal.Zero;
                        p.Nm_motorista = string.Empty;
                        p.Nr_frota = string.Empty;
                        PostoCombustivel.TCN_VendaCombustivel.Gravar(p, qtb_item.Banco_Dados);
                    });
                //Verificar se o item esta amarrado a um item venda mesa
                PostoCombustivel.TCN_VendaMesa_X_VendaRapida.Buscar(string.Empty,
                                                                    val.Cd_empresa,
                                                                    string.Empty,
                                                                    val.Id_lanctovenda.Value.ToString(),
                                                                    val.Id_vendarapida.Value.ToString(),
                                                                    qtb_item.Banco_Dados).ForEach(p =>
                                                                                      PostoCombustivel.TCN_VendaMesa_X_VendaRapida.Excluir(p, qtb_item.Banco_Dados));
                //Verificar se o item esta amarrado ao um item OS
                PostoCombustivel.TCN_Ordem_X_VendaRapida.Buscar(val.Cd_empresa,
                                                                string.Empty,
                                                                string.Empty,
                                                                val.Id_vendarapida.Value.ToString(),
                                                                val.Id_lanctovenda.Value.ToString(),
                                                                qtb_item.Banco_Dados).ForEach(p =>
                                                                    PostoCombustivel.TCN_Ordem_X_VendaRapida.Excluir(p, qtb_item.Banco_Dados));
                //Verificar se o item esta amarrado a um item Pre Venda
                TCN_PreVenda_X_VendaRapida.Buscar(val.Cd_empresa,
                                                  string.Empty,
                                                  string.Empty,
                                                  val.Id_vendarapida.Value.ToString(),
                                                  val.Id_lanctovenda.Value.ToString(),
                                                  qtb_item.Banco_Dados).ForEach(p => TCN_PreVenda_X_VendaRapida.Excluir(p, qtb_item.Banco_Dados));
                //Verificar se o item esta amarrado a um item Condicional
                TCN_ItensCondicional_X_VendaRapida.Buscar(val.Cd_empresa,
                                                          string.Empty,
                                                          val.Id_vendarapida.Value.ToString(),
                                                          val.Id_lanctovenda.Value.ToString(),
                                                          qtb_item.Banco_Dados).ForEach(p => TCN_ItensCondicional_X_VendaRapida.Excluir(p, qtb_item.Banco_Dados));
                //Verificar se o item esta amarrado a um abast item - módulo locação
                CamadaNegocio.Locacao.TCN_AbastItens_X_NFCeItens.buscar(val.Cd_empresa,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        val.Id_vendarapida.ToString(),
                                                                        val.Id_lanctovenda.ToString(),
                                                                        qtb_item.Banco_Dados).ForEach(p => CamadaNegocio.Locacao.TCN_AbastItens_X_NFCeItens.Excluir(p, qtb_item.Banco_Dados));
                //Excluir comissao
                if (new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_item.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapida.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Id_lanctovenda.Value.ToString()
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
                    throw new Exception("Item possui comissão faturada.\r\n" +
                                        "Para cancelar item é necessário antes cancelar a duplicata de pagamento comissão.");
                Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                        val.Cd_empresa,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        val.Id_vendarapida.Value.ToString(),
                                                        val.Id_lanctovenda.Value.ToString(),
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
                                                        string.Empty,
                                                        qtb_item.Banco_Dados).ForEach(p =>
                                                                                      Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados));
                //Buscar Devolução
                TCN_Devolucao.Buscar(val.Cd_empresa,
                                     string.Empty,
                                     val.Id_vendarapida.ToString(),
                                     string.Empty,
                                     string.Empty,
                                     string.Empty,
                                     true,
                                     qtb_item.Banco_Dados).ForEach(p => TCN_Devolucao.Excluir(p, qtb_item.Banco_Dados));
                //Excluir resgate pontos
                new CamadaDados.Faturamento.Fidelizacao.TCD_ResgatePontos(qtb_item.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapida.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Id_lanctovenda.Value.ToString()
                        }
                    }, 0, string.Empty).ForEach(p => Fidelizacao.TCN_ResgatePontos.Excluir(p, qtb_item.Banco_Dados));
                //Excluir Lotes Anvisa
                new CamadaDados.Faturamento.LoteAnvisa.TCD_MovLoteAnvisa(qtb_item.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapida.Value.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Id_lanctovenda.Value.ToString()
                        }
                    }, 0, string.Empty).ForEach(p => LoteAnvisa.TCN_MovLoteAnvisa.Excluir(p, qtb_item.Banco_Dados));
                val.St_registro = "C";
                qtb_item.Gravar(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void CancelarItem(TRegistro_VendaRapida_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_Item qtb_item = new TCD_VendaRapida_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_item.Gravar(val);
                //Cancelar estoque
                CamadaDados.Estoque.TList_RegLanEstoque lEstoque =
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_item.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_item_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_cupom = " + val.Id_vendarapida.Value.ToString() + " " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_lancto = " + val.Id_lanctovenda.Value.ToString() + ")"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                lEstoque.ForEach(p =>
                    {
                        p.St_registro = "C";
                        Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_item.Banco_Dados);
                    });
                //Excluir comissao
                if (new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao(qtb_item.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = val.Id_vendarapida.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_lancto",
                            vOperador = "=",
                            vVL_Busca = val.Id_lanctovenda.Value.ToString()
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
                    throw new Exception("Item possui comissão faturada.\r\n" +
                                        "Para cancelar item é necessário antes cancelar a duplicata de pagamento comissão.");
                Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                        val.Cd_empresa,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        val.Id_vendarapida.Value.ToString(),
                                                        val.Id_lanctovenda.Value.ToString(),
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
                                                        string.Empty,
                                                        qtb_item.Banco_Dados).ForEach(p =>
                                                            Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados));
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar item venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void ProcessarComissao(TRegistro_VendaRapida_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_Item qtb_item = new TCD_VendaRapida_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                //Verificar se ja existe comissao
                CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao lComissao =
                    Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                            val.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            val.Id_vendarapida.Value.ToString(),
                                                            val.Id_lanctovenda.Value.ToString(),
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
                                                            string.Empty,
                                                            qtb_item.Banco_Dados);
                if (lComissao.Count > 0)
                {
                    //Verificar se comissao possui faturamento
                    lComissao.ForEach(p =>
                        {
                            if (new CamadaDados.Faturamento.Comissao.TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_comissao = x.id_comissao " +
                                                        "and x.id_cupom = " + val.Id_vendarapida +
                                                        "and x.Id_lancto = " + val.Id_lanctovenda + ")"
                                        }
                                    }, "1") == null)
                                Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_item.Banco_Dados);
                            else
                                throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                        });
                }
                if (!string.IsNullOrEmpty(val.Cd_vendedor))
                {
                    //Verificar devolucao
                    decimal vl_basecalc = val.Vl_subtotalliquido - (val.Qtd_devolvida * (val.Vl_subtotalliquido / val.Quantidade));
                    decimal pc_comissao = decimal.Zero;
                    object obj = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(qtb_item.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and x.id_cupom = " + val.Id_vendarapida.Value.ToString() + ")"
                                        }
                                    }, "a.cd_condpgto");
                    string Cd_condpgto = obj == null ? string.Empty : obj.ToString();
                    string tp_comissao = "P";
                    decimal vl_comissao = Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                            val.Cd_vendedor,
                                                                                            val.Cd_tabelapreco,
                                                                                            Cd_condpgto,
                                                                                            val.Cd_produto,
                                                                                            val.Quantidade,
                                                                                            ref vl_basecalc,
                                                                                            ref pc_comissao,
                                                                                            ref tp_comissao,
                                                                                            qtb_item.Banco_Dados);

                    if (vl_comissao > decimal.Zero)
                    {
                        //Gravar fechamento comissao
                        Comissao.TCN_Fechamento_Comissao.Gravar(
                            new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_vendedor = val.Cd_vendedor,
                                Cd_representante = val.Cd_representante,
                                Dt_lancto = val.Dt_emissao.HasValue ? val.Dt_emissao : CamadaDados.UtilData.Data_Servidor(qtb_item.Banco_Dados),
                                Id_cupom = val.Id_vendarapida,
                                Id_lancto = val.Id_lanctovenda,
                                Tp_comissao = tp_comissao,
                                Pc_comissao = pc_comissao,
                                Vl_basecalc = vl_basecalc,
                                Vl_comissao = vl_comissao
                            }, qtb_item.Banco_Dados);
                    }
                    if (st_transacao)
                        qtb_item.Banco_Dados.Commit_Tran();
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        /// summary
        /// Este método tem a finalidade de validar se a quantidade informada consiste na 
        /// quantidade vendida na venda rapida.
        public static bool ValidarQuantidadeItemGrade(TRegistro_VendaRapida registro_VendaRapida, TRegistro_VendaRapida_Item registro_VendaRapida_Item, CamadaDados.Estoque.Cadastros.TRegistro_ValorCaracteristica registro_ValorCaracteristica, object value)
        {
            if (registro_VendaRapida == null ||
                registro_VendaRapida_Item == null ||
                value == null ||
                string.IsNullOrEmpty(value.ToString().SoNumero()) ||
                registro_ValorCaracteristica == null)
                return false;

            var qtdVendida = new TCD_VendaRapida_Item().executarEscalar("select xx1.quantidade " +
                "from TB_PDV_CupomFiscal_Item_X_Estoque xxx " +
                "inner join tb_est_gradeestoque xx1 " +
                "on xxx.Id_LanctoEstoque = xx1.Id_LanctoEstoque " +
                "where xxx.Id_Cupom = " + registro_VendaRapida.Id_vendarapidastr + " " +
                "and xx1.ID_Caracteristica = " + registro_ValorCaracteristica.Id_caracteristicastr + " " +
                "and xx1.ID_Item = " + registro_ValorCaracteristica.Id_item + " " +
                "and xxx.cd_produto = " + registro_VendaRapida_Item.Cd_produto + " " +
                "and xxx.CD_Empresa = " + registro_VendaRapida_Item.Cd_empresa + " ", null);

            if (qtdVendida == null || Convert.ToDecimal(qtdVendida) != Convert.ToDecimal(value))
                return false;

            return true;
        }
    }

    public class TCN_NFCe
    {
        public static TList_NFCe Buscar(string Id_nfce,
                                        string Nr_nfce,
                                        string Cd_empresa,
                                        string Id_pdv,
                                        string Nm_clifor,
                                        string Dt_ini,
                                        string Dt_fin,
                                        decimal Vl_ini,
                                        decimal Vl_fin,
                                        string Cd_produto,
                                        string Nr_requisicao,
                                        string Nr_serie,
                                        string Id_contingencia,
                                        bool St_transmitidonfce,
                                        string Id_venda,
                                        string St_registro,
                                        int vTop,
                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_nfce))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfce;
            }
            if (!string.IsNullOrEmpty(Nr_nfce))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_nfce;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_clifor.Trim() + "%')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /       :") && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Dt_ini + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /       :") && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + (Dt_fin) + "'";
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(select ISNULL(SUM(ISNULL(x.Vl_SubTotal, 0) + ISNULL(x.Vl_Acrescimo, 0) - ISNULL(x.Vl_Desconto, 0)), 0) " +
                                                      "from TB_PDV_NFCe_Item x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.Id_NFCe = a.Id_NFCe " +
                                                      "and ISNULL(x.ST_Registro, 'A') <> 'C') >= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(select ISNULL(SUM(ISNULL(x.Vl_SubTotal, 0) + ISNULL(x.Vl_Acrescimo, 0) - ISNULL(x.Vl_Desconto, 0)), 0) " +
                                                      "from TB_PDV_NFCe_Item x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.Id_NFCe = a.Id_NFCe " +
                                                      "and ISNULL(x.ST_Registro, 'A') <> 'C') <= " + Vl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_nfce_item x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_nfce = a.id_nfce " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Nr_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_requisicao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_contingencia))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_contingencia";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_contingencia;
            }
            if (St_transmitidonfce)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(lote.NR_Protocolo, 0)";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (!string.IsNullOrEmpty(Id_venda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_cupom = a.id_nfce " +
                                                      "and x.id_vendarapida = " + Id_venda + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_NFCe(banco).Select(filtro, vTop, string.Empty, string.Empty);
        }

        public static TRegistro_NFCe BuscarCupom(string Cd_empresa,
                                                 string Id_nfce,
                                                 BancoDados.TObjetoBanco banco)
        {
            TList_NFCe lCupom = Buscar(Id_nfce,
                                       string.Empty,
                                       Cd_empresa,
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
                                       false,
                                       string.Empty,
                                       string.Empty,
                                       1,
                                       banco);
            if (lCupom.Count > 0)
                return lCupom[0];
            else return null;
        }

        public static TRegistro_NFCe BuscarNFCe(string Cd_empresa,
                                                string Id_nfce,
                                                BancoDados.TObjetoBanco banco,
                                                bool st_delivery = false)
        {
            TList_NFCe lCupom = Buscar(Id_nfce,
                                       string.Empty,
                                       Cd_empresa,
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
                                       false,
                                       string.Empty,
                                       string.Empty,
                                       1,
                                       banco);
            if (lCupom.Count > 0)
            {
                //Buscar Empresa
                lCupom[0].rEmpresa = Diversos.TCN_CadEmpresa.Busca(Cd_empresa, string.Empty, string.Empty, banco)[0];
                //Cliente e Endereco
                if (new TCD_CFGCupomFiscal().BuscarEscalar(
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
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + lCupom[0].Cd_clifor.Trim() + "'"
                            }
                        }, "1") == null)
                {
                    if (!string.IsNullOrEmpty(lCupom[0].Cd_clifor))
                    {
                        lCupom[0].rCliente = TCN_CadClifor.Busca_Clifor_Codigo(lCupom[0].Cd_clifor, banco);
                        if (!string.IsNullOrEmpty(lCupom[0].Cd_endereco))
                            lCupom[0].rEndCli = TCN_CadEndereco.Buscar(lCupom[0].Cd_clifor,
                                                                       lCupom[0].Cd_endereco,
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
                                                                       banco)[0];
                    }
                }
                //Buscar Itens
                lCupom[0].lItem = TCN_NFCe_Item.Buscar(lCupom[0].Id_nfcestr,
                                                       lCupom[0].Cd_empresa,
                                                       string.Empty,
                                                       banco);
                //Buscar Encerrantes do item se Abastecida
                lCupom[0].lItem.Where(p => p.St_combustivel).ToList().ForEach(p =>
                {
                    CamadaDados.PostoCombustivel.TList_VendaCombustivel lVComp =
                                        new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                "and x.id_lanctovenda = a.id_lancto " +
                                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + p.ID_NFCe.Value.ToString() + " " +
                                                                "and x.id_lancto = " + p.Id_lancto.Value.ToString() + ")"
                                                }
                                            }, 0, string.Empty, string.Empty);
                    if (lVComp.Count > 0)
                    {
                        p.NR_Bico = lVComp[0].Id_bicostr;
                        p.EncerranteFin = lVComp[0].Encerrantebico;
                    }
                });
                if (new CamadaDados.Servicos.TCD_Pecas_X_NFCe().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cupom",
                            vOperador = "=",
                            vVL_Busca = lCupom[0].Id_nfcestr
                        }
                    }, "1") != null ||
                    new CamadaDados.Locacao.TCD_AbastItens_X_NFCeItens().BuscarEscalar(
                         new TpBusca[]
                         {
                             new TpBusca()
                             {
                                 vNM_Campo = "a.cd_empresa",
                                 vOperador = "=",
                                 vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                             },
                             new TpBusca()
                             {
                                 vNM_Campo = "a.id_cupom",
                                 vOperador = "=",
                                 vVL_Busca = lCupom[0].Id_nfcestr
                             }
                         }, "1") != null)
                {
                    lCupom[0].lPagto = new List<TRegistro_MovCaixa>() { new TRegistro_MovCaixa() { Tp_portador = "05", Vl_recebido = lCupom[0].Vl_cupom } };
                    lCupom[0].lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
                }
                else
                {
                    if (st_delivery || lCupom[0].st_delivery.Equals("S"))
                    {
                        //Buscar venda cupom
                        object obj = new TCD_Cupom_X_VendaRapida()
                            .BuscarEscalar(new TpBusca[]
                            {
                                new TpBusca
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = lCupom[0].Id_nfcestr
                                }
                            }, "a.id_vendarapida");
                        //Buscar Pagto
                        if (obj != null)
                            lCupom[0].lPagto = new TCD_CaixaPDV().SelectMovCaixa(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca
                                                        {
                                                            vNM_Campo = "a.id_cupom",
                                                            vOperador = "=",
                                                            vVL_Busca = obj.ToString()
                                                        }
                                                    }, string.Empty);
                        //Buscar Dup
                        lCupom[0].lDup = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                "and y.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                                                "and y.id_cupom = " + lCupom[0].Id_nfcestr + ")"
                                                }
                                            }, 1, string.Empty);
                    }
                    else
                    {
                        //Buscar venda cupom
                        object obj = new TCD_Cupom_X_VendaRapida()
                            .BuscarEscalar(new TpBusca[]
                            {
                                new TpBusca
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = lCupom[0].Id_nfcestr
                                }
                            }, "a.id_vendarapida");
                        //Buscar Pagto
                        if (obj != null)
                            lCupom[0].lPagto = new TCD_CaixaPDV().SelectMovCaixa(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca
                                                        {
                                                            vNM_Campo = "a.id_cupom",
                                                            vOperador = "=",
                                                            vVL_Busca = obj.ToString()
                                                        }
                                                    }, string.Empty);
                        //Buscar Dup
                        lCupom[0].lDup = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                "and y.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                                                "and y.id_cupom = " + lCupom[0].Id_nfcestr + ")"
                                                }
                                            }, 1, string.Empty);
                    }
                }
                return lCupom[0];
            }
            else return null;
        }

        public static void GerarCupomDelivery(TRegistro_NFCe val,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe qtb_cf = new TCD_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Gravar cupom fiscal
                val.Id_nfcestr = CamadaDados.TDataQuery.getPubVariavel(qtb_cf.Gravar(val), "@P_ID_NFCE");
                //Gravar Itens do cupom
                val.lItem.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.ID_NFCe = val.Id_nfce;
                    string Id_LanctoNFCe = TCN_NFCe_Item.Gravar(p, qtb_cf.Banco_Dados);
                    //Gravar Item Cupom X Venda Delivery
                    p.lItemVR.ForEach(v =>
                    {
                        CamadaDados.Restaurante.TRegistro_ItensPreVenda_X_ItensCupom rCupom = new CamadaDados.Restaurante.TRegistro_ItensPreVenda_X_ItensCupom();
                        rCupom.Cd_Empresa = !string.IsNullOrEmpty(v.Cd_empresa) ? v.Cd_empresa : p.Cd_empresa;
                        rCupom.Id_PreVenda = v.id_prevenda;
                        rCupom.Id_Item = v.id_item;
                        rCupom.Id_LanctoNFCe = Convert.ToDecimal(Id_LanctoNFCe);
                        rCupom.Id_NFCE = val.Id_nfce.Value;
                        Restaurante.TCN_ItensPreVenda_X_ItensCupom.Gravar(rCupom, qtb_cf.Banco_Dados);
                    });
                });
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar cupom: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }
        public static void GerarCupomVendaRapida(TRegistro_NFCe val,
                                                 BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe qtb_cf = new TCD_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cf.CriarBanco_Dados(true);
                else
                    qtb_cf.Banco_Dados = banco;
                //Gravar cupom fiscal
                val.Id_nfcestr = CamadaDados.TDataQuery.getPubVariavel(qtb_cf.Gravar(val), "@P_ID_NFCE");
                //Gravar Itens do cupom
                val.lItem.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.ID_NFCe = val.Id_nfce;
                    TCN_NFCe_Item.Gravar(p, qtb_cf.Banco_Dados);
                    //Gravar Item Cupom X Venda Rapida
                    p.lItemVR.ForEach(v =>
                    {
                        TCN_Cupom_X_VendaRapida.Gravar(new TRegistro_Cupom_X_VendaRapida()
                        {
                            Id_cupom = p.ID_NFCe,
                            Cd_empresa = p.Cd_empresa,
                            Id_lancto = p.Id_lancto,
                            Id_vendarapida = v.Id_vendarapida,
                            Id_lanctovenda = v.Id_lanctovenda
                        }, qtb_cf.Banco_Dados);
                    });
                    //Gravar Item Cupom X OS
                    p.lPecasOS.ForEach(v =>
                    {
                        Servicos.TCN_Pecas_X_NFCe.Gravar(new CamadaDados.Servicos.TRegistro_Pecas_X_NFCe()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_cupom = p.ID_NFCe,
                            Id_lancto = p.Id_lancto,
                            Id_os = v.Id_os,
                            Id_peca = v.Id_peca
                        }, qtb_cf.Banco_Dados);
                    });
                    //Gravar AbastItens
                    p.lAbastItens.ForEach(v =>
                    {
                        CamadaNegocio.Locacao.TCN_AbastItens_X_NFCeItens.Gravar(
                            new CamadaDados.Locacao.TRegistro_AbastItens_X_NFCeItens()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_loc = v.Id_loc,
                                Id_item = v.Id_item,
                                Id_carga = v.Id_carga,
                                Id_itemcarga = v.Id_itemcarga,
                                Id_cupom = p.ID_NFCe,
                                Id_lancto = p.Id_lancto
                            }, qtb_cf.Banco_Dados);
                    });
                });
                //Gravar Contabilidade
                List<TRegistro_Lan_ProcNFCe> lProcFat =
                TCN_Lan_ProcContabil.BuscaProc_NFCe(val.Cd_empresa,
                                                    val.NR_NFCestr,
                                                    val.Id_nfcestr,
                                                    string.Empty,
                                                    string.Empty,
                                                    false,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    decimal.Zero,
                                                    decimal.Zero,
                                                    qtb_cf.Banco_Dados);
                if (lProcFat.Count > 0)
                    if (lProcFat.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                        TCN_LanContabil.ProcessaCTB_NFCe(lProcFat.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_cf.Banco_Dados);
                //Gravar Contabilidade CMV
                //List<TRegistro_Lan_ProcCMV> lProcCMV =
                //    TCN_Lan_ProcContabil.BuscaProc_CMV(val.Cd_empresa,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       val.Id_nfcestr,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       false,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       string.Empty,
                //                                       decimal.Zero,
                //                                       decimal.Zero,
                //                                       qtb_cf.Banco_Dados);
                //if (lProcCMV.Count > 0)
                //    if (lProcCMV.Exists(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue))
                //        TCN_LanContabil.ProcessaCTB_CMV(lProcCMV.FindAll(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue), qtb_cf.Banco_Dados);
                if (st_transacao)
                    qtb_cf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar cupom: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cf.deletarBanco_Dados();
            }
        }

        public static void CancelarCFdelivery(TRegistro_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe qtb_cupom = new TCD_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                if (val.Cd_modelo.Trim().Equals("65") &&
                    !val.Nr_protocolo.HasValue &&
                    !val.Id_contingencia.HasValue)
                {
                    //busca cupom restaurante
                    Restaurante.TCN_ItensPreVenda_X_ItensCupom.Buscar(val.Cd_empresa,
                                                      string.Empty,
                                                      string.Empty,
                                                      val.Id_nfcestr,
                                                      string.Empty,
                                                      qtb_cupom.Banco_Dados)
                                                      .ForEach(o => Restaurante.TCN_ItensPreVenda_X_ItensCupom.Excluir(o, qtb_cupom.Banco_Dados));
                    qtb_cupom.ExcluirNFCe(val);
                }
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar CF/NFCe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }

        public static void CancelarCF(TRegistro_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe qtb_cupom = new TCD_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cupom.CriarBanco_Dados(true);
                else
                    qtb_cupom.Banco_Dados = banco;
                if (val.Cd_modelo.Trim().Equals("65") &&
                    !val.Nr_protocolo.HasValue &&
                    !val.StatusLote.Equals(104) &&
                    !val.Id_contingencia.HasValue)
                    qtb_cupom.ExcluirNFCe(val);
                else
                {
                    //Cancelar cupom
                    qtb_cupom.executarSql("update tb_pdv_nfce set st_registro = 'C', dt_alt = getdate() where cd_empresa = '" + val.Cd_empresa.Trim() + "' and id_nfce = " + val.Id_nfcestr, null);
                    //Cancelar Itens do Cupom
                    TCN_NFCe_Item.Buscar(val.Id_nfcestr,
                                         val.Cd_empresa,
                                         string.Empty,
                                         qtb_cupom.Banco_Dados)
                                         .ForEach(p => TCN_NFCe_Item.CancelarItemCF(p, qtb_cupom.Banco_Dados));
                    //Excluir Venda Rapida de Origem somente se o caixa estiver aberto
                    TCN_VendaRapida.ExcluirVendaRapida(new TCD_VendaRapida(qtb_cupom.Banco_Dados).Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_PDV_Cupom_X_VendaRapida x " +
                                                                    "inner join tb_pdv_cupom_x_movcaixa y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.id_vendarapida = y.id_cupom " +
                                                                    "inner join VTB_PDV_Caixa k " +
                                                                    "on y.id_caixa = k.id_caixa " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_vendarapida = a.id_vendarapida " +
                                                                    "and isnull(k.st_registro, 'A') in ('A', 'F') " +
                                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + val.Id_nfcestr + ")"
                                                    }
                                                }, 0, string.Empty, string.Empty), qtb_cupom.Banco_Dados);
                }
                if (st_transacao)
                    qtb_cupom.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cupom.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar CF/NFCe: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cupom.deletarBanco_Dados();
            }
        }

        public static string BuscarPlacaKM(string Cd_empresa,
                                           string Id_cupom,
                                           BancoDados.TObjetoBanco banco)
        {
            TCD_VendaRapida qtb_cf = new TCD_VendaRapida(banco);
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", Cd_empresa);
            hs.Add("@P_ID_CUPOM", Id_cupom);
            hs.Add("@P_ST_CUPOM", "S");
            return CamadaDados.TDataQuery.getPubVariavel(qtb_cf.executarProc("F_PDV_PLACAKMECF", hs), "@RETURN_VALUE");
        }
    }

    public class TCN_NFCe_Item
    {
        public static TList_NFCe_Item Buscar(string Id_nfce,
                                             string Cd_empresa,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_nfce))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfce;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_NFCe_Item(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_NFCe_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe_Item qtb_item = new TCD_NFCe_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else qtb_item.Banco_Dados = banco;
                val.Id_lancto = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_item.Gravar(val), "@P_ID_LANCTO"));
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_lancto.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item NFC-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void CancelarItemCF(TRegistro_NFCe_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFCe_Item qtb_item = new TCD_NFCe_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_item.Gravar(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar item NFC-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static void PreencherICMS(TRegistro_ImpostosNF val, TRegistro_NFCe_Item rItem)
        {
            rItem.Cd_icms = val.Cd_imposto;
            rItem.Cd_st_icms = val.Cd_st;
            rItem.Pc_aliquotaICMS = val.Pc_aliquota;
            rItem.Vl_icms = val.Vl_impostocalc;
            rItem.Vl_basecalcICMS = val.Vl_basecalc;
            rItem.Tp_situacao = val.Tp_situacao;
            rItem.Tp_modbasecalc = val.Tp_modbasecalc;
            rItem.Tp_modbasecalcST = val.Tp_modbasecalcST;
        }

        public static void PreencherOutrosImpostos(TList_ImpostosNF impostos, TRegistro_NFCe_Item rItem)
        {
            #region PIS
            if (impostos.Exists(p => p.Imposto.St_PIS))
            {
                TRegistro_ImpostosNF pis = impostos.Find(p => p.Imposto.St_PIS);
                rItem.Cd_pis = pis.Cd_imposto;
                rItem.Cd_st_pis = pis.Cd_st;
                rItem.Id_tpcontribuicaoPIS = pis.Id_tpcontribuicao;
                rItem.Id_detrecisentaPIS = pis.Id_detrecisenta;
                rItem.Id_receitaPIS = pis.Id_receita;
                rItem.Pc_aliquotaPIS = pis.Pc_aliquota;
                rItem.Vl_pis = pis.Vl_impostocalc;
                rItem.Vl_basecalcPIS = pis.Vl_basecalc;
            }
            #endregion

            #region COFINS
            if (impostos.Exists(p => p.Imposto.St_Cofins))
            {
                TRegistro_ImpostosNF cofins = impostos.Find(p => p.Imposto.St_Cofins);
                rItem.Cd_cofins = cofins.Cd_imposto;
                rItem.Cd_st_cofins = cofins.Cd_st;
                rItem.Id_tpcontribuicaoCOFINS = cofins.Id_tpcontribuicao;
                rItem.Id_detrecisentaCofins = cofins.Id_detrecisenta;
                rItem.Id_receitaCofins = cofins.Id_receita;
                rItem.Pc_aliquotaCofins = cofins.Pc_aliquota;
                rItem.Vl_cofins = cofins.Vl_impostocalc;
                rItem.Vl_basecalcCofins = cofins.Vl_basecalc;
            }
            #endregion
        }
    }

    public class TCN_XML_NFCe
    {
        public static TList_XML_NFCe Buscar(string Cd_empresa,
                                            string Id_nfce,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Id_nfce))
                Estruturas.CriarParametro(ref filtro, "a.id_nfce", Id_nfce);
            return new TCD_XML_NFCe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_XML_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_XML_NFCe qtb_reg = new TCD_XML_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else qtb_reg.Banco_Dados = banco;
                val.Id_registrostr = CamadaDados.TDataQuery.getPubVariavel(qtb_reg.Gravar(val), "@P_ID_REGISTRO");
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return val.Id_registrostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar xml: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_XML_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_XML_NFCe qtb_reg = new TCD_XML_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else qtb_reg.Banco_Dados = banco;
                qtb_reg.Excluir(val);
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return val.Id_registrostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir xml: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CupomFiscal_X_Duplicata
    {
        public static TList_CupomFiscal_X_Duplicata Buscar(string Id_cupom,
                                                           string Cd_empresa,
                                                           string Nr_lancto,
                                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_CupomFiscal_X_Duplicata(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_caixa,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
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
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lancto = a.nr_lancto "+
                                        "and x.id_caixa = " + Id_caixa + ")"
                        }
                    }, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDup(string Id_cupom,
                                                                                       string Cd_empresa,
                                                                                       BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(
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
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lancto = a.nr_lancto "+
                                        "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + Id_cupom + ")"
                        }
                    }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CupomFiscal_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CupomFiscal_X_Duplicata qtb_dup = new TCD_CupomFiscal_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                string retorno = qtb_dup.Gravar(val);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CupomFiscal_X_Duplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CupomFiscal_X_Duplicata qtb_dup = new TCD_CupomFiscal_X_Duplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dup.CriarBanco_Dados(true);
                else
                    qtb_dup.Banco_Dados = banco;
                qtb_dup.Excluir(val);
                if (st_transacao)
                    qtb_dup.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dup.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir duplicata: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dup.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CupomFiscal_Item_X_Estoque
    {
        public static TList_CupomFiscal_Item_X_Estoque Buscar(string Id_cupom,
                                                              string Cd_empresa,
                                                              string Id_lancto,
                                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            return new TCD_CupomFiscal_Item_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CupomFiscal_Item_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CupomFiscal_Item_X_Estoque qtb_est = new TCD_CupomFiscal_Item_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else
                    qtb_est.Banco_Dados = banco;
                string retorno = qtb_est.Gravar(val);
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CupomFiscal_Item_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CupomFiscal_Item_X_Estoque qtb_est = new TCD_CupomFiscal_Item_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_est.CriarBanco_Dados(true);
                else
                    qtb_est.Banco_Dados = banco;
                qtb_est.Excluir(val);
                if (st_transacao)
                    qtb_est.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_est.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_est.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Cupom_X_MovCaixa
    {
        public static TList_Cupom_X_MovCaixa Buscar(string Id_movimento,
                                                    string Id_cupom,
                                                    string Cd_empresa,
                                                    string Cd_contager,
                                                    string Cd_lanctocaixa,
                                                    string Cd_portador,
                                                    string Id_caixa,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movimento;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }

            return new TCD_Cupom_X_MovCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cupom_X_MovCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_MovCaixa qtb_mov = new TCD_Cupom_X_MovCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                val.Id_movimentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_mov.Gravar(val), "@P_ID_MOVIMENTO");
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movimentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cupom_X_MovCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_MovCaixa qtb_mov = new TCD_Cupom_X_MovCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static void ReprocessarFin(TRegistro_MovCaixa val,
                                          TRegistro_VendaRapida rCupom,
                                          BancoDados.TObjetoBanco banco)
        {
            if ((val != null) && (rCupom != null))
            {
                bool st_transacao = false;
                TCD_Cupom_X_MovCaixa qtb_mov = new TCD_Cupom_X_MovCaixa();
                try
                {
                    if (banco == null)
                        st_transacao = qtb_mov.CriarBanco_Dados(true);
                    else
                        qtb_mov.Banco_Dados = banco;
                    //Buscar movimentacao cupom fiscal
                    TList_Cupom_X_MovCaixa lMov = Buscar(val.Id_movimento.Value.ToString(),
                                                         val.Id_cupom.Value.ToString(),
                                                         val.Cd_empresa,
                                                         string.Empty,
                                                         string.Empty,
                                                         val.Cd_portador,
                                                         string.Empty,
                                                         qtb_mov.Banco_Dados);
                    lMov.ForEach(p =>
                        {
                            //Buscar lancamento de caixa
                            if (p.Cd_lanctocaixa.HasValue)
                            {
                                TList_LanCaixa lCaixa = TCN_LanCaixa.Busca(p.Cd_contager,
                                                                           p.Cd_lanctocaixastr,
                                                                           string.Empty,
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
                                                                           false,
                                                                           string.Empty,
                                                                           decimal.Zero,
                                                                           false,
                                                                           qtb_mov.Banco_Dados);
                                //Estornar lancamento de caixa
                                if (lCaixa.Count > 0)
                                    TCN_LanCaixa.EstornarCaixa(lCaixa[0], null, qtb_mov.Banco_Dados);
                            }
                            //Estornar Troco, se houver
                            if (p.Cd_lanctocaixa_troco.HasValue)
                            {
                                TList_LanCaixa lCaixaTroco = TCN_LanCaixa.Busca(p.Cd_contager,
                                                                                p.Cd_lanctocaixa_trocostr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                "N",
                                                                                false,
                                                                                string.Empty,
                                                                                decimal.Zero,
                                                                                false,
                                                                                qtb_mov.Banco_Dados);
                                if (lCaixaTroco.Count > 0)
                                    TCN_LanCaixa.EstornarCaixa(lCaixaTroco[0], null, qtb_mov.Banco_Dados);
                            }
                            //Cheque Troco
                            TCN_TrocoCH.Buscar(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               p.Id_movimentostr,
                                               null).ForEach(x => TCN_TrocoCH.Excluir(x, qtb_mov.Banco_Dados));
                            CamadaDados.PostoCombustivel.TList_CartaFrete lCartaF = null;
                            //Excluir carta frete
                            if (p.Id_cartafrete.HasValue)
                                PostoCombustivel.TCN_CartaFrete.Buscar(p.Cd_empresa,
                                                                       p.Id_cartafretestr,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       qtb_mov.Banco_Dados);
                            //Excluir credito, se houver
                            if (p.Id_adto.HasValue)
                            {
                                TList_LanAdiantamento lAdto = TCN_LanAdiantamento.Buscar(p.Id_adtostr,
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
                                                                                         qtb_mov.Banco_Dados);
                                if (lAdto.Count > 0)
                                    TCN_LanAdiantamento.Excluir(lAdto[0], qtb_mov.Banco_Dados);
                            }
                            //Excluir cupom x movimento
                            Excluir(p, qtb_mov.Banco_Dados);
                            if (lCartaF != null)
                                lCartaF.ForEach(x => PostoCombustivel.TCN_CartaFrete.Excluir(x, qtb_mov.Banco_Dados));
                            //Gravar novo financeiro para o cupom
                            rCupom.lPortador.ForEach(v =>
                                {
                                    v.lCheque.ForEach(x => x.Dt_emissao = rCupom.Dt_emissao);
                                    v.lDup.ForEach(x => x.Dt_emissao = rCupom.Dt_emissao);
                                    v.lFatura.ForEach(x => x.Dt_fatura = rCupom.Dt_emissao);
                                });
                            TCN_VendaRapida.FecharVenda(rCupom, val.Id_caixa, qtb_mov.Banco_Dados);
                            //Verificar se existe registro de fechento de caixa para o portador
                            rCupom.lPortador.ForEach(v =>
                                {
                                    if ((v.Vl_pagtoPDV > decimal.Zero) && v.Tp_portadorpdv.Trim().ToUpper().Equals("A"))
                                        if (new TCD_FechamentoCaixa(qtb_mov.Banco_Dados).BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = val.Id_caixa.Value.ToString()
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_portador",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + v.Cd_portador.Trim( )+ "'"
                                                }
                                            }, "1") == null)
                                        {
                                            //Gravar registro de fechamento de caixa para o portador
                                            TCN_FechamentoCaixa.Gravar(new TRegistro_FechamentoCaixa()
                                            {
                                                Cd_portador = v.Cd_portador,
                                                Id_caixa = val.Id_caixa,
                                                Vl_fechamento = val.Vl_recebido,
                                                Loginaudit = Parametros.pubLogin
                                            }, qtb_mov.Banco_Dados);
                                        }
                                });
                        });
                    //Alterar dados cupom, para gravar desconto caso tenha informado
                    TCN_VendaRapida.Gravar(rCupom, qtb_mov.Banco_Dados);
                    //Buscar fechamento de caixa para o portador cartao
                    TList_FechamentoCaixa lFech = new TCD_FechamentoCaixa(qtb_mov.Banco_Dados).Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_caixa",
                                                            vOperador = "=",
                                                            vVL_Busca = val.Id_caixa.Value.ToString()
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_portador x " +
                                                                        "where x.cd_portador = a.cd_portador " +
                                                                        "and x.st_cartaocredito = 0)"
                                                        }
                                                    }, 1, string.Empty);
                    if (lFech.Count > 0)
                    {
                        //Buscar Valor Movimento Liquido do portador
                        lFech[0].Vl_auditado =
                        new TCD_CaixaPDV(qtb_mov.Banco_Dados).SelectMovCaixa(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_caixa",
                                vOperador = "=",
                                vVL_Busca = val.Id_caixa.Value.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_portador",
                                vOperador = "=",
                                vVL_Busca = "'" + lFech[0].Cd_portador.Trim() + "'"
                            }
                        }, string.Empty).Sum(p => p.Vl_recebido - p.Vl_DevCredito);
                        TCN_FechamentoCaixa.Gravar(lFech[0], qtb_mov.Banco_Dados);
                    }
                    if (st_transacao)
                        qtb_mov.Banco_Dados.Commit_Tran();
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_mov.Banco_Dados.RollBack_Tran();
                    throw new Exception("Erro reprocessar financeiro venda rapida: " + ex.Message.Trim());
                }
                finally
                {
                    if (st_transacao)
                        qtb_mov.deletarBanco_Dados();
                }
            }
        }
    }

    public class TCN_Cupom_X_DevCredito
    {
        public static TList_Cupom_X_DevCredito Buscar(string Id_devolucao,
                                                      string Cd_contager,
                                                      string Cd_lanctocaixa,
                                                      string Cd_lanctocaixa_dev,
                                                      string Id_cupom,
                                                      string Cd_empresa,
                                                      string Id_caixa,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_devolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_devolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_devolucao;
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa_dev))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa_dev";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa_dev;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            return new TCD_Cupom_X_DevCredito(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cupom_X_DevCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_DevCredito qtb_mov = new TCD_Cupom_X_DevCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                string retorno = qtb_mov.Gravar(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cupom_X_DevCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_DevCredito qtb_mov = new TCD_Cupom_X_DevCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Cupom_X_VendaRapida
    {
        public static TList_Cupom_X_VendaRapida Buscar(string Id_cupom,
                                                       string Cd_empresa,
                                                       string Id_vendarapida,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_vendarapida))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vendarapida;
            }
            return new TCD_Cupom_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cupom_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_VendaRapida qtb_vr = new TCD_Cupom_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                string retorno = qtb_vr.Gravar(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cupom x venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cupom_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_VendaRapida qtb_vr = new TCD_Cupom_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                qtb_vr.Excluir(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cupom x venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Pedido_X_VendaRapida
    {
        public static TList_Pedido_X_VendaRapida Buscar(string Id_vendarapida,
                                                        string Cd_empresa,
                                                        string Nr_pedido,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_vendarapida))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vendarapida;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedido;
            }
            return new TCD_Pedido_X_VendaRapida(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Pedido_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido_X_VendaRapida qtb_ped = new TCD_Pedido_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                string retorno = qtb_ped.Gravar(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pedido venda rapida: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Pedido_X_VendaRapida val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido_X_VendaRapida qtb_ped = new TCD_Pedido_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                qtb_ped.Excluir(val);
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pedido venda direta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static void ProcessarPedido(CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed,
                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Pedido_X_VendaRapida qtb_ped = new TCD_Pedido_X_VendaRapida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ped.CriarBanco_Dados(true);
                else
                    qtb_ped.Banco_Dados = banco;
                //Gravar Pedido
                Pedido.TCN_Pedido.Grava_Pedido(rPed, qtb_ped.Banco_Dados);
                //Gravar Pedido X Venda
                rPed.Pedido_Itens.ForEach(p => p.lItemCF.ForEach(v => Gravar(new TRegistro_Pedido_X_VendaRapida()
                {
                    Id_vendarapida = v.Id_vendarapida,
                    Cd_empresa = v.Cd_empresa,
                    Id_lanctovenda = v.Id_lanctovenda,
                    Nr_pedido = p.Nr_pedido,
                    Cd_produto = p.Cd_produto,
                    Id_pedidoitem = p.Id_pedidoitem
                }, qtb_ped.Banco_Dados)));
                if (st_transacao)
                    qtb_ped.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ped.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }
    }

    public class TCN_VendaRapida_X_Orcamento
    {
        public static TList_VendaRapida_X_Orcamento Buscar(string Cd_empresa,
                                                           string Id_cupom,
                                                           string Id_lancto,
                                                           string Nr_orcamento,
                                                           string Id_item,
                                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            if (!string.IsNullOrEmpty(Nr_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_orcamento;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            return new TCD_VendaRapida_X_Orcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VendaRapida_X_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_X_Orcamento qtb_vr = new TCD_VendaRapida_X_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                string retorno = qtb_vr.Gravar(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaRapida_X_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_X_Orcamento qtb_vr = new TCD_VendaRapida_X_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                qtb_vr.Excluir(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }
    }

    public class TCN_VendaRapida_X_EntregaFutura
    {
        public static TList_VendaRapida_X_EntregaFutura Buscar(string Cd_empresa,
                                                               string Nr_lanctofiscal,
                                                               string Id_nfitem,
                                                               string Id_cupom,
                                                               string Id_lancto,
                                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            return new TCD_VendaRapida_X_EntregaFutura(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_VendaRapida_X_EntregaFutura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_X_EntregaFutura qtb_vr = new TCD_VendaRapida_X_EntregaFutura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                string retorno = qtb_vr.Gravar(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_VendaRapida_X_EntregaFutura val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_VendaRapida_X_EntregaFutura qtb_vr = new TCD_VendaRapida_X_EntregaFutura();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vr.CriarBanco_Dados(true);
                else
                    qtb_vr.Banco_Dados = banco;
                qtb_vr.Excluir(val);
                if (st_transacao)
                    qtb_vr.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vr.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vr.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Cupom_X_CCusto
    {
        public static TList_Cupom_X_CCusto Buscar(string Id_cupom,
                                                  string Cd_empresa,
                                                  string Id_ccustolan,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ccustolan))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ccustolan;
            }
            return new TCD_Cupom_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cupom_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_CCusto qtb_custo = new TCD_Cupom_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                string retorno = qtb_custo.Gravar(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cupom_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_CCusto qtb_custo = new TCD_Cupom_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                qtb_custo.Excluir(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static void ProcessarVendaCResultado(List<TRegistro_VendaRapida> lCupom,
                                                    string CD_CentroResult,
                                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cupom_X_CCusto qtb_desp = new TCD_Cupom_X_CCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desp.CriarBanco_Dados(true);
                else qtb_desp.Banco_Dados = banco;
                if (string.IsNullOrEmpty(CD_CentroResult))
                    throw new Exception("Obrigatório informar centro de resultado.");
                lCupom.ForEach(p =>
                {
                    //Verificar se despesa possui centro de resultado
                    TCN_Cupom_X_CCusto.Buscar(p.Id_vendarapidastr,
                                                   p.Cd_empresa,
                                                   string.Empty,
                                                   qtb_desp.Banco_Dados).ForEach(v =>
                                                   {
                                                       Excluir(v, qtb_desp.Banco_Dados);
                                                       TCN_LanCCustoLancto.Excluir(
                                                               new TRegistro_LanCCustoLancto()
                                                               {
                                                                   Id_ccustolan = v.Id_ccustolan
                                                               }, qtb_desp.Banco_Dados);
                                                   });
                    //Gravar Lancto Resultado
                    string id = TCN_LanCCustoLancto.Gravar(
                        new TRegistro_LanCCustoLancto()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_centroresult = CD_CentroResult,
                            Vl_lancto = p.Vl_cupom,
                            Dt_lancto = p.Dt_emissao
                        }, qtb_desp.Banco_Dados);
                    //Amarrar Lancto a Caixa
                    Gravar(new TRegistro_Cupom_X_CCusto()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Id_ccustolan = decimal.Parse(id),
                        Id_cupom = p.Id_vendarapida
                    }, qtb_desp.Banco_Dados);
                });
                if (st_transacao)
                    qtb_desp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar despesas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TrocoCH
    {
        public static TList_TrocoCH Buscar(string Id_troco,
                                           string Cd_empresa,
                                           string Id_caixa,
                                           string Nr_lanctocheque,
                                           string Cd_banco,
                                           string Id_movimento,
                                           BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_troco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_troco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_troco;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            if (!string.IsNullOrEmpty(Nr_lanctocheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctocheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctocheque;
            }
            if (!string.IsNullOrEmpty(Cd_banco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_banco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movimento;
            }
            return new TCD_TrocoCH(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Titulo.TList_RegLanTitulo BuscarCh(string Id_caixa,
                                                                                BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Titulo.TCD_LanTitulo(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.status_compensado, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "exists(select 1 from tb_pdv_trocoCH x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and x.id_caixa = " + Id_caixa + ") or " +
                                    "exists(select 1 from tb_fin_trocoCH x " +
                                    "inner join TB_FIN_Liquidacao y " +
                                    "on x.CD_ContaGer = y.CD_ContaGer " +
                                    "and x.CD_LanctoCaixa = y.CD_LanctoCaixa " +
                                    "inner join TB_PDV_Caixa_X_Liquidacao z " +
                                    "on y.CD_Empresa = z.CD_Empresa " +
                                    "and y.Nr_Lancto = z.Nr_Lancto " +
                                    "and y.CD_Parcela = z.CD_Parcela " +
                                    "and y.ID_Liquid = z.ID_Liquid " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_banco = a.cd_banco " +
                                    "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                    "and z.id_caixa = " + Id_caixa + ")"
                    }
                }, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_TrocoCH val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocoCH qtb_troco = new TCD_TrocoCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troco.CriarBanco_Dados(true);
                else
                    qtb_troco.Banco_Dados = banco;
                string retorno = qtb_troco.Gravar(val);
                if (st_transacao)
                    qtb_troco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocoCH val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocoCH qtb_troco = new TCD_TrocoCH();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troco.CriarBanco_Dados(true);
                else
                    qtb_troco.Banco_Dados = banco;

                CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCh =
                CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca(val.Cd_empresa,
                                                                    val.Nr_lanctocheque.Value,
                                                                    val.Cd_banco,
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
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    1,
                                                                    string.Empty,
                                                                    qtb_troco.Banco_Dados)[0];
                if (rCh.Tp_titulo.Equals("P"))
                {
                    //Verificar se a empresa gera cheque troco direto
                    if (new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto(qtb_troco.Banco_Dados).BuscarEscalar(
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
                                vNM_Campo = "isnull(a.st_chtrocodireto, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") != null)
                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.CancelarTitulo(rCh, qtb_troco.Banco_Dados);
                }
                else CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.EstornarCompensacaoTitulo(rCh, qtb_troco.Banco_Dados);
                qtb_troco.Excluir(val);
                if (st_transacao)
                    qtb_troco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troco.deletarBanco_Dados();
            }
        }
    }
}