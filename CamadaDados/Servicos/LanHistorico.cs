using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos
{
    public class TList_Historico : List<TRegistro_Historico>, IComparer<TRegistro_Historico>
    {
        #region IComparer<TRegistro_Historico> Members
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

        public TList_Historico()
        { }

        public TList_Historico(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Historico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Historico x, TRegistro_Historico y)
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

    
    public class TRegistro_Historico
    {
        private decimal? id_os;
        
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Id_historico
        { get; set; }
        
        public string Id_historicostr
        { get; set; }
        
        public string Ds_historico
        { get; set; }
        
        public string Login
        { get; set; }
        private DateTime? dt_historico;
        
        public DateTime? Dt_historico
        {
            get { return dt_historico; }
            set
            {
                dt_historico = value;
                dt_historicostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_historicostr;
        
        public string Dt_historicostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_historicostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_historicostr = value;
                try
                {
                    dt_historico = DateTime.Parse(value);
                }
                catch
                { dt_historico = null; }
            }
        }

        public TRegistro_Historico()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Id_historico = null;
            this.Id_historicostr = string.Empty;
            this.Ds_historico = string.Empty;
            this.Login = string.Empty;
            this.dt_historico = null;
            this.dt_historicostr = string.Empty;
        }
    }

    public class TCD_Historico : TDataQuery
    {
        public TCD_Historico()
        { }

        public TCD_Historico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "a.id_os, a.cd_empresa, ");
                sql.AppendLine("a.id_historico, a.login, a.ds_historico, a.dt_historico ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_OSE_Historico a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_historico desc ");
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

        public TList_Historico Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Historico lista = new TList_Historico();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Historico reg = new TRegistro_Historico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_historico")))
                        reg.Id_historico = reader.GetDecimal(reader.GetOrdinal("id_historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_historico"))))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("dt_historico"))))
                        reg.Dt_historico = reader.GetDateTime(reader.GetOrdinal("dt_historico"));
                    
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

        public string Gravar(TRegistro_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_HISTORICO", val.Id_historico);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_HISTORICO", val.Ds_historico);
            hs.Add("@P_DT_HISTORICO", val.Dt_historico);

            return this.executarProc("IA_OSE_HISTORICO", hs);
        }

        public string Excluir(TRegistro_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_HISTORICO", val.Id_historico);

            return this.executarProc("EXCLUI_OSE_HISTORICO", hs);
        }
    }
}
