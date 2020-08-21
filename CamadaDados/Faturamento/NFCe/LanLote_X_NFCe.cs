using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.NFCe
{
    public class TList_Lote_X_NFCe : List<TRegistro_Lote_X_NFCe>, IComparer<TRegistro_Lote_X_NFCe>
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

        public TList_Lote_X_NFCe()
        { }

        public TList_Lote_X_NFCe(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lote_X_NFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lote_X_NFCe x, TRegistro_Lote_X_NFCe y)
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

    public class TRegistro_Lote_X_NFCe
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
                catch { id_cupom = null; }
            }
        }
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
        public decimal? Nr_protocolo
        { get; set; }
        public string Digval
        { get; set; }
        public decimal? Status
        { get; set; }
        public string Ds_mensagem
        { get; set; }
        public string Veraplic
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public decimal? Id_coo_ecf
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public string St_registro
        {get; set;}
        public string Status_nfce
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
        public string Chave_acesso
        { get; set; }
        public string Cd_versao
        { get; set; }
        public string Tp_ambiente
        { get; set; }

        public TRegistro_Lote_X_NFCe()
        {
            Cd_empresa = string.Empty;
            id_lote = null;
            id_lotestr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            dt_processamento = null;
            dt_processamentostr = string.Empty;
            Nr_protocolo = null;
            Digval = string.Empty;
            Status = null;
            Ds_mensagem = string.Empty;
            Veraplic = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Dt_emissao = null;
            Id_coo_ecf = null;
            Nr_serie = string.Empty;
            Cd_modelo = string.Empty;
            Vl_cupom = decimal.Zero;
            St_registro = string.Empty;
            Chave_acesso = string.Empty;
            Cd_versao = string.Empty;
            Tp_ambiente = string.Empty;
        }
    }

    public class TCD_Lote_X_NFCe : TDataQuery
    {
        public TCD_Lote_X_NFCe() { }

        public TCD_Lote_X_NFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, a.ID_Lote, a.Id_Cupom, ");
                sql.AppendLine("a.DT_Processamento, a.NR_Protocolo, a.DigVal, a.CD_Versao, ");
                sql.AppendLine("a.Status, a.DS_Mensagem, a.VerAplic, b.st_registro, c.tp_ambiente, ");
                sql.AppendLine("b.cd_clifor, b.nm_clifor, b.dt_emissao, b.chave_acesso, ");
                sql.AppendLine("b.nr_nfce, b.nr_serie, b.cd_modelo, b.vl_cupom ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Lote_X_NFCe a ");
            sql.AppendLine("inner join VTB_PDV_NFCe b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_cupom = b.id_nfce ");
            sql.AppendLine("inner join TB_FAT_LoteNFCe c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.id_lote = c.id_lote ");

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

        public TList_Lote_X_NFCe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lote_X_NFCe lista = new TList_Lote_X_NFCe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Lote_X_NFCe reg = new TRegistro_Lote_X_NFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("ID_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigVal")))
                        reg.Digval = reader.GetString(reader.GetOrdinal("DigVal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("Status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("DS_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VerAplic")))
                        reg.Veraplic = reader.GetString(reader.GetOrdinal("VerAplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nfce")))
                        reg.Id_coo_ecf = reader.GetDecimal(reader.GetOrdinal("nr_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_acesso")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("chave_acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versao")))
                        reg.Cd_versao = reader.GetString(reader.GetOrdinal("cd_versao"));
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
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Lote_X_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_processamento);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_DIGVAL", val.Digval);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_VERAPLIC", val.Veraplic);
            hs.Add("@P_CD_VERSAO", val.Cd_versao);

            return executarProc("IA_FAT_LOTE_X_NFCE", hs);
        }

        public string Excluir(TRegistro_Lote_X_NFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return executarProc("EXCLUI_FAT_LOTE_X_NFCE", hs);
        }
    }
}
