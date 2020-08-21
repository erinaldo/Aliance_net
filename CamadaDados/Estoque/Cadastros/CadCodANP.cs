using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CodANP : List<TRegistro_CodANP>, IComparer<TRegistro_CodANP>
    {
        #region IComparer<TRegistro_CodANP> Members
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

        public TList_CodANP()
        { }

        public TList_CodANP(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CodANP value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CodANP x, TRegistro_CodANP y)
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

    
    public class TRegistro_CodANP
    {
        
        public string Cd_anp
        { get; set; }
        
        public string Ds_anp
        { get; set; }

        public TRegistro_CodANP()
        {
            this.Cd_anp = string.Empty;
            this.Ds_anp = string.Empty;
        }
    }

    public class TCD_CodANP : TDataQuery
    {
        public TCD_CodANP()
        { }

        public TCD_CodANP(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.cd_anp, a.ds_anp ");
            else
                sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
            sql.AppendLine(" from tb_est_anp a ");

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

        public TList_CodANP Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CodANP lista = new TList_CodANP();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CodANP reg = new TRegistro_CodANP();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));

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

        public string Gravar(TRegistro_CodANP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_ANP", val.Cd_anp);
            hs.Add("@P_DS_ANP", val.Ds_anp);

            return this.executarProc("IA_EST_ANP", hs);
        }

        public string Excluir(TRegistro_CodANP val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_ANP", val.Cd_anp);

            return this.executarProc("EXCLUI_EST_ANP", hs);
        }
    }
}
