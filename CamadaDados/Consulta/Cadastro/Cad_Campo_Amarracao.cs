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
    public class TList_Cad_Campo_Amarracao : List<TRegistro_Cad_Campo_Amarracao> { }

    public class TRegistro_Cad_Campo_Amarracao
    {
        public decimal ID_Campo_Amarracao { get; set; }
        public decimal ID_Amarracoes { get; set; }
        public string Campo_Base  { get; set; }
        public string Campo_Estrangeiro { get; set; }
        public string NM_Tabela_Base { get; set; }
        public string NM_Tabela_Estrangeiro { get; set; }

        public TRegistro_Cad_Campo_Amarracao()
        {
            this.ID_Campo_Amarracao = 0;
            this.ID_Amarracoes = 0;
            this.Campo_Base = "";
            this.Campo_Estrangeiro = "";
            this.NM_Tabela_Base = "";
            this.NM_Tabela_Estrangeiro = "";
        }
    }

    public class TCD_Cad_Campo_Amarracao : TDataQuery
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
                sql.AppendLine("Select " + strTop + " a.ID_Campo_Amarracao, a.ID_Amarracoes, a.Campo_Base, a.Campo_Estrangeiro, a.Alias_Campo_Base, a.Alias_Campo_Estrangeiro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_con_campo_amarracao a ");
            sql.AppendLine(" inner join tb_con_amarracoes b on a.id_amarracoes = b.id_amarracoes ");
            
            cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("ORDER BY a.Campo_Base, a.Campo_Estrangeiro ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_Cad_Campo_Amarracao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_Campo_Amarracao lista = new TList_Cad_Campo_Amarracao();
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
                    TRegistro_Cad_Campo_Amarracao reg = new TRegistro_Cad_Campo_Amarracao();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Campo_Amarracao")))
                        reg.ID_Campo_Amarracao = reader.GetDecimal(reader.GetOrdinal("ID_Campo_Amarracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Amarracoes")))
                        reg.ID_Amarracoes = reader.GetDecimal(reader.GetOrdinal("ID_Amarracoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Campo_Base")))
                        reg.Campo_Base = reader.GetString(reader.GetOrdinal("Campo_Base"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Campo_Estrangeiro")))
                        reg.Campo_Estrangeiro = reader.GetString(reader.GetOrdinal("Campo_Estrangeiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Alias_Campo_Base")))
                        reg.NM_Tabela_Base = reader.GetString(reader.GetOrdinal("Alias_Campo_Base"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Alias_Campo_Estrangeiro")))
                        reg.NM_Tabela_Estrangeiro = reader.GetString(reader.GetOrdinal("Alias_Campo_Estrangeiro"));

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

        public string Grava(TRegistro_Cad_Campo_Amarracao val)
        {
            Hashtable hs = new Hashtable(7);

            hs.Add("@P_ID_CAMPO_AMARRACAO", val.ID_Campo_Amarracao);
            hs.Add("@P_ID_AMARRACOES", val.ID_Amarracoes);
            hs.Add("@P_ALIAS_CAMPO_BASE", val.NM_Tabela_Base);
            hs.Add("@P_CAMPO_BASE", val.Campo_Base);
            hs.Add("@P_ALIAS_CAMPO_ESTRANGEIRO", val.NM_Tabela_Estrangeiro);
            hs.Add("@P_CAMPO_ESTRANGEIRO", val.Campo_Estrangeiro);
            return executarProc("IA_CON_CAMPO_AMARRACAO", hs);
        }

        public string Deleta(TRegistro_Cad_Campo_Amarracao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CAMPO_AMARRACAO", val.ID_Campo_Amarracao);
            return executarProc("EXCLUI_CON_CAMPO_AMARRACAO", hs);
        }

        public string DeletaPorAmarracoes(decimal ID_Amarracoes)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_AMARRACOES", ID_Amarracoes);
            return executarProc("EXCLUI_CON_CAMPOAMARRACAOPORAMARRACOES", hs);
        }
    }
}
