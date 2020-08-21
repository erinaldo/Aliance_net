using CamadaDados.Financeiro.Duplicata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Servicos
{
    #region Contrato Servico
    public class TList_Contrato : List<TRegistro_Contrato>, IComparer<TRegistro_Contrato>
    {
        #region IComparer<TRegistro_Contrato> Members
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

        public TList_Contrato()
        { }

        public TList_Contrato(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Contrato value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Contrato x, TRegistro_Contrato y)
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
    
    public class TRegistro_Contrato
    {
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_contratante
        { get; set; }
        public string Nm_contratante
        { get; set; }
        public string Cd_endcontratante
        { get; set; }
        public string Ds_endcontratante
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        private decimal? id_configboleto;
        public decimal? Id_configboleto
        {
            get { return id_configboleto; }
            set
            {
                id_configboleto = value;
                id_configboletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configboletostr;
        public string Id_configboletostr
        {
            get { return id_configboletostr; }
            set
            {
                id_configboletostr = value;
                try
                {
                    id_configboleto = decimal.Parse(value);
                }
                catch { id_configboleto = null; }
            }
        }
        public string Ds_configboleto
        { get; set; }
        public string Cd_condpgtocarne { get; set; }
        public string Ds_condpgtocarne { get; set; }
        public decimal Qt_parcelas { get; set; }
        public string Nr_contratorigem
        { get; set; }
        private DateTime? dt_abertura;
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_aberturastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = DateTime.Parse(value);
                }
                catch
                { dt_abertura = null; }
            }
        }
        private DateTime? dt_encerramento;
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_encerramentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = DateTime.Parse(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }
        public string Ds_contrato
        { get; set; }
        public decimal Diavenctofatura
        { get; set; }
        public string St_registro
        { get; set; }
        public DateTime Dt_servidor
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADO";
                else if (St_registro.Trim().ToUpper().Equals("S"))
                    return "SUSPENSO";
                else return string.Empty;
            }
        }
        public decimal Vl_contrato
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_Contrato_Itens lItens
        { get; set; }
        public TList_Contrato_Itens lItensDel
        { get; set; }
        public TList_SuspContrato lSuspenso
        { get; set; }
        public TList_Contrato_X_Carne lCarne { get; set; }
        public Faturamento.NotaFiscal.TList_RegLanFaturamento lNF
        { get; set; }

        public TRegistro_Contrato()
        {
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_contratante = string.Empty;
            Nm_contratante = string.Empty;
            Cd_endcontratante = string.Empty;
            Ds_endcontratante = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cfg_pedido = string.Empty;
            Ds_tipopedido = string.Empty;
            id_configboleto = null;
            id_configboletostr = string.Empty;
            Ds_configboleto = string.Empty;
            Nr_contratorigem = string.Empty;
            dt_abertura = null;
            dt_aberturastr = string.Empty;
            dt_encerramento = null;
            dt_encerramentostr = string.Empty;
            Dt_servidor = DateTime.Now;
            Ds_contrato = string.Empty;
            Diavenctofatura = decimal.Zero;
            St_registro = "A";
            Vl_contrato = decimal.Zero;
            Cd_condpgtocarne = string.Empty;
            Ds_condpgtocarne = string.Empty;
            Qt_parcelas = decimal.Zero;
            St_processar = false;

            lItens = new TList_Contrato_Itens();
            lItensDel = new TList_Contrato_Itens();
            lSuspenso = new TList_SuspContrato();
            lNF = new Faturamento.NotaFiscal.TList_RegLanFaturamento();
            lCarne = new TList_Contrato_X_Carne();
        }
    }

    public class TCD_Contrato : TDataQuery
    {
        public TCD_Contrato()
        { }

        public TCD_Contrato(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.NR_Contrato, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Contratante, c.NM_Clifor, a.cd_condpgtocarne, ");
                sql.AppendLine("a.CD_EndContratante, d.DS_Endereco, h.ds_condpgto, h.qt_parcelas, ");
                sql.AppendLine("a.CD_Vendedor, e.nm_clifor as NomeVendedor, a.NR_ContratoOrigem, ");
                sql.AppendLine("a.cfg_pedido, f.ds_tipopedido, a.id_config, g.ds_config, ");
                sql.AppendLine("a.DT_Abertura, a.DT_Encerramento, a.DS_Contrato, ");
                sql.AppendLine("a.DiaVenctoFatura, a.ST_Registro, getdate() as dt_servidor, ");
                sql.AppendLine("vl_contrato = isnull((select sum(isnull(x.quantidade, 0) * isnull(x.vl_unitario, 0)) ");
                sql.AppendLine("                        from tb_ose_contrato_itens x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.nr_contrato = a.nr_contrato), 0)");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_OSE_Contrato a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.CD_Contratante = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.CD_Contratante = d.CD_Clifor ");
            sql.AppendLine("and a.CD_EndContratante = d.CD_Endereco ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.CD_Vendedor = e.cd_clifor ");
            sql.AppendLine("inner join tb_fat_cfgpedido f ");
            sql.AppendLine("on a.cfg_pedido = f.cfg_pedido ");
            sql.AppendLine("left outer join tb_cob_cfgbanco g ");
            sql.AppendLine("on a.id_config = g.id_config ");
            sql.AppendLine("left outer join tb_fin_condpgto h ");
            sql.AppendLine("on a.cd_condpgtocarne = h.cd_condpgto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Contrato Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Contrato lista = new TList_Contrato();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato reg = new TRegistro_Contrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contratante")))
                        reg.Cd_contratante = reader.GetString(reader.GetOrdinal("CD_Contratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_contratante = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndContratante")))
                        reg.Cd_endcontratante = reader.GetString(reader.GetOrdinal("CD_EndContratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endcontratante = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NomeVendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("NomeVendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_configboleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_configboleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ContratoOrigem")))
                        reg.Nr_contratorigem = reader.GetString(reader.GetOrdinal("NR_ContratoOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Encerramento")))
                        reg.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("DT_Encerramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contrato")))
                        reg.Ds_contrato = reader.GetString(reader.GetOrdinal("DS_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DiaVenctoFatura")))
                        reg.Diavenctofatura = reader.GetDecimal(reader.GetOrdinal("DiaVenctoFatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_servidor")))
                        reg.Dt_servidor = reader.GetDateTime(reader.GetOrdinal("dt_servidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contrato")))
                        reg.Vl_contrato = reader.GetDecimal(reader.GetOrdinal("vl_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgtocarne")))
                        reg.Cd_condpgtocarne = reader.GetString(reader.GetOrdinal("cd_condpgtocarne"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgtocarne = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_parcelas")))
                        reg.Qt_parcelas = reader.GetDecimal(reader.GetOrdinal("qt_parcelas"));

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

        public string Gravar(TRegistro_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(14);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTRATANTE", val.Cd_contratante);
            hs.Add("@P_CD_ENDCONTRATANTE", val.Cd_endcontratante);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_ID_CONFIG", val.Id_configboleto);
            hs.Add("@P_NR_CONTRATOORIGEM", val.Nr_contratorigem);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_ENCERRAMENTO", val.Dt_encerramento);
            hs.Add("@P_DS_CONTRATO", val.Ds_contrato);
            hs.Add("@P_DIAVENCTOFATURA", val.Diavenctofatura);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_CONDPGTOCARNE", val.Cd_condpgtocarne);

            return executarProc("IA_OSE_CONTRATO", hs);
        }

        public string Excluir(TRegistro_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_OSE_CONTRATO", hs);
        }
    }
    #endregion

    #region Itens Contrato
    public class TList_Contrato_Itens : List<TRegistro_Contrato_Itens>
    { }

    
    public class TRegistro_Contrato_Itens
    {
        private decimal? nr_contrato;
        
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
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
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_condfiscal_produto
        { get; set; }
        
        public string Cd_unidproduto
        { get; set; }
        
        public string Ds_unidproduto
        { get; set; }
        
        public string Sg_unidproduto
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        private decimal vl_unitario;
        
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        public decimal Vl_subtotal
        { get { return Quantidade * vl_unitario; } }

        public TRegistro_Contrato_Itens()
        {
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Cd_empresa = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Cd_unidproduto = string.Empty;
            Ds_unidproduto = string.Empty;
            Sg_unidproduto = string.Empty;
            Quantidade = decimal.Zero;
            vl_unitario = decimal.Zero;
        }
    }

    public class TCD_Contrato_Itens : TDataQuery
    {
        public TCD_Contrato_Itens()
        { }

        public TCD_Contrato_Itens(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.NR_Contrato, a.CD_Empresa, ");
                sql.AppendLine("a.ID_Item, a.CD_Produto, b.DS_Produto, ");
                sql.AppendLine("b.CD_Unidade, c.DS_Unidade, c.Sigla_Unidade, ");
                sql.AppendLine("a.Quantidade, a.Vl_Unitario, b.cd_condfiscal_produto ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_OSE_Contrato_Itens a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Contrato_Itens Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Contrato_Itens lista = new TList_Contrato_Itens();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato_Itens reg = new TRegistro_Contrato_Itens();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidproduto = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidproduto = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sg_unidproduto = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    
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

        public string Gravar(TRegistro_Contrato_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);

            return executarProc("IA_OSE_CONTRATO_ITENS", hs);
        }

        public string Excluir(TRegistro_Contrato_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_OSE_CONTRATO_ITENS", hs);
        }
    }
    #endregion

    #region Contrato X NF
    public class TList_Contrato_X_NF : List<TRegistro_Contrato_X_NF>
    { }
    
    public class TRegistro_Contrato_X_NF
    {
        private decimal? nr_contrato;
        
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        
        public string Cd_empresa
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

        public TRegistro_Contrato_X_NF()
        {
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Cd_empresa = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
        }
    }

    public class TCD_Contrato_X_NF : TDataQuery
    {
        public TCD_Contrato_X_NF()
        { }

        public TCD_Contrato_X_NF(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strtop + " a.NR_Contrato, a.CD_Empresa, a.Nr_LanctoFiscal ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_OSE_Contrato_X_NF a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Contrato_X_NF Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Contrato_X_NF lista = new TList_Contrato_X_NF();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato_X_NF reg = new TRegistro_Contrato_X_NF();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    
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

        public string Gravar(TRegistro_Contrato_X_NF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return executarProc("IA_OSE_CONTRATO_X_NF", hs);
        }

        public string Excluir(TRegistro_Contrato_X_NF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return executarProc("EXCLUI_OSE_CONTRATO_X_NF", hs);
        }
    }
    #endregion

    #region Contrato X Carne
    public class TList_Contrato_X_Carne : List<TRegistro_Contrato_X_Carne> { }
    public class TRegistro_Contrato_X_Carne
    {
        public string Cd_empresa { get; set; }
        private decimal? nr_contrato;

        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;

        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch { nr_contrato = null; }
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
                catch { nr_lancto = null; }
            }
        }
        public string Nr_docto { get; set; }
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
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }catch { dt_emissao = null; }
            }
        }
        public decimal QT_Parcelas { get; set; }
        public TList_RegLanParcela lParc { get; set; }
        public TRegistro_Contrato_X_Carne()
        {
            Cd_empresa = string.Empty;
            nr_contrato = null;
            nr_contratostr = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            Nr_docto = string.Empty;
            dt_emissao = null;
            dt_emissaostr = string.Empty;
            QT_Parcelas = decimal.Zero;
            lParc = new TList_RegLanParcela();
        }
    }
    public class TCD_Contrato_X_Carne:TDataQuery
    {
        public TCD_Contrato_X_Carne() { }
        public TCD_Contrato_X_Carne(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, a.nr_contrato, ");
                sql.AppendLine("a.nr_lancto, b.dt_emissao, b.nr_docto, b.qt_parcelas ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_OSE_Contrato_X_Carne a ");
            sql.AppendLine("inner join TB_FIN_Duplicata b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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
        public TList_Contrato_X_Carne Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Contrato_X_Carne lista = new TList_Contrato_X_Carne();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato_X_Carne reg = new TRegistro_Contrato_X_Carne();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_parcelas")))
                        reg.QT_Parcelas = reader.GetDecimal(reader.GetOrdinal("qt_parcelas"));

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
        public string Gravar(TRegistro_Contrato_X_Carne val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            return executarProc("IA_OSE_CONTRATO_X_CARNE", hs);
        }
        public string Excluir(TRegistro_Contrato_X_Carne val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            return executarProc("EXCLUI_OSE_CONTRATO_X_CARNE", hs);
        }
    }

    #endregion

    #region Suspencao Contrato
    public class TList_SuspContrato : List<TRegistro_SuspContrato>
    { }
    
    public class TRegistro_SuspContrato
    {
        private decimal? id_suspenso;
        public decimal? Id_suspenso
        {
            get { return id_suspenso; }
            set
            {
                id_suspenso = value;
                id_suspensostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_suspensostr;
        public string Id_suspensostr
        {
            get { return id_suspensostr; }
            set
            {
                id_suspensostr = value;
                try
                {
                    id_suspenso = decimal.Parse(value);
                }
                catch { id_suspenso = null; }
            }
        }
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        { 
            get{return nr_contrato;}
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Ds_motivo
        { get; set; }
        private DateTime? dt_inisuspenso;
        public DateTime? Dt_inisuspenso
        {
            get { return dt_inisuspenso; }
            set
            {
                dt_inisuspenso = value;
                dt_inisuspensostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inisuspensostr;
        public string Dt_inisuspensostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inisuspensostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inisuspensostr = value;
                try
                {
                    dt_inisuspenso = DateTime.Parse(value);
                }
                catch
                { dt_inisuspenso = null; }
            }
        }
        private DateTime? dt_prevtermsusp;
        public DateTime? Dt_prevtermsusp
        {
            get { return dt_prevtermsusp; }
            set
            {
                dt_prevtermsusp = value;
                dt_prevtermsuspstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevtermsuspstr;
        public string Dt_prevtermsuspstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevtermsuspstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevtermsuspstr = value;
                try
                {
                    dt_prevtermsusp = DateTime.Parse(value);
                }
                catch
                { dt_prevtermsusp = null; }
            }
        }
        private DateTime? dt_finsuspenso;
        public DateTime? Dt_finsuspenso
        {
            get { return dt_finsuspenso; }
            set
            {
                dt_finsuspenso = value;
                dt_finsuspensostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finsuspensostr;
        public string Dt_finsuspensostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_finsuspensostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finsuspensostr = value;
                try
                {
                    dt_finsuspenso = DateTime.Parse(value);
                }
                catch
                { dt_finsuspenso = null; }
            }
        }

        public TRegistro_SuspContrato()
        {
            id_suspenso = null;
            id_suspensostr = string.Empty;
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Cd_empresa = string.Empty;
            Ds_motivo = string.Empty;
            dt_inisuspenso = null;
            dt_inisuspensostr = string.Empty;
            dt_prevtermsusp = null;
            dt_prevtermsuspstr = string.Empty;
            dt_finsuspenso = null;
            dt_finsuspensostr = string.Empty;
        }
    }

    public class TCD_SuspContrato : TDataQuery
    {
        public TCD_SuspContrato()
        { }

        public TCD_SuspContrato(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_suspenso, a.nr_contrato, ");
                sql.AppendLine("a.cd_empresa, a.ds_motivo, a.dt_inisuspenso, ");
                sql.AppendLine("a.dt_prevtermsusp, a.dt_finsuspenso ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_OSE_SuspContrato a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_SuspContrato Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_SuspContrato lista = new TList_SuspContrato();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SuspContrato reg = new TRegistro_SuspContrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_suspenso")))
                        reg.Id_suspenso = reader.GetDecimal(reader.GetOrdinal("id_suspenso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_inisuspenso")))
                        reg.Dt_inisuspenso = reader.GetDateTime(reader.GetOrdinal("dt_inisuspenso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevtermsusp")))
                        reg.Dt_prevtermsusp = reader.GetDateTime(reader.GetOrdinal("dt_prevtermsusp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_finsuspenso")))
                        reg.Dt_finsuspenso = reader.GetDateTime(reader.GetOrdinal("dt_finsuspenso"));

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

        public string Gravar(TRegistro_SuspContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_SUSPENSO", val.Id_suspenso);
            hs.Add("@P_DS_MOTIVO", val.Ds_motivo);
            hs.Add("@P_DT_INISUSPENSO", val.Dt_inisuspenso);
            hs.Add("@P_DT_PREVTERMSUSP", val.Dt_prevtermsusp);
            hs.Add("@P_DT_FINSUSPENSO", val.Dt_finsuspenso);

            return executarProc("IA_OSE_SUSPCONTRATO", hs);
        }

        public string Excluir(TRegistro_SuspContrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_SUSPENSO", val.Id_suspenso);

            return executarProc("EXCLUI_OSE_SUSPCONTRATO", hs);
        }
    }
    #endregion
}
