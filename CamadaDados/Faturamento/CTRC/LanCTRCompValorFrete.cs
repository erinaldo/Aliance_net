using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_CTRCompValorFrete : List<TRegistro_CTRCompValorFrete> { }

    public class TRegistro_CTRCompValorFrete
    {
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctoctr;
        public decimal? Nr_lanctoctr
        {
            get { return nr_lanctoctr; }
            set
            {
                nr_lanctoctr = value;
                nr_lanctoctrstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoctrstr;
        public string Nr_lanctoctrstr
        {
            get { return nr_lanctoctrstr; }
            set
            {
                nr_lanctoctrstr = value;
                try
                {
                    nr_lanctoctr = decimal.Parse(value);
                }
                catch { nr_lanctoctr = null; }
            }
        }
        private decimal? id_componente;
        public decimal? Id_componente
        {
            get { return id_componente; }
            set
            {
                id_componente = value;
                id_componentestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_componentestr;
        public string Id_componentestr
        {
            get { return id_componentestr; }
            set
            {
                id_componentestr = value;
                try
                {
                    id_componente = decimal.Parse(value);
                }
                catch { id_componente = null; }
            }
        }
        public string Nm_componente
        { get; set; }
        public decimal Vl_componente
        { get; set; }

        public TRegistro_CTRCompValorFrete()
        {
            this.Cd_empresa = string.Empty;
            this.nr_lanctoctr = null;
            this.nr_lanctoctrstr = string.Empty;
            this.id_componente = null;
            this.id_componentestr = string.Empty;
            this.Nm_componente = string.Empty;
            this.Vl_componente = decimal.Zero;
        }
    }

    public class TCD_CTRCompValorFrete : TDataQuery
    {
        public TCD_CTRCompValorFrete() { }

        public TCD_CTRCompValorFrete(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctoctr, ");
                sql.AppendLine("a.id_componente, a.nm_componente, a.vl_componente ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ctr_compvalorfrete a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTRCompValorFrete Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CTRCompValorFrete lista = new TList_CTRCompValorFrete();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CTRCompValorFrete reg = new TRegistro_CTRCompValorFrete();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_componente")))
                        reg.Id_componente = reader.GetDecimal(reader.GetOrdinal("id_componente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_componente")))
                        reg.Nm_componente = reader.GetString(reader.GetOrdinal("nm_componente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_componente")))
                        reg.Vl_componente = reader.GetDecimal(reader.GetOrdinal("vl_componente"));

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

        public string Gravar(TRegistro_CTRCompValorFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_COMPONENTE", val.Id_componente);
            hs.Add("@P_NM_COMPONENTE", val.Nm_componente);
            hs.Add("@P_VL_COMPONENTE", val.Vl_componente);

            return this.executarProc("IA_CTR_COMPVALORFRETE", hs);
        }

        public string Excluir(TRegistro_CTRCompValorFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_COMPONENTE", val.Id_componente);

            return this.executarProc("EXCLUI_CTR_COMPVALORFRETE", hs);
        }
    }
}
