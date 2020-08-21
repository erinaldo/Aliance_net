using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{
    public class TRegistro_CadCondFiscalProduto
    {
        public string CD_CONDFISCAL_PRODUTO { get; set; }
        public string DS_CONDFISCAL_PRODUTO { get; set; }
        public string Cd_Ds { get { return this.CD_CONDFISCAL_PRODUTO.Trim() + " - " + DS_CONDFISCAL_PRODUTO.Trim(); } }
        public string ST_REGISTRO { get; set; }
        public bool St_agregar { get; set; }

        public TRegistro_CadCondFiscalProduto()
        {
            this.CD_CONDFISCAL_PRODUTO = string.Empty;
            this.DS_CONDFISCAL_PRODUTO = string.Empty;
            this.ST_REGISTRO = "A";
            this.St_agregar = false;
        }
    }

    public class TList_CadCondFiscalProduto : List<TRegistro_CadCondFiscalProduto>, IComparer<TRegistro_CadCondFiscalProduto>
    {
        #region IComparer<TRegistro_CadCondFiscalProduto> Members
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

        public TList_CadCondFiscalProduto()
        { }

        public TList_CadCondFiscalProduto(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadCondFiscalProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadCondFiscalProduto x, TRegistro_CadCondFiscalProduto y)
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
    
    public class TCD_CadCondFiscalProduto : TDataQuery
    {
        public TList_CadCondFiscalProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCondFiscalProduto lista = new TList_CadCondFiscalProduto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadCondFiscalProduto reg = new TRegistro_CadCondFiscalProduto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CONDFISCAL_PRODUTO"))))
                        reg.CD_CONDFISCAL_PRODUTO = reader.GetString(reader.GetOrdinal("CD_CONDFISCAL_PRODUTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CONDFISCAL_PRODUTO"))))
                        reg.DS_CONDFISCAL_PRODUTO = reader.GetString(reader.GetOrdinal("DS_CONDFISCAL_PRODUTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_REGISTRO"))))
                        reg.ST_REGISTRO = reader.GetString(reader.GetOrdinal("ST_REGISTRO"));
                    
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

        public TCD_CadCondFiscalProduto()
        { }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select "+strTop+" a.CD_CondFiscal_Produto, a.DS_CondFiscal_Produto, a.ST_Registro ");
                       
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_CondFiscal_Produto a ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public string GravarFisProduto(TRegistro_CadCondFiscalProduto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.CD_CONDFISCAL_PRODUTO);
            hs.Add("@P_DS_CONDFISCAL_PRODUTO", val.DS_CONDFISCAL_PRODUTO);
            hs.Add("@P_ST_REGISTRO", val.ST_REGISTRO);

            return executarProc("IA_FIS_CONDFISCAL_PRODUTO", hs);
        }
        
        public string DeletarFisProduto(TRegistro_CadCondFiscalProduto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_CONDFISCAL_PRODUTO", val.CD_CONDFISCAL_PRODUTO);

            return executarProc("EXCLUI_FIS_CONDFISCAL_PRODUTO", hs);
        }
    }
}
