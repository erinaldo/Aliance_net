using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadMoeda
    {
        public static TList_Moeda Buscar(string Cd_moeda,
                                         string Ds_moeda_singular,
                                         string Ds_moeda_plural,
                                         string Sigla,
                                         int vTop,
                                         string vNm_campo,
                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_moeda_plural))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_moeda_plural";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_moeda_plural.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Ds_moeda_singular))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_moeda_singular";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_moeda_singular.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Sigla))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.sigla";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Sigla.Trim() + "'";
            }
            return new TCD_Moeda(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarMoeda(TRegistro_Moeda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Moeda qtb_moeda = new TCD_Moeda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_moeda.CriarBanco_Dados(true);
                else
                    qtb_moeda.Banco_Dados = banco;
                string retorno = qtb_moeda.GravarMoeda(val);
                if (st_transacao)
                    qtb_moeda.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_moeda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar moeda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_moeda.deletarBanco_Dados();
            }
        }

        public static string DeletarMoeda(TRegistro_Moeda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Moeda qtb_moeda = new TCD_Moeda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_moeda.CriarBanco_Dados(true);
                else
                    qtb_moeda.Banco_Dados = banco;
                qtb_moeda.DeletarMoeda(val);
                if (st_transacao)
                    qtb_moeda.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_moeda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir moeda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_moeda.deletarBanco_Dados();
            }
        }
    }
}
