using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Cultura : List<TRegistro_Cultura>, IComparer<TRegistro_Cultura>
    {
        #region IComparer<TRegistro_Cultura> Members
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

        public TList_Cultura()
        { }

        public TList_Cultura(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cultura value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cultura x, TRegistro_Cultura y)
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

    
    public class TRegistro_Cultura
    {
        private decimal? id_cultura;
        
        public decimal? Id_cultura
        {
            get { return id_cultura; }
            set
            {
                id_cultura = value;
                id_culturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_culturastr;
        
        public string Id_culturastr
        {
            get { return id_culturastr; }
            set
            {
                id_culturastr = value;
                try
                {
                    id_cultura = decimal.Parse(value);
                }
                catch
                { id_cultura = null; }
            }
        }
        
        public string Ds_cultura
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public TRegistro_Cultura()
        {
            this.id_cultura = null;
            this.id_culturastr = string.Empty;
            this.Ds_cultura = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
        }
    }

    public class TCD_Cultura : TDataQuery
    {
        public TCD_Cultura()
        { }

        public TCD_Cultura(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Cultura, a.CD_Produto, a.DS_Cultura, ");
                sql.AppendLine("b.DS_Produto, b.CD_Unidade, c.DS_Unidade, c.Sigla_Unidade, ");
                sql.AppendLine("c.Sigla_Unidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Cultura a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");

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

        public TList_Cultura Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Cultura lista = new TList_Cultura();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Cultura reg = new TRegistro_Cultura();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cultura")))
                        reg.Id_cultura = reader.GetDecimal(reader.GetOrdinal("ID_Cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cultura")))
                        reg.Ds_cultura = reader.GetString(reader.GetOrdinal("DS_Cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));

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

        public string Gravar(TRegistro_Cultura val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CULTURA", val.Id_cultura);
            hs.Add("@P_DS_CULTURA", val.Ds_cultura);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("IA_FAZ_CULTURA", hs);
        }

        public string Excluir(TRegistro_Cultura val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CULTURA", val.Id_cultura);

            return this.executarProc("EXCLUI_FAZ_CULTURA", hs);
        }
    }
}
