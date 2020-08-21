using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_LogSQL : List<TRegistro_LogSQL>, IComparer<TRegistro_LogSQL>
    {
        #region IComparer<TRegistro_LogSQL> Members
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

        public TList_LogSQL()
        { }

        public TList_LogSQL(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LogSQL value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LogSQL x, TRegistro_LogSQL y)
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

    public class TRegistro_LogSQL
    {
        private decimal? id_log;
        public decimal? Id_log
        {
            get { return id_log; }
            set
            {
                id_log = value;
                id_logstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_logstr;
        public string Id_logstr
        {
            get { return id_logstr; }
            set
            {
                id_logstr = value;
                try
                {
                    id_log = decimal.Parse(value);
                }
                catch { id_log = null; }
            }
        }
        private string Login
        { get; set; }
        public string ComandoSQL
        { get; set; }
        private DateTime? dt_registro;
        public DateTime? Dt_registro
        {
            get { return dt_registro; }
            set
            {
                dt_registro = value;
                dt_registrostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_registrostr;
        public string Dt_registrostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_registrostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_registrostr = value;
                try
                {
                    dt_registro = DateTime.Parse(value);
                }
                catch { dt_registro = null; }
            }
        }

        public TRegistro_LogSQL()
        {
            this.id_log = null;
            this.id_logstr = string.Empty;
            this.Login = string.Empty;
            this.ComandoSQL = string.Empty;
            this.dt_registro = null;
            this.dt_registrostr = string.Empty;
        }
    }

    public class TCD_LogSQL : TDataQuery
    {
        public TCD_LogSQL() { }

        public TCD_LogSQL(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " ");
                sql.AppendLine("");

            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_LogEmail a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
    }
}
