using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Servicos.Cadastros;

namespace CamadaDados.Servicos
{
    public class TList_LanServicoEvolucao : List<TRegistro_LanServicoEvolucao>, IComparer<TRegistro_LanServicoEvolucao>
    {
        #region IComparer<TRegistro_LanServicoEvolucao> Members
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

        public TList_LanServicoEvolucao()
        { }

        public TList_LanServicoEvolucao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanServicoEvolucao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanServicoEvolucao x, TRegistro_LanServicoEvolucao y)
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

    
    public class TRegistro_LanServicoEvolucao
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
        private decimal? id_etapa;
        
        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = (value.HasValue ? value.Value.ToString() : string.Empty);
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
                    id_etapa = Convert.ToDecimal(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        
        public string Ds_etapa
        { get; set; }
        
        public string Cd_tecnico
        { get; set; }
        
        public string NM_Tecnico
        { get; set; }

        public string Cd_oficina
        { get; set; }
        public string Nm_oficina
        { get; set; }
        public string Cd_EndOficina
        { get; set; }
        public string Ds_EndOficina
        { get; set; }
        
        public string Ds_evolucao
        { get; set; }
        
        public bool St_iniciarOS
        { get; set; }
        
        public bool St_finalizarOS
        { get; set; }
        
        public bool St_etapaOrcamentoOS
        { get; set; }
        
        public bool St_envterceiro
        { get; set; }
        private DateTime? dt_inicio;
        
        public DateTime? Dt_inicio
        {
            get { return dt_inicio; }
            set
            {
                dt_inicio = value;
                dt_iniciostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_iniciostr;
        public string Dt_iniciostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_iniciostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_iniciostr = value;
                try
                {
                    dt_inicio = DateTime.Parse(value);
                }
                catch
                { dt_inicio = null; }
            }
        }
        private DateTime? dt_final;
        
        public DateTime? Dt_final
        {
            get { return dt_final; }
            set
            {
                dt_final = value;
                dt_finalstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_finalstr;
        public string Dt_finalstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finalstr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finalstr = value;
                try
                {
                    dt_final = DateTime.Parse(value);
                }
                catch
                { dt_final = null; }
            }
        }
        private DateTime? dt_previstatermino;
        
        public DateTime? Dt_previstatermino
        {
            get { return dt_previstatermino; }
            set
            {
                dt_previstatermino = value;
                dt_previstaterminostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_previstaterminostr;
        public string Dt_previstaterminostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_previstaterminostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_previstaterminostr = value;
                try
                {
                    dt_previstatermino = DateTime.Parse(value);
                }
                catch
                { dt_previstatermino = null; }
            }
        }
        private string st_evolucao;
        
        public string St_evolucao
        {
            get { return st_evolucao; }
            set
            {
                st_evolucao = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTA";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADA";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTA"))
                    st_evolucao = "A";
                else if (value.Trim().ToUpper().Equals("ENCERRADA"))
                    st_evolucao = "E";
            }
        }
        public decimal Ordem
        { get; set; }
        public TList_LanAtividades lAtividade
        { get; set; }
        public TList_LanAtividades lAtividadeDel
        { get; set; }

        public TRegistro_LanServicoEvolucao()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_evolucao = null;
            this.id_evolucaostr = string.Empty;
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.Ds_etapa = string.Empty;
            this.Cd_tecnico = string.Empty;
            this.NM_Tecnico = string.Empty;
            this.Cd_oficina = string.Empty;
            this.Nm_oficina = string.Empty;
            this.Cd_EndOficina = string.Empty;
            this.Ds_EndOficina = string.Empty;
            this.Ds_evolucao = string.Empty;
            this.St_iniciarOS = false;
            this.St_finalizarOS = false;
            this.St_envterceiro = false;
            this.St_etapaOrcamentoOS = false;
            this.dt_inicio = DateTime.Now;
            this.dt_iniciostr = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.dt_final = null;
            this.dt_finalstr = string.Empty;
            this.dt_previstatermino = null;
            this.dt_previstaterminostr = string.Empty;
            this.st_evolucao = "A";
            this.status = "ABERTA";
            this.Ordem = decimal.Zero;
            this.lAtividade = new TList_LanAtividades();
            this.lAtividadeDel = new TList_LanAtividades();
        }
    }

    public class TCD_LanServicoEvolucao : TDataQuery
    {
        public TCD_LanServicoEvolucao()
        { }

        public TCD_LanServicoEvolucao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_os, a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_evolucao, a.cd_tecnico, c.nm_clifor as NM_Tecnico, a.cd_oficina, e.nm_clifor as nm_oficina, ");
                sql.AppendLine("a.CD_EndOficina, f.ds_endereco as Ds_EndOficina, a.id_etapa, d.ds_etapa, d.st_envterceiro, ");
                sql.AppendLine("d.st_iniciaros, d.st_finalizaros, d.ST_EtapaOrcamento, ");
                sql.AppendLine("a.ds_evolucao, a.dt_inicio, a.dt_final, ");
                sql.AppendLine("a.dt_previstatermino, a.st_evolucao, a.ordem ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ose_evolucao a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_clifor c ");
            sql.AppendLine("on a.cd_tecnico = c.cd_clifor ");
            sql.AppendLine("inner join TB_OSE_EtapaOrdem d ");
            sql.AppendLine("on a.id_etapa = d.id_etapa ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.cd_oficina = e.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_endereco f ");
            sql.AppendLine("on a.CD_EndOficina = f.cd_endereco ");
            sql.AppendLine("and a.cd_oficina = f.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_LanServicoEvolucao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_LanServicoEvolucao lista = new TList_LanServicoEvolucao();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanServicoEvolucao reg = new TRegistro_LanServicoEvolucao();
                    //Dados da Evolução OS
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Evolucao"))))
                        reg.Id_evolucao = reader.GetDecimal(reader.GetOrdinal("ID_Evolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Evolucao"))))
                        reg.Ds_evolucao = reader.GetString(reader.GetOrdinal("DS_Evolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Tecnico")))
                        reg.Cd_tecnico = reader.GetString(reader.GetOrdinal("CD_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tecnico")))
                        reg.NM_Tecnico = reader.GetString(reader.GetOrdinal("NM_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_oficina")))
                        reg.Cd_oficina = reader.GetString(reader.GetOrdinal("cd_oficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_oficina")))
                        reg.Nm_oficina = reader.GetString(reader.GetOrdinal("nm_oficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndOficina")))
                        reg.Cd_EndOficina = reader.GetString(reader.GetOrdinal("CD_EndOficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_EndOficina")))
                        reg.Ds_EndOficina = reader.GetString(reader.GetOrdinal("Ds_EndOficina"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_INICIO"))))
                        reg.Dt_inicio = reader.GetDateTime(reader.GetOrdinal("DT_INICIO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_FINAL"))))
                        reg.Dt_final = reader.GetDateTime(reader.GetOrdinal("DT_FINAL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevistaTermino")))
                        reg.Dt_previstatermino = reader.GetDateTime(reader.GetOrdinal("DT_PrevistaTermino"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_EVOLUCAO"))))
                        reg.St_evolucao = reader.GetString(reader.GetOrdinal("ST_EVOLUCAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("ID_Etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Etapa")))
                        reg.Ds_etapa = reader.GetString(reader.GetOrdinal("DS_Etapa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ordem"))))
                        reg.Ordem = reader.GetDecimal(reader.GetOrdinal("ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_iniciaros")))
                        reg.St_iniciarOS = reader.GetString(reader.GetOrdinal("st_iniciaros")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_finalizaros")))
                        reg.St_finalizarOS = reader.GetString(reader.GetOrdinal("st_finalizaros")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_envterceiro")))
                        reg.St_envterceiro = reader.GetString(reader.GetOrdinal("st_envterceiro")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EtapaOrcamento")))
                        reg.St_etapaOrcamentoOS = reader.GetString(reader.GetOrdinal("ST_EtapaOrcamento")).Trim().ToUpper().Equals("S");

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

        public string Gravar(TRegistro_LanServicoEvolucao val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_DS_EVOLUCAO", val.Ds_evolucao);
            hs.Add("@P_DT_INICIO", val.Dt_inicio);
            hs.Add("@P_DT_FINAL", val.Dt_final);
            hs.Add("@P_DT_PREVISTATERMINO", val.Dt_previstatermino);
            hs.Add("@P_ORDEM", val.Ordem);
            hs.Add("@P_ST_EVOLUCAO", val.St_evolucao);
            hs.Add("@P_CD_TECNICO", val.Cd_tecnico);
            hs.Add("@P_CD_OFICINA", val.Cd_oficina);
            hs.Add("@P_CD_ENDOFICINA", val.Cd_EndOficina);

            return this.executarProc("IA_OSE_EVOLUCAO", hs);
        }

        public string Excluir(TRegistro_LanServicoEvolucao val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);

            return this.executarProc("EXCLUI_OSE_EVOLUCAO", hs);
        }
    }
}
