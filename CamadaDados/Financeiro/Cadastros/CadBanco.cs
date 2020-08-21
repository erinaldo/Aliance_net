using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadBanco : List<TRegistro_CadBanco>, IComparer<TRegistro_CadBanco>
    {
        #region IComparer<TRegistro_CadBanco> Members
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

        public TList_CadBanco()
        { }

        public TList_CadBanco(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadBanco value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadBanco x, TRegistro_CadBanco y)
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
    
    
    public class TRegistro_CadBanco
    {
        
        public string Cd_banco 
        { get; set; }
        public string Digito
        {
            get
            {
                if (Cd_banco.Trim().Equals(string.Empty))
                    return string.Empty;
                else
                    return Estruturas.Mod11(Cd_banco, 9, false, 0).ToString();
            }
        }
        
        public string Ds_banco 
        { get; set; }
        
        public decimal Bordainferior
        { get; set; }
        
        public TRegistro_CadBanco()
        {
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.Bordainferior = decimal.Zero;
        }
    }

    public class TCD_CadBanco : TDataQuery
    {
        public TCD_CadBanco()
        { }

        public TCD_CadBanco(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.cd_banco, a.ds_banco, a.bordainferior ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_banco a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CadBanco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadBanco lista = new TList_CadBanco();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadBanco reg = new TRegistro_CadBanco();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("BordaInferior")))
                        reg.Bordainferior = reader.GetDecimal(reader.GetOrdinal("BordaInferior"));

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

        public string GravarBanco(TRegistro_CadBanco val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_DS_BANCO", val.Ds_banco);
            hs.Add("@P_BORDAINFERIOR", val.Bordainferior);

            return this.executarProc("IA_FIN_BANCO", hs);
        }

        public string DeletarBanco(TRegistro_CadBanco val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FIN_BANCO", hs);
        }
    }
}
