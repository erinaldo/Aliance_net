using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Dashboard
{
    public class TList_DashProduto : List<TRegistro_DashProduto>
    { }

    public class TRegistro_DashProduto
    {
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Cd_grupo { get; set; }
        public decimal Cf { get; set; }
        public decimal Cv { get; set; }
        public decimal Cmp { get; set; }
        //public decimal CmpTotal { get; set; }
        public decimal Pv { get; set; }
        public decimal Lucro
        {
            get
            {
                return Pv - Cmv;
            }
            set { }
        }
        public decimal MargContr
        {
            get
            {
                if (Pv > 0)
                    return (Lucro * 100) / Pv;
                else
                    return 0;
            }
            set { }
        } //Margem de contribuição em percentual
        /// <summary>
        /// Margem de contribuição em valor
        /// Consiste na diferença entre o preço de venda de um produto/serviço e a ssoma dos custos e despesas variáveis.
        /// </summary>
        public decimal MargContrEmValor
        {
            get { return Pv - Cmv; }
            set { }
        }
        public decimal Cmv
        {
            get
            {
                return (Cmp * (Markup / 100)) + Cmp;
            }
            set { }
        } //Custo total
        public decimal Markup
        { get; set; }
        public decimal QuantidadeVendida
        { get; set; }
        public decimal PontoEquilibrio
        { get; set; }
        public decimal teste
        {
            get { return PontoEquilibrio * Pv; }
        }


        public TRegistro_DashProduto()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_grupo = string.Empty;
            Cf = decimal.Zero;
            Cv = decimal.Zero;
            Cmp = decimal.Zero;
            Markup = decimal.Zero;
            Cmv = decimal.Zero;
            Pv = decimal.Zero;
            Lucro = decimal.Zero;
            MargContr = decimal.Zero;
            QuantidadeVendida = decimal.Zero;
        }

    }

    public class TCD_DashProduto : TDataQuery
    {
        public TCD_DashProduto()
        { }

        public TCD_DashProduto(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vCd_Empresa, string vCd_TabPreco)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (!vCd_Empresa.Trim().Equals(string.Empty) && !vCd_TabPreco.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select a.cd_produto, a.ds_produto, a.cd_grupo, ");
                sql.AppendLine("cmp = isnull((select top 1 VL_UNITARIO ");
                sql.AppendLine("                from tb_est_estoque ");
                sql.AppendLine("               where tp_movimento = 'E' ");
                sql.AppendLine("                 and isnull(st_registro, 'C') = 'A' ");
                sql.AppendLine("                 and tp_lancto  = 'N' ");
                sql.AppendLine("                 and cd_empresa = '" + vCd_Empresa.Trim() + "' ");
                sql.AppendLine("                 and cd_produto = a.cd_produto ");
                sql.AppendLine("               order by dt_lancto desc), 0), ");
                sql.AppendLine("cf = isnull((select sum(a.vl_documento) ");
                sql.AppendLine("               from TB_FIN_Duplicata a ");
                sql.AppendLine("              inner join TB_FIN_Historico b on a.CD_Historico = b.CD_Historico ");
                sql.AppendLine("              inner join TB_FIN_GrupoCF c on b.CD_GrupoCF = c.CD_GrupoCF ");
                sql.AppendLine("              where ISNULL(a.ST_Registro, 'C') = 'A' ");
                sql.AppendLine("                and datepart(month, a.dt_emissao) = datepart(month, dateadd(month, -1, getdate()))");
                sql.AppendLine("                and datepart(year, a.dt_emissao) = datepart(year, getdate()) ");
                sql.AppendLine("                and a.cd_empresa = '" + vCd_Empresa.Trim() + "' ");
                sql.AppendLine("                and ISNULL(c.tp_custo, null) = 'F'), 0), ");
                sql.AppendLine("cv = isnull((select sum(a.vl_documento) ");
                sql.AppendLine("               from TB_FIN_Duplicata a ");
                sql.AppendLine("              inner join TB_FIN_Historico b on a.CD_Historico = b.CD_Historico ");
                sql.AppendLine("              inner join TB_FIN_GrupoCF c on b.CD_GrupoCF = c.CD_GrupoCF ");
                sql.AppendLine("              where ISNULL(a.ST_Registro, 'C') = 'A' ");
                sql.AppendLine("                and datepart(month, a.dt_emissao) = datepart(month, dateadd(month, -1, getdate()))");
                sql.AppendLine("                and datepart(year, a.dt_emissao) = datepart(year, getdate()) ");
                sql.AppendLine("                and a.cd_empresa = '" + vCd_Empresa.Trim() + "' ");
                sql.AppendLine("                and ISNULL(c.tp_custo, null) = 'V'), 0), ");
                sql.AppendLine("pv = dbo.F_PRECO_VENDA('" + vCd_Empresa.Trim() + "', a.cd_produto, '" + vCd_TabPreco.Trim() + "') ");

            }
            else
                sql.AppendLine("select * ");

            sql.AppendLine("from tb_est_produto a ");
            sql.AppendLine("inner join tb_est_tpproduto b ");
            sql.AppendLine("on a.tp_produto = b.tp_produto");
            sql.AppendLine("and isnull(b.st_industrializado, 'N') = 'S' ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public string SqlCodeBuscaProdutoVendido()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.CD_Produto, SUM(b.Quantidade) as Qtd ");
            sql.AppendLine("  from TB_PDV_VendaRapida a ");
            sql.AppendLine(" inner join TB_PDV_VendaRapida_Item b ");
            sql.AppendLine("    on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("   and a.id_vendarapida = b.id_vendarapida ");
            sql.AppendLine("   and isnull(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("   and datepart(month, a.dt_emissao) = datepart(month, dateadd(month, -1, getdate())) ");
            sql.AppendLine("   and datepart(year, a.dt_emissao) = datepart(year, getdate()) ");
            sql.AppendLine(" group by b.CD_Produto ");
            sql.AppendLine("union all ");
            sql.AppendLine("select b.CD_Produto, sum(b.Quantidade) as Qtd ");
            sql.AppendLine("  from TB_FAT_NotaFiscal a ");
            sql.AppendLine(" inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("    on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("   and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("   and ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("   and a.Tp_Movimento = 'S' ");
            sql.AppendLine("   and datepart(month, a.dt_emissao) = datepart(month, dateadd(month, -1, getdate())) ");
            sql.AppendLine("   and datepart(year, a.dt_emissao) = datepart(year, getdate()) ");
            sql.AppendLine(" inner join TB_FAT_NotaFiscal_CMI c ");
            sql.AppendLine("    on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("   and a.Nr_LanctoFiscal = c.Nr_LanctoFiscal");
            sql.AppendLine("   and ISNULL(c.ST_Devolucao, 'N') <> 'S' ");
            sql.AppendLine("   and ISNULL(c.ST_Complementar, 'N') <> 'S' ");
            sql.AppendLine(" group by b.CD_Produto");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vCd_Empresa)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vCd_Empresa, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vCd_Empresa)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vCd_Empresa, string.Empty), null);
        }

        public TList_DashProduto Select(TpBusca[] vBusca, int vTop, string vCd_Empresa, string vCd_TabPreco)
        {
            TList_DashProduto lista = new TList_DashProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vCd_Empresa, vCd_TabPreco));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DashProduto reg = new TRegistro_DashProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cmp")))
                        reg.Cmp = reader.GetDecimal(reader.GetOrdinal("cmp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cf")))
                        reg.Cf = reader.GetDecimal(reader.GetOrdinal("cf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cv")))
                        reg.Cv = reader.GetDecimal(reader.GetOrdinal("cv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pv")))
                        reg.Pv = reader.GetDecimal(reader.GetOrdinal("pv"));
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

        public TList_DashProduto quantidadeProdutoVendido()
        {
            TList_DashProduto lista = new TList_DashProduto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaProdutoVendido());
            try
            {
                while (reader.Read())
                {
                    TRegistro_DashProduto reg = new TRegistro_DashProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd")))
                        reg.QuantidadeVendida = reader.GetDecimal(reader.GetOrdinal("qtd"));
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

    }

}
