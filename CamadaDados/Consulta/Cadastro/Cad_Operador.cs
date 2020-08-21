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
    public class TList_Cad_Operador : List<TRegistro_Cad_Operador>{ }

    public class TRegistro_Cad_Operador
    {
        private string _ID_Operador;
        public decimal ID_Operador { 
            get {

                try
                {
                    return Decimal.Parse(this._ID_Operador);
                }
                catch { 
                    return 0;
                }
            } 
            set {
                this._ID_Operador = value.ToString();
            }
        }

        public string ID_Operador_str { 
            get{
                return this._ID_Operador;
            } 
            set{
                try
                {
                    this._ID_Operador = Decimal.Parse(value).ToString();
                }
                catch { 
                    this._ID_Operador= null;
                }
            } 
        }

        public string NM_Operador { get; set; }
        public string Sigla_Operador { get; set; }
        
        public TRegistro_Cad_Operador()
        {
            this.ID_Operador = 0;
            this.NM_Operador = "";
            this._ID_Operador = null;
        }
    }

    public class TCD_Cad_Operador : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Operador, a.NM_Operador, a.Sigla_Operador ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_operador a ");
            sql.AppendLine(" where a.st_registro = 'A' ");

            cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.NM_Operador ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_Operador Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Operador lista = new TList_Cad_Operador();
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
                    TRegistro_Cad_Operador reg = new TRegistro_Cad_Operador();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Operador")))
                        reg.ID_Operador = reader.GetDecimal(reader.GetOrdinal("ID_Operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Operador")))
                        reg.NM_Operador = reader.GetString(reader.GetOrdinal("NM_Operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Operador")))
                        reg.Sigla_Operador = reader.GetString(reader.GetOrdinal("Sigla_Operador"));

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

        public string Grava(TRegistro_Cad_Operador val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OPERADOR", val.ID_Operador_str);
            hs.Add("@P_NM_OPERADOR", val.NM_Operador);
            hs.Add("@P_SIGLA_OPERADOR", val.Sigla_Operador);
            return executarProc("IA_CON_OPERADOR", hs);
        }

        public string Deleta(TRegistro_Cad_Operador val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_OPERADOR", val.ID_Operador);
            return executarProc("EXCLUI_CON_Operador", hs);
        }
    }
}
