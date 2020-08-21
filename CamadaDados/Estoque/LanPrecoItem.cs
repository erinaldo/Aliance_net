using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque
{
    #region Classe Produto Preco
    public class TList_ProdutoPreco : List<TRegistro_ProdutoPreco>, IComparer<TRegistro_ProdutoPreco>
    {
        #region IComparer<TRegistro_ProdutoPreco> Members
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

        public TList_ProdutoPreco()
        { }

        public TList_ProdutoPreco(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProdutoPreco value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProdutoPreco x, TRegistro_ProdutoPreco y)
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
    
    public class TRegistro_ProdutoPreco
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Nr_patrimonio
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public decimal Vl_estoque
        { get; set; }
        public decimal Vl_ultimacompra
        { get; set; }
        public decimal Pc_indice_venda
        { get; set; }
        public decimal Vl_custoreal
        {
            get
            {
                if (Pc_indice_venda > decimal.Zero)
                    return decimal.Divide(Vl_estoque, decimal.Divide(100 - Pc_indice_venda, 100));
                else return Vl_estoque;
            }
        }
        public decimal Vl_ultimopreco
        { get; set; }
        public DateTime? Dt_ultimavigencia
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_ProdutoPreco()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Nr_patrimonio = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Vl_estoque = decimal.Zero;
            Vl_ultimacompra = decimal.Zero;
            Pc_indice_venda = decimal.Zero;
            St_processar = false;
            Vl_ultimopreco = decimal.Zero;
            Dt_ultimavigencia = null;
        }
    }
    #endregion

    public class TList_LanPrecoItem : List<TRegistro_LanPrecoItem>, IComparer<TRegistro_LanPrecoItem>
    {
        #region IComparer<TRegistro_LanPrecoItem> Members
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

        public TList_LanPrecoItem()
        { }

        public TList_LanPrecoItem(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPrecoItem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPrecoItem x, TRegistro_LanPrecoItem y)
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
    
    public class TRegistro_LanPrecoItem
    {
        public decimal? Id_precoitem { get; set; }
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        public string Codigo_Alternativo { get; set; }
        public string CD_TabelaPreco { get; set; }
        public string Ds_tabelapreco { get; set; }
        private DateTime? dt_preco;
        public DateTime? Dt_preco
        {
            get { return dt_preco; }
            set
            {
                dt_preco = value;
                _dt_preco_string = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string _dt_preco_string;
        public string Dt_preco_string
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_dt_preco_string).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                _dt_preco_string = value;
                try
                {
                    dt_preco = Convert.ToDateTime(value);
                }
                catch
                { dt_preco = null; }
            }
        }
        private DateTime? dt_finvigencia = null;
        public DateTime? Dt_finvigencia
        {
            get { return dt_finvigencia; }
            set
            {
                dt_finvigencia = value;
                dt_finvigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finvigenciastr = string.Empty;
        public string Dt_finvigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finvigenciastr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_finvigenciastr = value;
                try
                {
                    dt_finvigencia = DateTime.Parse(value);
                }catch { dt_finvigencia = null; }
            }
        }
        public decimal Vl_ultimacompra { get; set; }
        public decimal VL_PrecoVenda{ get; set; }
        public decimal Vl_custoatual { get; set; }
        public decimal Pc_indice_venda { get; set; }
        public decimal Pc_margemPreco
        {
            get
            {
                if (Vl_custoreal.Equals(decimal.Zero) || VL_PrecoVenda.Equals(decimal.Zero))
                    return 100;
                else return 100 - decimal.Multiply(decimal.Divide(Vl_custoreal, VL_PrecoVenda), 100);
            } 
        }
        public decimal Pc_margemPrecoCompra
        {
            get
            {
                if (Vl_ultimacompra.Equals(decimal.Zero) || VL_PrecoVenda.Equals(decimal.Zero))
                    return 100;
                else return 100 - decimal.Multiply(decimal.Divide(Vl_ultimacompra, VL_PrecoVenda), 100);
            }
        }
        public decimal Vl_custoreal
        {
            get 
            {
                if (Pc_indice_venda > decimal.Zero)
                    return decimal.Divide(Vl_custoatual, decimal.Divide(100 - Pc_indice_venda, 100));
                else return Vl_custoatual;
            }
        }
        public decimal Vl_NovoPreco
        {
            get;
            set;
        }
        public decimal Pc_ajuste
        { get; set; }
        private System.Drawing.Image imagem;
        public System.Drawing.Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (System.Drawing.Image)new System.Drawing.ImageConverter().ConvertFrom(value);
            }
        }
        public decimal Qtd_validade
        { get; set; }
        public DateTime Dt_atual { get; set; } = DateTime.Now;
        public string Status { get { return dt_finvigencia.HasValue ? dt_finvigencia < Dt_atual ? "EXPIRADO": "ATIVO" : "ATIVO"; } }

        public TRegistro_LanPrecoItem()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            Codigo_Alternativo = string.Empty;
            CD_TabelaPreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            dt_preco = DateTime.Now;
            _dt_preco_string = DateTime.Now.ToString();
            Vl_ultimacompra = decimal.Zero;
            VL_PrecoVenda = decimal.Zero;
            Vl_custoatual = decimal.Zero;
            Vl_NovoPreco = decimal.Zero;
            Pc_indice_venda = decimal.Zero;
            Pc_ajuste = decimal.Zero;
            imagem = null;
            img = null;
            Qtd_validade = decimal.Zero;
        }
    }
    
    public class TCD_LanPrecoItem : TDataQuery
    {
        public TCD_LanPrecoItem() { }
        
        public TCD_LanPrecoItem(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        public TCD_LanPrecoItem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public TCD_LanPrecoItem(string vNM_ProcSqlBusca, BancoDados.TObjetoBanco banco)
        { NM_ProcSqlBusca = vNM_ProcSqlBusca; Banco_Dados = banco; }

        public string SqlCodeBusca_Itens(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " d.st_servico, a.cd_produto, a.cd_grupo, ");
                sql.AppendLine("a.ds_produto, isnull(b.vl_saldoestoque,0) as vl_saldoestoque,");
                sql.AppendLine("isnull(b.vl_medio,0) as vl_medio, isnull(b.tot_saldo,0) as tot_saldo, ");
                sql.AppendLine("b.cd_empresa, c.sigla_unidade ");
                
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_PRODUTO a");
            sql.AppendLine("inner join vtb_EST_vlestoque b ");
            sql.AppendLine("on b.cd_produto = a.cd_produto");
            sql.AppendLine("inner join TB_EST_unidade c ");
            sql.AppendLine("on c.cd_unidade = a.cd_unidade ");
            sql.AppendLine("inner join TB_EST_TpProduto d ");
            sql.AppendLine("on a.tp_produto = d.tp_produto ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.Append("Order by a.cd_produto");
            return sql.ToString();
        }

        private string SqlCodeBusca_Preco(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.CD_Empresa, c.nm_empresa, ");
                sql.AppendLine("a.CD_Produto, b.ds_produto, b.Codigo_Alternativo, a.CD_TabelaPreco, d.ds_tabelapreco, ");
                sql.AppendLine("a.dt_preco, a.vl_precovenda, a.id_precoitem, b.QT_Dias_PrazoGarantia as Qtd_validade, ");
                sql.AppendLine("a.dt_finvigencia, getdate() as dt_atual, ");
                sql.AppendLine("vl_medio = dbo.F_CUSTO_MEDIOESTOQUE(a.cd_empresa, a.cd_produto, null), ");
                sql.AppendLine("vl_ueps = isnull(dbo.F_FAT_ULTIMACOMPRA(a.cd_empresa, a.cd_produto), 0), ");
                sql.AppendLine("pc_indice_venda = isnull((select top 1 x.Vl_Numerico ");
                sql.AppendLine("                    from TB_CFG_ParamGer x ");
                sql.AppendLine("                    where x.DS_Parametro = 'PC_INDICE_VENDA'), 0), ");
                sql.AppendLine("imagem = (select top 1 x.imagem ");
                sql.AppendLine("            from TB_EST_PRODUTO_Imagens x ");
                sql.AppendLine("            where x.cd_produto = b.cd_produto ");
                sql.AppendLine("            order by x.id_imagem asc) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_est_precoitem a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_div_tabelapreco d ");
            sql.AppendLine("on a.cd_tabelapreco = d.cd_tabelapreco ");
            sql.AppendLine("where isnull(b.st_registro, 'A') <> 'C' ");
           
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.Append("Order By a.cd_empresa asc, a.cd_tabelapreco asc, a.cd_produto asc, a.dt_preco desc");
            return sql.ToString();
        }

        private string SqlCodeBusca_ProdutoPreco(string Cd_empresa,
                                                 string Cd_tabelapreco,
                                                 TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Produto, a.DS_Produto, ");
            sql.AppendLine("a.CD_Grupo, LTRIM(b.DS_Grupo) as DS_Grupo, c.Sigla_Unidade, ");
            sql.AppendLine("Vl_UEPS = isnull(dbo.F_FAT_ULTIMACOMPRA('" + Cd_empresa.Trim() + "', a.cd_produto), 0), ");
            sql.AppendLine("vl_estoque = dbo.F_CUSTO_MEDIOESTOQUE('" + Cd_empresa.Trim() + "', a.cd_produto, null), ");
            sql.AppendLine("vl_ultimopreco = isnull((select top 1 x.vl_precovenda ");
            sql.AppendLine("                    from tb_est_precoitem x ");
            sql.AppendLine("                    where x.cd_produto = a.cd_produto ");
            sql.AppendLine("                    and x.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("                    and x.cd_tabelapreco = '" + Cd_tabelapreco.Trim() + "'");
            sql.AppendLine("                    order by x.dt_preco desc), 0), ");
            sql.AppendLine("dt_ultimavigencia = (select top 1 x.dt_preco ");
            sql.AppendLine("                    from tb_est_precoitem x ");
            sql.AppendLine("                    where x.cd_produto = a.cd_produto ");
            sql.AppendLine("                    and x.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("                    and x.cd_tabelapreco = '" + Cd_tabelapreco.Trim() + "'");
            sql.AppendLine("                    order by x.dt_preco desc), ");
            sql.AppendLine("pc_indice_venda = isnull((select top 1 x.Vl_Numerico ");
            sql.AppendLine("                    from TB_CFG_ParamGer x ");
            sql.AppendLine("                    where x.DS_Parametro = 'PC_INDICE_VENDA'), 0), ");
            sql.AppendLine("Nr_Patrimonio = isnull((select x.NR_Patrimonio from TB_EST_Patrimonio x ");
            sql.AppendLine("                        where x.CD_Patrimonio = a.CD_Produto), '') ");

            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_GrupoProduto b ");
            sql.AppendLine("on a.CD_Grupo = b.CD_Grupo ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on a.CD_Unidade = c.CD_Unidade ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public string SqlCodeBusca_ConsultaPreco(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT distinct a.CD_Empresa, a.CD_Produto, ");
                sql.AppendLine("a.CD_TabelaPreco, b.DS_TabelaPreco, a.Vl_PrecoVenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_EST_PRECOVENDA a ");
            sql.AppendLine("inner join tb_div_tabelapreco b ");
            sql.AppendLine("on a.cd_tabelapreco = b.cd_tabelapreco ");

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
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca_Preco(vBusca, vTop, ""), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, "" }).ToString();
                return ExecutarBusca(sql, null);
            } 
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBuscaEscalar(SqlCodeBusca_Preco(vBusca, 1, vNM_Campo), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            } 
        }
                
        protected override object ExecutarBuscaEscalar(string vSQLCode, Hashtable Parametros)
        {
            return base.ExecutarBuscaEscalar(vSQLCode, Parametros);
        }

        public TList_LanPrecoItem Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LanPrecoItem lista = new TList_LanPrecoItem();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca_Preco(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPrecoItem reg = new TRegistro_LanPrecoItem();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PrecoItem")))
                        reg.Id_precoitem = reader.GetDecimal(reader.GetOrdinal("ID_PrecoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Codigo_Alternativo = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        reg.CD_TabelaPreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_PrecoVenda")))
                        reg.VL_PrecoVenda = reader.GetDecimal(reader.GetOrdinal("VL_PrecoVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_medio")))
                        reg.Vl_custoatual = reader.GetDecimal(reader.GetOrdinal("vl_medio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ueps")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ueps"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Dt_preco"))))
                        reg.Dt_preco = reader.GetDateTime(reader.GetOrdinal("Dt_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_finvigencia")))
                        reg.Dt_finvigencia = reader.GetDateTime(reader.GetOrdinal("dt_finvigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_atual")))
                        reg.Dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_indice_venda")))
                        reg.Pc_indice_venda = reader.GetDecimal(reader.GetOrdinal("pc_indice_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_validade")))
                        reg.Qtd_validade = reader.GetDecimal(reader.GetOrdinal("Qtd_validade"));
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public TList_LanPrecoItem SelectConsultaPreco(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LanPrecoItem lista = new TList_LanPrecoItem();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca_ConsultaPreco(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPrecoItem reg = new TRegistro_LanPrecoItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_precoVenda")))
                        reg.VL_PrecoVenda = reader.GetDecimal(reader.GetOrdinal("vl_PrecoVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_TabelaPreco")))
                        reg.CD_TabelaPreco = reader.GetString(reader.GetOrdinal("cd_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public TList_ProdutoPreco SelectProdutoPreco(string Cd_empresa, string Cd_tabelapreco, TpBusca[] vBusca)
        {
            TList_ProdutoPreco lista = new TList_ProdutoPreco();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca_ProdutoPreco(Cd_empresa, Cd_tabelapreco, vBusca));
                while (reader.Read())
                {
                    TRegistro_ProdutoPreco reg = new TRegistro_ProdutoPreco();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_estoque")))
                        reg.Vl_estoque = reader.GetDecimal(reader.GetOrdinal("vl_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_indice_venda")))
                        reg.Pc_indice_venda = reader.GetDecimal(reader.GetOrdinal("pc_indice_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ueps")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ueps"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ultimopreco")))
                        reg.Vl_ultimopreco = reader.GetDecimal(reader.GetOrdinal("vl_ultimopreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ultimavigencia")))
                        reg.Dt_ultimavigencia = reader.GetDateTime(reader.GetOrdinal("dt_ultimavigencia"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_LanPrecoItem vRegistro)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_PRECOITEM", vRegistro.Id_precoitem);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_CD_TABELAPRECO", vRegistro.CD_TabelaPreco);
            hs.Add("@P_DT_PRECO", vRegistro.Dt_preco);
            hs.Add("@P_DT_FINVIGENCIA", vRegistro.Dt_finvigencia);
            hs.Add("@P_VL_PRECOVENDA", vRegistro.Vl_NovoPreco.Equals(0) ? vRegistro.VL_PrecoVenda : vRegistro.Vl_NovoPreco);

            return executarProc("IA_EST_PRECOITEM", hs);
        }

        public string Excluir(TRegistro_LanPrecoItem vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_PRECOITEM", vRegistro.Id_precoitem);
            
            return executarProc("EXCLUI_EST_PRECOITEM", hs);
        }
    }
}

