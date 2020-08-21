using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo74
    {
        public string Tipo
        { get { return "74"; } }
        public DateTime? Dt_inventario
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_medio
        { get; set; }
        public decimal Vl_produto
        { get { return Quantidade * Vl_medio; } }

        public Tipo74()
        {
            this.Dt_inventario = null;
            this.Cd_produto = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_medio = decimal.Zero;
        }
    }

    public class TCD_Tipo74 : TDataQuery
    {
        public TCD_Tipo74() { }

        public TCD_Tipo74(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Dt_inventario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.CD_Produto, ");
            sql.AppendLine("quantidade = ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
            sql.AppendLine("				from TB_EST_Estoque x ");
            sql.AppendLine("				where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and ISNULL(x.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("				and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("				and x.DT_Lancto <= '" + DateTime.Parse(Dt_inventario).ToString("yyyyMMdd") + " 23:59:59'" + "), 0), ");
            sql.AppendLine("vl_medio = dbo.F_CUSTO_MEDIOESTOQUE('" + Cd_empresa.Trim() + "', a.CD_Produto, '" + DateTime.Parse(Dt_inventario).ToString("yyyyMMdd") + " 23:59:59')");

            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_TpProduto b ");
            sql.AppendLine("on a.TP_Produto = b.TP_Produto ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Servico, 'N') <> 'S' ");
            sql.AppendLine("and ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
            sql.AppendLine("				from TB_EST_Estoque x ");
            sql.AppendLine("				where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and ISNULL(x.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("				and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("				and x.DT_Lancto <= '" + DateTime.Parse(Dt_inventario).ToString("yyyyMMdd") + " 23:59:59'" + "), 0) > 0 ");

            sql.AppendLine("order by a.cd_produto ");
            return sql.ToString();
        }

        public List<Tipo74> Select(string Cd_empresa, string Dt_inventario)
        {
            List<Tipo74> retorno = new List<Tipo74>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(Cd_empresa, Dt_inventario));
            try
            {
                while (reader.Read())
                {
                    Tipo74 reg = new Tipo74();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_medio")))
                        reg.Vl_medio = reader.GetDecimal(reader.GetOrdinal("vl_medio"));
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
