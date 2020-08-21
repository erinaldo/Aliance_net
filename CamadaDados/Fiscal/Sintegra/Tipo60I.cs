using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60I
    {
        public string Tipo
        { get { return "60"; } }
        public string Subtipo
        { get { return "I"; } }
        public string Cd_modelo
        { get; set; }
        public decimal? Nr_coo_ECF
        { get; set; }
        public decimal? Nr_item
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public string Tp_situacao
        { get; set; }
        public string St_substTrib
        { get; set; }
        public string Situacao_trib
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANC";
                else if (St_substTrib.Trim().ToUpper().Equals("S"))
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
        public string St_registro
        { get; set; }

        public Tipo60I()
        {
            this.Cd_modelo = string.Empty;
            this.Nr_coo_ECF = null;
            this.Nr_item = null;
            this.Cd_produto = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Pc_aliquota = decimal.Zero;
            this.St_registro = string.Empty;
            this.Vl_icms = decimal.Zero;
            this.Tp_situacao = string.Empty;
            this.St_substTrib = string.Empty;
        }
    }

    public class TCD_Tipo60I : TDataQuery
    {
        public TCD_Tipo60I() { }

        public TCD_Tipo60I(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Modelo, a.ID_COO_ECf, a.Nr_Sequencial_ECF, a.CD_Produto, ");
                sql.AppendLine("a.Quantidade, a.Vl_subtotal, a.Vl_basecalc, a.Pc_aliquota, a.Vl_icms, a.st_registro, ");
                sql.AppendLine("a.TP_Situacao, a.ST_SubstTrib ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG60I a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public List<Tipo60I> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo60I> retorno = new List<Tipo60I>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo60I reg = new Tipo60I();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_COO_ECf")))
                        reg.Nr_coo_ECF = reader.GetDecimal(reader.GetOrdinal("ID_COO_ECf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Sequencial_ECF")))
                        reg.Nr_item = reader.GetDecimal(reader.GetOrdinal("Nr_Sequencial_ECF"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
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
