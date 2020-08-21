using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Faturamento.Cadastros;


namespace CamadaDados.Faturamento.Pedido
{
    #region Pedido
    public class TList_Pedido : List<TRegistro_Pedido>, IComparer<TRegistro_Pedido>
    {
        #region IComparer<TRegistro_Pedido> Members
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

        public TList_Pedido()
        { }

        public TList_Pedido(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Pedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Pedido x, TRegistro_Pedido y)
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
    
    public class TRegistro_Pedido
    {
        public decimal Nr_pedido
        { get; set; }
        public decimal Nr_Orcamento
        { get; set; }
        public decimal NR_SeqPedido
        { get; set; }
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Sigla
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string DS_tabelapreco
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nomevendedor
        { get; set; }
        public string Cd_representante
        { get; set; }
        public string Nm_representante
        { get; set; }
        public decimal Pc_comrep { get; set; }
        public string Cd_gerente { get; set; }
        public string Nm_gerente { get; set; }
        public string Cd_cliforind
        { get; set; }
        public string Nm_cliforind
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Pc_descgeral
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
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
                Pedido_Itens.ForEach(p =>
                    {
                        p.Tp_Movimento = tp_movimento;
                        p.Tp_frete = tp_frete;
                    });
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
                Pedido_Itens.ForEach(p =>
                    {
                        p.Tp_Movimento = tp_movimento;
                        p.Tp_frete = tp_frete;
                    });
            }
        }
        public decimal Vl_descontogeral
        { get; set; }
        public decimal Vl_acrescimogeral
        { get; set; }
        public decimal Vl_cotacao
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                status = value.Trim().ToUpper().Equals("A");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value)
                    st_registro = "A";
                else
                    st_registro = "C";
            }
        }
        private string _statusMagento;

        public string StatusMagento
        {
            get
            {
                if (_statusMagento.Trim().ToUpper().Equals("CLOSED"))
                    return "FECHADO";
                else if (_statusMagento.Trim().ToUpper().Equals("PROCESSING"))
                    return "PROCESSANDO";
                else if (_statusMagento.Trim().ToUpper().Equals("PENDING_PAYMENT"))
                    return "PAGAMENTO PENDENTE";
                else if (_statusMagento.Trim().ToUpper().Equals("PAYMENT_REVIEW"))
                    return "ANALISE DE PAGAMENTO";
                else if (_statusMagento.Trim().ToUpper().Equals("FRAUD"))
                    return "SUSPEITA DE FRAUDE";
                else if (_statusMagento.Trim().ToUpper().Equals("PENDING"))
                    return "PENDENTE";
                else if (_statusMagento.Trim().ToUpper().Equals("HOLDED"))
                    return "SEGURADO";
                else if (_statusMagento.Trim().ToUpper().Equals("COMPLETE"))
                    return "COMPLETO";
                else if (_statusMagento.Trim().ToUpper().Equals("CANCELED"))
                    return "CANCELADO";
                else if (_statusMagento.Trim().ToUpper().Equals("PAYPAL_CANCELED_REVERSAL"))
                    return "REVERSÃO CANCELADA DO PAYPAL";
                else if (_statusMagento.Trim().ToUpper().Equals("PENDING_PAYPAL"))
                    return "PAYPAL PENDENTE";
                else if (_statusMagento.Trim().ToUpper().Equals("PAYPAL_REVERSED"))
                    return "REVERSÃO DO PAYPAL";
                else return _statusMagento;
            }
            set { _statusMagento = value; }
        }

        public string CD_TRANSPORTADORA { get; set; }
        public string NM_TRANSPORTADORA { get; set; }
        public string NR_CCG_CPF_TRANSP { get; set; }
        public string CD_ENDERECOTRANSP { get; set; }
        public string DS_ENDERECOTRANSP { get; set; }
        public string NumeroTransp { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public decimal QUANTIDADENF { get; set; }
        public decimal PesoLiquido { get; set; }
        public string ESPECIENF { get; set; }
        public string MARCANF { get; set; }
        public string NUMERONF { get; set; }
        public string Placaveiculo { get; set; }
        public string Cd_municipioexecservico
        { get; set; }
        public string Ds_municipioexecservico
        { get; set; }
        public string Logindesconto
        { get; set; }
        public string Nr_PedidoOrigem
        {
            get;
            set;
        }
        public string cd_empresa;
        public string CD_Empresa
        {
            get { return cd_empresa.Trim(); }
            set { cd_empresa = value; }
        }
        public string Nm_Empresa
        {
            get;
            set;
        }
        public string Uf_empresa
        { get; set; }
        public string Cd_uf_empresa
        { get; set; }
        public string Cd_cidade_emp
        { get; set; }
        public string Ds_cidade_emp
        { get; set; }
        public string CFG_Pedido
        {
            get;
            set;
        }
        public string DS_CFG_Pedido
        {
            get;
            set;
        }
        public string CD_Clifor
        {
            get;
            set;
        }
        public string NM_Clifor
        {
            get;
            set;
        }
        public string Tp_pessoa
        { get; set; }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Nm_fantasia
        { get; set; }
        public string CD_Endereco
        {
            get;
            set;
        }
        public string DS_Endereco
        {
            get;
            set;
        }
        public string CD_Cidade
        {
            get;
            set;
        }
        public string DS_Cidade
        {
            get;
            set;
        }
        public string UF_Cliente
        {
            get;
            set;
        }
        public string Cd_uf_cliente
        { get; set; }
        public string CD_CondPGTO
        {
            get;
            set;
        }
        public string DS_CondPgto
        {
            get;
            set;
        }
        public decimal QTD_Parcelas
        {
            get;
            set;
        }
        public string Parcelas_Entrada
        {
            get;
            set;
        }
        public decimal Parcelas_Dias_Desdobro
        {
            get;
            set;
        }
        public string Parcelas_Feriado
        {
            get;
            set;
        }
        public string ST_SolicitarDtVencto
        {
            get;
            set;
        }
        private string tp_movimento;
        public string TP_Movimento
        {
            get { return tp_movimento; }
            set { tp_movimento = value;
                    if (value.Trim() == "E")
                    {
                        tp_movimento_extendido = "ENTRADA";
                        Comprador_Vendedor = "Comprador:";
                    }
                    else
                    {
                        if (value.Trim() == "S")
                        {
                            tp_movimento_extendido = "SAÍDA";
                            Comprador_Vendedor = "Vendedor:";
                        }
                    }
                    Pedido_Itens.ForEach(p =>
                    {
                        p.Tp_Movimento = tp_movimento;
                        p.Tp_frete = tp_frete;
                    });
            }
        }
        private string tp_movimento_extendido;
        public string TP_Movimento_Extendido
        {
            get { return tp_movimento_extendido; }
            set 
            { 
                tp_movimento_extendido = value;
                if (value.Trim() == "ENTRADA")
                {
                    tp_movimento = "E";
                    Comprador_Vendedor = "Comprador";
                }
                else if (value.Trim() == "SAÍDA")
                {
                    tp_movimento = "S";
                    Comprador_Vendedor = "Vendedor";
                }
                Pedido_Itens.ForEach(p =>
                {
                    p.Tp_Movimento = tp_movimento;
                    p.Tp_frete = tp_frete;
                });
            }
        }
        public string Comprador_Vendedor
        { get; set; }
        public string DS_Observacao
        {
            get;
            set;
        }
        private DateTime? dt_pedido;
        public DateTime? DT_Pedido
        {
            get { return dt_pedido; }
            set 
            { 
                dt_pedido = value;
                dt_pedido_string = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_pedido_string;
        public string DT_Pedido_String
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_pedido_string).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_pedido_string = value;
                try
                {
                    DT_Pedido = DateTime.Parse(value);
                }
                catch
                { DT_Pedido = null; }
            }
        }
        private DateTime? dt_entregapedido;
        public DateTime? Dt_entregapedido
        {
            get { return dt_entregapedido; }
            set
            {
                dt_entregapedido = value;
                dt_entregapedidostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_entregapedidostr;
        public string Dt_entregapedidostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_entregapedidostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_entregapedidostr = value;
                try
                {
                    dt_entregapedido = Convert.ToDateTime(value);
                }
                catch
                { dt_entregapedido = null; }
            }
        }
        
        public string Cd_clifor_comprador
        { get; set; }
        public string Nm_clifor_comprador
        { get; set; }
        public decimal Vl_totalpedido
        { get; set; }
        public decimal Vl_totalfat_entrada
        { get; set; }
        public decimal Vl_totalfat_saida
        { get; set; }
        public decimal Vl_saldopedido
        {
            get
            {
                if (TP_Movimento.Trim().ToUpper().Equals("E"))
                    return Vl_totalpedido - Vl_totalfat_entrada + Vl_totalfat_saida;
                else if (TP_Movimento.Trim().ToUpper().Equals("S"))
                    return Vl_totalpedido - Vl_totalfat_saida + Vl_totalfat_entrada;
                else
                    return decimal.Zero;
            }
        }
        public decimal Vl_entrada
        { get; set; }
        public TRegistro_CadEmpresa DadosEmpresa
        {
            get;
            set;
        }
        private string st_pedido;
        public string ST_Pedido
        {
            get { return st_pedido; }
            set
            {
                st_pedido = value;
                if (value.Trim().ToUpper().Equals("C"))
                    status_pedido = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("A"))
                    status_pedido = "ABERTO";
                else if (value.Trim().ToUpper().Equals("F"))
                    if (dt_entregapedido.HasValue ? dt_entregapedido.Value < DateTime.Now : false)
                        status_pedido = "EXPIRADO";
                    else if (Vl_saldopedido > 0 && this.Vl_saldopedido < Vl_totalpedido)
                        status_pedido = "PARCIAL";
                    else
                        status_pedido = "FECHADO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status_pedido = "ENCERRADO";
            }
        }
        private string status_pedido;
        public string Status_Pedido
        {
            get { return status_pedido; }
            set
            {
                status_pedido = value;
                if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_pedido = "C";
                else if (value.Trim().ToUpper().Equals("FECHADO") ||
                    value.Trim().ToUpper().Equals("EXPIRADO") ||
                    value.Trim().ToUpper().Equals("PARCIAL"))
                    st_pedido = "F";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_pedido = "P";
            }
        }
        public string ST_Registro
        {
            get;
            set;
        }
        public TRegistro_CadClifor Clifor { get; set; }
        public TRegistro_CadEndereco Endereco { get; set; }
        public TList_RegLanPedido_GRO Pedido_GRO
        {
            get;
            set;
        }
        public TList_RegLanPedido_Item Pedido_Itens
        { get; set; }
        public Entrega.TList_ItensRomaneio lRomaneio
        { get; set; }
        public TList_Pedido_DT_Vencto Pedidos_DT_Vencto
        {
            get;
            set;
        }
        public TList_RegLanPedido_Item Deleta_Pedido_Itens
        {
            get;
            set;
        }
        public TList_Pedido_DT_Vencto Deleta_Pedidos_DT_Vencto
        {
            get;
            set;
        }
        public TList_CadCFGPedidoFiscal Pedido_Fiscal
        { get; set; }
        public TList_CadContrato List_CadContrato { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdiant
        { get; set; }
        public bool St_bloq_debitovencido
        { get; set; }
        private decimal limite_credito;
        public decimal Limite_Credito
        {
            get { return limite_credito; }
            set
            {
                limite_credito = value;
                Saldo_Credito = limite_credito - credito_uso;
            }
        }
        private decimal credito_uso;
        public decimal Credito_Uso
        {
            get { return credito_uso; }
            set
            {
                credito_uso = value;
                Saldo_Credito = limite_credito - credito_uso;
            }
        }
        public decimal Saldo_Credito
        {
            get;
            set;
        }
        public decimal Debito_Vencidos
        {
            get;
            set;
        }
        private decimal adto_valor;
        public decimal ADTO_Valor
        {
            get { return adto_valor; }
            set 
            { 
                adto_valor = value;
                ADTO_A_Devolver = adto_valor - adto_devolvido;
            }
        }
        private decimal adto_devolvido;
        public decimal ADTO_Devolvido
        {
            get { return adto_devolvido; }
            set
            { 
                adto_devolvido = value;
                ADTO_A_Devolver = adto_valor - adto_devolvido;
            }
        }
        public decimal ADTO_A_Devolver
        {
            get;
            set;
        }
        public decimal VL_Total_Faturado_Entrada
        {
            get;
            set;
        }
        public decimal VL_Total_Faturado_Saida
        {
            get;
            set;
        }
        private string st_valoresfixos;
        public string St_valoresfixos
        {
            get { return st_valoresfixos; }
            set
            {
                st_valoresfixos = value;
                st_valoresfixosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_valoresfixosbool;
        public bool St_valoresfixosbool
        {
            get { return st_valoresfixosbool; }
            set
            {
                st_valoresfixosbool = value;
                if (value)
                    st_valoresfixos = "S";
                else
                    st_valoresfixos = "N";
            }
        }
        private string st_Commoditties;
        public string St_Commoditties
        {
            get { return st_Commoditties; }
            set
            {
                st_Commoditties = value;
                st_Commodittiesbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_Commodittiesbool;
        public bool St_Commodittiesbool
        {
            get { return st_Commodittiesbool; }
            set
            {
                st_Commodittiesbool = value;
                if (value)
                    st_Commoditties = "S";
                else
                    st_Commoditties = "N";
            }
        }
        private string st_comissaoped;
        public string St_comissaoped
        {
            get { return st_comissaoped; }
            set
            {
                st_comissaoped = value;
                st_comissaopedbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comissaopedbool;
        public bool St_comissaopedbool
        {
            get { return st_comissaopedbool; }
            set
            {
                st_comissaopedbool = value;
                st_comissaoped = value ? "S" : "N";
            }
        }
        private string st_comissaofat;
        public string St_comissaofat
        {
            get { return st_comissaofat; }
            set
            {
                st_comissaofat = value;
                st_comissaofatbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comissaofatbool;
        public bool St_comissaofatbool
        {
            get { return st_comissaofatbool; }
            set
            {
                st_comissaofatbool = value;
                st_comissaofat = value ? "S" : "N";
            }
        }
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
        private string st_deposito;
        public string St_deposito
        {
            get { return st_deposito; }
            set
            {
                st_deposito = value;
                st_depositobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_depositobool;
        public bool St_depositobool
        {
            get { return st_depositobool; }
            set
            {
                st_depositobool = value;
                st_deposito = value ? "S" : "N";
            }
        }
        public bool St_integraralmox
        { get; set; }
        public decimal Vl_totalsubst { get; set; } = decimal.Zero;
        public decimal Vl_totalipi { get; set; } = decimal.Zero;
        public decimal Vl_totalpedido_liquido
        {
            get
            {
                if(Pedido_Itens != null)
                    return Parametros.pubTruncarSubTotal ?
                        Estruturas.Truncar(Pedido_Itens.Sum(p => p.Vl_subtotal + 
                            ((tp_movimento.Trim().ToUpper().Equals("S") && Tp_frete.ToString().Equals("0")) ||
                             (tp_movimento.Trim().ToUpper().Equals("E") && tp_frete.ToString().Equals("1"))? p.Vl_freteitem : decimal.Zero) + p.Vl_juro_fin + p.Vl_acrescimo + p.Vl_subst + p.Vl_IPI - p.Vl_desc), 2) :
                        Math.Round(Pedido_Itens.Sum(p => p.Vl_subtotal + 
                            ((tp_movimento.Trim().ToUpper().Equals("S") && Tp_frete.ToString().Equals("0")) ||
                             (tp_movimento.Trim().ToUpper().Equals("E") && tp_frete.ToString().Equals("1"))? p.Vl_freteitem : decimal.Zero) + p.Vl_juro_fin + p.Vl_acrescimo + p.Vl_subst + p.Vl_IPI - p.Vl_desc), 2);
                else
                    return decimal.Zero;
            }
        }
        public decimal Vl_totalItens
        {
            get { return Pedido_Itens.Sum(p => p.Vl_subtotal); }
        }
        //Configuracao para calculo do valor do pedido com juros financeiros
        public string Cd_juro_fin
        { get; set; }
        public string Ds_juro_fin
        { get; set; }
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        public decimal Qt_diasdesdobro
        { get; set; }
        public string Tp_juro
        { get; set; }
        public bool St_cometrada
        { get; set; }
        public string Tp_pedido
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
        public string Cd_cliforent
        { get; set; }
        public string Nm_cliforent
        { get; set; }
        public string Cd_condfiscalent
        { get; set; }
        public string Tp_pessoaent
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
        public string Cd_uf_ent
        { get; set; }
        public string dsCancelmento { get; set; }
        public string LoginCancelamento { get; set; }
        public TList_EntregaPedido lEntregaPedido
        { get; set; }
        public Fiscal.TList_ResumoImposto lImpostoPedido
        { get; set; }
        public Servicos.TList_LanServico lOsIntegra
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanDuplicata lDupDel    
        { get; set; }
        public NotaFiscal.TList_RegLanFaturamento lNotaFiscal
        { get; set; }
        public Financeiro.Duplicata.TList_RegLanParcela lParc
        { get; set; }
        public TList_EtapaPedido lEtapa
        { get; set; }
        public TList_Expedicao lExpedicao
        { get; set; }
        public TList_OrdemCarregamento lOrdem
        { get; set; }
        public TList_AcessoriosPed lAcessorios
        { get; set; }
        public TList_AcessoriosPed lAcessoriosDel
        { get; set; }
        public string nr_cgc_cpf { get; set; }
        public string uf { get; set; }
        public byte[] Anexo_compra { get; set; } = null;
        public decimal Tot_subst { get; set; } = decimal.Zero;
        public decimal Tot_ipi { get; set; } = decimal.Zero;
        public decimal Id_CategoriaCliFor { get; set; }
        public string DS_CategoriaClifor { get; set; }

        public TRegistro_Pedido()
        {
            Nr_Orcamento = decimal.Zero;
            uf = string.Empty;
            nr_cgc_cpf = string.Empty;
            dsCancelmento = string.Empty;
            LoginCancelamento = string.Empty;
            Nr_pedido = decimal.Zero;
            NR_SeqPedido = decimal.Zero;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Cd_tabelapreco = string.Empty;
            DS_tabelapreco = string.Empty;
            Cd_vendedor = string.Empty;
            Nomevendedor = string.Empty;
            Cd_representante = string.Empty;
            Nm_representante = string.Empty;
            Pc_comrep = decimal.Zero;
            Cd_gerente = string.Empty;
            Nm_gerente = string.Empty;
            Cd_cliforind = string.Empty;
            Nm_cliforind = string.Empty;
            Cd_condfiscalent = string.Empty;
            Tp_pessoaent = string.Empty;
            Vl_frete = decimal.Zero;
            Pc_descgeral = decimal.Zero;
            Vl_comissao = decimal.Zero;
            tp_frete = "9";
            tipo_frete = "SEM FRETE";
            Vl_descontogeral = decimal.Zero;
            Vl_acrescimogeral = decimal.Zero;
            Vl_cotacao = decimal.Zero;
            st_registro = "A";
            _statusMagento = string.Empty;
            status = true;
            CD_TRANSPORTADORA = string.Empty;
            NM_TRANSPORTADORA = string.Empty;
            NR_CCG_CPF_TRANSP = string.Empty;
            CD_ENDERECOTRANSP = string.Empty;
            DS_ENDERECOTRANSP = string.Empty;
            NumeroTransp = string.Empty;
            CIDADE = string.Empty;
            UF = string.Empty;
            PesoLiquido = decimal.Zero;
            QUANTIDADENF = decimal.Zero;
            ESPECIENF = string.Empty;
            MARCANF = string.Empty;
            NUMERONF = string.Empty;
            Placaveiculo = string.Empty;
            Cd_municipioexecservico = string.Empty;
            Ds_municipioexecservico = string.Empty;
            Logindesconto = string.Empty;
            adto_devolvido = decimal.Zero;
            adto_valor = decimal.Zero;
            Comprador_Vendedor = "Comprador:";
            credito_uso = decimal.Zero;
            dt_pedido = DateTime.Now.Date;
            dt_pedido_string = DateTime.Now.Date.ToString("dd/MM/yyyy");
            dt_entregapedido = null;
            dt_entregapedidostr = string.Empty;
            limite_credito = decimal.Zero;
            st_pedido = "F";
            status_pedido = "FECHADO";
            tp_movimento = "E";
            tp_movimento_extendido = "ENTRADA";
            CD_Clifor = string.Empty;
            Cd_clifor_comprador = string.Empty;
            CD_CondPGTO = string.Empty;
            cd_empresa = string.Empty;
            Uf_empresa = string.Empty;
            Cd_uf_empresa = string.Empty;
            Cd_cidade_emp = string.Empty;
            Ds_cidade_emp = string.Empty;
            CD_Endereco = string.Empty;
            CFG_Pedido = string.Empty;
            Clifor = new TRegistro_CadClifor();
            Comprador_Vendedor = string.Empty;
            Credito_Uso = decimal.Zero;
            DadosEmpresa = new TRegistro_CadEmpresa();
            Debito_Vencidos = decimal.Zero;
            Deleta_Pedido_Itens = new TList_RegLanPedido_Item();
            Deleta_Pedidos_DT_Vencto = new TList_Pedido_DT_Vencto();
            DS_CFG_Pedido = string.Empty;
            CD_Cidade = string.Empty;
            DS_Cidade = string.Empty;
            DS_CondPgto = string.Empty;
            DS_Endereco = string.Empty;
            DS_Observacao = string.Empty;
            Endereco = new TRegistro_CadEndereco();
            Limite_Credito = decimal.Zero;
            NM_Clifor = string.Empty;
            Tp_pessoa = string.Empty;
            Cd_condfiscal_clifor = string.Empty;
            Nm_fantasia = string.Empty;
            Nm_clifor_comprador = string.Empty;
            Nm_Empresa = string.Empty;
            Nr_PedidoOrigem = string.Empty;
            Parcelas_Dias_Desdobro = decimal.Zero;
            Parcelas_Entrada = string.Empty;
            Parcelas_Feriado = string.Empty;
            Pedido_GRO = new TList_RegLanPedido_GRO();
            Pedido_Itens = new TList_RegLanPedido_Item();
            lRomaneio = new CamadaDados.Faturamento.Entrega.TList_ItensRomaneio();
            Pedidos_DT_Vencto = new TList_Pedido_DT_Vencto();
            Pedido_Fiscal = new TList_CadCFGPedidoFiscal();
            QTD_Parcelas = decimal.Zero;
            Saldo_Credito = decimal.Zero;
            st_Commoditties = "N";
            st_Commodittiesbool = false;
            st_servico = "N";
            st_servicobool = false;
            ST_Registro = "A";
            ST_SolicitarDtVencto = string.Empty;
            st_valoresfixos = "N";
            st_valoresfixosbool = false;
            UF_Cliente = string.Empty;
            Cd_uf_cliente = string.Empty;
            VL_Total_Faturado_Entrada = decimal.Zero;
            VL_Total_Faturado_Saida = decimal.Zero;
            Vl_totalfat_entrada = decimal.Zero;
            Vl_totalfat_saida = decimal.Zero;
            Vl_totalpedido = decimal.Zero;
            Cd_juro_fin = string.Empty;
            Ds_juro_fin = string.Empty;
            Pc_jurodiario_atrazo = decimal.Zero;
            Qt_diasdesdobro = decimal.Zero;
            Vl_entrada = decimal.Zero;
            Tp_juro = string.Empty;
            St_cometrada = false;
            List_CadContrato = new TList_CadContrato();
            lAdiant = new Financeiro.Adiantamento.TList_LanAdiantamento();
            Clifor = new TRegistro_CadClifor();
            Endereco = new TRegistro_CadEndereco();
            St_bloq_debitovencido = false;
            st_valoresfixos = "N";
            st_valoresfixosbool = false;
            st_comissaoped = "N";
            st_comissaopedbool = false;
            st_comissaofat = "N";
            st_comissaofatbool = false;
            st_deposito = "N";
            st_depositobool = false;
            St_integraralmox = false;
            Tp_pedido = string.Empty;
            tp_descarga = string.Empty;
            tipo_descarga = string.Empty;
            Cd_cliforent = string.Empty;
            Nm_cliforent = string.Empty;
            Cnpj_cpfent = string.Empty;
            Cd_enderecoent = string.Empty;
            Logradouroent = string.Empty;
            Numeroent = string.Empty;
            Complementoent = string.Empty;
            Bairroent = string.Empty;
            Cd_cidadeent = string.Empty;
            Ds_cidadeent = string.Empty;
            Uf_ent = string.Empty;
            Cd_uf_ent = string.Empty;
            lEntregaPedido = new TList_EntregaPedido();
            lOsIntegra = new CamadaDados.Servicos.TList_LanServico();
            lImpostoPedido = new CamadaDados.Fiscal.TList_ResumoImposto();
            lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            lDupDel = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            lNotaFiscal = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            lParc = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
            lEtapa = new TList_EtapaPedido();
            lExpedicao = new TList_Expedicao();
            lOrdem = new TList_OrdemCarregamento();
            lAcessorios = new TList_AcessoriosPed();
            lAcessoriosDel = new TList_AcessoriosPed();
        }
    }

    public class TCD_Pedido : TDataQuery
    {
        public TCD_Pedido()
        { }

        public TCD_Pedido(TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public TCD_Pedido(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "a.Nr_Pedido, a.Nr_orcamento, a.NR_SeqPedido, a.Nr_PedidoOrigem, a.CD_Empresa, b.Nm_Empresa, ");
                sql.AppendLine("a.CFG_Pedido, c.ds_TipoPedido, c.TP_Movimento as TP_Movimento_CFG, a.cd_cliforind, cInd.nm_clifor as nm_cliforind, ");
                sql.AppendLine("a.CD_Clifor, d.nm_clifor, d.nm_fantasia, endClifor.Insc_Estadual, c.st_integraralmox, a.pc_comrep, a.cd_gerente, cGer.nm_clifor as nm_gerente, ");
                sql.AppendLine("a.CD_Endereco, endClifor.ds_endereco, vend.nm_clifor as NomeVendedor, a.cd_vendedor, a.cd_representante, rep.nm_clifor as nm_representante, ");
                sql.AppendLine("endClifor.cd_cidade, endClifor.ds_cidade, a.dt_entregapedido, a.vl_comissao, a.logindesconto, ");
                sql.AppendLine("endClifor.uf as UF_Cliente, endclifor.cd_uf as cd_uf_cliente, a.tp_descarga, a.Anexo_Compra, ");
                //Dados Condicao de Pagamento
                sql.AppendLine(" a.CD_CondPGTO, h.ds_CondPGTO, h.QT_Parcelas, h.ST_ComEntrada, h.QT_DiasDesdobro, h.ST_VenctoEmFeriado, h.ST_SolicitarDtVencto, ");
                //Dados Juro Financeiro
                sql.AppendLine("h.cd_juro_fin, jurofin.ds_juro as ds_juro_fin, jurofin.pc_jurodiario_atrazo, jurofin.tp_juro, ");
                sql.AppendLine("a.TP_Movimento, a.DS_Observacao, d.cd_condfiscal_clifor, ");
                sql.AppendLine("a.DT_Pedido, a.ST_Pedido, a.ST_Registro, endEmpresa.uf as UF_Empresa, d.tp_pessoa, ");
                sql.AppendLine("endEmpresa.cd_cidade as cd_cidade_emp, endEmpresa.ds_cidade as ds_cidade_emp, ");
                sql.AppendLine("d.nr_cgc, d.nr_cpf, d.ST_Equiparado_PJ, d.ST_Agropecuaria, endEmpresa.cd_uf as cd_uf_empresa, ");
                sql.AppendLine("case when d.tp_pessoa = 'J' then d.nr_cgc else d.nr_cpf end as nr_cgc_cpf, ");
                sql.AppendLine("a.tp_frete, a.vl_totalpedido, a.vl_totalfat_entrada, a.vl_totalfat_saida, ");
                sql.AppendLine("a.cd_clifor_comprador, comp.nm_clifor as nm_clifor_comprador, c.st_deposito, ");
                sql.AppendLine("a.cd_transportadora, transp.nm_clifor as nm_transportadora, c.st_servico, ");
                sql.AppendLine("isnull(transp.nr_cgc, transp.nr_cpf) as nr_cgc_cpf_transp, c.st_valoresfixos, c.st_commoditties, ");
                sql.AppendLine("a.cd_enderecotransp, endTransp.ds_endereco as ds_enderecotransp, endTransp.Numero as NumeroTransp, endTransp.Ds_cidade as Ds_cidadeTransp, endTransp.uf as ufTransp, c.ST_ComissaoPed, c.ST_ComissaoFat, ");
                sql.AppendLine("a.numeronf, a.marcanf, a.especienf, isnull(a.quantidadenf, 0) as quantidadenf, a.placaveiculo, ");
                sql.AppendLine("a.cd_moeda, moeda.ds_moeda_singular, moeda.sigla, a.cd_tabelapreco, tabpreco.ds_tabelapreco, ");
                sql.AppendLine("a.vl_frete, a.tp_frete, a.vl_desconto, a.vl_cotacao, a.quantidadenf, a.especienf, a.marcanf, a.numeronf, a.vl_acrescimo, ");
                sql.AppendLine("a.cd_municipioexecservico, cid.ds_cidade as ds_municipioexecservico, ");
                sql.AppendLine("a.cd_cliforent, cent.nm_clifor as nm_cliforent, case when cent.tp_pessoa = 'J' then cent.nr_cgc else cent.nr_cpf end as cnpj_cpfent, ");
                sql.AppendLine("cent.tp_pessoa as tp_pessoaent, cent.ST_Equiparado_PJ as ST_Equiparado_PJent, cent.ST_Agropecuaria as ST_EquiparadoPFent, ");
                sql.AppendLine("cent.Cd_CondFiscal_Clifor as Cd_CondFiscal_Cliforent, a.cd_enderecoent, a.logradouroent, a.numeroent, a.complementoent, a.bairroent, ");
                sql.AppendLine("a.cd_cidadeent, cident.ds_cidade as ds_cidadeent, ufent.uf as uf_ent, ufent.Cd_uf as cd_uf_ent, eEnt.Insc_Estadual as Insc_Estadualent, ");
                sql.AppendLine("Tot_subst = isnull((select sum(isnull(x.vl_subst, 0)) from tb_fat_pedido_itens x where x.nr_pedido = a.nr_pedido), 0), ");
                sql.AppendLine("Tot_IPI = isnull((select sum(isnull(x.vl_ipi, 0)) from tb_fat_pedido_itens x where x.nr_pedido = a.nr_pedido), 0), " +
                    "d.Id_CategoriaCliFor, d.DS_CategoriaClifor ");
            }
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM VTB_FAT_PEDIDO a ");
            sql.AppendLine("left outer join tb_Div_Empresa b ");
            sql.AppendLine("on b.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join vtb_fin_endereco endEmpresa ");
            sql.AppendLine("on b.cd_clifor = endEmpresa.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = endEmpresa.cd_endereco ");

            sql.AppendLine("left outer join TB_FAT_CFGPedido c ");
            sql.AppendLine("on c.CFG_Pedido = a.CFG_Pedido ");
            sql.AppendLine("left outer join vtb_fin_clifor d ");
            sql.AppendLine("on d.cd_clifor = a.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco endClifor ");
            sql.AppendLine("on a.cd_clifor = endClifor.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = endClifor.cd_endereco ");
            sql.AppendLine("left outer join TB_fin_CondPGTO h ");
            sql.AppendLine("on h.cd_condpgto = a.cd_condpgto ");
            sql.AppendLine("left outer join tb_fin_juro jurofin ");
            sql.AppendLine("on h.cd_juro_fin = jurofin.cd_juro ");
            sql.AppendLine("left outer join vtb_fin_clifor comp ");
            sql.AppendLine("on a.cd_clifor_comprador = comp.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_clifor transp ");
            sql.AppendLine("on a.cd_transportadora = transp.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco endTransp ");
            sql.AppendLine("on a.cd_transportadora = endTransp.cd_clifor ");
            sql.AppendLine("and a.cd_enderecotransp = endTransp.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_clifor vend ");
            sql.AppendLine("on a.cd_vendedor = vend.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor rep ");
            sql.AppendLine("on a.cd_representante = rep.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_moeda moeda ");
            sql.AppendLine("on a.cd_moeda = moeda.cd_moeda ");
            sql.AppendLine("left outer join tb_div_tabelapreco tabpreco ");
            sql.AppendLine("on a.cd_tabelapreco = tabpreco.cd_tabelapreco ");
            sql.AppendLine("left outer join TB_FIN_Cidade cid ");
            sql.AppendLine("on a.cd_municipioexecservico = cid.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_Cidade cident ");
            sql.AppendLine("on a.cd_cidadeent = cident.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF ufent ");
            sql.AppendLine("on cident.cd_uf = ufent.cd_uf ");
            sql.AppendLine("left outer join TB_FIN_Clifor cInd ");
            sql.AppendLine("on a.cd_cliforind = cInd.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Clifor cent ");
            sql.AppendLine("on a.cd_cliforent = cent.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_Endereco eEnt ");
            sql.AppendLine("on a.cd_cliforent = eEnt.cd_clifor ");
            sql.AppendLine("and a.cd_enderecoent = eEnt.cd_endereco ");
            sql.AppendLine("left outer join TB_FIN_Clifor cGer ");
            sql.AppendLine("on a.cd_gerente = cGer.cd_clifor ");
            
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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pedido Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Pedido lista = new TList_Pedido();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Pedido reg = new TRegistro_Pedido();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_SeqPedido")))
                        reg.NR_SeqPedido = reader.GetDecimal(reader.GetOrdinal("NR_SeqPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_PedidoOrigem")))
                        reg.Nr_PedidoOrigem = reader.GetString(reader.GetOrdinal("NR_PedidoOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Empresa")))
                        reg.Uf_empresa = reader.GetString(reader.GetOrdinal("UF_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF_Empresa")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("CD_UF_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_emp")))
                        reg.Cd_cidade_emp = reader.GetString(reader.GetOrdinal("cd_cidade_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_emp")))
                        reg.Ds_cidade_emp = reader.GetString(reader.GetOrdinal("ds_cidade_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.CFG_Pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.DS_CFG_Pedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fantasia")))
                        reg.Nm_fantasia = reader.GetString(reader.GetOrdinal("NM_Fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.CD_Endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.DS_Endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade")))
                        reg.CD_Cidade = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.DS_Cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Cliente")))
                        reg.UF_Cliente = reader.GetString(reader.GetOrdinal("UF_Cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF_Cliente")))
                        reg.Cd_uf_cliente = reader.GetString(reader.GetOrdinal("CD_UF_Cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.CD_CondPGTO = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.DS_CondPgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qt_Parcelas")))
                        reg.QTD_Parcelas = reader.GetDecimal(reader.GetOrdinal("QT_parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_DiasDesdobro")))
                    {
                        reg.Parcelas_Dias_Desdobro = reader.GetDecimal(reader.GetOrdinal("QT_DiasDesdobro"));
                        reg.Qt_diasdesdobro = reader.GetDecimal(reader.GetOrdinal("QT_DiasDesdobro"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_comEntrada")))
                        reg.Parcelas_Entrada = reader.GetString(reader.GetOrdinal("ST_comEntrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_VenctoemFeriado")))
                        reg.Parcelas_Feriado = reader.GetString(reader.GetOrdinal("ST_VenctoemFeriado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SolicitarDtVencto")))
                        reg.ST_SolicitarDtVencto = reader.GetString(reader.GetOrdinal("ST_SolicitarDtVencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Pedido")))
                        reg.DT_Pedido = reader.GetDateTime(reader.GetOrdinal("DT_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EntregaPedido")))
                        reg.Dt_entregapedido = reader.GetDateTime(reader.GetOrdinal("DT_EntregaPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Pedido")))
                        reg.ST_Pedido = reader.GetString(reader.GetOrdinal("ST_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TotalPedido")))
                        reg.Vl_totalpedido = reader.GetDecimal(reader.GetOrdinal("Vl_TotalPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalFat_Entrada")))
                        reg.Vl_totalfat_entrada = reader.GetDecimal(reader.GetOrdinal("Vl_TotalFat_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotalFat_Saida")))
                        reg.Vl_totalfat_saida = reader.GetDecimal(reader.GetOrdinal("Vl_TotalFat_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Pedido")))
                        reg.ST_Pedido = reader.GetString(reader.GetOrdinal("ST_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Clifor_Comprador")))
                        reg.Cd_clifor_comprador = reader.GetString(reader.GetOrdinal("CD_Clifor_Comprador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor_Comprador")))
                        reg.Nm_clifor_comprador = reader.GetString(reader.GetOrdinal("NM_Clifor_Comprador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ValoresFixos")))
                        reg.St_valoresfixos = reader.GetString(reader.GetOrdinal("ST_ValoresFixos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_Commoditties")))
                        reg.St_Commoditties = reader.GetString(reader.GetOrdinal("St_Commoditties"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ComissaoPed")))
                        reg.St_comissaoped = reader.GetString(reader.GetOrdinal("ST_ComissaoPed"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ComissaoFat")))
                        reg.St_comissaofat = reader.GetString(reader.GetOrdinal("ST_ComissaoFat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("ST_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_deposito")))
                        reg.St_deposito = reader.GetString(reader.GetOrdinal("st_deposito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_MunicipioExecServico")))
                        reg.Cd_municipioexecservico = reader.GetString(reader.GetOrdinal("CD_MunicipioExecServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MunicipioExecServico")))
                        reg.Ds_municipioexecservico = reader.GetString(reader.GetOrdinal("DS_MunicipioExecServico"));
                    
                    //Dados Juro Financeiro
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Juro_Fin")))
                        reg.Cd_juro_fin = reader.GetString(reader.GetOrdinal("CD_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Juro_Fin")))
                        reg.Ds_juro_fin = reader.GetString(reader.GetOrdinal("DS_Juro_Fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo")))
                        reg.Pc_jurodiario_atrazo = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Juro")))
                        reg.Tp_juro = reader.GetString(reader.GetOrdinal("TP_Juro"));
                    
                    //Registro Dados do Pedido
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.CD_TRANSPORTADORA = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.NM_TRANSPORTADORA = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC_CPF_Transp")))
                        reg.NR_CCG_CPF_TRANSP = reader.GetString(reader.GetOrdinal("NR_CGC_CPF_Transp"));
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_enderecotransp")))
                        reg.CD_ENDERECOTRANSP = reader.GetString(reader.GetOrdinal("cd_enderecotransp"));
                    if(!reader.IsDBNull(reader.GetOrdinal("ds_enderecotransp")))
                        reg.DS_ENDERECOTRANSP = reader.GetString(reader.GetOrdinal("ds_enderecotransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NumeroTransp")))
                        reg.NumeroTransp = reader.GetString(reader.GetOrdinal("NumeroTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeTransp")))
                        reg.CIDADE = reader.GetString(reader.GetOrdinal("ds_cidadeTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ufTransp")))
                        reg.UF = reader.GetString(reader.GetOrdinal("ufTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco")))
                        reg.DS_tabelapreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NomeVendedor")))
                        reg.Nomevendedor = reader.GetString(reader.GetOrdinal("NomeVendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Representante")))
                        reg.Cd_representante = reader.GetString(reader.GetOrdinal("CD_Representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_representante")))
                        reg.Nm_representante = reader.GetString(reader.GetOrdinal("nm_representante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comrep")))
                        reg.Pc_comrep = reader.GetDecimal(reader.GetOrdinal("pc_comrep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_gerente")))
                        reg.Cd_gerente = reader.GetString(reader.GetOrdinal("cd_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_gerente")))
                        reg.Nm_gerente = reader.GetString(reader.GetOrdinal("nm_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforind")))
                        reg.Cd_cliforind = reader.GetString(reader.GetOrdinal("cd_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforind")))
                        reg.Nm_cliforind = reader.GetString(reader.GetOrdinal("nm_cliforind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_Frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("TP_Frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_descontogeral = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Acrescimo")))
                        reg.Vl_acrescimogeral = reader.GetDecimal(reader.GetOrdinal("Vl_Acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Cotacao")))
                        reg.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("Vl_Cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QuantidadeNf")))
                        reg.QUANTIDADENF = reader.GetDecimal(reader.GetOrdinal("QuantidadeNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EspecieNf")))
                        reg.ESPECIENF = reader.GetString(reader.GetOrdinal("EspecieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MarcaNf")))
                        reg.MARCANF = reader.GetString(reader.GetOrdinal("MarcaNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NumeroNf")))
                        reg.NUMERONF = reader.GetString(reader.GetOrdinal("NumeroNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("PlacaVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logindesconto")))
                        reg.Logindesconto = reader.GetString(reader.GetOrdinal("logindesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_integraralmox")))
                        reg.St_integraralmox = reader.GetString(reader.GetOrdinal("st_integraralmox")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_descarga")))
                        reg.TP_descarga = reader.GetString(reader.GetOrdinal("tp_descarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforent")))
                        reg.Cd_cliforent = reader.GetString(reader.GetOrdinal("cd_cliforent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforent")))
                        reg.Nm_cliforent = reader.GetString(reader.GetOrdinal("nm_cliforent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpfent")))
                        reg.Cnpj_cpfent = reader.GetString(reader.GetOrdinal("cnpj_cpfent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_enderecoent")))
                        reg.Cd_enderecoent = reader.GetString(reader.GetOrdinal("cd_enderecoent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logradouroent")))
                        reg.Logradouroent = reader.GetString(reader.GetOrdinal("logradouroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numeroent")))
                        reg.Numeroent = reader.GetString(reader.GetOrdinal("numeroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("complementoent")))
                        reg.Complementoent = reader.GetString(reader.GetOrdinal("complementoent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairroent")))
                        reg.Bairroent = reader.GetString(reader.GetOrdinal("bairroent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidadeent")))
                        reg.Cd_cidadeent = reader.GetString(reader.GetOrdinal("cd_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeent")))
                        reg.Ds_cidadeent = reader.GetString(reader.GetOrdinal("ds_cidadeent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_ent")))
                        reg.Uf_ent = reader.GetString(reader.GetOrdinal("uf_ent"));

                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_Orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Cliforent")))
                        reg.Cd_condfiscalent = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Cliforent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_pessoaent")))
                        reg.Tp_pessoaent = reader.GetString(reader.GetOrdinal("Tp_pessoaent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_uf_ent")))
                        reg.Cd_uf_ent = reader.GetString(reader.GetOrdinal("Cd_uf_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Anexo_Compra")))
                        reg.Anexo_compra = (byte[])reader.GetValue(reader.GetOrdinal("Anexo_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_subst")))
                        reg.Tot_subst = reader.GetDecimal(reader.GetOrdinal("tot_subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_ipi")))
                        reg.Tot_ipi = reader.GetDecimal(reader.GetOrdinal("tot_ipi"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Id_CategoriaCliFor")))
                        reg.Id_CategoriaCliFor = reader.GetDecimal(reader.GetOrdinal("Id_CategoriaCliFor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CategoriaClifor")))
                        reg.DS_CategoriaClifor = reader.GetString(reader.GetOrdinal("DS_CategoriaClifor"));

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

        public string Gravar_Pedido(TRegistro_Pedido val)
        {
            Hashtable hs = new Hashtable(42);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_NR_SEQPEDIDO", val.NR_SeqPedido);
            hs.Add("@P_NR_PEDIDOORIGEM", val.Nr_PedidoOrigem);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa); 
            hs.Add("@P_CFG_PEDIDO", val.CFG_Pedido); 
            hs.Add("@P_CD_CLIFOR", val.CD_Clifor); 
            hs.Add("@P_CD_ENDERECO", val.CD_Endereco);
            hs.Add("@P_CD_CONDPGTO", val.CD_CondPGTO); 
            hs.Add("@P_TP_MOVIMENTO", val.TP_Movimento);
            hs.Add("@P_DS_OBSERVACAO", val.DS_Observacao);
            hs.Add("@P_DT_PEDIDO", val.DT_Pedido);
            hs.Add("@P_DT_ENTREGAPEDIDO", val.Dt_entregapedido);
            hs.Add("@P_ST_PEDIDO", val.ST_Pedido);
            hs.Add("@P_CD_CLIFOR_COMPRADOR", val.Cd_clifor_comprador);
            hs.Add("@P_ST_REGISTRO", val.ST_Registro);
            hs.Add("@P_TP_DESCARGA", val.TP_descarga);
            //Parametros TB_FAT_DadosPedido
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_REPRESENTANTE", val.Cd_representante);
            hs.Add("@P_PC_COMREP", val.Pc_comrep);
            hs.Add("@P_CD_GERENTE", val.Cd_gerente);
            hs.Add("@P_CD_CLIFORIND", val.Cd_cliforind);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_VL_COTACAO", val.Vl_cotacao);
            hs.Add("@P_CD_TRANSPORTADORA", val.CD_TRANSPORTADORA);
            hs.Add("@P_CD_ENDERECOTRANSP", val.CD_ENDERECOTRANSP);
            hs.Add("@P_QUANTIDADENF", val.QUANTIDADENF);
            hs.Add("@P_ESPECIENF", val.ESPECIENF);
            hs.Add("@P_MARCANF", val.MARCANF);
            hs.Add("@P_NUMERONF", val.NUMERONF);
            hs.Add("@P_CD_MUNICIPIOEXECSERVICO", val.Cd_municipioexecservico);
            hs.Add("@P_LOGINDESCONTO", val.Logindesconto);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_CD_CLIFORENT", val.Cd_cliforent);
            hs.Add("@P_CD_ENDERECOENT", val.Cd_enderecoent);
            hs.Add("@P_LOGRADOUROENT", val.Logradouroent);
            hs.Add("@P_NUMEROENT", val.Numeroent);
            hs.Add("@P_COMPLEMENTOENT", val.Complementoent);
            hs.Add("@P_BAIRROENT", val.Bairroent);
            hs.Add("@P_CD_CIDADEENT", val.Cd_cidadeent);
            hs.Add("@P_LOGINCANC", val.LoginCancelamento);
            hs.Add("@P_DS_MOTIVOCANC", val.dsCancelmento);
            hs.Add("@P_ANEXO_COMPRA", val.Anexo_compra);
            
            return executarProc("IA_FAT_PEDIDO", hs);
        }

        public string Deletar_Pedido(TRegistro_Pedido val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            return executarProc("EXCLUI_FAT_PEDIDO", hs);
        }
    }
    #endregion

    #region Classe Acessorios Ped
    public class TList_AcessoriosPed : List<TRegistro_AcessoriosPed>
    { }


    public class TRegistro_AcessoriosPed
    {
        public decimal? Nr_pedido
        { get; set; }
        private decimal? id_acessorio;

        public decimal? Id_acessorio
        {
            get { return id_acessorio; }
            set
            {
                id_acessorio = value;
                id_acessoriostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_acessoriostr;

        public string Id_acessoriostr
        {
            get { return id_acessoriostr; }
            set
            {
                id_acessoriostr = value;
                try
                {
                    id_acessorio = decimal.Parse(value);
                }catch { id_acessorio = null; }
            }
        }

        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
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
        public decimal Qtd_expedida { get; set; }
        public decimal SaldoCarregar
        { get { return Quantidade - Qtd_expedida; } }
        public string Obs
        { get; set; }

        public TRegistro_AcessoriosPed()
        {
            Nr_pedido = null;
            id_acessorio = null;
            id_acessoriostr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_referencia = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_marca = decimal.Zero;
            Ds_marca = string.Empty;
            Cd_unditem = string.Empty;
            Ds_unditem = string.Empty;
            Sg_unditem = string.Empty;
            Quantidade = decimal.Zero;
            Qtd_expedida = decimal.Zero;
            Obs = string.Empty;
        }
    }

    public class TCD_AcessoriosPed : TDataQuery
    {
        public TCD_AcessoriosPed()
        { }

        public TCD_AcessoriosPed(TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Nr_Pedido, a.ID_Acessorio, ");
                sql.AppendLine("a.CD_Produto, b.ds_produto, ISNULL(b.Codigo_Alternativo, 'RF') as cd_referencia, ");
                sql.AppendLine("b.CD_Marca, d.DS_Marca, b.cd_unidade as cd_unditem, c.ds_unidade as ds_unditem, a.CD_Local, e.DS_Local, ");
                sql.AppendLine("c.sigla_Unidade as sg_unditem, a.quantidade, a.qtd_expedida, a.Obs ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_AcessoriosPed a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_Unidade = c.cd_unidade ");
            sql.AppendLine("inner join vtb_fat_pedido ped ");
            sql.AppendLine("on a.nr_pedido = ped.nr_pedido ");
            sql.AppendLine("left outer join TB_EST_Marca d ");
            sql.AppendLine("on b.CD_Marca = d.CD_Marca ");
            sql.AppendLine("left outer join TB_EST_LocalArm e ");
            sql.AppendLine("on e.CD_Local = a.CD_Local ");

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

        public TList_AcessoriosPed Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_AcessoriosPed lista = new TList_AcessoriosPed();
            SqlDataReader reader = null;

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AcessoriosPed reg = new TRegistro_AcessoriosPed();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_acessorio")))
                        reg.Id_acessorio = reader.GetDecimal(reader.GetOrdinal("id_acessorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_referencia")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("cd_referencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Local"))))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_expedida")))
                        reg.Qtd_expedida = reader.GetDecimal(reader.GetOrdinal("Qtd_expedida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));

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

        public string Gravar(TRegistro_AcessoriosPed val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_OBS", val.Obs);

            return executarProc("IA_FAT_ACESSORIOSPED", hs);
        }

        public string Excluir(TRegistro_AcessoriosPed val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return executarProc("EXCLUI_FAT_ACESSORIOSPED", hs);
        }
    }
    #endregion

    #region Anexo Pedido
    public class TList_AnexoPedido : List<TRegistro_AnexoPedido>, IComparer<TRegistro_AnexoPedido>
    {
        #region IComparer<TRegistro_AnexoPedido> Members
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

        public TList_AnexoPedido()
        { }

        public TList_AnexoPedido(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AnexoPedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AnexoPedido x, TRegistro_AnexoPedido y)
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

    public class TRegistro_AnexoPedido
    {
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
        private decimal? id_etapa;
        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;
        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch { id_etapa = null; }
            }
        }
        private decimal? id_processo;
        public decimal? Id_processo
        {
            get { return id_processo; }
            set
            {
                id_processo = value;
                id_processostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_processostr;
        public string Id_processostr
        {
            get { return id_processostr; }
            set
            {
                id_processostr = value;
                try
                {
                    id_processo = decimal.Parse(value);
                }
                catch { id_processo = null; }
            }
        }
        private decimal? id_anexo;
        public decimal? Id_anexo
        {
            get { return id_anexo; }
            set
            {
                id_anexo = value;
                id_anexostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_anexostr;
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
                catch
                { id_anexo = null; }
            }
        }
        public string Ds_anexo
        { get; set; }
        public string Ext_Anexo
        { get; set; }
        public byte[] Anexo
        { get; set; }

        public TRegistro_AnexoPedido()
        {
            nr_pedido = null;
            nr_pedidostr = string.Empty;
            id_etapa = null;
            id_etapastr = string.Empty;
            id_processo = null;
            id_processostr = string.Empty;
            id_anexo = null;
            id_anexostr = string.Empty;
            Ext_Anexo = string.Empty;
            Anexo = null;
            Ds_anexo = string.Empty;
        }
    }

    public class TCD_AnexoPedido : TDataQuery
    {
        public TCD_AnexoPedido()
        { }

        public TCD_AnexoPedido(TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.Nr_pedido, a.ID_Etapa, a.ID_Processo, a.ID_Anexo, a.DS_Anexo, a.Ext_Anexo, a.Anexo");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FAT_AnexoPedido a");

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

        public TList_AnexoPedido Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_AnexoPedido lista = new TList_AnexoPedido();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AnexoPedido reg = new TRegistro_AnexoPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("Id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_processo")))
                        reg.Id_processo = reader.GetDecimal(reader.GetOrdinal("id_processo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Anexo")))
                        reg.Id_anexo = reader.GetDecimal(reader.GetOrdinal("ID_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Anexo")))
                        reg.Ds_anexo = reader.GetString(reader.GetOrdinal("DS_Anexo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ext_Anexo")))
                        reg.Ext_Anexo = reader.GetString(reader.GetOrdinal("Ext_Anexo"));
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

        public string Grava(TRegistro_AnexoPedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_ID_PROCESSO", val.Id_processo);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);
            hs.Add("@P_DS_ANEXO", val.Ds_anexo);
            hs.Add("@P_EXT_ANEXO", val.Ext_Anexo);
            hs.Add("@P_ANEXO", val.Anexo);

            return executarProc("IA_FAT_ANEXOPEDIDO", hs);
        }

        public string Deleta(TRegistro_AnexoPedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_ID_PROCESSO", val.Id_processo);
            hs.Add("@P_ID_ANEXO", val.Id_anexo);

            return executarProc("EXCLUI_FAT_ANEXOPEDIDO", hs);
        }
    }
    #endregion
}

 