using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario_Empresa : List<TRegistro_CadUsuario_Empresa>
    { }

    
    public class TRegistro_CadUsuario_Empresa
    {
        
        public string CD_Empresa{ get; set; }
        
        public string Login{ get; set; }
        
        public string Nome_usuario { get; set; }
        
        public string NM_Empresa { get; set; }

        public TRegistro_CadUsuario_Empresa()
        {
            this.CD_Empresa = string.Empty;
            this.Login = string.Empty;
            this.Nome_usuario = string.Empty;
            this.NM_Empresa = string.Empty;
        }
    }

    public class TCD_CadUsuario_Empresa : TDataQuery
    {
        public TCD_CadUsuario_Empresa()
        { }

        public TCD_CadUsuario_Empresa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder  sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.Login, b.Nome_usuario, a.CD_Empresa, c.NM_Empresa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_Empresa a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("On b.login = a.login ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("On c.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("and isnull(c.st_registro, 'A') <> 'C'");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_CadUsuario_Empresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario_Empresa lista = new TList_CadUsuario_Empresa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                if (string.IsNullOrEmpty(vNM_Campo))
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadUsuario_Empresa reg = new TRegistro_CadUsuario_Empresa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                        reg.Nome_usuario = reader.GetString(reader.GetOrdinal("Nome_usuario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
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

        public string GravaUsuarioEmpresa(TRegistro_CadUsuario_Empresa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("IA_DIV_USUARIO_X_EMPRESA", hs);
        }

        public string DeletarUsuarioEmpresa(TRegistro_CadUsuario_Empresa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("EXCLUI_DIV_USUARIO_X_EMPRESA", hs);
        }
    }
}
