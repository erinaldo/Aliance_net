using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_Trans_X_UnidPag : List<TRegistro_Trans_X_UnidPag>, IComparer<TRegistro_Trans_X_UnidPag>
    {
        #region IComparer<TRegistro_Trans_X_UnidPag> Members
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

        public TList_Trans_X_UnidPag()
        { }

        public TList_Trans_X_UnidPag(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Trans_X_UnidPag value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Trans_X_UnidPag x, TRegistro_Trans_X_UnidPag y)
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

    public class TRegistro_Trans_X_UnidPag
    {
        public string CD_Transportadora
        { get; set; }

        public string NM_Transportadora
        { get; set; }

        public string CD_UnidPagadora
        { get; set; }

        public string NM_UnidPagadora
        { get; set; }
        
        public TRegistro_Trans_X_UnidPag()
        {
            this.CD_Transportadora = string.Empty;
            this.NM_Transportadora = string.Empty;
            this.CD_UnidPagadora = string.Empty;
            this.NM_UnidPagadora = string.Empty;
        }
    }

    public class TCD_Trans_X_UnidPag : TDataQuery
    {
        public TCD_Trans_X_UnidPag()
        { }

        public TCD_Trans_X_UnidPag(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.CD_Transportadora, b.NM_Clifor as NM_Transportadora, ");
                sql.AppendLine("a.CD_UnidPagadora, c.NM_Clifor as NM_UnidPagadora ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_Transp_X_UnidPag a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Transportadora = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_UnidPagadora = c.cd_clifor ");
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

        public TList_Trans_X_UnidPag Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_Trans_X_UnidPag lista = new TList_Trans_X_UnidPag();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Trans_X_UnidPag reg = new TRegistro_Trans_X_UnidPag();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.CD_Transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.NM_Transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidPagadora")))
                        reg.CD_UnidPagadora = reader.GetString(reader.GetOrdinal("CD_UnidPagadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_UnidPagadora")))
                        reg.NM_UnidPagadora = reader.GetString(reader.GetOrdinal("NM_UnidPagadora"));

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

        public string Gravar(TRegistro_Trans_X_UnidPag val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_TRANSPORTADORA", val.CD_Transportadora);
            hs.Add("@P_CD_UNIDPAGADORA", val.CD_UnidPagadora);

            return this.executarProc("IA_PDC_TRANSP_X_UNIDPAG", hs);
        }

        public string Excluir(TRegistro_Trans_X_UnidPag val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_TRANSPORTADORA", val.CD_Transportadora);
            hs.Add("@P_CD_UNIDPAGADORA", val.CD_UnidPagadora);

            return this.executarProc("EXCLUI_PDC_TRANSP_X_UNIDPAG", hs);
        }
    }
}
