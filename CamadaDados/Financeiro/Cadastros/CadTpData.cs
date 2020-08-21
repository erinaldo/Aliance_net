using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    #region Tipo de Data
    public class TList_TpData : List<TRegistro_TpData>, IComparer<TRegistro_TpData>
    {
        #region IComparer<TRegistro_Tp_data> Members
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

        public TList_TpData()
        { }

        public TList_TpData(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpData value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpData x, TRegistro_TpData y)
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


    public class TRegistro_TpData
    {
        private decimal? id_tpdata;
        public decimal? Id_TpData
        {
            get { return id_tpdata; }
            set
            {
                id_tpdata = value;
                id_tpdataStr = value.ToString();
            }
        }
        private string id_tpdataStr;
        public string Id_TpDataStr
        {
            get
            {
                return id_tpdataStr;
            }
            set
            {
                id_tpdataStr = value;
                try
                {
                    id_tpdata = Convert.ToDecimal(value);
                }
                catch
                {
                    id_tpdata = null;
                }
            }
        }

        public string Ds_tpData
        { get; set; }

        public TRegistro_TpData()
        {
            this.Id_TpData = null;
            this.Id_TpDataStr = string.Empty;
        }
    }

    public class TCD_TpData : TDataQuery
    {
        public TCD_TpData()
        { }

        public TCD_TpData(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_TpData, a.DS_TpData ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_TPData a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
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

        public TList_TpData Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TpData lista = new TList_TpData();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_TpData reg = new TRegistro_TpData();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpData")))
                        reg.Id_TpData = reader.GetDecimal(reader.GetOrdinal("ID_TpData"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpData")))
                        reg.Ds_tpData = reader.GetString(reader.GetOrdinal("DS_TpData"));

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

        public string Gravar(TRegistro_TpData val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);
            hs.Add("@P_DS_TPDATA", val.Ds_tpData);

            return this.executarProc("IA_FIN_TPDATA", hs);
        }

        public string Excluir(TRegistro_TpData val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);

            return this.executarProc("EXCLUI_FIN_TPDATA", hs);
        }
    }
    #endregion

    #region Data Clifor
    public class TList_DataClifor : List<TRegistro_DataClifor>, IComparer<TRegistro_DataClifor>
    {
        #region IComparer<TRegistro_DataClifor> Members
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

        public TList_DataClifor()
        { }

        public TList_DataClifor(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DataClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DataClifor x, TRegistro_DataClifor y)
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


    public class TRegistro_DataClifor
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_tpdata;
        public decimal? Id_TpData
        {
            get { return id_tpdata; }
            set
            {
                id_tpdata = value;
                id_tpdataStr = value.ToString();
            }
        }
        private string id_tpdataStr;
        public string Id_TpDataStr
        {
            get
            {
                return id_tpdataStr;
            }
            set
            {
                id_tpdataStr = value;
                try
                {
                    id_tpdata = Convert.ToDecimal(value);
                }
                catch
                {
                    id_tpdata = null;
                }
            }
        }

        public string Ds_tpdata
        { get; set; }

        private DateTime? data;

        public DateTime? Data
        {
            get { return data; }
            set
            {
                data = value;
                datastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string datastr;
        public string Datastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(datastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                datastr = value;
                try
                {
                    data = DateTime.Parse(value);
                }
                catch
                { data = null; }
            }
        }
        public string Tp_clifor
        { get; set; }

        public TRegistro_DataClifor()
        {
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Id_TpData = null;
            this.Id_TpDataStr = string.Empty;
            this.Ds_tpdata = string.Empty;
            this.Data = null;
            this.Datastr = string.Empty;
            this.Tp_clifor = string.Empty;
        }
    }

    public class TCD_DataClifor : TDataQuery
    {
        public TCD_DataClifor()
        { }

        public TCD_DataClifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_clifor, b.nm_clifor, a.ID_TpData, c.ds_tpdata, a.Data, a.Tp_clifor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_DataClifor a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_TPDATA c ");
            sql.AppendLine("on a.id_tpdata = c.id_tpdata ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
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

        public TList_DataClifor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DataClifor lista = new TList_DataClifor();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_DataClifor reg = new TRegistro_DataClifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpData")))
                        reg.Id_TpData = reader.GetDecimal(reader.GetOrdinal("ID_TpData"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdata")))
                        reg.Ds_tpdata = reader.GetString(reader.GetOrdinal("ds_tpdata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Data")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_clifor")))
                        reg.Tp_clifor = reader.GetString(reader.GetOrdinal("Tp_clifor"));

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

        public string Gravar(TRegistro_DataClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);
            hs.Add("@P_TP_CLIFOR", val.Tp_clifor);
            hs.Add("@P_DATA", val.Data);

            return this.executarProc("IA_FIN_DATACLIFOR", hs);
        }

        public string Excluir(TRegistro_DataClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);
            hs.Add("@P_TP_CLIFOR", val.Tp_clifor);

            return this.executarProc("EXCLUI_FIN_DATACLIFOR", hs);
        }
    }
    #endregion

    #region Data Contato
    public class TList_DataContato : List<TRegistro_DataContato>, IComparer<TRegistro_DataContato>
    {
        #region IComparer<TRegistro_DataContato> Members
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

        public TList_DataContato()
        { }

        public TList_DataContato(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DataContato value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DataContato x, TRegistro_DataContato y)
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


    public class TRegistro_DataContato
    {
        private decimal? id_contato;
        public decimal? Id_contato
        {
            get { return id_contato; }
            set
            {
                id_contato = value;
                id_contatoStr = value.ToString();
            }
        }
        private string id_contatoStr;
        public string Id_contatoStr
        {
            get
            {
                return id_contatoStr;
            }
            set
            {
                id_contatoStr = value;
                try
                {
                    id_contato = Convert.ToDecimal(value);
                }
                catch
                {
                    id_contato = null;
                }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_tpdata;
        public decimal? Id_TpData
        {
            get { return id_tpdata; }
            set
            {
                id_tpdata = value;
                id_tpdataStr = value.ToString();
            }
        }
        private string id_tpdataStr;
        public string Id_TpDataStr
        {
            get
            {
                return id_tpdataStr;
            }
            set
            {
                id_tpdataStr = value;
                try
                {
                    id_tpdata = Convert.ToDecimal(value);
                }
                catch
                {
                    id_tpdata = null;
                }
            }
        }

        public string Ds_tpdata
        { get; set; }

        private DateTime? data;

        public DateTime? Data
        {
            get { return data; }
            set
            {
                data = value;
                datastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string datastr;
        public string Datastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(datastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                datastr = value;
                try
                {
                    data = DateTime.Parse(value);
                }
                catch
                { data = null; }
            }
        }

        public TRegistro_DataContato()
        {
            this.Id_contato = null;
            this.Id_contatoStr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Id_TpData = null;
            this.Id_TpDataStr = string.Empty;
            this.Ds_tpdata = string.Empty;
            this.Data = null;
            this.Datastr = string.Empty;
        }
    }

    public class TCD_DataContato : TDataQuery
    {
        public TCD_DataContato()
        { }

        public TCD_DataContato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Contato, a.cd_clifor, b.nm_clifor, a.ID_TpData, c.ds_tpdata, a.Data ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_DataContato a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_TPDATA c ");
            sql.AppendLine("on a.id_tpdata = c.id_tpdata ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
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

        public TList_DataContato Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DataContato lista = new TList_DataContato();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_DataContato reg = new TRegistro_DataContato();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Contato")))
                        reg.Id_contato = reader.GetDecimal(reader.GetOrdinal("ID_Contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpData")))
                        reg.Id_TpData = reader.GetDecimal(reader.GetOrdinal("ID_TpData"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdata")))
                        reg.Ds_tpdata = reader.GetString(reader.GetOrdinal("ds_tpdata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Data")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("Data"));

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

        public string Gravar(TRegistro_DataContato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CONTATO", val.Id_contato);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);
            hs.Add("@P_DATA", val.Data);

            return this.executarProc("IA_FIN_DATACONTATO", hs);
        }

        public string Excluir(TRegistro_DataContato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CONTATO", val.Id_contato);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);

            return this.executarProc("EXCLUI_FIN_DATACONTATO", hs);
        }
    }
    #endregion
}
