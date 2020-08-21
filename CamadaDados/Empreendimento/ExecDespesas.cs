using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Empreendimento
{
    public class 
        TRegistro_ExecDespesas
    {
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
        public string id_contato { get; set; } = string.Empty;
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
        public string Cd_empresa
        { get; set; }
        public decimal id_despesa { get; set; }
        public decimal id_execucao { get; set; }
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
        public decimal nr_lancto
        { get; set; }
        public decimal vl_executado
        { get; set; }
        private DateTime? dt_execucao;
        public DateTime? Dt_execucao
        {
            get { return dt_execucao; }
            set
            {
                dt_execucao = value;
                dt_execucaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_execucaostr;
        public string Dt_execucaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_execucaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_execucaostr = value;
                try
                {
                    dt_execucao = DateTime.Parse(value);
                }
                catch { dt_execucao = null; }
            }
        }
        public string Cd_fornecedor { get; set; } = string.Empty;
        public string Nm_fornecedor { get; set; } = string.Empty;
        public string Cd_funcionario { get; set; } = string.Empty;
        public string Nm_funcionario { get; set; } = string.Empty;
        public string obs { get; set; }
        public Financeiro.Duplicata.TRegistro_LanDuplicata rDuplicata { get; set; }
        public Financeiro.CCustoLan.TList_LanCCustoLancto lCCusto { get; set; }
        public string Nr_docto { get; set; }
        private string tp_pagamento;
        public string ds_despesa { get; set; } = string.Empty;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_pagamento = "FUNCIONARIO";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_pagamento = "EMPRESA";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("FUNCIONARIO"))
                    tp_pagamento = "F";
                else if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_pagamento = "E";
            }
        }
        public TRegistro_ExecDespesas()
        {
            id_orcamentostr = string.Empty;
            nr_versaostr = string.Empty;
            nr_lancto = decimal.Zero;
            ds_despesa = string.Empty;
            vl_executado = decimal.Zero;
            dt_execucao = null;
            obs = string.Empty;
            Nr_docto = string.Empty;
            rDuplicata = new Financeiro.Duplicata.TRegistro_LanDuplicata();
            lCCusto = new Financeiro.CCustoLan.TList_LanCCustoLancto();

        }
    }

    public class TList_ExecDespesas : List<TRegistro_ExecDespesas>, IComparer<TRegistro_ExecDespesas>
    {
        #region IComparer<TRegistro_ExecDespesas> Members
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

        public TList_ExecDespesas()
        { }

        public TList_ExecDespesas(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ExecDespesas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ExecDespesas x, TRegistro_ExecDespesas y)
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

    public class TCD_ExecDespesas : TDataQuery
    {
        public TCD_ExecDespesas() { }

        public TCD_ExecDespesas(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " e.nr_docto, d.ds_despesa, a.id_regdesp, ");
                sql.AppendLine("a.id_execucao, b.id_orcamento, b.nr_versao, b.cd_empresa, ");
                sql.AppendLine("b.nr_versao, a.vl_executado, a.dt_execucao, a.nr_lancto, ");
                sql.AppendLine("a.cd_fornecedor, f.nm_clifor as nm_fornecedor, ");
                sql.AppendLine("a.cd_funcionario, g.nm_clifor as nm_funcionario, a.tp_pagamento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_ExecDespesas a");
            sql.AppendLine("join vtb_emp_orcamento b ");
            sql.AppendLine("on a.id_orcamento = b.id_orcamento ");
            sql.AppendLine("and a.nr_versao = b.nr_versao");
            sql.AppendLine("join tb_emp_despesas c");
            sql.AppendLine("on c.id_orcamento = a.id_orcamento ");
            sql.AppendLine("and a.nr_versao = c.nr_versao ");
            sql.AppendLine("and a.id_regdesp = c.id_regdesp ");
            sql.AppendLine("and a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("join TB_EMP_CadDespesa d");
            sql.AppendLine("on d.id_despesa = c.id_despesa ");
            sql.AppendLine("left join TB_fin_duplicata e ");
            sql.AppendLine("on e.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = e.nr_lancto ");
            sql.AppendLine("left outer join tb_fin_clifor f ");
            sql.AppendLine("on a.cd_fornecedor = f.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor g ");
            sql.AppendLine("on a.cd_funcionario = g.cd_clifor ");

            string cond = " and ";
            sql.AppendLine("where b.st_registro <> 'C' ");
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

        public TList_ExecDespesas Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ExecDespesas lista = new TList_ExecDespesas();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ExecDespesas reg = new TRegistro_ExecDespesas();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_regdesp")))
                        reg.Id_RegDesp = reader.GetDecimal(reader.GetOrdinal("id_regdesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("Nr_Versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_execucao")))
                        reg.id_execucao = reader.GetDecimal(reader.GetOrdinal("id_execucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_executado")))
                        reg.vl_executado = reader.GetDecimal(reader.GetOrdinal("vl_executado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_execucao")))
                        reg.Dt_execucao = reader.GetDateTime(reader.GetOrdinal("dt_execucao")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("CD_Funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Funcionario")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("NM_Funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("TP_Pagamento"));

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

        public string Gravar(TRegistro_ExecDespesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_REGDESP", val.Id_RegDesp);
            hs.Add("@P_ID_EXECUCAO", val.id_execucao);
            hs.Add("@P_NR_LANCTO", val.nr_lancto);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);
            hs.Add("@P_VL_EXECUTADO", val.vl_executado);
            hs.Add("@P_DT_EXECUCAO", val.Dt_execucao);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_OBS", val.obs);

            return executarProc("IA_EMP_EXECDESPESAS", hs);
        }

        public string Excluir(TRegistro_ExecDespesas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);

            return executarProc("EXCLUI_EMP_ORCAMENTO", hs);
        }
    }



    #region Despesa X Duplicata
    public class TList_DespViagem_X_CCusto : List<TRegistro_DespViagem_X_CCusto>
    { }


    public class TRegistro_DespViagem_X_CCusto
    {
        public string cd_empresa = string.Empty;
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
        public decimal nr_lancto
        { get; set; }

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

        private decimal? id_execucao;
        public decimal? Id_execucao
        {
            get { return id_execucao; }
            set
            {
                id_execucao = value;
                id_execucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_execucaostr;
        public string Id_execucaostr
        {
            get { return id_execucaostr; }
            set
            {
                id_execucaostr = value;
                try
                {
                    id_execucao = decimal.Parse(value);
                }
                catch { id_execucao = null; }
            }
        }
        private decimal? id_CCustoLan;
        public decimal? Id_CCustoLan
        {
            get { return id_CCustoLan; }
            set
            {
                id_CCustoLan = value;
                id_CCustoLanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_CCustoLanstr;
        public string Id_CCustoLanstr
        {
            get { return id_CCustoLanstr; }
            set
            {
                id_CCustoLanstr = value;
                try
                {
                    id_CCustoLan = decimal.Parse(value);
                }
                catch { id_CCustoLan = null; }
            }
        }
    

        public TRegistro_DespViagem_X_CCusto()
        {
            cd_empresa = null;
            id_CCustoLan = decimal.Zero;
            id_despesa = null;
            id_execucao = decimal.Zero;
            nr_versaostr = string.Empty;
            id_orcamento = null;
        }
    }

    public class TCD_DespViagem_X_CCusto : TDataQuery
    {
        public TCD_DespViagem_X_CCusto()
        { }

        public TCD_DespViagem_X_CCusto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_CCustoLan, ");
                sql.AppendLine("a.id_despesa, a.id_execucao, a.nr_versao , a.id_orcamento ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_EmpDespesas_X_CCusto a ");

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

        public TList_DespViagem_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DespViagem_X_CCusto lista = new TList_DespViagem_X_CCusto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DespViagem_X_CCusto reg = new TRegistro_DespViagem_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_CCustoLan")))
                        reg.Id_CCustoLan = reader.GetDecimal(reader.GetOrdinal("Id_CCustoLan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("Id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("Nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_execucao")))
                        reg.Id_execucao = reader.GetDecimal(reader.GetOrdinal("id_execucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));

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

        public string Gravar(TRegistro_DespViagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_EXECUCAO", val.Id_execucao);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_CCustoLan);

            return executarProc("IA_FIN_EMPDESPESAS_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_DespViagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_EXECUCAO", val.Id_execucao);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_CCustoLan);

            return executarProc("EXCLUI_FIN_EMPDESPESAS_X_CCUSTO", hs);
        }
    }
    #endregion


}
