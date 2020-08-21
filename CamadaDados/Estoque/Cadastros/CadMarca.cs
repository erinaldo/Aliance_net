using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadMarca : List<TRegistro_CadMarca>, IComparer<TRegistro_CadMarca>
    {
        #region IComparer<TRegistro_CadMarca> Members
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

        public TList_CadMarca()
        { }

        public TList_CadMarca(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadMarca value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadMarca x, TRegistro_CadMarca y)
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
    
    public class TRegistro_CadMarca
    {
        
        private decimal? cd_Marca;
        
        public decimal? Cd_Marca
        {
            get
            {
                if (cd_Marca == 0)
                    return null;
                else
                    return cd_Marca;
            }

            set
            {
                cd_Marca = value;
                cd_MarcaString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }

        private string cd_MarcaString;
        
        public string Cd_MarcaString
        {
            get { return cd_MarcaString; }
            set
            {
                cd_MarcaString = value;
                try
                {
                    cd_Marca = Convert.ToDecimal(value);
                }
                catch { cd_Marca = null; }
            }
        }
        
        public string Ds_Marca { get; set; }
        
        public TRegistro_CadMarca()
        {
            this.cd_Marca = null;
            this.cd_MarcaString = string.Empty;
            this.Ds_Marca = string.Empty; ;

        }
    }
    public class TCD_CadMarca : TDataQuery
    {
        public TCD_CadMarca()
        { }

        public TCD_CadMarca(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP" + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + "a.cd_marca, a.ds_marca ");
            else
                sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
            sql.AppendLine("From tb_est_marca a");

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
        public TList_CadMarca Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadMarca lista = new TList_CadMarca();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadMarca reg = new TRegistro_CadMarca();

                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Marca")))
                        reg.Cd_Marca = reader.GetDecimal(reader.GetOrdinal("Cd_Marca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_Marca"))))
                        reg.Ds_Marca = reader.GetString(reader.GetOrdinal("Ds_Marca"));
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
        public string GravaCadMarca(TRegistro_CadMarca val)
        {
            Hashtable hs = new Hashtable(20);
            hs.Add("@P_CD_MARCA", val.Cd_Marca);
            hs.Add("@P_DS_MARCA", val.Ds_Marca);
            return this.executarProc("IA_EST_MARCA", hs);
        }
        public string DeletaCadMarca(TRegistro_CadMarca val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_MARCA", val.Cd_Marca);
            hs.Add("@P_DS_MARCA", val.Ds_Marca);
            return this.executarProc("EXCLUI_EST_MARCA", hs);
        }
    }
}
