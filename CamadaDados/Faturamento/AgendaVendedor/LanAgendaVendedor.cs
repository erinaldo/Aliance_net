using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.AgendaVendedor
{
    public class TList_AgendaVendedor : List<TRegistro_AgendaVendedor>, IComparer<TRegistro_AgendaVendedor>
    {
        #region IComparer<TRegistro_CRMOrcamento> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_AgendaVendedor()
        { }

        public TList_AgendaVendedor(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AgendaVendedor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AgendaVendedor x, TRegistro_AgendaVendedor y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    public class TRegistro_AgendaVendedor
    {
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public string Cd_clifor { get; set; } = string.Empty;
        public string Nm_clifor { get; set; } = string.Empty;
        public string Login
        { get; set; }
        public string Ds_historico
        { get; set; }
        private DateTime? dt_contato;
        public DateTime? Dt_contato
        {
            get { return dt_contato; }
            set
            {
                dt_contato = value;
                dt_contatostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_contatostr;
        public string Dt_contatostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_contatostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_contatostr = value;
                try
                {
                    dt_contato = DateTime.Parse(value);
                }
                catch { dt_contato = null; }
            }
        }
        private DateTime? dt_agendamento;
        public DateTime? Dt_agendamento
        {
            get { return dt_agendamento; }
            set
            {
                dt_agendamento = value;
                dt_agendamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_agendamentostr;
        public string Dt_agendamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_agendamentostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_agendamentostr = value;
                try
                {
                    dt_agendamento = DateTime.Parse(value);
                }
                catch { dt_agendamento = null; }
            }
        }
        private TimeSpan? hr_agendamento;
        public TimeSpan? Hr_agendamento
        {
            get { return hr_agendamento; }
            set
            {
                hr_agendamento = value;
                hr_agendamentostr = value.HasValue ? new DateTime(value.Value.Ticks).ToString("HH:mm") : string.Empty;
            }
        }
        private string hr_agendamentostr;
        public string Hr_agendamentostr
        {
            get { return hr_agendamentostr; }
            set
            {
                hr_agendamentostr = value;
                try
                {
                    hr_agendamento = TimeSpan.Parse(value);
                }
                catch { hr_agendamento = null; }
            }
        }
        public string Nm_contato
        { get; set; }
        public string Fone_contato
        { get; set; }
        private string st_registro = "0";
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().Equals("0"))
                    status = "ABERTO";
                else if (value.Trim().Equals("1"))
                    status = "CONCLUIDO";
                else if (value.Trim().Equals("2"))
                    status = "CANCELADO";
            }
        }
        private string status = "ABERTO";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().Equals("ABERTO"))
                    st_registro = "0";
                else if (value.Trim().ToUpper().Equals("CONCLUIDO"))
                    st_registro = "1";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "2";
            }
        }

        public TRegistro_AgendaVendedor()
        {
            id_registro = null;
            id_registrostr = string.Empty;
            Login = string.Empty;
            Ds_historico = string.Empty;
            dt_contato = null;
            dt_contatostr = string.Empty;
            dt_agendamento = null;
            dt_agendamentostr = string.Empty;
            hr_agendamento = null;
            hr_agendamentostr = string.Empty;
            Nm_contato = string.Empty;
            Fone_contato = string.Empty;
        }
    }

    public class TCD_AgendaVendedor : TDataQuery
    {
        public TCD_AgendaVendedor() { }

        public TCD_AgendaVendedor(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Registro, a.Cd_Clifor, isnull(a.nm_clifor, b.NM_Clifor) as nm_clifor, ");
                sql.AppendLine("a.Login, a.DS_Historico, a.DT_Contato, a.DT_Agendamento, a.HR_Agendamento, ");
                sql.AppendLine("a.NM_Contato, a.Fone_Contato, a.St_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_AgendaVendedor a ");
            sql.AppendLine("left outer join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_agendamento desc, a.hr_agendamento desc ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AgendaVendedor Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_AgendaVendedor lista = new TList_AgendaVendedor();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AgendaVendedor reg = new TRegistro_AgendaVendedor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_registro"))))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_historico"))))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_contato")))
                        reg.Dt_contato = reader.GetDateTime(reader.GetOrdinal("dt_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_agendamento")))
                        reg.Dt_agendamento = reader.GetDateTime(reader.GetOrdinal("dt_agendamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("hr_agendamento")))
                        reg.Hr_agendamento = reader.GetTimeSpan(reader.GetOrdinal("hr_agendamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_contato")))
                        reg.Nm_contato = reader.GetString(reader.GetOrdinal("nm_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_contato")))
                        reg.Fone_contato = reader.GetString(reader.GetOrdinal("fone_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_AgendaVendedor val)
        {
            Hashtable hs = new Hashtable(11);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_HISTORICO", val.Ds_historico);
            hs.Add("@P_DT_CONTATO", val.Dt_contato);
            hs.Add("@P_DT_AGENDAMENTO", val.Dt_agendamento);
            hs.Add("@P_HR_AGENDAMENTO", val.Hr_agendamento);
            hs.Add("@P_NM_CONTATO", val.Nm_contato);
            hs.Add("@P_FONE_CONTATO", val.Fone_contato);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_AGENDAVENDEDOR", hs);
        }

        public string Excluir(TRegistro_AgendaVendedor val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);

            return executarProc("EXCLUI_FAT_AGENDAVENDEDOR", hs);
        }
    }
}
