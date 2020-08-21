using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using CamadaDados;

namespace CamadaDados.Estoque
{
    #region Provisao Estoque

    public class TList_Lan_Provisao_Estoque : List<TRegistro_Lan_Provisao_Estoque>, IComparer<TRegistro_Lan_Provisao_Estoque>
    {
        #region IComparer<TRegistro_Lan_Provisao_Estoque> Members
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

        public TList_Lan_Provisao_Estoque()
        { }

        public TList_Lan_Provisao_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_Provisao_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_Provisao_Estoque x, TRegistro_Lan_Provisao_Estoque y)
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
    
    public class TRegistro_Lan_Provisao_Estoque
    {
        public decimal? Id_provisao
        { get; set; }
        public string Ds_provisao
        { get; set; }
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
            get {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; } 
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch { dt_lancto = null; }
            }
        }
        public string Login
        { get; set; }
        public string Cd_empresa_prov
        { get; set; }
        public string Nm_empresa_prov
        { get; set; }
        public string Cd_produto_prov
        { get; set; }
        public string Ds_produto_prov
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal? Id_lanctoestoque_prov
        { get; set; }
        public decimal Tot_Entrada
        { get; set; }
        public decimal Tot_Saida
        { get; set; }
        public decimal VL_Medio
        { get; set; }
        public decimal Saldo_Provisao
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public TList_RegLanEstoque Lan_Estoque
        { get; set; }

        public TRegistro_Lan_Provisao_Estoque()
        {
            this.Id_provisao = null;
            this.Ds_provisao = string.Empty;
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Login = Utils.Parametros.pubLogin.ToString();
            this.Cd_empresa_prov = string.Empty;
            this.Nm_empresa_prov = string.Empty;
            this.Cd_produto_prov = string.Empty;
            this.Ds_produto_prov = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Id_lanctoestoque_prov = null;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Lan_Estoque = new TList_RegLanEstoque();
            this.Tot_Entrada = decimal.Zero;
            this.Tot_Saida = decimal.Zero;
            this.VL_Medio = decimal.Zero;
            this.Saldo_Provisao = decimal.Zero;
        }
    }

    public class TCD_Lan_Provisao_Estoque : TDataQuery
    {
        public TCD_Lan_Provisao_Estoque()
        { }

        public TCD_Lan_Provisao_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
                        

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select" + strTop + " a.ID_PROVISAO, a.DS_PROVISAO, a.DT_LANCTO, ");
                sql.AppendLine("a.LOGIN, a.CD_EMPRESA, b.nm_empresa, a.CD_PRODUTO_PROV, ");
                sql.AppendLine("c.ds_produto, a.ID_LANCTOESTOQUE_PROV, ");
                sql.AppendLine("a.Tot_entrada, a.tot_saida, a.vl_medio, a.saldo_provisao ");
            }
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_est_provisao_estoque a");
            sql.AppendLine("inner join tb_div_Empresa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on c.cd_produto = a.cd_produto_prov ");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lan_Provisao_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lan_Provisao_Estoque lista = new TList_Lan_Provisao_Estoque();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Lan_Provisao_Estoque reg = new TRegistro_Lan_Provisao_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PROVISAO")))
                        reg.Id_provisao = reader.GetDecimal(reader.GetOrdinal("ID_PROVISAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PROVISAO")))
                        reg.Ds_provisao = reader.GetString(reader.GetOrdinal("DS_PROVISAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_LANCTO")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_LANCTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LOGIN")))
                        reg.Login = reader.GetString(reader.GetOrdinal("LOGIN"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA")))
                        reg.Cd_empresa_prov = reader.GetString(reader.GetOrdinal("CD_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_EMPRESA")))
                        reg.Nm_empresa_prov = reader.GetString(reader.GetOrdinal("NM_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PRODUTO_PROV")))
                        reg.Cd_produto_prov = reader.GetString(reader.GetOrdinal("CD_PRODUTO_PROV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PRODUTO")))
                        reg.Ds_produto_prov = reader.GetString(reader.GetOrdinal("DS_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LANCTOESTOQUE_PROV")))
                        reg.Id_lanctoestoque_prov = reader.GetDecimal(reader.GetOrdinal("ID_LANCTOESTOQUE_PROV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_entrada")))
                        reg.Tot_Entrada = reader.GetDecimal(reader.GetOrdinal("tot_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_saida")))
                        reg.Tot_Saida = reader.GetDecimal(reader.GetOrdinal("tot_saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Medio")))
                        reg.VL_Medio = reader.GetDecimal(reader.GetOrdinal("VL_Medio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo_Provisao")))
                        reg.Saldo_Provisao = reader.GetDecimal(reader.GetOrdinal("Saldo_Provisao"));              

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Lan_Provisao_Estoque val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_PROVISAO", val.Id_provisao);
            hs.Add("@P_DS_PROVISAO", val.Ds_provisao); 
            hs.Add("@P_DT_LANCTO", val.Dt_lancto); 
            hs.Add("@P_LOGIN", val.Login); 
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa_prov); 

            return this.executarProc("IA_EST_PROVISAO_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_Lan_Provisao_Estoque val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PROVISAO", val.Id_provisao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa_prov);

            return this.executarProc("EXCLUI_EST_PROVISAO_ESTOQUE", hs);
        }
    }
   
    #endregion

    #region Provisao_X_Estoque

    public class TList_Lan_Provisao_X_Estoque : List<TRegistro_Lan_Provisao_X_Estoque>, IComparer<TRegistro_Lan_Provisao_X_Estoque>
    {
        #region IComparer<TRegistro_Lan_Provisao_X_Estoque> Members
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

        public TList_Lan_Provisao_X_Estoque()
        { }

        public TList_Lan_Provisao_X_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Lan_Provisao_X_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Lan_Provisao_X_Estoque x, TRegistro_Lan_Provisao_X_Estoque y)
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
    
    public class TRegistro_Lan_Provisao_X_Estoque
    {
        public decimal? Id_provisao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        public decimal? Id_loteCTB
        { get; set; }

        public TRegistro_Lan_Provisao_X_Estoque()
        {
            this.Id_provisao = null;
            this.Cd_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Id_lanctoestoque = null;
            this.Id_loteCTB = null;
        }
    }

    public class TCD_Lan_Provisao_X_Estoque : TDataQuery
    {
        public TCD_Lan_Provisao_X_Estoque()
        { }

        public TCD_Lan_Provisao_X_Estoque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.Append(" select" + strTop + " a.ID_PROVISAO, A.CD_EMPRESA, A.CD_PRODUTO, a.ID_LANCTOESTOQUE, a.ID_LOTECTB ");
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.Append(" from tb_est_prov_x_estoque a");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lan_Provisao_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lan_Provisao_X_Estoque lista = new TList_Lan_Provisao_X_Estoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Lan_Provisao_X_Estoque reg = new TRegistro_Lan_Provisao_X_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PROVISAO")))
                        reg.Id_provisao = reader.GetDecimal(reader.GetOrdinal("ID_PROVISAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PRODUTO")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LANCTOESTOQUE")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LANCTOESTOQUE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOTECTB")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LOTECTB"));
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

        public string Gravar(TRegistro_Lan_Provisao_X_Estoque val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_PROVISAO", val.Id_provisao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);

            return this.executarProc("IA_EST_PROVISAO_X_ESTOQUE", hs);
        }

        public string Excluir(TRegistro_Lan_Provisao_X_Estoque val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_PROVISAO", val.Id_provisao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_EST_PROVISAO_X_ESTOQUE", hs);
        }
    }

    #endregion
}
