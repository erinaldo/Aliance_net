using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using CamadaDados.Faturamento.Orcamento;

namespace CamadaDados.Faturamento.PosVenda
{
    #region Classe PosVenda
    public class TList_PosVenda : List<TRegistro_PosVenda>, IComparer<TRegistro_PosVenda>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_PosVenda()
        { }

        public TList_PosVenda(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PosVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PosVenda x, TRegistro_PosVenda y)
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

    public class TRegistro_PosVenda
    {
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }
        private decimal? id_posvenda;
        public decimal? Id_posvenda
        {
            get { return id_posvenda; }
            set
            {
                id_posvenda = value;
                id_posvendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_posvendastr;
        public string Id_posvendastr
        {
            get { return id_posvendastr; }
            set
            {
                id_posvendastr = value;
                try
                {
                    id_posvenda = Convert.ToDecimal(value);
                }
                catch
                { id_posvenda = null; }
            }
        }
        public string Login { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_questionario;
        public decimal? Id_questionario
        {
            get { return id_questionario; }
            set
            {
                id_questionario = value;
                id_questionariostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_questionariostr;
        public string Id_questionariostr
        {
            get { return id_questionariostr; }
            set
            {
                id_questionariostr = value;
                try
                {
                    id_questionario = Convert.ToDecimal(value);
                }
                catch
                { id_questionario = null; }
            }
        }

        private DateTime? dt_abertura;
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = Convert.ToDateTime(value);
                }
                catch
                { dt_abertura = null; }
            }
        }

        private DateTime? dt_encerramento;
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_encerramentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = Convert.ToDateTime(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }

        public string Ds_reclamacao { get; set; }
        public string Ds_sugestao { get; set; }
        public string St_registro { get; set; }

        public string Nr_orcamento { get; set; }

        public string Status
        {
            get
            {
                if (St_registro.Equals("A"))
                    return "ABERTO";
                else if (St_registro.Equals("E"))
                    return "ENCERRADO";
                else return "CANCELADO";
            }
        }

        public TList_EventoPosVenda lEventoPosVenda { get; set; }
        public TList_PosVendaQuestionario lPosVendaQuestionario { get; set; }
        public TList_EventoPosVenda DelEventoPosVenda { get; set; }
        public TList_PosVendaQuestionario DelPosVendaQuestionario { get; set; }
        public IEnumerable<TRegistro_Orcamento> lOrcamento { get; set; }
        public TList_PosVenda_X_Proposta lPosVendaProposta { get; set; }
        public TList_PosVenda_X_Proposta DelPosVendaProposta { get; set; }

        public TRegistro_PosVenda()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_posvenda = null;
            Login = string.Empty;
            Cd_clifor = string.Empty;
            Id_questionario = null;
            Dt_abertura = null;
            Dt_encerramento = null;
            Ds_reclamacao = string.Empty;
            Ds_sugestao = string.Empty;
            St_registro = string.Empty;

            lEventoPosVenda = new TList_EventoPosVenda();
            lPosVendaQuestionario = new TList_PosVendaQuestionario();
            DelEventoPosVenda = new TList_EventoPosVenda();
            DelPosVendaQuestionario = new TList_PosVendaQuestionario();
        }
    }

    public class TCD_PosVenda : TDataQuery
    {
        public TCD_PosVenda()
        {

        }

