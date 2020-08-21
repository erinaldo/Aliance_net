using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TList_Chopeira:List<TRegistro_Chopeira>, IComparer<TRegistro_Chopeira>
    {
        #region IComparer<TRegistro_Chopeira> Members
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

        public TList_Chopeira()
        { }

        public TList_Chopeira(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Chopeira value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Chopeira x, TRegistro_Chopeira y)
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

    public class TRegistro_Chopeira
    {
        public int? Id_chopeira { get; set; } = null;
        public string Ds_chopeira { get; set; } = string.Empty;
        public string Nr_chopeira { get; set; } = string.Empty;
        public string Voltagem { get; set; } = string.Empty;
        public string Voltagemstr
        {
            get
            {
                if (Voltagem.Trim().Equals("0"))
                    return "110";
                else if (Voltagem.Trim().Equals("1"))
                    return "220";
                else return string.Empty;
            }
        }
        public string Qt_torneiras { get; set; } = string.Empty;
        public bool Cancelado { get; set; } = false;
        public int Qt_chopeira { get; set; } = 0;
        public int Qt_reservada { get; set; } = 0;
        public int Qt_disponivel => Qt_chopeira - Qt_reservada;
    }

    public class TCD_Chopeira : TDataQuery
    {
        public TCD_Chopeira() { }

        public TCD_Chopeira(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_chopeira, a.ds_chopeira, ");
                sql.AppendLine("a.nr_chopeira, a.voltagem, a.qt_torneiras, a.cancelado ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_Chopeira a ");
            sql.AppendLine("where a.cancelado = 0 ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Chopeira Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Chopeira lista = new TList_Chopeira();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Chopeira reg = new TRegistro_Chopeira();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_chopeira")))
                        reg.Id_chopeira = reader.GetInt32(reader.GetOrdinal("id_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_chopeira")))
                        reg.Ds_chopeira = reader.GetString(reader.GetOrdinal("ds_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_chopeira")))
                        reg.Nr_chopeira = reader.GetString(reader.GetOrdinal("nr_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("voltagem")))
                        reg.Voltagem = reader.GetString(reader.GetOrdinal("voltagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_torneiras")))
                        reg.Qt_torneiras = reader.GetString(reader.GetOrdinal("qt_torneiras"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("cancelado"));

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

        public TList_Chopeira Select(string Cd_empresa,
                                     DateTime Dt_reserva,
                                     DateTime Dt_prevretorno)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("declare @startDate datetime; ")
                .AppendLine("declare @endDate datetime; ")
                .AppendLine("set @startDate = '" + Dt_reserva.ToString("yyyyMMdd") + "';")
                .AppendLine("set @endDate = '" + Dt_prevretorno.ToString("yyyyMMdd") + "';")
                .AppendLine("with dateRange as ")
                .AppendLine("(")
                .AppendLine("select dt = @startDate ")
                .AppendLine("where @startDate <= @endDate")
                .AppendLine("union all")
                .AppendLine("select dateadd(dd, 1, dt)")
                .AppendLine("from dateRange")
                .AppendLine("where dateadd(dd, 1, dt) <= @endDate")
                .AppendLine(")")
                .AppendLine("select a.voltagem, a.QT_Torneiras, count(1) as Qt_chopeira, ")
                .AppendLine("Qt_reservada = isnull((select count(1) from TB_RES_ReservaChopp x ")
                .AppendLine("				inner join VTB_RES_ItensReserva y ")
                .AppendLine("				on x.CD_Empresa = y.CD_Empresa ")
                .AppendLine("				and x.ID_Reserva = y.ID_Reserva ")
                .AppendLine("				and isnull(x.ST_Registro, 'A') = 'A' ")
                .AppendLine("				and (isnull(y.ST_Registro, '0') = '0' or isnull(y.ST_Registro, '0') = '1' or isnull(y.ST_Registro, '0') = '2') ")
                .AppendLine("				and exists(select 1 from dateRange w where convert(datetime, floor(convert(decimal(30,10), w.dt))) ")
                .AppendLine("					between convert(datetime, floor(convert(decimal(30,10), x.DT_Reserva))) ")
                .AppendLine("					and convert(datetime, floor(convert(decimal(30,10), x.DT_PrevRetorno))))")
                .AppendLine("				and x.cd_empresa = '" + Cd_empresa.Trim() + "'")
                .AppendLine("				and y.voltagem = a.voltagem ")
                .AppendLine("				and y.qt_torneiras = a.qt_torneiras), 0) ")
                .AppendLine("from tb_res_chopeira a ")
                .AppendLine("where a.cancelado = 0 ")
                .AppendLine("group by voltagem, QT_Torneiras ");

            TList_Chopeira lista = new TList_Chopeira();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_Chopeira reg = new TRegistro_Chopeira();
                    if (!reader.IsDBNull(reader.GetOrdinal("voltagem")))
                        reg.Voltagem = reader.GetString(reader.GetOrdinal("voltagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_torneiras")))
                        reg.Qt_torneiras = reader.GetString(reader.GetOrdinal("qt_torneiras"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_chopeira")))
                        reg.Qt_chopeira = reader.GetInt32(reader.GetOrdinal("Qt_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_reservada")))
                        reg.Qt_reservada = reader.GetInt32(reader.GetOrdinal("Qt_reservada"));

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

        public string Gravar(TRegistro_Chopeira val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_CHOPEIRA", val.Id_chopeira);
            hs.Add("@P_DS_CHOPEIRA", val.Ds_chopeira);
            hs.Add("@P_NR_CHOPEIRA", val.Nr_chopeira);
            hs.Add("@P_VOLTAGEM", val.Voltagem);
            hs.Add("@P_QT_TORNEIRAS", val.Qt_torneiras);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_RES_CHOPEIRA", hs);
        }

        public string Excluir(TRegistro_Chopeira val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CHOPEIRA", val.Id_chopeira);

            return executarProc("EXCLUI_RES_CHOPEIRA", hs);
        }
    }
}
