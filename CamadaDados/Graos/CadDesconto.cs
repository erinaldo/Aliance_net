using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_CadDesconto : List<TRegistro_CadDesconto>, IComparer<TRegistro_CadDesconto>
    {
        #region IComparer<TRegistro_CadDesconto> Members
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

        public TList_CadDesconto()
        { }

        public TList_CadDesconto(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadDesconto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadDesconto x, TRegistro_CadDesconto y)
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

    
    public class TRegistro_CadDesconto 
    {
        public string CD_Desconto{ get; set;}
        public string DS_Desconto{ get;set;}
        public string Padrao_Qualidade { get; set; }
        public string ST_Registro{ get;  set;}

        public TRegistro_CadDesconto()
        {
            this.CD_Desconto = string.Empty;
            this.DS_Desconto = string.Empty;
            this.Padrao_Qualidade = string.Empty;
            this.ST_Registro = "A";
        }
    }

    public class TCD_CadDesconto : TDataQuery
    {
        public TCD_CadDesconto()
        { }

        public TCD_CadDesconto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("SELECT " + strTop + "a.cd_tabeladesconto, a.ds_tabeladesconto, a.Padrao_qualidade, a.st_registro");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_gro_tabeladesconto a");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadDesconto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadDesconto lista = new TList_CadDesconto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadDesconto reg = new TRegistro_CadDesconto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabeladesconto")))
                        reg.CD_Desconto = reader.GetString(reader.GetOrdinal("cd_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabeladesconto")))
                        reg.DS_Desconto = reader.GetString(reader.GetOrdinal("ds_tabeladesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Padrao_qualidade")))
                        reg.Padrao_Qualidade = reader.GetString(reader.GetOrdinal("Padrao_qualidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    
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
      
        public string Gravar(TRegistro_CadDesconto vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_Desconto);
            hs.Add("@P_DS_TABELADESCONTO", vRegistro.DS_Desconto);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            hs.Add("@P_PADRAO_QUALIDADE",vRegistro.Padrao_Qualidade);
            return this.executarProc("IA_GRO_TABELADESCONTO", hs);
        }

        public string Excluir(TRegistro_CadDesconto vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_Desconto);
            return this.executarProc("EXCLUI_GRO_TABELADESCONTO", hs);
        }
    }
}
