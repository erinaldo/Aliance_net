using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Contabil
{
    public class TList_LanAuditarProdutor : List<TRegistro_LanAuditarProdutor>, IComparer<TRegistro_LanAuditarProdutor>
    {
        #region IComparer<TRegistro_LanAuditarProdutor> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_LanAuditarProdutor()
        { }

        public TList_LanAuditarProdutor(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanAuditarProdutor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanAuditarProdutor x, TRegistro_LanAuditarProdutor y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    public class TRegistro_LanAuditarProdutor
    {
        public string Cd_empresa { get; set; }
        public string Nr_notafiscal { get; set; }
        public decimal? Nr_lanctofiscal { get; set; }
        public string Nr_serie { get; set; }
        public DateTime? Dt_emissao { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Mov { get; set; }
        public string Sigla { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Vl_unitario { get; set; }
        public decimal Vl_subtotal { get; set; }
        public decimal? id_lotectb_fat { get; set; }
    }

    public struct FiltroAuditar
    {
        public string Cd_empresa;
        public string Cd_clifor;
        public string Dt_ini;
        public string Dt_fin;
    }

    public class TCD_LanAuditarProdutor : TDataQuery
    {
        public TCD_LanAuditarProdutor() { }

        public TCD_LanAuditarProdutor(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(FiltroAuditar[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, convert(varchar(10), a.nr_notafiscal) as Nr_notafiscal, a.nr_lanctofiscal, ");
            sql.AppendLine("a.nr_serie, a.dt_emissao, b.cd_produto, c.ds_produto, 'PAUTA' as Mov, ");
            sql.AppendLine("d.Sigla_Unidade as Sigla, b.Quantidade, b.Vl_Unitario, b.Vl_SubTotal, b.id_lotectb_fat ");
            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.CD_Unidade ");
            sql.AppendLine("where a.Tp_Movimento = 'E' ");
            sql.AppendLine("and a.cd_empresa = '" + filtro[0].Cd_empresa.Trim() + "' ");
            sql.AppendLine("and case when a.Tp_Nota = 'P' then a.DT_Emissao else a.DT_SaiEnt end between '" + filtro[0].Dt_ini.Trim() + "' and '" + filtro[0].Dt_fin.Trim() + "' ");
            sql.AppendLine("and exists(select 1 from VTB_GRO_CONTRATO x ");
            sql.AppendLine("where x.nr_pedido = b.nr_pedido ");
            sql.AppendLine("and x.cd_produto = b.cd_produto ");
            if (!string.IsNullOrEmpty(filtro[0].Cd_clifor))
                sql.AppendLine("and x.cd_clifor = '" + filtro[0].Cd_clifor.Trim() + "' ");
            sql.AppendLine("and x.id_pedidoitem = b.id_pedidoitem) ");
            sql.AppendLine("and not exists(select 1 from tb_gro_fixacao_nf x ");
            sql.AppendLine("               inner join tb_gro_fixacao y ");
            sql.AppendLine("               on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("               where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("               and x.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("               and x.id_nfitem = b.id_nfitem ");
            sql.AppendLine("               and isnull(y.st_registro, 'A') <> 'C' ");
            sql.AppendLine("               and x.tp_nota in ('D', 'C')) ");
            sql.AppendLine();
            sql.AppendLine("union all ");
            sql.AppendLine();
            sql.AppendLine("select a.cd_empresa, convert(varchar(10), a.nr_notafiscal) as Nr_notafiscal, a.nr_lanctofiscal, ");
            sql.AppendLine("a.nr_serie, a.dt_emissao, b.cd_produto, c.ds_produto, 'DEVOLUÇÃO' as Mov, ");
            sql.AppendLine("d.Sigla_Unidade as Sigla, b.Quantidade, b.Vl_Unitario, b.Vl_SubTotal, b.id_lotectb_fat ");
            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.CD_Unidade ");
            sql.AppendLine("where a.Tp_Movimento = 'S' ");
            sql.AppendLine("and a.cd_empresa = '" + filtro[0].Cd_empresa.Trim() + "' ");
            sql.AppendLine("and case when a.Tp_Nota = 'P' then a.DT_Emissao else a.DT_SaiEnt end between '" + filtro[0].Dt_ini.Trim() + "' and '" + filtro[0].Dt_fin.Trim() + "' ");
            sql.AppendLine("and exists(select 1 from VTB_GRO_CONTRATO x ");
            sql.AppendLine("            where x.nr_pedido = b.nr_pedido ");
            sql.AppendLine("            and x.cd_produto = b.cd_produto ");
            if (!string.IsNullOrEmpty(filtro[0].Cd_clifor))
                sql.AppendLine("            and x.cd_clifor = '" + filtro[0].Cd_clifor.Trim() + "' ");
            sql.AppendLine("            and x.id_pedidoitem = b.id_pedidoitem) ");
            sql.AppendLine("and exists(select 1 from tb_fat_compdevol_nf x ");
            sql.AppendLine("            where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("            and x.nr_lanctofiscal_destino = b.nr_lanctofiscal ");
            sql.AppendLine("            and x.id_nfitem_destino = b.id_nfitem ");
            sql.AppendLine("            and x.tp_operacao = 'D') ");
            sql.AppendLine();
            sql.AppendLine("union all ");
            sql.AppendLine();
            sql.AppendLine("select a.cd_empresa, convert(varchar(10), a.nr_notafiscal) as Nr_notafiscal, a.nr_lanctofiscal, ");
            sql.AppendLine("a.nr_serie, a.dt_emissao, b.cd_produto, c.ds_produto, 'FIXAÇÃO' as Mov, ");
            sql.AppendLine("d.Sigla_Unidade as Sigla, b.Quantidade, b.Vl_Unitario, b.Vl_SubTotal, b.id_lotectb_fat ");
            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.CD_Unidade ");
            sql.AppendLine("where a.Tp_Movimento = 'E' ");
            sql.AppendLine("and a.cd_empresa = '" + filtro[0].Cd_empresa.Trim() + "' ");
            sql.AppendLine("and case when a.Tp_Nota = 'P' then a.DT_Emissao else a.DT_SaiEnt end between '" + filtro[0].Dt_ini.Trim() + "' and '" + filtro[0].Dt_fin.Trim() + "' ");
            sql.AppendLine("and exists(select 1 from VTB_GRO_CONTRATO x ");
            sql.AppendLine("            where x.nr_pedido = b.nr_pedido ");
            sql.AppendLine("            and x.cd_produto = b.cd_produto ");
            if (!string.IsNullOrEmpty(filtro[0].Cd_clifor))
                sql.AppendLine("            and x.cd_clifor = '" + filtro[0].Cd_clifor.Trim() + "' ");
            sql.AppendLine("            and x.id_pedidoitem = b.id_pedidoitem) ");
            sql.AppendLine("and exists(select 1 from tb_gro_fixacao_nf x ");
            sql.AppendLine("            inner join tb_gro_fixacao y ");
            sql.AppendLine("             on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("            where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("            and x.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("            and x.id_nfitem = b.id_nfitem ");
            sql.AppendLine("            and isnull(y.st_registro, 'A') <> 'C' ");
            sql.AppendLine("            and x.tp_nota in ('D', 'C')) ");
            sql.AppendLine();
            sql.AppendLine("union all ");
            sql.AppendLine();
            sql.AppendLine("select b.CD_Empresa, b.Nr_Docto as Nr_notafiscal, b.Nr_Lancto, '' as nr_serie, ");
            sql.AppendLine("c.DT_Liquidacao, '' as cd_produto, '' as ds_produto, 'RECEBIMENTO' as Mov, ");
            sql.AppendLine("'' as Sigla, 0 as Quantidade, 0 as Vl_Unitario, c.Vl_Liquidacao, d.id_lotectb ");
            sql.AppendLine("from tb_gro_fixacao_x_duplicata a ");
            sql.AppendLine("inner join TB_FIN_Duplicata b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("inner join TB_FIN_Liquidacao c ");
            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and b.nr_lancto = c.Nr_Lancto ");
            sql.AppendLine("and isnull(b.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(c.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join tb_fin_caixa d ");
            sql.AppendLine("on c.cd_contager = d.CD_ContaGer ");
            sql.AppendLine("and c.CD_LanctoCaixa = d.CD_LanctoCaixa ");
            sql.AppendLine("where b.cd_empresa = '" + filtro[0].Cd_empresa.Trim() + "' ");
            if (!string.IsNullOrEmpty(filtro[0].Cd_clifor))
                sql.AppendLine("and b.CD_Clifor = '" + filtro[0].Cd_clifor.Trim() + "' ");
            sql.AppendLine("and c.DT_Liquidacao between '" + filtro[0].Dt_ini.Trim() + "' and '" + filtro[0].Dt_fin.Trim() + "' ");
            sql.AppendLine("union all ");
            sql.AppendLine("select a.cd_empresa, convert(varchar(10), a.nr_notafiscal), a.nr_lanctofiscal, ");
            sql.AppendLine("a.nr_serie, a.dt_emissao, convert(varchar(10), e.CD_Imposto) as cd_produto, f.ds_imposto as ds_produto, 'IMPOSTOS' as Mov, ");
            sql.AppendLine("'' as Sigla, 0 as Quantidade, 0 as Vl_Unitario, e.vl_impostoretido, e.Id_LoteCTB_Retido ");
            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.CD_Unidade ");
            sql.AppendLine("inner join TB_FAT_ImpostosNF e ");
            sql.AppendLine("on e.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and e.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("and e.ID_NFItem = b.ID_NFItem ");
            sql.AppendLine("inner join TB_FIS_Imposto f ");
            sql.AppendLine("on e.cd_imposto = f.cd_imposto ");
            sql.AppendLine("where e.vl_impostoretido > 0 ");
            sql.AppendLine("and a.cd_empresa = '" + filtro[0].Cd_empresa.Trim() + "' ");
            sql.AppendLine("and case when a.Tp_Nota = 'P' then a.DT_Emissao else a.DT_SaiEnt end between '" + filtro[0].Dt_ini.Trim() + "' and '" + filtro[0].Dt_fin.Trim() + "' ");
            sql.AppendLine("and exists(select 1 from VTB_GRO_CONTRATO x ");
            sql.AppendLine("            where x.nr_pedido = b.nr_pedido ");
            sql.AppendLine("           and x.cd_produto = b.cd_produto ");
            if (!string.IsNullOrEmpty(filtro[0].Cd_clifor))
                sql.AppendLine("            and x.cd_clifor = '" + filtro[0].Cd_clifor.Trim() + "' ");
            sql.AppendLine("           and x.id_pedidoitem = b.id_pedidoitem ) ");
            sql.AppendLine("and exists(select 1 from tb_gro_fixacao_nf x ");
            sql.AppendLine("            inner join tb_gro_fixacao y ");
            sql.AppendLine("            on x.id_fixacao = y.id_fixacao ");
            sql.AppendLine("            where x.cd_empresa = b.cd_empresa ");
            sql.AppendLine("            and x.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("            and x.id_nfitem = b.id_nfitem ");
            sql.AppendLine("            and isnull(y.st_registro, 'A') <> 'C')");
            return sql.ToString();
        }

        public TList_LanAuditarProdutor Select(FiltroAuditar[] filtro)
        {
            TList_LanAuditarProdutor lista = new TList_LanAuditarProdutor();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAuditarProdutor reg = new TRegistro_LanAuditarProdutor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_notafiscal"))))
                        reg.Nr_notafiscal = reader.GetString(reader.GetOrdinal("Nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_lanctofiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Dt_emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("Dt_emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("Ds_produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Mov"))))
                        reg.Mov = reader.GetString(reader.GetOrdinal("Mov"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla"))))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_subtotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_lotectb_fat"))))
                        reg.id_lotectb_fat = reader.GetDecimal(reader.GetOrdinal("id_lotectb_fat"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
    }
}
