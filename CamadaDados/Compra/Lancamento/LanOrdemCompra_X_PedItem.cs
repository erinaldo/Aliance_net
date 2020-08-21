using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_OrdemCompra_X_PedItem : List<TRegistro_OrdemCompra_X_PedItem>
    { }

    
    public class TRegistro_OrdemCompra_X_PedItem
    {
        
        public decimal? Id_oc
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public decimal? Id_pedidoitem
        { get; set; }

        public TRegistro_OrdemCompra_X_PedItem()
        {
            this.Id_oc = null;
            this.Nr_pedido = null;
            this.Cd_produto = string.Empty;
            this.Id_pedidoitem = null;
        }
    }

    public class TCD_OrdemCompra_X_PedItem : TDataQuery
    {
        public TCD_OrdemCompra_X_PedItem()
        { }

        public TCD_OrdemCompra_X_PedItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.id_oc, a.nr_pedido, a.cd_produto, a.id_pedidoitem ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_ordemcompra_x_peditem a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OrdemCompra_X_PedItem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OrdemCompra_X_PedItem lista = new TList_OrdemCompra_X_PedItem();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemCompra_X_PedItem reg = new TRegistro_OrdemCompra_X_PedItem();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OC"))))
                        reg.Id_oc = reader.GetDecimal(reader.GetOrdinal("ID_OC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem"))))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));

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

        public string GravarOC_XPedItem(TRegistro_OrdemCompra_X_PedItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_OC", val.Id_oc);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("IA_CMP_ORDEMCOMPRA_X_PEDITEM", hs);
        }

        public string DeletarOC_X_PedItem(TRegistro_OrdemCompra_X_PedItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_OC", val.Id_oc);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("EXCLUI_CMP_ORDEMCOMPRA_X_PEDITEM", hs);
        }
    }
}
