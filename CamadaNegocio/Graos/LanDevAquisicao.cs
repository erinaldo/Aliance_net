using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using CamadaDados.Graos;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using CamadaNegocio.Estoque.Cadastros;

namespace CamadaNegocio.Graos
{
    public class TCN_DevAquisicao
    {
        public static void GravarDevAquisicao(TRegistro_DevAquisicao val,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            if (banco == null)
            {
                banco = new BancoDados.TObjetoBanco();
                banco.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                banco.CriarComando();
                banco.Conexao.Open();
                banco.Start_Tran(System.Data.IsolationLevel.ReadCommitted);
                banco.Comando.Transaction = banco.Transac;
                st_transacao = true;
            }
            try
            {
                #region Nota_Fiscal_Origem
                val.rNfOrigem.Nr_pedido = val.Contrato_devolucao[0].Nr_pedido;
                val.rNfOrigem.Cd_clifor = val.Contrato_Origem.Cd_clifor;
                val.rNfOrigem.Cd_cmi = val.Contrato_Origem.Pedido_Fiscal[0].Cd_cmi;
                val.rNfOrigem.Cd_cmistring = val.Contrato_Origem.Pedido_Fiscal[0].Cd_cmistring; ;
                val.rNfOrigem.Cd_condfiscal_clifor = string.Empty;
                val.rNfOrigem.Cd_condpgto = val.Contrato_Origem.CD_CondPGTO;
                val.rNfOrigem.Cd_empresa = val.Contrato_Origem.Cd_empresa;
                val.rNfOrigem.Cd_endereco = val.Contrato_Origem.Cd_endereco;
                val.rNfOrigem.Cd_modelo = val.Contrato_Origem.Pedido_Fiscal[0].Cd_modelo;
                val.rNfOrigem.Cd_movimentacao = val.Contrato_Origem.Pedido_Fiscal[0].Cd_movto;
                                
                if (val.Duplicata_Origem.Count > 0)
                    val.rNfOrigem.Duplicata = val.Duplicata_Origem;

                //Criar itens da nota fiscal
                TRegistro_LanFaturamento_Item Reg_Itens_Nota = new TRegistro_LanFaturamento_Item();
                Reg_Itens_Nota.Cd_produto = val.Contrato_devolucao[0].Cd_produto;
                Reg_Itens_Nota.lNfcompdev = val.Devolucao;
                Reg_Itens_Nota.Quantidade = val.Quantidade;
                Reg_Itens_Nota.Vl_unitario = val.Vl_unit_origem;
                Reg_Itens_Nota.Cd_local = val.Contrato_devolucao[0].CD_Local;
                Reg_Itens_Nota.Vl_subtotal = val.Vl_subtotal_origem;
                Reg_Itens_Nota.Id_pedidoitem = val.Contrato_Origem.Id_pedidoitem.Value;
                Reg_Itens_Nota.Nr_pedido = val.Contrato_Origem.Nr_pedido.Value;
                CamadaDados.Fiscal.TRegistro_CadCFOP rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(val.rNfOrigem.Cd_movimentacaostring,
                                                                   val.Contrato_devolucao[0].Cd_condfiscal_produto,
                                                                   val.Contrato_Origem.CD_UFClifor.Trim().Equals("99") ? "I" :
                                                                   val.Contrato_Origem.CD_UFClifor.Trim().Equals(val.Reg_Empresa_Origem.rEndereco.Cd_uf.Trim()) ? "D" : "F",
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
                    throw new Exception("Não existe CFOP " + (val.Contrato_Origem.CD_UFClifor.Trim().Equals("99") ? "internacional" :
                       val.Contrato_Origem.CD_UFClifor.Trim().Equals(val.Reg_Empresa_Origem.rEndereco.Cd_uf.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + val.rNfOrigem.Cd_movimentacaostring + " condição fiscal do produto " + val.Contrato_devolucao[0].Cd_condfiscal_produto);

                Reg_Itens_Nota.Cd_unidade = val.Contrato_Origem.Cd_unidade;
                Reg_Itens_Nota.Cd_unidEst = val.Contrato_Origem.Cd_unid_produto;
                //Procurar Impostos Estaduais para o Item
                string vObsFiscal = string.Empty;
                TList_ImpostosNF lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf(val.Reg_Empresa_Origem.Cd_empresa,
                                                                                          val.Reg_Empresa_Origem.rEndereco.Cd_uf,
                                                                                          val.Contrato_Origem.CD_UFClifor,
                                                                                          val.Contrato_Origem.Pedido_Fiscal[0].Cd_movtostring,
                                                                                          val.rNfOrigem.Tp_movimento,
                                                                                          val.Reg_Clifor_Origem.Cd_condfiscal_clifor,
                                                                                          val.Reg_Produto_Origem.CD_CondFiscal_Produto,
                                                                                          val.Vl_subtotal_origem,
                                                                                          val.Quantidade,
                                                                                          ref vObsFiscal,
                                                                                          val.rNfOrigem.Dt_emissao,
                                                                                          val.Reg_Produto_Origem.CD_Produto,
                                                                                          val.rNfOrigem.Tp_nota,
                                                                                          val.rNfOrigem.Nr_serie,
                                                                                          banco);
                if (lImpostos.Count > 0)
                {
                    TCN_LanFaturamento_Item.PreencherICMS(lImpostos[0], Reg_Itens_Nota);
                    val.rNfOrigem.Obsfiscal += string.IsNullOrEmpty(val.rNfOrigem.Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                }
                else if (TCN_LanFaturamento_Item.ObrigImformarICMS(val.Reg_Produto_Destino.CD_Produto, val.rNfOrigem.Nr_serie, banco))
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
                                                                          val.Contrato_devolucao[0].CD_Empresa,
                                                                          val.Contrato_Origem.Pedido_Fiscal[0].Nr_serie,
                                                                          val.Reg_Clifor_Origem.Cd_clifor,
                                                                          val.Reg_Produto_Origem.CD_Unidade,
                                                                          val.Dt_lancto,
                                                                          Reg_Itens_Nota.Quantidade,
                                                                          Reg_Itens_Nota.Vl_subtotal,
                                                                          val.rNfOrigem.Tp_nota,
                                                                          string.Empty,
                                                                          banco), Reg_Itens_Nota, val.rNfOrigem.Tp_movimento);
                //Gerar observacao para o item
                //Observação do Item com os dados das notas de origem
                string obsitem = string.Empty;
                val.Devolucao.ForEach(p =>
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
                TCN_LanFaturamento.GravarFaturamento(val.rNfOrigem, null, banco);
                val.Contrato_devolucao[0].NR_LanctoFiscal = val.rNfOrigem.Nr_lanctofiscal.Value;
                #endregion

                #region Nota_Fiscal_Destino
                val.rNfDestino.Nr_pedido = val.Contrato_compra[0].Nr_pedido;
                val.rNfDestino.Cd_clifor = val.Contrato_Destino.Cd_clifor;
                val.rNfDestino.Cd_cmi = val.Contrato_Destino.Pedido_Fiscal[0].Cd_cmi;
                val.rNfDestino.Cd_cmistring = val.Contrato_Destino.Pedido_Fiscal[0].Cd_cmistring; ;
                val.rNfDestino.Cd_condpgto = val.Contrato_Destino.CD_CondPGTO;
                val.rNfDestino.Cd_empresa = val.Contrato_Destino.Cd_empresa;
                val.rNfDestino.Cd_endereco = val.Contrato_Destino.Cd_endereco;
                val.rNfDestino.Cd_modelo = val.Contrato_Destino.Pedido_Fiscal[0].Cd_modelo;
                val.rNfDestino.Cd_movimentacao = val.Contrato_Destino.Pedido_Fiscal[0].Cd_movto;
                if (val.Duplicata_Destino.Count > 0)
                    val.rNfDestino.Duplicata = val.Duplicata_Destino;

                //Registro item da nota fiscal de destino
                TRegistro_LanFaturamento_Item Reg_Itens_Nota_Destino = new TRegistro_LanFaturamento_Item();
                if (val.Contrato_compra[0].CD_Unidade_Est.Equals(val.Contrato_devolucao[0].CD_Unidade_Est))
                    Reg_Itens_Nota_Destino.Quantidade = val.Quantidade;
                else
                    Reg_Itens_Nota_Destino.Quantidade = TCN_CadConvUnidade.ConvertUnid(val.Contrato_compra[0].CD_Unidade_Est, val.Contrato_devolucao[0].CD_Unidade_Est, val.Quantidade, 3, banco);
                Reg_Itens_Nota_Destino.Cd_produto = val.Contrato_compra[0].Cd_produto;
                Reg_Itens_Nota_Destino.Vl_unitario = val.Vl_unit_destino;
                Reg_Itens_Nota_Destino.Cd_local = val.Contrato_compra[0].CD_Local;
                Reg_Itens_Nota_Destino.Vl_subtotal = val.Vl_subtotal_destino;
                Reg_Itens_Nota_Destino.Id_pedidoitem = val.Contrato_Destino.Id_pedidoitem;
                Reg_Itens_Nota_Destino.Nr_pedido = val.Contrato_Destino.Nr_pedido.Value;
                rCfop = null;
                if (CamadaNegocio.Fiscal.TCN_Mov_X_CFOP.BuscarCFOP(val.rNfDestino.Cd_movimentacaostring,
                                                                   val.Contrato_compra[0].Cd_condfiscal_produto,
                                                                   val.Contrato_Destino.CD_UFClifor.Trim().Equals("99") ? "I":
                                                                   val.Contrato_Destino.CD_UFClifor.Trim().Equals(val.Reg_Empresa_Destino.rEndereco.Cd_uf.Trim()) ? "D" : "F",
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
                    throw new Exception("Não existe CFOP " + (val.Contrato_Destino.CD_UFClifor.Trim().Equals("99") ? "internacional" : val.Contrato_Destino.CD_UFClifor.Trim().Equals(val.Reg_Empresa_Destino.rEndereco.Cd_uf.Trim()) ? "dentro estado" : "fora estado") + " configurado para a Movimentação " + val.rNfDestino.Cd_movimentacaostring + " condição fiscal do produto " + val.Contrato_compra[0].Cd_condfiscal_produto);
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
                                                                                       val.Vl_subtotal_destino,
                                                                                       val.Quantidade,
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
                    throw new Exception("Não existe configuração fiscal para o imposto ICMS: \r\n" +
                                                "Tipo Movimento: " + (val.rNfDestino.Tp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA") + "\r\n" +
                                                "Movimentação Comercial: " + val.Contrato_Destino.Pedido_Fiscal[0].Cd_movtostring + " - " + val.Contrato_Destino.Pedido_Fiscal[0].Ds_movimentacao + "\r\n" +
                                                "Condição Fiscal Clifor: " + val.Reg_Clifor_Destino.Cd_condfiscal_clifor + "\r\n" +
                                                "Condição Fiscal Produto: " + val.Reg_Produto_Destino.CD_CondFiscal_Produto + "\r\n" +
                                                "UF Origem: " + val.Reg_Empresa_Destino.rEndereco.Cd_uf + "\r\n" +
                                                "UF Destino: " + val.Contrato_Destino.CD_UFClifor);
                
                //Procurar impostos sobre os itens da nota fiscal de destino
                TCN_LanFaturamento_Item.PreencherOutrosImpostos(
                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(val.Reg_Clifor_Destino.Cd_condfiscal_clifor,
                                                                            val.Reg_Produto_Destino.CD_CondFiscal_Produto,
                                                                            val.Contrato_Destino.Pedido_Fiscal[0].Cd_movtostring,
                                                                            val.rNfDestino.Tp_movimento,
                                                                            val.Reg_Clifor_Destino.Tp_pessoa,
                                                                            val.Contrato_compra[0].CD_Empresa,
                                                                            val.Contrato_Destino.Pedido_Fiscal[0].Nr_serie,
                                                                            val.Reg_Clifor_Destino.Cd_clifor,
                                                                            val.Reg_Produto_Destino.CD_Unidade,
                                                                            val.Dt_lancto,
                                                                            Reg_Itens_Nota_Destino.Quantidade,
                                                                            Reg_Itens_Nota_Destino.Vl_subtotal,
                                                                            val.rNfDestino.Tp_nota,
                                                                            string.Empty,
                                                                            banco), Reg_Itens_Nota_Destino, val.rNfDestino.Tp_movimento);
                val.rNfDestino.ItensNota.Add(Reg_Itens_Nota_Destino);
                //Gravar Nota Fiscal Destino
                TCN_LanFaturamento.GravarFaturamento(val.rNfDestino, null, banco);
                val.Contrato_compra[0].NR_LanctoFiscal = val.rNfDestino.Nr_lanctofiscal.Value;
                #endregion

                if (st_transacao)
                    banco.Transac.Commit();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    banco.Transac.Rollback();
                throw new Exception("Erro gravar devolução/aquisição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                {
                    if (banco.Conexao.State == System.Data.ConnectionState.Open)
                        banco.Conexao.Close();
                    banco = null;
                }
            }
        }
    }
}
