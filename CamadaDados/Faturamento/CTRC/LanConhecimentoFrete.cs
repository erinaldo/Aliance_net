using CamadaDados.Estoque;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Fiscal;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_ConhecimentoFrete : List<TRegistro_ConhecimentoFrete>, IComparer<TRegistro_ConhecimentoFrete>
    {
        #region IComparer<TRegistro_ConhecimentoFrete> Members
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

        public TList_ConhecimentoFrete()
        { }

        public TList_ConhecimentoFrete(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ConhecimentoFrete value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ConhecimentoFrete x, TRegistro_ConhecimentoFrete y)
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

    public class TRegistro_ConhecimentoFrete
    {

        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Nr_lanctoCTRC
        { get; set; }
        private decimal? nr_lanctoCTRAnulado;
        public decimal? Nr_lanctoCTRAnulado
        {
            get { return nr_lanctoCTRAnulado; }
            set
            {
                nr_lanctoCTRAnulado = value;
                nr_lanctoCTRAnuladostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoCTRAnuladostr;
        public string Nr_lanctoCTRAnuladostr
        {
            get { return nr_lanctoCTRAnuladostr; }
            set
            {
                nr_lanctoCTRAnuladostr = value;
                try
                {
                    nr_lanctoCTRAnulado = decimal.Parse(value);
                }
                catch { nr_lanctoCTRAnulado = null; }
            }
        }
        public string Chave_acessoCTRAnulado
        { get; set; }
        private decimal? nr_lanctoCTRComplementado;
        public decimal? Nr_lanctoCTRComplementado
        {
            get { return nr_lanctoCTRComplementado; }
            set
            {
                nr_lanctoCTRComplementado = value;
                nr_lanctoCTRComplementadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoCTRComplementadostr;
        public string Nr_lanctoCTRComplementadostr
        {
            get { return nr_lanctoCTRComplementadostr; }
            set
            {
                nr_lanctoCTRComplementadostr = value;
                try
                {
                    nr_lanctoCTRComplementado = decimal.Parse(value);
                }
                catch { nr_lanctoCTRComplementado = null; }
            }
        }
        public string Chave_acessoCTRRef
        { get; set; }
        public string Cd_cliforCTeRef
        { get; set; }
        public string Nm_cliforCTeRef
        { get; set; }
        public string Cnpj_cliforCTeRef
        { get; set; }
        public string CH_AcessoNFeTom
        { get; set; }
        private decimal? nr_ctrc;
        public decimal? Nr_ctrc
        {
            get { return nr_ctrc; }
            set
            {
                nr_ctrc = value;
                nr_ctrcstr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_ctrcstr;
        public string Nr_ctrcstr
        {
            get { return nr_ctrcstr; }
            set
            {
                nr_ctrcstr = value;
                try
                {
                    nr_ctrc = Convert.ToDecimal(value);
                }
                catch
                { nr_ctrc = null; }
            }
        }
        public string Cd_transportadora
        { get; set; }
        public string Nm_transportadora
        { get; set; }
        public string Cnpj_transp
        { get; set; }
        public string Rntrc
        { get; set; }
        public string Insc_estadual_transp
        { get; set; }
        public string Cd_condfiscal_transportadora
        { get; set; }
        public string Tp_pessoa_transportadora
        { get; set; }
        public string Cd_endtransportadora
        { get; set; }
        public string Ds_endtransportadora
        { get; set; }
        public string Cd_uf_transportadora
        { get; set; }
        public string Uf_transportadora
        { get; set; }
        public string Cd_remetente
        { get; set; }
        public string Nm_remetente
        { get; set; }
        public string Cnpj_remetente
        { get; set; }
        public string Cd_condfiscal_remetente
        { get; set; }
        public string Cd_endremetente
        { get; set; }
        public string Ds_endremetente
        { get; set; }
        public string Numeroremetente
        { get; set; }
        public string Ds_cidaderemetente
        { get; set; }
        public string Cd_uf_remetente
        { get; set; }
        public string Uf_remetente
        { get; set; }
        public string Cd_destinatario
        { get; set; }
        public string Nm_destinatario
        { get; set; }
        public string Cnpj_destinatario
        { get; set; }
        public string Cd_condfiscal_destinatario
        { get; set; }
        public string Cd_enddestinatario
        { get; set; }
        public string Ds_enddestinatario
        { get; set; }
        public string Numerodestinatario
        { get; set; }
        public string Ds_cidadedestinatario
        { get; set; }
        public string Cd_uf_destinatario
        { get; set; }
        public string Uf_destinatario
        { get; set; }
        public string Cd_expedidor
        { get; set; }
        public string Nm_expedidor
        { get; set; }
        public string Cnpj_expedidor
        { get; set; }
        public string Cd_condfiscal_expedidor
        { get; set; }
        public string Cd_endexpedidor
        { get; set; }
        public string Ds_endexpedidor
        { get; set; }
        public string Ds_cidadeexpedidor
        { get; set; }
        public string Cd_uf_expedidor
        { get; set; }
        public string Uf_expedidor
        { get; set; }
        public string Cd_recebedor
        { get; set; }
        public string Nm_recebedor
        { get; set; }
        public string Cnpj_recebedor
        { get; set; }
        public string Cd_condfiscal_recebedor
        { get; set; }
        public string Cd_endrecebedor
        { get; set; }
        public string Ds_endrecebedor
        { get; set; }
        public string Ds_cidaderecebedor
        { get; set; }
        public string Cd_uf_recebedor
        { get; set; }
        public string Uf_recebedor
        { get; set; }
        public string Cd_tomador
        { get; set; }
        public string Nm_tomador
        { get; set; }
        public string Cnpj_tomador
        { get; set; }
        public string Cd_condfiscal_tomador
        { get; set; }
        public string Cd_endtomador
        { get; set; }
        public string Ds_endtomador
        { get; set; }
        public string Ds_cidadetomador
        { get; set; }
        public string Cd_uf_tomador
        { get; set; }
        public string Uf_tomador
        { get; set; }
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_movimentacaostr;
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = Convert.ToDecimal(value);
                }
                catch
                { cd_movimentacao = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public string Ds_cfop
        { get; set; }
        private decimal? cd_cmi;
        public decimal? Cd_cmi
        {
            get { return cd_cmi; }
            set
            {
                cd_cmi = value;
                cd_cmistr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_cmistr;
        public string Cd_cmistr
        {
            get { return cd_cmistr; }
            set
            {
                cd_cmistr = value;
                try
                {
                    cd_cmi = Convert.ToDecimal(value);
                }
                catch
                { cd_cmi = null; }
            }
        }
        public string Ds_cmi
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Ds_serienf
        { get; set; }
        public string Cd_modelo
        { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
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
        private DateTime? dt_saient;
        public DateTime? Dt_saient
        {
            get { return dt_saient; }
            set
            {
                dt_saient = value;
                dt_saientstr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_saientstr;
        public string Dt_saientstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_saientstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_saientstr = value;
                try
                {
                    dt_saient = Convert.ToDateTime(value);
                }
                catch
                { dt_saient = null; }
            }
        }
        private DateTime? dt_recebimento;
        public DateTime? Dt_recebimento
        {
            get { return dt_recebimento; }
            set
            {
                dt_recebimento = value;
                dt_recebimentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_recebimentostr;
        public string Dt_recebimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_recebimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_recebimentostr = value;
                try
                {
                    dt_recebimento = Convert.ToDateTime(value);
                }
                catch { dt_recebimento = null; }
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
        public string Ds_observacoes
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_icmssomar
        { get; set; }
        public decimal Vl_receber
        { get; set; }
        public string Chaveacesso
        { get; set; }
        private string tp_emissao;
        public string Tp_emissao
        {
            get { return tp_emissao; }
            set
            {
                tp_emissao = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_emissao = "PROPRIO";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_emissao = "TERCEIRO";
            }
        }
        private string tipo_emissao;
        public string Tipo_emissao
        {
            get { return tipo_emissao; }
            set
            {
                tipo_emissao = value;
                if (value.Trim().ToUpper().Equals("PROPRIO"))
                    tp_emissao = "P";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_emissao = "T";
            }
        }
        public decimal Vl_baseICMS
        { get; set; }
        public decimal Vl_basecalcPIS
        { get; set; }
        public decimal Vl_basecalcCOFINS
        { get; set; }
        public decimal Pc_aliquotaICMS
        { get; set; }
        public decimal Pc_aliquotaICMSDest
        { get; set; }
        public decimal Vl_difal
        { get; set; }
        public decimal PC_ReducaoBaseCalc
        { get; set; }
        public decimal Pc_aliquotaPIS
        { get; set; }
        public decimal Pc_aliquotaCOFINS
        { get; set; }
        public decimal Vl_ICMS
        { get; set; }
        public decimal Vl_PIS
        { get; set; }
        public decimal Vl_COFINS
        { get; set; }
        public string Tp_situacao
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_stPIS
        { get; set; }
        public string Cd_stCOFINS
        { get; set; }
        public decimal Vl_comissao
        { get; set; }
        public decimal? Id_loteCTB { get; set; } = null;
        public bool St_processar
        { get; set; }
        //Campos CTe
        private string tp_cte;
        public string Tp_cte
        {
            get { return tp_cte; }
            set
            {
                tp_cte = value;
                if (value.Trim().Equals("0"))
                    tipo_cte = "NORMAL";
                else if (value.Trim().Equals("1"))
                    tipo_cte = "COMPLEMENTO DE VALORES";
                else if (value.Trim().Equals("2"))
                    tipo_cte = "ANULAÇÃO DE VALORES";
                else if (value.Trim().Equals("3"))
                    tipo_cte = "SUBSTITUTO";
            }
        }
        private string tipo_cte;
        public string Tipo_cte
        {
            get { return tipo_cte; }
            set
            {
                tipo_cte = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_cte = "0";
                else if (value.Trim().ToUpper().Equals("COMPLEMENTO DE VALORES"))
                    tp_cte = "1";
                else if (value.Trim().ToUpper().Equals("ANULAÇÃO DE VALORES"))
                    tp_cte = "2";
                else if (value.Trim().ToUpper().Equals("SUBSTITUTO"))
                    tp_cte = "3";
            }
        }
        private string tp_modalidade;
        public string Tp_modalidade
        {
            get { return tp_modalidade; }
            set
            {
                tp_modalidade = value;
                if (value.Trim().Equals("01"))
                    tipo_modalidade = "RODOVIARIO";
                else if (value.Trim().Equals("02"))
                    tipo_modalidade = "AEREO";
                else if (value.Trim().Equals("03"))
                    tipo_modalidade = "AQUAVIARIO";
                else if (value.Trim().Equals("04"))
                    tipo_modalidade = "FERROVIARIO";
                else if (value.Trim().Equals("05"))
                    tipo_modalidade = "DUTOVIARIO";
            }
        }
        private string tipo_modalidade;
        public string Tipo_modalidade
        {
            get { return tipo_modalidade; }
            set
            {
                tipo_modalidade = value;
                if (value.Trim().ToUpper().Equals("RODOVIARIO"))
                    tp_modalidade = "01";
                else if (value.Trim().ToUpper().Equals("AEREO"))
                    tp_modalidade = "02";
                else if (value.Trim().ToUpper().Equals("AQUAVIARIO"))
                    tp_modalidade = "03";
                else if (value.Trim().ToUpper().Equals("FERROVIARIO"))
                    tp_modalidade = "04";
                else if (value.Trim().ToUpper().Equals("DUTOVIARIO"))
                    tp_modalidade = "05";
            }
        }
        private string tp_servico;
        public string Tp_servico
        {
            get { return tp_servico; }
            set
            {
                tp_servico = value;
                if (value.Trim().Equals("0"))
                    tipo_servico = "NORMAL";
                else if (value.Trim().Equals("1"))
                    tipo_servico = "SUBCONTRATAÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_servico = "REDESPACHO";
                else if (value.Trim().Equals("3"))
                    tipo_servico = "REDESPACHO INTERMEDIARIO";
            }
        }
        private string tipo_servico;
        public string Tipo_servico
        {
            get { return tipo_servico; }
            set
            {
                tipo_servico = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_servico = "0";
                else if (value.Trim().ToUpper().Equals("SUBCONTRATAÇÃO"))
                    tp_servico = "1";
                else if (value.Trim().ToUpper().Equals("REDESPACHO"))
                    tp_servico = "2";
                else if (value.Trim().ToUpper().Equals("REDESPACHO INTERMEDIARIO"))
                    tp_servico = "3";
            }
        }
        public string Cd_cidade_ini
        { get; set; }
        public string Ds_cidade_ini
        { get; set; }
        public string Cd_uf_ini
        { get; set; }
        public string Uf_ini
        { get; set; }
        public string Cd_cidade_fin
        { get; set; }
        public string Ds_cidade_fin
        { get; set; }
        public string Cd_uf_fin
        { get; set; }
        public string Uf_fin
        { get; set; }
        private string st_recebedorretira;
        public string St_receberretira
        {
            get { return st_recebedorretira; }
            set
            {
                st_recebedorretira = value;
                st_recebedorretirabool = value.Trim().Equals("0");
            }
        }
        private bool st_recebedorretirabool;
        public bool St_receberretirabool
        {
            get { return st_recebedorretirabool; }
            set
            {
                st_recebedorretirabool = value;
                st_recebedorretira = value ? "0" : "1";
            }
        }
        public string Ds_retira
        { get; set; }
        private string tp_tomador;
        public string Tp_tomador
        {
            get { return tp_tomador; }
            set
            {
                tp_tomador = value;
                if (value.Trim().Equals("0"))
                    tipo_tomador = "REMETENTE";
                else if (value.Trim().Equals("1"))
                    tipo_tomador = "EXPEDIDOR";
                else if (value.Trim().Equals("2"))
                    tipo_tomador = "RECEBEDOR";
                else if (value.Trim().Equals("3"))
                    tipo_tomador = "DESTINATARIO";
                else if (value.Trim().Equals("4"))
                    tipo_tomador = "OUTROS";
            }
        }
        private string tipo_tomador;
        public string Tipo_tomador
        {
            get { return tipo_tomador; }
            set
            {
                tipo_tomador = value;
                if (value.Trim().ToUpper().Equals("REMETENTE"))
                    tp_tomador = "0";
                else if (value.Trim().ToUpper().Equals("EXPEDIDOR"))
                    tp_tomador = "1";
                else if (value.Trim().ToUpper().Equals("RECEBEDOR"))
                    tp_tomador = "2";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_tomador = "3";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_tomador = "4";
            }
        }
        public decimal Vl_carga
        { get; set; }
        public string Ds_prodpredominante
        { get; set; }
        public string OutrasCaracCarga
        { get; set; }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch { id_viagem = null; }
            }
        }
        private decimal? id_mudanca;
        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;
        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = decimal.Parse(value);
                }
                catch
                { id_mudanca = null; }

            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_motorista { get; set; } = string.Empty;
        public string Nm_motorista { get; set; } = string.Empty;
        private decimal? id_veiculo = null;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr = string.Empty;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch { id_veiculo = null; }
            }
        }
        public string Ds_veiculo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Obsfiscal
        { get; set; }
        public string Xml_cte
        { get; set; }
        public decimal? Status_cte
        { get; set; }
        public string Msg_status
        { get; set; }
        public decimal? Nr_protocolo
        { get; set; }
        public bool St_anulado
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                {
                    if (Status_cte != null)
                    {
                        if (St_anulado)
                            status = "ANULADO";
                        else if (Status_cte.Value.Equals(100))
                            status = "TRANSMITIDO";
                        else
                            status = "ATIVO";
                    }
                }
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO") || value.Trim().ToUpper().Equals("TRANSMITIDO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    status = "C";
            }
        }
        public decimal Pc_impAprox
        { get; set; }
        public decimal Vl_impAprox
        { get { return Math.Round(decimal.Divide(decimal.Multiply(Vl_frete, Pc_impAprox), 100), 2); } }
        public string digVal { get; set; } = string.Empty;
        public TList_CTRNotaFiscal lNfCTe
        { get; set; }
        public TList_CTRNotaFiscal lNfCTeDel
        { get; set; }
        public TList_EventoCTe lEvento
        { get; set; }
        public TList_CTRCompValorFrete lCompValorFrete
        { get; set; }
        public TList_CTRCompValorFrete lCompValorFreteDel
        { get; set; }
        public TList_CTRQtdeCarga lQtdeCarga
        { get; set; }
        public TList_CTRQtdeCarga lQtdeCargaDel
        { get; set; }
        public TList_CTROrdemColeta lOrdemColeta
        { get; set; }
        public TList_CTROrdemColeta lOrdemColetadel
        { get; set; }
        public TList_RegLanFaturamento lNf
        { get; set; }
        public TList_RegLanFaturamento lNfDel
        { get; set; }
        public TRegistro_LanDuplicata rDuplicata
        { get; set; }
        public TList_RegLanParcela lParcelas
        { get; set; }
        public TList_RegLanEstoque lEstoque
        { get; set; }
        public TRegistro_CadCMI rCmi
        { get; set; }
        public TList_ImpostosNF lImpostos
        { get; set; }
        public TList_ImpostosNF lImpDel
        { get; set; }


        public TRegistro_ConhecimentoFrete()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_lanctoCTRC = null;
            nr_lanctoCTRAnulado = null;
            nr_lanctoCTRAnuladostr = string.Empty;
            Chave_acessoCTRAnulado = string.Empty;
            nr_lanctoCTRComplementado = null;
            nr_lanctoCTRComplementadostr = string.Empty;
            Chave_acessoCTRRef = string.Empty;
            Cd_cliforCTeRef = string.Empty;
            Nm_cliforCTeRef = string.Empty;
            Cnpj_cliforCTeRef = string.Empty;
            nr_ctrc = null;
            nr_ctrcstr = string.Empty;
            Cd_transportadora = string.Empty;
            Nm_transportadora = string.Empty;
            Rntrc = string.Empty;
            Cd_condfiscal_transportadora = string.Empty;
            Tp_pessoa_transportadora = string.Empty;
            Cd_endtransportadora = string.Empty;
            Ds_endtransportadora = string.Empty;
            Cd_uf_transportadora = string.Empty;
            Uf_transportadora = string.Empty;
            Cd_remetente = string.Empty;
            Nm_remetente = string.Empty;
            Cnpj_remetente = string.Empty;
            Cd_condfiscal_remetente = string.Empty;
            Cd_endremetente = string.Empty;
            Ds_endremetente = string.Empty;
            Numeroremetente = string.Empty;
            Ds_cidaderemetente = string.Empty;
            Cd_uf_remetente = string.Empty;
            Uf_remetente = string.Empty;
            Cd_destinatario = string.Empty;
            Nm_destinatario = string.Empty;
            Cnpj_destinatario = string.Empty;
            Cd_condfiscal_destinatario = string.Empty;
            Cd_enddestinatario = string.Empty;
            Numerodestinatario = string.Empty;
            Ds_enddestinatario = string.Empty;
            Ds_cidadedestinatario = string.Empty;
            Cd_uf_destinatario = string.Empty;
            Uf_destinatario = string.Empty;
            Cd_expedidor = string.Empty;
            Nm_expedidor = string.Empty;
            Cnpj_expedidor = string.Empty;
            Cd_condfiscal_expedidor = string.Empty;
            Cd_endexpedidor = string.Empty;
            Ds_endexpedidor = string.Empty;
            Ds_cidadeexpedidor = string.Empty;
            Cd_uf_expedidor = string.Empty;
            Uf_expedidor = string.Empty;
            Cd_recebedor = string.Empty;
            Nm_recebedor = string.Empty;
            Cnpj_recebedor = string.Empty;
            Cd_condfiscal_recebedor = string.Empty;
            Cd_endrecebedor = string.Empty;
            Ds_endrecebedor = string.Empty;
            Ds_cidaderecebedor = string.Empty;
            Cd_uf_recebedor = string.Empty;
            Uf_recebedor = string.Empty;
            Cd_tomador = string.Empty;
            Nm_tomador = string.Empty;
            Cnpj_tomador = string.Empty;
            Cd_condfiscal_tomador = string.Empty;
            Cd_endtomador = string.Empty;
            Ds_endtomador = string.Empty;
            Ds_cidadetomador = string.Empty;
            Cd_uf_tomador = string.Empty;
            Uf_tomador = string.Empty;
            cd_movimentacao = null;
            cd_movimentacaostr = string.Empty;
            Ds_movimentacao = string.Empty;
            Cd_cfop = string.Empty;
            Ds_cfop = string.Empty;
            cd_cmi = null;
            cd_cmistr = string.Empty;
            Ds_cmi = string.Empty;
            Nr_serie = string.Empty;
            Ds_serienf = string.Empty;
            Cd_modelo = string.Empty;
            dt_emissao = DateTime.Now;
            dt_emissaostr = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dt_saient = null;
            dt_saientstr = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            Ds_observacoes = string.Empty;
            Vl_frete = decimal.Zero;
            Vl_icmssomar = decimal.Zero;
            Vl_comissao = decimal.Zero;
            st_registro = "A";
            status = "ATIVO";
            Chaveacesso = string.Empty;
            tp_emissao = "T";
            tipo_emissao = "TERCEIRO";
            Vl_baseICMS = decimal.Zero;
            Vl_basecalcPIS = decimal.Zero;
            Vl_basecalcCOFINS = decimal.Zero;
            Pc_aliquotaICMS = decimal.Zero;
            Pc_aliquotaICMSDest = decimal.Zero;
            Vl_difal = decimal.Zero;
            PC_ReducaoBaseCalc = decimal.Zero;
            Pc_aliquotaPIS = decimal.Zero;
            Pc_aliquotaCOFINS = decimal.Zero;
            Vl_ICMS = decimal.Zero;
            Vl_PIS = decimal.Zero;
            Vl_COFINS = decimal.Zero;
            Tp_situacao = string.Empty;
            Cd_st = string.Empty;
            Cd_stPIS = string.Empty;
            Cd_stCOFINS = string.Empty;
            St_processar = false;
            tp_cte = "0";
            tipo_cte = "NORMAL";
            tp_modalidade = "01";
            tipo_modalidade = "RODOVIARIO";
            tp_servico = "0";
            tipo_servico = "NORMAL";
            Cd_cidade_ini = string.Empty;
            Ds_cidade_ini = string.Empty;
            Cd_uf_ini = string.Empty;
            Uf_ini = string.Empty;
            Cd_cidade_fin = string.Empty;
            Ds_cidade_fin = string.Empty;
            Cd_uf_fin = string.Empty;
            Uf_fin = string.Empty;
            st_recebedorretira = "1";
            st_recebedorretirabool = false;
            Ds_retira = string.Empty;
            tp_tomador = "0";
            tipo_tomador = "REMETENTE";
            Vl_carga = decimal.Zero;
            Ds_prodpredominante = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            id_mudanca = null;
            id_mudancastr = string.Empty;
            Ds_viagem = string.Empty;
            Obsfiscal = string.Empty;
            Xml_cte = string.Empty;
            Status_cte = null;
            Msg_status = string.Empty;
            Nr_protocolo = null;
            St_anulado = false;
            Pc_impAprox = decimal.Zero;
            CH_AcessoNFeTom = string.Empty;

            lNfCTe = new TList_CTRNotaFiscal();
            lNfCTeDel = new TList_CTRNotaFiscal();
            lEvento = new TList_EventoCTe();
            lCompValorFrete = new TList_CTRCompValorFrete();
            lCompValorFreteDel = new TList_CTRCompValorFrete();
            lQtdeCarga = new TList_CTRQtdeCarga();
            lQtdeCargaDel = new TList_CTRQtdeCarga();
            lOrdemColeta = new TList_CTROrdemColeta();
            lOrdemColetadel = new TList_CTROrdemColeta();
            lNf = new TList_RegLanFaturamento();
            lNfDel = new TList_RegLanFaturamento();
            lEstoque = new TList_RegLanEstoque();
            lParcelas = new TList_RegLanParcela();
            lImpostos = new TList_ImpostosNF();
            lImpDel = new TList_ImpostosNF();

            rDuplicata = null;
            rCmi = new TRegistro_CadCMI();
        }
    }

    public class TCD_ConhecimentoFrete : TDataQuery
    {
        public TCD_ConhecimentoFrete()
        { }

        public TCD_ConhecimentoFrete(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, a.NR_LanctoCTR, a.NR_CTRC, cfg.RNTRC, a.CH_AcessoNFeTom, ");
                sql.AppendLine("a.nr_lanctoctranulado, ca.ChaveAcesso as Chave_AcessoCTRAnulado , a.nr_lanctoctrcomplementado, ");
                //Emitente
                sql.AppendLine("a.Cd_Transportadora, cTransp.NM_Clifor as nm_transportadora, cTransp.NR_CGC as CNPJ_Transp, ");
                sql.AppendLine("a.Cd_EndTransportadora, eTransp.DS_Endereco as ds_endtransportadora, ");
                sql.AppendLine("eTransp.CD_UF as Cd_uf_transportadora, eTransp.Uf as uf_transportadora, ");
                sql.AppendLine("cTransp.Cd_CondFiscal_Clifor as Cd_CondFiscal_Transp, cTransp.TP_Pessoa, eTransp.Insc_Estadual as Insc_Estadual_Transp, ");
                //Remetente
                sql.AppendLine("a.Cd_Remetente, cRemet.NM_Clifor as nm_remetente, case when cRemet.tp_pessoa = 'J' then cRemet.NR_CGC else cRemet.NR_CPF end as Cnpj_remetente, ");
                sql.AppendLine("a.Cd_EndRemetente, eRemet.DS_Endereco as ds_endremetente, eRemet.DS_Cidade as DS_CidadeRemetente, ");
                sql.AppendLine("eRemet.cd_uf as cd_uf_remetente, eRemet.uf as uf_remetente, cRemet.Cd_CondFiscal_Clifor as Cd_CondFiscal_Remetente, ");
                //Destinatario
                sql.AppendLine("a.Cd_Destinatario, cDest.NM_Clifor as nm_destinatario, case when cDest.tp_pessoa = 'J' then cDest.NR_CGC else cDest.NR_CPF end as Cnpj_destinatario, ");
                sql.AppendLine("a.Cd_EndDestinatario, eDest.DS_Endereco as ds_enddestinatario, eDest.DS_Cidade as DS_CidadeDestinatario, ");
                sql.AppendLine("eDest.cd_uf as cd_uf_destinatario, eDest.uf as uf_destinatario, cDest.Cd_CondFiscal_Clifor as Cd_CondFiscal_Dest, ");
                //Expedidor
                sql.AppendLine("a.Cd_Expedidor, cExp.nm_clifor as nm_expedidor, case when cExp.tp_pessoa = 'J' then cExp.NR_CGC else cExp.NR_CPF end as Cnpj_expedidor, ");
                sql.AppendLine("a.Cd_endExpedidor, eExp.ds_endereco as ds_endexpedidor, eExp.ds_cidade as DS_CidadeExpedidor, ");
                sql.AppendLine("eExp.cd_uf as cd_uf_expedidor, eExp.uf as uf_expedidor, cExp.Cd_CondFiscal_Clifor as Cd_CondFiscal_Exp, ");
                //Recebedor
                sql.AppendLine("a.Cd_Recebedor, cRec.nm_clifor as nm_recebedor, case when cRec.tp_pessoa = 'J' then cRec.NR_CGC else cRec.NR_CPF end as Cnpj_recebedor, ");
                sql.AppendLine("a.Cd_endRecebedor, eRec.ds_endereco as ds_endrecebedor, eRec.ds_cidade as DS_CidadeRecebedor, ");
                sql.AppendLine("eRec.cd_uf as cd_uf_recebedor, eRec.uf as uf_recebedor, cRec.Cd_CondFiscal_Clifor as Cd_CondFiscal_Rec, ");
                //Tomador
                sql.AppendLine("a.Cd_Tomador, cTom.nm_clifor as nm_tomador, case when cTom.tp_pessoa = 'J' then cTom.NR_CGC else cTom.NR_CPF end as Cnpj_tomador, ");
                sql.AppendLine("a.Cd_endTomador, eTom.ds_endereco as ds_endtomador, eTom.DS_Cidade as DS_CidadeTomador, ");
                sql.AppendLine("eTom.cd_uf as cd_uf_tomador, eTom.uf as uf_tomador, cTom.Cd_CondFiscal_Clifor as Cd_CondFiscal_Tomador, ");
                //Cidade Ini
                sql.AppendLine("a.cd_cidade_ini, cIni.ds_cidade as ds_cidade_ini, cIni.cd_uf as cd_uf_ini, uIni.uf as uf_ini, ");
                //Cidade fin
                sql.AppendLine("a.cd_cidade_fin, cFin.ds_cidade as ds_cidade_fin, cfin.cd_uf as cd_uf_fin, uFin.uf as uf_fin, ");
                //Clifor CTe Ref
                sql.AppendLine("a.cd_cliforcteref, cRef.nm_clifor as nm_cliforcteref, cRef.nr_cgc as Cnpj_cliforcteref, ");
                //Motorista/Veiculo
                sql.AppendLine("a.cd_motorista, cMot.nm_clifor as nm_motorista, a.id_veiculo, veic.ds_veiculo, veic.placa, ");
                sql.AppendLine("a.CD_Movimentacao, mov.DS_Movimentacao, a.CD_CMI, cmi.DS_CMI, a.Vl_Receber, ");
                sql.AppendLine("a.Nr_Serie, serie.DS_SerieNf, a.cd_modelo, a.cd_cfop, cfop.ds_cfop, a.Vl_ICMSSomar, ");
                sql.AppendLine("a.DT_Emissao, a.DT_SaiEnt, a.DS_Observacoes, a.Vl_Frete, a.Vl_Comissao, a.Pc_ImpAprox, ");
                sql.AppendLine("a.tp_movimento, a.chaveacesso, a.ChaveAcessoCteRef, a.TP_Emissao, ");
                sql.AppendLine("a.tp_modalidade, a.tp_servico, a.tp_cte, a.id_loteCTB, ");
                sql.AppendLine("a.st_recebedorretira, a.ds_retira, a.tp_tomador, a.obsfiscal, ");
                sql.AppendLine("a.vl_carga, a.ds_prodpredominante, a.outrascaraccarga, ");
                sql.AppendLine("a.xml_cte, a.st_registro, a.status_cte, a.msg_status, a.nr_protocolo, a.st_anulado, ");
                sql.AppendLine("a.vl_basecalcICMS, a.vl_basecalcPIS, a.vl_basecalcCOFINS, a.Vl_difal, ");
                sql.AppendLine("a.pc_aliquotaICMS, a.PC_AliquotaICMSDest, a.PC_ReducaoBaseCalc, a.pc_aliquotaPIS, a.pc_aliquotaCOFINS, ");
                sql.AppendLine("a.vl_ICMS, a.vl_PIS, a.vl_COFINS, a.tp_situacao, a.cd_st, a.cd_stPIS, a.cd_stCOFINS ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_CTR_ConhecimentoFrete a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            //Emitente
            sql.AppendLine("inner join VTB_FIN_CLIFOR cTransp ");
            sql.AppendLine("on a.Cd_Transportadora = cTransp.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO eTransp ");
            sql.AppendLine("on a.Cd_Transportadora = eTransp.CD_Clifor ");
            sql.AppendLine("and a.Cd_EndTransportadora = eTransp.CD_Endereco ");
            //Remetente
            sql.AppendLine("inner join VTB_FIN_CLIFOR cRemet ");
            sql.AppendLine("on a.Cd_Remetente = cRemet.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO eRemet ");
            sql.AppendLine("on a.Cd_Remetente = eRemet.CD_Clifor ");
            sql.AppendLine("and a.Cd_EndRemetente = eRemet.CD_Endereco ");
            //Destinatario
            sql.AppendLine("inner join VTB_FIN_CLIFOR cDest ");
            sql.AppendLine("on a.Cd_Destinatario = cDest.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO eDest ");
            sql.AppendLine("on a.Cd_Destinatario = eDest.CD_Clifor ");
            sql.AppendLine("and a.Cd_EndDestinatario = eDest.CD_Endereco ");
            //Expedidor
            sql.AppendLine("left outer join VTB_FIN_Clifor cExp ");
            sql.AppendLine("on a.cd_expedidor = cExp.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco eExp ");
            sql.AppendLine("on a.cd_expedidor = eExp.cd_clifor ");
            sql.AppendLine("and a.cd_endExpedidor = eExp.cd_endereco ");
            //Recebedor
            sql.AppendLine("left outer join VTB_FIN_Clifor cRec ");
            sql.AppendLine("on a.cd_recebedor = cRec.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco eRec ");
            sql.AppendLine("on a.cd_recebedor = eRec.cd_clifor ");
            sql.AppendLine("and a.cd_endrecebedor = eRec.cd_endereco ");
            //Tomador
            sql.AppendLine("left outer join VTB_FIN_Clifor cTom ");
            sql.AppendLine("on a.cd_tomador = cTom.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco eTom ");
            sql.AppendLine("on a.cd_tomador = eTom.cd_clifor ");
            sql.AppendLine("and a.cd_endtomador = eTom.cd_endereco ");
            //Cidade Ini
            sql.AppendLine("left outer join TB_FIN_Cidade cIni ");
            sql.AppendLine("on a.cd_cidade_ini = cIni.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF uIni ");
            sql.AppendLine("on cIni.cd_uf = uIni.cd_uf ");
            //Cidade Fin
            sql.AppendLine("left outer join TB_FIN_Cidade cFin ");
            sql.AppendLine("on a.cd_cidade_fin = cFin.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF uFin ");
            sql.AppendLine("on cFin.cd_uf = uFin.cd_uf ");
            //Clifor CTe Ref
            sql.AppendLine("left outer join VTB_FIN_Clifor cRef ");
            sql.AppendLine("on a.cd_cliforcteref = cRef.cd_clifor ");
            //Motorista
            sql.AppendLine("left outer join TB_FIN_Clifor cMot ");
            sql.AppendLine("on a.cd_motorista = cMot.cd_clifor ");
            //Veiculo
            sql.AppendLine("left outer join TB_FRT_Veiculo veic ");
            sql.AppendLine("on a.id_veiculo = veic.id_veiculo ");

            sql.AppendLine("left outer join TB_FRT_CfgFrota cfg ");
            sql.AppendLine("on a.cd_empresa = cfg.cd_empresa ");
            sql.AppendLine("left outer join TB_CTR_ConhecimentoFrete ca ");
            sql.AppendLine("on a.cd_empresa = ca.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoCTRAnulado = ca.nr_lanctoCTR ");

            sql.AppendLine("inner join TB_FIS_Movimentacao mov ");
            sql.AppendLine("on a.CD_Movimentacao = mov.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CMI cmi ");
            sql.AppendLine("on a.CD_CMI = cmi.CD_CMI ");
            sql.AppendLine("inner join TB_FAT_SerieNF serie ");
            sql.AppendLine("on a.Nr_Serie = serie.Nr_Serie ");
            sql.AppendLine("and a.cd_modelo = serie.cd_modelo ");
            sql.AppendLine("inner join TB_FIS_CFOP cfop ");
            sql.AppendLine("on a.cd_cfop = cfop.cd_cfop ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.NR_CTRC ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return executarEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ConhecimentoFrete Select(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                CriarBanco_Dados(true);
            TList_ConhecimentoFrete lista = new TList_ConhecimentoFrete();
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ConhecimentoFrete reg = new TRegistro_ConhecimentoFrete();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoCTRC = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTRAnulado")))
                        reg.Nr_lanctoCTRAnulado = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTRAnulado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_AcessoCTRAnulado")))
                        reg.Chave_acessoCTRAnulado = reader.GetString(reader.GetOrdinal("Chave_AcessoCTRAnulado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTRComplementado")))
                        reg.Nr_lanctoCTRComplementado = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTRComplementado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ChaveAcessoCTeRef")))
                        reg.Chave_acessoCTRRef = reader.GetString(reader.GetOrdinal("ChaveAcessoCTeRef"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CTRC")))
                        reg.Nr_ctrc = reader.GetDecimal(reader.GetOrdinal("NR_CTRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("RNTRC")))
                        reg.Rntrc = reader.GetString(reader.GetOrdinal("RNTRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("cd_transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("nm_transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CNPJ_Transp")))
                        reg.Cnpj_transp = reader.GetString(reader.GetOrdinal("CNPJ_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual_Transp")))
                        reg.Insc_estadual_transp = reader.GetString(reader.GetOrdinal("Insc_Estadual_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Transp")))
                        reg.Cd_condfiscal_transportadora = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pessoa")))
                        reg.Tp_pessoa_transportadora = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_EndTransportadora")))
                        reg.Cd_endtransportadora = reader.GetString(reader.GetOrdinal("Cd_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endtransportadora")))
                        reg.Ds_endtransportadora = reader.GetString(reader.GetOrdinal("ds_endtransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_transportadora")))
                        reg.Cd_uf_transportadora = reader.GetString(reader.GetOrdinal("cd_uf_transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Transportadora")))
                        reg.Uf_transportadora = reader.GetString(reader.GetOrdinal("UF_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Remetente")))
                        reg.Cd_remetente = reader.GetString(reader.GetOrdinal("Cd_Remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_remetente")))
                        reg.Nm_remetente = reader.GetString(reader.GetOrdinal("nm_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_remetente")))
                        reg.Cnpj_remetente = reader.GetString(reader.GetOrdinal("cnpj_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Remetente")))
                        reg.Cd_condfiscal_remetente = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_EndRemetente")))
                        reg.Cd_endremetente = reader.GetString(reader.GetOrdinal("Cd_EndRemetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endremetente")))
                        reg.Ds_endremetente = reader.GetString(reader.GetOrdinal("ds_endremetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidaderemetente")))
                        reg.Ds_cidaderemetente = reader.GetString(reader.GetOrdinal("ds_cidaderemetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_remetente")))
                        reg.Cd_uf_remetente = reader.GetString(reader.GetOrdinal("cd_uf_remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Remetente")))
                        reg.Uf_remetente = reader.GetString(reader.GetOrdinal("UF_Remetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Destinatario")))
                        reg.Cd_destinatario = reader.GetString(reader.GetOrdinal("Cd_Destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_destinatario")))
                        reg.Nm_destinatario = reader.GetString(reader.GetOrdinal("nm_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_destinatario")))
                        reg.Cnpj_destinatario = reader.GetString(reader.GetOrdinal("cnpj_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Dest")))
                        reg.Cd_condfiscal_destinatario = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_EndDestinatario")))
                        reg.Cd_enddestinatario = reader.GetString(reader.GetOrdinal("Cd_EndDestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_enddestinatario")))
                        reg.Ds_enddestinatario = reader.GetString(reader.GetOrdinal("ds_enddestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadedestinatario")))
                        reg.Ds_cidadedestinatario = reader.GetString(reader.GetOrdinal("ds_cidadedestinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_destinatario")))
                        reg.Cd_uf_destinatario = reader.GetString(reader.GetOrdinal("cd_uf_destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Destinatario")))
                        reg.Uf_destinatario = reader.GetString(reader.GetOrdinal("UF_Destinatario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Expedidor")))
                        reg.Cd_expedidor = reader.GetString(reader.GetOrdinal("Cd_Expedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_expedidor")))
                        reg.Nm_expedidor = reader.GetString(reader.GetOrdinal("nm_expedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_expedidor")))
                        reg.Cnpj_expedidor = reader.GetString(reader.GetOrdinal("cnpj_expedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Exp")))
                        reg.Cd_condfiscal_expedidor = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Exp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_endExpedidor")))
                        reg.Cd_endexpedidor = reader.GetString(reader.GetOrdinal("Cd_endExpedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endexpedidor")))
                        reg.Ds_endexpedidor = reader.GetString(reader.GetOrdinal("ds_endexpedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeexpedidor")))
                        reg.Ds_cidadeexpedidor = reader.GetString(reader.GetOrdinal("ds_cidadeexpedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_expedidor")))
                        reg.Cd_uf_expedidor = reader.GetString(reader.GetOrdinal("cd_uf_expedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_expedidor")))
                        reg.Uf_expedidor = reader.GetString(reader.GetOrdinal("uf_expedidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Recebedor")))
                        reg.Cd_recebedor = reader.GetString(reader.GetOrdinal("Cd_Recebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_recebedor")))
                        reg.Nm_recebedor = reader.GetString(reader.GetOrdinal("nm_recebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_recebedor")))
                        reg.Cnpj_recebedor = reader.GetString(reader.GetOrdinal("cnpj_recebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Rec")))
                        reg.Cd_condfiscal_recebedor = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Rec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_endRecebedor")))
                        reg.Cd_endrecebedor = reader.GetString(reader.GetOrdinal("Cd_endRecebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endrecebedor")))
                        reg.Ds_endrecebedor = reader.GetString(reader.GetOrdinal("ds_endrecebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidaderecebedor")))
                        reg.Ds_cidaderecebedor = reader.GetString(reader.GetOrdinal("ds_cidaderecebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_recebedor")))
                        reg.Cd_uf_recebedor = reader.GetString(reader.GetOrdinal("cd_uf_recebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_recebedor")))
                        reg.Uf_recebedor = reader.GetString(reader.GetOrdinal("uf_recebedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tomador")))
                        reg.Cd_tomador = reader.GetString(reader.GetOrdinal("cd_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_tomador")))
                        reg.Nm_tomador = reader.GetString(reader.GetOrdinal("nm_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_tomador")))
                        reg.Cnpj_tomador = reader.GetString(reader.GetOrdinal("cnpj_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Tomador")))
                        reg.Cd_condfiscal_tomador = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endtomador")))
                        reg.Cd_endtomador = reader.GetString(reader.GetOrdinal("cd_endtomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endtomador")))
                        reg.Ds_endtomador = reader.GetString(reader.GetOrdinal("ds_endtomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadetomador")))
                        reg.Ds_cidadetomador = reader.GetString(reader.GetOrdinal("ds_cidadetomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_tomador")))
                        reg.Cd_uf_tomador = reader.GetString(reader.GetOrdinal("cd_uf_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_tomador")))
                        reg.Uf_tomador = reader.GetString(reader.GetOrdinal("uf_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_ini")))
                        reg.Cd_cidade_ini = reader.GetString(reader.GetOrdinal("cd_cidade_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_ini")))
                        reg.Ds_cidade_ini = reader.GetString(reader.GetOrdinal("ds_cidade_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_ini")))
                        reg.Cd_uf_ini = reader.GetString(reader.GetOrdinal("cd_uf_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_ini")))
                        reg.Uf_ini = reader.GetString(reader.GetOrdinal("uf_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_fin")))
                        reg.Cd_cidade_fin = reader.GetString(reader.GetOrdinal("cd_cidade_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_fin")))
                        reg.Ds_cidade_fin = reader.GetString(reader.GetOrdinal("ds_cidade_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_fin")))
                        reg.Cd_uf_fin = reader.GetString(reader.GetOrdinal("cd_uf_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_fin")))
                        reg.Uf_fin = reader.GetString(reader.GetOrdinal("uf_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CMI")))
                        reg.Cd_cmi = reader.GetDecimal(reader.GetOrdinal("CD_CMI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CMI")))
                        reg.Ds_cmi = reader.GetString(reader.GetOrdinal("DS_CMI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNf")))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacoes")))
                        reg.Ds_observacoes = reader.GetString(reader.GetOrdinal("DS_Observacoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_Frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcICMS")))
                        reg.Vl_baseICMS = reader.GetDecimal(reader.GetOrdinal("vl_basecalcICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcPIS")))
                        reg.Vl_basecalcPIS = reader.GetDecimal(reader.GetOrdinal("vl_basecalcPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcCOFINS")))
                        reg.Vl_basecalcCOFINS = reader.GetDecimal(reader.GetOrdinal("vl_basecalcCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaICMS")))
                        reg.Pc_aliquotaICMS = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_AliquotaICMSDest")))
                        reg.Pc_aliquotaICMSDest = reader.GetDecimal(reader.GetOrdinal("PC_AliquotaICMSDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_difal")))
                        reg.Vl_difal = reader.GetDecimal(reader.GetOrdinal("Vl_difal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoBaseCalc")))
                        reg.PC_ReducaoBaseCalc = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaPIS")))
                        reg.Pc_aliquotaPIS = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaCOFINS")))
                        reg.Pc_aliquotaCOFINS = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_icms")))
                        reg.Vl_ICMS = reader.GetDecimal(reader.GetOrdinal("vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pis")))
                        reg.Vl_PIS = reader.GetDecimal(reader.GetOrdinal("vl_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cofins")))
                        reg.Vl_COFINS = reader.GetDecimal(reader.GetOrdinal("vl_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("tp_situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_st"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_stPIS")))
                        reg.Cd_stPIS = reader.GetString(reader.GetOrdinal("cd_stPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_stCOFINS")))
                        reg.Cd_stCOFINS = reader.GetString(reader.GetOrdinal("cd_stCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.Chaveacesso = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_emissao")))
                        reg.Tp_emissao = reader.GetString(reader.GetOrdinal("tp_emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modalidade")))
                        reg.Tp_modalidade = reader.GetString(reader.GetOrdinal("tp_modalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_servico")))
                        reg.Tp_servico = reader.GetString(reader.GetOrdinal("tp_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cte")))
                        reg.Tp_cte = reader.GetString(reader.GetOrdinal("tp_cte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_recebedorretira")))
                        reg.St_receberretira = reader.GetString(reader.GetOrdinal("st_recebedorretira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_retira")))
                        reg.Ds_retira = reader.GetString(reader.GetOrdinal("ds_retira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tomador")))
                        reg.Tp_tomador = reader.GetString(reader.GetOrdinal("tp_tomador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_carga")))
                        reg.Vl_carga = reader.GetDecimal(reader.GetOrdinal("vl_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_prodpredominante")))
                        reg.Ds_prodpredominante = reader.GetString(reader.GetOrdinal("ds_prodpredominante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("outrascaraccarga")))
                        reg.OutrasCaracCarga = reader.GetString(reader.GetOrdinal("outrascaraccarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_cte")))
                        reg.Xml_cte = reader.GetString(reader.GetOrdinal("xml_cte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obsfiscal")))
                        reg.Obsfiscal = reader.GetString(reader.GetOrdinal("obsfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status_cte")))
                        reg.Status_cte = reader.GetDecimal(reader.GetOrdinal("status_cte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("msg_status")))
                        reg.Msg_status = reader.GetString(reader.GetOrdinal("msg_status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("nr_protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_anulado")))
                        reg.St_anulado = reader.GetString(reader.GetOrdinal("st_anulado")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ImpAprox")))
                        reg.Pc_impAprox = reader.GetDecimal(reader.GetOrdinal("PC_ImpAprox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Comissao")))
                        reg.Vl_comissao = reader.GetDecimal(reader.GetOrdinal("Vl_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_icmssomar")))
                        reg.Vl_icmssomar = reader.GetDecimal(reader.GetOrdinal("vl_icmssomar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_receber")))
                        reg.Vl_receber = reader.GetDecimal(reader.GetOrdinal("vl_receber"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CH_AcessoNFeTom")))
                        reg.CH_AcessoNFeTom = reader.GetString(reader.GetOrdinal("CH_AcessoNFeTom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforcteref")))
                        reg.Cd_cliforCTeRef = reader.GetString(reader.GetOrdinal("cd_cliforcteref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforcteref")))
                        reg.Nm_cliforCTeRef = reader.GetString(reader.GetOrdinal("nm_cliforcteref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cliforcteref")))
                        reg.Cnpj_cliforCTeRef = reader.GetString(reader.GetOrdinal("cnpj_cliforcteref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("cd_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));

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

        public string Gravar(TRegistro_ConhecimentoFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(51);

            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTRC);
            hs.Add("@P_NR_LANCTOCTRANULADO", val.Nr_lanctoCTRAnulado);
            hs.Add("@P_NR_LANCTOCTRCOMPLEMENTADO", val.Nr_lanctoCTRComplementado);
            hs.Add("@P_CH_ACESSONFETOM", val.CH_AcessoNFeTom);
            hs.Add("@P_NR_CTRC", val.Nr_ctrc);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_CD_ENDTRANSPORTADORA", val.Cd_endtransportadora);
            hs.Add("@P_CD_REMETENTE", val.Cd_remetente);
            hs.Add("@P_CD_ENDREMETENTE", val.Cd_endremetente);
            hs.Add("@P_CD_DESTINATARIO", val.Cd_destinatario);
            hs.Add("@P_CD_ENDDESTINATARIO", val.Cd_enddestinatario);
            hs.Add("@P_CD_EXPEDIDOR", val.Cd_expedidor);
            hs.Add("@P_CD_ENDEXPEDIDOR", val.Cd_endexpedidor);
            hs.Add("@P_CD_RECEBEDOR", val.Cd_recebedor);
            hs.Add("@P_CD_ENDRECEBEDOR", val.Cd_endrecebedor);
            hs.Add("@P_CD_TOMADOR", val.Cd_tomador);
            hs.Add("@P_CD_ENDTOMADOR", val.Cd_endtomador);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_CMI", val.Cd_cmi);
            hs.Add("@P_CD_CFOP", val.Cd_cfop);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_CIDADE_INI", val.Cd_cidade_ini);
            hs.Add("@P_CD_CIDADE_FIN", val.Cd_cidade_fin);
            hs.Add("@P_CD_CLIFORCTEREF", val.Cd_cliforCTeRef);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_SAIENT", val.Dt_saient);
            hs.Add("@P_DS_OBSERVACOES", val.Ds_observacoes);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_CHAVEACESSO", val.Chaveacesso);
            hs.Add("@P_CHAVEACESSOCTEREF", val.Chave_acessoCTRRef);
            hs.Add("@P_TP_EMISSAO", val.Tp_emissao);
            hs.Add("@P_TP_MODALIDADE", val.Tp_modalidade);
            hs.Add("@P_TP_SERVICO", val.Tp_servico);
            hs.Add("@P_TP_CTE", val.Tp_cte);
            hs.Add("@P_ST_RECEBEDORRETIRA", val.St_receberretira);
            hs.Add("@P_DS_RETIRA", val.Ds_retira);
            hs.Add("@P_TP_TOMADOR", val.Tp_tomador);
            hs.Add("@P_OBSFISCAL", val.Obsfiscal);
            hs.Add("@P_VL_CARGA", val.Vl_carga);
            hs.Add("@P_DS_PRODPREDOMINANTE", val.Ds_prodpredominante);
            hs.Add("@P_OUTRASCARACCARGA", val.OutrasCaracCarga);
            hs.Add("@P_XML_CTE", val.Xml_cte);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_PC_IMPAPROX", val.Pc_impAprox);
            hs.Add("@P_VL_ICMSSOMAR", val.Vl_icmssomar);
            hs.Add("@P_VL_RECEBER", val.Vl_receber);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("IA_CTR_CONHECIMENTOFRETE", hs);
        }

        public string Excluir(TRegistro_ConhecimentoFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTRC);

            return executarProc("EXCLUI_CTR_CONHECIMENTOFRETE", hs);
        }

        public string Cancelar(TRegistro_ConhecimentoFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTRC);

            return executarProc("CANCELA_CTR_CONHECIMENTOFRETE", hs);
        }
    }
}
