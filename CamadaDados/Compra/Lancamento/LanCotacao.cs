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
    public class TList_Cotacao : List<TRegistro_Cotacao>, IComparer<TRegistro_Cotacao>
    {
        #region IComparer<TRegistro_Cotacao> Members
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

        public TList_Cotacao()
        { }

        public TList_Cotacao(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cotacao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cotacao x, TRegistro_Cotacao y)
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
    
    public class TRegistro_Cotacao
    {
        public decimal? Id_cotacao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
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
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public decimal? Id_requisicao
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
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
        public decimal Vl_frete { get; set; } = decimal.Zero;
        public decimal Prazo_entrega
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Emailvendedor
        { get; set; }
        public string Fonefax
        { get; set; }
        public decimal Qtd_atendida
        { get; set; }
        public decimal Vl_unitario_cotado
        { get; set; }
        public decimal Vl_subtotal
        {
            get { return Qtd_atendida * Vl_unitario_cotado; }
        }
        private DateTime? dt_cotacao;
        public DateTime? Dt_cotacao
        {
            get { return dt_cotacao; }
            set
            {
                dt_cotacao = value;
                dt_cotacaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_cotacaostr;
        public string Dt_cotacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_cotacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_cotacaostr = value;
                try
                {
                    dt_cotacao = Convert.ToDateTime(value);
                }
                catch
                { dt_cotacao = null; }
            }
        }
        public string Ds_observacao
        { get; set; }
        public decimal Nr_diasvigencia
        { get; set; }
        public string Dt_validadecotacao
        {
            get
            {
                if ((Nr_diasvigencia > 0) && (dt_cotacao != null))
                    return dt_cotacao.Value.AddDays(Convert.ToDouble(Nr_diasvigencia)).ToString("dd/MM/yyyy");
                else
                    return string.Empty;
            }
        }
        public decimal Vl_ipi
        { get; set; }
        public decimal Vl_icmssubst
        { get; set; }
        public decimal Pc_icms
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTA";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "APROVADA";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "REPROVADA";
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
                else if (value.Trim().ToUpper().Equals("APROVADA"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("REPROVADA"))
                    st_registro = "R";
            }
        }
        public bool St_integrar
        { get; set; }

        public TRegistro_Cotacao()
        {
            Id_cotacao = null;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_fornecedor = string.Empty;
            Nm_fornecedor = string.Empty;
            Cd_endfornecedor = string.Empty;
            Ds_endfornecedor = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Cd_moeda = string.Empty;
            Ds_moeda = string.Empty;
            Sigla = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Id_requisicao = null;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Sigla_unidade = string.Empty;
            Cd_transportadora = string.Empty;
            Nm_transportadora = string.Empty;
            Cd_endtransportadora = string.Empty;
            Ds_endtransportadora = string.Empty;
            tp_frete = string.Empty;
            tipo_frete = string.Empty;
            Prazo_entrega = decimal.Zero;
            Nm_vendedor = string.Empty;
            Emailvendedor = string.Empty;
            Fonefax = string.Empty;
            Qtd_atendida = decimal.Zero;
            Vl_unitario_cotado = decimal.Zero;
            dt_cotacao = DateTime.Now;
            dt_cotacaostr = DateTime.Now.ToString("dd/MM/yyyy");
            Ds_observacao = string.Empty;
            Nr_diasvigencia = decimal.Zero;
            st_registro = "A";
            status = "ABERTA";
            Vl_ipi = decimal.Zero;
            Vl_icmssubst = decimal.Zero;
            Pc_icms = decimal.Zero;

            St_integrar = false;
        }
    }

    public class TCD_Cotacao : TDataQuery
    {
        public TCD_Cotacao()
        { }

        public TCD_Cotacao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string cond = string.Empty;
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {

                sql.AppendLine("select " + strTop + " a.ID_Cotacao, a.cd_empresa, emp.nm_empresa, a.CD_Fornecedor, b.NM_Clifor as nm_fornecedor, ");
                sql.AppendLine("a.cd_endfornecedor, endfornec.ds_endereco as ds_endfornecedor, a.vl_ipi, a.vl_icmssubst, a.pc_icms, ");
                sql.AppendLine("a.CD_CondPGTO, c.DS_CondPGTO, a.CD_Moeda, d.DS_Moeda_Singular, d.Sigla, ");
                sql.AppendLine("a.CD_Portador, e.DS_Portador, a.ID_Requisicao, f.CD_Produto, ");
                sql.AppendLine("g.DS_Produto, h.Sigla_Unidade, a.CD_Transportadora, ");
                sql.AppendLine("a.cd_endtransportadora, endTransp.ds_endereco as ds_endtransportadora, ");
                sql.AppendLine("i.NM_Clifor as nm_transportadora, a.TP_Frete, a.vl_frete, a.Prazo_Entrega, ");
                sql.AppendLine("a.NM_Vendedor, a.EmailVendedor, a.FoneFax, a.Qtd_Atendida, ");
                sql.AppendLine("a.Vl_Unitario_Cotado, a.DT_Cotacao, a.DS_Observacao, a.NR_DiasVigencia, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CMP_Cotacao a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR b ");
            sql.AppendLine("on a.CD_Fornecedor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco endFornec ");
            sql.AppendLine("on a.cd_fornecedor = endFornec.cd_clifor ");
            sql.AppendLine("and a.cd_endfornecedor = endFornec.cd_endereco ");
            sql.AppendLine("inner join TB_FIN_CondPGTO c ");
            sql.AppendLine("on a.CD_CondPGTO = c.CD_CondPGTO ");
            sql.AppendLine("inner join TB_FIN_Moeda d ");
            sql.AppendLine("on a.CD_Moeda = d.CD_Moeda ");
            sql.AppendLine("left outer join TB_FIN_Portador e ");
            sql.AppendLine("on a.CD_Portador = e.CD_Portador ");
            sql.AppendLine("inner join TB_CMP_Requisicao f ");
            sql.AppendLine("on a.ID_Requisicao = f.ID_Requisicao ");
            sql.AppendLine("and a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto g ");
            sql.AppendLine("on f.CD_Produto = g.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade h ");
            sql.AppendLine("on g.CD_Unidade = h.CD_Unidade ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR i ");
            sql.AppendLine("on a.CD_Transportadora = i.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco EndTransp ");
            sql.AppendLine("on a.cd_transportadora = endTransp.cd_clifor ");
            sql.AppendLine("and a.cd_endtransportadora = endTransp.cd_endereco ");

            cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
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

        public TList_Cotacao Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Cotacao lista = new TList_Cotacao();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cotacao reg = new TRegistro_Cotacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cotacao"))))
                        reg.Id_cotacao = reader.GetDecimal(reader.GetOrdinal("ID_Cotacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Requisicao")))
                        reg.Id_requisicao = reader.GetDecimal(reader.GetOrdinal("ID_Requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
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
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("emailvendedor")))
                        reg.Emailvendedor = reader.GetString(reader.GetOrdinal("emailvendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fonefax")))
                        reg.Fonefax = reader.GetString(reader.GetOrdinal("fonefax"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_atendida")))
                        reg.Qtd_atendida = reader.GetDecimal(reader.GetOrdinal("qtd_atendida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario_cotado")))
                        reg.Vl_unitario_cotado = reader.GetDecimal(reader.GetOrdinal("vl_unitario_cotado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_cotacao")))
                        reg.Dt_cotacao = reader.GetDateTime(reader.GetOrdinal("dt_cotacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasvigencia")))
                        reg.Nr_diasvigencia = reader.GetDecimal(reader.GetOrdinal("nr_diasvigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ipi")))
                        reg.Vl_ipi = reader.GetDecimal(reader.GetOrdinal("vl_ipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_icmssubst")))
                        reg.Vl_icmssubst = reader.GetDecimal(reader.GetOrdinal("vl_icmssubst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_icms")))
                        reg.Pc_icms = reader.GetDecimal(reader.GetOrdinal("pc_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_Cotacao val)
        {
            Hashtable hs = new Hashtable(24);
            hs.Add("@P_ID_COTACAO", val.Id_cotacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_ENDFORNECEDOR", val.Cd_endfornecedor);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_ID_REQUISICAO", val.Id_requisicao);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_CD_ENDTRANSPORTADORA", val.Cd_endtransportadora);
            hs.Add("@P_TP_FRETE", val.Tp_frete);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_PRAZO_ENTREGA", val.Prazo_entrega);
            hs.Add("@P_NM_VENDEDOR", val.Nm_vendedor);
            hs.Add("@P_EMAILVENDEDOR", val.Emailvendedor);
            hs.Add("@P_FONEFAX", val.Fonefax);
            hs.Add("@P_QTD_ATENDIDA", val.Qtd_atendida);
            hs.Add("@P_VL_UNITARIO_COTADO", val.Vl_unitario_cotado);
            hs.Add("@P_DT_COTACAO", val.Dt_cotacao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_NR_DIASVIGENCIA", val.Nr_diasvigencia);
            hs.Add("@P_VL_IPI", val.Vl_ipi);
            hs.Add("@P_VL_ICMSSUBST", val.Vl_icmssubst);
            hs.Add("@P_PC_ICMS", val.Pc_icms);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_CMP_COTACAO", hs);
        }

        public string Excluir(TRegistro_Cotacao val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_COTACAO", val.Id_cotacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_CMP_COTACAO", hs);
        }
    }
}
