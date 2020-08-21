using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_PrecoCommodities : List<TRegistro_PrecoCommodities>, IComparer<TRegistro_PrecoCommodities>
    {
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

        public TList_PrecoCommodities()
        { }

        public TList_PrecoCommodities(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PrecoCommodities value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PrecoCommodities x, TRegistro_PrecoCommodities y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }
    public class TRegistro_PrecoCommodities
    {
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public string Cd_unidadeProd { get; set; } = string.Empty;
        public string Ds_unidadeProd { get; set; } = string.Empty;
        public string Sg_unidadeProd { get; set; } = string.Empty;
        public string Cd_unidade { get; set; } = string.Empty;
        public string Ds_unidade { get; set; } = string.Empty;
        public string Sg_unidade { get; set; } = string.Empty;
        private decimal? id_preco = null;
        public decimal? Id_preco
        {
            get { return id_preco; }
            set
            {
                id_preco = value;
                id_precostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_precostr = string.Empty;
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
                catch { id_preco = null; }
            }
        }
        private DateTime? dt_preco = null;
        public DateTime? Dt_preco
        {
            get { return dt_preco; }
            set
            {
                dt_preco = value;
                dt_precostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_precostr = string.Empty;
        public string Dt_precostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_precostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_precostr = value;
                try
                {
                    dt_preco = DateTime.Parse(value);
                }
                catch { dt_preco = null; }
            }
        }
        public decimal Vl_precocompra { get; set; } = decimal.Zero;
        public decimal Vl_precovenda { get; set; } = decimal.Zero;
    }
    public class TCD_PrecoCommodities:TDataQuery
    {
        public TCD_PrecoCommodities() { }
        public TCD_PrecoCommodities(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_produto, b.ds_produto, ");
                sql.AppendLine("c.cd_unidade as cd_unidadeProd, c.ds_unidade as ds_unidadeProd, ");
                sql.AppendLine("c.sigla_unidade as sg_unidadeProd, a.cd_unidade, d.ds_unidade, d.sigla_unidade, ");
                sql.AppendLine("a.id_preco, a.dt_preco, a.vl_precocompra, a.vl_precovenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_GRO_PrecoCommodities a ");
            sql.AppendLine("INNER JOIN TB_EST_Produto b ");
            sql.AppendLine("ON a.cd_produto = b.cd_produto ");
            sql.AppendLine("INNER JOIN TB_EST_Unidade c ");
            sql.AppendLine("ON b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("INNER JOIN TB_EST_Unidade d ");
            sql.AppendLine("ON a.cd_unidade = d.cd_unidade ");

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
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_PrecoCommodities Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_PrecoCommodities lista = new TList_PrecoCommodities();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {

                while (reader.Read())
                {
                    TRegistro_PrecoCommodities reg = new TRegistro_PrecoCommodities();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidadeProd")))
                        reg.Cd_unidadeProd = reader.GetString(reader.GetOrdinal("cd_unidadeProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidadeProd")))
                        reg.Ds_unidadeProd = reader.GetString(reader.GetOrdinal("ds_unidadeProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_unidadeProd")))
                        reg.Sg_unidadeProd = reader.GetString(reader.GetOrdinal("sg_unidadeProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_preco")))
                        reg.Id_preco = reader.GetDecimal(reader.GetOrdinal("id_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_preco")))
                        reg.Dt_preco = reader.GetDateTime(reader.GetOrdinal("dt_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precocompra")))
                        reg.Vl_precocompra = reader.GetDecimal(reader.GetOrdinal("vl_precocompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precovenda")))
                        reg.Vl_precovenda = reader.GetDecimal(reader.GetOrdinal("vl_precovenda"));

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
        public TList_PrecoCommodities SelectProdCotacao(string Cd_produto, DateTime? Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_produto, a.ds_produto, ");
            sql.AppendLine("Sg_unidade = isnull((select top 1 y.sigla_unidade ");
            sql.AppendLine("                    from tb_gro_precocommodities x ");
            sql.AppendLine("                    inner join tb_est_unidade y ");
            sql.AppendLine("                    on x.cd_unidade = y.cd_unidade ");
            sql.AppendLine("                    where a.cd_produto = x.cd_produto ");
            if (Dt_movimento.HasValue)
                sql.AppendLine("                    and convert(datetime, floor(convert(decimal(30,10), x.dt_preco))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                    order by x.dt_preco desc), ''), ");
            sql.AppendLine("vl_precocompra = isnull((select top 1 x.vl_precocompra ");
            sql.AppendLine("                        from tb_gro_precocommodities x ");
            sql.AppendLine("                        where a.cd_produto = x.cd_produto ");
            if (Dt_movimento.HasValue)
                sql.AppendLine("                    and convert(datetime, floor(convert(decimal(30,10), x.dt_preco))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                        order by x.dt_preco desc), 0), ");
            sql.AppendLine("vl_precovenda = isnull((select top 1 x.vl_precovenda ");
            sql.AppendLine("                        from tb_gro_precocommodities x ");
            sql.AppendLine("                        where a.cd_produto = x.cd_produto ");
            if (Dt_movimento.HasValue)
                sql.AppendLine("                    and convert(datetime, floor(convert(decimal(30,10), x.dt_preco))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                        order by x.dt_preco desc), 0), ");
            sql.AppendLine("dt_preco = isnull((select top 1 x.dt_preco ");
            sql.AppendLine("                        from tb_gro_precocommodities x ");
            sql.AppendLine("                        where a.cd_produto = x.cd_produto ");
            if (Dt_movimento.HasValue)
                sql.AppendLine("                    and convert(datetime, floor(convert(decimal(30,10), x.dt_preco))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                        order by x.dt_preco desc), 0), ");
            sql.AppendLine("cd_unidade = isnull((select top 1 x.cd_unidade ");
            sql.AppendLine("                        from tb_gro_precocommodities x ");
            sql.AppendLine("                        where a.cd_produto = x.cd_produto ");
            if (Dt_movimento.HasValue)
                sql.AppendLine("                    and convert(datetime, floor(convert(decimal(30,10), x.dt_preco))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                        order by x.dt_preco desc), 0) ");

            sql.AppendLine("from tb_est_produto a ");
            sql.AppendLine("inner join tb_est_tpproduto b ");
            sql.AppendLine("on a.tp_produto = b.tp_produto ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(b.st_commodities, 'N') = 'S'");

            if (!string.IsNullOrEmpty(Cd_produto))
                sql.AppendLine("and a.cd_produto = '" + Cd_produto.Trim() + "'");

            TList_PrecoCommodities lista = new TList_PrecoCommodities();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {

                while (reader.Read())
                {
                    TRegistro_PrecoCommodities reg = new TRegistro_PrecoCommodities();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sg_unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("Sg_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precocompra")))
                        reg.Vl_precocompra = reader.GetDecimal(reader.GetOrdinal("vl_precocompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precovenda")))
                        reg.Vl_precovenda = reader.GetDecimal(reader.GetOrdinal("vl_precovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_preco")))
                        reg.Dt_preco = reader.GetDateTime(reader.GetOrdinal("dt_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));

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
        public string Gravar(TRegistro_PrecoCommodities val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PRECO", val.Id_preco);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_DT_PRECO", val.Dt_preco);
            hs.Add("@P_VL_PRECOCOMPRA", val.Vl_precocompra);
            hs.Add("@P_VL_PRECOVENDA", val.Vl_precovenda);

            return executarProc("IA_GRO_PRECOCOMMODITIES", hs);
        }
        public string Excluir(TRegistro_PrecoCommodities val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PRECO", val.Id_preco);

            return executarProc("EXCLUI_GRO_PRECOCOMMODITIES", hs);
        }
    }
}
