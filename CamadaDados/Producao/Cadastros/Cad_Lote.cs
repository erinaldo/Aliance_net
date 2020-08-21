using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using BancoDados;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_CadLote : List<TRegistro_CadLote>
    { }

    public class TRegistro_CadLote
    {
        public decimal Nr_loteproducao { get; set; }
        public string Ds_loteproducao { get; set; }
        public string Cd_loteID { get; set; }
        private DateTime? dt_inivigencia = null;
        public DateTime? Dt_inivigencia
        {
            get { return dt_inivigencia; }
            set
            {
                dt_inivigencia = value;
                dt_inivigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inivigenciastr = string.Empty;
        public string Dt_inivigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inivigenciastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inivigenciastr = value;
                try
                {
                    dt_inivigencia = DateTime.Parse(value);
                }
                catch { dt_inivigencia = null; }
            }
        }
        private DateTime? dt_finvigencia = null;
        public DateTime? Dt_finvigencia
        {
            get { return dt_finvigencia; }
            set
            {
                dt_finvigencia = value;
                dt_finvigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finvigenciastr = string.Empty;
        public string Dt_finvigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finvigenciastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finvigenciastr = value;
                try
                {
                    dt_finvigencia = DateTime.Parse(value);
                }
                catch { dt_finvigencia = null; }
            }
        }
        public TRegistro_CadLote()
        {
            Nr_loteproducao = 0;
            Ds_loteproducao = string.Empty;
            Cd_loteID = string.Empty;
        }
    }

    public class TCD_CadLote : TDataQuery
    {
        public TCD_CadLote() { }

        public TCD_CadLote(TObjetoBanco banco) { Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
            {
                strTop = "TOP " + Convert.ToString(vTop);
            }
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" Select " + strTop + " a.nr_loteProducao, a.ds_Loteproducao, a.cd_LoteID, ");
                sql.AppendLine("a.DT_IniVigencia, a.DT_FinVigencia, a.DT_Cad, a.DT_Alt ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.Append("From TB_PRD_Lote a");
            string cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_CadLote Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadLote lista = new TList_CadLote();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadLote CadLote = new TRegistro_CadLote();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LoteProducao")))
                        CadLote.Nr_loteproducao = reader.GetDecimal(reader.GetOrdinal("NR_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LoteProducao")))
                        CadLote.Ds_loteproducao = reader.GetString(reader.GetOrdinal("DS_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LoteID")))
                        CadLote.Cd_loteID = reader.GetString(reader.GetOrdinal("CD_LoteID"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniVigencia")))
                        CadLote.Dt_inivigencia = reader.GetDateTime(reader.GetOrdinal("DT_IniVigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FinVigencia")))
                        CadLote.Dt_finvigencia = reader.GetDateTime(reader.GetOrdinal("DT_FinVigencia"));
                    lista.Add(CadLote);
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

        public string Gravar(TRegistro_CadLote val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_LOTEPRODUCAO", val.Nr_loteproducao);
            hs.Add("@P_DS_LOTEPRODUCAO", val.Ds_loteproducao);
            hs.Add("@P_CD_LOTEID", val.Cd_loteID);
            hs.Add("@P_DT_INIVIGENCIA", val.Dt_inivigencia);
            hs.Add("@P_DT_FINVIGENCIA", val.Dt_finvigencia);
            return executarProc("IA_PRD_LOTE", hs);

        }

        public string Excluir(TRegistro_CadLote val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NR_LOTEPRODUCAO", val.Nr_loteproducao);
            return executarProc("EXCLUI_PRD_LOTE", hs);
        }

    }


}
