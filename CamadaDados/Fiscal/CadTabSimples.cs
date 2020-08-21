using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    #region Tabela Simples
    public class TList_TabSimples : List<TRegistro_TabSimples>, IComparer<TRegistro_TabSimples>
    {
        #region IComparer<TRegistro_TabSimples> Members
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

        public TList_TabSimples()
        { }

        public TList_TabSimples(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TabSimples value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TabSimples x, TRegistro_TabSimples y)
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
    
    public class TRegistro_TabSimples
    {
        private decimal? id_tabela;
        public decimal? Id_tabela
        {
            get { return id_tabela; }
            set
            {
                id_tabela = value;
                id_tabelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tabelastr;
        public string Id_tabelastr
        {
            get { return id_tabelastr; }
            set
            {
                id_tabelastr = value;
                try
                {
                    id_tabela = decimal.Parse(value);
                }
                catch { id_tabela = null; }
            }
        }
        public string Ds_tabela
        { get; set; }
        public string Obs
        { get; set; }
        public TList_AliquotaSimples lAliq
        { get; set; }
        public TList_AliquotaSimples lAliqDel
        { get; set; }

        public TRegistro_TabSimples()
        {
            this.id_tabela = null;
            this.id_tabelastr = string.Empty;
            this.Ds_tabela = string.Empty;
            this.Obs = string.Empty;
            this.lAliq = new TList_AliquotaSimples();
            this.lAliqDel = new TList_AliquotaSimples();
        }
    }

    public class TCD_TabSimples : TDataQuery
    {
        public TCD_TabSimples() { }

        public TCD_TabSimples(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tabela, a.ds_tabela, a.obs ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_TabSimples a ");
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

        public TList_TabSimples Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TabSimples lista = new TList_TabSimples();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TabSimples reg = new TRegistro_TabSimples();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("ID_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Tabela")))
                        reg.Ds_tabela = reader.GetString(reader.GetOrdinal("DS_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("obs"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_TabSimples val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_DS_TABELA", val.Ds_tabela);
            hs.Add("@P_OBS", val.Obs);

            return this.executarProc("IA_FIS_TABSIMPLES", hs);
        }

        public string Excluir(TRegistro_TabSimples val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TABELA", val.Id_tabela);

            return this.executarProc("EXCLUI_FIS_TABSIMPLES", hs);
        }
    }
    #endregion

    #region Aliquota Simples
    public class TList_AliquotaSimples : List<TRegistro_AliquotaSimples> { }

    public class TRegistro_AliquotaSimples
    {
        private decimal? id_tabela;
        public decimal? Id_tabela
        {
            get { return id_tabela; }
            set
            {
                id_tabela = value;
                id_tabelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tabelastr;
        public string Id_tabelastr
        {
            get { return id_tabelastr; }
            set
            {
                id_tabelastr = value;
                try
                {
                    id_tabela = decimal.Parse(value);
                }
                catch { id_tabela = null; }
            }
        }
        private decimal? id_aliquota;
        public decimal? Id_aliquota
        {
            get { return id_aliquota; }
            set
            {
                id_aliquota = value;
                id_aliquotastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_aliquotastr;
        public string Id_aliquotastr
        {
            get { return id_aliquotastr; }
            set
            {
                id_aliquotastr = value;
                try
                {
                    id_aliquota = decimal.Parse(value);
                }
                catch { id_aliquota = null; }
            }
        }
        public string Ds_aliquota
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Pc_irpj
        { get; set; }
        public decimal Pc_csll
        { get; set; }
        public decimal Pc_cofins
        { get; set; }
        public decimal Pc_pis
        { get; set; }
        public decimal Pc_cpp
        { get; set; }
        public decimal Pc_icms
        { get; set; }
        public decimal Pc_ipi
        { get; set; }
        public decimal Pc_iss
        { get; set; }

        public TRegistro_AliquotaSimples()
        {
            this.id_tabela = null;
            this.id_tabelastr = string.Empty;
            this.id_aliquota = null;
            this.id_aliquotastr = string.Empty;
            this.Ds_aliquota = string.Empty;
            this.Pc_aliquota = decimal.Zero;
            this.Pc_irpj = decimal.Zero;
            this.Pc_csll = decimal.Zero;
            this.Pc_cofins = decimal.Zero;
            this.Pc_pis = decimal.Zero;
            this.Pc_cpp = decimal.Zero;
            this.Pc_icms = decimal.Zero;
            this.Pc_ipi = decimal.Zero;
            this.Pc_iss = decimal.Zero;
        }
    }

    public class TCD_AliquotaSimples : TDataQuery
    {
        public TCD_AliquotaSimples() { }

        public TCD_AliquotaSimples(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_tabela, a.id_aliquota, a.ds_aliquota, ");
                sql.AppendLine("a.pc_aliquota, a.pc_irpj, a.pc_csll, a.pc_cofins, a.pc_pis, ");
                sql.AppendLine("a.pc_cpp, a.pc_icms, a.pc_ipi, a.pc_iss ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_AliquotaSimples a ");
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

        public TList_AliquotaSimples Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AliquotaSimples lista = new TList_AliquotaSimples();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AliquotaSimples reg = new TRegistro_AliquotaSimples();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("ID_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Aliquota")))
                        reg.Id_aliquota = reader.GetDecimal(reader.GetOrdinal("ID_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Aliquota")))
                        reg.Ds_aliquota = reader.GetString(reader.GetOrdinal("DS_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IRPJ")))
                        reg.Pc_irpj = reader.GetDecimal(reader.GetOrdinal("PC_IRPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_CSLL")))
                        reg.Pc_csll = reader.GetDecimal(reader.GetOrdinal("PC_CSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Cofins")))
                        reg.Pc_cofins = reader.GetDecimal(reader.GetOrdinal("PC_Cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_PIS")))
                        reg.Pc_pis = reader.GetDecimal(reader.GetOrdinal("PC_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_CPP")))
                        reg.Pc_cpp = reader.GetDecimal(reader.GetOrdinal("PC_CPP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ICMS")))
                        reg.Pc_icms = reader.GetDecimal(reader.GetOrdinal("PC_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IPI")))
                        reg.Pc_ipi = reader.GetDecimal(reader.GetOrdinal("PC_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ISS")))
                        reg.Pc_iss = reader.GetDecimal(reader.GetOrdinal("PC_ISS"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_AliquotaSimples val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_ID_ALIQUOTA", val.Id_aliquota);
            hs.Add("@P_DS_ALIQUOTA", val.Ds_aliquota);
            hs.Add("@P_PC_ALIQUOTA", val.Pc_aliquota);
            hs.Add("@P_PC_IRPJ", val.Pc_irpj);
            hs.Add("@P_PC_CSLL", val.Pc_csll);
            hs.Add("@P_PC_COFINS", val.Pc_cofins);
            hs.Add("@P_PC_PIS", val.Pc_pis);
            hs.Add("@P_PC_CPP", val.Pc_cpp);
            hs.Add("@P_PC_ICMS", val.Pc_icms);
            hs.Add("@P_PC_IPI", val.Pc_ipi);
            hs.Add("@P_PC_ISS", val.Pc_iss);

            return this.executarProc("IA_FIS_ALIQUOTASIMPLES", hs);
        }

        public string Excluir(TRegistro_AliquotaSimples val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_ID_ALIQUOTA", val.Id_aliquota);

            return this.executarProc("EXCLUI_FIS_ALIQUOTASIMPLES", hs);
        }
    }
    #endregion
}
