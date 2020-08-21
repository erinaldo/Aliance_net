using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CamadaDados.Fiscal
{
    public class TList_CondicaoFiscalImposto : List<TRegistro_CondicaoFiscalImposto>, IComparer<TRegistro_CondicaoFiscalImposto>
    {
        #region IComparer<TRegistro_CondicaoFiscalImposto> Members
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

        public TList_CondicaoFiscalImposto()
        { }

        public TList_CondicaoFiscalImposto(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CondicaoFiscalImposto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CondicaoFiscalImposto x, TRegistro_CondicaoFiscalImposto y)
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
    
    public class TRegistro_CondicaoFiscalImposto
    {
        private decimal? cd_imposto;
        public decimal? Cd_imposto 
        {
            get { return cd_imposto; }
            set 
            { 
                cd_imposto = value;
                cd_impostostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string cd_impostostring;
        public string Cd_impostostring
        {
            get { return cd_impostostring; }
            set 
            { 
                cd_impostostring = value;
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
        public decimal id_condicao { get; set; }
        public string cd_condfiscal_clifor { get; set; }
        public string cd_condfiscal_produto { get; set; }
        public decimal? cd_movimentacao { get; set; }
        private string tp_faturamento;
        public string Tp_faturamento 
        {
            get { return tp_faturamento; }
            set
            {
                tp_faturamento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_faturamento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_faturamento = "SAIDA";
            }
        }
        private string tipo_faturamento;
        public string Tipo_faturamento
        {
            get { return tipo_faturamento; }
            set
            {
                tipo_faturamento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_faturamento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_faturamento = "S";
            }
        }
        private string tp_pessoa;
        public string Tp_pessoa 
        {
            get { return tp_pessoa; }
            set
            {
                tp_pessoa = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_pessoa = "FISICA";
                else if (value.Trim().ToUpper().Equals("J"))
                    tipo_pessoa = "JURIDICA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_pessoa = "ESTRANGEIRO";
            }
        }
        private string tipo_pessoa;
        public string Tipo_pessoa
        {
            get { return tipo_pessoa; }
            set
            {
                tipo_pessoa = value;
                if (value.Trim().ToUpper().Equals("FISICA"))
                    tp_pessoa = "F";
                else if (value.Trim().ToUpper().Equals("JURIDICA"))
                    tp_pessoa = "J";
                else if (value.Trim().ToUpper().Equals("ESTRANGEIRO"))
                    tp_pessoa = "E";
            }
        }
        public string cd_empresa { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal pc_aliquota { get; set; }
        public decimal pc_retencao { get; set; }
        public decimal pc_basecalc { get; set; }
        public decimal vl_minimo { get; set; }
        private string st_imposto;
        public string St_imposto
        {
            get { return st_imposto; }
            set
            {
                st_imposto = value;
                if (value == "C")
                {
                    st_impostoBool = true;
                }
                else
                {
                    st_impostoBool = false;
                }
            }
        }
        private bool st_impostoBool;
        public bool St_impostoBool
        {
            get { return st_impostoBool; }
            set
            {
                st_impostoBool = value;
                if (value == true)
                {
                    st_imposto = "C";
                }
                else
                {
                    st_imposto = "U";
                }

            }
        }
        private string st_totalnota;
        public string St_totalnota 
        {
            get { return st_totalnota; }
            set
            {
                st_totalnota = value;
                if (value.Trim().ToUpper().Equals("S"))
                    status_totalnota = "SOMAR";
                else if (value.Trim().ToUpper().Equals("D"))
                    status_totalnota = "DIMINUIR";
                else
                    status_totalnota = "IGNORAR";
            }
        }
        private string status_totalnota;
        public string Status_totalnota
        {
            get { return status_totalnota; }
            set
            {
                status_totalnota = value;
                if (value.Trim().ToUpper().Equals("SOMAR"))
                    st_totalnota = "S";
                else if (value.Trim().ToUpper().Equals("DIMINUIR"))
                    st_totalnota = "D";
                else
                    st_totalnota = "I";
            }
        }
        public string st_calcularse { get; set; }
        public decimal vl_totfaturadobase { get; set; }
        public decimal vl_imposto_unit { get; set; }
        public string cd_unidade_ref { get; set; }
        public string Ds_unidade_ref
        { get; set; }
        public string Tp_imposto { get; set; }
        public string Cd_st { get; set; }
        public string Ds_situacao { get; set; }
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
        public bool St_pis
        { get; set; }
        public bool St_cofins
        { get; set; }
        public bool St_issqn
        { get; set; }
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
        public string Cd_municipiogeradoriss
        { get; set; }
        public string Ds_municipiogeradoriss
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
        public string Ds_basecredito
        { get; set; }
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
        public string Ds_tpcred
        { get; set; }
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
        public string Ds_tpcontribuicao
        { get; set; }
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
        public string Ds_detrecisenta
        { get; set; }
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
        public string Ds_receita
        { get; set; }
        
        public TRegistro_CondicaoFiscalImposto()
        {
            this.cd_imposto = null;
            this.cd_impostostring = string.Empty;
            this.Ds_imposto = string.Empty;
            this.id_condicao = decimal.Zero;
            this.cd_condfiscal_clifor = string.Empty;
            this.cd_condfiscal_produto = string.Empty;
            this.cd_movimentacao = decimal.Zero;
            this.tp_faturamento = string.Empty;
            this.tipo_faturamento = string.Empty;
            this.tp_pessoa = string.Empty;
            this.tipo_pessoa = string.Empty;
            this.cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.pc_aliquota = decimal.Zero;
            this.pc_retencao = decimal.Zero;
            this.pc_basecalc = decimal.Zero;
            this.vl_minimo = decimal.Zero;
            this.st_imposto = string.Empty;
            this.st_totalnota = "I";
            this.st_calcularse = "0";
            this.vl_totfaturadobase = decimal.Zero;
            this.vl_imposto_unit = decimal.Zero;
            this.cd_unidade_ref = string.Empty;
            this.Ds_unidade_ref = string.Empty;
            this.st_gerarcredito = 1;
            this.st_gerarcreditobool = false;
            this.Cd_st = string.Empty;
            this.Ds_situacao = string.Empty;
            this.St_pis = false;
            this.St_cofins = false;
            this.St_issqn = false;
            this.Tp_tributiss = string.Empty;
            this.Tp_naturezaoperacaoiss = string.Empty;
            this.Cd_municipiogeradoriss = string.Empty;
            this.Ds_municipiogeradoriss = string.Empty;
            this.id_basecredito = null;
            this.id_basecreditostr = string.Empty;
            this.Ds_basecredito = string.Empty;
            this.id_tpcred = null;
            this.id_tpcredstr = string.Empty;
            this.Ds_tpcred = string.Empty;
            this.id_tpcontribuicao = null;
            this.id_tpcontribuicaostr = string.Empty;
            this.Ds_tpcontribuicao = string.Empty;
            this.id_detrecisenta = null;
            this.id_detrecisentastr = string.Empty;
            this.Ds_detrecisenta = string.Empty;
            this.id_receita = null;
            this.id_receitastr = string.Empty;
            this.Ds_receita = string.Empty;
        }
    }

    public class TCD_CondicaoFiscalImposto : TDataQuery
    {
        public TCD_CondicaoFiscalImposto()
        { }

        public TCD_CondicaoFiscalImposto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Imposto, b.DS_Imposto, a.ID_Condicao, a.CD_Empresa, c.NM_Empresa, ");
                sql.AppendLine("a.CD_CondFiscal_Produto, d.DS_CondFiscal_Produto, a.CD_CondFiscal_Clifor, e.DS_CondFiscal, ");
                sql.AppendLine("a.CD_Movimentacao, f.DS_Movimentacao, a.id_basecredito, m.ds_basecredito, ");
                sql.AppendLine("a.TP_Faturamento, a.TP_Pessoa, a.PC_Aliquota, a.PC_BaseCalc, a.Vl_Minimo, a.ST_Imposto, ");
                sql.AppendLine("a.ST_TotalNota, a.ST_CalcularSe, a.PC_Retencao, a.st_gerarcredito, a.tp_tributiss, ");
                sql.AppendLine("a.Vl_TotFaturadoBase, a.Vl_Imposto_Unit, a.CD_Unidade_Ref, i.DS_Unidade as DS_Unidade_Ref, ");
                sql.AppendLine("a.Tp_Imposto, k.DS_Situacao, a.cd_st, b.st_pis, b.st_cofins, b.st_issqn, ");
                sql.AppendLine("a.cd_municipiogeradoriss, l.ds_cidade as ds_municipiogeradoriss, a.tp_naturezaoperacaoiss, ");
                sql.AppendLine("a.id_tpcred, n.ds_tpcred, a.id_tpcontribuicao, o.ds_tpcontribuicao, ");
                sql.AppendLine("a.id_detrecisenta, p.ds_detrecisenta, a.id_receita, q.ds_receita ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_Imposto b ");
            sql.AppendLine("inner join TB_FIS_CondicaoFiscal_Imposto a ");
            sql.AppendLine("On a.CD_Imposto = b.CD_Imposto ");
            sql.AppendLine("left outer join TB_DIV_Empresa c ");
            sql.AppendLine("On c.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIS_CondFiscal_Produto d ");
            sql.AppendLine("On d.CD_CondFiscal_Produto = a.CD_CondFiscal_Produto  ");
            sql.AppendLine("left outer join TB_FIS_CondFiscal_Clifor e ");
            sql.AppendLine("On e.CD_CondFiscal_Clifor = a.CD_CondFiscal_Clifor ");
            sql.AppendLine("left outer join TB_FIS_Movimentacao f ");
            sql.AppendLine("On f.CD_Movimentacao = a.CD_Movimentacao ");
            sql.AppendLine("left outer join TB_EST_Unidade i ");
            sql.AppendLine("On i.CD_Unidade = a.CD_Unidade_Ref ");
            sql.AppendLine("left outer join TB_Fis_TipoImposto_X_SitTrib j ");
            sql.AppendLine("on j.Tp_Imposto = a.tp_imposto ");
            sql.AppendLine("and j.cd_st = a.cd_st");
            sql.AppendLine("and j.cd_imposto = a.cd_imposto ");
            sql.AppendLine("left outer join TB_FIS_SitTribut k ");
            sql.AppendLine("on k.cd_st = a.cd_st ");
            sql.AppendLine("and k.cd_imposto = a.cd_imposto ");
            sql.AppendLine("left outer join TB_FIN_Cidade l ");
            sql.AppendLine("on a.cd_municipiogeradoriss = l.cd_cidade ");
            sql.AppendLine("left outer join TB_FIS_TpBaseCalcCredito m ");
            sql.AppendLine("on a.id_basecredito = m.id_basecredito ");
            sql.AppendLine("left outer join TB_FIS_TpCreditoPisCofins n ");
            sql.AppendLine("on a.id_tpcred = n.id_tpcred ");
            sql.AppendLine("left outer join TB_FIS_TpContribuicaoPisCofins o ");
            sql.AppendLine("on a.id_tpcontribuicao = o.id_tpcontribuicao ");
            sql.AppendLine("left outer join TB_FIS_DetRecIsentaPisCofins p ");
            sql.AppendLine("on a.id_detrecisenta = p.id_detrecisenta ");
            sql.AppendLine("and a.cd_imposto = p.cd_imposto ");
            sql.AppendLine("and a.cd_st = p.cd_st ");
            sql.AppendLine("left outer join TB_FIS_ReceitaPisCofins q ");
            sql.AppendLine("on a.id_receita = q.id_receita ");
            sql.AppendLine("and a.cd_imposto = q.cd_imposto ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_CondicaoFiscalImposto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CondicaoFiscalImposto lista = new TList_CondicaoFiscalImposto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CondicaoFiscalImposto reg = new TRegistro_CondicaoFiscalImposto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_IMPOSTO"))))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_IMPOSTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_pis")))
                        reg.St_pis = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_pis"))).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cofins")))
                        reg.St_cofins = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_cofins"))).Equals(0);
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ISSQN")))
                        reg.St_issqn = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_issqn"))).Equals(0);
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_CONDICAO"))))
                        reg.id_condicao = reader.GetDecimal(reader.GetOrdinal("ID_CONDICAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CONDFISCAL_CLIFOR"))))
                        reg.cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CONDFISCAL_CLIFOR"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CONDFISCAL_PRODUTO"))))
                        reg.cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CONDFISCAL_PRODUTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MOVIMENTACAO"))))
                        reg.cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_FATURAMENTO"))))
                        reg.Tp_faturamento = reader.GetString(reader.GetOrdinal("TP_FATURAMENTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_PESSOA"))))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_PESSOA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA"))))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("CD_EMPRESA")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTA"))))
                        reg.pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_RETENCAO"))))
                        reg.pc_retencao = reader.GetDecimal(reader.GetOrdinal("PC_RETENCAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_BASECALC"))))
                        reg.pc_basecalc = reader.GetDecimal(reader.GetOrdinal("PC_BASECALC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_MINIMO"))))
                        reg.vl_minimo = reader.GetDecimal(reader.GetOrdinal("VL_MINIMO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_IMPOSTO"))))
                        reg.St_imposto = reader.GetString(reader.GetOrdinal("ST_IMPOSTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_TOTALNOTA"))))
                        reg.St_totalnota = reader.GetString(reader.GetOrdinal("ST_TOTALNOTA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_CALCULARSE"))))
                        reg.st_calcularse = reader.GetString(reader.GetOrdinal("ST_CALCULARSE"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_TOTFATURADOBASE"))))
                        reg.vl_totfaturadobase = reader.GetDecimal(reader.GetOrdinal("VL_TOTFATURADOBASE"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_IMPOSTO_UNIT"))))
                        reg.vl_imposto_unit = reader.GetDecimal(reader.GetOrdinal("VL_IMPOSTO_UNIT"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_UNIDADE_REF"))))
                        reg.cd_unidade_ref = reader.GetString(reader.GetOrdinal("CD_UNIDADE_REF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade_Ref")))
                        reg.Ds_unidade_ref = reader.GetString(reader.GetOrdinal("DS_Unidade_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ST")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("CD_ST"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Situacao")))
                        reg.Ds_situacao = reader.GetString(reader.GetOrdinal("DS_Situacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Imposto")))
                        reg.Tp_imposto = reader.GetString(reader.GetOrdinal("Tp_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarCredito")))
                        reg.St_gerarcredito = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ST_GerarCredito")));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_TributISS")))
                        reg.Tp_tributiss = reader.GetString(reader.GetOrdinal("TP_TributISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_MunicipioGeradorISS")))
                        reg.Cd_municipiogeradoriss = reader.GetString(reader.GetOrdinal("CD_MunicipioGeradorISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MunicipioGeradorISS")))
                        reg.Ds_municipiogeradoriss = reader.GetString(reader.GetOrdinal("DS_MunicipioGeradorISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_NaturezaOperacaoISS")))
                        reg.Tp_naturezaoperacaoiss = reader.GetString(reader.GetOrdinal("TP_NaturezaOperacaoISS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_basecredito")))
                        reg.Id_basecredito = reader.GetDecimal(reader.GetOrdinal("id_basecredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_basecredito")))
                        reg.Ds_basecredito = reader.GetString(reader.GetOrdinal("ds_basecredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcred")))
                        reg.Id_tpcred = reader.GetDecimal(reader.GetOrdinal("id_tpcred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpcred")))
                        reg.Ds_tpcred = reader.GetString(reader.GetOrdinal("ds_tpcred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpcontribuicao")))
                        reg.Id_tpcontribuicao = reader.GetDecimal(reader.GetOrdinal("id_tpcontribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpcontribuicao")))
                        reg.Ds_tpcontribuicao = reader.GetString(reader.GetOrdinal("ds_tpcontribuicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_detrecisenta")))
                        reg.Id_detrecisenta = reader.GetDecimal(reader.GetOrdinal("id_detrecisenta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_detrecisenta")))
                        reg.Ds_detrecisenta = reader.GetString(reader.GetOrdinal("ds_detrecisenta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("id_receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_receita")))
                        reg.Ds_receita = reader.GetString(reader.GetOrdinal("ds_receita"));
                    
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

        public string Gravar(TRegistro_CondicaoFiscalImposto val)
        {
            Hashtable hs = new Hashtable(28);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_ID_CONDICAO", val.id_condicao);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.cd_condfiscal_clifor);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.cd_condfiscal_produto);
            hs.Add("@P_CD_MOVIMENTACAO", val.cd_movimentacao);
            hs.Add("@P_TP_FATURAMENTO", val.Tp_faturamento);
            hs.Add("@P_TP_PESSOA", val.Tp_pessoa);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_PC_ALIQUOTA", val.pc_aliquota);
            hs.Add("@P_PC_RETENCAO", val.pc_retencao);
            hs.Add("@P_PC_BASECALC", val.pc_basecalc);
            hs.Add("@P_VL_MINIMO", val.vl_minimo);
            hs.Add("@P_ST_IMPOSTO", val.St_imposto);
            hs.Add("@P_ST_TOTALNOTA", val.St_totalnota);
            hs.Add("@P_ST_CALCULARSE", val.st_calcularse);
            hs.Add("@P_VL_TOTFATURADOBASE", val.vl_totfaturadobase);
            hs.Add("@P_VL_IMPOSTO_UNIT", val.vl_imposto_unit);
            hs.Add("@P_CD_UNIDADE_REF", val.cd_unidade_ref);
            hs.Add("@P_CD_ST", val.Cd_st);
            hs.Add("@P_TP_IMPOSTO", val.Tp_imposto);
            hs.Add("@P_ST_GERARCREDITO", val.St_gerarcredito);
            hs.Add("@P_TP_TRIBUTISS", val.Tp_tributiss);
            hs.Add("@P_CD_MUNICIPIOGERADORISS", val.Cd_municipiogeradoriss);
            hs.Add("@P_TP_NATUREZAOPERACAOISS", val.Tp_naturezaoperacaoiss);
            hs.Add("@P_ID_BASECREDITO", val.Id_basecredito);
            hs.Add("@P_ID_TPCRED", val.Id_tpcred);
            hs.Add("@P_ID_TPCONTRIBUICAO", val.Id_tpcontribuicao);
            hs.Add("@P_ID_DETRECISENTA", val.Id_detrecisenta);
            hs.Add("@P_ID_RECEITA", val.Id_receita);

            return executarProc("IA_FIS_CONDICAOFISCAL_IMPOSTO", hs);
        }

        public string Excluir(TRegistro_CondicaoFiscalImposto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_ID_CONDICAO", val.id_condicao);
            return executarProc("EXCLUI_FIS_CONDICAOFISCAL_IMPOSTO", hs);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
    }
}
