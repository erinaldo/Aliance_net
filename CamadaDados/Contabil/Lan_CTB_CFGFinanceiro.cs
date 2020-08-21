using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGFinanceiro : List<TRegistro_CTB_CFGFinanceiro>, IComparer<TRegistro_CTB_CFGFinanceiro>
    {
        #region IComparer<TRegistro_CTB_CFGFinanceiro> Members
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

        public TList_CTB_CFGFinanceiro()
        { }

        public TList_CTB_CFGFinanceiro(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGFinanceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGFinanceiro x, TRegistro_CTB_CFGFinanceiro y)
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
    
    public class TRegistro_CTB_CFGFinanceiro
    {
        public decimal? Id_cfgctb
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
                    cd_conta_ctb_cred = Convert.ToDecimal(value);
                }
                catch
                { cd_conta_ctb_cred = null; }
            }
        }
        public string Ds_conta_ctb_cred
        { get; set; }
        public string Cd_classificacao_cred
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        public string Tp_mov_duplicata
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Tp_mov_historico
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        
        public TRegistro_CTB_CFGFinanceiro()
        {
            this.Id_cfgctb = null;
            this.Cd_classificacao_cred = string.Empty;
            this.Cd_classificacao_deb = string.Empty;
            this.Cd_clifor = string.Empty;
            this.cd_conta_ctb_cred = null;
            this.cd_conta_ctb_credstr = string.Empty;
            this.cd_conta_ctb_deb = null;
            this.cd_conta_ctb_debstr = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_conta_ctb_cred = string.Empty;
            this.Ds_conta_ctb_deb = string.Empty;
            this.Ds_historico = string.Empty;
            this.Tp_mov_historico = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.Tp_mov_duplicata = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
        }
    }

    public class TCD_CTB_CFGFinanceiro : TDataQuery
    {
        public TCD_CTB_CFGFinanceiro()
        { }

        public TCD_CTB_CFGFinanceiro(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop);
                sql.AppendLine("a.id_CFGCTB, a.CD_CONTA_CTB_DEB, b.DS_ContaCTB as DS_Conta_CTB_DEB, ");
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, ");
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED,  ");
                sql.AppendLine("a.TP_Duplicata, a.CD_Historico, a.CD_Clifor, a.cd_empresa, emp.nm_empresa, ");
                sql.AppendLine("d.DS_TPDuplicata, e.DS_Historico, f.NM_CLIFOR, ");
                sql.AppendLine("d.tp_mov as tp_mov_duplicata, e.tp_mov as tp_mov_historico ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Financeiro a ");
	        sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
	        sql.AppendLine("inner join tb_fin_TPDuplicata d ");
            sql.AppendLine("on d.TP_Duplicata = a.tp_Duplicata ");
            sql.AppendLine("inner join tb_fin_historico e ");
            sql.AppendLine("on e.Cd_Historico = a.CD_Historico ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
	        sql.AppendLine("left outer join tb_fin_Clifor f ");
            sql.AppendLine("on f.CD_Clifor = a.CD_Clifor");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTB_CFGFinanceiro Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGFinanceiro lista = new TList_CTB_CFGFinanceiro();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGFinanceiro reg = new TRegistro_CTB_CFGFinanceiro();
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
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TPDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TPDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_Duplicata")))
                        reg.Tp_mov_duplicata = reader.GetString(reader.GetOrdinal("TP_Mov_Duplicata"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_Historico")))
                        reg.Tp_mov_historico = reader.GetString(reader.GetOrdinal("TP_Mov_Historico"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.Cd_classificacao_deb = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.Cd_classificacao_cred = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));

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

        public string Grava(TRegistro_CTB_CFGFinanceiro vRegistro)
        {
            Hashtable hs = new Hashtable(7);

            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.Cd_conta_ctb_deb);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.Cd_conta_ctb_cred);
            hs.Add("@P_TP_DUPLICATA", vRegistro.Tp_duplicata);
            hs.Add("@P_CD_HISTORICO", vRegistro.Cd_historico);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", vRegistro.Cd_clifor);

            return this.executarProc("IA_CTB_FINANCEIRO", hs);
        }

        public string Deleta(TRegistro_CTB_CFGFinanceiro vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);

            return this.executarProc("EXCLUI_CTB_FINANCEIRO", hs);
        }
    }
}
