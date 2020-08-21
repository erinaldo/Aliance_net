using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_NegociacaoItem : List<TRegistro_NegociacaoItem>
    { }

    
    public class TRegistro_NegociacaoItem
    {
        
        public decimal? Id_negociacao
        { get; set; }
        
        public decimal? Id_item
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
        
        public string Nm_vendedor
        { get; set; }
        
        public string Email_vendedor
        { get; set; }
        
        public string FoneFax
        { get; set; }
        
        public decimal Qtd_porcompra
        { get; set; }
        
        public decimal Qtd_min_compra
        { get; set; }
        
        public decimal Vl_unitario_negociado
        { get; set; }
        
        public decimal Nr_diasvigencia
        { get; set; }
        
        public string Ds_observacao
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
                else if (value.Trim().ToUpper().Equals("V"))
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
                    st_registro = "V";
                else if (value.Trim().ToUpper().Equals("REPROVADA"))
                    st_registro = "R";
            }
        }
        
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
        private string st_depositarpagto;
        
        public string St_depositarpagto
        {
            get { return st_depositarpagto; }
            set
            {
                st_depositarpagto = value;
                st_depositarpagtobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_depositarpagtobool;
        
        public bool St_depositarpagtobool
        {
            get { return st_depositarpagtobool; }
            set
            {
                st_depositarpagtobool = value;
                if (value)
                    st_depositarpagto = "S";
                else
                    st_depositarpagto = "N";
            }
        }
        
        public decimal Nr_diaspagamento
        { get; set; }
        
        public string Ds_aprovarreprovar
        { get; set; }
        
        public TList_PrazoEntrega lPrazoEntrega
        { get; set; }
        
        public TList_PrazoEntrega lPrazoEntregaDel
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_NegociacaoItem()
        {
            this.Id_negociacao = null;
            this.Id_item = null;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.Cd_endfornecedor = string.Empty;
            this.Ds_endfornecedor = string.Empty;
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Email_vendedor = string.Empty;
            this.FoneFax = string.Empty;
            this.Qtd_porcompra = decimal.Zero;
            this.Qtd_min_compra = decimal.Zero;
            this.Vl_unitario_negociado = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.Nr_diasvigencia = decimal.Zero;
            this.st_registro = "A";
            this.status = "ABERTA";
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.st_depositarpagto = "N";
            this.st_depositarpagtobool = false;
            this.Nr_diaspagamento = decimal.Zero;
            this.lPrazoEntrega = new TList_PrazoEntrega();
            this.lPrazoEntregaDel = new TList_PrazoEntrega();
            this.St_processar = false;
            this.Ds_aprovarreprovar = string.Empty;
        }

        public TRegistro_NegociacaoItem Copia()
        {
            return new TRegistro_NegociacaoItem()
            {
                Id_negociacao = this.Id_negociacao,
                Id_item = this.Id_item,
                Cd_fornecedor = this.Cd_fornecedor,
                Nm_fornecedor = this.Nm_fornecedor,
                Cd_condpgto = this.Cd_condpgto,
                Ds_condpgto = this.Ds_condpgto,
                Nm_vendedor = this.Nm_vendedor,
                Email_vendedor = this.Email_vendedor,
                FoneFax = this.FoneFax,
                Qtd_porcompra = this.Qtd_porcompra,
                Qtd_min_compra = this.Qtd_min_compra,
                Vl_unitario_negociado = this.Vl_unitario_negociado,
                Nr_diasvigencia = this.Nr_diasvigencia,
                Ds_observacao = this.Ds_observacao,
                st_registro = this.st_registro,
                St_processar = this.St_processar,
                Ds_aprovarreprovar = this.Ds_aprovarreprovar
            };
        }
    }

    public class TCD_NegociacaoItem : TDataQuery
    {
        public TCD_NegociacaoItem()
        { }

        public TCD_NegociacaoItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_negociacao, a.id_item, a.cd_fornecedor, ");
                sql.AppendLine("a.cd_endfornecedor, endForn.ds_endereco as ds_endfornecedor, ");
                sql.AppendLine("b.nm_clifor as nm_fornecedor, a.cd_condpgto, c.ds_condpgto, a.nm_vendedor, ");
                sql.AppendLine("a.email_vendedor, a.fonefax, a.qtd_porcompra, ");
                sql.AppendLine("a.qtd_min_compra, a.vl_unitario_negociado, ");
                sql.AppendLine("a.ds_observacao, a.nr_diasvigencia, a.st_registro, ");
                sql.AppendLine("a.cd_moeda, f.ds_moeda_singular, f.sigla, a.ds_aprovarreprovar, ");
                sql.AppendLine("a.cd_portador, g.ds_portador, a.st_depositarpagto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_negociacao_item a ");
            sql.AppendLine("inner join vtb_fin_clifor b ");
            sql.AppendLine("on a.cd_fornecedor = b.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco endForn ");
            sql.AppendLine("on a.cd_fornecedor = endForn.cd_clifor ");
            sql.AppendLine("and a.cd_endfornecedor = endforn.cd_endereco ");
            sql.AppendLine("inner join tb_fin_condpgto c ");
            sql.AppendLine("on a.cd_condpgto = c.cd_condpgto ");
            sql.AppendLine("inner join tb_cmp_negociacao d ");
            sql.AppendLine("on a.id_negociacao = d.id_negociacao ");
            sql.AppendLine("left outer join tb_fin_moeda f ");
            sql.AppendLine("on a.cd_moeda = f.cd_moeda ");
            sql.AppendLine("left outer join tb_fin_portador g ");
            sql.AppendLine("on a.cd_portador = g.cd_portador ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_NegociacaoItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_NegociacaoItem lista = new TList_NegociacaoItem();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NegociacaoItem reg = new TRegistro_NegociacaoItem();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Negociacao"))))
                        reg.Id_negociacao = reader.GetDecimal(reader.GetOrdinal("ID_Negociacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor"))))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor"))))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndFornecedor")))
                        reg.Cd_endfornecedor = reader.GetString(reader.GetOrdinal("CD_EndFornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndFornecedor")))
                        reg.Ds_endfornecedor = reader.GetString(reader.GetOrdinal("DS_EndFornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_condpgto"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email_vendedor")))
                        reg.Email_vendedor = reader.GetString(reader.GetOrdinal("Email_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FoneFax")))
                        reg.FoneFax = reader.GetString(reader.GetOrdinal("FoneFax"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Min_Compra")))
                        reg.Qtd_min_compra = reader.GetDecimal(reader.GetOrdinal("QTD_Min_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_porCompra")))
                        reg.Qtd_porcompra = reader.GetDecimal(reader.GetOrdinal("QTD_porCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario_Negociado")))
                        reg.Vl_unitario_negociado = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario_Negociado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasVigencia")))
                        reg.Nr_diasvigencia = reader.GetDecimal(reader.GetOrdinal("NR_DiasVigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_DepositarPagto")))
                        reg.St_depositarpagto = reader.GetString(reader.GetOrdinal("ST_DepositarPagto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_AprovarReprovar")))
                        reg.Ds_aprovarreprovar = reader.GetString(reader.GetOrdinal("DS_AprovarReprovar"));

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

        public string GravarNegociacaoItem(TRegistro_NegociacaoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(20);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_ENDFORNECEDOR", val.Cd_endfornecedor);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_NM_VENDEDOR", val.Nm_vendedor);
            hs.Add("@P_EMAIL_VENDEDOR", val.Email_vendedor);
            hs.Add("@P_FONEFAX", val.FoneFax);
            hs.Add("@P_QTD_PORCOMPRA", val.Qtd_porcompra);
            hs.Add("@P_QTD_MIN_COMPRA", val.Qtd_min_compra);
            hs.Add("@P_VL_UNITARIO_NEGOCIADO", val.Vl_unitario_negociado);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_NR_DIASVIGENCIA", val.Nr_diasvigencia);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_ST_DEPOSITARPAGTO", val.St_depositarpagto);
            hs.Add("@P_NR_DIASPAGAMENTO", val.Nr_diaspagamento);
            hs.Add("@P_DS_APROVARREPROVAR", val.Ds_aprovarreprovar);

            return this.executarProc("IA_CMP_NEGOCIACAO_ITEM", hs);
        }

        public string DeletarNegociacaoItem(TRegistro_NegociacaoItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUIR_CMP_NEGOCIACAO_ITEM", hs);
        }
    }
}
