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
    public class TList_Cad_Amarracoes : List<TRegistro_Cad_Amarracoes>{ }

    public class TRegistro_Cad_Amarracoes
    {
        public decimal ID_Amarracoes { get; set; }
        public string ID_Consulta { get; set; }
        public decimal ID_Tipo_Amarracao { get; set; }
        public string NM_Tabela { get; set; }
        public string ST_Principal { get; set; }
        
        public TRegistro_Cad_Amarracoes()
        {
            this.ID_Amarracoes = 0;
            this.ID_Consulta = "";
            this.ID_Tipo_Amarracao = 0;
            this.NM_Tabela = "";
            this.ST_Principal = "N";
        }
    }

    public class TCD_Cad_Amarracoes : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Amarracoes, a.ID_Consulta, a.ID_Tipo_Amarracao, a.NM_Tabela, a.ST_Principal ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_amarracoes a ");

            cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.st_principal desc, a.NM_Tabela ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_Cad_Amarracoes Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Amarracoes lista = new TList_Cad_Amarracoes();
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
                    TRegistro_Cad_Amarracoes reg = new TRegistro_Cad_Amarracoes();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Amarracoes")))
                        reg.ID_Amarracoes = reader.GetDecimal(reader.GetOrdinal("ID_Amarracoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Consulta")))
                        reg.ID_Consulta = reader.GetString(reader.GetOrdinal("ID_Consulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Tipo_Amarracao")))
                        reg.ID_Tipo_Amarracao = reader.GetDecimal(reader.GetOrdinal("ID_Tipo_Amarracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tabela")))
                        reg.NM_Tabela = reader.GetString(reader.GetOrdinal("NM_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Principal")))
                        reg.ST_Principal = reader.GetString(reader.GetOrdinal("ST_Principal"));

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

        public string Grava(TRegistro_Cad_Amarracoes val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_AMARRACOES", val.ID_Amarracoes);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            if (val.ID_Tipo_Amarracao > 0)
            {
                hs.Add("@P_TIPO_AMARRACAO", val.ID_Tipo_Amarracao);
            }
            else
            {
                hs.Add("@P_TIPO_AMARRACAO", null);
            }
            hs.Add("@P_NM_TABELA", val.NM_Tabela);
            hs.Add("@P_ST_PRINCIPAL", val.ST_Principal);
            return executarProc("IA_CON_AMARRACOES", hs);
        }

        public string Deleta(TRegistro_Cad_Amarracoes val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_AMARRACOES", val.ID_Amarracoes);
            return executarProc("EXCLUI_CON_AMARRACOES", hs);
        }

        public string AlteraTodosStatus(TRegistro_Cad_Amarracoes val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            hs.Add("@P_ST_PRINCIPAL", val.ST_Principal);
            return executarProc("DESMARCA_TABELA_PRINCIPAL", hs);
        }

        public string DeletaPorConsulta(string ID_Consulta)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONSULTA", ID_Consulta);
            return executarProc("EXCLUI_CON_AMARRACOESPORCONSULTA", hs);
        }
    }
}

