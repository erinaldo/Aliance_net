using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_Requisicao:List<TRegistro_Requisicao>, IComparer<TRegistro_Requisicao>
    {
        #region IComparer<TRegistro_Requisicao> Members
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

        public TList_Requisicao()
        { }

        public TList_Requisicao(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Requisicao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Requisicao x, TRegistro_Requisicao y)
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
    
    public class TRegistro_Requisicao
    {
        public decimal? Id_requisicao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_tprequisicao;
        public decimal? Id_tprequisicao
        {
            get { return id_tprequisicao; }
            set
            {
                id_tprequisicao = value;
                id_tprequisicaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tprequisicaostr;
        public string Id_tprequisicaostr
        {
            get { return id_tprequisicaostr; }
            set
            {
                id_tprequisicaostr = value;
                try
                {
                    id_tprequisicao = decimal.Parse(value);
                }
                catch
                { id_tprequisicao = null; }
            }
        }
        public string Ds_tprequisicao
        { get; set; }
        private string tp_requisicao;
        public string Tp_requisicao
        {
            get { return tp_requisicao; }
            set
            {
                tp_requisicao = value;
                if (value.Trim().ToUpper().Equals("I"))
                    tipo_requisicao = "INTERNA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_requisicao = "EXTERNA";
            }
        }
        private string tipo_requisicao;
        public string Tipo_requisicao
        {
            get { return tipo_requisicao; }
            set
            {
                tipo_requisicao = value;
                if (value.Trim().ToUpper().Equals("INTERNA"))
                    tp_requisicao = "I";
                else if (value.Trim().ToUpper().Equals("EXTERNA"))
                    tp_requisicao = "E";
            }
        }
        private DateTime? dt_requisicao;
        public DateTime? Dt_requisicao
        {
            get { return dt_requisicao; }
            set
            {
                dt_requisicao = value;
                dt_requisicaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_requisicaostr;
        public string Dt_requisicaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_requisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_requisicaostr = value;
                try
                {
                    dt_requisicao = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_requisicao = null;
                }
            }
        }
        public string Cd_clifor_requisitante
        { get; set; }
        public string Nm_clifor_requisitante
        { get; set; }
        public string Cd_clifor_aprovador
        { get; set; }
        public string Nm_clifor_aprovador
        { get; set; }
        public string Cd_clifor_comprador
        { get; set; }
        public string Nm_clifor_comprador
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public string Cd_referencia
        { get; set; }
        public string Ds_marca
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        private string st_requisicao;
        public string St_requisicao
        {
            get { return st_requisicao; }
            set
            {
                st_requisicao = value;
                if (value.Trim().ToUpper().Equals("AC"))
                    status = "AGUARDANDO COTACAO";
                else if (value.Trim().ToUpper().Equals("AA"))
                    status = "AGUARDANDO APROVACAO";
                else if (value.Trim().ToUpper().Equals("RN"))
                    status = "RENEGOCIAR";
                else if (value.Trim().ToUpper().Equals("AP"))
                    status = "APROVADA";
                else if (value.Trim().ToUpper().Equals("RE"))
                    status = "REPROVADA";
                else if (value.Trim().ToUpper().Equals("OC") && this.Nr_pedido == null)
                    status = "ORDEM COMPRA";
                else if (value.Trim().ToUpper().Equals("OC") && this.Nr_pedido != null)
                    status = "PEDIDO GERADO";
                else if (value.Trim().ToUpper().Equals("CA"))
                    status = "CANCELADA";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("AGUARDANDO COTACAO"))
                    st_requisicao = "AC";
                else if (value.Trim().ToUpper().Equals("AGUARDANDO APROVACAO"))
                    st_requisicao = "AA";
                else if (value.Trim().ToUpper().Equals("RENEGOCIAR"))
                    st_requisicao = "RN";
                else if (value.Trim().ToUpper().Equals("APROVADA"))
                    st_requisicao = "AP";
                else if (value.Trim().ToUpper().Equals("REPROVADA"))
                    st_requisicao = "RE";
                else if (value.Trim().ToUpper().Equals("ORDEM COMPRA") ||
                         value.Trim().ToUpper().Equals("PEDIDO GERADO"))
                    st_requisicao = "OC";
                else if (value.Trim().ToUpper().Equals("CANCELADA"))
                    st_requisicao = "CA";
            }
        }
        public decimal Quantidade
        { get; set; }
        public decimal Qtd_aprovada
        { get; set; }
        public decimal Qtd_atendida
        { get; set; }
        public decimal Vl_unitCotacao
        { get; set; }
        public decimal SubTotalAtendido
        { get { return Qtd_atendida * Vl_unitCotacao; } }
        public decimal Vl_ipi
        { get; set; }
        public decimal Vl_icmssubst
        { get; set; }
        public decimal Pc_icms
        { get; set; }
        public decimal Qtd_almox
        { get; set; }
        public decimal SaldoAtualAlmox
        { get; set; }
        public decimal Sd_retirar_almox
        { get { return Qtd_aprovada - Qtd_almox; } }
        public string Ds_observacao
        { get; set; }
        public string Ds_motivorenegociar
        { get; set; }
        public bool St_integrar
        { get; set; }
        public string Cd_condPgto
        { get; set; }
        public string Ds_condPgto
        { get; set; }
        public decimal? Id_ordem
        { get; set; }
        public decimal SaldoAtualEst
        { get; set; }
        public decimal Vl_custoEst
        { get; set; }
        public decimal Vl_ultimaCompraForn
        { get; set; }
        public decimal Vl_ultimaCompraCon
        { get; set; }
        public TList_Requisicao_X_Negociacao lReqneg
        { get; set; }
        public TList_Requisicao_X_Negociacao lregnegdel
        { get; set; }
        public CamadaDados.Producao.Producao.TList_OrdemProducao_X_Requisicao lOrdemProd
        { get; set; }
        public TList_Cotacao lCotacoes
        { get; set; }

        public TRegistro_Requisicao()
        {
            Id_requisicao = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_tprequisicao = null;
            id_tprequisicaostr = string.Empty;
            Ds_tprequisicao = string.Empty;
            tp_requisicao = string.Empty;
            tipo_requisicao = string.Empty;
            dt_requisicao = DateTime.Now;
            dt_requisicaostr = DateTime.Now.ToString("dd/MM/yyyy");
            Cd_clifor_requisitante = string.Empty;
            Nm_clifor_requisitante = string.Empty;
            Cd_clifor_aprovador = string.Empty;
            Nm_clifor_aprovador = string.Empty;
            Cd_clifor_comprador = string.Empty;
            Nm_clifor_comprador = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Cd_referencia = string.Empty;
            Ds_marca = string.Empty;
            Cd_grupo = string.Empty;
            Sigla_unidade = string.Empty;
            st_requisicao = "AC";
            status = "AGUARDANDO COTACAO";
            Quantidade = decimal.Zero;
            Qtd_aprovada = decimal.Zero;
            Qtd_atendida = decimal.Zero;
            Vl_unitCotacao = decimal.Zero;
            Qtd_almox = decimal.Zero;
            Ds_observacao = string.Empty;
            Ds_motivorenegociar = string.Empty;
            St_integrar = false;
            Cd_condPgto = string.Empty;
            Ds_condPgto = string.Empty;
            Id_ordem = null;
            Nr_pedido = null;

            SaldoAtualAlmox = decimal.Zero;
            SaldoAtualEst = decimal.Zero;
            Vl_custoEst = decimal.Zero;
            Vl_ultimaCompraForn = decimal.Zero;
            Vl_ultimaCompraCon = decimal.Zero;
            Vl_ipi = decimal.Zero;
            Vl_icmssubst = decimal.Zero;
            Pc_icms = decimal.Zero;

            lReqneg = new TList_Requisicao_X_Negociacao();
            lregnegdel = new TList_Requisicao_X_Negociacao();
            lOrdemProd = new CamadaDados.Producao.Producao.TList_OrdemProducao_X_Requisicao();
            lCotacoes = new TList_Cotacao();
        }
    }

    public class TCD_Requisicao : TDataQuery
    {
        public TCD_Requisicao()
        { }

        public TCD_Requisicao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Requisicao, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.cd_clifor_requisitante, d.nm_clifor as nm_clifor_requisitante, ");
                sql.AppendLine("a.cd_clifor_aprovador, e.nm_clifor as nm_clifor_aprovador, a.dt_requisicao, ");
                sql.AppendLine("a.cd_clifor_comprador, f.nm_clifor as nm_clifor_comprador, a.qtd_almox, g.cd_grupo, ");
                sql.AppendLine("a.cd_produto, isnull(a.ds_produto, g.DS_Produto) as DS_Produto, a.cd_local, j.ds_local, g.Codigo_Alternativo, i.ds_marca, h.sigla_unidade, a.st_requisicao, ");
                sql.AppendLine("a.quantidade, a.qtd_aprovada, a.ds_observacao, a.ds_motivorenegociar, ");
                sql.AppendLine("a.id_tprequisicao, tp.ds_tprequisicao, tp.tp_requisicao, ");
                sql.AppendLine("CD_CondPGTO = isnull((select top 1 x.CD_CondPGTO ");
                sql.AppendLine("                     from tb_cmp_ordemcompra x ");
				sql.AppendLine("	                 where a.ID_Requisicao = x.ID_Requisicao ");
				sql.AppendLine("	                 and a.CD_Empresa = x.cd_empresa ");
				sql.AppendLine("	                 and ISNULL(x.st_registro, 'A') <> 'C'),''), ");
                sql.AppendLine("DS_CondPGTO = isnull((select top 1 y.DS_CondPGTO ");
                sql.AppendLine("                      from tb_cmp_ordemcompra x ");
				sql.AppendLine("	                  inner join TB_FIN_CondPGTO y ");
				sql.AppendLine("	                  on x.CD_CondPGTO = y.CD_CondPGTO ");
				sql.AppendLine("	                  where a.ID_Requisicao = x.ID_Requisicao ");
				sql.AppendLine("	                  and a.CD_Empresa = x.cd_empresa ");
                sql.AppendLine("	                  and ISNULL(x.st_registro, 'A') <> 'C'),''), ");
                sql.AppendLine("SaldoAtualEst = isnull((select isnull(x.Tot_Saldo, 0) from vtb_est_vlestoque x ");
				sql.AppendLine("		                where x.cd_empresa = a.CD_Empresa ");
				sql.AppendLine("		                and x.cd_produto = a.CD_Produto),0), ");
                sql.AppendLine("Vl_custoEst = isnull((select isnull(x.Vl_Medio, 0) from vtb_est_vlestoque x ");
				sql.AppendLine("		              where x.cd_empresa = a.CD_Empresa ");
                sql.AppendLine("		              and x.cd_produto = a.CD_Produto),0), ");
                sql.AppendLine("SaldoAtualAlmox = isnull((select isnull(x.Saldo, 0) from VTB_AMX_SALDOALMOXARIFADO x ");
                sql.AppendLine("		                where x.cd_empresa = a.CD_Empresa ");
                sql.AppendLine("		                and x.cd_produto = a.CD_Produto),0), ");
                sql.AppendLine("Id_ordem = isnull((select x.ID_Ordem from TB_PRD_OrdemProducao_X_Requisicao x ");
				sql.AppendLine("	                  where x.CD_Empresa = a.cd_empresa ");
                sql.AppendLine("	                  and x.ID_Requisicao = a.ID_Requisicao), null), ");
                sql.AppendLine("Nr_pedido = isnull((select top 1 x.Nr_Pedido from TB_FAT_Pedido_Itens x ");
				sql.AppendLine("	                inner join TB_CMP_OrdemCompra_X_PedItem y ");
				sql.AppendLine("	                on x.CD_Produto = y.CD_Produto ");
				sql.AppendLine("	                and x.Nr_Pedido = y.Nr_Pedido ");
				sql.AppendLine("	                and x.ID_PedidoItem = y.ID_PedidoItem ");
				sql.AppendLine("	                inner join TB_CMP_OrdemCompra h ");
				sql.AppendLine("	                on y.ID_OC = h.ID_OC ");
				sql.AppendLine("	                where a.CD_Empresa = h.CD_Empresa ");
				sql.AppendLine("	                and a.ID_Requisicao = h.ID_Requisicao ");
				sql.AppendLine("	                and a.CD_Produto = x.CD_Produto ");
                sql.AppendLine("	                and h.ST_Registro <> 'C' ");
                sql.AppendLine("                    and x.ST_Registro <> 'C'), null) ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_CMP_Requisicao a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_CMP_TpRequisicao tp ");
            sql.AppendLine("on a.id_tprequisicao = tp.id_tprequisicao ");
            sql.AppendLine("left outer join vtb_fin_clifor d ");
            sql.AppendLine("on a.cd_clifor_requisitante = d.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_clifor e ");
            sql.AppendLine("on a.cd_clifor_aprovador = e.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_clifor f ");
            sql.AppendLine("on a.cd_clifor_comprador = f.cd_clifor ");
            sql.AppendLine("left outer join tb_est_produto g ");
            sql.AppendLine("on a.cd_produto = g.cd_produto ");
            sql.AppendLine("left outer join tb_est_unidade h ");
            sql.AppendLine("on g.cd_unidade = h.cd_unidade ");
            sql.AppendLine("left outer join TB_EST_Marca i ");
            sql.AppendLine("on g.cd_marca = i.cd_marca ");
            sql.AppendLine("left outer join TB_EST_LocalArm j ");
            sql.AppendLine("on a.cd_local = j.cd_local ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_Requisicao Select(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_Requisicao lista = new TList_Requisicao();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Requisicao reg = new TRegistro_Requisicao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Requisicao"))))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_Requisicao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tprequisicao")))
                        reg.Id_tprequisicao = reader.GetDecimal(reader.GetOrdinal("id_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tprequisicao")))
                        reg.Ds_tprequisicao = reader.GetString(reader.GetOrdinal("ds_tprequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_requisicao")))
                        reg.Tp_requisicao = reader.GetString(reader.GetOrdinal("tp_requisicao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Requisicao"))))
                        reg.Dt_requisicao = reader.GetDateTime(reader.GetOrdinal("DT_Requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_requisitante")))
                        reg.Cd_clifor_requisitante = reader.GetString(reader.GetOrdinal("cd_clifor_requisitante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_requisitante")))
                        reg.Nm_clifor_requisitante = reader.GetString(reader.GetOrdinal("nm_clifor_requisitante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_aprovador")))
                        reg.Cd_clifor_aprovador = reader.GetString(reader.GetOrdinal("cd_clifor_aprovador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_aprovador")))
                        reg.Nm_clifor_aprovador = reader.GetString(reader.GetOrdinal("nm_clifor_aprovador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_comprador")))
                        reg.Cd_clifor_comprador = reader.GetString(reader.GetOrdinal("cd_clifor_comprador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_comprador")))
                        reg.Nm_clifor_comprador = reader.GetString(reader.GetOrdinal("nm_clifor_comprador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("Cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("Ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Codigo_Alternativo")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("Codigo_Alternativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("Ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_requisicao")))
                        reg.St_requisicao = reader.GetString(reader.GetOrdinal("st_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_aprovada")))
                        reg.Qtd_aprovada = reader.GetDecimal(reader.GetOrdinal("qtd_aprovada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_almox")))
                        reg.Qtd_almox = reader.GetDecimal(reader.GetOrdinal("qtd_almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoRenegociar")))
                        reg.Ds_motivorenegociar = reader.GetString(reader.GetOrdinal("DS_MotivoRenegociar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.Cd_condPgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_condPgto")))
                        reg.Ds_condPgto = reader.GetString(reader.GetOrdinal("Ds_condPgto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_ordem"))))
                        reg.Id_ordem = reader.GetDecimal(reader.GetOrdinal("Id_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoAtualEst")))
                        reg.SaldoAtualEst = reader.GetDecimal(reader.GetOrdinal("SaldoAtualEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SaldoAtualAlmox")))
                        reg.SaldoAtualAlmox = reader.GetDecimal(reader.GetOrdinal("SaldoAtualAlmox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_custoEst")))
                        reg.Vl_custoEst = reader.GetDecimal(reader.GetOrdinal("Vl_custoEst"));

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

        public string GravarRequisicao(TRegistro_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TPREQUISICAO", val.Id_tprequisicao);
            hs.Add("@P_DT_REQUISICAO", val.Dt_requisicao);
            hs.Add("@P_CD_CLIFOR_REQUISITANTE", val.Cd_clifor_requisitante);
            hs.Add("@P_CD_CLIFOR_APROVADOR", val.Cd_clifor_aprovador);
            hs.Add("@P_CD_CLIFOR_COMPRADOR", val.Cd_clifor_comprador);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_DS_PRODUTO", val.Ds_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ST_REQUISICAO", val.St_requisicao);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_QTD_APROVADA", val.Qtd_aprovada);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DS_MOTIVORENEGOCIAR", val.Ds_motivorenegociar);

            return executarProc("IA_CMP_REQUISICAO", hs);
        }

        public string DeletarRequisicao(TRegistro_Requisicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_CMP_REQUISICAO", hs);
        }
    }
}
