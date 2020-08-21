using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo71
    {
        public string Tipo
        {
            get
            {
                return "71";
            }
        }
        public string Cnpj_tomador
        { get; set; }
        private string insc_estadual_tomador;
        public string Insc_estadual_tomador
        {
            get
            {
                if (insc_estadual_tomador.Trim().ToUpper() != "ISENTO")
                    return insc_estadual_tomador.Trim().SoNumero();
                else
                    return insc_estadual_tomador;
            }
            set
            {
                insc_estadual_tomador = value;
            }
        }
        public DateTime? Dt_emissao_ctrc
        { get; set; }
        public string Uf_tomador
        { get; set; }
        public string Cd_modelo_ctrc
        { get; set; }
        public string Nr_serie_ctrc
        { get; set; }
        public string Nr_subserie_ctrc
        { get; set; }
        public decimal? Nr_ctrc
        { get; set; }
        public string Uf_remetente
        { get; set; }
        public string Cnpj_remetente
        { get; set; }
        private string insc_estadual_remetente;
        public string Insc_estadual_remetente
        {
            get
            {
                if (insc_estadual_remetente.Trim().ToUpper() != "ISENTO")
                    return insc_estadual_remetente.Trim().SoNumero();
                else
                    return insc_estadual_remetente;
            }
            set
            {
                insc_estadual_remetente = value;
            }
        }
        public DateTime? Dt_emissao_nf
        { get; set; }
        public string Cd_modelo_nf
        { get; set; }
        public string Nr_serie_nf
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal Vl_total_nf
        { get; set; }

        public Tipo71()
        {
            this.Cnpj_tomador = string.Empty;
            this.insc_estadual_tomador = string.Empty;
            this.Dt_emissao_ctrc = null;
            this.Uf_tomador = string.Empty;
            this.Cd_modelo_ctrc = string.Empty;
            this.Nr_serie_ctrc = string.Empty;
            this.Nr_subserie_ctrc = string.Empty;
            this.Nr_ctrc = null;
            this.Uf_remetente = string.Empty;
            this.Cnpj_remetente = string.Empty;
            this.insc_estadual_remetente = string.Empty;
            this.Dt_emissao_nf = null;
            this.Cd_modelo_nf = string.Empty;
            this.Nr_serie_nf = string.Empty;
            this.Nr_notafiscal = null;
            this.Vl_total_nf = decimal.Zero;
        }
    }

    public class TCD_Tipo71 : TDataQuery
    {
        public TCD_Tipo71() { }

        public TCD_Tipo71(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cnpj_tomador, a.insc_estadual_tomador, ");
                sql.AppendLine("a.DT_Emissao_recebimento, a.uf_tomador, a.cd_modelo, ");
                sql.AppendLine("a.Nr_Serie, a.NR_CTRC, a.uf_remetente, ");
                sql.AppendLine("a.cnpj_remetente, a.insc_estadual_remetente, ");
                sql.AppendLine("a.dt_emissao_nf, a.cd_modelo_nf, a.nr_serie_nf, ");
                sql.AppendLine("a.Nr_NotaFiscal, a.vl_totalnota ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG71 a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<Tipo71> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo71> retorno = new List<Tipo71>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo71 reg = new Tipo71();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_tomador")))
                        reg.Cnpj_tomador = reader.GetString(reader.GetOrdinal("cnpj_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_tomador")))
                        reg.Insc_estadual_tomador = reader.GetString(reader.GetOrdinal("insc_estadual_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao_recebimento")))
                        reg.Dt_emissao_ctrc = reader.GetDateTime(reader.GetOrdinal("DT_Emissao_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_tomador")))
                        reg.Uf_tomador = reader.GetString(reader.GetOrdinal("uf_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo_ctrc = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie_ctrc = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CTRC")))
                        reg.Nr_ctrc = reader.GetDecimal(reader.GetOrdinal("NR_CTRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_remetente")))
                        reg.Uf_remetente = reader.GetString(reader.GetOrdinal("uf_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_remetente")))
                        reg.Cnpj_remetente = reader.GetString(reader.GetOrdinal("cnpj_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_remetente")))
                        reg.Insc_estadual_remetente = reader.GetString(reader.GetOrdinal("insc_estadual_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao_nf")))
                        reg.Dt_emissao_nf = reader.GetDateTime(reader.GetOrdinal("dt_emissao_nf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo_nf")))
                        reg.Cd_modelo_nf = reader.GetString(reader.GetOrdinal("cd_modelo_nf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie_nf")))
                        reg.Nr_serie_nf = reader.GetString(reader.GetOrdinal("nr_serie_nf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_totalnota")))
                        reg.Vl_total_nf = reader.GetDecimal(reader.GetOrdinal("vl_totalnota"));
                    retorno.Add(reg);
                }
                return retorno;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }
    }
}
