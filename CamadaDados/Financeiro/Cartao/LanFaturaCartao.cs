using CamadaDados.Financeiro.Caixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Financeiro.Cartao
{
    #region Fatura Cartao
    public class TList_FaturaCartao : List<TRegistro_FaturaCartao>, IComparer<TRegistro_FaturaCartao>
    {
        #region IComparer<TRegistro_FaturaCartao> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_FaturaCartao()
        { }

        public TList_FaturaCartao(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FaturaCartao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FaturaCartao x, TRegistro_FaturaCartao y)
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

    public class TRegistro_FaturaCartao
    {
        public decimal? Id_fatura
        { get; set; }
        private decimal? id_cartao;
        public decimal? Id_cartao
        {
            get { return id_cartao; }
            set
            {
                id_cartao = value;
                id_cartaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartaostr;
        public string Id_cartaostr
        {
            get { return id_cartaostr; }
            set
            {
                id_cartaostr = value;
                try
                {
                    id_cartao = Convert.ToDecimal(value);
                }
                catch
                { id_cartao = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_bandeira;
        public decimal? Id_bandeira
        {
            get { return id_bandeira; }
            set
            {
                id_bandeira = value;
                id_bandeirastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bandeirastr;
        public string Id_bandeirastr
        {
            get { return id_bandeirastr; }
            set
            {
                id_bandeirastr = value;
                try
                {
                    id_bandeira = Convert.ToDecimal(value);
                }
                catch
                { id_bandeira = null; }
            }
        }
        public string Ds_bandeira
        { get; set; }
        private decimal? id_maquina;
        public decimal? Id_maquina
        {
            get { return id_maquina; }
            set
            {
                id_maquina = value;
                id_maquinastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_maquinastr;
        public string Id_maquinastr
        {
            get { return id_maquinastr; }
            set
            {
                id_maquinastr = value;
                try
                {
                    id_maquina = decimal.Parse(value);
                }
                catch { id_maquina = null; }
            }
        }
        public string Ds_maquina { get; set; }
        public decimal Pc_taxa
        { get; set; }
        private string tp_cartao;
        public string Tp_cartao
        {
            get { return tp_cartao; }
            set
            {
                tp_cartao = value;
                tipo_cartao = value.Trim().ToUpper().Equals("D") ? "DEBITO" : value.Trim().ToUpper().Equals("C") ? "CREDITO" : string.Empty;
            }
        }
        private string tipo_cartao;
        public string Tipo_cartao
        {
            get { return tipo_cartao; }
            set
            {
                tipo_cartao = value;
                tp_cartao = value.Trim().ToUpper().Equals("DEBITO") ? "D" : value.Trim().ToUpper().Equals("CREDITO") ? "C" : string.Empty;
            }
        }
        public string Nr_cartao
        { get; set; }
        public string Nomeusuario
        { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_movimento = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBER";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_movimento = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_movimento = "R";
            }
        }
        public decimal Vl_nominal
        { get; set; }
        public decimal Vl_juro
        { get; set; }
        public decimal Vl_fatura
        { get { return Vl_nominal + Vl_juro; } }
        public decimal Vl_taxa
        { get; set; }
        public decimal Vl_liquido
        { get { return Math.Round(Vl_fatura - Vl_taxa, 2); } }
        public decimal Vl_quitado
        { get; set; }
        public decimal Vl_Saldoquitar
        { get { return Math.Round(Vl_liquido - Vl_quitado, 2); } }
        public string Status
        {
            get
            {
                return Vl_Saldoquitar > decimal.Zero ? "ABERTO" : "QUITADO";
            }
        }
        private DateTime? dt_fatura;
        public DateTime? Dt_fatura
        {
            get { return dt_fatura; }
            set
            {
                dt_fatura = value;
                dt_faturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_faturastr;
        public string Dt_faturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_faturastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_faturastr = value;
                try
                {
                    dt_fatura = Convert.ToDateTime(value);
                }
                catch
                { dt_fatura = null; }
            }
        }

        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        public string Nr_autorizacao
        { get; set; }
        public DateTime? Dt_vencto
        { get; set; }
        public string Dt_venctostr
        { get { return Dt_vencto.HasValue ? Dt_vencto.Value.ToString("dd/MM/yyyy") : string.Empty; } }
        public string Cd_contager
        { get; set; }
        public string Cd_historico
        { get; set; }
        public TList_LanCaixa lCaixa
        { get; set; }
        public TList_Quitarfatura lQuitacao
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal? Id_adto
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public string Login
        { get; set; }

        public TRegistro_FaturaCartao()
        {
            Id_fatura = null;
            id_cartao = null;
            id_cartaostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_bandeira = null;
            id_bandeirastr = string.Empty;
            Ds_bandeira = string.Empty;
            id_maquina = null;
            id_maquinastr = string.Empty;
            Ds_maquina = string.Empty;
            Pc_taxa = decimal.Zero;
            Nr_cartao = string.Empty;
            Nomeusuario = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            Vl_nominal = decimal.Zero;
            Vl_juro = decimal.Zero;
            Vl_quitado = decimal.Zero;
            Vl_taxa = decimal.Zero;
            dt_fatura = null;
            dt_faturastr = string.Empty;
            dt_emissao = null;
            dt_emissaostr = string.Empty;
            Nr_autorizacao = string.Empty;
            Dt_vencto = null;
            St_processar = false;
            Cd_contager = string.Empty;
            Cd_historico = string.Empty;
            Id_adto = null;
            Id_cupom = null;
            Login = string.Empty;
            lCaixa = new TList_LanCaixa();
            lQuitacao = new TList_Quitarfatura();
        }
    }

    public class TCD_FaturaCartao : TDataQuery
    {
        public TCD_FaturaCartao()
        { }

        public TCD_FaturaCartao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.ID_Fatura, a.ID_Cartao, a.CD_Empresa, a.cd_contager, ");
                sql.AppendLine("b.NM_Empresa, a.ID_Bandeira, c.DS_Bandeira, a.nr_autorizacao, a.id_maquina, ");
                sql.AppendLine("a.NR_Cartao, a.NomeUsuario, c.TP_Cartao, a.vl_juro, d.pc_taxa, e.ds_maquina, ");
                sql.AppendLine("a.TP_Movimento, a.Vl_Nominal, a.dt_fatura, a.dt_emissao, a.vl_quitado, a.dt_vencto, ");
                sql.AppendLine("vl_taxa = round((a.vl_nominal + a.vl_juro - a.vl_quitado) * (d.pc_taxa / 100), 2), ");
                sql.AppendLine("Id_cupom = isnull((select top 1 x.Id_cupom from TB_PDV_Cupom_X_MovCaixa x ");
                sql.AppendLine("                   inner join TB_FIN_FaturaCartao_X_Caixa y ");
                sql.AppendLine("                   on x.CD_ContaGer = y.CD_ContaGer ");
                sql.AppendLine("                   and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
                sql.AppendLine("                   and y.id_fatura = a.id_fatura), null), ");
                sql.AppendLine("Login = isnull((select top 1 k.Login from TB_PDV_Cupom_X_MovCaixa x ");
                sql.AppendLine("                   inner join TB_PDV_Caixa k ");
                sql.AppendLine("                   on k.id_caixa = x.id_caixa ");
                sql.AppendLine("                   inner join TB_FIN_FaturaCartao_X_Caixa y ");
                sql.AppendLine("                   on x.CD_ContaGer = y.CD_ContaGer ");
                sql.AppendLine("                   and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
                sql.AppendLine("                   and y.id_fatura = a.id_fatura), null) ");


            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_FaturaCartao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_BandeiraCartao c ");
            sql.AppendLine("on a.ID_Bandeira = c.ID_Bandeira ");
            sql.AppendLine("left outer join TB_FIN_TaxaBandeira d ");
            sql.AppendLine("on a.CD_Empresa = d.cd_empresa ");
            sql.AppendLine("and a.ID_Bandeira = d.id_bandeira ");
            sql.AppendLine("and a.ID_Maquina = d.ID_Maquina ");
            sql.AppendLine("left outer join TB_FIN_MaquinaCartao e ");
            sql.AppendLine("on a.id_maquina = e.id_maquina ");
            sql.AppendLine("left outer join TB_FIN_CartaoCredito f ");
            sql.AppendLine("on a.id_cartao = f.id_cartao ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaResumo(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_Bandeira, b.DS_Bandeira, b.TP_Cartao, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_Nominal, 0) - ISNULL(a.vl_quitado, 0)), 0) as Vl_saldo ");

            sql.AppendLine("from VTB_FIN_FATURACARTAO a ");
            sql.AppendLine("inner join TB_FIN_BandeiraCartao b ");
            sql.AppendLine("on a.ID_Bandeira = b.ID_Bandeira ");

            string cond = " where ";

            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("group by a.ID_Bandeira, b.DS_Bandeira, b.TP_Cartao ");
            sql.AppendLine("having SUM(ISNULL(a.Vl_Nominal, 0) - ISNULL(a.vl_quitado, 0)) > 0 ");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_FaturaCartao Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_FaturaCartao lista = new TList_FaturaCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FaturaCartao reg = new TRegistro_FaturaCartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_fatura")))
                        reg.Id_fatura = reader.GetDecimal(reader.GetOrdinal("id_fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        reg.Id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bandeira")))
                        reg.Id_bandeira = reader.GetDecimal(reader.GetOrdinal("id_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bandeira")))
                        reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("ds_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_maquina")))
                        reg.Id_maquina = reader.GetDecimal(reader.GetOrdinal("id_maquina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_maquina")))
                        reg.Ds_maquina = reader.GetString(reader.GetOrdinal("ds_maquina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_taxa")))
                        reg.Pc_taxa = reader.GetDecimal(reader.GetOrdinal("pc_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencto")))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("dt_vencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartao")))
                        reg.Nr_cartao = reader.GetString(reader.GetOrdinal("nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomeusuario")))
                        reg.Nomeusuario = reader.GetString(reader.GetOrdinal("nomeusuario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("tp_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_nominal")))
                        reg.Vl_nominal = reader.GetDecimal(reader.GetOrdinal("vl_nominal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro")))
                        reg.Vl_juro = reader.GetDecimal(reader.GetOrdinal("vl_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_quitado")))
                        reg.Vl_quitado = reader.GetDecimal(reader.GetOrdinal("Vl_quitado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fatura")))
                        reg.Dt_fatura = reader.GetDateTime(reader.GetOrdinal("DT_Fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("Dt_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_autorizacao")))
                        reg.Nr_autorizacao = reader.GetString(reader.GetOrdinal("nr_autorizacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_taxa")))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("vl_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));

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

        public TList_FaturaCartao SelectResumo(Utils.TpBusca[] filtro)
        {
            TList_FaturaCartao lista = new TList_FaturaCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaResumo(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FaturaCartao reg = new TRegistro_FaturaCartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bandeira")))
                        reg.Id_bandeira = reader.GetDecimal(reader.GetOrdinal("id_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bandeira")))
                        reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("ds_bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("tp_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_saldo")))
                        reg.Vl_nominal = reader.GetDecimal(reader.GetOrdinal("vl_saldo"));

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

        public string Gravar(TRegistro_FaturaCartao val)
        {
            Hashtable hs = new Hashtable(12);
            hs.Add("@P_ID_FATURA", val.Id_fatura);
            hs.Add("@P_ID_CARTAO", val.Id_cartao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_BANDEIRA", val.Id_bandeira);
            hs.Add("@P_ID_MAQUINA", val.Id_maquina);
            hs.Add("@P_NR_CARTAO", val.Nr_cartao);
            hs.Add("@P_NOMEUSUARIO", val.Nomeusuario);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_VL_NOMINAL", val.Vl_nominal);
            hs.Add("@P_VL_JURO", val.Vl_juro);
            hs.Add("@P_DT_FATURA", val.Dt_fatura);
            hs.Add("@P_NR_AUTORIZACAO", val.Nr_autorizacao);

            return executarProc("IA_FIN_FATURACARTAO", hs);
        }

        public string Excluir(TRegistro_FaturaCartao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_FATURA", val.Id_fatura);

            return executarProc("EXCLUI_FIN_FATURACARTAO", hs);
        }
    }
    #endregion

    #region Fatura Cartao X Caixa Origem
    public class TList_FaturaCartao_X_Caixa : List<TRegistro_FaturaCartao_X_Caixa>, IComparer<TRegistro_FaturaCartao_X_Caixa>
    {
        #region IComparer<TRegistro_FaturaCartao_X_Caixa> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_FaturaCartao_X_Caixa()
        { }

        public TList_FaturaCartao_X_Caixa(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FaturaCartao_X_Caixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FaturaCartao_X_Caixa x, TRegistro_FaturaCartao_X_Caixa y)
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

    
    public class TRegistro_FaturaCartao_X_Caixa
    {
        private decimal? id_fatura;
        
        public decimal? Id_fatura
        {
            get { return id_fatura; }
            set
            {
                id_fatura = value;
                id_faturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_faturastr;
        
        public string Id_faturastr
        {
            get { return id_faturastr; }
            set
            {
                id_faturastr = value;
                try
                {
                    id_fatura = decimal.Parse(value);
                }
                catch
                { id_fatura = null; }
            }
        }
        
        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }

        public TRegistro_FaturaCartao_X_Caixa()
        {
            id_fatura = null;
            id_faturastr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
        }
    }

    public class TCD_FaturaCartao_X_Caixa : TDataQuery
    {
        public TCD_FaturaCartao_X_Caixa()
        { }

        public TCD_FaturaCartao_X_Caixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" select " + strTop + " a.id_fatura, a.cd_contager, a.cd_lanctocaixa ");
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_FaturaCartao_X_Caixa a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_FaturaCartao_X_Caixa Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_FaturaCartao_X_Caixa lista = new TList_FaturaCartao_X_Caixa();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FaturaCartao_X_Caixa reg = new TRegistro_FaturaCartao_X_Caixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_fatura")))
                        reg.Id_fatura = reader.GetDecimal(reader.GetOrdinal("id_fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));

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

        public string Gravar(TRegistro_FaturaCartao_X_Caixa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_FATURA", val.Id_fatura);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("IA_FIN_FATURACARTAO_X_CAIXA", hs);
        }

        public string Excluir(TRegistro_FaturaCartao_X_Caixa val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_FATURA", val.Id_fatura);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("EXCLUI_FIN_FATURACARTAO_X_CAIXA", hs);
        }
    }
    #endregion

    #region Quitar Fatura
    public class TList_Quitarfatura : List<TRegistro_Quitarfatura>, IComparer<TRegistro_Quitarfatura>
    {
        #region IComparer<TRegistro_Quitarfatura> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Quitarfatura()
        { }

        public TList_Quitarfatura(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Quitarfatura value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Quitarfatura x, TRegistro_Quitarfatura y)
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

    public class TRegistro_Quitarfatura
    {
        private decimal? id_quitar;
        
        public decimal? Id_quitar
        {
            get { return id_quitar; }
            set
            {
                id_quitar = value;
                id_quitarstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_quitarstr;
        
        public string Id_quitarstr
        {
            get { return id_quitarstr; }
            set
            {
                id_quitarstr = value;
                try
                {
                    id_quitar = decimal.Parse(value);
                }
                catch
                { id_quitar = null; }
            }
        }
        private decimal? id_fatura;
        
        public decimal? Id_fatura
        {
            get { return id_fatura; }
            set
            {
                id_fatura = value;
                id_faturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_faturastr;
        
        public string Id_faturastr
        {
            get { return id_faturastr; }
            set
            {
                id_faturastr = value;
                try
                {
                    id_fatura = decimal.Parse(value);
                }
                catch
                { id_fatura = null; }
            }
        }
        
        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }
        
        public string Cd_contagerquit
        { get; set; }
        private decimal? cd_lanctocaixaquit;
        
        public decimal? Cd_lanctocaixaquit
        {
            get { return cd_lanctocaixaquit; }
            set
            {
                cd_lanctocaixaquit = value;
                cd_lanctocaixaquitstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixaquitstr;
        
        public string Cd_lanctocaixaquitstr
        {
            get { return cd_lanctocaixaquitstr; }
            set
            {
                cd_lanctocaixaquitstr = value;
                try
                {
                    cd_lanctocaixaquit = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixaquit = null; }
            }
        }
        private decimal? cd_lanctocaixajuro;
        
        public decimal? Cd_lanctocaixajuro
        {
            get { return cd_lanctocaixajuro; }
            set
            {
                cd_lanctocaixajuro = value;
                cd_lanctocaixajurostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixajurostr;
        
        public string Cd_lanctocaixajurostr
        {
            get { return cd_lanctocaixajurostr; }
            set
            {
                cd_lanctocaixajurostr = value;
                try
                {
                    cd_lanctocaixajuro = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixajuro = null; }
            }
        }
        private decimal? cd_lanctocaixatx;
        
        public decimal? Cd_lanctocaixatx
        {
            get { return cd_lanctocaixatx; }
            set
            {
                cd_lanctocaixatx = value;
                cd_lanctocaixatxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixatxstr;
        
        public string Cd_lanctocaixatxstr
        {
            get { return cd_lanctocaixatxstr; }
            set
            {
                cd_lanctocaixatxstr = value;
                try
                {
                    cd_lanctocaixatx = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixatx = null; }
            }
        }
        private decimal? id_loteCTB;
        public decimal? Id_loteCTB
        {
            get { return id_loteCTB; }
            set
            {
                id_loteCTB = value;
                id_loteCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTBstr;
        public string Id_loteCTBstr
        {
            get { return id_loteCTBstr; }
            set
            {
                id_loteCTBstr = value;
                try
                {
                    id_loteCTB = decimal.Parse(value);
                }catch { id_loteCTB = null; }
            }
        }
        private decimal? id_loteCTB_juro;
        public decimal? Id_loteCTB_Juro
        {
            get { return id_loteCTB_juro; }
            set
            {
                id_loteCTB_juro = value;
                id_loteCTB_jurostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTB_jurostr;
        public string Id_loteCTB_jurostr
        {
            get { return id_loteCTB_jurostr; }
            set
            {
                id_loteCTB_jurostr = value;
                try
                {
                    id_loteCTB_juro = decimal.Parse(value);
                }catch { id_loteCTB_juro = null; }
            }
        }
        private decimal? id_loteCTB_tx;
        public decimal? Id_loteCTB_tx
        {
            get { return id_loteCTB_tx; }
            set
            {
                id_loteCTB_tx = value;
                id_loteCTB_txstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTB_txstr;
        public string Id_loteCTB_txstr
        {
            get { return id_loteCTB_txstr; }
            set
            {
                id_loteCTB_txstr = value;
                try
                {
                    id_loteCTB_tx = decimal.Parse(value);
                }catch { id_loteCTB_tx = null; }
            }
        }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }catch { dt_lancto = null; }
            }
        }
        public decimal Vl_quitado
        { get; set; }
        
        public decimal Vl_juro
        { get; set; }
        
        public decimal Vl_taxa
        { get; set; }
        
        public bool St_estornar
        { get; set; }
        
        public TList_LanCaixa lCaixa
        { get; set; }

        public TRegistro_Quitarfatura()
        {
            id_quitar = null;
            id_quitarstr = string.Empty;
            id_fatura = null;
            id_faturastr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            Cd_contagerquit = string.Empty;
            cd_lanctocaixaquit = null;
            cd_lanctocaixaquitstr = string.Empty;
            cd_lanctocaixajuro = null;
            cd_lanctocaixajurostr = string.Empty;
            cd_lanctocaixatx = null;
            cd_lanctocaixatxstr = string.Empty;
            id_loteCTB = null;
            Id_loteCTBstr = string.Empty;
            id_loteCTB_juro = null;
            id_loteCTB_jurostr = string.Empty;
            id_loteCTB_tx = null;
            Id_loteCTB_txstr = string.Empty;
            dt_lancto = null;
            dt_lanctostr = string.Empty;
            Vl_quitado = decimal.Zero;
            Vl_juro = decimal.Zero;
            Vl_taxa = decimal.Zero;
            St_estornar = false;
            lCaixa = new TList_LanCaixa();
        }
    }

    public class TCD_QuitarFatura : TDataQuery
    {
        public TCD_QuitarFatura()
        { }

        public TCD_QuitarFatura(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select " + strTop + " a.ID_Quitar, a.ID_Fatura, ");
                sql.AppendLine("a.CD_ContaGer, a.CD_LanctoCaixa, a.id_lotectb, a.dt_lancto, ");
                sql.AppendLine("a.id_lotectb_juro, a.id_lotectb_tx, ");
                sql.AppendLine("a.CD_ContaGerQuit, a.CD_LanctoCaixaQuit, ");
                sql.AppendLine("a.CD_LanctoCaixaJuro, a.CD_LanctoCaixaTX, ");
                sql.AppendLine("a.Vl_Quitado, a.Vl_Juro, a.Vl_Taxa ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_QuitarFatura a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_Quitarfatura Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Quitarfatura lista = new TList_Quitarfatura();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Quitarfatura reg = new TRegistro_Quitarfatura();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Quitar")))
                        reg.Id_quitar = reader.GetDecimal(reader.GetOrdinal("id_quitar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_fatura")))
                        reg.Id_fatura = reader.GetDecimal(reader.GetOrdinal("id_fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGerQuit")))
                        reg.Cd_contagerquit = reader.GetString(reader.GetOrdinal("CD_ContaGerQuit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixaQuit")))
                        reg.Cd_lanctocaixaquit = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixaQuit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixaJuro")))
                        reg.Cd_lanctocaixajuro = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixaJuro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixaTX")))
                        reg.Cd_lanctocaixatx = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixaTX"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb_juro")))
                        reg.Id_loteCTB_Juro = reader.GetDecimal(reader.GetOrdinal("id_lotectb_juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb_tx")))
                        reg.Id_loteCTB_tx = reader.GetDecimal(reader.GetOrdinal("id_lotectb_tx"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Quitado")))
                        reg.Vl_quitado = reader.GetDecimal(reader.GetOrdinal("Vl_Quitado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Juro")))
                        reg.Vl_juro = reader.GetDecimal(reader.GetOrdinal("Vl_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Taxa")))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));

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

        public string Gravar(TRegistro_Quitarfatura val)
        {
            Hashtable hs = new Hashtable(15);
            hs.Add("@P_ID_QUITAR", val.Id_quitar);
            hs.Add("@P_ID_FATURA", val.Id_fatura);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGERQUIT", val.Cd_contagerquit);
            hs.Add("@P_CD_LANCTOCAIXAQUIT", val.Cd_lanctocaixaquit);
            hs.Add("@P_CD_LANCTOCAIXAJURO", val.Cd_lanctocaixajuro);
            hs.Add("@P_CD_LANCTOCAIXATX", val.Cd_lanctocaixatx);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);
            hs.Add("@P_ID_LOTECTB_JURO", val.Id_loteCTB_Juro);
            hs.Add("@P_ID_LOTECTB_TX", val.Id_loteCTB_tx);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_VL_QUITADO", val.Vl_quitado);
            hs.Add("@P_VL_JURO", val.Vl_juro);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);

            return executarProc("IA_FIN_QUITARFATURA", hs);
        }

        public string Excluir(TRegistro_Quitarfatura val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_QUITAR", val.Id_quitar);

            return executarProc("EXCLUI_FIN_QUITARFATURA", hs);
        }
    }
    #endregion
}
