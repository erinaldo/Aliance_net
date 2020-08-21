using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_equipamento
        { get; set; }
        public decimal? Id_coo_ecf
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public decimal? Nr_sequencial_ecf
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Tp_situacao
        { get; set; }
        public string St_substtrib
        { get; set; }
        public string Situacao_tributaria
        {
            get
            {
                if (St_substtrib.Trim().ToUpper().Equals("S"))
                    return "F   ";
                else if (Tp_situacao.Trim().Equals("2"))
                    return "I   ";
                else if (Tp_situacao.Trim().Equals("3"))
                    return "N   ";
                else return Pc_aliquota.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).SoNumero().FormatStringEsquerda(4, '0');
            }
        }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }

        public Tipo60()
        {
            this.Cd_empresa = string.Empty;
            this.Id_equipamento = null;
            this.Id_coo_ecf = null;
            this.Dt_emissao = null;
            this.St_registro = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Nr_sequencial_ecf = null;
            this.Cd_produto = string.Empty;
            this.Tp_situacao = string.Empty;
            this.St_substtrib = string.Empty;
            this.Pc_aliquota = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
        }
    }

    public class TCD_Tipo60 : TDataQuery
    {
        public TCD_Tipo60() { }

        public TCD_Tipo60(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Equipamento, ");
                sql.AppendLine("a.ID_COO_ECF, a.DT_Emissao, a.ST_Registro, ");
                sql.AppendLine("a.CD_Modelo, a.Nr_Sequencial_ECF, a.CD_Produto, ");
                sql.AppendLine("a.TP_Situacao, a.ST_SubstTrib, a.PC_Aliquota, ");
                sql.AppendLine("a.Vl_BaseCalc, a.Vl_icms, a.Quantidade, a.Vl_Subtotal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_Reg60 a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public List<Tipo60> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo60> retorno = new List<Tipo60>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo60 reg = new Tipo60();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Equipamento")))
                        reg.Id_equipamento = reader.GetDecimal(reader.GetOrdinal("ID_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_COO_ECF")))
                        reg.Id_coo_ecf = reader.GetDecimal(reader.GetOrdinal("ID_COO_ECF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Sequencial_ECF")))
                        reg.Nr_sequencial_ecf = reader.GetDecimal(reader.GetOrdinal("Nr_Sequencial_ECF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("TP_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SubstTrib")))
                        reg.St_substtrib = reader.GetString(reader.GetOrdinal("ST_SubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_Subtotal"));

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
