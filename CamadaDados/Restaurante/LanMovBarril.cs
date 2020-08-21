using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante
{
    public class TList_MovBarril:List<TRegistro_MovBarril>, IComparer<TRegistro_MovBarril>
    {
        #region IComparer<TRegistro_MovBarril> Members
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

        public TList_MovBarril()
        { }

        public TList_MovBarril(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovBarril value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovBarril x, TRegistro_MovBarril y)
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

    public class TRegistro_MovBarril
    {
        public int? Id_barril { get; set; }
        public string Cd_empresa { get; set; } = string.Empty;
        public int? Id_mov { get; set; }
        public string Nm_empresa { get; set; } = string.Empty;
        public string Nr_barril { get; set; } = string.Empty;
        public int Volume { get; set; }
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        private DateTime? dt_carga = DateTime.Now;
        public DateTime? Dt_carga
        {
            get { return dt_carga; }
            set
            {
                dt_carga = value;
                dt_cargastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_cargastr = DateTime.Now.ToString("dd/MM/yyyy");
        public string Dt_cargastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_cargastr).ToString("dd/MM/yyyy");
                }
                catch { return null; }
            }
            set
            {
                dt_cargastr = value;
                try
                {
                    dt_carga = DateTime.Parse(value);
                }
                catch { dt_carga = null; }
            }
        }
        private DateTime? dt_descarga = null;
        public DateTime? Dt_descarga
        {
            get { return dt_descarga; }
            set
            {
                dt_descarga = value;
                dt_descargastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_descargastr = string.Empty;
        public string Dt_descargastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_descargastr).ToString("dd/MM/yyyy");
                }
                catch { return null; }
            }
            set
            {
                dt_descargastr = value;
                try
                {
                    dt_descarga = DateTime.Parse(value);
                }
                catch { dt_descarga = null; }
            }
        }
        public string Obs { get; set; } = string.Empty;
        public string St_registro { get; set; } = "C";//Carregado
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CARREGADO";
                else if (St_registro.Trim().ToUpper().Equals("V"))
                    return "VAZIO";
                else return string.Empty;
            }
        }
    }

    public class TCD_MovBarril:TDataQuery
    {
        public TCD_MovBarril() { }
        public TCD_MovBarril(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_barril, a.cd_empresa, d.nm_empresa, ");
                sql.AppendLine("a.id_mov, a.cd_produto, a.dt_carga, a.dt_descarga, ");
                sql.AppendLine("a.obs, a.st_registro, b.nr_barril, b.volume, c.ds_produto ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_MovBarril a ");
            sql.AppendLine("inner join TB_RES_Barril b ");
            sql.AppendLine("on a.id_barril = b.id_barril ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_MovBarril Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_MovBarril lista = new TList_MovBarril();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovBarril reg = new TRegistro_MovBarril();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_barril")))
                        reg.Id_barril = reader.GetInt32(reader.GetOrdinal("id_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_barril")))
                        reg.Nr_barril = reader.GetString(reader.GetOrdinal("nr_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volume")))
                        reg.Volume = reader.GetInt32(reader.GetOrdinal("volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_mov")))
                        reg.Id_mov = reader.GetInt32(reader.GetOrdinal("id_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_carga")))
                        reg.Dt_carga = reader.GetDateTime(reader.GetOrdinal("dt_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_descarga")))
                        reg.Dt_descarga = reader.GetDateTime(reader.GetOrdinal("dt_descarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_MovBarril val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_BARRIL", val.Id_barril);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DT_CARGA", val.Dt_carga);
            hs.Add("@P_DT_DESCARGA", val.Dt_descarga);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_RES_MOVBARRIL", hs);
        }

        public string Excluir(TRegistro_MovBarril val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_BARRIL", val.Id_barril);
            hs.Add("@P_ID_MOV", val.Id_mov);

            return executarProc("EXCLUI_RES_MOVBARRIL", hs);
        }
    }
}
