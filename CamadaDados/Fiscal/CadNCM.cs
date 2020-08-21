using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Fiscal
{
    public class TList_CadNCM : List<TRegistro_CadNCM>
    { }
    
    public class TRegistro_CadNCM
    {
        public string NCM
        { get; set; }
        public string CF
        { get; set; }
        public string Ds_NCM
        { get; set; }
        private decimal? Pc_Aliquota;
        public decimal? PC_Aliquota
        {
            get { return Pc_Aliquota; }
            set
            {
                Pc_Aliquota = value;
                Pc_AliquotaString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string Pc_AliquotaString;
        public string PC_AliquotaString
        {
            get { return Pc_AliquotaString; }
            set
            {
                Pc_AliquotaString = value;
                try
                {
                    Pc_Aliquota = Convert.ToDecimal(value);
                }
                catch
                { Pc_Aliquota = null; }
            }
        }
        public string CEST
        { get; set; }
        private DateTime? dt_DT_IniVigencia;
        public DateTime? Dt_DT_IniVigencia
        {
            get { return dt_DT_IniVigencia; }
            set
            {
                dt_DT_IniVigencia = value;
                dt_DT_IniVigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_DT_IniVigenciastr;
        public string Dt_DT_IniVigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_DT_IniVigenciastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_DT_IniVigenciastr = value;
                try
                {
                    dt_DT_IniVigencia = DateTime.Parse(value);
                }
                catch { dt_DT_IniVigencia = null; }
            }
        }
        private DateTime? dt_DT_FimVigencia;
        public DateTime? Dt_DT_FimVigencia
        {
            get { return dt_DT_FimVigencia; }
            set
            {
                dt_DT_FimVigencia = value;
                dt_DT_FimVigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_DT_FimVigenciastr;
        public string Dt_DT_FimVigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_DT_FimVigenciastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_DT_FimVigenciastr = value;
                try
                {
                    dt_DT_FimVigencia = DateTime.Parse(value);
                }
                catch { dt_DT_FimVigencia = null; }
            }
        }

        public TRegistro_CadNCM()
        {
            NCM = string.Empty;
            CF = string.Empty;
            Ds_NCM = string.Empty;
            Pc_Aliquota = decimal.Zero;
            CEST = string.Empty;
            dt_DT_FimVigencia = new DateTime();
            dt_DT_IniVigencia = new DateTime();
        }
    }

    public class TCD_CadNCM : TDataQuery
    {
        public TCD_CadNCM() { }

        public TCD_CadNCM(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "  TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NCM, a.CF ,a.Ds_NCM, a.Pc_Aliquota, a.CEST, a.DT_FinVigencia, a.DT_IniVigencia ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fis_NCM a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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

        public TList_CadNCM Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadNCM lista = new TList_CadNCM();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadNCM reg = new TRegistro_CadNCM();

                    if (!(reader.IsDBNull(reader.GetOrdinal("NCM"))))
                        reg.NCM = reader.GetString(reader.GetOrdinal("NCM"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CF"))))
                        reg.CF = reader.GetString(reader.GetOrdinal("CF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_NCM"))))
                        reg.Ds_NCM = reader.GetString(reader.GetOrdinal("DS_NCM"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTA"))))
                        reg.PC_Aliquota = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEST")))
                        reg.CEST = reader.GetString(reader.GetOrdinal("CEST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FinVigencia")))
                        reg.Dt_DT_FimVigencia = reader.GetDateTime(reader.GetOrdinal("DT_FinVigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniVigencia")))
                        reg.Dt_DT_IniVigencia = reader.GetDateTime(reader.GetOrdinal("DT_IniVigencia"));

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

        public string GravarNCM(TRegistro_CadNCM val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_NCM", val.NCM.Trim());
            hs.Add("@P_CF", val.CF);
            hs.Add("@P_DS_NCM", val.Ds_NCM);
            hs.Add("@P_PC_ALIQUOTA", val.PC_Aliquota);
            hs.Add("@P_CEST", val.CEST);
            hs.Add("@P_DT_INIVIGENCIA", val.Dt_DT_IniVigenciastr);
            hs.Add("@P_DT_FINVIGENCIA", val.Dt_DT_FimVigenciastr);

            return executarProc("IA_FIS_NCM", hs);
        }

        public string DeletarNCM(TRegistro_CadNCM val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NCM", val.NCM);

            return executarProc("EXCLUI_FIS_NCM", hs);
        }
    }
}
