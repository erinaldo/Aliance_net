using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_Moeda : List<TRegistro_Moeda>, IComparer<TRegistro_Moeda>
    {
        #region IComparer<TRegistro_Moeda> Members
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

        public TList_Moeda()
        { }

        public TList_Moeda(System.ComponentModel.PropertyDescriptor Prop,
                           System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Moeda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Moeda x, TRegistro_Moeda y)
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
    
    public class TRegistro_Moeda
    {
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda_singular
        { get; set; }
        public string Ds_moeda_plural
        { get; set; }
        public string Sigla
        { get; set; }
        public string St_registro
        { get; set; }

        public TRegistro_Moeda()
        {
            this.Cd_moeda = string.Empty;
            this.Ds_moeda_plural = string.Empty;
            this.Ds_moeda_singular = string.Empty;
            this.Sigla = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_Moeda : TDataQuery
    {
        public TCD_Moeda()
        { }

        public TCD_Moeda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_moeda, a.ds_moeda_singular, ");
                sql.AppendLine("a.ds_moeda_plural, a.sigla, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_moeda a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Moeda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Moeda lista = new TList_Moeda();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Moeda reg = new TRegistro_Moeda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular"))))
                        reg.Ds_moeda_singular = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Plural"))))
                        reg.Ds_moeda_plural = reader.GetString(reader.GetOrdinal("DS_Moeda_Plural"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla"))))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string GravarMoeda(TRegistro_Moeda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_DS_MOEDA_SINGULAR", val.Ds_moeda_singular);
            hs.Add("@P_DS_MOEDA_PLURAL", val.Ds_moeda_plural);
            hs.Add("@P_SIGLA", val.Sigla);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_MOEDA", hs);
        }

        public string DeletarMoeda(TRegistro_Moeda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);

            return this.executarProc("EXCLUI_FIN_MOEDA", hs);
        }
    }
}
