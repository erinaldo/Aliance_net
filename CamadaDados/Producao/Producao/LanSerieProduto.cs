using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Producao.Producao
{
    public class TList_SerieProduto : List<TRegistro_SerieProduto>, IComparer<TRegistro_SerieProduto>
    {
        #region IComparer<TRegistro_SerieProduto> Members
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

        public TList_SerieProduto()
        { }

        public TList_SerieProduto(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_SerieProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_SerieProduto x, TRegistro_SerieProduto y)
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


    public class TRegistro_SerieProduto
    {
        private decimal? id_serie;
        public decimal? Id_serie
        {
            get { return id_serie; }
            set
            {
                id_serie = value;
                id_seriestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_seriestr;
        public string Id_seriestr
        {
            get { return id_seriestr; }
            set
            {
                id_seriestr = value;
                try
                {
                    id_serie = decimal.Parse(value);
                }
                catch
                { id_serie = null; }
            }
        }
       public string Cd_empresa
       { get; set; }
       public string Nm_empresa
       { get; set; }
       public string Cd_produto
        { get; set; }
       public string Ds_produto
       { get; set; }

        private decimal? id_ordem;

        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;

        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = Convert.ToDecimal(value);
                }
                catch
                { id_ordem = null; }
            }
        }
        public string Nr_serie
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTA";
                else if (St_registro.Trim().ToUpper().Equals("P"))
                    return "PROCESSADA";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FATURADA";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADA";
                else return string.Empty;
            }
        }
        public bool St_processar
        { get; set; }
        public TList_MovRastreabilidade lMovSaida
        { get; set; }
        public Faturamento.Pedido.TList_ItensExpedicao lItensExp
        { get; set; }

        public TRegistro_SerieProduto()
        {
            id_serie = null;
            id_seriestr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_ordem = null;
            id_ordemstr = string.Empty;
            Nr_serie = string.Empty;
            St_registro = "A";
            St_processar = false;
            lMovSaida = new TList_MovRastreabilidade();
            lItensExp = new Faturamento.Pedido.TList_ItensExpedicao();
        }
    }

    public class TCD_SerieProduto : TDataQuery
    {
        public TCD_SerieProduto()
        { }

        public TCD_SerieProduto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.ID_Serie, a.CD_Empresa, emp.nm_empresa, ");
                sql.AppendLine("a.CD_Produto, b.ds_produto, a.ID_Ordem, a.NR_Serie, a.St_registro ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PRD_SerieProduto a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'" );

            string cond = " and ";
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

        public TList_SerieProduto Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_SerieProduto lista = new TList_SerieProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SerieProduto reg = new TRegistro_SerieProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Serie")))
                        reg.Id_serie = reader.GetDecimal(reader.GetOrdinal("ID_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("St_registro"));
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

        public string Gravar(TRegistro_SerieProduto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_SERIE", val.Id_serie);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PRD_SERIEPRODUTO", hs);
        }

        public string Excluir(TRegistro_SerieProduto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_SERIE", val.Id_serie);

            return executarProc("EXCLUI_PRD_SERIEPRODUTO", hs);
        }
    }
}
