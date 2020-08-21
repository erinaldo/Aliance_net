using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Empreendimento
{
    #region "Classe Empreendimento"
    public class TList_Empreendimento : List<TRegistro_Empreendimento>
    { }
    
    public class TRegistro_Empreendimento
    {
        
        public decimal? Id_empreendimento
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Ds_empreendimento
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        private DateTime? dt_iniempreendimento;
        
        public DateTime? Dt_iniempreendimento
        {
            get { return dt_iniempreendimento; }
            set
            {
                dt_iniempreendimento = value;
                dt_iniempreendimentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_iniempreendimentostr;
        public string Dt_iniempreendimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_iniempreendimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_iniempreendimentostr = value;
                try
                {
                    dt_iniempreendimento = Convert.ToDateTime(value);
                }
                catch
                { dt_iniempreendimento = null; }
            }
        }
        private DateTime? dt_encerramento;
        
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_encerramentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = Convert.ToDateTime(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
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
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
            }
        }
        
        public CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF lCResultado
        { get; set; }
        
        public CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF lCResultadoDel
        { get; set; }
        
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lLanCCusto
        { get; set; }
        
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lLanCCustoDel
        { get; set; }

        public TRegistro_Empreendimento()
        {
            this.Id_empreendimento = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Ds_empreendimento = string.Empty;
            this.Ds_observacao = string.Empty;
            this.dt_iniempreendimento = null;
            this.dt_iniempreendimentostr = string.Empty;
            this.dt_encerramento = null;
            this.dt_encerramentostr = string.Empty;
            this.st_registro = "A";
            this.status = "ATIVO";

            this.lCResultado = new CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF();
            this.lCResultadoDel = new CamadaDados.Financeiro.Cadastros.TList_CadGrupoCF();
            this.lLanCCusto = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
            this.lLanCCustoDel = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_Empreendimento : TDataQuery
    {
        public TCD_Empreendimento()
        { }

        public TCD_Empreendimento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_empreendimento, a.cd_empresa, ");
                sql.AppendLine("b.nm_empresa, a.ds_empreendimento, a.ds_observacao, ");
                sql.AppendLine("a.dt_iniempreendimento, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_empreendimento a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Empreendimento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Empreendimento lista = new TList_Empreendimento();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Empreendimento reg = new TRegistro_Empreendimento();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Empreendimento"))))
                        reg.Id_empreendimento = reader.GetDecimal(reader.GetOrdinal("ID_Empreendimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Empreendimento")))
                        reg.Ds_empreendimento = reader.GetString(reader.GetOrdinal("DS_Empreendimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniEmpreendimento")))
                        reg.Dt_iniempreendimento = reader.GetDateTime(reader.GetOrdinal("DT_IniEmpreendimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string GravarEmpreendimento(TRegistro_Empreendimento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DS_EMPREENDIMENTO", val.Ds_empreendimento);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DT_INIEMPREENDIMENTO", val.Dt_iniempreendimento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_EMPREENDIMENTO", hs);
        }

        public string DeletarEmpreendimento(TRegistro_Empreendimento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);

            return this.executarProc("EXCLUI_FIN_EMPREENDIMENTO", hs);
        }
    }
    #endregion

    #region "Classe Empreendimento X CResultado"
    public class TList_Empreendimento_X_CResultado : List<TRegistro_Empreendimento_X_CResultado>
    { }
    
    public class TRegistro_Empreendimento_X_CResultado
    {
        
        public decimal? Id_empreendimento
        { get; set; }
        
        public string Cd_grupocf
        { get; set; }

        public TRegistro_Empreendimento_X_CResultado()
        {
            this.Id_empreendimento = null;
            this.Cd_grupocf = string.Empty;
        }
    }

    public class TCD_Empreendimento_X_CResultado : TDataQuery
    {
        public TCD_Empreendimento_X_CResultado()
        { }

        public TCD_Empreendimento_X_CResultado(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.id_empreendimento, a.cd_grupocf ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_empreendimento_x_cresultado a ");

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

        public TList_Empreendimento_X_CResultado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Empreendimento_X_CResultado lista = new TList_Empreendimento_X_CResultado();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Empreendimento_X_CResultado reg = new TRegistro_Empreendimento_X_CResultado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Empreendimento"))))
                        reg.Id_empreendimento = reader.GetDecimal(reader.GetOrdinal("ID_Empreendimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF"))))
                        reg.Cd_grupocf = reader.GetString(reader.GetOrdinal("CD_GrupoCF"));

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

        public string GravarEmpreendimento_X_CResultado(TRegistro_Empreendimento_X_CResultado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);
            hs.Add("@P_CD_GRUPOCF", val.Cd_grupocf);

            return this.executarProc("IA_FIN_EMPREENDIMENTO_X_CRESULTADO", hs);
        }

        public string DeletarEmpreendimento_X_CResultado(TRegistro_Empreendimento_X_CResultado val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);
            hs.Add("@P_CD_GRUPOCF", val.Cd_grupocf);

            return this.executarProc("EXCLUI_FIN_EMPREENDIMENTO_X_CRESULTADO", hs);
        }
    }
    #endregion

    #region "Classe Empreendimento X LanCCusto"
    public class TList_Empreendimento_X_LanCCusto : List<TRegistro_Empreendimento_X_lanCCusto>
    { }
    
    public class TRegistro_Empreendimento_X_lanCCusto
    {
        
        public decimal? Id_empreendimento
        { get; set; }
        
        public decimal? Id_ccustolan
        { get; set; }

        public TRegistro_Empreendimento_X_lanCCusto()
        {
            this.Id_ccustolan = null;
            this.Id_empreendimento = null;
        }
    }

    public class TCD_Empreendimento_X_LnCCusto : TDataQuery
    {
        public TCD_Empreendimento_X_LnCCusto()
        { }

        public TCD_Empreendimento_X_LnCCusto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.id_empreendimento, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Empreendimento_X_LanCCusto a ");

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

        public TList_Empreendimento_X_LanCCusto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Empreendimento_X_LanCCusto lista = new TList_Empreendimento_X_LanCCusto();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Empreendimento_X_lanCCusto reg = new TRegistro_Empreendimento_X_lanCCusto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Empreendimento"))))
                        reg.Id_empreendimento = reader.GetDecimal(reader.GetOrdinal("ID_Empreendimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_CCustoLan"))))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("ID_CCustoLan"));

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

        public string GravarEmpreendimento_X_LanCCusto(TRegistro_Empreendimento_X_lanCCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("IA_FIN_EMPREENDIMENTO_X_LANCCUSTO", hs);
        }

        public string DeletarEmpreendimento_X_LanCCusto(TRegistro_Empreendimento_X_lanCCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPREENDIMENTO", val.Id_empreendimento);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("EXCLUI_FIN_EMPREENDIMENTO_X_LANCCUSTO", hs);
        }
    }
    #endregion

    #region "Classe Resultado Empreendimento"
    public class TList_ResultadoEmpreendimento : List<TRegistro_ResultadoEmpreendimento>
    { }

    
    public class TRegistro_ResultadoEmpreendimento
    {
        
        public decimal Id_empreendimento
        { get; set; }
        
        public string Ds_empreendimento
        { get; set; }
        
        public string Cd_grupocf1
        { get; set; }
        
        public string Ds_grupocf1
        { get; set; }
        
        public string Cd_grupocf2
        { get; set; }
        
        public string Ds_grupocf2
        { get; set; }
        
        public string Cd_grupocf3
        { get; set; }
        
        public string Ds_grupocf3
        { get; set; }
        
        public string Cd_grupocf4
        { get; set; }
        
        public string Ds_grupocf4
        { get; set; }
        
        public decimal Valor
        { get; set; }

        public TRegistro_ResultadoEmpreendimento()
        {
            this.Id_empreendimento = decimal.Zero;
            this.Ds_empreendimento = string.Empty;
            this.Cd_grupocf1 = string.Empty;
            this.Ds_grupocf1 = string.Empty;
            this.Cd_grupocf2 = string.Empty;
            this.Ds_grupocf2 = string.Empty;
            this.Cd_grupocf3 = string.Empty;
            this.Ds_grupocf3 = string.Empty;
            this.Cd_grupocf4 = string.Empty;
            this.Ds_grupocf4 = string.Empty;
            this.Valor = decimal.Zero;
        }
    }

    public class TCD_ResultadoEmpreendimento : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select emp.ID_Empreendimento, emp.DS_Empreendimento, ");
            sql.AppendLine("a.CD_GrupoCF as cd_grupocf4, a.DS_GrupoCF as ds_grupocf4, ");
            sql.AppendLine("b.CD_GrupoCF as cd_grupocf3, b.DS_GrupoCF as ds_grupocf3, ");
            sql.AppendLine("c.CD_GrupoCF as cd_grupocf2, c.DS_GrupoCF as ds_grupocf2, ");
            sql.AppendLine("d.CD_GrupoCF as cd_grupocf1, d.DS_GrupoCF as ds_grupocf1, ");
            sql.AppendLine("valor = ISNULL((select isnull(case when a.TP_Movimento = 'R' then sum(isnull(x.VL_Lancto, 0)) else sum(isnull(x.VL_Lancto, 0)) * (-1) end , 0) ");
            sql.AppendLine("				from TB_FIN_CCustoLancto x ");
            sql.AppendLine("				inner join TB_FIN_Empreendimento_X_LanCCusto y ");
            sql.AppendLine("				on x.Id_CCustoLan = y.Id_CCustoLan ");
            sql.AppendLine("				and x.cd_grupocf = a.CD_GrupoCF ");
            sql.AppendLine("				and y.ID_Empreendimento = emp.ID_Empreendimento), 0) ");
            sql.AppendLine("from TB_FIN_GrupoCF a ");
            sql.AppendLine("left outer join TB_FIN_GrupoCF b ");
            sql.AppendLine("on a.CD_GrupoCF_Pai = b.CD_GrupoCF ");
            sql.AppendLine("left outer join TB_FIN_GrupoCF c ");
            sql.AppendLine("on b.CD_GrupoCF_Pai = c.CD_GrupoCF ");
            sql.AppendLine("left outer join TB_FIN_GrupoCF d ");
            sql.AppendLine("on c.CD_GrupoCF_Pai = d.CD_GrupoCF, ");
            sql.AppendLine("TB_FIN_Empreendimento emp ");
            sql.AppendLine("where a.CD_GrupoCF is not null ");
            sql.AppendLine("and b.CD_GrupoCF is not null ");
            sql.AppendLine("and c.CD_GrupoCF is not null ");
            sql.AppendLine("and d.CD_GrupoCF is not null ");
            if (filtro != null)
            {
                string cond = " and ";
                for (int i = 0; i < (filtro.Length); i++)
                    sql.AppendLine(cond + " ( " + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            }
            return sql.ToString();
        }

        public TList_ResultadoEmpreendimento Select(TpBusca[] filtro)
        {
            TList_ResultadoEmpreendimento lista = new TList_ResultadoEmpreendimento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(filtro));
                while (reader.Read())
                {
                    TRegistro_ResultadoEmpreendimento reg = new TRegistro_ResultadoEmpreendimento();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Empreendimento"))))
                        reg.Id_empreendimento = reader.GetDecimal(reader.GetOrdinal("ID_Empreendimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Empreendimento"))))
                        reg.Ds_empreendimento = reader.GetString(reader.GetOrdinal("DS_Empreendimento")).Trim();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF1"))))
                        reg.Cd_grupocf1 = reader.GetString(reader.GetOrdinal("CD_GrupoCF1")).Trim();
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF1"))))
                        reg.Ds_grupocf1 = reader.GetString(reader.GetOrdinal("DS_GrupoCF1")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF2")))
                        reg.Cd_grupocf2 = reader.GetString(reader.GetOrdinal("CD_GrupoCF2")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF2")))
                        reg.Ds_grupocf2 = reader.GetString(reader.GetOrdinal("DS_GrupoCF2")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF3")))
                        reg.Cd_grupocf3 = reader.GetString(reader.GetOrdinal("CD_GrupoCF3")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF3")))
                        reg.Ds_grupocf3 = reader.GetString(reader.GetOrdinal("DS_GrupoCF3")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF4")))
                        reg.Cd_grupocf4 = reader.GetString(reader.GetOrdinal("CD_GrupoCF4")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF4")))
                        reg.Ds_grupocf4 = reader.GetString(reader.GetOrdinal("DS_GrupoCF4")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("Valor"));
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
    }
    #endregion
}
