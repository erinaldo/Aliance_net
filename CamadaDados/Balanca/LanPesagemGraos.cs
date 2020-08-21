using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Balanca
{
    #region Interface Pesagem Fazenda
    interface IPsFazenda
    {
        decimal? Id_lanctoestoque
        { get; set; }
        string Id_lanctoestoquestr
        { get; set; }
        decimal? Id_plantio
        { get; set; }
        string Id_plantiostr
        { get; set; }
        decimal? Id_cultura
        { get; set; }
        string Id_culturastr
        { get; set; }
        string Ds_cultura
        { get; set; }
        decimal? Id_talhao
        { get; set; }
        string Id_talhaostr
        { get; set; }
        string Ds_talhao
        { get; set; }
        decimal? Id_area
        { get; set; }
        string Id_areastr
        { get; set; }
        string Ds_area
        { get; set; }
        decimal Vl_unitario
        { get; set; }
    }
    #endregion

    public class TList_CommodittiesClifor : List<TRegistro_CommodittiesClifor>, IComparer<TRegistro_CommodittiesClifor>
    {
        #region IComparer<TRegistro_CommodittiesClifor> Members
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

        public TList_CommodittiesClifor()
        { }

        public TList_CommodittiesClifor(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CommodittiesClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CommodittiesClifor x, TRegistro_CommodittiesClifor y)
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

    public class TRegistro_CommodittiesClifor
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Id_ticket
        { get; set; }
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
        public string Cd_contratante
        { get; set; }
        public string Nm_contratante
        { get; set; }
        public decimal Ps_bruto
        { get; set; }
        public decimal Ps_tara
        { get; set; }
        public decimal Ps_desconto
        { get; set; }
        public decimal Qtd_embalagem
        { get; set; }
        public decimal Ps_embalagem
        { get; set; }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        public decimal Qtd_aplicado
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public DateTime? Dt_ticket
        { get; set; }

        public TRegistro_CommodittiesClifor()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_ticket = null;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            Cd_contratante = string.Empty;
            Nm_contratante = string.Empty;
            Ps_bruto = decimal.Zero;
            Ps_tara = decimal.Zero;
            Ps_desconto = decimal.Zero;
            Qtd_embalagem = decimal.Zero;
            Ps_embalagem = decimal.Zero;
            vl_unitario = decimal.Zero;
            Qtd_aplicado = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Dt_ticket = null;
        }
    }

    public class TList_RegLanPesagemGraos : List<TRegistro_LanPesagemGraos>, IComparer<TRegistro_LanPesagemGraos>
    {
        #region IComparer<TRegistro_LanPesagemGraos> Members
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

        public TList_RegLanPesagemGraos()
        { }

        public TList_RegLanPesagemGraos(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPesagemGraos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPesagemGraos x, TRegistro_LanPesagemGraos y)
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

    public class TRegistro_LanPesagemGraos : IPesagem, IPsFazenda
    {
        private decimal? _NR_Contrato;
        public decimal? NR_Contrato 
        {
            get { return _NR_Contrato; }
            set
            {
                _NR_Contrato = value;
                _NR_ContratoStr = value.ToString();
            }
        }
        private string _NR_ContratoStr;
        public string NR_ContratoStr
        {
            get 
            {
                return _NR_ContratoStr;
            }
            set 
            {
                _NR_ContratoStr = value;
                try
                {
                    _NR_Contrato = Convert.ToDecimal(value);
                }
                catch
                {
                    _NR_Contrato = null;
                }
            }
        }
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
        public string CD_Contratante { get; set; }
        public string NM_Contratante { get; set; }
        public string CD_EndContratante { get; set; }
        public string DS_EndContratante { get; set; }
        public string Anosafra { get; set; }
        public string Ds_safra { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        private decimal? id_variedade;
        public decimal? Id_variedade
        {
            get { return id_variedade; }
            set
            {
                id_variedade = value;
                id_variedadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_variedadestr;
        public string Id_variedadestr
        {
            get { return id_variedadestr; }
            set
            {
                id_variedadestr = value;
                try
                {
                    id_variedade = decimal.Parse(value);
                }
                catch { id_variedade = null; }
            }
        }
        public string Ds_variedade
        { get; set; }
        public string Cd_local { get; set; }
        public string Ds_local { get; set; }
        public string Cd_tabeladesconto { get; set; }
        public string Ds_tabeladesconto { get; set; }
        public string Cd_moega { get; set; }
        public string Ds_moega { get; set; }
        private decimal? id_autoriz;
        public decimal? Id_autoriz
        {
            get { return id_autoriz; }
            set
            {
                id_autoriz = value;
                id_autorizstring = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_autorizstring;
        public string Id_autorizstring
        {
            get { return id_autorizstring; }
            set
            {
                id_autorizstring = value;
                try
                {
                    id_autoriz = Convert.ToDecimal(value);
                }
                catch
                { id_autoriz = null; }
            }
        }
        public string Cd_origempesagem
        { get; set; }
        public string Ds_origempesagem
        { get; set; }
        private decimal ps_desconto_est;
        public decimal Ps_desconto_est
        {
            get { return Math.Round(ps_desconto_est, 0); }
            set { ps_desconto_est = Math.Round(value, 0); }
        }
        private decimal ps_desconto_pag;
        public decimal Ps_desconto_pag
        {
            get { return Math.Round(ps_desconto_pag, 0); }
            set
            {
                ps_desconto_pag = Math.Round(value, 0);
                Ps_liquido = Ps_bruto - Ps_tara - ps_desconto_pag - Ps_desdobro - Ps_totalembalagem;
            }
        }
        private string tp_prodpesagem;
        public string Tp_prodpesagem
        {
            get { return tp_prodpesagem; }
            set
            {
                tp_prodpesagem = value;
                if (value.Trim().ToUpper().Equals("CV"))
                    tipo_prodpesagem = "CONVENCIONAL";
                else if (value.Trim().ToUpper().Equals("TR"))
                    tipo_prodpesagem = "TRANSGÊNICA";
                else if (value.Trim().ToUpper().Equals("ID"))
                    tipo_prodpesagem = "INTACTA DECLARADA";
                else if (value.Trim().ToUpper().Equals("IT"))
                    tipo_prodpesagem = "INTACTA TESTADA";
                else if (value.Trim().ToUpper().Equals("IP"))
                    tipo_prodpesagem = "INTACTA PARTICIPANTE";
            }
        }
        private string tipo_prodpesagem;
        public string Tipo_prodpesagem
        {
            get { return tipo_prodpesagem; }
            set
            {
                tipo_prodpesagem = value;
                if (value.Trim().ToUpper().Equals("CONVENCIONAL"))
                    tp_prodpesagem = "CV";
                else if (value.Trim().ToUpper().Equals("TRANSGÊNICA"))
                    tp_prodpesagem = "TR";
                else if (value.Trim().ToUpper().Equals("INTACTA DECLARADA"))
                    tp_prodpesagem = "ID";
                else if (value.Trim().ToUpper().Equals("INTACTA TESTADA"))
                    tp_prodpesagem = "IT";
                else if (value.Trim().ToUpper().Equals("INTACTA PARTICIPANTE"))
                    tp_prodpesagem = "IP";
            }
        }
        public string Nr_notaprodutor { get; set; }
        private DateTime? dt_emissaonfprodutor;
        public DateTime? Dt_emissaonfprodutor
        {
            get { return dt_emissaonfprodutor; }
            set
            {
                dt_emissaonfprodutor = value;
                dt_emissaonfprodutorstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaonfprodutorstr;
        public string Dt_emissaonfprodutorstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaonfprodutorstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaonfprodutorstr = value;
                try
                {
                    dt_emissaonfprodutor = DateTime.Parse(value);
                }
                catch { dt_emissaonfprodutor = null; }
            }
        }
        private DateTime? dt_venctonfprodutor;

        public DateTime? Dt_venctonfprodutor
        {
            get { return dt_venctonfprodutor; }
            set
            {
                dt_venctonfprodutor = value;
                dt_venctonfprodutorstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_venctonfprodutorstr;

        public string Dt_venctonfprodutorstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_venctonfprodutorstr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_venctonfprodutorstr = value;
                try
                {
                    dt_venctonfprodutor = DateTime.Parse(value);
                }catch { dt_venctonfprodutor = null; }
            }
        }

        public decimal Qt_nfprodutor { get; set; }
        public decimal Vl_nfprodutor { get; set; }

        private decimal qtd_aplicado;
        public decimal Qtd_Aplicado 
        {
            get { return Math.Round(qtd_aplicado, 0); }
            set { qtd_aplicado = Math.Round(value, 0); }
        }
        
        public string Cd_cliforemp
        {
            get;
            set;
        }
        public string Nr_cgcemp
        {
            get;
            set;
        }
        public string Foneemp
        {
            get;
            set;
        }
        public string Celularemp
        {
            get;
            set;
        }
        public string Cidadeemp
        {
            get;
            set;
        }
        public string Estadoemp
        {
            get;
            set;
        }
        public string Cd_ufemp
        {
            get;
            set;
        }

        public string Ds_amostra1
        { get; set; }
        public string Ds_amostra2
        { get; set; }
        public decimal Pc_amostra1
        { get; set; }
        public decimal Pc_amostra2
        { get; set; }
        public decimal Ps_amostra1
        { get; set; }
        public decimal Ps_amostra2
        { get; set; }

        //Campos para aplicar
        public string Tp_movcontrato
        { get; set; }
        public string Cd_ufcontratante
        { get; set; }
        public string Cd_condfiscal_contratante
        { get; set; }
        public string Tp_pessoa_contratante
        { get; set; }
        public string Freteporconta
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_unid_produto
        { get; set; }
        public string Cd_unid_contrato
        { get; set; }
        public decimal Vl_unit_contrato
        { get; set; }

        public TList_LanTransbordo lTransbordo
        { get; set; }
        public TList_RegLanClassificacao Classificacao
        {
            get;
            set;
        }
        public TList_ItensDesdobro lDesdobroDel
        { get; set; }
        public TList_ItensDesdobro lDesdobro
        { get; set; }
        public CamadaDados.Estoque.TRegistro_LanEstoque rEstEmbalagem
        { get; set; }
        public TList_LanAplicacaoPedido lAplicTicket
        { get; set; }
        private decimal ps_aplicar;
        public decimal Ps_Aplicar
        {
            get { return Math.Round(ps_aplicar, 0); }
            set { ps_aplicar = Math.Round(value, 0); }
        }
        public string Tp_desdobro { get; set; } = string.Empty;
        public string ie_endContratante { get; set; }
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
                if ((dt_tara != null) && (dt_bruto != null))
                    if (tp_movimento.Trim().ToUpper().Equals("E"))
                        return dt_tara.Value.Subtract(dt_bruto.Value);
                    else if (tp_movimento.Trim().ToUpper().Equals("S"))
                        return dt_bruto.Value.Subtract(dt_tara.Value);
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
                return (Dt_permanenciaveiculo.HasValue ? (Dt_permanenciaveiculo.Value.Days > 0 ? Dt_permanenciaveiculo.Value.Days.ToString() + " Dias" : string.Empty) +
                                (Dt_permanenciaveiculo.Value.Hours > 0 ? Dt_permanenciaveiculo.Value.Hours.ToString() + " Hr " : string.Empty) +
                                (Dt_permanenciaveiculo.Value.Minutes > 0 ? Dt_permanenciaveiculo.Value.Minutes.ToString() + " Mn " : string.Empty) +
                                (Dt_permanenciaveiculo.Value.Seconds > 0 ? Dt_permanenciaveiculo.Value.Seconds.ToString() + " Sg" : string.Empty) : "");
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
                if (ps_liquido > decimal.Zero)
                {
                    string aux = Math.Floor(ps_liquido / 60).ToString() + " Sacas(60Kg)";
                    if ((ps_liquido % 60) > 0)
                        aux += " e " + (ps_liquido % 60).ToString() + "Kg";
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
        public decimal Ps_desdobro { get; set; }
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
        private string st_testprod;
        public string St_testprod
        {
            get { return st_testprod; }
            set
            {
                st_testprod = value;
                st_testprodbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_testprodbool;
        public bool St_testprodbool
        {
            get { return st_testprodbool; }
            set
            {
                st_testprodbool = value;
                if (value)
                    st_testprod = "S";
                else
                    st_testprod = "N";
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

        #region IPsFazenda Members
        private decimal? id_lanctoestoque;
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }
        private decimal? id_plantio;
        public decimal? Id_plantio
        {
            get { return id_plantio; }
            set
            {
                id_plantio = value;
                id_plantiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_plantiostr;
        public string Id_plantiostr
        {
            get { return id_plantiostr; }
            set
            {
                id_plantiostr = value;
                try
                {
                    id_plantio = decimal.Parse(value);
                }
                catch
                { id_plantio = null; }
            }
        }
        private decimal? id_cultura;
        public decimal? Id_cultura
        {
            get { return id_cultura; }
            set
            {
                id_cultura = value;
                id_culturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_culturastr;
        public string Id_culturastr
        {
            get { return id_culturastr; }
            set
            {
                id_culturastr = value;
                try
                {
                    id_cultura = decimal.Parse(value);
                }
                catch
                { id_cultura = null; }
            }
        }
        public string Ds_cultura
        { get; set; }
        private decimal? id_talhao;
        public decimal? Id_talhao
        {
            get { return id_talhao; }
            set
            {
                id_talhao = value;
                id_talhaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_talhaostr;
        public string Id_talhaostr
        {
            get { return id_talhaostr; }
            set
            {
                id_talhaostr = value;
                try
                {
                    id_talhao = decimal.Parse(value);
                }
                catch
                { id_talhao = null; }
            }
        }
        public string Ds_talhao
        { get; set; }
        private decimal? id_area;
        public decimal? Id_area
        {
            get { return id_area; }
            set
            {
                id_area = value;
                id_areastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_areastr;
        public string Id_areastr
        {
            get { return id_areastr; }
            set
            {
                id_areastr = value;
                try
                {
                    id_area = decimal.Parse(value);
                }
                catch
                { id_area = null; }
            }
        }
        public string Ds_area
        { get; set; }
        public decimal Vl_unitario
        { get; set; }

        #endregion

        public TRegistro_LanPesagemGraos()
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
            this.ie_endContratante = string.Empty;
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
            this.Ps_desdobro = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.tp_transbordo = "N";
            this.tp_transbordobool = false;
            this.Ps_transbordo = decimal.Zero;
            this.st_testprod = "N";
            this.st_testprodbool = false;
            this.St_processarTicketRef = false;
            this.Ds_motivocancelamento = string.Empty;
            this.lFotosPesagem = new TList_FotosPesagem();
            this.lFotosPesagemExcluir = new TList_FotosPesagem();
            this.NR_Contrato = null;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.id_pedidoitem = null;
            this.id_pedidoitemstr = string.Empty;
            this.CD_Contratante = string.Empty;
            this.NM_Contratante = string.Empty;
            this.CD_EndContratante = string.Empty;
            this.DS_EndContratante = string.Empty;
            this.Anosafra = string.Empty;
            this.Ds_safra = string.Empty;
            this.Cd_moega = string.Empty;
            this.Ds_moega = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.id_variedade = null;
            this.id_variedadestr = string.Empty;
            this.Ds_variedade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Cd_tabeladesconto = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.id_autoriz = null;
            this.id_autorizstring = string.Empty;
            this.ps_desconto_est = decimal.Zero;
            this.ps_desconto_pag = decimal.Zero;
            this.tp_prodpesagem = "CV";
            this.tipo_prodpesagem = "CONVENCIONAL";
            this.Cd_cliforemp = string.Empty;
            this.Nr_cgcemp = string.Empty;
            this.Foneemp = string.Empty;
            this.Celularemp = string.Empty;
            this.Cidadeemp = string.Empty;
            this.Estadoemp = string.Empty;
            this.Cd_ufemp = string.Empty;
            this.ps_aplicar = decimal.Zero;
            this.Cd_origempesagem = string.Empty;
            this.Ds_origempesagem = string.Empty;
            this.Classificacao = new TList_RegLanClassificacao();
            this.lAplicTicket = new TList_LanAplicacaoPedido();
            this.lDesdobroDel = new TList_ItensDesdobro();
            this.lDesdobro = new TList_ItensDesdobro();
            this.rEstEmbalagem = null;
            this.qtd_aplicado = decimal.Zero;
            this.Ds_amostra1 = string.Empty;
            this.Ds_amostra2 = string.Empty;
            this.Pc_amostra1 = decimal.Zero;
            this.Pc_amostra2 = decimal.Zero;
            this.Ps_amostra1 = decimal.Zero;
            this.Ps_amostra2 = decimal.Zero;
            this.id_lanctoestoque = null;
            this.id_lanctoestoquestr = string.Empty;
            this.id_plantio = null;
            this.id_plantiostr = string.Empty;
            this.id_cultura = null;
            this.id_culturastr = string.Empty;
            this.Ds_cultura = string.Empty;
            this.id_area = null;
            this.id_areastr = string.Empty;
            this.Ds_area = string.Empty;
            this.id_talhao = null;
            this.id_talhaostr = string.Empty;
            this.Ds_talhao = string.Empty;
            this.Vl_unitario = decimal.Zero;

            Tp_movcontrato = string.Empty;
            Cd_ufcontratante = string.Empty;
            Cd_condfiscal_contratante = string.Empty;
            Tp_pessoa_contratante = string.Empty;
            Freteporconta = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Cd_unid_produto = string.Empty;
            Cd_unid_contrato = string.Empty;
            Vl_unit_contrato = decimal.Zero;
        }
    }

    public class TCD_LanPesagemGraos: TDataQuery
    {
        public TCD_LanPesagemGraos()
        { }

        public TCD_LanPesagemGraos(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }
                
        private string SqlCodeBusca(TpBusca[] vBusca, 
                                    string Cd_amostra1,
                                    string Cd_amostra2,
                                    Int32 vTop, 
                                    string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, c.NM_Empresa, c.CD_Clifor as CD_CliforEmp, d.Tp_modo, ");
                sql.AppendLine("a.CD_tabeladesconto, l.ds_tabeladesconto, a.DS_MotivoCancelamento, ");
                sql.AppendLine("ce.NR_CGC as NR_CGCEmp, ee.Fone as FoneEmp, ee.celular as CelularEmp, ee.DS_Cidade as CidadeEmp, ");
                sql.AppendLine("ee.UF as EstadoEmp, ee.CD_UF as CD_UFEmp, d.tp_transbordo, a.PS_Desdobro, ");
                sql.AppendLine("d.NM_TPPesagem, a.ID_TicketOrig, a.TP_Movimento, a.PlacaCarreta, ");
                sql.AppendLine("a.PlacaCavalo, a.DT_Bruto, a.DT_Tara, a.ID_Ticket, a.TP_Pesagem, ");
                sql.AppendLine("a.PS_Bruto, a.PS_Tara, (a.ps_bruto - a.ps_tara - a.ps_desconto_pag - a.ps_desdobro - (a.qtd_embalagem * a.ps_embalagem))as PS_Liquido, ");
                sql.AppendLine("a.CD_Transp, e.NM_Clifor as NM_Transportadora, ");
                sql.AppendLine("a.Login_PsTara, a.Login_PsBruto, a.Cd_TpVeiculo, f.DS_TpVeiculo, ");
                sql.AppendLine("a.NM_Motorista, a.Cpf_cnpj_mot, a.TP_Captura_Bruto, a.TP_Captura_Tara, ");
                sql.AppendLine("a.QTD_Embalagem, a.PS_Embalagem, a.DS_Observacao, ");
                sql.AppendLine("a.TP_ProdPesagem, a.AnoSafra, g.DS_Safra, a.CD_Moega, ");
                sql.AppendLine("h.DS_Moega, a.CD_Produto, i.DS_Produto, a.id_variedade, vr.ds_variedade, ");
                sql.AppendLine("a.CD_Local, k.DS_Local, a.CD_TabelaDesconto, l.DS_TabelaDesconto, ");
                sql.AppendLine("a.ID_Autoriz, a.PS_Desconto_Est, a.PS_Desconto_Pag, ");
                sql.AppendLine("a.CD_Contratante, a.NM_Contratante, a.ST_Registro, ");
                sql.AppendLine("a.nr_contrato, cto.nr_pedido, cto.ID_PedidoItem, cto.cd_endereco as CD_EndContratante, ");
                sql.AppendLine("a.cd_origempesagem, cid.ds_cidade as ds_origempesagem, endCto.ds_endereco as DS_EndContratante, endCto.insc_estadual as ie_endContratante, ");
                sql.AppendLine("a.NR_NotaProdutor, a.DT_EmissaoNFProdutor, a.DT_VenctoNFProdutor, a.QT_NFProdutor, a.VL_NFProdutor, ");
                sql.AppendLine("cliCto.Cd_CondFiscal_Clifor as Cd_CondFiscal_Contratante, cliCto.TP_Pessoa as Tp_Pessoa_Contratante, ");
                sql.AppendLine("endCto.CD_UF as Cd_Uf_Contratante, cto.Tp_Movimento as Tp_MovContrato, ped.Tp_Frete as Freteporconta, ");
                sql.AppendLine("i.CD_CondFiscal_Produto, i.CD_Unidade as Cd_unid_produto, a.st_testprod, ");
                sql.AppendLine("cto.VL_Unitario as Vl_unit_contrato, cto.CD_Unidade as Cd_unid_contrato, ");
                //Dados Fazenda
                sql.AppendLine("a.id_plantio, plantio.id_cultura, cultura.ds_cultura, ");
                sql.AppendLine("a.id_area, area.ds_area, a.id_talhao, talhao.ds_talhao, a.vl_unitario, a.ps_aplicado, ");
                sql.AppendLine("PS_Aplicar = (round(isnull((isnull(A.PS_BRUTO,0) - isnull(A.PS_TARA,0) - isnull(a.PS_Desconto_Pag,0) - isnull(a.PS_Desdobro, 0) - ");
                sql.AppendLine("             a.Ps_aplicado),0),0)), ");
                sql.AppendLine("Ps_Transbordo =    (select isnull(sum(isnull(x.ps_transbordo, 0)), 0) from tb_bal_transbordo x ");
                sql.AppendLine("                    where x.cd_empresaorig = a.cd_empresa ");
                sql.AppendLine("                    and x.id_ticketorig = a.id_ticket ");
                sql.AppendLine("                    and x.tp_pesagemorig = a.tp_pesagem), ");
                sql.AppendLine("ds_amostra1 = (select x.ds_amostra ");
                sql.AppendLine("                from tb_gro_amostra x ");
                sql.AppendLine("                where x.cd_tipoamostra = '" + Cd_amostra1.Trim() + "'), ");
                sql.AppendLine("ds_amostra2 = (select x.ds_amostra ");
                sql.AppendLine("                from tb_gro_amostra x ");
                sql.AppendLine("                where x.cd_tipoamostra = '" + Cd_amostra2.Trim() + "'), ");
                sql.AppendLine("pc_amostra1 = isnull((select top 1 isnull(x.pc_resultado_local, 0) ");
                sql.AppendLine("                from tb_bal_classif x ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.id_ticket = a.id_ticket ");
                sql.AppendLine("                and x.tp_pesagem = a.tp_pesagem ");
                sql.AppendLine("                and x.cd_tipoamostra = '" + Cd_amostra1.Trim() + "'), 0), ");
                sql.AppendLine("pc_amostra2 = isnull((select top 1 isnull(x.pc_resultado_local, 0) ");
                sql.AppendLine("                from tb_bal_classif x ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.id_ticket = a.id_ticket ");
                sql.AppendLine("                and x.tp_pesagem = a.tp_pesagem ");
                sql.AppendLine("                and x.cd_tipoamostra = '" + Cd_amostra2.Trim() + "'), 0), ");
                sql.AppendLine("ps_amostra1 = isnull((select top 1 isnull(x.ps_descontado_pgt, 0) ");
                sql.AppendLine("                from tb_bal_classif x ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.id_ticket = a.id_ticket ");
                sql.AppendLine("                and x.tp_pesagem = a.tp_pesagem ");
                sql.AppendLine("                and x.cd_tipoamostra = '" + Cd_amostra1.Trim() + "'), 0), ");
                sql.AppendLine("ps_amostra2 = isnull((select top 1 isnull(x.ps_descontado_pgt, 0) ");
                sql.AppendLine("                from tb_bal_classif x ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.id_ticket = a.id_ticket ");
                sql.AppendLine("                and x.tp_pesagem = a.tp_pesagem ");
                sql.AppendLine("                and x.cd_tipoamostra = '" + Cd_amostra2.Trim() + "'), 0) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_BAL_PsGraos a ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("On c.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("inner join TB_BAL_TPPesagem ");
            sql.AppendLine("d On d.TP_Pesagem = a.TP_Pesagem ");
            sql.AppendLine("inner join TB_GRO_TabelaDesconto l ");
            sql.AppendLine("On l.CD_TabelaDesconto = a.CD_TabelaDesconto ");

            sql.AppendLine("left outer join TB_FIN_Cidade cid ");
            sql.AppendLine("on a.cd_origempesagem = cid.cd_cidade ");
            sql.AppendLine("left outer join TB_GRO_Safra g ");
            sql.AppendLine("On g.anoSafra = a.anoSafra ");
            sql.AppendLine("left outer join TB_EST_Produto i ");
            sql.AppendLine("On i.CD_Produto = a.CD_Produto ");
            sql.AppendLine("left outer join TB_EST_LocalArm k ");
            sql.AppendLine("On k.CD_Local = a.CD_Local ");

            sql.AppendLine("left outer join VTB_GRO_Contrato cto ");
            sql.AppendLine("on cto.nr_contrato = a.nr_contrato");
            sql.AppendLine("LEFT outer join TB_FIN_Clifor cliCto ");
            sql.AppendLine("on cto.CD_Clifor = cliCto.CD_Clifor ");
            sql.AppendLine("LEFT outer join VTB_FIN_ENDERECO endCto ");
            sql.AppendLine("on cto.CD_Clifor = endCto.CD_Clifor ");
            sql.AppendLine("and cto.CD_Endereco = endCto.CD_Endereco ");
            sql.AppendLine("left outer join TB_FAT_DadosPedido ped ");
            sql.AppendLine("on cto.Nr_Pedido = ped.Nr_Pedido ");
            sql.AppendLine("left outer join VTB_FIN_Clifor e ");
            sql.AppendLine("On e.CD_Clifor = a.CD_Transp ");

            sql.AppendLine("left outer join TB_DIV_TpVeiculo f ");
            sql.AppendLine("On f.CD_TpVeiculo = a.CD_TPVeiculo ");            
            sql.AppendLine("left outer join TB_EST_Moega h ");
            sql.AppendLine("On h.CD_Moega = a.CD_Moega ");
            
            sql.AppendLine("left outer join VTB_FIN_Clifor ce ");
            sql.AppendLine("On ce.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco ee ");
            sql.AppendLine("On ee.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("and ee.CD_Endereco = c.CD_Endereco ");

            sql.AppendLine("left outer join TB_EST_Variedade vr ");
            sql.AppendLine("on a.cd_produto = vr.cd_produto ");
            sql.AppendLine("and a.id_variedade = vr.id_variedade ");
            //Dados Fazenda
            sql.AppendLine("left outer join tb_faz_plantio plantio ");
            sql.AppendLine("on a.id_plantio = plantio.id_plantio ");
            sql.AppendLine("left outer join tb_faz_cultura cultura ");
            sql.AppendLine("on plantio.id_cultura = cultura.id_cultura ");
            sql.AppendLine("left outer join tb_faz_area area ");
            sql.AppendLine("on a.cd_empresa = area.cd_fazenda ");
            sql.AppendLine("and a.id_area = area.id_area ");
            sql.AppendLine("left outer join tb_faz_talhoes talhao ");
            sql.AppendLine("on a.cd_empresa = talhao.cd_fazenda ");
            sql.AppendLine("and a.id_area = talhao.id_area ");
            sql.AppendLine("and a.id_talhao = talhao.id_talhao ");
            
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
            return ExecutarBusca(SqlCodeBusca(vBusca, string.Empty, string.Empty, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, string.Empty, string.Empty, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, string.Empty, string.Empty, 1, vNM_Campo), null);
        }

        public TList_RegLanPesagemGraos Select(TpBusca[] vBusca, 
                                               string Cd_amostra1,
                                               string Cd_amostra2,
                                               Int32 vTop, 
                                               string vNM_Campo)
        {
            TList_RegLanPesagemGraos lista = new TList_RegLanPesagemGraos();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Cd_amostra1, Cd_amostra2, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanPesagemGraos reg = new TRegistro_LanPesagemGraos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
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
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Liquido"))))
                        reg.Ps_liquido = reader.GetDecimal(reader.GetOrdinal("PS_Liquido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Transp"))))
                        reg.Cd_transp = reader.GetString(reader.GetOrdinal("CD_Transp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_PsTara"))))
                        reg.Login_pstara = reader.GetString(reader.GetOrdinal("Login_PsTara"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login_PsBruto"))))
                        reg.Login_psbruto = reader.GetString(reader.GetOrdinal("Login_PsBruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo"))))
                        reg.Cd_tpveiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpVeiculo"))))
                        reg.Ds_tpveiculo = reader.GetString(reader.GetOrdinal("DS_TpVeiculo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Motorista"))))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cpf_cnpj_mot")))
                        reg.Cpf_cnpj_mot = reader.GetString(reader.GetOrdinal("Cpf_cnpj_mot"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Captura_Bruto"))))
                        reg.Tp_captura_bruto = reader.GetString(reader.GetOrdinal("TP_Captura_Bruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Captura_Tara"))))
                        reg.Tp_captura_tara = reader.GetString(reader.GetOrdinal("TP_Captura_Tara"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Embalagem"))))
                        reg.Qtd_embalagem = reader.GetDecimal(reader.GetOrdinal("QTD_Embalagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Embalagem"))))
                        reg.Ps_embalagem = reader.GetDecimal(reader.GetOrdinal("PS_Embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Desdobro")))
                        reg.Ps_desdobro = reader.GetDecimal(reader.GetOrdinal("PS_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("AnoSafra"))))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Safra"))))
                        reg.Ds_safra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moega"))))
                        reg.Cd_moega = reader.GetString(reader.GetOrdinal("CD_Moega"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moega"))))
                        reg.Ds_moega = reader.GetString(reader.GetOrdinal("DS_Moega"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_variedade")))
                        reg.Id_variedade = reader.GetDecimal(reader.GetOrdinal("id_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                        reg.Ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Local"))))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto"))))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TabelaDesconto"))))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("DS_TabelaDesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Autoriz"))))
                        reg.Id_autoriz = reader.GetDecimal(reader.GetOrdinal("ID_Autoriz"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Contrato"))))
                        reg.NR_Contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Contratante"))))
                        reg.CD_Contratante = reader.GetString(reader.GetOrdinal("CD_Contratante"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Contratante"))))
                        reg.NM_Contratante = reader.GetString(reader.GetOrdinal("NM_Contratante"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EndContratante"))))
                        reg.CD_EndContratante = reader.GetString(reader.GetOrdinal("CD_EndContratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndContratante")))
                        reg.DS_EndContratante = reader.GetString(reader.GetOrdinal("DS_EndContratante"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_ProdPesagem"))))
                        reg.Tp_prodpesagem = reader.GetString(reader.GetOrdinal("TP_ProdPesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Desconto_Est"))))
                        reg.Ps_desconto_est = reader.GetDecimal(reader.GetOrdinal("PS_Desconto_est"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PS_Desconto_Pag"))))
                        reg.Ps_desconto_pag = reader.GetDecimal(reader.GetOrdinal("PS_Desconto_Pag"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("FoneEmp"))))
                        reg.Foneemp = reader.GetString(reader.GetOrdinal("FoneEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CelularEmp"))))
                        reg.Celularemp = reader.GetString(reader.GetOrdinal("CelularEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CliforEmp"))))
                        reg.Cd_cliforemp = reader.GetString(reader.GetOrdinal("CD_CliforEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CGCEmp"))))
                        reg.Nr_cgcemp = reader.GetString(reader.GetOrdinal("NR_CGCEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("FoneEmp"))))
                        reg.Foneemp = reader.GetString(reader.GetOrdinal("FoneEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CidadeEmp"))))
                        reg.Cidadeemp = reader.GetString(reader.GetOrdinal("CidadeEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("EstadoEmp"))))
                        reg.Estadoemp = reader.GetString(reader.GetOrdinal("EstadoEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_UFEmp"))))
                        reg.Cd_ufemp = reader.GetString(reader.GetOrdinal("CD_UFEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Tabeladesconto"))))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("CD_tabeladesconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Tabeladesconto"))))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("DS_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Aplicar")))
                        reg.Ps_Aplicar = reader.GetDecimal(reader.GetOrdinal("Ps_Aplicar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Transbordo")))
                        reg.Tp_transbordo = reader.GetString(reader.GetOrdinal("TP_Transbordo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Transbordo")))
                        reg.Ps_transbordo = reader.GetDecimal(reader.GetOrdinal("Ps_Transbordo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_aplicado")))
                        reg.Qtd_Aplicado = reader.GetDecimal(reader.GetOrdinal("ps_aplicado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_OrigemPesagem")))
                        reg.Cd_origempesagem = reader.GetString(reader.GetOrdinal("CD_OrigemPesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_OrigemPesagem")))
                        reg.Ds_origempesagem = reader.GetString(reader.GetOrdinal("DS_OrigemPesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoCancelamento")))
                        reg.Ds_motivocancelamento = reader.GetString(reader.GetOrdinal("DS_MotivoCancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_amostra1")))
                        reg.Ds_amostra1 = reader.GetString(reader.GetOrdinal("ds_amostra1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_amostra2")))
                        reg.Ds_amostra2 = reader.GetString(reader.GetOrdinal("ds_amostra2"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_amostra1")))
                        reg.Pc_amostra1 = reader.GetDecimal(reader.GetOrdinal("pc_amostra1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_amostra2")))
                        reg.Pc_amostra2 = reader.GetDecimal(reader.GetOrdinal("pc_amostra2"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_amostra1")))
                        reg.Ps_amostra1 = reader.GetDecimal(reader.GetOrdinal("ps_amostra1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_amostra2")))
                        reg.Ps_amostra2 = reader.GetDecimal(reader.GetOrdinal("ps_amostra2"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaProdutor")))
                        reg.Nr_notaprodutor = reader.GetString(reader.GetOrdinal("NR_NotaProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EmissaoNFProdutor")))
                        reg.Dt_emissaonfprodutor = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoNFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_VenctoNFProdutor")))
                        reg.Dt_venctonfprodutor = reader.GetDateTime(reader.GetOrdinal("DT_VenctoNFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_NFProdutor")))
                        reg.Qt_nfprodutor = reader.GetDecimal(reader.GetOrdinal("QT_NFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_NFProdutor")))
                        reg.Vl_nfprodutor = reader.GetDecimal(reader.GetOrdinal("VL_NFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Contratante")))
                        reg.Cd_condfiscal_contratante = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Contratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Pessoa_Contratante")))
                        reg.Tp_pessoa_contratante = reader.GetString(reader.GetOrdinal("Tp_Pessoa_Contratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Uf_Contratante")))
                        reg.Cd_ufcontratante = reader.GetString(reader.GetOrdinal("Cd_Uf_Contratante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_MovContrato")))
                        reg.Tp_movcontrato = reader.GetString(reader.GetOrdinal("Tp_MovContrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Freteporconta")))
                        reg.Freteporconta = reader.GetString(reader.GetOrdinal("Freteporconta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("Cd_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unit_contrato")))
                        reg.Vl_unit_contrato = reader.GetDecimal(reader.GetOrdinal("Vl_unit_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unid_contrato")))
                        reg.Cd_unid_contrato = reader.GetString(reader.GetOrdinal("Cd_unid_contrato"));
                    //Dados Fazenda
                    if (!reader.IsDBNull(reader.GetOrdinal("id_plantio")))
                        reg.Id_plantio = reader.GetDecimal(reader.GetOrdinal("id_plantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cultura")))
                        reg.Id_cultura = reader.GetDecimal(reader.GetOrdinal("id_cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cultura")))
                        reg.Ds_cultura = reader.GetString(reader.GetOrdinal("ds_cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_area")))
                        reg.Id_area = reader.GetDecimal(reader.GetOrdinal("id_area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("ds_area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_talhao")))
                        reg.Id_talhao = reader.GetDecimal(reader.GetOrdinal("id_talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_talhao")))
                        reg.Ds_talhao = reader.GetString(reader.GetOrdinal("ds_talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_testprod"))))
                        reg.St_testprod = reader.GetString(reader.GetOrdinal("st_testprod")); 
                    if (!(reader.IsDBNull(reader.GetOrdinal("ie_endContratante"))))
                        reg.ie_endContratante = reader.GetString(reader.GetOrdinal("ie_endContratante")); 

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

        public string Gravar(TRegistro_LanPesagemGraos val)
        {
            Hashtable hs = new Hashtable(44);
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
            hs.Add("@P_NR_CONTRATO", val.NR_Contrato);
            hs.Add("@P_CD_CONTRATANTE", val.CD_Contratante);
            hs.Add("@P_NM_CONTRATANTE", val.NM_Contratante);            
            hs.Add("@P_ANOSAFRA", val.Anosafra);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_VARIEDADE", val.Id_variedade);
            hs.Add("@P_CD_MOEGA", val.Cd_moega);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_ID_AUTORIZ", val.Id_autoriz);
            hs.Add("@P_TP_PRODPESAGEM", val.Tp_prodpesagem);
            hs.Add("@P_PS_DESCONTO_EST", val.Ps_desconto_est);
            hs.Add("@P_PS_DESCONTO_PAG", val.Ps_desconto_pag);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_ORIGEMPESAGEM", val.Cd_origempesagem);
            hs.Add("@P_ST_TESTPROD", val.St_testprod);
            hs.Add("@P_NR_NOTAPRODUTOR", val.Nr_notaprodutor);
            hs.Add("@P_DT_EMISSAONFPRODUTOR", val.Dt_emissaonfprodutor);
            hs.Add("@P_DT_VENCTONFPRODUTOR", val.Dt_venctonfprodutor);
            hs.Add("@P_QT_NFPRODUTOR", val.Qt_nfprodutor);
            hs.Add("@P_VL_NFPRODUTOR", val.Vl_nfprodutor);

            return executarProc("IA_BAL_PSGRAOS", hs);
        }

        public string GravaPesagemFazenda(TRegistro_LanPesagemGraos val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_FAZENDA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);

            return executarProc("IA_BAL_PSFAZENDA", hs);
        }
    }
}