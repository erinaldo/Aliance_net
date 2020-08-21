using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo70
    {
        public string Tipo
        {
            get
            {
                return "70";
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
        public DateTime? Dt_emissao_utilizacao
        { get; set; }
        public string Uf
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Nr_Serie
        { get; set; }
        public string Nr_subserie
        { get; set; }
        public decimal? Nr_documento
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_documento
        { get; set; }
        public decimal Vl_basecalcicms
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public Modalidade_frete Tp_frete
        { get; set; }
        public string Situacao
        { get; set; }

        public Tipo70()
        {
            this.Cnpj = string.Empty;
            this.insc_estadual = string.Empty;
            this.Dt_emissao_utilizacao = null;
            this.Uf = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Nr_Serie = string.Empty;
            this.Nr_subserie = string.Empty;
            this.Nr_documento = null;
            this.Cd_cfop = string.Empty;
            this.Vl_documento = decimal.Zero;
            this.Vl_basecalcicms = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Tp_frete = Modalidade_frete.OUTROS;
            this.Situacao = string.Empty;
        }
    }

    public class TCD_Tipo70 : TDataQuery
    {
        public TCD_Tipo70() { }

        public TCD_Tipo70(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cnpj, a.Insc_Estadual, a.dt_emissao_recebimento, ");
                sql.AppendLine("a.UF, a.CD_Modelo, a.Nr_Serie, a.NR_CTRC, a.CD_CFOP, ");
                sql.AppendLine("a.Vl_BaseCalcICMS, a.Vl_ICMS, a.Vl_Frete, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG70 a ");
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

        public List<Tipo70> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo70> retorno = new List<Tipo70>();
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
                    Tipo70 reg = new Tipo70();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao_recebimento")))
                        reg.Dt_emissao_utilizacao = reader.GetDateTime(reader.GetOrdinal("dt_emissao_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_Serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CTRC")))
                        reg.Nr_documento = reader.GetDecimal(reader.GetOrdinal("NR_CTRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcICMS")))
                        reg.Vl_basecalcicms = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.Situacao = reader.GetString(reader.GetOrdinal("ST_Registro")).ToString().Trim().ToUpper().Equals("C") ? "S" : "N";
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
