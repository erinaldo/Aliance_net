using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_CadSafra : List<TRegistro_CadSafra>, IComparer<TRegistro_CadSafra>
    {
        #region IComparer<TRegistro_CadSafra> Members
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

        public TList_CadSafra()
        { }

        public TList_CadSafra(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSafra value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSafra x, TRegistro_CadSafra y)
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
    
    public class TRegistro_CadSafra
    {
        public string AnoSafra{get;set;}
        public string DS_Safra{ get;set;}
        private DateTime? dt_inisafra;
        public DateTime? Dt_inisafra
        {
            get { return dt_inisafra; }
            set
            {
                dt_inisafra = value;
                dt_inisafrastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inisafrastr;
        public string Dt_inisafrastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inisafrastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inisafrastr = value;
                try
                {
                    dt_inisafra = DateTime.Parse(value);
                }
                catch { dt_inisafra = null; }
            }
        }
        private DateTime? dt_finsafra;
        public DateTime? Dt_finsafra
        {
            get { return dt_finsafra; }
            set
            {
                dt_finsafra = value;
                dt_finsafrastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finsafrastr;
        public string Dt_finsafrastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finsafrastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finsafrastr = value;
                try
                {
                    dt_finsafra = DateTime.Parse(value);
                }
                catch { dt_finsafra = null; }
            }
        }
        
        public TRegistro_CadSafra()
        {
            AnoSafra = string.Empty;
            DS_Safra = string.Empty;
            dt_inisafra = null;
            dt_inisafrastr = string.Empty;
            dt_finsafra = null;
            dt_finsafrastr = string.Empty;
        }
    }

    public class TCD_CadSafra : TDataQuery
    {
        public TCD_CadSafra()
        { }

        public TCD_CadSafra(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

         private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.anosafra, a.ds_safra, a.dt_inisafra, a.dt_finsafra ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_safra a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.Anosafra asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public TList_CadSafra Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadSafra lista = new TList_CadSafra();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                
                while (reader.Read())
                {
                    TRegistro_CadSafra reg = new TRegistro_CadSafra();
                    if (!reader.IsDBNull(reader.GetOrdinal("anosafra")))
                        reg.AnoSafra = reader.GetString(reader.GetOrdinal("anosafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_safra")))
                        reg.DS_Safra = reader.GetString(reader.GetOrdinal("ds_safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_inisafra")))
                        reg.Dt_inisafra = reader.GetDateTime(reader.GetOrdinal("dt_inisafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_finsafra")))
                        reg.Dt_finsafra = reader.GetDateTime(reader.GetOrdinal("dt_finsafra"));

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

        public string Grava(TRegistro_CadSafra vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ANOSAFRA", vRegistro.AnoSafra);
            hs.Add("@P_DS_SAFRA", vRegistro.DS_Safra);
            hs.Add("@P_DT_INISAFRA", vRegistro.Dt_inisafra);
            hs.Add("@P_DT_FINSAFRA", vRegistro.Dt_finsafra);

            return executarProc("IA_GRO_SAFRA", hs);
        }

        public string Deleta(TRegistro_CadSafra vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ANOSAFRA", vRegistro.AnoSafra);

            return executarProc("EXCLUI_GRO_SAFRA", hs);
        }
    }
}