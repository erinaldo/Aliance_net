using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Balanca
{
    public class TList_PesagemAvulsa : List<TRegistro_PesagemAvulsa>, IComparer<TRegistro_PesagemAvulsa>
    {
        #region IComparer<TRegistro_PesagemAvulsa> Members
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

        public TList_PesagemAvulsa()
        { }

        public TList_PesagemAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PesagemAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PesagemAvulsa x, TRegistro_PesagemAvulsa y)
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

    public class TRegistro_PesagemAvulsa : IPesagem
    {
        #region IPesagem Members
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        private decimal? id_ticket;
        public decimal? Id_ticket
        {
            get { return id_ticket; }
            set
            {
                id_ticket = value;
                id_ticketstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticketstr;
        public string Id_ticketstr
        {
            get { return id_ticketstr; }
            set
            {
                id_ticketstr = value;
                try
                {
                    id_ticket = decimal.Parse(value);
                }
                catch { id_ticket = null; }
            }
        }
        public string Tp_pesagem { get; set; }
        public string Nm_tppesagem { get; set; }
        public string Tp_modo { get; set; }
        private decimal? id_ticketorig;
        public decimal? Id_ticketorig
        {
            get { return id_ticketorig; }
            set
            {
                id_ticketorig = value;
                id_ticketorigstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticketorigstr;
        public string Id_ticketorigstr
        {
            get { return id_ticketorigstr; }
            set
            {
                id_ticketorigstr = value;
                try
                {
                    id_ticketorig = decimal.Parse(value);
                }
                catch { id_ticketorig = null; }
            }
        }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        public string Placacarreta { get; set; }
        public string Placacavalo { get; set; }
        private DateTime? dt_bruto;
        public DateTime? Dt_bruto
        {
            get { return dt_bruto; }
            set
            {
                dt_bruto = value;
                dt_brutostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_brutostring;
        public string Dt_brutostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_brutostring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_brutostring = value;
                try
                {
                    dt_bruto = Convert.ToDateTime(value);
                }
                catch
                { dt_bruto = null; }
            }
        }
        private DateTime? dt_tara;
        public DateTime? Dt_tara
        {
            get { return dt_tara; }
            set
            {
                dt_tara = value;
                dt_tarastring = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_tarastring;
        public string Dt_tarastring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_tarastring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_tarastring = value;
                try
                {
                    dt_tara = Convert.ToDateTime(value);
                }
                catch
                { dt_tara = null; }
            }
        }
        public TimeSpan? Dt_permanenciaveiculo
        {
            get
            {
                if ((this.dt_tara != null) && (this.dt_bruto != null))
                    if (this.tp_movimento.Trim().ToUpper().Equals("E"))
                        return this.dt_tara.Value.Subtract(this.dt_bruto.Value);
                    else if (this.tp_movimento.Trim().ToUpper().Equals("S"))
                        return this.dt_bruto.Value.Subtract(this.dt_tara.Value);
                    else
                        return null;
                else
                    return null;
            }
        }
        public string Dt_permanenciaveiculostr
        {
            get
            {
                return (this.Dt_permanenciaveiculo.HasValue ? (this.Dt_permanenciaveiculo.Value.Days > 0 ? this.Dt_permanenciaveiculo.Value.Days.ToString() + " Dias" : string.Empty) +
                                (this.Dt_permanenciaveiculo.Value.Hours > 0 ? this.Dt_permanenciaveiculo.Value.Hours.ToString() + " Hr " : string.Empty) +
                                (this.Dt_permanenciaveiculo.Value.Minutes > 0 ? this.Dt_permanenciaveiculo.Value.Minutes.ToString() + " Mn " : string.Empty) +
                                (this.Dt_permanenciaveiculo.Value.Seconds > 0 ? this.Dt_permanenciaveiculo.Value.Seconds.ToString() + " Sg" : string.Empty) : "");
            }
        }
        public decimal Ps_bruto { get; set; }
        public decimal Ps_tara { get; set; }
        private decimal ps_liquido;
        public decimal Ps_liquido
        {
            get { return Math.Round(ps_liquido, 0); }
            set { ps_liquido = Math.Round(value, 0); }
        }
        public decimal Ps_liquidobruto
        {
            get { return Ps_bruto - Ps_tara; }
        }
        public string Ps_liqSacas
        {
            get
            {
                if (this.ps_liquido > decimal.Zero)
                {
                    string aux = Math.Floor(this.ps_liquido / 60).ToString() + " Sacas(60Kg)";
                    if ((this.ps_liquido % 60) > 0)
                        aux += " e " + (this.ps_liquido % 60).ToString() + "Kg";
                    return aux;
                }
                else
                    return string.Empty;
            }
        }
        public string Cd_transp { get; set; }
        public string Login_pstara { get; set; }
        public string Login_psbruto { get; set; }
        public string Cd_tpveiculo { get; set; }
        public string Ds_tpveiculo { get; set; }
        public string Nm_motorista { get; set; }
        public string Cpf_cnpj_mot { get; set; }
        private string tp_captura_bruto;
        public string Tp_captura_bruto
        {
            get { return tp_captura_bruto; }
            set
            {
                tp_captura_bruto = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_captura_bruto = "AUTOMATICO";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_captura_bruto = "MANUAL";
            }
        }
        private string tipo_captura_bruto;
        public string Tipo_captura_bruto
        {
            get { return tipo_captura_bruto; }
            set
            {
                tipo_captura_bruto = value;
                if (value.Trim().ToUpper().Equals("AUTOMATICO"))
                    tp_captura_bruto = "A";
                else if (value.Trim().ToUpper().Equals("MANUAL"))
                    tp_captura_bruto = "M";
            }
        }
        private string tp_captura_tara;
        public string Tp_captura_tara
        {
            get { return tp_captura_tara; }
            set
            {
                tp_captura_tara = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_captura_tara = "AUTOMATICO";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_captura_tara = "MANUAL";
            }
        }
        private string tipo_captura_tara;
        public string Tipo_captura_tara
        {
            get { return tipo_captura_tara; }
            set
            {
                tipo_captura_tara = value;
                if (value.Trim().ToUpper().Equals("AUTOMATICO"))
                    tp_captura_tara = "A";
                else if (value.Trim().ToUpper().Equals("MANUAL"))
                    tp_captura_tara = "M";
            }
        }
        public decimal Qtd_embalagem { get; set; }
        public decimal Ps_embalagem { get; set; }
        public decimal Ps_totalembalagem
        {
            get { return Math.Round(Qtd_embalagem * Ps_embalagem, 0); }
        }
        public string Ds_observacao { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("F"))
                    status = "FECHADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "REFUGADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("FECHADO"))
                    st_registro = "F";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("REFUGADO"))
                    St_registro = "R";
            }
        }
        private string tp_transbordo;
        public string Tp_transbordo
        {
            get { return tp_transbordo; }
            set
            {
                tp_transbordo = value;
                tp_transbordobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool tp_transbordobool;
        public bool Tp_transbordobool
        {
            get { return tp_transbordobool; }
            set
            {
                tp_transbordobool = value;
                if (value)
                    tp_transbordo = "S";
                else
                    tp_transbordo = "N";
            }
        }
        public decimal Ps_transbordo
        { get; set; }
        public decimal Ps_saldotransbordo
        {
            get
            {
                return Ps_liquido - Ps_transbordo;
            }
        }
        public bool St_processarTicketRef
        { get; set; }
        public string Ds_motivocancelamento
        { get; set; }
        public TList_FotosPesagem lFotosPesagem
        { get; set; }
        public TList_FotosPesagem lFotosPesagemExcluir
        { get; set; }

        #endregion

        public string Cnpjempresa
        { get; set; }
        public string Ds_enderecoempresa
        { get; set; }
        public string Numeroempresa
        { get; set; }
        public string Bairroempresa
        { get; set; }
        public string Ds_cidadeempresa
        { get; set; }
        public string Ufempresa
        { get; set; }
        public string Foneempresa
        { get; set; }
        public string Ds_carga
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public decimal Vl_taxa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public string St_financeiro
        { get; set; }

        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc
        { get; set; }

        public TRegistro_PesagemAvulsa()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_ticket = null;
            this.id_ticketstr = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.Nm_tppesagem = string.Empty;
            this.Tp_modo = string.Empty;
            this.id_ticketorig = null;
            this.id_ticketorigstr = string.Empty;
            this.tp_movimento = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Placacarreta = string.Empty;
            this.Placacavalo = string.Empty;
            this.dt_bruto = null;
            this.dt_brutostring = string.Empty;
            this.dt_tara = null;
            this.dt_tarastring = string.Empty;
            this.Ps_bruto = decimal.Zero;
            this.Ps_tara = decimal.Zero;
            this.ps_liquido = decimal.Zero;
            this.Cd_transp = string.Empty;
            this.Login_pstara = string.Empty;
            this.Login_psbruto = string.Empty;
            this.Cd_tpveiculo = string.Empty;
            this.Ds_tpveiculo = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Cpf_cnpj_mot = string.Empty;
            this.tp_captura_bruto = string.Empty;
            this.tipo_captura_bruto = string.Empty;
            this.tp_captura_tara = string.Empty;
            this.tipo_captura_tara = string.Empty;
            this.Qtd_embalagem = decimal.Zero;
            this.Ps_embalagem = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.tp_transbordo = "N";
            this.tp_transbordobool = false;
            this.Ps_transbordo = decimal.Zero;
            this.St_processarTicketRef = false;
            this.Ds_motivocancelamento = string.Empty;
            this.lFotosPesagem = new TList_FotosPesagem();
            this.lFotosPesagemExcluir = new TList_FotosPesagem();

            this.Cnpjempresa = string.Empty;
            this.Ds_enderecoempresa = string.Empty;
            this.Numeroempresa = string.Empty;
            this.Bairroempresa = string.Empty;
            this.Ds_cidadeempresa = string.Empty;
            this.Ufempresa = string.Empty;
            this.Foneempresa = string.Empty;
            this.Ds_carga = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Vl_taxa = decimal.Zero;
            this.Nr_lancto = null;
            this.St_financeiro = string.Empty;
            this.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lParc = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
        }
    }

    public class TCD_PesagemAvulsa : TDataQuery
    {
        public TCD_PesagemAvulsa()
        { }

        public TCD_PesagemAvulsa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.nm_empresa, a.ID_Ticket, ");
                sql.AppendLine("a.Tp_Pesagem, c.nm_tppesagem, c.tp_modo, a.ds_carga, ");
                sql.AppendLine("a.Id_TicketOrig, a.TP_Movimento, a.PlacaCarreta, ");
                sql.AppendLine("a.PlacaCavalo, a.DT_Bruto, a.Cpf_cnpj_mot, ");
                sql.AppendLine("a.DT_Tara, a.PS_Bruto, a.PS_Tara, a.CD_Transp, ");
                sql.AppendLine("a.Login_PsBruto, a.Login_PsTara, a.CD_TpVeiculo, ");
                sql.AppendLine("a.NM_Motorista, a.Tp_Captura_Bruto, a.Tp_Captura_Tara, ");
                sql.AppendLine("a.QTD_Embalagem, a.Ps_Embalagem, ");
                sql.AppendLine("a.DS_Observacao, a.ST_Registro, a.CD_Clifor, ");
                sql.AppendLine("a.NM_Clifor, a.Vl_Taxa, a.st_registro, a.nr_lancto, ");
                sql.AppendLine("ps_liquido = (a.ps_bruto - a.ps_tara), a.st_financeiro, ");
                sql.AppendLine("cemp.nr_cgc, eemp.ds_endereco, eemp.numero, ");
                sql.AppendLine("eemp.bairro, eemp.ds_cidade, eemp.uf, eemp.fone ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_BAL_PSAVULSA a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor cemp ");
            sql.AppendLine("on b.cd_clifor = cemp.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco eemp ");
            sql.AppendLine("on b.cd_clifor = eemp.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = eemp.cd_endereco ");
            sql.AppendLine("inner join tb_bal_tppesagem c ");
            sql.AppendLine("on a.tp_pesagem = c.tp_pesagem ");

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

        public TList_PesagemAvulsa Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_PesagemAvulsa lista = new TList_PesagemAvulsa();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PesagemAvulsa reg = new TRegistro_PesagemAvulsa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpjempresa = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_enderecoempresa = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
                        reg.Numeroempresa = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
                        reg.Bairroempresa = reader.GetString(reader.GetOrdinal("Bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.Ds_cidadeempresa = reader.GetString(reader.GetOrdinal("DS_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Ufempresa = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone")))
                        reg.Foneempresa = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Modo"))))
                        reg.Tp_modo = reader.GetString(reader.GetOrdinal("Tp_Modo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_TPPesagem"))))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TPPesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TicketOrig"))))
                        reg.Id_ticketorig = reader.GetDecimal(reader.GetOrdinal("ID_TicketOrig"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PlacaCarreta"))))
                        reg.Placacarreta = reader.GetString(reader.GetOrdinal("PlacaCarreta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PlacaCavalo"))))
                        reg.Placacavalo = reader.GetString(reader.GetOrdinal("PlacaCavalo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Bruto"))))
                        reg.Dt_bruto = reader.GetDateTime(reader.GetOrdinal("DT_Bruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Tara"))))
                        reg.Dt_tara = reader.GetDateTime(reader.GetOrdinal("DT_Tara"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Bruto"))))
                        reg.Ps_bruto = reader.GetDecimal(reader.GetOrdinal("PS_Bruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Tara"))))
                        reg.Ps_tara = reader.GetDecimal(reader.GetOrdinal("PS_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_liquido")))
                        reg.Ps_liquido = reader.GetDecimal(reader.GetOrdinal("ps_liquido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Transp"))))
                        reg.Cd_transp = reader.GetString(reader.GetOrdinal("CD_Transp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_PsTara"))))
                        reg.Login_pstara = reader.GetString(reader.GetOrdinal("Login_PsTara"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_PsBruto"))))
                        reg.Login_psbruto = reader.GetString(reader.GetOrdinal("Login_PsBruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo"))))
                        reg.Cd_tpveiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Motorista"))))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cpf_cnpj_mot")))
                        reg.Cpf_cnpj_mot = reader.GetString(reader.GetOrdinal("cpf_cnpj_mot"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Captura_Bruto"))))
                        reg.Tp_captura_bruto = reader.GetString(reader.GetOrdinal("TP_Captura_Bruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Captura_Tara"))))
                        reg.Tp_captura_tara = reader.GetString(reader.GetOrdinal("TP_Captura_Tara"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Embalagem"))))
                        reg.Qtd_embalagem = reader.GetDecimal(reader.GetOrdinal("QTD_Embalagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Embalagem"))))
                        reg.Ps_embalagem = reader.GetDecimal(reader.GetOrdinal("PS_Embalagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Taxa")))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Carga")))
                        reg.Ds_carga = reader.GetString(reader.GetOrdinal("DS_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_financeiro")))
                        reg.St_financeiro = reader.GetString(reader.GetOrdinal("st_financeiro"));

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

        public string Gravar(TRegistro_PesagemAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(28);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_TICKETORIG", val.Id_ticketorig);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_PLACACARRETA", val.Placacarreta);
            hs.Add("@P_PLACACAVALO", val.Placacavalo);
            hs.Add("@P_DT_BRUTO", val.Dt_bruto);
            hs.Add("@P_DT_TARA", val.Dt_tara);
            hs.Add("@P_PS_BRUTO", val.Ps_bruto);
            hs.Add("@P_PS_TARA", val.Ps_tara);
            hs.Add("@P_CD_TRANSP", val.Cd_transp);
            hs.Add("@P_LOGIN_PSTARA", val.Login_pstara);
            hs.Add("@P_LOGIN_PSBRUTO", val.Login_psbruto);
            hs.Add("@P_CD_TPVEICULO", val.Cd_tpveiculo);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_CPF_CNPJ_MOT", val.Cpf_cnpj_mot);
            hs.Add("@P_TP_CAPTURA_BRUTO", val.Tp_captura_bruto);
            hs.Add("@P_TP_CAPTURA_TARA", val.Tp_captura_tara);
            hs.Add("@P_QTD_EMBALAGEM", val.Qtd_embalagem);
            hs.Add("@P_PS_EMBALAGEM", val.Ps_embalagem);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DS_MOTIVOCANCELAMENTO", val.Ds_motivocancelamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DS_CARGA", val.Ds_carga);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);

            return this.executarProc("IA_BAL_PSAVULSA", hs);
        }

        public string Excluir(TRegistro_PesagemAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("EXCLUI_BAL_PSAVULSA", hs);
        }
    }
}
