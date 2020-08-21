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
    public class TList_CadLocalArm_X_Empresa : List<TRegistro_CadLocalArm_X_Empresa>, IComparer<TRegistro_CadLocalArm_X_Empresa>
    {
        #region IComparer<TRegistro_CadLocalArm_X_Empresa> Members
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

        public TList_CadLocalArm_X_Empresa()
        { }

        public TList_CadLocalArm_X_Empresa(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadLocalArm_X_Empresa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadLocalArm_X_Empresa x, TRegistro_CadLocalArm_X_Empresa y)
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
    
    public class TRegistro_CadLocalArm_X_Empresa
    {
        
        public string CD_Local{ get; set; }
        
        public string DS_Local{ get; set;}
        
        public string CD_Empresa {get;set; }
        
        public string NM_Empresa { get; set;}
        
        public string ST_Registro {get;set; }

        public TRegistro_CadLocalArm_X_Empresa()
        {
            this.CD_Local = string.Empty;
            this.DS_Local = string.Empty;
            this.CD_Empresa = string.Empty;
            this.NM_Empresa = string.Empty;
            this.ST_Registro = "A";
        }
    }

    public class TCD_CadLocalArm_X_Empresa : TDataQuery
    {
        public TCD_CadLocalArm_X_Empresa()
        { }

        public TCD_CadLocalArm_X_Empresa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + "a.cd_local, c.ds_local, a.cd_empresa, b.nm_empresa, a.st_registro");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_Empresa_X_LocalArm a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join TB_EST_LocalArm c ");
            sql.AppendLine("on c.cd_local = a.cd_local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by b.nm_empresa asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadLocalArm_X_Empresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadLocalArm_X_Empresa lista = new TList_CadLocalArm_X_Empresa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadLocalArm_X_Empresa reg = new TRegistro_CadLocalArm_X_Empresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.CD_Local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.DS_Local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
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

        public string Grava(TRegistro_CadLocalArm_X_Empresa vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            return this.executarProc("IA_EST_Empresa_X_LocalArm", hs);
        }
        
        public string Deleta(TRegistro_CadLocalArm_X_Empresa vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);
            return this.executarProc("EXCLUI_EST_Empresa_X_LocalArm", hs);
        }

    }
}