using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;
using Utils;
using BancoDados;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaNegocio.Faturamento.Cadastros;
using CamadaNegocio.Balanca;
using CamadaDados.Balanca;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Fiscal;

namespace CamadaNegocio.Graos
{
    public class TCN_Transferencia
    {

        public static TList_Transferencia Busca(string vID_Transf, 
                                                string vNR_Contrato_Origem,
                                                string vNR_Contrato_Destino,
                                                string vDT_Inicial,
                                                string vDT_Final,
                                                string vCD_Clifor_Origem,
                                                string vCD_Clifor_Destino,
                                                string vSt_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if(!string.IsNullOrEmpty(vID_Transf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_transf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vID_Transf;
            }
            if (!string.IsNullOrEmpty(vNR_Contrato_Origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_transf_x_contrato x " +
                                                      "inner join tb_gro_contrato y " +
                                                      "on x.nr_contrato = y.nr_contrato " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and x.nr_contrato = " + vNR_Contrato_Origem + " " +
                                                      "and x.tp_movimento <> y.tp_movimento)";
            }
            if (!string.IsNullOrEmpty(vNR_Contrato_Destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_transf_x_contrato x " +
                                                      "inner join tb_gro_contrato y " +
                                                      "on x.nr_contrato = y.nr_contrato " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and x.nr_contrato = " + vNR_Contrato_Destino + " " +
                                                      "and x.tp_movimento = y.tp_movimento)";
            }
            if ((!string.IsNullOrEmpty(vDT_Inicial)) && (vDT_Inicial.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Inicial).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(vDT_Final)) && (vDT_Final.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Final).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor_Origem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_transf_x_pedido x " +
                                                      "inner join tb_fat_pedido y "+
                                                      "on x.nr_pedido = y.nr_pedido "+
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.cd_clifor = '" + vCD_Clifor_Origem + "' " +
                                                      "and x.tp_movimento = 'S')";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor_Destino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_gro_transf_x_pedido x " +
                                                      "inner join tb_fat_pedido y " +
                                                      "on x.nr_pedido = y.nr_pedido " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.cd_clifor = '" + vCD_Clifor_Destino + "' " +
                                                      "and x.tp_movimento = 'E')";
            }
            if (!string.IsNullOrEmpty(vSt_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vSt_registro.Trim() + ")";
            }

            return new TCD_Transferencia(banco).Select(filtro, 0, string.Empty);
        }

        public static string Grava_Transferencia(TRegistro_Transferencia val,
                                                 TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Transferencia qtb_Transferencia = new TCD_Transferencia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Transferencia.CriarBanco_Dados(true);
                else
                    qtb_Transferencia.Banco_Dados = banco;

                // Grava Transferencia
                string retorno = qtb_Transferencia.Gravar(val);
                val.ID_Transf = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_TRANSF"));
                // Grava Transferencia Pedido Origem

                #region Nota_Fiscal_Origem
                val.rNfOrigem.Nr_pedido = val.Transf_X_Contrato_Origem[0].Nr_pedido;
                val.rNfOrigem.Cd_clifor = val.Contrato_Origem.Cd_clifor;
                val.rNfOrigem.Cd_condfiscal_clifor = string.Empty;
                val.rNfOrigem.Cd_condpgto = val.Contrato_Origem.CD_CondPGTO;
                val.rNfOrigem.Cd_empresa = val.Contrato_Origem.Cd_empresa;
                val.rNfOrigem.Cd_endereco = val.Contrato_Origem.Cd_endereco;
                val.rNfOrigem.Cd_movimentacao = val.Contrato_Origem.Pedido_Fiscal[0].Cd_movto;
                if (val.Duplicata_Origem.Count > 0)
                    val.rNfOrigem.Duplicata = val.Duplicata_Origem;

                //Criar itens da nota fiscal
                TRegistro_LanFaturamento_Item Reg_Itens_Nota = new TRegistro_LanFaturamento_Item();
                Reg_Itens_Nota.Cd_produto = val.Transf_X_Contrato_Origem[0].Cd_produto;
                Reg_Itens_Nota.lNfcompdev = val.Complemento_Devolucao;
                Reg_Itens_Nota.Quantidade = val.QTD_Transf;
                Reg_Itens_Nota.Vl_unitario = val.VL_Unit_Origem;
                Reg_Itens_Nota.Cd_local = val.Contrato_Origem.Cd_local;
                Reg_Itens_Nota.Vl_subtotal = val.VL_Sub_Total_Origem;
                Reg_Itens_Nota.Id_pedidoitem = val.Contrato_Origem.Id_pedidoitem;
                Reg_Itens_Nota.Nr_pedido = val.Contrato_Origem.Nr_pedido.Value;
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(val.rNfOrigem.Cd_movimentacaostring,
                                                                   val.Transf_X_Contrato_Origem[0].Cd_condfiscal_produto,
                                                                   val.Contrato_Origem.CD_UFClifor.Trim().Equals("99") ? "I" :
                                                                   val.Reg_Empresa_Origem.rEndereco.Cd_uf.Trim().Equals(val.Contrato_Origem.CD_UFClifor.Trim()) ? "D" : "F",
                                                                   val.Reg_Empresa_Origem.rEndereco.Cd_uf,
                                                                   val.Contrato_Origem.CD_UFClifor,
                                                                   val.rNfOrigem.Tp_movimento,
                                                                   val.Reg_Clifor_Origem.Cd_condfiscal_clifor,
                                                                   val.Reg_Empresa_Origem.Cd_empresa,
                                                                   ref rCfop,
                                                                   banco))
                {
                    Reg_Itens_Nota.Cd_cfop = rCfop.CD_CFOP;
                    Reg_Itens_Nota.Ds_cfop = rCfop.DS_CFOP;
                    Reg_Itens_Nota.St_bonificacao = rCfop.St_bonificacaobool;
                }
                else
                    throw new Exception("Não existe CFOP " + (val.Contrato_Origem.CD_UFClifor.Trim().Equals("99") ? "internacional" : val.Reg_Empresa_Origem.rEndereco.Cd_uf.Trim().Equals(val.Contrato_Origem.CD_UFClifor.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + val.rNfOrigem.Cd_movimentacaostring + " condição fiscal do produto " + val.Transf_X_Contrato_Origem[0].Cd_condfiscal_produto);
                Reg_Itens_Nota.Cd_unidade = val.Contrato_Origem.Cd_unidade;
                Reg_Itens_Nota.Cd_unidEst = val.Contrato_Origem.Cd_unid_produto;
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpUfOrig = TCN_LanFaturamento_Item.procuraImpostosPorUf(val.Reg_Empresa_Origem.Cd_empresa,
                                                                                           val.Reg_Empresa_Origem.rEndereco.Cd_uf,
                                                                                           val.Contrato_Origem.CD_UFClifor,
                                                                                           val.Contrato_Origem.Pedido_Fiscal[0].Cd_movtostring,
                                                                                           val.rNfOrigem.Tp_movimento,
                                                                                           val.Reg_Clifor_Origem.Cd_condfiscal_clifor,
                                                                                           val.Reg_Produto_Origem.CD_CondFiscal_Produto,
                                                                                           val.VL_Sub_Total_Origem,
                                                                                           val.QTD_Transf,
                                                                                           ref vObsFiscal,
                                                                                           val.rNfOrigem.Dt_emissao,
                                                                                           val.Reg_Produto_Origem.CD_Produto,
                                                                                           val.rNfOrigem.Tp_nota,
                                                                                           val.rNfOrigem.Nr_serie,
                                                                                           banco);
                if (lImpUfOrig.Exists(v=> v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpUfOrig.Find(v=> v.Imposto.St_ICMS), Reg_Itens_Nota);
                    val.rNfOrigem.Obsfiscal += string.IsNullOrEmpty(val.rNfOrigem.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(val.Reg_Produto_Origem.CD_Produto, val.rNfOrigem.Nr_serie, banco))
                    throw new Exception("Não existe condição fiscal para o imposto ICMS: \r\n" +
                                                "Tipo Movimento: " + (val.rNfOrigem.Tp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA") + "\r\n" +
                                                "Movimentação Comercial: " + val.Contrato_Origem.Pedido_Fiscal[0].Cd_movtostring + " - " + val.Contrato_Origem.Pedido_Fiscal[0].Ds_movimentacao + "\r\n" +
                                                "Condição Fiscal Clifor: " + val.Reg_Clifor_Origem.Cd_condfiscal_clifor + "\r\n" +
                                                "Condição Fiscal Produto: " + val.Reg_Produto_Origem.CD_CondFiscal_Produto + "\r\n" +
                                                "UF Origem: " + val.Reg_Empresa_Origem.rEndereco.Cd_uf + "\r\n" +
                                                "UF Destino: " + val.Contrato_Origem.CD_UFClifor);
                
                //Procurar impostos sobre os itens da nota fiscal de origem
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(val.Reg_Clifor_Origem.Cd_condfiscal_clifor,
                                                                            val.Reg_Produto_Origem.CD_CondFiscal_Produto,
                                                                            val.Contrato_Origem.Pedido_Fiscal[0].Cd_movtostring,
                                                                            val.rNfOrigem.Tp_movimento,
                                                                            val.Reg_Clifor_Origem.Tp_pessoa,
                                                                            val.Transf_X_Contrato_Origem[0].CD_Empresa,
                                                                            val.Contrato_Origem.Pedido_Fiscal[0].Nr_serie,
                                                                            val.Reg_Clifor_Origem.Cd_clifor,
                                                                            val.Reg_Produto_Origem.CD_Unidade,
                                                                            val.DT_Lancto,
                                                                            Reg_Itens_Nota.Quantidade,
                                                                            Reg_Itens_Nota.Vl_subtotal,
                                                                            val.rNfOrigem.Tp_nota,
                                                                            string.Empty,
                                                                            banco), Reg_Itens_Nota, val.rNfOrigem.Tp_movimento);
                //Gerar observacao para o item
                //Observação do Item com os dados das notas de origem
                string obsitem = string.Empty;
                val.Complemento_Devolucao.ForEach(p =>
                {
                    obsitem += (p.Nr_notafiscal_origem.ToString() + "/" + p.Nr_serie_origem).FormatStringDireita(21, ' ') + 
                                (p.Qtd_lancto.ToString("N3", new System.Globalization.CultureInfo("en-US", true)) +
                                Reg_Itens_Nota.Sigla_unidade_estoque.Trim()).FormatStringDireita(15, ' ') + 
                                p.Vl_lancto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringDireita(12, ' ') + "\r\n";
                });
                Reg_Itens_Nota.Observacao_item += "NF/Serie Origem      Quantidade     Valor(R$)\r\n" + obsitem;
                //Adicionar item a nota fiscal de origem
                val.rNfOrigem.ItensNota.Add(Reg_Itens_Nota);
                //Gravar nota fiscal de origem
                TCN_LanFaturamento.GravarFaturamento(val.rNfOrigem, null, qtb_Transferencia.Banco_Dados);
                val.Transf_X_Contrato_Origem[0].NR_LanctoFiscal = val.rNfOrigem.Nr_lanctofiscal.Value;
                //Gravar transferencia x pedido origem
                TCN_Transf_X_Contrato.Gravar(new TRegistro_Transf_X_Contrato()
                    {
                        CD_Empresa = val.Transf_X_Contrato_Origem[0].CD_Empresa,
                        Cd_produto = val.Transf_X_Contrato_Origem[0].Cd_produto,
                        ID_Transf = val.ID_Transf,
                        TP_Movimento = val.rNfOrigem.Tp_movimento,
                        NR_LanctoFiscal = val.rNfOrigem.Nr_lanctofiscal.Value,
                        ID_NFItem = val.rNfOrigem.ItensNota[0].Id_nfitem,
                        NR_Contrato = val.Contrato_Origem.Nr_contrato
                    }, qtb_Transferencia.Banco_Dados);
                #endregion

                #region Nota_Fiscal_Destino
                val.rNfDestino.Nr_pedido = val.Transf_X_Contrato_Destino[0].Nr_pedido;
                val.rNfDestino.Cd_clifor = val.Contrato_Destino.Cd_clifor;
                val.rNfDestino.Cd_condpgto = val.Contrato_Destino.CD_CondPGTO;
                val.rNfDestino.Cd_empresa = val.Contrato_Destino.Cd_empresa;
                val.rNfDestino.Cd_endereco = val.Contrato_Destino.Cd_endereco;
                val.rNfDestino.Cd_movimentacao = val.Contrato_Destino.Pedido_Fiscal[0].Cd_movto;
                if (val.Duplicata_Destino.Count > 0)
                    val.rNfDestino.Duplicata = val.Duplicata_Destino;

                //Registro item da nota fiscal de destino
                TRegistro_LanFaturamento_Item Reg_Itens_Nota_Destino = new TRegistro_LanFaturamento_Item();
                if (val.Transf_X_Contrato_Destino[0].CD_Unidade_Est.Equals(val.Transf_X_Contrato_Origem[0].CD_Unidade_Est))
                    Reg_Itens_Nota_Destino.Quantidade = val.QTD_Transf;
                else
                    Reg_Itens_Nota_Destino.Quantidade = TCN_CadConvUnidade.ConvertUnid(val.Transf_X_Contrato_Destino[0].CD_Unidade_Est, val.Transf_X_Contrato_Origem[0].CD_Unidade_Est, val.QTD_Transf, 3, qtb_Transferencia.Banco_Dados);

                Reg_Itens_Nota_Destino.Cd_produto = val.Transf_X_Contrato_Destino[0].Cd_produto;
                Reg_Itens_Nota_Destino.Vl_unitario = val.VL_Unit_Destino;
                Reg_Itens_Nota_Destino.Cd_local = val.Contrato_Destino.Cd_local;
                Reg_Itens_Nota_Destino.Vl_subtotal = val.VL_Sub_Total_Destino;
                Reg_Itens_Nota_Destino.Id_pedidoitem = val.Contrato_Destino.Id_pedidoitem.Value;
                Reg_Itens_Nota_Destino.Nr_pedido = val.Contrato_Destino.Nr_pedido.Value;
                rCfop = null;
                if (TCN_Mov_X_CFOP.BuscarCFOP(val.rNfDestino.Cd_movimentacaostring,
                                              val.Transf_X_Contrato_Destino[0].Cd_condfiscal_produto,
                                              val.Contrato_Destino.CD_UFClifor.Trim().Equals("99") ? "I" :
                                              val.Reg_Empresa_Destino.rEndereco.Cd_uf.Trim().Equals(val.Contrato_Destino.CD_UFClifor.Trim()) ? "D" : "F",
                                              val.Reg_Empresa_Destino.rEndereco.Cd_uf,
                                              val.Contrato_Destino.CD_UFClifor,
                                              val.rNfDestino.Tp_movimento,
                                              val.Reg_Clifor_Destino.Cd_condfiscal_clifor,
                                              val.Reg_Empresa_Destino.Cd_empresa,
                                              ref rCfop,
                                              banco))
                {
                    Reg_Itens_Nota_Destino.Cd_cfop = rCfop.CD_CFOP;
                    Reg_Itens_Nota_Destino.Ds_cfop = rCfop.DS_CFOP;
                    Reg_Itens_Nota_Destino.St_bonificacao = rCfop.St_bonificacaobool;
                }
                else
                    throw new Exception("Não existe CFOP " + (val.Contrato_Destino.CD_UFClifor.Trim().Equals("99") ? "internacional" : val.Reg_Empresa_Destino.rEndereco.Cd_uf.Trim().Equals(val.Contrato_Destino.CD_UFClifor.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + val.rNfDestino.Cd_movimentacaostring + " condição fiscal do produto " + val.Transf_X_Contrato_Destino[0].Cd_condfiscal_produto);
                Reg_Itens_Nota_Destino.Cd_unidade = val.Contrato_Destino.Cd_unidade;
                Reg_Itens_Nota_Destino.Cd_unidEst = val.Contrato_Destino.Cd_unid_produto;
                //Procurar Impostos Estaduais para o Item
                vObsFiscal = string.Empty;
                TList_ImpostosNF lImpUf = TCN_LanFaturamento_Item.procuraImpostosPorUf(val.Reg_Empresa_Destino.Cd_empresa,
                                                                                       val.Reg_Empresa_Destino.rEndereco.Cd_uf,
                                                                                       val.Contrato_Destino.CD_UFClifor,
                                                                                       val.Contrato_Destino.Pedido_Fiscal[0].Cd_movtostring,
                                                                                       val.rNfDestino.Tp_movimento,
                                                                                       val.Reg_Clifor_Destino.Cd_condfiscal_clifor,
                                                                                       val.Reg_Produto_Destino.CD_CondFiscal_Produto,
                                                                                       val.VL_Sub_Total_Destino,
                                                                                       val.QTD_Transf,
                                                                                       ref vObsFiscal,
                                                                                       val.rNfDestino.Dt_emissao,
                                                                                       val.Reg_Produto_Destino.CD_Produto,
                                                                                       val.rNfDestino.Tp_nota,
                                                                                       val.rNfDestino.Nr_serie,
                                                                                       banco);
                if (lImpUf.Exists(v=> v.Imposto.St_ICMS))
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpUf.Find(v=> v.Imposto.St_ICMS), Reg_Itens_Nota_Destino);
                    val.rNfDestino.Obsfiscal += string.IsNullOrEmpty(val.rNfDestino.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(val.Reg_Produto_Destino.CD_Produto, val.rNfDestino.Nr_serie, banco))
                    throw new Exception("Não existe condição fiscal para o imposto ICMS: \r\n" +
                                                "Tipo Movimento: " + (val.rNfDestino.Tp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA") + "\r\n" +
                                                "Movimentação Comercial: " + val.Contrato_Destino.Pedido_Fiscal[0].Cd_movtostring + " - " + val.Contrato_Destino.Pedido_Fiscal[0].Ds_movimentacao + "\r\n" +
                                                "Condição Fiscal Clifor: " + val.Reg_Clifor_Destino.Cd_condfiscal_clifor + "\r\n" +
                                                "Condição Fiscal Produto: " + val.Reg_Produto_Destino.CD_CondFiscal_Produto + "\r\n" +
                                                "UF Origem: " + val.Reg_Empresa_Destino.rEndereco.Cd_uf + "\r\n" +
                                                "UF Destino: " + val.Contrato_Destino.CD_UFClifor);
                
                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(val.Reg_Clifor_Destino.Cd_condfiscal_clifor,
                                                                                                                  val.Reg_Produto_Destino.CD_CondFiscal_Produto,
                                                                                                                  val.Contrato_Destino.Pedido_Fiscal[0].Cd_movtostring,
                                                                                                                  val.rNfDestino.Tp_movimento,
                                                                                                                  val.Reg_Clifor_Destino.Tp_pessoa,
                                                                                                                  val.Transf_X_Contrato_Destino[0].CD_Empresa,
                                                                                                                  val.Contrato_Destino.Pedido_Fiscal[0].Nr_serie,
                                                                                                                  val.Reg_Clifor_Destino.Cd_clifor,
                                                                                                                  val.Reg_Produto_Destino.CD_Unidade,
                                                                                                                  val.DT_Lancto,
                                                                                                                  Reg_Itens_Nota_Destino.Quantidade,
                                                                                                                  Reg_Itens_Nota_Destino.Vl_subtotal,
                                                                                                                  val.rNfDestino.Tp_nota,
                                                                                                                  string.Empty,
                                                                                                                  banco), Reg_Itens_Nota_Destino, val.rNfDestino.Tp_movimento);
                val.rNfDestino.ItensNota.Add(Reg_Itens_Nota_Destino);
                //Gravar Nota Fiscal Destino
                TCN_LanFaturamento.GravarFaturamento(val.rNfDestino, null, qtb_Transferencia.Banco_Dados);
                val.Transf_X_Contrato_Destino[0].NR_LanctoFiscal = val.rNfDestino.Nr_lanctofiscal.Value;

                TCN_Transf_X_Contrato.Gravar(new TRegistro_Transf_X_Contrato()
                {
                    CD_Empresa = val.Transf_X_Contrato_Destino[0].CD_Empresa,
                    Cd_produto = val.Transf_X_Contrato_Destino[0].Cd_produto,
                    ID_Transf = val.ID_Transf,
                    TP_Movimento = val.rNfDestino.Tp_movimento,
                    NR_LanctoFiscal = val.rNfDestino.Nr_lanctofiscal.Value,
                    ID_NFItem = val.rNfDestino.ItensNota[0].Id_nfitem,
                    NR_Contrato = val.Transf_X_Contrato_Destino[0].NR_Contrato
                }, qtb_Transferencia.Banco_Dados);

                #endregion

                if (st_transacao)
                    qtb_Transferencia.Banco_Dados.Commit_Tran();

                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Transferencia.Banco_Dados.RollBack_Tran();

                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_Transferencia.deletarBanco_Dados();
            }
        }

        public static void Altera_Transferencia(TRegistro_Transferencia val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Transferencia qtb_transf = new TCD_Transferencia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else
                    qtb_transf.Banco_Dados = banco;
                qtb_transf.Gravar(val);
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar transferência: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }

        public static void Cancela_Transferencia(TRegistro_Transferencia val, TObjetoBanco banco)
        {
            string Retorno = string.Empty;
            bool st_transacao = false;
            TCD_Transferencia qtb_Transferencia = new TCD_Transferencia();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Transferencia.CriarBanco_Dados(true);
                else
                    qtb_Transferencia.Banco_Dados = banco;
                
                //Verificar se o usuario tem permissão para cancelar nota fiscal
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR NOTAS FISCAIS", qtb_Transferencia.Banco_Dados))
                    throw new Exception("Usuario não tem permissão para cancelar nota fiscal.");
                //Cancelar transferencia
                val.St_registro = "C";
                Altera_Transferencia(val, qtb_Transferencia.Banco_Dados);
                //Cancelar nota fiscal de origem
                TList_RegLanFaturamento lFatOrigem = TCN_LanFaturamento.Busca(val.Transf_X_Contrato_Origem[0].CD_Empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              val.Transf_X_Contrato_Origem[0].NR_LanctoFiscal.ToString(),
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
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              string.Empty,
                                                                              qtb_Transferencia.Banco_Dados);
                if (lFatOrigem.Count > 0)
                    TCN_LanFaturamento.CancelarFaturamento(lFatOrigem[0], qtb_Transferencia.Banco_Dados);
                else
                    throw new Exception("Nota Fiscal de Origem não encontrada!");

                //Cancelar nota fiscal de destino
                TList_RegLanFaturamento lFatDestino = TCN_LanFaturamento.Busca(val.Transf_X_Contrato_Destino[0].CD_Empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                val.Transf_X_Contrato_Destino[0].NR_LanctoFiscal.ToString(),
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
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                false,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                qtb_Transferencia.Banco_Dados);
                if (lFatDestino.Count > 0)
                    TCN_LanFaturamento.CancelarFaturamento(lFatDestino[0], qtb_Transferencia.Banco_Dados);
                else
                    throw new Exception("Nota Fiscal de destino não encontrada!");

                
                if (st_transacao)
                    qtb_Transferencia.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Transferencia.Banco_Dados.RollBack_Tran();
                //Retornar o status da transferencia para ativo novamente
                val.St_registro = "A";
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_Transferencia.deletarBanco_Dados();
            }
        }

        public static decimal Saldo_Contrato(string NR_Contrato, string CD_Produto, bool St_origem)
        {
            decimal Retorno = 0;
            try
            {
                if ((!string.IsNullOrEmpty(CD_Produto)) && 
                    (!string.IsNullOrEmpty(NR_Contrato)))
                {
                    TList_PedidoAplicacao List_Aplicacao = TCN_PedidoAplicacao.Buscar(string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty,
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      false, 
                                                                                      NR_Contrato, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      string.Empty, 
                                                                                      false, 
                                                                                      CD_Produto, 
                                                                                      false, 
                                                                                      false, 
                                                                                      string.Empty, 
                                                                                      false, 
                                                                                      false,
                                                                                      0);

                    if (List_Aplicacao.Count > 0)
                        Retorno = St_origem ? List_Aplicacao[0].Ps_disponivel : List_Aplicacao[0].Ps_saldo;
                }
                return Retorno;
            }
            catch
            {
                return Retorno;
            }
        }

        public static bool Verifica_Valores_Fixos(string Nr_contrato, BancoDados.TObjetoBanco banco)
        {
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from vtb_gro_contrato x " +
                                                "where x.cfg_pedido = a.cfg_pedido " +
                                                "and x.nr_contrato = " + Nr_contrato + ")"
                                }
                            }, "cfgped.st_valoresfixos");
            return obj == null ? false : obj.ToString().Trim().ToUpper().Equals("S");
        }

        public static bool Confere_Saldo(string Nr_contrato, BancoDados.TObjetoBanco banco)
        {
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal(banco).BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from vtb_gro_contrato x " +
                                                "where x.cfg_pedido = a.cfg_pedido " +
                                                "and x.nr_contrato = " + Nr_contrato + ")"
                                }
                            }, "cfgped.ST_Confere_Saldo");
            return obj == null ? false : obj.ToString().Trim().ToUpper().Equals("S");
        }
        
        public static void Busca_Transf_Origem(TRegistro_Transferencia val)
        {
            if (val != null)
                if (val.Transf_X_Contrato_Origem.Count == 0)
                    if (val.ID_Transf > 0)
                        val.Transf_X_Contrato_Origem = TCN_Transf_X_Contrato.Busca(val.ID_Transf.ToString(), 
                                                                                   string.Empty, 
                                                                                   "S", 
                                                                                   string.Empty, 
                                                                                   false,
                                                                                   null);
        }

        public static void Busca_Transf_Destino(TRegistro_Transferencia val)
        {
            if (val != null)
                if (val.Transf_X_Contrato_Destino.Count == 0)
                    if (val.ID_Transf > 0)
                        val.Transf_X_Contrato_Destino = TCN_Transf_X_Contrato.Busca(val.ID_Transf.ToString(), 
                                                                                    string.Empty, 
                                                                                    "E", 
                                                                                    string.Empty, 
                                                                                    false,
                                                                                    null);
        }
    }
        
}
