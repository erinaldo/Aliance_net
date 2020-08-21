using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Emprestimos
{
    #region Emprestimos
    public class TList_Emprestimos : List<TRegistro_Emprestimos>, IComparer<TRegistro_Emprestimos>
    {
        #region IComparer<TRegistro_Emprestimos> Members
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

        public TList_Emprestimos()
        { }

        public TList_Emprestimos(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Emprestimos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Emprestimos x, TRegistro_Emprestimos y)
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

    
    public class TRegistro_Emprestimos
    {
        private decimal? id_emprestimo;
        
        public decimal? Id_emprestimo
        {
            get { return id_emprestimo; }
            set
            {
                id_emprestimo = value;
                id_emprestimostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_emprestimostr;
        
        public string Id_emprestimostr
        {
            get { return id_emprestimostr; }
            set
            {
                id_emprestimostr = value;
                try
                {
                    id_emprestimo = decimal.Parse(value);
                }
                catch
                { id_emprestimo = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Cd_juro
        { get; set; }
        
        public string Ds_juro
        { get; set; }
        
        public decimal Pc_juro
        { get; set; }
        private DateTime? dt_emprestimo;
        
        public DateTime? Dt_emprestimo
        {
            get { return dt_emprestimo; }
            set
            {
                dt_emprestimo = value;
                dt_emprestimostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emprestimostr;
        public string Dt_emprestimostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_emprestimostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emprestimostr = value;
                try
                {
                    dt_emprestimo = DateTime.Parse(value);
                }
                catch
                { dt_emprestimo = null; }
            }
        }
        
        public string Tp_emprestimo
        { get; set; }
        public string Tipo_emprestimo
        {
            get
            {
                if (Tp_emprestimo.Trim().ToUpper().Equals("C"))
                    return "CONCEDIDO";
                else if (Tp_emprestimo.Trim().ToUpper().Equals("R"))
                    return "RECEBIDO";
                else return string.Empty;
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else if (Vl_quitado >= Vl_emprestimo)
                    return "DEVOLVIDO";
                else if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else return string.Empty;
            }
        }
        
        public decimal Vl_emprestimo
        { get; set; }
        
        public decimal Vl_atual
        { get; set; }
        
        public decimal Vl_quitado
        { get; set; }
        
        public decimal Vl_devolver
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }
        
        public string Cd_contager_dev
        { get; set; }
        
        public string Ds_contager_dev
        { get; set; }
        
        public DateTime Dt_devolucao
        { get; set; }
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        
        public string Cd_portador_dev
        { get; set; }
        
        public string Ds_portador_dev
        { get; set; }
        
        public CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa
        { get; set; }
        
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheque
        { get; set; }
        
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCentroResult
        { get; set; }

        public TRegistro_Emprestimos()
        {
            this.id_emprestimo = null;
            this.id_emprestimostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_juro = string.Empty;
            this.Ds_juro = string.Empty;
            this.Pc_juro = decimal.Zero;
            this.dt_emprestimo = null;
            this.dt_emprestimostr = string.Empty;
            this.Tp_emprestimo = string.Empty;
            this.Ds_observacao = string.Empty;
            this.Vl_emprestimo = decimal.Zero;
            this.Vl_atual = decimal.Zero;
            this.Vl_quitado = decimal.Zero;
            this.Vl_devolver = decimal.Zero;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Cd_contager_dev = string.Empty;
            this.Ds_contager_dev = string.Empty;
            this.Dt_devolucao = DateTime.Now;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.Cd_portador_dev = string.Empty;
            this.Ds_portador_dev = string.Empty;
            this.lCaixa = new CamadaDados.Financeiro.Caixa.TList_LanCaixa();
            this.lCheque = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
            this.lCentroResult = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_Emprestimos : TDataQuery
    {
        public TCD_Emprestimos()
        { }

        public TCD_Emprestimos(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Emprestimo, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Clifor, c.NM_Clifor, ");
                sql.AppendLine("a.CD_Endereco, d.DS_Endereco, a.CD_Juro, ");
                sql.AppendLine("e.DS_Juro, e.PC_JuroDiario_Atrazo, ");
                sql.AppendLine("a.DT_Emprestimo, a.TP_Emprestimo, ");
                sql.AppendLine("a.DS_Observacao, a.ST_Registro, ");
                sql.AppendLine("a.cd_contager, f.ds_contager, ");
                sql.AppendLine("a.Vl_emprestimo, a.vl_atual, a.Vl_quitado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_EMPRESTIMOS a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = d.CD_Endereco ");
            sql.AppendLine("left outer join TB_FIN_Juro e ");
            sql.AppendLine("on a.CD_Juro = e.CD_Juro ");
            sql.AppendLine("left outer join TB_FIN_ContaGer f ");
            sql.AppendLine("on a.cd_contager = f.cd_contager ");

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

        public TList_Emprestimos Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Emprestimos lista = new TList_Emprestimos();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Emprestimos reg = new TRegistro_Emprestimos();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_emprestimo")))
                        reg.Id_emprestimo = reader.GetDecimal(reader.GetOrdinal("Id_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_juro")))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("cd_juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_juro")))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("ds_juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo")))
                        reg.Pc_juro = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emprestimo")))
                        reg.Dt_emprestimo = reader.GetDateTime(reader.GetOrdinal("dt_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_emprestimo")))
                        reg.Tp_emprestimo = reader.GetString(reader.GetOrdinal("tp_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_emprestimo")))
                        reg.Vl_emprestimo = reader.GetDecimal(reader.GetOrdinal("vl_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_atual")))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("vl_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_quitado")))
                        reg.Vl_quitado = reader.GetDecimal(reader.GetOrdinal("vl_quitado"));

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

        public string Gravar(TRegistro_Emprestimos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_DT_EMPRESTIMO", val.Dt_emprestimo);
            hs.Add("@P_TP_EMPRESTIMO", val.Tp_emprestimo);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_EMPRESTIMOS", hs);
        }

        public string Excluir(TRegistro_Emprestimos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_EMPRESTIMOS", hs);
        }
    }
    #endregion

    #region Emprestimo X Caixa
    public class TList_Emprestimo_X_Caixa:List<TRegistro_Emprestimo_X_Caixa>, IComparer<TRegistro_Emprestimo_X_Caixa>
    {
        #region IComparer<TRegistro_Emprestimo_X_Caixa> Members
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

        public TList_Emprestimo_X_Caixa()
        { }

        public TList_Emprestimo_X_Caixa(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Emprestimo_X_Caixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Emprestimo_X_Caixa x, TRegistro_Emprestimo_X_Caixa y)
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

    
    public class TRegistro_Emprestimo_X_Caixa
    {
        private decimal? id_emprestimo;
        
        public decimal? Id_emprestimo
        {
            get { return id_emprestimo; }
            set
            {
                id_emprestimo = value;
                id_emprestimostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_emprestimostr;
        
        public string Id_emprestimostr
        {
            get { return id_emprestimostr; }
            set
            {
                id_emprestimostr = value;
                try
                {
                    id_emprestimo = decimal.Parse(value);
                }
                catch
                { id_emprestimo = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
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
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        
        public string Tp_lancto
        { get; set; }
        public string Tipo_lancto
        {
            get
            {
                if (Tp_lancto.Trim().ToUpper().Equals("O"))
                    return "ORIGEM";
                else if (Tp_lancto.Trim().ToUpper().Equals("Q"))
                    return "QUITACAO";
                else return string.Empty;
            }
        }

        public TRegistro_Emprestimo_X_Caixa()
        {
            this.id_emprestimo = null;
            this.id_emprestimostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_contager = string.Empty;
            this.cd_lanctocaixa = null;
            this.cd_lanctocaixastr = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.Tp_lancto = string.Empty;
        }
    }

    public class TCD_Emprestimo_X_Caixa : TDataQuery
    {
        public TCD_Emprestimo_X_Caixa()
        { }

        public TCD_Emprestimo_X_Caixa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Emprestimo, a.CD_Empresa, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa, a.tp_lancto, ");
                sql.AppendLine("a.cd_portador, b.ds_portador ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_emprestimo_x_caixa a ");
            sql.AppendLine("inner join tb_fin_portador b ");
            sql.AppendLine("on a.cd_portador = b.cd_portador ");

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

        public TList_Emprestimo_X_Caixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Emprestimo_X_Caixa lista = new TList_Emprestimo_X_Caixa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Emprestimo_X_Caixa reg = new TRegistro_Emprestimo_X_Caixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_emprestimo")))
                        reg.Id_emprestimo = reader.GetDecimal(reader.GetOrdinal("Id_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_lancto")))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("tp_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));

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

        public string Gravar(TRegistro_Emprestimo_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_TP_LANCTO", val.Tp_lancto);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return this.executarProc("IA_FIN_EMPRESTIMO_X_CAIXA", hs);
        }

        public string Excluir(TRegistro_Emprestimo_X_Caixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("EXCLUI_FIN_EMPRESTIMO_X_CAIXA", hs);
        }
    }
    #endregion

    #region Emprestimos X Centro Resultado
    public class TList_Emprestimos_X_CCusto : List<TRegistro_Emprestimos_X_CCusto>
    { }

    
    public class TRegistro_Emprestimos_X_CCusto
    {
        
        public decimal? Id_emprestimo
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Id_ccustolan
        { get; set; }

        public TRegistro_Emprestimos_X_CCusto()
        {
            this.Id_emprestimo = null;
            this.Cd_empresa = string.Empty;
            this.Id_ccustolan = null;
        }
    }

    public class TCD_Emprestimos_X_CCusto : TDataQuery
    {
        public TCD_Emprestimos_X_CCusto()
        { }

        public TCD_Emprestimos_X_CCusto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_emprestimo, a.CD_Empresa, a.id_ccustolan ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_emprestimos_x_ccusto a ");

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

        public TList_Emprestimos_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Emprestimos_X_CCusto lista = new TList_Emprestimos_X_CCusto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Emprestimos_X_CCusto reg = new TRegistro_Emprestimos_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_emprestimo")))
                        reg.Id_emprestimo = reader.GetDecimal(reader.GetOrdinal("Id_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
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
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Emprestimos_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("IA_FIN_EMPRESTIMOS_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_Emprestimos_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("EXCLUI_FIN_EMPRESTIMOS_X_CCUSTO", hs);
        }
    }
    #endregion
}
