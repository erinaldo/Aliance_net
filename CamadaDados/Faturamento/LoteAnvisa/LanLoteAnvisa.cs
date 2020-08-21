using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.LoteAnvisa
{
    #region Lote Anvisa
    public class TList_LoteAnvisa : List<TRegistro_LoteAnvisa>, IComparer<TRegistro_LoteAnvisa>
    {
        #region IComparer<TRegistro_LoteAnvisa> Members
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

        public TList_LoteAnvisa()
        { }

        public TList_LoteAnvisa(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteAnvisa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteAnvisa x, TRegistro_LoteAnvisa y)
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

    public class TRegistro_LoteAnvisa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch { id_lote = null; }
            }
        }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sg_unidade
        { get; set; }
        public string Nr_lote
        { get; set; }
        private DateTime? dt_fabric;
        public DateTime? Dt_fabric
        {
            get { return dt_fabric; }
            set
            {
                dt_fabric = value;
                dt_fabricstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fabricstr;
        public string Dt_fabricstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_fabricstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_fabricstr = value;
                try
                {
                    dt_fabric = DateTime.Parse(value);
                }
                catch { dt_fabric = null; }
            }
        }
        private DateTime? dt_validade;
        public DateTime? Dt_validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                Dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;
        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = DateTime.Parse(value);
                }
                catch { dt_validade = null; }
            }
        }
        public decimal Qtd_loteEnt
        { get; set; }
        public decimal Qtd_loteSai
        { get; set; }
        public decimal Qtd_saldo
        { get { return this.Qtd_loteEnt - this.Qtd_loteSai; } }
        public string Status
        { get { return Qtd_saldo > decimal.Zero ? "ABERTO" : "ENCERRADO"; } }

        public TList_MovLoteAnvisa lMov
        { get; set; }

        public TRegistro_LoteAnvisa()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sg_unidade = string.Empty;
            this.Nr_lote = string.Empty;
            this.dt_fabric = null;
            this.dt_fabricstr = string.Empty;
            this.dt_validade = null;
            this.dt_validadestr = string.Empty;
            this.Qtd_loteEnt = decimal.Zero;
            this.Qtd_loteSai = decimal.Zero;

            this.lMov = new TList_MovLoteAnvisa();
        }
    }

    public class TCD_LoteAnvisa : TDataQuery
    {
        public TCD_LoteAnvisa() { }

        public TCD_LoteAnvisa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_Lote, a.CD_Fornecedor, c.NM_Clifor, ");
                sql.AppendLine("a.CD_Produto, d.DS_Produto, e.Sigla_Unidade, ");
                sql.AppendLine("a.NR_Lote, a.DT_Fabric, a.DT_Validade, ");
                sql.AppendLine("a.Qtd_entrada, a.Qtd_saida ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FAT_LOTEANVISA a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Fornecedor = c.cd_clifor ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on a.CD_Produto = d.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on d.CD_Unidade = e.CD_Unidade ");

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

        public TList_LoteAnvisa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LoteAnvisa lista = new TList_LoteAnvisa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LoteAnvisa reg = new TRegistro_LoteAnvisa();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("NR_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fabric")))
                        reg.Dt_fabric = reader.GetDateTime(reader.GetOrdinal("DT_Fabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("DT_Validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_entrada")))
                        reg.Qtd_loteEnt = reader.GetDecimal(reader.GetOrdinal("Qtd_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_saida")))
                        reg.Qtd_loteSai = reader.GetDecimal(reader.GetOrdinal("Qtd_saida"));

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

        public string Gravar(TRegistro_LoteAnvisa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_NR_LOTE", val.Nr_lote);
            hs.Add("@P_DT_FABRIC", val.Dt_fabric);
            hs.Add("@P_DT_VALIDADE", val.Dt_validade);

            return this.executarProc("IA_FAT_LOTEANVISA", hs);
        }

        public string Excluir(TRegistro_LoteAnvisa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_FAT_LOTEANVISA", hs);
        }
    }
    #endregion

    #region Movimento Lote
    public class TList_MovLoteAnvisa : List<TRegistro_MovLoteAnvisa>
    { }
    
    public class TRegistro_MovLoteAnvisa
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_lote;
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lotestr;
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = decimal.Parse(value);
                }
                catch { id_lote = null; }
            }
        }
        public string Nr_lote
        { get; set; }
        public DateTime? Dt_fabric
        { get; set; }
        public DateTime? Dt_validade
        { get; set; }
        private decimal? id_mov;
        public decimal? Id_mov
        {
            get { return id_mov; }
            set
            {
                id_mov = value;
                id_movstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movstr;
        public string Id_movstr
        {
            get { return id_movstr; }
            set
            {
                id_movstr = value;
                try
                {
                    id_mov = decimal.Parse(value);
                }
                catch { id_mov = null; }
            }
        }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_nfitem;
        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;
        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch { id_cupom = null; }
            }
        }
        private decimal? id_lancto;
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch { id_lancto = null; }
            }
        }
        public string Cd_produto
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
                catch { id_lanctoestoque = null; }
            }
        }
        private string tp_mov;
        public string Tp_mov
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_mov = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_mov = "SAIDA";
            }
        }
        private string tipo_mov;
        public string Tipo_mov
        {
            get { return tipo_mov; }
            set
            {
                tipo_mov = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_mov = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_mov = "S";
            }
        }
        public decimal Quantidade
        { get; set; }

        public TRegistro_MovLoteAnvisa()
        {
            this.Cd_empresa = string.Empty;
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Nr_lote = string.Empty;
            this.Dt_fabric = null;
            this.Dt_validade = null;
            this.id_mov = null;
            this.id_movstr = string.Empty;
            this.nr_lanctofiscal = null;
            this.nr_lanctofiscalstr = string.Empty;
            this.id_nfitem = null;
            this.id_nfitemstr = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.id_lanctoestoque = null;
            this.id_lanctoestoquestr = string.Empty;
            this.tp_mov = string.Empty;
            this.tipo_mov = string.Empty;
            this.Quantidade = decimal.Zero;
        }
    }

    public class TCD_MovLoteAnvisa : TDataQuery
    {
        public TCD_MovLoteAnvisa() { }

        public TCD_MovLoteAnvisa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Lote, a.cd_produto, ");
                sql.AppendLine("a.ID_Mov, a.NR_LanctoFiscal, a.ID_NFItem, a.id_lanctoestoque, ");
                sql.AppendLine("a.ID_Cupom, a.ID_Lancto, a.TP_Mov, a.Quantidade, b.nr_lote, ");
                sql.AppendLine("b.dt_fabric, b.dt_validade ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_MovLoteAnvisa a ");
            sql.AppendLine("inner join TB_FAT_LoteAnvisa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_lote = b.id_lote ");

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

        public TList_MovLoteAnvisa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_MovLoteAnvisa lista = new TList_MovLoteAnvisa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_MovLoteAnvisa reg = new TRegistro_MovLoteAnvisa();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("nr_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fabric")))
                        reg.Dt_fabric = reader.GetDateTime(reader.GetOrdinal("dt_fabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_validade")))
                        reg.Dt_validade = reader.GetDateTime(reader.GetOrdinal("dt_validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mov")))
                        reg.Id_mov = reader.GetDecimal(reader.GetOrdinal("ID_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("ID_Cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lancto")))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

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

        public string Gravar(TRegistro_MovLoteAnvisa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return this.executarProc("IA_FAT_MOVLOTEANVISA", hs);
        }

        public string Excluir(TRegistro_MovLoteAnvisa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_MOV", val.Id_mov);

            return this.executarProc("EXCLUI_FAT_MOVLOTEANVISA", hs);
        }
    }
    #endregion
}
