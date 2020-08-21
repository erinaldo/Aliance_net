using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadMoega_X_TabDesc : List<TRegistro_CadMoega_X_TabDesc>, IComparer<TRegistro_CadMoega_X_TabDesc>
    {
        #region IComparer<TRegistro_CadMoega_X_TabDesc> Members
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

        public TList_CadMoega_X_TabDesc()
        { }

        public TList_CadMoega_X_TabDesc(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadMoega_X_TabDesc value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadMoega_X_TabDesc x, TRegistro_CadMoega_X_TabDesc y)
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
    
    public class TRegistro_CadMoega_X_TabDesc
    {
        
        public string CD_Moega {get;set;}
        
        public string DS_Moega{get; set;}
        
        public string CD_TabelaDesconto { get;set;}
        
        public string DS_TabelaDesconto{ get;set;}
        
        public string ST_Registro  {get; set;}
        
        public TRegistro_CadMoega_X_TabDesc()
        {
            this.CD_Moega = string.Empty;
            this.DS_Moega = string.Empty;
            this.CD_TabelaDesconto = string.Empty;
            this.DS_TabelaDesconto = string.Empty;
            this.ST_Registro = "A";  
        }
     }
 
    public class TCD_CadMoega_X_TabDesc : TDataQuery
    {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_moega, b.ds_moega, a.cd_tabeladesconto, c.ds_tabeladesconto, a.st_registro");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_Moega_X_TabDesc a ");
            sql.AppendLine(" left outer join TB_EST_Moega b on (b.cd_moega = a.cd_moega)");
            sql.AppendLine(" left outer join TB_GRO_TabelaDesconto c on (c.cd_tabeladesconto = a.cd_tabeladesconto)");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.cd_moega asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

            public TList_CadMoega_X_TabDesc Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadMoega_X_TabDesc lista = new TList_CadMoega_X_TabDesc();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
                {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadMoega_X_TabDesc reg = new TRegistro_CadMoega_X_TabDesc();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moega")))
                        reg.CD_Moega = reader.GetString(reader.GetOrdinal("cd_moega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moega")))
                        reg.DS_Moega = reader.GetString(reader.GetOrdinal("ds_moega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                        reg.CD_TabelaDesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                        reg.DS_TabelaDesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
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
    
        public string Grava(TRegistro_CadMoega_X_TabDesc vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_MOEGA", vRegistro.CD_Moega);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_TabelaDesconto);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            return this.executarProc("IA_EST_MOEGA_X_TABDESC", hs);
        }

        public string Deleta(TRegistro_CadMoega_X_TabDesc vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_MOEGA", vRegistro.CD_Moega);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_TabelaDesconto );
            return this.executarProc("EXCLUI_EST_MOEGA_X_TABDESC", hs);
        }

       
    }
}