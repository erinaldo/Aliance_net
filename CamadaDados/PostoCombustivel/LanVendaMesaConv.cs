using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region Venda Mesa Conveniencia
    public class TList_VendaMesaConv : List<TRegistro_VendaMesaConv>, IComparer<TRegistro_VendaMesaConv>
    {
        #region IComparer<TRegistro_VendaMesaConv> Members
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

        public TList_VendaMesaConv()
        { }

        public TList_VendaMesaConv(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VendaMesaConv value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VendaMesaConv x, TRegistro_VendaMesaConv y)
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
    
    public class TRegistro_VendaMesaConv
    {
        private decimal? id_venda;
        public decimal? Id_venda
        {
            get { return id_venda; }
            set
            {
                id_venda = value;
                id_vendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vendastr;
        public string Id_vendastr
        {
            get { return id_vendastr; }
            set
            {
                id_vendastr = value;
                try
                {
                    id_venda = decimal.Parse(value);
                }
                catch
                { id_venda = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_cliente
        { get; set; }
        public string Nm_cliente
        { get; set; }
        private DateTime? dt_venda;
        public DateTime? Dt_venda
        {
            get { return dt_venda; }
            set
            {
                dt_venda = value;
                dt_vendastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vendastr;
        public string Dt_vendastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_vendastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vendastr = value;
                try
                {
                    dt_venda = DateTime.Parse(value);
                }
                catch
                { dt_venda = null; }
            }
        }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADA";
                else if (St_registro.Trim().ToUpper().Equals("A"))
                    if (St_faturar)
                        return "ABERTA";
                    else
                        return "FATURADA";
                else return string.Empty;
            }
        }
        public decimal Vl_venda
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public bool St_faturar
        { get; set; }
        public TList_ItensVendaMesaConv lItens
        { get; set; }
        public TList_ItensVendaMesaConv lItensDel
        { get; set; }

        public TRegistro_VendaMesaConv()
        {
            this.id_venda = null;
            this.id_vendastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.dt_venda = DateTime.Now;
            this.dt_vendastr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Vl_venda = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.St_registro = "A";
            this.St_faturar = false;

            this.lItens = new TList_ItensVendaMesaConv();
            this.lItensDel = new TList_ItensVendaMesaConv();
        }
    }

    public class TCD_VendaMesaConv : TDataQuery
    {
        public TCD_VendaMesaConv()
        { }

        public TCD_VendaMesaConv(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Venda, a.DT_Venda, a.NM_Cliente, a.qtd_faturar, ");
                sql.AppendLine("a.vl_venda, a.vl_desconto, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDC_VENDAMESACONV a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

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

        public TList_VendaMesaConv Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_VendaMesaConv lista = new TList_VendaMesaConv();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaMesaConv reg = new TRegistro_VendaMesaConv();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_venda"))))
                        reg.Id_venda = reader.GetDecimal(reader.GetOrdinal("id_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliente")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("nm_cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_venda")))
                        reg.Dt_venda = reader.GetDateTime(reader.GetOrdinal("dt_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_venda")))
                        reg.Vl_venda = reader.GetDecimal(reader.GetOrdinal("vl_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_faturar")))
                        reg.St_faturar = reader.GetDecimal(reader.GetOrdinal("qtd_faturar")) > decimal.Zero;

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

        public string Gravar(TRegistro_VendaMesaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NM_CLIENTE", val.Nm_cliente);
            hs.Add("@P_DT_VENDA", val.Dt_venda);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDC_VENDAMESACONV", hs);
        }

        public string Excluir(TRegistro_VendaMesaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDC_VENDAMESACONV", hs);
        }
    }
    #endregion

    #region Itens Venda
    public class TList_ItensVendaMesaConv : List<TRegistro_ItensVendaMesaConv>, IComparer<TRegistro_ItensVendaMesaConv>
    {
        #region IComparer<TRegistro_ItensVendaMesaConv> Members
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

        public TList_ItensVendaMesaConv()
        { }

        public TList_ItensVendaMesaConv(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensVendaMesaConv value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensVendaMesaConv x, TRegistro_ItensVendaMesaConv y)
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
    
    public class TRegistro_ItensVendaMesaConv
    {
        private decimal? id_venda;
        public decimal? Id_venda
        {
            get { return id_venda; }
            set
            {
                id_venda = value;
                id_vendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vendastr;
        public string Id_vendastr
        {
            get { return id_vendastr; }
            set
            {
                id_vendastr = value;
                try
                {
                    id_venda = decimal.Parse(value);
                }
                catch
                { id_venda = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_cliente
        { get; set; }
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
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Qtd_faturada
        { get; set; }
        public decimal Qtd_faturar
        { get; set; }
        public decimal Saldo
        { get { return Quantidade - Qtd_faturada; } }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get { return Utils.Parametros.pubTruncarSubTotal ? 
            Utils.Estruturas.Truncar(Quantidade * Vl_unitario, 2) :
            Math.Round(Quantidade * Vl_unitario, 2); } }
        public decimal Vl_faturar
        { get { return Utils.Parametros.pubTruncarSubTotal ?
            Utils.Estruturas.Truncar(Qtd_faturar * Vl_unitario, 2) :
            Math.Round(Qtd_faturar * Vl_unitario, 2); } }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_liquido
        { get { return Utils.Parametros.pubTruncarSubTotal ?
            Utils.Estruturas.Truncar(Vl_subtotal - Vl_desconto, 2) :
            Math.Round(Vl_subtotal - Vl_desconto, 2); } }
        public bool St_faturar
        { get; set; }

        public TRegistro_ItensVendaMesaConv()
        {
            this.id_venda = null;
            this.id_vendastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_cliente = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Qtd_faturada = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_desconto = decimal.Zero;

            this.St_faturar = false;
        }
    }

    public class TCD_ItensVendaMesaConv : TDataQuery
    {
        public TCD_ItensVendaMesaConv()
        { }

        public TCD_ItensVendaMesaConv(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Venda, a.CD_Empresa, a.ID_Item, ");
                sql.AppendLine("a.CD_Produto, b.DS_Produto, c.Sigla_Unidade, ");
                sql.AppendLine("b.cd_grupo, b.cd_condfiscal_produto, b.cd_unidade, ");
                sql.AppendLine("a.CD_Local, d.DS_Local, a.Quantidade, v.nm_cliente, ");
                sql.AppendLine("a.Vl_Unitario, a.Vl_Desconto, a.Qtd_Faturada ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDC_ITENSVENDAMESACONV a ");
            sql.AppendLine("inner join tb_pdc_vendamesaconv v ");
            sql.AppendLine("on a.cd_empresa = v.cd_empresa ");
            sql.AppendLine("and a.id_venda = v.id_venda ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_LocalArm d ");
            sql.AppendLine("on a.CD_Local = d.CD_Local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != "")
                sql.AppendLine(" Order By " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_ItensVendaMesaConv Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_ItensVendaMesaConv lista = new TList_ItensVendaMesaConv();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensVendaMesaConv reg = new TRegistro_ItensVendaMesaConv();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_venda"))))
                        reg.Id_venda = reader.GetDecimal(reader.GetOrdinal("id_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliente")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("nm_cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_faturada")))
                        reg.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("qtd_faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));

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

        public string Gravar(TRegistro_ItensVendaMesaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);

            return this.executarProc("IA_PDC_ITENSVENDAMESACONV", hs);
        }

        public string Excluir(TRegistro_ItensVendaMesaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_PDC_ITENSVENDAMESACONV", hs);
        }
    }
    #endregion

    #region Itens Venda X Venda Rapida
    public class TList_VendaMesa_X_VendaRapida : List<TRegistro_VendaMesa_X_VendaRapida>, IComparer<TRegistro_VendaMesa_X_VendaRapida>
    {
        #region IComparer<TRegistro_VendaMesa_X_VendaRapida> Members
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

        public TList_VendaMesa_X_VendaRapida()
        { }

        public TList_VendaMesa_X_VendaRapida(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VendaMesa_X_VendaRapida value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VendaMesa_X_VendaRapida x, TRegistro_VendaMesa_X_VendaRapida y)
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
    
    public class TRegistro_VendaMesa_X_VendaRapida
    {
        private decimal? id_venda;
        public decimal? Id_venda
        {
            get { return id_venda; }
            set
            {
                id_venda = value;
                id_vendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vendastr;
        public string Id_vendastr
        {
            get { return id_vendastr; }
            set
            {
                id_vendastr = value;
                try
                {
                    id_venda = decimal.Parse(value);
                }
                catch
                { id_venda = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
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
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch
                { id_lancto = null; }
            }
        }
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
                catch
                { id_cupom = null; }
            }
        }

        public TRegistro_VendaMesa_X_VendaRapida()
        {
            this.id_venda = null;
            this.id_vendastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
        }
    }

    public class TCD_VendaMesa_X_VendaRapida : TDataQuery
    {
        public TCD_VendaMesa_X_VendaRapida()
        { }

        public TCD_VendaMesa_X_VendaRapida(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Venda, a.CD_Empresa, ");
                sql.AppendLine("a.ID_Item, a.Id_lancto, a.Id_Cupom ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_VendaMesa_X_VendaRapida a ");

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

        public TList_VendaMesa_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_VendaMesa_X_VendaRapida lista = new TList_VendaMesa_X_VendaRapida();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaMesa_X_VendaRapida reg = new TRegistro_VendaMesa_X_VendaRapida();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_venda"))))
                        reg.Id_venda = reader.GetDecimal(reader.GetOrdinal("id_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("Id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));

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

        public string Gravar(TRegistro_VendaMesa_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("IA_PDC_VENDAMESA_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_VendaMesa_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("EXCLUI_PDC_VENDAMESA_X_VENDARAPIDA", hs);
        }
    }
    #endregion
}
