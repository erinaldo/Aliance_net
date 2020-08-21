using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CfgEmprestimos : List<TRegistro_CfgEmprestimos>, IComparer<TRegistro_CfgEmprestimos>
    {
        #region IComparer<TRegistro_CfgEmprestimos> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CfgEmprestimos()
        { }

        public TList_CfgEmprestimos(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgEmprestimos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgEmprestimos x, TRegistro_CfgEmprestimos y)
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

    
    public class TRegistro_CfgEmprestimos
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_historico_c
        { get; set; }
        
        public string Ds_historico_c
        { get; set; }
        
        public string Cd_historico_r
        { get; set; }
        
        public string Ds_historico_r
        { get; set; }
        
        public string Cd_historico_dev_c
        { get; set; }
        
        public string Ds_historico_dev_c
        { get; set; }
        
        public string Cd_historico_dev_r
        { get; set; }
        
        public string Ds_historico_dev_r
        { get; set; }
        
        public string Cd_centroresult_c
        { get; set; }
        
        public string Ds_centroresult_c
        { get; set; }
        
        public string Cd_centroresult_r
        { get; set; }
        
        public string Ds_centroresult_r
        { get; set; }
        
        public string Cd_centroresult_dev_c
        { get; set; }
        
        public string Ds_centroresult_dev_c
        { get; set; }
        
        public string Cd_centroresult_dev_r
        { get; set; }
        
        public string Ds_centroresult_dev_r
        { get; set; }

        public TRegistro_CfgEmprestimos()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_historico_c = string.Empty;
            this.Ds_historico_c = string.Empty;
            this.Cd_historico_r = string.Empty;
            this.Ds_historico_r = string.Empty;
            this.Cd_historico_dev_c = string.Empty;
            this.Ds_historico_dev_c = string.Empty;
            this.Cd_historico_dev_r = string.Empty;
            this.Ds_historico_dev_r = string.Empty;
            this.Cd_centroresult_c = string.Empty;
            this.Ds_centroresult_c = string.Empty;
            this.Cd_centroresult_r = string.Empty;
            this.Ds_centroresult_r = string.Empty;
            this.Cd_centroresult_dev_c = string.Empty;
            this.Ds_centroresult_dev_c = string.Empty;
            this.Cd_centroresult_dev_r = string.Empty;
            this.Ds_centroresult_dev_r = string.Empty;
        }
    }

    public class TCD_CfgEmprestimos : TDataQuery
    {
        public TCD_CfgEmprestimos()
        { }

        public TCD_CfgEmprestimos(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Historico_C, c.DS_Historico as DS_Historico_C, ");
                sql.AppendLine("a.CD_Historico_R, d.DS_Historico as DS_Historico_R, ");
                sql.AppendLine("a.CD_Historico_DEV_C, e.DS_Historico as DS_Historico_DEV_C, ");
                sql.AppendLine("a.CD_Historico_DEV_R, f.DS_Historico as DS_Historico_DEV_R, ");
                sql.AppendLine("a.CD_CentroResult_C, g.DS_CentroResultado as DS_CentroResult_C, ");
                sql.AppendLine("a.cd_centroresult_R, h.DS_CentroResultado as DS_CentroResult_R, ");
                sql.AppendLine("a.CD_CentroResult_DEV_C, i.DS_CentroResultado as DS_CentroResult_DEV_C, ");
                sql.AppendLine("a.CD_CentroResult_DEV_R, j.DS_CentroResultado as DS_CentroResult_DEV_R ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_CFGEmprestimos a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Historico c ");
            sql.AppendLine("on a.CD_Historico_C = c.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico d ");
            sql.AppendLine("on a.CD_Historico_R = d.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico e ");
            sql.AppendLine("on a.CD_Historico_DEV_C = e.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico f ");
            sql.AppendLine("on a.CD_Historico_DEV_R = f.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado g ");
            sql.AppendLine("on a.CD_CentroResult_C = g.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado h ");
            sql.AppendLine("on a.CD_CentroResult_R = h.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado i ");
            sql.AppendLine("on a.CD_CentroResult_DEV_C = i.CD_CentroResult ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado j ");
            sql.AppendLine("on a.CD_CentroResult_DEV_R = j.CD_CentroResult ");

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

        public TList_CfgEmprestimos Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgEmprestimos lista = new TList_CfgEmprestimos();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgEmprestimos reg = new TRegistro_CfgEmprestimos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_C")))
                        reg.Cd_historico_c = reader.GetString(reader.GetOrdinal("CD_Historico_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_C")))
                        reg.Ds_historico_c = reader.GetString(reader.GetOrdinal("DS_Historico_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_R")))
                        reg.Cd_historico_r = reader.GetString(reader.GetOrdinal("CD_Historico_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_R")))
                        reg.Ds_historico_r = reader.GetString(reader.GetOrdinal("DS_Historico_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DEV_C")))
                        reg.Cd_historico_dev_c = reader.GetString(reader.GetOrdinal("CD_Historico_DEV_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DEV_C")))
                        reg.Ds_historico_dev_c = reader.GetString(reader.GetOrdinal("DS_Historico_DEV_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DEV_R")))
                        reg.Cd_historico_dev_r = reader.GetString(reader.GetOrdinal("CD_Historico_DEV_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DEV_R")))
                        reg.Ds_historico_dev_r = reader.GetString(reader.GetOrdinal("DS_Historico_DEV_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult_C")))
                        reg.Cd_centroresult_c = reader.GetString(reader.GetOrdinal("CD_CentroResult_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_C")))
                        reg.Ds_centroresult_c = reader.GetString(reader.GetOrdinal("DS_CentroResult_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult_R")))
                        reg.Cd_centroresult_r = reader.GetString(reader.GetOrdinal("cd_centroresult_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_R")))
                        reg.Ds_centroresult_r = reader.GetString(reader.GetOrdinal("DS_CentroResult_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult_DEV_C")))
                        reg.Cd_centroresult_dev_c = reader.GetString(reader.GetOrdinal("CD_CentroResult_DEV_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_DEV_C")))
                        reg.Ds_centroresult_dev_c = reader.GetString(reader.GetOrdinal("DS_CentroResult_DEV_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult_DEV_R")))
                        reg.Cd_centroresult_dev_r = reader.GetString(reader.GetOrdinal("CD_CentroResult_DEV_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_DEV_R")))
                        reg.Ds_centroresult_dev_r = reader.GetString(reader.GetOrdinal("DS_CentroResult_DEV_R"));

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

        public string Gravar(TRegistro_CfgEmprestimos val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO_C", val.Cd_historico_c);
            hs.Add("@P_CD_HISTORICO_R", val.Cd_historico_r);
            hs.Add("@P_CD_HISTORICO_DEV_C", val.Cd_historico_dev_c);
            hs.Add("@P_CD_HISTORICO_DEV_R", val.Cd_historico_dev_r);
            hs.Add("@P_CD_CENTRORESULT_C", val.Cd_centroresult_c);
            hs.Add("@P_CD_CENTRORESULT_R", val.Cd_centroresult_r);
            hs.Add("@P_CD_CENTRORESULT_DEV_C", val.Cd_centroresult_dev_c);
            hs.Add("@P_CD_CENTRORESULT_DEV_R", val.Cd_centroresult_dev_r);

            return this.executarProc("IA_FIN_CFGEMPRESTIMOS", hs);
        }

        public string Excluir(TRegistro_CfgEmprestimos val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CFGEMPRESTIMOS", hs);
        }
    }
}
