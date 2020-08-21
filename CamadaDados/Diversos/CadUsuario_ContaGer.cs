using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_Usuario_ContaGer : List<TRegistro_Usuario_ContaGer>
    { }

    
    public class TRegistro_Usuario_ContaGer
    {
        
        public string Login
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }

        public TRegistro_Usuario_ContaGer()
        {
            this.Login = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
        }
    }

    public class TCD_Usuario_ContaGer : TDataQuery
    {
        public TCD_Usuario_ContaGer()
        { }

        public TCD_Usuario_ContaGer(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " a.Login, a.cd_contager, b.ds_contager ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_ContaGer a ");
            sql.AppendLine("inner join TB_FIN_ContaGer b ");
            sql.AppendLine("On a.cd_contager = b.cd_contager ");

            string cond = " Where ";
            if (vBusca != null)
                for (Int16 i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Usuario_ContaGer Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Usuario_ContaGer lista = new TList_Usuario_ContaGer();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Usuario_ContaGer reg = new TRegistro_Usuario_ContaGer();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ContaGer"))))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));

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

        public string Gravar(TRegistro_Usuario_ContaGer val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return this.executarProc("IA_DIV_USUARIO_X_CONTAGER", hs);
        }

        public string Excluir(TRegistro_Usuario_ContaGer val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return this.executarProc("EXCLUI_DIV_USUARIO_X_CONTAGER", hs);
        }
    }
}
