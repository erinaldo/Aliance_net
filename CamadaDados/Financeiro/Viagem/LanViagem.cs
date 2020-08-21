using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Financeiro.Viagem
{
    #region Viagem
    public class TList_Viagem : List<TRegistro_Viagem>, IComparer<TRegistro_Viagem>
    {
        #region IComparer<TRegistro_Viagem> Members
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

        public TList_Viagem()
        { }

        public TList_Viagem(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Viagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Viagem x, TRegistro_Viagem y)
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

    public class TRegistro_Viagem
    {
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }

            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_funcionario
        { get; set; }
        public string Nm_funcionario
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        private DateTime? dt_ini;
        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = DateTime.Parse(value);
                }
                catch
                { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;
        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = DateTime.Parse(value);
                }
                catch
                { dt_fin = null; }
            }
        }
        public decimal KM_ini
        { get; set; }
        public decimal KM_fin
        { get; set; }
        public string Obs
        { get; set; }
        private DateTime? dt_acerto;
        public DateTime? Dt_acerto
        {
            get { return dt_acerto; }
            set
            {
                dt_acerto = value;
                dt_acertostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_acertostr;
        public string Dt_acertostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_acertostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_acertostr = value;
                try
                {
                    dt_acerto = DateTime.Parse(value);
                }
                catch
                { dt_acerto = null; }
            }
        }
        public decimal Vl_despesas
        { get; set; }
        public decimal Vl_despesasM
        { get; set; }
        public decimal Vl_despesasE
        { get { return decimal.Subtract(Vl_despesas, Vl_despesasM); } }
        public decimal Vl_adto
        { get; set; }
        public decimal SaldoDevolverC
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.ToUpper().Equals("A"))
                    return "ABERTA";
                else return "PROCESSADA";
            }
        }
        public bool St_processar
        { get; set; }
        public TList_DespesasViagem lDespesas
        { get; set; }
        public TList_DespesasViagem lDespesasDel
        { get; set; }
        public Adiantamento.TList_LanAdiantamento lAdto
        { get; set; }
        public Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public Caixa.TRegistro_LanCaixa rCaixa
        { get; set; }

        public Duplicata.TList_RegLanDuplicata lDup
        { get; set; }

        public TRegistro_Viagem()
        {
            id_viagem = null;
            id_viagemstr = string.Empty;
            Ds_viagem = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_funcionario = string.Empty;
            Nm_funcionario = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            Cd_lanctocaixa = null;
            Nr_lancto = null;
            dt_ini = null;
            dt_inistr = string.Empty;
            dt_fin = null;
            dt_finstr = string.Empty;
            KM_ini = decimal.Zero;
            KM_fin = decimal.Zero;
            Obs = string.Empty;
            dt_acerto = null;
            dt_acertostr = string.Empty;
            Vl_despesas = decimal.Zero;
            Vl_despesasM = decimal.Zero;
            Vl_adto = decimal.Zero;
            SaldoDevolverC = decimal.Zero;
            St_registro = "A";
            St_processar = false;

            lDespesas = new TList_DespesasViagem();
            lDespesasDel = new TList_DespesasViagem();
            lAdto = new Adiantamento.TList_LanAdiantamento();
            lDup = new Duplicata.TList_RegLanDuplicata();
            rDup = null;
            rCaixa = null;
        }
    }

    public class TCD_Viagem : TDataQuery
    {
        public TCD_Viagem()
        { }

        public TCD_Viagem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_viagem, a.ds_viagem, a.cd_contager, a.DS_ContaGer, a.cd_lanctocaixa, a.Nr_lancto, a.cd_empresa, a.nm_empresa, ");
                sql.AppendLine("a.cd_funcionario, a.nm_funcionario, a.dt_ini, a.dt_fin, a.km_ini, a.km_fin, a.obs, a.dt_acerto, a.vl_despesas, a.Vl_adto, a.st_registro, ");
                sql.AppendLine("Vl_despesasM = isnull((select sum(isnull(x.Vl_Unitario, 0) * ");
                sql.AppendLine("                      isnull(x.quantidade, 0)) ");
                sql.AppendLine("                      from TB_FIN_DespesasViagem x ");
                sql.AppendLine("                      where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                      and x.id_viagem = a.id_viagem ");
                sql.AppendLine("                      and x.TP_Pagamento = '0'), 0), ");
                sql.AppendLine("SaldoDevolverC = isnull((Select sum(isnull(x.vl_pagar, 0) - isnull(x.vl_receber, 0)) ");
                sql.AppendLine("                        from vtb_fin_adiantamento x ");
                sql.AppendLine("                        where x.CD_Clifor = a.cd_funcionario ");
                sql.AppendLine("                        and x.Tp_movimento = 'C'), 0) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_viagem a ");

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

        public TList_Viagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem lista = new TList_Viagem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem reg = new TRegistro_Viagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("Cd_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_funcionario")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("nm_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("Cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("Ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_lanctocaixa")))
                        reg.Cd_lanctocaixa= reader.GetDecimal(reader.GetOrdinal("Cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("Nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("dt_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_ini")))
                        reg.KM_ini = reader.GetDecimal(reader.GetOrdinal("km_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_fin")))
                        reg.KM_fin = reader.GetDecimal(reader.GetOrdinal("km_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_acerto")))
                        reg.Dt_acerto = reader.GetDateTime(reader.GetOrdinal("dt_acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_despesasM")))
                        reg.Vl_despesasM = reader.GetDecimal(reader.GetOrdinal("Vl_despesasM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_adto")))
                        reg.Vl_adto = reader.GetDecimal(reader.GetOrdinal("Vl_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoDevolverC")))
                        reg.SaldoDevolverC = reader.GetDecimal(reader.GetOrdinal("SaldoDevolverC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("St_registro"));

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

        public string Gravar(TRegistro_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_DS_VIAGEM", val.Ds_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);
            hs.Add("@P_KM_INI", val.KM_ini);
            hs.Add("@P_KM_FIN", val.KM_fin);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_DT_ACERTO", val.Dt_acerto);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIN_VIAGEM", hs);
        }

        public string Excluir(TRegistro_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FIN_VIAGEM", hs);
        }
    }
    #endregion

    #region Despesas Viagem
    public class TList_DespesasViagem : List<TRegistro_DespesasViagem>, IComparer<TRegistro_DespesasViagem>
    {
        #region IComparer<TRegistro_DespesasViagem> Members
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

        public TList_DespesasViagem()
        { }

        public TList_DespesasViagem(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DespesasViagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DespesasViagem x, TRegistro_DespesasViagem y)
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

    public class TRegistro_DespesasViagem
    {
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_cliente { get; set; } = string.Empty;
        public string Nm_cliente { get; set; } = string.Empty;
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        private DateTime? dt_despesa;
        public DateTime? Dt_despesa
        {
            get { return dt_despesa; }
            set
            {
                dt_despesa = value;
                dt_despesastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_despesastr;
        public string Dt_despesastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_despesastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_despesastr = value;
                try
                {
                    dt_despesa = DateTime.Parse(value);
                }
                catch
                { dt_despesa = null; }
            }
        }
        public string Nr_notafiscal
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        private string tp_pagamento;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_pagamento = "FUNCIONÁRIO";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_pagamento = "EMPRESA";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("FUNCIONÁRIO"))
                    tp_pagamento = "0";
                else if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_pagamento = "1";
            }
        }
        public string Obs
        { get; set; }
        public bool St_processar
        { get; set;  }
        public Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public CCustoLan.TList_LanCCustoLancto lCCusto
        { get; set; }

        public TRegistro_DespesasViagem()
        {
            id_viagem = null;
            id_viagemstr = string.Empty;
            Ds_viagem = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Ds_despesa = string.Empty;
            dt_despesa = null;
            dt_despesastr = string.Empty;
            Nr_notafiscal = string.Empty;
            Nm_fornecedor = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            tp_pagamento = string.Empty;
            tipo_pagamento = string.Empty;
            Obs = string.Empty;
            St_processar = false;
            rDup = null;
            lCCusto = new CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_DespesasViagem : TDataQuery
    {
        public TCD_DespesasViagem()
        { }

        public TCD_DespesasViagem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.ID_Viagem, ");
                sql.AppendLine("b.DS_Viagem, a.CD_Empresa, c.NM_Empresa, ");
                sql.AppendLine("a.ID_Despesa, a.DS_Despesa, a.DT_Despesa, ");
                sql.AppendLine("a.Nr_NotaFiscal, a.NM_Fornecedor, a.Quantidade, ");
                sql.AppendLine("a.VL_Unitario, a.Quantidade * a.VL_Unitario as Vl_subtotal, ");
                sql.AppendLine("a.TP_Pagamento, a.Obs, a.cd_cliente,  d.nm_clifor ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_DespesasViagem a ");
            sql.AppendLine("inner join TB_FIN_Viagem b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_viagem = b.ID_Viagem ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("left outer join tb_fin_clifor d ");
            sql.AppendLine("on a.cd_cliente = d.cd_clifor ");

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

        public TList_DespesasViagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DespesasViagem lista = new TList_DespesasViagem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DespesasViagem reg = new TRegistro_DespesasViagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("DS_Viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliente")))
                        reg.Cd_cliente = reader.GetString(reader.GetOrdinal("cd_cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("ID_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("DS_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Despesa")))
                        reg.Dt_despesa = reader.GetDateTime(reader.GetOrdinal("DT_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetString(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("TP_Pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

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

        public string Gravar(TRegistro_DespesasViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIENTE", val.Cd_cliente);
            hs.Add("@P_DS_DESPESA", val.Ds_despesa);
            hs.Add("@P_DT_DESPESA", val.Dt_despesa);
            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_NM_FORNECEDOR", val.Nm_fornecedor);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_FIN_DESPESASVIAGEM", hs);
        }

        public string Excluir(TRegistro_DespesasViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FIN_DESPESASVIAGEM", hs);
        }
    }
    #endregion

    #region Viagem X Adiantamento
    public class TList_AdtoViagem : List<TRegistro_AdtoViagem>, IComparer<TRegistro_AdtoViagem>
    {
        #region IComparer<TRegistro_AdtoViagem> Members
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

        public TList_AdtoViagem()
        { }

        public TList_AdtoViagem(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AdtoViagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AdtoViagem x, TRegistro_AdtoViagem y)
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


    public class TRegistro_AdtoViagem
    {
        private decimal? id_adto;

        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;

        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        private decimal? id_viagem;

        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;

        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }

        public string Cd_empresa
        { get; set; }

        public TRegistro_AdtoViagem()
        {
            id_adto = null;
            id_adtostr = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Cd_empresa = string.Empty;
        }
    }

    public class TCD_AdtoViagem : TDataQuery
    {
        public TCD_AdtoViagem()
        { }

        public TCD_AdtoViagem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_adto, a.id_viagem, a.cd_empresa ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Viagem_X_Adto a ");

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

        public TList_AdtoViagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_AdtoViagem lista = new TList_AdtoViagem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AdtoViagem reg = new TRegistro_AdtoViagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));

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

        public string Gravar(TRegistro_AdtoViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("IA_FIN_VIAGEM_X_ADTO", hs);
        }

        public string Excluir(TRegistro_AdtoViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FIN_VIAGEM_X_ADTO", hs);
        }
    }
    #endregion

    #region Despesa Viagem X Centro Resultado
    public class TList_Viagem_X_CCusto : List<TRegistro_Viagem_X_CCusto>
    { }

    public class TRegistro_Viagem_X_CCusto
    {
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch { id_despesa = null; }
            }
        }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch { id_viagem = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch { id_ccustolan = null; }
            }
        }

        public TRegistro_Viagem_X_CCusto()
        {
            id_despesa = null;
            id_despesastr = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Cd_empresa = string.Empty;
            id_ccustolan = null;
            id_ccustolanstr = string.Empty;
        }
    }

    public class TCD_Viagem_X_CCusto : TDataQuery
    {
        public TCD_Viagem_X_CCusto() { }

        public TCD_Viagem_X_CCusto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_despesa, a.id_viagem, a.cd_empresa, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Viagem_X_CCusto a ");

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

        public TList_Viagem_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem_X_CCusto lista = new TList_Viagem_X_CCusto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem_X_CCusto reg = new TRegistro_Viagem_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));

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

        public string Gravar(TRegistro_Viagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("IA_FIN_VIAGEM_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_Viagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_VIAGEM_X_CCUSTO", hs);
        }
    }
    #endregion

    #region Despesa X Duplicata
    public class TList_Despesa_X_Duplicata : List<TRegistro_Despesa_X_Duplicata>
    { }


    public class TRegistro_Despesa_X_Duplicata
    {
        private decimal? id_despesa;

        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;

        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        private decimal? id_viagem;

        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;

        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }

        public string Cd_empresa
        { get; set; }
        private decimal? nr_lancto;

        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;

        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }

        public TRegistro_Despesa_X_Duplicata()
        {
            id_despesa = null;
            id_despesastr = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Cd_empresa = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
        }
    }

    public class TCD_Despesa_X_Duplicata : TDataQuery
    {
        public TCD_Despesa_X_Duplicata()
        { }

        public TCD_Despesa_X_Duplicata(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_despesa, a.id_viagem, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Despesas_X_Duplicata a ");

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

        public TList_Despesa_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Despesa_X_Duplicata lista = new TList_Despesa_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Despesa_X_Duplicata reg = new TRegistro_Despesa_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));

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

        public string Gravar(TRegistro_Despesa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("IA_FIN_DESPESAS_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Despesa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_FIN_DESPESAS_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region Viagem X DevCred
    public class TList_Viagem_X_DevCred : List<TRegistro_Viagem_X_DevCred>
    { }


    public class TRegistro_Viagem_X_DevCred
    {
        private decimal? id_adto;

        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;

        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        private decimal? id_viagem;

        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;

        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }

        public string Cd_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
        { get; set; }

        public TRegistro_Viagem_X_DevCred()
        {
            id_adto = null;
            id_adtostr = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Cd_empresa = string.Empty;
            Cd_contager = string.Empty;
            Cd_lanctocaixa = null;
        }
    }

    public class TCD_Viagem_X_DevCred : TDataQuery
    {
        public TCD_Viagem_X_DevCred()
        { }

        public TCD_Viagem_X_DevCred(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.id_viagem, ");
                sql.AppendLine("a.Id_Adto, a.CD_LanctoCaixa, a.CD_ContaGer ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Viagem_X_DevCred a ");

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

        public TList_Viagem_X_DevCred Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem_X_DevCred lista = new TList_Viagem_X_DevCred();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem_X_DevCred reg = new TRegistro_Viagem_X_DevCred();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("Id_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("Cd_contager"));

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

        public string Gravar(TRegistro_Viagem_X_DevCred val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("IA_FIN_VIAGEM_X_DEVCRED", hs);
        }

        public string Excluir(TRegistro_Viagem_X_DevCred val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("EXCLUI_FIN_VIAGEM_X_DEVCRED", hs);
        }
    }
    #endregion
}
