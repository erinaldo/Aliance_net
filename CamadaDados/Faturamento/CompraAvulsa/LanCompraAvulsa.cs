using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CompraAvulsa
{
    #region Compra Avulsa
    public class TList_CompraAvulsa : List<TRegistro_CompraAvulsa>, IComparer<TRegistro_CompraAvulsa>
    { 
        #region IComparer<TRegistro_Cad_Genero> Members
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

        public TList_CompraAvulsa()
        { }

        public TList_CompraAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CompraAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CompraAvulsa x, TRegistro_CompraAvulsa y)
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

    
    public class TRegistro_CompraAvulsa
    {
        
        public string NR_Compra
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? id_compra;
        
        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;
        
        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
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
        private DateTime? dt_compra;
        
        public DateTime? Dt_compra
        {
            get { return dt_compra; }
            set
            {
                dt_compra = value;
                dt_comprastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_comprastr;
        public string Dt_comprastr
        {
            get { return dt_comprastr; }
            set
            {
                dt_comprastr = value;
                try
                {
                    dt_compra = DateTime.Parse(value);
                }
                catch
                { dt_compra = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("F"))
                    return "FATURADO";
                else return "ATIVO";
            }
        }
        
        public TList_Compra_Itens lItens
        { get; set; }
        
        public TList_Compra_Itens lItensDel
        { get; set; }

        
        public decimal Pc_desconto
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Vl_despesas
        { get; set; }
        
        public decimal Vl_totalitens
        { get; set; }
        
        public decimal Vl_totalcompra
        { get { return Vl_totalitens - (Vl_desconto) +(Vl_despesas); } }
        
        public bool St_processar
        { get; set; }

        public TRegistro_CompraAvulsa()
        {
            this.NR_Compra = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.dt_compra = null;
            this.dt_comprastr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";

            this.lItens = new TList_Compra_Itens();
            this.lItensDel = new TList_Compra_Itens();

            this.Pc_desconto = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.Vl_despesas = decimal.Zero;
            this.Vl_totalitens = decimal.Zero;

            this.St_processar = false;
        }
    }

    public class TCD_CompraAvulsa : TDataQuery
    {
        public TCD_CompraAvulsa()
        { }

        public TCD_CompraAvulsa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Compra, ");
                sql.AppendLine("a.CD_Clifor, c.NM_Clifor, a.CD_Endereco, a.Vl_TotalItens, a.Vl_desconto, a.Vl_despesas, ");
                sql.AppendLine("a.NR_compra, d.DS_Endereco, a.DT_Compra, a.DS_Observacao, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_FAT_CompraAvulsa a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = d.CD_Endereco ");

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

        public TList_CompraAvulsa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CompraAvulsa lista = new TList_CompraAvulsa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CompraAvulsa reg = new TRegistro_CompraAvulsa();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_compra")))
                        reg.NR_Compra = reader.GetString(reader.GetOrdinal("NR_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("DT_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalItens")))
                        reg.Vl_totalitens = reader.GetDecimal(reader.GetOrdinal("Vl_TotalItens"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_despesas"));
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

        public string Gravar(TRegistro_CompraAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_NR_COMPRA", val.NR_Compra);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DT_COMPRA", val.Dt_compra);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAT_COMPRAAVULSA", hs);
        }

        public string Excluir(TRegistro_CompraAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);

            return this.executarProc("EXCLUI_FAT_COMPRAAVULSA", hs);
        }
    }
    #endregion

    #region Compra Itens
    public class TList_Compra_Itens : List<TRegistro_Compra_Itens>, IComparer<TRegistro_Compra_Itens>
    {

        #region IComparer<TRegistro_Compra_Itens> Members
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

        public TList_Compra_Itens()
        { }

        public TList_Compra_Itens(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Compra_Itens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Compra_Itens x, TRegistro_Compra_Itens y)
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

    
    public class TRegistro_Compra_Itens
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_compra;
        
        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;
        
        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
            }
        }
        private decimal? id_itemcompra;
        
        public decimal? Id_itemcompra
        {
            get { return id_itemcompra; }
            set
            {
                id_itemcompra = value;
                id_itemcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcomprastr;
        
        public string Id_itemcomprastr
        {
            get { return id_itemcomprastr; }
            set
            {
                id_itemcomprastr = value;
                try
                {
                    id_itemcompra = decimal.Parse(value);
                }
                catch
                { id_itemcompra = null; }
            }
        }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Qtd_os
        { get; set; }
        public decimal SD_Qtde
        { get { return Quantidade - Qtd_os; } }
        
        public decimal Vl_despesas
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }
        
        public decimal Pc_desconto
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Vl_subtotalliq
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public bool St_processar
        { get; set; }

        
        public TList_CompraItens_X_PecaOS lItemOs
        { get; set; }
        public Servicos.TList_LanServico lOs { get; set; }

        public TRegistro_Compra_Itens()
        {
            this.Cd_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.id_itemcompra = null;
            this.id_itemcomprastr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Qtd_os = decimal.Zero;
            this.Vl_despesas = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Pc_desconto = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.Vl_subtotalliq = decimal.Zero;
            this.Nr_pedido = null;
            this.St_processar = false;

            this.lItemOs = new TList_CompraItens_X_PecaOS();
            lOs = new Servicos.TList_LanServico();
        }
    }

    public class TCD_Compra_Itens : TDataQuery
    {
        public TCD_Compra_Itens()
        { }

        public TCD_Compra_Itens(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Compra, a.ID_ItemCompra, ");
                sql.AppendLine("a.CD_Produto, b.ds_produto, b.CD_Unidade, c.DS_Unidade, a.qtd_os, ");
                sql.AppendLine("c.Sigla_Unidade, a.CD_Local, d.DS_Local, a.Quantidade, a.NR_Pedido, ");
                sql.AppendLine("a.vl_despesas, a.Vl_Unitario, a.Vl_Subtotal, a.Vl_Desconto, a.Vl_SubTotalLiq ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_FAT_COMPRA_ITENS a ");
            sql.AppendLine("inner join tb_fat_compraavulsa cp ");
            sql.AppendLine("on a.cd_empresa = cp.cd_empresa ");
            sql.AppendLine("and a.id_compra = cp.id_compra ");
            sql.AppendLine("left outer join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("left outer join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("left outer join TB_EST_LocalArm d ");
            sql.AppendLine("on a.CD_Local = d.CD_Local ");

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

        public TList_Compra_Itens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Compra_Itens lista = new TList_Compra_Itens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Compra_Itens reg = new TRegistro_Compra_Itens();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCompra")))
                        reg.Id_itemcompra = reader.GetDecimal(reader.GetOrdinal("ID_ItemCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("vl_despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_Subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotalLiq")))
                        reg.Vl_subtotalliq = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotalLiq"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_os")))
                        reg.Qtd_os = reader.GetDecimal(reader.GetOrdinal("Qtd_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));

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

        public string Gravar(TRegistro_Compra_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_DESPESAS", val.Vl_despesas);

            return this.executarProc("IA_FAT_COMPRA_ITENS", hs);
        }

        public string Excluir(TRegistro_Compra_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);

            return this.executarProc("EXCLUI_FAT_COMPRA_ITENS", hs);
        }
    }
    #endregion

    #region Compra Itens X Estoque
    public class TList_CompraItens_X_Estoque : List<TRegistro_CompraItens_X_Estoque>
    { }

    
    public class TRegistro_CompraItens_X_Estoque
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_compra;
        
        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;
        
        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
            }
        }
        private decimal? id_itemcompra;
        
        public decimal? Id_itemcompra
        {
            get { return id_itemcompra; }
            set
            {
                id_itemcompra = value;
                id_itemcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcomprastr;
        
        public string Id_itemcomprastr
        {
            get { return id_itemcomprastr; }
            set
            {
                id_itemcomprastr = value;
                try
                {
                    id_itemcompra = decimal.Parse(value);
                }
                catch
                { id_itemcompra = null; }
            }
        }
        
        public string Cd_produto
        { get; set; }
        private decimal? id_lanctoestoque;
        
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }

        public TRegistro_CompraItens_X_Estoque()
        {
            this.Cd_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.id_itemcompra = null;
            this.id_itemcomprastr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_lanctoestoque = null;
            this.id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_CompraItens_X_Estoque : TDataQuery
    {
        public TCD_CompraItens_X_Estoque()
        { }

        public TCD_CompraItens_X_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Compra, ");
                sql.AppendLine("a.ID_ItemCompra, a.CD_Produto, a.ID_LanctoEstoque ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CompraItens_X_Estoque a ");

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

        public TList_CompraItens_X_Estoque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CompraItens_X_Estoque lista = new TList_CompraItens_X_Estoque();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CompraItens_X_Estoque reg = new TRegistro_CompraItens_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCompra")))
                        reg.Id_itemcompra = reader.GetDecimal(reader.GetOrdinal("ID_ItemCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));

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

        public string Gravar(TRegistro_CompraItens_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("IA_FAT_COMPRAITENS_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_CompraItens_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_FAT_COMPRAITENS_X_ESTOQUE", hs);
        }
    }
    #endregion

    #region Compra Itens X Almoxarifado
    public class TList_CompraItens_X_Almox : List<TRegistro_CompraItens_X_Almox>
    { }


    public class TRegistro_CompraItens_X_Almox
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_compra;

        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;

        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
            }
        }
        private decimal? id_itemcompra;

        public decimal? Id_itemcompra
        {
            get { return id_itemcompra; }
            set
            {
                id_itemcompra = value;
                id_itemcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcomprastr;

        public string Id_itemcomprastr
        {
            get { return id_itemcomprastr; }
            set
            {
                id_itemcomprastr = value;
                try
                {
                    id_itemcompra = decimal.Parse(value);
                }
                catch
                { id_itemcompra = null; }
            }
        }

        public string Cd_produto
        { get; set; }
        private decimal? id_movimento;

        public decimal? Id_movimento
        {
            get { return id_movimento; }
            set
            {
                id_movimento = value;
                id_movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movimentostr;

        public string Id_movimentostr
        {
            get { return id_movimentostr; }
            set
            {
                id_movimentostr = value;
                try
                {
                    id_movimento = decimal.Parse(value);
                }
                catch
                { id_movimento = null; }
            }
        }

        public TRegistro_CompraItens_X_Almox()
        {
            this.Cd_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.id_itemcompra = null;
            this.id_itemcomprastr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;
        }
    }

    public class TCD_CompraItens_X_Almox : TDataQuery
    {
        public TCD_CompraItens_X_Almox()
        { }

        public TCD_CompraItens_X_Almox(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Compra, ");
                sql.AppendLine("a.ID_ItemCompra, a.ID_Movimento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CompraItens_X_Almox a ");

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

        public TList_CompraItens_X_Almox Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CompraItens_X_Almox lista = new TList_CompraItens_X_Almox();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CompraItens_X_Almox reg = new TRegistro_CompraItens_X_Almox();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCompra")))
                        reg.Id_itemcompra = reader.GetDecimal(reader.GetOrdinal("ID_ItemCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("ID_Movimento"));

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

        public string Gravar(TRegistro_CompraItens_X_Almox val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);

            return this.executarProc("IA_FAT_COMPRAITENS_X_ALMOX", hs);
        }

        public string Excluir(TRegistro_CompraItens_X_Almox val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);

            return this.executarProc("EXCLUI_FAT_COMPRAITENS_X_ALMOX", hs);
        }
    }
    #endregion

    #region Compra Itens X Pedido Itens
    public class TList_CompraItens_X_PedidoItens : List<TRegistro_CompraItens_X_PedidoItens>
    { }

    
    public class TRegistro_CompraItens_X_PedidoItens
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_compra;
        
        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;
        
        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
            }
        }
        private decimal? id_itemcompra;
        
        public decimal? Id_itemcompra
        {
            get { return id_itemcompra; }
            set
            {
                id_itemcompra = value;
                id_itemcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcomprastr;
        
        public string Id_itemcomprastr
        {
            get { return id_itemcomprastr; }
            set
            {
                id_itemcomprastr = value;
                try
                {
                    id_itemcompra = decimal.Parse(value);
                }
                catch
                { id_itemcompra = null; }
            }
        }
        private decimal? nr_pedido;
        
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostr;
        
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        
        public string Cd_produto
        { get; set; }
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

        public TRegistro_CompraItens_X_PedidoItens()
        {
            this.Cd_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.id_itemcompra = null;
            this.id_itemcomprastr = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_pedidoitem = null;
            this.id_pedidoitemstr = string.Empty;
        }
    }

    public class TCD_CompraItens_X_PedidoItens : TDataQuery
    {
        public TCD_CompraItens_X_PedidoItens()
        { }

        public TCD_CompraItens_X_PedidoItens(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Compra, ");
                sql.AppendLine("a.ID_ItemCompra, a.NR_Pedido, a.CD_Produto, a.ID_PedidoItem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CompraItens_X_PedidoItens a ");

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

        public TList_CompraItens_X_PedidoItens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CompraItens_X_PedidoItens lista = new TList_CompraItens_X_PedidoItens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CompraItens_X_PedidoItens reg = new TRegistro_CompraItens_X_PedidoItens();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCompra")))
                        reg.Id_itemcompra = reader.GetDecimal(reader.GetOrdinal("ID_ItemCompra"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CompraItens_X_PedidoItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("IA_FAT_COMPRAITENS_X_PEDIDOITENS", hs);
        }

        public string Excluir(TRegistro_CompraItens_X_PedidoItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("EXCLUI_FAT_COMPRAITENS_X_PEDIDOITENS", hs);
        }
    }
    #endregion

    #region Compra Itens X Peca OS
    public class TList_CompraItens_X_PecaOS : List<TRegistro_CompraItens_X_PecaOS>
    { }

    
    public class TRegistro_CompraItens_X_PecaOS
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_compra;
        
        public decimal? Id_compra
        {
            get { return id_compra; }
            set
            {
                id_compra = value;
                id_comprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comprastr;
        
        public string Id_comprastr
        {
            get { return id_comprastr; }
            set
            {
                id_comprastr = value;
                try
                {
                    id_compra = decimal.Parse(value);
                }
                catch
                { id_compra = null; }
            }
        }
        private decimal? id_itemcompra;
        
        public decimal? Id_itemcompra
        {
            get { return id_itemcompra; }
            set
            {
                id_itemcompra = value;
                id_itemcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcomprastr;
        
        public string Id_itemcomprastr
        {
            get { return id_itemcomprastr; }
            set
            {
                id_itemcomprastr = value;
                try
                {
                    id_itemcompra = decimal.Parse(value);
                }
                catch
                { id_itemcompra = null; }
            }
        }
        private decimal? id_os;
        
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        private decimal? id_peca;
        
        public decimal? Id_peca
        {
            get { return id_peca; }
            set
            {
                id_peca = value;
                id_pecastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pecastr;
        
        public string Id_pecastr
        {
            get { return id_pecastr; }
            set
            {
                id_pecastr = value;
                try
                {
                    id_peca = decimal.Parse(value);
                }
                catch
                { id_peca = null; }
            }
        }
        
        public decimal Quantidade
        { get; set; }

        public TRegistro_CompraItens_X_PecaOS()
        {
            this.Cd_empresa = string.Empty;
            this.id_compra = null;
            this.id_comprastr = string.Empty;
            this.id_itemcompra = null;
            this.id_itemcomprastr = string.Empty;
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.id_peca = null;
            this.id_pecastr = string.Empty;
            this.Quantidade = decimal.Zero;
        }
    }

    public class TCD_CompraItens_X_PecaOS : TDataQuery
    {
        public TCD_CompraItens_X_PecaOS()
        { }

        public TCD_CompraItens_X_PecaOS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Compra, ");
                sql.AppendLine("a.ID_ItemCompra, a.ID_OS, a.ID_Peca, a.Quantidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CompraItens_X_PecaOS a ");

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

        public TList_CompraItens_X_PecaOS Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CompraItens_X_PecaOS lista = new TList_CompraItens_X_PecaOS();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CompraItens_X_PecaOS reg = new TRegistro_CompraItens_X_PecaOS();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Compra")))
                        reg.Id_compra = reader.GetDecimal(reader.GetOrdinal("ID_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCompra")))
                        reg.Id_itemcompra = reader.GetDecimal(reader.GetOrdinal("ID_ItemCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("ID_Peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

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

        public string Gravar(TRegistro_CompraItens_X_PecaOS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return this.executarProc("IA_FAT_COMPRAITENS_X_PECAOS", hs);
        }

        public string Excluir(TRegistro_CompraItens_X_PecaOS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COMPRA", val.Id_compra);
            hs.Add("@P_ID_ITEMCOMPRA", val.Id_itemcompra);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_ID_PECA", val.Id_peca);

            return this.executarProc("EXCLUI_FAT_COMPRAITENS_X_PECAOS", hs);
        }
    }
    #endregion
}
