using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Diversos
{
    public class TRegistro_CadUsuario_TpProduto
    {
        public string Login { get; set; }
        public string Tp_Produto { get; set; }
    }

    public class TList_CadUsuario_TpProduto : List<TRegistro_CadUsuario_TpProduto>
    {

    }

    public class TCD_CadUsuario_TpProduto : TDataQuery
    {
        public TCD_CadUsuario_TpProduto()
        { }

        public TCD_CadUsuario_TpProduto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Login, a.tp_produto");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_TpProduto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public TList_CadUsuario_TpProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario_TpProduto lista = new TList_CadUsuario_TpProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadUsuario_TpProduto cadUser = new TRegistro_CadUsuario_TpProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        cadUser.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Produto")))
                        cadUser.Tp_Produto = reader.GetString(reader.GetOrdinal("TP_Produto"));

                    lista.Add(cadUser);
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

        public string Gravar(TRegistro_CadUsuario_TpProduto user)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", user.Login);
            hs.Add("@P_TP_PRODUTO", user.Tp_Produto);

            return executarProc("IA_DIV_USUARIO_X_TPPRODUTO", hs);
        }

        public string Deletar(TRegistro_CadUsuario_TpProduto user)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", user.Login);
            hs.Add("@P_TP_PRODUTO", user.Tp_Produto);

            return this.executarProc("EXCLUI_DIV_USUARIO_X_TPPRODUTO", hs);
        }
    }

}
