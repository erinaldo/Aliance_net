using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using System.Data;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadTipoServico : List<TRegistro_CadTipoServico>, IComparer<TRegistro_CadTipoServico>
    {
        #region IComparer<TRegistro_CadTipoServico> Members
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

        public TList_CadTipoServico()
        { }

        public TList_CadTipoServico(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTipoServico value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTipoServico x, TRegistro_CadTipoServico y)
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

    
    public class TRegistro_CadTipoServico
    {
        public string Id_tpservico
        { get; set; }
        public string Ds_tpservico
        { get; set; }
        public decimal PC_IBPT
        { get; set; }

        public TRegistro_CadTipoServico()
        {
            this.Id_tpservico = string.Empty;
            this.Ds_tpservico = string.Empty;
            this.PC_IBPT = decimal.Zero;
        }
    }

    public class TCD_CadTipoServico : TDataQuery
    {
        public TCD_CadTipoServico()
        { }

        public TCD_CadTipoServico(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_tpservico, a.ds_tpservico, a.PC_IBPT ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_TipoServico a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.id_tpservico asc");
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

        public TList_CadTipoServico Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTipoServico lista = new TList_CadTipoServico();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTipoServico reg = new TRegistro_CadTipoServico();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpservico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("id_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpservico")))
                        reg.Ds_tpservico = reader.GetString(reader.GetOrdinal("ds_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_IBPT")))
                        reg.PC_IBPT = reader.GetDecimal(reader.GetOrdinal("PC_IBPT"));
                    
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

        public string Gravar(TRegistro_CadTipoServico val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TPSERVICO", val.Id_tpservico);
            hs.Add("@P_DS_TPSERVICO", val.Ds_tpservico);
            hs.Add("@P_PC_IBPT", val.PC_IBPT);

            return this.executarProc("IA_EST_TIPOSERVICO", hs);
        }

        public string Excluir(TRegistro_CadTipoServico val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TPSERVICO", val.Id_tpservico);

            return this.executarProc("EXCLUI_EST_TIPOSERVICO", hs);
        }
    }
}
