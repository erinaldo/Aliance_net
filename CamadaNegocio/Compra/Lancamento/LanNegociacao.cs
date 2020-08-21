using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_Negociacao
    {
        public static TList_Negociacao Buscar(string Id_negociacao,
                                              string Cd_produto,
                                              string Cd_grupo,
                                              string Ds_observacao,
                                              string Cd_fornecedor,
                                              string Cd_condpgto,
                                              string Tp_data,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string St_registro,
                                              int vTop,
                                              string vNm_campo,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_negociacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_negociacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_negociacao;
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (Cd_grupo.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            if (Ds_observacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_negociacao_item x " +
                                                      "where x.id_negociacao = a.id_negociacao " +
                                                      "and x.cd_fornecedor = '" + Cd_fornecedor.Trim() + "')";
            }
            if (Cd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_cmp_negociacao_item x " +
                                                      "where x.id_negociacao = a.id_negociacao " +
                                                      "and x.cd_condpgto = '" + Cd_condpgto.Trim() + "')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = (Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_negociacao" : "a.dt_fechnegociacao");
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = (Tp_data.Trim().ToUpper().Equals("A") ? "a.dt_negociacao" : "a.dt_fechnegociacao");
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (St_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_Negociacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarNegociacao(TRegistro_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_negociacao = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_negociacao.CriarBanco_Dados(true);
                else
                    qtb_negociacao.Banco_Dados = banco;
                //Gravar negociacao
                string retorno = qtb_negociacao.GravarNegociacao(val);
                val.Id_negociacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_NEGOCIACAO"));
                //Deletar itens da negociacao
                val.lItensDel.ForEach(p => TCN_NegociacaoItem.DeletarNegociacaoItem(p, qtb_negociacao.Banco_Dados));
                //Gravar itens da negociacao
                val.lItens.ForEach(p =>
                    {
                        p.Id_negociacao = val.Id_negociacao;
                        TCN_NegociacaoItem.GravarNegociacaoItem(p, qtb_negociacao.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_negociacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_negociacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar negociacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_negociacao.deletarBanco_Dados();
            }
        }

        public static string DeletarNegociacao(TRegistro_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_negociacao = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_negociacao.CriarBanco_Dados(true);
                else
                    qtb_negociacao.Banco_Dados = banco;
                //Verificar se existe requisicao utilizando negociacao

                //Cancelar itens
                val.lItens.ForEach(p =>
                    {
                        p.St_registro = "C";
                        TCN_NegociacaoItem.GravarNegociacaoItem(p, qtb_negociacao.Banco_Dados);
                    });
                val.St_registro = "C";//cancelada
                GravarNegociacao(val, qtb_negociacao.Banco_Dados);
                if (st_transacao)
                    qtb_negociacao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_negociacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar negociacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_negociacao.deletarBanco_Dados();
            }
        }

        public static string ProcessarNegociacao(TRegistro_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_neg = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                //Percorrer lista de fornecedor
                val.lItens.ForEach(p =>
                    {
                        if (p.St_processar)
                        {
                            //Alterar status para V - Aprovada
                            p.St_registro = "V";
                            TCN_NegociacaoItem.GravarNegociacaoItem(p, qtb_neg.Banco_Dados);
                        }
                        else
                        {
                            //Alterar status para R - Refugada
                            p.St_registro = "R";
                            TCN_NegociacaoItem.GravarNegociacaoItem(p, qtb_neg.Banco_Dados);
                        }
                    });
                //Alterar status da negociacao para P - Processada
                val.St_registro = "P";
                val.Dt_fechnegociacao = CamadaDados.UtilData.Data_Servidor();
                string retorno = qtb_neg.GravarNegociacao(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar negociação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }

        public static void FecharNegociacao(TRegistro_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_neg = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                val.St_registro = "F";//Status F- Fechada
                qtb_neg.GravarNegociacao(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro fechar negociação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }

        public static void EncerrarNegociacao(TRegistro_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_neg = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                val.St_registro = "E";
                qtb_neg.GravarNegociacao(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro encerrar negociação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }

        public static void LancarNegFornec(TList_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Negociacao qtb_neg = new TCD_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        //Verificar se existe negociacao em aberto ou fechada para o produto
                        TList_Negociacao aux = Buscar(string.Empty,
                                                      p.Cd_produto,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      "'A', 'F'",
                                                      1,
                                                      string.Empty,
                                                      qtb_neg.Banco_Dados);
                        if (aux.Count > 0)
                        {
                            p.lItens.ForEach(v =>
                                {
                                    v.Id_negociacao = aux[0].Id_negociacao;
                                    TCN_NegociacaoItem.GravarNegociacaoItem(v, qtb_neg.Banco_Dados);
                                });
                        }
                        else
                        {
                            //Gravar negociacao
                            string retorno = qtb_neg.GravarNegociacao(p);
                            //Gravar item negociacao
                            p.lItens.ForEach(v =>
                                {
                                    v.Id_negociacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_NEGOCIACAO"));
                                    string ret = TCN_NegociacaoItem.GravarNegociacaoItem(v, qtb_neg.Banco_Dados);
                                    v.lPrazoEntrega.ForEach(x =>
                                        {
                                            x.Id_negociacao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_NEGOCIACAO"));
                                            x.Id_item = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_ITEM"));
                                            TCN_PrazoEntrega.GravarPrazoEntrega(x, qtb_neg.Banco_Dados);
                                        });
                                });
                        }
                    });
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro lançar negociação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }
    }
}
