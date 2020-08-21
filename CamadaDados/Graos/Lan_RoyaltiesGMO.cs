using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TRegistro_SaldoContratoGMO
    {
        public decimal? Nr_contrato
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Cd_unidade_valor
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public string Tp_gmo
        { get; set; }
        public decimal Saldo_credito
        { get; set; }
        public decimal Saldo_debito
        { get; set; }

        public TRegistro_SaldoContratoGMO()
        {
            this.Nr_contrato = null;
            this.Cd_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Cd_unidade_valor = string.Empty;
            this.Vl_unitario = decimal.Zero;
            this.Tp_gmo = string.Empty;
            this.Saldo_credito = decimal.Zero;
            this.Saldo_debito = decimal.Zero;
        }
    }
    
    public class TRegistro_SaldoNFGMO
    {
        public decimal? Nr_contrato
        { get; set; }
        public string Cd_produto
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public string Tp_gmo
        { get; set; }
        public decimal? Nr_lanctoduplicata
        { get; set; }
        public DateTime? Dt_saient
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Saldo_credito
        { get; set; }
        public decimal Saldo_debito
        { get; set; }

        public TRegistro_SaldoNFGMO()
        {
            this.Nr_contrato = null;
            this.Cd_produto = string.Empty;
            this.Id_nfitem = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctofiscal = null;
            this.Tp_gmo = string.Empty;
            this.Nr_lanctoduplicata = null;
            this.Dt_saient = null;
            this.Vl_unitario = decimal.Zero;
            this.Saldo_credito = decimal.Zero;
            this.Saldo_debito = decimal.Zero;
        }
    }

    public class TList_LanRoyaltiesGMO : List<TRegistro_LanRoyaltiesGMO>, IComparer<TRegistro_LanRoyaltiesGMO>
    {
        #region IComparer<TRegistro_LanRoyaltiesGMO> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_LanRoyaltiesGMO()
        { }

        public TList_LanRoyaltiesGMO(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanRoyaltiesGMO value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanRoyaltiesGMO x, TRegistro_LanRoyaltiesGMO y)
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
    
    public class TRegistro_LanRoyaltiesGMO
    {
        private decimal? id_lanctoGMO;
        public decimal? Id_lanctoGMO
        {
            get { return id_lanctoGMO; }
            set
            {
                id_lanctoGMO = value;
                id_lanctoGMOstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctoGMOstr;
        public string Id_lanctoGMOstr
        {
            get { return id_lanctoGMOstr; }
            set
            {
                id_lanctoGMOstr = value;
                try
                {
                    id_lanctoGMO = Convert.ToDecimal(value);
                }
                catch
                { id_lanctoGMO = null; }
            }
        }
        private decimal? nr_contrato;
        public decimal? Nr_Contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_Contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        public string DS_Observacao { get; set; }
        public decimal QTD_Credito { get; set; }
        public decimal QTD_Debito { get; set; }
        private string tp_lancto;
        public string TP_Lancto
        {
            get { return tp_lancto; }
            set
            {
                tp_lancto = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_lancto = "AVULSO";
                else if (value.Trim().ToUpper().Equals("N"))
                    tipo_lancto = "NORMAL";
            }
        }
        private string tipo_lancto;
        public string Tipo_Lancto
        {
            get { return tipo_lancto; }
            set
            {
                tipo_lancto = value;
                if (value.Trim().ToUpper().Equals("AVULSO"))
                    tp_lancto = "A";
                else if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_lancto = "N";
            }
        }
        private string tp_gmo;
        public string Tp_gmo
        {
            get { return tp_gmo; }
            set
            {
                tp_gmo = value;
                if (value.Trim().ToUpper().Equals("D"))
                    tipo_gmo = "INTACTA DECLARADA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_gmo = "INTACTA TESTADA";
            }
        }
        private string tipo_gmo;
        public string Tipo_gmo
        {
            get { return tipo_gmo; }
            set
            {
                tipo_gmo = value;
                if (value.Trim().ToUpper().Equals("INTACTA DECLARADA"))
                    tp_gmo = "D";
                else if (value.Trim().ToUpper().Equals("INTACTA TESTADA"))
                    tp_gmo = "T";
            }
        }
        public string Cd_clifor { get; set; }
        public string nm_Clifor { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Vl_royalties_retido
        { get; set; }
        public CamadaDados.Balanca.TList_RegLanPesagemGraos lPesagem
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDuplicata
        { get; set; }
        public CamadaDados.Financeiro.Caixa.TList_LanCaixa lCaixa
        { get; set; }
        
        public TRegistro_LanRoyaltiesGMO()
        {
            id_lanctoGMO = null;
            id_lanctoGMOstr = string.Empty;
            Nr_Contratostr = string.Empty;
            CD_Produto = string.Empty;
            DS_Produto = string.Empty;
            DS_Observacao = string.Empty;
            QTD_Credito = decimal.Zero;
            QTD_Debito = decimal.Zero;
            TP_Lancto = "A";
            tp_gmo = "D";
            tipo_gmo = "INTACTA DECLARADA";
            Cd_clifor = string.Empty;
            nm_Clifor = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla_unidade = string.Empty;
            this.Vl_royalties_retido = decimal.Zero;
            lPesagem = new CamadaDados.Balanca.TList_RegLanPesagemGraos();
            lNf = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            lDuplicata = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            lCaixa = new CamadaDados.Financeiro.Caixa.TList_LanCaixa();
        }
    }

    public class TCD_LanRoyaltiesGMO : TDataQuery
    {
        public TCD_LanRoyaltiesGMO()
        { }

        public TCD_LanRoyaltiesGMO(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_LanctoGMO, a.Nr_Contrato, ");
                sql.AppendLine("b.CD_Produto, e.DS_Produto, ");
                sql.AppendLine("a.QTD_Credito, a.QTD_Debito, a.Tp_lancto, ");
                sql.AppendLine("a.Tp_GMO, a.DS_Observacao, d.CD_Clifor, d.NM_Clifor, ");
                sql.AppendLine("f.cd_unidade, f.ds_unidade, f.sigla_unidade, ");
                sql.AppendLine("vl_royalties_retido = ISNULL((select SUM(ISNULL(y.Vl_RECEBER, 0)) ");
                sql.AppendLine("								from TB_GRO_RetencaoFinanceiraGMO x ");
                sql.AppendLine("								inner join TB_FIN_Caixa y ");
                sql.AppendLine("								on x.CD_ContaGer = y.CD_ContaGer ");
                sql.AppendLine("								and x.CD_LanctoCaixa = y.CD_LanctoCaixa ");
                sql.AppendLine("								where x.ID_LanctoGMO = a.ID_LanctoGMO ");
                sql.AppendLine("								and ISNULL(y.ST_Estorno, 'N') <> 'S'), 0) ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_GRO_RoyaltiesGMO a ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO b ");
            sql.AppendLine("on a.Nr_Contrato = b.Nr_Contrato ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on b.cd_empresa = c.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor d ");
            sql.AppendLine("on b.cd_clifor = d.CD_Clifor");
            sql.AppendLine("inner join TB_EST_Produto e ");
            sql.AppendLine("on b.CD_Produto = e.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade f ");
            sql.AppendLine("on f.cd_unidade = e.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaSaldoContratoGMO(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop);
                sql.AppendLine("sum(isnull(a.qtd_credito, 0))as Saldo_Credito,sum(isnull(a.qtd_debito, 0))as Saldo_Debito, ");
                sql.AppendLine("a.tp_gmo, p.cd_produto, p.VL_Unitario, p.CD_Unidade as cd_unidade_valor, pr.cd_unidade, p.nr_contrato ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_royaltiesgmo a ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO p ");
            sql.AppendLine("on a.Nr_Contrato = p.Nr_Contrato ");
            sql.AppendLine("inner join tb_est_produto pr ");
            sql.AppendLine("on pr.cd_produto = p.CD_Produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by a.tp_gmo, p.cd_produto, p.VL_Unitario, p.CD_Unidade, pr.cd_unidade, p.nr_contrato ");

            return sql.ToString();
        }
        
        private string SqlCodeBuscaSaldoNotaFiscalGMO(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_produto, contrato.nr_contrato, ");
                sql.AppendLine("a.id_nfitem, langmo.tp_gmo, a.vl_unitario, ");
                sql.AppendLine("nfgmo.nr_lanctoFiscal, nfgmo.cd_empresa, nfd.nr_lanctoDuplicata, nf.dt_saiEnt, ");
                sql.AppendLine("sum(langmo.qtd_credito)as Saldo_Credito, sum(langmo.qtd_debito)as Saldo_Debito");
                
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_notaFiscal_Item a");
            sql.AppendLine("inner join tb_gro_notafiscalGMO nfgmo ");
            sql.AppendLine("on a.cd_empresa = nfgmo.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoFiscal = nfgmo.nr_lanctoFiscal ");
            sql.AppendLine("and a.id_nfItem = nfgmo.id_nfItem ");
            sql.AppendLine("inner join vtb_gro_contrato contrato ");
            sql.AppendLine("on a.nr_pedido = contrato.nr_pedido ");
            sql.AppendLine("and a.cd_produto = contrato.cd_produto ");
            sql.AppendLine("and a.id_pedidoitem = contrato.id_pedidoitem ");
            sql.AppendLine("inner join tb_gro_royaltiesgmo langmo ");
            sql.AppendLine("on langmo.id_lanctoGmo = nfgmo.id_lanctoGmo");
            sql.AppendLine("inner join tb_fat_NotaFiscal_X_Duplicata nfd ");
            sql.AppendLine("on a.nr_lanctoFiscal = nfd.nr_lanctoFiscal ");
            sql.AppendLine("and a.cd_empresa = nfd.cd_empresa");
            sql.AppendLine("inner join tb_fat_notafiscal nf ");
            sql.AppendLine("on nf.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and nf.nr_lanctoFiscal = a.nr_lanctoFiscal ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by a.cd_produto, nfgmo.nr_lanctoFiscal, ");
            sql.AppendLine("nfgmo.cd_empresa, nfd.nr_lanctoDuplicata, a.id_nfitem, langmo.tp_gmo, ");
            sql.AppendLine("a.vl_unitario, nf.dt_saiEnt, contrato.nr_contrato ");
            sql.AppendLine("having sum(langmo.qtd_credito) < sum(langmo.qtd_debito)");
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
        
        public List<TRegistro_SaldoNFGMO> SelectSaldoNFGMO(TpBusca[] vBusca, short vTop)
        {
            List<TRegistro_SaldoNFGMO> lista = new List<TRegistro_SaldoNFGMO>();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaSaldoNotaFiscalGMO(vBusca, vTop, string.Empty));
                while (reader.Read())
                {
                    TRegistro_SaldoNFGMO reg = new TRegistro_SaldoNFGMO();

                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_GMO")))
                        reg.Tp_gmo = reader.GetString(reader.GetOrdinal("TP_GMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoDuplicata")))
                        reg.Nr_lanctoduplicata = reader.GetDecimal(reader.GetOrdinal("nr_lanctoDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_saiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("dt_saiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo_Credito")))
                        reg.Saldo_credito = reader.GetDecimal(reader.GetOrdinal("Saldo_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo_Debito")))
                        reg.Saldo_debito = reader.GetDecimal(reader.GetOrdinal("Saldo_Debito"));

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

        public List<TRegistro_SaldoContratoGMO> SelectSaldoContratoGMO(TpBusca[] vBusca, short vTop)
        {
            List<TRegistro_SaldoContratoGMO> lista = new List<TRegistro_SaldoContratoGMO>();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBuscaSaldoContratoGMO(vBusca, vTop, string.Empty));
                while (reader.Read())
                {
                    TRegistro_SaldoContratoGMO reg = new TRegistro_SaldoContratoGMO();

                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade_valor")))
                        reg.Cd_unidade_valor = reader.GetString(reader.GetOrdinal("cd_unidade_valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_GMO")))
                        reg.Tp_gmo = reader.GetString(reader.GetOrdinal("TP_GMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo_Credito")))
                        reg.Saldo_credito = reader.GetDecimal(reader.GetOrdinal("Saldo_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Saldo_Debito")))
                        reg.Saldo_debito = reader.GetDecimal(reader.GetOrdinal("Saldo_Debito"));

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

        public TList_LanRoyaltiesGMO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanRoyaltiesGMO lista = new TList_LanRoyaltiesGMO();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanRoyaltiesGMO reg = new TRegistro_LanRoyaltiesGMO();
                
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoGMO")))
                        reg.Id_lanctoGMO = reader.GetDecimal(reader.GetOrdinal("ID_LanctoGMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_Contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Credito")))
                        reg.QTD_Credito = reader.GetDecimal(reader.GetOrdinal("QTD_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Debito")))
                        reg.QTD_Debito = reader.GetDecimal(reader.GetOrdinal("QTD_Debito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Lancto")))
                        reg.TP_Lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_GMO")))
                        reg.Tp_gmo = reader.GetString(reader.GetOrdinal("TP_GMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.nm_Clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_royalties_retido")))
                        reg.Vl_royalties_retido = reader.GetDecimal(reader.GetOrdinal("vl_royalties_retido"));
                    
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

        public string Gravar(TRegistro_LanRoyaltiesGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_LANCTOGMO", vRegistro.Id_lanctoGMO);
            hs.Add("@P_NR_CONTRATO", vRegistro.Nr_Contrato);
            hs.Add("@P_QTD_CREDITO", vRegistro.QTD_Credito);
            hs.Add("@P_QTD_DEBITO", vRegistro.QTD_Debito);
            hs.Add("@P_TP_LANCTO", vRegistro.TP_Lancto);
            hs.Add("@P_TP_GMO", vRegistro.Tp_gmo);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_Observacao);

            return this.executarProc("IA_GRO_ROYALTIESGMO", hs);
        }

        public string Excluir(TRegistro_LanRoyaltiesGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LANCTOGMO", vRegistro.Id_lanctoGMO);

            return this.executarProc("EXCLUI_GRO_ROYALTIESGMO", hs);
        }
    }
}

