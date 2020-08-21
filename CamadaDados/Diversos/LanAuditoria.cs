using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TRegistro_Trigger
    {
        public string Nm_tabela
        { get; set; }
        public string Nm_trigger
        { get; set; }
        public bool ST_Enabled
        { get; set; }

        public TRegistro_Trigger()
        {
            this.Nm_tabela = string.Empty;
            this.Nm_trigger = string.Empty;
            this.ST_Enabled = false;
        }
    }

    public class TList_Auditoria : List<TRegistro_Auditoria>, IComparer<TRegistro_Auditoria>
    {
        #region IComparer<TRegistro_Auditoria> Members
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

        public TList_Auditoria()
        { }

        public TList_Auditoria(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Auditoria value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Auditoria x, TRegistro_Auditoria y)
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

    public class TRegistro_Auditoria
    {
        private decimal? id_auditoria;
        public decimal? Id_auditoria
        {
            get { return id_auditoria; }
            set
            {
                id_auditoria = value;
                id_auditoriastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_auditoriastr;
        public string Id_auditoriastr
        {
            get { return id_auditoriastr; }
            set
            {
                id_auditoriastr = value;
                try
                {
                    id_auditoria = decimal.Parse(value);
                }
                catch { id_auditoria = null; }
            }
        }
        public string Login
        { get; set; }
        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_eventostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch { dt_evento = null; }
            }
        }
        public string Nm_tabela
        { get; set; }
        private string tp_evento;
        public string Tp_evento
        {
            get { return tp_evento; }
            set
            {
                tp_evento = value;
                if (value.Trim().ToUpper().Equals("U"))
                    tipo_evento = "UPDATE";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_evento = "DELETE";
            }
        }
        private string tipo_evento;
        public string Tipo_evento
        {
            get { return tipo_evento; }
            set
            {
                tipo_evento = value;
                if (value.Trim().ToUpper().Equals("UPDATE"))
                    tp_evento = "U";
                else if (value.Trim().ToUpper().Equals("DELETE"))
                    tp_evento = "D";
            }
        }
        public string id_chave { get; set; }
        public TList_ColunasAudit lColunas
        { get; set; }

        public TRegistro_Auditoria()
        {
            this.id_auditoria = null;
            this.id_auditoriastr = string.Empty;
            this.Login = string.Empty;
            this.dt_evento = null;
            this.dt_eventostr = string.Empty;
            this.Nm_tabela = string.Empty;
            this.tp_evento = string.Empty;
            this.tipo_evento = string.Empty;
            id_chave = string.Empty;
            this.lColunas = new TList_ColunasAudit();
        }
    }

    public class TCD_Auditoria : TDataQuery
    {
        public TCD_Auditoria() { }

        public TCD_Auditoria(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        public System.Data.DataTable BuscarTabelas()
        {
            return this.ExecutarBusca("select name from sysobjects where xtype = 'U' order by name", null);
        }

        public System.Data.DataTable BuscarColunas(string Tabela)
        {
            return this.ExecutarBusca("SELECT COLUNAS.NAME AS COLUNA, " +
                                      "TIPOS.NAME AS TIPO, " +
                                      "COLUNAS.LENGTH AS TAMANHO, " +
                                      "COLUNAS.ISNULLABLE AS EH_NULO " +
                                      "FROM SYSOBJECTS AS TABELAS, " +
                                      "SYSCOLUMNS AS COLUNAS, " +
                                      "SYSTYPES AS TIPOS " +
                                      "WHERE TABELAS.ID = COLUNAS.ID " +
                                      "AND COLUNAS.USERTYPE = TIPOS.USERTYPE " +
                                      "AND TABELAS.NAME = '" + Tabela.Trim() + "'", null);
        }

        public List<TRegistro_Trigger> BuscarTrigger(string Tabela)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select A.name Nome_Trigger, b.name as NM_Tabela, c.is_disabled ");
            sql.AppendLine("from sysobjects A ");
            sql.AppendLine("join sysobjects B ");
            sql.AppendLine("on A.parent_obj = B.id ");
            sql.AppendLine("join sys.triggers C ");
            sql.AppendLine("on a.id = c.object_id ");
            sql.AppendLine("where A.xtype = 'TR' ");
            if (!string.IsNullOrEmpty(Tabela))
                sql.AppendLine("and B.name = '" + Tabela.Trim() + "'");
            System.Data.DataTable tb_trigger = this.ExecutarBusca(sql.ToString(), null);
            List<TRegistro_Trigger> retorno = new List<TRegistro_Trigger>();
            if (tb_trigger != null)
                if (tb_trigger.Rows.Count > 0)
                    for(int i = 0; i < tb_trigger.Rows.Count; i++)
                        retorno.Add(new TRegistro_Trigger()
                        {
                            Nm_tabela = tb_trigger.Rows[i]["nm_tabela"].ToString(),
                            Nm_trigger = tb_trigger.Rows[i]["nome_trigger"].ToString(),
                            ST_Enabled = !Convert.ToBoolean(tb_trigger.Rows[i]["is_disabled"].ToString())
                        });
            return retorno;
        }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("Select " + strTop + " a.id_auditoria, a.login, a.dt_evento, a.nm_tabela, a.tp_evento, a.id_chave ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_Auditoria a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_Auditoria Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Auditoria lista = new TList_Auditoria();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Auditoria reg = new TRegistro_Auditoria();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_auditoria")))
                            reg.Id_auditoria = reader.GetDecimal(reader.GetOrdinal("id_auditoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("dt_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tabela")))
                        reg.Nm_tabela = reader.GetString(reader.GetOrdinal("nm_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("tp_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_chave")))
                        reg.id_chave = reader.GetString(reader.GetOrdinal("id_chave"));
                    
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
    }

    public class TList_ColunasAudit : List<TRegistro_ColunasAudit>, IComparer<TRegistro_ColunasAudit>
    {
        #region IComparer<TRegistro_ColunasAudit> Members
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

        public TList_ColunasAudit()
        { }

        public TList_ColunasAudit(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ColunasAudit value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ColunasAudit x, TRegistro_ColunasAudit y)
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

    public class TRegistro_ColunasAudit
    {
        private decimal? id_auditoria;
        public decimal? Id_auditoria
        {
            get { return id_auditoria; }
            set
            {
                id_auditoria = value;
                id_auditoriastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_auditoriastr;
        public string Id_auditoriastr
        {
            get { return id_auditoriastr; }
            set
            {
                id_auditoriastr = value;
                try
                {
                    id_auditoria = decimal.Parse(value);
                }
                catch { id_auditoria = null; }
            }
        }
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
        public string Nm_coluna
        { get; set; }
        public string Vl_old
        { get; set; }
        public string Vl_atual
        { get; set; }
        public string login { get; set; }
        public string nm_tabela { get; set; }

        private DateTime? dt_evento { get; set; } = new DateTime();
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eventostr { get; set; } = string.Empty;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_eventostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = Convert.ToDateTime(value);
                }
                catch
                { dt_evento = null; }
            }
        }

        public string ds_coluna { get; set; }
        public string id_chave { get; set; }
        public string id_orcamento
        {
            get
            {
                if (id_chave.Contains("|"))
                {
                    string[] vetor1 = id_chave.Split('|');
                    if (vetor1[0].Contains(":"))
                    {
                        string[] vetor2 = vetor1[0].Split(':');
                        return vetor2[1].ToString();
                    }
                }
                else if (id_chave.Contains(":"))
                {
                    string[] vetor2 = id_chave.Split(':');
                    return vetor2[1].ToString();
                }
                
                return string.Empty;
            } 
        }
        public string id_item
        {
            get
            {
                if (id_chave.Contains("|"))
                {
                    string[] vetor1 = id_chave.Split('|');
                    if (vetor1[1].Contains(":"))
                    {
                        string[] vetor2 = vetor1[1].Split(':');
                        return vetor2[1].ToString();
                    }
                }

                return string.Empty;
            }
        }

        public TRegistro_ColunasAudit()
        { 
            this.id_auditoria = null;
            this.id_auditoriastr = string.Empty;
            this.id_registro = null;
            this.id_registrostr = string.Empty;
            this.Nm_coluna = string.Empty;
            this.Vl_old = string.Empty;
            this.Vl_atual = string.Empty;
            this.login = string.Empty;
            this.Dt_eventostr = string.Empty;
            this.nm_tabela = string.Empty;
            this.id_chave = string.Empty;
            this.ds_coluna = string.Empty;
        }
    }

    public class TCD_ColunasAudit : TDataQuery
    {
        public TCD_ColunasAudit() { }

        public TCD_ColunasAudit(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("Select " + strTop + " a.id_auditoria, a.id_registro, a.nm_coluna, a.vl_old, a.vl_atual, b.login, b.dt_evento, b.nm_tabela, b.id_chave, isnull(c.ds_coluna,a.nm_coluna) as ds_coluna ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_ColunasAudit a ");
            sql.AppendLine(" left join tb_div_auditoria b ON A.id_auditoria = b.id_auditoria ");
            sql.AppendLine(" left join TB_DIV_AuditColunas c on a.nm_coluna = c.nm_coluna and b.nm_tabela = c.nm_tabela ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_ColunasAudit Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ColunasAudit lista = new TList_ColunasAudit();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ColunasAudit reg = new TRegistro_ColunasAudit();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_auditoria")))
                        reg.Id_auditoria = reader.GetDecimal(reader.GetOrdinal("id_auditoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_coluna")))
                        reg.Nm_coluna = reader.GetString(reader.GetOrdinal("nm_coluna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tabela")))
                        reg.nm_tabela = reader.GetString(reader.GetOrdinal("nm_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_coluna")))
                        reg.ds_coluna = reader.GetString(reader.GetOrdinal("ds_coluna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tabela")))
                        reg.nm_tabela = reader.GetString(reader.GetOrdinal("nm_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_chave")))
                        reg.id_chave = reader.GetString(reader.GetOrdinal("id_chave"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("Dt_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_old")))
                        reg.Vl_old = reader.GetString(reader.GetOrdinal("vl_old"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_atual")))
                        reg.Vl_atual = reader.GetString(reader.GetOrdinal("vl_atual"));

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
    }
}
