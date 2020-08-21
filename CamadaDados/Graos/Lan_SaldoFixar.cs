using BancoDados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CamadaDados.Graos
{
    public class TList_SaldoFixar : List<TRegistro_SaldoFixar> { }
    public class TRegistro_SaldoFixar
    {
        public decimal? Nr_contrato { get; set; }
        public string Cd_clifor { get; set; }
        public string Nm_clifor { get; set; }
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Sigla_unidade { get; set; }
        public string Tp_movimento { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("E"))
                    return "ENTRADA";
                else if (Tp_movimento.Trim().ToUpper().Equals("S"))
                    return "SAIDA";
                else return string.Empty;
            }
        }
        public decimal Peso { get; set; }
        public decimal Valor { get; set; }
        public decimal Ps_devolvido { get; set; }
        public decimal Vl_devolvido { get; set; }
        public decimal Ps_aplicado { get; set; }
        public decimal Vl_aplicado { get; set; }
        public decimal Ps_fixado { get; set; }
        public decimal Vl_fixado { get; set; }
        public decimal Ps_transf_E { get; set; }
        public decimal Vl_transf_E { get; set; }
        public decimal Ps_transf_S { get; set; }
        public decimal Vl_transf_S { get; set; }
        public decimal Ps_saldo
        { get { return Tp_movimento.Trim().ToUpper().Equals("E") ? Peso + Ps_transf_E - Ps_transf_S - Ps_devolvido - Ps_fixado : Peso + Ps_transf_S - Ps_transf_E - Ps_devolvido - Ps_fixado; } }
        public decimal Vl_saldo
        { get { return Tp_movimento.Trim().ToUpper().Equals("E") ? Valor + Vl_transf_E - Vl_transf_S - Vl_devolvido - Vl_fixado : Valor + Vl_transf_S - Vl_transf_E - Vl_devolvido - Vl_fixado; } }
        public TRegistro_SaldoFixar()
        {
            Nr_contrato = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Tp_movimento = string.Empty;
            Peso = decimal.Zero;
            Valor = decimal.Zero;
            Ps_devolvido = decimal.Zero;
            Vl_devolvido = decimal.Zero;
            Ps_aplicado = decimal.Zero;
            Vl_aplicado = decimal.Zero;
            Ps_fixado = decimal.Zero;
            Vl_fixado = decimal.Zero;
            Ps_transf_E = decimal.Zero;
            Vl_transf_E = decimal.Zero;
            Ps_transf_S = decimal.Zero;
            Vl_transf_S = decimal.Zero;
        }
    }
    public class TCD_SaldoFixar:TDataQuery
    {
        public TCD_SaldoFixar() { }

        public TCD_SaldoFixar(TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca_E(string Cd_empresa,
                                      string Cd_clifor,
                                      string Cd_produto,
                                      DateTime Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.CD_Empresa, emp.nm_empresa, a.CD_Produto, f.ds_produto, h.sigla_unidade, ");
            sql.AppendLine("a.Tp_Movimento, a.nr_contrato, a.cd_clifor, b.nm_clifor, ");
            sql.AppendLine("Ps_totalentrada = isnull((select sum(isnull(y.qtd_entrada, 0)) ");
            sql.AppendLine("							from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("							inner join tb_est_estoque y ");
            sql.AppendLine("							on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("							and x.cd_produto = y.cd_produto ");
            sql.AppendLine("							and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("							where x.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("							and x.cd_produto = a.CD_Produto ");
            sql.AppendLine("                            and x.id_pedidoitem = a.ID_PedidoItem ");
            sql.AppendLine("							and y.st_registro <> 'C' ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("							and not exists(select 1 from tb_fat_notafiscal_item_x_estoque nfi ");
            sql.AppendLine("											inner join tb_gro_transf_x_contrato tfc ");
            sql.AppendLine("											on nfi.cd_empresa = tfc.cd_empresa ");
            sql.AppendLine("											and nfi.nr_lanctofiscal = tfc.nr_lanctofiscal ");
            sql.AppendLine("											and nfi.id_nfitem = tfc.id_nfitem ");
            sql.AppendLine("											where nfi.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and nfi.cd_produto = x.cd_produto ");
            sql.AppendLine("											and nfi.id_lanctoestoque = x.id_lanctoestoque)), 0), ");
            sql.AppendLine("Vl_totalentrada = isnull((select sum(isnull(y.vl_subtotal, 0)) ");
            sql.AppendLine("							from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("							inner join tb_est_estoque y ");
            sql.AppendLine("							on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("							and x.cd_produto = y.cd_produto ");
            sql.AppendLine("							and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("							where x.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("							and x.cd_produto = a.CD_Produto ");
            sql.AppendLine("                            and x.id_pedidoitem = a.ID_PedidoItem ");
            sql.AppendLine("							and y.st_registro <> 'C' ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("							and not exists(select 1 from tb_fat_notafiscal_item_x_estoque nfi ");
            sql.AppendLine("											inner join tb_gro_transf_x_contrato tfc ");
            sql.AppendLine("											on nfi.cd_empresa = tfc.cd_empresa ");
            sql.AppendLine("											and nfi.nr_lanctofiscal = tfc.nr_lanctofiscal ");
            sql.AppendLine("											and nfi.id_nfitem = tfc.id_nfitem ");
            sql.AppendLine("											where nfi.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and nfi.cd_produto = x.cd_produto ");
            sql.AppendLine("											and nfi.id_lanctoestoque = x.id_lanctoestoque) ");
            sql.AppendLine("							and not exists(select 1 from tb_fat_notafiscal_item_x_estoque nfi ");
            sql.AppendLine("											inner join tb_gro_fixacao_nf nff ");
            sql.AppendLine("											on nfi.cd_empresa = nff.cd_empresa ");
            sql.AppendLine("											and nfi.nr_lanctofiscal = nff.nr_lanctofiscal ");
            sql.AppendLine("											and nfi.id_nfitem = nff.id_nfitem ");
            sql.AppendLine("											and nff.tp_nota in('C', 'D') ");
            sql.AppendLine("											where nfi.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and nfi.cd_produto = x.cd_produto ");
            sql.AppendLine("											and nfi.id_lanctoestoque = x.id_lanctoestoque)), 0), ");
            sql.AppendLine("Ps_devolvido = isnull((select sum(isnull(x.quantidade, 0)) ");
            sql.AppendLine("						from tb_fat_notafiscal_item x ");
            sql.AppendLine("						inner join tb_fat_notafiscal_cmi y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and isnull(z.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and isnull(y.st_devolucao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), case when z.tp_movimento = 'E' then z.dt_saient else z.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and not exists(select 1 from tb_gro_transf_x_contrato z ");
            sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            //sql.AppendLine("						and not exists(select 1 from tb_fat_notafiscal_item_x_estoque z ");
            //sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            //sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            //sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            sql.AppendLine("Vl_devolvido = isnull((select sum(isnull(x.vl_subtotal, 0)) ");
            sql.AppendLine("						from tb_fat_notafiscal_item x ");
            sql.AppendLine("						inner join tb_fat_notafiscal_cmi y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and isnull(z.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and isnull(y.st_devolucao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), case when z.tp_movimento = 'E' then z.dt_saient else z.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and not exists(select 1 from tb_gro_transf_x_contrato z ");
            sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            //sql.AppendLine("						and not exists(select 1 from tb_fat_notafiscal_item_x_estoque z ");
            //sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            //sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            //sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            sql.AppendLine("tot_aplicado = isnull((select (sum( case when y.tp_movimento = 'E' then isnull(p.qtd_aplicado, 0) else 0 end) - sum(case when y.tp_movimento = 'S' then isnull(p.qtd_aplicado, 0) else 0 end)) ");
            sql.AppendLine("						from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("						inner join tb_est_estoque y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = y.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("						inner join tb_bal_aplicacao_pedido p ");
            sql.AppendLine("						on x.cd_empresa = p.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = p.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = p.id_lanctoestoque ");
            sql.AppendLine("						and x.nr_pedido = p.nr_pedido ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and y.st_registro <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("vl_aplicado = isnull((select (sum( case when y.tp_movimento = 'E' then isnull(p.vl_subtotal, 0) else 0 end) - sum(case when y.tp_movimento = 'S' then isnull(p.vl_subtotal, 0) else 0 end)) ");
            sql.AppendLine("						from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("						inner join tb_est_estoque y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = y.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("						inner join tb_bal_aplicacao_pedido p ");
            sql.AppendLine("						on x.cd_empresa = p.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = p.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = p.id_lanctoestoque ");
            sql.AppendLine("						and x.nr_pedido = p.nr_pedido ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and y.st_registro <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");

            sql.AppendLine("Ps_fixado = isnull((select sum(isnull(x.ps_fixado_total, 0)) ");
            sql.AppendLine("                        from tb_gro_fixacao x ");
            sql.AppendLine("                        inner join TB_GRO_Fixacao_X_Contrato y ");
            sql.AppendLine("                        on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("                        where y.nr_contrato = a.Nr_Contrato ");
            sql.AppendLine("						and ISNULL(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.dt_fixacao))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("Vl_fixado = isnull((select sum(isnull(x.ps_fixado_total, 0) * isnull(z.vl_unitario, 0)) ");
            sql.AppendLine("                        from tb_gro_fixacao x ");
            sql.AppendLine("                        inner join TB_GRO_Fixacao_X_Contrato y ");
            sql.AppendLine("                        on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("						inner join VTB_GRO_Contrato z ");
            sql.AppendLine("						on y.nr_contrato = z.nr_contrato ");
            sql.AppendLine("                        where y.nr_contrato = a.Nr_Contrato ");
            sql.AppendLine("						and ISNULL(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.dt_fixacao))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("QTD_Transferencia_Entrada = isnull((SELECT SUM(Isnull(z.quantidade, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'E' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.CD_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.ID_PedidoItem),0), ");
            sql.AppendLine("Vlr_Transferencia_Entrada = isnull((SELECT SUM(Isnull(z.vl_subtotal, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'E' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.CD_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.ID_PedidoItem),0), ");
            sql.AppendLine("QTD_Transferencia_Saida = isnull((SELECT SUM(Isnull(z.quantidade, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'S' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.nr_pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.cd_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.id_pedidoitem),0), ");
            sql.AppendLine("Vlr_Transferencia_Saida = isnull((SELECT SUM(Isnull(z.vl_subtotal, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'S' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.nr_pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.cd_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.id_pedidoitem),0) ");

            sql.AppendLine("from VTB_GRO_CONTRATO a ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.CD_Empresa = emp.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto f ");
            sql.AppendLine("on a.CD_Produto = f.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade h ");
            sql.AppendLine("on f.cd_unidade = h.cd_unidade ");
            sql.AppendLine("inner join tb_fat_cfgpedido cfgped ");
            sql.AppendLine("on a.CFG_Pedido = cfgped.cfg_pedido ");
            sql.AppendLine("and isnull(cfgped.st_valoresfixos, 'N') <> 'S' ");
            sql.AppendLine("and isnull(cfgped.ST_Deposito, 'N') <> 'S' ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");

            sql.AppendLine("where isnull(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.tp_movimento = 'E'");
            if (!string.IsNullOrEmpty(Cd_empresa))
                sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_produto))
                sql.AppendLine("and a.cd_produto = '" + Cd_produto.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_clifor))
                sql.AppendLine("and a.cd_clifor = '" + Cd_clifor.Trim() + "'");

            sql.AppendLine("order by a.cd_clifor ");

            return sql.ToString();
        }
        public TList_SaldoFixar Select_E(string Cd_empresa,
                                         string Cd_clifor,
                                         string Cd_produto,
                                         DateTime Dt_movimento)
        {
            TList_SaldoFixar lista = new TList_SaldoFixar();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca_E(Cd_empresa, Cd_clifor, Cd_produto, Dt_movimento));
            try
            {

                while (reader.Read())
                {
                    TRegistro_SaldoFixar reg = new TRegistro_SaldoFixar();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_totalentrada")))
                        reg.Peso = reader.GetDecimal(reader.GetOrdinal("Ps_totalentrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalentrada")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Vl_totalentrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_devolvido")))
                        reg.Ps_devolvido = reader.GetDecimal(reader.GetOrdinal("Ps_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("Vl_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_aplicado")))
                        reg.Ps_aplicado = reader.GetDecimal(reader.GetOrdinal("tot_aplicado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_aplicado")))
                        reg.Vl_aplicado = reader.GetDecimal(reader.GetOrdinal("vl_aplicado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_fixado")))
                        reg.Ps_fixado = reader.GetDecimal(reader.GetOrdinal("Ps_fixado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_fixado")))
                        reg.Vl_fixado = reader.GetDecimal(reader.GetOrdinal("Vl_fixado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transferencia_Entrada")))
                        reg.Ps_transf_E = reader.GetDecimal(reader.GetOrdinal("QTD_Transferencia_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vlr_Transferencia_Entrada")))
                        reg.Vl_transf_E = reader.GetDecimal(reader.GetOrdinal("Vlr_Transferencia_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transferencia_Saida")))
                        reg.Ps_transf_S = reader.GetDecimal(reader.GetOrdinal("QTD_Transferencia_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vlr_Transferencia_Saida")))
                        reg.Vl_transf_S = reader.GetDecimal(reader.GetOrdinal("Vlr_Transferencia_Saida"));
                    
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
        private string SqlCodeBusca_S(string Cd_empresa,
                                      string Cd_produto,
                                      DateTime Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.CD_Empresa, emp.nm_empresa, a.CD_Produto, f.ds_produto, h.sigla_unidade, ");
            sql.AppendLine("a.Tp_Movimento, a.nr_contrato, a.cd_clifor, b.nm_clifor, ");
            sql.AppendLine("Ps_totalsaida = isnull((select sum(isnull(y.qtd_saida, 0)) ");
            sql.AppendLine("							from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("							inner join tb_est_estoque y ");
            sql.AppendLine("							on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("							and x.cd_produto = y.cd_produto ");
            sql.AppendLine("							and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("							where x.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("							and x.cd_produto = a.CD_Produto ");
            sql.AppendLine("                            and x.id_pedidoitem = a.ID_PedidoItem ");
            sql.AppendLine("							and y.st_registro <> 'C' ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("							and not exists(select 1 from tb_fat_notafiscal_item_x_estoque nfi ");
            sql.AppendLine("											inner join tb_gro_transf_x_contrato tfc ");
            sql.AppendLine("											on nfi.cd_empresa = tfc.cd_empresa ");
            sql.AppendLine("											and nfi.nr_lanctofiscal = tfc.nr_lanctofiscal ");
            sql.AppendLine("											and nfi.id_nfitem = tfc.id_nfitem ");
            sql.AppendLine("											where nfi.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and nfi.cd_produto = x.cd_produto ");
            sql.AppendLine("											and nfi.id_lanctoestoque = x.id_lanctoestoque)), 0), ");
            sql.AppendLine("Vl_totalsaida = isnull((select sum(isnull(x.Vl_SubTotal, 0)) ");
            sql.AppendLine("							from tb_fat_notafiscal_item x ");
            sql.AppendLine("							inner join tb_fat_notafiscal y");
            sql.AppendLine("							on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("							and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("							and isnull(y.st_registro, 'A') <> 'C' ");
            sql.AppendLine("							where x.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("							and x.cd_produto = a.CD_Produto ");
            sql.AppendLine("                            and x.id_pedidoitem = a.ID_PedidoItem ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), y.dt_emissao))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("							and not exists(select 1 from tb_gro_transf_x_contrato tfc ");
            sql.AppendLine("											where tfc.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and tfc.Nr_LanctoFiscal = x.Nr_LanctoFiscal ");
            sql.AppendLine("											and tfc.ID_NFItem = x.ID_NFItem) ");
            sql.AppendLine("							and not exists(select 1 from tb_gro_fixacao_nf nff ");
            sql.AppendLine("											where nff.cd_empresa = x.cd_empresa ");
            sql.AppendLine("											and nff.nr_lanctofiscal = x.nr_lanctofiscal ");
            sql.AppendLine("											and nff.id_nfitem = x.id_nfitem ");
            sql.AppendLine("											and nff.tp_nota in('C', 'D'))), 0), ");
            sql.AppendLine("Ps_devolvido = isnull((select sum(isnull(x.quantidade, 0)) ");
            sql.AppendLine("						from tb_fat_notafiscal_item x ");
            sql.AppendLine("						inner join tb_fat_notafiscal_cmi y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and isnull(z.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and isnull(y.st_devolucao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), case when z.tp_movimento = 'E' then z.dt_saient else z.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and not exists(select 1 from tb_gro_transf_x_contrato z ");
            sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            //sql.AppendLine("						and not exists(select 1 from tb_fat_notafiscal_item_x_estoque z ");
            //sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            //sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            //sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            sql.AppendLine("Vl_devolvido = isnull((select sum(isnull(x.vl_subtotal, 0)) ");
            sql.AppendLine("						from tb_fat_notafiscal_item x ");
            sql.AppendLine("						inner join tb_fat_notafiscal_cmi y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and isnull(z.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and isnull(y.st_devolucao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), case when z.tp_movimento = 'E' then z.dt_saient else z.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and not exists(select 1 from tb_gro_transf_x_contrato z ");
            sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            //sql.AppendLine("						and not exists(select 1 from tb_fat_notafiscal_item_x_estoque z ");
            //sql.AppendLine("										where x.cd_empresa = z.cd_empresa ");
            //sql.AppendLine("										and x.nr_lanctofiscal = z.nr_lanctofiscal ");
            //sql.AppendLine("										and x.id_nfitem = z.id_nfitem)), 0), ");
            sql.AppendLine("tot_aplicado = isnull((select (sum( case when y.tp_movimento = 'E' then isnull(p.qtd_aplicado, 0) else 0 end) - sum(case when y.tp_movimento = 'S' then isnull(p.qtd_aplicado, 0) else 0 end)) ");
            sql.AppendLine("						from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("						inner join tb_est_estoque y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = y.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("						inner join tb_bal_aplicacao_pedido p ");
            sql.AppendLine("						on x.cd_empresa = p.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = p.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = p.id_lanctoestoque ");
            sql.AppendLine("						and x.nr_pedido = p.nr_pedido ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and y.st_registro <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("vl_aplicado = isnull((select (sum( case when y.tp_movimento = 'E' then isnull(p.vl_subtotal, 0) else 0 end) - sum(case when y.tp_movimento = 'S' then isnull(p.vl_subtotal, 0) else 0 end)) ");
            sql.AppendLine("						from tb_fat_pedido_x_estoque x ");
            sql.AppendLine("						inner join tb_est_estoque y ");
            sql.AppendLine("						on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = y.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = y.id_lanctoestoque ");
            sql.AppendLine("						inner join tb_bal_aplicacao_pedido p ");
            sql.AppendLine("						on x.cd_empresa = p.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = p.cd_produto ");
            sql.AppendLine("						and x.id_lanctoestoque = p.id_lanctoestoque ");
            sql.AppendLine("						and x.nr_pedido = p.nr_pedido ");
            sql.AppendLine("						where x.nr_pedido = a.nr_pedido ");
            sql.AppendLine("						and x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.id_pedidoitem = a.id_pedidoitem ");
            sql.AppendLine("						and y.st_registro <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), y.dt_lancto))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("Ps_fixado = isnull((select sum(isnull(x.ps_fixado_total, 0)) ");
            sql.AppendLine("                        from tb_gro_fixacao x ");
            sql.AppendLine("                        inner join TB_GRO_Fixacao_X_Contrato y ");
            sql.AppendLine("                        on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("                        where y.nr_contrato = a.Nr_Contrato ");
            sql.AppendLine("						and ISNULL(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.dt_fixacao))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("Vl_fixado = isnull((select sum(isnull(x.ps_fixado_total, 0) * isnull(z.vl_unitario, 0)) ");
            sql.AppendLine("                        from tb_gro_fixacao x ");
            sql.AppendLine("                        inner join TB_GRO_Fixacao_X_Contrato y ");
            sql.AppendLine("                        on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("						inner join VTB_GRO_Contrato z ");
            sql.AppendLine("						on y.nr_contrato = z.nr_contrato ");
            sql.AppendLine("                        where y.nr_contrato = a.Nr_Contrato ");
            sql.AppendLine("						and ISNULL(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.dt_fixacao))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("QTD_Transferencia_Entrada = isnull((SELECT SUM(Isnull(z.quantidade, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'E' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.CD_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.ID_PedidoItem),0), ");
            sql.AppendLine("Vlr_Transferencia_Entrada = isnull((SELECT SUM(Isnull(z.vl_subtotal, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'E' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.Nr_Pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.CD_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.ID_PedidoItem),0), ");
            sql.AppendLine("QTD_Transferencia_Saida = isnull((SELECT SUM(Isnull(z.quantidade, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'S' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.nr_pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.cd_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.id_pedidoitem),0), ");
            sql.AppendLine("Vlr_Transferencia_Saida = isnull((SELECT SUM(Isnull(z.vl_subtotal, 0)) ");
            sql.AppendLine("                                    FROM tb_gro_transferencia y ");
            sql.AppendLine("                                    INNER JOIN TB_GRO_Transf_X_Contrato x ");
            sql.AppendLine("                                    ON x.id_transf = y.id_Transf ");
            sql.AppendLine("                                    inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("                                    on x.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal_Item z ");
            sql.AppendLine("                                    ON x.cd_empresa = z.cd_empresa ");
            sql.AppendLine("                                    AND x.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("                                    AND x.id_nfitem = z.id_nfitem ");
            sql.AppendLine("                                    INNER JOIN TB_FAT_NotaFiscal nf ");
            sql.AppendLine("                                    ON z.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("                                    AND z.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("                                    WHERE nf.tp_movimento = 'S' ");
            sql.AppendLine("                                    and isnull(nf.st_registro, 'A') <> 'C' ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), case when nf.tp_movimento = 'E' then nf.dt_saient else nf.dt_emissao end))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("                                    AND con.nr_pedido = a.nr_pedido ");
            sql.AppendLine("                                    AND con.cd_Produto = a.cd_Produto ");
            sql.AppendLine("                                    and con.id_pedidoitem = a.id_pedidoitem),0) ");

            sql.AppendLine("from VTB_GRO_CONTRATO a ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.CD_Empresa = emp.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto f ");
            sql.AppendLine("on a.CD_Produto = f.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade h ");
            sql.AppendLine("on f.cd_unidade = h.cd_unidade ");
            sql.AppendLine("inner join tb_fat_cfgpedido cfgped ");
            sql.AppendLine("on a.CFG_Pedido = cfgped.cfg_pedido ");
            sql.AppendLine("and isnull(cfgped.st_valoresfixos, 'N') <> 'S' ");
            sql.AppendLine("and isnull(cfgped.ST_Deposito, 'N') <> 'S' ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");

            sql.AppendLine("where isnull(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.tp_movimento = 'S'");
            if (!string.IsNullOrEmpty(Cd_empresa))
                sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_produto))
                sql.AppendLine("and a.cd_produto = '" + Cd_produto.Trim() + "'");

            sql.AppendLine("order by a.cd_clifor ");

            return sql.ToString();
        }
        public TList_SaldoFixar Select_S(string Cd_empresa,
                                           string Cd_produto,
                                           DateTime Dt_movimento)
        {
            TList_SaldoFixar lista = new TList_SaldoFixar();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca_S(Cd_empresa, Cd_produto, Dt_movimento));
            try
            {

                while (reader.Read())
                {
                    TRegistro_SaldoFixar reg = new TRegistro_SaldoFixar();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_totalsaida")))
                        reg.Peso = reader.GetDecimal(reader.GetOrdinal("Ps_totalsaida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalsaida")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Vl_totalsaida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_devolvido")))
                        reg.Ps_devolvido = reader.GetDecimal(reader.GetOrdinal("Ps_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("Vl_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_aplicado")))
                        reg.Ps_aplicado = reader.GetDecimal(reader.GetOrdinal("tot_aplicado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_aplicado")))
                        reg.Vl_aplicado = reader.GetDecimal(reader.GetOrdinal("vl_aplicado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_fixado")))
                        reg.Ps_fixado = reader.GetDecimal(reader.GetOrdinal("Ps_fixado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_fixado")))
                        reg.Vl_fixado = reader.GetDecimal(reader.GetOrdinal("Vl_fixado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transferencia_Entrada")))
                        reg.Ps_transf_E = reader.GetDecimal(reader.GetOrdinal("QTD_Transferencia_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vlr_Transferencia_Entrada")))
                        reg.Vl_transf_E = reader.GetDecimal(reader.GetOrdinal("Vlr_Transferencia_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transferencia_Saida")))
                        reg.Ps_transf_S = reader.GetDecimal(reader.GetOrdinal("QTD_Transferencia_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vlr_Transferencia_Saida")))
                        reg.Vl_transf_S = reader.GetDecimal(reader.GetOrdinal("Vlr_Transferencia_Saida"));

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
    }
}
