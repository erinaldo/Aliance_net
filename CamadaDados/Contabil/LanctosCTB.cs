using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;

namespace CamadaDados.Contabil
{
    public class TRegistro_BalancoSintetico
    {
        private decimal? cd_contaCTB;
        public decimal? Cd_contaCTB
        {
            get { return cd_contaCTB; }
            set
            {
                cd_contaCTB = value;
                cd_contaCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contaCTBstr;
        public string Cd_contaCTBstr
        {
            get { return cd_contaCTBstr; }
            set
            {
                cd_contaCTBstr = value;
                try
                {
                    cd_contaCTB = decimal.Parse(value);
                }
                catch { cd_contaCTB = null; }
            }
        }
        public string Ds_contactb
        { get; set; }
        public string Classificacao
        { get; set; }
        public string Tp_conta
        { get; set; }
        public string Natureza
        { get; set; }
        public DateTime? Dt_altconta
        { get; set; }
        public string Tp_contasped
        { get; set; }
        public decimal Nivelconta
        { get; set; }
        public decimal? Cd_contaCTBPai
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public decimal Vl_saldoant
        { get; set; }
        public decimal Vl_debito
        { get; set; }
        public decimal Vl_credito
        { get; set; }
        public decimal Vl_atual
        { get; set; }

        public TRegistro_BalancoSintetico()
        {
            cd_contaCTB = null;
            cd_contaCTBstr = string.Empty;
            Ds_contactb = string.Empty;
            Classificacao = string.Empty;
            Tp_conta = string.Empty;
            Natureza = string.Empty;
            Dt_altconta = null;
            Tp_contasped = string.Empty;
            Nivelconta = decimal.Zero;
            Cd_contaCTBPai = null;
            Cd_referencia = string.Empty;
            Vl_saldoant = decimal.Zero;
            Vl_debito = decimal.Zero;
            Vl_credito = decimal.Zero;
            Vl_atual = decimal.Zero;
        }
    }

    public class TRegistro_RazaoContabil
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cnpj
        { get; set; }
        private decimal? cd_contaCTB;
        public decimal? Cd_contaCTB
        {
            get { return cd_contaCTB; }
            set
            {
                cd_contaCTB = value;
                cd_contaCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contaCTBstr;
        public string Cd_contaCTBstr
        {
            get { return cd_contaCTBstr; }
            set
            {
                cd_contaCTBstr = value;
                try
                {
                    cd_contaCTB = decimal.Parse(value);
                }
                catch { cd_contaCTB = null; }
            }
        }
        public string Ds_contactb
        { get; set; }
        public string Cd_classificacao
        { get; set; }
        public string Natureza
        { get; set; }
        private decimal? id_lotectb;
        public decimal? Id_lotectb
        {
            get { return id_lotectb; }
            set
            {
                id_lotectb = value;
                id_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotectbstr;
        public string Id_lotectbstr
        {
            get { return id_lotectbstr; }
            set
            {
                id_lotectbstr = value;
                try
                {
                    id_lotectb = decimal.Parse(value);
                }
                catch { id_lotectb = null; }
            }
        }
        public string Nr_docto
        { get; set; }
        public string Tp_integracao
        { get; set; }
        public string Tipo_integracao
        {
            get
            {
                if (Tp_integracao.Trim().ToUpper().Equals("FA"))
                    return "FATURAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("IF"))
                    return "IMPOSTO FATURAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("FI"))
                    return "FINANCEIRO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CC"))
                    return "CHEQUE COMPENSADO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CX"))
                    return "CAIXA";
                else if (Tp_integracao.Trim().ToUpper().Equals("PE"))
                    return "PROVISÃO ESTOQUE";
                else if (Tp_integracao.Trim().ToUpper().Equals("PA"))
                    return "PATRIMONIO";
                else if (Tp_integracao.Trim().ToUpper().Equals("AV"))
                    return "AVULSO";
                else if (Tp_integracao.Trim().ToUpper().Equals("FE"))
                    return "FECHAMENTO CONTABIL";
                else if (Tp_integracao.Trim().ToUpper().Equals("IS"))
                    return "IMPLANTAÇÃO SALDO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CF"))
                    return "COMPLEMENTO FIXAR";
                else if (Tp_integracao.Trim().ToUpper().Equals("ZR"))
                    return "ZERAMENTO";
                else return string.Empty;
            }
        }
        public string Ds_comp_historico
        { get; set; }
        private DateTime? data;
        public DateTime? Data
        {
            get { return data; }
            set
            {
                data = value;
                datastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string datastr;
        public string Datastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(datastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                datastr = value;
                try
                {
                    data = DateTime.Parse(value);
                }
                catch { data = null; }
            }
        }
        private decimal? cd_contaCTB_CtPartida;
        public decimal? Cd_contaCTB_CtPartida
        {
            get { return cd_contaCTB_CtPartida; }
            set
            {
                cd_contaCTB_CtPartida = value;
                cd_contaCTB_CtPartidastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contaCTB_CtPartidastr;
        public string Cd_contaCTB_CtPartidastr
        {
            get { return cd_contaCTB_CtPartidastr; }
            set
            {
                cd_contaCTB_CtPartidastr = value;
                try
                {
                    cd_contaCTB_CtPartida = decimal.Parse(value);
                }
                catch { cd_contaCTB_CtPartida = null; }
            }
        }
        public string Ds_contaCTB_CtPartida
        { get; set; }
        public decimal Vl_saldoant
        { get; set; }
        public decimal Vl_debito
        { get; set; }
        public decimal Vl_credito
        { get; set; }

        public TRegistro_RazaoContabil()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cnpj = string.Empty;
            cd_contaCTB = null;
            cd_contaCTBstr = string.Empty;
            Ds_contactb = string.Empty;
            Cd_classificacao = string.Empty;
            Natureza = string.Empty;
            id_lotectb = null;
            id_lotectbstr = string.Empty;
            Nr_docto = string.Empty;
            Tp_integracao = string.Empty;
            Ds_comp_historico = string.Empty;
            data = null;
            datastr = string.Empty;
            cd_contaCTB_CtPartida = null;
            cd_contaCTB_CtPartidastr = string.Empty;
            Ds_contaCTB_CtPartida = string.Empty;
            Vl_saldoant = decimal.Zero;
            Vl_debito = decimal.Zero;
            Vl_credito = decimal.Zero;
        }
    }

    public class TRegistro_DiarioContabil
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Nr_cgc
        { get; set; }
        public DateTime? Data
        { get; set; }
        public string Cd_classificacao
        { get; set; }
        public string Ds_contactb
        { get; set; }
        public string Ds_complhistorico
        { get; set; }
        public string D_C
        { get; set; }
        public decimal Valor
        { get; set; }
        public decimal? Id_lotectb
        { get; set; }

        public TRegistro_DiarioContabil()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_cgc = string.Empty;
            Data = null;
            Cd_classificacao = string.Empty;
            Ds_contactb = string.Empty;
            Ds_complhistorico = string.Empty;
            D_C = string.Empty;
            Valor = decimal.Zero;
            Id_lotectb = null;
        }
    }

    public class TRegistro_DRE
    {
        public decimal? Id_param
        { get; set; }
        public string Ds_param
        {get;set;}
        public string Classificacao
        { get; set; }
        public decimal Nivel
        { get; set; }
        public string Tp_conta
        { get; set; }
        public string Operador
        { get; set; }
        public decimal? Cd_conta_ctb
        { get; set; }
        public string Ds_contactb
        { get; set; }
        public decimal Sd_ant
        {get;set;}
        public decimal Sd_atual
        {get;set;}
        public decimal Tot_ant
        { get; set; }
        public decimal Tot_atual
        { get; set; }

        public TRegistro_DRE()
        {
            Id_param = null;
            Ds_param = string.Empty;
            Classificacao = string.Empty;
            Nivel = decimal.Zero;
            Tp_conta = string.Empty;
            Operador = string.Empty;
            Cd_conta_ctb = null;
            Ds_contactb = string.Empty;
            Sd_ant = decimal.Zero;
            Sd_atual = decimal.Zero;
            Tot_ant = decimal.Zero;
            Tot_atual = decimal.Zero;
        }
    }

    public class TRegistro_LanctosCTB
    {
        public string Cd_empresa{get; set;}
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lanctoctb;
        public decimal? Nr_lanctoctb
            {
                get { return nr_lanctoctb; }
                set
                {
                    nr_lanctoctb = value;
                    nr_lanctoctbstr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
        private string nr_lanctoctbstr;
        public string Nr_lanctoctbstr
        {
            get { return nr_lanctoctbstr; }
            set
            {
                nr_lanctoctbstr = value;
                try
                {
                    nr_lanctoctb = Convert.ToDecimal(value);
                }
                catch
                { nr_lanctoctb = null; }
            }
        }
        private decimal? cd_conta_ctb;
        public decimal? Cd_conta_ctb 
        {
            get { return cd_conta_ctb; }
            set
            {
                cd_conta_ctb = value;
                cd_conta_ctbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_conta_ctbstr;
        public string Cd_conta_ctbstr
        {
            get { return cd_conta_ctbstr; }
            set
            {
                cd_conta_ctbstr = value;
                try
                {
                    cd_conta_ctb = Convert.ToDecimal(value);
                }
                catch
                { cd_conta_ctb = null; }
            }
        }
        private decimal? id_lotectb;
        public decimal? ID_LoteCTB
        {
            get { return id_lotectb; }
            set
            {
                id_lotectb = value;
                id_lotectbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotectbstr;
        public string Id_lotectbstr
        {
            get { return id_lotectbstr; }
            set
            {
                id_lotectbstr = value;
                try
                {
                    id_lotectb = Convert.ToDecimal(value);
                }
                catch
                { id_lotectb = null; }
            }
        }
        public string Nr_docto{ get;set;}
        public DateTime? Data
        { get;set; }
        private string d_c;
        public string D_c
        {
            get { return d_c; }
            set
            {
                d_c = value;
                if (value.Trim().ToUpper().Equals("D"))
                    debito_credito = "DEBITO";
                else if (value.Trim().ToUpper().Equals("C"))
                    debito_credito = "CREDITO";
            }
        }
        private string debito_credito;
        public string Debito_credito
        {
            get { return debito_credito; }
            set
            {
                debito_credito = value;
                if (value.Trim().ToUpper().Equals("DEBITO"))
                    d_c = "D";
                else if (value.Trim().ToUpper().Equals("CREDITO"))
                    d_c = "C";
            }
        }
        public decimal Valor { get; set;}
        public string Ds_compl_historico{get; set;}
        public string Ds_lote{get; set;}
        public string Ds_contactb{get;set;}
        public string Cd_classificacao
        { get; set; }
        public string Tp_integracao
        { get; set; }
        public string Tipo_integracao
        {
            get
            {
                if (Tp_integracao.Trim().ToUpper().Equals("FA"))
                    return "FATURAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("IF"))
                    return "IMPOSTO FATURAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("FI"))
                    return "FINANCEIRO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CC"))
                    return "CHEQUE COMPENSADO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CX"))
                    return "CAIXA";
                else if (Tp_integracao.Trim().ToUpper().Equals("PE"))
                    return "PROVISÃO ESTOQUE";
                else if (Tp_integracao.Trim().ToUpper().Equals("PA"))
                    return "PATRIMONIO";
                else if (Tp_integracao.Trim().ToUpper().Equals("AV"))
                    return "AVULSO";
                else if (Tp_integracao.Trim().ToUpper().Equals("FE"))
                    return "FECHAMENTO CONTABIL";
                else if (Tp_integracao.Trim().ToUpper().Equals("IS"))
                    return "IMPLANTAÇÃO SALDO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CM"))
                    return "CMV";
                else if (Tp_integracao.Trim().ToUpper().Equals("CF"))
                    return "COMPLEMENTO FIXAR";
                else if (Tp_integracao.Trim().ToUpper().Equals("AD"))
                    return "ADIANTAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("ZR"))
                    return "ZERAMENTO";
                else if (Tp_integracao.Trim().ToUpper().Equals("FC"))
                    return "FATURA CARTÃO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CE"))
                    return "CUPOM ELETRONICO";
                else if (Tp_integracao.Trim().ToUpper().Equals("CT"))
                    return "CONHECIMENTO FRETE";
                else return string.Empty;
            }
        }

        public TRegistro_LanctosCTB()
        {
            Cd_empresa = string.Empty;
            nr_lanctoctb = null;
            nr_lanctoctbstr = string.Empty;
            cd_conta_ctb = null;
            cd_conta_ctbstr = string.Empty;
            id_lotectb = null;
            id_lotectbstr = string.Empty;
            Nr_docto = string.Empty;
            Data = null;
            d_c = string.Empty;
            debito_credito = string.Empty;
            Valor = decimal.Zero;
            Ds_compl_historico = string.Empty;
            Ds_lote = string.Empty;
            Ds_contactb = string.Empty;
            Cd_classificacao = string.Empty;
            Tp_integracao = string.Empty;
        }
    }

    public class TList_LanContabil : List<TRegistro_LanctosCTB>, IComparer<TRegistro_LanctosCTB>
    {
        #region IComparer<TRegistro_LanctosCTB> Members
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

        public TList_LanContabil()
        { }

        public TList_LanContabil(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanctosCTB value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanctosCTB x, TRegistro_LanctosCTB y)
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

    public class TCD_LanctosCTB : TDataQuery
    {
        public TCD_LanctosCTB()
        { }

        public TCD_LanctosCTB(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop.Trim() + " a.cd_empresa, b.nm_empresa, "); 
                sql.AppendLine("a.nr_lanctoctb, a.cd_conta_ctb, c.ds_contactb, c.cd_classificacao, "); 
                sql.AppendLine("a.id_lotectb, a.nr_docto, a.data, a.d_c, a.valor, ");
                sql.AppendLine("a.ds_compl_historico, d.ds_lote, d.tp_integracao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ctb_lanctosCTB a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_ctb_planocontas c ");
            sql.AppendLine("on a.cd_conta_ctb = c.cd_conta_ctb ");
            sql.AppendLine("inner join tb_ctb_lotelan d ");
            sql.AppendLine("on a.id_lotectb = d.id_lotectb ");
            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine(" Group By " + vGroup);
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" ORDER By " + vOrder);

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", "", null), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros), vParametros);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty, null), null);
        }

        public TList_LanContabil Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            TList_LanContabil Lista = new TList_LanContabil();
            SqlDataReader reader = null;
            Boolean vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, vOrder, null));
                while (reader.Read())
                {
                    TRegistro_LanctosCTB reg = new TRegistro_LanctosCTB();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoCTB")))
                        reg.Nr_lanctoctb = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LoteCTB")))
                        reg.ID_LoteCTB = reader.GetDecimal(reader.GetOrdinal("Id_LoteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Data")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("D_C")))
                        reg.D_c = reader.GetString(reader.GetOrdinal("D_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Compl_Historico")))
                        reg.Ds_compl_historico = reader.GetString(reader.GetOrdinal("Ds_Compl_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Lote")))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTACTB")))
                        reg.Ds_contactb = reader.GetString(reader.GetOrdinal("DS_CONTACTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao")))
                        reg.Cd_classificacao = reader.GetString(reader.GetOrdinal("CD_Classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Integracao")))
                        reg.Tp_integracao = reader.GetString(reader.GetOrdinal("TP_Integracao"));

                    Lista.Add(reg);
                }
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();              
            }
        }

        public TList_LanContabil SelectImportDominio(string Cd_empresa,
                                                     DateTime Dt_ini,
                                                     DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_lotectb, a.Data, a.D_C, a.Valor, a.Cd_Conta_CTB, ");
            sql.AppendLine("Historico = isnull(case when b.tp_integracao = 'FA' then ");
            sql.AppendLine("					(select case when y.Tp_Movimento = 'P' then 'PAGAMENTO ' else 'RECEBIMENTO ' end + ");
            sql.AppendLine("							'NF ' + LTrim(RTrim(convert(varchar(15), y.Nr_NotaFiscal))) + ' ' + LTrim(RTrim(z.NM_Clifor)) ");
            sql.AppendLine("					from TB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("					inner join TB_FAT_NotaFiscal y ");
            sql.AppendLine("					on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("					and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal ");
            sql.AppendLine("					inner join TB_FIN_Clifor z ");
            sql.AppendLine("					on y.CD_Clifor = z.CD_Clifor ");
            sql.AppendLine("					where x.Id_LoteCTB_Fat = a.id_lotectb) ");
            sql.AppendLine("				 when b.Tp_Integracao = 'FI' then ");
            sql.AppendLine("					(select case when y.tp_mov = 'P' then 'PAGAMENTO ' else 'RECEBIMENTO ' end + ");
            sql.AppendLine("							'DUP ' + LTrim(RTrim(convert(varchar(10), x.nr_lancto))) + ' ' + LTrim(RTrim(z.NM_Clifor)) ");
            sql.AppendLine("					from TB_FIN_Duplicata x ");
            sql.AppendLine("					inner join TB_FIN_TPDuplicata y ");
            sql.AppendLine("					on x.TP_Duplicata = y.TP_Duplicata ");
            sql.AppendLine("					inner join TB_FIN_Clifor z ");
            sql.AppendLine("					on x.CD_Clifor = z.CD_Clifor ");
            sql.AppendLine("					where x.id_lotectb = a.id_lotectb) ");
            sql.AppendLine("				 when b.Tp_Integracao = 'CX' then ");
            sql.AppendLine("					(select case when x.vl_pagar > 0 then 'PAGAMENTO ' else 'RECEBIMENTO ' end + ");
            sql.AppendLine("							'DOCTO ' + LTrim(RTrim(x.nr_docto)) + ' ' + LTrim(RTrim(x.nm_clifor)) ");
            sql.AppendLine("					from TB_FIN_Caixa x ");
            sql.AppendLine("					where x.Id_LoteCTB = a.Id_LoteCTB) else '' end, '') ");

            sql.AppendLine("from TB_CTB_LanctosCTB a ");
            sql.AppendLine("inner join TB_CTB_LoteLan b ");
            sql.AppendLine("on a.Id_LoteCTB = b.id_loteCTB ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.data))) between '" + Dt_ini.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("and '" + Dt_fin.ToString("yyyyMMdd") + "'");

            sql.AppendLine("order by a.data, a.id_lotectb ");

            TList_LanContabil Lista = new TList_LanContabil();
            SqlDataReader reader = null;
            Boolean vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_LanctosCTB reg = new TRegistro_LanctosCTB();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb")))
                        reg.ID_LoteCTB = reader.GetDecimal(reader.GetOrdinal("id_lotectb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Conta_CTB")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Data")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("D_C")))
                        reg.D_c = reader.GetString(reader.GetOrdinal("D_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Historico")))
                        reg.Ds_compl_historico = reader.GetString(reader.GetOrdinal("Historico"));

                    Lista.Add(reg);
                }
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();
            }
        }

        public string GravaLanctosCTB(TRegistro_LanctosCTB val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTB", val.Nr_lanctoctb);
            hs.Add("@P_CD_CONTA_CTB", val.Cd_conta_ctb);            
            hs.Add("@P_ID_LOTECTB", val.ID_LoteCTB);
            hs.Add("@P_NR_DOCTO", val.Nr_docto);
            hs.Add("@P_DATA", val.Data);
            hs.Add("@P_D_C", val.D_c);
            hs.Add("@P_VALOR", val.Valor);
            hs.Add("@P_DS_COMPL_HISTORICO", val.Ds_compl_historico);
            return executarProc("IA_CTB_LANCTOSCTB", hs);
        }
        
        public string ExcluiLanctosCTB(TRegistro_LanctosCTB val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTB", val.Nr_lanctoctb);
            return executarProc("EXCLUI_CTB_LANCTOSCTB", hs);
        }

        public string ExcluiLanctosLote(decimal? vID_LoteCTB)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LOTECTB", vID_LoteCTB);
            return executarProc("EXCLUI_CTB_LANCTOSLOTE", hs);
        }

        //Balanco Sintetico 
        public List<TRegistro_BalancoSintetico> SelectBalancoSintetico(string Cd_empresa,
                                                                       string Cd_classificacao,
                                                                       string Cd_conta,
                                                                       DateTime? Dt_ini,
                                                                       DateTime? Dt_fin,
                                                                       bool St_contaMovimento,
                                                                       bool St_ignorarzeramento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.CD_Conta_CTB, SPACE((a.NIVELCONTA-1)*5)+a.ds_contactb as ds_contactb, a.cd_classificacao, ");
            sql.AppendLine("a.tp_conta, a.natureza, a.dt_alt, a.tp_contasped, a.nivelconta, a.cd_conta_ctbpai, a.cd_referencia, ");
            //Saldo Anterior ao Periodo
            if (Dt_ini.HasValue)
            {
                sql.AppendLine("SD_ant = isnull((select sum( case when k.d_c <> z.natureza then -1 else 1 end * isnull(k.valor,0) ) ");
                sql.AppendLine("                from tb_ctb_LanctosCTB k ");
                sql.AppendLine("                INNER JOIN tb_ctb_PlanoContas Z ");
                sql.AppendLine("                ON Z.CD_Conta_CTB = K.CD_Conta_CTB ");
                sql.AppendLine("                where k.CD_Conta_CTB = a.CD_Conta_CTB ");
                sql.AppendLine("                and isnull(z.st_registro, 'A') <> 'C' ");
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) < '" + Dt_ini.Value.ToString("yyyyMMdd") + "' ");
                if (St_ignorarzeramento)
                {
                    sql.AppendLine("and not exists(select 1 from tb_ctb_lotelan lote ");
                    sql.AppendLine("                where k.id_lotectb = lote.id_lotectb ");
                    sql.AppendLine("                and lote.tp_integracao = 'ZR') ");
                }
                sql.AppendLine("                and k.CD_Empresa in (" + Cd_empresa.Trim() + ")),0), ");
            }
            else sql.AppendLine("SD_ant = convert(decimal(15,2), 0), ");
            //Total Debitado no Periodo
            sql.AppendLine("SD_Deb = isnull((select sum(case when k.d_c = 'D' then isnull(k.valor,0) else 0 end ) ");
            sql.AppendLine("                from tb_ctb_LanctosCTB k ");
            sql.AppendLine("                INNER JOIN tb_ctb_PlanoContas Z ");
            sql.AppendLine("                ON Z.CD_Conta_CTB = K.CD_Conta_CTB ");
            sql.AppendLine("                where k.CD_Conta_CTB = a.CD_Conta_CTB ");
            sql.AppendLine("                and isnull(z.st_registro, 'A') <> 'C' ");
            if(Dt_ini.HasValue)
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) >= '" + Dt_ini.Value.ToString("yyyyMMdd") + "' ");
            if(Dt_fin.HasValue)
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            if (St_ignorarzeramento)
            {
                sql.AppendLine("and not exists(select 1 from tb_ctb_lotelan lote ");
                sql.AppendLine("                where k.id_lotectb = lote.id_lotectb ");
                sql.AppendLine("                and lote.tp_integracao = 'ZR') ");
            }
            sql.AppendLine("                and k.CD_Empresa in (" + Cd_empresa.Trim() + ")),0), ");
            //Total Creditado no Periodo
            //sql.AppendLine("SD_cred = isnull((select sum( case when (k.d_c = 'C' and isnull(z.st_deducao, 'N') <> 'S') or (k.d_c = 'C' and z.Natureza = 'D' and isnull(z.st_deducao, 'N') = 'S') then isnull(k.valor,0) else 0 end ) ");
            sql.AppendLine("SD_cred = isnull((select sum( case when k.d_c = 'C' then isnull(k.valor,0) else 0 end ) ");
            sql.AppendLine("                from tb_ctb_LanctosCTB k ");
            sql.AppendLine("                INNER JOIN tb_ctb_PlanoContas Z ");
            sql.AppendLine("                ON Z.CD_Conta_CTB = K.CD_Conta_CTB ");
            sql.AppendLine("                where k.CD_Conta_CTB = a.CD_Conta_CTB ");
            sql.AppendLine("                and isnull(z.st_registro, 'A') <> 'C' ");
            if(Dt_ini.HasValue)
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) >= '" + Dt_ini.Value.ToString("yyyyMMdd") + "' ");
            if(Dt_fin.HasValue)
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            if (St_ignorarzeramento)
            {
                sql.AppendLine("and not exists(select 1 from tb_ctb_lotelan lote ");
                sql.AppendLine("                where k.id_lotectb = lote.id_lotectb ");
                sql.AppendLine("                and lote.tp_integracao = 'ZR') ");
            }
            sql.AppendLine("                and k.CD_Empresa in (" + Cd_empresa.Trim() + ")),0), ");
            //Saldo Atual
            sql.AppendLine("SD_atual = isnull((select sum( case when k.d_c <> z.natureza then -1 else 1 end * isnull(k.valor,0) ) ");
            sql.AppendLine("                from tb_ctb_LanctosCTB k ");
            sql.AppendLine("                INNER JOIN tb_ctb_PlanoContas Z ");
            sql.AppendLine("                ON Z.CD_Conta_CTB = K.CD_Conta_CTB ");
            sql.AppendLine("                where k.CD_Conta_CTB = a.CD_Conta_CTB ");
            sql.AppendLine("                and isnull(z.st_registro, 'A') <> 'C' ");
            if(Dt_fin.HasValue)
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            if (St_ignorarzeramento)
            {
                sql.AppendLine("and not exists(select 1 from tb_ctb_lotelan lote ");
                sql.AppendLine("                where k.id_lotectb = lote.id_lotectb ");
                sql.AppendLine("                and lote.tp_integracao = 'ZR') ");
            }
            sql.AppendLine("                and k.CD_Empresa in (" + Cd_empresa.Trim() + ")),0) ");

            sql.AppendLine("From TB_CTB_PlanoContas a ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");
            if (!string.IsNullOrEmpty(Cd_classificacao))
                sql.AppendLine("and a.cd_classificacao like '" + Cd_classificacao.Trim() + "%'");

            if (!string.IsNullOrEmpty(Cd_conta))
                sql.AppendLine("and a.CD_Conta_CTB = '" + Cd_conta.Trim() + "' ");

            sql.AppendLine("order by a.cd_classificacao asc ");

            SqlDataReader reader = null;
            List<TRegistro_BalancoSintetico> Lista = new List<TRegistro_BalancoSintetico>();
            bool vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_BalancoSintetico reg = new TRegistro_BalancoSintetico();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                        reg.Cd_contaCTB = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contactb")))
                        reg.Ds_contactb = reader.GetString(reader.GetOrdinal("DS_Contactb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("cd_classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("tp_conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("natureza")))
                        reg.Natureza = reader.GetString(reader.GetOrdinal("natureza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_alt")))
                        reg.Dt_altconta = reader.GetDateTime(reader.GetOrdinal("dt_alt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_contasped")))
                        reg.Tp_contasped = reader.GetString(reader.GetOrdinal("tp_contasped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivelconta")))
                        reg.Nivelconta = reader.GetDecimal(reader.GetOrdinal("nivelconta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta_ctbpai")))
                        reg.Cd_contaCTBPai = reader.GetDecimal(reader.GetOrdinal("cd_conta_ctbpai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_referencia")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("cd_referencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_ant")))
                        reg.Vl_saldoant = reader.GetDecimal(reader.GetOrdinal("SD_ant"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_deb")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("SD_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_cred")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("SD_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_atual")))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("SD_atual"));

                    if (Dt_fin.HasValue && reg.Dt_altconta.HasValue)
                        if (reg.Dt_altconta.Value.Date > Dt_fin.Value.Date)
                            reg.Dt_altconta = Dt_fin;
                    Lista.Add(reg);
                }
                if (St_contaMovimento)
                    Lista = Lista.FindAll(p => p.Tp_conta.Trim().ToUpper().Equals("S") || p.Vl_saldoant != decimal.Zero || p.Vl_credito != decimal.Zero || p.Vl_debito != decimal.Zero);
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();
            }
        }

        //Razao Contabil
        public List<TRegistro_RazaoContabil> SelectRazaoContabil(string Cd_empresa,
                                                                 string lContaCTB,
                                                                 string Cd_classif,
                                                                 DateTime? Dt_ini,
                                                                 DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select z.cd_empresa, Z.NM_EMPRESA, D.NR_CGC, c.tp_integracao, ");
            sql.AppendLine("case when isnull(B.DS_Compl_Historico, '') = '' then ");
            sql.AppendLine("	(select top 1 case when isnull(x.complhistorico, '') = '' then y.ds_historico else x.complhistorico end ");
            sql.AppendLine("		from TB_FIN_Caixa x ");
            sql.AppendLine("		inner join tb_fin_historico y ");
            sql.AppendLine("		on x.cd_historico = y.cd_historico ");
            sql.AppendLine("		where x.Id_LoteCTB = b.Id_LoteCTB) else b.DS_Compl_Historico end as DS_Compl_Historico, ");
            sql.AppendLine("a.CD_Conta_CTB, a.DS_Contactb, b.nr_docto, a.natureza, ");
            sql.AppendLine("a.cd_classificacao, B.ID_LOTECTB, b.DATA, ");
            sql.AppendLine("cd_conta_contrapartida = (select top 1 x.CD_CONTA_CTB ");
            sql.AppendLine("							 from tb_ctb_lanctosCTB x ");
            sql.AppendLine("       						 where x.id_LOTEctb = b.id_LOTEctb ");
            sql.AppendLine("      						 and x.CD_CONTA_CTB <> b.CD_CONTA_CTB), ");
            sql.AppendLine("DS_conta_contrapartida = (select top 1 k.ds_contaCTB ");
            sql.AppendLine("							from tb_ctb_lanctosCTB x ");
            sql.AppendLine("							inner join TB_CTB_PLANOCONTAS k ");
            sql.AppendLine("							on k.cd_conta_CTB = x.CD_CONTA_CTB ");
            sql.AppendLine("   							where x.id_LOTEctb = b.id_LOTEctb ");
            sql.AppendLine("  							and x.CD_CONTA_CTB <> b.CD_CONTA_CTB), ");
            //Saldo Anterior ao Periodo
            sql.AppendLine("SD_ant = isnull((select sum( case when k.d_c <> z.natureza or isnull(z.ST_Deducao, 'N') = 'S' then -1 else 1 end * isnull(k.valor,0) ) ");
            sql.AppendLine("                from tb_ctb_LanctosCTB k ");
            sql.AppendLine("                INNER JOIN tb_ctb_PlanoContas Z ");
            sql.AppendLine("                ON Z.CD_Conta_CTB = K.CD_Conta_CTB ");
            sql.AppendLine("                where a.cd_classificacao = SUBSTRING(z.cd_classificacao, 1, len(a.cd_classificacao)) ");
            sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), k.data))) < '" + Dt_ini.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("                and k.CD_Empresa = '" + Cd_empresa.Trim() + "'),0), ");
            //Valor Debito
            sql.AppendLine("Vl_Deb = case when D_C = 'D'then Valor  else 0 end, ");
            //Valor Credito
            sql.AppendLine("Vl_Cred = case when D_C = 'C'then Valor  else 0 end ");

            sql.AppendLine("From tb_ctb_lanctosCTB B ");
            sql.AppendLine("inner join tb_ctb_planocontas A ");
            sql.AppendLine("on a.cd_conta_ctb = b.cd_conta_ctb ");
            sql.AppendLine("INNER JOIN TB_CTB_LOTELAN C ");
            sql.AppendLine("ON B.id_LOTEctb = C.id_LOTEctb ");
            sql.AppendLine("INNER JOIN TB_DIV_EMPRESA Z ");
            sql.AppendLine("ON Z.CD_EMPRESA = B.CD_EMPRESA ");
            sql.AppendLine("INNER JOIN TB_FIN_Clifor_PJ D ");
            sql.AppendLine("ON Z.CD_CLIFOR = D.CD_CLIFOR ");

            sql.AppendLine("WHERE a.TP_CONTA = 'A' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), B.data))) >= '" + Dt_ini.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), B.data))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("AND b.CD_Empresa = '" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(lContaCTB))
                sql.AppendLine("and a.CD_Conta_CTB in(" + lContaCTB.Trim() + ")");
            if (!string.IsNullOrEmpty(Cd_classif))
                sql.AppendLine("and a.CD_Classificacao like '" + Cd_classif.Trim() + "%'");

            sql.AppendLine("Order By A.cd_classificacao, a.CD_Conta_ctb, a.DS_Contactb, B.DATA, b.Nr_docto");

            SqlDataReader reader = null;
            List<TRegistro_RazaoContabil> Lista = new List<TRegistro_RazaoContabil>();
            bool vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_RazaoContabil reg = new TRegistro_RazaoContabil();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_EMPRESA")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                        reg.Cd_contaCTB = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contactb")))
                        reg.Ds_contactb = reader.GetString(reader.GetOrdinal("DS_Contactb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao")))
                        reg.Cd_classificacao = reader.GetString(reader.GetOrdinal("cd_classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("natureza")))
                        reg.Natureza = reader.GetString(reader.GetOrdinal("natureza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOTECTB")))
                        reg.Id_lotectb = reader.GetDecimal(reader.GetOrdinal("ID_LOTECTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("DATA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_integracao")))
                        reg.Tp_integracao = reader.GetString(reader.GetOrdinal("tp_integracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Compl_Historico")))
                        reg.Ds_comp_historico = reader.GetString(reader.GetOrdinal("DS_Compl_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta_contrapartida")))
                        reg.Cd_contaCTB_CtPartida = reader.GetDecimal(reader.GetOrdinal("cd_conta_contrapartida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_conta_contrapartida")))
                        reg.Ds_contaCTB_CtPartida = reader.GetString(reader.GetOrdinal("DS_conta_contrapartida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SD_ant")))
                        reg.Vl_saldoant = reader.GetDecimal(reader.GetOrdinal("SD_ant"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Deb")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("Vl_Deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Cred")))
                        reg.Vl_credito = reader.GetDecimal(reader.GetOrdinal("Vl_Cred"));

                    Lista.Add(reg);
                }
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();
            }
        }
        //Diario Contabil
        public List<TRegistro_DiarioContabil> SelectDiarioContabil(string Cd_empresa,
                                                                   DateTime? Dt_ini,
                                                                   DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, c.nm_empresa, d.nr_cgc, ");
            sql.AppendLine("convert(datetime, floor(convert(decimal(30,10),a.data))) as data, ");
            sql.AppendLine("b.cd_classificacao, b.ds_contactb, ");
            sql.AppendLine("a.ds_compl_historico, a.d_c, a.valor, a.id_lotectb ");

            sql.AppendLine("from TB_CTB_LanctosCTB a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on a.cd_conta_ctb = b.cd_conta_ctb ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_fin_clifor_pj d ");
            sql.AppendLine("on c.cd_clifor = d.cd_clifor ");

            string cond = "where ";

            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                sql.AppendLine(cond + "a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
                cond = " and ";
            }
            if (Dt_ini.HasValue)
            {
                sql.AppendLine(cond + "convert(datetime, floor(convert(decimal(30,10), a.data))) >= '" + Dt_ini.Value.ToString("yyyyMMdd") + "' ");
                cond = " and ";
            }
            if (Dt_fin.HasValue)
                sql.AppendLine(cond + "convert(datetime, floor(convert(decimal(30,10), a.data))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");

            sql.AppendLine("order by a.data, a.id_lotectb ");

            SqlDataReader reader = null;
            List<TRegistro_DiarioContabil> Lista = new List<TRegistro_DiarioContabil>();
            bool vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_DiarioContabil reg = new TRegistro_DiarioContabil();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_EMPRESA")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Nr_cgc = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contactb")))
                        reg.Ds_contactb = reader.GetString(reader.GetOrdinal("DS_Contactb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao")))
                        reg.Cd_classificacao = reader.GetString(reader.GetOrdinal("cd_classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOTECTB")))
                        reg.Id_lotectb = reader.GetDecimal(reader.GetOrdinal("ID_LOTECTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DATA")))
                        reg.Data = reader.GetDateTime(reader.GetOrdinal("DATA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Compl_Historico")))
                        reg.Ds_complhistorico = reader.GetString(reader.GetOrdinal("DS_Compl_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("d_c")))
                        reg.D_C = reader.GetString(reader.GetOrdinal("d_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("valor"));

                    Lista.Add(reg);
                }
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();
            }
        }                                                      
        //DRE
        public List<TRegistro_DRE> SelectDRE(string Cd_empresa,
                                             string Id_dre,
                                             decimal Exercicio)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_param, SPACE((a.nivel-1)*5)+a.ds_param as ds_param, a.classificacao, ");
            sql.AppendLine("a.nivel, a.tp_conta, a.operador, c.cd_conta_ctb, c.ds_contactb, ");
            sql.AppendLine("sd_ant = isnull((select sum(case when x.d_c <> y.natureza then - 1 else 1 end * isnull(x.valor, 0)) ");
            sql.AppendLine("			from tb_ctb_lanctosCTB x ");
            sql.AppendLine("			inner join tb_ctb_planocontas y ");
            sql.AppendLine("			on x.cd_conta_ctb = y.cd_conta_ctb ");
            sql.AppendLine("			where x.cd_conta_ctb = c.cd_conta_ctb ");
            sql.AppendLine("            and year(x.data) = " + (Exercicio - 1).ToString());
            sql.AppendLine("			and x.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("			and not exists(select 1 from tb_ctb_lotelan lote ");
            sql.AppendLine("							where x.id_lotectb = lote.id_lotectb ");
            sql.AppendLine("							and lote.tp_integracao = 'ZR')), 0), ");
            sql.AppendLine("sd_atual = isnull((select sum(case when x.d_c <> y.natureza then - 1 else 1 end * isnull(x.valor, 0)) ");
            sql.AppendLine("			from tb_ctb_lanctosCTB x ");
            sql.AppendLine("			inner join tb_ctb_planocontas y ");
            sql.AppendLine("			on x.cd_conta_ctb = y.cd_conta_ctb ");
            sql.AppendLine("			where x.cd_conta_ctb = c.cd_conta_ctb ");
            sql.AppendLine("			and year(x.data) = " + Exercicio.ToString());
            sql.AppendLine("			and x.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("			and not exists(select 1 from tb_ctb_lotelan lote ");
            sql.AppendLine("							where x.id_lotectb = lote.id_lotectb ");
            sql.AppendLine("							and lote.tp_integracao = 'ZR')), 0) ");

            sql.AppendLine("from tb_ctb_paramdre a ");
            sql.AppendLine("left outer join tb_ctb_param_x_contactb b ");
            sql.AppendLine("on a.id_dre = b.id_dre ");
            sql.AppendLine("and a.id_param = b.id_param ");
            sql.AppendLine("left outer join tb_ctb_planocontas c ");
            sql.AppendLine("on b.cd_conta_ctb = c.cd_conta_ctb ");

            sql.AppendLine("where a.id_dre = " + Id_dre);
            sql.AppendLine("and isnull(c.st_registro, 'A') <> 'C' ");

            sql.AppendLine("order by classificacao ");

            SqlDataReader reader = null;
            List<TRegistro_DRE> Lista = new List<TRegistro_DRE>();
            bool vCriaBanco = false;
            if (Banco_Dados == null)
                vCriaBanco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_DRE reg = new TRegistro_DRE();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_param")))
                        reg.Id_param = reader.GetDecimal(reader.GetOrdinal("id_param"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_param")))
                        reg.Ds_param = reader.GetString(reader.GetOrdinal("ds_param"));
                    if (!reader.IsDBNull(reader.GetOrdinal("classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("tp_conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("nivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta_ctb")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("cd_conta_ctb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb")))
                        reg.Ds_contactb = reader.GetString(reader.GetOrdinal("ds_contactb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("operador")))
                        reg.Operador = reader.GetString(reader.GetOrdinal("operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sd_ant")))
                        reg.Sd_ant = reader.GetDecimal(reader.GetOrdinal("sd_ant"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sd_atual")))
                        reg.Sd_atual = reader.GetDecimal(reader.GetOrdinal("sd_atual"));

                    Lista.Add(reg);
                }
                return Lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (vCriaBanco)
                    deletarBanco_Dados();
            }
        }
        public DataTable Integracao_Contabil_lote(decimal vLote)
        {
            StringBuilder SQL = new StringBuilder();
            Hashtable param = new Hashtable();

            SQL.AppendLine("SELECT D.CD_EMPRESA, D.NR_LANCTOCTB, B.CD_Classificacao, D.CD_CONTA_CTB, D.D_C, D.VALOR, D.DS_COMPL_HISTORICO, b.DS_ContaCTB ");
            SQL.AppendLine("FROM TB_CTB_LANCTOSCTB D join TB_CTB_PlanoContas B ON D.CD_CONTA_CTB = B.CD_CONTA_CTB");
            SQL.AppendLine("WHERE D.ID_LOTECTB = @ID_LOTECTB");

            param.Add("@ID_LOTECTB", vLote);
            return ExecutarBusca(SQL.ToString(), param);
        }
    }

    public class TCD_CTB_Faturamento : TDataQuery
    {
        private string SQLCodeBusca(TpBusca[] vBusca, short vTop)
        {
            StringBuilder SQL = new StringBuilder();
            string cond = " Where (isnull(c.ST_BATCH,'N') = 'N')";
            string and = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    cond = cond + and + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )";

            //union principal filtro completo
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, ");
            SQL.AppendLine(" d.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, b.vl_subtotal as valor, b.ID_NFItem, a.NR_LanctoFiscal ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine(" inner join TB_CTB_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and a.cd_clifor = c.cd_clifor and b.cd_produto = c.cd_produto and not c.cd_clifor is null and not c.cd_produto is null ");
            SQL.AppendLine(" inner join TB_FIS_Movimentacao d on D.CD_Movimentacao = a.cd_movimentacao ");
            SQL.AppendLine(  cond);
            
            SQL.AppendLine(" UNION  "); //UNION PARCIAL SEM CLIFOR

            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_Movimento, ");
            SQL.AppendLine(" d.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, b.vl_subtotal as valor, b.ID_NFItem, a.NR_LanctoFiscal ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine(" inner join TB_CTB_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and  b.cd_produto = c.cd_produto and not c.cd_produto is null and c.cd_clifor is null ");
            SQL.AppendLine(" inner join TB_FIS_Movimentacao d on D.CD_Movimentacao = a.cd_movimentacao ");
            SQL.AppendLine(  cond);

            SQL.AppendLine(" UNION  "); //UNION PARCIAL SEM PRODUTO

            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_Movimento, ");
            SQL.AppendLine(" d.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, b.vl_subtotal as valor, b.ID_NFItem, a.NR_LanctoFiscal ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine(" inner join TB_CTB_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and a.cd_clifor = c.cd_clifor and not c.cd_clifor is null and c.cd_produto is null ");
            SQL.AppendLine(" inner join TB_FIS_Movimentacao d on D.CD_Movimentacao = a.cd_movimentacao ");
            SQL.AppendLine(  cond);

            SQL.AppendLine(" UNION  "); //UNION PARCIAL SEM PRODUTO SEM CLIFOR

            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_Movimento, ");
            SQL.AppendLine(" d.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, b.vl_subtotal as valor, b.ID_NFItem, a.NR_LanctoFiscal ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL  ");
            SQL.AppendLine(" inner join TB_CTB_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_produto is null and c.cd_clifor is null  ");
            SQL.AppendLine(" inner join TB_FIS_Movimentacao d on D.CD_Movimentacao = a.cd_movimentacao ");
            SQL.AppendLine( cond);

            SQL.AppendLine("ORDER BY cd_produto desc, cd_clifor desc ");

            return SQL.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SQLCodeBusca(vBusca, vTop), null);
        }
        public string GravaLoteCTB(Hashtable vParamChave)
        { 
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Update TB_FAT_NotaFiscal_Item set ");
            sql.AppendLine("ID_LoteCTB_FAT = @ID_LOTECTB ");
            sql.AppendLine("Where CD_Empresa = @CD_EMPRESA ");
            sql.AppendLine("and NR_LanctoFiscal = @NR_LANCTOFISCAL ");
            sql.AppendLine("and ID_NFItem = @ID_NFITEM ");
            return executarSql(sql.ToString(), vParamChave);        
        }
    }

    public class TCD_CTB_Imposto_Faturamento : TDataQuery
    {
        private string SQLCodeBusca(TpBusca[] vBusca, short vTop)
        {
            StringBuilder SQL = new StringBuilder();
            string cond = " Where (isnull(c.ST_BATCH,'N') = 'N')";
            string and = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    cond = cond + and + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )";

            //union principal filtro completo - Imposto Retido
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_impostoretido as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_ImpostoRetido > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and a.cd_clifor = c.cd_clifor and b.cd_produto = c.cd_produto and c.TP_Imposto = 'R' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);
            
            SQL.AppendLine(" UNION ");
            //union principal filtro completo - Imposto Calculado
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_imposto as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_Imposto > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and a.cd_clifor = c.cd_clifor and b.cd_produto = c.cd_produto and c.TP_Imposto = 'C' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION ");

            //union principal filtro sem clifor - Imposto Retido
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_impostoretido as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_ImpostoRetido > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and b.cd_produto = c.cd_produto and c.cd_clifor is null and c.TP_Imposto = 'R' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION ");
            //union principal filtro sem clifor - Imposto Calculado
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_imposto as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_Imposto > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_clifor is null and b.cd_produto = c.cd_produto and c.TP_Imposto = 'C' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION ");

            //union principal filtro sem produto - Imposto Retido
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_impostoretido as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_ImpostoRetido > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_produto is null and c.cd_clifor = a.cd_clifor and c.TP_Imposto = 'R' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION ");
            //union principal filtro sem produto - Imposto Calculado
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_imposto as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_Imposto > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_clifor = a.cd_clifor and c.cd_produto is null and c.TP_Imposto = 'C' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION ");

            //union principal filtro sem produto e sem clifor - Imposto Retido
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_impostoretido as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_ImpostoRetido > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_produto is null and c.cd_clifor is null and c.TP_Imposto = 'R' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond + "  ");

            SQL.AppendLine(" UNION ");
            //union principal filtro sem produto e sem clifor - Imposto Calculado
            SQL.AppendLine(" select  a.cd_empresa, a.Nr_notafiscal as Nr_docto, case when a.tp_movimento = 'E' then a.DT_SAIENT else a.DT_Emissao end as DATA, a.tp_movimento, a.NR_LanctoFiscal, ");
            SQL.AppendLine(" e.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_clifor, c.cd_produto, e.vl_imposto as valor, b.ID_NFItem, e.CD_Imposto, c.TP_Imposto ");
            SQL.AppendLine(" from TB_FAT_NotaFiscal a ");
            SQL.AppendLine(" inner join TB_FAT_Notafiscal_Item b  ON A.CD_EMPRESA = B.CD_EMPRESA AND A.NR_LANCTOFISCAL = B.NR_LANCTOFISCAL ");
            SQL.AppendLine("inner join TB_FAT_Impostos e On e.CD_Empresa = b.CD_Empresa and e.NR_LanctoFiscal = b.NR_LanctoFiscal and e.ID_NFItem = b.ID_NFItem and e.Vl_Imposto > 0 ");
            SQL.AppendLine(" inner join TB_CTB_Imposto_Faturamento c on  a.cd_movimentacao = c.cd_movimentacao and c.cd_clifor is null and c.cd_produto is null and c.TP_Imposto = 'C' ");
            SQL.AppendLine("and c.CD_Imposto = e.CD_Imposto ");
            SQL.AppendLine(cond);

            SQL.AppendLine("ORDER BY cd_produto desc, cd_clifor desc ");

            return SQL.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SQLCodeBusca(vBusca, vTop), null);
        }
        public string GravaLoteCTB(Hashtable vParamChave)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Update TB_FAT_Impostos set ");
            sql.AppendLine("ID_LoteCTB_Retido = @ID_LOTECTB_RETIDO, ");
            sql.AppendLine("ID_LoteCTB_Calculado = @ID_LOTECTB_CALCULADO ");
            sql.AppendLine("Where CD_Empresa = @CD_EMPRESA ");
            sql.AppendLine("and NR_LanctoFiscal = @NR_LANCTOFISCAL ");
            sql.AppendLine("and ID_NFItem = @ID_NFITEM ");
            sql.AppendLine("and CD_Imposto = @CD_IMPOSTO ");
            return executarSql(sql.ToString(), vParamChave);
        }
    }

    public class TCD_CTB_Financeiro : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, short vTop)
        {
            StringBuilder SQL = new StringBuilder();
            string cond = " Where (isnull(c.ST_BATCH,'N') = 'N')";
            string and = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    cond = cond + and + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )";

            //union principal filtro completo
            SQL.AppendLine("select  a.cd_empresa, a.nr_docto, a.dt_emissao as data, c.cd_historico, ");
            SQL.AppendLine("c.cd_conta_ctb_cred, c.cd_conta_ctb_deb, c.cd_clifor, a.vl_documento as valor, a.nr_lancto ");
            SQL.AppendLine("from TB_FIN_Duplicata a ");
            SQL.AppendLine("inner join TB_CTB_Financeiro c ON  a.tp_duplicata = c.tp_duplicata and a.cd_clifor = c.cd_clifor and c.cd_clifor is not null ");
            SQL.AppendLine("inner join TB_FIN_TPDuplicata d ON d.tp_duplicata = a.tp_duplicata ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION  "); //UNION PARCIAL SEM CLIFOR

            SQL.AppendLine("select  a.cd_empresa, a.nr_docto, a.dt_emissao as data, c.cd_historico, ");
            SQL.AppendLine("c.cd_conta_ctb_cred, c.cd_conta_ctb_deb, c.cd_clifor, a.vl_documento as valor, a.nr_lancto ");
            SQL.AppendLine("from TB_FIN_Duplicata a ");
            SQL.AppendLine("inner join TB_CTB_Financeiro c ON  a.tp_duplicata = c.tp_duplicata and c.cd_clifor is not null ");
            SQL.AppendLine("inner join TB_FIN_TPDuplicata d ON d.tp_duplicata = a.tp_duplicata ");
            SQL.AppendLine(cond);
            
            SQL.AppendLine("ORDER BY cd_clifor desc ");

            return SQL.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop), null);
        }

        public string GravaLoteCTB(Hashtable vParamChave)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Update TB_FIN_Duplicata set ");
            sql.AppendLine("ID_LoteCTB = @ID_LOTECTB ");
            sql.AppendLine("Where CD_Empresa = @CD_EMPRESA ");
            sql.AppendLine("and NR_Lancto = @NR_LANCTO ");
            return executarSql(sql.ToString(), vParamChave);
        }
    }

    public class TCD_CTB_Caixa : TDataQuery
    {
        private string SQLCodeBusca(TpBusca[] vBusca, short vTop)
        {
            StringBuilder SQL = new StringBuilder();
            string cond = " Where (isnull(c.ST_BATCH,'N') = 'N')";
            string and = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    cond = cond + and + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )";

            //union principal filtro completo
            SQL.AppendLine(" select  a.cd_empresa, a.nr_Docto, DT_Lancto as DATA, case when a.vl_receber > 0 then 'E' else 'S' end as Tp_MovCX, d.Tp_mov as Tp_MovHS, a.cd_contaGer, a.cd_lanctocaixa, ");
            SQL.AppendLine(" a.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_empresa, abs(a.vl_receber - a.vl_pagar) as valor, d.ds_historico  ");
            SQL.AppendLine(" from TB_FIN_CAIXA a ");
            SQL.AppendLine(" inner join TB_CTB_Caixa c on a.cd_empresa = c.cd_empresa and a.cd_contaGer = c.cd_contaGer ");
            SQL.AppendLine("  and a.cd_historico = c.cd_historico and not c.cd_empresa is null ");
            SQL.AppendLine(" inner join TB_FIN_Historico d on d.cd_historico = a.cd_historico and d.st_contabil = 'S' ");
            SQL.AppendLine(cond);

            SQL.AppendLine(" UNION  "); //UNION PARCIAL SEM EMPRESA

            SQL.AppendLine(" select  a.cd_empresa, a.nr_Docto, DT_Lancto as DATA, case when a.vl_receber > 0 then 'E' else 'S' end as Tp_MovCX, d.Tp_mov as Tp_MovHS, a.cd_contager, a.cd_lanctocaixa, ");
            SQL.AppendLine(" a.cd_historico, c.CD_CONTA_CTB_CRED, C.CD_CONTA_CTB_DEB, c.cd_empresa, abs(a.vl_receber - a.vl_pagar) as valor, d.ds_historico  ");
            SQL.AppendLine(" from TB_FIN_CAIXA a ");
            SQL.AppendLine(" inner join TB_CTB_Caixa c on a.cd_contaGer = c.cd_contaGer ");
            SQL.AppendLine("  and a.cd_historico = c.cd_historico and c.cd_empresa is null ");
            SQL.AppendLine(" inner join TB_FIN_Historico d on d.cd_historico = a.cd_historico and d.st_contabil = 'S' ");
            SQL.AppendLine(cond + "  ");

            SQL.AppendLine("ORDER BY a.cd_empresa desc ");

            return SQL.ToString();
        }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SQLCodeBusca(vBusca, vTop), null);
        }
        
        public string GravaLoteCTB(Hashtable vParamChave)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Update TB_FIN_CAIXA set ");
            sql.AppendLine("ID_LoteCTB = @ID_LOTECTB ");
            sql.AppendLine("Where CD_ContaGer = @CD_CONTAGER ");
            sql.AppendLine("and CD_LANCTOCAIXA = @CD_LANCTOCAIXA ");            
            return executarSql(sql.ToString(), vParamChave);
        }
    }
}
