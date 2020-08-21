using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante
{
    public class TRegistro_HoraBoliche
    {
        public decimal Id_Hora { get; set; } = decimal.Zero;

        private TimeSpan? hora;
        public TimeSpan? Hora
        {
            get { return hora; }
            set
            {
                hora = value;
                //horastr = value.HasValue ? value.Value.ToString("00:00") : string.Empty;
            }
        }
        private string horastr;
        public string Horastr {
            get
            {
                try
                {
                    return TimeSpan.Parse(horastr).ToString("00:00");
                }
                catch { return string.Empty; }
            }
            set
            {
                horastr = value;
                try
                {
                    hora = TimeSpan.Parse(value);
                }
                catch { hora = null; }
            }
        }

        private string dia;
        public string Dia
        {
            get { return tp_dia; }
            set
            {
                dia = value;
                if (value.Trim().Equals("2"))
                    tp_dia = "SEGUNDA";
                else if (value.Trim().Equals("3"))
                    tp_dia = "TERÇA";
                else if (value.Trim().Equals("4"))
                    tp_dia = "QUARTA";
                else if (value.Trim().Equals("5"))
                    tp_dia = "QUINTA";
                else if (value.Trim().Equals("6"))
                    tp_dia = "SEXTA";
                else if (value.Trim().Equals("7"))
                    tp_dia = "SÁBADO";
                else if (value.Trim().Equals("1"))
                    tp_dia = "DOMINGO";
            }
        }

        private string tp_dia;
        public string Tp_dia {
            get { return dia; }
            set
            {
                tp_dia = value;
                if (value.Trim().ToUpper().Equals("DOMINGO"))
                    dia = "1";
                else if (value.Trim().ToUpper().Equals("SEGUNDA"))
                    dia = "2";
                else if (value.Trim().ToUpper().Equals("TERÇA"))
                    dia = "3";
                else if (value.Trim().ToUpper().Equals("QUARTA"))
                    dia = "4";
                else if (value.Trim().ToUpper().Equals("QUINTA"))
                    dia = "5";
                else if (value.Trim().ToUpper().Equals("SEXTA"))
                    dia = "6";
                else if (value.Trim().ToUpper().Equals("SÁBADO"))
                    dia = "7";
                
            }
        }

        public decimal Vl_hora { get; set; } = decimal.Zero;
        public string Tp_servico { get; set; } = string.Empty;

    }

    public class TList_HoraBoliche : List<TRegistro_HoraBoliche> { }

    public class TCD_HoraBoliche : TDataQuery
    {
        public TCD_HoraBoliche() { }

        public TCD_HoraBoliche(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_hora, a.hora, a.vl_hora, a.dia, a.tp_servico ");
            else
                sql.AppendLine("select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_horaboliche a");

            string cond = "where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" order by " + vOrder);

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_HoraBoliche Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_HoraBoliche lista = new TList_HoraBoliche();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_HoraBoliche rHora = new TRegistro_HoraBoliche();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Hora")))
                        rHora.Id_Hora = reader.GetDecimal(reader.GetOrdinal("ID_Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Hora")))
                        rHora.Hora = reader.GetTimeSpan(reader.GetOrdinal("Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Hora")))
                        rHora.Vl_hora = reader.GetDecimal(reader.GetOrdinal("Vl_Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dia")))
                        rHora.Dia = reader.GetString(reader.GetOrdinal("Dia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_servico")))
                        rHora.Tp_servico = reader.GetString(reader.GetOrdinal("Tp_servico"));
                    lista.Add(rHora);
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

        public TList_HoraBoliche Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_HoraBoliche lista = new TList_HoraBoliche();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_HoraBoliche rHora = new TRegistro_HoraBoliche();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Hora")))
                        rHora.Id_Hora = reader.GetDecimal(reader.GetOrdinal("ID_Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Hora")))
                        rHora.Hora = reader.GetTimeSpan(reader.GetOrdinal("Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Hora")))
                        rHora.Vl_hora = reader.GetDecimal(reader.GetOrdinal("Vl_Hora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dia")))
                        rHora.Dia = reader.GetString(reader.GetOrdinal("Dia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_servico")))
                        rHora.Tp_servico = reader.GetString(reader.GetOrdinal("Tp_servico"));
                    lista.Add(rHora);
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

        public string Gravar(TRegistro_HoraBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_HORA", val.Id_Hora);
            hs.Add("@P_HORA", val.Hora);
            hs.Add("@P_VL_HORA", val.Vl_hora);
            hs.Add("@P_DIA", val.Tp_dia);
            hs.Add("@P_TP_SERVICO", val.Tp_servico);
            return this.executarProc("IA_RES_HORABOLICHE", hs);
        }

        public string Excluir(TRegistro_HoraBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_HORA", val.Id_Hora);
            return this.executarProc("EXCLUI_RES_HORABOLICHE", hs);
        }
    }
}
