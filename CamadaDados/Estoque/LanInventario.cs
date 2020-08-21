using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Estoque
{
    #region "Classe Inventario"
    public class Tlist_Inventario : List<Tregistro_Inventario>, IComparer<Tregistro_Inventario>
    {
        #region IComparer<Tregistro_Inventario> Members
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

        public Tlist_Inventario()
        { }

        public Tlist_Inventario(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(Tregistro_Inventario value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(Tregistro_Inventario x, Tregistro_Inventario y)
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


    public class Tregistro_Inventario
    {

        public decimal? Id_inventario { get; set; }

        public string Cd_empresa { get; set; }

        public string Nm_empresa { get; set; }
        private DateTime? dt_inventario;

        public DateTime? Dt_inventario
        {
            get { return dt_inventario; }
            set
            {
                dt_inventario = value;
                dt_inventariostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_inventariostring;
        public string Dt_inventariostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_inventariostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inventariostring = value;
                try
                {
                    dt_inventario = Convert.ToDateTime(value);
                }
                catch
                { dt_inventario = null; }
            }
        }

        public string Login_responsavel
        { get; set; }
        private string st_inventario;

        public string St_inventario
        {
            get { return st_inventario; }
            set
            {
                st_inventario = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_inventario = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status_inventario = "PROCESSADO";
            }
        }
        private string status_inventario;

        public string Status_inventario
        {
            get { return status_inventario; }
            set
            {
                status_inventario = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_inventario = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_inventario = "P";
            }
        }

        public string Ds_observacao
        { get; set; }

        public TList_Inventario_Item lItensInventario
        { get; set; }

        public TList_Inventario_Item lItensDel
        { get; set; }

        public Tregistro_Inventario()
        {
            this.Id_inventario = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.dt_inventario = null;
            this.dt_inventariostring = string.Empty;
            this.Login_responsavel = string.Empty;
            this.st_inventario = "A";
            this.status_inventario = "ABERTO";
            this.Ds_observacao = string.Empty;
            this.lItensInventario = new TList_Inventario_Item();
            this.lItensDel = new TList_Inventario_Item();
        }
    }

    public class TCD_Inventario : TDataQuery
    {
        public TCD_Inventario()
        { }

        public TCD_Inventario(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_inventario ,a.cd_empresa , b.nm_empresa, ");
                sql.AppendLine("a.dt_inventario, a.st_inventario, a.login_responsavel, a.ds_observacao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Inventario_Est a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        private string SqlCodeBuscaRelItens(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.id_inventario, a.cd_empresa, b.nm_empresa, ");
            sql.AppendLine("a.dt_inventario, a.login_responsavel, ");
            sql.AppendLine("c.cd_produto, d.ds_produto, d.codigo_alternativo as cd_referencia, d.cd_marca, g.ds_marca, e.sigla_unidade, f.vl_medio, f.tot_saldo ");
            sql.AppendLine("from tb_est_inventario_est a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_inventario_item c ");
            sql.AppendLine("on a.id_inventario = c.id_inventario ");
            sql.AppendLine("inner join tb_est_produto d ");
            sql.AppendLine("on c.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade e ");
            sql.AppendLine("on d.cd_unidade = e.cd_unidade ");
            sql.AppendLine("left outer join vtb_est_vlestoque f ");
            sql.AppendLine("on a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("and c.cd_produto = f.cd_produto ");
            sql.AppendLine("left outer join tb_est_marca g ");
            sql.AppendLine("on d.cd_marca = g.cd_marca ");
            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("and isnull(d.st_registro, 'A') <> 'C' ");
            sql.AppendLine("order by d.ds_produto asc ");
            return sql.ToString();
        }

        public DataTable BuscarRelItens(TpBusca[] vBusca)
        {
            return this.ExecutarBusca(this.SqlCodeBuscaRelItens(vBusca), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public Tlist_Inventario Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            Tlist_Inventario lista = new Tlist_Inventario();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    Tregistro_Inventario reg = new Tregistro_Inventario();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Inventario"))))
                        reg.Id_inventario = reader.GetDecimal(reader.GetOrdinal("ID_Inventario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Inventario"))))
                        reg.Dt_inventario = reader.GetDateTime(reader.GetOrdinal("DT_Inventario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_Responsavel"))))
                        reg.Login_responsavel = reader.GetString(reader.GetOrdinal("Login_Responsavel"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Inventario"))))
                        reg.St_inventario = reader.GetString(reader.GetOrdinal("ST_Inventario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));

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

        public string GravarInventario(Tregistro_Inventario val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DT_INVENTARIO", val.Dt_inventario);
            hs.Add("@P_LOGIN_RESPONSAVEL", val.Login_responsavel);
            hs.Add("@P_ST_INVENTARIO", val.St_inventario);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_EST_INVENTARIO_EST", hs);
        }

        public string DeletarInvetario(Tregistro_Inventario val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);

            return this.executarProc("EXCLUI_EST_INVENTARIO_EST", hs);
        }
    }
    #endregion

    #region "Classe Inventario X Item"
    public class TList_Inventario_Item : List<TRegistro_Inventario_Item>, IComparer<TRegistro_Inventario_Item>
    {
        #region IComparer<TRegistro_Inventario_Item> Members
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

        public TList_Inventario_Item()
        { }

        public TList_Inventario_Item(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Inventario_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Inventario_Item x, TRegistro_Inventario_Item y)
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


    public class TRegistro_Inventario_Item
    {

        public decimal? Id_inventario
        { get; set; }

        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public decimal? Cd_marca
        { get; set; }
        public string Ds_marca
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string St_consumointerno
        {
            get; set;
        }

        public TList_Inventario_Item_X_Saldo lSaldoItem
        { get; set; }

        public TRegistro_Inventario_Item()
        {
            this.Id_inventario = null;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_referencia = string.Empty;
            this.Cd_marca = null;
            this.Ds_marca = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.lSaldoItem = new TList_Inventario_Item_X_Saldo();
            St_consumointerno = string.Empty;
        }
    }

    public class TCD_Inventario_Item : TDataQuery
    {
        public TCD_Inventario_Item()
        { }

        public TCD_Inventario_Item(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.id_inventario ,a.cd_produto , b.ds_produto, b.codigo_alternativo, b.cd_marca, d.ds_marca, c.sigla_unidade,  e.st_consumointerno ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Inventario_Item a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join tb_est_marca d ");
            sql.AppendLine("on d.cd_marca = b.cd_marca ");
            sql.AppendLine("left outer join tb_est_tpproduto e");
            sql.AppendLine("on b.tp_produto = e.tp_produto ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vGroup.Trim() != "")
                sql.AppendLine("group by " + vGroup);
            if (vOrder.Trim() != "")
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", "", ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
        }

        public TList_Inventario_Item Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Inventario_Item lista = new TList_Inventario_Item();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Inventario"))))
                        reg.Id_inventario = reader.GetDecimal(reader.GetOrdinal("ID_Inventario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("codigo_alternativo"))))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("codigo_alternativo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_marca"))))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("Cd_marca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_marca"))))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("Ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_consumointerno")))
                        reg.St_consumointerno = reader.GetString(reader.GetOrdinal("st_consumointerno"));


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

        public string GravarInventario_Item(TRegistro_Inventario_Item val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("IA_EST_INVENTARIO_ITEM", hs);
        }

        public string DeletarInventario_Item(TRegistro_Inventario_Item val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_EST_INVENTARIO_ITEM", hs);
        }
    }
    #endregion"

    #region "Classe Inventario_Item X Saldo
    public class TList_Inventario_Item_X_Saldo : List<TRegistro_Inventario_Item_X_Saldo>, IComparer<TRegistro_Inventario_Item_X_Saldo>
    {
        #region IComparer<TRegistro_Inventario_Item_X_Saldo> Members
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

        public TList_Inventario_Item_X_Saldo()
        { }

        public TList_Inventario_Item_X_Saldo(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Inventario_Item_X_Saldo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Inventario_Item_X_Saldo x, TRegistro_Inventario_Item_X_Saldo y)
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


    public class TRegistro_Inventario_Item_X_Saldo
    {

        public decimal? Id_inventario
        { get; set; }
        public decimal? Id_registro
        { get; set; }
        public string Cd_empresa
        { get; set; }
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
        public decimal Qtd_contada
        { get; set; }
        public decimal Qtd_saldo
        { get; set; }
        public decimal Qtd_saldoAmx
        { get; set; }
        public decimal Qtd_saldoatual
        { get; set; }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        public decimal vl_medio
        { get; set; }
        public decimal Vl_subtotal
        {
            get { return Qtd_contada * Vl_unitario; }
        }
        public decimal? Id_Almox
        { get; set; }
        public string St_consumoInterno
        {
            get; set;
        }

        public TList_RegLanEstoque lEstoque
        { get; set; }

        public TRegistro_Inventario_Item_X_Saldo()
        {
            this.Id_inventario = 0;
            this.Cd_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Qtd_contada = decimal.Zero;
            this.Qtd_saldo = decimal.Zero;
            this.Qtd_saldoatual = decimal.Zero;
            this.vl_unitario = decimal.Zero;
            this.vl_medio = decimal.Zero;
            this.lEstoque = new TList_RegLanEstoque();
        }
    }

    public class TCD_Inventario_Item_X_Saldo : TDataQuery
    {
        public TCD_Inventario_Item_X_Saldo()
        { }

        public TCD_Inventario_Item_X_Saldo(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeSaldo(TpBusca[] vBusca, string vNm_campo)
        {
            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select a.id_inventario, a.cd_produto, b.ds_produto, ");
                sql.AppendLine("a.cd_local, c.ds_local, a.qtd_contada, a.qtd_saldo, ");
                sql.AppendLine("a.vl_unitario, a.qtd_contada * a.vl_unitario as vl_subtotal, a.Id_registro ");

                sql.AppendLine("from tb_est_inventario_item_x_saldo a ");
                sql.AppendLine("inner join tb_est_produto b ");
                sql.AppendLine("on a.cd_produto = b.cd_produto ");
                sql.AppendLine("inner join tb_est_localarm c ");
                sql.AppendLine("a.cd_local = c.cd_local ");
            }
            else
                sql.AppendLine("select " + vNm_campo.Trim() + " ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public DataTable BuscarSaldo(TpBusca[] vBusca, string vNm_campo)
        {
            return this.ExecutarBusca(this.SqlCodeSaldo(vBusca, vNm_campo), null);
        }

        public object BuscarSaldoEscalar(TpBusca[] vBusca, string vNm_campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeSaldo(vBusca, vNm_campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " y.cd_empresa, x.id_inventario, x.cd_produto, b.ds_produto, ");
                sql.AppendLine("b.cd_unidade, c.ds_unidade, c.sigla_unidade, a.cd_local, d.ds_local, g.vl_medio, ");
                sql.AppendLine("a.qtd_contada, a.qtd_saldo, g.tot_saldo, h.saldo as qtd_saldoAmx, a.id_almox, ");
                sql.AppendLine("case when isnull(a.vl_unitario, 0) > 0 then a.vl_unitario else g.vl_medio end as vl_unitario, a.Id_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Inventario_Item x ");
            sql.AppendLine("inner join TB_EST_Inventario_Est y ");
            sql.AppendLine("on x.id_inventario = y.id_inventario ");
            sql.AppendLine("inner join TB_EST_Inventario_Item_X_Saldo a ");
            sql.AppendLine("on x.id_inventario = a.id_inventario ");
            sql.AppendLine("and x.cd_produto = a.cd_produto ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on x.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join TB_EST_LocalArm d ");
            sql.AppendLine("on a.cd_local = d.cd_local ");
            sql.AppendLine("left outer join VTB_EST_VLESTOQUELOCAL g ");
            sql.AppendLine("on y.cd_empresa = g.cd_empresa ");
            sql.AppendLine("and a.cd_produto = g.cd_produto ");
            sql.AppendLine("and a.cd_local = g.cd_local ");
            sql.AppendLine("left outer join VTB_AMX_SALDOALMOXARIFADO h ");
            sql.AppendLine("on y.cd_empresa = h.cd_empresa ");
            sql.AppendLine("and x.cd_produto = h.cd_produto ");
            sql.AppendLine("and a.id_almox = h.Id_Almox ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine(" order by b.ds_produto asc ");
            return sql.ToString();
        }

        private string SqlCodeBuscaRelItensSaldo(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_inventario, a.cd_empresa, b.nm_empresa, ");
            sql.AppendLine("a.dt_inventario, a.nm_responsavel, a.nm_supervisor, ");
            sql.AppendLine("c.cd_local, d.ds_local, c.qtd_contada, c.qtd_saldo, ");
            sql.AppendLine("c.vl_unitario, c.vl_subtotal, c.cd_produto, e.ds_produto, c.Id_registro ");
            sql.AppendLine("f.sigla_unidade ");
            sql.AppendLine("from tb_est_inventario_est a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_inventario_item_x_saldo c ");
            sql.AppendLine("on a.id_inventario = c.id_inventario ");
            sql.AppendLine("inner join tb_est_produto e ");
            sql.AppendLine("on e.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade f ");
            sql.AppendLine("on e.cd_unidade = f.cd_unidade ");
            sql.AppendLine("left outer join tb_est_LocalArm d ");
            sql.AppendLine("on c.cd_local = d.cd_local ");
            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public DataTable BuscarRelItensSaldo(TpBusca[] vBusca)
        {
            return this.ExecutarBusca(this.SqlCodeBuscaRelItensSaldo(vBusca), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Inventario_Item_X_Saldo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Inventario_Item_X_Saldo lista = new TList_Inventario_Item_X_Saldo();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Inventario_Item_X_Saldo reg = new TRegistro_Inventario_Item_X_Saldo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Inventario"))))
                        reg.Id_inventario = reader.GetDecimal(reader.GetOrdinal("ID_Inventario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
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

                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_medio"))))
                        reg.vl_medio = reader.GetDecimal(reader.GetOrdinal("vl_medio"));

                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Contada")))
                        reg.Qtd_contada = reader.GetDecimal(reader.GetOrdinal("QTD_Contada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Saldo")))
                        reg.Qtd_saldo = reader.GetDecimal(reader.GetOrdinal("QTD_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_saldo")))
                        reg.Qtd_saldoatual = reader.GetDecimal(reader.GetOrdinal("tot_saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_saldoAmx")))
                        reg.Qtd_saldoAmx = reader.GetDecimal(reader.GetOrdinal("qtd_saldoAmx"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("id_almox")))
                        reg.Id_Almox = reader.GetDecimal(reader.GetOrdinal("id_almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("Id_registro"));
                    
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

        public string GravarInventario_Item_X_Saldo(TRegistro_Inventario_Item_X_Saldo val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_QTD_CONTADA", val.Qtd_contada);
            hs.Add("@P_QTD_SALDO", val.Qtd_saldo);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_ID_ALMOX", val.Id_Almox);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);

            return this.executarProc("IA_EST_INVENTARIO_ITEM_X_SALDO", hs);
        }

        public string DeletarInventario_Item_X_Saldo(TRegistro_Inventario_Item_X_Saldo val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_REGISTRO", val.Cd_local);

            return this.executarProc("EXCLUI_EST_INVENTARIO_ITEM_X_SALDO", hs);
        }
    }
    #endregion

    #region "Classe Inventario X Estoque"
    public class TList_Inventario_X_Estoque : List<TRegistro_Inventario_X_Estoque>, IComparer<TRegistro_Inventario_X_Estoque>
    {
        #region IComparer<TRegistro_Inventario_X_Estoque> Members
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

        public TList_Inventario_X_Estoque()
        { }

        public TList_Inventario_X_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Inventario_X_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Inventario_X_Estoque x, TRegistro_Inventario_X_Estoque y)
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

    public class TRegistro_Inventario_X_Estoque
    {

        public decimal? Id_inventario
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        public decimal? Id_registro { get; set; }
        public decimal? Id_movimentoAlmox { get; set; }
        public decimal? Id_mov { get; set; }

        public TRegistro_Inventario_X_Estoque()
        {
            this.Id_inventario = null;
            this.Cd_produto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Id_lanctoestoque = null;
        }
    }

    public class TCD_Inventario_X_Estoque : TDataQuery
    {
        public TCD_Inventario_X_Estoque()
        { }

        public TCD_Inventario_X_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_inventario, a.cd_produto, a.cd_empresa, a.id_lanctoestoque, a.Id_registro, a.Id_movimentoAlmox, ");
                sql.AppendLine("a.id_mov ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EST_Inventario_X_Estoque a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Inventario_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Inventario_X_Estoque lista = new TList_Inventario_X_Estoque();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Inventario_X_Estoque reg = new TRegistro_Inventario_X_Estoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Inventario"))))
                        reg.Id_inventario = reader.GetDecimal(reader.GetOrdinal("ID_Inventario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_movimentoAlmox")))
                        reg.Id_movimentoAlmox = reader.GetDecimal(reader.GetOrdinal("Id_movimentoAlmox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("Id_registro"));
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

        public string GravarInventarioEstoque(TRegistro_Inventario_X_Estoque val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_MOVIMENTOALMOX", val.Id_movimentoAlmox);

            return this.executarProc("IA_EST_INVENTARIO_X_ESTOQUE", hs);
        }

        public string DeletarInventarioEstoque(TRegistro_Inventario_X_Estoque val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_INVENTARIO", val.Id_inventario);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_MOV", val.Id_mov);

            return this.executarProc("EXCLUI_EST_INVENTARIO_X_ESTOQUE", hs);
        }
    }
    #endregion
}
