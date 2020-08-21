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
    public class TList_CadEncargosFolha : List<TRegistro_CadEncargosFolha>, IComparer<TRegistro_CadEncargosFolha>
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

        public TList_CadEncargosFolha()
        { }

        public TList_CadEncargosFolha(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadEncargosFolha value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadEncargosFolha x, TRegistro_CadEncargosFolha y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }
    public class TRegistro_CadEncargosFolha
    {
        private decimal? id_encargo = null;
        public decimal? Id_encargo
        {
            get { return id_encargo; }
            set
            {
                id_encargo = value;
                id_encargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_encargostr = string.Empty;
        public string Id_encargostr
        {
            get { return id_encargostr; }
            set
            {
                id_encargostr = value;
                try
                {
                    id_encargo = decimal.Parse(value);
                }
                catch { id_encargo = null; }
            }
        }
        public string Ds_encargo { get; set; } = string.Empty;
        public decimal Pc_encargo { get; set; } = decimal.Zero;
        public bool st_agregar { get; set; } = false;
    }
    public class TCD_CadEncargosFolha:TDataQuery
    {
        public TCD_CadEncargosFolha() { }
        public TCD_CadEncargosFolha(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_encargo, a.ds_encargo, a.pc_encargo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_EncargosFolha a ");
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
        public TList_CadEncargosFolha Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadEncargosFolha lista = new TList_CadEncargosFolha();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadEncargosFolha reg = new TRegistro_CadEncargosFolha();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_encargo")))
                        reg.Id_encargo = reader.GetDecimal(reader.GetOrdinal("id_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_encargo")))
                        reg.Ds_encargo = reader.GetString(reader.GetOrdinal("DS_encargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_encargo")))
                        reg.Pc_encargo = reader.GetDecimal(reader.GetOrdinal("pc_encargo"));

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
        public string Gravar(TRegistro_CadEncargosFolha val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_ENCARGO", val.Id_encargo);
            hs.Add("@P_DS_ENCARGO", val.Ds_encargo);
            hs.Add("@P_PC_ENCARGO", val.Pc_encargo);

            return executarProc("IA_EMP_ENCARGOSFOLHA", hs);
        }
        public string Excluir(TRegistro_CadEncargosFolha val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ENCARGO", val.Id_encargo);

            return executarProc("EXCLUI_EMP_ENCARGOSFOLHA", hs);
        }
    }
}
