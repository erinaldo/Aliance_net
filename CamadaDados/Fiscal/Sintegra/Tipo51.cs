using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo51
    {
        public string Tipo
        {
            get
            {
                return "51";
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
        public string Nr_serie
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        public decimal Vl_ipi
        { get; set; }
        public decimal Vl_isento_naotributado
        { get; set; }
        public decimal Vl_outros
        { get; set; }
        public string Situacao
        { get; set; }

        public Tipo51()
        {
            this.Cnpj = string.Empty;
            this.insc_estadual = string.Empty;
            this.Dt_emissao_recebimento = null;
            this.Uf = string.Empty;
            this.Nr_serie = string.Empty;
            this.Nr_notafiscal = null;
            this.Cd_cfop = string.Empty;
            this.Vl_totalnota = decimal.Zero;
            this.Vl_ipi = decimal.Zero;
            this.Vl_isento_naotributado = decimal.Zero;
            this.Vl_outros = decimal.Zero;
            this.Situacao = string.Empty;
        }
    }

    public class TCD_Tipo51 : TDataQuery
    {
        public TCD_Tipo51() { }

        public TCD_Tipo51(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cnpj, a.insc_estadual, a.uf, ");
                sql.AppendLine("a.nr_serie, a.nr_notafiscal, a.cd_cfop, ");
                sql.AppendLine("a.dt_emissao_recebimento, a.st_registro, ");
                sql.AppendLine("a.Vl_TotalNota, a.vl_ipi, a.vl_isento_naotributado, a.vl_outros ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG51 a ");
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

        public List<Tipo51> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo51> retorno = new List<Tipo51>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo51 reg = new Tipo51();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao_recebimento")))
                        reg.Dt_emissao_recebimento = reader.GetDateTime(reader.GetOrdinal("dt_emissao_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.Situacao = reader.GetString(reader.GetOrdinal("st_registro")).Trim().ToUpper().Equals("C") ? "S" : "N";
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalNota")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("Vl_TotalNota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ipi")))
                        reg.Vl_ipi = reader.GetDecimal(reader.GetOrdinal("vl_ipi"));
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
