using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.NFCe
{
    public class TList_LoteNFCe : List<TRegistro_LoteNFCe>, IComparer<TRegistro_LoteNFCe>
    {
        #region IComparer<TRegistro_LoteNFCe> Members
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

        public TList_LoteNFCe()
        { }

        public TList_LoteNFCe(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteNFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteNFCe x, TRegistro_LoteNFCe y)
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

    public class TRegistro_LoteNFCe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
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
        public decimal? Nr_protocololote
        { get; set; }
        private DateTime? dt_recebimento;
        public DateTime? Dt_recebimento
        {
            get { return dt_recebimento; }
            set
            {
                dt_recebimento = value;
                dt_recebimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_recebimentostr;
        public string Dt_recebimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_recebimentostr).ToString("dd/MM/yyyy");
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
        public decimal? Tempomedio
        { get; set; }
        public decimal? Status
        { get; set; }
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
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_registro = "ABERTO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status_registro = "ENVIADO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status_registro = "PROCESSADO";
            }
        }
        private string status_registro;
        public string Status_registro
        {
            get { return status_registro; }
            set
            {
                status_registro = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("ENVIADO"))
                    st_registro = "E";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        public TList_Lote_X_NFCe lLoteNCFe
        { get; set; }

        public TRegistro_LoteNFCe()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_lote = null;
            id_lotestr = string.Empty;
            Nr_protocololote = null;
            dt_recebimento = null;
            dt_recebimentostr = string.Empty;
            Tempomedio = null;
            Status = null;
            Ds_mensagem = string.Empty;
            tp_ambiente = string.Empty;
            tipo_ambiente = string.Empty;
            st_registro = string.Empty;
            status_registro = string.Empty;
            lLoteNCFe = new TList_Lote_X_NFCe();
        }
    }

    public class TCD_LoteNFCe : TDataQuery
    {
        public TCD_LoteNFCe() { }

        public TCD_LoteNFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Lote, a.NR_ProtocoloLote, a.DT_Recebimento, ");
                sql.AppendLine("a.TempoMedio, a.Status, a.DS_Mensagem, ");
                sql.AppendLine("a.TP_Ambiente, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_LoteNFCe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

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

        public TList_LoteNFCe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LoteNFCe lista = new TList_LoteNFCe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LoteNFCe reg = new TRegistro_LoteNFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ProtocoloLote")))
                        reg.Nr_protocololote = reader.GetDecimal(reader.GetOrdinal("NR_ProtocoloLote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Recebimento")))
                        reg.Dt_recebimento = reader.GetDateTime(reader.GetOrdinal("DT_Recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TempoMedio")))
                        reg.Tempomedio = reader.GetDecimal(reader.GetOrdinal("TempoMedio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("Status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("DS_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("Tp_Ambiente"));

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

        public string Gravar(TRegistro_LoteNFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_NR_PROTOCOLOLOTE", val.Nr_protocololote);
            hs.Add("@P_DT_RECEBIMENTO", val.Dt_recebimento);
            hs.Add("@P_TEMPOMEDIO", val.Tempomedio);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_LOTENFCE", hs);
        }

        public string Excluir(TRegistro_LoteNFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return executarProc("EXCLUI_FAT_LOTENFCE", hs);
        }
    }
}
