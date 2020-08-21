using CamadaDados;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Faturamento.PDV;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Comissao
{
    #region Metas Vendas Vendedor
    public class TList_Metas_VendasVendedor : List<TRegistro_Metas_VendasVendedor>, IComparer<TRegistro_Metas_VendasVendedor>
    {
        #region IComparer<TRegistro_Metas_VendasVendedor> Members
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

        public TList_Metas_VendasVendedor()
        { }

        public TList_Metas_VendasVendedor(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Metas_VendasVendedor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Metas_VendasVendedor x, TRegistro_Metas_VendasVendedor y)
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

    public class TRegistro_Metas_VendasVendedor
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Mes
        { get; set; }
        public string Ano
        { get; set; }
        public decimal Tot_LiquidoVenda
        { get; set; }
        public decimal Tot_comissao
        { get; set; }
        public decimal Vl_metaatingida
        { get; set; }
        public decimal Pc_comissao
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_MetaVendedor lMeta
        { get; set; }
        public TList_VendaRapida_Item lItemVenda
        { get; set; }
        public TList_ComposicaoComissao lComposicao
        { get; set; }

        public TRegistro_Metas_VendasVendedor()
        {
            Cd_empresa = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Mes = string.Empty;
            Ano = string.Empty;
            Tot_LiquidoVenda = decimal.Zero;
            Tot_comissao = decimal.Zero;
            Vl_metaatingida = decimal.Zero;
            Pc_comissao = decimal.Zero;
            St_processar = false;
            lMeta = new TList_MetaVendedor();
            lItemVenda = new TList_VendaRapida_Item();
            lComposicao = new TList_ComposicaoComissao();
        }
    }

    public class TCD_Metas_VendasVendedor : TDataQuery
    {
        public TCD_Metas_VendasVendedor()
        { }

        public TCD_Metas_VendasVendedor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Cd_empresa, a.Cd_vendedor, a.Nm_vendedor, a.Mes, a.Ano, a.Tot_LiquidoVenda, ");
                sql.AppendLine("CONVERT(DECIMAL(15,2), ISNULL(dbo.[F_SPLIT](a.meta, ',', 1), 0)) as Vl_meta, ");
                sql.AppendLine("CONVERT(DECIMAL(15,2), ISNULL(dbo.[F_SPLIT](a.meta, ',', 2), 0)) as Pc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from VTB_FAT_Metas_VendasVendedor a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by CONVERT(DECIMAL(15,2), ISNULL(dbo.[F_SPLIT](a.meta, ',', 1), 0)) desc ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Metas_VendasVendedor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Metas_VendasVendedor lista = new TList_Metas_VendasVendedor();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Metas_VendasVendedor reg = new TRegistro_Metas_VendasVendedor();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetString(reader.GetOrdinal("Mes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetString(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_LiquidoVenda")))
                        reg.Tot_LiquidoVenda = reader.GetDecimal(reader.GetOrdinal("Tot_LiquidoVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_meta")))
                        reg.Vl_metaatingida = reader.GetDecimal(reader.GetOrdinal("Vl_meta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("Pc_comissao"));

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
    #endregion

    #region Fechamento Comissao
    public class TList_Fechamento_Comissao : List<TRegistro_Fechamento_Comissao>, IComparer<TRegistro_Fechamento_Comissao>
    {
        #region IComparer<TRegistro_Fechamento_Comissao> Members
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

        public TList_Fechamento_Comissao()
        { }

        public TList_Fechamento_Comissao(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Fechamento_Comissao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Fechamento_Comissao x, TRegistro_Fechamento_Comissao y)
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
    
    public class TRegistro_Fechamento_Comissao
    {
        private decimal? id_comissao;
        public decimal? Id_comissao
        {
            get { return id_comissao; }
            set
            {
                id_comissao = value;
                id_comissaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comissaostr;
        public string Id_comissaostr
        {
            get { return id_comissaostr; }
            set
            {
                id_comissaostr = value;
                try
                {
                    id_comissao = decimal.Parse(value);
                }
                catch
                { id_comissao = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_endvendedor
        { get; set; }
        public string Cd_representante
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
                catch
                { nr_lanctofiscal = null; }
            }
        }
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

        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr; 
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
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
                catch
                { nr_notafiscal = null; }
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
                catch
                { id_nfitem = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch
                { id_cupom = null; }
            }
        }
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch
                { id_lancto = null; }
            }
        }
        private decimal? id_os;
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        private decimal? id_peca;
        public decimal? Id_peca
        {
            get { return id_peca; }
            set
            {
                id_peca = value;
                id_pecastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pecastr;
        public string Id_pecastr
        {
            get { return id_pecastr; }
            set
            {
                id_pecastr = value;
                try
                {
                    id_peca = decimal.Parse(value);
                }
                catch
                { id_peca = null; }
            }
        }
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostr;
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        private decimal? id_pedidoitem;
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemstr;
        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = decimal.Parse(value);
                }
                catch
                { id_pedidoitem = null; }
            }
        }
        private decimal? nr_lanctoctr;
        public decimal? Nr_lanctoctr
        {
            get { return nr_lanctoctr; }
            set
            {
                nr_lanctoctr = value;
                nr_lanctoctrstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoctrstr;
        public string Nr_lanctoctrstr
        {
            get { return nr_lanctoctrstr; }
            set
            {
                nr_lanctoctrstr = value;
                try
                {
                    nr_lanctoctr = decimal.Parse(value);
                }
                catch { nr_lanctoctr = null; }
            }
        }
        private decimal? id_receita;
        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;
        public string Id_receitastr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch
                { id_receita = null; }
            }
        }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = Convert.ToDecimal(value);
                }
                catch
                { id_item = null; }
            }
        }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_comissao
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_faturado
        { get; set; }
        public decimal Vl_saldofaturar
        { get { return Math.Round(Vl_comissao - Vl_faturado, 5); } }
        public string Tp_comissao
        { get; set; }
        public string Tipo_comissao
        {
            get
            {
                if (Tp_comissao.Trim().ToUpper().Equals("P"))
                    return "PERCENTUAL";
                else if (Tp_comissao.Trim().ToUpper().Equals("V"))
                    return "VALOR";
                else return string.Empty;
            }
        }
        public string Status
        {
            get
            {
                if (Vl_saldofaturar.Equals(decimal.Zero))
                    return "FATURADA";
                else return "ABERTA";
            }
        }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal id_viagem { get; set; }
        public decimal? id_liquid { get; set; }
        public decimal? cd_parcela { get; set; }
        public decimal? nr_lancto { get; set; }


        public TRegistro_Fechamento_Comissao()
        {
            id_comissao = null;
            id_comissaostr = string.Empty;
            Cd_empresa = string.Empty;
            id_liquid = null;
            cd_parcela = null;
            nr_lancto = null;
            Nm_empresa = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_endvendedor = string.Empty;
            Cd_representante = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            nr_notafiscal = null;
            nr_notafiscalstr = string.Empty;
            id_nfitem = null;
            id_nfitemstr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            id_lancto = null;
            id_lanctostr = string.Empty;
            id_os = null;
            id_osstr = string.Empty;
            id_peca = null;
            id_pecastr = string.Empty;
            nr_pedido = null;
            id_viagem = decimal.Zero;
            nr_pedidostr = string.Empty;
            Cd_produto = string.Empty;
            id_pedidoitem = null;
            id_pedidoitemstr = string.Empty;
            nr_lanctoctr = null;
            nr_lanctoctrstr = string.Empty;
            id_receita = null;
            id_receitastr = string.Empty;
            id_locacao = null;
            id_locacaostr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Tp_comissao = string.Empty;
            dt_lancto = null;
            dt_lanctostr = string.Empty;
            Vl_basecalc = decimal.Zero;
            Pc_comissao = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_faturado = decimal.Zero;
            St_processar = false;
            lParc = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
        }
    }

    public class TCD_Fechamento_Comissao : TDataQuery
    {
        public TCD_Fechamento_Comissao()
        { }

        public TCD_Fechamento_Comissao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Comissao, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Vendedor, c.NM_Clifor, ");
                sql.AppendLine("a.Nr_LanctoFiscal, a.ID_NFItem, d.Nr_NotaFiscal, a.id_locacao, a.id_itemloc, ");
                sql.AppendLine("a.Id_Cupom, a.Id_lancto, a.id_receita, a.DT_Lancto, a.Vl_BaseCalc, ");
                sql.AppendLine("a.PC_Comissao, a.VL_Comissao, a.Vl_Faturado, a.cd_endvendedor, ");
                sql.AppendLine("a.id_os, a.id_peca, a.tp_comissao, a.nr_pedido, a.cd_produto, ");
                sql.AppendLine("a.id_pedidoitem, a.nr_lanctoctr,a.id_orcamento,a.nr_versao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from VTB_FAT_Fechamento_Comissao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_fin_clifor c ");
            sql.AppendLine("on a.cd_vendedor = c.cd_clifor ");
            sql.AppendLine("left outer join TB_FAT_NotaFiscal d ");
            sql.AppendLine("on a.CD_Empresa = d.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = d.Nr_LanctoFiscal ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Fechamento_Comissao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Fechamento_Comissao lista = new TList_Fechamento_Comissao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Fechamento_Comissao reg = new TRegistro_Fechamento_Comissao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Comissao")))
                        reg.Id_comissao = reader.GetDecimal(reader.GetOrdinal("ID_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endvendedor")))
                        reg.Cd_endvendedor = reader.GetString(reader.GetOrdinal("cd_endvendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("Id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("id_peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_comissao")))
                        reg.Tp_comissao = reader.GetString(reader.GetOrdinal("tp_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("id_receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("PC_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("VL_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_faturado")))
                        reg.Vl_faturado = reader.GetDecimal(reader.GetOrdinal("vl_faturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamentostr = reader.GetString(reader.GetOrdinal("Id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_versao")))
                        reg.Nr_versaostr = reader.GetString(reader.GetOrdinal("Nr_versao"));

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

        public string Gravar(TRegistro_Fechamento_Comissao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(21);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_LIQUID", val.id_liquid);
            hs.Add("@P_CD_PARCELA", val.cd_parcela);
            hs.Add("@P_NR_LANCTO", val.nr_lancto);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_item);
            hs.Add("@P_TP_COMISSAO", val.Tp_comissao);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_VL_BASECALC", val.Vl_basecalc);
            hs.Add("@P_PC_COMISSAO", val.Pc_comissao);
            hs.Add("@P_VL_COMISSAO", val.Vl_comissao);

            return executarProc("IA_FAT_FECHAMENTO_COMISSAO", hs);
        }

        public string Excluir(TRegistro_Fechamento_Comissao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FAT_FECHAMENTO_COMISSAO", hs);
        }
    }
    #endregion

    #region Comissao X Duplicata
    public class TList_Comissao_X_Duplicata : List<TRegistro_Comissao_X_Duplicata>
    { }

    
    public class TRegistro_Comissao_X_Duplicata
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_comissao;
        
        public decimal? Id_comissao
        {
            get { return id_comissao; }
            set
            {
                id_comissao = value;
                id_comissaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comissaostr;
        
        public string Id_comissaostr
        {
            get { return id_comissaostr; }
            set
            {
                id_comissaostr = value;
                try
                {
                    id_comissao = decimal.Parse(value);
                }
                catch
                { id_comissao = null; }
            }
        }
        private decimal? nr_lancto;
        
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        
        public decimal Vl_faturado
        { get; set; }

        public TRegistro_Comissao_X_Duplicata()
        {
            Cd_empresa = string.Empty;
            id_comissao = null;
            id_comissaostr = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            Vl_faturado = decimal.Zero;
        }
    }

    public class TCD_Comissao_X_Duplicata : TDataQuery
    {
        public TCD_Comissao_X_Duplicata()
        { }

        public TCD_Comissao_X_Duplicata(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.ID_Comissao, a.CD_Empresa, a.NR_Lancto, a.Vl_Faturado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAT_Comissao_X_Duplicata a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Comissao_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Comissao_X_Duplicata lista = new TList_Comissao_X_Duplicata();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Comissao_X_Duplicata reg = new TRegistro_Comissao_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Comissao")))
                        reg.Id_comissao = reader.GetDecimal(reader.GetOrdinal("ID_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_faturado")))
                        reg.Vl_faturado = reader.GetDecimal(reader.GetOrdinal("vl_faturado"));

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

        public string Gravar(TRegistro_Comissao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_VL_FATURADO", val.Vl_faturado);

            return executarProc("IA_FAT_COMISSAO_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Comissao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_FAT_COMISSAO_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region Transf Comissao
    public class TList_TransfComissao : List<TRegistro_TransfComissao> { }

    public class TRegistro_TransfComissao
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_comissao;
        public decimal? Id_comissao
        {
            get { return id_comissao; }
            set
            {
                id_comissao = value;
                id_comissaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_comissaostr;
        public string Id_comissaostr
        {
            get { return id_comissaostr; }
            set
            {
                id_comissaostr = value;
                try
                {
                    id_comissao = decimal.Parse(value);
                }
                catch { id_comissao = null; }
            }
        }
        private decimal? id_transf;
        public decimal? Id_transf
        {
            get { return id_transf; }
            set
            {
                id_transf = value;
                id_transfstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_transfstr;
        public string Id_transfstr
        {
            get { return id_transfstr; }
            set
            {
                id_transfstr = value;
                try
                {
                    id_transf = decimal.Parse(value);
                }
                catch { id_transf = null; }
            }
        }
        public string Cd_vendedorold
        { get; set; }
        public string Logintransfvend
        { get; set; }
        private DateTime? dt_transfvend;
        public DateTime? Dt_transfvend
        {
            get { return dt_transfvend; }
            set
            {
                dt_transfvend = value;
                dt_transfvendstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_transfvendstr;
        public string Dt_transfvendstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_transfvendstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_transfvendstr = value;
                try
                {
                    dt_transfvend = DateTime.Parse(value);
                }
                catch { dt_transfvend = null; }
            }
        }

        public TRegistro_TransfComissao()
        {
            Cd_empresa = string.Empty;
            id_comissao = null;
            id_comissaostr = string.Empty;
            id_transf = null;
            id_transfstr = string.Empty;
            Cd_vendedorold = string.Empty;
            Logintransfvend = string.Empty;
            dt_transfvend = null;
            dt_transfvendstr = string.Empty;
        }
    }

    public class TCD_TransfComissao : TDataQuery
    {
        public TCD_TransfComissao() { }

        public TCD_TransfComissao(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_comissao, a.id_transf, ");
                sql.AppendLine("a.cd_vendedororig, a.logintransfvend, a.dt_transfvend ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAT_TransfComissao a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TransfComissao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_TransfComissao lista = new TList_TransfComissao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_TransfComissao reg = new TRegistro_TransfComissao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Comissao")))
                        reg.Id_comissao = reader.GetDecimal(reader.GetOrdinal("ID_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VendedorOrig")))
                        reg.Cd_vendedorold = reader.GetString(reader.GetOrdinal("CD_VendedorOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginTransfVend")))
                        reg.Logintransfvend = reader.GetString(reader.GetOrdinal("LoginTransfVend"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_TransfVend")))
                        reg.Dt_transfvend = reader.GetDateTime(reader.GetOrdinal("DT_TransfVend"));

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

        public string Gravar(TRegistro_TransfComissao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TRANSF", val.Id_transf);
            hs.Add("@P_CD_VENDEDORORIG", val.Cd_vendedorold);
            hs.Add("@P_LOGINTRANSFVEND", val.Logintransfvend);
            hs.Add("@P_DT_TRANSFVEND", val.Dt_transfvend);

            return executarProc("IA_FAT_TRANSFCOMISSAO", hs);
        }

        public string Excluir(TRegistro_TransfComissao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_COMISSAO", val.Id_comissao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TRANSF", val.Id_transf);

            return executarProc("EXCLUI_FAT_TRANSFCOMISSAO", hs);
        }
    }
    #endregion

    #region Composição Comissão
    public class TList_ComposicaoComissao : List<TRegistro_ComposicaoComissao>, IComparer<TRegistro_ComposicaoComissao>
    {
        #region IComparer<TRegistro_ComposicaoComissao> Members
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

        public TList_ComposicaoComissao()
        { }

        public TList_ComposicaoComissao(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ComposicaoComissao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ComposicaoComissao x, TRegistro_ComposicaoComissao y)
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

    public class TRegistro_ComposicaoComissao
    {
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Tipo_comissao
        {
            get
            {
                if (!string.IsNullOrEmpty(Cd_produto))
                    return "PRODUTO";
                else if (!string.IsNullOrEmpty(Cd_grupo))
                    return "GRUPO PRODUTO";
                else return "META VENDEDOR";
            }
        }
        public decimal Quantidade
        { get; set; }
        public decimal Tot_venda
        { get; set; }
        public decimal Pc_comissao
        { get; set; }
        public decimal Total_comissao
        { get; set; }

        public TRegistro_ComposicaoComissao()
        {
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Quantidade = decimal.Zero;
            Tot_venda = decimal.Zero;
            Pc_comissao = decimal.Zero;
            Total_comissao = decimal.Zero;
        }
    }
    #endregion
}
