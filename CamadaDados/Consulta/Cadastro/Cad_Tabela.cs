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
    #region "TABELA"
    
        public class TList_Cad_Tabela : List<TRegistro_Cad_Tabela>{ }

        public class TRegistro_Cad_Tabela
        {
            public string NM_Tabela { get; set; }
            
            public TRegistro_Cad_Tabela()
            {
                this.NM_Tabela = "";
            }
        }

        public class TCD_Cad_Tabela : TDataQuery
        {
            private string SqlCodeBusca()
            {
                StringBuilder sql;
                sql = new StringBuilder();
                sql.AppendLine("Select name ");
                sql.AppendLine(" FROM sysobjects ");
                sql.AppendLine(" WHERE type = 'U' ");
                sql.AppendLine(" ORDER BY name ASC ");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(), null);
            }

            public TList_Cad_Tabela Select()
            {
                TList_Cad_Tabela lista = new TList_Cad_Tabela();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }
                try
                {
                    reader = ExecutarBusca(SqlCodeBusca());
                    
                    while (reader.Read())
                    {
                        TRegistro_Cad_Tabela reg = new TRegistro_Cad_Tabela();

                        if (!reader.IsDBNull(reader.GetOrdinal("name")))
                            reg.NM_Tabela = reader.GetString(reader.GetOrdinal("name"));

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
        }

    #endregion

    #region "CAMPOS"

        public class TList_Cad_Campo_Tabela : List<TRegistro_Cad_Campo_Tabela> { }

        public class TRegistro_Cad_Campo_Tabela
        {
            public string NM_Campo { get; set; }
            public string NM_Tabela { get; set; }
            public string ST_Existe { get; set; }
            public string Chave_Estrangeira { get; set; }

            public TRegistro_Cad_Campo_Tabela()
            {
                this.NM_Campo = "";
                this.NM_Tabela = "";
                this.ST_Existe = "";
                this.Chave_Estrangeira = "";
            }
        }

        public class TCD_Cad_Campo_Tabela : TDataQuery
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
                sql.AppendLine("Select " + strTop + " so.Name As 'Tabela', sc.Name As 'Campo', ");
                sql.AppendLine(" isNull((select top 1 'S' from tb_con_campos x where x.Alias_Campo = so.Name and x.NM_Campo = sc.Name AND x.ID_Consulta = '" + vNM_Campo + "'), 'N') as 'Existe', ");
                sql.AppendLine(" ISNULL((SELECT TOP 1 'S' ");
                sql.AppendLine(" FROM sysobjects f ");
                sql.AppendLine(" INNER JOIN sysobjects c on  f.parent_obj = c.id ");
                sql.AppendLine(" INNER JOIN sysreferences r on f.id =  r.constid ");
                sql.AppendLine(" INNER JOIN sysobjects p on r.rkeyid = p.id ");
                sql.AppendLine(" INNER JOIN syscolumns rc on r.rkeyid = rc.id and r.rkey1 = rc.colid ");
                sql.AppendLine(" INNER JOIN syscolumns fc on r.fkeyid = fc.id and r.fkey1 = fc.colid ");
                sql.AppendLine(" LEFT JOIN syscolumns rc2 on r.rkeyid = rc2.id and r.rkey2 = rc.colid ");
                sql.AppendLine(" LEFT JOIN syscolumns fc2 on r.fkeyid = fc2.id and r.fkey2 = fc.colid ");
                sql.AppendLine(" WHERE f.type = 'F' ");
                sql.AppendLine(" AND fc.name = sc.Name ");
                sql.AppendLine(" AND c.name = so.Name), 'N') as 'Chave_Estrangeira' ");
                sql.AppendLine(" FROM syscolumns sc ");
                sql.AppendLine(" INNER JOIN sysobjects so ");
                sql.AppendLine(" ON sc.id = so.id ");

                cond = " where ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        cond = " and ";
                    }
                //sql.AppendLine("ORDER BY sc.Name ASC");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public TList_Cad_Campo_Tabela Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Cad_Campo_Tabela lista = new TList_Cad_Campo_Tabela();
                SqlDataReader reader;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }
                try
                {
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                    while (reader.Read())
                    {
                        TRegistro_Cad_Campo_Tabela reg = new TRegistro_Cad_Campo_Tabela();

                        if (!reader.IsDBNull(reader.GetOrdinal("Tabela")))
                            reg.NM_Tabela = reader.GetString(reader.GetOrdinal("Tabela"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Campo")))
                            reg.NM_Campo = reader.GetString(reader.GetOrdinal("Campo"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Existe")))
                            reg.ST_Existe = reader.GetString(reader.GetOrdinal("Existe"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Chave_Estrangeira")))
                            reg.Chave_Estrangeira = reader.GetString(reader.GetOrdinal("Chave_Estrangeira"));

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
        }

    #endregion

    #region "FOREIGN KEY"

        public class TList_Cad_Foreign_Key : List<TRegistro_Cad_Foreign_Key> { }

        public class TRegistro_Cad_Foreign_Key
        {
            public string Tabela_Base { get; set; }
            public string Campo_Base { get; set; }
            public string Tabela_Estrangeiro { get; set; }
            public string Campo_Estrangeiro { get; set; }

            public TRegistro_Cad_Foreign_Key()
            {
                this.Tabela_Base = "";
                this.Campo_Base = "";
                this.Tabela_Estrangeiro = "";
                this.Campo_Estrangeiro = "";
            }
        }

        public class TCD_Cad_Foreign_Key : TDataQuery
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
                sql.AppendLine("Select " + strTop + " c.name as Tabela_Base, fc.name as  Campo_Base, p.name as Tabela_Estrangeiro, rc.name as Campo_Estrangeiro ");
                sql.AppendLine(" FROM sysobjects f ");
                sql.AppendLine(" INNER JOIN sysobjects c on  f.parent_obj = c.id ");
                sql.AppendLine(" INNER JOIN sysreferences r on f.id =  r.constid ");
                sql.AppendLine(" INNER JOIN sysobjects p on r.rkeyid = p.id ");
                sql.AppendLine(" INNER JOIN syscolumns rc on r.rkeyid = rc.id and r.rkey1 = rc.colid ");
                sql.AppendLine(" INNER JOIN syscolumns fc on r.fkeyid = fc.id and r.fkey1 = fc.colid ");
                sql.AppendLine(" LEFT JOIN syscolumns rc2 on r.rkeyid = rc2.id and r.rkey2 = rc.colid ");
                sql.AppendLine(" LEFT JOIN syscolumns fc2 on r.fkeyid = fc2.id and r.fkey2 = fc.colid ");
                sql.AppendLine(" WHERE f.type = 'F' ");

                cond = " and ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        cond = " and ";
                    }
                //sql.AppendLine("ORDER BY sc.Name ASC");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public TList_Cad_Foreign_Key Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_Cad_Foreign_Key lista = new TList_Cad_Foreign_Key();
                SqlDataReader reader;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }
                try
                {
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                    while (reader.Read())
                    {
                        TRegistro_Cad_Foreign_Key reg = new TRegistro_Cad_Foreign_Key();

                        if (!reader.IsDBNull(reader.GetOrdinal("Tabela_Base")))
                            reg.Tabela_Base = reader.GetString(reader.GetOrdinal("Tabela_Base"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Campo_Base")))
                            reg.Campo_Base = reader.GetString(reader.GetOrdinal("Campo_Base"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Tabela_Estrangeiro")))
                            reg.Tabela_Estrangeiro = reader.GetString(reader.GetOrdinal("Tabela_Estrangeiro"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Campo_Estrangeiro")))
                            reg.Campo_Estrangeiro = reader.GetString(reader.GetOrdinal("Campo_Estrangeiro"));

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
        }

    #endregion
}
