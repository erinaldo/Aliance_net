using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CTRC
{
    #region Lote CTe
    public class TList_LoteCTe : List<TRegistro_LoteCTe>, IComparer<TRegistro_LoteCTe>
    {
        #region IComparer<TRegistro_LoteCTe> Members
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

        public TList_LoteCTe()
        { }

        public TList_LoteCTe(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteCTe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteCTe x, TRegistro_LoteCTe y)
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
    
    public class TRegistro_LoteCTe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        {get;set;}
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
                catch { id_lote = null; }
            }
        }
        private DateTime? dt_recebimento;
        public DateTime? Dt_recebimento
        {
            get { return dt_recebimento; }
            set
            {
                dt_recebimento = value;
                dt_recebimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_recebimentostr;
        public string Dt_recebimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_recebimentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_recebimentostr = value;
                try
                {
                    dt_recebimento = DateTime.Parse(value);
                }
                catch { dt_recebimento = null; }
            }
        }
        private decimal? status;
        public decimal? Status
        {
            get { return status; }
            set
            {
                status = value;
                statusstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string statusstr;
        public string Statusstr
        {
            get { return statusstr; }
            set
            {
                statusstr = value;
                try
                {
                    status = decimal.Parse(value);
                }
                catch { status = null; }
            }
        }
        public string Ds_mensagem
        { get; set; }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente = "PRODUÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente = "HOMOLOGAÇÃO";
            }
        }
        private string tipo_ambiente;
        public string Tipo_ambiente
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("PRODUÇÃO"))
                    tp_ambiente = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente = "2";
            }
        }
        private decimal? nr_recibo;
        public decimal? Nr_recibo
        {
            get { return nr_recibo; }
            set
            {
                nr_recibo = value;
                nr_recibostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_recibostr;
        public string Nr_recibostr
        {
            get { return nr_recibostr; }
            set
            {
                nr_recibostr = value;
                try
                {
                    nr_recibo = decimal.Parse(value);
                }
                catch { nr_recibo = null; }
            }
        }
        public string Tp_emissaocte
        {get;set;}
        public string Tipo_emissaocte
        {
            get
            {
                if (Tp_emissaocte.Trim().Equals("1"))
                    return "NORMAL";
                else if (Tp_emissaocte.Trim().Equals("7"))
                    return "SVC-Rio Grande do Sul";
                else if (Tp_emissaocte.Trim().Equals("8"))
                    return "SVC-São Paulo";
                else return string.Empty;
            }
        }
        public TList_Lote_X_CTe lCTe
        { get; set; }

        public TRegistro_LoteCTe()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.dt_recebimento = null;
            this.dt_recebimentostr = string.Empty;
            this.status = null;
            this.statusstr = string.Empty;
            this.Ds_mensagem = string.Empty;
            this.tp_ambiente = string.Empty;
            this.tipo_ambiente = string.Empty;
            this.nr_recibo = null;
            this.nr_recibostr = string.Empty;
            this.Tp_emissaocte = string.Empty;
            this.lCTe = new TList_Lote_X_CTe();
        }
    }

    public class TCD_LoteCTe : TDataQuery
    {
        public TCD_LoteCTe() { }

        public TCD_LoteCTe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_lote, a.dt_recebimento, a.status, a.ds_mensagem, ");
                sql.AppendLine("a.tp_ambiente, a.nr_recibo, a.tp_emissaocte ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_LoteCTe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
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

        public TList_LoteCTe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_LoteCTe lista = new TList_LoteCTe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_LoteCTe reg = new TRegistro_LoteCTe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("id_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_recebimento")))
                        reg.Dt_recebimento = reader.GetDateTime(reader.GetOrdinal("dt_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("ds_mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_recibo")))
                        reg.Nr_recibo = reader.GetDecimal(reader.GetOrdinal("nr_recibo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_emissaocte")))
                        reg.Tp_emissaocte = reader.GetString(reader.GetOrdinal("tp_emissaocte"));

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

        public string Gravar(TRegistro_LoteCTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_DT_RECEBIMENTO", val.Dt_recebimento);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_NR_RECIBO", val.Nr_recibo);
            hs.Add("@P_TP_EMISSAOCTE", val.Tp_emissaocte);

            return this.executarProc("IA_CTR_LOTECTE", hs);
        }

        public string Excluir(TRegistro_LoteCTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_CTR_LOTECTE", hs);
        }
    }
    #endregion

    #region Lote X CTe
    public class TList_Lote_X_CTe : List<TRegistro_Lote_X_CTe>
    { }
    
    public class TRegistro_Lote_X_CTe
    {
        public string Cd_empresa
        { get; set; }
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
                catch { id_lote = null; }
            }
        }
        private decimal? nr_lanctoctr;
        public decimal? Nr_lanctoctr
        {
            get { return nr_lanctoctr; }
            set
            {
                nr_lanctoctr = value;
                nr_lanctoctrstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoctrstr;
        public string Nr_lanctoctrstr
        {
            get { return nr_lanctoctrstr; }
            set
            {
                nr_lanctoctrstr = value;
                try
                {
                    nr_lanctoctr = decimal.Parse(value);
                }
                catch { nr_lanctoctr = null; }
            }
        }
        private decimal? nr_ctrc;
        public decimal? Nr_ctrc
        {
            get { return nr_ctrc; }
            set
            {
                nr_ctrc = value;
                nr_ctrcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_ctrcstr;
        public string Nr_ctrcstr
        {
            get { return nr_ctrcstr; }
            set
            {
                nr_ctrcstr = value;
                try
                {
                    nr_ctrc = decimal.Parse(value);
                }
                catch { nr_ctrc = null; }
            }
        }
        public string ChaveAcesso
        { get; set; }
        public string Nm_remetente
        { get; set; }
        public string Nm_destinatario
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        private DateTime? dt_processamento;
        public DateTime? Dt_processamento
        {
            get { return dt_processamento; }
            set
            {
                dt_processamento = value;
                dt_processamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_processamentostr;
        public string Dt_processamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_processamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_processamentostr = value;
                try
                {
                    dt_processamento = DateTime.Parse(value);
                }
                catch { dt_processamento = null; }
            }
        }
        private decimal? nr_protocolo;
        public decimal? Nr_protocolo
        {
            get { return nr_protocolo; }
            set
            {
                nr_protocolo = value;
                nr_protocolostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_protocolostr;
        public string Nr_protocolostr
        {
            get { return nr_protocolostr; }
            set
            {
                nr_protocolostr = value;
                try
                {
                    nr_protocolo = decimal.Parse(value);
                }
                catch { nr_protocolo = null; }
            }
        }
        public string Digval
        { get; set; }
        public string VerAplic
        { get; set; }
        private decimal? status;
        public decimal? Status
        {
            get { return status; }
            set
            {
                status = value;
                statusstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string statusstr;
        public string Statusstr
        {
            get { return statusstr; }
            set
            {
                statusstr = value;
                try
                {
                    status = decimal.Parse(value);
                }
                catch { status = null; }
            }
        }
        public string Ds_mensagem
        { get; set; }
        public string Tp_ambiente
        { get; set; }

        public TRegistro_Lote_X_CTe()
        {
            this.Cd_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.nr_lanctoctr = null;
            this.nr_lanctoctrstr = string.Empty;
            this.nr_ctrc = null;
            this.nr_ctrcstr = string.Empty;
            this.ChaveAcesso = string.Empty;
            this.Nm_destinatario = string.Empty;
            this.Nm_remetente = string.Empty;
            this.Vl_frete = decimal.Zero;
            this.nr_protocolo = null;
            this.nr_protocolostr = string.Empty;
            this.Digval = string.Empty;
            this.VerAplic = string.Empty;
            this.status = null;
            this.statusstr = string.Empty;
            this.Ds_mensagem = string.Empty;
            this.Tp_ambiente = string.Empty;
        }
    }

    public class TCD_Lote_X_CTe : TDataQuery
    {
        public TCD_Lote_X_CTe() { }

        public TCD_Lote_X_CTe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_lote, " );
                sql.AppendLine("a.nr_lanctoctr, a.dt_processamento, ");
                sql.AppendLine("a.nr_protocolo, a.digval, a.veraplic, a.status, a.ds_mensagem, ");
                sql.AppendLine("b.nr_ctrc, c.nm_clifor as nm_remetente, e.tp_ambiente, ");
                sql.AppendLine("d.nm_clifor as nm_destinatario, b.vl_frete, b.chaveacesso ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_Lote_X_CTe a ");
            sql.AppendLine("inner join TB_CTR_ConhecimentoFrete b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoctr = b.nr_lanctoctr ");
            sql.AppendLine("inner join tb_fin_clifor c ");
            sql.AppendLine("on b.cd_remetente = c.cd_clifor ");
            sql.AppendLine("inner join tb_fin_clifor d ");
            sql.AppendLine("on b.cd_destinatario = d.cd_clifor ");
            sql.AppendLine("inner join TB_CTR_LoteCTe e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.id_lote = e.id_lote ");

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

        public TList_Lote_X_CTe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lote_X_CTe lista = new TList_Lote_X_CTe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Lote_X_CTe reg = new TRegistro_Lote_X_CTe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("id_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_ctrc")))
                        reg.Nr_ctrc = reader.GetDecimal(reader.GetOrdinal("nr_ctrc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.ChaveAcesso = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_remetente")))
                        reg.Nm_remetente = reader.GetString(reader.GetOrdinal("nm_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_destinatario")))
                        reg.Nm_destinatario = reader.GetString(reader.GetOrdinal("nm_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("dt_processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("nr_protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("digval")))
                        reg.Digval = reader.GetString(reader.GetOrdinal("digval"));
                    if (!reader.IsDBNull(reader.GetOrdinal("veraplic")))
                        reg.VerAplic = reader.GetString(reader.GetOrdinal("veraplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("ds_mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));

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

        public string Gravar(TRegistro_Lote_X_CTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_processamento);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_DIGVAL", val.Digval);
            hs.Add("@P_VERAPLIC", val.VerAplic);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);

            return this.executarProc("IA_CTR_LOTE_X_CTE", hs);
        }

        public string Excluir(TRegistro_Lote_X_CTe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);

            return this.executarProc("EXCLUI_CTR_LOTE_X_CTE", hs);
        }
    }
    #endregion
}
