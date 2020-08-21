using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Compra
{
    #region TP.Requisição
    public class TList_TpRequisicao : List<TRegistro_TpRequisicao>, IComparer<TRegistro_TpRequisicao>
    {
        #region IComparer<TRegistro_TpRequisicao> Members
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

        public TList_TpRequisicao()
        { }

        public TList_TpRequisicao(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpRequisicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpRequisicao x, TRegistro_TpRequisicao y)
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

    public class TRegistro_TpRequisicao
    {
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
        private string tp_requisicao;
        
        public string Tp_requisicao
        {
            get { return tp_requisicao; }
            set
            {
                tp_requisicao = value;
                if (value.Trim().ToUpper().Equals("I"))
                    tipo_requisicao = "INTERNA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_requisicao = "EXTERNA";
            }
        }
        private string tipo_requisicao;
        
        public string Tipo_requisicao
        {
            get { return tipo_requisicao; }
            set
            {
                tipo_requisicao = value;
                if (value.Trim().ToUpper().Equals("INTERNA"))
                    tp_requisicao = "I";
                else if (value.Trim().ToUpper().Equals("EXTERNA"))
                    tp_requisicao = "E";
            }
        }
        
        public bool St_processar
        { get; set; }
        public TList_TpRequisicao_X_GrupoProd lGrupoProd
        { get; set; }

        public TRegistro_TpRequisicao()
        {
            this.id_tprequisicao = null;
            this.id_tprequisicaostr = string.Empty;
            this.Ds_tprequisicao = string.Empty;
            this.tp_requisicao = string.Empty;
            this.tipo_requisicao = string.Empty;
            this.St_processar = false;
            this.lGrupoProd = new TList_TpRequisicao_X_GrupoProd();
        }
    }

    public class TCD_TpRequisicao : TDataQuery
    {
        public TCD_TpRequisicao()
        { }

        public TCD_TpRequisicao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tprequisicao, a.ds_tprequisicao, a.tp_requisicao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_tprequisicao a ");

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

        public TList_TpRequisicao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TpRequisicao lista = new TList_TpRequisicao();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo)); ;
            try
            {
                while (reader.Read())
                {
                    TRegistro_TpRequisicao reg = new TRegistro_TpRequisicao();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_tprequisicao")))
                        reg.Id_tprequisicao = reader.GetDecimal(reader.GetOrdinal("id_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tprequisicao")))
                        reg.Ds_tprequisicao = reader.GetString(reader.GetOrdinal("ds_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_requisicao")))
                        reg.Tp_requisicao = reader.GetString(reader.GetOrdinal("tp_requisicao"));

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

        public string Gravar(TRegistro_TpRequisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);
            hs.Add("@P_DS_TPREQUISICAO", val.Ds_tprequisicao);
            hs.Add("@P_TP_REQUISICAO", val.Tp_requisicao);

            return this.executarProc("IA_CMP_TPREQUISICAO", hs);
        }

        public string Excluir(TRegistro_TpRequisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);

            return this.executarProc("EXCLUI_CMP_TPREQUISICAO", hs);
        }
    }
    #endregion

    #region TP.Requisição X Grupo Produto
    public class TList_TpRequisicao_X_GrupoProd : List<TRegistro_TpRequisicao_X_GrupoProd>, IComparer<TRegistro_TpRequisicao_X_GrupoProd>
    {
        #region IComparer<TRegistro_TpRequisicao_X_GrupoProd> Members
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

        public TList_TpRequisicao_X_GrupoProd()
        { }

        public TList_TpRequisicao_X_GrupoProd(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpRequisicao_X_GrupoProd value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpRequisicao_X_GrupoProd x, TRegistro_TpRequisicao_X_GrupoProd y)
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

    public class TRegistro_TpRequisicao_X_GrupoProd
    {
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
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }


        public TRegistro_TpRequisicao_X_GrupoProd()
        {
            this.id_tprequisicao = null;
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
        }
    }

    public class TCD_TpRequisicao_X_GrupoProd : TDataQuery
    {
        public TCD_TpRequisicao_X_GrupoProd()
        { }

        public TCD_TpRequisicao_X_GrupoProd(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tprequisicao, a.Cd_grupo, b.Ds_grupo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CMP_TpRequisicao_X_GrupoProd a ");
            sql.AppendLine("inner join TB_EST_GrupoProduto b ");
            sql.AppendLine("on a.cd_grupo = b.cd_grupo ");

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

        public TList_TpRequisicao_X_GrupoProd Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TpRequisicao_X_GrupoProd lista = new TList_TpRequisicao_X_GrupoProd();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo)); ;
            try
            {
                while (reader.Read())
                {
                    TRegistro_TpRequisicao_X_GrupoProd reg = new TRegistro_TpRequisicao_X_GrupoProd();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_tprequisicao")))
                        reg.Id_tprequisicao = reader.GetDecimal(reader.GetOrdinal("id_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("Cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("Ds_grupo"));

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

        public string Gravar(TRegistro_TpRequisicao_X_GrupoProd val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);

            return this.executarProc("IA_CMP_TpRequisicao_X_GrupoProd", hs);
        }

        public string Excluir(TRegistro_TpRequisicao_X_GrupoProd val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);

            return this.executarProc("EXCLUI_CMP_TPREQUISICAO_X_GRUPOPROD", hs);
        }
    }
    #endregion
}
