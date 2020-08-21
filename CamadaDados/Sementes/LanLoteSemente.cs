using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Sementes
{
    #region "Classe Lote Semente"
    public class TList_LoteSemente : List<TRegistro_LoteSemente>, IComparer<TRegistro_LoteSemente>
    {
        #region IComparer<TRegistro_LoteSemente> Members
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

        public TList_LoteSemente()
        { }

        public TList_LoteSemente(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LoteSemente value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LoteSemente x, TRegistro_LoteSemente y)
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
    
    public class TRegistro_LoteSemente
    {
        public decimal Id_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Renasem_empresa
        { get; set; }
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
        public string Anosafra
        { get; set; }
        public string Ds_safra
        { get; set; }
        public string Nr_lote
        { get; set; }
        public string Cd_atestado
        { get; set; }
        public string Cd_certificado
        { get; set; }
        public decimal Pc_germinacao
        { get; set; }
        public decimal Pc_pureza
        { get; set; }
        private DateTime? dt_lote;
        public DateTime? DT_lote
        {
            get { return dt_lote; }
            set
            {
                dt_lote = value;
                dt_lotestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lotestr;
        public string Dt_lotestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lotestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lotestr = value;
                try
                {
                    dt_lote = Convert.ToDateTime(value);
                }
                catch
                { dt_lote = null; }
            }
        }
        private DateTime? dt_valgerminacao;
        public DateTime? Dt_valgerminacao
        {
            get { return dt_valgerminacao; }
            set
            {
                dt_valgerminacao = value;
                dt_valgerminacaostr = value.Value.ToString("dd/MM/yyyy");
            }
        }
        private string dt_valgerminacaostr;
        public string Dt_valgerminacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_valgerminacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_valgerminacaostr = value;
                try
                {
                    dt_valgerminacao = Convert.ToDateTime(value);
                }
                catch
                { dt_valgerminacao = null; }
            }
        }
        public decimal Qtd_amostra
        { get; set; }
        public decimal Qtd_lote
        {
            get
            {
                if ((!string.IsNullOrEmpty(this.Cd_unidamostra)) &&
                    (!string.IsNullOrEmpty(this.Cd_unidade)) &&
                    (this.Qtd_amostra > 0))
                    try
                    {
                        return new CamadaDados.Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(this.Cd_unidamostra, this.Cd_unidade, this.Qtd_amostra);
                    }
                    catch
                    { return decimal.Zero; }
                else
                    return Qtd_amostra;
            }
        }
        public decimal Qtd_vendida
        { get; set; }
        public decimal Qtd_DevVenda
        { get; set; }
        public decimal Qtd_DevCompra
        { get; set; }
        public decimal Qtd_saldo
        {
            get
            {
                if (this.Qtd_lote > 0)
                    return this.Qtd_lote - this.Qtd_vendida - this.Qtd_DevCompra + this.Qtd_DevVenda;
                else
                    return decimal.Zero;
            }
        }
        public decimal Qtd_produzida
        { get; set; }
        public decimal Qtd_produzir
        {
            get 
            {
                if (Qtd_lote > 0)
                    return Qtd_lote - Qtd_produzida;
                else
                    return decimal.Zero;
            }
        }
        public decimal Peneira
        { get; set; }
        private decimal? id_formulacao;
        public decimal? Id_formulacao
        {
            get { return id_formulacao; }
            set
            {
                id_formulacao = value;
                id_formulacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_formulacaostr;
        public string Id_formulacaostr
        {
            get { return id_formulacaostr; }
            set
            {
                id_formulacaostr = value;
                try
                {
                    id_formulacao = Convert.ToDecimal(value);
                }
                catch
                { id_formulacao = null; }
            }
        }
        public string Ds_formula
        { get; set; }
        private decimal? id_formestorno;
        public decimal? Id_formestorno
        {
            get { return id_formestorno; }
            set
            {
                id_formestorno = value;
                id_formestornostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_formestornostr;
        public string Id_formestornostr
        {
            get { return id_formestornostr; }
            set
            {
                id_formestornostr = value;
                try
                {
                    id_formestorno = Convert.ToDecimal(value);
                }
                catch
                { id_formestorno = null; }
            }
        }
        public string Ds_formulaestorno
        { get; set; }
        public string Cd_amostra
        { get; set; }
        public string Ds_amostra
        { get; set; }
        public string Cd_unidamostra
        { get; set; }
        public string Ds_unidamostra
        { get; set; }
        public string Sigla_unidamostra
        { get; set; }
        public string Cd_laboratorio
        { get; set; }
        public string Nm_laboratorio
        { get; set; }
        public string Cd_tecnico
        { get; set; }
        public string Nm_tecnico
        { get; set; }
        public string Renasem_tecnico
        { get; set; }
        public string Ds_motivorefugo
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("P") && (this.dt_valgerminacao == null ? false : this.dt_valgerminacao.Value.Date < DateTime.Now.Date))
                    status = "VENCIDO";
                else if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "APROVADO";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "REPROVADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("APROVADO"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("REPROVADO"))
                    st_registro = "R";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
            }
        }
        private string tp_lote;
        public string Tp_lote
        {
            get { return tp_lote; }
            set
            {
                tp_lote = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_lote = "PROPRIO";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_lote = "TERCEIRO";
            }
        }
        private string tipo_lote;
        public string Tipo_lote
        {
            get { return tipo_lote; }
            set
            {
                tipo_lote = value;
                if (value.Trim().ToUpper().Equals("PROPRIO"))
                    tp_lote = "P";
                else if(value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_lote = "T";
            }
        }
        public string Renasem
        { get; set; }
        public TList_LoteSemente_X_TipoAnalise lLoteXAnalise
        { get; set; }
        public TList_LoteSemente_X_TipoAnalise lLoteXAnaliseDel
        { get; set; }
        public CamadaDados.Sementes.Cadastros.TList_TipoAnalise lAnalise
        { get; set; }
        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lLoteNfItens
        { get; set; }
        public CamadaDados.Producao.Producao.TList_ApontamentoProducao lApontamento
        { get; set; }
        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lItensNfOrigem
        { get; set; }
        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lNfVenda
        { get; set; }
        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lNfDevolucao
        { get; set; }

        public string Conformidade { get; set; }
        public string Ds_formulacao { get; set; }

        public TRegistro_LoteSemente()
        {
            this.Id_lote = decimal.Zero;
            this.Conformidade = string.Empty;
            this.Ds_formulacao = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Renasem_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Anosafra = string.Empty;
            this.Ds_safra = string.Empty;
            this.Nr_lote = string.Empty;
            this.Cd_atestado = string.Empty;
            this.Cd_certificado = string.Empty;
            this.Pc_germinacao = decimal.Zero;
            this.Pc_pureza = decimal.Zero;
            this.dt_lote = DateTime.Now;
            this.dt_lotestr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_valgerminacao = null;
            this.dt_valgerminacaostr = string.Empty;
            this.Qtd_vendida = decimal.Zero;
            this.Qtd_DevVenda = decimal.Zero;
            this.Qtd_DevCompra = decimal.Zero;
            this.Qtd_produzida = decimal.Zero;
            this.Peneira = decimal.Zero;
            this.id_formulacao = null;
            this.id_formulacaostr = string.Empty;
            this.Ds_formula = string.Empty;
            this.id_formestorno = null;
            this.id_formestornostr = string.Empty;
            this.Ds_formulaestorno = string.Empty;
            this.Cd_amostra = string.Empty;
            this.Ds_amostra = string.Empty;
            this.Cd_unidamostra = string.Empty;
            this.Ds_unidamostra = string.Empty;
            this.Sigla_unidamostra = string.Empty;
            this.Cd_laboratorio = string.Empty;
            this.Nm_laboratorio = string.Empty;
            this.Cd_tecnico = string.Empty;
            this.Nm_tecnico = string.Empty;
            this.Renasem_tecnico = string.Empty;
            this.Ds_motivorefugo = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.tp_lote = string.Empty;
            this.tipo_lote = string.Empty;
            this.Renasem = string.Empty;

            this.lLoteXAnalise = new TList_LoteSemente_X_TipoAnalise();
            this.lLoteXAnaliseDel = new TList_LoteSemente_X_TipoAnalise();
            this.lAnalise = new CamadaDados.Sementes.Cadastros.TList_TipoAnalise();
            this.lLoteNfItens = new TList_LoteSemente_X_NFItem();
            this.lApontamento = new CamadaDados.Producao.Producao.TList_ApontamentoProducao();
            this.lItensNfOrigem = new TList_LoteSemente_X_NFItem();
            this.lNfDevolucao = new TList_LoteSemente_X_NFItem();
            this.lNfVenda = new TList_LoteSemente_X_NFItem();
        }
    }

    public class TCD_LoteSemente : TDataQuery
    {
        public TCD_LoteSemente()
        { }

        public TCD_LoteSemente(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.termoconformidade, a.ds_formulacao, a.id_lote, a.cd_empresa, b.nm_empresa, clifor_emp.renasem as renasem_empresa, ");
                sql.AppendLine("a.cd_produto, c.ds_produto, d.cd_unidade, d.ds_unidade, d.sigla_unidade, ");
                sql.AppendLine("a.anosafra, e.ds_safra, a.nr_lote, a.cd_atestado, a.cd_certificado, ");
                sql.AppendLine("a.pc_germinacao, a.pc_pureza, a.dt_lote, a.dt_valgerminacao, ");
                sql.AppendLine("a.qtd_lote, a.peneira, a.id_formulacao, h.ds_formula, ");
                sql.AppendLine("f.cd_unidade as cd_unidamostra, f.ds_unidade as ds_unidamostra, ");
                sql.AppendLine("f.sigla_unidade as sigla_unidamostra, a.tp_lote, a.renasem, ");
                sql.AppendLine("a.cd_amostra, g.ds_produto as ds_amostra, a.st_registro, ");
                sql.AppendLine("a.cd_laboratorio, j.nm_clifor as nm_laboratorio, a.ds_motivorefugo, ");
                sql.AppendLine("a.cd_tecnico, k.nm_clifor as nm_tecnico, k.renasem as renasem_tecnico, ");
                sql.AppendLine("a.qtd_vendida, a.qtd_devvenda, a.qtd_devcompra, a.qtd_produzida ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from vtb_sem_lotesemente a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("inner join vtb_fin_clifor clifor_emp ");
            sql.AppendLine("on b.cd_clifor = clifor_emp.cd_clifor ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("left outer join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            sql.AppendLine("left outer join tb_gro_safra e ");
            sql.AppendLine("on a.anosafra = e.anosafra ");
            sql.AppendLine("left outer join tb_est_produto g ");
            sql.AppendLine("on a.cd_amostra = g.cd_produto ");
            sql.AppendLine("left outer join tb_est_unidade f ");
            sql.AppendLine("on g.cd_unidade = f.cd_unidade ");
            sql.AppendLine("left outer join tb_prd_formula_apontamento h ");
            sql.AppendLine("on a.cd_empresa = h.cd_empresa ");
            sql.AppendLine("and a.id_formulacao = h.id_formulacao ");
            sql.AppendLine("left outer join vtb_fin_clifor j ");
            sql.AppendLine("on a.cd_laboratorio = j.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_clifor k ");
            sql.AppendLine("on a.cd_tecnico = k.cd_clifor ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");//Lote Cancelado
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LoteSemente Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LoteSemente lista = new TList_LoteSemente();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteSemente reg = new TRegistro_LoteSemente();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Renasem_empresa")))
                        reg.Renasem_empresa = reader.GetString(reader.GetOrdinal("Renasem_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                        reg.Ds_safra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lote")))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("NR_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Atestado")))
                        reg.Cd_atestado = reader.GetString(reader.GetOrdinal("CD_Atestado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Certificado")))
                        reg.Cd_certificado = reader.GetString(reader.GetOrdinal("CD_Certificado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Germinacao")))
                        reg.Pc_germinacao = reader.GetDecimal(reader.GetOrdinal("PC_Germinacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Pureza")))
                        reg.Pc_pureza = reader.GetDecimal(reader.GetOrdinal("PC_Pureza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lote")))
                        reg.DT_lote = reader.GetDateTime(reader.GetOrdinal("DT_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_ValGerminacao")))
                        reg.Dt_valgerminacao = reader.GetDateTime(reader.GetOrdinal("DT_ValGerminacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Lote")))
                        reg.Qtd_amostra = reader.GetDecimal(reader.GetOrdinal("QTD_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Vendida")))
                        reg.Qtd_vendida = reader.GetDecimal(reader.GetOrdinal("QTD_Vendida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_DevVenda")))
                        reg.Qtd_DevVenda = reader.GetDecimal(reader.GetOrdinal("Qtd_DevVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_DevCompra")))
                        reg.Qtd_DevCompra = reader.GetDecimal(reader.GetOrdinal("Qtd_DevCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_produzida")))
                        reg.Qtd_produzida = reader.GetDecimal(reader.GetOrdinal("qtd_produzida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Peneira")))
                        reg.Peneira = reader.GetDecimal(reader.GetOrdinal("Peneira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("id_formulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Formula")))
                        reg.Ds_formula = reader.GetString(reader.GetOrdinal("DS_Formula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Amostra")))
                        reg.Cd_amostra = reader.GetString(reader.GetOrdinal("CD_Amostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Amostra")))
                        reg.Ds_amostra = reader.GetString(reader.GetOrdinal("DS_Amostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidAmostra")))
                        reg.Cd_unidamostra = reader.GetString(reader.GetOrdinal("CD_UnidAmostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UnidAmostra")))
                        reg.Ds_unidamostra = reader.GetString(reader.GetOrdinal("DS_UnidAmostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidamostra")))
                        reg.Sigla_unidamostra = reader.GetString(reader.GetOrdinal("sigla_unidamostra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Laboratorio")))
                        reg.Cd_laboratorio = reader.GetString(reader.GetOrdinal("CD_Laboratorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Laboratorio")))
                        reg.Nm_laboratorio = reader.GetString(reader.GetOrdinal("NM_Laboratorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Tecnico")))
                        reg.Cd_tecnico = reader.GetString(reader.GetOrdinal("CD_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Tecnico")))
                        reg.Nm_tecnico = reader.GetString(reader.GetOrdinal("NM_Tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Renasem_tecnico")))
                        reg.Renasem_tecnico = reader.GetString(reader.GetOrdinal("Renasem_tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoRefugo")))
                        reg.Ds_motivorefugo = reader.GetString(reader.GetOrdinal("DS_MotivoRefugo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_lote")))
                        reg.Tp_lote = reader.GetString(reader.GetOrdinal("tp_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("renasem")))
                        reg.Renasem = reader.GetString(reader.GetOrdinal("renasem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("termoconformidade")))
                        reg.Conformidade = reader.GetString(reader.GetOrdinal("termoconformidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_formulacao")))
                        reg.Ds_formulacao = reader.GetString(reader.GetOrdinal("Ds_formulacao"));

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

        public string Gravar(TRegistro_LoteSemente val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(23);
            
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ANOSAFRA", val.Anosafra);
            hs.Add("@P_NR_LOTE", val.Nr_lote);
            hs.Add("@P_CD_ATESTADO", val.Cd_atestado);
            hs.Add("@P_CD_CERTIFICADO", val.Cd_certificado);
            hs.Add("@P_PC_GERMINACAO", val.Pc_germinacao);
            hs.Add("@P_PC_PUREZA", val.Pc_pureza);
            hs.Add("@P_DT_LOTE", val.DT_lote);
            hs.Add("@P_DT_VALGERMINACAO", val.Dt_valgerminacao);
            hs.Add("@P_QTD_LOTE", val.Qtd_amostra);
            hs.Add("@P_PENEIRA", val.Peneira);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_CD_AMOSTRA", val.Cd_amostra);
            hs.Add("@P_CD_LABORATORIO", val.Cd_laboratorio);
            hs.Add("@P_CD_TECNICO", val.Cd_tecnico);
            hs.Add("@P_DS_MOTIVOREFUGO", val.Ds_motivorefugo);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_LOTE", val.Tp_lote);
            hs.Add("@P_RENASEM", val.Renasem);
            hs.Add("@P_TERMOCONFORMIDADE", val.Conformidade);
            hs.Add("@P_DS_FORMULACAO", val.Ds_formulacao);

            return this.executarProc("IA_SEM_LOTESEMENTE", hs);
        }

        public string Excluir(TRegistro_LoteSemente val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOTE", val.Id_lote);

            return this.executarProc("EXCLUI_SEM_LOTESEMENTE", hs);
        }
    }
    #endregion

    #region "Classe Lote Semente X NF Item"
    public class TList_LoteSemente_X_NFItem : List<TRegistro_LoteSemente_X_NFItem>
    { }

    public class TRegistro_LoteSemente_X_NFItem
    {
        public decimal Id_item
        { get; set; }
        public decimal Id_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lanctofiscal
        { get; set; }
        public decimal Id_nfitem
        { get; set; }
        public decimal Quantidade
        { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("O"))
                    tipo_movimento = "ORIGEM";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_movimento = "DEVOLUCAO";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ORIGEM"))
                    tp_movimento = "O";
                else if (value.Trim().ToUpper().Equals("DEVOLUCAO"))
                    tp_movimento = "D";
            }
        }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Ds_obsNfItem
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public decimal? Id_formestorno
        { get; set; }

        public TRegistro_LoteSemente_X_NFItem()
        {
            this.Id_item = decimal.Zero;
            this.Id_lote = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctofiscal = decimal.Zero;
            this.Id_nfitem = decimal.Zero;
            this.Quantidade = decimal.Zero;
            this.tp_movimento = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Nr_notafiscal = null;
            this.Nr_serie = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Ds_obsNfItem = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Id_formestorno = null;
        }
    }

    public class TCD_LoteSemente_X_NFItem : TDataQuery
    {
        public TCD_LoteSemente_X_NFItem()
        { }

        public TCD_LoteSemente_X_NFItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_item, a.id_lote, a.cd_empresa, ");
                sql.AppendLine("a.nr_lanctofiscal, a.id_nfitem, a.quantidade, ");
                sql.AppendLine("a.tp_movimento, b.cd_produto, d.ds_produto, ");
                sql.AppendLine("e.sigla_unidade, b.observacao_item, ");
                sql.AppendLine("c.nr_notafiscal, c.nr_serie, c.cd_clifor, f.nm_clifor ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_sem_lotesemente_x_nfitem a ");
            sql.AppendLine("inner join tb_fat_notafiscal_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("and a.id_nfitem = b.id_nfitem ");
            sql.AppendLine("inner join tb_fat_notafiscal c ");
            sql.AppendLine("on b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and b.nr_lanctofiscal = c.nr_lanctofiscal ");
            sql.AppendLine("inner join tb_est_produto d ");
            sql.AppendLine("on b.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade e ");
            sql.AppendLine("on d.cd_unidade = e.cd_unidade ");
            sql.AppendLine("inner join vtb_fin_clifor f ");
            sql.AppendLine("on c.cd_clifor = f.cd_clifor ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LoteSemente_X_NFItem Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LoteSemente_X_NFItem lista = new TList_LoteSemente_X_NFItem();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteSemente_X_NFItem reg = new TRegistro_LoteSemente_X_NFItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Observacao_item")))
                        reg.Ds_obsNfItem = reader.GetString(reader.GetOrdinal("Observacao_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));

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

        public string Gravar(TRegistro_LoteSemente_X_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);

            return this.executarProc("IA_SEM_LOTESEMENTE_X_NFITEM", hs);
        }

        public string Excluir(TRegistro_LoteSemente_X_NFItem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ITEM", val.Id_item);
            
            return this.executarProc("EXCLUI_SEM_LOTESEMENTE_X_NFITEM", hs);
        }
    }
    #endregion

    #region "Classe Lote Semente X Apontamento"
    public class TList_LoteSemente_X_Apontamento : List<TRegistro_LoteSemente_X_Apontamento>
    { }

    public class TRegistro_LoteSemente_X_Apontamento
    {
        public decimal Id_lote
        { get; set; }
        public decimal Id_apontamento
        { get; set; }

        public TRegistro_LoteSemente_X_Apontamento()
        {
            this.Id_apontamento = decimal.Zero;
            this.Id_lote = decimal.Zero;
        }
    }

    public class TCD_LoteSemente_X_Apontamento : TDataQuery
    {
        public TCD_LoteSemente_X_Apontamento()
        { }

        public TCD_LoteSemente_X_Apontamento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_lote, a.id_apontamento ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_sem_lotesemente_x_apontamento a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LoteSemente_X_Apontamento Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LoteSemente_X_Apontamento lista = new TList_LoteSemente_X_Apontamento();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteSemente_X_Apontamento reg = new TRegistro_LoteSemente_X_Apontamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));

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

        public string Gravar(TRegistro_LoteSemente_X_Apontamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);

            return this.executarProc("IA_SEM_LOTESEMENTE_X_APONTAMENTO", hs);
        }

        public string Excluir(TRegistro_LoteSemente_X_Apontamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);

            return this.executarProc("EXCLUI_SEM_LOTESEMENTE_X_APONTAMENTO", hs);
        }
    }
    #endregion   

    #region "Classe Lote Semente X Tipo Analise"
    public class TList_LoteSemente_X_TipoAnalise : List<TRegistro_LoteSemente_X_TipoAnalise>
    { }

    public class TRegistro_LoteSemente_X_TipoAnalise
    {
        public decimal? Id_analise
        { get; set; }
        public decimal? Id_lote
        { get; set; }

        public TRegistro_LoteSemente_X_TipoAnalise()
        {
            this.Id_analise = null;
            this.Id_lote = null;
        }
    }

    public class TCD_LoteSemente_X_TipoAnalise : TDataQuery
    {
        public TCD_LoteSemente_X_TipoAnalise()
        { }

        public TCD_LoteSemente_X_TipoAnalise(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_lote, a.id_analise ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_sem_lotesemente_x_tipoanalise a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LoteSemente_X_TipoAnalise Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LoteSemente_X_TipoAnalise lista = new TList_LoteSemente_X_TipoAnalise();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LoteSemente_X_TipoAnalise reg = new TRegistro_LoteSemente_X_TipoAnalise();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Analise")))
                        reg.Id_analise = reader.GetDecimal(reader.GetOrdinal("ID_Analise"));

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

        public string Gravar(TRegistro_LoteSemente_X_TipoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_ANALISE", val.Id_analise);

            return this.executarProc("IA_SEM_LOTESEMENTE_X_TIPOANALISE", hs);
        }

        public string Excluir(TRegistro_LoteSemente_X_TipoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_ANALISE", val.Id_analise);

            return this.executarProc("EXCLUI_SEM_LOTESEMENTE_X_TIPOANALISE", hs);
        }
    }
    #endregion
}
