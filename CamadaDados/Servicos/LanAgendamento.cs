using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Servicos
{
    public class TList_Agendamento : List<TRegistro_Agendamento>, IComparer<TRegistro_Agendamento>
    {
        #region IComparer<TRegistro_Agendamento> Members
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

        public TList_Agendamento()
        { }

        public TList_Agendamento(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Agendamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Agendamento x, TRegistro_Agendamento y)
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

    public class TRegistro_Agendamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_agenda;
        public decimal? Id_agenda
        {
            get { return id_agenda; }
            set
            {
                id_agenda = value;
                id_agendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_agendastr;
        public string Id_agendastr
        {
            get { return id_agendastr; }
            set
            {
                id_agendastr = value;
                try
                {
                    id_agenda = decimal.Parse(value);
                }
                catch { id_agenda = null; }
            }
        }
        public string Cd_tecnico
        { get; set; }
        public string Nm_tecnico
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Fone_clifor
        { get; set; }
        public decimal? Id_os
        { get; set; }
        public string Cd_servico
        { get; set; }
        public string Ds_servico
        { get; set; }
        private DateTime? dt_agendamento;
        public DateTime? Dt_agendamento
        {
            get { return dt_agendamento; }
            set
            {
                dt_agendamento = value;
                if (value.HasValue)
                {
                    dt_agendamentostr = value.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    Data_agendamento = value.Value.ToString("dd/MM/yyyy");
                    Hora_agendamento = value.Value.ToString("HH:mm:ss");
                }
                else
                {
                    dt_agendamentostr = string.Empty;
                    Data_agendamento = string.Empty;
                    Hora_agendamento = string.Empty;
                }
            }
        }
        private string dt_agendamentostr;
        public string Dt_agendamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_agendamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_agendamentostr = value;
                try
                {
                    dt_agendamento = DateTime.Parse(value);
                    Data_agendamento = DateTime.Parse(value).ToString("dd/MM/yyyy");
                    Hora_agendamento = DateTime.Parse(value).ToString("HH:mm:ss");
                }
                catch { dt_agendamento = null; }
            }
        }
        public string Data_agendamento
        { get; set; }
        public string Hora_agendamento
        { get; set; }
        public string Ds_obs
        { get; set; }
        public string Motivodesmarcar
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "EXECUTADO";
                else if (value.Trim().ToUpper().Equals("D"))
                    status = "DESMARCADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("N"))
                    status = "NÃO COMPARECEU";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("EXECUTADO"))
                    st_registro = "E";
                else if (value.Trim().ToUpper().Equals("DESMARCADO"))
                    st_registro = "D";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("NÃO COMPARECEU"))
                    St_registro = "N";
            }
        }

        public TRegistro_Agendamento()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_agenda = null;
            this.id_agendastr = string.Empty;
            this.Cd_tecnico = string.Empty;
            this.Nm_tecnico = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Fone_clifor = string.Empty;
            this.Id_os = null;
            this.Cd_servico = string.Empty;
            this.Ds_servico = string.Empty;
            this.dt_agendamento = null;
            this.dt_agendamentostr = string.Empty;
            this.Data_agendamento = string.Empty;
            this.Hora_agendamento = string.Empty;
            this.Ds_obs = string.Empty;
            this.Motivodesmarcar = string.Empty;
            this.st_registro = "A";
            this.status = "ATIVO";
        }
    }

    public class TCD_Agendamento : TDataQuery
    {
        public TCD_Agendamento() { }

        public TCD_Agendamento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Agenda, ");
                sql.AppendLine("a.CD_Clifor, isnull(c.NM_Clifor, a.NM_Clifor) as NM_Clifor, ");
                sql.AppendLine("isnull(endClifor.fone, a.Fone_Clifor) as Fone_Clifor, ");
                sql.AppendLine("endClifor.cd_endereco, endClifor.ds_endereco, ");
                sql.AppendLine("a.id_os, a.CD_Tecnico, d.NM_Clifor as NM_Tecnico, ");
                sql.AppendLine("a.DT_Agendamento, a.DS_obs, a.MotivoDesmarcar, a.ST_Registro, ");
                sql.AppendLine("a.CD_Servico, serv.ds_produto as ds_servico ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Agendamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("left outer join TB_FIN_Endereco endClifor ");
            sql.AppendLine("on a.cd_clifor = endClifor.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = endClifor.cd_endereco ");
            sql.AppendLine("inner join TB_EST_Produto serv ");
            sql.AppendLine("on a.cd_servico = serv.cd_produto ");
            sql.AppendLine("left outer join TB_FIN_Clifor d ");
            sql.AppendLine("on a.CD_Tecnico = d.CD_Clifor ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_Agendamento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_Agendamento lista = new TList_Agendamento();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Agendamento reg = new TRegistro_Agendamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Agenda")))
                        reg.Id_agenda = reader.GetDecimal(reader.GetOrdinal("ID_Agenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_Clifor")))
                        reg.Fone_clifor = reader.GetString(reader.GetOrdinal("Fone_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_servico")))
                        reg.Cd_servico = reader.GetString(reader.GetOrdinal("cd_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("ds_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Tecnico")))
                        reg.Cd_tecnico = reader.GetString(reader.GetOrdinal("CD_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tecnico")))
                        reg.Nm_tecnico = reader.GetString(reader.GetOrdinal("NM_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Agendamento")))
                        reg.Dt_agendamento = reader.GetDateTime(reader.GetOrdinal("DT_Agendamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("DS_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoDesmarcar")))
                        reg.Motivodesmarcar = reader.GetString(reader.GetOrdinal("MotivoDesmarcar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
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

        public string Gravar(TRegistro_Agendamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_AGENDA", val.Id_agenda);
            hs.Add("@P_CD_TECNICO", val.Cd_tecnico);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_FONE_CLIFOR", val.Fone_clifor);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_SERVICO", val.Cd_servico);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_DT_AGENDAMENTO", val.Dt_agendamento);
            hs.Add("@P_DS_SERVICO", val.Ds_servico);
            hs.Add("@P_MOTIVODESMARCAR", val.Motivodesmarcar);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_OSE_AGENDAMENTO", hs);
        }

        public string Excluir(TRegistro_Agendamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_AGENDA", val.Id_agenda);

            return this.executarProc("EXCLUI_OSE_ANGEDAMENTO", hs);
        }
    }
}
