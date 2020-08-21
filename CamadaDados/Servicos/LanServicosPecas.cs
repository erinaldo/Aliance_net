using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Servicos
{
    #region Pecas
    public class TList_LanServicosPecas : List<TRegistro_LanServicosPecas>, IComparer<TRegistro_LanServicosPecas>
    {
        #region IComparer<TRegistro_LanServicosPecas> Members
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

        public TList_LanServicosPecas()
        { }

        public TList_LanServicosPecas(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanServicosPecas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanServicosPecas x, TRegistro_LanServicosPecas y)
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
    
    public class TRegistro_LanServicosPecas
    {
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
        public string Cd_empresa
        { get; set; }
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
        private decimal? id_evolucao;
        public decimal? Id_evolucao
        {
            get { return id_evolucao; }
            set
            {
                id_evolucao = value;
                id_evolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_evolucaostr;
        public string Id_evolucaostr
        {
            get { return id_evolucaostr; }
            set
            {
                id_evolucaostr = value;
                try
                {
                    id_evolucao = decimal.Parse(value);
                }
                catch
                { id_evolucao = null; }
            }
        }
        public string Cd_tecnico
        { get; set; }
        public string Nm_tecnico
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidproduto
        { get; set; }
        public string Ds_unidproduto
        { get; set; }
        public string Sigla_unidproduto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ncm
        { get; set; }
        private string st_servico;
        public string St_servico
        {
            get { return st_servico; }
            set
            {
                st_servico = value;
                st_servicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_servicobool;
        public bool St_servicobool
        {
            get { return st_servicobool; }
            set
            {
                st_servicobool = value;
                st_servico = value ? "S" : "N";
            }
        }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Qtd_faturar
        { get; set; }
        public decimal SaldoFaturar
        { get; set; }
        public decimal Qtd_compra
        { get; set; }
        public decimal SD_Compra
        { get { return Quantidade - Qtd_compra; } }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_custo
        { get; set; }
        public decimal Tot_Custo
        { get { return Vl_custo * Quantidade; } }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Pc_desconto
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Pc_acrescimo
        { get; set; }
        public decimal Vl_SubTotalLiq
        { get; set; }
        public string Ds_observacao
        { get; set; }
        private string st_atendimentogarantia;
        public string St_atendimentogarantia
        {
            get { return st_atendimentogarantia; }
            set
            {
                st_atendimentogarantia = value;
                st_atendimentogarantiabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_atendimentogarantiabool;
        public bool St_atendimentogarantiabool
        {
            get { return st_atendimentogarantiabool; }
            set
            {
                st_atendimentogarantiabool = value;
                st_atendimentogarantia = value ? "S" : "N";
            }
        }
        public decimal? Nr_orcamento
        { get; set; }
        public decimal? Id_itemOrc
        { get; set; }
        public DateTime? Dt_servico
        { get; set; }
        public decimal Vl_CustoFicha
        { get; set; }
        public bool St_processar
        { get; set; }

        public TList_FichaTecOS lFichaTecOS
        { get; set; }
        public TList_FichaTecOS lFichaTecOSDel
        { get; set; }

        public TRegistro_LanServicosPecas()
        {
            id_os = null;
            id_osstr = string.Empty;
            Cd_empresa = string.Empty;
            id_peca = null;
            id_pecastr = string.Empty;
            id_evolucao = null;
            id_evolucaostr = string.Empty;
            Cd_tecnico = string.Empty;
            Nm_tecnico = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidproduto = string.Empty;
            Ds_unidproduto = string.Empty;
            Sigla_unidproduto = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ncm = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Quantidade = decimal.Zero;
            Qtd_faturar = decimal.Zero;
            SaldoFaturar = decimal.Zero;
            Qtd_compra = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_custo = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Vl_SubTotalLiq = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Pc_desconto = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Pc_acrescimo = decimal.Zero;
            Ds_observacao = string.Empty;
            st_atendimentogarantia = "N";
            st_atendimentogarantiabool = false;
            st_servico = "N";
            st_servicobool = false;
            Nr_orcamento = null;
            Id_itemOrc = null;
            Dt_servico = null;
            Vl_CustoFicha = decimal.Zero;
            St_processar = false;

            lFichaTecOS = new TList_FichaTecOS();
            lFichaTecOSDel = new TList_FichaTecOS();
        }
    }

    public class TCD_LanServicosPecas : TDataQuery
    {
        public TCD_LanServicosPecas()
        { }

        public TCD_LanServicosPecas(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_OS, a.CD_Empresa, a.ID_Peca, b.cd_condfiscal_produto,  ");
                sql.AppendLine("a.CD_Produto, isnull(a.ds_pecaavulsa, b.DS_Produto) as DS_PecaAvulsa, b.CD_Unidade, ");
                sql.AppendLine("c.DS_Unidade, c.Sigla_Unidade, a.ST_Servico, a.CD_Local, a.Qtd_Compra, b.ncm, ");
                sql.AppendLine("d.DS_Local, a.ID_Evolucao, a.CD_Tecnico, e.nm_clifor as nm_tecnico, a.vl_custoficha, ");
                sql.AppendLine("a.Quantidade, a.VL_Unitario, a.Vl_custo, a.Vl_Subtotal, a.Vl_Desconto, a.Vl_Acrescimo, ");
                sql.AppendLine("a.Vl_SubTotalLiq, a.DS_Observacao, a.ST_AtendimentoGarantia, os.dt_abertura, ");
                sql.AppendLine("SaldoFaturar = isnull(a.quantidade, 0) -  isnull((select sum(isnull(k.quantidade, 0)) ");
                sql.AppendLine("               from tb_fat_notafiscal_item k ");
                sql.AppendLine("               left outer join TB_FAT_Notafiscal w ");
                sql.AppendLine("               on k.cd_empresa = w.cd_empresa ");
                sql.AppendLine("               and k.nr_lanctofiscal = w.nr_lanctofiscal ");
                sql.AppendLine("               inner join TB_OSE_Servico_X_PedidoItem x ");
                sql.AppendLine("               on x.nr_pedido = k.nr_pedido ");
                sql.AppendLine("               and x.cd_produto = k.cd_produto ");
                sql.AppendLine("               and x.id_pedidoitem = k.id_pedidoitem ");
                sql.AppendLine("               inner join TB_FAT_Pedido_Itens y ");
                sql.AppendLine("               on x.NR_Pedido = y.Nr_Pedido ");
                sql.AppendLine("               and x.id_pedidoitem = y.id_pedidoitem ");
                sql.AppendLine("               where x.id_os = a.id_os ");
                sql.AppendLine("               and x.cd_produto = a.cd_produto ");
                sql.AppendLine("               and ISNULL(y.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("               and ISNULL(w.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("	           and x.cd_empresa = a.cd_empresa), 0) "); 
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_OSE_Pecas a ");
            sql.AppendLine("inner join tb_ose_servico os ");
            sql.AppendLine("on a.cd_empresa = os.cd_empresa ");
            sql.AppendLine("and a.id_os = os.id_os ");
            sql.AppendLine("left outer join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("left outer join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("left outer join TB_EST_TpProduto tp ");
            sql.AppendLine("on b.TP_Produto = tp.TP_Produto ");
            sql.AppendLine("left outer join tb_est_localarm d ");
            sql.AppendLine("on a.cd_local = d.cd_local ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.cd_tecnico = e.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_LanServicosPecas Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_LanServicosPecas lista = new TList_LanServicosPecas();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanServicosPecas reg = new TRegistro_LanServicosPecas();
                    //Dados do produto/servico da os
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Peca"))))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("ID_Peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Evolucao")))
                        reg.Id_evolucao = reader.GetDecimal(reader.GetOrdinal("ID_Evolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_compra")))
                        reg.Qtd_compra = reader.GetDecimal(reader.GetOrdinal("qtd_compra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_custo"))))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("Vl_custo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Subtotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_Subtotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("Vl_Acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotalLiq")))
                        reg.Vl_SubTotalLiq = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotalLiq"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    //Dados do produto/servico
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PecaAvulsa")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_PecaAvulsa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_atendimentoGarantia")))
                        reg.St_atendimentogarantia = reader.GetString(reader.GetOrdinal("st_atendimentoGarantia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidproduto = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidproduto = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidproduto= reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("st_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Tecnico")))
                        reg.Cd_tecnico = reader.GetString(reader.GetOrdinal("cd_tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tecnico")))
                        reg.Nm_tecnico = reader.GetString(reader.GetOrdinal("NM_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        reg.Dt_servico = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custoficha")))
                        reg.Vl_CustoFicha = reader.GetDecimal(reader.GetOrdinal("vl_custoficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoFaturar")))
                        reg.SaldoFaturar = reader.GetDecimal(reader.GetOrdinal("SaldoFaturar"));
                    
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

        public string Gravar(TRegistro_LanServicosPecas val)
        {
            Hashtable hs = new Hashtable(16);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DS_PECAAVULSA", val.Ds_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_TECNICO", val.Cd_tecnico);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_CUSTO", val.Vl_custo);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_ACRESCIMO", val.Vl_acrescimo);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_ATENDIMENTOGARANTIA", val.St_atendimentogarantia);
            hs.Add("@P_ST_SERVICO", val.St_servico);
           
            return executarProc("IA_OSE_PECAS", hs);
        }

        public string Excluir(TRegistro_LanServicosPecas val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);

            return executarProc("EXCLUI_OSE_PECAS", hs);
        }
    }
    #endregion

    #region Pecas X PreVenda
    public class TList_Pecas_X_PreVenda : List<TRegistro_Pecas_X_PreVenda>
    { }
    
    public class TRegistro_Pecas_X_PreVenda
    {
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
        public string Cd_empresa
        { get; set; }
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
        private decimal? id_prevenda;
        public decimal? Id_prevenda
        {
            get { return id_prevenda; }
            set
            {
                id_prevenda = value;
                id_prevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_prevendastr;
        public string Id_prevendastr
        {
            get { return id_prevendastr; }
            set
            {
                id_prevendastr = value;
                try
                {
                    id_prevenda = decimal.Parse(value);
                }
                catch
                { id_prevenda = null; }
            }
        }
        private decimal? id_itemprevenda;
        public decimal? Id_itemprevenda
        {
            get { return id_itemprevenda; }
            set
            {
                id_itemprevenda = value;
                id_itemprevendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemprevendastr;
        public string Id_itemprevendastr
        {
            get { return id_itemprevendastr; }
            set
            {
                id_itemprevendastr = value;
                try
                {
                    id_itemprevenda = decimal.Parse(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }

        public TRegistro_Pecas_X_PreVenda()
        {
            id_os = null;
            id_osstr = string.Empty;
            Cd_empresa = string.Empty;
            id_peca = null;
            id_pecastr = string.Empty;
            id_prevenda = null;
            id_prevendastr = string.Empty;
            id_itemprevenda = null;
            id_itemprevendastr = string.Empty;
        }
    }

    public class TCD_Pecas_X_PreVenda : TDataQuery
    {
        public TCD_Pecas_X_PreVenda()
        { }

        public TCD_Pecas_X_PreVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_os, a.cd_empresa,  ");
                sql.AppendLine("a.id_peca, a.id_prevenda, a.id_itemprevenda ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Pecas_X_PreVenda a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pecas_X_PreVenda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Pecas_X_PreVenda lista = new TList_Pecas_X_PreVenda();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Pecas_X_PreVenda reg = new TRegistro_Pecas_X_PreVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Peca"))))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("ID_Peca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PreVenda"))))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("ID_PreVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemPreVenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("ID_ItemPreVenda"));

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

        public string Gravar(TRegistro_Pecas_X_PreVenda val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("IA_OSE_PECAS_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_Pecas_X_PreVenda val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("EXCLUI_OSE_PECAS_X_PREVENDA", hs);
        }
    }
    #endregion

    #region Pecas X NFCe
    public class TList_Pecas_X_NFCe : List<TRegistro_Pecas_X_NFCe> { }

    public class TRegistro_Pecas_X_NFCe
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_os
        { get; set; }
        public decimal? Id_peca
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_lancto
        { get; set; }

        public TRegistro_Pecas_X_NFCe()
        {
            Cd_empresa = string.Empty;
            Id_os = null;
            Id_peca = null;
            Id_cupom = null;
            Id_lancto = null;
        }
    }

    public class TCD_Pecas_X_NFCe : TDataQuery
    {
        public TCD_Pecas_X_NFCe() { }

        public TCD_Pecas_X_NFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.id_os,  ");
                sql.AppendLine("a.id_peca, a.id_cupom, a.id_lancto  ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Pecas_X_NFCe a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pecas_X_NFCe Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Pecas_X_NFCe lista = new TList_Pecas_X_NFCe();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Pecas_X_NFCe reg = new TRegistro_Pecas_X_NFCe();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Peca"))))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("ID_Peca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("ID_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));

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

        public string Gravar(TRegistro_Pecas_X_NFCe val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("IA_OSE_PECAS_X_NFCE", hs);
        }

        public string Excluir(TRegistro_Pecas_X_NFCe val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("EXCLUI_OSE_PECAS_X_NFCE", hs);
        }
    }
    #endregion

    #region Estoque
    public class TList_OSEEstoque : List<TRegistro_OSEEstoque>
    { }

    public class TRegistro_OSEEstoque
    {
        private decimal? id_os;
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                Id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
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
                catch { id_os = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
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
                catch { id_peca = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        private decimal? id_lanctoestoque;
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch { id_lanctoestoque = null; }
            }
        }

        public TRegistro_OSEEstoque()
        {
            id_os = null;
            id_osstr = string.Empty;
            Cd_empresa = string.Empty;
            id_peca = null;
            id_pecastr = string.Empty;
            Cd_produto = string.Empty;
            id_lanctoestoque = null;
            id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_OSEEstoque : TDataQuery
    {
        public TCD_OSEEstoque() { }

        public TCD_OSEEstoque(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_os, a.cd_empresa, ");
                sql.AppendLine("a.id_peca, a.cd_produto, a.id_lanctoestoque ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Estoque a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OSEEstoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OSEEstoque lista = new TList_OSEEstoque();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OSEEstoque reg = new TRegistro_OSEEstoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Peca"))))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("ID_Peca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));

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

        public string Gravar(TRegistro_OSEEstoque val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("IA_OSE_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_OSEEstoque val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("EXCLUI_OSE_ESTOQUE", hs);
        }
    }
    #endregion

    #region Ficha Tecnica OS
    public class TList_FichaTecOS : List<TRegistro_FichaTecOS>
    { }

    public class TRegistro_FichaTecOS
    {
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
        public string Cd_empresa
        { get; set; }
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
        public string Cd_item
        { get; set; }
        public string Ds_item
        { get; set; }
        public string Cd_unid_item
        { get; set; }
        public string Ds_unid_item
        { get; set; }
        public string Sg_unid_item
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_Subtotal
        { get { return Quantidade * Vl_unitario; } }
        public decimal Vl_UnitCusto
        { get; set; }
        public decimal Vl_TotCusto
        { get { return Quantidade * Vl_UnitCusto; } }
        public bool St_processar
        { get; set; }

        public TRegistro_FichaTecOS()
        {
            id_os = null;
            id_osstr = string.Empty;
            Cd_empresa = null;
            id_peca = null;
            id_pecastr = string.Empty;
            Cd_item = string.Empty;
            Ds_item = string.Empty;
            Cd_unid_item = string.Empty;
            Ds_unid_item = string.Empty;
            Sg_unid_item = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_UnitCusto = decimal.Zero;
            St_processar = false;
        }
    }

    public class TCD_FichaTecOS : TDataQuery
    {
        public TCD_FichaTecOS()
        { }

        public TCD_FichaTecOS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_os, a.cd_empresa, ");
                sql.AppendLine("a.ID_Peca, a.cd_item, b.ds_produto as ds_item, ");
                sql.AppendLine("b.cd_unidade as cd_unid_item, u.ds_unidade as ds_unid_item, u.sigla_unidade as sg_unid_item, ");
                sql.AppendLine("a.CD_Local, c.ds_local, a.Quantidade, a.vl_unitcusto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_FichaTecOS a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_item = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade u ");
            sql.AppendLine("on b.cd_unidade = u.cd_unidade ");
            sql.AppendLine("left outer join tb_est_localarm c ");
            sql.AppendLine("on a.cd_local = c.cd_local ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    if ((filtro.vNM_Campo != null) && (filtro.vOperador != null) && (filtro.vVL_Busca != null))
                    {
                        sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_FichaTecOS Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FichaTecOS lista = new TList_FichaTecOS();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_FichaTecOS reg = new TRegistro_FichaTecOS();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("Id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("Id_peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("CD_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("DS_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitcusto")))
                        reg.Vl_UnitCusto = reader.GetDecimal(reader.GetOrdinal("vl_unitcusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unid_item")))
                        reg.Cd_unid_item = reader.GetString(reader.GetOrdinal("cd_unid_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unid_item")))
                        reg.Ds_unid_item = reader.GetString(reader.GetOrdinal("ds_unid_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_unid_item")))
                        reg.Sg_unid_item = reader.GetString(reader.GetOrdinal("sg_unid_item"));

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

        public string Gravar(TRegistro_FichaTecOS val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITCUSTO", val.Vl_UnitCusto);

            return executarProc("IA_OSE_FICHATECOS", hs);
        }

        public string Excluir(TRegistro_FichaTecOS val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_ITEM", val.Cd_item);

            return executarProc("EXCLUI_OSE_FICHATECOS", hs);
        }
    }
    #endregion

    #region FichaTec_X_Estoque
    public class TList_FichaTec_X_Estoque : List<TRegistro_FichaTec_X_Estoque>
    { }

    public class TRegistro_FichaTec_X_Estoque
    {
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
        public string Cd_empresa
        { get; set; }
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
        public string Cd_item
        { get; set; }
        public string Cd_produto
        { get; set; }
        private decimal? id_lanctoestoque;
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch { id_lanctoestoque = null; }
            }
        }

        public TRegistro_FichaTec_X_Estoque()
        {
            id_os = null;
            id_osstr = string.Empty;
            Cd_empresa = null;
            id_peca = null;
            id_pecastr = string.Empty;
            Cd_item = string.Empty;
            Cd_produto = string.Empty;
            id_lanctoestoque = null;
            id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_FichaTec_X_Estoque : TDataQuery
    {
        public TCD_FichaTec_X_Estoque()
        { }

        public TCD_FichaTec_X_Estoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_os, a.cd_empresa, a.ID_Peca, a.cd_item, a.CD_Produto, a.Id_LanctoEstoque ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_FichaTec_X_Estoque a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    if ((filtro.vNM_Campo != null) && (filtro.vOperador != null) && (filtro.vVL_Busca != null))
                    {
                        sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_FichaTec_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FichaTec_X_Estoque lista = new TList_FichaTec_X_Estoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_FichaTec_X_Estoque reg = new TRegistro_FichaTec_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("Id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("Id_peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("CD_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("Id_lanctoestoque"));

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

        public string Gravar(TRegistro_FichaTec_X_Estoque val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("IA_OSE_FICHATEC_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_FichaTec_X_Estoque val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("EXCLUI_OSE_FICHATEC_X_ESTOQUE", hs);
        }
    }
    #endregion
}
