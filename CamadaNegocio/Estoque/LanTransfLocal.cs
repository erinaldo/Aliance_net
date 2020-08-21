using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Estoque;
using BancoDados;

namespace CamadaNegocio.Estoque
{
    public class TCN_TransfLocal
    {
        public static TList_TransfLocal Buscar(string Id_transf,
                                        string Cd_produto,
                                        string Cd_empresaorigem,
                                        string Cd_empresadestino,
                                        string Cd_localorigem,
                                        string Cd_localdestino,
                                        string Dt_ini,
                                        string Dt_fin,
                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_transf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_transf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_transf;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_empresaorigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                                      "inner join tb_est_estoque y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.tp_movimento = 'S' " +
                                                      "and x.cd_empresa = '" + Cd_empresaorigem.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_empresadestino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                                      "inner join tb_est_estoque y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.tp_movimento = 'E' " +
                                                      "and x.cd_empresa = '" + Cd_empresadestino.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_localorigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                                      "inner join tb_est_estoque y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.tp_movimento = 'S' " +
                                                      "and y.cd_local = '" + Cd_localorigem.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Cd_localdestino))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_transflocal_x_estoque x " +
                                                      "inner join tb_est_estoque y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.cd_produto = y.cd_produto " +
                                                      "and x.id_lanctoestoque = y.id_lanctoestoque " +
                                                      "where x.id_transf = a.id_transf " +
                                                      "and y.tp_movimento = 'E' " +
                                                      "and y.cd_local = '" + Cd_localdestino.Trim() + "')";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            return new TCD_TransfLocal(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TransfLocal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfLocal qtb_transf = new TCD_TransfLocal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_transf.CriarBanco_Dados(true);
                else
                    qtb_transf.Banco_Dados = banco;
                //Gravar Transferencia
                val.Id_transf = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_transf.Gravar(val), "@P_ID_TRANSF"));
                //Buscar valor medio do estoque
                decimal vl_estoque_medio = 0;
                if (TCN_LanEstoque.VlMedioEstoque(val.Cd_empresaorigem, val.Cd_produto, ref vl_estoque_medio, qtb_transf.Banco_Dados))
                {
                    //Gravar estoque de saida do produto do local de origem
                    string id_estoque_sai = TCN_LanEstoque.GravarEstoque(new TRegistro_LanEstoque()
                    {
                        Cd_produto = val.Cd_produto,
                        Cd_empresa = val.Cd_empresaorigem,
                        Cd_local = val.Cd_localorigem,
                        Dt_lancto = val.Dt_lancto,
                        St_registro = "A",
                        Tp_lancto = "T",
                        Tp_movimento = "S",
                        Qtd_saida = val.Quantidade,
                        Qtd_entrada = decimal.Zero,
                        Vl_unitario = vl_estoque_medio,
                        Vl_subtotal = vl_estoque_medio * val.Quantidade
                    }, qtb_transf.Banco_Dados);
                    //Gravar Transferencia X Estoque de saida
                    TCN_LanTransfLocal_X_Estoque.GravarTransLocal_X_Estoque(new TRegistro_LanTransfLocal_X_Estoque()
                    {
                        Id_transf = val.Id_transf.Value,
                        Cd_empresa = val.Cd_empresaorigem,
                        Cd_produto = val.Cd_produto,
                        Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(id_estoque_sai, "@@P_ID_LANCTOESTOQUE"))
                    }, qtb_transf.Banco_Dados);
                    //Gravar estoque de entrada do produto no local de destino
                    string id_estoque_ent = TCN_LanEstoque.GravarEstoque(new TRegistro_LanEstoque()
                    {
                        Cd_produto = val.Cd_produto,
                        Cd_empresa = val.Cd_empresadestino,
                        Cd_local = val.Cd_localdestino,
                        Dt_lancto = val.Dt_lancto,
                        St_registro = "A",
                        Tp_lancto = "T",
                        Tp_movimento = "E",
                        Qtd_saida = decimal.Zero,
                        Qtd_entrada = val.Quantidade,
                        Vl_unitario = vl_estoque_medio,
                        Vl_subtotal = vl_estoque_medio * val.Quantidade
                    }, qtb_transf.Banco_Dados);
                    //Gravar Transferencia X Estoque de entrada
                    TCN_LanTransfLocal_X_Estoque.GravarTransLocal_X_Estoque(new TRegistro_LanTransfLocal_X_Estoque()
                    {
                        Id_transf = val.Id_transf.Value,
                        Cd_empresa = val.Cd_empresadestino,
                        Cd_produto = val.Cd_produto,
                        Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(id_estoque_ent, "@@P_ID_LANCTOESTOQUE"))
                    }, qtb_transf.Banco_Dados);
                }
                else
                    throw new Exception("Não Existe Valor Médio Para o Produto ");
                
                if (st_transacao)
                    qtb_transf.Banco_Dados.Commit_Tran();

                return val.Id_transf.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_transf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar transf.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_transf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TransfLocal val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TransfLocal qtb_LanTransfLocal = new TCD_TransfLocal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_LanTransfLocal.CriarBanco_Dados(true);
                else
                    qtb_LanTransfLocal.Banco_Dados = banco;

                qtb_LanTransfLocal.Excluir(val);
                
                if (st_transacao)
                    qtb_LanTransfLocal.Banco_Dados.Commit_Tran();

                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanTransfLocal.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro exclui transf.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_LanTransfLocal.deletarBanco_Dados();
            }
        }
    }
}
