using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cartao
{
    #region Carrega Cartão Pré
    public class TList_CarregaCartaoPre : List<TRegistro_CarregaCartaoPre>, IComparer<TRegistro_CarregaCartaoPre>
    {
        #region IComparer<TRegistro_CarregaCartaoPre> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CarregaCartaoPre()
        { }

        public TList_CarregaCartaoPre(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CarregaCartaoPre value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CarregaCartaoPre x, TRegistro_CarregaCartaoPre y)
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

    public class TRegistro_CarregaCartaoPre
    {
        private decimal? id_cartao;
        public decimal? Id_cartao
        {
            get { return id_cartao; }
            set
            {
                id_cartao = value;
                id_cartaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartaostr;
        public string Id_cartaostr
        {
            get { return id_cartaostr; }
            set
            {
                id_cartaostr = value;
                try
                {
                    id_cartao = Convert.ToDecimal(value);
                }
                catch
                { id_cartao = null; }
            }
        }
        public string Ds_cartao
        { get; set; }
        public string Nr_cartao
        { get; set; }
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
                    id_carga = Convert.ToDecimal(value);
                }
                catch
                { id_carga = null; }
            }
        }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
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
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cargastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_cargastr = value;
                try
                {
                    dt_carga = Convert.ToDateTime(value);
                }
                catch
                { dt_carga = null; }
            }
        }
        public decimal Vl_carga
        { get; set; }
        public string Obs
        { get; set; }


        public TRegistro_CarregaCartaoPre()
        {
            id_cartao = null;
            id_cartaostr = string.Empty;
            Ds_cartao = string.Empty;
            Nr_cartao = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_carga = null;
            id_cargastr = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            Cd_lanctocaixa = null;
            dt_carga = null;
            dt_cargastr = string.Empty;
            Vl_carga = decimal.Zero;
            Obs = string.Empty;
        }
    }

    public class TList_MovCartaoPre : List<TMovCartaoPre>
    {

    }
    public class TMovCartaoPre
    {
        private decimal? id_cartao;
        public decimal? Id_cartao
        {
            get { return id_cartao; }
            set
            {
                id_cartao = value;
                id_cartaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartaostr;
        public string Id_cartaostr
        {
            get { return id_cartaostr; }
            set
            {
                id_cartaostr = value;
                try
                {
                    id_cartao = Convert.ToDecimal(value);
                }
                catch
                { id_cartao = null; }
            }
        }
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
                    id_carga = Convert.ToDecimal(value);
                }
                catch
                { id_carga = null; }
            }
        }
        public string Ds_cartao
        { get; set; }
        public string Nr_cartao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
        { get; set; }
        public DateTime? Dt_lancto
        { get; set; }
        public decimal Vl_credito
        { get; set; }
        public decimal Vl_debito
        { get; set; }
    }

    public class TList_SaldoCartaoPre : List<TSaldoCartaoPre>
    {

    }
    public class TSaldoCartaoPre
    {
        private decimal? id_cartao;
        public decimal? Id_cartao
        {
            get { return id_cartao; }
            set
            {
                id_cartao = value;
                id_cartaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartaostr;
        public string Id_cartaostr
        {
            get { return id_cartaostr; }
            set
            {
                id_cartaostr = value;
                try
                {
                    id_cartao = Convert.ToDecimal(value);
                }
                catch
                { id_cartao = null; }
            }
        }
        public string Ds_cartao
        { get; set; }
        public string Nr_cartao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal Tot_credito
        { get; set; }
        public decimal Tot_debito
        { get; set; }
        public decimal Saldo
        { get; set; }
    }

    public class TCD_CarregaCartaoPre : TDataQuery
    {
        public TCD_CarregaCartaoPre()
        { }

        public TCD_CarregaCartaoPre(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.ID_Carga, a.ID_Cartao, c.DS_Cartao, c.Nr_cartao, a.CD_Empresa, a.cd_contager, d.DS_ContaGer, ");
                sql.AppendLine("b.NM_Empresa, a.CD_LanctoCaixa, a.DT_Carga, a.Obs ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_CarregarCartaoPre a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_CartaoCredito c ");
            sql.AppendLine("on a.ID_Cartao = c.ID_Cartao ");
            sql.AppendLine("left outer join TB_FIN_ContaGer d ");
            sql.AppendLine("on a.CD_ContaGer = d.CD_ContaGer ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaMovCartao(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.CD_Empresa, a.NM_Empresa, a.ID_Cartao, a.ID_Carga, ");
                sql.AppendLine("a.DS_Cartao, a.Nr_cartao, a.CD_ContaGer, a.CD_LanctoCaixa, a.DT_Lancto, a.Vl_credito, a.vl_debito ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_CARTAOPRE a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaSaldoCartao(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.CD_Empresa, a.NM_Empresa, a.ID_Cartao, a.DS_Cartao, a.Nr_cartao, ");
                sql.AppendLine("sum(isnull(a.vl_credito, 0)) as Tot_credito, sum(isnull(a.vl_debito, 0)) as Tot_debito, ");
                sql.AppendLine("sum(isnull(a.vl_credito, 0)) - sum(isnull(a.vl_debito, 0))  as Saldo ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_CARTAOPRE a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());
            sql.AppendLine("group by a.CD_Empresa, a.NM_Empresa, a.ID_Cartao, a.DS_Cartao, a.Nr_cartao ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_CarregaCartaoPre Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_CarregaCartaoPre lista = new TList_CarregaCartaoPre();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CarregaCartaoPre reg = new TRegistro_CarregaCartaoPre();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.Id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_cartao")))
                        reg.Ds_cartao = reader.GetString(reader.GetOrdinal("Ds_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_cartao")))
                        reg.Nr_cartao = reader.GetString(reader.GetOrdinal("Nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("Id_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("Ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_carga")))
                        reg.Dt_carga = reader.GetDateTime(reader.GetOrdinal("Dt_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

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

        public TList_MovCartaoPre SelectMovCartao(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_MovCartaoPre lista = new TList_MovCartaoPre();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaMovCartao(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TMovCartaoPre reg = new TMovCartaoPre();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.Id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_cartao")))
                        reg.Ds_cartao = reader.GetString(reader.GetOrdinal("Ds_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_cartao")))
                        reg.Nr_cartao = reader.GetString(reader.GetOrdinal("Nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("Id_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("Dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_credito")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("Vl_credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_debito")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("Vl_debito"));

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

        public TList_SaldoCartaoPre SelectSaldoCartao(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_SaldoCartaoPre lista = new TList_SaldoCartaoPre();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaSaldoCartao(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TSaldoCartaoPre reg = new TSaldoCartaoPre();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.Id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_cartao")))
                        reg.Ds_cartao = reader.GetString(reader.GetOrdinal("Ds_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_cartao")))
                        reg.Nr_cartao = reader.GetString(reader.GetOrdinal("Nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_credito")))
                        reg.Tot_credito = reader.GetDecimal(reader.GetOrdinal("Tot_credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tot_debito")))
                        reg.Tot_debito = reader.GetDecimal(reader.GetOrdinal("Tot_debito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo")))
                        reg.Saldo = reader.GetDecimal(reader.GetOrdinal("Saldo"));

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

        public string Gravar(TRegistro_CarregaCartaoPre val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_CARTAO", val.Id_cartao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_DT_CARGA", val.Dt_carga);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_FIN_CARREGARCARTAOPRE", hs);
        }

        public string Excluir(TRegistro_CarregaCartaoPre val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_CARTAO", val.Id_cartao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);

            return executarProc("EXCLUI_FIN_CARREGARCARTAOPRE", hs);
        }
    }
    #endregion
}
