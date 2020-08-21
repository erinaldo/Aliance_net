using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.CCustoLan
{
    public class TList_LanCCustoLancto : List<TRegistro_LanCCustoLancto>, IComparer<TRegistro_LanCCustoLancto>
    {
        #region IComparer<TRegistro_LanCCustoLancto> Members
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

        public TList_LanCCustoLancto()
        { }

        public TList_LanCCustoLancto(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanCCustoLancto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanCCustoLancto x, TRegistro_LanCCustoLancto y)
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
    
    public class TRegistro_LanCCustoLancto
    {
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch
                { id_ccustolan = null; }
            }
        }
        public string Cd_centroresult
        { get; set; }
        public string Ds_centroresultado
        { get; set; }
        private decimal? nr_orcamento;
        public decimal? Nr_orcamento
        {
            get { return nr_orcamento; }
            set
            {
                nr_orcamento = value;
                nr_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_orcamentostr;
        public string Nr_orcamentostr
        {
            get { return nr_orcamentostr; }
            set
            {
                nr_orcamentostr = value;
                try
                {
                    nr_orcamento = decimal.Parse(value);
                }
                catch { nr_orcamento = null; }
            }
        }
        public decimal Vl_lancto
        {
            get;
            set;
        }
        public decimal Pc_lancto
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Tipo_movimento
        {
            get
            {
                if (Tp_movimento.Trim().ToUpper().Equals("D"))
                    return "DESPESA";
                else if (Tp_movimento.Trim().ToUpper().Equals("R"))
                    return "RECEITA";
                else
                    return string.Empty;
            }
        }
        public string st_deducao
        { get; set; }
        public bool St_deducaobool
        { get { return st_deducao.Trim().ToUpper().Equals("S"); } }
        public string Cd_ccustoalt
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal? Nr_lancto
        { get; set; }
        public string Nr_docto
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_contager
        { get; set; }
        public decimal? Cd_lanctocaixa
        { get; set; }
        public decimal? Id_cupom
        { get; set; }
        public decimal? Id_emprestimo
        { get; set; }
        public decimal? Id_adto
        { get; set; }
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
        public string PathCentroresult
        { get; set; }
        public string Ds_observacao
        { get; set; }

        public TRegistro_LanCCustoLancto()
        {
            id_ccustolan = null;
            id_ccustolanstr = string.Empty;
            Cd_centroresult = string.Empty;
            Ds_centroresultado = string.Empty;
            nr_orcamento = null;
            nr_orcamentostr = string.Empty;
            Vl_lancto = decimal.Zero;
            Pc_lancto = decimal.Zero;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Tp_movimento = string.Empty;
            Cd_ccustoalt = string.Empty;
            Dt_lancto = null;
            dt_lanctostr = string.Empty;
            Nr_lancto = null;
            Nr_docto = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_contager = string.Empty;
            Cd_lanctocaixa = null;
            Id_cupom = null;
            Id_emprestimo = null;
            Id_adto = null;
            tp_registro = "A";
            tipo_registro = "AUTOMATICO";
            PathCentroresult = string.Empty;
            Ds_observacao = string.Empty;
        }
    }

    public class TCD_LanCCustoLancto : TDataQuery
    {
        public TCD_LanCCustoLancto()
        { }

        public TCD_LanCCustoLancto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanCCustoLancto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanCCustoLancto lista = new TList_LanCCustoLancto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanCCustoLancto reg = new TRegistro_LanCCustoLancto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_CCustoLan"))))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("Id_CCustoLan"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CentroResult"))))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("CD_CentroResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CentroResultado"))))
                        reg.Ds_centroresultado = reader.GetString(reader.GetOrdinal("DS_CentroResultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_orcamento")))
                        reg.Nr_orcamento = reader.GetDecimal(reader.GetOrdinal("nr_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_deducao")))
                        reg.st_deducao = reader.GetString(reader.GetOrdinal("st_deducao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Lancto"))))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docto")))
                        reg.Nr_docto = reader.GetString(reader.GetOrdinal("nr_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_emprestimo")))
                        reg.Id_emprestimo = reader.GetDecimal(reader.GetOrdinal("id_emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PathCentroresult")))
                        reg.PathCentroresult = reader.GetString(reader.GetOrdinal("PathCentroresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));

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

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_ccustolan, a.cd_centroresult, a.dt_lancto, a.tp_registro, a.ds_observacao, a.nr_orcamento, ");
                sql.AppendLine("a.vl_lancto, b.ds_centroresultado, a.cd_empresa, emp.nm_empresa, b.tp_registro as tp_movimento, isnull(b.st_deducao, 'N') as st_deducao, ");
                sql.AppendLine("ISNULL(ISNULL(dup.nr_docto, caixa.Nr_Docto), 'VG-' + convert(varchar(10), i.id_viagem)) as Nr_docto, ISNULL(ISNULL(dup.CD_Clifor, venda.CD_Clifor), i.CD_Funcionario) as CD_Clifor, ");
                //Buscar NM_clifor
                sql.AppendLine("case when ISNULL(ISNULL(cf.NM_Clifor, cv.NM_Clifor), j.NM_Clifor) is not null then ");
                sql.AppendLine("          ISNULL(ISNULL(cf.NM_Clifor, cv.NM_Clifor), j.NM_Clifor) else caixa.Nm_clifor end as NM_Clifor, ");
                //Buscar Nr_lancto
                sql.AppendLine("case when c.Nr_Lancto is not null ");
                sql.AppendLine("then c.nr_lancto else ");
                sql.AppendLine("isnull((select TOP 1 x.nr_lancto from TB_FIN_Liquidacao x ");
                sql.AppendLine("        where x.cd_lanctocaixa_juro = d.cd_lanctocaixa ");
                sql.AppendLine("        and x.cd_contager = d.cd_contager), null) end as Nr_lancto, ");

                sql.AppendLine("d.CD_ContaGer, d.CD_LanctoCaixa, e.Id_Cupom, f.ID_Emprestimo, g.Id_Adto, ");
                sql.AppendLine("dbo.F_PATHCENTRORESULT(a.cd_centroresult) as PathCentroresult ");
            }
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_ccustolancto a");
            sql.AppendLine("inner join tb_fin_centroresultado b ");
            sql.AppendLine("on a.cd_centroresult = b.cd_centroresult ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Duplicata_X_CCusto c ");
            sql.AppendLine("on a.Id_CCustoLan = c.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_FIN_Duplicata dup ");
            sql.AppendLine("on c.cd_empresa = dup.cd_empresa ");
            sql.AppendLine("and c.nr_lancto = dup.nr_lancto ");
            sql.AppendLine("left outer join TB_FIN_Clifor cf ");
            sql.AppendLine("on dup.CD_Clifor = cf.CD_Clifor ");
            sql.AppendLine("left outer join TB_FIN_Caixa_X_CCusto d ");
            sql.AppendLine("on a.Id_CCustoLan = d.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_FIN_Caixa caixa ");
            sql.AppendLine("on d.cd_lanctocaixa = caixa.cd_lanctocaixa ");
            sql.AppendLine("and d.cd_contager = caixa.cd_contager ");
            sql.AppendLine("left outer join TB_FIN_Cupom_X_CCusto e ");
            sql.AppendLine("on a.Id_CCustoLan = e.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_PDV_VendaRapida venda ");
            sql.AppendLine("on e.cd_empresa = venda.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor cv ");
            sql.AppendLine("on venda.CD_Clifor = cv.CD_Clifor ");
            sql.AppendLine("left outer join TB_FIN_Emprestimos_X_CCusto f ");
            sql.AppendLine("on a.Id_CCustoLan = f.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_FIN_Adiantamento_X_CCusto g ");
            sql.AppendLine("on a.Id_CCustoLan = g.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_FIN_Viagem_X_CCusto h ");
            sql.AppendLine("on a.Id_CCustoLan = h.Id_CCustoLan ");
            sql.AppendLine("left outer join TB_FIN_Viagem i ");
            sql.AppendLine("on h.CD_Empresa = i.CD_Empresa ");
            sql.AppendLine("and h.ID_Viagem = i.ID_Viagem ");
            sql.AppendLine("left outer join TB_FIN_Clifor j ");
            sql.AppendLine("on i.CD_Funcionario = j.CD_Clifor ");
            
            string cond = " where ";
            
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            
            return sql.ToString();
        }

        public string Gravar(TRegistro_LanCCustoLancto val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_CCUSTO", val.Id_ccustolan);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_NR_ORCAMENTO", val.Nr_orcamento);
            hs.Add("@P_VL_LANCTO", val.Vl_lancto);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_FIN_CCUSTOLANCTO", hs);
        }

        public string Excluir(TRegistro_LanCCustoLancto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CCUSTO", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_CCUSTOLANCTO", hs);
        }
    }
}
