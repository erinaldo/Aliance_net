using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Folha_Pagamento
{
    #region Pagamento Folha
    public class TList_PagamentoFolha : List<TRegistro_PagamentoFolha>, IComparer<TRegistro_PagamentoFolha>
    {
        #region IComparer<TRegistro_PagamentoFolha> Members
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

        public TList_PagamentoFolha()
        { }

        public TList_PagamentoFolha(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PagamentoFolha value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PagamentoFolha x, TRegistro_PagamentoFolha y)
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
    
    public class TRegistro_PagamentoFolha
    {
        public string Cd_funcionario
        { get; set; }
        public string Nm_funcionario
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal Vl_salario
        { get; set; }
        public decimal Vl_saldoadto
        { get; set; }
        public decimal Vl_adtodevolver
        { get; set; }
        public bool St_gerarpagamento
        { get; set; }

        public TRegistro_PagamentoFolha()
        {
            this.Cd_funcionario = string.Empty;
            this.Nm_funcionario = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Vl_salario = decimal.Zero;
            this.Vl_saldoadto = decimal.Zero;
            this.Vl_adtodevolver = decimal.Zero;
            this.St_gerarpagamento = false;
        }
    }
    #endregion

    #region Folha Pagamento
    public class TList_FolhaPagamento : List<TRegistro_FolhaPagamento>, IComparer<TRegistro_FolhaPagamento>
    {
        #region IComparer<TRegistro_FolhaPagamento> Members
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

        public TList_FolhaPagamento()
        { }

        public TList_FolhaPagamento(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FolhaPagamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FolhaPagamento x, TRegistro_FolhaPagamento y)
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

    public class TRegistro_FolhaPagamento
    {
        public decimal? Id_folha
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? mes_folha;
        public decimal? Mes_folha
        {
            get { return mes_folha; }
            set
            {
                mes_folha = value;
                mes_folhastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string mes_folhastr;
        public string Mes_folhastr
        {
            get { return mes_folhastr; }
            set
            {
                mes_folhastr = value;
                try
                {
                    mes_folha = Convert.ToDecimal(value);
                }
                catch
                { mes_folha = null; }
            }
        }
        private decimal? ano_folha;
        public decimal? Ano_folha
        {
            get { return ano_folha; }
            set
            {
                ano_folha = value;
                ano_folhastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string ano_folhastr;
        public string Ano_folhastr
        {
            get { return ano_folhastr; }
            set
            {
                ano_folhastr = value;
                try
                {
                    ano_folha = Convert.ToDecimal(value);
                }
                catch
                { ano_folha = null; }
            }
        }
        public string Ds_observacao
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
                    status = "PROCESSADO";
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
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        public TList_Folha_X_Funcionarios lFolhaFunc
        { get; set; }
        public TList_Folha_X_Funcionarios lFolhaFuncDel
        { get; set; }
        
        public TRegistro_FolhaPagamento()
        {
            this.Id_folha = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.mes_folha = DateTime.Now.Month;
            this.mes_folhastr = DateTime.Now.Month.ToString();
            this.ano_folha = DateTime.Now.Year;
            this.ano_folhastr = DateTime.Now.Year.ToString();
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.lFolhaFunc = new TList_Folha_X_Funcionarios();
            this.lFolhaFuncDel = new TList_Folha_X_Funcionarios();
        }
    }

    public class TCD_FolhaPagamento : TDataQuery
    {
        public TCD_FolhaPagamento()
        { }

        public TCD_FolhaPagamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_folha, a.cd_empresa, a.st_registro, ");
                sql.AppendLine("b.NM_Empresa, a.mes_folha, a.ano_folha, a.ds_observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_FolhaPagamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaPagto(Utils.TpBusca[] vBusca, string Cd_empresa, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {
                sql.AppendLine("select " + strTop + "a.CD_Clifor as cd_funcionario, ");
                sql.AppendLine("a.NM_Clifor as nm_funcionario, ");
                sql.AppendLine("a.cd_empresa, b.NM_Empresa, a.vl_salario, ");
                sql.AppendLine("Vl_saldoadto = (select ISNULL(SUM(ISNULL(x.vl_pagar, 0)), 0) - ISNULL(SUM(ISNULL(x.vl_receber, 0)), 0) ");
                sql.AppendLine("				from vtb_fin_adiantamento x ");
                sql.AppendLine("				where ISNULL(x.st_adto, 'A') <> 'C' ");
                sql.AppendLine("				and x.tp_movimento = 'C' ");
                sql.AppendLine("				and x.cd_clifor = a.cd_clifor ");
                sql.AppendLine("				and x.cd_empresa = '" + Cd_empresa.Trim() + "') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_CLIFOR a ");
            sql.AppendLine("left outer join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("where isnull(a.ST_Funcionarios, 'N') = 'S' ");
            sql.AppendLine("and isnull(a.ST_Registro, 'A') <> 'C' ");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_FolhaPagamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FolhaPagamento lista = new TList_FolhaPagamento();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FolhaPagamento reg = new TRegistro_FolhaPagamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_folha")))
                        reg.Id_folha = reader.GetDecimal(reader.GetOrdinal("id_folha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("mes_folha")))
                        reg.Mes_folha = reader.GetDecimal(reader.GetOrdinal("mes_folha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ano_folha")))
                        reg.Ano_folha = reader.GetDecimal(reader.GetOrdinal("ano_folha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    
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

        public TList_PagamentoFolha Select(Utils.TpBusca[] vBusca, string Cd_empresa, Int32 vTop, string vNM_Campo)
        {
            TList_PagamentoFolha lista = new TList_PagamentoFolha();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBuscaPagto(vBusca, Cd_empresa, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PagamentoFolha reg = new TRegistro_PagamentoFolha();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("cd_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_funcionario")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("nm_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_salario")))
                        reg.Vl_salario = reader.GetDecimal(reader.GetOrdinal("vl_salario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_saldoadto")))
                        reg.Vl_saldoadto = reader.GetDecimal(reader.GetOrdinal("vl_saldoadto"));

                    reg.Vl_adtodevolver = (reg.Vl_salario > reg.Vl_saldoadto) ? reg.Vl_saldoadto : reg.Vl_adtodevolver = reg.Vl_salario;

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

        public string Gravar(TRegistro_FolhaPagamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_FOLHA", val.Id_folha);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_MES_FOLHA", val.Mes_folha);
            hs.Add("@P_ANO_FOLHA", val.Ano_folha);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_FOLHAPAGAMENTO", hs);
        }

        public string Excluir(TRegistro_FolhaPagamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_FOLHA", val.Id_folha);

            return this.executarProc("EXCLUI_FIN_FOLHAPAGAMENTO", hs);
        }
    }
    #endregion

    #region Folha X Funcionarios
    public class TList_Folha_X_Funcionarios : List<TRegistro_Folha_X_Funcionarios>, IComparer<TRegistro_Folha_X_Funcionarios>
    {
        #region IComparer<TRegistro_Folha_X_Funcionarios> Members
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

        public TList_Folha_X_Funcionarios()
        { }

        public TList_Folha_X_Funcionarios(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Folha_X_Funcionarios value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Folha_X_Funcionarios x, TRegistro_Folha_X_Funcionarios y)
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
    
    public class TRegistro_Folha_X_Funcionarios
    {
        public decimal? Id_folha
        { get; set; }
        public string Cd_funcionario
        { get; set; }
        public string Nm_funcionario
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public decimal Vl_pagamento
        { get; set; }
        public decimal Vl_adtodevolver
        { get; set; }

        public TRegistro_Folha_X_Funcionarios()
        {
            this.Id_folha = null;
            this.Cd_funcionario = string.Empty;
            this.Nm_funcionario = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = null;
            this.Vl_pagamento = decimal.Zero;
            this.Vl_adtodevolver = decimal.Zero;
        }
    }

    public class TCD_Folha_X_Funcionarios : TDataQuery
    {
        public TCD_Folha_X_Funcionarios()
        { }

        public TCD_Folha_X_Funcionarios(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {
                sql.AppendLine("select " + strTop + " a.id_folha, a.cd_empresa, a.nr_lancto, ");
                sql.AppendLine("a.vl_pagamento, a.cd_funcionario, b.nm_clifor as nm_funcionario, a.vl_adtodevolver ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_folha_x_funcionarios a ");
            sql.AppendLine("inner join VTB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_funcionario = b.cd_clifor ");
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

        public TList_Folha_X_Funcionarios Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Folha_X_Funcionarios lista = new TList_Folha_X_Funcionarios();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Folha_X_Funcionarios reg = new TRegistro_Folha_X_Funcionarios();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_folha")))
                        reg.Id_folha = reader.GetDecimal(reader.GetOrdinal("id_folha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_funcionario")))
                        reg.Cd_funcionario = reader.GetString(reader.GetOrdinal("cd_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_funcionario")))
                        reg.Nm_funcionario = reader.GetString(reader.GetOrdinal("nm_funcionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pagamento")))
                        reg.Vl_pagamento = reader.GetDecimal(reader.GetOrdinal("vl_pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_adtodevolver")))
                        reg.Vl_adtodevolver = reader.GetDecimal(reader.GetOrdinal("vl_adtodevolver"));

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

        public string Gravar(TRegistro_Folha_X_Funcionarios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_FOLHA", val.Id_folha);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_VL_PAGAMENTO", val.Vl_pagamento);
            hs.Add("@P_VL_ADTODEVOLVER", val.Vl_adtodevolver);

            return this.executarProc("IA_FIN_FOLHA_X_FUNCIONARIOS", hs);
        }

        public string Excluir(TRegistro_Folha_X_Funcionarios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_FOLHA", val.Id_folha);
            hs.Add("@P_CD_FUNCIONARIO", val.Cd_funcionario);

            return this.executarProc("EXCLUI_FIN_FOLHA_X_FUNCIONARIOS", hs);
        }
    }
    #endregion
}
