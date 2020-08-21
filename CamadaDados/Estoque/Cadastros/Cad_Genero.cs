using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_Cad_Genero : List<TRegistro_Cad_Genero>, IComparer<TRegistro_Cad_Genero>
    {
        #region IComparer<TRegistro_Cad_Genero> Members
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

        public TList_Cad_Genero()
        { }

        public TList_Cad_Genero(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cad_Genero value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cad_Genero x, TRegistro_Cad_Genero y)
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

    public class TRegistro_Cad_Genero
    {
        private decimal ?id_genero;
        public decimal ?Id_genero
        {
            get
            {
                if (id_genero == 0)
                    return null;
                else
                    return id_genero;
            }

            set
            {
                id_genero = value;
                id_generoString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_generoString;
        public string Id_generoString
        {
            get { return id_generoString; }
            set
            {
                id_generoString = value;
                try
                {
                    id_genero = Convert.ToDecimal(value);
                }
                catch { id_genero = null; }
            }
        }
        public string ds_genero
        { get; set; }
        
        public TRegistro_Cad_Genero()
        {
            id_genero = null;
            id_generoString = string.Empty;
            ds_genero = string.Empty;
        }
    }

    public class TCD_Cad_Genero : TDataQuery
    {
        public TCD_Cad_Genero()
        { }

        public TCD_Cad_Genero(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_genero, a.ds_genero ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from tb_est_GeneroProduto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_Genero Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Cad_Genero lista = new TList_Cad_Genero();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Cad_Genero reg = new TRegistro_Cad_Genero();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_genero")))
                        reg.Id_genero = reader.GetDecimal(reader.GetOrdinal("id_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_genero")))
                        reg.ds_genero = reader.GetString(reader.GetOrdinal("ds_genero"));
                    
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

        public string GravaCad_Genero(TRegistro_Cad_Genero val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_GENERO",val.Id_genero);
            hs.Add("@P_DS_GENERO", val.ds_genero);
            return this.executarProc("IA_EST_GENEROPRODUTO", hs);
        }

        public string DeletaCad_Genero(TRegistro_Cad_Genero val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_GENERO", val.Id_genero);
            return this.executarProc("EXCLUI_EST_GENEROPRODUTO", hs);
        }
    
    }
  
}
