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
    public class TList_CTB_CFGProvisao_Estoque : List<TRegistro_CTB_CFGProvisao_Estoque>, IComparer<TRegistro_CTB_CFGProvisao_Estoque>
    {
        #region IComparer<TRegistro_CTB_CFGProvisao_Estoque> Members
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

        public TList_CTB_CFGProvisao_Estoque()
        { }

        public TList_CTB_CFGProvisao_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGProvisao_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGProvisao_Estoque x, TRegistro_CTB_CFGProvisao_Estoque y)
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

    public class TRegistro_CTB_CFGProvisao_Estoque
    {
        private decimal? _ID_CFGCTB;
        public decimal? ID_CFGCTB
        {
            get { return _ID_CFGCTB; }
            set
            {
                _ID_CFGCTB = value;
                _ID_CFGCTB_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string _ID_CFGCTB_String;
        public string ID_CFGCTB_String
        {
            get { return _ID_CFGCTB_String; }
            set
            {
                _ID_CFGCTB_String = value;
                try
                {
                    _ID_CFGCTB = decimal.Parse(value);
                }
                catch { _ID_CFGCTB = null; }
            }
        }
        private decimal? _CD_Conta_CTB_DEB;
        public decimal? CD_Conta_CTB_DEB
        {
            get { return _CD_Conta_CTB_DEB; }
            set
            {
                _CD_Conta_CTB_DEB = value;
                _CD_Conta_CTB_DEB_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private decimal? _CD_Conta_CTB_CRED;
        public decimal? CD_Conta_CTB_CRED
        {
            get { return _CD_Conta_CTB_CRED; }
            set
            {
                _CD_Conta_CTB_CRED = value;
                _CD_Conta_CTB_CRED_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string _CD_Conta_CTB_DEB_String;
        public string CD_Conta_CTB_DEB_String
        {
            get { return _CD_Conta_CTB_DEB_String; }
            set
            {
                _CD_Conta_CTB_DEB_String = value;
                try
                {
                    _CD_Conta_CTB_DEB = decimal.Parse(value);
                }
                catch { _CD_Conta_CTB_DEB = null; }
            }
        }
        private string _CD_Conta_CTB_CRED_String;
        public string CD_Conta_CTB_CRED_String
        {
            get { return _CD_Conta_CTB_CRED_String; }
            set
            {
                _CD_Conta_CTB_CRED_String = value;
                try
                {
                    _CD_Conta_CTB_CRED = decimal.Parse(value);
                }
                catch { _CD_Conta_CTB_CRED = null; }
            }
        }
        public string CD_Classificacao_DEB
        { get; set; }
        public string CD_Classificacao_CRED
        { get; set; }
        public string DS_Conta_CTB_DEB
        { get; set; }
        public string DS_Conta_CTB_CRED
        { get; set; }
        public string CD_Produto
        { get; set; }
        public string DS_Produto
        { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }

        public TRegistro_CTB_CFGProvisao_Estoque()
        {
            _ID_CFGCTB = null;
            _ID_CFGCTB_String = string.Empty;
            _CD_Conta_CTB_DEB = null;
            _CD_Conta_CTB_CRED = null;
            _CD_Conta_CTB_DEB_String = string.Empty;
            _CD_Conta_CTB_CRED_String = string.Empty;
            CD_Classificacao_CRED = string.Empty;
            CD_Classificacao_DEB = string.Empty;
            DS_Conta_CTB_DEB = string.Empty;
            DS_Conta_CTB_CRED = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
        }
    }

    public class TCD_CTB_CFGProvisao_Estoque : TDataQuery
    {
        public TCD_CTB_CFGProvisao_Estoque() { }

        public TCD_CTB_CFGProvisao_Estoque(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

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
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED,  ");
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, a.TP_Movimento,");
                sql.AppendLine("a.cd_produto, d.ds_produto, a.cd_empresa, emp.nm_empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Provisao_Estoque a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join TB_est_Produto d ");
            sql.AppendLine("on d.cd_Produto = a.cd_produto ");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CTB_CFGProvisao_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGProvisao_Estoque lista = new TList_CTB_CFGProvisao_Estoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGProvisao_Estoque reg = new TRegistro_CTB_CFGProvisao_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CFGCTB")))
                        reg.ID_CFGCTB = reader.GetDecimal(reader.GetOrdinal("ID_CFGCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_DEB")))
                        reg.CD_Conta_CTB_DEB = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_CRED")))
                        reg.CD_Conta_CTB_CRED = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_DEB")))
                        reg.DS_Conta_CTB_DEB = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_CRED")))
                        reg.DS_Conta_CTB_CRED = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.CD_Classificacao_DEB = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.CD_Classificacao_CRED = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
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

        public string Grava(TRegistro_CTB_CFGProvisao_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(6);

            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.CD_Conta_CTB_DEB);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.CD_Conta_CTB_CRED);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.Tp_movimento);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return this.executarProc("IA_CTB_PROVISAO_ESTOQUE", hs);
        }

        public string Deleta(TRegistro_CTB_CFGProvisao_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            return this.executarProc("EXCLUI_CTB_PROVISAO_ESTOQUE", hs);
        }
    }
}
