using System;
using System.Collections.Generic;
using Utils;
using CamadaDados.Servicos;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaNegocio.ConfigGer;
using CamadaDados.Financeiro.CCustoLan;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Fiscal;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Fiscal;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaNegocio.Servicos
{
    public class TCN_Contrato
    {
        public static TList_Contrato Buscar(string Nr_contrato,
                                            string Cd_empresa,
                                            string Cd_contratante,
                                            string Cd_vendedor,
                                            string Nr_contratoorigem,
                                            string Tp_data,
                                            string Dt_ini,
                                            string Dt_fin,
                                            bool St_carne,
                                            bool St_carneVenc,
                                            string St_registro,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contratante))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contratante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contratante.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_vendedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_vendedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_contratoorigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contratoorigem";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nr_contratoorigem.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_abertura" : "a.dt_encerramento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if(St_carne)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.cd_condpgtocarne, '')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "''";
            }
            if(St_carneVenc)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_contrato_x_carne x " +
                                                      "inner join tb_fin_duplicata y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lancto = y.nr_lancto " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "inner join tb_fin_parcela z " +
                                                      "on x.cd_empresa = z.cd_empresa " +
                                                      "and x.nr_lancto = z.nr_lancto " +
                                                      "and month(z.dt_vencto) >= month(getdate()) " +
                                                      "and year(z.dt_vencto) >= year(getdate()) " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_contrato = a.nr_contrato)";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Contrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            try
            {
                if(banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                if (val.Dt_encerramento.HasValue)
                    val.St_registro = "E";
                else val.St_registro = "A";
                val.Nr_contratostr = CamadaDados.TDataQuery.getPubVariavel(qtb_contrato.Gravar(val), "@P_NR_CONTRATO");
                //Excluir itens contrato
                val.lItensDel.ForEach(p=> TCN_Contrato_Itens.Excluir(p, qtb_contrato.Banco_Dados));
                //Gravar itens contrato
                val.lItens.ForEach(p=>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_contrato = val.Nr_contrato;
                        TCN_Contrato_Itens.Gravar(p, qtb_contrato.Banco_Dados);
                    });
                if(st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
                return val.Nr_contratostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                //Verificar se o contrato possui movimentacao
                if (new CamadaDados.Servicos.TCD_Contrato_X_NF(qtb_contrato.Banco_Dados).BuscarEscalar(
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
                            vNM_Campo = "a.nr_contrato",
                            vOperador = "=",
                            vVL_Busca = val.Nr_contratostr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                        "and isnull(x.st_registro, 'A') <> 'C')"
                        }
                    }, "1") != null)
                    throw new Exception("Não é permitido excluir contrato com faturamento.");
                //Excluir itens contrato
                val.lItensDel.ForEach(p => TCN_Contrato_Itens.Excluir(p, qtb_contrato.Banco_Dados));
                val.lItens.ForEach(p => TCN_Contrato_Itens.Excluir(p, qtb_contrato.Banco_Dados));
                //Exclui contrato x NF
                val.lNF.ForEach(p =>
                    TCN_Contrato_X_NF.Excluir(new TRegistro_Contrato_X_NF()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Nr_contrato = val.Nr_contrato,
                        Nr_lanctofiscal = p.Nr_lanctofiscal
                    }, qtb_contrato.Banco_Dados));
                //Excluir contrato
                qtb_contrato.Excluir(val);
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
                return val.Nr_contratostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static string ProcessarLote(List<TRegistro_Contrato> val,
                                           DateTime Dt_referencia,
                                           ThreadEspera tEspera,
                                           BancoDados.TObjetoBanco banco)
        {
            if(val.Count.Equals(0))
                return "Lista de contrato para processar esta vazia.";
            //Buscar parametros contrato
            TList_CfgContrato lCfg = TCN_CfgContrato.Buscar(val[0].Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
            if (lCfg.Count.Equals(0))
                return "Não existe configuração para processar contrato para a empresa " + val[0].Cd_empresa.Trim();
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            string retorno = string.Empty;
            val.ForEach(p =>
                {
                    tEspera.Msg("Processando Contrato Nº" + p.Nr_contratostr + "...");
                    //Verificar se o contrato nao possui faturamento para a data em questao
                    if (new TCD_LanFaturamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_ose_contrato_x_nf x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and isnull(a.st_registro, 'A') <> 'C' " +
                                            "and month(a.dt_emissao) = " + Dt_referencia.Month.ToString() + " " +
                                            "and year(a.dt_emissao) = " + Dt_referencia.Year.ToString() + " " +
                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                            "and x.nr_contrato = " + p.Nr_contratostr + ")"
                            }
                        }, "1") != null)
                        tEspera.Msg("Contrato Nº" + p.Nr_contratostr + " faturado para a data referência...");
                    else
                        try
                        {
                            if (banco == null)
                                st_transacao = qtb_contrato.CriarBanco_Dados(true);
                            else
                                qtb_contrato.Banco_Dados = banco;
                            //Buscar itens contrato
                            p.lItens = TCN_Contrato_Itens.Buscar(p.Nr_contratostr, p.Cd_empresa, string.Empty, qtb_contrato.Banco_Dados);
                            #region Pedido
                            //Buscar moeda padrao
                            string moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", p.Cd_empresa, qtb_contrato.Banco_Dados);
                            if (string.IsNullOrEmpty(moeda))
                                throw new Exception("Não existe moeda padrão configurada para a empresa " + p.Cd_empresa);
                            //Criar objeto pedido
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                            rPed.CD_Empresa = p.Cd_empresa;
                            rPed.CD_Clifor = p.Cd_contratante;
                            rPed.CD_Endereco = p.Cd_endcontratante;
                            rPed.Cd_moeda = moeda;
                            rPed.Cd_vendedor = p.Cd_vendedor;
                            rPed.CFG_Pedido = p.Cfg_pedido;
                            rPed.DT_Pedido = CamadaDados.UtilData.Data_Servidor(qtb_contrato.Banco_Dados);
                            //Buscar cidade da empresa
                            TList_CadCidade lCid = new TCD_CadCidade(qtb_contrato.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fin_endereco x " +
                                                    "inner join tb_div_empresa y " +
                                                    "on x.cd_clifor = y.cd_clifor " +
                                                    "and x.cd_endereco = y.cd_endereco " +
                                                    "where x.cd_cidade = a.cd_cidade " +
                                                    "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "')"
                                    }
                                }, 1, string.Empty);
                            if (lCid.Count > 0)
                            {
                                rPed.Cd_municipioexecservico = lCid[0].Cd_cidade;
                                rPed.Ds_municipioexecservico = lCid[0].Ds_cidade;
                            }
                            rPed.TP_Movimento = "S"; //Pedido de saida
                            rPed.ST_Pedido = "F"; //Pedido fechado
                            rPed.ST_Registro = "F"; //Pedido fechado
                            //Montar itens do pedido
                            p.lItens.ForEach(v =>
                            {
                                rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                {
                                    Cd_Empresa = p.Cd_empresa,
                                    Cd_local = string.Empty,
                                    Cd_produto = v.Cd_produto,
                                    Ds_produto = v.Ds_produto,
                                    Cd_condfiscal_produto = v.Cd_condfiscal_produto,
                                    Cd_unidade_est = v.Cd_unidproduto,
                                    Cd_unidade_valor = v.Cd_unidproduto,
                                    Quantidade = v.Quantidade,
                                    Vl_unitario = v.Vl_unitario,
                                    Vl_subtotal = v.Vl_subtotal
                                });
                            });
                            //Gravar pedido
                            TCN_Pedido.Grava_Pedido(rPed, qtb_contrato.Banco_Dados);
                            //Buscar pedido atualizado
                            rPed = TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), qtb_contrato.Banco_Dados);
                            //Buscar itens pedido
                            TCN_Pedido.Busca_Pedido_Itens(rPed, false, qtb_contrato.Banco_Dados);
                            #endregion

                            #region Nota Fiscal
                            //Buscar Cfg Pedido
                            TList_CadCFGPedidoFiscal lCfgPed =
                                new TCD_CadCFGPedidoFiscal(qtb_contrato.Banco_Dados).Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cfg_pedido",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rPed.CFG_Pedido.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_fiscal",
                                            vOperador = "=",
                                            vVL_Busca = "'NO'"
                                        }
                                    }, 1, string.Empty);
                            if (lCfgPed.Count.Equals(0))
                                throw new Exception("Não existe config. fiscal para o tipo pedido " + rPed.CFG_Pedido.Trim());
                            if (lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper() != "S")
                                throw new Exception("Serie <" + lCfgPed[0].Nr_serie.Trim() + "> não esta configurada para sequencia automatica.");
                            //Objeto Nota Fiscal
                            TRegistro_LanFaturamento rNf = new TRegistro_LanFaturamento();
                            rNf.Cd_empresa = rPed.CD_Empresa;
                            rNf.Cd_clifor = rPed.CD_Clifor;
                            rNf.Nm_clifor = rPed.NM_Clifor;
                            rNf.Cd_endereco = rPed.CD_Endereco;
                            rNf.Cd_cmi = lCfgPed[0].Cd_cmi;
                            rNf.Cd_movimentacao = lCfgPed[0].Cd_movto;
                            rNf.lCFGFiscal = lCfgPed;
                            rNf.Cd_uf_empresa = rPed.Cd_uf_empresa;
                            rNf.Uf_empresa = rPed.Uf_empresa;
                            rNf.Cd_uf_clifor = rPed.Cd_uf_cliente;
                            rNf.Uf_clifor = rPed.UF_Cliente;
                            rNf.Cd_condfiscal_clifor = rPed.Cd_condfiscal_clifor;
                            rNf.Cd_municipioexecservico = rPed.Cd_municipioexecservico;
                            rNf.Ds_municipioexecservico = rPed.Ds_municipioexecservico;
                            rNf.Tp_duplicata = lCfg[0].Tp_duplicata;
                            rNf.Ds_tpduplicata = lCfg[0].Ds_tpduplicata;
                            rNf.Cd_condpgto = lCfg[0].Cd_condpgto;
                            rNf.Nr_pedido = rPed.Nr_pedido;
                            rNf.Tp_movimento = rPed.TP_Movimento;
                            rNf.Tp_pessoa = rPed.Tp_pessoa;
                            rNf.Tp_nota = "P";
                            rNf.Nr_serie = lCfgPed[0].Nr_serie;
                            rNf.Cd_modelo = lCfgPed[0].Cd_modelo;
                            rNf.St_sequenciaauto = lCfgPed[0].ST_SequenciaAuto.Trim().ToUpper().Equals("S");
                            rNf.Dt_emissao = rPed.DT_Pedido;
                            rNf.Dt_saient = rPed.DT_Pedido;
                            //Itens da nota fiscal
                            rPed.Pedido_Itens.ForEach(v =>
                                {
                                    //Item da nota fiscal
                                    TRegistro_LanFaturamento_Item rItem = new TRegistro_LanFaturamento_Item();
                                    rItem.Cd_empresa = rPed.CD_Empresa;
                                    rItem.Cd_produto = v.Cd_produto;
                                    rItem.Cd_local = v.Cd_local;
                                    rItem.Cd_condfiscal_produto = v.Cd_condfiscal_produto;
                                    rItem.Cd_unidade = v.Cd_unidade_valor;
                                    rItem.Cd_unidEst = v.Cd_unidade_est;
                                    rItem.Nr_pedido = rPed.Nr_pedido;
                                    rItem.Id_pedidoitem = v.Id_pedidoitem;
                                    rItem.Quantidade = v.Quantidade;
                                    rItem.Quantidade_estoque = v.Quantidade;
                                    rItem.Vl_subtotal = v.Vl_subtotal;
                                    rItem.Vl_subtotal_estoque = v.Vl_subtotal;
                                    rItem.Vl_unitario = v.Vl_unitario;
                                    rItem.Pc_desconto = v.Pc_desc;
                                    rItem.Vl_desconto = v.Vl_desc;
                                    rItem.Vl_freteitem = v.Vl_freteitem;
                                    rItem.Pc_juro_fin = v.Pc_juro_fin;
                                    rItem.Vl_juro_fin = v.Vl_juro_fin;
                                    //Buscar cfop do item
                                    TRegistro_CadCFOP rCfop = null;
                                    bool st_dentroestado = rPed.Cd_uf_cliente.Trim().Equals(rPed.Cd_uf_empresa.Trim());
                                    if (TCN_Mov_X_CFOP.BuscarCFOP(rNf.Cd_movimentacaostring,
                                                                                       v.Cd_condfiscal_produto,
                                                                                       rPed.Cd_uf_cliente.Trim().Equals("99") ? "I" :
                                                                                       rPed.Cd_uf_cliente.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "D" : "F",
                                                                                       (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                       (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                       rNf.Tp_movimento,
                                                                                       rNf.Cd_condfiscal_clifor,
                                                                                       rNf.Cd_empresa,
                                                                                       ref rCfop,
                                                                                       qtb_contrato.Banco_Dados))
                                    {
                                        rItem.Cd_cfop = rCfop.CD_CFOP;
                                        rItem.Ds_cfop = rCfop.DS_CFOP;
                                        rItem.St_bonificacao = rCfop.St_bonificacaobool;
                                    }
                                    else
                                        throw new Exception("Não existe CFOP " + (rPed.Cd_uf_cliente.Trim().Equals("99") ? "internacional" : rPed.Cd_uf_cliente.Trim().Equals(rPed.Cd_uf_empresa.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + rNf.Cd_movimentacaostring + " condição fiscal do produto " + v.Cd_condfiscal_produto);
                                    //Procurar Impostos Estaduais para o Item
                                    string vObsFiscal = string.Empty;
                                    TList_ImpostosNF lImpUf =
                                        TCN_LanFaturamento_Item.procuraImpostosPorUf(rNf.Cd_empresa,
                                                                                    (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_clifor : rNf.Cd_uf_empresa),
                                                                                    (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Cd_uf_empresa : rNf.Cd_uf_clifor),
                                                                                    rNf.Cd_movimentacaostring,
                                                                                    rNf.Tp_movimento,
                                                                                    rNf.Cd_condfiscal_clifor,
                                                                                    rItem.Cd_condfiscal_produto,
                                                                                    rItem.Vl_subtotal,
                                                                                    rItem.Quantidade,
                                                                                    ref vObsFiscal,
                                                                                    rNf.Dt_emissao,
                                                                                    rItem.Cd_produto,
                                                                                    rNf.Tp_nota,
                                                                                    rNf.Nr_serie,
                                                                                    qtb_contrato.Banco_Dados);
                                    if (lImpUf.Exists(x=> x.Imposto.St_ICMS))
                                    {
                                        TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(x=> x.Imposto.St_ICMS), rItem);
                                        rNf.Obsfiscal += string.IsNullOrEmpty(rNf.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                                    }
                                    else if (TCN_LanFaturamento_Item.ObrigImformarICMS(rItem.Cd_produto, rNf.Nr_serie, qtb_contrato.Banco_Dados))
                                        throw new Exception("Erro: Não existe condição fiscal do ICMS.\r\n" +
                                                                "Tipo Movimento: " + rNf.Tipo_movimento.Trim() + "\r\n" +
                                                                "Movimentação: " + rNf.Cd_movimentacao.ToString() + "\r\n" +
                                                                "Cond. Fiscal Clifor: " + rNf.Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                                "Cond. Fiscal Produto: " + rItem.Cd_condfiscal_produto.Trim() + "\r\n" +
                                                                "UF Origem: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_clifor.Trim() : rNf.Uf_empresa.Trim()) + "\r\n" +
                                                                "UF Destino: " + (rNf.Tp_movimento.Trim().ToUpper().Equals("E") ? rNf.Uf_empresa.Trim() : rNf.Uf_clifor.Trim()));

                                    //Procurar impostos sobre os itens da nota fiscal de destino
                                    TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                                        TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(rNf.Cd_condfiscal_clifor,
                                                                                                rItem.Cd_condfiscal_produto,
                                                                                                rNf.Cd_movimentacaostring,
                                                                                                rNf.Tp_movimento,
                                                                                                rNf.Tp_pessoa,
                                                                                                rNf.Cd_empresa,
                                                                                                rNf.Nr_serie,
                                                                                                rNf.Cd_clifor,
                                                                                                rItem.Cd_unidEst,
                                                                                                rNf.Dt_emissao,
                                                                                                rItem.Quantidade,
                                                                                                rItem.Vl_subtotal,
                                                                                                rNf.Tp_nota,
                                                                                                rNf.Cd_municipioexecservico,
                                                                                                qtb_contrato.Banco_Dados), rItem, rNf.Tp_movimento);
                                    rNf.ItensNota.Add(rItem);
                                });
                            //Financeiro da Nota
                            if (!string.IsNullOrEmpty(rNf.Tp_duplicata) && string.IsNullOrEmpty(p.Cd_condpgtocarne))
                            {
                                TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                                rDup.Cd_empresa = rNf.Cd_empresa;
                                if (string.IsNullOrEmpty(lCfgPed[0].Cd_historicoMov))
                                    throw new Exception("Não existe historico configurado para a movimentação " + lCfgPed[0].Cd_movtostring);
                                rDup.Cd_historico = lCfgPed[0].Cd_historicoMov;
                                rDup.Nr_docto = string.Empty;
                                rDup.Vl_documento = TCN_LanFaturamento.CalcTotalNota(rNf);
                                rDup.Vl_documento_padrao = rDup.Vl_documento;
                                rDup.Dt_emissao = rNf.Dt_emissao;
                                rDup.Tp_duplicata = rNf.Tp_duplicata;
                                rDup.Tp_mov = "S";
                                //Buscar cond pagamento
                                TRegistro_CadCondPgto rCond = TCN_CadCondPgto.Buscar(lCfg[0].Cd_condpgto,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     1,
                                                                                     string.Empty,
                                                                                     qtb_contrato.Banco_Dados)[0];
                                rDup.Qt_parcelas = rCond.Qt_parcelas;
                                rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                                rDup.St_comentrada = rCond.St_comentrada;
                                rDup.Tp_docto = lCfg[0].Tp_docto;
                                rDup.Cd_juro = rCond.Cd_juro;
                                rDup.Tp_juro = rCond.Tp_juro;
                                rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                                rDup.Cd_clifor = rNf.Cd_clifor;
                                rDup.Cd_endereco = rNf.Cd_endereco;
                                rDup.Cd_moeda = rPed.Cd_moeda;
                                rDup.Cd_condpgto = lCfg[0].Cd_condpgto;
                                rDup.St_registro = string.Empty;
                                rDup.Id_configBoleto = p.Id_configboleto.HasValue ? p.Id_configboleto : lCfg[0].Id_configboleto;
                                rDup.Ds_configboleto = p.Id_configboleto.HasValue ? p.Ds_configboleto : lCfg[0].Ds_configboleto;
                                //Parcela
                                TCN_LanDuplicata.calcularParcelas(rDup, qtb_contrato.Banco_Dados);
                                rDup.Parcelas.ForEach(x =>
                                    {
                                        DateTime dt_vencto = new DateTime(x.Dt_vencto.Value.Year, x.Dt_vencto.Value.Month, Convert.ToInt32(p.Diavenctofatura));
                                        TCN_LanDuplicata.validaFeriado(false, ref dt_vencto);
                                        x.Dt_vencto = dt_vencto;
                                    });
                                if (TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                 rDup.Cd_empresa,
                                                                 null).Trim().ToUpper().Equals("S") &&
                                    (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult)))
                                    rDup.lCustoLancto = new TList_LanCCustoLancto()
                                    {
                                        new TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = rDup.Cd_empresa,
                                            Cd_centroresult = lCfg[0].Cd_centroresult,
                                            Vl_lancto = rDup.Vl_documento,
                                            Dt_lancto = rDup.Dt_emissao
                                        }
                                    };
                                rNf.Duplicata.Add(rDup);
                            }
                            //Gravar Nota Fiscal
                            TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_contrato.Banco_Dados);
                            p.lNF.Clear();
                            p.lNF.Add(rNf);
                            //Gravar Contrato X NF
                            TCN_Contrato_X_NF.Gravar(new TRegistro_Contrato_X_NF()
                            {
                                Cd_empresa = rNf.Cd_empresa,
                                Nr_contrato = p.Nr_contrato,
                                Nr_lanctofiscal = rNf.Nr_lanctofiscal
                            }, qtb_contrato.Banco_Dados);
                            if (st_transacao)
                                qtb_contrato.Banco_Dados.Commit_Tran();
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            if (st_transacao)
                                qtb_contrato.Banco_Dados.RollBack_Tran();
                            p.lNF.Clear();
                            retorno += "Contrato: " + p.Nr_contratostr + ", Erro: " + ex.Message.Trim() + "\r\n";
                        }
                        finally
                        {
                            if (st_transacao)
                                qtb_contrato.deletarBanco_Dados();
                        }
                });
            return retorno;
        }
        public static void GerarCarne(List<TRegistro_Contrato> val,
                                        DateTime Dt_referencia,
                                        BancoDados.TObjetoBanco banco)
        {
            if (val.Count.Equals(0))
                throw new Exception("Lista de contrato para processar esta vazia.");
            //Buscar parametros contrato
            TList_CfgContrato lCfg = TCN_CfgContrato.Buscar(val[0].Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
            if (lCfg.Count.Equals(0))
                throw new Exception("Não existe configuração para processar contrato para a empresa " + val[0].Cd_empresa.Trim());
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            string retorno = string.Empty;
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else qtb_contrato.Banco_Dados = banco;
                val.ForEach(p =>
                {
                    //Duplicata Carnê
                    TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                    rDup.Cd_empresa = p.Cd_empresa;
                    if (string.IsNullOrEmpty(lCfg[0].Cd_historico))
                        throw new Exception("Não existe historico configurado para gerar carnê.");
                    rDup.Cd_historico = lCfg[0].Cd_historico;
                    rDup.Nr_docto = string.Empty;
                    rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor(qtb_contrato.Banco_Dados);
                    rDup.Tp_duplicata = lCfg[0].Tp_duplicata;
                    rDup.Tp_docto = lCfg[0].Tp_docto;
                    rDup.Tp_mov = "S";
                    //Buscar cond pagamento
                    TRegistro_CadCondPgto rCond = TCN_CadCondPgto.Buscar(p.Cd_condpgtocarne,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         decimal.Zero,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         1,
                                                                         string.Empty,
                                                                         qtb_contrato.Banco_Dados)[0];
                    rDup.Qt_parcelas = rCond.Qt_parcelas;
                    rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                    rDup.St_comentrada = rCond.St_comentrada;
                    rDup.Tp_docto = lCfg[0].Tp_docto;
                    rDup.Cd_juro = rCond.Cd_juro;
                    rDup.Tp_juro = rCond.Tp_juro;
                    rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                    rDup.Cd_clifor = p.Cd_contratante;
                    rDup.Cd_endereco = p.Cd_endcontratante;
                    //Buscar moeda padrao
                    string moeda = TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", p.Cd_empresa, qtb_contrato.Banco_Dados);
                    if (string.IsNullOrEmpty(moeda))
                        throw new Exception("Não existe moeda padrão configurada para a empresa " + p.Cd_empresa);
                    rDup.Cd_moeda = moeda;
                    rDup.Cd_condpgto = rCond.Cd_condpgto;
                    rDup.St_registro = string.Empty;
                    rDup.Id_configBoleto = p.Id_configboleto.HasValue ? p.Id_configboleto : lCfg[0].Id_configboleto;
                    rDup.Ds_configboleto = p.Id_configboleto.HasValue ? p.Ds_configboleto : lCfg[0].Ds_configboleto;
                    rDup.Vl_documento = p.Vl_contrato * rCond.Qt_parcelas;
                    rDup.Vl_documento_padrao = rDup.Vl_documento;
                    //Parcela
                    TCN_LanDuplicata.calcularParcelas(rDup, qtb_contrato.Banco_Dados);
                    rDup.Parcelas.ForEach(x =>
                    {
                        DateTime dt_vencto = new DateTime(x.Dt_vencto.Value.Year, x.Dt_vencto.Value.Month, Convert.ToInt32(p.Diavenctofatura));
                        TCN_LanDuplicata.validaFeriado(false, ref dt_vencto);
                        x.Dt_vencto = dt_vencto;
                    });
                    if (TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                        rDup.Cd_empresa,
                                                        null).Trim().ToUpper().Equals("S") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult)))
                        rDup.lCustoLancto = new TList_LanCCustoLancto()
                            {
                                new TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = rDup.Cd_empresa,
                                    Cd_centroresult = lCfg[0].Cd_centroresult,
                                    Vl_lancto = rDup.Vl_documento,
                                    Dt_lancto = rDup.Dt_emissao
                                }
                            };
                    //Gravar duplicata
                    TCN_LanDuplicata.GravarDuplicata(rDup, true, qtb_contrato.Banco_Dados);
                    //Gravar Contrato x Carne
                    TCN_Contrato_X_Carne.Gravar(new TRegistro_Contrato_X_Carne()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Nr_contrato = p.Nr_contrato,
                        Nr_lancto = rDup.Nr_lancto
                    }, qtb_contrato.Banco_Dados);
                });
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar carnê: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static void SuspenderContrato(TRegistro_Contrato val, 
                                             string Motivo, 
                                             DateTime Dt_prevtermsusp,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else qtb_contrato.Banco_Dados = banco;
                val.St_registro = "S";
                qtb_contrato.Gravar(val);
                TCN_SuspContrato.Gravar(new TRegistro_SuspContrato()
                {
                    Nr_contrato = val.Nr_contrato,
                    Cd_empresa = val.Cd_empresa,
                    Ds_motivo = Motivo,
                    Dt_inisuspenso = CamadaDados.UtilData.Data_Servidor(qtb_contrato.Banco_Dados),
                    Dt_prevtermsusp = Dt_prevtermsusp
                }, qtb_contrato.Banco_Dados);
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro suspender contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static void EncerrarSuspensao(TRegistro_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato qtb_contrato = new TCD_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else qtb_contrato.Banco_Dados = banco;
                val.St_registro = "A";
                new TCD_SuspContrato(qtb_contrato.Banco_Dados).Select(
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
                            vNM_Campo = "a.nr_contrato",
                            vOperador = "=",
                            vVL_Busca = val.Nr_contratostr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.dt_finsuspenso",
                            vOperador = "is",
                            vVL_Busca = "null"
                        }
                    }, 0, string.Empty).ForEach(p =>
                        {
                            p.Dt_finsuspenso = CamadaDados.UtilData.Data_Servidor(qtb_contrato.Banco_Dados);
                            TCN_SuspContrato.Gravar(p, qtb_contrato.Banco_Dados);
                        });
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar suspensão contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Contrato_Itens
    {
        public static TList_Contrato_Itens Buscar(string Nr_contrato,
                                                  string Cd_empresa,
                                                  string Cd_produto,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_Contrato_Itens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_Itens qtb_contrato = new TCD_Contrato_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_contrato.CriarBanco_Dados(true);
                else
                    qtb_contrato.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_contrato.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    qtb_contrato.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_contrato.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_contrato.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato_Itens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_Itens qtb_item = new TCD_Contrato_Itens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                qtb_item.Excluir(val);
                if (st_transacao)
                    qtb_item.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Contrato_X_NF
    {
        public static TList_Contrato_X_NF Buscar(string Nr_contrato,
                                                 string Cd_empresa,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_Contrato_X_NF(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanFaturamento BuscarNF(string Nr_contrato,
                                                                                          string Cd_empresa,
                                                                                          BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanFaturamento(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_ose_contrato_x_nf x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.nr_contrato = " + Nr_contrato + ")"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato_X_NF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_NF qtb_ped = new TCD_Contrato_X_NF();
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
                throw new Exception("Erro gravar pedido contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato_X_NF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_NF qtb_ped = new TCD_Contrato_X_NF();
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
                throw new Exception("Erro excluir pedido contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ped.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Contrato_X_Carne
    {
        public static TList_Contrato_X_Carne Buscar(string Cd_empresa,
                                                    string Nr_contrato,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            return new TCD_Contrato_X_Carne(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Contrato_X_Carne val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_Carne qtb_c = new TCD_Contrato_X_Carne();
            try
            {
                if (banco == null)
                    st_transacao = qtb_c.CriarBanco_Dados(true);
                else qtb_c.Banco_Dados = banco;
                string retorno = qtb_c.Gravar(val);
                if (st_transacao)
                    qtb_c.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_c.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_c.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_Contrato_X_Carne val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_Carne qtb_c = new TCD_Contrato_X_Carne();
            try
            {
                if (banco == null)
                    st_transacao = qtb_c.CriarBanco_Dados(true);
                else qtb_c.Banco_Dados = banco;
                qtb_c.Excluir(val);
                if (st_transacao)
                    qtb_c.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_c.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_c.deletarBanco_Dados();
            }
        }
    }

    public class TCN_SuspContrato
    {
        public static TList_SuspContrato Buscar(string Nr_contrato,
                                                string Cd_empresa,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_SuspContrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_SuspContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SuspContrato qtb_susp = new TCD_SuspContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_susp.CriarBanco_Dados(true);
                else
                    qtb_susp.Banco_Dados = banco;
                val.Id_suspensostr = CamadaDados.TDataQuery.getPubVariavel(qtb_susp.Gravar(val), "@P_ID_SUSPENSO");
                if (st_transacao)
                    qtb_susp.Banco_Dados.Commit_Tran();
                return val.Id_suspensostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_susp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_susp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_SuspContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SuspContrato qtb_susp = new TCD_SuspContrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_susp.CriarBanco_Dados(true);
                else
                    qtb_susp.Banco_Dados = banco;
                qtb_susp.Excluir(val);
                if (st_transacao)
                    qtb_susp.Banco_Dados.Commit_Tran();
                return val.Id_suspensostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_susp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_susp.deletarBanco_Dados();
            }
        }
    }
}
