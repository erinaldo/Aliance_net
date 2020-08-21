using System;
using Utils;
using System.Collections.Generic;
using System.Linq;
using CamadaDados.Faturamento.Orcamento;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using System.IO;
using System.Windows.Forms;
using CamadaDados.Producao.Producao;
using CamadaNegocio.Producao.Producao;
using CamadaNegocio.Estoque;
using CamadaNegocio.Estoque.Cadastros;
using System.Globalization;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;

namespace CamadaNegocio.Faturamento.Orcamento
{
    public class TCN_Orcamento
    {
        public static TList_Orcamento Buscar(string Nr_orcamento,
                                             string Cd_empresa,
                                             string Cd_condpgto,
                                             string Cd_vendedor,
                                             string Cd_representante,
                                             string Cd_tabelapreco,
                                             string Cd_produto,
                                             string Nm_clifor,
                                             string Ds_endereco,
                                             string UF,
                                             string Dt_ini,
                                             string Dt_fin,
                                             decimal Vl_inicial,
                                             decimal Vl_final,
                                             string St_registro,
                                             string St_OrcPedido,
                                             string St_orcprojeto,
                                             string Nr_orcorigem,
                                             bool St_faturado,
                                             bool St_saldofaturar,
                                             string Nr_Pedido,
                                             string cd_grupo,
                                             bool St_orcVendedor,
                                             bool St_itensabaixocusto,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_orcamento;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_condpgto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_vendedor;
            }
            if (!string.IsNullOrEmpty(Cd_representante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_representante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_representante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabelapreco.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Orcamento_Item x " +
                                                      "where x.NR_Orcamento = a.NR_Orcamento " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_clifor.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Ds_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_endereco";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_endereco.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(UF))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.uf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + UF.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_orcamento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_orcamento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (Vl_inicial > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ISNULL(a.Vl_totalitens, 0) + ISNULL(a.VL_JURO_FIN, 0) + case when b.TP_Frete = '0' then ISNULL(a.VL_FRETE, 0) ELSE 0 END + " +
                                                      "ISNULL(a.VL_ACRESCIMO, 0) - ISNULL(a.VL_DESCONTO)";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), Vl_inicial.ToString());
            }
            if (Vl_final > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ISNULL(a.Vl_totalitens, 0) + ISNULL(a.VL_JURO_FIN, 0) + case when b.TP_Frete = '0' then ISNULL(a.VL_FRETE, 0) ELSE 0 END + " +
                                                      "ISNULL(a.VL_ACRESCIMO, 0) - ISNULL(a.VL_DESCONTO)";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new CultureInfo("en-US", true), Vl_final.ToString());
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_OrcPedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.St_OrcPedido";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_OrcPedido.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_orcprojeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_orcprojeto, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_orcprojeto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_orcorigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcorigem";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nr_orcorigem.Trim() + "%'";
            }
            if (St_faturado)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_fat_orcamento_item x " +
                                                      "where x.nr_orcamento = a.nr_orcamento " +
                                                      "and (x.vl_subtotal + x.vl_juro_fin + x.vl_acrescimo + x.vl_frete - x.vl_desconto - x.vl_faturado) > 0)";
            }
            if (St_saldofaturar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_fat_orcamento_item x " +
                                                      "where x.nr_orcamento = a.nr_orcamento " +
                                                      "and (x.vl_subtotal + x.vl_juro_fin + x.vl_acrescimo + x.vl_frete - x.vl_desconto - x.vl_faturado) > 0)";
            }
            if (!string.IsNullOrEmpty(Nr_Pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                                      "where x.nr_orcamento = a.nr_orcamento " +
                                                      "and x.nr_pedido = '" + Nr_Pedido + "')";
            }
            if (!string.IsNullOrEmpty(cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "( select 1  from TB_FAT_Orcamento_Item x  "
                                                    + " join tb_est_produto y on y.cd_produto = x.cd_produto"
                                                    + " join TB_EST_GrupoProduto z on z.cd_grupo = y.cd_grupo "
                                                    + " where z.cd_grupo_pai = " + cd_grupo + "  and x.NR_Orcamento = a.NR_Orcamento)";
            }
            if (St_orcVendedor)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(c.LoginVendedor = '" + Parametros.pubLogin.Trim() + "' or exists(select 1 from TB_DIV_Usuario_X_RegraEspecial x where x.login = '" + Parametros.pubLogin.Trim() + "' and x.DS_Regra = 'PERMITIR ALTERAR PEDIDO OUTROS VENDEDORES'))";
            }
            if (St_itensabaixocusto)
                Estruturas.CriarParametro(ref filtro, string.Empty,
                    "(select 1 from vtb_fat_orcamento_item x " +
                    "where x.nr_orcamento = a.nr_orcamento " +
                    "and case when x.quantidade > 0 then " +
                    "x.vl_subtotal + x.vl_acrescimo + x.vl_juro_fin - x.vl_desconto + case when x.st_somarfrete = 'S' then x.vl_frete else 0 end / x.quantidade else 0 end < x.vl_custo)", "exists");


            return new TCD_Orcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_Orcamento BuscarPosVenda(string Nr_orcamento,
                                                       string Cd_empresa,
                                                       string Cd_clifor,
                                                       string Nr_pedido,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       bool rbSemPosVenda,
                                                       bool rbComPosVenda,
                                                       bool rbTodas,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "exists";
            filtro[0].vVL_Busca = "(select 1 " +
                                  "from VTB_FAT_Pedido ped " +
                                  "inner join VTB_FAT_Orcamento a on a.NR_Orcamento = ped.NR_Orcamento " +
                                  "and b.CD_Empresa = ped.CD_Empresa " +
                                  "inner join TB_FAT_Pedido_Itens pedI " +
                                  "on ped.NR_Pedido = pedI.NR_Pedido " +
                                  "inner join TB_FAT_NotaFiscal nf " +
                                  "on ped.NR_Pedido = nf.NR_Pedido " +
                                  "and ped.CD_Empresa = nf.CD_Empresa " +
                                  "where isnull(a.ST_Registro, 'AB') <> 'CA' " +
                                  "and isnull(nf.ST_Registro, 'A') <> 'C' " +
                                  "and isnull(pedI.ST_Registro, 'A') <> 'C')";

            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "b.cd_empresa", Cd_empresa);
            if (!string.IsNullOrEmpty(Cd_clifor))
                Estruturas.CriarParametro(ref filtro, "a.cd_clifor", Cd_clifor);
            if (!string.IsNullOrEmpty(Nr_pedido))
                Estruturas.CriarParametro(ref filtro, "ped.nr_pedido", Nr_pedido);
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_orcamento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_orcamento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            if (rbSemPosVenda)
                Estruturas.CriarParametro(ref filtro, "", 
                    "(select 1 from tb_fat_posvenda_x_proposta x " +
                    "inner join TB_FAT_PosVenda z on z.ID_PosVenda = x.ID_PosVenda " +
                    "where b.cd_empresa = x.cd_empresa " + 
                    "and a.NR_Orcamento = x.NR_Orcamento " +
                    "and isnull(z.st_registro, 'A') <> 'C')", "not exists");
            else if (rbComPosVenda)
                Estruturas.CriarParametro(ref filtro, "", 
                    "(select 1 from tb_fat_posvenda_x_proposta x " +
                    "inner join TB_FAT_PosVenda z on z.ID_PosVenda = x.ID_PosVenda " +
                    "where b.cd_empresa = x.cd_empresa " + 
                    "and a.NR_Orcamento = x.NR_Orcamento " + 
                    "and isnull(z.st_registro, 'A') <> 'C')", "exists");

            return new TCD_Orcamento(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                val.Nr_orcamento = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_orc.Gravar(val), "@P_NR_ORCAMENTO"));
                if (val.Nr_pedidovenda != null)
                {
                    //Deletar Itens
                    val.rPedido.Pedido_Itens.ForEach(p => TCN_LanPedido_Item.DeletaPedido_Item(p, qtb_orc.Banco_Dados));
                    //Excluir itens
                    val.lItensDel.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_Orcamento_Item.Excluir(p, qtb_orc.Banco_Dados);
                    });
                    //Gravar itens
                    val.lItens.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_Orcamento_Item.Gravar(p, qtb_orc.Banco_Dados);
                    });
                    //Deletar Parcela
                    val.rPedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(val.rPedido.Nr_pedido, qtb_orc.Banco_Dados);
                    val.rPedido.Pedidos_DT_Vencto.ForEach(p => TCN_LanPedido_DT_Vencto.Excluir(p, qtb_orc.Banco_Dados));
                    //Excluir financeiro
                    TList_Orcamento_DT_Vencto lParc = TCN_Orcamento_DT_Vencto.Buscar(val.Nr_orcamentostr, qtb_orc.Banco_Dados);
                    lParc.ForEach(p => TCN_Orcamento_DT_Vencto.Excluir(p, qtb_orc.Banco_Dados));
                    //Gravar financeiro
                    val.lParcelas.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_Orcamento_DT_Vencto.Gravar(p, qtb_orc.Banco_Dados);
                    });
                    //Gravar Itens Compra Projeto
                    val.lItensCompra.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_ItensCompraOrcProj.Gravar(p, qtb_orc.Banco_Dados);
                    });
                    //Excluir Itens Compra Projeto
                    val.lItensCompraDel.ForEach(p => TCN_ItensCompraOrcProj.Excluir(p, qtb_orc.Banco_Dados));
                    //Buscar CFG
                    CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg = Cadastros.TCN_CFGOrcamento.Buscar(val.Cd_empresa,
                                                                                                                  string.Empty,
                                                                                                                  string.Empty,
                                                                                                                  qtb_orc.Banco_Dados);
                    //Processar Orçamento novamente
                    ProcessarOrcamento(val, lCfg[0], qtb_orc.Banco_Dados);

                }
                else
                {
                    //Excluir itens
                    val.lItensDel.ForEach(p =>
                        {
                            p.Nr_orcamento = val.Nr_orcamento;
                            TCN_Orcamento_Item.Excluir(p, qtb_orc.Banco_Dados);
                        });
                    //Gravar itens
                    val.lItens.ForEach(p =>
                        {
                            p.Nr_orcamento = val.Nr_orcamento;
                            TCN_Orcamento_Item.Gravar(p, qtb_orc.Banco_Dados);
                        });
                    //Excluir financeiro
                    TList_Orcamento_DT_Vencto lParc = TCN_Orcamento_DT_Vencto.Buscar(val.Nr_orcamentostr, qtb_orc.Banco_Dados);
                    lParc.ForEach(p => TCN_Orcamento_DT_Vencto.Excluir(p, qtb_orc.Banco_Dados));
                    //Gravar financeiro
                    val.lParcelas.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_Orcamento_DT_Vencto.Gravar(p, qtb_orc.Banco_Dados);
                    });
                    //Excluir Itens Compra Projeto
                    val.lItensCompraDel.ForEach(p => TCN_ItensCompraOrcProj.Excluir(p, qtb_orc.Banco_Dados));
                    //Gravar Itens Compra Projeto
                    val.lItensCompra.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        TCN_ItensCompraOrcProj.Gravar(p, qtb_orc.Banco_Dados);
                    });
                }

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Nr_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                //Excluir itens
                val.lItens.ForEach(p => TCN_Orcamento_Item.Excluir(p, qtb_orc.Banco_Dados));
                val.lItensDel.ForEach(p => TCN_Orcamento_Item.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir financeiro
                TList_Orcamento_DT_Vencto lParc = TCN_Orcamento_DT_Vencto.Buscar(val.Nr_orcamentostr, qtb_orc.Banco_Dados);
                lParc.ForEach(p => TCN_Orcamento_DT_Vencto.Excluir(p, qtb_orc.Banco_Dados));
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Nr_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string AlterarVendedor(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                //Alterar Orçamento e Pedido
                hs.Add("@CD_VENDEDOR", val.Cd_vendedor);
                hs.Add("@NR_PEDIDO", val.Nr_pedidovenda);
                hs.Add("@NR_ORCAMENTO", val.Nr_orcamento);
                new CamadaDados.TDataQuery().executarSql("update TB_FAT_DadosPedido set CD_VENDEDOR = @CD_VENDEDOR, Dt_alt = GETDATE() " +
                                                         "where Nr_pedido = @NR_PEDIDO " +
                                                         "update TB_FAT_Pedido_Itens set CD_VENDEDOR = @CD_VENDEDOR, Dt_alt = GETDATE() " +
                                                         "where Nr_pedido = @NR_PEDIDO " +
                                                         "update TB_FAT_Orcamento set CD_VENDEDOR = @CD_VENDEDOR, Dt_alt = GETDATE() " +
                                                         "where NR_Orcamento = @NR_ORCAMENTO ", hs);
                //Reprocessar Comissão
                val.rPedido.Pedido_Itens.ForEach(p =>
                {
                    p.Cd_vendedor = val.Cd_vendedor;
                    TCN_LanPedido_Item.ProcessarComissao(p, qtb_orc.Banco_Dados);
                });
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Nr_orcamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        
        public static void AlterarClienteProposta(TRegistro_Orcamento val, string Cd_clifor, string MotivoTroca, string Login, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                //Verificar se proposta possui nota fiscal
                if(new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                        "inner join tb_fat_pedido_itens y " +
                                        "on x.nr_pedido = y.nr_pedido " +
                                        "and x.cd_produto = y.cd_produto " +
                                        "and x.id_pedidoitem = y.id_pedidoitem " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                        "and y.nr_orcamento = " + val.Nr_orcamentostr + ")"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido trocar cliente de proposta com FATURAMENTO.");
                //Verificar se proposta possui expedição
                if (new TCD_ItensExpedicao().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.nr_orcamento = " + val.Nr_orcamentostr + ")"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido trocar cliente de proposta com EXPEDIÇÃO.");
                //Verificar se proposta possui boleto ativo
                if (new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "=", vVL_Busca = "'A'" },
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                        "inner join tb_fat_pedido_itens y " +
                                        "on x.nr_pedido = y.nr_pedido " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and y.nr_orcamento = " + val.Nr_orcamentostr + ")"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido trocar cliente de proposta com BOLETO em ABERTO.");
                TRegistro_TrocaCliente rTroca = new TRegistro_TrocaCliente();
                TList_RegLanDuplicata lDup = new TList_RegLanDuplicata();
                //Copiar pedido
                TRegistro_Pedido rPed =
                new TCD_Pedido().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca
                                            {
                                                vNM_Campo = "isnull(a.st_pedido, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                                            "where x.nr_pedido = a.nr_pedido " +
                                                            "and x.nr_orcamento = " + val.Nr_orcamentostr + ")"
                                            }
                                        }, 1, string.Empty).FirstOrDefault();
                if (rPed != null)
                {
                    rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                    //Buscar itens do pedido
                    rPed.Pedido_Itens = TCN_LanPedido_Item.Busca(string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                rPed.Nr_pedido.ToString(),
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                false,
                                                                null);
                    rPed.Pedido_Itens.ForEach(v => { v.Nr_pedido = 0; v.Id_pedidoitem = 0; });
                    //Vencto Pedido
                    rPed.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(rPed.Nr_pedido, null);
                    rPed.Pedidos_DT_Vencto.ForEach(v => { v.Nr_Pedido = 0; v.Id_vencto = 0; });
                    //Verificar se pedido exige etapa
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CFG_Pedido",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CFG_Pedido.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.ST_ExigeEtapa, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, "1") == null)
                    {
                        rPed.ST_Pedido = "F";
                        rPed.St_registro = "F";
                    }
                    else
                    {
                        rPed.ST_Pedido = "A";
                        rPed.St_registro = "A";
                        //Preencher etapas
                        CamadaDados.Faturamento.Cadastros.TList_CadEtapa lEtapa =
                            Cadastros.TCN_CadEtapa.Busca(string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        null);

                        if (lEtapa.Count > 0)
                            lEtapa.ForEach(p =>
                            {
                                TRegistro_EtapaPedido rEtapa =
                                new TRegistro_EtapaPedido();
                                rEtapa.Id_etapa = p.Id_etapa;
                                rEtapa.DS_Etapa = p.DS_Etapa;
                                rEtapa.Dt_ini = CamadaDados.UtilData.Data_Servidor();
                                rEtapa.St_registro = "A";
                                rPed.lEtapa.Add(rEtapa);
                            });
                        //Preencher Processos da Etapa
                        if (rPed.lEtapa.Count > 0)
                            rPed.lEtapa.ForEach(p =>
                            {
                                //Buscar Processos da Etapa
                                CamadaDados.Faturamento.Cadastros.TList_ProcessoEtapa lProc =
                                        Cadastros.TCN_CadProcessoEtapa.Busca(p.Id_etapastr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                                lProc.ForEach(v =>
                                {
                                    TRegistro_ProcEtapa rProcEtapa = new TRegistro_ProcEtapa();
                                    rProcEtapa.Id_etapa = v.Id_etapa;
                                    rProcEtapa.Id_processo = v.ID_Processo;
                                    p.lProcEtapa.Add(rProcEtapa);
                                });
                            });
                    }

                    //Duplicatas do pedido
                    lDup = new TCD_LanDuplicata().Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.nr_pedido = " + rPed.Nr_pedido.ToString() + ")"
                            }
                        }, 0, string.Empty);
                    //Buscar Parcelas das duplicatas
                    lDup.ForEach(v =>
                    {
                        v.Parcelas = TCN_LanParcela.Busca(v.Cd_empresa, v.Nr_lancto, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, null);
                        v.Parcelas.Where(y => y.Vl_liquidado > decimal.Zero)
                        .ToList()
                        .ForEach(y => y.Liquidacoes = TCN_LanLiquidacao.Busca(y.Cd_empresa,
                                                                                y.Nr_lancto.Value,
                                                                                y.Cd_parcela.Value,
                                                                                decimal.Zero,
                                                                                string.Empty,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                decimal.Zero,
                                                                                false,
                                                                                "A",
                                                                                0,
                                                                                string.Empty,
                                                                                null));
                    });
                }
                else throw new Exception("Não foi encontrado pedido para a proposta.");
                //Buscar conta para quitar adiantamento
                object objConta = new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" }
                    }, "a.cd_contager");
                if (objConta == null)
                    throw new Exception("Não existe conta gerencial cadastrada na config. de orçamento para realizar troca.");
                string cd_contager = objConta.ToString();
                object objPortador = new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" }
                    }, "a.cd_portador");
                if (objPortador == null)
                    throw new Exception("Não existe portador cadastrado na config. de orçamento para realizar troca.");
                string cd_portador = objPortador.ToString();
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Encerrar pedido origem
                qtb_orc.executarSql("update tb_fat_pedido set st_pedido = 'P', st_registro = 'P' where nr_pedido = " + rPed.Nr_pedido.ToString(), null);
                //Gravar novo pedido
                rTroca.Nr_pedidoorigem = rPed.Nr_pedido;
                rPed.Nr_pedido = 0;
                rPed.CD_Clifor = Cd_clifor;
                TCN_Pedido.Grava_Pedido(rPed, qtb_orc.Banco_Dados);
                //Liquidar parcelas em aberto do pedido origem
                lDup.ForEach(x =>
                {
                    x.Parcelas.Where(v => v.Vl_atual > decimal.Zero)
                    .ToList()
                    .ForEach(v =>
                    {
                        //Gerar Liquidacao
                        TRegistro_LanLiquidacao regLiquidacao = new TRegistro_LanLiquidacao();
                        regLiquidacao.Cd_empresa = v.Cd_empresa;
                        regLiquidacao.Nr_lancto = v.Nr_lancto;
                        regLiquidacao.Nr_docto = v.Nr_docto;
                        regLiquidacao.Dt_Liquidacao = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                        regLiquidacao.Cd_contager = cd_contager;
                        regLiquidacao.Cd_historico = x.Cd_historico;//Historico de quitacao
                        regLiquidacao.Cd_historico_desc = x.Cd_historico_Desconto;
                        regLiquidacao.ComplHistorico = v.complHistorico;
                        regLiquidacao.Tp_mov = v.Tp_mov;
                        regLiquidacao.Cd_portador = cd_portador;
                        regLiquidacao.cVl_Atual = v.Vl_atual;
                        regLiquidacao.cVl_descontoconcedido = v.Vl_atual;
                        regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                        regLiquidacao.cVl_juroliquidar = decimal.Zero;
                        regLiquidacao.cVl_JuroTotal = decimal.Zero;
                        regLiquidacao.cVl_Liquidado = decimal.Zero;
                        regLiquidacao.cVl_Nominal = v.Vl_atual;
                        regLiquidacao.Cvl_aliquidar_padrao = v.Vl_atual;
                        regLiquidacao.cVl_adiantamento = decimal.Zero;
                        regLiquidacao.lCred = null;
                        regLiquidacao.Vl_trocoCH = decimal.Zero;
                        regLiquidacao.Vl_trocoDH = decimal.Zero;
                        regLiquidacao.lChTroco = null;
                        regLiquidacao.Vl_adto = decimal.Zero;
                        regLiquidacao.St_AdtoTrocoCH = false;
                        //Gravar liquidacao                    
                        TCN_LanLiquidacao.GravarLiquidacao(new List<TRegistro_LanParcela> { v },
                                                           regLiquidacao,
                                                           null,
                                                           null,
                                                           null,
                                                           null,
                                                           qtb_orc.Banco_Dados);
                        rTroca.Troca_X_Mov.Add(new TRegistro_Troca_X_Mov { Cd_empresa = v.Cd_empresa, Nr_lancto = v.Nr_lancto, Cd_parcela = v.Cd_parcela, Id_liquid = regLiquidacao.Id_liquid });
                    });
                });
                if (lDup.Count > 0)
                {
                    //Gravar duplicata do pedido
                    for (int i = 0; i < lDup.Count; i++)
                    {
                        TRegistro_LanDuplicata cloneDup = (TRegistro_LanDuplicata)lDup[i].Clone();
                        cloneDup.Parcelas.ForEach(x => x.St_registro = "A");
                        rPed.lDup.Add(cloneDup);
                    }
                    rPed.lDup.ForEach(p => { p.Nr_lancto = 0; p.Cd_clifor = Cd_clifor; });
                    TCN_Pedido.GravaDuplicata(rPed, qtb_orc.Banco_Dados);
                    //Verificar liquidações
                    for (int i = 0; i < lDup.Count; i++)
                    {
                        for(int x = 0; x < lDup[i].Parcelas.Count; x++)
                        {
                            if(lDup[i].Parcelas[x].Vl_liquidado > decimal.Zero)
                            {
                                //Gerar Liquidacao
                                TRegistro_LanLiquidacao regLiquidacao = new TRegistro_LanLiquidacao();
                                regLiquidacao.Cd_empresa = rPed.lDup[i].Cd_empresa;
                                regLiquidacao.Nr_lancto = rPed.lDup[i].Nr_lancto;
                                regLiquidacao.Nr_docto = rPed.lDup[i].Nr_docto;
                                regLiquidacao.Dt_Liquidacao = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                                regLiquidacao.Cd_contager = cd_contager;
                                regLiquidacao.Cd_historico = rPed.lDup[i].Cd_historico;//Historico de quitacao
                                regLiquidacao.Cd_historico_desc = rPed.lDup[i].Cd_historico_Desconto;
                                regLiquidacao.ComplHistorico = rPed.lDup[i].Parcelas[x].complHistorico;
                                regLiquidacao.Tp_mov = rPed.lDup[i].Tp_mov;
                                regLiquidacao.Cd_portador = cd_portador;
                                regLiquidacao.cVl_Atual = lDup[i].Parcelas[x].Vl_liquidado;
                                regLiquidacao.cVl_descontoconcedido = lDup[i].Parcelas[x].Vl_liquidado;
                                regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                                regLiquidacao.cVl_juroliquidar = decimal.Zero;
                                regLiquidacao.cVl_JuroTotal = decimal.Zero;
                                regLiquidacao.cVl_Liquidado = decimal.Zero;
                                regLiquidacao.cVl_Nominal = lDup[i].Parcelas[x].Vl_parcela_padrao;
                                regLiquidacao.Cvl_aliquidar_padrao = lDup[i].Parcelas[x].Vl_liquidado;
                                regLiquidacao.cVl_adiantamento = decimal.Zero;
                                regLiquidacao.lCred = null;
                                regLiquidacao.Vl_trocoCH = decimal.Zero;
                                regLiquidacao.Vl_trocoDH = decimal.Zero;
                                regLiquidacao.lChTroco = null;
                                regLiquidacao.Vl_adto = decimal.Zero;
                                regLiquidacao.St_AdtoTrocoCH = false;
                                //Gravar liquidacao                    
                                TCN_LanLiquidacao.GravarLiquidacao(new List<TRegistro_LanParcela> { rPed.lDup[i].Parcelas[x] },
                                                                       regLiquidacao,
                                                                       null,
                                                                       null,
                                                                       null,
                                                                       null,
                                                                       qtb_orc.Banco_Dados);
                                rTroca.Troca_X_Mov.Add(new TRegistro_Troca_X_Mov { Cd_empresa = regLiquidacao.Cd_empresa, Nr_lancto = regLiquidacao.Nr_lancto, Cd_parcela = regLiquidacao.Cd_parcela, Id_liquid = regLiquidacao.Id_liquid });
                            }
                        }
                    }
                }
                //Gravar Troca
                rTroca.Nr_orcamento = val.Nr_orcamento;
                rTroca.Nr_pedidotroca = rPed.Nr_pedido;
                rTroca.Login = Login;
                rTroca.MotivoTroca = MotivoTroca;
                TCN_TrocaCliente.Gravar(rTroca, qtb_orc.Banco_Dados);
                //Trocar cliente da proposta
                CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                    Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(Cd_clifor, qtb_orc.Banco_Dados);
                val.Cd_clifor = rClifor.Cd_clifor;
                val.Nm_clifor = rClifor.Nm_clifor;
                //Buscar Endereco
                CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnd =
                    Financeiro.Cadastros.TCN_CadEndereco.Buscar(Cd_clifor,
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
                                                                1,
                                                                qtb_orc.Banco_Dados).FirstOrDefault();
                if(rEnd != null)
                {
                    val.Fone_clifor = rEnd.Fone;
                    val.Ds_endereco = rEnd.Ds_endereco;
                    val.Ds_cidade = rEnd.DS_Cidade;
                    val.Uf = rEnd.UF;
                    val.Logradouroent = rEnd.Ds_endereco;
                    val.Numeroent = rEnd.Numero;
                    val.Complementoent = rEnd.Ds_complemento;
                    val.Bairroent = rEnd.Bairro;
                }
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar cliente proposta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
        
        public static void CancelarOrcamento(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                //Verificar se um item do orcamento ja foi faturado
                object obj = new TCD_LanPedido_Item(qtb_orc.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_orcamento",
                                        vOperador = "=",
                                        vVL_Busca = val.Nr_orcamentostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                }, "1");
                if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                    throw new Exception("Não é permitido cancelar orçamento que possui item faturado.");
                val.St_registro = "CA";
                Gravar(val, qtb_orc.Banco_Dados);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static void RatearFrete(TRegistro_Orcamento val)
        {
            if (val != null && val.lItens.Count > 0)
            {
                decimal tot_subtotal = val.lItens.Sum(p => p.Vl_subtotal);
                val.lItens.ForEach(p =>
                {
                    if ((p.Vl_subtotal > decimal.Zero))
                        p.Vl_frete = Math.Round((Math.Round((Math.Round(p.Vl_subtotal, 2, MidpointRounding.AwayFromZero) * Math.Round(val.Vl_frete, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) / Math.Round(tot_subtotal, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero);
                });
                val.lItens[val.lItens.Count - 1].Vl_frete += val.Vl_frete - val.lItens.Sum(p => p.Vl_frete);
            }
        }

        public static void RatearDesconto(TRegistro_Orcamento val, bool St_perc)
        {
            if (val != null && val.lItens.Count > 0)
            {
                if (!St_perc)
                    val.Pc_desconto = Math.Round(val.Vl_desconto * 100 / val.lItens.Sum(p => p.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                val.lItens.ForEach(p =>
                {
                    p.Vl_desconto = Math.Round(p.Vl_subtotal * (val.Pc_desconto / 100), 2, MidpointRounding.AwayFromZero);
                    p.Pc_desconto = val.Pc_desconto;
                });
                if ((!St_perc) && (val.Vl_desconto > val.lItens.Sum(p => p.Vl_desconto)))
                    val.lItens[val.lItens.Count - 1].Vl_desconto += val.Vl_desconto - val.lItens.Sum(p => p.Vl_desconto);
            }
        }

        public static void RatearAcrescimo(TRegistro_Orcamento val)
        {
            if (val == null ? false : val.lItens.Sum(p => p.Vl_subtotalliq) > 0)
            {
                decimal perc = Math.Round(val.Vl_acrescimo * 100 / val.lItens.Sum(p => p.Vl_subtotal), 5, MidpointRounding.AwayFromZero);
                val.lItens.ForEach(p => p.Vl_acrescimo = Math.Round(p.Vl_subtotal * (perc / 100), 2, MidpointRounding.AwayFromZero));
                if (val.Vl_acrescimo > val.lItens.Sum(p => p.Vl_acrescimo))
                    val.lItens[val.lItens.Count - 1].Vl_acrescimo += val.Vl_acrescimo - val.lItens.Sum(p => p.Vl_acrescimo);
            }
        }

        public static void Calcula_Parcelas(TRegistro_Orcamento val)
        {
            if (val.lItens.Count > 0)
            {
                if (val.Vl_totalorcamento > 0)
                {
                    if (!string.IsNullOrEmpty(val.Cd_condpgto.Trim()))
                    {
                        TRegistro_LanDuplicata Lan_Duplicata = new TRegistro_LanDuplicata();
                        Lan_Duplicata.Qt_parcelas = val.QTD_Parcelas;
                        Lan_Duplicata.Vl_documento = val.Vl_totalorcamento;
                        Lan_Duplicata.Vl_documento_padrao = val.Vl_totalorcamento;
                        Lan_Duplicata.Dt_emissao = val.Dt_orcamento;
                        Lan_Duplicata.Vl_entrada = val.Vl_entrada;
                        Lan_Duplicata.Vl_entrada_padrao = val.Vl_entrada;
                        Lan_Duplicata.St_comentrada = val.Parcelas_Entrada;
                        Lan_Duplicata.Qt_dias_desdobro = val.Parcelas_Dias_Desdobro;
                        Lan_Duplicata.Cd_condpgto = val.Cd_condpgto;
                        Lan_Duplicata.St_venctoferiado = "S";

                        TList_RegLanParcela Lista_Parcela = TCN_LanDuplicata.calcularParcelas(Lan_Duplicata, null);
                        val.lParcelas.Clear();
                        Lista_Parcela.ForEach(p =>
                        {
                            val.lParcelas.Add(
                                new CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_DT_Vencto()
                                {
                                    DiasVencto = p.Dt_vencto.Value.Subtract(val.Dt_orcamento.Value).Days,
                                    Vl_parcela = p.Vl_parcela
                                });
                        });
                    }
                }
            }
        }

        public static void Recalcula_Parcelas(TRegistro_Orcamento val, int Position)
        {
            //Armazena Datas das Parcelas
            TList_Orcamento_DT_Vencto Lista_Data_Parcelas = new TList_Orcamento_DT_Vencto();
            for (int x = 0; x < val.lParcelas.Count; x++)
            {
                TRegistro_Orcamento_DT_Vencto Reg_Data_Parcelas = new TRegistro_Orcamento_DT_Vencto();
                Reg_Data_Parcelas.DiasVencto = val.lParcelas[x].DiasVencto;
                Lista_Data_Parcelas.Add(Reg_Data_Parcelas);
            }

            //Carrego o Duplicata para poder usar a Camada de Negocio da Duplicata
            TRegistro_LanDuplicata Lan_Duplicata = new TRegistro_LanDuplicata();
            Lan_Duplicata.Qt_parcelas = val.QTD_Parcelas;
            Lan_Duplicata.Vl_documento = val.Vl_totalorcamento;
            Lan_Duplicata.Vl_documento_padrao = val.Vl_totalorcamento;
            Lan_Duplicata.Vl_entrada = val.lParcelas[0].Vl_entrada;

            //Populo as Parcelas da Duplicata
            TList_RegLanParcela Lista_Parcela = new TList_RegLanParcela();
            for (int x = 0; x < val.lParcelas.Count; x++)
            {
                TRegistro_LanParcela reg_Parcela = new TRegistro_LanParcela();
                reg_Parcela.Vl_parcela = val.lParcelas[x].Vl_parcela;
                Lista_Parcela.Add(reg_Parcela);
            }

            //Retorno o List das Parcelas Calculadas 
            Lan_Duplicata.Parcelas = Lista_Parcela;
            TList_RegLanParcela Lista_Parcela_Retorno = new TList_RegLanParcela();
            Lista_Parcela_Retorno = TCN_LanDuplicata.Recalcula_Parcelas_List(Lan_Duplicata, Position);

            //Preencho as Parcelas do Pedido
            val.lParcelas.Clear();
            for (int x = 0; x < Lista_Parcela_Retorno.Count; x++)
            {
                val.lParcelas.Add(new TRegistro_Orcamento_DT_Vencto()
                {
                    Vl_parcela = Lista_Parcela_Retorno[x].Vl_parcela,
                    DiasVencto = Lista_Data_Parcelas[x].DiasVencto
                });
            }
        }

        public static void CalcularDtValidade(TRegistro_Orcamento val)
        {
            if ((!string.IsNullOrEmpty(val.Cd_empresa)) && (val.Dt_orcamento != null))
            {
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    }
                                }, "a.qt_diasvalidade");
                if (obj != null)
                    if (decimal.Parse(obj.ToString()) > decimal.Zero)
                        val.Dt_validade = val.Dt_orcamento.Value.AddDays(Convert.ToDouble(obj.ToString()));
            }
        }

        public static void RecalcDiaVencto(TList_Orcamento_DT_Vencto val, decimal Qtd_desdobro, int index)
        {
            for (int i = (index + 1); i < val.Count; i++)
                val[i].DiasVencto = val[i - 1].DiasVencto + Qtd_desdobro;
        }

        public static void ProcessarOrcamento(TRegistro_Orcamento val,
                                              CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCfg,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                //Verificar se o orcamento ainda e valido
                if (val.Dt_validade.HasValue && val.St_registro.ToUpper().Equals("AB"))
                    if (val.Dt_validade.Value.Date < CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados).Date)
                        throw new Exception("Orçamento não é mais valido.\r\nData validade: " + val.Dt_validade.Value.ToString("dd/MM/yyyy"));
                //Buscar moeda padrao empresa
                CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda = ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(val.Cd_empresa, qtb_orc.Banco_Dados);
                if (lMoeda == null)
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + val.Cd_empresa.Trim());
                #region Pedido
                TRegistro_Pedido rPed = new TRegistro_Pedido();
                rPed.CD_Empresa = val.Cd_empresa;
                rPed.Nr_Orcamento = Convert.ToDecimal(val.Nr_orcamentostr);
                rPed.DT_Pedido = val.Nr_pedidovenda == null ? CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados) : val.rPedido.DT_Pedido;
                if (val.PrazoEntrega > decimal.Zero && val.Nr_pedidovenda == null)
                    rPed.Dt_entregapedido = rPed.DT_Pedido.Value.AddDays(Convert.ToDouble(val.PrazoEntrega));
                rPed.CFG_Pedido = string.IsNullOrEmpty(val.Cfg_pedido) ? rCfg.Cfg_pedido : val.Cfg_pedido;
                rPed.TP_Movimento = "S";
                if (val.Nr_pedidovenda == null)
                {
                    //Verificar se pedido exige etapa
                    if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(qtb_orc.Banco_Dados).BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CFG_Pedido",
                                vOperador = "=",
                                vVL_Busca = "'" + rPed.CFG_Pedido.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.ST_ExigeEtapa, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                            }, "1") == null)
                    {
                        rPed.ST_Pedido = "F";
                        rPed.St_registro = "F";
                    }
                    else
                    {
                        rPed.ST_Pedido = "A";
                        rPed.St_registro = "A";
                        //Preencher etapas
                        CamadaDados.Faturamento.Cadastros.TList_CadEtapa lEtapa =
                            Cadastros.TCN_CadEtapa.Busca(string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        qtb_orc.Banco_Dados);

                        if (lEtapa.Count > 0)
                            lEtapa.ForEach(p =>
                                {
                                    TRegistro_EtapaPedido rEtapa =
                                    new TRegistro_EtapaPedido();
                                    rEtapa.Id_etapa = p.Id_etapa;
                                    rEtapa.DS_Etapa = p.DS_Etapa;
                                    rEtapa.Dt_ini = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                                    rEtapa.St_registro = "A";
                                    rPed.lEtapa.Add(rEtapa);
                                });
                        //Preencher Processos da Etapa
                        if (rPed.lEtapa.Count > 0)
                            rPed.lEtapa.ForEach(p =>
                                {
                                    //Buscar Processos da Etapa
                                    CamadaDados.Faturamento.Cadastros.TList_ProcessoEtapa lProc =
                                            Cadastros.TCN_CadProcessoEtapa.Busca(p.Id_etapastr,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 qtb_orc.Banco_Dados);
                                    lProc.ForEach(x =>
                                        {
                                            TRegistro_ProcEtapa rProcEtapa = new TRegistro_ProcEtapa();
                                            rProcEtapa.Id_etapa = x.Id_etapa;
                                            rProcEtapa.Id_processo = x.ID_Processo;
                                            p.lProcEtapa.Add(rProcEtapa);
                                        });
                                });
                    }
                }
                else
                {
                    rPed.ST_Pedido = val.rPedido.ST_Pedido;
                    rPed.St_registro = val.rPedido.St_registro;
                }
                rPed.CD_Clifor = val.Cd_clifor;
                rPed.CD_Endereco = val.Cd_endereco;
                rPed.Cd_moeda = lMoeda[0].Cd_moeda;
                rPed.Cd_vendedor = val.Cd_vendedor;
                rPed.Cd_representante = val.Cd_representante;
                rPed.Pc_comrep = val.Pc_comrep;
                rPed.Cd_gerente = val.Cd_gerente;
                rPed.Cd_cliforind = val.Cd_cliforind;
                rPed.CD_CondPGTO = val.Cd_condpgto;
                rPed.Cd_tabelapreco = val.Cd_tabelapreco;
                rPed.DS_Observacao = val.Ds_observacoes;
                rPed.Vl_frete = val.Vl_frete;
                rPed.Logindesconto = val.LoginDesconto;
                rPed.Tp_frete = val.Tp_frete;
                rPed.TP_descarga = val.TP_descarga;
                rPed.Cd_cliforent = val.Cd_cliforent;
                rPed.Cd_enderecoent = val.Cd_enderecoent;
                rPed.Logradouroent = val.Logradouroent;
                rPed.Cd_cidadeent = val.Cd_cidadeent;
                rPed.Bairroent = val.Bairroent;
                rPed.Numeroent = val.Numeroent;
                rPed.Complementoent = val.Complementoent;
                TList_RegLanPedido_Item lItensPedido = new TList_RegLanPedido_Item();
                //Criar itens do pedido
                val.lItens.ForEach(p =>
                    {
                        if ((!p.St_servicobool) || (p.St_servicobool && ((!rCfg.St_gerarosbool) || rCfg.Tp_os.Trim().Equals("I"))))
                        {
                            //Buscar ficha tecnica do item orcamento
                            p.lFichaTec = TCN_FichaTecOrcItem.Buscar(p.Nr_orcamento.Value.ToString(), p.Id_item.Value.ToString(), string.Empty, qtb_orc.Banco_Dados);
                            //Montar ficha tecnica do item do pedido
                            TList_FichaTecItemPed lFicha = new TList_FichaTecItemPed();
                            p.lFichaTec.ForEach(v => lFicha.Add(new TRegistro_FichaTecItemPed()
                            {
                                Cd_item = v.Cd_item,
                                Ds_item = v.Ds_item,
                                Quantidade = v.Quantidade,
                                Cd_unditem = v.Cd_unditem,
                                Cd_local = v.Cd_local
                            }));
                            //Calcular custo produto composto
                            decimal vl_estoque = decimal.Zero;
                            TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, p.Cd_produto, ref vl_estoque, qtb_orc.Banco_Dados);
                            lItensPedido.Add(new TRegistro_LanPedido_Item()
                            {
                                Cd_Empresa = val.Cd_empresa,
                                Cd_local = p.Cd_local,
                                Cd_produto = p.Cd_produto,
                                Cd_unidade_est = p.Cd_unid_produto,
                                Cd_unidade_valor = p.Cd_unid_produto,
                                Quantidade = p.Quantidade,
                                Vl_unitario = rCfg.St_aplicdescvlunitbool ? Math.Round(decimal.Divide(p.Vl_subtotal - p.Vl_desconto, p.Quantidade), 5, MidpointRounding.AwayFromZero) : p.Vl_unitario,
                                Vl_subtotal = decimal.Multiply(p.Quantidade, rCfg.St_aplicdescvlunitbool ? Math.Round(decimal.Divide(p.Vl_subtotal - p.Vl_desconto, p.Quantidade), 5, MidpointRounding.AwayFromZero) : p.Vl_unitario),
                                Pc_desc = rCfg.St_aplicdescvlunitbool ? decimal.Zero : p.Pc_desconto,
                                Vl_desc = rCfg.St_aplicdescvlunitbool ? decimal.Zero : p.Vl_desconto,
                                Vl_freteitem = p.Vl_frete,
                                Vl_acrescimo = p.Vl_acrescimo,
                                altura = p.vl_altura,
                                largura = p.vl_largura,
                                comprimento_und = p.vl_comprimento,
                                Pc_comrep = p.Pc_comrep,
                                Vl_juro_fin = p.Vl_juro_fin,
                                Ds_Fichatec = p.Ds_Fichatec,
                                St_projespecialbool = p.St_projespecialbool,
                                Ds_observacaoitem = p.Ds_observacao,
                                Nr_orcamento = p.Nr_orcamento,
                                Id_itemorc = p.Id_item,
                                Vl_custoitem = vl_estoque,
                                lFichaTec = lFicha
                            });
                        }
                    });
                //Criar financeiro do pedido
                val.lParcelas.ForEach(p => rPed.Pedidos_DT_Vencto.Add(new TRegistro_Pedido_DT_Vencto()
                {
                    Dt_vencto = rPed.DT_Pedido.Value.AddDays(Convert.ToDouble(p.DiasVencto)),
                    VL_Parcela = p.Vl_parcela
                }));
                //Gravar pedido Ordem de Producao
                if (!string.IsNullOrEmpty(rCfg.Cfg_PedOrdemProd))
                {
                    TRegistro_Pedido rPedOrdemProd = new TRegistro_Pedido();
                    rPedOrdemProd = rPed;
                    rPedOrdemProd.CFG_Pedido = rCfg.Cfg_PedOrdemProd;
                    rPedOrdemProd.Nr_pedido = decimal.Zero;
                    rPedOrdemProd.Pedido_Itens = new TList_RegLanPedido_Item();
                    lItensPedido.ForEach(x =>
                        {
                            if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoIndustrializado(x.Cd_produto))
                                rPedOrdemProd.Pedido_Itens.Add(x);
                        });
                    if (rPedOrdemProd.Pedido_Itens.Count > decimal.Zero)
                        Pedido.TCN_Pedido.Grava_Pedido(rPedOrdemProd, qtb_orc.Banco_Dados);
                }
                //Gravar pedido Serviço
                if (!string.IsNullOrEmpty(rCfg.Cfg_pedservico) && !rCfg.St_gerarosbool)
                {
                    TRegistro_Pedido rPedServico = new TRegistro_Pedido();
                    rPedServico = rPed;
                    rPedServico.CFG_Pedido = rCfg.Cfg_pedservico;
                    rPedServico.Nr_pedido = decimal.Zero;
                    rPedServico.Pedido_Itens = new TList_RegLanPedido_Item();
                    lItensPedido.ForEach(x =>
                    {
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ItemServico(x.Cd_produto))
                            rPedServico.Pedido_Itens.Add(x);
                    });
                    if (rPedServico.Pedido_Itens.Count > decimal.Zero)
                        Pedido.TCN_Pedido.Grava_Pedido(rPedServico, qtb_orc.Banco_Dados);
                }
                //Gravar pedido
                TRegistro_Pedido rPedido = new TRegistro_Pedido();
                rPedido = rPed;
                rPedido.CFG_Pedido = rCfg.Cfg_pedido;
                rPedido.Nr_pedido = val.Nr_pedidovenda == null ? decimal.Zero : Convert.ToDecimal(val.Nr_pedidovenda);
                rPedido.Pedido_Itens = new TList_RegLanPedido_Item();
                lItensPedido.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(rCfg.Cfg_pedservico) &&
                        !string.IsNullOrEmpty(rCfg.Cfg_PedOrdemProd) && !rCfg.St_gerarosbool)
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ItemServico(x.Cd_produto) &&
                            !new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoIndustrializado(x.Cd_produto))
                            rPedido.Pedido_Itens.Add(x);
                    }
                    else if (!string.IsNullOrEmpty(rCfg.Cfg_pedservico) && !rCfg.St_gerarosbool)
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ItemServico(x.Cd_produto))
                            rPedido.Pedido_Itens.Add(x);
                    }
                    else if (!string.IsNullOrEmpty(rCfg.Cfg_PedOrdemProd))
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoIndustrializado(x.Cd_produto))
                            rPedido.Pedido_Itens.Add(x);
                    }
                    else
                        rPedido.Pedido_Itens.Add(x);
                });
                if (rPedido.Pedido_Itens.Count > decimal.Zero)
                    Pedido.TCN_Pedido.Grava_Pedido(rPedido, qtb_orc.Banco_Dados);
                #endregion

                #region OS
                if (rCfg.St_gerarosbool && val.lItens.Exists(p => p.St_servicobool))
                {
                    CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                    rOs.Cd_empresa = val.Cd_empresa;
                    rOs.Tp_ordem = rCfg.Tp_ordem;
                    if (string.IsNullOrEmpty(rOs.Tp_ordemstr))
                        throw new Exception("Não existe tipo de ordem configurada na CFG.Orçamento!" + rCfg.Tp_ordemstr);
                    rOs.Cd_clifor = val.Cd_clifor;
                    rOs.Nm_clifor = val.Nm_clifor;
                    rOs.Cd_endereco = val.Cd_endereco;
                    rOs.Ds_endereco = val.Ds_endereco;
                    rOs.Cd_tabelapreco = val.Cd_tabelapreco;
                    rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                    rOs.St_prioridade = "1";
                    rOs.Ds_observacoesgerais = "SERVIÇO INTERNO DO ORÇAMENTO " + val.Nr_orcamentostr;
                    rOs.St_os = "AB";

                    //Etapa de abertura
                    CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem(qtb_orc.Banco_Dados).Select(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                            }, 1, string.Empty);
                    if (lEtapa.Count > 0)
                        rOs.lEvolucao.Add(
                            new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                            {
                                Dt_inicio = rOs.Dt_abertura,
                                Id_etapa = lEtapa[0].Id_etapa,
                                Ds_evolucao = "ETAPA ABERTURA DA OS",
                                St_envterceiro = lEtapa[0].St_envterceirobool,
                                St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                St_iniciarOS = lEtapa[0].St_iniciarOSbool
                            });
                    else
                        throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                    //Servicos da OS
                    val.lItens.FindAll(p => p.St_servicobool).ForEach(p =>
                        {
                            rOs.lPecas.Add(new CamadaDados.Servicos.TRegistro_LanServicosPecas()
                            {
                                Cd_produto = p.Cd_produto,
                                Quantidade = p.Quantidade,
                                Vl_unitario = p.Vl_unitario,
                                Vl_subtotal = p.Vl_subtotal,
                                Vl_desconto = p.Vl_desconto,
                                Vl_SubTotalLiq = p.Vl_subtotalliq,
                                Ds_observacao = p.Ds_observacao,
                                Nr_orcamento = p.Nr_orcamento,
                                Id_itemOrc = p.Id_item
                            });
                        });
                    //Gravar OS
                    Servicos.TCN_LanServico.Gravar(rOs, qtb_orc.Banco_Dados);
                    //Amarrar Item Orcamento com Item OS
                    rOs.lPecas.ForEach(p =>
                        TCN_Orcamento_X_OS.Gravar(
                        new TRegistro_Orcamento_X_OS()
                        {
                            Nr_orcamento = p.Nr_orcamento,
                            Id_item = p.Id_itemOrc,
                            Id_os = p.Id_os,
                            Cd_empresa = p.Cd_empresa,
                            Id_peca = p.Id_peca
                        }, qtb_orc.Banco_Dados));
                }
                #endregion

                #region Projeto
                if (rCfg.St_gerarprojetobool && val.lItens.Exists(p => !new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoIndustrializado(p.Cd_produto)))
                {
                    CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                    rOs.Cd_empresa = val.Cd_empresa;
                    rOs.Nr_osorigem = val.Nr_orcamentostr;
                    rOs.Tp_ordem = rCfg.Tp_ordem;
                    rOs.Cd_clifor = val.Cd_clifor;
                    rOs.Nm_clifor = val.Nm_clifor;
                    rOs.Cd_endereco = val.Cd_endereco;
                    rOs.Ds_endereco = val.Ds_endereco;
                    rOs.Cd_tabelapreco = val.Cd_tabelapreco;
                    rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                    rOs.St_os = "AB";

                    if (string.IsNullOrEmpty(rCfg.Tp_ordemstr))
                        throw new Exception("Não existe TP.Ordem configurada na CFG.Orçamento!");
                    //Buscar etapa de abertura da OS
                    CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                    new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem(qtb_orc.Banco_Dados).Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                            }, 0, string.Empty);
                    if (lEtapa.Count > 0)
                    {
                        lEtapa.ForEach(p =>
                        {
                            //Buscar Ordem Etapa do Tipo de Ordem
                            object obj = new CamadaDados.Servicos.Cadastros.TCD_TpOrdem_X_Etapa(qtb_orc.Banco_Dados).BuscarEscalar(
                                            new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_etapa",
                                                                vOperador = "=",
                                                                vVL_Busca = p.Id_etapastr
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.TP_Ordem",
                                                                vOperador = "=",
                                                                vVL_Busca = rOs.Tp_ordemstr                                    }
                                                        }, "a.Ordem");
                            if (!string.IsNullOrEmpty(obj.ToString()))
                                p.Ordem = Convert.ToDecimal(obj);
                            else
                                p.Ordem = rOs.lEvolucao.Count + 1;

                            rOs.lEvolucao.Add(
                                new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                {
                                    Dt_inicio = rOs.Dt_abertura,
                                    Id_etapa = p.Id_etapa,
                                    Ds_evolucao = p.Ds_etapa,
                                    Ordem = p.Ordem.Equals(decimal.Zero) ? decimal.Parse(p.Id_etapastr) : p.Ordem,
                                    St_envterceiro = p.St_envterceirobool,
                                    St_finalizarOS = p.St_finalizarOSbool,
                                    St_iniciarOS = p.St_iniciarOSbool
                                });
                        });
                    }

                    //Servicos da OS
                    val.lItens.ForEach(p =>
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoIndustrializado(p.Cd_produto))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ProdutoComposto(p.Cd_produto))
                                rOs.lPecas.Add(new CamadaDados.Servicos.TRegistro_LanServicosPecas()
                                {
                                    Cd_produto = p.Cd_produto,
                                    Cd_local = p.Cd_local,
                                    Cd_unidproduto = p.Cd_unid_produto,
                                    Quantidade = p.Quantidade,
                                    Vl_unitario = p.Vl_unitario,
                                    Vl_custo = p.Vl_custo,
                                    Vl_subtotal = p.Vl_subtotal,
                                    Vl_desconto = p.Vl_desconto,
                                    Vl_acrescimo = p.Vl_acrescimo,
                                    Vl_SubTotalLiq = p.Vl_subtotalliq,
                                    Ds_observacao = p.Ds_observacao,
                                    Nr_orcamento = p.Nr_orcamento,
                                    Id_itemOrc = p.Id_item,
                                    St_servicobool = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ItemServico(p.Cd_produto),
                                });

                            //Adicionar Ficha Técnica
                            if (p.lFichaTec.Count > 0)
                                p.lFichaTec.ForEach(x =>
                                        rOs.lPecas.Add(new CamadaDados.Servicos.TRegistro_LanServicosPecas()
                                        {
                                            Cd_produto = x.Cd_item,
                                            Cd_local = p.Cd_local,
                                            Cd_unidproduto = p.Cd_unid_produto,
                                            Quantidade = x.Quantidade,
                                            Vl_unitario = TCN_LanPrecoItem.Busca_ConsultaPreco(val.Cd_empresa, x.Cd_item, val.Cd_tabelapreco, qtb_orc.Banco_Dados),
                                            Vl_custo = x.Vl_custo,
                                            Vl_subtotal = x.Vl_Subtotal,
                                            Vl_desconto = decimal.Zero,
                                            Nr_orcamento = p.Nr_orcamento,
                                            Id_itemOrc = p.Id_item,
                                            St_servicobool = new CamadaDados.Estoque.Cadastros.TCD_CadProduto(qtb_orc.Banco_Dados).ItemServico(p.Cd_produto)
                                        }));
                        }
                    });
                    //Gravar OS
                    Servicos.TCN_LanServico.Gravar(rOs, qtb_orc.Banco_Dados);
                    //Amarrar Item Orcamento com Item OS
                    rOs.lPecas.ForEach(p =>
                        TCN_Orcamento_X_OS.Gravar(
                        new TRegistro_Orcamento_X_OS()
                        {
                            Nr_orcamento = p.Nr_orcamento,
                            Id_item = p.Id_itemOrc,
                            Id_os = p.Id_os,
                            Cd_empresa = p.Cd_empresa,
                            Id_peca = p.Id_peca
                        }, qtb_orc.Banco_Dados));
                }
                #endregion
                //Alterar status do objeto orcamento
                val.St_registro = "FT";
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static List<TRegistro_Pedido> ProcessarOrcamentoProjeto(TRegistro_Orcamento val,
                                                                       CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCfg,
                                                                       BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            List<TRegistro_Pedido> retorno = new List<TRegistro_Pedido>();
            TCD_Orcamento qtb_orc = new TCD_Orcamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Buscar moeda padrao empresa
                CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda = ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(val.Cd_empresa, banco);
                if (lMoeda == null)
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + val.Cd_empresa.Trim());
                TRegistro_Pedido rPedProduto = null;
                TRegistro_Pedido rPedServico = null;
                #region Pedido Produtos
                if (val.lItens.Exists(p => (!p.St_servicobool) && p.lItensFat.Count > 0))
                {
                    if (string.IsNullOrEmpty(rCfg.Cfg_pedido))
                        throw new Exception("Não existe configuração de pedido produto para faturar orçamento.");
                    if (string.IsNullOrEmpty(rCfg.Cd_local))
                        throw new Exception("Não existe local armazenagem configurado para faturar orçamento.");
                    rPedProduto = new TRegistro_Pedido();
                    rPedProduto.CD_Empresa = val.Cd_empresa;
                    rPedProduto.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                    if (val.PrazoEntrega > decimal.Zero)
                        rPedProduto.Dt_entregapedido = rPedProduto.DT_Pedido.Value.AddDays(Convert.ToDouble(val.PrazoEntrega));
                    rPedProduto.CFG_Pedido = rCfg.Cfg_pedido;
                    rPedProduto.TP_Movimento = "S";
                    rPedProduto.ST_Pedido = "F";
                    rPedProduto.St_registro = "F";
                    rPedProduto.CD_Clifor = val.Cd_clifor;
                    rPedProduto.CD_Endereco = val.Cd_endereco;
                    rPedProduto.Cd_moeda = lMoeda[0].Cd_moeda;
                    rPedProduto.Cd_vendedor = val.Cd_vendedor;
                    rPedProduto.Cd_representante = val.Cd_representante;
                    rPedProduto.CD_CondPGTO = val.Cd_condpgto;
                    rPedProduto.Cd_tabelapreco = val.Cd_tabelapreco;
                    rPedProduto.DS_Observacao = val.Ds_observacoes;
                    rPedProduto.Vl_frete = val.Vl_frete;
                    rPedProduto.Logindesconto = val.LoginDesconto;
                    rPedProduto.Tp_frete = val.Tp_frete;
                    rPedProduto.TP_descarga = val.TP_descarga;
                    //Criar itens do pedido
                    val.lItens.FindAll(p => (!p.St_servicobool) && p.lItensFat.Count > 0).ForEach(p =>
                     {
                         p.lItensFat.ForEach(v =>
                             {
                                 v.Cd_local = rCfg.Cd_local;
                                 v.Nr_orcamento = p.Nr_orcamento;
                                 v.Id_itemorc = p.Id_item;
                                 rPedProduto.Pedido_Itens.Add(v);
                             });
                     });
                    //Gravar pedido
                    Pedido.TCN_Pedido.Grava_Pedido(rPedProduto, qtb_orc.Banco_Dados);
                    retorno.Add(rPedProduto);
                }
                #endregion

                #region Pedido Servico
                if (val.lItens.Exists(p => p.St_servicobool && p.lItensFat.Count > 0))
                {
                    if (string.IsNullOrEmpty(rCfg.Cfg_pedservico))
                        throw new Exception("Não existe configuração de pedido serviço para faturar orçamento.");
                    rPedServico = new TRegistro_Pedido();
                    rPedServico.CD_Empresa = val.Cd_empresa;
                    //Buscar cidade empresa
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(qtb_orc.Banco_Dados).BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                            "where x.cd_clifor = a.cd_clifor " +
                                                            "and x.cd_endereco = a.cd_endereco " +
                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                            }
                                        }, "a.cd_cidade");
                    if (obj != null)
                        rPedServico.Cd_municipioexecservico = obj.ToString();
                    rPedServico.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                    if (val.PrazoEntrega > decimal.Zero)
                        rPedServico.Dt_entregapedido = rPedServico.DT_Pedido.Value.AddDays(Convert.ToDouble(val.PrazoEntrega));
                    rPedServico.CFG_Pedido = rCfg.Cfg_pedservico;
                    rPedServico.TP_Movimento = "S";
                    rPedServico.ST_Pedido = "F";
                    rPedServico.St_registro = "F";
                    rPedServico.CD_Clifor = val.Cd_clifor;
                    rPedServico.CD_Endereco = val.Cd_endereco;
                    rPedServico.Cd_moeda = lMoeda[0].Cd_moeda;
                    rPedServico.Cd_vendedor = val.Cd_vendedor;
                    rPedServico.Cd_representante = val.Cd_representante;
                    rPedServico.CD_CondPGTO = val.Cd_condpgto;
                    rPedServico.Cd_tabelapreco = val.Cd_tabelapreco;
                    rPedServico.DS_Observacao = val.Ds_observacoes;
                    rPedServico.Vl_frete = val.Vl_frete;
                    rPedServico.Logindesconto = val.LoginDesconto;
                    rPedServico.Tp_frete = val.Tp_frete;
                    rPedServico.TP_descarga = val.TP_descarga;
                    //Criar itens do pedido
                    val.lItens.FindAll(p => p.St_servicobool && p.lItensFat.Count > 0).ForEach(p =>
                        p.lItensFat.ForEach(v =>
                            {
                                v.Nr_orcamento = p.Nr_orcamento;
                                v.Id_itemorc = p.Id_item;
                                rPedServico.Pedido_Itens.Add(v);
                            }));
                    //Gravar pedido
                    Pedido.TCN_Pedido.Grava_Pedido(rPedServico, qtb_orc.Banco_Dados);
                    retorno.Add(rPedServico);
                }
                #endregion

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static void ImprimirOrcamento(TRegistro_Orcamento val,
                                             CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor,
                                             CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEnderecoClifor,
                                             CamadaDados.Diversos.TRegistro_CadEmpresa rEmpresa)
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

            FileInfo f = null;
            StreamWriter w = null;
            f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Orcamento.txt");
            w = f.CreateText();

            int numParcela = 1;

            try
            {
                w.WriteLine("******************************ORCAMENTO VENDA******************************");
                w.WriteLine("Orcamento Numero: " + val.Nr_orcamento + "                                     Data : " + val.Dt_orcamentostr);
                w.WriteLine("                                                       Valido ate:" + val.Dt_validadestr);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("EMPRESA:  " + rEmpresa.Nm_empresa.Trim().ToUpper().FormatStringDireita(48, ' ') + "- CNPJ: " + rEmpresa.rClifor.Nr_cgc);
                w.WriteLine("ENDERECO: " + rEmpresa.Ds_endereco.Trim().ToUpper() + " - " + rEmpresa.rEndereco.Bairro.Trim() + " - " + rEmpresa.rEndereco.Numero);
                w.WriteLine("CIDADE: " + rEmpresa.rEndereco.DS_Cidade.Trim().ToUpper() + " - " + rEmpresa.rEndereco.UF + " - " + rEmpresa.rEndereco.NM_Pais);
                w.WriteLine();
                w.WriteLine("CLIENTE: " + rClifor.Nm_clifor.Trim().ToUpper() + " - CNPJ/CPF: " + (rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? rClifor.Nr_cgc : rClifor.Nr_cpf));
                w.WriteLine("ENDERECO: " + rEnderecoClifor.Ds_endereco.FormatStringDireita(30, ' ') + "     N: " + rEnderecoClifor.Numero);
                w.WriteLine("BAIRRO: " + rEnderecoClifor.Bairro.Trim().ToUpper() + "    CIDADE : " + rEnderecoClifor.DS_Cidade.Trim() + " - " + rEnderecoClifor.UF.Trim() + "    FONE: " + rEnderecoClifor.Fone);
                w.WriteLine();
                w.WriteLine("PRODUTO                                QTD UND  VALOR UNIT  VAL DESC.  SUBTOTAL");
                w.WriteLine("--------------------------------------------------------------------------------");

                val.lItens.ForEach(p =>
                {
                    w.WriteLine((p.Cd_produto.Trim() + "-" + p.Ds_produto).FormatStringDireita(32, ' '));
                    w.WriteLine(p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine(" ");
                    w.WriteLine(p.Sigla_unid_produto.FormatStringEsquerda(3, ' '));
                    w.WriteLine(p.Vl_unitario.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                    w.WriteLine(p.Vl_desconto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(11, ' '));
                    w.WriteLine(p.Vl_subtotal.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(10, ' '));
                    w.WriteLine();
                });

                w.WriteLine();
                w.WriteLine();
                w.WriteLine(" TOTAL ITENS                TOTAL ORCAMENTO");
                w.WriteLine("--------------------------------------------------------------------------------");
                w.WriteLine(val.Vl_totalitens.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' '));
                w.WriteLine(val.Vl_totalorcamento.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(31, ' '));
                w.WriteLine();
                w.WriteLine();

                w.WriteLine("                             PARCELAS");
                w.WriteLine();
                w.WriteLine("PARCELA         VALOR           DIAS VENCTO");
                w.WriteLine("--------------------------------------------------------------------------------");
                val.lParcelas.ForEach(p =>
                {
                    w.WriteLine(numParcela.FormatStringEsquerda(7, ' '));
                    w.WriteLine(p.Vl_parcela.FormatStringEsquerda(14, ' '));
                    w.WriteLine((p.DiasVencto.ToString() + " DIAS").FormatStringEsquerda(22, ' '));
                    numParcela++;
                    w.WriteLine();
                });
                w.WriteLine("--------------------------------------------------------------------------------");

                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("OBSERVACOES: " + val.Ds_observacoes);
                w.WriteLine();
                w.WriteLine();
                w.WriteLine();
                w.WriteLine("-----------------------------------        -------------------------------------");
                w.WriteLine("CLIENTE                                    VENDEDOR                             ");
                w.WriteLine(val.Nm_clifor.Trim().ToUpper().FormatStringDireita(43, ' '));
                w.WriteLine(val.Nm_vendedor.Trim().ToUpper().FormatStringDireita(47, ' '));
                w.WriteLine();
                w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                w.Write(Convert.ToChar(12));
                w.Write(Convert.ToChar(27));
                w.Write(Convert.ToChar(109));
                w.Flush();
                f.CopyTo(obj.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show("Erro impressão Orçamento: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                w.Dispose();
                f = null;
            }
        }

        public static void MontarFichaTecItem(string Cd_empresa,
                                              string Cd_local,
                                              TRegistro_Orcamento_Item rItem,
                                              TList_Orcamento_Item val)
        {
            object ds_local = new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_local",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_local.Trim() + "'"
                                            }
                                        }, "a.ds_local");
            if (rItem != null)
            {
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(rItem.Cd_produto) ||
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoIndustrializado(rItem.Cd_produto))
                {
                    //Buscar ficha tecnica do item
                    TList_FichaTecOrcItem lFicha = TCN_FichaTecOrcItem.Buscar(rItem.Nr_orcamento.Value.ToString(),
                                                                              rItem.Id_item.Value.ToString(),
                                                                              string.Empty,
                                                                              null);
                    lFicha.ForEach(p =>
                        {
                            if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_item)) &&
                                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_item)))
                                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_item) ||
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoIndustrializado(p.Cd_item))
                                {
                                    val.Add(new TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = p.Cd_item,
                                        Ds_produto = p.Ds_item,
                                        NCM = p.Ncm,
                                        Cest = p.Cest,
                                        Sigla_unid_produto = p.Sg_unditem,
                                        Quantidade = p.Quantidade,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_saldoestoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, p.Cd_item, Cd_local, null)
                                    });
                                    MontarFichaTecItem(Cd_empresa, Cd_local, null, val);
                                }
                                else if (val.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_item.Trim())))
                                    val.Find(v => v.Cd_produto.Trim().Equals(p.Cd_item.Trim())).Quantidade += p.Quantidade;
                                else
                                    val.Add(new TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = p.Cd_item,
                                        Ds_produto = p.Ds_item,
                                        NCM = p.Ncm,
                                        Cest = p.Cest,
                                        Sigla_unid_produto = p.Sg_unditem,
                                        Quantidade = p.Quantidade,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_saldoestoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, p.Cd_item, Cd_local, null),
                                        Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, p.Cd_item, null)
                                    });
                        });
                }
                else
                    return;
            }
            else
                val.ForEach(p =>
                {
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                    {

                        //Buscar Ficha Tecnica do Produto
                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto,
                                                                                       string.Empty,
                                                                                       null);
                        //Remover da lista
                        val.Remove(p);
                        lFicha.ForEach(v =>
                        {
                            if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_item)) &&
                                (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_item)))
                                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                {
                                    val.Add(new TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = v.Cd_item,
                                        Ds_produto = v.Ds_item,
                                        NCM = v.Ncmitem,
                                        Cest = v.Cestitem,
                                        Quantidade = p.Quantidade * v.Quantidade,
                                        Sigla_unid_produto = v.Sg_unditem,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_saldoestoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, v.Cd_item, Cd_local, null)
                                    });
                                    //Chamada Recursiva
                                    MontarFichaTecItem(Cd_empresa, Cd_local, null, val);
                                }
                                else if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                    val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += p.Quantidade * v.Quantidade;
                                else
                                    val.Add(new TRegistro_Orcamento_Item()
                                    {
                                        Cd_produto = v.Cd_item,
                                        Ds_produto = v.Ds_item,
                                        NCM = v.Ncmitem,
                                        Cest = v.Cestitem,
                                        Quantidade = p.Quantidade * v.Quantidade,
                                        Sigla_unid_produto = v.Sg_unditem,
                                        Cd_local = Cd_local,
                                        Ds_local = ds_local != null ? ds_local.ToString() : string.Empty,
                                        Qtd_saldoestoque = CamadaNegocio.Estoque.TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, v.Cd_item, Cd_local, null),
                                        Vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, v.Cd_item, null)
                                    });
                        });
                    }
                });
        }

        public static void MontarListaSeparacaoOrc(string Nr_orcamento,
                                                   string Cd_empresa,
                                                   TList_Orcamento_Item val,
                                                   int i)
        {
            int c = i;
            if (!string.IsNullOrEmpty(Nr_orcamento))
            {
                TList_Orcamento_Item lItens = TCN_Orcamento_Item.Buscar(Nr_orcamento, false, false, null);
                lItens.ForEach(p =>
                {
                    if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(p.Cd_produto)) &&
                        (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(p.Cd_produto)))
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                        {
                            val.Add(p);
                            MontarListaSeparacaoOrc(null, Cd_empresa, val, c);
                        }
                        else if (val.Exists(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())) &&
                            val.Exists(v => v.Ds_produto.Trim().Equals(p.Ds_produto.Trim())))
                            val.Find(v => v.Cd_produto.Trim().Equals(p.Cd_produto.Trim())).Quantidade += p.Quantidade;
                        else
                            val.Add(p);
                });
            }
            else
            {
                for (i = c; val.Count > i; i++)
                {
                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(val[i].Cd_produto))
                    {
                        val[i].Vl_custo = decimal.Zero;
                        if (val[i].lFichaTec.Count > 0)
                            val[i].lFichaTec.ForEach(v =>
                            {
                                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                {
                                    if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                        val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += v.Quantidade;
                                    else
                                        val.Add(new TRegistro_Orcamento_Item()
                                        {
                                            Cd_produto = v.Cd_item,
                                            Ds_produto = v.Ds_item,
                                            NCM = v.Ncm,
                                            Cest = v.Cest,
                                            Quantidade = v.Quantidade,
                                            Sigla_unid_produto = v.Sg_unditem
                                        });
                                    //Chamada Recursiva
                                    MontarListaSeparacaoOrc(null, Cd_empresa, val, val.Count);
                                }
                                else
                                {
                                    if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                        val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += v.Quantidade;
                                    else
                                        val.Add(new TRegistro_Orcamento_Item()
                                        {
                                            Cd_produto = v.Cd_item,
                                            Ds_produto = v.Ds_item,
                                            NCM = v.Ncm,
                                            Cest = v.Cest,
                                            Quantidade = v.Quantidade,
                                            Sigla_unid_produto = v.Sg_unditem,
                                            Vl_custo = Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, v.Cd_item, null)
                                        });
                                }
                            });
                        else
                        {
                            c++;
                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                Estoque.Cadastros.TCN_FichaTecProduto.Buscar(val[i].Cd_produto,
                                                                             string.Empty,
                                                                             null);
                            lFicha.ForEach(v =>
                            {
                                if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(v.Cd_item)) &&
                                    (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(v.Cd_item)))
                                    if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(v.Cd_item))
                                    {
                                        if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                            val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += val[i].Quantidade * v.Quantidade;
                                        else
                                            val.Add(new TRegistro_Orcamento_Item()
                                            {
                                                Cd_produto = v.Cd_item,
                                                Ds_produto = v.Ds_item,
                                                NCM = v.Ncmitem,
                                                Cest = v.Cestitem,
                                                Quantidade = val[i].Quantidade * v.Quantidade,
                                                Sigla_unid_produto = v.Sg_unditem
                                            });
                                        //Chamada Recursiva
                                        MontarListaSeparacaoOrc(null, Cd_empresa, val, val.Count);
                                    }
                                    else if (val.Exists(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())))
                                        val.Find(x => x.Cd_produto.Trim().Equals(v.Cd_item.Trim())).Quantidade += val[i].Quantidade * v.Quantidade;
                                    else
                                        val.Add(new TRegistro_Orcamento_Item()
                                        {
                                            Cd_produto = v.Cd_item,
                                            Ds_produto = v.Ds_item,
                                            NCM = v.Ncmitem,
                                            Cest = v.Cestitem,
                                            Quantidade = val[i].Quantidade * v.Quantidade,
                                            Sigla_unid_produto = v.Sg_unditem,
                                            Vl_custo = Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, v.Cd_item, null)
                                        });
                            });
                        }
                    }
                }
            }
        }
    }

    public class TCN_Orcamento_Item
    {
        public static TList_Orcamento_Item Buscar(string Nr_orcamento,
                                                  bool St_SaldoFaturar,
                                                  bool Cancelado,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_orcamento;
            }
            if (St_SaldoFaturar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.quantidade - a.qtd_faturada";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if (!Cancelado)
                Estruturas.CriarParametro(ref filtro, "isnull(a.cancelado, 0)", "0");
            return new TCD_Orcamento_Item(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_Item qtb_orc = new TCD_Orcamento_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                val.Id_item = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_orc.Gravar(val), "@P_ID_ITEM"));
                //Excluir item Ficha Tecnica
                val.lFichaTecDel.ForEach(p => TCN_FichaTecOrcItem.Excluir(p, qtb_orc.Banco_Dados));
                //Gravar Item Ficha Tecnica
                val.lFichaTec.ForEach(p =>
                    {
                        p.Nr_orcamento = val.Nr_orcamento;
                        p.Id_item = val.Id_item;
                        TCN_FichaTecOrcItem.Gravar(p, qtb_orc.Banco_Dados);
                    });
                //Excluir Anexos
                val.lAnexoDel.ForEach(p => TCN_AnexoItemOrc.Excluir(p, qtb_orc.Banco_Dados));
                //Gravar anexos
                val.lAnexo.ForEach(p =>
                {
                    p.Nr_orcamento = val.Nr_orcamento;
                    p.Id_item = val.Id_item;
                    TCN_AnexoItemOrc.Gravar(p, qtb_orc.Banco_Dados);
                });
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_item.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string GravarLista(TList_Orcamento_Item lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_Item qtb_orc = new TCD_Orcamento_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                lista.ForEach(p => qtb_orc.Gravar(p));
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_Item qtb_orc = new TCD_Orcamento_Item();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                //Excluir Item Ficha Tecnica
                val.lFichaTec.ForEach(p => TCN_FichaTecOrcItem.Excluir(p, qtb_orc.Banco_Dados));
                val.lFichaTecDel.ForEach(p => TCN_FichaTecOrcItem.Excluir(p, qtb_orc.Banco_Dados));
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static void TrocarItem(TRegistro_TrocaItemProposta val,
                                      string Cd_clifor,
                                      string Cd_endereco,
                                      BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaItemProposta qtb_troca = new TCD_TrocaItemProposta();
            try
            {
                //Verificar se o item não esta faturado
                if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.nr_orcamento = " + val.ItemOrig.Nr_orcamento.Value.ToString() + " " +
                                        "and x.id_itemorc = " + val.ItemOrig.Id_item.Value.ToString() + ")"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido trocar item FATURADO.");
                //Verificar se o item não esta em expedição
                if (new TCD_ItensExpedicao().BuscarEscalar(
                    new TpBusca[]
                    {
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                    "where x.nr_pedido = a.nr_pedido " +
                                    "and x.cd_produto = a.cd_produto " +
                                    "and x.id_pedidoitem = a.id_pedidoitem " +
                                    "and x.nr_orcamento = " + val.ItemOrig.Nr_orcamento.Value.ToString() + " " +
                                    "and x.id_itemorc = " + val.ItemOrig.Id_item.Value.ToString() + ")"
                    }
                    }, "1") != null)
                    throw new Exception("Não é permitido trocar item com EXPEDIÇÃO.");
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                //Cancelar item na proposta
                val.ItemOrig.Cancelado = true;
                new TCD_Orcamento_Item(qtb_troca.Banco_Dados).Gravar(val.ItemOrig);
                //Gravar novo item na proposta
                val.ItemDest.Nr_orcamento = val.ItemOrig.Nr_orcamento;
                Gravar(val.ItemDest, qtb_troca.Banco_Dados);
                //Cancelar item no pedido
                TRegistro_LanPedido_Item rItemPed =
                    new TCD_LanPedido_Item(qtb_troca.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca{vNM_Campo = "a.nr_orcamento", vOperador = "=", vVL_Busca = val.ItemOrig.Nr_orcamento.Value.ToString()},
                            new TpBusca{vNM_Campo = "a.id_itemorc", vOperador = "=", vVL_Busca = val.ItemOrig.Id_item.Value.ToString()}
                        }, 1, string.Empty, string.Empty, string.Empty).FirstOrDefault();
                if(rItemPed != null)
                {
                    rItemPed.St_registro = "C";
                    TCN_LanPedido_Item.GravaPedido_Item(rItemPed, qtb_troca.Banco_Dados);
                }
                //Gravar novo item no pedido
                //Buscar ficha tecnica do item orcamento
                val.ItemDest.lFichaTec = TCN_FichaTecOrcItem.Buscar(val.ItemDest.Nr_orcamento.Value.ToString(), 
                                                                    val.ItemDest.Id_item.Value.ToString(), string.Empty, 
                                                                    qtb_troca.Banco_Dados);
                //Montar ficha tecnica do item do pedido
                TList_FichaTecItemPed lFicha = new TList_FichaTecItemPed();
                val.ItemDest.lFichaTec.ForEach(v => lFicha.Add(new TRegistro_FichaTecItemPed()
                {
                    Cd_item = v.Cd_item,
                    Ds_item = v.Ds_item,
                    Quantidade = v.Quantidade,
                    Cd_unditem = v.Cd_unditem,
                    Cd_local = v.Cd_local
                }));
                //Calcular custo produto composto
                CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCfg =
                    Cadastros.TCN_CFGOrcamento.Buscar(val.Cd_empresa,
                                                      string.Empty,
                                                      string.Empty,
                                                      qtb_troca.Banco_Dados).FirstOrDefault();
                decimal vl_estoque = decimal.Zero;
                TCN_LanEstoque.VlMedioEstoque(val.Cd_empresa, val.ItemDest.Cd_produto, ref vl_estoque, qtb_troca.Banco_Dados);
                TRegistro_LanPedido_Item itemPed = new TRegistro_LanPedido_Item();
                itemPed.Cd_Empresa = val.Cd_empresa;
                itemPed.Nr_pedido = rItemPed.Nr_pedido;
                itemPed.Cd_local = val.ItemDest.Cd_local;
                itemPed.Cd_produto = val.ItemDest.Cd_produto;
                itemPed.Cd_unidade_est = val.ItemDest.Cd_unid_produto;
                itemPed.Cd_unidade_valor = val.ItemDest.Cd_unid_produto;
                itemPed.Quantidade = val.ItemDest.Quantidade;
                itemPed.Vl_unitario = rCfg.St_aplicdescvlunitbool ? Math.Round(decimal.Divide(val.ItemDest.Vl_subtotal - val.ItemDest.Vl_desconto, val.ItemDest.Quantidade), 5, MidpointRounding.AwayFromZero) : val.ItemDest.Vl_unitario;
                itemPed.Vl_subtotal = decimal.Multiply(val.ItemDest.Quantidade, rCfg.St_aplicdescvlunitbool ? Math.Round(decimal.Divide(val.ItemDest.Vl_subtotal - val.ItemDest.Vl_desconto, val.ItemDest.Quantidade), 5, MidpointRounding.AwayFromZero) : val.ItemDest.Vl_unitario);
                itemPed.Pc_desc = rCfg.St_aplicdescvlunitbool ? decimal.Zero : val.ItemDest.Pc_desconto;
                itemPed.Vl_desc = rCfg.St_aplicdescvlunitbool ? decimal.Zero : val.ItemDest.Vl_desconto;
                itemPed.Vl_freteitem = val.ItemDest.Vl_frete;
                itemPed.Vl_acrescimo = val.ItemDest.Vl_acrescimo;
                itemPed.altura = val.ItemDest.vl_altura;
                itemPed.largura = val.ItemDest.vl_largura;
                itemPed.comprimento_und = val.ItemDest.vl_comprimento;
                itemPed.Pc_comrep = val.ItemDest.Pc_comrep;
                itemPed.Vl_juro_fin = val.ItemDest.Vl_juro_fin;
                itemPed.Ds_Fichatec = val.ItemDest.Ds_Fichatec;
                itemPed.St_projespecialbool = val.ItemDest.St_projespecialbool;
                itemPed.Ds_observacaoitem = val.ItemDest.Ds_observacao;
                itemPed.Nr_orcamento = val.ItemDest.Nr_orcamento;
                itemPed.Id_itemorc = val.ItemDest.Id_item;
                itemPed.Vl_custoitem = vl_estoque;
                itemPed.lFichaTec = lFicha;
                itemPed.Nr_orcamento = val.ItemDest.Nr_orcamento;
                itemPed.Id_itemorc = val.ItemDest.Id_item;
                TCN_LanPedido_Item.GravaPedido_Item(itemPed, qtb_troca.Banco_Dados);

                if (val.ItemDest.Vl_subtotalliq > val.ItemOrig.Vl_subtotalliq)
                {
                    //Gravar duplicata
                    TCN_LanDuplicata.GravarDuplicata(val.rDup, true, qtb_troca.Banco_Dados);
                    //Amarrar duplicata ao pedido
                    TCN_LanPedido_X_Duplicata.Gravar(
                        new TRegistro_LanPedido_X_Duplicata
                        {
                            Cd_empresa = val.rDup.Cd_empresa,
                            Nr_lancto = val.rDup.Nr_lancto,
                            Nr_pedido = rItemPed.Nr_pedido
                        }, qtb_troca.Banco_Dados);
                    val.Nr_lancto = val.rDup.Nr_lancto;
                }
                else if(val.ItemDest.Vl_subtotalliq < val.ItemOrig.Vl_subtotalliq)
                {
                    decimal saldo = val.ItemOrig.Vl_subtotalliq - val.ItemDest.Vl_subtotalliq;
                    //Buscar conta para quitar adiantamento
                    object objConta = new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" }
                        }, "a.cd_contager");
                    if (objConta == null)
                        throw new Exception("Não existe conta gerencial cadastrada na config. de orçamento para realizar troca.");
                    string cd_contager = objConta.ToString();
                    object objPortador = new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" }
                        }, "a.cd_portador");
                    if (objPortador == null)
                        throw new Exception("Não existe portador cadastrado na config. de orçamento para realizar troca.");
                    string cd_portador = objPortador.ToString();
                    new TCD_LanParcela(qtb_troca.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                            "inner join tb_fat_pedido_itens y " +
                                            "on x.nr_pedido = y.nr_pedido " +
                                            "and x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and y.nr_orcamento = " + val.ItemOrig.Nr_orcamento.Value.ToString() + ")"
                            },
                            new TpBusca
                            {
                                vNM_Campo = "a.Vl_Atual",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                        }, 0, string.Empty, "a.dt_vencto", string.Empty)
                        .ForEach(v =>
                        {
                            decimal vl_liquidar = saldo > v.Vl_atual ? v.Vl_atual : saldo;
                            //Gerar Liquidacao
                            TRegistro_LanLiquidacao regLiquidacao = new TRegistro_LanLiquidacao();
                            regLiquidacao.Cd_empresa = v.Cd_empresa;
                            regLiquidacao.Nr_lancto = v.Nr_lancto;
                            regLiquidacao.Nr_docto = v.Nr_docto;
                            regLiquidacao.Dt_Liquidacao = CamadaDados.UtilData.Data_Servidor(qtb_troca.Banco_Dados);
                            regLiquidacao.Cd_contager = cd_contager;
                            regLiquidacao.Cd_historico = v.Cd_historico;//Historico de quitacao
                            regLiquidacao.Cd_historico_desc = v.Cd_historico_desconto;
                            regLiquidacao.ComplHistorico = v.complHistorico;
                            regLiquidacao.Tp_mov = v.Tp_mov;
                            regLiquidacao.Cd_portador = cd_portador;
                            regLiquidacao.cVl_Atual = vl_liquidar;
                            regLiquidacao.cVl_descontoconcedido = vl_liquidar;
                            regLiquidacao.cVl_DescontoTotal = decimal.Zero;
                            regLiquidacao.cVl_juroliquidar = decimal.Zero;
                            regLiquidacao.cVl_JuroTotal = decimal.Zero;
                            regLiquidacao.cVl_Liquidado = decimal.Zero;
                            regLiquidacao.cVl_Nominal = vl_liquidar;
                            regLiquidacao.Cvl_aliquidar_padrao = vl_liquidar;
                            regLiquidacao.cVl_adiantamento = decimal.Zero;
                            regLiquidacao.lCred = null;
                            regLiquidacao.Vl_trocoCH = decimal.Zero;
                            regLiquidacao.Vl_trocoDH = decimal.Zero;
                            regLiquidacao.lChTroco = null;
                            regLiquidacao.Vl_adto = decimal.Zero;
                            regLiquidacao.St_AdtoTrocoCH = false;
                            //Gravar liquidacao                    
                            TCN_LanLiquidacao.GravarLiquidacao(new List<TRegistro_LanParcela> { v },
                                                               regLiquidacao,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               qtb_troca.Banco_Dados);
                            val.lTrocaLiquid.Add(
                                new TRegistro_Troca_X_Liquid
                                {
                                    Nr_orcamento = val.ItemOrig.Nr_orcamento,
                                    Id_itemorig = val.ItemOrig.Id_item,
                                    Id_itemdest = val.ItemDest.Id_item,
                                    Cd_empresa = regLiquidacao.Cd_empresa,
                                    Nr_lancto = regLiquidacao.Nr_lancto,
                                    Cd_parcela = regLiquidacao.Cd_parcela,
                                    Id_liquid = regLiquidacao.Id_liquid
                                });
                        });
                    if (saldo > decimal.Zero)
                    {
                        //Gerar credito com a diferenca
                        CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                        rAdto.Cd_empresa = val.Cd_empresa;
                        rAdto.Cd_clifor = Cd_clifor;
                        rAdto.CD_Endereco = Cd_endereco;
                        rAdto.Ds_adto = "Crédito troca de item da proposta " + val.Nr_orcamento.ToString();
                        rAdto.Tp_movimento = "R";//Recebido
                        rAdto.Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_troca.Banco_Dados);
                        rAdto.Vl_adto = saldo;
                        rAdto.ST_ADTO = "A";
                        rAdto.TP_Lancto = "P";
                        
                        rAdto.Cd_contager_qt = cd_contager;
                        Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, qtb_troca.Banco_Dados);
                        val.Id_adto = rAdto.Id_adto;
                    }
                }
                //Gravar troca de item
                val.Nr_orcamento = val.ItemOrig.Nr_orcamento.Value;
                val.Id_itemOrig = val.ItemOrig.Id_item.Value;
                val.Id_itemDest = val.ItemDest.Id_item.Value;
                qtb_troca.Gravar(val);
                val.lTrocaLiquid.ForEach(v => TCN_Troca_X_Liquid.Gravar(v, qtb_troca.Banco_Dados));
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AnexoItemOrc
    {
        public static TList_AnexoItemOrc Buscar(string Nr_orcamento,
                                                string Id_item,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            if (!string.IsNullOrWhiteSpace(Id_item))
                Estruturas.CriarParametro(ref filtro, "a.id_item", Id_item);
            return new TCD_AnexoItemOrc(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_AnexoItemOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoItemOrc qtb_anexo = new TCD_AnexoItemOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else
                    qtb_anexo.Banco_Dados = banco;
                string retorno = qtb_anexo.Gravar(val);
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar anexo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_AnexoItemOrc val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AnexoItemOrc qtb_anexo = new TCD_AnexoItemOrc();
            try
            {
                if (banco == null)
                    st_transacao = qtb_anexo.CriarBanco_Dados(true);
                else
                    qtb_anexo.Banco_Dados = banco;
                qtb_anexo.Excluir(val);
                if (st_transacao)
                    qtb_anexo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_anexo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir anexo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_anexo.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FichaTecOrcItem
    {
        public static TList_FichaTecOrcItem Buscar(string Nr_orcamento,
                                                   string Id_item,
                                                   string Cd_item,
                                                   BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
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
            if (!string.IsNullOrEmpty(Cd_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_item;
            }
            return new TCD_FichaTecOrcItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FichaTecOrcItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOrcItem qtb_ficha = new TCD_FichaTecOrcItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                string retorno = qtb_ficha.Gravar(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item ficha tecnica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string GravarLista(TList_FichaTecOrcItem lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOrcItem qtb_ficha = new TCD_FichaTecOrcItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                lista.ForEach(p => qtb_ficha.Gravar(p));
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item ficha tecnica: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FichaTecOrcItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOrcItem qtb_ficha = new TCD_FichaTecOrcItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                qtb_ficha.Excluir(val);
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item ficha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static string ExcluirLista(TList_FichaTecOrcItem lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FichaTecOrcItem qtb_ficha = new TCD_FichaTecOrcItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ficha.CriarBanco_Dados(true);
                else
                    qtb_ficha.Banco_Dados = banco;
                lista.ForEach(p => qtb_ficha.Excluir(p));
                if (st_transacao)
                    qtb_ficha.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ficha.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item ficha: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ficha.deletarBanco_Dados();
            }
        }

        public static TList_FichaTecOrcItem MontarFichaTecOrcItem(string Cd_produto,
                                                                  string Cd_empresa,
                                                                  string Cd_tabelapreco,
                                                                  decimal Quantidade,
                                                                  BancoDados.TObjetoBanco banco)
        {
            //Buscar ficha tecnica do produto
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                TCN_FichaTecProduto.Buscar(Cd_produto, string.Empty, banco);
            if (lFicha.Count > 0)
            {
                TList_FichaTecOrcItem lFichaOrc = new TList_FichaTecOrcItem();
                lFicha.ForEach(p =>
                    {
                        lFichaOrc.Add(new TRegistro_FichaTecOrcItem()
                        {
                            Cd_item = p.Cd_item,
                            Cd_unditem = p.Cd_unditem,
                            Ds_item = p.Ds_item,
                            Ds_unditem = p.Ds_unditem,
                            Sg_unditem = p.Sg_unditem,
                            Quantidade = p.Quantidade * Quantidade,
                            Vl_custo = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, p.Cd_item, null),
                            Vl_unitario = ((!string.IsNullOrEmpty(Cd_empresa)) && (!string.IsNullOrEmpty(Cd_tabelapreco))) ?
                                            TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, p.Cd_item, Cd_tabelapreco, banco) : decimal.Zero
                        });
                    });
                return lFichaOrc;
            }
            else
                throw new Exception("Não existe ficha tecnica cadastrada para o produto " + Cd_produto.Trim());
        }

        public static TList_FichaTecOrcItem MontarFichaTecPropostaItem(string Cd_produto,
                                                                 string Cd_empresa,
                                                                 string Cd_tabelapreco,
                                                                 decimal Quantidade,
                                                                 BancoDados.TObjetoBanco banco)
        {
            //Buscar ficha tecnica do produto
            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                TCN_FichaTecProduto.Buscar(Cd_produto, string.Empty, banco);
            if (lFicha.Count > 0)
            {
                TList_FichaTecOrcItem lFichaOrc = new TList_FichaTecOrcItem();
                lFicha.ForEach(p =>
                {
                    lFichaOrc.Add(new TRegistro_FichaTecOrcItem()
                    {
                        Cd_item = p.Cd_item,
                        Cd_unditem = p.Cd_unditem,
                        Ds_item = p.Ds_item,
                        Ds_unditem = p.Ds_unditem,
                        Sg_unditem = p.Sg_unditem,
                        Quantidade = p.Quantidade * Quantidade,
                        Vl_custo = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(Cd_empresa, p.Cd_item, null),
                        Vl_unitario = ((!string.IsNullOrEmpty(Cd_empresa)) && (!string.IsNullOrEmpty(Cd_produto)) && (!string.IsNullOrEmpty(Cd_tabelapreco))) ?
                                        CamadaNegocio.Estoque.Cadastros.TCN_PrecoItemFicha.Busca_ConsultaPreco(Cd_produto, p.Cd_item, Cd_tabelapreco, banco) : decimal.Zero
                    });
                });
                return lFichaOrc;
            }
            else
                throw new Exception("Não existe ficha tecnica cadastrada para o produto " + Cd_produto.Trim());
        }
        public static TList_FichaTecOrcItem MontarFichaTecOrcItemProducao(string Cd_produto,
                                                                          string Cd_empresa,
                                                                          string Cd_tabelapreco,
                                                                          decimal Quantidade,
                                                                          BancoDados.TObjetoBanco banco)
        {
            //Buscar Formula Apontamento Producao
            TList_FormulaApontamento lFormula = TCN_FormulaApontamento.Buscar(Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              Cd_produto,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              banco);
            if (lFormula.Count > 0)
            {
                TList_FichaTec_MPrima lMPrima = TCN_FichaTec_MPrima.Buscar(lFormula[0].Cd_empresa,
                                                                           lFormula[0].Id_formulacaostr,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           0,
                                                                           string.Empty,
                                                                           banco);
                TList_FichaTecOrcItem lFichaOrc = new TList_FichaTecOrcItem();
                if (lMPrima.Count > 0)
                    lMPrima.ForEach(p =>
                    {
                        lFichaOrc.Add(new TRegistro_FichaTecOrcItem()
                        {
                            Cd_item = p.Cd_produto,
                            Cd_unditem = p.Cd_unid_produto,
                            Ds_item = p.Ds_produto,
                            Ds_unditem = p.Ds_unidade,
                            Sg_unditem = p.Sigla_unidade,
                            Vl_custo = TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.Cd_empresa, p.Cd_produto, banco),
                            Quantidade = p.Qtd_produto * Quantidade,
                            Vl_unitario = ((!string.IsNullOrEmpty(Cd_empresa)) && (!string.IsNullOrEmpty(Cd_tabelapreco))) ?
                                            TCN_LanPrecoItem.Busca_ConsultaPreco(Cd_empresa, p.Cd_produto, Cd_tabelapreco, banco) : decimal.Zero
                        });
                    });
                return lFichaOrc;
            }
            else
                throw new Exception("Não existe fórmula de produção para o produto: " + Cd_produto.Trim());
        }
    }

    public class TCN_Orcamento_DT_Vencto
    {
        public static TList_Orcamento_DT_Vencto Buscar(string Nr_orcamento,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_orcamento;
            }
            return new TCD_Orcamento_DT_Vencto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento_DT_Vencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_DT_Vencto qtb_orc = new TCD_Orcamento_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                string retorno = qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar financeiro orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento_DT_Vencto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_DT_Vencto qtb_orc = new TCD_Orcamento_DT_Vencto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else
                    qtb_orc.Banco_Dados = banco;
                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir financeiro orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Orcamento_X_OS
    {
        public static TList_Orcamento_X_OS Buscar(string Nr_orcamento,
                                                  string Id_item,
                                                  string Id_os,
                                                  string Cd_empresa,
                                                  string Id_peca,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
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
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_peca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_peca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_peca;
            }
            return new TCD_Orcamento_X_OS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Orcamento_X_OS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_X_OS qtb_os = new TCD_Orcamento_X_OS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Orcamento_X_OS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Orcamento_X_OS qtb_os = new TCD_Orcamento_X_OS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensCompraOrcProj
    {
        public static TList_ItensCompraOrcProj Buscar(string Nr_orcamento,
                                                      string Cd_produto,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            if (!string.IsNullOrEmpty(Cd_produto))
                Estruturas.CriarParametro(ref filtro, "a.cd_produto", Cd_produto);
            return new TCD_ItensCompraOrcProj(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_ItensCompraOrcProj val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCompraOrcProj qtb_itens = new TCD_ItensCompraOrcProj();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                string ret = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Gravar(TList_ItensCompraOrcProj lista, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCompraOrcProj qtb_itens = new TCD_ItensCompraOrcProj();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                //Gravar Itens
                lista.ForEach(p => qtb_itens.Gravar(p));
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_ItensCompraOrcProj val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensCompraOrcProj qtb_itens = new TCD_ItensCompraOrcProj();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }
    
    public static class TCN_TrocaCliente
    {
        public static TList_TrocaCliente Buscar(string Nr_orcamento,
                                                string Id_troca,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            if (!string.IsNullOrEmpty(Id_troca))
                Estruturas.CriarParametro(ref filtro, "a.id_troca", Id_troca);
            return new TCD_TrocaCliente(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TrocaCliente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaCliente qtb_troca = new TCD_TrocaCliente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                val.Id_troca = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_troca.Gravar(val), "@P_ID_TROCA"));
                val.Troca_X_Mov.ForEach(x => { x.Id_troca = val.Id_troca; x.Nr_orcamento = val.Nr_orcamento; TCN_Troca_X_Mov.Gravar(x, qtb_troca.Banco_Dados); });
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return val.Id_troca.Value.ToString();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca cliente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocaCliente val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaCliente qtb_troca = new TCD_TrocaCliente();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                val.Troca_X_Mov.ForEach(x => TCN_Troca_X_Mov.Excluir(x, qtb_troca.Banco_Dados));
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca cliente: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_Troca_X_Mov
    {
        public static TList_Troca_X_Mov Buscar(string Nr_orcamento,
                                                      string Id_troca,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            if (!string.IsNullOrEmpty(Id_troca))
                Estruturas.CriarParametro(ref filtro, "a.id_troca", Id_troca);
            return new TCD_Troca_X_Mov(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Troca_X_Mov val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Troca_X_Mov qtb_troca = new TCD_Troca_X_Mov();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                string retorno = qtb_troca.Gravar(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca x liquidacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Troca_X_Mov val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Troca_X_Mov qtb_troca = new TCD_Troca_X_Mov();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca x liquidação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_TrocaItemProposta
    {
        public static TList_TrocaItemProposta Buscar(string Nr_orcamento,
                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            return new TCD_TrocaItemProposta(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_TrocaItemProposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaItemProposta qtb_troca = new TCD_TrocaItemProposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                string retorno = qtb_troca.Gravar(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocaItemProposta val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaItemProposta qtb_troca = new TCD_TrocaItemProposta();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }

    public static class TCN_Troca_X_Liquid
    {
        public static TList_Troca_X_Liquid Buscar(string Nr_orcamento,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_orcamento))
                Estruturas.CriarParametro(ref filtro, "a.nr_orcamento", Nr_orcamento);
            return new TCD_Troca_X_Liquid(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Troca_X_Liquid val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Troca_X_Liquid qtb_troca = new TCD_Troca_X_Liquid();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                string retorno = qtb_troca.Gravar(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca x liquid: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Troca_X_Liquid val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Troca_X_Liquid qtb_troca = new TCD_Troca_X_Liquid();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca x liquid: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }
}
