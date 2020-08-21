using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Almoxarifado
{
    public class TList_CadRua : List<TRegistro_CadRua>, IComparer<TRegistro_CadRua>
    {
        #region IComparer<TRegistro_CadRua> Members
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

        public TList_CadRua()
        { }

        public TList_CadRua(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadRua value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadRua x, TRegistro_CadRua y)
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

    
    public class TRegistro_CadRua
    {
        private decimal? id_rua;
        
        public decimal? Id_rua
        {
            get { return id_rua; }
            set 
            {
                id_rua = value;
                id_ruastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ruastr;
        
        public string Id_ruastr
        {
            get { return id_ruastr; }
            set 
            {
                id_ruastr = value;
                try
                {
                    id_rua = Convert.ToDecimal(value);
                }
                catch
                { id_rua = null; }
            }
        }
        
        public string Ds_rua{ get; set; }

        public TRegistro_CadRua()
        {
            id_rua = null;
            id_ruastr = string.Empty;
            Ds_rua = string.Empty;
        }
    }

    public class TCD_CadRua : TDataQuery
    {
        public TCD_CadRua()
        { }

        public TCD_CadRua(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine(" Select " + strTop + " a.id_rua, a.ds_rua ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNm_Campo + " ");

            sql.AppendLine("From tb_amx_rua  a ");

            string cond = "where";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ") ");
                    cond = "and";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadRua Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadRua lista = new TList_CadRua();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadRua reg = new TRegistro_CadRua();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Rua"))))
                        reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("Id_Rua"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_Rua"))))
                        reg.Ds_rua = reader.GetString(reader.GetOrdinal("Ds_Rua"));
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

        public string Gravar(TRegistro_CadRua val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_RUA", val.Id_rua);
            hs.Add("@P_DS_RUA", val.Ds_rua);

            return executarProc("IA_AMX_RUA", hs);
        }

        public string Excluir(TRegistro_CadRua val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_RUA", val.Id_rua);

            return executarProc("EXCLUI_AMX_RUA", hs);
        }
    }
}

