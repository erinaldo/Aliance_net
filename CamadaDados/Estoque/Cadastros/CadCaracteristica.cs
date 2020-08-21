using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Estoque.Cadastros
{
    #region Classe Caracteristica

    public class TList_Caracteristica : List<TRegistro_Caracteristica>, IComparer<TRegistro_Caracteristica>
    {
        #region IComparer<TRegistro_Caracteristica> Members
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

        public TList_Caracteristica()
        { }

        public TList_Caracteristica(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Caracteristica value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Caracteristica x, TRegistro_Caracteristica y)
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

    
    public class TRegistro_Caracteristica
    {
        private decimal? id_caracteristica;
        public decimal? Id_caracteristica
        {
            get { return id_caracteristica; }
            set
            {
                id_caracteristica = value;
                id_caracteristicastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicastr;
        public string Id_caracteristicastr
        {
            get { return id_caracteristicastr; }
            set
            {
                id_caracteristicastr = value;
                try
                {
                    id_caracteristica = Convert.ToDecimal(value);
                }
                catch
                { id_caracteristica = null; }
            }
        }
        public string Ds_caracteristica
        { get; set; }
        public decimal QuantidadeVendida
        { get; set; }
        public TRegistro_Caracteristica()
        {
            id_caracteristica = null;
            id_caracteristicastr = string.Empty;
            Ds_caracteristica = string.Empty;
        }
    }

    public class TCD_Caracteristica : TDataQuery
    {
        public TCD_Caracteristica()
        { }

        public TCD_Caracteristica(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNm_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.id_caracteristica, a.ds_caracteristica ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine(" from tb_est_caracteristica a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Caracteristica Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Caracteristica lista = new TList_Caracteristica();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Caracteristica reg = new TRegistro_Caracteristica();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristica")))
                        reg.Id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristica")))
                        reg.Ds_caracteristica = reader.GetString(reader.GetOrdinal("ds_caracteristica"));

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

        public string Gravar(TRegistro_Caracteristica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);
            hs.Add("@P_DS_CARACTERISTICA", val.Ds_caracteristica);

            return executarProc("IA_EST_CARACTERISTICA", hs);
        }

        public string Excluir(TRegistro_Caracteristica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);

            return executarProc("EXCLUI_EST_CARACTERISTICA", hs);
        }
    }

    #endregion

    #region Classe Valor Caracteristica
    public class TList_ValorCaracteristica : List<TRegistro_ValorCaracteristica>, IComparer<TRegistro_ValorCaracteristica>
    {
        #region IComparer<TRegistro_ValorCaracteristica> Members
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

        public TList_ValorCaracteristica()
        { }

        public TList_ValorCaracteristica(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ValorCaracteristica value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ValorCaracteristica x, TRegistro_ValorCaracteristica y)
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

    
    public class TRegistro_ValorCaracteristica
    {
        private decimal? id_caracteristica;
        
        public decimal? Id_caracteristica
        {
            get { return id_caracteristica; }
            set
            {
                id_caracteristica = value;
                id_caracteristicastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicastr;
        
        public string Id_caracteristicastr
        {
            get { return id_caracteristicastr; }
            set
            {
                id_caracteristicastr = value;
                try
                {
                    id_caracteristica = Convert.ToDecimal(value);
                }
                catch
                { id_caracteristica = null; }
            }
        }
        
        public string Ds_caracteristica
        { get; set; }
        
        public decimal? Id_item
        { get; set; }
        
        public string Valor
        { get; set; }
        public decimal SaldoEst { get; set; } = decimal.Zero;
        public decimal Vl_mov { get; set; } = decimal.Zero;

        public TRegistro_ValorCaracteristica()
        {
            id_caracteristica = null;
            id_caracteristicastr = string.Empty;
            Ds_caracteristica = string.Empty;
            Id_item = null;
            Valor = string.Empty;
        }
    }

    public class TCD_ValorCaracteristica : TDataQuery
    {
        public TCD_ValorCaracteristica()
        { }

        public TCD_ValorCaracteristica(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNm_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.id_caracteristica, b.ds_caracteristica, a.id_item, a.valor ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from tb_est_valorcaracteristica a ");
            sql.AppendLine("inner join tb_est_caracteristica b ");
            sql.AppendLine("on a.id_caracteristica = b.id_caracteristica ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.valor ");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ValorCaracteristica Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_ValorCaracteristica lista = new TList_ValorCaracteristica();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ValorCaracteristica reg = new TRegistro_ValorCaracteristica();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristica")))
                        reg.Id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristica")))
                        reg.Ds_caracteristica = reader.GetString(reader.GetOrdinal("ds_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetString(reader.GetOrdinal("valor"));

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

        public TList_ValorCaracteristica Select(string Id_caracteristica, string Cd_empresa, string Cd_produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_Caracteristica, b.DS_Caracteristica, a.ID_Item, a.Valor, ");
            sql.AppendLine("Saldo_Estoque = isnull((select top 1 x.Saldo ");
            sql.AppendLine("				from VTB_EST_SALDOGRADEESTOQUE x ");
            sql.AppendLine("				where x.ID_Caracteristica = a.id_caracteristica ");
            sql.AppendLine("				and x.ID_Item = a.id_item ");
            sql.AppendLine("				and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("				and x.CD_Produto = '" + Cd_produto.Trim() + "'), 0) ");
            sql.AppendLine("from tb_est_valorcaracteristica a ");
            sql.AppendLine("inner join tb_est_caracteristica b ");
            sql.AppendLine("on a.id_caracteristica = b.ID_Caracteristica ");
            sql.AppendLine("where a.id_caracteristica = " + Id_caracteristica);
            sql.AppendLine("order by a.valor ");
            TList_ValorCaracteristica lista = new TList_ValorCaracteristica();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_ValorCaracteristica reg = new TRegistro_ValorCaracteristica();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristica")))
                        reg.Id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristica")))
                        reg.Ds_caracteristica = reader.GetString(reader.GetOrdinal("ds_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetString(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("saldo_estoque")))
                        reg.SaldoEst = reader.GetDecimal(reader.GetOrdinal("saldo_estoque"));

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

        public string Gravar(TRegistro_ValorCaracteristica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_VALOR", val.Valor);

            return executarProc("IA_EST_VALORCARACTERISTICA", hs);
        }

        public string Excluir(TRegistro_ValorCaracteristica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_EST_VALORCARACTERISTICA", hs);
        }
    }
    #endregion
}
