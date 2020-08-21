using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    #region Centro Resultado
    public class TList_CentroResultado : List<TRegistro_CentroResultado>, IComparer<TRegistro_CentroResultado>
    {
        #region IComparer<TRegistro_CentroResultado> Members
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

        public TList_CentroResultado()
        { }

        public TList_CentroResultado(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CentroResultado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CentroResultado x, TRegistro_CentroResultado y)
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
    
    public class TRegistro_CentroResultado
    {
        public string Cd_centroresult
        { get; set; }
        public string Ds_centroresultado
        { get; set; }
        public string Cd_centroresult_pai
        { get; set; }
        public string Ds_centroresult_pai
        { get; set; }
        public decimal Nivel
        { get; set; }
        private string tp_registro;
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("R"))
                    tipo_registro = "RECEITA";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_registro = "DESPESA";
            }
        }
        private string tipo_registro;
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("RECEITA"))
                    tp_registro = "R";
                else if (value.Trim().ToUpper().Equals("DESPESA"))
                    tp_registro = "D";
            }
        }
        private string st_sintetico;
        public string St_sintetico
        {
            get { return st_sintetico; }
            set
            {
                st_sintetico = value;
                st_sinteticobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sinteticobool;
        public bool St_sinteticobool
        {
            get { return st_sinteticobool; }
            set
            {
                st_sinteticobool = value;
                st_sintetico = value ? "S" : "N";
            }
        }
        private string st_deducao;
        public string St_deducao
        {
            get { return st_deducao; }
            set
            {
                st_deducao = value;
                st_deducaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_deducaobool;
        public bool St_deducaobool
        {
            get { return st_deducaobool; }
            set
            {
                st_deducaobool = value;
                st_deducao = value ? "S" : "N";
            }
        }
        public decimal Valor
        { get; set; }
        public decimal Pc_valor
        { get; set; }
        public string St_registro
        { get; set; }
        public string PathCentroresult
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_CadHistorico lHist
        { get; set; }
        public TList_CadHistorico lHistDel
        { get; set; }

        public TRegistro_CentroResultado()
        {
            Cd_centroresult = string.Empty;
            Ds_centroresultado = string.Empty;
            Cd_centroresult_pai = string.Empty;
            Ds_centroresult_pai = string.Empty;
            Nivel = decimal.Zero;
            tp_registro = string.Empty;
            tipo_registro = string.Empty;
            st_sintetico = "N";
            st_sinteticobool = false;
            st_deducao = "N";
            st_deducaobool = false;
            Valor = decimal.Zero;
            Pc_valor = decimal.Zero;
            St_registro = "A";
            PathCentroresult = string.Empty;
            St_processar = false;
            lHist = new TList_CadHistorico();
            lHistDel = new TList_CadHistorico();
        }
    }

    public class TCD_CentroResultado : TDataQuery
    {
        public TCD_CentroResultado()
        { }

        public TCD_CentroResultado(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_CentroResult, Space((a.Nivel - 1)*5) + a.DS_CentroResultado as DS_CentroResultado, ");
                sql.AppendLine("a.CD_CentroResult_Pai, b.DS_CentroResultado as DS_CentroResult_Pai, ");
                sql.AppendLine("a.Nivel, a.TP_Registro, a.ST_Sintetico, a.ST_Deducao, a.ST_Registro, ");
                sql.AppendLine("dbo.F_PATHCENTRORESULT(a.cd_centroresult) as PathCentroresult ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_CentroResultado a ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado b ");
            sql.AppendLine("on a.CD_CentroResult_Pai = b.CD_CentroResult ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + " ( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            sql.AppendLine(" order by a.CD_CentroResult_Pai, a.CD_CentroResult ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CentroResultado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CentroResultado lista = new TList_CentroResultado();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CentroResultado reg = new TRegistro_CentroResultado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CentroResult"))))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("CD_CentroResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CentroResultado"))))
                        reg.Ds_centroresultado = reader.GetString(reader.GetOrdinal("DS_CentroResultado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CentroResult_Pai"))))
                        reg.Cd_centroresult_pai = reader.GetString(reader.GetOrdinal("CD_CentroResult_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_Pai")))
                        reg.Ds_centroresult_pai = reader.GetString(reader.GetOrdinal("DS_CentroResult_Pai"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nivel"))))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("Nivel"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Sintetico"))))
                        reg.St_sintetico = reader.GetString(reader.GetOrdinal("ST_Sintetico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("TP_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Deducao")))
                        reg.St_deducao = reader.GetString(reader.GetOrdinal("ST_Deducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PathCentroresult")))
                        reg.PathCentroresult = reader.GetString(reader.GetOrdinal("PathCentroresult"));
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

        public string Gravar(TRegistro_CentroResultado val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_CENTRORESULT_PAI", val.Cd_centroresult_pai);
            hs.Add("@P_DS_CENTRORESULTADO", val.Ds_centroresultado.Trim());
            hs.Add("@P_ST_SINTETICO", val.St_sintetico);
            hs.Add("@P_ST_DEDUCAO", val.St_deducao);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIN_CENTRORESULTADO", hs);
        }

        public string Excluir(TRegistro_CentroResultado val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);

            return executarProc("EXCLUI_FIN_CENTRORESULTADO", hs);
        }
    }
    #endregion

    #region CentroResult X Historico
    public class TList_CentroResult_X_Historico : List<TRegistro_CentroResult_X_Historico>, IComparer<TRegistro_CentroResult_X_Historico>
    {
        #region IComparer<TRegistro_CentroResult_X_Historico> Members
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

        public TList_CentroResult_X_Historico()
        { }

        public TList_CentroResult_X_Historico(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CentroResult_X_Historico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CentroResult_X_Historico x, TRegistro_CentroResult_X_Historico y)
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

    public class TRegistro_CentroResult_X_Historico
    {
        public string Cd_centroresult
        { get; set; }
        public string Cd_historico { get; set; }


        public TRegistro_CentroResult_X_Historico()
        {
            Cd_centroresult = string.Empty;
            Cd_historico = string.Empty;
        }
    }

    public class TCD_CentroResult_X_Historico : TDataQuery
    {
        public TCD_CentroResult_X_Historico()
        { }

        public TCD_CentroResult_X_Historico(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_CentroResult, a.cd_historico ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_CentroResult_X_Historico a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + " ( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CentroResult_X_Historico Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CentroResult_X_Historico lista = new TList_CentroResult_X_Historico();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CentroResult_X_Historico reg = new TRegistro_CentroResult_X_Historico();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CentroResult"))))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("CD_CentroResult"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("Cd_historico"));
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

        public string Gravar(TRegistro_CentroResult_X_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);

            return executarProc("IA_FIN_CENTRORESULT_X_HISTORICO", hs);
        }

        public string Excluir(TRegistro_CentroResult_X_Historico val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);

            return executarProc("EXCLUI_FIN_CENTRORESULT_X_HISTORICO", hs);
        }
    }
    #endregion
}
