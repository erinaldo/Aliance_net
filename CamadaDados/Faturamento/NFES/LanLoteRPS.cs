using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.NFES
{
    #region Lote RPS
    public class TList_LoteRPS : List<TRegistro_LoteRPS>
    { }
    
    public class TRegistro_LoteRPS
    {
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                Id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
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
                    id_lote = Convert.ToDecimal(value);
                }
                catch
                { id_lote = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private DateTime? dt_lote;
        public DateTime? Dt_lote
        {
            get { return dt_lote; }
            set
            {
                dt_lote = value;
                dt_lotestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_lotestr;
        public string Dt_lotestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lotestr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lotestr = value;
                try
                {
                    dt_lote = Convert.ToDateTime(value);
                }
                catch
                { dt_lote = null; }
            }
        }
        public string Nr_protocolo
        { get; set; }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_ambiente = "PRODUÇÃO";
                else if (value.Trim().ToUpper().Equals("H"))
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
                    tp_ambiente = "P";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente = "H";
            }
        }
        private string st_lote;
        public string St_lote
        {
            get { return st_lote; }
            set
            {
                st_lote = value;
                if (value.Trim().ToUpper().Equals("1"))
                    status_lote = "AGUARDANDO PROCESSAMENTO";
                else if (value.Trim().ToUpper().Equals("2"))
                    status_lote = "NÃO PROCESSADO";
                else if (value.Trim().ToUpper().Equals("3"))
                    status_lote = "PROCESSADO COM SUCESSO";
                else if (value.Trim().ToUpper().Equals("4"))
                    status_lote = "PROCESSADO COM AVISOS";
            }
        }
        private string status_lote;
        public string Status_lote
        {
            get { return status_lote; }
            set
            {
                status_lote = value;
                if (value.Trim().ToUpper().Equals("AGUARDANDO PROCESSAMENTO"))
                    st_lote = "1";
                else if (value.Trim().ToUpper().Equals("NÃO PROCESSADO"))
                    st_lote = "2";
                else if (value.Trim().ToUpper().Equals("PROCESSADO COM SUCESSO"))
                    st_lote = "3";
                else if (value.Trim().ToUpper().Equals("PROCESSADO COM AVISOS"))
                    st_lote = "4";
            }
        }
        public TList_MsgRetornoRPS lMsgRPS
        { get; set; }
        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNfes
        { get; set; }

        public TRegistro_LoteRPS()
        {
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.dt_lote = null;
            this.dt_lotestr = string.Empty;
            this.Nr_protocolo = string.Empty;
            this.tp_ambiente = string.Empty;
            this.tipo_ambiente = string.Empty;
            this.st_lote = "2";
            this.status_lote = "NÃO PROCESSADO";
            this.lMsgRPS = new TList_MsgRetornoRPS();
            this.lNfes = new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>();
        }
    }

    public class TCD_LoteRPS : TDataQuery
    {
        public TCD_LoteRPS()
        { }

        public TCD_LoteRPS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Lote, a.dt_lote, ");
                sql.AppendLine("a.nr_protocolo, a.tp_ambiente, a.st_lote, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_LoteRPS a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.id_lote desc ");
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

        public TList_LoteRPS Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LoteRPS lista = new TList_LoteRPS();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LoteRPS reg = new TRegistro_LoteRPS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_lote")))
                        reg.Dt_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetString(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("TP_Ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Lote")))
                        reg.St_lote = reader.GetString(reader.GetOrdinal("ST_Lote"));

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

        public string Gravar(TRegistro_LoteRPS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DT_LOTE", val.Dt_lote);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_ST_LOTE", val.St_lote);

            return this.executarProc("IA_FAT_LOTERPS", hs);
        }

        public string Excluir(TRegistro_LoteRPS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_LOTERPS", hs);
        }
    }
    #endregion

    #region Lote RPS X NFES
    public class TList_LoteRPS_X_NFES : List<TRegistro_LoteRPS_X_NFES>
    { }

    public class TRegistro_LoteRPS_X_NFES
    {
        public decimal? Id_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public decimal? Nr_nfse
        { get; set; }
        public decimal? Nr_rps
        { get; set; }
        public DateTime? Dt_cancelamento
        { get; set; }
        public string Cd_autenticacao
        { get; set; }
        public DateTime? Dt_autorizacao
        { get; set; }

        public TRegistro_LoteRPS_X_NFES()
        {
            this.Id_lote = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctofiscal = null;
            this.Nr_notafiscal = null;
            this.Nr_serie = string.Empty;
            this.Nr_nfse = null;
            this.Nr_rps = null;
            this.Dt_cancelamento = null;
            this.Cd_autenticacao = string.Empty;
            this.Dt_autorizacao = null;
        }
    }

    public class TCD_LoteRPS_X_NFES : TDataQuery
    {
        public TCD_LoteRPS_X_NFES()
        { }

        public TCD_LoteRPS_X_NFES(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Lote, a.cd_empresa, ");
                sql.AppendLine("a.cd_autenticacao, a.dt_autorizacao, b.nr_serie, ");
                sql.AppendLine("a.nr_lanctofiscal, a.dt_cancelamento, ");
                sql.AppendLine("b.nr_notafiscal, b.nr_rps, a.nr_nfse ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_LoteRPS_X_NFES a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");

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

        public TList_LoteRPS_X_NFES Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LoteRPS_X_NFES lista = new TList_LoteRPS_X_NFES();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LoteRPS_X_NFES reg = new TRegistro_LoteRPS_X_NFES();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NFSe")))
                        reg.Nr_nfse = reader.GetDecimal(reader.GetOrdinal("NR_NFSe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_RPS")))
                        reg.Nr_rps = reader.GetDecimal(reader.GetOrdinal("NR_RPS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cancelamento")))
                        reg.Dt_cancelamento = reader.GetDateTime(reader.GetOrdinal("DT_Cancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Autenticacao")))
                        reg.Cd_autenticacao = reader.GetString(reader.GetOrdinal("CD_Autenticacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Autorizacao")))
                        reg.Dt_autorizacao = reader.GetDateTime(reader.GetOrdinal("DT_Autorizacao"));

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

        public string Gravar(TRegistro_LoteRPS_X_NFES val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_NR_NFSE", val.Nr_nfse);
            hs.Add("@P_DT_CANCELAMENTO", val.Dt_cancelamento);
            hs.Add("@P_CD_AUTENTICACAO", val.Cd_autenticacao);
            hs.Add("@P_DT_AUTORIZACAO", val.Dt_autorizacao);

            return this.executarProc("IA_FAT_LOTERPS_X_NFES", hs);
        }

        public string Excluir(TRegistro_LoteRPS_X_NFES val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return this.executarProc("EXCLUI_FAT_LOTERPS_X_NFES", hs);
        }
    }
    #endregion

    #region Mensagem Lote RPS
    public class TList_MsgRetornoRPS : List<TRegistro_MsgRetornoRPS>
    { }

    
    public class TRegistro_MsgRetornoRPS
    {
        
        public decimal? Id_lote
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Id_mensagem
        { get; set; }
        
        public string Cd_mensagem
        {get;set;}
        
        public string Ds_mensagem
        {get;set;}
        
        public string Ds_correcao
        { get; set; }
        private string tp_origem;
        
        public string Tp_origem
        {
            get { return tp_origem; }
            set
            {
                tp_origem = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_origem = "ENVIAR LOTE RPS";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_origem = "CONSULTAR LOTE RPS";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_origem = "CANCELAR NFES";
            }
        }
        private string tipo_origem;
        
        public string Tipo_origem
        {
            get { return tipo_origem; }
            set
            {
                tipo_origem = value;
                if (value.Trim().ToUpper().Equals("ENVIAR LOTE RPS"))
                    tp_origem = "1";
                else if (value.Trim().ToUpper().Equals("CONSULTAR LOTE RPS"))
                    tp_origem = "2";
                else if (value.Trim().ToUpper().Equals("CANCELAR NFES"))
                    tp_origem = "3";
            }
        }

        public TRegistro_MsgRetornoRPS()
        {
            this.Id_lote = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_mensagem = null;
            this.Cd_mensagem = string.Empty;
            this.Ds_mensagem = string.Empty;
            this.Ds_correcao = string.Empty;
            this.tp_origem = string.Empty;
            this.tipo_origem = string.Empty;
        }
    }

    public class TCD_MsgRetornoRPS : TDataQuery
    {
        public TCD_MsgRetornoRPS()
        { }

        public TCD_MsgRetornoRPS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Lote, a.id_mensagem, ");
                sql.AppendLine("a.cd_mensagem, a.ds_mensagem, a.ds_correcao, a.tp_origem, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_MsgRetornoRPS a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

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

        public TList_MsgRetornoRPS Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MsgRetornoRPS lista = new TList_MsgRetornoRPS();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MsgRetornoRPS reg = new TRegistro_MsgRetornoRPS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mensagem")))
                        reg.Id_mensagem = reader.GetDecimal(reader.GetOrdinal("ID_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Mensagem")))
                        reg.Cd_mensagem = reader.GetString(reader.GetOrdinal("CD_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("DS_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Correcao")))
                        reg.Ds_correcao = reader.GetString(reader.GetOrdinal("DS_Correcao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Origem")))
                        reg.Tp_origem = reader.GetString(reader.GetOrdinal("TP_Origem"));

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

        public string Gravar(TRegistro_MsgRetornoRPS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MENSAGEM", val.Id_mensagem);
            hs.Add("@P_CD_MENSAGEM", val.Cd_mensagem);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_DS_CORRECAO", val.Ds_correcao);
            hs.Add("@P_TP_ORIGEM", val.Tp_origem);

            return this.executarProc("IA_FAT_MSGRETORNORPS", hs);
        }

        public string Excluir(TRegistro_MsgRetornoRPS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MENSAGEM", val.Id_mensagem);

            return this.executarProc("EXCLUI_FAT_MSGRETORNORPS", hs);
        }
    }
    #endregion
}
