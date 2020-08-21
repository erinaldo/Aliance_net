using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_ProximaEtapa : List<TRegistro_ProximaEtapa>, IComparer<TRegistro_ProximaEtapa>
    {
        #region IComparer<TRegistro_ProximaEtapa> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProximaEtapa()
        { }

        public TList_ProximaEtapa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProximaEtapa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProximaEtapa x, TRegistro_ProximaEtapa y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    
    public class TRegistro_ProximaEtapa
    {
        private decimal? id_etapa;
        
        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;
        
        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        
        public string Ds_etapa
        { get; set; }
        private decimal? id_proximaetapa;
        
        public decimal? Id_proximaetapa
        {
            get { return id_proximaetapa; }
            set
            {
                id_proximaetapa = value;
                id_proximaetapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_proximaetapastr;
        
        public string Id_proximaetapastr
        {
            get { return id_proximaetapastr; }
            set
            {
                id_proximaetapastr = value;
                try
                {
                    id_proximaetapa = decimal.Parse(value);
                }
                catch
                { id_proximaetapa = null; }
            }
        }
        
        public string Ds_proximaetapa
        { get; set; }

        public TRegistro_ProximaEtapa()
        {
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.Ds_etapa = string.Empty;
            this.id_proximaetapa = null;
            this.id_proximaetapastr = string.Empty;
            this.Ds_proximaetapa = string.Empty;
        }
    }

    public class TCD_ProximaEtapa : TDataQuery
    {
        public TCD_ProximaEtapa()
        { }

        public TCD_ProximaEtapa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_etapa, b.ds_etapa, ");
                sql.AppendLine("a.id_proximaetapa, c.ds_etapa as ds_proximaetapa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_ose_proximaetapa a ");
            sql.AppendLine("inner join tb_ose_etapaordem b ");
            sql.AppendLine("on a.id_etapa = b.id_etapa ");
            sql.AppendLine("inner join tb_ose_etapaordem c ");
            sql.AppendLine("on a.id_proximaetapa = c.id_etapa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_ProximaEtapa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ProximaEtapa lista = new TList_ProximaEtapa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ProximaEtapa reg = new TRegistro_ProximaEtapa();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        reg.Ds_etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_proximaetapa")))
                        reg.Id_proximaetapa = reader.GetDecimal(reader.GetOrdinal("id_proximaetapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_proximaetapa")))
                        reg.Ds_proximaetapa = reader.GetString(reader.GetOrdinal("ds_proximaetapa"));

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

        public string Gravar(TRegistro_ProximaEtapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_ID_PROXIMAETAPA", val.Id_proximaetapa);

            return this.executarProc("IA_OSE_PROXIMAETAPA", hs);
        }

        public string Excluir(TRegistro_ProximaEtapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_ID_PROXIMAETAPA", val.Id_proximaetapa);

            return this.executarProc("EXCLUI_OSE_PROXIMAETAPA", hs);
        }
    }
}
