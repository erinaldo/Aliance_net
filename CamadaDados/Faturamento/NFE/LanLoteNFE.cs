using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.NFE
{
    public class TList_LanLoteNFE : List<TRegistro_LanLoteNFE>, IComparer<TRegistro_LanLoteNFE>
    {
        #region IComparer<TRegistro_LanLoteNFE> Members
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

        public TList_LanLoteNFE()
        { }

        public TList_LanLoteNFE(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanLoteNFE value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanLoteNFE x, TRegistro_LanLoteNFE y)
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
    
    public class TRegistro_LanLoteNFE
    {
        public decimal Id_lote
        { get; set; }
        public decimal Loteretorno
        { get; set; }
        private DateTime? dt_recebimento;
        public DateTime? Dt_recebimento
        {
            get { return dt_recebimento; }
            set 
            { 
                dt_recebimento = value;
                dt_recebimentostring = (value.HasValue ? value.ToString() : string.Empty);
            }
        }
        private string dt_recebimentostring;
        public string Dt_recebimentostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_recebimentostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set 
            { 
                dt_recebimentostring = value;
                try
                {
                    dt_recebimento = Convert.ToDateTime(value);
                }
                catch
                { dt_recebimento = null; }
            }
        }
        public decimal Tempomedio
        { get; set; }
        public decimal Status
        { get; set; }
        public string Ds_mensagem
        { get; set; }
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
        public string Tp_emissaonfe
        { get; set; }
        public string Tipo_emissaonfe
        {
            get
            {
                if (Tp_emissaonfe.Trim().ToUpper().Equals("1"))
                    return "NORMAL";
                else if (Tp_emissaonfe.Trim().ToUpper().Equals("6"))
                    return "CONTINGÊNCIA SVC-AN";
                else if (Tp_emissaonfe.Trim().ToUpper().Equals("7"))
                    return "CONTINGÊNCIA SVC-RS";
                else return string.Empty;
            }
        }
        public TList_LanLoteNFE_X_NotaFiscal lNfe
        { get; set; }

        public TRegistro_LanLoteNFE()
        {
            Id_lote = decimal.Zero;
            Loteretorno = decimal.Zero;
            dt_recebimento = null;
            dt_recebimentostring = string.Empty;
            Tempomedio = decimal.Zero;
            St_registro = string.Empty;
            status_registro = string.Empty;
            Status = decimal.Zero;
            Ds_mensagem = string.Empty;
            Tp_emissaonfe = string.Empty;
            lNfe = new TList_LanLoteNFE_X_NotaFiscal();
        }
    }

    public class TCD_LanLoteNFE : TDataQuery
    {
        public TCD_LanLoteNFE()
        { }

        public TCD_LanLoteNFE(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Lote, a.LoteRetorno, a.DT_Recebimento, ");
                sql.AppendLine("a.TempoMedio, a.ST_Registro, a.Status, a.tp_emissaoNFe, ");
                sql.AppendLine("a.DS_Mensagem, a.Tp_Ambiente ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_LoteNFE a ");

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

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanLoteNFE Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanLoteNFE lista = new TList_LanLoteNFE();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanLoteNFE reg = new TRegistro_LanLoteNFE();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoteRetorno")))
                        reg.Loteretorno = reader.GetDecimal(reader.GetOrdinal("LoteRetorno"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_EmissaoNFe")))
                        reg.Tp_emissaonfe = reader.GetString(reader.GetOrdinal("TP_EmissaoNFe"));

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

        public string Gravar(TRegistro_LanLoteNFE val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_LOTERETORNO", val.Loteretorno);
            hs.Add("@P_DT_RECEBIMENTO", val.Dt_recebimento);
            hs.Add("@P_TEMPOMEDIO", val.Tempomedio);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_TP_EMISSAONFE", val.Tp_emissaonfe);

            return executarProc("IA_FAT_LOTENFE", hs);
        }

        public string Excluir(TRegistro_LanLoteNFE val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return executarProc("EXCLUI_FAT_LOTENFE", hs);
        }
    }
}
