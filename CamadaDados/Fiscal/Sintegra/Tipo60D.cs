using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60D
    {
        public string Tipo
        { get { return "60"; } }
        public string Subtipo
        { get { return "D"; } }
        public string Cd_produto
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
        public string Situacao_tributaria
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
        public decimal Vl_icms
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }

        public Tipo60D()
        {
            this.Cd_produto = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Pc_aliquota = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Tp_situacao = string.Empty;
            this.St_substTrib = string.Empty;
        }
    }

    public class TCD_Tipo60D : TDataQuery
    {
        public TCD_Tipo60D() { }

        public TCD_Tipo60D(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Produto, a.Pc_aliquota, ");
                sql.AppendLine("a.TP_Situacao, a.ST_SubstTrib, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Quantidade, 0)), 0) as Quantidade, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_subtotal, 0)), 0) as Vl_subtotal, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_basecalc, 0)), 0) as Vl_basecalc, ");
                sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_icms, 0)), 0) as Vl_icms ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_Reg60D a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("group by a.CD_Produto, a.Pc_aliquota, a.TP_Situacao, a.ST_SubstTrib ");
            sql.AppendLine("order by a.CD_Produto, a.Pc_aliquota ");
            return sql.ToString();
        }

        public List<Tipo60D> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo60D> retorno = new List<Tipo60D>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo60D reg = new Tipo60D();
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
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
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
