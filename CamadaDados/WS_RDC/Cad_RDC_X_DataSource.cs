using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Linq;

namespace CamadaDados.WS_RDC
{
    public class TList_Cad_RDC_X_DataSource : List<TRegistro_Cad_RDC_X_DataSource> { }

    public class TRegistro_Cad_RDC_X_DataSource
    {
        public string ID_RDC { get; set; }
        public string ID_DataSource { get; set; }
        public string DS_RDC { get; set; }
        public string ST_RDC { get; set; }
        public string DS_DataSource { get; set; }

        public TRegistro_Cad_RDC_X_DataSource()
        {
            this.ID_RDC = "";
            this.ID_DataSource = "";
            this.DS_RDC = "";
            this.DS_DataSource = "";
        }
    }

    public class TCD_Cad_RDC_X_DataSource : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.ID_RDC, a.ID_DTS, b.DS_RDC, c.DS_DTS, ST_RDC ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_BIN_RDC_X_DataSource a ");
            sql.AppendLine("INNER JOIN TB_CON_RDC b ON a.ID_RDC = b.ID_RDC ");
            sql.AppendLine("INNER JOIN TB_CON_DataSource c ON a.ID_DTS = c.ID_DTS ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.ID_RDC, a.ID_DTS ASC");
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

        public TList_Cad_RDC_X_DataSource Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_RDC_X_DataSource lista = new TList_Cad_RDC_X_DataSource();
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
                    TRegistro_Cad_RDC_X_DataSource reg = new TRegistro_Cad_RDC_X_DataSource();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_RDC"))))
                        reg.ID_RDC = reader.GetGuid(reader.GetOrdinal("ID_RDC")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_DTS"))))
                        reg.ID_DataSource = reader.GetGuid(reader.GetOrdinal("ID_DTS")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_RDC"))))
                        reg.DS_RDC = reader.GetString(reader.GetOrdinal("DS_RDC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_DTS"))))
                        reg.DS_DataSource = reader.GetString(reader.GetOrdinal("DS_DTS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_RDC"))))
                        reg.ST_RDC = reader.GetString(reader.GetOrdinal("ST_RDC"));

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

        public string GravarRDC_X_DataSource(TRegistro_Cad_RDC_X_DataSource val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_RDC", new Guid(val.ID_RDC));
            hs.Add("@P_ST_RDC", val.ST_RDC);
            hs.Add("@P_ID_DATASOURCE", new Guid(val.ID_DataSource));
            return this.executarProc("IA_BIN_RDC_X_DATASOURCE", hs);
        }

        public string DeletarRDC_X_DataSource(TRegistro_Cad_RDC_X_DataSource val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_RDC", new Guid(val.ID_RDC));
            hs.Add("@P_ID_DTS", new Guid(val.ID_DataSource));
            return this.executarProc("EXCLUI_BIN_RDC_X_DATASOURCE", hs);
        }

        public string DeletarRDCPorDataSource(string vID_DataSource)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_DTS", new Guid(vID_DataSource));
            return this.executarProc("EXCLUI_BIN_RDCPORDATASOURCE", hs);
        }

        public string DeletarRDCPorRDC(string vID_RDC)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_RDC", new Guid(vID_RDC));
            return this.executarProc("EXCLUI_BIN_RDCPORRDC", hs);
        }
    }
}
