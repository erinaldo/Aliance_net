using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Entrega
{
    #region Carga Entrega
    public class TList_CargaEntrega : List<TRegistro_CargaEntrega>, IComparer<TRegistro_CargaEntrega>
    {
        #region IComparer<TRegistro_CargaEntrega> Members
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

        public TList_CargaEntrega()
        { }

        public TList_CargaEntrega(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CargaEntrega value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CargaEntrega x, TRegistro_CargaEntrega y)
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

    
    public class TRegistro_CargaEntrega
    {
        private decimal? id_carga;
        
        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;
        
        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }
        
        public string Cd_motorista
        { get; set; }
        
        public string Nm_motorista
        { get; set; }
        
        public string Placa
        { get; set; }
        private DateTime? dt_carga;
        
        public DateTime? Dt_carga
        {
            get { return dt_carga; }
            set
            {
                dt_carga = value;
                dt_cargastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_cargastr;
        public string Dt_cargastr
        {
            get { return dt_cargastr; }
            set
            {
                dt_cargastr = value;
                try
                {
                    dt_carga = DateTime.Parse(value);
                }
                catch
                { dt_carga = null; }
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
                    return DateTime.Parse(dt_entregastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_entregastr = value;
                try
                {
                    dt_entrega = DateTime.Parse(value);
                }
                catch
                { dt_entrega = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (this.St_registro.Trim().ToUpper().Equals("E"))
                    return "EXECUTADA";
                else return string.Empty;
            }
        }
        
        public TList_ItensCarga lItens
        { get; set; }
        
        public TList_ItensCarga lItensDel
        { get; set; }

        public TRegistro_CargaEntrega()
        {
            this.id_carga = null;
            this.id_cargastr = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Placa = string.Empty;
            this.dt_carga = null;
            this.dt_cargastr = string.Empty;
            this.dt_entrega = null;
            this.dt_entregastr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";

            this.lItens = new TList_ItensCarga();
            this.lItensDel = new TList_ItensCarga();
        }
    }

    public class TCD_CargaEntrega : TDataQuery
    {
        public TCD_CargaEntrega()
        { }

        public TCD_CargaEntrega(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.ID_Carga, a.CD_Motorista, ");
                sql.AppendLine("a.NM_Motorista, a.Placa, a.DT_Carga, a.DT_Entrega,  ");
                sql.AppendLine("a.DS_Observacao, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CargaEntrega a ");

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

        public TList_CargaEntrega Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CargaEntrega lista = new TList_CargaEntrega();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CargaEntrega reg = new TRegistro_CargaEntrega();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Carga")))
                        reg.Dt_carga = reader.GetDateTime(reader.GetOrdinal("DT_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("DT_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao")); ;
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_CargaEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_DT_CARGA", val.Dt_carga);
            hs.Add("@P_DT_ENTREGA", val.Dt_entrega);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAT_CARGAENTREGA", hs);
        }

        public string Excluir(TRegistro_CargaEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CARGA", val.Id_carga);

            return this.executarProc("EXCLUI_FAT_CARGAENTREGA", hs);
        }
    }
    #endregion

    #region Itens Carga
    public class TList_ItensCarga : List<TRegistro_ItensCarga>, IComparer<TRegistro_ItensCarga>
    {

        #region IComparer<TRegistro_ItensCarga> Members
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

        public TList_ItensCarga()
        { }

        public TList_ItensCarga(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensCarga value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensCarga x, TRegistro_ItensCarga y)
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

    
    public class TRegistro_ItensCarga
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? id_carga;
        
        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;
        
        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }
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
        private decimal? id_itemcarga;
        
        public decimal? Id_itemcarga
        {
            get { return id_itemcarga; }
            set
            {
                id_itemcarga = value;
                id_itemcargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemcargastr;
        
        public string Id_itemcargastr
        {
            get { return id_itemcargastr; }
            set
            {
                id_itemcargastr = value;
                try
                {
                    id_itemcarga = decimal.Parse(value);
                }
                catch
                { id_itemcarga = null; }
            }
        }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal? Id_lanctoEstoque
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Qtd_entregue
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public decimal? Id_prevenda
        { get; set; }
        
        public decimal? Nr_pedido
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
        
        public DateTime? Dt_entrega
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_ItensCarga()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_carga = null;
            this.id_cargastr = string.Empty;
            this.id_romaneio = null;
            this.id_romaneiostr = string.Empty;
            this.id_itemromaneio = null;
            this.id_itemromaneiostr = string.Empty;
            this.id_itemcarga = null;
            this.id_itemcargastr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Id_lanctoEstoque = null;
            this.Quantidade = decimal.Zero;
            this.Qtd_entregue = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.Id_prevenda = null;
            this.Nr_pedido = null;
            this.Nm_cliente = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Numero = string.Empty;
            this.Bairro = string.Empty;
            this.Cidade = string.Empty;
            this.Dt_entrega = null;
            this.St_processar = false;           
        }
    }

    public class TCD_ItensCarga : TDataQuery
    {
        public TCD_ItensCarga()
        { }

        public TCD_ItensCarga(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, emp.NM_Empresa, a.ID_Carga, a.DS_Observacao, f.dt_entrega, ");
                sql.AppendLine("a.ID_Romaneio, a.ID_ItemRomaneio, a.ID_ItemCarga, a.ID_lanctoEstoque,");
                sql.AppendLine("b.CD_Produto, c.ds_produto, d.sigla_unidade, a.Quantidade, a.QTD_Entregue, ");
                sql.AppendLine("b.id_prevenda, b.nr_pedido, e.nm_cliente, e.ds_endereco, e.numero, e.bairro, e.cidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_ItensCarga a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join VTB_FAT_ItensRomaneio b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.ID_Romaneio = b.ID_Romaneio ");
            sql.AppendLine("and a.ID_ItemRomaneio = b.ID_ItemRomaneio ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_fat_romaneioentrega e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and a.id_romaneio = e.id_romaneio ");
            sql.AppendLine("inner join tb_fat_cargaentrega f ");
            sql.AppendLine("on a.id_carga = f.id_carga ");

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

        public TList_ItensCarga Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCarga lista = new TList_ItensCarga();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCarga reg = new TRegistro_ItensCarga();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Romaneio")))
                        reg.Id_romaneio = reader.GetDecimal(reader.GetOrdinal("ID_Romaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemRomaneio")))
                        reg.Id_itemromaneio = reader.GetDecimal(reader.GetOrdinal("ID_ItemRomaneio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemCarga")))
                        reg.Id_itemcarga = reader.GetDecimal(reader.GetOrdinal("ID_ItemCarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lanctoEstoque")))
                        reg.Id_lanctoEstoque = reader.GetDecimal(reader.GetOrdinal("Id_lanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_entregue")))
                        reg.Qtd_entregue = reader.GetDecimal(reader.GetOrdinal("Qtd_entregue"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("dt_entrega"));

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

        public string Gravar(TRegistro_ItensCarga val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);
            hs.Add("@P_ID_ITEMROMANEIO", val.Id_itemromaneio);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoEstoque);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_QTD_ENTREGUE", val.Qtd_entregue);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FAT_ITENSCARGA", hs);
        }

        public string Excluir(TRegistro_ItensCarga val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ROMANEIO", val.Id_romaneio);
            hs.Add("@P_ID_ITEMROMANEIO", val.Id_itemromaneio);
            hs.Add("@P_ID_ITEMCARGA", val.Id_itemcarga);

            return this.executarProc("EXCLUI_FAT_ITENSCARGA", hs);
        }
    }
    #endregion
}
