using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario_Grupo : List<TRegistro_CadUsuario_Grupo>
    { }

    
    public class TRegistro_CadUsuario_Grupo
    {
        
        public string LoginGrp { get; set; }
        
        public string Nome_grupo { get; set; }
        
        public string LoginUsr { get; set; }
        
        public string Nome_usuario { get; set; }
        
        public TRegistro_CadUsuario_Grupo()
        {
            this.LoginGrp = string.Empty;
            this.Nome_grupo = string.Empty;
            this.LoginUsr = string.Empty;
            this.Nome_usuario = string.Empty;
        }
    }
    public class TCD_CadUsuario_Grupo : TDataQuery
    {
        public TCD_CadUsuario_Grupo()
        { }

        public TCD_CadUsuario_Grupo(BancoDados.TObjetoBanco banco)
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
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.loginusr, b.nome_usuario, a.logingrp, c.nome_usuario as NM_Grupo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_Grupos a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("On b.login = a.loginusr ");
            sql.AppendLine("inner join TB_DIV_Usuario c ");
            sql.AppendLine("On c.login = a.logingrp ");

            string cond = " where ";
            if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_CadUsuario_Grupo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario_Grupo lista = new TList_CadUsuario_Grupo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            { 
                if(vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while(reader.Read())
                {
                    TRegistro_CadUsuario_Grupo reg = new TRegistro_CadUsuario_Grupo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("LoginGrp"))))
                        reg.LoginGrp = reader.GetString(reader.GetOrdinal("LoginGrp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Grupo")))
                        reg.Nome_grupo = reader.GetString(reader.GetOrdinal("NM_Grupo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("LoginUsr"))))
                        reg.LoginUsr = reader.GetString(reader.GetOrdinal("LoginUsr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nome_usuario")))
                        reg.Nome_usuario = reader.GetString(reader.GetOrdinal("nome_usuario"));
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
        
        public string GravaUserGrupo(TRegistro_CadUsuario_Grupo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGINGRP", val.LoginGrp);
            hs.Add("@P_LOGINUSR", val.LoginUsr);
            return executarProc("IA_DIV_USUARIO_X_GRUPOS", hs);
        }

        public string DeletaUserGrupo(TRegistro_CadUsuario_Grupo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGINUSR", val.LoginUsr);
            hs.Add("@P_LOGINGRP", val.LoginGrp);
            return executarProc("EXCLUI_DIV_USUARIO_X_GRUPOS", hs);
        }
    }   
}
