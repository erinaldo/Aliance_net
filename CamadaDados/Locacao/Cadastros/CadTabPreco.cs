using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Locacao.Cadastros
{
    public class TList_CadTabPreco : List<TRegistro_CadTabPreco>, IComparer<TRegistro_CadTabPreco>
    {
        #region IComparer<TRegistro_CadTabPreco> Members
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

        public TList_CadTabPreco()
        { }

        public TList_CadTabPreco(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTabPreco value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTabPreco x, TRegistro_CadTabPreco y)
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

    public class TRegistro_CadTabPreco
    {
        private decimal? id_tabela;

        public decimal? Id_tabela
        {
            get { return id_tabela; }
            set
            {
                id_tabela = value;
                id_tabelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tabelastr;

        public string Id_tabelastr
        {
            get { return id_tabelastr; }
            set
            {
                id_tabelastr = value;
                try
                {
                    id_tabela = decimal.Parse(value);
                }
                catch
                { id_tabela = null; }
            }
        }

        public string Ds_tabela
        { get; set; }
        private string tp_tabela;

        public string Tp_tabela
        {
            get { return tp_tabela; }
            set
            {
                tp_tabela = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_tabela = "UNIDADE";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_tabela = "MILIMETRO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_tabela = "HORA";
                else if (value.Trim().ToUpper().Equals("3"))
                    tipo_tabela = "DIA";
                else if (value.Trim().ToUpper().Equals("4"))
                    tipo_tabela = "MÊS";
                else if (value.Trim().ToUpper().Equals("5"))
                    tipo_tabela = "SEMANA";
                else if (value.Trim().ToUpper().Equals("6"))
                    tipo_tabela = "QUINZENA";
            }
        }
        private string tipo_tabela;

        public string Tipo_tabela
        {
            get { return tipo_tabela; }
            set
            {
                tipo_tabela = value;
                if (value.Trim().ToUpper().Equals("UNIDADE"))
                    tp_tabela = "0";
                else if (value.Trim().ToUpper().Equals("MILIMETRO"))
                    tp_tabela = "1";
                else if (value.Trim().ToUpper().Equals("HORA"))
                    tp_tabela = "2";
                else if (value.Trim().ToUpper().Equals("DIA"))
                    tp_tabela = "3";
                else if (value.Trim().ToUpper().Equals("MÊS"))
                    tp_tabela = "4";
                else if (value.Trim().ToUpper().Equals("SEMANA"))
                    tp_tabela = "5";
                else if (value.Trim().ToUpper().Equals("QUINZENA"))
                    tp_tabela = "6";
            }
        }
        public bool St_processar
        { get; set; }
        public bool Cancelado { get; set; }

        public TRegistro_CadTabPreco()
        {
            id_tabela = null;
            id_tabelastr = string.Empty;
            Ds_tabela = string.Empty;
            tp_tabela = string.Empty;
            tipo_tabela = string.Empty;
            St_processar = false;
            Cancelado = false;
        }
    }

    public class TCD_CadTabPreco : TDataQuery
    {
        public TCD_CadTabPreco() { }

        public TCD_CadTabPreco(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.ID_Tabela, a.DS_Tabela, a.TP_Tabela, a.cancelado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine(" from TB_LOC_TabPreco a ");

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

        public TList_CadTabPreco Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadTabPreco lista = new TList_CadTabPreco();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTabPreco reg = new TRegistro_CadTabPreco();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Tabela")))
                        reg.Id_tabela = reader.GetDecimal(reader.GetOrdinal("ID_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Tabela")))
                        reg.Ds_tabela = reader.GetString(reader.GetOrdinal("DS_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Tabela")))
                        reg.Tp_tabela = reader.GetString(reader.GetOrdinal("TP_Tabela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cancelado")))
                        reg.Cancelado = reader.GetBoolean(reader.GetOrdinal("Cancelado"));

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

        public string Gravar(TRegistro_CadTabPreco val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_TABELA", val.Id_tabela);
            hs.Add("@P_DS_TABELA", val.Ds_tabela);
            hs.Add("@P_TP_TABELA", val.Tp_tabela);
            hs.Add("@P_CANCELADO", val.Cancelado);

            return executarProc("IA_LOC_TABPRECO", hs);
        }

        public string Excluir(TRegistro_CadTabPreco val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TABELA", val.Id_tabela);

            return executarProc("EXCLUI_LOC_TABPRECO", hs);
        }
    }
}
