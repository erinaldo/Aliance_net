using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_ResumoFiscal : List<TRegistro_ResumoFiscal>
    { }

    
    public class TRegistro_ResumoFiscal
    {
        
        public string Uf
        { get; set; }
        
        public string Ds_uf
        { get; set; }
        
        public decimal Vl_contabil
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }
        
        public decimal Vl_icms
        { get; set; }
        
        public decimal Vl_icms_subst
        { get; set; }
        
        public decimal Vl_isentas
        { get; set; }
        
        public decimal Vl_outros
        { get; set; }

        public TRegistro_ResumoFiscal()
        {
            this.Uf = string.Empty;
            this.Ds_uf = string.Empty;
            this.Vl_contabil = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_icms_subst = decimal.Zero;
            this.Vl_isentas = decimal.Zero;
            this.Vl_outros = decimal.Zero;
        }
    }
        
    public class TList_ApuracaoFiscal : List<TRegistro_ApuracaoFiscal>
    { }

    
    public class TRegistro_ApuracaoFiscal
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nr_cnpj
        { get; set; }
        
        public string Insc_estadual
        { get; set; }
        
        public string Cd_cfop
        { get; set; }
        
        public string Ds_cfop
        { get; set; }
        
        public string Estado
        { get; set; }
        
        public decimal Vl_icms
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }
        
        public decimal Vl_contabil
        { get; set; }
        
        public decimal Vl_isentas
        { get; set; }
        
        public decimal Vl_outras
        { get; set; }
        
        public string Tp_movimento
        { get; set; }
        
        public TRegistro_ApuracaoFiscal()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_cnpj = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Cd_cfop = string.Empty;
            this.Ds_cfop = string.Empty;
            this.Estado = string.Empty;
            this.Vl_icms = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_contabil = decimal.Zero;
            this.Vl_isentas = decimal.Zero;
            this.Vl_outras = decimal.Zero;
            this.Tp_movimento = string.Empty;
        }
    }
        
    public class TCD_ApuracaoImpostos : TDataQuery
    {
        private string SqlCodeBuscaApuracaoFiscal(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, d.nm_empresa, ");
            sql.AppendLine("e.nr_cgc, f.insc_estadual, a.CD_CFOP, C.DS_CFOP, ");
            sql.AppendLine("SUM(CONVERT(numeric(15,2),a.VL_ICMS)) AS VL_ICMS, ");
            sql.AppendLine("SUM(CONVERT(numeric(15,2),a.VL_BASECALC)) AS VL_BASECALC, ");
            sql.AppendLine("SUM(CONVERT(numeric(15,2),a.VL_Contabil)) AS VL_CONTABIL, ");
            sql.AppendLine("SUM(CONVERT(numeric(15,2),a.VL_Isentas)) AS VL_ISENTAS, ");
            sql.AppendLine("SUM(CONVERT(numeric(15,2),a.VL_Outros)) AS VL_OUTROS, ");
            sql.AppendLine("a.TP_Movimento ");

            sql.AppendLine("FROM TB_FIS_LIVROFISCAL A ");
            sql.AppendLine("INNER JOIN TB_FAT_SERIENF B ");
            sql.AppendLine("ON A.NR_SERIE = B.NR_SERIE ");
            sql.AppendLine("AND A.CD_MODELO = B.CD_MODELO ");
            sql.AppendLine("INNER JOIN TB_FIS_CFOP C ");
            sql.AppendLine("ON A.CD_CFOP = C.CD_CFOP ");
            sql.AppendLine("INNER JOIN TB_DIV_EMPRESA D ");
            sql.AppendLine("ON A.CD_EMPRESA = D.CD_EMPRESA ");
            sql.AppendLine("INNER JOIN VTB_FIN_CLIFOR E ");
            sql.AppendLine("ON D.CD_CLIFOR = E.CD_CLIFOR ");
            sql.AppendLine("INNER JOIN VTB_FIN_ENDERECO F ");
            sql.AppendLine("ON D.CD_CLIFOR = F.CD_CLIFOR ");
            sql.AppendLine("AND D.CD_ENDERECO = F.CD_ENDERECO ");
                       
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("GROUP BY a.cd_empresa, d.nm_empresa, ");
            sql.AppendLine("e.nr_cgc, f.insc_estadual, a.cd_cfop, c.ds_cfop, a.CD_empresa, a.TP_Movimento ");

            return sql.ToString();
        }

        private string SqlCodeBuscaResumoFiscal(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.UF, b.DS_UF, ");
            sql.AppendLine("sum(isnull(a.Vl_contabil, 0)) as vl_contabil, ");
            sql.AppendLine("sum(isnull(A.Vl_BaseCalc, 0)) as VL_BASECALC,");
            sql.AppendLine("sum(isnull(a.Vl_icms, 0)) as VL_ICMS,");
            sql.AppendLine("sum(isnull(a.vl_icms_subst, 0)) as Vl_ICMS_Subst, ");
            sql.AppendLine("sum(isnull(a.vl_isentas, 0)) as Vl_isentas, ");
            sql.AppendLine("sum(isnull(a.Vl_Outros, 0)) as Vl_outros ");

            sql.AppendLine("FROM TB_FIS_LIVROFISCAL a ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = b.CD_Endereco ");
            sql.AppendLine("inner join TB_FAT_SerieNF c ");
            sql.AppendLine("on a.Nr_Serie = c.Nr_Serie ");
            sql.AppendLine("and a.cd_modelo = c.cd_modelo ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("group by a.UF, b.DS_UF ");
            return sql.ToString();
        }

        public TList_ApuracaoFiscal SelectApuracaoFiscal(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_ApuracaoFiscal lista = new TList_ApuracaoFiscal();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaApuracaoFiscal(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ApuracaoFiscal reg = new TRegistro_ApuracaoFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Nr_cnpj = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfop")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("ds_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contabil")))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("vl_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALC")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("VL_BASECALC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("VL_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_isentas")))
                        reg.Vl_isentas = reader.GetDecimal(reader.GetOrdinal("Vl_isentas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_outros")))
                        reg.Vl_outras = reader.GetDecimal(reader.GetOrdinal("Vl_outros"));
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public TList_ResumoFiscal SelectResumoFiscal(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_ResumoFiscal lista = new TList_ResumoFiscal();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaResumoFiscal(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ResumoFiscal reg = new TRegistro_ResumoFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UF")))
                        reg.Ds_uf = reader.GetString(reader.GetOrdinal("DS_UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contabil")))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("vl_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALC")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("VL_BASECALC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("VL_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ICMS_Subst")))
                        reg.Vl_icms_subst = reader.GetDecimal(reader.GetOrdinal("Vl_ICMS_Subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_isentas")))
                        reg.Vl_isentas = reader.GetDecimal(reader.GetOrdinal("Vl_isentas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_outros")))
                        reg.Vl_outros = reader.GetDecimal(reader.GetOrdinal("Vl_outros"));
                    lista.Add(reg);
                }
                return lista;
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
