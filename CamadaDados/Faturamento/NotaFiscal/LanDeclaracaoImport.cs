using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_DeclaracaoImport : List<TRegistro_DeclaracaoImport>, IComparer<TRegistro_DeclaracaoImport>
    {
        #region IComparer<TRegistro_DeclaracaoImport> Members
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

        public TList_DeclaracaoImport()
        { }

        public TList_DeclaracaoImport(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DeclaracaoImport value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DeclaracaoImport x, TRegistro_DeclaracaoImport y)
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

    public class TRegistro_DeclaracaoImport
    {
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
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }
        private decimal? id_di;
        public decimal? Id_di
        {
            get { return id_di; }
            set
            {
                id_di = value;
                id_distr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_distr;
        public string Id_distr
        {
            get { return id_distr; }
            set
            {
                id_distr = value;
                try
                {
                    id_di = decimal.Parse(value);
                }
                catch { id_di = null; }
            }
        }
        public string Cd_ufdesemb
        { get; set; }
        public string Ds_ufdesemb
        { get; set; }
        public string Sg_ufdesemb
        { get; set; }
        public string Nr_di
        { get; set; }
        private DateTime? dt_di;
        public DateTime? Dt_di
        {
            get { return dt_di; }
            set
            {
                dt_di = value;
                dt_distr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_distr;
        public string Dt_distr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_distr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_distr = value;
                try
                {
                    dt_di = DateTime.Parse(value);
                }
                catch { dt_di = null; }
            }
        }
        public string xLocDesemb
        { get; set; }
        private DateTime? dt_desemb;
        public DateTime? Dt_desemb
        {
            get { return dt_desemb; }
            set
            {
                dt_desemb = value;
                dt_desembstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_desembstr;
        public string Dt_desembstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_desembstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_desembstr = value;
                try
                {
                    dt_desemb = DateTime.Parse(value);
                }
                catch { dt_desemb = null; }
            }
        }
        private string tp_viatransp;
        public string Tp_viatransp
        {
            get { return tp_viatransp; }
            set
            {
                tp_viatransp = value;
                if (value.Trim().Equals("1"))
                    tipo_viatransp = "MARITIMA";
                else if (value.Trim().Equals("2"))
                    tipo_viatransp = "FLUVIAL";
                else if (value.Trim().Equals("3"))
                    tipo_viatransp = "LACUSTRE";
                else if (value.Trim().Equals("4"))
                    tipo_viatransp = "AEREA";
                else if (value.Trim().Equals("5"))
                    tipo_viatransp = "POSTAL";
                else if (value.Trim().Equals("6"))
                    tipo_viatransp = "FERROVIARIA";
                else if (value.Trim().Equals("7"))
                    tipo_viatransp = "RODOVIARIA";
                else if (value.Trim().Equals("8"))
                    tipo_viatransp = "CONDUTO/REDE TRANSMISSAO";
                else if (value.Trim().Equals("9"))
                    tipo_viatransp = "MEIOS PROPRIOS";
                else if (value.Trim().Equals("10"))
                    tipo_viatransp = "ENTRADA/SAIDA FICTA";
                else if (value.Trim().Equals("11"))
                    tipo_viatransp = "COURIER";
                else if (value.Trim().Equals("12"))
                    tipo_viatransp = "HANDCARRY";
            }
        }
        private string tipo_viatransp;
        public string Tipo_viatransp
        {
            get { return tipo_viatransp; }
            set
            {
                tipo_viatransp = value;
                if (value.Trim().Equals("MARITIMA"))
                    tp_viatransp = "1";
                else if (value.Trim().Equals("FLUVIAL"))
                    tp_viatransp = "2";
                else if (value.Trim().Equals("LACUSTRE"))
                    tp_viatransp = "3";
                else if (value.Trim().Equals("AEREA"))
                    tp_viatransp = "4";
                else if (value.Trim().Equals("POSTAL"))
                    tp_viatransp = "5";
                else if (value.Trim().Equals("FERROVIARIA"))
                    tp_viatransp = "6";
                else if (value.Trim().Equals("RODOVIARIA"))
                    tp_viatransp = "7";
                else if (value.Trim().Equals("CONDUTO/REDE TRANSMISSAO"))
                    tp_viatransp = "8";
                else if (value.Trim().Equals("MEIOS PROPRIOS"))
                    tp_viatransp = "9";
                else if (value.Trim().Equals("ENTRADA/SAIDA FICTA"))
                    tp_viatransp = "10";
                else if (value.Trim().Equals("COURIER"))
                    tp_viatransp = "11";
                else if (value.Trim().Equals("HANDCARRY"))
                    tp_viatransp = "12";
            }
        }
        public decimal Vl_AFRMM
        { get; set; }
        private string tp_intermedio;
        public string Tp_intermedio
        {
            get { return tp_intermedio; }
            set
            {
                tp_intermedio = value;
                if (value.Trim().Equals("1"))
                    tipo_intermedio = "IMPORTACAO POR CONTA PROPRIA";
                else if (value.Trim().Equals("2"))
                    tipo_intermedio = "IMPORTACAO POR CONTA E ORDEM";
                else if (value.Trim().Equals("3"))
                    tipo_intermedio = "IMPORTACAO POR ENCOMENDA";
            }
        }
        private string tipo_intermedio;
        public string Tipo_intermedio
        {
            get { return tipo_intermedio; }
            set
            {
                tipo_intermedio = value;
                if (value.Trim().Equals("IMPORTACAO POR CONTA PROPRIA"))
                    tp_intermedio = "1";
                else if (value.Trim().Equals("IMPORTACAO POR CONTA E ORDEM"))
                    tp_intermedio = "2";
                else if (value.Trim().Equals("IMPORTACAO POR ENCOMENDA"))
                    tp_intermedio = "3";
            }
        }
        public string Nr_adicao
        { get; set; }
        public string nSeqAdic
        { get; set; }

        public TRegistro_DeclaracaoImport()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.id_di = null;
            this.id_distr = string.Empty;
            this.Cd_ufdesemb = string.Empty;
            this.Ds_ufdesemb = string.Empty;
            this.Sg_ufdesemb = string.Empty;
            this.Nr_di = string.Empty;
            this.dt_di = null;
            this.dt_distr = string.Empty;
            this.xLocDesemb = string.Empty;
            this.dt_desemb = null;
            this.dt_desembstr = string.Empty;
            this.tp_viatransp = string.Empty;
            this.tipo_intermedio = string.Empty;
            this.Vl_AFRMM = decimal.Zero;
            this.tp_intermedio = string.Empty;
            this.tipo_intermedio = string.Empty;
            this.Nr_adicao = string.Empty;
            this.nSeqAdic = string.Empty;
        }
    }

    public class TCD_DeclaracaoImport : TDataQuery
    {
        public TCD_DeclaracaoImport() { }

        public TCD_DeclaracaoImport(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.NR_LanctoFiscal, a.ID_NFItem, a.ID_DI, a.CD_UFDesemb, ");
                sql.AppendLine("c.ds_uf as DS_UFDesemb, c.uf as SG_UFDesemb, a.NR_DI, ");
                sql.AppendLine("a.DT_DI, a.xLocDesemb, a.DT_Desemb, a.TP_ViaTransp, ");
                sql.AppendLine("a.Vl_AFRMM, a.TP_Intermedio, a.NR_Adicao, a.nSeqAdic ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_DeclaracaoImport a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_UF c ");
            sql.AppendLine("On a.CD_UFDesemb = c.CD_UF ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_DeclaracaoImport Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = null;
            TList_DeclaracaoImport lista = new TList_DeclaracaoImport();
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_DeclaracaoImport reg = new TRegistro_DeclaracaoImport();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DI")))
                        reg.Id_di = reader.GetDecimal(reader.GetOrdinal("ID_DI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFDesemb")))
                        reg.Cd_ufdesemb = reader.GetString(reader.GetOrdinal("CD_UFDesemb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UFDesemb")))
                        reg.Ds_ufdesemb = reader.GetString(reader.GetOrdinal("DS_UFDesemb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_UFDesemb")))
                        reg.Sg_ufdesemb = reader.GetString(reader.GetOrdinal("SG_UFDesemb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DI")))
                        reg.Nr_di = reader.GetString(reader.GetOrdinal("NR_DI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_DI")))
                        reg.Dt_di = reader.GetDateTime(reader.GetOrdinal("DT_DI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xLocDesemb")))
                        reg.xLocDesemb = reader.GetString(reader.GetOrdinal("xLocDesemb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Desemb")))
                        reg.Dt_desemb = reader.GetDateTime(reader.GetOrdinal("DT_Desemb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ViaTransp")))
                        reg.Tp_viatransp = reader.GetString(reader.GetOrdinal("TP_ViaTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_AFRMM")))
                        reg.Vl_AFRMM = reader.GetDecimal(reader.GetOrdinal("Vl_AFRMM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Intermedio")))
                        reg.Tp_intermedio = reader.GetString(reader.GetOrdinal("TP_Intermedio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Adicao")))
                        reg.Nr_adicao = reader.GetString(reader.GetOrdinal("NR_Adicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nSeqAdic")))
                        reg.nSeqAdic = reader.GetString(reader.GetOrdinal("nSeqAdic"));

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

        public string Gravar(TRegistro_DeclaracaoImport val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_DI", val.Id_di);
            hs.Add("@P_CD_UFDESEMB", val.Cd_ufdesemb);
            hs.Add("@P_NR_DI", val.Nr_di);
            hs.Add("@P_DT_DI", val.Dt_di);
            hs.Add("@P_XLOCDESEMB", val.xLocDesemb);
            hs.Add("@P_DT_DESEMB", val.Dt_desemb);
            hs.Add("@P_TP_VIATRANSP", val.Tp_viatransp);
            hs.Add("@P_VL_AFRMM", val.Vl_AFRMM);
            hs.Add("@P_TP_INTERMEDIO", val.Tp_intermedio);
            hs.Add("@P_NR_ADICAO", val.Nr_adicao);
            hs.Add("@P_NSEQADIC", val.nSeqAdic);

            return this.executarProc("IA_FAT_DECLARACAOIMPORT", hs);
        }

        public string Excluir(TRegistro_DeclaracaoImport val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFItem", val.Id_nfitem);
            hs.Add("@P_ID_DI", val.Id_di);

            return this.executarProc("EXCLUI_FAT_DECLARACAOIMPORT", hs);
        }


    }
}
