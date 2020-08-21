using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_PrecoANP : List<TRegistro_PrecoANP>, IComparer<TRegistro_PrecoANP>
    {
        #region IComparer<TRegistro_PrecoANP> Members
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

        public TList_PrecoANP()
        { }

        public TList_PrecoANP(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PrecoANP value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PrecoANP x, TRegistro_PrecoANP y)
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

    public class TRegistro_PrecoANP
    {
        private decimal? id_preco;
        
        public decimal? Id_preco
        {
            get { return id_preco; }
            set
            {
                id_preco = value;
                id_precostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_precostr;
        
        public string Id_precostr
        {
            get { return id_precostr; }
            set
            {
                id_precostr = value;
                try
                {
                    id_preco = decimal.Parse(value);
                }
                catch
                { id_preco = null; }
            }
        }
        
        public string Cd_combustivel
        { get; set; }
        
        public string Ds_combustivel
        { get; set; }
        
        public decimal Vl_preco
        { get; set; }
        private DateTime? dt_preco;
        
        public DateTime? Dt_preco
        {
            get { return dt_preco; }
            set
            {
                dt_preco = value;
                dt_precostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_precostr;
        public string Dt_precostr
        {
            get { return dt_precostr; }
            set
            {
                dt_precostr = value;
                try
                {
                    dt_preco = DateTime.Parse(value);
                }
                catch
                { dt_preco = null; }
            }
        }

        public TRegistro_PrecoANP()
        {
            this.id_preco = null;
            this.id_precostr = string.Empty;
            this.Cd_combustivel = string.Empty;
            this.Ds_combustivel = string.Empty;
            this.Vl_preco = decimal.Zero;
            this.dt_preco = DateTime.Now;
            this.dt_precostr = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    public class TCD_PrecoANP : TDataQuery
    {
        public TCD_PrecoANP()
        { }

        public TCD_PrecoANP(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_preco, a.cd_combustivel, ");
                sql.AppendLine("b.ds_produto as ds_combustivel, a.vl_preco, a.dt_preco ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_PrecoANP a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_combustivel = b.cd_produto ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_PrecoANP Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_PrecoANP lista = new TList_PrecoANP();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PrecoANP reg = new TRegistro_PrecoANP();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_preco")))
                        reg.Id_preco = reader.GetDecimal(reader.GetOrdinal("id_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_combustivel")))
                        reg.Cd_combustivel = reader.GetString(reader.GetOrdinal("cd_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_combustivel")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_preco")))
                        reg.Vl_preco = reader.GetDecimal(reader.GetOrdinal("vl_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_preco")))
                        reg.Dt_preco = reader.GetDateTime(reader.GetOrdinal("dt_preco"));

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

        public string Gravar(TRegistro_PrecoANP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_PRECO", val.Id_preco);
            hs.Add("@P_CD_COMBUSTIVEL", val.Cd_combustivel);
            hs.Add("@P_VL_PRECO", val.Vl_preco);
            hs.Add("@P_DT_PRECO", val.Dt_preco);

            return this.executarProc("IA_PDC_PRECOANP", hs);
        }

        public string Excluir(TRegistro_PrecoANP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_PRECO", val.Id_preco);
            hs.Add("@P_CD_COMBUSTIVEL", val.Cd_combustivel);

            return this.executarProc("EXCLUI_PDC_PRECOANP", hs);
        }
    }
}
