using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Faturamento.Pedido
{
    #region Expedicao
    public class TList_Expedicao : List<TRegistro_Expedicao>, IComparer<TRegistro_Expedicao>
    {
        #region IComparer<TRegistro_Expedicao> Members
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

        public TList_Expedicao()
        { }

        public TList_Expedicao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Expedicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Expedicao x, TRegistro_Expedicao y)
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

    public class TRegistro_Expedicao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_expedicao;

        public decimal? Id_expedicao
        {
            get { return id_expedicao; }
            set
            {
                id_expedicao = value;
                id_expedicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_expedicaostr;

        public string Id_expedicaostr
        {
            get { return id_expedicaostr; }
            set
            {
                id_expedicaostr = value;
                try
                {
                    id_expedicao = decimal.Parse(value);
                }
                catch
                { id_expedicao = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public decimal Peso
        { get; set; }
        public string Volume
        { get; set; }
        public string Obs
        { get; set; }
        public decimal? Id_ordem
        { get; set; }
        public decimal? Nr_lanctoFiscal
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_ItensExpedicao lItens
        { get; set; }
        public TList_ItensExpedicao lItensDel
        { get; set; }

        public TRegistro_Expedicao()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_expedicao = null;
            id_expedicaostr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Peso = decimal.Zero;
            Volume = string.Empty;
            Obs = string.Empty;
            Id_ordem = null;
            Nr_lanctoFiscal = null;
            St_processar = false;
            lItens = new TList_ItensExpedicao();
            lItensDel = new TList_ItensExpedicao();
        }
    }

    public class TCD_Expedicao : TDataQuery
    {
        public TCD_Expedicao()
        { }

        public TCD_Expedicao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.nm_empresa, a.ID_Expedicao, a.Peso, ");
                sql.AppendLine("a.cd_clifor, c.nm_clifor, a.cd_endereco, d.ds_endereco, a.volume, a.obs, e.id_ordem, ");
                sql.AppendLine("Nr_lanctoFiscal = (select x.Nr_lanctoFiscal from VTB_FAT_Notafiscal x ");
                sql.AppendLine("                         inner join TB_FAT_Ordem_X_Expedicao y ");
                sql.AppendLine("                         on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                         and x.Nr_lanctoFiscal = y.Nr_lanctoFiscal ");
                sql.AppendLine("                         where a.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                         and a.id_expedicao = y.ID_Expedicao ");
                sql.AppendLine("                         and isnull(x.ST_Registro, 'A')<> 'C') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Expedicao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_Endereco d ");
            sql.AppendLine("on a.cd_endereco = d.cd_endereco ");
            sql.AppendLine("and a.cd_clifor = d.cd_clifor ");
            sql.AppendLine("left outer join TB_FAT_Ordem_X_Expedicao e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.id_expedicao = e.id_expedicao ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.ID_Expedicao ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Expedicao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Expedicao lista = new TList_Expedicao();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Expedicao reg = new TRegistro_Expedicao();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Expedicao")))
                        reg.Id_expedicao = reader.GetDecimal(reader.GetOrdinal("ID_Expedicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("Ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Peso")))
                        reg.Peso = reader.GetDecimal(reader.GetOrdinal("Peso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volume")))
                        reg.Volume = reader.GetString(reader.GetOrdinal("Volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("id_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lanctoFiscal")))
                        reg.Nr_lanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_lanctoFiscal"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_PESO", val.Peso);
            hs.Add("@P_VOLUME", val.Volume);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_FAT_EXPEDICAO", hs);
        }

        public string Excluir(TRegistro_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);

            return executarProc("EXCLUI_FAT_EXPEDICAO", hs);
        }
    }
    #endregion

    #region Itens Expedicao
    public class TList_ItensExpedicao : List<TRegistro_ItensExpedicao>, IComparer<TRegistro_ItensExpedicao>
    {
        #region IComparer<TRegistro_ItensExpedicao> Members
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

        public TList_ItensExpedicao()
        { }

        public TList_ItensExpedicao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensExpedicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensExpedicao x, TRegistro_ItensExpedicao y)
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

    public class TRegistro_ItensExpedicao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_expedicao;

        public decimal? Id_expedicao
        {
            get { return id_expedicao; }
            set
            {
                id_expedicao = value;
                id_expedicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_expedicaostr;

        public string Id_expedicaostr
        {
            get { return id_expedicaostr; }
            set
            {
                id_expedicaostr = value;
                try
                {
                    id_expedicao = decimal.Parse(value);
                }
                catch
                { id_expedicao = null; }
            }
        }
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
                catch
                { id_item = null; }
            }
        }
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_PedidoString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_PedidoString;
        public string Nr_PedidoString
        {
            get { return nr_PedidoString; }
            set
            {
                nr_PedidoString = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch { nr_pedido = null; }
            }
        }
        private decimal? id_pedidoitem;

        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemstr;

        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = decimal.Parse(value);
                }
                catch
                { id_pedidoitem = null; }
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
                catch { id_acessorio = null; }
            }
        }


        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
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
        public string Nr_serie
        { get; set; }
        public string Cd_local
        { get; set; }
        public bool St_exigirserie
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal PS_Unitario
        { get; set; }
        public decimal SaldoCarregar
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_TrocaSerieExped lTroca
        { get; set; }
        public TList_FichaTecProduto lFicha
        { get; set; }

        public TRegistro_ItensExpedicao()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_expedicao = null;
            id_expedicaostr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            nr_pedido = null;
            nr_PedidoString = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_pedidoitem = null;
            id_pedidoitemstr = string.Empty;
            id_acessorio = null;
            id_acessoriostr = string.Empty;
            id_serie = null;
            id_seriestr = string.Empty;
            St_exigirserie = false;
            Cd_local = string.Empty;
            Quantidade = decimal.Zero;
            PS_Unitario = decimal.Zero;
            SaldoCarregar = decimal.Zero;
            St_processar = false;
            lTroca = new TList_TrocaSerieExped();
            lFicha = new TList_FichaTecProduto();
        }
    }

    public class TCD_ItensExpedicao : TDataQuery
    {
        public TCD_ItensExpedicao()
        { }

        public TCD_ItensExpedicao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, emp.nm_empresa, a.ID_Expedicao, a.Id_item, b.ps_unitario, ");
                sql.AppendLine("a.nr_pedido, a.id_pedidoitem, a.id_acessorio, a.cd_produto, b.ds_produto, a.id_serie, b.st_exigirserie, c.nr_serie, a.Quantidade, ");
                sql.AppendLine("CASE WHEN a.ID_PedidoItem is not null then d.CD_Local else e.CD_Local end as CD_Local ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ItensExpedicao a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("left outer join TB_PRD_SerieProduto c ");
            sql.AppendLine("on c.id_serie = a.id_serie ");
            sql.AppendLine("left outer join TB_FAT_Pedido_Itens d ");
            sql.AppendLine("on d.Nr_Pedido = a.Nr_Pedido ");
            sql.AppendLine("and d.CD_Produto = a.CD_Produto ");
            sql.AppendLine("and d.ID_PedidoItem = a.ID_PedidoItem ");
            sql.AppendLine("left outer join TB_FAT_AcessoriosPed e");
            sql.AppendLine("on e.Nr_Pedido = a.Nr_Pedido ");
            sql.AppendLine("and e.ID_Acessorio = a.ID_Acessorio ");
            sql.AppendLine("and e.CD_Produto = a.CD_Produto ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.ID_Expedicao ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ItensExpedicao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ItensExpedicao lista = new TList_ItensExpedicao();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensExpedicao reg = new TRegistro_ItensExpedicao();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Expedicao")))
                        reg.Id_expedicao = reader.GetDecimal(reader.GetOrdinal("ID_Expedicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("Id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("Ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acessorio")))
                        reg.Id_acessorio = reader.GetDecimal(reader.GetOrdinal("ID_Acessorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_serie")))
                        reg.Id_serie = reader.GetDecimal(reader.GetOrdinal("Id_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Unitario")))
                        reg.PS_Unitario = reader.GetDecimal(reader.GetOrdinal("PS_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_exigirserie")))
                        reg.St_exigirserie = reader.GetString(reader.GetOrdinal("St_exigirserie")).ToString().ToUpper().Equals("S");

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_ItensExpedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_ID_SERIE", val.Id_serie);
            hs.Add("@P_QUANTIDADE", val.Quantidade);


            return executarProc("IA_FAT_ITENSEXPEDICAO", hs);
        }

        public string Excluir(TRegistro_ItensExpedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_FAT_ITENSEXPEDICAO", hs);
        }
    }
    #endregion

    #region Troca Série Expedicao
    public class TList_TrocaSerieExped : List<TRegistro_TrocaSerieExped>, IComparer<TRegistro_TrocaSerieExped>
    {
        #region IComparer<TRegistro_ItensExpedicao> Members
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

        public TList_TrocaSerieExped()
        { }

        public TList_TrocaSerieExped(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TrocaSerieExped value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TrocaSerieExped x, TRegistro_TrocaSerieExped y)
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

    public class TRegistro_TrocaSerieExped
    {
        private decimal? id_troca;

        public decimal? Id_troca
        {
            get { return id_troca; }
            set
            {
                id_troca = value;
                id_trocastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_trocastr;

        public string Id_trocastr
        {
            get { return id_trocastr; }
            set
            {
                id_trocastr = value;
                try
                {
                    id_troca = decimal.Parse(value);
                }
                catch
                { id_troca = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_expedicao;

        public decimal? Id_expedicao
        {
            get { return id_expedicao; }
            set
            {
                id_expedicao = value;
                id_expedicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_expedicaostr;

        public string Id_expedicaostr
        {
            get { return id_expedicaostr; }
            set
            {
                id_expedicaostr = value;
                try
                {
                    id_expedicao = decimal.Parse(value);
                }
                catch
                { id_expedicao = null; }
            }
        }
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
                catch
                { id_item = null; }
            }
        }
        private decimal? id_SerieNew;

        public decimal? Id_SerieNew
        {
            get { return id_SerieNew; }
            set
            {
                id_SerieNew = value;
                id_SerieNewstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_SerieNewstr;

        public string Id_SerieNewstr
        {
            get { return id_SerieNewstr; }
            set
            {
                id_SerieNewstr = value;
                try
                {
                    id_SerieNew = decimal.Parse(value);
                }
                catch { id_SerieNew = null; }
            }
        }
        public string Nr_serieNew
        { get; set; }
        private decimal? id_SerieOld;

        public decimal? Id_SerieOld
        {
            get { return id_SerieOld; }
            set
            {
                id_SerieOld = value;
                id_SerieOldstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_SerieOldstr;

        public string Id_SerieOldstr
        {
            get { return id_SerieOldstr; }
            set
            {
                id_SerieOldstr = value;
                try
                {
                    id_SerieOld = decimal.Parse(value);
                }
                catch { id_SerieOld = null; }
            }
        }
        public string Nr_serieOld
        { get; set; }
        public string Login
        { get; set; }
        public string Motivo
        { get; set; }

        public TRegistro_TrocaSerieExped()
        {
            id_troca = null;
            id_trocastr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_expedicao = null;
            id_expedicaostr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            id_SerieNew = null;
            id_SerieNewstr = string.Empty;
            Nr_serieNew = string.Empty;
            id_SerieOld = null;
            id_SerieOldstr = string.Empty;
            Nr_serieOld = string.Empty;
            Login = string.Empty;
            Motivo = string.Empty;
        }
    }

    public class TCD_TrocaSerieExped : TDataQuery
    {
        public TCD_TrocaSerieExped()
        { }

        public TCD_TrocaSerieExped(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + "a.id_troca, a.CD_Empresa, emp.nm_empresa, a.ID_Expedicao, a.Id_item, a.ID_SerieNew, b.nr_serie as Nr_serieNew, ");
                sql.AppendLine("a.ID_SerieOld, c.Nr_Serie as Nr_SerieOld, a.Login, a.Motivo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_TrocaSerieExped a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join TB_PRD_SerieProduto b ");
            sql.AppendLine("on b.id_serie = a.ID_SerieNew ");
            sql.AppendLine("left outer join TB_PRD_SerieProduto c ");
            sql.AppendLine("on c.id_serie = a.ID_SerieOld ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.ID_Expedicao ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TrocaSerieExped Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TrocaSerieExped lista = new TList_TrocaSerieExped();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocaSerieExped reg = new TRegistro_TrocaSerieExped();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Troca")))
                        reg.Id_expedicao = reader.GetDecimal(reader.GetOrdinal("ID_Troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Expedicao")))
                        reg.Id_expedicao = reader.GetDecimal(reader.GetOrdinal("ID_Expedicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("Id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_SerieNew")))
                        reg.Id_SerieNew = reader.GetDecimal(reader.GetOrdinal("ID_SerieNew"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serieNew")))
                        reg.Nr_serieNew = reader.GetString(reader.GetOrdinal("Nr_serieNew"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_SerieOld")))
                        reg.Id_SerieOld = reader.GetDecimal(reader.GetOrdinal("ID_SerieOld"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serieOld")))
                        reg.Nr_serieOld = reader.GetString(reader.GetOrdinal("Nr_serieOld"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Motivo")))
                        reg.Motivo = reader.GetString(reader.GetOrdinal("Motivo"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_TrocaSerieExped val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_SERIENEW", val.Id_SerieNew);
            hs.Add("@P_ID_SERIEOLD", val.Id_SerieOld);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_MOTIVO", val.Motivo);

            return executarProc("IA_FAT_TROCASERIEEXPED", hs);
        }

        public string Excluir(TRegistro_TrocaSerieExped val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TROCA", val.Id_troca);

            return executarProc("EXCLUI_FAT_TROCASERIEEXPED", hs);
        }
    }
    #endregion
}
