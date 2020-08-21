using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Contabil.SPED_CONTABIL
{
    #region Sped Contabil
    public class TList_SpedContabil : List<TRegistro_SpedContabil> { }

    public class TRegistro_SpedContabil
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_sped;
        public decimal? Id_sped
        {
            get { return id_sped; }
            set
            {
                id_sped = value;
                id_spedstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_spedstr;
        public string Id_spedstr
        {
            get { return id_spedstr; }
            set
            {
                id_spedstr = value;
                try
                {
                    id_sped = decimal.Parse(value);
                }
                catch { id_sped = null; }
            }
        }
        private decimal? nr_sped;
        public decimal? Nr_sped
        {
            get { return nr_sped; }
            set
            {
                nr_sped = value;
                nr_spedstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_spedstr;
        public string Nr_spedstr
        {
            get { return nr_spedstr; }
            set
            {
                nr_spedstr = value;
                try
                {
                    nr_sped = decimal.Parse(value);
                }
                catch { nr_sped = null; }
            }
        }
        private DateTime? dt_ini;
        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = DateTime.Parse(value);
                }
                catch { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;
        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = DateTime.Parse(value);
                }
                catch { dt_fin = null; }
            }
        }

        public TRegistro_SpedContabil()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_sped = null;
            this.id_spedstr = string.Empty;
            this.nr_sped = null;
            this.nr_spedstr = string.Empty;
            this.dt_ini = null;
            this.dt_inistr = string.Empty;
            this.dt_fin = null;
            this.dt_finstr = string.Empty;
        }
    }

    public class TCD_SpedContabil : TDataQuery
    {
        public TCD_SpedContabil() { }

        public TCD_SpedContabil(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empres, b.nm_empresa, ");
                sql.AppendLine("a.id_sped, a.nr_sped, a.dt_ini, a.dt_fin ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_SpedContabil a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

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

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_SpedContabil Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_SpedContabil lista = new TList_SpedContabil();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_SpedContabil reg = new TRegistro_SpedContabil();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_sped")))
                        reg.Id_sped = reader.GetDecimal(reader.GetOrdinal("id_sped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_sped")))
                        reg.Nr_sped = reader.GetDecimal(reader.GetOrdinal("nr_sped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("dt_fin"));
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

        public string Gravar(TRegistro_SpedContabil val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_SPED", val.Id_sped);
            hs.Add("@P_NR_SPED", val.Nr_sped);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);

            return this.executarProc("IA_CTB_SPEDCONTABIL", hs);
        }

        public string Excluir(TRegistro_SpedContabil val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_SPED", val.Id_sped);
            
            return this.executarProc("EXCLUI_CTB_SPEDCONTABIL", hs);
        }
    }
    #endregion

    #region Registro Arquivo
    public class TList_RegArquivo : List<TRegistro_RegArquivo>
    {
        public void Adiciona(TRegistro_RegArquivo reg)
        {
            if (this.Exists(p => p.Registro.Trim().ToUpper().Equals(reg.Registro.Trim().ToUpper())))
                this.Find(p => p.Registro.Trim().ToUpper().Equals(reg.Registro.Trim().ToUpper())).Qtd_linha += reg.Qtd_linha;
            else
                this.Add(reg);
        }
    }

    public class TRegistro_RegArquivo
    {
        public string Registro
        { get; set; }
        public decimal Qtd_linha
        { get; set; }
    }
    #endregion

    #region Empresa
    public class TRegistro_Empresa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cnpj
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Uf
        { get; set; }
        public string Insc_municipal
        { get; set; }
        public string Cd_registrojunta
        { get; set; }
        public DateTime? Dt_abertura
        { get; set; }
        public string Tp_InstPlanoRef
        { get; set; }
        public string Tp_spedcontabil
        { get; set; }
        public string Layoutspedcontabil
        { get; set; }
        public string Cpf_contador
        { get; set; }
        public string NM_contador
        { get; set; }
        public string Email_contador
        { get; set; }
        public string Fone_contador
        { get; set; }
        public string Nr_CRC
        { get; set; }
        public string UF_CRC
        { get; set; }
        public string SequencialCRC
        { get; set; }
        public DateTime? Dt_validadeCRC
        { get; set; }

        public TRegistro_Empresa()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cnpj = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Cd_cidade = string.Empty;
            this.Ds_cidade = string.Empty;
            this.Uf = string.Empty;
            this.Insc_municipal = string.Empty;
            this.Cd_registrojunta = string.Empty;
            this.Dt_abertura = null;
            this.Tp_InstPlanoRef = string.Empty;
            this.Tp_spedcontabil = string.Empty;
            this.Layoutspedcontabil = string.Empty;
            this.Cpf_contador = string.Empty;
            this.NM_contador = string.Empty;
            this.Email_contador = string.Empty;
            this.Fone_contador = string.Empty;
            this.Nr_CRC = string.Empty;
            this.UF_CRC = string.Empty;
            this.SequencialCRC = string.Empty;
            this.Dt_validadeCRC = null;
        }
    }

    public class TCD_Empresa : TDataQuery
    {
        public TCD_Empresa() { }

        public TCD_Empresa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, a.NM_Empresa, b.NR_CGC, c.UF, ");
            sql.AppendLine("c.Insc_Estadual, c.CD_Cidade, c.DS_Cidade, a.tp_instplanoref, ");
            sql.AppendLine("a.Insc_Municipal, a.Cd_registrojunta, a.dt_abertura, ");
            sql.AppendLine("a.TP_SpedContabil, a.LayoutSpedContabil, d.nr_cpf as cpf_contador, ");
            sql.AppendLine("d.nm_clifor as nm_contador, a.crc_contador, e.uf, ");
            sql.AppendLine("d.email as email_contador, a.SequencialCRC, a.DT_ValidadeCRC, ");
            sql.AppendLine("Fone_Contador = isnull((select top 1 x.fone ");
            sql.AppendLine("                        from tb_fin_endereco x ");
            sql.AppendLine("                        where x.cd_clifor = a.cd_clifor_contador), '')");

            sql.AppendLine("from TB_DIV_Empresa a ");
            sql.AppendLine("inner join TB_FIN_Clifor_PJ b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = c.CD_Endereco ");
            sql.AppendLine("inner join VTB_FIN_Clifor d ");
            sql.AppendLine("on a.cd_clifor_contador = d.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_UF e ");
            sql.AppendLine("on a.cd_ufexpCRC = e.cd_uf ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_Empresa> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_Empresa> lista = new List<TRegistro_Empresa>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Empresa reg = new TRegistro_Empresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_municipal")))
                        reg.Insc_municipal = reader.GetString(reader.GetOrdinal("insc_municipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_registrojunta")))
                        reg.Cd_registrojunta = reader.GetString(reader.GetOrdinal("cd_registrojunta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_instplanoref")))
                        reg.Tp_InstPlanoRef = reader.GetString(reader.GetOrdinal("tp_instplanoref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_SpedContabil")))
                        reg.Tp_spedcontabil = reader.GetString(reader.GetOrdinal("TP_SpedContabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LayoutSpedContabil")))
                        reg.Layoutspedcontabil = reader.GetString(reader.GetOrdinal("LayoutSpedContabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_contador")))
                        reg.NM_contador = reader.GetString(reader.GetOrdinal("nm_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_contador")))
                        reg.Cpf_contador = reader.GetString(reader.GetOrdinal("cpf_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email_contador")))
                        reg.Email_contador = reader.GetString(reader.GetOrdinal("email_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_contador")))
                        reg.Fone_contador = reader.GetString(reader.GetOrdinal("Fone_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("crc_contador")))
                        reg.Nr_CRC = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.UF_CRC = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SequencialCRC")))
                        reg.SequencialCRC = reader.GetString(reader.GetOrdinal("SequencialCRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_ValidadeCRC")))
                        reg.Dt_validadeCRC = reader.GetDateTime(reader.GetOrdinal("DT_ValidadeCRC"));
                    

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }

    #endregion

    #region Registro I355
    public class TRegistro_I355
    {
        public decimal? Cd_contaCTB
        { get; set; }
        public string Natureza
        { get; set; }
        public decimal Vl_saldo
        { get; set; }

        public TRegistro_I355()
        {
            this.Cd_contaCTB = null;
            this.Natureza = string.Empty;
            this.Vl_saldo = decimal.Zero;
        }
    }

    public class TCD_I355 : TDataQuery
    {
        public TCD_I355() { }

        public TCD_I355(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, DateTime Dt_ini, DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_conta_ctb, a.natureza, ");
            sql.AppendLine("sd_atual = isnull((select sum(case when x.d_c <> y.natureza then - 1 else 1 end * isnull(x.valor, 0)) ");
            sql.AppendLine("			from tb_ctb_lanctosCTB x ");
            sql.AppendLine("			inner join tb_ctb_planocontas y ");
            sql.AppendLine("			on x.cd_conta_ctb = y.cd_conta_ctb ");
            sql.AppendLine("			where x.cd_conta_ctb = a.cd_conta_ctb ");
            sql.AppendLine("			and convert(datetime, floor(convert(decimal(30,10), x.data))) >= '" + Dt_ini.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("			and convert(datetime, floor(convert(decimal(30,10), x.data))) <= '" + Dt_fin.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("			and x.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("			and not exists(select 1 from tb_ctb_lotelan lote ");
            sql.AppendLine("							where x.id_lotectb = lote.id_lotectb ");
            sql.AppendLine("							and lote.tp_integracao = 'ZR')), 0) ");

            sql.AppendLine("from tb_ctb_planocontas a ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and a.tp_contasped = '04' ");
            sql.AppendLine("and a.tp_conta = 'A' ");

            sql.AppendLine("order by a.cd_classificacao asc ");

            return sql.ToString();
        }

        public List<TRegistro_I355> Select(string Cd_empresa, DateTime Dt_ini, DateTime Dt_fin)
        {
            List<TRegistro_I355> lista = new List<TRegistro_I355>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_I355 reg = new TRegistro_I355();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta_ctb")))
                        reg.Cd_contaCTB = reader.GetDecimal(reader.GetOrdinal("cd_conta_ctb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("natureza")))
                        reg.Natureza = reader.GetString(reader.GetOrdinal("natureza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sd_atual")))
                        reg.Vl_saldo = reader.GetDecimal(reader.GetOrdinal("sd_atual"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
