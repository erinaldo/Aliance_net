using System;
using System.Collections;
using System.Data;
using BancoDados;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados
{

    public class TDataQuery
    {
        private TObjetoBanco pBanco_Dados;
        
        private string pNM_Procedure;

        public string NM_ProcSqlBusca { get { return pNM_Procedure; } set { pNM_Procedure = value; } }

        public TObjetoBanco Banco_Dados { get { return pBanco_Dados; } set { pBanco_Dados = value; } }

        public TDataQuery()
        {
            NM_ProcSqlBusca = string.Empty;
        }

        public TDataQuery(TObjetoBanco banco)
        {
            NM_ProcSqlBusca = string.Empty;
            Banco_Dados = banco;
        }

        public string executarSql(string vComando, Hashtable parametros)
        {
            bool pode_liberar;
            string p = string.Empty;
            string vRetorno = string.Empty;
            if (pBanco_Dados == null)
            {
                pode_liberar = true;
                pBanco_Dados = new TObjetoBanco();
                pBanco_Dados.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                pBanco_Dados.Conexao.Open();
                pBanco_Dados.CriarComando();
            }
            else
            {
                pode_liberar = false;
                if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                    pBanco_Dados.Conexao.Open();
                pBanco_Dados.Comando.Parameters.Clear();
            }

            pBanco_Dados.Comando.CommandType = CommandType.Text;
            pBanco_Dados.Comando.CommandText = vComando;
            try
            {
                if (parametros != null)
                    pBanco_Dados.preencherParametrosBusca(parametros);
                pBanco_Dados.Comando.ExecuteNonQuery();
                for (int i = 0; i <= pBanco_Dados.Comando.Parameters.Count - 1; i++)
                {
                    if (pBanco_Dados.Comando.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        vRetorno += p +
                                    pBanco_Dados.Comando.Parameters[i].ParameterName + ":" +
                                    pBanco_Dados.Comando.Parameters[i].Value.ToString();
                        p = "|";
                    }
                }
                return vRetorno;
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

        public object executarEscalar(string vQuery, Hashtable Parametros)
        {
            return ExecutarBuscaEscalar(vQuery, Parametros);
        }
        
        public string executarProc( string nmProcedure, Hashtable parametros )
        {
            bool pode_liberar = false;

            if (pBanco_Dados == null) 
            {
              pode_liberar = true;
              pBanco_Dados = new TObjetoBanco();
              pBanco_Dados.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
              pBanco_Dados.Conexao.Open();
              pBanco_Dados.CriarComando();
              pBanco_Dados.Comando.CommandText = nmProcedure.ToUpper();
            }
            else 
            {
              pode_liberar = false;
              if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                  pBanco_Dados.Conexao.Open();
              pBanco_Dados.Comando.CommandType = CommandType.StoredProcedure;
              pBanco_Dados.Comando.CommandText = nmProcedure.ToUpper();
            }
            try
            {
                if (parametros != null)
                {
                    pBanco_Dados.preencherParametros(parametros);
                }
                pBanco_Dados.Comando.ExecuteNonQuery();
                string p = string.Empty;
                string vRetorno = string.Empty;
                foreach (SqlParameter parametro in pBanco_Dados.Comando.Parameters)
                {
                    if (parametro.Direction.Equals(ParameterDirection.InputOutput) ||
                        parametro.Direction.Equals(ParameterDirection.ReturnValue))
                    {
                        vRetorno += p +
                                    parametro.ParameterName + ":" + parametro.Value.ToString();
                        p = "|";
                    }
                }
                return vRetorno;
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

        public SqlDataReader executarProcReader(string nmProcedure, Hashtable parametros)
        {
            bool pode_liberar = false;
            if (pBanco_Dados == null)
            {
                pode_liberar = true;
                pBanco_Dados = new TObjetoBanco();
                pBanco_Dados.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                pBanco_Dados.Conexao.Open();
                pBanco_Dados.CriarComando();
                pBanco_Dados.Comando.CommandText = nmProcedure.ToUpper();
            }
            else
            {
                pode_liberar = false;
                if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                    pBanco_Dados.Conexao.Open();
                pBanco_Dados.Comando.CommandType = CommandType.StoredProcedure;
                pBanco_Dados.Comando.CommandText = nmProcedure.ToUpper();
            }
            try
            {
                if (parametros != null)
                    pBanco_Dados.preencherParametros(parametros);
                return pBanco_Dados.Comando.ExecuteReader();
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

        public DataTable ExecutarBusca(string vSQLCode, Hashtable Parametros)
        {
            bool pode_liberar = false;
            if (pBanco_Dados == null) 
            {
                pode_liberar = true;
                pBanco_Dados = new TObjetoBanco();
                pBanco_Dados.CriarObjetosBanco(Utils.Parametros.pubLogin, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
                pBanco_Dados.Comando.CommandType = CommandType.Text;
                pBanco_Dados.Comando.CommandText = vSQLCode;
                pBanco_Dados.Conexao.Open();
            }
            else 
            {
                if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                    pBanco_Dados.Conexao.Open();
                pBanco_Dados.Comando.CommandType = CommandType.Text;
                pBanco_Dados.Comando.CommandText = vSQLCode;
                pBanco_Dados.CriarAdapter(true);
            }
            try 
            {
                if (Parametros != null)
                    pBanco_Dados.preencherParametrosBusca(Parametros);
                DataTable dt = new DataTable();
                
                pBanco_Dados.Adapter.Fill(dt);
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

        protected SqlDataReader ExecutarBuscaReader(string vSQLCode, Hashtable Parametros)
        {
            if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                pBanco_Dados.Conexao.Open();
            pBanco_Dados.Comando.CommandType = CommandType.Text;
            pBanco_Dados.Comando.CommandText = vSQLCode;
            if (Parametros != null)

                pBanco_Dados.preencherParametrosBusca(Parametros);
            return pBanco_Dados.Comando.ExecuteReader();
        }

        protected SqlDataReader ExecutarBusca(string vSQLCode)
        {
            if (pBanco_Dados.Conexao.State == ConnectionState.Closed)
                pBanco_Dados.Conexao.Open();
            
            pBanco_Dados.Comando.CommandType = CommandType.Text;
            pBanco_Dados.Comando.CommandText = vSQLCode;
            
            return pBanco_Dados.Comando.ExecuteReader();
        }
        
        protected virtual object ExecutarBuscaEscalar(string vSQLCode, Hashtable Parametros) 
        {
            bool pode_liberar;
            if (pBanco_Dados == null) 
            {
               pode_liberar = true;
               pBanco_Dados = new TObjetoBanco();
               pBanco_Dados.CriarObjetosBanco(Utils.Parametros.pubLogin, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
               pBanco_Dados.Comando.CommandType = CommandType.Text;
               pBanco_Dados.Comando.CommandText = vSQLCode;
               pBanco_Dados.Conexao.Open();
            }
            else
            {
              pode_liberar = false;
              if (pBanco_Dados.Conexao.State == ConnectionState.Closed) 
                  pBanco_Dados.Conexao.Open();
              pBanco_Dados.Comando.CommandType = CommandType.Text;
              pBanco_Dados.Comando.CommandText = vSQLCode;
            }
            try
            {
                if (Parametros != null)
                    pBanco_Dados.preencherParametrosBusca(Parametros);
                return pBanco_Dados.Comando.ExecuteScalar();
            }
            catch(Exception ex)
            {
                return null;
            }
            finally {
               if (pode_liberar) 
               {
                 pBanco_Dados.Conexao.Close();
                 pBanco_Dados = null;
               }
            }
        }

        public static string getPubVariavel(string vStr, string vChave)
        {
            if ((vStr == null) || (vChave == null))
                return string.Empty;
            if ((vStr.Length > 0) && (vChave.Length > 0))
            {
                string[] vAux1 = vStr.Split('|');
                for (Int16 i = 0; i < vAux1.Length; i++)
                {
                    string[] vAux2 = vAux1[i].Split(':');
                    if (vAux2[0].Trim().ToUpper() == vChave.Trim().ToUpper())
                        return vAux2[1].Trim(); 
                }
                return string.Empty;
            }
            else return string.Empty;
        }

        public virtual DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return null;
        }

        public virtual DataTable Buscar(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            return null;
        }

        public virtual DataTable Buscar(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return null;
        }

        public virtual object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return null;
        }

        public virtual object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return null;
        }
        
        public bool CriarBanco_Dados(bool vStartTran) 
        {
            try
            {
                pBanco_Dados = new TObjetoBanco();
                pBanco_Dados.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                pBanco_Dados.CriarComando();
                pBanco_Dados.Conexao.Open();
                if (vStartTran)
                {
                    pBanco_Dados.Start_Tran(IsolationLevel.ReadCommitted);
                    pBanco_Dados.Comando.Transaction = pBanco_Dados.Transac;
                }
                return true;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        public bool CriarBanco_Dados(bool vStartTran, IsolationLevel isolation)
        {
            try
            {
                pBanco_Dados = new TObjetoBanco();
                pBanco_Dados.CriarConexao(Parametros.pubLogin, Parametros.pubNM_Servidor, Parametros.pubNM_BancoDados);
                pBanco_Dados.CriarComando();
                pBanco_Dados.Conexao.Open();
                if (vStartTran)
                {
                    pBanco_Dados.Start_Tran(isolation);
                    pBanco_Dados.Comando.Transaction = pBanco_Dados.Transac;
                }
                return true;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message.Trim()); }
        }

        public void deletarBanco_Dados() 
        {
            if (pBanco_Dados.Conexao.State == ConnectionState.Open)
              pBanco_Dados.Conexao.Close();
            pBanco_Dados = null;
        }
    }
}
