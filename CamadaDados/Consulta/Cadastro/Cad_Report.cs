using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Linq;
using CamadaDados.WS_RDC;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_Report : List<TRegistro_Cad_Report> { }

    public class TRegistro_Cad_Report
    {
        public decimal ID_Report { get; set; }
        public string DS_Report { get; set; }
        public string ID_RDC { get; set; }
        public decimal Versao { get; set; }
        public string ST_Report { get; set; }
        public string ST_DataCube { get; set; }
        public string ST_Chart { get; set; }

        public string Modulo { get; set; }
        public string Sistema { get; set; }
        public string Ident { get; set; }
        public string NM_Classe { get; set; }

        private byte[] code_report;
        public byte[] Code_Report
        {
            get
            {
                return code_report;
            }
            set
            {
                code_report = value;
                if (code_report != null)
                    ST_Report = "SIM";
                else
                    ST_Report = "NÃO";
            }
        }

        private byte[] code_datacube;
        public byte[] Code_DataCube
        {
            get
            {
                return code_datacube;
            }
            set
            {
                code_datacube = value;
                if (code_datacube != null)
                    ST_DataCube = "SIM";
                else
                    ST_DataCube = "NÃO";
            }
        }

        private byte[] code_chart;
        public byte[] Code_Chart
        {
            get
            {
                return code_chart;
            }
            set
            {
                code_chart = value;
                if (code_chart != null)
                    ST_Chart = "SIM";
                else
                    ST_Chart = "NÃO";
            }
        }
        public TList_Cad_Consulta lConsulta { get; set; }

        public TRegistro_Cad_Report()
        {
            this.ID_Report = 0;
            this.ID_RDC = "";
            this.Versao = 0;
            this.Code_Report = null;
            this.Code_DataCube = null;
            this.Code_Chart = null;
            this.Modulo = string.Empty;
            this.Ident = string.Empty;
            this.NM_Classe = string.Empty;
            this.lConsulta = new TList_Cad_Consulta();
        }
    }

    public class TCD_Cad_Report : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Report, a.DS_Report, a.ID_RDC, a.Modulo, a.Ident, a.NM_Classe, a.Versao, a.Code_Report ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CON_Report a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.ID_Report ASC");
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

        public TList_Cad_Report Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_Report lista = new TList_Cad_Report();
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
                    TRegistro_Cad_Report reg = new TRegistro_Cad_Report();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Report"))))
                        reg.ID_Report = reader.GetDecimal(reader.GetOrdinal("ID_Report"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Report"))))
                        reg.DS_Report = reader.GetString(reader.GetOrdinal("DS_Report"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_RDC"))))
                        reg.ID_RDC = reader.GetGuid(reader.GetOrdinal("ID_RDC")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Versao"))))
                        reg.Versao = reader.GetDecimal(reader.GetOrdinal("Versao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Code_Report"))))
                        reg.Code_Report = (byte[])reader.GetValue(reader.GetOrdinal("Code_Report"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Modulo"))))
                        reg.Modulo = reader.GetString(reader.GetOrdinal("Modulo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ident"))))
                        reg.Ident = reader.GetString(reader.GetOrdinal("Ident"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Classe"))))
                        reg.NM_Classe = reader.GetString(reader.GetOrdinal("NM_Classe"));
                    
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

        public string GravarReport(TRegistro_Cad_Report val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_REPORT", val.ID_Report);
            hs.Add("@P_DS_REPORT", val.DS_Report);
            if (val.ID_RDC != "")
                hs.Add("@P_ID_RDC", new Guid(val.ID_RDC));
            hs.Add("@P_VERSAO", val.Versao);
            hs.Add("@P_CODE_REPORT", val.Code_Report);
            hs.Add("@P_CODE_DATACUBE", val.Code_DataCube);
            hs.Add("@P_CODE_CHART", val.Code_Chart);
            hs.Add("@P_MODULO", val.Modulo);
            hs.Add("@P_IDENT", val.Ident);
            hs.Add("@P_NM_CLASSE", val.NM_Classe);
            hs.Add("@P_SISTEMA", val.Sistema);

            return this.executarProc("IA_CON_REPORT", hs);
        }

        public string DeletarReport(TRegistro_Cad_Report val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_REPORT", val.ID_Report);
            return this.executarProc("EXCLUI_CON_REPORT", hs);
        }

        public string AtualizaMenuReport(string ID_Menu)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_MENU", ID_Menu);
            return this.executarProc("ATUALIZA_MENU_CON_REPORT", hs);
        }
    }
}
