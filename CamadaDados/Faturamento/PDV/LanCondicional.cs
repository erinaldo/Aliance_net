using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    #region Condicional
    public class TList_Condicional : List<TRegistro_Condicional>, IComparer<TRegistro_Condicional>
    {
        #region IComparer<TRegistro_Condicional> Members
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

        public TList_Condicional()
        { }

        public TList_Condicional(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Condicional value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Condicional x, TRegistro_Condicional y)
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
    
    public class TRegistro_Condicional
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch
                { id_condicional = null; }
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
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_cliforind
        { get; set; }
        public string Nm_cliforind
        { get; set; }
        private decimal? id_pessoa;
        public decimal? Id_pessoa
        {
            get { return id_pessoa; }
            set
            {
                id_pessoa = value;
                id_pessoastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pessoastr;
        public string Id_pessoastr
        {
            get { return id_pessoastr; }
            set
            {
                id_pessoastr = value;
                try
                {
                    id_pessoa = decimal.Parse(value);
                }
                catch { id_pessoa = null; }
            }
        }
        public string Nm_pessoa
        { get; set; }
        private DateTime? dt_condicional;
        public DateTime? Dt_condicional
        {
            get { return dt_condicional; }
            set
            {
                dt_condicional = value;
                dt_condicionalstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_condicionalstr;
        public string Dt_condicionalstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_condicionalstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_condicionalstr = value;
                try
                {
                    dt_condicional = DateTime.Parse(value);
                }
                catch
                { dt_condicional = null; }
            }
        }
        private DateTime? dt_prevdevolucao;
        public DateTime? Dt_prevdevolucao
        {
            get { return dt_prevdevolucao; }
            set
            {
                dt_prevdevolucao = value;
                dt_prevdevolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_prevdevolucaostr;
        public string Dt_prevdevolucaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevdevolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevdevolucaostr = value;
                try
                {
                    dt_prevdevolucao = DateTime.Parse(value);
                }
                catch
                { dt_prevdevolucao = null; }
            }
        }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (tp_movimento.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (tp_movimento.Trim().ToUpper().Equals("S"))
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
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                {
                    if (this.Qtd_devolver.Equals(decimal.Zero))
                        return "DEVOLVIDO";
                    else
                        return "ATIVO";
                }
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public decimal Qtd_devolver
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_ItensCondicional lItens
        { get; set; }
        public TList_ItensCondicional lItensDel
        { get; set; }

        public TRegistro_Condicional()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_condicional = null;
            this.id_condicionalstr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_cliforind = string.Empty;
            this.Nm_cliforind = string.Empty;
            this.id_pessoa = null;
            this.id_pessoastr = string.Empty;
            this.Nm_pessoa = string.Empty;
            this.dt_condicional = DateTime.Now;
            this.dt_condicionalstr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_prevdevolucao = null;
            this.dt_prevdevolucaostr = string.Empty;
            this.tp_movimento = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
            this.Qtd_devolver = decimal.Zero;
            this.St_processar = false;

            this.lItens = new TList_ItensCondicional();
            this.lItensDel = new TList_ItensCondicional();
        }
    }

    public class TCD_Condicional : TDataQuery
    {
        public TCD_Condicional() { }

        public TCD_Condicional(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Condicional, ");
                sql.AppendLine("a.CD_Clifor, c.NM_Clifor, a.CD_Endereco, d.DS_Endereco, a.tp_movimento, ");
                sql.AppendLine("a.DT_Condicional,a.DT_PrevDevolucao, a.DS_Observacao, a.ST_Registro, ");
                sql.AppendLine("a.id_pessoa, paut.nm_pessoa, ");
                sql.AppendLine("a.Cd_Vendedor, e.nm_clifor as Nm_Vendedor, a.cd_cliforind, f.nm_clifor as nm_cliforind, ");
                sql.AppendLine("qtd_devolver = isnull((select sum(isnull(x.Quantidade, 0) - isnull(x.Qtd_devolvida, 0)) ");
                sql.AppendLine("                        from VTB_PDV_ITENSCONDICIONAL x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.id_condicional = a.id_condicional ");
                sql.AppendLine("                        and isnull(x.st_registro, 'A') <> 'C'), 0) ");  
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_PDV_Condicional a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join TB_FIN_Endereco d ");
            sql.AppendLine("on a.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = d.CD_Endereco ");
            sql.AppendLine("left outer join TB_FIN_Clifor e ");
            sql.AppendLine("on a.cd_vendedor = e.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_Clifor f ");
            sql.AppendLine("on a.cd_cliforind = f.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_PessoasAutorizadas paut ");
            sql.AppendLine("on a.cd_clifor = paut.cd_clifor ");
            sql.AppendLine("and a.id_pessoa = paut.id_pessoa ");

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

        public TList_Condicional Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Condicional lista = new TList_Condicional();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Condicional reg = new TRegistro_Condicional();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("id_condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("NM_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CliforInd")))
                        reg.Cd_cliforind = reader.GetString(reader.GetOrdinal("CD_CliforInd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_CliforInd")))
                        reg.Nm_cliforind = reader.GetString(reader.GetOrdinal("NM_CliforInd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("id_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pessoa")))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("nm_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Condicional")))
                        reg.Dt_condicional = reader.GetDateTime(reader.GetOrdinal("DT_Condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevDevolucao")))
                        reg.Dt_prevdevolucao = reader.GetDateTime(reader.GetOrdinal("DT_PrevDevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_devolver")))
                        reg.Qtd_devolver = reader.GetDecimal(reader.GetOrdinal("qtd_devolver"));

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

        public string Gravar(TRegistro_Condicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_CLIFORIND", val.Cd_cliforind);
            hs.Add("@P_ID_PESSOA", val.Id_pessoa);
            hs.Add("@P_DT_CONDICIONAL", val.Dt_condicional);
            hs.Add("@P_DT_PREVDEVOLUCAO", val.Dt_prevdevolucao);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_CONDICIONAL", hs);
        }

        public string Excluir(TRegistro_Condicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);

            return this.executarProc("EXCLUI_PDV_CONDICIONAL", hs);
        }
    }
    #endregion

    #region Itens Condicional
    public class TList_ItensCondicional : List<TRegistro_ItensCondicional>, IComparer<TRegistro_ItensCondicional>
    {
        #region IComparer<TRegistro_ItensCondicional> Members
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

        public TList_ItensCondicional()
        { }

        public TList_ItensCondicional(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensCondicional value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensCondicional x, TRegistro_ItensCondicional y)
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

    public class TRegistro_ItensCondicional
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch
                { id_condicional = null; }
            }
        }
        public Estoque.Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Estoque.Cadastros.TList_ValorCaracteristica();
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
        public string Cd_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get { return Utils.Parametros.pubTruncarSubTotal ?
            Utils.Estruturas.Truncar(this.Quantidade * this.Vl_unitario, 2) :
            Math.Round(this.Quantidade * this.Vl_unitario, 2); } }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Saldo_devolver
        { get { return this.Quantidade - this.Qtd_devolvida; } }
        public decimal Qtd_faturada
        { get; set; }
        public decimal Qtd_devolver
        { get; set; }
        public decimal Qtd_faturar
        { get; set; }
        public decimal Qtd_nfdev
        { get; set; }
        public decimal Saldo_nfdev
        { get { return Qtd_devolvida - Qtd_nfdev; } }
        public decimal Qtd_nfcond
        { get; set; }
        public decimal Saldo_nfcond
        { get { return Quantidade - Qtd_nfcond; } }
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
        public string Tp_movimento
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Cd_cliforind
        { get; set; }
        public string Nm_cliforind
        { get; set; }
        private decimal? id_pessoa;
        public decimal? Id_pessoa
        {
            get { return id_pessoa; }
            set
            {
                id_pessoa = value;
                id_pessoastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pessoastr;
        public string Id_pessoastr
        {
            get { return id_pessoastr; }
            set
            {
                id_pessoastr = value;
                try
                {
                    id_pessoa = decimal.Parse(value);
                }
                catch { id_pessoa = null; }
            }
        }
        public string Nm_pessoa
        { get; set; }
        public decimal Pc_aprox_imposto
        { get; set; }
        public bool St_processar
        { get; set; }
        public TRegistro_ItensPreVenda rItemPreVenda
        { get; set; }

        public TRegistro_ItensCondicional()
        {
            this.Cd_empresa = string.Empty;
            this.id_condicional = null;
            this.id_condicionalstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_local = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Qtd_devolvida = decimal.Zero;
            this.Qtd_faturada = decimal.Zero;
            this.Qtd_devolver = decimal.Zero;
            this.Qtd_faturar = decimal.Zero;
            this.lGrade = new Estoque.Cadastros.TList_ValorCaracteristica();
            this.Qtd_nfcond = decimal.Zero;
            this.Qtd_nfdev = decimal.Zero;
            this.St_registro = "A";
            this.Tp_movimento = string.Empty;
            this.Pc_aprox_imposto = decimal.Zero;
            this.St_processar = false;
            this.rItemPreVenda = null;
        }
    }

    public class TCD_ItensCondicional : TDataQuery
    {
        public TCD_ItensCondicional() { }

        public TCD_ItensCondicional(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Condicional, a.ID_Item, a.qtd_nfcond, a.qtd_nfdev, ");
                sql.AppendLine("a.CD_Produto, b.DS_Produto, c.Sigla_Unidade, a.ST_Registro, cond.tp_movimento, ");
                sql.AppendLine("a.Quantidade, a.Vl_unitario, a.Qtd_devolvida, a.Qtd_faturada, a.cd_local, ");
                sql.AppendLine("cond.cd_clifor, d.nm_clifor, cond.cd_endereco, e.ds_endereco, cond.cd_vendedor, ");
                sql.AppendLine("b.cd_unidade, b.cd_condfiscal_produto, f.pc_aliquota, cond.cd_cliforind, ");
                sql.AppendLine("g.nm_clifor as nm_cliforind, cond.id_pessoa, h.nm_pessoa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from VTB_PDV_ITENSCONDICIONAL a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join tb_pdv_condicional cond ");
            sql.AppendLine("on a.cd_empresa = cond.cd_empresa ");
            sql.AppendLine("and a.id_condicional = cond.id_condicional ");
            sql.AppendLine("inner join tb_fin_clifor d ");
            sql.AppendLine("on cond.cd_clifor = d.cd_clifor ");
            sql.AppendLine("inner join tb_fin_endereco e ");
            sql.AppendLine("on cond.cd_clifor = e.cd_clifor ");
            sql.AppendLine("and cond.cd_endereco = e.cd_endereco ");
            sql.AppendLine("left outer join TB_FIS_NCM f ");
            sql.AppendLine("on b.ncm = f.ncm ");
            sql.AppendLine("left outer join vtb_fin_clifor g ");
            sql.AppendLine("on cond.cd_cliforind = g.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_pessoasautorizadas h ");
            sql.AppendLine("on cond.cd_clifor = h.cd_clifor ");
            sql.AppendLine("and cond.id_pessoa = h.id_pessoa ");

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

        public TList_ItensCondicional Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCondicional lista = new TList_ItensCondicional();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCondicional reg = new TRegistro_ItensCondicional();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("ID_Condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_faturada")))
                        reg.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("Qtd_faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforind")))
                        reg.Cd_cliforind = reader.GetString(reader.GetOrdinal("cd_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforind")))
                        reg.Nm_cliforind = reader.GetString(reader.GetOrdinal("nm_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pessoa")))
                        reg.Id_pessoa = reader.GetDecimal(reader.GetOrdinal("id_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pessoa")))
                        reg.Nm_pessoa = reader.GetString(reader.GetOrdinal("nm_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_nfcond")))
                        reg.Qtd_nfcond = reader.GetDecimal(reader.GetOrdinal("qtd_nfcond"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_nfdev")))
                        reg.Qtd_nfdev = reader.GetDecimal(reader.GetOrdinal("qtd_nfdev"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota")))
                        reg.Pc_aprox_imposto = reader.GetDecimal(reader.GetOrdinal("pc_aliquota"));

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

        public string Gravar(TRegistro_ItensCondicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_ITENSCONDICIONAL", hs);
        }

        public string Excluir(TRegistro_ItensCondicional val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_PDV_ITENSCONDICIONAL", hs);
        }
    }
    #endregion

    #region Estoque Item
    public class TList_ItensCondicional_X_Estoque : List<TRegistro_ItensCondicional_X_Estoque>
    { }
    
    public class TRegistro_ItensCondicional_X_Estoque
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch
                { id_condicional = null; }
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

        public TRegistro_ItensCondicional_X_Estoque()
        {
            this.Cd_empresa = string.Empty;
            this.id_condicional = null;
            this.id_condicionalstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_lanctoestoque = null;
            this.id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_ItensCondicional_X_Estoque : TDataQuery
    {
        public TCD_ItensCondicional_X_Estoque() { }

        public TCD_ItensCondicional_X_Estoque(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Condicional, a.ID_Item, a.CD_Produto, a.Id_LanctoEstoque ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_PDV_ItensCondicional_X_Estoque a ");

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

        public TList_ItensCondicional_X_Estoque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCondicional_X_Estoque lista = new TList_ItensCondicional_X_Estoque();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCondicional_X_Estoque reg = new TRegistro_ItensCondicional_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("ID_Condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));

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

        public string Gravar(TRegistro_ItensCondicional_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("IA_PDV_ITENSCONDICIONAL_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_ItensCondicional_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_PDV_ITENSCONDICIONAL_X_ESTOQUE", hs);
        }
    }
    #endregion

    #region Faturamento Item
    public class TList_ItensCondicional_X_VendaRapida : List<TRegistro_ItensCondicional_X_VendaRapida>
    { }

    public class TRegistro_ItensCondicional_X_VendaRapida
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch
                { id_condicional = null; }
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

        public TRegistro_ItensCondicional_X_VendaRapida()
        {
            this.Cd_empresa = string.Empty;
            this.id_condicional = null;
            this.id_condicionalstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
        }
    }

    public class TCD_ItensCondicional_X_VendaRapida : TDataQuery
    {
        public TCD_ItensCondicional_X_VendaRapida() { }

        public TCD_ItensCondicional_X_VendaRapida(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Condicional, a.ID_Item, a.Id_Cupom, a.Id_lancto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_PDV_ItensCondicional_X_VendaRapida a ");

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

        public TList_ItensCondicional_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCondicional_X_VendaRapida lista = new TList_ItensCondicional_X_VendaRapida();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCondicional_X_VendaRapida reg = new TRegistro_ItensCondicional_X_VendaRapida();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("ID_Condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("Id_lancto"));

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

        public string Gravar(TRegistro_ItensCondicional_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("IA_PDV_ITENSCONDICIONAL_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_ItensCondicional_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("EXCLUI_PDV_ITENSCONDICIONAL_X_VENDARAPIDA", hs);
        }
    }
    #endregion

    #region Itens X NF
    public class TList_ItensCondicional_x_NFItem : List<TRegistro_ItensCondicional_x_NFItem>
    { }

    public class TRegistro_ItensCondicional_x_NFItem
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_condicional;
        public decimal? Id_condicional
        {
            get { return id_condicional; }
            set
            {
                id_condicional = value;
                id_condicionalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_condicionalstr;
        public string Id_condicionalstr
        {
            get { return id_condicionalstr; }
            set
            {
                id_condicionalstr = value;
                try
                {
                    id_condicional = decimal.Parse(value);
                }
                catch { id_condicional = null; }
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
                catch { id_item = null; }
            }
        }
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
                catch { nr_lanctofiscal = null; }
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
                catch { id_nfitem = null; }
            }
        }

        public TRegistro_ItensCondicional_x_NFItem()
        {
            this.Cd_empresa = string.Empty;
            this.id_condicional = null;
            this.id_condicionalstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
        }
    }

    public class TCD_ItensCondicional_x_NFItem : TDataQuery
    {
        public TCD_ItensCondicional_x_NFItem() { }

        public TCD_ItensCondicional_x_NFItem(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Condicional, a.ID_Item, a.NR_LanctoFiscal, a.ID_NFItem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_PDV_ItensCondicional_X_NFItem a ");

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

        public TList_ItensCondicional_x_NFItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCondicional_x_NFItem lista = new TList_ItensCondicional_x_NFItem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCondicional_x_NFItem reg = new TRegistro_ItensCondicional_x_NFItem();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Condicional")))
                        reg.Id_condicional = reader.GetDecimal(reader.GetOrdinal("ID_Condicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));

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

        public string Gravar(TRegistro_ItensCondicional_x_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("IA_PDV_ITENSCONDICIONAL_X_NFITEM", hs);
        }

        public string Excluir(TRegistro_ItensCondicional_x_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONDICIONAL", val.Id_condicional);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("EXCLUI_PDV_ITENSCONDICIONAL_X_NFITEM", hs);
        }
    }
    #endregion
}
