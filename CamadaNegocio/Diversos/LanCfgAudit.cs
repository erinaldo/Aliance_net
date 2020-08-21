using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CfgAudit
    {
        public static TList_CfgAudit Buscar(string Id_config,
                                            string Nm_tabela,
                                            string St_update,
                                            string St_delete,
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
            if (!string.IsNullOrEmpty(Nm_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_tabela";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_tabela.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(St_update))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_update, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_update.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_delete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_delete, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_delete.Trim() + "'";
            }
            return new TCD_CfgAudit(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgAudit val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgAudit qtb_cfg = new TCD_CfgAudit();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                val.Id_configstr = CamadaDados.TDataQuery.getPubVariavel(qtb_cfg.Gravar(val), "@P_ID_CONFIG");
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgAudit val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgAudit qtb_cfg = new TCD_CfgAudit();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Id_configstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
