using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_FichaTec_MPrima : List<TRegistro_FichaTec_MPrima>, IComparer<TRegistro_FichaTec_MPrima>
    {
        #region IComparer<TRegistro_FichaTec_MPrima> Members
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

        public TList_FichaTec_MPrima()
        { }

        public TList_FichaTec_MPrima(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FichaTec_MPrima value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FichaTec_MPrima x, TRegistro_FichaTec_MPrima y)
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

    
    public class TRegistro_FichaTec_MPrima
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Id_formulacao
        { get; set; }
        
        public string Ds_formula
        { get; set; }

        public string Cd_alternativo
        { get; set; }

        public decimal Cd_marca
        { get; set; }

        public string Ds_marca
        { get; set; }

        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unid_produto
        { get; set; }
        
        public string Ds_unid_produto
        { get; set; }
        
        public string Sigla_unid_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        private decimal? id_formulacao_mprima;
        
        public decimal? Id_formulacao_mprima
        {
            get { return id_formulacao_mprima; }
            set
            {
                id_formulacao_mprima = value;
                id_formulacao_mprimastr = value.ToString();
            }
        }
        private string id_formulacao_mprimastr;
        
        public string Id_formulacao_mprimastr
        {
            get { return id_formulacao_mprimastr; }
            set
            {
                id_formulacao_mprimastr = value;
                try
                {
                    id_formulacao_mprima = Convert.ToDecimal(value);
                }
                catch
                { id_formulacao_mprima = null; }
            }
        }
        
        public decimal Qtd_produto
        { get; set; }
        
        public decimal Vl_custo
        { get; set; }
        
        public decimal Vl_customedio
        { get; set; }
        
        public decimal Pc_quebra_tec
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        
        public decimal Vl_total
        { get; set; }
        
        public decimal SaldoMPrima
        { get; set; }
        
        public decimal Qtd_unestoque
        { get; set; }
        
        public decimal Qtd_unformula
        { get; set; }
        
        public decimal Vl_complementoEstoqueCTRC
        { get; set; }
        
        public decimal? Id_apontamentomprima
        { get; set; }
        

        public TRegistro_FichaTec_MPrima()
        {
	        Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Id_formulacao = null;
            Ds_formula = string.Empty;
            Cd_alternativo = string.Empty;
            Cd_marca = decimal.Zero;
            Ds_marca = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unid_produto = string.Empty;
            Ds_unid_produto = string.Empty;
            Sigla_unid_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            id_formulacao_mprima = null;
            id_formulacao_mprimastr = string.Empty;
            Qtd_produto = decimal.Zero;
            Vl_custo = decimal.Zero;
            Vl_customedio = decimal.Zero;
            Pc_quebra_tec = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Vl_total = decimal.Zero;
            SaldoMPrima = decimal.Zero;
            Qtd_unestoque = decimal.Zero;
            Qtd_unformula = decimal.Zero;
            Vl_complementoEstoqueCTRC = decimal.Zero;
            Id_apontamentomprima = null;
        }
    }

    public class TCD_FichaTec_MPrima : TDataQuery
    {
        public TCD_FichaTec_MPrima()
        { }

        public TCD_FichaTec_MPrima(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, b.nm_empresa, g.ds_formula, c.Codigo_Alternativo, c.CD_Marca, h.DS_Marca, ");
                sql.AppendLine("a.id_formulacao, a.cd_produto, c.ds_produto, c.cd_unidade as CD_Unid_produto, ");
                sql.AppendLine("d.ds_unidade as ds_unid_produto, d.sigla_unidade as sigla_unid_produto, ");
                sql.AppendLine("a.cd_unidade, e.ds_unidade, e.sigla_unidade, ");
                sql.AppendLine("a.cd_local, f.ds_local, a.id_formulacao_mprima, ");
                sql.AppendLine("a.qtd_produto, a.pc_quebratec, ");
                sql.AppendLine("Vl_Total = dbo.F_Consulta_VL_Estoque(a.cd_produto, a.cd_empresa, dbo.F_Converte_Unid(a.cd_unidade ,c.cd_unidade, a.qtd_produto) ), ");
                sql.AppendLine("VL_Unitario = dbo.F_Consulta_VL_Estoque(a.cd_produto, a.cd_empresa, 1 ), ");
                sql.AppendLine("SaldoMPrima = dbo.F_Converte_Unid(c.cd_unidade, a.cd_unidade , dbo.F_SALDOESTOQUE (a.cd_empresa, a.cd_produto) ), ");
                sql.AppendLine("QTD_UnEstoque = dbo.F_Converte_Unid(a.cd_unidade, c.cd_unidade, a.QTD_Produto), ");
                sql.AppendLine("QTD_UnFormula = dbo.F_Converte_Unid(a.cd_unidade, e.cd_unidade, a.QTD_Produto) ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_fichatec_mprima a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_est_unidade e ");
            sql.AppendLine("on a.cd_unidade = e.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm f ");
            sql.AppendLine("on a.cd_local = f.cd_local ");
            sql.AppendLine("inner join tb_prd_formula_apontamento g ");
            sql.AppendLine("on a.cd_empresa = g.cd_empresa ");
            sql.AppendLine("and a.id_formulacao = g.id_formulacao ");
            sql.AppendLine("left outer join TB_EST_Marca h ");
            sql.AppendLine("on c.CD_Marca = h.CD_Marca ");
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

        public TList_FichaTec_MPrima Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_FichaTec_MPrima lista = new TList_FichaTec_MPrima();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaTec_MPrima reg = new TRegistro_FichaTec_MPrima();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("ID_Formulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Formula")))
                        reg.Ds_formula = reader.GetString(reader.GetOrdinal("DS_Formula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Cd_alternativo = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_marca"))))
                        reg.Cd_marca = reader.GetDecimal(reader.GetOrdinal("cd_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unid_produto")))
                        reg.Cd_unid_produto = reader.GetString(reader.GetOrdinal("CD_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unid_produto")))
                        reg.Ds_unid_produto = reader.GetString(reader.GetOrdinal("DS_Unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unid_produto")))
                        reg.Sigla_unid_produto = reader.GetString(reader.GetOrdinal("Sigla_unid_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Formulacao_MPrima")))
                        reg.Id_formulacao_mprima = reader.GetDecimal(reader.GetOrdinal("ID_Formulacao_MPrima"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_produto")))
                        reg.Qtd_produto = reader.GetDecimal(reader.GetOrdinal("QTD_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Quebratec")))
                        reg.Pc_quebra_tec = reader.GetDecimal(reader.GetOrdinal("PC_Quebratec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Total")))
                        reg.Vl_total = reader.GetDecimal(reader.GetOrdinal("Vl_Total"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoMPrima")))
                        reg.SaldoMPrima = reader.GetDecimal(reader.GetOrdinal("SaldoMPrima"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_UnEstoque")))
                        reg.Qtd_unestoque = reader.GetDecimal(reader.GetOrdinal("Qtd_UnEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_UnFormula")))
                        reg.Qtd_unformula = reader.GetDecimal(reader.GetOrdinal("Qtd_UnFormula"));

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

        public string GravarFichaTec_MPrima(TRegistro_FichaTec_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ID_FORMULACAO_MPRIMA", val.Id_formulacao_mprima);
            hs.Add("@P_QTD_PRODUTO", val.Qtd_produto);
            hs.Add("@P_PC_QUEBRATEC", val.Pc_quebra_tec);

            return executarProc("IA_PRD_FICHATEC_MPRIMA", hs);
        }

        public string DeletarFichaTec_MPrima(TRegistro_FichaTec_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return executarProc("EXCLUI_PRD_FICHATEC_MPRIMA", hs);
        }
    }
}
