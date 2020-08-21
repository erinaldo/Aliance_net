using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    #region CfgPainelVendaConv
    public class TList_CfgPainelVendaConv : List<TRegistro_CfgPainelVendaConv>, IComparer<TRegistro_CfgPainelVendaConv>
    {
        #region IComparer<TRegistro_CfgPainelVendaConv> Members
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

        public TList_CfgPainelVendaConv()
        { }

        public TList_CfgPainelVendaConv(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgPainelVendaConv value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgPainelVendaConv x, TRegistro_CfgPainelVendaConv y)
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

    
    public class TRegistro_CfgPainelVendaConv
    {
        private decimal? id_config;
        
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch
                { id_config = null; }
            }
        }
        
        public string Ds_config
        { get; set; }
        
        public TList_CfgPainelVendaConv_X_Grupo lGrupo
        { get; set; }
        
        public TList_CfgPainelVendaConv_X_Grupo lGrupoDel
        { get; set; }

        public TRegistro_CfgPainelVendaConv()
        {
            this.id_config = null;
            this.id_configstr = string.Empty;
            this.Ds_config = string.Empty;
            this.lGrupo = new TList_CfgPainelVendaConv_X_Grupo();
            this.lGrupoDel = new TList_CfgPainelVendaConv_X_Grupo();
        }
    }

    public class TCD_CfgPainelVendaConv : TDataQuery
    {
        public TCD_CfgPainelVendaConv()
        { }

        public TCD_CfgPainelVendaConv(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_config, a.ds_config ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_CfgPainelVendaConv a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CfgPainelVendaConv Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CfgPainelVendaConv lista = new TList_CfgPainelVendaConv();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgPainelVendaConv reg = new TRegistro_CfgPainelVendaConv();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));

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

        public string Gravar(TRegistro_CfgPainelVendaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_DS_CONFIG", val.Ds_config);

            return this.executarProc("IA_PDC_CFGPAINELVENDACONV", hs);
        }

        public string Excluir(TRegistro_CfgPainelVendaConv val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CONFIG", val.Id_config);

            return this.executarProc("EXCLUI_PDC_CFGPAINELVENDACONV", hs);
        }
    }
    #endregion

    #region CfgPainelVendaConv X Grupo
    public class TList_CfgPainelVendaConv_X_Grupo : List<TRegistro_CfgPainelVendaConv_X_Grupo>, IComparer<TRegistro_CfgPainelVendaConv_X_Grupo>
    {
        #region IComparer<TRegistro_CfgPainelVendaConv_X_Grupo> Members
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

        public TList_CfgPainelVendaConv_X_Grupo()
        { }

        public TList_CfgPainelVendaConv_X_Grupo(System.ComponentModel.PropertyDescriptor Prop,
                                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgPainelVendaConv_X_Grupo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgPainelVendaConv_X_Grupo x, TRegistro_CfgPainelVendaConv_X_Grupo y)
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

    
    public class TRegistro_CfgPainelVendaConv_X_Grupo
    {
        private decimal? id_config;
        
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch
                { id_config = null; }
            }
        }
        
        public string Ds_config
        { get; set; }
        
        public string Cd_grupo
        { get; set; }
        
        public string Ds_grupo
        { get; set; }

        public TRegistro_CfgPainelVendaConv_X_Grupo()
        {
            this.id_config = null;
            this.id_configstr = string.Empty;
            this.Ds_config = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
        }
    }

    public class TCD_CfgPainelVendaConv_X_Grupo : TDataQuery
    {
        public TCD_CfgPainelVendaConv_X_Grupo()
        { }

        public TCD_CfgPainelVendaConv_X_Grupo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_config, b.ds_config, a.cd_grupo, c.ds_grupo ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_CfgPainelVendaConv_X_Grupo a ");
            sql.AppendLine("inner join TB_PDC_CfgPainelVendaConv b ");
            sql.AppendLine("on a.id_config = b.id_config ");
            sql.AppendLine("inner join TB_EST_GrupoProduto c ");
            sql.AppendLine("on a.cd_grupo = c.cd_grupo ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CfgPainelVendaConv_X_Grupo Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CfgPainelVendaConv_X_Grupo lista = new TList_CfgPainelVendaConv_X_Grupo();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgPainelVendaConv_X_Grupo reg = new TRegistro_CfgPainelVendaConv_X_Grupo();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));

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

        public string Gravar(TRegistro_CfgPainelVendaConv_X_Grupo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);

            return this.executarProc("IA_PDC_CFGPAINELVENDACONV_X_GRUPO", hs);
        }

        public string Excluir(TRegistro_CfgPainelVendaConv_X_Grupo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);

            return this.executarProc("EXCLUI_PDC_CFGPAINELVENDACONV_X_GRUPO", hs);
        }
    }
    #endregion
}
