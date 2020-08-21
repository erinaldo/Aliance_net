using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Graos
{
    #region "CONTRATO HEADGE"

        public class TList_CadContratoHeadge : List<TRegistro_CadContratoHeadge> { }

        public class TRegistro_CadContratoHeadge
        {
            private decimal? nr_contrato;
            public decimal? Nr_contrato
            {
                get { return nr_contrato; }
                set
                {
                    nr_contrato = value;
                    nr_contratostr = value.ToString();
                }
            }
            private string nr_contratostr;
            public string Nr_contratostr
            {
                get { return nr_contratostr; }
                set
                {
                    nr_contratostr = value;
                    try
                    {
                        nr_contrato = Convert.ToDecimal(value);
                    }
                    catch
                    { nr_contrato = null; }
                }
            }
            public decimal Nr_Pedido { get; set; }
            public string Anosafra { get; set; }
            public string Cd_clifor { get; set; }
            public string Nm_clifor { get; set; }
            public string Cd_UnidQTD { get; set; }
            public string DS_UnidQTD { get; set; }
            public string Cd_UnidVL { get; set; }
            public string DS_UnidVL { get; set; }
            public string Cd_empresa { get; set; }
            public string Nm_empresa { get; set; }
            public string Cd_produto { get; set; }
            public string Ds_produto { get; set; }
            public decimal QTD_Contrato { get; set; }
            public decimal VL_Contrato { get; set; }
            public decimal VL_Unitario { get; set; }
            public decimal PC_Atendido { get; set; }

            public decimal QTD_Venda { get; set; }
            public decimal VL_Venda { get; set; }
            public decimal VL_Compra { get; set; }
            public decimal QTD_Compra { get; set; }
            public decimal Tot_Imposto_Venda { get; set; }
            public decimal Tot_Frete_Venda { get; set; }
            public decimal Tot_Comissao_Venda { get; set; }
            public decimal Tot_Outros_Venda { get; set; }
            public decimal Tot_Imposto_Compra { get; set; }
            public decimal Tot_Frete_Compra { get; set; }
            public decimal Tot_Comissao_Compra { get; set; }
            public decimal Tot_Outros_Compra { get; set; }
            public decimal Tot_Headge_Compra
            { 
                get 
                {
                    return Tot_Imposto_Compra + Tot_Frete_Compra + Tot_Comissao_Compra + Tot_Outros_Compra;
                } 
            }
            public decimal Tot_Headge_Venda
            {
                get
                {
                    return Tot_Imposto_Venda + Tot_Frete_Venda + Tot_Comissao_Venda + Tot_Outros_Venda;
                }
            }
            public decimal Tot_Custo_Headge
            {
                get
                {
                    return Tot_Headge_Compra + Tot_Headge_Venda;
                }
            }

            public TRegistro_CadContratoHeadge()
            {
                this.Nr_contratostr = "";
                this.Anosafra = "";
                this.Cd_clifor = "";
                this.Nm_clifor = "";
                this.Cd_empresa = "";
                this.Nm_empresa = "";
                this.Cd_produto = "";
                this.Ds_produto = "";
                this.Cd_UnidQTD = "";
                this.DS_UnidQTD = "";
                this.Cd_UnidVL = "";
                this.DS_UnidVL = "";
                this.Nr_Pedido = 0;
                this.Tot_Imposto_Venda = 0;
                this.Tot_Frete_Venda = 0;
                this.Tot_Comissao_Venda = 0;
                this.Tot_Outros_Venda = 0;
                this.Tot_Imposto_Compra = 0;
                this.Tot_Frete_Compra = 0;
                this.Tot_Comissao_Compra = 0;
                this.Tot_Outros_Compra = 0;
                this.QTD_Venda = 0;
                this.VL_Unitario = 0;
                this.VL_Venda = 0;
                this.VL_Compra= 0;
                this.QTD_Compra = 0;
            }
        }

    #endregion

    #region "NOTAS FISCAL HEADGE"

        public class TList_CadNotaFiscalHeadge : List<TRegistro_CadNotaFiscalHeadge> { }

        public class TRegistro_CadNotaFiscalHeadge
        {
            public string CD_Empresa { get; set; }
            public decimal Nr_LanctoFiscal { get; set; }
            public decimal Nr_NotaFiscal { get; set; }
            public decimal ID_Originacao { get; set; }
            public decimal ID_NFItem { get; set; }
            public decimal Nr_Pedido { get; set; }
            public decimal ID_PedidoItem { get; set; }
            public string Nr_Serie { get; set; }
            public string CD_Clifor { get; set; }
            public string NM_Clifor { get; set; }
            public string CD_Produto { get; set; }
            public decimal Quantidade { get; set; }
            public decimal VL_Unitario { get; set; }
            public decimal VL_Subtotal { get; set; }
            public decimal Qtd_Origem { get; set; }
            public decimal Vl_Origem { get; set; }
            public decimal Ps_Chegada { get; set; }
            public decimal Tot_Imposto_Venda { get; set; }
            public decimal Tot_Frete_Venda { get; set; }
            public decimal Tot_Comissao_Venda { get; set; }
            public decimal Tot_Outros_Venda { get; set; }
            public decimal Tot_Imposto_Compra { get; set; }
            public decimal Tot_Frete_Compra { get; set; }
            public decimal Tot_Comissao_Compra { get; set; }
            public decimal Tot_Outros_Compra { get; set; }
            public decimal Tot_Headge_Compra
            {
                get
                {
                    return Tot_Imposto_Compra + Tot_Frete_Compra + Tot_Comissao_Compra + Tot_Outros_Compra;
                }
            }
            public decimal Tot_Headge_Venda
            {
                get
                {
                    return Tot_Imposto_Venda + Tot_Frete_Venda + Tot_Comissao_Venda + Tot_Outros_Venda;
                }
            }
            public decimal Tot_Custo_Headge
            {
                get
                {
                    return Tot_Headge_Compra + Tot_Headge_Venda;
                }
            }

            public TRegistro_CadNotaFiscalHeadge()
            {
                this.CD_Empresa = "";
                this.Nr_LanctoFiscal = 0;
                this.Nr_NotaFiscal = 0;
                this.ID_Originacao = 0;
                this.ID_NFItem = 0;
                this.Qtd_Origem = 0;
                this.Vl_Origem = 0;
                this.Nr_Serie = "";
                this.CD_Clifor = "";
                this.NM_Clifor = "";
                this.CD_Produto = "";
                this.Quantidade = 0;
                this.VL_Unitario = 0;
                this.VL_Subtotal = 0;
                this.Ps_Chegada = 0;
                this.Tot_Imposto_Venda = 0;
                this.Tot_Frete_Venda = 0;
                this.Tot_Comissao_Venda = 0;
                this.Tot_Outros_Venda = 0;
                this.Tot_Imposto_Compra = 0;
                this.Tot_Frete_Compra = 0;
                this.Tot_Comissao_Compra = 0;
                this.Tot_Outros_Compra = 0;
                this.ID_PedidoItem = 0;
                this.Nr_Pedido = 0;
            }
        }

    #endregion

    #region "TOTAIS CONTRATO HEADGE"

        public class TList_CadTotaisContratoHeadge : List<TRegistro_CadTotaisContratoHeadge> { }

        public class TRegistro_CadTotaisContratoHeadge
        {
            public decimal TotalImpostoCompra { get; set; }
            public decimal TotalFreteCompra { get; set; }
            public decimal TotalComissaoCompra { get; set; }
            public decimal TotalOutrosCompra { get; set; }
            public decimal TotalCompra { get; set; }
            public decimal TotalImpostoVenda { get; set; }
            public decimal TotalFreteVenda { get; set; }
            public decimal TotalComissaoVenda { get; set; }
            public decimal TotalOutrosVenda { get; set; }
            public decimal TotalVenda { get; set; }
            public decimal TotalVLVenda { get; set; }
            public decimal TotalVLCompra { get; set; }
            public decimal TotalResulImposto { get; set; }
            public decimal TotalResulFrete { get; set; }
            public decimal TotalResulComissao { get; set; }
            public decimal TotalResulOutros { get; set; }
            public decimal TotalResulTotCompraVenda { get; set; }
            public decimal TotalResulVLCompraVenda { get; set; }

            public TRegistro_CadTotaisContratoHeadge()
            {
                this.TotalImpostoCompra = 0;
                this.TotalFreteCompra = 0;
                this.TotalComissaoCompra = 0;
                this.TotalOutrosCompra = 0;
                this.TotalCompra = 0;
                this.TotalImpostoVenda = 0;
                this.TotalFreteVenda = 0;
                this.TotalComissaoVenda = 0;
                this.TotalOutrosVenda = 0;
                this.TotalVenda = 0;
                this.TotalVLVenda = 0;
                this.TotalVLCompra = 0;
                this.TotalResulImposto  = 0;
                this.TotalResulFrete = 0;
                this.TotalResulComissao = 0;
                this.TotalResulOutros = 0;
                this.TotalResulTotCompraVenda = 0;
                this.TotalResulVLCompraVenda = 0;
            }
        }

    #endregion

    public class TCD_LanFechamentoOperacao : TDataQuery
    {
        private string SqlCodeBuscaContrato(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine("	a.Nr_contrato, a.tp_movimento, a.Anosafra, a.Cd_clifor, c.Nm_clifor, a.Cd_empresa, e.Nm_empresa, a.Cd_produto,a.Nr_pedido, d.Ds_produto,   ");
            sql.AppendLine("	g.CD_Unidade, i.DS_Unidade, g.VL_Unitario, g.VL_subtotal as VL_Contratado, g.Quantidade, ");

            sql.AppendLine("	ISNULL((SELECT SUM(x.VL_Lancto) FROM TB_GRO_Lancto_NFHeadge x ");
            sql.AppendLine("	 INNER JOIN TB_GRO_Headge y ON x.ID_Headge = y.ID_Headge ");
            sql.AppendLine("	 INNER JOIN TB_FAT_NotaFiscal_Item w ON x.Nr_LanctoFiscal = w.Nr_LanctoFiscal and x.cd_empresa = w.cd_empresa and x.id_nfitem = w.id_nfitem ");
            sql.AppendLine("	 WHERE y.TP_Headge = 'I' ");
            sql.AppendLine("	 AND w.Nr_Pedido = f.Nr_Pedido),0) as Tot_Imposto_Venda, ");

            sql.AppendLine("	ISNULL((SELECT SUM(x.VL_Lancto) FROM TB_GRO_Lancto_NFHeadge x  ");
            sql.AppendLine("	 INNER JOIN TB_GRO_Headge y ON x.ID_Headge = y.ID_Headge ");
            sql.AppendLine("	 INNER JOIN TB_FAT_NotaFiscal_Item w ON x.Nr_LanctoFiscal = w.Nr_LanctoFiscal and x.cd_empresa = w.cd_empresa and x.id_nfitem = w.id_nfitem ");
            sql.AppendLine("	 WHERE y.TP_Headge = 'F' ");
            sql.AppendLine("	 AND w.Nr_Pedido = f.Nr_Pedido),0) as Tot_Frete_Venda, ");

            sql.AppendLine("	ISNULL((SELECT SUM(x.VL_Lancto) FROM TB_GRO_Lancto_NFHeadge x  ");
            sql.AppendLine("	 INNER JOIN TB_GRO_Headge y ON x.ID_Headge = y.ID_Headge ");
            sql.AppendLine("	 INNER JOIN TB_FAT_NotaFiscal_Item w ON x.Nr_LanctoFiscal = w.Nr_LanctoFiscal and x.cd_empresa = w.cd_empresa and x.id_nfitem = w.id_nfitem ");
            sql.AppendLine("	 WHERE y.TP_Headge = 'C' ");
            sql.AppendLine("	 AND w.Nr_Pedido = f.Nr_Pedido),0) as Tot_Comissao_Venda, ");

            sql.AppendLine("	ISNULL((SELECT SUM(x.VL_Lancto) FROM TB_GRO_Lancto_NFHeadge x  ");
            sql.AppendLine("	 INNER JOIN TB_GRO_Headge y ON x.ID_Headge = y.ID_Headge ");
            sql.AppendLine("	 INNER JOIN TB_FAT_NotaFiscal_Item w ON x.Nr_LanctoFiscal = w.Nr_LanctoFiscal and x.cd_empresa = w.cd_empresa and x.id_nfitem = w.id_nfitem ");
            sql.AppendLine("	 WHERE y.TP_Headge = 'O' ");
            sql.AppendLine("	 AND w.Nr_Pedido = f.Nr_Pedido),0) as Tot_Outros_Venda, ");

            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'I' ");
            sql.AppendLine("	   and nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as Tot_Impostos_Compra, ");

            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'F' ");
            sql.AppendLine("	   and nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as Tot_Frete_Compra, ");

            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'C' ");
            sql.AppendLine("	   and nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = b.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as Tot_Comissao_Compra, ");

            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'O' ");
            sql.AppendLine("	   and nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as Tot_Outros_Compra, ");

            sql.AppendLine("	ISNULL((select sum(isnull(nfs.vl_subtotal,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 WHERE nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = b.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as VL_Venda, ");

            sql.AppendLine("	ISNULL((select sum(isnull(nfs.quantidade,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 WHERE nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as QTD_Venda, ");
            
            sql.AppendLine("	ISNULL((select sum(isnull(n.vl_origem,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 WHERE nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as VL_Compra, ");

            sql.AppendLine("	ISNULL((select sum(isnull(n.qtd_origem,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m  ");
            sql.AppendLine("	 join tb_fat_notafiscal_item nfs on m.cd_empresa = nfs.cd_empresa and m.nr_lanctofiscal = nfs.nr_lanctofiscal and m.id_nfitem = nfs.id_nfitem ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 WHERE nfs.nr_pedido = a.nr_pedido and nfs.cd_produto = a.cd_produto and nfs.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("	 ),0) as QTD_Compra ");
            
            sql.AppendLine("FROM VTB_GRO_Contrato a  ");
            sql.AppendLine("JOIN vTB_FIN_Clifor c ON c.CD_Clifor = a.CD_Clifor  ");
            sql.AppendLine("JOIN TB_EST_Produto d ON d.CD_Produto = a.CD_Produto  ");
            sql.AppendLine("JOIN TB_DIV_Empresa e ON e.CD_Empresa = a.CD_Empresa  ");
            sql.AppendLine("JOIN vTB_FAT_Pedido f ON f.Nr_Pedido = a.Nr_Pedido AND f.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("JOIN TB_FAT_Pedido_Itens g ON g.Nr_Pedido = f.Nr_Pedido AND g.ID_PedidoItem = a.ID_PedidoItem AND g.CD_Produto = a.CD_Produto ");
            sql.AppendLine("JOIN TB_EST_Unidade i ON i.CD_Unidade = d.CD_Unidade ");
            sql.AppendLine("WHERE a.tp_movimento = 'S' ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            
            return sql.ToString();
        }

        public TList_CadContratoHeadge SelectContrato(TpBusca[] vBusca)
        {
            TList_CadContratoHeadge lista = new TList_CadContratoHeadge();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaContrato(vBusca));
                while (reader.Read())
                {
                    TRegistro_CadContratoHeadge reg = new TRegistro_CadContratoHeadge();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("Nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedido")))
                        reg.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Anosafra")))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("Anosafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("Cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("Nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("Ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Imposto_Venda")))
                        reg.Tot_Imposto_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Imposto_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Frete_Venda")))
                        reg.Tot_Frete_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Frete_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Comissao_Venda")))
                        reg.Tot_Comissao_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Comissao_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Outros_Venda")))
                        reg.Tot_Outros_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Outros_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Impostos_Compra")))
                        reg.Tot_Imposto_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Impostos_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Frete_Compra")))
                        reg.Tot_Frete_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Frete_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Comissao_Compra")))
                        reg.Tot_Comissao_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Comissao_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Outros_Compra")))
                        reg.Tot_Outros_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Outros_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.VL_Unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));

                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Venda")))
                        reg.VL_Venda = reader.GetDecimal(reader.GetOrdinal("VL_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Venda")))
                        reg.QTD_Venda = reader.GetDecimal(reader.GetOrdinal("QTD_Venda"));

                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Contratado")))
                        reg.VL_Contrato= reader.GetDecimal(reader.GetOrdinal("VL_Contratado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.QTD_Contrato = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Compra")))
                        reg.QTD_Compra = reader.GetDecimal(reader.GetOrdinal("QTD_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Compra")))
                        reg.VL_Compra = reader.GetDecimal(reader.GetOrdinal("VL_Compra"));
                    if (reg.QTD_Contrato > 0)
                      reg.PC_Atendido = Math.Round((reg.QTD_Venda / reg.QTD_Contrato) * 100,1);

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

        private string SqlCodeBuscaNotaFiscal(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine("	a.CD_Empresa, a.NR_LanctoFiscal, a.Nr_NotaFiscal, a.Nr_Serie, a.CD_Clifor, e.NM_Clifor, b.CD_Produto, f.DS_Produto, ");
            sql.AppendLine("	b.Quantidade, b.VL_Unitario, b.VL_Subtotal, d.Ps_Chegada, d.ID_Originacao, b.ID_NFItem, b.nr_pedido, b.id_pedidoitem, ");
            sql.AppendLine("	ISNULL(SUM((CASE WHEN i.TP_Headge = 'I' THEN g.VL_Lancto ELSE 0 END)),0) as Tot_Imposto_Venda, ");
            sql.AppendLine("	ISNULL(SUM((CASE WHEN i.TP_Headge = 'F' THEN g.VL_Lancto ELSE 0 END)),0) as Tot_Frete_Venda, ");
            sql.AppendLine("	ISNULL(SUM((CASE WHEN i.TP_Headge = 'C' THEN g.VL_Lancto ELSE 0 END)),0) as Tot_Comissao_Venda, ");
            sql.AppendLine("	ISNULL(SUM((CASE WHEN i.TP_Headge = 'O' THEN g.VL_Lancto ELSE 0 END)),0) as Tot_Outros_Venda, ");
            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'I' ");
            sql.AppendLine("	   and m.cd_empresa = a.cd_empresa and m.nr_lanctofiscal = a.nr_lanctofiscal and m.id_nfitem = b.id_nfitem ");
            sql.AppendLine("	 ),0) as Tot_Impostos_Compra, ");
            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m 	  ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'F' ");
            sql.AppendLine("	   and m.cd_empresa = a.cd_empresa and m.nr_lanctofiscal = a.nr_lanctofiscal and m.id_nfitem = b.id_nfitem ");
            sql.AppendLine("	 ),0) as Tot_Frete_Compra, ");
            sql.AppendLine("	ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("	 from tb_gro_originacao m 	  ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'C' ");
            sql.AppendLine("	   and m.cd_empresa = a.cd_empresa and m.nr_lanctofiscal = a.nr_lanctofiscal and m.id_nfitem = b.id_nfitem ");
            sql.AppendLine("	 ),0) as Tot_Comissao_Compra, ");
            sql.AppendLine("     ISNULL((select sum(isnull(p.vl_lancto,0)) ");
            sql.AppendLine("     from tb_gro_originacao m 	  ");
            sql.AppendLine("	 join tb_gro_originacao_X_faturamento n on m.id_originacao = n.id_originacao ");
            sql.AppendLine("	 join tb_fat_notafiscal_item o on n.cd_empresa = o.cd_empresa and n.nr_lanctofiscal = o.nr_lanctofiscal and n.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_lancto_NFHeadge p on p.nr_lanctofiscal = o.nr_lanctofiscal and p.cd_empresa = o.cd_empresa and p.id_nfitem = o.id_nfitem ");
            sql.AppendLine("	 join tb_gro_headge q on q.id_headge = p.id_headge ");
            sql.AppendLine("	 where q.tp_headge = 'O' ");
            sql.AppendLine("	   and m.cd_empresa = a.cd_empresa and m.nr_lanctofiscal = a.nr_lanctofiscal and m.id_nfitem = b.id_nfitem ");
            sql.AppendLine("	 ),0) as Tot_Outros_Compra ");

            sql.AppendLine("FROM TB_FAT_NotaFiscal a  ");
            sql.AppendLine("JOIN TB_FAT_NotaFiscal_Item b ON a.Nr_lanctoFiscal = b.Nr_lanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("JOIN VTB_GRO_Contrato c ON c.Nr_pedido = b.Nr_pedido AND c.CD_Produto = b.CD_produto AND c.ID_PedidoItem = b.ID_PedidoItem ");
            sql.AppendLine("JOIN TB_GRO_Originacao d ON b.Nr_LanctoFiscal = d.Nr_LanctoFiscal AND b.CD_Empresa = d.CD_Empresa AND d.ID_NFItem = b.ID_NFItem ");
            sql.AppendLine("JOIN vTB_FIN_Clifor e ON a.CD_Clifor = e.CD_Clifor ");
            sql.AppendLine("JOIN TB_EST_Produto f ON f.CD_Produto = b.CD_Produto ");
            sql.AppendLine("LEFT OUTER JOIN TB_GRO_Lancto_NFHeadge g ON g.nr_lanctofiscal = b.nr_lanctofiscal AND g.cd_empresa = b.cd_empresa AND g.id_nfItem = b.id_nfItem ");
            sql.AppendLine("LEFT OUTER JOIN TB_GRO_Headge i ON i.ID_Headge = g.ID_Headge ");
            sql.AppendLine("WHERE ISNULL(a.st_registro, '') <> 'C' ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("GROUP BY a.CD_Empresa, a.NR_LanctoFiscal, a.Nr_NotaFiscal, a.Nr_Serie, a.CD_Clifor, e.NM_Clifor, b.CD_Produto, f.DS_Produto, ");
            sql.AppendLine("b.Quantidade, b.VL_Unitario, b.VL_Subtotal, d.Ps_Chegada, b.id_nfitem, d.ID_Originacao, b.nr_pedido, b.id_pedidoitem ");
            return sql.ToString();
        }

        public TList_CadNotaFiscalHeadge SelectNotaFiscal(TpBusca[] vBusca)
        {
            TList_CadNotaFiscalHeadge lista = new TList_CadNotaFiscalHeadge();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaNotaFiscal(vBusca));
                while (reader.Read())
                {
                    TRegistro_CadNotaFiscalHeadge reg = new TRegistro_CadNotaFiscalHeadge();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_NotaFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_Serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.VL_Unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Subtotal")))
                        reg.VL_Subtotal = reader.GetDecimal(reader.GetOrdinal("VL_Subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Chegada")))
                        reg.Ps_Chegada = reader.GetDecimal(reader.GetOrdinal("Ps_Chegada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Imposto_Venda")))
                        reg.Tot_Imposto_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Imposto_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Frete_Venda")))
                        reg.Tot_Frete_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Frete_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Comissao_Venda")))
                        reg.Tot_Comissao_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Comissao_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Outros_Venda")))
                        reg.Tot_Outros_Venda = reader.GetDecimal(reader.GetOrdinal("Tot_Outros_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Impostos_Compra")))
                        reg.Tot_Imposto_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Impostos_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Frete_Compra")))
                        reg.Tot_Frete_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Frete_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Comissao_Compra")))
                        reg.Tot_Comissao_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Comissao_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_Outros_Compra")))
                        reg.Tot_Outros_Compra = reader.GetDecimal(reader.GetOrdinal("Tot_Outros_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Originacao")))
                        reg.ID_Originacao = reader.GetDecimal(reader.GetOrdinal("ID_Originacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.ID_PedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        private string SqlCodeBuscaNotaFiscalEntrada(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine("	a.cd_empresa, d.nr_notafiscal, d.nr_lanctofiscal, d.nr_serie, d.cd_clifor, e.nm_clifor, b.qtd_origem, b.vl_origem, a.quantidade as QTD_NF, a.vl_subtotal as VL_NF, ");
            sql.AppendLine("	c.ID_Originacao, a.ID_pedidoItem, a.ID_NFItem, a.Nr_Pedido, a.CD_produto ");

            sql.AppendLine("from tb_fat_notafiscal_item a ");
            sql.AppendLine("join tb_fat_notafiscal d on a.cd_empresa = d.cd_empresa and a.nr_lanctofiscal = d.nr_lanctofiscal ");
            sql.AppendLine("join tb_gro_originacao_x_faturamento b on a.cd_empresa = b.cd_empresa and a.nr_lanctofiscal = b.nr_lanctofiscal and a.id_nfitem = b.id_nfitem ");
            sql.AppendLine("join tb_gro_originacao c on b.id_originacao = c.id_originacao ");
            sql.AppendLine("join vtb_fin_clifor e on e.cd_clifor = d.cd_clifor ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            
            return sql.ToString();
        }

        public TList_CadNotaFiscalHeadge SelectNotaFiscalEntrada(TpBusca[] vBusca)
        {
            TList_CadNotaFiscalHeadge lista = new TList_CadNotaFiscalHeadge();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaNotaFiscalEntrada(vBusca));
                while (reader.Read())
                {
                    TRegistro_CadNotaFiscalHeadge reg = new TRegistro_CadNotaFiscalHeadge();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_NotaFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_Serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_NF")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("QTD_NF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_NF")))
                        reg.VL_Subtotal = reader.GetDecimal(reader.GetOrdinal("VL_NF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_origem")))
                        reg.Qtd_Origem = reader.GetDecimal(reader.GetOrdinal("qtd_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_origem")))
                        reg.Vl_Origem = reader.GetDecimal(reader.GetOrdinal("vl_origem"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Originacao")))
                        reg.ID_Originacao = reader.GetDecimal(reader.GetOrdinal("ID_Originacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.ID_PedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }
    }
   
}
