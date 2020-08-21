using System;
using System.Collections.Generic;
using System.Text;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CamadaDados.Faturamento.PDV;
using CamadaDados.Servicos;
using CamadaDados.Faturamento.CompraAvulsa;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Faturamento.Pedido
{
    #region Classe Item Pedido
    public class TList_RegLanPedido_Item : List<TRegistro_LanPedido_Item>, IComparer<TRegistro_LanPedido_Item>
    {
        #region IComparer<TRegistro_LanPedido_Item> Members
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

        public TList_RegLanPedido_Item()
        { }

        public TList_RegLanPedido_Item(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPedido_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPedido_Item x, TRegistro_LanPedido_Item y)
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

    public class TRegistro_LanPedido_Item
    {
        public decimal altura { get; set; }
        public decimal largura { get; set; }
        public decimal comprimento_und { get; set; }
        public string Tp_unidade { get; set; } = string.Empty;
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_PedidoString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_PedidoString;
        public string Nr_PedidoString
        {
            get { return nr_PedidoString; }
            set
            {
                nr_PedidoString = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch { nr_pedido = null; }
            }
        }
        public string Cd_condpgto
        { get; set; }
        private DateTime? dt_pedido;
        public DateTime? Dt_pedido
        {
            get { return dt_pedido; }
            set
            {
                dt_pedido = value;
                dt_pedidostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_pedidostr;
        public string Dt_pedidostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_pedidostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_pedidostr = value;
                try
                {
                    dt_pedido = DateTime.Parse(value);
                }
                catch
                { dt_pedido = null; }
            }
        }
        public decimal Id_pedidoitem
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ds_condfiscal_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_marca
        { get; set; }
        public bool St_servico
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Cd_unidade_valor
        { get; set; }
        public string Ds_unidade_valor
        { get; set; }
        public string Sg_unidade_valor
        { get; set; }
        public string Cd_unidade_est
        { get; set; }
        public string Ds_unidade_est
        { get; set; }
        public string Sg_unidade_est
        { get; set; }
        public decimal SaldoCarregar
        { get { return quantidade - Qtd_expedida + Qtd_devolvida; } }
        private decimal quantidade;
        public decimal Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                if ((!string.IsNullOrEmpty(Cd_unidade_est)) &
                    (!string.IsNullOrEmpty(Cd_unidade_valor)))
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidade_est, Cd_unidade_valor, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidade_est, Cd_unidade_valor, quantidade * vl_unitario), 2);
                vl_desc = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_desc) / 100, 5) :
                    Math.Round((vl_subtotal * pc_desc) / 100, 5);
                vl_acrescimo = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_acrescimo) / 100, 5) :
                    Math.Round((vl_subtotal * pc_acrescimo) / 100, 5);
                if (vl_subtotal > 0)
                {
                    pc_desc = (vl_desc / vl_subtotal) * 100;
                    pc_acrescimo = (vl_acrescimo / vl_subtotal) * 100;
                }
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        public decimal Qtd_estoque
        { get; set; }
        public decimal Qtd_expedida { get; set; }
        public bool St_semsaldoestoque
        { get { return quantidade > Qtd_estoque; } }
        public decimal Qtd_reservada
        { get; set; }
        public decimal Qtd_saldofuturo
        {
            get
            {
                return Qtd_estoque - Qtd_reservada;
            }
        }
        public decimal Qtd_faturada
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Qtd_sdfaturar
        { get { return quantidade - Qtd_faturada + Qtd_devolvida - Qtd_devpedido; } }
        public decimal Qtd_conferida
        { get; set; }
        public decimal Qtd_devpedido { get; set; }
        private decimal pc_desc;
        public decimal Pc_desc
        {
            get { return Math.Round(pc_desc, 2); }
            set
            {
                pc_desc = value;
                vl_desc = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_desc) / 100, 5) :
                    Math.Round((vl_subtotal * pc_desc) / 100, 5);
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal pc_acrescimo;
        public decimal Pc_acrescimo
        {
            get { return Math.Round(pc_acrescimo, 2); }
            set
            {
                pc_acrescimo = value;
                vl_acrescimo = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_acrescimo) / 100, 5) :
                    Math.Round((vl_subtotal * pc_acrescimo) / 100, 5);
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? vl_freteitem : decimal.Zero) + vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? vl_freteitem : decimal.Zero) + vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_unitario, 7) : Math.Round(vl_unitario, 7); }
            set
            {
                vl_unitario = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 7) : Math.Round(value, 7);
                if ((!string.IsNullOrEmpty(Cd_unidade_valor)) &&
                    (!string.IsNullOrEmpty(Cd_unidade_est)))
                    vl_subtotal = Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidade_est, Cd_unidade_valor, quantidade * vl_unitario), 2) :
                        Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(Cd_unidade_est, Cd_unidade_valor, quantidade * vl_unitario), 2);
                vl_desc = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_desc) / 100, 5) :
                    Math.Round((vl_subtotal * pc_desc) / 100, 5);
                vl_acrescimo = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_acrescimo) / 100, 5) :
                    Math.Round((vl_subtotal * pc_acrescimo) / 100, 5);
                if (vl_subtotal > 0)
                {
                    pc_desc = (vl_desc / vl_subtotal) * 100;
                    pc_acrescimo = (vl_acrescimo / vl_subtotal) * 100;
                }
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_subtotal, 2) : Math.Round(vl_subtotal, 2); }
            set
            {
                vl_subtotal = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2);
                vl_desc = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_desc) / 100, 5) :
                    Math.Round((vl_subtotal * pc_desc) / 100, 5);
                vl_acrescimo = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal * pc_acrescimo) / 100, 5) :
                    Math.Round((vl_subtotal * pc_acrescimo) / 100, 5);
                if (vl_subtotal > 0)
                {
                    pc_desc = (vl_desc / vl_subtotal) * 100;
                    pc_acrescimo = (vl_acrescimo / vl_subtotal) * 100;
                }
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal vl_desc;
        public decimal Vl_desc
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_desc, 5) : Math.Round(vl_desc, 5); }
            set
            {
                vl_desc = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 5) : Math.Round(value, 5);
                if (vl_subtotal > decimal.Zero)
                    pc_desc = (vl_desc / vl_subtotal) * 100;
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal vl_freteitem;
        public decimal Vl_freteitem
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_freteitem, 2) : Math.Round(vl_freteitem, 2); }
            set
            {
                vl_freteitem = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2);
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_acrescimo, 5) : Math.Round(vl_acrescimo, 5); }
            set
            {
                vl_acrescimo = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 5) : Math.Round(value, 5);
                if (vl_subtotal > decimal.Zero)
                    pc_acrescimo = (vl_acrescimo / vl_subtotal) * 100;
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? vl_freteitem : decimal.Zero) + vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? vl_freteitem : decimal.Zero) + vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        public string Ds_Fichatec
        { get; set; }
        public string St_TanqueAereo
        { get; set; }
        public decimal Ps_unitario
        { get; set; }
        public string Ds_observacaoitem
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_registro = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_registro = "CANCELADO";
            }
        }
        private string status_registro;
        public string Status_registro
        {
            get { return status_registro; }
            set
            {
                status_registro = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        public decimal? Nr_contrato
        { get; set; }
        private decimal vl_total_item;
        public decimal VL_Total_Item
        {
            get { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_total_item, 2) : Math.Round(vl_total_item, 2); }
            set { vl_total_item = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2); }
        }
        public decimal Vl_subtotal_semjuros
        {
            get
            {
                return Parametros.pubTruncarSubTotal ?
            Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + vl_acrescimo) - (vl_desc), 2) :
            Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + vl_acrescimo) - (vl_desc), 2);
            }
        }
        public string Tp_Movimento
        { get; set; }
        public string Tp_pedOS
        { get; set; }
        public string Nm_Empresa
        { get; set; }
        public string Cd_Empresa
        { get; set; }
        public TList_EntregaPedido EntregaPedido
        { get; set; }
        public TList_FichaTecItemPed lFichaTec
        { get; set; }
        public TList_FichaTecProduto lFicha
        { get; set; }
        public NotaFiscal.TList_ImpostosNF ImpostosItens
        {
            get;
            set;
        }
        public TList_PedidoGrade lPedidoGrade { get; set; }
        public TList_VendaRapida_Item lItemCF
        { get; set; }
        public TList_LanServicosPecas lPecaOS
        { get; set; }
        public TList_Compra_Itens lItensCompra
        { get; set; }
        public Entrega.TList_ItensCargaAvulsa lItensCargaAvulsa
        { get; set; }
        private decimal vl_juro_fin;
        public decimal Vl_juro_fin
        {
            get
            { return Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_juro_fin, 2) : Math.Round(vl_juro_fin, 2); }
            set
            {
                vl_juro_fin = Parametros.pubTruncarSubTotal ? Estruturas.Truncar(value, 2) : Math.Round(value, 2);
                vl_total_item = Parametros.pubTruncarSubTotal ?
                    Estruturas.Truncar((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2) :
                    Math.Round((vl_subtotal + (St_somarFrete ? Vl_freteitem : decimal.Zero) + Vl_juro_fin + vl_acrescimo) - (vl_desc), 2);
            }
        }
        public decimal Pc_juro_fin
        {
            get
            {
                if (VL_Total_Item > 0)
                    return ((Parametros.pubTruncarSubTotal ? Estruturas.Truncar(vl_juro_fin, 2) : Math.Round(vl_juro_fin, 2)) * 100) /
                        (Parametros.pubTruncarSubTotal ? Estruturas.Truncar(Vl_subtotal_semjuros, 2) : Math.Round(Vl_subtotal_semjuros, 2));
                else return decimal.Zero;
            }
        }
        public string ExtensoValor { get; set; }
        public string ExtensoQtde { get; set; }
        public bool St_gerarConferencia
        { get; set; }
        public decimal? Nr_orcamento
        { get; set; }
        public decimal? Id_itemorc
        { get; set; }
        public decimal Vl_descCupom
        { get; set; }
        public decimal Vl_juroCupom
        { get; set; }
        public decimal Vl_custo
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal Vl_custoitem
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nomevendedor
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string ncm
        { get; set; }
        public string Cest
        { get; set; }
        public string Ds_tecnica
        { get; set; }
        public string DS_TecnicaAssistencia
        { get; set; }
        private System.Drawing.Image imagem;
        public System.Drawing.Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (System.Drawing.Image)new System.Drawing.ImageConverter().ConvertFrom(value);
            }
        }
        public string Tp_frete
        { get; set; }
        public bool St_somarFrete
        {
            get
            {
                if ((Tp_Movimento != null) && (Tp_frete != null))
                    if ((Tp_Movimento.Trim().ToUpper().Equals("S") && Tp_frete.Trim().Equals("0")) ||
                        (Tp_Movimento.Trim().ToUpper().Equals("E") && Tp_frete.Trim().Equals("1")))
                        return true;
                    else return false;
                else return false;
            }
        }
        public decimal Pc_imposto_Aprox
        { get; set; }
        public NotaFiscal.TRegistro_ItensXMLNFe rItemXML
        { get; set; }
        public decimal Pc_icms
        { get; set; }
        public bool St_exigirserie
        { get; set; }
        public decimal Pc_comrep
        { get; set; }
        public decimal Vl_comrep
        {
            get
            {
                if ((this.vl_subtotal + this.vl_acrescimo + this.vl_juro_fin - this.vl_desc) > decimal.Zero)
                    return Math.Round(decimal.Divide(decimal.Multiply((this.vl_subtotal + this.vl_acrescimo + this.vl_juro_fin - this.vl_desc), this.Pc_comrep), 100), 2, MidpointRounding.AwayFromZero);
                else return decimal.Zero;
            }
        }
        private string st_projespecial;
        public string St_projespecial
        {
            get { return st_projespecial; }
            set
            {
                st_projespecial = value;
                st_projespecialbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_projespecialbool;
        public bool St_projespecialbool
        {
            get { return st_projespecialbool; }
            set
            {
                st_projespecialbool = value;
                st_projespecial = value ? "S" : "N";
            }
        }
        public decimal Vl_subst { get; set; } = decimal.Zero;
        public decimal Vl_IPI { get; set; } = decimal.Zero;
        public bool St_processar
        { get; set; }
        public decimal Qtd_devolver { get; set; }

        public TRegistro_LanPedido_Item()
        {
            Nr_pedido = decimal.Zero;
            nr_PedidoString = string.Empty;
            Cd_condpgto = string.Empty;
            dt_pedido = null;
            dt_pedidostr = string.Empty;
            Id_pedidoitem = decimal.Zero;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_referencia = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ds_condfiscal_produto = string.Empty;
            Cd_grupo = string.Empty;
            Ds_marca = string.Empty;
            St_servico = false;
            Qtd_estoque = decimal.Zero;
            Qtd_expedida = decimal.Zero;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_unidade_valor = string.Empty;
            Ds_unidade_valor = string.Empty;
            Sg_unidade_valor = string.Empty;
            Cd_unidade_est = string.Empty;
            Ds_unidade_est = string.Empty;
            Sg_unidade_est = string.Empty;
            quantidade = decimal.Zero;
            Qtd_faturada = decimal.Zero;
            Qtd_devolvida = decimal.Zero;
            Qtd_conferida = decimal.Zero;
            Qtd_devpedido = decimal.Zero;
            pc_desc = decimal.Zero;
            pc_acrescimo = decimal.Zero;
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_desc = decimal.Zero;
            Vl_freteitem = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            vl_total_item = decimal.Zero;
            Ds_Fichatec = string.Empty;
            St_TanqueAereo = string.Empty;
            Ps_unitario = decimal.Zero;
            Ds_observacaoitem = string.Empty;
            st_registro = "A";
            status_registro = "ATIVO";
            Nr_contrato = null;
            Tp_pedOS = string.Empty;
            Tp_Movimento = string.Empty;
            Nm_Empresa = string.Empty;
            Cd_Empresa = string.Empty;
            Vl_juro_fin = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_custoitem = decimal.Zero;

            EntregaPedido = new TList_EntregaPedido();
            lFichaTec = new TList_FichaTecItemPed();
            lFicha = new TList_FichaTecProduto();
            lItemCF = new TList_VendaRapida_Item();
            lPedidoGrade = new TList_PedidoGrade();
            lPecaOS = new TList_LanServicosPecas();
            lItensCompra = new TList_Compra_Itens();
            lItensCargaAvulsa = new Entrega.TList_ItensCargaAvulsa();
            ExtensoQtde = string.Empty;
            ExtensoValor = string.Empty;
            Qtd_reservada = decimal.Zero;
            St_gerarConferencia = false;
            Nr_orcamento = null;
            Id_itemorc = null;
            Vl_descCupom = decimal.Zero;
            Vl_juroCupom = decimal.Zero;
            Vl_custo = decimal.Zero;
            Cd_vendedor = string.Empty;
            Nomevendedor = string.Empty;
            Cd_tabelapreco = string.Empty;
            ncm = string.Empty;
            Cest = string.Empty;
            Ds_tecnica = string.Empty;
            DS_TecnicaAssistencia = string.Empty;
            imagem = null;
            img = null;
            Tp_frete = string.Empty;
            Pc_imposto_Aprox = decimal.Zero;
            rItemXML = null;
            Pc_icms = decimal.Zero;
            St_exigirserie = false;
            Pc_comrep = decimal.Zero;
            st_projespecial = "N";
            st_projespecialbool = false;
            St_processar = false;
            this.ImpostosItens = new CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF();
        }
    }

    public class TCD_LanPedido_Item : TDataQuery
    {
        public TCD_LanPedido_Item()
        { }

        public TCD_LanPedido_Item(TObjetoBanco banco)
        { Banco_Dados = banco; }

        public TCD_LanPedido_Item(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + "a.largura, a.altura, a.comprimento as comprimento_und, a.nr_pedido, a.cd_produto, b.ds_produto, b.Codigo_Alternativo, contrato.nr_contrato, ");
                sql.AppendLine("a.id_pedidoitem, marca.ds_marca, a.vl_juro_fin, b.cd_condfiscal_produto, n.cd_condpgto, n.st_pedido, ");
                sql.AppendLine("a.nr_orcamento, a.id_itemorc, cond.ds_condfiscal_produto, a.Qtd_conferida, tpProd.st_servico, ");
                sql.AppendLine("a.Qtd_estoque, a.Qtd_reservada, a.Qtd_saldofuturo, b.cd_grupo, n.tp_frete, a.qtd_expedida, a.qtd_devpedido, ");
                sql.AppendLine("a.qtd_faturada, a.qtd_devolvida, a.vl_comissao, a.Vl_CustoItem, a.cd_vendedor, vend.nm_clifor as nomevendedor, ");
                sql.AppendLine("b.cd_unidade as cd_unidade_est, c.ds_unidade as ds_unidade_est, c.tp_unidade, ");
                sql.AppendLine("c.sigla_unidade as sg_unidade_est, a.cd_local, d.ds_local, n.cfg_pedido, n.DT_Pedido, n.cd_empresa, ");
                sql.AppendLine("a.cd_unidade as cd_unidade_valor, cfgped.ds_tipopedido, nc.cest, ");
                sql.AppendLine("f.ds_unidade as ds_unidade_valor, f.sigla_unidade as sg_unidade_valor, a.vl_acrescimo, ");
                sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_freteitem, n.cd_tabelapreco, b.ncm, b.ds_tecnica, b.DS_TecnicaAssistencia, b.ST_TanqueAereo, ");
                sql.AppendLine("b.ps_unitario, b.St_exigirserie, a.PC_ComRep, a.ST_ProjEspecial, a.Vl_Subst, a.Vl_IPI, ");
                sql.AppendLine("imagem = (select top 1 x.imagem ");
                sql.AppendLine("            from TB_EST_PRODUTO_Imagens x ");
                sql.AppendLine("            where x.cd_produto = b.cd_produto ");
                sql.AppendLine("            order by x.id_imagem asc), ");
                sql.AppendLine("a.vl_subtotal, a.vl_desc, a.ds_fichatec, case when isnull(tpProd.st_servico, 'N') = 'S' then tpserv.pc_ibpt else nc.pc_aliquota end as PC_Imposto_Aprox, ");
                sql.AppendLine("a.ds_observacaoitem, a.st_registro, n.tp_movimento, m.nm_empresa, ");
                sql.AppendLine("clifor.cd_clifor, clifor.nm_clifor, clifor.tp_pessoa, clifor.st_equiparado_pj, ");
                sql.AppendLine("clifor.st_agropecuaria, contrato.tp_prodcontrato, cfgped.st_deposito, ");
                sql.AppendLine("endereco.cd_endereco, endereco.ds_endereco, endereco.DS_Cidade, endereco.UF, contrato.cd_tabeladesconto, contrato.anosafra,");
                sql.AppendLine("case when clifor.tp_pessoa = 'J' then clifor.nr_cgc else clifor.nr_cpf end as nr_cgc_cpf, ");
                sql.AppendLine("case when a.vl_juro_fin > 0 then a.vl_juro_fin * 100 / a.vl_subtotal else 0 end as pc_juro_fin, ");
                sql.AppendLine("case when a.vl_desc > 0 then a.vl_desc * 100 / a.vl_subtotal else 0 end as pc_desc, ");
                sql.AppendLine("case when a.vl_acrescimo > 0 then a.vl_acrescimo * 100 / a.vl_subtotal else 0 end as pc_acrescimo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fat_pedido_itens a ");
            //Produto
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto");
            //Tipo Produto
            sql.AppendLine("inner join tb_est_tpproduto tpProd ");
            sql.AppendLine("on b.tp_produto = tpProd.tp_produto ");
            //Pedido
            sql.AppendLine("inner join vtb_fat_pedido n ");
            sql.AppendLine("on a.nr_pedido = n.nr_pedido");
            //CFG Pedido
            sql.AppendLine("inner join tb_fat_cfgpedido cfgped ");
            sql.AppendLine("on cfgped.cfg_pedido = n.cfg_pedido ");
            //Clifor
            sql.AppendLine("left outer join vtb_fin_clifor clifor ");
            sql.AppendLine("on n.cd_clifor = clifor.cd_clifor");
            //endereco
            sql.AppendLine("left outer join vtb_fin_endereco endereco ");
            sql.AppendLine("on n.cd_clifor = endereco.cd_clifor ");
            sql.AppendLine("and n.cd_endereco = endereco.cd_endereco");
            //empresa
            sql.AppendLine("left outer join tb_div_empresa m ");
            sql.AppendLine("on n.cd_empresa = m.cd_empresa");
            //Contrato
            sql.AppendLine("left outer join tb_gro_contrato contrato ");
            sql.AppendLine("on a.nr_pedido = contrato.nr_pedido ");
            sql.AppendLine("and a.cd_produto = contrato.cd_produto ");
            sql.AppendLine("and a.id_pedidoitem = contrato.id_pedidoitem ");
            //Unidade Estoque
            sql.AppendLine("left outer join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade");
            //Local Armazenagem
            sql.AppendLine("left outer join tb_est_localarm d ");
            sql.AppendLine("on a.cd_local = d.cd_local");
            //Unidade Pedido
            sql.AppendLine("left outer join tb_est_unidade f ");
            sql.AppendLine("on a.cd_unidade = f.cd_unidade");
            //Marca
            sql.AppendLine("left outer join tb_est_marca marca ");
            sql.AppendLine("on marca.cd_marca = b.cd_marca ");
            //Condicao Fiscal Produto
            sql.AppendLine("left outer join tb_fis_condfiscal_produto cond ");
            sql.AppendLine("on b.cd_condfiscal_produto = cond.cd_condfiscal_produto ");
            //Vendedor Pedido
            sql.AppendLine("left outer join tb_fin_clifor vend ");
            sql.AppendLine("on a.cd_vendedor = vend.cd_clifor ");
            //NCM
            sql.AppendLine("left outer join tb_fis_ncm nc ");
            sql.AppendLine("on b.ncm = nc.ncm ");
            //Tipo Servico
            sql.AppendLine("left outer join tb_est_tiposervico tpserv ");
            sql.AppendLine("on b.id_tpservico = tpserv.id_tpservico ");

            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    if ((filtro.vNM_Campo != null) && (filtro.vOperador != null) && (filtro.vVL_Busca != null))
                        sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine("group by " + vGroup.Trim());
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaSaldoMestra(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.NR_Pedido, a.NR_PedidoOrigem, a.id_pedidoitem, ");
                sql.AppendLine("a.CD_Empresa, a.NM_Empresa, a.CD_Clifor, a.NM_Clifor, a.CD_Local, a.DS_Local, ");
                sql.AppendLine("a.TP_Pessoa, a.NR_CGC, a.NR_CPF, a.DS_Endereco, a.CD_Cidade, a.PC_Aliquota_Aprox, ");
                sql.AppendLine("a.DS_Cidade, a.UF, a.DS_UF, a.CD_Produto, a.DS_Produto, a.CD_CondFiscal_Produto, ");
                sql.AppendLine("a.TP_Movimento, a.TP_Frete, a.ST_Deposito, a.Vl_Unitario, ");
                sql.AppendLine("a.qtd_conferencia, a.Quantidade, a.Vl_SubTotal, ");
                sql.AppendLine("a.CD_UnES, a.SG_UnES, a.DS_UnES,");
                sql.AppendLine("a.CD_UnVL, a.SG_UnVL, a.DS_UnVL,");
                sql.AppendLine("a.Vl_Desc, a.ST_Registro, a.ds_observacaoitem, ");
                sql.AppendLine("a.pc_juro_fin, a.pc_desc, a.pc_acrescimo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_FAT_SaldoMestra a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("order by a.id_pedidoitem ");

            return sql.ToString();
        }

        private string SqlCodeBuscaSaldoNFNormal(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.NR_Pedido, a.NR_PedidoOrigem, a.id_pedidoitem, a.nr_contrato, ");
                sql.AppendLine("a.CD_Empresa, a.NM_Empresa, a.CD_Clifor, a.NM_Clifor, a.CD_Local, a.DS_Local, ");
                sql.AppendLine("a.TP_Pessoa, a.NR_CGC, a.NR_CPF, a.DS_Endereco, a.CD_Cidade, a.TP_Frete, ");
                sql.AppendLine("a.DS_Cidade, a.UF, a.DS_UF, a.CD_Produto, a.DS_Produto, a.CD_CondFiscal_Produto, ");
                sql.AppendLine("a.TP_Movimento, a.ST_Deposito, a.Vl_Unitario, a.ds_observacaoitem, ");
                sql.AppendLine("a.qtd_conferencia, a.Quantidade, a.Vl_SubTotal, ");
                sql.AppendLine("a.CD_UnES, a.SG_UnES, a.DS_UnES,");
                sql.AppendLine("a.CD_UnVL, a.SG_UnVL, a.DS_UnVL,");
                sql.AppendLine("a.Vl_Desc, a.ST_Registro, a.pc_imposto_aprox, ");
                sql.AppendLine("a.pc_juro_fin, a.pc_desc, a.pc_acrescimo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_FAT_SaldoNFNormal a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("order by a.id_pedidoitem ");

            return sql.ToString();
        }

        //Obs.: Não devolve nota mestra
        private string SqlCodeBuscaSaldoDevolucao(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "a.NR_Pedido, a.NR_PedidoOrigem, a.CD_Endereco, a.CD_Empresa, a.NM_Empresa, a.id_pedidoitem, a.nr_contrato, ");
                sql.AppendLine("a.CD_Clifor, a.NM_Clifor, a.CD_Local, a.DS_Local, a.CD_CondFiscal_Clifor, a.TP_Pessoa, a.NR_CGC, a.NR_CPF, ");
                sql.AppendLine("a.ST_Equiparado_PJ, a.ST_Agropecuaria, a.DS_Endereco, a.CD_Cidade, a.DS_Cidade, a.UF, a.DS_UF, a.CD_Produto, ");
                sql.AppendLine("a.DS_Produto, a.CD_CondFiscal_Produto, a.TP_Movimento, a.TP_Frete, a.ST_Deposito, a.Vl_Unitario, ");
                sql.AppendLine("a.CFG_Pedido, a.DS_TipoPedido, a.UF_Empresa, a.CD_UnES, a.ds_observacaoitem, ");
                sql.AppendLine("a.SG_UnES, a.DS_UnES, a.CD_UnVL, a.SG_UnVL, ");
                sql.AppendLine("a.DS_UnVL, a.Vl_Desc, a.ST_Registro, a.qtd_conferencia, ");
                sql.AppendLine("a.Quantidade, a.Vl_subTotal, a.pc_imposto_aprox, ");
                sql.AppendLine("a.pc_juro_fin, a.pc_desc, a.pc_acrescimo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_FAT_SaldoDevolucao a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("order by a.id_pedidoitem ");

            return sql.ToString();
        }

        private string SqlCodeBuscaSaldoSimplesRemessa(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.NR_Pedido, a.NR_PedidoOrigem, a.id_pedidoitem, ");
                sql.AppendLine("a.CD_Empresa, a.NM_Empresa, a.CD_Clifor, a.NM_Clifor, a.CD_Local, a.DS_Local, ");
                sql.AppendLine("a.TP_Pessoa, a.NR_CGC, a.NR_CPF, a.CD_CondFiscal_Clifor, a.DS_Endereco, a.CD_Cidade, ");
                sql.AppendLine("a.DS_Cidade, a.UF, a.DS_UF, a.CD_Produto, a.DS_Produto, a.CD_CondFiscal_Produto, a.TP_Movimento, a.ST_Deposito, ");
                sql.AppendLine("a.Vl_Unitario, a.ds_observacaoitem, a.TP_Frete, ");
                sql.AppendLine("a.qtd_conferencia, a.Quantidade, a.Vl_SubTotal, ");
                sql.AppendLine("a.CD_UnES, a.SG_UnES, a.DS_UnES,");
                sql.AppendLine("a.CD_UnVL, a.SG_UnVL, a.DS_UnVL,");
                sql.AppendLine("a.Vl_Desc, a.ST_Registro, a.pc_imposto_aprox, ");
                sql.AppendLine("a.pc_juro_fin, a.pc_desc, a.pc_acrescimo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From VTB_FAT_SaldoSimplesRemessa a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("order by a.id_pedidoitem ");

            return sql.ToString();
        }

        public DataTable BuscarRelAnaliticoPorClifor(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select  a.nr_pedido, a.cd_produto, b.ds_produto, ");
            sql.AppendLine("a.vl_juro_fin, n.st_pedido, c.Sigla_Unidade as sg_unidade_est, ");
            sql.AppendLine("n.DT_Pedido, n.cd_empresa, f.sigla_unidade as sg_unidade_valor, a.vl_acrescimo, ");
            sql.AppendLine("a.quantidade, a.vl_unitario, a.vl_freteitem, a.vl_subtotal, a.vl_desc, ");
            sql.AppendLine("n.tp_movimento, m.nm_empresa, clifor.cd_clifor, clifor.nm_clifor, ");
            sql.AppendLine("case when clifor.tp_pessoa = 'J' then clifor.nr_cgc else clifor.nr_cpf end as nr_cgc_cpf ");

            sql.AppendLine("from vtb_fat_pedido_itens a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join vtb_fat_pedido n ");
            sql.AppendLine("on a.nr_pedido = n.nr_pedido ");
            sql.AppendLine("left outer join vtb_fin_clifor clifor ");
            sql.AppendLine("on n.cd_clifor = clifor.cd_clifor ");
            sql.AppendLine("left outer join tb_div_empresa m ");
            sql.AppendLine("on n.cd_empresa = m.cd_empresa ");
            sql.AppendLine("left outer join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join tb_est_unidade f ");
            sql.AppendLine("on a.cd_unidade = f.cd_unidade ");

            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            string cond = " and ";
            if (filtro != null)
                foreach (TpBusca f in filtro)
                    if ((f.vNM_Campo != null) && (f.vOperador != null) && (f.vVL_Busca != null))
                        sql.AppendLine(cond + "(" + f.vNM_Campo + " " + f.vOperador + " " + f.vVL_Busca + ")");

            return ExecutarBusca(sql.ToString(), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca, System.Reflection.BindingFlags.InvokeMethod |
                                 System.Reflection.BindingFlags.Public |
                                 System.Reflection.BindingFlags.DeclaredOnly |
                                 System.Reflection.BindingFlags.Default |
                                 System.Reflection.BindingFlags.ExactBinding |
                                 System.Reflection.BindingFlags.FlattenHierarchy |
                                 System.Reflection.BindingFlags.Instance |
                                 System.Reflection.BindingFlags.NonPublic).Invoke(this, new object[] { vBusca, vTop, "" }).ToString();


                return ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (NM_ProcSqlBusca == "")
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca, System.Reflection.BindingFlags.InvokeMethod |
                                 System.Reflection.BindingFlags.Public |
                                 System.Reflection.BindingFlags.DeclaredOnly |
                                 System.Reflection.BindingFlags.Default |
                                 System.Reflection.BindingFlags.ExactBinding |
                                 System.Reflection.BindingFlags.FlattenHierarchy |
                                 System.Reflection.BindingFlags.Instance |
                                 System.Reflection.BindingFlags.NonPublic).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();

                return ExecutarBuscaEscalar(sql, null);
            }

        }

        protected override object ExecutarBuscaEscalar(string vSQLCode, Hashtable Parametros)
        {
            return base.ExecutarBuscaEscalar(vSQLCode, Parametros);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (NM_ProcSqlBusca == "")
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca, System.Reflection.BindingFlags.InvokeMethod |
                                 System.Reflection.BindingFlags.Public |
                                 System.Reflection.BindingFlags.DeclaredOnly |
                                 System.Reflection.BindingFlags.Default |
                                 System.Reflection.BindingFlags.ExactBinding |
                                 System.Reflection.BindingFlags.FlattenHierarchy |
                                 System.Reflection.BindingFlags.Instance |
                                 System.Reflection.BindingFlags.NonPublic).Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();


                return ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public TList_RegLanPedido_Item Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            TList_RegLanPedido_Item lista = new TList_RegLanPedido_Item();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder));
                while (reader.Read())
                {
                    TRegistro_LanPedido_Item LanPedido_Item = new TRegistro_LanPedido_Item();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        LanPedido_Item.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        LanPedido_Item.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_pedidoitem")))
                        LanPedido_Item.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        LanPedido_Item.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        LanPedido_Item.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        LanPedido_Item.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        LanPedido_Item.Cd_referencia = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        LanPedido_Item.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condfiscal_produto")))
                        LanPedido_Item.Ds_condfiscal_produto = reader.GetString(reader.GetOrdinal("ds_condfiscal_produto"));
                    if (reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        LanPedido_Item.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        LanPedido_Item.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        LanPedido_Item.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Valor")))
                        LanPedido_Item.Cd_unidade_valor = reader.GetString(reader.GetOrdinal("CD_Unidade_Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade_Valor")))
                        LanPedido_Item.Ds_unidade_valor = reader.GetString(reader.GetOrdinal("DS_Unidade_Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Unidade_Valor")))
                        LanPedido_Item.Sg_unidade_valor = reader.GetString(reader.GetOrdinal("SG_Unidade_Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Est")))
                        LanPedido_Item.Cd_unidade_est = reader.GetString(reader.GetOrdinal("CD_Unidade_Est"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade_Est")))
                        LanPedido_Item.Ds_unidade_est = reader.GetString(reader.GetOrdinal("DS_Unidade_Est"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Unidade_Est")))
                        LanPedido_Item.Sg_unidade_est = reader.GetString(reader.GetOrdinal("SG_Unidade_Est"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_unidade")))
                        LanPedido_Item.Tp_unidade = reader.GetString(reader.GetOrdinal("tp_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        LanPedido_Item.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Expedida")))
                        LanPedido_Item.Qtd_expedida = reader.GetDecimal(reader.GetOrdinal("QTD_Expedida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Faturada")))
                        LanPedido_Item.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("QTD_Faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Devolvida")))
                        LanPedido_Item.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("QTD_Devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Conferida")))
                        LanPedido_Item.Qtd_conferida = reader.GetDecimal(reader.GetOrdinal("QTD_Conferida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        LanPedido_Item.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        LanPedido_Item.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desc")))
                        LanPedido_Item.Vl_desc = reader.GetDecimal(reader.GetOrdinal("Vl_Desc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_FreteItem")))
                        LanPedido_Item.Vl_freteitem = reader.GetDecimal(reader.GetOrdinal("Vl_FreteItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acrescimo")))
                        LanPedido_Item.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("Vl_Acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_fichatec")))
                        LanPedido_Item.Ds_Fichatec = reader.GetString(reader.GetOrdinal("DS_fichatec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_TanqueAereo")))
                        LanPedido_Item.St_TanqueAereo = reader.GetString(reader.GetOrdinal("St_TanqueAereo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ObservacaoItem")))
                        LanPedido_Item.Ds_observacaoitem = reader.GetString(reader.GetOrdinal("DS_ObservacaoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        LanPedido_Item.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Movimento"))))
                        LanPedido_Item.Tp_Movimento = reader.GetString(reader.GetOrdinal("Tp_movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_Empresa"))))
                        LanPedido_Item.Nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Marca")))
                        LanPedido_Item.Ds_marca = reader.GetString(reader.GetOrdinal("DS_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Estoque")))
                        LanPedido_Item.Qtd_estoque = reader.GetDecimal(reader.GetOrdinal("QTD_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_reservada")))
                        LanPedido_Item.Qtd_reservada = reader.GetDecimal(reader.GetOrdinal("Qtd_reservada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Juro_Fin")))
                        LanPedido_Item.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("Vl_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        LanPedido_Item.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        LanPedido_Item.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemorc")))
                        LanPedido_Item.Id_itemorc = reader.GetDecimal(reader.GetOrdinal("id_itemorc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_comissao")))
                        LanPedido_Item.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_CustoItem")))
                        LanPedido_Item.Vl_custoitem = reader.GetDecimal(reader.GetOrdinal("Vl_CustoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        LanPedido_Item.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomevendedor")))
                        LanPedido_Item.Nomevendedor = reader.GetString(reader.GetOrdinal("nomevendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        LanPedido_Item.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        LanPedido_Item.ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tecnica")))
                        LanPedido_Item.Ds_tecnica = reader.GetString(reader.GetOrdinal("ds_tecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaAssistencia")))
                        LanPedido_Item.DS_TecnicaAssistencia = reader.GetString(reader.GetOrdinal("DS_TecnicaAssistencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
                        LanPedido_Item.Img = (byte[])reader.GetValue(reader.GetOrdinal("imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_frete")))
                        LanPedido_Item.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_imposto_aprox")))
                        LanPedido_Item.Pc_imposto_Aprox = reader.GetDecimal(reader.GetOrdinal("pc_imposto_aprox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_pedido")))
                        LanPedido_Item.Dt_pedido = reader.GetDateTime(reader.GetOrdinal("dt_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        LanPedido_Item.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                        LanPedido_Item.St_servico = reader.GetString(reader.GetOrdinal("st_servico")).ToString().Trim().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_unitario")))
                        LanPedido_Item.Ps_unitario = reader.GetDecimal(reader.GetOrdinal("Ps_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_exigirserie")))
                        LanPedido_Item.St_exigirserie = reader.GetString(reader.GetOrdinal("St_exigirserie")).ToString().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("altura")))
                        LanPedido_Item.altura = reader.GetDecimal(reader.GetOrdinal("altura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("comprimento_und")))
                        LanPedido_Item.comprimento_und = reader.GetDecimal(reader.GetOrdinal("comprimento_und"));
                    if (!reader.IsDBNull(reader.GetOrdinal("largura")))
                        LanPedido_Item.largura = reader.GetDecimal(reader.GetOrdinal("largura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ComRep")))
                        LanPedido_Item.Pc_comrep = reader.GetDecimal(reader.GetOrdinal("PC_ComRep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ProjEspecial")))
                        LanPedido_Item.St_projespecial = reader.GetString(reader.GetOrdinal("ST_ProjEspecial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Subst")))
                        LanPedido_Item.Vl_subst = reader.GetDecimal(reader.GetOrdinal("Vl_Subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_IPI")))
                        LanPedido_Item.Vl_IPI = reader.GetDecimal(reader.GetOrdinal("Vl_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_devpedido")))
                        LanPedido_Item.Qtd_devpedido = reader.GetDecimal(reader.GetOrdinal("qtd_devpedido"));

                    lista.Add(LanPedido_Item);
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

        public static void totalPedido(string vNR_Pedido, string vCD_Produto, decimal vId_pedidoitem, ref decimal tQuantidade, ref decimal tValor)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "a.NR_Pedido";
            vBusca[0].vVL_Busca = vNR_Pedido;
            vBusca[0].vOperador = "=";
            if (vCD_Produto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vId_pedidoitem > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.id_pedidoitem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_pedidoitem.ToString();
            }
            TCD_LanPedido_Item qtb_pedido = new TCD_LanPedido_Item();
            System.Data.DataTable tabela = qtb_pedido.Buscar(vBusca, 1, "isNull(sum(isNull(b.Quantidade,0)),0) as Quantidade," +
                                                            "isNull(sum(isNull(b.Vl_SubTotal,0)),0) as Vl_SubTotal");
            if (tabela != null)
                if (tabela.Rows.Count > 0)
                {
                    try
                    {
                        tQuantidade = Convert.ToDecimal(tabela.Rows[0]["Quantidade"].ToString());
                    }
                    catch
                    { tQuantidade = 0; }
                    try
                    {
                        tValor = Convert.ToDecimal(tabela.Rows[0]["Vl_SubTotal"].ToString());
                    }
                    catch
                    { tValor = 0; }
                }
        }

        public string Grava(TRegistro_LanPedido_Item vRegistro)
        {
            Hashtable hs = new Hashtable(26);

            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);
            hs.Add("@P_CD_LOCAL", vRegistro.Cd_local);
            hs.Add("@P_CD_UNIDADE", vRegistro.Cd_unidade_valor);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_VL_UNITARIO", vRegistro.Vl_unitario);
            hs.Add("@P_VL_FRETEITEM", vRegistro.Vl_freteitem);
            hs.Add("@P_VL_ACRESCIMO", vRegistro.Vl_acrescimo);
            hs.Add("@P_VL_SUBTOTAL", vRegistro.Vl_subtotal);
            hs.Add("@P_VL_DESC", vRegistro.Vl_desc);
            hs.Add("@P_DS_FICHATEC", vRegistro.Ds_Fichatec);
            hs.Add("@P_DS_OBSERVACAOITEM", vRegistro.Ds_observacaoitem);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
            hs.Add("@P_VL_JURO_FIN", vRegistro.Vl_juro_fin);
            hs.Add("@P_NR_ORCAMENTO", vRegistro.Nr_orcamento);
            hs.Add("@P_ID_ITEMORC", vRegistro.Id_itemorc);
            hs.Add("@P_CD_VENDEDOR", vRegistro.Cd_vendedor);
            hs.Add("@P_LARGURA", vRegistro.largura);
            hs.Add("@P_ALTURA", vRegistro.altura);
            hs.Add("@P_COMPRIMENTO", vRegistro.comprimento_und);
            hs.Add("@P_VL_CUSTOITEM", vRegistro.Vl_custoitem);
            hs.Add("@P_PC_COMREP", vRegistro.Pc_comrep);
            hs.Add("@P_ST_PROJESPECIAL", vRegistro.St_projespecial);
            hs.Add("@P_VL_SUBST", vRegistro.Vl_subst);
            hs.Add("@P_VL_IPI", vRegistro.Vl_IPI);

            return executarProc("IA_FAT_PEDIDO_ITENS", hs);
        }

        public string Deleta(TRegistro_LanPedido_Item vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);

            return executarProc("EXCLUI_FAT_PEDIDO_ITENS", hs);
        }
    }
    #endregion

    #region Classe Ficha Tecnica Item
    public class TList_FichaTecItemPed : List<TRegistro_FichaTecItemPed>
    { }


    public class TRegistro_FichaTecItemPed
    {
        public decimal? Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_pedidoitem
        { get; set; }
        public decimal? Id_ficha
        { get; set; }
        public string Cd_item
        { get; set; }
        public string Ds_item
        { get; set; }
        public string Ncm
        { get; set; }
        public string Cest
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public string Cd_local
        { get; set; }
        public decimal Cd_marca
        { get; set; }
        public string Ds_marca
        { get; set; }
        public string Cd_unditem
        { get; set; }
        public string Ds_unditem
        { get; set; }
        public string Sg_unditem
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_custo
        { get; set; }
        public decimal Vl_venda
        { get; set; }
        public decimal Vl_subtotal
        { get { return Quantidade * Vl_venda; } }
        public decimal Qtd_itemPed { get; set; } = decimal.Zero;
        public TRegistro_FichaTecItemPed()
        {
            Nr_pedido = null;
            Cd_produto = string.Empty;
            Id_pedidoitem = null;
            Id_ficha = null;
            Cd_item = string.Empty;
            Ds_item = string.Empty;
            Ncm = string.Empty;
            Cest = string.Empty;
            Cd_referencia = string.Empty;
            Cd_local = string.Empty;
            Cd_marca = decimal.Zero;
            Ds_marca = string.Empty;
            Cd_unditem = string.Empty;
            Ds_unditem = string.Empty;
            Sg_unditem = string.Empty;
            Quantidade = decimal.Zero;
            Vl_custo = decimal.Zero;
            Vl_venda = decimal.Zero;
        }
    }

    public class TCD_FichaTecItemPed : TDataQuery
    {
        public TCD_FichaTecItemPed()
        { }

        public TCD_FichaTecItemPed(TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Nr_Pedido, a.CD_Produto, iped.quantidade as qtd_itemped, ");
                sql.AppendLine("a.ID_PedidoItem, a.id_ficha, a.CD_Item, a.ds_item, a.cd_local, ISNULL(b.Codigo_Alternativo, 'RF') as cd_referencia, ");
                sql.AppendLine("b.CD_Marca, d.DS_Marca, b.cd_unidade as cd_unditem, c.ds_unidade as ds_unditem, ");
                sql.AppendLine("c.sigla_Unidade as sg_unditem, a.quantidade, b.ncm, nc.cest, ");
                sql.AppendLine("case when dbo.F_CUSTO_MEDIOESTOQUE(ped.cd_empresa, a.cd_item, getdate()) > 0 then ");
                sql.AppendLine("dbo.F_CUSTO_MEDIOESTOQUE(ped.cd_empresa, a.cd_item, getdate()) else ");
                sql.AppendLine("(select isnull(x.quantidade, 0) * isnull(x.vl_custoservico, 0) ");
                sql.AppendLine("from tb_est_fichatecproduto x ");
                sql.AppendLine("where x.cd_produto = a.cd_produto ");
                sql.AppendLine("and x.cd_item = a.cd_item) end as vl_custo, ");
                sql.AppendLine("vl_venda = isnull((select vl_precovenda ");
                sql.AppendLine("                    from VTB_EST_PRECOVENDA x ");
                sql.AppendLine("                    where x.cd_empresa = ped.cd_empresa ");
                sql.AppendLine("                    and x.cd_tabelapreco = ped.cd_tabelapreco ");
                sql.AppendLine("                    and x.cd_produto = a.cd_item), 0)");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_FichaTecItemPed a ");
            sql.AppendLine("left join tb_est_produto b ");
            sql.AppendLine("on a.cd_item = b.cd_produto ");
            sql.AppendLine("left join tb_est_unidade c ");
            sql.AppendLine("on b.cd_Unidade = c.cd_unidade ");
            sql.AppendLine("inner join vtb_fat_pedido ped ");
            sql.AppendLine("on a.nr_pedido = ped.nr_pedido ");
            sql.AppendLine("inner join tb_fat_pedido_itens iPed ");
            sql.AppendLine("on a.nr_pedido = iped.nr_pedido ");
            sql.AppendLine("and a.cd_produto = iped.cd_produto ");
            sql.AppendLine("and a.id_pedidoitem =iped.id_pedidoitem ");
            sql.AppendLine("left outer join TB_EST_Marca d ");
            sql.AppendLine("on b.CD_Marca = d.CD_Marca ");
            sql.AppendLine("left outer join TB_FIS_NCM nc ");
            sql.AppendLine("on b.ncm = nc.ncm ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    if ((filtro.vNM_Campo != null) && (filtro.vOperador != null) && (filtro.vVL_Busca != null))
                    {
                        sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_FichaTecItemPed Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FichaTecItemPed lista = new TList_FichaTecItemPed();
            SqlDataReader reader = null;

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_FichaTecItemPed reg = new TRegistro_FichaTecItemPed();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_ficha")))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("Id_ficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Item")))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("CD_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("DS_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("Cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_referencia")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("cd_referencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Marca")))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("CD_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("Ds_Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UndItem")))
                        reg.Cd_unditem = reader.GetString(reader.GetOrdinal("CD_UndItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UndItem")))
                        reg.Ds_unditem = reader.GetString(reader.GetOrdinal("DS_UndItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sg_undItem")))
                        reg.Sg_unditem = reader.GetString(reader.GetOrdinal("Sg_UndItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("vl_custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_venda")))
                        reg.Vl_venda = reader.GetDecimal(reader.GetOrdinal("vl_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_itemped")))
                        reg.Qtd_itemPed = reader.GetDecimal(reader.GetOrdinal("qtd_itemped"));

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

        public string Gravar(TRegistro_FichaTecItemPed val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_DS_ITEM", val.Ds_item);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return executarProc("IA_FAT_FICHATECITEMPED", hs);
        }

        public string Excluir(TRegistro_FichaTecItemPed val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_ID_FICHA", val.Id_ficha);

            return executarProc("EXCLUI_FAT_FICHATECITEMPED", hs);
        }
    }
    #endregion

    #region Classe Itens Devolvidos
    public class TList_ItensDevolvidos : List<TRegistro_ItensDevolvidos>, IComparer<TRegistro_ItensDevolvidos>
    {
        #region IComparer<TRegistro_LanPedido_Item> Members
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

        public TList_ItensDevolvidos()
        { }

        public TList_ItensDevolvidos(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensDevolvidos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensDevolvidos x, TRegistro_ItensDevolvidos y)
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

    public class TRegistro_ItensDevolvidos
    {
        public decimal? Nr_Pedido { get; set; }
        public string CD_Produto { get; set; }
        public decimal? ID_PedidoItem { get; set; }
        public decimal? ID_Devolvido { get; set; }
        public DateTime? DT_Devolucao { get; set; }
        public decimal QTD_Devolvida { get; set; }

        public TRegistro_ItensDevolvidos()
        {
            Nr_Pedido = null;
            CD_Produto = string.Empty;
            ID_PedidoItem = null;
            ID_Devolvido = null;
            DT_Devolucao = null;
            QTD_Devolvida = decimal.Zero;
        }
    }

    public class TCD_ItensDevolvidos : TDataQuery
    {
        public TCD_ItensDevolvidos()
        { }

        public TCD_ItensDevolvidos(TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Nr_Pedido, a.CD_Produto, a.ID_PedidoItem, a.ID_Devolvido, a.DT_Devolucao, a.QTD_Devolvida ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ItensDevolvidos a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    if ((filtro.vNM_Campo != null) && (filtro.vOperador != null) && (filtro.vVL_Busca != null))
                    {
                        sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                        cond = "and";
                    }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public TList_ItensDevolvidos Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ItensDevolvidos lista = new TList_ItensDevolvidos();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensDevolvidos _ItensDevolvidos = new TRegistro_ItensDevolvidos();
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        _ItensDevolvidos.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        _ItensDevolvidos.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        _ItensDevolvidos.ID_PedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Devolvido")))
                        _ItensDevolvidos.ID_Devolvido = reader.GetDecimal(reader.GetOrdinal("ID_Devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Devolucao")))
                        _ItensDevolvidos.DT_Devolucao = reader.GetDateTime(reader.GetOrdinal("DT_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Devolvida")))
                        _ItensDevolvidos.QTD_Devolvida = reader.GetDecimal(reader.GetOrdinal("QTD_Devolvida"));

                    lista.Add(_ItensDevolvidos);
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

        public string Gravar(TRegistro_ItensDevolvidos vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.ID_PedidoItem);
            hs.Add("@P_ID_DEVOLVIDO", vRegistro.ID_Devolvido);
            hs.Add("@P_DT_DEVOLUCAO", vRegistro.DT_Devolucao);
            hs.Add("@P_QTD_DEVOLVIDA", vRegistro.QTD_Devolvida);

            return executarProc("IA_FAT_ITENSDEVOLVIDOS", hs);
        }

        public string Excluir(TRegistro_ItensDevolvidos vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.ID_PedidoItem);
            hs.Add("@P_ID_DEVOLVIDO", vRegistro.ID_Devolvido);

            return executarProc("EXCLUI_FAT_ITENSDEVOLVIDOS", hs);
        }
    }
    #endregion
}
