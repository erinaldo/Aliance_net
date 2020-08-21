using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_CTRDuplicata : List<TRegistro_CTRDuplicata>
    { }

    
    public class TRegistro_CTRDuplicata
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lanctoctr
        { get; set; }
        
        public decimal? Nr_lanctoduplicata
        { get; set; }

        public TRegistro_CTRDuplicata()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_lanctoctr = null;
            this.Nr_lanctoduplicata = null;
        }
    }

    public class TCD_CTRDuplicata : TDataQuery
    {
        public TCD_CTRDuplicata()
        { }

        public TCD_CTRDuplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.nr_lanctoctr, a.nr_lanctoduplicata ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_Duplicata a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTRDuplicata Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (this.Banco_Dados == null)
            {
                this.CriarBanco_Dados(true);
            }
            TList_CTRDuplicata lista = new TList_CTRDuplicata();
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CTRDuplicata reg = new TRegistro_CTRDuplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoduplicata")))
                        reg.Nr_lanctoduplicata = reader.GetDecimal(reader.GetOrdinal("nr_lanctoduplicata"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string GravarCTRDuplicata(TRegistro_CTRDuplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_NR_LANCTODUPLICATA", val.Nr_lanctoduplicata);

            return this.executarProc("IA_CTR_DUPLICATA", hs);
        }

        public string DeletarCTRDuplicata(TRegistro_CTRDuplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_NR_LANCTODUPLICATA", val.Nr_lanctoduplicata);

            return this.executarProc("EXCLUI_CTR_DUPLICATA", hs);
        }
    }
}
