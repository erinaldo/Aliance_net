using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Diversos
{
    
    #region tabela
    public class TRegistro_Tabelasbd
    {
        public string nome_tabela { get; set; }
        public TList_Colunasbd lColunas
        { get; set; }
        public TList_Triggers lTriggers { get; set; }

        public TRegistro_Tabelasbd()
        {
            this.nome_tabela = string.Empty;
            this.lColunas = new TList_Colunasbd();
            this.lTriggers = new TList_Triggers();
        }

    }
    public class TList_Tabelasbd : List<TRegistro_Tabelasbd> { }


    public class TCD_Tabelas : TDataQuery
    {
        public TCD_Tabelas()
        { }

        public TCD_Tabelas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT  a.name as TABLE_NAME FROM sys.tables  as a "); //TRIG.name as Trigger_Name,
            sql.AppendLine(" left join [sys].[triggers] as TRIG  on TRIG.parent_id = a.object_id ");
            string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = "  and ";
                    }
                sql.AppendLine("   group by a.name");//order by a.name ASC
            return sql.ToString();
        }

        public TList_Tabelasbd Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_Tabelasbd lista = new TList_Tabelasbd();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));

                while (reader.Read())
                {
                    TRegistro_Tabelasbd reg = new TRegistro_Tabelasbd();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TABLE_NAME"))))
                        reg.nome_tabela = reader.GetString(reader.GetOrdinal("TABLE_NAME"));
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

        public string ExecutarTrigger(TRegistro_Triggers val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            return executarSql(val.trigger_script,null);
        }

        public string DeletarAcesso(TRegistro_CadAcesso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_MENU", val.Id_menu);
            return this.executarProc("EXCLUI_DIV_ACESSO", hs);
        }
         
    }

    #endregion


    #region columns

    public class TRegistro_Columnsbd
    {
        public string nome_coluna { get; set; }
        public string nome_tabela { get; set; }
        public string chave { get; set; }
        public string tipo { get; set; }
        public string tamanho { get; set; }
        public bool st_agregar { get; set; }

        public TRegistro_Columnsbd()
        {
            nome_coluna = string.Empty;
            chave = string.Empty;
            tipo = string.Empty;
            tamanho = string.Empty;
            st_agregar = false;
        }

    }
    public class TList_Colunasbd : List<TRegistro_Columnsbd> { }


    public class TCD_Columnsbd : TDataQuery
    {
        public TCD_Columnsbd()
        { }

        public TCD_Columnsbd(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT isnull(a.character_maximum_length,0) as length, isnull(a.numeric_precision,0) as numeric_precision, isnull(a.numeric_scale,0)as numeric_scale , a.data_type, a.COLUMN_NAME, isnull((SELECT ");
			 sql.AppendLine("			'1'");
	         sql.AppendLine("           FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1");
	         sql.AppendLine("           INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE  ");
			 sql.AppendLine("		   i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME");
	         sql.AppendLine("           WHERE i1.CONSTRAINT_TYPE =  'PRIMARY KEY'   and");
			 sql.AppendLine("		  a.COLUMN_NAME = i2.column_name and");
             sql.AppendLine("		   i1.TABLE_NAME = a.TABLE_NAME GROUP BY  i2.COLUMN_NAME),0) as pk,");
			 sql.AppendLine("		    isnull((SELECT ");
			 sql.AppendLine("			'1'");
	          sql.AppendLine("          FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1");
	          sql.AppendLine("          INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE  ");
			 sql.AppendLine("		   i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME");
	          sql.AppendLine("          WHERE i1.CONSTRAINT_TYPE =  'FOREIGN KEY'   and");
			 sql.AppendLine("		  a.COLUMN_NAME = i2.column_name and");
             sql.AppendLine("		   i1.TABLE_NAME = a.TABLE_NAME GROUP BY i1.CONSTRAINT_TYPE, i2.COLUMN_NAME),0) as fk");
             sql.AppendLine("   FROM INFORMATION_SCHEMA.COLUMNS a");
           //  sql.AppendLine("   where a.data_type = 'numeric' or a.data_type = 'varchar' or a.data_type = 'decimal' or a.data_type = 'text' or a.data_type = 'int'   or a.data_type = 'datetime'  or a.data_type = 'char' ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine(" order by pk desc, fk desc");
            return sql.ToString();
        }

        public TList_Colunasbd Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_Colunasbd lista = new TList_Colunasbd();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            string pk = string.Empty, fk = string.Empty, lgm = string.Empty, lgr = string.Empty;
            int tamanho = 0;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));

                while (reader.Read())
                {
                    TRegistro_Columnsbd reg = new TRegistro_Columnsbd();
                    if (!(reader.IsDBNull(reader.GetOrdinal("COLUMN_NAME"))))
                        reg.nome_coluna = reader.GetString(reader.GetOrdinal("COLUMN_NAME"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PK"))) || !(reader.IsDBNull(reader.GetOrdinal("FK"))))
                    {
                        pk = reader.GetString(reader.GetOrdinal("PK"));
                        fk = reader.GetString(reader.GetOrdinal("FK"));
                        if (pk == fk && !pk.Equals("0") && !fk.Equals("0"))
                            reg.chave = "PFK";
                        else if (!pk.Equals("0"))
                            reg.chave = "PK";
                        else if (!fk.Equals("0"))
                            reg.chave = "FK";
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("data_type"))))
                        reg.tipo = reader.GetString(reader.GetOrdinal("data_type"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("length"))) || !(reader.IsDBNull(reader.GetOrdinal("numeric_precision")))
                        || !(reader.IsDBNull(reader.GetOrdinal("numeric_scale"))))
                    {
                        tamanho = reader.GetInt32(reader.GetOrdinal("length"));
                        lgm = reader.GetByte(reader.GetOrdinal("numeric_precision")).ToString();
                        lgr = reader.GetInt32(reader.GetOrdinal("numeric_scale")).ToString();
                        if (!string.IsNullOrEmpty(lgm.ToString()) && !lgm.Equals("0") && !string.IsNullOrEmpty(lgr.ToString()))
                            reg.tamanho = "("+lgm+","+lgr+")";
                        else if (!string.IsNullOrEmpty(tamanho.ToString()) && !tamanho.Equals("0"))
                            reg.tamanho = "("+tamanho+")";

                         
                    }
                    if (reg.tipo.Equals("varchar") || reg.tipo.Equals("char") || reg.tipo.Equals("image") || reg.tipo.Equals("numeric") || reg.tipo.Equals("decimal") || reg.tipo.Equals("datetime") || reg.tipo.Equals("int"))
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

        public string GravarAcesso(TRegistro_CadAcesso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_MENU", val.Id_menu);
            hs.Add("@P_INCLUI", val.Inclui);
            hs.Add("@P_ALTERA", val.Altera);
            hs.Add("@P_EXCLUI", val.Exclui);
            hs.Add("@P_QTD_ACESSO", val.Qtd_acesso);
            return executarProc("IA_DIV_ACESSO", hs);
        }

        public string DeletarAcesso(TRegistro_CadAcesso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_MENU", val.Id_menu);
            return this.executarProc("EXCLUI_DIV_ACESSO", hs);
        }

    }

    #endregion


    #region triggers

    public class TRegistro_Triggers
    {
        public string trigger_nome { get; set; }
        public bool st_ativo { get; set; }
        public string trigger_script { get; set; }
        public string table_nome { get; set; }
        public string ativo { get; set; }
        public TList_Colunasbd lColunas { get; set; }

        public TRegistro_Triggers()
        {
            trigger_nome = string.Empty;
            trigger_script = string.Empty;
            table_nome = string.Empty;
            ativo = string.Empty;
            st_ativo = false;
            lColunas = new TList_Colunasbd();
        }

    }
    public class TList_Triggers : List<TRegistro_Triggers> { }

    public class TCD_Triggers : TDataQuery
    {
        public TCD_Triggers()
        { }

        public TCD_Triggers(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT  m.definition, TAB.name as Table_Name , TRIG.name as Trigger_Name, TRIG.is_disabled  FROM [sys].[triggers] as TRIG inner join sys.tables as TAB on TRIG.parent_id = TAB.object_id ");
            sql.AppendLine(" join  sys.sql_modules m on trig.object_id = m.object_id");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public TList_Triggers Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_Triggers lista = new TList_Triggers();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));

                while (reader.Read())
                {
                    CamadaDados.Diversos.TRegistro_Triggers reg = new CamadaDados.Diversos.TRegistro_Triggers();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Trigger_Name"))))
                        reg.trigger_nome = reader.GetString(reader.GetOrdinal("Trigger_Name"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("definition"))))
                        reg.trigger_script = reader.GetString(reader.GetOrdinal("definition"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("is_disabled"))))
                        reg.st_ativo = !reader.GetBoolean(reader.GetOrdinal("is_disabled"));
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

        public string ExecutarTrigger(string val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable();
            return executarSql(val, hs);
        }

        public string Deleta(string val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(0);
            //hs.Add("@P_LOGIN", val.Login);
            //hs.Add("@P_ID_MENU", val.Id_menu);
            return this.executarSql(val, hs);
        }
        public string Desativar(TRegistro_Triggers val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(0);
           

            string a = " alter table "+val.table_nome+" "+val.ativo+" trigger "+val.trigger_nome+"";
            return this.executarSql(a, hs);
        }
    }

    #endregion





    #region auditcolum
    public class TRegistro_Colunas
    {
        public decimal id_coluna { get; set; } = decimal.Zero;
        public string nm_tabela { get; set; } = string.Empty;
        public string nm_coluna { get; set; } = string.Empty;
        public string ds_coluna { get; set; } = string.Empty;


    }
    public class TList_Colunas : List<TRegistro_Colunas> { }

    public class TCD_Colunas : TDataQuery
    {
        public TCD_Colunas()
        { }

        public TCD_Colunas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("SELECT  A.ID_COLUNA, A.NM_COLUNA, A.DS_COLUNA, A.NM_TABELA "); //TRIG.name as Trigger_Name,
            else
                sql.AppendLine("select top 1 " + vNM_Campo );
            sql.AppendLine(" FROM TB_DIV_AuditColunas A ");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
           // sql.AppendLine("   group by a.ID_COLUNA");//order by a.name ASC
            return sql.ToString();
            }

        public TList_Colunas Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_Colunas lista = new TList_Colunas();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));

                while (reader.Read())
                {
                    TRegistro_Colunas reg = new TRegistro_Colunas();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_coluna"))))
                        reg.id_coluna = reader.GetDecimal(reader.GetOrdinal("id_coluna"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_coluna"))))
                        reg.ds_coluna = reader.GetString(reader.GetOrdinal("ds_coluna"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_coluna"))))
                        reg.nm_coluna = reader.GetString(reader.GetOrdinal("nm_coluna"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_tabela"))))
                        reg.nm_tabela = reader.GetString(reader.GetOrdinal("nm_tabela"));
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

        public string Gravar(TRegistro_Colunas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_COLUNA", val.id_coluna);
            hs.Add("@P_NM_COLUNA", val.nm_coluna);
            hs.Add("@P_DS_COLUNA", val.ds_coluna);
            hs.Add("@P_NM_TABELA", val.nm_tabela);
            return this.executarProc("IA_DIV_AUDITCOLUNAS", hs);
        }

        public string Excluir(TRegistro_Colunas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_COLUNA", val.id_coluna);
            return this.executarProc("EXCLUI_DIV_AUDITCOLUNAS", hs);
        }

    }


    #endregion

}
