using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_Markup : List<TRegistro_Markup>, IComparer<TRegistro_Markup>
    {
        #region IComparer<TRegistro_Markup> Members
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

        public TList_Markup()
        { }

        public TList_Markup(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Markup value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Markup x, TRegistro_Markup y)
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
    
    public class TRegistro_Markup
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_markup;
        public decimal? Id_markup
        {
            get { return id_markup; }
            set
            {
                id_markup = value;
                id_markupstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_markupstr;
        public string Id_markupstr
        {
            get { return id_markupstr; }
            set
            {
                id_markupstr = value;
                try
                {
                    id_markup = decimal.Parse(value);
                }
                catch
                { id_markup = null; }
            }
        }
        public string Ds_markup
        { get; set; }
        private string tp_markup;
        public string Tp_markup
        {
            get { return tp_markup; }
            set
            {
                tp_markup = value;
                if (value.Trim().ToUpper().Equals("D"))
                    tipo_markup = "DIVISOR";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_markup = "MULTIPLICADOR";
            }
        }
        private string tipo_markup;
        public string Tipo_markup
        {
            get { return tipo_markup; }
            set
            {
                tipo_markup = value;
                if (value.Trim().ToUpper().Equals("DIVISOR"))
                    tp_markup = "D";
                else if (value.Trim().ToUpper().Equals("MULTIPLICADOR"))
                    tp_markup = "M";
            }
        }
        public decimal Pc_custofixo
        { get; set; }
        public decimal Pc_custovariavel
        { get; set; }
        public decimal Pc_lucro
        { get; set; }
        public decimal Pc_indicemarkup
        {
            get
            {
                if (Pc_custofixo > decimal.Zero &&
                    Pc_custovariavel > decimal.Zero &&
                    !string.IsNullOrEmpty(tp_markup))
                {
                    if (tp_markup.Trim().ToUpper().Equals("M"))
                        return Pc_custofixo + Pc_custovariavel + Pc_lucro >= 100 ? decimal.Zero : Math.Round(decimal.Divide(100, 100 - Pc_custofixo - Pc_custovariavel - Pc_lucro), 5, MidpointRounding.AwayFromZero);
                    else return Math.Round(decimal.Divide(100 - Pc_custofixo - Pc_custovariavel - Pc_lucro, 100), 5, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
        }

        public TRegistro_Markup()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_markup = null;
            id_markupstr = string.Empty;
            Ds_markup = string.Empty;
            tp_markup = string.Empty;
            Pc_custofixo = decimal.Zero;
            Pc_custovariavel = decimal.Zero;
            Pc_lucro = decimal.Zero;
        }
    }

    public class TCD_Markup : TDataQuery
    {
        public TCD_Markup()
        { }

        public TCD_Markup(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP" + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_markup, a.ds_markup, a.tp_markup, ");
                sql.AppendLine("a.pc_custofixo, a.pc_custovariavel, a.pc_lucro ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
            sql.AppendLine("From tb_est_markup a");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

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

        public TList_Markup Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Markup lista = new TList_Markup();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Markup reg = new TRegistro_Markup();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_markup")))
                        reg.Id_markup = reader.GetDecimal(reader.GetOrdinal("id_markup"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_markup"))))
                        reg.Ds_markup = reader.GetString(reader.GetOrdinal("Ds_markup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_markup")))
                        reg.Tp_markup = reader.GetString(reader.GetOrdinal("tp_markup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_custofixo")))
                        reg.Pc_custofixo = reader.GetDecimal(reader.GetOrdinal("pc_custofixo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_custovariavel")))
                        reg.Pc_custovariavel = reader.GetDecimal(reader.GetOrdinal("pc_custovariavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_lucro")))
                        reg.Pc_lucro = reader.GetDecimal(reader.GetOrdinal("pc_lucro"));

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

        public string Gravar(TRegistro_Markup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MARKUP", val.Id_markup);
            hs.Add("@P_DS_MARKUP", val.Ds_markup);
            hs.Add("@P_TP_MARKUP", val.Tp_markup);
            hs.Add("@P_PC_CUSTOFIXO", val.Pc_custofixo);
            hs.Add("@P_PC_CUSTOVARIAVEL", val.Pc_custovariavel);
            hs.Add("@P_PC_LUCRO", val.Pc_lucro);

            return executarProc("IA_EST_MARKUP", hs);
        }

        public string Excluir(TRegistro_Markup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MARKUP", val.Id_markup);

            return executarProc("EXCLUI_EST_MARKUP", hs);
        }
    }
}
