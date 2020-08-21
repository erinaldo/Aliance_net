using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Compra
{
    public class TList_CFGCompra : List<TRegistro_CFGCompra>
    { }

    
    public class TRegistro_CFGCompra
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_requisitantepadrao
        { get; set; }
        
        public string Nm_requisitantepadrao
        { get; set; }
        
        public string Cfg_pedidocompra
        { get; set; }
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public string id_duplicata { get; set; }
        public string ds_dup { get; set; }
        public string tp_doc { get; set; }
        public string ds_doc { get; set; }


        public string Ds_tipopedidocompra
        { get; set; }
        
        public decimal Qtd_min_negociacao
        { get; set; }
        
        public decimal Qtd_min_cotacao
        { get; set; }
        private string st_gerarrequisicaoauto;
        
        public string St_gerarrequisicaoauto
        {
            get { return st_gerarrequisicaoauto; }
            set
            {
                st_gerarrequisicaoauto = value;
                st_gerarrequisicaoautobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarrequisicaoautobool;
        
        public bool St_gerarrequisicaoautobool
        {
            get { return st_gerarrequisicaoautobool; }
            set
            {
                st_gerarrequisicaoautobool = value;
                if (value)
                    st_gerarrequisicaoauto = "S";
                else
                    st_gerarrequisicaoauto = "N";
            }
        }
        private string tp_qtdreqauto;
        
        public string Tp_qtdreqauto
        {
            get { return tp_qtdreqauto; }
            set
            {
                tp_qtdreqauto = value;
                if (value.Trim().ToUpper().Equals("UV"))
                    tipo_qtdreqauto = "ULTIMA VENDA";
                else if (value.Trim().ToUpper().Equals("MV"))
                    tipo_qtdreqauto = "MEDIA VENDAS";
                else if (value.Trim().ToUpper().Equals("AM"))
                    tipo_qtdreqauto = "AJUSTAR MINIMO";
            }
        }
        private string tipo_qtdreqauto;
        
        public string Tipo_qtdreqauto
        {
            get { return tipo_qtdreqauto; }
            set
            {
                tipo_qtdreqauto = value;
                if (value.Trim().ToUpper().Equals("ULTIMA VENDA"))
                    tp_qtdreqauto = "UV";
                else if (value.Trim().ToUpper().Equals("MEDIA VENDAS"))
                    tp_qtdreqauto = "MV";
                else if (value.Trim().ToUpper().Equals("AJUSTAR MINIMO"))
                    tp_qtdreqauto = "AM";
            }
        }
        
        public decimal Nr_mesesmediavenda
        { get; set; }
        private string st_utilizarmoedaoc;
        
        public string St_utilizarmoedaoc
        {
            get { return st_utilizarmoedaoc; }
            set
            {
                st_utilizarmoedaoc = value;
                st_utilizarmoedaocbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_utilizarmoedaocbool;
        
        public bool St_utilizarmoedaocbool
        {
            get { return st_utilizarmoedaocbool; }
            set
            {
                st_utilizarmoedaocbool = value;
                if (value)
                    st_utilizarmoedaoc = "S";
                else
                    st_utilizarmoedaoc = "N";
            }
        }

        public TRegistro_CFGCompra()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_requisitantepadrao = string.Empty;
            Nm_requisitantepadrao = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cfg_pedidocompra = string.Empty;
            Ds_tipopedidocompra = string.Empty;
            Qtd_min_cotacao = decimal.Zero;
            Qtd_min_negociacao = decimal.Zero;
            st_gerarrequisicaoauto = "N";
            st_gerarrequisicaoautobool = false;
            tp_qtdreqauto = string.Empty;
            tipo_qtdreqauto = string.Empty;
            Nr_mesesmediavenda = decimal.Zero;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            st_utilizarmoedaoc = "N";
            st_utilizarmoedaocbool = false;
            id_duplicata = string.Empty;
            ds_dup = string.Empty;
            ds_doc = string.Empty;
            tp_doc = string.Empty;

        }
    }

    public class TCD_CFGCompra : TDataQuery
    {
        public TCD_CFGCompra()
        { }

        public TCD_CFGCompra(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.cd_requisitantepadrao, c.nm_clifor as nm_requisitantepadrao, ");
                sql.AppendLine("a.cd_moeda, d.ds_moeda_singular, d.sigla, a.st_utilizarmoedaoc, ");
                sql.AppendLine("a.qtd_min_cotacao, a.qtd_min_negociacao, ");
                sql.AppendLine("a.cfg_pedidocompra, e.ds_tipopedido, ");
                sql.AppendLine("a.cd_local, f.ds_local, a.st_gerarrequisicaoauto, ");
                sql.AppendLine("a.tp_qtdreqauto, a.nr_mesesmediavenda, g.tp_duplicata , g.ds_tpduplicata,h.tp_docto,h.ds_tpdocto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_cfgcompra a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_requisitantepadrao = c.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_moeda d ");
            sql.AppendLine("on a.cd_moeda = d.cd_moeda ");
            sql.AppendLine("left outer join tb_fat_cfgpedido e ");
            sql.AppendLine("on a.cfg_pedidocompra = e.cfg_pedido ");
            sql.AppendLine("left outer join tb_est_localarm f ");
            sql.AppendLine("on a.cd_local = f.cd_local ");
            sql.AppendLine("left  join tb_fin_tpduplicata g ");
            sql.AppendLine("on a.tp_duplicata = g.tp_duplicata"); 
            sql.AppendLine("left  join TB_FIN_TPDocto_Dup h ");
            sql.AppendLine("on a.tp_docto = h.tp_docto"); 

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CFGCompra Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGCompra lista = new TList_CFGCompra();

            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo)); ;
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGCompra reg = new TRegistro_CFGCompra();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_RequisitantePadrao")))
                        reg.Cd_requisitantepadrao = reader.GetString(reader.GetOrdinal("CD_RequisitantePadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_RequisitantePadrao")))
                        reg.Nm_requisitantepadrao = reader.GetString(reader.GetOrdinal("NM_RequisitantePadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_PedidoCompra")))
                        reg.Cfg_pedidocompra = reader.GetString(reader.GetOrdinal("CFG_PedidoCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedidocompra = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Min_Negociacao")))
                        reg.Qtd_min_negociacao = reader.GetDecimal(reader.GetOrdinal("QTD_Min_Negociacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Min_Cotacao")))
                        reg.Qtd_min_cotacao = reader.GetDecimal(reader.GetOrdinal("QTD_Min_Cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarRequisicaoAuto")))
                        reg.St_gerarrequisicaoauto = reader.GetString(reader.GetOrdinal("ST_GerarRequisicaoAuto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_QtdReqAuto")))
                        reg.Tp_qtdreqauto = reader.GetString(reader.GetOrdinal("TP_QtdReqAuto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_MesesMediaVenda")))
                        reg.Nr_mesesmediavenda = reader.GetDecimal(reader.GetOrdinal("NR_MesesMediaVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_UtilizarMoedaOC")))
                        reg.St_utilizarmoedaoc = reader.GetString(reader.GetOrdinal("ST_UtilizarMoedaOC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.tp_doc = reader.GetDecimal(reader.GetOrdinal("tp_docto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.ds_doc = reader.GetString(reader.GetOrdinal("ds_tpdocto")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.id_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.ds_dup = reader.GetString(reader.GetOrdinal("ds_tpduplicata")).ToString();

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

        public string GravarCFGCompra(TRegistro_CFGCompra val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);

            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_REQUISITANTEPADRAO", val.Cd_requisitantepadrao);
            hs.Add("@P_CFG_PEDIDOCOMPRA", val.Cfg_pedidocompra);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QTD_MIN_NEGOCIACAO", val.Qtd_min_negociacao);
            hs.Add("@P_QTD_MIN_COTACAO", val.Qtd_min_cotacao);
            hs.Add("@P_ST_GERARREQUISICAOAUTO", val.St_gerarrequisicaoauto);
            hs.Add("@P_TP_QTDREQAUTO", val.Tp_qtdreqauto);
            hs.Add("@P_NR_MESESMEDIAVENDA", val.Nr_mesesmediavenda);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_ST_UTILIZARMOEDAOC", val.St_utilizarmoedaoc);
            hs.Add("@P_TP_DUPLICATA", val.id_duplicata);
            hs.Add("@P_TP_DOCTO", val.tp_doc);

            return executarProc("IA_CMP_CFGCOMPRA", hs);
        }

        public string DeletarCFGCompra(TRegistro_CFGCompra val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_CMP_CFGCOMPRA", hs);
        }
    }
}
