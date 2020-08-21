using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Utils;

namespace CamadaDados.Balanca
{
    public class TList_ProdutoDerivado : List<TRegistro_ProdutoDerivado>, IComparer<TRegistro_ProdutoDerivado>
    {
        #region IComparer<TRegistro_ProdutoDerivado> Members
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

        public TList_ProdutoDerivado()
        { }

        public TList_ProdutoDerivado(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ProdutoDerivado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ProdutoDerivado x, TRegistro_ProdutoDerivado y)
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

    [DataContract]
    public class TRegistro_ProdutoDerivado
    {
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Nm_empresa
        { get; set; }
        [DataMember]
        public decimal? Id_ticket
        { get; set; }
        [DataMember]
        public string Tp_pesagem
        { get; set; }
        [DataMember]
        public string Cd_produto
        { get; set; }
        [DataMember]
        public string Ds_produto
        { get; set; }
        [DataMember]
        public decimal Qtd_embalagem
        { get; set; }

        public TRegistro_ProdutoDerivado()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_ticket = null;
            this.Tp_pesagem = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Qtd_embalagem = decimal.Zero;
        }
    }

    public class TCD_ProdutoDerivado : TDataQuery
    {
        public TCD_ProdutoDerivado()
        { }

        public TCD_ProdutoDerivado(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_ticket, ");
                sql.AppendLine("a.tp_pesagem, a.cd_produto, c.ds_produto, a.qtd_embalagem ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_bal_produtoderivado a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");

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

        public TList_ProdutoDerivado SelectProdDeriv(string vNr_contrato,
                                                      string vCd_empresa,
                                                      string vTp_pesagem,
                                                      string vId_ticket)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_produto, b.ds_produto, ");
            sql.AppendLine("qtd_embalagem = isnull((select sum(isnull(x.qtd_embalagem, 0)) ");
            sql.AppendLine("						from tb_bal_produtoderivado x ");
            sql.AppendLine("                        where x.cd_produto = a.cd_produto ");
            sql.AppendLine("						and x.cd_empresa = '" + vCd_empresa.Trim() + "' ");
            sql.AppendLine("						and x.tp_pesagem = '" + vTp_pesagem.Trim() + "' ");
            sql.AppendLine("						and x.id_ticket = " + vId_ticket + "), 0) ");
            sql.AppendLine("from tb_gro_contrato_x_pedidoitem a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("where a.nr_contrato = " + vNr_contrato);
            sql.AppendLine("and not exists(select 1 from tb_bal_psgraos x ");
            sql.AppendLine("				where x.nr_contrato = a.nr_contrato ");
            sql.AppendLine("				and x.nr_pedidounico = a.nr_pedido ");
            sql.AppendLine("				and x.cd_produto = a.cd_produto ");
            sql.AppendLine("				and x.cd_empresa = '" + vCd_empresa.Trim() + "' ");
            sql.AppendLine("				and x.tp_pesagem = '" + vTp_pesagem.Trim() + "' ");
            sql.AppendLine("				and x.id_ticket = " + vId_ticket + ")");

            bool st_transacao = false;
            TList_ProdutoDerivado lista = new TList_ProdutoDerivado();
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProdutoDerivado reg = new TRegistro_ProdutoDerivado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Embalagem")))
                        reg.Qtd_embalagem = reader.GetDecimal(reader.GetOrdinal("QTD_Embalagem"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }

        public TList_ProdutoDerivado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ProdutoDerivado lista = new TList_ProdutoDerivado();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProdutoDerivado reg = new TRegistro_ProdutoDerivado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Embalagem")))
                        reg.Qtd_embalagem = reader.GetDecimal(reader.GetOrdinal("QTD_Embalagem"));

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

        public string Gravar(TRegistro_ProdutoDerivado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QTD_EMBALAGEM", val.Qtd_embalagem);

            return this.executarProc("IA_BAL_PRODUTODERIVADO", hs);
        }

        public string Excluir(TRegistro_ProdutoDerivado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_BAL_PRODUTODERIVADO", hs);
        }
    }
}
