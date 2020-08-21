using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_EventoNFCe : List<TRegistro_EventoNFCe>, IComparer<TRegistro_EventoNFCe>
    {
        #region IComparer<TRegistro_EventoNFCe> Members
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

        public TList_EventoNFCe()
        { }

        public TList_EventoNFCe(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EventoNFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EventoNFCe x, TRegistro_EventoNFCe y)
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

    public class TRegistro_EventoNFCe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
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
        public string Chave_acesso_nfce
        { get; set; }
        public decimal? Nr_nfce
        { get; set; }
        private decimal? id_evento;
        public decimal? Id_evento
        {
            get { return id_evento; }
            set
            {
                id_evento = value;
                id_eventostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_eventostr;
        public string Id_eventostr
        {
            get { return id_eventostr; }
            set
            {
                id_eventostr = value;
                try
                {
                    id_evento = decimal.Parse(value);
                }
                catch { id_evento = null; }
            }
        }
        private decimal? cd_evento;
        public decimal? Cd_evento
        {
            get { return cd_evento; }
            set
            {
                cd_evento = value;
                cd_eventostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_eventostr;
        public string Cd_eventostr
        {
            get { return cd_eventostr; }
            set
            {
                cd_eventostr = value;
                try
                {
                    cd_evento = decimal.Parse(value);
                }
                catch { cd_evento = null; }
            }
        }
        public string Ds_evento
        { get; set; }
        public string Tp_evento
        { get; set; }
        public string Tipo_evento
        {
            get
            {
                if(this.Tp_evento.Trim().ToUpper().Equals("CC"))
                    return "CARTA CORREÇÃO";
                else if(this.Tp_evento.Trim().ToUpper().Equals("CA"))
                    return "CANCELAMENTO";
                else if(this.Tp_evento.Trim().ToUpper().Equals("MF"))
                    return "MANIFESTO";
                else return string.Empty;
            }
        }
        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_eventostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch { dt_evento = null; }
            }
        }
        public string Justificativa
        { get; set; }
        public decimal? Nr_protocolo
        { get; set; }
        public string Xml_evento
        { get; set; }
        public string Xml_retevento
        { get; set; }
        public decimal? Nr_protocoloNFCe
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("T"))
                    return "TRANSMITIDO";
                else return string.Empty;
            }
        }

        public TRegistro_EventoNFCe()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
            this.id_evento = null;
            this.id_eventostr = string.Empty;
            this.cd_evento = null;
            this.cd_eventostr = string.Empty;
            this.Ds_evento = string.Empty;
            this.Tp_evento = string.Empty;
            this.dt_evento = null;
            this.dt_eventostr = string.Empty;
            this.Justificativa = string.Empty;
            this.Nr_protocolo = null;
            this.Xml_evento = string.Empty;
            this.Xml_retevento = string.Empty;
            this.Nr_protocoloNFCe = null;
            this.Chave_acesso_nfce = string.Empty;
            this.Nr_nfce = null;
            this.St_registro = "A";
        }
    }

    public class TCD_EventoNFCe : TDataQuery
    {
        public TCD_EventoNFCe() { }

        public TCD_EventoNFCe(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.Id_Cupom, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Evento, a.CD_Evento, c.DS_Evento, c.TP_Evento, d.chave_acesso, d.NR_NFCE, ");
                sql.AppendLine("a.DT_Evento, a.Justificativa, a.NR_Protocolo, e.NR_Protocolo as NR_ProtocoloNFCe, ");
                sql.AppendLine("a.XML_Evento, a.XML_RetEvento, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_EventoNFCe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FAT_Evento c ");
            sql.AppendLine("on a.CD_Evento = c.CD_Evento ");
            sql.AppendLine("inner join TB_PDV_NFCe d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.id_cupom = d.id_nfce ");
            sql.AppendLine("left outer join TB_FAT_Lote_X_NFCe e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.id_cupom = e.id_cupom ");

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

        public TList_EventoNFCe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_EventoNFCe lista = new TList_EventoNFCe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_EventoNFCe reg = new TRegistro_EventoNFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_acesso")))
                        reg.Chave_acesso_nfce = reader.GetString(reader.GetOrdinal("chave_acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nfce")))
                        reg.Nr_nfce = reader.GetDecimal(reader.GetOrdinal("nr_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Evento")))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("ID_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Evento")))
                        reg.Cd_evento = reader.GetDecimal(reader.GetOrdinal("CD_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Evento")))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("DS_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("TP_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("DT_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Justificativa")))
                        reg.Justificativa = reader.GetString(reader.GetOrdinal("Justificativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("XML_Evento")))
                        reg.Xml_evento = reader.GetString(reader.GetOrdinal("XML_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("XML_RetEvento")))
                        reg.Xml_retevento = reader.GetString(reader.GetOrdinal("XML_RetEvento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ProtocoloNFCe")))
                        reg.Nr_protocoloNFCe = reader.GetDecimal(reader.GetOrdinal("NR_ProtocoloNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_EventoNFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);
            hs.Add("@P_JUSTIFICATIVA", val.Justificativa);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_XML_EVENTO", val.Xml_evento);
            hs.Add("@P_XML_RETEVENTO", val.Xml_retevento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_EVENTONFCE", hs);
        }

        public string Excluir(TRegistro_EventoNFCe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVENTO", val.Id_evento);

            return this.executarProc("EXCLUI_PDV_EVENTONFCE", hs);
        }
    }
}
