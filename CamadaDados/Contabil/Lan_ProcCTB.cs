using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Contabil
{
    #region Processar Caixa
    public class TList_ProcCaixa : List<TRegistro_Lan_ProcCaixa>, IComparer<TRegistro_Lan_ProcCaixa>
    {
        #region IComparer<TRegistro_Lan_ProcCaixa> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcCaixa()
        { }

        public TList_ProcCaixa(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcCaixa x, TRegistro_Lan_ProcCaixa y)
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

    public class TRegistro_Lan_ProcCaixa
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_Documento { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = decimal.Parse(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public string CD_Historico { get; set; }
        public string DS_Historico { get; set; }
        private decimal? id_lanctocaixa;
        public decimal? ID_LanctoCaixa
        {
            get { return id_lanctocaixa; }
            set
            {
                id_lanctocaixa = value;
                id_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctocaixastr;
        public string Id_lanctocaixastr
        {
            get { return id_lanctocaixastr; }
            set
            {
                id_lanctocaixastr = value;
                try
                {
                    id_lanctocaixa = decimal.Parse(value);
                }
                catch
                { id_lanctocaixa = null; }
            }
        }
        public string CD_ContaGer { get; set; }
        public string DS_ContaGer { get; set; }
        public string DS_ComplHistorico { get; set; }
        public string TP_Movimento { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (TP_Movimento.Trim().ToUpper().Equals("P"))
                    return "PAGAR";
                else if (TP_Movimento.Trim().ToUpper().Equals("R"))
                    return "RECEBER";
                else return string.Empty;
            }
        }
        public string Nm_clifor
        { get; set; }
        public string Nr_cheque
        { get; set; }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacao_deb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public string St_titulo
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcCaixa()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_Documento = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            CD_Historico = string.Empty;
            DS_Historico = string.Empty;
            id_lanctocaixa = null;
            id_lanctocaixastr = string.Empty;
            CD_ContaGer = string.Empty;
            DS_ContaGer = string.Empty;
            DS_ComplHistorico = string.Empty;
            TP_Movimento = string.Empty;
            cd_contadeb = decimal.Zero;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacao_deb = string.Empty;
            cd_contacre = null;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacao_cred = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_titulo = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cheque = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcCaixa : TDataQuery
    {
        public TCD_Lan_ProcCaixa()
        { }

        public TCD_Lan_ProcCaixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, b.NM_Empresa, a.Nr_Docto, ");
            sql.AppendLine("a.DT_Lancto, a.cd_historico, c.DS_Historico, ");
            sql.AppendLine("a.cd_lanctocaixa, a.CD_ContaGer, d.DS_ContaGer, ");
            sql.AppendLine("a.ID_LoteCTB, a.ST_Titulo, a.ComplHistorico, ");
            sql.AppendLine("a.Tp_Mov, a.Valor, a.nm_clifor, a.nr_cheque, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, e.DS_ContaCTB as ds_contacre, e.CD_Classificacao as cd_classificacaocre, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, f.DS_ContaCTB as ds_contadeb, f.CD_Classificacao as cd_classificacaodeb, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCCAIXA a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Historico c ");
            sql.AppendLine("on a.cd_historico = c.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_ContaGer d ");
            sql.AppendLine("on a.CD_ContaGer = d.CD_ContaGer ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = f.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }

            sql.AppendLine("Order by a.CD_ContaGer, FLOOR(CONVERT(FLOAT,convert(datetime, a.DT_Lancto))), a.CD_LanctoCaixa ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcCaixa Select(TpBusca[] vBusca)
        {
            TList_ProcCaixa lista = new TList_ProcCaixa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcCaixa reg = new TRegistro_Lan_ProcCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Documento = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.CD_Historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.DS_Historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.ID_LanctoCaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.CD_ContaGer = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.DS_ContaGer = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Titulo")))
                        reg.St_titulo = reader.GetString(reader.GetOrdinal("ST_Titulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ComplHistorico")))
                        reg.DS_ComplHistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Mov")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("Tp_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cheque")))
                        reg.Nr_cheque = reader.GetString(reader.GetOrdinal("nr_cheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contacre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("ds_contacre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacaocre")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("cd_classificacaocre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contadeb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("ds_contadeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacaodeb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("cd_classificacaodeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contactb_d")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("cd_contactb_d"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contactb_c")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("cd_contactb_c"));

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

        public string AtualizaLoteCaixa(TRegistro_Lan_ProcCaixa reg)
        {
            //ATUALIZA_LOTE_CAIXA
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_LOTECTB", reg.CD_LoteCTB);
            hs.Add("@P_CD_CONTAGER", reg.CD_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", reg.ID_LanctoCaixa);

            return executarProc("ATUALIZA_LOTE_CAIXA", hs);
        }
    }
    #endregion

    #region Processar Adiantamento
    public class TList_ProcAdiantamento : List<TRegistro_ProcAdiantamento>, IComparer<TRegistro_ProcAdiantamento>
    {
        #region IComparer<TRegistro_ProcAdiantamento> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcAdiantamento()
        { }

        public TList_ProcAdiantamento(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcAdiantamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcAdiantamento x, TRegistro_ProcAdiantamento y)
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

    public class TRegistro_ProcAdiantamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_adto;
        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;
        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch { id_adto = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Ds_adto
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("C"))
                    return "CONCEDIDO";
                else if (Tp_movimento.Trim().ToUpper().Equals("R"))
                    return "RECEBIDO";
                else return string.Empty;
            }
        }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch { cd_lanctocaixa = null; }
            }
        }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Nr_docto
        { get; set; }
        public string Complhistorico
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }
                catch { dt_lancto = null; }
            }
        }
        public string Tp_movcaixa
        { get; set; }
        public string Tipo_movcaixa
        {
            get
            {
                if (Tp_movcaixa.Trim().ToUpper().Equals("P"))
                    return "PAGAR";
                else if (Tp_movcaixa.Trim().ToUpper().Equals("R"))
                    return "RECEBER";
                else return string.Empty;
            }
        }
        public decimal Vl_lancto
        { get; set; }
        private decimal? id_loteCTB;
        public decimal? Id_loteCTB
        {
            get { return id_loteCTB; }
            set
            {
                id_loteCTB = value;
                id_loteCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTBstr;
        public string Id_loteCTBstr
        {
            get { return id_loteCTBstr; }
            set
            {
                id_loteCTBstr = value;
                try
                {
                    id_loteCTB = decimal.Parse(value);
                }
                catch { id_loteCTB = null; }
            }
        }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacao_deb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_ProcAdiantamento()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_adto = null;
            id_adtostr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Ds_adto = string.Empty;
            Tp_movcaixa = string.Empty;
            Tp_movimento = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Nr_docto = string.Empty;
            Complhistorico = string.Empty;
            dt_lancto = null;
            dt_lanctostr = string.Empty;
            Vl_lancto = decimal.Zero;
            id_loteCTB = null;
            id_loteCTBstr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacao_deb = string.Empty;
            cd_contacre = null;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacao_cred = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_ProcAdiantamento : TDataQuery
    {
        public TCD_ProcAdiantamento() { }

        public TCD_ProcAdiantamento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_Adto, a.CD_Empresa, b.NM_Empresa, ");
            sql.AppendLine("a.CD_Clifor, c.NM_Clifor, a.DS_Adto, a.Tp_Movimento, ");
            sql.AppendLine("a.CD_ContaGer, d.DS_ContaGer, a.CD_LanctoCaixa, a.id_lotectb, ");
            sql.AppendLine("a.CD_Historico, e.DS_Historico, a.Nr_Docto, a.ComplHistorico, ");
            sql.AppendLine("a.DT_Lancto, a.Tp_MovCaixa, a.Vl_Lancto, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, f.ds_contactb as ds_contactb_cred, ");
            sql.AppendLine("f.cd_classificacao as cd_classificacao_cre, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, g.ds_contactb as ds_contactb_deb, ");
            sql.AppendLine("g.cd_classificacao as cd_classificacao_deb, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");


            sql.AppendLine("from VTB_CTB_PROCADIANTAMENTO a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join TB_FIN_ContaGer d ");
            sql.AppendLine("on a.CD_ContaGer = d.CD_ContaGer ");
            sql.AppendLine("inner join TB_FIN_Historico e ");
            sql.AppendLine("on a.CD_Historico = e.CD_Historico ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.cd_contactb_cre = f.cd_conta_ctb ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.cd_contactb_deb = g.cd_conta_ctb ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_lancto ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcAdiantamento Select(TpBusca[] vBusca)
        {
            TList_ProcAdiantamento lista = new TList_ProcAdiantamento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_ProcAdiantamento reg = new TRegistro_ProcAdiantamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("Id_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Adto")))
                        reg.Ds_adto = reader.GetString(reader.GetOrdinal("DS_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ComplHistorico")))
                        reg.Complhistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_MovCaixa")))
                        reg.Tp_movcaixa = reader.GetString(reader.GetOrdinal("Tp_MovCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Lancto")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("Vl_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_cred")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("ds_contactb_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cre")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("cd_classificacao_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_deb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("ds_contactb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));

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
    }
    #endregion

    #region Processar Faturamento
    public class TList_ProcFaturamento : List<TRegistro_Lan_ProcFaturamento>, IComparer<TRegistro_Lan_ProcFaturamento>
    {
        #region IComparer<TRegistro_Lan_ProcFaturamento> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcFaturamento()
        { }

        public TList_ProcFaturamento(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcFaturamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcFaturamento x, TRegistro_Lan_ProcFaturamento y)
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

    public class TRegistro_Lan_ProcFaturamento
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_Documento { get; set; }
        private decimal? cd_movto;
        public decimal? CD_Movto
        {
            get { return cd_movto; }
            set
            {
                cd_movto = value;
                cd_movtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movtostr;
        public string Cd_movtostr
        {
            get { return cd_movtostr; }
            set
            {
                cd_movtostr = value;
                try
                {
                    cd_movto = Convert.ToDecimal(value);
                }
                catch
                { cd_movto = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        public string TP_Movimento { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (TP_Movimento.Trim().ToUpper().Equals("E"))
                    return "ENTRADA";
                else if (TP_Movimento.Trim().ToUpper().Equals("S"))
                    return "SAIDA";
                else return string.Empty;
            }
        }
        public string CD_Clifor { get; set; }
        public string NM_Clifor { get; set; }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        public string ID_NFItem { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = Convert.ToDecimal(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public string CD_CFOP { get; set; }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacaocred
        { get; set; }
        private decimal? nr_lanctonotafiscal;
        public decimal? Nr_LanctoNotaFiscal
        {
            get { return nr_lanctonotafiscal; }
            set
            {
                nr_lanctonotafiscal = value;
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
                    nr_lanctonotafiscal = Convert.ToDecimal(value);
                }
                catch
                { nr_lanctonotafiscal = null; }
            }
        }
        public string NR_Serie { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public string Ds_tpproduto { get; set; } = string.Empty;
        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcFaturamento()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_Documento = string.Empty;
            cd_movto = null;
            cd_movtostr = string.Empty;
            Ds_movimentacao = string.Empty;
            nr_lanctonotafiscal = null;
            nr_lanctofiscalstr = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            TP_Movimento = string.Empty;
            CD_Clifor = string.Empty;
            NM_Clifor = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            ID_NFItem = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            CD_CFOP = string.Empty;
            cd_contadeb = decimal.Zero;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = decimal.Zero;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacaocred = string.Empty;
            NR_Serie = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcFaturamento : TDataQuery
    {
        public TCD_Lan_ProcFaturamento()
        { }

        public TCD_Lan_ProcFaturamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, emp.nm_empresa, a.Nr_docto, a.cd_Movimentacao, ");
            sql.AppendLine("d.DS_Movimentacao, a.CD_CFOP, a.tp_movimento, a.Ds_TpProduto, ");
            sql.AppendLine("a.DATA, a.CD_CONTACTB_CRE, e.DS_ContaCTB as ds_contactb_cre, ");
            sql.AppendLine("e.CD_Classificacao as cd_classificacao_cre, a.CD_CONTACTB_DEB, ");
            sql.AppendLine("f.DS_ContaCTB as ds_contactb_deb, f.CD_Classificacao as cd_classificacao_deb, ");
            sql.AppendLine("a.NR_LanctoFiscal, a.Nr_Serie, a.CD_Clifor, b.NM_Clifor, ");
            sql.AppendLine("a.cd_produto, c.DS_Produto, a.ID_NFItem, a.ID_LoteCTB_Fat, a.valor, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCFATURAMENTO a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_Movimentacao = d.CD_Movimentacao ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = f.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.data ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcFaturamento Select(TpBusca[] vBusca)
        {
            TList_ProcFaturamento lista = new TList_ProcFaturamento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcFaturamento reg = new TRegistro_Lan_ProcFaturamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Documento = reader.GetDecimal(reader.GetOrdinal("Nr_Docto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DATA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Movimentacao")))
                        reg.CD_Movto = reader.GetDecimal(reader.GetOrdinal("cd_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_LanctoNotaFiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.NR_Serie = Convert.ToString(reader.GetString(reader.GetOrdinal("Nr_Serie")));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB_Fat")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB_Fat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_cre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("ds_contactb_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cre")))
                        reg.Cd_classificacaocred = reader.GetString(reader.GetOrdinal("cd_classificacao_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_deb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("ds_contactb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.CD_CFOP = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_TpProduto")))
                        reg.Ds_tpproduto = reader.GetString(reader.GetOrdinal("Ds_TpProduto"));

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

        public string AtualizaLoteNotaFiscalItem(TRegistro_Lan_ProcFaturamento reg)
        {
            //ATUALIZA_LOTE_NOTAFISCALITEM
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_LANCTOFISCAL", reg.Nr_LanctoNotaFiscal);
            hs.Add("@P_ID_LOTECTB", reg.CD_LoteCTB);
            hs.Add("@P_CD_EMPRESA", reg.CD_Empresa);
            hs.Add("@P_ID_NFITEM", reg.ID_NFItem);
            hs.Add("@P_CD_PRODUTO", reg.CD_Produto);

            return executarProc("ATUALIZA_LOTE_NOTAFISCALITEM", hs);
        }
    }
    #endregion

    #region Processar Cupom Fiscal
    public class TList_ProcNFCe : List<TRegistro_Lan_ProcNFCe>, IComparer<TRegistro_Lan_ProcNFCe>
    {
        #region IComparer<TRegistro_Lan_ProcNFCe> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcNFCe()
        { }

        public TList_ProcNFCe(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcNFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcNFCe x, TRegistro_Lan_ProcNFCe y)
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
    public class TRegistro_Lan_ProcNFCe
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_Documento { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        public string CD_Clifor { get; set; }
        public string NM_Clifor { get; set; }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = Convert.ToDecimal(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public string CD_CFOP { get; set; }
        public string Ds_cfop { get; set; }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacaocred
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
                    id_cupom = Convert.ToDecimal(value);
                }
                catch
                { id_cupom = null; }
            }
        }
        public decimal? Id_lancto { get; set; } = null;
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public decimal? Cd_movimentacao { get; set; } = null;
        public string Ds_movimentacao { get; set; } = string.Empty;
        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcNFCe()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_Documento = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            CD_Clifor = string.Empty;
            NM_Clifor = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            CD_CFOP = string.Empty;
            Ds_cfop = string.Empty;
            cd_contadeb = decimal.Zero;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = decimal.Zero;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacaocred = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_processar = false;
        }
    }
    public class TCD_Lan_ProcNFCe : TDataQuery
    {
        public TCD_Lan_ProcNFCe()
        { }

        public TCD_Lan_ProcNFCe(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, emp.nm_empresa, a.Nr_docto, a.CD_CFOP, cfop.DS_CFOP, ");
            sql.AppendLine("a.DATA, a.CD_CONTACTB_CRE, e.DS_ContaCTB as ds_contactb_cre, ");
            sql.AppendLine("e.CD_Classificacao as cd_classificacao_cre, a.CD_CONTACTB_DEB, ");
            sql.AppendLine("f.DS_ContaCTB as ds_contactb_deb, f.CD_Classificacao as cd_classificacao_deb, ");
            sql.AppendLine("a.ID_NFCe, a.CD_Clifor, b.NM_Clifor, a.id_lancto, ");
            sql.AppendLine("a.cd_produto, c.DS_Produto, a.ID_LoteCTB, a.valor, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C, a.cd_movimentacao, d.ds_movimentacao ");

            sql.AppendLine("from VTB_CTB_ProcNFCe a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_FIS_CFOP cfop ");
            sql.AppendLine("on a.cd_cfop = cfop.cd_cfop ");
            sql.AppendLine("left outer join TB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_movimentacao = d.cd_movimentacao ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = f.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.data ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcNFCe Select(TpBusca[] vBusca)
        {
            TList_ProcNFCe lista = new TList_ProcNFCe();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcNFCe reg = new TRegistro_Lan_ProcNFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Documento = reader.GetDecimal(reader.GetOrdinal("Nr_Docto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DATA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfce")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_cre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("ds_contactb_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cre")))
                        reg.Cd_classificacaocred = reader.GetString(reader.GetOrdinal("cd_classificacao_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_deb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("ds_contactb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.CD_CFOP = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));

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

        public string AtualizaLoteNFCeItem(TRegistro_Lan_ProcNFCe reg)
        {
            //ATUALIZA_LOTE_NOTAFISCALITEM
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_NFCE", reg.Id_cupom);
            hs.Add("@P_ID_LOTECTB", reg.CD_LoteCTB);
            hs.Add("@P_CD_EMPRESA", reg.CD_Empresa);
            hs.Add("@P_ID_LANCTO", reg.Id_lancto);
            hs.Add("@P_CD_PRODUTO", reg.CD_Produto);

            return executarProc("ATUALIZA_LOTE_NFCEITEM", hs);
        }
    }
    #endregion

    #region Processar Impostos
    public class TList_ProcImpostos : List<TRegistro_ProcImpostos>, IComparer<TRegistro_ProcImpostos>
    {
        #region IComparer<TRegistro_ProcImpostos> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcImpostos()
        { }

        public TList_ProcImpostos(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcImpostos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcImpostos x, TRegistro_ProcImpostos y)
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

    public class TRegistro_ProcImpostos
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Cd_imposto
        { get; set; }
        public string Ds_imposto
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("E"))
                    return "ENTRADA";
                else if (Tp_movimento.Trim().ToUpper().Equals("S"))
                    return "SAIDA";
                else return string.Empty;
            }
        }
        public decimal? Cd_movimentacao
        { get; set; }
        public string Ds_movimentacao
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public DateTime? Dt_documento
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Pc_retencao
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_impostocalc
        { get; set; }
        public decimal Vl_impostoretido
        { get; set; }
        public decimal? Id_lotectb_calculado
        { get; set; }
        public decimal? Id_lotectb_retido
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? cd_contactb_cred;
        public decimal? Cd_contactb_cred
        {
            get { return cd_contactb_cred; }
            set { cd_contactb_cred = value.Value.Equals(decimal.Zero) ? null : value; }
        }
        public string Ds_contactb_cred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        private decimal? cd_contactb_deb;
        public decimal? Cd_contactb_deb
        {
            get { return cd_contactb_deb; }
            set { cd_contactb_deb = value.Value.Equals(decimal.Zero) ? null : value; }
        }
        public string Ds_contactb_deb
        { get; set; }
        public string Cd_classificacao_deb
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_ProcImpostos()
        {
            Cd_clifor = string.Empty;
            cd_contactb_cred = null;
            Ds_contactb_cred = string.Empty;
            Cd_classificacao_cred = string.Empty;
            cd_contactb_deb = null;
            Ds_contactb_deb = string.Empty;
            Cd_classificacao_deb = string.Empty;
            Cd_empresa = string.Empty;
            Cd_imposto = null;
            Cd_movimentacao = null;
            Cd_produto = string.Empty;
            Ds_imposto = string.Empty;
            Ds_movimentacao = string.Empty;
            Ds_produto = string.Empty;
            Id_lotectb_calculado = null;
            Id_lotectb_retido = null;
            Nm_clifor = string.Empty;
            Nm_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Nr_notafiscal = null;
            Id_nfitem = null;
            Dt_documento = null;
            Nr_serie = string.Empty;
            Pc_aliquota = decimal.Zero;
            Pc_retencao = decimal.Zero;
            Tp_movimento = string.Empty;
            Vl_basecalc = decimal.Zero;
            Vl_impostocalc = decimal.Zero;
            Vl_impostoretido = decimal.Zero;
            St_processar = false;
        }
    }

    public class TCD_ProcImpostos : TDataQuery
    {
        public TCD_ProcImpostos()
        { }

        public TCD_ProcImpostos(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.CD_Empresa, b.NM_Empresa, a.CD_Imposto, a.ID_NFItem, ");
            sql.AppendLine("c.DS_Imposto, a.Tp_Movimento, a.CD_Movimentacao, a.PC_Retencao, ");
            sql.AppendLine("d.DS_Movimentacao, a.Nr_LanctoFiscal, a.Nr_NotaFiscal, a.data, ");
            sql.AppendLine("a.Nr_Serie, a.CD_Produto, e.ds_produto, a.pc_aliquota, a.Vl_Retido, ");
            sql.AppendLine("a.Vl_BaseCalc, a.Vl_ImpostoCalc, a.Id_LoteCTB_Calculado, a.Id_LoteCTB_Retido, ");
            sql.AppendLine("a.CD_Clifor, f.NM_Clifor, a.CD_ContaCTB_Cred, g.DS_ContaCTB as ds_contactb_cred, ");
            sql.AppendLine("g.CD_Classificacao as cd_classificacao_cred, a.CD_ContaCTB_Deb, ");
            sql.AppendLine("h.DS_ContaCTB as ds_contactb_deb, h.CD_Classificacao as cd_classificacao_deb ");

            sql.AppendLine("from VTB_CTB_PROCIMPOSTOS a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIS_Imposto c ");
            sql.AppendLine("on a.CD_Imposto = c.cd_imposto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.CD_Movimentacao = d.CD_Movimentacao ");
            sql.AppendLine("inner join TB_EST_Produto e ");
            sql.AppendLine("on a.CD_Produto = e.cd_produto ");
            sql.AppendLine("inner join TB_FIN_Clifor f ");
            sql.AppendLine("on a.CD_Clifor = f.CD_Clifor ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.CD_ContaCTB_Cred = g.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas h ");
            sql.AppendLine("on a.CD_ContaCTB_Deb = h.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.data ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcImpostos Select(TpBusca[] vBusca)
        {
            TList_ProcImpostos lista = new TList_ProcImpostos();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_ProcImpostos reg = new TRegistro_ProcImpostos();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("data")))
                        reg.Dt_documento = reader.GetDateTime(reader.GetOrdinal("data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("pc_aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ImpostoCalc")))
                        reg.Vl_impostocalc = reader.GetDecimal(reader.GetOrdinal("Vl_ImpostoCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Retencao")))
                        reg.Pc_retencao = reader.GetDecimal(reader.GetOrdinal("PC_Retencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Retido")))
                        reg.Vl_impostoretido = reader.GetDecimal(reader.GetOrdinal("Vl_Retido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB_Calculado")))
                        reg.Id_lotectb_calculado = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB_Calculado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB_Retido")))
                        reg.Id_lotectb_retido = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB_Retido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_Cred")))
                        reg.Cd_contactb_cred = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_Cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_cred")))
                        reg.Ds_contactb_cred = reader.GetString(reader.GetOrdinal("ds_contactb_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cred")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("cd_classificacao_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_Deb")))
                        reg.Cd_contactb_deb = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_Deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_deb")))
                        reg.Ds_contactb_deb = reader.GetString(reader.GetOrdinal("ds_contactb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));

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
    }
    #endregion

    #region Processar Financeiro
    public class TList_ProcFinanceiro : List<TRegistro_Lan_ProcFinanceiro>, IComparer<TRegistro_Lan_ProcFinanceiro>
    {
        #region IComparer<TRegistro_Lan_ProcFinanceiro> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcFinanceiro()
        { }

        public TList_ProcFinanceiro(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcFinanceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcFinanceiro x, TRegistro_Lan_ProcFinanceiro y)
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


    public class TRegistro_Lan_ProcFinanceiro
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_Documento { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        public string TP_Movimento
        {
            get
            {
                if (Tp_movduplicata.Trim().ToUpper().Equals("P"))
                    return "PAGAR";
                else if (Tp_movduplicata.Trim().ToUpper().Equals("R"))
                    return "RECEBER";
                else return string.Empty;
            }
        }
        public string CD_Clifor { get; set; }
        public string NM_Clifor { get; set; }
        public string TP_Duplicata { get; set; }
        public string Ds_tpduplicata { get; set; }
        public string Tp_movduplicata { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = decimal.Parse(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get { return cd_contadebstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = decimal.Parse(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {

                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get { return cd_contacrestr; }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = decimal.Parse(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacre
        { get; set; }
        public string Cd_classificacaocre
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_Lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        public string CD_Historico { get; set; }
        public string DS_Historico { get; set; }
        public string Tp_movhistorico { get; set; }
        public string Ds_observacao { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public bool St_processar { get; set; }

        public TRegistro_Lan_ProcFinanceiro()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_Documento = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            CD_Clifor = string.Empty;
            NM_Clifor = string.Empty;
            TP_Duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            Tp_movduplicata = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = null;
            cd_contacrestr = string.Empty;
            Ds_contacre = string.Empty;
            Cd_classificacaocre = string.Empty;
            CD_Historico = string.Empty;
            DS_Historico = string.Empty;
            Tp_movhistorico = string.Empty;
            Ds_observacao = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcFinanceiro : TDataQuery
    {
        public TCD_Lan_ProcFinanceiro()
        { }

        public TCD_Lan_ProcFinanceiro(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, b.NM_Empresa, a.Nr_Docto, a.DT_Emissao, a.nr_lancto, a.ds_observacao, ");
            sql.AppendLine("a.tp_duplicata, tp.ds_tpduplicata, tp.tp_mov as tp_movduplicata, a.ID_LoteCTB, a.VL_Documento, ");
            sql.AppendLine("a.cd_historico, c.ds_historico, c.tp_mov as tp_movhistorico, a.cd_clifor, d.NM_Clifor, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, e.DS_ContaCTB as DS_ContaDeb, e.CD_Classificacao as CD_ClassificacaoDeb, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, f.DS_ContaCTB as DS_ContaCre, f.CD_Classificacao as CD_ClassificacaoCre, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCFINANCEIRO a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Historico c ");
            sql.AppendLine("on a.cd_historico = c.cd_historico ");
            sql.AppendLine("inner join TB_FIN_Clifor d ");
            sql.AppendLine("on a.cd_clifor = d.CD_Clifor ");
            sql.AppendLine("inner join TB_FIN_TpDuplicata tp ");
            sql.AppendLine("on a.tp_duplicata = tp.tp_duplicata ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = f.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.dt_emissao ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcFinanceiro Select(TpBusca[] vBusca)
        {
            TList_ProcFinanceiro lista = new TList_ProcFinanceiro();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcFinanceiro reg = new TRegistro_Lan_ProcFinanceiro();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Documento = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_Lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Documento")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("VL_Documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.CD_Historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.DS_Historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movhistorico")))
                        reg.Tp_movhistorico = reader.GetString(reader.GetOrdinal("tp_movhistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.TP_Duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movduplicata")))
                        reg.Tp_movduplicata = reader.GetString(reader.GetOrdinal("tp_movduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaDeb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ClassificacaoDeb")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("CD_ClassificacaoDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCre")))
                        reg.Ds_contacre = reader.GetString(reader.GetOrdinal("DS_ContaCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ClassificacaoCre")))
                        reg.Cd_classificacaocre = reader.GetString(reader.GetOrdinal("CD_ClassificacaoCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));

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

        public string AtualizaLoteFinanceiro(TRegistro_Lan_ProcFinanceiro reg)
        {
            //ATUALIZA_LOTE_CAIXA
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_LOTECTB", reg.CD_LoteCTB);
            hs.Add("@P_CD_EMPRESA", reg.CD_Empresa);
            hs.Add("@P_NR_LANCTO", reg.Nr_Lancto);

            return executarProc("ATUALIZA_LOTE_DUPLICATA", hs);
        }
    }
    #endregion

    #region Processar Cheque Compensado
    public class TList_ProcChequeCompensado : List<TRegistro_Lan_ProcChequeCompensado>, IComparer<TRegistro_Lan_ProcChequeCompensado>
    {
        #region IComparer<TRegistro_Lan_ProcChequeCompensado> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcChequeCompensado()
        { }

        public TList_ProcChequeCompensado(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcChequeCompensado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcChequeCompensado x, TRegistro_Lan_ProcChequeCompensado y)
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

    public class TRegistro_Lan_ProcChequeCompensado
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_Cheque { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        public string TP_Movimento { get; set; }
        private decimal? cd_lotectb;
        public decimal? Cd_lotectb
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get
            {
                if (cd_lotectbstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_lotectbstr;
            }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = decimal.Parse(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public string Nr_Documento { get; set; }
        private decimal? cd_contadeb;
        public decimal? Cd_contadeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get { return cd_contadebstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = decimal.Parse(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacao_deb
        { get; set; }
        private decimal? cd_contacred;
        public decimal? Cd_contacred
        {
            get { return cd_contacred; }
            set
            {
                cd_contacred = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacredstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacredstr;
        public string Cd_contacredstr
        {
            get { return cd_contacredstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contacred = decimal.Parse(value);
                }
                catch
                { cd_contacred = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        private decimal? id_lanctocaixa;
        public decimal? Id_lanctocaixa
        {
            get { return id_lanctocaixa; }
            set
            {
                id_lanctocaixa = value;
                id_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctocaixastr;
        public string Id_lanctocaixastr
        {
            get { return id_lanctocaixastr; }
            set
            {
                id_lanctocaixastr = value;
                try
                {
                    id_lanctocaixa = decimal.Parse(value);
                }
                catch
                { id_lanctocaixa = null; }
            }
        }
        public string Cd_historico { get; set; }
        public string Ds_historico { get; set; }
        public string CD_ContaGerOrig { get; set; }
        public string CD_ContaGerDest { get; set; }
        public string DS_ContaGerOrig { get; set; }
        public string DS_ContaGerDest { get; set; }
        public string DS_ComplHistorico { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }

        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcChequeCompensado()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_Cheque = string.Empty;
            Nr_Documento = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            DS_ComplHistorico = string.Empty;
            TP_Movimento = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            cd_contacred = null;
            cd_contacredstr = string.Empty;
            id_lanctocaixa = null;
            id_lanctocaixastr = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            CD_ContaGerOrig = string.Empty;
            CD_ContaGerDest = string.Empty;
            DS_ContaGerOrig = string.Empty;
            DS_ContaGerDest = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcChequeCompensado : TDataQuery
    {
        public TCD_Lan_ProcChequeCompensado() { }

        public TCD_Lan_ProcChequeCompensado(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.Tp_Titulo, a.cd_empresa, b.NM_Empresa, ");
            sql.AppendLine("a.Nr_Docto, a.Nr_Cheque, a.DT_Lancto, a.cd_lanctocaixa, ");
            sql.AppendLine("a.cd_historico, c.DS_Historico, a.id_loteCTB, a.ComplHistorico, a.Valor, ");
            sql.AppendLine("a.cd_contaOrig, d.DS_ContaGer, a.CD_ContaDest, e.DS_ContaGer as DS_ContaGerDest, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, f.DS_ContaCTB as DS_ContaCre, f.CD_Classificacao as CD_ClassificacaoCre, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, g.DS_ContaCTB as DS_ContaDeb, g.CD_Classificacao as CD_ClassificacaoDeb, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCCHEQUECOMPENSADO a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Historico c ");
            sql.AppendLine("on a.cd_historico = c.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_ContaGer d ");
            sql.AppendLine("on a.cd_contaOrig = d.CD_ContaGer ");
            sql.AppendLine("inner join TB_FIN_ContaGer e ");
            sql.AppendLine("on a.CD_ContaDest = e.CD_ContaGer ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = f.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = g.CD_Conta_CTB ");
            sql.AppendLine("");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.dt_lancto ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcChequeCompensado Select(TpBusca[] vBusca)
        {
            TList_ProcChequeCompensado lista = new TList_ProcChequeCompensado();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcChequeCompensado reg = new TRegistro_Lan_ProcChequeCompensado();
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Titulo")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("Tp_Titulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Documento = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Cheque")))
                        reg.Nr_Cheque = reader.GetString(reader.GetOrdinal("Nr_Cheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Id_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Cd_lotectb = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ComplHistorico")))
                        reg.DS_ComplHistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contaOrig")))
                        reg.CD_ContaGerOrig = reader.GetString(reader.GetOrdinal("cd_contaOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.DS_ContaGerOrig = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaDest")))
                        reg.CD_ContaGerDest = reader.GetString(reader.GetOrdinal("CD_ContaDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGerDest")))
                        reg.DS_ContaGerDest = reader.GetString(reader.GetOrdinal("DS_ContaGerDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.Cd_contacred = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("DS_ContaCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ClassificacaoCre")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("CD_ClassificacaoCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.Cd_contadeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaDeb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ClassificacaoDeb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("CD_ClassificacaoDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));

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
    }
    #endregion

    #region Processar Fatura Cartao
    public class TList_ProcCartao_DC : List<TRegistro_ProcCartao_DC>, IComparer<TRegistro_ProcCartao_DC>
    {
        #region IComparer<TRegistro_Lan_ProcChequeCompensado> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcCartao_DC()
        { }

        public TList_ProcCartao_DC(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcCartao_DC value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcCartao_DC x, TRegistro_ProcCartao_DC y)
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

    public class TRegistro_ProcCartao_DC
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        public DateTime DT_Lancto { get; set; }
        public string Tp_lancto { get; set; } = string.Empty;
        public string Tipo_lancto
        {
            get
            {
                if (Tp_lancto.Trim().ToUpper().Equals("Q"))
                    return "QUITAÇÃO";
                else if (Tp_lancto.Trim().ToUpper().Equals("J"))
                    return "JURO";
                else if (Tp_lancto.Trim().ToUpper().Equals("T"))
                    return "TAXA";
                else return string.Empty;
            }
        }
        public decimal VL_Lancto { get; set; }
        public string TP_Movimento { get; set; }
        private decimal? cd_lotectb;
        public decimal? Cd_lotectb
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get
            {
                if (cd_lotectbstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_lotectbstr;
            }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = decimal.Parse(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public decimal? Id_fatura { get; set; } = null;
        private decimal? cd_contadeb;
        public decimal? Cd_contadeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get { return cd_contadebstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = decimal.Parse(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacao_deb
        { get; set; }
        private decimal? cd_contacred;
        public decimal? Cd_contacred
        {
            get { return cd_contacred; }
            set
            {
                cd_contacred = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacredstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacredstr;
        public string Cd_contacredstr
        {
            get { return cd_contacredstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contacred = decimal.Parse(value);
                }
                catch
                { cd_contacred = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        public string CD_ContaGerOrig { get; set; }
        public string CD_ContaGerDest { get; set; }
        public string DS_ContaGerOrig { get; set; }
        public string DS_ContaGerDest { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public decimal? Id_bandeira { get; set; } = null;
        public string Ds_bandeira { get; set; } = string.Empty;
        public string Tp_cartao { get; set; } = string.Empty;
        public string Tipo_cartao
        {
            get
            {
                if (Tp_cartao.Trim().ToUpper().Equals("D"))
                    return "DEBITO";
                else if (Tp_cartao.Trim().ToUpper().Equals("C"))
                    return "CREDITO";
                else if (Tp_cartao.Trim().ToUpper().Equals("R"))
                    return "ROTATIVO";
                else return string.Empty;
            }
        }
        private decimal? id_quitar;
        public decimal? Id_quitar
        {
            get { return id_quitar; }
            set
            {
                id_quitar = value;
                id_quitarstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_quitarstr;
        public string Id_quitarstr
        {
            get { return id_quitarstr; }
            set
            {
                id_quitarstr = value;
                try
                {
                    id_quitar = decimal.Parse(value);
                }
                catch { id_quitar = null; }
            }
        }

        public bool St_processar
        { get; set; }

        public TRegistro_ProcCartao_DC()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            TP_Movimento = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            cd_contacred = null;
            cd_contacredstr = string.Empty;
            CD_ContaGerOrig = string.Empty;
            CD_ContaGerDest = string.Empty;
            DS_ContaGerOrig = string.Empty;
            DS_ContaGerDest = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            cd_contactb_D = null;
            id_quitar = null;
            id_quitarstr = string.Empty;
            cd_contactb_Dstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_ProcCartao_DC : TDataQuery
    {
        public TCD_ProcCartao_DC() { }

        public TCD_ProcCartao_DC(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.TP_Movimento, a.cd_empresa, b.NM_Empresa, a.ID_Quitar, ");
            sql.AppendLine("a.ID_Fatura, a.DT_Lancto, a.TP_Lancto, a.id_loteCTB, ");
            sql.AppendLine("a.CD_ContaGer, c.DS_ContaGer, a.CD_ContaGerQuit, d.DS_ContaGer as DS_ContaGerQuit, ");
            sql.AppendLine("a.id_bandeira, e.DS_Bandeira, e.TP_Cartao, a.Valor, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, f.DS_ContaCTB as DS_ContaCre, f.CD_Classificacao as ClassificacaoCre, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, g.DS_ContaCTB as DS_ContaDeb, g.CD_Classificacao as ClassificacaoDeb, ");
            sql.AppendLine("a.CD_ContaCTB_C, a.CD_ContaCTB_D ");

            sql.AppendLine("from VTB_CTB_PROCCARTAO_DC a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_ContaGer c ");
            sql.AppendLine("on a.CD_ContaGer = c.CD_ContaGer ");
            sql.AppendLine("inner join TB_FIN_ContaGer d ");
            sql.AppendLine("on a.CD_ContaGerQuit = d.CD_ContaGer ");
            sql.AppendLine("inner join TB_FIN_BandeiraCartao e ");
            sql.AppendLine("on a.id_bandeira = e.ID_Bandeira ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = f.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = g.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.AppendLine("order by a.dt_lancto ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcCartao_DC Select(TpBusca[] vBusca)
        {
            TList_ProcCartao_DC lista = new TList_ProcCartao_DC();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_ProcCartao_DC reg = new TRegistro_ProcCartao_DC();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Quitar")))
                        reg.Id_quitar = reader.GetDecimal(reader.GetOrdinal("ID_Quitar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fatura")))
                        reg.Id_fatura = reader.GetDecimal(reader.GetOrdinal("ID_Fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Lancto")))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Cd_lotectb = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.CD_ContaGerOrig = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.DS_ContaGerOrig = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGerQuit")))
                        reg.CD_ContaGerDest = reader.GetString(reader.GetOrdinal("CD_ContaGerQuit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGerQuit")))
                        reg.DS_ContaGerDest = reader.GetString(reader.GetOrdinal("DS_ContaGerQuit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bandeira")))
                        reg.Id_bandeira = reader.GetDecimal(reader.GetOrdinal("id_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Bandeira")))
                        reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("DS_Bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("TP_Cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.Cd_contacred = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("DS_ContaCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ClassificacaoCre")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("ClassificacaoCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.Cd_contadeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaDeb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ClassificacaoDeb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("ClassificacaoDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));

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

        public string AtualizaLoteCartao(TRegistro_ProcCartao_DC reg)
        {
            //ATUALIZA_LOTE_CAIXA
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_QUITAR", reg.Id_quitar);
            hs.Add("@P_ID_LOTECTB", reg.Cd_lotectb);
            hs.Add("@P_TP_LANCTO", reg.Tp_lancto);

            return executarProc("ATUALIZA_LOTE_FATURA", hs);
        }
    }
    #endregion

    #region Provisao Estoque
    public class TList_ProcProvEstoque : List<TRegistro_Lan_ProcProvEstoque>, IComparer<TRegistro_Lan_ProcProvEstoque>
    {
        #region IComparer<TRegistro_Lan_ProcProvEstoque> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcProvEstoque()
        { }

        public TList_ProcProvEstoque(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcProvEstoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcProvEstoque x, TRegistro_Lan_ProcProvEstoque y)
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


    public class TRegistro_Lan_ProcProvEstoque
    {
        public string CD_Empresa { get; set; }
        public string Nm_empresa { get; set; }
        private decimal? id_lanctoestoque;
        public decimal? ID_LanctoEstoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = Convert.ToDecimal(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }
        public DateTime DT_Lancto { get; set; }
        public decimal VL_Lancto { get; set; }
        public string TP_Movimento { get; set; }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = Convert.ToDecimal(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get { return cd_contadebstr; }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get { return cd_contacrestr; }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacre
        { get; set; }
        public string Cd_classificacaocre
        { get; set; }
        private decimal? id_provisao;
        public decimal? ID_Provisao
        {
            get { return id_provisao; }
            set
            {
                id_provisao = value;
                id_provisaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_provisaostr;
        public string Id_provisaostr
        {
            get { return id_provisaostr; }
            set
            {
                id_provisaostr = value;
                try
                {
                    id_provisao = Convert.ToDecimal(value);
                }
                catch
                { id_provisao = null; }
            }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcProvEstoque()
        {
            CD_Empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_lanctoestoque = null;
            id_lanctoestoquestr = string.Empty;
            DT_Lancto = DateTime.Now;
            VL_Lancto = decimal.Zero;
            TP_Movimento = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = null;
            cd_contacrestr = string.Empty;
            Ds_contacre = string.Empty;
            Cd_classificacaocre = string.Empty;
            id_provisao = null;
            id_provisaostr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcProvEstoque : TDataQuery
    {
        public TCD_Lan_ProcProvEstoque()
        { }

        public TCD_Lan_ProcProvEstoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, b.NM_Empresa, a.ID_LanctoEstoque, a.Id_LoteCTB, ");
            sql.AppendLine("a.tp_movimento, a.DT_Lancto, a.CD_PRODUTO, c.DS_Produto, a.Id_Provisao, a.Valor, ");
            sql.AppendLine("a.CD_CONTACTB_CRE, d.DS_ContaCTB as DS_ContaCre, d.CD_Classificacao as Cd_ClassificacaoCre, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, e.DS_ContaCTB as DS_ContaDeb, e.CD_Classificacao as Cd_ClassificacaoDeb ");

            sql.AppendLine("from VTB_CTB_PROCPROVISAOEST a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.CD_PRODUTO = c.CD_Produto ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas d ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = d.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = e.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcProvEstoque Select(TpBusca[] vBusca)
        {
            TList_ProcProvEstoque lista = new TList_ProcProvEstoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcProvEstoque reg = new TRegistro_Lan_ProcProvEstoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.ID_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PRODUTO")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Provisao")))
                        reg.ID_Provisao = reader.GetDecimal(reader.GetOrdinal("Id_Provisao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCre")))
                        reg.Ds_contacre = reader.GetString(reader.GetOrdinal("DS_ContaCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ClassificacaoCre")))
                        reg.Cd_classificacaocre = reader.GetString(reader.GetOrdinal("Cd_ClassificacaoCre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaDeb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaDeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ClassificacaoDeb")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("Cd_ClassificacaoDeb"));
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

        public string AtualizaLoteProvEstoque(TRegistro_Lan_ProcProvEstoque reg)
        {
            //ATUALIZA_LOTE_CAIXA
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_LOTECTB", reg.CD_LoteCTB);
            hs.Add("@P_CD_EMPRESA", reg.CD_Empresa);
            hs.Add("@P_CD_PRODUTO", reg.CD_Produto);
            hs.Add("@P_ID_LANCTOESTOQUE", reg.ID_LanctoEstoque);
            hs.Add("@P_ID_PROVISAO", reg.ID_Provisao);

            return executarProc("ATUALIZA_LOTE_PROV_X_ESTOQUE", hs);
        }
    }
    #endregion

    #region CMV
    public class TList_ProcCMV : List<TRegistro_Lan_ProcCMV>, IComparer<TRegistro_Lan_ProcCMV>
    {
        #region IComparer<TRegistro_Lan_ProcCMV> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcCMV()
        { }

        public TList_ProcCMV(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_ProcCMV value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_ProcCMV x, TRegistro_Lan_ProcCMV y)
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


    public class TRegistro_Lan_ProcCMV
    {
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Nr_docto { get; set; }
        private decimal? cd_movto;
        public decimal? CD_Movto
        {
            get { return cd_movto; }
            set
            {
                cd_movto = value;
                cd_movtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movtostr;
        public string Cd_movtostr
        {
            get { return cd_movtostr; }
            set
            {
                cd_movtostr = value;
                try
                {
                    cd_movto = Convert.ToDecimal(value);
                }
                catch
                { cd_movto = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public DateTime Dt_lancto { get; set; }
        public decimal Vl_lancto { get; set; }
        public string Tp_movimento { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("E"))
                    return "ENTRADA";
                else if (Tp_movimento.Trim().ToUpper().Equals("S"))
                    return "SAIDA";
                else return string.Empty;
            }
        }
        public string Cd_clifor { get; set; }
        public string Nm_clifor { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Id_nfitem { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = Convert.ToDecimal(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        public string CD_CFOP { get; set; }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacaocred
        { get; set; }
        private decimal? nr_lanctonotafiscal;
        public decimal? Nr_LanctoNotaFiscal
        {
            get { return nr_lanctonotafiscal; }
            set
            {
                nr_lanctonotafiscal = value;
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
                    nr_lanctonotafiscal = Convert.ToDecimal(value);
                }
                catch
                { nr_lanctonotafiscal = null; }
            }
        }
        public string NR_Serie { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch
                { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public string Ds_tpproduto { get; set; } = string.Empty;
        public bool St_processar
        { get; set; }

        public TRegistro_Lan_ProcCMV()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_docto = string.Empty;
            cd_movto = null;
            cd_movtostr = string.Empty;
            Ds_movimentacao = string.Empty;
            nr_lanctonotafiscal = null;
            nr_lanctofiscalstr = string.Empty;
            Dt_lancto = DateTime.Now;
            Vl_lancto = decimal.Zero;
            Tp_movimento = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Id_nfitem = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            CD_CFOP = string.Empty;
            cd_contadeb = decimal.Zero;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = decimal.Zero;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacaocred = string.Empty;
            NR_Serie = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcCMV : TDataQuery
    {
        public TCD_Lan_ProcCMV()
        { }

        public TCD_Lan_ProcCMV(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("select a.cd_empresa, emp.nm_empresa, a.Nr_docto, a.cd_Movimentacao, ");
            sql.AppendLine("d.DS_Movimentacao, a.CD_CFOP, a.tp_movimento, tp.ds_tpproduto, ");
            sql.AppendLine("a.DATA, a.CD_CONTACTB_CRE, e.DS_ContaCTB as ds_contactb_cre, ");
            sql.AppendLine("e.CD_Classificacao as cd_classificacao_cre, a.CD_CONTACTB_DEB, ");
            sql.AppendLine("f.DS_ContaCTB as ds_contactb_deb, f.CD_Classificacao as cd_classificacao_deb, ");
            sql.AppendLine("a.NR_LanctoFiscal, a.Nr_Serie, a.CD_Clifor, b.NM_Clifor, ");
            sql.AppendLine("a.cd_produto, c.DS_Produto, a.ID_NFItem, a.ID_LoteCTB_CMV, a.valor, ");
            sql.AppendLine("a.CD_ContaCTB_D, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCCMV a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_TpProduto tp ");
            sql.AppendLine("on c.tp_produto = tp.tp_produto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_Movimentacao = d.CD_Movimentacao ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = f.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcCMV Select(TpBusca[] vBusca)
        {
            TList_ProcCMV lista = new TList_ProcCMV();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_Lan_ProcCMV reg = new TRegistro_Lan_ProcCMV();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_docto = reader.GetDecimal(reader.GetOrdinal("Nr_Docto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DATA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Movimentacao")))
                        reg.CD_Movto = reader.GetDecimal(reader.GetOrdinal("cd_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_LanctoNotaFiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.NR_Serie = Convert.ToString(reader.GetString(reader.GetOrdinal("Nr_Serie")));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB_CMV")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB_CMV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_cre")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("ds_contactb_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cre")))
                        reg.Cd_classificacaocred = reader.GetString(reader.GetOrdinal("cd_classificacao_cre"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb_deb")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("ds_contactb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.CD_CFOP = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpproduto")))
                        reg.Ds_tpproduto = reader.GetString(reader.GetOrdinal("ds_tpproduto"));

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
    }
    #endregion

    #region Processar Complemento Fixar
    public class TList_ProcCompFixar : List<TRegistro_ProcCompFixar>, IComparer<TRegistro_ProcCompFixar>
    {
        #region IComparer<TRegistro_ProcCompFixar> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcCompFixar()
        { }

        public TList_ProcCompFixar(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcCompFixar value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcCompFixar x, TRegistro_ProcCompFixar y)
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

    public class TRegistro_ProcCompFixar
    {
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        private decimal? id_atualiza;

        public decimal? Id_atualiza
        {
            get { return id_atualiza; }
            set
            {
                id_atualiza = value;
                id_atualizastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atualizastr;

        public string Id_atualizastr
        {
            get { return id_atualizastr; }
            set
            {
                id_atualizastr = value;
                try
                {
                    id_atualiza = decimal.Parse(value);
                }
                catch { id_atualiza = null; }
            }
        }

        public DateTime Dt_lancto { get; set; }
        public decimal Vl_lancto { get; set; }
        public string Tp_registro { get; set; }
        public string Tipo_registro
        {
            get
            {
                if (Tp_registro.Trim().ToUpper().Equals("E"))
                    return "ESTORNO";
                else if (Tp_registro.Trim().ToUpper().Equals("A"))
                    return "ATUALIZAÇÃO";
                else return string.Empty;
            }
        }
        public string Tp_movimento { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("C"))
                    return "COMPRA";
                else if (Tp_movimento.Trim().ToUpper().Equals("V"))
                    return "VENDA";
                else return string.Empty;
            }
        }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        private decimal? cd_lotectb;
        public decimal? CD_LoteCTB
        {
            get { return cd_lotectb; }
            set
            {
                cd_lotectb = value;
                cd_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lotectbstr;
        public string Cd_lotectbstr
        {
            get { return cd_lotectbstr; }
            set
            {
                cd_lotectbstr = value;
                try
                {
                    cd_lotectb = Convert.ToDecimal(value);
                }
                catch
                { cd_lotectb = null; }
            }
        }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb
        { get; set; }
        public string Cd_classificacaodeb
        { get; set; }
        private decimal? cd_contacre;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred
        { get; set; }
        public string Cd_classificacaocred
        { get; set; }
        private decimal? cd_contactb_D;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }

        public bool St_processar
        { get; set; }

        public TRegistro_ProcCompFixar()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_atualiza = null;
            id_atualizastr = string.Empty;
            Tp_registro = string.Empty;
            Tp_movimento = string.Empty;
            Dt_lancto = DateTime.Now;
            Vl_lancto = decimal.Zero;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            cd_lotectb = null;
            cd_lotectbstr = string.Empty;
            cd_contadeb = decimal.Zero;
            cd_contadebstr = string.Empty;
            Ds_contadeb = string.Empty;
            Cd_classificacaodeb = string.Empty;
            cd_contacre = decimal.Zero;
            cd_contacrestr = string.Empty;
            Ds_contacred = string.Empty;
            Cd_classificacaocred = string.Empty;
            cd_contactb_D = null;
            cd_contactb_Dstr = string.Empty;
            cd_contactb_C = null;
            cd_contactb_Cstr = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Lan_ProcCompFixar : TDataQuery
    {
        public TCD_Lan_ProcCompFixar() { }

        public TCD_Lan_ProcCompFixar(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT a.cd_empresa, a.nm_empresa, a.cd_produto, a.ds_produto, ");
            sql.AppendLine("a.tp_registro, a.tp_movimento, a.data, a.valor, a.id_atualiza, ");
            sql.AppendLine("a.id_lotectb, a.CD_CONTACTB_CRE, f.DS_ContaCTB as DS_CONTACTB_CRE, ");
            sql.AppendLine("f.CD_Classificacao as CD_Classificacao_CRE, a.CD_ContaCTB_D, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, g.DS_ContaCTB as DS_ContaCTB_DEB, ");
            sql.AppendLine("g.CD_Classificacao as CD_Classificacao_DEB, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_PROCCOMPFIXACAO a ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = f.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = g.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.data ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcCompFixar Select(TpBusca[] vBusca)
        {
            TList_ProcCompFixar lista = new TList_ProcCompFixar();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_ProcCompFixar reg = new TRegistro_ProcCompFixar();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atualiza")))
                        reg.Id_atualiza = reader.GetDecimal(reader.GetOrdinal("id_atualiza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("data")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTACTB_CRE")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("DS_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRE")))
                        reg.Cd_classificacaocred = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB_DEB")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaCTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.CD_LoteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));

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
    }
    #endregion
    
    #region Processar Conhecimento Frete
    public class TList_ProcConhecimentoFrete:List<TRegistro_ProcConhecimentoFrete>,IComparer<TRegistro_ProcConhecimentoFrete>
    {
        #region IComparer<TList_ProcConhecimentoFrete> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_ProcConhecimentoFrete()
        {
        }

        public TList_ProcConhecimentoFrete(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcConhecimentoFrete value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcConhecimentoFrete x, TRegistro_ProcConhecimentoFrete y)
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
    public class TRegistro_ProcConhecimentoFrete
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public decimal? Nr_ctrc { get; set; } = null;
        public decimal? Nr_lanctoCTR { get; set; } = null;
        public string Cd_cfop { get; set; } = string.Empty;
        public DateTime? Dt_documento { get; set; } = null;
        public string Nr_serie { get; set; } = string.Empty;
        public string Cd_transportadora { get; set; } = string.Empty;
        public string Nm_transportadora { get; set; } = string.Empty;
        public string Cd_movimentacao { get; set; } = string.Empty;
        public string Ds_movimentacao { get; set; } = string.Empty;
        private decimal? cd_contadeb = null;
        public decimal? CD_ContaDeb
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contadebstr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contadebstr = string.Empty;
        public string Cd_contadebstr
        {
            get
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr;
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        public string Ds_contadeb { get; set; } = string.Empty;
        public string Cd_classificacaodeb { get; set; } = string.Empty;
        private decimal? cd_contacre = null;
        public decimal? CD_ContaCre
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value.Value.Equals(decimal.Zero) ? null : value;
                cd_contacrestr = value.Value.Equals(decimal.Zero) ? string.Empty : value.Value.ToString();
            }
        }
        private string cd_contacrestr = string.Empty;
        public string Cd_contacrestr
        {
            get
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr;
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        public string Ds_contacred { get; set; } = string.Empty;
        public string Cd_classificacaocred { get; set; } = string.Empty;
        private decimal? cd_contactb_D = null;
        public decimal? Cd_contactb_D
        {
            get { return cd_contactb_D; }
            set
            {
                cd_contactb_D = value;
                cd_contactb_Dstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Dstr = string.Empty;
        public string Cd_contactb_Dstr
        {
            get { return cd_contactb_Dstr; }
            set
            {
                cd_contactb_Dstr = value;
                try
                {
                    cd_contactb_D = decimal.Parse(value);
                }
                catch { cd_contactb_D = null; }
            }
        }
        private decimal? cd_contactb_C = null;
        public decimal? Cd_contactb_C
        {
            get { return cd_contactb_C; }
            set
            {
                cd_contactb_C = value;
                cd_contactb_Cstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contactb_Cstr = string.Empty;
        public string Cd_contactb_Cstr
        {
            get { return cd_contactb_Cstr; }
            set
            {
                cd_contactb_Cstr = value;
                try
                {
                    cd_contactb_C = decimal.Parse(value);
                }
                catch { cd_contactb_C = null; }
            }
        }
        public decimal? Id_loteCTB { get; set; } = null;
        public decimal Vl_lancto { get; set; } = decimal.Zero;
        public bool St_processar { get; set; } = false;
    }
    public class TCD_ProcConhecimentoFrete: TDataQuery
    {
        public TCD_ProcConhecimentoFrete() { }

        public TCD_ProcConhecimentoFrete(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT a.cd_empresa, b.nm_empresa, a.Nr_docto, a.CD_CFOP, ");
            sql.AppendLine("a.DT_SaiEnt, a.NR_LanctoCTR, a.Nr_Serie, a.CD_Transportadora, a.valor, ");
            sql.AppendLine("a.Cd_Movimentacao, c.Ds_Movimentacao, d.nm_clifor as nm_transportadora, ");
            sql.AppendLine("a.id_lotectb, a.CD_CONTACTB_CRE, f.DS_ContaCTB as DS_CONTACTB_CRE, ");
            sql.AppendLine("f.CD_Classificacao as CD_Classificacao_CRE, a.CD_ContaCTB_D, ");
            sql.AppendLine("a.CD_CONTACTB_DEB, g.DS_ContaCTB as DS_ContaCTB_DEB, ");
            sql.AppendLine("g.CD_Classificacao as CD_Classificacao_DEB, a.CD_ContaCTB_C ");

            sql.AppendLine("from VTB_CTB_ProcConhecimentoFrete a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fis_movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.cd_movimentacao ");
            sql.AppendLine("inner join tb_fin_clifor d ");
            sql.AppendLine("on a.cd_transportadora = d.cd_clifor ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas f ");
            sql.AppendLine("on a.CD_CONTACTB_CRE = f.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g ");
            sql.AppendLine("on a.CD_CONTACTB_DEB = g.CD_Conta_CTB ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_saient ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_ProcConhecimentoFrete Select(TpBusca[] vBusca)
        {
            TList_ProcConhecimentoFrete lista = new TList_ProcConhecimentoFrete();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca));
                while (reader.Read())
                {
                    TRegistro_ProcConhecimentoFrete reg = new TRegistro_ProcConhecimentoFrete();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_docto")))
                        reg.Nr_ctrc = reader.GetDecimal(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_documento = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoCTR = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("Cd_Movimentacao")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("Ds_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTACTB_CRE")))
                        reg.Ds_contacred = reader.GetString(reader.GetOrdinal("DS_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRE")))
                        reg.Cd_classificacaocred = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB_DEB")))
                        reg.Ds_contadeb = reader.GetString(reader.GetOrdinal("DS_ContaCTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.Cd_classificacaodeb = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_D")))
                        reg.Cd_contactb_D = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_D"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaCTB_C")))
                        reg.Cd_contactb_C = reader.GetDecimal(reader.GetOrdinal("CD_ContaCTB_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));

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
    }
    #endregion
}