using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TResumoProduto
    {
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public int Qtd_barril { get; set; }
        public int Volume { get; set; }
    }

    public class TList_Barril : List<TRegistro_Barril>, IComparer<TRegistro_Barril>
    {
        #region IComparer<TRegistro_Chopeira> Members
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

        public TList_Barril()
        { }

        public TList_Barril(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Barril value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Barril x, TRegistro_Barril y)
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

    public class TRegistro_Barril
    {
        public int? Id_barril { get; set; } = null;
        public string Nr_barril { get; set; } = string.Empty;
        public int Volume { get; set; } = 0;
        public bool Cancelado { get; set; } = false;
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
    }

    public class TCD_Barril : TDataQuery
    {
        public TCD_Barril() { }

        public TCD_Barril(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_barril, a.nr_barril, a.volume, ")
                    .AppendLine("a.cancelado, a.cd_produto, b.ds_produto");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from VTB_RES_Barril a ");
            sql.AppendLine("left outer join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");

            sql.AppendLine("where a.cancelado = 0 ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Barril Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Barril lista = new TList_Barril();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Barril reg = new TRegistro_Barril();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_barril")))
                        reg.Id_barril = reader.GetInt32(reader.GetOrdinal("id_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_barril")))
                        reg.Nr_barril = reader.GetString(reader.GetOrdinal("nr_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volume")))
                        reg.Volume = reader.GetInt32(reader.GetOrdinal("volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("cancelado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Barril val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_BARRIL", val.Id_barril);
            hs.Add("@P_NR_BARRIL", val.Nr_barril);
            hs.Add("@P_VOLUME", val.Volume);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_RES_BARRIL", hs);
        }

        public string Excluir(TRegistro_Barril val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_BARRIL", val.Id_barril);

            return executarProc("EXCLUI_RES_BARRIL", hs);
        }
    }
}
