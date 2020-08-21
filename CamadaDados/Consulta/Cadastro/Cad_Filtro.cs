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
    public class TList_Cad_Filtro : List<TRegistro_Cad_Filtro> { }

    public class TRegistro_Cad_Filtro
    {
        public decimal ID_Filtro { get; set; }
        public string ID_Consulta { get; set; }
        public decimal ID_Operador { get; set; }
        public decimal ID_ParamClasse { get; set; }
        public string NM_Campo { get; set; }
        public string Alias_Campo { get; set; }
        public string ST_Ligacao { get; set; }

        public TRegistro_Cad_Filtro()
        {
            this.ID_Filtro = 0;
            this.ID_Consulta = "";
            this.ID_Operador = 0;
            this.ID_ParamClasse = 0;
            this.NM_Campo = "";
            this.Alias_Campo = "";
            this.ST_Ligacao = "";
        }
    }

    public class TCD_Cad_Filtro : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Filtro, a.ID_Consulta, a.ID_Operador, a.NM_Campo, a.Alias_Campo, a.ST_Ligacao, a.ID_ParamClasse ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_Filtro a ");

            cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.ID_Filtro ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_Cad_Filtro Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Filtro lista = new TList_Cad_Filtro();
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
                    TRegistro_Cad_Filtro reg = new TRegistro_Cad_Filtro();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Filtro")))
                        reg.ID_Filtro = reader.GetDecimal(reader.GetOrdinal("ID_Filtro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Consulta")))
                        reg.ID_Consulta = reader.GetString(reader.GetOrdinal("ID_Consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Operador")))
                        reg.ID_Operador = reader.GetDecimal(reader.GetOrdinal("ID_Operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Campo")))
                        reg.NM_Campo = reader.GetString(reader.GetOrdinal("NM_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Alias_Campo")))
                        reg.Alias_Campo = reader.GetString(reader.GetOrdinal("Alias_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Ligacao")))
                        reg.ST_Ligacao = reader.GetString(reader.GetOrdinal("ST_Ligacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ParamClasse")))
                        reg.ID_ParamClasse = reader.GetDecimal(reader.GetOrdinal("ID_ParamClasse"));

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

        public string Grava(TRegistro_Cad_Filtro val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_FILTRO", val.ID_Filtro);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            hs.Add("@P_ID_OPERADOR", val.ID_Operador);
            hs.Add("@P_ID_PARAMCLASSE", val.ID_ParamClasse);
            hs.Add("@P_NM_CAMPO", val.NM_Campo);
            hs.Add("@P_ALIAS_CAMPO", val.Alias_Campo);
            hs.Add("@P_ST_LIGACAO", val.ST_Ligacao);
            return executarProc("IA_CON_FILTRO", hs);
        }

        public string Deleta(TRegistro_Cad_Filtro val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_FILTRO", val.ID_Filtro);
            return executarProc("EXCLUI_CON_FILTRO", hs);
        }

        public string DeletaPorConsulta(string ID_Consulta)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", ID_Consulta);
            return executarProc("EXCLUI_CON_FILTROPORCONSULTA", hs);
        }
    }
}
