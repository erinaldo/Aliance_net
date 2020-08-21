using System;
using Utils;
using BancoDados;
using CamadaDados.Estoque;
using System.Linq;

namespace CamadaNegocio.Estoque
{
    public class TCN_Lan_Provisao_Estoque
    {
        public static TList_Lan_Provisao_Estoque Buscar(string vID_Provisao,
                                                        string vDS_Provisao,                                                            
                                                        string vCd_empresa,
                                                        string vCd_produto,
                                                        string vDt_ini,
                                                        string vDt_fin,
                                                        bool vSt_comsaldo,
                                                        TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vID_Provisao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Provisao";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Provisao;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vDS_Provisao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Provisao";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Provisao.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
                            
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa_Prov";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }

            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto_Prov";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_lancto";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_lancto";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (vSt_comsaldo)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.saldo_provisao";
                vBusca[vBusca.Length - 1].vOperador = ">";
                vBusca[vBusca.Length - 1].vVL_Busca = "0";
            }   
                            
            return new TCD_Lan_Provisao_Estoque(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lan_Provisao_Estoque val, TObjetoBanco banco)
        {
            TCD_Lan_Provisao_Estoque QTB_Provisao_Estoque = new TCD_Lan_Provisao_Estoque();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = QTB_Provisao_Estoque.CriarBanco_Dados(true);
                else
                    QTB_Provisao_Estoque.Banco_Dados = banco;

                //Gravar Lancamento Estoque
                val.Id_lanctoestoque_prov = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(
                                            TCN_LanEstoque.GravarEstoque(
                                            new TRegistro_LanEstoque()
                                            {
                                                Cd_empresa = val.Cd_empresa_prov,
                                                Cd_produto = val.Cd_produto_prov,
                                                Tp_lancto = "P",
                                                Tp_movimento = "E",
                                                Cd_local = val.Cd_local,
                                                Ds_observacao = val.Ds_provisao,
                                                Dt_lancto = val.Dt_lancto,
                                                Qtd_entrada = val.Quantidade,
                                                Qtd_saida = decimal.Zero,
                                                Vl_unitario = val.Vl_unitario,
                                                Vl_subtotal = val.Quantidade * val.Vl_unitario
                                            }, QTB_Provisao_Estoque.Banco_Dados), "@@P_ID_LANCTOESTOQUE"));
                //Gravar Provisao
                val.Id_provisao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(QTB_Provisao_Estoque.Gravar(val), "@P_ID_PROVISAO"));
                //Gravar Provisao X Estoque
                TCN_Prov_X_Estoque.Gravar(new TRegistro_Lan_Provisao_X_Estoque()
                {
                    Cd_empresa = val.Cd_empresa_prov,
                    Cd_produto = val.Cd_produto_prov,
                    Id_lanctoestoque = val.Id_lanctoestoque_prov,
                    Id_provisao = val.Id_provisao
                }, QTB_Provisao_Estoque.Banco_Dados);
                //Contabilizar Provisao
                System.Collections.Generic.List<CamadaDados.Contabil.TRegistro_Lan_ProcProvEstoque> lProv =
                    CamadaNegocio.Contabil.TCN_Lan_ProcContabil.BuscaProc_ProvEstoque(string.Empty,
                                                                                      val.Id_provisao.Value.ToString(),
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      false,
                                                                                      QTB_Provisao_Estoque.Banco_Dados);
                if (lProv != null)
                    if (lProv.Exists(p => p.CD_ContaCre.HasValue && p.CD_ContaDeb.HasValue))
                        CamadaNegocio.Contabil.TCN_LanContabil.ProcessaCTB_ProvEstoque(lProv.FindAll(p => p.CD_ContaDeb.HasValue && p.CD_ContaCre.HasValue), QTB_Provisao_Estoque.Banco_Dados);
                if (pode_liberar)
                    QTB_Provisao_Estoque.Banco_Dados.Commit_Tran();
                return val.Id_provisao.Value.ToString();
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar provisao: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.deletarBanco_Dados();
            }
            
        }

        public static string Baixar(TRegistro_Lan_Provisao_Estoque val, TObjetoBanco banco)
        {
            TCD_Lan_Provisao_Estoque QTB_Provisao_Estoque = new TCD_Lan_Provisao_Estoque();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = QTB_Provisao_Estoque.CriarBanco_Dados(true);
                else
                    QTB_Provisao_Estoque.Banco_Dados = banco;

                //Gravar Lancamento Estoque da Baixa
                //Buscar lancamento estoque origem
                TList_RegLanEstoque lEstoque =
                    new TCD_LanEstoque(QTB_Provisao_Estoque.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_movimento",
                            vOperador = "=",
                            vVL_Busca = "'E'",
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'",
                        },
                        new TpBusca()
                        {
                            vNM_Campo= string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_est_prov_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_provisao = " + val.Id_provisao.Value.ToString() + ")"
                        }
                    }, 1, string.Empty, string.Empty, string.Empty);
                if (lEstoque.Count > 0)
                {
                    string retorno = TCN_LanEstoque.GravarEstoque(
                        new TRegistro_LanEstoque()
                        {
                            Cd_empresa = lEstoque[0].Cd_empresa,
                            Cd_local = lEstoque[0].Cd_local,
                            Cd_produto = lEstoque[0].Cd_produto,
                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                            Qtd_entrada = decimal.Zero,
                            Qtd_saida = val.Saldo_Provisao,
                            Tp_lancto = "P",
                            Tp_movimento = "S",
                            Vl_unitario = Math.Round(lEstoque.Average(x=> decimal.Divide(x.Vl_subtotal, x.Qtd_entrada)), 7, MidpointRounding.AwayFromZero),
                            Vl_subtotal = val.Saldo_Provisao * Math.Round(lEstoque.Average(x => decimal.Divide(x.Vl_subtotal, x.Qtd_entrada)), 7, MidpointRounding.AwayFromZero)
                        }, QTB_Provisao_Estoque.Banco_Dados);
                    //Gravar Provisao X Estoque
                    TCN_Prov_X_Estoque.Gravar(new TRegistro_Lan_Provisao_X_Estoque()
                    {
                        Cd_empresa = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_EMPRESA"),
                        Cd_produto = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_PRODUTO"),
                        Id_lanctoestoque = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@@P_ID_LANCTOESTOQUE")),
                        Id_provisao = val.Id_provisao
                    }, QTB_Provisao_Estoque.Banco_Dados);

                    if (pode_liberar)
                        QTB_Provisao_Estoque.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                else
                    throw new Exception("Estoque de origem da provisão não foi encontrado.");
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro baixa provisao: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lan_Provisao_Estoque val, TObjetoBanco banco)
        {
            TCD_Lan_Provisao_Estoque QTB_Provisao_Estoque = new TCD_Lan_Provisao_Estoque();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = QTB_Provisao_Estoque.CriarBanco_Dados(true);
                else
                    QTB_Provisao_Estoque.Banco_Dados = banco;

                if (val.Lan_Estoque.Count > 0)
                    TCN_LanEstoque.DeletarEstoque(val.Lan_Estoque[0], QTB_Provisao_Estoque.Banco_Dados);
                TCN_Prov_X_Estoque.Buscar(val.Cd_empresa_prov,
                                          val.Id_provisao.Value.ToString(),
                                          QTB_Provisao_Estoque.Banco_Dados).ForEach(p =>
                                              TCN_Prov_X_Estoque.Excluir(p, QTB_Provisao_Estoque.Banco_Dados));
                QTB_Provisao_Estoque.Excluir(val);
                
                if (pode_liberar)
                    QTB_Provisao_Estoque.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir provisao: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    QTB_Provisao_Estoque.deletarBanco_Dados();
            }
        }
    }

    public class TCN_Prov_X_Estoque
    {
        public static TList_Lan_Provisao_X_Estoque Buscar(string Cd_empresa,
                                                          string Id_provisao,
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
            if (!string.IsNullOrEmpty(Id_provisao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_provisao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_provisao;
            }
            return new TCD_Lan_Provisao_X_Estoque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lan_Provisao_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_Provisao_X_Estoque qtb_lan = new TCD_Lan_Provisao_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lan.CriarBanco_Dados(true);
                else qtb_lan.Banco_Dados = banco;
                string ret = qtb_lan.Gravar(val);
                if (st_transacao)
                    qtb_lan.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lan.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lan_Provisao_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_Provisao_X_Estoque qtb_lan = new TCD_Lan_Provisao_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lan.CriarBanco_Dados(true);
                else qtb_lan.Banco_Dados = banco;
                qtb_lan.Excluir(val);
                //Excluir Lote Contabil
                if (val.Id_loteCTB.HasValue)
                    CamadaNegocio.Contabil.TCN_LanContabil.ExcluirLoteCTB(val.Id_loteCTB.Value.ToString(), qtb_lan.Banco_Dados);
                if (st_transacao)
                    qtb_lan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lan.deletarBanco_Dados();
            }
        }
    }
}
