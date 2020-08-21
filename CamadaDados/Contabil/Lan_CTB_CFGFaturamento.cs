using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGFaturamento : List<TRegistro_CTB_CFGFaturamento>, IComparer<TRegistro_CTB_CFGFaturamento>
    {
        #region IComparer<TRegistro_CTB_CFGFaturamento> Members
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

        public TList_CTB_CFGFaturamento()
        { }

        public TList_CTB_CFGFaturamento(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGFaturamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGFaturamento x, TRegistro_CTB_CFGFaturamento y)
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

    public class TRegistro_CTB_CFGFaturamento
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
                    _CD_Conta_CTB_DEB = Convert.ToDecimal(value);
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
                    _CD_Conta_CTB_CRED = Convert.ToDecimal(value);
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
        private decimal? _CD_Movimentacao;
        public decimal? CD_Movimentacao
        {
            get { return _CD_Movimentacao; }
            set 
            { 
                _CD_Movimentacao = value;
                _CD_Movimentacao_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string _CD_Movimentacao_String;
        public string CD_Movimentacao_String
        {
            get { return _CD_Movimentacao_String; }
            set { _CD_Movimentacao_String = value;
            try
            {
                _CD_Movimentacao = Convert.ToDecimal(value);
            }
            catch { _CD_Movimentacao = null; }
            
            }
        }
        public string DS_Movimentacao
        { get; set; }
        public string CD_Clifor
        { get; set; }
        public string NM_Clifor
        { get; set; }
        public string CD_Produto
        { get; set; }
        public string DS_Produto
        { get; set; }
        public string Cd_grupo { get; set; } = string.Empty;
        public string Ds_grupo { get; set; } = string.Empty;
        public string CD_Empresa
        { get; set; }
        public string NM_Empresa
        { get; set; }

        public TRegistro_CTB_CFGFaturamento()
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
            _CD_Movimentacao = null; 
            _CD_Movimentacao_String = string.Empty;
            DS_Movimentacao = string.Empty;
            CD_Clifor = string.Empty;
            NM_Clifor = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            CD_Empresa = string.Empty;
            NM_Empresa = string.Empty;
        }
    }

    public class TCD_CTB_CFGFaturamento : TDataQuery
    {
        public TCD_CTB_CFGFaturamento() { }

        public TCD_CTB_CFGFaturamento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

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
                sql.AppendLine("a.cd_movimentacao, a.cd_Clifor, a.cd_produto, a.CD_Grupo, a.CD_Empresa, ");
                sql.AppendLine("d.ds_movimentacao, e.NM_Clifor, f.ds_Produto, h.DS_Grupo, g.NM_Empresa");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Faturamento a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join TB_fis_movimentacao d ");
            sql.AppendLine("on d.cd_movimentacao = a.cd_movimentacao ");
            sql.AppendLine("inner join TB_div_Empresa g ");
            sql.AppendLine("on g.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join TB_fin_Clifor e ");
            sql.AppendLine("on e.cd_Clifor = a.cd_clifor ");
            sql.AppendLine("left outer join TB_est_produto ");
            sql.AppendLine("f on f.cd_produto = a.cd_produto ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto h ");
            sql.AppendLine("on a.cd_grupo = h.cd_grupo ");
            
            
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

        public TList_CTB_CFGFaturamento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CTB_CFGFaturamento lista = new TList_CTB_CFGFaturamento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGFaturamento reg = new TRegistro_CTB_CFGFaturamento();
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

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.CD_Movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Movimentacao")))
                        reg.DS_Movimentacao = reader.GetString(reader.GetOrdinal("DS_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.CD_Classificacao_DEB = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.CD_Classificacao_CRED = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("CD_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
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

        public string Grava(TRegistro_CTB_CFGFaturamento vRegistro)
        {
            Hashtable hs = new Hashtable(8);

            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.CD_Conta_CTB_DEB);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.CD_Conta_CTB_CRED);
            hs.Add("@P_CD_MOVIMENTACAO", vRegistro.CD_Movimentacao);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_GRUPO", vRegistro.Cd_grupo);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            
            return executarProc("IA_CTB_FATURAMENTO", hs);
        }

        public string Deleta(TRegistro_CTB_CFGFaturamento vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CFGCTB", vRegistro.ID_CFGCTB);
            return executarProc("EXCLUI_CTB_FATURAMENTO", hs);
        }
    }
}
