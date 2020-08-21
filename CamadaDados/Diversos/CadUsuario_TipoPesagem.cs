using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario_TipoPesagem : List<TRegistro_CadUsuario_TipoPesagem>
    { }

    
    public class TRegistro_CadUsuario_TipoPesagem
    {
        
        public string Login { get; set; }
        
        public string Nome_usuario { get; set; }
        
        public string Tp_pesagem { get; set; }
        
        public string Nm_tppesagem { get; set; }

        public TRegistro_CadUsuario_TipoPesagem()
        {
            this.Login = string.Empty;
            this.Nome_usuario = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.Nm_tppesagem = string.Empty;
        }
    }
    public class TCD_CadUsuario_TipoPesagem : TDataQuery
    {
        public TCD_CadUsuario_TipoPesagem()
        { }

        public TCD_CadUsuario_TipoPesagem(BancoDados.TObjetoBanco banco)
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
                sql.AppendLine("Select " + strTop + " a.Login, b.Nome_usuario, a.TP_Pesagem, c.NM_TpPesagem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_TpPesagem a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("On b.login = a.login ");
            sql.AppendLine("inner join TB_BAL_TpPesagem c ");
            sql.AppendLine("On c.TP_Pesagem = a.TP_Pesagem ");

            string cond = " Where ";
            if (vBusca != null)
                for (Int16 i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
        public TList_CadUsuario_TipoPesagem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario_TipoPesagem lista = new TList_CadUsuario_TipoPesagem();
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
                    TRegistro_CadUsuario_TipoPesagem reg = new TRegistro_CadUsuario_TipoPesagem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nome_usuario"))))
                        reg.Nome_usuario = reader.GetString(reader.GetOrdinal("Nome_usuario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("tp_pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tppesagem")))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("Nm_tppesagem"));
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

        public string GravaTipoPesagem(TRegistro_CadUsuario_TipoPesagem val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return executarProc("IA_DIV_USUARIO_X_TPPESAGEM", hs);
        }

        public string DeletaTipoPesagem(TRegistro_CadUsuario_TipoPesagem val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return executarProc("EXCLUI_DIV_USUARIO_X_TPPESAGEM", hs);
        }
    }
}
