using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;

namespace CamadaDados.Faturamento.Pedido
{
    #region Etapa Pedido
    public class TList_EtapaPedido : List<TRegistro_EtapaPedido>, IComparer<TRegistro_EtapaPedido>
    {
        #region IComparer<TRegistro_EtapaPedido> Members
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

        public TList_EtapaPedido()
        { }

        public TList_EtapaPedido(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EtapaPedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EtapaPedido x, TRegistro_EtapaPedido y)
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

    public class TRegistro_EtapaPedido
    {
        private decimal? nr_pedido;

        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                if (value.HasValue)
                    nr_pedidostr = value.Value.ToString();
                else
                    nr_pedidostr = string.Empty;
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
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        private decimal? id_etapa;

        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;

        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        public string DS_Etapa
        { get; set; }
        private DateTime? dt_ini;

        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = Convert.ToDateTime(value);
                }
                catch
                { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;

        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_finstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = Convert.ToDateTime(value);
                }
                catch
                { dt_fin = null; }
            }
        }
        private string st_registro;

        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("F"))
                    status = "FINALIZADO";
            }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTo"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("FINALIZADO"))
                    st_registro = "F";

            }
        }
        public TList_ProcEtapa lProcEtapa
        { get; set; }
        public TList_ProcEtapa lProcEtapaDel
        { get; set; }


        public TRegistro_EtapaPedido()
        {
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.DS_Etapa = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.dt_ini = null;
            this.dt_inistr = string.Empty;
            this.dt_fin = null;
            this.dt_finstr = string.Empty;
            this.St_registro = "A";
            this.lProcEtapa = new TList_ProcEtapa();
            this.lProcEtapaDel = new TList_ProcEtapa();

        }
    }

    public class TCD_EtapaPedido : TDataQuery
    {
        public TCD_EtapaPedido()
        { }

        public TCD_EtapaPedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_etapa, b.DS_Etapa, a.nr_pedido, a.dt_ini, a.dt_fin, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Pedido_Etapa a ");
            sql.AppendLine("inner join TB_FAT_EtapaPed b ");
            sql.AppendLine("on a.id_etapa = b.id_etapa ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            sql.AppendLine("order by b.ordem ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_EtapaPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_EtapaPedido lista = new TList_EtapaPedido();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EtapaPedido reg = new TRegistro_EtapaPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("Id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Etapa")))
                        reg.DS_Etapa = reader.GetString(reader.GetOrdinal("DS_Etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("dt_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_EtapaPedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAT_PEDIDO_ETAPA", hs);
        }

        public string Excluir(TRegistro_EtapaPedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);

            return this.executarProc("EXCLUI_FAT_PEDIDO_ETAPA", hs);
        }
    }
    #endregion  

    #region Processo Etapa
    public class TList_ProcEtapa : List<TRegistro_ProcEtapa>, IComparer<TRegistro_ProcEtapa>
    {
        #region IComparer<TRegistro_ProcEtapa> Members
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

        public TList_ProcEtapa()
        { }

        public TList_ProcEtapa(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProcEtapa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProcEtapa x, TRegistro_ProcEtapa y)
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

    public class TRegistro_ProcEtapa
    {
        private decimal? nr_pedido;
        public string stRegistro { get; set; }

        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                if (value.HasValue)
                    nr_pedidostr = value.Value.ToString();
                else
                    nr_pedidostr = string.Empty;
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
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        private decimal? id_processo;

        public decimal? Id_processo
        {
            get { return id_processo; }
            set
            {
                id_processo = value;
                id_processostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_processostr;

        public string Id_processostr
        {
            get { return id_processostr; }
            set
            {
                id_processostr = value;
                try
                {
                    id_processo = decimal.Parse(value);
                }
                catch
                { id_processo = null; }
            }
        }
        private decimal? id_etapa;

        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;

        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        public string DS_Processo
        { get; set; }
        public string Login
        { get; set; }
        private DateTime? dt_processo;

        public DateTime? Dt_processo
        {
            get { return dt_processo; }
            set
            {
                dt_processo = value;
                dt_processostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_processostr;
        public string Dt_processostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_processostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_processostr = value;
                try
                {
                    dt_processo = Convert.ToDateTime(value);
                }
                catch
                { dt_processo = null; }
            }
        }
        public string Obs
        { get; set; }
        public TList_AnexoPedido lAnexo
        { get; set; }
        public TList_AnexoPedido lAnexoDel
        { get; set; }
        public string Id_Anexo
        { get; set; }

        public TRegistro_ProcEtapa()
        {
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.id_processo = null;
            this.id_processostr = string.Empty;
            this.DS_Processo = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.Login = string.Empty;
            this.dt_processo = null;
            this.dt_processostr = string.Empty;
            this.Id_Anexo = string.Empty;
            this.Obs = string.Empty;
            this.lAnexo = new TList_AnexoPedido();
            this.lAnexoDel = new TList_AnexoPedido();
            this.stRegistro = string.Empty;
        }
    }

    public class TCD_ProcEtapa : TDataQuery
    {
        public TCD_ProcEtapa()
        { }

        public TCD_ProcEtapa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_etapa, a.id_processo, b.DS_Processo, a.nr_pedido, a.login, a.dt_processo, a.obs ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Pedido_ProcEtapa a ");
            sql.AppendLine("inner join TB_FAT_ProcessoEtapa b ");
            sql.AppendLine("on a.id_etapa = b.id_etapa ");
            sql.AppendLine("and a.id_processo = b.id_processo ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ProcEtapa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ProcEtapa lista = new TList_ProcEtapa();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProcEtapa reg = new TRegistro_ProcEtapa();

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("Id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_processo")))
                        reg.Id_processo = reader.GetDecimal(reader.GetOrdinal("Id_processo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Processo")))
                        reg.DS_Processo = reader.GetString(reader.GetOrdinal("DS_Processo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_processo")))
                        reg.Dt_processo = reader.GetDateTime(reader.GetOrdinal("Dt_processo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_ProcEtapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_PROCESSO", val.Id_processo);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DT_PROCESSO", val.Dt_processo);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_REGISTRO", val.stRegistro);

            return this.executarProc("IA_FAT_PEDIDO_PROCETAPA", hs);
        }

        public string Excluir(TRegistro_ProcEtapa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_PROCESSO", val.Id_processo);

            return this.executarProc("EXCLUI_FAT_PEDIDO_PROCETAPA", hs);
        }
    }
    #endregion  
}
