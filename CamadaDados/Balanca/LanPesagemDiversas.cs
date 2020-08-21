using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaDados.Balanca
{
    public class TList_PesagemDiversas : List<TRegistro_PesagemDiversas>, IComparer<TRegistro_PesagemDiversas>
    {
        #region IComparer<TRegistro_PesagemDiversas> Members
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

        public TList_PesagemDiversas()
        { }

        public TList_PesagemDiversas(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PesagemDiversas value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PesagemDiversas x, TRegistro_PesagemDiversas y)
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

    public class TRegistro_PesagemDiversas : IPesagem
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
                    return Convert.ToDateTime(dt_brutostring).ToString("dd/MM/yyyy hh:mm:ss");
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
        public string Nm_transp { get; set; }
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
        private decimal? nr_pedido;        
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostr;
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch { nr_pedido = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Sg_produto
        { get; set; }
        private decimal? id_pedidoitem;
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemstr;
        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = decimal.Parse(value);
                }
                catch { id_pedidoitem = null; }
            }
        }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctoFiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        public decimal? Id_NFItem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }
        private decimal? nr_notafiscal;
        public decimal? Nr_notafiscal
        {
            get { return nr_notafiscal; }
            set
            {
                nr_notafiscal = value;
                nr_notafiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_notafiscalstr;
        public string Nr_notafiscalstr
        {
            get { return nr_notafiscalstr; }
            set
            {
                nr_notafiscalstr = value;
                try
                {
                    nr_notafiscal = decimal.Parse(value);
                }
                catch { nr_notafiscal = null; }
            }
        }
        public TRegistro_LanFaturamento rNota
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_PesagemDiversas()
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
            this.Nm_transp = string.Empty;
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
            this.rNota = null;
            this.St_processar = false;

            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Sg_produto = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.id_pedidoitem = null;
            this.id_pedidoitemstr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.nr_notafiscal = null;
            this.nr_notafiscalstr = string.Empty;
        }
    }

    public class TCD_PesagemDiversas : TDataQuery
    {
        public TCD_PesagemDiversas()
        { }

        public TCD_PesagemDiversas(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Ticket, ");
                sql.AppendLine("a.Tp_Pesagem, c.NM_TpPesagem, c.TP_Modo, a.TP_Movimento, a.PlacaCarreta, ");
                sql.AppendLine("a.DT_Bruto, a.DT_Tara, a.PS_Bruto, a.PS_Tara, a.CD_Transp, ");
                sql.AppendLine("d.NM_Clifor as nm_transportadora, a.Login_PsBruto, a.Login_PsTara, ");
                sql.AppendLine("a.CD_TpVeiculo, e.DS_TpVeiculo, a.NM_Motorista, a.CPF_CNPJ_Mot, a.Tp_Captura_Bruto, ");
                sql.AppendLine("a.Tp_Captura_Tara, a.DS_Observacao, a.DS_MotivoCancelamento, ");
                sql.AppendLine("a.ST_Registro, a.Nr_Pedido, a.CD_Produto, f.DS_Produto, ");
                sql.AppendLine("f.cd_unidade, i.sigla_unidade, a.ID_PedidoItem,");
                sql.AppendLine("a.Nr_LanctoFiscal, g.Nr_NotaFiscal, a.ID_NFItem, a.cd_clifor, h.NM_Clifor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_BAL_PSDIVERSAS a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_BAL_TpPesagem c ");
            sql.AppendLine("on a.Tp_Pesagem = c.Tp_Pesagem ");
            sql.AppendLine("left outer join TB_FIN_Clifor d ");
            sql.AppendLine("on a.CD_Transp = d.CD_Clifor ");
            sql.AppendLine("left outer join TB_DIV_TPVeiculo e ");
            sql.AppendLine("on a.CD_TpVeiculo = e.CD_TpVeiculo ");
            sql.AppendLine("left outer join TB_EST_Produto f ");
            sql.AppendLine("on a.CD_Produto = f.CD_Produto ");
            sql.AppendLine("left outer join TB_FAT_NotaFiscal g ");
            sql.AppendLine("on a.CD_Empresa = g.CD_Empresa ");
            sql.AppendLine("and a.NR_LanctoFiscal = g.NR_LanctoFiscal ");
            sql.AppendLine("left outer join TB_FIN_Clifor h ");
            sql.AppendLine("on a.cd_clifor = h.CD_Clifor ");
            sql.AppendLine("left outer join TB_EST_Unidade i ");
            sql.AppendLine("on f.cd_unidade = i.cd_unidade ");

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

        public TList_PesagemDiversas Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_PesagemDiversas lista = new TList_PesagemDiversas();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PesagemDiversas reg = new TRegistro_PesagemDiversas();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ticket")))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Pesagem")))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("Tp_Pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_TpPesagem")))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TpPesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Modo")))
                        reg.Tp_modo = reader.GetString(reader.GetOrdinal("TP_Modo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaCarreta")))
                        reg.Placacarreta = reader.GetString(reader.GetOrdinal("PlacaCarreta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Bruto")))
                        reg.Dt_bruto = reader.GetDateTime(reader.GetOrdinal("DT_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Tara")))
                        reg.Dt_tara = reader.GetDateTime(reader.GetOrdinal("DT_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Bruto")))
                        reg.Ps_bruto = reader.GetDecimal(reader.GetOrdinal("PS_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Tara")))
                        reg.Ps_tara = reader.GetDecimal(reader.GetOrdinal("PS_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transp")))
                        reg.Cd_transp = reader.GetString(reader.GetOrdinal("CD_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_transportadora")))
                        reg.Nm_transp = reader.GetString(reader.GetOrdinal("nm_transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_PsBruto")))
                        reg.Login_psbruto = reader.GetString(reader.GetOrdinal("Login_PsBruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_PsTara")))
                        reg.Login_pstara = reader.GetString(reader.GetOrdinal("Login_PsTara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo")))
                        reg.Cd_tpveiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpVeiculo")))
                        reg.Ds_tpveiculo = reader.GetString(reader.GetOrdinal("DS_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CPF_CNPJ_Mot")))
                        reg.Cpf_cnpj_mot = reader.GetString(reader.GetOrdinal("CPF_CNPJ_Mot"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Captura_Bruto")))
                        reg.Tp_captura_bruto = reader.GetString(reader.GetOrdinal("Tp_Captura_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Captura_Tara")))
                        reg.Tp_captura_tara = reader.GetString(reader.GetOrdinal("Tp_Captura_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoCancelamento")))
                        reg.Ds_motivocancelamento = reader.GetString(reader.GetOrdinal("DS_MotivoCancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sg_produto = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctoFiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));

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

        public string Gravar(TRegistro_PesagemDiversas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(25);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_PLACACARRETA", val.Placacarreta);
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
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctoFiscal);
            hs.Add("@P_ID_NFITEM", val.Id_NFItem);

            return this.executarProc("IA_BAL_PSDIVERSAS", hs);
        }

        public string Excluir(TRegistro_PesagemDiversas val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_DS_MOTIVOCANCELAMENTO", val.Ds_motivocancelamento);

            return this.executarProc("EXCLUI_BAL_PSDIVERSAS", hs);
        }
    }
}
