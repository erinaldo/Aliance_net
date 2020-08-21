using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaDados.Graos
{
    #region Impostos Reter Fixacao
    public class TRegistro_ImpostosReter
    {
        public decimal? Cd_imposto
        { get; set; }
        public string Ds_imposto
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_retencao
        { get; set; }
        public decimal Vl_rentecao
        { get; set; }

        public TRegistro_ImpostosReter()
        {
            this.Cd_imposto = null;
            this.Ds_imposto = string.Empty;
            this.Vl_basecalc = decimal.Zero;
            this.Pc_retencao = decimal.Zero;
            this.Vl_rentecao = decimal.Zero;
        }
    }
    #endregion

    #region Fixacao
    public class TList_LanFixacao : List<TRegistro_LanFixacao>
    { }
    
    public class TRegistro_LanFixacao
    {
        public decimal? Id_fixacao
        { get; set; }
        private DateTime? dt_fixacao;
        public DateTime? Dt_fixacao
        {
            get { return dt_fixacao; }
            set
            {
                dt_fixacao = value;
                dt_fixacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fixacaostr;
        public string Dt_fixacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fixacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fixacaostr = value;
                try
                {
                    dt_fixacao = Convert.ToDateTime(value);
                }
                catch
                { dt_fixacao = null; }
            }
        }
        public decimal Ps_fixado_total
        { get; set; }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        public decimal Vl_bonificacao
        { get; set; }
        public decimal Vl_adiantamento
        { get; set; }
        public decimal Vl_impostosret
        { get; set; }
        public decimal Vl_royalties_declarado
        { get; set; }
        public decimal Vl_royalties_testado
        { get; set; }
        public decimal Vl_royalties
        { get; set; }
        public decimal Vl_fixacao
        { get; set; }
        public decimal Vl_financeiro
        { get { return Math.Round(Vl_fixacao, 2) - Math.Round(Vl_impostosret, 2) - Math.Round(Vl_royalties, 2); } }
        public decimal Vl_liquido
        { get { return Vl_fixacao - Vl_impostosret - Vl_adiantamento - Vl_royalties; } }
        public string Ds_observacao
        { get; set; }
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch { nr_contrato = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidestoque
        { get; set; }
        public string Ds_unidestoque
        { get; set; }
        public string Sigla_unidestoque
        { get; set; }
        public string Cd_unidvalor
        { get; set; }
        public string Ds_unidvalor
        { get; set; }
        public string Sigla_unidvalor
        { get; set; }
        public decimal Qtd_gmo_declarado
        { get; set; }
        public decimal Qtd_gmo_testado
        { get; set; }
        public string Obsretencao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (this.St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public TList_Fixacao_NF lFixacaonf
        { get; set; }
        public TRegistro_LanFaturamento rNfDev { get; set; }
        public TRegistro_Fixacao_X_Contrato rFixacao_pedido
        { get; set; }
        public TRegistro_LanDuplicata rDup
        { get; set; }
        public TList_RegLanDuplicata lDupFixacao
        { get; set; }
        public TList_RegLanFaturamento_Item lItemNf
        { get; set; }
        
        public TRegistro_LanFixacao()
        {
            Id_fixacao = null;
            dt_fixacao = null;
            dt_fixacaostr = string.Empty;
            Ps_fixado_total = decimal.Zero;
            vl_unitario = decimal.Zero;
            Vl_bonificacao = decimal.Zero;
            Vl_adiantamento = decimal.Zero;
            Vl_impostosret = decimal.Zero;
            Vl_royalties = decimal.Zero;
            Vl_royalties_declarado = decimal.Zero;
            Vl_royalties_testado = decimal.Zero;
            Vl_fixacao = decimal.Zero;
            Ds_observacao = string.Empty;
            nr_contrato = null;
            nr_contratostr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidestoque = string.Empty;
            Ds_unidestoque = string.Empty;
            Sigla_unidestoque = string.Empty;
            Cd_unidvalor = string.Empty;
            Ds_unidvalor = string.Empty;
            Sigla_unidvalor = string.Empty;
            Qtd_gmo_declarado = decimal.Zero;
            Qtd_gmo_testado = decimal.Zero;
            St_registro = "A";
            lFixacaonf = new TList_Fixacao_NF();
            rFixacao_pedido = null;
            rDup = null;
            lDupFixacao = new TList_RegLanDuplicata();
            lItemNf = new TList_RegLanFaturamento_Item();
        }
    }

    public class TCD_LanFixacao : TDataQuery
    {
        public TCD_LanFixacao()
        { }

        public TCD_LanFixacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_fixacao, a.dt_fixacao, a.vl_bonificacao, ");
                sql.AppendLine("a.ps_fixado_total, a.vl_unitario, a.vl_fixacao, ");
                sql.AppendLine("a.ds_observacao, b.nr_contrato, c.cd_produto, ");
                sql.AppendLine("unidvalor.cd_unidade as Cd_unidvalor, a.st_registro, ");
                sql.AppendLine("unidvalor.ds_unidade as Ds_unidvalor, d.ds_produto, ");
                sql.AppendLine("unidvalor.sigla_unidade as Sigla_unidvalor, ");
                sql.AppendLine("unidestoque.cd_unidade as Cd_unidestoque, ");
                sql.AppendLine("unidestoque.ds_unidade as Ds_unidestoque, ");
                sql.AppendLine("unidestoque.sigla_unidade as Sigla_unidestoque, ");
                sql.AppendLine("a.vl_adiantamento, a.vl_impostosret, a.vl_royalties ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_fixacao a ");
            sql.AppendLine("inner join TB_GRO_Fixacao_X_Contrato b ");
            sql.AppendLine("on a.id_fixacao = b.id_fixacao ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO c ");
            sql.AppendLine("on b.nr_contrato = c.nr_contrato ");
            sql.AppendLine("inner join tb_est_unidade unidvalor ");
            sql.AppendLine("on c.cd_unidade = unidvalor.cd_unidade ");
            sql.AppendLine("inner join tb_est_produto d ");
            sql.AppendLine("on c.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade unidestoque ");
            sql.AppendLine("on d.cd_unidade = unidestoque.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanFixacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanFixacao lista = new TList_LanFixacao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanFixacao reg = new TRegistro_LanFixacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fixacao")))
                        reg.Id_fixacao = reader.GetDecimal(reader.GetOrdinal("ID_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Fixacao")))
                        reg.Dt_fixacao = reader.GetDateTime(reader.GetOrdinal("DT_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PS_Fixado_Total")))
                        reg.Ps_fixado_total = reader.GetDecimal(reader.GetOrdinal("PS_Fixado_Total"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Adiantamento")))
                        reg.Vl_adiantamento = reader.GetDecimal(reader.GetOrdinal("Vl_Adiantamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ImpostosRet")))
                        reg.Vl_impostosret = reader.GetDecimal(reader.GetOrdinal("Vl_ImpostosRet"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Royalties")))
                        reg.Vl_royalties = reader.GetDecimal(reader.GetOrdinal("Vl_Royalties"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Fixacao")))
                        reg.Vl_fixacao = reader.GetDecimal(reader.GetOrdinal("Vl_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unidvalor")))
                        reg.Cd_unidvalor = reader.GetString(reader.GetOrdinal("Cd_unidvalor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_unidvalor")))
                        reg.Ds_unidvalor = reader.GetString(reader.GetOrdinal("Ds_unidvalor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidvalor")))
                        reg.Sigla_unidvalor = reader.GetString(reader.GetOrdinal("Sigla_unidvalor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unidestoque")))
                        reg.Cd_unidestoque = reader.GetString(reader.GetOrdinal("Cd_unidestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_unidestoque")))
                        reg.Ds_unidestoque = reader.GetString(reader.GetOrdinal("Ds_unidestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidestoque")))
                        reg.Sigla_unidestoque = reader.GetString(reader.GetOrdinal("Sigla_unidestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_bonificacao")))
                        reg.Vl_bonificacao = reader.GetDecimal(reader.GetOrdinal("vl_bonificacao"));
                    
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

        public string Gravar(TRegistro_LanFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_DT_FIXACAO", val.Dt_fixacao);
            hs.Add("@P_PS_FIXADO_TOTAL", val.Ps_fixado_total);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_BONIFICACAO", val.Vl_bonificacao);
            hs.Add("@P_VL_FIXACAO", val.Vl_fixacao);
            hs.Add("@P_VL_ADIANTAMENTO", val.Vl_adiantamento);
            hs.Add("@P_VL_IMPOSTOSRET", val.Vl_impostosret);
            hs.Add("@P_VL_ROYALTIES", val.Vl_royalties);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_GRO_FIXACAO", hs);
        }

        public string Excluir(TRegistro_LanFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);

            return this.executarProc("EXCLUI_GRO_FIXACAO", hs);
        }
    }
    #endregion

    #region Fixacao X Contrato
    public class TList_Fixacao_X_Contrato : List<TRegistro_Fixacao_X_Contrato>
    { }

    
    public class TRegistro_Fixacao_X_Contrato
    {
        
        public decimal? Nr_contrato
        { get; set; }
        
        public decimal? Id_fixacao
        { get; set; }

        public TRegistro_Fixacao_X_Contrato()
        {
            this.Nr_contrato = null;
            this.Id_fixacao = null;
        }
    }

    public class TCD_Fixacao_X_Contrato : TDataQuery
    {
        public TCD_Fixacao_X_Contrato()
        { }

        public TCD_Fixacao_X_Contrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.id_fixacao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_gro_fixacao_x_contrato a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Fixacao_X_Contrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Fixacao_X_Contrato lista = new TList_Fixacao_X_Contrato();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Fixacao_X_Contrato reg = new TRegistro_Fixacao_X_Contrato();

                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fixacao")))
                        reg.Id_fixacao = reader.GetDecimal(reader.GetOrdinal("ID_Fixacao"));

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

        public string Gravar(TRegistro_Fixacao_X_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);

            return this.executarProc("IA_GRO_FIXACAO_X_CONTRATO", hs);
        }

        public string Excluir(TRegistro_Fixacao_X_Contrato val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);

            return this.executarProc("EXCLUI_GRO_FIXACAO_X_CONTRATO", hs);
        }
    }
    #endregion

    #region Fixacao NF
    public class TList_Fixacao_NF : List<TRegistro_Fixacao_NF>
    { }
    
    public class TRegistro_Fixacao_NF
    {
        public decimal? Id_fixacaonf
        { get; set; }
        public decimal? Id_fixacao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public decimal Qtd_fixacao
        { get; set; }
        public decimal Vl_pauta
        { get; set; }
        public decimal Vl_fixacao
        { get; set; }
        public decimal Vl_complemento
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }
        public decimal Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        private decimal? id_variedade;
        public decimal? Id_variedade
        {
            get { return id_variedade; }
            set
            {
                id_variedade = value;
                id_variedadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_variedadestr;
        public string Id_variedadestr
        {
            get { return id_variedadestr; }
            set
            {
                id_variedadestr = value;
                try
                {
                    id_variedade = decimal.Parse(value);
                }
                catch { id_variedade = null; }
            }
        }
        public string Ds_variedade
        { get; set; }
        private string tp_nota;
        public string Tp_nota
        {
            get { return tp_nota; }
            set
            {
                tp_nota = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_nota = "PAUTA";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_nota = "COMPLEMENTO";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_nota = "DEVOLUÇÃO";
            }
        }
        private string tipo_nota;
        public string Tipo_nota
        {
            get { return tipo_nota; }
            set
            {
                tipo_nota = value;
                if (value.Trim().ToUpper().Equals("PAUTA"))
                    tp_nota = "P";
                else if (value.Trim().ToUpper().Equals("COMPLEMENTO"))
                    tp_nota = "C";
                else if (value.Trim().ToUpper().Equals("DEVOLUÇÃO"))
                    tp_nota = "D";
            }
        }
        public TRegistro_LanFaturamento rNfComplemento
        { get; set; }

        public TRegistro_Fixacao_NF()
        {
            Id_fixacaonf = null;
            Id_fixacao = null;
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Id_nfitem = null;
            Qtd_fixacao = decimal.Zero;
            Vl_pauta = decimal.Zero;
            Vl_fixacao = decimal.Zero;
            Vl_complemento = decimal.Zero;
            Vl_devolucao = decimal.Zero;
            Nr_notafiscal = decimal.Zero;
            Nr_serie = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_variedade = null;
            id_variedadestr = string.Empty;
            Ds_variedade = string.Empty;
            Sigla_unidade = string.Empty;
            tp_nota = string.Empty;
            tipo_nota = string.Empty;
        }
    }

    public class TCD_Fixacao_NF : TDataQuery
    {
        public TCD_Fixacao_NF()
        { }

        public TCD_Fixacao_NF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_fixacaonf, a.id_fixacao, a.cd_empresa, ");
                sql.AppendLine("a.nr_lanctofiscal, a.id_nfitem, a.qtd_fixacao, a.vl_fixacao, a.tp_nota, ");
                sql.AppendLine("b.cd_produto, c.ds_produto, d.sigla_unidade, nf.nr_notafiscal, nf.nr_serie ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_fixacao_nf a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and a.id_nfitem = b.id_nfitem ");
            sql.AppendLine("inner join tb_fat_notafiscal nf ");
            sql.AppendLine("on nf.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and nf.nr_lanctofiscal = a.nr_lanctofiscal ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join tb_gro_fixacao fx ");
            sql.AppendLine("on a.id_fixacao = fx.id_fixacao ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Fixacao_NF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Fixacao_NF lista = new TList_Fixacao_NF();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Fixacao_NF reg = new TRegistro_Fixacao_NF();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_FixacaoNF")))
                        reg.Id_fixacaonf = reader.GetDecimal(reader.GetOrdinal("ID_FixacaoNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fixacao")))
                        reg.Id_fixacao = reader.GetDecimal(reader.GetOrdinal("ID_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Fixacao")))
                        reg.Qtd_fixacao = reader.GetDecimal(reader.GetOrdinal("QTD_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Fixacao")))
                        reg.Vl_fixacao = reader.GetDecimal(reader.GetOrdinal("Vl_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("TP_Nota"));

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

        public string Gravar(TRegistro_Fixacao_NF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_FIXACAONF", val.Id_fixacaonf);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_QTD_FIXACAO", val.Qtd_fixacao);
            hs.Add("@P_VL_FIXACAO", val.Vl_fixacao);
            hs.Add("@P_TP_NOTA", val.Tp_nota);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("IA_GRO_FIXACAO_NF", hs);
        }

        public string Excluir(TRegistro_Fixacao_NF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_FIXACAONF", val.Id_fixacaonf);

            return this.executarProc("EXCLUI_GRO_FIXACAO_NF", hs);
        }
    }
    #endregion

    #region Fixacao X Duplicata
    public class TList_Fixacao_X_Duplicata : List<TRegistro_Fixacao_X_Duplicata>
    { }
    
    public class TRegistro_Fixacao_X_Duplicata
    {
        public decimal? Id_fixacao
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }

        public TRegistro_Fixacao_X_Duplicata()
        {
            this.Id_fixacao = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = null;
        }
    }

    public class TCD_Fixacao_X_Duplicata : TDataQuery
    {
        public TCD_Fixacao_X_Duplicata()
        { }

        public TCD_Fixacao_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_fixacao, a.cd_empresa, a.nr_lancto ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_gro_fixacao_x_duplicata a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Fixacao_X_Duplicata Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Fixacao_X_Duplicata lista = new TList_Fixacao_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Fixacao_X_Duplicata reg = new TRegistro_Fixacao_X_Duplicata();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fixacao")))
                        reg.Id_fixacao = reader.GetDecimal(reader.GetOrdinal("ID_Fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));

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

        public string Gravar(TRegistro_Fixacao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_GRO_FIXACAO_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Fixacao_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_FIXACAO", val.Id_fixacao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_GRO_FIXACAO_X_DUPLICATA", hs);
        }
    }
    #endregion
}
