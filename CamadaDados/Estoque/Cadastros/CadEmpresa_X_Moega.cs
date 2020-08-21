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
    public class TList_CadEmpresa_X_Moega : List<TRegistro_CadEmpresa_X_Moega>, IComparer<TRegistro_CadEmpresa_X_Moega>
    {
        #region IComparer<TRegistro_CadEmpresa_X_Moega> Members
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

        public TList_CadEmpresa_X_Moega()
        { }

        public TList_CadEmpresa_X_Moega(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadEmpresa_X_Moega value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadEmpresa_X_Moega x, TRegistro_CadEmpresa_X_Moega y)
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

    
    public class TRegistro_CadEmpresa_X_Moega
    {
        
        public string CD_Empresa { get; set; }
        
        public string NM_Empresa { get; set; }
        
        public string CD_Moega { get; set; }
        
        public string DS_Moega { get; set; }
        
        public string ST_Registro  { get; set; }

        public TRegistro_CadEmpresa_X_Moega()
        {
            this.CD_Empresa = string.Empty;
            this.NM_Empresa = string.Empty;
            this.CD_Moega = string.Empty;
            this.DS_Moega = string.Empty;
            this.ST_Registro = "A";
        }
    }

    public class TCD_CadEmpresa_X_Moega : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_moega, c.ds_moega, a.cd_empresa, b.nm_empresa, a.st_registro");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_Empresa_X_Moega a ");
            sql.AppendLine(" left outer join TB_DIV_Empresa b on (b.cd_empresa = a.cd_empresa)");
            sql.AppendLine(" left outer join TB_EST_Moega c on (c.cd_moega = a.cd_moega)");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by c.ds_moega asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadEmpresa_X_Moega Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadEmpresa_X_Moega lista = new TList_CadEmpresa_X_Moega();
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
                    TRegistro_CadEmpresa_X_Moega reg = new TRegistro_CadEmpresa_X_Moega();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moega")))
                        reg.CD_Moega = reader.GetString(reader.GetOrdinal("cd_moega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moega")))
                        reg.DS_Moega = reader.GetString(reader.GetOrdinal("ds_moega"));
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

        public string Grava(TRegistro_CadEmpresa_X_Moega vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_CD_MOEGA", vRegistro.CD_Moega);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            return this.executarProc("IA_EST_Empresa_X_Moega", hs);
        }

        public string Deleta(TRegistro_CadEmpresa_X_Moega vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_CD_MOEGA", vRegistro.CD_Moega);
            return this.executarProc("EXCLUI_EST_Empresa_X_Moega", hs);
        }

    }
}