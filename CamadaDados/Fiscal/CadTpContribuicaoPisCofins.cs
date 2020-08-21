using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_TpContribuicaoPisCofins : List<TRegistro_TpContribuicaoPisCofins>, IComparer<TRegistro_TpContribuicaoPisCofins>
    {
        #region IComparer<TRegistro_TpContribuicaoPisCofins> Members
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

        public TList_TpContribuicaoPisCofins()
        { }

        public TList_TpContribuicaoPisCofins(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpContribuicaoPisCofins value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpContribuicaoPisCofins x, TRegistro_TpContribuicaoPisCofins y)
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

    
    public class TRegistro_TpContribuicaoPisCofins
    {
        private decimal? id_tpcontribuicao;
        
        public decimal? Id_tpcontribuicao
        {
            get { return id_tpcontribuicao; }
            set
            {
                id_tpcontribuicao = value;
                id_tpcontribuicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpcontribuicaostr;
        
        public string Id_tpcontribuicaostr
        {
            get { return id_tpcontribuicaostr; }
            set
            {
                id_tpcontribuicaostr = value;
                try
                {
                    id_tpcontribuicao = decimal.Parse(value);
                }
                catch
                { id_tpcontribuicao = null; }
            }
        }
        
        public string Ds_tpcontribuicao
        { get; set; }

        public TRegistro_TpContribuicaoPisCofins()
        {
            this.id_tpcontribuicao = null;
            this.id_tpcontribuicaostr = string.Empty;
            this.Ds_tpcontribuicao = string.Empty;
        }
    }

    public class TCD_TpContribuicaoPisCofins : TDataQuery
    {
        public TCD_TpContribuicaoPisCofins()
        { }

        public TCD_TpContribuicaoPisCofins(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tpcontribuicao, a.ds_tpcontribuicao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from tb_fis_tpcontribuicaopiscofins a ");

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

        public TList_TpContribuicaoPisCofins Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TpContribuicaoPisCofins lista = new TList_TpContribuicaoPisCofins();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TpContribuicaoPisCofins reg = new TRegistro_TpContribuicaoPisCofins();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcontribuicao")))
                        reg.Id_tpcontribuicao = reader.GetDecimal(reader.GetOrdinal("id_tpcontribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpcontribuicao")))
                        reg.Ds_tpcontribuicao = reader.GetString(reader.GetOrdinal("ds_tpcontribuicao"));

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

        public string Gravar(TRegistro_TpContribuicaoPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPCONTRIBUICAO", val.Id_tpcontribuicao);
            hs.Add("@P_DS_TPCONTRIBUICAO", val.Ds_tpcontribuicao);

            return this.executarProc("IA_FIS_TPCONTRIBUICAOPISCOFINS", hs);
        }

        public string Excluir(TRegistro_TpContribuicaoPisCofins val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TPCONTRIBUICAO", val.Id_tpcontribuicao);

            return this.executarProc("EXCLUI_FIS_TPCONTRIBUICAOPISCOFINS", hs);
        }
    }
}
