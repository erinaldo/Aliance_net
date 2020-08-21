using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Entrega
{
    #region Romaneio Entrega
    public class TList_RomaneioEntrega : List<TRegistro_RomaneioEntrega>, IComparer<TRegistro_RomaneioEntrega>
    {
        #region IComparer<TRegistro_RomaneioEntrega> Members
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

        public TList_RomaneioEntrega()
        { }

        public TList_RomaneioEntrega(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_RomaneioEntrega value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_RomaneioEntrega x, TRegistro_RomaneioEntrega y)
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

    
    public class TRegistro_RomaneioEntrega
    {
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? id_romaneio;
        
        public decimal? Id_romaneio
        {
            get { return id_romaneio; }
            set
            {
                id_romaneio = value;
                id_romaneiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_romaneiostr;
        
        public string Id_romaneiostr
        {
            get { return id_romaneiostr; }
            set
            {
                id_romaneiostr = value;
                try
                {
                    id_romaneio = decimal.Parse(value);
                }
                catch
                { id_romaneio = null; }
            }
        }
        
        public string Nm_cliente
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Numero
        { get; set; }
        
        public string Bairro
        { get; set; }
        
        public string Cidade
        { get; set; }
        
        public string UF
        { get; set; }
        
        public string Referencia
        { get; set; }
        
        public string Fone
        { get; set; }
        private DateTime? dt_romaneio;
        
        public DateTime? Dt_romaneio
        {
            get { return dt_romaneio; }
            set
            {
                dt_romaneio = value;
                dt_romaneiostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_romaneiostr;
        public string Dt_romaneiostr
        {
            get { return dt_romaneiostr; }
            set
            {
                dt_romaneiostr = value;
                try
                {
                    dt_romaneio = DateTime.Parse(value);
                }
                catch
                { dt_romaneio = null; }
            }
        }
        private DateTime? dt_PrevEntrega;
        
        public DateTime? Dt_PrevEntrega
        {
            get { return dt_PrevEntrega; }
            set
            {
                dt_PrevEntrega = value;
                dt_PrevEntregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_PrevEntregastr;
        public string Dt_PrevEntregastr
        {
            get { return dt_PrevEntregastr; }
            set
            {
                dt_PrevEntregastr = value;
                try
                {
                    dt_PrevEntrega = DateTime.Parse(value);
                }
                catch
                { dt_PrevEntrega = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public TList_ItensRomaneio lItens
        { get; set; }
        
        public TList_ItensRomaneio lItensDel
        { get; set; }

        public TRegistro_RomaneioEntrega()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_romaneio = null;
            this.id_romaneiostr = string.Empty;
            this.Nm_cliente = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Numero = string.Empty;
            this.Bairro = string.Empty;
            this.Cidade = string.Empty;
            this.UF = string.Empty;
            this.Referencia = string.Empty;
            this.Fone = string.Empty;
            this.dt_romaneio = null;
            this.dt_romaneiostr = string.Empty;
            this.dt_PrevEntrega = null;
            this.dt_PrevEntregastr = string.Empty;
            this.Ds_observacao = string.Empty;

            this.lItens = new TList_ItensRomaneio();
            this.lItensDel = new TList_ItensRomaneio();
        }
    }

    public class TCD_RomaneioEntrega : TDataQuery
    {
        public TCD_RomaneioEntrega()
        { }

        public TCD_RomaneioEntrega(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Romaneio, ");
                sql.AppendLine("a.NM_Cliente, a.DS_Endereco, a.Numero, a.Bairro, a.Cidade, ");
                sql.AppendLine("a.UF, a.Referencia, a.Fone, a.DT_Romaneio, ");
                sql.AppendLine("a.DT_PrevEntrega, a.DS_Observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_RomaneioEntrega a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

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

        public TList_RomaneioEntrega Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_RomaneioEntrega lista = new TList_RomaneioEntrega();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_RomaneioEntrega reg = new TRegistro_RomaneioEntrega();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Romaneio")))
                        reg.Id_romaneio = reader.GetDecimal(reader.GetOrdinal("ID_Romaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Cliente")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("NM_Cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("Bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cidade")))
                        reg.Cidade = reader.GetString(reader.GetOrdinal("Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.UF = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Referencia")))
                        reg.Referencia = reader.GetString(reader.GetOrdinal("Referencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Romaneio")))
                        reg.Dt_romaneio = reader.GetDateTime(reader.GetOrdinal("DT_Romaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevEntrega")))
                        reg.Dt_PrevEntrega = reader.GetDateTime(reader.GetOrdinal("DT_PrevEntrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));;

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

        public string Gravar(TRegistro_RomaneioEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);
            hs.Add("@P_NM_CLIENTE", val.Nm_cliente);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_NUMERO", val.Numero);
            hs.Add("@P_BAIRRO", val.Bairro);
            hs.Add("@P_CIDADE", val.Cidade);
            hs.Add("@P_UF", val.UF);
            hs.Add("@P_REFERENCIA", val.Referencia);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_DT_ROMANEIO", val.Dt_romaneio);
            hs.Add("@P_DT_PREVENTREGA", val.Dt_PrevEntrega);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FAT_ROMANEIOENTREGA", hs);
        }

        public string Excluir(TRegistro_RomaneioEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);

            return this.executarProc("EXCLUI_FAT_ROMANEIOENTREGA", hs);
        }
    }
    #endregion

    #region Itens Romaneio
    public class TList_ItensRomaneio : List<TRegistro_ItensRomaneio>, IComparer<TRegistro_ItensRomaneio>
    {
        #region IComparer<TRegistro_ItensRomaneio> Members
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

        public TList_ItensRomaneio()
        { }

        public TList_ItensRomaneio(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensRomaneio value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensRomaneio x, TRegistro_ItensRomaneio y)
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

    
    public class TRegistro_ItensRomaneio
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_romaneio;
        
        public decimal? Id_romaneio
        {
            get { return id_romaneio; }
            set
            {
                id_romaneio = value;
                id_romaneiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_romaneiostr;
        
        public string Id_romaneiostr
        {
            get { return id_romaneiostr; }
            set
            {
                id_romaneiostr = value;
                try
                {
                    id_romaneio = decimal.Parse(value);
                }
                catch
                { id_romaneio = null; }
            }
        }
        private decimal? id_itemromaneio;
        
        public decimal? Id_itemromaneio
        {
            get { return id_itemromaneio; }
            set
            {
                id_itemromaneio = value;
                id_itemromaneiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemromaneiostr;
        
        public string Id_itemromaneiostr
        {
            get { return id_itemromaneiostr; }
            set
            {
                id_itemromaneiostr = value;
                try
                {
                    id_itemromaneio = decimal.Parse(value);
                }
                catch
                { id_itemromaneio = null; }
            }
        }
        
        public decimal? Id_prevenda
        { get; set; }
        
        public decimal? Id_itemprevenda
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public decimal? Id_pedidoitem
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Qtd_venda
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Qtd_programada
        { get; set; }
        
        public decimal Qtd_entregue
        { get; set; }
        
        public decimal SaldoEntregar
        { get { return Quantidade - Qtd_programada - Qtd_entregue; } }
        
        public decimal Qtd_entregar
        { get; set; }
        
        public string Nm_cliente
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Numero
        { get; set; }
        
        public string Bairro
        { get; set; }
        
        public string Cidade
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_ItensRomaneio()
        {
            this.Cd_empresa = string.Empty;
            this.id_romaneio = null;
            this.id_romaneiostr = string.Empty;
            this.id_itemromaneio = null;
            this.id_itemromaneiostr = string.Empty;
            this.Id_prevenda = null;
            this.Id_itemprevenda = null;
            this.Nr_pedido = null;
            this.Id_pedidoitem = null;
            this.Cd_local = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Qtd_venda = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.Qtd_programada = decimal.Zero;
            this.Qtd_entregue = decimal.Zero;
            this.Qtd_entregar = decimal.Zero;
            this.Nm_cliente = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Numero = string.Empty;
            this.Bairro = string.Empty;
            this.Cidade = string.Empty;
            this.St_processar = false;
        }
    }

    public class TCD_ItensRomaneio : TDataQuery
    {
        public TCD_ItensRomaneio()
        { }

        public TCD_ItensRomaneio(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Romaneio, a.ID_ItemRomaneio, ");
                sql.AppendLine("a.id_prevenda, a.id_itemprevenda, a.nr_pedido, a.id_pedidoitem, ");
                sql.AppendLine("a.cd_local, e.ds_local, a.CD_Produto, c.ds_produto, d.sigla_unidade, ");
                sql.AppendLine("b.nm_cliente, b.ds_endereco, b.numero, b.bairro, b.cidade, ");
                sql.AppendLine("a.Quantidade, a.Qtd_venda, a.Qtd_programada, a.Qtd_entregue ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_FAT_ITENSROMANEIO a ");
            sql.AppendLine("inner join TB_FAT_RomaneioEntrega b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.ID_Romaneio = b.ID_Romaneio ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join TB_EST_LocalArm e ");
            sql.AppendLine("on a.cd_local = e.CD_Local ");

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

        public TList_ItensRomaneio Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensRomaneio lista = new TList_ItensRomaneio();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensRomaneio reg = new TRegistro_ItensRomaneio();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Romaneio")))
                        reg.Id_romaneio = reader.GetDecimal(reader.GetOrdinal("ID_Romaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemRomaneio")))
                        reg.Id_itemromaneio = reader.GetDecimal(reader.GetOrdinal("ID_ItemRomaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_venda")))
                        reg.Qtd_venda = reader.GetDecimal(reader.GetOrdinal("Qtd_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_programada")))
                        reg.Qtd_programada = reader.GetDecimal(reader.GetOrdinal("Qtd_programada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_entregue")))
                        reg.Qtd_entregue = reader.GetDecimal(reader.GetOrdinal("Qtd_entregue"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliente")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("nm_cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cidade")))
                        reg.Cidade = reader.GetString(reader.GetOrdinal("cidade"));

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

        public string Gravar(TRegistro_ItensRomaneio val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);
            hs.Add("@P_ID_ITEMROMANEIO", val.Id_itemromaneio);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);


            return this.executarProc("IA_FAT_ITENSROMANEIO", hs);
        }

        public string Excluir(TRegistro_ItensRomaneio val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);
            hs.Add("@P_ID_ITEMROMANEIO", val.Id_itemromaneio);

            return this.executarProc("EXCLUI_FAT_ITENSROMANEIO", hs);
        }
    }
    #endregion
}
