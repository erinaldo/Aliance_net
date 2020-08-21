using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Contabil.Cadastro
{
    #region CTB_DRE
    public class TCN_CTB_DRE
    {
        public static CamadaDados.Contabil.Cadastro.TList_CTB_DRE Buscar(string id_dre,
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
            return new CamadaDados.Contabil.Cadastro.TCD_CTD_DRE(banco).Select(filtro, 0, string.Empty, "a.id_dre asc");
        }

        public static string Gravar(CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTD_DRE qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTD_DRE();
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

        public static string Excluir(CamadaDados.Contabil.Cadastro.TRegistro_CTB_DRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTD_DRE qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTD_DRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                //Excluir
                val.lParamDre.ForEach(p=> TCN_CTB_paramDRE.Excluir(p, qtb_plan.Banco_Dados));
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

    #region CTB_paramDRE
    public class TCN_CTB_paramDRE
    {

        public static CamadaDados.Contabil.Cadastro.TList_CTB_paramDRE Buscar(string id_dre,
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
            return new CamadaDados.Contabil.Cadastro.TCD_CTD_paramDRE(banco).Select(filtro, 0, string.Empty, "a.classificacao asc");
        }

        public static string Gravar(CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTD_paramDRE qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTD_paramDRE();
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

        public static string Excluir(CamadaDados.Contabil.Cadastro.TRegistro_CTB_paramDRE val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTD_paramDRE qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTD_paramDRE();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plan.CriarBanco_Dados(true);
                else
                    qtb_plan.Banco_Dados = banco;
                //Excluir
                val.lparamConta.ForEach(p => TCN_CTB_PARAM_X_CONTACTB.Excluir(p, qtb_plan.Banco_Dados));
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

    #region CTB_PARAM_X_CONTACTB
    public class TCN_CTB_PARAM_X_CONTACTB
    {

        public static CamadaDados.Contabil.Cadastro.TList_CTB_param_x_contaCTB Buscar(string id_dre,
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
            return new CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB(banco).Select(filtro, 0, string.Empty, "a.cd_conta_ctb asc");
        }

        public static string Gravar(CamadaDados.Contabil.Cadastro.TRegistro_CTB_param_x_contaCTB val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB();
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

        public static string Excluir(CamadaDados.Contabil.Cadastro.TRegistro_CTB_param_x_contaCTB val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB qtb_plan = new CamadaDados.Contabil.Cadastro.TCD_CTB_param_x_contaCTB();
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
