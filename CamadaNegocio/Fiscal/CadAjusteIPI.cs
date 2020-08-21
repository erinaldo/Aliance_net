using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_AjusteIPI
    {
        public static TList_AjusteIPI Buscar(string Cd_ajusteIPI,
                                             string Cd_imposto,
                                             string Ds_ajusteIPI,
                                             string Tp_natureza,
                                             string Ds_finalidade,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_ajusteIPI))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_ajusteIPI";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_ajusteIPI.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Ds_ajusteIPI))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_ajusteIPI";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_ajusteIPI.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Tp_natureza))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_natureza";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_natureza.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_finalidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_finalidade";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_finalidade.Trim() + "%')";
            }

            return new TCD_AjusteIPI(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AjusteIPI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjusteIPI qtb_ajuste = new TCD_AjusteIPI();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajuste.CriarBanco_Dados(true);
                else
                    qtb_ajuste.Banco_Dados = banco;
                val.Cd_ajusteIPI = CamadaDados.TDataQuery.getPubVariavel(qtb_ajuste.Gravar(val), "@P_CD_AJUSTEIPI");
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.Commit_Tran();
                return val.Cd_ajusteIPI;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ajuste: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ajuste.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AjusteIPI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjusteIPI qtb_ajuste = new TCD_AjusteIPI();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajuste.CriarBanco_Dados(true);
                else
                    qtb_ajuste.Banco_Dados = banco;
                qtb_ajuste.Excluir(val);
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.Commit_Tran();
                return val.Cd_ajusteIPI;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ajuste: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ajuste.deletarBanco_Dados();
            }
        }
    }
}
