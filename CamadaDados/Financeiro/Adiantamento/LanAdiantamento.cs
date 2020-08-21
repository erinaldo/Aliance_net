using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Financeiro.Caixa;

namespace CamadaDados.Financeiro.Adiantamento
{
    #region Adiantamento
    public class TList_LanAdiantamento : List<TRegistro_LanAdiantamento>, IComparer<TRegistro_LanAdiantamento>
    {
        #region IComparer<TRegistro_LanAdiantamento> Members
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

        public TList_LanAdiantamento()
        { }

        public TList_LanAdiantamento(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanAdiantamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanAdiantamento x, TRegistro_LanAdiantamento y)
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
    
    public class TRegistro_LanAdiantamento
    {
        public decimal Id_adto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Ds_adto
        { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set 
            { 
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("C"))
                    tipo_movimento = "CONCEDIDO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBIDO";
            }
        }      
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set 
            { 
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("CONCEDIDO"))
                    tp_movimento = "C";
                else if (value.Trim().ToUpper().Equals("RECEBIDO"))
                    tp_movimento = "R";
            }
        }
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
                    return Convert.ToDateTime(dt_lanctostring.Trim()).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set 
            {
                dt_lanctostring = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        private DateTime? dt_prevdevolucao;
        public DateTime? Dt_prevdevolucao
        {
            get { return dt_prevdevolucao; }
            set
            {
                dt_prevdevolucao = value;
                dt_prevdevolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_prevdevolucaostr;
        public string Dt_prevdevolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_prevdevolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevdevolucaostr = value;
                try
                {
                    dt_prevdevolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_prevdevolucao = null; }
            }
        }
        public decimal Vl_adto
        { get; set; }          
        private string _ST_ADTO;
        public string ST_ADTO
        {
            get { return _ST_ADTO; }
            set
            {
                _ST_ADTO = value;
                if (value.Trim().ToUpper().Equals("A"))
                    _ST_ADTO_String = "ABERTO";
                else if (value.Trim().ToUpper().Equals("F"))
                    _ST_ADTO_String = "QUITADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    _ST_ADTO_String = "DEVOLVIDO";
                else if (value.Trim().ToUpper().Equals("C"))
                    _ST_ADTO_String = "CANCELADO";
            }
        }
        private string _ST_ADTO_String;
        public string ST_ADTO_String
        {
            get { return _ST_ADTO_String; }
            set 
            { 
                _ST_ADTO_String = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    _ST_ADTO_String = "A";
                else if (value.Trim().ToUpper().Equals("QUITADO"))
                    _ST_ADTO_String = "F";
                else if (value.Trim().ToUpper().Equals("DEVOLVIDO"))
                    _ST_ADTO_String = "E";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    _ST_ADTO_String = "C";
            }
        }
        public string Status
        {
            get
            {
                if (_ST_ADTO.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else if (tp_movimento.Trim().ToUpper().Equals("C"))
                    if (Vl_adto == VL_Pagar)
                        if (Vl_adto > VL_Receber)
                            return "QUITADO";
                        else
                            return "DEVOLVIDO";
                    else
                        return "ABERTO";
                else
                    if (Vl_adto == VL_Receber)
                        if (Vl_adto > VL_Pagar)
                            return "QUITADO";
                        else
                            return "DEVOLVIDO";
                    else
                        return "ABERTO";
            }
        }
        private string _TP_Lancto;
        public string TP_Lancto
        {
            get { return _TP_Lancto; }
            set 
            { 
                _TP_Lancto = value;
                if (value.Trim().ToUpper().Equals("F"))
                    _TP_Lancto_String = "FINANCEIRO";
                else if (value.Trim().ToUpper().Equals("R"))
                    _TP_Lancto_String = "FROTAS";
                else if (value.Trim().ToUpper().Equals("P"))
                    _TP_Lancto_String = "PEDIDO";
                else if (value.Trim().ToUpper().Equals("C"))
                    _TP_Lancto_String = "COMMODITTIES";
                else if (value.Trim().ToUpper().Equals("T"))
                    _TP_Lancto_String = "FRENTE CAIXA";
            }
        }
        private string _TP_Lancto_String;
        public string TP_Lancto_String
        {
            get { return _TP_Lancto_String; }
            set
            {
                _TP_Lancto_String = value;
                if (value.Trim().ToUpper().Equals("FINANCEIRO"))
                    _TP_Lancto = "F";
                else if (value.Trim().ToUpper().Equals("FROTAS"))
                    _TP_Lancto = "R";
                else if (value.Trim().ToUpper().Equals("PEDIDO"))
                    _TP_Lancto = "P";
                else if (value.Trim().ToUpper().Equals("COMMODITTIES"))
                    _TP_Lancto = "C";
                else if (value.Trim().ToUpper().Equals("FRENTE CAIXA"))
                    _TP_Lancto = "T";
            }
        }
        public CCustoLan.TList_LanCCustoLancto lCustoLancto
        { get; set; }
        public CCustoLan.TList_LanCCustoLancto lCustoLanDel
        { get; set; }
        public TList_LanCaixa List_Caixa
        {
            get;
            set;
        }
        public Titulo.TList_RegLanTitulo lCheques
        { get; set; }
        public Cartao.TList_FaturaCartao lFatura
        { get; set; }
        public Titulo.TList_RegLanTitulo lChequesBusca
        { get; set; }
        public decimal Vl_total_devolver
        {
            get 
            { 
                  if (tp_movimento.Trim().ToUpper().Equals("C"))
                      return Math.Round(VL_Pagar - VL_Receber, 2, MidpointRounding.AwayFromZero);
                  else return Math.Round(VL_Receber - VL_Pagar, 2, MidpointRounding.AwayFromZero);
            }
            
        }
        public decimal Vl_saldo_quitacao
        {
            get { return Vl_adto - VL_total_quitado; }
        }
        public decimal VL_total_quitado
        {
            get
            {
                if (tp_movimento.Trim().ToUpper().Equals("C"))
                    return VL_Pagar;
                else if (tp_movimento.Trim().ToUpper().Equals("R"))
                    return VL_Receber;
                else
                    return decimal.Zero;
            }
        }
        public decimal VL_Receber
        {
            get;
            set;
        }
        public decimal VL_Pagar
        {
            get;
            set;
        }
        public string CD_Endereco
        {
            get;
            set;
        }
        public string DS_Endereco
        {
            get;
            set;
        }
        public string Cidade
        {
            get;
            set;
        }
        public string UF
        {
            get;
            set;
        }
        public decimal Vl_devolver
        { get; set; }
        public string Cd_contager_qt
        { get; set; }
        public string Ds_contager_qt
        { get; set; }
        private decimal? id_caixaPDV;
        public decimal? Id_caixaPDV
        {
            get { return id_caixaPDV; }
            set
            {
                id_caixaPDV = value;
                id_caixaPDVstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixaPDVstr;
        public string Id_caixaPDVstr
        {
            get { return id_caixaPDVstr; }
            set
            {
                id_caixaPDVstr = value;
                try
                {
                    id_caixaPDV = decimal.Parse(value);
                }
                catch
                { id_caixaPDV = null; }
            }
        }
        public string Cd_contagerDev
        { get; set; }
        public decimal? Cd_lanctoCaixaDev
        { get; set; }
        public bool St_qtCheque
        { get; set; }
        private decimal vl_processar;
        public decimal Vl_processar
        {
            get { return Math.Round(vl_processar, 2, MidpointRounding.AwayFromZero); }
            set { vl_processar = value; }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_LanAdiantamento()
        {
            Id_adto = 0;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Ds_adto = string.Empty;
            tp_movimento = "C";
            tipo_movimento = "CONCEDIDO";
            Vl_adto = decimal.Zero;
            dt_lancto = UtilData.Data_Servidor();
            dt_lanctostring = UtilData.Data_Servidor().ToString("dd/MM/yyyy");
            dt_prevdevolucao = null;
            dt_prevdevolucaostr = string.Empty;
            _ST_ADTO = "A";
            _ST_ADTO_String = "ABERTO";
            _TP_Lancto = "F";
            _TP_Lancto_String = "FINANCEIRO";
            lCustoLancto = new CCustoLan.TList_LanCCustoLancto();
            lCustoLanDel = new CCustoLan.TList_LanCCustoLancto();
            List_Caixa = new TList_LanCaixa();
            lCheques = new Titulo.TList_RegLanTitulo();
            lChequesBusca = new Titulo.TList_RegLanTitulo();
            lFatura = new Cartao.TList_FaturaCartao();
            VL_Receber = decimal.Zero;
            VL_Pagar = decimal.Zero;
            CD_Endereco = string.Empty;
            DS_Endereco = string.Empty;
            Cidade = string.Empty;
            UF = string.Empty;
            Vl_devolver = decimal.Zero;
            id_caixaPDV = null;
            id_caixaPDVstr = string.Empty;
            Cd_contagerDev = string.Empty;
            Cd_lanctoCaixaDev = null;
            St_qtCheque = false;
            vl_processar = decimal.Zero;
            St_processar = false;

            Cd_contager_qt = string.Empty;
            Ds_contager_qt = string.Empty;
        }
    }

    public class TCD_LanAdiantamento : TDataQuery
    {
        public TCD_LanAdiantamento()
        { }

        public TCD_LanAdiantamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_adto, a.cd_empresa, a.cd_contager, ");
                sql.AppendLine("b.nm_empresa, a.cd_clifor, c.nm_clifor, a.cd_endereco, ");
                sql.AppendLine("d.ds_endereco, d.ds_cidade, d.cd_uf, a.id_caixaPDV, ");
                sql.AppendLine("a.ds_adto, a.tp_movimento, a.dt_lancto, a.vl_adto, ");
                sql.AppendLine("a.st_adto, a.TP_Lancto, a.dt_prevdevolucao, ");
                sql.AppendLine("a.St_qtCheque, a.vl_receber, a.vl_pagar ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_adiantamento a ");
            sql.AppendLine("inner join tb_div_empresa  b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco d ");
            sql.AppendLine("on a.cd_endereco = d.cd_endereco ");
            sql.AppendLine("and a.cd_clifor = d.cd_clifor ");

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

        public TList_LanAdiantamento Select(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            TList_LanAdiantamento lista = new TList_LanAdiantamento();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNm_campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAdiantamento reg = new TRegistro_LanAdiantamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("ID_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Adto")))
                        reg.Ds_adto = reader.GetString(reader.GetOrdinal("DS_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager_qt = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevDevolucao")))
                        reg.Dt_prevdevolucao = reader.GetDateTime(reader.GetOrdinal("DT_PrevDevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Adto")))
                        reg.Vl_adto = reader.GetDecimal(reader.GetOrdinal("Vl_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Lancto")))
                        reg.TP_Lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ADTO")))
                        reg.ST_ADTO = reader.GetString(reader.GetOrdinal("ST_ADTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_receber")))
                        reg.VL_Receber = reader.GetDecimal(reader.GetOrdinal("vl_receber"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pagar")))
                        reg.VL_Pagar = reader.GetDecimal(reader.GetOrdinal("vl_pagar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.CD_Endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.DS_Endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Cidade")))
                        reg.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.UF = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixaPDV")))
                        reg.Id_caixaPDV = reader.GetDecimal(reader.GetOrdinal("id_caixaPDV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_qtCheque")))
                        reg.St_qtCheque = reader.GetString(reader.GetOrdinal("St_qtCheque")).Trim().ToUpper().Equals("S");
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

        public string Gravar(TRegistro_LanAdiantamento val)
        {
            Hashtable hs = new Hashtable(12 );
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.CD_Endereco);
            hs.Add("@P_ID_CAIXAPDV", val.Id_caixaPDV);
            hs.Add("@P_DS_ADTO", val.Ds_adto);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_DT_PREVDEVOLUCAO", val.Dt_prevdevolucao);
            hs.Add("@P_VL_ADTO", val.Vl_adto);
            hs.Add("@P_TP_LANCTO", val.TP_Lancto);
            hs.Add("@P_ST_ADTO", val.ST_ADTO);

            return executarProc("IA_FIN_ADIANTAMENTO", hs);
        }

        public string Excluir(TRegistro_LanAdiantamento val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ADTO", val.Id_adto);

            return executarProc("EXCLUI_FIN_ADIANTAMENTO", hs);
        }
    }
    #endregion

    #region Adiantamento X Caixa
    public class TList_LanAdiantamentoXCaixa : List<TRegistro_LanAdiantamentoXCaixa>
    { }
    
    public class TRegistro_LanAdiantamentoXCaixa
    {
        public decimal Id_adto
        { get; set; }
        public decimal Cd_lanctocaixa
        { get; set; }
        public string Cd_contager
        { get; set; }
        
        public TRegistro_LanAdiantamentoXCaixa()
        {
            Id_adto = 0;
            Cd_lanctocaixa = 0;
            Cd_contager = string.Empty;
        }
    }

    public class TCD_AdiantamentoXCaixa : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_adto, a.cd_lanctocaixa, a.cd_contager ");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_adiantamento_x_caixa a ");

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

        public TList_LanAdiantamentoXCaixa Select(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            TList_LanAdiantamentoXCaixa lista = new TList_LanAdiantamentoXCaixa();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAdiantamentoXCaixa reg = new TRegistro_LanAdiantamentoXCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
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

        public string Gravar(TRegistro_LanAdiantamentoXCaixa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("IA_FIN_ADIANTAMENTO_X_CAIXA", hs);
        }

        public string Excluir(TRegistro_LanAdiantamentoXCaixa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("EXCLUI_FIN_ADIANTAMENTO_X_CAIXA", hs);
        }
    }
    #endregion

    #region Adiantamento X Centro Resultado
    public class TList_Adiantamento_X_CCusto : List<TRegistro_Adiantamento_X_CCusto>
    { }
    
    public class TRegistro_Adiantamento_X_CCusto
    {
        public decimal? Id_adto
        { get; set; }
        public decimal? Id_ccustolan
        { get; set; }

        public TRegistro_Adiantamento_X_CCusto()
        {
            Id_adto = null;
            Id_ccustolan = null;
        }
    }

    public class TCD_Adiantamento_X_CCusto : TDataQuery
    {
        public TCD_Adiantamento_X_CCusto()
        { }

        public TCD_Adiantamento_X_CCusto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_adto, a.id_ccustolan ");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_adiantamento_x_ccusto a ");

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

        public TList_Adiantamento_X_CCusto Select(TpBusca[] vBusca, int vTop, string vNm_campo)
        {
            TList_Adiantamento_X_CCusto lista = new TList_Adiantamento_X_CCusto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Adiantamento_X_CCusto reg = new TRegistro_Adiantamento_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));
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

        public string Gravar(TRegistro_Adiantamento_X_CCusto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("IA_FIN_ADIANTAMENTO_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_Adiantamento_X_CCusto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_ADIANTAMENTO_X_CCUSTO", hs);
        }
    }
    #endregion
}
