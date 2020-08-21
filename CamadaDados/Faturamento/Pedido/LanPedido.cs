using System;
using System.Collections.Generic;
using System.Text;
using BancoDados;
using Querys;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;

namespace CamadaDados.Faturamento.Pedido
{
    public class TList_RegLanPedido : List<TRegistro_LanPedido>
    { }    
    public class TRegistro_LanPedido
    {
        //VARIAVEIS PRIVADAS
        private string vTp_Modalidade;
        private char vTp_Movimento = 'E';
        private char vST_Registro = 'A';
        private char vST_Pedido = 'A';
        private Decimal vNr_Pedido;
        private string vNr_PedidoOrigem;
        private string vCD_Empresa;
        private string vNM_Empresa;
        private string vCFG_Pedido;
        private string vDS_CFGPedido;
        private string vCD_Endereco_Entrega;
        private string vDS_Endereco_Entrega;
        private string vCD_Clifor_Entrega;
        private string vNM_clifor_Entrega;
        private string vNR_CGCCPF;
        private string vCD_Clifor;
        private string vNM_clifor;
        private string vCD_Endereco;
        private string vDS_Endereco;
        private string vDS_Cidade;
        private string vDS_Observacao;
        private bool vTp_Entrada;
        private bool vTp_Saida;
        private TList_RegLanPedidoVenda vPedidoVenda = new TList_RegLanPedidoVenda();
        private TList_RegLanPedido_GRO vPedidoGRO = new TList_RegLanPedido_GRO();
        private TList_RegLanPedidoFiscal vPedidoFiscal = new TList_RegLanPedidoFiscal();
        private TList_RegLanPedido_Item vPedidoItens = new TList_RegLanPedido_Item();

        private string _DS_Local_Entrega;

        public string DS_Local_Entrega
        {
            get { return _DS_Local_Entrega; }
            set { _DS_Local_Entrega = value; }
        }

        private DateTime? vDT_Pedido;

        public DateTime? DT_Pedido
        {
            get { return vDT_Pedido; }
            set { vDT_Pedido = value;
                  _DT_Pedido_String = value.ToString();
            }
        }


        private string _DT_Pedido_String;

