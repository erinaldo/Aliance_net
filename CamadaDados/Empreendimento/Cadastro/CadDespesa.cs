using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BancoDados;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TList_CadDespesa : List<TRegistro_CadDespesa>, IComparer<TRegistro_CadDespesa>
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

        public TList_CadDespesa()
        { }

        public TList_CadDespesa(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadDespesa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadDespesa x, TRegistro_CadDespesa y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }

    public class TRegistro_CadDespesa
    {
        private decimal? id_despesa = null;
        public decimal? Id_despesa 
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr = string.Empty;
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
                catch { id_despesa = null; }
            }
        }
        public string Ds_despesa { get; set; } = string.Empty;
        public string Cd_unidade { get; set; } = string.Empty;
        public string Ds_unidade { get; set; } = string.Empty;
        public string Sigla_unidade { get; set; } = string.Empty;
        public decimal Pc_margemcont { get; set; } = decimal.Zero;
        public bool st_agregar { get; set; } = false;
    }

    public class TCD_CadDespesa : TDataQuery
    {
        public TCD_CadDespesa()
        { }

        public TCD_CadDespesa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_despesa, a.DS_despesa, a.pc_margemcont ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_EMP_CadDespesa a ");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_CadDespesa Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadDespesa lista = new TList_CadDespesa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadDespesa reg = new TRegistro_CadDespesa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("DS_despesa"));
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

        public string Grava(TRegistro_CadDespesa vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_DESPESA", vRegistro.Id_despesa );
            hs.Add("@P_DS_DESPESA", vRegistro.Ds_despesa);
            //hs.Add("@P_CD_UNIDADE", vRegistro.Cd_unidade);
            hs.Add("@P_PC_MARGEMCONT", vRegistro.Pc_margemcont);

            return this.executarProc("IA_EMP_CadDespesa", hs);
        }

        public string Deleta(TRegistro_CadDespesa vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_DESPESA", vRegistro.Id_despesa);

            return this.executarProc("EXCLUI_EMP_CadDespesa", hs);
        }
    }
    



}
