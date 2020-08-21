using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Pedido
{
    public class TList_ReservaPedido : List<TRegistro_ReservaPedido>
    { }

    
    public class TRegistro_ReservaPedido
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Qtd_reservada
        { get; set; }
        
        public decimal Qtd_saidaest
        { get; set; }
        
        public decimal Qtd_entradaest
        { get; set; }
        
        public decimal Qtd_saldoreserva
        { get; set; }

        public TRegistro_ReservaPedido()
        {
            this.Cd_empresa = string.Empty;
            this.Nr_pedido = null;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Qtd_reservada = decimal.Zero;
            this.Qtd_saidaest = decimal.Zero;
            this.Qtd_entradaest = decimal.Zero;
            this.Qtd_saldoreserva = decimal.Zero;
        }
    }

    public class TCD_ReservaPedido : TDataQuery
    {
        public TCD_ReservaPedido()
        { }

        public TCD_ReservaPedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.nr_pedido, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, c.sigla_unidade, ");
                sql.AppendLine("a.qtd_reservada, a.qtd_saidaest, a.qtd_entradaest, a.qtd_saldoreserva ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_RESERVAESTPEDIDO a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
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
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ReservaPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ReservaPedido lista = new TList_ReservaPedido();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReservaPedido reg = new TRegistro_ReservaPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Reservada")))
                        reg.Qtd_reservada = reader.GetDecimal(reader.GetOrdinal("QTD_Reservada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaidaEst")))
                        reg.Qtd_saidaest = reader.GetDecimal(reader.GetOrdinal("QTD_SaidaEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_EntradaEst")))
                        reg.Qtd_entradaest = reader.GetDecimal(reader.GetOrdinal("QTD_EntradaEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaldoReserva")))
                        reg.Qtd_saldoreserva = reader.GetDecimal(reader.GetOrdinal("QTD_SaldoReserva"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }
    }
}
