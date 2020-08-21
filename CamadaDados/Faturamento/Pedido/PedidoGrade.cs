using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Faturamento.Pedido
{
    public class TRegistro_PedidoGrade
    {
        public string cd_produto { get; set; } = string.Empty;
        public decimal? nr_pedido { get; set; } = null;
        public decimal? nr_pedidoItem { get; set; } = null;
        public decimal id_caracteristica { get; set; } = decimal.Zero;
        public decimal id_item { get; set; } = decimal.Zero;
        public decimal quantidade { get; set; } = decimal.Zero; 
    }

    public class TList_PedidoGrade : List<TRegistro_PedidoGrade> { }


    public class TCD_PedidoGrade : TDataQuery
    {
        public TCD_PedidoGrade() { }

        public TCD_PedidoGrade(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_pedido,a.cd_produto,a.id_pedidoitem,a.id_caracteristica,a.id_item,a.quantidade "); 
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_PedidoGrade a "); 


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PedidoGrade Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PedidoGrade lista = new TList_PedidoGrade();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PedidoGrade reg = new TRegistro_PedidoGrade();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristica")))
                        reg.id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_pedidoItem")))
                        reg.nr_pedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_pedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }
        public string Gravar(TRegistro_PedidoGrade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_PRODUTO", val.cd_produto);
            hs.Add("@P_ID_CARACTERISTICA", val.id_caracteristica);
            hs.Add("@P_ID_ITEM", val.id_item);
            hs.Add("@P_NR_PEDIDO", val.nr_pedido);
            hs.Add("@P_ID_PEDIDOITEM", val.nr_pedidoItem);
            hs.Add("@P_QUANTIDADE", val.quantidade); 

            return executarProc("IA_FAT_PEDIDOGRADE", hs);
        }
        public string Excluir(TRegistro_PedidoGrade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_PRODUTO", val.cd_produto);
            hs.Add("@P_ID_CATACTERISTICA", val.id_caracteristica);
            hs.Add("@P_ID_ITEM", val.id_item);
            hs.Add("@P_NR_PEDIDO", val.nr_pedido);
            hs.Add("@P_NR_PEDIDOITEM", val.nr_pedidoItem); 

            return executarProc("EXCLUI_FAT_PEDIDOGRADE", hs);
        }
    }


}
