using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace CamadaDados.Financeiro.ProvisaoDRG
{
    public class TList_SaldoProvisaoDRG : List<TRegistro_SaldoProvisaoDRG>
    { }
    [DataContract]
    public class TRegistro_SaldoProvisaoDRG
    {
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Nm_empresa
        { get; set; }
        [DataMember]
        public decimal Ano
        { get; set; }
        [DataMember]
        public string Mes
        { get; set; }
        [DataMember]
        public string MesStr
        {
            get
            {
                if (Mes.Trim().Equals(string.Empty))
                    return string.Empty;
                switch (Convert.ToInt32(this.Mes))
                {
                    case 1: return "Janeiro";
                    case 2: return "Fevereiro";
                    case 3: return "Março";
                    case 4: return "Abril";
                    case 5: return "Maio";
                    case 6: return "Junho";
                    case 7: return "Julho";
                    case 8: return "Agosto";
                    case 9: return "Setembro";
                    case 10: return"Outubro";
                    case 11: return "Novembro";
                    case 12: return "Dezembro";
                    default: return string.Empty;
                }
            }
        }
        [DataMember]
        public decimal Vl_saldoprevisto
        { get; set; }
        [DataMember]
        public decimal Vl_saldorealizado
        { get; set; }

        public TRegistro_SaldoProvisaoDRG()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Ano = 2008;
            this.Mes = string.Empty;
            this.Vl_saldoprevisto = decimal.Zero;
            this.Vl_saldorealizado = decimal.Zero;
        }
    }

    public class TCD_SaldoProvisaoDRG : TDataQuery
    {
        public TCD_SaldoProvisaoDRG()
        { }

        public TCD_SaldoProvisaoDRG(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.ano, a.mes, a.vl_saldoprevisto, a.vl_saldorealizado ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_saldoprovisaodrg a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_empresa, a.ano, a.mes ");
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
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_SaldoProvisaoDRG Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_SaldoProvisaoDRG lista = new TList_SaldoProvisaoDRG();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoProvisaoDRG reg = new TRegistro_SaldoProvisaoDRG();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ano")))
                        reg.Ano = reader.GetDecimal(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mes")))
                        reg.Mes = reader.GetDecimal(reader.GetOrdinal("Mes")).ToString();
                    if(!reader.IsDBNull(reader.GetOrdinal("Vl_SaldoPrevisto")))
                        reg.Vl_saldoprevisto = reader.GetDecimal(reader.GetOrdinal("Vl_SaldoPrevisto"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Vl_SaldoRealizado")))
                        reg.Vl_saldorealizado = reader.GetDecimal(reader.GetOrdinal("Vl_SaldoRealizado"));

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

        public string GravarSaldoProvisaoDRG(TRegistro_SaldoProvisaoDRG reg)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", reg.Cd_empresa);
            hs.Add("@P_ANO", reg.Ano);
            hs.Add("@P_MES", reg.Mes);
            hs.Add("@P_VL_SALDOPREVISTO", reg.Vl_saldoprevisto);
            hs.Add("@P_VL_SALDOREALIZADO", reg.Vl_saldorealizado);

            return this.executarProc("IA_FIN_SALDOPROVISAODRG", hs);
        }

        public string DeletarSaldoProvisaoDRG(TRegistro_SaldoProvisaoDRG reg)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", reg.Cd_empresa);
            hs.Add("@P_ANO", reg.Ano);
            hs.Add("@P_MES", reg.Mes);

            return this.executarProc("EXCLUI_FIN_SALDOPROVISAODRG", hs);
        }
    }
}
