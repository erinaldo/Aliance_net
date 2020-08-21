using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_Usuario_TpRequisicao : List<TRegistro_Usuario_TpRequisicao>, IComparer<TRegistro_Usuario_TpRequisicao>
    {
        #region IComparer<TRegistro_Usuario_TpRequisicao> Members
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

        public TList_Usuario_TpRequisicao()
        { }

        public TList_Usuario_TpRequisicao(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Usuario_TpRequisicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Usuario_TpRequisicao x, TRegistro_Usuario_TpRequisicao y)
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

    
    public class TRegistro_Usuario_TpRequisicao
    {
        
        public string Login
        { get; set; }
        private decimal? id_tprequisicao;
        
        public decimal? Id_tprequisicao
        {
            get { return id_tprequisicao; }
            set
            {
                id_tprequisicao = value;
                id_tprequisicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tprequisicaostr;
        
        public string Id_tprequisicaostr
        {
            get { return id_tprequisicaostr; }
            set
            {
                id_tprequisicaostr = value;
                try
                {
                    id_tprequisicao = decimal.Parse(value);
                }
                catch
                { id_tprequisicao = null; }
            }
        }
        
        public string Ds_tprequisicao
        { get; set; }

        public TRegistro_Usuario_TpRequisicao()
        {
            this.Login = string.Empty;
            this.id_tprequisicao = null;
            this.id_tprequisicaostr = string.Empty;
            this.Ds_tprequisicao = string.Empty;
        }
    }

    public class TCD_Usuario_TpRequisicao : TDataQuery
    {
        public TCD_Usuario_TpRequisicao()
        { }

        public TCD_Usuario_TpRequisicao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" select " + strTop + " a.login, a.id_tprequisicao, b.ds_tprequisicao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_DIV_Usuario_X_TpRequisicao a ");
            sql.AppendLine("inner join TB_CMP_TpRequisicao b ");
            sql.AppendLine("on a.id_tprequisicao = b.id_tprequisicao ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Usuario_TpRequisicao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Usuario_TpRequisicao lista = new TList_Usuario_TpRequisicao();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Usuario_TpRequisicao reg = new TRegistro_Usuario_TpRequisicao();
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tprequisicao")))
                        reg.Id_tprequisicao = reader.GetDecimal(reader.GetOrdinal("id_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tprequisicao")))
                        reg.Ds_tprequisicao = reader.GetString(reader.GetOrdinal("ds_tprequisicao"));

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

        public string Gravar(TRegistro_Usuario_TpRequisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);

            return this.executarProc("IA_DIV_USUARIO_X_TPREQUISICAO", hs);
        }

        public string Excluir(TRegistro_Usuario_TpRequisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);

            return this.executarProc("EXCLUI_DIV_USUARIO_X_TPREQUISICAO", hs);
        }
    }
}
