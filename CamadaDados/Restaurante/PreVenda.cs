using CamadaDados.Restaurante.Integracao.Torneiras;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante
{
    #region prevenda
    public class TRegistro_PreVenda
    {
        public bool st_agregar { get; set; } = false;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal id_cartao { get; set; } = decimal.Zero;
        public decimal? id_prevenda { get; set; } = decimal.Zero;
        public string cd_garcon { get; set; } = string.Empty;
        public string ds_garcon { get; set; } = string.Empty;
        public decimal? NR_SenhaDelivery { get; set; } = null;
        public string porta_imp { get; set; } = string.Empty;
        public decimal id_portaimp { get; set; } = decimal.Zero;
        public string ds_grupo { get; set; } = string.Empty;
        public string ObsFecharDelivery { get; set; } = string.Empty;
        public decimal Vl_TrocoPara { get; set; } = decimal.Zero;
        public string cd_entregador { get; set; } = string.Empty;
        public string ds_entregador { get; set; } = string.Empty;
        public string cd_clifor { get; set; } = string.Empty;
        public string nm_clifor { get; set; } = string.Empty;
        public string celular_Clifor { get; set; } = string.Empty;
        public decimal vl_total { get; set; } = decimal.Zero;
        public decimal vl_troco { get; set; } = decimal.Zero;
        public bool imp_end { get; set; } = false;
        public string st_ativo { get; set; } = "A";
        public string motivo { get; set; } = string.Empty;
        public string nr_cartao { get; set; } = string.Empty;
        public string nf_nfce { get; set; } = string.Empty;
        public decimal? Id_cupom { get; set; } = null;
        private string st_delivery = "";
        public string St_delivery
        {
            get { return st_delivery; }
            set
            {
                st_delivery = value;
                if (value.Trim().ToUpper().Equals(""))
                    status = "";
                else
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else
                if (value.Trim().ToUpper().Equals("E"))
                    status = "ENTREGA";
                else
                if (value.Trim().ToUpper().Equals("F"))
                    status = "FECHADO";
            }
        }
        private string status = "ABERTO";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals(""))
                    st_delivery = "";
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_delivery = "A";
                if (value.Trim().ToUpper().Equals("FECHADO"))
                    st_delivery = "F";
                if (value.Trim().ToUpper().Equals("ENTREGA"))
                    st_delivery = "E";
            }
        }


        private string st_levarcartao;
        public string St_levarcartao
        {
            get { return st_levarcartao; }
            set
            {
                st_levarcartao = value;
                st_levarcartaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_levarcartaobool;
        public bool St_levarcartaobool
        {
            get { return st_levarcartaobool; }
            set
            {
                st_levarcartaobool = value;
                st_levarcartao = value ? "S" : "N";
            }
        }

        private DateTime? dt_venda { get; set; } = new DateTime();
        public DateTime? Dt_venda
        {
            get { return dt_venda; }
            set
            {
                dt_venda = value;
                dt_vendastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy hh:mm") : string.Empty;
            }
        }
        private string dt_vendastr { get; set; } = string.Empty;
        public string Dt_vendastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vendastr).ToString("dd/MM/yyyy hh:mm");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vendastr = value;
                try
                {
                    dt_venda = Convert.ToDateTime(value);
                }
                catch
                { dt_venda = null; }
            }
        }
        private DateTime? dt_dataentrega { get; set; } = null;
        public DateTime? Dt_dataentrega
        {
            get { return dt_dataentrega; }
            set
            {
                dt_dataentrega = value;
                dt_dataentregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy hh:mm") : string.Empty;
            }
        }
        private string dt_dataentregastr { get; set; } = string.Empty;
        public string Dt_dataentregastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_dataentregastr).ToString("dd/MM/yyyy hh:mm");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_dataentregastr = value;
                try
                {
                    dt_dataentrega = Convert.ToDateTime(value);
                }
                catch
                { dt_dataentrega = null; }
            }
        }
        public string bairro { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
        public string proximo { get; set; } = string.Empty;
        public string st_clientetira { get; set; } = string.Empty;

        public bool bool_clientetira
        {
            get
            {
                if (st_clientetira.Equals("S"))
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    st_clientetira = "S";
                else
                    st_clientetira = "N";
            }
        }

        public TList_PreVenda_Item lItens { get; set; } = new TList_PreVenda_Item();
        public TList_PreVenda_Item lDelItens { get; set; } = new TList_PreVenda_Item();
        public Faturamento.PDV.TList_VendaRapida lVenda = new Faturamento.PDV.TList_VendaRapida();

        public string distancia { get; set; } = string.Empty;
        public Financeiro.Cadastros.TList_CadEndereco lend { get; set; } = new Financeiro.Cadastros.TList_CadEndereco();
        public bool agrupador { get; set; } = false;

        public decimal valor_cartao { get; set; } = decimal.Zero;
    } 
    public class TList_PreVenda : List<TRegistro_PreVenda>, IComparer<TRegistro_PreVenda>
    {
        #region IComparer<TRegistro_CadClifor> Members
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

        public TList_PreVenda()
        { }

        public TList_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PreVenda x, TRegistro_PreVenda y)
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


    public class TCD_PreVenda : TDataQuery
    {
        public TCD_PreVenda() { }

        public TCD_PreVenda(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string order)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " d.nr_cartao,d.nr_nfce, d.id_cupom, ");
                sql.AppendLine("d.cd_clifor, d.nm_clifor,a.st_clienteretira,e.celular ");
                sql.AppendLine(",a.st_Registro , a.DT_ENTREGADELIVERY,a.st_delivery, ");
                sql.AppendLine("c.nm_clifor as nm_entregador,a.Vl_TrocoPara,A.ObsFecharDelivery, ");
                sql.AppendLine("A.ST_LevarMaqCartao, a.cd_entregador, a.cd_empresa, a.dt_venda, ");
                sql.AppendLine("a.id_prevenda,a.nr_senhafastfood, a.id_cartao, a.cd_garcon, b.nm_clifor ");
                sql.AppendLine(" ,e.numero, e.ds_endereco, e.proximo, e.bairro, d.valor_cartao ");

            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_prevenda a ");
            sql.AppendLine("inner join vtb_res_cartao d ");
            sql.AppendLine("on a.id_cartao = d.id_Cartao ");
            sql.AppendLine("left join vtb_res_clifor e ");
            sql.AppendLine("on d.cd_clifor = e.cd_clifor");
            sql.AppendLine("left join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_garcon = b.cd_clifor");//garcon
            sql.AppendLine("left join tb_fin_clifor C ");
            sql.AppendLine("on a.cd_entregador = C.cd_clifor");//entregador

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(order))
                sql.AppendLine("order by "+order );
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public string BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo,string order)
        {
            string a = string.Empty; 
            if(this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, order), null) != null)
                a= this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, order), null).ToString();
            return a;
        }

        public TList_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string order )
        {
            bool podeFecharBco = false;
            TList_PreVenda lista = new TList_PreVenda();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, order));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PreVenda reg = new TRegistro_PreVenda();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_senhafastfood")))
                        reg.NR_SenhaDelivery = reader.GetDecimal(reader.GetOrdinal("nr_senhafastfood"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_garcon")))
                        reg.cd_garcon = reader.GetString(reader.GetOrdinal("cd_garcon")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_venda")))
                        reg.Dt_venda = reader.GetDateTime(reader.GetOrdinal("Dt_venda")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ENTREGADOR")))
                        reg.cd_entregador = reader.GetString(reader.GetOrdinal("CD_ENTREGADOR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_ENTREGADOR")))
                        reg.ds_entregador = reader.GetString(reader.GetOrdinal("NM_ENTREGADOR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_LevarMaqCartao")))
                        reg.St_levarcartao = reader.GetString(reader.GetOrdinal("ST_LevarMaqCartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ObsFecharDelivery")))
                        reg.ObsFecharDelivery = reader.GetString(reader.GetOrdinal("ObsFecharDelivery"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TrocoPara")))
                        reg.Vl_TrocoPara = reader.GetDecimal(reader.GetOrdinal("Vl_TrocoPara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_ENTREGADELIVERY")))
                        reg.Dt_dataentrega = reader.GetDateTime(reader.GetOrdinal("DT_ENTREGADELIVERY"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_delivery")))
                        reg.St_delivery = reader.GetString(reader.GetOrdinal("st_delivery"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        reg.celular_Clifor = reader.GetString(reader.GetOrdinal("celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.numero = reader.GetString(reader.GetOrdinal("numero"))   ;
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo")))
                        reg.proximo = reader.GetString(reader.GetOrdinal("proximo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Registro")))
                        reg.st_ativo = reader.GetString(reader.GetOrdinal("st_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartao")))
                        reg.nr_cartao = reader.GetString(reader.GetOrdinal("nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nfce")))
                        reg.nf_nfce = reader.GetDecimal(reader.GetOrdinal("nr_nfce")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_clienteretira")))
                        reg.st_clientetira = reader.GetString(reader.GetOrdinal("st_clienteretira")).ToString();

                    if (!reader.IsDBNull(reader.GetOrdinal("valor_cartao")))
                        reg.valor_cartao = reader.GetDecimal(reader.GetOrdinal("valor_cartao"));

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

        public string Gravar(TRegistro_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_GARCON", val.cd_garcon);
            hs.Add("@P_ID_CARTAO", val.id_cartao);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);
            hs.Add("@P_DT_VENDA", val.Dt_venda);
            hs.Add("@P_ST_DELIVERY", val.St_delivery);
            hs.Add("@P_ST_REGISTRO", val.st_ativo);
            hs.Add("@P_OBS_FECHARDELIVERY", val.St_delivery);
            hs.Add("@P_NR_SENHAFASTFOOD", val.NR_SenhaDelivery);
            hs.Add("@P_ST_LEVARMAQCARTAO", val.St_levarcartao);
            hs.Add("@P_VL_TROCOPARA", val.Vl_TrocoPara);
            hs.Add("@P_CD_ENTREGADOR", val.cd_entregador);
            hs.Add("@P_ST_CLIENTERETIRA", val.st_clientetira);
            hs.Add("@P_DT_ENTREGADELIVERY", val.Dt_dataentrega);



            return this.executarProc("IA_RES_PREVENDA", hs);
        }

        public string Excluir(TRegistro_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);

            return this.executarProc("EXCLUI_RES_PREVENDA", hs);
        }
    }
    #endregion

    #region prevendaitens

    public class TRegistro_PreVenda_Item
    {
        public bool st_agregar { get; set; } = false;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? id_prevenda { get; set; } = null;
        public decimal? id_item { get; set; } = null;
        public decimal? id_itemPaiAdic { get; set; } = null;
        public decimal? id_cartao { get; set; } = null;
        public string cd_produto { get; set; } = string.Empty;
        public string ds_produto { get; set; } = string.Empty;
        public decimal quantidade { get; set; } = decimal.Zero;
        public decimal quantidade_agregar { get; set; } = decimal.Zero;
        public decimal casasdecimais { get; set; } = decimal.Zero;
        public string st_registro { get; set; } = "A";
        public decimal vl_unitario { get; set; } = decimal.Zero; 
        public decimal vl_desconto { get; set; } = decimal.Zero;
        public decimal vl_desconto_total { get { return vl_desconto * quantidade; } } 
        public bool st_adicionado { get; set; } = false;
        public bool st_removido { get; set; } = false;
        public decimal vl_liquido
        {
            get
            {
                return Convert.ToDecimal(decimal.Subtract(decimal.Multiply(quantidade, vl_unitario), vl_desconto).ToString("N" + (casasdecimais != decimal.Zero ? casasdecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR")));
            }
            set { }
        }
        public TList_SaboresItens lSabores { get; set; } = new TList_SaboresItens();
        public decimal qtd_faturada { get; set; } = decimal.Zero;
        public decimal qtd_faturar { get; set; } = decimal.Zero;
        public string cd_condfiscal_produto { get; set; } = string.Empty;
        public string obsItem { get; set; } = string.Empty;
        public string Cd_grupo { get; set; } = string.Empty;
        public string ds_grupo { get; set; } = string.Empty;
        public decimal vl_subtotal
        {
            get
            {
                return Convert.ToDecimal(decimal.Multiply(quantidade, (vl_unitario ) ).ToString("N" + (casasdecimais != decimal.Zero ? casasdecimais.ToString() : "2"), new System.Globalization.CultureInfo("pt-BR")));
            }
            set
            {

            }
        }
        public decimal id_portaimp { get; set; } = decimal.Zero;
        public string porta_imp { get; set; } = string.Empty;
        public string st_obsitem { get; set; } = string.Empty;
        private string st_impresso;
        public string St_impresso
        {
            get { return st_impresso; }
            set
            {
                st_impresso = value;
                st_impressobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_impressobool;
        public bool St_impressobool
        {
            get { return st_impressobool; }
            set
            {
                st_impressobool = value;
                st_impresso = value ? "S" : "N";
            }
        }
        /// <summary>
        /// st_excluir, quando true objeto pode ser excluido
        /// status utilizado na prevenda restaurante, lancamento de true 
        /// </summary>
        public bool st_excluir { get; set; } = false;
        public TRegistro_TapTransactions tapTransactions { get; set; }
        public DateTime Dt_Cad { get; set; }
        /// <summary>
        /// utilizado na impressão de Res.IMP_Cartao.Impressao_ITENSPORPORTA
        /// </summary>
        public bool st_gerouErroImpressao { get; set; }
        /// <summary>
        /// utilizado para controlar exclusão de item sendo produto ou servico (sinuca/boliche produto ou servico)
        /// quando produto (true) significa que o lancamento foi efetuado pela tela de prevenda, logo nao tem relacao com movimentação (servico) e podendo exclusão
        /// quando servico não permite exclução pois houve movimentacao do produto
        /// </summary>
        public bool st_produto { get; set; } = false;
        public string Ch_torneira { get; set; } = string.Empty;

        public string LoginCanc { get; set; } = string.Empty;

        public TRegistro_PreVenda_Item _ItemAdicional { get; set; }

        public TRegistro_PreVenda_Item()
        {
            id_portaimp = decimal.Zero;
            id_prevenda = null;
            id_item = null;
            id_cartao = null;
            id_itemPaiAdic = null;

            Cd_empresa = string.Empty;
            cd_produto = string.Empty;
            ds_produto = string.Empty;

            st_obsitem = string.Empty;
            st_agregar = false;
            porta_imp = string.Empty;
            vl_liquido = decimal.Zero;
            obsItem = string.Empty;
            quantidade = decimal.Zero;
            casasdecimais = decimal.Zero;
            st_registro = "A";
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            st_adicionado = false; 
            st_removido = false;
            vl_desconto = decimal.Zero;
            qtd_faturada = decimal.Zero;
            cd_condfiscal_produto = string.Empty;
            st_impresso = "N";
            st_impressobool = false;
            tapTransactions = null;
            st_gerouErroImpressao = false;
        }
    }

    public class TList_PreVenda_Item : List<TRegistro_PreVenda_Item> { }

    public class TCD_PreVenda_Item : TDataQuery
    {
        public TCD_PreVenda_Item() { }

        public TCD_PreVenda_Item(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.vl_liquido, a.id_itemPaiAdic, a.obsItem, a.id_prevenda, e.id_cartao, a.vl_desconto, ");
                sql.AppendLine("isnull(a.st_registro,'A') as st_registro , a.cd_empresa, a.cd_produto, a.quantidade,a.qtd_faturada, a.dt_cad, ");
                sql.AppendLine("b.cd_condfiscal_produto, a.qtd_faturar , a.vl_unitario, a.id_item, a.id_prevenda, a.cd_empresa, b.ds_produto, ");
                sql.AppendLine("c.casasdecimais, b.id_localimp, f.porta_imp, a.st_impresso, a.ch_torneira, b.cd_grupo, a.logincanc ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from vtb_res_itensprevenda a ");
            sql.AppendLine(" join tb_est_produto b on a.cd_produto = b.cd_produto ");
            sql.AppendLine(" left join tb_est_unidade c on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine(" inner join tb_res_prevenda d on a.id_prevenda = d.id_prevenda ");
            sql.AppendLine(" inner join tb_res_cartao e on d.id_cartao = e.id_cartao ");
            sql.AppendLine(" left join tb_res_localimp f on f.id_localimp = b.id_localimp");

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

        public TList_PreVenda_Item Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PreVenda_Item lista = new TList_PreVenda_Item();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PreVenda_Item reg = new TRegistro_PreVenda_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_liquido")))
                        reg.vl_liquido = reader.GetDecimal(reader.GetOrdinal("vl_liquido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("casasdecimais")))
                        reg.casasdecimais = reader.GetDecimal(reader.GetOrdinal("casasdecimais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_faturada")))
                        reg.qtd_faturada = reader.GetDecimal(reader.GetOrdinal("qtd_faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_faturar")))
                        reg.qtd_faturar = reader.GetDecimal(reader.GetOrdinal("qtd_faturar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obsItem")))
                        reg.obsItem = reader.GetString(reader.GetOrdinal("obsItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_localimp")))
                        reg.id_portaimp = reader.GetDecimal(reader.GetOrdinal("id_localimp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_imp")))
                        reg.porta_imp = reader.GetString(reader.GetOrdinal("porta_imp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.st_registro = reader.GetString(reader.GetOrdinal("st_registro")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemPaiAdic")))
                        reg.id_itemPaiAdic = reader.GetDecimal(reader.GetOrdinal("id_itemPaiAdic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_impresso")))
                        reg.St_impresso = reader.GetString(reader.GetOrdinal("St_impresso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cad")))
                        reg.Dt_Cad = reader.GetDateTime(reader.GetOrdinal("dt_cad"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ch_Torneira")))
                        reg.Ch_torneira = reader.GetString(reader.GetOrdinal("Ch_Torneira"));

                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        reg.LoginCanc = reader.GetString(reader.GetOrdinal("LoginCanc"));

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

        public string Gravar(TRegistro_PreVenda_Item val)
        {
            Hashtable hs = new Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.cd_produto);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);
            hs.Add("@P_ID_ITEM", val.id_item);
            hs.Add("@P_QUANTIDADE", val.quantidade);
            hs.Add("@P_VL_UNITARIO", val.vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.vl_desconto);
            hs.Add("@P_OBSITEM", val.obsItem);
            hs.Add("@P_ST_REGISTRO", val.st_registro);
            hs.Add("@P_ID_ITEMPAIADIC", val.id_itemPaiAdic);
            hs.Add("@P_ST_IMPRESSO", val.St_impresso);
            hs.Add("@P_CH_TORNEIRA", val.Ch_torneira);
            hs.Add("@P_LOGINCANC", val.LoginCanc);

            return this.executarProc("IA_RES_ITENSPREVENDA", hs);
        }

        public string Excluir(TRegistro_PreVenda_Item val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PREVENDA", val.id_prevenda);
            hs.Add("@P_ID_ITEM", val.id_item);

            return this.executarProc("EXCLUI_RES_ITENSPREVENDA", hs);
        }
    }

    #endregion

    #region saboresitens
    public class TRegistro_SaboresItens : CamadaDados.Restaurante.Cadastro.TRegistro_Sabores
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal? Id_PreVenda { get; set; } = null;
        public string Id_PreVendaStr
        {
            get
            {
                return Id_PreVenda.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Id_PreVenda = Convert.ToDecimal(value);
            }
        }
        public decimal? Id_Item { get; set; } = null;
        public string Id_ItemStr
        {
            get
            {
                return Id_Item.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Id_Item = Convert.ToDecimal(value);
            }
        }
        public bool st_agregar { get; set; } = false;

        public TRegistro_SaboresItens()
        {
            Id_Item = null;
            Id_PreVenda = null;
            Cd_Empresa = string.Empty;
            st_agregar = false;
            ID_Sabor = null;
            DS_Sabor = string.Empty;
        }
    }
    public class TList_SaboresItens : List<TRegistro_SaboresItens>, IComparer<TRegistro_SaboresItens>
    {
        #region IComparer<TRegistro_CadClifor> Members
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

        public TList_SaboresItens()
        { }

        public TList_SaboresItens(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_SaboresItens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_SaboresItens x, TRegistro_SaboresItens y)
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


    public class TCD_SaboresItens : TDataQuery
    {
        public TCD_SaboresItens() { }

        public TCD_SaboresItens(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string order)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_prevenda, a.id_item, a.id_sabor, b.ds_sabor,a.cd_grupo  ");
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from TB_RES_SaboresItens  a ");
            sql.AppendLine("inner join TB_RES_Sabores b on a.id_sabor = b.id_sabor and a.cd_grupo = b.cd_grupo "); 


            string cond = " where ";
            //     sql.AppendLine("where  ");
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(order))
            {
                sql.AppendLine("order by " + order);
            }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public string BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string order)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, order), null).ToString();
        }

        public TList_SaboresItens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_SaboresItens lista = new TList_SaboresItens();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaboresItens reg = new TRegistro_SaboresItens();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_PreVenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Item")))
                        reg.Id_Item = reader.GetDecimal(reader.GetOrdinal("Id_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Sabor")))
                        reg.ID_Sabor = reader.GetDecimal(reader.GetOrdinal("ID_Sabor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Sabor")))
                        reg.DS_Sabor = reader.GetString(reader.GetOrdinal("DS_Sabor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Sabor")))
                        reg.DS_Sabor = reader.GetString(reader.GetOrdinal("DS_Sabor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));

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

        public string Gravar(TRegistro_SaboresItens val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa); 
            hs.Add("@P_ID_PREVENDA", val.Id_PreVenda);
            hs.Add("@P_ID_SABOR", val.ID_Sabor);
            hs.Add("@P_CD_GRUPO", val.cd_grupo);
            hs.Add("@P_ID_ITEM", val.Id_Item);


            return this.executarProc("IA_RES_SABORESITENS", hs);
        }

        public string Excluir(TRegistro_SaboresItens val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_PREVENDA", val.Id_PreVenda);
            hs.Add("@P_ID_SABOR", val.ID_Sabor);
            hs.Add("@P_CD_GRUPO", val.cd_grupo);
            hs.Add("@P_ID_ITEM", val.Id_Item);

            return this.executarProc("EXCLUI_RES_SABORESITENS", hs);
        }
    }
    #endregion
}
