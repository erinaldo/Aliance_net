using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Contabil
{
    public class TList_CTB_CFGNFCe : List<TRegistro_CTB_CFGNFCe>, IComparer<TRegistro_CTB_CFGNFCe>
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

        public TList_CTB_CFGNFCe()
        { }

        public TList_CTB_CFGNFCe(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CTB_CFGNFCe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CTB_CFGNFCe x, TRegistro_CTB_CFGNFCe y)
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
    public class TRegistro_CTB_CFGNFCe
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
        public string Cd_cfop
        { get; set; }
        public string Ds_cfop
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
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

        public TRegistro_CTB_CFGNFCe()
        {
            id_cfgctb = null;
            id_cfgctbstr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_cfop = string.Empty;
            Ds_cfop = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            _CD_Conta_CTB_DEB = null;
            _CD_Conta_CTB_CRED = null;
            _CD_Conta_CTB_DEB_String = string.Empty;
            _CD_Conta_CTB_CRED_String = string.Empty;
            CD_Classificacao_CRED = string.Empty;
            CD_Classificacao_DEB = string.Empty;
            DS_Conta_CTB_CRED = string.Empty;
            DS_Conta_CTB_DEB = string.Empty;
        }
    }

    public class TCD_CTB_CFGNFCe : TDataQuery
    {
        public TCD_CTB_CFGNFCe() { }

        public TCD_CTB_CFGNFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

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
                sql.AppendLine("a.CD_CONTA_CTB_CRED, c.DS_ContaCTB as DS_Conta_CTB_CRED, ");
                sql.AppendLine("b.CD_Classificacao as CD_Classificacao_DEB, c.CD_Classificacao as CD_Classificacao_CRED,  ");
                sql.AppendLine("a.cd_cfop, a.cd_produto, a.CD_Empresa, ");
                sql.AppendLine("d.ds_cfop, f.ds_Produto, g.NM_Empresa");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_NFCe a ");
            sql.AppendLine("inner join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.cd_Conta_CTB = a.cd_Conta_CTB_Deb ");
            sql.AppendLine("inner join TB_CTB_PlanoContas c ");
            sql.AppendLine("on c.cd_Conta_CTB = a.cd_Conta_CTB_Cred ");
            sql.AppendLine("inner join tb_fis_cfop d ");
            sql.AppendLine("on d.cd_cfop = a.cd_cfop ");
            sql.AppendLine("inner join TB_div_Empresa g ");
            sql.AppendLine("on g.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join TB_est_produto ");
            sql.AppendLine("f on f.cd_produto = a.cd_produto ");


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

        public TList_CTB_CFGNFCe Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CTB_CFGNFCe lista = new TList_CTB_CFGNFCe();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CTB_CFGNFCe reg = new TRegistro_CTB_CFGNFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CFGCTB")))
                        reg.Id_cfgctb = reader.GetDecimal(reader.GetOrdinal("ID_CFGCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_DEB")))
                        reg.CD_Conta_CTB_DEB = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTA_CTB_CRED")))
                        reg.CD_Conta_CTB_CRED = reader.GetDecimal(reader.GetOrdinal("CD_CONTA_CTB_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_DEB")))
                        reg.DS_Conta_CTB_DEB = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTA_CTB_CRED")))
                        reg.DS_Conta_CTB_CRED = reader.GetString(reader.GetOrdinal("DS_CONTA_CTB_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cfop")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("ds_cfop"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_DEB")))
                        reg.CD_Classificacao_DEB = reader.GetString(reader.GetOrdinal("CD_Classificacao_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao_CRED")))
                        reg.CD_Classificacao_CRED = reader.GetString(reader.GetOrdinal("CD_Classificacao_CRED"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
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

        public string Grava(TRegistro_CTB_CFGNFCe vRegistro)
        {
            Hashtable hs = new Hashtable(6);

            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);
            hs.Add("@P_CD_CONTA_CTB_DEB", vRegistro.CD_Conta_CTB_DEB);
            hs.Add("@P_CD_CONTA_CTB_CRED", vRegistro.CD_Conta_CTB_CRED);
            hs.Add("@P_CD_CFOP", vRegistro.Cd_cfop);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return executarProc("IA_CTB_NFCE", hs);
        }

        public string Deleta(TRegistro_CTB_CFGNFCe vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CFGCTB", vRegistro.Id_cfgctb);
            return executarProc("EXCLUI_CTB_NFCE", hs);
        }
    }
}
