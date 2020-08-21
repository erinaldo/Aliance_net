using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Empreendimento;

namespace CamadaNegocio.Financeiro.Empreendimento
{
    #region "Classe Empreendimento"
    public class TCN_Empreendimento
    {
        public static TList_Empreendimento Buscar(string Id_empreendimento,
                                                  string Cd_empresa,
                                                  string Ds_empreendimento,
                                                  string Ds_observacao,
                                                  string Tp_data,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  int vTop,
                                                  string vNm_campo,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_empreendimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_empreendimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_empreendimento;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (Ds_empreendimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_empreendimento";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_empreendimento.Trim() + "%')";
            }
            if (Ds_observacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_observacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_observacao.Trim() + "%')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = (Tp_data.Trim().Equals("I") ? "a.dt_iniempreendimento" : "a.dt_encerramento");
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = (Tp_data.Trim().Equals("I") ? "a.dt_iniempreendimento" : "a.dt_encerramento");
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            return new TCD_Empreendimento(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarEmpreendimento(TRegistro_Empreendimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento qtb_emp = new TCD_Empreendimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                string retorno = qtb_emp.GravarEmpreendimento(val);
                val.Id_empreendimento = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_EMPREENDIMENTO"));
                //Deletar centro resultado
                val.lCResultadoDel.ForEach(p => TCN_Empreendimento_X_CResultado.DeletarEmpreendimento_X_CResultado(
                    new TRegistro_Empreendimento_X_CResultado()
                    {
                        Cd_grupocf = p.Cd_grupocf,
                        Id_empreendimento = val.Id_empreendimento
                    }, qtb_emp.Banco_Dados));
                //Gravar centro resultado
                val.lCResultado.ForEach(p => TCN_Empreendimento_X_CResultado.GravarEmpreendimento_X_CResultado(
                    new TRegistro_Empreendimento_X_CResultado()
                    {
                        Cd_grupocf = p.Cd_grupocf,
                        Id_empreendimento = val.Id_empreendimento
                    }, qtb_emp.Banco_Dados));
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string DeletarEmpreendimento(TRegistro_Empreendimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento qtb_emp = new TCD_Empreendimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Verificar se o empreendimento possui movimentacao
                object obj = new CamadaDados.Financeiro.Empreendimento.TCD_Empreendimento_X_LnCCusto().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_empreendimento",
                            vOperador = "=",
                            vVL_Busca = val.Id_empreendimento.Value.ToString()
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_ccustolancto x "+
                                        "inner join tb_fin_duplicata_x_ccusto y "+
                                        "on x.id_ccustolan = y.id_ccustolan "+
                                        "inner join tb_fin_duplicata z "+
                                        "on y.cd_empresa = z.cd_empresa "+
                                        "and y.nr_lancto = z.nr_lancto "+
                                        "where x.id_ccustolan = a.id_ccustolan "+
                                        "and isnull(z.st_registro, 'A') <> 'C')"
                        }
                    }, "1");
                bool st_excluir = true;
                if (obj != null)
                    if (obj.ToString().Trim().Equals("1"))
                        st_excluir = false;
                if (st_excluir)
                    //Deletar empreendimento
                    qtb_emp.DeletarEmpreendimento(val);
                else
                {
                    val.St_registro = "C";
                    GravarEmpreendimento(val, qtb_emp.Banco_Dados);
                }
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Empreendimento X CResultado"
    public class TCN_Empreendimento_X_CResultado
    {
        public static TList_Empreendimento_X_CResultado Buscar(string Id_empreendimento,
                                                               string Cd_grupocf,
                                                               int vTop,
                                                               string vNm_campo,
                                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_empreendimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_empreendimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_empreendimento;
            }
            if (Cd_grupocf.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupocf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupocf.Trim() + "'";
            }
            return new TCD_Empreendimento_X_CResultado(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF BuscarCResultado(string Id_empreendimento,
                                                                                         BancoDados.TObjetoBanco banco)
        {
            if (Id_empreendimento.Trim() != string.Empty)
                return new CamadaDados.Financeiro.Cadastros.TCD_CadGrupoCF(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_empreendimento_x_cresultado x "+
                                        "where x.cd_grupocf = a.cd_grupocf "+
                                        "and x.id_empreendimento = "+Id_empreendimento+")" 
                        }
                    }, 0, string.Empty);
            else
                return new CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF();
        }

        public static string GravarEmpreendimento_X_CResultado(TRegistro_Empreendimento_X_CResultado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento_X_CResultado qtb_emp = new TCD_Empreendimento_X_CResultado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Gravar empreendimento x ccusto
                string retorno = qtb_emp.GravarEmpreendimento_X_CResultado(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar centro custo empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string DeletarEmpreendimento_X_CResultado(TRegistro_Empreendimento_X_CResultado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento_X_CResultado qtb_emp = new TCD_Empreendimento_X_CResultado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Deletar empreendimento x ccusto
                qtb_emp.DeletarEmpreendimento_X_CResultado(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir centro custo empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Empreendimento X LanCCusto"
    public class TCN_Empreendimento_X_LanCCusto
    {
        public static TList_Empreendimento_X_LanCCusto Buscar(string Id_empreendimento,
                                                              string Id_ccustolan,
                                                              int vTop,
                                                              string vNm_campo,
                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_empreendimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_empreendimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_empreendimento;
            }
            if (Id_ccustolan.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ccustolan";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Id_ccustolan.Trim() + "'";
            }
            return new TCD_Empreendimento_X_LnCCusto(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto BuscarCResultado(string Id_empreendimento,
                                                                                              BancoDados.TObjetoBanco banco)
        {
            if (Id_empreendimento.Trim() != string.Empty)
                return new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_empreendimento_x_lanccusto x "+
                                        "where x.id_ccustolan = a.id_ccustolan "+
                                        "and x.id_empreendimento = "+Id_empreendimento+")"
                        }
                    }, 0, string.Empty);
            else
                return new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }

        public static string GravarEmpreendimentoLanCCusto(TRegistro_Empreendimento_X_lanCCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento_X_LnCCusto qtb_emp = new TCD_Empreendimento_X_LnCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_emp.GravarEmpreendimento_X_LanCCusto(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar custo empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string ExcluirEmpreendimentoLanCCusto(TRegistro_Empreendimento_X_lanCCusto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Empreendimento_X_LnCCusto qtb_emp = new TCD_Empreendimento_X_LnCCusto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                //Excluir registro
                qtb_emp.DeletarEmpreendimento_X_LanCCusto(val);
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir custo empreendimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region "Classe Resultado Empreendimento"
    public class TCN_ResultadoEmpreendimento
    {
        public static TList_ResultadoEmpreendimento Buscar(string Id_empreendimento)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_empreendimento.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "emp.id_empreendimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Id_empreendimento + ")";
            }
            return new TCD_ResultadoEmpreendimento().Select(filtro);
        }
    }
    #endregion
}
