using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_ReceitaPisCofins : List<TRegistro_ReceitaPisCofins>, IComparer<TRegistro_ReceitaPisCofins>
    {
        #region IComparer<TRegistro_ReceitaPisCofins> Members
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

        public TList_ReceitaPisCofins()
        { }

        public TList_ReceitaPisCofins(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ReceitaPisCofins value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ReceitaPisCofins x, TRegistro_ReceitaPisCofins y)
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

    public class TRegistro_ReceitaPisCofins
    {
        private decimal? id_receita;
        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;
        public string Id_receitastr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch { id_receita = null; }
            }
        }
        private decimal? cd_imposto;
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = decimal.Parse(value);
                }
                catch { cd_imposto = null; }
            }
        }
        public string Ds_imposto
        { get; set; }
        public string Ds_receita
        { get; set; }

        public TRegistro_ReceitaPisCofins()
        {
            this.id_receita = null;
            this.id_receitastr = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Ds_receita = string.Empty;
        }
    }

    public class TCD_ReceitaPisCofins : TDataQuery
    {
        public TCD_ReceitaPisCofins() { }

        public TCD_ReceitaPisCofins(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_receita, a.ds_receita, a.cd_imposto, b.ds_imposto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_ReceitaPisCofins a ");
            sql.AppendLine("inner join TB_FIS_Imposto b ");
            sql.AppendLine("on a.cd_imposto = b.cd_imposto ");

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

        public TList_ReceitaPisCofins Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ReceitaPisCofins lista = new TList_ReceitaPisCofins();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReceitaPisCofins reg = new TRegistro_ReceitaPisCofins();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("id_receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_receita")))
                        reg.Ds_receita = reader.GetString(reader.GetOrdinal("ds_receita"));

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

        public string Gravar(TRegistro_ReceitaPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_DS_RECEITA", val.Ds_receita);

            return this.executarProc("IA_FIS_RECEITAPISCOFINS", hs);
        }

        public string Excluir(TRegistro_ReceitaPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);

            return this.executarProc("EXCLUI_FIS_RECEITAPISCOFINS", hs);
        }
    }
}
