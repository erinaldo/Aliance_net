using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Producao.Producao
{
    public class TList_FormulaApontamento : List<TRegistro_FormulaApontamento>, IComparer<TRegistro_FormulaApontamento>
    {
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

        public TList_FormulaApontamento()
        { }

        public TList_FormulaApontamento(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FormulaApontamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FormulaApontamento x, TRegistro_FormulaApontamento y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }

    public class TRegistro_FormulaApontamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_formulacao;
        public decimal? Id_formulacao
        {
            get { return id_formulacao; }
            set
            {
                id_formulacao = value;
                id_formulacaostr = value.Value.ToString();
            }
        }
        private string id_formulacaostr;
        public string Id_formulacaostr
        {
            get { return id_formulacaostr; }
            set
            {
                id_formulacaostr = value;
                try
                {
                    id_formulacao = Convert.ToDecimal(value);
                }
                catch
                { id_formulacao = null; }
            }
        }
        public string Ds_observacoes
        { get; set; }
        
        public string Ds_indicacao
        { get; set; }
        public string Ds_formula
        { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Cd_unidProduto { get; set; }
        public string Ds_unidProduto { get; set; }
        public string Sg_unidProduto { get; set; }
        public string Cd_unidade { get; set; }
        public string Ds_unidade { get; set; }
        public string Sigla_unidade { get; set; }
        public string Cd_local { get; set; }
        public string Ds_local { get; set; }
        public decimal Qt_produto { get; set; }
        public bool St_decomposicao { get; set; }
        public int DiasProduzir { get; set; }
        //Lista Custo Fixo Direto
        public TList_CustoFixo_Direto LCustoFixo
        { get; set; }
        public TList_CustoFixo_Direto LCustoFixoDel
        { get; set; }
        //Lista Ficha Tecnica MPrima
        public TList_FichaTec_MPrima LFichaTec_MPrima
        { get; set; }
        public TList_FichaTec_MPrima LFichaTec_MPrimaDel
        { get; set; }

        public TRegistro_FormulaApontamento()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_formulacao = null;
            id_formulacaostr = string.Empty;
            Ds_observacoes = string.Empty;
            Ds_indicacao = string.Empty;
            Ds_formula = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidProduto = string.Empty;
            Ds_unidProduto = string.Empty;
            Sg_unidProduto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Qt_produto = decimal.Zero;
            St_decomposicao = false;
            LCustoFixo = new TList_CustoFixo_Direto();
            LCustoFixoDel = new TList_CustoFixo_Direto();
            LFichaTec_MPrima = new TList_FichaTec_MPrima();
            LFichaTec_MPrimaDel = new TList_FichaTec_MPrima();
        }
    }

    public class TCD_FormulaApontamento : TDataQuery
    {
        public TCD_FormulaApontamento()
        { }

        public TCD_FormulaApontamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_formulacao, a.ds_observacoes, ");
                sql.AppendLine("a.ds_indicacao, a.ds_formula, ");
                sql.AppendLine("a.cd_produto, c.ds_produto, d.cd_unidade as cd_unidproduto, ");
                sql.AppendLine("d.ds_unidade as ds_unidproduto, d.sigla_unidade as sg_unidproduto, ");
                sql.AppendLine("a.cd_unidade, e.ds_unidade, e.sigla_unidade, ");
                sql.AppendLine("a.cd_local, g.ds_local, a.qt_produto, a.DiasProduzir ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_formula_apontamento a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_est_unidade e ");
            sql.AppendLine("on a.cd_unidade = e.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm g ");
            sql.AppendLine("on a.cd_local = g.cd_local ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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

        public TList_FormulaApontamento Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_FormulaApontamento lista = new TList_FormulaApontamento();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FormulaApontamento reg = new TRegistro_FormulaApontamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("ID_Formulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacoes")))
                        reg.Ds_observacoes = reader.GetString(reader.GetOrdinal("DS_Observacoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Indicacao")))
                        reg.Ds_indicacao = reader.GetString(reader.GetOrdinal("DS_Indicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Formula")))
                        reg.Ds_formula = reader.GetString(reader.GetOrdinal("DS_Formula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidproduto")))
                        reg.Cd_unidProduto = reader.GetString(reader.GetOrdinal("cd_unidproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidproduto")))
                        reg.Ds_unidProduto = reader.GetString(reader.GetOrdinal("ds_unidproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_unidproduto")))
                        reg.Sg_unidProduto = reader.GetString(reader.GetOrdinal("sg_unidproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_produto")))
                        reg.Qt_produto = reader.GetDecimal(reader.GetOrdinal("qt_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DiasProduzir")))
                        reg.DiasProduzir = reader.GetInt32(reader.GetOrdinal("DiasProduzir"));

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

        public string Gravar(TRegistro_FormulaApontamento val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_DS_OBSERVACOES", val.Ds_observacoes);
            hs.Add("@P_DS_INDICACAO", val.Ds_indicacao);
            hs.Add("@P_DS_FORMULA", val.Ds_formula);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QT_PRODUTO", val.Qt_produto);
            hs.Add("@P_DIASPRODUZIR", val.DiasProduzir);

            return executarProc("IA_PRD_FORMULA_APONTAMENTO", hs);
        }

        public string Excluir(TRegistro_FormulaApontamento val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);

            return executarProc("EXCLUI_PRD_FORMULA_APONTAMENTO", hs);
        }
    }
}
