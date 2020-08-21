using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Servicos
{
    public class TList_Servico_X_PedidoItem : List<TRegistro_Servico_X_PedidoItem>
    { }
    
    public class TRegistro_Servico_X_PedidoItem
    {
        public decimal? Id_os
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public decimal? Id_pedidoitem
        { get; set; }
        private string tp_pedido;
        public string Tp_pedido
        {
            get { return tp_pedido; }
            set
            {
                tp_pedido = value;
                if (value.Trim().ToUpper().Equals("IT"))
                    tipo_pedido = "ITEM";
                else if (value.Trim().ToUpper().Equals("SV"))
                    tipo_pedido = "SERVICO";
                else if (value.Trim().ToUpper().Equals("GR"))
                    tipo_pedido = "GARANTIA";
                else if (value.Trim().ToUpper().Equals("RM"))
                    tipo_pedido = "REMESSA";
            }
        }
        private string tipo_pedido;
        public string Tipo_pedido
        {
            get { return tipo_pedido; }
            set
            {
                tipo_pedido = value;
                if (value.Trim().ToUpper().Equals("ITEM"))
                    tp_pedido = "IT";
                else if (value.Trim().ToUpper().Equals("SERVICO"))
                    tp_pedido = "SV";
                else if (value.Trim().ToUpper().Equals("GARANTIA"))
                    tp_pedido = "GR";
                else if (value.Trim().ToUpper().Equals("REMESSA"))
                    tp_pedido = "RM";
            }
        }

        public TRegistro_Servico_X_PedidoItem()
        {
            this.Id_os = null;
            this.Cd_empresa = string.Empty;
            this.Nr_pedido = null;
            this.Cd_produto = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Id_pedidoitem = null;
            this.tp_pedido = string.Empty;
            this.tipo_pedido = string.Empty;
        }
    }

    public class TCD_Servico_X_PedidoItem : TDataQuery
    {
        public TCD_Servico_X_PedidoItem()
        { }

        public TCD_Servico_X_PedidoItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.id_os, a.cd_empresa, ");
                sql.AppendLine("a.nr_pedido, a.cd_produto, a.id_pedidoitem, ");
                sql.AppendLine("b.cd_condfiscal_produto, a.tp_pedido ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_OSE_Servico_X_PedidoItem a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Servico_X_PedidoItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Servico_X_PedidoItem lista = new TList_Servico_X_PedidoItem();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Servico_X_PedidoItem reg = new TRegistro_Servico_X_PedidoItem();
                    //Dados da OS
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pedido"))))
                        reg.Tp_pedido = reader.GetString(reader.GetOrdinal("TP_Pedido"));

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

        public string GravarServicoXPedidoItem(TRegistro_Servico_X_PedidoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_TP_PEDIDO", val.Tp_pedido);

            return this.executarProc("IA_OSE_SERVICO_X_PEDIDOITEM", hs);
        }

        public string DeletarServicoXPedidoItem(TRegistro_Servico_X_PedidoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("EXCLUI_OSE_SERVICO_X_PEDIDOITEM", hs);
        }
    }
}
