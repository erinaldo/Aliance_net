using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Empreendimento
{
    #region Orcamento
    public class TList_Orcamento : List<TRegistro_Orcamento>, IComparer<TRegistro_Orcamento>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_Orcamento()
        { }

        public TList_Orcamento(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Orcamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Orcamento x, TRegistro_Orcamento y)
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
    public class TRegistro_Orcamento : ICloneable
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string cd_condpgto { get; set; } = string.Empty;
        public string DS_condpgto { get; set; } = string.Empty;
        public decimal vl_orcamento { get; set; } = decimal.Zero;
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string id_contato { get; set; } = string.Empty;
        public string Nm_contato { get; set; } = string.Empty;
        public string Fone_contato { get; set; } = string.Empty;
        public string Email_contato { get; set; } = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        public decimal? Id_orc { get; set; } = null;
      public decimal total_orcamento => Math.Round(decimal.Divide(Custo_Empreendimento, decimal.Divide(decimal.Subtract(100, decimal.Add(Tot_impostos, Pc_margemcont)), 100)), 2, MidpointRounding.AwayFromZero);
      //public decimal total_orcamento => Math.Round(decimal.Add(Custo_Empreendimento, decimal.Multiply(Custo_Empreendimento, decimal.Divide(decimal.Add(Tot_impostos, Pc_margemcont), 100))), 2, MidpointRounding.AwayFromZero);
        public decimal total_orcdesc => Pc_descprog > decimal.Zero ? 
                        Math.Round(
                            decimal.Divide(total_orcamento, 
                                decimal.Divide(
                                    decimal.Subtract(total_orcamento, 
                                        decimal.Multiply(total_orcamento, 
                                            decimal.Divide(Pc_descprog, 100))), 
                                    total_orcamento)), 
                            2, MidpointRounding.AwayFromZero) : total_orcamento;
        public decimal Vl_liquido => Math.Round(decimal.Subtract(decimal.Subtract(total_orcdesc, Custo_Empreendimento), Vl_totimpostos), 2, MidpointRounding.AwayFromZero);
        public decimal? Nr_versaoOrc { get; set; } = null;
        public string Cd_clifor { get; set; } = string.Empty;
        public string Nm_clifor { get; set; } = string.Empty;
        public string Cnpj_cpf { get; set; } = string.Empty;
        public string Cd_endereco { get; set; } = string.Empty;
        public string Ds_endereco { get; set; } = string.Empty;
        public string Cd_vendedor { get; set; } = string.Empty;
        public string Nm_vendedor { get; set; } = string.Empty;
        public string Ds_empreendimento { get; set; } = string.Empty;
        public string Ds_enderecoemp { get; set; } = string.Empty;
        public string Numeroemp { get; set; } = string.Empty;
        public string Bairroemp { get; set; } = string.Empty;
        public string Foneemp { get; set; } = string.Empty;
        public string Cd_cidadeemp { get; set; } = string.Empty;
        public string Ds_cidadeemp { get; set; } = string.Empty;
        public string Cd_ufemp { get; set; } = string.Empty;
        public string Uf_emp { get; set; } = string.Empty;
        private DateTime? dt_orcamento;
        public DateTime? Dt_orcamento
        {
            get { return dt_orcamento; }
            set
            {
                dt_orcamento = value;
                dt_orcamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_orcamentostr;
        public string Dt_orcamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_orcamentostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_orcamentostr = value;
                try
                {
                    dt_orcamento = DateTime.Parse(value);
                }
                catch { dt_orcamento = null; }
            }
        }
        private DateTime? dt_proposta;
        public DateTime? Dt_proposta
        {
            get { return dt_proposta; }
            set
            {
                dt_proposta = value;
                dt_propostastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_propostastr;
        public string Dt_propostastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_propostastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_propostastr = value;
                try
                {
                    dt_proposta = DateTime.Parse(value);
                }
                catch { dt_proposta = null; }
            }
        }

        private DateTime? dt_previni;
        public DateTime? Dt_previni
        {
            get { return dt_previni; }
            set
            {
                dt_previni = value;
                dt_previnistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_previnistr;
        public string Dt_previnistr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_previnistr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_previnistr = value;
                try
                {
                    dt_previni = DateTime.Parse(value);
                }
                catch { dt_previni = null; }
            }
        }
        private DateTime? dt_prevfin;
        public DateTime? Dt_prevfin
        {
            get { return dt_prevfin; }
            set
            {
                dt_prevfin = value;
                dt_prevfinstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevfinstr;
        public string Dt_prevfinstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevfinstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_prevfinstr = value;
                try
                {
                    dt_prevfin = DateTime.Parse(value);
                }
                catch { dt_prevfin = null; }
            }
        }
        public decimal Pc_issqn { get; set; } = decimal.Zero;
        public decimal Vl_issqn => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(st_empglobalbool ? Math.Round(decimal.Multiply(Pc_issqn, decimal.Divide(40, 100)), 2, MidpointRounding.AwayFromZero) : Pc_issqn, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_comissao { get; set; } = decimal.Zero;
        public decimal vl_comissao { get; set; } = decimal.Zero;
        public string loginorc { get; set; } = string.Empty;
        public decimal Pc_custofin { get; set; } = decimal.Zero;
        public decimal Pc_irpj { get; set; } = decimal.Zero;
        public decimal Vl_irpj => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_irpj, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_irpjAdic { get; set; } = decimal.Zero;
        public decimal Vl_irpjAdic => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_irpjAdic, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_inss { get; set; } = decimal.Zero;
        public decimal Vl_inss => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_inss, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_csll { get; set; } = decimal.Zero;
        public decimal Vl_csll => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_csll, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_pis { get; set; } = decimal.Zero;
        public decimal Vl_pis => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_pis, 100)), 2, MidpointRounding.AwayFromZero);
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public decimal Pc_cofins { get; set; } = decimal.Zero;
        public decimal Vl_cofins => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Pc_cofins, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Tot_impostos { get
            { return (st_empglobalbool ? Math.Round(decimal.Multiply(Pc_issqn, decimal.Divide(40, 100)), 2, MidpointRounding.AwayFromZero) : Pc_issqn) + Pc_irpj + Pc_csll + Pc_pis + Pc_cofins + Pc_irpjAdic + Pc_inss; } }
        public decimal Vl_totimpostos => Math.Round(decimal.Multiply(total_orcdesc, decimal.Divide(Tot_impostos, 100)), 2, MidpointRounding.AwayFromZero);
        public decimal Pc_margemcont { get; set; } = decimal.Zero;
        public decimal Pc_descprog { get; set; } = decimal.Zero;
        public decimal Pc_desconto { get; set; } = decimal.Zero;
        private string st_empglobal = "N";
        public string St_empglobal
        {
            get { return st_empglobal; }
            set
            {
                st_empglobal = value;
                st_empglobalbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_empglobalbool = false;
        public bool St_empglobalbool
        {
            get { return st_empglobalbool; }
            set
            {
                st_empglobalbool = value;
                st_empglobal = value ? "S" : "N";
            }
        }
        private string st_registro = "A";
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "REQUISICAO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "NEGOCIADO";
                else if (value.Trim().ToUpper().Equals("O"))
                    status = "EM ORCAMENTO";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "NAO NEGOCIADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("N"))
                    status = "EM NEGOCIACAO";
                else if (value.Trim().ToUpper().Equals("F"))
                    status = "FINALIZADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "EXECUCAO";
                else if (value.Trim().ToUpper().Equals("X"))
                    status = "PROJETO CONCLUIDO";
                else if (value.Trim().ToUpper().Equals("T"))
                    status = "EM PROJETO";
                else if (value.Trim().ToUpper().Equals("H"))
                    status = "AGUARDANDO APROVACAO";
                else if (value.Trim().ToUpper().Equals("J"))
                    status = "EM PROJETO";
            }
        }
        private string status = "REQUISICAO";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("REQUISICAO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("NEGOCIADO"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("NAO NEGOCIADO"))
                    st_registro = "R";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("EM NEGOCIACAO"))
                    st_registro = "N";
                else if (value.Trim().ToUpper().Equals("FINALIZADO"))
                    st_registro = "F";
                else if (value.Trim().ToUpper().Equals("EM ORCAMENTO"))
                    st_registro = "O";
                else if (value.Trim().ToUpper().Equals("EXECUCAO"))
                    st_registro = "E";
                else if (value.Trim().ToUpper().Equals("PROJETO CONCLUIDO"))
                    st_registro = "X";
                else if (value.Trim().ToUpper().Equals("AGUARDANDO APROVACAO"))
                    st_registro = "H";
                else if (value.Trim().ToUpper().Equals("EM PROJETO"))
                    st_registro = "T";
            }
        }
        public decimal Custo_MPrima
        {
            set { Custo_MPrima = value; }
            get { return decimal.Add(ficha_fd, ficha_fd); }
        }
        public decimal ficha_fp { get; set; } = decimal.Zero;
        public decimal ficha_fd { get; set; } = decimal.Zero;
        public decimal custo_folha { get; set; } = decimal.Zero;
        public decimal Custo_Despesas { get; set; } = decimal.Zero;
        public decimal tot_encargo { get; set; } = decimal.Zero;
        public decimal maodeobra { get; set; } = decimal.Zero;
        public decimal Custo_Empreendimento =>  ficha_fp + Custo_Despesas + custo_folha + tot_encargo;
        public TList_OrcProjeto lOrcProjeto { get; set; } = new TList_OrcProjeto();
        public TList_OrcProjeto lOrcProjetoDel { get; set; } = new TList_OrcProjeto();
        public TList_Despesas lDespesas { get; set; } = new TList_Despesas();
        public TList_Despesas lDespesasDel { get; set; } = new TList_Despesas();
        public TList_Tarefas lTarefas { get; set; } = new TList_Tarefas();
        public TList_RequisitoORc lRequisitos { get; set; } = new TList_RequisitoORc();
        public TList_RequisitoORc lDelRequisitos { get; set; } = new TList_RequisitoORc();
        public TList_Tarefas lTarefasDel { get; set; } = new TList_Tarefas();
        public Cadastro.TList_OrcamentoEncargo lOEncargo { get; set; } = new Cadastro.TList_OrcamentoEncargo();
        public Cadastro.TList_OrcamentoEncargo lOEncargoDel { get; set; } = new Cadastro.TList_OrcamentoEncargo();
        public Cadastro.TList_CadMaoObra lMaoObra { get; set; } = new Cadastro.TList_CadMaoObra();
        public Cadastro.TList_CadMaoObra lMaoObraDel { get; set; } = new Cadastro.TList_CadMaoObra();
        public bool st_aprovar { get; set; } = false;
        public decimal total_faturado { get; set; } = decimal.Zero;

        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = DateTime.Parse(value);
                }
                catch { dt_validadestr = null; }
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_Orcamento : TDataQuery
    {
        public TCD_Orcamento() { }

        public TCD_Orcamento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_condpgto,K.DS_CONDPGTO, a.cd_empresa, b.nm_empresa, a.nr_versaoorc, a.id_orc, ");
                sql.AppendLine("  a.id_orcamento, a.nr_versao, a.cd_clifor, c.nm_clifor, ");
                sql.AppendLine("case when c.tp_pessoa = 'J' then c.NR_CGC else c.nr_cpf end as CNPJ_CPF, ");
                sql.AppendLine("d.CD_Endereco, d.DS_Endereco, a.CD_Vendedor, g.NM_Clifor as nm_vendedor, ");
                sql.AppendLine("a.ds_empreendimento, a.ds_enderecoemp, a.numeroemp, a.bairroemp, ");
                sql.AppendLine("a.foneemp, a.cd_cidadeemp, e.DS_Cidade as ds_cidadeemp, e.CD_UF as cd_ufemp, ");
                sql.AppendLine("f.uf as uf_emp, a.dt_orcamento, a.dt_previni, a.st_empglobal, ");
                sql.AppendLine("a.dt_prevfin, a.st_registro, a.vl_orcamento, ");
                sql.AppendLine("a.PC_ISSQN, a.PC_Comissao, a.PC_CustoFin,a.loginorc ,a.id_contato, j.nm_contato, j.email as email_contato, j.fone as fone_contato, ");
                sql.AppendLine("a.dt_entregaproposta, a.PC_IRPJ, a.PC_CSLL, a.PC_PIS, a.PC_Cofins, a.PC_MargemCont, a.PC_IRPJAdic, a.PC_INSS, a.PC_DescProg, a.PC_Desconto, ");
                sql.AppendLine("a.Total_FichaFP, A.Total_FichaFD, a.Total_Despesas, a.total_folha, a.total_encargo, a.total_faturado, a.dt_validade ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_EMP_Orcamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.cd_clifor = d.CD_Clifor ");
            sql.AppendLine("and a.cd_endereco = d.cd_endereco ");
            sql.AppendLine("left join TB_FIN_Cidade e ");
            sql.AppendLine("on a.cd_cidadeemp = e.CD_Cidade ");
            sql.AppendLine("left join TB_FIN_UF f ");
            sql.AppendLine("on e.CD_UF = f.cd_uf ");
            sql.AppendLine("left outer join TB_FIN_Clifor g ");
            sql.AppendLine("on a.CD_Vendedor = g.CD_Clifor ");
            sql.AppendLine("left join TB_EMP_CFGEmpreendimento i ");
            sql.AppendLine("on i.cd_empresa = a.cd_empresa");
            sql.AppendLine("left outer join TB_FIN_ContatoClifor j ");
            sql.AppendLine("on a.cd_clifor = j.cd_clifor ");
            sql.AppendLine("and a.id_contato = j.id_contato ");
            sql.AppendLine("LEFT JOIN TB_FIN_CONDPGTO K ON K.CD_CONDPGTO = A.CD_CONDPGTO ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if(string.IsNullOrEmpty(vNM_Campo))
            sql.AppendLine("order by a.id_orcamento asc");
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

        public TList_Orcamento Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento lista = new TList_Orcamento();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento reg = new TRegistro_Orcamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_condpgto")))
                        reg.DS_condpgto = reader.GetString(reader.GetOrdinal("DS_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_contato")))
                        reg.id_contato = reader.GetDecimal(reader.GetOrdinal("id_contato")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_contato")))
                        reg.Nm_contato = reader.GetString(reader.GetOrdinal("nm_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_contato")))
                        reg.Fone_contato = reader.GetString(reader.GetOrdinal("fone_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email_contato")))
                        reg.Email_contato = reader.GetString(reader.GetOrdinal("email_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Orc")))
                        reg.Id_orc = reader.GetDecimal(reader.GetOrdinal("ID_Orc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_VersaoOrc")))
                        reg.Nr_versaoOrc = reader.GetDecimal(reader.GetOrdinal("NR_VersaoOrc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CNPJ_CPF")))
                        reg.Cnpj_cpf = reader.GetString(reader.GetOrdinal("CNPJ_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_empreendimento")))
                        reg.Ds_empreendimento = reader.GetString(reader.GetOrdinal("ds_empreendimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_enderecoemp")))
                        reg.Ds_enderecoemp = reader.GetString(reader.GetOrdinal("ds_enderecoemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numeroemp")))
                        reg.Numeroemp = reader.GetString(reader.GetOrdinal("numeroemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairroemp")))
                        reg.Bairroemp = reader.GetString(reader.GetOrdinal("bairroemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("foneemp")))
                        reg.Foneemp = reader.GetString(reader.GetOrdinal("foneemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidadeemp")))
                        reg.Cd_cidadeemp = reader.GetString(reader.GetOrdinal("cd_cidadeemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeemp")))
                        reg.Ds_cidadeemp = reader.GetString(reader.GetOrdinal("ds_cidadeemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ufemp")))
                        reg.Cd_ufemp = reader.GetString(reader.GetOrdinal("cd_ufemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_emp")))
                        reg.Uf_emp = reader.GetString(reader.GetOrdinal("uf_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_orcamento")))
                        reg.Dt_orcamento = reader.GetDateTime(reader.GetOrdinal("dt_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_entregaproposta")))
                        reg.Dt_proposta = reader.GetDateTime(reader.GetOrdinal("dt_entregaproposta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_previni")))
                        reg.Dt_previni = reader.GetDateTime(reader.GetOrdinal("dt_previni"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevfin")))
                        reg.Dt_prevfin = reader.GetDateTime(reader.GetOrdinal("dt_prevfin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_orcamento")))
                        reg.vl_orcamento = reader.GetDecimal(reader.GetOrdinal("vl_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ISSQN")))
                        reg.Pc_issqn = reader.GetDecimal(reader.GetOrdinal("PC_ISSQN"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("PC_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_CustoFin")))
                        reg.Pc_custofin = reader.GetDecimal(reader.GetOrdinal("PC_CustoFin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IRPJ")))
                        reg.Pc_irpj = reader.GetDecimal(reader.GetOrdinal("PC_IRPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_CSLL")))
                        reg.Pc_csll = reader.GetDecimal(reader.GetOrdinal("PC_CSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_PIS")))
                        reg.Pc_pis = reader.GetDecimal(reader.GetOrdinal("PC_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Cofins")))
                        reg.Pc_cofins = reader.GetDecimal(reader.GetOrdinal("PC_Cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IRPJAdic")))
                        reg.Pc_irpjAdic = reader.GetDecimal(reader.GetOrdinal("PC_IRPJAdic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_INSS")))
                        reg.Pc_inss = reader.GetDecimal(reader.GetOrdinal("PC_INSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_MargemCont")))
                        reg.Pc_margemcont = reader.GetDecimal(reader.GetOrdinal("PC_MargemCont"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_DescProg")))
                        reg.Pc_descprog = reader.GetDecimal(reader.GetOrdinal("PC_DescProg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Desconto")))
                        reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("PC_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginorc")))
                        reg.loginorc = reader.GetString(reader.GetOrdinal("loginorc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_empglobal")))
                        reg.St_empglobal = reader.GetString(reader.GetOrdinal("st_empglobal"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Total_FichaFP")))
                        reg.ficha_fp = reader.GetDecimal(reader.GetOrdinal("Total_FichaFP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Total_FichaFD")))
                        reg.ficha_fd = reader.GetDecimal(reader.GetOrdinal("Total_FichaFD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Total_Despesas")))
                        reg.Custo_Despesas = reader.GetDecimal(reader.GetOrdinal("Total_Despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("total_folha")))
                        reg.custo_folha = reader.GetDecimal(reader.GetOrdinal("total_folha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("total_encargo")))
                        reg.tot_encargo = reader.GetDecimal(reader.GetOrdinal("total_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("total_faturado")))
                        reg.total_faturado = reader.GetDecimal(reader.GetOrdinal("total_faturado"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("Dt_validade"));

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

        public string Gravar(TRegistro_Orcamento val)
        {
            Hashtable hs = new Hashtable(34);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONDPGTO", val.cd_condpgto);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_CONTATO", val.id_contato);
            hs.Add("@P_ID_ORC", val.Id_orc);
            hs.Add("@P_NR_VERSAOORC", val.Nr_versaoOrc);
            hs.Add("@P_DS_EMPREENDIMENTO", val.Ds_empreendimento);
            hs.Add("@P_DS_ENDERECOEMP", val.Ds_enderecoemp);
            hs.Add("@P_NUMEROEMP", val.Numeroemp);
            hs.Add("@P_BAIRROEMP", val.Bairroemp);
            hs.Add("@P_FONEEMP", val.Foneemp);
            hs.Add("@P_CD_CIDADEEMP", val.Cd_cidadeemp);
            hs.Add("@P_DT_ORCAMENTO", val.Dt_orcamento);
            hs.Add("@P_DT_ENTREGAPROPOSTA", val.Dt_proposta);
            hs.Add("@P_DT_PREVINI", val.Dt_previni);
            hs.Add("@P_DT_PREVFIN", val.Dt_prevfin);
            hs.Add("@P_VL_ORCAMENTO", val.vl_orcamento);
            hs.Add("@P_PC_ISSQN", val.Pc_issqn);
            hs.Add("@P_PC_COMISSAO", val.Pc_comissao);
            hs.Add("@P_PC_CUSTOFIN", val.Pc_custofin);
            hs.Add("@P_PC_IRPJ", val.Pc_irpj);
            hs.Add("@P_PC_CSLL", val.Pc_csll);
            hs.Add("@P_PC_PIS", val.Pc_pis);
            hs.Add("@P_PC_COFINS", val.Pc_cofins);
            hs.Add("@P_PC_IRPJADIC", val.Pc_irpjAdic);
            hs.Add("@P_PC_INSS", val.Pc_inss);
            hs.Add("@P_PC_MARGEMCONT", val.Pc_margemcont);
            hs.Add("@P_PC_DESCPROG", val.Pc_descprog);
            hs.Add("@P_PC_DESCONTO", val.Pc_desconto);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_LOGINORC", val.loginorc);
            hs.Add("@P_ST_EMPGLOBAL", val.St_empglobal);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);

            return executarProc("IA_EMP_ORCAMENTO", hs);
        }

        public string Excluir(TRegistro_Orcamento val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);

            return executarProc("EXCLUI_EMP_ORCAMENTO", hs);
        }
    }
    #endregion

    #region Projetos Orcamento
    public class TList_OrcProjeto : List<TRegistro_OrcProjeto> { }

    public class TRegistro_OrcProjeto : ICloneable
    {
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string id_contato { get; set; } = string.Empty;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_projeto;
        public decimal? Id_projeto
        {
            get { return id_projeto; }
            set
            {
                id_projeto = value;
                id_projetostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_projetostr;
        public string Id_projetostr
        {
            get { return id_projetostr; }
            set
            {
                id_projetostr = value;
                try
                {
                    id_projeto = decimal.Parse(value);
                }
                catch { id_projeto = null; }
            }
        }
        public string Ds_projeto
        { get; set; }
        public string Obs
        { get; set; }
        public decimal Vl_subtotal { get; set; }
        public bool st_importar { get; set; }

        public TList_FichaTec lFicha
        { get; set; }
        public TList_FichaTec lFichaDel
        { get; set; }
        
        public TRegistro_OrcProjeto()
        {
            st_importar = false;
            Cd_empresa = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            nr_versao = null;
            nr_versaostr = string.Empty;
            id_projeto = null;
            id_projetostr = string.Empty;
            Ds_projeto = string.Empty;
            Obs = string.Empty;
            Vl_subtotal = decimal.Zero;
            lFicha = new TList_FichaTec();
            lFichaDel = new TList_FichaTec();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_OrcProjeto : TDataQuery
    {
        public TCD_OrcProjeto() { }
        public TCD_OrcProjeto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_registro, a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_atividade, c.ds_atividade, a.obs, a.vl_subtotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_emp_atividade a ");
            sql.AppendLine("left join vtb_emp_orcamento b on a.id_orcamento = b.id_orcamento and a.nr_versao = b.nr_versao and a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left join tb_emp_cadatividade c on c.id_atividade = a.id_atividade");


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
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string groupBy)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_OrcProjeto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OrcProjeto lista = new TList_OrcProjeto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrcProjeto reg = new TRegistro_OrcProjeto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_atividade")))
                        reg.Ds_projeto = reader.GetString(reader.GetOrdinal("ds_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));

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
        public string Gravar(TRegistro_OrcProjeto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_DS_PROJETO", val.Ds_projeto);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_EMP_ATIVIDADE", hs);
        }
        public string Excluir(TRegistro_OrcProjeto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);

            return executarProc("EXCLUI_EMP_ATIVIDADE", hs);
        }
    }
    #endregion

    #region atividaderequisito

    public class TRegistro_Requisitos
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;

        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string id_contato { get; set; } = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        public string id_atividade { get; set; } = string.Empty;
        public string id_requisito { get; set; } = string.Empty;
        public string ds_requisito { get; set; } = string.Empty;
        public bool st_agregar { get; set; } = false;

        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
    }

    public class TList_Requisitos : List<TRegistro_Requisitos> { }

    public class TCD_Requisitos : TDataQuery
    {
        public TCD_Requisitos() { }
        public TCD_Requisitos(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_atividade, a.id_requisito, a.id_registro, a.id_orcamento, a.nr_versao, a.cd_empresa, b.ds_requisito ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_Requisitos a ");
            sql.AppendLine(" left join TB_EMP_RequisitosAtividade b on b.id_atividade = a.id_atividade and a.id_requisito = b.id_requisito ");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_Requisitos Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Requisitos lista = new TList_Requisitos();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_Requisitos reg = new TRegistro_Requisitos();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.id_atividade = reader.GetDecimal(reader.GetOrdinal("id_atividade")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_requisito")))
                        reg.id_requisito = reader.GetDecimal(reader.GetOrdinal("id_requisito")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_requisito")))
                        reg.ds_requisito = reader.GetString(reader.GetOrdinal("ds_requisito"));

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
        public string Gravar(TRegistro_Requisitos val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);
            hs.Add("@P_ID_ATIVIDADE", val.id_atividade);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);

            return executarProc("IA_EMP_REQUISITOS", hs);
        }
        public string Excluir(TRegistro_Requisitos val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);
            hs.Add("@P_ID_ATIVIDADE", val.id_atividade);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);

            return executarProc("EXCLUI_EMP_REQUISITOS", hs);
        }
    }
    #endregion

    #region Ficha Tec
    public class TList_FichaTec : List<TRegistro_FichaTec> { }

    public class TRegistro_FichaTec : ICloneable
    {
        public CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImpostos { get; set; } = new Faturamento.NotaFiscal.TList_ImpostosNF();

        private decimal? id_registro;
        public string ds_atividade { get; set; } = string.Empty;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string id_contato { get; set; } = string.Empty;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_projeto;
        public decimal? Id_projeto
        {
            get { return id_projeto; }
            set
            {
                id_projeto = value;
                id_projetostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_projetostr;
        public string Id_projetostr
        {
            get { return id_projetostr; }
            set
            {
                id_projetostr = value;
                try
                {
                }
                catch { id_projeto = null; }
            }
        }
        private decimal? id_ficha;
        public decimal? Id_ficha
        {
            get { return id_ficha; }
            set
            {
                id_ficha = value;
                id_fichastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_fichastr;
        public string Id_fichastr
        {
            get { return id_fichastr; }
            set
            {
                id_fichastr = value;
                try
                {
                    id_ficha = decimal.Parse(value);
                }
                catch { id_ficha = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade { get; set; } = string.Empty;
        public string Ds_unidade { get; set; } = string.Empty;
        public string Sg_unidade
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal qtd_saida { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_Executado
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_ultimacompra { get; set; } = decimal.Zero;
        private string st_fatdireto;
        public string St_fatdireto
        {
            get { return st_fatdireto; }
            set
            {
                st_fatdireto = value;
                st_fatdiretobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_fatdiretobool;
        public bool St_fatdiretobool
        {
            get { return st_fatdiretobool; }
            set
            {
                st_fatdiretobool = value;
                st_fatdireto = value ? "S" : "N";
            }
        }
        private string st_addremessa;
        public string St_addremessa
        {
            get { return st_addremessa; }
            set
            {
                st_addremessa = value;
                st_addremessabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_addremessabool;
        public bool St_addremessabool
        {
            get { return st_addremessabool; }
            set
            {
                st_addremessabool = value;
                st_addremessa = value ? "S" : "N";
            }
        }
        public decimal Qtd_faturada { get; set; } = decimal.Zero;
        public decimal Sd_faturar
        { get { return Quantidade - Qtd_faturada; } }
        public bool st_agregar { get; set; } = false;
        public decimal Tot_saldo { get; set; } = decimal.Zero;
        public decimal quantidade_agregar { get; set; }
        public decimal qtd_requisitado { get; set; } = decimal.Zero;
        public string cd_grupo { get; set; } = string.Empty;
        public string ds_grupo { get; set; } = string.Empty;
        public TList_FichaItens lfichaItens { get; set; }
        public TList_FichaItens lfichaItensDel { get; set; }
        public decimal qtd_aprovado { get; set; } = decimal.Zero; 
        public decimal qtd_n_aprovado { get; set; } = decimal.Zero; 
        public string st_composto { get; set; }
        public decimal Vl_unitarioAtual { get; set; } = decimal.Zero;

        public TRegistro_FichaTec()
        {
            lImpostos = new Faturamento.NotaFiscal.TList_ImpostosNF();
            quantidade_agregar = decimal.Zero;
            st_agregar = false;
            Cd_empresa = string.Empty;
            Vl_Executado = decimal.Zero;
            id_orcamento = null;
            qtd_saida = decimal.Zero;
            id_orcamentostr = string.Empty;
            nr_versao = null;
            st_composto = string.Empty;
            nr_versaostr = string.Empty;
            id_projeto = null;
            id_projetostr = string.Empty;
            id_ficha = null;
            id_fichastr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sg_unidade = string.Empty;
            Quantidade = 1;
            Vl_unitario = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            st_fatdireto = string.Empty;
            st_fatdiretobool = false;
            st_addremessa = string.Empty;
            st_addremessabool = false;
            lfichaItensDel = new TList_FichaItens();
            lfichaItens = new TList_FichaItens();
            ds_atividade = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_FichaTec : TDataQuery
    {
        public TCD_FichaTec() { }

        public TCD_FichaTec(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " i.cd_grupo, i.ds_grupo, d.st_composto,e.ds_atividade, a.cd_empresa, a.id_orcamento, a.id_registro, ");
                sql.AppendLine("a.nr_versao, a.id_atividade, e.ds_atividade, a.id_ficha, a.st_fatdireto, a.st_addremessa, ");
                sql.AppendLine("a.cd_produto, isnull(a.ds_produto, b.ds_produto) as ds_produto, b.cd_unidade, c.ds_unidade, c.sigla_unidade, ");
                sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_subtotal, a.qtd_faturada, ");
                sql.AppendLine("f.Tot_saldo, ");
                sql.AppendLine("qtd_saida = (isnull((select sum(x.Quantidade)  from TB_EMP_FichaTec x where x.cd_produto = a.CD_Produto and x.st_fatdireto in ('N')),0) ");
                sql.AppendLine(" - isnull((select sum(z.quantidade) from TB_EMP_NFRemessa y ");
                sql.AppendLine("join TB_FAT_NotaFiscal_Item z on y.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
                sql.AppendLine("where z.CD_Produto = a.CD_Produto ),0)), ");
                sql.AppendLine("qtd_requisitado =(a.quantidade-  (select sum(x.Quantidade) from TB_CMP_Requisicao x  ");
                sql.AppendLine("    join TB_EMP_CompraEmpreendimento Y ON Y.ID_Requisicao = X.ID_Requisicao AND Y.ID_ORCAMENTO = A.ID_ORCAMENTO ");
                sql.AppendLine("    AND Y.NR_Versao = A.NR_Versao AND Y.ID_Ficha = A.ID_Ficha AND Y.ID_Atividade = A.ID_Atividade where x.CD_PRODUTO = B.CD_PRODUTO and g.ID_TpRequisicao = x.ID_TpRequisicao )), ");
                sql.AppendLine("qtd_aprovado = ( select sum(x.QTD_APROVADA) from TB_CMP_Requisicao x ");
                sql.AppendLine("    where x.st_requisicao in('AP') and x.cd_produto = a.cd_produto), ");
                sql.AppendLine("qtd_n_aprovado = (select(sum(x.quantidade) - sum(x.QTD_APROVADA)) from TB_CMP_Requisicao x ");
                sql.AppendLine("    where x.cd_produto = a.cd_produto), ");
                sql.AppendLine("Vl_ultimacompra = case when isnull(a.cd_produto, '') = '' then 0 else isnull(dbo.F_FAT_ULTIMACOMPRA(a.cd_empresa, a.cd_produto), 0) end ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_emp_fichatec a ");
            sql.AppendLine("left join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("left join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left join TB_EST_TpProduto d ");
            sql.AppendLine("on b.tp_produto = d.tp_produto ");
            sql.AppendLine("left join tb_emp_cadatividade e ");
            sql.AppendLine("on a.id_atividade = e.id_atividade");
            sql.AppendLine("left join vtb_est_vlestoque f ");
            sql.AppendLine("on a.cd_produto = f.cd_produto and a.cd_empresa = f.cd_empresa");
            sql.AppendLine("left join tb_emp_cfgempreendimento g ");
            sql.AppendLine("on a.cd_empresa = g.cd_empresa ");
            sql.AppendLine("left join TB_EST_LocalArm h on h.CD_Local = g.CD_Local ");
            sql.AppendLine("left join tb_est_grupoproduto i on i.cd_grupo = b.cd_grupo ");
            sql.AppendLine("left join vtb_est_vlestoque j on j.cd_produto = a.CD_Produto and j.cd_empresa = a.CD_Empresa ");
            

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

        public TList_FichaTec Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FichaTec lista = new TList_FichaTec();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaTec reg = new TRegistro_FichaTec();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("Cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("Ds_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_faturada")))
                        reg.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("qtd_faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_fatdireto")))
                        reg.St_fatdireto = reader.GetString(reader.GetOrdinal("st_fatdireto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_addremessa")))
                        reg.St_addremessa = reader.GetString(reader.GetOrdinal("st_addremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ultimacompra")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ultimacompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_composto")))
                        reg.st_composto = reader.GetString(reader.GetOrdinal("st_composto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_atividade")))
                        reg.ds_atividade = reader.GetString(reader.GetOrdinal("ds_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_saldo")))
                        reg.Tot_saldo = reader.GetDecimal(reader.GetOrdinal("Tot_saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_aprovado")))
                        reg.qtd_aprovado = reader.GetDecimal(reader.GetOrdinal("qtd_aprovado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_n_aprovado")))
                        reg.qtd_n_aprovado = reader.GetDecimal(reader.GetOrdinal("qtd_n_aprovado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_requisitado")))
                        reg.qtd_requisitado = reader.GetDecimal(reader.GetOrdinal("qtd_requisitado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));

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
        public string Gravar(TRegistro_FichaTec val)
        {
            Hashtable hs = new Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_DS_PRODUTO", val.Ds_produto);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_ST_FATDIRETO", val.St_fatdireto);
            hs.Add("@P_ST_ADDREMESSA", val.St_addremessa);

            return executarProc("IA_EMP_FICHATEC", hs);
        }
        public string Excluir(TRegistro_FichaTec val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_FICHA", val.Id_ficha);

            return executarProc("EXCLUI_EMP_FICHATEC", hs);
        }
    }
    #endregion

    #region Despesas
    public class TList_Despesas : List<TRegistro_Despesas> { }

    public class TRegistro_Despesas : ICloneable
    {
        public string Cd_empresa
        { get; set; }
        public bool st_importar { get; set; } = false;
        private decimal? id_RegDesp;
        public decimal? Id_RegDesp
        {
            get { return id_RegDesp; }
            set
            {
                id_RegDesp = value;
                id_RegDespstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_RegDespstr;
        public string Id_RegDespstr
        {
            get { return id_RegDespstr; }
            set
            {
                id_RegDespstr = value;
                try
                {
                    id_RegDesp = decimal.Parse(value);
                }
                catch { id_RegDesp = null; }
            }
        }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;

            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        private decimal? id_cargo;
        public decimal? Id_cargo
        {
            get { return id_cargo; }
            set
            {
                id_cargo = value;
                id_cargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargostr;
        public string Id_cargostr
        {
            get { return id_cargostr; }
            set
            {
                id_cargostr = value;
                try
                {
                    id_cargo = decimal.Parse(value);
                }
                catch { id_cargo = null; }
            }
        }
        public string Ds_cargo
        { get; set; }
        public decimal Vl_basesalario
        { get; set; }
        public decimal Cargahorariames
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public string ST_AddExec { get; set;}

        public decimal vl_executado
        { get; set; }
        public TRegistro_Despesas()
        {
            Cd_empresa = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            nr_versao = null;
            nr_versaostr = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Ds_despesa = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            id_cargo = null;
            id_cargostr = string.Empty;
            Ds_cargo = string.Empty;
            Vl_basesalario = decimal.Zero;
            Cargahorariames = decimal.Zero;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            vl_executado = decimal.Zero;
            Id_RegDesp = decimal.Zero;
            ST_AddExec = string.Empty;
        }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_Despesas : TDataQuery
    {
        public TCD_Despesas() { }
        public TCD_Despesas(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_regdesp, a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_despesa, b.ds_despesa, ");
                sql.AppendLine("a.Quantidade, a.Vl_Unitario, a.Vl_SubTotal, a.ST_AddExec, a.vl_executado ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vTB_EMP_Despesas a ");
            sql.AppendLine("join TB_EMP_CadDespesa b on a.id_despesa = b.id_despesa");
            string cond = " where";
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
        public TList_Despesas Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Despesas lista = new TList_Despesas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try 
            { 
                while (reader.Read())
                {
                    TRegistro_Despesas reg = new TRegistro_Despesas();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_RegDesp")))
                        reg.Id_RegDesp = reader.GetDecimal(reader.GetOrdinal("Id_RegDesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_AddExec")))
                        reg.ST_AddExec = reader.GetString(reader.GetOrdinal("ST_AddExec"));
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
        public string Gravar(TRegistro_Despesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_REGDESP", val.Id_RegDesp);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_CARGO", val.Id_cargo);
            hs.Add("@P_DS_DESPESA", val.Ds_despesa);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_ST_ADDEXEC", val.ST_AddExec);

            return executarProc("IA_EMP_DESPESAS", hs);
        }
        public string Excluir(TRegistro_Despesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_REGDESP", val.Id_RegDesp);

            return executarProc("EXCLUI_EMP_DESPESAS", hs);
        }
    }
    #endregion

    #region remessanf

    public class TRegistro_RemessaNf
    {
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string id_contato { get; set; } = string.Empty;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal vl_orcamento { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string st_registro { get; set; } = string.Empty;
        public string nr_danfe { get; set; } = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }
        public string id_orc { get; set; }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }

        public string nr_lanctofiscal { get; set; }
        public string id_nfitem { get; set; }
        public decimal id_ficha { get; set; }
        public decimal id_projeto { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItens { get; set; } = new Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
        public TList_RemessaNf lItensremessa { get; set; } = new TList_RemessaNf();

        public decimal vl_unitario { get; set; }
        public decimal quantidade { get; set; }
        public decimal vl_subtotal { get; set; }
        public decimal id_atividade { get; set; }
        public string cd_produto { get; set; }
        public TRegistro_RemessaNf()
        {
            id_nfitem = string.Empty;
            id_orc = string.Empty;
            Id_orcamento = decimal.Zero;
            Cd_empresa = string.Empty;
            nr_lanctofiscal = string.Empty;
            Nr_versaostr = string.Empty;
            cd_produto = string.Empty;
            id_projeto = decimal.Zero;
            id_ficha = decimal.Zero;
            vl_unitario = decimal.Zero;
            quantidade = decimal.Zero;
            vl_subtotal = decimal.Zero;
            id_atividade = decimal.Zero;
            lItensremessa = new TList_RemessaNf();

        }
    }
    public class TList_RemessaNf : List<TRegistro_RemessaNf> { }

    public class TCD_RemessaNf : TDataQuery
    {
        public TCD_RemessaNf() { }

        public TCD_RemessaNf(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.nr_lanctofiscal, c.dt_emissao, c.nr_notafiscal ");
                sql.AppendLine(", st_registro = (select case x.st_registro when 'A' then 'PROCESSADO' ELSE 'CANCELADO' END from tb_fat_notafiscal x where x.nr_lanctofiscal = a.nr_lanctofiscal and a.cd_empresa = x.cd_empresa)");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_NFRemessa a ");
            sql.AppendLine("left join vtb_emp_orcamento b ");
            sql.AppendLine("on a.id_orcamento = b.id_orcamento and a.nr_versao = b.nr_versao");
            sql.AppendLine("join TB_FAT_NotaFiscal c on a.Nr_LanctoFiscal = c.Nr_LanctoFiscal and a.cd_empresa = c.cd_empresa");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by a.cd_empresa, a.id_orcamento, a.nr_versao, a.nr_lanctofiscal, c.dt_emissao, c.nr_notafiscal ");//a.id_atividade,
            return sql.ToString();
        }
        private string SqlCodeBuscaItens(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_registro , a.nr_lanctofiscal, a.id_atividade, a.id_ficha,  ");
                sql.AppendLine(" vl_subtotal = (select x.vl_subtotal from TB_FAT_NotaFiscal_Item x where ");
                sql.AppendLine("                 x.Nr_LanctoFiscal = c.Nr_LanctoFiscal and x.cd_empresa = c.cd_empresa and a.id_nfitem = x.id_nfitem), ");
                sql.AppendLine(" st_registro = (select case x.st_registro when 'A' then 'PROCESSADO' ELSE 'CANCELADO' END from tb_fat_notafiscal x where x.nr_lanctofiscal = a.nr_lanctofiscal and a.cd_empresa = x.cd_empresa) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_NFRemessa a ");
            sql.AppendLine("left join vtb_emp_orcamento b ");
            sql.AppendLine("on a.id_orcamento = b.id_orcamento and a.nr_versao = b.nr_versao");
            sql.AppendLine("join TB_FAT_NotaFiscal c on a.Nr_LanctoFiscal = c.Nr_LanctoFiscal and a.cd_empresa = c.cd_empresa");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
       //     sql.AppendLine("group by a.cd_empresa, a.id_orcamento, a.nr_versao, a.id_registro , a.nr_lanctofiscal,  c.vl_unitario,c.quantidade,c.vl_subtotal,a.id_atividade, a.id_ficha, c.cd_Produto ");//a.id_atividade,
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

        public TList_RemessaNf Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RemessaNf lista = new TList_RemessaNf();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_RemessaNf reg = new TRegistro_RemessaNf();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.nr_danfe = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.st_registro = reader.GetString(reader.GetOrdinal("st_registro")).ToString();

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

        public TList_RemessaNf SelectItens(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RemessaNf lista = new TList_RemessaNf();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaItens(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_RemessaNf reg = new TRegistro_RemessaNf();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));

                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.id_atividade = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                    //    reg.id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem")).ToString(); 

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
        public string Gravar(TRegistro_RemessaNf val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.id_projeto);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_FICHA", val.id_ficha);
            hs.Add("@P_NR_LANCTOFISCAL", val.nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.id_nfitem);

            return executarProc("IA_EMP_NFREMESSA", hs);
        }




    }

    #endregion

    #region requisicaoorc

    public class TRegistro_RequisitoOrc
    {
        public string cd_empresa { get; set; } = string.Empty;
        public decimal id_orcamento { get; set; } = decimal.Zero;
        public decimal nr_versao { get; set; } = decimal.Zero;
        public decimal id_requisito { get; set; } = decimal.Zero;
        public string obs { get; set; } = string.Empty;
        public string ds_requisito { get; set; } = string.Empty;

    }

    public class TList_RequisitoORc : List<TRegistro_RequisitoOrc> { }

    public class TCD_RequisitoOrc : TDataQuery
    {

        public TCD_RequisitoOrc() { }

        public TCD_RequisitoOrc(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, a.id_requisito, ");
                sql.AppendLine("a.nr_versao, b.ds_requisito, a.obs ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_requisitos a ");
            sql.AppendLine("left join TB_EMP_Cadrequisito b on b.id_requisito = a.id_requisito"); 

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            //sql.AppendLine("order by a.dt_cad desc ");

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
        public TList_RequisitoORc Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RequisitoORc lista = new TList_RequisitoORc();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_RequisitoOrc reg = new TRegistro_RequisitoOrc();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_requisito")))
                        reg.id_requisito = reader.GetDecimal(reader.GetOrdinal("id_requisito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.obs = reader.GetString(reader.GetOrdinal("obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_requisito")))
                        reg.ds_requisito = reader.GetString(reader.GetOrdinal("ds_requisito"));

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
        public string Gravar(TRegistro_RequisitoOrc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.id_orcamento);
            hs.Add("@P_NR_VERSAO", val.nr_versao);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);
            hs.Add("@P_OBS", val.obs);

            return executarProc("IA_EMP_REQUISITOS", hs);
        }
        public string Excluir(TRegistro_RequisitoOrc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.id_orcamento);
            hs.Add("@P_NR_VERSAO", val.nr_versao);
            hs.Add("@P_ID_REQUISITO", val.id_requisito);

            return executarProc("EXCLUI_EMP_REQUISITOS", hs);
        }
    }




    #endregion

    #region
    public class TList_Tarefas : List<TRegistro_Tarefas> { }

    public class TRegistro_Tarefas : ICloneable
    {
        public string Cd_empresa { get; set; } = string.Empty;
        private decimal? id_orcamento = null;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr = string.Empty;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao = null;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_tarefa = null;
        public decimal? Id_tarefa
        {
            get { return id_tarefa; }
            set
            {
                id_tarefa = value;
                id_tarefastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tarefastr;
        public string Id_tarefastr
        {
            get { return id_tarefastr; }
            set
            {
                id_tarefastr = value;
                try
                {
                    id_tarefa = decimal.Parse(value);
                }
                catch { id_tarefa = null; }
            }
        }
        public string Login { get; set; } = string.Empty;
        public string Ds_tarefa { get; set; } = string.Empty;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_Tarefas:TDataQuery
    {
        public TCD_Tarefas() { }

        public TCD_Tarefas(BancoDados.TObjetoBanco banco) { Banco_Dados = banco;}

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_tarefa, a.login, a.ds_tarefa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_Tarefas a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.dt_cad desc ");

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
        public TList_Tarefas Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Tarefas lista = new TList_Tarefas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Tarefas reg = new TRegistro_Tarefas();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tarefa")))
                        reg.Id_tarefa = reader.GetDecimal(reader.GetOrdinal("id_tarefa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tarefa")))
                        reg.Ds_tarefa = reader.GetString(reader.GetOrdinal("ds_tarefa"));

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
        public string Gravar(TRegistro_Tarefas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_TAREFA", val.Id_tarefa);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_TAREFA", val.Ds_tarefa);

            return executarProc("IA_EMP_TAREFAS", hs);
        }
        public string Excluir(TRegistro_Tarefas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_TAREFA", val.Id_tarefa);

            return executarProc("EXCLUI_EMP_TAREFAS", hs);
        }
    }
    #endregion
}
