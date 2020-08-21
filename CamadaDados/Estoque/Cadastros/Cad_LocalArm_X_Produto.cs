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
    public class TList_CadLocalArm_X_Produto : List<TRegistro_CadLocalArm_X_Produto>, IComparer<TRegistro_CadLocalArm_X_Produto>
    {
        #region IComparer<TRegistro_CadLocalArm_X_Produto> Members
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

        public TList_CadLocalArm_X_Produto()
        { }

        public TList_CadLocalArm_X_Produto(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadLocalArm_X_Produto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadLocalArm_X_Produto x, TRegistro_CadLocalArm_X_Produto y)
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
    
    public class TRegistro_CadLocalArm_X_Produto
    {
        
        public string CD_Local { get; set; }
        
        public string DS_Local { get; set; }
        
        public string CD_Produto { get; set; }
        
        public string DS_Produto  { get;set;}
        
        public TRegistro_CadLocalArm_X_Produto()
        {
            this.CD_Local = string.Empty;
            this.DS_Local = string.Empty;
            this.CD_Produto = string.Empty;
            this.DS_Produto = string.Empty;
        }
     }
 
    public class TCD_CadLocalArm_X_Produto : TDataQuery
    {
        public TCD_CadLocalArm_X_Produto()
        { }

        public TCD_CadLocalArm_X_Produto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + "a.cd_local, c.ds_local, a.cd_produto, b.ds_produto, a.st_registro");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_LocalArm_X_Produto a ");
            sql.AppendLine("left outer join TB_EST_Produto b on (b.cd_produto = a.cd_produto)");
            sql.AppendLine("left outer join TB_EST_LocalArm c on (c.cd_local = a.cd_local)");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by c.ds_local asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadLocalArm_X_Produto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadLocalArm_X_Produto lista = new TList_CadLocalArm_X_Produto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadLocalArm_X_Produto reg = new TRegistro_CadLocalArm_X_Produto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.CD_Local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.DS_Local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
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
    
        public string Grava(TRegistro_CadLocalArm_X_Produto vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);
            return executarProc("IA_EST_LocalArm_X_Produto", hs);
        }

        public string Deleta(TRegistro_CadLocalArm_X_Produto vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);
           return executarProc("EXCLUI_EST_LocalArm_X_Produto", hs);
        }
    }
}