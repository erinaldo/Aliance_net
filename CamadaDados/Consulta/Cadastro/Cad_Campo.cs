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
    public class TList_Cad_Campo : List<TRegistro_Cad_Campo> { }

    public class TRegistro_Cad_Campo
    {
        public decimal ID_Campo { get; set; }
        public string ID_Consulta { get; set; }
        public string Alias_Campo { get; set; }
        public string NM_Campo { get; set; }

        public TRegistro_Cad_Campo()
        {
            this.ID_Campo = 0;
            this.ID_Consulta = "";
            this.NM_Campo = "";
            this.Alias_Campo = "";
        }
    }

    public class TCD_Cad_Campo : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Campo, a.ID_Consulta, a.NM_Campo, a.Alias_Campo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_Campos a ");
            
            cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.NM_Campo ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_Cad_Campo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Campo lista = new TList_Cad_Campo();
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
                    TRegistro_Cad_Campo reg = new TRegistro_Cad_Campo();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Campo")))
                        reg.ID_Campo = reader.GetDecimal(reader.GetOrdinal("ID_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Campo")))
                        reg.NM_Campo = reader.GetString(reader.GetOrdinal("NM_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Consulta")))
                        reg.ID_Consulta = reader.GetString(reader.GetOrdinal("ID_Consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Alias_Campo")))
                        reg.Alias_Campo = reader.GetString(reader.GetOrdinal("Alias_Campo"));

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

        public string Grava(TRegistro_Cad_Campo val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_CAMPO", val.ID_Campo);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            hs.Add("@P_NM_CAMPO", val.NM_Campo);
            hs.Add("@P_ALIAS_CAMPO", val.Alias_Campo);
            return executarProc("IA_CON_CAMPOS", hs);
        }
        
        public string Deleta(TRegistro_Cad_Campo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CAMPO", val.ID_Campo);
            return executarProc("EXCLUI_CON_CAMPOS", hs);
        }

        public string DeletaTodos(string vID_Consulta)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", vID_Consulta);
            return executarProc("EXCLUI_CON_TODOSCAMPOS", hs);
        }
    }
}
