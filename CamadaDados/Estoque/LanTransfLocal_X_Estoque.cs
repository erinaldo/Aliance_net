using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque
{
    public class TList_LanTransfLocal_X_Estoque : List<TRegistro_LanTransfLocal_X_Estoque>, IComparer<TRegistro_LanTransfLocal_X_Estoque>
    {
        #region IComparer<TRegistro_LanTransfLocal_X_Estoque> Members
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

        public TList_LanTransfLocal_X_Estoque()
        { }

        public TList_LanTransfLocal_X_Estoque(System.ComponentModel.PropertyDescriptor Prop,
                                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanTransfLocal_X_Estoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanTransfLocal_X_Estoque x, TRegistro_LanTransfLocal_X_Estoque y)
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
    
    public class TRegistro_LanTransfLocal_X_Estoque
    {
        
        public decimal Id_transf
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_produto 
        { get; set; }
        
        public string Ds_produto
        {get;set;}
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Id_lanctoestoque
        { get; set; }
        
        public decimal Qtd_entrada 
        { get; set; }
        
        public decimal Qtd_saida 
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        

        public TRegistro_LanTransfLocal_X_Estoque()
        {
            this.Id_transf = 0;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Id_lanctoestoque = decimal.Zero;
            this.Qtd_entrada = decimal.Zero;
            this.Qtd_saida = decimal.Zero;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.Ds_observacao = string.Empty;
        }
    }

    public class TCD_LanTransfLocal_X_Estoque : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.id_transf, a.cd_empresa, a.cd_produto, a.id_lanctoEstoque, ");
                sql.AppendLine("b.ds_produto, c.nm_empresa, a.id_lanctoEstoque, d.ds_observacao, ");
                sql.AppendLine("d.qtd_entrada, d.cd_local as cd_LocalOrigem, d.qtd_saida, e.ds_local as ds_localorigem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_EST_TransfLocal_X_Estoque a ");
            sql.AppendLine("left outer join tb_div_empresa c ");
            sql.AppendLine("on c.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join tb_est_produto b ");
            sql.AppendLine("on b.cd_produto = a.cd_produto ");
            sql.AppendLine("left outer join tb_est_estoque d ");
            sql.AppendLine("on d.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and d.cd_produto = a.cd_produto ");
            sql.AppendLine("and d.id_lanctoestoque = a.id_lanctoestoque ");
            sql.AppendLine("left outer join TB_EST_LocalArm e ");
            sql.AppendLine("on e.cd_local = d.cd_local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.id_transf asc");
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

        public TList_LanTransfLocal_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanTransfLocal_X_Estoque lista = new TList_LanTransfLocal_X_Estoque();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanTransfLocal_X_Estoque reg = new TRegistro_LanTransfLocal_X_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entrada")))
                        reg.Qtd_entrada = reader.GetDecimal(reader.GetOrdinal("QTD_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Saida")))
                        reg.Qtd_saida = reader.GetDecimal(reader.GetOrdinal("QTD_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LocalOrigem")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_LocalOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LocalOrigem")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_LocalOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));

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

        public string Grava(TRegistro_LanTransfLocal_X_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_TRANSF", vRegistro.Id_transf);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa.Trim());
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto.Trim());
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.Id_lanctoestoque);
            
            return this.executarProc("IA_EST_TRANSFLOCAL_X_ESTOQUE", hs);
        }
    }
}
