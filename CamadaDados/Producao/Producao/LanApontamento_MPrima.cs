using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_Apontamento_MPrima : List<TRegistro_Apontamento_MPrima>, IComparer<TRegistro_Apontamento_MPrima>
    {
        #region IComparer<TRegistro_Apontamento_MPrima> Members
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

        public TList_Apontamento_MPrima()
        { }

        public TList_Apontamento_MPrima(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Apontamento_MPrima value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Apontamento_MPrima x, TRegistro_Apontamento_MPrima y)
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

    
    public class TRegistro_Apontamento_MPrima
    {
        
        public decimal Id_apontamento
        { get; set; }
        
        public decimal Id_mprima
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidestoque
        { get; set; }
        
        public string Ds_unidestoque
        { get; set; }
        
        public string Sg_unidestoque
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sg_unidade
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public decimal Qtd_produto
        { get; set; }
        
        public decimal Pc_quebratec
        { get; set; }
        
        public decimal Vl_complementoEstoqueCTRC
        { get; set; }
        
        public decimal? Id_apontamentomprima
        { get; set; }

        public TRegistro_Apontamento_MPrima()
        {
            Id_apontamento = decimal.Zero;
            Id_mprima = decimal.Zero;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidestoque = string.Empty;
            Ds_unidestoque = string.Empty;
            Sg_unidestoque = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sg_unidade = string.Empty;
            Qtd_produto = decimal.Zero;
            Pc_quebratec = decimal.Zero;
            Vl_complementoEstoqueCTRC = decimal.Zero;
            Id_apontamentomprima = null;
        }
    }

    public class TCD_Apontamento_MPrima : TDataQuery
    {
        public TCD_Apontamento_MPrima()
        { }

        public TCD_Apontamento_MPrima(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_apontamento, a.id_mprima, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, b.cd_unidade as CD_UnidEstoque, ");
                sql.AppendLine("c.ds_unidade as ds_unidestoque, c.sigla_unidade as sg_unidestoque, ");
                sql.AppendLine("a.cd_unidade, d.ds_unidade, d.sigla_unidade, a.id_apontamentomprima, ");
                sql.AppendLine("a.cd_local, e.ds_local, a.qtd_produto, a.pc_quebratec ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_apontamento_mprima a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on a.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm e ");
            sql.AppendLine("on a.cd_local = e.cd_local ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Apontamento_MPrima Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Apontamento_MPrima lista = new TList_Apontamento_MPrima();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Apontamento_MPrima reg = new TRegistro_Apontamento_MPrima();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MPrima")))
                        reg.Id_mprima = reader.GetDecimal(reader.GetOrdinal("ID_MPrima"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidEstoque")))
                        reg.Cd_unidestoque = reader.GetString(reader.GetOrdinal("CD_UnidEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UnidEstoque")))
                        reg.Ds_unidestoque = reader.GetString(reader.GetOrdinal("DS_UnidEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sg_unidestoque")))
                        reg.Sg_unidestoque = reader.GetString(reader.GetOrdinal("Sg_unidestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Produto")))
                        reg.Qtd_produto = reader.GetDecimal(reader.GetOrdinal("QTD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_QuebraTec")))
                        reg.Pc_quebratec = reader.GetDecimal(reader.GetOrdinal("PC_QuebraTec"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ApontamentoMPrima")))
                        reg.Id_apontamentomprima = reader.GetDecimal(reader.GetOrdinal("ID_ApontamentoMPrima"));

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

        public string Gravar(TRegistro_Apontamento_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_ID_MPRIMA", val.Id_mprima);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ID_APONTAMENTOMPRIMA", val.Id_apontamentomprima);
            hs.Add("@P_QTD_PRODUTO", val.Qtd_produto);
            hs.Add("@P_PC_QUEBRATEC", val.Pc_quebratec);

            return executarProc("IA_PRD_APONTAMENTO_MPRIMA", hs);
        }

        public string Excluir(TRegistro_Apontamento_MPrima val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_ID_MPRIMA", val.Id_mprima);

            return executarProc("EXCLUI_PRD_APONTAMENTO_MPRIMA", hs);
        }
    }
}
