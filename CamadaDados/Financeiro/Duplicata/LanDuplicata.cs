using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CamadaDados.Financeiro.Titulo;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.CCustoLan;

namespace CamadaDados.Financeiro.Duplicata
{
    #region Classe Parcela Auxiliar
    public class TList_Parcelas : List<TParcelas>
    { }

    public class TParcelas
    {
        private DateTime? dt_vencimento;
        public DateTime? Dt_vencimento
        {
            get { return dt_vencimento; }
            set
            {
                dt_vencimento = value;
                dt_vencimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_vencimentostr;
        public string Dt_vencimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimentostr = value;
                try
                {
                    dt_vencimento = Convert.ToDateTime(value);
                }
                catch
                { dt_vencimento = null; }
            }
        }
        public decimal? DiasVencto
        { get; set; }
        public decimal Vl_parcela
        { get; set; }
        public decimal Vl_parcela_padrao
        { get; set; }
        public decimal Vl_juro
        { get; set; }

        public TParcelas()
        {
            dt_vencimento = null;
            dt_vencimentostr = string.Empty;
            DiasVencto = null;
            Vl_parcela = decimal.Zero;
            Vl_parcela_padrao = decimal.Zero;
            Vl_juro = decimal.Zero;
        }
    }
    #endregion

    #region Duplicata

    public class TList_RegLanDuplicata : List<TRegistro_LanDuplicata>, IComparer<TRegistro_LanDuplicata>
    {
        #region IComparer<TRegistro_LanDuplicata> Members
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

        public TList_RegLanDuplicata()
        { }

        public TList_RegLanDuplicata(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanDuplicata value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanDuplicata x, TRegistro_LanDuplicata y)
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

