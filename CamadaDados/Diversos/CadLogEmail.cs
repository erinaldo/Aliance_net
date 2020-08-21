using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_CadLogEmail : List<TRegistro_CadlogEmail>, IComparer<TRegistro_CadlogEmail>
    {
        #region IComparer<TRegistro_CadlogEmail> Members
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

        public TList_CadLogEmail()
        { }

        public TList_CadLogEmail(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadlogEmail value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadlogEmail x, TRegistro_CadlogEmail y)
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

    public class TRegistro_CadlogEmail
    {
        public decimal? id_log { get; set; }
        public string Loginremetente { get; set; }
        public string DS_Destinatario { get; set; }
        public string DS_Titulo { get; set; }
        public string Prioridade { get; set; }
        public DateTime? Dt_email { get; set; }
        public string Mensagem { get; set; }
        public string Anexo { get; set; }
        public decimal? Id_TpData { get; set; }
        public TList_CadUsuario login  { get; set; }

         public TRegistro_CadlogEmail()
        {
            this.id_log = null;
            this.Loginremetente = string.Empty;
            this.DS_Destinatario = string.Empty;
            this.DS_Titulo = string.Empty;
            this.Prioridade = string.Empty;
            this.Mensagem = string.Empty;
            this.Anexo = string.Empty;
            this.Id_TpData = null;
            this.login = new TList_CadUsuario();
        }
    }

    public class TCD_CadLogEmail : TDataQuery
    {
        public TCD_CadLogEmail()
        { }

        public TCD_CadLogEmail(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_log, a.loginremetente, a.ds_destinatario, ");
                sql.AppendLine("a.ds_titulo, a.prioridade, a.mensagem, a.anexo, a.dt_email, a.id_tpdata ");

            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_LogEmail a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadLogEmail Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadLogEmail lista = new TList_CadLogEmail();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadlogEmail cadlogEmail = new TRegistro_CadlogEmail();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Log")))
                        cadlogEmail.id_log = reader.GetDecimal(reader.GetOrdinal("ID_Log"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginRemetente")))
                        cadlogEmail.Loginremetente = reader.GetString(reader.GetOrdinal("LoginRemetente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_destinatario")))
                        cadlogEmail.DS_Destinatario = reader.GetString(reader.GetOrdinal("ds_destinatario")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_titulo")))
                        cadlogEmail.DS_Titulo = reader.GetString(reader.GetOrdinal("ds_titulo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("prioridade")))
                        cadlogEmail.Prioridade = reader.GetString(reader.GetOrdinal("prioridade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Email")))
                        cadlogEmail.Dt_email = reader.GetDateTime(reader.GetOrdinal("DT_Email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("mensagem")))
                        cadlogEmail.Mensagem = reader.GetString(reader.GetOrdinal("mensagem")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("anexo")))
                        cadlogEmail.Anexo = reader.GetString(reader.GetOrdinal("anexo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpdata")))
                        cadlogEmail.Id_TpData = reader.GetDecimal(reader.GetOrdinal("id_tpdata"));

                    lista.Add(cadlogEmail);
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

        public string Gravar(TRegistro_CadlogEmail val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_ID_LOG", val.id_log);
            hs.Add("@P_LOGINREMETENTE", val.Loginremetente);
            hs.Add("@P_DS_DESTINATARIO", val.DS_Destinatario);
            hs.Add("@P_DS_TITULO", val.DS_Titulo);
            hs.Add("@P_PRIORIDADE", val.Prioridade);
            hs.Add("@P_MENSAGEM", val.Mensagem);
            hs.Add("@P_ANEXO", val.Anexo);
            hs.Add("@P_DT_EMAIL", val.Dt_email);
            hs.Add("@P_ID_TPDATA", val.Id_TpData);

            return executarProc("IA_DIV_LOGEMAIL", hs);

        }
        
        public string Excluir(TRegistro_CadlogEmail val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LOG", val.id_log);

            return this.executarProc("EXCLUI_DIV_LOGEMAIL", hs);
        }
    }
}
