using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_CfgContrato
    {
        public static TList_CfgContrato Buscar(string cd_empresa,
                                               string cd_condpgto,
                                               string tp_docto,
                                               string tp_duplicata,
                                               string cd_historico,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_condpgto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_condpgto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(tp_docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = tp_docto;
            }
            if (!string.IsNullOrEmpty(tp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_historico.Trim() + "'";
            }
            return new TCD_CfgContrato(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgContrato qtb_cfg = new TCD_CfgContrato();
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
                throw new Exception("Erro gravar config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CfgContrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgContrato qtb_cfg = new TCD_CfgContrato();
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
                throw new Exception("Erro excluir config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
