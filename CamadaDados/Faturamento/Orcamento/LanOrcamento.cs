using CamadaDados.Faturamento.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Orcamento
{
    #region Classe Orcamento
    public class TList_Orcamento : List<TRegistro_Orcamento>, IComparer<TRegistro_Orcamento>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_Orcamento()
        { }

        public TList_Orcamento(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Orcamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Orcamento x, TRegistro_Orcamento y)
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

    public class TRegistro_Orcamento
    {
        private decimal? nr_orcamento;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = Convert.ToDecimal(value);
                }
                catch
                { nr_orcamento = null; }
            }
        }
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }
        public decimal NR_Versao
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Uf
        { get; set; }
        public string Fone_clifor
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_representante
        { get; set; }
        public string Nm_representante
        { get; set; }
        public string Cd_cliforind
        { get; set; }
        public string Nm_cliforind
        { get; set; }
        public string Cd_gerente { get; set; }
        public string Nm_gerente { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        private DateTime? dt_orcamento;
        public DateTime? Dt_orcamento
        {
            get { return dt_orcamento; }
            set
            {
                dt_orcamento = value;
                dt_orcamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_orcamentostr;
        public string Dt_orcamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_orcamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_orcamentostr = value;
                try
                {
                    dt_orcamento = Convert.ToDateTime(value);
                }
                catch
                { dt_orcamento = null; }
            }
        }
        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = Convert.ToDateTime(value);
                }
                catch
                { dt_validade = null; }
            }
        }
        private decimal pc_desconto;
        public decimal Pc_desconto
        {
            get { return Math.Round(pc_desconto, 5); }
            set { pc_desconto = value; }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return Math.Round(vl_desconto, 2); }
            set { vl_desconto = value; }
        }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return Math.Round(vl_acrescimo, 2); }
            set { vl_acrescimo = value; }
        }
        private decimal vl_frete;
        public decimal Vl_frete
        {
            get { return Math.Round(vl_frete, 2); }
            set { vl_frete = value; }
        }
        //
        private decimal vl_juro_fin;
        public decimal Vl_juro_fin
        {
            get { return Math.Round(vl_juro_fin, 2); }
            set { vl_juro_fin = value; }
        }
        public decimal Vl_totalitens
        { get; set; }
        public decimal Vl_totalorcamento
        {
            get { return lItens.Sum(p => p.Vl_subtotalliq) + Vl_impostosomar - Vl_impostosubtrair; }
        }
        public decimal Pc_comrep
        { get; set; }
        public decimal Vl_faturado
        { get; set; }
        public decimal Total_ItensComprados
        { get; set; }
        public decimal Vl_saldofaturar
        { get { return Vl_totalitens - Vl_faturado; } }
        public string Ds_observacoes
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("AB"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("AR"))
                    status = "AGUARDANDO RETORNO";
                else if (value.Trim().ToUpper().Equals("FT"))
                    status = "PROCESSADO";
                else if (value.Trim().ToUpper().Equals("CA"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("RE"))
                    status = "REPROVADO";
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
                    st_registro = "AB";
                else if (value.Trim().ToUpper().Equals("AGUARDANDO RETORNO"))
                    st_registro = "AR";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "FT";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "CA";
                else if (value.Trim().ToUpper().Equals("REPROVADO"))
                    st_registro = "RE";
            }
        }
        public string MotivoCanc { get; set; } = string.Empty;
        private string st_OrcPedido;
        public string St_OrcPedido
        {
            get { return st_OrcPedido; }
            set
            {
                st_OrcPedido = value;
                if (value.Trim().ToUpper().Equals("AB"))
                    statusOrcPedido = "ABERTA";
                else if (value.Trim().ToUpper().Equals("CA"))
                    statusOrcPedido = "CANCELADA";
                else if (value.Trim().ToUpper().Equals("PA"))
                    statusOrcPedido = "PROPOSTA APROVADA";
                else if (value.Trim().ToUpper().Equals("PF"))
                    statusOrcPedido = "PROPOSTA FECHADA";
            }
        }
        private string statusOrcPedido;
        public string StatusOrcPedido
        {
            get { return statusOrcPedido; }
            set
            {
                statusOrcPedido = value;
                if (value.Trim().ToUpper().Equals("ABERTA"))
                    st_OrcPedido = "AB";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_OrcPedido = "CA";
                else if (value.Trim().ToUpper().Equals("PROPOSTA APROVADA"))
                    st_OrcPedido = "PA";
                else if (value.Trim().ToUpper().Equals("PROPOSTA FECHADA"))
                    st_OrcPedido = "PF";
            }
        }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        public decimal Vl_impostosomar
        { get; set; }
        public decimal Vl_impostosubtrair
        { get; set; }
        private string tp_descarga;
        public string TP_descarga
        {
            get { return tp_descarga; }
            set
            {
                tp_descarga = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_descarga = "VENDEDOR";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_descarga = "COMPRADOR";

            }
        }
        private string tipo_descarga;
        public string Tipo_descarga
        {
            get { return tipo_descarga; }
            set
            {
                tipo_descarga = value;
                if (value.Trim().ToUpper().Equals("VENDEDOR"))
                    tp_descarga = "P";
                else if (value.Trim().ToUpper().Equals("COMPRADOR"))
                    tp_descarga = "T";
            }
        }
        private string tp_frete;
        public string Tp_frete
        {
            get { return tp_frete; }
            set
            {
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_frete = "EMITENTE";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_frete = "DESTINATARIO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_frete = "TERCEIRO";
                else if (value.Trim().ToUpper().Equals("9"))
                    tipo_frete = "SEM FRETE";
                lItens.ForEach(p => p.St_somarFrete = value.Trim().ToUpper().Equals("0"));
            }
        }
        private string tipo_frete;
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("EMITENTE"))
                    tp_frete = "0";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_frete = "1";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_frete = "2";
                else if (value.Trim().ToUpper().Equals("SEM FRETE"))
                    tp_frete = "9";
                lItens.ForEach(p => p.St_somarFrete = value.Trim().ToUpper().Equals("0"));
            }
        }
        public decimal PrazoEntrega
        { get; set; }
        public decimal Vl_entrada
        { get; set; }
        //Configuracao para calculo do valor do orcamento com juros financeiros
        public string Cd_juro_fin
        { get; set; }
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        public decimal Qt_diasdesdobro
        { get; set; }
        public string Tp_juro
        { get; set; }
        public bool St_cometrada
        { get; set; }
        public decimal QTD_Parcelas
        { get; set; }
        public string Parcelas_Entrada
        { get; set; }
        public decimal Parcelas_Dias_Desdobro
        { get; set; }
        public string Parcelas_Feriado
        { get; set; }
        public string ST_SolicitarDtVencto
        { get; set; }
        public TList_Orcamento_Item lItens
        { get; set; }
        public TList_Orcamento_Item lItensDel
        { get; set; }
        public TList_Orcamento_DT_Vencto lParcelas
        { get; set; }
        public TList_ItensCompraOrcProj lItensCompra
        { get; set; }
        public TList_ItensCompraOrcProj lItensCompraDel
        { get; set; }
        public decimal? Nr_pedidovenda
        { get; set; }
        public decimal? Id_os
        { get; set; }
        public decimal? Nr_venda
        { get; set; }
        public string LoginDesconto
        { get; set; }
        public decimal Pc_Icms_UF
        { get; set; }
        private string st_orcprojeto;
        public string St_orcprojeto
        {
            get { return st_orcprojeto; }
            set
            {
                st_orcprojeto = value;
                st_orcprojetobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_orcprojetobool;
        public bool St_orcprojetobool
        {
            get { return st_orcprojetobool; }
            set
            {
                st_orcprojetobool = value;
                st_orcprojeto = value ? "S" : "N";
            }
        }
        public string Nr_orcorigem
        { get; set; }
        public string Cd_cliforent
        { get; set; }
        public string Nm_cliforent
        { get; set; }
        public string Cnpj_cpfent
        { get; set; }
        public string Cd_enderecoent
        { get; set; }
        public string Logradouroent
        { get; set; }
        public string Numeroent
        { get; set; }
        public string Complementoent
        { get; set; }
        public string Bairroent
        { get; set; }
        public string Cd_cidadeent
        { get; set; }
        public string Ds_cidadeent
        { get; set; }
        public string Uf_ent
        { get; set; }
        public string Cd_UFEnt
        { get; set; }
        public NotaFiscal.TList_RegLanFaturamento lNotaFiscal
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanParcela lParc { get; set; } = new Financeiro.Duplicata.TList_RegLanParcela();
        public TList_EtapaPedido lEtapa
        { get; set; }
        public TRegistro_Pedido rPedido
        { get; set; }
        public TList_AcessoriosPed lAcessorios
        { get; set; }
        public bool Selecionado { get; set; }


        public TRegistro_Orcamento()
        {
            nr_orcamento = null;
            nr_orcamentostr = string.Empty;
            cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            NR_Versao = decimal.Zero;
            Cd_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Cd_representante = string.Empty;
            Nm_representante = string.Empty;
            Cd_cliforind = string.Empty;
            Nm_cliforind = string.Empty;
            Cd_gerente = string.Empty;
            Nm_gerente = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            dt_orcamento = DateTime.Now;
            dt_orcamentostr = DateTime.Now.ToString("dd/MM/yyyy");
            dt_validade = null;
            dt_validadestr = string.Empty;
            pc_desconto = decimal.Zero;
            vl_desconto = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            vl_frete = decimal.Zero;
            vl_juro_fin = decimal.Zero;
            Nm_clifor = string.Empty;
            Fone_clifor = string.Empty;
            Ds_endereco = string.Empty;
            Ds_cidade = string.Empty;
            Uf = string.Empty;
            Ds_observacoes = string.Empty;
            st_registro = "AB";
            status = "ABERTO";
            Cd_juro_fin = string.Empty;
            Pc_jurodiario_atrazo = decimal.Zero;
            Qt_diasdesdobro = decimal.Zero;
            Tp_juro = string.Empty;
            St_cometrada = false;
            QTD_Parcelas = decimal.Zero;
            Parcelas_Entrada = string.Empty;
            Parcelas_Dias_Desdobro = decimal.Zero;
            Parcelas_Feriado = string.Empty;
            ST_SolicitarDtVencto = string.Empty;
            Nr_pedidovenda = null;
            Id_os = null;
            Nr_venda = null;
            Cfg_pedido = string.Empty;
            Ds_tipopedido = string.Empty;
            Vl_impostosomar = decimal.Zero;
            Vl_impostosubtrair = decimal.Zero;
            tp_descarga = string.Empty;
            tipo_descarga = string.Empty;
            tp_frete = string.Empty;
            tipo_frete = string.Empty;
            PrazoEntrega = decimal.Zero;
            Vl_entrada = decimal.Zero;
            LoginDesconto = string.Empty;
            Pc_Icms_UF = decimal.Zero;
            st_orcprojeto = "N";
            st_orcprojetobool = false;
            St_OrcPedido = string.Empty;
            Nr_orcorigem = string.Empty;
            Logradouroent = string.Empty;
            Numeroent = string.Empty;
            Complementoent = string.Empty;
            Bairroent = string.Empty;
            Cd_cliforent = string.Empty;
            Nm_cliforent = string.Empty;
            Cnpj_cpfent = string.Empty;
            Cd_endereco = string.Empty;
            Cd_cidadeent = string.Empty;
            Ds_cidadeent = string.Empty;
            Uf_ent = string.Empty;
            Cd_UFEnt = string.Empty;
            Vl_totalitens = decimal.Zero;
            Vl_faturado = decimal.Zero;
            Total_ItensComprados = decimal.Zero;
            Pc_comrep = decimal.Zero;
            lItens = new TList_Orcamento_Item();
            lItensDel = new TList_Orcamento_Item();
            lParcelas = new TList_Orcamento_DT_Vencto();
            lNotaFiscal = new NotaFiscal.TList_RegLanFaturamento();
            lEtapa = new TList_EtapaPedido();
            rPedido = new TRegistro_Pedido();
            lAcessorios = new TList_AcessoriosPed();
            lItensCompra = new TList_ItensCompraOrcProj();
            lItensCompraDel = new TList_ItensCompraOrcProj();
            Selecionado = false;
        }
    }

    public class TList_OrcPosVenda : List<TRegistro_OrcPosVenda>, IComparer<TRegistro_OrcPosVenda>
    {
        #region IComparer<TRegistro_Orcamento> Members
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

        public TList_OrcPosVenda()
        { }

        public TList_OrcPosVenda(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_OrcPosVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_OrcPosVenda x, TRegistro_OrcPosVenda y)
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

    public class TRegistro_OrcPosVenda
    {
        private decimal? nr_orcamento;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = Convert.ToDecimal(value);
                }
                catch
                { nr_orcamento = null; }
            }
        }
        private string cd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Trim(); } set { cd_empresa = value; } }
        public string Nm_empresa
        { get; set; }
        public decimal NR_Versao
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Fone_clifor
        { get; set; }
        private DateTime? dt_orcamento;
        public DateTime? Dt_orcamento
        {
            get { return dt_orcamento; }
            set
            {
                dt_orcamento = value;
                dt_orcamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_orcamentostr;
        public string Dt_orcamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_orcamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_orcamentostr = value;
                try
                {
                    dt_orcamento = Convert.ToDateTime(value);
                }
                catch
                { dt_orcamento = null; }
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
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
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
                    return Convert.ToDateTime(dt_pedidostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_pedidostr = value;
                try
                {
                    dt_pedido = Convert.ToDateTime(value);
                }
                catch
                { dt_pedido = null; }
            }
        }

        private string cd_produto;
        public string Cd_produto
        { get { return cd_produto.Trim(); } set { cd_produto = value; } }

        private decimal? id_PedidoItem;
        public decimal? ID_PedidoItem
        {
            get { return id_PedidoItem; }
            set
            {
                id_PedidoItem = value;
                id_PedidoItemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_PedidoItemstr;
        public string ID_PedidoItemstr
        {
            get { return id_PedidoItemstr; }
            set
            {
                id_PedidoItemstr = value;
                try
                {
                    id_PedidoItem = Convert.ToDecimal(value);
                }
                catch
                { id_PedidoItem = null; }
            }
        }

        private decimal? quantidade;
        public decimal? Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
            }
        }

        private decimal? vl_subtotal;
        public decimal? Vl_subtotal
        {
            get { return vl_subtotal; }
            set
            {
                vl_subtotal = value;
            }
        }
        public string Ds_produto
        { get; set; }

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
                    nr_notafiscal = Convert.ToDecimal(value);
                }
                catch
                { nr_notafiscal = null; }
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

        private decimal? id_ordem;
        public decimal? Id_ordem
        {
            get { return id_ordem; }
            set
            {
                id_ordem = value;
                id_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ordemstr;
        public string Id_ordemstr
        {
            get { return id_ordemstr; }
            set
            {
                id_ordemstr = value;
                try
                {
                    id_ordem = Convert.ToDecimal(value);
                }
                catch
                { id_ordem = null; }
            }
        }

        private DateTime? dt_carregamento;
        public DateTime? Dt_carregamento
        {
            get { return dt_carregamento; }
            set
            {
                dt_carregamento = value;
                dt_carregamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_carregamentostr;
        public string Dt_carregamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_carregamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_carregamentostr = value;
                try
                {
                    dt_carregamento = Convert.ToDateTime(value);
                }
                catch
                { dt_carregamento = null; }
            }
        }

        public string Contato { get; set; }
        public bool Selecinado { get; set; }


        public TRegistro_OrcPosVenda()
        {
            Nr_orcamento = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Fone_clifor = string.Empty;
            Dt_orcamento = null;
            Nr_pedido = null;
            Dt_pedido = null;
            Cd_produto = null;
            ID_PedidoItem = null;
            Quantidade = null;
            Vl_subtotal = null;
            Ds_produto = string.Empty;
            Nr_notafiscal = null;
            Dt_emissao = null;
            Id_ordem = null;
            Dt_carregamento = null;
            Nm_empresa = string.Empty;
            Cd_empresa = null;
            Contato = string.Empty;
            Selecinado = false;
        }
    }

    public class TCD_Orcamento : TDataQuery
    {
        public TCD_Orcamento()
        { }

        public TCD_Orcamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.CD_Empresa, a.ST_OrcProjeto, a.nr_orcorigem, a.St_OrcPedido, ");
                sql.AppendLine("b.NM_Empresa, a.nr_versao, a.CD_Clifor, a.CD_Endereco, cfgped.ds_tipopedido, ");
                sql.AppendLine("a.CD_Vendedor, c.nm_clifor as nomevendedor, a.CD_Representante, rep.nm_clifor as nm_representante, ");
                sql.AppendLine("a.CD_TabelaPreco, e.DS_TabelaPreco, a.CD_CliforInd, cInd.nm_clifor as nm_cliforind, ");
                sql.AppendLine("a.cd_enderecoent, a.Logradouroent, a.Numeroent, a.Complementoent, a.Bairroent, a.Cd_cidadeent, cid.cd_cidade as Ds_cidadeent, u.uf as Uf_ent, u.cd_uf as Cd_UFEnt, ");
                sql.AppendLine("a.cd_cliforent, cent.nm_clifor as nm_cliforent, case when cent.tp_pessoa = 'J' then cent.nr_cgc else cent.nr_cpf end as cnpj_cpfent, ");
                sql.AppendLine("a.DT_Orcamento, a.DT_Validade, a.Vl_Desconto, a.Vl_Acrescimo, a.LoginDesconto, a.MotivoCanc, ");
                sql.AppendLine("a.Vl_Frete, a.Vl_juro_fin, a.NM_Clifor, a.Fone_Clifor, a.DS_Endereco, a.Vl_totalitens, a.Vl_Faturado, ");
                sql.AppendLine("a.DS_Cidade, a.UF, a.DS_Observacoes, a.ST_Registro, a.pc_comrep, a.cd_gerente, cGer.nm_clifor as nm_gerente, ");
                sql.AppendLine("a.cfg_pedido, a.vl_impostosomar, a.vl_impostosubtrair, a.tp_descarga, a.tp_frete, a.prazoentrega, ");
                //Dados Condicao de Pagamento
                sql.AppendLine(" a.CD_CondPGTO, d.ds_CondPGTO, d.QT_Parcelas, d.ST_ComEntrada, ");
                sql.AppendLine("d.QT_DiasDesdobro, d.ST_VenctoEmFeriado, d.ST_SolicitarDtVencto, ");
                sql.AppendLine("a.nr_pedidovenda, a.id_os, a.nr_venda ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_Orcamento a ");

            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

            sql.AppendLine("inner join tb_fin_clifor c ");
            sql.AppendLine("on a.CD_Vendedor = c.cd_clifor ");

            sql.AppendLine("left outer join TB_FIN_CondPGTO d ");
            sql.AppendLine("on a.CD_CondPGTO = d.CD_CondPGTO ");

            sql.AppendLine("left outer join TB_DIV_TabelaPreco e ");
            sql.AppendLine("on a.CD_TabelaPreco = e.CD_TabelaPreco ");

            sql.AppendLine("left outer join TB_FAT_CFGPedido cfgped ");
            sql.AppendLine("on a.cfg_pedido = cfgped.cfg_pedido ");

            sql.AppendLine("left outer join tb_fin_clifor rep ");
            sql.AppendLine("on a.CD_Representante = rep.cd_clifor ");

            sql.AppendLine("left outer join tb_fin_clifor cInd ");
            sql.AppendLine("on a.cd_cliforind = cInd.cd_clifor ");

            sql.AppendLine("left outer join TB_FIN_Cidade cid ");
            sql.AppendLine("on a.Cd_cidadeent = cid.cd_cidade ");

            sql.AppendLine("left outer join TB_FIN_UF u ");
            sql.AppendLine("on cid.CD_UF = u.cd_uf ");

            sql.AppendLine("left outer join VTB_FIN_Clifor cent ");
            sql.AppendLine("on a.cd_cliforent = cent.cd_clifor ");

            sql.AppendLine("left outer join tb_fin_clifor cGer ");
            sql.AppendLine("on a.cd_gerente = cGer.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.NR_Orcamento ");
            return sql.ToString();
        }

        private string SqlCodeBuscaPosVenda(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" select orc.NR_Orcamento, orc.CD_Clifor, orc.NM_Clifor, orc.Fone_Clifor, orc.DT_Orcamento, ");
                sql.AppendLine(" ped.NR_Pedido,  ped.DT_Pedido, ");
                sql.AppendLine(" pedI.CD_Produto, pedI.ID_PedidoItem, pedI.Quantidade, pedI.VL_SubTotal,  prod.DS_Produto, ");
                sql.AppendLine(" nf.Nr_NotaFiscal, nf.DT_Emissao, ");
                sql.AppendLine(" ordem.ID_Ordem, ordem.DT_Carregamento, ");
                sql.AppendLine(" emp.NM_Empresa, emp.CD_Empresa, ");
                sql.AppendLine(" contato = (select top 1 cont.NM_Contato from TB_FIN_ContatoClifor cont ");
                sql.AppendLine(" 		   where orc.CD_Clifor = cont.CD_Clifor) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from TB_FAT_Orcamento orc ");
            sql.AppendLine(" inner join VTB_FAT_Pedido ped ");
            sql.AppendLine(" on orc.NR_Orcamento = ped.NR_Orcamento ");
            sql.AppendLine(" and orc.CD_Empresa = ped.CD_Empresa ");

            sql.AppendLine(" inner join TB_FAT_Pedido_Itens pedI ");
            sql.AppendLine(" on ped.NR_Pedido = pedI.NR_Pedido ");

            sql.AppendLine(" inner join TB_FAT_NotaFiscal nf ");
            sql.AppendLine(" on ped.NR_Pedido = nf.NR_Pedido ");
            sql.AppendLine(" and ped.CD_Empresa = nf.CD_Empresa ");

            sql.AppendLine(" inner join TB_EST_Produto prod ");
            sql.AppendLine(" on pedI.CD_Produto = prod.CD_Produto ");

            sql.AppendLine(" left join TB_FAT_Ordem_X_Expedicao expe ");
            sql.AppendLine(" on nf.NR_LanctoFiscal = expe.NR_LanctoFiscal ");
            sql.AppendLine(" and nf.CD_Empresa = expe.CD_Empresa ");

            sql.AppendLine(" left join TB_FAT_OrdemCarregamento ordem ");
            sql.AppendLine(" on ordem.ID_Ordem = expe.ID_Ordem ");

            sql.AppendLine(" inner join TB_DIV_Empresa emp ");
            sql.AppendLine(" on orc.CD_Empresa = emp.CD_Empresa ");
            sql.AppendLine(" and ordem.CD_Empresa = expe.CD_Empresa ");

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

        public TList_Orcamento Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento lista = new TList_Orcamento();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento reg = new TRegistro_Orcamento();
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_versao"))))
                        reg.NR_Versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomevendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nomevendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Representante")))
                        reg.Cd_representante = reader.GetString(reader.GetOrdinal("CD_Representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_representante")))
                        reg.Nm_representante = reader.GetString(reader.GetOrdinal("nm_representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforind")))
                        reg.Cd_cliforind = reader.GetString(reader.GetOrdinal("cd_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforind")))
                        reg.Nm_cliforind = reader.GetString(reader.GetOrdinal("nm_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_gerente")))
                        reg.Cd_gerente = reader.GetString(reader.GetOrdinal("cd_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_gerente")))
                        reg.Nm_gerente = reader.GetString(reader.GetOrdinal("nm_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Parcelas")))
                        reg.QTD_Parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ComEntrada")))
                        reg.St_cometrada = reader.GetString(reader.GetOrdinal("ST_ComEntrada")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_DiasDesdobro")))
                        reg.Parcelas_Dias_Desdobro = reader.GetDecimal(reader.GetOrdinal("QT_DiasDesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SolicitarDtVencto")))
                        reg.ST_SolicitarDtVencto = reader.GetString(reader.GetOrdinal("ST_SolicitarDtVencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_orcamento")))
                        reg.Dt_orcamento = reader.GetDateTime(reader.GetOrdinal("dt_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("dt_validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Juro_Fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("Vl_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_clifor")))
                        reg.Fone_clifor = reader.GetString(reader.GetOrdinal("fone_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacoes")))
                        reg.Ds_observacoes = reader.GetString(reader.GetOrdinal("ds_observacoes"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_impostosomar")))
                        reg.Vl_impostosomar = reader.GetDecimal(reader.GetOrdinal("vl_impostosomar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_impostosubtrair")))
                        reg.Vl_impostosubtrair = reader.GetDecimal(reader.GetOrdinal("vl_impostosubtrair"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_descarga"))))
                        reg.TP_descarga = reader.GetString(reader.GetOrdinal("tp_descarga"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_frete"))))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("prazoentrega")))
                        reg.PrazoEntrega = reader.GetDecimal(reader.GetOrdinal("prazoentrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedidovenda")))
                        reg.Nr_pedidovenda = reader.GetDecimal(reader.GetOrdinal("nr_pedidovenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforent")))
                        reg.Cd_cliforent = reader.GetString(reader.GetOrdinal("cd_cliforent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforent")))
                        reg.Nm_cliforent = reader.GetString(reader.GetOrdinal("nm_cliforent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpfent")))
                        reg.Cnpj_cpfent = reader.GetString(reader.GetOrdinal("cnpj_cpfent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_enderecoent")))
                        reg.Cd_enderecoent = reader.GetString(reader.GetOrdinal("cd_enderecoent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logradouroent")))
                        reg.Logradouroent = reader.GetString(reader.GetOrdinal("Logradouroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numeroent")))
                        reg.Numeroent = reader.GetString(reader.GetOrdinal("Numeroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complementoent")))
                        reg.Complementoent = reader.GetString(reader.GetOrdinal("Complementoent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairroent")))
                        reg.Bairroent = reader.GetString(reader.GetOrdinal("Bairroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cidadeent")))
                        reg.Cd_cidadeent = reader.GetString(reader.GetOrdinal("Cd_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_cidadeent")))
                        reg.Ds_cidadeent = reader.GetString(reader.GetOrdinal("Ds_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Uf_ent")))
                        reg.Uf_ent = reader.GetString(reader.GetOrdinal("Uf_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_UFEnt")))
                        reg.Cd_UFEnt = reader.GetString(reader.GetOrdinal("Cd_UFEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_os")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_venda")))
                        reg.Nr_venda = reader.GetDecimal(reader.GetOrdinal("nr_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginDesconto")))
                        reg.LoginDesconto = reader.GetString(reader.GetOrdinal("LoginDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_OrcProjeto")))
                        reg.St_orcprojeto = reader.GetString(reader.GetOrdinal("ST_OrcProjeto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_OrcPedido")))
                        reg.St_OrcPedido = reader.GetString(reader.GetOrdinal("St_OrcPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcorigem")))
                        reg.Nr_orcorigem = reader.GetString(reader.GetOrdinal("nr_orcorigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_totalitens")))
                        reg.Vl_totalitens = reader.GetDecimal(reader.GetOrdinal("vl_totalitens"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Faturado")))
                        reg.Vl_faturado = reader.GetDecimal(reader.GetOrdinal("Vl_Faturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ComRep")))
                        reg.Pc_comrep = reader.GetDecimal(reader.GetOrdinal("PC_ComRep"));

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

        public TList_OrcPosVenda SelectPosVenda(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_OrcPosVenda lista = new TList_OrcPosVenda();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaPosVenda(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrcPosVenda reg = new TRegistro_OrcPosVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("NR_Orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fone_Clifor"))))
                        reg.Fone_clifor = reader.GetString(reader.GetOrdinal("Fone_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Orcamento"))))
                        reg.Dt_orcamento = reader.GetDateTime(reader.GetOrdinal("DT_Orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Pedido"))))
                        reg.Dt_pedido = reader.GetDateTime(reader.GetOrdinal("DT_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem"))))
                        reg.ID_PedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_SubTotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("VL_SubTotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal"))))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ordem"))))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("ID_Ordem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Carregamento"))))
                        reg.Dt_carregamento = reader.GetDateTime(reader.GetOrdinal("DT_Carregamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("contato"))))
                        reg.Contato = reader.GetString(reader.GetOrdinal("contato"));


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

        public string Gravar(TRegistro_Orcamento val)
        {
            Hashtable hs = new Hashtable(38);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_VERSAO", val.NR_Versao);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_REPRESENTANTE", val.Cd_representante);
            hs.Add("@P_CD_CLIFORIND", val.Cd_cliforind);
            hs.Add("@P_CD_GERENTE", val.Cd_gerente);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_DT_ORCAMENTO", val.Dt_orcamento);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);
            hs.Add("@P_NM_CLIFOR", val.Nm_clifor);
            hs.Add("@P_FONE_CLIFOR", val.Fone_clifor);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_DS_CIDADE", val.Ds_cidade);
            hs.Add("@P_UF", val.Uf);
            hs.Add("@P_DS_OBSERVACOES", val.Ds_observacoes);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_VL_IMPOSTOSOMAR", val.Vl_impostosomar);
            hs.Add("@P_VL_IMPOSTOSUBTRAIR", val.Vl_impostosubtrair);
            hs.Add("@P_LOGINDESCONTO", val.LoginDesconto);
            hs.Add("@P_TP_DESCARGA", val.TP_descarga);
            hs.Add("@P_PRAZOENTREGA", val.PrazoEntrega);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_ST_ORCPROJETO", val.St_orcprojeto);
            hs.Add("@P_NR_ORCORIGEM", val.Nr_orcorigem);
            hs.Add("@P_CD_CLIFORENT", val.Cd_cliforent);
            hs.Add("@P_CD_ENDERECOENT", val.Cd_enderecoent);
            hs.Add("@P_CD_CIDADEENT", val.Cd_cidadeent);
            hs.Add("@P_LOGRADOUROENT", val.Logradouroent);
            hs.Add("@P_NUMEROENT", val.Numeroent);
            hs.Add("@P_COMPLEMENTOENT", val.Complementoent);
            hs.Add("@P_BAIRROENT", val.Bairroent);
            hs.Add("@P_PC_COMREP", val.Pc_comrep);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);

            return executarProc("IA_FAT_ORCAMENTO", hs);
        }

        public string Excluir(TRegistro_Orcamento val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);

            return executarProc("EXCLUI_FAT_ORCAMENTO", hs);
        }
    }
    #endregion

    #region Classe Itens Orcamento
    public class TList_Orcamento_Item : List<TRegistro_Orcamento_Item>, IComparer<TRegistro_Orcamento_Item>
    {
        #region IComparer<TRegistro_Orcamento_Item> Members
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

        public TList_Orcamento_Item()
        { }

        public TList_Orcamento_Item(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Orcamento_Item value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Orcamento_Item x, TRegistro_Orcamento_Item y)
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

    public class TRegistro_Orcamento_Item
    {
        public decimal? Nr_orcamento
        { get; set; }
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? Id_formulacao { get; set; } = null;
        public decimal? Id_item
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ds_condfiscal_produto
        { get; set; }
        public string Cd_unid_produto
        { get; set; }
        public string Ds_unid_produto
        { get; set; }
        public string Sigla_unid_produto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        private string st_servico;
        public string St_servico
        {
            get { return st_servico; }
            set
            {
                st_servico = value;
                st_servicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_servicobool;
        public bool St_servicobool
        {
            get { return st_servicobool; }
            set
            {
                st_servicobool = value;
                st_servico = value ? "S" : "N";
            }
        }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string NCM
        { get; set; }
        public string Cest
        { get; set; }
        public string Ds_Fichatec
        { get; set; }
        public string DS_TecnicaAssistencia
        { get; set; }
        public decimal PS_unitario
        { get; set; }
        public decimal Comprimento
        { get; set; }
        private decimal quantidade;
        public decimal Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                vl_subtotal = Math.Round(decimal.Multiply(quantidade, vl_unitario), 2, MidpointRounding.AwayFromZero);
                Vl_desconto = Math.Round(decimal.Divide(decimal.Multiply(Vl_subtotal, Pc_desconto), 100), 2, MidpointRounding.AwayFromZero);
                if (Vl_subtotal > 0)
                    Pc_desconto = Math.Round(decimal.Multiply(decimal.Divide(Vl_desconto, Vl_subtotal), 100), 5, MidpointRounding.AwayFromZero);
            }
        }
        public decimal Qtd_saldoestoque
        { get; set; }
        public bool St_semsaldoestoque
        { get { return quantidade > Qtd_saldoestoque; } }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set
            {
                vl_unitario = value;
                vl_subtotal = Math.Round(decimal.Multiply(quantidade, vl_unitario), 2, MidpointRounding.AwayFromZero);
                Vl_desconto = Math.Round(decimal.Divide(decimal.Multiply(Vl_subtotal, Pc_desconto), 100), 2, MidpointRounding.AwayFromZero);
                if (Vl_subtotal > 0)
                    Pc_desconto = Math.Round(decimal.Multiply(decimal.Divide(Vl_desconto, Vl_subtotal), 100), 5, MidpointRounding.AwayFromZero);
            }
        }
        public decimal Vl_tabela { get; set; } = decimal.Zero;
        public decimal PcDescUnit
        {
            get
            {
                if (Vl_tabela > decimal.Zero && vl_unitario > decimal.Zero)
                    return Math.Round(decimal.Subtract(100, decimal.Multiply(decimal.Divide(vl_unitario, Vl_tabela), 100)), 5, MidpointRounding.AwayFromZero);
                else return decimal.Zero;
            }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return vl_subtotal; }
            set
            {
                vl_subtotal = value;
                Vl_desconto = Math.Round(decimal.Divide(decimal.Multiply(Vl_subtotal, Pc_desconto), 100), 2, MidpointRounding.AwayFromZero);
                if (Vl_subtotal > 0)
                    Pc_desconto = Math.Round(decimal.Multiply(decimal.Divide(Vl_desconto, Vl_subtotal), 100), 5, MidpointRounding.AwayFromZero);
            }
        }
        private decimal pc_desconto;
        public decimal Pc_desconto
        {
            get { return Math.Round(pc_desconto, 5); }
            set
            {
                pc_desconto = value;
                vl_desconto = Math.Round(decimal.Divide(decimal.Multiply(vl_subtotal, pc_desconto), 100), 2, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get { return Math.Round(vl_desconto, 2); }
            set
            {
                vl_desconto = value;
                if (vl_subtotal > 0)
                    pc_desconto = Math.Round(decimal.Multiply(decimal.Divide(vl_desconto, vl_subtotal), 100), 5, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_acrescimo;
        public decimal Vl_acrescimo
        {
            get { return Math.Round(vl_acrescimo, 2, MidpointRounding.AwayFromZero); }
            set { vl_acrescimo = value; }
        }
        private decimal pc_acrescimo;
        public decimal Pc_acrescimo
        {
            get { return Math.Round(pc_acrescimo, 5); }
            set
            {
                pc_acrescimo = value;
                vl_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(vl_subtotal, pc_acrescimo), 100), 2, MidpointRounding.AwayFromZero);
            }
        }
        private decimal vl_frete;
        public decimal Vl_frete
        {
            get { return Math.Round(vl_frete, 2, MidpointRounding.AwayFromZero); }
            set { vl_frete = value; }
        }
        public decimal Vl_juro_fin
        { get; set; }
        public decimal Vl_subtotalliq => Vl_subtotal + vl_acrescimo + Vl_juro_fin - Vl_desconto + (St_somarFrete ? Vl_frete : decimal.Zero);
        public decimal Vl_unitarioLiquido => Vl_subtotalliq > decimal.Zero && quantidade > decimal.Zero ? Math.Round(decimal.Divide(Vl_subtotalliq, quantidade), 2) : vl_unitario;
        public string Ds_observacao
        { get; set; }
        private decimal vl_custo;
        public decimal Vl_custo
        {
            get { return Math.Round(vl_custo, 2, MidpointRounding.AwayFromZero); }
            set { vl_custo = Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        public decimal Vl_custototal => Math.Round(decimal.Multiply(quantidade, vl_custo), 2, MidpointRounding.AwayFromZero);
        public decimal Vl_ultimacompra
        { get; set; }
        public decimal Qtd_faturada
        { get; set; }
        public decimal Sd_faturar
        { get { return quantidade - Qtd_faturada; } }
        public decimal Qtd_faturar
        { get; set; }
        public decimal Vl_faturado
        { get; set; }
        public decimal Vl_faturar => Math.Round(decimal.Subtract(Vl_subtotalliq, Vl_faturado), 2, MidpointRounding.AwayFromZero);
        public bool St_faturar
        { get; set; }
        public bool St_somarFrete
        { get; set; }
        public TList_FichaTecOrcItem lFichaTec
        { get; set; }
        public TList_FichaTecOrcItem lFichaTecDel
        { get; set; }
        public TList_RegLanPedido_Item lItensFat
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
        public decimal Pc_comrep
        { get; set; }
        public decimal Vl_comrep
        {
            get
            {
                if ((this.Vl_subtotal + this.vl_acrescimo - this.vl_desconto) > decimal.Zero)
                    return Math.Round(decimal.Divide(decimal.Multiply((this.Vl_subtotal + this.vl_acrescimo - this.vl_desconto), this.Pc_comrep), 100), 2, MidpointRounding.AwayFromZero);
                else return decimal.Zero;
            }
        }
        public string St_TanqueAereo
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public decimal? Cd_marca
        { get; set; }
        public string Ds_marca
        { get; set; }
        public decimal Pc_icms
        { get; set; }
        public decimal Pc_icms_ST
        { get; set; }
        public decimal Pc_pis
        { get; set; }
        public decimal Pc_cofins
        { get; set; }
        public decimal Pc_ipi
        { get; set; }
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
        public string Ds_projespecial
        { get; set; }
        public bool Cancelado { get; set; } = false;
        public bool St_processar
        { get; set; }

        public decimal vl_comprimento { get; set; }

        public decimal vl_altura { get; set; }

        public decimal vl_largura { get; set; }
        public string Logincusto { get; set; } = string.Empty;
        public string Ds_motabaixocusto { get; set; } = string.Empty;
        public string LoginDesc { get; set; } = string.Empty;
        public bool St_abaixocusto => (quantidade > decimal.Zero ? decimal.Divide(Vl_subtotalliq, quantidade) : decimal.Zero) < vl_custo;
        public TList_AnexoItemOrc lAnexo { get; set; } = new TList_AnexoItemOrc();
        public TList_AnexoItemOrc lAnexoDel { get; set; } = new TList_AnexoItemOrc();

        public TRegistro_Orcamento_Item()
        {
            Nr_orcamento = null;
            Id_item = null;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ds_condfiscal_produto = string.Empty;
            Cd_unid_produto = string.Empty;
            Ds_unid_produto = string.Empty;
            Sigla_unid_produto = string.Empty;
            Cd_grupo = string.Empty;
            st_servico = "N";
            st_servicobool = false;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            NCM = string.Empty;
            Cest = string.Empty;
            Ds_Fichatec = string.Empty;
            DS_TecnicaAssistencia = string.Empty;
            PS_unitario = decimal.Zero;
            Comprimento = decimal.Zero;
            quantidade = decimal.Zero;
            Qtd_faturada = decimal.Zero;
            Qtd_faturar = decimal.Zero;
            Qtd_saldoestoque = decimal.Zero;
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            pc_desconto = decimal.Zero;
            vl_desconto = decimal.Zero;
            pc_acrescimo = decimal.Zero;
            vl_acrescimo = decimal.Zero;
            vl_frete = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
            Vl_custo = decimal.Zero;
            Vl_ultimacompra = decimal.Zero;
            Vl_faturado = decimal.Zero;
            Ds_observacao = string.Empty;
            St_faturar = false;
            St_somarFrete = false;
            lFichaTec = new TList_FichaTecOrcItem();
            lFichaTecDel = new TList_FichaTecOrcItem();
            lItensFat = new TList_RegLanPedido_Item();
            imagem = null;
            img = null;
            Pc_comrep = decimal.Zero;
            Cd_referencia = string.Empty;
            St_TanqueAereo = string.Empty;
            Cd_marca = null;
            Ds_marca = string.Empty;
            Pc_icms = decimal.Zero;
            Pc_icms_ST = decimal.Zero;
            Pc_pis = decimal.Zero;
            Pc_cofins = decimal.Zero;
            Pc_ipi = decimal.Zero;
            st_projespecial = "N";
            st_projespecialbool = false;
            Ds_projespecial = string.Empty;
            St_processar = false;
            vl_comprimento = decimal.Zero;
            vl_altura = decimal.Zero;
            vl_largura = decimal.Zero;
        }
    }

    public class TCD_Orcamento_Item : TDataQuery
    {
        public TCD_Orcamento_Item()
        { }

        public TCD_Orcamento_Item(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Cd_empresa, a.NR_Orcamento, a.ID_Item, a.ST_SomarFrete, a.Cd_empresa, ");
                sql.AppendLine("a.CD_Produto, isnull(b.DS_Produto, a.ds_produto) as ds_produto, b.DS_TecnicaAssistencia, ");
                sql.AppendLine("b.CD_Unidade as cd_unid_produto, b.cd_grupo, a.st_servico, a.ds_fichatec, a.LoginDesc, ");
                sql.AppendLine("c.DS_Unidade as ds_unid_produto, a.QTD_Faturada, a.Vl_Faturado, ncm.cest, a.id_formulacao, ");
                sql.AppendLine("b.PS_unitario, b.ncm, b.Codigo_Alternativo, b.cd_marca, f.ds_marca, ");
                sql.AppendLine("isnull(c.Sigla_Unidade, a.sg_unidorcamento) as sigla_unid_produto, ");
                sql.AppendLine("a.Quantidade, a.Vl_Unitario, a.Vl_SubTotal, a.Vl_juro_fin, b.ST_TanqueAereo, ");
                sql.AppendLine("a.Vl_Desconto, a.Vl_Acrescimo, a.Vl_Frete, a.ds_observacao, ");
                sql.AppendLine("b.cd_condfiscal_produto, d.ds_condfiscal_produto, a.vl_tabela, ");
                sql.AppendLine("a.cd_local, e.ds_local, a.qtd_saldo, a.vl_custo, a.vl_ueps, a.PC_ComRep, ");
                sql.AppendLine("imagem = (select top 1 x.imagem ");
                sql.AppendLine("            from TB_EST_PRODUTO_Imagens x ");
                sql.AppendLine("            where x.cd_produto = b.cd_produto ");
                sql.AppendLine("            order by x.id_imagem asc), ");
                sql.AppendLine("a.largura, a.comprimento, a.altura, a.ST_ProjEspecial, a.DS_ProjEspecial, ");
                sql.AppendLine("a.LoginCusto, a.Ds_MotAbaixoCusto, a.Cancelado ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_Orcamento_Item a ");
            sql.AppendLine("left outer join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("left outer join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("left outer join tb_fis_condfiscal_produto d ");
            sql.AppendLine("on b.cd_condfiscal_produto = d.cd_condfiscal_produto ");
            sql.AppendLine("left outer join TB_EST_LocalArm e ");
            sql.AppendLine("on a.cd_local = e.cd_local ");
            sql.AppendLine("left outer join TB_EST_Marca f ");
            sql.AppendLine("on b.cd_marca = f.cd_marca ");
            sql.AppendLine("left outer join TB_FIS_NCM ncm ");
            sql.AppendLine("on b.ncm = ncm.ncm ");

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

        public TList_Orcamento_Item Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento_Item lista = new TList_Orcamento_Item();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento_Item reg = new TRegistro_Orcamento_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("cd_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unid_produto")))
                        reg.Ds_unid_produto = reader.GetString(reader.GetOrdinal("ds_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unid_produto")))
                        reg.Sigla_unid_produto = reader.GetString(reader.GetOrdinal("sigla_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.NCM = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TecnicaAssistencia")))
                        reg.DS_TecnicaAssistencia = reader.GetString(reader.GetOrdinal("DS_TecnicaAssistencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_TanqueAereo")))
                        reg.St_TanqueAereo = reader.GetString(reader.GetOrdinal("St_TanqueAereo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_fichatec"))))
                        reg.Ds_Fichatec = reader.GetString(reader.GetOrdinal("ds_fichatec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("st_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_unitario")))
                        reg.PS_unitario = reader.GetDecimal(reader.GetOrdinal("PS_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Comprimento")))
                        reg.Comprimento = reader.GetDecimal(reader.GetOrdinal("Comprimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("vl_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condfiscal_produto")))
                        reg.Ds_condfiscal_produto = reader.GetString(reader.GetOrdinal("ds_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_marca")))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("cd_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_saldo")))
                        reg.Qtd_saldoestoque = reader.GetDecimal(reader.GetOrdinal("qtd_saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("vl_custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ueps")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("vl_ueps"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Faturada")))
                        reg.Qtd_faturada = reader.GetDecimal(reader.GetOrdinal("QTD_Faturada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Faturado")))
                        reg.Vl_faturado = reader.GetDecimal(reader.GetOrdinal("Vl_Faturado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SomarFrete")))
                        reg.St_somarFrete = reader.GetString(reader.GetOrdinal("ST_SomarFrete")).ToString().Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("comprimento")))
                        reg.vl_comprimento = reader.GetDecimal(reader.GetOrdinal("comprimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("altura")))
                        reg.vl_altura = reader.GetDecimal(reader.GetOrdinal("altura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("largura")))
                        reg.vl_largura = reader.GetDecimal(reader.GetOrdinal("largura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ComRep")))
                        reg.Pc_comrep = reader.GetDecimal(reader.GetOrdinal("PC_ComRep"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_ProjEspecial"))))
                        reg.St_projespecial = reader.GetString(reader.GetOrdinal("ST_ProjEspecial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ProjEspecial")))
                        reg.Ds_projespecial = reader.GetString(reader.GetOrdinal("DS_ProjEspecial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCusto")))
                        reg.Logincusto = reader.GetString(reader.GetOrdinal("LoginCusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_MotAbaixoCusto")))
                        reg.Ds_motabaixocusto = reader.GetString(reader.GetOrdinal("Ds_MotAbaixoCusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_tabela")))
                        reg.Vl_tabela = reader.GetDecimal(reader.GetOrdinal("vl_tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginDesc")))
                        reg.LoginDesc = reader.GetString(reader.GetOrdinal("LoginDesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("Cancelado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("id_formulacao"));

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

        public string Gravar(TRegistro_Orcamento_Item val)
        {
            Hashtable hs = new Hashtable(31);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DS_PRODUTO", val.Ds_produto);
            hs.Add("@P_SG_UNIDORCAMENTO", val.Sigla_unid_produto);
            hs.Add("@P_ST_SERVICO", val.St_servico);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_ACRESCIMO", val.Vl_acrescimo);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_VL_JURO_FIN", val.Vl_juro_fin);
            hs.Add("@P_DS_FICHATEC", val.Ds_Fichatec);
            hs.Add("@P_VL_CUSTO", val.St_projespecialbool ? decimal.Zero : val.Vl_custo);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ALTURA", val.vl_altura);
            hs.Add("@P_COMPRIMENTO", val.vl_comprimento);
            hs.Add("@P_LARGURA", val.vl_largura);
            hs.Add("@P_PC_COMREP", val.Pc_comrep);
            hs.Add("@P_ST_PROJESPECIAL", val.St_projespecial);
            hs.Add("@P_DS_PROJESPECIAL", val.Ds_projespecial);
            hs.Add("@P_LOGINCUSTO", val.Logincusto);
            hs.Add("@P_DS_MOTABAIXOCUSTO", val.Ds_motabaixocusto);
            hs.Add("@P_VL_TABELA", val.Vl_tabela);
            hs.Add("@P_LOGINDESC", val.LoginDesc);
            hs.Add("@P_CANCELADO", val.Cancelado);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);

            return executarProc("IA_FAT_ORCAMENTO_ITEM", hs);
        }

        public string Excluir(TRegistro_Orcamento_Item val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_FAT_ORCAMENTO_ITEM", hs);
        }
    }
    #endregion

    #region Anexo Item Orcamento
    public class TList_AnexoItemOrc : List<TRegistro_AnexoItemOrc> { }
    public class TRegistro_AnexoItemOrc
    {
        private decimal? nr_orcamento = null;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr = string.Empty;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = decimal.Parse(value);
                }
                catch { nr_orcamento = null; }
            }
        }
        private decimal? id_item = null;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr = string.Empty;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch { id_item = null; }
            }
        }
        private decimal? id_anexo = null;
        public decimal? Id_anexo
        {
            get { return id_anexo; }
            set
            {
                id_anexo = value;
                id_anexostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_anexostr = string.Empty;
        public string Id_anexostr
        {
            get { return id_anexostr; }
            set
            {
                id_anexostr = value;
                try
                {
                    id_anexo = decimal.Parse(value);
                }
                catch { id_anexo = null; }
            }
        }
        public string Ds_anexo { get; set; } = string.Empty;
        public byte[] Anexo { get; set; } = null;
        public string Ext_anexo { get; set; } = string.Empty;
    }
    public class TCD_AnexoItemOrc : TDataQuery
    {
        public TCD_AnexoItemOrc() { }

        public TCD_AnexoItemOrc(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.Nr_Orcamento, a.Id_Item, a.Id_Anexo, a.Ds_Anexo, a.Anexo, a.Ext_Anexo ");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FAT_AnexoItemOrc a");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_AnexoItemOrc Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_AnexoItemOrc lista = new TList_AnexoItemOrc();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AnexoItemOrc reg = new TRegistro_AnexoItemOrc();

                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("NR_Orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Anexo")))
                        reg.Id_anexo = reader.GetDecimal(reader.GetOrdinal("ID_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Anexo")))
                        reg.Ds_anexo = reader.GetString(reader.GetOrdinal("DS_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ext_Anexo")))
                        reg.Ext_anexo = reader.GetString(reader.GetOrdinal("Ext_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Anexo")))
                        reg.Anexo = (byte[])reader.GetValue(reader.GetOrdinal("Anexo"));
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

        public string Gravar(TRegistro_AnexoItemOrc val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);
            hs.Add("@P_DS_ANEXO", val.Ds_anexo);
            hs.Add("@P_EXT_ANEXO", val.Ext_anexo);
            hs.Add("@P_ANEXO", val.Anexo);

            return executarProc("IA_FAT_ANEXOITEMORC", hs);
        }

        public string Excluir(TRegistro_AnexoItemOrc val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);

            return executarProc("EXCLUI_FAT_ANEXOITEMORC", hs);
        }
    }
    #endregion

    #region Classe Ficha Tecnica Item Orcamento
    public class TList_FichaTecOrcItem : List<TRegistro_FichaTecOrcItem>
    { }

    public class TRegistro_FichaTecOrcItem
    {
        public decimal? Nr_orcamento
        { get; set; }
        public decimal? Id_item
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
        public string Cd_alternativo
        { get; set; }
        public decimal Cd_marca
        { get; set; }
        public string Ds_marca
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
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
        public decimal Vl_ultimacompra
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_Subtotal
        { get { return Quantidade * Vl_unitario; } }
        public decimal SaldoEstoque
        { get; set; }

        public TRegistro_FichaTecOrcItem()
        {
            Nr_orcamento = null;
            Id_item = null;
            Id_ficha = null;
            Cd_item = string.Empty;
            Ds_item = string.Empty;
            Ncm = string.Empty;
            Cest = string.Empty;
            Cd_alternativo = string.Empty;
            Cd_marca = decimal.Zero;
            Ds_marca = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_unditem = string.Empty;
            Ds_unditem = string.Empty;
            Sg_unditem = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_custo = decimal.Zero;
            Vl_ultimacompra = decimal.Zero;
            SaldoEstoque = decimal.Zero;
        }
    }

    public class TCD_FichaTecOrcItem : TDataQuery
    {
        public TCD_FichaTecOrcItem()
        { }

        public TCD_FichaTecOrcItem(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_Item, a.Id_ficha, b.Codigo_Alternativo as cd_alternativo, ");
                sql.AppendLine("b.CD_Marca, d.DS_Marca, a.cd_local, e.ds_local, a.CD_Item, isnull(a.ds_item, b.ds_produto) as ds_item, a.Quantidade, ");
                sql.AppendLine("b.CD_Unidade as cd_unditem, b.ncm, nc.cest, ");
                sql.AppendLine("c.DS_Unidade as ds_unditem, ");
                sql.AppendLine("c.Sigla_Unidade as sg_unditem, a.Vl_venda, ");
                sql.AppendLine("Vl_custo = case when a.CD_Item is not null then dbo.F_CUSTO_MEDIOESTOQUE(orc.cd_empresa, a.CD_Item, null) else a.Vl_venda end * a.Quantidade, ");
                sql.AppendLine("Vl_ultimacompra = dbo.F_FAT_ULTIMACOMPRA(orc.cd_empresa, a.CD_Item) * a.Quantidade, ");
                sql.AppendLine("SaldoEstoque = ISNULL((SELECT Sum(isnull(QTD_Entrada,0)) - sum(isnull(QTD_Saida,0)) ");
                sql.AppendLine("                       FROM TB_EST_ESTOQUE x ");
                sql.AppendLine("                       WHERE ISNULL(x.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("                       AND x.CD_EMPRESA = orc.cd_empresa ");
                sql.AppendLine("                       AND x.CD_LOCAL = a.CD_LOCAL ");
                sql.AppendLine("                       AND x.CD_PRODUTO = a.CD_Item),0 ) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_FichaTecOrcItem a ");
            sql.AppendLine("inner join TB_FAT_Orcamento orc ");
            sql.AppendLine("on orc.nr_orcamento = a.nr_orcamento ");
            sql.AppendLine("left join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Item = b.CD_Produto ");
            sql.AppendLine("left join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("left outer join TB_EST_Marca d ");
            sql.AppendLine("on b.CD_Marca = d.CD_Marca ");
            sql.AppendLine("left outer join TB_FIS_NCM nc ");
            sql.AppendLine("on b.ncm = nc.ncm ");
            sql.AppendLine("left outer join TB_EST_LocalArm e ");
            sql.AppendLine("on e.cd_local = a.cd_local ");

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

        public TList_FichaTecOrcItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FichaTecOrcItem lista = new TList_FichaTecOrcItem();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaTecOrcItem reg = new TRegistro_FichaTecOrcItem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_ficha"))))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("Id_ficha"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_item"))))
                        reg.Cd_item = reader.GetString(reader.GetOrdinal("cd_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cest")))
                        reg.Cest = reader.GetString(reader.GetOrdinal("cest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_alternativo")))
                        reg.Cd_alternativo = reader.GetString(reader.GetOrdinal("cd_alternativo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_marca"))))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("cd_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("Cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("Ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unditem")))
                        reg.Cd_unditem = reader.GetString(reader.GetOrdinal("cd_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unditem")))
                        reg.Ds_unditem = reader.GetString(reader.GetOrdinal("ds_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_unditem")))
                        reg.Sg_unditem = reader.GetString(reader.GetOrdinal("sg_unditem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("Vl_custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ultimacompra")))
                        reg.Vl_ultimacompra = reader.GetDecimal(reader.GetOrdinal("Vl_ultimacompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_venda")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoEstoque")))
                        reg.SaldoEstoque = reader.GetDecimal(reader.GetOrdinal("SaldoEstoque"));

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

        public string Gravar(TRegistro_FichaTecOrcItem val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_CD_ITEM", val.Cd_item);
            hs.Add("@P_DS_ITEM", val.Ds_item);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_VENDA", val.Vl_unitario);

            return executarProc("IA_FAT_FICHATECORCITEM", hs);
        }

        public string Excluir(TRegistro_FichaTecOrcItem val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_FICHA", val.Id_ficha);

            return executarProc("EXCLUI_FAT_FICHATECORCITEM", hs);
        }
    }
    #endregion

    #region Classe Financeiro Orcamento
    public class TList_Orcamento_DT_Vencto : List<TRegistro_Orcamento_DT_Vencto>
    { }

    public class TRegistro_Orcamento_DT_Vencto
    {
        public decimal? Nr_orcamento
        { get; set; }
        private decimal? id_vencto;
        public decimal? Id_vencto
        {
            get { return id_vencto; }
            set
            {
                id_vencto = value;
                id_venctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_venctostr;
        public string Id_venctostr
        {
            get { return id_venctostr; }
            set
            {
                id_venctostr = value;
                try
                {
                    id_vencto = decimal.Parse(value);
                }
                catch { id_vencto = null; }
            }
        }
        public decimal DiasVencto
        { get; set; }
        public decimal Vl_parcela
        { get; set; }
        public decimal Vl_entrada
        { get; set; }
        public DateTime Dt_pedido { get; set; } = DateTime.Now;
        public DateTime Dt_vencto
        { get { return Dt_pedido.AddDays(Convert.ToDouble(DiasVencto)); } }

        public TRegistro_Orcamento_DT_Vencto()
        {
            Nr_orcamento = null;
            id_vencto = null;
            id_venctostr = string.Empty;
            DiasVencto = decimal.Zero;
            Vl_parcela = decimal.Zero;
            Vl_entrada = decimal.Zero;
        }
    }

    public class TCD_Orcamento_DT_Vencto : TDataQuery
    {
        public TCD_Orcamento_DT_Vencto()
        { }

        public TCD_Orcamento_DT_Vencto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_Vencto, a.diasvencto, a.vl_parcela, ");
                sql.AppendLine("dt_pedido = (select top 1 y.dt_pedido ");
                sql.AppendLine("            from tb_fat_pedido_itens x ");
                sql.AppendLine("            inner join tb_fat_pedido y ");
                sql.AppendLine("            on x.nr_pedido = y.nr_pedido ");
                sql.AppendLine("            where x.nr_orcamento = a.nr_orcamento ");
                sql.AppendLine("            and isnull(x.st_registro, 'A') <> 'C' ");
                sql.AppendLine("            and isnull(y.st_registro, 'A') <> 'C')");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Orcamento_DT_Vencto a ");

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

        public TList_Orcamento_DT_Vencto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento_DT_Vencto lista = new TList_Orcamento_DT_Vencto();
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento_DT_Vencto reg = new TRegistro_Orcamento_DT_Vencto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vencto")))
                        reg.Id_vencto = reader.GetDecimal(reader.GetOrdinal("id_vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("diasvencto"))))
                        reg.DiasVencto = reader.GetDecimal(reader.GetOrdinal("diasvencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_parcela"))))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("vl_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_pedido")))
                        reg.Dt_pedido = reader.GetDateTime(reader.GetOrdinal("dt_pedido"));

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

        public string Gravar(TRegistro_Orcamento_DT_Vencto val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_VENCTO", val.Id_vencto);
            hs.Add("@P_DIASVENCTO", val.DiasVencto);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);

            return executarProc("IA_FAT_ORCAMENTO_DT_VENCTO", hs);
        }

        public string Excluir(TRegistro_Orcamento_DT_Vencto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_VENCTO", val.Id_vencto);

            return executarProc("EXCLUI_FAT_ORCAMENTO_DT_VENCTO", hs);
        }
    }
    #endregion

    #region Orcamento X OS
    public class TList_Orcamento_X_OS : List<TRegistro_Orcamento_X_OS>
    { }


    public class TRegistro_Orcamento_X_OS
    {
        private decimal? nr_orcamento;

        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr;

        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = decimal.Parse(value);
                }
                catch
                { nr_orcamento = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
            }
        }
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
        private decimal? id_peca;

        public decimal? Id_peca
        {
            get { return id_peca; }
            set
            {
                id_peca = value;
                id_pecastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pecastr;

        public string Id_pecastr
        {
            get { return id_pecastr; }
            set
            {
                id_pecastr = value;
                try
                {
                    id_peca = decimal.Parse(value);
                }
                catch
                { id_peca = null; }
            }
        }

        public TRegistro_Orcamento_X_OS()
        {
            nr_orcamento = null;
            nr_orcamentostr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Cd_empresa = string.Empty;
            id_os = null;
            id_osstr = string.Empty;
            id_peca = null;
            id_pecastr = string.Empty;
        }
    }

    public class TCD_Orcamento_X_OS : TDataQuery
    {
        public TCD_Orcamento_X_OS() { }

        public TCD_Orcamento_X_OS(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_Item, a.ID_OS, a.CD_Empresa, a.ID_Peca ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Orcamento_X_OS a ");

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

        public TList_Orcamento_X_OS Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Orcamento_X_OS lista = new TList_Orcamento_X_OS();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Orcamento_X_OS reg = new TRegistro_Orcamento_X_OS();
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_orcamento"))))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_os"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("id_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("id_peca"));

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

        public string Gravar(TRegistro_Orcamento_X_OS val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);

            return executarProc("IA_FAT_ORCAMENTO_X_OS", hs);
        }

        public string Excluir(TRegistro_Orcamento_X_OS val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);

            return executarProc("EXCLUI_FAT_ORCAMENTO_X_OS", hs);
        }
    }
    #endregion

    #region Itens Compra Projeto
    public class TList_ItensCompraOrcProj : List<TRegistro_ItensCompraOrcProj>, IComparer<TRegistro_ItensCompraOrcProj>
    {
        #region IComparer<TRegistro_ItensCompraOrcProj> Members
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

        public TList_ItensCompraOrcProj()
        { }

        public TList_ItensCompraOrcProj(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensCompraOrcProj value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensCompraOrcProj x, TRegistro_ItensCompraOrcProj y)
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
    public class TRegistro_ItensCompraOrcProj
    {
        private decimal? nr_orcamento;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private string nr_orcamentostr;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = decimal.Parse(value);
                }
                catch { nr_orcamento = null; }
            }
        }

        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Cd_unidade { get; set; }
        public string Ds_unidade { get; set; }
        public string Sigla_unidade { get; set; }
        private DateTime? dt_compra;

        public DateTime? Dt_compra
        {
            get { return dt_compra; }
            set
            {
                dt_compra = value;
                dt_comprastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_comprastr;

        public string Dt_comprastr
        {
            get { return dt_comprastr; }
            set
            {
                dt_comprastr = value;
                try
                {
                    dt_compra = DateTime.Parse(value);
                }
                catch { dt_compra = null; }
            }
        }

        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
    public class TCD_ItensCompraOrcProj : TDataQuery
    {
        public TCD_ItensCompraOrcProj() { }
        public TCD_ItensCompraOrcProj(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.CD_Produto, ");
                sql.AppendLine("b.DS_Produto, b.CD_Unidade, c.DS_Unidade, c.Sigla_Unidade, ");
                sql.AppendLine("a.DT_Compra, a.Quantidade, a.Valor ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ItensCompraOrcProj a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");

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
        public TList_ItensCompraOrcProj Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ItensCompraOrcProj lista = new TList_ItensCompraOrcProj();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensCompraOrcProj reg = new TRegistro_ItensCompraOrcProj();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("DT_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("valor"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_ItensCompraOrcProj val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DT_COMPRA", val.Dt_compra);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VALOR", val.Valor);
            return executarProc("IA_FAT_ITENSCOMPRAORCPROJ", hs);
        }
        public string Excluir(TRegistro_ItensCompraOrcProj val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            return executarProc("EXCLUI_FAT_ITENSCOMPRAORCPROJ", hs);
        }
    }
    #endregion
    
    #region Troca Cliente
    public class TList_TrocaCliente : List<TRegistro_TrocaCliente>, IComparer<TRegistro_TrocaCliente>
    {
        #region IComparer<TRegistro_TrocaCliente> Members
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

        public TList_TrocaCliente()
        { }

        public TList_TrocaCliente(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TrocaCliente value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TrocaCliente x, TRegistro_TrocaCliente y)
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

    public class TRegistro_TrocaCliente
    {
        public decimal? Nr_orcamento { get; set; } = null;
        public decimal? Id_troca { get; set; } = null;
        public decimal? Nr_pedidoorigem { get; set; } = null;
        public decimal? Nr_pedidotroca { get; set; } = null;
        public string Login { get; set; } = string.Empty;
        public string MotivoTroca { get; set; } = string.Empty;
        public DateTime? Dt_troca { get; set; } = null;
        public TList_Troca_X_Mov Troca_X_Mov { get; set; } = new TList_Troca_X_Mov();
    }

    public class TCD_TrocaCliente: TDataQuery
    {
        public TCD_TrocaCliente() { }
        public TCD_TrocaCliente(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_Troca, ");
                sql.AppendLine("a.NR_PedidoOrigem, a.NR_PedidoTroca, a.Login, a.MotivoTroca, a.DT_Cad ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_TrocaCliente a ");

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
        public TList_TrocaCliente Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocaCliente lista = new TList_TrocaCliente();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocaCliente reg = new TRegistro_TrocaCliente();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_troca")))
                        reg.Id_troca = reader.GetDecimal(reader.GetOrdinal("id_troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedidoorigem")))
                        reg.Nr_pedidoorigem = reader.GetDecimal(reader.GetOrdinal("nr_pedidoorigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedidotroca")))
                        reg.Nr_pedidotroca = reader.GetDecimal(reader.GetOrdinal("nr_pedidotroca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoTroca")))
                        reg.MotivoTroca = reader.GetString(reader.GetOrdinal("MotivoTroca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cad")))
                        reg.Dt_troca = reader.GetDateTime(reader.GetOrdinal("DT_Cad"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_TrocaCliente val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_NR_PEDIDOORIGEM", val.Nr_pedidoorigem);
            hs.Add("@P_NR_PEDIDOTROCA", val.Nr_pedidotroca);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_MOTIVOTROCA", val.MotivoTroca);
            return executarProc("IA_FAT_TROCACLIENTE", hs);
        }
        public string Excluir(TRegistro_TrocaCliente val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            return executarProc("EXCLUI_FAT_TROCACLIENTE", hs);
        }
    }
    #endregion
    
    #region Troca X Liquidacao
    public class TList_Troca_X_Mov : List<TRegistro_Troca_X_Mov> { }

    public class TRegistro_Troca_X_Mov
    {
        public decimal? Nr_orcamento { get; set; } = null;
        public decimal? Id_troca { get; set; } = null;
        public decimal? Id_mov { get; set; } = null;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? Nr_lancto { get; set; } = null;
        public decimal? Cd_parcela { get; set; } = null;
        public decimal? Id_liquid { get; set; } = null;
    }

    public class TCD_Troca_X_Mov:TDataQuery
    {
        public TCD_Troca_X_Mov() { }
        public TCD_Troca_X_Mov(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_Troca, a.ID_Mov, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_liquid ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Troca_x_mov a ");

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
        public TList_Troca_X_Mov Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Troca_X_Mov lista = new TList_Troca_X_Mov();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Troca_X_Mov reg = new TRegistro_Troca_X_Mov();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_troca")))
                        reg.Id_troca = reader.GetDecimal(reader.GetOrdinal("id_troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_mov")))
                        reg.Id_mov = reader.GetDecimal(reader.GetOrdinal("id_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("cd_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("id_liquid"));
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_Troca_X_Mov val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            return executarProc("IA_FAT_TROCA_X_MOV", hs);
        }
        public string Excluir(TRegistro_Troca_X_Mov val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_ID_MOV", val.Id_mov);
            return executarProc("EXCLUI_FAT_TROCA_X_MOV", hs);
        }
    }
    #endregion

    #region Trocar Item Proposta
    public class TList_TrocaItemProposta : List<TRegistro_TrocaItemProposta> { }
    public class TRegistro_TrocaItemProposta
    {
        public decimal? Nr_orcamento { get; set; } = null;
        public decimal? Id_itemOrig { get; set; } = null;
        public decimal? Id_itemDest { get; set; } = null;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? Nr_lancto { get; set; } = null;
        public decimal? Id_adto { get; set; } = null;
        public string Login { get; set; } = string.Empty;
        public string MotivoTroca { get; set; } = string.Empty;
        public TRegistro_Orcamento_Item ItemOrig { get; set; } = null;
        public TRegistro_Orcamento_Item ItemDest { get; set; } = null;
        public Financeiro.Duplicata.TRegistro_LanDuplicata rDup { get; set; } = null;
        public TList_Troca_X_Liquid lTrocaLiquid { get; set; } = new TList_Troca_X_Liquid();
    }
    public class TCD_TrocaItemProposta:TDataQuery
    {
        public TCD_TrocaItemProposta() { }
        public TCD_TrocaItemProposta(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_ItemOrig, a.ID_ItemDest, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, a.id_adto, a.Login, a.MotivoTroca ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_TrocaItemProposta a ");

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
        public TList_TrocaItemProposta Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocaItemProposta lista = new TList_TrocaItemProposta();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocaItemProposta reg = new TRegistro_TrocaItemProposta();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemorig")))
                        reg.Id_itemOrig = reader.GetDecimal(reader.GetOrdinal("id_itemorig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemdest")))
                        reg.Id_itemDest = reader.GetDecimal(reader.GetOrdinal("id_itemdest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoTroca")))
                        reg.MotivoTroca = reader.GetString(reader.GetOrdinal("MotivoTroca"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_TrocaItemProposta val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEMORIG", val.Id_itemOrig);
            hs.Add("@P_ID_ITEMDEST", val.Id_itemDest);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_MOTIVOTROCA", val.MotivoTroca);
            return executarProc("IA_FAT_TROCAITEMPROPOSTA", hs);
        }
        public string Excluir(TRegistro_TrocaItemProposta val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEMORIG", val.Id_itemOrig);
            hs.Add("@P_ID_ITEMDEST", val.Id_itemDest);
            return executarProc("EXCLUI_FAT_TROCAITEMPROPOSTA", hs);
        }
    }
    #endregion

    #region Troca X Liquid
    public class TList_Troca_X_Liquid : List<TRegistro_Troca_X_Liquid> { }
    public class TRegistro_Troca_X_Liquid
    {
        public decimal? Nr_orcamento { get; set; } = null;
        public decimal? Id_itemorig { get; set; } = null;
        public decimal? Id_itemdest { get; set; } = null;
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? Nr_lancto { get; set; } = null;
        public decimal? Cd_parcela { get; set; } = null;
        public decimal? Id_liquid { get; set; } = null;
    }
    public class TCD_Troca_X_Liquid:TDataQuery
    {
        public TCD_Troca_X_Liquid() { }
        public TCD_Troca_X_Liquid(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_Orcamento, a.ID_ItemOrig, a.ID_ItemDest, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_liquid ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Troca_X_Liquid a ");

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
        public TList_Troca_X_Liquid Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Troca_X_Liquid lista = new TList_Troca_X_Liquid();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Troca_X_Liquid reg = new TRegistro_Troca_X_Liquid();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemorig")))
                        reg.Id_itemorig = reader.GetDecimal(reader.GetOrdinal("id_itemorig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemdest")))
                        reg.Id_itemdest = reader.GetDecimal(reader.GetOrdinal("id_itemdest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("cd_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("id_liquid"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_Troca_X_Liquid val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEMORIG", val.Id_itemorig);
            hs.Add("@P_ID_ITEMDEST", val.Id_itemdest);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            return executarProc("IA_FAT_TROCA_X_LIQUID", hs);
        }
        public string Excluir(TRegistro_Troca_X_Liquid val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_ID_ITEMORIG", val.Id_itemorig);
            hs.Add("@P_ID_ITEMDEST", val.Id_itemdest);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            return executarProc("EXCLUI_FAT_TROCA_X_LIQUID", hs);
        }
    }
    #endregion
}
