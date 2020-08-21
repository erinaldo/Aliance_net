using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGAdiantamento : List<TRegistro_CTB_CFGAdiantamento>, IComparer<TRegistro_CTB_CFGAdiantamento>
    {
        #region IComparer<TRegistro_CTB_CFGAdiantamento> Members
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

        public TList_CTB_CFGAdiantamento()
        { }

        public TList_CTB_CFGAdiantamento(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGAdiantamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGAdiantamento x, TRegistro_CTB_CFGAdiantamento y)
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

    public class TRegistro_CTB_CFGAdiantamento
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
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value == null)
                    tipo_movimento = string.Empty;
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_movimento = "CONCEDIDO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBIDO";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value == null)
                    tp_movimento = string.Empty;
                else if (value.Trim().ToUpper().Equals("CONCEDIDO"))
                    tp_movimento = "C";
                else if (value.Trim().ToUpper().Equals("RECEBIDO"))
                    tp_movimento = "R";
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
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

        public TRegistro_CTB_CFGAdiantamento()
        {
            this.id_cfgctb = null;
            this.id_cfgctbstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_historico = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.tp_movimento = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.cd_conta_ctb_deb = null;
            this.cd_conta_ctb_debstr = string.Empty;
            this.Ds_conta_ctb_deb = string.Empty;
            this.Cd_classificacao_deb = string.Empty;
            this.cd_conta_ctb_cred = null;
            this.cd_conta_ctb_credstr = string.Empty;
            this.Ds_conta_ctb_cred = string.Empty;
            this.Cd_classificacao_cred = string.Empty;
        }
    }

    public class TCD_CTB_CFGAdiantamento : TDataQuery
    {
        public TCD_CTB_CFGAdiantamento() { }

        public TCD_CTB_CFGAdiantamento(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop);
                sql.AppendLine("a.id_CFGCTB, a.CD_CONTA_CTB_DEB, b.DS_ContaCTB as DS_Conta_CTB_DEB, ");
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, a.cd_empresa, d.nm_empresa, ");
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED,  ");
                sql.AppendLine("a.cd_historico, e.ds_historico, a.TP_Movimento, a.cd_clifor, f.nm_clifor, ");
                sql.AppendLine("a.cd_contager, g.ds_contager ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Adiantamento a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on d.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Historico e ");
            sql.AppendLine("on e.cd_historico = a.cd_historico ");
            sql.AppendLine("inner join TB_FIN_ContaGer g ");
            sql.AppendLine("on a.cd_contager = g.cd_contager ");
            sql.AppendLine("left outer join TB_FIN_Clifor f ");
            sql.AppendLine("on a.cd_clifor = f.cd_clifor ");

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

        public TList_CTB_CFGAdiantamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGAdiantamento lista = new TList_CTB_CFGAdiantamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGAdiantamento reg = new TRegistro_CTB_CFGAdiantamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CFGCTB")))
                        reg.Id_cfgctb = reader.GetDecimal(reader.GetOrdinal("ID_CFGCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_DEB")))
                        reg.Cd_conta_ctb_deb = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_CRED")))
                        reg.Cd_conta_ctb_cred = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_DEB")))
                        reg.Ds_conta_ctb_deb = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_CRED")))
                        reg.Ds_conta_ctb_cred = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));

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

        public string Gravar(TRegistro_CTB_CFGAdiantamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_CONTA_CTB_DEB", val.Cd_conta_ctb_deb);
            hs.Add("@P_CD_CONTA_CTB_CRED", val.Cd_conta_ctb_cred);

            return this.executarProc("IA_CTB_ADIANTAMENTO", hs);
        }

        public string Excluir(TRegistro_CTB_CFGAdiantamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CFGCTB", val.Id_cfgctb);

            return this.executarProc("EXCLUI_CTB_ADIANTAMENTO", hs);
        }
    }
}
