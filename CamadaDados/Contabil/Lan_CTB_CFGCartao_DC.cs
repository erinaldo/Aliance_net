using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGCartao_DC:List<TRegistro_CTB_CFGCartao_DC>, IComparer<TRegistro_CTB_CFGCartao_DC>
    {
        #region IComparer<TRegistro_CTB_CFGCartao_DC> Members
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

        public TList_CTB_CFGCartao_DC()
        { }

        public TList_CTB_CFGCartao_DC(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGCartao_DC value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGCartao_DC x, TRegistro_CTB_CFGCartao_DC y)
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
    public class TRegistro_CTB_CFGCartao_DC
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
        public string Cd_classificacao_deb
        { get; set; }
        public string Ds_conta_ctb_deb
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
        public string Cd_classificacao_cred
        { get; set; }
        public string Ds_conta_ctb_cred
        { get; set; }
        public string Cd_contager_saida
        { get; set; }
        public string Cd_contager_entrada
        { get; set; }
        public string Ds_contager_saida
        { get; set; }
        public string Ds_contager_entrada
        { get; set; }
        private string tp_movimento;
        public string TP_Movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_movimento = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_movimento = "RECEBER";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_movimento = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_movimento = "R";
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        public TRegistro_CTB_CFGCartao_DC()
        {
            Cd_classificacao_cred = string.Empty;
            Cd_classificacao_deb = string.Empty;
            cd_conta_ctb_cred = null;
            cd_conta_ctb_credstr = string.Empty;
            cd_conta_ctb_deb = null;
            cd_conta_ctb_debstr = string.Empty;
            Cd_contager_entrada = string.Empty;
            Cd_contager_saida = string.Empty;
            Ds_conta_ctb_cred = string.Empty;
            Ds_conta_ctb_deb = string.Empty;
            Ds_contager_entrada = string.Empty;
            Ds_contager_saida = string.Empty;
            id_cfgctb = null;
            id_cfgctbstr = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
        }
    }
    public class TCD_CTB_CFGCartao_DC : TDataQuery
    {
        public TCD_CTB_CFGCartao_DC() { }

        public TCD_CTB_CFGCartao_DC(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop);
                sql.AppendLine("a.id_CFGCTB, a.CD_CONTA_CTB_DEB, b.DS_ContaCTB as DS_Conta_CTB_DEB, ");
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, a.cd_empresa, emp.nm_empresa, ");
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED,  ");
                sql.AppendLine("a.cd_Contager_Entrada, a.cd_Contager_saida, a.TP_Movimento, ");
                sql.AppendLine("d.ds_Contager as ContaGer_Entrada, e.ds_Contager as ContaGer_Saida ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Cartao_DC a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join TB_fin_Contager d ");
            sql.AppendLine("on d.cd_Contager = a.cd_ContaGer_entrada ");
            sql.AppendLine("inner join TB_fin_Contager e ");
            sql.AppendLine("on e.cd_Contager = a.cd_ContaGer_saida ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTB_CFGCartao_DC Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CTB_CFGCartao_DC lista = new TList_CTB_CFGCartao_DC();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGCartao_DC reg = new TRegistro_CTB_CFGCartao_DC();
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

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTAGer_Entrada")))
                        reg.Cd_contager_entrada = reader.GetString(reader.GetOrdinal("CD_CONTAGer_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CONTAGer_Entrada")))
                        reg.Ds_contager_entrada = reader.GetString(reader.GetOrdinal("CONTAGer_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTAGer_Saida")))
                        reg.Cd_contager_saida = reader.GetString(reader.GetOrdinal("CD_CONTAGer_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CONTAGer_Saida")))
                        reg.Ds_contager_saida = reader.GetString(reader.GetOrdinal("CONTAGer_Saida"));

                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_CTB_CFGCartao_DC vRegistro)
        {
            Hashtable hs = new Hashtable(7);

            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.Cd_conta_ctb_deb);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.Cd_conta_ctb_cred);
            hs.Add("@P_CD_CONTAGER_ENTRADA", vRegistro.Cd_contager_entrada);
            hs.Add("@P_CD_CONTAGER_SAIDA", vRegistro.Cd_contager_saida);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.TP_Movimento);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return executarProc("IA_CTB_CARTAO_DC", hs);
        }

        public string Exclui(TRegistro_CTB_CFGCartao_DC vRegistro)
        {
            Hashtable hs = new Hashtable(1);

            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);

            return executarProc("EXCLUI_CTB_CARTAO_DC", hs);
        }
    }
}
