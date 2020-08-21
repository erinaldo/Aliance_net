using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Locacao.Cadastros
{
    public class TList_CadPrecoItens : List<TRegistro_CadPrecoItens>, IComparer<TRegistro_CadPrecoItens>
    {
        #region IComparer<TRegistro_CadPrecoItens> Members
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

        public TList_CadPrecoItens()
        { }

        public TList_CadPrecoItens(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadPrecoItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadPrecoItens x, TRegistro_CadPrecoItens y)
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


    public class TRegistro_CadPrecoItens
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_tabela;

        public decimal? Id_tabela
        {
            get { return id_tabela; }
            set
            {
                id_tabela = value;
                id_tabelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tabelastr;

        public string Id_tabelastr
        {
            get { return id_tabelastr; }
            set
            {
                id_tabelastr = value;
                try
                {
                    id_tabela = decimal.Parse(value);
                }
                catch
                { id_tabela = null; }
            }
        }

        public string Ds_tabela
        { get; set; }
        public string Tp_tabela
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Nr_patrimonio
        { get; set; }
        public decimal Vl_preco
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (this.St_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADO";
                else return string.Empty;
            }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_CadPrecoItens()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_tabela = null;
            this.id_tabelastr = string.Empty;
            this.Ds_tabela = string.Empty;
            this.Tp_tabela = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Nr_patrimonio = string.Empty;
            this.Vl_preco = decimal.Zero;
            this.St_registro = "A";
            this.St_registro = "ATIVO";
            this.St_processar = false;
        }
    }

    public class TCD_CadPrecoItens : TDataQuery
    {
        public TCD_CadPrecoItens() { }

        public TCD_CadPrecoItens(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, emp.NM_empresa, a.ID_Tabela, b.DS_Tabela, b.tp_tabela, ");
                sql.AppendLine("a.cd_produto, c.ds_produto, a.Vl_preco, a.ST_Registro, ");
                sql.AppendLine("Nr_Patrimonio = isnull((select x.NR_Patrimonio from TB_EST_Patrimonio x ");
                sql.AppendLine("                        where x.CD_Patrimonio = a.CD_Produto), '') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_LOC_PrecoItens a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_LOC_TabPreco b ");
            sql.AppendLine("on a.ID_Tabela = b.ID_Tabela ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");

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

        public TList_CadPrecoItens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadPrecoItens lista = new TList_CadPrecoItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadPrecoItens reg = new TRegistro_CadPrecoItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("ID_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Tabela")))
                        reg.Ds_tabela = reader.GetString(reader.GetOrdinal("DS_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tabela")))
                        reg.Tp_tabela = reader.GetString(reader.GetOrdinal("tp_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_preco")))
                        reg.Vl_preco = reader.GetDecimal(reader.GetOrdinal("Vl_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_CadPrecoItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_VL_PRECO", val.Vl_preco);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_LOC_PRECOITENS", hs);
        }

        public string Excluir(TRegistro_CadPrecoItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_LOC_PRECOITENS", hs);
        }
    }
}
