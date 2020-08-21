using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Graos;
using CamadaNegocio.Graos;
using CamadaNegocio.Sementes;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Faturamento.Comissao;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Fiscal;
using CamadaDados.Diversos;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Fiscal;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Faturamento.Comissao;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanFaturamento_Item
    {
        public static TList_RegLanFaturamento_Item Busca(string Cd_empresa,
                                                         string Nr_lanctofiscal,
                                                         string Id_nfitem,
                                                         TObjetoBanco banco)
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
            return new TCD_LanFaturamento_Item(banco).Select(filtro, 0, string.Empty, string.Empty, "a.id_nfitem");
        }

        public static TList_RegLanFaturamento_Item Busca(string Cd_empresa,
                                                         string Nr_lanctofiscal,
                                                         int vTop,
                                                         string vNM_Campo,
                                                         TObjetoBanco banco)
        {
            return new TCD_LanFaturamento_Item(banco).Select(
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
                }, vTop, vNM_Campo, string.Empty, "a.id_nfitem");
        }

        public static TList_RegLanFaturamento_Item BuscarNfFixacao(string Nr_contrato,
                                                                   string Tp_movimento,
                                                                   bool St_comsaldofixar,
                                                                   bool St_nfpauta,
                                                                   bool St_nffixar,
                                                                   decimal Id_fixacao)
        {
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 from vtb_gro_contrato x " +
                                  "where x.nr_pedido = a.nr_pedido " +
                                  "and x.cd_produto = a.cd_produto " +
                                  "and x.id_pedidoitem = a.id_pedidoitem " +
                                  "and x.nr_contrato = " + Nr_contrato + ")";

            filtro[1].vNM_Campo = "nf.tp_movimento";
            filtro[1].vOperador = !string.IsNullOrEmpty(Tp_movimento) ? "=" : "in";
            filtro[1].vVL_Busca = !string.IsNullOrEmpty(Tp_movimento) ? "'" + Tp_movimento.Trim() + "'" : "('E','S')";

            filtro[2].vNM_Campo = "isnull(nf.st_registro, 'A')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'C'";

            if (St_comsaldofixar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.quantidade - a.Qtd_devolvida - a.Qtd_fixacao";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (Id_fixacao > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_fixacao_nf x " +
                                                      "inner join tb_gro_fixacao y " +
                                                      "on x.id_fixacao = y.id_fixacao " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and x.id_nfitem = a.id_nfitem " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "and x.id_fixacao = " + Id_fixacao.ToString() + ")";
            }
            if (St_nfpauta)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_fixacao_nf x " +
                                                      "inner join tb_gro_fixacao y " +
                                                      "on x.id_fixacao = y.id_fixacao " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and x.id_nfitem = a.id_nfitem " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "and x.tp_nota in ('D', 'C'))";
            }
            if (St_nffixar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_fixacao_nf x " +
                                                      "inner join tb_gro_fixacao y " +
                                                      "on x.id_fixacao = y.id_fixacao " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                      "and x.id_nfitem = a.id_nfitem " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "and x.tp_nota in ('D', 'C'))";
            }

            return new TCD_LanFaturamento_Item().Select(filtro, 0, string.Empty, string.Empty, "a.id_nfitem");
        }

        public static void qtdVlrNotaFiscal(string vNR_Pedido,
                                            string vCD_Empresa,
                                            string vNR_LanctoFiscal,
                                            string vCD_Produto,
                                            bool vST_Mestra,
                                            bool vST_Remessa,
                                            ref decimal tQuantidade,
                                            ref decimal tValor)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vNR_Pedido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "nf.NR_Pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vNR_LanctoFiscal.Trim() != "") && (!vST_Remessa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vST_Mestra)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "m.ST_Mestra";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vST_Remessa)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "nf.NR_LanctoFiscal_Mestra";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            TCD_LanFaturamento_Item qtb_nfItem = new TCD_LanFaturamento_Item();
            DataTable tabela = qtb_nfItem.Buscar(vBusca, 1, "isNull(sum(isNull(a.Quantidade,0)),0) as Quantidade," +
                                                    "isNull(sum(isNull(a.Vl_SubTotal,0)),0) as Vl_SubTotal");
            if (tabela != null)
                if (tabela.Rows.Count > 0)
                {
                    try
                    {
                        tQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                    }
                    catch
                    { tQuantidade = 0; }
                    try
                    {
                        tValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                    }
                    catch
                    { tValor = 0; }
                }
        }

        public static decimal totalNfdoMes(string vCD_Empresa, string vCD_Clifor, DateTime? vDT_Emissao, TObjetoBanco banco)
        {
            if (string.IsNullOrEmpty(vCD_Empresa) ||
                string.IsNullOrEmpty(vCD_Clifor) ||
                (!vDT_Emissao.HasValue))
                return decimal.Zero;
            object obj = new TCD_LanFaturamento(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCD_Empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "nf.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCD_Clifor.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "year(nf.dt_emissao)",
                                    vOperador = "=",
                                    vVL_Busca = vDT_Emissao.Value.Year.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "month(nf.dt_emissao)",
                                    vOperador = "=",
                                    vVL_Busca = vDT_Emissao.Value.Month.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "day(nf.dt_emissao)",
                                    vOperador = "=",
                                    vVL_Busca = vDT_Emissao.Value.Day.ToString()
                                }
                            },
                            "isNull(sum( dbo.F_isZero( a.Quantidade * a.Vl_Unitario, a.vl_subtotal)),0)as totalFaturado");
            return obj == null ? decimal.Zero : Convert.ToDecimal(obj.ToString());
        }

        public static string GravarFaturamentoItem(TList_RegLanFaturamento_Item val, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            if (val != null)
            {
                for (int i = 0; i < val.Count; i++)
                    retorno = retorno + "|" + GravarFaturamentoItem(val[i], banco);
            }
            return retorno;
        }

        public static string GravarFaturamentoItem(TRegistro_LanFaturamento_Item val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanFaturamento_Item qtb_faturamento = new TCD_LanFaturamento_Item();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_faturamento.CriarBanco_Dados(true);
                else
                    qtb_faturamento.Banco_Dados = banco;
                //Buscar % Aliquota Simples Nacional
                object obj = new TCD_CadEmpresa(qtb_faturamento.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    }
                                }, "isnull(i.pc_aliquota, 0)");
                if (obj == null ? false : decimal.Parse(obj.ToString()) > decimal.Zero)
                    val.Pc_aliquotasimples = decimal.Parse(obj.ToString());
                //Gravar Item
                string retorno = qtb_faturamento.GravaItensNF(val);
                val.Id_nfitem = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_NFITEM"));
                //Gravar Devolução / Complemento
                val.lNfcompdev.ForEach(p =>
                    {
                        p.Nr_lanctofiscal_destino = val.Nr_lanctofiscal;
                        p.Id_nfitem_destino = val.Id_nfitem;
                        retorno += "|" + TCN_LanFat_ComplementoDevolucao.Gravar(p, qtb_faturamento.Banco_Dados);
                        if (p.Tp_operacao.Trim().ToUpper().Equals("D"))
                        {
                            p.lSerie.ForEach(x =>
                            {
                                TCN_SerieDevolvida.Gravar(
                                    new CamadaDados.Producao.Producao.TRegistro_SerieDevolvida
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Nr_lanctofiscal = p.Nr_lanctofiscal_destino,
                                        Id_nfitem = p.Id_nfitem_destino,
                                        Id_serie = x.Id_serie
                                    }, qtb_faturamento.Banco_Dados);
                            });
                        }
                    });
                //Gravar Numero de serie dos itens
                for (int i = 0; i < val.Serial.Count; i++)
                    Servicos.Cadastros.TCN_OSE_SerialClifor.Gravar_SerialClifor(val.Serial[i], qtb_faturamento.Banco_Dados);

                //GRAVA ORIGINACAO
                if (val.lOriginacao_x_Faturamento.Count > 0)
                {
                    //PREENCHE OS DADOS DA ORIGINACAO CENTRAL
                    TRegistro_Lan_Originacao reg_originacao = new TRegistro_Lan_Originacao();
                    reg_originacao.CD_Empresa = val.Cd_empresa;
                    reg_originacao.Nr_LanctoFiscal = val.Nr_lanctofiscal;
                    reg_originacao.ID_NFItem = val.Id_nfitem;

                    string ret_originacao = TCN_Lan_Originacao.GravarOriginacao(reg_originacao, banco);
                    reg_originacao.ID_Originacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret_originacao, "@P_ID_ORIGINACAO"));

                    for (int i = 0; i < val.lOriginacao_x_Faturamento.Count; i++)
                    {
                        val.lOriginacao_x_Faturamento[i].CD_Empresa = val.Cd_empresa;
                        val.lOriginacao_x_Faturamento[i].ID_Originacao = reg_originacao.ID_Originacao;

                        TCN_Lan_Originacao_x_Faturamento.GravarOriginacao_x_Faturamento(val.lOriginacao_x_Faturamento[i], banco);

                        //GRAVA NFHeadge
                        if (val.lOriginacao_x_Faturamento[i].lNFHeadge.Count > 0)
                        {
                            for (int x = 0; x < val.lOriginacao_x_Faturamento[i].lNFHeadge.Count; x++)
                            {
                                val.lOriginacao_x_Faturamento[i].lNFHeadge[x].ID_Originacao = reg_originacao.ID_Originacao;
                                TCN_Lan_NFHeadge.GravarNFHeadge(val.lOriginacao_x_Faturamento[i].lNFHeadge[x], banco);
                            }
                        }
                        //FIM DA GRAVACAO DA NFHeadge
                    }
                }
                //Gravar lote semente
                if (val.lLoteSemente != null)
                    val.lLoteSemente.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                            p.Id_nfitem = val.Id_nfitem;
                            TCN_LoteSemente_X_NFItem.Gravar(p, qtb_faturamento.Banco_Dados);
                        });
                //Gravar origem lote semente
                if (val.lLoteNfOrigem != null)
                    val.lLoteNfOrigem.ForEach(p => TCN_LoteSemente_X_NFItem.Gravar(p, qtb_faturamento.Banco_Dados));
                if (val.ldi != null)
                    val.ldi.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                            p.Id_nfitem = val.Id_nfitem;
                            TCN_DeclaracaoImport.Gravar(p, qtb_faturamento.Banco_Dados);
                        });
                //Gravar Lote Matéria-Prima
                if (val.lMov != null)
                    val.lMov.ForEach(p =>
                        {
                            p.Cd_empresa = val.Cd_empresa;
                            p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                            p.Id_nfitem = val.Id_nfitem;
                            TCN_MovRastreabilidade.Gravar(p, qtb_faturamento.Banco_Dados);
                        });
                //Gravar Itens Carga Avulsa
                if (val.lItensCargaAvulsa != null)
                    val.lItensCargaAvulsa.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_LanctoFiscalS = val.Nr_lanctofiscal;
                        p.ID_NFItemS = val.Id_nfitem;
                        Entrega.TCN_ItensCargaAvulsa.Gravar(p, qtb_faturamento.Banco_Dados);
                    });
                //Gravar comissao
                ProcessarComissao(val, qtb_faturamento.Banco_Dados);
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
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
        }

        public static void GravarLoteSementeItem(TRegistro_LanFaturamento_Item val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanFaturamento_Item qtb_faturamento = new TCD_LanFaturamento_Item();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_faturamento.CriarBanco_Dados(true);
                else
                    qtb_faturamento.Banco_Dados = banco;
                //Gravar lote semente
                if (val.lLoteSemente != null)
                    val.lLoteSemente.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctofiscal = val.Nr_lanctofiscal;
                        p.Id_nfitem = val.Id_nfitem;
                        TCN_LoteSemente_X_NFItem.Gravar(p, qtb_faturamento.Banco_Dados);
                    });
                //Gravar origem lote semente
                if (val.lLoteNfOrigem != null)
                    val.lLoteNfOrigem.ForEach(p => TCN_LoteSemente_X_NFItem.Gravar(p, qtb_faturamento.Banco_Dados));
                if (pode_liberar)
                    qtb_faturamento.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
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
        }

        public static void ProcessarComissao(TRegistro_LanFaturamento_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento_Item qtb_item = new TCD_LanFaturamento_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                if (val.St_devolucao)
                {
                    //Buscar lista dos itens nf que estao sendo devolvidos
                    qtb_item.Select(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctofiscal_origem = a.nr_lanctofiscal " +
                                        "and x.id_nfitem_origem = a.id_nfitem " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.nr_lanctofiscal_destino = " + val.Nr_lanctofiscal.ToString() + " " +
                                        "and x.id_nfitem_destino = " + val.Id_nfitem.ToString() + " " +
                                        "and x.tp_operacao = 'D')"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty).ForEach(p =>
                        {
                            //Verificar se ja existe comissao
                            TList_Fechamento_Comissao lComissao =
                                TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                               p.Cd_empresa,
                                                               string.Empty,
                                                               string.Empty,
                                                               p.Nr_lanctofiscal.ToString(),
                                                               p.Id_nfitem.ToString(),
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
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                               string.Empty,
                                                               qtb_item.Banco_Dados);

                            if (lComissao.Count > 0)
                            {
                                lComissao.ForEach(x =>
                                    {
                                        //Verificar se comissao possui faturamento
                                        if (new TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + x.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FAT_Fechamento_Comissao x " +
                                                                "where a.cd_empresa = x.cd_empresa " +
                                                                "and a.id_comissao = x.id_comissao " +
                                                                "and x.Nr_lanctofiscal = " + p.Nr_lanctofiscal +
                                                                "and x.Id_nfitem = " + p.Id_nfitem + ")"
                                                }
                                            }, "1") == null)
                                            TCN_Fechamento_Comissao.Excluir(x, qtb_item.Banco_Dados);
                                        else
                                            throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.\r\n" +
                                                                "Nota Fiscal: " + p.Nr_notafiscal.ToString() + "\r\n" +
                                                                "Produto: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim());
                                    });
                            }
                            //Verificar se o pedido gera comissao no faturamento
                            if ((new TCD_CadCFGPedido(qtb_item.Banco_Dados).BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_comissaofat, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                        "where x.cfg_pedido = a.cfg_pedido " +
                                                        "and x.nr_pedido = " + p.Nr_pedido.ToString() + ")"
                                        }
                                    }, "1") != null))
                            {
                                val.St_servico = new TCD_CadProduto(qtb_item.Banco_Dados).ItemServico(p.Cd_produto) ? "S" : "N";

                                //Verificar se o item e servico e se vendedor e comissionado sobre servico
                                if ((!p.St_servico.Trim().ToUpper().Equals("S")) ||
                                    (p.St_servico.Trim().ToUpper().Equals("S") &&
                                    (new TCD_Vendedor_X_Empresa(qtb_item.Banco_Dados).BuscarEscalar(
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
                                                vNM_Campo = "a.cd_vendedor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_vendedor.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo= "isnull(a.st_comservico, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, "1") != null)))
                                {
                                    TList_RegLanPedido_Item lPedItem =
                                    TCN_LanPedido_Item.Busca(string.Empty,
                                                             string.Empty,
                                                             p.Cd_produto,
                                                             p.Nr_pedido.ToString(),
                                                             p.Id_pedidoitemstr,
                                                             string.Empty,
                                                             string.Empty,
                                                             false,
                                                             qtb_item.Banco_Dados);
                                    if (!string.IsNullOrEmpty(lPedItem[0].Cd_vendedor))
                                    {
                                        decimal vl_basecalc = (p.Vl_subtotal + p.Vl_juro_fin + p.Vl_outrasdesp - p.Vl_desconto) -
                                            (val.Vl_subtotal + val.Vl_juro_fin + val.Vl_outrasdesp - val.Vl_desconto);
                                        decimal pc_comissao = decimal.Zero;
                                        string tp_comissao = "P";
                                        decimal vl_comissao = TCN_Fechamento_Comissao.CalcularComissao(lPedItem[0].Cd_Empresa,
                                                                                                       lPedItem[0].Cd_vendedor,
                                                                                                       lPedItem[0].Cd_tabelapreco,
                                                                                                       p.Cd_condpgto,
                                                                                                       p.Cd_produto,
                                                                                                       p.Quantidade,
                                                                                                       ref vl_basecalc,
                                                                                                       ref pc_comissao,
                                                                                                       ref tp_comissao,
                                                                                                       qtb_item.Banco_Dados);
                                        //Gravar fechamento comissao
                                        if (vl_comissao > decimal.Zero)
                                        {
                                            TCN_Fechamento_Comissao.Gravar(
                                                new TRegistro_Fechamento_Comissao()
                                                {
                                                    Cd_empresa = p.Cd_empresa,
                                                    Cd_vendedor = lPedItem[0].Cd_vendedor,
                                                    Dt_lancto = p.Dt_emissao,
                                                    Nr_lanctofiscal = p.Nr_lanctofiscal,
                                                    Id_nfitem = p.Id_nfitem,
                                                    Tp_comissao = tp_comissao,
                                                    Pc_comissao = pc_comissao,
                                                    Vl_basecalc = vl_basecalc,
                                                    Vl_comissao = vl_comissao
                                                }, qtb_item.Banco_Dados);
                                            if (st_transacao)
                                                qtb_item.Banco_Dados.Commit_Tran();
                                        }
                                    }
                                }
                            }
                        });
                }
                else
                {
                    //Verificar se ja existe comissao
                    TList_Fechamento_Comissao lComissao = TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                         val.Cd_empresa,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         val.Nr_lanctofiscal.ToString(),
                                                                                         val.Id_nfitem.ToString(),
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
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         qtb_item.Banco_Dados);
                    if (lComissao.Count > 0)
                    {
                        //Verificar se comissao possui faturamento
                        if (new TCD_Comissao_X_Duplicata(qtb_item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + lComissao[0].Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_comissao",
                                    vOperador = "=",
                                    vVL_Busca = lComissao[0].Id_comissaostr
                                }
                            }, "1") == null)
                            TCN_Fechamento_Comissao.Excluir(lComissao[0], qtb_item.Banco_Dados);
                        else
                            throw new Exception("Item possui comissão faturada. Obrigatorio antes cancelar faturamento comissão.");
                    }
                    //Verificar se o pedido gera comissao
                    if ((new TCD_CadCFGPedido(qtb_item.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_comissaofat, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                "where x.cfg_pedido = a.cfg_pedido " +
                                                "and x.nr_pedido = " + val.Nr_pedido.ToString() + ")"
                                }
                            }, "1") != null))
                    {
                        val.St_servico = new TCD_CadProduto(qtb_item.Banco_Dados).ItemServico(val.Cd_produto) ? "S" : "N";

                        //Verificar se o item e servico e se vendedor e comissionado sobre servico
                        if ((!val.St_servico.Trim().ToUpper().Equals("S")) ||
                            (val.St_servico.Trim().ToUpper().Equals("S") &&
                            (new TCD_Vendedor_X_Empresa(qtb_item.Banco_Dados).BuscarEscalar(
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
                                        vNM_Campo = "a.cd_vendedor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_vendedor.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo= "isnull(a.st_comservico, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null)))
                        {
                            TList_RegLanPedido_Item lPedItem = TCN_LanPedido_Item.Busca(string.Empty,
                                                                                        string.Empty,
                                                                                        val.Cd_produto,
                                                                                        val.Nr_pedido.ToString(),
                                                                                        val.Id_pedidoitemstr,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,
                                                                                        qtb_item.Banco_Dados);
                            if (!string.IsNullOrEmpty(lPedItem[0].Cd_vendedor))
                            {
                                //Verificar se o item possui devolucao
                                TList_RegLanFaturamento_Item lDev =
                                    new TCD_LanFaturamento_Item(qtb_item.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal_destino = a.nr_lanctofiscal " +
                                                        "and x.id_nfitem_destino = a.id_nfitem " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and x.nr_lanctofiscal_origem = " + val.Nr_lanctofiscal.ToString() + " " +
                                                        "and x.id_nfitem_origem = " + val.Id_nfitem.ToString() + " " +
                                                        "and x.tp_operacao = 'D')"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
                                decimal vl_basecalc = (val.Vl_subtotal + val.Vl_juro_fin + val.Vl_outrasdesp - val.Vl_desconto) -
                                    lDev.Sum(v => v.Vl_subtotal + v.Vl_juro_fin + v.Vl_outrasdesp - v.Vl_desconto);
                                decimal pc_comissao = decimal.Zero;
                                string tp_comissao = "P";
                                decimal vl_comissao = TCN_Fechamento_Comissao.CalcularComissao(lPedItem[0].Cd_Empresa,
                                                                                               lPedItem[0].Cd_vendedor,
                                                                                               lPedItem[0].Cd_tabelapreco,
                                                                                               val.Cd_condpgto,
                                                                                               val.Cd_produto,
                                                                                               val.Quantidade - lDev.Sum(v => v.Quantidade),
                                                                                               ref vl_basecalc,
                                                                                               ref pc_comissao,
                                                                                               ref tp_comissao,
                                                                                               qtb_item.Banco_Dados);
                                //Gravar fechamento comissao
                                TCN_Fechamento_Comissao.Gravar(
                                    new TRegistro_Fechamento_Comissao()
                                    {
                                        Cd_empresa = val.Cd_empresa,
                                        Cd_vendedor = lPedItem[0].Cd_vendedor,
                                        Dt_lancto = val.Dt_emissao,
                                        Nr_lanctofiscal = val.Nr_lanctofiscal,
                                        Id_nfitem = val.Id_nfitem,
                                        Tp_comissao = tp_comissao,
                                        Pc_comissao = pc_comissao,
                                        Vl_basecalc = vl_basecalc,
                                        Vl_comissao = vl_comissao
                                    }, qtb_item.Banco_Dados);
                                if (st_transacao)
                                    qtb_item.Banco_Dados.Commit_Tran();
                            }
                        }
                    }
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

        public static string AlterarFaturamentoItem(TRegistro_LanFaturamento_Item val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFaturamento_Item qtb_item = new TCD_LanFaturamento_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                qtb_item.GravaItensNF(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_nfitem.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar item Nota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static bool ObrigImformarICMS(string Cd_produto,
                                             string Nr_serie,
                                             TObjetoBanco banco)
        {
            return (Parametros.pubCultura.Trim().Equals("pt-BR") &&
                    (!new TCD_CadProduto(banco).ItemServico(Cd_produto)) &&
                    (new TCD_CadSerieNF(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_serie",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Nr_serie.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_gerasintegra, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "1") != null));
        }

        public static bool ObrigInformarPIS(string Cd_empresa,
                                            string Cd_movto,
                                            string Tp_nota,
                                            bool St_nfe,
                                            string Cd_produto,
                                            TRegistro_LanFaturamento_Item rItem,
                                            TObjetoBanco banco)
        {
            //Verificar se a movimentacao gera sped pis/cofins
            bool st_movgerasped = new TCD_CadMovimentacao(banco).BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_movimentacao",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_movto.Trim() + "'"
                                            }
                                        }, "isnull(a.st_gerarspedpiscofins, 'N')").ToString().ToUpper().Equals("S");
            //Verificar se a empresa gera sped pis/cofins
            bool st_empgerasped = new TCD_CadEmpresa(banco).BuscarEscalar(
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
                                                vNM_Campo = "a.tp_atividadespedpiscofins",
                                                vOperador = "is",
                                                vVL_Busca = "not null"
                                            }
                                        }, "1") != null;
            return ((Tp_nota.Trim().ToUpper().Equals("P") &&
                    St_nfe &&
                    (!new TCD_CadProduto(banco).ItemServico(Cd_produto)) &&
                    (string.IsNullOrWhiteSpace(rItem.Cd_ST_PIS))) ||
                    (Tp_nota.Trim().ToUpper().Equals("T") &&
                    st_movgerasped &&
                    st_empgerasped &&
                    (!new TCD_CadProduto(banco).ItemServico(Cd_produto)) &&
                    (string.IsNullOrWhiteSpace(rItem.Cd_ST_PIS))));
        }

        public static bool ObrigInformarCOFINS(string Cd_empresa,
                                               string Cd_movto,
                                               string Tp_nota,
                                               bool St_nfe,
                                               string Cd_produto,
                                               TRegistro_LanFaturamento_Item rItem,
                                               TObjetoBanco banco)
        {
            //Verificar se a movimentacao gera sped pis/cofins
            bool st_movgerasped = new TCD_CadMovimentacao(banco).BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_movimentacao",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_movto.Trim() + "'"
                                            }
                                        }, "isnull(a.st_gerarspedpiscofins, 'N')").ToString().Trim().ToUpper().Equals("S");
            //Verificar se a empresa gera sped pis/cofins
            bool st_empgerasped = new TCD_CadEmpresa(banco).BuscarEscalar(
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
                                                vNM_Campo = "a.tp_atividadespedpiscofins",
                                                vOperador = "is",
                                                vVL_Busca = "not null"
                                            }
                                        }, "1") != null;
            return ((Tp_nota.Trim().ToUpper().Equals("P") &&
                    St_nfe &&
                    (!new TCD_CadProduto(banco).ItemServico(Cd_produto)) &&
                    (string.IsNullOrWhiteSpace(rItem.Cd_ST_COFINS))) ||
                    (Tp_nota.Trim().ToUpper().Equals("T") &&
                    st_movgerasped &&
                    st_empgerasped &&
                    (!new TCD_CadProduto(banco).ItemServico(Cd_produto)) &&
                    (string.IsNullOrWhiteSpace(rItem.Cd_ST_COFINS))));
        }

        public static void CalcImpostos(TRegistro_ImpostosNF val, decimal vVl_BaseCalc, decimal vQuantidade, string Tp_movimento)
        {
            if ((!val.St_simplesnacional) ||
                (val.St_simplesnacional && (!val.St_substtrib)))
            {
                //Calcular Vl Base Calc
                if (val.Pc_aliquota > decimal.Zero)
                {
                    if (val.Pc_reducaobasecalc > decimal.Zero)
                        val.Vl_basecalc = ((val.St_somaricmsbase ? Math.Round(decimal.Divide(vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero), decimal.Divide(100 - val.Pc_aliquota, 100)), 2, MidpointRounding.AwayFromZero) : vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero)) * ((100 - val.Pc_reducaobasecalc) / 100));
                    else
                        val.Vl_basecalc = (val.St_somaricmsbase ? Math.Round(decimal.Divide(vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero), decimal.Divide(100 - val.Pc_aliquota, 100)), 2, MidpointRounding.AwayFromZero) : vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero));
                }
                else val.Vl_basecalc = decimal.Zero;
                decimal vPc_aliquota = val.Pc_aliquota;

                //Calcular Valor Imposto
                if (val.Pc_reducaoaliquota > decimal.Zero)
                {
                    decimal icmsoperacao = (val.Vl_basecalc * (vPc_aliquota / 100));
                    val.Vl_diferidoICMS = Math.Round(decimal.Multiply(icmsoperacao, decimal.Divide(val.Pc_reducaoaliquota, 100)), 2, MidpointRounding.AwayFromZero);
                    val.Vl_impostocalc = Math.Round(icmsoperacao, 2, MidpointRounding.AwayFromZero) - val.Vl_diferidoICMS;
                }
                else val.Vl_impostocalc = Math.Round((val.Vl_basecalc * (vPc_aliquota / 100)), 2);
                
                //Calcular DIFAL
                if (val.Pc_aliquotaICMSDest > decimal.Zero)
                    val.Vl_difal = Math.Round(decimal.Multiply(val.Vl_basecalc, decimal.Divide(val.Pc_aliquotaICMSDest - (val.Pc_aliquota > decimal.Zero ? val.Pc_aliquota : val.Pc_aliqopdifal), 100)), 2, MidpointRounding.AwayFromZero);

                //Calcular Fundo Combate a Pobreza
                if (val.Pc_FCP > decimal.Zero)
                    val.Vl_FCP = Math.Round(decimal.Multiply(val.Vl_basecalc, decimal.Divide(val.Pc_FCP, 100)), 2, MidpointRounding.AwayFromZero);
            }
            //Calcular Vl Base Calc Subst. Trib
            if (val.Pc_aliquotasubst > decimal.Zero)
            {
                if (val.Tp_modbasecalcST.Trim().Equals("5") &&
                    val.Vl_pauta > decimal.Zero &&
                    vQuantidade > decimal.Zero)
                {
                    val.Vl_basecalcsubsttrib = vQuantidade * val.Vl_pauta;
                    decimal vl_icms_dest = Math.Round(decimal.Divide(decimal.Multiply(val.Vl_basecalcsubsttrib, val.Pc_aliquotasubst), 100), 2);
                    decimal baseicms = val.Vl_basecalc;
                    if(baseicms.Equals(decimal.Zero))
                    {
                        //Calcular Vl Base Calc
                        if (val.Pc_aliquota > decimal.Zero)
                        {
                            if (val.Pc_reducaobasecalc > decimal.Zero)
                                baseicms = ((val.St_somaricmsbase ? Math.Round(decimal.Divide(vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero), decimal.Divide(100 - val.Pc_aliquota, 100)), 2, MidpointRounding.AwayFromZero) : vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero)) * ((100 - val.Pc_reducaobasecalc) / 100));
                            else
                                baseicms = (val.St_somaricmsbase ? Math.Round(decimal.Divide(vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero), decimal.Divide(100 - val.Pc_aliquota, 100)), 2, MidpointRounding.AwayFromZero) : vVl_BaseCalc + (val.St_somarIPIBaseICMS ? val.Vl_ipisomar : decimal.Zero));
                        }
                        else baseicms = decimal.Zero;
                    }
                    decimal vl_icms = Math.Round(decimal.Divide(decimal.Multiply(baseicms, val.Pc_aliquota), 100), 2);
                    val.Vl_impostosubsttrib = vl_icms_dest - vl_icms;
                }
                else
                {
                    val.Vl_basecalcsubsttrib = vVl_BaseCalc + (val.St_somarIPIBaseST ? val.Vl_ipisomar : decimal.Zero);
                    if (val.Vl_mva > decimal.Zero)
                    {
                        val.Vl_basecalcsubsttrib = Math.Round(vQuantidade * val.Vl_mva, 2);
                        if (val.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                            val.Vl_basecalcsubsttrib = Math.Round((val.Vl_basecalcsubsttrib * ((100 - val.Pc_reducaobasecalcsubsttrib) / 100)), 2);
                        //Calcular Valor Imposto Subst. Trib.
                        val.Vl_impostosubsttrib = Math.Round((val.Vl_basecalcsubsttrib * 1 * (val.Pc_aliquotasubst / 100)), 2);
                    }
                    else
                    {
                        if (val.Pc_iva_st > decimal.Zero)
                            val.Vl_basecalcsubsttrib = Math.Round(val.Vl_basecalcsubsttrib + decimal.Divide(decimal.Multiply(val.Vl_basecalcsubsttrib, val.Pc_iva_st), 100), 2);
                        decimal vl_icms_dest = Math.Round(decimal.Divide(decimal.Multiply(val.Vl_basecalcsubsttrib, val.Pc_aliquotasubst), 100), 2);
                        //decimal vl_icms = Math.Round(decimal.Divide(decimal.Multiply(vVl_BaseCalc, val.Pc_aliquota), 100), 2);
                        val.Vl_impostosubsttrib = vl_icms_dest - val.Vl_impostocalc;// vl_icms;
                        if (val.St_simplesnacional && val.St_substtrib)
                            val.Pc_aliquota = decimal.Zero;
                    }
                }
                //Calcular Fundo Combate a Pobreza
                if (val.Pc_FCPST > decimal.Zero)
                    val.Vl_FCPST = Math.Round(decimal.Multiply(val.Vl_basecalcsubsttrib, decimal.Divide(val.Pc_FCPST, 100)), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                val.Vl_basecalcsubsttrib = decimal.Zero;
                val.Vl_impostosubsttrib = decimal.Zero;
            }
            //if (val.St_substtrib &&
            //    Tp_movimento.Trim().ToUpper().Equals("S") &&
            //    val.Pc_aliquota > decimal.Zero &&
            //    val.Pc_aliquotainterna > decimal.Zero)
            //    val.Vl_difsubst = Math.Round(decimal.Multiply(val.Vl_basecalc, decimal.Divide(decimal.Subtract(val.Pc_aliquotainterna, val.Pc_aliquota), decimal.Subtract(100, val.Pc_aliquotainterna))), 2, MidpointRounding.AwayFromZero);
        }

        public static TList_ImpostosNF procuraImpostosPorUf(string vCd_empresa,
                                                            string vUF_Origem,
                                                            string vUF_Destino,
                                                            string vCD_Movto,
                                                            string vTP_Movto,
                                                            string vCD_CondFiscal_Clifor,
                                                            string vCD_CondFiscal_Produto,
                                                            decimal vVl_SubTotal,
                                                            decimal vQuantidade,
                                                            ref string vObsFiscal,
                                                            DateTime? vDt_emissao,
                                                            string vCd_produto,
                                                            string vTp_nota,
                                                            string vNr_serie,
                                                            TObjetoBanco banco)
        {
            //Buscar Impostos por UF
            TpBusca[] filtro = new TpBusca[6];
            //Estado Origem
            filtro[0].vNM_Campo = "a.CD_UFOrig";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + vUF_Origem.Trim() + "'";
            //Estado Destino
            filtro[1].vNM_Campo = "a.CD_UFDest";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + vUF_Destino.Trim() + "'";
            //Movimentacao
            filtro[2].vNM_Campo = "a.cd_movimentacao";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + vCD_Movto.Trim() + "'";
            //Tipo Movimento
            filtro[3].vNM_Campo = "a.tp_movimento";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'" + vTP_Movto.Trim() + "'";
            //Condicao fiscal clifor
            filtro[4].vNM_Campo = "a.CD_CondFiscal_Clifor";
            filtro[4].vOperador = "=";
            filtro[4].vVL_Busca = "'" + vCD_CondFiscal_Clifor.Trim() + "'";
            //Empresa
            filtro[5].vNM_Campo = "a.cd_empresa";
            filtro[5].vOperador = "=";
            filtro[5].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            if (!string.IsNullOrEmpty(vCD_CondFiscal_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CondFiscal_Produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_CondFiscal_Produto.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.CD_CondFiscal_Produto, '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "''";
            }
            string obsfiscal = string.Empty;
            TList_CadCondFiscalICMS lImpostos = new TCD_CadCondFiscalICMS(banco).Select(filtro, 0, string.Empty);
            if (lImpostos.Count.Equals(0) &&
                ObrigImformarICMS(vCd_produto, vNr_serie, banco) &&
                vTp_nota.Trim().ToUpper().Equals("P"))
            {
                //Verificar o regime da empresa, se for simples gerar condicao fiscal icms automaticamente
                object obj = new TCD_CadEmpresa(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                                    }
                                }, "a.tp_regimetributario");
                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("1"))//Simples Nacional
                {
                    //Verificar se tem parametro para situacao tributaria isenta do icms configurada
                    string sittrib = TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_ICMS", vCd_empresa, banco);
                    if (!string.IsNullOrEmpty(sittrib))
                    {
                        //Buscar codigo imposto icms
                        obj = new TCD_CadImposto(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.st_icms",
                                        vOperador = "=",
                                        vVL_Busca = "0"
                                    }
                                }, "a.cd_imposto");
                        if (obj != null)
                        {
                            TCN_CadCondFiscalICMS.Gravar(
                                new TRegistro_CadCondFiscalICMS()
                                {
                                    Cd_empresa = vCd_empresa,
                                    Cd_condfiscal_clifor = vCD_CondFiscal_Clifor,
                                    Cd_condfiscal_produto = vCD_CondFiscal_Produto,
                                    Cd_impostostr = obj.ToString(),
                                    Cd_st = sittrib,
                                    Tp_movimento = vTP_Movto,
                                    Tp_modbasecalc = "0",
                                    Tp_modbasecalcST = "4"
                                },
                                new List<TRegistro_CadMovimentacao>()
                                {
                                    new TRegistro_CadMovimentacao()
                                    {
                                        Cd_movimentacao = Convert.ToDecimal(vCD_Movto)
                                    }
                                },
                                new List<TRegistro_CadUf>()
                                {
                                    new TRegistro_CadUf()
                                    {
                                        Cd_uf = vUF_Origem
                                    }
                                },
                                new List<TRegistro_CadUf>()
                                {
                                    new TRegistro_CadUf()
                                    {
                                        Cd_uf = vUF_Destino
                                    }
                                },
                                banco);
                            lImpostos = new TCD_CadCondFiscalICMS(banco).Select(filtro, 0, string.Empty);
                        }
                    }
                }
            }

            TList_ImpostosNF lImp = new TList_ImpostosNF();
            lImpostos.ForEach(p =>
                {
                    //Verificar se ja nao existe imposto gerado para a condicao
                    if (!lImp.Exists(v => v.Cd_imposto.Value.Equals(p.Cd_imposto.Value)))
                    {
                        TRegistro_ImpostosNF rImp = new TRegistro_ImpostosNF();
                        rImp.Cd_imposto = p.Cd_imposto;
                        rImp.Ds_imposto = p.Ds_imposto;
                        rImp.Pc_aliquota = p.Pc_aliquota_icms;
                        rImp.Pc_reducaoaliquota = p.Pc_reducaoaliquota;
                        rImp.Pc_reducaobasecalc = p.Pc_reducaobasecalc;
                        rImp.Pc_aliquotasubst = p.Pc_aliquota_icms_substtrib;
                        rImp.Pc_reducaobasecalcsubsttrib = p.Pc_reducaobasecalc_substtrib;
                        rImp.Tp_situacao = p.Tp_situacao;
                        rImp.St_gerarcredito = p.St_gerarcredito;
                        rImp.Dt_imposto = vDt_emissao;
                        rImp.St_impostouf = 0;
                        rImp.Tp_modbasecalc = p.Tp_modbasecalc;
                        rImp.Tp_modbasecalcST = p.Tp_modbasecalcST;
                        rImp.Cd_st = p.Cd_st;
                        rImp.Ds_situacao = p.Ds_situacao;
                        rImp.St_substtrib = p.St_substtrib;
                        rImp.St_simplesnacional = p.St_simplesnacional;
                        rImp.Pc_iva_st = p.Pc_iva_st;
                        rImp.Vl_mva = p.Vl_mva;
                        rImp.Pc_FCP = p.PC_FCP;
                        rImp.Pc_FCPST = p.PC_FCPST;
                        rImp.St_somaricmsbase = p.St_somaricmsbasebool;
                        rImp.Pc_aliquotaICMSDest = p.Pc_aliquota_icmsDest;
                        rImp.Pc_aliqopdifal = p.PC_AliqOpDIFAL;
                        rImp.Vl_pauta = p.Vl_pauta;
                        rImp.St_somarIPIBaseICMS = p.St_somarIPIBaseICMS;
                        rImp.St_somarIPIBaseST = p.St_somarIPIBaseST;
                        //Calcular Imposto
                        CalcImpostos(rImp, vVl_SubTotal, vQuantidade, p.Tp_movimento);
                        obsfiscal += p.Ds_observacaofiscal.Trim();

                        //Verificar se a empresa nao e substituto tributario, caso dos postos de combustives
                        if ((rImp.Vl_basecalcsubsttrib > decimal.Zero) &&
                            vTP_Movto.Trim().ToUpper().Equals("S") &&
                            (new TCD_CadEmpresa(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vCd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from TB_DIV_InscSubstEmpresa x " +
                                                    "where x.cd_empresa = a.cd_empresa)"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_PDC_CfgPosto x " +
                                                    "where x.cd_empresa = a.cd_empresa)"
                                    }
                                }, "1") != null))
                        {
                            obsfiscal += (string.IsNullOrEmpty(obsfiscal) ? string.Empty : " - ") +
                                "Base de Calculo de ST: R$" + rImp.Vl_basecalcsubsttrib.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) +
                                " - ICMS ST: R$" + rImp.Vl_impostosubsttrib.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            rImp.Vl_basecalcsubsttrib = decimal.Zero;
                            rImp.Pc_aliquotasubst = decimal.Zero;
                            rImp.Vl_impostosubsttrib = decimal.Zero;
                        }
                        //Buscar dados do imposto
                        TList_CadImposto lImposto = TCN_CadImposto.Busca(p.Cd_imposto.HasValue ? p.Cd_imposto.Value.ToString() : string.Empty,
                                                        string.Empty, banco);
                        if (lImposto.Count.Equals(0))
                            throw new Exception("Não existe dados cadastro para o imposto.");
                        rImp.Imposto.Cd_impostoSt = p.Cd_imposto.HasValue ? p.Cd_imposto.Value.ToString() : string.Empty;
                        rImp.Imposto.St_Cofins = lImposto[0].St_Cofins;
                        rImp.Imposto.St_CSLL = lImposto[0].St_CSLL;
                        rImp.Imposto.St_ICMS = lImposto[0].St_ICMS;
                        rImp.Imposto.St_INSS = lImposto[0].St_INSS;
                        rImp.Imposto.St_IRRF = lImposto[0].St_IRRF;
                        rImp.Imposto.St_ISSQN = lImposto[0].St_ISSQN;
                        rImp.Imposto.St_PIS = lImposto[0].St_PIS;
                        rImp.Imposto.St_Funrural = lImposto[0].St_Funrural;
                        rImp.Imposto.St_Senar = lImposto[0].St_Senar;
                        lImp.Add(rImp);
                    }
                });
            vObsFiscal = obsfiscal;
            return lImp;
        }

        public static void CalcImpostosGeral(TRegistro_ImpostosNF qtb_impostos,
                                             decimal vQuantidade,
                                             decimal vVl_BaseCalc,
                                             string vCD_UnidProduto,
                                             TObjetoBanco banco)
        {
            if ((!string.IsNullOrEmpty(qtb_impostos.Cd_unidade_ref)) && (qtb_impostos.Vl_imposto_unit > 0))
            {
                if (vQuantidade > 0)
                {
                    decimal vQuantidadeCalculada = TCN_CadConvUnidade.ConvertUnid(vCD_UnidProduto, qtb_impostos.Cd_unidade_ref, vQuantidade, 3, banco);
                    qtb_impostos.Pc_aliquota = (100 * (vQuantidadeCalculada * (qtb_impostos.Vl_imposto_unit / vVl_BaseCalc)));
                    qtb_impostos.Vl_basecalc = ((qtb_impostos.Pc_basecalc / 100) * vVl_BaseCalc);
                    qtb_impostos.Vl_impostocalc = (vQuantidadeCalculada * qtb_impostos.Vl_imposto_unit);
                }
                else
                    throw new Exception("Obrigatorio informar quantidade para calcular imposto sobre quantidade.");
            }
            else
            {
                qtb_impostos.Vl_basecalc = Math.Round(Math.Round((qtb_impostos.Pc_basecalc / 100), 2, MidpointRounding.AwayFromZero) * vVl_BaseCalc, 2, MidpointRounding.AwayFromZero);
                decimal vl_impretido = Math.Round((qtb_impostos.Vl_basecalc * qtb_impostos.Pc_retencao) / 100, 2, MidpointRounding.AwayFromZero);
                if (qtb_impostos.Vl_minimo > 0)
                {
                    if (vl_impretido >= qtb_impostos.Vl_minimo)
                    {
                        qtb_impostos.Vl_impostoretido = vl_impretido;
                        qtb_impostos.Vl_impostocalc = Math.Round((qtb_impostos.Vl_basecalc * (qtb_impostos.Pc_aliquota - qtb_impostos.Pc_retencao)) / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        qtb_impostos.Vl_impostoretido = 0;
                        qtb_impostos.Vl_impostocalc = Math.Round((qtb_impostos.Vl_basecalc * qtb_impostos.Pc_aliquota) / 100, 2, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    if (qtb_impostos.Pc_aliquota > decimal.Zero)
                        qtb_impostos.Vl_impostocalc = Math.Round((qtb_impostos.Vl_basecalc * (qtb_impostos.Pc_aliquota - qtb_impostos.Pc_retencao)) / 100, 2, MidpointRounding.AwayFromZero);
                    qtb_impostos.Vl_impostoretido = vl_impretido;
                }
            }
        }

        public static TList_ImpostosNF procuraCondicaoFiscalImpostos(string vCD_CondFiscal_Clifor,
                                                                     string vCD_CondFiscal_Produto,
                                                                     string vCD_Movto,
                                                                     string vTP_Movto,
                                                                     string vTP_Pessoa,
                                                                     string vCD_Empresa,
                                                                     string vNR_Serie,
                                                                     string vCD_Clifor,
                                                                     string vCD_UnidProduto,
                                                                     DateTime? vDT_Emissao,
                                                                     decimal vQuantidade,
                                                                     decimal vVl_BaseCalc,
                                                                     string vTp_nota,
                                                                     string vCd_municipioexecservico,
                                                                     TObjetoBanco banco)
        {
            //Verificar se existe condicao fiscal imposto configurada
            //para os parametros informados
            TpBusca[] filtro = new TpBusca[5];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            //Movimentacao
            filtro[1].vNM_Campo = "a.cd_movimentacao";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = vCD_Movto;
            //Tipo Movimento
            filtro[2].vNM_Campo = "a.tp_faturamento";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + vTP_Movto.Trim() + "'";
            //Tipo Pessoa
            filtro[3].vNM_Campo = "a.tp_pessoa";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'" + vTP_Pessoa.Trim() + "'";
            //Condicao Fiscal Clifor
            filtro[4].vNM_Campo = "a.cd_condfiscal_clifor";
            filtro[4].vOperador = "=";
            filtro[4].vVL_Busca = "'" + vCD_CondFiscal_Clifor.Trim() + "'";
            if (!string.IsNullOrEmpty(vCD_CondFiscal_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condfiscal_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_CondFiscal_Produto.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condfiscal_produto";
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "is null";
            }
            if (!string.IsNullOrEmpty(vCd_municipioexecservico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.cd_municipiogeradoriss, '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "case when b.st_issqn = 1 then '" + vCd_municipioexecservico.Trim() + "' else isnull(a.cd_municipiogeradoriss, '') end";
            }
            TList_CondicaoFiscalImposto lCondFiscal =
                new TCD_CondicaoFiscalImposto(banco).Select(filtro, 0, string.Empty);
            if (vTp_nota.Trim().ToUpper().Equals("P") &&
                (!lCondFiscal.Exists(p => p.St_pis || p.St_cofins)))
            {
                //Verificar o regime da empresa, se for simples gerar condicao fiscal imposto automaticamente
                object obj = new TCD_CadEmpresa(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vCD_Empresa.Trim() + "'"
                                    }
                                }, "a.tp_regimetributario");
                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("1"))//Simples Nacional
                {
                    //Gravar imposto PIS
                    if (!lCondFiscal.Exists(p => p.St_pis))
                    {
                        //Verificar se a serie e NF-e
                        if (new TCD_CadSerieNF(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_serie",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vNR_Serie.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_modelo",
                                        vOperador = "=",
                                        vVL_Busca = "'55'"
                                    }
                                }, "1") != null)
                        {
                            //Verificar se tem parametro para situacao tributaria isenta do pis configurada
                            string sittrib = TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_PIS", vCD_Empresa, banco);
                            if (!string.IsNullOrEmpty(sittrib))
                            {
                                //Buscar codigo imposto icms
                                obj = new TCD_CadImposto(banco).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.st_pis",
                                                vOperador = "=",
                                                vVL_Busca = "0"
                                            }
                                        }, "a.cd_imposto");
                                if (obj != null)
                                {
                                    object objtpimposto = new TCD_CadTpImposto_x_SitTrib(banco).BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_imposto",
                                                                    vOperador = "=",
                                                                    vVL_Busca = obj.ToString()
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_st",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + sittrib.Trim() + "'"
                                                                }
                                                            }, "a.tp_imposto");
                                    if (objtpimposto != null)
                                        TCN_CondicaoFiscalImposto.gravarFiscImposto(
                                            new TRegistro_CondicaoFiscalImposto()
                                            {
                                                cd_empresa = vCD_Empresa,
                                                Cd_impostostring = obj.ToString(),
                                                Cd_st = sittrib,
                                                Tp_imposto = objtpimposto.ToString(),
                                                Tp_faturamento = vTP_Movto,
                                                Tp_pessoa = vTP_Pessoa
                                            },
                                            new List<TRegistro_CadMovimentacao>()
                                        {
                                            new TRegistro_CadMovimentacao()
                                            {
                                                Cd_movimentacao = decimal.Parse(vCD_Movto)
                                            }
                                        },
                                            new List<TRegistro_CadCondFiscalClifor>()
                                        {
                                            new TRegistro_CadCondFiscalClifor()
                                            {
                                                Cd_condFiscal_clifor = vCD_CondFiscal_Clifor
                                            }
                                        },
                                            new List<TRegistro_CadCondFiscalProduto>()
                                        {
                                            new TRegistro_CadCondFiscalProduto()
                                            {
                                                CD_CONDFISCAL_PRODUTO = vCD_CondFiscal_Produto
                                            }
                                        },
                                        vTP_Pessoa.Trim().ToUpper().Equals("F"),
                                        vTP_Pessoa.Trim().ToUpper().Equals("J"),
                                        vTP_Pessoa.Trim().ToUpper().Equals("E"),
                                        banco);
                                }
                            }
                        }
                    }
                    //Gravar imposto COFINS
                    if (!lCondFiscal.Exists(p => p.St_cofins))
                    {
                        //Verificar se a serie e NF-e
                        if (new TCD_CadSerieNF(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_serie",
                                        vOperador = "=",
                                        vVL_Busca = "'" + vNR_Serie.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_modelo",
                                        vOperador = "=",
                                        vVL_Busca = "'55'"
                                    }
                                }, "1") != null)
                        {
                            //Verificar se tem parametro para situacao tributaria isenta do pis configurada
                            string sittrib = TCN_CadParamGer.BuscaVL_String_Empresa("CD_SITTRIB_ISENTA_COFINS", vCD_Empresa, banco);
                            if (!string.IsNullOrEmpty(sittrib))
                            {
                                //Buscar codigo imposto icms
                                obj = new TCD_CadImposto(banco).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.st_cofins",
                                                vOperador = "=",
                                                vVL_Busca = "0"
                                            }
                                        }, "a.cd_imposto");
                                if (obj != null)
                                {
                                    object objtpimposto = new TCD_CadTpImposto_x_SitTrib(banco).BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_imposto",
                                                                    vOperador = "=",
                                                                    vVL_Busca = obj.ToString()
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_st",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + sittrib.Trim() + "'"
                                                                }
                                                            }, "a.tp_imposto");
                                    if (objtpimposto != null)
                                        TCN_CondicaoFiscalImposto.gravarFiscImposto(
                                            new TRegistro_CondicaoFiscalImposto()
                                            {
                                                cd_empresa = vCD_Empresa,
                                                Cd_impostostring = obj.ToString(),
                                                Cd_st = sittrib,
                                                Tp_imposto = objtpimposto.ToString(),
                                                Tp_faturamento = vTP_Movto,
                                                Tp_pessoa = vTP_Pessoa
                                            },
                                            new List<TRegistro_CadMovimentacao>()
                                            {
                                                new TRegistro_CadMovimentacao()
                                                {
                                                    Cd_movimentacao = decimal.Parse(vCD_Movto)
                                                }
                                            },
                                                new List<TRegistro_CadCondFiscalClifor>()
                                            {
                                                new TRegistro_CadCondFiscalClifor()
                                                {
                                                    Cd_condFiscal_clifor = vCD_CondFiscal_Clifor
                                                }
                                            },
                                                new List<TRegistro_CadCondFiscalProduto>()
                                            {
                                                new TRegistro_CadCondFiscalProduto()
                                                {
                                                    CD_CONDFISCAL_PRODUTO = vCD_CondFiscal_Produto
                                                }
                                            },
                                            vTP_Pessoa.Trim().ToUpper().Equals("F"),
                                            vTP_Pessoa.Trim().ToUpper().Equals("J"),
                                            vTP_Pessoa.Trim().ToUpper().Equals("E"),
                                            banco);
                                }
                            }
                        }
                    }
                    lCondFiscal = new TCD_CondicaoFiscalImposto(banco).Select(filtro, 0, string.Empty);
                }
            }
            TList_ImpostosNF lImpostos = new TList_ImpostosNF();
            lCondFiscal.ForEach(p =>
            {
                if (!lImpostos.Exists(v => v.Cd_imposto.Value.Equals(p.Cd_imposto.Value)))
                {
                    decimal vTotalFaturado = totalNfdoMes(vCD_Empresa, vCD_Clifor, vDT_Emissao, banco);
                    bool st_calcularse = false;
                    if (p.st_calcularse.Trim().Equals("0"))
                        st_calcularse = true;
                    else if (p.st_calcularse.Trim().Equals("1"))
                        st_calcularse = (vTotalFaturado <= p.vl_totfaturadobase);
                    else
                        st_calcularse = (vTotalFaturado > p.vl_totfaturadobase);

                    TRegistro_ImpostosNF qtb_impostos = new TRegistro_ImpostosNF();
                    qtb_impostos.Cd_imposto = p.Cd_imposto;
                    qtb_impostos.Ds_imposto = p.Ds_imposto;
                    qtb_impostos.St_totalnota = p.St_totalnota;
                    qtb_impostos.Vl_minimo = p.vl_minimo;
                    qtb_impostos.Cd_unidade_ref = p.cd_unidade_ref;
                    qtb_impostos.Vl_imposto_unit = p.vl_imposto_unit;
                    qtb_impostos.Pc_aliquota = p.pc_aliquota;
                    qtb_impostos.Pc_retencao = p.pc_retencao;
                    qtb_impostos.Pc_basecalc = p.pc_basecalc;
                    qtb_impostos.St_gerarcredito = p.St_gerarcredito;
                    qtb_impostos.Dt_imposto = vDT_Emissao;
                    qtb_impostos.Tp_tributiss = p.Tp_tributiss;
                    qtb_impostos.Id_basecredito = p.Id_basecredito;
                    qtb_impostos.Id_tpcred = p.Id_tpcred;
                    qtb_impostos.Id_tpcontribuicao = p.Id_tpcontribuicao;
                    qtb_impostos.Id_detrecisenta = p.Id_detrecisenta;
                    qtb_impostos.Id_receita = p.Id_receita;
                    qtb_impostos.Tp_naturezaoperacaoiss = p.Tp_naturezaoperacaoiss;
                    CalcImpostosGeral(qtb_impostos, vQuantidade, vVl_BaseCalc, vCD_UnidProduto, banco);
                    //Buscar dados do imposto
                    TList_CadImposto lImposto =
                        TCN_CadImposto.Busca(p.Cd_imposto.HasValue ? p.Cd_imposto.Value.ToString() : string.Empty,
                                                    string.Empty, banco);
                    if (lImposto.Count.Equals(0))
                        throw new Exception("Não existe dados cadastro para o imposto.");
                    qtb_impostos.Imposto.Cd_impostoSt = p.Cd_imposto.HasValue ? p.Cd_imposto.Value.ToString() : string.Empty;
                    qtb_impostos.Cd_st = p.Cd_st;
                    qtb_impostos.Ds_situacao = p.Ds_situacao;
                    qtb_impostos.Tp_imposto = p.Tp_imposto;
                    qtb_impostos.Imposto.St_Cofins = lImposto[0].St_Cofins;
                    qtb_impostos.Imposto.St_CSLL = lImposto[0].St_CSLL;
                    qtb_impostos.Imposto.St_ICMS = lImposto[0].St_ICMS;
                    qtb_impostos.Imposto.St_INSS = lImposto[0].St_INSS;
                    qtb_impostos.Imposto.St_IRRF = lImposto[0].St_IRRF;
                    qtb_impostos.Imposto.St_ISSQN = lImposto[0].St_ISSQN;
                    qtb_impostos.Imposto.St_PIS = lImposto[0].St_PIS;
                    qtb_impostos.Imposto.St_IPI = lImposto[0].St_IPI;
                    qtb_impostos.Imposto.St_Funrural = lImposto[0].St_Funrural;
                    qtb_impostos.Imposto.St_Senar = lImposto[0].St_Senar;

                    lImpostos.Add(qtb_impostos);
                }
            });
            return lImpostos;
        }

        public static void PreencherICMS(TRegistro_ImpostosNF val, TRegistro_LanFaturamento_Item rItem)
        {
            rItem.Cd_ICMS = val.Cd_imposto;
            rItem.Cd_ST_ICMS = val.Cd_st;
            rItem.Tp_imposto = val.Tp_imposto;
            rItem.Pc_aliquotaICMS = val.Pc_aliquota;
            rItem.Pc_retencaoICMS = val.Pc_retencao;
            rItem.Vl_ICMSRetido = val.Vl_impostoretido;
            rItem.Vl_icms = val.Vl_impostocalc;
            rItem.Vl_basecalcICMS = val.Vl_basecalc;
            rItem.St_gerarcreditoICMS = val.St_gerarcreditobool;
            rItem.Vl_basecalcSTICMS = val.Vl_basecalcsubsttrib;
            rItem.Vl_ICMSST = val.Vl_impostosubsttrib;
            rItem.Pc_reducaobasecalcICMS = val.Pc_reducaobasecalc;
            rItem.Pc_aliquotaSTICMS = val.Pc_aliquotasubst;
            rItem.Pc_redbcstICMS = val.Pc_reducaobasecalcsubsttrib;
            rItem.Pc_diferidoICMS = val.Pc_reducaoaliquota;
            rItem.Vl_diferidoICMS = val.Vl_diferidoICMS;
            rItem.Tp_situacao = val.Tp_situacao;
            rItem.Vl_difal = val.Vl_difal;
            rItem.Pc_aliquotaICMSDest = val.Pc_aliquotaICMSDest;
            rItem.Pc_aliqopdifal = val.Pc_aliqopdifal;
            rItem.Ds_deducao = val.Ds_deducao;
            rItem.Pc_FCP = val.Pc_FCP;
            rItem.Vl_FCP = val.Vl_FCP;
            rItem.Pc_FCPST = val.Pc_FCPST;
            rItem.Vl_FCPST = val.Vl_FCPST;
            rItem.Vl_pauta = val.Vl_pauta;
            rItem.Pc_iva_st = val.Pc_iva_st;
            rItem.Vl_mva = val.Vl_mva;
            rItem.Tp_modbasecalc = val.Tp_modbasecalc;
            rItem.Tp_modbasecalcST = val.Tp_modbasecalcST;
            rItem.St_somarIPIBaseICMS = val.St_somarIPIBaseICMS;
            rItem.St_somarIPIBaseST = val.St_somarIPIBaseST;
        }

        public static void PreencherOutrosImpostos(TList_ImpostosNF impostos,
                                                   TRegistro_LanFaturamento_Item rItem,
                                                   string Tp_movimento)
        {
            #region PIS
            if (impostos.Exists(p => p.Imposto.St_PIS))
            {
                TRegistro_ImpostosNF pis = impostos.Find(p => p.Imposto.St_PIS);
                rItem.Cd_PIS = pis.Cd_imposto;
                rItem.Cd_ST_PIS = pis.Cd_st;
                rItem.Id_BaseCreditoPIS = pis.Id_basecredito;
                rItem.Id_TpCredPIS = pis.Id_tpcred;
                rItem.Id_TpContribuicaoPIS = pis.Id_tpcontribuicao;
                rItem.Id_detrecisentaPIS = pis.Id_detrecisenta;
                rItem.Id_receitaPIS = pis.Id_receita;
                rItem.Tp_imposto = pis.Tp_imposto;
                rItem.Pc_aliquotaPIS = pis.Pc_aliquota;
                rItem.Vl_pis = pis.Vl_impostocalc;
                rItem.Vl_basecalcPIS = pis.Vl_basecalc;
                rItem.St_gerarcreditoPIS = pis.St_gerarcreditobool;
                rItem.Tp_situacao = pis.Tp_situacao;
                rItem.St_totalnotaPIS = pis.St_totalnota;
                rItem.Vl_imposto_unit_PIS = pis.Vl_imposto_unit;
                rItem.Pc_retencaoPIS = pis.Pc_retencao;
                rItem.Vl_retidoPIS = pis.Vl_impostoretido;
            }
            #endregion

            #region COFINS
            if (impostos.Exists(p => p.Imposto.St_Cofins))
            {
                TRegistro_ImpostosNF cofins = impostos.Find(p => p.Imposto.St_Cofins);
                rItem.Cd_COFINS = cofins.Cd_imposto;
                rItem.Cd_ST_COFINS = cofins.Cd_st;
                rItem.Id_BaseCreditoCofins = cofins.Id_basecredito;
                rItem.Id_TpCredCofins = cofins.Id_tpcred;
                rItem.Id_TpContribuicaoCofins = cofins.Id_tpcontribuicao;
                rItem.Id_detrecisentaCofins = cofins.Id_detrecisenta;
                rItem.Id_receitaCofins = cofins.Id_receita;
                rItem.Tp_imposto = cofins.Tp_imposto;
                rItem.Pc_aliquotaCofins = cofins.Pc_aliquota;
                rItem.Vl_cofins = cofins.Vl_impostocalc;
                rItem.Vl_basecalcCofins = cofins.Vl_basecalc;
                rItem.St_gerarcreditoCofins = cofins.St_gerarcreditobool;
                rItem.Tp_situacao = cofins.Tp_situacao;
                rItem.St_totalnotaCofins = cofins.St_totalnota;
                rItem.Vl_imposto_unit_Cofins = cofins.Vl_imposto_unit;
                rItem.Pc_retencaoCofins = cofins.Pc_retencao;
                rItem.Vl_retidoCofins = cofins.Vl_impostoretido;
            }
            #endregion

            #region IPI
            if (impostos.Exists(p => p.Imposto.St_IPI))
            {
                TRegistro_ImpostosNF ipi = impostos.Find(p => p.Imposto.St_IPI);
                rItem.Cd_IPI = ipi.Cd_imposto;
                rItem.Cd_ST_IPI = ipi.Cd_st;
                rItem.Tp_imposto = ipi.Tp_imposto;
                rItem.Pc_aliquotaIPI = ipi.Pc_aliquota;
                rItem.Vl_ipi = ipi.Vl_impostocalc;
                rItem.Vl_basecalcIPI = ipi.Vl_basecalc;
                rItem.St_gerarcreditoIPI = ipi.St_gerarcreditobool;
                rItem.Tp_situacao = ipi.Tp_situacao;
                rItem.St_totalnotaIPI = ipi.St_totalnota;
                rItem.Vl_imposto_unit_ipi = ipi.Vl_imposto_unit;
                if (!string.IsNullOrEmpty(rItem.Cd_ST_ICMS) &&
                    (rItem.St_somarIPIBaseICMS || rItem.St_somarIPIBaseST))
                {
                    TRegistro_ImpostosNF rImp = new TRegistro_ImpostosNF();
                    rImp.Cd_imposto = rItem.Cd_ICMS;
                    rImp.Pc_aliquota = rItem.Pc_aliquotaICMS;
                    rImp.Pc_reducaoaliquota = rItem.Pc_diferidoICMS;
                    rImp.Pc_reducaobasecalc = rItem.Pc_reducaobasecalcICMS;
                    rImp.Pc_aliquotasubst = rItem.Pc_aliquotaSTICMS;
                    rImp.Pc_reducaobasecalcsubsttrib = rItem.Pc_redbcstICMS;
                    rImp.Tp_situacao = rItem.Tp_situacao;
                    rImp.Dt_imposto = rItem.Dt_emissao;
                    rImp.St_impostouf = 0;
                    rImp.Tp_modbasecalc = rItem.Tp_modbasecalc;
                    rImp.Tp_modbasecalcST = rItem.Tp_modbasecalcST;
                    rImp.Cd_st = rItem.Cd_ST_ICMS;
                    //Buscar situacao tributaria
                    TList_CadSitTribut lST =
                    new TCD_CadSitTribut().Select(new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "a.cd_imposto",
                            vOperador = "=",
                            vVL_Busca = rItem.Cd_ICMS?.ToString()
                        },
                        new TpBusca
                        {
                            vNM_Campo= "a.cd_st",
                            vOperador = "=",
                            vVL_Busca = "'" + rItem.Cd_ST_ICMS.Trim() + "'"
                        }
                    }, 1, string.Empty);
                    if (lST.Count > 0)
                    {
                        rImp.St_substtrib = lST[0].St_substtribbool;
                        rImp.St_simplesnacional = lST[0].St_simplesnacionalbool;
                    }
                    rImp.Pc_iva_st = rItem.Pc_iva_st;
                    rImp.Vl_mva = rItem.Vl_mva;
                    rImp.Pc_aliquotaICMSDest = rItem.Pc_aliquotaICMSDest;
                    rItem.Pc_aliqopdifal = rItem.Pc_aliqopdifal;
                    rImp.Vl_pauta = rItem.Vl_pauta;
                    rImp.St_somarIPIBaseICMS = rItem.St_somarIPIBaseICMS;
                    rImp.St_somarIPIBaseST = rItem.St_somarIPIBaseST;
                    rImp.Vl_ipisomar = ipi.Vl_impostocalc;
                    rImp.Pc_FCP = rItem.Pc_FCP;
                    rImp.Pc_FCPST = rItem.Pc_FCPST;
                    //Calcular Imposto
                    CalcImpostos(rImp, rItem.Vl_basecalcImposto, rItem.Quantidade, Tp_movimento);
                    //Preencher ICMS Item Nota
                    PreencherICMS(rImp, rItem);
                }
            }
            #endregion

            #region Funrural
            if (impostos.Exists(p => p.Imposto.St_Funrural))
            {
                TRegistro_ImpostosNF funrural = impostos.Find(p => p.Imposto.St_Funrural);
                rItem.Vl_basecalcFunrural = funrural.Vl_basecalc;
                rItem.Pc_funrural = funrural.Pc_aliquota;
                rItem.Vl_funrural = funrural.Vl_impostocalc;
                rItem.Pc_retencaoFunrural = funrural.Pc_retencao;
                rItem.Vl_retidoFunrural = funrural.Vl_impostoretido;
                rItem.Tp_imposto = funrural.Tp_imposto;
            }
            #endregion

            #region Senar
            if (impostos.Exists(p => p.Imposto.St_Senar))
            {
                TRegistro_ImpostosNF senar = impostos.Find(p => p.Imposto.St_Senar);
                rItem.Vl_basecalcSenar = senar.Vl_basecalc;
                rItem.Pc_senar = senar.Pc_aliquota;
                rItem.Vl_senar = senar.Vl_impostocalc;
                rItem.Pc_retencaoSenar = senar.Pc_retencao;
                rItem.Vl_retidoSenar = senar.Vl_impostoretido;
                rItem.Tp_imposto = senar.Tp_imposto;
            }
            #endregion

            #region IRRF
            if (impostos.Exists(p => p.Imposto.St_IRRF))
            {
                TRegistro_ImpostosNF irrf = impostos.Find(p => p.Imposto.St_IRRF);
                rItem.Vl_basecalcIRRF = irrf.Vl_basecalc;
                rItem.Pc_retencaoIRRF = irrf.Pc_retencao;
                rItem.Vl_retidoIRRF = irrf.Vl_impostoretido;
                rItem.Tp_imposto = irrf.Tp_imposto;
            }
            #endregion

            #region CSLL
            if (impostos.Exists(p => p.Imposto.St_CSLL))
            {
                TRegistro_ImpostosNF csll = impostos.Find(p => p.Imposto.St_CSLL);
                rItem.Vl_basecalcCSLL = csll.Vl_basecalc;
                rItem.Pc_retencaoCSLL = csll.Pc_retencao;
                rItem.Vl_retidoCSLL = csll.Vl_impostoretido;
                rItem.Tp_imposto = csll.Tp_imposto;
            }
            #endregion

            #region INSS
            if (impostos.Exists(p => p.Imposto.St_INSS))
            {
                TRegistro_ImpostosNF inss = impostos.Find(p => p.Imposto.St_INSS);
                rItem.Vl_basecalcINSS = inss.Vl_basecalc;
                rItem.Pc_retencaoINSS = inss.Pc_retencao;
                rItem.Vl_retidoINSS = inss.Vl_impostoretido;
                rItem.Tp_imposto = inss.Tp_imposto;
            }
            #endregion

            #region II
            if (impostos.Exists(p => p.Imposto.St_II))
            {
                rItem.Vl_basecalcII = impostos.Find(v => v.Imposto.St_II).Vl_basecalc;
                rItem.Pc_aliquotaII = impostos.Find(v => v.Imposto.St_II).Pc_aliquota;
                rItem.Vl_II = impostos.Find(v => v.Imposto.St_II).Vl_impostocalc;
            }
            #endregion

            #region ISS
            if (impostos.Exists(p => p.Imposto.St_ISSQN))
            {
                TRegistro_ImpostosNF iss = impostos.Find(p => p.Imposto.St_ISSQN);
                rItem.Tp_imposto = iss.Tp_imposto;
                rItem.Pc_aliquotaISS = iss.Pc_aliquota;
                rItem.Pc_retencaoISS = iss.Pc_retencao;
                rItem.Vl_iss = iss.Vl_impostocalc;
                rItem.Vl_issretido = iss.Vl_impostoretido;
                rItem.Vl_basecalcISS = iss.Vl_basecalc;
                rItem.St_gerarcreditoISS = iss.St_gerarcreditobool;
                rItem.Tp_situacao = iss.Tp_situacao;
                rItem.St_totalnotaISS = iss.St_totalnota;
                rItem.Tp_tributISS = iss.Tp_tributiss;
                rItem.Tp_naturezaOperacaoISS = iss.Tp_naturezaoperacaoiss;
                rItem.Pc_reducaobasecalcISS = iss.Pc_reducaobasecalc;
                rItem.Ds_deducao = iss.Ds_deducao;
            }
            #endregion
        }
    }
}
