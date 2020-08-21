using System;
using System.Collections.Generic;
using System.Text;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CamadaDados;


namespace CamadaDados.Faturamento.Pedido
{
    public class TList_RegLanPedido_Item_X_Estoque : List<TRegistro_LanPedido_Item_X_Estoque>
    { }
    
    public class TRegistro_LanPedido_Item_X_Estoque
    {
        
        public string CD_Empresa
        {
            get;
            set;
        }
        
        public decimal Nr_Pedido
        {
            get;
            set;
        }
        
        public decimal Id_pedidoitem
        { get; set; }
        
        public string CD_Produto
        {
            get;
            set;
        }
        
        public string Ds_produto
        {
            get;
            set;
        }
        
        public decimal ID_LanctoEstoque
        {
            get;
            set;
        }
        
        public TRegistro_LanPedido_Item_X_Estoque()
        {
            this.CD_Empresa = string.Empty;
            this.Nr_Pedido = 0;
            this.Id_pedidoitem = 0;
            this.CD_Produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.ID_LanctoEstoque = 0;
        }
    }

    public class TCD_LanPedido_Item_X_Estoque : TDataQuery
    {
        public TCD_LanPedido_Item_X_Estoque()
        { }

        public TCD_LanPedido_Item_X_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql = new StringBuilder();
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select  a.NR_Pedido, a.CD_produto, a.CD_Empresa, a.Id_LanctoEstoque, ");
                sql.AppendLine("b.CD_local, b.DT_Lancto, b.Tp_movimento, ");
                sql.AppendLine("b.QTD_Entrada, b.QTD_Saida, b.Vl_Unitario, ");
                sql.AppendLine("b.Vl_SubTotal, b.Vl_MedioEstoque, b.Tp_Lancto, a.id_pedidoitem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_Pedido_X_Estoque a ");
            sql.AppendLine(" inner join TB_EST_Estoque b ");
            sql.AppendLine("On a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.cd_produto = b.cd_produto ");
            sql.AppendLine("and a.id_lanctoEstoque = b.Id_lanctoEstoque ");
            sql.AppendLine("Where isNull(b.st_registro, 'A') <> 'C' ");//Estoque diferente de cancelado

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public TList_RegLanPedido_Item_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPedido_Item_X_Estoque lista = new TList_RegLanPedido_Item_X_Estoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPedido_Item_X_Estoque LanPedido_Item_Estoque = new TRegistro_LanPedido_Item_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        LanPedido_Item_Estoque.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        LanPedido_Item_Estoque.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        LanPedido_Item_Estoque.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                        LanPedido_Item_Estoque.ID_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        LanPedido_Item_Estoque.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));

                    lista.Add(LanPedido_Item_Estoque);
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

        public string Grava(TRegistro_LanPedido_Item_X_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(5);

            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.ID_LanctoEstoque);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);

            return executarProc("IA_FAT_PEDIDO_X_ESTOQUE", hs);
        }

        public string Deleta(TRegistro_LanPedido_Item_X_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.ID_LanctoEstoque);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);

            return this.executarProc("EXCLUI_FAT_PEDIDO_X_ESTOQUE", hs);
        }
    }
}
