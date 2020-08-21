using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_CfgAudit : List<TRegistro_CfgAudit>, IComparer<TRegistro_CfgAudit>
    {
        #region IComparer<TRegistro_CfgAudit> Members
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

        public TList_CfgAudit()
        { }

        public TList_CfgAudit(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgAudit value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgAudit x, TRegistro_CfgAudit y)
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

    public class TRegistro_CfgAudit
    {
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch { id_config = null; }
            }
        }
        public string Nm_tabela
        { get; set; }
        private string st_update;
        public string St_update
        {
            get { return st_update; }
            set
            {
                st_update = value;
                st_updatebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_updatebool;
        public bool St_updatebool
        {
            get { return st_updatebool; }
            set
            {
                st_updatebool = value;
                st_update = value ? "S" : "N";
            }
        }
        private string st_delete;
        public string St_delete
        {
            get { return st_delete; }
            set
            {
                st_delete = value;
                st_deletebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_deletebool;
        public bool St_deletebool
        {
            get { return st_deletebool; }
            set
            {
                st_deletebool = value;
                st_delete = value ? "S" : "N";
            }
        }
        public string Nm_colunas
        { get; set; }

        public TRegistro_CfgAudit()
        {
            this.id_config = null;
            this.id_configstr = string.Empty;
            this.Nm_tabela = string.Empty;
            this.st_update = "N";
            this.st_updatebool = false;
            this.st_delete = "N";
            this.st_deletebool = false;
            this.Nm_colunas = string.Empty;
        }
    }

    public class TCD_CfgAudit : TDataQuery
    {
        public TCD_CfgAudit() { }

        public TCD_CfgAudit(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }
                
        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("Select " + strTop + " a.id_config, a.nm_tabela, a.st_update, a.st_delete, a.nm_colunas ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_CfgAudit a ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

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

        public System.Data.DataTable BuscarTrigger(string Tabela)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select A.name Nome_Trigger, c.is_disabled ");
            sql.AppendLine("from sysobjects A ");
            sql.AppendLine("join sysobjects B ");
            sql.AppendLine("on A.parent_obj = B.id ");
            sql.AppendLine("join sys.triggers C ");
            sql.AppendLine("on a.id = c.object_id ");
            sql.AppendLine("where A.xtype = 'TR' ");
            if (!string.IsNullOrEmpty(Tabela))
                sql.AppendLine("and B.name = '" + Tabela.Trim() + "'");
            return this.ExecutarBusca(sql.ToString(), null);
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

        public TList_CfgAudit Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgAudit lista = new TList_CfgAudit();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgAudit reg = new TRegistro_CfgAudit();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tabela")))
                        reg.Nm_tabela = reader.GetString(reader.GetOrdinal("nm_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_update")))
                        reg.St_update = reader.GetString(reader.GetOrdinal("st_update"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_delete")))
                        reg.St_delete = reader.GetString(reader.GetOrdinal("st_delete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_colunas")))
                        reg.Nm_colunas = reader.GetString(reader.GetOrdinal("nm_colunas"));

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

        public string Gravar(TRegistro_CfgAudit val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_NM_TABELA", val.Nm_tabela);
            hs.Add("@P_ST_UPDATE", val.St_update);
            hs.Add("@P_ST_DELETE", val.St_delete);
            hs.Add("@P_NM_COLUNAS", val.Nm_colunas);

            return this.executarProc("IA_DIV_CFGAUDIT", hs);
        }

        public string Excluir(TRegistro_CfgAudit val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CONFIG", val.Id_config);

            return this.executarProc("EXCLUI_DIV_CFGAUDIT", hs);
        }
    }
}
