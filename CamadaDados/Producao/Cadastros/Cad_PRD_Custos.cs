using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_Cad_PRD_Custos : List<TRegistro_Cad_PRD_Custos>, IComparer<TRegistro_Cad_PRD_Custos>
    {
        #region IComparer<TRegistro_Cad_PRD_Custos> Members
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

        public TList_Cad_PRD_Custos()
        { }

        public TList_Cad_PRD_Custos(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cad_PRD_Custos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cad_PRD_Custos x, TRegistro_Cad_PRD_Custos y)
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

    
    public class TRegistro_Cad_PRD_Custos
    {
        private decimal? id_custo;
        
        public decimal? Id_custo
        {
            get { return id_custo; }
            set
            {
                id_custo = value;
                id_custostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_custostr;
        
        public string Id_custostr
        {
            get { return id_custostr; }
            set
            {
                id_custostr = value;
                try
                {
                    id_custo = decimal.Parse(value);
                }
                catch
                { id_custo = null; }
            }
        }
        
        public string Ds_custo
        { get; set; }
        private string tp_custo;
        
        public string Tp_custo
        {
            get { return tp_custo; }
            set 
            { 
                tp_custo = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_custo = "FIXO";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_custo = "VARIAVEL";
            }
        }
        private string tipo_custo;
        
        public string Tipo_custo
        {
            get { return tipo_custo; }
            set 
            { 
                tipo_custo = value;
                if (value.Trim().ToUpper().Equals("FIXO"))
                    tp_custo = "F";
                else if (value.Trim().ToUpper().Equals("VARIAVEL"))
                    tp_custo = "V";
            }
        }

        public TRegistro_Cad_PRD_Custos()
        {
            this.id_custo = null;
            this.id_custostr = string.Empty;
            this.Ds_custo = string.Empty;
            this.tp_custo = string.Empty;
            this.tipo_custo = string.Empty;
        }
    }

    public class TCD_Cad_PRD_Custos : TDataQuery
    {
        public TCD_Cad_PRD_Custos()
        { }

        public TCD_Cad_PRD_Custos(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " id_custo, ds_custo, tp_custo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_prd_custos ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_PRD_Custos Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_PRD_Custos lista = new TList_Cad_PRD_Custos();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Cad_PRD_Custos reg = new TRegistro_Cad_PRD_Custos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Custo"))))
                        reg.Id_custo = reader.GetDecimal(reader.GetOrdinal("ID_Custo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Custo"))))
                        reg.Ds_custo = reader.GetString(reader.GetOrdinal("DS_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Custo")))
                        reg.Tp_custo = reader.GetString(reader.GetOrdinal("TP_Custo"));
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

        public string Gravar(TRegistro_Cad_PRD_Custos val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            hs.Add("@P_DS_CUSTO", val.Ds_custo);
            hs.Add("@P_TP_CUSTO", val.Tp_custo);

            return this.executarProc("IA_PRD_CUSTOS", hs);
        }

        public string Excluir(TRegistro_Cad_PRD_Custos val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CUSTO", val.Id_custo);

            return this.executarProc("EXCLUI_PRD_CUSTOS", hs);
        }
    }
}
