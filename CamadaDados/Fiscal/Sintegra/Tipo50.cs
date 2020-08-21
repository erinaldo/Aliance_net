using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo50
    {
        public string Tipo
        {
            get
            {
                return "50";
            }
        }
        public string Cnpj
        { get; set; }
        private string insc_estadual;
        public string Insc_estadual
        {
            get
            {
                if (insc_estadual.Trim().ToUpper() != "ISENTO")
                    return insc_estadual.Trim().SoNumero();
                else
                    return insc_estadual.Trim();
            }
            set
            {
                insc_estadual = value;
            }
        }
        public DateTime? Dt_emissao_recebimento
        { get; set; }
        public string Uf
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Nr_serie
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public string Tp_nota
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        public decimal Vl_basecalcicms
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public decimal Vl_isento_naotributado
        { get; set; }
        public decimal Vl_outros
        { get; set; }
        public decimal Pc_aliquota_icms
        { get; set; }
        public string Situacao_nf
        { get; set; }

        public Tipo50()
        {
            this.Cnpj = string.Empty;
            this.insc_estadual = string.Empty;
            this.Dt_emissao_recebimento = null;
            this.Uf = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Nr_serie = string.Empty;
            this.Nr_notafiscal = null;
            this.Cd_cfop = string.Empty;
            this.Tp_nota = string.Empty;
            this.Vl_totalnota = decimal.Zero;
            this.Vl_basecalcicms = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_isento_naotributado = decimal.Zero;
            this.Vl_outros = decimal.Zero;
            this.Situacao_nf = string.Empty;
        }
    }

    public class TCD_Tipo50 : TDataQuery
    {
        public TCD_Tipo50() { }

        public TCD_Tipo50(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cnpj, a.insc_estadual, a.uf, ");
                sql.AppendLine("a.cd_modelo, a.nr_serie, a.nr_notafiscal, ");
                sql.AppendLine("a.cd_cfop, a.tp_nota, a.dt_emissao_recebimento, ");
                sql.AppendLine("a.st_registro, a.Vl_TotalNota, a.pc_aliquota_icms, ");
                sql.AppendLine("a.vl_basecalc_icms, a.vl_icms, a.vl_isento_naotributado, a.vl_outros ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG50 a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_emissao_recebimento, a.cnpj, a.nr_notafiscal, a.nr_serie, a.cd_modelo ");
            return sql.ToString();
        }

        public List<Tipo50> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo50> retorno = new List<Tipo50>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo50 reg = new Tipo50();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("tp_nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao_recebimento")))
                        reg.Dt_emissao_recebimento = reader.GetDateTime(reader.GetOrdinal("dt_emissao_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.Situacao_nf = reader.GetString(reader.GetOrdinal("st_registro")).Trim().ToUpper().Equals("C") ? "S" : "N";
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalNota")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("Vl_TotalNota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota_icms")))
                        reg.Pc_aliquota_icms = reader.GetDecimal(reader.GetOrdinal("pc_aliquota_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalc_icms")))
                        reg.Vl_basecalcicms = reader.GetDecimal(reader.GetOrdinal("vl_basecalc_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_isento_naotributado")))
                        reg.Vl_isento_naotributado = reader.GetDecimal(reader.GetOrdinal("vl_isento_naotributado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_outros")))
                        reg.Vl_outros = reader.GetDecimal(reader.GetOrdinal("vl_outros"));

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
