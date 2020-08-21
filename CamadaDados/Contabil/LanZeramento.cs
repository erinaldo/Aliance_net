using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Contabil
{
    #region Zeramento
    public class TList_Zeramento : List<TRegistro_Zeramento>, IComparer<TRegistro_Zeramento>
    {
        #region IComparer<TRegistro_Zeramento> Members
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

        public TList_Zeramento()
        { }

        public TList_Zeramento(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Zeramento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Zeramento x, TRegistro_Zeramento y)
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

    public class TRegistro_Zeramento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_zeramento;
        public decimal? Id_zeramento
        {
            get { return id_zeramento; }
            set
            {
                id_zeramento = value;
                id_zeramentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_zeramentostr;
        public string Id_zeramentostr
        {
            get { return id_zeramentostr; }
            set
            {
                id_zeramentostr = value;
                try
                {
                    id_zeramento = decimal.Parse(value);
                }
                catch { id_zeramento = null; }
            }
        }
        private DateTime? dt_zeramento;
        public DateTime? Dt_zeramento
        {
            get { return dt_zeramento; }
            set
            {
                dt_zeramento = value;
                dt_zeramentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_zeramentostr;
        public string Dt_zeramentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_zeramentostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_zeramentostr = value;
                try
                {
                    dt_zeramento = DateTime.Parse(value);
                }
                catch { dt_zeramento = null; }
            }
        }
        public string Complemento
        { get; set; }

        public TRegistro_Zeramento()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_zeramento = null;
            this.id_zeramentostr = string.Empty;
            this.dt_zeramento = null;
            this.dt_zeramentostr = string.Empty;
            this.Complemento = string.Empty;
        }
    }

    public class TCD_Zeramento : TDataQuery
    {
        public TCD_Zeramento() { }

        public TCD_Zeramento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_zeramento, a.dt_zeramento, a.complemento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Zeramento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_Zeramento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_Zeramento lista = new TList_Zeramento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_Zeramento reg = new TRegistro_Zeramento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_zeramento")))
                        reg.Id_zeramento = reader.GetDecimal(reader.GetOrdinal("id_zeramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_zeramento")))
                        reg.Dt_zeramento = reader.GetDateTime(reader.GetOrdinal("dt_zeramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("complemento")))
                        reg.Complemento = reader.GetString(reader.GetOrdinal("complemento"));
                    
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

        public string Gravar(TRegistro_Zeramento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ZERAMENTO", val.Id_zeramento);
            hs.Add("@P_DT_ZERAMENTO", val.Dt_zeramento);
            hs.Add("@P_COMPLEMENTO", val.Complemento);

            return this.executarProc("IA_CTB_ZERAMENTO", hs);
        }

        public string Excluir(TRegistro_Zeramento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ZERAMENTO", val.Id_zeramento);

            return this.executarProc("EXCLUI_CTB_ZERAMENTO", hs);
        }

        public string ExcluirLoteZeramento(TRegistro_Zeramento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ZERAMENTO", val.Id_zeramento);

            return this.executarProc("EXCLUI_CTB_LOTEZERAMENTO", hs);
        }
    }
    #endregion

    #region Zeramento X Lote
    public class TList_Zeramento_X_Lote : List<TRegistro_Zeramento_X_Lote>
    { }

    public class TRegistro_Zeramento_X_Lote
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_zeramento;
        public decimal? Id_zeramento
        {
            get { return id_zeramento; }
            set
            {
                id_zeramento = value;
                id_zeramentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_zeramentostr;
        public string Id_zeramentostr
        {
            get { return id_zeramentostr; }
            set
            {
                id_zeramentostr = value;
                try
                {
                    id_zeramento = decimal.Parse(value);
                }
                catch { id_zeramento = null; }
            }
        }
        private decimal? id_loteCTB;
        public decimal? Id_loteCTB
        {
            get { return id_loteCTB; }
            set
            {
                id_loteCTB = value;
                id_loteCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTBstr;
        public string Id_loteCTBstr
        {
            get { return id_loteCTBstr; }
            set
            {
                id_loteCTBstr = value;
                try
                {
                    id_loteCTB = decimal.Parse(value);
                }
                catch { id_loteCTB = null; }
            }
        }

        public TRegistro_Zeramento_X_Lote()
        {
            this.Cd_empresa = string.Empty;
            this.id_zeramento = null;
            this.id_zeramentostr = string.Empty;
            this.id_loteCTB = null;
            this.id_loteCTBstr = string.Empty;
        }
    }

    public class TCD_Zeramento_X_Lote : TDataQuery
    {
        public TCD_Zeramento_X_Lote() { }

        public TCD_Zeramento_X_Lote(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.id_zeramento, a.id_loteCTB ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Zeramento_X_Lote a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Zeramento_X_Lote Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Zeramento_X_Lote lista = new TList_Zeramento_X_Lote();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Zeramento_X_Lote reg = new TRegistro_Zeramento_X_Lote();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_zeramento")))
                        reg.Id_zeramento = reader.GetDecimal(reader.GetOrdinal("id_zeramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));

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

        public string Gravar(TRegistro_Zeramento_X_Lote val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ZERAMENTO", val.Id_zeramento);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);

            return this.executarProc("IA_CTB_ZERAMENTO_X_LOTE", hs);
        }

        public string Excluir(TRegistro_Zeramento_X_Lote val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ZERAMENTO", val.Id_zeramento);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);

            return this.executarProc("EXCLUI_CTB_ZERAMENTO_X_LOTE", hs);
        }
    }
    #endregion
}
