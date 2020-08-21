using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca.Cadastros
{
    public class TList_CadItens : List<TRegistro_CadItens>, IComparer<TRegistro_CadItens>
    {
        #region IComparer<TRegistro_CadItens> Members
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

        public TList_CadItens()
        { }

        public TList_CadItens(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadItens x, TRegistro_CadItens y)
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

    public class TRegistro_CadItens
    {
        private decimal? id_item;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch { id_item = null; }
            }
        }
        private decimal? id_itempai;
        public decimal? Id_itempai
        {
            get { return id_itempai; }
            set
            {
                id_itempai = value;
                id_itempaistr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itempaistr;
        public string Id_itempaistr
        {
            get { return id_itempaistr; }
            set
            {
                id_itempaistr = value;
                try
                {
                    id_itempai = decimal.Parse(value);
                }
                catch { id_itempai = null; }
            }
        }
        public string Ds_itempai
        { get; set; }
        public string Ds_item
        { get; set; }
        public decimal MetragemCub
        { get; set; }
        private string st_sintetico;
        public string St_sintetico
        {
            get { return st_sintetico; }
            set
            {
                st_sintetico = value;
                st_sinteticobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sinteticobool;
        public bool St_sinteticobool
        {
            get { return st_sinteticobool; }
            set
            {
                st_sinteticobool = value;
                if (value)
                    st_sintetico = "S";
                else
                    st_sintetico = "N";
            }
        }
        public string Cd_itemweb
        { get; set; }
        public string Ds_itemweb
        { get; set; }
        public string Classificacao
        { get; set; }

        public TRegistro_CadItens()
        {
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.id_itempai = null;
            this.id_itempaistr = string.Empty;
            this.Ds_itempai = string.Empty;
            this.Ds_item = string.Empty;
            this.MetragemCub = decimal.Zero;
            this.st_sintetico = "N";
            this.st_sinteticobool = false;
            this.Cd_itemweb = string.Empty;
            this.Ds_itemweb = string.Empty;
            this.Classificacao = string.Empty;
        }
    }

    public class TCD_CadItens : TDataQuery
    {
        public TCD_CadItens()
        { }

        public TCD_CadItens(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Item, a.ID_ItemPai, ");
                sql.AppendLine("a.DS_Item, a.MetragemCub, a.ST_Sintetico, a.cd_itemweb, a.classificacao, ");
                sql.AppendLine("ds_itempai = ISNULL((select top 1 x.DS_Item from tb_mud_itens x ");
                sql.AppendLine("					where SUBSTRING(a.classificacao, 0, 3) = x.Classificacao ");
                sql.AppendLine("					and x.ST_Sintetico = 'S'), ''), ");
                sql.AppendLine("DS_ItemWeb = isnull((select top 1 DS_ItemWeb from TB_MUD_Orcamento_X_Itens x ");
                sql.AppendLine("					where x.CD_ItemWeb = a.cd_itemweb ), '') ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Itens a ");
            sql.AppendLine("left outer join TB_MUD_Itens b ");
            sql.AppendLine("on b.id_item = a.id_itempai ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("order by a.classificacao ");
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

        public TList_CadItens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadItens lista = new TList_CadItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadItens reg = new TRegistro_CadItens();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemPai")))
                        reg.Id_itempai = reader.GetDecimal(reader.GetOrdinal("ID_ItemPai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("DS_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_itempai")))
                        reg.Ds_itempai = reader.GetString(reader.GetOrdinal("ds_itempai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MetragemCub")))
                        reg.MetragemCub = reader.GetDecimal(reader.GetOrdinal("MetragemCub"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Sintetico")))
                        reg.St_sintetico = reader.GetString(reader.GetOrdinal("ST_Sintetico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_itemweb")))
                        reg.Cd_itemweb = reader.GetString(reader.GetOrdinal("cd_itemweb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItemWeb")))
                        reg.Ds_itemweb = reader.GetString(reader.GetOrdinal("DS_ItemWeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("classificacao"));


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

        public string Gravar(TRegistro_CadItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_ITEMPAI", val.Id_itempai);
            hs.Add("@P_DS_ITEM", val.Ds_item);
            hs.Add("@P_METRAGEMCUB", val.MetragemCub);
            hs.Add("@P_ST_SINTETICO", val.St_sintetico);
            hs.Add("@P_CD_ITEMWEB", val.Cd_itemweb);
            hs.Add("@P_CLASSIFICACAO", val.Classificacao);


            return this.executarProc("IA_MUD_ITENS", hs);
        }

        public string Excluir(TRegistro_CadItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_MUD_ITENS", hs);
        }
    }
}
