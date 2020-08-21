using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGCompFixacao : List<TRegistro_CTB_CFGCompFixacao>, IComparer<TRegistro_CTB_CFGCompFixacao>
    {
        #region IComparer<TRegistro_CTB_CFGCompFixacao> Members
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

        public TList_CTB_CFGCompFixacao()
        { }

        public TList_CTB_CFGCompFixacao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGCompFixacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGCompFixacao x, TRegistro_CTB_CFGCompFixacao y)
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
    
    public class TRegistro_CTB_CFGCompFixacao
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
                    id_cfgctb = decimal.Parse(value);
                }
                catch { id_cfgctb = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private string tp_registro;
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Trim().ToUpper().Equals("E"))
                        tipo_registro = "ESTORNO";
                    else if (value.Trim().ToUpper().Equals("A"))
                        tipo_registro = "ATUALIZAÇÃO";
                }
            }
        }
        private string tipo_registro;
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Trim().ToUpper().Equals("ESTORNO"))
                        tp_registro = "E";
                    else if (value.Trim().ToUpper().Equals("ATUALIZAÇÃO"))
                        tp_registro = "A";
                }
            }
        }
        private string tp_movimento;

        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (tp_movimento.Trim().ToUpper().Equals("C"))
                        tipo_movimento = "COMPRA";
                    else if (tp_movimento.Trim().ToUpper().Equals("V"))
                        tipo_movimento = "VENDA";
                }
            }
        }
        private string tipo_movimento;

        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Trim().ToUpper().Equals("COMPRA"))
                        tp_movimento = "C";
                    else if (value.Trim().ToUpper().Equals("VENDA"))
                        tp_movimento = "V";
                }
            }
        }

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
                    cd_conta_ctb_deb = decimal.Parse(value);
                }
                catch { cd_conta_ctb_deb = null; }
            }
        }
        public string Ds_conta_ctb_deb
        { get; set; }
        public string Cd_classificacao_deb
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
                    cd_conta_ctb_cred = decimal.Parse(value);
                }
                catch { cd_conta_ctb_cred = null; }
            }
        }
        public string Ds_conta_ctb_cred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }

        public TRegistro_CTB_CFGCompFixacao()
        {
            id_cfgctb = null;
            id_cfgctbstr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            tp_registro = string.Empty;
            tipo_registro = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            cd_conta_ctb_cred = null;
            cd_conta_ctb_credstr = string.Empty;
            Ds_conta_ctb_cred = string.Empty;
            Cd_classificacao_cred = string.Empty;
            cd_conta_ctb_deb = null;
            cd_conta_ctb_debstr = string.Empty;
            Ds_conta_ctb_deb = string.Empty;
            Cd_classificacao_deb = string.Empty;
        }
    }

    public class TCD_CTB_CFGCompFixacao : TDataQuery
    {
        public TCD_CTB_CFGCompFixacao() { }

        public TCD_CTB_CFGCompFixacao(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_CFGCTB, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Produto, g.DS_Produto, a.TP_Registro, a.TP_Movimento, ");
                sql.AppendLine("a.CD_Conta_CTB_CRED, d.DS_ContaCTB as DS_ContaCTB_CRED, ");
                sql.AppendLine("d.CD_Classificacao as CD_Classificacao_CRED, a.CD_Conta_CTB_DEB, ");
                sql.AppendLine("e.DS_ContaCTB as DS_ContaCTB_DEB, e.CD_Classificacao as CD_Classificacao_DEB ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_CompFixacao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_CTB_PlanoContas d ");
            sql.AppendLine("on a.CD_Conta_CTB_CRED = d.CD_Conta_CTB ");
            sql.AppendLine("inner join TB_CTB_PlanoContas e ");
            sql.AppendLine("on a.CD_Conta_CTB_DEB = e.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_EST_Produto g ");
            sql.AppendLine("on a.cd_produto = g.CD_Produto ");

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

        public TList_CTB_CFGCompFixacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGCompFixacao lista = new TList_CTB_CFGCompFixacao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGCompFixacao reg = new TRegistro_CTB_CFGCompFixacao();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CFGCTB")))
                        reg.Id_cfgctb = reader.GetDecimal(reader.GetOrdinal("ID_CFGCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB_CRED")))
                        reg.Cd_conta_ctb_cred = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB_CRED")))
                        reg.Ds_conta_ctb_cred = reader.GetString(reader.GetOrdinal("DS_ContaCTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB_DEB")))
                        reg.Cd_conta_ctb_deb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB_DEB")))
                        reg.Ds_conta_ctb_deb = reader.GetString(reader.GetOrdinal("DS_ContaCTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
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

        public string Gravar(TRegistro_CTB_CFGCompFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_CD_CONTA_CTB_DEB", val.Cd_conta_ctb_deb);
            hs.Add("@P_CD_CONTA_CTB_CRED", val.Cd_conta_ctb_cred);

            return executarProc("IA_CTB_COMPFIXACAO", hs);
        }

        public string Excluir(TRegistro_CTB_CFGCompFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);

            return executarProc("EXCLUI_CTB_COMPFIXACAO", hs);
        }
    }
}
