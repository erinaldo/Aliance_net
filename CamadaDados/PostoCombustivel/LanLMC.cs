using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region LMC
    public class TList_LMC : List<TRegistro_LMC>, IComparer<TRegistro_LMC>
    {
        #region IComparer<TRegistro_LMC> Members
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

        public TList_LMC()
        { }

        public TList_LMC(System.ComponentModel.PropertyDescriptor Prop,
                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LMC value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LMC x, TRegistro_LMC y)
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

    public class TRegistro_LMC
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cnpj_empresa
        { get; set; }
        public string IE_empresa
        { get; set; }
        private decimal? id_lmc;
        public decimal? Id_lmc
        {
            get { return id_lmc; }
            set
            {
                id_lmc = value;
                id_lmcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lmcstr;
        public string Id_lmcstr
        {
            get { return id_lmcstr; }
            set
            {
                id_lmcstr = value;
                try
                {
                    id_lmc = decimal.Parse(value);
                }
                catch { id_lmc = null; }
            }
        }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get 
            {
                try
                {
                    return dt_emissaostr;
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        public string Chaveacesso
        { get; set; }
        private DateTime? dt_recebimento;
        public DateTime? Dt_recebimento
        {
            get { return dt_recebimento; }
            set
            {
                dt_recebimento = value;
                dt_recebimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_recebimentostr;
        public string Dt_recebimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_recebimentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_recebimentostr = value;
                try
                {
                    dt_recebimento = DateTime.Parse(value);
                }
                catch { dt_recebimento = null; }
            }
        }
        public decimal Status
        { get; set; }
        public string xMotivo
        { get; set; }
        public string nProt
        { get; set; }
        public string digVal
        { get; set; }
        public string Xml_lmc
        { get; set; }

        public TList_MovLMC lMov
        { get; set; }

        public TRegistro_LMC()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cnpj_empresa = string.Empty;
            this.IE_empresa = string.Empty;
            this.id_lmc = null;
            this.id_lmcstr = string.Empty;
            this.dt_emissao = null;
            this.dt_emissaostr = string.Empty;
            this.Chaveacesso = string.Empty;
            this.dt_recebimento = null;
            this.dt_recebimentostr = string.Empty;
            this.Status = 0;
            this.xMotivo = string.Empty;
            this.nProt = string.Empty;
            this.digVal = string.Empty;
            this.Xml_lmc = string.Empty;

            this.lMov = new TList_MovLMC();
        }
    }

    public class TCD_LMC : TDataQuery
    {
        public TCD_LMC() { }

        public TCD_LMC(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("c.nr_cgc, d.insc_estadual, a.ChaveAcesso, ");
                sql.AppendLine("a.ID_LMC, a.dt_emissao, ");
                sql.AppendLine("a.Status, a.xMotivo, a.nProt, a.digVal, ");
                sql.AppendLine("a.dt_recebimento, a.xml_lmc ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_LMC a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor_PJ c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_Endereco d ");
            sql.AppendLine("on b.cd_clifor = d.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = d.cd_endereco ");

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

        public TList_LMC Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LMC lista = new TList_LMC();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LMC reg = new TRegistro_LMC();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj_empresa = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.IE_empresa = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lmc")))
                        reg.Id_lmc = reader.GetDecimal(reader.GetOrdinal("id_lmc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ChaveAcesso")))
                        reg.Chaveacesso = reader.GetString(reader.GetOrdinal("ChaveAcesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_recebimento")))
                        reg.Dt_recebimento = reader.GetDateTime(reader.GetOrdinal("dt_recebimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xMotivo")))
                        reg.xMotivo = reader.GetString(reader.GetOrdinal("xMotivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nProt")))
                        reg.nProt = reader.GetString(reader.GetOrdinal("nProt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("digVal")))
                        reg.digVal = reader.GetString(reader.GetOrdinal("digVal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_lmc")))
                        reg.Xml_lmc = reader.GetString(reader.GetOrdinal("xml_lmc"));

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

        public string Gravar(TRegistro_LMC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_CHAVEACESSO", val.Chaveacesso);
            hs.Add("@P_DT_RECEBIMENTO", val.Dt_recebimento);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_XMOTIVO", val.xMotivo);
            hs.Add("@P_NPROT", val.nProt);
            hs.Add("@P_DIGVAL", val.digVal);
            hs.Add("@P_XML_LMC", val.Xml_lmc);

            return this.executarProc("IA_PDC_LMC", hs);
        }

        public string Excluir(TRegistro_LMC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);

            return this.executarProc("EXCLUI_PDC_LMC", hs);
        }

        public TList_MovLMC SelectLMC(string Cd_empresa,
                                   DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Produto, a.DS_Produto, a.TP_Combustivel, ");
            sql.AppendLine("VolumeAbertura = ISNULL((case when exists(select 1 "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x "); 
            sql.AppendLine("							inner join TB_PDC_Tanque y ");
            sql.AppendLine("							on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("							and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.CD_Produto = a.CD_Produto ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'A') then ");
            sql.AppendLine("							(select sum(x.QTD_Combustivel) "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("							inner join TB_PDC_Tanque y ");
            sql.AppendLine("							on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("							and x.id_tanque = y.id_tanque "); 
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.CD_Produto = a.CD_Produto ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'A') else ");
            sql.AppendLine("							(select sum(x.QTD_Combustivel) "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("							inner join TB_PDC_Tanque y ");
            sql.AppendLine("							on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("							and x.Id_Tanque = y.Id_Tanque "); 
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.cd_produto = a.CD_Produto ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.AddDays(-1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'F') end), 0), ");
            sql.AppendLine("VolumeFechamento = ISNULL((case when exists(select 1 "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("							inner join tb_pdc_tanque y ");
            sql.AppendLine("							on x.cd_empresa = y.CD_Empresa ");
            sql.AppendLine("							and x.Id_Tanque = y.Id_Tanque "); 
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.CD_Produto = a.CD_Produto ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'F') then ");
            sql.AppendLine("							(select sum(x.QTD_Combustivel) "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x "); 
            sql.AppendLine("							inner join TB_PDC_Tanque y ");
            sql.AppendLine("							on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("							and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.cd_produto = a.cd_produto "); 
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'F') else ");
            sql.AppendLine("							(select sum(x.QTD_Combustivel) "); 
            sql.AppendLine("							from TB_PDC_MedicaoTanque x "); 
            sql.AppendLine("							inner join TB_PDC_Tanque y ");
            sql.AppendLine("							on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("							and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("							where x.CD_Empresa = '" + Cd_empresa.Trim() + "' "); 
            sql.AppendLine("							and y.CD_Produto = a.CD_Produto ");
            sql.AppendLine("							and convert(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_emissao.AddDays(1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(y.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("							and x.tp_medicao = 'A') end), 0), ");
            sql.AppendLine("Vl_VendaDia = ISNULL((select SUM(ISNULL(y.vl_subtotal, 0) + isnull(y.Vl_Acrescimo, 0) + ISNULL(y.Vl_Frete, 0) + isnull(y.Vl_Juro_Fin, 0) - isnull(y.Vl_Desconto, 0)) ");
            sql.AppendLine("						from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("						inner join TB_PDV_VendaRapida_Item y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Id_Cupom = y.Id_VendaRapida ");
            sql.AppendLine("						and x.Id_lancto = y.Id_lanctoVenda ");
            sql.AppendLine("						where isnull(x.st_afericao, 'N') <> 'S' ");
            sql.AppendLine("						and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("						and x.CD_Produto = a.cd_produto ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Abastecimento))) = '" + Dt_emissao.ToString("yyyyMMdd") + "'), 0) ");
            sql.AppendLine("from tb_est_produto a ");
            sql.AppendLine("inner join tb_est_tpproduto b ");
            sql.AppendLine("on a.tp_produto = b.tp_produto ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(b.ST_Combustivel, 'N') = 'S' ");

            TList_MovLMC lista = new TList_MovLMC();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovLMC reg = new TRegistro_MovLMC();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Combustivel")))
                        reg.Tp_combustivel = reader.GetString(reader.GetOrdinal("TP_Combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAbertura")))
                        reg.Volumeabertura = reader.GetDecimal(reader.GetOrdinal("VolumeAbertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeFechamento")))
                        reg.Volumefechamento = reader.GetDecimal(reader.GetOrdinal("VolumeFechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_VendaDia")))
                        reg.Vl_vendasdia = reader.GetDecimal(reader.GetOrdinal("Vl_VendaDia"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Mov LMC
    public class TList_MovLMC : List<TRegistro_MovLMC>, IComparer<TRegistro_MovLMC>
    {
        #region IComparer<TRegistro_MovLMC> Members
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

        public TList_MovLMC()
        { }

        public TList_MovLMC(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovLMC value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovLMC x, TRegistro_MovLMC y)
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

    public class TRegistro_MovLMC
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_lmc;
        public decimal? Id_lmc
        {
            get { return id_lmc; }
            set
            {
                id_lmc = value;
                id_lmcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lmcstr;
        public string Id_lmcstr
        {
            get { return id_lmcstr; }
            set
            {
                id_lmcstr = value;
                try
                {
                    id_lmc = decimal.Parse(value);
                }
                catch { id_lmc = null; }
            }
        }
        private decimal? id_movto;
        public decimal? Id_movto
        {
            get { return id_movto; }
            set
            {
                id_movto = value;
                id_movtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movtostr;
        public string Id_movtostr
        {
            get { return id_movtostr; }
            set
            {
                id_movtostr = value;
                try
                {
                    id_movto = decimal.Parse(value);
                }
                catch { id_movto = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Tp_combustivel
        { get; set; }
        public decimal Volumeabertura
        { get; set; }
        public decimal Tot_recebido
        {
            get { return lRec.Sum(p => p.VolumeRecebido); }
        }
        public decimal Tot_disponivel
        { get { return Volumeabertura + Tot_recebido; } }
        public decimal Tot_vendasdia
        { get { return lVend.Sum(p => p.Volfechamento - p.Volabertura - p.Volafericao); } }
        public decimal Tot_estoquecontabil
        { get { return Tot_disponivel - Tot_vendasdia; } }
        public decimal Volumefechamento
        { get; set; }
        public decimal Perdas_ganhos
        { get { return Volumefechamento - Tot_estoquecontabil; } }
        public decimal Pc_perdaganho
        {
            get
            {
                if (Perdas_ganhos > decimal.Zero)
                    return Math.Round(Math.Abs(((Tot_estoquecontabil * 100) / Volumefechamento) - 100), 2, MidpointRounding.AwayFromZero);
                else if (Perdas_ganhos < decimal.Zero)
                    return Math.Round(Math.Abs(((Volumefechamento * 100) / Tot_estoquecontabil) - 100), 2, MidpointRounding.AwayFromZero);
                else return decimal.Zero;
            }
        }
        public decimal Vl_vendasdia
        { get; set; }

        public string Obs
        { get; set; }

        public TList_MovRec lRec
        { get; set; }
        public TList_MovVend lVend
        { get; set; }

        public TRegistro_MovLMC()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_lmc = null;
            this.id_lmcstr = string.Empty;
            this.id_movto = null;
            this.id_movtostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Tp_combustivel = string.Empty;
            this.Volumeabertura = decimal.Zero;
            this.Volumefechamento = decimal.Zero;
            this.Vl_vendasdia = decimal.Zero;
            this.Obs = string.Empty;

            this.lRec = new TList_MovRec();
            this.lVend = new TList_MovVend();
        }
    }

    public class TCD_MovLMC : TDataQuery
    {
        public TCD_MovLMC() { }

        public TCD_MovLMC(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_LMC, a.ID_Movto, a.CD_Produto, ");
                sql.AppendLine("c.DS_Produto, c.TP_Combustivel, ");
                sql.AppendLine("a.VolumeAbertura, a.VolumeFechamento, ");
                sql.AppendLine("a.Vl_VendasDia, a.Obs ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_movlmc a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.CD_Produto = c.CD_Produto ");

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

        public TList_MovLMC Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MovLMC lista = new TList_MovLMC();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovLMC reg = new TRegistro_MovLMC();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LMC")))
                        reg.Id_lmc = reader.GetDecimal(reader.GetOrdinal("ID_LMC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movto")))
                        reg.Id_movto = reader.GetDecimal(reader.GetOrdinal("ID_Movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Combustivel")))
                        reg.Tp_combustivel = reader.GetString(reader.GetOrdinal("TP_Combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAbertura")))
                        reg.Volumeabertura = reader.GetDecimal(reader.GetOrdinal("VolumeAbertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeFechamento")))
                        reg.Volumefechamento = reader.GetDecimal(reader.GetOrdinal("VolumeFechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_VendasDia")))
                        reg.Vl_vendasdia = reader.GetDecimal(reader.GetOrdinal("Vl_VendasDia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

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

        public string Gravar(TRegistro_MovLMC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_ID_MOVTO", val.Id_movto);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_VOLUMEABERTURA", val.Volumeabertura);
            hs.Add("@P_VOLUMEFECHAMENTO", val.Volumefechamento);
            hs.Add("@P_VL_VENDASDIA", val.Vl_vendasdia);
            hs.Add("@P_OBS", val.Obs);

            return this.executarProc("IA_PDC_MOVLMC", hs);
        }

        public string Excluir(TRegistro_MovLMC val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_ID_MOVTO", val.Id_movto);

            return this.executarProc("EXCLUI_PDC_MOVLMC", hs);
        }
    }
    #endregion

    #region Mov LMC Rec
    public class TList_MovRec : List<TRegistro_MovRec>, IComparer<TRegistro_MovRec>
    {
        #region IComparer<TRegistro_MovRec> Members
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

        public TList_MovRec()
        { }

        public TList_MovRec(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovRec value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovRec x, TRegistro_MovRec y)
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

    public class TRegistro_MovRec
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_lmc;
        public decimal? Id_lmc
        {
            get { return id_lmc; }
            set
            {
                id_lmc = value;
                id_lmcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lmcstr;
        public string Id_lmcstr
        {
            get { return id_lmcstr; }
            set
            {
                id_lmcstr = value;
                try
                {
                    id_lmc = decimal.Parse(value);
                }
                catch { id_lmc = null; }
            }
        }
        private decimal? id_movto;
        public decimal? Id_movto
        {
            get { return id_movto; }
            set
            {
                id_movto = value;
                id_movtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movtostr;
        public string Id_movtostr
        {
            get { return id_movtostr; }
            set
            {
                id_movtostr = value;
                try
                {
                    id_movto = decimal.Parse(value);
                }
                catch { id_movto = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public string Cnpj_fornecedor
        { get; set; }
        private decimal? nr_notafiscal;
        public decimal? Nr_notafiscal
        {
            get { return nr_notafiscal; }
            set
            {
                nr_notafiscal = value;
                nr_notafiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_notafiscalstr;
        public string Nr_notafiscalstr
        {
            get { return nr_notafiscalstr; }
            set
            {
                nr_notafiscalstr = value;
                try
                {
                    nr_notafiscal = decimal.Parse(value);
                }
                catch { nr_notafiscal = null; }
            }
        }
        private DateTime? dt_saient;
        public DateTime? Dt_saient
        {
            get { return dt_saient; }
            set
            {
                dt_saient = value;
                dt_saientstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_saientstr;
        public string Dt_saientstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_saientstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_saientstr = value;
                try
                {
                    dt_saient = DateTime.Parse(value);
                }
                catch { dt_saient = null; }
            }
        }
        public decimal VolumeRecebido
        { get; set; }
        private decimal? id_tanque;
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch { id_tanque = null; }
            }
        }

        public TRegistro_MovRec()
        {
            this.Cd_empresa = string.Empty;
            this.id_lmc = null;
            this.id_lmcstr = string.Empty;
            this.id_movto = null;
            this.id_movtostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.Cnpj_fornecedor = string.Empty;
            this.nr_notafiscal = null;
            this.nr_notafiscalstr = string.Empty;
            this.dt_saient = null;
            this.dt_saientstr = string.Empty;
            this.VolumeRecebido = decimal.Zero;
            this.id_tanque = null;
            this.id_tanquestr = string.Empty;
        }
    }

    public class TCD_MovRec : TDataQuery
    {
        public TCD_MovRec() { }

        public TCD_MovRec(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_LMC, ");
                sql.AppendLine("a.ID_Movto, lmc.CD_Produto, a.NR_LanctoFiscal, a.ID_NFItem, ");
                sql.AppendLine("b.NR_Notafiscal, b.DT_SaiEnt, b.CD_Clifor, ");
                sql.AppendLine("c.NM_Clifor, c.NR_CGC, d.Quantidade, e.id_tanque ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_MovRec a ");
            sql.AppendLine("inner join TB_PDC_MovLMC lmc ");
            sql.AppendLine("on a.CD_Empresa = lmc.CD_Empresa ");
            sql.AppendLine("and a.id_lmc = lmc.ID_LMC ");
            sql.AppendLine("and a.id_movto = lmc.id_movto ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.NR_LanctoFiscal = b.NR_LanctoFiscal ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item d ");
            sql.AppendLine("on a.CD_Empresa = d.CD_Empresa ");
            sql.AppendLine("and a.NR_LanctoFiscal = d.NR_LanctoFiscal ");
            sql.AppendLine("and a.ID_NFItem = d.ID_NFItem ");
            sql.AppendLine("inner join TB_PDC_Tanque e ");
            sql.AppendLine("on d.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and d.cd_produto = e.cd_produto ");
            sql.AppendLine("and d.cd_local = e.cd_local ");

            sql.AppendLine("where b.DT_SaiEnt between isnull(e.DT_Ativacao, getdate()) and isnull(e.DT_Desativacao, getdate()) ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_MovRec Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MovRec lista = new TList_MovRec();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovRec reg = new TRegistro_MovRec();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lmc")))
                        reg.Id_lmc = reader.GetDecimal(reader.GetOrdinal("id_lmc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movto")))
                        reg.Id_movto = reader.GetDecimal(reader.GetOrdinal("id_movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_Notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj_fornecedor = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.VolumeRecebido = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));

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

        public string Gravar(TRegistro_MovRec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_ID_MOVTO", val.Id_movto);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("IA_PDC_MOVREC", hs);
        }

        public string Excluir(TRegistro_MovRec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("EXCLUI_PDC_MOVREC", hs);
        }

        public TList_MovRec SelectRec(string Cd_empresa, string Cd_combustivel, DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Nr_NotaFiscal, a.DT_SaiEnt, f.Id_Tanque, ");
            sql.AppendLine("b.Quantidade, a.NR_LanctoFiscal, b.ID_NFItem ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_PDC_Tanque f ");
            sql.AppendLine("on b.CD_Empresa = f.CD_Empresa ");
            sql.AppendLine("and b.CD_Local = f.CD_Local ");
            sql.AppendLine("and b.CD_Produto = f.CD_Produto ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI cmi ");
            sql.AppendLine("on a.cd_empresa = cmi.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = cmi.nr_lanctofiscal ");
            sql.AppendLine("and isnull(cmi.st_mestra, 'N') <> 'S' ");

            sql.AppendLine("where CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(f.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(f.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and a.Tp_Movimento = 'E' ");
            sql.AppendLine("and ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and b.cd_produto = '" + Cd_combustivel.Trim() + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_saient))) between '" +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "' and '" +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");

            TList_MovRec lista = new TList_MovRec();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovRec reg = new TRegistro_MovRec();
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("Id_Tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.VolumeRecebido = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));


                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Mov LMC Vend
    public class TList_MovVend : List<TRegistro_MovVend>, IComparer<TRegistro_MovVend>
    {
        #region IComparer<TRegistro_MovVend> Members
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

        public TList_MovVend()
        { }

        public TList_MovVend(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovVend value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovVend x, TRegistro_MovVend y)
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

    public class TRegistro_MovVend
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_lmc;
        public decimal? Id_lmc
        {
            get { return id_lmc; }
            set
            {
                id_lmc = value;
                id_lmcstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lmcstr;
        public string Id_lmcstr
        {
            get { return id_lmcstr; }
            set
            {
                id_lmcstr = value;
                try
                {
                    id_lmc = decimal.Parse(value);
                }
                catch { id_lmc = null; }
            }
        }
        private decimal? id_movto;
        public decimal? Id_movto
        {
            get { return id_movto; }
            set
            {
                id_movto = value;
                id_movtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movtostr;
        public string Id_movtostr
        {
            get { return id_movtostr; }
            set
            {
                id_movtostr = value;
                try
                {
                    id_movto = decimal.Parse(value);
                }
                catch { id_movto = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        private decimal? id_bico;
        public decimal? Id_bico
        {
            get { return id_bico; }
            set
            {
                id_bico = value;
                id_bicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bicostr;
        public string Id_bicostr
        {
            get { return id_bicostr; }
            set
            {
                id_bicostr = value;
                try
                {
                    id_bico = decimal.Parse(value);
                }
                catch { id_bico = null; }
            }
        }
        public string Ds_labelbico
        { get; set; }
        private decimal? id_tanque;
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch { id_tanque = null; }
            }
        }
        public decimal Volfechamento
        { get; set; }
        public decimal Volabertura
        { get; set; }
        public decimal Volafericao
        { get; set; }
        public decimal VolVendasDia
        { get { return Volfechamento - Volabertura - Volafericao; } }

        public TRegistro_MovVend()
        {
            this.Cd_empresa = string.Empty;
            this.id_lmc = null;
            this.id_lmcstr = string.Empty;
            this.id_movto = null;
            this.id_movtostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_bico = null;
            this.id_bicostr = string.Empty;
            this.Ds_labelbico = string.Empty;
            this.id_tanque = null;
            this.id_tanquestr = string.Empty;
            this.Volfechamento = decimal.Zero;
            this.Volabertura = decimal.Zero;
            this.Volafericao = decimal.Zero;
        }
    }

    public class TCD_MovVend : TDataQuery
    {
        public TCD_MovVend() { }

        public TCD_MovVend(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_LMC, ");
                sql.AppendLine("a.ID_Movto, lmc.CD_Produto, a.ID_Bico, b.id_tanque, ");
                sql.AppendLine("a.volfechamento, a.volabertura, a.volafericao, b.ds_label ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_MovVend a ");
            sql.AppendLine("inner join TB_PDC_MovLMC lmc ");
            sql.AppendLine("on a.cd_empresa = lmc.cd_empresa ");
            sql.AppendLine("and a.id_lmc = lmc.id_lmc ");
            sql.AppendLine("and a.id_movto = lmc.id_movto ");
            sql.AppendLine("inner join TB_PDC_BicoBomba b ");
            sql.AppendLine("on a.ID_Bico = b.ID_Bico ");

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

        public TList_MovVend Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_MovVend lista = new TList_MovVend();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovVend reg = new TRegistro_MovVend();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lmc")))
                        reg.Id_lmc = reader.GetDecimal(reader.GetOrdinal("id_lmc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_movto")))
                        reg.Id_movto = reader.GetDecimal(reader.GetOrdinal("id_movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Ds_labelbico = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volfechamento")))
                        reg.Volfechamento = reader.GetDecimal(reader.GetOrdinal("volfechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volabertura")))
                        reg.Volabertura = reader.GetDecimal(reader.GetOrdinal("volabertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volafericao")))
                        reg.Volafericao = reader.GetDecimal(reader.GetOrdinal("volafericao"));

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

        public string Gravar(TRegistro_MovVend val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_ID_MOVTO", val.Id_movto);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_VOLFECHAMENTO", val.Volfechamento);
            hs.Add("@P_VOLABERTURA", val.Volabertura);
            hs.Add("@P_VOLAFERICAO", val.Volafericao);

            return this.executarProc("IA_PDC_MOVVEND", hs);
        }

        public string Excluir(TRegistro_MovVend val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LMC", val.Id_lmc);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_BICO", val.Id_bico);

            return this.executarProc("EXCLUI_PDC_MOVVEND", hs);
        }

        public TList_MovVend SelectMovVend(string Cd_empresa,
                                           string Cd_produto,
                                           DateTime Dt_emissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_Tanque, a.id_bico, ");
            sql.AppendLine("Volfechamento = ISNULL((case when exists(select 1 ");
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

            sql.AppendLine("Volabertura = ISNULL((case when exists(select 1 ");
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

            sql.AppendLine("Volafericao = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("						from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("						where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("						and ISNULL(x.ST_Afericao, 'N') = 'S' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Abastecimento))) = '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'), 0) ");

            sql.AppendLine("from TB_PDC_BicoBomba a ");
            sql.AppendLine("inner join TB_PDC_Tanque b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_tanque = b.id_tanque ");
            sql.AppendLine("where CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_emissao.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and b.cd_produto = '" + Cd_produto.Trim() + "'");

            TList_MovVend lista = new TList_MovVend();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovVend reg = new TRegistro_MovVend();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("Id_Tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volfechamento")))
                        reg.Volfechamento = reader.GetDecimal(reader.GetOrdinal("Volfechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volabertura")))
                        reg.Volabertura = reader.GetDecimal(reader.GetOrdinal("Volabertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volafericao")))
                        reg.Volafericao = reader.GetDecimal(reader.GetOrdinal("Volafericao"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
