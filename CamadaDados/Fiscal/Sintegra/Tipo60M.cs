using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60M
    {
        public string Tipo
        { get { return "60"; } }
        public string Subtipo
        { get { return "M"; } }
        public decimal? Id_mapa
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public string Nr_serie_equipamento
        { get; set; }
        public decimal? Id_equipamento
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public decimal? Nr_coo_inicial
        { get; set; }
        public decimal? Nr_coo_final
        { get; set; }
        public decimal? Contador_reducaoZ
        { get; set; }
        public decimal? Contador_reinicio_operacao
        { get; set; }
        public decimal Vl_vendabruta
        { get; set; }
        public decimal Vl_totalgeral
        { get; set; }

        public Tipo60M()
        {
            this.Id_mapa = null;
            this.Dt_emissao = null;
            this.Nr_serie_equipamento = string.Empty;
            this.Id_equipamento = null;
            this.Cd_modelo = string.Empty;
            this.Nr_coo_inicial = null;
            this.Nr_coo_final = null;
            this.Contador_reducaoZ = null;
            this.Contador_reinicio_operacao = null;
            this.Vl_vendabruta = decimal.Zero;
            this.Vl_totalgeral = decimal.Zero;
        }
    }

    public class TCD_Tipo60M : TDataQuery
    {
        public TCD_Tipo60M() { }

        public TCD_Tipo60M(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Mapa, a.DT_Mapa, b.NR_Serie as Nr_serie_equipamento, ");
                sql.AppendLine("a.ID_Equipamento, a.NR_COO_Inicial, a.NR_COO_Final, ");
                sql.AppendLine("a.Contador_ReducaoZ, a.Contador_Reinicio_Operacao, ");
                sql.AppendLine("(isnull(a.Vl_VendaBruta, 0) - isnull(a.Vl_DescontoICMS, 0) - isnull(a.vl_cancelamentoICMS, 0)) as Vl_VendaBruta, a.Vl_TotalGeral, ");
                sql.AppendLine("cd_modelo = (select top 1 x.CD_Modelo ");
                sql.AppendLine("				from TB_PDV_CupomFiscal x ");
                sql.AppendLine("				where x.ID_Equipamento = a.ID_Equipamento) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_MapaResumo a ");
            sql.AppendLine("inner join TB_PDV_EmissorCF b ");
            sql.AppendLine("on a.ID_Equipamento = b.ID_Equipamento ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_mapa, b.nr_serie ");
            return sql.ToString();
        }

        public List<Tipo60M> Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            List<Tipo60M> retorno = new List<Tipo60M>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tipo60M reg = new Tipo60M();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mapa")))
                        reg.Id_mapa = reader.GetDecimal(reader.GetOrdinal("ID_Mapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Mapa")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Mapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serie_equipamento")))
                        reg.Nr_serie_equipamento = reader.GetString(reader.GetOrdinal("Nr_serie_equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Equipamento")))
                        reg.Id_equipamento = reader.GetDecimal(reader.GetOrdinal("ID_Equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_COO_Inicial")))
                        reg.Nr_coo_inicial = reader.GetDecimal(reader.GetOrdinal("NR_COO_Inicial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_COO_Final")))
                        reg.Nr_coo_final = reader.GetDecimal(reader.GetOrdinal("NR_COO_Final"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Contador_ReducaoZ")))
                        reg.Contador_reducaoZ = reader.GetDecimal(reader.GetOrdinal("Contador_ReducaoZ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Contador_Reinicio_Operacao")))
                        reg.Contador_reinicio_operacao = reader.GetDecimal(reader.GetOrdinal("Contador_Reinicio_Operacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_VendaBruta")))
                        reg.Vl_vendabruta = reader.GetDecimal(reader.GetOrdinal("Vl_VendaBruta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalGeral")))
                        reg.Vl_totalgeral = reader.GetDecimal(reader.GetOrdinal("Vl_TotalGeral"));

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
