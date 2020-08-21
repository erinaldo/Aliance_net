using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_Apontamento_Estoque : List<TRegistro_Apontamento_Estoque>
    { }

    public class TRegistro_Apontamento_Estoque
    {
        public decimal? Id_apontamento
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        public decimal Vl_custocontabil
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Qtd_entrada
        { get; set; }
        public decimal Qtd_saida
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public DateTime? Dt_lancamento
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }

        public TRegistro_Apontamento_Estoque()
        {
            this.Id_apontamento = null;
            this.Cd_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Id_lanctoestoque = null;
            this.Vl_custocontabil = decimal.Zero;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Qtd_entrada = decimal.Zero;
            this.Qtd_saida = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Dt_lancamento = null;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
        }
    }

    public class TCD_Apontamento_Estoque : TDataQuery
    {
        public TCD_Apontamento_Estoque()
        {}

        public TCD_Apontamento_Estoque(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_apontamento, a.cd_empresa, ");
                sql.AppendLine("a.cd_produto, a.id_lanctoestoque, c.ds_produto, ");
                sql.AppendLine("d.sigla_unidade, b.qtd_entrada, b.qtd_saida, ");
                sql.AppendLine("b.vl_unitario, b.vl_subtotal, b.dt_lancto, ");
                sql.AppendLine("b.cd_local, e.ds_local, a.vl_custocontabil ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_apontamento_x_estoque a ");
            sql.AppendLine("inner join tb_est_estoque b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.cd_produto = b.cd_produto ");
            sql.AppendLine("and a.id_lanctoestoque = b.id_lanctoestoque ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm e ");
            sql.AppendLine("on b.cd_local = e.cd_local ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Apontamento_Estoque Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Apontamento_Estoque lista = new TList_Apontamento_Estoque();
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
                    TRegistro_Apontamento_Estoque reg = new TRegistro_Apontamento_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entrada")))
                        reg.Qtd_entrada = reader.GetDecimal(reader.GetOrdinal("QTD_Entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Saida")))
                        reg.Qtd_saida = reader.GetDecimal(reader.GetOrdinal("QTD_Saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.Dt_lancamento = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_CustoContabil")))
                        reg.Vl_custocontabil = reader.GetDecimal(reader.GetOrdinal("Vl_CustoContabil"));

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

        public string GravarApontamentoEstoque(TRegistro_Apontamento_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_VL_CUSTOCONTABIL", val.Vl_custocontabil);

            return this.executarProc("IA_PRD_APONTAMENTO_X_ESTOQUE", hs);
        }

        public string DeletarApontamentoEstoque(TRegistro_Apontamento_Estoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return this.executarProc("EXCLUI_PRD_APONTAMENTO_X_ESTOQUE", hs);
        }
    }
}
