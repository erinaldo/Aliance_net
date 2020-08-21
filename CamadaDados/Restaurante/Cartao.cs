using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Restaurante
{
    public class TList_Cartao : List<TRegistro_Cartao>, IComparer<TRegistro_Cartao>
    {
        #region IComparer<TRegistro_Cartao> Members
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

        public TList_Cartao()
        {
        }

        public TList_Cartao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cartao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cartao x, TRegistro_Cartao y)
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

    public class TRegistro_Cartao
    {
        public decimal valor_cartao { get; set; } = decimal.Zero;
        public decimal? Id_mesa { get; set; } = null;
        public string nr_mesa { get; set; } = string.Empty;
        public decimal? id_local { get; set; } = null;
        public string ds_local { get; set; } = string.Empty;
        public decimal? total_itens { get; set; } = decimal.Zero;
        public bool st_agregar { get; set; } = false;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal id_cartao { get; set; } = decimal.Zero;
        public string Cd_Clifor { get; set; } = string.Empty;
        public string Nm_Clifor { get; set; } = string.Empty;
        public decimal vl_limitecartao { get; set; } = decimal.Zero;
        private string st_registro = "A";
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
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
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                if (value.Trim().ToUpper().Equals("FECHADO"))
                    st_registro = "F";
                if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }

        public string status_menor = "N";

        public bool st_menor
        {
            get
            {
                return status_menor.Equals("S");
            }
            set
            {
                if (value)
                    status_menor = "S";
                else
                    status_menor = "N";

            }
        }
        public string nr_card { get; set; } = string.Empty;

        private DateTime? dt_fechamento { get; set; } = null;
        public DateTime? Dt_fechamento
        {
            get { return dt_fechamento; }
            set
            {
                dt_fechamento = value;
                dt_fechamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy hh:mm") : string.Empty;
            }
        }
        private string dt_fechamentostr { get; set; } = string.Empty;
        public string Dt_fechamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fechamentostr).ToString("dd/MM/yyyy hh:mm");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fechamentostr = value;
                try
                {
                    dt_fechamento = Convert.ToDateTime(value);
                }
                catch
                { dt_fechamento = null; }
            }
        }

        private DateTime? dt_abertura { get; set; } = null;
        public string dtabertura
        {
            get
            {
                return dt_abertura.ToString();
            }
            set
            {
                dt_abertura = Convert.ToDateTime(value);
            }
        }
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy hh:mm") : string.Empty;
            }
        }
        private string dt_aberturastr { get; set; } = string.Empty;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy hh:mm");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = Convert.ToDateTime(value);
                }
                catch
                { dt_abertura = null; }
            }
        }
        public decimal? nr_cupom { get; set; } = null;
        public string nr_cupomStr
        {
            get
            {
                return nr_cupom.ToString();
            }
            set
            {
                nr_cupom = Convert.ToDecimal(value);
            }
        }

        public string Fone { get; set; }
        public string FoneComercial { get; set; }
        public string Celular { get; set; }

        public string nr_cartao = string.Empty;
        public decimal? nr_fastfood { get; set; } = null;
        public string nr_fastfoodStr { get { return nr_fastfood.ToString(); } set { nr_fastfood = Convert.ToDecimal(value); } }
        public TList_PreVenda lPreVenda { get; set; } = new TList_PreVenda();
        public TList_PreVenda lDelPreVenda { get; set; } = new TList_PreVenda();

    }

    public class TCD_Cartao : TDataQuery
    {
        public TCD_Cartao() { }

        public TCD_Cartao(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string order)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_nfce,  a.cd_empresa, a.nr_senhafastfood,a.id_cartao,a.nm_clifor, a.nr_cartao, a.cd_clifor, a.dt_abertura, a.dt_fechamento, a.st_menoridade, a.st_registro, a.vl_limitecartao, a.nm_clifor,  ");
                sql.AppendLine("a.valor_cartao, a.total_itens, a.id_mesa,a.id_local, b.ds_local, c.nr_mesa, nr_card =(isnull(isnull(convert(varchar(10),a.nr_senhafastfood),a.nr_cartao),'')), ");
                sql.AppendLine("d.fone, d.fone_comercial, d.celular ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_res_cartao a ");
            sql.AppendLine("left join tb_res_local b on a.id_Local = b.id_local ");
            sql.AppendLine("left join tb_res_mesa c on a.id_mesa = c.id_mesa and a.id_local = c.id_local");
            sql.AppendLine("left join tb_fin_endereco d on a.cd_clifor = d.cd_clifor");

            string cond = " where ";
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

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public string BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string order)
        {
            if (ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, order), null) != null)
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, order), null).ToString();
            else
                return string.Empty;
        }

        public TList_Cartao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string order)
        {
            bool podeFecharBco = false;
            TList_Cartao lista = new TList_Cartao();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, order));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cartao reg = new TRegistro_Cartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitecartao")))
                        reg.vl_limitecartao = reader.GetDecimal(reader.GetOrdinal("vl_limitecartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartao")))
                        reg.nr_cartao = reader.GetString(reader.GetOrdinal("nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_senhafastfood")))
                        reg.nr_fastfood = reader.GetDecimal(reader.GetOrdinal("nr_senhafastfood"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Clifor")))
                        reg.Cd_Clifor = reader.GetString(reader.GetOrdinal("Cd_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_menoridade")))
                        reg.status_menor = reader.GetString(reader.GetOrdinal("st_menoridade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_Clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nfce")))
                        reg.nr_cupom = reader.GetDecimal(reader.GetOrdinal("nr_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("Dt_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fechamento")))
                        reg.Dt_fechamento = reader.GetDateTime(reader.GetOrdinal("dt_fechamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_mesa")))
                        reg.Id_mesa = reader.GetDecimal(reader.GetOrdinal("id_mesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_local")))
                        reg.id_local = reader.GetDecimal(reader.GetOrdinal("id_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor_cartao")))
                        reg.valor_cartao = reader.GetDecimal(reader.GetOrdinal("valor_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_mesa")))
                        reg.nr_mesa = reader.GetString(reader.GetOrdinal("nr_mesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_card")))
                        reg.nr_card = reader.GetString(reader.GetOrdinal("nr_card"));

                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_comercial")))
                        reg.FoneComercial = reader.GetString(reader.GetOrdinal("fone_comercial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        reg.Celular = reader.GetString(reader.GetOrdinal("celular"));

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

        public string Gravar(TRegistro_Cartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAO", val.id_cartao);
            hs.Add("@P_NR_CARTAO", val.nr_cartao);
            hs.Add("@P_VL_LIMITECARTAO", val.vl_limitecartao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ST_MENORIDADE", val.status_menor);
            hs.Add("@P_DT_ABERTURA", val.Dt_abertura);
            hs.Add("@P_DT_FECHAMENTO", val.Dt_fechamento);
            hs.Add("@P_CD_CLIFOR", val.Cd_Clifor);
            hs.Add("@P_ID_MESA", val.Id_mesa);
            hs.Add("@P_ID_LOCAL", val.id_local);

            return executarProc("IA_RES_CARTAO", hs);
        }

        public string Excluir(TRegistro_Cartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAO", val.id_cartao);

            return executarProc("EXCLUI_RES_CARTAO", hs);
        }
    }
}
