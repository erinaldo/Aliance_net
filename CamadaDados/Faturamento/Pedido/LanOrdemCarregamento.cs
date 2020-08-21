using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;

namespace CamadaDados.Faturamento.Pedido
{
    #region Ordem Carregamento
    public class TList_OrdemCarregamento : List<TRegistro_OrdemCarregamento>, IComparer<TRegistro_OrdemCarregamento>
    {
        #region IComparer<TRegistro_OrdemCarregamento> Members
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

        public TList_OrdemCarregamento()
        { }

        public TList_OrdemCarregamento(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemCarregamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemCarregamento x, TRegistro_OrdemCarregamento y)
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

    public class TRegistro_OrdemCarregamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_ordem;

        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;

        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = decimal.Parse(value);
                }
                catch
                { id_ordem = null; }
            }
        }
        public DateTime? dt_embarque { get; set; } = new DateTime();
        private DateTime? dt_carregamento;

        public DateTime? Dt_carregamento
        {
            get { return dt_carregamento; }
            set
            {
                dt_carregamento = value;
                dt_carregamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_carregamentostr;
        public string Dt_carregamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_carregamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_carregamentostr = value;
                try
                {
                    dt_carregamento = Convert.ToDateTime(value);
                }
                catch
                { dt_carregamento = null; }
            }
        }
        private DateTime? dt_entrega;

        public DateTime? Dt_entrega
        {
            get { return dt_entrega; }
            set
            {
                dt_entrega = value;
                dt_entregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_entregastr;
        public string Dt_entregastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_entregastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_entregastr = value;
                try
                {
                    dt_entrega = Convert.ToDateTime(value);
                }
                catch
                { dt_entrega = null; }
            }
        }
        public string HR_Carregamento
        { get; set; }
        public string Tp_carregamento
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public string Nm_Transportadora
        { get; set; }
        public string Ds_EnderecoTransp
        { get; set; }
        public string Logradouroent
        { get; set; }
        public string Numeroent
        { get; set; }
        public string Complementoent
        { get; set; }
        public string Bairroent
        { get; set; }
        public string Cd_cidadeent
        { get; set; }
        public string Ds_cidadeent
        { get; set; }
        public string Uf_ent
        { get; set; }
        public string Ds_obs
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public string Status
        { get; set; }
        public TList_Ordem_X_Expedicao lItens
        { get; set; }
        public TList_Ordem_X_Expedicao lItensDel
        { get; set; }
        public TList_Expedicao lExp
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNotaFiscal
        { get; set; }
        public CamadaDados.Faturamento.Pedido.TList_EtapaPedido lEtapa
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc
        { get; set; }

        public string nr_proposta { get; set; }

        public TRegistro_OrdemCarregamento()
        {
            this.nr_proposta = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.dt_carregamento = null;
            this.dt_carregamentostr = string.Empty;
            this.dt_entrega = null;
            this.Dt_entregastr = string.Empty;
            this.HR_Carregamento = string.Empty;
            this.Tp_carregamento = string.Empty;
            this.Vl_frete = decimal.Zero;
            this.Nm_Transportadora = string.Empty;
            this.Ds_EnderecoTransp = string.Empty;
            this.Ds_obs = string.Empty;
            this.Logradouroent = string.Empty;
            this.Numeroent = string.Empty;
            this.Complementoent = string.Empty;
            this.Bairroent = string.Empty;
            this.Cd_cidadeent = string.Empty;
            this.Ds_cidadeent = string.Empty;
            this.Uf_ent = string.Empty;
            this.Nr_pedido = null;
            this.dt_embarque = null;
            this.Nr_notafiscal = null;
            this.Qtd_devolvida = decimal.Zero;
            this.Status = string.Empty;
            this.lItens = new TList_Ordem_X_Expedicao();
            this.lItensDel = new TList_Ordem_X_Expedicao();
            this.lExp = new TList_Expedicao();
            this.lNotaFiscal = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            this.lEtapa = new TList_EtapaPedido();
            this.lParc = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
        }
    }

    public class TCD_OrdemCarregamento : TDataQuery
    {
        public TCD_OrdemCarregamento()
        { }

        public TCD_OrdemCarregamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.nm_empresa, a.ID_Ordem, ");
                sql.AppendLine("a.DT_Carregamento, a.DT_Entrega, a.HR_Carregamento, a.Tp_carregamento, a.Vl_frete, ");
                sql.AppendLine("a.Nm_Transportadora, a.Ds_EnderecoTransp, a.Ds_obs, a.Logradouroent, a.Numeroent, a.Complementoent, a.Qtd_devolvida, ");
                sql.AppendLine("a.Bairroent, a.Cd_cidadeent, a.Ds_cidadeent, a.Uf_ent, a.Nr_pedido, a.NR_NotaFiscal, a.status, nr_proposta = (select top 1 x.nr_orcamento from TB_FAT_Pedido_Itens x where x.nr_pedido = a.nr_pedido) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_OrdemCarregamento a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.Id_ordem ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OrdemCarregamento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_OrdemCarregamento lista = new TList_OrdemCarregamento();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemCarregamento reg = new TRegistro_OrdemCarregamento();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_proposta")))
                        reg.nr_proposta = reader.GetDecimal(reader.GetOrdinal("nr_proposta")).ToString(); 
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Carregamento")))
                        reg.Dt_carregamento = reader.GetDateTime(reader.GetOrdinal("DT_Carregamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("DT_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HR_Carregamento")))
                        reg.HR_Carregamento = reader.GetString(reader.GetOrdinal("HR_Carregamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_Transportadora")))
                        reg.Nm_Transportadora = reader.GetString(reader.GetOrdinal("Nm_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_EnderecoTransp")))
                        reg.Ds_EnderecoTransp = reader.GetString(reader.GetOrdinal("Ds_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_obs")))
                        reg.Ds_obs = reader.GetString(reader.GetOrdinal("Ds_obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logradouroent")))
                        reg.Logradouroent = reader.GetString(reader.GetOrdinal("Logradouroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numeroent")))
                        reg.Numeroent = reader.GetString(reader.GetOrdinal("Numeroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complementoent")))
                        reg.Complementoent = reader.GetString(reader.GetOrdinal("Complementoent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairroent")))
                        reg.Bairroent = reader.GetString(reader.GetOrdinal("Bairroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cidadeent")))
                        reg.Cd_cidadeent = reader.GetString(reader.GetOrdinal("Cd_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_cidadeent")))
                        reg.Ds_cidadeent = reader.GetString(reader.GetOrdinal("Ds_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Uf_ent")))
                        reg.Uf_ent = reader.GetString(reader.GetOrdinal("Uf_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.Status = reader.GetString(reader.GetOrdinal("Status"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_OrdemCarregamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(17);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_DT_CARREGAMENTO", val.Dt_carregamento);
            hs.Add("@P_DT_ENTREGA", val.Dt_entrega);
            hs.Add("@P_HR_CARREGAMENTO", val.HR_Carregamento);
            hs.Add("@P_TP_CARREGAMENTO", val.Tp_carregamento);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_NM_TRANSPORTADORA", val.Nm_Transportadora);
            hs.Add("@P_DS_ENDERECOTRANSP", val.Ds_EnderecoTransp);
            hs.Add("@P_DS_OBS", val.Ds_obs);
            hs.Add("@P_LOGRADOUROENT", val.Logradouroent);
            hs.Add("@P_NUMEROENT", val.Numeroent);
            hs.Add("@P_COMPLEMENTOENT", val.Complementoent);
            hs.Add("@P_BAIRROENT", val.Bairroent);
            hs.Add("@P_CD_CIDADEENT", val.Cd_cidadeent);


            return this.executarProc("IA_FAT_ORDEMCARREGAMENTO", hs);
        }

        public string Excluir(TRegistro_OrdemCarregamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);

            return this.executarProc("EXCLUI_FAT_ORDEMCARREGAMENTO", hs);
        }
    }
    #endregion  

    #region Ordem_X_Expedicao
    public class TList_Ordem_X_Expedicao : List<TRegistro_Ordem_X_Expedicao>, IComparer<TRegistro_Ordem_X_Expedicao>
    {
        #region IComparer<TRegistro_Ordem_X_Expedicao> Members
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

        public TList_Ordem_X_Expedicao()
        { }

        public TList_Ordem_X_Expedicao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Ordem_X_Expedicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Ordem_X_Expedicao x, TRegistro_Ordem_X_Expedicao y)
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

    public class TRegistro_Ordem_X_Expedicao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_ordem;

        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;

        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = decimal.Parse(value);
                }
                catch
                { id_ordem = null; }
            }
        }
        private decimal? id_expedicao;

        public decimal? Id_expedicao
        {
            get { return id_expedicao; }
            set
            {
                id_expedicao = value;
                id_expedicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_expedicaostr;

        public string Id_expedicaostr
        {
            get { return id_expedicaostr; }
            set
            {
                id_expedicaostr = value;
                try
                {
                    id_expedicao = decimal.Parse(value);
                }
                catch
                { id_expedicao = null; }
            }
        }
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

        public TRegistro_Ordem_X_Expedicao()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.id_expedicao = null;
            this.id_expedicaostr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
        }
    }
    public class TCD_Ordem_X_Expedicao : TDataQuery
    {
        public TCD_Ordem_X_Expedicao()
        { }

        public TCD_Ordem_X_Expedicao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Ordem, a.ID_Expedicao, a.Nr_LanctoFiscal ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Ordem_X_Expedicao a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by a.Id_ordem ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Ordem_X_Expedicao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Ordem_X_Expedicao lista = new TList_Ordem_X_Expedicao();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Ordem_X_Expedicao reg = new TRegistro_Ordem_X_Expedicao();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ordem")))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Expedicao")))
                        reg.Id_expedicao = reader.GetDecimal(reader.GetOrdinal("ID_Expedicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_Ordem_X_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return this.executarProc("IA_FAT_ORDEM_X_EXPEDICAO", hs);
        }

        public string Excluir(TRegistro_Ordem_X_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);

            return this.executarProc("EXCLUI_FAT_ORDEM_X_EXPEDICAO", hs);
        }
    }
    #endregion
}
