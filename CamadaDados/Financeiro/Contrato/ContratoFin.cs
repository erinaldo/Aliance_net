using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Contrato
{
    #region Contrato Financeiro
    public class TList_ContratoFin : List<TRegistro_ContratoFin>, IComparer<TRegistro_ContratoFin>
    {
        #region IComparer<TRegistro_ContratoFin> Members
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

        public TList_ContratoFin()
        { }

        public TList_ContratoFin(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ContratoFin value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ContratoFin x, TRegistro_ContratoFin y)
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

    
    public class TRegistro_ContratoFin
    {
        private decimal? _NR_Contrato;
        public decimal? NR_Contrato
        {
            get { return _NR_Contrato; }
            set
            {
                _NR_Contrato = value;
                _NR_ContratoStr = value.ToString();
            }
        }
        private string _NR_ContratoStr;
        public string NR_ContratoStr
        {
            get
            {
                return _NR_ContratoStr;
            }
            set
            {
                _NR_ContratoStr = value;
                try
                {
                    _NR_Contrato = Convert.ToDecimal(value);
                }
                catch
                {
                    _NR_Contrato = null;
                }
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
        
        public string Cd_endereco
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Ds_contrato
        { get; set; }
        
        public string NR_ContratoOrigem
        { get; set; }
        
        public decimal? Nr_lancto
        { get; set; }
        
        public string Cd_condPagto
        { get; set; }
        
        public decimal QTD_parcelas
        { get; set; }
        
        public decimal QTD_diasdesdobro
        { get; set; }
        
        public decimal Vl_Contrato
        { get; set; }
        private DateTime? dt_contrato;
        
        public DateTime? Dt_contrato
        {
            get { return dt_contrato; }
            set
            {
                dt_contrato = value;
                dt_contratostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_contratostr;
        public string Dt_contratostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_contratostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_contratostr = value;
                try
                {
                    dt_contrato = DateTime.Parse(value);
                }
                catch
                { dt_contrato = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        private DateTime? dt_vencimento;
        
        public DateTime? Dt_vencimento
        {
            get { return dt_vencimento; }
            set
            {
                dt_vencimento = value;
                dt_vencimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencimentostr;
        public string Dt_vencimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_vencimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimentostr = value;
                try
                {
                    dt_vencimento = DateTime.Parse(value);
                }
                catch
                { dt_vencimento = null; }
            }
        }
        
        public string Ds_cultura
        { get; set; }
        
        public string Ds_area
        { get; set; }
        
        public string Status
        { get { return this.Nr_lancto != null ? "PROCESSADO" : "ABERTO"; } }
        
        public TList_ParcelaContrato lParc
        { get; set; }
        
        public TList_ParcelaContrato lParcDel
        { get; set; }
        
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }

        public CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcela
        { get; set; }

        public TRegistro_ContratoFin()
        {
            this.NR_Contrato = null;
            this.NR_ContratoStr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Ds_contrato = string.Empty;
            this.NR_ContratoOrigem = string.Empty;
            this.Nr_lancto = null;
            this.Cd_condPagto = string.Empty;
            this.QTD_parcelas = decimal.Zero;
            this.QTD_diasdesdobro = 30;
            this.Vl_Contrato = decimal.Zero;
            this.dt_contrato = DateTime.Now;
            this.dt_contratostr = DateTime.Now.ToString();
            this.Ds_observacao = string.Empty;
            this.dt_vencimento = null;
            this.dt_vencimentostr = string.Empty;
            this.Ds_cultura = string.Empty;
            this.Ds_area = string.Empty;
            this.lParc = new TList_ParcelaContrato();
            this.lParcDel = new TList_ParcelaContrato();
            this.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lParcela = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
        }
    }

    public class TCD_ContratoFin : TDataQuery
    {
        public TCD_ContratoFin()
        { }

        public TCD_ContratoFin(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Clifor, c.NM_Clifor, a.nr_lancto, a.cd_condPgto, ");
                sql.AppendLine("a.CD_Endereco, d.DS_Endereco, a.ds_contrato, ");
                sql.AppendLine("a.nr_contratoorigem, a.vl_contrato, ");
                sql.AppendLine("a.DT_contrato, a.DS_Observacao, a.dt_vencimento, a.ds_cultura, a.ds_area ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_ContratoFin a ");
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

        public TList_ContratoFin Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ContratoFin lista = new TList_ContratoFin();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ContratoFin reg = new TRegistro_ContratoFin();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.NR_Contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contrato")))
                        reg.Ds_contrato = reader.GetString(reader.GetOrdinal("ds_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contratoorigem")))
                        reg.NR_ContratoOrigem = reader.GetString(reader.GetOrdinal("nr_contratoorigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condPgto")))
                        reg.Cd_condPagto = reader.GetString(reader.GetOrdinal("cd_condPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contrato")))
                        reg.Vl_Contrato = reader.GetDecimal(reader.GetOrdinal("vl_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_contrato")))
                        reg.Dt_contrato = reader.GetDateTime(reader.GetOrdinal("DT_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencimento")))
                        reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("dt_vencimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cultura")))
                        reg.Ds_cultura = reader.GetString(reader.GetOrdinal("ds_cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("ds_area"));
      
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

        public string Gravar(TRegistro_ContratoFin val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_NR_CONTRATO", val.NR_Contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DS_CONTRATO", val.Ds_contrato);
            hs.Add("@P_NR_CONTRATOORIGEM", val.NR_ContratoOrigem);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condPagto);
            hs.Add("@P_VL_CONTRATO", val.Vl_Contrato);
            hs.Add("@P_DT_CONTRATO", val.Dt_contrato);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DT_VENCIMENTO", val.Dt_vencimento);
            hs.Add("@P_DS_CULTURA", val.Ds_cultura);
            hs.Add("@P_DS_AREA", val.Ds_area);

            return this.executarProc("IA_FIN_CONTRATOFIN", hs);
        }

        public string Excluir(TRegistro_ContratoFin val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CONTRATO", val.NR_Contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CONTRATOFIN", hs);
        }
    }
    #endregion

    #region Parcela Contrato
    public class TList_ParcelaContrato : List<TRegistro_ParcelaContrato>, IComparer<TRegistro_ParcelaContrato>
    {
        #region IComparer<TRegistro_ParcelaContrato> Members
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

        public TList_ParcelaContrato()
        { }

        public TList_ParcelaContrato(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ParcelaContrato value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ParcelaContrato x, TRegistro_ParcelaContrato y)
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

    
    public class TRegistro_ParcelaContrato
    {
        private decimal? _NR_Contrato;
        public decimal? NR_Contrato
        {
            get { return _NR_Contrato; }
            set
            {
                _NR_Contrato = value;
                _NR_ContratoStr = value.ToString();
            }
        }
        private string _NR_ContratoStr;
        public string NR_ContratoStr
        {
            get
            {
                return _NR_ContratoStr;
            }
            set
            {
                _NR_ContratoStr = value;
                try
                {
                    _NR_Contrato = Convert.ToDecimal(value);
                }
                catch
                {
                    _NR_Contrato = null;
                }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_parcela;
        
        public decimal? Id_parcela
        {
            get { return id_parcela; }
            set
            {
                id_parcela = value;
                id_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_parcelastr;
        
        public string Id_parcelastr
        {
            get { return id_parcelastr; }
            set
            {
                id_parcelastr = value;
                try
                {
                    id_parcela = decimal.Parse(value);
                }
                catch
                { id_parcela = null; }
            }
        }
        private DateTime? dt_venctoProvisao;
        
        public DateTime? Dt_venctoProvisao
        {
            get { return dt_venctoProvisao; }
            set
            {
                dt_venctoProvisao = value;
                dt_venctoProvisaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_venctoProvisaostr;
        public string Dt_venctoProvisaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_venctoProvisaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_venctoProvisaostr = value;
                try
                {
                    dt_venctoProvisao = DateTime.Parse(value);
                }
                catch
                { dt_venctoProvisao = null; }
            }
        }
        
        public decimal Vl_parcProvisao
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        
        public decimal Vl_atual
        { get; set; }
        
        public decimal Vl_liquidado
        { get; set; }
        
        public string StatusParcela
        { get; set; }

        public TRegistro_ParcelaContrato()
        {
            this.NR_Contrato = null;
            this.NR_ContratoStr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_parcela = null;
            this.id_parcelastr = string.Empty;
            this.dt_venctoProvisao = null;
            this.dt_venctoProvisaostr = string.Empty;
            this.Vl_parcProvisao = decimal.Zero;
            this.St_registro = "A";
            this.Vl_atual = decimal.Zero;
            this.Vl_liquidado = decimal.Zero;
            this.StatusParcela = string.Empty;
        }
    }

    public class TCD_ParcelaContrato : TDataQuery
    {
        public TCD_ParcelaContrato()
        { }

        public TCD_ParcelaContrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.CD_Empresa, ");
                sql.AppendLine("a.id_parcela, a.dt_venctoprovisao, ");
                sql.AppendLine("a.vl_parcprovisao, a.st_registro, b.vl_atual, b.vl_liquidado, b.status_parcela ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_ParcelaContrato a ");
            sql.AppendLine("inner join TB_FIN_ContratoFin fin ");
            sql.AppendLine("on a.CD_Empresa = fin.CD_Empresa ");
            sql.AppendLine("and a.NR_Contrato = fin.NR_Contrato ");
            sql.AppendLine("left outer join VTB_FIN_Parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and fin.nr_lancto = b.nr_lancto ");
            sql.AppendLine("and a.id_parcela = b.cd_parcela ");

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

        public TList_ParcelaContrato Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ParcelaContrato lista = new TList_ParcelaContrato();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ParcelaContrato reg = new TRegistro_ParcelaContrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.NR_Contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_parcela")))
                        reg.Id_parcela = reader.GetDecimal(reader.GetOrdinal("id_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_venctoprovisao")))
                        reg.Dt_venctoProvisao = reader.GetDateTime(reader.GetOrdinal("dt_venctoprovisao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_parcprovisao")))
                        reg.Vl_parcProvisao = reader.GetDecimal(reader.GetOrdinal("vl_parcprovisao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_atual")))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("vl_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_liquidado")))
                        reg.Vl_liquidado = reader.GetDecimal(reader.GetOrdinal("vl_liquidado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status_parcela")))
                        reg.StatusParcela = reader.GetString(reader.GetOrdinal("status_parcela"));

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

        public string Gravar(TRegistro_ParcelaContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_NR_CONTRATO", val.NR_Contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PARCELA", val.Id_parcela);
            hs.Add("@P_DT_VENCTOPROVISAO", val.Dt_venctoProvisao);
            hs.Add("@P_VL_PARCPROVISAO", val.Vl_parcProvisao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_PARCELACONTRATO", hs);
        }

        public string Excluir(TRegistro_ParcelaContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_CONTRATO", val.NR_Contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PARCELA", val.Id_parcela);

            return this.executarProc("EXCLUI_FIN_PARCELACONTRATO", hs);
        }
    }
    #endregion
}
