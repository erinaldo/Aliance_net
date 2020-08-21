using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Locacao
{
    #region Acessorios Item
    public class TList_AcessoriosItem : List<TRegistro_AcessoriosItem>, IComparer<TRegistro_AcessoriosItem>
    {
        #region IComparer<TRegistro_AcessoriosItem> Members
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

        public TList_AcessoriosItem()
        { }

        public TList_AcessoriosItem(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AcessoriosItem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AcessoriosItem x, TRegistro_AcessoriosItem y)
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


    public class TRegistro_AcessoriosItem
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
        private decimal? id_acessorio;

        public decimal? Id_acessorio
        {
            get { return id_acessorio; }
            set
            {
                id_acessorio = value;
                id_acessoriostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_acessoriostr;

        public string Id_acessoriostr
        {
            get { return id_acessoriostr; }
            set
            {
                id_acessoriostr = value;
                try
                {
                    id_acessorio = decimal.Parse(value);
                }
                catch
                { id_acessorio = null; }
            }
        }
        private decimal? id_lanctoestoque_s;

        public decimal? Id_lanctoestoque_s
        {
            get { return id_lanctoestoque_s; }
            set
            {
                id_lanctoestoque_s = value;
                id_lanctoestoque_sstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoque_sstr;

        public string Id_lanctoestoque_sstr
        {
            get { return id_lanctoestoque_sstr; }
            set
            {
                id_lanctoestoque_sstr = value;
                try
                {
                    id_lanctoestoque_s = Convert.ToDecimal(value);
                }
                catch
                { id_lanctoestoque_s = null; }
            }
        }
        private decimal? id_lanctoestoque_e;

        public decimal? Id_lanctoestoque_e
        {
            get { return id_lanctoestoque_e; }
            set
            {
                id_lanctoestoque_e = value;
                id_lanctoestoque_estr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoque_estr;

        public string Id_lanctoestoque_estr
        {
            get { return id_lanctoestoque_estr; }
            set
            {
                id_lanctoestoque_estr = value;
                try
                {
                    id_lanctoestoque_e = Convert.ToDecimal(value);
                }
                catch
                { id_lanctoestoque_e = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal QTD_Devolvida
        { get; set; }
        public decimal Vl_subtotal
        { get { return Vl_unitario * QTD_Gasta; } }
        public decimal Qtd_baixa
        { get; set; }
        public decimal Vl_baixa
        { get; set; }
        public decimal Tot_baixa
        { get { return Qtd_baixa * Vl_baixa; } }
        public decimal QTD_Gasta
        { get; set; }
        public decimal Qtd_saldo => (Quantidade - Qtd_baixa - QTD_Gasta - QTD_Devolvida) < 0 ? 0 : Quantidade - Qtd_baixa - QTD_Gasta - QTD_Devolvida;
        public string Obs
        { get; set; }
        public bool St_gerarLanctoS
        { get; set; }

        public decimal Vl_desconto
        { get; set; }

        public TRegistro_AcessoriosItem()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_itemloc = null;
            id_itemlocstr = string.Empty;
            id_acessorio = null;
            id_acessoriostr = string.Empty;
            Id_lanctoestoque_s = null;
            Id_lanctoestoque_sstr = string.Empty;
            Id_lanctoestoque_e = null;
            Id_lanctoestoque_estr = string.Empty;
            Cd_produto = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            QTD_Gasta = decimal.Zero;
            QTD_Devolvida = decimal.Zero;
            Qtd_baixa = decimal.Zero;
            Vl_baixa = decimal.Zero;
            Obs = string.Empty;
            St_gerarLanctoS = true;
        }
    }

    public class TCD_AcessoriosItem : TDataQuery
    {
        public TCD_AcessoriosItem()
        { }

        public TCD_AcessoriosItem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.id_acessorio, a.vl_desconto, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, a.quantidade, a.Id_LanctoEstoque_S, a.Id_LanctoEstoque_E, a.Qtd_baixa, a.Obs,  ");
                sql.AppendLine("qtd_gasta = isnull(a.QTD_Gasta, isnull((select isnull(x.Quantidade, 0) ");
                sql.AppendLine("                    from VTB_PDV_ITENSPREVENDA x ");
                sql.AppendLine("                    inner join VTB_PDV_PREVENDA h ");
                sql.AppendLine("                    on x.CD_Empresa = h.CD_Empresa ");
                sql.AppendLine("                    and x.ID_PreVenda = h.ID_PreVenda ");
                sql.AppendLine("                    inner join TB_LOC_Acessorios_X_PreVenda y ");
                sql.AppendLine("                    on y.CD_Empresa = x.CD_Empresa ");
                sql.AppendLine("                    and y.ID_PreVenda = x.ID_PreVenda ");
                sql.AppendLine("                    and y.ID_ItemPreVenda = x.ID_ItemPreVenda ");
                sql.AppendLine("                    where a.CD_Empresa = y.CD_Empresa ");
                sql.AppendLine("                    and a.ID_Locacao = y.ID_Locacao ");
                sql.AppendLine("                    and a.ID_ItemLoc = y.ID_ItemLoc ");
                sql.AppendLine("                    and a.ID_Acessorio = y.ID_Acessorio ");
                sql.AppendLine("                    and isnull(h.st_registro, 'A') <> 'C'), 0)), ");
                sql.AppendLine("vl_unitario = isnull(a.Vl_Unitario, (select isnull(x.Vl_Unitario, 0) "); 
                sql.AppendLine("                    from VTB_PDV_ITENSPREVENDA x ");
				sql.AppendLine("                    inner join VTB_PDV_PREVENDA h ");
				sql.AppendLine("                    on x.CD_Empresa = h.CD_Empresa ");
				sql.AppendLine("                    and x.ID_PreVenda = h.ID_PreVenda ");
                sql.AppendLine("                    inner join TB_LOC_Acessorios_X_PreVenda y ");
				sql.AppendLine("                    on y.CD_Empresa = x.CD_Empresa ");
				sql.AppendLine("                    and y.ID_PreVenda = x.ID_PreVenda ");
				sql.AppendLine("                    and y.ID_ItemPreVenda = x.ID_ItemPreVenda ");
				sql.AppendLine("                    where a.CD_Empresa = y.CD_Empresa ");
				sql.AppendLine("                    and a.ID_Locacao = y.ID_Locacao ");
				sql.AppendLine("                    and a.ID_ItemLoc = y.ID_ItemLoc ");
				sql.AppendLine("                    and a.ID_Acessorio = y.ID_Acessorio ");
                sql.AppendLine("                    and isnull(h.st_registro, 'A') <> 'C')), ");
                sql.AppendLine("Vl_Baixa = isnull((select isnull(x.Vl_Unitario, 0) ");
				sql.AppendLine("			        from TB_EST_Estoque x "); 
				sql.AppendLine("			        where a.cd_empresa = x.CD_Empresa ");
				sql.AppendLine("			        and a.CD_Produto = x.CD_Produto ");
				sql.AppendLine("			        and a.Id_LanctoEstoque_S = x.Id_LanctoEstoque ");
				sql.AppendLine("			        and isnull(x.st_registro, 'A') <> 'C' ");
                sql.AppendLine("			        and a.Qtd_baixa > 0), 0), ");
                sql.AppendLine("QTD_Devolvida = isnull((select isnull(x.QTD_Entrada, 0) ");
                sql.AppendLine("			        from TB_EST_Estoque x ");
                sql.AppendLine("			        where a.cd_empresa = x.CD_Empresa ");
                sql.AppendLine("			        and a.CD_Produto = x.CD_Produto ");
                sql.AppendLine("			        and a.Id_LanctoEstoque_E = x.Id_LanctoEstoque ");
                sql.AppendLine("			        and isnull(x.st_registro, 'A') <> 'C'), 0) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_AcessoriosItem a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("left join tb_est_estoque c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("and a.CD_Produto = c.CD_Produto ");
            sql.AppendLine("and c.Id_LanctoEstoque = a.Id_LanctoEstoque_S ");


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

        public TList_AcessoriosItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_AcessoriosItem lista = new TList_AcessoriosItem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_AcessoriosItem reg = new TRegistro_AcessoriosItem();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_acessorio")))
                        reg.Id_acessorio = reader.GetDecimal(reader.GetOrdinal("Id_acessorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque_S")))
                        reg.Id_lanctoestoque_s = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque_S"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque_E")))
                        reg.Id_lanctoestoque_e = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque_E"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_baixa")))
                        reg.Qtd_baixa = reader.GetDecimal(reader.GetOrdinal("Qtd_baixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Baixa")))
                        reg.Vl_baixa = reader.GetDecimal(reader.GetOrdinal("Vl_Baixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Devolvida")))
                        reg.QTD_Devolvida = reader.GetDecimal(reader.GetOrdinal("QTD_Devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Gasta")))
                        reg.QTD_Gasta = reader.GetDecimal(reader.GetOrdinal("QTD_Gasta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Obs"))))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
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

        public string Gravar(TRegistro_AcessoriosItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE_S", val.Id_lanctoestoque_s);
            hs.Add("@P_ID_LANCTOESTOQUE_E", val.Id_lanctoestoque_e);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_QTD_BAIXA", val.Qtd_baixa);
            hs.Add("@P_QTD_GASTA", val.QTD_Gasta);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);

            return executarProc("IA_LOC_ACESSORIOSITEM", hs);
        }

        public string Excluir(TRegistro_AcessoriosItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);

            return executarProc("EXCLUI_LOC_ACESSORIOSITEM", hs);
        }

    }
    #endregion

    #region Acessorios_X_PreVenda
    public class TList_Acessorios_X_PreVenda : List<TRegistro_Acessorios_X_PreVenda>, IComparer<TRegistro_Acessorios_X_PreVenda>
    {
        #region IComparer<TRegistro_Acessorios_X_PreVenda> Members
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

        public TList_Acessorios_X_PreVenda()
        { }

        public TList_Acessorios_X_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Acessorios_X_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Acessorios_X_PreVenda x, TRegistro_Acessorios_X_PreVenda y)
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

    public class TRegistro_Acessorios_X_PreVenda
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
        private decimal? id_acessorio;

        public decimal? Id_acessorio
        {
            get { return id_acessorio; }
            set
            {
                id_acessorio = value;
                id_acessoriostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_acessoriostr;

        public string Id_acessoriostr
        {
            get { return id_acessoriostr; }
            set
            {
                id_acessoriostr = value;
                try
                {
                    id_acessorio = decimal.Parse(value);
                }
                catch
                { id_acessorio = null; }
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


        public TRegistro_Acessorios_X_PreVenda()
        {
            Cd_empresa = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_itemloc = null;
            id_itemlocstr = string.Empty;
            id_acessorio = null;
            id_acessoriostr = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
        }
    }

    public class TCD_Acessorios_X_PreVenda : TDataQuery
    {
        public TCD_Acessorios_X_PreVenda()
        { }

        public TCD_Acessorios_X_PreVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.id_acessorio, a.ID_PreVenda, a.ID_ItemPreVenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_Acessorios_X_PreVenda a ");


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

        public TList_Acessorios_X_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Acessorios_X_PreVenda lista = new TList_Acessorios_X_PreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Acessorios_X_PreVenda reg = new TRegistro_Acessorios_X_PreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_acessorio")))
                        reg.Id_acessorio = reader.GetDecimal(reader.GetOrdinal("Id_acessorio"));
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
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Acessorios_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("IA_LOC_ACESSORIOS_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_Acessorios_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("EXCLUI_LOC_ACESSORIOS_X_PREVENDA", hs);
        }

    }
    #endregion
}
