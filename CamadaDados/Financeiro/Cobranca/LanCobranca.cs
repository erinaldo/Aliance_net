using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Cobranca
{
    #region Cobranca Cliente
    public class TList_CobrancaClifor : List<TRegistro_CobrancaClifor>, IComparer<TRegistro_CobrancaClifor>
    {
        #region IComparer<TRegistro_CobrancaClifor> Members
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

        public TList_CobrancaClifor()
        { }

        public TList_CobrancaClifor(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CobrancaClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CobrancaClifor x, TRegistro_CobrancaClifor y)
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

    
    public class TRegistro_CobrancaClifor
    {
        private decimal? id_cobranca;
        
        public decimal? Id_cobranca
        {
            get { return id_cobranca; }
            set
            {
                id_cobranca = value;
                id_cobrancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cobrancastr;
        
        public string Id_cobrancastr
        {
            get { return id_cobrancastr; }
            set
            {
                id_cobrancastr = value;
                try
                {
                    id_cobranca = decimal.Parse(value);
                }
                catch
                { id_cobranca = null; }
            }
        }
        
        public string Login
        { get; set; }
        
        public string Nome_usuario
        { get; set; }
        private DateTime? dt_cobranca;
        
        public DateTime? Dt_cobranca
        {
            get { return dt_cobranca; }
            set
            {
                dt_cobranca = value;
                dt_cobrancastr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_cobrancastr;
        public string Dt_cobrancastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cobrancastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_cobrancastr = value;
                try
                {
                    dt_cobranca = Convert.ToDateTime(value);
                }
                catch
                { dt_cobranca = null; }
            }
        }
        private string hora_agendamento;
        
        public string Hora_agendamento
        {
            get { return hora_agendamento; }
            set
            { hora_agendamento = value; }
        }
        
        public string Ds_historico
        { get; set; }
        
        public string Nm_contato
        { get; set; }
        
        public string Fone_contato
        { get; set; }
        private DateTime? dt_agendamento;
        
        public DateTime? Dt_agendamento
        {
            get 
            { return dt_agendamento; }
            set
            {
                dt_agendamento = value;
                dt_agendamentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_agendamentostr;
        public string Dt_agendamentostr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_agendamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_agendamentostr = value;
                try
                {
                    dt_agendamento = Convert.ToDateTime(value);
                }
                catch
                { dt_agendamento = null; }
            }
        }
        public string Email { get; set; } = string.Empty;


        public TList_Cobranca_X_Parcelas lParcelas
        { get; set; }

        public TRegistro_CobrancaClifor()
        {
            this.id_cobranca = null;
            this.id_cobrancastr = string.Empty;
            this.Login = string.Empty;
            this.Nome_usuario = string.Empty;
            this.dt_cobranca = null;
            this.dt_cobrancastr = string.Empty;
            this.Ds_historico = string.Empty;
            this.Nm_contato = string.Empty;
            this.Fone_contato = string.Empty;
            this.dt_agendamento = null;
            this.dt_agendamentostr = string.Empty;
            this.lParcelas = new TList_Cobranca_X_Parcelas();
        }
    }

    public class TCD_CobrancaClifor : TDataQuery
    {
        public TCD_CobrancaClifor()
        { }

        public TCD_CobrancaClifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.id_cobranca, a.login, b.nome_usuario, ");
                sql.AppendLine("a.dt_cobranca, a.ds_historico, a.nm_contato, a.fone_contato, a.dt_agendamento ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cobrancaclifor a ");
            sql.AppendLine("inner join tb_div_usuario b ");
            sql.AppendLine("on a.login = b.login ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CobrancaClifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CobrancaClifor lista = new TList_CobrancaClifor();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CobrancaClifor reg = new TRegistro_CobrancaClifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nome_usuario"))))
                        reg.Nome_usuario = reader.GetString(reader.GetOrdinal("Nome_usuario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Cobranca"))))
                        reg.Dt_cobranca = reader.GetDateTime(reader.GetOrdinal("DT_Cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Contato")))
                        reg.Nm_contato = reader.GetString(reader.GetOrdinal("NM_Contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_Contato")))
                        reg.Fone_contato = reader.GetString(reader.GetOrdinal("Fone_Contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Agendamento")))
                        reg.Dt_agendamento = reader.GetDateTime(reader.GetOrdinal("DT_Agendamento"));

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

        public string GravarCobranca(TRegistro_CobrancaClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_HISTORICO", val.Ds_historico);
            hs.Add("@P_NM_CONTATO", val.Nm_contato);
            hs.Add("@P_FONE_CONTATO", val.Fone_contato);
            hs.Add("@P_DT_AGENDAMENTO", val.Dt_agendamento);

            return this.executarProc("IA_FIN_COBRANCACLIFOR", hs);
        }

        public string DeletarCobranca(TRegistro_CobrancaClifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);

            return this.executarProc("EXCLUI_FIN_COBRANCACLIFOR", hs);
        }
    }
    #endregion

    #region Cobranca X Parcelas
    public class TList_Cobranca_X_Parcelas : List<TRegistro_Cobranca_X_Parcelas>
    { }

    
    public class TRegistro_Cobranca_X_Parcelas
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lancto
        { get; set; }
        
        public decimal? Cd_parcela
        { get; set; }
        
        public decimal? Id_cobranca
        { get; set; }

        public TRegistro_Cobranca_X_Parcelas()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = null;
            this.Cd_parcela = null;
            this.Id_cobranca = null;
        }
    }

    public class TCD_Cobranca_X_Parcelas : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine(" select " + strTop + " a.id_cobranca, a.cd_empresa, ");
                sql.AppendLine("a.nr_lancto, a.cd_parcela ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cobranca_x_parcelas a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cobranca_X_Parcelas Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cobranca_X_Parcelas lista = new TList_Cobranca_X_Parcelas();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cobranca_X_Parcelas reg = new TRegistro_Cobranca_X_Parcelas();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));

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

        public string GravarCobranca_X_Parcelas(TRegistro_Cobranca_X_Parcelas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);

            return this.executarProc("IA_FIN_COBRANCA_X_PARCELAS", hs);
        }

        public string DeletarCobranca_X_Parcelas(TRegistro_Cobranca_X_Parcelas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);

            return this.executarProc("EXCLUI_FIN_COBRANCA_X_PARCELAS", hs);
        }
    }
    #endregion
}
