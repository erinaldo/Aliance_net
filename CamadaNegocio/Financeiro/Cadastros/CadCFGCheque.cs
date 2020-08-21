using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CFGCheque
    {
        public static TList_CFGCheque Buscar(string Cd_empresa,
                                                 string Cd_historico_desconto,
                                                 string Cd_historico_taxa,
                                                 string Cd_historico_creddesconto,
                                                 string Cd_histdev_chemitidos,
                                                 string Cd_histreap_chemitidos,
                                                 string Cd_contadev_chemitidos,
                                                 string Cd_histdev_chrecebidos,
                                                 string Cd_histreap_chrecebidos,
                                                 string Cd_contadev_chrecebidos,
                                                 int vTop,
                                                 string vNm_campo,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if(Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Cd_historico_desconto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_desconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_desconto.Trim() + "'";
            }
            if (Cd_historico_taxa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_taxa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_taxa.Trim() + "'";
            }
            if (Cd_historico_creddesconto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_creddesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_creddesconto.Trim() + "'";
            }
            if (Cd_histdev_chemitidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_histdev_chemitidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_histdev_chemitidos.Trim() + "'";
            }
            if (Cd_histreap_chemitidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_histreap_chemitidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_histreap_chemitidos.Trim() + "'";
            }
            if (Cd_contadev_chemitidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contadev_chemitidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contadev_chemitidos.Trim() + "'";
            }
            if (Cd_histdev_chrecebidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_histdev_chrecebidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_histdev_chrecebidos.Trim() + "'";
            }
            if (Cd_histreap_chrecebidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_histreap_chrecebidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_histreap_chrecebidos.Trim() + "'";
            }
            if (Cd_contadev_chrecebidos.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contadev_chrecebidos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contadev_chrecebidos.Trim() + "'";
            }

            return new TCD_CFGCheque(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCFGCheque(TRegistro_CFGCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCheque qtb_cfg = new TCD_CFGCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.GravarCFGCheque(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static string DeletarCFGCheque(TRegistro_CFGCheque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCheque qtb_cfg = new TCD_CFGCheque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.DeletarCFGCheque(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
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
