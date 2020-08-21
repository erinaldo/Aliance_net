using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_CadDesenhoPneu : List<TRegistro_CadDesenhoPneu>, IComparer<TRegistro_CadDesenhoPneu>
    {
        #region IComparer<TRegistro_LanAdiantamento> Members
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

        public TList_CadDesenhoPneu()
        { }

        public TList_CadDesenhoPneu(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadDesenhoPneu value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadDesenhoPneu x, TRegistro_CadDesenhoPneu y)
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

    public class TRegistro_CadDesenhoPneu
    {
        private Int32? id_desenho;
        public Int32? Id_desenho
        {
            get
            {
                return id_desenho;
            }
            set
            {
                id_desenho = value;
                id_desenhostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_desenhostr;
        public string Id_desenhostr
        {
            get
            { return id_desenhostr; }
            set
            {
                id_desenhostr = value;
                try
                {
                    id_desenho = Convert.ToInt32(value);
                }
                catch { id_desenho = null; }
            }
        }

        public string Ds_desenho
        { get; set; }

        public TRegistro_CadDesenhoPneu()
        {
            Id_desenho = null;
            Id_desenhostr = string.Empty;
            Ds_desenho = string.Empty;
        }
    }

    public class TCD_CadDesenhoPneu : TDataQuery
    {
        public TCD_CadDesenhoPneu()
        { }

        public TCD_CadDesenhoPneu(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select id_desenho, ds_desenho ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_DesenhoPneu ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " ) ");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadDesenhoPneu Select(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_CadDesenhoPneu lista = new TList_CadDesenhoPneu();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNm_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadDesenhoPneu reg = new TRegistro_CadDesenhoPneu();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_desenho")))
                        reg.Id_desenho = reader.GetInt32(reader.GetOrdinal("id_desenho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_desenho")))
                        reg.Ds_desenho = reader.GetString(reader.GetOrdinal("ds_desenho"));

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

        public string Gravar(TRegistro_CadDesenhoPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_DESENHO", val.Id_desenhostr);
            hs.Add("@P_DS_DESENHO", val.Ds_desenho);

            return executarProc("IA_FRT_DESENHOPNEU", hs);
        }

        public string Excluir(TRegistro_CadDesenhoPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_DESENHO", val.Id_desenhostr);

            return executarProc("EXCLUI_FRT_DESENHOPNEU", hs);
        }

    }
}
