using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
        public class TList_CadDescontoxProduto : List<TRegistro_CadDescontoxProduto>
        {
        }

    
        public class TRegistro_CadDescontoxProduto
        {
        
            public string Cd_TabelaDesconto{get;set;}
        
            public string Ds_tabeladesconto{ get;set;}
         
            public string Cd_Produto{get;set;}
        
            public string Ds_produto{get; set;}
        
            public string St_Registro{ get; set;}

            public TRegistro_CadDescontoxProduto()
            {
                this.Cd_TabelaDesconto = string.Empty;
                this.Ds_tabeladesconto = string.Empty;
                this.Cd_Produto = string.Empty;
                this.Ds_produto = string.Empty;
                this. St_Registro = "A";
            }
        }

        public class TCD_CadDescontoxProdutos : TDataQuery
        {
            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = string.Empty;
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (string.IsNullOrEmpty(vNM_Campo))
                {
                    sql.AppendLine(" SELECT " + strTop + "a.cd_tabeladesconto, a.cd_produto, a.st_registro, ");
                    sql.AppendLine("b.ds_tabeladesconto ,c.ds_produto ");
                    
                }
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine(" FROM tb_gro_descontoxproduto a ");
                sql.AppendLine("inner join tb_gro_tabeladesconto b ");
                sql.AppendLine("on a.cd_tabeladesconto = b.cd_tabeladesconto ");
                sql.AppendLine("inner join tb_est_Produto c");
                sql.AppendLine("on c.cd_produto = a.cd_produto");

                string cond = " where ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
                sql.AppendLine("Order By a.cd_tabeladesconto asc");
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
            }

            public TList_CadDescontoxProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_CadDescontoxProduto lista = new TList_CadDescontoxProduto();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    while (reader.Read())
                    {
                        TRegistro_CadDescontoxProduto reg = new TRegistro_CadDescontoxProduto();
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                            reg.Cd_TabelaDesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                            reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                            reg.Cd_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                            reg.Ds_produto = (reader.GetString(reader.GetOrdinal("ds_produto")));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                            reg.St_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
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

            public string Grava(TRegistro_CadDescontoxProduto vRegistro)
            {
                Hashtable hs = new Hashtable(3);
                hs.Add("@P_CD_TABELADESCONTO", vRegistro.Cd_TabelaDesconto);
                hs.Add("@P_CD_PRODUTO", vRegistro.Cd_Produto);
                hs.Add("@P_ST_REGISTRO", vRegistro.St_Registro);
                return this.executarProc("IA_GRO_DESCONTOXPRODUTO", hs);
            }

            public string Deleta(TRegistro_CadDescontoxProduto vRegistro)
            {
                Hashtable hs = new Hashtable(2);
                hs.Add("@P_CD_TABELADESCONTO", vRegistro.Cd_TabelaDesconto);
                hs.Add("@P_CD_PRODUTO", vRegistro.Cd_Produto);
                return this.executarProc("EXCLUI_GRO_DESCONTOXPRODUTO", hs);
            }

        }
}
