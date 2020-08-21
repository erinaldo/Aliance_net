using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Balanca
{
    public class TList_PesagemFazenda : List<TRegistro_PesagemFazenda>, IComparer<TRegistro_PesagemFazenda>
    {
        #region IComparer<TRegistro_PesagemFazenda> Members
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

        public TList_PesagemFazenda()
        { }

        public TList_PesagemFazenda(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PesagemFazenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PesagemFazenda x, TRegistro_PesagemFazenda y)
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

    public class TRegistro_PesagemFazenda : TRegistro_LanPesagem
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        private decimal? id_lanctoestoque;
        public decimal? Id_lanctoestoque
        {
            get { return id_lanctoestoque; }
            set
            {
                id_lanctoestoque = value;
                id_lanctoestoquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoestoquestr;
        public string Id_lanctoestoquestr
        {
            get { return id_lanctoestoquestr; }
            set
            {
                id_lanctoestoquestr = value;
                try
                {
                    id_lanctoestoque = decimal.Parse(value);
                }
                catch
                { id_lanctoestoque = null; }
            }
        }
        public string Cd_tabeladesconto
        { get; set; }
        public string Ds_tabeladesconto
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        private decimal? id_plantio;
        public decimal? Id_plantio
        {
            get { return id_plantio; }
            set
            {
                id_plantio = value;
                id_plantiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_plantiostr;
        public string Id_plantiostr
        {
            get { return id_plantiostr; }
            set
            {
                id_plantiostr = value;
                try
                {
                    id_plantio = decimal.Parse(value);
                }
                catch
                { id_plantio = null; }
            }
        }
        public string Anosafra
        { get; set; }
        public string Ds_safra
        { get; set; }
        private decimal? id_cultura;
        public decimal? Id_cultura
        {
            get { return id_cultura; }
            set
            {
                id_cultura = value;
                id_culturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_culturastr;
        public string Id_culturastr
        {
            get { return id_culturastr; }
            set
            {
                id_culturastr = value;
                try
                {
                    id_cultura = decimal.Parse(value);
                }
                catch
                { id_cultura = null; }
            }
        }
        public string Ds_cultura
        { get; set; }
        private decimal? id_talhao;
        public decimal? Id_talhao
        {
            get { return id_talhao; }
            set
            {
                id_talhao = value;
                id_talhaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_talhaostr;
        public string Id_talhaostr
        {
            get { return id_talhaostr; }
            set
            {
                id_talhaostr = value;
                try
                {
                    id_talhao = decimal.Parse(value);
                }
                catch
                { id_talhao = null; }
            }
        }
        public string Ds_talhao
        { get; set; }
        private decimal? id_area;
        public decimal? Id_area
        {
            get { return id_area; }
            set
            {
                id_area = value;
                id_areastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_areastr;
        public string Id_areastr
        {
            get { return id_areastr; }
            set
            {
                id_areastr = value;
                try
                {
                    id_area = decimal.Parse(value);
                }
                catch
                { id_area = null; }
            }
        }
        public string Ds_area
        { get; set; }
        private decimal? nr_pedido;
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostr;
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = decimal.Parse(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        private decimal? id_pedidoitem;
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemstr;
        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = decimal.Parse(value);
                }
                catch
                { id_pedidoitem = null; }
            }
        }
        public decimal Vl_unitario
        { get; set; }
        public decimal Ps_desconto
        { get; set; }
        public TList_RegLanClassificacao lClassif
        { get; set; }

        public TRegistro_PesagemFazenda()
        {
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.id_lanctoestoque = null;
            this.id_lanctoestoquestr = string.Empty;
            this.Cd_tabeladesconto = string.Empty;
            this.Ds_tabeladesconto = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.id_plantio = null;
            this.id_plantiostr = string.Empty;
            this.Anosafra = string.Empty;
            this.Ds_safra = string.Empty;
            this.id_cultura = null;
            this.id_culturastr = string.Empty;
            this.Ds_cultura = string.Empty;
            this.id_talhao = null;
            this.id_talhaostr = string.Empty;
            this.Ds_talhao = string.Empty;
            this.id_area = null;
            this.id_areastr = string.Empty;
            this.Ds_area = string.Empty;
            this.Vl_unitario = decimal.Zero;
            this.Ps_desconto = decimal.Zero;
            this.lClassif = new TList_RegLanClassificacao();
        }
    }

    public class TCD_PesagemFazenda : TDataQuery
    {
        public TCD_PesagemFazenda()
        { }

        public TCD_PesagemFazenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Fazenda, b.NM_Empresa, a.ID_Ticket, ");
                sql.AppendLine("a.Tp_Pesagem, c.NM_TpPesagem, a.Id_TicketOrig, ");
                sql.AppendLine("a.TP_Movimento, a.PlacaCarreta, a.PlacaCavalo, ");
                sql.AppendLine("a.QTD_ImpTicket, a.DT_Bruto, a.DT_Tara, a.PS_Bruto, ");
                sql.AppendLine("a.PS_Tara, a.PS_OrigemChegada_Veiculo, a.QTD_DesdobroClifor, ");
                sql.AppendLine("a.CD_Transp, a.Nr_Veiculo, a.Login_PsBruto, a.Login_PsTara, ");
                sql.AppendLine("a.CD_TpVeiculo, a.NM_Motorista, a.NM_Agente, a.Tp_Captura_Bruto, ");
                sql.AppendLine("a.Tp_Captura_Tara, a.ST_TrocaNf, a.QTD_Embalagem, a.Ps_Embalagem, ");
                sql.AppendLine("a.DS_Observacao, a.DS_MotivoCancelamento, a.ST_Registro, a.CD_Local, ");
                sql.AppendLine("d.DS_Local, a.CD_Produto, e.DS_Produto, e.CD_Unidade, f.DS_Unidade, ");
                sql.AppendLine("f.Sigla_Unidade, a.CD_TabelaDesconto, g.DS_TabelaDesconto, a.Id_LanctoEstoque, ");
                sql.AppendLine("a.Id_Plantio, h.AnoSafra, i.DS_Safra, h.ID_Cultura, a.ID_Talhao, j.DS_Talhao, ");
                sql.AppendLine("a.ID_Area, k.DS_Area, a.Vl_Unitario, a.Ps_Desconto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_BAL_PSFAZENDA a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Fazenda = b.CD_Empresa ");
            sql.AppendLine("inner join TB_BAL_TpPesagem c ");
            sql.AppendLine("on a.Tp_Pesagem = c.Tp_Pesagem ");
            sql.AppendLine("inner join TB_EST_LocalArm d ");
            sql.AppendLine("on a.CD_Local = d.CD_Local ");
            sql.AppendLine("inner join TB_EST_Produto e ");
            sql.AppendLine("on a.CD_Produto = e.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade f ");
            sql.AppendLine("on e.CD_Unidade = f.CD_Unidade ");
            sql.AppendLine("inner join TB_GRO_TabelaDesconto g ");
            sql.AppendLine("on a.CD_TabelaDesconto = g.CD_TabelaDesconto ");
            sql.AppendLine("inner join TB_FAZ_Plantio h ");
            sql.AppendLine("on a.Id_Plantio = h.Id_Plantio ");
            sql.AppendLine("inner join TB_GRO_Safra i ");
            sql.AppendLine("on h.AnoSafra = i.AnoSafra ");
            sql.AppendLine("inner join TB_FAZ_Talhoes j ");
            sql.AppendLine("on a.ID_Talhao = j.ID_Talhao ");
            sql.AppendLine("inner join TB_FAZ_Area k ");
            sql.AppendLine("on a.ID_Area = k.ID_Area ");

            string cond = " where ";
            if (vBusca != null)
                foreach (Utils.TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PesagemFazenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PesagemFazenda lista = new TList_PesagemFazenda();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PesagemFazenda reg = new TRegistro_PesagemFazenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Fazenda"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Fazenda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("Tp_Pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_TpPesagem")))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TpPesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_TicketOrig")))
                        reg.Id_ticketorig = reader.GetDecimal(reader.GetOrdinal("Id_TicketOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaCarreta")))
                        reg.Placacarreta = reader.GetString(reader.GetOrdinal("PlacaCarreta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaCavalo")))
                        reg.Placacavalo = reader.GetString(reader.GetOrdinal("PlacaCavalo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_ImpTicket")))
                        reg.Qtd_impticket = reader.GetDecimal(reader.GetOrdinal("QTD_ImpTicket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Bruto")))
                        reg.Dt_bruto = reader.GetDateTime(reader.GetOrdinal("DT_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Tara")))
                        reg.Dt_tara = reader.GetDateTime(reader.GetOrdinal("DT_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Bruto")))
                        reg.Ps_bruto = reader.GetDecimal(reader.GetOrdinal("PS_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Tara")))
                        reg.Ps_tara = reader.GetDecimal(reader.GetOrdinal("PS_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_OrigemChegada_Veiculo")))
                        reg.Ps_origemchegada_veiculo = reader.GetDecimal(reader.GetOrdinal("PS_OrigemChegada_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_DesdobroClifor")))
                        reg.Qtd_desdobroclifor = reader.GetDecimal(reader.GetOrdinal("QTD_DesdobroClifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transp")))
                        reg.Cd_transp = reader.GetString(reader.GetOrdinal("CD_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Veiculo")))
                        reg.Nr_veiculo = reader.GetString(reader.GetOrdinal("Nr_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_PsBruto")))
                        reg.Login_psbruto = reader.GetString(reader.GetOrdinal("Login_PsBruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login_PsTara")))
                        reg.Login_pstara = reader.GetString(reader.GetOrdinal("Login_PsTara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TpVeiculo")))
                        reg.Cd_tpveiculo = reader.GetString(reader.GetOrdinal("CD_TpVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Agente")))
                        reg.Nm_agente = reader.GetString(reader.GetOrdinal("NM_Agente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Captura_Bruto")))
                        reg.Tp_captura_bruto = reader.GetString(reader.GetOrdinal("Tp_Captura_Bruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Captura_Tara")))
                        reg.Tp_captura_tara = reader.GetString(reader.GetOrdinal("Tp_Captura_Tara"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_TrocaNf")))
                        reg.St_trocanf = reader.GetString(reader.GetOrdinal("ST_TrocaNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Embalagem")))
                        reg.Qtd_embalagem = reader.GetDecimal(reader.GetOrdinal("QTD_Embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Embalagem")))
                        reg.Ps_embalagem = reader.GetDecimal(reader.GetOrdinal("Ps_Embalagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoCancelamento")))
                        reg.Ds_motivocancelamento = reader.GetString(reader.GetOrdinal("DS_MotivoCancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto")))
                        reg.Cd_tabeladesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaDesconto")))
                        reg.Ds_tabeladesconto = reader.GetString(reader.GetOrdinal("DS_TabelaDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Plantio")))
                        reg.Id_plantio = reader.GetDecimal(reader.GetOrdinal("Id_Plantio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                        reg.Ds_safra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cultura")))
                        reg.Id_cultura = reader.GetDecimal(reader.GetOrdinal("ID_Cultura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Talhao")))
                        reg.Id_talhao = reader.GetDecimal(reader.GetOrdinal("ID_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Talhao")))
                        reg.Ds_talhao = reader.GetString(reader.GetOrdinal("DS_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Area")))
                        reg.Id_area = reader.GetDecimal(reader.GetOrdinal("ID_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Area")))
                        reg.Ds_area = reader.GetString(reader.GetOrdinal("DS_Area"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Desconto")))
                        reg.Ps_desconto = reader.GetDecimal(reader.GetOrdinal("PS_Desconto"));

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

        public string Gravar(TRegistro_PesagemFazenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_FAZENDA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_CD_TABELADESCONTO", val.Cd_tabeladesconto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_ID_PLANTIO", val.Id_plantio);
            hs.Add("@P_ID_TALHAO", val.Id_talhao);
            hs.Add("@P_ID_AREA", val.Id_area);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_PS_DESCONTO", val.Ps_desconto);

            return this.executarProc("IA_BAL_PSFAZENDA", hs);
        }

        public string Excluir(TRegistro_PesagemFazenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_FAZENDA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("EXCLUI_BAL_PSFAZENDA", hs);
        }
    }
}
