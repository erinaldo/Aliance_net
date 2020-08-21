using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Cartao
{
    public class TRegistro_LanLoteCartao
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal Id_Lote { get; set; } = decimal.Zero;
        public string Cd_ContaGer { get; set; } = string.Empty;
        public decimal? Cd_LanctoCaixa { get; set; } = null;
        public string Ds_Lote { get; set; } = string.Empty;
        public string Ds_Bandeira { get; set; } = string.Empty;
        public string Ds_Contager { get; set; } = string.Empty;

        private string st_registro = "A";
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
            }
        }
        private string status = "ABERTO";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }

        private DateTime? dt_Processamento ;
        public DateTime? Dt_Processamento
        {
            get { return dt_Processamento; }
            set
            {
                dt_Processamento = value;
                dt_Processamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_Processamentostr { get; set; } = string.Empty;
        public string Dt_Processamentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_Processamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_Processamentostr = value;
                try
                {
                    dt_Processamento = Convert.ToDateTime(value);
                }
                catch
                { dt_Processamento = null; }
            }
        }


        private DateTime? dt_Lote { get; set; } = new DateTime();
        public DateTime? Dt_Lote
        {
            get { return dt_Lote; }
            set
            {
                dt_Lote = value;
                dt_Lotestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_Lotestr { get; set; } = string.Empty;
        public string Dt_Lotestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_Lotestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_Lotestr = value;
                try
                {
                    dt_Lote = Convert.ToDateTime(value);
                }
                catch
                { dt_Lote = null; }
            }
        }
        public TList_FaturaDescontar lCartao { get; set; } = new TList_FaturaDescontar();
        public TList_FaturaCartao lFatCartao { get; set; } = new TList_FaturaCartao();
        public CamadaDados.Financeiro.Caixa.TList_LanCaixa lLanCaixa { get; set; } = new CamadaDados.Financeiro.Caixa.TList_LanCaixa();
        public TList_FaturaCartao_X_Caixa lFatCartao_Caixa { get; set; } = new TList_FaturaCartao_X_Caixa();
        


    }

    public class TList_LanLoteCartao : List<TRegistro_LanLoteCartao> { }

    public class TCD_LanLoteCartao : TDataQuery
    {

        public TCD_LanLoteCartao() { }

        public TCD_LanLoteCartao(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_lote, a.cd_contager, a.cd_lanctocaixa, a.dt_lote, a.ds_lote, a.dt_processamento,a.st_registro ");
                sql.AppendLine(", b.ds_contager  ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_DescontarFat a ");
            sql.AppendLine(" left join tb_fin_contager b on a.cd_contager = b.cd_contager ");



            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            //sql.AppendLine("order by a.dt_lote asc");
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

        public TList_LanLoteCartao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanLoteCartao lista = new TList_LanLoteCartao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanLoteCartao reg = new TRegistro_LanLoteCartao();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Lote")))
                        reg.Id_Lote = reader.GetDecimal(reader.GetOrdinal("Id_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_ContaGer = reader.GetString(reader.GetOrdinal("cd_contager")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_LanctoCaixa")))
                        reg.Cd_LanctoCaixa = reader.GetDecimal(reader.GetOrdinal("Cd_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lote")))
                        reg.Dt_Lote = reader.GetDateTime(reader.GetOrdinal("dt_lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_Processamento")))
                        reg.Dt_Processamento = reader.GetDateTime(reader.GetOrdinal("Dt_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Lote")))
                        reg.Ds_Lote = reader.GetString(reader.GetOrdinal("Ds_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Contager")))
                        reg.Ds_Contager = reader.GetString(reader.GetOrdinal("Ds_Contager"));

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

        public string Gravar(TRegistro_LanLoteCartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(28);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_CD_CONTAGER", val.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_LanctoCaixa);
            hs.Add("@P_ID_LOTE", val.Id_Lote);
            hs.Add("@P_DT_LOTE", val.Dt_Lote);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_Processamento);
            hs.Add("@P_DS_LOTE", val.Ds_Lote);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_DESCONTARFAT", hs);
        }

        public string Excluir(TRegistro_LanLoteCartao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_LOTE", val.Id_Lote);

            return this.executarProc("EXCLUI_FIN_DESCONTARFAT", hs);
        }
    }


    public class TRegistro_FaturaDescontar
    {
        public string Cd_Empresa { get; set; } = string.Empty;
        public decimal Id_Lote { get; set; } = decimal.Zero;
        public decimal Id_Fatura { get; set; } = decimal.Zero;
        public decimal vl_nominal { get; set; } = decimal.Zero;
        public decimal vl_liquido { get { return vl_nominal - vl_taxa; } set { } }
        public decimal vl_fatura { get; set; } = decimal.Zero;
        public decimal vl_quitado { get; set; } = decimal.Zero;
        public decimal vl_quitar { get; set; } = decimal.Zero;
        public decimal vl_taxa { get; set; } = decimal.Zero;
        public decimal pc_taxa { get; set; } = decimal.Zero;


        public string tp_movimento { get; set; } = string.Empty;

        private DateTime? dt_Fatura { get; set; } = new DateTime();
        public DateTime? Dt_Fatura
        {
            get { return dt_Fatura; }
            set
            {
                dt_Fatura = value;
                dt_Faturastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_Faturastr { get; set; } = string.Empty;
        public string Dt_Faturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_Faturastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_Faturastr = value;
                try
                {
                    dt_Fatura = Convert.ToDateTime(value);
                }
                catch
                { dt_Fatura = null; }
            }
        }


    }

    public class TList_FaturaDescontar : List<TRegistro_FaturaDescontar> { }

    public class TCD_FaturaDescontar : TDataQuery
    {

        public TCD_FaturaDescontar() { }

        public TCD_FaturaDescontar(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_lote, a.id_fatura ");
                sql.AppendLine(" , b.tp_movimento, b.vl_nominal, b.dt_fatura,vl_taxa = round((b.vl_nominal + b.vl_juro - b.vl_quitado) * (c.pc_taxa / 100), 2) ,");
                sql.AppendLine("c.pc_taxa      ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_FaturaDescontar a ");
            sql.AppendLine(" left join vTB_FIN_FaturaCartao b on a.id_fatura = b.id_fatura ");
            sql.AppendLine("left join TB_FIN_DescontarFat d  on d.cd_empresa = a.cd_empresa and a.id_lote = d.id_lote");
            sql.AppendLine("left outer join TB_FIN_TaxaBandeira c");
            sql.AppendLine("on a.CD_Empresa = c.cd_empresa");
            sql.AppendLine("and b.ID_Bandeira = c.id_bandeira");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            //sql.AppendLine("order by a.dt_lote asc");
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

        public TList_FaturaDescontar Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FaturaDescontar lista = new TList_FaturaDescontar();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FaturaDescontar reg = new TRegistro_FaturaDescontar();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Lote")))
                        reg.Id_Lote = reader.GetDecimal(reader.GetOrdinal("Id_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Fatura")))
                        reg.Id_Fatura = reader.GetDecimal(reader.GetOrdinal("Id_Fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_Fatura")))
                        reg.Dt_Fatura = reader.GetDateTime(reader.GetOrdinal("Dt_Fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_nominal")))
                        reg.vl_nominal = reader.GetDecimal(reader.GetOrdinal("vl_nominal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_taxa")))
                        reg.vl_taxa = reader.GetDecimal(reader.GetOrdinal("vl_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_taxa")))
                        reg.pc_taxa = reader.GetDecimal(reader.GetOrdinal("pc_taxa"));

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

        public string Gravar(TRegistro_FaturaDescontar val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_FATURA", val.Id_Fatura);
            hs.Add("@P_ID_LOTE", val.Id_Lote);

            return this.executarProc("IA_FIN_FATURADESCONTAR", hs);
        }

        public string Excluir(TRegistro_FaturaDescontar val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_ID_LOTE", val.Id_Lote);
            hs.Add("@P_ID_FATURA", val.Id_Fatura);

            return this.executarProc("EXCLUI_FIN_FATURADESCONTAR", hs);
        }
    }

}

