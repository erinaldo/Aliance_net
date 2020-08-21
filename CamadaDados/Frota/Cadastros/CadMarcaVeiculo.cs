using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    #region Marca Veiculo

    public class TList_CadMarcaVeiculo : List<TRegistro_CadMarcaVeiculo>, IComparer<TRegistro_CadMarcaVeiculo>
    {

        #region IComparer<TRegistro_CadMarcaVeiculo> Members
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

        public TList_CadMarcaVeiculo()
        { }

        public TList_CadMarcaVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadMarcaVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadMarcaVeiculo x, TRegistro_CadMarcaVeiculo y)
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

    
    public class TRegistro_CadMarcaVeiculo
    {
        private decimal? id_marca;
        
        public decimal? Id_marca
        {
            get { return id_marca; }
            set
            {
                id_marca = value;
                id_marcastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_marcastr;
        
        public string Id_marcastr
        {
            get { return id_marcastr; }
            set
            {
                id_marcastr = value;
                try
                {
                    id_marca = Convert.ToDecimal(value);
                }
                catch
                { id_marca = null; }
            }
        }
        
        public string Ds_marca
        { get; set; }

        public TRegistro_CadMarcaVeiculo()
        {
            this.id_marca = null;
            this.id_marcastr = string.Empty;
            this.Ds_marca = string.Empty;
        }
    }

    public class TCD_CadMarcaVeiculo : TDataQuery
    {
        public TCD_CadMarcaVeiculo()
        { }

        public TCD_CadMarcaVeiculo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_marca, a.ds_marca ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_marcaveiculo a ");


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

        public TList_CadMarcaVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadMarcaVeiculo lista = new TList_CadMarcaVeiculo();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadMarcaVeiculo reg = new TRegistro_CadMarcaVeiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_marca")))
                        reg.Id_marca = reader.GetDecimal(reader.GetOrdinal("id_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                   
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

        public string Gravar(TRegistro_CadMarcaVeiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_MARCA", val.Id_marca);
            hs.Add("@P_DS_MARCA", val.Ds_marca);
           

            return this.executarProc("IA_FRT_MARCAVEICULO", hs);
        }

        public string Excluir(TRegistro_CadMarcaVeiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_MARCA", val.Id_marca);

            return this.executarProc("EXCLUI_FRT_MARCAVEICULO", hs);
        }


    }

    #endregion
}
