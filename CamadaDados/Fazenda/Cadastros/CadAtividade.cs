using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_Atividade : List<TRegistro_Atividade>, IComparer<TRegistro_Atividade>
    {
        #region IComparer<TRegistro_Atividade> Members
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

        public TList_Atividade()
        { }

        public TList_Atividade(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Atividade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Atividade x, TRegistro_Atividade y)
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

    
    public class TRegistro_Atividade
    {
        private decimal? id_atividade;
        
        public decimal? Id_atividade
        {
            get { return id_atividade; }
            set
            {
                id_atividade = value;
                id_atividadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atividadestr;
        
        public string Id_atividadestr
        {
            get { return id_atividadestr; }
            set
            {
                id_atividadestr = value;
                try
                {
                    id_atividade = decimal.Parse(value);
                }
                catch
                { id_atividade = null; }
            }
        }
        
        public string Ds_atividade
        { get; set; }

        public TRegistro_Atividade()
        {
            this.id_atividade = null;
            this.id_atividadestr = string.Empty;
            this.Ds_atividade = string.Empty;
        }
    }

    public class TCD_Atividade : TDataQuery
    {
        public TCD_Atividade()
        { }

        public TCD_Atividade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.ID_Atividade, a.DS_Atividade ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("from TB_FAZ_Atividade a ");

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

        public TList_Atividade Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Atividade lista = new TList_Atividade();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Atividade reg = new TRegistro_Atividade();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Atividade")))
                        reg.Id_atividade = reader.GetDecimal(reader.GetOrdinal("ID_Atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Atividade")))
                        reg.Ds_atividade = reader.GetString(reader.GetOrdinal("DS_Atividade"));

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

        public string Gravar(TRegistro_Atividade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);
            hs.Add("@P_DS_ATIVIDADE", val.Ds_atividade);

            return this.executarProc("IA_FAZ_ATIVIDADE", hs);
        }

        public string Excluir(TRegistro_Atividade val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);

            return this.executarProc("EXCLUI_FAZ_ATIVIDADE", hs);
        }
    }
}

