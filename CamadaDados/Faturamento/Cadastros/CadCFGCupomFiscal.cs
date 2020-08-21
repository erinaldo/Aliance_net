using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CFGCupomFiscal : List<TRegistro_CFGCupomFiscal>
    { }
    
    public class TRegistro_CFGCupomFiscal
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Cd_historico_transf
        { get; set; }
        public string Ds_historico_transf
        { get; set; }
        public string Cd_historico_ret
        { get; set; }
        public string Ds_historico_ret
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch { id_config = null; }
            }
        }
        public string Ds_config
        { get; set; }
        public string Cd_historicocaixa
        { get; set; }
        public string Ds_historicocaixa
        { get; set; }
        public string Cd_contacaixa
        { get; set; }
        public string Ds_contacaixa
        { get; set; }
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movimentacaostr;
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = Convert.ToDecimal(value);
                }
                catch
                { cd_movimentacao = null; }
            }
        }
        public string Ds_movimentacao
        { get; set; }
        public string Cd_centroresultCMV
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Ds_serienf
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Cd_condfiscal_clifor
        { get; set; }
        public string Ds_condfiscal_clifor
        { get; set; }
        public string Tp_pessoa
        { get; set; }
        public string Cd_historico_troco
        { get; set; }
        public string Ds_historico_troco
        { get; set; }
        public string Cd_historico_sobracaixa
        { get; set; }
        public string Ds_historico_sobracaixa
        { get; set; }
        public string Cd_historico_faltacaixa
        { get; set; }
        public string Ds_historico_faltacaixa
        { get; set; }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        public string Cfg_pedidovinculado
        { get; set; }
        public string Ds_tipopedidovinculado
        { get; set; }
        public string Cfg_pedservico
        { get; set; }
        public string Ds_tipopedidoservico
        { get; set; }
        public string Cfg_pedvendaconsumo
        { get; set; }
        public string Ds_tipopedidoconsumo
        { get; set; }
        public string Cd_contacartao
        { get; set; }
        public string Ds_contacartao
        { get; set; }
        public string Cd_contaoperacional
        { get; set; }
        public string Ds_contaoperacional
        { get; set; }
        public string Cd_centroresult
        { get; set; }
        public string Cd_CentroResultFrete
        { get; set; }
        public string Cd_CentroResultBaixaPat
        { get; set; }
        public string Ds_centroresultado
        { get; set; }
        public string Cfg_pedcondicional
        { get; set; }
        public string Ds_tipopedidocondicional
        { get; set; }
        public string Cfg_peddevolucao
        { get; set; }
        public string Ds_tipopedidodevolucao
        { get; set; }
        public string Nr_serienfce
        { get; set; }
        public string Ds_serienfce
        { get; set; }
        public string Cd_modelonfce
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public string Ds_mensagem
        { get; set; }
        private string st_movestoque;
        public string St_movestoque
        {
            get { return st_movestoque; }
            set
            {
                st_movestoque = value;
                st_movestoquebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_movestoquebool;
        public bool St_movestoquebool
        {
            get { return st_movestoquebool; }
            set
            {
                st_movestoquebool = value;
                st_movestoque = value ? "S" : "N";
            }
        }
        private string st_produtocodigo;
        public string St_produtocodigo
        {
            get { return st_produtocodigo; }
            set
            {
                st_produtocodigo = value;
                st_produtocodigobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_produtocodigobool;
        public bool St_produtocodigobool
        {
            get { return st_produtocodigobool; }
            set
            {
                st_produtocodigobool = value;
                st_produtocodigo = value ? "S" : "N";
            }
        }
        private string st_impcpfcnpj;
        public string St_impcpfcnpj
        {
            get { return st_impcpfcnpj; }
            set
            {
                st_impcpfcnpj = value;
                st_impcpfcnpjbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_impcpfcnpjbool;
        public bool St_impcpfcnpjbool
        {
            get { return st_impcpfcnpjbool; }
            set
            {
                st_impcpfcnpjbool = value;
                st_impcpfcnpj = value ? "S" : "N";
            }
        }
        private string st_apurarcomcx;
        public string St_apurarcomcx
        {
            get { return st_apurarcomcx; }
            set
            {
                st_apurarcomcx = value;
                st_apurarcomcxbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_apurarcomcxbool;
        public bool St_apurarcomcxbool
        {
            get { return st_apurarcomcxbool; }
            set
            {
                st_apurarcomcxbool = value;
                st_apurarcomcx = value ? "S" : "N";
            }
        }
        private string st_portadorprevenda;
        public string St_portadorprevenda
        {
            get { return st_portadorprevenda; }
            set
            {
                st_portadorprevenda = value;
                st_portadorprevendabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_portadorprevendabool;
        public bool St_portadorprevendabool
        {
            get { return st_portadorprevendabool; }
            set
            {
                st_portadorprevendabool = value;
                st_portadorprevenda = value ? "S" : "N";
            }
        }
        private string st_obrigavendedor;
        public string St_obrigavendedor
        {
            get { return st_obrigavendedor; }
            set
            {
                st_obrigavendedor = value;
                st_obrigavendedorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_obrigavendedorbool;
        public bool St_obrigavendedorbool
        {
            get { return st_obrigavendedorbool; }
            set
            {
                st_obrigavendedorbool = value;
                st_obrigavendedor = value ? "S" : "N";
            }
        }
        private string st_exigircliente;
        public string St_exigircliente
        {
            get { return st_exigircliente; }
            set
            {
                st_exigircliente = value;
                st_exigirclientebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirclientebool;
        public bool St_exigirclientebool
        {
            get { return st_exigirclientebool; }
            set
            {
                st_exigirclientebool = value;
                st_exigircliente = value ? "S" : "N";
            }
        }

        private string st_RATEARDESCSERVICO;
        public string St_RATEARDESCSERVICO
        {
            get { return st_RATEARDESCSERVICO; }
            set
            {
                st_RATEARDESCSERVICO = value;
                st_RATEARDESCSERVICObool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_RATEARDESCSERVICObool;
        public bool St_RATEARDESCSERVICObool
        {
            get { return st_RATEARDESCSERVICObool; }
            set
            {
                st_RATEARDESCSERVICObool = value;
                st_RATEARDESCSERVICO = value ? "S" : "N";
            }
        }

        public TRegistro_CFGCupomFiscal()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_historico_transf = string.Empty;
            Ds_historico_transf = string.Empty;
            Cd_historico_ret = string.Empty;
            Ds_historico_ret = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            id_configstr = string.Empty;
            id_config = null;
            Ds_config = string.Empty;
            Cd_historicocaixa = string.Empty;
            Ds_historicocaixa = string.Empty;
            Cd_contacaixa = string.Empty;
            Ds_contacaixa = string.Empty;
            cd_movimentacao = null;
            cd_movimentacaostr = string.Empty;
            Ds_movimentacao = string.Empty;
            Cd_centroresultCMV = string.Empty;
            Cd_CentroResultFrete = string.Empty;
            Cd_CentroResultBaixaPat = string.Empty;
            Nr_serie = string.Empty;
            Ds_serienf = string.Empty;
            Cd_modelo = string.Empty;
            Cd_condfiscal_clifor = string.Empty;
            Ds_condfiscal_clifor = string.Empty;
            Tp_pessoa = string.Empty;
            Cd_historico_troco = string.Empty;
            Ds_historico_troco = string.Empty;
            Cd_historico_sobracaixa = string.Empty;
            Ds_historico_sobracaixa = string.Empty;
            Cd_historico_faltacaixa = string.Empty;
            Ds_historico_faltacaixa = string.Empty;
            Cfg_pedido = string.Empty;
            Ds_tipopedido = string.Empty;
            Nr_serienfce = string.Empty;
            Ds_serienfce = string.Empty;
            Cd_modelonfce = string.Empty;
            Ds_mensagem = string.Empty;
            Cfg_pedidovinculado = string.Empty;
            Ds_tipopedidovinculado = string.Empty;
            Cfg_pedservico = string.Empty;
            Ds_tipopedidoservico = string.Empty;
            Cfg_pedvendaconsumo = string.Empty;
            Ds_tipopedidoconsumo = string.Empty;
            Cd_contacartao = string.Empty;
            Ds_contacartao = string.Empty;
            Cd_contaoperacional = string.Empty;
            Ds_contaoperacional = string.Empty;
            Cd_centroresult = string.Empty;
            Ds_centroresultado = string.Empty;
            Cfg_pedcondicional = string.Empty;
            Ds_tipopedidocondicional = string.Empty;
            Cfg_peddevolucao = string.Empty;
            Ds_tipopedidodevolucao = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            st_movestoque = "S";
            st_movestoquebool = true;
            st_produtocodigo = "N";
            st_produtocodigobool = false;
            st_impcpfcnpj = "N";
            st_impcpfcnpjbool = false;
            st_apurarcomcx = "N";
            st_apurarcomcxbool = false;
            st_portadorprevenda = "N";
            st_portadorprevendabool = false;
            st_obrigavendedor = "N";
            st_obrigavendedorbool = false;
            st_exigircliente = "N";
            st_exigirclientebool = false;
            st_RATEARDESCSERVICO = "N";
            st_RATEARDESCSERVICObool = false;
        }
    }

    public class TCD_CFGCupomFiscal : TDataQuery
    {
        public TCD_CFGCupomFiscal()
        { }

        public TCD_CFGCupomFiscal(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Historico, c.DS_Historico, ");
                sql.AppendLine("a.CD_Clifor, d.NM_Clifor, ");
                sql.AppendLine("cd_endereco = (select top 1 x.cd_endereco ");
                sql.AppendLine("                from tb_fin_endereco x ");
                sql.AppendLine("                where x.cd_clifor = a.cd_clifor ");
                sql.AppendLine("                order by x.cd_endereco asc), ");
                sql.AppendLine("ds_endereco = (select top 1 x.ds_endereco ");
                sql.AppendLine("                from tb_fin_endereco x ");
                sql.AppendLine("                where x.cd_clifor = a.cd_clifor ");
                sql.AppendLine("                order by x.cd_endereco asc), ");
                sql.AppendLine("a.CD_TabelaPreco, e.DS_TabelaPreco, ");
                sql.AppendLine("a.CD_Local, f.DS_Local, a.CD_CondPgto, cond.DS_CondPgto, ");
                sql.AppendLine("a.CD_Historico_Transf, g.DS_Historico as ds_historico_transf, ");
                sql.AppendLine("a.cd_historico_ret, j.ds_historico as ds_historico_ret, ");
                sql.AppendLine("a.Tp_Docto, h.DS_TpDocto, i.id_config, config.ds_config, ");
                sql.AppendLine("a.TP_Duplicata, i.DS_TpDuplicata, a.DS_Mensagem, ");
                sql.AppendLine("a.cd_historicocaixa, k.ds_historico as ds_historicocaixa, ");
                sql.AppendLine("a.cd_contacaixa, l.ds_contager as ds_contacaixa, ");
                sql.AppendLine("a.CD_Movimentacao, m.DS_Movimentacao, m.cd_centroresult as cd_centroresultCMV, ");
                sql.AppendLine("a.Nr_Serie, n.DS_SerieNf, a.CD_Modelo, ");
                sql.AppendLine("a.NR_SerieNFCe, nfce.DS_SerieNf as DS_SerieNFCe, nfce.Cd_Modelo as Cd_ModeloNFCe, ");
                sql.AppendLine("d.CD_condfiscal_clifor, o.DS_CondFiscal, d.tp_pessoa, ");
                sql.AppendLine("a.cd_historico_troco, p.ds_historico as ds_historico_troco, ");
                sql.AppendLine("a.cfg_pedido, q.ds_tipopedido, a.st_apurarcomcx, ");
                sql.AppendLine("a.cd_historico_sobracaixa, hs.ds_historico as ds_historico_sobracaixa, ");
                sql.AppendLine("a.cd_historico_faltacaixa, hf.ds_historico as ds_historico_faltacaixa, ");
                sql.AppendLine("a.cfg_pedidovinculado, r.ds_tipopedido as ds_tipopedidovinculado, ");
                sql.AppendLine("a.cfg_pedcondicional, cpc.ds_tipopedido as ds_tipopedidocondicional, ");
                sql.AppendLine("a.cfg_peddevolucao, cpd.ds_tipopedido as ds_tipopedidodevolucao, ");
                sql.AppendLine("a.cd_contacartao, s.ds_contager as ds_contacartao, ");
                sql.AppendLine("a.cd_contaoperacional, t.ds_contager as ds_contaoperacional, ");
                sql.AppendLine("a.cfg_pedservico, u.ds_tipopedido as ds_tipopedservico, ");
                sql.AppendLine("a.cfg_pedvendaconsumo, v.ds_tipopedido as ds_tipopedidoconsumo, ");
                sql.AppendLine("a.cd_centroresult, a.CD_CentroResultFrete, a.CD_CentroResultBaixaPat, cr.ds_centroresultado, a.st_movestoque, ");
                sql.AppendLine("a.st_produtocodigo, a.ST_ImpCPFCNPJ, a.ST_PortadorPreVenda, a.ST_ObrigaVendedor, a.ST_ExigirCliente, a.st_RATEARDESCSERVICO ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_CFGCupomFiscal a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Historico c ");
            sql.AppendLine("on a.CD_Historico = c.CD_Historico ");
            sql.AppendLine("inner join VTB_FIN_Clifor d ");
            sql.AppendLine("on a.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco e ");
            sql.AppendLine("on a.CD_TabelaPreco = e.CD_TabelaPreco ");
            sql.AppendLine("inner join TB_EST_LocalArm f ");
            sql.AppendLine("on a.CD_Local = f.CD_Local ");
            sql.AppendLine("inner join TB_FIN_Historico g ");
            sql.AppendLine("on a.CD_Historico_Transf = g.CD_Historico ");
            sql.AppendLine("inner join TB_FIN_TPDocto_Dup h ");
            sql.AppendLine("on a.Tp_Docto = h.Tp_Docto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata i ");
            sql.AppendLine("on a.TP_Duplicata = i.TP_Duplicata ");
            sql.AppendLine("inner join TB_FIN_Historico j ");
            sql.AppendLine("on a.cd_historico_ret = j.cd_historico ");
            sql.AppendLine("inner join TB_FIN_Historico k ");
            sql.AppendLine("on a.cd_historicocaixa = k.cd_historico ");
            sql.AppendLine("inner join TB_FIN_ContaGer l ");
            sql.AppendLine("on a.cd_contacaixa = l.cd_contager ");
            sql.AppendLine("inner join TB_FIS_Movimentacao m ");
            sql.AppendLine("on a.CD_Movimentacao = m.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FAT_SerieNF n ");
            sql.AppendLine("on a.Nr_Serie = n.Nr_Serie ");
            sql.AppendLine("and a.Cd_modelo = n.Cd_modelo ");
            sql.AppendLine("LEFT join TB_FIS_CondFiscal_Clifor o ");
            sql.AppendLine("on d.cd_condfiscal_clifor = o.Cd_CondFiscal_Clifor ");
            sql.AppendLine("inner join TB_FIN_Historico p ");
            sql.AppendLine("on a.cd_historico_troco = p.cd_historico ");
            sql.AppendLine("inner join TB_FIN_Historico hs ");
            sql.AppendLine("on a.cd_historico_sobracaixa = hs.cd_historico ");
            sql.AppendLine("inner join TB_FIN_Historico hf ");
            sql.AppendLine("on a.cd_historico_faltacaixa = hf.cd_historico ");
            sql.AppendLine("left outer join tb_fat_cfgpedido q ");
            sql.AppendLine("on a.cfg_pedido = q.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido r ");
            sql.AppendLine("on a.cfg_pedidovinculado = r.cfg_pedido ");
            sql.AppendLine("left outer join tb_fin_contager s ");
            sql.AppendLine("on a.cd_contacartao = s.cd_contager ");
            sql.AppendLine("left outer join tb_fin_contager t ");
            sql.AppendLine("on a.cd_contaoperacional = t.cd_contager ");
            sql.AppendLine("left outer join tb_fat_cfgpedido u ");
            sql.AppendLine("on a.cfg_pedservico = u.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido v ");
            sql.AppendLine("on a.cfg_pedvendaconsumo = v.cfg_pedido ");
            sql.AppendLine("left outer join tb_fin_centroresultado cr ");
            sql.AppendLine("on a.cd_centroresult = cr.cd_centroresult ");
            sql.AppendLine("left outer join tb_cob_cfgbanco config ");
            sql.AppendLine("on i.id_config = config.id_config ");
            sql.AppendLine("left outer join tb_fat_cfgpedido cpc ");
            sql.AppendLine("on a.cfg_pedcondicional = cpc.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_cfgpedido cpd ");
            sql.AppendLine("on a.cfg_peddevolucao = cpd.cfg_pedido ");
            sql.AppendLine("left outer join tb_fat_serienf nfce ");
            sql.AppendLine("on a.nr_serienfce = nfce.nr_serie ");
            sql.AppendLine("and a.cd_modelonfce = nfce.cd_modelo ");
            sql.AppendLine("left outer join tb_fin_condpgto cond ");
            sql.AppendLine("on a.cd_condpgto = cond.cd_condpgto ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CFGCupomFiscal Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CFGCupomFiscal lista = new TList_CFGCupomFiscal();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGCupomFiscal reg = new TRegistro_CFGCupomFiscal();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Transf")))
                        reg.Cd_historico_transf = reader.GetString(reader.GetOrdinal("CD_Historico_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_transf")))
                        reg.Ds_historico_transf = reader.GetString(reader.GetOrdinal("ds_historico_transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("DS_TpDocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("ID_Config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("DS_Config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("DS_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_ret")))
                        reg.Cd_historico_ret = reader.GetString(reader.GetOrdinal("cd_historico_ret"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_ret")))
                        reg.Ds_historico_ret = reader.GetString(reader.GetOrdinal("ds_historico_ret"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicocaixa")))
                        reg.Cd_historicocaixa = reader.GetString(reader.GetOrdinal("cd_historicocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicocaixa")))
                        reg.Ds_historicocaixa = reader.GetString(reader.GetOrdinal("ds_historicocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contacaixa")))
                        reg.Cd_contacaixa = reader.GetString(reader.GetOrdinal("cd_contacaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contacaixa")))
                        reg.Ds_contacaixa = reader.GetString(reader.GetOrdinal("ds_contacaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultCMV")))
                        reg.Cd_centroresultCMV = reader.GetString(reader.GetOrdinal("cd_centroresultCMV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("cd_condfiscal_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condfiscal")))
                        reg.Ds_condfiscal_clifor = reader.GetString(reader.GetOrdinal("ds_condfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_Pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_troco")))
                        reg.Cd_historico_troco = reader.GetString(reader.GetOrdinal("cd_historico_troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_troco")))
                        reg.Ds_historico_troco = reader.GetString(reader.GetOrdinal("ds_historico_troco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedidovinculado")))
                        reg.Cfg_pedidovinculado = reader.GetString(reader.GetOrdinal("CFG_PedidoVinculado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedidoVinculado")))
                        reg.Ds_tipopedidovinculado = reader.GetString(reader.GetOrdinal("DS_TipoPedidoVinculado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_sobracaixa")))
                        reg.Cd_historico_sobracaixa = reader.GetString(reader.GetOrdinal("cd_historico_sobracaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_sobracaixa")))
                        reg.Ds_historico_sobracaixa = reader.GetString(reader.GetOrdinal("ds_historico_sobracaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_faltacaixa")))
                        reg.Cd_historico_faltacaixa = reader.GetString(reader.GetOrdinal("cd_historico_faltacaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico_faltacaixa")))
                        reg.Ds_historico_faltacaixa = reader.GetString(reader.GetOrdinal("ds_historico_faltacaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contacartao")))
                        reg.Cd_contacartao = reader.GetString(reader.GetOrdinal("cd_contacartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contacartao")))
                        reg.Ds_contacartao = reader.GetString(reader.GetOrdinal("ds_contacartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contaoperacional")))
                        reg.Cd_contaoperacional = reader.GetString(reader.GetOrdinal("cd_contaoperacional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contaoperacional")))
                        reg.Ds_contaoperacional = reader.GetString(reader.GetOrdinal("ds_contaoperacional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedservico")))
                        reg.Cfg_pedservico = reader.GetString(reader.GetOrdinal("cfg_pedservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedservico")))
                        reg.Ds_tipopedidoservico = reader.GetString(reader.GetOrdinal("ds_tipopedservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedvendaconsumo")))
                        reg.Cfg_pedvendaconsumo = reader.GetString(reader.GetOrdinal("cfg_pedvendaconsumo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedidoconsumo")))
                        reg.Ds_tipopedidoconsumo = reader.GetString(reader.GetOrdinal("ds_tipopedidoconsumo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("cd_centroresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResultFrete")))
                        reg.Cd_CentroResultFrete = reader.GetString(reader.GetOrdinal("CD_CentroResultFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResultBaixaPat")))
                        reg.Cd_CentroResultBaixaPat = reader.GetString(reader.GetOrdinal("CD_CentroResultBaixaPat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultado")))
                        reg.Ds_centroresultado = reader.GetString(reader.GetOrdinal("ds_centroresultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedcondicional")))
                        reg.Cfg_pedcondicional = reader.GetString(reader.GetOrdinal("cfg_pedcondicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedidocondicional")))
                        reg.Ds_tipopedidocondicional = reader.GetString(reader.GetOrdinal("ds_tipopedidocondicional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_peddevolucao")))
                        reg.Cfg_peddevolucao = reader.GetString(reader.GetOrdinal("cfg_peddevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedidodevolucao")))
                        reg.Ds_tipopedidodevolucao = reader.GetString(reader.GetOrdinal("ds_tipopedidodevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_movestoque")))
                        reg.St_movestoque = reader.GetString(reader.GetOrdinal("st_movestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_produtocodigo")))
                        reg.St_produtocodigo = reader.GetString(reader.GetOrdinal("st_produtocodigo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ImpCPFCNPJ")))
                        reg.St_impcpfcnpj = reader.GetString(reader.GetOrdinal("ST_ImpCPFCNPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ApurarComCX")))
                        reg.St_apurarcomcx = reader.GetString(reader.GetOrdinal("ST_ApurarComCX"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_PortadorPreVenda")))
                        reg.St_portadorprevenda = reader.GetString(reader.GetOrdinal("ST_PortadorPreVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ObrigaVendedor")))
                        reg.St_obrigavendedor = reader.GetString(reader.GetOrdinal("ST_ObrigaVendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_SerieNFCe")))
                        reg.Nr_serienfce = reader.GetString(reader.GetOrdinal("NR_SerieNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNFCe")))
                        reg.Ds_serienfce = reader.GetString(reader.GetOrdinal("DS_SerieNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ModeloNFCe")))
                        reg.Cd_modelonfce = reader.GetString(reader.GetOrdinal("Cd_ModeloNFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ExigirCliente")))
                        reg.St_exigircliente = reader.GetString(reader.GetOrdinal("ST_ExigirCliente")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("st_RATEARDESCSERVICO")))
                        reg.St_RATEARDESCSERVICO = reader.GetString(reader.GetOrdinal("st_RATEARDESCSERVICO")); 

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

        public string Gravar(TRegistro_CFGCupomFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(39);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_HISTORICO_TRANSF", val.Cd_historico_transf);
            hs.Add("@P_CD_HISTORICO_RET", val.Cd_historico_ret);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_CD_HISTORICOCAIXA", val.Cd_historicocaixa);
            hs.Add("@P_CD_CONTACAIXA", val.Cd_contacaixa);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_HISTORICO_TROCO", val.Cd_historico_troco);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CFG_PEDIDOVINCULADO", val.Cfg_pedidovinculado);
            hs.Add("@P_CD_HISTORICO_SOBRACAIXA", val.Cd_historico_sobracaixa);
            hs.Add("@P_CD_HISTORICO_FALTACAIXA", val.Cd_historico_faltacaixa);
            hs.Add("@P_CD_CONTACARTAO", val.Cd_contacartao);
            hs.Add("@P_CD_CONTAOPERACIONAL", val.Cd_contaoperacional);
            hs.Add("@P_CFG_PEDSERVICO", val.Cfg_pedservico);
            hs.Add("@P_CFG_PEDVENDACONSUMO", val.Cfg_pedvendaconsumo);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_CENTRORESULTFRETE", val.Cd_CentroResultFrete);
            hs.Add("@P_CD_CENTRORESULTBAIXAPAT", val.Cd_CentroResultBaixaPat);
            hs.Add("@P_CFG_PEDCONDICIONAL", val.Cfg_pedcondicional);
            hs.Add("@P_CFG_PEDDEVOLUCAO", val.Cfg_peddevolucao);
            hs.Add("@P_NR_SERIENFCE", val.Nr_serienfce);
            hs.Add("@P_CD_MODELONFCE", val.Cd_modelonfce);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_ST_MOVESTOQUE", val.St_movestoque);
            hs.Add("@P_ST_PRODUTOCODIGO", val.St_produtocodigo);
            hs.Add("@P_ST_IMPCPFCNPJ", val.St_impcpfcnpj);
            hs.Add("@P_ST_APURARCOMCX", val.St_apurarcomcx);
            hs.Add("@P_ST_PORTADORPREVENDA", val.St_portadorprevenda);
            hs.Add("@P_ST_OBRIGAVENDEDOR", val.St_obrigavendedor);
            hs.Add("@P_ST_EXIGIRCLIENTE", val.St_exigircliente);
            hs.Add("@P_ST_RATEARDESCSERVICO", val.St_RATEARDESCSERVICO);
            

            return executarProc("IA_PDV_CFGCUPOMFISCAL", hs);
        }

        public string Excluir(TRegistro_CFGCupomFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PDV_CFGCUPOMFISCAL", hs);
        }
    }
}
