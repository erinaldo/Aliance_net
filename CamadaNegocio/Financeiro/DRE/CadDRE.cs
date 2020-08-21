using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Financeiro.DRE
{
    #region DRE
    public class TCN_DRE
    {
        public static CamadaDados.Financeiro.DRE.TList_DRE Buscar(string id_dre,
                                                  string ds_dre,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_dre))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_dre";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_dre;
            }
            if (!string.IsNullOrEmpty(ds_dre))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_dre";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_dre.Trim() + "%')";
            }
            return new CamadaDados.Financeiro.DRE.TCD_DRE(banco).Select(filtro, 0, string.Empty, "a.id_dre asc");
        }

        public static string Gravar(CamadaDados.Financeiro.DRE.TRegistro_DRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_DRE qtb_plan = new CamadaDados.Financeiro.DRE.TCD_DRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                string retorno = qtb_plan.Grava(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Financeiro.DRE.TRegistro_DRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_DRE qtb_plan = new CamadaDados.Financeiro.DRE.TCD_DRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                //Excluir
                val.lParamDre.ForEach(p => TCN_paramDRE.Excluir(p, qtb_plan.Banco_Dados));
                qtb_plan.Deleta(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

    }
    #endregion

    #region paramDRE
    public class TCN_paramDRE
    {

        public static CamadaDados.Financeiro.DRE.TList_paramDRE Buscar(string id_dre,
                                                                              string id_param,
                                                                              string ds_param,
                                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_dre))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_dre";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_dre;
            }
            if (!string.IsNullOrEmpty(id_param))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_param";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_param;
            }
            if (!string.IsNullOrEmpty(ds_param))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_param";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_param.Trim() + "%')";
            }
            return new CamadaDados.Financeiro.DRE.TCD_paramDRE(banco).Select(filtro, 0, string.Empty, "a.classificacao asc");
        }

        public static string Gravar(CamadaDados.Financeiro.DRE.TRegistro_paramDRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_paramDRE qtb_plan = new CamadaDados.Financeiro.DRE.TCD_paramDRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                string retorno = qtb_plan.Grava(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Financeiro.DRE.TRegistro_paramDRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_paramDRE qtb_plan = new CamadaDados.Financeiro.DRE.TCD_paramDRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                //Excluir
                val.lparamConta.ForEach(p => TCN_PARAM_X_HISTORICO.Excluir(p, qtb_plan.Banco_Dados));
                qtb_plan.Deleta(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

    }
    #endregion

    #region PARAM_X_CONTACTB
    public class TCN_PARAM_X_HISTORICO
    {

        public static CamadaDados.Financeiro.DRE.TList_param_x_Historico Buscar(string id_dre,
                                                  string id_param,
                                                  string cd_conta_ctb,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_dre))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_dre";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_dre;
            }
            if (!string.IsNullOrEmpty(id_param))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_param";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_param;
            }
            if (!string.IsNullOrEmpty(cd_conta_ctb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_conta_ctb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = cd_conta_ctb;
            }
            return new CamadaDados.Financeiro.DRE.TCD_param_x_Historico(banco).Select(filtro, 0, string.Empty, "a.cd_historico asc");
        }

        public static string Gravar(CamadaDados.Financeiro.DRE.TRegistro_param_x_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_param_x_Historico qtb_plan = new CamadaDados.Financeiro.DRE.TCD_param_x_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                string retorno = qtb_plan.Grava(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Financeiro.DRE.TRegistro_param_x_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.DRE.TCD_param_x_Historico qtb_plan = new CamadaDados.Financeiro.DRE.TCD_param_x_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                qtb_plan.Deleta(val);
                if (st_transacao)
                    qtb_plan.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plan.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plan.deletarBanco_Dados();
            }
        }

    }
    #endregion
}
