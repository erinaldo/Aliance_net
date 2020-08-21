using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    #region Devolucao
    public class TList_Devolucao : List<TRegistro_Devolucao>, IComparer<TRegistro_Devolucao>
    {
        #region IComparer<TRegistro_Devolucao> Members
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

        public TList_Devolucao()
        { }

        public TList_Devolucao(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Devolucao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Devolucao x, TRegistro_Devolucao y)
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
    
    public class TRegistro_Devolucao
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_devolucao;
        public decimal? Id_devolucao
        {
            get { return id_devolucao; }
            set
            {
                id_devolucao = value;
                id_devolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devolucaostr;
        public string Id_devolucaostr
        {
            get { return id_devolucaostr; }
            set
            {
                id_devolucaostr = value;
                try
                {
                    id_devolucao = decimal.Parse(value);
                }
                catch
                { id_devolucao = null; }
            }
        }
        private decimal? id_adto;
        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;
        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        public decimal Vl_adto
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
        private DateTime? dt_devolucao;
        public DateTime? Dt_devolucao
        {
            get { return dt_devolucao; }
            set
            {
                dt_devolucao = value;
                dt_devolucaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_devolucaostr;
        public string Dt_devolucaostr
        {
            get { return dt_devolucaostr; }
            set
            {
                dt_devolucaostr = value;
                try
                {
                    dt_devolucao = DateTime.Parse(value);
                }
                catch
                { dt_devolucao = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public TList_VendaRapida_Item lItens
        { get; set; }
        public TList_ItensDevolvidos lItensDev
        { get; set; }
        public Financeiro.Adiantamento.TList_LanAdiantamento lAdto
        { get; set; }
        public TList_DevolucaoFIN lDevFin
        { get; set; }

        public TRegistro_Devolucao()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_devolucao = null;
            id_devolucaostr = string.Empty;
            id_adto = null;
            id_adtostr = string.Empty;
            Vl_adto = decimal.Zero;
            dt_devolucao = DateTime.Now;
            dt_devolucaostr = DateTime.Now.ToString("dd/MM/yyyy");
            Ds_observacao = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            lItens = new TList_VendaRapida_Item();
            lItensDev = new TList_ItensDevolvidos();
            lAdto = new Financeiro.Adiantamento.TList_LanAdiantamento();
            lDevFin = new TList_DevolucaoFIN();
        }
    }

    public class TCD_Devolucao : TDataQuery
    {
        public TCD_Devolucao()
        { }

        public TCD_Devolucao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("d.nm_clifor, a.id_devolucao, a.id_adto, c.vl_adto, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa, a.dt_devolucao, a.ds_observacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_pdv_devolucao a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_Adiantamento c ");
            sql.AppendLine("on a.id_adto = c.id_adto ");
            sql.AppendLine("left outer join tb_fin_clifor d ");
            sql.AppendLine("on c.cd_clifor = d.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_Devolucao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo, string vOrder)
        {
            TList_Devolucao lista = new TList_Devolucao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_Devolucao reg = new TRegistro_Devolucao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("id_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_adto")))
                        reg.Vl_adto = reader.GetDecimal(reader.GetOrdinal("vl_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_devolucao")))
                        reg.Dt_devolucao = reader.GetDateTime(reader.GetOrdinal("dt_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
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

        public string Gravar(TRegistro_Devolucao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_DT_DEVOLUCAO", val.Dt_devolucao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_PDV_DEVOLUCAO", hs);
        }

        public string Excluir(TRegistro_Devolucao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);

            return executarProc("EXCLUI_PDV_DEVOLUCAO", hs);
        }
    }
    #endregion

    #region Itens Devolvidos
    public class TList_ItensDevolvidos : List<TRegistro_ItensDevolvidos>
    { }

    
    public class TRegistro_ItensDevolvidos
    {
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_devolucao;
        public decimal? Id_devolucao
        {
            get { return id_devolucao; }
            set
            {
                id_devolucao = value;
                id_devolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devolucaostr;
        public string Id_devolucaostr
        {
            get { return id_devolucaostr; }
            set
            {
                id_devolucaostr = value;
                try
                {
                    id_devolucao = decimal.Parse(value);
                }
                catch
                { id_devolucao = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch
                { id_cupom = null; }
            }
        }
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch
                { id_lancto = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_acrescimo
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public decimal Vl_juro_fin
        { get; set; }
        public decimal Vl_SubTotalLiquido
        { get { return Math.Round((Qtd_devolvida * Vl_unitario) + Vl_acrescimo + Vl_frete + Vl_juro_fin - Vl_desconto, 2); } }
        private decimal? id_lanctoestoque;
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }
        public Estoque.Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Estoque.Cadastros.TList_ValorCaracteristica();
        public string DesGrade
        {
            get
            {
                string s = "";
                lGrade.ForEach(x => s += x.Valor + ": " + x.Vl_mov.ToString() + " | ");
                return s;
            }
        }

        public TRegistro_ItensDevolvidos()
        {
            Cd_empresa = string.Empty;
            id_devolucao = null;
            id_devolucaostr = string.Empty;
            id_cupom = null;
            id_cupomstr = string.Empty;
            id_lancto = null;
            id_lanctostr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Qtd_devolvida = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_acrescimo = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_frete = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
            id_lanctoestoque = null;
            id_lanctoestoquestr = string.Empty;
        }
    }

    public class TCD_ItensDevolvidos : TDataQuery
    {
        public TCD_ItensDevolvidos()
        { }

        public TCD_ItensDevolvidos(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_devolucao, ");
                sql.AppendLine("a.id_cupom, a.id_lancto, a.cd_produto, a.id_lanctoestoque, ");
                sql.AppendLine("b.ds_produto, c.sigla_unidade, d.qtd_entrada, e.Vl_unitario, ");
                sql.AppendLine("((isnull(e.Vl_Desconto, 0) / isnull(e.Quantidade, 0)) * isnull(d.QTD_Entrada,0)) as Vl_desconto, ");
                sql.AppendLine("((isnull(e.Vl_Acrescimo, 0) / isnull(e.Quantidade, 0)) * isnull(d.QTD_Entrada,0)) as Vl_acrescimo, ");
                sql.AppendLine("((isnull(e.VL_FRETE, 0) / isnull(e.Quantidade, 0)) * isnull(d.QTD_Entrada,0)) as Vl_frete, ");
                sql.AppendLine("((isnull(e.Vl_Juro_Fin, 0) / isnull(e.Quantidade, 0)) * isnull(d.QTD_Entrada,0)) as Vl_juro_fin ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_pdv_itensdevolvidos a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join tb_est_estoque d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.cd_produto = d.cd_produto ");
            sql.AppendLine("and a.id_lanctoestoque = d.id_lanctoestoque ");
            sql.AppendLine("inner join TB_PDV_VendaRapida_Item e ");
            sql.AppendLine("on a.CD_Empresa = e.CD_Empresa ");
            sql.AppendLine("and a.Id_Cupom = e.Id_VendaRapida ");
            sql.AppendLine("and a.Id_lancto = e.Id_lanctoVenda ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_ItensDevolvidos Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensDevolvidos lista = new TList_ItensDevolvidos();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensDevolvidos reg = new TRegistro_ItensDevolvidos();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("id_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entrada")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("qtd_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_acrescimo")))
                        reg.Vl_acrescimo = reader.GetDecimal(reader.GetOrdinal("Vl_acrescimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_juro_fin")))
                        reg.Vl_juro_fin = reader.GetDecimal(reader.GetOrdinal("Vl_juro_fin"));

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

        public string Gravar(TRegistro_ItensDevolvidos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("IA_PDV_ITENSDEVOLVIDOS", hs);
        }

        public string Excluir(TRegistro_ItensDevolvidos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("EXCLUI_PDV_ITENSDEVOLVIDOS", hs);
        }
    }
    #endregion
}
