using System;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CamadaDados.Financeiro.ProvisaoDRG
{
    #region Provisao DRG
    public class TList_LanProvisaoDRG : List<TRegistro_LanProvisaoDRG>, IComparer<TRegistro_LanProvisaoDRG>
    {
        #region IComparer<TRegistro_LanProvisaoDRG> Members
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

        public TList_LanProvisaoDRG()
        { }

        public TList_LanProvisaoDRG(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanProvisaoDRG value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanProvisaoDRG x, TRegistro_LanProvisaoDRG y)
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

    
    public class TRegistro_LanProvisaoDRG
    {
        
        public string Cd_centroresult
        { get; set; }
        
        public string Ds_centroresultado
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        public decimal Dia
        { get; set; }
        public decimal Mes
        { get; set; }
        
        public decimal Ano
        { get; set; }
        
        public decimal Vl_previsto
        { get; set; }
        public string Messtr
        {
            get
            {
                switch (Convert.ToInt32(Mes))
                {
                    case 1: return "JANEIRO";
                    case 2: return "FEVEREIRO";
                    case 3: return "MARÇO";
                    case 4: return "ABRIL";
                    case 5: return "MAIO";
                    case 6: return "JUNHO";
                    case 7: return "JULHO";
                    case 8: return "AGOSTO";
                    case 9: return "SETEMBRO";
                    case 10: return "OUTUBRO";
                    case 11: return "NOVEMBRO";
                    case 12: return "DEZEMBRO";
                    default: return string.Empty;
                }
            }
        }
        public bool St_processar
        { get; set; }

        public TRegistro_LanProvisaoDRG()
        {
            Cd_centroresult = string.Empty;
            Ds_centroresultado = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Dia = decimal.Zero;
            Mes = decimal.Zero;
            Ano = decimal.Zero;
            Vl_previsto = decimal.Zero;
            St_processar = false;
        }
    }

    public class TCD_LanProvisaoDRG : TDataQuery
    {
        public TCD_LanProvisaoDRG()
        { }

        public TCD_LanProvisaoDRG(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_centroresult, b.ds_centroresultado, ");
            sql.AppendLine("a.cd_empresa, c.nm_empresa, a.dia, a.mes, a.ano, a.vl_previsto ");

            sql.AppendLine("from TB_FIN_ProvisaoDRG a ");
            sql.AppendLine("inner join TB_FIN_CentroResultado b ");
            sql.AppendLine("on a.cd_centroresult = b.cd_centroresult ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + " ( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca), null);
        }

        public TList_LanProvisaoDRG Select(TpBusca[] vBusca)
        {
            TList_LanProvisaoDRG lista = new TList_LanProvisaoDRG();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanProvisaoDRG reg = new TRegistro_LanProvisaoDRG();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("CD_CentroResult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResultado")))
                        reg.Ds_centroresultado = reader.GetString(reader.GetOrdinal("DS_CentroResultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dia")))
                        reg.Dia = reader.GetDecimal(reader.GetOrdinal("dia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetDecimal(reader.GetOrdinal("Mes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetDecimal(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Previsto")))
                        reg.Vl_previsto = reader.GetDecimal(reader.GetOrdinal("Vl_Previsto"));

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

        public string Gravar(TRegistro_LanProvisaoDRG val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_MES", val.Mes);
            hs.Add("@P_ANO", val.Ano);
            hs.Add("@P_DIA", val.Dia);
            hs.Add("@P_VL_PREVISTO", val.Vl_previsto);

            return executarProc("IA_FIN_PROVISAODRG", hs);
        }

        public string Excluir(TRegistro_LanProvisaoDRG val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_MES", val.Mes);
            hs.Add("@P_ANO", val.Ano);

            return executarProc("EXCLUI_FIN_PROVISAODRG", hs);
        }
    }
    #endregion

    #region Provisao Mes
    public class TList_ProvisaoMes : List<TRegistro_ProvisaoMes>
    { }

    
    public class TRegistro_ProvisaoMes
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_centroresult_pai
        { get; set; }
        
        public string Ds_centroresult_pai
        { get; set; }
        
        public string Cd_centroresult
        { get; set; }
        
        public string Ds_centroresult
        { get; set; }
        
        public decimal Ano
        { get; set; }
        
        public decimal Vl_prev_janeiro
        { get; set; }
        
        public decimal Vl_real_janeiro
        { get; set; }
        
        public decimal Vl_prev_fevereiro
        { get; set; }
        
        public decimal Vl_real_fevereiro
        { get; set; }
        
        public decimal Vl_prev_marco
        { get; set; }
        
        public decimal Vl_real_marco
        { get; set; }
        
        public decimal Vl_prev_abril
        { get; set; }
        
        public decimal Vl_real_abril
        { get; set; }
        
        public decimal Vl_prev_maio
        { get; set; }
        
        public decimal Vl_real_maio
        { get; set; }
        
        public decimal Vl_prev_junho
        { get; set; }
        
        public decimal Vl_real_junho
        { get; set; }
        
        public decimal Vl_prev_julho
        { get; set; }
        
        public decimal Vl_real_julho
        { get; set; }
        
        public decimal Vl_prev_agosto
        { get; set; }
        
        public decimal Vl_real_agosto
        { get; set; }
        
        public decimal Vl_prev_setembro
        { get; set; }
        
        public decimal Vl_real_setembro
        { get; set; }
        
        public decimal Vl_prev_outubro
        { get; set; }
        
        public decimal Vl_real_outubro
        { get; set; }
        
        public decimal Vl_prev_novembro
        { get; set; }
        
        public decimal Vl_real_novembro
        { get; set; }
        
        public decimal Vl_prev_dezembro
        { get; set; }
        
        public decimal Vl_real_dezembro
        { get; set; }
        public decimal Vl_total_previsto
        {
            get
            {
                return Vl_prev_janeiro +
                       Vl_prev_fevereiro +
                       Vl_prev_marco +
                       Vl_prev_abril +
                       Vl_prev_maio +
                       Vl_prev_junho +
                       Vl_prev_julho +
                       Vl_prev_agosto +
                       Vl_prev_setembro +
                       Vl_prev_outubro +
                       Vl_prev_novembro +
                       Vl_prev_dezembro;
            }
        }
        public decimal Vl_total_realizado
        {
            get
            {
                return Vl_real_janeiro +
                       Vl_real_fevereiro +
                       Vl_real_marco +
                       Vl_real_abril +
                       Vl_real_maio +
                       Vl_real_junho +
                       Vl_real_julho +
                       Vl_real_agosto +
                       Vl_real_setembro +
                       Vl_real_outubro +
                       Vl_real_novembro +
                       Vl_real_dezembro;
            }
        }

        public TRegistro_ProvisaoMes()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_centroresult = string.Empty;
            Ds_centroresult = string.Empty;
            Cd_centroresult_pai = string.Empty;
            Ds_centroresult_pai = string.Empty;
            Ano = decimal.Zero;
            Vl_prev_janeiro = decimal.Zero;
            Vl_real_janeiro = decimal.Zero;
            Vl_prev_fevereiro = decimal.Zero;
            Vl_real_fevereiro = decimal.Zero;
            Vl_prev_marco = decimal.Zero;
            Vl_real_marco = decimal.Zero;
            Vl_prev_abril = decimal.Zero;
            Vl_real_abril = decimal.Zero;
            Vl_prev_maio = decimal.Zero;
            Vl_real_maio = decimal.Zero;
            Vl_prev_junho = decimal.Zero;
            Vl_real_junho = decimal.Zero;
            Vl_prev_julho = decimal.Zero;
            Vl_real_julho = decimal.Zero;
            Vl_prev_agosto = decimal.Zero;
            Vl_real_agosto = decimal.Zero;
            Vl_prev_setembro = decimal.Zero;
            Vl_real_setembro = decimal.Zero;
            Vl_prev_outubro = decimal.Zero;
            Vl_real_outubro = decimal.Zero;
            Vl_prev_novembro = decimal.Zero;
            Vl_real_novembro = decimal.Zero;
            Vl_prev_dezembro = decimal.Zero;
            Vl_real_dezembro = decimal.Zero;
        }
    }

    public class TCD_ProvisaoMes : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, a.nm_empresa, ");
            sql.AppendLine("a.cd_centroresult_pai, a.ds_centroresult_pai, ");
            sql.AppendLine("a.cd_centroresult, a.ds_centroresult, a.ano, ");
            sql.AppendLine("a.vl_prev_janeiro, a.vl_real_janeiro, ");
            sql.AppendLine("a.vl_prev_fevereiro, a.vl_real_fevereiro, ");
            sql.AppendLine("a.vl_prev_marco, a.vl_real_marco, ");
            sql.AppendLine("a.vl_prev_abril, a.vl_real_abril, ");
            sql.AppendLine("a.vl_prev_maio, a.vl_real_maio, ");
            sql.AppendLine("a.vl_prev_junho, a.vl_real_junho, ");
            sql.AppendLine("a.vl_prev_julho, a.vl_real_julho, ");
            sql.AppendLine("a.vl_prev_agosto, a.vl_real_agosto, ");
            sql.AppendLine("a.vl_prev_setembro, a.vl_real_setembro, ");
            sql.AppendLine("a.vl_prev_outubro, a.vl_real_outubro, ");
            sql.AppendLine("a.vl_prev_novembro, a.vl_real_novembro, ");
            sql.AppendLine("a.vl_prev_dezembro, a.vl_real_dezembro ");

            sql.AppendLine("from VTB_FIN_PROVISAODRG a ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + " ( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_centroresult ");
            return sql.ToString();
        }

        public TList_ProvisaoMes Select(TpBusca[] vBusca)
        {
            TList_ProvisaoMes lista = new TList_ProvisaoMes();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ProvisaoMes reg = new TRegistro_ProvisaoMes();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("CD_CentroResult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult")))
                        reg.Ds_centroresult = reader.GetString(reader.GetOrdinal("DS_CentroResult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CentroResult_Pai")))
                        reg.Cd_centroresult_pai = reader.GetString(reader.GetOrdinal("CD_CentroResult_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CentroResult_Pai")))
                        reg.Ds_centroresult_pai = reader.GetString(reader.GetOrdinal("DS_CentroResult_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetDecimal(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_janeiro")))
                        reg.Vl_prev_janeiro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_janeiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_janeiro")))
                        reg.Vl_real_janeiro = reader.GetDecimal(reader.GetOrdinal("Vl_real_janeiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_fevereiro")))
                        reg.Vl_prev_fevereiro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_fevereiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_fevereiro")))
                        reg.Vl_real_fevereiro = reader.GetDecimal(reader.GetOrdinal("Vl_real_fevereiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_marco")))
                        reg.Vl_prev_marco = reader.GetDecimal(reader.GetOrdinal("Vl_prev_marco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_marco")))
                        reg.Vl_real_marco = reader.GetDecimal(reader.GetOrdinal("Vl_real_marco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_abril")))
                        reg.Vl_prev_abril = reader.GetDecimal(reader.GetOrdinal("Vl_prev_abril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_abril")))
                        reg.Vl_real_abril = reader.GetDecimal(reader.GetOrdinal("Vl_real_abril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_maio")))
                        reg.Vl_prev_maio = reader.GetDecimal(reader.GetOrdinal("Vl_prev_maio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_maio")))
                        reg.Vl_real_maio = reader.GetDecimal(reader.GetOrdinal("Vl_real_maio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_junho")))
                        reg.Vl_prev_junho = reader.GetDecimal(reader.GetOrdinal("Vl_prev_junho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_junho")))
                        reg.Vl_real_junho = reader.GetDecimal(reader.GetOrdinal("Vl_real_junho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_julho")))
                        reg.Vl_prev_julho = reader.GetDecimal(reader.GetOrdinal("Vl_prev_julho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_julho")))
                        reg.Vl_real_julho = reader.GetDecimal(reader.GetOrdinal("Vl_real_julho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_agosto")))
                        reg.Vl_prev_agosto = reader.GetDecimal(reader.GetOrdinal("Vl_prev_agosto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_agosto")))
                        reg.Vl_real_agosto = reader.GetDecimal(reader.GetOrdinal("Vl_real_agosto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_setembro")))
                        reg.Vl_prev_setembro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_setembro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_setembro")))
                        reg.Vl_real_setembro = reader.GetDecimal(reader.GetOrdinal("Vl_real_setembro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_outubro")))
                        reg.Vl_prev_outubro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_outubro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_outubro")))
                        reg.Vl_real_outubro = reader.GetDecimal(reader.GetOrdinal("Vl_real_outubro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_novembro")))
                        reg.Vl_prev_novembro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_novembro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_novembro")))
                        reg.Vl_real_novembro = reader.GetDecimal(reader.GetOrdinal("Vl_real_novembro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_prev_dezembro")))
                        reg.Vl_prev_dezembro = reader.GetDecimal(reader.GetOrdinal("Vl_prev_dezembro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_real_dezembro")))
                        reg.Vl_real_dezembro = reader.GetDecimal(reader.GetOrdinal("Vl_real_dezembro"));
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
    }
    #endregion
}
