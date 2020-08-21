using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadAssistenteVenda : List<TRegistro_CadAssistenteVenda>, IComparer<TRegistro_CadAssistenteVenda>
    {
        #region IComparer<TRegistro_CadAssistenteVenda> Members
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

        public TList_CadAssistenteVenda()
        { }

        public TList_CadAssistenteVenda(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadAssistenteVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadAssistenteVenda x, TRegistro_CadAssistenteVenda y)
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

    
    public class TRegistro_CadAssistenteVenda
    {
        
        public string CD_Produto 
        { get; set; }
        
        public string DS_Produto 
        { get; set; }
        
        public string CD_ProdVenda
        { get; set; }
        
        public string DS_ProdVenda
        { get; set; }
        
        public string NCM
        { get; set; }
        
        public string CD_Unidade
        { get; set; }
        
        public string DS_Unidade
        { get; set; }
        
        public string Sigla_Unidade
        { get; set; }
        
        public string DS_Marca
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        
        public decimal Quantidade 
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public decimal Vl_desconto { get; set; }

        public TRegistro_CadAssistenteVenda()
        {
            this.CD_Produto = string.Empty;
            this.DS_Produto = string.Empty;
            this.CD_ProdVenda = string.Empty;
            this.DS_ProdVenda = string.Empty;
            this.NCM = string.Empty;
            this.CD_Unidade = string.Empty;
            this.DS_Unidade = string.Empty;
            this.Sigla_Unidade = string.Empty;
            this.DS_Marca = string.Empty;
            this.Vl_unitario = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.St_processar = false;
        }

    }

    public class TCD_CadAssistenteVenda : TDataQuery
    {
        public TCD_CadAssistenteVenda()
        { }

        public TCD_CadAssistenteVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_produto, b.ds_produto, marca.DS_Marca, ");
                sql.AppendLine("a.cd_prodVenda, c.ds_produto as ds_prodVenda, a.quantidade, c.NCM, c.CD_Unidade, d.DS_Unidade, d.Sigla_Unidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_ASSISTENTEVENDA a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_prodVenda = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("left outer join tb_est_marca marca ");
            sql.AppendLine("on marca.cd_marca = c.cd_marca ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadAssistenteVenda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadAssistenteVenda lista = new TList_CadAssistenteVenda();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAssistenteVenda reg = new TRegistro_CadAssistenteVenda();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_prodVenda")))
                        reg.CD_ProdVenda = reader.GetString(reader.GetOrdinal("cd_prodVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_prodVenda")))
                        reg.DS_ProdVenda = reader.GetString(reader.GetOrdinal("ds_prodVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NCM")))
                        reg.NCM = reader.GetString(reader.GetOrdinal("NCM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.CD_Unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.DS_Unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Marca")))
                        reg.DS_Marca = reader.GetString(reader.GetOrdinal("DS_Marca"));
                   
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

        public string Grava(TRegistro_CadAssistenteVenda vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_PRODVENDA", vRegistro.CD_ProdVenda);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
           
            return this.executarProc("IA_EST_ASSISTENTEVENDA", hs);
        }

        public string Deleta(TRegistro_CadAssistenteVenda vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_PRODVENDA", vRegistro.CD_ProdVenda);

            return this.executarProc("EXCLUI_EST_ASSISTENTEVENDA", hs);
        }

    }
}
