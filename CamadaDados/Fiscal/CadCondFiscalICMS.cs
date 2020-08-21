using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Fiscal
{
    public class TList_CadCondFiscalICMS : List<TRegistro_CadCondFiscalICMS>, IComparer<TRegistro_CadCondFiscalICMS>
    {
        #region IComparer<TRegistro_CadCondFiscalICMS> Members
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

        public TList_CadCondFiscalICMS()
        { }

        public TList_CadCondFiscalICMS(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCondFiscalICMS value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCondFiscalICMS x, TRegistro_CadCondFiscalICMS y)
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
    
    public class TRegistro_CadCondFiscalICMS
    {
        public decimal? Id_condfiscal_icms
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Tp_regimetributario
        { get; set; }
        public string Cd_uforig
        { get; set; }
        public string Ds_uforig
        { get; set; }
        public string Sg_uforig
        { get; set; }
        public string Cd_ufdest
        { get; set; }
        public string Ds_ufdest
        { get; set; }
        public string Sg_ufdest
        { get; set; }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Ds_condfiscal_clifor
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Ds_condfiscal_produto
        { get; set; }
        public string Ds_situacao
        { get; set; }
        public string Cd_st
        { get; set; }
        public bool St_substtrib
        { get; set; }
        public bool St_simplesnacional
        { get; set; }
        public string Tp_situacao
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
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
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
        public string Cd_observacaofiscal
        { get; set; }
        public string Ds_observacaofiscal
        { get; set; }
        public string Cd_cfop { get; set; } = string.Empty;
        public string Ds_cfop { get; set; } = string.Empty;
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
        public decimal Pc_aliquota_icms
        { get; set; }
        public decimal Pc_aliquota_icmsDest
        { get; set; }
        public decimal Pc_aliquota_icms_substtrib
        { get; set; }
        public decimal Pc_reducaobasecalc
        { get; set; }
        public decimal Pc_reducaobasecalc_substtrib
        { get; set; }
        public decimal Pc_reducaoaliquota
        { get; set; }
        public decimal Pc_iva_st
        { get; set; }
        public decimal Vl_mva
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
        private string st_somaricmsbase;
        public string St_somaricmsbase
        {
            get { return st_somaricmsbase; }
            set
            {
                st_somaricmsbase = value;
                st_somaricmsbasebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_somaricmsbasebool;
        public bool St_somaricmsbasebool
        {
            get { return st_somaricmsbasebool; }
            set
            {
                st_somaricmsbasebool = value;
                St_somaricmsbase = value ? "S" : "N";
            }
        }
        public decimal PC_FCP { get; set; } = decimal.Zero;
        public decimal PC_FCPST { get; set; } = decimal.Zero;
        public decimal Vl_pauta { get; set; } = decimal.Zero;
        public decimal PC_AliqOpDIFAL { get; set; } = decimal.Zero;
        public bool St_somarIPIBaseICMS { get; set; } = false;
        public bool St_somarIPIBaseST { get; set; } = false;

        public TRegistro_CadCondFiscalICMS()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Tp_regimetributario = string.Empty;
            Cd_condfiscal_clifor = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            cd_imposto = null;
            cd_impostostr = string.Empty;
            cd_movimentacao = null;
            cd_movimentacaostr = string.Empty;
            Cd_observacaofiscal = string.Empty;
            Cd_ufdest = string.Empty;
            Ds_ufdest = string.Empty;
            Sg_ufdest = string.Empty;
            Cd_uforig = string.Empty;
            Ds_uforig = string.Empty;
            Sg_uforig = string.Empty;
            Ds_condfiscal_clifor = string.Empty;
            Ds_condfiscal_produto = string.Empty;
            Ds_imposto = string.Empty;
            Ds_movimentacao = string.Empty;
            Ds_observacaofiscal = string.Empty;
            Id_condfiscal_icms = null;
            Ds_situacao = string.Empty;
            Cd_st = string.Empty;
            St_substtrib = false;
            St_simplesnacional = false;
            Tp_situacao = string.Empty;
            Pc_aliquota_icms = decimal.Zero;
            Pc_aliquota_icmsDest = decimal.Zero;
            Pc_aliquota_icms_substtrib = decimal.Zero;
            Pc_reducaoaliquota = decimal.Zero;
            Pc_reducaobasecalc = decimal.Zero;
            Pc_reducaobasecalc_substtrib = decimal.Zero;
            Pc_iva_st = decimal.Zero;
            Vl_mva = decimal.Zero;
            tipo_movimento = string.Empty;
            tp_movimento = string.Empty;
            st_gerarcredito = 1;
            st_gerarcreditobool = false;
            Tp_modbasecalc = string.Empty;
            Tp_modbasecalcST = string.Empty;
            st_somaricmsbase = "N";
            st_somaricmsbasebool = false;
        }
    }

    public class TCD_CadCondFiscalICMS : TDataQuery
    {
        public TCD_CadCondFiscalICMS()
        { }

        public TCD_CadCondFiscalICMS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_CondFiscal_ICMS, a.CD_UFOrig, a.CD_UFDest, ");
                sql.AppendLine("origem.ds_uf as ds_uforig, origem.uf as sg_uforig, a.Vl_Pauta, ");
                sql.AppendLine("destino.ds_uf as ds_ufdest, destino.uf as sg_ufdest, a.ST_SomarIPIBaseST, ");
                sql.AppendLine("a.Cd_CondFiscal_Clifor, b.DS_CondFiscal, a.CD_ST, st.DS_Situacao, a.pc_fcp, a.pc_fcpst, ");
                sql.AppendLine("a.CD_CondFiscal_Produto, c.DS_CondFiscal_Produto, st.ST_SubstTrib, st.st_simplesnacional, ");
                sql.AppendLine("a.CD_Imposto, d.DS_Imposto, a.tp_modbasecalc, a.tp_modbasecalcST, a.ST_SomarIPIBaseICMS, ");
                sql.AppendLine("a.CD_Movimentacao, e.DS_Movimentacao, a.CD_ObservacaoFiscal, a.st_somaricmsbase, ");
                sql.AppendLine("g.DS_ObservacaoFiscal, a.TP_Movimento, a.PC_Aliquota_ICMS, a.PC_AliquotaICMSDest, ");
                sql.AppendLine("a.PC_Aliquota_ICMS_SubstTrib, a.PC_ReducaoBaseCalc, a.st_gerarcredito, ");
                sql.AppendLine("a.PC_reducaoBaseCalc_SubstTrib, a.PC_ReducaoAliquota, st.tp_situacao, a.cd_cfop, h.ds_cfop, ");
                sql.AppendLine("a.cd_empresa, emp.nm_empresa, emp.tp_regimetributario, a.pc_iva_st, a.vl_mva, a.Pc_AliqOpDIFAL "); 
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIS_CondicaoFiscal_ICMS a ");
            sql.AppendLine("inner join TB_FIS_CondFiscal_Clifor b ");
            sql.AppendLine("on a.Cd_CondFiscal_Clifor = b.Cd_CondFiscal_Clifor ");
            sql.AppendLine("inner join TB_FIS_Imposto d ");
            sql.AppendLine("on a.CD_Imposto = d.CD_Imposto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao e ");
            sql.AppendLine("on a.CD_Movimentacao = e.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_SitTribut st ");
            sql.AppendLine("on a.CD_ST = st.CD_ST ");
            sql.AppendLine("and a.cd_imposto = st.cd_imposto ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join tb_fin_uf origem ");
            sql.AppendLine("on a.CD_UFOrig = origem.cd_uf ");
            sql.AppendLine("inner join tb_fin_uf destino ");
            sql.AppendLine("on a.CD_UFDest = destino.cd_uf ");
            sql.AppendLine("left outer join TB_FIS_CondFiscal_Produto c ");
            sql.AppendLine("on a.CD_CondFiscal_Produto = c.CD_CondFiscal_Produto ");
            sql.AppendLine("left outer join TB_FIS_ObservacaoFiscal g ");
            sql.AppendLine("on a.CD_ObservacaoFiscal = g.CD_ObservacaoFiscal ");
            sql.AppendLine("left outer join TB_FIS_CFOP h ");
            sql.AppendLine("on a.cd_cfop = h.cd_cfop ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_CadCondFiscalICMS Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadCondFiscalICMS lista = new TList_CadCondFiscalICMS();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCondFiscalICMS reg = new TRegistro_CadCondFiscalICMS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CondFiscal_ICMS")))
                        reg.Id_condfiscal_icms = reader.GetDecimal(reader.GetOrdinal("ID_CondFiscal_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_regimetributario")))
                        reg.Tp_regimetributario = reader.GetString(reader.GetOrdinal("tp_regimetributario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFOrig")))
                        reg.Cd_uforig = reader.GetString(reader.GetOrdinal("CD_UFOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UFOrig")))
                        reg.Ds_uforig = reader.GetString(reader.GetOrdinal("DS_UFOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_UFOrig")))
                        reg.Sg_uforig = reader.GetString(reader.GetOrdinal("SG_UFOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFDest")))
                        reg.Cd_ufdest = reader.GetString(reader.GetOrdinal("CD_UFDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UFDest")))
                        reg.Ds_ufdest = reader.GetString(reader.GetOrdinal("DS_UFDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_UFDest")))
                        reg.Sg_ufdest = reader.GetString(reader.GetOrdinal("SG_UFDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CondFiscal_Clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("Cd_CondFiscal_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal")))
                        reg.Ds_condfiscal_clifor = reader.GetString(reader.GetOrdinal("DS_CondFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("DS_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("CD_ST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_substtrib")))
                        reg.St_substtrib = reader.GetString(reader.GetOrdinal("st_substtrib")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("st_simplesnacional")))
                        reg.St_simplesnacional = reader.GetString(reader.GetOrdinal("st_simplesnacional")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal_Produto")))
                        reg.Ds_condfiscal_produto = reader.GetString(reader.GetOrdinal("DS_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ObservacaoFiscal")))
                        reg.Cd_observacaofiscal = reader.GetString(reader.GetOrdinal("CD_ObservacaoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ObservacaoFiscal")))
                        reg.Ds_observacaofiscal = reader.GetString(reader.GetOrdinal("DS_ObservacaoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfop")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("ds_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota_ICMS")))
                        reg.Pc_aliquota_icms = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_AliquotaICMSDest")))
                        reg.Pc_aliquota_icmsDest = reader.GetDecimal(reader.GetOrdinal("PC_AliquotaICMSDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota_ICMS_SubstTrib")))
                        reg.Pc_aliquota_icms_substtrib = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota_ICMS_SubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoBaseCalc")))
                        reg.Pc_reducaobasecalc = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_reducaoBaseCalc_SubstTrib")))
                        reg.Pc_reducaobasecalc_substtrib = reader.GetDecimal(reader.GetOrdinal("PC_reducaoBaseCalc_SubstTrib"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoAliquota")))
                        reg.Pc_reducaoaliquota = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoAliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarCredito")))
                        reg.St_gerarcredito = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_GerarCredito")));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Situacao")))
                        reg.Tp_situacao = reader.GetString(reader.GetOrdinal("TP_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalc")))
                        reg.Tp_modbasecalc = reader.GetString(reader.GetOrdinal("TP_ModBaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ModBaseCalcST")))
                        reg.Tp_modbasecalcST = reader.GetString(reader.GetOrdinal("TP_ModBaseCalcST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_iva_st")))
                        reg.Pc_iva_st = reader.GetDecimal(reader.GetOrdinal("pc_iva_st"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_mva")))
                        reg.Vl_mva = reader.GetDecimal(reader.GetOrdinal("vl_mva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_somaricmsbase")))
                        reg.St_somaricmsbase = reader.GetString(reader.GetOrdinal("st_somaricmsbase"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_fcp")))
                        reg.PC_FCP = reader.GetDecimal(reader.GetOrdinal("pc_fcp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_fcpst")))
                        reg.PC_FCPST = reader.GetDecimal(reader.GetOrdinal("pc_fcpst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Pauta")))
                        reg.Vl_pauta = reader.GetDecimal(reader.GetOrdinal("Vl_Pauta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SomarIPIBaseICMS")))
                        reg.St_somarIPIBaseICMS = reader.GetBoolean(reader.GetOrdinal("ST_SomarIPIBaseICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_SomarIPIBaseST")))
                        reg.St_somarIPIBaseST = reader.GetBoolean(reader.GetOrdinal("ST_SomarIPIBaseST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_AliqOpDIFAL")))
                        reg.PC_AliqOpDIFAL = reader.GetDecimal(reader.GetOrdinal("Pc_AliqOpDIFAL"));

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

        public string Gravar(TRegistro_CadCondFiscalICMS val)
        {
            Hashtable hs = new Hashtable(30);
            hs.Add("@P_ID_CONDFISCAL_ICMS", val.Id_condfiscal_icms);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_UFORIG", val.Cd_uforig);
            hs.Add("@P_CD_UFDEST", val.Cd_ufdest);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.Cd_condfiscal_clifor);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.Cd_condfiscal_produto);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_CFOP", val.Cd_cfop);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_OBSERVACAOFISCAL", val.Cd_observacaofiscal);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_PC_ALIQUOTA_ICMS", val.Pc_aliquota_icms);
            hs.Add("@P_PC_ALIQUOTAICMSDEST", val.Pc_aliquota_icmsDest);
            hs.Add("@P_PC_ALIQUOTA_ICMS_SUBSTTRIB", val.Pc_aliquota_icms_substtrib);
            hs.Add("@P_PC_REDUCAOBASECALC", val.Pc_reducaobasecalc);
            hs.Add("@P_PC_REDUCAOBASECALC_SUBSTTRIB", val.Pc_reducaobasecalc_substtrib);
            hs.Add("@P_PC_REDUCAOALIQUOTA", val.Pc_reducaoaliquota);
            hs.Add("@P_ST_GERARCREDITO", val.St_gerarcredito);
            hs.Add("@P_TP_MODBASECALC", val.Tp_modbasecalc);
            hs.Add("@P_TP_MODBASECALCST", val.Tp_modbasecalcST);
            hs.Add("@P_PC_IVA_ST", val.Pc_iva_st);
            hs.Add("@P_VL_MVA", val.Vl_mva);
            hs.Add("@P_ST_SOMARICMSBASE", val.St_somaricmsbase);
            hs.Add("@P_PC_FCP", val.PC_FCP);
            hs.Add("@P_PC_FCPST", val.PC_FCPST);
            hs.Add("@P_VL_PAUTA", val.Vl_pauta);
            hs.Add("@P_ST_SOMARIPIBASEICMS", val.St_somarIPIBaseICMS);
            hs.Add("@P_ST_SOMARIPIBASEST", val.St_somarIPIBaseST);
            hs.Add("@P_PC_ALIQOPDIFAL", val.PC_AliqOpDIFAL);

            return executarProc("IA_FIS_CONDICAOFISCAL_ICMS", hs);
        }

        public string Excluir(TRegistro_CadCondFiscalICMS val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONDFISCAL_ICMS", val.Id_condfiscal_icms);

            return executarProc("EXCLUI_FIS_CONDICAOFISCAL_ICMS", hs);
        }
    }
}
