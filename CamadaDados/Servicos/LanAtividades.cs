using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Servicos
{
    public class TList_LanAtividades : List<TRegistro_LanAtividades>, IComparer<TRegistro_LanAtividades>
    {
        #region IComparer<TRegistro_LanAtividades> Members
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

        public TList_LanAtividades()
        { }

        public TList_LanAtividades(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanAtividades value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanAtividades x, TRegistro_LanAtividades y)
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
    
    public class TRegistro_LanAtividades
    {
        private decimal? id_os;
        
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_evolucao;
        
        public decimal? Id_evolucao
        {
            get { return id_evolucao; }
            set
            {
                id_evolucao = value;
                id_evolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_evolucaostr;
        
        public string Id_evolucaostr
        {
            get { return id_evolucaostr; }
            set
            {
                id_evolucaostr = value;
                try
                {
                    id_evolucao = decimal.Parse(value);
                }
                catch
                { id_evolucao = null; }
            }
        }
        private decimal? id_atividade;
        
        public decimal? Id_atividade
        {
            get { return id_atividade; }
            set
            {
                id_atividade = value;
                id_atividadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atividadestr;
        
        public string Id_atividadestr
        {
            get { return id_atividadestr; }
            set
            {
                id_atividadestr = value;
                try
                {
                    id_atividade = decimal.Parse(value);
                }
                catch
                { id_atividade = null; }
            }
        }
        
        public string Login
        { get; set; }
        
        public string Cd_tecnico
        { get; set; }
        
        public string Ds_tecnico
        { get; set; }
        
        public string Ds_atividade
        { get; set; }
        private DateTime? dt_atividade;
        
        public DateTime? Dt_atividade
        {
            get { return dt_atividade; }
            set
            {
                dt_atividade = value;
                dt_atividadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_atividadestr;
        public string Dt_atividadestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_atividadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_atividadestr = value;
                try
                {
                    dt_atividade = DateTime.Parse(value);
                }
                catch
                { dt_atividade = null; }
            }
        }
        private DateTime? dt_PrevConclusao;
        
        public DateTime? Dt_PrevConclusao
        {
            get { return dt_PrevConclusao; }
            set
            {
                dt_PrevConclusao = value;
                dt_PrevConclusaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_PrevConclusaostr;
        public string Dt_PrevConclusaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_PrevConclusaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_PrevConclusaostr = value;
                try
                {
                    dt_PrevConclusao = DateTime.Parse(value);
                }
                catch
                { dt_PrevConclusao = null; }
            }
        }
        private DateTime? dt_Conclusao;
        
        public DateTime? Dt_Conclusao
        {
            get { return dt_Conclusao; }
            set
            {
                dt_Conclusao = value;
                dt_Conclusaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_Conclusaostr;
        public string Dt_Conclusaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_Conclusaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_Conclusaostr = value;
                try
                {
                    dt_Conclusao = DateTime.Parse(value);
                }
                catch
                { dt_Conclusao = null; }
            }
        }
        
        public decimal Horas_trabalhadas
        { get; set; }
        public string horas_trab
        {
            get { return Horas_trabalhadas.ToString().Replace(",", ":"); }
        }
        
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("P"))
                    return "PENDENTE";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CONCLUÍDA";
                else return string.Empty;
            }
        }

        public TRegistro_LanAtividades()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_evolucao = null;
            this.id_evolucaostr = string.Empty;
            this.id_atividade = null;
            this.id_atividadestr = string.Empty;
            this.Login = string.Empty;
            this.Cd_tecnico = string.Empty;
            this.Ds_atividade = string.Empty;
            this.dt_atividade = null;
            this.dt_atividadestr = string.Empty;
            this.dt_PrevConclusao = null;
            this.dt_PrevConclusaostr = string.Empty;
            this.dt_Conclusao = null;
            this.dt_Conclusaostr = string.Empty;
            this.Horas_trabalhadas = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_registro = "P";
        }
    }

    public class TCD_LanAtividades : TDataQuery
    {
        public TCD_LanAtividades()
        { }

        public TCD_LanAtividades(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_OS, a.CD_Empresa, a.ID_Evolucao, a.ID_Atividade, ");
                sql.AppendLine("a.Login, a.CD_Tecnico, c.nm_clifor as ds_tecnico, a.DS_Atividade, a.DT_Atividade, a.DT_PrevConclusao, a.DT_Conclusao, ");
                sql.AppendLine("a.Horas_Trabalhadas, a.DS_Observacao, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Atividades a ");
            sql.AppendLine("inner join tb_ose_servico os ");
            sql.AppendLine("on a.cd_empresa = os.cd_empresa ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join tb_ose_evolucao ev ");
            sql.AppendLine("on a.id_evolucao = ev.id_evolucao ");
            sql.AppendLine("and a.id_os = ev.id_os ");
            sql.AppendLine("and a.cd_empresa = ev.cd_empresa ");
            sql.AppendLine("and a.id_os = os.id_os ");
            sql.AppendLine("left outer join tb_div_usuario b ");
            sql.AppendLine("on a.Login = b.Login ");
            sql.AppendLine("left outer join tb_fin_clifor c ");
            sql.AppendLine("on a.cd_tecnico = c.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LanAtividades Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanAtividades lista = new TList_LanAtividades();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAtividades reg = new TRegistro_LanAtividades();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Evolucao")))
                        reg.Id_evolucao = reader.GetDecimal(reader.GetOrdinal("ID_Evolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Atividade"))))
                        reg.Id_atividade = reader.GetDecimal(reader.GetOrdinal("ID_Atividade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Tecnico")))
                        reg.Cd_tecnico = reader.GetString(reader.GetOrdinal("CD_Tecnico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Tecnico"))))
                        reg.Ds_tecnico = reader.GetString(reader.GetOrdinal("DS_Tecnico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Atividade"))))
                        reg.Ds_atividade = reader.GetString(reader.GetOrdinal("DS_Atividade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Atividade"))))
                        reg.Dt_atividade = reader.GetDateTime(reader.GetOrdinal("DT_Atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevConclusao")))
                        reg.Dt_PrevConclusao = reader.GetDateTime(reader.GetOrdinal("DT_PrevConclusao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Conclusao")))
                        reg.Dt_Conclusao = reader.GetDateTime(reader.GetOrdinal("DT_Conclusao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Horas_Trabalhadas"))))
                        reg.Horas_trabalhadas = reader.GetDecimal(reader.GetOrdinal("Horas_Trabalhadas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
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

        public string Gravar(TRegistro_LanAtividades val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);
            hs.Add("@P_CD_TECNICO", val.Cd_tecnico);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_DS_ATIVIDADE", val.Ds_atividade);
            hs.Add("@P_DT_ATIVIDADE", val.Dt_atividade);
            hs.Add("@P_DT_PREVCONCLUSAO", val.Dt_PrevConclusao);
            hs.Add("@P_DT_CONCLUSAO", val.Dt_Conclusao);
            hs.Add("@P_HORAS_TRABALHADAS", val.Horas_trabalhadas);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_OSE_ATIVIDADES", hs);
        }

        public string Excluir(TRegistro_LanAtividades val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);

            return this.executarProc("EXCLUI_OSE_ATIVIDADES", hs);
        }
    }
}
