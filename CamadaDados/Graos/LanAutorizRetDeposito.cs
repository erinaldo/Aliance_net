using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Graos
{
    public class TList_AutorizRetDeposito : List<TRegistro_AutorizRetDeposito>, IComparer<TRegistro_AutorizRetDeposito>
    {
        #region IComparer<TRegistro_AutorizRetDeposito> Members
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

        public TList_AutorizRetDeposito()
        { }

        public TList_AutorizRetDeposito(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AutorizRetDeposito value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AutorizRetDeposito x, TRegistro_AutorizRetDeposito y)
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

    
    public class TRegistro_AutorizRetDeposito
    {
        private decimal? id_autoriz;
        
        public decimal? Id_autoriz
        {
            get { return id_autoriz; }
            set
            {
                id_autoriz = value;
                id_autorizstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_autorizstr;
        
        public string Id_autorizstr
        {
            get { return id_autorizstr; }
            set
            {
                id_autorizstr = value;
                try
                {
                    id_autoriz = Convert.ToDecimal(value);
                }
                catch
                { id_autoriz = null; }
            }
        }
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = (value.HasValue ? value.Value.ToString() : string.Empty);
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
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidproduto
        { get; set; }
        
        public string Sg_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }
        
        public string Sg_unidade
        { get; set; }
        private DateTime? dt_lancto;
        
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        
        public decimal Qtd_retirar
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public decimal Qtd_retirada
        { get; set; }
        
        public string St_registro
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Ds_endempresa
        { get; set; }
        
        public string Numeroempresa
        { get; set; }
        
        public string Ds_cidadeemp
        { get; set; }
        
        public string Uf_emp
        { get; set; }
        
        public string Cnpj_emp
        { get; set; }
        
        public string Insc_emp
        { get; set; }
        
        public string Fone_emp
        { get; set; }
        
        public string Cd_cliforcontrato
        { get; set; }
        
        public string Nm_cliforcontrato
        { get; set; }
        
        public decimal Qtd_saldocontrato
        { get; set; }
        
        public CamadaDados.Balanca.TList_RegLanPesagemGraos lPesagem
        { get; set; }

        public decimal Qtd_saldoretirar
        {
            get
            {
                return this.Qtd_retirar - this.Qtd_retirada;
            }
        }

        public TRegistro_AutorizRetDeposito()
        {
            this.id_autoriz = null;
            this.id_autorizstr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidproduto = string.Empty;
            this.Sg_produto = string.Empty;
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sg_unidade = string.Empty;
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Qtd_retirar = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.Qtd_retirada = decimal.Zero;
            this.St_registro = "A";
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Ds_endempresa = string.Empty;
            this.Numeroempresa = string.Empty;
            this.Ds_cidadeemp = string.Empty;
            this.Uf_emp = string.Empty;
            this.Cnpj_emp = string.Empty;
            this.Insc_emp = string.Empty;
            this.Fone_emp = string.Empty;
            this.Cd_cliforcontrato = string.Empty;
            this.Nm_cliforcontrato = string.Empty;
            this.Qtd_saldocontrato = decimal.Zero;
            this.lPesagem = new CamadaDados.Balanca.TList_RegLanPesagemGraos();
        }
    }

    public class TCD_Autoriz_RetDeposito : TDataQuery
    {
        public TCD_Autoriz_RetDeposito()
        { }

        public TCD_Autoriz_RetDeposito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.id_autoriz, e.cd_produto, b.ds_produto, c.sigla_unidade as sg_produto, ");
                sql.AppendLine("a.nr_contrato, a.cd_unidade, d.ds_unidade, d.sigla_unidade as sg_unidade, ");
                sql.AppendLine("a.dt_lancto, a.qtd_retirar, a.ds_observacao, a.st_registro, c.cd_unidade as cd_unidproduto, ");
                sql.AppendLine("f.cd_empresa, f.nm_empresa, g.nr_cgc, h.ds_endereco, h.numero, ");
                sql.AppendLine("h.ds_cidade, h.uf, h.insc_estadual, h.fone, e.cd_clifor, i.nm_clifor, ");
                sql.AppendLine("a.qtd_retirada, (a.qtd_retirar - a.qtd_retirada) as saldo_retirar ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM VTB_GRO_AUTORIZ_RETDEPOSITO a ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on a.cd_unidade = d.cd_unidade ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO e ");
            sql.AppendLine("on a.nr_contrato = e.nr_contrato ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on e.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join tb_div_empresa f ");
            sql.AppendLine("on e.cd_empresa = f.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor g ");
            sql.AppendLine("on f.cd_clifor = g.cd_clifor ");
            sql.AppendLine("inner join vtb_fin_endereco h ");
            sql.AppendLine("on f.cd_clifor = h.cd_clifor ");
            sql.AppendLine("and f.cd_endereco = h.cd_endereco ");
            sql.AppendLine("inner join vtb_fin_clifor i ");
            sql.AppendLine("on e.cd_clifor = i.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
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

        public TList_AutorizRetDeposito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AutorizRetDeposito lista = new TList_AutorizRetDeposito();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AutorizRetDeposito reg = new TRegistro_AutorizRetDeposito();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_autoriz")))
                        reg.Id_autoriz = reader.GetDecimal(reader.GetOrdinal("id_autoriz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidproduto")))
                        reg.Cd_unidproduto = reader.GetString(reader.GetOrdinal("cd_unidproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Produto")))
                        reg.Sg_produto = reader.GetString(reader.GetOrdinal("SG_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_Unidade")))
                        reg.Sg_unidade = reader.GetString(reader.GetOrdinal("SG_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Retirar")))
                        reg.Qtd_retirar = reader.GetDecimal(reader.GetOrdinal("QTD_Retirar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_retirada")))
                        reg.Qtd_retirada = reader.GetDecimal(reader.GetOrdinal("qtd_retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endempresa = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
                        reg.Numeroempresa = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.Ds_cidadeemp = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Uf_emp = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj_emp = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual")))
                        reg.Insc_emp = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.Fone_emp = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_cliforcontrato = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_cliforcontrato = reader.GetString(reader.GetOrdinal("NM_Clifor"));

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

        public string Gravar(TRegistro_AutorizRetDeposito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_AUTORIZ", val.Id_autoriz);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_QTD_RETIRAR", val.Qtd_retirar);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_GRO_AUTORIZ_RETDEPOSITO", hs);
        }

        public string Excluir(TRegistro_AutorizRetDeposito val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_AUTORIZ", val.Id_autoriz);

            return this.executarProc("EXCLUI_GRO_AUTORIZ_RETDEPOSITO", hs);
        }
    }
}
