using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadHistorico
    {
        public static TList_CadHistorico Buscar(string Cd_historico,
                                                string Tp_mov,
                                                string Ds_historico,
                                                string Cd_historico_quitacao,
                                                string Cd_grupocf,
                                                int vTop,
                                                string vNm_campo)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_mov.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_historico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_historico.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_historico_quitacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico_quitacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico_quitacao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_grupocf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupocf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupocf.Trim() + "'";
            }

            return new TCD_CadHistorico().Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadHistorico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadHistorico qtb_hist = new TCD_CadHistorico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_hist.CriarBanco_Dados(true);
                else
                    qtb_hist.Banco_Dados = banco;
                val.Cd_historico = CamadaDados.TDataQuery.getPubVariavel(qtb_hist.Gravar(val), "@P_CD_HISTORICO");
                if (st_transacao)
                    qtb_hist.Banco_Dados.Commit_Tran();
                return val.Cd_historico;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_hist.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar historico: "  + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_hist.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadHistorico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadHistorico qtb_hist = new TCD_CadHistorico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_hist.CriarBanco_Dados(true);
                else
                    qtb_hist.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_hist.Gravar(val);
                if (st_transacao)
                    qtb_hist.Banco_Dados.Commit_Tran();
                return val.Cd_historico;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_hist.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir historico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_hist.deletarBanco_Dados();
            }
        }
    }
}
