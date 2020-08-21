using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_OrdemCompra : List<TRegistro_OrdemCompra>
    { }

    
    public class TRegistro_OrdemCompra
    {
        
        public decimal? Id_oc
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_requisicao;
        
        public decimal? Id_requisicao
        {
            get { return id_requisicao; }
            set
            {
                id_requisicao = value;
                id_requisicaostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_requisicaostr;
        
        public string Id_requisicaostr
        {
            get { return id_requisicaostr; }
            set
            {
                id_requisicaostr = value;
                try
                {
                    id_requisicao = Convert.ToDecimal(value);
                }
                catch
                { id_requisicao = null; }
            }
        }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public decimal? Id_pedidoitem
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Cd_fornecedor
        { get; set; }
        
        public string Nm_fornecedor
        { get; set; }
        
        public string Cd_endfornecedor
        { get; set; }
        
        public string Ds_endfornecedor
        { get; set; }
        
        public string Cd_condpgto
        { get; set; }
        
        public string Ds_condpgto
        { get; set; }
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }
        
        public string Cd_moedacompra
        { get; set; }
        
        public string Ds_moedacompra
        { get; set; }
        
        public string Siglacompra
        { get; set; }
        
        public string St_utilizarmoedaoc
        { get; set; }
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        
        public string Cd_transportadora
        { get; set; }
        
        public string Nm_transportadora
        { get; set; }
        
        public string Cd_endtransportadora
        { get; set; }
        
        public string Ds_endtransportadora
        { get; set; }
        private string tp_frete;
        
        public string Tp_frete
        {
            get { return tp_frete; }
            set
            {
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_frete = "EMITENTE";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_frete = "DESTINATARIO";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_frete = "TERCEIRO";
                else if (value.Trim().ToUpper().Equals("9"))
                    tipo_frete = "SEM FRETE";
            }
        }
        private string tipo_frete;
        
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("EMITENTE"))
                    tp_frete = "0";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_frete = "1";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_frete = "2";
                else if (value.Trim().ToUpper().Equals("SEM FRETE"))
                    tp_frete = "9";
            }
        }
        public decimal Vl_frete
        { get; set; }
        public decimal Prazo_entrega
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        private decimal vl_unitario;
        
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        public decimal Vl_subtotal
        { get { return Quantidade * Vl_unitario; } }
        public decimal Vl_Convertido
        {
            get
            {
                if ((Cd_moedacompra.Trim() != Cd_moeda.Trim()) && (Vl_cotacao > 0) && (Quantidade > 0) && (Vl_unitario > 0))
                    return Quantidade * (Vl_unitario * Vl_cotacao);
                else
                    return Vl_subtotal;
            }
        }
        public decimal Vl_unitConvertido
        {
            get
            {
                if ((Cd_moedacompra.Trim() != Cd_moeda.Trim()) && (Vl_cotacao > 0) && (Vl_unitario > 0))
                    return (Vl_unitario * Vl_cotacao);
                else
                    return Vl_unitario;
            }
        }
        private DateTime? dt_oc;
        
        public DateTime? Dt_oc
        {
            get { return dt_oc; }
            set
            {
                dt_oc = value;
                dt_ocstr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_ocstr;
        public string Dt_ocstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_ocstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ocstr = value;
                try
                {
                    dt_oc = Convert.ToDateTime(value);
                }
                catch
                { dt_oc = null; }
            }
        }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTA";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADA";
                else if (value.Trim().ToUpper().Equals("F"))
                    status = "FATURADA";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTA"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("FATURADA"))
                    st_registro = "F";
            }
        }
        
        public decimal Vl_cotacao
        { get; set; }
        public string ObsRequisicao
        { get; set; }      
        public bool St_gerarpedido
        { get; set; }

        public TRegistro_OrdemCompra()
        {
            Id_oc = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_requisicao = null;
            id_requisicaostr = string.Empty;
            Nr_pedido = null;
            Id_pedidoitem = null;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_fornecedor = string.Empty;
            Nm_fornecedor = string.Empty;
            Cd_endfornecedor = string.Empty;
            Ds_endfornecedor = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Cd_moedacompra = string.Empty;
            Ds_moedacompra = string.Empty;
            Siglacompra = string.Empty;
            St_utilizarmoedaoc = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Cd_transportadora = string.Empty;
            Nm_transportadora = string.Empty;
            Cd_endtransportadora = string.Empty;
            Ds_endtransportadora = string.Empty;
            tp_frete = "1";
            tipo_frete = "EMITENTE";
            Vl_frete = decimal.Zero;
            Prazo_entrega = decimal.Zero;
            Quantidade = decimal.Zero;
            vl_unitario = decimal.Zero;
            dt_oc = DateTime.Now;
            dt_ocstr = DateTime.Now.ToString("dd/MM/yyyy");
            st_registro = "A";
            status = "ABERTA";
            St_gerarpedido = false;
            Vl_cotacao = decimal.Zero;
        }
    }

    public class TCD_OrdemCompra : TDataQuery
    {
        public TCD_OrdemCompra()
        { }

        public TCD_OrdemCompra(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {

                sql.AppendLine("select " + strTop + " a.ID_OC, a.cd_empresa, emp.nm_empresa, a.ID_Requisicao, b.CD_Produto, ");
                sql.AppendLine("c.DS_Produto, d.Sigla_Unidade, a.CD_Fornecedor, ");
                sql.AppendLine("e.NM_Clifor as nm_fornecedor, a.CD_CondPGTO, a.vl_cotacao, ");
                sql.AppendLine("a.cd_endfornecedor, endf.ds_endereco as ds_endfornecedor, ");
                sql.AppendLine("f.DS_CondPGTO, a.CD_Moeda, g.DS_Moeda_Singular, g.Sigla, ");
                sql.AppendLine("a.CD_Portador, h.DS_Portador, a.CD_Transportadora, ");
                sql.AppendLine("i.NM_Clifor as nm_transportadora, a.tp_frete, a.vl_frete, a.DT_OC, ");
                sql.AppendLine("a.Prazo_Entrega, a.Quantidade, a.Vl_Unitario, a.ST_Registro, ");
                sql.AppendLine("a.cd_endtransportadora, endt.ds_endereco as ds_endtransportadora, ");
                sql.AppendLine("cfg.cd_moeda as cd_moedacompra, mcompra.ds_moeda_singular as ds_moedacompra, ");
                sql.AppendLine("mcompra.sigla as siglacompra, cfg.st_utilizarmoedaoc, b.DS_Observacao, ");
                sql.AppendLine("nr_pedido = (select top 1 x.nr_pedido from tb_cmp_ordemcompra_x_peditem x ");
                sql.AppendLine("            inner join tb_fat_pedido_itens y ");
                sql.AppendLine("            on x.nr_pedido = y.nr_pedido ");
                sql.AppendLine("            and x.cd_produto = y.cd_produto ");
                sql.AppendLine("            and x.id_pedidoitem = y.id_pedidoitem ");
                sql.AppendLine("            where x.id_oc = a.id_oc ");
                sql.AppendLine("            and isnull(y.st_registro, 'A') <> 'C'), ");
                sql.AppendLine("id_pedidoitem = (select top 1 x.id_pedidoitem from tb_cmp_ordemcompra_x_peditem x ");
                sql.AppendLine("                inner join tb_fat_pedido_itens y ");
                sql.AppendLine("                on x.nr_pedido = y.nr_pedido ");
                sql.AppendLine("                and x.cd_produto = y.cd_produto ");
                sql.AppendLine("                and x.id_pedidoitem = y.id_pedidoitem ");
                sql.AppendLine("                where x.id_oc = a.id_oc ");
                sql.AppendLine("                and isnull(y.st_registro, 'A') <> 'C') ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CMP_OrdemCompra a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join TB_CMP_Requisicao b ");
            sql.AppendLine("on a.ID_Requisicao = b.ID_Requisicao ");
            sql.AppendLine("and a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.CD_Unidade = d.CD_Unidade ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR e ");
            sql.AppendLine("on a.CD_Fornecedor = e.CD_Clifor ");
            sql.AppendLine("inner join vtb_fin_endereco endF ");
            sql.AppendLine("on a.cd_fornecedor = endf.cd_clifor ");
            sql.AppendLine("and a.cd_endfornecedor = endf.cd_endereco ");
            sql.AppendLine("inner join TB_FIN_CondPGTO f ");
            sql.AppendLine("on a.CD_CondPGTO = f.CD_CondPGTO ");
            sql.AppendLine("inner join TB_FIN_Moeda g ");
            sql.AppendLine("on a.CD_Moeda = g.CD_Moeda ");
            sql.AppendLine("left outer join TB_FIN_Portador h ");
            sql.AppendLine("on a.CD_Portador = h.CD_Portador ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR i ");
            sql.AppendLine("on a.CD_Transportadora = i.CD_Clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco endt ");
            sql.AppendLine("on a.cd_transportadora = endt.cd_clifor ");
            sql.AppendLine("and a.cd_endtransportadora = endt.cd_endereco ");
            sql.AppendLine("left outer join tb_cmp_cfgcompra cfg ");
            sql.AppendLine("on b.cd_empresa = cfg.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_moeda mcompra ");
            sql.AppendLine("on cfg.cd_moeda = mcompra.cd_moeda ");

            cond = " where ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
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

        public TList_OrdemCompra Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_OrdemCompra lista = new TList_OrdemCompra();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OrdemCompra reg = new TRegistro_OrdemCompra();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OC"))))
                        reg.Id_oc = reader.GetDecimal(reader.GetOrdinal("ID_OC"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Requisicao")))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_Requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_unidade"))))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor"))))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor"))))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndFornecedor")))
                        reg.Cd_endfornecedor = reader.GetString(reader.GetOrdinal("CD_EndFornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndFornecedor")))
                        reg.Ds_endfornecedor = reader.GetString(reader.GetOrdinal("DS_EndFornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_condpgto"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.ObsRequisicao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndTransportadora")))
                        reg.Cd_endtransportadora = reader.GetString(reader.GetOrdinal("CD_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndTransportadora")))
                        reg.Ds_endtransportadora = reader.GetString(reader.GetOrdinal("DS_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("prazo_entrega")))
                        reg.Prazo_entrega = reader.GetDecimal(reader.GetOrdinal("prazo_entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_OC")))
                        reg.Dt_oc = reader.GetDateTime(reader.GetOrdinal("DT_OC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_MoedaCompra")))
                        reg.Cd_moedacompra = reader.GetString(reader.GetOrdinal("CD_MoedaCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MoedaCompra")))
                        reg.Ds_moedacompra = reader.GetString(reader.GetOrdinal("DS_MoedaCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SiglaCompra")))
                        reg.Siglacompra = reader.GetString(reader.GetOrdinal("SiglaCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_UtilizarMoedaOC")))
                        reg.St_utilizarmoedaoc = reader.GetString(reader.GetOrdinal("ST_UtilizarMoedaOC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Cotacao")))
                        reg.Vl_cotacao = reader.GetDecimal(reader.GetOrdinal("Vl_Cotacao"));

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

        public string Gravar(TRegistro_OrdemCompra val)
        {
            Hashtable hs = new Hashtable(18);
            hs.Add("@P_ID_OC", val.Id_oc);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_ENDFORNECEDOR", val.Cd_endfornecedor);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_CD_ENDTRANSPORTADORA", val.Cd_endtransportadora);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_PRAZO_ENTREGA", val.Prazo_entrega);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_DT_OC", val.Dt_oc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_VL_COTACAO", val.Vl_cotacao);

            return executarProc("IA_CMP_ORDEMCOMPRA", hs);
        }

        public string Excluir(TRegistro_OrdemCompra val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_OC", val.Id_oc);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_CMP_ORDEMCOMPRA", hs);
        }
    }
}
