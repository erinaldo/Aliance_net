using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Linq;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_Report_X_Consulta : List<TRegistro_Cad_Report_X_Consulta> { }

    public class TRegistro_Cad_Report_X_Consulta
    {
        public decimal ID_Report { get; set; }
        public string ID_Consulta { get; set; }
        public string DS_Report { get; set; }
        public string DS_Consulta { get; set; }
        
        public TRegistro_Cad_Report_X_Consulta()
        {
            this.ID_Report = 0;
            this.ID_Consulta = "";
            this.DS_Report = "";
            this.DS_Consulta = "";
        }
    }

    public class TCD_Cad_Report_X_Consulta : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.ID_Report, a.ID_Consulta, b.DS_Report, c.DS_Consulta ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CON_Report_X_Consulta a ");
            sql.AppendLine("INNER JOIN TB_CON_Report b ON a.ID_Report = b.ID_Report ");
            sql.AppendLine("INNER JOIN TB_CON_Consulta c ON a.ID_Consulta = c.ID_Consulta ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.ID_Report, a.ID_Consulta ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_Report_X_Consulta Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_Report_X_Consulta lista = new TList_Cad_Report_X_Consulta();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_Report_X_Consulta reg = new TRegistro_Cad_Report_X_Consulta();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Report"))))
                        reg.ID_Report = reader.GetDecimal(reader.GetOrdinal("ID_Report"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Consulta"))))
                        reg.ID_Consulta = reader.GetGuid(reader.GetOrdinal("ID_Consulta")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Report"))))
                        reg.DS_Report = reader.GetString(reader.GetOrdinal("DS_Report"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Consulta"))))
                        reg.DS_Consulta = reader.GetString(reader.GetOrdinal("DS_Consulta"));

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

        public string GravarReport_X_Consulta(TRegistro_Cad_Report_X_Consulta val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_REPORT", val.ID_Report);
            hs.Add("@P_ID_CONSULTA", new Guid(val.ID_Consulta));
            return this.executarProc("IA_CON_REPORT_X_CONSULTA", hs);
        }

        public string DeletarReport_X_Consulta(TRegistro_Cad_Report_X_Consulta val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_REPORT", val.ID_Report);
            hs.Add("@P_ID_CONSULTA", new Guid(val.ID_Consulta));
            return this.executarProc("EXCLUI_CON_REPORT_X_CONSULTA", hs);
        }

        public string DeletarReportPorConsulta(string vID_Consulta)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", new Guid(vID_Consulta));
            return this.executarProc("EXCLUI_CON_REPORTPORCONSULTA", hs);
        }
    }
}
