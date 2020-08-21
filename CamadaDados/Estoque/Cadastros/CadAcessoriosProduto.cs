using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadAcessoriosProduto : List<TRegistro_CadAcessoriosProduto>, IComparer<TRegistro_CadAcessoriosProduto>
    {
        #region IComparer<TRegistro_CadAcessoriosProduto> Members
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

        public TList_CadAcessoriosProduto()
        { }

        public TList_CadAcessoriosProduto(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadAcessoriosProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadAcessoriosProduto x, TRegistro_CadAcessoriosProduto y)
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

    
    public class TRegistro_CadAcessoriosProduto
    {
        
        public decimal Id_Acessorio
        {
            get;
            set;
        }
        
        public string cd_produto { get; set; }
        
        public string ds_Acessorio { get; set; }
        
        public string Ds_produto { get; set; }
        
        public bool St_adicionar { get; set; }

        public TRegistro_CadAcessoriosProduto()
        {
            this.Id_Acessorio = decimal.Zero;
            this.cd_produto = string.Empty;
            this.ds_Acessorio = string.Empty;
            this.Ds_produto = string.Empty;
            this.St_adicionar = false;
        }

    }
    public class TCD_CadAcessoriosProduto : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop) + " ";
            StringBuilder sql = new StringBuilder();
            if (vNm_Campo.Length == 0)
            {

                sql.AppendLine("Select " + strTop + " a.id_Acessorio,a.ds_Acessorio,b.cd_produto,b.ds_Produto ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
            sql.AppendLine("From tb_est_Acessorios_Produto a");
            sql.AppendLine("inner join tb_Est_Produto b on a.cd_Produto = b.Cd_Produto");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, ""), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_CadAcessoriosProduto Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadAcessoriosProduto lista = new TList_CadAcessoriosProduto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAcessoriosProduto reg = new TRegistro_CadAcessoriosProduto();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_Acessorio")))
                        reg.Id_Acessorio = reader.GetDecimal(reader.GetOrdinal("id_Acessorio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_Acessorio"))))
                        reg.ds_Acessorio= reader.GetString(reader.GetOrdinal("Ds_Acessorio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_Produto"))))
                        reg.cd_produto= reader.GetString(reader.GetOrdinal("cd_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_Produto"));
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
        public string GravaCadAcessoriosProduto(TRegistro_CadAcessoriosProduto val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_ACESSORIO", val.Id_Acessorio);
            hs.Add("@P_DS_ACESSORIO", val.ds_Acessorio);
            hs.Add("@P_CD_PRODUTO", val.cd_produto);

            return this.executarProc("IA_EST_ACESSORIOS_PRODUTOS", hs);
        }
        public string DeletaCadAcessoriosProduto(TRegistro_CadAcessoriosProduto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ACESSORIO", val.Id_Acessorio);
            hs.Add("@P_CD_PRODUTO", val.cd_produto);
            return this.executarProc("EXCLUI_EST_ACESSORIOS_PRODUTO", hs);
        }
    }
}
