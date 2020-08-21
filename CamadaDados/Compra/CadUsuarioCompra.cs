using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Compra
{
    public class TList_CadUsuarioCompra : List<TRegistro_CadUsuarioCompra>, IComparer<TRegistro_CadUsuarioCompra>
     {
         #region IComparer<TRegistro_CadUsuarioCompra> Members
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

        public TList_CadUsuarioCompra()
        { }

        public TList_CadUsuarioCompra(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadUsuarioCompra value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadUsuarioCompra x, TRegistro_CadUsuarioCompra y)
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
    
    public class TRegistro_CadUsuarioCompra
     {
        
         public string Cd_clifor_cmp
         { get; set; }
        
         public string Nm_clifor_cmp
         { get; set; }
        
         public string Login 
         {get; set; }
        
         public string Nome_usuario
         { get; set; }
         private string st_requisitar;
         
         public string St_requisitar
         {
             get { return st_requisitar; }
             set
             {
                 st_requisitar = value;
                 st_requisitarbool = value.Trim().ToUpper().Equals("S");
             }
         }
         private bool st_requisitarbool;
         
         public bool St_requisitarbool
         {
             get { return st_requisitarbool; }
             set
             {
                 st_requisitarbool = value;
                 st_requisitar = value ? "S" : "N";
             }
         }
         private string st_aprovar;
         
         public string St_aprovar
         {
             get { return st_aprovar; }
             set
             {
                 st_aprovar = value;
                 st_aprovarbool = value.Trim().ToUpper().Equals("S");
             }
         }
         private bool st_aprovarbool;
         
         public bool St_aprovarbool
         {
             get { return st_aprovarbool; }
             set
             {
                 st_aprovarbool = value;
                 st_aprovar = value ? "S" : "N";
             }
         }
         private string st_comprar;
         
         public string St_comprar
         {
             get { return st_comprar; }
             set
             {
                 st_comprar = value;
                 st_comprarbool = value.Trim().ToUpper().Equals("S");
             }
         }
         private bool st_comprarbool;
         
         public bool St_comprarbool
         {
             get { return st_comprarbool; }
             set
             {
                 st_comprarbool = value;
                 st_comprar = value ? "S" : "N";
             }
         }

         public TRegistro_CadUsuarioCompra()
         {
             this.Cd_clifor_cmp = string.Empty;
             this.Nm_clifor_cmp = string.Empty;
             this.Login = string.Empty;
             this.Nome_usuario = string.Empty;
             this.st_requisitar = "N";
             this.st_requisitarbool = false;
             this.st_aprovar = "N";
             this.st_aprovarbool = false;
             this.st_comprar = "N";
             this.st_comprarbool = false;
         }
     }

    public class TCD_CadUsuarioCompra : TDataQuery
     {
         public TCD_CadUsuarioCompra()
         { }

         public TCD_CadUsuarioCompra(BancoDados.TObjetoBanco banco)
         { this.Banco_Dados = banco; }

         private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
         {
             string strTop = string.Empty;
             if (vTop > 0)
                 strTop = "TOP " + Convert.ToString(vTop);

             StringBuilder sql = new StringBuilder();
             if (string.IsNullOrEmpty(vNM_Campo))
             {
                 sql.AppendLine("Select " + strTop + " a.CD_Clifor_CMP, ");
                 sql.AppendLine("a.login, b.nome_usuario, c.nm_clifor, ");
                 sql.AppendLine("a.st_requisitar, a.st_aprovar, a.st_comprar ");
             }
             else
                 sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
             
             sql.AppendLine("from tb_cmp_usuariocompra a ");
             sql.AppendLine("inner join tb_div_usuario b ");
             sql.AppendLine("on b.login = a.login ");
             sql.AppendLine("inner join tb_fin_clifor c ");
             sql.AppendLine("on c.cd_clifor = a.cd_clifor_cmp ");

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

         public TList_CadUsuarioCompra Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
         {
             TList_CadUsuarioCompra lista = new TList_CadUsuarioCompra();
             
             bool podeFecharBco = false;
             if (Banco_Dados == null)
                 podeFecharBco = this.CriarBanco_Dados(false);
             SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));;
             try
             {
                 while (reader.Read())
                 {
                     TRegistro_CadUsuarioCompra reg = new TRegistro_CadUsuarioCompra();

                     if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor_CMP")))
                         reg.Cd_clifor_cmp = reader.GetString(reader.GetOrdinal("CD_Clifor_CMP"));
                     if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                         reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                     if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                         reg.Nm_clifor_cmp = reader.GetString(reader.GetOrdinal("nm_clifor"));
                     if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                         reg.Nome_usuario = reader.GetString(reader.GetOrdinal("nome_usuario"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Requisitar")))
                         reg.St_requisitar = reader.GetString(reader.GetOrdinal("ST_Requisitar"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Aprovar")))
                         reg.St_aprovar = reader.GetString(reader.GetOrdinal("ST_Aprovar"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Comprar")))
                         reg.St_comprar = reader.GetString(reader.GetOrdinal("ST_Comprar"));
                     
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
         
         public string Grava(TRegistro_CadUsuarioCompra val)
         {
             Hashtable hs = new Hashtable(5);
             hs.Add("@P_CD_CLIFOR_CMP", val.Cd_clifor_cmp);
             hs.Add("@P_LOGIN", val.Login);
             hs.Add("@P_ST_REQUISITAR", val.St_requisitar);
             hs.Add("@P_ST_APROVAR", val.St_aprovar);
             hs.Add("@P_ST_COMPRAR", val.St_comprar);

             return executarProc("IA_CMP_USUARIOCOMPRA", hs);
         }
         
         public string Deleta(TRegistro_CadUsuarioCompra val)
         {
             Hashtable hs = new Hashtable(1);
             hs.Add("@P_CD_CLIFOR_CMP", val.Cd_clifor_cmp);

             return executarProc("EXCLUI_CMP_USUARIOCOMPRA", hs);
         }
     }
}
