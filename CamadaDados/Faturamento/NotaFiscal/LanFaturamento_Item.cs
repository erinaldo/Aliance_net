using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Estoque;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Graos;
using CamadaDados.Faturamento.PDV;
using CamadaDados.Empreendimento;
using CamadaDados.Balanca;
using CamadaDados.Sementes;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Producao.Producao;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TRegistro_ItensXMLNFe
    {
        public string Cd_produto_xml
        { get; set; }
        public string Ds_produto_xml
        { get; set; }
        public string Codigo_Bar
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal? Id_caracteristica { get; set; } = null;
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Ncm_xml
        { get; set; }
        public string Ncm
        { get; set; }
        public string Cfop_xml
        { get; set; }
        public string Cfop
        { get; set; }
        public string Cd_anp_xml
        { get; set; }
        public string Cd_anp
        { get; set; }
        public string Tp_origem
        { get; set; }
        public string Cd_unidade_fornec
        { get; set; }
        public string Ds_unidade_fornec
        { get; set; }
        public decimal Quantidade_xml
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_seguro
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_outrasdesp
        { get; set; }
        public decimal Vl_liquido
        { get { return Vl_subtotal + Vl_frete + Vl_seguro + Vl_outrasdesp - Vl_desconto; } }
        public Estoque.Cadastros.TRegistro_CadProduto rProd
        { get; set; }
        public Estoque.Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Estoque.Cadastros.TList_ValorCaracteristica();
        public TList_ImpostosNF lImpostos
        { get; set; }
        public TList_Rastreabilidade lLoteRast
        { get; set; }
        public TList_MovRastreabilidade lMov
        { get; set; }
        //Lote Matéria-Prima
        public decimal Qtd_movimentar
        { get; set; }
        public decimal Tot_movimento
        { get; set; }
        public decimal Saldo
        { get { return Qtd_movimentar - Tot_movimento; } }
        public string CD_CodBarra { get; set; } = string.Empty;

        public TRegistro_ItensXMLNFe()
        {
            Cd_produto_xml = string.Empty;
            Codigo_Bar = string.Empty;
            Ds_produto_xml = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Ncm_xml = string.Empty;
            Ncm = string.Empty;
            Cfop_xml = string.Empty;
            Cfop = string.Empty;
            Cd_anp_xml = string.Empty;
            Cd_anp = string.Empty;
            Cd_unidade_fornec = string.Empty;
            Ds_unidade_fornec = string.Empty;
            Quantidade_xml = decimal.Zero;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Vl_frete = decimal.Zero;
            Vl_seguro = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_outrasdesp = decimal.Zero;
            rProd = null;
            lImpostos = new TList_ImpostosNF();
            lLoteRast = new TList_Rastreabilidade();
            lMov = new TList_MovRastreabilidade();
            Qtd_movimentar = decimal.Zero;
            Tot_movimento = decimal.Zero;
            Tp_origem = string.Empty;
        }
    }

    public class TListVendasMes : List<TRegistroVendasMes>
    { }

    public class TRegistroVendasMes
    {
        public int? Ano
        { get; set; }
        public int? Mes
        { get; set; }
        public string Messtr
        {
            get
            {
                if (Mes == null)
                    return string.Empty;
                else
                    switch (Mes.Value)
                    {
                        case 1: return "Janeiro";
                        case 2: return "Fevereiro";
                        case 3: return "Março";
                        case 4: return "Abril";
                        case 5: return "Maio";
                        case 6: return "Junho";
                        case 7: return "Julho";
                        case 8: return "Agosto";
                        case 9: return "Setembro";
                        case 10: return "Outubro";
                        case 11: return "Novembro";
                        case 12: return "Dezembro";
                        default: return string.Empty;
                    }
            }
        }
        public string Sigla_unidade
        { get; set; }
        public decimal Quantidade
        { get; set; }

        public TRegistroVendasMes()
        {
            Ano = null;
            Mes = null;
            Sigla_unidade = string.Empty;
            Quantidade = decimal.Zero;
        }
    }

    public class TListUltimasCompras : List<TRegistroUltimasCompras>
    { }

    public class TRegistroUltimasCompras
    {
        public decimal? Nr_notafiscal
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nm_fantasia
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_unitario
        {
            get
            {
                if ((Quantidade > 0) && (Vl_subtotal > 0))
                    return Vl_subtotal / Quantidade;
                else
                    return decimal.Zero;
            }
        }
        public decimal Vl_custoNota
        { get; set; }
        public decimal Vl_UnitCustoNota
        {
            get
            {
                if ((Quantidade > decimal.Zero) &&
                    (Vl_custoNota > decimal.Zero))
                    return Vl_custoNota / Quantidade;
                else
                    return decimal.Zero;
            }
        }

        public TRegistroUltimasCompras()
        {
            Nr_notafiscal = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Nm_fantasia = string.Empty;
            Dt_emissao = null;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Sigla_unidade = string.Empty;
            Quantidade = decimal.Zero;
            Vl_subtotal = decimal.Zero;
        }
    }

    public class TList_RegLanFaturamento_Item : List<TRegistro_LanFaturamento_Item>, IComparer<TRegistro_LanFaturamento_Item>
    {
        #region IComparer<TRegistro_LanFaturamento_Item> Members
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

        public TList_RegLanFaturamento_Item()
        { }

        public TList_RegLanFaturamento_Item(System.ComponentModel.PropertyDescriptor Prop,
                                            System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanFaturamento_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanFaturamento_Item x, TRegistro_LanFaturamento_Item y)
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

    public class TRegistro_LanFaturamento_Item
    {
        public string Cd_empresa
        {
            get;
            set;
        }
        public decimal Nr_lanctofiscal
        {
            get;
            set;
        }
        public decimal Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public decimal Id_nfitem
        {
            get;
            set;
        }
        private decimal? id_pedidoitem;
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                if (value.HasValue)
                    id_pedidoitemstr = value.Value.ToString();
                else
                    id_pedidoitemstr = string.Empty;
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
                    id_pedidoitem = Convert.ToDecimal(value);
                }
                catch
                { id_pedidoitem = null; }
            }
        }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_local
        {
            get;
            set;
        }
        public string Lote
        {
            get;
            set;
        }
        private decimal quantidade;
        public decimal Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                if ((vl_unitario > 0) &&
                    (!string.IsNullOrEmpty(cd_unidade)) &&
                    (!string.IsNullOrEmpty(cd_unidEst)))
                {
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2, MidpointRounding.AwayFromZero);
                    //Calculo do Desconto
                    if ((vl_subtotal > 0) && (pc_desconto > 0))
                        vl_desconto = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar(((pc_desconto * vl_subtotal) / 100), 5) :
                            Math.Round(((pc_desconto * vl_subtotal) / 100), 5, MidpointRounding.AwayFromZero);
                    else
                        vl_desconto = decimal.Zero;
                    //Calculo do Juro
                    if ((vl_subtotal > 0) && (pc_juro_fin > 0))
                        vl_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2) :
                            Math.Round((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
                    if ((value > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                        pc_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((vl_juro_fin * 100) / (Vl_subtotal - vl_desconto), 2) :
                            Math.Round((vl_juro_fin * 100) / (Vl_subtotal - vl_desconto), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
        public decimal Quantidade_estoque
        { get; set; }
        private string cd_unidade;
        public string Cd_unidade
        {
            get { return cd_unidade; }
            set
            {
                cd_unidade = value;
                if ((quantidade > decimal.Zero) &&
                    (vl_unitario > decimal.Zero) &&
                    (!string.IsNullOrEmpty(cd_unidade)) &&
                    (!string.IsNullOrEmpty(cd_unidEst)))
                {
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2, MidpointRounding.AwayFromZero);
                    //Calculo do Desconto
                    if ((vl_subtotal > 0) && (pc_desconto > 0))
                        vl_desconto = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((pc_desconto * vl_subtotal) / 100, 5) :
                            Math.Round((pc_desconto * vl_subtotal) / 100, 5, MidpointRounding.AwayFromZero);
                    else
                        vl_desconto = decimal.Zero;
                    //Calculo do Juro
                    if ((vl_subtotal > 0) && (pc_juro_fin > 0))
                        vl_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2) :
                            Math.Round((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
                    if ((vl_subtotal > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                        pc_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2) :
                            Math.Round((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
        private string cd_unidEst;
        public string Cd_unidEst
        {
            get { return cd_unidEst; }
            set
            {
                cd_unidEst = value;
                if ((quantidade > decimal.Zero) &&
                    (vl_unitario > decimal.Zero) &&
                    (!string.IsNullOrEmpty(cd_unidade)) &&
                    (!string.IsNullOrEmpty(cd_unidEst)))
                {
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2, MidpointRounding.AwayFromZero);
                    //Calculo do Desconto
                    if ((vl_subtotal > 0) && (pc_desconto > 0))
                        vl_desconto = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((pc_desconto * vl_subtotal) / 100, 5) :
                            Math.Round((pc_desconto * vl_subtotal) / 100, 5, MidpointRounding.AwayFromZero);
                    else
                        vl_desconto = decimal.Zero;
                    //Calculo do Juro
                    if ((vl_subtotal > 0) && (pc_juro_fin > 0))
                        vl_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2) :
                            Math.Round((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
                    if ((vl_subtotal > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                        pc_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2) :
                            Math.Round((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set
            {
                vl_unitario = Math.Round(value, 7, MidpointRounding.AwayFromZero);
                if ((quantidade > 0) &&
                    (vl_unitario > 0) &&
                    (!string.IsNullOrEmpty(cd_unidade)) &&
                    (!string.IsNullOrEmpty(cd_unidEst)))
                {
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidEst, Cd_unidade, quantidade * vl_unitario), 2, MidpointRounding.AwayFromZero);
                    //Calculo do Desconto
                    if ((vl_subtotal > 0) && (pc_desconto > 0))
                        vl_desconto = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((pc_desconto * vl_subtotal) / 100, 5) :
                            Math.Round((pc_desconto * vl_subtotal) / 100, 5, MidpointRounding.AwayFromZero);
                    else
                        vl_desconto = decimal.Zero;
                    //Calculo do Juro
                    if ((vl_subtotal > 0) && (pc_juro_fin > 0))
                        vl_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (vl_subtotal - vl_desconto)) / 100, 2) :
                            Math.Round((Math.Round(pc_juro_fin, 2) * (vl_subtotal - vl_desconto)) / 100, 2);
                    if ((vl_subtotal > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                        pc_juro_fin = Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2) :
                            Math.Round((vl_juro_fin * 100) / (vl_subtotal - vl_desconto), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
        public decimal Vl_unitCusto
        { get; set; }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return vl_subtotal; }
            set
            {
                vl_subtotal = Math.Round(value, 2, MidpointRounding.AwayFromZero);
                if ((quantidade > decimal.Zero) &&
                    (vl_unitario.Equals(decimal.Zero)) &&
                    (!string.IsNullOrEmpty(cd_unidade)) &&
                    (!string.IsNullOrEmpty(cd_unidEst)))
                    vl_unitario = Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidade, Cd_unidEst, vl_subtotal / quantidade), 7, MidpointRounding.AwayFromZero);

                //Calculo do Desconto
                if ((value > decimal.Zero) && (pc_desconto > decimal.Zero))
                    vl_desconto = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar((pc_desconto * value) / 100, 5) :
                        Math.Round((pc_desconto * value) / 100, 5, MidpointRounding.AwayFromZero);
                else
                    vl_desconto = decimal.Zero;
                //Calculo do Juro
                if ((value > decimal.Zero) && (pc_juro_fin > decimal.Zero))
                    vl_juro_fin = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (value - vl_desconto)) / 100, 2) :
                        Math.Round((Math.Round(pc_juro_fin, 2, MidpointRounding.AwayFromZero) * (value - vl_desconto)) / 100, 2);
                //Calculo Outras Despesas
                if ((value > decimal.Zero) && (pc_outrasdesp > decimal.Zero))
                    vl_outrasdesp = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar((pc_outrasdesp * value) / 100, 2) :
                        Math.Round((pc_outrasdesp * value) / 100, 2, MidpointRounding.AwayFromZero);
                else
                    vl_outrasdesp = decimal.Zero;
                if ((value > decimal.Zero) && (vl_juro_fin > decimal.Zero) && (vl_desconto > decimal.Zero))
                    pc_juro_fin = Math.Round((vl_juro_fin * 100) / (value - vl_desconto), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal Vl_custoItem
        { get { return quantidade * Vl_unitCusto; } }
        public decimal Vl_subtotal_estoque
        {
            get;
            set;
        }
        private decimal pc_desconto;
        public decimal Pc_desconto
        {
            get { return pc_desconto; }
            set
            {
                pc_desconto = value;
                vl_desconto = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((value * vl_subtotal) / 100, 5) :
                    Math.Round((value * vl_subtotal) / 100, 5, MidpointRounding.AwayFromZero);
                vl_juro_fin = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((value * (vl_subtotal - vl_desconto)) / 100, 2) :
                    Math.Round((value * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
                if ((vl_subtotal > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                    pc_juro_fin = Math.Round(((vl_juro_fin * 100) / Math.Round(vl_subtotal - vl_desconto, 2)), 2, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_desconto, 5) : Math.Round(vl_desconto, 5); }
            set
            {
                vl_desconto = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 5) : Math.Round(value, 5);
                if (vl_subtotal > 0)
                    pc_desconto = (vl_desconto / vl_subtotal) * 100;
                vl_juro_fin = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((value * (vl_subtotal - vl_desconto)) / 100, 2) :
                    Math.Round((value * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
                if ((vl_subtotal > 0) && (vl_juro_fin > 0) && (vl_desconto > 0))
                    pc_juro_fin = Math.Round(((vl_juro_fin * 100) / Math.Round(vl_subtotal - vl_desconto, 2)), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal Vl_comissao
        { get; set; }
        public string Cd_produto
        {
            get;
            set;
        }
        public string Cd_produto_fornecedor
        { get; set; }
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
        private decimal vl_freteitem;
        public decimal Vl_freteitem
        {
            get { return vl_freteitem; }
            set { vl_freteitem = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        private decimal pc_juro_fin;
        public decimal Pc_juro_fin
        {
            get { return pc_juro_fin; }
            set
            {
                pc_juro_fin = value;
                vl_juro_fin = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((value * (vl_subtotal - vl_desconto)) / 100, 2) :
                    Math.Round((value * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_juro_fin;
        public decimal Vl_juro_fin
        {
            get { return vl_juro_fin; }
            set
            {
                vl_juro_fin = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar(value, 2) :
                    Math.Round(value, 2, MidpointRounding.AwayFromZero);
                if ((Vl_subtotal > decimal.Zero) && (value > decimal.Zero))
                    pc_juro_fin = Math.Round(((Math.Round(vl_juro_fin, 2) * 100) / Math.Round(Vl_subtotal, 2)), 2, MidpointRounding.AwayFromZero);
                else pc_juro_fin = decimal.Zero;
            }
        }
        private decimal pc_outrasdesp;
        public decimal Pc_outrasdesp
        {
            get { return pc_outrasdesp; }
            set
            {
                pc_outrasdesp = value;
                vl_outrasdesp = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((value * (vl_subtotal - vl_desconto)) / 100, 2) :
                    Math.Round((value * (vl_subtotal - vl_desconto)) / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_outrasdesp;
        public decimal Vl_outrasdesp
        {
            get { return vl_outrasdesp; }
            set
            {
                vl_outrasdesp = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2, MidpointRounding.AwayFromZero);
                if ((vl_subtotal > decimal.Zero) && (value > decimal.Zero))
                    pc_outrasdesp = Math.Round(((Math.Round(vl_outrasdesp, 2, MidpointRounding.AwayFromZero) * 100) / Math.Round(vl_subtotal, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero);
                else
                    pc_outrasdesp = decimal.Zero;
            }
        }
        public decimal Vl_seguro
        { get; set; }
        public string St_servico
        {
            get;
            set;
        }
        public string Observacao_item
        {
            get;
            set;
        }
        public decimal? Id_lotectb_fat
        { get; set; }
        public decimal? Id_lotectb_cmv
        { get; set; }
        public decimal? Cd_contactb_sped
        { get; set; }
        public string Nm_empresa
        {
            get;
            set;
        }
        public string Ds_local
        {
            get;
            set;
        }
        public string Ds_produto
        {
            get;
            set;
        }
        public string Ds_situacao
        {
            get;
            set;
        }
        public string Ds_unidade
        {
            get;
            set;
        }
        public string Sigla_unidade
        {
            get;
            set;
        }
        public string Codigo_Alternativo
        {
            get;
            set;
        }
        public string Cod_barra { get; set; } = string.Empty;
        public string Cd_condfiscal_produto
        {
            get;
            set;
        }
        public string Sigla_unidade_estoque
        {
            get;
            set;
        }
        public decimal Nr_pedido
        {
            get;
            set;
        }
        public string Tp_prodpesagem
        { get; set; }
        public string Tipo_prodpesagem
        {
            get
            {
                if (Tp_prodpesagem.Trim().ToUpper().Equals("CV"))
                    return "CONVENCIONAL";
                else if (Tp_prodpesagem.Trim().ToUpper().Equals("TR"))
                    return "TRANGENICA";
                else if (Tp_prodpesagem.Trim().ToUpper().Equals("ID"))
                    return "INTACTA DECLARADA";
                else if (Tp_prodpesagem.Trim().ToUpper().Equals("IT"))
                    return "INTACTA TESTADA";
                else if (Tp_prodpesagem.Trim().ToUpper().Equals("IP"))
                    return "INTACTA PARTICIPANTE";
                else return string.Empty;
            }
        }
        public decimal Qtd_devolver
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal SaldoDevolver => Quantidade - Qtd_devolvida - Qtd_devolver;
        public decimal Qtd_fixacao
        { get; set; }
        public decimal Saldo_fixar
        {
            get { return Quantidade - Qtd_devolvida - Qtd_fixacao; }
        }
        public decimal Vl_fixacao
        { get; set; }
        public decimal Qtd_fiscaldevolver
        { get; set; }
        public decimal Qtd_fiscaldevolvido
        { get; set; }
        public decimal Sd_qtdfiscaldevolver
        {
            get { return Qtd_fiscaldevolver - Qtd_fiscaldevolvido; }
        }
        public decimal Vl_fiscaldevolver
        { get; set; }
        public decimal Vl_fiscaldevolvido
        { get; set; }
        public decimal Sd_vlfiscaldevolver
        {
            get { return Vl_fiscaldevolver - Vl_fiscaldevolvido; }
        }
        public decimal Qtd_fiscalcomplementar
        { get; set; }
        public decimal Qtd_fiscalcomplemento
        { get; set; }
        public decimal Sd_qtdfiscalcomplementar
        { get { return Qtd_fiscalcomplementar - Qtd_fiscalcomplemento; } }
        public decimal Vl_fiscalcomplementar
        { get; set; }
        public decimal Vl_fiscalcomplemento
        { get; set; }
        public decimal Sd_vlfiscalcomplementar
        { get { return Vl_fiscalcomplementar - Vl_fiscalcomplemento; } }
        public decimal Qtd_origem
        { get; set; }
        public decimal Qtd_sdorigem
        { get { return Quantidade - Qtd_origem; } }
        public decimal Vl_origem
        { get; set; }
        public decimal Vl_sdorigem
        { get { return Vl_subtotal - Vl_origem; } }
        public decimal? Id_apontamento
        { get; set; }
        public decimal Qtd_lotesemente
        { get; set; }
        public decimal Qtd_saldosemente
        {
            get
            {
                return Quantidade - Qtd_lotesemente;
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public string Ds_cfop
        { get; set; }
        public bool St_bonificacao
        { get; set; }
        public bool St_usoconsumo
        { get; set; }
        public bool St_devolucao
        { get; set; }
        public bool St_remessa
        { get; set; }
        public bool St_retorno
        { get; set; }
        private string tp_origem;
        public string Tp_origem
        {
            get { return tp_origem; }
            set
            {
                tp_origem = value;
                if (value.Trim().Equals("0"))
                    tipo_origem = "Nacional";
                else if (value.Trim().Equals("1"))
                    tipo_origem = "Estrangeira - Importação Direta";
                else if (value.Trim().Equals("2"))
                    tipo_origem = "Estrangeira - Adquirada Mercado Interno";
                else if (value.Trim().Equals("3"))
                    tipo_origem = "Nacional - Importação 40% a 70%";
                else if (value.Trim().Equals("4"))
                    tipo_origem = "Nacional - Outros";
                else if (value.Trim().Equals("5"))
                    tipo_origem = "Nacional - Importação <= 40%";
                else if (value.Trim().Equals("6"))
                    tipo_origem = "Estrangeira - Importação Direta sem Similar Nacional";
                else if (value.Trim().Equals("7"))
                    tipo_origem = "Estrangeira - Adquirida Mercado Nacional Sem Similar";
                else if (value.Trim().Equals("8"))
                    tipo_origem = "Nacional - Importação > 70%";
            }
        }
        private string tipo_origem;
        public string Tipo_origem
        {
            get { return tipo_origem; }
            set
            {
                tipo_origem = value;
                if (value.Trim().Equals("Nacional"))
                    tp_origem = "0";
                else if (value.Trim().Equals("Estrangeira - Importação Direta"))
                    tp_origem = "1";
                else if (value.Trim().Equals("Estrangeira - Adquirada Mercado Interno"))
                    tp_origem = "2";
                else if (value.Trim().Equals("Nacional - Importação 40% a 70%"))
                    tp_origem = "3";
                else if (value.Trim().Equals("Nacional - Outros"))
                    tp_origem = "4";
                else if (value.Trim().Equals("Nacional - Importação <= 40%"))
                    tp_origem = "5";
                else if (value.Trim().Equals("Estrangeira - Importação Direta sem Similar Nacional"))
                    tp_origem = "6";
                else if (value.Trim().Equals("Estrangeira - Adquirida Mercado Nacional Sem Similar"))
                    tp_origem = "7";
                else if (value.Trim().Equals("Nacional - Importação > 70%"))
                    tp_origem = "8";
            }
        }
        public decimal Vl_basecalcImposto
        {
            get
            {
                return Parametros.pubTruncarSubTotal ?
            Estruturas.Truncar(vl_subtotal + vl_freteitem + vl_juro_fin + Vl_seguro + vl_outrasdesp - vl_desconto, 2) :
            Math.Round(vl_subtotal + vl_freteitem + vl_juro_fin + Vl_seguro + vl_outrasdesp - vl_desconto, 2, MidpointRounding.AwayFromZero);
            }
        }
        public bool St_somarIPIBaseICMS { get; set; } = false;
        public bool St_somarIPIBaseST { get; set; } = false;

        public TList_LanFat_ComplementoDevolucao lNfcompdev
        {
            get;
            set;
        }
        public TRegistro_LanFaturamento rNotafiscal
        {
            get;
            set;
        }
        public TList_TransfLocal lTransf
        { get; set; }
        public TList_EntregaPedido lEntrega
        { get; set; }
        public TList_OSE_SerialClifor Serial
        { get; set; }
        public TList_Lan_Originacao_x_Faturamento lOriginacao_x_Faturamento { get; set; }
        public TRegistro_LanEstoque rEstoque;
        public decimal Vl_complementoEstoqueCTRC
        { get; set; }
        public TList_LoteSemente_X_NFItem lLoteSemente
        { get; set; }
        public TList_LoteSemente_X_NFItem lLoteNfOrigem
        { get; set; }
        public TList_RegLanPesagemGraos lTicketAplicar
        { get; set; }
        public TRegistro_ItensCondicional rItemCondicional
        { get; set; }
        public TRegistro_FichaTec rItemFichaTec
        { get; set; }
        public TRegistro_NFCe_Item rItemCF
        { get; set; }
        public Entrega.TList_ItensCargaAvulsa lItensCargaAvulsa
        { get; set; }
        public TList_DeclaracaoImport ldi
        {
            get;
            set;
        }
        public TList_MovRastreabilidade lMov
        { get; set; }
        public Estoque.Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Estoque.Cadastros.TList_ValorCaracteristica();
        //Campo utilizado pela nfe
        public string Cd_anp
        { get; set; }
        public string Ds_anp { get; set; } = string.Empty;
        public string Cd_ncm
        { get; set; }
        public string Cest
        { get; set; }
        public decimal Pc_imposto_Aprox
        { get; set; }
        public decimal Vl_imposto_Aprox
        {
            get
            {
                return Parametros.pubTruncarSubTotal ?
            Estruturas.Truncar(Vl_basecalcImposto * Math.Round(Pc_imposto_Aprox, 2, MidpointRounding.AwayFromZero) / 100, 2) :
            Math.Round(Vl_basecalcImposto * Math.Round(Pc_imposto_Aprox, 2, MidpointRounding.AwayFromZero) / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal Pc_aliquotasimples
        { get; set; }
        public string Id_tpservico
        { get; set; }
        public decimal Qtd_totalconferencia
        {
            get; set;
        }
        public decimal Qtd_difFatConf
        {
            get
            {
                return Quantidade - Qtd_totalconferencia;
            }
        }
        public bool St_atualizaprecovenda
        { get; set; }
        public bool St_processar
        { get; set; }
        public bool St_movEstoque
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public decimal Vl_ImpCustoEst
        {
            get
            {
                return Vl_ICMSST +
                        (St_totalnotaCofins.Trim().ToUpper().Equals("S") ? Vl_cofins : decimal.Zero) +
                        (St_totalnotaIPI.Trim().ToUpper().Equals("S") ? Vl_ipi : decimal.Zero) +
                        (St_totalnotaISS.Trim().ToUpper().Equals("S") ? Vl_iss : decimal.Zero) +
                        (St_totalnotaPIS.Trim().ToUpper().Equals("S") ? Vl_pis : decimal.Zero) -
                        (St_gerarcreditoCofins ? Vl_cofins : decimal.Zero) -
                        (St_gerarcreditoICMS ? Vl_icms : decimal.Zero) -
                        (St_gerarcreditoIPI ? Vl_ipi : decimal.Zero) -
                        (St_gerarcreditoISS ? Vl_iss : decimal.Zero) -
                        (St_gerarcreditoPIS ? Vl_pis : decimal.Zero);
            }
        }
        #region Fiscal
        public decimal? Cd_ICMS { get; set; } = null;
        public string Cd_ST_ICMS { get; set; } = string.Empty;
        public decimal? Cd_PIS { get; set; } = null;
        public string Cd_ST_PIS { get; set; } = string.Empty;
        public decimal? Cd_COFINS { get; set; } = null;
        public string Cd_ST_COFINS { get; set; } = string.Empty;
        public decimal? Cd_IPI { get; set; } = null;
        public string Cd_ST_IPI { get; set; } = string.Empty;
        public decimal? Id_BaseCreditoPIS { get; set; } = null;
        public decimal? Id_BaseCreditoCofins { get; set; } = null;
        public decimal? Id_TpCredPIS { get; set; } = null;
        public decimal? Id_TpCredCofins { get; set; } = null;
        public decimal? Id_TpContribuicaoPIS { get; set; } = null;
        public decimal? Id_TpContribuicaoCofins { get; set; } = null;
        public decimal? Id_detrecisentaPIS { get; set; } = null;
        public decimal? Id_detrecisentaCofins { get; set; } = null;
        public decimal? Id_receitaPIS { get; set; } = null;
        public decimal? Id_receitaCofins { get; set; } = null;
        public string Tp_imposto { get; set; } = string.Empty;
        public decimal Pc_aliquotaICMS { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaPIS { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaCofins { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaIPI { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaISS { get; set; } = decimal.Zero;
        public decimal Pc_retencaoICMS { get; set; } = decimal.Zero;
        public decimal Pc_retencaoISS { get; set; } = decimal.Zero;
        public decimal Vl_ICMSRetido { get; set; } = decimal.Zero;
        public decimal Vl_icms { get; set; } = decimal.Zero;
        public decimal Vl_pis { get; set; } = decimal.Zero;
        public decimal Vl_cofins { get; set; } = decimal.Zero;
        public decimal Vl_ipi { get; set; } = decimal.Zero;
        public decimal Vl_iss { get; set; } = decimal.Zero;
        public decimal Vl_issretido { get; set; } = decimal.Zero;
        public decimal Vl_basecalcICMS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcPIS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcCofins { get; set; } = decimal.Zero;
        public decimal Vl_basecalcIPI { get; set; } = decimal.Zero;
        public decimal Vl_basecalcISS { get; set; } = decimal.Zero;
        public bool St_gerarcreditoICMS { get; set; } = false;
        public bool St_gerarcreditoPIS { get; set; } = false;
        public bool St_gerarcreditoCofins { get; set; } = false;
        public bool St_gerarcreditoIPI { get; set; } = false;
        public bool St_gerarcreditoISS { get; set; } = false;
        public decimal Vl_basecalcSTICMS { get; set; } = decimal.Zero;
        public decimal Vl_ICMSST { get; set; } = decimal.Zero;
        public decimal Pc_reducaobasecalcICMS { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaSTICMS { get; set; } = decimal.Zero;
        public decimal Pc_redbcstICMS { get; set; } = decimal.Zero;
        public decimal Pc_diferidoICMS { get; set; } = decimal.Zero;
        public decimal Vl_diferidoICMS { get; set; } = decimal.Zero;
        public string Tp_situacao { get; set; } = string.Empty;
        public string St_totalnotaPIS { get; set; } = string.Empty;
        public string St_totalnotaCofins { get; set; } = string.Empty;
        public string St_totalnotaIPI { get; set; } = "S";
        public string St_totalnotaISS { get; set; } = string.Empty;
        public decimal Vl_imposto_unit_PIS { get; set; } = decimal.Zero;
        public decimal Vl_imposto_unit_Cofins { get; set; } = decimal.Zero;
        public decimal Vl_imposto_unit_ipi { get; set; } = decimal.Zero;
        public decimal Vl_difal { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaICMSDest { get; set; } = decimal.Zero;
        public decimal Pc_aliqopdifal { get; set; } = decimal.Zero;
        public string Ds_deducao { get; set; } = string.Empty;
        public decimal Pc_FCP { get; set; } = decimal.Zero;
        public decimal Vl_FCP { get; set; } = decimal.Zero;
        public decimal Pc_FCPST { get; set; } = decimal.Zero;
        public decimal Vl_FCPST { get; set; } = decimal.Zero;
        public decimal Vl_pauta { get; set; } = decimal.Zero;
        public decimal Pc_iva_st { get; set; } = decimal.Zero;
        public decimal Vl_mva { get; set; } = decimal.Zero;
        public string Tp_tributISS { get; set; } = string.Empty;
        public string Tp_naturezaOperacaoISS { get; set; } = string.Empty;
        public decimal Pc_retencaoPIS { get; set; } = decimal.Zero;
        public decimal Pc_retencaoCofins { get; set; } = decimal.Zero;
        public decimal Pc_retencaoIRRF { get; set; } = decimal.Zero;
        public decimal Pc_retencaoCSLL { get; set; } = decimal.Zero;
        public decimal Pc_retencaoINSS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcIRRF { get; set; } = decimal.Zero;
        public decimal Vl_basecalcCSLL { get; set; } = decimal.Zero;
        public decimal Vl_basecalcINSS { get; set; } = decimal.Zero;
        public decimal Vl_retidoPIS { get; set; } = decimal.Zero;
        public decimal Vl_retidoCofins { get; set; } = decimal.Zero;
        public decimal Vl_retidoIRRF { get; set; } = decimal.Zero;
        public decimal Vl_retidoCSLL { get; set; } = decimal.Zero;
        public decimal Vl_retidoINSS { get; set; } = decimal.Zero;
        public decimal Vl_basecalcFunrural { get; set; } = decimal.Zero;
        public decimal Vl_basecalcSenar { get; set; } = decimal.Zero;
        public decimal Pc_funrural { get; set; } = decimal.Zero;
        public decimal Pc_senar { get; set; } = decimal.Zero;
        public decimal Pc_retencaoFunrural { get; set; } = decimal.Zero;
        public decimal Pc_retencaoSenar { get; set; } = decimal.Zero;
        public decimal Vl_funrural { get; set; } = decimal.Zero;
        public decimal Vl_senar { get; set; } = decimal.Zero;
        public decimal Vl_retidoFunrural { get; set; } = decimal.Zero;
        public decimal Vl_retidoSenar { get; set; } = decimal.Zero;
        public decimal Pc_reducaobasecalcISS { get; set; } = decimal.Zero;
        public string Tp_modbasecalc { get; set; } = string.Empty;
        public string Tp_modbasecalcST { get; set; } = string.Empty;
        public decimal Vl_basecalcII { get; set; } = decimal.Zero;
        public decimal Pc_aliquotaII { get; set; } = decimal.Zero;
        public decimal Vl_II { get; set; } = decimal.Zero;

        public decimal PC_IRRF { get; set; } = decimal.Zero;
        public decimal PC_CSLL { get; set; } = decimal.Zero;
        public decimal PC_INSS { get; set; } = decimal.Zero;
        public decimal VL_IRRF { get; set; } = decimal.Zero;
        public decimal VL_CSLL { get; set; } = decimal.Zero;
        public decimal VL_INSS { get; set; } = decimal.Zero;
        public decimal Pc_redbasecalcINSS { get; set; } = decimal.Zero;
        public decimal Pc_redbasecalcCSLL { get; set; } = decimal.Zero;
        public decimal Pc_redbasecalcIRRF { get; set; } = decimal.Zero;
        #endregion

        public TRegistro_LanFaturamento_Item()
        {
            Cd_anp = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_lanctofiscal = decimal.Zero;
            Nr_notafiscal = decimal.Zero;
            Nr_serie = string.Empty;
            Dt_emissao = null;
            Id_nfitem = decimal.Zero;
            Nr_pedido = decimal.Zero;
            Tp_prodpesagem = string.Empty;
            id_pedidoitem = null;
            id_pedidoitemstr = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Codigo_Alternativo = string.Empty;
            Lote = string.Empty;
            quantidade = decimal.Zero;
            Quantidade_estoque = decimal.Zero;
            cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            cd_unidEst = string.Empty;
            vl_unitario = decimal.Zero;
            Vl_unitCusto = decimal.Zero;
            vl_subtotal = decimal.Zero;
            Vl_subtotal_estoque = decimal.Zero;
            Cd_produto = string.Empty;
            Cd_produto_fornecedor = string.Empty;
            Ds_produto = string.Empty;
            id_variedade = null;
            id_variedadestr = string.Empty;
            Ds_variedade = string.Empty;
            Ds_situacao = string.Empty;
            St_servico = string.Empty;
            Observacao_item = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Sigla_unidade_estoque = string.Empty;
            pc_desconto = decimal.Zero;
            vl_desconto = decimal.Zero;
            Vl_comissao = decimal.Zero;
            vl_freteitem = decimal.Zero;
            pc_juro_fin = decimal.Zero;
            vl_juro_fin = decimal.Zero;
            Vl_seguro = decimal.Zero;
            vl_outrasdesp = decimal.Zero;
            Id_lotectb_cmv = null;
            Id_lotectb_fat = null;
            Cd_contactb_sped = null;
            Id_apontamento = null;
            Qtd_fixacao = decimal.Zero;
            Vl_fixacao = decimal.Zero;
            Qtd_origem = decimal.Zero;
            Vl_origem = decimal.Zero;
            Cd_cfop = string.Empty;
            Ds_cfop = string.Empty;
            St_bonificacao = false;
            St_usoconsumo = false;
            St_devolucao = false;
            St_remessa = false;
            St_retorno = false;
            Cd_ncm = string.Empty;
            Cest = string.Empty;
            Pc_imposto_Aprox = decimal.Zero;
            Pc_aliquotasimples = decimal.Zero;
            Qtd_lotesemente = decimal.Zero;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            rNotafiscal = new TRegistro_LanFaturamento();
            //ImpostosItens = new TList_ImpostosNF();
            //ImpDel = new TList_ImpostosNF();
            lNfcompdev = new TList_LanFat_ComplementoDevolucao();
            lTransf = new TList_TransfLocal();
            Serial = new TList_OSE_SerialClifor();
            lOriginacao_x_Faturamento = new TList_Lan_Originacao_x_Faturamento();
            Vl_complementoEstoqueCTRC = decimal.Zero;
            lTicketAplicar = new TList_RegLanPesagemGraos();
            lLoteSemente = new TList_LoteSemente_X_NFItem();
            lLoteNfOrigem = new TList_LoteSemente_X_NFItem();
            ldi = new TList_DeclaracaoImport();
            lMov = new TList_MovRastreabilidade();
            rItemCondicional = null;
            rItemFichaTec = null;
            rItemCF = null;
            lItensCargaAvulsa = new Entrega.TList_ItensCargaAvulsa();
            Qtd_totalconferencia = decimal.Zero;
            St_atualizaprecovenda = false;
            St_processar = false;
            Qtd_fiscaldevolver = decimal.Zero;
            Qtd_fiscaldevolvido = decimal.Zero;
            Vl_fiscaldevolver = decimal.Zero;
            Vl_fiscaldevolvido = decimal.Zero;
            Qtd_fiscalcomplementar = decimal.Zero;
            Qtd_fiscalcomplemento = decimal.Zero;
            Vl_fiscalcomplementar = decimal.Zero;
            Vl_fiscalcomplemento = decimal.Zero;
            Id_tpservico = string.Empty;
            Cd_condpgto = string.Empty;
            St_movEstoque = false;
            tp_origem = "0";
            tipo_origem = "Nacional";

            Qtd_devolvida = decimal.Zero;
            Qtd_devolver = decimal.Zero;
        }
    }

    public class TCD_LanFaturamento_Item : TDataQuery
    {
        public TCD_LanFaturamento_Item()
        { }

        public TCD_LanFaturamento_Item(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, a.Nr_LanctoFiscal, a.ID_NFItem, nf.cd_condpgto, nf.dt_emissao, ")
                .AppendLine("a.CD_Local, a.Lote, a.Quantidade, a.CD_Unidade, c.CD_Unidade as CD_UnidEst, cond.ds_condpgto, ")
                .AppendLine("nf.CD_Clifor, vClifor.NM_Clifor, nf.NR_NotaFiscal, nf.nr_serie, a.nr_pedido, a.id_pedidoitem, a.id_apontamento, ")
                .AppendLine("a.Vl_Unitario, a.Vl_SubTotal, a.CD_Produto, tpprod.ST_Servico, a.Observacao_Item, a.vl_comissao, ")
                .AppendLine("b.NM_Empresa, c.CD_CondFiscal_produto, a.vl_desconto, a.vl_freteitem, a.id_lotectb_fat, a.id_lotectb_cmv, ")
                .AppendLine("f.DS_Local, c.DS_Produto, c.Codigo_Alternativo, e.DS_Unidade, e.Sigla_Unidade, a.id_variedade, vr.ds_variedade, ")
                .AppendLine("a.vl_juro_fin, a.vl_seguro, a.vl_outrasdesp, a.PC_Imposto_Aprox, a.PC_AliquotaSimples, ")
                .AppendLine("undest.Sigla_Unidade as sigla_unidade_estoque, a.Quantidade_estoque, ")
                .AppendLine("a.vl_contabil, a.Qtd_devolvida, a.Qtd_fixacao, a.Vl_fixacao, a.Qtd_lotesemente, c.cd_anp, anp.ds_anp, ")
                .AppendLine("a.qtd_fiscaldevolver, a.qtd_fiscaldevolvido, c.ncm, nc.cest, ")
                .AppendLine("a.vl_fiscaldevolver, a.vl_fiscaldevolvido, nf.dt_emissao, ")
                .AppendLine("a.qtd_fiscalcomplementar, a.qtd_fiscalcomplemento, ")
                .AppendLine("a.vl_fiscalcomplementar, a.vl_fiscalcomplemento, ")
                .AppendLine("a.cd_cfop, cfop.ds_cfop, cfop.st_bonificacao, cfop.st_usoconsumo, cfop.st_retorno, ")
                .AppendLine("cfop.st_devolucao, cfop.st_remessa, a.qtd_origem, a.vl_origem, c.id_tpservico, a.tp_origem, ")
                .AppendLine("ped.cd_vendedor, vend.nm_clifor as nomevendedor, isnull(nfcmi.st_geraestoque, 'N') as ST_MovEstoque, ")
                .AppendLine("Cod_barra = (select top 1 x.cd_codbarra from tb_est_codbarra x where x.cd_produto = c.cd_produto), ")
                .AppendLine("Tp_prodpesagem =  isnull((select top 1 x.TP_ProdPesagem from TB_BAL_Psgraos x ")
                .AppendLine("                         inner join TB_BAL_Aplicacao_Pedido y ")
                .AppendLine("                         on x.cd_empresa = y.cd_empresa ")
                .AppendLine("                         and x.id_ticket = y.id_ticket ")
                .AppendLine("                         and x.tp_pesagem =  y.tp_pesagem ")
                .AppendLine("                         inner join TB_FAT_Aplicacao_X_NotaFiscal k ")
                .AppendLine("                         on y.id_aplicacao = k.id_aplicacao ")
                .AppendLine("                         where k.cd_empresa = a.cd_empresa ")
                .AppendLine("                         and k.nr_lanctofiscal = a.nr_lanctofiscal ")
                .AppendLine("                         and k.ID_NFItem = a.ID_NFItem ), ''), ")
                .AppendLine("cd_contactb_sped = (select x.cd_conta_ctb from TB_CTB_LanctosCTB x ")
                .AppendLine("                    where x.id_loteCTB = a.id_lotectb_fat ")
                .AppendLine("                    and x.d_c = case when nf.tp_movimento = 'E' then 'D' else 'C' end), ")
                //Fiscal
                .AppendLine("a.CD_ICMS, a.CD_ST_ICMS, a.CD_PIS, a.CD_ST_PIS, a.CD_COFINS, a.CD_ST_COFINS, ")
                .AppendLine("a.CD_IPI, a.CD_ST_IPI, a.ID_BASECREDITOPIS, a.ID_BASECREDITOCOFINS, ")
                .AppendLine("a.ID_TPCREDPIS, a.ID_TPCREDCOFINS, a.ID_TPCONTRIBUICAOPIS, a.ID_TPCONTRIBUICAOCOFINS, ")
                .AppendLine("a.ID_DETRECISENTAPIS, a.ID_DETRECISENTACOFINS, a.ID_RECEITAPIS, a.ID_RECEITACOFINS, ")
                .AppendLine("a.TP_IMPOSTO, a.PC_ALIQUOTAICMS, a.PC_ALIQUOTAPIS, a.PC_ALIQUOTACOFINS, a.PC_ALIQUOTAIPI, ")
                .AppendLine("a.PC_ALIQUOTAISS, a.PC_RETENCAOICMS, a.PC_RETENCAOISS, a.VL_ICMSRETIDO, a.VL_ICMS, ")
                .AppendLine("a.VL_PIS, a.VL_COFINS, a.VL_IPI, a.VL_ISS, a.VL_ISSRETIDO, a.VL_BASECALCICMS, ")
                .AppendLine("a.VL_BASECALCPIS, a.VL_BASECALCCOFINS, a.VL_BASECALCIPI, a.VL_BASECALCISS, ")
                .AppendLine("a.ST_GERARCREDITOICMS, a.ST_GERARCREDITOPIS, a.ST_GERARCREDITOCOFINS, ")
                .AppendLine("a.ST_GERARCREDITOIPI, a.ST_GERARCREDITOISS, a.VL_BASECALCSTICMS, ")
                .AppendLine("a.VL_ICMSST, a.PC_REDUCAOBASECALCICMS, a.PC_ALIQUOTASTICMS, a.PC_REDBCSTICMS, ")
                .AppendLine("a.PC_DIFERIDOICMS, a.VL_DIFERIDOICMS, a.TP_SITUACAO, a.ST_TOTALNOTAPIS, a.ST_TOTALNOTACOFINS, ")
                .AppendLine("a.ST_TOTALNOTAIPI, a.ST_TOTALNOTAISS, a.VL_IMPOSTO_UNIT_PIS, a.VL_IMPOSTO_UNIT_COFINS, ")
                .AppendLine("a.VL_DIFAL, a.PC_ALIQUOTAICMSDEST, a.PC_AliqOpDifal, a.DS_DEDUCAO, a.PC_FCP, a.VL_FCP, ")
                .AppendLine("a.PC_FCPST, a.VL_FCPST, a.VL_PAUTA, a.PC_IVA_ST, a.Vl_MVA, ")
                .AppendLine("a.TP_TRIBUTISS, a.TP_NATUREZAOPERACAOISS, a.VL_IMPOSTO_UNIT_IPI, ")
                .AppendLine("a.Pc_retencaoPIS, a.Pc_retencaoCofins, a.Pc_retencaoIRRF, ")
                .AppendLine("a.Pc_retencaoCSLL, a.Pc_retencaoINSS, a.Vl_basecalcIRRF, ")
                .AppendLine("a.Vl_basecalcCSLL, a.Vl_basecalcINSS, a.Vl_retidoPIS, ")
                .AppendLine("a.Vl_retidoCofins, a.Vl_retidoIRRF, a.vl_retidoCSLL, ")
                .AppendLine("a.vl_retidoINSS, a.Vl_basecalcFunrural, a.Vl_basecalcSenar, ")
                .AppendLine("a.Pc_funrural, a.Pc_Senar, a.Pc_retencaoFunrural, a.Pc_retencaoSenar, ")
                .AppendLine("a.Vl_funrural, a.Vl_senar, a.Vl_retidoFunrural, a.Vl_retidoSenar, ")
                .AppendLine("a.TP_ModBaseCalc, a.TP_ModBaseCalcST, a.ST_SomarIPIBaseICMS, a.ST_SomarIPIBaseST, ")
                .AppendLine("a.Pc_ReducaoBaseCalcISS, a.Vl_BaseCalcII, a.Pc_AliquotaII, a.Vl_II, ")
                .AppendLine("a.PC_IRRF, a.PC_CSLL, a.PC_INSS, a.VL_IRRF, a.VL_CSLL, a.VL_INSS, ")
                .AppendLine("a.PC_RedBaseCalcINSS, a.PC_RedBaseCalcCSLL, a.PC_RedBaseCalcIRRF ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("FROM VTB_FAT_NOTAFISCAL_ITEM a  ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal nf ");
            sql.AppendLine("On a.CD_Empresa = nf.CD_Empresa ");
            sql.AppendLine("and a.NR_LanctoFiscal = nf.NR_LanctoFiscal ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI nfcmi ");
            sql.AppendLine("on nf.cd_empresa = nfcmi.cd_empresa ");
            sql.AppendLine("and nf.nr_lanctofiscal = nfcmi.nr_lanctofiscal ");
            sql.AppendLine("left outer join tb_fin_condpgto cond ");
            sql.AppendLine("on nf.cd_condpgto = cond.cd_condpgto ");
            sql.AppendLine("left outer join TB_FIN_Clifor vClifor ");
            sql.AppendLine("On vClifor.CD_Clifor = nf.CD_Clifor ");
            sql.AppendLine("left outer JOIN TB_EST_LocalArm f ");
            sql.AppendLine("ON a.CD_Local = f.CD_Local ");
            sql.AppendLine("INNER JOIN TB_EST_Unidade e ");
            sql.AppendLine("ON a.CD_Unidade = e.CD_Unidade  ");
            sql.AppendLine("INNER JOIN TB_EST_Produto c ");
            sql.AppendLine("ON a.CD_Produto = c.CD_Produto  ");
            sql.AppendLine("INNER JOIN TB_EST_Unidade undest ");
            sql.AppendLine("ON c.cd_unidade = undest.cd_unidade ");
            sql.AppendLine("INNER JOIN TB_DIV_Empresa b ");
            sql.AppendLine("ON a.CD_Empresa = b.CD_Empresa  ");
            sql.AppendLine("INNER JOIN TB_EST_TpProduto tpprod ");
            sql.AppendLine("ON c.tp_produto = tpprod.tp_produto ");
            sql.AppendLine("left outer join TB_FIS_CMI m ");
            sql.AppendLine("ON nf.CD_CMI = m.CD_CMI ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIS_CFOP cfop ");
            sql.AppendLine("on a.cd_cfop = cfop.cd_cfop ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_TipoServico tpserv ");
            sql.AppendLine("ON c.id_tpservico = tpserv.id_tpservico ");
            sql.AppendLine("LEFT OUTER JOIN TB_FAT_DadosPedido ped ");
            sql.AppendLine("ON a.nr_pedido = ped.nr_pedido ");
            sql.AppendLine("LEFT OUTER JOIN tb_fin_clifor vend ");
            sql.AppendLine("ON ped.cd_vendedor = vend.cd_clifor ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIS_NCM nc ");
            sql.AppendLine("on c.ncm = nc.ncm ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_Variedade vr ");
            sql.AppendLine("on a.cd_produto = vr.cd_produto ");
            sql.AppendLine("and a.id_variedade = vr.id_variedade ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_ANP anp ");
            sql.AppendLine("on c.cd_anp = anp.cd_anp ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine("group by " + vGroup.Trim());
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());

            return sql.ToString();
        }

        private string SqlCodeBuscaDetalhesUltimasCompras(TpBusca[] filtro, int vTop)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select " + strTop + " a.Nr_NotaFiscal, a.cd_clifor, c.NM_Clifor, c.NM_Fantasia, ");
            sql.AppendLine("a.DT_Emissao, a.CD_CondPGTO, d.DS_CondPGTO, g.Sigla_Unidade, ");
            sql.AppendLine("Quantidade = b.Quantidade + ISNULL((select sum(isnull(x.Quantidade, 0)) ");
            sql.AppendLine("                                    from TB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("									inner join TB_FAT_CompDevol_NF y ");
            sql.AppendLine("									on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("									and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal_Destino ");
            sql.AppendLine("									and x.ID_NFItem = y.ID_NFItem_Destino ");
            sql.AppendLine("									where y.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("									and y.Nr_LanctoFiscal_Origem = b.Nr_LanctoFiscal ");
            sql.AppendLine("									and y.ID_NFItem_Origem = b.ID_NFItem ");
            sql.AppendLine("									and y.TP_Operacao = 'C'), 0), ");
            sql.AppendLine("Vl_SubTotal = b.Vl_SubTotal + ISNULL((select sum(isnull(x.Vl_SubTotal, 0)) ");
            sql.AppendLine("                                    from VTB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("									inner join TB_FAT_CompDevol_NF y ");
            sql.AppendLine("									on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("									and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal_Destino ");
            sql.AppendLine("									and x.ID_NFItem = y.ID_NFItem_Destino ");
            sql.AppendLine("									where y.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("									and y.Nr_LanctoFiscal_Origem = b.Nr_LanctoFiscal ");
            sql.AppendLine("									and y.ID_NFItem_Origem = b.ID_NFItem ");
            sql.AppendLine("									and y.TP_Operacao = 'C'), 0), ");
            sql.AppendLine("Vl_Contabil = b.Vl_Contabil + ISNULL((select SUM(ISNULL(y.Vl_Subtotal, 0)) ");
            sql.AppendLine("									from TB_CTR_Estoque x ");
            sql.AppendLine("									inner join TB_EST_Estoque y ");
            sql.AppendLine("									on y.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("									and x.CD_Produto = y.CD_Produto ");
            sql.AppendLine("									and x.Id_LanctoEstoque = y.Id_LanctoEstoque ");
            sql.AppendLine("                                    inner join TB_CTR_NotaFiscal z ");
            sql.AppendLine("                                    on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("									and x.NR_LanctoCTR = z.NR_LanctoCTR ");
            sql.AppendLine("									and x.ID_Nota = z.ID_Nota ");
            sql.AppendLine("									where x.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("									and z.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("									and x.CD_Produto = b.CD_Produto), 0) + ");
            sql.AppendLine("								ISNULL((select SUM(ISNULL(x.Vl_Contabil, 0)) ");
            sql.AppendLine("                                    from VTB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("									inner join TB_FAT_CompDevol_NF y ");
            sql.AppendLine("									on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("									and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal_Destino ");
            sql.AppendLine("									and x.ID_NFItem = y.ID_NFItem_Destino ");
            sql.AppendLine("									where y.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("									and y.Nr_LanctoFiscal_Origem = b.Nr_LanctoFiscal ");
            sql.AppendLine("									and y.ID_NFItem_Origem = b.Nr_LanctoFiscal ");
            sql.AppendLine("									and y.TP_Operacao = 'C'), 0) ");

            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join vtb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_clifor = c.CD_Clifor ");
            sql.AppendLine("left outer join TB_FIN_CondPGTO d ");
            sql.AppendLine("on a.CD_CondPGTO = d.CD_CondPGTO ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI e ");
            sql.AppendLine("on a.CD_Empresa = e.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = e.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto f ");
            sql.AppendLine("on b.CD_Produto = f.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade g ");
            sql.AppendLine("on f.CD_Unidade = g.CD_Unidade ");
            string cond = " Where ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("order by a.dt_saient desc ");

            return sql.ToString();
        }

        private string SqlCodeBuscaVendasMes(TpBusca[] filtro, int vTop)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select " + strTop + " YEAR(a.DT_Emissao) as ano, ");
            sql.AppendLine("MONTH(a.DT_Emissao) as mes, e.Sigla_Unidade, ");
            sql.AppendLine("SUM(isnull(est.QTD_Saida, 0)) as quantidade ");
            sql.AppendLine("from tb_fat_notafiscal a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = c.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item_X_Estoque f ");
            sql.AppendLine("on b.CD_Empresa = f.CD_Empresa ");
            sql.AppendLine("and b.Nr_LanctoFiscal = f.Nr_LanctoFiscal ");
            sql.AppendLine("and b.ID_NFItem = f.ID_NFItem ");
            sql.AppendLine("inner join TB_EST_Estoque est ");
            sql.AppendLine("on f.CD_Empresa = est.CD_Empresa ");
            sql.AppendLine("and f.CD_Produto = est.CD_Produto ");
            sql.AppendLine("and f.Id_LanctoEstoque = est.Id_LanctoEstoque ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on b.CD_Produto = d.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on d.CD_Unidade = e.CD_Unidade ");

            string cond = " Where ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by YEAR(a.DT_Emissao), MONTH(a.DT_Emissao), e.Sigla_Unidade ");
            sql.AppendLine("order by YEAR(a.DT_Emissao) desc, MONTH(a.DT_Emissao) desc ");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public TList_RegLanFaturamento_Item Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder));
            TList_RegLanFaturamento_Item lista = new TList_RegLanFaturamento_Item();
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanFaturamento_Item reg = new TRegistro_LanFaturamento_Item();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Local"))))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_variedade")))
                        reg.Id_variedade = reader.GetDecimal(reader.GetOrdinal("id_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                        reg.Ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Unidade"))))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade"))))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo"))))
                        reg.Codigo_Alternativo = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cod_barra")))
                        reg.Cod_barra = reader.GetString(reader.GetOrdinal("Cod_barra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TpServico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("ID_TpServico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NfItem"))))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NfItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Lote"))))
                        reg.Lote = reader.GetString(reader.GetOrdinal("Lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Observacao_Item"))))
                        reg.Observacao_item = reader.GetString(reader.GetOrdinal("Observacao_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade_estoque")))
                        reg.Quantidade_estoque = reader.GetDecimal(reader.GetOrdinal("Quantidade_estoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Servico"))))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("ST_Servico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contabil")))
                        reg.Vl_unitCusto = reader.GetDecimal(reader.GetOrdinal("vl_contabil"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto"))))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade_Estoque"))))
                        reg.Sigla_unidade_estoque = reader.GetString(reader.GetOrdinal("Sigla_Unidade_Estoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_UnidEst"))))
                        reg.Cd_unidEst = reader.GetString(reader.GetOrdinal("CD_UnidEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FreteItem")))
                        reg.Vl_freteitem = reader.GetDecimal(reader.GetOrdinal("Vl_FreteItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Juro_Fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("Vl_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_seguro")))
                        reg.Vl_seguro = reader.GetDecimal(reader.GetOrdinal("vl_seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_outrasdesp")))
                        reg.Vl_outrasdesp = reader.GetDecimal(reader.GetOrdinal("vl_outrasdesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB_Fat")))
                        reg.Id_lotectb_fat = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB_Fat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB_CMV")))
                        reg.Id_lotectb_cmv = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB_CMV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_fixacao")))
                        reg.Qtd_fixacao = reader.GetDecimal(reader.GetOrdinal("Qtd_fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_fixacao")))
                        reg.Vl_fixacao = reader.GetDecimal(reader.GetOrdinal("Vl_fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_lotesemente")))
                        reg.Qtd_lotesemente = reader.GetDecimal(reader.GetOrdinal("Qtd_lotesemente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_prodpesagem"))))
                        reg.Tp_prodpesagem = reader.GetString(reader.GetOrdinal("Tp_prodpesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_fiscalcomplementar")))
                        reg.Qtd_fiscalcomplementar = reader.GetDecimal(reader.GetOrdinal("QTD_FiscalComplementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_FiscalComplemento")))
                        reg.Qtd_fiscalcomplemento = reader.GetDecimal(reader.GetOrdinal("QTD_FiscalComplemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FiscalComplementar")))
                        reg.Vl_fiscalcomplementar = reader.GetDecimal(reader.GetOrdinal("Vl_FiscalComplementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FiscalComplemento")))
                        reg.Vl_fiscalcomplemento = reader.GetDecimal(reader.GetOrdinal("Vl_FiscalComplemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_FiscalDevolver")))
                        reg.Qtd_fiscaldevolver = reader.GetDecimal(reader.GetOrdinal("Qtd_FiscalDevolver"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_FiscalDevolvido")))
                        reg.Qtd_fiscaldevolvido = reader.GetDecimal(reader.GetOrdinal("Qtd_FiscalDevolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FiscalDevolver")))
                        reg.Vl_fiscaldevolver = reader.GetDecimal(reader.GetOrdinal("Vl_FiscalDevolver"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FiscalDevolvido")))
                        reg.Vl_fiscaldevolvido = reader.GetDecimal(reader.GetOrdinal("Vl_fiscaldevolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_origem")))
                        reg.Qtd_origem = reader.GetDecimal(reader.GetOrdinal("qtd_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_origem")))
                        reg.Vl_origem = reader.GetDecimal(reader.GetOrdinal("vl_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Bonificacao")))
                        reg.St_bonificacao = reader.GetString(reader.GetOrdinal("ST_Bonificacao")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_UsoConsumo")))
                        reg.St_usoconsumo = reader.GetString(reader.GetOrdinal("ST_UsoConsumo")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Devolucao")))
                        reg.St_devolucao = reader.GetString(reader.GetOrdinal("ST_Devolucao")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Remessa")))
                        reg.St_remessa = reader.GetString(reader.GetOrdinal("ST_Remessa")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Retorno")))
                        reg.St_retorno = reader.GetString(reader.GetOrdinal("ST_Retorno")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("NCM")))
                        reg.Cd_ncm = reader.GetString(reader.GetOrdinal("NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEST")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("CEST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Imposto_Aprox")))
                        reg.Pc_imposto_Aprox = reader.GetDecimal(reader.GetOrdinal("PC_Imposto_Aprox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_AliquotaSimples")))
                        reg.Pc_aliquotasimples = reader.GetDecimal(reader.GetOrdinal("PC_AliquotaSimples"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_anp")))
                        reg.Ds_anp = reader.GetString(reader.GetOrdinal("ds_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomevendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nomevendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_movestoque")))
                        reg.St_movEstoque = reader.GetString(reader.GetOrdinal("st_movestoque")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_origem")))
                        reg.Tp_origem = reader.GetString(reader.GetOrdinal("tp_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("cd_contactb_sped"));
                    //Fiscal
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ICMS")))
                        reg.Cd_ICMS = reader.GetDecimal(reader.GetOrdinal("CD_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST_ICMS")))
                        reg.Cd_ST_ICMS = reader.GetString(reader.GetOrdinal("CD_ST_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PIS")))
                        reg.Cd_PIS = reader.GetDecimal(reader.GetOrdinal("CD_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST_PIS")))
                        reg.Cd_ST_PIS = reader.GetString(reader.GetOrdinal("CD_ST_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_COFINS")))
                        reg.Cd_COFINS = reader.GetDecimal(reader.GetOrdinal("CD_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST_COFINS")))
                        reg.Cd_ST_COFINS = reader.GetString(reader.GetOrdinal("CD_ST_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_IPI")))
                        reg.Cd_IPI = reader.GetDecimal(reader.GetOrdinal("CD_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST_IPI")))
                        reg.Cd_ST_IPI = reader.GetString(reader.GetOrdinal("CD_ST_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_BASECREDITOPIS")))
                        reg.Id_BaseCreditoPIS = reader.GetDecimal(reader.GetOrdinal("ID_BASECREDITOPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_BASECREDITOCOFINS")))
                        reg.Id_BaseCreditoCofins = reader.GetDecimal(reader.GetOrdinal("ID_BASECREDITOCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPCREDPIS")))
                        reg.Id_TpCredPIS = reader.GetDecimal(reader.GetOrdinal("ID_TPCREDPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPCREDCOFINS")))
                        reg.Id_TpCredCofins = reader.GetDecimal(reader.GetOrdinal("ID_TPCREDCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPCONTRIBUICAOPIS")))
                        reg.Id_TpContribuicaoPIS = reader.GetDecimal(reader.GetOrdinal("ID_TPCONTRIBUICAOPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPCONTRIBUICAOCOFINS")))
                        reg.Id_TpContribuicaoCofins = reader.GetDecimal(reader.GetOrdinal("ID_TPCONTRIBUICAOCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DETRECISENTAPIS")))
                        reg.Id_detrecisentaPIS = reader.GetDecimal(reader.GetOrdinal("ID_DETRECISENTAPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DETRECISENTACOFINS")))
                        reg.Id_detrecisentaCofins = reader.GetDecimal(reader.GetOrdinal("ID_DETRECISENTACOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_RECEITAPIS")))
                        reg.Id_receitaPIS = reader.GetDecimal(reader.GetOrdinal("ID_RECEITAPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_RECEITACOFINS")))
                        reg.Id_receitaCofins = reader.GetDecimal(reader.GetOrdinal("ID_RECEITACOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_IMPOSTO")))
                        reg.Tp_imposto = reader.GetString(reader.GetOrdinal("TP_IMPOSTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAICMS")))
                        reg.Pc_aliquotaICMS = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAPIS")))
                        reg.Pc_aliquotaPIS = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTACOFINS")))
                        reg.Pc_aliquotaCofins = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTACOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAIPI")))
                        reg.Pc_aliquotaIPI = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAISS")))
                        reg.Pc_aliquotaISS = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RETENCAOICMS")))
                        reg.Pc_retencaoICMS = reader.GetDecimal(reader.GetOrdinal("PC_RETENCAOICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RETENCAOISS")))
                        reg.Pc_retencaoISS = reader.GetDecimal(reader.GetOrdinal("PC_RETENCAOISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ICMSRETIDO")))
                        reg.Vl_ICMSRetido = reader.GetDecimal(reader.GetOrdinal("VL_ICMSRETIDO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("VL_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_PIS")))
                        reg.Vl_pis = reader.GetDecimal(reader.GetOrdinal("VL_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_COFINS")))
                        reg.Vl_cofins = reader.GetDecimal(reader.GetOrdinal("VL_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_IPI")))
                        reg.Vl_ipi = reader.GetDecimal(reader.GetOrdinal("VL_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ISS")))
                        reg.Vl_iss = reader.GetDecimal(reader.GetOrdinal("VL_ISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ISSRETIDO")))
                        reg.Vl_issretido = reader.GetDecimal(reader.GetOrdinal("VL_ISSRETIDO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCICMS")))
                        reg.Vl_basecalcICMS = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCPIS")))
                        reg.Vl_basecalcPIS = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCCOFINS")))
                        reg.Vl_basecalcCofins = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCIPI")))
                        reg.Vl_basecalcIPI = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCISS")))
                        reg.Vl_basecalcISS = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARCREDITOICMS")))
                        reg.St_gerarcreditoICMS = reader.GetBoolean(reader.GetOrdinal("ST_GERARCREDITOICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARCREDITOPIS")))
                        reg.St_gerarcreditoPIS = reader.GetBoolean(reader.GetOrdinal("ST_GERARCREDITOPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARCREDITOCOFINS")))
                        reg.St_gerarcreditoCofins = reader.GetBoolean(reader.GetOrdinal("ST_GERARCREDITOCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARCREDITOIPI")))
                        reg.St_gerarcreditoIPI = reader.GetBoolean(reader.GetOrdinal("ST_GERARCREDITOIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARCREDITOISS")))
                        reg.St_gerarcreditoISS = reader.GetBoolean(reader.GetOrdinal("ST_GERARCREDITOISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_BASECALCSTICMS")))
                        reg.Vl_basecalcSTICMS = reader.GetDecimal(reader.GetOrdinal("VL_BASECALCSTICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ICMSST")))
                        reg.Vl_ICMSST = reader.GetDecimal(reader.GetOrdinal("VL_ICMSST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_REDUCAOBASECALCICMS")))
                        reg.Pc_reducaobasecalcICMS = reader.GetDecimal(reader.GetOrdinal("PC_REDUCAOBASECALCICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTASTICMS")))
                        reg.Pc_aliquotaSTICMS = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTASTICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_REDBCSTICMS")))
                        reg.Pc_redbcstICMS = reader.GetDecimal(reader.GetOrdinal("PC_REDBCSTICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_DIFERIDOICMS")))
                        reg.Pc_diferidoICMS = reader.GetDecimal(reader.GetOrdinal("PC_DIFERIDOICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_DIFERIDOICMS")))
                        reg.Vl_diferidoICMS = reader.GetDecimal(reader.GetOrdinal("VL_DIFERIDOICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_SITUACAO")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("TP_SITUACAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TOTALNOTAPIS")))
                        reg.St_totalnotaPIS = reader.GetString(reader.GetOrdinal("ST_TOTALNOTAPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TOTALNOTACOFINS")))
                        reg.St_totalnotaCofins = reader.GetString(reader.GetOrdinal("ST_TOTALNOTACOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TOTALNOTAIPI")))
                        reg.St_totalnotaIPI = reader.GetString(reader.GetOrdinal("ST_TOTALNOTAIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TOTALNOTAISS")))
                        reg.St_totalnotaISS = reader.GetString(reader.GetOrdinal("ST_TOTALNOTAISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_IMPOSTO_UNIT_PIS")))
                        reg.Vl_imposto_unit_PIS = reader.GetDecimal(reader.GetOrdinal("VL_IMPOSTO_UNIT_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_IMPOSTO_UNIT_COFINS")))
                        reg.Vl_imposto_unit_Cofins = reader.GetDecimal(reader.GetOrdinal("VL_IMPOSTO_UNIT_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_IMPOSTO_UNIT_IPI")))
                        reg.Vl_imposto_unit_ipi = reader.GetDecimal(reader.GetOrdinal("VL_IMPOSTO_UNIT_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_DIFAL")))
                        reg.Vl_difal = reader.GetDecimal(reader.GetOrdinal("VL_DIFAL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAICMSDEST")))
                        reg.Pc_aliquotaICMSDest = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAICMSDEST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_AliqOpDifal")))
                        reg.Pc_aliqopdifal = reader.GetDecimal(reader.GetOrdinal("PC_AliqOpDifal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_DEDUCAO")))
                        reg.Ds_deducao = reader.GetString(reader.GetOrdinal("DS_DEDUCAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_FCP")))
                        reg.Pc_FCP = reader.GetDecimal(reader.GetOrdinal("PC_FCP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_FCP")))
                        reg.Vl_FCP = reader.GetDecimal(reader.GetOrdinal("VL_FCP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_FCPST")))
                        reg.Pc_FCPST = reader.GetDecimal(reader.GetOrdinal("PC_FCPST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_FCPST")))
                        reg.Vl_FCPST = reader.GetDecimal(reader.GetOrdinal("VL_FCPST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_PAUTA")))
                        reg.Vl_pauta = reader.GetDecimal(reader.GetOrdinal("VL_PAUTA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IVA_ST")))
                        reg.Pc_iva_st = reader.GetDecimal(reader.GetOrdinal("PC_IVA_ST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_MVA")))
                        reg.Vl_mva = reader.GetDecimal(reader.GetOrdinal("VL_MVA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_TRIBUTISS")))
                        reg.Tp_tributISS = reader.GetString(reader.GetOrdinal("TP_TRIBUTISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_NATUREZAOPERACAOISS")))
                        reg.Tp_naturezaOperacaoISS = reader.GetString(reader.GetOrdinal("TP_NATUREZAOPERACAOISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RetencaoPIS")))
                        reg.Pc_retencaoPIS = reader.GetDecimal(reader.GetOrdinal("PC_RetencaoPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RetencaoCofins")))
                        reg.Pc_retencaoCofins = reader.GetDecimal(reader.GetOrdinal("PC_RetencaoCofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RetencaoIRRF")))
                        reg.Pc_retencaoIRRF = reader.GetDecimal(reader.GetOrdinal("PC_RetencaoIRRF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RetencaoCSLL")))
                        reg.Pc_retencaoCSLL = reader.GetDecimal(reader.GetOrdinal("PC_RetencaoCSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RetencaoINSS")))
                        reg.Pc_retencaoINSS = reader.GetDecimal(reader.GetOrdinal("PC_RetencaoINSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcIRRF")))
                        reg.Vl_basecalcIRRF = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcIRRF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcCSLL")))
                        reg.Vl_basecalcCSLL = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcCSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcINSS")))
                        reg.Vl_basecalcINSS = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcINSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoPIS")))
                        reg.Vl_retidoPIS = reader.GetDecimal(reader.GetOrdinal("Vl_retidoPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoCofins")))
                        reg.Vl_retidoCofins = reader.GetDecimal(reader.GetOrdinal("VL_retidoCofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoIRRF")))
                        reg.Vl_retidoIRRF = reader.GetDecimal(reader.GetOrdinal("Vl_retidoIRRF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoCSLL")))
                        reg.Vl_retidoCSLL = reader.GetDecimal(reader.GetOrdinal("VL_retidoCSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoINSS")))
                        reg.Vl_retidoINSS = reader.GetDecimal(reader.GetOrdinal("vl_retidoINSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcFunrural")))
                        reg.Vl_basecalcFunrural = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcFunrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcSenar")))
                        reg.Vl_basecalcSenar = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcSenar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_funrural")))
                        reg.Pc_funrural = reader.GetDecimal(reader.GetOrdinal("Pc_funrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_senar")))
                        reg.Pc_senar = reader.GetDecimal(reader.GetOrdinal("Pc_senar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_retencaoFunrural")))
                        reg.Pc_retencaoFunrural = reader.GetDecimal(reader.GetOrdinal("Pc_retencaoFunrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_retencaoSenar")))
                        reg.Pc_retencaoSenar = reader.GetDecimal(reader.GetOrdinal("Pc_retencaoSenar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_funrural")))
                        reg.Vl_funrural = reader.GetDecimal(reader.GetOrdinal("Vl_funrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_senar")))
                        reg.Vl_senar = reader.GetDecimal(reader.GetOrdinal("Vl_senar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoFunrural")))
                        reg.Vl_retidoFunrural = reader.GetDecimal(reader.GetOrdinal("Vl_retidoFunrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_retidoSenar")))
                        reg.Vl_retidoSenar = reader.GetDecimal(reader.GetOrdinal("Vl_retidoSenar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_ReducaoBaseCalcISS")))
                        reg.Pc_reducaobasecalcISS = reader.GetDecimal(reader.GetOrdinal("Pc_ReducaoBaseCalcISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalc")))
                        reg.Tp_modbasecalc = reader.GetString(reader.GetOrdinal("TP_ModBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalcST")))
                        reg.Tp_modbasecalcST = reader.GetString(reader.GetOrdinal("TP_ModBaseCalcST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcII")))
                        reg.Vl_basecalcII = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcII"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaII")))
                        reg.Pc_aliquotaII = reader.GetDecimal(reader.GetOrdinal("Pc_AliquotaII"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_II")))
                        reg.Vl_II = reader.GetDecimal(reader.GetOrdinal("Vl_II"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalc")))
                        reg.Tp_modbasecalc = reader.GetString(reader.GetOrdinal("TP_ModBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalcST")))
                        reg.Tp_modbasecalcST = reader.GetString(reader.GetOrdinal("TP_ModBaseCalcST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SomarIPIBaseICMS")))
                        reg.St_somarIPIBaseICMS = reader.GetBoolean(reader.GetOrdinal("ST_SomarIPIBaseICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SomarIPIBaseST")))
                        reg.St_somarIPIBaseST = reader.GetBoolean(reader.GetOrdinal("ST_SomarIPIBaseST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IRRF")))
                        reg.PC_IRRF = reader.GetDecimal(reader.GetOrdinal("PC_IRRF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_CSLL")))
                        reg.PC_CSLL = reader.GetDecimal(reader.GetOrdinal("PC_CSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_INSS")))
                        reg.VL_INSS = reader.GetDecimal(reader.GetOrdinal("VL_INSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_INSS")))
                        reg.PC_INSS = reader.GetDecimal(reader.GetOrdinal("PC_INSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_IRRF")))
                        reg.VL_IRRF = reader.GetDecimal(reader.GetOrdinal("VL_IRRF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_CSLL")))
                        reg.VL_CSLL = reader.GetDecimal(reader.GetOrdinal("VL_CSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RedBaseCalcINSS")))
                        reg.Pc_redbasecalcINSS = reader.GetDecimal(reader.GetOrdinal("PC_RedBaseCalcINSS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RedBaseCalcCSLL")))
                        reg.Pc_redbasecalcCSLL = reader.GetDecimal(reader.GetOrdinal("PC_RedBaseCalcCSLL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_RedBaseCalcIRRF")))
                        reg.Pc_redbasecalcIRRF = reader.GetDecimal(reader.GetOrdinal("PC_RedBaseCalcIRRF"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public TListUltimasCompras Select(TpBusca[] filtro, int vTop)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaDetalhesUltimasCompras(filtro, vTop));
            TListUltimasCompras lista = new TListUltimasCompras();
            try
            {
                while (reader.Read())
                {
                    TRegistroUltimasCompras reg = new TRegistroUltimasCompras();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fantasia")))
                        reg.Nm_fantasia = reader.GetString(reader.GetOrdinal("NM_Fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contabil")))
                        reg.Vl_custoNota = reader.GetDecimal(reader.GetOrdinal("vl_contabil"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }

        public TListVendasMes SelectVendasMes(TpBusca[] filtro, int vTop)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaVendasMes(filtro, vTop));
            TListVendasMes lista = new TListVendasMes();
            try
            {
                while (reader.Read())
                {
                    TRegistroVendasMes reg = new TRegistroVendasMes();
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetInt32(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetInt32(reader.GetOrdinal("Mes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }

        public string GravaItensNF(TRegistro_LanFaturamento_Item vRegistro)
        {
            Hashtable hs = new Hashtable(136);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", vRegistro.Id_nfitem);
            hs.Add("@P_ID_APONTAMENTO", vRegistro.Id_apontamento);
            hs.Add("@P_CD_LOCAL", vRegistro.Cd_local);
            hs.Add("@P_CD_CFOP", vRegistro.Cd_cfop);
            hs.Add("@P_LOTE", vRegistro.Lote);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_CD_UNIDADE", vRegistro.Cd_unidade);
            hs.Add("@P_VL_UNITARIO", vRegistro.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", vRegistro.Vl_subtotal);
            hs.Add("@P_VL_DESCONTO", vRegistro.Vl_desconto);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_ID_VARIEDADE", vRegistro.Id_variedade);
            hs.Add("@P_VL_FRETEITEM", vRegistro.Vl_freteitem);
            hs.Add("@P_VL_JURO_FIN", vRegistro.Vl_juro_fin);
            hs.Add("@P_VL_SEGURO", vRegistro.Vl_seguro);
            hs.Add("@P_VL_OUTRASDESP", vRegistro.Vl_outrasdesp);
            hs.Add("@P_PC_IMPOSTO_APROX", vRegistro.Pc_imposto_Aprox);
            hs.Add("@P_PC_ALIQUOTASIMPLES", vRegistro.Pc_aliquotasimples);
            hs.Add("@P_ST_SERVICO", vRegistro.St_servico);
            hs.Add("@P_OBSERVACAO_ITEM", vRegistro.Observacao_item);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_pedido);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);
            hs.Add("@P_ID_LOTECTB_CMV", vRegistro.Id_lotectb_cmv);
            hs.Add("@P_ID_LOTECTB_FAT", vRegistro.Id_lotectb_fat);
            hs.Add("@P_TP_ORIGEM", vRegistro.Tp_origem);
            hs.Add("@P_CD_ICMS", vRegistro.Cd_ICMS);
            hs.Add("@P_CD_ST_ICMS", vRegistro.Cd_ST_ICMS);
            hs.Add("@P_CD_PIS", vRegistro.Cd_PIS);
            hs.Add("@P_CD_ST_PIS", vRegistro.Cd_ST_PIS);
            hs.Add("@P_CD_COFINS", vRegistro.Cd_COFINS);
            hs.Add("@P_CD_ST_COFINS", vRegistro.Cd_ST_COFINS);
            hs.Add("@P_CD_IPI", vRegistro.Cd_IPI);
            hs.Add("@P_CD_ST_IPI", vRegistro.Cd_ST_IPI);
            hs.Add("@P_ID_BASECREDITOPIS", vRegistro.Id_BaseCreditoPIS);
            hs.Add("@P_ID_BASECREDITOCOFINS", vRegistro.Id_BaseCreditoCofins);
            hs.Add("@P_ID_TPCREDPIS", vRegistro.Id_TpCredPIS);
            hs.Add("@P_ID_TPCREDCOFINS", vRegistro.Id_TpCredCofins);
            hs.Add("@P_ID_TPCONTRIBUICAOPIS", vRegistro.Id_TpContribuicaoPIS);
            hs.Add("@P_ID_TPCONTRIBUICAOCOFINS", vRegistro.Id_TpContribuicaoCofins);
            hs.Add("@P_ID_DETRECISENTAPIS", vRegistro.Id_detrecisentaPIS);
            hs.Add("@P_ID_DETRECISENTACOFINS", vRegistro.Id_detrecisentaCofins);
            hs.Add("@P_ID_RECEITAPIS", vRegistro.Id_receitaPIS);
            hs.Add("@P_ID_RECEITACOFINS", vRegistro.Id_receitaCofins);
            hs.Add("@P_TP_IMPOSTO", vRegistro.Tp_imposto);
            hs.Add("@P_PC_ALIQUOTAICMS", vRegistro.Pc_aliquotaICMS);
            hs.Add("@P_PC_ALIQUOTAPIS", vRegistro.Pc_aliquotaPIS);
            hs.Add("@P_PC_ALIQUOTACOFINS", vRegistro.Pc_aliquotaCofins);
            hs.Add("@P_PC_ALIQUOTAIPI", vRegistro.Pc_aliquotaIPI);
            hs.Add("@P_PC_ALIQUOTAISS", vRegistro.Pc_aliquotaISS);
            hs.Add("@P_PC_RETENCAOICMS", vRegistro.Pc_retencaoICMS);
            hs.Add("@P_PC_RETENCAOISS", vRegistro.Pc_retencaoISS);
            hs.Add("@P_VL_ICMSRETIDO", vRegistro.Vl_ICMSRetido);
            hs.Add("@P_VL_ICMS", vRegistro.Vl_icms);
            hs.Add("@P_VL_PIS", vRegistro.Vl_pis);
            hs.Add("@P_VL_COFINS", vRegistro.Vl_cofins);
            hs.Add("@P_VL_IPI", vRegistro.Vl_ipi);
            hs.Add("@P_VL_ISS", vRegistro.Vl_iss);
            hs.Add("@P_VL_ISSRETIDO", vRegistro.Vl_issretido);
            hs.Add("@P_VL_BASECALCICMS", vRegistro.Vl_basecalcICMS);
            hs.Add("@P_VL_BASECALCPIS", vRegistro.Vl_basecalcPIS);
            hs.Add("@P_VL_BASECALCCOFINS", vRegistro.Vl_basecalcCofins);
            hs.Add("@P_VL_BASECALCIPI", vRegistro.Vl_basecalcIPI);
            hs.Add("@P_VL_BASECALCISS", vRegistro.Vl_basecalcISS);
            hs.Add("@P_ST_GERARCREDITOICMS", vRegistro.St_gerarcreditoICMS);
            hs.Add("@P_ST_GERARCREDITOPIS", vRegistro.St_gerarcreditoPIS);
            hs.Add("@P_ST_GERARCREDITOCOFINS", vRegistro.St_gerarcreditoCofins);
            hs.Add("@P_ST_GERARCREDITOIPI", vRegistro.St_gerarcreditoIPI);
            hs.Add("@P_ST_GERARCREDITOISS", vRegistro.St_gerarcreditoISS);
            hs.Add("@P_VL_BASECALCSTICMS", vRegistro.Vl_basecalcSTICMS);
            hs.Add("@P_VL_ICMSST", vRegistro.Vl_ICMSST);
            hs.Add("@P_PC_REDUCAOBASECALCICMS", vRegistro.Pc_reducaobasecalcICMS);
            hs.Add("@P_PC_ALIQUOTASTICMS", vRegistro.Pc_aliquotaSTICMS);
            hs.Add("@P_PC_REDBCSTICMS", vRegistro.Pc_redbcstICMS);
            hs.Add("@P_PC_DIFERIDOICMS", vRegistro.Pc_diferidoICMS);
            hs.Add("@P_VL_DIFERIDOICMS", vRegistro.Vl_diferidoICMS);
            hs.Add("@P_TP_SITUACAO", vRegistro.Tp_situacao);
            hs.Add("@P_ST_TOTALNOTAPIS", vRegistro.St_totalnotaPIS);
            hs.Add("@P_ST_TOTALNOTACOFINS", vRegistro.St_totalnotaCofins);
            hs.Add("@P_ST_TOTALNOTAIPI", vRegistro.St_totalnotaIPI);
            hs.Add("@P_ST_TOTALNOTAISS", vRegistro.St_totalnotaISS);
            hs.Add("@P_VL_IMPOSTO_UNIT_PIS", vRegistro.Vl_imposto_unit_PIS);
            hs.Add("@P_VL_IMPOSTO_UNIT_COFINS", vRegistro.Vl_imposto_unit_Cofins);
            hs.Add("@P_VL_IMPOSTO_UNIT_IPI", vRegistro.Vl_imposto_unit_ipi);
            hs.Add("@P_VL_DIFAL", vRegistro.Vl_difal);
            hs.Add("@P_PC_ALIQUOTAICMSDEST", vRegistro.Pc_aliquotaICMSDest);
            hs.Add("@P_PC_ALIQOPDIFAL", vRegistro.Pc_aliqopdifal);
            hs.Add("@P_DS_DEDUCAO", vRegistro.Ds_deducao);
            hs.Add("@P_PC_FCP", vRegistro.Pc_FCP);
            hs.Add("@P_VL_FCP", vRegistro.Vl_FCP);
            hs.Add("@P_PC_FCPST", vRegistro.Pc_FCPST);
            hs.Add("@P_VL_FCPST", vRegistro.Vl_FCPST);
            hs.Add("@P_VL_PAUTA", vRegistro.Vl_pauta);
            hs.Add("@P_PC_IVA_ST", vRegistro.Pc_iva_st);
            hs.Add("@P_VL_MVA", vRegistro.Vl_mva);
            hs.Add("@P_TP_TRIBUTISS", vRegistro.Tp_tributISS);
            hs.Add("@P_TP_NATUREZAOPERACAOISS", vRegistro.Tp_naturezaOperacaoISS);
            hs.Add("@P_PC_RETENCAOPIS", vRegistro.Pc_retencaoPIS);
            hs.Add("@P_PC_RETENCAOCOFINS", vRegistro.Pc_retencaoCofins);
            hs.Add("@P_PC_RETENCAOIRRF", vRegistro.Pc_retencaoIRRF);
            hs.Add("@P_PC_RETENCAOCSLL", vRegistro.Pc_retencaoCSLL);
            hs.Add("@P_PC_RETENCAOINSS", vRegistro.Pc_retencaoINSS);
            hs.Add("@P_VL_BASECALCIRRF", vRegistro.Vl_basecalcIRRF);
            hs.Add("@P_VL_BASECALCCSLL", vRegistro.Vl_basecalcCSLL);
            hs.Add("@P_VL_BASECALCINSS", vRegistro.Vl_basecalcINSS);
            hs.Add("@P_VL_RETIDOPIS", vRegistro.Vl_retidoPIS);
            hs.Add("@P_VL_RETIDOCOFINS", vRegistro.Vl_retidoCofins);
            hs.Add("@P_VL_RETIDOIRRF", vRegistro.Vl_retidoIRRF);
            hs.Add("@P_VL_RETIDOCSLL", vRegistro.Vl_retidoCSLL);
            hs.Add("@P_VL_RETIDOINSS", vRegistro.Vl_retidoINSS);
            hs.Add("@P_VL_BASECALCFUNRURAL", vRegistro.Vl_basecalcFunrural);
            hs.Add("@P_VL_BASECALCSENAR", vRegistro.Vl_basecalcSenar);
            hs.Add("@P_PC_FUNRURAL", vRegistro.Pc_funrural);
            hs.Add("@P_PC_SENAR", vRegistro.Pc_senar);
            hs.Add("@P_PC_RETENCAOFUNRURAL", vRegistro.Pc_retencaoFunrural);
            hs.Add("@P_PC_RETENCAOSENAR", vRegistro.Pc_retencaoSenar);
            hs.Add("@P_VL_FUNRURAL", vRegistro.Vl_funrural);
            hs.Add("@P_VL_SENAR", vRegistro.Vl_senar);
            hs.Add("@P_VL_RETIDOFUNRURAL", vRegistro.Vl_retidoFunrural);
            hs.Add("@P_VL_RETIDOSENAR", vRegistro.Vl_retidoSenar);
            hs.Add("@P_PC_REDUCAOBASECALCISS", vRegistro.Pc_reducaobasecalcISS);
            hs.Add("@P_TP_MODBASECALC", vRegistro.Tp_modbasecalc);
            hs.Add("@P_TP_MODBASECALCST", vRegistro.Tp_modbasecalcST);
            hs.Add("@P_VL_BASECALCII", vRegistro.Vl_basecalcII);
            hs.Add("@P_PC_ALIQUOTAII", vRegistro.Pc_aliquotaII);
            hs.Add("@P_VL_II", vRegistro.Vl_II);
            hs.Add("@P_ST_SOMARIPIBASEICMS", vRegistro.St_somarIPIBaseICMS);
            hs.Add("@P_ST_SOMARIPIBASEST", vRegistro.St_somarIPIBaseST);
            hs.Add("@P_PC_IRRF", vRegistro.PC_IRRF);
            hs.Add("@P_PC_CSLL", vRegistro.PC_CSLL);
            hs.Add("@P_PC_INSS", vRegistro.PC_INSS);
            hs.Add("@P_VL_IRRF", vRegistro.VL_IRRF);
            hs.Add("@P_VL_CSLL", vRegistro.VL_CSLL);
            hs.Add("@P_VL_INSS", vRegistro.VL_INSS);
            hs.Add("@P_PC_REDBASECALCINSS", vRegistro.Pc_redbasecalcINSS);
            hs.Add("@P_PC_REDBASECALCCSLL", vRegistro.Pc_redbasecalcCSLL);
            hs.Add("@P_PC_REDBASECALCIRRF", vRegistro.Pc_redbasecalcIRRF);

            return executarProc("IA_FAT_NOTAFISCAL_ITEM", hs);
        }
    }
}
