using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CamadaDados.Faturamento.PDV
{
    #region Credito Clifor
    public class TList_CreditoClifor : List<TRegistro_CreditoClifor>, IComparer<TRegistro_CreditoClifor>
    {
        #region IComparer<TRegistro_CreditoClifor> Members
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

        public TList_CreditoClifor()
        { }

        public TList_CreditoClifor(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CreditoClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CreditoClifor x, TRegistro_CreditoClifor y)
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

    [DataContract]
    public class TRegistro_CreditoClifor
    {
        private decimal? id_credito;
        [DataMember]
        public decimal? Id_credito
        {
            get { return id_credito; }
            set
            {
                id_credito = value;
                id_creditostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_creditostr;
        [DataMember]
        public string Id_creditostr
        {
            get { return id_creditostr; }
            set
            {
                id_creditostr = value;
                try
                {
                    id_credito = decimal.Parse(value);
                }
                catch
                { id_credito = null; }
            }
        }
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Nm_empresa
        { get; set; }
        [DataMember]
        public string Cd_clifor
        { get; set; }
        [DataMember]
        public string Nm_clifor
        { get; set; }
        [DataMember]
        public string Cd_endereco
        { get; set; }
        [DataMember]
        public string Ds_endereco
        { get; set; }
        private DateTime? dt_credito;
        [DataMember]
        public DateTime? Dt_credito
        {
            get { return dt_credito; }
            set
            {
                dt_credito = value;
                dt_creditostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_creditostr;
        [DataMember]
        public string Dt_creditostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_creditostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_creditostr = value;
                try
                {
                    dt_credito = DateTime.Parse(value);
                }
                catch
                { dt_credito = null; }
            }
        }
        [DataMember]
        public decimal Vl_credito
        { get; set; }
        [DataMember]
        public decimal Vl_devolvido
        { get; set; }
        public decimal Vl_saldodevolver
        { get { return this.Vl_credito - this.Vl_devolvido; } }
        [DataMember]
        public string Ds_observacao
        { get; set; }
        [DataMember]
        public string Cd_contager
        { get; set; }
        [DataMember]
        public CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa
        { get; set; }

        public TRegistro_CreditoClifor()
        {
            this.id_credito = null;
            this.id_creditostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.dt_credito = null;
            this.dt_creditostr = string.Empty;
            this.Vl_credito = decimal.Zero;
            this.Vl_devolvido = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.Cd_contager = string.Empty;
        }
    }

    public class TCD_CreditoClifor : TDataQuery
    {
        public TCD_CreditoClifor()
        { }

        public TCD_CreditoClifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_credito, a.cd_empresa, ");
                sql.AppendLine("b.nm_empresa, a.cd_clifor, c.nm_clifor, a.cd_endereco, ");
                sql.AppendLine("d.ds_endereco, a.dt_credito, a.ds_observacao, ");
                sql.AppendLine("a.vl_credito, a.vl_devolvido, a.cd_contager ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_CreditoClifor a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco d ");
            sql.AppendLine("on a.cd_clifor = d.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = d.cd_endereco ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CreditoClifor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CreditoClifor lista = new TList_CreditoClifor();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CreditoClifor reg = new TRegistro_CreditoClifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_credito"))))
                        reg.Id_credito = reader.GetDecimal(reader.GetOrdinal("id_credito"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_credito")))
                        reg.Dt_credito = reader.GetDateTime(reader.GetOrdinal("dt_credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_credito")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("vl_credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("vl_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));

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

        public string Gravar(TRegistro_CreditoClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_CREDITO", val.Id_credito);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DT_CREDITO", val.Dt_credito);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_PDV_CREDITOCLIFOR", hs);
        }

        public string Excluir(TRegistro_CreditoClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CREDITO", val.Id_credito);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDV_CREDITOCLIFOR", hs);
        }
    }
    #endregion

    #region Credito Clifor X Caixa
    public class TList_CreditoClifor_X_Caixa : List<TRegistro_CreditoClifor_X_Caixa>, IComparer<TRegistro_CreditoClifor_X_Caixa>
    {
        #region IComparer<TRegistro_CreditoClifor_X_Caixa> Members
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

        public TList_CreditoClifor_X_Caixa()
        { }

        public TList_CreditoClifor_X_Caixa(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CreditoClifor_X_Caixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CreditoClifor_X_Caixa x, TRegistro_CreditoClifor_X_Caixa y)
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

    [DataContract]
    public class TRegistro_CreditoClifor_X_Caixa
    {
        private decimal? id_credito;
        [DataMember]
        public decimal? Id_credito
        {
            get { return id_credito; }
            set
            {
                id_credito = value;
                id_creditostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_creditostr;
        [DataMember]
        public string Id_creditostr
        {
            get { return id_creditostr; }
            set
            {
                id_creditostr = value;
                try
                {
                    id_credito = decimal.Parse(value);
                }
                catch
                { id_credito = null; }
            }
        }
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Cd_contager
        { get; set; }
        [DataMember]
        private decimal? cd_lanctocaixa;
        [DataMember]
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        [DataMember]
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }

        public TRegistro_CreditoClifor_X_Caixa()
        {
            this.id_credito = null;
            this.id_creditostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_contager = string.Empty;
            this.cd_lanctocaixa = null;
            this.cd_lanctocaixastr = string.Empty;
        }
    }

    public class TCD_CreditoClifor_X_Caixa : TDataQuery
    {
        public TCD_CreditoClifor_X_Caixa()
        { }

        public TCD_CreditoClifor_X_Caixa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_credito, a.cd_empresa, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_CreditoClifor_X_Caixa a ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CreditoClifor_X_Caixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CreditoClifor_X_Caixa lista = new TList_CreditoClifor_X_Caixa();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CreditoClifor_X_Caixa reg = new TRegistro_CreditoClifor_X_Caixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_credito"))))
                        reg.Id_credito = reader.GetDecimal(reader.GetOrdinal("id_credito"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_contager"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));

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

        public string Gravar(TRegistro_CreditoClifor_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CREDITO", val.Id_credito);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("IA_PDV_CREDITOCLIFOR_X_CAIXA", hs);
        }

        public string Excluir(TRegistro_CreditoClifor_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CREDITO", val.Id_credito);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("EXCLUI_PDV_CREDITOCLIFOR_X_CAIXA", hs);
        }
    }
    #endregion
}
