using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Locacao
{
    public class TList_MedicaoProdutoItens:List<TRegistro_MedicaoProdutoItens>, IComparer<TRegistro_MedicaoProdutoItens>
    {
        #region IComparer<TRegistro_MedicaoProdutoItens> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_MedicaoProdutoItens()
        { }

        public TList_MedicaoProdutoItens(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MedicaoProdutoItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MedicaoProdutoItens x, TRegistro_MedicaoProdutoItens y)
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
    public class TRegistro_MedicaoProdutoItens
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        private decimal? id_loc = null;
        public decimal? Id_loc
        {
            get { return id_loc; }
            set
            {
                id_loc = value;
                id_locstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locstr = string.Empty;
        public string Id_locstr
        {
            get { return id_locstr; }
            set
            {
                id_locstr = value;
                try
                {
                    id_loc = decimal.Parse(value);
                }catch { id_loc = null; }
            }
        }
        private decimal? id_item = null;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr = string.Empty;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }catch { id_item = null; }
            }
        }
        public string Nr_patrimonio { get; set; } = string.Empty;
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        private decimal? id_medicao = null;
        public decimal? Id_medicao
        {
            get { return id_medicao; }
            set
            {
                id_medicao = value;
                id_medicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_medicaostr = string.Empty;
        public string Id_medicaostr
        {
            get { return id_medicaostr; }
            set
            {
                id_medicaostr = value;
                try
                {
                    id_medicao = decimal.Parse(value);
                }catch { id_medicao = null; }
            }
        }
        private DateTime? dt_medicao = null;
        public DateTime? Dt_medicao
        {
            get { return dt_medicao; }
            set
            {
                dt_medicao = value;
                dt_medicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_medicaostr = string.Empty;
        public string Dt_medicaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_medicaostr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_medicaostr = value;
                try
                {
                    dt_medicao = DateTime.Parse(value);
                }catch { dt_medicao = null; }
            }
        }
        public decimal Qt_medicao { get; set; } = decimal.Zero;
        public decimal Vl_precovenda { get; set; } = decimal.Zero;
        public decimal Vl_subtotal => Qt_medicao * Vl_precovenda;
    }

    public class TCD_MedicaoProdutoItens : TDataQuery
    {
        public TCD_MedicaoProdutoItens() { }

        public TCD_MedicaoProdutoItens(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Cd_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.Id_loc, a.Id_Item, f.Nr_patrimonio, a.Cd_produto, c.Ds_produto, ");
                sql.AppendLine("d.Endereco, a.Id_Medicao, a.Dt_Medicao, a.Qt_Medicao, a.Vl_PrecoVenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_LOC_MedicaoProdutoItens a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_LOC_ProdutoItens d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.id_loc = d.id_loc ");
            sql.AppendLine("and a.id_item = d.id_item ");
            sql.AppendLine("and a.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join TB_LOC_ItensLocTerceiro e ");
            sql.AppendLine("on d.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and d.id_loc = e.id_loc ");
            sql.AppendLine("and d.id_item = e.id_item ");
            sql.AppendLine("inner join TB_EST_Patrimonio f ");
            sql.AppendLine("on e.cd_patrimonio = f.cd_patrimonio ");

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

        public TList_MedicaoProdutoItens Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_MedicaoProdutoItens lista = new TList_MedicaoProdutoItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_MedicaoProdutoItens reg = new TRegistro_MedicaoProdutoItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Loc")))
                        reg.Id_loc = reader.GetDecimal(reader.GetOrdinal("ID_Loc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("NR_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Endereco")))
                        reg.Endereco = reader.GetString(reader.GetOrdinal("Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Medicao")))
                        reg.Id_medicao = reader.GetDecimal(reader.GetOrdinal("Id_Medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_Medicao")))
                        reg.Dt_medicao = reader.GetDateTime(reader.GetOrdinal("Dt_Medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_Medicao")))
                        reg.Qt_medicao = reader.GetDecimal(reader.GetOrdinal("Qt_Medicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PrecoVenda")))
                        reg.Vl_precovenda = reader.GetDecimal(reader.GetOrdinal("Vl_PrecoVenda"));

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

        public string Gravar(TRegistro_MedicaoProdutoItens val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MEDICAO", val.Id_medicao);
            hs.Add("@P_DT_MEDICAO", val.Dt_medicao);
            hs.Add("@P_QT_MEDICAO", val.Qt_medicao);

            return executarProc("IA_LOC_MEDICAOPRODUTOITENS", hs);
        }

        public string Excluir(TRegistro_MedicaoProdutoItens val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOC", val.Id_loc);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MEDICAO", val.Id_medicao);

            return executarProc("EXCLUI_LOC_MEDICAOPRODUTOITENS", hs);
        }
    }
}
