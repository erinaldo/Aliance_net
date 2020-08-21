using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Producao.Producao
{
    #region Rastreabilidade
    public class TList_Rastreabilidade : List<TRegistro_Rastreabilidade>, IComparer<TRegistro_Rastreabilidade>
    {
        #region IComparer<TRegistro_Rastreabilidade> Members
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

        public TList_Rastreabilidade()
        { }

        public TList_Rastreabilidade(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Rastreabilidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Rastreabilidade x, TRegistro_Rastreabilidade y)
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


    public class TRegistro_Rastreabilidade
    {
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch
                { id_lote = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Nr_lote
        { get; set; }
        private DateTime? dt_fabric;
        public DateTime? Dt_fabric
        {
            get { return dt_fabric; }
            set
            {
                dt_fabric = value;
                dt_fabricstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fabricstr;
        public string Dt_fabricstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fabricstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fabricstr = value;
                try
                {
                    dt_fabric = Convert.ToDateTime(value);
                }
                catch
                { dt_fabric = null; }
            }
        }
        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = Convert.ToDateTime(value);
                }
                catch
                { dt_validade = null; }
            }
        }
        public decimal Qtd_Entrada
        { get; set; }
        public decimal Qtd_Saida
        { get; set; }
        public decimal Qtd_saldo
        { get { return this.Qtd_Entrada - this.Qtd_Saida; } }


        public TRegistro_Rastreabilidade()
        {
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Nr_lote = string.Empty;
            this.dt_fabric = null;
            this.dt_fabricstr = string.Empty;
            this.dt_validade = null;
            this.dt_validadestr = string.Empty;
            this.Qtd_Entrada = decimal.Zero;
            this.Qtd_Saida = decimal.Zero;
        }
    }

    public class TCD_Rastreabilidade : TDataQuery
    {
        public TCD_Rastreabilidade()
        { }

        public TCD_Rastreabilidade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.ID_Lote, a.CD_Empresa, emp.nm_empresa, a.cd_clifor, c.nm_clifor, a.CD_Produto, b.ds_produto, ");
                sql.AppendLine("a.Nr_lote, a.Dt_fabric, a.Dt_validade, a.QTD_Entrada, a.QTD_Saida ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from VTB_PRD_Rastreabilidade a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");

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

        public TList_Rastreabilidade Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Rastreabilidade lista = new TList_Rastreabilidade();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Rastreabilidade reg = new TRegistro_Rastreabilidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("Id_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("Nr_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_fabric")))
                        reg.Dt_fabric = reader.GetDateTime(reader.GetOrdinal("Dt_fabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("Dt_validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entrada")))
                        reg.Qtd_Entrada = reader.GetDecimal(reader.GetOrdinal("QTD_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_Saida")))
                        reg.Qtd_Saida = reader.GetDecimal(reader.GetOrdinal("Qtd_Saida"));

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

        public string Gravar(TRegistro_Rastreabilidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_NR_LOTE", val.Nr_lote);
            hs.Add("@P_DT_FABRIC", val.Dt_fabric);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);

            return this.executarProc("IA_PRD_RASTREABILIDADE", hs);
        }

        public string Excluir(TRegistro_Rastreabilidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_PRD_RASTREABILIDADE", hs);
        }
    }
    #endregion

    #region Mov Rastreabilidade
    public class TList_MovRastreabilidade : List<TRegistro_MovRastreabilidade>, IComparer<TRegistro_MovRastreabilidade>
    {
        #region IComparer<TRegistro_MovRastreabilidade> Members
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

        public TList_MovRastreabilidade()
        { }

        public TList_MovRastreabilidade(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovRastreabilidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovRastreabilidade x, TRegistro_MovRastreabilidade y)
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


    public class TRegistro_MovRastreabilidade
    {
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch
                { id_lote = null; }
            }
        }
        public string Nr_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_mov;
        public decimal? Id_mov
        {
            get { return id_mov; }
            set
            {
                id_mov = value;
                id_movstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movstr;
        public string Id_movstr
        {
            get { return id_movstr; }
            set
            {
                id_movstr = value;
                try
                {
                    id_mov = decimal.Parse(value);
                }
                catch
                { id_mov = null; }
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
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private decimal? id_apontamento;      
        public decimal? Id_apontamento
        {
            get { return id_apontamento; }
            set
            {
                id_apontamento = value;
                id_apontamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_apontamentostr;
        
        public string Id_apontamentostr
        {
            get { return id_apontamentostr; }
            set
            {
                id_apontamentostr = value;
                try
                {
                    id_apontamento = Convert.ToDecimal(value);
                }
                catch
                { id_apontamento = null; }
            }
        }
        private string tp_mov;
        
        public string Tp_mov
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_mov = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_mov = "SAIDA";
            }
        }
        private string tipo_mov;
        
        public string Tipo_mov
        {
            get { return tipo_mov; }
            set
            {
                tipo_mov = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_mov = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_mov = "S";
            }
        }
        private DateTime? dt_fabric;
        public DateTime? Dt_fabric
        {
            get { return dt_fabric; }
            set
            {
                dt_fabric = value;
                dt_fabricstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fabricstr;
        public string Dt_fabricstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fabricstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fabricstr = value;
                try
                {
                    dt_fabric = Convert.ToDateTime(value);
                }
                catch
                { dt_fabric = null; }
            }
        }
        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = Convert.ToDateTime(value);
                }
                catch
                { dt_validade = null; }
            }
        }
        public decimal Quantidade
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNfOrigem
        { get; set; }


        public TRegistro_MovRastreabilidade()
        {
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Nr_lote = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_mov = null;
            this.id_movstr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.id_apontamento = null;
            this.id_apontamentostr = string.Empty;
            this.tp_mov = string.Empty;
            this.Tipo_mov = string.Empty;
            this.dt_fabric = null;
            this.dt_fabricstr = string.Empty;
            this.dt_validade = null;
            this.dt_validadestr = string.Empty;
            this.Quantidade = decimal.Zero;
            this.lNfOrigem = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
        }
    }

    public class TCD_MovRastreabilidade : TDataQuery
    {
        public TCD_MovRastreabilidade()
        { }

        public TCD_MovRastreabilidade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.ID_Lote, b.Nr_lote, a.CD_Empresa, emp.nm_empresa, a.Id_MOV, a.Nr_lanctoFiscal, a.ID_NFItem, ");
                sql.AppendLine("b.cd_produto, c.ds_produto, a.ID_apontamento, a.TP_Mov, b.dt_fabric, b.dt_validade, a.Quantidade ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PRD_MovRastreabilidade a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join TB_PRD_Rastreabilidade b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_lote = b.id_lote ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");

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

        public TList_MovRastreabilidade Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_MovRastreabilidade lista = new TList_MovRastreabilidade();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovRastreabilidade reg = new TRegistro_MovRastreabilidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("Id_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("Nr_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_mov")))
                        reg.Id_mov = reader.GetDecimal(reader.GetOrdinal("Id_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("Id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("Id_apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("Tp_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_fabric")))
                        reg.Dt_fabric = reader.GetDateTime(reader.GetOrdinal("Dt_fabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("Dt_validade"));
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

        public string Gravar(TRegistro_MovRastreabilidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return this.executarProc("IA_PRD_MOVRASTREABILIDADE", hs);
        }

        public string Excluir(TRegistro_MovRastreabilidade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MOV", val.Id_mov);

            return this.executarProc("EXCLUI_PRD_MOVRASTREABILIDADE", hs);
        }
    }
    #endregion
}
