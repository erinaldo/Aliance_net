using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_Despesa : List<TRegistro_Despesa>, IComparer<TRegistro_Despesa>
    {
        #region IComparer<TRegistro_Despesa> Members
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

        public TList_Despesa()
        { }

        public TList_Despesa(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Despesa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Despesa x, TRegistro_Despesa y)
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
    
    public class TRegistro_Despesa
    {
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        private string tp_despesa;
        public string Tp_despesa
        {
            get { return tp_despesa; }
            set
            {
                tp_despesa = value;
                if (value.Trim().ToUpper().Equals("DV"))
                    tipo_despesa = "DESPESA VIAGEM";
                else if (value.Trim().ToUpper().Equals("MV"))
                    tipo_despesa = "MANUTENÇÃO/DESPESA VEICULO";
                else if (value.Trim().ToUpper().Equals("AB"))
                    tipo_despesa = "ABASTECIMENTO";
                else if (value.Trim().ToUpper().Equals("MI"))
                    tipo_despesa = "MANUTENÇÃO INTERNA";
                else if (value.Trim().ToUpper().Equals("IF"))
                    tipo_despesa = "INFRAÇÃO";
            }
        }
        private string tipo_despesa;
        public string Tipo_despesa
        {
            get { return tipo_despesa; }
            set
            {
                tipo_despesa = value;
                if (value.Trim().ToUpper().Equals("DESPESA VIAGEM"))
                    tp_despesa = "DV";
                else if (value.Trim().ToUpper().Equals("MANUTENÇÃO/DESPESA VEICULO"))
                    tp_despesa = "MV";
                else if (value.Trim().ToUpper().Equals("ABASTECIMENTO"))
                    tp_despesa = "AB";
                else if (value.Trim().ToUpper().Equals("MANUTENÇÃO INTERNA"))
                    tp_despesa = "MI";
                else if (value.Trim().ToUpper().Equals("INFRAÇÃO"))
                    tp_despesa = "IF";
            }
        }

        public TRegistro_Despesa()
        {
            this.id_despesa = null;
            this.id_despesastr = string.Empty;
            this.Ds_despesa = string.Empty;
            this.tp_despesa = string.Empty;
            this.tipo_despesa = string.Empty;
        }
    }

    public class TCD_Despesa : TDataQuery
    {
        public TCD_Despesa()
        { }

        public TCD_Despesa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_despesa, a.ds_despesa, a.tp_despesa ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Despesa a ");

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
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Despesa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Despesa lista = new TList_Despesa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Despesa reg = new TRegistro_Despesa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_despesa")))
                        reg.Tp_despesa = reader.GetString(reader.GetOrdinal("tp_despesa"));

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

        public string Gravar(TRegistro_Despesa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_DS_DESPESA", val.Ds_despesa);
            hs.Add("@P_TP_DESPESA", val.Tp_despesa);

            return this.executarProc("IA_FRT_DESPESA", hs);
        }

        public string Excluir(TRegistro_Despesa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);

            return this.executarProc("EXCLUI_FRT_DESPESA", hs);
        }
    }
}
