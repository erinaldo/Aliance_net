using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Consulta
{
    public class TList_SqlEditor : List<TRegistro_SqlEditor> { }

    public class TRegistro_SqlEditor
    {
        public string ID_Consulta { get; set; }
        public string Login { get; set; }
        public string DS_Consulta { get; set; }
        public string DS_SQL { get; set; }
        private DateTime? _DT_Consulta;
        public DateTime? DT_Consulta
        {
            get { return _DT_Consulta; }
            set
            {
                _DT_Consulta = value;
                _DT_ConsultaString = value.ToString();
            }
        }
        private string _DT_ConsultaString;
        public string DT_ConsultaString
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_DT_ConsultaString).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                _DT_ConsultaString = value;
                try
                { _DT_Consulta = Convert.ToDateTime(value); }
                catch
                { _DT_Consulta = null; }
            }
        }
        

        public TRegistro_SqlEditor()
        {
            this.ID_Consulta = "";
            this.Login = "";
            this.DS_Consulta = "";
            this.DS_SQL = "";
            this.DT_Consulta = DateTime.Now;
        }
    }

    public class TCD_SqlEditor : TDataQuery
    {
        public int tamanho { get; set; }
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
                sql.AppendLine("Select " + strTop + " a.ID_LOG, a.Login, a.COMANDOSQL ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_DIV_LogSQL a ");

            cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
          //  sql.AppendLine("ORDER BY a.DS_Consulta ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public DataTable BuscarSQL(string SQL)
        {
            BancoDados.TObjetoBanco pBanco_Dados = null;
            bool pode_liberar = false;
            if (pBanco_Dados == null)
            {
                pode_liberar = true;
                pBanco_Dados = new BancoDados.TObjetoBanco();
                pBanco_Dados.CriarObjetosBanco(Utils.Parametros.pubLogin, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
                pBanco_Dados.Comando.CommandType = CommandType.Text;
                pBanco_Dados.Comando.CommandText = SQL;
                pBanco_Dados.Conexao.Open();
            }
            try
            {
                //if (Parametros != null)
                //    pBanco_Dados.preencherParametrosBusca(Parametros);
                DataTable dt = new DataTable();
                if(SQL.ToUpper().Contains("SELECT"))
                    pBanco_Dados.Adapter.Fill(dt);
                else
                //   tamanho = Convert.ToInt32(pBanco_Dados.Comando.);
                // retorna o numero de registros afetados
                tamanho = pBanco_Dados.Comando.ExecuteNonQuery();
                return dt;
            }
            finally
            {
                if (pode_liberar)
                {
                    pBanco_Dados.Conexao.Close();
                    pBanco_Dados = null;
                }
            }
        }

        public TList_SqlEditor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_SqlEditor lista = new TList_SqlEditor();
            SqlDataReader reader;
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
                    TRegistro_SqlEditor reg = new TRegistro_SqlEditor();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOG")))
                        reg.ID_Consulta = reader.GetGuid(reader.GetOrdinal("ID_LOG")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("COMANDOSQL")))
                        reg.DS_Consulta = reader.GetString(reader.GetOrdinal("COMANDOSQL"));

                    lista.Add(reg);

                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            };
            return lista;
        }

        public string Grava(TRegistro_SqlEditor val)
        {
            Hashtable hs = new Hashtable(4);
            //Guid ID;
            //if (val.ID_Consulta != "")
            //    ID = new Guid(val.ID_Consulta);
            //else
            //    ID = System.Guid.NewGuid();

            hs.Add("@P_ID_LOG", val.ID_Consulta);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_COMANDOSQL", val.DS_Consulta);
          //  hs.Add("@P_DS_SQL", val.DS_SQL);
            return executarProc("IA_DIV_LOGSQL", hs);
        }

        public string Deleta(TRegistro_SqlEditor val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", new Guid(val.ID_Consulta));
            return executarProc("EXCLUI_CON_CONSULTA", hs);
        }
    }
}
