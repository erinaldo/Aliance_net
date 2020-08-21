using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region Intervencao Tecnica
    public class TList_IntervencaoTecnica : List<TRegistro_IntervencaoTecnica>
    { }

    
    public class TRegistro_IntervencaoTecnica
    {
        private decimal? id_intervencao;
        
        public decimal? Id_intervencao
        {
            get { return id_intervencao; }
            set
            {
                id_intervencao = value;
                id_intervencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_intervencaostr;
        
        public string Id_intervencaostr
        {
            get { return id_intervencaostr; }
            set
            {
                id_intervencaostr = value;
                try
                {
                    id_intervencao = decimal.Parse(value);
                }
                catch
                { id_intervencao = null; }
            }
        }
        private decimal? id_bomba;
        
        public decimal? Id_bomba
        {
            get { return id_bomba; }
            set
            {
                id_bomba = value;
                id_bombastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bombastr;
        
        public string Id_bombastr
        {
            get { return id_bombastr; }
            set
            {
                id_bombastr = value;
                try
                {
                    id_bomba = decimal.Parse(value);
                }
                catch
                { id_bomba = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_cliforintervencao
        { get; set; }
        
        public string Nm_cliforintervencao
        { get; set; }
        
        public string Nr_cnpjintervencao
        { get; set; }
        private DateTime? dt_intervencao;
        
        public DateTime? Dt_intervencao
        {
            get { return dt_intervencao; }
            set
            {
                dt_intervencao = value;
                dt_intervencaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_intervencaostr;
        public string Dt_intervencaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_intervencaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_intervencaostr = value;
                try
                {
                    dt_intervencao = DateTime.Parse(value);
                }
                catch
                { dt_intervencao = null; }
            }
        }
        
        public string Nr_intervencao
        { get; set; }
        
        public string Ds_motivo
        { get; set; }
        
        public string Nm_tecnico
        { get; set; }
        
        public string Cpf_tecnico
        { get; set; }
        
        public CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lBico
        { get; set; }
        public TRegistro_IntervencaoTecnica()
        {
            this.id_intervencao = null;
            this.id_intervencaostr = string.Empty;
            this.id_bomba = null;
            this.id_bombastr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_cliforintervencao = string.Empty;
            this.Nm_cliforintervencao = string.Empty;
            this.Nr_cnpjintervencao = string.Empty;
            this.dt_intervencao = null;
            this.dt_intervencaostr = string.Empty;
            this.Nr_intervencao = string.Empty;
            this.Ds_motivo = string.Empty;
            this.Nm_tecnico = string.Empty;
            this.Cpf_tecnico = string.Empty;

            this.lBico = new CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba();
        }
    }

    public class TCD_IntervencaoTecnica : TDataQuery
    {
        public TCD_IntervencaoTecnica()
        { }

        public TCD_IntervencaoTecnica(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Intervencao, a.ID_Bomba, ");
                sql.AppendLine("a.cd_cliforintervencao, c.nm_clifor, c.nr_cgc, ");
                sql.AppendLine("a.DT_Intervencao, a.NR_Intervencao, a.DS_Motivo, ");
                sql.AppendLine("a.NM_Tecnico, a.CPF_Tecnico, a.cd_empresa, b.nm_empresa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_IntervencaoTecnica a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_cliforintervencao = c.cd_clifor ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_IntervencaoTecnica Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_IntervencaoTecnica lista = new TList_IntervencaoTecnica();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_IntervencaoTecnica reg = new TRegistro_IntervencaoTecnica();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_intervencao"))))
                        reg.Id_intervencao = reader.GetDecimal(reader.GetOrdinal("id_intervencao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_bomba"))))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("id_bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforintervencao")))
                        reg.Cd_cliforintervencao = reader.GetString(reader.GetOrdinal("cd_cliforintervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_cliforintervencao = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Nr_cnpjintervencao = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("dt_intervencao"))))
                        reg.Dt_intervencao = reader.GetDateTime(reader.GetOrdinal("dt_intervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_intervencao")))
                        reg.Nr_intervencao = reader.GetString(reader.GetOrdinal("nr_intervencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tecnico")))
                        reg.Nm_tecnico = reader.GetString(reader.GetOrdinal("nm_tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_tecnico")))
                        reg.Cpf_tecnico = reader.GetString(reader.GetOrdinal("cpf_tecnico"));

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

        public string Gravar(TRegistro_IntervencaoTecnica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);
            hs.Add("@P_ID_BOMBA", val.Id_bomba);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFORINTERVENCAO", val.Cd_cliforintervencao);
            hs.Add("@P_DT_INTERVENCAO", val.Dt_intervencao);
            hs.Add("@P_NR_INTERVENCAO", val.Nr_intervencao);
            hs.Add("@P_DS_MOTIVO", val.Ds_motivo);
            hs.Add("@P_NM_TECNICO", val.Nm_tecnico);
            hs.Add("@P_CPF_TECNICO", val.Cpf_tecnico);

            return this.executarProc("IA_PDC_INTERVENCAOTECNICA", hs);
        }

        public string Excluir(TRegistro_IntervencaoTecnica val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);

            return this.executarProc("EXCLUI_PDC_INTERVENCAOTECNICA", hs);
        }
    }
    #endregion

    #region Intervencao X Encerrante
    public class TList_Intervencao_X_Encerrante : List<TRegistro_Intervencao_X_Encerrante>
    { }

    
    public class TRegistro_Intervencao_X_Encerrante
    {
        private decimal? id_intervencao;
        
        public decimal? Id_intervencao
        {
            get { return id_intervencao; }
            set
            {
                id_intervencao = value;
                id_intervencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_intervencaostr;
        
        public string Id_intervencaostr
        {
            get { return id_intervencaostr; }
            set
            {
                id_intervencaostr = value;
                try
                {
                    id_intervencao = decimal.Parse(value);
                }
                catch
                { id_intervencao = null; }
            }
        }
        private decimal? id_encerrante;
        
        public decimal? Id_encerrante
        {
            get { return id_encerrante; }
            set
            {
                id_encerrante = value;
                id_encerrantestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_encerrantestr;
        
        public string Id_encerrantestr
        {
            get { return id_encerrantestr; }
            set
            {
                id_encerrantestr = value;
                try
                {
                    id_encerrante = decimal.Parse(value);
                }
                catch
                { id_encerrante = null; }
            }
        }
        
        public TRegistro_Intervencao_X_Encerrante()
        {
            this.id_intervencao = null;
            this.id_intervencaostr = string.Empty;
            this.id_encerrante = null;
            this.id_encerrantestr = string.Empty;
        }
    }

    public class TCD_Intervencao_X_Encerrante : TDataQuery
    {
        public TCD_Intervencao_X_Encerrante()
        { }

        public TCD_Intervencao_X_Encerrante(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Intervencao, a.ID_Encerrante ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_Intervencao_X_Encerrante a ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Intervencao_X_Encerrante Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Intervencao_X_Encerrante lista = new TList_Intervencao_X_Encerrante();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Intervencao_X_Encerrante reg = new TRegistro_Intervencao_X_Encerrante();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_intervencao"))))
                        reg.Id_intervencao = reader.GetDecimal(reader.GetOrdinal("id_intervencao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_encerrante"))))
                        reg.Id_encerrante = reader.GetDecimal(reader.GetOrdinal("id_encerrante"));

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

        public string Gravar(TRegistro_Intervencao_X_Encerrante val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);
            hs.Add("@P_ID_ENCERRANTE", val.Id_encerrante);

            return this.executarProc("IA_PDC_INTERVENCAO_X_ENCERRANTE", hs);
        }

        public string Excluir(TRegistro_Intervencao_X_Encerrante val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_INTERVENCAO", val.Id_intervencao);
            hs.Add("@P_ID_ENCERRANTE", val.Id_encerrante);

            return this.executarProc("EXCLUI_PDC_INTERVENCAO_X_ENCERRANTE", hs);
        }
    }
    #endregion
}
