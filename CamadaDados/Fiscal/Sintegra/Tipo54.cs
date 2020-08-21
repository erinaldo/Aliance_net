using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo54
    {
        public string Tipo
        {
            get
            {
                return "54";
            }
        }
        public string Cnpj
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Nr_serie
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public string Cd_st
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc_icms
        { get; set; }
        public decimal Vl_basecalc_icmssubsttrib
        { get; set; }
        public decimal Pc_aliquotaicms
        { get; set; }

        public Tipo54()
        {
            this.Cnpj = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Nr_serie = string.Empty;
            this.Nr_notafiscal = null;
            this.Nr_lanctofiscal = null;
            this.Cd_cfop = string.Empty;
            this.Cd_st = string.Empty;
            this.Id_nfitem = null;
            this.Cd_produto = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_basecalc_icms = decimal.Zero;
            this.Vl_basecalc_icmssubsttrib = decimal.Zero;
            this.Pc_aliquotaicms = decimal.Zero;
        }
    }

    public class TCD_Tipo54 : TDataQuery
    {
        public TCD_Tipo54() { }

        public TCD_Tipo54(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cnpj, a.cd_modelo, a.nr_serie, ");
                sql.AppendLine("a.nr_notafiscal, a.nr_lanctofiscal, a.cd_cfop, a.id_nfitem, ");
                sql.AppendLine("a.cd_produto, a.quantidade, a.vl_subtotal, ");
                sql.AppendLine("a.cd_st, a.vl_basecalc_icms, a.vl_basecalcsubsttrib, a.pc_aliquota_icms ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG54 a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_emissao_recebimento, a.cnpj, a.nr_notafiscal, a.nr_serie, a.cd_modelo, a.id_nfitem ");
            return sql.ToString();
        }

        public List<Tipo54> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo54> retorno = new List<Tipo54>();
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
                    Tipo54 reg = new Tipo54();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_st"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalc_icms")))
                        reg.Vl_basecalc_icms = reader.GetDecimal(reader.GetOrdinal("vl_basecalc_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcsubsttrib")))
                        reg.Vl_basecalc_icmssubsttrib = reader.GetDecimal(reader.GetOrdinal("vl_basecalcsubsttrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota_icms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("pc_aliquota_icms"));

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
