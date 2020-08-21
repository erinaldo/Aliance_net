using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Emprestimos;

namespace CamadaNegocio.Financeiro.Emprestimos
{
    #region Emprestimos
    public class TCN_Emprestimos
    {
        public static TList_Emprestimos Buscar(string Id_emprestimo,
                                               string Cd_empresa,
                                               string Cd_clifor,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string Tp_emprestimo,
                                               string St_registro,
                                               bool St_devolvido,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_emprestimo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_emprestimo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_emprestimo;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (Dt_ini.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emprestimo";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (Dt_fin.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emprestimo";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(Tp_emprestimo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_emprestimo";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_emprestimo.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            if (St_devolvido)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_emprestimo - a.vl_quitado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }

            return new TCD_Emprestimos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Emprestimos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimos qtb_emp = new TCD_Emprestimos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Buscar Config Emprestimos
                CamadaDados.Financeiro.Cadastros.TList_CfgEmprestimos lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CfgEmprestimos.Buscar(val.Cd_empresa, qtb_emp.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para gravar emprestimos na empresa " + val.Cd_empresa.Trim());
                if (val.Tp_emprestimo.Trim().ToUpper().Equals("C") &&
                    string.IsNullOrEmpty(lCfg[0].Cd_historico_c))
                    throw new Exception("Não existe historico configurado para gravar emprestimos concedidos.");
                if (val.Tp_emprestimo.Trim().ToUpper().Equals("R") &&
                    string.IsNullOrEmpty(lCfg[0].Cd_historico_r))
                    throw new Exception("Não existe historico configurado para gravar emprestimos recebidos.");
                //Gravar Emprestimo
                val.Id_emprestimostr = CamadaDados.TDataQuery.getPubVariavel(qtb_emp.Gravar(val), "@P_ID_EMPRESTIMO");
                if (val.lCheque.Count > 0)
                {
                    val.lCheque.ForEach(p =>
                        {
                            //Gravar Cheque
                            p.St_lancarcaixa = true;
                            p.Observacao = "EMPRESTIMO " + val.Tipo_emprestimo + " Nº " + val.Id_emprestimostr;
                            p.Cd_historico = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? lCfg[0].Cd_historico_c : lCfg[0].Cd_historico_r;
                            CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(p, qtb_emp.Banco_Dados);
                            //Buscar lancamento caixa cheque
                            CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.Buscar(p.Cd_empresa,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    p.Cd_banco,
                                                                                    p.Nr_lanctocheque.ToString(),
                                                                                    qtb_emp.Banco_Dados).ForEach(v =>
                                                                                        //Gravar Emprestimo x Caixa
                                                                                        TCN_Emprestimo_X_Caixa.Gravar(
                                                                                        new TRegistro_Emprestimo_X_Caixa()
                                                                                        {
                                                                                            Cd_empresa = val.Cd_empresa,
                                                                                            Cd_contager = val.Cd_contager,
                                                                                            Cd_lanctocaixa = v.Cd_lanctocaixa,
                                                                                            Id_emprestimo = val.Id_emprestimo,
                                                                                            Tp_lancto = "O",
                                                                                            Cd_portador = val.Cd_portador
                                                                                        }, qtb_emp.Banco_Dados));
                        });
                }
                else
                {
                    //Gravar Caixa
                    string caixa = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                                    {
                                        Cd_Empresa = val.Cd_empresa,
                                        Cd_ContaGer = val.Cd_contager,
                                        Cd_Historico = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? lCfg[0].Cd_historico_c : lCfg[0].Cd_historico_r,
                                        ComplHistorico = "EMPRESTIMO " + val.Tipo_emprestimo + " Nº " + val.Id_emprestimostr,
                                        Dt_lancto = val.Dt_emprestimo,
                                        Nr_Docto = "EMP" + val.Id_emprestimostr,
                                        Login = Utils.Parametros.pubLogin,
                                        St_Estorno = "N",
                                        St_Titulo = "N",
                                        Vl_PAGAR = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? val.Vl_emprestimo : decimal.Zero,
                                        Vl_RECEBER = val.Tp_emprestimo.Trim().ToUpper().Equals("R") ? val.Vl_emprestimo : decimal.Zero
                                    }, qtb_emp.Banco_Dados);
                    //Gravar Emprestimo X Caixa
                    TCN_Emprestimo_X_Caixa.Gravar(new TRegistro_Emprestimo_X_Caixa()
                    {
                        Cd_empresa = val.Cd_empresa,
                        Cd_contager = val.Cd_contager,
                        Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(caixa, "@P_CD_LANCTOCAIXA")),
                        Id_emprestimo = val.Id_emprestimo,
                        Tp_lancto = "O",
                        Cd_portador = val.Cd_portador
                    }, qtb_emp.Banco_Dados);
                }
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         val.Cd_empresa,
                                                                         qtb_emp.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    if(val.Tp_emprestimo.Trim().ToUpper().Equals("C") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_c)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_c,
                                Vl_lancto = val.Vl_emprestimo,
                                Dt_lancto = val.Dt_emprestimo
                            }, qtb_emp.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Emprestimos_X_CCusto.Gravar(new TRegistro_Emprestimos_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_ccustolan = decimal.Parse(id_lan),
                            Id_emprestimo = val.Id_emprestimo
                        }, qtb_emp.Banco_Dados);
                    }
                    else if (val.Tp_emprestimo.Trim().ToUpper().Equals("R") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_r)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_r,
                                Vl_lancto = val.Vl_emprestimo,
                                Dt_lancto = val.Dt_emprestimo
                            }, qtb_emp.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Emprestimos_X_CCusto.Gravar(new TRegistro_Emprestimos_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_ccustolan = decimal.Parse(id_lan),
                            Id_emprestimo = val.Id_emprestimo
                        }, qtb_emp.Banco_Dados);
                    }
                }
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return val.Id_emprestimostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Emprestimos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimos qtb_emp = new TCD_Emprestimos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Cancelar emprestimo
                val.St_registro = "C";
                qtb_emp.Gravar(val);
                //Cancelar lancamentos de caixa
                val.lCaixa.ForEach(p => CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.EstornarCaixa(p, null, qtb_emp.Banco_Dados));
                //Cancelar Centro Resultado
                TCN_Emprestimos_X_CCusto.Buscar(val.Id_emprestimostr,
                                                val.Cd_empresa,
                                                string.Empty,
                                                qtb_emp.Banco_Dados).ForEach(p =>
                                                    {
                                                        //Excluir emprestimo x ccusto
                                                        TCN_Emprestimos_X_CCusto.Excluir(p, qtb_emp.Banco_Dados);
                                                        //Excluir centro resultado
                                                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Excluir(
                                                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                                            {
                                                                Id_ccustolan = p.Id_ccustolan
                                                            }, qtb_emp.Banco_Dados);
                                                    });
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return val.Id_emprestimostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static void DevolverEmprestimo(TRegistro_Emprestimos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimos qtb_emp = new TCD_Emprestimos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Buscar Config Emprestimos
                CamadaDados.Financeiro.Cadastros.TList_CfgEmprestimos lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CfgEmprestimos.Buscar(val.Cd_empresa, qtb_emp.Banco_Dados);
                if (lCfg.Count.Equals(0))
                    throw new Exception("Não existe configuração para gravar emprestimos na empresa " + val.Cd_empresa.Trim());
                if (val.Tp_emprestimo.Trim().ToUpper().Equals("C") &&
                    string.IsNullOrEmpty(lCfg[0].Cd_historico_dev_c))
                    throw new Exception("Não existe historico configurado para devolver emprestimos concedidos.");
                if (val.Tp_emprestimo.Trim().ToUpper().Equals("R") &&
                    string.IsNullOrEmpty(lCfg[0].Cd_historico_dev_r))
                    throw new Exception("Não existe historico configurado para devolver emprestimos recebidos.");
                if (val.lCheque.Count > 0)
                {
                    val.lCheque.ForEach(p =>
                    {
                        //Gravar Cheque
                        p.St_lancarcaixa = true;
                        p.Observacao = "DEVOLUCAO EMPRESTIMO Nº" + val.Id_emprestimostr;
                        p.Cd_historico = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? lCfg[0].Cd_historico_dev_c : lCfg[0].Cd_historico_dev_r;
                        CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(p, qtb_emp.Banco_Dados);
                        //Buscar lancamento caixa cheque
                        CamadaNegocio.Financeiro.Titulo.TCN_TituloXCaixa.Buscar(p.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                p.Cd_banco,
                                                                                p.Nr_lanctocheque.ToString(),
                                                                                qtb_emp.Banco_Dados).ForEach(v =>
                                                                                    //Gravar Emprestimo x Caixa
                                                                                    TCN_Emprestimo_X_Caixa.Gravar(
                                                                                    new TRegistro_Emprestimo_X_Caixa()
                                                                                    {
                                                                                        Cd_empresa = val.Cd_empresa,
                                                                                        Cd_contager = val.Cd_contager_dev,
                                                                                        Cd_lanctocaixa = v.Cd_lanctocaixa,
                                                                                        Id_emprestimo = val.Id_emprestimo,
                                                                                        Tp_lancto = "D",
                                                                                        Cd_portador = val.Cd_portador
                                                                                    }, qtb_emp.Banco_Dados));
                    });
                }
                else
                {
                    //Gravar caixa devolucao
                    string caixa =
                    CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                        new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                        {
                            Cd_Empresa = val.Cd_empresa,
                            Cd_ContaGer = val.Cd_contager_dev,
                            Cd_Historico = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? lCfg[0].Cd_historico_dev_c : lCfg[0].Cd_historico_dev_r,
                            ComplHistorico = "DEVOLUCAO EMPRESTIMO Nº" + val.Id_emprestimostr,
                            Dt_lancto = val.Dt_devolucao,
                            Nr_Docto = "DEVEMP" + val.Id_emprestimostr,
                            Login = Utils.Parametros.pubLogin,
                            St_Estorno = "N",
                            St_Titulo = "N",
                            Vl_PAGAR = val.Tp_emprestimo.Trim().ToUpper().Equals("R") ? val.Vl_devolver : decimal.Zero,
                            Vl_RECEBER = val.Tp_emprestimo.Trim().ToUpper().Equals("C") ? val.Vl_devolver : decimal.Zero
                        }, qtb_emp.Banco_Dados);
                    //Amarrar caixa ao emprestimo
                    TCN_Emprestimo_X_Caixa.Gravar(
                        new TRegistro_Emprestimo_X_Caixa()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_contager = val.Cd_contager_dev,
                            Cd_lanctocaixa = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(caixa, "@P_CD_LANCTOCAIXA")),
                            Id_emprestimo = val.Id_emprestimo,
                            Tp_lancto = "D",
                            Cd_portador = val.Cd_portador
                        }, qtb_emp.Banco_Dados);
                }
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         val.Cd_empresa,
                                                                         qtb_emp.Banco_Dados).Trim().ToUpper().Equals("S"))
                {
                    if (val.Tp_emprestimo.Trim().ToUpper().Equals("C") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_dev_c)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_dev_c,
                                Vl_lancto = val.Vl_devolver,
                                Dt_lancto = val.Dt_devolucao
                            }, qtb_emp.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Emprestimos_X_CCusto.Gravar(new TRegistro_Emprestimos_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_ccustolan = decimal.Parse(id_lan),
                            Id_emprestimo = val.Id_emprestimo
                        }, qtb_emp.Banco_Dados);
                    }
                    else if (val.Tp_emprestimo.Trim().ToUpper().Equals("R") &&
                        (!string.IsNullOrEmpty(lCfg[0].Cd_centroresult_dev_r)))
                    {
                        string id_lan =
                        CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(
                            new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                            {
                                Cd_empresa = val.Cd_empresa,
                                Cd_centroresult = lCfg[0].Cd_centroresult_dev_r,
                                Vl_lancto = val.Vl_devolver,
                                Dt_lancto = val.Dt_devolucao
                            }, qtb_emp.Banco_Dados);
                        //Gravar Emprestimo X CCusto
                        TCN_Emprestimos_X_CCusto.Gravar(new TRegistro_Emprestimos_X_CCusto()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Id_ccustolan = decimal.Parse(id_lan),
                            Id_emprestimo = val.Id_emprestimo
                        }, qtb_emp.Banco_Dados);
                    }
                }
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Emprestimo x Caixa
    public class TCN_Emprestimo_X_Caixa
    {
        public static TList_Emprestimo_X_Caixa Buscar(string Id_emprestimo,
                                                      string Cd_empresa,
                                                      string Cd_contager,
                                                      string Cd_lanctocaixa,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_emprestimo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_emprestimo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_emprestimo;
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
            return new TCD_Emprestimo_X_Caixa(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Financeiro.Caixa.TList_LanCaixa BuscarCaixa(string Id_emprestimo,
                                                                              string Cd_empresa,
                                                                              BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Financeiro.Caixa.TCD_LanCaixa(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_emprestimo_x_caixa x " +
                                    "where x.cd_contager = a.cd_contager " +
                                    "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_emprestimo = " + Id_emprestimo + ")"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Emprestimo_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimo_X_Caixa qtb_emp = new TCD_Emprestimo_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                string retorno = qtb_emp.Gravar(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar caixa emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Emprestimo_X_Caixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimo_X_Caixa qtb_emp = new TCD_Emprestimo_X_Caixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                qtb_emp.Excluir(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro exclui caixa emprestimo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Emprestimos X Centro Resultado
    public class TCN_Emprestimos_X_CCusto
    {
        public static TList_Emprestimos_X_CCusto Buscar(string Id_emprestimo,
                                                        string Cd_empresa,
                                                        string Id_ccustolan,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_emprestimo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_emprestimo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_emprestimo;
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
            return new TCD_Emprestimos_X_CCusto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Emprestimos_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimos_X_CCusto qtb_custo = new TCD_Emprestimos_X_CCusto();
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

        public static string Excluir(TRegistro_Emprestimos_X_CCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Emprestimos_X_CCusto qtb_custo = new TCD_Emprestimos_X_CCusto();
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
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
