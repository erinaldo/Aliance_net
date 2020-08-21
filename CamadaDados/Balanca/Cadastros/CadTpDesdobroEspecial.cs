using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Balanca.Cadastros
{
    public class TList_TpDesdobroEspecial : List<TRegistro_TpDesdobroEspecial>, IComparer<TRegistro_TpDesdobroEspecial>
    {
        #region IComparer<TRegistro_TpDesdobroEspecial> Members
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

        public TList_TpDesdobroEspecial()
        { }

        public TList_TpDesdobroEspecial(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_TpDesdobroEspecial value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_TpDesdobroEspecial x, TRegistro_TpDesdobroEspecial y)
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

    
    public class TRegistro_TpDesdobroEspecial
    {
        private decimal? id_tpdesdobro;
        
        public decimal? Id_tpdesdobro
        {
            get { return id_tpdesdobro; }
            set
            {
                id_tpdesdobro = value;
                id_tpdesdobrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpdesdobrostr;
        
        public string Id_tpdesdobrostr
        {
            get { return id_tpdesdobrostr; }
            set
            {
                id_tpdesdobrostr = value;
                try
                {
                    id_tpdesdobro = Convert.ToDecimal(value);
                }
                catch
                { id_tpdesdobro = null; }
            }
        }
        
        public string Ds_tpdesdobro
        { get; set; }
        
        public decimal Pc_desdobro
        { get; set; }
        private string tp_pesodesdobro;
        
        public string Tp_pesodesdobro
        {
            get { return tp_pesodesdobro; }
            set
            {
                tp_pesodesdobro = value;
                if (value.Trim().ToUpper().Equals("B"))
                    tipo_pesodesdobro = "PESO BRUTO";
                else if (value.Trim().ToUpper().Equals("L"))
                    tipo_pesodesdobro = "PESO LIQUIDO";
            }
        }
        private string tipo_pesodesdobro;
        
        public string Tipo_pesodesdobro
        {
            get { return tipo_pesodesdobro; }
            set
            {
                tipo_pesodesdobro = value;
                if (value.Trim().ToUpper().Equals("PESO BRUTO"))
                    tp_pesodesdobro = "B";
                else if (value.Trim().ToUpper().Equals("PESO LIQUIDO"))
                    tp_pesodesdobro = "L";
            }
        }

        public TRegistro_TpDesdobroEspecial()
        {
            this.id_tpdesdobro = null;
            this.id_tpdesdobrostr = string.Empty;
            this.Ds_tpdesdobro = string.Empty;
            this.Pc_desdobro = decimal.Zero;
            this.tp_pesodesdobro = string.Empty;
            this.tipo_pesodesdobro = string.Empty;
        }
    }

    public class TCD_TpDesdobroEspecial : TDataQuery
    {
        public TCD_TpDesdobroEspecial()
        { }

        public TCD_TpDesdobroEspecial(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_tpdesdobro, a.ds_tpdesdobro, a.pc_desdobro, a.tp_pesodesdobro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_tpdesdobroespecial a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_TpDesdobroEspecial Select(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_TpDesdobroEspecial lista = new TList_TpDesdobroEspecial();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TpDesdobroEspecial reg = new TRegistro_TpDesdobroEspecial();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_tpdesdobro"))))
                        reg.Id_tpdesdobro = reader.GetDecimal(reader.GetOrdinal("id_tpdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdesdobro")))
                        reg.Ds_tpdesdobro = reader.GetString(reader.GetOrdinal("ds_tpdesdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("pc_desdobro"))))
                        reg.Pc_desdobro = reader.GetDecimal(reader.GetOrdinal("pc_desdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pesodesdobro")))
                        reg.Tp_pesodesdobro = reader.GetString(reader.GetOrdinal("tp_pesodesdobro"));

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

        public string Gravar(TRegistro_TpDesdobroEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_TPDESDOBRO", val.Id_tpdesdobro);
            hs.Add("@P_DS_TPDESDOBRO", val.Ds_tpdesdobro);
            hs.Add("@P_PC_DESDOBRO", val.Pc_desdobro);
            hs.Add("@P_TP_PESODESDOBRO", val.Tp_pesodesdobro);

            return this.executarProc("IA_BAL_TPDESDOBROESPECIAL", hs);
        }

        public string Excluir(TRegistro_TpDesdobroEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_TPDESDOBRO", val.Id_tpdesdobro);

            return this.executarProc("EXCLUI_BAL_TPDESDOBROESPECIAL", hs);
        }
    }
}
