using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using CamadaDados;
using Utils;

namespace CamadaDados.Faturamento.Pedido
{
    public class TList_RegLanPedidoVenda : List<TRegistro_LanPedidoVenda>
    { }

    public class TRegistro_LanPedidoVenda
    {
        private Decimal vNr_Pedido;
        public Decimal Nr_Pedido
        {
            get { return vNr_Pedido; }
            set { vNr_Pedido = value; }
        }
        string vCD_TabelaPreco;
        public string CD_TabelaPreco { get { return vCD_TabelaPreco; } set { vCD_TabelaPreco = value; } }
        private string vDS_TabelaPreco;
        public string DS_TabelaPreco
        {
            get { return vDS_TabelaPreco; }
            set { vDS_TabelaPreco = value; }
        }
        string vCD_Vendedor;
        public string CD_Vendedor { get { return vCD_Vendedor; } set { vCD_Vendedor = value; } }
        private string vNM_Vendedor;
        public string NM_Vendedor
        {
            get { return vNM_Vendedor; }
            set { vNM_Vendedor = value; }
        }
        DateTime vDT_Validade;
        public DateTime DT_Validade { get { return vDT_Validade; } set { vDT_Validade = value; } }
        decimal vVl_Frete;
        public decimal Vl_Frete { get { return vVl_Frete; } set { vVl_Frete = value; } }
        decimal vPC_DescGeral;
        public decimal Pc_DescGeral { get { return vPC_DescGeral; } set { vPC_DescGeral = value; } }
        decimal vPC_Comissao;
        public decimal Pc_Comissao { get { return vPC_Comissao; } set { vPC_Comissao = value; } }
        string vTp_Frete;
        public string Tp_Frete { get { return vTp_Frete; } set { vTp_Frete = value; } }
        string vTp_VlFrete;
        public string Tp_VlFrete { get { return vTp_VlFrete; } set { vTp_VlFrete = value; } }
        string vST_AgregarFrete;
        public string ST_AgregarFrete { get { return vST_AgregarFrete; } set { vST_AgregarFrete = value; } }
        decimal vVl_DescontoGeral;
        public decimal Vl_DescontoGeral { get { return vVl_DescontoGeral; } set { vVl_DescontoGeral = value; } }        
        private char vST_Registro = 'A';
        public char ST_Registro
        {
            get
            {
                return vST_Registro;
            }
            set
            {
                value = vST_Registro;
            }
        }
    }

    public class TCD_LanPedido_Venda : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select a.NR_Pedido, a.CD_TabelaPreco, a.CD_Vendedor, a.DT_Validade, a.Vl_Frete, a.Pc_DescGeral, a.Pc_Comissao, ");
                sql.AppendLine("a.tp_frete, a.tp_vlFrete, a.st_AgregarFrete, a.vl_DescontoGeral, a.ST_Registro, a.DT_Cad, a.DT_Alt");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From Tb_Fat_DadosPedido a ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            cond = " and ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                {
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        if ((vBusca[i].vOperador.ToUpper() == "IN") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT IN") ||
                            (vBusca[i].vOperador.ToUpper() == "EXISTS") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT EXISTS"))
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        }
                        else
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        }
                    }
                }
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }
        public TList_RegLanPedidoVenda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPedidoVenda lista = new TList_RegLanPedidoVenda();
            SqlDataReader reader = null;
            Int64 x = 0;
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

                while (reader.Read() && (x <= vTop || vTop == 0))
                {
                    TRegistro_LanPedidoVenda LanPedido_Venda = new TRegistro_LanPedidoVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        LanPedido_Venda.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        LanPedido_Venda.CD_TabelaPreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        LanPedido_Venda.CD_Vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Validade")))
                        LanPedido_Venda.DT_Validade = reader.GetDateTime(reader.GetOrdinal("DT_Validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Frete")))
                        LanPedido_Venda.Vl_Frete = reader.GetDecimal(reader.GetOrdinal("Vl_Frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_DescGeral")))
                        LanPedido_Venda.Pc_DescGeral = reader.GetDecimal(reader.GetOrdinal("Pc_DescGeral"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_Comissao")))
                        LanPedido_Venda.Pc_Comissao = reader.GetDecimal(reader.GetOrdinal("Pc_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Frete")))
                        LanPedido_Venda.Tp_Frete = reader.GetString(reader.GetOrdinal("Pc_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_VlFrete")))
                        LanPedido_Venda.Tp_VlFrete = reader.GetString(reader.GetOrdinal("TP_VlFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_AgregarFrete")))
                        LanPedido_Venda.ST_AgregarFrete = reader.GetString(reader.GetOrdinal("ST_AgregarFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_DescontoGeral")))
                        LanPedido_Venda.Vl_DescontoGeral = reader.GetDecimal(reader.GetOrdinal("VL_DescontoGeral"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        LanPedido_Venda.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"))[0];

                    lista.Add(LanPedido_Venda);
                    x++;
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
        public string Grava(TRegistro_LanPedidoVenda vRegistro)
        {
            Hashtable hs = new Hashtable();

            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido.ToString());
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);

            return executarProc("IA_FAT_PEDIDO_VENDA", hs);
        }
        public void Deleta(TRegistro_LanPedidoVenda vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);            

            executarProc("EXCLUI_FAT_PEDIDO_VENDA", hs);
        }

    }
}
