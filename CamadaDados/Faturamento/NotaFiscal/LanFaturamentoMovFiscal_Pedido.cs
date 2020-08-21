using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_RegLanFaturamentoMovFiscal_Pedido : List<TRegistro_LanFaturamentoMovFiscal_Pedido>
    {}

    
    public class TRegistro_LanFaturamentoMovFiscal_Pedido
    {
        
        public decimal? Nr_lanctofiscal
        {
            get;
            set;
        }
        
        public string Cd_empresa
        {
            get;
            set;
        }
        
        public string Nm_empresa
        {
            get;
            set;
        }
        
        public decimal? Id_nfitem
        {
            get;
            set;
        }
        
        public decimal? Nr_pedido
        {
            get;
            set;
        }
        
        public string Cd_produto
        {
            get;
            set;
        }
        
        public string Ds_produto
        {
            get;
            set;
        }
        
        public decimal Id_pedidoitem
        { get; set; }
        
        public string Tp_movimento
        {
            get;
            set;
        }
        
        public decimal Quantidade
        {
            get;
            set;
        }
        
        public decimal Vl_subtotal
        {
            get;
            set;
        }

        public TRegistro_LanFaturamentoMovFiscal_Pedido()
        {
            this.Nr_lanctofiscal = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_nfitem = null;
            this.Nr_pedido = null;
            this.Id_pedidoitem = 0;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Tp_movimento = string.Empty;
            this.Quantidade = 0;
            this.Vl_subtotal = 0;
        }
    }

    public class TCD_LanFaturamentoMovFiscal_Pedido : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.Nr_LanctoFiscal, a.CD_Empresa, a.ID_NFItem, ");
                sql.AppendLine("a.Nr_LanctoFiscal, a.CD_Empresa, a.ID_NFItem, a.id_pedidoitem, ");
                sql.AppendLine("a.VL_SubTotal, b.NM_Empresa, c.DS_Produto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAT_MovFiscal_Pedido AS a INNER JOIN ");
            sql.AppendLine("TB_DIV_Empresa AS b ON a.CD_Empresa = b.CD_Empresa INNER JOIN ");
            sql.AppendLine("TB_EST_Produto AS c ON a.CD_Produto = c.CD_Produto ");

            string cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
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

        public TList_RegLanFaturamentoMovFiscal_Pedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            TList_RegLanFaturamentoMovFiscal_Pedido lista = new TList_RegLanFaturamentoMovFiscal_Pedido();
            while (reader.Read())
            {
                TRegistro_LanFaturamentoMovFiscal_Pedido reg = new TRegistro_LanFaturamentoMovFiscal_Pedido();
                if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                    reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                    reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                    reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                if (!(reader.IsDBNull(reader.GetOrdinal("ID_NfItem"))))
                    reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NfItem"));
                if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                    reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                    reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                    reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                    reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                    reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                if (!(reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal"))))
                    reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                    reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                lista.Add(reg);
            }
            return lista;
        }

        public string GravaMovFiscal_Pedido(TRegistro_LanFaturamentoMovFiscal_Pedido val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);

            return this.executarProc("IA_FAT_MOVFISCAL_PEDIDO", hs);
        }

        public string DeletaMovFiscal_Pedido(TRegistro_LanFaturamentoMovFiscal_Pedido val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("EXCLUI_FAT_MOVFISCAL_PEDIDO", hs);
        }
    }
}
