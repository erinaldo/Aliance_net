using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Almoxarifado
{
    public class TRegistro_CadAlmoxarifado
    {
        private decimal? id_almox;
        
        public decimal? Id_almox 
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxString = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private string id_almoxString;
        
        public string Id_almoxString 
        {
            get { return id_almoxString; }
            set
            {
                id_almoxString = value;
                try { id_almox = decimal.Parse(value); }
                catch { id_almox = null; }
            }
        }

        public string Ds_almoxarifado 
        { get; set; }

        public TRegistro_CadAlmoxarifado()
        {
            id_almox = null;
            id_almoxString = string.Empty;
            Ds_almoxarifado = string.Empty;
        }   
    }

    public class TList_CadAlmoxarifado : List<TRegistro_CadAlmoxarifado>, IComparer<TRegistro_CadAlmoxarifado>
    {
        #region IComparer<TRegistro_CadAlmoxarifado> Members
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

        public TList_CadAlmoxarifado()
        { }

        public TList_CadAlmoxarifado(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadAlmoxarifado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadAlmoxarifado x, TRegistro_CadAlmoxarifado y)
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

    public class TCD_CadAlmoxarifado  : TDataQuery
    {
        public TCD_CadAlmoxarifado()
        { }

        public TCD_CadAlmoxarifado(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.id_almox , a.ds_almoxarifado ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_AMX_ALMOXARIFADO a");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = "and";
                }
            return sql.ToString();
        }

        public TList_CadAlmoxarifado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadAlmoxarifado lista = new TList_CadAlmoxarifado();
            SqlDataReader reader =null ;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAlmoxarifado reg = new TRegistro_CadAlmoxarifado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Almox"))))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("Id_Almox"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Almoxarifado"))))
                        reg.Ds_almoxarifado = reader.GetString(reader.GetOrdinal("DS_Almoxarifado"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_CadAlmoxarifado val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ALMOX", val.Id_almox);
            hs.Add("@P_DS_ALMOXARIFADO", val.Ds_almoxarifado);

            return executarProc("IA_AMX_ALMOXARIFADO", hs);
        }

        public string Excluir(TRegistro_CadAlmoxarifado val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ALMOX", val.Id_almox);            

            return executarProc("EXCLUI_AMX_ALMOXARIFADO", hs);
        }
    }
}
