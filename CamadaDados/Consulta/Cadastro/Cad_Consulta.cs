using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_Consulta : List<TRegistro_Cad_Consulta> { }

    public class TRegistro_Cad_Consulta
    {
        public string ID_Consulta { get; set; }
        public string Login { get; set; }
        public string DS_Consulta { get; set; }
        public string DS_SQL { get; set; }
        private DateTime? _DT_Consulta;
        public DateTime? DT_Consulta
        {
            get { return _DT_Consulta; }
            set
            {
                _DT_Consulta = value;
                _DT_ConsultaString = value.ToString();
            }
        }
        private string _DT_ConsultaString;
        public string DT_ConsultaString
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_DT_ConsultaString).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                _DT_ConsultaString = value;
                try
                { _DT_Consulta = Convert.ToDateTime(value); }
                catch
                { _DT_Consulta = null; }
            }
        }

        public TList_Cad_ParamClasse lParamClasse { get; set; }

        public TRegistro_Cad_Consulta()
        {
            this.ID_Consulta = "";
            this.Login = "";
            this.DS_Consulta = "";
            this.DS_SQL = "";
            this.DT_Consulta = DateTime.Now;
            this.lParamClasse = new TList_Cad_ParamClasse();
        }
    }

    public class TCD_Cad_Consulta : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Consulta, a.Login, a.DS_Consulta, a.DS_SQL, a.DT_Consulta ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_Consulta a ");

            cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.DS_Consulta ASC");
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

        public TList_Cad_Consulta Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Consulta lista = new TList_Cad_Consulta();
            SqlDataReader reader;
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
                    TRegistro_Cad_Consulta reg = new TRegistro_Cad_Consulta();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Consulta")))
                        reg.ID_Consulta = reader.GetGuid(reader.GetOrdinal("ID_Consulta")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Consulta")))
                        reg.DS_Consulta = reader.GetString(reader.GetOrdinal("DS_Consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SQL")))
                        reg.DS_SQL = reader.GetString(reader.GetOrdinal("DS_SQL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Consulta")))
                        reg.DT_Consulta = reader.GetDateTime(reader.GetOrdinal("DT_Consulta"));

                    lista.Add(reg);

                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            };
            return lista;
        }

        public string Grava(TRegistro_Cad_Consulta val)
        {
            Hashtable hs = new Hashtable(4);
            Guid ID;
            if (val.ID_Consulta != "")
                ID = new Guid(val.ID_Consulta);
            else
                ID = System.Guid.NewGuid();

            hs.Add("@P_ID_CONSULTA", ID);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_CONSULTA", val.DS_Consulta);
            hs.Add("@P_DS_SQL", val.DS_SQL);
            return executarProc("IA_CON_CONSULTA", hs);
        }

        public string Deleta(TRegistro_Cad_Consulta val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", new Guid(val.ID_Consulta));
            return executarProc("EXCLUI_CON_CONSULTA", hs);
        }
    }
}
