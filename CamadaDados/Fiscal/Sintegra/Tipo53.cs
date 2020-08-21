using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo53
    {
        public string Tipo
        { get { return "53"; } }
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
                    return insc_estadual;
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
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public decimal Vl_despesas
        { get; set; }
        public string Situacao
        { get; set; }

        public Tipo53()
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
            this.Vl_basecalc = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_despesas = decimal.Zero;
            this.Situacao = string.Empty;
        }
    }

    public class TCD_Tipo53 : TDataQuery
    {
        public TCD_Tipo53() { }

        public TCD_Tipo53(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.Cnpj, a.Insc_Estadual, a.UF, ");
                sql.AppendLine("a.Nr_Serie, a.CD_Modelo, a.Dt_emissao_recebimento, ");
                sql.AppendLine("a.Nr_NotaFiscal, a.CD_CFOP, a.Tp_Nota, a.ST_Registro, ");
                sql.AppendLine("a.Vl_basecalcicms, a.Vl_icms, a.Vl_despesas ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG53 a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_emissao_recebimento ");
            return sql.ToString();
        }

        public List<Tipo53> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo53> retorno = new List<Tipo53>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo53 reg = new Tipo53();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao_recebimento")))
                        reg.Dt_emissao_recebimento = reader.GetDateTime(reader.GetOrdinal("dt_emissao_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.Situacao = reader.GetString(reader.GetOrdinal("st_registro")).Trim().ToUpper().Equals("C") ? "S" : "N";
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("Tp_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcicms")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_despesas"));
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
