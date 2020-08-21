using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadMaquinaCartao : List<TRegistro_CadMaquinaCartao>, IComparer<TRegistro_CadMaquinaCartao>
    {
        #region IComparer<TRegistro_CadMaquinaCartao> Members
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

        public TList_CadMaquinaCartao()
        { }

        public TList_CadMaquinaCartao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadMaquinaCartao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadMaquinaCartao x, TRegistro_CadMaquinaCartao y)
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

    public class TRegistro_CadMaquinaCartao
    {
        private decimal? id_maquina;
        public decimal? ID_maquina
        {
            get { return id_maquina; }
            set
            {
                id_maquina = value;
                id_maquinastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_maquinastr;
        public string Id_maquinastr
        {
            get { return id_maquinastr; }
            set
            {
                id_maquinastr = value;
                try
                {
                    id_maquina = Convert.ToDecimal(value);
                }
                catch
                { id_maquina = null; }
            }
        }
        public string Ds_maquina
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadMaquinaCartao()
        {
            id_maquina = null;
            id_maquinastr = string.Empty;
            Ds_maquina = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_CadMaquinaCartao : TDataQuery
    {
        public TCD_CadMaquinaCartao()
        { }

        public TCD_CadMaquinaCartao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Maquina, a.DS_Maquina ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_MaquinaCartao a ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadMaquinaCartao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadMaquinaCartao lista = new TList_CadMaquinaCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadMaquinaCartao reg = new TRegistro_CadMaquinaCartao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Maquina"))))
                        reg.ID_maquina = reader.GetDecimal(reader.GetOrdinal("ID_Maquina"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Maquina"))))
                        reg.Ds_maquina = reader.GetString(reader.GetOrdinal("DS_Maquina"));
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

        public string Gravar(TRegistro_CadMaquinaCartao val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_MAQUINA", val.ID_maquina);
            hs.Add("@P_DS_MAQUINA", val.Ds_maquina);

            return executarProc("IA_FIN_MAQUINACARTAO", hs);
        }

        public string Excluir(TRegistro_CadMaquinaCartao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_MAQUINA", val.ID_maquina);

            return executarProc("EXCLUI_FIN_MAQUINACARTAO", hs);
        }
    }
}
