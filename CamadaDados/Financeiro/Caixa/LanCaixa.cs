using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Caixa
{
    #region Caixa
    public class TList_LanCaixa : List<TRegistro_LanCaixa>, IComparer<TRegistro_LanCaixa>
    {
        #region IComparer<TRegistro_LanCaixa> Members
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

        public TList_LanCaixa()
        { }

        public TList_LanCaixa(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanCaixa x, TRegistro_LanCaixa y)
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
    
    public class TRegistro_LanCaixa
    {
        private string cd_ContaGer;
        public string Cd_ContaGer
        {
            get { return cd_ContaGer; }
            set { cd_ContaGer = value; }
        }
        private decimal cd_LanctoCaixa;
        public decimal Cd_LanctoCaixa
        {
            get { return cd_LanctoCaixa; }
            set { cd_LanctoCaixa = value; }
        }
        private string cd_Empresa;
        public string Cd_Empresa
        {
            get { return cd_Empresa; }
            set { cd_Empresa = value; }
        }
        private string nr_Docto;
        public string Nr_Docto
        {
            get { return nr_Docto; }
            set { nr_Docto = value; }
        }
        private string cd_Historico;
        public string Cd_Historico
        {
            get { return cd_Historico; }
            set { cd_Historico = value; }
        }
        public string Cd_centroresult
        { get; set; }
        private string complHistorico;
        public string ComplHistorico
        {
            get { return complHistorico; }
            set { complHistorico = value; }
        }
        public decimal? ID_LoteCTB
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set 
            { 
                dt_lancto = value;
                dt_lanctostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_lanctostring;
        public string Dt_lanctostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostring).ToString("dd/MM/yyyy");
                }
                catch
                {
                    return "";
                }
            }
            set 
            { 
                dt_lanctostring = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_lancto = null;
                }
            }
        }
        private decimal vl_PAGAR;
        public decimal Vl_PAGAR
        {
            get { return Math.Round(vl_PAGAR, 2); }
            set { vl_PAGAR = Math.Round(value, 2);
                  vl_Atual = vl_Anterior - Vl_PAGAR;
            }
        }
        private decimal vl_RECEBER;
        public decimal Vl_RECEBER
        {
            get { return Math.Round(vl_RECEBER, 2); }
            set { vl_RECEBER = Math.Round(value, 2);
                  vl_Atual = vl_Anterior + vl_RECEBER;
            }
        }
        private decimal vl_Anterior;
        public decimal Vl_Anterior
        {
            get { return Math.Round(vl_Anterior, 2); }
            set { vl_Anterior = Math.Round(value, 2); }
        }
        private decimal vl_Atual;
        public decimal Vl_Atual
        {
            get { return Math.Round(vl_Atual, 2); }
            set { vl_Atual = Math.Round(value, 2); }
        }
        private string cd_classif_DEB;
        public string Cd_classif_DEB
        {
            get { return cd_classif_DEB; }
            set { cd_classif_DEB = value; }
        }
        private string cd_classif_CRED;
        public string Cd_classif_CRED
        {
            get { return cd_classif_CRED; }
            set { cd_classif_CRED = value; }
        }
        private string st_Titulo;
        public string St_Titulo
        {
            get { return st_Titulo; }
            set 
            { 
                st_Titulo = value;
                if (value.Trim().ToUpper().Equals("S"))
                    status_titulo = "SIM";
                else if (value.Trim().ToUpper().Equals("N"))
                    status_titulo = "NAO";
                else if (value.Trim().ToUpper().Equals("F"))
                    status_titulo = "TRANSF";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_titulo = "COMPENSAÇÃO";
            }
        }
        private string status_titulo;
        public string Status_titulo
        {
            get { return status_titulo; }
            set 
            { 
                status_titulo = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                    st_Titulo = "S";
                else if (value.Trim().ToUpper().Equals("NAO"))
                    st_Titulo = "N";
                else if (value.Trim().ToUpper().Equals("TRANSF"))
                    st_Titulo = "F";
                else if (value.Trim().ToUpper().Equals("COMPENSAÇÃO"))
                    st_Titulo = "C";
            }
        }
        private string st_Estorno;
        public string St_Estorno
        {
            get { return st_Estorno; }
            set 
            { 
                st_Estorno = value;
                if (value.Trim().ToUpper().Equals("S"))
                    status_estorno = "SIM";
                else if (value.Trim().ToUpper().Equals("N"))
                    status_estorno = "NAO";
            }
        }
        private string status_estorno;
        public string Status_estorno
        {
            get { return status_estorno; }
            set 
            { 
                status_estorno = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                    st_Estorno = "S";
                else if (value.Trim().ToUpper().Equals("NAO"))
                    st_Estorno = "N";
            }
        }
        private string ds_Contager;
        public string Ds_ContaGer
        {
            get { return ds_Contager; }
            set { ds_Contager = value; }
        }
        private string nm_empresa;
        public string Nm_empresa
        {
            get { return nm_empresa; }
            set { nm_empresa = value; }
        }
        private string ds_historico;
        public string Ds_historico
        {
            get { return ds_historico; }
            set { ds_historico = value; }
        }
        public string NM_Clifor { get; set; }
        public decimal SaldoAnterior { get; set; }
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Sigla
        { get; set; }
        public string Login
        { get; set; }
        public string Nr_cheque
        { get; set; }
        public string St_avulso
        { get; set; }
        public bool Status_avulso
        { get { return St_avulso.Trim().ToUpper().Equals("S"); } }
        public decimal? Id_adto
        { get; set; }
        public bool St_conciliar
        { get; set; }
        //Propriedade utlizada para identificar se o lançamento tem origem na comp. ch,
        //Finalidade: somente para não permitir a contabilização do caixa de comp.
        public CCustoLan.TList_LanCCustoLancto lCustoLancto
        { get; set; }
        public CCustoLan.TList_LanCCustoLancto lCustoLanDel
        { get; set; }

        private DateTime? dt_auditavulso;
        public DateTime? Dt_auditavulso
        {
            get { return dt_auditavulso; }
            set
            {
                dt_auditavulso = value;
                dt_auditavulsostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_auditavulsostr;
        public string Dt_auditavulsostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_auditavulsostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_auditavulsostr = value;
                try
                {
                    dt_auditavulso = Convert.ToDateTime(value);
                }
                catch { dt_auditavulso = null; }
            }
        }
        public string LoginAuditAvulso
        { get; set; }
        public bool St_Avulso
        { get; set; }

        public TRegistro_LanCaixa()
        {
            ID_LoteCTB = null;
            cd_ContaGer = string.Empty;
            cd_LanctoCaixa = decimal.Zero;
            cd_Empresa = string.Empty;
            nr_Docto = string.Empty;
            cd_Historico = string.Empty;
            Cd_centroresult = string.Empty;
            complHistorico = string.Empty;
            dt_lancto = DateTime.Now;
            dt_lanctostring = DateTime.Now.ToString("dd/MM/yyyy");
            vl_PAGAR = decimal.Zero;
            vl_RECEBER = decimal.Zero;
            vl_Anterior = decimal.Zero;
            vl_Atual = decimal.Zero;
            st_Titulo = string.Empty;
            status_titulo = string.Empty;
            st_Estorno = string.Empty;
            status_estorno = string.Empty;
            ds_Contager = string.Empty;
            nm_empresa = string.Empty;
            ds_historico = string.Empty;
            SaldoAnterior = decimal.Zero;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Login = string.Empty;
            Nr_cheque = string.Empty;
            St_avulso = "N";
            Id_adto = null;
            St_conciliar = false;
            lCustoLancto = new CCustoLan.TList_LanCCustoLancto();
            lCustoLanDel = new CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_LanCaixa : TDataQuery
    {
        public TCD_LanCaixa() 
        { }

        public TCD_LanCaixa(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public TCD_LanCaixa(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        public TCD_LanCaixa(string vNM_ProcSqlBusca, BancoDados.TObjetoBanco banco)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select a.cd_ContaGer, c.ds_contager, a.cd_LanctoCaixa, a.cd_Empresa, a.nr_Docto, a.login, a.ComplHistorico, a.st_avulso, ");
                 sql.AppendLine("a.cd_Historico, a.dt_lancto, a.vl_PAGAR, a.vl_RECEBER, a.vl_Anterior, a.vl_Atual, isNull(a.st_Titulo, 'N') as st_titulo, isNull(a.st_Estorno, 'N')as st_estorno, ");
                 sql.AppendLine("b.nm_empresa, c.ds_contager, d.ds_historico, a.ID_LoteCTB,  a.NM_clifor, moeda.cd_moeda, moeda.ds_moeda_singular, moeda.sigla, ");
                 sql.AppendLine("cd_classif_DEB = (select y.cd_classificacao from tb_ctb_lanctosCTB x join tb_ctb_planoContas y on x.cd_conta_ctb = y.cd_conta_ctb where x.id_loteCTB = a.Id_LoteCTB and x.D_C = 'D'), ");
                 sql.AppendLine("cd_classif_CRED = (select y.cd_classificacao from tb_ctb_lanctosCTB x join tb_ctb_planoContas y on x.cd_conta_ctb = y.cd_conta_ctb where x.id_loteCTB = a.Id_LoteCTB and x.D_C = 'C'), " +
                     "a.DT_AuditAvulso, a.ST_Avulso, a.LoginAuditAvulso, ");
                 sql.AppendLine("nr_cheque = (select top 1 y.nr_cheque from tb_fin_titulo_x_caixa x ");
                 sql.AppendLine("                inner join tb_fin_titulo y ");
                 sql.AppendLine("                on x.cd_empresa = y.cd_empresa ");
                 sql.AppendLine("                and x.cd_banco = y.cd_banco ");
                 sql.AppendLine("                and x.nr_lanctocheque = y.nr_lanctocheque ");
                 sql.AppendLine("                and x.cd_contager = a.cd_contager ");
                 sql.AppendLine("                and x.cd_lanctocaixa = a.cd_lanctocaixa) ");
            }
           else
           {
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
           }

           sql.AppendLine("from tb_fin_caixa a ");
           sql.AppendLine("inner join tb_DIV_empresa  b ");
           sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
           sql.AppendLine("inner join tb_fin_contager c ");
           sql.AppendLine("on c.cd_contager = a.cd_contager ");
           sql.AppendLine("inner join tb_fin_moeda moeda ");
           sql.AppendLine("on c.cd_moeda = moeda.cd_moeda ");
           sql.AppendLine("inner join tb_fin_historico d ");
           sql.AppendLine("on d.cd_historico = a.cd_historico ");
           sql.AppendLine("left outer join tb_fin_Adiantamento_x_caixa e ");
           sql.AppendLine("on e.cd_LAnctoCaixa = a.cd_lanctoCaixa ");
           sql.AppendLine("and e.cd_ContaGer = a.cd_ContaGer ");

           string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (vNM_Campo == "")
                sql.AppendLine(" Order by a.CD_ContaGer, FLOOR(CONVERT(FLOAT,convert(datetime, a.DT_Lancto))), a.CD_LanctoCaixa ");
            return sql.ToString();
        }
                
        public string SqlCodeBusca_SINT_EMP_DATA(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_Empresa, b.Nm_empresa, ");
                sql.AppendLine("a.dt_lancto, ");
                sql.AppendLine("SUM(a.vl_PAGAR) as Tot_Pagar, ");
                sql.AppendLine("SUM(a.vl_RECEBER) AS Tot_Receber, ");
                sql.AppendLine("Tot_SaldoAnt = (select isnull(sum(x.vl_receber - x.vl_pagar),0) from tb_fin_caixa x where x.cd_empresa = a.cd_Empresa and x.dt_lancto < a.dt_lancto), ");
                sql.AppendLine("SUM(a.vl_RECEBER - A.VL_PAGAR) as Tot_Saldo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_caixa a inner join tb_DIV_empresa  b on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("					inner join tb_fin_contager c on c.cd_contager = a.cd_contager ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("group by a.cd_empresa, b.Nm_empresa, a.dt_lancto ");

            return sql.ToString();
        }

        public string SqlCodeBusca_SINT_EMP_CONTA_DATA(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_Empresa, b.Nm_empresa, a.CD_ContaGer, c.DS_ContaGer, ");
                sql.AppendLine("a.dt_lancto, ");
                sql.AppendLine("SUM(a.vl_PAGAR) as Tot_Pagar, ");
                sql.AppendLine("SUM(a.vl_RECEBER) AS Tot_Receber, ");
                sql.AppendLine("Tot_SaldoAnt = (select isnull(sum(x.vl_receber - x.vl_pagar),0) from tb_fin_caixa x where x.cd_empresa = a.cd_Empresa and x.cd_contager = a.cd_contager and x.dt_lancto < a.dt_lancto), ");
                sql.AppendLine("SUM(a.vl_RECEBER - A.VL_PAGAR) as Tot_Saldo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_caixa a inner join tb_DIV_empresa  b on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("					inner join tb_fin_contager c on c.cd_contager = a.cd_contager ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("group by a.cd_empresa, b.Nm_empresa, a.CD_ContaGer, c.DS_ContaGer, a.dt_lancto ");

            return sql.ToString();
        }

        public string sqlcodBuscar_Cheques(TpBusca[] filtro, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select a.cd_empresa,a.nr_lanctocheque,a.cd_banco,a.nr_cheque,a.nr_cgccpf,a.nomebanco,a.dt_compensacao,a.vl_titulo ,b.cd_contager,b.cd_lanctocaixa,b.nr_lanctocheque,c.cd_historico,c.dt_lancto,c.nm_clifor  ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("from tb_fin_titulo a  ");
            sql.AppendLine("inner join tb_fin_titulo_x_caixa b on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine(" and a.nr_lanctocheque = b.nr_lanctocheque and a.cd_banco = b.cd_banco ");
            sql.AppendLine(" inner join tb_fin_caixa c on b.cd_contager = c.cd_contager and b.cd_lanctocaixa = c.cd_lanctocaixa ");
            sql.AppendLine(" where isnull(c.st_estorno, 'N') <> 'S' and isnull(status_compensado, 'N') = 'N' ");
            string cond = " and ";

            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + " (" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                }
            return sql.ToString();
        }

        public string SqlCodeBuscaTotaisMapaFinanceiro(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_ContaGer, a.DS_ContaGer, ");
            sql.AppendLine("Vl_Saldo = isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from tb_fin_caixa x ");
            sql.AppendLine("                    where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and isnull(x.st_estorno, 'N') <> 'S'), 0), ");
            sql.AppendLine("Vl_ChRec = isnull((Select isnull(Sum(isnull(z.Vl_receber, 0)),0) ");
            sql.AppendLine("                    From tb_fin_titulo x ");
            sql.AppendLine("                    INNER JOIN tb_fin_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.cd_banco = y.cd_banco ");
            sql.AppendLine("                    and x.nr_lanctoCheque = y.nr_lanctoCheque ");
            sql.AppendLine("                    and x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                    INNER JOIN tb_fin_caixa z ");
            sql.AppendLine("                    on z.cd_contager = y.cd_contager ");
            sql.AppendLine("                    and z.cd_lanctocaixa = y.cd_lanctocaixa ");
            sql.AppendLine("                    where isnull(z.st_estorno,'N') <> 'S' ");
            sql.AppendLine("                    and z.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and x.Status_compensado = 'N' ");
            sql.AppendLine("                    and x.tp_titulo = 'R'), 0), ");
            sql.AppendLine("Vl_ChPag = isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from TB_FIN_Caixa x ");
            sql.AppendLine("                    inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                    and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                    inner join TB_FIN_Titulo z ");
            sql.AppendLine("                    on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                    and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                    and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                    where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                    and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                    and z.Tp_Titulo = 'P'), 0), ");
            sql.AppendLine("Vl_SaldoFuturo = (isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from tb_fin_caixa x ");
            sql.AppendLine("                            where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                            and isnull(x.st_estorno, 'N') <> 'S'), 0) - ");
            sql.AppendLine("                 isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from TB_FIN_Caixa x ");
            sql.AppendLine("                            inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                            on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                            and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                            inner join TB_FIN_Titulo z ");
            sql.AppendLine("                            on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                            and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                            and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                            where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                            and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                            and z.Tp_Titulo = 'P'), 0)) ");
            sql.AppendLine("From TB_FIN_ContaGer a ");
            sql.AppendLine("inner join TB_FIN_FluxoCaixa_X_ContaGer b ");
            sql.AppendLine("on a.CD_ContaGer = b.CD_ContaGer ");
            sql.AppendLine("inner join TB_FIN_ContaGer_X_Empresa c ");
            sql.AppendLine("on a.CD_ContaGer = c.CD_ContaGer ");
            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                }
            sql.AppendLine("order by a.cd_contager ");
            return sql.ToString();
        }

        public DataTable RelSinteticoContaGer(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_ContaGer, a.DS_ContaGer, a.cd_moeda, d.ds_moeda_singular, d.sigla, ");
            sql.AppendLine("e.cd_empresa, e.nm_empresa, ");
            //Valor Cambio Utilizado para Converter Valores
            sql.AppendLine("vl_cotacao = isnull((select x.valor ");
            sql.AppendLine("                    from tb_fin_cotacaomoeda x ");
            sql.AppendLine("                    where x.cd_moeda = a.cd_moeda ");
            sql.AppendLine("                    and x.data <= getdate() ");
            sql.AppendLine("                    and isnull(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("                    and x.cd_moedaresult = isnull((select top 1 y.vl_string from tb_cfg_paramger y ");
            sql.AppendLine("                    							where y.ds_parametro = 'CD_MOEDA_PADRAO'), '')), 0), ");
            //Valor Saldo Atual
            sql.AppendLine("Vl_Saldo = isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from tb_fin_caixa x ");
            sql.AppendLine("                    where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and isnull(x.st_estorno, 'N') <> 'S'), 0), ");
            //Valor Saldo Atual Moeda Padrao
            sql.AppendLine("Vl_SaldoMPadrao = dbo.F_CONV_MOEDA(a.cd_moeda, null, getdate(), 0, isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from tb_fin_caixa x ");
            sql.AppendLine("                    where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and isnull(x.st_estorno, 'N') <> 'S'), 0)), ");
            //Valor Cheque Receber
            sql.AppendLine("Vl_ChRec = isnull((Select isnull(Sum(isnull(z.Vl_receber, 0)),0) ");
            sql.AppendLine("                    From tb_fin_titulo x ");
            sql.AppendLine("                    INNER JOIN tb_fin_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.cd_banco = y.cd_banco ");
            sql.AppendLine("                    and x.nr_lanctoCheque = y.nr_lanctoCheque ");
            sql.AppendLine("                    and x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                    INNER JOIN tb_fin_caixa z ");
            sql.AppendLine("                    on z.cd_contager = y.cd_contager ");
            sql.AppendLine("                    and z.cd_lanctocaixa = y.cd_lanctocaixa ");
            sql.AppendLine("                    where isnull(z.st_estorno,'N') <> 'S' ");
            sql.AppendLine("                    and z.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and x.Status_compensado = 'N' ");
            sql.AppendLine("                    and x.tp_titulo = 'R'), 0), ");
            //Valor Cheque Receber Moeda Padrao
            sql.AppendLine("Vl_ChRecMPadrao = dbo.F_CONV_MOEDA(a.cd_moeda, null, getdate(), 0, isnull((Select isnull(Sum(isnull(z.Vl_receber, 0)),0) ");
            sql.AppendLine("                    From tb_fin_titulo x ");
            sql.AppendLine("                    INNER JOIN tb_fin_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.cd_banco = y.cd_banco ");
            sql.AppendLine("                    and x.nr_lanctoCheque = y.nr_lanctoCheque ");
            sql.AppendLine("                    and x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                    INNER JOIN tb_fin_caixa z ");
            sql.AppendLine("                    on z.cd_contager = y.cd_contager ");
            sql.AppendLine("                    and z.cd_lanctocaixa = y.cd_lanctocaixa ");
            sql.AppendLine("                    where isnull(z.st_estorno,'N') <> 'S' ");
            sql.AppendLine("                    and z.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and x.Status_compensado = 'N' ");
            sql.AppendLine("                    and x.tp_titulo = 'R'), 0)), ");
            //Valor Cheque Pagar
            sql.AppendLine("Vl_ChPag = isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from TB_FIN_Caixa x ");
            sql.AppendLine("                    inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                    and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                    inner join TB_FIN_Titulo z ");
            sql.AppendLine("                    on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                    and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                    and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                    where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                    and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                    and z.Tp_Titulo = 'P'), 0), ");
            //Valor Cheque Pagar Moeda Padrao
            sql.AppendLine("Vl_ChPagMPadrao = dbo.F_CONV_MOEDA(a.cd_moeda, null, getdate(), 0, isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                    from TB_FIN_Caixa x ");
            sql.AppendLine("                    inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                    on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                    and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                    inner join TB_FIN_Titulo z ");
            sql.AppendLine("                    on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                    and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                    and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                    where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                    and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                    and z.Tp_Titulo = 'P'), 0)), ");
            //Valor Saldo Futuro
            sql.AppendLine("Vl_SaldoFuturo = (isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from tb_fin_caixa x ");
            sql.AppendLine("                            where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                            and isnull(x.st_estorno, 'N') <> 'S'), 0) - ");
            sql.AppendLine("                 isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from TB_FIN_Caixa x ");
            sql.AppendLine("                            inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                            on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                            and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                            inner join TB_FIN_Titulo z ");
            sql.AppendLine("                            on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                            and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                            and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                            where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                            and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                            and z.Tp_Titulo = 'P'), 0)), ");
            //Valor Saldo Futuro Moeda Padrao
            sql.AppendLine("Vl_SaldoFuturoMPadrao = dbo.F_CONV_MOEDA(a.cd_moeda, null, getdate(), 0, (isnull((select isnull(sum(isnull(x.vl_receber, 0)), 0) - isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from tb_fin_caixa x ");
            sql.AppendLine("                            where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                            and isnull(x.st_estorno, 'N') <> 'S'), 0) - ");
            sql.AppendLine("                 isnull((select isnull(sum(isnull(x.vl_pagar, 0)), 0) ");
            sql.AppendLine("                            from TB_FIN_Caixa x ");
            sql.AppendLine("                            inner join TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("                            on x.CD_ContaGer = y.CD_ContaGer ");
            sql.AppendLine("                            and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
            sql.AppendLine("                            inner join TB_FIN_Titulo z ");
            sql.AppendLine("                            on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("                            and y.CD_Banco = z.CD_Banco ");
            sql.AppendLine("                            and y.Nr_LanctoCheque = z.Nr_LanctoCheque ");
            sql.AppendLine("                            where isnull(z.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                            and x.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("                            and z.Tp_Titulo = 'P'), 0))) ");

            sql.AppendLine("From TB_FIN_ContaGer a ");
            sql.AppendLine("inner join TB_FIN_ContaGer_X_Empresa c ");
            sql.AppendLine("on a.CD_ContaGer = c.CD_ContaGer ");
            sql.AppendLine("inner join tb_fin_moeda d ");
            sql.AppendLine("on a.cd_moeda = d.cd_moeda ");
            sql.AppendLine("inner join tb_div_empresa e ");
            sql.AppendLine("on c.cd_empresa = e.cd_empresa ");
            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                }
            sql.AppendLine("order by a.cd_contager ");

            return ExecutarBusca(sql.ToString(), null);
        }

        public decimal TotChequeRec(TpBusca[] filtro)
        {
            string sql = "select isnull(sum(isnull(c.vl_receber,0)),0)\r\n " +
                         "from tb_fin_titulo a\r\n " +
                         "inner join tb_fin_titulo_x_caixa b\r\n " +
                         "on a.cd_banco = b.cd_banco\r\n " +
                         "and a.nr_lanctocheque = b.nr_lanctocheque\r\n " +
                         "and a.cd_empresa = b.cd_empresa\r\n " +
                         "inner join tb_fin_caixa c\r\n " +
                         "on b.cd_contager = c.cd_contager\r\n " +
                         "and b.cd_lanctocaixa = c.cd_lanctocaixa\r\n " +
                         "where isnull(status_compensado, 'N') = 'N'\r\n " +
                         "and isnull(c.st_estorno, 'N') <> 'S'\r\n " +
                         "and a.tp_titulo = 'R'\r\n ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql += "and " + filtro[i].vNM_Campo.Trim() + " " + filtro[i].vOperador.Trim() + " " + filtro[i].vVL_Busca.Trim() + "\r\n";
            object obj = ExecutarBuscaEscalar(sql.Trim(), null);
            if (obj != null)
            {
                try
                {
                    return Convert.ToDecimal(obj.ToString());
                }
                catch
                { return 0; }
            }
            else
                return 0;
        }

        public decimal TotChequePag(TpBusca[] filtro)
        {
            string sql = "select isnull(sum(isnull(c.vl_pagar,0)),0)\r\n " +
                         "from tb_fin_titulo a\r\n " +
                         "inner join tb_fin_titulo_x_caixa b\r\n " +
                         "on a.cd_banco = b.cd_banco\r\n " +
                         "and a.nr_lanctocheque = b.nr_lanctocheque\r\n " +
                         "and a.cd_empresa = b.cd_empresa\r\n " +
                         "inner join tb_fin_caixa c\r\n " +
                         "on b.cd_contager = c.cd_contager\r\n " +
                         "and b.cd_lanctocaixa = c.cd_lanctocaixa\r\n " +
                         "where isnull(status_compensado, 'N') = 'N'\r\n " +
                         "and isnull(c.st_estorno, 'N') <> 'S'\r\n " +
                         "and a.tp_titulo = 'P'\r\n ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql += "and " + filtro[i].vNM_Campo.Trim() + " " + filtro[i].vOperador.Trim() + " " + filtro[i].vVL_Busca.Trim() + "\r\n";
            object obj = ExecutarBuscaEscalar(sql.Trim(), null);
            if (obj != null)
            {
                try
                {
                    return Convert.ToDecimal(obj.ToString());
                }
                catch
                { return 0; }
            }
            else
                return 0;
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
              if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
              else
              {
                  string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, ""}).ToString();
                    return ExecutarBusca(sql,null);
              }           
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public DataTable buscarChequesACompensar(TpBusca[] vBusca)
        {
            return ExecutarBusca(sqlcodBuscar_Cheques(vBusca, 0, ""), null);
        }

        public DataTable BuscarMapaFinanceiro(TpBusca[] filtro)
        {
            return ExecutarBusca(SqlCodeBuscaTotaisMapaFinanceiro(filtro), null);
        }

        public DataTable BuscarRelTransacaoCaixa(TpBusca[] filtro, string vOrder)
        {
            string sql = "select c.cd_empresa, c.nm_empresa, a.st_estorno, g.nr_cheque, a.nm_clifor, \r\n" +
                         "case when isnull(g.nr_cheque, '') <> '' then observacao else a.complhistorico end as complhistorico, \r\n" +
                         "a.cd_lanctocaixa, a.cd_contager, b.ds_contager, a.dt_lancto, a.nr_docto, \r\n" +
                         "d.cd_historico, d.ds_historico, a.vl_receber, a.vl_pagar, \r\n" +
                         "a.vl_anterior, a.vl_atual, a.st_titulo \r\n" +
                         "from tb_fin_caixa a \r\n" +
                         "inner join tb_fin_contager b \r\n" +
                         "on a.cd_contager = b.cd_contager \r\n" +
                         "inner join tb_div_empresa c \r\n" +
                         "on a.cd_empresa = c.cd_empresa \r\n" +
                         "inner join tb_fin_historico d \r\n" +
                         "on a.cd_historico = d.cd_historico \r\n" +
                         "left outer join tb_fin_banco e \r\n" +
                         "on b.cd_banco = e.cd_banco \r\n" +
                         "left outer join tb_fin_titulo_x_caixa f \r\n" +
                         "on a.cd_contager = f.cd_contager \r\n" +
                         "and a.cd_lanctocaixa = f.cd_lanctocaixa \r\n" +
                         "left outer join tb_fin_titulo g \r\n" +
                         "on f.cd_banco = g.cd_banco \r\n" +
                         "and f.cd_empresa = g.cd_empresa \r\n" +
                         "and f.nr_lanctocheque = g.nr_lanctocheque \r\n";
            if (filtro != null)
            {
                string cond = " where ";
                foreach (TpBusca f in filtro)
                {
                    sql += cond + "(" + f.vNM_Campo.Trim() + " " + f.vOperador.Trim() + " " + f.vVL_Busca.Trim() + ")";
                    cond = " and ";
                }
            }
            if (vOrder.Trim() != string.Empty)
                sql += "order by " + vOrder.Trim();
            return ExecutarBusca(sql.Trim(), null);
        }

        public TList_LanCaixa Select(TpBusca[] vBusca, Int32 vTop, string vNm_campo)
        {
            TList_LanCaixa lista = new TList_LanCaixa();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanCaixa LanCaixa = new TRegistro_LanCaixa();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        LanCaixa.Cd_ContaGer = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        LanCaixa.Ds_ContaGer = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_LanctoCaixa")))
                        LanCaixa.Cd_LanctoCaixa = reader.GetDecimal(reader.GetOrdinal("Cd_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        LanCaixa.Cd_Empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        LanCaixa.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        LanCaixa.Nr_Docto = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        LanCaixa.Cd_Historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ComplHistorico")))
                        LanCaixa.ComplHistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_historico")))
                        LanCaixa.Ds_historico = reader.GetString(reader.GetOrdinal("DS_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        LanCaixa.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_PAGAR")))
                        LanCaixa.Vl_PAGAR = reader.GetDecimal(reader.GetOrdinal("VL_PAGAR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_RECEBER")))
                        LanCaixa.Vl_RECEBER = reader.GetDecimal(reader.GetOrdinal("VL_RECEBER"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CLASSIF_DEB")))
                        LanCaixa.Cd_classif_DEB = reader.GetString(reader.GetOrdinal("CD_Classif_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CLASSIF_CRED")))
                        LanCaixa.Cd_classif_CRED = reader.GetString(reader.GetOrdinal("CD_Classif_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOTECTB")))
                        LanCaixa.ID_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LOTECTB"));

                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Atual")))
                        LanCaixa.Vl_Atual = reader.GetDecimal(reader.GetOrdinal("VL_Atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Anterior")))
                        LanCaixa.Vl_Anterior = reader.GetDecimal(reader.GetOrdinal("VL_Anterior")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Titulo")))
                        LanCaixa.St_Titulo = reader.GetString(reader.GetOrdinal("ST_Titulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Estorno")))
                        LanCaixa.St_Estorno = reader.GetString(reader.GetOrdinal("ST_Estorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        LanCaixa.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        LanCaixa.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        LanCaixa.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        LanCaixa.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        LanCaixa.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Cheque")))
                        LanCaixa.Nr_cheque = reader.GetString(reader.GetOrdinal("NR_Cheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Avulso")))
                        LanCaixa.St_avulso = reader.GetString(reader.GetOrdinal("ST_Avulso"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DT_AuditAvulso")))
                        LanCaixa.Dt_auditavulso = reader.GetDateTime(reader.GetOrdinal("DT_AuditAvulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAuditAvulso")))
                        LanCaixa.LoginAuditAvulso = reader.GetString(reader.GetOrdinal("LoginAuditAvulso"));

                    lista.Add(LanCaixa);
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

        public object BuscarSaldoCaixa(string Cd_contager)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select isnull(sum(isnull(vl_receber, 0) - isnull(vl_pagar, 0)), 0) ");
            sql.AppendLine("from tb_fin_caixa ");
            sql.AppendLine("where cd_contager = '" + Cd_contager.Trim() + "'");
            sql.AppendLine("and isnull(st_estorno, 'N') <> 'S'");

            return ExecutarBuscaEscalar(sql.ToString(), null);
        }

        public string Grava(TRegistro_LanCaixa val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_CONTAGER"     , val.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA"  , val.Cd_LanctoCaixa);
            hs.Add("@P_CD_EMPRESA"      , val.Cd_Empresa);
            hs.Add("@P_NR_DOCTO"        , val.Nr_Docto);
            hs.Add("@P_CD_HISTORICO"    , val.Cd_Historico);
            hs.Add("@P_COMPLHISTORICO"  , val.ComplHistorico);
            hs.Add("@P_NM_CLIFOR"       , val.NM_Clifor);
            hs.Add("@P_DT_LANCTO"       , val.Dt_lancto);
            if (val.Vl_PAGAR > 0)
            {
                hs.Add("@P_VALOR", val.Vl_PAGAR);
                hs.Add("@P_TP_MOV", "P");
            }
            else
            {
                hs.Add("@P_VALOR", val.Vl_RECEBER);
                hs.Add("@P_TP_MOV", "R");
            }
            hs.Add("@P_ST_TITULO", val.St_Titulo);
            hs.Add("@P_ST_ESTORNO", val.St_Estorno);
            hs.Add("@P_LOGIN", Utils.Parametros.pubLogin);
            hs.Add("@P_ST_AVULSO", val.St_avulso);
            hs.Add("@P_LOGINAUDITAVULSO", val.LoginAuditAvulso);
            hs.Add("@P_DT_AUDITAVULSO", val.Dt_auditavulso);

            return executarProc("IA_FIN_CAIXA", hs);
        }

        public string Altera(TRegistro_LanCaixa val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_CONTAGER", val.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_LanctoCaixa);
            hs.Add("@P_NR_DOCTO", val.Nr_Docto);
            hs.Add("@P_CD_HISTORICO", val.Cd_Historico);
            hs.Add("@P_COMPLHISTORICO", val.ComplHistorico);
            hs.Add("@P_NM_CLIFOR", val.NM_Clifor);
            hs.Add("@P_ST_TITULO", val.St_Titulo);
            hs.Add("@P_ST_ESTORNO", val.St_Estorno);

            return executarProc("ALTERA_FIN_CAIXA", hs);
        }
        
        public void Deleta(TRegistro_LanCaixa val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_CONTAGER", val.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_LanctoCaixa);
            hs.Add("@P_DT_ESTORNO", val.Dt_lancto);
            executarProc("ESTORNA_CAIXA", hs);
        }

        public void Recalcula(TRegistro_LanCaixa val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_CONTAGER", val.Cd_ContaGer);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            
            executarProc("RECALCULA_CAIXA", hs);        
        }
    }
    #endregion

    #region Estorno Caixa
    public class TList_EstornoCaixa : List<TRegistro_LanEstornoCaixa>
    { }
    
    public class TRegistro_LanEstornoCaixa
    {
        public string Cd_contager
        { get; set; }
        public decimal Cd_lancto_origem
        { get; set; }
        public decimal Cd_lancto_estorno
        { get; set; }
        public decimal Id_estorno
        { get; set; }
        public string Login
        { get; set; }

        public TRegistro_LanEstornoCaixa()
        {
            Cd_contager = string.Empty;
            Cd_lancto_origem = decimal.Zero;
            Cd_lancto_estorno = decimal.Zero;
            Id_estorno = decimal.Zero;
            Login = string.Empty;
        }
    }

    public class TCD_EstornoCaixa : TDataQuery
    {
        public TCD_EstornoCaixa()
        { }

        public TCD_EstornoCaixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_campo))
                sql.AppendLine("Select "+strTop + " a.cd_contager, a.cd_lanctoorigem, a.cd_lanctodestino, a.id_estorno, a.login ");

            else
                sql.AppendLine("Select " + strTop + " " + vNm_campo + " ");

            sql.AppendLine("from tb_fin_estorno_caixa a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_EstornoCaixa Select(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            TList_EstornoCaixa lista = new TList_EstornoCaixa();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanEstornoCaixa reg = new TRegistro_LanEstornoCaixa();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoOrigem")))
                        reg.Cd_lancto_origem = reader.GetDecimal(reader.GetOrdinal("CD_LanctoOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_LanctoEstorno")))
                        reg.Cd_lancto_estorno = reader.GetDecimal(reader.GetOrdinal("Cd_LanctoEstorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Estorno")))
                        reg.Id_estorno = reader.GetDecimal(reader.GetOrdinal("ID_Estorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));

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

        public string GravarEstornoCaixa(TRegistro_LanEstornoCaixa val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOORIGEM", val.Cd_lancto_origem);
            hs.Add("@P_CD_LANCTOESTORNO", val.Cd_lancto_estorno);
            hs.Add("@P_ID_ESTORNO", val.Id_estorno);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("IA_FIN_ESTORNO_CAIXA", hs);
        }

        public string DeletarEstornoCaixa(TRegistro_LanEstornoCaixa val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOORIGEM", val.Cd_lancto_origem);
            hs.Add("@P_CD_LANCTOESTORNO", val.Cd_lancto_estorno);
            hs.Add("@P_ID_ESTORNO", val.Id_estorno);

            return executarProc("EXCLUI_FIN_ESTORNO_CAIXA", hs);
        }
    }
    #endregion

    #region Caixa X Centro Resultado
    public class TList_Caixa_X_Ccusto : List<TRegistro_Caixa_X_CCusto>
    { }
    
    public class TRegistro_Caixa_X_CCusto
    {
        public string Cd_contager
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
                catch
                { cd_lanctocaixa = null; }
            }
        }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch
                { id_ccustolan = null; }
            }
        }

        public TRegistro_Caixa_X_CCusto()
        {
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            id_ccustolan = null;
            id_ccustolanstr = string.Empty;
        }
    }

    public class TCD_Caixa_X_CCusto : TDataQuery
    {
        public TCD_Caixa_X_CCusto()
        { }

        public TCD_Caixa_X_CCusto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.cd_contager, a.cd_lanctocaixa, a.id_ccustolan ");

            else
                sql.AppendLine("Select " + strTop + " " + vNm_campo + " ");

            sql.AppendLine("from tb_fin_caixa_x_ccusto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Caixa_X_Ccusto Select(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            TList_Caixa_X_Ccusto lista = new TList_Caixa_X_Ccusto();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Caixa_X_CCusto reg = new TRegistro_Caixa_X_CCusto();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CCustoLan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("ID_CCustoLan"));
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

        public string Gravar(TRegistro_Caixa_X_CCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("IA_FIN_CAIXA_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_Caixa_X_CCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_CAIXA_X_CCUSTO", hs);
        }
    }
    #endregion

    #region Movimento Caixa excluindo tipo documento
    public class TCD_RelMovCaixaTpDocto : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select d.DT_Lancto, a.Nr_Docto, d.NM_Clifor, a.tp_docto, g.DS_TpDocto, d.cd_empresa, d.cd_contager, ");
                sql.AppendLine("d.CD_Historico, e.DS_Historico, d.ComplHistorico, a.vl_documento_padrao, h.nm_empresa, i.ds_contager, ");
                sql.AppendLine("vl_pagar = (case when f.TP_MOV = 'P' then ISNULL(c.VL_Liquidacao_padrao, 0) - ");
                sql.AppendLine("										  ISNULL(c.Vl_DescontoBonus, 0) ");
                sql.AppendLine("									 else 0 end), ");
                sql.AppendLine("vl_receber = (case when f.TP_MOV = 'R' then ISNULL(c.VL_Liquidacao_padrao, 0) - ");
                sql.AppendLine("											ISNULL(c.Vl_DescontoBonus, 0) ");
                sql.AppendLine("										else 0 end) ");
            }
            else
                sql.AppendLine("select " + vNm_campo.Trim() + " ");

            sql.AppendLine("from tb_fin_duplicata a ");
            sql.AppendLine("inner join TB_FIN_Parcela b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.Nr_Lancto ");
            sql.AppendLine("inner join TB_FIN_Liquidacao c ");
            sql.AppendLine("on b.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("and b.Nr_Lancto = c.Nr_Lancto ");
            sql.AppendLine("and b.CD_Parcela = c.CD_Parcela ");
            sql.AppendLine("inner join TB_FIN_Caixa d ");
            sql.AppendLine("on c.CD_ContaGer = d.CD_ContaGer ");
            sql.AppendLine("and c.CD_LanctoCaixa = d.CD_LanctoCaixa ");
            sql.AppendLine("inner join TB_FIN_Historico e ");
            sql.AppendLine("on d.CD_Historico = e.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata f ");
            sql.AppendLine("on a.TP_Duplicata = f.TP_Duplicata ");
            sql.AppendLine("inner join TB_FIN_TPDocto_Dup g ");
            sql.AppendLine("on a.Tp_Docto = g.Tp_Docto ");
            sql.AppendLine("inner join tb_div_empresa h ");
            sql.AppendLine("on d.cd_empresa = h.cd_empresa ");
            sql.AppendLine("inner join tb_fin_contager i ");
            sql.AppendLine("on d.cd_contager = i.cd_contager ");
            string cond = " where ";
            if(filtro != null)
                foreach (TpBusca f in filtro)
                {
                    sql.AppendLine(cond + "(" + f.vNM_Campo + " " + f.vOperador + " " + f.vVL_Busca + ")");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public DataTable Buscar(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            return ExecutarBusca(SqlCodeBusca(filtro, vNm_campo, vOrder), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, vNM_Campo, string.Empty), null);
        }
    }
    #endregion

    #region Saldo Conta Gerencial - Painel Gerencial
    
    public class TRegistro_SaldoContaGer
    {
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public bool St_cc
        {get;set;}
        public decimal Vl_saldo
        { get; set; }
        public decimal Vl_chrecebido
        {get;set;}
        public decimal Vl_chemitido
        {get;set;}
        public decimal Vl_saldofuturo
        { get { return Vl_saldo - Vl_chemitido; } }
        
        public TRegistro_SaldoContaGer()
        {
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            St_cc = false;
            Vl_saldo = decimal.Zero;
            Vl_chrecebido = decimal.Zero;
            Vl_chemitido = decimal.Zero;
        }
    }

    public class TCD_SaldoContaGer : TDataQuery
    {
        public TCD_SaldoContaGer()
        { }

        public TCD_SaldoContaGer(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, string Cd_contageraplic)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_ContaGer, a.DS_ContaGer, ");
            sql.AppendLine("St_cc = case when (a.cd_banco is not null) and (isnull(a.st_contacompensacao, 'N') <> 'S') then 0 else 1 end, ");
            sql.AppendLine("vl_saldo = ISNULL((select SUM(ISNULL(x.Vl_RECEBER, 0) - ISNULL(x.Vl_PAGAR, 0)) ");
            sql.AppendLine("					from TB_FIN_Caixa x ");
            sql.AppendLine("					where x.CD_ContaGer = a.CD_ContaGer ");
            sql.AppendLine("					and ISNULL(x.ST_Estorno, 'N') <> 'S'), 0), ");
            sql.AppendLine("Vl_ChRec = isnull((Select isnull(Sum(isnull(x.Vl_Titulo, 0)),0) ");
            sql.AppendLine("                    From tb_fin_titulo x ");
            sql.AppendLine("                    where ISNULL(x.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                    and x.Tp_Titulo = 'R' ");
            sql.AppendLine("                    and exists(select 1 from TB_FIN_Titulo_X_Caixa y ");
            sql.AppendLine("								inner join TB_FIN_Caixa z ");
            sql.AppendLine("								on y.CD_ContaGer = z.CD_ContaGer ");
            sql.AppendLine("								and y.CD_LanctoCaixa = z.CD_LanctoCaixa ");
            sql.AppendLine("								where x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("								and x.CD_Banco = y.CD_Banco ");
            sql.AppendLine("								and x.Nr_LanctoCheque = y.Nr_LanctoCheque ");
            sql.AppendLine("								and ISNULL(z.ST_Estorno, 'N') <> 'S' ");
            sql.AppendLine("								and z.CD_ContaGer = a.CD_ContaGer)), 0), ");
            sql.AppendLine("Vl_ChPag = isnull((select isnull(sum(isnull(x.Vl_Titulo, 0)), 0) ");
            sql.AppendLine("                    from TB_FIN_Titulo x ");
            sql.AppendLine("                    where ISNULL(x.Status_Compensado, 'N') = 'N' ");
            sql.AppendLine("                    and x.Tp_Titulo = 'P' ");
            sql.AppendLine("                    and exists(select 1 from tb_fin_titulo_x_caixa y ");
            sql.AppendLine("								inner join TB_FIN_Caixa z ");
            sql.AppendLine("								on y.CD_ContaGer = z.CD_ContaGer ");
            sql.AppendLine("								and y.CD_LanctoCaixa = z.CD_LanctoCaixa ");
            sql.AppendLine("								where x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("								and x.CD_Banco = y.CD_Banco ");
            sql.AppendLine("								and x.Nr_LanctoCheque = y.Nr_LanctoCheque ");
            sql.AppendLine("								and ISNULL(z.ST_Estorno, 'N') <> 'S' ");
            sql.AppendLine("								and z.CD_ContaGer = a.CD_ContaGer_Compensacao)), 0) ");
            
            sql.AppendLine("from TB_FIN_ContaGer a ");
            sql.AppendLine("where ISNULL(a.ST_ContaCompensacao, 'N') <> 'S' ");
            sql.AppendLine("and a.ST_ContaCartao = 1 ");
            sql.AppendLine("and a.ST_ContaCF = 1 ");
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                sql.AppendLine("and exists(select 1 from TB_FIN_ContaGer_X_Empresa x ");
                sql.AppendLine("            where x.cd_contager = a.cd_contager ");
                sql.AppendLine("            and x.cd_empresa in (" + Cd_empresa.Trim() + "))");
            }
            if (!string.IsNullOrEmpty(Cd_contageraplic))
                sql.AppendLine("and a.cd_contager_aplic = '" + Cd_contageraplic.Trim() + "'");

            return sql.ToString();
        }

        public List<TRegistro_SaldoContaGer> Select(string Cd_empresa, string Cd_contageraplic)
        {
            bool podeFecharBco = false;
            List<TRegistro_SaldoContaGer> lista = new List<TRegistro_SaldoContaGer>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_contageraplic));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoContaGer reg = new TRegistro_SaldoContaGer();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_cc")))
                        reg.St_cc = reader.GetInt32(reader.GetOrdinal("st_cc")).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_saldo")))
                        reg.Vl_saldo = reader.GetDecimal(reader.GetOrdinal("vl_saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ChRec")))
                        reg.Vl_chrecebido = reader.GetDecimal(reader.GetOrdinal("Vl_ChRec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ChPag")))
                        reg.Vl_chemitido = reader.GetDecimal(reader.GetOrdinal("Vl_ChPag"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion
}