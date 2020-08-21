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
    public class TList_CTB_CFGCaixa : List<TRegistro_CTB_CFGCaixa>, IComparer<TRegistro_CTB_CFGCaixa>
    {
        #region IComparer<TRegistro_CTB_CFGCaixa> Members
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

        public TList_CTB_CFGCaixa()
        { }

        public TList_CTB_CFGCaixa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGCaixa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGCaixa x, TRegistro_CTB_CFGCaixa y)
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

    public class TRegistro_CTB_CFGCaixa
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
        public string DS_Conta_CTB_DEB
        { get; set; }
        public string DS_Conta_CTB_CRED
        { get; set; }
        public string CD_Classificacao_DEB
        { get; set; }
        public string CD_Classificacao_CRED
        { get; set; }
        public string CD_Empresa
        { get; set; }
        public string NM_Empresa
        { get; set; }
        public string CD_Historico
        { get; set; }
        public string DS_Historico
        { get; set; }
        public string CD_ContaGer
        { get; set; }
        public string DS_ContaGer
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
                    TP_Movimento = "R";
            }
        }
                
        public TRegistro_CTB_CFGCaixa()
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
            CD_Empresa = string.Empty;
            NM_Empresa = string.Empty;
            CD_Historico = string.Empty;
            DS_Historico = string.Empty;
            CD_ContaGer = string.Empty;
            DS_ContaGer = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
        }
    }

    public class TCD_CTB_CFGCaixa : TDataQuery
    {
        public TCD_CTB_CFGCaixa() { }

        public TCD_CTB_CFGCaixa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop);
                sql.AppendLine("a.id_CFGCTB, a.CD_CONTA_CTB_DEB, b.DS_ContaCTB as DS_Conta_CTB_DEB, ");
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, ");
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED, ");
                sql.AppendLine("a.cd_Contager, a.cd_historico, a.cd_empresa, a.TP_Movimento, ");
                sql.AppendLine("d.ds_Contager, e.ds_historico, f.NM_Empresa "); 
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Caixa a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join TB_Fin_Contager d ");
            sql.AppendLine("on d.cd_Contager = a.cd_contager ");
	        sql.AppendLine("inner join TB_Fin_historico e ");
            sql.AppendLine("on e.cd_historico = a.cd_historico ");
            sql.AppendLine("inner join TB_div_Empresa f ");
            sql.AppendLine("on f.cd_empresa = a.cd_empresa ");


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

        public TList_CTB_CFGCaixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGCaixa lista = new TList_CTB_CFGCaixa();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGCaixa reg = new TRegistro_CTB_CFGCaixa();
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
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico")))
                        reg.CD_Historico = reader.GetString(reader.GetOrdinal("CD_Historico"));                     
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                       reg.DS_Historico = reader.GetString(reader.GetOrdinal("DS_Historico"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.CD_Classificacao_DEB = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.CD_Classificacao_CRED = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contager")))
                        reg.CD_ContaGer = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contager")))
                        reg.DS_ContaGer = reader.GetString(reader.GetOrdinal("DS_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_CTB_CFGCaixa vRegistro)
        {
            Hashtable hs = new Hashtable(7);
            
            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.CD_Conta_CTB_DEB);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.CD_Conta_CTB_CRED);
            hs.Add("@P_CD_HISTORICO", vRegistro.CD_Historico);
            hs.Add("@P_CD_CONTAGER", vRegistro.CD_ContaGer); 
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.TP_Movimento);            

            return this.executarProc("IA_CTB_CAIXA", hs);
        }

        public string Deleta(TRegistro_CTB_CFGCaixa vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            return this.executarProc("EXCLUI_CTB_CAIXA", hs);
        }
    }
}
