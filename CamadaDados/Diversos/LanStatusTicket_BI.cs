using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_StatusTicket_BI : List<TRegistro_StatusTicket_BI>
    { }

    public class TRegistro_StatusTicket_BI
    {
        private decimal? id_ticket;
        public decimal? Id_ticket
        {
            get { return id_ticket; }
            set
            {
                id_ticket = value;
                id_ticketstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticketstr;
        public string Id_ticketstr
        {
            get { return id_ticketstr; }
            set
            {
                id_ticketstr = value;
                try
                {
                    id_ticket = decimal.Parse(value);
                }
                catch
                { id_ticket = null; }
            }
        }
        public string Login_BI
        { get; set; }
        private DateTime? dt_etapa;
        public DateTime? Dt_etapa
        {
            get { return dt_etapa; }
            set
            {
                dt_etapa = value;
                dt_etapastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_etapastr;
        public string Dt_etapastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_etapastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_etapastr = value;
                try
                {
                    dt_etapa = DateTime.Parse(value);
                }
                catch
                { dt_etapa = null; }
            }
        }

        public TRegistro_StatusTicket_BI()
        {
            this.id_ticket = null;
            this.id_ticketstr = string.Empty;
            this.Login_BI = string.Empty;
            this.dt_etapa = null;
            this.dt_etapastr = string.Empty;
        }
    }

    public class TCD_StatusTicket_BI : TDataQuery
    {
        public TCD_StatusTicket_BI()
        { }

        public TCD_StatusTicket_BI(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_ticket, a.login_BI, a.dt_etapa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_StatusTicket_BI a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_StatusTicket_BI Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_StatusTicket_BI lista = new TList_StatusTicket_BI();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_StatusTicket_BI reg = new TRegistro_StatusTicket_BI();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_BI"))))
                        reg.Login_BI = reader.GetString(reader.GetOrdinal("Login_BI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Etapa")))
                        reg.Dt_etapa = reader.GetDateTime(reader.GetOrdinal("DT_Etapa"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_StatusTicket_BI val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_LOGIN_BI", val.Login_BI);
            hs.Add("@P_DT_ETAPA", val.Dt_etapa);

            return this.executarProc("IA_DIV_STATUSTICKET_BI", hs);
        }

        public string Excluir(TRegistro_StatusTicket_BI val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TICKET", val.Id_ticket);

            return this.executarProc("EXCLUI_DIV_STATUSTICKET_BI", hs);
        }
    }
}
