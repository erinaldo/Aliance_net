using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_Variedade : List<TRegistro_Variedade>, IComparer<TRegistro_Variedade>
    {
        #region IComparer<TRegistro_Variedade> Members
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

        public TList_Variedade()
        { }

        public TList_Variedade(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Variedade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Variedade x, TRegistro_Variedade y)
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
    
    public class TRegistro_Variedade
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private decimal? id_variedade;
        public decimal? Id_variedade
        {
            get { return id_variedade; }
            set
            {
                id_variedade = value;
                id_variedadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_variedadestr;
        public string Id_variedadestr
        {
            get { return id_variedadestr; }
            set
            {
                id_variedadestr = value;
                try
                {
                    id_variedade = decimal.Parse(value);
                }
                catch { id_variedade = null; }
            }
        }
        public string Ds_variedade
        { get; set; }

        public TRegistro_Variedade()
        {
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.id_variedade = null;
            this.id_variedadestr = string.Empty;
            this.Ds_variedade = string.Empty;
        }
    }

    public class TCD_Variedade : TDataQuery
    {
        public TCD_Variedade() { }

        public TCD_Variedade(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("SELECT " + strTop + " a.cd_produto, b.ds_produto, a.id_variedade, a.ds_variedade ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_est_variedade a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Variedade Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Variedade lista = new TList_Variedade();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Variedade reg = new TRegistro_Variedade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_variedade")))
                        reg.Id_variedade = reader.GetDecimal(reader.GetOrdinal("id_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                        reg.Ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
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

        public string Gravar(TRegistro_Variedade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_VARIEDADE", val.Id_variedade);
            hs.Add("@P_DS_VARIEDADE", val.Ds_variedade);

            return this.executarProc("IA_EST_VARIEDADE", hs);
        }

        public string Excluir(TRegistro_Variedade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_VARIEDADE", val.Id_variedade);

            return this.executarProc("EXCLUI_EST_VARIEDADE", hs);
        }
    }
}
