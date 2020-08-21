using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CFGFaturaCartao
    {
        public static CamadaDados.Financeiro.Cadastros.TList_CFGFaturaCartao Buscar(string Cd_empresa,
                                                                                    string Cd_historico_rec,
                                                                                    string Cd_historico_pag,
                                                                                    string Cd_historico_juro,
                                                                                    string Cd_historico_taxa,
                                                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico_rec))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_rec";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_rec.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico_pag))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_pag";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_pag.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico_juro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_juro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_juro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_historico_taxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_taxa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_taxa.Trim() + "'";
            }

            return new CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Financeiro.Cadastros.TRegistro_CFGFaturaCartao val,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao qtb_cfg = new CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao();
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

        public static string Excluir(CamadaDados.Financeiro.Cadastros.TRegistro_CFGFaturaCartao val,
                                     BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao qtb_cfg = new CamadaDados.Financeiro.Cadastros.TCD_CFGFaturaCartao();
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
