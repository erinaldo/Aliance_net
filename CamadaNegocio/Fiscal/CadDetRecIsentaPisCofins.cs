using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_DetRecIsentaPisCofins
    {
        public static TList_DetRecIsentaPisCofins Buscar(string Id_detrecisenta,
                                                         string Cd_imposto,
                                                         string Cd_st,
                                                         string Ds_detrecisenta,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_detrecisenta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_detrecisenta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_detrecisenta;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Cd_st))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_st";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_st.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_detrecisenta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_detrecisenta";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_detrecisenta.Trim() + "%'";
            }
            return new TCD_DetRecIsentaPisCofins(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DetRecIsentaPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DetRecIsentaPisCofins qtb_det = new TCD_DetRecIsentaPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_det.CriarBanco_Dados(true);
                else
                    qtb_det.Banco_Dados = banco;
                val.Id_detrecisentastr = CamadaDados.TDataQuery.getPubVariavel(qtb_det.Gravar(val), "@P_ID_DETRECISENTA");
                if (st_transacao)
                    qtb_det.Banco_Dados.Commit_Tran();
                return val.Id_detrecisentastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_det.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_det.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DetRecIsentaPisCofins val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DetRecIsentaPisCofins qtb_det = new TCD_DetRecIsentaPisCofins();
            try
            {
                if (banco == null)
                    st_transacao = qtb_det.CriarBanco_Dados(true);
                else
                    qtb_det.Banco_Dados = banco;
                qtb_det.Excluir(val);
                if (st_transacao)
                    qtb_det.Banco_Dados.Commit_Tran();
                return val.Id_detrecisentastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_det.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_det.deletarBanco_Dados();
            }
        }
    }
}
