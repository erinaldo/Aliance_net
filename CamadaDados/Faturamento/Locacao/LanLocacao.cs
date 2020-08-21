using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Locacao
{
    #region Locacao
    public class TList_Locacao : List<TRegistro_Locacao>, IComparer<TRegistro_Locacao>
    {
        #region IComparer<TRegistro_Locacao> Members
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

        public TList_Locacao()
        { }

        public TList_Locacao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Locacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Locacao x, TRegistro_Locacao y)
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
    
    public class TRegistro_Locacao
    {
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
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Cd_vendedor
        { get; set; }
        
        public string Nm_vendedor
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        
        public string Cd_tabelapreco
        { get; set; }
        
        public string Ds_tabelapreco
        { get; set; }
        private DateTime? dt_locacao;
        
        public DateTime? Dt_locacao
        {
            get { return dt_locacao; }
            set
            {
                dt_locacao = value;
                dt_locacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_locacaostr;
        public string Dt_locacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_locacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_locacaostr = value;
                try
                {
                    dt_locacao = Convert.ToDateTime(value);
                }
                catch
                { dt_locacao = null; }
            }
        }
        private DateTime? dt_retirada;
        
        public DateTime? Dt_retirada
        {
            get { return dt_retirada; }
            set
            {
                dt_retirada = value;
                dt_retiradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_retiradastr;
        public string Dt_retiradastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_retiradastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_retiradastr = value;
                try
                {
                    dt_retirada = Convert.ToDateTime(value);
                }
                catch
                { dt_retirada = null; }
            }
        }
        private DateTime? dt_prevdevolucao;
        
        public DateTime? Dt_prevdevolucao
        {
            get { return dt_prevdevolucao; }
            set
            {
                dt_prevdevolucao = value;
                dt_prevdevolucaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevdevolucaostr;
        public string Dt_prevdevolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_prevdevolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevdevolucaostr = value;
                try
                {
                    dt_prevdevolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_prevdevolucao = null; }
            }
        }
        private DateTime? dt_devolucao;
        
        public DateTime? Dt_devolucao
        {
            get { return dt_devolucao; }
            set
            {
                dt_devolucao = value;
                dt_devolucaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_devolucaostr;
        public string Dt_devolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_devolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_devolucaostr = value;
                try
                {
                    dt_devolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_devolucao = null; }
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
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("R"))
                    return "RETIRADO";
                else if (St_registro.Trim().ToUpper().Equals("D"))
                    return "DEVOLVIDO";
                else return string.Empty;
            }
        }
        
        public decimal Vl_locacao
        { get; set; }
        
        public TList_ItensLocacao lItens
        { get; set; }
        
        public TList_ItensLocacao lItensDel
        { get; set; }

        public TRegistro_Locacao()
        {
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.dt_locacao = DateTime.Now;
            this.dt_locacaostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_retirada = null;
            this.dt_retiradastr = string.Empty;
            this.dt_prevdevolucao = null;
            this.dt_prevdevolucaostr = string.Empty;
            this.dt_devolucao = null;
            this.dt_devolucaostr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
            this.Vl_locacao = decimal.Zero;

            this.lItens = new TList_ItensLocacao();
            this.lItensDel = new TList_ItensLocacao();


        }

    }

    public class TCD_Locacao : TDataQuery
    {
        public TCD_Locacao()
        { }

        public TCD_Locacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Locacao, ");
                sql.AppendLine("a.cd_clifor, b.nm_clifor, ");
                sql.AppendLine("a.cd_endereco, g.ds_endereco,");
                sql.AppendLine("a.cd_tabelapreco, t.ds_tabelapreco, ");
                sql.AppendLine("a.cd_empresa, c.nm_empresa, a.dt_locacao, ");
                sql.AppendLine("a.dt_retirada, a.dt_prevdevolucao, ");
                sql.AppendLine(" a.dt_devolucao, a.ds_observacao, a.st_registro, ");
                sql.AppendLine("a.vl_locacao, a.cd_vendedor, x.nm_clifor as nm_vendedor ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_Locacao a ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_Endereco g ");
            sql.AppendLine("on a.cd_clifor = g.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = g.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_Clifor x ");
            sql.AppendLine("on a.cd_vendedor = x.cd_clifor ");
            sql.AppendLine("left outer join tb_div_tabelapreco t ");
            sql.AppendLine("on a.cd_tabelapreco = t.cd_tabelapreco ");

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

        public TList_Locacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Locacao lista = new TList_Locacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Locacao reg = new TRegistro_Locacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("dt_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_retirada")))
                        reg.Dt_retirada = reader.GetDateTime(reader.GetOrdinal("dt_retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevdevolucao")))
                        reg.Dt_prevdevolucao = reader.GetDateTime(reader.GetOrdinal("dt_prevdevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("dt_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_locacao")))
                        reg.Vl_locacao = reader.GetDecimal(reader.GetOrdinal("vl_locacao"));

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

        public string Gravar(TRegistro_Locacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_DT_LOCACAO", val.Dt_locacao);
            hs.Add("@P_DT_RETIRADA", val.Dt_retirada);
            hs.Add("@P_DT_PREVDEVOLUCAO", val.Dt_prevdevolucao);
            hs.Add("@P_DT_DEVOLUCAO", val.Dt_devolucao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FAT_LOCACAO", hs);
        }

        public string Excluir(TRegistro_Locacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);

            return this.executarProc("EXCLUI_FAT_LOCACAO", hs);
        }


    }

    #endregion

    #region ItensLocacao
    public class TList_ItensLocacao : List<TRegistro_ItensLocacao>, IComparer<TRegistro_ItensLocacao>
    {

        #region IComparer<TRegistro_ItensLocacao> Members
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

        public TList_ItensLocacao()
        { }

        public TList_ItensLocacao(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensLocacao x, TRegistro_ItensLocacao y)
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

    
    public class TRegistro_ItensLocacao
    {
        
        public string Cd_empresa
        { get; set; }
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
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_grupo
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        
        public decimal Vl_custo
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Pc_desconto
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }
        
        public decimal Vl_totalcusto
        { get { return this.Quantidade * this.Vl_custo; } }
        public decimal Vl_liquido
        { get { return this.Vl_subtotal - Vl_desconto; } }
        
        public decimal Qtd_devolver
        { get; set; }
        public decimal Sd_devolver
        { get { return this.Quantidade - this.Qtd_devolver; } }
        public decimal Vl_custoPagar
        { get { return Sd_devolver * this.Vl_custo; } }
        
        public TList_FichaTecItensLoc lFichaTec
        { get; set; }
        
        public TList_FichaTecItensLoc lFichaTecDel
        { get; set; }


        public TRegistro_ItensLocacao()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_custo = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_desconto = decimal.Zero;
            this.Pc_desconto = decimal.Zero;
            this.lFichaTec = new TList_FichaTecItensLoc();
            this.lFichaTecDel = new TList_FichaTecItensLoc();

            this.Qtd_devolver = decimal.Zero;
        }
    }

    public class TCD_ItensLocacao : TDataQuery
    {
        public TCD_ItensLocacao()
        { }

        public TCD_ItensLocacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.vl_desconto, d.sigla_unidade, ");
                sql.AppendLine("a.id_locacao, a.id_item, a.cd_produto, c.ds_produto, c.cd_grupo, ");
                sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_custo, a.vl_subtotal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from vtb_fat_itenslocacao a ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");


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

        public TList_ItensLocacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensLocacao lista = new TList_ItensLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensLocacao reg = new TRegistro_ItensLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("vl_custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));

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

        public string Gravar(TRegistro_ItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_CUSTO", val.Vl_custo);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);

            return this.executarProc("IA_FAT_ITENSLOCACAO", hs);
        }

        public string Excluir(TRegistro_ItensLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_FAT_ITENSLOCACAO", hs);
        }

    }
    #endregion

    #region Locacao_X_PreVenda
    public class TList_Locacao_X_PreVenda : List<TRegistro_Locacao_X_PreVenda>, IComparer<TRegistro_Locacao_X_PreVenda>
    {
        #region IComparer<TRegistro_Locacao_X_PreVenda> Members
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

        public TList_Locacao_X_PreVenda()
        { }

        public TList_Locacao_X_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Locacao_X_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Locacao_X_PreVenda x, TRegistro_Locacao_X_PreVenda
 y)
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

    
    public class TRegistro_Locacao_X_PreVenda
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
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
                    id_prevenda = Convert.ToDecimal(value);
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
                    id_itemprevenda = Convert.ToDecimal(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }
        
        public string Tp_locacao
        { get; set; }

        public TRegistro_Locacao_X_PreVenda()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_locacao = null;
            this.Id_locacaostr = string.Empty;
            this.Id_prevenda = null;
            this.Id_prevendastr = string.Empty;
            this.Id_itemprevenda = null;
            this.Id_itemprevendastr = string.Empty;
            this.Tp_locacao = string.Empty;
        }
    }

    public class TCD_Locacao_X_PreVenda : TDataQuery
    {
        public TCD_Locacao_X_PreVenda()
        { }

        public TCD_Locacao_X_PreVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, ");
                sql.AppendLine("a.id_locacao, a.id_prevenda, a.id_item prevenda, a.tp_locacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_locacao_x_prevenda a ");

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

        public TList_Locacao_X_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Locacao_X_PreVenda lista = new TList_Locacao_X_PreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Locacao_X_PreVenda reg = new TRegistro_Locacao_X_PreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_locacao")))
                        reg.Tp_locacao = reader.GetString(reader.GetOrdinal("tp_locacao"));
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

        public string Gravar(TRegistro_Locacao_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);
            hs.Add("@P_TP_LOCACAO", val.Tp_locacao);

            return this.executarProc("IA_FAT_LOCACAO_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_Locacao_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return this.executarProc("EXCLUI_FAT_LOCACAO_X_PREVENDA", hs);
        }



    }

    #endregion

    #region ItensLocacao_X_Estoque
    public class TList_ItensLocacao_X_Estoque : List<TRegistro_ItensLocacao_X_Estoque>, IComparer<TRegistro_ItensLocacao_X_Estoque>
    {

        #region IComparer<TRegistro_ItensLocacao_X_Estoque> Members
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

        public TList_ItensLocacao_X_Estoque()
        { }

        public TList_ItensLocacao_X_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensLocacao_X_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensLocacao_X_Estoque x, TRegistro_ItensLocacao_X_Estoque y)
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

    
    public class TRegistro_ItensLocacao_X_Estoque
    {
        
        public string Cd_empresa
        { get; set; }
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
                    id_lanctoestoque = Convert.ToDecimal(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }

        public TRegistro_ItensLocacao_X_Estoque()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Id_lanctoestoque = null;
            this.Id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_ItensLocacao_X_Estoque : TDataQuery
    {
        public TCD_ItensLocacao_X_Estoque()
        { }

        public TCD_ItensLocacao_X_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, ");
                sql.AppendLine("a.id_locacao, a.cd_item, a.cd_produto, a.id_lanctoestoque ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from vtb_fat_itenslocacao_x_estoque a ");


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

        public TList_ItensLocacao_X_Estoque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensLocacao_X_Estoque lista = new TList_ItensLocacao_X_Estoque();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensLocacao_X_Estoque reg = new TRegistro_ItensLocacao_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));

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

        public string Gravar(TRegistro_ItensLocacao_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("IA_FAT_ITENSLOCACAO_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_ItensLocacao_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_FAT_ITENSLOCACAO_X_ESTOQUE", hs);
        }
    }

    #endregion

    #region ItensLocacao_X_PreVenda
    public class TList_ItensLocacao_X_PreVenda : List<TRegistro_ItensLocacao_X_PreVenda>, IComparer<TRegistro_ItensLocacao_X_PreVenda>
    {
        #region IComparer<TRegistro_ItensLocacao_X_PreVenda> Members
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

        public TList_ItensLocacao_X_PreVenda()
        { }

        public TList_ItensLocacao_X_PreVenda(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensLocacao_X_PreVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensLocacao_X_PreVenda x, TRegistro_ItensLocacao_X_PreVenda
y)
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

    
    public class TRegistro_ItensLocacao_X_PreVenda
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
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
                    id_prevenda = Convert.ToDecimal(value);
                }
                catch
                { id_prevenda = null; }
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
                    id_itemprevenda = Convert.ToDecimal(value);
                }
                catch
                { id_itemprevenda = null; }
            }
        }
        public TRegistro_ItensLocacao_X_PreVenda()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_locacao = null;
            this.Id_locacaostr = string.Empty;
            this.Id_prevenda = null;
            this.Id_prevendastr = string.Empty;
            this.Id_item = null;
            this.Id_itemstr = string.Empty;
            this.Id_itemprevenda = null;
            this.Id_itemprevendastr = string.Empty;
        }
    }

    public class TCD_ItensLocacao_X_PreVenda : TDataQuery
    {
        public TCD_ItensLocacao_X_PreVenda()
        { }

        public TCD_ItensLocacao_X_PreVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, ");
                sql.AppendLine("a.id_locacao, a.id_prevenda, a.id_item, a.id_itemprevenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_itenslocacao_x_prevenda a ");

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

        public TList_ItensLocacao_X_PreVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensLocacao_X_PreVenda lista = new TList_ItensLocacao_X_PreVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensLocacao_X_PreVenda reg = new TRegistro_ItensLocacao_X_PreVenda();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
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

        public string Gravar(TRegistro_ItensLocacao_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return this.executarProc("IA_FAT_ITENSLOCACAO_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_ItensLocacao_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return this.executarProc("EXCLUI_FAT_ITENSLOCACAO_X_PREVENDA", hs);
        }



    }

    #endregion

    #region Ficha Tecnica Itens Locacao
    public class TList_FichaTecItensLoc : List<TRegistro_FichaTecItensLoc>
    { }

    
    public class TRegistro_FichaTecItensLoc
    {
        
        public string Cd_empresa
        { get; set; }
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
                    id_locacao = decimal.Parse(value);
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
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
            }
        }
        
        public string Cd_item
        { get; set; }
        
        public string Ds_item
        { get; set; }
        
        public string Sigla_item
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Vl_custo
        { get; set; }
        public decimal Vl_totalcusto
        { get { return Quantidade * Vl_custo; } }

        public TRegistro_FichaTecItensLoc()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Cd_item = string.Empty;
            this.Ds_item = string.Empty;
            this.Sigla_item = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_custo = decimal.Zero;
        }
    }

    public class TCD_FichaTecItensLoc : TDataQuery
    {
        public TCD_FichaTecItensLoc() { }

        public TCD_FichaTecItensLoc(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_locacao, ");
                sql.AppendLine("a.id_item, a.cd_item, b.ds_produto as ds_item, ");
                sql.AppendLine("c.sigla_unidade as sigla_item, a.quantidade, a.vl_custo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_fichatecitensloc a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_item = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

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

        public TList_FichaTecItensLoc Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_FichaTecItensLoc lista = new TList_FichaTecItensLoc();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_FichaTecItensLoc reg = new TRegistro_FichaTecItensLoc();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("cd_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_item")))
                        reg.Sigla_item = reader.GetString(reader.GetOrdinal("sigla_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("vl_custo"));
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

        public string Gravar(TRegistro_FichaTecItensLoc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_CUSTO", val.Vl_custo);

            return this.executarProc("IA_FAT_FICHATECITENSLOC", hs);
        }

        public string Excluir(TRegistro_FichaTecItensLoc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_ITEM", val.Cd_item);

            return this.executarProc("EXCLUI_FAT_FICHATECITENSLOC", hs);
        }
    }
    #endregion
}