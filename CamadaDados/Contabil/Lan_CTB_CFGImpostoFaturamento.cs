using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Contabil
{
    public class TList_CFGImpostoFaturamento : List<TRegistro_CFGImpostoFaturamento>, IComparer<TRegistro_CFGImpostoFaturamento>
    {
        #region IComparer<TRegistro_CFGImpostoFaturamento> Members
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

        public TList_CFGImpostoFaturamento()
        { }

        public TList_CFGImpostoFaturamento(System.ComponentModel.PropertyDescriptor Prop,
                                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGImpostoFaturamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGImpostoFaturamento x, TRegistro_CFGImpostoFaturamento y)
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

    
    public class TRegistro_CFGImpostoFaturamento
    {
        private decimal? id_cfgctb;
        public decimal? Id_cfgctb
        {
            get { return id_cfgctb; }
            set
            {
                id_cfgctb = value;
                id_cfgctbstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cfgctbstr;
        public string Id_cfgctbstr
        {
            get { return id_cfgctbstr; }
            set
            {
                id_cfgctbstr = value;
                try
                {
                    id_cfgctb = Convert.ToDecimal(value);
                }
                catch
                { id_cfgctb = null; }
            }
        }
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
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private decimal? cd_conta_ctb_deb;
        public decimal? Cd_conta_ctb_deb
        {
            get { return cd_conta_ctb_deb; }
            set
            {
                cd_conta_ctb_deb = value;
                cd_conta_ctb_debstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_conta_ctb_debstr;
        public string Cd_conta_ctb_debstr
        {
            get { return cd_conta_ctb_debstr; }
            set
            {
                cd_conta_ctb_debstr = value;
                try
                {
                    cd_conta_ctb_deb = Convert.ToDecimal(value);
                }
                catch
                { cd_conta_ctb_deb = null; }
            }
        }
        public string Cd_classificacao_deb
        { get; set; }
        public string Ds_contactb_deb
        { get; set; }
        private decimal? cd_conta_ctb_cred;
        public decimal? Cd_conta_ctb_cred
        {
            get { return cd_conta_ctb_cred; }
            set
            {
                cd_conta_ctb_cred = value;
                cd_conta_ctb_credstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_conta_ctb_credstr;
        public string Cd_conta_ctb_credstr
        {
            get { return cd_conta_ctb_credstr; }
            set
            {
                cd_conta_ctb_credstr = value;
                try
                {
                    cd_conta_ctb_cred = Convert.ToDecimal(value);
                }
                catch
                { cd_conta_ctb_cred = null; }
            }
        }
        public string Cd_classificacao_cred
        { get; set; }
        public string Ds_contactb_cred
        { get; set; }
        
        public TRegistro_CFGImpostoFaturamento()
        {
            this.id_cfgctb = null;
            this.id_cfgctbstr = string.Empty;
            this.cd_movimentacao = null;
            this.cd_movimentacaostr = string.Empty;
            this.Ds_movimentacao = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.cd_conta_ctb_cred = null;
            this.cd_conta_ctb_credstr = string.Empty;
            this.Cd_classificacao_cred = string.Empty;
            this.Ds_contactb_cred = string.Empty;
            this.cd_conta_ctb_deb = null;
            this.cd_conta_ctb_debstr = string.Empty;
            this.Cd_classificacao_deb = string.Empty;
            this.Ds_contactb_deb = string.Empty;
        }
    }

    public class TCD_CFGImpostoFaturamento : TDataQuery
    {
        public TCD_CFGImpostoFaturamento()
        { }

        public TCD_CFGImpostoFaturamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.Id_CFGCTB, a.CD_Movimentacao, ");
                sql.AppendLine("b.DS_Movimentacao, a.CD_Imposto, c.DS_Imposto, ");
                sql.AppendLine("a.CD_Empresa, emp.NM_Empresa, ");
                sql.AppendLine("a.CD_Conta_CTB_CRED, d.DS_ContaCTB as ds_conta_ctb_cred, ");
                sql.AppendLine("d.CD_Classificacao as cd_classificacao_cred, ");
                sql.AppendLine("a.CD_Conta_CTB_DEB, e.DS_ContaCTB as ds_conta_ctb_deb, ");
                sql.AppendLine("e.CD_Classificacao as cd_classificacao_deb, ");
                sql.AppendLine("a.CD_Clifor, f.NM_Clifor, a.CD_Produto, g.DS_Produto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_Imposto_Faturamento a ");
            sql.AppendLine("inner join TB_FIS_Movimentacao b ");
            sql.AppendLine("on a.CD_Movimentacao = b.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_Imposto c ");
            sql.AppendLine("on a.CD_Imposto = c.CD_Imposto ");
            sql.AppendLine("inner join TB_CTB_PlanoContas d ");
            sql.AppendLine("on a.CD_Conta_CTB_CRED = d.CD_Conta_CTB ");
            sql.AppendLine("inner join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_Conta_CTB_DEB = e.CD_Conta_CTB ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.CD_Empresa = emp.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor f ");
            sql.AppendLine("on a.CD_Clifor = f.CD_Clifor ");
            sql.AppendLine("left outer join TB_EST_Produto g ");
            sql.AppendLine("on a.CD_Produto = g.CD_Produto ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CFGImpostoFaturamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGImpostoFaturamento lista = new TList_CFGImpostoFaturamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGImpostoFaturamento reg = new TRegistro_CFGImpostoFaturamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CFGCTB")))
                        reg.Id_cfgctb = reader.GetDecimal(reader.GetOrdinal("ID_CFGCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("DS_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB_CRED")))
                        reg.Cd_conta_ctb_cred = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_conta_ctb_cred")))
                        reg.Ds_contactb_cred = reader.GetString(reader.GetOrdinal("ds_conta_ctb_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_cred")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("cd_classificacao_cred"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB_DEB")))
                        reg.Cd_conta_ctb_deb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_conta_ctb_deb")))
                        reg.Ds_contactb_deb = reader.GetString(reader.GetOrdinal("ds_conta_ctb_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao_deb")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("cd_classificacao_deb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));

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

        public string Gravar(TRegistro_CFGImpostoFaturamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_CONTA_CTB_DEB", val.Cd_conta_ctb_deb);
            hs.Add("@P_CD_CONTA_CTB_CRED", val.Cd_conta_ctb_cred);

            return this.executarProc("IA_CTB_IMPOSTO_FATURAMENTO", hs);
        }

        public string Excluir(TRegistro_CFGImpostoFaturamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);

            return this.executarProc("EXCLUI_CTB_IMPOSTO_FATURAMENTO", hs);
        }
    }
}
