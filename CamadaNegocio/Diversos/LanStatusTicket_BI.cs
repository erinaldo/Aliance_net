using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_StatusTicket_BI
    {
        public static TList_StatusTicket_BI Buscar(string Id_ticket,
                                                   string Login_BI,
                                                   string Dt_ini,
                                                   string Dt_fin,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Login_BI))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login_BI";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login_BI.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_etapa)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_etapa)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd HH:mm:ss") + "'";
            }
            return new TCD_StatusTicket_BI(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_StatusTicket_BI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_StatusTicket_BI qtb_status = new TCD_StatusTicket_BI();
            try
            {
                if (banco == null)
                    st_transacao = qtb_status.CriarBanco_Dados(true);
                else
                    qtb_status.Banco_Dados = banco;
                qtb_status.Gravar(val);
                if (st_transacao)
                    qtb_status.Banco_Dados.Commit_Tran();
                return val.Id_ticketstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_status.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar status ticket: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_status.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_StatusTicket_BI val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_StatusTicket_BI qtb_status = new TCD_StatusTicket_BI();
            try
            {
                if (banco == null)
                    st_transacao = qtb_status.CriarBanco_Dados(true);
                else
                    qtb_status.Banco_Dados = banco;
                qtb_status.Excluir(val);
                if (st_transacao)
                    qtb_status.Banco_Dados.Commit_Tran();
                return val.Id_ticketstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_status.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir status ticket: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_status.deletarBanco_Dados();
            }
        }
    }
}
