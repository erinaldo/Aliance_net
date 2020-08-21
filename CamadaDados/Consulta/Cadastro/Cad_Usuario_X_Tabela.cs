using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_Usuario_X_Tabela : List<TRegistro_Cad_Usuario_X_Tabela>{ }

    public class TRegistro_Cad_Usuario_X_Tabela
    {
        public string Login { get; set; }
        public string nome_usuario { get; set; }
        public string NM_Clifor { get; set; }
        public string NM_Tabela { get; set; }

        public TRegistro_Cad_Usuario_X_Tabela()
        {
            this.nome_usuario = "";
            this.Login = "";
            this.NM_Tabela = "";
        }
    }

    public class TCD_Cad_Usuario_X_Tabela : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.Login, a.NM_Tabela, b.nome_usuario ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_usuario_x_tabela a ");
            sql.AppendLine(" inner join tb_div_usuario b on b.login = a.login ");

            cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY b.nome_usuario ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_Cad_Usuario_X_Tabela Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Usuario_X_Tabela lista = new TList_Cad_Usuario_X_Tabela();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                if (vNM_Campo == "")
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
                else
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_Cad_Usuario_X_Tabela reg = new TRegistro_Cad_Usuario_X_Tabela();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tabela")))
                        reg.NM_Tabela = reader.GetString(reader.GetOrdinal("NM_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                        reg.nome_usuario=     reader.GetString(reader.GetOrdinal("nome_usuario")); 
                    
                    lista.Add(reg);

                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            };
            return lista;
        }

        public string Grava(TRegistro_Cad_Usuario_X_Tabela val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_NM_TABELA", val.NM_Tabela);
            return executarProc("IA_CON_USUARIOXTABELA", hs);
        }

        public string Deleta(TRegistro_Cad_Usuario_X_Tabela val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_NM_TABELA", val.NM_Tabela);

            return executarProc("EXCLUI_CON_USUARIOXTABELA", hs);
        }

        public string DeletaTodos(TRegistro_Cad_Usuario_X_Tabela val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("EXCLUI_CON_USUARIOXTABELALOGIN", hs);
        }
    }
}
