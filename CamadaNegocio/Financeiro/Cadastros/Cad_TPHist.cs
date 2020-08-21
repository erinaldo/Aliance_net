using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_TPHist
    {
        public static TList_TPHist Buscar(string Tp_hist,
                                          string Ds_tphist,
                                          bool St_caixagerencial,
                                          bool St_financeiro,
                                          bool St_quitacoes,
                                          bool St_faturamento,
                                          int vTop,
                                          string vNm_campo,
                                          BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Tp_hist.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "tp_hist";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_hist.Trim() + "'";
            }
            if (Ds_tphist.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ds_tphist";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Ds_tphist.Trim() + "'";
            }
            if (St_caixagerencial)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ST_Caixagerencial";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_financeiro)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ST_Financeiro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_quitacoes)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ST_Quitacoes";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (St_faturamento)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ST_Faturamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            return new TCD_TPHist(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarTpHist(TRegistro_TPHist val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TPHist qtb_hist = new TCD_TPHist();
            try
            {
                if (banco == null)
                {
                    qtb_hist.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_hist.Banco_Dados = banco;
                string retorno = qtb_hist.GravarTPHist(val);
                if (st_transacao)
                    qtb_hist.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_hist.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_hist.deletarBanco_Dados();
            }
        }

        public static string DeletarTPHist(TRegistro_TPHist val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TPHist qtb_hist = new TCD_TPHist();
            try
            {
                if (banco == null)
                {
                    qtb_hist.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_hist.Banco_Dados = banco;
                qtb_hist.DeletarTPHist(val);
                if (st_transacao)
                    qtb_hist.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_hist.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_hist.deletarBanco_Dados();
            }
        }
    }
}