        public string DT_Pedido_String
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_DT_Pedido_String).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                _DT_Pedido_String = value;
                try
                {
                    DT_Pedido = Convert.ToDateTime(value);
                }
                catch
                { DT_Pedido = null; }
            }
        }

        private string _UF;

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }


        //PROPRIEDADES
        public Decimal Nr_Pedido 
        {
            get { return vNr_Pedido; }
            set 
            { 
                vNr_Pedido = value;
                for (int x = 0; x < vPedidoItens.Count; x++)
                {
                    vPedidoItens[x].Nr_pedido = vNr_Pedido;                
                }
                for (int x = 0; x < vPedidoFiscal.Count; x++)
                {
                    vPedidoFiscal[x].Nr_pedido = vNr_Pedido;
                }
                if (vPedidoGRO.Count > 0)
                    vPedidoGRO[0].NR_Pedido = vNr_Pedido;
            }
        }
        public string Tp_Modalidade
        {
            get
            {
                return vTp_Modalidade;
            }
            set
            {
                vTp_Modalidade = value;
            }
        }
        public string Nr_PedidoOrigem
        {
            get { return vNr_PedidoOrigem; }
            set { vNr_PedidoOrigem = value; }        
        }
        public string CD_Empresa
        {
            get { return vCD_Empresa; }
            set { vCD_Empresa = value; }
        }
        public string NM_Empresa
        {
            get { return vNM_Empresa; }
            set { vNM_Empresa = value; }
        }
        public string CFG_Pedido 
        { 
            get { return vCFG_Pedido; } set { vCFG_Pedido = value; } 
        }
        public string DS_CFGPedido
        {
            get { return vDS_CFGPedido; }
            set { vDS_CFGPedido = value; }        
        }
        public string CD_Endereco_Entrega 
        { 
            get { return vCD_Endereco_Entrega; } set { vCD_Endereco_Entrega = value; } 
        }
        public string DS_Endereco_Entrega 
        { 
            get { return vDS_Endereco_Entrega; } set { vDS_Endereco_Entrega = value; } 
        }
        public string NR_CGCCPF
        {
            get { return vNR_CGCCPF; }
            set { vNR_CGCCPF = value; }        
        }
        public string CD_Clifor_Entrega 
        { 
            get { return vCD_Clifor_Entrega; } set { vCD_Clifor_Entrega = value; } 
        }
        public string NM_clifor_Entrega 
        { 
            get { return vNM_clifor_Entrega; } set { vNM_clifor_Entrega = value; } 
        }
        public string CD_Clifor 
        { 
            get { return vCD_Clifor; } set { vCD_Clifor = value; } 
        }
        public string NM_clifor 
        { 
            get { return vNM_clifor; } set { vNM_clifor = value; } 
        }
        public string DS_Cidade
        {
            get { return vDS_Cidade; }
            set { vDS_Cidade = value; }         
        }
        public string CD_Endereco 
        { 
            get { return vCD_Endereco; } set { vCD_Endereco = value; } 
        }
        public string DS_Endereco 
        { 
            get { return vDS_Endereco; } set { vDS_Endereco = value; } 
        }
        public string DS_Observacao 
        { 
            get { return vDS_Observacao; } set { vDS_Observacao = value; } 
        }
        public char Tp_Movimento
        {
            get
            {
                if (vTp_Entrada)
                    return 'E';
                else
                    return 'S';                
            }
            set
            {
                if (value == 'E')
                {
                    vTp_Entrada = true;
                    vTp_Saida = false;
                }
                else
                {
                    vTp_Entrada = false;
                    vTp_Saida = true;
                }
                vTp_Movimento = value;
            }
        }
        public bool Tp_Entrada
        {
            get
            {
                vTp_Saida = !vTp_Entrada;
                return vTp_Entrada;
            }
            set {
                vTp_Entrada = value;
                vTp_Saida = !vTp_Entrada;
            }
        }
        public bool Tp_Saida
        {
            get
            {
                vTp_Entrada = !vTp_Saida;
                return vTp_Saida;
            }
            set 
            {
                vTp_Saida = value;
                vTp_Entrada = !vTp_Saida;
            }
        }
        
        public char ST_Registro
        {
            get
            {
                return vST_Registro;
            }
            set
            {
                value = vST_Registro;
            }
        }
        public char ST_Pedido
        {
            get
            {
                return vST_Pedido;
            }
            set
            {
                value = vST_Pedido;
            }
        }

        public TList_RegLanPedido_Item  PedidoItens
        {
            get { return vPedidoItens; }
            set { vPedidoItens = value; }        
        }
        public TList_RegLanPedidoFiscal PedidoFiscal
        {
            get { return vPedidoFiscal; }
            set { vPedidoFiscal = value; }
        }
        public TList_RegLanPedido_GRO   PedidoGRO
        {
            get { return vPedidoGRO; }
            set { vPedidoGRO = value; }
        }
        public TList_RegLanPedidoVenda  PedidoVenda
        {
            get { return vPedidoVenda; }
            set { vPedidoVenda = value; }
        }
            
    }
    public class TCD_LanPedido : TDataQuery
    {
        public TCD_LanPedido()
        { }

        public TCD_LanPedido(string vNM_SqlCodeBusca)
        {
            this.NM_ProcSqlBusca = vNM_SqlCodeBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select a.NR_Pedido, a.TP_Modalidade, a.NR_PedidoOrigem, a.CD_Empresa, e.NM_Empresa, ee.UF as UF_Empresa, a.CFG_Pedido, ");
                sql.AppendLine("a.CD_Clifor, f.NM_Clifor, f.CD_CondFiscal_Clifor, f.TP_Pessoa, a.CD_endereco, h.DS_TipoPedido, ");
                sql.AppendLine("a.CD_clifor_Entrega, a.CD_Endereco_Entrega, fe.NM_clifor as NM_clifor_Entrega, ge.DS_Endereco as DS_Endereco_Entrega, ");
                sql.AppendLine("f.TP_Pessoa, f.NR_CGC, f.NR_CPF, f.ST_Equiparado_PJ, f.ST_Agropecuaria, ");
                sql.AppendLine("g.DS_Endereco, g.CD_Cidade, g.DS_Cidade, g.UF as UF_Cliente, g.DS_UF, a.TP_Movimento, ");
                sql.AppendLine("a.DS_Observacao, h.ST_Deposito, a.DT_Pedido, a.ST_pedido, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_Pedido a ");
            sql.AppendLine(" left outer join TB_DIV_Empresa e On e.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("left outer join VTB_FIN_Endereco ee On e.CD_Clifor = ee.CD_Clifor and e.CD_Endereco = ee.CD_Endereco ");

            sql.AppendLine(" left outer join VTB_FIN_Clifor f On f.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine(" left outer join VTB_FIN_Endereco g On g.CD_Clifor = a.CD_Clifor and g.CD_Endereco = a.CD_Endereco ");

            sql.AppendLine(" left outer join VTB_FIN_Clifor fe On fe.CD_Clifor = a.CD_Clifor_Entrega ");
            sql.AppendLine(" left outer join VTB_FIN_Endereco ge On ge.CD_Clifor = a.CD_Clifor_Entrega and ge.CD_Endereco = a.CD_Endereco_Entrega ");

            sql.AppendLine(" left outer join TB_FAT_CFGPedido h On h.CFG_Pedido = a.CFG_Pedido ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            cond = " and  ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine(vGroup + " ");
            sql.AppendLine(vOrder + " ");
            return sql.ToString();
        }

        private string SqlCodeBuscaPedidoAplicacao(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select a.NR_Pedido, a.TP_Movimento, g.ST_GMO, g.TP_Natureza, ");
                sql.AppendLine("a.CD_Empresa, emp.NM_Empresa, endEmp.UF as UF_Empresa, a.CFG_Pedido, f.DS_TipoPedido, ");
                sql.AppendLine("a.ST_Registro, a.CD_Clifor, b.CD_Produto, c.DS_Produto, b.Quantidade, ");
                sql.AppendLine("b.CD_Unidade, i.Sigla_Unidade, d.CD_Unidade as CD_UnidEstoque, ");
                sql.AppendLine("d.DS_Unidade as DS_UnidEstoque, d.Sigla_Unidade as sigla_UnidEstoque, a.TP_Modalidade, g.CD_TabelaDesconto, ");
                sql.AppendLine("g.PC_PesoDesc_Deposito, g.AnoSafra, h.CD_CondPgto, e.TP_Pessoa, e.NM_Clifor, ");
                sql.AppendLine("h.CD_Historico, h.CD_Portador, h.CD_ContaGer, h.TP_Duplicata, ");
                sql.AppendLine("f.ST_Confere_Saldo, f.ST_Deposito, f.ST_ProcessaNF, f.ST_ProcessaNFAuto, f.ST_ValoresFixos, ");

                sql.AppendLine("case when isnull(g.ST_ValUnitMedio,'N') = 'N' then b.Vl_Unitario else k.Vl_Medio end as vl_Unitario, ");
                
                sql.AppendLine("Tot_Entrada = isnull((select sum(isnull(x.QTD_Entrada,0)) from TB_EST_Estoque X inner join TB_FAT_Pedido_X_Estoque y ");
                sql.AppendLine("On y.CD_Empresa = x.CD_Empresa and y.CD_Produto = x.CD_Produto and y.ID_LanctoEstoque = x.ID_LanctoEstoque ");
                sql.AppendLine("where x.cd_empresa = @CD_EMPRESA and exists(select 1 from TB_DIV_Usuario_X_Empresa  xy where xy.login = @LOGIN and xy.cd_empresa = x.cd_empresa) ");
                sql.AppendLine("and x.cd_produto = b.cd_produto and isNull(x.ST_Registro, 'A') <> 'C'" );
                sql.AppendLine("and y.nr_pedido = a.nr_pedido),0), ");

                sql.AppendLine("Tot_saida = isnull((select sum(isnull(x.QTD_Saida,0)) from TB_EST_Estoque X inner join TB_FAT_Pedido_X_Estoque y ");
                sql.AppendLine("On y.CD_Empresa = x.CD_Empresa and y.CD_Produto = x.CD_Produto and y.ID_LanctoEstoque = x.ID_LanctoEstoque ");
                sql.AppendLine("where x.cd_empresa = @CD_EMPRESA and exists(select 1 from TB_DIV_Usuario_X_Empresa  xy where xy.login = @LOGIN and xy.cd_empresa = x.cd_empresa) ");
                sql.AppendLine("and x.cd_produto = b.cd_produto and isNull(x.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("and y.nr_pedido = a.nr_pedido),0), ");

                sql.AppendLine("Tot_Aplicado = (Select isNull(sum(isNull(x.QTD_Aplicado,0)),0) From TB_BAL_Aplicacao_Pedido x inner join TB_BAL_Pesagem y ");
                sql.AppendLine("On y.CD_Empresa = x.CD_Empresa and y.ID_Ticket = x.ID_Ticket and y.TP_Pesagem = x.TP_Pesagem ");
                sql.AppendLine("Where x.NR_Pedido = a.NR_Pedido and x.CD_Empresa = a.CD_Empresa and x.CD_Produto = b.CD_Produto and isNull(y.ST_Registro, 'A') = 'F')");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_Pedido a ");
            sql.AppendLine("inner join TB_GRO_Pedido g On g.NR_Pedido = a.NR_Pedido  ");
            sql.AppendLine("inner join TB_DIV_Empresa emp On emp.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("inner join TB_FAT_Pedido_Finan h On h.NR_Pedido = a.NR_Pedido  ");
            sql.AppendLine("inner join TB_FAT_Pedido_Itens b On b.NR_Pedido = a.NR_Pedido  ");
            sql.AppendLine("inner join TB_EST_Unidade i On i.CD_Unidade = b.CD_Unidade  ");
            sql.AppendLine("inner join TB_EST_Produto c On c.CD_Produto = b.CD_Produto  ");
            sql.AppendLine("left outer join TB_EST_Unidade d On d.CD_Unidade = c.CD_Unidade  ");
            sql.AppendLine("left outer join VTB_FIN_Clifor e On e.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("left outer join TB_FAT_CFGPedido f On f.CFG_Pedido = a.CFG_Pedido  ");
            sql.AppendLine("left outer join VTB_FIN_Endereco endEmp On endEmp.CD_Clifor = emp.CD_Clifor and endEmp.CD_Endereco = emp.CD_Endereco ");
            sql.AppendLine("left outer join VTB_FAT_VLEstoque k on k.cd_empresa = b.cd_empresa and k.cd_produto = b.cd_produto and k.nr_pedido = b.nr_pedido");
                        
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') = 'A' ");

            string cond = " and  ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (vGroup.Trim() != "")
                sql.AppendLine(" Group By " + vGroup);
            sql.AppendLine(vGroup + " ");
            if (vOrder.Trim() != "")
                sql.AppendLine(" Order by " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, "", "", "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, "", "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, "", "" }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca == "")
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBuscaEscalar(sql, vParametros);
            }
        }

        public TList_RegLanPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPedido lista = new TList_RegLanPedido();
            SqlDataReader reader;
            Int64 x = 0;
            bool podeFecharBco = false;
                       
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                if (vNM_Campo == "")
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", ""));
                else
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""));

                while (reader.Read() && (x <= vTop || vTop == 0))
                {
                    TRegistro_LanPedido LanPedido = new TRegistro_LanPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                      LanPedido.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Modalidade")))
                      LanPedido.Tp_Modalidade = reader.GetString(reader.GetOrdinal("Tp_Modalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_pedidoOrigem")))
                      LanPedido.Nr_PedidoOrigem = reader.GetString(reader.GetOrdinal("Nr_pedidoOrigem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                      LanPedido.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                      LanPedido.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                      LanPedido.CFG_Pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                      LanPedido.DS_CFGPedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco_Entrega")))
                      LanPedido.CD_Endereco_Entrega = reader.GetString(reader.GetOrdinal("CD_Endereco_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco_Entrega")))
                      LanPedido.DS_Endereco_Entrega = reader.GetString(reader.GetOrdinal("DS_Endereco_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor_Entrega")))
                      LanPedido.CD_Clifor_Entrega = reader.GetString(reader.GetOrdinal("CD_Clifor_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_clifor_Entrega")))
                      LanPedido.NM_clifor_Entrega = reader.GetString(reader.GetOrdinal("NM_clifor_Entrega"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                      LanPedido.NR_CGCCPF = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                      LanPedido.NR_CGCCPF = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                      LanPedido.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                      LanPedido.NM_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                      LanPedido.CD_Endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                      LanPedido.DS_Endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                      LanPedido.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                      LanPedido.DS_Cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_movimento")))
                      LanPedido.Tp_Movimento = reader.GetString(reader.GetOrdinal("Tp_movimento"))[0];
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Pedido")))
                      LanPedido.DT_Pedido = reader.GetDateTime(reader.GetOrdinal("DT_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_pedido")))
                        LanPedido.ST_Pedido = reader.GetString(reader.GetOrdinal("ST_pedido"))[0];
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        LanPedido.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"))[0];

                    TCD_LanPedido_Item it = new TCD_LanPedido_Item();
                    TCD_LanPedido_Fiscal fs = new TCD_LanPedido_Fiscal();
                    TCD_LanPedido_GRO gr = new TCD_LanPedido_GRO();

                    TpBusca[] filtro = new TpBusca[1];
                    filtro[0].vNM_Campo = "a.Nr_Pedido";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido")).ToString();                      

                    LanPedido.PedidoItens = it.Select(filtro,0,"");
                    LanPedido.PedidoFiscal = fs.Select(filtro, 0, "");   
                //    LanPedido.PedidoGRO = gr.Select(filtro, 0, "");  //SOMENTE TERÁ (1) E APENAS 1 REGISTRO

                    lista.Add(LanPedido);
                    x++;
                }
            }
            finally
            {
                if (podeFecharBco)
                   this.deletarBanco_Dados();
            };

            return lista;        
        }

        public string Grava(TRegistro_LanPedido vRegistro)
        {
            string ret;
            string nrped;
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_NR_PEDIDO",  vRegistro.Nr_Pedido);
            hs.Add("@P_TP_MODALIDADE", vRegistro.Tp_Modalidade);
            hs.Add("@P_NR_PEDIDOORIGEM", vRegistro.Nr_PedidoOrigem);
            hs.Add("@P_CFG_PEDIDO", vRegistro.CFG_Pedido);
            hs.Add("@P_CD_ENDERECO_ENTREGA", vRegistro.CD_Endereco_Entrega);
            hs.Add("@P_CD_CLIFOR_ENTREGA", vRegistro.CD_Clifor_Entrega);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_CD_ENDERECO", vRegistro.CD_Endereco);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.Tp_Movimento);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_Observacao);
            hs.Add("@P_DT_PEDIDO", vRegistro.DT_Pedido);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);

            ret = executarProc("IA_FAT_PEDIDO", hs);
            nrped = getPubVariavel(ret, "@P_NR_PEDIDO");
            vRegistro.Nr_Pedido = Convert.ToDecimal(nrped);

            //ver onde vai gravar os itens
            if (vRegistro.PedidoItens.Count > 0)
            {
                int cont = vRegistro.PedidoItens.Count;
                TCD_LanPedido_Item item = new TCD_LanPedido_Item();
                item.Banco_Dados = this.Banco_Dados;
                for (int i = 0; i < cont; i++)
                {
                    item.Grava(vRegistro.PedidoItens[i]);
                }
            };

            return ret;
        }

        public void Deleta(TRegistro_LanPedido vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            executarProc("EXCLUI_FAT_PEDIDO", hs);
        }
    }
}
