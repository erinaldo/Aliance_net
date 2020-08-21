using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    #region CfgPainelVendaConv
    public class TCN_CfgPainelVendaConv
    {
        public static TList_CfgPainelVendaConv Buscar(string Id_config,
                                                      string Ds_config,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_config";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_config;
            }
            if (!string.IsNullOrEmpty(Ds_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_config";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_config.Trim() + "%')";
            }
            return new TCD_CfgPainelVendaConv(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgPainelVendaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgPainelVendaConv qtb_cfg = new TCD_CfgPainelVendaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                val.Id_configstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cfg.Gravar(val), "@P_ID_CONFIG");
                val.lGrupoDel.ForEach(p => TCN_CfgPainelVendaConv_X_Grupo.Excluir(p, qtb_cfg.Banco_Dados));
                val.lGrupo.ForEach(p =>
                    {
                        p.Id_config = val.Id_config;
                        TCN_CfgPainelVendaConv_X_Grupo.Gravar(p, qtb_cfg.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgPainelVendaConv val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgPainelVendaConv qtb_cfg = new TCD_CfgPainelVendaConv();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                val.lGrupo.ForEach(p => TCN_CfgPainelVendaConv_X_Grupo.Excluir(p, qtb_cfg.Banco_Dados));
                val.lGrupoDel.ForEach(p => TCN_CfgPainelVendaConv_X_Grupo.Excluir(p, qtb_cfg.Banco_Dados));
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region CfgPainelVendaConv_X_Grupo
    public class TCN_CfgPainelVendaConv_X_Grupo
    {
        public static TList_CfgPainelVendaConv_X_Grupo Buscar(string Id_config,
                                                              string Cd_grupo,
                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_config))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_config";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_config;
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupo.Trim() + "'";
            }
            return new TCD_CfgPainelVendaConv_X_Grupo(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgPainelVendaConv_X_Grupo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgPainelVendaConv_X_Grupo qtb_cfg = new TCD_CfgPainelVendaConv_X_Grupo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar grupo config: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgPainelVendaConv_X_Grupo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgPainelVendaConv_X_Grupo qtb_cfg = new TCD_CfgPainelVendaConv_X_Grupo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir grupo config: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
