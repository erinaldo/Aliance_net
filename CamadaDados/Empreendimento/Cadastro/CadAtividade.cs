using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TList_CadAtividade : List<TRegistro_CadAtividade>, IComparer<TRegistro_CadAtividade>
    {
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

        public TList_CadAtividade()
        { }

        public TList_CadAtividade(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadAtividade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadAtividade x, TRegistro_CadAtividade y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }

    public class TRegistro_CadAtividade
    {
        public bool st_agregar { get; set; } = false;
        private decimal? id_atividade = null;
        public decimal? Id_atividade
        {
            get { return id_atividade; }
            set
            {
                id_atividade = value;
                id_atividadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atividadestr = string.Empty;
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
                catch { id_atividade = null; }
            }
        }
        public string Ds_atividade { get; set; } = string.Empty;
        public decimal Pc_margemcont { get; set; } = decimal.Zero;
    }

    public class TCD_CadAtividade:TDataQuery
    {
        public TCD_CadAtividade() { }
        public TCD_CadAtividade(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_atividade, a.ds_atividade, a.pc_margemcont ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_CadAtividade a ");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public TList_CadAtividade Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadAtividade lista = new TList_CadAtividade();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadAtividade reg = new TRegistro_CadAtividade();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_atividade = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_atividade")))
                        reg.Ds_atividade = reader.GetString(reader.GetOrdinal("DS_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_margemcont")))
                        reg.Pc_margemcont = reader.GetDecimal(reader.GetOrdinal("pc_margemcont"));

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
        public string Gravar(TRegistro_CadAtividade val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);
            hs.Add("@P_DS_ATIVIDADE", val.Ds_atividade);
            hs.Add("@P_PC_MARGEMCONT", val.Pc_margemcont);

            return executarProc("IA_EMP_CADATIVIDADE", hs);
        }
        public string Excluir(TRegistro_CadAtividade val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);

            return executarProc("EXCLUI_EMP_CADATIVIDADE", hs);
        }
    }
}
