using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal.LMC
{
    #region Afericao Tanque
    public class TList_AfericaoTanque : List<TRegistro_AfericaoTanque>
    { }

    
    public class TRegistro_AfericaoTanque
    {
        
        public decimal? Id_tanque
        { get; set; }
        
        public string Ds_combustivel
        { get; set; }
        
        public decimal CapacidadeTanque
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Qtd_combustivel
        { get; set; }

        public TRegistro_AfericaoTanque()
        {
            Id_tanque = null;
            Ds_combustivel = string.Empty;
            CapacidadeTanque = decimal.Zero;
            Sigla_unidade = string.Empty;
            Qtd_combustivel = decimal.Zero;
        }
    }

    public class TCD_AfericaoTanque : TDataQuery
    {
        public TCD_AfericaoTanque()
        { }

        public TCD_AfericaoTanque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_combustivel,
                                    DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_Tanque, a.CapacidadeTanque, c.sigla_unidade, b.ds_produto, ");
            sql.AppendLine("qtd_combustivel = ISNULL((case when exists(select 1 ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'A') then ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'A' ");
            sql.AppendLine("									order by x.DT_Medicao) else ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(-1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'F' ");
            sql.AppendLine("									order by x.DT_Medicao desc) end), 0) ");

            sql.AppendLine("from TB_PDC_Tanque a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.cd_produto = '" + Cd_combustivel.Trim() + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and ISNULL((case when exists(select 1 ");
            sql.AppendLine("			from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("			where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("			and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("			and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("			and x.tp_medicao = 'A') then ");
            sql.AppendLine("			(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("			from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("			where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("			and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("			and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("			and x.tp_medicao = 'A' ");
            sql.AppendLine("			order by x.DT_Medicao) else ");
            sql.AppendLine("			(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("			from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("			where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("			and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("			and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(-1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("			and x.tp_medicao = 'F' ");
            sql.AppendLine("			order by x.DT_Medicao desc) end), 0) > 0 ");

            return sql.ToString();
        }

        public TList_AfericaoTanque Select(string Cd_empresa,
                                           string Cd_combustivel,
                                           DateTime Dt_emissao)
        {
            TList_AfericaoTanque lista = new TList_AfericaoTanque();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_combustivel, Dt_emissao));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AfericaoTanque reg = new TRegistro_AfericaoTanque();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapacidadeTanque")))
                        reg.CapacidadeTanque = reader.GetDecimal(reader.GetOrdinal("CapacidadeTanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_combustivel")))
                        reg.Qtd_combustivel = reader.GetDecimal(reader.GetOrdinal("qtd_combustivel"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Volume Recebido
    public class TList_VolumeRecebido : List<TRegistro_VolumeRecebido>
    { }
    
    public class TRegistro_VolumeRecebido
    {
        public decimal? Nr_notafiscal
        { get; set; }
        public DateTime? Dt_saient
        { get; set; }
        public decimal? Id_tanque
        { get; set; }
        public string Ds_combustivel
        { get; set; }
        public decimal Qtd_combustivel
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }

        public TRegistro_VolumeRecebido()
        {
            Nr_notafiscal = null;
            Dt_saient = null;
            Id_tanque = null;
            Ds_combustivel = string.Empty;
            Qtd_combustivel = decimal.Zero;
            Sigla_unidade = string.Empty;
            Nr_lanctofiscal = null;
            Id_nfitem = null;
        }
    }

    public class TCD_VolumeRecebido : TDataQuery
    {
        public TCD_VolumeRecebido()
        { }

        public TCD_VolumeRecebido(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_combustivel,
                                    string Id_tanque,
                                    DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Nr_NotaFiscal, a.DT_SaiEnt, f.Id_Tanque, ");
            sql.AppendLine("c.DS_Produto, b.Quantidade, e.Sigla_Unidade, ");
            sql.AppendLine("a.NR_LanctoFiscal, b.ID_NFItem ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_TpProduto d ");
            sql.AppendLine("on c.TP_Produto = d.TP_Produto ");
            sql.AppendLine("and ISNULL(d.ST_Combustivel, 'N') = 'S' ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on c.CD_Unidade = e.CD_Unidade ");
            sql.AppendLine("inner join TB_PDC_Tanque f ");
            sql.AppendLine("on b.CD_Empresa = f.CD_Empresa ");
            sql.AppendLine("and b.CD_Local = f.CD_Local ");
            sql.AppendLine("and b.CD_Produto = f.CD_Produto ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI cmi ");
            sql.AppendLine("on a.cd_empresa = cmi.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = cmi.nr_lanctofiscal ");
            sql.AppendLine("and isnull(cmi.st_mestra, 'N') <> 'S' ");

            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(f.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(f.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and a.Tp_Movimento = 'E' ");
            sql.AppendLine("and ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and b.cd_produto = '" + Cd_combustivel.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_tanque))
                sql.AppendLine("and f.id_tanque = " + Id_tanque);
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) between '" + 
                string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "' and '" + 
                string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");

            return sql.ToString();
        }

        public TList_VolumeRecebido Select(string Cd_empresa,
                                           string Cd_combustivel,
                                           string Id_tanque,
                                           DateTime Dt_emissao)
        {
            TList_VolumeRecebido lista = new TList_VolumeRecebido();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_combustivel, Id_tanque, Dt_emissao));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VolumeRecebido reg = new TRegistro_VolumeRecebido();
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("Id_Tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Qtd_combustivel = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Volume Vendido
    public class TList_VolumeVendido : List<TRegistro_VolumeVendido>
    { }

    
    public class TRegistro_VolumeVendido
    {
        
        public decimal? Id_tanque
        { get; set; }
        
        public decimal? Id_bico
        { get; set; }
        
        public string Cd_bico
        { get; set; }
        
        public decimal Qtd_fechamento
        { get; set; }
        
        public decimal Qtd_abertura
        { get; set; }
        
        public decimal Qtd_afericao
        { get; set; }
        
        public decimal Vl_venda
        { get; set; }
        public decimal Qtd_vendas
        { get { return Qtd_fechamento - Qtd_abertura - Qtd_afericao; } }

        public TRegistro_VolumeVendido()
        {
            Id_tanque = null;
            Id_bico = null;
            Cd_bico = string.Empty;
            Qtd_fechamento = decimal.Zero;
            Qtd_abertura = decimal.Zero;
            Qtd_afericao = decimal.Zero;
            Vl_venda = decimal.Zero;
        }
    }

    public class TCD_VolumeVendido : TDataQuery
    {
        public TCD_VolumeVendido()
        { }

        public TCD_VolumeVendido(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_combustivel,
                                    DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_Tanque, a.ds_label, a.id_bico, ");
            sql.AppendLine("qtd_fechamento = ISNULL((case when exists(select 1 ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'F') then ");
            sql.AppendLine("									(select top 1 x.QTD_Encerrante ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'F' ");
            sql.AppendLine("									order by x.DT_Encerrante desc) else ");
            sql.AppendLine("									(select top 1 x.QTD_Encerrante ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'A' ");
            sql.AppendLine("									order by x.DT_Encerrante asc) end), 0), ");
            
            sql.AppendLine("qtd_abertura = ISNULL((case when exists(select 1 ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'A') then ");
            sql.AppendLine("									(select top 1 x.QTD_Encerrante ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'A' ");
            sql.AppendLine("									order by x.DT_Encerrante asc) else ");
            sql.AppendLine("									(select top 1 x.QTD_Encerrante ");
            sql.AppendLine("									from TB_PDC_EncerranteBico x ");
            sql.AppendLine("									where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(-1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.TP_Encerrante = 'F' ");
            sql.AppendLine("									order by x.DT_Encerrante desc) end), 0), ");

            sql.AppendLine("qtd_afericao = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("						from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("						where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("						and ISNULL(x.ST_Afericao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Abastecimento))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'), 0), ");
            
            sql.AppendLine("vl_venda = ISNULL((select SUM(ISNULL(x.vl_subtotal, 0)) ");
            sql.AppendLine("                        from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("                        where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("                        and ISNULL(x.ST_Afericao, 'N') <> 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Abastecimento))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'), 0) ");

            sql.AppendLine("from TB_PDC_BicoBomba a ");
            sql.AppendLine("inner join TB_PDC_Tanque b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_tanque = b.id_tanque ");
            sql.AppendLine("where CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and b.cd_produto = '" + Cd_combustivel.Trim() + "'");

            return sql.ToString();
        }

        public TList_VolumeVendido Select(string Cd_empresa,
                                           string Cd_combustivel,
                                           DateTime Dt_emissao)
        {
            TList_VolumeVendido lista = new TList_VolumeVendido();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_combustivel, Dt_emissao));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VolumeVendido reg = new TRegistro_VolumeVendido();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("Id_Tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Cd_bico = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_fechamento")))
                        reg.Qtd_fechamento = reader.GetDecimal(reader.GetOrdinal("qtd_fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_abertura")))
                        reg.Qtd_abertura = reader.GetDecimal(reader.GetOrdinal("qtd_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_afericao")))
                        reg.Qtd_afericao = reader.GetDecimal(reader.GetOrdinal("qtd_afericao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_venda")))
                        reg.Vl_venda = reader.GetDecimal(reader.GetOrdinal("vl_venda"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Fechamento Fisico
    public class TList_FechamentoFisico : List<TRegistro_FechamentoFisico>
    { }
    
    public class TRegistro_FechamentoFisico
    {
        
        public decimal? Id_tanque
        { get; set; }
        
        public string Ds_combustivel
        { get; set; }
        
        public decimal CapacidadeTanque
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Qtd_combustivel
        { get; set; }

        public TRegistro_FechamentoFisico()
        {
            Id_tanque = null;
            Ds_combustivel = string.Empty;
            CapacidadeTanque = decimal.Zero;
            Sigla_unidade = string.Empty;
            Qtd_combustivel = decimal.Zero;
        }
    }

    public class TCD_FechamentoFisico : TDataQuery
    {
        public TCD_FechamentoFisico()
        { }

        public TCD_FechamentoFisico(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_combustivel,
                                    DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_Tanque, a.CapacidadeTanque, c.sigla_unidade, b.ds_produto, ");
            sql.AppendLine("qtd_combustivel = ISNULL((case when exists(select 1 ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'F') then ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'F' ");
            sql.AppendLine("									order by x.DT_Medicao) else ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'A' ");
            sql.AppendLine("									order by x.DT_Medicao desc) end), 0) ");

            sql.AppendLine("from TB_PDC_Tanque a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");

            sql.AppendLine("where (ISNULL((case when exists(select 1 ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'F') then ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'F' ");
            sql.AppendLine("									order by x.DT_Medicao) else ");
            sql.AppendLine("									(select top 1 x.QTD_Combustivel ");
            sql.AppendLine("									from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("									where x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("									and x.Id_Tanque = a.id_tanque ");
            sql.AppendLine("									and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.AddDays(1).ToString("yyyyMMdd")) + "'");
            sql.AppendLine("									and x.tp_medicao = 'A' ");
            sql.AppendLine("									order by x.DT_Medicao desc) end), 0) > 0) ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.cd_produto = '" + Cd_combustivel.Trim() + "'");

            return sql.ToString();
        }

        public TList_FechamentoFisico Select(string Cd_empresa,
                                           string Cd_combustivel,
                                           DateTime Dt_emissao)
        {
            TList_FechamentoFisico lista = new TList_FechamentoFisico();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_combustivel, Dt_emissao));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FechamentoFisico reg = new TRegistro_FechamentoFisico();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CapacidadeTanque")))
                        reg.CapacidadeTanque = reader.GetDecimal(reader.GetOrdinal("CapacidadeTanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_combustivel")))
                        reg.Qtd_combustivel = reader.GetDecimal(reader.GetOrdinal("qtd_combustivel"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion
}
