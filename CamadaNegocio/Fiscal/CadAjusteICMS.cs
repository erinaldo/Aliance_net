using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_AjusteICMS
    {
        public static TList_AjusteICMS Buscar(string Cd_ajuste,
                                              string Cd_imposto,
                                              string Ds_ajuste,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_ajuste))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_ajuste";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_ajuste.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Ds_ajuste))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_ajuste";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_ajuste.Trim() + "%')";
            }
            return new TCD_AjusteICMS(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AjusteICMS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjusteICMS qtb_ajuste = new TCD_AjusteICMS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajuste.CriarBanco_Dados(true);
                else
                    qtb_ajuste.Banco_Dados = banco;
                val.Cd_ajuste = CamadaDados.TDataQuery.getPubVariavel(qtb_ajuste.Gravar(val), "@P_CD_AJUSTE");
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.Commit_Tran();
                return val.Cd_ajuste;
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

        public static string Excluir(TRegistro_AjusteICMS val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AjusteICMS qtb_ajuste = new TCD_AjusteICMS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ajuste.CriarBanco_Dados(true);
                else
                    qtb_ajuste.Banco_Dados = banco;
                qtb_ajuste.Excluir(val);
                if (st_transacao)
                    qtb_ajuste.Banco_Dados.Commit_Tran();
                return val.Cd_ajuste;
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
