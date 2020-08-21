using BancoDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TList_KitExtrator : List<TRegistro_KitExtrator> { }

    public class TRegistro_KitExtrator
    {
        public int? Id_kit { get; set; } = null;
        public string Nr_kit { get; set; } = string.Empty;
        public int Qtd_kit { get; set; }
        public int Qtd_reservada { get; set; }
        public int Qtd_disponivel => Qtd_kit - Qtd_reservada;
    }

    public class TCD_KitExtrator:TDataQuery
    {
        public TCD_KitExtrator() { }

        public TCD_KitExtrator(TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strtop + " a.id_kit, a.nr_kit ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_KitExtrator a ");

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

        public TList_KitExtrator Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_KitExtrator lista = new TList_KitExtrator();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_KitExtrator reg = new TRegistro_KitExtrator();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_kit")))
                        reg.Id_kit = reader.GetInt32(reader.GetOrdinal("id_kit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_kit")))
                        reg.Nr_kit = reader.GetString(reader.GetOrdinal("nr_kit"));

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

        public TList_KitExtrator Select(string Cd_empresa,
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
                .AppendLine("select count(1) as Qt_kit, ")
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
                .AppendLine("				and y.st_kitextrator = 1), 0)")
                .AppendLine("from tb_res_kitextrator a ");

            TList_KitExtrator lista = new TList_KitExtrator();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_KitExtrator reg = new TRegistro_KitExtrator();
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_kit")))
                        reg.Qtd_kit = reader.GetInt32(reader.GetOrdinal("Qt_kit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_reservada")))
                        reg.Qtd_reservada = reader.GetInt32(reader.GetOrdinal("Qt_reservada"));

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

        public string Gravar(TRegistro_KitExtrator val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_KIT", val.Id_kit);
            hs.Add("@P_NR_KIT", val.Nr_kit);

            return executarProc("IA_RES_KITEXTRATOR", hs);
        }

        public string Excluir(TRegistro_KitExtrator val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_KIT", val.Id_kit);

            return executarProc("EXCLUI_RES_KITEXTRATOR", hs);
        }
    }
}
