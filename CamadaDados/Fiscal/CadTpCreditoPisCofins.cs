using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_TpCreditoPisCofins : List<TRegistro_TpCreditoPisCofins>, IComparer<TRegistro_TpCreditoPisCofins>
    {
        #region IComparer<TRegistro_TpCreditoPisCofins> Members
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

        public TList_TpCreditoPisCofins()
        { }

        public TList_TpCreditoPisCofins(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpCreditoPisCofins value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpCreditoPisCofins x, TRegistro_TpCreditoPisCofins y)
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

    
    public class TRegistro_TpCreditoPisCofins
    {
        private decimal? id_tpcred;
        
        public decimal? Id_tpcred
        {
            get { return id_tpcred; }
            set
            {
                id_tpcred = value;
                id_tpcredstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpcredstr;
        
        public string Id_tpcredstr
        {
            get { return id_tpcredstr; }
            set
            {
                id_tpcredstr = value;
                try
                {
                    id_tpcred = decimal.Parse(value);
                }
                catch
                { id_tpcred = null; }
            }
        }
        
        public string Ds_tpcred
        { get; set; }

        public TRegistro_TpCreditoPisCofins()
        {
            this.id_tpcred = null;
            this.id_tpcredstr = string.Empty;
            this.Ds_tpcred = string.Empty;
        }
    }

    public class TCD_TpCreditoPisCofins : TDataQuery
    {
        public TCD_TpCreditoPisCofins()
        { }

        public TCD_TpCreditoPisCofins(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tpcred, a.ds_tpcred ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from tb_fis_tpcreditopiscofins a ");

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

        public TList_TpCreditoPisCofins Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TpCreditoPisCofins lista = new TList_TpCreditoPisCofins();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TpCreditoPisCofins reg = new TRegistro_TpCreditoPisCofins();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcred")))
                        reg.Id_tpcred = reader.GetDecimal(reader.GetOrdinal("id_tpcred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpcred")))
                        reg.Ds_tpcred = reader.GetString(reader.GetOrdinal("ds_tpcred"));

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

        public string Gravar(TRegistro_TpCreditoPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPCRED", val.Id_tpcred);
            hs.Add("@P_DS_TPCRED", val.Ds_tpcred);

            return this.executarProc("IA_FIS_TPCREDITOPISCOFINS", hs);
        }

        public string Excluir(TRegistro_TpCreditoPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TPCRED", val.Id_tpcred);

            return this.executarProc("EXCLUI_FIS_TPCREDITOPISCOFINS", hs);
        }
    }
}
