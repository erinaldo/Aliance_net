using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Almoxarifado
{
    #region Saldo Almoxarifado
    public class TList_SaldoAlmoxarifado : List<TRegistro_SaldoAlmoxarifado>, IComparer<TRegistro_SaldoAlmoxarifado>
    {
        #region IComparer<TRegistro_SaldoAlmoxarifado> Members
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

        public TList_SaldoAlmoxarifado()
        { }

        public TList_SaldoAlmoxarifado(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_SaldoAlmoxarifado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_SaldoAlmoxarifado x, TRegistro_SaldoAlmoxarifado y)
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

    
    public class TRegistro_SaldoAlmoxarifado
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Id_almox
        { get; set; }
        
        public string Ds_almoxarifado
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Tot_entrada
        { get; set; }
        
        public decimal Tot_saida
        { get; set; }
        
        public decimal Saldo
        { get; set; }
        
        public decimal Vl_entrada
        { get; set; }
        
        public decimal Vl_saida
        { get; set; }
        
        public decimal Vl_custo
        { get; set; }
        public decimal Vl_custototal
        { get { return Saldo * Vl_custo; } }

        public TRegistro_SaldoAlmoxarifado()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_almox = null;
            this.Ds_almoxarifado = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Tot_entrada = decimal.Zero;
            this.Tot_saida = decimal.Zero;
            this.Saldo = decimal.Zero;
            this.Vl_entrada = decimal.Zero;
            this.Vl_saida = decimal.Zero;
            this.Vl_custo = decimal.Zero;
        }
    }

    public class TCD_SaldoAlmoxarifado : TDataQuery
    {
        public TCD_SaldoAlmoxarifado()
        { }

        public TCD_SaldoAlmoxarifado(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.Id_Almox, c.DS_Almoxarifado, a.CD_Produto, d.DS_Produto, ");
                sql.AppendLine("e.Sigla_Unidade, a.tot_entrada, a.tot_saida, a.saldo, ");
                sql.AppendLine("a.vl_entrada, a.vl_saida, a.vl_custo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_AMX_SALDOALMOXARIFADO a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_AMX_Almoxarifado c ");
            sql.AppendLine("on a.Id_Almox = c.Id_Almox ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on a.CD_Produto = d.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on d.CD_Unidade = e.CD_Unidade ");

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

        public TList_SaldoAlmoxarifado Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_SaldoAlmoxarifado lista = new TList_SaldoAlmoxarifado();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_SaldoAlmoxarifado reg = new TRegistro_SaldoAlmoxarifado();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_Almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Almoxarifado")))
                        reg.Ds_almoxarifado = reader.GetString(reader.GetOrdinal("DS_Almoxarifado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_entrada")))
                        reg.Tot_entrada = reader.GetDecimal(reader.GetOrdinal("tot_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_saida")))
                        reg.Tot_saida = reader.GetDecimal(reader.GetOrdinal("tot_saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("saldo")))
                        reg.Saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_entrada")))
                        reg.Vl_entrada = reader.GetDecimal(reader.GetOrdinal("vl_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_saida")))
                        reg.Vl_saida = reader.GetDecimal(reader.GetOrdinal("vl_saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("vl_custo"));

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
    }
    #endregion

    #region Movimentacao
    public class TList_Movimentacao : List<TRegistro_Movimentacao>, IComparer<TRegistro_Movimentacao>
    {
        #region IComparer<TRegistro_Movimentacao> Members
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

        public TList_Movimentacao()
        { }

        public TList_Movimentacao(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Movimentacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Movimentacao x, TRegistro_Movimentacao y)
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
        
    public class TRegistro_Movimentacao
    {
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
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string LoginAlmoxarife
        { get; set; }
        private decimal? id_almox;
        
        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_almoxstr;
        
        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = decimal.Parse(value);
                }
                catch
                { id_almox = null; }
            }
        }
        
        public string Ds_almoxarifado
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
        private DateTime? dt_movimento;
        
        public DateTime? Dt_movimento
        {
            get { return dt_movimento; }
            set
            {
                dt_movimento = value;
                dt_movimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_movimentostr;
        public string Dt_movimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_movimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_movimentostr = value;
                try
                {
                    dt_movimento = DateTime.Parse(value);
                }
                catch
                { dt_movimento = null; }
            }
        }
        private string tp_movimento;
        
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }

        
        public decimal? Id_rua
        { get; set; }
        
        public string Ds_rua
        { get; set; }
        
        public decimal? Id_secao
        { get; set; }
        
        public string Ds_secao
        { get; set; }
        
        public decimal? Id_celula
        { get; set; }
        
        public string Ds_celula
        { get; set; }
        
        public TRegistro_Mov_X_NFItem rNFItem
        { get; set; }
        
        public TRegistro_Mov_X_Requisicao rRequisicao
        { get; set; }


        public TRegistro_Movimentacao()
        {
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.LoginAlmoxarife = string.Empty;
            this.id_almox = null;
            this.id_almoxstr = string.Empty;
            this.Ds_almoxarifado = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.dt_movimento = null;
            this.dt_movimentostr = string.Empty;
            this.tp_movimento = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";

            this.Id_rua = null;
            this.Ds_rua = string.Empty;
            this.Id_secao = null;
            this.Ds_secao = string.Empty;
            this.Id_celula = null;
            this.Ds_celula = string.Empty;
            this.rNFItem = null;
            this.rRequisicao = null;
        }
    }

    public class TCD_Movimentacao : TDataQuery
    {
        public TCD_Movimentacao()
        { }

        public TCD_Movimentacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Movimento, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.LoginAlmoxarife, a.Id_Almox, c.DS_Almoxarifado, ");
                sql.AppendLine("a.CD_Produto, d.DS_Produto, d.CD_Unidade, e.DS_Unidade, ");
                sql.AppendLine("e.Sigla_Unidade, a.DT_Movimento, a.TP_Movimento, ");
                sql.AppendLine("a.Quantidade, a.DS_Observacao, a.ST_Registro, ");
                sql.AppendLine("f.id_rua, g.ds_rua, f.id_secao, h.ds_secao, ");
                sql.AppendLine("f.id_celula, i.ds_celula, a.vl_unitario, a.vl_subtotal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_AMX_Movimentacao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_AMX_Almoxarifado c ");
            sql.AppendLine("on a.Id_Almox = c.Id_Almox ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on a.CD_Produto = d.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on d.CD_Unidade = e.CD_Unidade ");
            sql.AppendLine("left outer join TB_AMX_Itens f ");
            sql.AppendLine("on a.cd_produto = f.cd_produto ");
            sql.AppendLine("and a.id_almox = f.id_almox ");
            sql.AppendLine("left outer join TB_AMX_Rua g ");
            sql.AppendLine("on f.id_rua = g.id_rua ");
            sql.AppendLine("left outer join TB_AMX_Secao h ");
            sql.AppendLine("on f.id_rua = h.id_rua ");
            sql.AppendLine("and f.id_secao = h.id_secao ");
            sql.AppendLine("left outer join TB_AMX_CelulaArm i ");
            sql.AppendLine("on f.id_rua = i.id_rua ");
            sql.AppendLine("and f.id_secao = i.id_secao ");
            sql.AppendLine("and f.id_celula = i.id_celula ");

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

        public TList_Movimentacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Movimentacao lista = new TList_Movimentacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Movimentacao reg = new TRegistro_Movimentacao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("ID_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAlmoxarife")))
                        reg.LoginAlmoxarife = reader.GetString(reader.GetOrdinal("LoginAlmoxarife"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_Almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Almoxarifado")))
                        reg.Ds_almoxarifado = reader.GetString(reader.GetOrdinal("DS_Almoxarifado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Movimento")))
                        reg.Dt_movimento = reader.GetDateTime(reader.GetOrdinal("DT_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rua")))
                        reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("id_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rua")))
                        reg.Ds_rua = reader.GetString(reader.GetOrdinal("ds_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_secao")))
                        reg.Id_secao = reader.GetDecimal(reader.GetOrdinal("id_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_secao")))
                        reg.Ds_secao = reader.GetString(reader.GetOrdinal("ds_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_celula")))
                        reg.Id_celula = reader.GetDecimal(reader.GetOrdinal("id_celula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_celula")))
                        reg.Ds_celula = reader.GetString(reader.GetOrdinal("ds_celula"));

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

        public string Gravar(TRegistro_Movimentacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_LOGINALMOXARIFE", val.LoginAlmoxarife);
            hs.Add("@P_ID_ALMOX", val.Id_almox);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DT_MOVIMENTO", val.Dt_movimento);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_AMX_MOVIMENTACAO", hs);
        }

        public string Excluir(TRegistro_Movimentacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);

            return this.executarProc("EXCLUI_AMX_MOVIMENTACAO", hs);
        }
    }
    #endregion

    #region Mov X NFItem
    public class TList_Mov_X_NFItem : List<TRegistro_Mov_X_NFItem>
    { }

    
    public class TRegistro_Mov_X_NFItem
    {
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
        
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch
                { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        
        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch
                { id_nfitem = null; }
            }
        }

        public TRegistro_Mov_X_NFItem()
        {
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
        }
    }

    public class TCD_Mov_X_NFItem : TDataQuery
    {
        public TCD_Mov_X_NFItem()
        { }

        public TCD_Mov_X_NFItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_movimento, a.cd_empresa, a.nr_lanctofiscal, a.id_nfitem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_AMX_Mov_X_NFItem a ");

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

        public TList_Mov_X_NFItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Mov_X_NFItem lista = new TList_Mov_X_NFItem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Mov_X_NFItem reg = new TRegistro_Mov_X_NFItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("id_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));

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

        public string Gravar(TRegistro_Mov_X_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("IA_AMX_MOV_X_NFITEM", hs);
        }

        public string Excluir(TRegistro_Mov_X_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("EXCLUI_AMX_MOV_X_NFITEM", hs);
        }
    }
    #endregion

    #region Mov X Requisicao
    public class TList_Mov_X_Requisicao : List<TRegistro_Mov_X_Requisicao>, IComparer<TRegistro_Mov_X_Requisicao>
    {
        #region IComparer<TRegistro_Mov_X_Requisicao> Members
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

        public TList_Mov_X_Requisicao()
        { }

        public TList_Mov_X_Requisicao(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Mov_X_Requisicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Mov_X_Requisicao x, TRegistro_Mov_X_Requisicao y)
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

    
    public class TRegistro_Mov_X_Requisicao
    {
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
        private decimal? id_requisicao;
        
        public decimal? Id_requisicao
        {
            get { return id_requisicao; }
            set
            {
                id_requisicao = value;
                id_requisicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_requisicaostr;
        
        public string Id_requisicaostr
        {
            get { return id_requisicaostr; }
            set
            {
                id_requisicaostr = value;
                try
                {
                    id_requisicao = decimal.Parse(value);
                }
                catch
                { id_requisicao = null; }
            }
        }
        public string Cd_empresa
        { get; set; }

        public TRegistro_Mov_X_Requisicao()
        {
            this.id_movimento = null;
            this.id_movimentostr = string.Empty;
            this.id_requisicao = null;
            this.id_requisicaostr = string.Empty;
            this.Cd_empresa = string.Empty;
        }
    }

    public class TCD_Mov_X_Requisicao : TDataQuery
    {
        public TCD_Mov_X_Requisicao()
        { }

        public TCD_Mov_X_Requisicao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_movimento, a.id_requisicao, a.cd_empresa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_AMX_Mov_X_Requisicao a ");

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

        public TList_Mov_X_Requisicao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Mov_X_Requisicao lista = new TList_Mov_X_Requisicao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Mov_X_Requisicao reg = new TRegistro_Mov_X_Requisicao();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("id_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_requisicao")))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("id_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));

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

        public string Gravar(TRegistro_Mov_X_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("IA_AMX_MOV_X_REQUISICAO", hs);
        }

        public string Excluir(TRegistro_Mov_X_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_AMX_MOV_X_REQUISICAO", hs);
        }
    }
    #endregion
}
