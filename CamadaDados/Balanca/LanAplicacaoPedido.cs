using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Graos;
using CamadaDados.Faturamento.Pedido;

namespace CamadaDados.Balanca
{
    #region Pedido Aplicação
        public class TList_PedidoAplicacao : List<TRegistro_PedidoAplicacao>{ }
        public class TList_SaldoSinteticoPedido : List<TRegistro_SaldoSinteticoPedido>{ }
        public class TList_TotaisConsulta : List<TRegistro_TotaisConsulta>{ }
        public class TList_LanctoEstoqueXPedido : List<TRegistro_LanctoEstoqueXPedido> { }
        public class TList_NotaFiscalPedido : List<TRegistro_NotaFiscalPedido> { }

        public class TRegistro_PedidoAplicacao
        {
            private decimal? nr_contrato;
            public decimal? Nr_contrato 
            {
                get { return nr_contrato; }
                set
                {
                    nr_contrato = value;
                    nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string nr_contratostr;
            public string Nr_contratostr
            {
                get { return nr_contratostr; }
                set
                {
                    nr_contratostr = value;
                    try
                    {
                        nr_contrato = Convert.ToDecimal(value);
                    }
                    catch
                    { nr_contrato = null; }
                }
            }
            public DateTime? Dt_abertura
            { get; set; }
            public string Cd_tipoamostra1
            { get; set; }
            public string Cd_tipoamostra2
            { get; set; }
            private decimal? nr_pedido;
            public decimal? Nr_pedido
            {
                get { return nr_pedido; }
                set
                {
                    nr_pedido = value;
                    nr_pedidostring = value.ToString();
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
            public decimal Id_pedidoitem
            { get; set; }
            public string Cd_clifor { get; set; }
            public string Nm_clifor { get; set; }
            public string Tp_pessoa { get; set; }
            public string Cd_endereco { get; set; }
            public string Cd_uf_clifor { get; set; }
            public string Uf_clifor { get; set; }
            public string Cd_condfiscal_clifor { get; set; }
            public string Cd_produto { get; set; }
            public string Ds_produto { get; set; }
            public string Cd_condfiscal_produto { get; set; }
            public string Cd_local { get; set; }
            public string Cd_unidade { get; set; }
            public string Ds_unidade { get; set; }
            public string Sigla_unidade { get; set; }
            public string Cd_unidade_estoque { get; set; }
            public string Ds_unidade_estoque { get; set; }
            public string Sigla_unidade_estoque { get; set; }
            private string tp_movimento;
            public string Tp_movimento
            {
                get { return tp_movimento; }
                set
                {
                    tp_movimento = value;
                    if (value.ToUpper().Trim().Equals("E"))
                        tipo_movimento = "ENTRADA";
                    else if (value.ToUpper().Trim().Equals("S"))
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
                    if (value.ToUpper().Trim().Equals("ENTRADA"))
                        tp_movimento = "E";
                    else if (value.ToUpper().Trim().Equals("SAIDA"))
                        tp_movimento = "S";
                }
            }
            public string Cd_tabeladesconto { get; set; }
            public string Ds_tabeladesconto { get; set; }
            public string Anosafra { get; set; }
            public string Ds_safra { get; set; }
            public string Cd_condpgto { get; set; }
            public string Ds_condpgto { get; set; }
            public string St_confere_saldo { get; set; }
            public string St_deposito { get; set; }
            public string St_valoresfixos { get; set; }
            public decimal Vl_unitario
            { get; set; }
            public decimal Vl_bonificacao { get; set; }
            public decimal Ps_contratado { get; set; }
            public decimal Ps_totalentrada { get; set; }
            public decimal Ps_totalsaida { get; set; }
            public decimal Ps_devolvido { get; set; }
            public decimal Ps_transf { get; set; }
            public decimal Ps_fixado { get; set; }
            public decimal Vl_fixado { get; set; }
            public decimal Vl_saldoadto { get; set; }
            public decimal tot_aplicado { get; set; }
            public decimal Qtd_Entrada_Transferencia { get; set; }
            public decimal Qtd_Saida_Transferencia { get; set; }
            public decimal VL_Adiantado { get; set; }
            public decimal VL_Devolvido { get; set; }
            public decimal Qtd_Entregar { get; set; }
            public decimal ps_retido_taxa { get; set; }
            public decimal ps_retido_taxafat { get; set; }
            public decimal vl_retido_taxa { get; set; }
            public decimal vl_retido_taxafat { get; set; }
            public decimal Vl_CreditoGMO { get; set; }
            public decimal QTD_DEBITOGMO_T { get; set; }
            public decimal QTD_DEBITOGMO_D { get; set; }
            public decimal QTD_CREDITO_GMO_D { get; set; }
            public decimal QTD_CREDITO_GMO_T { get; set; }
            public decimal QTD_SALDO_GMO_D { get; set; }
            public decimal QTD_SALDO_GMO_T { get; set; }
            public string Cd_empresa { get; set; }
            public string Nm_empresa { get; set; }
            public string Cd_uf_empresa { get; set; }
            public string Uf_empresa { get; set; }
            public string Cfg_pedido { get; set; }
            public string Ds_tipopedido { get; set; }
            public string Cd_moeda { get; set; }
            public string Ds_moeda { get; set; }
            public string Sigla_moeda { get; set; }
            public string Tp_prodcontrato
            { get; set; }
            public string Tipo_prodcontrato
            {
                get
                {
                    if (Tp_prodcontrato.Trim().ToUpper().Equals("CV"))
                        return "CONVENCIONAL";
                    else if (Tp_prodcontrato.Trim().ToUpper().Equals("TR"))
                        return "TRANGENICA";
                    else if (Tp_prodcontrato.Trim().ToUpper().Equals("ID"))
                        return "INTACTA DECLARADA";
                    else if (Tp_prodcontrato.Trim().ToUpper().Equals("IT"))
                        return "INTACTA TESTADA";
                    else if (Tp_prodcontrato.Trim().ToUpper().Equals("IP"))
                        return "INTACTA PARTICIPANTE";
                    else return string.Empty;
                }
            }
            public string St_registro
            { get; set; }
            public string Status_contrato
            {
                get
                {
                    if (this.St_registro.Trim().ToUpper().Equals("A"))
                        return "ABERTO";
                    else if (this.St_registro.Trim().ToUpper().Equals("E"))
                        return "ENCERRADO";
                    else if (this.St_registro.Trim().ToUpper().Equals("C"))
                        return "CANCELADO";
                    else return string.Empty;
                }
            }
            public decimal Ps_saldo
            {
                get
                {
                    if (tp_movimento.ToUpper().Trim().Equals("E"))
                        return Ps_totalentrada + Qtd_Entrada_Transferencia - Ps_totalsaida - Qtd_Saida_Transferencia - Ps_devolvido;
                    else if (tp_movimento.ToUpper().Trim().Equals("S"))
                        return Ps_totalsaida + Qtd_Saida_Transferencia - Ps_totalentrada - Qtd_Entrada_Transferencia - Ps_devolvido;
                    else
                        return 0;
                }
            }
            public decimal Ps_disponivel => Ps_saldo - Ps_fixado;
            
            public string St_exigirautorizretirada
            { get; set; }

            public TList_MovContrato MovContrato { get; set; }
            public TList_SinteticoTaxas SinteticoTaxas { get; set; }
            public TList_TaxaDeposito AnaliticoTaxas { get; set; }
            public TList_RegLanFaturamento_Item lNfPauta
            { get; set; }

            public TRegistro_PedidoAplicacao()
            {
                this.Id_pedidoitem = decimal.Zero;
                this.Anosafra = string.Empty;
                this.Cd_clifor = string.Empty;
                this.Cd_condpgto = string.Empty;
                this.Cd_endereco = string.Empty;
                this.Cd_uf_clifor = string.Empty;
                this.Uf_clifor = string.Empty;
                this.Cd_condfiscal_clifor = string.Empty;
                this.Cd_produto = string.Empty;
                this.Cd_condfiscal_produto = string.Empty;
                this.Cd_tabeladesconto = string.Empty;
                this.Cd_unidade = string.Empty;
                this.Cd_unidade_estoque = string.Empty;
                this.Cd_local = string.Empty;
                this.Ds_condpgto = string.Empty;
                this.Ds_produto = string.Empty;
                this.Ds_safra = string.Empty;
                this.Ds_tabeladesconto = string.Empty;
                this.Ds_unidade = string.Empty;
                this.Ds_unidade_estoque = string.Empty;
                this.Nm_clifor = string.Empty;
                this.nr_contrato = null;
                this.nr_contratostr = string.Empty;
                this.Dt_abertura = null;
                this.nr_pedido = null;
                this.nr_pedidostring = string.Empty;
                this.Ps_contratado = decimal.Zero;
                this.Ps_fixado = decimal.Zero;
                this.Vl_fixado = decimal.Zero;
                this.Ps_totalentrada = decimal.Zero;
                this.Ps_totalsaida = decimal.Zero;
                this.Ps_devolvido = decimal.Zero;
                this.Ps_transf = decimal.Zero;
                this.Sigla_unidade = string.Empty;
                this.Sigla_unidade_estoque = string.Empty;
                this.St_confere_saldo = string.Empty;
                this.St_deposito = string.Empty;
                this.Tp_prodcontrato = string.Empty;
                this.St_valoresfixos = string.Empty;
                this.tp_movimento = string.Empty;
                this.Tp_pessoa = string.Empty;
                this.Vl_saldoadto = decimal.Zero;
                this.Vl_unitario = decimal.Zero;
                this.Vl_bonificacao = decimal.Zero;
                this.Cd_empresa = string.Empty;
                this.Nm_empresa = string.Empty;
                this.Cd_uf_empresa = string.Empty;
                this.Uf_empresa = string.Empty;
                this.Cfg_pedido = string.Empty;
                this.Ds_tipopedido = string.Empty;
                this.St_exigirautorizretirada = string.Empty;
                this.Qtd_Entrada_Transferencia = decimal.Zero;
                this.Qtd_Saida_Transferencia = decimal.Zero;
                this.VL_Devolvido = decimal.Zero;
                this.VL_Adiantado = decimal.Zero;
                this.Qtd_Entregar = decimal.Zero;
                this.Vl_CreditoGMO = decimal.Zero;
                this.QTD_CREDITO_GMO_D = decimal.Zero;
                this.QTD_CREDITO_GMO_T = decimal.Zero;
                this.ps_retido_taxa = decimal.Zero;
                this.ps_retido_taxafat = decimal.Zero;
                this.vl_retido_taxa = decimal.Zero;
                this.vl_retido_taxafat = decimal.Zero;
                this.Cd_moeda = string.Empty;
                this.Ds_moeda = string.Empty;
                this.Sigla_moeda = string.Empty;
                this.Cd_tipoamostra1 = string.Empty;
                this.Cd_tipoamostra2 = string.Empty;
                this.St_registro = string.Empty;

                this.MovContrato = new TList_MovContrato();
                this.SinteticoTaxas = new TList_SinteticoTaxas();
                this.AnaliticoTaxas = new TList_TaxaDeposito();
                this.lNfPauta = new TList_RegLanFaturamento_Item();
            }
        }

        public class TRegistro_SaldoSinteticoPedido
        {
            public decimal NR_Contrato { get; set; }
            public decimal PS_Transf_E { get; set; }
            public decimal PS_Transf_S { get; set; }
            public decimal Qtd_E { get; set; }
            public decimal Qtd_S { get; set; }
            public decimal VL_Entrada_Est { get; set; }
            public decimal VL_Saida_Est { get; set; }
            public decimal Quantidade_Fiscal_E { get; set; }
            public decimal Quantidade_Fiscal_S { get; set; }
            public decimal VL_SubTotal_Fiscal_E { get; set; }
            public decimal VL_SubTotal_Fiscal_S { get; set; }
            public decimal QTD_Devol_E { get; set; }
            public decimal QTD_Devol_S { get; set; }
            public decimal VL_Devol_E { get; set; }
            public decimal VL_Devol_S { get; set; }
            public decimal Qtd_Estoque_E { get; set; }
            public decimal Qtd_Estoque_S { get; set; }
            
            public TRegistro_SaldoSinteticoPedido()
            {
                this.NR_Contrato = decimal.Zero;
                this.PS_Transf_E = decimal.Zero;
                this.PS_Transf_S = decimal.Zero;
                this.Qtd_E = decimal.Zero;
                this.Qtd_S = decimal.Zero;
                this.VL_Entrada_Est = decimal.Zero;
                this.VL_Saida_Est = decimal.Zero;
                this.VL_SubTotal_Fiscal_E = decimal.Zero;
                this.VL_SubTotal_Fiscal_S = decimal.Zero;
                this.QTD_Devol_E = decimal.Zero;
                this.QTD_Devol_S = decimal.Zero;
                this.VL_Devol_E = decimal.Zero;
                this.VL_Devol_S = decimal.Zero;
                this.Quantidade_Fiscal_E = decimal.Zero;
                this.Quantidade_Fiscal_S = decimal.Zero;
                this.Qtd_Estoque_E = decimal.Zero;
                this.Qtd_Estoque_S = decimal.Zero;
            }
        }

        public class TRegistro_TotaisConsulta
        {
            //ENTRADA
            public decimal EstoqueQTDEnt { get; set; }
            public decimal EstoqueQTDSai { get; set; }
            public decimal EstoqueVLEnt { get; set; }
            public decimal EstoqueVLSai { get; set; }
            //SAIDA
            public decimal FiscalQTDEnt { get; set; }
            public decimal FiscalQTDSai { get; set; }
            public decimal FiscalVLEnt { get; set; }
            public decimal FiscalVLSai { get; set; }
            //DIFERENÇA
            public decimal DiferencaQTDEnt { get; set; }
            public decimal DiferencaQTDSai { get; set; }
            public decimal DiferencaVLEnt { get; set; }
            public decimal DiferencaVLSai { get; set; }
            //BUSCA SALDO BALANÇA
            public decimal BalancaEnt { get; set; }
            public decimal BalancaSai { get; set; }
            public decimal TransfEnt { get; set; }
            public decimal TransfSai { get; set; }
            public decimal TransfTotSai { get; set; }
            public decimal BalTotEnt { get; set; }
            public decimal BalTotSai { get; set; }
            
            //ESTOQUE
            public decimal SDEstoqueQTD { get; set; }
            public decimal SDEstoqueVL { get; set; }
            public decimal SDFiscalQTD { get; set; }
            public decimal SDFiscalVL { get; set; }
            public decimal SDDiferencaQTD { get; set; }
            public decimal SDDiferencaVL { get; set; }

            //DISPONIVEL
            public decimal PSRetidoTaxa { get; set; }
            public decimal PSRetidoGMO { get; set; }
            public decimal LiquidoFinal { get; set; }

            public decimal ps_RetidoGMO_D { get; set; }
            public decimal ps_RetidoGMO_T { get; set; }

            public TRegistro_TotaisConsulta()
            {
                this.EstoqueQTDEnt = decimal.Zero;
                this.EstoqueQTDSai = decimal.Zero;
                this.EstoqueVLEnt = decimal.Zero;
                this.EstoqueVLSai = decimal.Zero;
                //SAIDA
                this.FiscalQTDEnt = decimal.Zero;
                this.FiscalQTDSai = decimal.Zero;
                this.FiscalVLEnt = decimal.Zero;
                this.FiscalVLSai = decimal.Zero;
                //DIFERENÇA
                this.DiferencaQTDEnt = decimal.Zero;
                this.DiferencaQTDSai = decimal.Zero;
                this.DiferencaVLEnt = decimal.Zero;
                this.DiferencaVLSai = decimal.Zero;
                //BUSCA SALDO BALANÇA
                this.BalancaEnt = decimal.Zero;
                this.BalancaSai = decimal.Zero;
                this.TransfEnt = decimal.Zero;
                this.TransfSai = decimal.Zero;
                this.TransfTotSai = decimal.Zero;
                this.BalTotEnt = decimal.Zero;
                this.BalTotSai = decimal.Zero;
                
                //ESTOQUE
                this.SDEstoqueQTD = decimal.Zero;
                this.SDEstoqueVL = decimal.Zero;
                this.SDFiscalQTD = decimal.Zero;
                this.SDFiscalVL = decimal.Zero;
                this.SDDiferencaQTD = decimal.Zero;
                this.SDDiferencaVL = decimal.Zero;

                //DISPONIVEL
                this.PSRetidoTaxa = decimal.Zero;
                this.PSRetidoGMO = decimal.Zero;
                this.LiquidoFinal = decimal.Zero;

                this.ps_RetidoGMO_D = decimal.Zero;
                this.ps_RetidoGMO_T = decimal.Zero;
            }
        }

        public class TRegistro_LanctoEstoqueXPedido
        {
            //ENTRADA
            public decimal NR_Pedido { get; set; }
            public decimal id_LanctoEstoque { get; set; }
            public string CD_Produto { get; set; }
            public string CD_Empresa { get; set; }
            public string NM_Empresa { get; set; }
            public string CD_Local { get; set; }
            public string DS_Local { get; set; }
            private DateTime? dt_lancto;
            public DateTime? Dt_lancto
            {
                get { return dt_lancto; }
                set
                {
                    dt_lancto = value;
                    _dt_lancto_STR = value.ToString();
                }
            }
            private string _dt_lancto_STR;
            public string Dt_lancto_STR
            {
                get
                {
                    try
                    {
                        return Convert.ToDateTime(_dt_lancto_STR).ToString("dd/MM/yyyy");
                    }
                    catch { return ""; }
                }
                set
                {
                    _dt_lancto_STR = value;
                    try
                    {
                        dt_lancto = Convert.ToDateTime(value);
                    }
                    catch { dt_lancto = null; }
                }
            }
            private string tp_movimento;
            public string Tp_movimento
            {
                get { return tp_movimento; }
                set
                {
                    tp_movimento = value;
                    if (value == "E")
                    {
                        tp_movimento_String = "ENTRADA";
                    }
                    else
                        if (value == "S")
                        {
                            tp_movimento_String = "SAIDA";
                        }
                }

            }
            private string tp_movimento_String;
            public string Tp_movimento_String
            {
                get { return tp_movimento_String; }
                set
                {
                    tp_movimento_String = value;
                    if (value == "E")
                    {
                        tp_movimento_String = "ENTRADA";
                    }
                    else
                        if (value == "S")
                        {
                            tp_movimento_String = "SAIDA";
                        }
                }
            }
            public string DS_Produto { get; set; }
            public decimal QTD_Entrada { get; set; }
            public decimal QTD_Saida { get; set; }
            private decimal vl_unitario;
            public decimal VL_Unitario 
            {
                get { return vl_unitario; }
                set { vl_unitario = value; }
            }
            public decimal VL_Subtotal { get; set; }
            private string tp_lancto;
            public string Tp_lancto
            {
                get { return tp_lancto; }
                set
                {
                    tp_lancto = value;
                    if (value.Equals("M"))
                        _TP_Lancto_String = "MANUAL";
                    else if (value.Equals("N"))
                        _TP_Lancto_String = "NORMAL";
                    else if (value.Equals("I"))
                        _TP_Lancto_String = "INVENTÁRIO";
                    else if (value.Equals("P"))
                        _TP_Lancto_String = "PROVISÃO";
                    else if (value.Equals("T"))
                        _TP_Lancto_String = "TRANSFERÊNCIA";
                    else if (value.Equals("L"))
                        _TP_Lancto_String = "COMP/DEV";
                }
            }
            private string _TP_Lancto_String;
            public string TP_Lancto_String
            {
                get { return _TP_Lancto_String; }
                set
                {
                    _TP_Lancto_String = value;
                    if (value.Equals("MANUAL"))
                        tp_lancto = "M";
                    else if (value.Equals("NORMAL"))
                        tp_lancto = "N";
                    else if (value.Equals("INVENTÁRIO"))
                        tp_lancto = "I";
                    else if (value.Equals("PROVISÃO"))
                        tp_lancto = "P";
                    else if (value.Equals("TRANSFERÊNCIA"))
                        tp_lancto = "T";
                    else if (value.Equals("COMP/DEV"))
                        tp_lancto = "L";
                }
            }
            public string DS_Observacao { get; set; }

            public TRegistro_LanctoEstoqueXPedido()
            {
                this.NR_Pedido = decimal.Zero;
                this.CD_Empresa = string.Empty;
                this.NM_Empresa = string.Empty;
                this.CD_Produto = string.Empty;
                this.DS_Produto = string.Empty;
                this.id_LanctoEstoque = decimal.Zero;
                this.CD_Local = string.Empty;
                this.DS_Local = string.Empty;
                this.dt_lancto = DateTime.Now;
                this.Dt_lancto_STR = DateTime.Now.ToString();
                this.tp_movimento = string.Empty;
                this.QTD_Entrada = decimal.Zero;
                this.QTD_Saida = decimal.Zero;
                this.vl_unitario = decimal.Zero;
                this.VL_Subtotal = decimal.Zero;
                this.tp_lancto = string.Empty;
            }

        }

        public class TRegistro_NotaFiscalPedido
        {
            public decimal Nr_LanctoFiscal { get; set; }
            public decimal Nr_Pedido { get; set; }
            public decimal Nr_NotaFiscal { get; set; } 
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
            public string CD_Empresa { get; set; }
            public string NM_Empresa { get; set; }
            private DateTime? dt_Emissao;
            public DateTime? Dt_Emissao
            {
                get { return dt_Emissao; }
                set
                {
                    dt_Emissao = value;
                    _dt_Emissao_STR = value.ToString();
                }
            }
            private string _dt_Emissao_STR;
            public string Dt_Emissao_STR
            {
                get
                {
                    try
                    {
                        return Convert.ToDateTime(_dt_Emissao_STR).ToString("dd/MM/yyyy");
                    }
                    catch { return ""; }
                }
                set
                {
                    _dt_Emissao_STR = value;
                    try
                    {
                        dt_Emissao = Convert.ToDateTime(value);
                    }
                    catch { dt_Emissao = null; }
                }
            }
            private DateTime? dt_SaiEnt;
            public DateTime? Dt_SaiEnt
            {
                get { return dt_SaiEnt; }
                set
                {
                    dt_SaiEnt = value;
                    _dt_SaiEnt_STR = value.ToString();
                }
            }
            private string _dt_SaiEnt_STR;
            public string Dt_SaiEnt_STR
            {
                get
                {
                    try
                    {
                        return Convert.ToDateTime(_dt_SaiEnt_STR).ToString("dd/MM/yyyy");
                    }
                    catch { return ""; }
                }
                set
                {
                    _dt_SaiEnt_STR = value;
                    try
                    {
                        dt_SaiEnt = Convert.ToDateTime(value);
                    }
                    catch { dt_SaiEnt = null; }
                }
            }
            public string Especie { get; set; } 
            public decimal Vl_TotalNota { get; set; }
            public string Nr_Serie { get; set; }
            public string DS_SerieNf { get; set; } 
            public string CD_Clifor { get; set; }
            private string tp_nota;
            public string Tp_nota
            {
                get { return tp_nota; }
                set
                {
                    tp_nota = value;
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
            public string NM_Clifor { get; set; }
            public decimal Quantidade { get; set; }
            public string CD_Unidade { get; set; }
            public string CD_UnidEst { get; set; }
            public string CD_Produto { get; set; }
            public string DS_Local { get; set; }
            public string DS_Produto { get; set; }
            public string DS_Unidade { get; set; }
            public string Sigla_Unidade { get; set; }
            public string sigla_unidade_estoque { get; set; }
            private decimal vl_unitario;
            public decimal VL_Unitario 
            {
                get { return vl_unitario; }
                set { vl_unitario = value; }
            } 
            public decimal VL_SubTotal { get; set; }
            public decimal QTD_Remessa { get; set; }
            public decimal VL_Remessa { get; set; }
            public decimal QTD_Disponivel { get; set; }
            public decimal VL_Disponivel{ get; set; }
            public decimal VL_Fixado { get; set; }
            public decimal QTD_Fixado { get; set; }
            public decimal Qtd_origem { get; set; }
            public decimal Qtd_sdorigem { get { return this.Quantidade - this.Qtd_origem; } }
            public decimal Vl_origem { get; set; }
            public decimal Vl_sdorigem { get { return this.VL_SubTotal - this.Vl_origem; } }
            public TList_NotaFiscalPedido List_NotaFiscalPedido { get; set; }

            public TRegistro_NotaFiscalPedido()
            {
                this.Nr_LanctoFiscal = decimal.Zero;
                this.Nr_Pedido = decimal.Zero;
                this.Nr_NotaFiscal = decimal.Zero;
                this.tp_movimento = string.Empty;
                this.CD_Empresa = string.Empty;
                this.NM_Empresa = string.Empty;
                this.Dt_Emissao = DateTime.Now;
                this.Dt_Emissao_STR = DateTime.Now.ToString("dd/mm/yyyy");
                this.Dt_SaiEnt = DateTime.Now;
                this.Dt_SaiEnt_STR = DateTime.Now.ToString("dd/mm/yyyy");
                this.Especie = string.Empty;
                this.Vl_TotalNota = decimal.Zero;
                this.Nr_Serie = string.Empty;
                this.DS_SerieNf = string.Empty;
                this.VL_Fixado = decimal.Zero;
                this.QTD_Fixado = decimal.Zero;
                this.CD_Clifor = string.Empty;
                this.tp_nota = string.Empty; 
                this.NM_Clifor = string.Empty;
                this.Quantidade = decimal.Zero;
                this.CD_Unidade = string.Empty;
                this.CD_UnidEst = string.Empty;
                this.CD_Produto = string.Empty;
                this.DS_Local = string.Empty;
                this.DS_Produto = string.Empty;
                this.DS_Unidade = string.Empty;
                this.Sigla_Unidade = string.Empty;
                this.sigla_unidade_estoque = string.Empty;
                this.vl_unitario = decimal.Zero;
                this.VL_SubTotal = decimal.Zero;
                this.Qtd_origem = decimal.Zero;
                this.Vl_origem = decimal.Zero;
                this.List_NotaFiscalPedido = new TList_NotaFiscalPedido();
            }

        }

        public class TCD_PedidoAplicacao : TDataQuery
        {
            public string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
            {
                string strTop = string.Empty;
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();
                if (string.IsNullOrEmpty(vNM_Campo))
                {
                    sql.AppendLine("Select " + strTop + " a.nr_contrato, a.nr_pedido, ");
                    sql.AppendLine("a.cd_condfiscal_clifor, a.cd_clifor, a.nm_clifor, ");
                    sql.AppendLine("a.cd_endereco, a.cd_empresa, a.uf_clifor, a.id_pedidoitem, ");
                    sql.AppendLine("a.tp_pessoa, a.st_exigirautorizretirada, a.cd_produto, ");
                    sql.AppendLine("a.ds_produto, a.cd_unidade, a.ds_unidade, a.nm_empresa, ");
                    sql.AppendLine("a.cd_condfiscal_produto, a.sigla_unidade, a.cd_unidade_estoque, ");
                    sql.AppendLine("a.tp_prodcontrato, a.uf_empresa, a.ds_unidade_estoque, a.tp_movimento, ");
                    sql.AppendLine("a.cd_tabeladesconto, a.ds_tabeladesconto, a.cfg_pedido, ");
                    sql.AppendLine("a.ds_tipopedido, a.anosafra, a.ds_safra, a.cd_condpgto, ");
                    sql.AppendLine("a.ds_condpgto, a.st_confere_saldo, a.st_deposito, ");
                    sql.AppendLine("a.st_valoresfixos, a.vl_unitario, a.ps_contratado, a.dt_abertura, ");
                    sql.AppendLine("a.cd_local, a.st_registro, a.cd_uf_clifor, a.vl_bonificacao_fix, ");
                    sql.AppendLine("a.cd_uf_empresa, a.ps_totalentrada, a.ps_totalsaida, a.ps_devolvido, ");
                    sql.AppendLine("a.tot_aplicado, a.ps_retido_taxa, vl_retido_taxa, ");
                    sql.AppendLine("a.ps_fixado, a.vl_fixado, a.qtd_transferencia_entrada, ");
                    sql.AppendLine("a.qtd_transferencia_saida, a.vl_adiantado, a.vl_devolvido, ");
                    sql.AppendLine("a.vl_creditogmo, a.qtd_debitogmo_t, a.qtd_creditogmo_t, ");
                    sql.AppendLine("a.qtd_creditogmo_d, a.qtd_debitogmo_d, a.sigla_unidade_estoque, ");
                    sql.AppendLine("a.vl_retido_taxafat, a.ps_retido_taxafat, a.cd_tipoamostra1, ");
                    sql.AppendLine("a.cd_moeda, a.ds_moeda, a.sigla_moeda, a.cd_tipoamostra2 ");
                }
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("from VTB_BAL_PEDIDOAPLICACAO a ");
                //Usuario tem acesso a empresa do contrato
                sql.AppendLine("where exists(select 1 from tb_div_usuario_x_empresa u ");
                sql.AppendLine("            where u.cd_empresa = a.cd_empresa ");
                sql.AppendLine("            and ((u.login = '"+ Utils.Parametros.pubLogin.Trim() +"') or ");
                sql.AppendLine("                (exists(select 1 from tb_div_usuario_x_grupos ug ");
                sql.AppendLine("                        where ug.logingrp = u.login and ug.loginusr = '"+ Utils.Parametros.pubLogin.Trim() +"')))) ");
                //Usuario tem acesso ao tipo de pedido amarrado ao contrato
                sql.AppendLine("and exists(select 1 from tb_div_usuario_x_cfgpedido cfg ");
                sql.AppendLine("            where cfg.cfg_pedido = a.cfg_pedido ");
                sql.AppendLine("            and ((cfg.login = '"+ Utils.Parametros.pubLogin.Trim() +"') or ");
                sql.AppendLine("                (exists(select 1 from tb_div_usuario_x_grupos ug ");
                sql.AppendLine("                        where ug.logingrp = cfg.login and ug.loginusr = '"+ Utils.Parametros.pubLogin.Trim() +"')))) ");
                
                string cond = " and ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

                sql.AppendLine("order by a.nr_pedido, a.nr_contrato, a.cd_produto ");

                return sql.ToString();
            }

            public string SqlCodeSaldoSintetico(TpBusca[] vBusca)
            {
                StringBuilder sql = new StringBuilder();
                
                sql.AppendLine("SELECT SUM( C.QTD_Entrada ) as qtd_E, ");
                sql.AppendLine("SUM( case when c.tp_movimento = 'E' then c.vl_subtotal else 0 end ) as VL_ent_Estoq, ");
                sql.AppendLine("SUM( C.QTD_Saida   ) as qtd_S, ");
                sql.AppendLine("SUM( case when c.tp_movimento = 'S' then c.vl_subtotal else 0 end ) as VL_sai_Estoq  ");

                sql.AppendLine("FROM TB_GRO_Contrato D ");
                sql.AppendLine("INNER JOIN TB_FAT_Pedido_X_Estoque E ");
                sql.AppendLine("on d.Nr_Pedido = E.Nr_Pedido ");
                sql.AppendLine("AND d.cd_produto = e.cd_produto ");
                sql.AppendLine("and d.ID_PedidoItem = e.ID_PedidoItem ");
                sql.AppendLine("INNER JOIN TB_EST_Estoque C ");
                sql.AppendLine("on C.CD_Empresa = E.CD_Empresa ");
                sql.AppendLine("AND C.CD_produto = E.Cd_produto ");
                sql.AppendLine("AND C.ID_LanctoEstoque = E.ID_LanctoEstoque ");

                sql.AppendLine("WHERE C.ST_Registro <> 'C' ");

                string cond = " AND ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                sql.AppendLine("GROUP BY D.Nr_Contrato ");
                return sql.ToString();
            }

            public string SqlCodeSaldoBalanca(TpBusca[] vBusca)
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT SUM( case when g.tp_movimento = 'E' then f.qtd_aplicado else 0 end ) as Qtd_Estoque_E, ");
                sql.AppendLine("SUM( case when g.tp_movimento = 'S' then f.qtd_aplicado else 0 end   ) as Qtd_Estoque_S ");

                sql.AppendLine("FROM TB_GRO_Contrato a ");
                sql.AppendLine("INNER JOIN TB_BAL_Aplicacao_Pedido f ");
                sql.AppendLine("on a.Nr_Pedido = f.Nr_Pedido ");
                sql.AppendLine("AND a.CD_Produto = f.cd_produto ");
                sql.AppendLine("and a.ID_PedidoItem = f.ID_PedidoItem ");
                sql.AppendLine("INNER JOIN TB_EST_Estoque g ");
                sql.AppendLine("on g.CD_Empresa = f.CD_Empresa ");
                sql.AppendLine("AND g.CD_produto = f.Cd_produto ");
                sql.AppendLine("AND g.ID_LanctoEstoque = f.ID_LanctoEstoque ");
                sql.AppendLine("INNER JOIN TB_EST_Produto p ");
                sql.AppendLine("ON f.CD_Produto = p.cd_produto ");
                sql.AppendLine("LEFT OUTER JOIN VTB_BAL_PSGraos h ");
                sql.AppendLine("ON h.CD_Empresa = f.CD_Empresa ");
                sql.AppendLine("AND h.ID_Ticket = f.ID_Ticket ");
                sql.AppendLine("AND h.TP_pesagem = f.tp_pesagem ");
                
                sql.AppendLine("WHERE isnull(g.ST_Registro,'N') <> 'C' ");

                string cond = " AND ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                sql.AppendLine("GROUP BY a.Nr_Contrato, a.Nr_Pedido, a.cd_produto, a.ID_PedidoItem ");
                return sql.ToString();
            }

            public string SqlCodeSaldoFiscal(TpBusca[] vBusca)
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT ISNULL(SUM(case when a.tp_movimento = 'E' then ISNULL(b.quantidade, 0) else 0 end), 0) as Quantidade_E, ");
                sql.AppendLine("ISNULL(SUM(case when a.tp_movimento = 'S' then ISNULL(b.quantidade, 0) else 0 end), 0) as Quantidade_S, ");
                sql.AppendLine("ISNULL(SUM(case when a.tp_movimento = 'E' then ISNULL(b.vl_subtotal, 0) else 0 end), 0) as VL_SubTotal_E, ");
                sql.AppendLine("ISNULL(SUM(case when a.tp_movimento = 'S' then ISNULL(b.vl_subtotal, 0) else 0 end), 0) as VL_SubTotal_S ");
                sql.AppendLine("FROM VTB_FAT_NotaFiscal a ");
                sql.AppendLine("inner join VTB_FAT_NotaFiscal_Item b ");
                sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
                sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI c ");
                sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
                sql.AppendLine("and a.nr_lanctofiscal = c.nr_lanctofiscal ");
                sql.AppendLine("inner join TB_GRO_Contrato d ");
                sql.AppendLine("on b.nr_pedido = d.nr_pedido ");
                sql.AppendLine("and b.cd_produto = d.cd_produto ");
                sql.AppendLine("and b.id_pedidoitem = d.id_pedidoitem ");
                sql.AppendLine("WHERE isnull(a.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("AND isnull(c.ST_Mestra,'N') <> 'S' ");

                string cond = " AND ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                return sql.ToString();
            }
           
            public string SqlCodeLanctoEstoqueXPedido(TpBusca[] vBusca)
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT b.id_LanctoEstoque, b.CD_Produto, b.CD_Local, c.DS_Local, b.DT_Lancto, d.DS_Produto, b.CD_Empresa, e.NM_Empresa, ");
	            sql.AppendLine("b.TP_Movimento, b.QTD_Entrada, b.QTD_Saida, b.VL_Unitario, b.VL_Subtotal, b.Tp_Lancto, b.DS_Observacao ");
                sql.AppendLine("FROM TB_FAT_Pedido_X_Estoque a  ");
                sql.AppendLine("INNER JOIN TB_EST_Estoque b ");
                sql.AppendLine("ON a.CD_Empresa = b.CD_Empresa ");
                sql.AppendLine("AND a.CD_Produto = b.CD_Produto ");
                sql.AppendLine("AND a.Id_LanctoEstoque = b.Id_LanctoEstoque ");
                sql.AppendLine("INNER JOIN TB_EST_LocalArm c ");
                sql.AppendLine("ON b.CD_Local = c.CD_Local ");
                sql.AppendLine("INNER JOIN TB_EST_Produto d ");
                sql.AppendLine("ON d.CD_Produto = a.CD_Produto ");
                sql.AppendLine("INNER JOIN TB_DIV_Empresa e ");
                sql.AppendLine("ON e.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("WHERE isnull(b.ST_Registro,'N') <> 'C'  ");

                string cond = " AND ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                sql.AppendLine("ORDER BY b.DT_Lancto ASC ");
                return sql.ToString();
            }

            public string SqlCodeNotasFiscais(TpBusca[] vBusca)
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT a.Nr_LanctoFiscal, a.Nr_NotaFiscal, a.Tp_Movimento, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.DT_Emissao, a.DT_SaiEnt, a.Especie, a.Nr_Serie, a.Vl_TotalNota, c.DS_SerieNf, a.Nr_Pedido, a.CD_Clifor, a.Tp_Nota, d.NM_Clifor, ");
                sql.AppendLine("e.Quantidade, e.CD_Unidade, i.CD_Unidade as CD_UnidEst, e.CD_Produto, f.DS_Local, i.DS_Produto, ");
                sql.AppendLine("h.DS_Unidade, h.Sigla_Unidade, undest.Sigla_Unidade as sigla_unidade_estoque, e.VL_Unitario, e.VL_SubTotal, ");
                sql.AppendLine("e.qtd_remessa, e.vl_remessa, e.vl_fixacao as vl_fixado, e.qtd_fixacao as qtd_fixado, e.qtd_origem, e.vl_origem ");
                
                sql.AppendLine("FROM VTB_FAT_NotaFiscal a   ");
                sql.AppendLine("INNER JOIN TB_DIV_Empresa b ");
                sql.AppendLine("ON a.CD_Empresa = b.CD_Empresa  ");
                sql.AppendLine("INNER JOIN TB_FAT_SerieNF c ");
                sql.AppendLine("ON a.Nr_Serie = c.Nr_Serie  ");
                sql.AppendLine("and a.cd_modelo = c.cd_modelo ");
                sql.AppendLine("INNER JOIN VTB_FIN_CLIFOR d ");
                sql.AppendLine("ON a.CD_Clifor = d.CD_Clifor  ");
                //DO ITEM
                sql.AppendLine("INNER JOIN VTB_FAT_NotaFiscal_Item e ");
                sql.AppendLine("On a.CD_Empresa = e.CD_Empresa ");
                sql.AppendLine("and a.NR_LanctoFiscal = e.NR_LanctoFiscal  ");
                sql.AppendLine("LEFT OUTER JOIN TB_EST_LocalArm f ");
                sql.AppendLine("ON e.CD_Local = f.CD_Local  ");
                sql.AppendLine("INNER JOIN TB_EST_Unidade h ");
                sql.AppendLine("ON e.CD_Unidade = h.CD_Unidade   ");
                sql.AppendLine("INNER JOIN TB_EST_Produto i ");
                sql.AppendLine("ON i.CD_Produto = e.CD_Produto   ");
                sql.AppendLine("INNER JOIN TB_EST_Unidade undest ");
                sql.AppendLine("ON i.cd_unidade = undest.cd_unidade ");
                sql.AppendLine("LEFT OUTER JOIN TB_FAT_NotaFiscal_CMI j ");
                sql.AppendLine("On a.CD_Empresa = j.CD_Empresa ");
                sql.AppendLine("and a.NR_LanctoFiscal = j.NR_LanctoFiscal ");
                sql.AppendLine("WHERE isnull(a.ST_Registro,'N') <> 'C'  ");

                string cond = "AND ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                sql.AppendLine("ORDER BY a.DT_Emissao ASC ");
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

            public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), vParametros);
            }
            
            public TRegistro_SaldoSinteticoPedido BuscaSaldoSintetico(string Nr_contrato, string CD_Produto)
            {
                DataTable estoque_fisico = this.ExecutarBusca(this.SqlCodeSaldoSintetico( new TpBusca[]
                    {
                        new TpBusca() { vNM_Campo = "d.NR_Contrato", vOperador = "=", vVL_Busca = Nr_contrato },
                        new TpBusca() { vNM_Campo = "e.CD_Produto", vOperador = "=", vVL_Busca = CD_Produto }
                    }
                    ), null);

                TRegistro_SaldoSinteticoPedido SaldoSinteticoPedido = new TRegistro_SaldoSinteticoPedido();

                if (estoque_fisico.Rows.Count > 0)
                {
                    //SALDO SINTETICO
                    SaldoSinteticoPedido.Qtd_E = Convert.ToDecimal(estoque_fisico.Rows[0]["Qtd_E"].ToString());
                    SaldoSinteticoPedido.Qtd_S = Convert.ToDecimal(estoque_fisico.Rows[0]["Qtd_S"].ToString());
                    SaldoSinteticoPedido.VL_Entrada_Est = Convert.ToDecimal(estoque_fisico.Rows[0]["VL_Ent_Estoq"].ToString());
                    SaldoSinteticoPedido.VL_Saida_Est = Convert.ToDecimal(estoque_fisico.Rows[0]["VL_Sai_Estoq"].ToString());
                    //SaldoSinteticoPedido.NR_Pedido = Convert.ToDecimal(estoque_fisico.Rows[0]["NR_Pedido"].ToString());
                }

                SaldoSinteticoPedido.NR_Contrato = decimal.Parse(Nr_contrato);
                return SaldoSinteticoPedido;
            }
            
            public TRegistro_SaldoSinteticoPedido BuscaSaldoFiscal(string Nr_contrato, string CD_Produto)
            {
                DataTable estoque_fisico = this.ExecutarBusca(this.SqlCodeSaldoFiscal(new TpBusca[]
                    {
                        new TpBusca() { vNM_Campo = "d.NR_Contrato", vOperador = "=", vVL_Busca = Nr_contrato },
                        new TpBusca() { vNM_Campo = "b.CD_Produto", vOperador = "=", vVL_Busca = CD_Produto }
                    }
                    ), null);

                TRegistro_SaldoSinteticoPedido SaldoSinteticoPedido = new TRegistro_SaldoSinteticoPedido();

                if (estoque_fisico.Rows.Count > 0)
                {
                    //SALDO FISCAL
                    SaldoSinteticoPedido.Quantidade_Fiscal_E = Convert.ToDecimal(estoque_fisico.Rows[0]["Quantidade_E"].ToString());
                    SaldoSinteticoPedido.Quantidade_Fiscal_S = Convert.ToDecimal(estoque_fisico.Rows[0]["Quantidade_S"].ToString());
                    SaldoSinteticoPedido.VL_SubTotal_Fiscal_E = Convert.ToDecimal(estoque_fisico.Rows[0]["VL_SubTotal_E"].ToString());
                    SaldoSinteticoPedido.VL_SubTotal_Fiscal_S = Convert.ToDecimal(estoque_fisico.Rows[0]["VL_SubTotal_S"].ToString());
                }

                SaldoSinteticoPedido.NR_Contrato = decimal.Parse(Nr_contrato);
                return SaldoSinteticoPedido;
            }

            public TRegistro_SaldoSinteticoPedido BuscaSaldoBalanca(string Nr_contrato, string CD_Produto)
            {
                DataTable estoque_fisico = this.ExecutarBusca(this.SqlCodeSaldoBalanca(new TpBusca[]
                    {
                        new TpBusca() { vNM_Campo = "a.NR_Contrato", vOperador = "=", vVL_Busca = Nr_contrato },
                        new TpBusca() { vNM_Campo = "a.CD_Produto", vOperador = "=", vVL_Busca = CD_Produto }
                    }
                    ), null);

                TRegistro_SaldoSinteticoPedido SaldoBalanca = new TRegistro_SaldoSinteticoPedido();

                if (estoque_fisico.Rows.Count > 0)
                {
                    //SALDO FISCAL
                    SaldoBalanca.Qtd_Estoque_E = Convert.ToDecimal(estoque_fisico.Rows[0]["Qtd_Estoque_E"].ToString());
                    SaldoBalanca.Qtd_Estoque_S = Convert.ToDecimal(estoque_fisico.Rows[0]["Qtd_Estoque_S"].ToString());
                    
                }

                SaldoBalanca.NR_Contrato = decimal.Parse(Nr_contrato);
                return SaldoBalanca;
            }

            public TList_LanctoEstoqueXPedido BuscaLanctoEstoqueXPedido(decimal Nr_Pedido, string CD_Produto, string CD_Empresa)
            {
                DataTable estoque_fisico = this.ExecutarBusca(this.SqlCodeLanctoEstoqueXPedido(new TpBusca[]
                    {
                        new TpBusca() { vNM_Campo = "a.NR_pedido", vOperador = "=", vVL_Busca = Nr_Pedido.ToString() },
                        new TpBusca() { vNM_Campo = "b.CD_Produto", vOperador = "=", vVL_Busca = CD_Produto },
                        new TpBusca() { vNM_Campo = "b.CD_Empresa", vOperador = "=", vVL_Busca = CD_Empresa }
                    }
                    ), null);

                TList_LanctoEstoqueXPedido List_LanctoEstoqueXPedido = new TList_LanctoEstoqueXPedido();

                for (int i = 0; i < estoque_fisico.Rows.Count; i++)
                {
                    TRegistro_LanctoEstoqueXPedido LanctoEstoqueXPedido = new TRegistro_LanctoEstoqueXPedido();
                    
                    LanctoEstoqueXPedido.id_LanctoEstoque = Convert.ToDecimal(estoque_fisico.Rows[i]["id_LanctoEstoque"].ToString());
                    LanctoEstoqueXPedido.CD_Produto = estoque_fisico.Rows[i]["CD_Produto"].ToString();
                    LanctoEstoqueXPedido.Dt_lancto_STR = estoque_fisico.Rows[i]["DT_Lancto"].ToString();
                    LanctoEstoqueXPedido.DS_Produto = estoque_fisico.Rows[i]["DS_Produto"].ToString();
                    LanctoEstoqueXPedido.CD_Empresa = estoque_fisico.Rows[i]["CD_Empresa"].ToString();
                    LanctoEstoqueXPedido.NM_Empresa = estoque_fisico.Rows[i]["NM_Empresa"].ToString();
                    LanctoEstoqueXPedido.QTD_Saida = Convert.ToDecimal(estoque_fisico.Rows[i]["QTD_Saida"].ToString());
                    LanctoEstoqueXPedido.VL_Unitario = Convert.ToDecimal(estoque_fisico.Rows[i]["VL_Unitario"].ToString());
                    LanctoEstoqueXPedido.VL_Subtotal = Convert.ToDecimal(estoque_fisico.Rows[i]["VL_Subtotal"].ToString());
                    LanctoEstoqueXPedido.Tp_lancto = estoque_fisico.Rows[i]["Tp_Lancto"].ToString();
                    LanctoEstoqueXPedido.DS_Observacao = estoque_fisico.Rows[i]["DS_Observacao"].ToString();
                    LanctoEstoqueXPedido.CD_Local = estoque_fisico.Rows[i]["CD_Local"].ToString();
                    LanctoEstoqueXPedido.DS_Local = estoque_fisico.Rows[i]["DS_Local"].ToString();
                    LanctoEstoqueXPedido.Tp_movimento = estoque_fisico.Rows[i]["TP_Movimento"].ToString();
                    LanctoEstoqueXPedido.QTD_Entrada = Convert.ToDecimal(estoque_fisico.Rows[i]["QTD_Entrada"].ToString());
                    LanctoEstoqueXPedido.NR_Pedido = Nr_Pedido;
                    List_LanctoEstoqueXPedido.Add(LanctoEstoqueXPedido);
                }

                return List_LanctoEstoqueXPedido;
            }

            public TList_NotaFiscalPedido BuscaNotasFiscaisPedido(decimal Nr_Pedido, string CD_Empresa, bool NotaMestra, string vTPMovimento)
            {
                TpBusca[] vBusca = new Utils.TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "e.NR_pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = Nr_Pedido.ToString();
                vBusca[vBusca.Length - 1].vOperador = "=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'"+CD_Empresa.Trim()+"'";
                vBusca[vBusca.Length - 1].vOperador = "=";
                if (NotaMestra)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "isnull(j.ST_Mestra, 'N')";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                if (vTPMovimento != "")
                {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTPMovimento + "'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                
                DataTable NotasFiscais = this.ExecutarBusca(this.SqlCodeNotasFiscais(vBusca), null);

                TList_NotaFiscalPedido List_NotaFiscalPedido = new TList_NotaFiscalPedido();

                for (int i = 0; i < NotasFiscais.Rows.Count; i++)
                {
                    TRegistro_NotaFiscalPedido NotaFiscalPedido = new TRegistro_NotaFiscalPedido();

                    NotaFiscalPedido.Nr_LanctoFiscal = Convert.ToDecimal(NotasFiscais.Rows[i]["Nr_LanctoFiscal"].ToString());
                    NotaFiscalPedido.Nr_NotaFiscal = Convert.ToDecimal(NotasFiscais.Rows[i]["Nr_NotaFiscal"].ToString());
                    NotaFiscalPedido.Tp_movimento = NotasFiscais.Rows[i]["Tp_Movimento"].ToString();
                    NotaFiscalPedido.CD_Empresa = NotasFiscais.Rows[i]["CD_Empresa"].ToString();
                    NotaFiscalPedido.Dt_Emissao_STR = NotasFiscais.Rows[i]["DT_Emissao"].ToString();
                    NotaFiscalPedido.Dt_SaiEnt_STR = NotasFiscais.Rows[i]["DT_SaiEnt"].ToString();
                    NotaFiscalPedido.Especie = NotasFiscais.Rows[i]["Especie"].ToString();
                    NotaFiscalPedido.Vl_TotalNota = Convert.ToDecimal(NotasFiscais.Rows[i]["Vl_TotalNota"].ToString());
                    NotaFiscalPedido.Nr_Serie = NotasFiscais.Rows[i]["Nr_Serie"].ToString();
                    NotaFiscalPedido.DS_SerieNf = NotasFiscais.Rows[i]["DS_SerieNf"].ToString();
                    NotaFiscalPedido.Nr_Pedido = Convert.ToDecimal(NotasFiscais.Rows[i]["Nr_Pedido"].ToString());
                    NotaFiscalPedido.CD_Clifor = NotasFiscais.Rows[i]["CD_Clifor"].ToString();
                    NotaFiscalPedido.Tp_nota = NotasFiscais.Rows[i]["Tp_Nota"].ToString();
                    NotaFiscalPedido.NM_Clifor = NotasFiscais.Rows[i]["NM_Clifor"].ToString();
                    NotaFiscalPedido.Quantidade = Convert.ToDecimal(NotasFiscais.Rows[i]["Quantidade"].ToString());
                    NotaFiscalPedido.CD_Unidade = NotasFiscais.Rows[i]["CD_Unidade"].ToString();
                    NotaFiscalPedido.CD_UnidEst = NotasFiscais.Rows[i]["CD_UnidEst"].ToString();
                    NotaFiscalPedido.CD_Produto = NotasFiscais.Rows[i]["CD_Produto"].ToString();
                    NotaFiscalPedido.DS_Local = NotasFiscais.Rows[i]["DS_Local"].ToString();
                    NotaFiscalPedido.DS_Produto = NotasFiscais.Rows[i]["DS_Produto"].ToString();
                    NotaFiscalPedido.DS_Unidade = NotasFiscais.Rows[i]["DS_Unidade"].ToString();
                    NotaFiscalPedido.Sigla_Unidade = NotasFiscais.Rows[i]["Sigla_Unidade"].ToString();
                    NotaFiscalPedido.sigla_unidade_estoque = NotasFiscais.Rows[i]["sigla_unidade_estoque"].ToString();
                    NotaFiscalPedido.VL_Unitario = Convert.ToDecimal(NotasFiscais.Rows[i]["VL_Unitario"].ToString());
                    NotaFiscalPedido.VL_SubTotal = Convert.ToDecimal(NotasFiscais.Rows[i]["VL_SubTotal"].ToString());
                    NotaFiscalPedido.QTD_Remessa = Convert.ToDecimal(NotasFiscais.Rows[i]["Qtd_remessa"].ToString());
                    NotaFiscalPedido.VL_Remessa = Convert.ToDecimal(NotasFiscais.Rows[i]["vl_remessa"].ToString());
                    NotaFiscalPedido.Qtd_origem = Convert.ToDecimal(NotasFiscais.Rows[i]["qtd_origem"].ToString());
                    NotaFiscalPedido.Vl_origem = Convert.ToDecimal(NotasFiscais.Rows[i]["vl_origem"].ToString());

                    if (NotaMestra)
                    {
                        NotaFiscalPedido.QTD_Disponivel = NotaFiscalPedido.Quantidade - NotaFiscalPedido.QTD_Remessa;
                        NotaFiscalPedido.VL_Disponivel = NotaFiscalPedido.VL_SubTotal - NotaFiscalPedido.VL_Remessa;
                    }

                    List_NotaFiscalPedido.Add(NotaFiscalPedido);
                }

                return List_NotaFiscalPedido;
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), vParametros);
            }

            public TList_PedidoAplicacao Select(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
            {
                TList_PedidoAplicacao lista = new TList_PedidoAplicacao();
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                    podeFecharBco = this.CriarBanco_Dados(false);
                SqlDataReader reader = this.ExecutarBuscaReader(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
                try
                {
                    while (reader.Read())
                    {
                        TRegistro_PedidoAplicacao reg = new TRegistro_PedidoAplicacao();
                        if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                            reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                        if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                            reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra1")))
                            reg.Cd_tipoamostra1 = reader.GetString(reader.GetOrdinal("cd_tipoamostra1"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_tipoamostra2")))
                            reg.Cd_tipoamostra2 = reader.GetString(reader.GetOrdinal("cd_tipoamostra2"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                            reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                            reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cd_clifor"))))
                            reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                        if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                            reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                            reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor")))
                            reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Clifor"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cd_endereco"))))
                            reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                        if(!reader.IsDBNull(reader.GetOrdinal("CD_UF_Clifor")))
                            reg.Cd_uf_clifor = reader.GetString(reader.GetOrdinal("CD_UF_Clifor"));
                        if (!reader.IsDBNull(reader.GetOrdinal("UF_Clifor")))
                            reg.Uf_clifor = reader.GetString(reader.GetOrdinal("UF_Clifor"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cd_produto"))))
                            reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_produto"))))
                            reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                            reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cd_unidade"))))
                            reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_unidade"))))
                            reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("sigla_unidade"))))
                            reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("cd_unidade_estoque"))))
                            reg.Cd_unidade_estoque = reader.GetString(reader.GetOrdinal("cd_unidade_estoque"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ds_unidade_estoque"))))
                            reg.Ds_unidade_estoque = reader.GetString(reader.GetOrdinal("ds_unidade_estoque"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("sigla_unidade_estoque"))))
                            reg.Sigla_unidade_estoque = reader.GetString(reader.GetOrdinal("sigla_unidade_estoque"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                            reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("tp_prodcontrato"))))
                            reg.Tp_prodcontrato = reader.GetString(reader.GetOrdinal("tp_prodcontrato"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                            reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                            reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                            reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("anosafra")))
                            reg.Anosafra = reader.GetString(reader.GetOrdinal("anosafra"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_safra")))
                            reg.Ds_safra = reader.GetString(reader.GetOrdinal("ds_safra"));
                        if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                            reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                            reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_confere_saldo")))
                            reg.St_confere_saldo = reader.GetString(reader.GetOrdinal("st_confere_saldo"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_deposito")))
                            reg.St_deposito = reader.GetString(reader.GetOrdinal("st_deposito"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_exigirautorizretirada")))
                            reg.St_exigirautorizretirada = reader.GetString(reader.GetOrdinal("st_exigirautorizretirada"));
                        if (!reader.IsDBNull(reader.GetOrdinal("st_valoresfixos")))
                            reg.St_valoresfixos = reader.GetString(reader.GetOrdinal("st_valoresfixos"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                            reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_bonificacao_fix")))
                            reg.Vl_bonificacao = reader.GetDecimal(reader.GetOrdinal("vl_bonificacao_fix"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ps_contratado")))
                            reg.Ps_contratado = reader.GetDecimal(reader.GetOrdinal("ps_contratado"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Ps_totalentrada")))
                            reg.Ps_totalentrada = reader.GetDecimal(reader.GetOrdinal("Ps_totalentrada"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Ps_totalsaida")))
                            reg.Ps_totalsaida = reader.GetDecimal(reader.GetOrdinal("Ps_totalsaida"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Ps_devolvido")))
                            reg.Ps_devolvido = reader.GetDecimal(reader.GetOrdinal("Ps_devolvido"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                            reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_UF_Empresa")))
                            reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("CD_UF_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("uf_empresa")))
                            reg.Uf_empresa = reader.GetString(reader.GetOrdinal("uf_empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                            reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                            reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tot_aplicado")))
                            reg.tot_aplicado = reader.GetDecimal(reader.GetOrdinal("tot_aplicado"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_retido_taxa")))
                            reg.vl_retido_taxa = reader.GetDecimal(reader.GetOrdinal("vl_retido_taxa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("vl_retido_taxafat")))
                            reg.vl_retido_taxafat = reader.GetDecimal(reader.GetOrdinal("vl_retido_taxafat"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ps_retido_taxa")))
                            reg.ps_retido_taxa = reader.GetDecimal(reader.GetOrdinal("ps_retido_taxa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ps_retido_taxafat")))
                            reg.ps_retido_taxafat = reader.GetDecimal(reader.GetOrdinal("ps_retido_taxafat"));
                        if (!reader.IsDBNull(reader.GetOrdinal("PS_Fixado")))
                            reg.Ps_fixado = reader.GetDecimal(reader.GetOrdinal("PS_Fixado"));
                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transferencia_Entrada")))
                            reg.Qtd_Entrada_Transferencia = reader.GetDecimal(reader.GetOrdinal("QTD_Transferencia_Entrada"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Qtd_Transferencia_Saida")))
                            reg.Qtd_Saida_Transferencia = reader.GetDecimal(reader.GetOrdinal("Qtd_Transferencia_Saida"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Vl_Fixado")))
                            reg.Vl_fixado = reader.GetDecimal(reader.GetOrdinal("Vl_Fixado"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                            reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                            reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Vl_CreditoGMO")))
                            reg.Vl_CreditoGMO = reader.GetDecimal(reader.GetOrdinal("vl_creditogmo"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                            reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda")))
                            reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Moeda")))
                            reg.Sigla_moeda = reader.GetString(reader.GetOrdinal("Sigla_Moeda"));
                        
                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_DEBITOGMO_T")))
                            reg.QTD_DEBITOGMO_T = reader.GetDecimal(reader.GetOrdinal("QTD_DEBITOGMO_T"));

                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_DEBITOGMO_D")))
                            reg.QTD_DEBITOGMO_D = reader.GetDecimal(reader.GetOrdinal("QTD_DEBITOGMO_D"));

                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_CREDITOGMO_D")))
                            reg.QTD_CREDITO_GMO_D = reader.GetDecimal(reader.GetOrdinal("QTD_CREDITOGMO_D"));
                        if (!reader.IsDBNull(reader.GetOrdinal("QTD_CREDITOGMO_T")))
                            reg.QTD_CREDITO_GMO_T = reader.GetDecimal(reader.GetOrdinal("QTD_CREDITOGMO_T"));
                        
                        //CALCULA OS DADOS DA ENTREGAR
                        reg.Qtd_Entregar = (reg.Ps_contratado * (reg.Tp_movimento.Equals("E") ? +1 : -1) - (reg.Ps_totalentrada - reg.Ps_totalsaida));

                        reg.QTD_SALDO_GMO_D = ( reg.QTD_DEBITOGMO_D - reg.QTD_CREDITO_GMO_D );
                        if (reg.QTD_SALDO_GMO_D <= decimal.Zero)
                            reg.QTD_SALDO_GMO_D = decimal.Zero;

                        reg.QTD_SALDO_GMO_T = ( reg.QTD_DEBITOGMO_T - reg.QTD_CREDITO_GMO_T);
                        if (reg.QTD_SALDO_GMO_T <= decimal.Zero)
                            reg.QTD_SALDO_GMO_T = decimal.Zero;

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
        }

    #endregion
    
    #region Aplicação Pedido
    public class TList_LanAplicacaoPedido : List<TRegistro_LanAplicacaoPedido>, IComparer<TRegistro_LanAplicacaoPedido>
    {
        #region IComparer<TRegistro_LanAplicacaoPedido> Members
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

        public TList_LanAplicacaoPedido()
        { }

        public TList_LanAplicacaoPedido(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanAplicacaoPedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanAplicacaoPedido x, TRegistro_LanAplicacaoPedido y)
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
    
    public class TRegistro_LanAplicacaoPedido
    {
        private decimal? id_aplicacao;
        public decimal? Id_aplicacao
        {
            get { return id_aplicacao; }
            set
            {
                id_aplicacao = value;
                id_aplicacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_aplicacaostr;
        public string Id_aplicacaostr
        {
            get { return id_aplicacaostr; }
            set
            {
                id_aplicacaostr = value;
                try
                {
                    id_aplicacao = decimal.Parse(value);
                }
                catch
                { id_aplicacao = null; }
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
                catch
                { nr_pedido = null; }
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
                catch
                { id_pedidoitem = null; }
            }
        }
        public string Cd_unidestoque
        {
            get;
            set;
        }
        public string Ds_unidestoque
        { get; set; }
        public string Sigla_unidestoque
        { get; set; }
        public string Cd_unidade
        {
            get;
            set;
        }
        public string Sigla_unidade
        { get; set; }
        public string Cd_produto
        {
            get;
            set;
        }
        public string Ds_produto
        {
            get;
            set;
        }
        public string Cd_empresa
        {
            get;
            set;
        }
        public string Nm_empresa
        {
            get;
            set;
        }
        public decimal Id_lanctoestoque
        {
            get;
            set;
        }
        public decimal Id_ticket
        {
            get;
            set;
        }
        public string Tp_pesagem
        {
            get;
            set;
        }
        public decimal Qtd_aplicado
        {
            get;
            set;
        }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        {
            get;
            set;
        }
        private decimal? id_autoriz;
        public decimal? Id_autoriz
        {
            get { return id_autoriz; }
            set
            {
                id_autoriz = value;
                id_autorizstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_autorizstr;
        public string Id_autorizstr
        {
            get { return id_autorizstr; }
            set
            {
                id_autorizstr = value;
                try
                {
                    id_autoriz = Convert.ToDecimal(value);
                }
                catch
                { id_autoriz = null; }
            }
        }
        public decimal Vl_taxasecagem
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
                if (value.ToUpper().Trim().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.ToUpper().Trim().Equals("S"))
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
                if (value.ToUpper().Trim().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.ToUpper().Trim().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        public string Tp_movimento_pedido
        { get; set; }
        public string Uf_empresa
        {
            get;
            set;
        }
        public string Cd_condpgto
        { get; set; }
        public bool St_notaunica
        { get; set; }
        public bool St_confere_saldo
        { get; set; }
        public bool St_valores_fixos
        { get; set; }
        //Atributos do Desdobro
        public decimal? Nr_contrato
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nome_clifor
        { get; set; }
        public string Tp_pessoa
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Nr_notaprodutor
        { get; set; }
        public DateTime? Dt_emissaonfprodutor
        { get; set; }
        public decimal Qt_nfprodutor
        { get; set; }
        public decimal Vl_nfprodutor
        { get; set; }
        public decimal Nr_notafiscalaplic
        { get; set; }
        public decimal Nr_lanctofiscalaplic
        { get; set; }
        public string Nr_serieaplic
        { get; set; }
        public DateTime? Dt_emissaoaplic
        { get; set; }
        public bool St_desaplicar
        { get; set; }

        public TRegistro_LanAplicacaoPedido()
        {
            this.Cd_condpgto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Cd_unidestoque = string.Empty;
            this.Ds_produto = string.Empty;
            this.Ds_unidestoque = string.Empty;
            this.Id_aplicacao = decimal.Zero;
            this.id_autoriz = null;
            this.id_autorizstr = string.Empty;
            this.Id_lanctoestoque = decimal.Zero;
            this.Id_pedidoitem = decimal.Zero;
            this.Id_ticket = decimal.Zero;
            this.Nm_empresa = string.Empty;
            this.Nr_lanctofiscalaplic = decimal.Zero;
            this.Nr_notafiscalaplic = decimal.Zero;
            this.Nr_pedido = decimal.Zero;
            this.Qtd_aplicado = decimal.Zero;
            this.Sigla_unidade = string.Empty;
            this.Sigla_unidestoque = string.Empty;
            this.St_confere_saldo = false;
            this.St_desaplicar = false;
            this.St_notaunica = false;
            this.St_valores_fixos = false;
            this.tipo_movimento = string.Empty;
            this.tp_movimento = string.Empty;
            this.Tp_movimento_pedido = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.Uf_empresa = string.Empty;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_taxasecagem = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Nr_contrato = null;
            this.Cd_clifor = string.Empty;
            this.Nome_clifor = string.Empty;
            this.Tp_pessoa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Nr_notaprodutor = string.Empty;
            this.Dt_emissaonfprodutor = null;
            this.Qt_nfprodutor = decimal.Zero;
            this.Vl_nfprodutor = decimal.Zero;
            this.Nr_notafiscalaplic = decimal.Zero;
            this.Nr_lanctofiscalaplic = decimal.Zero;
            this.Nr_serieaplic = string.Empty;
            this.Dt_emissaoaplic = null;
        }
    }

    public class TCD_LanAplicacaoPedido : TDataQuery
    {
        public TCD_LanAplicacaoPedido()
        { }

        public TCD_LanAplicacaoPedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, f.nm_empresa, a.id_ticket, ");
                sql.AppendLine("i.NR_NotaProdutor, i.DT_EmissaoNFProdutor, i.QT_NFProdutor, ");
                sql.AppendLine("i.VL_NFProdutor, a.id_pedidoitem, nf.cd_clifor, a.tp_pesagem, ");
                sql.AppendLine("c.nm_clifor, c.tp_pessoa, en.cd_endereco, i.nr_contrato, ");
                sql.AppendLine("a.vl_unitario, a.vl_subtotal, a.id_aplicacao, a.nr_pedido, ");
                sql.AppendLine("a.cd_produto, g.ds_produto, a.id_lanctoestoque, a.qtd_aplicado, ");
                sql.AppendLine("g.cd_unidade as cd_unidade_estoque, h.ds_unidade as ds_unidade_estoque, ");
                sql.AppendLine("h.sigla_unidade as sigla_unidade_estoque, a.vl_taxasecagem, a.id_autoriz, ");
                sql.AppendLine("nf.nr_serie, nf.dt_emissao, ");
                sql.AppendLine("nf.nr_notafiscal as nr_notafiscalaplic, ");
                sql.AppendLine("nf.nr_lanctofiscal as nr_lanctofiscalaplic ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            //Aplicacao
            sql.AppendLine("from tb_bal_aplicacao_pedido a ");
            //Nota Fiscal Aplicacao
            sql.AppendLine("inner join TB_FAT_Aplicacao_X_NotaFiscal ap ");
            sql.AppendLine("on ap.id_aplicacao = a.id_aplicacao ");
            //Nota Fiscal
            sql.AppendLine("inner join TB_Fat_Notafiscal nf ");
            sql.AppendLine("on nf.cd_empresa = ap.cd_empresa ");
            sql.AppendLine("and nf.nr_lanctofiscal = ap.nr_lanctofiscal ");
            //Clifor da Nota Fiscal
            sql.AppendLine("inner join vtb_fin_clifor c ");
            sql.AppendLine("on c.cd_clifor = nf.cd_clifor ");
            //Endereco Clifor Nota
            sql.AppendLine("inner join vtb_fin_endereco en ");
            sql.AppendLine("on en.cd_clifor = nf.cd_clifor ");
            sql.AppendLine("and en.cd_endereco = nf.cd_endereco ");
            //Empresa da Pesagem
            sql.AppendLine("inner join tb_div_empresa f ");
            sql.AppendLine("on a.cd_empresa = f.cd_empresa ");
            //Produto da Aplicacao
            sql.AppendLine("inner join tb_est_produto g ");
            sql.AppendLine("on a.cd_produto = g.cd_produto ");
            //Unidade do Produto
            sql.AppendLine("inner join tb_est_unidade h ");
            sql.AppendLine("on g.cd_unidade = h.cd_unidade ");
            //Pesagem Aplicada
            sql.AppendLine("inner join VTB_BAL_PsGraos i ");
            sql.AppendLine("on a.cd_empresa = i.cd_empresa ");
            sql.AppendLine("and a.tp_pesagem = i.tp_pesagem ");
            sql.AppendLine("and a.id_ticket = i.id_ticket ");
            //Pesagem nao pode estar cancelada
            sql.AppendLine("where isnull(i.st_registro, 'A') <> 'C' ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine(" Group By " + vGroup);
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" Order By " + vOrder);

            return sql.ToString();
        }
        
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public TList_LanAplicacaoPedido Select(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            TList_LanAplicacaoPedido lista = new TList_LanAplicacaoPedido();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAplicacaoPedido reg = new TRegistro_LanAplicacaoPedido();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Aplicacao")))
                        reg.Id_aplicacao = reader.GetDecimal(reader.GetOrdinal("ID_Aplicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem"))))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque"))))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Aplicado"))))
                        reg.Qtd_aplicado = reader.GetDecimal(reader.GetOrdinal("QTD_Aplicado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Autoriz"))))
                        reg.Id_autoriz = reader.GetDecimal(reader.GetOrdinal("ID_Autoriz"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_TaxaSecagem"))))
                        reg.Vl_taxasecagem = reader.GetDecimal(reader.GetOrdinal("Vl_TaxaSecagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade_estoque")))
                        reg.Cd_unidestoque = reader.GetString(reader.GetOrdinal("cd_unidade_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade_estoque")))
                        reg.Ds_unidestoque = reader.GetString(reader.GetOrdinal("ds_unidade_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade_estoque")))
                        reg.Sigla_unidestoque = reader.GetString(reader.GetOrdinal("sigla_unidade_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nome_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaProdutor")))
                        reg.Nr_notaprodutor = reader.GetString(reader.GetOrdinal("NR_NotaProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EmissaoNFProdutor")))
                        reg.Dt_emissaonfprodutor = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoNFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_NFProdutor")))
                        reg.Qt_nfprodutor = reader.GetDecimal(reader.GetOrdinal("QT_NFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_NFProdutor")))
                        reg.Vl_nfprodutor = reader.GetDecimal(reader.GetOrdinal("VL_NFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscalaplic")))
                        reg.Nr_notafiscalaplic = reader.GetDecimal(reader.GetOrdinal("nr_notafiscalaplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscalaplic")))
                        reg.Nr_lanctofiscalaplic = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscalaplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serieaplic = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_emissao")))
                        reg.Dt_emissaoaplic = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));

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

        public string Gravar(TRegistro_LanAplicacaoPedido val)
        {
            Hashtable hs = new Hashtable(14);
            hs.Add("@P_ID_APLICACAO", val.Id_aplicacao);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_QTD_APLICADO", val.Qtd_aplicado);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_ID_AUTORIZ", val.Id_autoriz);
            hs.Add("@P_VL_TAXASECAGEM", val.Vl_taxasecagem);

            return executarProc("IA_BAL_APLICACAO_PEDIDO", hs);
        }

        public string Excluir(TRegistro_LanAplicacaoPedido val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_APLICACAO", val.Id_aplicacao);

            return this.executarProc("EXCLUI_BAL_APLICACAO_PEDIDO", hs);
        }
    }
    #endregion
}
