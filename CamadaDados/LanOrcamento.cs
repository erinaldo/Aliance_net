using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public class TRegistro_Orcamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
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
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cnpj_cpf
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Login
        { get; set; }
        public string Ds_empreendimento
        { get; set; }
        public string Ds_enderecoemp
        { get; set; }
        public string Numeroemp
        { get; set; }
        public string Bairroemp
        { get; set; }
        public string Foneemp
        { get; set; }
        public string Cd_cidadeemp
        { get; set; }
        public string Ds_cidadeemp
        { get; set; }
        public string Cd_ufemp
        { get; set; }
        public string Uf_emp
        { get; set; }
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
        public string Ds_motivo
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "APROVADO";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "REPROVADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("N"))
                    status = "NEGOCIACAO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("APROVADO"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("REPROVADO"))
                    st_registro = "R";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("NEGOCIACAO"))
                    st_registro = "N";
            }
        }
        public decimal Total_Ficha
        { get; set; }
        public decimal Total_Despesas
        { get; set; }
        public decimal Resultado
        { get { return Total_Ficha + Total_Despesas; } }
        public TList_OrcProjeto lOrcProjeto
        { get; set; }
        public TList_OrcProjeto lOrcProjetoDel
        { get; set; }
        public TList_Despesas lDespesas
        { get; set; }
        public TList_Despesas lDespesasDel
        { get; set; }

        public TRegistro_Orcamento()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cnpj_cpf = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Login = string.Empty;
            this.Ds_empreendimento = string.Empty;
            this.Ds_enderecoemp = string.Empty;
            this.Numeroemp = string.Empty;
            this.Bairroemp = string.Empty;
            this.Foneemp = string.Empty;
            this.Cd_cidadeemp = string.Empty;
            this.Ds_cidadeemp = string.Empty;
            this.Cd_ufemp = string.Empty;
            this.Uf_emp = string.Empty;
            this.dt_orcamento = null;
            this.dt_orcamentostr = string.Empty;
            this.dt_previni = null;
            this.dt_previnistr = string.Empty;
            this.dt_prevfin = null;
            this.dt_prevfinstr = string.Empty;
            this.Ds_motivo = string.Empty;
            this.st_registro = string.Empty;
            this.Total_Ficha = decimal.Zero;
            this.Total_Despesas = decimal.Zero;

            this.lOrcProjeto = new TList_OrcProjeto();
            this.lOrcProjetoDel = new TList_OrcProjeto();
            this.lDespesas = new TList_Despesas();
            this.lDespesasDel = new TList_Despesas();
        }
    }

    public class TCD_Orcamento : TDataQuery
    {
        public TCD_Orcamento() { }
        
        public TCD_Orcamento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_orcamento, a.nr_versao, a.cd_clifor, c.nm_clifor, ");
                sql.AppendLine("case when c.tp_pessoa = 'J' then c.NR_CGC else c.nr_cpf end as CNPJ_CPF, ");
                sql.AppendLine("a.CD_Endereco, d.DS_Endereco, a.CD_Vendedor, g.NM_Clifor as nm_vendedor, ");
                sql.AppendLine("a.login, a.ds_empreendimento, a.ds_enderecoemp, a.numeroemp, a.bairroemp, ");
                sql.AppendLine("a.foneemp, a.cd_cidadeemp, e.DS_Cidade as ds_cidadeemp, e.CD_UF as cd_ufemp, ");
                sql.AppendLine("f.uf as uf_emp, a.dt_orcamento, a.dt_previni, a.dt_prevfin, a.ds_motivo, a.st_registro, a.Total_Ficha, a.Total_Despesas ");
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
            sql.AppendLine("inner join TB_FIN_Cidade e ");
            sql.AppendLine("on a.cd_cidadeemp = e.CD_Cidade ");
            sql.AppendLine("inner join TB_FIN_UF f ");
            sql.AppendLine("on e.CD_UF = f.cd_uf ");
            sql.AppendLine("left outer join TB_FIN_Clifor g ");
            sql.AppendLine("on a.CD_Vendedor = g.CD_Clifor ");

            string cond = " and ";
            sql.AppendLine("where a.st_registro <> 'C' ");
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Orcamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento lista = new TList_Orcamento();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento reg = new TRegistro_Orcamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_previni")))
                        reg.Dt_previni = reader.GetDateTime(reader.GetOrdinal("dt_previni"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevfin")))
                        reg.Dt_prevfin = reader.GetDateTime(reader.GetOrdinal("dt_prevfin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Total_Ficha")))
                        reg.Total_Ficha = reader.GetDecimal(reader.GetOrdinal("Total_Ficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Total_Despesas")))
                        reg.Total_Despesas = reader.GetDecimal(reader.GetOrdinal("Total_Despesas"));

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

        public string Gravar(TRegistro_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(18);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_EMPREENDIMENTO", val.Ds_empreendimento);
            hs.Add("@P_DS_ENDERECOEMP", val.Ds_enderecoemp);
            hs.Add("@P_NUMEROEMP", val.Numeroemp);
            hs.Add("@P_BAIRROEMP", val.Bairroemp);
            hs.Add("@P_FONEEMP", val.Foneemp);
            hs.Add("@P_CD_CIDADEEMP", val.Cd_cidadeemp);
            hs.Add("@P_DT_ORCAMENTO", val.Dt_orcamento);
            hs.Add("@P_DT_PREVINI", val.Dt_previni);
            hs.Add("@P_DT_PREVFIN", val.Dt_prevfin);
            hs.Add("@P_DS_MOTIVO", val.Ds_motivo);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_EMP_ORCAMENTO", hs);
        }

        public string Excluir(TRegistro_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);

            return this.executarProc("EXCLUI_EMP_ORCAMENTO", hs);
        }
    }
    #endregion

    #region Projetos Orcamento
    public class TList_OrcProjeto : List<TRegistro_OrcProjeto> { }

    public class TRegistro_OrcProjeto
    {
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
        public bool st_importar { get; set; }

        public TList_FichaTec lFicha
        { get; set; }
        public TList_FichaTec lFichaDel
        { get; set; }

        public TRegistro_OrcProjeto()
        {
            this.st_importar = false;
            this.Cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_projeto = null;
            this.id_projetostr = string.Empty;
            this.Ds_projeto = string.Empty;
            this.Obs = string.Empty;
            this.lFicha = new TList_FichaTec();
            this.lFichaDel = new TList_FichaTec();
        }
    }

    public class TCD_OrcProjeto : TDataQuery
    {
        public TCD_OrcProjeto() { }

        public TCD_OrcProjeto(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_projeto, a.ds_projeto, a.obs ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_emp_orcprojeto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_OrcProjeto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OrcProjeto lista = new TList_OrcProjeto();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrcProjeto reg = new TRegistro_OrcProjeto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_projeto")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_projeto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_projeto")))
                        reg.Ds_projeto = reader.GetString(reader.GetOrdinal("ds_projeto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("obs"));

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

        public string Gravar(TRegistro_OrcProjeto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_PROJETO", val.Id_projeto);
            hs.Add("@P_DS_PROJETO", val.Ds_projeto);
            hs.Add("@P_OBS", val.Obs);

            return this.executarProc("IA_EMP_ORCPROJETO", hs);
        }

        public string Excluir(TRegistro_OrcProjeto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_PROJETO", val.Id_projeto);

            return this.executarProc("EXCLUI_EMP_ORCPROJETO", hs);
        }
    }
    #endregion

    #region Ficha Tec
    public class TList_FichaTec : List<TRegistro_FichaTec> { }

    public class TRegistro_FichaTec
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        { 
            get{return id_orcamento;}
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
        public string Sg_unidade
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }

        public TRegistro_FichaTec()
        {
            this.Cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_projeto = null;
            this.id_projetostr = string.Empty;
            this.id_ficha = null;
            this.id_fichastr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sg_unidade = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
        }
    }

    public class TCD_FichaTec : TDataQuery
    {
        public TCD_FichaTec() { }

        public TCD_FichaTec(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_projeto, a.id_ficha, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, c.sigla_unidade, ");
                sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_subtotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_emp_fichatec a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_FichaTec Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FichaTec lista = new TList_FichaTec();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("id_projeto")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_projeto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_FichaTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_PROJETO", val.Id_projeto);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);

            return this.executarProc("IA_EMP_FICHATEC", hs);
        }

        public string Excluir(TRegistro_FichaTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_PROJETO", val.Id_projeto);
            hs.Add("@P_ID_FICHA", val.Id_ficha);

            return this.executarProc("EXCLUI_EMP_FICHATEC", hs);
        }
    }
    #endregion

    #region Despesas
    public class TList_Despesas : List<TRegistro_Despesas> { }

    public class TRegistro_Despesas
    {
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
        private decimal? id_despesapai;
        public decimal? Id_despesapai
        {
            get { return id_despesapai; }
            set
            {
                id_despesapai = value;
                id_despesapaistr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesapaistr;
        public string Id_despesapaistr
        {
            get { return id_despesapaistr; }
            set
            {
                id_despesapaistr = value;
                try
                {
                    id_despesapai = decimal.Parse(value);
                }
                catch { id_despesapai = null; }
            }
        }
        public string Ds_despesapai
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        private string tp_despesa;
        public string Tp_despesa
        {
            get { return tp_despesa; }
            set
            {
                tp_despesa = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_despesa = "FUNCIONARIOS";
                else if (value.Trim().ToUpper().Equals("O"))
                    tipo_despesa = "OUTRAS";
            }
        }
        private string tipo_despesa;
        public string Tipo_despesa
        {
            get { return tipo_despesa; }
            set
            {
                tipo_despesa = value;
                if (value.Trim().ToUpper().Equals("FUNCIONARIOS"))
                    tp_despesa = "F";
                else if (value.Trim().ToUpper().Equals("OUTRAS"))
                    tp_despesa = "O";
            }
        }
        private string tp_classif;
        public string Tp_classif
        {
            get { return tp_classif; }
            set
            {
                tp_classif = value;
                if (value.Trim().ToUpper().Equals("S"))
                    tipo_classif = "SINTETICO";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_classif = "ANALITICO";
            }
        }
        private string tipo_classif;
        public string Tipo_classif
        {
            get { return tipo_classif; }
            set
            {
                tipo_classif = value;
                if (value.Trim().ToUpper().Equals("SINTETICO"))
                    tp_classif = "S";
                else if (value.Trim().ToUpper().Equals("ANALITICO"))
                    tp_classif = "A";
            }
        }
        public string Classificacao
        { get; set; }
        public decimal Nivel
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }

        public TList_Funcionarios lFunc
        { get; set; }
        public TList_Funcionarios lFuncDel
        { get; set; }

        public TRegistro_Despesas()
        {
            this.Cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_despesa = null;
            this.id_despesastr = string.Empty;
            this.Ds_despesa = string.Empty;
            this.id_despesapai = null;
            this.id_despesapaistr = string.Empty;
            this.Ds_despesapai = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.tp_despesa = string.Empty;
            this.tipo_despesa = string.Empty;
            this.tp_classif = string.Empty;
            this.tipo_classif = string.Empty;
            this.Classificacao = string.Empty;
            this.Nivel = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;

            this.lFunc = new TList_Funcionarios();
            this.lFuncDel = new TList_Funcionarios();
        }
    }

    public class TCD_Despesas : TDataQuery
    {
        public TCD_Despesas() { }

        public TCD_Despesas(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_despesa, a.ds_despesa, ");
                sql.AppendLine("a.id_despesapai, b.ds_despesa as ds_despesapai, ");
                sql.AppendLine("a.cd_unidade,-- c.DS_Unidade, c.Sigla_Unidade, ");
                sql.AppendLine("a.TP_Despesa, a.TP_Classif, a.Classificacao, ");
                sql.AppendLine("a.Nivel, a.Quantidade, a.Vl_Unitario, a.Vl_SubTotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_Despesas a ");
            sql.AppendLine("left outer join TB_EMP_CADDespesa b ");
            sql.AppendLine("on a.id_despesapai = b.id_despesa ");
           // sql.AppendLine("inner join tb_est_unidade c ");
           // sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("order by a.id_despesapai ");

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

        public TList_Despesas Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Despesas lista = new TList_Despesas();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesapai")))
                        reg.Id_despesapai = reader.GetDecimal(reader.GetOrdinal("id_despesapai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesapai")))
                        reg.Ds_despesapai = reader.GetString(reader.GetOrdinal("ds_despesapai"));
                   // if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                   //     reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                   // if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                   //     reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                   // if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                   //     reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_despesa")))
                        reg.Tp_despesa = reader.GetString(reader.GetOrdinal("tp_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_classif")))
                        reg.Tp_classif = reader.GetString(reader.GetOrdinal("tp_classif"));
                    if (!reader.IsDBNull(reader.GetOrdinal("classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("nivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Despesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_DESPESAPAI", val.Id_despesapai);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_DS_DESPESA", val.Ds_despesa);
            hs.Add("@P_TP_DESPESA", val.Tp_despesa);
            hs.Add("@P_TP_CLASSIF", val.Tp_classif);
            hs.Add("@P_CLASSIFICACAO", val.Classificacao);
            hs.Add("@P_NIVEL", val.Nivel);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);

            return this.executarProc("IA_EMP_DESPESAS", hs);
        }

        public string Excluir(TRegistro_Despesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);

            return this.executarProc("EXCLUI_EMP_DESPESAS", hs);
        }
    }
    #endregion

    #region Funcionarios
    public class TList_Funcionarios : List<TRegistro_Funcionarios> { }

    public class TRegistro_Funcionarios
    {
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
        public decimal Quantidade
        { get; set; }
        public decimal Tmp_dias
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }

        public TRegistro_Funcionarios()
        {
            this.Cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_despesa = null;
            this.id_despesastr = string.Empty;
            this.id_cargo = null;
            this.id_cargostr = string.Empty;
            this.Ds_cargo = string.Empty;
            this.Quantidade = 1;
            this.Tmp_dias = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
        }
    }

    public class TCD_Funcionarios : TDataQuery
    {
        public TCD_Funcionarios() { }

        public TCD_Funcionarios(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao,a.id_despesa, a.id_cargo, b.ds_cargo, ");
                sql.AppendLine("a.quantidade, a.tmp_dias, a.vl_unitario, a.vl_subtotal ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_emp_funcionarios a ");
            sql.AppendLine("inner join tb_div_cargofuncionario b ");
            sql.AppendLine("on a.id_cargo = b.id_cargo ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Funcionarios Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Funcionarios lista = new TList_Funcionarios();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Funcionarios reg = new TRegistro_Funcionarios();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcametno")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cargo")))
                        reg.Id_cargo = reader.GetDecimal(reader.GetOrdinal("id_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cargo")))
                        reg.Ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_dias")))
                        reg.Tmp_dias = reader.GetDecimal(reader.GetOrdinal("tmp_dias"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Funcionarios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_CARGO", val.Id_cargo);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_TMP_DIAS", val.Tmp_dias);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);

            return this.executarProc("IA_EMP_FUNCIONARIOS", hs);
        }
        public string Excluir(TRegistro_Funcionarios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_CARGO", val.Id_cargo);

            return this.executarProc("EXCLUI_EMP_FUNCIONARIOS", hs);
        }
    }
    #endregion
}
