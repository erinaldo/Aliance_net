using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Graos
{
    public class TList_LanAplicacaoPedido : List<TRegistro_LanAplicacaoPedido>
    { }

    public class TRegistro_LanAplicacaoPedido
    {
        private decimal id_aplicacao;
        public decimal Id_aplicacao
        {
            get { return id_aplicacao; }
            set { id_aplicacao = value; }
        }

        private decimal nr_pedido;
        public decimal Nr_pedido
        {
            get { return nr_pedido; }
            set { nr_pedido = value; }
        }

        private string cd_produto;
        public string Cd_produto
        {
            get { return cd_produto; }
            set { cd_produto = value; }
        }

        private string ds_produto;
        public string Ds_produto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }

        private string cd_empresa;
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }

        private string nm_empresa;
        public string Nm_empresa
        {
            get { return nm_empresa; }
            set { nm_empresa = value; }
        }

        private decimal id_lanctoestoque;
        public decimal Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set { id_lanctoestoque = value; }
        }

        private decimal id_ticket;
        public decimal Id_ticket
        {
            get { return id_ticket; }
            set { id_ticket = value; }
        }

        private string tp_pesagem;
        public string Tp_pesagem
        {
            get { return tp_pesagem; }
            set { tp_pesagem = value; }
        }

        private decimal id_item;
        public decimal Id_item
        {
            get { return id_item; }
            set { id_item = value; }
        }

        private decimal id_desdobro;
        public decimal Id_desdobro
        {
            get { return id_desdobro; }
            set { id_desdobro = value; }
        }

        private decimal qtd_aplicado;
        public decimal Qtd_aplicado
        {
            get { return qtd_aplicado; }
            set { qtd_aplicado = value; }
        }

        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }

        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return vl_subtotal; }
            set { vl_subtotal = value; }
        }

        private decimal cd_autoriz;
        public decimal Cd_autoriz
        {
            get { return cd_autoriz; }
            set { cd_autoriz = value; }
        }

        private decimal vl_taxasecagem;
        public decimal Vl_taxasecagem
        {
            get { return vl_taxasecagem; }
            set { vl_taxasecagem = value; }
        }

        public TRegistro_LanAplicacaoPedido()
        {
            this.id_aplicacao = 0;
            this.nr_pedido = 0;
            this.cd_produto = "";
            this.ds_produto = "";
            this.cd_empresa = "";
            this.nm_empresa = "";
            this.id_lanctoestoque = 0;
            this.id_ticket = 0;
            this.id_item = 0;
            this.tp_pesagem = "";
            this.id_desdobro = 0;
            this.qtd_aplicado = 0;
            this.vl_unitario = 0;
            this.vl_subtotal = 0;
            this.cd_autoriz = 0;
            this.vl_taxasecagem = 0;
        }
    }

    public class TCD_LanAplicacaoPedido : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.Append("Select " + strTop + " a.ID_Aplicacao, a.CD_Empresa, a.CD_Produto, a.Nr_Pedido, ");
                sql.Append("a.Id_LanctoEstoque, a.ID_Ticket, a.Tp_Pesagem, a.QTD_Aplicado, ");
                sql.Append("a.Vl_Unitario, a.Vl_SubTotal, b.NM_Empresa, c.DS_Produto ");
            }
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            sql.Append("FROM TB_BAL_Aplicacao_Pedido AS a INNER JOIN ");
            sql.Append("TB_DIV_Empresa AS b ON a.CD_Empresa = b.CD_Empresa INNER JOIN ");
            sql.Append("TB_EST_Produto AS c ON a.CD_Produto = c.CD_Produto ");
            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_LanAplicacaoPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanAplicacaoPedido lista = new TList_LanAplicacaoPedido();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_LanAplicacaoPedido lanAplicacao = new TRegistro_LanAplicacaoPedido();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Aplicacao")))
                        lanAplicacao.Id_aplicacao = reader.GetDecimal(reader.GetOrdinal("ID_Aplicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        lanAplicacao.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        lanAplicacao.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        lanAplicacao.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        lanAplicacao.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        lanAplicacao.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque"))))
                        lanAplicacao.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        lanAplicacao.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        lanAplicacao.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        lanAplicacao.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Desdobro"))))
                        lanAplicacao.Id_desdobro = reader.GetDecimal(reader.GetOrdinal("ID_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Aplicado"))))
                        lanAplicacao.Qtd_aplicado = reader.GetDecimal(reader.GetOrdinal("QTD_Aplicado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Unitario"))))
                        lanAplicacao.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal"))))
                        lanAplicacao.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Autoriz"))))
                        lanAplicacao.Cd_autoriz = reader.GetDecimal(reader.GetOrdinal("CD_Autoriz"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_TaxaSecagem"))))
                        lanAplicacao.Vl_taxasecagem = reader.GetDecimal(reader.GetOrdinal("Vl_TaxaSecagem"));
                    lista.Add(lanAplicacao);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }
        /*
        public string GravarAplicacao(TRegistro_LanAplicacaoPedido val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_PC_RESULTADO", val.Pc_resultado);
            hs.Add("@P_PS_RENDA_INI", val.Ps_renda_ini);
            hs.Add("@P_PS_RENDA_FIN", val.Ps_renda_fin);
            return executarProc("IA_GRO_RENDA", hs);
        }

        public string DeletarAplicacao(TRegistro_LanAplicacaoPedido val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_PC_RESULTADO", val.Pc_resultado);
            return this.executarProc("EXCLUI_GRO_RENDA", hs);
        }*/
    }
}
