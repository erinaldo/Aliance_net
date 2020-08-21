using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Relatorios
{
    public class TList_PortadorReceber : List<TRegistro_PortadorReceber>
    { }

    public class TRegistro_PortadorReceber
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Portador
        { get; set; }
        public DateTime? Periodo_Inicial
        { get; set; }
        public DateTime? Periodo_Final
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_PortadorReceber()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Periodo_Inicial = null;
            this.Periodo_Final = null;
            this.Valor = decimal.Zero;
        }
    }
    public class TList_ChequeReceber : List<TRegistro_ChequeReceber>
    { }

    public class TRegistro_ChequeReceber
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Periodo
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_ChequeReceber()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Periodo = string.Empty;
            this.Valor = decimal.Zero;
        }
    }

    public class TList_CartaoReceber : List<TRegistro_CartaoReceber>
    { }

    public class TRegistro_CartaoReceber
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Periodo
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_CartaoReceber()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Periodo = string.Empty;
            this.Valor = decimal.Zero;
        }
    }

    public class TList_DuplicataReceber : List<TRegistro_DuplicataReceber>
    { }

    public class TRegistro_DuplicataReceber
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Periodo
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_DuplicataReceber()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Periodo = string.Empty;
            this.Valor = decimal.Zero;
        }
    }

    public class TList_BoletoReceber : List<TRegistro_BoletoReceber>
    { }

    public class TRegistro_BoletoReceber
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Periodo
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_BoletoReceber()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Periodo = string.Empty;
            this.Valor = decimal.Zero;
        }
    }

    public class TCD_PortadorReceber : TDataQuery
    {
        public TCD_PortadorReceber()
        {
        }

        public TCD_PortadorReceber(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlBuscaChequesReceber(TpBusca[] vBusca, string startWeek)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("set DateFirst " + startWeek);
            sql.AppendLine("SELECT x.cd_empresa, b.NM_Empresa,  DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) AS PERIODO,  ");
            sql.AppendLine("SUM(ISNULL(x.vl_titulo, 0)) AS Valor ");
            sql.AppendLine("From VTB_FIN_Titulo x ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("Where (isnull(x.status_compensado, 'N') = 'N' ) ");
            sql.AppendLine("and x.tp_titulo = 'R' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("group by x.cd_empresa, b.NM_Empresa, DATEPART(YEAR, X.DT_VENCTO), DATEPART(WEEK, X.DT_VENCTO), DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) ");
            sql.AppendLine("order by DATEPART(YEAR, X.DT_VENCTO) desc, DATEPART(WEEK, X.DT_VENCTO) desc ");
            sql.AppendLine("set DateFirst 7 ");
            return sql.ToString();
        }

        public TList_ChequeReceber SelectChequesReceber(TpBusca[] vBusca, string starWeek)
        {
            bool podeFecharBco = false;
            TList_ChequeReceber lista = new TList_ChequeReceber();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlBuscaChequesReceber(vBusca, starWeek));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ChequeReceber reg = new TRegistro_ChequeReceber();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Periodo"))))
                        reg.Periodo = reader.GetString(reader.GetOrdinal("Periodo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Valor"))))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));

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

        private string SqlBuscaCartaoReceber(TpBusca[] vBusca, string startWeek)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("set DateFirst " + startWeek);
            sql.AppendLine("select x.cd_empresa, b.NM_Empresa, ");
            sql.AppendLine("DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) AS PERIODO, ");
            sql.AppendLine("sum(((isnull(x.Vl_nominal, 0) + isnull(x.vl_juro, 0)) - ");
            sql.AppendLine("round((isnull(x.vl_nominal, 0) + isnull(x.vl_juro, 0) - ");
            sql.AppendLine("isnull(x.vl_quitado, 0)) * (isnull(d.pc_taxa, 0) / 100), 2)) - ");
            sql.AppendLine("isnull(x.vl_quitado, 0)) as Valor ");
            sql.AppendLine("from VTB_FIN_FaturaCartao x ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on x.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_BandeiraCartao c ");
            sql.AppendLine("on x.ID_Bandeira = c.ID_Bandeira ");
            sql.AppendLine("left outer join TB_FIN_TaxaBandeira d ");
            sql.AppendLine("on x.CD_Empresa = d.cd_empresa ");
            sql.AppendLine("and x.ID_Bandeira = d.id_bandeira ");
            sql.AppendLine("where(x.tp_movimento = 'R')  ");
            sql.AppendLine("and(vl_nominal - vl_quitado > 0) ");
            sql.AppendLine("and c.tp_cartao = 'C' ");
            

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("group by x.cd_empresa, b.NM_Empresa, DATEPART(YEAR, X.DT_VENCTO), DATEPART(WEEK, X.DT_VENCTO), DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) ");
            sql.AppendLine("order by DATEPART(YEAR, X.DT_VENCTO) desc, DATEPART(WEEK, X.DT_VENCTO) desc ");
            sql.AppendLine("set DateFirst 7 ");
            return sql.ToString();
        }

        public TList_CartaoReceber SelectCartaoReceber(TpBusca[] vBusca, string starWeek)
        {
            bool podeFecharBco = false;
            TList_CartaoReceber lista = new TList_CartaoReceber();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlBuscaCartaoReceber(vBusca, starWeek));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CartaoReceber reg = new TRegistro_CartaoReceber();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Periodo"))))
                        reg.Periodo = reader.GetString(reader.GetOrdinal("Periodo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Valor"))))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));

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

        private string SqlBuscaDuplicataReceber(TpBusca[] vBusca, string startWeek)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("set DateFirst " + startWeek);
            sql.AppendLine("SELECT x.cd_empresa, b.NM_Empresa, ");
            sql.AppendLine("DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) AS PERIODO, ");
            sql.AppendLine("SUM(ISNULL(x.vl_atual, 0)) as Valor ");
            sql.AppendLine("FROM VTB_FIN_Parcela x ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on x.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Duplicata dup ");
            sql.AppendLine("on x.cd_empresa = dup.cd_empresa ");
            sql.AppendLine("and x.nr_lancto = dup.nr_lancto ");
            sql.AppendLine("where isnull(x.ST_Registro, 'A') in ('A', 'P') ");
            sql.AppendLine("and isnull(dup.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and x.TP_Mov = 'R' ");
            sql.AppendLine("and not exists(select 1 from TB_COB_Titulo y ");
            sql.AppendLine("                 where x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("                 and x.Nr_Lancto = y.Nr_Lancto ");
            sql.AppendLine("                 and x.CD_Parcela = y.CD_Parcela ");
            sql.AppendLine("                 and ISNULL(y.ST_Registro, 'A') <> 'C') ");


            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("group by x.cd_empresa, b.NM_Empresa, DATEPART(YEAR, X.DT_VENCTO), DATEPART(WEEK, X.DT_VENCTO), DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, x.dt_vencto))), DATEPART(WEEK, X.DT_VENCTO)) ");
            sql.AppendLine("order by DATEPART(YEAR, X.DT_VENCTO) desc, DATEPART(WEEK, X.DT_VENCTO) desc ");
            sql.AppendLine("set DateFirst 7 ");
            return sql.ToString();
        }

        public TList_DuplicataReceber SelectDuplicataReceber(TpBusca[] vBusca, string starWeek)
        {
            bool podeFecharBco = false;
            TList_DuplicataReceber lista = new TList_DuplicataReceber();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlBuscaDuplicataReceber(vBusca, starWeek));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DuplicataReceber reg = new TRegistro_DuplicataReceber();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Periodo"))))
                        reg.Periodo = reader.GetString(reader.GetOrdinal("Periodo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Valor"))))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));

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

        private string SqlBuscaBoletoReceber(TpBusca[] vBusca, string startWeek)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("set DateFirst " + startWeek);
            sql.AppendLine("SELECT x.cd_empresa, b.NM_Empresa, ");
            sql.AppendLine("DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, y.dt_vencto))), DATEPART(WEEK, y.DT_VENCTO)) AS PERIODO, ");
            sql.AppendLine("SUM(ISNULL(y.vl_atual, 0)) as Valor ");
            sql.AppendLine("FROM TB_COB_Titulo x ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on x.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_Parcela y ");
            sql.AppendLine("on x.cd_empresa = y.CD_Empresa ");
            sql.AppendLine("and x.Nr_Lancto = y.Nr_Lancto ");
            sql.AppendLine("and x.CD_Parcela = y.CD_Parcela ");
            sql.AppendLine("where isnull(x.ST_Registro, 'A') = 'A' ");


            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("group by x.cd_empresa, b.NM_Empresa, DATEPART(YEAR, y.DT_VENCTO), DATEPART(WEEK, y.DT_VENCTO), DBO.F_PERIODOSEMANA(convert(varchar(4), (DATEPART(year, y.dt_vencto))), DATEPART(WEEK, y.DT_VENCTO)) ");
            sql.AppendLine("order by DATEPART(YEAR, y.DT_VENCTO) desc, DATEPART(WEEK, y.DT_VENCTO) desc ");
            sql.AppendLine("set DateFirst 7 ");
            return sql.ToString();
        }

        public TList_BoletoReceber SelectBoletoReceber(TpBusca[] vBusca, string starWeek)
        {
            bool podeFecharBco = false;
            TList_BoletoReceber lista = new TList_BoletoReceber();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlBuscaBoletoReceber(vBusca, starWeek));
            try
            {
                while (reader.Read())
                {
                    TRegistro_BoletoReceber reg = new TRegistro_BoletoReceber();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Periodo"))))
                        reg.Periodo = reader.GetString(reader.GetOrdinal("Periodo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Valor"))))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));

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
    }
}
