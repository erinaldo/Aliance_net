using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.NotaFiscal
{
    #region Faturamento_Item_X_Estoque
    public class TList_Faturamento_Item_X_Estoque : List<TRegistro_Faturamento_Item_X_Estoque>
    { }

    public class TRegistro_Faturamento_Item_X_Estoque
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        public decimal? Id_entrega
        { get; set; }
        public decimal? Id_transf
        { get; set; }
        
        public TRegistro_Faturamento_Item_X_Estoque()
        {
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Id_nfitem = null;
            Cd_produto = string.Empty;
            Id_lanctoestoque = null;
            Id_entrega = null;
            Id_transf = null;
        }
    }

    public class TCD_Faturamento_Item_X_Estoque : TDataQuery
    {
        public TCD_Faturamento_Item_X_Estoque()
        { }

        public TCD_Faturamento_Item_X_Estoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select "+strTop + " a.cd_empresa, a.nr_lanctofiscal, ");
                sql.AppendLine("a.id_nfitem, a.cd_produto, a.id_lanctoestoque, a.id_entrega, a.Id_transf ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_NotaFiscal_Item_X_Estoque a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Faturamento_Item_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Faturamento_Item_X_Estoque lista = new TList_Faturamento_Item_X_Estoque();
            SqlDataReader reader = null;

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Faturamento_Item_X_Estoque LanPedido_Item_Estoque = new TRegistro_Faturamento_Item_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        LanPedido_Item_Estoque.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        LanPedido_Item_Estoque.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        LanPedido_Item_Estoque.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        LanPedido_Item_Estoque.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        LanPedido_Item_Estoque.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Entrega")))
                        LanPedido_Item_Estoque.Id_entrega = reader.GetDecimal(reader.GetOrdinal("ID_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_transf")))
                        LanPedido_Item_Estoque.Id_transf = reader.GetDecimal(reader.GetOrdinal("Id_transf"));

                    lista.Add(LanPedido_Item_Estoque);
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

        public string GravarFaturamentoItem_X_Estoque(TRegistro_Faturamento_Item_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_ENTREGA", val.Id_entrega);
            hs.Add("@P_ID_TRANSF", val.Id_transf);

            return this.executarProc("INCLUI_FAT_NOTAFISCAL_ITEM_X_ESTOQUE", hs);
        }

        public string DeletarFaturamentoItem_X_Estoque(TRegistro_Faturamento_Item_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_FAT_NOTAFISCAL_ITEM_X_ESTOQUE", hs);
        }
    }
    #endregion

    #region NFAcessorios_X_Estoque
    public class TList_NFAcessorios_X_Estoque : List<TRegistro_NFAcessorios_X_Estoque>
    { }

    public class TRegistro_NFAcessorios_X_Estoque
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        public decimal Quantidade
        { get; set; }

        public TRegistro_NFAcessorios_X_Estoque()
        {
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Cd_produto = string.Empty;
            Cd_local = string.Empty;
            Id_lanctoestoque = null;
            Quantidade = decimal.Zero;
        }
    }

    public class TCD_NFAcessorios_X_Estoque : TDataQuery
    {
        public TCD_NFAcessorios_X_Estoque()
        { }

        public TCD_NFAcessorios_X_Estoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.nr_lanctofiscal, ");
                sql.AppendLine("a.cd_produto, a.id_lanctoestoque ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_NFAcessorios_X_Estoque a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_NFAcessorios_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_NFAcessorios_X_Estoque lista = new TList_NFAcessorios_X_Estoque();
            SqlDataReader reader = null;

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_NFAcessorios_X_Estoque LanPedido_Item_Estoque = new TRegistro_NFAcessorios_X_Estoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        LanPedido_Item_Estoque.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        LanPedido_Item_Estoque.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        LanPedido_Item_Estoque.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        LanPedido_Item_Estoque.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));

                    lista.Add(LanPedido_Item_Estoque);
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

        public string GravarNFAcessorios_X_Estoque(TRegistro_NFAcessorios_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("IA_FAT_NFACESSORIOS_X_ESTOQUE", hs);
        }

        public string DeletarNFAcessorios_X_Estoque(TRegistro_NFAcessorios_X_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_FAT_NFACESSORIOS_X_ESTOQUE", hs);
        }
    }
    #endregion
}
