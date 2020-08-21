using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
   public class TList_CadUsuarioxTerminal : List<TRegistro_CadUsuarioxTerminal> { }

    
   public class TRegistro_CadUsuarioxTerminal   
   {
        
       public string Cd_Terminal {get; set;}
        
        public string Ds_terminal { get; set; }
        
       public string Login {get; set;}
        
        public string Nome_usuario { get; set; }

      public TRegistro_CadUsuarioxTerminal()
       {
           this.Cd_Terminal = string.Empty;
           this.Ds_terminal = string.Empty;
           this.Login = string.Empty;
           this.Nome_usuario = string.Empty;
       }
   }

   public class TCD_CadUsuarioxTerminal : TDataQuery
   {
       public TCD_CadUsuarioxTerminal()
       { }

       public TCD_CadUsuarioxTerminal(BancoDados.TObjetoBanco banco)
       { this.Banco_Dados = banco; }

       private string sqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
       {
           string strTop = string.Empty;
           if (vTop > 0)
               strTop = " TOP " + Convert.ToString(vTop);
           StringBuilder sql=new StringBuilder();
           if (string.IsNullOrEmpty(vNM_Campo))
           {
               sql.AppendLine(" SELECT " + strTop + "a.cd_terminal, b.ds_terminal, ");
               sql.AppendLine("a.login, c.nome_usuario ");
           }
           else
               sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo + " ");

           sql.AppendLine("From tb_div_usuario_X_terminal a ");
           sql.AppendLine("inner join tb_div_terminal b ");
           sql.AppendLine("on a.cd_terminal=b.cd_terminal ");
           sql.AppendLine("inner join tb_div_usuario c ");
           sql.AppendLine("on a.login=c.login");

           string cond = "where";

           if (vBusca != null)
               for (int i = 0; i < (vBusca.Length); i++)
               {
                   sql.AppendLine(cond + " (" + " " + vBusca[i].vNM_Campo + "" + vBusca[i].vOperador + "" + vBusca[i].vVL_Busca + " )");
                   cond = "and";
               }
           sql.AppendLine("Order By a.login asc");
           return sql.ToString();
       }

       public override DataTable Buscar(TpBusca[] vBusca, short vTop)
       {
           return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, ""), null);
       }

       public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
       {
           return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, vNM_Campo), null);
       }

       public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
       {
           return this.ExecutarBuscaEscalar(this.sqlCodeBusca(vBusca, 1, vNM_Campo), null);
       }

       public TList_CadUsuarioxTerminal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
       {
           TList_CadUsuarioxTerminal lista = new TList_CadUsuarioxTerminal();
           SqlDataReader reader = null;
           bool podeFecharBco = false;
           if (Banco_Dados == null)
               podeFecharBco = this.CriarBanco_Dados(false);
           try
           {
               reader = this.ExecutarBusca(this.sqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
               while (reader.Read()) 
               {
                   TRegistro_CadUsuarioxTerminal reg = new TRegistro_CadUsuarioxTerminal();
                   if (!reader.IsDBNull(reader.GetOrdinal("cd_terminal")))
                       reg.Cd_Terminal = reader.GetString(reader.GetOrdinal("cd_terminal"));
                   if (!reader.IsDBNull(reader.GetOrdinal("ds_terminal")))
                       reg.Ds_terminal = reader.GetString(reader.GetOrdinal("ds_terminal"));
                   if (!reader.IsDBNull(reader.GetOrdinal("login")))
                       reg.Login = reader.GetString(reader.GetOrdinal("login"));
                   if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                       reg.Nome_usuario = reader.GetString(reader.GetOrdinal("nome_usuario"));
                   lista.Add(reg);
               };
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

       public string Grava(TRegistro_CadUsuarioxTerminal vRegistro)
       {
           System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
           hs.Add("@P_CD_TERMINAL", vRegistro.Cd_Terminal);
           hs.Add("@P_LOGIN", vRegistro.Login);

           return this.executarProc("IA_DIV_USUARIO_X_TERMINAL",hs);
       }

       public string Deleta(TRegistro_CadUsuarioxTerminal vRegistro)
       {
           System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
           hs.Add("@P_CD_TERMINAL", vRegistro.Cd_Terminal);
           hs.Add("@P_LOGIN", vRegistro.Login);

           return this.executarProc("EXCLUI_DIV_USUARIO_X_TERMINAL",hs);
       }
   }
}
