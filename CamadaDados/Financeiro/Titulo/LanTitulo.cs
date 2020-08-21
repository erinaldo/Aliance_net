using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using CamadaDados;
using CamadaDados.Financeiro.Caixa;

namespace CamadaDados.Financeiro.Titulo
{    
    #region TITULO
    public class TList_RegLanTitulo : List<TRegistro_LanTitulo>, IComparer<TRegistro_LanTitulo>
    {
        #region IComparer<TRegistro_LanTitulo> Members
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

        public TList_RegLanTitulo()
        { }

        public TList_RegLanTitulo(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanTitulo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }
        
        public int Compare(TRegistro_LanTitulo x, TRegistro_LanTitulo y)
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
    
    public class TRegistro_LanTitulo
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Ds_cidade_empresa
        { get; set; }
        public decimal Nr_lanctocheque
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string Ds_banco
        { get; set; }
        public string Ds_banco_custodia
        { get; set; }
        public string Nr_cheque
        { get; set; }
        public decimal Nr_chequeInt
        { get { return Convert.ToDecimal(Nr_cheque); } }
        public string Nr_cgccpf
        { get; set; }
        private string tp_titulo;
        public string Tp_titulo
        {
            get { return tp_titulo; }
            set 
            { 
                tp_titulo = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_titulo = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_titulo = "RECEBER";
            }
        }
        private string tipo_titulo;
        public string Tipo_titulo
        {
            get { return tipo_titulo; }
            set 
            { 
                tipo_titulo = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_titulo = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_titulo = "R";
            }
        }
        public string Nomebanco
        { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao.HasValue ? DateTime.Parse(dt_emissao.Value.ToString("dd/MM/yyyy")) : dt_emissao; }
            set 
            { 
                dt_emissao = value;
                dt_emissaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_emissaostring;
        public string Dt_emissaostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostring).ToString("dd/MM/yyyy");
                }
                catch { return ""; }
            }
            set 
            { 
                dt_emissaostring = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch { dt_emissao = null; }
            }
        }
        private DateTime? dt_vencto;
        public DateTime? Dt_vencto
        {
            get { return dt_vencto.HasValue ? DateTime.Parse(dt_vencto.Value.ToString("dd/MM/yyyy")) : dt_vencto; }
            set 
            { 
                dt_vencto = value;
                dt_venctostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_venctostring;
        public string Dt_venctostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_venctostring).ToString("dd/MM/yyyy");
                }
                catch { return ""; }
            }
            set 
            { 
                dt_venctostring = value;
                try
                {
                    dt_vencto = Convert.ToDateTime(value);
                }
                catch { dt_vencto = null; }
            }
        }
        private DateTime? dt_compensacao;
        public DateTime? Dt_compensacao
        {
            get { return dt_compensacao.HasValue ? DateTime.Parse(dt_compensacao.Value.ToString("dd/MM/yyyy")) : dt_compensacao; }
            set 
            { 
                dt_compensacao = value;
                dt_compensacaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_compensacaostring;
        public string Dt_compensacaostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_compensacaostring).ToString("dd/MM/yyyy");
                }
                catch { return ""; }
            }
            set 
            { 
                dt_compensacaostring = value;
                try
                {
                    dt_compensacao = Convert.ToDateTime(value);
                }
                catch { dt_compensacao = null; }
            }
        }
        public decimal Vl_titulo
        { get; set; }
        public string Observacao
        { get; set; }
        public string Nomeclifor
        { get; set; }
        public string Fone
        { get; set; }
        public string Nm_clifor_nominal
        { get; set; }
        private string status_compensado;
        public string Status_compensado
        {
            get { return status_compensado; }
            set 
            {
                status_compensado = value;
                if (value.Trim().ToUpper().Equals("S"))
                    st_compensado = "COMPENSADO";
                else if (value.Trim().ToUpper().Equals("N"))
                    st_compensado = "COMPENSAR";
                else if (value.Trim().ToUpper().Equals("D"))
                    st_compensado = "DESCONTADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    st_compensado = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("R"))
                    st_compensado = "REPASSADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    st_compensado = "ENVIADO";
                else if (value.Trim().ToUpper().Equals("V"))
                    st_compensado = "DEVOLVIDO";
                else if (value.Trim().ToUpper().Equals("T"))
                    st_compensado = "CHEQUE TROCO";
                else if (value.Trim().ToUpper().Equals("U"))
                    st_compensado = "CUSTODIADO";
                else if (value.Trim().ToUpper().Equals("L"))
                    st_compensado = "DEPOSITADO";
            }
        }
        private string st_compensado;
        public string St_compensado
        {
            get { return st_compensado; }
            set 
            { 
                st_compensado = value;
                if (value.Trim().ToUpper().Equals("COMPENSADO"))
                    status_compensado = "S";
                else if (value.Trim().ToUpper().Equals("COMPENSAR"))
                    status_compensado = "N";
                else if (value.Trim().ToUpper().Equals("DESCONTADO"))
                    status_compensado = "D";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    status_compensado = "C";
                else if (value.Trim().ToUpper().Equals("REPASSADO"))
                    status_compensado = "R";
                else if (value.Trim().ToUpper().Equals("ENVIADO"))
                    status_compensado = "E";
                else if (value.Trim().ToUpper().Equals("DEVOLVIDO"))
                    status_compensado = "V";
                else if (value.Trim().ToUpper().Equals("CHEQUE TROCO"))
                    status_compensado = "T";
                else if (value.Trim().ToUpper().Equals("CUSTODIADO"))
                    status_compensado = "U";
                else if (value.Trim().ToUpper().Equals("DEPOSITADO"))
                    status_compensado = "L";
            }
        }
        private string st_impresso;
        public string St_impresso
        {
            get { return st_impresso; }
            set 
            { 
                st_impresso = value;
                if (value.Trim().ToUpper().Equals("S"))
                    status_impressao = "SIM";
                else if (value.Trim().ToUpper().Equals("N"))
                    status_impressao = "NAO";
            }
        }
        private string status_impressao;
        public string Status_impressao
        {
            get { return status_impressao; }
            set 
            { 
                status_impressao = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                    st_impresso = "S";
                else if (value.Trim().ToUpper().Equals("NAO"))
                    st_impresso = "N";
            }
        }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Tp_mov
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Nm_contager
        { get; set; }
        public bool St_contaCF
        { get; set; }
        public string Cd_contager_destino
        { get; set; }
        public string Ds_contager_destino
        { get; set; }
        public TList_LanCaixa lCaixa
        { get; set; }
        public bool St_lancarcaixa
        { get; set; }
        public bool St_conciliar
        { get; set; }
        public string ValorExtenso
        {
            get
            {
                if (this.Vl_titulo > 0)
                {
                    return new Utils.Extenso().ValorExtenso(this.Vl_titulo,
                                                            this.Ds_moeda,
                                                            this.Ds_moeda_plural);
                }
                else
                    return string.Empty;
            }
        }
        public string Nm_clifor_origem
        { get; set; }
        public string Nm_clifor_repasse
        { get; set; }
        public TList_DevolucaoCheque lDevolucao
        { get; set; }
        public string Nr_contacorrente
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Ds_moeda_plural
        { get; set; }
        public string Sigla_moeda
        { get; set; }
        public bool St_processar
        { get; set; }
        public decimal? Id_adto
        { get; set; }

        public TRegistro_LanTitulo()
        {
            this.Cd_banco = string.Empty;
            this.Cd_contager = string.Empty;
            this.St_contaCF = false;
            this.Cd_empresa = string.Empty;
            this.Cd_historico = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_banco = string.Empty;
            this.Ds_banco_custodia = string.Empty;
            this.Ds_historico = string.Empty;
            this.Ds_portador = string.Empty;
            this.dt_compensacao = null;
            this.dt_compensacaostring = string.Empty;
            this.dt_emissao = null;
            this.dt_emissaostring = string.Empty;
            this.dt_vencto = null;
            this.dt_venctostring = string.Empty;
            this.Fone = string.Empty;
            this.Nm_contager = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nomebanco = string.Empty;
            this.Nomeclifor = string.Empty;
            this.Nr_cgccpf = string.Empty;
            this.Nr_cheque = string.Empty;
            this.Nr_lanctocheque = decimal.Zero;
            this.Observacao = string.Empty;
            this.st_compensado = "N";
            this.st_impresso = "N";
            this.status_compensado = string.Empty;
            this.status_impressao = string.Empty;
            this.tipo_titulo = string.Empty;
            this.tp_titulo = string.Empty;
            this.Vl_titulo = decimal.Zero;
            this.St_lancarcaixa = false;
            this.St_conciliar = false;
            this.Nm_clifor_nominal = string.Empty;
            this.Nm_clifor_origem = string.Empty;
            this.Nm_clifor_repasse = string.Empty;
            this.Nr_contacorrente = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Ds_moeda_plural = string.Empty;
            this.Sigla_moeda = string.Empty;
            this.Ds_cidade_empresa = string.Empty;
            this.St_processar = false;
            this.Id_adto = null;
            this.lCaixa = new TList_LanCaixa();
            lDevolucao = new TList_DevolucaoCheque();
        }
    }

    public class TCD_LanTitulo : TDataQuery
    {
        public TCD_LanTitulo()
        { }

        public TCD_LanTitulo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vNm_OrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, b.nm_empresa, a.nr_lanctocheque, ");
                sql.AppendLine("a.cd_banco, c.ds_banco, a.nr_cheque, a.nr_cgccpf, a.tp_titulo, a.nm_clifor_nominal, ");
                sql.AppendLine("a.nomebanco, a.dt_emissao, a.dt_vencto, a.dt_compensacao, a.vl_titulo, ");
                sql.AppendLine("a.observacao, a.nomeclifor, a.fone, isNull(a.status_compensado, 'N') as status_compensado, a.st_impresso, ");
                sql.AppendLine("a.cd_portador, d.ds_portador, a.cd_historico, e.ds_historico, e.tp_mov, f.ST_ContaCF, ");
                sql.AppendLine("a.cd_contager, f.ds_contager, a.nr_contacorrente, endEmp.DS_Cidade as DS_Cidade_Empresa, ");
                sql.AppendLine("a.ds_moeda, a.ds_moeda_plural, a.sigla_moeda, ");
                sql.AppendLine("a.nm_clifor_origem, a.nm_clifor_repasse, a.ds_banco_custodia ");

            }
            else
                sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo); 

            sql.AppendLine(" From VTB_FIN_Titulo a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join VTB_FIN_Endereco endEmp ");
            sql.AppendLine("on b.cd_clifor = endEmp.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = endEmp.cd_endereco ");
            sql.AppendLine("inner join TB_FIN_Banco c ");
            sql.AppendLine("on a.cd_banco = c.cd_banco ");
            sql.AppendLine("left outer join TB_FIN_Portador d ");
            sql.AppendLine("on a.cd_portador = d.cd_portador ");
            sql.AppendLine("left outer join TB_FIN_Historico e ");
            sql.AppendLine("on a.cd_historico = e.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_ContaGer f ");
            sql.AppendLine("on a.cd_contager = f.cd_contager ");
            string cond = " Where ";
            if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            if(vNm_OrderBy.Trim() != "")
                sql.AppendLine("Order by " + vNm_OrderBy);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
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

        public TList_RegLanTitulo Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vNm_OrdemBy)
        {
            TList_RegLanTitulo lista = new TList_RegLanTitulo();
            Boolean VCriaBanco = false;
            if (Banco_Dados == null)
                VCriaBanco = CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vNm_OrdemBy));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanTitulo reg = new TRegistro_LanTitulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade_Empresa")))
                        reg.Ds_cidade_empresa = reader.GetString(reader.GetOrdinal("DS_Cidade_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoCheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco_Custodia")))
                        reg.Ds_banco_custodia = reader.GetString(reader.GetOrdinal("DS_Banco_Custodia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Cheque"))))
                        reg.Nr_cheque = reader.GetString(reader.GetOrdinal("NR_Cheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_CGCCPF"))))
                        reg.Nr_cgccpf = reader.GetString(reader.GetOrdinal("Nr_CGCCPF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Titulo"))))
                        reg.Tp_titulo = reader.GetString(reader.GetOrdinal("Tp_Titulo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NomeBanco"))))
                        reg.Nomebanco = reader.GetString(reader.GetOrdinal("NomeBanco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Vencto"))))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Compensacao"))))
                        reg.Dt_compensacao = reader.GetDateTime(reader.GetOrdinal("DT_Compensacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Titulo"))))
                        reg.Vl_titulo = reader.GetDecimal(reader.GetOrdinal("Vl_Titulo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Observacao"))))
                        reg.Observacao = reader.GetString(reader.GetOrdinal("Observacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NomeClifor"))))
                        reg.Nomeclifor = reader.GetString(reader.GetOrdinal("NomeClifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fone"))))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Status_Compensado"))))
                        reg.Status_compensado = reader.GetString(reader.GetOrdinal("Status_Compensado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Impresso"))))
                        reg.St_impresso = reader.GetString(reader.GetOrdinal("ST_Impresso"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("tp_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Nm_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_contaCF")))
                        reg.St_contaCF = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("st_contaCF"))).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor_Nominal")))
                        reg.Nm_clifor_nominal = reader.GetString(reader.GetOrdinal("NM_Clifor_Nominal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor_Origem")))
                        reg.Nm_clifor_origem = reader.GetString(reader.GetOrdinal("NM_Clifor_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor_Repasse")))
                        reg.Nm_clifor_repasse = reader.GetString(reader.GetOrdinal("NM_Clifor_Repasse"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ContaCorrente")))
                        reg.Nr_contacorrente = reader.GetString(reader.GetOrdinal("NR_ContaCorrente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Plural")))
                        reg.Ds_moeda_plural = reader.GetString(reader.GetOrdinal("DS_Moeda_Plural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_moeda")))
                        reg.Sigla_moeda = reader.GetString(reader.GetOrdinal("sigla_moeda"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (VCriaBanco)
                    deletarBanco_Dados();
            }
            return lista;        
        }

        public string GravaTitulo(TRegistro_LanTitulo val)
        {
            Hashtable hs = new Hashtable(19);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_NR_CHEQUE", val.Nr_cheque);
            hs.Add("@P_NR_CGCCPF", val.Nr_cgccpf);
            hs.Add("@P_TP_TITULO", val.Tp_titulo);
            hs.Add("@P_NOMEBANCO", val.Nomebanco);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_VENCTO", val.Dt_vencto);
            hs.Add("@P_DT_COMPENSACAO", val.Dt_compensacao);
            hs.Add("@P_VL_TITULO", val.Vl_titulo);
            hs.Add("@P_OBSERVACAO", val.Observacao);
            hs.Add("@P_NOMECLIFOR", val.Nomeclifor);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_STATUS_COMPENSADO", val.Status_compensado);
            hs.Add("@P_ST_IMPRESSO", val.St_impresso);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_NM_CLIFOR_NOMINAL", val.Nm_clifor_nominal);

            return this.executarProc("IA_FIN_TITULO", hs);
        }

        public string DeletaTitulo(TRegistro_LanTitulo val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FIN_TITULO", hs);
        }
    }
    #endregion
    
    #region TITULO X CAIXA
    public class TList_RegLanTituloXCaixa : List<TRegistro_LanTituloXCaixa>
    { }
    
    public class TRegistro_LanTituloXCaixa
    {
        private string cd_empresa;
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }
        private string cd_contager;
        public string Cd_contager
        {
            get { return cd_contager; }
            set { cd_contager = value; }
        }
        private decimal cd_lanctocaixa;
        public decimal Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set { cd_lanctocaixa = value; }
        }
        private string cd_banco;
        public string Cd_banco
        {
            get { return cd_banco; }
            set { cd_banco = value; }
        }
        private decimal nr_lanctocheque;
        public decimal Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set { nr_lanctocheque = value; }
        }
        public string Tp_caixa
        { get; set; }
        private string tp_lancto;
        public string Tp_lancto
        {
            get { return tp_lancto; }
            set
            {
                tp_lancto = value;
                if (value.Trim().ToUpper().Equals("OR"))
                    tipo_lancto = "ORIGEM";
                else if (value.Trim().ToUpper().Equals("CP"))
                    tipo_lancto = "COMPENSAÇÃO";
            }
        }
        private string tipo_lancto;
        public string Tipo_lancto
        {
            get { return tipo_lancto; }
            set
            {
                tipo_lancto = value;
                if (value.Trim().ToUpper().Equals("ORIGEM"))
                    tp_lancto = "OR";
                else if (value.Trim().ToUpper().Equals("COMPENSAÇÃO"))
                    tp_lancto = "CP";
            }
        }
        
        public TRegistro_LanTituloXCaixa()
        {
            this.cd_empresa = string.Empty;
            this.cd_contager = string.Empty;
            this.cd_lanctocaixa = decimal.Zero;
            this.cd_banco = string.Empty;
            this.nr_lanctocheque = decimal.Zero;
            this.Tp_caixa = string.Empty;
            this.Tp_lancto = string.Empty;
            this.Tipo_lancto = string.Empty;
        }
    }

    public class TCD_TituloXCaixa : TDataQuery
    {
        public TCD_TituloXCaixa()
        { }

        public TCD_TituloXCaixa(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, a.CD_ContaGer, a.CD_LanctoCaixa, a.cd_banco, a.Nr_LanctoCheque, a.tp_lancto ");
            else
            { sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo); }
            sql.AppendLine(" From TB_FIN_Titulo_X_caixa a ");
            string cond = " Where ";
            if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }
        
        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_RegLanTituloXCaixa Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_RegLanTituloXCaixa lista = new TList_RegLanTituloXCaixa();
            Boolean VCriaBanco = false;
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                VCriaBanco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanTituloXCaixa reg = new TRegistro_LanTituloXCaixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa"))))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Lancto")))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (VCriaBanco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        //grava
        public string GravaTituloXCaixa(TRegistro_LanTituloXCaixa val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_TP_CAIXA", val.Tp_caixa);
            hs.Add("@P_TP_LANCTO", val.Tp_lancto);

            return this.executarProc("IA_FIN_TITULO_X_CAIXA", hs);
        }

        public string DeletaTituloXCaixa(TRegistro_LanTituloXCaixa val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            return this.executarProc("EXCLUI_FIN_TITULO_X_CAIXA", hs);
        }

        public DataTable Integracao_Cheque_Caixa(string vCD_ContaGer, decimal vCD_LanctoCaixa)
        {
            StringBuilder SQL = new StringBuilder();
            Hashtable param = new Hashtable();

            SQL.AppendLine(" SELECT  A.CD_EMPRESA, A.NR_LANCTOCHEQUE, A.CD_BANCO, A.NR_CHEQUE, A.TP_TITULO, A.DT_EMISSAO, ");
            SQL.AppendLine(" A.DT_VENCTO, A.DT_COMPENSACAO, A.VL_TITULO, A.OBSERVACAO, A.NOMECLIFOR, A.FONE, A.STATUS_COMPENSADO ");
            SQL.AppendLine(" FROM  TB_FIN_TITULO A JOIN TB_FIN_TITULO_X_CAIXA B ON A.CD_EMPRESA = B.CD_EMPRESA");
            SQL.AppendLine("   AND A.NR_LANCTOCHEQUE = B.NR_LANCTOCHEQUE AND A.CD_BANCO = B.CD_BANCO ");
            SQL.AppendLine(" WHERE B.CD_CONTAGER = @CD_CONTAGER ");
            SQL.AppendLine("   AND B.CD_LANCTOCAIXA = @CD_LANCTOCAIXA ");

            param.Add("@CD_CONTAGER", vCD_ContaGer);
            param.Add("@CD_LANCTOCAIXA", vCD_LanctoCaixa);

            return ExecutarBusca(SQL.ToString(), param);
        }
    }
    #endregion

    #region Titulo X Liquidação
    public class TList_Titulo_x_Liquidacao : List<TRegistro_Titulo_x_Liquidacao>
    { }

    public class TRegistro_Titulo_x_Liquidacao
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_banco
        { get; set; }
        private decimal? nr_lanctocheque;
        public decimal? Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set
            {
                nr_lanctocheque = value;
                nr_lanctochequestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctochequestr;
        public string Nr_lanctochequestr
        {
            get { return nr_lanctochequestr; }
            set
            {
                nr_lanctochequestr = value;
                try
                {
                    nr_lanctocheque = decimal.Parse(value);
                }
                catch { nr_lanctocheque = null; }
            }
        }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch { cd_parcela = null; }
            }
        }
        private decimal? id_liquid;
        public decimal? Id_liquid
        {
            get { return id_liquid; }
            set
            {
                id_liquid = value;
                id_liquidstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_liquidstr;
        public string Id_liquidstr
        {
            get { return id_liquidstr; }
            set
            {
                id_liquidstr = value;
                try
                {
                    id_liquid = decimal.Parse(value);
                }
                catch { id_liquid = null; }
            }
        }

        public TRegistro_Titulo_x_Liquidacao()
        {
            this.Cd_empresa = string.Empty;
            this.Cd_banco = string.Empty;
            this.nr_lanctocheque = null;
            this.nr_lanctochequestr = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
            this.cd_parcela = null;
            this.cd_parcelastr = string.Empty;
            this.id_liquid = null;
            this.id_liquidstr = string.Empty;
        }
    }

    public class TCD_Titulo_x_Liquidacao : TDataQuery
    {
        public TCD_Titulo_x_Liquidacao() { }

        public TCD_Titulo_x_Liquidacao(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, a.NR_LanctoCheque, ");
                sql.AppendLine("a.CD_Banco, a.NR_Lancto, a.CD_Parcela, a.ID_Liquid ");
            }
            else
            { sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo); }
            sql.AppendLine(" From TB_FIN_Titulo_X_Liquidacao a ");
            string cond = " Where ";
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Titulo_x_Liquidacao Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Titulo_x_Liquidacao lista = new TList_Titulo_x_Liquidacao();
            Boolean VCriaBanco = false;
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                VCriaBanco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Titulo_x_Liquidacao reg = new TRegistro_Titulo_x_Liquidacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (VCriaBanco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Titulo_x_Liquidacao val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return this.executarProc("IA_FIN_TITULO_X_LIQUIDACAO", hs);
        }

        public string Excluir(TRegistro_Titulo_x_Liquidacao val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return this.executarProc("EXCLUI_FIN_TITULO_X_LIQUIDACAO", hs);
        }
    }
    #endregion

    #region TRANSFERE TITULO
    public class TList_TransfTitulo : List<TRegistro_TransfTitulo>
    { }
    
    public class TRegistro_TransfTitulo
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_conta_orig
        { get; set; }
        public string Cd_conta_dest
        { get; set; }
        public decimal Cd_lanctocaixa_orig
        { get; set; }
        public decimal Cd_lanctocaixa_dest
        { get; set; }
        public decimal Nr_lanctocheque
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string St_compensacao
        { get; set; }

        public TRegistro_TransfTitulo()
        {
            this.Cd_empresa = string.Empty;
            this.Cd_conta_orig = string.Empty;
            this.Cd_conta_dest = string.Empty;
            this.Cd_lanctocaixa_orig = decimal.Zero;
            this.Cd_lanctocaixa_dest = decimal.Zero;
            this.Nr_lanctocheque = decimal.Zero;
            this.Cd_banco = string.Empty;
            this.St_compensacao = "N";
        }
    }

    public class TCD_TransfTitulo : TDataQuery
    {
        public TCD_TransfTitulo()
        { }

        public TCD_TransfTitulo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.cd_contaorig, a.cd_lanctocaixaorig, ");
                sql.AppendLine("a.cd_contadest, a.cd_lanctocaixadest, a.nr_lanctocheque, a.cd_banco, a.st_compensacao ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo);

            sql.AppendLine("From TB_FIN_Transfere_Titulo a ");
            sql.AppendLine("inner join TB_FIN_Caixa b ");
            sql.AppendLine("on a.cd_contaorig = b.cd_contager ");
            sql.AppendLine("and a.cd_lanctocaixaorig = b.cd_lanctocaixa ");
            sql.AppendLine("inner join TB_FIN_Caixa c ");
            sql.AppendLine("on a.cd_contadest = c.cd_contager ");
            sql.AppendLine("and a.cd_lanctocaixadest = c.cd_lanctocaixa ");
            string cond = " Where ";
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

        public TList_TransfTitulo Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            Boolean VCriaBanco = false;
            if (Banco_Dados == null)
                VCriaBanco = CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            TList_TransfTitulo lista = new TList_TransfTitulo();
            try
            {
                while (reader.Read())
                {
                    TRegistro_TransfTitulo reg = new TRegistro_TransfTitulo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_contaorig"))))
                        reg.Cd_conta_orig = reader.GetString(reader.GetOrdinal("cd_contaorig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixaorig"))))
                        reg.Cd_lanctocaixa_orig = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixaorig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_contadest"))))
                        reg.Cd_conta_dest = reader.GetString(reader.GetOrdinal("cd_contadest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixadest"))))
                        reg.Cd_lanctocaixa_dest = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixadest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_compensacao")))
                        reg.St_compensacao = reader.GetString(reader.GetOrdinal("st_compensacao"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (VCriaBanco)
                {
                    deletarBanco_Dados();
                }
            }
            return lista;
        }

        public string GravarTransfTitulo(TRegistro_TransfTitulo val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONTAORIG", val.Cd_conta_orig);
            hs.Add("@P_CD_LANCTOCAIXAORIG", val.Cd_lanctocaixa_orig);
            hs.Add("@P_CD_CONTADEST", val.Cd_conta_dest);
            hs.Add("@P_CD_LANCTOCAIXADEST", val.Cd_lanctocaixa_dest);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ST_COMPENSACAO", val.St_compensacao);
            return this.executarProc("IA_FIN_TRANSFERE_TITULO", hs);
        }

        public string DeletarTransfTitulo(TRegistro_TransfTitulo val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CONTAORIG", val.Cd_conta_orig);
            hs.Add("@P_CD_LANCTOCAIXAORIG", val.Cd_lanctocaixa_orig);
            hs.Add("@P_CD_CONTADEST", val.Cd_conta_dest);
            hs.Add("@P_CD_LANCTOCAIXADEST", val.Cd_lanctocaixa_dest);
            return this.executarProc("DELETE_FIN_TRANSFERE_TITULO", hs);
        }
    }
    #endregion

    #region Gerar Credito
    public class TList_CreditoTitulo : List<TRegistro_CreditoTitulo>
    { }
    
    public class TRegistro_CreditoTitulo
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public decimal? Nr_lanctocheque
        { get; set; }
        public string Nr_cheque
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string Ds_banco
        { get; set; }
        public string Cd_contagercredito
        { get; set; }
        public string Ds_contagercredito
        { get; set; }
        public string Cd_empresacredito
        { get; set; }
        public string Nm_empresacredito
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string CompHistorico
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal Vl_titulo
        { get; set; }

        public TRegistro_CreditoTitulo()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Nr_lanctocheque = null;
            this.Nr_cheque = string.Empty;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.Cd_contagercredito = string.Empty;
            this.Ds_contagercredito = string.Empty;
            this.Cd_empresacredito = string.Empty;
            this.Nm_empresacredito = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_historico = string.Empty;
            this.CompHistorico = string.Empty;
            this.dt_lancto = null;
            this.dt_lanctostr = string.Empty;
            this.Vl_titulo = decimal.Zero;
        }
    }
    #endregion

    #region RASTREAR CHEQUE TERCEIRO
    public class TList_Rastreab_ChTerceiro : List<TRegistro_Rastreab_ChTerceiro>
    { }
    
    public class TRegistro_Rastreab_ChTerceiro
    {
        public string Cd_clifor_origem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lanctocheque
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string Cd_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
        { get; set; }
        public string Tp_registro
        { get; set; }

        public TRegistro_Rastreab_ChTerceiro()
        {
            this.Cd_clifor_origem = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctocheque = decimal.Zero;
            this.Cd_banco = string.Empty;
            this.Cd_contager = string.Empty;
            this.Cd_lanctocaixa = null;
            this.Tp_registro = string.Empty;
        }
    }

    public class TCD_Rastreab_ChTerceiro : TDataQuery
    {
        public TCD_Rastreab_ChTerceiro()
        {}

        public TCD_Rastreab_ChTerceiro(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_clifor_origem, a.cd_empresa, ");
                sql.AppendLine("a.nr_lanctocheque, a.cd_banco, a.tp_registro, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa ");
            }
            else
            { sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo); }
            sql.AppendLine(" From TB_FIN_Rastreab_ChTerceiro a ");
            string cond = " Where ";
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

        public TList_Rastreab_ChTerceiro Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            TList_Rastreab_ChTerceiro lista = new TList_Rastreab_ChTerceiro();
            try
            {
                while (reader.Read())
                {
                    TRegistro_Rastreab_ChTerceiro reg = new TRegistro_Rastreab_ChTerceiro();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor_Origem"))))
                        reg.Cd_clifor_origem = reader.GetString(reader.GetOrdinal("CD_Clifor_Origem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            return lista;
        }

        public string GravarRastreab_ChTerceiro(TRegistro_Rastreab_ChTerceiro val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_CLIFOR_ORIGEM", val.Cd_clifor_origem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);

            return this.executarProc("IA_FIN_RASTREAB_CHTERCEIRO", hs);
        }

        public string DeletarRastreab_ChTerceiro(TRegistro_Rastreab_ChTerceiro val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CLIFOR_ORIGEM", val.Cd_clifor_origem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FIN_RASTREAB_CHTERCEIRO", hs);
        }
    }
    #endregion
}
