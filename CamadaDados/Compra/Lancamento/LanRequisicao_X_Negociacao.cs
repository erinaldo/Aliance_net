using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_Requisicao_X_Negociacao : List<TRegistro_Requisicao_X_Negociacao>
    { }

    
    public class TRegistro_Requisicao_X_Negociacao:TRegistro_NegociacaoItem
    {
        
        public decimal? Id_requisicao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        private string st_negreq;
        
        public string St_NegReq
        {
            get
            {
                if (st_negreq.Trim().ToUpper().Equals("A"))
                    return "APROVADA";
                else if (st_negreq.Trim().ToUpper().Equals("R"))
                    return "REPROVADA";
                else
                    return string.Empty;
            }
            set
            {
                st_negreq = value;
            }
        }

        public TRegistro_Requisicao_X_Negociacao()
        {
            this.Id_requisicao = null;
            this.Cd_empresa = string.Empty;
            this.st_negreq = "S";
        }
    }

    public class TCD_Requisicao_X_Negociacao : TDataQuery
    {
        public TCD_Requisicao_X_Negociacao()
        { }

        public TCD_Requisicao_X_Negociacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_negociacao, a.id_item, a.cd_fornecedor, ");
                sql.AppendLine("b.nm_clifor as nm_fornecedor, a.cd_condpgto, c.ds_condpgto, a.nm_vendedor, ");
                sql.AppendLine("a.email_vendedor, a.fonefax, a.qtd_porcompra, ");
                sql.AppendLine("a.qtd_min_compra, a.vl_unitario_negociado, ");
                sql.AppendLine("a.ds_observacao, a.nr_diasvigencia, a.cd_endfornecedor, ");
                sql.AppendLine("a.cd_moeda, f.ds_moeda_singular, f.sigla, endFor.ds_endereco as ds_endfornecedor, ");
                sql.AppendLine("a.cd_portador, g.ds_portador, a.st_depositarpagto, ");
                sql.AppendLine("x.id_requisicao, x.cd_empresa, x.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_negociacao_item a ");
            sql.AppendLine("inner join tb_cmp_requisicao_x_negociacao x ");
            sql.AppendLine("on a.id_negociacao = x.id_negociacao ");
            sql.AppendLine("and a.id_item = x.id_item ");
            sql.AppendLine("inner join vtb_fin_clifor b ");
            sql.AppendLine("on a.cd_fornecedor = b.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco endFor ");
            sql.AppendLine("on a.cd_fornecedor = endFor.cd_clifor ");
            sql.AppendLine("and a.cd_endfornecedor = endFor.cd_endereco ");
            sql.AppendLine("inner join tb_fin_condpgto c ");
            sql.AppendLine("on a.cd_condpgto = c.cd_condpgto ");
            sql.AppendLine("inner join tb_cmp_negociacao d ");
            sql.AppendLine("on a.id_negociacao = d.id_negociacao ");
            sql.AppendLine("left outer join tb_fin_moeda f ");
            sql.AppendLine("on a.cd_moeda = f.cd_moeda ");
            sql.AppendLine("left outer join tb_fin_portador g ");
            sql.AppendLine("on a.cd_portador = g.cd_portador ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Requisicao_X_Negociacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Requisicao_X_Negociacao lista = new TList_Requisicao_X_Negociacao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Requisicao_X_Negociacao reg = new TRegistro_Requisicao_X_Negociacao();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Requisicao"))))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_Requisicao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Negociacao"))))
                        reg.Id_negociacao = reader.GetDecimal(reader.GetOrdinal("ID_Negociacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor"))))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor"))))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndFornecedor")))
                        reg.Cd_endfornecedor = reader.GetString(reader.GetOrdinal("CD_EndFornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndFornecedor")))
                        reg.Ds_endfornecedor = reader.GetString(reader.GetOrdinal("DS_EndFornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_condpgto"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email_vendedor")))
                        reg.Email_vendedor = reader.GetString(reader.GetOrdinal("Email_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FoneFax")))
                        reg.FoneFax = reader.GetString(reader.GetOrdinal("FoneFax"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Min_Compra")))
                        reg.Qtd_min_compra = reader.GetDecimal(reader.GetOrdinal("QTD_Min_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_porCompra")))
                        reg.Qtd_porcompra = reader.GetDecimal(reader.GetOrdinal("QTD_porCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario_Negociado")))
                        reg.Vl_unitario_negociado = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario_Negociado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasVigencia")))
                        reg.Nr_diasvigencia = reader.GetDecimal(reader.GetOrdinal("NR_DiasVigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_DepositarPagto")))
                        reg.St_depositarpagto = reader.GetString(reader.GetOrdinal("ST_DepositarPagto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_NegReq = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string GravarRequisicao_X_Negociacao(TRegistro_Requisicao_X_Negociacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ST_REGISTRO", val.St_NegReq);

            return this.executarProc("IA_CMP_REQUISICAO_X_NEGOCIACAO", hs);
        }

        public string DeletarRequisicao_X_Negociacao(TRegistro_Requisicao_X_Negociacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_CMP_REQUISICAO_X_NEGOCIACAO", hs);
        }
    }
}
