using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Duplicata
{
    #region Dados Bloqueio
    public class TList_DadosBloqueio : List<TRegistro_DadosBloqueio>, IComparer<TRegistro_DadosBloqueio>
    {
        #region IComparer<TRegistro_DadosBloqueio> Members
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

        public TList_DadosBloqueio()
        { }

        public TList_DadosBloqueio(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DadosBloqueio value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DadosBloqueio x, TRegistro_DadosBloqueio y)
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

    
    public class TRegistro_DadosBloqueio
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public decimal Vl_limitecredito
        { get; set; }
        public decimal Vl_limitecredCH
        { get; set; }
        public decimal Vl_debito_aberto
        { get; set; }
        public decimal Vl_dupPerdidas
        { get; set; }
        public string St_bloq_debitovencido
        { get; set; }
        public bool St_bloq_debitovencidobool
        { get { return St_bloq_debitovencido.Trim().ToUpper().Equals("S"); } }
        public decimal Vl_debito_vencto
        { get; set; }
        public string St_bloqcreditoavulso
        { get; set; }
        public bool St_bloqcreditoavulsobool
        { get { return St_bloqcreditoavulso.Trim().ToUpper().Equals("S"); } }
        public string Ds_motivobloqavulso
        { get; set; }
        public DateTime? Dt_renovacaocadastro
        { get; set; }
        public decimal Diasrenovacaocadastro
        { get; set; }
        public DateTime? Dt_atual
        { get; set; }
        public bool St_renovarcadastro
        {
            get
            {
                if (Diasrenovacaocadastro > decimal.Zero)
                    return Dt_renovacaocadastro.Value.AddDays(Convert.ToDouble(Diasrenovacaocadastro)).Date < Dt_atual.Value.Date;
                else
                    return false;
            }
        }
        public decimal Vl_ch_devolvido
        { get; set; }
        public decimal Vl_ch_predatado
        { get; set; }
        public decimal Vl_adto_devolver
        { get; set; }
        private DateTime? dt_consultaspc;
        public DateTime? Dt_consultaSPC
        {
            get { return dt_consultaspc; }
            set
            {
                dt_consultaspc = value;
                dt_consultaspcstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_consultaspcstr;
        public string Dt_consultaSPCstr
        {
            get { return dt_consultaspcstr; }
            set
            {
                dt_consultaspcstr = value;
                try
                {
                    dt_consultaspc = DateTime.Parse(value);
                }
                catch
                { dt_consultaspc = null; }
            }
        }
        public string Ds_ConsultaSPC
        { get; set; }
        private string st_bloqueiospc;
        public string St_bloqueiospc
        {
            get { return st_bloqueiospc; }
            set
            {
                st_bloqueiospc = value;
                st_bloqueiospcbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_bloqueiospcbool;
        public bool St_bloqueiospcbool
        {
            get { return st_bloqueiospcbool; }
            set
            {
                st_bloqueiospcbool = value;
                st_bloqueiospc = value ? "S" : "N";
            }
        }

        public TRegistro_DadosBloqueio()
        {
            //this.Cd_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Vl_limitecredito = decimal.Zero;
            this.Vl_limitecredCH = decimal.Zero;
            this.Vl_debito_aberto = decimal.Zero;
            this.Vl_dupPerdidas = decimal.Zero;
            this.St_bloq_debitovencido = string.Empty;
            this.Vl_debito_vencto = decimal.Zero;
            this.St_bloqcreditoavulso = string.Empty;
            this.Ds_motivobloqavulso = string.Empty;
            this.Dt_renovacaocadastro = null;
            this.Diasrenovacaocadastro = decimal.Zero;
            this.Dt_atual = null;
            this.Vl_ch_devolvido = decimal.Zero;
            this.Vl_ch_predatado = decimal.Zero;
            this.Vl_adto_devolver = decimal.Zero;
            this.dt_consultaspc = null;
            this.dt_consultaspcstr = string.Empty;
            this.Ds_ConsultaSPC = string.Empty;
            this.st_bloqueiospc = "N";
            this.st_bloqueiospcbool = false;
        }
    }

    public class TCD_DadosBloqueio : TDataQuery
    {
        public TCD_DadosBloqueio()
        { }

        public TCD_DadosBloqueio(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Clifor, a.NM_Clifor, a.Vl_LimiteCredito, a.Vl_LimiteCredCH, ");
            sql.AppendLine("a.vl_debito_aberto, a.Vl_dupPerdidas, a.ST_Bloq_DebitoVencido, ");
            sql.AppendLine("a.vl_debito_vencto, a.ST_BLOQCREDITOAVULSO, a.DS_MOTIVOBLOQAVULSO, ");
            sql.AppendLine("a.vl_ch_devolvido, a.vl_ch_predatado, ");
            sql.AppendLine("a.DT_ConsultaSPC, a.DS_ConsultaSPC, a.ST_BloqueioSPC,");
            sql.AppendLine("a.dt_renovacaocadastro, a.diasrenovacaocadastro, a.dt_atual ");

            sql.AppendLine("from VTB_FIN_CLIENTEINADIMPLENTE a ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("order by a.cd_clifor ");

            return sql.ToString();
        }

        public TList_DadosBloqueio Select(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_DadosBloqueio lista = new TList_DadosBloqueio();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(true);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DadosBloqueio reg = new TRegistro_DadosBloqueio();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_LimiteCredito"))))
                        reg.Vl_limitecredito = reader.GetDecimal(reader.GetOrdinal("Vl_LimiteCredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitecredch")))
                        reg.Vl_limitecredCH = reader.GetDecimal(reader.GetOrdinal("vl_limitecredch"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_debito_aberto"))))
                        reg.Vl_debito_aberto = reader.GetDecimal(reader.GetOrdinal("vl_debito_aberto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_dupPerdidas"))))
                        reg.Vl_dupPerdidas = reader.GetDecimal(reader.GetOrdinal("Vl_dupPerdidas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Bloq_DebitoVencido"))))
                        reg.St_bloq_debitovencido = reader.GetString(reader.GetOrdinal("ST_Bloq_DebitoVencido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_debito_vencto"))))
                        reg.Vl_debito_vencto = reader.GetDecimal(reader.GetOrdinal("vl_debito_vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_BLOQCREDITOAVULSO"))))
                        reg.St_bloqcreditoavulso = reader.GetString(reader.GetOrdinal("ST_BLOQCREDITOAVULSO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MOTIVOBLOQAVULSO"))))
                        reg.Ds_motivobloqavulso = reader.GetString(reader.GetOrdinal("DS_MOTIVOBLOQAVULSO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_renovacaocadastro")))
                        reg.Dt_renovacaocadastro = reader.GetDateTime(reader.GetOrdinal("dt_renovacaocadastro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasrenovacaocadastro")))
                        reg.Diasrenovacaocadastro = reader.GetDecimal(reader.GetOrdinal("diasrenovacaocadastro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_atual")))
                        reg.Dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ch_devolvido")))
                        reg.Vl_ch_devolvido = reader.GetDecimal(reader.GetOrdinal("vl_ch_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ch_predatado")))
                        reg.Vl_ch_predatado = reader.GetDecimal(reader.GetOrdinal("vl_ch_predatado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_ConsultaSPC")))
                        reg.Dt_consultaSPC = reader.GetDateTime(reader.GetOrdinal("DT_ConsultaSPC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ConsultaSPC")))
                        reg.Ds_ConsultaSPC = reader.GetString(reader.GetOrdinal("DS_ConsultaSPC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_BloqueioSPC")))
                        reg.St_bloqueiospcbool = reader.GetString(reader.GetOrdinal("ST_BloqueioSPC")).Trim().ToUpper().Equals("S");

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
    }
    #endregion

    #region Liberar Credito
    public class TList_LiberarCredito : List<TRegistro_LiberarCredito>, IComparer<TRegistro_LiberarCredito>
    {

        #region IComparer<TRegistro_LiberarCredito> Members
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

        public TList_LiberarCredito()
        { }

        public TList_LiberarCredito(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LiberarCredito value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LiberarCredito x, TRegistro_LiberarCredito y)
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

    
    public class TRegistro_LiberarCredito
    {
        private decimal? id_solicitacao;
        
        public decimal? Id_solicitacao
        {
            get { return id_solicitacao; }
            set
            {
                id_solicitacao = value;
                id_solicitacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_solicitacaostr;
        
        public string Id_solicitacaostr
        {
            get { return id_solicitacaostr; }
            set
            {
                id_solicitacaostr = value;
                try
                {
                    id_solicitacao = decimal.Parse(value);
                }
                catch
                { id_solicitacao = null; }
            }
        }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Loginbloqueio
        { get; set; }
        
        public string Logindesbloqueio
        { get; set; }
        
        public decimal Vl_compra
        { get; set; }
        private DateTime? dt_solicitacao;
        
        public DateTime? Dt_solicitacao
        {
            get { return dt_solicitacao; }
            set
            {
                dt_solicitacao = value;
                dt_solicitacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_solicitacaostr;
        public string Dt_solicitacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_solicitacaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_solicitacaostr = value;
                try
                {
                    dt_solicitacao = DateTime.Parse(value);
                }
                catch
                { dt_solicitacao = null; }
            }
        }
        private DateTime? dt_liberacao;
        
        public DateTime? Dt_liberacao
        {
            get { return dt_liberacao; }
            set
            {
                dt_liberacao = value;
                dt_liberacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_liberacaostr;
        public string Dt_liberacaostr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_liberacaostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_liberacaostr = value;
                try
                {
                    dt_liberacao = DateTime.Parse(value);
                }
                catch
                { dt_liberacao = null; }
            }
        }
        
        public string Ds_obsbloqueio
        { get; set; }
        
        public string Ds_obsliberacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "AGUARDANDO";
                else if (St_registro.Trim().ToUpper().Equals("P"))
                    return "APROVADA";
                else if (St_registro.Trim().ToUpper().Equals("R"))
                    return "RECUSADA";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CONSUMIDA";
                else return string.Empty;
            }
        }

        public TRegistro_LiberarCredito()
        {
            this.id_solicitacao = null;
            this.id_solicitacaostr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Loginbloqueio = string.Empty;
            this.Logindesbloqueio = string.Empty;
            this.Vl_compra = decimal.Zero;
            this.dt_solicitacao = null;
            this.dt_solicitacaostr = string.Empty;
            this.dt_liberacao = null;
            this.dt_liberacaostr = string.Empty;
            this.Ds_obsbloqueio = string.Empty;
            this.Ds_obsliberacao = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_LiberarCredito : TDataQuery
    {
        public TCD_LiberarCredito()
        { }

        public TCD_LiberarCredito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_Solicitacao, a.CD_Clifor, c.NM_Clifor, ");
                sql.AppendLine("a.LoginBloqueio, a.LoginDesbloqueio, a.Vl_Compra, ");
                sql.AppendLine("a.DT_Solicitacao, a.DT_Liberacao, a.DS_ObsBloqueio, ");
                sql.AppendLine("a.DS_ObsLiberacao, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_LiberarCredito a ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");

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

        public TList_LiberarCredito Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LiberarCredito lista = new TList_LiberarCredito();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(true);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LiberarCredito reg = new TRegistro_LiberarCredito();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Solicitacao")))
                        reg.Id_solicitacao = reader.GetDecimal(reader.GetOrdinal("ID_Solicitacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("LoginBloqueio"))))
                        reg.Loginbloqueio = reader.GetString(reader.GetOrdinal("LoginBloqueio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("LoginDesbloqueio"))))
                        reg.Logindesbloqueio = reader.GetString(reader.GetOrdinal("LoginDesbloqueio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Compra"))))
                        reg.Vl_compra = reader.GetDecimal(reader.GetOrdinal("Vl_Compra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Solicitacao"))))
                        reg.Dt_solicitacao = reader.GetDateTime(reader.GetOrdinal("DT_Solicitacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Liberacao")))
                        reg.Dt_liberacao = reader.GetDateTime(reader.GetOrdinal("DT_Liberacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ObsBloqueio"))))
                        reg.Ds_obsbloqueio = reader.GetString(reader.GetOrdinal("DS_ObsBloqueio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ObsLiberacao"))))
                        reg.Ds_obsliberacao = reader.GetString(reader.GetOrdinal("DS_ObsLiberacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
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

        public string Gravar(TRegistro_LiberarCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_SOLICITACAO", val.Id_solicitacao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_LOGINBLOQUEIO", val.Loginbloqueio);
            hs.Add("@P_LOGINDESBLOQUEIO", val.Logindesbloqueio);
            hs.Add("@P_VL_COMPRA", val.Vl_compra);
            hs.Add("@P_DT_SOLICITACAO", val.Dt_solicitacao);
            hs.Add("@P_DT_LIBERACAO", val.Dt_liberacao);
            hs.Add("@P_DS_OBSBLOQUEIO", val.Ds_obsbloqueio);
            hs.Add("@P_DS_OBSLIBERACAO", val.Ds_obsliberacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_LIBERARCREDITO", hs);
        }

        public string Excluir(TRegistro_LiberarCredito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_SOLICITACAO", val.Id_solicitacao);

            return this.executarProc("EXCLUI_FIN_LIBERARCREDITO", hs);
        }
    }
    #endregion
}
