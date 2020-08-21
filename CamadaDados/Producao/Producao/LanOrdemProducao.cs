using CamadaDados.Faturamento.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;

namespace CamadaDados.Producao.Producao
{
    #region Produto Producao
    public class TList_PRD_Produto : List<TRegistro_PRD_Produto>, IComparer<TRegistro_PRD_Produto>
    {
        #region IComparer<TRegistro_PRD_Produto> Members
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

        public TList_PRD_Produto()
        { }

        public TList_PRD_Produto(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PRD_Produto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PRD_Produto x, TRegistro_PRD_Produto y)
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


    public class TRegistro_PRD_Produto
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal SD_Estoque
        { get; set; }
        public decimal QT_Min_Estoque
        { get; set; }
        public decimal QT_Max_Estoque
        { get; set; }
        public decimal QT_PedFaturar
        { get; set; }
        public decimal QT_Produzir
        { get; set; }
        public decimal SD_EstoqueFuturo
        { get { return SD_Estoque - QT_PedFaturar + QT_Produzir; } }
    }

    public class TCD_PRD_Produto : TDataQuery
    {
        public TCD_PRD_Produto() { }

        public TCD_PRD_Produto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_produto,
                                    string Cd_grupo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Produto, a.DS_Produto, ");
            sql.AppendLine("SD_Estoque = ISNULL(DBO.F_SALDOESTOQUE('" + Cd_empresa.Trim() + "', a.cd_produto), 0), ");
            sql.AppendLine("QT_Min_Estoque = ISNULL((select top 1 x.QT_Min_Estoque ");
            sql.AppendLine("					from TB_EST_Produto_QTDEstoque x ");
            sql.AppendLine("					where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("					and x.cd_empresa = '" + Cd_empresa.Trim() + "'), 0), ");
            sql.AppendLine("QT_Max_Estoque = ISNULL((select top 1 x.QT_Max_Estoque ");
            sql.AppendLine("					from TB_EST_Produto_QTDEstoque x ");
            sql.AppendLine("					where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("					and x.CD_Empresa = '" + Cd_empresa.Trim() + "'), 0), ");
            sql.AppendLine("QT_PedFaturar = ISNULL((select SUM(ISNULL(x.Quantidade, 0) - ISNULL(x.qtd_faturada, 0) + ISNULL(x.qtd_devolvida, 0)) ");
            sql.AppendLine("						from VTB_FAT_Pedido_Itens x ");
            sql.AppendLine("						inner join TB_FAT_Pedido y ");
            sql.AppendLine("						on x.Nr_Pedido = y.Nr_Pedido ");
            sql.AppendLine("						where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("						and y.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("                        and exists(select 1 from TB_FAT_Pedido_Etapa k where y.nr_pedido = k.nr_pedido)");
            sql.AppendLine("						and isnull(y.ST_Pedido, 'A') <> 'C'), 0), ");
            sql.AppendLine("QT_Produzir = ISNULL((select SUM(ISNULL(x.QTD_Batch, 0) * ISNULL(x.QT_Produto,0) - ISNULL(x.QTD_Produzida,0)) ");
            sql.AppendLine("					from VTB_PRD_OrdemProducao x ");
            sql.AppendLine("					where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("					and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("					and not exists(select 1 from TB_PRD_OrdemProducao_X_Apontamento y ");
            sql.AppendLine("									where y.id_ordem = x.id_ordem)), 0) ");

            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_TpProduto b ");
            sql.AppendLine("on a.TP_Produto = b.TP_Produto ");

            sql.AppendLine("where isnull(b.ST_Industrializado, 'N') = 'S' ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            if (!string.IsNullOrEmpty(Cd_produto))
                sql.AppendLine("and a.cd_produto = '" + Cd_produto.Trim() + "' ");
            if (!string.IsNullOrEmpty(Cd_grupo))
                sql.AppendLine("and a.cd_grupo like '" + Cd_grupo.Trim() + "%' ");

            return sql.ToString();
        }

        public TList_PRD_Produto Select(string Cd_empresa,
                                        string Cd_produto,
                                        string Cd_grupo)
        {
            TList_PRD_Produto lista = new TList_PRD_Produto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_produto, Cd_grupo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PRD_Produto reg = new TRegistro_PRD_Produto();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_Estoque")))
                        reg.SD_Estoque = reader.GetDecimal(reader.GetOrdinal("SD_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Min_Estoque")))
                        reg.QT_Min_Estoque = reader.GetDecimal(reader.GetOrdinal("QT_Min_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Max_Estoque")))
                        reg.QT_Max_Estoque = reader.GetDecimal(reader.GetOrdinal("QT_Max_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_PedFaturar")))
                        reg.QT_PedFaturar = reader.GetDecimal(reader.GetOrdinal("QT_PedFaturar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Produzir")))
                        reg.QT_Produzir = reader.GetDecimal(reader.GetOrdinal("QT_Produzir"));

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
    }
    #endregion

    #region Produto Entregar
    public class TList_PRD_ProdutoEntregar : List<TRegistro_PRD_ProdutoEntregar>, IComparer<TRegistro_PRD_ProdutoEntregar>
    {
        #region IComparer<TRegistro_PRD_Produto> Members
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

        public TList_PRD_ProdutoEntregar()
        { }

        public TList_PRD_ProdutoEntregar(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PRD_ProdutoEntregar value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PRD_ProdutoEntregar x, TRegistro_PRD_ProdutoEntregar y)
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

    public class TRegistro_PRD_ProdutoEntregar
    {
        public decimal? Nr_orcamento
        { get; set; }
        public decimal? Id_item
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private DateTime? dt_preventrega;
        public DateTime? Dt_preventrega
        {
            get { return dt_preventrega; }
            set
            {
                dt_preventrega = value;
                dt_preventregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_preventregastr;
        public string Dt_preventregastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_preventregastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_preventregastr = value;
                try
                {
                    dt_preventrega = DateTime.Parse(value);
                }
                catch { dt_preventrega = null; }
            }
        }
        public decimal Qtd_entregar
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public string DS_Observacao
        { get; set; }
        public decimal? Nr_pedido { get; set; } = null;
        public decimal? Id_formulacao { get; set; } = null;

        public TRegistro_PRD_ProdutoEntregar()
        {
            Nr_orcamento = null;
            Id_item = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            dt_preventrega = null;
            dt_preventregastr = string.Empty;
            Qtd_entregar = decimal.Zero;
            Vl_unitario = decimal.Zero;
            DS_Observacao = string.Empty;
        }
    }

    public class TCD_PRD_ProdutoEntregar : TDataQuery
    {
        public TCD_PRD_ProdutoEntregar() { }

        public TCD_PRD_ProdutoEntregar(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_produto,
                                    string Cd_grupo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select 'ESPECIAL' as TP_Projeto, a.nr_pedidovenda as nr_pedido, b.NR_Orcamento, b.id_item, a.cd_clifor, e.nm_clifor, b.cd_produto, c.ds_produto, DATEADD(DAY, a.prazoentrega, a.dt_orcamento) as DT_EntregaPedido, convert(varchar(1024),b.DS_ProjEspecial) as DS_Observacao, ");
            sql.AppendLine("b.Quantidade as QTD_Entregar, b.Vl_unitario ");

            sql.AppendLine("from vtb_fat_orcamento a ");
            sql.AppendLine("inner join VTB_FAT_Orcamento_Item b ");
            sql.AppendLine("on a.Nr_orcamento = b.Nr_orcamento ");
            sql.AppendLine("left join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("left join TB_EST_TpProduto d ");
            sql.AppendLine("on c.TP_Produto = d.TP_Produto ");
            sql.AppendLine("inner join TB_FIN_Clifor e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("where isnull(a.st_registro, 'A') = 'AB' "); 
            if (!string.IsNullOrEmpty(Cd_empresa))
                sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            if (!string.IsNullOrEmpty(Cd_grupo))
                sql.AppendLine("and c.cd_grupo = '" + Cd_grupo.Trim() + "' ");
            sql.AppendLine("and isnull(b.ST_ProjEspecial, 'N') = 'S' ");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'NORMAL' as TP_Projeto, a.Nr_pedido, b.NR_Orcamento, b.ID_PedidoItem as id_item, a.cd_clifor, e.nm_clifor, b.cd_produto, c.ds_produto, a.DT_EntregaPedido, a.DS_Observacao, ");
            sql.AppendLine("QTD_Entregar = ISNULL(b.Quantidade, 0) - ISNULL(b.qtd_faturada, 0) + ISNULL(b.qtd_devolvida, 0), b.Vl_unitario ");

            sql.AppendLine("from tb_fat_pedido a ");
            sql.AppendLine("inner join vtb_fat_pedido_itens b ");
            sql.AppendLine("on a.Nr_Pedido = b.Nr_Pedido ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_TpProduto d ");
            sql.AppendLine("on c.TP_Produto = d.TP_Produto ");
            sql.AppendLine("inner join TB_FIN_Clifor e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(a.st_pedido, 'A') <> 'P' "); 
            sql.AppendLine("and isnull(b.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(d.ST_Industrializado, 'N') = 'S' ");
            sql.AppendLine("and not exists(select 1 from TB_PRD_OrdemProducao_X_PedItem x ");
            sql.AppendLine("               where x.nr_pedido = b.nr_pedido ");
            sql.AppendLine("               and x.cd_produto = b.cd_produto ");
            sql.AppendLine("               and x.id_pedidoitem = b.id_pedidoitem) ");

            if (!string.IsNullOrEmpty(Cd_empresa))
                sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            if (!string.IsNullOrEmpty(Cd_produto))
                sql.AppendLine("and b.cd_produto = '" + Cd_produto.Trim() + "' ");
            if (!string.IsNullOrEmpty(Cd_grupo))
                sql.AppendLine("and c.cd_grupo like '" + Cd_grupo.Trim() + "%' ");
            sql.AppendLine("and ISNULL(b.Quantidade, 0) - ISNULL(b.qtd_faturada, 0) + ISNULL(b.qtd_devolvida, 0) > 0 ");
            sql.AppendLine("and exists(select 1 from TB_FAT_Pedido_Etapa x where x.nr_pedido = a.nr_pedido) ");
            //sql.AppendLine("order by b.cd_produto asc, a.dt_entregapedido desc ");

            return sql.ToString();
        }

        public TList_PRD_ProdutoEntregar SelectProjProgramar(string Cd_empresa,
                                                             string Cd_produto,
                                                             string Cd_grupo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.NR_Orcamento, b.id_item, a.cd_clifor, e.nm_clifor, b.cd_produto, c.ds_produto, ")
                .AppendLine("DATEADD(DAY, a.prazoentrega, a.dt_orcamento) as DT_EntregaPedido, ")
                .AppendLine("convert(varchar(1024),b.DS_ProjEspecial) as DS_Observacao, ")
                .AppendLine("b.Quantidade as QTD_Entregar, b.Vl_unitario ")
                .AppendLine("from tb_fat_orcamento a ")
                .AppendLine("inner join TB_FAT_Orcamento_Item b ")
                .AppendLine("on a.Nr_orcamento = b.Nr_orcamento ")
                .AppendLine("and isnull(a.st_registro, 'A') = 'AB' ")
                .AppendLine("and isnull(b.ST_ProjEspecial, 'N') = 'S' ")
                .AppendLine("and b.id_formulacao is null ")
                .AppendLine("and b.vl_unitario = 0 ")
                .AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.DT_Validade))) > convert(datetime, floor(convert(decimal(30,10), getdate()))) ")
                .AppendLine("left join TB_EST_Produto c ")
                .AppendLine("on b.CD_Produto = c.CD_Produto ")
                .AppendLine("left join TB_EST_TpProduto d ")
                .AppendLine("on c.TP_Produto = d.TP_Produto ")
                .AppendLine("inner join TB_FIN_Clifor e ")
                .AppendLine("on a.cd_clifor = e.cd_clifor ");
            string cond = " where ";
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                sql.AppendLine(cond + "a.cd_empresa = '" + Cd_empresa.Trim() + "'");
                cond = " and ";
            }
            if(!string.IsNullOrEmpty(Cd_produto))
            {
                sql.AppendLine(cond + "b.produto = '" + Cd_produto.Trim() + "'");
                cond = " and ";
            }
            if(!string.IsNullOrEmpty(Cd_grupo))
                sql.AppendLine(cond + "c.cd_grupo like '" + Cd_grupo.Trim() + "%' ");

            TList_PRD_ProdutoEntregar lista = new TList_PRD_ProdutoEntregar();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_PRD_ProdutoEntregar reg = new TRegistro_PRD_ProdutoEntregar();
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("Nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EntregaPedido")))
                        reg.Dt_preventrega = reader.GetDateTime(reader.GetOrdinal("DT_EntregaPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entregar")))
                        reg.Qtd_entregar = reader.GetDecimal(reader.GetOrdinal("QTD_Entregar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));

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

        public TList_PRD_ProdutoEntregar SelectProjProduzir(string Cd_empresa,
                                                            string Cd_produto,
                                                            string Cd_grupo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.nr_pedido, f.id_formulacao, b.NR_Orcamento, b.ID_PedidoItem as id_item, a.cd_clifor, ")
                .AppendLine("e.nm_clifor, b.cd_produto, c.ds_produto, a.DT_EntregaPedido, a.DS_Observacao, ")
                .AppendLine("QTD_Entregar = ISNULL(b.Quantidade, 0) - ISNULL(b.qtd_faturada, 0) + ISNULL(b.qtd_devolvida, 0), b.Vl_unitario ")
                .AppendLine("from tb_fat_pedido a ")
                .AppendLine("inner join vtb_fat_pedido_itens b ")
                .AppendLine("on a.Nr_Pedido = b.Nr_Pedido ")
                .AppendLine("and isnull(a.st_registro, 'A') <> 'C' ")
                .AppendLine("and isnull(a.st_pedido, 'A') <> 'P' ")
                .AppendLine("and isnull(b.ST_Registro, 'A') <> 'C' ")
                .AppendLine("and ISNULL(b.Quantidade, 0) - ISNULL(b.qtd_faturada, 0) + ISNULL(b.qtd_devolvida, 0) > 0 ")
                .AppendLine("inner join TB_EST_Produto c ")
                .AppendLine("on b.CD_Produto = c.CD_Produto ")
                .AppendLine("inner join TB_EST_TpProduto d ")
                .AppendLine("on c.TP_Produto = d.TP_Produto ")
                .AppendLine("and ISNULL(d.ST_Industrializado, 'N') = 'S' ")
                .AppendLine("inner join TB_FIN_Clifor e ")
                .AppendLine("on a.cd_clifor = e.cd_clifor ")
                .AppendLine("inner join tb_fat_orcamento_item f ")
                .AppendLine("on b.nr_orcamento = f.nr_orcamento ")
                .AppendLine("and b.ID_ItemOrc = f.ID_Item ")
                .AppendLine("and isnull(f.ST_ProjEspecial, 'N') = 'S' ");
            string cond = " where ";
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                sql.AppendLine(cond + "a.cd_empresa = '" + Cd_empresa.Trim() + "'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                sql.AppendLine(cond + "b.produto = '" + Cd_produto.Trim() + "'");
                cond = " and ";
            }
            if (!string.IsNullOrEmpty(Cd_grupo))
                sql.AppendLine(cond + "c.cd_grupo like '" + Cd_grupo.Trim() + "%' ");

            TList_PRD_ProdutoEntregar lista = new TList_PRD_ProdutoEntregar();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_PRD_ProdutoEntregar reg = new TRegistro_PRD_ProdutoEntregar();
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("Nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EntregaPedido")))
                        reg.Dt_preventrega = reader.GetDateTime(reader.GetOrdinal("DT_EntregaPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entregar")))
                        reg.Qtd_entregar = reader.GetDecimal(reader.GetOrdinal("QTD_Entregar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("id_formulacao"));

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
    }
    #endregion

    #region Ordem Producao
    public class TList_OrdemProducao : List<TRegistro_OrdemProducao>, IComparer<TRegistro_OrdemProducao>
    {
        #region IComparer<TRegistro_OrdemProducao> Members
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

        public TList_OrdemProducao()
        { }

        public TList_OrdemProducao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemProducao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemProducao x, TRegistro_OrdemProducao y)
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
    
    public class TRegistro_OrdemProducao
    {
        public decimal? Id_ordem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Cd_unid_produto
        { get; set; }
        public string Ds_unid_produto
        { get; set; }
        public string Sg_unid_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        private decimal? id_formulacao;
        public decimal? Id_formulacao
        {
            get { return id_formulacao; }
            set
            {
                id_formulacao = value;
                id_formulacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_formulacaostr;
        public string Id_formulacaostr
        {
            get { return id_formulacaostr; }
            set
            {
                id_formulacaostr = value;
                try
                {
                    id_formulacao = decimal.Parse(value);
                }catch { id_formulacao = null; }
            }
        }
        public string Ds_formula { get; set; }
        private DateTime? dt_ordem;
        public DateTime? Dt_ordem
        {
            get { return dt_ordem; }
            set
            {
                dt_ordem = value;
                dt_ordemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_ordemstr;
        public string Dt_ordemstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_ordemstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ordemstr = value;
                try
                {
                    dt_ordem = Convert.ToDateTime(value);
                }
                catch
                { dt_ordem = null; }
            }
        }
        private DateTime? dt_previniprod;
        public DateTime? Dt_previniprod
        {
            get { return dt_previniprod; }
            set
            {
                dt_previniprod = value;
                dt_previniprodstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_previniprodstr;
        public string Dt_previniprodstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_previniprodstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_previniprodstr = value;
                try
                {
                    dt_previniprod = Convert.ToDateTime(value);
                }
                catch
                { dt_previniprod = null; }
            }
        }
        private DateTime? dt_prevfinprod;
        public DateTime? Dt_prevfinprod
        {
            get { return dt_prevfinprod; }
            set
            {
                dt_prevfinprod = value;
                dt_prevfinprodstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevfinprodstr;
        public string Dt_prevfinprodstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevfinprodstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_prevfinprodstr = value;
                try
                {
                    dt_prevfinprod = DateTime.Parse(value);
                }
                catch { dt_prevfinprod = null; }
            }
        }
        private DateTime? dt_iniprod;
        public DateTime? Dt_iniprod
        {
            get { return dt_iniprod; }
            set
            {
                dt_iniprod = value;
                dt_iniprodstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_iniprodstr;
        public string Dt_iniprodstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_iniprodstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_iniprodstr = value;
                try
                {
                    dt_iniprod = DateTime.Parse(value);
                }
                catch { dt_iniprod = null; }
            }
        }
        private DateTime? dt_finprod;
        public DateTime? Dt_finprod
        {
            get { return dt_finprod; }
            set
            {
                dt_finprod = value;
                dt_finprodstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finprodstr;
        public string Dt_finprodstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finprodstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finprodstr = value;
                try
                {
                    dt_finprod = DateTime.Parse(value);
                }
                catch { dt_finprod = null; }
            }
        }
        public string Nr_serie
        { get; set; }
        public decimal PesoLiquido
        { get; set; }
        public string Ds_comercial
        { get; set; }
        public string Ds_interna
        { get; set; }
        public int Qtd_batch
        { get; set; }
        public decimal Qtd_produzida
        { get; set; }
        public decimal Qt_produto { get; set; } = decimal.Zero;
        public decimal QT_Produzir => decimal.Multiply(Qtd_batch, Qt_produto);
        public decimal Qtd_saldoproduzir => QT_Produzir - Qtd_produzida;
        public decimal Altura
        { get; set; }
        public decimal Comprimento
        { get; set; }
        public decimal Largura
        { get; set; }
        public decimal Qt_Particao
        { get; set; }
        public int Qt_replicarOP { get; set; } = 1;
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (Qtd_produzida.Equals(decimal.Zero))
                    if (St_registro.Trim().ToUpper().Equals("A"))
                        return "ABERTA";
                    else if (St_registro.Trim().ToUpper().Equals("P"))
                        return "EM PRODUÇÃO";
                    else return string.Empty;
                else 
                {
                    if (Qtd_produzida > decimal.Zero && Qtd_saldoproduzir > decimal.Zero)
                        return "PARCIAL";
                    else if (Qtd_saldoproduzir.Equals(decimal.Zero))
                        return "PRODUZIDA";
                    else return string.Empty;
                }
            }
        }
        public TList_OrdemProducao_X_PedItem lPedItem
        { get; set; }
        public TList_OrdemProducao_X_PedItem lPedItemDel
        { get; set; }
        public TList_ApontamentoProducao lApontamento
        { get; set; }
        public TList_SerieProduto lSerie
        { get; set; }
        public TList_RegLanPedido_Item lItem
        { get; set; }
        public TList_Ordem_MPrima lOrdem_MPrima { get; set; }
        public TList_Ordem_MPrima lOrdem_MPrimaDel { get; set; }

        public TRegistro_OrdemProducao()
        {
            Id_ordem = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_unid_produto = string.Empty;
            Ds_unid_produto = string.Empty;
            Sg_unid_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            id_formulacao = null;
            id_formulacaostr = string.Empty;
            Ds_formula = string.Empty;
            dt_ordem = null;
            dt_ordemstr = string.Empty;
            dt_previniprod = null;
            dt_previniprodstr = string.Empty;
            dt_prevfinprod = null;
            dt_prevfinprodstr = string.Empty;
            dt_iniprod = null;
            dt_iniprodstr = string.Empty;
            dt_finprod = null;
            dt_finprodstr = string.Empty;
            Nr_serie = string.Empty;
            PesoLiquido = decimal.Zero;
            Ds_comercial = string.Empty;
            Ds_interna = string.Empty;
            Qtd_batch = 1;
            Altura = decimal.Zero;
            Largura = decimal.Zero;
            Comprimento = decimal.Zero;
            Qt_Particao = decimal.Zero;
            Ds_observacao = string.Empty;
            St_registro = "A";

            lPedItem = new TList_OrdemProducao_X_PedItem();
            lPedItemDel = new TList_OrdemProducao_X_PedItem();
            lApontamento = new TList_ApontamentoProducao();
            lSerie = new TList_SerieProduto();
            lItem = new TList_RegLanPedido_Item();
            lOrdem_MPrima = new TList_Ordem_MPrima();
            lOrdem_MPrimaDel = new TList_Ordem_MPrima();
        }
    }

    public class TCD_OrdemProducao : TDataQuery
    {
        public TCD_OrdemProducao()
        { }

        public TCD_OrdemProducao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.ID_Ordem, a.CD_Empresa, b.NM_Empresa, a.id_formulacao, ");
                sql.AppendLine("a.CD_Produto, c.DS_Produto, c.CD_Unidade as cd_unid_produto, c.ds_tecnica, c.ds_tecnicainterna, ");
                sql.AppendLine("d.DS_Unidade as ds_unid_produto, d.Sigla_Unidade as sg_unid_produto, ");
                sql.AppendLine("a.CD_Unidade, e.DS_Unidade, e.Sigla_Unidade, c.ps_unitario, ");
                sql.AppendLine("a.DT_PrevIniProd, a.DT_PrevFinProd, a.DT_IniProd, a.DT_FinProd, ");
                sql.AppendLine("a.QTD_Batch, a.QTD_Produzida, a.DS_Observacao, a.dt_ordem, a.QT_Produto, ");
                sql.AppendLine("a.altura, a.largura, a.comprimento, a.QT_Particao, a.ST_Registro, a.cd_local, f.ds_local, ");
                sql.AppendLine("Nr_serie = isnull((select top 1 x.Nr_serie from TB_PRD_SerieProduto x ");
                sql.AppendLine("                   where a.id_ordem = x.id_ordem and isnull(x.st_registro, 'A') <> 'C'), ' ') ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from VTB_PRD_OrdemProducao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.CD_Unidade = d.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on a.CD_Unidade = e.CD_Unidade ");
            sql.AppendLine("left outer join TB_EST_LocalArm f ");
            sql.AppendLine("on a.CD_Local = f.CD_Local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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

        public TList_OrdemProducao Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrdemProducao lista = new TList_OrdemProducao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemProducao reg = new TRegistro_OrdemProducao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("Cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("Ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("CD_Unid_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unid_Produto")))
                        reg.Ds_unid_produto = reader.GetString(reader.GetOrdinal("DS_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Unid_Produto")))
                        reg.Sg_unid_produto = reader.GetString(reader.GetOrdinal("SG_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("id_formulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Ordem")))
                        reg.Dt_ordem = reader.GetDateTime(reader.GetOrdinal("DT_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevIniProd")))
                        reg.Dt_previniprod = reader.GetDateTime(reader.GetOrdinal("DT_PrevIniProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevFinProd")))
                        reg.Dt_prevfinprod = reader.GetDateTime(reader.GetOrdinal("DT_PrevFinProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniProd")))
                        reg.Dt_iniprod = reader.GetDateTime(reader.GetOrdinal("DT_IniProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_FinProd")))
                        reg.Dt_finprod = reader.GetDateTime(reader.GetOrdinal("DT_FinProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_unitario")))
                        reg.PesoLiquido = reader.GetDecimal(reader.GetOrdinal("ps_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnica")))
                        reg.Ds_comercial = reader.GetString(reader.GetOrdinal("ds_tecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnicainterna")))
                        reg.Ds_interna = reader.GetString(reader.GetOrdinal("ds_tecnicainterna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Batch")))
                        reg.Qtd_batch = reader.GetInt32(reader.GetOrdinal("QTD_Batch"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Produzida")))
                        reg.Qtd_produzida = reader.GetDecimal(reader.GetOrdinal("QTD_Produzida"));

                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Produto")))
                        reg.Qt_produto = reader.GetDecimal(reader.GetOrdinal("QT_Produto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("altura")))
                        reg.Altura = reader.GetDecimal(reader.GetOrdinal("altura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("largura")))
                        reg.Largura = reader.GetDecimal(reader.GetOrdinal("largura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("comprimento")))
                        reg.Comprimento = reader.GetDecimal(reader.GetOrdinal("comprimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Particao")))
                        reg.Qt_Particao = reader.GetDecimal(reader.GetOrdinal("QT_Particao"));

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

        public string Gravar(TRegistro_OrdemProducao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(19);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_DT_ORDEM", val.Dt_ordem);
            hs.Add("@P_DT_PREVINIPROD", val.Dt_previniprod);
            hs.Add("@P_DT_PREVFINPROD", val.Dt_prevfinprod);
            hs.Add("@P_DT_INIPROD", val.Dt_iniprod);
            hs.Add("@P_DT_FINPROD", val.Dt_finprod);
            hs.Add("@P_QTD_BATCH", val.Qtd_batch);
            hs.Add("@P_QT_PRODUZIR", val.QT_Produzir);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ALTURA", val.Altura);
            hs.Add("@P_LARGURA", val.Largura);
            hs.Add("@P_COMPRIMENTO", val.Comprimento);
            hs.Add("@P_QT_PARTICAO", val.Qt_Particao);

            return executarProc("IA_PRD_ORDEMPRODUCAO", hs);
        }

        public string Excluir(TRegistro_OrdemProducao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);

            return executarProc("EXCLUI_PRD_ORDEMPRODUCAO", hs);
        }
    }
    #endregion

    #region Ficha Tecnica Ordem
    public class TList_Ordem_MPrima : List<TRegistro_Ordem_MPrima> { }
    public class TRegistro_Ordem_MPrima
    {
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
                    id_ordem = decimal.Parse(value);
                }catch { id_ordem = null; }
            }
        }
        private decimal? id_mprima;

        public decimal? Id_mprima
        {
            get { return id_mprima; }
            set
            {
                id_mprima = value;
                id_mprimastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mprimastr;

        public string Id_mprimastr
        {
            get { return id_mprimastr; }
            set
            {
                id_mprimastr = value;
                try
                {
                    id_mprima = decimal.Parse(value);
                }catch { id_mprima = null; }
            }
        }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Cd_unidade { get; set; }
        public string Ds_unidade { get; set; }
        public string Cd_unid_produto { get; set; }
        public string Ds_unid_produto { get; set; }
        public string Sigla_unidade { get; set; }
        public string Cd_local { get; set; }
        public string Ds_local { get; set; }
        public decimal Qtd_produto { set; get; }
        public decimal Qtd_produto_calc { get; set; }
        public decimal SaldoEstoque { get; set; }
        public decimal Pc_quebratec { get; set; }
        public bool St_multparticao { get; set; }
        public string CD_Empresa { get; set; }
        public decimal? ID_Formulacao_MPrima { get; set; }
        public TRegistro_Ordem_MPrima()
        {
            id_ordem = null;
            id_ordemstr = string.Empty;
            id_mprima = null;
            id_mprimastr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Cd_unid_produto = string.Empty;
            Ds_unid_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Qtd_produto = decimal.Zero;
            SaldoEstoque = decimal.Zero;
            Pc_quebratec = decimal.Zero;
            St_multparticao = false;
        }
    }
    public class TCD_Ordem_MPrima:TDataQuery
    {
        public TCD_Ordem_MPrima() { }
        public TCD_Ordem_MPrima(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_ordem, a.id_mprima, a.cd_produto, ");
                sql.AppendLine("b.ds_produto, a.cd_unidade, d.ds_unidade, b.cd_unidade as CD_Unid_produto, d.sigla_unidade, ");
                sql.AppendLine("f.ds_unidade as ds_unid_produto, a.cd_local, e.ds_local, a.qtd_produto, a.pc_quebratec, ");
                sql.AppendLine("a.cd_empresa, a.id_formulacao_mprima");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_ordem_mprima a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on a.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm e ");
            sql.AppendLine("on a.cd_local = e.cd_local ");
            sql.AppendLine("inner join tb_est_unidade f ");
            sql.AppendLine("on f.cd_unidade = b.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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
        public TList_Ordem_MPrima Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Ordem_MPrima lista = new TList_Ordem_MPrima();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Ordem_MPrima reg = new TRegistro_Ordem_MPrima();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("id_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_mprima")))
                        reg.Id_mprima = reader.GetDecimal(reader.GetOrdinal("id_mprima"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("CD_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unid_produto")))
                        reg.Ds_unid_produto = reader.GetString(reader.GetOrdinal("DS_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_produto")))
                    {
                        reg.Qtd_produto = reader.GetDecimal(reader.GetOrdinal("qtd_produto"));
                        reg.Qtd_produto_calc = reg.Qtd_produto;
                    }
                     if (!reader.IsDBNull(reader.GetOrdinal("pc_quebratec")))
                        reg.Pc_quebratec = reader.GetDecimal(reader.GetOrdinal("pc_quebratec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Formulacao_MPrima")))
                        reg.ID_Formulacao_MPrima = reader.GetDecimal(reader.GetOrdinal("ID_Formulacao_MPrima"));
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
        public string Gravar(TRegistro_Ordem_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_MPRIMA", val.Id_mprima);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QTD_PRODUTO", val.Qtd_produto);
            hs.Add("@P_PC_QUEBRATEC", val.Pc_quebratec);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa);
            hs.Add("@P_ID_FORMULACAO_MPRIMA", val.ID_Formulacao_MPrima);
            return executarProc("IA_PRD_ORDEM_MPRIMA", hs);
        }
        public string Excluir(TRegistro_Ordem_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_MPRIMA", val.Id_mprima);
            return executarProc("EXCLUI_PRD_ORDEM_MPRIMA", hs);
        }
    }
    #endregion

    #region Ordem Producao X Pedido Item
    public class TList_OrdemProducao_X_PedItem : List<TRegistro_OrdemProducao_X_PedItem>, IComparer<TRegistro_OrdemProducao_X_PedItem>
    {
        #region IComparer<TRegistro_OrdemProducao_X_PedItem> Members
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

        public TList_OrdemProducao_X_PedItem()
        { }

        public TList_OrdemProducao_X_PedItem(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemProducao_X_PedItem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemProducao_X_PedItem x, TRegistro_OrdemProducao_X_PedItem y)
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

    
    public class TRegistro_OrdemProducao_X_PedItem
    {
        
        public decimal? Id_ordem
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public string Cd_produto
        {get;set;}
        
        public decimal? Id_pedidoitem
        { get; set; }

        public TRegistro_OrdemProducao_X_PedItem()
        {
            Id_ordem = null;
            Nr_pedido = null;
            Cd_produto = string.Empty;
            Id_pedidoitem = null;
        }
    }

    public class TCD_OrdemProducao_X_PedItem : TDataQuery
    {
        public TCD_OrdemProducao_X_PedItem()
        { }

        public TCD_OrdemProducao_X_PedItem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.ID_Ordem, a.Nr_Pedido, a.CD_Produto, a.ID_PedidoItem ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PRD_OrdemProducao_X_PedItem a ");
            string cond = " where ";
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

        public TList_OrdemProducao_X_PedItem Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrdemProducao_X_PedItem lista = new TList_OrdemProducao_X_PedItem();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemProducao_X_PedItem reg = new TRegistro_OrdemProducao_X_PedItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));

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

        public string Gravar(TRegistro_OrdemProducao_X_PedItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return executarProc("IA_PRD_ORDEMPRODUCAO_X_PEDITEM", hs);
        }

        public string Excluir(TRegistro_OrdemProducao_X_PedItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return executarProc("EXCLUI_PRD_ORDEMPRODUCAO_X_PEDITEM", hs);
        }
    }
    #endregion

    #region Ordem Producao X Apontamento
    public class TList_OrdemProducao_X_Apontamento : List<TRegistro_OrdemProducao_X_Apontamento>, IComparer<TRegistro_OrdemProducao_X_Apontamento>
    {
        #region IComparer<TRegistro_OrdemProducao_X_Apontamento> Members
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

        public TList_OrdemProducao_X_Apontamento()
        { }

        public TList_OrdemProducao_X_Apontamento(System.ComponentModel.PropertyDescriptor Prop,
                                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemProducao_X_Apontamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemProducao_X_Apontamento x, TRegistro_OrdemProducao_X_Apontamento y)
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

    
    public class TRegistro_OrdemProducao_X_Apontamento
    {
        
        public decimal? Id_ordem
        { get; set; }
        
        public decimal? Id_apontamento
        { get; set; }

        public TRegistro_OrdemProducao_X_Apontamento()
        {
            Id_ordem = null;
            Id_apontamento = null;
        }
    }

    public class TCD_OrdemProducao_X_Apontamento : TDataQuery
    {
        public TCD_OrdemProducao_X_Apontamento()
        { }

        public TCD_OrdemProducao_X_Apontamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.ID_Ordem, a.ID_Apontamento ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PRD_OrdemProducao_X_Apontamento a ");
            string cond = " where ";
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

        public TList_OrdemProducao_X_Apontamento Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrdemProducao_X_Apontamento lista = new TList_OrdemProducao_X_Apontamento();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemProducao_X_Apontamento reg = new TRegistro_OrdemProducao_X_Apontamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));

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

        public string Gravar(TRegistro_OrdemProducao_X_Apontamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);

            return executarProc("IA_PRD_ORDEMPRODUCAO_X_APONTAMENTO", hs);
        }

        public string Excluir(TRegistro_OrdemProducao_X_Apontamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);

            return executarProc("EXCLUI_PRD_ORDEMPRODUCAO_X_APONTAMENTO", hs);
        }
    }
    #endregion

    #region Ordem Producao X Requisicao
    public class TList_OrdemProducao_X_Requisicao : List<TRegistro_OrdemProducao_X_Requisicao>, IComparer<TRegistro_OrdemProducao_X_Requisicao>
    {
        #region IComparer<TRegistro_OrdemProducao_X_Requisicao> Members
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

        public TList_OrdemProducao_X_Requisicao()
        { }

        public TList_OrdemProducao_X_Requisicao(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemProducao_X_Requisicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemProducao_X_Requisicao x, TRegistro_OrdemProducao_X_Requisicao y)
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


    public class TRegistro_OrdemProducao_X_Requisicao
    {

        public decimal? Id_ordem
        { get; set; }

        public decimal? Id_requisicao
        { get; set; }

        public string Cd_empresa
        { get; set; }

        public TRegistro_OrdemProducao_X_Requisicao()
        {
            Id_ordem = null;
            Id_requisicao = null;
            Cd_empresa = string.Empty;
        }
    }

    public class TCD_OrdemProducao_X_Requisicao : TDataQuery
    {
        public TCD_OrdemProducao_X_Requisicao()
        { }

        public TCD_OrdemProducao_X_Requisicao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.ID_Ordem, a.ID_Requisicao, a.CD_Empresa ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PRD_OrdemProducao_X_Requisicao a ");
            string cond = " where ";
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

        public TList_OrdemProducao_X_Requisicao Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrdemProducao_X_Requisicao lista = new TList_OrdemProducao_X_Requisicao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemProducao_X_Requisicao reg = new TRegistro_OrdemProducao_X_Requisicao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Requisicao")))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_Requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));

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

        public string Gravar(TRegistro_OrdemProducao_X_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("IA_PRD_ORDEMPRODUCAO_X_REQUISICAO", hs);
        }

        public string Excluir(TRegistro_OrdemProducao_X_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PRD_ORDEMPRODUCAO_X_REQUISICAO", hs);
        }
    }
    #endregion

    #region Disponibilidade MPrima
    public class TList_MPrima : List<TRegistro_MPrima>, IComparer<TRegistro_MPrima>
    {
        #region IComparer<TRegistro_MPrima> Members
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

        public TList_MPrima()
        { }

        public TList_MPrima(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MPrima value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MPrima x, TRegistro_MPrima y)
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
    
    public class TRegistro_MPrima
    {
        public string Cd_mprima
        { get; set; }
        
        public string Ds_mprima
        { get; set; }

        public string Cd_alternativo
        { get; set; }

        public decimal Cd_marca
        { get; set; }

        public string Ds_marca
        { get; set; }

        public string Sigla_unidade
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public decimal Qtd_mprima
        { get; set; }
        
        public decimal Vl_custounit
        { get; set; }
        public decimal Vl_custo
        { get { return Qtd_mprima * Vl_custounit; } }
        
        public decimal Qtd_saldolocal
        { get; set; }
        public decimal Qtd_saldonecessario
        { get { return Qtd_saldolocal - Qtd_mprima; } }
        public TList_MPrima lMPrima
        { get; set; }

        public TRegistro_MPrima()
        {
            Cd_mprima = string.Empty;
            Ds_mprima = string.Empty;
            Cd_alternativo = string.Empty;
            Cd_marca = decimal.Zero;
            Ds_marca = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Qtd_mprima = decimal.Zero;
            Qtd_saldolocal = decimal.Zero;
            lMPrima = new TList_MPrima();
        }
    }
    #endregion
}
