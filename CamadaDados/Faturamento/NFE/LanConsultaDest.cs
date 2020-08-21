using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.NFE
{
    public class TList_ConsultaDest : List<TRegistro_ConsultaDest>, IComparer<TRegistro_ConsultaDest>
    {
        #region IComparer<TRegistro_ConsultaDest> Members
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

        public TList_ConsultaDest()
        { }

        public TList_ConsultaDest(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ConsultaDest value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ConsultaDest x, TRegistro_ConsultaDest y)
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

    public class TRegistro_ConsultaDest
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_consulta;
        public decimal? Id_consulta
        {
            get { return id_consulta; }
            set
            {
                id_consulta = value;
                id_consultastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_consultastr;
        public string Id_consultastr
        {
            get { return id_consultastr; }
            set
            {
                id_consultastr = value;
                try
                {
                    id_consulta = decimal.Parse(value);
                }
                catch { id_consulta = null; }
            }
        }
        public string Loginconsulta
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
                }catch { nr_lanctofiscal = null; }
            }
        }
        public decimal? Nr_notafiscal { get; set; }
        private DateTime? dt_consulta;
        public DateTime? Dt_consulta
        {
            get { return dt_consulta; }
            set
            {
                dt_consulta = value;
                dt_consultastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_consultastr;
        public string Dt_consultastr
        {
            get { return dt_consultastr; }
            set
            {
                dt_consultastr = value;
                try
                {
                    dt_consulta = DateTime.Parse(value);
                }
                catch { dt_consulta = null; }
            }
        }
        public decimal? Nsu
        { get; set; }
        public string chave_acesso
        { get; set; }
        public string Cnpj_emitente
        { get; set; }
        public string Nm_emitente
        { get; set; }
        public string Insc_Emitente
        { get; set; }
        public string digVal
        { get; set; }
        private DateTime? dh_recbto;
        public DateTime? Dh_recbto
        {
            get { return dh_recbto; }
            set
            {
                dh_recbto = value;
                dh_recbtostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dh_recbtostr;
        public string Dh_recbtostr
        {
            get { return dh_recbtostr; }
            set
            {
                dh_recbtostr = value;
                try
                {
                    dh_recbto = DateTime.Parse(value);
                }
                catch { dh_recbto = null; }
            }
        }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        public string XML_NFe
        { get; set; }
        public decimal Vl_nfe
        { get; set; }
        public string St_nfe
        { get; set; }
        public string Status_nfe
        {
            get
            {
                if (St_nfe.Trim().Equals("1"))
                    return "AUTORIZADA";
                else if (St_nfe.Trim().Equals("2"))
                    return "DENEGADA";
                else if (St_nfe.Trim().Equals("3"))
                    return "CANCELADA";
                else return string.Empty;
            }
        }
        public string Sitconf
        { get; set; }
        public string Situacaoconf
        {
            get
            {
                if (Sitconf.Trim().Equals("0"))
                    return "SEM MANIFESTAÇÃO";
                else if (Sitconf.Trim().Equals("1"))
                    return "CONFIRMADA OPERAÇÃO";
                else if (Sitconf.Trim().Equals("2"))
                    return "DESCONHECIDA";
                else if (Sitconf.Trim().Equals("3"))
                    return "OPERAÇÃO NÃO REALIZADA";
                else if (Sitconf.Trim().Equals("4"))
                    return "CIÊNCIA OPERAÇÃO";
                else return string.Empty;
            }
        }
        public string Ds_correcao
        { get; set; }
        public string Tp_registro
        { get; set; }
        public string Tipo_registro
        {
            get
            {
                if (Tp_registro.Trim().Equals("1"))
                    return "NFe";
                else if (Tp_registro.Trim().Equals("2"))
                    return "CANCELAMENTO";
                else if (Tp_registro.Trim().Equals("3"))
                    return "CARTA CORREÇÃO";
                else return string.Empty;
            }
        }
        private DateTime? dt_eminfe;
        public DateTime? Dt_eminfe
        {
            get { return dt_eminfe; }
            set
            {
                dt_eminfe = value;
                dt_eminfestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eminfestr;
        public string Dt_eminfestr
        {
            get { return dt_eminfestr; }
            set
            {
                dt_eminfestr = value;
                try
                {
                    dt_eminfe = DateTime.Parse(value);
                }
                catch { dt_eminfe = null; }
            }
        }
        public decimal? nProt { get; set; }

        public TRegistro_ConsultaDest()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_consulta = null;
            id_consultastr = string.Empty;
            Loginconsulta = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            dt_consulta = null;
            dt_consultastr = string.Empty;
            Nsu = null;
            chave_acesso = string.Empty;
            Cnpj_emitente = string.Empty;
            Nm_emitente = string.Empty;
            Vl_nfe = decimal.Zero;
            St_nfe = string.Empty;
            Sitconf = string.Empty;
            Ds_correcao = string.Empty;
            Tp_registro = string.Empty;
            Insc_Emitente = string.Empty;
            digVal = string.Empty;
            dh_recbto = null;
            dh_recbtostr = string.Empty;
            tp_movimento = string.Empty;
            XML_NFe = string.Empty;
            dt_eminfe = null;
            dt_eminfestr = string.Empty;
            nProt = null;
        }
    }

    public class TCD_ConsultaDest : TDataQuery
    {
        public TCD_ConsultaDest() { }

        public TCD_ConsultaDest(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_consulta, a.loginconsulta, a.dt_consulta, ");
                sql.AppendLine("a.nsu, a.chave_acesso, a.cnpj_emitente, a.nm_emitente, a.nProt, ");
                sql.AppendLine("a.Insc_Emitente, a.digVal, a.dhRecbto, a.TP_NFe, a.XML_NFe, ");
                sql.AppendLine("a.vl_nfe, a.st_nfe, a.sitconf, a.ds_correcao, a.tp_registro, a.DT_EmiNFe, ");
                sql.AppendLine("c.nr_lanctofiscal, c.nr_notafiscal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ConsultaDest a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FAT_NotaFiscal c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.chave_acesso = c.chave_acesso_nfe ");

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

        public TList_ConsultaDest Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ConsultaDest lista = new TList_ConsultaDest();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ConsultaDest reg = new TRegistro_ConsultaDest();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_consulta")))
                        reg.Id_consulta = reader.GetDecimal(reader.GetOrdinal("id_consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginconsulta")))
                        reg.Loginconsulta = reader.GetString(reader.GetOrdinal("loginconsulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_consulta")))
                        reg.Dt_consulta = reader.GetDateTime(reader.GetOrdinal("dt_consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nsu")))
                        reg.Nsu = reader.GetDecimal(reader.GetOrdinal("nsu"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_acesso")))
                        reg.chave_acesso = reader.GetString(reader.GetOrdinal("chave_acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_emitente")))
                        reg.Cnpj_emitente = reader.GetString(reader.GetOrdinal("cnpj_emitente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_emitente")))
                        reg.Nm_emitente = reader.GetString(reader.GetOrdinal("nm_emitente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_nfe")))
                        reg.Vl_nfe = reader.GetDecimal(reader.GetOrdinal("vl_nfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_nfe")))
                        reg.St_nfe = reader.GetString(reader.GetOrdinal("st_nfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sitconf")))
                        reg.Sitconf = reader.GetString(reader.GetOrdinal("sitconf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_correcao")))
                        reg.Ds_correcao = reader.GetString(reader.GetOrdinal("ds_correcao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Emitente")))
                        reg.Insc_Emitente = reader.GetString(reader.GetOrdinal("Insc_Emitente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("digVal")))
                        reg.digVal = reader.GetString(reader.GetOrdinal("digVal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dhRecbto")))
                        reg.Dh_recbto = reader.GetDateTime(reader.GetOrdinal("dhRecbto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_NFe")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_NFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("XML_NFe")))
                        reg.XML_NFe = reader.GetString(reader.GetOrdinal("XML_NFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EmiNFe")))
                        reg.Dt_eminfe = reader.GetDateTime(reader.GetOrdinal("DT_EmiNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nProt")))
                        reg.nProt = reader.GetDecimal(reader.GetOrdinal("nProt"));

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

        public string Gravar(TRegistro_ConsultaDest val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(20);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONSULTA", val.Id_consulta);
            hs.Add("@P_LOGINCONSULTA", val.Loginconsulta);
            hs.Add("@P_DT_CONSULTA", val.Dt_consulta);
            hs.Add("@P_NSU", val.Nsu);
            hs.Add("@P_CHAVE_ACESSO", val.chave_acesso);
            hs.Add("@P_CNPJ_EMITENTE", val.Cnpj_emitente);
            hs.Add("@P_NM_EMITENTE", val.Nm_emitente);
            hs.Add("@P_INSC_EMITENTE", val.Insc_Emitente);
            hs.Add("@P_VL_NFE", val.Vl_nfe);
            hs.Add("@P_ST_NFE", val.St_nfe);
            hs.Add("@P_SITCONF", val.Sitconf);
            hs.Add("@P_DS_CORRECAO", val.Ds_correcao);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_DIGVAL", val.digVal);
            hs.Add("@P_DHRECBTO", val.Dh_recbto);
            hs.Add("@P_TP_NFE", val.Tp_movimento);
            hs.Add("@P_XML_NFE", val.XML_NFe);
            hs.Add("@P_DT_EMINFE", val.Dt_eminfe);
            hs.Add("@P_NPROT", val.nProt);

            return executarProc("IA_FAT_CONSULTADEST", hs);
        }

        public string Excluir(TRegistro_ConsultaDest val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CONSULTA", val.Id_consulta);

            return executarProc("EXCLUI_FAT_CONSULTADEST", hs);
        }
    }
}