        public TCD_PosVenda(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_posvenda, a.login, a.cd_clifor, c.nm_clifor, ");
                sql.AppendLine(" a.id_questionario, a.dt_abertura, a.dt_encerramento, a.ds_reclamacao, a.ds_sugestao, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_fat_posvenda a ");
            sql.AppendLine(" inner join tb_div_empresa b ");
            sql.AppendLine(" on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine(" inner join tb_fin_clifor c ");
            sql.AppendLine(" on a.cd_clifor = c.cd_clifor ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_PosVenda Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PosVenda lista = new TList_PosVenda();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PosVenda reg = new TRegistro_PosVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PosVenda"))))
                        reg.Id_posvenda = reader.GetDecimal(reader.GetOrdinal("ID_PosVenda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Questionario"))))
                        reg.Id_questionario = reader.GetDecimal(reader.GetOrdinal("ID_Questionario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Abertura"))))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Encerramento"))))
                        reg.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("DT_Encerramento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Reclamacao"))))
                        reg.Ds_reclamacao = reader.GetString(reader.GetOrdinal("DS_Reclamacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Sugestao"))))
                        reg.Ds_sugestao = reader.GetString(reader.GetOrdinal("DS_Sugestao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));

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

        public string Gravar(TRegistro_PosVenda val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_ID_QUESTIONARIO", val.Id_questionario);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_ENCERRAMENTO", val.Dt_encerramento);
            hs.Add("@P_DS_RECLAMACAO", val.Ds_reclamacao);
            hs.Add("@P_DS_SUGESTAO", val.Ds_sugestao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_POSVENDA", hs);
        }

        public string Excluir(TRegistro_PosVenda val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);

            return executarProc("EXCLUI_FAT_POSVENDA", hs);
        }
    }
    #endregion

    #region PosVenda_X_Proposta
    public class TList_PosVenda_X_Proposta : List<TRegistro_PosVenda_X_Proposta>, IComparer<TRegistro_PosVenda_X_Proposta>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_PosVenda_X_Proposta()
        { }

        public TList_PosVenda_X_Proposta(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PosVenda_X_Proposta value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PosVenda_X_Proposta x, TRegistro_PosVenda_X_Proposta y)
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

    public class TRegistro_PosVenda_X_Proposta
    {
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }

        private decimal? id_posvenda;
        public decimal? Id_posvenda
        {
            get { return id_posvenda; }
            set
            {
                id_posvenda = value;
                id_posvendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_posvendastr;
        public string Id_posvendastr
        {
            get { return id_posvendastr; }
            set
            {
                id_posvendastr = value;
                try
                {
                    id_posvenda = Convert.ToDecimal(value);
                }
                catch
                { id_posvenda = null; }
            }
        }

        private decimal? nr_orcamento;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = Convert.ToDecimal(value);
                }
                catch
                { nr_orcamento = null; }
            }
        }

        public TRegistro_PosVenda_X_Proposta()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_posvenda = null;
            Nr_orcamento = null;
        }
    }

    public class TCD_PosVenda_X_Proposta : TDataQuery
    {
        public TCD_PosVenda_X_Proposta()
        {

        }

        public TCD_PosVenda_X_Proposta(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_posvenda, a.nr_orcamento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_FAT_PosVenda_X_Proposta a ");
            sql.AppendLine(" inner join tb_div_empresa b ");
            sql.AppendLine(" on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_PosVenda_X_Proposta Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PosVenda_X_Proposta lista = new TList_PosVenda_X_Proposta();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PosVenda_X_Proposta reg = new TRegistro_PosVenda_X_Proposta();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PosVenda"))))
                        reg.Id_posvenda = reader.GetDecimal(reader.GetOrdinal("ID_PosVenda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("NR_Orcamento"));

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

        public string Gravar(TRegistro_PosVenda_X_Proposta val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);

            return executarProc("IA_FAT_POSVENDA_X_PROPOSTA", hs);
        }

        public string Excluir(TRegistro_PosVenda_X_Proposta val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);

            return executarProc("EXCLUI_FAT_POSVENDA_X_PROPOSTA", hs);
        }
    }
    #endregion

    #region PosVendaQuestionario
    public class TList_PosVendaQuestionario : List<TRegistro_PosVendaQuestionario>, IComparer<TRegistro_PosVendaQuestionario>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_PosVendaQuestionario()
        { }

        public TList_PosVendaQuestionario(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PosVendaQuestionario value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PosVendaQuestionario x, TRegistro_PosVendaQuestionario y)
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

    public class TRegistro_PosVendaQuestionario
    {
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }

        private decimal? id_posvenda;
        public decimal? Id_posvenda
        {
            get { return id_posvenda; }
            set
            {
                id_posvenda = value;
                id_posvendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_posvendastr;
        public string Id_posvendastr
        {
            get { return id_posvendastr; }
            set
            {
                id_posvendastr = value;
                try
                {
                    id_posvenda = Convert.ToDecimal(value);
                }
                catch
                { id_posvenda = null; }
            }
        }

        private decimal? id_pergunta;
        public decimal? Id_pergunta
        {
            get { return id_pergunta; }
            set
            {
                id_pergunta = value;
                id_perguntastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_perguntastr;
        public string Id_perguntastr
        {
            get { return id_perguntastr; }
            set
            {
                id_perguntastr = value;
                try
                {
                    id_pergunta = Convert.ToDecimal(value);
                }
                catch
                { id_pergunta = null; }
            }
        }

        private decimal? id_resposta;
        public decimal? Id_resposta
        {
            get { return id_resposta; }
            set
            {
                id_resposta = value;
                id_respostastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_respostastr;
        public string Id_respostastr
        {
            get { return id_respostastr; }
            set
            {
                id_respostastr = value;
                try
                {
                    id_resposta = Convert.ToDecimal(value);
                }
                catch
                { id_resposta = null; }
            }
        }

        public string Ds_pergunta { get; set; }
        public string Ds_resposta { get; set; }

        public string Id_questionario { get; set; }

        public TRegistro_PosVendaQuestionario()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_posvenda = null;
            Id_pergunta = null;
            Id_resposta = null;
            Ds_pergunta = string.Empty;
            Ds_resposta = string.Empty;
            Id_questionario = string.Empty;
        }
    }

    public class TCD_PosVendaQuestionario : TDataQuery
    {
        public TCD_PosVendaQuestionario()
        {

        }

        public TCD_PosVendaQuestionario(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_posvenda, a.id_pergunta, a.id_resposta, ");
                sql.AppendLine(" c.ds_pergunta, d.ds_resposta ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_FAT_PosVendaQuestionario a ");

            sql.AppendLine(" inner join tb_div_empresa b ");
            sql.AppendLine(" on a.cd_empresa = b.cd_empresa ");

            sql.AppendLine(" inner join TB_FAT_Pergunta c ");
            sql.AppendLine("on a.id_pergunta = c.id_pergunta ");

            sql.AppendLine("inner join TB_FAT_Resposta d");
            sql.AppendLine("on a.id_resposta = d.id_resposta");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_PosVendaQuestionario Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PosVendaQuestionario lista = new TList_PosVendaQuestionario();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PosVendaQuestionario reg = new TRegistro_PosVendaQuestionario();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PosVenda"))))
                        reg.Id_posvenda = reader.GetDecimal(reader.GetOrdinal("ID_PosVenda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Pergunta"))))
                        reg.Id_pergunta = reader.GetDecimal(reader.GetOrdinal("ID_Pergunta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Resposta"))))
                        reg.Id_resposta = reader.GetDecimal(reader.GetOrdinal("ID_Resposta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_pergunta"))))
                        reg.Ds_pergunta = reader.GetString(reader.GetOrdinal("ds_pergunta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_resposta"))))
                        reg.Ds_resposta = reader.GetString(reader.GetOrdinal("ds_resposta"));


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

        public string Gravar(TRegistro_PosVendaQuestionario val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);

            return executarProc("IA_FAT_POSVENDAQUESTIONARIO", hs);
        }

        public string Excluir(TRegistro_PosVendaQuestionario val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);

            return executarProc("EXCLUI_FAT_POSVENDAQUESTIONARIO", hs);
        }
    }
    #endregion

    #region EventoPosVenda
    public class TList_EventoPosVenda : List<TRegistro_EventoPosVenda>, IComparer<TRegistro_EventoPosVenda>
    {
        #region IComparer<TRegistro_EventoPosVenda> Members
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

        public TList_EventoPosVenda()
        { }

        public TList_EventoPosVenda(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EventoPosVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EventoPosVenda x, TRegistro_EventoPosVenda y)
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

    public class TRegistro_EventoPosVenda
    {
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }

        private decimal? id_posvenda;
        public decimal? Id_posvenda
        {
            get { return id_posvenda; }
            set
            {
                id_posvenda = value;
                id_posvendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_posvendastr;
        public string Id_posvendastr
        {
            get { return id_posvendastr; }
            set
            {
                id_posvendastr = value;
                try
                {
                    id_posvenda = Convert.ToDecimal(value);
                }
                catch
                { id_posvenda = null; }
            }
        }

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
                    id_evento = Convert.ToDecimal(value);
                }
                catch
                { id_evento = null; }
            }
        }

        public string Login { get; set; }
        public string Ds_evento { get; set; }

        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_eventostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = Convert.ToDateTime(value);
                }
                catch
                { dt_evento = null; }
            }
        }

        public TRegistro_EventoPosVenda()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_posvenda = null;
            Id_evento = null;
            Login = string.Empty;
            Ds_evento = string.Empty;
            Dt_evento = null;
        }
    }

    public class TCD_EventoPosVenda : TDataQuery
    {
        public TCD_EventoPosVenda()
        {

        }

        public TCD_EventoPosVenda(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_posvenda, a.id_evento, a.login, ");
                sql.AppendLine(" a.ds_evento, a.dt_evento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_FAT_EventoPosVenda a ");
            sql.AppendLine(" inner join tb_div_empresa b ");
            sql.AppendLine(" on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_EventoPosVenda Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_EventoPosVenda lista = new TList_EventoPosVenda();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EventoPosVenda reg = new TRegistro_EventoPosVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Evento"))))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("ID_Evento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Evento"))))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("DS_Evento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Evento"))))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("DT_Evento"));


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

        public string Gravar(TRegistro_EventoPosVenda val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_EVENTO", val.Ds_evento);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);

            return executarProc("IA_FAT_EVENTOPOSVENDA", hs);
        }

        public string Excluir(TRegistro_EventoPosVenda val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_POSVENDA", val.Id_posvenda);
            hs.Add("@P_ID_EVENTO", val.Id_evento);

            return executarProc("EXCLUI_FAT_EVENTOPOSVENDA", hs);
        }
    }
    #endregion
}
