using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using CamadaDados.Fiscal;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_ImpostosNF : List<TRegistro_ImpostosNF>
    {
        public void Concat(TList_ImpostosNF segunda)
        {
            if (segunda != null) 
                segunda.ForEach(p =>
                    {
                        if (Exists(v => v.Cd_imposto.Equals(p.Cd_imposto)))
                            RemoveAll(v => v.Cd_imposto.Equals(p.Cd_imposto));
                        Add(p);
                    });
        }

        public void ConcatenarXMLNFe(TList_ImpostosNF segunda)
        {
            if (segunda != null)
                segunda.ForEach(p =>
                    {
                        if (Exists(v => v.Cd_imposto.Equals(p.Cd_imposto)))
                        {
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Cd_clifor = p.Cd_clifor;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Cd_empresa = p.Cd_empresa;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Cd_st = p.Cd_st;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Cd_unidade_ref = p.Cd_unidade_ref;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Ds_situacao = p.Ds_situacao;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Ds_unidade_ref = p.Ds_unidade_ref;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Dt_imposto = p.Dt_imposto;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_basecredito = p.Id_basecredito;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_detrecisenta = p.Id_detrecisenta;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_receita = p.Id_receita;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_lancto = p.Id_lancto;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_lotectb_calculado = p.Id_lotectb_calculado;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_lotectb_retido = p.Id_lotectb_retido;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_lotefis = p.Id_lotefis;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_tpcontribuicao = p.Id_tpcontribuicao;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Id_tpcred = p.Id_tpcred;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Imposto = p.Imposto;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Nm_clifor = p.Nm_clifor;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Nm_empresa = p.Nm_empresa;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Nr_lanctoctr = p.Nr_lanctoctr;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_aliquota = p.Pc_aliquota;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_basecalc = p.Pc_basecalc;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_iva_st = p.Pc_iva_st;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_reducaoaliquota = p.Pc_reducaoaliquota;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_reducaobasecalc = p.Pc_reducaobasecalc;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_retencao = p.Pc_retencao;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Sg_unidade_ref = p.Sg_unidade_ref;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).St_gerarcredito = p.St_gerarcredito;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).St_impostouf = p.St_impostouf;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).St_substtrib = p.St_substtrib;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).St_simplesnacional = p.St_simplesnacional;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).St_totalnota = p.St_totalnota;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_docto = p.Tp_docto;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_imposto = p.Tp_imposto;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_modbasecalc = p.Tp_modbasecalc;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_modbasecalcST = p.Tp_modbasecalcST;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_registro = p.Tp_registro;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_situacao = p.Tp_situacao;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_situacao = p.Tp_situacao;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Tp_tributiss = p.Tp_tributiss;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Uf_clifor = p.Uf_clifor;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_basecalc = p.Vl_basecalc;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_contabil = p.Vl_contabil;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_imposto_unit = p.Vl_imposto_unit;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_impostocalc = p.Vl_impostocalc;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_impostoretido = p.Vl_impostoretido;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_minimo = p.Vl_minimo;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_mva = p.Vl_mva;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_FCP = p.Pc_FCP;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_FCP = p.Vl_FCP;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Pc_FCPST = p.Pc_FCPST;
                            this.FirstOrDefault(v => v.Cd_imposto.Equals(p.Cd_imposto)).Vl_FCPST = p.Vl_FCPST;
                        }
                    });
        }
    }
    
    public class TRegistro_ImpostosNF: ICloneable
    {
        public decimal? Id_lancto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Nr_lanctoctr
        { get; set; }
        private decimal? cd_imposto;
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = Convert.ToDecimal(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        public string Ds_imposto
        { get; set; }
        public decimal? Id_lotectb_retido
        { get; set; }
        public decimal? Id_lotectb_calculado
        { get; set; }
        public string Tp_imposto
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_st_xml
        { get; set; }
        public string Ds_situacao
        { get; set; }
        public bool St_substtrib
        { get; set; }
        public bool St_simplesnacional
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Pc_aliquota_xml
        { get; set; }
        public decimal Pc_retencao
        { get; set; }
        private decimal vl_contabil;
        public decimal Vl_contabil
        {
            get { return Math.Round(vl_contabil, 2); }
            set { vl_contabil = Math.Round(value, 2); }
        }
        private decimal vl_impostoretido;
        public decimal Vl_impostoretido
        {
            get { return Math.Round(vl_impostoretido, 2); }
            set { vl_impostoretido = Math.Round(value, 2); }
        }
        private decimal vl_impostocalc;
        public decimal Vl_impostocalc
        {
            get { return Math.Round(vl_impostocalc, 2); }
            set { vl_impostocalc = Math.Round(value, 2); }
        }
        public decimal Vl_imposto_xml
        { get; set; }
        
        private decimal vl_basecalc;
        public decimal Vl_basecalc
        {
            get { return Math.Round(vl_basecalc, 2); }
            set { vl_basecalc = Math.Round(value, 2); }
        }
        public decimal Vl_basecalc_xml
        { get; set; }
        private int st_gerarcredito;
        public int St_gerarcredito
        {
            get { return st_gerarcredito; }
            set
            {
                st_gerarcredito = value;
                st_gerarcreditobool = value.Equals(0);
            }
        }
        private bool st_gerarcreditobool;
        public bool St_gerarcreditobool
        {
            get { return st_gerarcreditobool; }
            set
            {
                st_gerarcreditobool = value;
                if (value)
                    st_gerarcredito = 0;
                else
                    st_gerarcredito = 1;
            }
        }
        private decimal vl_basecalcsubsttrib;
        public decimal Vl_basecalcsubsttrib
        {
            get { return Math.Round(vl_basecalcsubsttrib, 2); }
            set { vl_basecalcsubsttrib = Math.Round(value, 2); }
        }
        public decimal Vl_basecalcsubsttrib_xml { get; set; } = decimal.Zero;
        private decimal vl_impostosubsttrib;
        public decimal Vl_impostosubsttrib
        {
            get { return Math.Round(vl_impostosubsttrib, 2); }
            set { vl_impostosubsttrib = Math.Round(value, 2); }
        }
        public decimal Vl_impostosubsttrib_xml { get; set; } = decimal.Zero;
        public decimal Pc_reducaobasecalc
        { get; set; }
        public decimal Pc_reducaobasecalc_xml
        { get; set; }
        public decimal Pc_aliquotasubst
        { get; set; }
        public decimal Pc_aliquotasubst_xml { get; set; } = decimal.Zero;
        public decimal Pc_reducaobasecalcsubsttrib
        { get; set; }
        public decimal Pc_reducaobasecalcsubsttrib_xml { get; set; } = decimal.Zero;
        public decimal Pc_iva_st
        { get; set; }
        public decimal Vl_mva
        { get; set; }
        public decimal Pc_reducaoaliquota
        { get; set; }
        public decimal Vl_diferidoICMS { get; set; } = decimal.Zero;
        private string tp_situacao;
        public string Tp_situacao
        {
            get { return tp_situacao; }
            set
            {
                tp_situacao = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_registro = "TRIBUTADO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_registro = "ISENTA";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_registro = "OUTRAS";
            }
        }
        private string tipo_situacao;
        public string Tipo_situacao
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("TRIBUTADO"))
                    tp_situacao = "1";
                else if (value.Trim().ToUpper().Equals("ISENTA"))
                    tp_situacao = "2";
                else if (value.Trim().ToUpper().Equals("OUTRAS"))
                    tp_situacao = "3";
            }
        }
        private string tp_registro;
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_registro = "AUTOMATICO";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_registro = "MANUAL";
            }
        }
        private string tipo_registro;
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("AUTOMATICO"))
                    tp_registro = "A";
                else if (value.Trim().ToUpper().Equals("MANUAL"))
                    tp_registro = "M";
            }
        }
        public string St_totalnota
        { get; set; }
        public decimal Vl_minimo
        { get; set; }
        public string Cd_unidade_ref
        { get; set; }
        public string Ds_unidade_ref
        { get; set; }
        public string Sg_unidade_ref
        { get; set; }
        public decimal Vl_imposto_unit
        { get; set; }
        public decimal Pc_basecalc
        { get; set; }
        private int st_impostouf;
        public int St_impostouf
        {
            get { return st_impostouf; }
            set
            {
                st_impostouf = value;
                st_impostoufbool = value.Equals(0);
            }
        }
        private bool st_impostoufbool;
        public bool St_impostoufbool
        {
            get { return st_impostoufbool; }
            set
            {
                st_impostoufbool = value;
                if (value)
                    st_impostouf = 0;
                else
                    st_impostouf = 1;
            }
        }
        public decimal? Id_lotefis
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Uf_clifor
        { get; set; }
        public string Tp_docto
        { get; set; }
        public DateTime? Dt_imposto
        { get; set; }
        public string Dt_impostostr
        { get { return Dt_imposto.HasValue ? Dt_imposto.Value.ToString("dd/MM/yyyy") : string.Empty; } }
        public string Tp_tributiss
        { get; set; }
        public string Tipo_tributiss
        {
            get
            {
                if (Tp_tributiss.Trim().ToUpper().Equals("N"))
                    return "NORMAL";
                else if (Tp_tributiss.Trim().ToUpper().Equals("R"))
                    return "RETIDA";
                else if (Tp_tributiss.Trim().ToUpper().Equals("S"))
                    return "SUBSTITUTA";
                else if (Tp_tributiss.Trim().ToUpper().Equals("I"))
                    return "ISENTA";
                else
                    return string.Empty;
            }
        }
        public string Tp_modbasecalc
        { get; set; }
        public string Tipo_modbasecalc
        {
            get
            {
                if (this.Tp_modbasecalc.Trim().Equals("0"))
                    return "MARGEM VALOR AGREGADO(%)";
                else if (this.Tp_modbasecalc.Trim().Equals("1"))
                    return "PAUTA(VALOR)";
                else if (this.Tp_modbasecalc.Trim().Equals("2"))
                    return "PREÇO TABELADO MAXIMO(VALOR)";
                else if (this.Tp_modbasecalc.Trim().Equals("3"))
                    return "VALOR OPERAÇÃO";
                else return string.Empty;
            }
        }
        public string Tp_modbasecalcST
        { get; set; }
        public string Tipo_modbasecalcST
        {
            get
            {
                if (this.Tp_modbasecalcST.Trim().Equals("0"))
                    return "PREÇO TABELADO";
                else if (this.Tp_modbasecalcST.Trim().Equals("1"))
                    return "LISTA NEGATIVA(VALOR)";
                else if (this.Tp_modbasecalcST.Trim().Equals("2"))
                    return "LISTA POSITIVA(VALOR)";
                else if (this.Tp_modbasecalcST.Trim().Equals("3"))
                    return "LISTA NEUTRA(VALOR)";
                else if (this.Tp_modbasecalcST.Trim().Equals("4"))
                    return "MARGEM VALOR AGREGADO";
                else if (this.Tp_modbasecalcST.Trim().Equals("5"))
                    return "PAUTA(VALOR)";
                else return string.Empty;
            }
        }
        private decimal? id_basecredito;
        public decimal? Id_basecredito
        {
            get { return id_basecredito; }
            set
            {
                id_basecredito = value;
                id_basecreditostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_basecreditostr;
        public string Id_basecreditostr
        {
            get { return id_basecreditostr; }
            set
            {
                id_basecreditostr = value;
                try
                {
                    id_basecredito = decimal.Parse(value);
                }
                catch
                { id_basecredito = null; }
            }
        }
        private decimal? id_tpcred;
        public decimal? Id_tpcred
        {
            get { return id_tpcred; }
            set
            {
                id_tpcred = value;
                id_tpcredstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpcredstr;
        public string Id_tpcredstr
        {
            get { return id_tpcredstr; }
            set
            {
                id_tpcredstr = value;
                try
                {
                    id_tpcred = decimal.Parse(value);
                }
                catch
                { id_tpcred = null; }
            }
        }
        private decimal? id_tpcontribuicao;
        public decimal? Id_tpcontribuicao
        {
            get { return id_tpcontribuicao; }
            set
            {
                id_tpcontribuicao = value;
                id_tpcontribuicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpcontribuicaostr;
        public string Id_tpcontribuicaostr
        {
            get { return id_tpcontribuicaostr; }
            set
            {
                id_tpcontribuicaostr = value;
                try
                {
                    id_tpcontribuicao = decimal.Parse(value);
                }
                catch
                { id_tpcontribuicao = null; }
            }
        }
        private decimal? id_detrecisenta;
        public decimal? Id_detrecisenta
        {
            get { return id_detrecisenta; }
            set
            {
                id_detrecisenta = value;
                id_detrecisentastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_detrecisentastr;
        public string Id_detrecisentastr
        {
            get { return id_detrecisentastr; }
            set
            {
                id_detrecisentastr = value;
                try
                {
                    id_detrecisenta = decimal.Parse(value);
                }
                catch
                { id_detrecisenta = null; }
            }
        }
        private decimal? id_receita;
        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;
        public string Id_receitastr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch { id_receita = null; }
            }
        }
        public decimal Vl_ImpCustoEst
        {
            get
            {
                return this.vl_impostosubsttrib +
                       (this.St_totalnota.Trim().ToUpper().Equals("S") ? this.vl_impostocalc : decimal.Zero) -
                       (this.st_gerarcreditobool ? this.vl_impostocalc : decimal.Zero);
            }
        }
        public bool St_somaricmsbase
        { get; set; }
        public string Tp_naturezaoperacaoiss
        { get; set; }
        public string Tipo_naturezaoperacaoiss
        {
            get
            {
                if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("1"))
                    return "TRIBUTAÇÃO MUNICIPIO";
                else if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("2"))
                    return "TRIBUTAÇÃO FORA MUNICIPIO";
                else if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("3"))
                    return "ISENTO";
                else if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("4"))
                    return "IMUNE";
                else if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("5"))
                    return "EXIGIBILIDADE SUSPENSA DECISÃO JUDICIAL";
                else if (Tp_naturezaoperacaoiss.Trim().ToUpper().Equals("6"))
                    return "EXIGIBILIDADE SUSPENSA DECISÃO ADIMINISTRATIVA";
                else return string.Empty;
            }
        }
        public decimal Pc_aliquotaICMSDest
        { get; set; }
        public decimal Pc_aliqopdifal { get; set; } = decimal.Zero;
        public decimal Vl_difal
        { get; set; }
        public string Ds_deducao
        { get; set; }
        public decimal Pc_FCP { get; set; }
        public decimal Vl_FCP { get; set; }
        public decimal Pc_FCPST { get; set; } = decimal.Zero;
        public decimal Vl_FCPST { get; set; } = decimal.Zero;
        public decimal Vl_pauta { get; set; } = decimal.Zero;
        public bool St_somarIPIBaseICMS { get; set; } = false;
        public bool St_somarIPIBaseST { get; set; } = false;
        public decimal Vl_ipisomar { get; set; }
        public TRegistro_CadImposto Imposto
        { get; set; }

        public TRegistro_ImpostosNF()
        {
            Id_lancto = null;
            Cd_empresa = string.Empty;
            cd_imposto = null;
            cd_impostostr = string.Empty;
            Ds_imposto = string.Empty;
            Id_lotectb_calculado = null;
            Id_lotectb_retido = null;
            Cd_st = string.Empty;
            Cd_st_xml = string.Empty;
            Ds_situacao = string.Empty;
            St_substtrib = false;
            St_simplesnacional = false;
            Pc_aliquota = decimal.Zero;
            Pc_aliquota_xml = decimal.Zero;
            Pc_retencao = decimal.Zero;
            Tp_imposto = string.Empty;
            vl_contabil = decimal.Zero;
            vl_basecalc = decimal.Zero;
            Vl_basecalc_xml = decimal.Zero;
            vl_impostocalc = decimal.Zero;
            Vl_imposto_xml = decimal.Zero;
            vl_impostoretido = decimal.Zero;
            st_gerarcredito = 1;
            st_gerarcreditobool = false;
            vl_basecalcsubsttrib = decimal.Zero;
            vl_impostosubsttrib = decimal.Zero;
            Pc_reducaobasecalc = decimal.Zero;
            Pc_reducaobasecalc_xml = decimal.Zero;
            Pc_aliquotasubst = decimal.Zero;
            Pc_reducaobasecalcsubsttrib = decimal.Zero;
            Pc_iva_st = decimal.Zero;
            Vl_mva = decimal.Zero;
            Pc_reducaoaliquota = decimal.Zero;
            tp_situacao = string.Empty;
            tipo_situacao = string.Empty;
            tp_registro = "A";
            tipo_registro = "AUTOMATICO";
            St_totalnota = string.Empty;
            Vl_minimo = decimal.Zero;
            Cd_unidade_ref = string.Empty;
            Ds_unidade_ref = string.Empty;
            Sg_unidade_ref = string.Empty;
            Vl_imposto_unit = decimal.Zero;
            Pc_basecalc = decimal.Zero;
            st_impostouf = 1;
            st_impostoufbool = false;
            Nr_lanctoctr = null;
            Id_lotefis = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Uf_clifor = string.Empty;
            Tp_docto = string.Empty;
            Dt_imposto = null;
            Tp_tributiss = string.Empty;
            Tp_modbasecalc = string.Empty;
            Tp_modbasecalcST = string.Empty;
            id_basecredito = null;
            id_basecreditostr = string.Empty;
            id_tpcred = null;
            id_tpcredstr = string.Empty;
            id_tpcontribuicao = null;
            id_tpcontribuicaostr = string.Empty;
            id_detrecisenta = null;
            id_detrecisentastr = string.Empty;
            id_receita = null;
            id_receitastr = string.Empty;
            St_somaricmsbase = false;
            Tp_naturezaoperacaoiss = string.Empty;
            Pc_aliquotaICMSDest = decimal.Zero;
            Vl_difal = decimal.Zero;
            Ds_deducao = string.Empty;
            Imposto = new TRegistro_CadImposto();
        }

        #region ICloneable Members

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }

    public class TCD_ImpostosNF : TDataQuery
    {
        public TCD_ImpostosNF()
        { }

        public TCD_ImpostosNF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }
                
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_lancto, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Imposto, c.DS_Imposto, a.Id_LoteCTB_Calculado, ");
                sql.AppendLine("a.Id_LoteCTB_Retido, a.TP_Imposto, a.CD_ST, g.ds_situacao, g.st_substtrib, a.id_tpcontribuicao, ");
                sql.AppendLine("a.PC_Aliquota, a.PC_Retencao, a.Vl_BaseCalc, a.st_impostouf, a.id_basecredito, a.ds_deducao, ");
                sql.AppendLine("a.Vl_ImpostoCalc, a.Vl_ImpostoRetido, a.st_gerarcredito, a.id_lotefis, g.st_simplesnacional, ");
                sql.AppendLine("a.Vl_BaseCalcSubstTrib, a.Vl_ImpostoSubstTrib, a.tp_modbasecalc, a.tp_modbasecalcst, a.Vl_Pauta, ");
                sql.AppendLine("a.PC_ReducaoBaseCalc, a.PC_AliquotaSubst, a.tp_registro, a.tp_tributiss, ");
                sql.AppendLine("a.PC_ReducaoBaseCalcSubstTrib, a.PC_ReducaoAliquota, a.tp_situacao, ");
                sql.AppendLine("a.st_totalnota, a.vl_minimo, a.cd_unidade_ref, a.vl_imposto_unit, a.id_receita, a.tp_naturezaoperacaoiss, ");
                sql.AppendLine("e.ds_unidade as ds_unidade_ref, e.sigla_unidade as sg_unidade_ref, a.id_detrecisenta, ");
                sql.AppendLine("c.st_pis, c.st_cofins, c.st_icms, c.st_ipi, c.st_issqn, c.st_ii, ");
                sql.AppendLine("c.st_csll, c.st_irrf, c.st_inss, c.st_funrural, c.st_senar, a.nr_lanctoctr, a.id_tpcred, a.pc_iva_st, ");
                sql.AppendLine("a.pc_fcp, a.vl_fcp, a.pc_aliquotaicmsdest, a.pc_aliqopdifal, a.vl_difal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ImpostosNF a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIS_Imposto c ");
            sql.AppendLine("on a.CD_Imposto = c.CD_Imposto ");
            sql.AppendLine("left outer join TB_CTR_ConhecimentoFrete ctrc ");
            sql.AppendLine("on a.cd_empresa = ctrc.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoctr = ctrc.nr_lanctoctr ");
            sql.AppendLine("left outer join tb_est_unidade e ");
            sql.AppendLine("on a.cd_unidade_ref = e.cd_unidade ");
            sql.AppendLine("left outer join TB_FIS_SitTribut g ");
            sql.AppendLine("on a.cd_st = g.cd_st ");
            sql.AppendLine("and a.cd_imposto = g.cd_imposto ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }


        public TList_ImpostosNF Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ImpostosNF lista = new TList_ImpostosNF();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ImpostosNF reg = new TRegistro_ImpostosNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                    {
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                        reg.Imposto.Cd_imposto = reg.Cd_imposto;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                    {
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                        reg.Imposto.ds_imposto = reg.Ds_imposto;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB_Calculado")))
                        reg.Id_lotectb_calculado = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB_Calculado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB_Retido")))
                        reg.Id_lotectb_retido = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB_Retido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Imposto")))
                        reg.Tp_imposto = reader.GetString(reader.GetOrdinal("TP_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("CD_ST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("DS_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_substtrib")))
                        reg.St_substtrib = reader.GetString(reader.GetOrdinal("st_substtrib")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_simplesnacional")))
                        reg.St_simplesnacional = reader.GetString(reader.GetOrdinal("st_simplesnacional")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Retencao")))
                        reg.Pc_retencao = reader.GetDecimal(reader.GetOrdinal("PC_Retencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ImpostoCalc")))
                        reg.Vl_impostocalc = reader.GetDecimal(reader.GetOrdinal("Vl_ImpostoCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ImpostoRetido")))
                        reg.Vl_impostoretido = reader.GetDecimal(reader.GetOrdinal("Vl_ImpostoRetido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarCredito")))
                        reg.St_gerarcredito = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("ST_GerarCredito")));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcSubstTrib")))
                        reg.Vl_basecalcsubsttrib = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcSubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ImpostoSubstTrib")))
                        reg.Vl_impostosubsttrib = reader.GetDecimal(reader.GetOrdinal("Vl_ImpostoSubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoBaseCalc")))
                        reg.Pc_reducaobasecalc = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_AliquotaSubst")))
                        reg.Pc_aliquotasubst = reader.GetDecimal(reader.GetOrdinal("PC_AliquotaSubst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoBaseCalcSubstTrib")))
                        reg.Pc_reducaobasecalcsubsttrib = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoBaseCalcSubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoAliquota")))
                        reg.Pc_reducaoaliquota = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoAliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("tp_situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TotalNota")))
                        reg.St_totalnota = reader.GetString(reader.GetOrdinal("ST_TotalNota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Minimo")))
                        reg.Vl_minimo = reader.GetDecimal(reader.GetOrdinal("Vl_Minimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Ref")))
                        reg.Cd_unidade_ref = reader.GetString(reader.GetOrdinal("CD_Unidade_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade_Ref")))
                        reg.Ds_unidade_ref = reader.GetString(reader.GetOrdinal("DS_Unidade_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Unidade_Ref")))
                        reg.Sg_unidade_ref = reader.GetString(reader.GetOrdinal("SG_Unidade_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Imposto_Unit")))
                        reg.Vl_imposto_unit = reader.GetDecimal(reader.GetOrdinal("Vl_Imposto_Unit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ImpostoUF")))
                        reg.St_impostouf = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_ImpostoUF")));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotefis")))
                        reg.Id_lotefis = reader.GetDecimal(reader.GetOrdinal("id_lotefis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modbasecalc")))
                        reg.Tp_modbasecalc = reader.GetString(reader.GetOrdinal("tp_modbasecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modbasecalcst")))
                        reg.Tp_modbasecalcST = reader.GetString(reader.GetOrdinal("tp_modbasecalcst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_iva_st")))
                        reg.Pc_iva_st = reader.GetDecimal(reader.GetOrdinal("pc_iva_st"));
                    //Dados do imposto
                    if (!reader.IsDBNull(reader.GetOrdinal("st_pis")))
                        reg.Imposto.St_PIS = reader.GetBoolean(reader.GetOrdinal("st_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cofins")))
                        reg.Imposto.St_Cofins = reader.GetBoolean(reader.GetOrdinal("st_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_icms")))
                        reg.Imposto.St_ICMS = reader.GetBoolean(reader.GetOrdinal("st_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_ipi")))
                        reg.Imposto.St_IPI = reader.GetBoolean(reader.GetOrdinal("st_ipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_issqn")))
                        reg.Imposto.St_ISSQN = reader.GetBoolean(reader.GetOrdinal("st_issqn"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_csll")))
                        reg.Imposto.St_CSLL = reader.GetBoolean(reader.GetOrdinal("st_csll"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_irrf")))
                        reg.Imposto.St_IRRF = reader.GetBoolean(reader.GetOrdinal("st_irrf"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_inss")))
                        reg.Imposto.St_INSS = reader.GetBoolean(reader.GetOrdinal("st_inss"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_ii")))
                        reg.Imposto.St_II = reader.GetBoolean(reader.GetOrdinal("st_ii"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_funrural")))
                        reg.Imposto.St_Funrural = reader.GetBoolean(reader.GetOrdinal("st_funrural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_senar")))
                        reg.Imposto.St_Senar = reader.GetBoolean(reader.GetOrdinal("st_senar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_basecredito")))
                        reg.Id_basecredito = reader.GetDecimal(reader.GetOrdinal("id_basecredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcred")))
                        reg.Id_tpcred = reader.GetDecimal(reader.GetOrdinal("id_tpcred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcontribuicao")))
                        reg.Id_tpcontribuicao = reader.GetDecimal(reader.GetOrdinal("id_tpcontribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_detrecisenta")))
                        reg.Id_detrecisenta = reader.GetDecimal(reader.GetOrdinal("id_detrecisenta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("id_receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_naturezaoperacaoiss")))
                        reg.Tp_naturezaoperacaoiss = reader.GetString(reader.GetOrdinal("tp_naturezaoperacaoiss"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicmsdest")))
                        reg.Pc_aliquotaICMSDest = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicmsdest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliqopdifal")))
                        reg.Pc_aliqopdifal = reader.GetDecimal(reader.GetOrdinal("pc_aliqopdifal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_difal")))
                        reg.Vl_difal = reader.GetDecimal(reader.GetOrdinal("vl_difal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_deducao")))
                        reg.Ds_deducao = reader.GetString(reader.GetOrdinal("ds_deducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_fcp")))
                        reg.Pc_FCP = reader.GetDecimal(reader.GetOrdinal("pc_fcp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_fcp")))
                        reg.Vl_FCP = reader.GetDecimal(reader.GetOrdinal("vl_fcp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Pauta")))
                        reg.Vl_pauta = reader.GetDecimal(reader.GetOrdinal("Vl_Pauta"));

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

        public string Gravar(TRegistro_ImpostosNF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(44);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_ID_LOTECTB_RETIDO", val.Id_lotectb_retido);
            hs.Add("@P_ID_LOTECTB_CALCULADO", val.Id_lotectb_calculado);
            hs.Add("@P_TP_IMPOSTO", val.Tp_imposto);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_PC_ALIQUOTA", Math.Round(val.Pc_aliquota, 2));
            hs.Add("@P_PC_RETENCAO", Math.Round(val.Pc_retencao, 2));
            hs.Add("@P_VL_BASECALC", Math.Round(val.Vl_basecalc, 2));
            hs.Add("@P_VL_IMPOSTORETIDO", Math.Round(val.Vl_impostoretido, 2));
            hs.Add("@P_VL_IMPOSTOCALC", Math.Round(val.Vl_impostocalc, 2));
            hs.Add("@P_ST_GERARCREDITO", val.St_gerarcredito);
            hs.Add("@P_VL_BASECALCSUBSTTRIB", Math.Round(val.Vl_basecalcsubsttrib, 2));
            hs.Add("@P_VL_IMPOSTOSUBSTTRIB", Math.Round(val.Vl_impostosubsttrib, 2));
            hs.Add("@P_PC_REDUCAOBASECALC", Math.Round(val.Pc_reducaobasecalc, 2));
            hs.Add("@P_PC_ALIQUOTASUBST", Math.Round(val.Pc_aliquotasubst, 2));
            hs.Add("@P_PC_REDUCAOBASECALCSUBSTTRIB", Math.Round(val.Pc_reducaobasecalcsubsttrib, 2));
            hs.Add("@P_PC_REDUCAOALIQUOTA", Math.Round(val.Pc_reducaoaliquota, 2));
            hs.Add("@P_TP_SITUACAO", val.Tp_situacao);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_ST_TOTALNOTA", val.St_totalnota);
            hs.Add("@P_VL_MINIMO", Math.Round(val.Vl_minimo, 2));
            hs.Add("@P_CD_UNIDADE_REF", val.Cd_unidade_ref);
            hs.Add("@P_VL_IMPOSTO_UNIT", val.Vl_imposto_unit);
            hs.Add("@P_ST_IMPOSTOUF", val.St_impostouf);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);
            hs.Add("@P_ID_LOTEFIS", val.Id_lotefis);
            hs.Add("@P_TP_TRIBUTISS", val.Tp_tributiss);
            hs.Add("@P_TP_MODBASECALC", val.Tp_modbasecalc);
            hs.Add("@P_TP_MODBASECALCST", val.Tp_modbasecalcST);
            hs.Add("@P_ID_BASECREDITO", val.Id_basecredito);
            hs.Add("@P_ID_TPCRED", val.Id_tpcred);
            hs.Add("@P_ID_TPCONTRIBUICAO", val.Id_tpcontribuicao);
            hs.Add("@P_ID_DETRECISENTA", val.Id_detrecisenta);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_PC_IVA_ST", val.Pc_iva_st);
            hs.Add("@P_TP_NATUREZAOPERACAOISS", val.Tp_naturezaoperacaoiss);
            hs.Add("@P_PC_ALIQUOTAICMSDEST", val.Pc_aliquotaICMSDest);
            hs.Add("@P_PC_ALIQOPDIFAL", val.Pc_aliqopdifal);
            hs.Add("@P_VL_DIFAL", val.Vl_difal);
            hs.Add("@P_DS_DEDUCAO", val.Ds_deducao);
            hs.Add("@P_PC_FCP", val.Pc_FCP);
            hs.Add("@P_VL_FCP", val.Vl_FCP);
            hs.Add("@P_VL_PAUTA", val.Vl_pauta);

            return executarProc("IA_FAT_IMPOSTOSNF", hs);
        }

        public string Excluir(TRegistro_ImpostosNF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("EXCLUI_FAT_IMPOSTOSNF", hs);
        }
    }
}
