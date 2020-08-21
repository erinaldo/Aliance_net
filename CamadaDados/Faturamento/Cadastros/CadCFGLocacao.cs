using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    #region CFG_Locacao
    public class TList_CFGLocacao : List<TRegistro_CFGLocacao>, IComparer<TRegistro_CFGLocacao>
    {
        #region IComparer<TRegistro_CFGLocacao> Members
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

        public TList_CFGLocacao()
        { }

        public TList_CFGLocacao(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGLocacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGLocacao x, TRegistro_CFGLocacao
 y)
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

    
    public class TRegistro_CFGLocacao
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_tabelapreco
        { get; set; }
        
        public string Ds_tabelapreco
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public decimal Qtd_diasdevolucao
        { get; set; }
        
        public decimal Pc_multa
        { get; set; }
        
        public string Tp_multa
        { get; set; }
        public string Status
        {
            get
            {
                if (Tp_multa.Trim().ToUpper().Equals("D"))
                    return "DIARIA";
                else if (Tp_multa.Trim().ToUpper().Equals("F"))
                    return "FIXA";
                else return string.Empty;
            }
        }

        public TRegistro_CFGLocacao()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Qtd_diasdevolucao = decimal.Zero;
            this.Pc_multa = decimal.Zero;
            this.Tp_multa = string.Empty;
        }
    }

    public class TCD_CFGLocacao : TDataQuery
    {
        public TCD_CFGLocacao()
        { }

        public TCD_CFGLocacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, u.sigla_unidade, ");
                sql.AppendLine("c.nm_empresa, a.cd_tabelapreco, b.ds_tabelapreco, a.cd_produto, d.ds_produto, ");
                sql.AppendLine("a.cd_local, g.ds_local, a.qtd_diasdevolucao, a.pc_multa, a.Tp_multa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from tb_fat_cfglocacao a ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("left outer join tb_div_tabelapreco b ");
            sql.AppendLine("on a.cd_tabelapreco = b.cd_tabelapreco ");
            sql.AppendLine("inner join tb_est_produto d ");
            sql.AppendLine("on a.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade u ");
            sql.AppendLine("on d.cd_unidade = u.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm g ");
            sql.AppendLine("on a.cd_local = g.cd_local ");


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

        public TList_CFGLocacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CFGLocacao lista = new TList_CFGLocacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGLocacao reg = new TRegistro_CFGLocacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_diasdevolucao")))
                        reg.Qtd_diasdevolucao = reader.GetDecimal(reader.GetOrdinal("qtd_diasdevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_multa")))
                        reg.Pc_multa = reader.GetDecimal(reader.GetOrdinal("pc_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_multa")))
                        reg.Tp_multa = reader.GetString(reader.GetOrdinal("tp_multa"));

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

        public string Gravar(TRegistro_CFGLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QTD_DIASDEVOLUCAO", val.Qtd_diasdevolucao);
            hs.Add("@P_PC_MULTA", val.Pc_multa);
            hs.Add("@P_TP_MULTA", val.Tp_multa);

            return this.executarProc("IA_FAT_CFGLOCACAO", hs);
        }

        public string Excluir(TRegistro_CFGLocacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_CFGLOCACAO", hs);
        }



    }

    #endregion
}   
