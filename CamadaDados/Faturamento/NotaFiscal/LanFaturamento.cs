using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Utils;
using CamadaDados.Balanca;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Fiscal;
using CamadaDados.Graos;
using CamadaDados.Estoque;
using CamadaDados.Faturamento.PDV;
using CamadaDados.Faturamento.Pedido;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_RegLanFaturamento:List<TRegistro_LanFaturamento>, IComparer<TRegistro_LanFaturamento>
    {
        #region IComparer<TRegistro_LanFaturamento> Members
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

        public TList_RegLanFaturamento()
        { }

        public TList_RegLanFaturamento(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanFaturamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanFaturamento x, TRegistro_LanFaturamento y)
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

    public class TRegistro_LanFaturamento
    {
        public string Cd_empresa
        { get; set; }
        public string NR_NotaFiscal_danfe { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
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
                catch
                { nr_lanctofiscal = null; }
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
                catch
                { nr_notafiscal = null; }
            }
        }
        private decimal? nr_rps;
        public decimal? Nr_rps
        {
            get { return nr_rps; }
            set
            {
                nr_rps = value;
                nr_rpsstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_rpsstr;
        public string Nr_rpsstr
        {
            get { return nr_rpsstr; }
            set
            {
                nr_rpsstr = value;
                try
                {
                    nr_rps = decimal.Parse(value);
                }
                catch
                { nr_rps = null; }
            }
        }
        public decimal Nr_embarque
        {
            get;
            set;
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
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set 
            { 
                dt_emissao = value;
                dt_emissaostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_emissaostring;
        public string Dt_emissaostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_emissaostring = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_emissao = null;
                }
            }
        }
        private DateTime? dt_saient;
        public DateTime? Dt_saient
        {
            get { return dt_saient; }
            set 
            { 
                dt_saient = value;
                dt_saientstring = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_saientstring;
        public string Dt_saientstring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_saientstring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set 
            { 
                dt_saientstring = value;
                try
                {
                    dt_saient = Convert.ToDateTime(value);
                }
                catch
                { dt_saient = null; }
            }
        }
        public string Cd_modelo
        {
            get;
            set;
        }
        public string Nr_serie
        {
            get;
            set;
        }
        public string Cd_condpgto
        {
            get;
            set;
        }
        public decimal Qtd_Parcelas
        { get; set; }
        public decimal Qt_diasdesdobro
        { get; set; }
        public bool St_cometrada
        { get; set; }
        public string Cd_juro_fin
        { get; set; }
        public string Ds_juro_fin
        { get; set; }
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        public string Tp_juro
        { get; set; }
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set 
            { 
                nr_pedido = value;
                nr_pedidostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_pedidostring;
        public string Nr_pedidostring
        {
            get { return nr_pedidostring; }
            set 
            { 
                nr_pedidostring = value;
                try
                {
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        public decimal? Nr_orcamento
        { get; set; }
        public bool St_confere_saldo
        { get; set; }
        public string Cd_clifor
        {
            get;
            set;
        }
        public string Cd_endereco
        {
            get;
            set;
        }
        public string Insc_estadualclifor
        { get; set; }
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set 
            { 
                cd_movimentacao = value;
                cd_movimentacaostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_movimentacaostring;
        public string Cd_movimentacaostring
        {
            get { return cd_movimentacaostring; }
            set 
            { 
                cd_movimentacaostring = value;
                try
                {
                    cd_movimentacao = Convert.ToDecimal(value);
                }
                catch { cd_movimentacao = null; }
            }
        }
        public string Cd_centroresultCMV
        { get; set; }
        private decimal? cd_cmi;
        public decimal? Cd_cmi
        {
            get { return cd_cmi; }
            set 
            { 
                cd_cmi = value;
                cd_cmistring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_cmistring;
        public string Cd_cmistring
        {
            get { return cd_cmistring; }
            set 
            { 
                cd_cmistring = value;
                try
                {
                    cd_cmi = Convert.ToDecimal(value);
                }
                catch { cd_cmi = null; }
            }
        }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        private string tp_nota;
        public string Tp_nota
        {
            get { return tp_nota; }
            set 
            { 
                tp_nota = value;
                if (string.IsNullOrEmpty(value))
                    return;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_nota = "PROPRIA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_nota = "TERCEIRO";
            }
        }
        private string tipo_nota;
        public string Tipo_nota
        {
            get { return tipo_nota; }
            set 
            { 
                tipo_nota = value;
                if (value.Trim().ToUpper().Equals("PROPRIA"))
                    tp_nota = "P";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_nota = "T";
            }
        }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public string Cd_moedanf
        { get; set; }
        public string Ds_moeda_singularnf
        { get; set; }
        public string Ds_moeda_pluralnf
        { get; set; }
        public string Sigla_moedanf
        { get; set; }
        public string ValorExtensoNota
        {
            get
            {
                if (Vl_totalnota > 0)
                {
                    return new Utils.Extenso().ValorExtenso(Vl_totalnota,
                                                            Ds_moeda_singularnf,
                                                            Ds_moeda_pluralnf);
                }
                else
                    return string.Empty;
            }
        }
        public string Cd_transportadora
        { get; set; }
        public string Nm_razaosocialtransp
        {
            get;
            set;
        }
        public string Cpf_transp
        {
            get;
            set;
        }
        public string Cd_enderecotransp
        { get; set; }
        public string Ds_enderecotransp
        { get; set; }
        public string Ds_cidadetransp
        { get; set; }
        public string Uf_transp
        { get; set; }
        public string Insc_estadualtransp
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_seguro
        {
            get;
            set;
        }
        public decimal Vl_juro_fin
        { get; set; }
        public decimal Vl_outrasdesp
        {
            get;
            set;
        }
        private string freteporconta;
        public string Freteporconta
        {
            get { return freteporconta; }
            set 
            { 
                freteporconta = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tp_frete = "EMITENTE";
                else if (value.Trim().ToUpper().Equals("1"))
                    tp_frete = "DESTINATARIO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tp_frete = "TERCEIRO";
                else if (value.Trim().ToUpper().Equals("9"))
                    tp_frete = "SEM FRETE";
            }
        }
        private string tp_frete;
        public string Tp_frete
        {
            get { return tp_frete; }
            set 
            { 
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("EMITENTE"))
                    freteporconta = "0";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    freteporconta = "1";
                else if(value.Trim().ToUpper().Equals("TERCEIRO"))
                freteporconta = "2";
                else if(value.Trim().ToUpper().Equals("SEM FRETE"))
                freteporconta = "9";
            }
        }
        public string Placaveiculo
        {
            get;
            set;
        }
        public string Ufveiculo
        { get; set; }
        public decimal Quantidade
        {
            get;
            set;
        }
        public string Especie
        {
            get;
            set;
        }
        public string Marca
        {
            get;
            set;
        }
        public string Numero
        {
            get;
            set;
        }
        private decimal pesobruto;
        public decimal Pesobruto
        {
            get { return pesobruto; }
            set { pesobruto = value; }
        }
        private decimal pesoliquido;
        public decimal Pesoliquido
        {
            get { return pesoliquido; }
            set { pesoliquido = value; }
        }
        public string Dadosadicionais
        {
            get;
            set;
        }
        public string Obsfiscal
        {
            get;
            set;
        }
        private string st_agregarfrete;
        public string St_agregarfrete
        {
            get { return st_agregarfrete; }
            set 
            { 
                st_agregarfrete = value;
                if (value.Trim().ToUpper().Equals("S"))
                    status_agregarfrete = "SIM";
                else if (value.Trim().ToUpper().Equals("N"))
                    status_agregarfrete = "NAO";
            }
        }
        private string status_agregarfrete;
        public string Status_agregarfrete
        {
            get { return status_agregarfrete; }
            set 
            { 
                status_agregarfrete = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                    st_agregarfrete = "S";
                else if (value.Trim().ToUpper().Equals("NAO"))
                    st_agregarfrete = "N";
            }
        }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set 
            { 
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_registro = "ABERTO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_registro = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("D"))
                    status_registro = "DENEGADO";
            }
        }
        private string status_registro;
        public string Status_registro
        {
            get { return status_registro; }
            set 
            { 
                status_registro = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("DENEGADO"))
                    status_registro = "D";
            }
        }
        public TList_RegLanFaturamento_Item ItensNota
        {
            get;
            set;
        }
        public TList_RegLanDuplicata Duplicata
        {
            get;
            set;
        }
        public List<TRegistro_LanParcela> lParcAgrupar
        { get; set; }
        public List<TRegistro_LanParcela> lParcDev { get; set; } = new List<TRegistro_LanParcela>();
        public TList_RegLanFaturamento_CMI Cminf
        { get; set; }
        public string Nm_clifor
        {
            get;
            set;
        }
        public string Nr_cgc_cpf
        { get; set; }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Uf_clifor
        { get; set; }
        public string Cd_uf_clifor
        { get; set; }
        public string Ds_cmi
        {
            get;
            set;
        }
        public string Ds_condpgto
        {
            get;
            set;
        }
        public string Nm_empresa
        {
            get;
            set;
        }
        public string Uf_empresa
        { get; set; }
        public string Cd_uf_empresa
        { get; set; }
        public string NR_CGC_Empresa
        { get; set; }
        public string Ds_endereco
        {
            get;
            set;
        }
        public string Ds_modelo
        {
            get;
            set;
        }
        public string Ds_movimentacao
        {
            get;
            set;
        }
        public bool St_vendaconsumidor
        { get; set; }
        public string Ds_serienf
        {
            get;
            set;
        }
        public string Tp_serie
        { get; set; }
        private string tp_pessoa;
        public string Tp_pessoa
        {
            get { return tp_pessoa; }
            set
            {
                tp_pessoa = value;
                if (value.Trim().ToUpper().Equals("J"))
                    tipo_pessoa = "JURIDICA";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_pessoa = "FISICA";
            }
        }
        private string tipo_pessoa;
        public string Tipo_pessoa
        {
            get { return tipo_pessoa; }
            set 
            { 
                tipo_pessoa = value;
                if (value.Trim().ToUpper().Equals("JURIDICA"))
                    tp_pessoa = "J";
                else if (value.Trim().ToUpper().Equals("FISICA"))
                    tp_pessoa = "F";
            }
        }
        public bool St_sequenciaauto
        {
            get;
            set;
        }
        public string Cd_ufsaidaex
        { get; set; }
        public string Ds_ufsaidaex
        { get; set; }
        public string Uf_saidaex
        { get; set; }
        public string Ds_localex
        { get; set; }
        private decimal? nr_lanctofiscalRT;
        public decimal? Nr_lanctofiscalRT
        {
            get { return nr_lanctofiscalRT; }
            set
            {
                nr_lanctofiscalRT = value;
                nr_lanctofiscalRTstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalRTstr;
        public string Nr_lanctofiscalRTstr
        {
            get { return nr_lanctofiscalRTstr; }
            set
            {
                nr_lanctofiscalRTstr = value;
                try
                {
                    nr_lanctofiscalRT = decimal.Parse(value);
                }
                catch { nr_lanctofiscalRT = null; }
            }
        }
        public TList_RegLanPesagemGraos lTicketAplicar
        { get; set; }
        public TList_CadCFGPedidoFiscal lCFGFiscal
        { get; set; }        
        //Campos utilizados pela NF-e
        public string tp_emissaonfe
        { get; set; }
        public string Tipo_emissaonfe
        {
            get
            {
                if (tp_emissaonfe.Trim().Equals("1"))
                    return "NORMAL";
                else if (tp_emissaonfe.Trim().Equals("6"))
                    return "CONTINGENCIA SVC-AN";
                else if (tp_emissaonfe.Trim().Equals("7"))
                    return "CONTINGENCIA SVC-RS";
                else return string.Empty;
            }
        }

        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDuplicata { get; set; } = new Financeiro.Duplicata.TRegistro_LanDuplicata();
        public TRegistro_CadEmpresa rEmpresa
        { get; set; }
        public TRegistro_CadClifor rClifor
        { get; set; }
        public TRegistro_CadEndereco rEndereco
        { get; set; }
        public TRegistro_CadCMI rCmi
        { get; set; }
        public TRegistro_CfgNfe rCfgNfe
        { get; set; }
        public string Chave_acesso_nfe
        { get; set; }
        public string Nr_protocolo
        { get; set; }
        public bool St_transmitidoNFe
        { get { return !string.IsNullOrEmpty(Nr_protocolo); } }
        public bool St_enviadoNFe
        { get; set; }
        public bool St_transcanc_NFe
        { get; set; }
        public DateTime? Dt_processamento
        { get; set; }
        public DateTime? Dt_cadastro
        { get; set; }
        public string Ds_MsgReceita
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
        public TList_Lan_Originacao_x_Faturamento lOriginacao_x_Faturamento { get; set; }
        public CamadaDados.Estoque.TList_RegLanEstoque lEstoqueNf
        { get; set; }
        public TList_DevolucaoFIN lDevolucaoFin
        { get; set; }
        public bool St_formarlotectrc
        { get; set; }
        public string Xml_Nfe
        { get; set; }
        public TList_NFCe lCupom
        { get; set; }
        public NFE.TList_EventoNFe lEventoNFe
        { get; set; }
        public TList_Ordem_X_Expedicao lOrdem
        { get; set; }
        public TList_NFAcessorios_X_Estoque lNfAcessorios_X_Estoque
        { get; set; }
        public TRegistro_LanFaturamento rNFVendaRT { get; set; }
        //Campos Calculados
        public decimal Vl_totalProdutosServicos
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        public decimal Vl_totalservicos
        { get; set; }
        public string Cd_municipioexecservico
        { get; set; }
        public string Ds_municipioexecservico
        { get; set; }
        public decimal Vl_acrescimo_fin
        { get; set; }
        public decimal Vl_desconto_fin
        { get; set; }

        public TRegistro_LanFaturamento()
        {
            NR_NotaFiscal_danfe = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Uf_empresa = string.Empty;
            Cd_uf_empresa = string.Empty;
            NR_CGC_Empresa = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            nr_notafiscal = null;
            nr_notafiscalstr = string.Empty;
            nr_rps = null;
            nr_rpsstr = string.Empty;
            Nr_embarque = decimal.Zero;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            dt_emissao = null;
            dt_emissaostring = string.Empty;
            dt_saient = null;
            dt_saientstring = string.Empty;
            Cd_modelo = string.Empty;
            Ds_modelo = string.Empty;
            Nr_serie = string.Empty;
            Ds_serienf = string.Empty;
            Tp_serie = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            nr_pedido = null;
            Nr_orcamento = null;
            St_confere_saldo = false;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_condfiscal_clifor = string.Empty;
            Nr_cgc_cpf = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Ds_cidade = string.Empty;
            Uf_clifor = string.Empty;
            Cd_uf_clifor = string.Empty;
            Insc_estadualclifor = string.Empty;
            cd_movimentacao = null;
            cd_movimentacaostring = string.Empty;
            Ds_movimentacao = string.Empty;
            St_vendaconsumidor = false;
            Cd_centroresultCMV = string.Empty;
            cd_cmi = null;
            Ds_cmi = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            tp_nota = "P";
            tipo_nota = "PROPRIA";
            Cd_transportadora = string.Empty;
            Nm_razaosocialtransp = string.Empty;
            Cpf_transp = string.Empty;
            Cd_enderecotransp = string.Empty;
            Ds_enderecotransp = string.Empty;
            Ds_cidadetransp = string.Empty;
            Uf_transp = string.Empty;
            Insc_estadualtransp = string.Empty;
            Vl_seguro = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
            Vl_outrasdesp = decimal.Zero;
            freteporconta = "9";
            tp_frete = "SEM FRETE";
            Placaveiculo = string.Empty;
            Ufveiculo = string.Empty;
            Quantidade = decimal.Zero;
            Especie = string.Empty;
            Marca = string.Empty;
            Numero = string.Empty;
            pesobruto = decimal.Zero;
            pesoliquido = decimal.Zero;
            Dadosadicionais = string.Empty;
            Obsfiscal = string.Empty;
            st_agregarfrete = string.Empty;
            status_agregarfrete = string.Empty;
            st_registro = "A";
            status_registro = "ABERTO";
            tp_pessoa = string.Empty;
            tipo_pessoa = string.Empty;
            St_sequenciaauto = false;
            Chave_acesso_nfe = string.Empty;
            Vl_frete = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Qtd_Parcelas = decimal.Zero;
            Qt_diasdesdobro = decimal.Zero;
            St_cometrada = false;
            Cd_juro_fin = string.Empty;
            Ds_juro_fin = string.Empty;
            Pc_jurodiario_atrazo = decimal.Zero;
            Tp_juro = string.Empty;
            Cd_moedanf = string.Empty;
            Ds_moeda_singularnf = string.Empty;
            Ds_moeda_pluralnf = string.Empty;
            Sigla_moedanf = string.Empty;
            Nr_protocolo = string.Empty;
            Dt_processamento = null;
            Dt_cadastro = null;
            Ds_MsgReceita = string.Empty;
            Cd_ufsaidaex = string.Empty;
            Ds_ufsaidaex = string.Empty;
            Uf_saidaex = string.Empty;
            Ds_localex = string.Empty;
            rNFVendaRT = null;
            lTicketAplicar = new TList_RegLanPesagemGraos();
            ItensNota = new TList_RegLanFaturamento_Item();
            Duplicata = new TList_RegLanDuplicata();
            rDuplicata = new Financeiro.Duplicata.TRegistro_LanDuplicata();
            lParcAgrupar = new List<TRegistro_LanParcela>();
            Cminf = new TList_RegLanFaturamento_CMI();
            rEmpresa = new TRegistro_CadEmpresa();
            rClifor = new TRegistro_CadClifor();
            rEndereco = new TRegistro_CadEndereco();
            rCmi = new TRegistro_CadCMI();
            rCfgNfe = new TRegistro_CfgNfe();
            lOriginacao_x_Faturamento = new TList_Lan_Originacao_x_Faturamento();
            lEstoqueNf = new TList_RegLanEstoque();
            lDevolucaoFin = new TList_DevolucaoFIN();
            lCupom = new TList_NFCe();
            lEventoNFe = new NFE.TList_EventoNFe();
            lOrdem = new TList_Ordem_X_Expedicao();
            lNfAcessorios_X_Estoque = new TList_NFAcessorios_X_Estoque();
            St_formarlotectrc = false;
            Vl_totalnota = decimal.Zero;
            Vl_comissao = decimal.Zero;
            Vl_totalProdutosServicos = decimal.Zero;
            Vl_totalservicos = decimal.Zero;
            Cd_municipioexecservico = string.Empty;
            Ds_municipioexecservico = string.Empty;
            Xml_Nfe = string.Empty;
            Vl_acrescimo_fin = decimal.Zero;
            Vl_desconto_fin = decimal.Zero;
            tp_emissaonfe = string.Empty;
            Logradouroent = string.Empty;
            Numeroent = string.Empty;
            Complementoent = string.Empty;
            Bairroent = string.Empty;
            Cd_cidadeent = string.Empty;
            Ds_cidadeent = string.Empty;
            Uf_ent = string.Empty;
            St_transcanc_NFe = false;
            St_enviadoNFe = false;
            nr_lanctofiscalRT = null;
            nr_lanctofiscalRTstr = string.Empty;
        }
    }

    public class TCD_LanFaturamento : TDataQuery
    {
        public TCD_LanFaturamento()
        {  }

        public TCD_LanFaturamento(string vNM_ProcSqlBusca )
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;        
        }

        public TCD_LanFaturamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }
        
        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();            
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.Nr_LanctoFiscal, a.Nr_NotaFiscal, a.Nr_RPS, a.Nr_Embarque, a.Tp_Movimento, a.nr_lanctofiscalRT, ");
                sql.AppendLine("a.DT_Emissao, a.DT_SaiEnt, a.Vl_Frete, a.Vl_Seguro, a.Vl_OutrasDesp, a.FreteporConta, a.PlacaVeiculo, a.Quantidade, a.Especie, a.Marca, a.Numero, ");
                sql.AppendLine("a.PesoBruto, a.PesoLiquido, a.ST_Registro, a.ST_AgregarFrete, a.DadosAdicionais, a.vl_comissao, a.vl_juro_fin, ");
                sql.AppendLine("a.Nr_Serie, a.CD_CondPGTO, a.Nr_Pedido, a.CD_Modelo, a.CD_CMI, a.CD_Movimentacao, a.ST_TRANSCANC_NFE, ");
                sql.AppendLine("a.ObsFiscal, a.Tp_Nota, a.VL_Desconto, e.DS_SerieNf, e.ST_SequenciaAuto, e.tp_serie, f.DS_Modelo, l.qt_parcelas, ");
                sql.AppendLine("l.DS_CondPgto, k.DS_Movimentacao, k.Cd_CentroResult, k.st_vendaconsumidor, m.DS_CMI, ");
                sql.AppendLine("tp_dup.tp_duplicata, tp_dup.ds_tpduplicata, a.Chave_Acesso_NFE, null as Imagem_Empresa_Relatorio, a.ST_EnviadoNFe, ");
                sql.AppendLine("a.ufveiculo, a.cd_transportadora, a.NM_RazaoSocialTransp, a.dt_cad, a.TP_EmissaoNFe, ");
                sql.AppendLine("case when isnull(a.cpf_transp, '') = '' then case when cliforTransp.tp_pessoa = 'J' then cliforTransp.nr_cgc else cliforTransp.nr_cpf end else a.cpf_transp end as cpf_transp, ");
                sql.AppendLine("a.cd_enderecotransp, endTransp.ds_endereco as ds_enderecotransp, a.nr_protocolo, a.dt_processamento, a.Ds_MsgReceita, ");
                sql.AppendLine("endTransp.ds_cidade as ds_cidadetransp, endTransp.uf as uftransp, isnull(endTransp.insc_estadual, cliforTransp.nr_rg) as insc_estadualtransp, ");
                sql.AppendLine("dup.cd_moeda, moeda.ds_moeda_singular, moeda.ds_moeda_plural, moeda.sigla, ");
                sql.AppendLine("a.Vl_totalnota, a.Vl_totalProdutosServicos, a.Vl_totalservicos, ");
                sql.AppendLine("dbo.F_FORMAT_NR_NOTAFISCAL_NFE(dbo.F_PADLEFT_RIGHT(convert(varchar(15), a.nr_notafiscal), 9, '0', 'L')) as nr_notafiscal_relatorio, ");
                sql.AppendLine("a.cd_municipioexecservico, cid.ds_cidade as ds_municipioexecservico, a.cd_ufsaidaex, ufex.ds_uf as ds_ufsaidaex, ufex.uf as uf_saidaex, ");
                sql.AppendLine("a.xml_nfe, a.vl_acrescimo_fin, a.vl_desconto_fin, a.ds_localex, ");
                //Clifor NFe
                sql.AppendLine("a.CD_Clifor, h.NM_Clifor, h.TP_Pessoa, h.cd_condfiscal_clifor, case when h.tp_pessoa = 'J' then h.nr_cgc else h.nr_cpf end as nr_cgc_cpf, ");
                sql.AppendLine("h.nr_cgc, h.nr_cpf, h.nm_fantasia, ");
                //Endereco Clifor NFe
                sql.AppendLine("a.CD_Endereco, i.DS_Endereco, i.cd_cidade, i.ds_cidade, i.uf as UF_Clifor, i.cd_uf as cd_uf_clifor, ");
                sql.AppendLine("i.insc_estadual as insc_estadualclifor, i.numero as numero_clifor, i.bairro, i.cep, i.proximo, i.cp, i.fone, i.fone_comercial, i.celular, ");
                sql.AppendLine("i.ds_complemento, i.ds_uf as ds_uf_clifor, i.cd_pais as cd_pais_clifor, i.nm_pais as nm_pais_clifor, i.st_naocontribuinte, ");
                //CMI Nota Fiscal
                sql.AppendLine("cmi.st_mestra, cmi.st_devolucao, cmi.st_complementar, cmi.st_geraestoque, cmi.st_simplesremessa, cmi.st_compdevimposto, ");
                //Cfg NFe
                sql.AppendLine("cfg.TP_AmbienteCont, cfg.Path_NFE_Schemas, ");
                sql.AppendLine("cfg.NR_Certificado_NFE, cfg.TP_Ambiente, cfg.TP_Ambiente_NFES, ");
                sql.AppendLine("cfg.CD_Versao, cfg.HorasCancNfe, cfg.ID_EntidadeNFES, ");
                sql.AppendLine("cfg.NR_DiasExpirarCert, cfg.ST_EnviarEmailContador, cfg.DT_AvisoCert, ");
                sql.AppendLine("cfg.DS_CondUsoCCe, cfg.CD_VersaoEvento, cfg.CD_VersaoConDest, ");
                //Empresa NFe
                sql.AppendLine("a.CD_Empresa, c.NM_Empresa, c.CD_Clifor_Contador, c.CD_Escritorio_Contabil, ");
                sql.AppendLine("c.crc_contador, c.cd_empresa_dominio, c.cd_registrojunta, c.logoempresa, ");
                sql.AppendLine("c.tp_regimetributario, c.tp_basetributacaonormal, c.tp_empresasimples, ");
                sql.AppendLine("c.insc_municipal, c.cnae_fiscal, c.tp_regimetribmunicipal, c.st_incentivadorcultural, ");
                sql.AppendLine("c.tp_perfilfiscal, c.tp_atividadespedfiscal, ");
                sql.AppendLine("c.tp_atividadespedpiscofins, c.tp_naturezapj, c.tp_incidtributaria, isub.insc_estadual_subst, ");
                sql.AppendLine("c.tp_apropcredito, c.tp_contribuicao, c.tp_regimecumulativo, c.layoutspedfiscal, c.layoutspedpiscofins, ");
                sql.AppendLine("insc_estadual_subst = (select top 1 x.insc_estadual_subst ");
                sql.AppendLine("                        from TB_DIV_InscSubstEmpresa x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.cd_uf = i.cd_uf), ");
                //Clifor Empresa
                sql.AppendLine("cEmp.cd_clifor as cd_clifor_emp, cEmp.NM_Clifor as nm_clifor_emp, ");
                sql.AppendLine("cEmp.TP_Pessoa as tp_pessoa_emp, cEmp.cd_condfiscal_clifor as cd_condfiscal_clifor_emp, ");
                sql.AppendLine("cEmp.NR_CGC as NR_CGC_Empresa, ");
                //Endereco Empresa 
                sql.AppendLine("endEmpresa.CD_Endereco as cd_endereco_emp, endEmpresa.DS_Endereco as ds_endereco_emp, ");
                sql.AppendLine("endEmpresa.cd_cidade as cd_cidade_emp, endEmpresa.ds_cidade as ds_cidade_emp, ");
                sql.AppendLine("endEmpresa.UF as UF_Empresa, endEmpresa.cd_uf as CD_UF_Empresa, ");
                sql.AppendLine("endEmpresa.insc_estadual as insc_estadual_emp, endEmpresa.numero as numero_emp, ");
                sql.AppendLine("endEmpresa.bairro as bairro_emp, endEmpresa.cep as cep_emp, endEmpresa.proximo as proximo_emp, ");
                sql.AppendLine("endEmpresa.cp as cp_emp, endEmpresa.fone as fone_emp, endEmpresa.celular as celular_emp, ");
                sql.AppendLine("endEmpresa.ds_complemento as ds_complemento_emp, endEmpresa.ds_uf as ds_uf_emp, ");
                sql.AppendLine("endEmpresa.cd_pais as cd_pais_emp, endEmpresa.nm_pais as nm_pais_emp, ");
                //Endereco Entrega
                sql.AppendLine("a.LogradouroEnt, a.NumeroEnt, a.ComplementoEnt, a.BairroEnt, ");
                sql.AppendLine("a.Cd_CidadeEnt, cident.ds_cidade as ds_cidadeent, ufent.uf as uf_ent, ");
                sql.AppendLine("NR_Orcamento = (select top 1 x.nr_orcamento ");
                sql.AppendLine("                from tb_fat_pedido_itens x ");
                sql.AppendLine("                where x.nr_pedido = a.nr_pedido) ");

            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
          
            sql.AppendLine("FROM VTB_FAT_NotaFiscal A  ");
            //Empresa
            sql.AppendLine("INNER JOIN TB_DIV_Empresa c ");
            sql.AppendLine("ON a.CD_Empresa = c.CD_Empresa ");
            //Clifor Empresa
            sql.AppendLine("INNER JOIN VTB_FIN_Clifor cEmp ");
            sql.AppendLine("on c.cd_clifor = cEmp.cd_clifor ");
            //Endereco Empresa
            sql.AppendLine("INNER JOIN VTB_FIN_Endereco endEmpresa ");
            sql.AppendLine("ON c.cd_clifor = endEmpresa.cd_clifor ");
            sql.AppendLine("and c.cd_endereco = endEmpresa.cd_endereco ");
            //Serie
            sql.AppendLine("INNER JOIN TB_FAT_SerieNF e ");
            sql.AppendLine("ON a.Nr_Serie = e.Nr_Serie ");
            sql.AppendLine("and a.cd_modelo = e.cd_modelo ");
            //Modelo
            sql.AppendLine("INNER JOIN TB_FAT_ModeloNF f ");
            sql.AppendLine("ON a.CD_Modelo = f.CD_Modelo ");
            //Pedido
            sql.AppendLine("INNER JOIN TB_FAT_Pedido g ");
            sql.AppendLine("ON a.Nr_Pedido = g.Nr_Pedido ");
            //Clifor
            sql.AppendLine("INNER JOIN VTB_FIN_CLIFOR h ");
            sql.AppendLine("ON a.CD_Clifor = h.CD_Clifor ");
            //Endereco Clifor
            sql.AppendLine("INNER JOIN VTB_FIN_ENDERECO i ");
            sql.AppendLine("ON a.CD_Clifor = i.CD_Clifor ");
            sql.AppendLine("AND a.CD_Endereco = i.CD_Endereco ");
            //Movimentacao
            sql.AppendLine("INNER JOIN TB_FIS_Movimentacao k ");
            sql.AppendLine("ON a.CD_Movimentacao = k.CD_Movimentacao "); 
            //CMI
            sql.AppendLine("INNER JOIN TB_FIS_CMI m ");
            sql.AppendLine("ON a.CD_CMI = m.CD_CMI ");
            //Nota Fiscal X CMI
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal_CMI cmi ");
            sql.AppendLine("ON a.cd_empresa = cmi.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = cmi.nr_lanctofiscal ");
            //NF X Duplicata
            sql.AppendLine("LEFT OUTER JOIN TB_FAT_NotaFiscal_X_Duplicata NFDup ");
            sql.AppendLine("ON a.cd_empresa = NFDup.cd_empresa ");
            sql.AppendLine("AND a.nr_lanctofiscal = NFDup.nr_lanctofiscal ");
            //Duplicata
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Duplicata dup ");
            sql.AppendLine("ON NFDup.cd_empresa = dup.cd_empresa ");
            sql.AppendLine("and NFDup.nr_lanctoduplicata = dup.nr_lancto and isnull(dup.st_Registro,'A') <> 'C' ");
            //Moeda
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda moeda ");
            sql.AppendLine("ON dup.cd_moeda = moeda.cd_moeda ");
            //Condicao Pagamento
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_CondPGTO l ");
            sql.AppendLine("ON a.CD_CondPGTO = l.CD_CondPGTO ");
            //Tipo Duplicata
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_TPDuplicata tp_dup ");
            sql.AppendLine("ON m.tp_duplicata = tp_dup.tp_duplicata ");
            //Transportadora
            sql.AppendLine("LEFT OUTER JOIN VTB_FIN_Clifor cliforTransp ");
            sql.AppendLine("ON a.cd_transportadora = cliforTransp.cd_clifor ");
            //Endereco Transp
            sql.AppendLine("LEFT OUTER JOIN VTB_FIN_ENDERECO endTransp ");
            sql.AppendLine("ON a.cd_transportadora = endTransp.cd_clifor ");
            sql.AppendLine("and a.cd_enderecotransp = endTransp.cd_endereco ");
            //Cidade Servico
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Cidade cid ");
            sql.AppendLine("ON a.cd_municipioexecservico = cid.cd_cidade ");
            //Cfg Nfe
            sql.AppendLine("LEFT OUTER JOIN TB_FAT_CfgNfe cfg ");
            sql.AppendLine("on a.cd_empresa = cfg.cd_empresa ");
            //Inscricao Estadual Subst NFe
            sql.AppendLine("LEFT OUTER JOIN TB_DIV_InscSubstEmpresa isub ");
            sql.AppendLine("on a.cd_empresa = isub.cd_empresa ");
            sql.AppendLine("and i.cd_uf = isub.cd_uf ");
            //Estado Saida Exportacao
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_UF ufEx ");
            sql.AppendLine("on a.cd_ufsaidaex = ufex.cd_uf ");
            //Cidade Entrega
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Cidade cident ");
            sql.AppendLine("on a.cd_cidadeent = cident.cd_cidade ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_UF as ufent ");
            sql.AppendLine("on cident.cd_uf = ufent.cd_uf ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaNFXDuplicata(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, a.NR_LanctoFiscal, ");
                sql.AppendLine("a.NR_LanctoDuplicata, a.DT_Cad, a.DT_Alt ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAT_NotaFiscal_X_Duplicata A ");
            string cond = " where ";
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
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty }).ToString();
                return ExecutarBusca(sql ,null);
            }
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo }).ToString();
                return ExecutarBusca(sql ,null);
            }
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)        
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_RegLanFaturamento Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);
            
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty));
            TList_RegLanFaturamento lista = new TList_RegLanFaturamento();
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanFaturamento reg = new TRegistro_LanFaturamento();
                    //Clifor NFe
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                    {
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                        reg.rClifor.Cd_clifor = reg.Cd_clifor;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                    {
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                        reg.rClifor.Nm_clifor = reg.Nm_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor")))
                    {
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Clifor"));
                        reg.rClifor.Cd_condfiscal_clifor = reg.Cd_condfiscal_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pessoa")))
                        reg.rClifor.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.rClifor.Nr_cgc = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        reg.rClifor.Nr_cpf = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fantasia")))
                        reg.rClifor.Nm_fantasia = reader.GetString(reader.GetOrdinal("nm_fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC_CPF")))
                        reg.Nr_cgc_cpf = reader.GetString(reader.GetOrdinal("NR_CGC_CPF"));
                    //Endereco NFe
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                    {
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                        reg.rEndereco.Cd_endereco = reg.Cd_endereco;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Endereco"))))
                    {
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                        reg.rEndereco.Ds_endereco = reg.Ds_endereco;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                    {
                        reg.rEndereco.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                        reg.rEndereco.rCidade.Cd_cidade = reg.rEndereco.Cd_cidade;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                    {
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                        reg.rEndereco.DS_Cidade = reg.Ds_cidade;
                        reg.rEndereco.rCidade.Ds_cidade = reg.Ds_cidade;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadualclifor")))
                    {
                        reg.Insc_estadualclifor = reader.GetString(reader.GetOrdinal("insc_estadualclifor"));
                        reg.rEndereco.Insc_estadual = reg.Insc_estadualclifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Clifor")))
                    {
                        reg.Uf_clifor = reader.GetString(reader.GetOrdinal("UF_Clifor"));
                        reg.rEndereco.UF = reg.Uf_clifor;
                        reg.rEndereco.rCidade.rUf.Uf = reg.Uf_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF_Clifor")))
                    {
                        reg.Cd_uf_clifor = reader.GetString(reader.GetOrdinal("CD_UF_Clifor"));
                        reg.rEndereco.Cd_uf = reg.Cd_uf_clifor;
                        reg.rEndereco.rCidade.rUf.Cd_uf = reg.Cd_uf_clifor;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("numero_clifor")))
                        reg.rEndereco.Numero = reader.GetString(reader.GetOrdinal("numero_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.rEndereco.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        reg.rEndereco.Cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo")))
                        reg.rEndereco.Proximo = reader.GetString(reader.GetOrdinal("proximo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cp")))
                        reg.rEndereco.Cp = reader.GetString(reader.GetOrdinal("cp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.rEndereco.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_comercial")))
                        reg.rEndereco.Fone_comercial = reader.GetString(reader.GetOrdinal("fone_comercial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        reg.rEndereco.Celular = reader.GetString(reader.GetOrdinal("celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.rEndereco.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_uf_clifor")))
                        reg.rEndereco.DS_Estado = reader.GetString(reader.GetOrdinal("ds_uf_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_pais_clifor")))
                        reg.rEndereco.CD_Pais = reader.GetString(reader.GetOrdinal("cd_pais_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pais_clifor")))
                        reg.rEndereco.NM_Pais = reader.GetString(reader.GetOrdinal("nm_pais_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_naocontribuinte")))
                        reg.rEndereco.St_naocontribuinte = reader.GetString(reader.GetOrdinal("st_naocontribuinte"));
                    //CMI NFe
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CMI"))))
                    {
                        reg.Cd_cmi = reader.GetDecimal(reader.GetOrdinal("CD_CMI"));
                        reg.rCmi.Cd_cmi = reg.Cd_cmi;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CMI"))))
                    {
                        reg.Ds_cmi = reader.GetString(reader.GetOrdinal("DS_CMI"));
                        reg.rCmi.Ds_cmi = reg.Ds_cmi;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mestra")))
                        reg.rCmi.St_mestra = reader.GetString(reader.GetOrdinal("st_mestra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_devolucao")))
                        reg.rCmi.St_devolucao = reader.GetString(reader.GetOrdinal("st_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_complementar")))
                        reg.rCmi.St_complementar = reader.GetString(reader.GetOrdinal("st_complementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_geraestoque")))
                        reg.rCmi.St_geraestoque = reader.GetString(reader.GetOrdinal("st_geraestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_simplesremessa")))
                        reg.rCmi.St_simplesremessa = reader.GetString(reader.GetOrdinal("st_simplesremessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_compdevimposto")))
                        reg.rCmi.St_compdevimposto = reader.GetString(reader.GetOrdinal("st_compdevimposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TPDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TPDuplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPgto"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPgto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CondPgto"))))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscalRT")))
                        reg.Nr_lanctofiscalRT = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscalRT"));
                    //Cfg Nfe
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_AmbienteCont")))
                        reg.rCfgNfe.Tp_ambientecont = reader.GetString(reader.GetOrdinal("TP_AmbienteCont"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Path_NFE_Schemas")))
                        reg.rCfgNfe.Path_nfe_schemas = reader.GetString(reader.GetOrdinal("Path_NFE_Schemas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Certificado_NFE")))
                        reg.rCfgNfe.Nr_certificado_nfe = reader.GetString(reader.GetOrdinal("NR_Certificado_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente")))
                        reg.rCfgNfe.Tp_ambiente = reader.GetString(reader.GetOrdinal("TP_Ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente_NFES")))
                        reg.rCfgNfe.Tp_ambiente_nfes = reader.GetString(reader.GetOrdinal("TP_Ambiente_NFES"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Versao")))
                        reg.rCfgNfe.Cd_versao = reader.GetString(reader.GetOrdinal("CD_Versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HorasCancNfe")))
                        reg.rCfgNfe.Horascancnfe = reader.GetDecimal(reader.GetOrdinal("HorasCancNfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_EntidadeNFES")))
                        reg.rCfgNfe.Id_entidadenfes = reader.GetDecimal(reader.GetOrdinal("ID_EntidadeNFES"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasExpirarCert")))
                        reg.rCfgNfe.Nr_diasexpirarcert = reader.GetDecimal(reader.GetOrdinal("NR_DiasExpirarCert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EnviarEmailContador")))
                        reg.rCfgNfe.St_enviaremailcontador = reader.GetString(reader.GetOrdinal("ST_EnviarEmailContador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_AvisoCert")))
                        reg.rCfgNfe.Dt_avisoCert = reader.GetDateTime(reader.GetOrdinal("DT_AvisoCert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondUsoCCe")))
                        reg.rCfgNfe.Ds_condusoCCe = reader.GetString(reader.GetOrdinal("DS_CondUsoCCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoEvento")))
                        reg.rCfgNfe.Cd_versaoEvento = reader.GetString(reader.GetOrdinal("CD_VersaoEvento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_VersaoConDest")))
                        reg.rCfgNfe.Cd_versaocondest = reader.GetString(reader.GetOrdinal("CD_VersaoConDest"));
                    //Empresa
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                    {
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        reg.rEmpresa.Cd_empresa = reg.Cd_empresa;
                        reg.rCfgNfe.Cd_empresa = reg.Cd_empresa;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                    {
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                        reg.rEmpresa.Nm_empresa = reg.Nm_empresa;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor_Contador")))
                        reg.rEmpresa.Cd_clifor_contador = reader.GetString(reader.GetOrdinal("CD_Clifor_Contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Escritorio_Contabil")))
                        reg.rEmpresa.Cd_escritorio_contabil = reader.GetString(reader.GetOrdinal("CD_Escritorio_Contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("crc_contador")))
                        reg.rEmpresa.Crc_contador = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dominio")))
                        reg.rEmpresa.Cd_empresa_dominio = reader.GetDecimal(reader.GetOrdinal("cd_empresa_dominio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logoempresa")))
                        reg.rEmpresa.Img = (byte[])reader.GetValue(reader.GetOrdinal("logoempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetributario")))
                    {
                        reg.rEmpresa.Tp_regimetributario = reader.GetString(reader.GetOrdinal("tp_regimetributario"));
                        reg.rCfgNfe.Tp_regimetributario = reader.GetString(reader.GetOrdinal("tp_regimetributario"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_basetributacaonormal")))
                        reg.rEmpresa.Tp_basetributacaonormal = reader.GetString(reader.GetOrdinal("tp_basetributacaonormal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_empresasimples")))
                        reg.rEmpresa.Tp_empresasimples = reader.GetString(reader.GetOrdinal("tp_empresasimples"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_municipal")))
                    {
                        reg.rEmpresa.Insc_municipal = reader.GetString(reader.GetOrdinal("insc_municipal"));
                        reg.rCfgNfe.Insc_municipal_empresa = reader.GetString(reader.GetOrdinal("insc_municipal"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("cnae_fiscal")))
                        reg.rEmpresa.Cnae_fiscal = reader.GetString(reader.GetOrdinal("cnae_fiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetribmunicipal")))
                        reg.rEmpresa.Tp_regimetribmunicipal = reader.GetString(reader.GetOrdinal("tp_regimetribmunicipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_incentivadorcultural")))
                        reg.rEmpresa.St_incentivadorcultural = reader.GetString(reader.GetOrdinal("st_incentivadorcultural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_perfilfiscal")))
                        reg.rEmpresa.Tp_perfilfiscal = reader.GetString(reader.GetOrdinal("tp_perfilfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_atividadespedfiscal")))
                        reg.rEmpresa.Tp_atividadespedfiscal = reader.GetString(reader.GetOrdinal("tp_atividadespedfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_atividadespedpiscofins")))
                        reg.rEmpresa.Tp_atividadespedpiscofins = reader.GetString(reader.GetOrdinal("tp_atividadespedpiscofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_naturezapj")))
                        reg.rEmpresa.Tp_naturezaPJ = reader.GetString(reader.GetOrdinal("tp_naturezapj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_incidtributaria")))
                        reg.rEmpresa.Tp_incidtributaria = reader.GetString(reader.GetOrdinal("tp_incidtributaria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_apropcredito")))
                        reg.rEmpresa.Tp_apropcredito = reader.GetString(reader.GetOrdinal("tp_apropcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_contribuicao")))
                        reg.rEmpresa.Tp_contribuicao = reader.GetString(reader.GetOrdinal("tp_contribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimecumulativo")))
                        reg.rEmpresa.Tp_regimecumulativo = reader.GetString(reader.GetOrdinal("tp_regimecumulativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("layoutspedfiscal")))
                        reg.rEmpresa.LayoutSpedFiscal = reader.GetString(reader.GetOrdinal("layoutspedfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("layoutspedpiscofins")))
                        reg.rEmpresa.LayoutSpedPisCofins = reader.GetString(reader.GetOrdinal("layoutspedpiscofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_subst")))
                        reg.rEmpresa.Insc_estadual_subst = reader.GetString(reader.GetOrdinal("insc_estadual_subst"));
                    //Clifor Empresa
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_emp")))
                        reg.rEmpresa.rClifor.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_emp")))
                        reg.rEmpresa.rClifor.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa_emp")))
                        reg.rEmpresa.rClifor.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_clifor_emp")))
                        reg.rEmpresa.rClifor.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("cd_condfiscal_clifor_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC_Empresa")))
                    {
                        reg.NR_CGC_Empresa = reader.GetString(reader.GetOrdinal("NR_CGC_Empresa"));
                        reg.rEmpresa.rClifor.Nr_cgc = reg.NR_CGC_Empresa;
                        reg.rCfgNfe.Cnpj_empresa = reg.NR_CGC_Empresa;
                    }
                    //Endereco Empresa
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco_emp")))
                        reg.rEmpresa.rEndereco.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco_emp")))
                        reg.rEmpresa.rEndereco.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_emp")))
                    {
                        reg.rEmpresa.rEndereco.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade_emp"));
                        reg.rCfgNfe.Cd_municipio_empresa = reg.rEmpresa.rEndereco.Cd_cidade;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_emp")))
                        reg.rEmpresa.rEndereco.DS_Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Empresa")))
                    {
                        reg.Uf_empresa = reader.GetString(reader.GetOrdinal("UF_Empresa"));
                        reg.rEmpresa.rEndereco.UF = reg.Uf_empresa;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF_Empresa")))
                    {
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("CD_UF_Empresa"));
                        reg.rEmpresa.rEndereco.Cd_uf = reg.Cd_uf_empresa;
                        reg.rCfgNfe.Cd_uf_empresa = reg.Cd_uf_empresa;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_emp")))
                        reg.rEmpresa.rEndereco.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual_subst")))
                        reg.rEmpresa.Insc_estadual_subst = reader.GetString(reader.GetOrdinal("insc_estadual_subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero_emp")))
                        reg.rEmpresa.rEndereco.Numero = reader.GetString(reader.GetOrdinal("numero_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro_emp")))
                        reg.rEmpresa.rEndereco.Bairro = reader.GetString(reader.GetOrdinal("bairro_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep_emp")))
                        reg.rEmpresa.rEndereco.Cep = reader.GetString(reader.GetOrdinal("cep_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo_emp")))
                        reg.rEmpresa.rEndereco.Proximo = reader.GetString(reader.GetOrdinal("proximo_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cp_emp")))
                        reg.rEmpresa.rEndereco.Cp = reader.GetString(reader.GetOrdinal("cp_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone_emp")))
                        reg.rEmpresa.rEndereco.Fone = reader.GetString(reader.GetOrdinal("fone_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular_emp")))
                        reg.rEmpresa.rEndereco.Celular = reader.GetString(reader.GetOrdinal("celular_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento_emp")))
                        reg.rEmpresa.rEndereco.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_uf_emp")))
                        reg.rEmpresa.rEndereco.DS_Estado = reader.GetString(reader.GetOrdinal("ds_uf_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_pais_emp")))
                        reg.rEmpresa.rEndereco.CD_Pais = reader.GetString(reader.GetOrdinal("cd_pais_emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_pais_emp")))
                        reg.rEmpresa.rEndereco.NM_Pais = reader.GetString(reader.GetOrdinal("nm_pais_emp"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Modelo"))))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Modelo"))))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("DS_Modelo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao"))))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao"))))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vendaconsumidor")))
                        reg.St_vendaconsumidor = reader.GetString(reader.GetOrdinal("st_vendaconsumidor")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult")))
                        reg.Cd_centroresultCMV = reader.GetString(reader.GetOrdinal("cd_centroresult"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("DadosAdicionais"))))
                        reg.Dadosadicionais = reader.GetString(reader.GetOrdinal("DadosAdicionais"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt"))))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Especie"))))
                        reg.Especie = reader.GetString(reader.GetOrdinal("Especie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("FretePorConta"))))
                        reg.Freteporconta = reader.GetString(reader.GetOrdinal("FretePorConta"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Marca"))))
                        reg.Marca = reader.GetString(reader.GetOrdinal("Marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_RazaoSocialTransp"))))
                        reg.Nm_razaosocialtransp = reader.GetString(reader.GetOrdinal("NM_RazaoSocialTransp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CPF_Transp"))))
                        reg.Cpf_transp = reader.GetString(reader.GetOrdinal("CPF_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EnderecoTransp")))
                        reg.Cd_enderecotransp = reader.GetString(reader.GetOrdinal("CD_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EnderecoTransp")))
                        reg.Ds_enderecotransp = reader.GetString(reader.GetOrdinal("DS_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CidadeTransp")))
                        reg.Ds_cidadetransp = reader.GetString(reader.GetOrdinal("DS_CidadeTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UfTransp")))
                        reg.Uf_transp = reader.GetString(reader.GetOrdinal("UFTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_EstadualTransp")))
                        reg.Insc_estadualtransp = reader.GetString(reader.GetOrdinal("Insc_EstadualTransp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Embarque"))))
                        reg.Nr_embarque = reader.GetDecimal(reader.GetOrdinal("NR_Embarque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal"))))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_rps")))
                        reg.Nr_rps = reader.GetDecimal(reader.GetOrdinal("nr_rps"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal_relatorio")))
                        reg.NR_NotaFiscal_danfe = reader.GetString(reader.GetOrdinal("nr_notafiscal_relatorio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_SerieNf"))))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SequenciaAuto")))
                        reg.St_sequenciaauto = reader.GetString(reader.GetOrdinal("ST_SequenciaAuto")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_serie")))
                        reg.Tp_serie = reader.GetString(reader.GetOrdinal("tp_serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Numero"))))
                        reg.Numero = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ObsFiscal"))))
                        reg.Obsfiscal = reader.GetString(reader.GetOrdinal("ObsFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PesoBruto"))))
                        reg.Pesobruto = reader.GetDecimal(reader.GetOrdinal("PesoBruto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PesoLiquido"))))
                        reg.Pesoliquido = reader.GetDecimal(reader.GetOrdinal("PesoLiquido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo"))))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("PlacaVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UFVeiculo")))
                        reg.Ufveiculo = reader.GetString(reader.GetOrdinal("UFVeiculo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_AgregarFrete"))))
                        reg.St_agregarfrete = reader.GetString(reader.GetOrdinal("ST_AgregarFrete"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Nota"))))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("TP_Nota"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Frete"))))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_Frete"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDesp"))))
                        reg.Vl_outrasdesp = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDesp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Seguro"))))
                        reg.Vl_seguro = reader.GetDecimal(reader.GetOrdinal("Vl_Seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("vl_juro_fin"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pessoa"))))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFE")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_EmissaoNFe")))
                        reg.tp_emissaonfe = reader.GetString(reader.GetOrdinal("TP_EmissaoNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moedanf = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda_singularnf = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Plural")))
                        reg.Ds_moeda_pluralnf = reader.GetString(reader.GetOrdinal("DS_Moeda_Plural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla_moedanf = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetString(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TRANSCANC_NFE")))
                        reg.St_transcanc_NFe = reader.GetString(reader.GetOrdinal("ST_TRANSCANC_NFE")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EnviadoNFe")))
                        reg.St_enviadoNFe = reader.GetString(reader.GetOrdinal("ST_EnviadoNFe")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cad")))
                        reg.Dt_cadastro = reader.GetDateTime(reader.GetOrdinal("DT_Cad"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_MsgReceita")))
                        reg.Ds_MsgReceita = reader.GetString(reader.GetOrdinal("Ds_MsgReceita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalnota")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("Vl_totalnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalProdutosServicos")))
                        reg.Vl_totalProdutosServicos = reader.GetDecimal(reader.GetOrdinal("Vl_totalProdutosServicos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalservicos")))
                        reg.Vl_totalservicos = reader.GetDecimal(reader.GetOrdinal("Vl_totalservicos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_MunicipioExecServico")))
                        reg.Cd_municipioexecservico = reader.GetString(reader.GetOrdinal("CD_MunicipioExecServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MunicipioExecServico")))
                        reg.Ds_municipioexecservico = reader.GetString(reader.GetOrdinal("DS_MunicipioExecServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_parcelas")))
                        reg.Qtd_Parcelas = reader.GetDecimal(reader.GetOrdinal("qt_parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_nfe")))
                        reg.Xml_Nfe = reader.GetString(reader.GetOrdinal("xml_nfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("vl_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_acrescimo_fin")))
                        reg.Vl_acrescimo_fin = reader.GetDecimal(reader.GetOrdinal("vl_acrescimo_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto_fin")))
                        reg.Vl_desconto_fin = reader.GetDecimal(reader.GetOrdinal("vl_desconto_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ufsaidaex")))
                        reg.Cd_ufsaidaex = reader.GetString(reader.GetOrdinal("cd_ufsaidaex"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ufsaidaex")))
                        reg.Ds_ufsaidaex = reader.GetString(reader.GetOrdinal("ds_ufsaidaex"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_saidaex")))
                        reg.Uf_saidaex = reader.GetString(reader.GetOrdinal("uf_saidaex"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_localex")))
                        reg.Ds_localex = reader.GetString(reader.GetOrdinal("ds_localex"));
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

        public void incSeqNotaFiscal(TRegistro_LanFaturamento vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_serie);
            hs.Add("@P_CD_MODELO", vRegistro.Cd_modelo);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_lanctofiscal);

            string retorno = executarProc("INC_SEQNOTAFISCAL", hs);
            try
            {
                vRegistro.Nr_notafiscal = decimal.Parse(getPubVariavel(retorno, "@P_NR_NOTAFISCAL"));
            }
            catch (Exception ex)
            { throw new Exception("Erro incrementar numero nota: " + ex.Message.Trim()); }
        }

        public void IncSeqRPS(TRegistro_LanFaturamento val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_NR_RPS", val.Nr_rps);
            string retorno = executarProc("INC_SEQRPS", hs);
            try
            {
                val.Nr_rps = decimal.Parse(getPubVariavel(retorno, "@P_NR_RPS"));
            }
            catch (Exception ex)
            { throw new Exception("Erro incrementar numero RPS: " + ex.Message.Trim()); }
        }

        public string GravaNotaFiscal(TRegistro_LanFaturamento vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.Nr_lanctofiscal);
            hs.Add("@P_NR_NOTAFISCAL", vRegistro.Nr_notafiscal);
            hs.Add("@P_NR_RPS", vRegistro.Nr_rps);
            hs.Add("@P_NR_EMBARQUE", vRegistro.Nr_embarque);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.Tp_movimento);
            if(vRegistro.Tp_nota.Trim().ToUpper().Equals("P"))
            {
                vRegistro.Dt_emissao = vRegistro.Dt_emissao.Value.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second).AddMilliseconds(DateTime.Now.Millisecond);
                vRegistro.Dt_saient = vRegistro.Dt_saient.Value.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second).AddMilliseconds(DateTime.Now.Millisecond);
                hs.Add("@P_DT_EMISSAO", vRegistro.Dt_emissao);
                hs.Add("@P_DT_SAIENT",  vRegistro.Dt_saient);
            }
            else
            {
                hs.Add("@P_DT_EMISSAO", vRegistro.Dt_emissao);
                hs.Add("@P_DT_SAIENT", vRegistro.Dt_saient);
            }
            hs.Add("@P_CD_MODELO", vRegistro.Cd_modelo);
            hs.Add("@P_NR_SERIE", vRegistro.Nr_serie);
            hs.Add("@P_CD_CONDPGTO", vRegistro.Cd_condpgto);
            if(vRegistro.Nr_pedido.Equals(0))
                hs.Add("@P_NR_PEDIDO", DBNull.Value);
            else
                hs.Add("@P_NR_PEDIDO", vRegistro.Nr_pedido);
            hs.Add("@P_CD_CLIFOR", vRegistro.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", vRegistro.Cd_endereco);
            if(vRegistro.Cd_movimentacao.Equals(0))
                hs.Add("@P_CD_MOVIMENTACAO", DBNull.Value);
            else
                hs.Add("@P_CD_MOVIMENTACAO", vRegistro.Cd_movimentacao);
            if(vRegistro.Cd_cmi.Equals(0))
                hs.Add("@P_CD_CMI", DBNull.Value);
            else
                hs.Add("@P_CD_CMI", vRegistro.Cd_cmi);
            hs.Add("@P_TP_NOTA", vRegistro.Tp_nota);
            hs.Add("@P_VL_DESCONTO", vRegistro.Vl_desconto);
            hs.Add("@P_NM_RAZAOSOCIALTRANSP", vRegistro.Nm_razaosocialtransp);
            hs.Add("@P_CPF_TRANSP", vRegistro.Cpf_transp);
            hs.Add("@P_VL_FRETE", vRegistro.Vl_frete);
            hs.Add("@P_FRETEPORCONTA", vRegistro.Freteporconta);
            hs.Add("@P_PLACAVEICULO", vRegistro.Placaveiculo);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_ESPECIE", vRegistro.Especie);
            hs.Add("@P_MARCA", vRegistro.Marca);
            hs.Add("@P_NUMERO", vRegistro.Numero);
            hs.Add("@P_PESOBRUTO", vRegistro.Pesobruto);
            hs.Add("@P_PESOLIQUIDO", vRegistro.Pesoliquido);
            hs.Add("@P_DADOSADICIONAIS", vRegistro.Dadosadicionais);
            hs.Add("@P_OBSFISCAL", vRegistro.Obsfiscal);
            hs.Add("@P_ST_AGREGARFRETE", vRegistro.St_agregarfrete);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
            hs.Add("@P_CHAVE_ACESSO_NFE", vRegistro.Chave_acesso_nfe);
            hs.Add("@P_TP_EMISSAONFE", vRegistro.tp_emissaonfe);
            hs.Add("@P_CD_TRANSPORTADORA", vRegistro.Cd_transportadora);
            hs.Add("@P_CD_ENDERECOTRANSP", vRegistro.Cd_enderecotransp);
            hs.Add("@P_UFVEICULO", vRegistro.Ufveiculo);
            hs.Add("@P_CD_MUNICIPIOEXECSERVICO", vRegistro.Cd_municipioexecservico);
            hs.Add("@P_VL_ACRESCIMO_FIN", vRegistro.Vl_acrescimo_fin);
            hs.Add("@P_VL_DESCONTO_FIN", vRegistro.Vl_desconto_fin);
            hs.Add("@P_CD_UFSAIDAEX", vRegistro.Cd_ufsaidaex);
            hs.Add("@P_DS_LOCALEX", vRegistro.Ds_localex);
            hs.Add("@P_LOGRADOUROENT", vRegistro.Logradouroent);
            hs.Add("@P_NUMEROENT", vRegistro.Numeroent);
            hs.Add("@P_COMPLEMENTOENT", vRegistro.Complementoent);
            hs.Add("@P_BAIRROENT", vRegistro.Bairroent);
            hs.Add("@P_CD_CIDADEENT", vRegistro.Cd_cidadeent);
            hs.Add("@P_NR_LANCTOFISCALRT", vRegistro.Nr_lanctofiscalRT);

            return executarProc("IA_FAT_NOTAFISCAL", hs);
        }

        public string ExcluirNotaFiscal(TRegistro_LanFaturamento val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return executarProc("EXCLUI_FAT_NOTAFISCAL", hs);
        }

        public string AlteraNotaFiscal(TRegistro_LanFaturamento val)
        {
            Hashtable hs = new Hashtable(28);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_NR_RPS", val.Nr_rps);
            hs.Add("@P_CHAVE_ACESSO_NFE", val.Chave_acesso_nfe);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_MUNICIPIOEXECSERVICO", val.Cd_municipioexecservico);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_SAIENT", val.Dt_saient);
            hs.Add("@P_OBSFISCAL", val.Obsfiscal);
            hs.Add("@P_DADOSADICIONAIS", val.Dadosadicionais);
            hs.Add("@P_NR_EMBARQUE", val.Nr_embarque);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_NM_RAZAOSOCIALTRANSP", val.Nm_razaosocialtransp);
            hs.Add("@P_UFVEICULO", val.Ufveiculo);
            hs.Add("@P_CPF_TRANSP", val.Cpf_transp);
            hs.Add("@P_CD_ENDERECOTRANSP", val.Cd_enderecotransp);
            hs.Add("@P_FRETEPORCONTA", val.Freteporconta);
            hs.Add("@P_ESPECIE", val.Especie);
            hs.Add("@P_NUMERO", val.Numero);
            hs.Add("@P_PESOBRUTO", val.Pesobruto);
            hs.Add("@P_MARCA", val.Marca);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_PESOLIQUIDO", val.Pesoliquido);
            hs.Add("@P_XML_NFE", val.Xml_Nfe);
            hs.Add("@P_TP_EMISSAONFE", val.tp_emissaonfe);
            
            return executarProc("ALTERA_FAT_NOTAFISCAL", hs);
        }
                
        public string GravaNotaFiscalXDuplicata(TRegistro_LanFaturamento vNotaFiscal, TRegistro_LanDuplicata vDuplicata)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", vNotaFiscal.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vNotaFiscal.Nr_lanctofiscal);
            hs.Add("@P_NR_LANCTODUPLICATA", vDuplicata.Nr_lancto);
            return executarProc("IA_FAT_NOTAFISCAL_X_DUPLICATA", hs);
        }

        public string DeletaNotaFiscalXDuplicata(TRegistro_LanFaturamento vNotaFiscal, TRegistro_LanDuplicata vDuplicata)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", vNotaFiscal.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vNotaFiscal.Nr_lanctofiscal);
            hs.Add("@P_NR_LANCTODUPLICATA", vDuplicata.Nr_lancto);
            return executarProc("EXCLUI_FAT_NOTAFISCAL_X_DUPLICATA", hs);
        }
    }
}

