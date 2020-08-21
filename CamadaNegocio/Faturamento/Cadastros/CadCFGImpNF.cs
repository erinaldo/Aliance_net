using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CFGImpNF
    {
        public static CamadaDados.Faturamento.Cadastros.TList_CFGImpNF Buscar(string Nr_serie,
                                                                              string Cd_modelo,
                                                                              string Cd_empresa,
                                                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_serie.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_modelo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_modelo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_modelo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarCFGImpNF(CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF qtb_cfg = new CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.GravarCFGImpNF(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string ExcluirCFGImpNF(CamadaDados.Faturamento.Cadastros.TRegistro_CFGImpNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF qtb_cfg = new CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.ExcluirCFGImpNF(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
