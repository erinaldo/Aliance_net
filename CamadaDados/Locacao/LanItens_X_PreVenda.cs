using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Locacao
{
    #region Itens_X_PreVenda
    public class TList_Itens_X_PreVenda : List<TRegistro_Itens_X_PreVenda>, IComparer<TRegistro_Itens_X_PreVenda>
    {

        #region IComparer<TRegistro_Itens_X_PreVenda> Members
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

        public TList_Itens_X_PreVenda()
        { }

        public TList_Itens_X_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Itens_X_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Itens_X_PreVenda x, TRegistro_Itens_X_PreVenda y)
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


    public class TRegistro_Itens_X_PreVenda
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }

        private decimal? id_prevenda;

        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;

        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch
                { id_prevenda = null; }
            }
        }

        private decimal? id_itemprevenda;

        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;

        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = Convert.ToDecimal(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }

        public TRegistro_Itens_X_PreVenda()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_itemloc = null;
            this.id_itemlocstr = string.Empty;
            this.id_prevenda = null;
            this.id_prevendastr = string.Empty;
            this.id_itemprevenda = null;
            this.id_itemprevendastr = string.Empty;
        }
    }

    public class TCD_Itens_X_PreVenda : TDataQuery
    {
        public TCD_Itens_X_PreVenda()
        { }

        public TCD_Itens_X_PreVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.ID_PreVenda, a.ID_ItemPreVenda ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_Itens_X_PreVenda a ");


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

        public TList_Itens_X_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Itens_X_PreVenda lista = new TList_Itens_X_PreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Itens_X_PreVenda reg = new TRegistro_Itens_X_PreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PreVenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("ID_PreVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemPreVenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("ID_ItemPreVenda"));
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

        public string Gravar(TRegistro_Itens_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return this.executarProc("IA_LOC_ITENS_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_Itens_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return this.executarProc("EXCLUI_LOC_ITENS_X_PREVENDA", hs);
        }

    }
    #endregion
}
