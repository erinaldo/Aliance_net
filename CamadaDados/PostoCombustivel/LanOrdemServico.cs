using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region Ordem Servico
    public class TList_OrdemServico : List<TRegistro_OrdemServico>, IComparer<TRegistro_OrdemServico>
    {
        #region IComparer<TRegistro_OrdemServico> Members
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

        public TList_OrdemServico()
        { }

        public TList_OrdemServico(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrdemServico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrdemServico x, TRegistro_OrdemServico y)
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

    
    public class TRegistro_OrdemServico
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
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Cd_vendedor
        { get; set; }
        
        public string Nm_vendedor
        { get; set; }
        
        public string Cd_tabelapreco
        { get; set; }
        
        public string Ds_tabelapreco
        { get; set; }
        
        public string Ds_veiculo
        { get; set; }
        
        public string Marca_veiculo
        { get; set; }
        
        public string Placa
        { get; set; }
        
        public string Ano
        { get; set; }
        
        public string Modelo
        { get; set; }
        
        public decimal Km_atual
        { get; set; }
        private DateTime? dt_ordem;
        
        public DateTime? Dt_ordem
        {
            get { return dt_ordem; }
            set
            {
                dt_ordem = value;
                dt_ordemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
            }
        }
        private string dt_ordemstr;
        public string Dt_ordemstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_ordemstr).ToString("dd/MM/yyyy HH:mm");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ordemstr = value;
                try
                {
                    dt_ordem = DateTime.Parse(value);
                }
                catch
                { dt_ordem = null; }
            }
        }
        
        public string Nr_requisicao
        { get; set; }
        
        public string Status
        { get; set; }
        
        public decimal Vl_ordem
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Vl_comissao
        { get; set; }
        
        public TList_ItensOrdemServico lItens
        { get; set; }
        
        public TList_ItensOrdemServico lItensDel
        { get; set; }

        public TRegistro_OrdemServico()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Marca_veiculo = string.Empty;
            this.Placa = string.Empty;
            this.Ano = string.Empty;
            this.Modelo = string.Empty;
            this.Km_atual = decimal.Zero;
            this.dt_ordem = null;
            this.dt_ordemstr = string.Empty;
            this.Nr_requisicao = string.Empty;
            this.Status = string.Empty;
            this.Vl_ordem = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.Vl_comissao = decimal.Zero;
            this.lItens = new TList_ItensOrdemServico();
            this.lItensDel = new TList_ItensOrdemServico();
        }
    }

    public class TCD_OrdemServico : TDataQuery
    {
        public TCD_OrdemServico()
        { }

        public TCD_OrdemServico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Ordem, a.CD_Clifor, c.NM_Clifor, a.Nr_requisicao, ");
                sql.AppendLine("a.CD_Endereco, d.DS_Endereco, a.CD_Vendedor, ");
                sql.AppendLine("e.nm_clifor as NomeVendedor, a.DS_Veiculo, a.Marca_Veiculo, ");
                sql.AppendLine("a.Placa, a.Ano, a.Modelo, a.KM_Atual, a.DT_Ordem, ");
                sql.AppendLine("a.Vl_ordem, a.Vl_desconto, a.Vl_comissao, ");
                sql.AppendLine("a.CD_TabelaPreco, t.DS_TabelaPreco, a.Qtd_faturar ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDC_ORDEMSERVICO a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco t ");
            sql.AppendLine("on a.cd_tabelapreco = t.cd_tabelapreco ");
            sql.AppendLine("left outer join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = d.CD_Endereco ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.CD_Vendedor = e.cd_clifor ");

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

        public TList_OrdemServico Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OrdemServico lista = new TList_OrdemServico();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemServico reg = new TRegistro_OrdemServico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ordem"))))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NomeVendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("NomeVendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("DS_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Marca_Veiculo")))
                        reg.Marca_veiculo = reader.GetString(reader.GetOrdinal("Marca_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetString(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Modelo")))
                        reg.Modelo = reader.GetString(reader.GetOrdinal("Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("KM_Atual")))
                        reg.Km_atual = reader.GetDecimal(reader.GetOrdinal("KM_Atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Ordem")))
                        reg.Dt_ordem = reader.GetDateTime(reader.GetOrdinal("DT_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_requisicao")))
                        reg.Nr_requisicao = reader.GetString(reader.GetOrdinal("nr_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ordem")))
                        reg.Vl_ordem = reader.GetDecimal(reader.GetOrdinal("Vl_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("Vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_faturar")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("Qtd_faturar")) > decimal.Zero ? "ABERTA" : "FATURADA";

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

        public string Gravar(TRegistro_OrdemServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_DS_VEICULO", val.Ds_veiculo);
            hs.Add("@P_MARCA_VEICULO", val.Marca_veiculo);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_ANO", val.Ano);
            hs.Add("@P_MODELO", val.Modelo);
            hs.Add("@P_KM_ATUAL", val.Km_atual);
            hs.Add("@P_DT_ORDEM", val.Dt_ordem);
            hs.Add("@P_NR_REQUISICAO", val.Nr_requisicao);

            return this.executarProc("IA_PDC_ORDEMSERVICO", hs);
        }

        public string Excluir(TRegistro_OrdemServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);

            return this.executarProc("EXCLUI_PDC_ORDEMSERVICO", hs);
        }
    }
    #endregion

    #region Itens Ordem
    public class TList_ItensOrdemServico : List<TRegistro_ItensOrdemServico>, IComparer<TRegistro_ItensOrdemServico>
    {
        #region IComparer<TRegistro_ItensOrdemServico> Members
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

        public TList_ItensOrdemServico()
        { }

        public TList_ItensOrdemServico(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensOrdemServico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensOrdemServico x, TRegistro_ItensOrdemServico y)
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
    
    public class TRegistro_ItensOrdemServico
    {
        public string Cd_empresa
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
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get { return Utils.Parametros.pubTruncarSubTotal ? 
            Utils.Estruturas.Truncar(this.Quantidade * this.Vl_unitario, 2) :
            Math.Round(this.Quantidade * this.Vl_unitario, 2); } }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Km_validade
        { get; set; }
        public decimal Dias_validade
        { get; set; }
        public decimal Qtd_faturada
        { get; set; }
        public decimal Qtd_faturar
        { get { return this.Quantidade - this.Qtd_faturada; } }
        public string Cd_vendedor
        { get; set; }
        public string Status
        { get { return Qtd_faturar > decimal.Zero ? "FATURAR" : "FATURADA"; } }
        public decimal? Nr_venda
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_ItensOrdemServico()
        {
            this.Cd_empresa = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.Vl_comissao = decimal.Zero;
            this.Km_validade = decimal.Zero;
            this.Dias_validade = decimal.Zero;
            this.Qtd_faturada = decimal.Zero;
            this.Cd_vendedor = string.Empty;
            this.Nr_venda = null;
            this.St_processar = false;
        }
    }

    public class TCD_ItensOrdemServico : TDataQuery
    {
        public TCD_ItensOrdemServico()
        { }

        public TCD_ItensOrdemServico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Ordem, a.ID_Item, e.cd_clifor, e.cd_vendedor, ");
                sql.AppendLine("a.CD_Produto, b.DS_Produto, b.cd_unidade, c.Sigla_Unidade, f.nm_clifor, a.nr_venda, ");
                sql.AppendLine("a.CD_Local, d.DS_Local, a.Quantidade, a.Vl_Unitario, b.cd_condfiscal_produto, b.cd_grupo, ");
                sql.AppendLine("a.Vl_Desconto, a.Vl_Comissao, a.KM_Validade, a.Dias_Validade, a.Qtd_faturada ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDC_ITENSORDEMSERVICO a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_EST_LocalArm d ");
            sql.AppendLine("on a.CD_Local = d.CD_Local ");
            sql.AppendLine("inner join TB_PDC_OrdemServico e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.id_ordem = e.id_ordem ");
            sql.AppendLine("inner join TB_FIN_Clifor f ");
            sql.AppendLine("on e.cd_clifor = f.cd_clifor ");

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

        public TList_ItensOrdemServico Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ItensOrdemServico lista = new TList_ItensOrdemServico();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensOrdemServico reg = new TRegistro_ItensOrdemServico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ordem"))))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("Vl_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("KM_Validade")))
                        reg.Km_validade = reader.GetDecimal(reader.GetOrdinal("KM_Validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dias_Validade")))
                        reg.Dias_validade = reader.GetDecimal(reader.GetOrdinal("Dias_Validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_faturada")))
                        reg.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("Qtd_faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_venda")))
                        reg.Nr_venda = reader.GetDecimal(reader.GetOrdinal("nr_venda"));

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

        public string Gravar(TRegistro_ItensOrdemServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@p_VL_COMISSAO", val.Vl_comissao);
            hs.Add("@P_KM_VALIDADE", val.Km_validade);
            hs.Add("@P_DIAS_VALIDADE", val.Dias_validade);

            return this.executarProc("IA_PDC_ITENSORDEMSERVICO", hs);
        }

        public string Excluir(TRegistro_ItensOrdemServico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_PDC_ITENSORDEMSERVICO", hs);
        }
    }
    #endregion

    #region Ordem X Venda Rapida
    public class TList_Ordem_X_VendaRapida : List<TRegistro_Ordem_X_VendaRapida>, IComparer<TRegistro_Ordem_X_VendaRapida>
    {
        #region IComparer<TRegistro_Ordem_X_VendaRapida> Members
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

        public TList_Ordem_X_VendaRapida()
        { }

        public TList_Ordem_X_VendaRapida(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Ordem_X_VendaRapida value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Ordem_X_VendaRapida x, TRegistro_Ordem_X_VendaRapida y)
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

    
    public class TRegistro_Ordem_X_VendaRapida
    {
        
        public string Cd_empresa
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
        
        public string Id_Itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
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

        public TRegistro_Ordem_X_VendaRapida()
        {
            this.Cd_empresa = string.Empty;
            this.id_ordem = null;
            this.id_ordemstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
        }
    }

    public class TCD_Ordem_X_VendaRapida : TDataQuery
    {
        public TCD_Ordem_X_VendaRapida()
        { }

        public TCD_Ordem_X_VendaRapida(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Ordem, ");
                sql.AppendLine("a.ID_Item, a.Id_Cupom, a.Id_lancto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_Ordem_X_VendaRapida a ");

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

        public TList_Ordem_X_VendaRapida Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Ordem_X_VendaRapida lista = new TList_Ordem_X_VendaRapida();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Ordem_X_VendaRapida reg = new TRegistro_Ordem_X_VendaRapida();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ordem"))))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("Id_lancto"));

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

        public string Gravar(TRegistro_Ordem_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("IA_PDC_ORDEM_X_VENDARAPIDA", hs);
        }

        public string Excluir(TRegistro_Ordem_X_VendaRapida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORDEM", val.Id_ordem);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);

            return this.executarProc("EXCLUI_PDC_ORDEM_X_VENDARAPIDA", hs);
        }
    }
    #endregion
}
