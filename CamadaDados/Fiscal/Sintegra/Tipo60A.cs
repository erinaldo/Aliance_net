using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo60A
    {
        public string Tipo
        { get { return "60"; } }
        public string Subtipo
        { get { return "A"; } }
        public string Cd_totalizador
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public string Nr_serie_equipamento
        { get; set; }
        public string Situacao_tributaria
        {
            get
            {
                if (Cd_totalizador.Trim().ToUpper().Equals("F"))
                    return "F   ";
                else if (Cd_totalizador.Trim().ToUpper().Equals("I"))
                    return "I   ";
                else return Cd_totalizador.Trim().FormatStringDireita(4, '0');
            }
        }
        public decimal Vl_totalizador
        { get; set; }

        public Tipo60A()
        {
            this.Cd_totalizador = string.Empty;
            this.Dt_emissao = null;
            this.Nr_serie_equipamento = string.Empty;
            this.Vl_totalizador = decimal.Zero;
        }
    }

    public class TCD_Tipo60A : TDataQuery
    {
        public TCD_Tipo60A() { }

        public TCD_Tipo60A(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(string Id_mapa, string Id_equipamento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.DT_Mapa, c.NR_Serie, ");
            sql.AppendLine("b.CD_Totalizador, b.Vl_Totalizador ");
            
            sql.AppendLine("from TB_PDV_MapaResumo a ");
            sql.AppendLine("inner join TB_PDV_TotalizadorMapa b ");
            sql.AppendLine("on a.ID_Mapa = b.ID_Mapa ");
            sql.AppendLine("inner join TB_PDV_EmissorCF c ");
            sql.AppendLine("on a.ID_Equipamento = c.ID_Equipamento ");

            sql.AppendLine("where a.id_mapa = " + Id_mapa);
            sql.AppendLine("and a.id_equipamento = " + Id_equipamento);
            sql.AppendLine("order by a.dt_mapa, c.nr_serie ");
            return sql.ToString();
        }

        public List<Tipo60A> Select(string Id_mapa, string Id_equipamento)
        {
            List<Tipo60A> retorno = new List<Tipo60A>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(Id_mapa, Id_equipamento));
            try
            {
                while (reader.Read())
                {
                    Tipo60A reg = new Tipo60A();
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Mapa")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Mapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serie")))
                        reg.Nr_serie_equipamento = reader.GetString(reader.GetOrdinal("Nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Totalizador")))
                        reg.Cd_totalizador = reader.GetString(reader.GetOrdinal("CD_Totalizador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Totalizador")))
                        reg.Vl_totalizador = reader.GetDecimal(reader.GetOrdinal("Vl_Totalizador"));

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
