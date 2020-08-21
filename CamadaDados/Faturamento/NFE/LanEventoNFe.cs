using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.NFE
{
    public class TList_EventoNFe : List<TRegistro_EventoNFe>, IComparer<TRegistro_EventoNFe>
    {
        #region IComparer<TRegistro_EventoNFe> Members
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

        public TList_EventoNFe()
        { }

        public TList_EventoNFe(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EventoNFe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EventoNFe x, TRegistro_EventoNFe y)
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

    public class TRegistro_EventoNFe
    {
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
                catch
                { id_evento = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch
                { nr_lanctofiscal = null; }
            }
        }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Chave_acesso_nfe
        { get; set; }
        public string Nr_protocoloNfe
        { get; set; }
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
                catch
                { cd_evento = null; }
            }
        }
        public string Descricao_evento
        { get; set; }
        public string Ds_evento
        { get; set; }
        public string Tp_evento
        { get; set; }
        public string Tipo_evento
        {
            get
            {
                if (Tp_evento.Trim().ToUpper().Equals("CC"))
                    return "CARTA CORREÇÃO";
                else if (Tp_evento.Trim().ToUpper().Equals("CA"))
                    return "CANCELAMENTO";
                else if (Tp_evento.Trim().ToUpper().Equals("MF"))
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
                catch
                { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch
                { dt_evento = null; }
            }
        }
        public decimal? Nr_protocolo
        { get; set; }
        public string Xml_evento
        { get; set; }
        public string Xml_retevento
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

        public TRegistro_EventoNFe()
        {
            id_evento = null;
            id_eventostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            Nr_notafiscal = null;
            Nr_serie = string.Empty;
            Chave_acesso_nfe = string.Empty;
            Nr_protocoloNfe = string.Empty;
            dt_evento = null;
            dt_eventostr = string.Empty;
            cd_evento = null;
            cd_eventostr = string.Empty;
            Descricao_evento = string.Empty;
            Ds_evento = string.Empty;
            Nr_protocolo = null;
            Xml_evento = string.Empty;
            Xml_retevento = string.Empty;
            Tp_evento = string.Empty;
            St_registro = string.Empty;
        }
    }

    public class TCD_EventoNFe : TDataQuery
    {
        public TCD_EventoNFe()
        { }

        public TCD_EventoNFe(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_evento, a.cd_empresa, a.xml_retevento, ");
                sql.AppendLine("b.nm_empresa, a.nr_lanctofiscal, a.cd_evento, a.dt_evento, c.nr_serie, ");
                sql.AppendLine("c.nr_notafiscal, isnull(a.chave_acesso, c.chave_acesso_nfe) as chave_acesso_nfe, c.Nr_protocolo as Nr_protocoloNfe, a.xml_evento, ");
                sql.AppendLine("a.ds_evento, a.nr_protocolo, d.tp_evento, d.ds_evento as descricao_evento, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_EventoNFe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join VTB_FAT_NotaFiscal c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = c.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FAT_Evento d ");
            sql.AppendLine("on a.cd_evento = d.cd_evento ");

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

        public TList_EventoNFe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_EventoNFe lista = new TList_EventoNFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_EventoNFe reg = new TRegistro_EventoNFe();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_evento")))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("id_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_acesso_nfe")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("chave_acesso_nfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_protocoloNfe")))
                        reg.Nr_protocoloNfe = reader.GetString(reader.GetOrdinal("Nr_protocoloNfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_evento")))
                        reg.Cd_evento = reader.GetDecimal(reader.GetOrdinal("cd_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("descricao_evento")))
                        reg.Descricao_evento = reader.GetString(reader.GetOrdinal("descricao_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("dt_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_evento")))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("ds_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("nr_protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("tp_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_evento")))
                        reg.Xml_evento = reader.GetString(reader.GetOrdinal("xml_evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_retevento")))
                        reg.Xml_retevento = reader.GetString(reader.GetOrdinal("xml_retevento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_EventoNFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);
            hs.Add("@P_DS_EVENTO", val.Ds_evento);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_XML_EVENTO", val.Xml_evento);
            hs.Add("@P_XML_RETEVENTO", val.Xml_retevento);
            hs.Add("@P_CHAVE_ACESSO", val.Chave_acesso_nfe);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_EVENTONFE", hs);
        }

        public string Excluir(TRegistro_EventoNFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_EVENTO", val.Id_evento);

            return executarProc("EXCLUI_FAT_EVENTONFE", hs);
        }
    }
}
