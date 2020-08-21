using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_CfgFrota : List<TRegistro_CfgFrota>, IComparer<TRegistro_CfgFrota>
    {
        #region IComparer<TRegistro_CfgFrota> Members
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

        public TList_CfgFrota()
        { }

        public TList_CfgFrota(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgFrota value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgFrota x, TRegistro_CfgFrota y)
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
    
    public class TRegistro_CfgFrota
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cnpj_empresa
        { get; set; }
        public string Cd_uf_empresa
        { get; set; }
        public string Cnpj_contador { get; set; } = string.Empty;
        public string Cd_combustivel
        { get; set; }
        public string Ds_combustivel
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        private decimal? id_despesacombustivel;
        public decimal? Id_despesacombustivel
        {
            get { return id_despesacombustivel; }
            set
            {
                id_despesacombustivel = value;
                id_despesacombustivelstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesacombustivelstr;
        public string Id_despesacombustivelstr
        {
            get { return id_despesacombustivelstr; }
            set
            {
                id_despesacombustivelstr = value;
                try
                {
                    id_despesacombustivel = decimal.Parse(value);
                }
                catch
                { id_despesacombustivel = null; }
            }
        }
        public string Ds_despesacombustivel
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_historicoDesp
        { get; set; }
        public string Ds_historicoDesp
        { get; set; }
        public string Cd_terminal
        { get; set; }
        public string Ds_terminal
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        private decimal? cd_movcte;
        public decimal? Cd_movcte
        {
            get { return cd_movcte; }
            set
            {
                cd_movcte = value;
                cd_movctestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movctestr;
        public string Cd_movctestr
        {
            get { return cd_movctestr; }
            set
            {
                cd_movctestr = value;
                try
                {
                    cd_movcte = decimal.Parse(value);
                }
                catch { cd_movcte = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public string Nr_seriecte
        { get; set; }
        public string Ds_seriecte
        { get; set; }
        public string Cd_modelocte
        { get; set; }
        private decimal? cd_movanulacao;
        public decimal? Cd_movanulacao
        {
            get { return cd_movanulacao; }
            set
            {
                cd_movanulacao = value;
                cd_movanulacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movanulacaostr;
        public string Cd_movanulacaostr
        {
            get { return cd_movanulacaostr; }
            set
            {
                cd_movanulacaostr = value;
                try
                {
                    cd_movanulacao = decimal.Parse(value);
                }
                catch
                { cd_movanulacao = null; }
            }
        }
        public string Ds_movanulacao
        { get; set; }
        private decimal? cd_cmianulacao;
        public decimal? Cd_cmianulacao
        {
            get { return cd_cmianulacao; }
            set
            {
                cd_cmianulacao = value;
                cd_cmianulacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_cmianulacaostr;
        public string Cd_cmianulacaostr
        {
            get { return cd_cmianulacaostr; }
            set
            {
                cd_cmianulacaostr = value;
                try
                {
                    cd_cmianulacao = decimal.Parse(value);
                }
                catch { cd_cmianulacao = null; }
            }
        }
        public string Ds_cmianulacao
        { get; set; }
        private decimal? cd_movcteuf;
        public decimal? Cd_movcteuf
        {
            get { return cd_movcteuf; }
            set
            {
                cd_movcteuf = value;
                cd_movcteufstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movcteufstr;
        public string Cd_movcteufstr
        {
            get { return cd_movcteufstr; }
            set
            {
                cd_movcteufstr = value;
                try
                {
                    cd_movcteuf = decimal.Parse(value);
                }
                catch { cd_movcteuf = null; }
            }
        }
        public string Ds_movcteuf
        { get; set; }
        public bool St_sequenciaauto
        { get; set; }
        private string st_exigirrequisicao;
        public string St_exigirrequisicao
        {
            get { return st_exigirrequisicao; }
            set
            {
                st_exigirrequisicao = value;
                st_exigirrequisicaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirrequisicaobool;
        public bool St_exigirrequisicaobool
        {
            get { return st_exigirrequisicaobool; }
            set
            {
                st_exigirrequisicaobool = value;
                st_exigirrequisicao = value ? "S" : "N";
            }
        }
        private string tp_concentrador;
        public string Tp_concentrador
        {
            get { return tp_concentrador; }
            set
            {
                tp_concentrador = value;
                if (value.Trim().ToUpper().Equals("CT"))
                    tipo_concentrador = "COMPANYTEC";
                else if (value.Trim().ToUpper().Equals("GB"))
                    tipo_concentrador = "GILBARCO";
                else if (value.Trim().ToUpper().Equals("VW"))
                    tipo_concentrador = "VWTECH";
            }
        }
        private string tipo_concentrador;
        public string Tipo_concentrador
        {
            get { return tipo_concentrador; }
            set
            {
                tipo_concentrador = value;
                if (value.Trim().ToUpper().Equals("COMPANYTEC"))
                    tp_concentrador = "CT";
                else if (value.Trim().ToUpper().Equals("GILBARCO"))
                    tp_concentrador = "GB";
                else if (value.Trim().ToUpper().Equals("VWTECH"))
                    tp_concentrador = "VW";
            }
        }
        public decimal Porta_comunicacao
        { get; set; }
        public string Endereco_bico
        { get; set; }
        public decimal Tmp_abastecimento
        { get; set; }
        public decimal Tmp_abastonline
        { get; set; }
        public decimal Vl_fatordivisao
        { get; set; }
        private string st_km_obrigatorio;
        public string St_km_obrigatorio
        {
            get { return st_km_obrigatorio; }
            set
            {
                st_km_obrigatorio = value;
                st_km_obrigatoriobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_km_obrigatoriobool;
        public bool St_km_obrigatoriobool
        {
            get { return st_km_obrigatoriobool; }
            set
            {
                st_km_obrigatoriobool = value;
                st_km_obrigatorio = value ? "S" : "N";
            }
        }
        public string Path_schemas
        { get; set; }
        public string Nr_seriecertificado
        { get; set; }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente = "PRODUÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente = "HOMOLOGAÇÃO";
            }
        }
        private string tipo_ambiente;
        public string Tipo_ambiente
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("PRODUÇÃO"))
                    tp_ambiente = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente = "2";
            }
        }
        private string tp_ambientecont;
        public string Tp_ambientecont
        {
            get { return tp_ambientecont; }
            set
            {
                tp_ambientecont = value;
                if (value.Trim().ToUpper().Equals("SP"))
                    tipo_ambiente = "SVC-SÃO PAULO";
                else if (value.Trim().ToUpper().Equals("RS"))
                    tipo_ambiente = "SVC-RIO GRANDE DO SUL";
            }
        }
        private string tipo_ambientecont;
        public string Tipo_ambientecont
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("SVC-SÃO PAULO"))
                    tp_ambientecont = "SP";
                else if (value.Trim().ToUpper().Equals("SVC-RIO GRANDE DO SUL"))
                    tp_ambientecont = "RS";
            }
        }
        public string Cd_versaolayout
        { get; set; }
        public string Cd_versaomodalrod
        { get; set; }
        public string RNTRC
        { get; set; }
        public decimal Pc_impAprox
        { get; set; }
        private string tp_tomadordef;
        public string Tp_tomadordef
        {
            get { return tp_tomadordef; }
            set
            {
                tp_tomadordef = value;
                if (value.Trim().Equals("0"))
                    tipo_tomadordef = "REMETENTE";
                else if (value.Trim().Equals("1"))
                    tipo_tomadordef = "EXPEDIDOR";
                else if (value.Trim().Equals("2"))
                    tipo_tomadordef = "RECEBEDOR";
                else if (value.Trim().Equals("3"))
                    tipo_tomadordef = "DESTINATARIO";
            }
        }
        private string tipo_tomadordef;
        public string Tipo_tomadordef
        {
            get { return tipo_tomadordef; }
            set
            {
                tipo_tomadordef = value;
                if (value.Trim().ToUpper().Equals("REMETENTE"))
                    tp_tomadordef = "0";
                else if (value.Trim().ToUpper().Equals("EXPEDIDOR"))
                    tp_tomadordef = "1";
                else if (value.Trim().ToUpper().Equals("RECEBEDOR"))
                    tp_tomadordef = "2";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_tomadordef = "3";
            }
        }
        public string Ds_condusoCCe
        { get; set; }
        public bool St_ctecontingencia
        { get; set; }
        public decimal Vl_unitfrete
        { get; set; }
        private string tp_unidfrete;
        public string Tp_unidfrete
        {
            get { return tp_unidfrete; }
            set
            {
                tp_unidfrete = value;
                if (value.Trim().Equals("00"))
                    tipo_unidfrete = "METROS CUBICOS";
                else if (value.Trim().Equals("01"))
                    tipo_unidfrete = "QUILOGRAMA";
                else if (value.Trim().Equals("02"))
                    tipo_unidfrete = "TONELADA";
                else if (value.Trim().Equals("03"))
                    tipo_unidfrete = "UNIDADE";
                else if (value.Trim().Equals("04"))
                    tipo_unidfrete = "LITROS";
                else if (value.Trim().Equals("05"))
                    tipo_unidfrete = "MMBTU";
            }
        }
        private string tipo_unidfrete;
        public string Tipo_unidfrete
        {
            get { return tipo_unidfrete; }
            set
            {
                tipo_unidfrete = value;
                if (value.Trim().ToUpper().Equals("METROS CUBICOS"))
                    tp_unidfrete = "00";
                else if (value.Trim().ToUpper().Equals("KILOS"))
                    tp_unidfrete = "01";
                else if (value.Trim().ToUpper().Equals("TONELADA"))
                    tp_unidfrete = "02";
                else if (value.Trim().ToUpper().Equals("UNIDADE"))
                    tp_unidfrete = "03";
                else if (value.Trim().ToUpper().Equals("LITROS"))
                    tp_unidfrete = "04";
                else if (value.Trim().ToUpper().Equals("MMBTU"))
                    tp_unidfrete = "05";
            }
        }
        public string OutrasCaracCarga
        { get; set; }
        private string st_subimpbasecalccom;
        public string St_subimpbasecalccom
        {
            get { return st_subimpbasecalccom; }
            set
            {
                st_subimpbasecalccom = value;
                st_subimpbasecalccombool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_subimpbasecalccombool;
        public bool St_subimpbasecalccombool
        {
            get { return st_subimpbasecalccombool; }
            set
            {
                st_subimpbasecalccombool = value;
                st_subimpbasecalccom = value ? "S" : "N";

            }
        }
        private string tp_recapuracao;
        public string Tp_recapuracao
        {
            get { return tp_recapuracao; }
            set
            {
                tp_recapuracao = value;
                if (value.Trim().Equals("0"))
                    tipo_recapuracao = "CTE";
                else if (value.Trim().Equals("1"))
                    tipo_recapuracao = "OUTRAS RECEITAS";
                else if (value.Trim().Equals("2"))
                    tipo_recapuracao = "TODAS";
            }
        }
        private string tipo_recapuracao;
        public string Tipo_recapuracao
        {
            get { return tipo_recapuracao; }
            set
            {
                tipo_recapuracao = value;
                if (value.Trim().ToUpper().Equals("CTE"))
                    tp_recapuracao = "0";
                else if (value.Trim().ToUpper().Equals("OUTRAS RECEITAS"))
                    tp_recapuracao = "1";
                else if (value.Trim().ToUpper().Equals("TODAS"))
                    tp_recapuracao = "2";
            }
        }

        public TRegistro_CfgFrota()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cnpj_empresa = string.Empty;
            Cd_uf_empresa = string.Empty;
            Cd_combustivel = string.Empty;
            Ds_combustivel = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            id_despesacombustivel = null;
            id_despesacombustivelstr = string.Empty;
            Ds_despesacombustivel = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_historicoDesp = string.Empty;
            Ds_historicoDesp = string.Empty;
            Cd_terminal = string.Empty;
            Ds_terminal = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            cd_movcte = null;
            cd_movctestr = string.Empty;
            Ds_movimentacao = string.Empty;
            Nr_seriecte = string.Empty;
            Ds_seriecte = string.Empty;
            Cd_modelocte = string.Empty;
            cd_movanulacao = null;
            cd_movanulacaostr = string.Empty;
            Ds_movanulacao = string.Empty;
            cd_cmianulacao = null;
            cd_cmianulacaostr = string.Empty;
            Ds_cmianulacao = string.Empty;
            cd_movcteuf = null;
            cd_movcteufstr = string.Empty;
            Ds_movcteuf = string.Empty;
            St_sequenciaauto = false;
            st_exigirrequisicao = "N";
            st_exigirrequisicaobool = false;
            tp_concentrador = string.Empty;
            tipo_concentrador = string.Empty;
            Porta_comunicacao = decimal.Zero;
            Endereco_bico = string.Empty;
            Tmp_abastecimento = decimal.Zero;
            Tmp_abastonline = decimal.Zero;
            Vl_fatordivisao = decimal.Zero;
            st_km_obrigatorio = "N";
            st_km_obrigatoriobool = false;
            Path_schemas = string.Empty;
            Nr_seriecertificado = string.Empty;
            tp_ambiente = string.Empty;
            tipo_ambiente = string.Empty;
            tp_ambientecont = string.Empty;
            tipo_ambientecont = string.Empty;
            Cd_versaolayout = string.Empty;
            Cd_versaomodalrod = string.Empty;
            RNTRC = string.Empty;
            Pc_impAprox = decimal.Zero;
            tp_tomadordef = string.Empty;
            tipo_tomadordef = string.Empty;
            Ds_condusoCCe = string.Empty;
            St_ctecontingencia = false;
            Vl_unitfrete = decimal.Zero;
            tp_unidfrete = string.Empty;
            tipo_unidfrete = string.Empty;
            OutrasCaracCarga = string.Empty;
            st_subimpbasecalccom = "N";
            st_subimpbasecalccombool = false;
            tp_recapuracao = "2";
            tipo_recapuracao = "TODAS";
        }
    }

    public class TCD_CfgFrota : TDataQuery
    {
        public TCD_CfgFrota()
        { }

        public TCD_CfgFrota(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, cEmp.nr_cgc, endEmp.cd_uf as cd_uf_empresa, ");
                sql.AppendLine("a.cd_combustivel, c.ds_produto as ds_combustivel, a.rntrc, a.pc_impaprox, ");
                sql.AppendLine("a.cd_local, d.ds_local, a.id_despesacombustivel, a.ds_condusocce, ");
                sql.AppendLine("e.ds_despesa as ds_despesacombustivel, a.porta_comunicacao, ");
                sql.AppendLine("a.tp_concentrador, a.st_exigirrequisicao, a.vl_fatordivisao, ");
                sql.AppendLine("a.tmp_abastecimento, a.tmp_abastonline, a.st_km_obrigatorio, ");
                sql.AppendLine("a.endereco_bico, a.tp_duplicata, f.ds_tpduplicata, ");
                sql.AppendLine("a.tp_docto, g.ds_tpdocto, a.cd_historico, h.ds_historico, " );
                sql.AppendLine("a.cd_historicodesp, j.ds_historico as ds_historicodesp, ");
                sql.AppendLine("a.cd_terminal, i.ds_terminal, a.cd_contager, k.ds_contager, ");
                sql.AppendLine("a.path_schemas, a.nr_seriecertificado, a.tp_ambiente, a.tp_ambientecont, ");
                sql.AppendLine("a.cd_versaolayout, a.cd_versaomodalrod, ");
                sql.AppendLine("a.cd_movcte, l.ds_movimentacao, a.nr_seriecte, m.ds_serienf, ");
                sql.AppendLine("m.st_sequenciaauto, a.cd_modelocte, a.vl_unitfrete, a.tp_unidfrete, ");
                sql.AppendLine("a.cd_movanulacao, n.ds_movimentacao as ds_movanulacao, ");
                sql.AppendLine("a.cd_cmianulacao, o.ds_cmi as ds_cmianulacao, a.st_subimpbasecalccom, ");
                sql.AppendLine("a.cd_movcteuf, p.ds_movimentacao as ds_movcteuf, a.outrascaraccarga, ");
                sql.AppendLine("a.tp_tomadordef, a.TP_RecApuracao, cCont.NR_CGC as Cnpj_contador ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_CfgFrota a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_Clifor cEmp ");
            sql.AppendLine("on b.cd_clifor = cEmp.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco endEmp ");
            sql.AppendLine("on b.cd_clifor = endEmp.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = endEmp.cd_endereco ");
            sql.AppendLine("left outer join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_combustivel = c.cd_produto ");
            sql.AppendLine("left outer join TB_EST_LocalArm d ");
            sql.AppendLine("on a.cd_local = d.cd_local ");
            sql.AppendLine("left outer join TB_FRT_Despesa e ");
            sql.AppendLine("on a.id_despesacombustivel = e.id_despesa ");
            sql.AppendLine("left outer join tb_fin_tpduplicata f ");
            sql.AppendLine("on a.tp_duplicata = f.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup g ");
            sql.AppendLine("on a.tp_docto = g.tp_docto ");
            sql.AppendLine("left outer join tb_fin_historico h ");
            sql.AppendLine("on a.cd_historico = h.cd_historico ");
            sql.AppendLine("left outer join tb_div_terminal i ");
            sql.AppendLine("on a.cd_terminal = i.cd_terminal ");
            sql.AppendLine("left outer join tb_fin_historico j ");
            sql.AppendLine("on a.cd_historicodesp = j.cd_historico ");
            sql.AppendLine("left outer join tb_fin_contager k ");
            sql.AppendLine("on a.cd_contager = k.cd_contager ");
            sql.AppendLine("left outer join tb_fis_movimentacao l ");
            sql.AppendLine("on a.cd_movcte = l.cd_movimentacao ");
            sql.AppendLine("left outer join tb_fat_serienf m ");
            sql.AppendLine("on a.nr_seriecte = m.nr_serie ");
            sql.AppendLine("and a.cd_modelocte = m.cd_modelo ");
            sql.AppendLine("left outer join tb_fis_movimentacao n ");
            sql.AppendLine("on a.cd_movanulacao = n.cd_movimentacao ");
            sql.AppendLine("left outer join tb_fis_cmi o ");
            sql.AppendLine("on a.cd_cmianulacao = o.cd_cmi ");
            sql.AppendLine("left outer join tb_fis_movimentacao p ");
            sql.AppendLine("on a.cd_movcteuf = p.cd_movimentacao ");
            sql.AppendLine("left outer join VTB_FIN_Clifor cCont ");
            sql.AppendLine("on b.cd_escritorio_contabil = cCont.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CfgFrota Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgFrota lista = new TList_CfgFrota();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
            
                {
                    TRegistro_CfgFrota reg = new TRegistro_CfgFrota();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj_empresa = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_empresa")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("cd_uf_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cnpj_contador")))
                        reg.Cnpj_contador = reader.GetString(reader.GetOrdinal("Cnpj_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_combustivel")))
                        reg.Cd_combustivel = reader.GetString(reader.GetOrdinal("cd_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_combustivel")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesacombustivel")))
                        reg.Id_despesacombustivel = reader.GetDecimal(reader.GetOrdinal("id_despesacombustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesacombustivel")))
                        reg.Ds_despesacombustivel = reader.GetString(reader.GetOrdinal("ds_despesacombustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicodesp")))
                        reg.Cd_historicoDesp = reader.GetString(reader.GetOrdinal("cd_historicodesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicodesp")))
                        reg.Ds_historicoDesp = reader.GetString(reader.GetOrdinal("ds_historicodesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_terminal")))
                        reg.Cd_terminal = reader.GetString(reader.GetOrdinal("cd_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_terminal")))
                        reg.Ds_terminal = reader.GetString(reader.GetOrdinal("ds_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movcte")))
                        reg.Cd_movcte = reader.GetDecimal(reader.GetOrdinal("cd_movcte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_seriecte")))
                        reg.Nr_seriecte = reader.GetString(reader.GetOrdinal("nr_seriecte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.Ds_seriecte = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_sequenciaauto")))
                        reg.St_sequenciaauto = reader.GetString(reader.GetOrdinal("st_sequenciaauto")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelocte")))
                        reg.Cd_modelocte = reader.GetString(reader.GetOrdinal("cd_modelocte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_exigirrequisicao")))
                        reg.St_exigirrequisicao = reader.GetString(reader.GetOrdinal("st_exigirrequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_concentrador")))
                        reg.Tp_concentrador = reader.GetString(reader.GetOrdinal("tp_concentrador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_comunicacao")))
                        reg.Porta_comunicacao = reader.GetDecimal(reader.GetOrdinal("porta_comunicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("endereco_bico")))
                        reg.Endereco_bico = reader.GetString(reader.GetOrdinal("endereco_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_abastecimento")))
                        reg.Tmp_abastecimento = reader.GetDecimal(reader.GetOrdinal("tmp_abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_abastonline")))
                        reg.Tmp_abastonline = reader.GetDecimal(reader.GetOrdinal("tmp_abastonline"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_fatordivisao")))
                        reg.Vl_fatordivisao = reader.GetDecimal(reader.GetOrdinal("vl_fatordivisao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_km_obrigatorio")))
                        reg.St_km_obrigatorio = reader.GetString(reader.GetOrdinal("st_km_obrigatorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("path_schemas")))
                        reg.Path_schemas = reader.GetString(reader.GetOrdinal("path_schemas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_seriecertificado")))
                        reg.Nr_seriecertificado = reader.GetString(reader.GetOrdinal("nr_seriecertificado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambientecont")))
                        reg.Tp_ambientecont = reader.GetString(reader.GetOrdinal("tp_ambientecont"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaolayout")))
                        reg.Cd_versaolayout = reader.GetString(reader.GetOrdinal("cd_versaolayout"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaomodalrod")))
                        reg.Cd_versaomodalrod = reader.GetString(reader.GetOrdinal("cd_versaomodalrod"));
                    if (!reader.IsDBNull(reader.GetOrdinal("rntrc")))
                        reg.RNTRC = reader.GetString(reader.GetOrdinal("rntrc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movanulacao")))
                        reg.Cd_movanulacao = reader.GetDecimal(reader.GetOrdinal("cd_movanulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movanulacao")))
                        reg.Ds_movanulacao = reader.GetString(reader.GetOrdinal("ds_movanulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cmianulacao")))
                        reg.Cd_cmianulacao = reader.GetDecimal(reader.GetOrdinal("cd_cmianulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cmianulacao")))
                        reg.Ds_cmianulacao = reader.GetString(reader.GetOrdinal("ds_cmianulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movcteuf")))
                        reg.Cd_movcteuf = reader.GetDecimal(reader.GetOrdinal("cd_movcteuf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movcteuf")))
                        reg.Ds_movcteuf = reader.GetString(reader.GetOrdinal("ds_movcteuf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_impaprox")))
                        reg.Pc_impAprox = reader.GetDecimal(reader.GetOrdinal("pc_impaprox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_tomadordef")))
                        reg.Tp_tomadordef = reader.GetString(reader.GetOrdinal("tp_tomadordef"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condusocce")))
                        reg.Ds_condusoCCe = reader.GetString(reader.GetOrdinal("ds_condusocce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitfrete")))
                        reg.Vl_unitfrete = reader.GetDecimal(reader.GetOrdinal("vl_unitfrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_unidfrete")))
                        reg.Tp_unidfrete = reader.GetString(reader.GetOrdinal("tp_unidfrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("outrascaraccarga")))
                        reg.OutrasCaracCarga = reader.GetString(reader.GetOrdinal("outrascaraccarga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_subimpbasecalccom")))
                        reg.St_subimpbasecalccom = reader.GetString(reader.GetOrdinal("st_subimpbasecalccom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_RecApuracao")))
                        reg.Tp_recapuracao = reader.GetString(reader.GetOrdinal("TP_RecApuracao"));

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

        public string Gravar(TRegistro_CfgFrota val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(39);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_COMBUSTIVEL", val.Cd_combustivel);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ID_DESPESACOMBUSTIVEL", val.Id_despesacombustivel);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_HISTORICODESP", val.Cd_historicoDesp);
            hs.Add("@P_CD_TERMINAL", val.Cd_terminal);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_MOVCTE", val.Cd_movcte);
            hs.Add("@P_NR_SERIECTE", val.Nr_seriecte);
            hs.Add("@P_CD_MODELOCTE", val.Cd_modelocte);
            hs.Add("@P_CD_MOVANULACAO", val.Cd_movanulacao);
            hs.Add("@P_CD_CMIANULACAO", val.Cd_cmianulacao);
            hs.Add("@P_CD_MOVCTEUF", val.Cd_movcteuf);
            hs.Add("@P_ST_EXIGIRREQUISICAO", val.St_exigirrequisicao);
            hs.Add("@P_TP_CONCENTRADOR", val.Tp_concentrador);
            hs.Add("@P_PORTA_COMUNICACAO", val.Porta_comunicacao);
            hs.Add("@P_ENDERECO_BICO", val.Endereco_bico);
            hs.Add("@P_TMP_ABASTECIMENTO", val.Tmp_abastecimento);
            hs.Add("@P_TMP_ABASTONLINE", val.Tmp_abastonline);
            hs.Add("@P_VL_FATORDIVISAO", val.Vl_fatordivisao);
            hs.Add("@P_ST_KM_OBRIGATORIO", val.St_km_obrigatorio);
            hs.Add("@P_PATH_SCHEMAS", val.Path_schemas);
            hs.Add("@P_NR_SERIECERTIFICADO", val.Nr_seriecertificado);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_TP_AMBIENTECONT", val.Tp_ambientecont);
            hs.Add("@P_CD_VERSAOLAYOUT", val.Cd_versaolayout);
            hs.Add("@P_CD_VERSAOMODALROD", val.Cd_versaomodalrod);
            hs.Add("@P_RNTRC", val.RNTRC);
            hs.Add("@P_PC_IMPAPROX", val.Pc_impAprox);
            hs.Add("@P_TP_TOMADORDEF", val.Tp_tomadordef);
            hs.Add("@P_DS_CONDUSOCCE", val.Ds_condusoCCe);
            hs.Add("@P_VL_UNITFRETE", val.Vl_unitfrete);
            hs.Add("@P_TP_UNIDFRETE", val.Tp_unidfrete);
            hs.Add("@P_OUTRASCARACCARGA", val.OutrasCaracCarga);
            hs.Add("@P_ST_SUBIMPBASECALCCOM", val.St_subimpbasecalccom);
            hs.Add("@P_TP_RECAPURACAO", val.Tp_recapuracao);

            return executarProc("IA_FRT_CFGFROTA", hs);
        }

        public string Excluir(TRegistro_CfgFrota val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FRT_CFGFROTA", hs);
        }
    }
}
