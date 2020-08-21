using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_TrocaItem : List<TRegistro_TrocaItem>, IComparer<TRegistro_TrocaItem>
    {
        #region IComparer<TRegistro_TrocaItem> Members
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

        public TList_TrocaItem()
        { }

        public TList_TrocaItem(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TrocaItem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TrocaItem x, TRegistro_TrocaItem y)
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

    public class TRegistro_TrocaItem
    {
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch { id_cupom = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_lanctoOrig;
        public decimal? Id_lanctoOrig
        {
            get { return id_lanctoOrig; }
            set
            {
                id_lanctoOrig = value;
                id_lanctoOrigstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoOrigstr;
        public string Id_lanctoOrigstr
        {
            get { return id_lanctoOrigstr; }
            set
            {
                id_lanctoOrigstr = value;
                try
                {
                    id_lanctoOrig = decimal.Parse(value);
                }
                catch { id_lanctoOrig = null; }
            }
        }
        public string Cd_produtoOrig
        { get; set; }
        public string Ds_produtoOrig
        { get; set; }
        private decimal? id_lanctoDest;
        public decimal? Id_lanctoDest
        {
            get { return id_lanctoDest; }
            set
            {
                id_lanctoDest = value;
                id_lanctoDeststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoDeststr;
        public string Id_lanctoDeststr
        {
            get { return id_lanctoDeststr; }
            set
            {
                id_lanctoDeststr = value;
                try
                {
                    id_lanctoDest = decimal.Parse(value);
                }
                catch { id_lanctoDest = null; }
            }
        }
        public string Cd_produtoDest
        { get; set; }
        public string Ds_produtoDest
        { get; set; }
        public string MotivoTroca
        { get; set; }

        public TRegistro_TrocaItem()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            id_lanctoOrig = null;
            id_lanctoOrigstr = string.Empty;
            Cd_produtoOrig = string.Empty;
            Ds_produtoOrig = string.Empty;
            Cd_produtoDest = string.Empty;
            Ds_produtoDest = string.Empty;
            id_lanctoDest = null;
            id_lanctoDeststr = string.Empty;
            MotivoTroca = string.Empty;
        }
    }

    public class TCD_TrocaItem : TDataQuery
    {
        public TCD_TrocaItem() { }

        public TCD_TrocaItem(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_Cupom, a.CD_Empresa, b.NM_Empresa, a.Id_lanctoOrig, ");
                sql.AppendLine("a.Id_lanctoDest, a.MotivoTroca, c.cd_produto as cd_produtoOrig, e.ds_produto as ds_produtoOrig, ");
                sql.AppendLine("d.cd_produto as cd_produtoDest, f.ds_produto as ds_produtoDest ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_TrocaItem a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_PDV_VendaRapida_Item c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.id_cupom = c.id_vendarapida ");
            sql.AppendLine("and a.Id_lanctoOrig = c.id_lanctovenda");
            sql.AppendLine("inner join TB_PDV_VendaRapida_Item d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.id_cupom = d.id_vendarapida ");
            sql.AppendLine("and a.Id_lanctoDest = d.id_lanctovenda ");
            sql.AppendLine("inner join TB_EST_Produto e ");
            sql.AppendLine("on c.cd_produto = e.cd_produto ");
            sql.AppendLine("inner join TB_EST_Produto f ");
            sql.AppendLine("on c.cd_produto = f.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TrocaItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocaItem lista = new TList_TrocaItem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocaItem reg = new TRegistro_TrocaItem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lanctoOrig")))
                        reg.Id_lanctoOrig = reader.GetDecimal(reader.GetOrdinal("Id_lanctoOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lanctoDest")))
                        reg.Id_lanctoDest = reader.GetDecimal(reader.GetOrdinal("Id_lanctoDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produtoOrig")))
                        reg.Cd_produtoOrig = reader.GetString(reader.GetOrdinal("cd_produtoOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produtoOrig")))
                        reg.Ds_produtoOrig = reader.GetString(reader.GetOrdinal("ds_produtoOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produtoDest")))
                        reg.Cd_produtoDest = reader.GetString(reader.GetOrdinal("cd_produtoDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produtoDest")))
                        reg.Ds_produtoDest = reader.GetString(reader.GetOrdinal("ds_produtoDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoTroca")))
                        reg.MotivoTroca = reader.GetString(reader.GetOrdinal("MotivoTroca"));

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

        public string Gravar(TRegistro_TrocaItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTOORIG", val.Id_lanctoOrig);
            hs.Add("@P_ID_LANCTODEST", val.Id_lanctoDest);
            hs.Add("@P_MOTIVOTROCA", val.MotivoTroca);

            return executarProc("IA_PDV_TROCAITEM", hs);
        }

        public string Excluir(TRegistro_TrocaItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTOORIG", val.Id_lanctoOrig);
            hs.Add("@P_ID_LANCTODEST", val.Id_lanctoDest);

            return executarProc("EXCLUI_PDV_TROCAITEM", hs);
        }
    }
}
