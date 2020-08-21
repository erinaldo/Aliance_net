using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60R
    {
        public string Tipo
        { get { return "60"; } }
        public string Subtipo
        { get { return "R"; } }
        public int Mes
        { get; set; }
        public int Ano
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public string Tp_situacao
        { get; set; }
        public string St_substTrib
        { get; set; }
        public string Situacao_trib
        {
            get
            {
                if (St_substTrib.Trim().ToUpper().Equals("S"))
                    return "F   ";
                else if (Tp_situacao.Trim().Equals("2"))
                    return "I   ";
                else if (Tp_situacao.Trim().Equals("3"))
                    return "N   ";
                else return Pc_aliquota.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).SoNumero().FormatStringEsquerda(4, '0');
            }
        }

        public Tipo60R()
        {
            this.Mes = 0;
            this.Ano = 0;
            this.Cd_produto = string.Empty;
            this.Pc_aliquota = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Tp_situacao = string.Empty;
            this.St_substTrib = string.Empty;
        }
    }

    public class TCD_Tipo60R : TDataQuery
    {
        public TCD_Tipo60R() { }

        public TCD_Tipo60R(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " MONTH(a.DT_Emissao) as Mes, ");
                sql.AppendLine("YEAR(a.DT_Emissao) as Ano, a.CD_Produto, a.Pc_aliquota, ");
                sql.AppendLine("a.TP_Situacao, a.ST_SubstTrib, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Quantidade, 0)), 0) as Quantidade, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_subtotal, 0)), 0) as Vl_subtotal, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_basecalc, 0)), 0) as Vl_basecalc ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG60R a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("group by MONTH(a.DT_Emissao), YEAR(a.DT_Emissao), a.CD_Produto, a.Pc_aliquota, a.TP_Situacao, a.ST_SubstTrib ");
            sql.AppendLine("order by MONTH(a.DT_Emissao), YEAR(a.DT_Emissao), a.CD_Produto ");
            return sql.ToString();
        }

        public List<Tipo60R> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo60R> retorno = new List<Tipo60R>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo60R reg = new Tipo60R();
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetInt32(reader.GetOrdinal("Mes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetInt32(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("pc_aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("TP_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SubstTrib")))
                        reg.St_substTrib = reader.GetString(reader.GetOrdinal("ST_SubstTrib"));

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
