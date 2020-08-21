using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.WS_RDC
{
    public class TList_Cad_RDC : List<TRegistro_Cad_RDC> { }

    public class TRegistro_Cad_RDC
    {
        public string ID_RDC { get; set; }
        public string DS_RDC { get; set; }
        public decimal Versao { get; set; }
        public string ST_RDC { get; set; }
        
        public string Modulo { get; set; }
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
            }
        }

        public TList_Cad_DataSource lCad_DataSource { get; set; }

        public TRegistro_Cad_RDC()
        {
            ID_RDC = string.Empty;
            Versao = decimal.Zero;
            Code_Report = null;
            ST_RDC = string.Empty;
            Modulo = string.Empty;
            Ident = string.Empty;
            NM_Classe = string.Empty;
            lCad_DataSource = new TList_Cad_DataSource();
        }
    }

    public class TCD_Cad_RDC : TDataQuery
    {
        public TCD_Cad_RDC()
        { }

        public TCD_Cad_RDC(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_RDC, a.DS_RDC, a.Modulo, ");
                sql.AppendLine("a.Ident, a.NM_Classe, a.Versao, a.Code_Report,  a.ST_RDC ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_BIN_RDC a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.ID_RDC ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_RDC Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_RDC lista = new TList_Cad_RDC();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_RDC reg = new TRegistro_Cad_RDC();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_RDC"))))
                        reg.ID_RDC = reader.GetGuid(reader.GetOrdinal("ID_RDC")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_RDC"))))
                        reg.DS_RDC = reader.GetString(reader.GetOrdinal("DS_RDC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_RDC"))))
                        reg.ST_RDC = reader.GetString(reader.GetOrdinal("ST_RDC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Versao"))))
                        reg.Versao = reader.GetInt32(reader.GetOrdinal("Versao"));
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
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string GravarRDC(TRegistro_Cad_RDC val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_RDC", string.IsNullOrEmpty(val.ID_RDC) ? new Guid() : new Guid(val.ID_RDC));
            hs.Add("@P_ST_RDC", val.ST_RDC);
            hs.Add("@P_DS_RDC", val.DS_RDC);
            hs.Add("@P_VERSAO", val.Versao);
            hs.Add("@P_CODE_REPORT", val.Code_Report);
            hs.Add("@P_MODULO", val.Modulo);
            hs.Add("@P_IDENT", val.Ident);
            hs.Add("@P_NM_CLASSE", val.NM_Classe);

            return executarProc("IA_BIN_RDC", hs);
        }

        public string DeletarRDC(TRegistro_Cad_RDC val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_RDC", new Guid(val.ID_RDC));
            return executarProc("EXCLUI_BIN_RDC", hs);
        }

    }
}
