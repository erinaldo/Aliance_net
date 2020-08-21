using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadContaGer : List<TRegistro_CadContaGer>, IComparer<TRegistro_CadContaGer>
    {
        #region IComparer<TRegistro_CadContaGer> Members
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

        public TList_CadContaGer()
        { }

        public TList_CadContaGer(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadContaGer value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadContaGer x, TRegistro_CadContaGer y)
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
    
    public class TRegistro_CadContaGer
    {
        public string Cd_contager 
        { get; set; }
        public string Ds_contager 
        { get; set; }
        public TRegistro_CadBanco Banco 
        { get; set; }
        public string Nr_agencia 
        { get; set; }
        public string Digito_agencia
        { get; set; }
        public string St_registro 
        { get; set; }
        public string Nr_contacorrente 
        { get; set; }
        public string Digito_contacorrente
        { get; set; }
        private string _st_contacompensacao;
        public string St_contacompensacao
        {
            get { return _st_contacompensacao; }
            set
            {
                _st_contacompensacao = value;
                if (value == "S")
                    _st_contacompensacaobool = true;
                else
                    _st_contacompensacaobool = false;
            }
        }
        private bool _st_contacompensacaobool;
        public bool St_contacompensacaobool
        {
            get
            { return _st_contacompensacaobool; }
            set
            {
                _st_contacompensacaobool = value;
                if (value)
                    St_contacompensacao = "S";
                else
                    St_contacompensacao = "N";
            }
        }
        private string _st_integractb;
        public string St_integractb 
        {
            get { return _st_integractb; }
            set
            {
                _st_integractb = value;
                if (value == "S")
                    _st_integractbbool = true;
                else
                    _st_integractbbool = false;
            }
        }
        private bool _st_integractbbool;
        public bool St_integractbbool
        {
            get
            { return _st_integractbbool; }
            set
            {
                _st_integractbbool = value;
                if (value)
                    St_integractb = "S";
                else
                    St_integractb = "N";
            }
        }
        public decimal Vl_limite 
        { get; set; }
        public string Cd_contager_compensacao
        { get; set; }
        public string Ds_contager_compensacao
        { get; set; }
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Sigla
        { get; set; }
        public decimal Nr_cheque_seq 
        { get; set; }
        public string LayoutCheque 
        { get; set; }
        private int st_contacartao;
        public int St_contacartao
        {
            get
            { return st_contacartao; }
            set
            {
                st_contacartao = value;
                st_contacartaobool = value.Equals(0);
            }
        }
        private bool st_contacartaobool;
        public bool St_contacartaobool
        {
            get 
            { return st_contacartaobool; }
            set
            {
                st_contacartaobool = value;
                st_contacartao = value ? 0 : 1;
            }
        }
        private int st_contacf;
        public int St_contacf
        {
            get
            { return st_contacf; }
            set
            {
                st_contacf = value;
                st_contacfbool = value.Equals(0);
            }
        }
        private bool st_contacfbool;
        public bool St_contacfbool
        {
            get
            { return st_contacfbool; }
            set
            {
                st_contacfbool = value;
                st_contacf = value ? 0 : 1;
            }
        }
        public decimal Vl_limitecustodia
        { get; set; }
        public decimal Pc_jurolimitecustodia
        { get; set; }
        public decimal Pc_jurolimite
        { get; set; }
        private int st_controlarsaldo;
        public int St_controlarsaldo
        {
            get { return st_controlarsaldo; }
            set
            {
                st_controlarsaldo = value;
                st_controlarsaldobool = value.Equals(0);
            }
        }
        private bool st_controlarsaldobool;
        public bool St_controlarsaldobool
        {
            get { return st_controlarsaldobool; }
            set
            {
                st_controlarsaldobool = value;
                st_controlarsaldo = value ? 0 : 1;
            }
        }
        private string st_contaaplicacao;
        public string St_contaaplicacao
        {
            get { return st_contaaplicacao; }
            set
            {
                st_contaaplicacao = value;
                st_contaaplicacaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_contaaplicacaobool;
        public bool St_contaaplicacaobool
        {
            get { return st_contaaplicacaobool; }
            set
            {
                st_contaaplicacaobool = value;
                st_contaaplicacao = value ? "S" : "N";
            }
        }
        public string Cd_contager_aplic
        { get; set; }
        public string Ds_contager_aplic
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadContaGer()
        {
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            Banco = new TRegistro_CadBanco();
            Nr_agencia = string.Empty;
            Digito_agencia = string.Empty;
            St_registro = "A";
            Nr_contacorrente = string.Empty;
            Digito_contacorrente = string.Empty;
            St_contacompensacao = string.Empty;
            St_contacompensacaobool = false;
            St_integractb = string.Empty;
            St_integractbbool = false;
            Vl_limite = decimal.Zero;
            Cd_contager_compensacao = String.Empty;
            Ds_contager_compensacao = String.Empty;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Nr_cheque_seq = decimal.Zero;
            LayoutCheque = string.Empty;
            St_contacartao = 1;
            st_contacartaobool = false;
            St_contacf = 1;
            st_contacfbool = false;
            st_controlarsaldo = 1;
            st_controlarsaldobool = false;
            Vl_limitecustodia = decimal.Zero;
            Pc_jurolimitecustodia = decimal.Zero;
            Pc_jurolimite = decimal.Zero;
            st_contaaplicacao = "N";
            st_contaaplicacaobool = false;
            Cd_contager_aplic = string.Empty;
            Ds_contager_aplic = string.Empty;
            St_processar = false;
        }
    }

    public class TList_SaldoContas : List<TRegistro_SaldoContas>
    { }
    
    public class TRegistro_SaldoContas
    {
        public string Cd_contaGer
        { get; set; }
        public string Ds_contaGer
        { get; set; }
        public decimal Vl_Saldo
        { get; set; }
        public decimal SaldoAtual
        { get; set; }
        public string DataConsulta
        { get; set; }

        public TRegistro_SaldoContas()
        {
            Cd_contaGer = string.Empty;
            Ds_contaGer = string.Empty;
            Vl_Saldo = decimal.Zero;
            SaldoAtual = decimal.Zero;
            DataConsulta = string.Empty;
        }
    }

    public class TCD_CadContaGer : TDataQuery
    {
        public TCD_CadContaGer()
        { }

        public TCD_CadContaGer(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_contager, a.ds_contager, a.nr_agencia, ");
                sql.AppendLine("a.ST_ContaCartao, a.ST_ContaCF, a.Vl_LimiteCustodia, a.PC_JuroLimite, a.PC_JuroLimiteCustodia, ");
                sql.AppendLine("a.st_registro, a.nr_contacorrente, a.st_contacompensacao, a.nr_cheque_seq, ");
                sql.AppendLine("a.st_integractb, a.vl_limite, b.cd_banco, b.ds_banco, a.layoutcheque, ");
                sql.AppendLine("a.cd_contager_compensacao, a.st_controlarsaldo, ");
                sql.AppendLine("c.ds_contager as ds_compensacao, a.cd_moeda, d.ds_moeda_singular, d.sigla, ");
                sql.AppendLine("a.digitoagencia, a.digitoconta, a.st_contaaplicacao, ");
                sql.AppendLine("a.cd_contager_aplic, e.ds_contager as ds_contager_aplic ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_contager a ");
            sql.AppendLine("left outer join tb_fin_banco b ");
            sql.AppendLine("on a.cd_banco = b.cd_banco ");
            sql.AppendLine("left outer join tb_fin_contager c ");
            sql.AppendLine("on c.cd_contager = a.cd_contager_compensacao ");
            sql.AppendLine("left outer join tb_fin_moeda d ");
            sql.AppendLine("on a.cd_moeda = d.cd_moeda ");
            sql.AppendLine("left outer join tb_fin_contager e ");
            sql.AppendLine("on a.cd_contager_aplic = e.cd_contager ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        private string SqlBuscaSaldoContas(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string Data)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_contager, a.ds_contager, ");
                sql.AppendLine("vl_saldo = ISNULL((select sum(isnull(x.Vl_RECEBER, 0) - ISNULL(x.Vl_PAGAR, 0)) ");
                sql.AppendLine("                   from TB_FIN_Caixa x ");
                sql.AppendLine("                   where x.CD_ContaGer = a.CD_ContaGer ");
                sql.AppendLine("				   and ISNULL(x.ST_Estorno, 'N') <> 'S' ");
                sql.AppendLine("                   and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '" + Data.Trim() + "'), 0), ");
                sql.AppendLine("SaldoAtual = isnull ((select top 1 isnull(sum(y.vl_receber - y.vl_pagar), 0) ");
                sql.AppendLine("                      from tb_fin_caixa y ");
                sql.AppendLine("                      where y.CD_ContaGer = a.CD_ContaGer ");
                sql.AppendLine("                      and ISNULL(y.st_estorno, 'N') <> 'S'), 0) ");
                
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_contager a ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CadContaGer Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadContaGer lista = new TList_CadContaGer();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadContaGer reg = new TRegistro_CadContaGer();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ContaGer"))))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Agencia"))))
                        reg.Nr_agencia = reader.GetString(reader.GetOrdinal("Nr_Agencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoAgencia")))
                        reg.Digito_agencia = reader.GetString(reader.GetOrdinal("DigitoAgencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_ContaCorrente"))))
                        reg.Nr_contacorrente = reader.GetString(reader.GetOrdinal("Nr_ContaCorrente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoConta")))
                        reg.Digito_contacorrente = reader.GetString(reader.GetOrdinal("DigitoConta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_ContaCompensacao"))))
                        reg.St_contacompensacao = reader.GetString(reader.GetOrdinal("ST_ContaCompensacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_IntegraCTB"))))
                        reg.St_integractb = reader.GetString(reader.GetOrdinal("ST_IntegraCTB"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Limite"))))
                        reg.Vl_limite = reader.GetDecimal(reader.GetOrdinal("VL_Limite"));
                    if(!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Banco.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if(!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Banco.Ds_banco = reader.GetString(reader.GetOrdinal("DS_banco"));
                    if(!reader.IsDBNull(reader.GetOrdinal("NR_Cheque_Seq")))
                        reg.Nr_cheque_seq = reader.GetDecimal(reader.GetOrdinal("NR_Cheque_Seq"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LayoutCheque")))
                        reg.LayoutCheque = reader.GetString(reader.GetOrdinal("LayoutCheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer_compensacao"))))
                        reg.Cd_contager_compensacao = reader.GetString(reader.GetOrdinal("CD_ContaGer_compensacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Compensacao"))))
                        reg.Ds_contager_compensacao = reader.GetString(reader.GetOrdinal("DS_compensacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ContaCartao")))
                        reg.St_contacartao = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_ContaCartao")));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ContaCF")))
                        reg.St_contacf = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_ContaCF")));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ControlarSaldo")))
                        reg.St_controlarsaldo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_ControlarSaldo")));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_LimiteCustodia")))
                        reg.Vl_limitecustodia= reader.GetDecimal(reader.GetOrdinal("VL_LimiteCustodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroLimiteCustodia")))
                        reg.Pc_jurolimitecustodia = reader.GetDecimal(reader.GetOrdinal("PC_JuroLimiteCustodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroLimite")))
                        reg.Pc_jurolimite = reader.GetDecimal(reader.GetOrdinal("PC_JuroLimite"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_contaaplicacao")))
                        reg.St_contaaplicacao = reader.GetString(reader.GetOrdinal("st_contaaplicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager_aplic")))
                        reg.Cd_contager_aplic = reader.GetString(reader.GetOrdinal("cd_contager_aplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager_aplic")))
                        reg.Ds_contager_aplic = reader.GetString(reader.GetOrdinal("ds_contager_aplic"));

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

        public TList_SaldoContas SelectSaldoContas(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string Data)
        {
            bool podeFecharBco = false;
            TList_SaldoContas lista = new TList_SaldoContas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlBuscaSaldoContas(vBusca, vTop, vNM_Campo, Data));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoContas reg = new TRegistro_SaldoContas();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_contager"))))
                        reg.Cd_contaGer = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_contager"))))
                        reg.Ds_contaGer = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_saldo"))))
                        reg.Vl_Saldo = reader.GetDecimal(reader.GetOrdinal("vl_saldo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("SaldoAtual"))))
                        reg.SaldoAtual = reader.GetDecimal(reader.GetOrdinal("SaldoAtual"));

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

        public string Gravar(TRegistro_CadContaGer val)
        {
            Hashtable hs = new Hashtable(23);

            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_DS_CONTAGER", val.Ds_contager);
            hs.Add("@P_CD_BANCO", val.Banco.Cd_banco);
            hs.Add("@P_NR_AGENCIA", val.Nr_agencia);
            hs.Add("@P_DIGITOAGENCIA", val.Digito_agencia);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_NR_CONTACORRENTE", val.Nr_contacorrente);
            hs.Add("@P_DIGITOCONTA", val.Digito_contacorrente);
            hs.Add("@P_ST_CONTACOMPENSACAO", val.St_contacompensacao);
            hs.Add("@P_ST_INTEGRACTB", val.St_integractb);
            hs.Add("@P_VL_LIMITE", val.Vl_limite);
            hs.Add("@P_CD_CONTAGER_COMPENSACAO", val.Cd_contager_compensacao);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_NR_CHEQUE_SEQ", val.Nr_cheque_seq);
            hs.Add("@P_LAYOUTCHEQUE", val.LayoutCheque);
            hs.Add("@P_ST_CONTACARTAO", val.St_contacartao);
            hs.Add("@P_ST_CONTACF", val.St_contacf);
            hs.Add("@P_ST_CONTROLARSALDO", val.St_controlarsaldo);
            hs.Add("@P_VL_LIMITECUSTODIA", val.Vl_limitecustodia);
            hs.Add("@P_PC_JUROLIMITECUSTODIA", val.Pc_jurolimitecustodia);
            hs.Add("@P_PC_JUROLIMITE", val.Pc_jurolimite);
            hs.Add("@P_ST_CONTAAPLICACAO", val.St_contaaplicacao);
            hs.Add("@P_CD_CONTAGER_APLIC", val.Cd_contager_aplic);

            return executarProc("IA_FIN_CONTAGER", hs);
        }

        public string Excluir(TRegistro_CadContaGer val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return executarProc("EXCLUI_FIN_CONTAGER", hs);
        }
    }
}
