using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    #region Questionario
    public class TList_Questionario : List<TRegistro_Questionario>, IComparer<TRegistro_Questionario>
    {
        #region IComparer<TRegistro_Questionario> Members
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

        public TList_Questionario()
        { }

        public TList_Questionario(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Questionario value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Questionario x, TRegistro_Questionario y)
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

    public class TRegistro_Questionario
    {
        private decimal? id_questionario = null;
        public decimal? Id_questionario
        {
            get { return id_questionario; }
            set
            {
                id_questionario = value;
                id_questionariostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_questionariostr = string.Empty;
        public string Id_questionariostr
        {
            get { return id_questionariostr; }
            set
            {
                id_questionariostr = value;
                try
                {
                    id_questionario = decimal.Parse(value);
                }
                catch { id_questionario = null; }
            }
        }
        public string Ds_questionario { get; set; } = string.Empty;
        public bool Cancelado { get; set; } = false;
        public bool Selecionado { get; set; } = false;

        public TRegistro_Questionario()
        {
            Id_questionario = null;
            Ds_questionario = string.Empty;
            Cancelado = false;
        }
    }

    public class TCD_Questionario : TDataQuery
    {
        public TCD_Questionario() { }

        public TCD_Questionario(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_questionario, a.ds_questionario, a.cancelado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Questionario a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Questionario Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Questionario lista = new TList_Questionario();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Questionario reg = new TRegistro_Questionario();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_questionario")))
                        reg.Id_questionario = reader.GetDecimal(reader.GetOrdinal("id_questionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_questionario")))
                        reg.Ds_questionario = reader.GetString(reader.GetOrdinal("ds_questionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("cancelado"));

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

        public string Gravar(TRegistro_Questionario val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_QUESTIONARIO", val.Id_questionario);
            hs.Add("@P_DS_QUESTIONARIO", val.Ds_questionario);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_FAT_QUESTIONARIO", hs);
        }

        public string Excluir(TRegistro_Questionario val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_QUESTIONARIO", val.Id_questionario);

            return executarProc("EXCLUI_FAT_QUESTIONARIO", hs);
        }
    }
    #endregion

    #region Questionario X Pergunta
    public class TList_Questionario_X_Pergunta : List<TRegistro_Questionario_X_Pergunta> { }

    public class TRegistro_Questionario_X_Pergunta
    {
        private decimal? id_questionario = null;
        public decimal? Id_questionario
        {
            get { return id_questionario; }
            set
            {
                id_questionario = value;
                id_questionariostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_questionariostr = string.Empty;
        public string Id_questionariostr
        {
            get { return id_questionariostr; }
            set
            {
                id_questionariostr = value;
                try
                {
                    id_questionario = decimal.Parse(value);
                }
                catch { id_questionario = null; }
            }
        }
        private decimal? id_pergunta = null;
        public decimal? Id_pergunta
        {
            get { return id_pergunta; }
            set
            {
                id_pergunta = value;
                id_perguntastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_perguntastr = string.Empty;
        public string Id_perguntastr
        {
            get { return id_perguntastr; }
            set
            {
                id_perguntastr = value;
                try
                {
                    id_pergunta = decimal.Parse(value);
                }
                catch { id_pergunta = null; }
            }
        }

        public string ds_pergunta { get; set; } = string.Empty;

        public TRegistro_Questionario_X_Pergunta()
        {
            Id_questionario = null;
            Id_pergunta = null;
            ds_pergunta = string.Empty;
        }
    }

    public class TCD_Questionario_X_Pergunta : TDataQuery
    {
        public TCD_Questionario_X_Pergunta() { }

        public TCD_Questionario_X_Pergunta(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_questionario, a.id_pergunta, b.ds_pergunta ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Questionario_X_Pergunta a ");
            sql.AppendLine(" inner join TB_FAT_Pergunta b on a.ID_Pergunta = b.ID_Pergunta ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Questionario_X_Pergunta Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Questionario_X_Pergunta lista = new TList_Questionario_X_Pergunta();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Questionario_X_Pergunta reg = new TRegistro_Questionario_X_Pergunta();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_questionario")))
                        reg.Id_questionario = reader.GetDecimal(reader.GetOrdinal("id_questionario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pergunta")))
                        reg.Id_pergunta = reader.GetDecimal(reader.GetOrdinal("id_pergunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pergunta")))
                        reg.ds_pergunta = reader.GetString(reader.GetOrdinal("ds_pergunta"));

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

        public string Gravar(TRegistro_Questionario_X_Pergunta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_QUESTIONARIO", val.Id_questionario);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);

            return executarProc("IA_FAT_QUESTIONARIO_X_PERGUNTA", hs);
        }

        public string Excluir(TRegistro_Questionario_X_Pergunta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_QUESTIONARIO", val.Id_questionario);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);

            return executarProc("EXCLUI_FAT_QUESTIONARIO_X_PERGUNTA", hs);
        }
    }
    #endregion

    #region Pergunta
    public class TList_Pergunta : List<TRegistro_Pergunta>, IComparer<TRegistro_Pergunta>
    {
        #region IComparer<TRegistro_Pergunta> Members
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

        public TList_Pergunta()
        { }

        public TList_Pergunta(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Pergunta value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Pergunta x, TRegistro_Pergunta y)
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

    public class TRegistro_Pergunta
    {
        private decimal? id_pergunta = null;
        public decimal? Id_pergunta
        {
            get { return id_pergunta; }
            set
            {
                id_pergunta = value;
                id_perguntastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_perguntastr = string.Empty;
        public string Id_perguntastr
        {
            get { return id_perguntastr; }
            set
            {
                id_perguntastr = value;
                try
                {
                    id_pergunta = decimal.Parse(value);
                }
                catch { id_pergunta = null; }
            }
        }
        public string Ds_pergunta { get; set; } = string.Empty;
        public bool Cancelado { get; set; } = false;
        public bool Selecionado { get; set; } = false;

        public TRegistro_Pergunta()
        {
            Id_pergunta = null;
            Ds_pergunta = string.Empty;
            Cancelado = false;
        }
    }

    public class TCD_Pergunta : TDataQuery
    {
        public TCD_Pergunta() { }

        public TCD_Pergunta(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.ds_pergunta, a.cancelado, a.id_pergunta ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Pergunta a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pergunta Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Pergunta lista = new TList_Pergunta();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Pergunta reg = new TRegistro_Pergunta();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_pergunta")))
                        reg.Id_pergunta = reader.GetDecimal(reader.GetOrdinal("id_pergunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pergunta")))
                        reg.Ds_pergunta = reader.GetString(reader.GetOrdinal("ds_pergunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("cancelado"));

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

        public string Gravar(TRegistro_Pergunta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);
            hs.Add("@P_DS_PERGUNTA", val.Ds_pergunta);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_FAT_PERGUNTA", hs);
        }

        public string Excluir(TRegistro_Pergunta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);

            return executarProc("EXCLUI_FAT_PERGUNTA", hs);
        }
    }
    #endregion

    #region Resposta
    public class TList_Resposta : List<TRegistro_Resposta>, IComparer<TRegistro_Resposta>
    {
        #region IComparer<TRegistro_Evento> Members
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

        public TList_Resposta()
        { }

        public TList_Resposta(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Resposta value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Resposta x, TRegistro_Resposta y)
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

    public class TRegistro_Resposta
    {
        private decimal? id_resposta = null;
        public decimal? Id_resposta
        {
            get { return id_resposta; }
            set
            {
                id_resposta = value;
                id_respostastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_respostastr = string.Empty;
        public string Id_respostastr
        {
            get { return id_respostastr; }
            set
            {
                id_respostastr = value;
                try
                {
                    id_resposta = decimal.Parse(value);
                }
                catch { id_resposta = null; }
            }
        }
        public string Ds_resposta { get; set; } = string.Empty;
        public bool Cancelado { get; set; } = false;
        public bool Selecionado { get; set; } = false;

        public TRegistro_Resposta()
        {
            Id_respostastr = null;
            Ds_resposta = string.Empty;
            Cancelado = false;
        }
    }

    public class TCD_Resposta : TDataQuery
    {
        public TCD_Resposta() { }

        public TCD_Resposta(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_resposta, a.ds_resposta, a.cancelado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Resposta a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Resposta Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Resposta lista = new TList_Resposta();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Resposta reg = new TRegistro_Resposta();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_resposta")))
                        reg.Id_resposta = reader.GetDecimal(reader.GetOrdinal("id_resposta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_resposta")))
                        reg.Ds_resposta = reader.GetString(reader.GetOrdinal("ds_resposta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("cancelado"));

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

        public string Gravar(TRegistro_Resposta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);
            hs.Add("@P_DS_RESPOSTA", val.Ds_resposta);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_FAT_RESPOSTA", hs);
        }

        public string Excluir(TRegistro_Resposta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);

            return executarProc("EXCLUI_FAT_RESPOSTA", hs);
        }
    }
    #endregion

    #region Pergunta X Resposta
    public class TList_Pergunta_X_Resposta : List<TRegistro_Pergunta_x_Resposta> { }

    public class TRegistro_Pergunta_x_Resposta
    {
        private decimal? id_pergunta = null;
        public decimal? Id_pergunta
        {
            get { return id_pergunta; }
            set
            {
                id_pergunta = value;
                id_perguntastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_perguntastr = string.Empty;
        public string Id_perguntastr
        {
            get { return id_perguntastr; }
            set
            {
                id_perguntastr = value;
                try
                {
                    id_pergunta = decimal.Parse(value);
                }
                catch { id_pergunta = null; }
            }
        }
        private decimal? id_resposta = null;
        public decimal? Id_resposta
        {
            get { return id_resposta; }
            set
            {
                id_resposta = value;
                id_respostastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_respostastr = string.Empty;
        public string Id_respostastr
        {
            get { return id_respostastr; }
            set
            {
                id_respostastr = value;
                try
                {
                    id_resposta = decimal.Parse(value);
                }
                catch { id_resposta = null; }
            }
        }

        public string ds_resposta { get; set; } = string.Empty;

        public TRegistro_Pergunta_x_Resposta()
        {
            Id_pergunta = null;
            Id_resposta = null;
            ds_resposta = string.Empty;
        }
    }

    public class TCD_Pergunta_X_Resposta : TDataQuery
    {
        public TCD_Pergunta_X_Resposta() { }

        public TCD_Pergunta_X_Resposta(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.id_pergunta, a.id_resposta, b.ds_resposta ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_FAT_Pergunta_X_Resposta a ");
            sql.AppendLine(" inner join TB_FAT_Resposta b ");
            sql.AppendLine(" on a.ID_Resposta = b.ID_Resposta ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pergunta_X_Resposta Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_Pergunta_X_Resposta lista = new TList_Pergunta_X_Resposta();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Pergunta_x_Resposta reg = new TRegistro_Pergunta_x_Resposta();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_pergunta")))
                        reg.Id_pergunta = reader.GetDecimal(reader.GetOrdinal("id_pergunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_resposta")))
                        reg.Id_resposta = reader.GetDecimal(reader.GetOrdinal("id_resposta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_resposta")))
                        reg.ds_resposta = reader.GetString(reader.GetOrdinal("ds_resposta"));


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

        public string Gravar(TRegistro_Pergunta_x_Resposta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);

            return executarProc("IA_FAT_PERGUNTA_X_RESPOSTA", hs);
        }

        public string Excluir(TRegistro_Pergunta_x_Resposta val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_PERGUNTA", val.Id_pergunta);
            hs.Add("@P_ID_RESPOSTA", val.Id_resposta);

            return executarProc("EXCLUI_FAT_PERGUNTA_X_RESPOSTA", hs);
        }
    }
    #endregion
}