    public class TRegistro_LanDuplicata: ICloneable
    {
        private string cd_empresa;
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set
            {
                cd_empresa = value;
                if (parcelas != null)
                    for (int x = 0; x < parcelas.Count; x++)
                    {
                        parcelas[x].Cd_empresa = cd_empresa;
                        parcelas[x].Nr_lancto = nr_lancto;
                    }
            }
        }
        private decimal nr_lancto;
        public decimal Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                if (parcelas != null)
                    for (int x = 0; x < parcelas.Count; x++)
                    {
                        parcelas[x].Cd_empresa = cd_empresa;
                        parcelas[x].Nr_lancto = nr_lancto;
                    }
            }
        }
        public string Nm_empresa
        {
            get;
            set;
        }
        public string Cd_historico
        {
            get;
            set;
        }
        public string Ds_historico
        {
            get;
            set;
        }
        public string Cd_grupoCF
        { get; set; }
        public string Nr_docto
        {
            get;
            set;
        }
        private string tp_mov;
        public string Tp_mov
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_movimento = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBER";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_mov = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_mov = "R";
            }
        }
        public decimal? Id_lotectb
        { get; set; }
        private decimal vl_documento;
        public decimal Vl_documento
        {
            get { return Math.Round(vl_documento, 2); }
            set { vl_documento = Math.Round(value, 2); }
        }
        private decimal vl_documento_padrao;
        public decimal Vl_documento_padrao
        {
            get { return Math.Round(vl_documento_padrao, 2); }
            set { vl_documento_padrao = Math.Round(value, 2); }
        }
        public string Vl_documentoExtenso
        {
            get
            {
                if (vl_documento_padrao > 0)
                {
                    return new Extenso().ValorExtenso(vl_documento_padrao,
                                                      "REAL",
                                                      "REAIS");
                }
                else
                    return string.Empty;
            }
        }
        private decimal vl_entrada;
        public decimal Vl_entrada
        {
            get { return Math.Round(vl_entrada, 2); }
            set
            {
                if (value >= Vl_documento)
                    vl_entrada = Math.Round(value - 1, 2);
                else
                    vl_entrada = Math.Round(value, 2);
                if (DupCotacao.Operador.Trim().Equals("*"))
                    vl_entrada_padrao = value * DupCotacao.Vl_cotacao;
                else if (DupCotacao.Operador.Trim().Equals("/"))
                    vl_entrada_padrao = value / DupCotacao.Vl_cotacao;
                else
                    vl_entrada_padrao = value;
            }
        }
        private decimal vl_entrada_padrao;
        public decimal Vl_entrada_padrao
        {
            get
            { return Math.Round(vl_entrada_padrao, 2); }
            set
            {
                if (value >= Vl_documento_padrao)
                    vl_entrada_padrao = Math.Round(value - 1, 2);
                else
                    vl_entrada_padrao = Math.Round(value, 2);
                if (DupCotacao.Operador.Trim().Equals("*"))
                    Vl_entrada = value / DupCotacao.Vl_cotacao;
                else if (DupCotacao.Operador.Trim().Equals("/"))
                    Vl_entrada = value * DupCotacao.Vl_cotacao;
                else
                    Vl_entrada = value;
            }
        }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_emissaostring;
        public string Dt_emissaostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostring).ToString("dd/MM/yyyy");
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
                catch { dt_emissao = null; }
            }
        }
        public decimal Qt_parcelas
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
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
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        public decimal Qt_dias_desdobro
        { get; set; }
        public string St_comentrada
        { get; set; }
        public string Tp_juro
        { get; set; }
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        private decimal pc_jurodiario_atrazo;
        public decimal Pc_juromensal_atrazo
        {
            get { return (pc_jurodiario_atrazo * 30); }
            set { pc_jurodiario_atrazo = (value / 30); }
        }
        public string Ds_observacao
        { get; set; }
        public string Complhistorico
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_juro
        { get; set; }
        public string Ds_juro
        { get; set; }
        public string Cd_moeda
        {
            get;
            set;
        }
        public string Ds_moeda
        {
            get;
            set;
        }
        public string Ds_moeda_singular
        { get; set; }
        public string Sigla_moeda
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string tp_doctostring;
        public string Tp_doctostring
        {
            get { return tp_doctostring; }
            set
            {
                tp_doctostring = value;
                try
                {
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_avalista
        { get; set; }
        public string Nm_avalista
        { get; set; }
        public string Cd_endavalista
        { get; set; }
        public string Ds_endavalista
        { get; set; }
        private TList_RegLanParcela parcelas;
        public TList_RegLanParcela Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }
        public TList_RegLanTitulo Titulos
        { get; set; }
        public CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura
        { get; set; }
        private string st_venctoferiado;
        public string St_venctoferiado
        {
            get { return st_venctoferiado; }
            set { st_venctoferiado = value; }
        }
        public string Nm_cliforcontrato
        { get; set; }
        public TList_LanCCustoLancto lCustoLancto
        { get; set; }
        public TList_LanCCustoLancto lCustoLanctoDel
        { get; set; }
        public TList_CentroResultado lCentroResult
        { get; set; }
        public TRegistro_DuplicataCotacao DupCotacao
        { get; set; }
        //CAMPOS AUXILIARES
        public string Cd_historico_Dup
        { get; set; }
        public string Ds_historico_Dup
        { get; set; }
        public string Cd_historico_Juro
        { get; set; }
        public string Ds_historico_Juro
        { get; set; }
        public string Cd_historico_Desconto
        { get; set; }
        public string Ds_historico_Desconto
        { get; set; }
        public decimal Cd_conta_ctb
        { get; set; }
        public string Cd_classif_ctb
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_conta
        { get; set; }
        public bool St_liquidar
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        public string Logincanc
        { get; set; }
        public decimal? Id_caixaoperacional
        { get; set; }
        private decimal? id_configboleto;
        public decimal? Id_configBoleto
        {
            get { return id_configboleto; }
            set
            {
                id_configboleto = value;
                id_configboletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configboletostr;
        public string Id_configboletostr
        {
            get { return id_configboletostr; }
            set
            {
                id_configboletostr = value;
                try
                {
                    id_configboleto = decimal.Parse(value);
                }
                catch { id_configboleto = null; }
            }
        }
        public string Ds_configboleto
        { get; set; }
        //CAMPOS CALCULADOS
        private decimal vl_atual;
        public decimal Vl_atual
        {
            get { return Math.Round(vl_atual, 2); }
            set { vl_atual = Math.Round(value, 2); }
        }
        private decimal vl_vencido;
        public decimal Vl_vencido
        {
            get { return Math.Round(vl_vencido, 2); }
            set { vl_vencido = Math.Round(value, 2); }
        }
        private decimal vl_avencer;
        public decimal Vl_avencer
        {
            get { return Math.Round(vl_avencer, 2); }
            set { vl_avencer = Math.Round(value, 2); }
        }
        private decimal vl_liquidado;
        public decimal Vl_liquidado
        {
            get { return Math.Round(vl_liquidado, 2); }
            set { vl_liquidado = Math.Round(value, 2); }
        }
        public decimal Vl_liq
        { get; set; }
        private decimal cvl_adiantamento;
        public decimal cVl_adiantamento
        {
            get { return Math.Round(cvl_adiantamento, 2); }
            set
            {
                cvl_adiantamento = Math.Round(value, 2);
            }
        }
        public decimal cVl_trocoCH
        { get; set; }
        public decimal cVl_trocoDH
        { get; set; }
        public decimal cVl_adtoCH
        { get; set; }
        public List<TRegistro_LanTitulo> lChTroco
        { get; set; }
        public bool St_AdtoTrocoCH
        { get; set; }
        public List<Adiantamento.TRegistro_LanAdiantamento> lCred
        { get; set; }
        public string MotivoCanc { get; set; } = string.Empty;

        private DateTime? dt_auditavulso;
        public DateTime? Dt_auditavulso
        {
            get { return dt_auditavulso; }
            set
            {
                dt_auditavulso = value;
                dt_auditavulsostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_auditavulsostr;
        public string Dt_auditavulsostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_auditavulsostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_auditavulsostr = value;
                try
                {
                    dt_auditavulso = Convert.ToDateTime(value);
                }
                catch { dt_auditavulso = null; }
            }
        }
        public string LoginAuditAvulso
        { get; set; }
        public bool St_Avulso
        { get; set; }

        public TRegistro_LanDuplicata()
        {
            Id_lotectb = null;
            cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            nr_lancto = decimal.Zero;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_grupoCF = string.Empty;
            Nr_docto = string.Empty;
            Vl_documento = decimal.Zero;
            Vl_documento_padrao = decimal.Zero;
            vl_atual = decimal.Zero;
            vl_vencido = decimal.Zero;
            vl_avencer = decimal.Zero;
            vl_liquidado = decimal.Zero;
            vl_entrada = decimal.Zero;
            dt_emissao = null;
            dt_emissaostring = string.Empty;
            Qt_parcelas = decimal.Zero;
            st_registro = "A";
            status = string.Empty;
            Qt_dias_desdobro = decimal.Zero;
            St_comentrada = string.Empty;
            Tp_juro = string.Empty;
            Pc_jurodiario_atrazo = decimal.Zero;
            Ds_observacao = string.Empty;
            Complhistorico = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_juro = string.Empty;
            Ds_juro = string.Empty;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Ds_moeda_singular = string.Empty;
            Sigla_moeda = string.Empty;
            tp_docto = null;
            tp_doctostring = string.Empty;
            Ds_tpdocto = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Cd_avalista = string.Empty;
            Nm_avalista = string.Empty;
            Cd_endavalista = string.Empty;
            Ds_endavalista = string.Empty;
            parcelas = new TList_RegLanParcela();
            Titulos = new TList_RegLanTitulo();
            lFatura = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
            lCustoLancto = new TList_LanCCustoLancto();
            lCustoLanctoDel = new TList_LanCCustoLancto();
            lCentroResult = new TList_CentroResultado();
            tp_mov = string.Empty;
            tipo_movimento = string.Empty;
            st_venctoferiado = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Vl_desconto = decimal.Zero;
            Cd_contager = string.Empty;
            Ds_conta = string.Empty;
            DupCotacao = new TRegistro_DuplicataCotacao();
            St_liquidar = true;
            Nr_pedido = null;
            Cd_historico_Dup = string.Empty;
            Cd_historico_Juro = string.Empty;
            Cd_historico_Desconto = string.Empty;
            cVl_trocoCH = decimal.Zero;
            cVl_trocoDH = decimal.Zero;
            lChTroco = new List<TRegistro_LanTitulo>();
            cVl_adtoCH = decimal.Zero;
            St_AdtoTrocoCH = false;
            Logincanc = string.Empty;
            Id_caixaoperacional = null;
            id_configboleto = null;
            id_configboletostr = string.Empty;
            Ds_configboleto = string.Empty;
            lCred = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
        }

        public object Clone()
        {
            return (TRegistro_LanDuplicata)MemberwiseClone();
        }
    }

    public class TCD_LanDuplicata : TDataQuery
    {
        public TCD_LanDuplicata()
        { }

        public TCD_LanDuplicata(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        //ANALITICO
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.CD_Empresa, a.Nr_Lancto, a.CD_Historico, a.Nr_Docto, a.VL_Documento, a.Vl_Documento_padrao, a.DT_Emissao, a.QT_Parcelas, a.ST_Registro, a.QT_Dias_Desdobro, ");
                sql.AppendLine("a.ST_ComEntrada, a.TP_Juro, a.PC_JuroDiario_Atrazo, a.DS_Observacao, a.ComplHistorico, a.CD_Clifor, a.CD_Juro, a.CD_Moeda, ");
                sql.AppendLine("a.Tp_Docto, a.TP_Duplicata, a.CD_CondPGTO, a.CD_Endereco, b.NM_Empresa, c.DS_Historico, d.NM_Clifor, e.DS_Juro, f.DS_Moeda_Singular, f.sigla, ");
                sql.AppendLine("g.DS_TpDuplicata, g.TP_Mov, h.DS_Endereco, i.DS_CondPgto, j.DS_TpDocto, HQuitacao.CD_Historico as CD_Historico_Dup, HQuitacao.DS_Historico as DS_Historico_Dup, ");
                sql.AppendLine("HJur.CD_Historico as CD_Historico_Juro, HJur.DS_Historico as DS_Historico_Juro, i.st_venctoemferiado, a.logincanc, ");
                sql.AppendLine("HDes.CD_Historico as CD_Historico_Desconto, HDes.DS_Historico as DS_Historico_Desconto, c.cd_grupocf, a.id_loteCTB, ");
                sql.AppendLine("a.CD_Avalista, av.NM_Clifor as NM_Avalista, a.CD_EndAvalista, endav.DS_Endereco as DS_EndAvalista, pedido.Nr_pedido, a.MotivoCanc, " +
                    "a.DT_AuditAvulso, a.ST_Avulso, a.LoginAuditAvulso, ");
                //Dados cotacao
                sql.AppendLine("dc.login, dc.cd_moeda, m.ds_moeda_singular, m.sigla, dc.cd_moedaresult, mr.ds_moeda_singular as ds_moedaresult, mr.sigla as siglaresult, ");
                sql.AppendLine("dc.vl_cotacao, dc.dt_cotacao, dc.operador, ");

                sql.AppendLine("VL_ATUAL =  (SELECT  sum(DBO.F_CALC_ATUAL(x.CD_Empresa, x.Nr_Lancto, x.Cd_Parcela, Getdate(), 'N' )) ");
                sql.AppendLine("             FROM TB_FIN_PARCELA X where a.cd_empresa = x.cd_empresa and x.nr_lancto = a.nr_lancto ), ");
                sql.AppendLine("VL_VENCIDAS = (SELECT  sum(DBO.F_CALC_ATUAL(x.CD_Empresa, x.Nr_Lancto, x.Cd_Parcela, Getdate(), 'N' )) ");
                sql.AppendLine("             FROM TB_FIN_PARCELA X where a.cd_empresa = x.cd_empresa and x.nr_lancto = a.nr_lancto AND X.DT_VENCTO < Getdate() ), ");
                sql.AppendLine("VL_AVENCER = (SELECT  sum(DBO.F_CALC_ATUAL(x.CD_Empresa, x.Nr_Lancto, x.Cd_Parcela, Getdate(), 'N' )) ");
                sql.AppendLine("             FROM TB_FIN_PARCELA X where a.cd_empresa = x.cd_empresa and x.nr_lancto = a.nr_lancto AND X.DT_VENCTO >= Getdate() ), ");
                sql.AppendLine("VL_LIQUIDADO = (SELECT isNull(sum(isNull(Vl_Liquidacao_Padrao,0)),0) FROM TB_FIN_LIQUIDACAO X  ");
                sql.AppendLine("                  where a.cd_empresa = x.cd_empresa and x.nr_lancto = a.nr_lancto and X.st_registro = 'A' ), ");
                sql.AppendLine("VL_LIQ = (select isNull(sum(isNull(vl_liquidacao,0)),0) from tb_fin_liquidacao x ");
                sql.AppendLine("                    where a.cd_empresa = x.cd_empresa and x.nr_lancto = a.nr_lancto and x.st_registro = 'A' ) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Duplicata a  ");

            sql.AppendLine("INNER JOIN TB_DIV_Empresa b ");
            sql.AppendLine("ON a.CD_Empresa = b.CD_Empresa ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico c ");
            sql.AppendLine("ON a.CD_Historico = c.CD_Historico ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Juro e ");
            sql.AppendLine("ON a.CD_Juro = e.CD_Juro ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda f ");
            sql.AppendLine("ON a.CD_Moeda = f.CD_Moeda ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_TPDocto_Dup j ");
            sql.AppendLine("ON a.Tp_Docto = j.Tp_Docto ");

            sql.AppendLine("INNER JOIN TB_FIN_TPDuplicata g ");
            sql.AppendLine("ON a.TP_Duplicata = g.TP_Duplicata ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_CondPGTO i ");
            sql.AppendLine("ON a.CD_CondPGTO = i.CD_CondPGTO ");

            sql.AppendLine("INNER JOIN VTB_FIN_CLIFOR d ");
            sql.AppendLine("ON a.CD_Clifor = d.CD_Clifor  ");

            sql.AppendLine("INNER JOIN VTB_FIN_ENDERECO h ");
            sql.AppendLine("ON a.CD_Clifor = h.CD_Clifor ");
            sql.AppendLine("AND a.CD_Endereco = h.CD_Endereco ");

            sql.AppendLine("LEFT OUTER JOIN VTB_FIN_CLIFOR av ");
            sql.AppendLine("on a.cd_avalista = av.cd_clifor ");

            sql.AppendLine("LEFT OUTER JOIN VTB_FIN_ENDERECO endav ");
            sql.AppendLine("on a.cd_avalista = endav.cd_clifor ");
            sql.AppendLine("and a.cd_endavalista = endav.cd_endereco ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico HDup ");
            sql.AppendLine("on HDup.CD_Historico = a.CD_Historico ");
            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico HQuitacao ");
            sql.AppendLine("on HDup.CD_Historico_Quitacao = HQuitacao.CD_Historico ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico HJur ");
            sql.AppendLine("on HJur.CD_Historico = G.CD_Historico_Juro ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Historico HDes ");
            sql.AppendLine("on HDes.CD_Historico = G.CD_Historico_Desconto ");

            sql.AppendLine("LEFT OUTER JOIN TB_FAT_Pedido_X_Duplicata pedido ");
            sql.AppendLine("on pedido.Nr_Lancto = a.Nr_Lancto ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Duplicata_Cotacao dc ");
            sql.AppendLine("on a.cd_empresa = dc.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = dc.nr_lancto ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda m ");
            sql.AppendLine("on dc.cd_moeda = m.cd_moeda ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda mr ");
            sql.AppendLine("on dc.cd_moedaresult = mr.cd_moeda ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaFluxoCaixa(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.DT_Vencto, ");
            sql.AppendLine("sum(case when c.TP_MOV = 'P' then DBO.F_CALC_ATUAL(a.CD_Empresa, a.Nr_Lancto, b.CD_Parcela, b.DT_Vencto, 'N') else 0 end) as vl_pagar, ");
            sql.AppendLine("sum(case when c.TP_MOV = 'R' then DBO.F_CALC_ATUAL(a.CD_Empresa, a.Nr_Lancto, b.CD_Parcela, b.DT_Vencto, 'N') else 0 end) as vl_receber ");
            sql.AppendLine("from tb_fin_duplicata a ");
            sql.AppendLine("inner join tb_fin_parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by b.DT_Vencto ");
            sql.AppendLine("order by b.DT_Vencto ");
            return sql.ToString();
        }

        public DataTable BuscarFluxoCaixa(TpBusca[] vBusca)
        { return ExecutarBusca(SqlCodeBuscaFluxoCaixa(vBusca), null); }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return executarEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_RegLanDuplicata Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RegLanDuplicata lista = new TList_RegLanDuplicata();

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(true);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanDuplicata reg = new TRegistro_LanDuplicata();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico"))))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupocf")))
                        reg.Cd_grupoCF = reader.GetString(reader.GetOrdinal("cd_grupocf"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Docto"))))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("NR_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Mov"))))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_Mov"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Documento"))))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("Vl_Documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Documento_Padrao")))
                        reg.Vl_documento_padrao = reader.GetDecimal(reader.GetOrdinal("Vl_Documento_Padrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_ATUAL"))))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("VL_ATUAL"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_VENCIDAS"))))
                        reg.Vl_vencido = reader.GetDecimal(reader.GetOrdinal("VL_VENCIDAS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_AVENCER"))))
                        reg.Vl_avencer = reader.GetDecimal(reader.GetOrdinal("VL_AVENCER"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_LIQUIDADO"))))
                        reg.Vl_liquidado = reader.GetDecimal(reader.GetOrdinal("VL_LIQUIDADO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_LIQ")))
                        reg.Vl_liq = reader.GetDecimal(reader.GetOrdinal("VL_LIQ"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Parcelas"))))
                        reg.Qt_parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Dias_Desdobro"))))
                        reg.Qt_dias_desdobro = reader.GetDecimal(reader.GetOrdinal("QT_Dias_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_ComEntrada"))))
                        reg.St_comentrada = reader.GetString(reader.GetOrdinal("ST_ComEntrada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Juro"))))
                        reg.Tp_juro = reader.GetString(reader.GetOrdinal("TP_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo"))))
                        reg.Pc_jurodiario_atrazo = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ComplHistorico"))))
                        reg.Complhistorico = reader.GetString(reader.GetOrdinal("ComplHistorico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Juro"))))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("CD_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Juro"))))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("DS_juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular"))))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla_moeda = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Docto"))))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("TP_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDocto"))))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("DS_TpDocto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Duplicata"))))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata"))))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPgto"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPgto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CondPgto"))))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_venctoemferiado")))
                        reg.St_venctoferiado = reader.GetString(reader.GetOrdinal("st_venctoemferiado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Endereco"))))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Dup"))))
                        reg.Cd_historico_Dup = reader.GetString(reader.GetOrdinal("CD_Historico_Dup"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_Dup"))))
                        reg.Ds_historico_Dup = reader.GetString(reader.GetOrdinal("DS_Historico_Dup"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Juro"))))
                        reg.Cd_historico_Juro = reader.GetString(reader.GetOrdinal("CD_Historico_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_Juro"))))
                        reg.Ds_historico_Juro = reader.GetString(reader.GetOrdinal("DS_Historico_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Desconto"))))
                        reg.Cd_historico_Desconto = reader.GetString(reader.GetOrdinal("CD_Historico_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_Desconto"))))
                        reg.Ds_historico_Desconto = reader.GetString(reader.GetOrdinal("DS_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Avalista")))
                        reg.Cd_avalista = reader.GetString(reader.GetOrdinal("CD_Avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Avalista")))
                        reg.Nm_avalista = reader.GetString(reader.GetOrdinal("NM_Avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndAvalista")))
                        reg.Cd_endavalista = reader.GetString(reader.GetOrdinal("CD_EndAvalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndAvalista")))
                        reg.Ds_endavalista = reader.GetString(reader.GetOrdinal("DS_EndAvalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logincanc")))
                        reg.Logincanc = reader.GetString(reader.GetOrdinal("logincanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Id_lotectb = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    //Dados cotacao
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.DupCotacao.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moeda")))
                        reg.DupCotacao.Cd_moeda = reader.GetString(reader.GetOrdinal("cd_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moeda_singular")))
                        reg.DupCotacao.Ds_moeda = reader.GetString(reader.GetOrdinal("ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.DupCotacao.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moedaresult")))
                        reg.DupCotacao.Cd_moedaresult = reader.GetString(reader.GetOrdinal("cd_moedaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moedaresult")))
                        reg.DupCotacao.Ds_moedaresult = reader.GetString(reader.GetOrdinal("ds_moedaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("siglaresult")))
                        reg.DupCotacao.Siglaresult = reader.GetString(reader.GetOrdinal("siglaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cotacao")))
                        reg.DupCotacao.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("vl_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cotacao")))
                        reg.DupCotacao.Dt_cotacao = reader.GetDateTime(reader.GetOrdinal("dt_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("operador")))
                        reg.DupCotacao.Operador = reader.GetString(reader.GetOrdinal("operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DT_AuditAvulso")))
                        reg.Dt_auditavulso = reader.GetDateTime(reader.GetOrdinal("DT_AuditAvulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Avulso")))
                        reg.St_Avulso = reader.GetBoolean(reader.GetOrdinal("ST_Avulso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAuditAvulso")))
                        reg.LoginAuditAvulso = reader.GetString(reader.GetOrdinal("LoginAuditAvulso"));

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

        public string GravaDuplicata(TRegistro_LanDuplicata val)
        {
            Hashtable hs = new Hashtable(24);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_NR_DOCTO", val.Nr_docto);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_VL_DOCUMENTO", val.Vl_documento);
            hs.Add("@P_VL_DOCUMENTO_PADRAO", val.Vl_documento_padrao);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_COMPLHISTORICO", val.Complhistorico);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_CD_AVALISTA", val.Cd_avalista);
            hs.Add("@P_CD_ENDAVALISTA", val.Cd_endavalista);
            hs.Add("@P_LOGINCANC", val.Logincanc);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_AVULSO", val.St_Avulso);
            hs.Add("@P_LOGINAUDITAVULSO", val.LoginAuditAvulso);
            hs.Add("@P_DT_AUDITAVULSO", val.Dt_auditavulso);

            return executarProc("IA_FIN_DUPLICATA", hs);
        }
    }

    #endregion

    #region "Duplicata Cotacao"
    public class TList_DuplicataCotacao : List<TRegistro_DuplicataCotacao>, IComparer<TRegistro_DuplicataCotacao>
    {
        #region IComparer<TRegistro_DuplicataCotacao> Members
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

        public TList_DuplicataCotacao()
        { }

        public TList_DuplicataCotacao(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DuplicataCotacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DuplicataCotacao x, TRegistro_DuplicataCotacao y)
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


    public class TRegistro_DuplicataCotacao
    {

        public string Cd_empresa
        { get; set; }

        public decimal Nr_lancto
        { get; set; }

        public string Cd_moeda
        { get; set; }

        public string Ds_moeda
        { get; set; }

        public string Sigla
        { get; set; }

        public string Cd_moedaresult
        { get; set; }

        public string Ds_moedaresult
        { get; set; }

        public string Siglaresult
        { get; set; }

        public decimal Vl_cotacao
        { get; set; }

        private DateTime? dt_cotacao;

        public DateTime? Dt_cotacao
        {
            get { return dt_cotacao; }
            set
            {
                dt_cotacao = value;
                dt_cotacaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }

        private string dt_cotacaostring;
        public string Dt_cotacaostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cotacaostring).ToString("dd/MM/yyyy");
                }
                catch
                { return null; }
            }
            set
            {
                dt_cotacaostring = value;
                try
                {
                    dt_cotacao = Convert.ToDateTime(value);
                }
                catch
                { dt_cotacao = null; }
            }
        }

        public string Login
        { get; set; }

        public string Operador
        { get; set; }

        public TRegistro_DuplicataCotacao()
        {
            Cd_empresa = string.Empty;
            Nr_lancto = 0;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Cd_moedaresult = string.Empty;
            Ds_moedaresult = string.Empty;
            Siglaresult = string.Empty;
            Vl_cotacao = 0;
            Operador = string.Empty;
            dt_cotacao = null;
            dt_cotacaostring = string.Empty;
            Login = string.Empty;
        }
    }

    public class TCD_DuplicataCotacao : TDataQuery
    {
        public TCD_DuplicataCotacao()
        { }

        public TCD_DuplicataCotacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" Select " + strTop + " a.cd_empresa, a.nr_lancto, ");
                sql.AppendLine("a.cd_moeda, b.ds_moeda_singular as ds_moeda, b.sigla, ");
                sql.AppendLine("a.cd_moedaresult, c.ds_moeda_singular as ds_moedaresult, c.sigla as siglaresult, ");
                sql.AppendLine("a.vl_cotacao, a.operador, a.dt_cotacao, a.login ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_duplicata_cotacao a ");
            sql.AppendLine("inner join tb_fin_moeda b ");
            sql.AppendLine("on a.cd_moeda = b.cd_moeda ");
            sql.AppendLine("inner join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moedaresult = c.cd_moeda ");

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

        public TList_DuplicataCotacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DuplicataCotacao lista = new TList_DuplicataCotacao();
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
                    TRegistro_DuplicataCotacao reg = new TRegistro_DuplicataCotacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda"))))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla"))))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MoedaResult"))))
                        reg.Cd_moedaresult = reader.GetString(reader.GetOrdinal("CD_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MoedaResult"))))
                        reg.Ds_moedaresult = reader.GetString(reader.GetOrdinal("DS_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("SiglaResult"))))
                        reg.Siglaresult = reader.GetString(reader.GetOrdinal("SiglaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Cotacao"))))
                        reg.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("Vl_Cotacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Operador"))))
                        reg.Operador = reader.GetString(reader.GetOrdinal("Operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cotacao")))
                        reg.Dt_cotacao = reader.GetDateTime(reader.GetOrdinal("DT_Cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));

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

        public string GravarDuplicataCotacao(TRegistro_DuplicataCotacao val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_MOEDARESULT", val.Cd_moedaresult);
            hs.Add("@P_VL_COTACAO", val.Vl_cotacao);
            hs.Add("@P_OPERADOR", val.Operador);
            hs.Add("@P_DT_COTACAO", val.Dt_cotacao);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("IA_FIN_DUPLICATA_COTACAO", hs);
        }

        public string DeletarDuplicataCotacao(TRegistro_DuplicataCotacao val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_FIN_DUPLICATA_COTACAO", hs);
        }
    }
    #endregion"

    #region "Parcelas"
    public class TList_CliforAgrupar : List<TRegistro_CliforAgrupar>, IComparer<TRegistro_CliforAgrupar>
    {
        #region IComparer<TRegistro_CliforAgrupar> Members
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

        public TList_CliforAgrupar()
        { }

        public TList_CliforAgrupar(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CliforAgrupar value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CliforAgrupar x, TRegistro_CliforAgrupar y)
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
    //Classe auxiliar de parcelas agrupar posto combustivel por cliente

    public class TRegistro_CliforAgrupar
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public decimal Qt_diasdesdobro
        { get; set; }
        public DateTime? Dt_agrupamento
        { get; set; }
        public decimal? Id_convenio
        { get; set; }
        public decimal? Id_configBoleto
        { get; set; }
        public string Ds_condigBoleto
        { get; set; }
        public decimal Vl_agrupar
        { get; set; }

        public TRegistro_CliforAgrupar()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Qt_diasdesdobro = decimal.Zero;
            Dt_agrupamento = null;
            Id_convenio = null;
            Id_configBoleto = null;
            Ds_condigBoleto = string.Empty;
            Vl_agrupar = decimal.Zero;
        }
    }

    public class TList_RegLanParcela : List<TRegistro_LanParcela>, IComparer<TRegistro_LanParcela>
    {
        #region IComparer<TRegistro_LanParcela> Members
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

        public TList_RegLanParcela()
        { }

        public TList_RegLanParcela(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanParcela value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanParcela x, TRegistro_LanParcela y)
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

    public class TRegistro_LanParcela: ICloneable
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch
                { cd_parcela = null; }
            }
        }
        public decimal? QT_Parcelas
        { get; set; }
        public string NR_Parcelas
        {
            get
            {
                if (cd_parcela.HasValue)
                    return cd_parcela.Value.ToString() + (QT_Parcelas.HasValue ? "/" + QT_Parcelas.Value.ToString() : string.Empty);
                else return string.Empty;
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
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        private DateTime? dt_vencto;
        public DateTime? Dt_vencto
        {
            get { return dt_vencto; }
            set
            {
                dt_vencto = value;
                dt_venctostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_venctostring;
        public string Dt_venctostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_venctostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_venctostring = value;
                try
                {
                    dt_vencto = Convert.ToDateTime(value);
                }
                catch
                { dt_vencto = null; }
            }
        }
        private decimal vl_parcela;
        public decimal Vl_parcela
        {
            get { return Math.Round(vl_parcela, 2); }
            set
            {
                vl_parcela = Math.Round(value, 2);
                if (Cd_moeda.Trim() != Cd_moedaresult.Trim())
                    if (Operador.Trim().Equals("*"))
                        vl_parcela_padrao = Math.Round(Math.Round(value, 2) * Vl_cotacao, 2);
                    else if (Operador.Trim().Equals("/"))
                    {
                        if (Vl_cotacao > 0)
                            vl_parcela_padrao = Math.Round(Math.Round(value, 2) / Vl_cotacao, 2);
                    }
                    else
                        vl_parcela_padrao = Math.Round(value, 2);
                else
                    vl_parcela_padrao = Math.Round(value, 2);
            }
        }
        public bool St_CalcVl_Parcela
        { get; set; }
        private decimal vl_parcela_padrao;
        public decimal Vl_parcela_padrao
        {
            get { return Math.Round(vl_parcela_padrao, 2); }
            set
            {
                vl_parcela_padrao = Math.Round(value, 2);
                if (St_CalcVl_Parcela)
                {
                    if (Cd_moeda.Trim().Equals(Cd_moedaresult.Trim()))
                        vl_parcela = Math.Round(value, 2);
                    else
                    {
                        if (Operador.Trim().Equals("*"))
                        {
                            if (Vl_cotacao > 0)
                                vl_parcela = Math.Round(Math.Round(value, 2) / Vl_cotacao, 2);
                        }
                        else if (Operador.Trim().Equals("/"))
                            vl_parcela = Math.Round(Math.Round(value, 2) * Vl_cotacao, 2);
                        else
                            vl_parcela = Math.Round(value, 2);
                    }
                }
                if (Tp_mov.Trim().ToUpper().Equals("R"))
                    vl_juro = Math.Round(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN), 2);
            }
        }
        private decimal vl_juro;
        public decimal Vl_juro
        {
            get { return Math.Round(vl_juro, 2); }
            set { vl_juro = Math.Round(value, 2); }
        }
        private decimal vl_desconto;
        public decimal Vl_desconto
        {
            get
            {
                decimal tmp = ((vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN) - vl_atual);
                if (tmp > 0)
                    return Math.Round(tmp, 2);
                else
                    return 0;
            }
            set { vl_desconto = Math.Round(value, 2); }
        }
        private decimal vl_juroliquid;
        public decimal Vl_JuroLiquid
        {
            get { return Math.Round(vl_juroliquid, 2); }
            set { vl_juroliquid = Math.Round(value, 2); }
        }
        private decimal vl_descliquid;
        public decimal Vl_DescLiquid
        {
            get { return Math.Round(vl_descliquid, 2); }
            set { vl_descliquid = Math.Round(value, 2); }
        }
        private decimal vl_atual;
        public decimal Vl_atual
        {
            get { return Math.Round(vl_atual, 2); }
            set
            {
                vl_atual = Math.Round(value, 2);
                if (Tp_mov.Trim().ToUpper().Equals("R"))
                    vl_juro = Math.Round(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN), 2);
            }
        }
        public decimal cVl_atual
        { get; set; }
        private decimal vl_liquidado;
        public decimal Vl_liquidado
        {
            get { return Math.Round(vl_liquidado, 2); }
            set
            {
                vl_liquidado = Math.Round(value, 2);
                if (Tp_mov.Trim().ToUpper().Equals("R"))
                    vl_juro = Math.Round(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN), 2);
            }
        }
        public decimal Vl_troco
        { get; set; }
        public decimal Vl_devcredito
        { get; set; }
        public decimal Vl_devolucaoFIN
        { get; set; }
        public string Vl_atualextenso
        {
            get
            {
                if (cVl_atual > 0)
                {
                    return new Extenso().ValorExtenso(cVl_atual,
                                                      Ds_moeda,
                                                      Ds_moeda_plural);
                }
                else
                    return string.Empty;
            }
        }
        public TList_RegLanLiquidacao Liquidacoes
        { get; set; }
        public string St_cobranca
        { get; set; }
        public bool St_cobrancabool
        { get { return St_cobranca.Trim().ToUpper().Equals("S"); } }
        public string St_registro
        { get; set; }
        public string Tp_mov
        { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_mov.Trim().ToUpper().Equals("P"))
                    return "PAGAR";
                else if (Tp_mov.Trim().ToUpper().Equals("R"))
                    return "RECEBER";
                else return string.Empty;
            }
        }
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Ds_moeda_plural
        { get; set; }
        public string Cd_moedaresult
        { get; set; }
        public string Sigla
        { get; set; }
        public decimal cVl_DifCamb_Ativa
        {
            get
            {
                if (Tp_mov.Trim().ToUpper().Equals("P"))
                    if ((vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)) < 0)
                        if ((!string.IsNullOrEmpty(Cd_moeda)) &&
                            (!string.IsNullOrEmpty(Cd_moedaresult)) &&
                            (!Cd_moeda.Trim().Equals(Cd_moedaresult.Trim())))
                            return Math.Round(Math.Abs(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)), 2);
                        else
                            return decimal.Zero;
                    else
                        return decimal.Zero;
                else if (Tp_mov.Trim().ToUpper().Equals("R"))
                    if ((vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)) > 0)
                        if ((!string.IsNullOrEmpty(Cd_moeda)) &&
                            (!string.IsNullOrEmpty(Cd_moedaresult)) &&
                            (!Cd_moeda.Trim().Equals(Cd_moedaresult.Trim())))
                            return Math.Round(Math.Abs(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)), 2);
                        else
                            return decimal.Zero;
                    else
                        return decimal.Zero;
                else
                    return decimal.Zero;
            }
        }
        public decimal cVl_DifCamb_Passiva
        {
            get
            {
                if (Tp_mov.Trim().ToUpper().Equals("P"))
                    if ((vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)) > 0)
                    {
                        if ((!string.IsNullOrEmpty(Cd_moeda)) &&
                            (!string.IsNullOrEmpty(Cd_moedaresult)) &&
                            (!Cd_moeda.Trim().Equals(Cd_moedaresult.Trim())))
                            return Math.Round(Math.Abs(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)), 2);
                        else
                            return decimal.Zero;
                    }
                    else
                        return decimal.Zero;
                else if (Tp_mov.Trim().ToUpper().Equals("R"))
                    if ((vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)) < 0)
                        if ((!string.IsNullOrEmpty(Cd_moeda)) &&
                            (!string.IsNullOrEmpty(Cd_moedaresult)) &&
                            (!Cd_moeda.Trim().Equals(Cd_moedaresult.Trim())))
                            return Math.Round(Math.Abs(vl_atual - (vl_parcela_padrao - vl_liquidado - Vl_devolucaoFIN)), 2);
                        else
                            return decimal.Zero;
                    else
                        return decimal.Zero;
                else
                    return decimal.Zero;
            }
        }
        public Bloqueto.blTitulo Bloqueto
        { get; set; }
        public Cobranca.TList_CobrancaClifor lCobranca
        { get; set; }
        public bool St_bloquetobool
        { get; set; }
        public bool St_cobrar
        { get; set; }
        public string Nr_docto
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cnpj_cpf
        { get; set; } = string.Empty;
        public string Cd_endereco
        { get; set; }
        public decimal? Id_categoriaclifor
        { get; set; }
        public string Ds_categoriaclifor
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_historico_desconto
        { get; set; }
        public string Cd_historico_juro
        { get; set; }
        public string Cd_historico_dcamb_at
        { get; set; }
        public string Cd_historico_dcamb_pa
        { get; set; }
        public string Cd_historico_troco
        { get; set; }
        public string Cd_portadoragrupar
        { get; set; }
        public string complHistorico
        { get; set; }
        public string Cd_contageragrupar
        { get; set; }
        public string Cd_historicoagrup
        { get; set; }
        public string Cd_historicoquitacaoagrup
        { get; set; }
        public string Cd_portadorperdadup
        { get; set; }
        public string Cd_contagerperdadup
        { get; set; }
        public string Cd_historicoperdadup
        { get; set; }
        public string Cd_historicoquitperdadup
        { get; set; }
        public decimal Vl_difcambAT
        { get; set; }
        public decimal Vl_difcambPA
        { get; set; }
        public string Nossonumero
        { get; set; }
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public decimal? Tp_docto
        { get; set; }
        public string Operador
        { get; set; }
        public decimal Vl_cotacao
        { get; set; }
        public string Status_parcela
        { get; set; }
        public decimal? NR_LanctoAgrupador
        { get; set; }
        public string St_agrupador
        { get; set; }
        public string Status_agrupador
        {
            get
            {
                if (St_agrupador.Trim().ToUpper().Equals("S"))
                    return "SIM";
                else if (St_agrupador.Trim().ToUpper().Equals("N"))
                    return "NÃO";
                else return string.Empty;
            }
        }
        public decimal Vl_agrupado
        { get; set; }
        private decimal? id_cooECF;
        public decimal? Id_cooECF
        {
            get { return id_cooECF; }
            set
            {
                id_cooECF = value;
                id_cooECFstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cooECFstr;
        public string Id_cooECFstr
        {
            get { return id_cooECFstr; }
            set
            {
                id_cooECFstr = value;
                try
                {
                    id_cooECF = decimal.Parse(value);
                }
                catch
                { id_cooECF = null; }
            }
        }
        //Campo utilizado somente para guardar a liquidacao correspondente a parcela no momento de gravar a liquidacao agrupamento
        public decimal? Id_liquidAgrupar
        { get; set; }
        public string Nr_placa
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_LanParcela()
        {
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Ds_moeda_plural = string.Empty;
            Cd_moedaresult = string.Empty;
            Operador = string.Empty;
            Vl_cotacao = decimal.Zero;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            cd_parcela = null;
            cd_parcelastr = string.Empty;
            QT_Parcelas = null;
            dt_emissao = null;
            dt_emissaostr = string.Empty;
            dt_vencto = null;
            dt_venctostring = string.Empty;
            vl_parcela = decimal.Zero;
            vl_juro = decimal.Zero;
            vl_desconto = decimal.Zero;
            vl_atual = decimal.Zero;
            cVl_atual = decimal.Zero;
            St_registro = "A";
            St_cobranca = "S";
            Tp_mov = string.Empty;
            Bloqueto = new Bloqueto.blTitulo();
            St_bloquetobool = false;
            Liquidacoes = new TList_RegLanLiquidacao();
            Id_liquidAgrupar = null;
            lCobranca = new Cobranca.TList_CobrancaClifor();
            St_cobrar = true;
            Nr_docto = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Id_categoriaclifor = null;
            Ds_categoriaclifor = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_historico_desconto = string.Empty;
            Cd_historico_juro = string.Empty;
            Cd_historico_dcamb_at = string.Empty;
            Cd_historico_dcamb_pa = string.Empty;
            Cd_historico_troco = string.Empty;
            complHistorico = string.Empty;
            Cd_portadoragrupar = string.Empty;
            Cd_contageragrupar = string.Empty;
            Cd_historicoagrup = string.Empty;
            Cd_historicoquitacaoagrup = string.Empty;
            Cd_portadorperdadup = string.Empty;
            Cd_contagerperdadup = string.Empty;
            Cd_historicoperdadup = string.Empty;
            Cd_historicoquitperdadup = string.Empty;
            Vl_difcambAT = decimal.Zero;
            Vl_difcambPA = decimal.Zero;
            Nossonumero = string.Empty;
            Pc_jurodiario_atrazo = decimal.Zero;
            Tp_duplicata = string.Empty;
            Tp_docto = null;
            NR_LanctoAgrupador = null;
            St_agrupador = string.Empty;
            Vl_agrupado = decimal.Zero;
            Status_parcela = string.Empty;
            St_processar = false;
            Vl_troco = decimal.Zero;
            Vl_devcredito = decimal.Zero;
            Vl_devolucaoFIN = decimal.Zero;
            id_cooECF = null;
            id_cooECFstr = string.Empty;
            Nr_placa = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_LanParcela : TDataQuery
    {
        public TCD_LanParcela()
        { }

        public TCD_LanParcela(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder, string vGroup)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.Nr_Lancto, a.tp_mov, ");
                sql.AppendLine("a.CD_Parcela, a.DT_Vencto, a.Vl_Parcela, a.Vl_Parcela_Padrao, dup.tp_docto, ");
                sql.AppendLine("a.ST_Registro, a.nr_docto, a.cd_clifor, c.NM_Clifor, a.tp_duplicata, ");
                sql.AppendLine("case when c.tp_pessoa = 'J' then c.nr_cgc else c.nr_cpf end as cnpj_cpf, ");
                sql.AppendLine("c.Id_CategoriaClifor, c.DS_CategoriaClifor, a.DT_Emissao, a.QT_Parcelas, ");
                sql.AppendLine("a.CD_Historico, d.DS_Historico, a.status_parcela, dup.cd_endereco, ");
                sql.AppendLine("a.Vl_CalcAtual, a.Vl_Atual, a.Vl_Liquidado, a.Vl_Juro, ");
                sql.AppendLine("a.Vl_Desconto, a.Vl_DifCamb_AT, a.Vl_DifCamb_PA, a.operador, a.vl_cotacao, ");
                sql.AppendLine("a.Nosso_Numero, a.ST_Cobranca, a.CD_Moeda, a.CD_MoedaResult, ");
                sql.AppendLine("e.DS_Moeda_Plural, e.DS_Moeda_Singular, e.Sigla, a.id_cupom, ");
                sql.AppendLine("a.PC_JuroDiario_Atrazo, a.vl_troco, a.vl_devcredito, a.vl_devolucaoFIN, ");
                sql.AppendLine("a.cd_historico_desconto, a.cd_historico_juro, a.CD_HISTORICO_TROCOCH, ");
                sql.AppendLine("a.CD_Historico_DCamb_Ativa, a.CD_Historico_DCamb_Passiva, a.cd_historicoquitacaoagrup, ");
                sql.AppendLine("a.cd_portadorperdadup, a.cd_contagerperdadup, a.cd_historicoperdadup, a.cd_historicoquitperdadup, ");
                sql.AppendLine("a.cd_portadoragrupar, a.cd_contageragrupar, a.NR_LanctoAgrupador, ");
                sql.AppendLine("a.st_agrupador, a.vl_agrupado, a.complHistorico, a.cd_historicoagrup, ");
                sql.AppendLine("Nr_placa = (select top 1 y.PlacaVeiculo ");
                sql.AppendLine("			from TB_PDV_CupomFiscal_X_Duplicata x ");
                sql.AppendLine("			inner join TB_PDC_VendaCombustivel y ");
                sql.AppendLine("			on x.CD_Empresa = y.CD_Empresa ");
                sql.AppendLine("			and x.Id_Cupom = y.Id_Cupom ");
                sql.AppendLine("			where x.CD_Empresa = a.CD_Empresa ");
                sql.AppendLine("			and x.Nr_Lancto = a.Nr_Lancto) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIN_PARCELA a ");
            sql.AppendLine("inner join TB_FIN_Duplicata dup ");
            sql.AppendLine("on a.cd_empresa = dup.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = dup.nr_lancto ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.cd_clifor = c.CD_Clifor ");
            sql.AppendLine("inner join TB_FIN_Historico d ");
            sql.AppendLine("on a.CD_Historico = d.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_Moeda e ");
            sql.AppendLine("on a.cd_moeda = e.CD_Moeda ");
            sql.AppendLine("inner join TB_FIN_TpDuplicata t ");
            sql.AppendLine("on dup.tp_duplicata = t.tp_duplicata ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());

            return sql.ToString();
        }

        private string SqlCodeBuscaRelGeralContas(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, d.nm_empresa, a.cd_clifor, b.tp_mov, ");
            sql.AppendLine("e.nm_clifor, f.fone, a.nr_docto, a.nr_lancto, c.st_registro, ");
            sql.AppendLine("RTrim(convert(char(3), c.cd_parcela))+'/'+LTrim(convert(char(3), a.qt_parcelas)) as parcela, ");
            sql.AppendLine("c.vl_parcela_padrao, a.dt_emissao, c.dt_vencto, ");
            sql.AppendLine("dupcot.cd_moeda, mOrigem.sigla as sg_moeda, ");
            sql.AppendLine("dupcot.cd_moedaresult, mDestino.sigla as sg_moedaresult, dupcot.vl_cotacao, ");
            //Valor Cotação Atual
            sql.AppendLine("vl_cotacao_atual = isNull((select top 1 isNull(x.valor,0) from tb_fin_cotacaomoeda x ");
            sql.AppendLine("				where x.cd_moeda = dupcot.cd_moeda ");
            sql.AppendLine("				and x.cd_moedaresult = dupcot.cd_moedaresult ");
            sql.AppendLine("				and x.data <= getDate() ");
            sql.AppendLine("				and isNull(x.st_registro, 'A') <> 'C' ");
            sql.AppendLine("				order by x.data desc),0), ");
            //Valor Atual
            sql.AppendLine("vl_atual = isNull(dbo.F_CALC_ATUAL(c.cd_empresa, c.nr_lancto, c.cd_parcela, getDate(), 'S'),0), ");
            //Valor Liquidado
            sql.AppendLine("vl_liquidado = isNull((select sum(isNull(x.vl_liquidacao_padrao,0)) from tb_fin_liquidacao x ");
            sql.AppendLine("				where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("				and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C'),0), ");
            //Valor Juro
            sql.AppendLine("vl_juro = isNull((select sum(isNull(x.vl_juroacrescimo,0)) from tb_fin_liquidacao x ");
            sql.AppendLine("			where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("			and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C'),0), ");
            //Valor Desconto
            sql.AppendLine("vl_desconto = isNull((select sum(isNull(x.vl_descontobonus,0)) from tb_fin_liquidacao x ");
            sql.AppendLine("				where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("				and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C'),0), ");
            // Valor Diferença Cambial Ativa
            sql.AppendLine("vl_difcamb_at = isNull((select sum(isNull(x.vl_difcamb_at,0)) from tb_fin_liquidacao x ");
            sql.AppendLine("				where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("				and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C'),0), ");
            //Valor Diferença Cambial Passiva
            sql.AppendLine("vl_difcamb_pa = isNull((select sum(isNull(x.vl_difcamb_pa,0)) from tb_fin_liquidacao x ");
            sql.AppendLine("				where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("				and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C'),0), ");
            //Data Ultima Liquidação
            sql.AppendLine("dt_liquidacao = (select max(x.dt_liquidacao) from tb_fin_liquidacao x ");
            sql.AppendLine("				where x.cd_empresa = c.cd_empresa and x.nr_lancto = c.nr_lancto ");
            sql.AppendLine("				and x.cd_parcela = c.cd_parcela and isNull(x.st_registro, 'A') <> 'C') ");

            sql.AppendLine("from tb_fin_duplicata a ");
            sql.AppendLine("inner join tb_fin_tpduplicata b ");
            sql.AppendLine("on a.tp_duplicata = b.tp_duplicata ");
            sql.AppendLine("inner join tb_fin_parcela c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco f ");
            sql.AppendLine("on a.cd_clifor = f.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = f.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_duplicata_cotacao dupcot ");
            sql.AppendLine("on a.cd_empresa = dupcot.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = dupcot.nr_lancto ");
            sql.AppendLine("left outer join tb_fin_moeda mOrigem ");
            sql.AppendLine("on dupcot.cd_moeda = mOrigem.cd_moeda ");
            sql.AppendLine("left outer join tb_fin_moeda mDestino ");
            sql.AppendLine("on dupcot.cd_moedaresult = mDestino.cd_moeda ");


            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order by e.nm_clifor, dt_liquidacao");
            return sql.ToString();
        }

        private string SqlCodeBuscaRelExtratoContas(TpBusca[] filtro, string vTp_relatorio, string vCd_contager)
        {
            StringBuilder sql = new StringBuilder();
            if (vTp_relatorio.Trim().ToUpper() != "L")
            {
                sql.AppendLine("select a.cd_empresa, e.nm_empresa, a.nr_lancto, a.cd_clifor, d.nm_clifor, mDup.sigla as sg_moeda, ");
                sql.AppendLine("RTrim(a.nr_docto)+'/'+convert(varchar(3),c.cd_parcela) as doctoparc, c.dt_vencto, mPad.sigla as sg_moeda_padrao, ");
                sql.AppendLine("a.tp_duplicata, b.tp_mov, a.dt_emissao as data, c.vl_parcela, isnull(f.vl_cotacao,0) as vl_cotacao, ");
                sql.AppendLine("c.vl_parcela_padrao, '' as cd_contager, '' as ds_contager, 0 as cd_lanctocaixa_liq, null as dt_caixa, ");
                sql.AppendLine("0 as cd_lanctocaixa_juro, 0 as cd_lanctocaixa_desc, 0 as cd_lanctocaixa_dcambat, ");
                sql.AppendLine("0 as cd_lanctocaixa_dcambpa, 0 as vl_quitacao, 0 as vl_juro, 0 as vl_desconto, ");
                sql.AppendLine("0 as vl_difcamb_at, 0 as vl_difcamb_pa ");
                sql.AppendLine("from tb_fin_duplicata a ");
                sql.AppendLine("inner join tb_fin_tpduplicata b ");
                sql.AppendLine("on a.tp_duplicata = b.tp_duplicata ");
                sql.AppendLine("inner join tb_fin_parcela c ");
                sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
                sql.AppendLine("inner join tb_fin_clifor d ");
                sql.AppendLine("on a.cd_clifor = d.cd_clifor ");
                sql.AppendLine("inner join tb_div_empresa e ");
                sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
                sql.AppendLine("inner join tb_fin_duplicata_cotacao f ");
                sql.AppendLine("on a.cd_empresa = f.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = f.nr_lancto ");
                sql.AppendLine("inner join tb_fin_moeda mDup ");
                sql.AppendLine("on f.cd_moeda = mDup.cd_moeda ");
                sql.AppendLine("inner join tb_fin_moeda mPad ");
                sql.AppendLine("on f.cd_moedaresult = mPad.cd_moeda ");
                sql.AppendLine("where isnull(a.st_registro, 'A') = 'A' ");
                if (filtro != null)
                {
                    string cond = " and ";
                    for (int i = 0; i < filtro.Length; i++)
                        sql.AppendLine(cond + "(" + filtro[i].vNM_Campo.Trim() + " " + filtro[i].vOperador.Trim() + " " + filtro[i].vVL_Busca.Trim() + ")");
                }
            }
            if (vTp_relatorio.Trim().ToUpper().Equals("T"))
                sql.AppendLine(" union all ");
            if (vTp_relatorio.Trim().ToUpper() != "P")
            {
                sql.AppendLine("select a.cd_empresa, e.nm_empresa, a.nr_lancto, a.cd_clifor, d.nm_clifor, mDup.sigla as sg_moeda, ");
                sql.AppendLine("RTrim(a.nr_docto)+'/'+convert(varchar(3),c.cd_parcela) as doctoparc, c.dt_vencto, mPad.sigla as sg_moeda_padrao, ");
                sql.AppendLine("a.tp_duplicata, b.tp_mov, g.dt_liquidacao as data, 0 as vl_parcela, 0 as vl_cotacao, ");
                sql.AppendLine("0 as vl_parcela_padrao, g.cd_contager, h.ds_contager, cLiq.cd_lanctocaixa as cd_lanctocaixa_liq, cLiq.dt_lancto as dt_caixa, ");
                sql.AppendLine("cJuro.cd_lanctocaixa as cd_lanctocaixa_juro, cDesc.cd_lanctocaixa as cd_lanctocaixa_desc, ");
                sql.AppendLine("cDCambAt.cd_lanctocaixa as cd_lanctocaixa_dcambat, cDCambPa.cd_lanctocaixa as cd_lanctocaixa_dcambpa, ");
                sql.AppendLine("case when b.tp_mov = 'P' then isnull(cLiq.vl_pagar,0) else isnull(cLiq.vl_receber,0)end as vl_quitacao, ");
                sql.AppendLine("case when b.tp_mov = 'P' then isnull(cJuro.vl_pagar,0) else isnull(cJuro.vl_receber,0)end as vl_juro, ");
                sql.AppendLine("case when b.tp_mov = 'P' then isnull(cDesc.vl_receber,0) else isnull(cDesc.vl_pagar,0)end as vl_desconto, ");
                sql.AppendLine("case when b.tp_mov = 'P' then isnull(cDCambAt.vl_pagar,0) else isnull(cDCambAt.vl_receber,0)end as vl_difcamb_at, ");
                sql.AppendLine("case when b.tp_mov = 'P' then isnull(cDCambPa.vl_receber,0) else isnull(cDCambPa.vl_pagar,0)end as vl_difcamb_pa ");
                sql.AppendLine("from tb_fin_duplicata a ");
                sql.AppendLine("inner join tb_fin_tpduplicata b ");
                sql.AppendLine("on a.tp_duplicata = b.tp_duplicata ");
                sql.AppendLine("inner join tb_fin_parcela c ");
                sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
                sql.AppendLine("inner join tb_fin_clifor d ");
                sql.AppendLine("on a.cd_clifor = d.cd_clifor ");
                sql.AppendLine("inner join tb_div_empresa e ");
                sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
                sql.AppendLine("inner join tb_fin_duplicata_cotacao f ");
                sql.AppendLine("on a.cd_empresa = f.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = f.nr_lancto ");
                sql.AppendLine("inner join tb_fin_moeda mDup ");
                sql.AppendLine("on f.cd_moeda = mDup.cd_moeda ");
                sql.AppendLine("inner join tb_fin_moeda mPad ");
                sql.AppendLine("on f.cd_moedaresult = mPad.cd_moeda ");
                sql.AppendLine("inner join tb_fin_liquidacao g ");
                sql.AppendLine("on c.cd_empresa = g.cd_empresa ");
                sql.AppendLine("and c.nr_lancto = g.nr_lancto ");
                sql.AppendLine("and c.cd_parcela = g.cd_parcela ");
                sql.AppendLine("inner join tb_fin_contager h ");
                sql.AppendLine("on g.cd_contager = h.cd_contager ");
                sql.AppendLine("inner join tb_fin_caixa cLiq ");
                sql.AppendLine("on g.cd_contager = cLiq.cd_contager ");
                sql.AppendLine("and g.cd_lanctocaixa = cLiq.cd_lanctocaixa ");
                sql.AppendLine("left outer join tb_fin_caixa cJuro ");
                sql.AppendLine("on g.cd_contager = cJuro.cd_contager ");
                sql.AppendLine("and g.cd_lanctocaixa_juro = cJuro.cd_lanctocaixa ");
                sql.AppendLine("left outer join tb_fin_caixa cDesc ");
                sql.AppendLine("on g.cd_contager = cDesc.cd_contager ");
                sql.AppendLine("and g.cd_lanctocaixa_desc = cDesc.cd_lanctocaixa ");
                sql.AppendLine("left outer join tb_fin_caixa cDCambAt ");
                sql.AppendLine("on g.cd_contager = cDCambAt.cd_contager ");
                sql.AppendLine("and g.cd_lanctocaixa_dcamb_at = cDCambAt.cd_lanctocaixa ");
                sql.AppendLine("left outer join tb_fin_caixa cDCambPa ");
                sql.AppendLine("on g.cd_contager = cDCambPa.cd_contager ");
                sql.AppendLine("and g.cd_lanctocaixa_dcamb_pa = cDCambPa.cd_lanctocaixa ");
                sql.AppendLine("where isnull(a.st_registro, 'A') = 'A' ");
                sql.AppendLine("and isnull(g.st_registro, 'A') <> 'C' ");
                if (filtro != null)
                {
                    string cond = " and ";
                    for (int i = 0; i < filtro.Length; i++)
                        sql.AppendLine(cond + "(" + filtro[i].vNM_Campo.Trim() + " " + filtro[i].vOperador.Trim() + " " + filtro[i].vVL_Busca.Trim() + ")");
                }
                if (vCd_contager.Trim() != string.Empty)
                    sql.AppendLine(" and (h.cd_contager = '" + vCd_contager.Trim() + "')");
            }
            sql.AppendLine("order by a.cd_clifor, data, tp_mov, nr_lancto, cd_contager ");
            return sql.ToString();
        }

        private string SqlCodeContasPagarReceberMes(string cd_empresa, string dt_ini, string dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.TP_Duplicata, a.DS_TpDuplicata, ");
            sql.AppendLine("vl_parcela = isnull((select sum(z.Vl_Parcela) from VTB_FIN_PARCELA z ");
            sql.AppendLine("		inner join tb_fin_duplicata h ");
            sql.AppendLine("		on h.cd_empresa = z.CD_Empresa ");
            sql.AppendLine("		and h.Nr_Lancto = z.Nr_Lancto ");
            sql.AppendLine("		where h.TP_Duplicata = a.TP_Duplicata ");
            sql.AppendLine("        and h.cd_empresa = '" + cd_empresa.Trim() + "'");
            sql.AppendLine("		and isnull(h.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("		and (CONVERT(datetime, floor(convert(decimal(30,10), z.DT_Vencto))) >= '" + dt_ini + "') ");
            sql.AppendLine("		and (CONVERT(datetime, floor(convert(decimal(30,10), z.DT_Vencto))) <= '" + dt_fin + "')),0), ");
            sql.AppendLine("vl_liquidacao = isnull((select sum(x.Vl_Liquidacao) from VTB_FIN_LIQUIDACAO x ");
            sql.AppendLine("		inner join tb_fin_duplicata y ");
            sql.AppendLine("		on y.cd_empresa = x.CD_Empresa ");
            sql.AppendLine("		and y.Nr_Lancto = x.Nr_Lancto ");
            sql.AppendLine("		where y.TP_Duplicata = a.TP_Duplicata ");
            sql.AppendLine("        and y.cd_empresa = '" + cd_empresa.Trim() + "'");
            sql.AppendLine("		and isnull(x.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("		and (CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Liquidacao))) >= '" + dt_ini + "') ");
            sql.AppendLine("		and (CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Liquidacao))) <= '" + dt_fin + "')),0) ");
            sql.AppendLine("from TB_FIN_TpDuplicata a ");

            return sql.ToString();
        }

        public DataTable BuscarRelExtratoContas(TpBusca[] filtro, string vTp_relatorio, string vCd_contager)
        {
            return ExecutarBusca(SqlCodeBuscaRelExtratoContas(filtro, vTp_relatorio, vCd_contager), null);
        }

        public DataTable BuscarRelGeralContas(TpBusca[] vBusca)
        {
            return ExecutarBusca(SqlCodeBuscaRelGeralContas(vBusca), null);
        }

        public DataTable BuscarRelContasPagarReceberMes(string cd_empresa, string dt_ini, string dt_fin)
        {
            return ExecutarBusca(SqlCodeContasPagarReceberMes(cd_empresa, dt_ini, dt_fin), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public TList_RegLanParcela Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder, string vGroup)
        {
            bool podeFecharBco = false;
            TList_RegLanParcela lista = new TList_RegLanParcela();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder, vGroup));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanParcela reg = new TRegistro_LanParcela();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Parcelas")))
                        reg.QT_Parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Vencto"))))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Parcela"))))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("Vl_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Parcela_Padrao")))
                        reg.Vl_parcela_padrao = reader.GetDecimal(reader.GetOrdinal("Vl_Parcela_Padrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_CalcAtual"))))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("Vl_CalcAtual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Atual")))
                        reg.cVl_atual = reader.GetDecimal(reader.GetOrdinal("Vl_Atual"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Liquidado"))))
                        reg.Vl_liquidado = reader.GetDecimal(reader.GetOrdinal("Vl_Liquidado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Cobranca")))
                        reg.St_cobranca = reader.GetString(reader.GetOrdinal("ST_Cobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_mov"))))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("tp_mov"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Juro"))))
                        reg.Vl_JuroLiquid = reader.GetDecimal(reader.GetOrdinal("Vl_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_DescLiquid = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_troco")))
                        reg.Vl_troco = reader.GetDecimal(reader.GetOrdinal("vl_troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devcredito")))
                        reg.Vl_devcredito = reader.GetDecimal(reader.GetOrdinal("vl_devcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Plural")))
                        reg.Ds_moeda_plural = reader.GetString(reader.GetOrdinal("DS_Moeda_Plural"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_MoedaResult")))
                        reg.Cd_moedaresult = reader.GetString(reader.GetOrdinal("CD_MoedaResult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("operador")))
                        reg.Operador = reader.GetString(reader.GetOrdinal("operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cotacao")))
                        reg.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("vl_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpf")))
                        reg.Cnpj_cpf = reader.GetString(reader.GetOrdinal("cnpj_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_CategoriaClifor")))
                        reg.Id_categoriaclifor = reader.GetDecimal(reader.GetOrdinal("Id_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CategoriaClifor")))
                        reg.Ds_categoriaclifor = reader.GetString(reader.GetOrdinal("DS_CategoriaClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DifCamb_AT")))
                        reg.Vl_difcambAT = reader.GetDecimal(reader.GetOrdinal("Vl_DifCamb_AT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DifCamb_PA")))
                        reg.Vl_difcambPA = reader.GetDecimal(reader.GetOrdinal("Vl_DifCamb_PA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nosso_Numero")))
                        reg.Nossonumero = reader.GetString(reader.GetOrdinal("Nosso_Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo")))
                        reg.Pc_jurodiario_atrazo = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status_parcela")))
                        reg.Status_parcela = reader.GetString(reader.GetOrdinal("status_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Desconto")))
                        reg.Cd_historico_desconto = reader.GetString(reader.GetOrdinal("CD_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Juro")))
                        reg.Cd_historico_juro = reader.GetString(reader.GetOrdinal("CD_Historico_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DCamb_Ativa")))
                        reg.Cd_historico_dcamb_at = reader.GetString(reader.GetOrdinal("CD_Historico_DCamb_Ativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DCamb_Passiva")))
                        reg.Cd_historico_dcamb_pa = reader.GetString(reader.GetOrdinal("CD_Historico_DCamb_Passiva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_HISTORICO_TROCOCH")))
                        reg.Cd_historico_troco = reader.GetString(reader.GetOrdinal("CD_HISTORICO_TROCOCH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portadoragrupar")))
                        reg.Cd_portadoragrupar = reader.GetString(reader.GetOrdinal("cd_portadoragrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contageragrupar")))
                        reg.Cd_contageragrupar = reader.GetString(reader.GetOrdinal("cd_contageragrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoagrup")))
                        reg.Cd_historicoagrup = reader.GetString(reader.GetOrdinal("cd_historicoagrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoquitacaoagrup")))
                        reg.Cd_historicoquitacaoagrup = reader.GetString(reader.GetOrdinal("cd_historicoquitacaoagrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portadorperdadup")))
                        reg.Cd_portadorperdadup = reader.GetString(reader.GetOrdinal("cd_portadorperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contagerperdadup")))
                        reg.Cd_contagerperdadup = reader.GetString(reader.GetOrdinal("cd_contagerperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoperdadup")))
                        reg.Cd_historicoperdadup = reader.GetString(reader.GetOrdinal("cd_historicoperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoquitperdadup")))
                        reg.Cd_historicoquitperdadup = reader.GetString(reader.GetOrdinal("cd_historicoquitperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoAgrupador")))
                        reg.NR_LanctoAgrupador = reader.GetDecimal(reader.GetOrdinal("NR_LanctoAgrupador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_agrupador")))
                        reg.St_agrupador = reader.GetString(reader.GetOrdinal("st_agrupador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_agrupado")))
                        reg.Vl_agrupado = reader.GetDecimal(reader.GetOrdinal("vl_agrupado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("complHistorico")))
                        reg.complHistorico = reader.GetString(reader.GetOrdinal("complHistorico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cooECF = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_placa")))
                        reg.Nr_placa = reader.GetString(reader.GetOrdinal("nr_placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devolucaoFIN")))
                        reg.Vl_devolucaoFIN = reader.GetDecimal(reader.GetOrdinal("vl_devolucaoFIN"));

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

        public TList_CliforAgrupar SelectCliforAgrupar(string lEmpresa)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, d.nm_empresa, a.cd_clifor, e.nm_clifor, a.id_config, f.ds_config, ");
            sql.AppendLine("a.cd_endereco, b.cd_condpgto, c.ds_condpgto, c.qt_diasdesdobro, a.id_convenio, ");
            sql.AppendLine("dt_agrupamento = dateadd(day, c.qt_diasdesdobro, getdate()), ");
            sql.AppendLine("isnull(sum(isnull(a.vl_agrupar, 0)), 0) as Vl_Agrupar ");

            sql.AppendLine("from VTB_FIN_AgruparFinPosto a ");
            sql.AppendLine("inner join tb_pdc_convenio b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_convenio = b.id_convenio ");
            sql.AppendLine("inner join tb_fin_condpgto c ");
            sql.AppendLine("on b.cd_condpgto = c.cd_condpgto ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join tb_fin_clifor e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("left outer join TB_COB_CfgBanco f ");
            sql.AppendLine("on a.id_config = f.id_config ");

            if (!string.IsNullOrEmpty(lEmpresa))
                sql.AppendLine("where a.cd_empresa in (" + lEmpresa.Trim() + ")");
            else
            {
                sql.AppendLine("where exists(select 1 from tb_div_usuario_x_empresa u ");
                sql.AppendLine("			where u.cd_empresa = a.CD_Empresa  ");
                sql.AppendLine("			and ((u.login = '" + Parametros.pubLogin.Trim() + "') or  ");
                sql.AppendLine("			(exists(select 1 from tb_div_usuario_x_grupos g ");
                sql.AppendLine("			         where g.logingrp = u.login and g.loginusr = '" + Parametros.pubLogin.Trim() + "')))) ");
            }
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_vencto))) <= convert(datetime, floor(convert(decimal(30,10), getdate()))) ");

            sql.AppendLine("group by a.cd_empresa, d.nm_empresa, a.cd_clifor, e.nm_clifor, ");
            sql.AppendLine("a.cd_endereco, b.st_utilizardiascondpgto, b.cd_condpgto, ");
            sql.AppendLine("c.ds_condpgto, c.qt_diasdesdobro, a.id_convenio, a.id_config, f.ds_config ");

            bool podeFecharBco = false;
            TList_CliforAgrupar lista = new TList_CliforAgrupar();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_CliforAgrupar reg = new TRegistro_CliforAgrupar();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasdesdobro")))
                        reg.Qt_diasdesdobro = reader.GetDecimal(reader.GetOrdinal("qt_diasdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_agrupamento")))
                        reg.Dt_agrupamento = reader.GetDateTime(reader.GetOrdinal("dt_agrupamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_convenio")))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_configBoleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_condigBoleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_agrupar")))
                        reg.Vl_agrupar = reader.GetDecimal(reader.GetOrdinal("vl_agrupar"));

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

        public string GravaParcela(TRegistro_LanParcela val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_DT_VENCTO", val.Dt_vencto);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);
            hs.Add("@P_VL_PARCELA_PADRAO", val.Vl_parcela_padrao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIN_PARCELA", hs);
        }
    }

    #endregion

    #region "Liquidacao"
    public class TList_RegLanLiquidacao : List<TRegistro_LanLiquidacao>, IComparer<TRegistro_LanLiquidacao>
    {
        #region IComparer<TRegistro_LanLiquidacao> Members
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

        public TList_RegLanLiquidacao()
        { }

        public TList_RegLanLiquidacao(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanLiquidacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanLiquidacao x, TRegistro_LanLiquidacao y)
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


    public class TRegistro_LanLiquidacao : ICloneable
    {
        public string Cd_empresa
        {
            get;
            set;
        }
        public decimal? Nr_lancto
        {
            get;
            set;
        }
        public decimal? Cd_parcela
        {
            get;
            set;
        }
        public decimal? Id_liquid
        {
            get;
            set;
        }
        public string Cd_contager
        {
            get;
            set;
        }
        public string Ds_contaGer
        {
            get;
            set;
        }
        public string Cd_portador
        {
            get;
            set;
        }
        public string Ds_portador
        {
            get;
            set;
        }
        public decimal? Id_lotectb
        { get; set; }
        public string St_tituloterceiro
        {
            get;
            set;
        }
        public string Nr_docto
        {
            get;
            set;
        }
        public string Cd_historico
        {
            get;
            set;
        }
        public string Ds_historico
        { get; set; }
        public string Cd_historico_juro
        {
            get;
            set;
        }
        public string Cd_historico_desc
        {
            get;
            set;
        }
        public string Cd_historico_trocoCH
        { get; set; }
        public string Cd_historicoperdaDup
        { get; set; }
        public string ComplHistorico
        {
            get;
            set;
        }
        public string ComplHistoricoLiquid
        { get; set; }
        private DateTime? dt_liquidacao;
        public DateTime? Dt_Liquidacao
        {
            get { return dt_liquidacao; }
            set
            {
                dt_liquidacao = value;
                dt_liquidacaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_liquidacaostring;
        public string Dt_liquidacaostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_liquidacaostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_liquidacaostring = value;
                try
                {
                    dt_liquidacao = Convert.ToDateTime(value);
                }
                catch { dt_liquidacao = null; }
            }
        }
        public decimal? Cd_lanctocaixa
        {
            get;
            set;
        }
        public decimal? Cd_lanctocaixa_Juro
        {
            get;
            set;
        }
        public decimal? Cd_lanctocaixa_Desc
        {
            get;
            set;
        }
        public decimal? Cd_lanctocaixa_dcamb_at
        { get; set; }
        public decimal? Cd_lanctocaixa_dcamb_pa
        { get; set; }
        public decimal? Cd_lanctocaixa_trocoCH
        { get; set; }
        public decimal? Cd_lanctocaixa_trocoDH
        { get; set; }
        public decimal? Cd_lanctocaixa_perdaDup
        { get; set; }
        public decimal? Cd_lanctocaixa_adto
        { get; set; }
        public string Tp_mov
        {
            get;
            set;
        }
        private decimal vl_parcela;
        public decimal Vl_parcela
        {
            get { return Math.Round(vl_parcela, 2); }
            set { vl_parcela = Math.Round(value, 2); }
        }
        private decimal vl_atual;
        public decimal Vl_atual
        {
            get { return Math.Round(vl_atual, 2); }
            set { vl_atual = Math.Round(value, 2); }
        }
        private decimal vl_difcamb_at;
        public decimal Vl_difcamb_at
        {
            get { return Math.Round(vl_difcamb_at, 2); }
            set { vl_difcamb_at = Math.Round(value, 2); }
        }
        private decimal vl_difcamb_pa;
        public decimal Vl_difcamb_pa
        {
            get { return Math.Round(vl_difcamb_pa, 2); }
            set { vl_difcamb_pa = Math.Round(value, 2); }
        }
        private decimal vl_liquidado;
        public decimal Vl_Liquidado
        {
            get { return Math.Round(vl_liquidado, 2); }
            set { vl_liquidado = Math.Round(value, 2); }
        }
        private decimal vl_liquidado_padrao;
        public decimal Vl_liquidado_padrao
        {
            get { return Math.Round(vl_liquidado_padrao, 2); }
            set { vl_liquidado_padrao = Math.Round(value, 2); }
        }
        public decimal Vl_LiquidadoTotal_padrao
        { get { return Vl_liquidado_padrao + Vl_difcamb_at - Vl_difcamb_pa + Vl_JuroAcrescimo - Vl_DescontoBonus; } }
        private decimal vl_descontobonus;
        public decimal Vl_DescontoBonus
        {
            get { return Math.Round(vl_descontobonus, 2); }
            set { vl_descontobonus = Math.Round(value, 2); }
        }
        private decimal vl_trocoCH;
        public decimal Vl_trocoCH
        {
            get { return Math.Round(vl_trocoCH, 2); }
            set { vl_trocoCH = Math.Round(value, 2); }
        }
        private decimal vl_trocoDH;
        public decimal Vl_trocoDH
        {
            get { return Math.Round(vl_trocoDH, 2); }
            set { vl_trocoDH = Math.Round(value, 2); }
        }
        private decimal vl_adto;
        public decimal Vl_adto
        {
            get { return Math.Round(vl_adto, 2); }
            set { vl_adto = Math.Round(value, 2); }
        }
        private decimal vl_juroacrescimo;
        public decimal Vl_JuroAcrescimo
        {
            get { return Math.Round(vl_juroacrescimo, 2); }
            set { vl_juroacrescimo = Math.Round(value, 2); }
        }
        public string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
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
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        private decimal cvl_nominal;
        public decimal cVl_Nominal
        {
            get { return Math.Round(cvl_nominal, 2); }
            set { cvl_nominal = Math.Round(value, 2); }
        }
        private decimal cvl_adiantamento;
        public decimal cVl_adiantamento
        {
            get { return Math.Round(cvl_adiantamento, 2); }
            set { cvl_adiantamento = Math.Round(value, 2); }
        }
        private decimal cvl_liquidado;
        public decimal cVl_Liquidado
        {
            get { return Math.Round(cvl_liquidado, 2); }
            set { cvl_liquidado = Math.Round(value, 2); }
        }
        private decimal ctaxa_mensal;
        public decimal cTaxa_Mensal
        {
            get { return Math.Round(ctaxa_mensal, 2); }
            set { ctaxa_mensal = Math.Round(value, 2); }
        }
        private decimal cvl_atual;
        public decimal cVl_Atual
        {
            get { return Math.Round(cvl_atual, 2); }
            set { cvl_atual = Math.Round(value, 2); }
        }
        private decimal cvl_jurototal;
        public decimal cVl_JuroTotal
        {
            get { return Math.Round(cvl_jurototal, 2); }
            set { cvl_jurototal = Math.Round(value, 2); }
        }
        private decimal cvl_descontototal;
        public decimal cVl_DescontoTotal
        {
            get { return Math.Round(cvl_descontototal, 2); }
            set { cvl_descontototal = Math.Round(value, 2); }
        }
        private decimal cvl_aliquidar_padrao;
        public decimal Cvl_aliquidar_padrao
        {
            get { return Math.Round(cvl_aliquidar_padrao, 2); }
            set
            {
                cvl_aliquidar_padrao = Math.Round(value, 2);
                Vl_pagar_receber = cvl_aliquidar_padrao;
                if (cvl_aliquidar_padrao > cvl_atual)
                {
                    if (lCotacao != null)
                        if (lCotacao.Cd_moeda.Trim().Equals(lCotacao.Cd_moedaresult.Trim()))
                            cvl_juroliquidar = Math.Round((cvl_aliquidar_padrao - (cVl_Nominal - cVl_Liquidado)), 2);
                }
                else
                    if (cVl_Liquidado > cVl_Nominal)
                {
                    if (lCotacao != null)
                        if (lCotacao.Cd_moeda.Trim().Equals(lCotacao.Cd_moedaresult.Trim()))
                            cvl_juroliquidar = Math.Round(cvl_aliquidar_padrao, 2);
                }
                else
                        if (lCotacao != null)
                    if (lCotacao.Cd_moeda.Trim().Equals(lCotacao.Cd_moedaresult.Trim()))
                        cvl_juroliquidar = Math.Round(cVl_JuroTotal, 2);
                if (cvl_aliquidar_padrao < cvl_juroliquidar)
                    if (lCotacao != null)
                        if (lCotacao.Cd_moeda.Trim().Equals(lCotacao.Cd_moedaresult.Trim()))
                            cvl_juroliquidar = cvl_aliquidar_padrao;
            }
        }
        public decimal Vl_liquidarLiquido
        {
            get
            {
                return cvl_aliquidar_padrao - cvl_descontoconcedido - cvl_adiantamento;
            }
        }
        public decimal Vl_pagar_receber
        { get; set; }
        private decimal cvl_juroliquidar;
        public decimal cVl_juroliquidar
        {
            get { return Math.Round(cvl_juroliquidar, 2); }
            set
            {
                cvl_juroliquidar = Math.Round(value, 2);
                if (cVl_Liquidado > cVl_Nominal)
                    cvl_aliquidar_padrao = Math.Round(cvl_juroliquidar, 2);
                else
                {
                    if (cvl_jurototal > decimal.Zero)
                        if (cvl_aliquidar_padrao >= (cvl_atual - cvl_liquidado))
                            cvl_aliquidar_padrao = Math.Round(cvl_juroliquidar + (cvl_atual - cvl_liquidado), 2);
                }
            }
        }
        private decimal cvl_descontoconcedido;
        public decimal cVl_descontoconcedido
        {
            get { return Math.Round(cvl_descontoconcedido, 2); }
            set { cvl_descontoconcedido = Math.Round(value, 2); }
        }
        public decimal cVl_perdaduplicata
        { get; set; }
        private decimal cvl_diferencacambialativa;
        public decimal Cvl_diferencacambialativa
        {
            get { return Math.Round(cvl_diferencacambialativa, 2); }
            set { cvl_diferencacambialativa = Math.Round(value, 2); }
        }
        private decimal cvl_diferencacambialpassiva;
        public decimal Cvl_diferencacambialpassiva
        {
            get { return Math.Round(cvl_diferencacambialpassiva, 2); }
            set { cvl_diferencacambialpassiva = Math.Round(value, 2); }
        }
        public decimal? Id_caixaoperacional
        { get; set; }
        public bool St_BloqLiquidacao
        { get; set; }
        public bool St_AdtoTrocoCH
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public TList_Liquidacao_X_Adto_Caixa LiqAdtoCaixa
        { get; set; }
        public TRegistro_LiquidacaoCotacao lCotacao
        { get; set; }
        public List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lCred
        { get; set; }
        public List<TRegistro_LanTitulo> lChTroco
        { get; set; }
        public string MotivoCanc { get; set; } = string.Empty;

        public TRegistro_LanLiquidacao()
        {
            Id_lotectb = null;
            Cd_empresa = string.Empty;
            Cd_contager = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_historico_desc = string.Empty;
            Cd_historico_juro = string.Empty;
            Cd_historico_trocoCH = string.Empty;
            Cd_historicoperdaDup = string.Empty;
            Cd_lanctocaixa = null;
            Cd_lanctocaixa_dcamb_at = null;
            Cd_lanctocaixa_dcamb_pa = null;
            Cd_lanctocaixa_Desc = null;
            Cd_lanctocaixa_Juro = null;
            Cd_lanctocaixa_trocoCH = null;
            Cd_lanctocaixa_trocoDH = null;
            Cd_lanctocaixa_perdaDup = null;
            Cd_lanctocaixa_adto = null;
            Cd_parcela = null;
            Cd_portador = string.Empty;
            ComplHistorico = string.Empty;
            ComplHistoricoLiquid = string.Empty;
            Ds_contaGer = string.Empty;
            Ds_portador = string.Empty;
            St_tituloterceiro = string.Empty;
            dt_liquidacaostring = string.Empty;
            Id_liquid = null;
            lCotacao = new TRegistro_LiquidacaoCotacao();
            Nr_docto = string.Empty;
            Nr_lancto = null;
            Tp_mov = string.Empty;
            Vl_atual = decimal.Zero;
            Vl_DescontoBonus = decimal.Zero;
            Vl_difcamb_at = decimal.Zero;
            Vl_difcamb_pa = decimal.Zero;
            Vl_JuroAcrescimo = decimal.Zero;
            Vl_Liquidado = decimal.Zero;
            Vl_parcela = decimal.Zero;
            vl_liquidado_padrao = decimal.Zero;
            vl_trocoCH = decimal.Zero;
            vl_trocoDH = decimal.Zero;
            vl_adto = decimal.Zero;
            cVl_perdaduplicata = decimal.Zero;
            Vl_pagar_receber = decimal.Zero;
            st_registro = "A";
            status = "ABERTO";
            St_BloqLiquidacao = true;
            St_AdtoTrocoCH = false;
            Id_caixaoperacional = null;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            LiqAdtoCaixa = new TList_Liquidacao_X_Adto_Caixa();
            lCred = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
            lChTroco = new List<TRegistro_LanTitulo>();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TCD_LanLiquidacao : TDataQuery
    {
        public TCD_LanLiquidacao()
        { }

        public TCD_LanLiquidacao(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT a.CD_Empresa, a.Nr_Lancto, a.CD_Parcela, a.Id_liquid, a.DT_Liquidacao, a.vl_liquidacao, ");
                sql.AppendLine("a.vl_descontoBonus, a.vl_juroAcrescimo, a.cd_ContaGer, a.cd_portador, a.CD_lanctocaixa, a.Vl_Liquidacao_Padrao, ");
                sql.AppendLine("a.CD_LanctoCaixa_Juro, a.CD_LanctoCaixa_Desc, a.CD_LanctoCaixa_DCamb_AT, a.CD_LanctoCaixa_DCamb_PA, ");
                sql.AppendLine("k.DS_ContaGer, p.DS_portador, p.ST_TituloTerceiro, C.DT_Vencto, d.DT_Emissao, C.VL_Parcela, a.ST_Registro, t.tp_mov, ");
                sql.AppendLine("a.Vl_DifCamb_AT, a.Vl_DifCamb_PA, a.cd_lanctocaixa_trocoCH, a.vl_trocoCH, a.vl_trocoDH, a.vl_adto, ");
                sql.AppendLine("d.cd_clifor, cli.nm_clifor, a.cd_lanctocaixa_perdadup, a.cd_lanctocaixa_adto, a.id_loteCTB, ");
                sql.AppendLine("l.login, l.cd_moeda, m.ds_moeda_singular, m.sigla, a.cd_lanctocaixa_trocoDH, ");
                sql.AppendLine("l.cd_moedaresult, mr.ds_moeda_singular as ds_moedaresult, mr.sigla as siglaresult, ");
                sql.AppendLine("l.vl_cotacao, l.dt_cotacao, l.operador, caixa.ComplHistorico as ComplHistoricoLiquid, a.MotivoCanc ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Liquidacao a ");

            sql.AppendLine("INNER JOIN TB_FIN_Caixa caixa ");
            sql.AppendLine("ON a.cd_contager = caixa.cd_contager ");
            sql.AppendLine("and a.cd_lanctocaixa = caixa.cd_lanctocaixa ");

            sql.AppendLine("INNER JOIN TB_FIN_ContaGer k ");
            sql.AppendLine("ON k.CD_ContaGer = a.CD_ContaGer ");

            sql.AppendLine("INNER JOIN TB_FIN_Portador p ");
            sql.AppendLine("ON P.CD_Portador = a.cd_portador ");

            sql.AppendLine("INNER JOIN TB_FIN_Parcela  C ");
            sql.AppendLine("ON C.CD_Empresa  = a.CD_Empresa ");
            sql.AppendLine("and C.nr_lancto = a.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = C.cd_parcela ");

            sql.AppendLine("INNER JOIN TB_FIN_Duplicata d ");
            sql.AppendLine("ON d.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and d.nr_lancto = c.nr_lancto ");

            sql.AppendLine("INNER JOIN TB_FIN_TPDuplicata t ");
            sql.AppendLine("on t.tp_duplicata = d.tp_duplicata");

            sql.AppendLine("INNER JOIN TB_FIN_Clifor cli ");
            sql.AppendLine("ON d.cd_clifor = cli.cd_clifor ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Liquidacao_Cotacao l ");
            sql.AppendLine("on a.cd_empresa = l.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = l.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = l.cd_parcela ");
            sql.AppendLine("and a.id_liquid = l.id_liquid ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda m ");
            sql.AppendLine("on l.cd_moeda = m.cd_moeda ");

            sql.AppendLine("LEFT OUTER JOIN TB_FIN_Moeda mr ");
            sql.AppendLine("on l.cd_moedaresult = mr.cd_moeda ");

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

        public TList_RegLanLiquidacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RegLanLiquidacao lista = new TList_RegLanLiquidacao();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanLiquidacao reg = new TRegistro_LanLiquidacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ContaGer"))))
                        reg.Ds_contaGer = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Portador"))))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ComplHistoricoLiquid"))))
                        reg.ComplHistoricoLiquid = reader.GetString(reader.GetOrdinal("ComplHistoricoLiquid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TituloTerceiro")))
                        reg.St_tituloterceiro = reader.GetString(reader.GetOrdinal("ST_TituloTerceiro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Liquidacao"))))
                        reg.Dt_Liquidacao = reader.GetDateTime(reader.GetOrdinal("DT_Liquidacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Liquidacao"))))
                        reg.Vl_Liquidado = reader.GetDecimal(reader.GetOrdinal("Vl_Liquidacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Liquidacao_Padrao")))
                        reg.Vl_liquidado_padrao = reader.GetDecimal(reader.GetOrdinal("Vl_Liquidacao_Padrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_DescontoBonus"))))
                    {
                        reg.Vl_DescontoBonus = reader.GetDecimal(reader.GetOrdinal("Vl_DescontoBonus"));
                        //Acrescentado campo para imprimir desconto no recibo tanto direto na liquidação quanto posteriormente.
                        reg.cVl_descontoconcedido = reg.Vl_DescontoBonus;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_juroAcrescimo"))))
                        reg.Vl_JuroAcrescimo = reader.GetDecimal(reader.GetOrdinal("vl_juroacrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DifCamb_AT")))
                        reg.Vl_difcamb_at = reader.GetDecimal(reader.GetOrdinal("Vl_DifCamb_AT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_DifCamb_PA")))
                        reg.Vl_difcamb_pa = reader.GetDecimal(reader.GetOrdinal("Vl_DifCamb_PA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa"))))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_juro"))))
                        reg.Cd_lanctocaixa_Juro = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_desc"))))
                        reg.Cd_lanctocaixa_Desc = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_desc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_DCamb_AT")))
                        reg.Cd_lanctocaixa_dcamb_at = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_DCamb_AT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_DCamb_PA")))
                        reg.Cd_lanctocaixa_dcamb_pa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_DCamb_PA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa_trocoCH")))
                        reg.Cd_lanctocaixa_trocoCH = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa_trocoCH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa_trocoDH")))
                        reg.Cd_lanctocaixa_trocoDH = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa_trocoDH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa_perdadup")))
                        reg.Cd_lanctocaixa_perdaDup = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa_perdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa_adto")))
                        reg.Cd_lanctocaixa_adto = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_trocoCH")))
                        reg.Vl_trocoCH = reader.GetDecimal(reader.GetOrdinal("vl_trocoCH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_trocoDH")))
                        reg.Vl_trocoDH = reader.GetDecimal(reader.GetOrdinal("vl_trocoDH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_adto")))
                        reg.Vl_adto = reader.GetDecimal(reader.GetOrdinal("vl_adto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Id_lotectb = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    //Dados cotacao
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.lCotacao.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moeda")))
                        reg.lCotacao.Cd_moeda = reader.GetString(reader.GetOrdinal("cd_moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moeda_singular")))
                        reg.lCotacao.Ds_moeda = reader.GetString(reader.GetOrdinal("ds_moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla")))
                        reg.lCotacao.Sigla = reader.GetString(reader.GetOrdinal("sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_moedaresult")))
                        reg.lCotacao.Cd_moedaresult = reader.GetString(reader.GetOrdinal("cd_moedaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_moedaresult")))
                        reg.lCotacao.Ds_moedaresult = reader.GetString(reader.GetOrdinal("ds_moedaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("siglaresult")))
                        reg.lCotacao.Sigla_moedaresult = reader.GetString(reader.GetOrdinal("siglaresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cotacao")))
                        reg.lCotacao.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("vl_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cotacao")))
                        reg.lCotacao.Dt_cotacao = reader.GetDateTime(reader.GetOrdinal("dt_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("operador")))
                        reg.lCotacao.Operador = reader.GetString(reader.GetOrdinal("operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoCanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("MotivoCanc"));


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

        public string GravaLiquidacao(TRegistro_LanLiquidacao val)
        {
            Hashtable hs = new Hashtable(34);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_DT_LIQUIDACAO", val.Dt_Liquidacao);
            hs.Add("@P_VL_LIQUIDACAO", val.Vl_Liquidado);
            hs.Add("@P_VL_LIQUIDACAO_PADRAO", val.Vl_liquidado_padrao);
            hs.Add("@P_VL_ATUAL", val.Vl_atual);
            hs.Add("@P_VL_DESCONTOBONUS", val.Vl_DescontoBonus);
            hs.Add("@P_VL_JUROACRESCIMO", val.Vl_JuroAcrescimo);
            hs.Add("@P_VL_DIFCAMB_PA", val.Vl_difcamb_pa);
            hs.Add("@P_VL_DIFCAMB_AT", val.Vl_difcamb_at);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_NR_DOCTO", val.Nr_docto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_HISTORICO_JURO", val.Cd_historico_juro);
            hs.Add("@P_CD_HISTORICO_DESC", val.Cd_historico_desc);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_COMPLHISTORICO", val.ComplHistorico);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_LANCTO", val.Cd_lanctocaixa);
            hs.Add("@P_CD_LANCTO_JURO", val.Cd_lanctocaixa_Juro);
            hs.Add("@P_CD_LANCTO_DESC", val.Cd_lanctocaixa_Desc);
            hs.Add("@P_CD_LANCTO_DCAMB_AT", val.Cd_lanctocaixa_dcamb_at);
            hs.Add("@P_CD_LANCTO_DCAMB_PA", val.Cd_lanctocaixa_dcamb_pa);
            hs.Add("@P_CD_LANCTO_TROCOCH", val.Cd_lanctocaixa_trocoCH);
            hs.Add("@P_CD_LANCTO_TROCODH", val.Cd_lanctocaixa_trocoDH);
            hs.Add("@P_CD_LANCTO_PERDADUP", val.Cd_lanctocaixa_perdaDup);
            hs.Add("@P_CD_LANCTO_ADTO", val.Cd_lanctocaixa_adto);
            hs.Add("@P_VL_TROCOCH", val.Vl_trocoCH);
            hs.Add("@P_VL_TROCODH", val.Vl_trocoDH);
            hs.Add("@P_VL_ADTO", val.Vl_adto);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);

            return executarProc("IA_FIN_LIQUIDACAO", hs);
        }

        public DataTable Integracao_Financeiro_Caixa(string vCD_ContaGer, decimal vCD_LanctoCaixa)
        {
            StringBuilder SQL = new StringBuilder();
            Hashtable param = new Hashtable();

            SQL.AppendLine(" SELECT a.cd_empresa, a.nr_docto, a.vl_documento, a.dt_emissao, a.vl_documento, a.qt_parcelas, a.ComplHistorico,");
            SQL.AppendLine("       b.cd_parcela, b.dt_vencto, b.vl_parcela, ");
            SQL.AppendLine("  n.vl_liquidacao_padrao, n.dt_liquidacao, n.id_liquid, n.vl_juroAcrescimo, n.vl_descontoBonus, (n.vl_liquidacao_padrao - n.vl_juroAcrescimo + n.vl_descontoBonus) as Vl_LiquidLiq ");
            SQL.AppendLine(" FROM TB_FIN_DUPLICATA A ");
            SQL.AppendLine("            JOIN TB_FIN_PARCELA B ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTO = B.NR_LANCTO ");
            SQL.AppendLine("            JOIN TB_FIN_LIQUIDACAO N ON n.CD_EMPRESA = B.CD_EMPRESA AND n.NR_LANCTO = B.NR_LANCTO AND n.CD_PARCELA = B.CD_PARCELA AND N.CD_LANCTOCAIXA = @CD_LANCTOCAIXA");

            SQL.AppendLine(" UNION ");

            SQL.AppendLine(" SELECT a.cd_empresa, a.nr_docto, a.vl_documento, a.dt_emissao, a.vl_documento, a.qt_parcelas, a.ComplHistorico,");
            SQL.AppendLine("       b.cd_parcela, b.dt_vencto, b.vl_parcela, ");
            SQL.AppendLine("  n.vl_liquidacao_padrao, n.dt_liquidacao, n.id_liquid, n.vl_juroAcrescimo, n.vl_descontoBonus, (n.vl_liquidacao_padrao - n.vl_juroAcrescimo + n.vl_descontoBonus) as Vl_LiquidLiq ");
            SQL.AppendLine(" FROM TB_FIN_DUPLICATA A ");
            SQL.AppendLine("            JOIN TB_FIN_PARCELA B ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTO = B.NR_LANCTO ");
            SQL.AppendLine("            JOIN TB_FIN_LIQUIDACAO N ON n.CD_EMPRESA = B.CD_EMPRESA AND n.NR_LANCTO = B.NR_LANCTO AND n.CD_PARCELA = B.CD_PARCELA AND N.CD_LANCTOCAIXA_JURO = @CD_LANCTOCAIXA");

            SQL.AppendLine(" UNION ");

            SQL.AppendLine(" SELECT a.cd_empresa, a.nr_docto, a.vl_documento, a.dt_emissao, a.vl_documento, a.qt_parcelas, a.ComplHistorico,");
            SQL.AppendLine("       b.cd_parcela, b.dt_vencto, b.vl_parcela, ");
            SQL.AppendLine("  n.vl_liquidacao_padrao, n.dt_liquidacao, n.id_liquid, n.vl_juroAcrescimo, n.vl_descontoBonus, (n.vl_liquidacao_padrao - n.vl_juroAcrescimo + n.vl_descontoBonus) as Vl_LiquidLiq ");
            SQL.AppendLine(" FROM TB_FIN_DUPLICATA A ");
            SQL.AppendLine("            JOIN TB_FIN_PARCELA B ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTO = B.NR_LANCTO ");
            SQL.AppendLine("            JOIN TB_FIN_LIQUIDACAO N ON n.CD_EMPRESA = B.CD_EMPRESA AND n.NR_LANCTO = B.NR_LANCTO AND n.CD_PARCELA = B.CD_PARCELA AND N.CD_LANCTOCAIXA_DESC = @CD_LANCTOCAIXA");

            param.Add("@CD_CONTAGER", vCD_ContaGer);
            param.Add("@CD_LANCTOCAIXA", vCD_LanctoCaixa);

            return ExecutarBusca(SQL.ToString(), param);
        }
    }

    #endregion

    #region "Liquidacao X Adiantamento_Caixa"
    public class TList_Liquidacao_X_Adto_Caixa : List<TRegistro_Liquidacao_X_Adto_Caixa>
    { }


    public class TRegistro_Liquidacao_X_Adto_Caixa
    {

        public decimal? Id_lancto
        { get; set; }

        public decimal? Id_adto
        { get; set; }

        public decimal? Cd_lanctocaixa
        { get; set; }

        public string Cd_contager
        { get; set; }

        public string Cd_empresa
        { get; set; }

        public decimal? Nr_lancto
        { get; set; }

        public decimal? Cd_parcela
        { get; set; }

        public decimal? Id_liquid
        { get; set; }

        public decimal Vl_lancto
        { get; set; }

        public decimal Vl_devolvido
        { get; set; }

        public decimal Vl_saldo
        {
            get { return Vl_lancto - Vl_devolvido; }
        }

        public TRegistro_Liquidacao_X_Adto_Caixa()
        {
            Id_lancto = null;
            Id_adto = null;
            Cd_lanctocaixa = null;
            Cd_contager = string.Empty;
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Cd_parcela = null;
            Id_liquid = null;
            Vl_lancto = decimal.Zero;
            Vl_devolvido = decimal.Zero;
        }
    }

    public class TCD_Liquidacao_X_Adto_Caixa : TDataQuery
    {
        public TCD_Liquidacao_X_Adto_Caixa()
        { }

        public TCD_Liquidacao_X_Adto_Caixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strTop + " a.id_lancto, a.id_adto, a.cd_lanctocaixa, ");
                sql.AppendLine("a.cd_contager, a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_liquid ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_liquidacao_x_Adto_Caixa a ");

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

        public TList_Liquidacao_X_Adto_Caixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Liquidacao_X_Adto_Caixa lista = new TList_Liquidacao_X_Adto_Caixa();
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
                    TRegistro_Liquidacao_X_Adto_Caixa reg = new TRegistro_Liquidacao_X_Adto_Caixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Adto"))))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("ID_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Liquid"))))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));

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

        public string GravarLiquidacao_x_Adto_Caixa(TRegistro_Liquidacao_X_Adto_Caixa val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return executarProc("IA_FIN_LIQUIDACAO_X_ADTO_CAIXA", hs);
        }

        public string DeletarLiquidacao_x_Adto_Caixa(TRegistro_Liquidacao_X_Adto_Caixa val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return executarProc("IA_FIN_EXCLUI_LIQUIDACAO_X_ADTO_CAIXA", hs);
        }
    }
    #endregion

    #region Troco Cheque
    public class TList_TrocoCH : List<TRegistro_TrocoCH>
    { }


    public class TRegistro_TrocoCH
    {

        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctocheque;

        public decimal? Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set
            {
                nr_lanctocheque = value;
                nr_lanctochequestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctochequestr;

        public string Nr_lanctochequestr
        {
            get { return nr_lanctochequestr; }
            set
            {
                nr_lanctochequestr = value;
                try
                {
                    nr_lanctocheque = decimal.Parse(value);
                }
                catch { nr_lanctocheque = null; }
            }
        }

        public string Cd_banco
        { get; set; }

        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;

        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;

        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch { cd_lanctocaixa = null; }
            }
        }

        public TRegistro_TrocoCH()
        {
            Cd_empresa = string.Empty;
            nr_lanctocheque = null;
            nr_lanctochequestr = string.Empty;
            Cd_banco = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
        }
    }

    public class TCD_TrocoCH : TDataQuery
    {
        public TCD_TrocoCH() { }

        public TCD_TrocoCH(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" Select " + strTop + " a.cd_empresa, a.nr_lanctocheque, ");
                sql.AppendLine("a.cd_banco, a.cd_contager, a.cd_lanctocaixa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_trocoCH a ");

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

        public TList_TrocoCH Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocoCH lista = new TList_TrocoCH();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocoCH reg = new TRegistro_TrocoCH();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque"))))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));

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

        public string Gravar(TRegistro_TrocoCH val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("IA_FIN_TROCOCH", hs);
        }

        public string Excluir(TRegistro_TrocoCH val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("EXCLUI_FIN_TROCOCH", hs);
        }
    }
    #endregion

    #region Liquidacao Carta Frete
    public class TList_LiquidCartaFrete : List<TRegistro_LiquidCartaFrete>
    { }


    public class TRegistro_LiquidCartaFrete
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_cartafrete;

        public decimal? Id_cartafrete
        {
            get { return id_cartafrete; }
            set
            {
                id_cartafrete = value;
                id_cartafretestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartafretestr;

        public string Id_cartafretestr
        {
            get { return id_cartafretestr; }
            set
            {
                id_cartafretestr = value;
                try
                {
                    id_cartafrete = decimal.Parse(value);
                }
                catch { id_cartafrete = null; }
            }
        }

        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;

        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;

        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch { cd_lanctocaixa = null; }
            }
        }

        public TRegistro_LiquidCartaFrete()
        {
            Cd_empresa = string.Empty;
            id_cartafrete = null;
            id_cartafretestr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
        }
    }

    public class TCD_LiquidCartaFrete : TDataQuery
    {
        public TCD_LiquidCartaFrete() { }

        public TCD_LiquidCartaFrete(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" Select " + strTop + " a.cd_empresa, a.id_cartafrete, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_LiquidCartaFrete a ");

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

        public TList_LiquidCartaFrete Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LiquidCartaFrete lista = new TList_LiquidCartaFrete();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LiquidCartaFrete reg = new TRegistro_LiquidCartaFrete();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_CartaFrete"))))
                        reg.Id_cartafrete = reader.GetDecimal(reader.GetOrdinal("ID_CartaFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));

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

        public string Gravar(TRegistro_LiquidCartaFrete val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("IA_FIN_LIQUIDCARTAFRETE", hs);
        }

        public string Excluir(TRegistro_LiquidCartaFrete val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return executarProc("EXCLUI_FIN_LIQUIDCARTAFRETE", hs);
        }
    }
    #endregion

    #region "Recibo"
    public class TList_Recibo : List<TRecibo>
    { }


    public class TRecibo
    {

        public string Nm_recebi
        { get; set; }

        public string Nr_cnpj_cpf_recebi
        { get; set; }

        public string Ds_endereco_recebi
        { get; set; }

        public string Numero_recebi
        { get; set; }

        public string Bairro_recebi
        { get; set; }

        public string Cidade_recebi
        { get; set; }

        public string Uf_recebi
        { get; set; }

        public string Fone_recebi
        { get; set; }

        public string Insc_estadual_recebi
        { get; set; }

        public decimal Vl_liquidacao
        { get; set; }

        public string Vl_extenso
        { get; set; }

        public string Ds_historico
        { get; set; }

        public string Complhistorico
        { get; set; }

        public string Nm_recibo
        { get; set; }

        public string Nr_cnpj_recibo
        { get; set; }

        public string Ds_cidade_recibo
        { get; set; }

        public string Fone_recibo
        { get; set; }

        public DateTime Dt_liquidacao
        { get; set; }

        public TRecibo()
        {
            Bairro_recebi = string.Empty;
            Cidade_recebi = string.Empty;
            Complhistorico = string.Empty;
            Ds_cidade_recibo = string.Empty;
            Ds_endereco_recebi = string.Empty;
            Ds_historico = string.Empty;
            Dt_liquidacao = DateTime.Now;
            Fone_recebi = string.Empty;
            Fone_recibo = string.Empty;
            Insc_estadual_recebi = string.Empty;
            Nm_recebi = string.Empty;
            Nm_recibo = string.Empty;
            Nr_cnpj_cpf_recebi = string.Empty;
            Nr_cnpj_recibo = string.Empty;
            Numero_recebi = string.Empty;
            Uf_recebi = string.Empty;
            Vl_extenso = string.Empty;
            Vl_liquidacao = decimal.Zero;
        }
    }

    public class TCD_Recibo : TDataQuery
    {
        public TList_Recibo SqlCodeImpRecibo(TRegistro_LanLiquidacao rLiq)
        {
            string sql = "select (isnull(c.vl_liquidacao_padrao,0) - isnull(c.vl_juroacrescimo,0)) as vl_liquidacao, c.dt_liquidacao, \r\n" +
                         "a.complhistorico, his.ds_historico, \r\n" +
                         "case when tpdup.tp_mov = 'P' then d.nm_empresa else g.nm_clifor end as nm_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then e.nr_cgc else  \r\n" +
                             "case when g.tp_pessoa = 'J' then g.nr_cgc else g.nr_cpf end end as nr_cnpj_cpf_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.ds_endereco else h.ds_endereco end as ds_endereco_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.numero else h.numero end as numero_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.bairro else h.bairro end as bairro_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.ds_cidade else h.ds_cidade end as cidade_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.uf else h.uf end as uf_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.fone else h.fone end fone_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then f.insc_estadual else h.insc_estadual end insc_estadual_recebi, \r\n" +
                         "case when tpdup.tp_mov = 'P' then g.nm_clifor else d.nm_empresa end as nm_recibo, \r\n" +
                         "case when tpdup.tp_mov = 'P' then  \r\n" +
                         "	case when g.tp_pessoa = 'J' then g.nr_cgc else g.nr_cpf end  \r\n" +
                         "else e.nr_cgc end as nr_cnpj_recibo, \r\n" +
                         "case when tpdup.tp_mov = 'P' then h.ds_cidade else f.ds_cidade end as cidade_recibo, \r\n" +
                         "case when tpdup.tp_mov = 'P' then h.fone else f.fone end as fone_recibo \r\n" +
                         "from tb_fin_duplicata a \r\n" +
                         "inner join tb_fin_tpduplicata tpdup \r\n" +
                         "on a.tp_duplicata = tpdup.tp_duplicata \r\n" +
                         "inner join tb_fin_historico his \r\n" +
                         "on a.cd_historico = his.cd_historico \r\n" +
                         "inner join tb_fin_parcela b \r\n" +
                         "on a.cd_empresa = b.cd_empresa \r\n" +
                         "and a.nr_lancto = b.nr_lancto \r\n" +
                         "inner join tb_fin_liquidacao c \r\n" +
                         "on b.cd_empresa = c.cd_empresa \r\n" +
                         "and b.nr_lancto = c.nr_lancto \r\n" +
                         "and b.cd_parcela = c.cd_parcela \r\n" +
                         "inner join tb_div_empresa d \r\n" +
                         "on a.cd_empresa = d.cd_empresa \r\n" +
                         "inner join vtb_fin_clifor e \r\n" +
                         "on d.cd_clifor = e.cd_clifor \r\n" +
                         "inner join vtb_fin_endereco f \r\n" +
                         "on d.cd_clifor = f.cd_clifor \r\n" +
                         "and d.cd_endereco = f.cd_endereco \r\n" +
                         "inner join vtb_fin_clifor g \r\n" +
                         "on a.cd_clifor = g.cd_clifor \r\n" +
                         "inner join vtb_fin_endereco h \r\n" +
                         "on a.cd_clifor = h.cd_clifor \r\n" +
                         "and a.cd_endereco = h.cd_endereco \r\n" +
                         "where c.cd_empresa = '" + rLiq.Cd_empresa.Trim() + "' \r\n" +
                         "and c.nr_lancto = " + rLiq.Nr_lancto.ToString() + " \r\n" +
                         "and c.cd_parcela = " + rLiq.Cd_parcela.ToString() + " \r\n" +
                         "and c.id_liquid = " + rLiq.Id_liquid.ToString() + " \r\n";

            DataTable tb_recibo = ExecutarBusca(sql.Trim(), null);
            if (tb_recibo != null)
            {
                TList_Recibo lRecibo = new TList_Recibo();
                for (int i = 0; i < tb_recibo.Rows.Count; i++)
                {
                    TRecibo rec = new TRecibo();
                    rec.Bairro_recebi = tb_recibo.Rows[i]["bairro_recebi"].ToString();
                    rec.Cidade_recebi = tb_recibo.Rows[i]["cidade_recebi"].ToString();
                    rec.Complhistorico = tb_recibo.Rows[i]["complhistorico"].ToString();
                    //rec.Ds_cidade_recibo = tb_recibo.Rows[i]["ds_cidade_recibo"].ToString();
                    rec.Ds_endereco_recebi = tb_recibo.Rows[i]["ds_endereco_recebi"].ToString();
                    rec.Ds_historico = tb_recibo.Rows[i]["ds_historico"].ToString();
                    try
                    {
                        rec.Dt_liquidacao = Convert.ToDateTime(tb_recibo.Rows[i]["dt_liquidacao"].ToString());
                    }
                    catch { }
                    rec.Fone_recebi = tb_recibo.Rows[i]["fone_recebi"].ToString();
                    rec.Fone_recibo = tb_recibo.Rows[i]["fone_recibo"].ToString();
                    rec.Insc_estadual_recebi = tb_recibo.Rows[i]["insc_estadual_recebi"].ToString();
                    rec.Nm_recebi = tb_recibo.Rows[i]["nm_recebi"].ToString();
                    rec.Nm_recibo = tb_recibo.Rows[i]["nm_recibo"].ToString();
                    rec.Nr_cnpj_cpf_recebi = tb_recibo.Rows[i]["nr_cnpj_cpf_recebi"].ToString();
                    rec.Nr_cnpj_recibo = tb_recibo.Rows[i]["nr_cnpj_recibo"].ToString();
                    rec.Numero_recebi = tb_recibo.Rows[i]["numero_recebi"].ToString();
                    rec.Uf_recebi = tb_recibo.Rows[i]["uf_recebi"].ToString();
                    try
                    {
                        rec.Vl_liquidacao = Convert.ToDecimal(tb_recibo.Rows[i]["vl_liquidacao"].ToString());
                    }
                    catch { rec.Vl_liquidacao = 0; }

                    rec.Vl_extenso = new Extenso().ValorExtenso(rec.Vl_liquidacao, "Real", "Reais");
                    lRecibo.Add(rec);
                }
                return lRecibo;
            }
            else
                return null;
        }
    }
    #endregion

    #region "Liquidacao Cotacao"
    public class TList_LiquidacaoCotacao : List<TRegistro_LiquidacaoCotacao>
    { }


    public class TRegistro_LiquidacaoCotacao
    {

        public string Cd_empresa
        { get; set; }

        public decimal? Nr_lancto
        { get; set; }

        public decimal? Cd_parcela
        { get; set; }

        public decimal? Id_liquid
        { get; set; }

        public string Cd_moeda
        { get; set; }

        public string Ds_moeda
        { get; set; }

        public string Sigla
        { get; set; }

        public string Cd_moedaresult
        { get; set; }

        public string Ds_moedaresult
        { get; set; }

        public string Sigla_moedaresult
        { get; set; }

        public decimal Vl_cotacao
        { get; set; }

        private DateTime? dt_cotacao;

        public DateTime? Dt_cotacao
        {
            get { return dt_cotacao; }
            set
            {
                dt_cotacao = value;
                dt_cotacaostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }

        private string dt_cotacaostring;
        public string Dt_cotacaostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cotacaostring).ToString("dd/MM/yyyy");
                }
                catch
                { return null; }
            }
            set
            {
                dt_cotacaostring = value;
                try
                {
                    dt_cotacao = Convert.ToDateTime(value);
                }
                catch
                { dt_cotacao = null; }
            }
        }

        public string Login
        { get; set; }

        public string Operador
        { get; set; }

        public TRegistro_LiquidacaoCotacao()
        {
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Cd_parcela = null;
            Id_liquid = null;
            Cd_moeda = string.Empty;
            Cd_moedaresult = string.Empty;
            Vl_cotacao = decimal.Zero;
            Operador = string.Empty;
            dt_cotacao = null;
            dt_cotacaostring = string.Empty;
            Login = string.Empty;
        }
    }

    public class TCD_LiquidacaoCotacao : TDataQuery
    {
        public TCD_LiquidacaoCotacao()
        { }

        public TCD_LiquidacaoCotacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" Select " + strTop + " a.cd_empresa, a.nr_lancto, a.cd_parcela, ");
                sql.AppendLine("a.id_liquid, a.cd_moeda, b.ds_moeda_singular as ds_moeda, b.sigla, ");
                sql.AppendLine("a.cd_moedaresult, c.ds_moeda_singular as ds_moedaresult, c.sigla as sigla_moedaresult, ");
                sql.AppendLine("a.vl_cotacao, a.operador, a.DT_Cotacao, a.Login ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_liquidacao_cotacao a ");
            sql.AppendLine("inner join tb_fin_moeda b ");
            sql.AppendLine("on a.cd_moeda = b.cd_moeda ");
            sql.AppendLine("inner join tb_fin_moeda c ");
            sql.AppendLine("on a.cd_moedaresult = c.cd_moeda ");

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

        public TList_LiquidacaoCotacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LiquidacaoCotacao lista = new TList_LiquidacaoCotacao();
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
                    TRegistro_LiquidacaoCotacao reg = new TRegistro_LiquidacaoCotacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Liquid")))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda"))))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla"))))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MoedaResult"))))
                        reg.Cd_moedaresult = reader.GetString(reader.GetOrdinal("CD_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MoedaResult"))))
                        reg.Ds_moedaresult = reader.GetString(reader.GetOrdinal("DS_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_MoedaResult"))))
                        reg.Sigla_moedaresult = reader.GetString(reader.GetOrdinal("Sigla_MoedaResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Cotacao"))))
                        reg.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("Vl_Cotacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Operador"))))
                        reg.Operador = reader.GetString(reader.GetOrdinal("Operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cotacao")))
                        reg.Dt_cotacao = reader.GetDateTime(reader.GetOrdinal("DT_Cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));

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

        public string GravarLiquidacaoCotacao(TRegistro_LiquidacaoCotacao val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_MOEDARESULT", val.Cd_moedaresult);
            hs.Add("@P_VL_COTACAO", val.Vl_cotacao);
            hs.Add("@P_OPERADOR", val.Operador);
            hs.Add("@P_DT_COTACAO", val.Dt_cotacao);
            hs.Add("@P_LOGIN", val.Login);

            return executarProc("IA_FIN_LIQUIDACAO_COTACAO", hs);
        }

        public string DeletarLiquidacaoCotacao(TRegistro_LiquidacaoCotacao val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);

            return executarProc("EXCLUI_FIN_LIQUIDACAO_COTACAO", hs);
        }
    }
    #endregion"

    #region "Duplicata X Centro Custo"
    public class TList_DuplicataXCcusto : List<TRegistro_DuplicataXCCusto>
    { }


    public class TRegistro_DuplicataXCCusto
    {

        public string Cd_empresa
        { get; set; }

        public decimal? Nr_lancto
        { get; set; }

        public decimal? Id_ccustolan
        { get; set; }

        public TRegistro_DuplicataXCCusto()
        {
            Cd_empresa = string.Empty;
            Nr_lancto = null;
            Id_ccustolan = null;
        }
    }

    public class TCD_DuplicataXCCusto : TDataQuery
    {
        public TCD_DuplicataXCCusto()
        { }

        public TCD_DuplicataXCCusto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.nr_lancto, a.id_ccustolan ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_Duplicata_X_CCusto a ");

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

        public TList_DuplicataXCcusto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DuplicataXCcusto lista = new TList_DuplicataXCcusto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DuplicataXCCusto reg = new TRegistro_DuplicataXCCusto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CCustoLan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("ID_CCustoLan"));

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

        public string Gravar(TRegistro_DuplicataXCCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("IA_FIN_DUPLICATAXCCUSTO", hs);
        }

        public string Excluir(TRegistro_DuplicataXCCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return executarProc("EXCLUI_FIN_DUPLICATAXCCUSTO", hs);
        }
    }
    #endregion"

    #region "RELATORIO EXTRATO CONTAS CLIFOR"
    public class TCD_RelExtratoContasClifor : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] filtro, TpBusca[] fLiq, short vTipo)
        {
            StringBuilder sql = new StringBuilder();
            if (vTipo != 2)
            {
                sql.AppendLine("select 'Parcela' , b.cd_empresa, e.nm_empresa, ");
                sql.AppendLine("a.nr_lancto, a.nr_docto, b.cd_parcela, a.tp_duplicata, ");
                sql.AppendLine("c.tp_mov, b.dt_vencto, b.vl_parcela_padrao, ");
                sql.AppendLine("DBO.F_CALC_ATUAL(b.cd_empresa, b.nr_lancto, b.cd_parcela, getDate(), 'S') + ");
                sql.AppendLine("isnull((select isnull(sum(vl_liquidacao_padrao),0) from tb_fin_liquidacao x ");
                sql.AppendLine("		where x.cd_empresa = b.cd_empresa and x.nr_lancto = b.nr_lancto ");
                sql.AppendLine("		and x.cd_parcela = b.cd_parcela and x.st_registro <> 'C'),0) as Vl_Atual, ");
                sql.AppendLine("0 as vl_liquidacao, a.dt_emissao as data, a.cd_clifor, d.nm_clifor, '' as cd_conta, ");
                sql.AppendLine("'' as ds_conta, a.complhistorico ");
                sql.AppendLine("from tb_fin_duplicata a ");
                sql.AppendLine("inner join tb_fin_parcela b ");
                sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
                sql.AppendLine("inner join tb_fin_tpduplicata c ");
                sql.AppendLine("on a.tp_duplicata = c.tp_duplicata ");
                sql.AppendLine("inner join vtb_fin_clifor d ");
                sql.AppendLine("on a.cd_clifor = d.cd_clifor ");
                sql.AppendLine("inner join tb_div_empresa e ");
                sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
                sql.AppendLine("where a.qt_parcelas > 0 ");
                sql.AppendLine("and a.st_registro <> 'C' ");
                string cond = " and ";
                if (filtro != null)
                    foreach (TpBusca busca in filtro)
                        sql.AppendLine(cond + "(" + busca.vNM_Campo + " " + busca.vOperador + " " + busca.vVL_Busca + " )");
            }
            if (vTipo.Equals(0))
                sql.AppendLine("union all ");
            if (vTipo != 1)
            {
                sql.AppendLine("select 'Pagto', b.cd_empresa, g.nm_empresa, ");
                sql.AppendLine("a.nr_lancto, a.nr_docto, b.cd_parcela, a.tp_duplicata, ");
                sql.AppendLine("e.tp_mov, b.dt_vencto, b.vl_parcela_padrao, 0 as vl_atual, ");
                sql.AppendLine("c.vl_liquidacao_padrao, c.dt_liquidacao as data, a.cd_clifor, ");
                sql.AppendLine("f.nm_clifor, h.cd_contager, h.ds_contager, a.complhistorico ");
                sql.AppendLine("from tb_fin_duplicata a ");
                sql.AppendLine("inner join tb_fin_parcela b ");
                sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
                sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
                sql.AppendLine("inner join tb_fin_liquidacao c ");
                sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
                sql.AppendLine("and b.nr_lancto = c.nr_lancto ");
                sql.AppendLine("and b.cd_parcela = c.cd_parcela ");
                sql.AppendLine("inner join tb_fin_caixa d ");
                sql.AppendLine("on c.cd_contager = d.cd_contager ");
                sql.AppendLine("and c.cd_lanctocaixa = d.cd_lanctocaixa ");
                sql.AppendLine("inner join tb_fin_tpduplicata e ");
                sql.AppendLine("on a.tp_duplicata = e.tp_duplicata ");
                sql.AppendLine("inner join vtb_fin_clifor f ");
                sql.AppendLine("on a.cd_clifor = f.cd_clifor ");
                sql.AppendLine("inner join tb_div_empresa g ");
                sql.AppendLine("on a.cd_empresa = g.cd_empresa ");
                sql.AppendLine("inner join tb_fin_contager h ");
                sql.AppendLine("on d.cd_contager = h.cd_contager ");
                sql.AppendLine("where a.qt_parcelas > 0 ");
                sql.AppendLine("and a.st_registro <> 'C' ");
                string cond = " and ";
                if (filtro != null)
                    foreach (TpBusca busca in filtro)
                        sql.AppendLine(cond + "(" + busca.vNM_Campo.Trim() + " " + busca.vOperador.Trim() + " " + busca.vVL_Busca.Trim() + ")");
                if (vTipo.Equals(2))
                    foreach (TpBusca busca in fLiq)
                        sql.AppendLine(cond + "(" + busca.vNM_Campo.Trim() + " " + busca.vOperador.Trim() + " " + busca.vVL_Busca.Trim() + ")");
            }
            return sql.ToString();
        }

        public DataTable BuscarExtratoContasClifor(TpBusca[] filtro, TpBusca[] fLiq, short vTipo)
        {
            return ExecutarBusca(SqlCodeBusca(filtro, fLiq, vTipo), null);
        }
    }
    #endregion

    #region Relatorio Extrato Gerencial cliente/fornecedor
    public class TCD_RelGerExtratoClifor : TDataQuery
    {
        private string SqlCodeBusca(string Cd_clifor, DateTime Dt_inicio, bool St_saldoanterior)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select 'FINANCEIRO' as tp_lancto, a.nr_docto, a.dt_emissao as dt_lancto, a.cd_historico, b.ds_historico, ");
            sql.AppendLine("vl_pagar = case when c.tp_mov = 'P' then ISNULL((select sum(x.Vl_Parcela) ");
            sql.AppendLine("												from tb_fin_parcela x ");
            sql.AppendLine("												where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("												and x.nr_lancto = a.nr_lancto), 0) else 0 end, ");
            sql.AppendLine("vl_receber = case when c.tp_mov = 'R' then ISNULL((select sum(x.Vl_Parcela) ");
            sql.AppendLine("												from tb_fin_parcela x ");
            sql.AppendLine("												where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("												and x.nr_lancto = a.nr_lancto), 0) else 0 end, ");
            sql.AppendLine("id_ticket = isnull((select top 1 w.id_ticket ");
            sql.AppendLine("					from tb_fat_notafiscal_x_duplicata x ");
            sql.AppendLine("					inner join tb_fat_notafiscal y ");
            sql.AppendLine("					on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_fat_aplicacao_x_notafiscal z ");
            sql.AppendLine("					on y.cd_empresa = z.cd_empresa ");
            sql.AppendLine("					and y.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_bal_aplicacao_pedido w ");
            sql.AppendLine("					on z.id_aplicacao = w.id_aplicacao ");
            sql.AppendLine("					where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctoduplicata = a.nr_lancto), 0), ");
            sql.AppendLine("ps_aplicado = isnull((select sum(q.qtd_nota) ");
            sql.AppendLine("					from tb_fat_notafiscal_x_duplicata x ");
            sql.AppendLine("					inner join tb_fat_notafiscal y ");
            sql.AppendLine("					on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_fat_aplicacao_x_notafiscal z ");
            sql.AppendLine("					on y.cd_empresa = z.cd_empresa ");
            sql.AppendLine("					and y.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_bal_aplicacao_pedido w ");
            sql.AppendLine("					on z.id_aplicacao = w.id_aplicacao ");
            sql.AppendLine("					inner join vtb_bal_desdobro q ");
            sql.AppendLine("					on w.cd_empresa = q.cd_empresa ");
            sql.AppendLine("					and w.id_ticket = q.id_ticket ");
            sql.AppendLine("					and w.tp_pesagem = q.tp_pesagem ");
            sql.AppendLine("					and w.id_desdobro = q.id_desdobro ");
            sql.AppendLine("					and w.id_item = q.id_item ");
            sql.AppendLine("					where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctoduplicata = a.nr_lancto), 0), ");
            sql.AppendLine("vl_unitario = isnull((select top 1 q.vl_unitario ");
            sql.AppendLine("					from tb_fat_notafiscal_x_duplicata x ");
            sql.AppendLine("					inner join tb_fat_notafiscal y ");
            sql.AppendLine("					on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_fat_aplicacao_x_notafiscal z ");
            sql.AppendLine("					on y.cd_empresa = z.cd_empresa ");
            sql.AppendLine("					and y.nr_lanctofiscal = z.nr_lanctofiscal ");
            sql.AppendLine("					inner join tb_bal_aplicacao_pedido w ");
            sql.AppendLine("					on z.id_aplicacao = w.id_aplicacao ");
            sql.AppendLine("					inner join vtb_bal_desdobro q ");
            sql.AppendLine("					on w.cd_empresa = q.cd_empresa ");
            sql.AppendLine("					and w.id_ticket = q.id_ticket ");
            sql.AppendLine("					and w.tp_pesagem = q.tp_pesagem ");
            sql.AppendLine("					and w.id_desdobro = q.id_desdobro ");
            sql.AppendLine("					and w.id_item = q.id_item ");
            sql.AppendLine("					where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("					and x.nr_lanctoduplicata = a.nr_lancto), 0), '' as nr_cheque ");

            sql.AppendLine("from tb_fin_duplicata a ");
            sql.AppendLine("inner join tb_fin_historico b ");
            sql.AppendLine("on a.cd_historico = b.cd_historico ");
            sql.AppendLine("inner join tb_fin_tpduplicata c ");
            sql.AppendLine("on a.tp_duplicata = c.tp_duplicata ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_clifor = '" + Cd_clifor.Trim() + "'");
            sql.AppendLine("and a.dt_emissao " + (St_saldoanterior ? "< '" : ">= '") + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_inicio.ToString("yyyyMMdd")) + " 00:00:00'");

            sql.AppendLine(" union all ");

            sql.AppendLine("select 'LIQUIDACAO' as tp_lancto, a.Nr_Docto, a.DT_Lancto, a.CD_Historico, ");
            sql.AppendLine("b.DS_Historico, a.Vl_RECEBER as vl_pagar, a.Vl_PAGAR as vl_receber, 0 as id_ticket, 0 as ps_aplicado, 0 as vl_unitario, ");
            sql.AppendLine("nr_cheque = isnull((select top 1 y.nr_cheque from tb_fin_titulo_x_caixa x ");
            sql.AppendLine("                    inner join tb_fin_titulo y ");
            sql.AppendLine("                    on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                    and x.cd_banco = y.cd_banco ");
            sql.AppendLine("                    and x.nr_lanctocheque = y.nr_lanctocheque ");
            sql.AppendLine("                    where x.cd_contager = a.cd_contager ");
            sql.AppendLine("                    and x.cd_lanctocaixa = a.cd_lanctocaixa), '') ");
            sql.AppendLine("from TB_FIN_Caixa a ");
            sql.AppendLine("inner join TB_FIN_Historico b ");
            sql.AppendLine("on a.CD_Historico = b.CD_Historico ");
            sql.AppendLine("where isnull(a.st_estorno, 'N') <> 'S' ");
            sql.AppendLine("and a.dt_lancto " + (St_saldoanterior ? "< '" : ">= '") + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_inicio.ToString("yyyyMMdd")) + " 00:00:00'");
            sql.AppendLine("and exists(select 1 from TB_FIN_Liquidacao x ");
            sql.AppendLine("			inner join TB_FIN_Parcela y ");
            sql.AppendLine("			on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("			and x.Nr_Lancto = y.Nr_Lancto ");
            sql.AppendLine("			and x.CD_Parcela = y.CD_Parcela ");
            sql.AppendLine("			inner join TB_FIN_Duplicata z ");
            sql.AppendLine("			on y.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("			and y.Nr_Lancto = z.Nr_Lancto ");
            sql.AppendLine("			where x.CD_ContaGer = a.CD_ContaGer ");
            sql.AppendLine("			and ((x.CD_LanctoCaixa = a.CD_LanctoCaixa) or ");
            sql.AppendLine("				 (x.CD_LanctoCaixa_DCamb_AT = a.CD_LanctoCaixa) or ");
            sql.AppendLine("				 (x.CD_LanctoCaixa_DCamb_PA = a.CD_LanctoCaixa) or ");
            sql.AppendLine("				 (x.CD_LanctoCaixa_Desc = a.CD_LanctoCaixa) or ");
            sql.AppendLine("				 (x.CD_LanctoCaixa_Juro = a.CD_LanctoCaixa)) ");
            sql.AppendLine("			and z.CD_Clifor = '" + Cd_clifor.Trim() + "') ");

            sql.AppendLine(" union all ");

            sql.AppendLine("select 'ADIANTAMENTO' as tp_lancto, convert(varchar(10), a.id_adto), c.dt_lancto, c.cd_historico, d.ds_historico, ");
            sql.AppendLine("c.vl_receber as vl_pagar, c.vl_pagar as vl_receber, 0 as id_ticket, 0 as ps_aplicado, 0 as vl_unitario, ");
            sql.AppendLine("nr_cheque = isnull((select top 1 y.nr_cheque from tb_fin_titulo_x_caixa x ");
            sql.AppendLine("                    inner join tb_fin_titulo y ");
            sql.AppendLine("                    on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                    and x.cd_banco = y.cd_banco ");
            sql.AppendLine("                    and x.nr_lanctocheque = y.nr_lanctocheque ");
            sql.AppendLine("                    where x.cd_contager = c.cd_contager ");
            sql.AppendLine("                    and x.cd_lanctocaixa = c.cd_lanctocaixa), '') ");
            sql.AppendLine("from tb_fin_adiantamento a ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa b ");
            sql.AppendLine("on a.id_adto = b.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa c ");
            sql.AppendLine("on b.cd_contager = c.cd_contager ");
            sql.AppendLine("and b.cd_lanctocaixa = c.cd_lanctocaixa ");
            sql.AppendLine("inner join tb_fin_historico d ");
            sql.AppendLine("on c.cd_historico = d.cd_historico ");
            sql.AppendLine("where isnull(c.st_estorno, 'N') <> 'S' ");
            sql.AppendLine("and isnull(a.st_adto, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_clifor = '" + Cd_clifor.Trim() + "' ");
            sql.AppendLine("and c.dt_lancto " + (St_saldoanterior ? "< '" : ">= '") + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_inicio.ToString("yyyyMMdd")) + " 00:00:00'");

            sql.AppendLine("order by dt_lancto ");

            return sql.ToString();
        }

        public DataTable Buscar(string Cd_clifor, DateTime Dt_inicio, bool St_saldoanterior)
        {
            return ExecutarBusca(SqlCodeBusca(Cd_clifor, Dt_inicio, St_saldoanterior), null);
        }
    }
    #endregion

    #region "SINTÉTICO DUPLICATAS"

    public class TCD_DuplicataSINT : TDataQuery
    {
        public DataTable BuscarSint(TpBusca[] vBusca)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0), null);
        }

        public DataTable BuscarSintCliFor(TpBusca[] vBusca)
        {
            return ExecutarBusca(SqlCodeBuscaCLIFOR(vBusca, 0), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop)
        {
            StringBuilder sql = new StringBuilder();
            string cond = "";

            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql.AppendLine("select " + strTop + " b.tp_duplicata, b.ds_tpduplicata , b.TP_Mov ");
            //Valor Contabil
            sql.AppendLine(",isnull(( select sum(isNull(a.vl_Documento_Padrao, 0)) from tb_fin_duplicata a  ");
            sql.AppendLine("        where a.tp_duplicata = b.tp_duplicata and a.st_registro <> 'C' ),0)   as  Contabil ");
            //Valor em Aberto
            sql.AppendLine(", dbo.F_CALC_VL_DUP_MOEDAPADRAO(d.cd_empresa, d.nr_lancto, null, 'S', getDate(), isnull(( select sum(isNull(y.vl_parcela, 0)) from tb_fin_duplicata a join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto ");
            sql.AppendLine(" where a.tp_duplicata = b.tp_duplicata and a.st_registro <> 'C' and y.ST_registro in ('A','P') ),0))  as Aberto ");
            //Valor Vencido
            sql.AppendLine(", dbo.F_CALC_VL_DUP_MOEDAPADRAO(d.cd_empresa, d.nr_lancto, null, 'S', getDate(), isnull(( select sum(isNull(y.vl_parcela, 0)) from tb_fin_duplicata a join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto  ");
            sql.AppendLine("        where a.tp_duplicata = b.tp_duplicata and a.st_registro <> 'C' and y.ST_registro in ('A','P')  and y.dt_vencto < getdate() ),0))  as  Vencidas ");
            //Valor a Vencer
            sql.AppendLine(", dbo.F_CALC_VL_DUP_MOEDAPADRAO(d.cd_empresa, d.nr_lancto, null, 'S', getDate(), isnull(( select sum(isNull(y.vl_parcela_padrao, 0)) from tb_fin_duplicata a join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto ");
            sql.AppendLine("        where a.tp_duplicata = b.tp_duplicata and a.st_registro <> 'C' and y.ST_registro in ('A','P')  and y.dt_vencto >= getdate() ),0)) as  aVencer ");
            //Valor liquidado
            sql.AppendLine(",isnull((select sum(abs(isnull(n.vl_receber,0) - isnull(n.vl_pagar,0)) )");
            sql.AppendLine("from tb_fin_duplicata a");
            sql.AppendLine("join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto");
            sql.AppendLine("join TB_Fin_Liquidacao L on l.cd_empresa = y.cd_empresa and l.nr_lancto = y.nr_lancto and l.cd_parcela = y.cd_parcela");
            sql.AppendLine("left outer join TB_Fin_Caixa n on n.cd_contager = l.cd_contager and n.cd_lanctocaixa = l.cd_lanctocaixa");
            sql.AppendLine("where a.tp_duplicata = b.tp_duplicata ");
            sql.AppendLine("and a.st_registro <> 'C' ");
            sql.AppendLine("and y.ST_registro in ('L','P') ");
            sql.AppendLine("and l.st_registro <> 'C'),0)  as Liquidadas ");
            //Valor Juros
            sql.AppendLine(",isnull((select sum(abs(isnull(n.vl_receber,0) - isnull(n.vl_pagar,0)) )");
            sql.AppendLine("from tb_fin_duplicata a");
            sql.AppendLine("join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto");
            sql.AppendLine("join TB_Fin_Liquidacao L on l.cd_empresa = y.cd_empresa and l.nr_lancto = y.nr_lancto and l.cd_parcela = y.cd_parcela");
            sql.AppendLine("left outer join TB_Fin_Caixa n on n.cd_contager = l.cd_contager and n.cd_lanctocaixa = l.cd_lanctocaixa_juro");
            sql.AppendLine("where a.tp_duplicata = b.tp_duplicata ");
            sql.AppendLine("and a.st_registro <> 'C' ");
            sql.AppendLine("and y.ST_registro in ('L','P') ");
            sql.AppendLine("and l.st_registro <> 'C'),0)  as Juros ");
            //Valor Descontos
            sql.AppendLine(",isnull((select sum(abs(isnull(n.vl_receber,0) - isnull(n.vl_pagar,0)) )");
            sql.AppendLine("from tb_fin_duplicata a");
            sql.AppendLine("join tb_FIN_PARCELA Y on a.cd_empresa = y.cd_empresa and a.nr_lancto = y.nr_lancto");
            sql.AppendLine("join TB_Fin_Liquidacao L on l.cd_empresa = y.cd_empresa and l.nr_lancto = y.nr_lancto and l.cd_parcela = y.cd_parcela");
            sql.AppendLine("left outer join TB_Fin_Caixa n on n.cd_contager = l.cd_contager and n.cd_lanctocaixa = l.cd_lanctocaixa_desc");
            sql.AppendLine("where a.tp_duplicata = b.tp_duplicata ");
            sql.AppendLine("and a.st_registro <> 'C' ");
            sql.AppendLine("and y.ST_registro in ('L','P') ");
            sql.AppendLine("and l.st_registro <> 'C'),0)  as Descontos ");

            sql.AppendLine(" from TB_FIN_TPDuplicata b ");
            sql.AppendLine("inner join TB_FIN_Duplicata d ");
            sql.AppendLine("on b.tp_duplicata = d.tp_duplicata ");
            cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                { sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")"); }
            sql.AppendLine("group by b.tp_duplicata, b.ds_tpduplicata , b.TP_Mov ");
            sql.AppendLine("order by b.tp_duplicata");
            return sql.ToString();
        }

        private string SqlCodeBuscaCLIFOR(TpBusca[] vBusca, Int32 vTop)
        {
            StringBuilder sql = new StringBuilder();
            string cond = "";

            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql.AppendLine("select a.cd_clifor, a.NM_Clifor ");
            //Total Vl_Contabil_Receber
            sql.AppendLine(",sum(case when t.tp_mov = 'R' then b.vl_documento_padrao else 0 end) as Vl_Contabil_Rec");
            //Total Vl_Contabil_Pagar
            sql.AppendLine(",sum(case when t.tp_mov = 'P' then b.vl_documento_padrao else 0 end) as Vl_Contabil_Pag");
            //Total Adiantamento Concedido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'C' then isNull(z.vl_pagar,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_Adto_Concedido ");
            //Total Devolução Adiantamento Concedido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'C' then isNull(z.vl_receber,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_DevAdto_Concedido ");
            //Saldo Adiantamento Concedido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'C' then isNull(z.vl_pagar,0) - isNull(z.vl_receber,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_Saldo_AdtoConcedido ");
            //Total Adiantamento Recebido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'R' then isNull(z.vl_receber,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_Adto_Recebido ");
            //Total Devolução Adiantamento Recebido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'R' then isNull(z.vl_pagar,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_DevAdto_Recebido ");
            //Saldo Adiantamento Recebido
            sql.AppendLine(",(select isNull(sum(case when x.tp_movimento = 'R' then isNull(z.vl_receber,0) - isNull(z.vl_pagar,0) else 0 end),0) ");
            sql.AppendLine("from tb_fin_adiantamento x ");
            sql.AppendLine("inner join tb_fin_adiantamento_x_caixa y ");
            sql.AppendLine("on x.id_adto = y.id_adto ");
            sql.AppendLine("inner join tb_fin_caixa z ");
            sql.AppendLine("on y.cd_contager = z.cd_contager ");
            sql.AppendLine("and y.cd_lanctocaixa = z.cd_lanctocaixa ");
            sql.AppendLine("where x.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and isNull(z.st_estorno, 'N') <> 'C')as Vl_Saldo_AdtoRecebido ");

            sql.AppendLine("from tb_Fin_Clifor a");
            sql.AppendLine("join tb_fin_duplicata b on a.cd_clifor = b.cd_clifor");
            sql.AppendLine("join tb_fin_tpduplicata t on t.tp_duplicata = b.tp_duplicata");
            sql.AppendLine("where b.st_registro <> 'C'");

            cond = " and ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                {
                    for (int i = 0; i < (vBusca.Length); i++)
                    { sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")"); }
                }
            sql.AppendLine("group by a.cd_clifor, a.NM_Clifor ");
            sql.AppendLine("order by a.cd_clifor");

            return sql.ToString();
        }
    }
    #endregion

    #region Duplicatas - Painel Gerencial

    public class TRegistro_DupPainel
    {
        public string Ds_label
        { get; set; }
        public decimal Valor
        { get; set; }

        public TRegistro_DupPainel()
        {
            Ds_label = string.Empty;
            Valor = decimal.Zero;
        }
    }

    public class TCD_DupPainel : TDataQuery
    {
        public TCD_DupPainel()
        { }

        public TCD_DupPainel(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string lEmpresa, string Tp_mov, DateTime Dt_atual)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select 'VENCIDAS + 120 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) < '" + Dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS + 90 a 120 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) >= '" + Dt_atual.AddDays(-120).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) < '" + Dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS + 60 a 90 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) >= '" + Dt_atual.AddDays(-90).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) < '" + Dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS + 30 a 60 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) >= '" + Dt_atual.AddDays(-60).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) < '" + Dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS a 30 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) >= '" + Dt_atual.AddDays(-30).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) < '" + Dt_atual.ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCE HOJE' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) = '" + Dt_atual.ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCER a 30 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) > '" + Dt_atual.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) <= '" + Dt_atual.AddDays(30).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCER + 30 a 60 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) > '" + Dt_atual.AddDays(30).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) <= '" + Dt_atual.AddDays(60).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS + 60 a 90 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) > '" + Dt_atual.AddDays(60).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) <= '" + Dt_atual.AddDays(90).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCER + 90 a 120 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) > '" + Dt_atual.AddDays(90).ToString("yyyyMMdd") + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) <= '" + Dt_atual.AddDays(120).ToString("yyyyMMdd") + "'");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'VENCIDAS + 120 DIAS' AS Label, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(case when ISNULL(a.ST_Registro, 'A') = 'L' then 0 else DBO.F_CALC_ATUAL(a.CD_Empresa, a.NR_Lancto, b.CD_Parcela, getDate(), 'S') end, 0)), 0) as Valor ");
            sql.AppendLine("from TB_FIN_Duplicata a ");
            sql.AppendLine("inner join TB_FIN_PARCELA b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = b.NR_Lancto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata c ");
            sql.AppendLine("on a.TP_Duplicata = c.TP_Duplicata ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'L' ");
            sql.AppendLine("and a.cd_empresa in(" + lEmpresa.Trim() + ")");
            sql.AppendLine("and c.tp_mov = '" + Tp_mov.Trim() + "'");
            sql.AppendLine("and CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), b.DT_Vencto))) > '" + Dt_atual.AddDays(120).ToString("yyyyMMdd") + "'");

            return sql.ToString();
        }

        public List<TRegistro_DupPainel> Select(string Cd_empresa, string Tp_mov, DateTime Dt_atual)
        {
            bool podeFecharBco = false;
            List<TRegistro_DupPainel> lista = new List<TRegistro_DupPainel>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Tp_mov, Dt_atual));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DupPainel reg = new TRegistro_DupPainel();
                    if (!reader.IsDBNull(reader.GetOrdinal("label")))
                        reg.Ds_label = reader.GetString(reader.GetOrdinal("label"));
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
    }
    #endregion

    #region Extrato Declaracao Imposto Renda
    public class TRegistro_ExtratoIR
    {
        public string Cd_empresa
        { get; set; }
        public string NM_Empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_cgc_cpf
        { get; set; }
        public int Mes
        { get; set; }
        public decimal Vl_recebido
        { get; set; }
        public decimal Vl_pago
        { get; set; }

        public TRegistro_ExtratoIR()
        {
            Cd_empresa = string.Empty;
            NM_Empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cgc_cpf = string.Empty;
            Mes = 0;
            Vl_recebido = decimal.Zero;
            Vl_pago = decimal.Zero;
        }

        public TRegistro_ExtratoIR Copy(TRegistro_ExtratoIR val)
        {
            TRegistro_ExtratoIR ret = new TRegistro_ExtratoIR();
            ret.Cd_empresa = val.Cd_empresa;
            ret.NM_Empresa = val.NM_Empresa;
            ret.Cd_clifor = val.Cd_clifor;
            ret.Nm_clifor = val.Nm_clifor;
            ret.Nr_cgc_cpf = val.Nr_cgc_cpf;
            ret.Mes = val.Mes;
            ret.Vl_recebido = val.Vl_recebido;
            ret.Vl_pago = val.Vl_pago;

            return ret;
        }
    }

    public class TCD_ExtratoIR : TDataQuery
    {
        public TCD_ExtratoIR() { }

        public TCD_ExtratoIR(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, string Cd_clifor, string Exercicio)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, c.nm_empresa, d.cd_clifor, d.nm_clifor, ");
            sql.AppendLine("case when d.tp_pessoa = 'J' then d.nr_cgc else d.nr_cpf end as NR_CGC_CPF, ");
            sql.AppendLine("month(a.DT_Emissao) as Mes, ");
            sql.AppendLine("Vl_Recebido = case when b.tp_mov = 'R' then sum(isnull(a.VL_Documento, 0)) else 0 end, ");
            sql.AppendLine("Vl_Pago = case when b.tp_mov = 'P' then sum(isnull(a.VL_Documento, 0)) else 0 end ");

            sql.AppendLine("from tb_fin_duplicata a ");
            sql.AppendLine("inner join tb_fin_tpduplicata b ");
            sql.AppendLine("on a.tp_duplicata = b.tp_duplicata ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor d ");
            sql.AppendLine("on a.cd_clifor = d.cd_clifor ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and year(a.dt_emissao) = " + Exercicio);
            sql.AppendLine("and a.cd_clifor = '" + Cd_clifor.Trim() + "'");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");

            sql.AppendLine("group by a.cd_empresa, c.nm_empresa, ");
            sql.AppendLine("d.cd_clifor, d.nm_clifor, d.tp_pessoa, d.nr_cgc, d.nr_cpf, ");
            sql.AppendLine("b.tp_mov, month(a.dt_emissao) ");

            return sql.ToString();
        }

        public List<TRegistro_ExtratoIR> Select(string Cd_empresa, string Cd_clifor, string Exercicio)
        {
            bool podeFecharBco = false;
            List<TRegistro_ExtratoIR> lista = new List<TRegistro_ExtratoIR>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_clifor, Exercicio));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ExtratoIR reg = new TRegistro_ExtratoIR();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf")))
                        reg.Nr_cgc_cpf = reader.GetString(reader.GetOrdinal("nr_cgc_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetInt32(reader.GetOrdinal("Mes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Recebido")))
                        reg.Vl_recebido = reader.GetDecimal(reader.GetOrdinal("Vl_Recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Pago")))
                        reg.Vl_pago = reader.GetDecimal(reader.GetOrdinal("Vl_Pago"));

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
    }
    #endregion

    #region Fluxo Caixa
    public class TRegistro_FluxoCaixa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public DateTime? Dt_vencto
        { get; set; }
        public decimal Sd_ant
        { get; set; }
        public decimal Vl_pagar
        { get; set; }
        public decimal Vl_receber
        { get; set; }
        public decimal Sd_atual
        { get; set; }

        public TRegistro_FluxoCaixa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Dt_vencto = null;
            Sd_ant = decimal.Zero;
            Vl_pagar = decimal.Zero;
            Vl_receber = decimal.Zero;
            Sd_atual = decimal.Zero;
        }
    }

    public class TCD_FluxoCaixa : TDataQuery
    {
        public TCD_FluxoCaixa() { }

        public TCD_FluxoCaixa(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        public List<TRegistro_FluxoCaixa> Select(string Cd_empresa,
                                                 DateTime Dt_ini,
                                                 DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, b.NM_Empresa, a.dt_vencto, ");
            sql.AppendLine("sd_ant = isnull((select sum(x.vl_receber - vl_pagar) ");
            sql.AppendLine("				from VTB_FIN_FLUXOCAIXA x ");
            sql.AppendLine("				where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("				and x.dt_vencto < a.dt_vencto), 0), ");
            sql.AppendLine("a.vl_pagar, a.vl_receber, ");
            sql.AppendLine("sd_atual = isnull((select sum(x.vl_receber - vl_pagar) ");
            sql.AppendLine("				from VTB_FIN_FLUXOCAIXA x ");
            sql.AppendLine("				where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("				and x.dt_vencto <= a.dt_vencto), 0) ");

            sql.AppendLine("from vtb_fin_fluxocaixa a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and a.dt_vencto >= '" + Dt_ini.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and a.dt_vencto <= '" + Dt_fin.ToString("yyyyMMdd") + "' ");

            sql.AppendLine("order by a.dt_vencto ");

            bool podeFecharBco = false;
            List<TRegistro_FluxoCaixa> lista = new List<TRegistro_FluxoCaixa>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_FluxoCaixa reg = new TRegistro_FluxoCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencto")))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("dt_vencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sd_ant")))
                        reg.Sd_ant = reader.GetDecimal(reader.GetOrdinal("sd_ant"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pagar")))
                        reg.Vl_pagar = reader.GetDecimal(reader.GetOrdinal("vl_pagar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_receber")))
                        reg.Vl_receber = reader.GetDecimal(reader.GetOrdinal("vl_receber"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sd_atual")))
                        reg.Sd_atual = reader.GetDecimal(reader.GetOrdinal("sd_atual"));

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
    }
    #endregion

    #region Atualização Vencto Parcela
    public class TList_AtVenctoParcela : List<TRegistro_AtVenctoParcela>, IComparer<TRegistro_AtVenctoParcela>
    {
        #region IComparer<TRegistro_AtVenctoParcela> Members
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

        public TList_AtVenctoParcela()
        { }

        public TList_AtVenctoParcela(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AtVenctoParcela value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AtVenctoParcela x, TRegistro_AtVenctoParcela y)
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

    public class TRegistro_AtVenctoParcela
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch
                { cd_parcela = null; }
            }
        }
        private decimal? id_atualiza;
        public decimal? Id_atualiza
        {
            get { return id_atualiza; }
            set
            {
                id_atualiza = value;
                id_atualizastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atualizastr;
        public string Id_atualizastr
        {
            get { return id_atualizastr; }
            set
            {
                id_atualizastr = value;
                try
                {
                    id_atualiza = decimal.Parse(value);
                }
                catch
                { id_atualiza = null; }
            }
        }
        public string LoginAtualiza
        { get; set; }
        private DateTime? dt_vencto;
        public DateTime? Dt_vencto
        {
            get { return dt_vencto; }
            set
            {
                dt_vencto = value;
                dt_venctostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_venctostring;
        public string Dt_venctostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_venctostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_venctostring = value;
                try
                {
                    dt_vencto = Convert.ToDateTime(value);
                }
                catch
                { dt_vencto = null; }
            }
        }
        public decimal Vl_parcela
        { get; set; }

        public TRegistro_AtVenctoParcela()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            cd_parcela = null;
            cd_parcelastr = string.Empty;
            id_atualiza = null;
            id_atualizastr = string.Empty;
            dt_vencto = null;
            dt_venctostring = string.Empty;
            LoginAtualiza = string.Empty;
            Vl_parcela = decimal.Zero;
        }
    }

    public class TCD_AtVenctoParcela : TDataQuery
    {
        public TCD_AtVenctoParcela()
        { }

        public TCD_AtVenctoParcela(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder, string vGroup)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.Nr_Lancto, ");
                sql.AppendLine("a.CD_Parcela, a.ID_Atualiza, a.LoginAtualiza, a.DT_Vencto, a.Vl_Parcela");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_AtVenctoParcela a ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order by " + vOrder.Trim());
            return sql.ToString();
        }


        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override Object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public TList_AtVenctoParcela Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder, string vGroup)
        {
            bool podeFecharBco = false;
            TList_AtVenctoParcela lista = new TList_AtVenctoParcela();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder, vGroup));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AtVenctoParcela reg = new TRegistro_AtVenctoParcela();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Atualiza"))))
                        reg.Id_atualiza = reader.GetDecimal(reader.GetOrdinal("ID_Atualiza"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("LoginAtualiza"))))
                        reg.LoginAtualiza = reader.GetString(reader.GetOrdinal("LoginAtualiza"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Dt_vencto"))))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("Dt_vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_parcela"))))
                        reg.Vl_parcela = reader.GetDecimal(reader.GetOrdinal("Vl_parcela"));

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

        public string Grava(TRegistro_AtVenctoParcela val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_ATUALIZA", val.Id_atualiza);
            hs.Add("@P_LOGINATUALIZA", val.LoginAtualiza);
            hs.Add("@P_DT_VENCTO", val.Dt_vencto);
            hs.Add("@P_VL_PARCELA", val.Vl_parcela);

            return executarProc("IA_FIN_ATVENCTOPARCELA", hs);
        }

        public string Exclui(TRegistro_AtVenctoParcela val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_ATUALIZA", val.Id_atualiza);

            return executarProc("EXCLUI_FIN_ATVENCTOPARCELA", hs);
        }
    }
    #endregion
}
