using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.ProgEspecialVenda
{
    public class TList_ProgEspecialVenda : List<TRegistro_ProgEspecialVenda>, IComparer<TRegistro_ProgEspecialVenda>
    {

        #region IComparer<TRegistro_ProgEspecialVenda> Members
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

        public TList_ProgEspecialVenda()
        { }

        public TList_ProgEspecialVenda(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProgEspecialVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProgEspecialVenda x, TRegistro_ProgEspecialVenda y)
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
    
    public class TRegistro_ProgEspecialVenda
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_prog;
        public decimal? Id_prog
        {
            get { return id_prog; }
            set
            {
                id_prog = value;
                id_progstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_progstr;
        public string Id_progstr
        {
            get { return id_progstr; }
            set
            {
                id_progstr = value;
                try
                {
                    id_prog = decimal.Parse(value);
                }
                catch { id_prog = null; }
            }
        }
        private decimal? id_categoriaclifor;
        public decimal? Id_categoriaclifor
        {
            get { return id_categoriaclifor; }
            set
            {
                id_categoriaclifor = value;
                id_categoriacliforstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_categoriacliforstr;
        public string Id_categoriacliforstr
        {
            get { return id_categoriacliforstr; }
            set
            {
                id_categoriacliforstr = value;
                try
                {
                    id_categoriaclifor = decimal.Parse(value);
                }
                catch
                { id_categoriaclifor = null; }
            }
        }
        public string Ds_categoriaclifor
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public decimal? Id_tabprecoloc
        { get; set; }
        public string Ds_tabprecoloc
        { get; set; }
        private string tp_preco;
        public string Tp_preco
        {
            get { return tp_preco; }
            set
            {
                tp_preco = value;
                if (value.Trim().ToUpper().Equals("N"))
                    tipo_preco = "NORMAL";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_preco = "CUSTO";
            }
        }
        private string tipo_preco;
        public string Tipo_preco
        {
            get { return tipo_preco; }
            set
            {
                tipo_preco = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_preco = "N";
                else if (value.Trim().ToUpper().Equals("CUSTO"))
                    tp_preco = "C";
            }
        }
        private string tp_acresdesc;
        public string Tp_acresdesc
        {
            get { return tp_acresdesc; }
            set
            {
                tp_acresdesc = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_acresdesc = "ACRESCIMO";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_acresdesc = "DESCONTO";
            }
        }
        private string tipo_acresdesc;
        public string Tipo_acresdesc
        {
            get { return tipo_acresdesc; }
            set
            {
                tipo_acresdesc = value;
                if (value.Trim().ToUpper().Equals("ACRESCIMO"))
                    tp_acresdesc = "A";
                else if (value.Trim().ToUpper().Equals("DESCONTO"))
                    tp_acresdesc = "D";
            }
        }
        private string tp_valor;
        public string Tp_valor
        {
            get { return tp_valor; }
            set
            {
                tp_valor = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_valor = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_valor = "VALOR";
            }
        }
        private string tipo_valor;
        public string Tipo_valor
        {
            get { return tipo_valor; }
            set
            {
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_valor = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_valor = "V";
            }
        }
        public decimal Qtd_minVenda
        { get; set; }
        public decimal Valor
        { get; set; }
        private DateTime? dt_inivigencia;
        public DateTime? Dt_inivigencia
        {
            get { return dt_inivigencia; }
            set
            {
                dt_inivigencia = value;
                dt_inivigenciastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_inivigenciastr;
        public string Dt_inivigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inivigenciastr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_inivigenciastr = value;
                try
                {
                    dt_inivigencia = DateTime.Parse(value);
                }catch { dt_inivigencia = null; }
            }
        }
        private DateTime? dt_finvigencia;
        public DateTime? Dt_finvigencia
        {
            get { return dt_finvigencia; }
            set
            {
                dt_finvigencia = value;
                dt_finvigenciastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_finvigenciastr;
        public string Dt_finvigenciastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finvigenciastr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_finvigenciastr = value;
                try
                {
                    dt_finvigencia = DateTime.Parse(value);
                }catch { dt_finvigencia = null; }
            }
        }
        public DateTime? Dt_atual { get; set; }
        public string Status
        {
            get
            {
                string s = "ATIVO";
                if (dt_inivigencia.HasValue && Dt_atual.HasValue)
                    if (dt_inivigencia.Value.Date > Dt_atual.Value.Date)
                        s = "ATIVAR";
                if (dt_finvigencia.HasValue && Dt_atual.HasValue)
                    if (dt_finvigencia.Value.Date < Dt_atual.Value.Date)
                        s = "EXPIRADO";
                return s;
            }
        }

        public TRegistro_ProgEspecialVenda()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_prog = null;
            id_progstr = string.Empty;
            id_categoriaclifor = null;
            id_categoriacliforstr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Id_tabprecoloc = null;
            Ds_tabprecoloc = string.Empty;
            tp_preco = string.Empty;
            tipo_preco = string.Empty;
            tp_acresdesc = string.Empty;
            tipo_acresdesc = string.Empty;
            tp_valor = string.Empty;
            tipo_valor = string.Empty;
            Qtd_minVenda = decimal.Zero;
            Valor = decimal.Zero;
            dt_inivigencia = null;
            dt_inivigenciastr = string.Empty;
            dt_finvigencia = null;
            dt_finvigenciastr = string.Empty;
        }
    }

    public class TCD_ProgEspecialVenda : TDataQuery
    {
        public TCD_ProgEspecialVenda()
        { }

        public TCD_ProgEspecialVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_prog, ");
                sql.AppendLine("a.id_categoriaclifor, c.ds_categoriaclifor, a.tp_acresdesc, getdate() as DT_Atual, ");
                sql.AppendLine("a.cd_grupo, rtrim(d.ds_grupo) as ds_grupo, a.tp_preco, a.tp_valor, a.Qtd_minVenda, a.valor, ");
                sql.AppendLine("a.cd_clifor, e.nm_clifor, a.cd_produto, f.ds_produto, a.dt_inivigencia, a.dt_finvigencia, ");
                sql.AppendLine("a.cd_tabelapreco, g.ds_tabelapreco, a.Id_tabelaLocacao, h.ds_tabela as Ds_tabelaLocacao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_ProgEspecialVenda a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_CategoriaClifor c ");
            sql.AppendLine("on a.id_categoriaclifor = c.id_categoriaclifor ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto d ");
            sql.AppendLine("on a.cd_grupo = d.cd_grupo ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on a.cd_clifor = e.cd_clifor ");
            sql.AppendLine("left outer join tb_est_produto f ");
            sql.AppendLine("on a.cd_produto = f.cd_produto ");
            sql.AppendLine("left outer join TB_DIV_TabelaPreco g ");
            sql.AppendLine("on a.cd_tabelapreco = g.cd_tabelapreco ");
            sql.AppendLine("left outer join TB_LOC_TabPreco h ");
            sql.AppendLine("on a.Id_tabelaLocacao = h.id_tabela ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_grupo, a.id_categoriaclifor ");

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

        public TList_ProgEspecialVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ProgEspecialVenda lista = new TList_ProgEspecialVenda();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProgEspecialVenda reg = new TRegistro_ProgEspecialVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prog")))
                        reg.Id_prog = reader.GetDecimal(reader.GetOrdinal("id_prog"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_categoriaclifor")))
                        reg.Id_categoriaclifor = reader.GetDecimal(reader.GetOrdinal("id_categoriaclifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_categoriaclifor")))
                        reg.Ds_categoriaclifor = reader.GetString(reader.GetOrdinal("ds_categoriaclifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_preco")))
                        reg.Tp_preco = reader.GetString(reader.GetOrdinal("tp_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_acresdesc")))
                        reg.Tp_acresdesc = reader.GetString(reader.GetOrdinal("tp_acresdesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_valor")))
                        reg.Tp_valor = reader.GetString(reader.GetOrdinal("tp_valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_minVenda")))
                        reg.Qtd_minVenda = reader.GetDecimal(reader.GetOrdinal("Qtd_minVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_tabelaLocacao")))
                        reg.Id_tabprecoloc = reader.GetDecimal(reader.GetOrdinal("Id_tabelaLocacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tabelaLocacao")))
                        reg.Ds_tabprecoloc = reader.GetString(reader.GetOrdinal("Ds_tabelaLocacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_inivigencia")))
                        reg.Dt_inivigencia = reader.GetDateTime(reader.GetOrdinal("dt_inivigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_finvigencia")))
                        reg.Dt_finvigencia = reader.GetDateTime(reader.GetOrdinal("dt_finvigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_atual")))
                        reg.Dt_atual = reader.GetDateTime(reader.GetOrdinal("dt_atual"));

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

        public string Gravar(TRegistro_ProgEspecialVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PROG", val.Id_prog);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_categoriaclifor);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_ID_TABELALOCACAO", val.Id_tabprecoloc);
            hs.Add("@P_TP_PRECO", val.Tp_preco);
            hs.Add("@P_TP_ACRESDESC", val.Tp_acresdesc);
            hs.Add("@P_TP_VALOR", val.Tp_valor);
            hs.Add("@P_QTD_MINVENDA", val.Qtd_minVenda);
            hs.Add("@P_VALOR", val.Valor);
            hs.Add("@P_DT_INIVIGENCIA", val.Dt_inivigencia);
            hs.Add("@P_DT_FINVIGENCIA", val.Dt_finvigencia);

            return executarProc("IA_FAT_PROGESPECIALVENDA", hs);
        }

        public string Excluir(TRegistro_ProgEspecialVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PROG", val.Id_prog);

            return executarProc("EXCLUI_FAT_PROGESPECIALVENDA", hs);
        }
    }
}
