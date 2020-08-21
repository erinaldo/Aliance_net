using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.WS_RDC
{
    public class TList_Cad_DataSource : List<TRegistro_Cad_DataSource> { }

    public class TRegistro_Cad_DataSource
    {
        public string ID_DataSource { get; set; }
        public string DS_DataSource { get; set; }
        public string DS_SQL { get; set; }
        private DateTime? _DT_DataSource;
        public DateTime? DT_DataSource
        {
            get { return _DT_DataSource; }
            set
            {
                _DT_DataSource = value;
                _DT_DataSourceString = value.ToString();
            }
        }
        private string _DT_DataSourceString;
        public string DT_DataSourceString
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_DT_DataSourceString).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                _DT_DataSourceString = value;
                try
                { _DT_DataSource = Convert.ToDateTime(value); }
                catch
                { _DT_DataSource = null; }
            }
        }

        public TList_Cad_ParamClasse lCad_ParamClasse { get; set; }

        public TRegistro_Cad_DataSource()
        {
            this.ID_DataSource = "";
            this.DS_DataSource = "";
            this.DS_SQL = "";
            this.DT_DataSource = DateTime.Now;
            this.lCad_ParamClasse = new TList_Cad_ParamClasse();
        }
    }

    public class TCD_Cad_DataSource : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.ID_DTS, a.DS_DTS, a.DS_SQL, a.DT_DTS ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_bin_DataSource a ");

            cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.DS_DTS ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public DataTable BuscarSQL(string SQL)
        {
            return this.ExecutarBusca(SQL, null);
        }

        public TList_Cad_DataSource Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_DataSource lista = new TList_Cad_DataSource();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                if (vNM_Campo == "")
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
                else
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_Cad_DataSource reg = new TRegistro_Cad_DataSource();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DTS")))
                        reg.ID_DataSource = reader.GetGuid(reader.GetOrdinal("ID_DTS")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_DTS")))
                        reg.DS_DataSource = reader.GetString(reader.GetOrdinal("DS_DTS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SQL")))
                        reg.DS_SQL = reader.GetString(reader.GetOrdinal("DS_SQL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_DTS")))
                        reg.DT_DataSource = reader.GetDateTime(reader.GetOrdinal("DT_DTS"));

                    lista.Add(reg);

                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            };
            return lista;
        }

        public string Grava(TRegistro_Cad_DataSource val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_DATASOURCE", new Guid(val.ID_DataSource));
            hs.Add("@P_DS_DATASOURCE", val.DS_DataSource);
            hs.Add("@P_DS_SQL", val.DS_SQL);
            return executarProc("IA_BIN_DATASOURCE", hs);
        }

        public string Deleta(TRegistro_Cad_DataSource val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_DATASOURCE", val.ID_DataSource);
            return executarProc("EXCLUI_BIN_DATASOURCE", hs);
        }
    }
}
