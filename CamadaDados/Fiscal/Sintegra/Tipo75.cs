using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo75
    {
        public string Tipo
        {
            get
            {
                return "75";
            }
        }
        public DateTime? Dt_inicial
        { get; set; }
        public DateTime? Dt_final
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ncm
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla
        { get; set; }
        public decimal Pc_aliquota_ipi
        { get; set; }
        public decimal Pc_aliquota_icms
        { get; set; }
        public decimal Pc_reducao_basecalcicms
        { get; set; }
        public decimal Base_calc_icms_substtrib
        { get; set; }

        public Tipo75()
        {
            this.Dt_inicial = null;
            this.Dt_final = null;
            this.Cd_produto = string.Empty;
            this.Ncm = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla = string.Empty;
            this.Pc_aliquota_ipi = decimal.Zero;
            this.Pc_aliquota_icms = decimal.Zero;
            this.Pc_reducao_basecalcicms = decimal.Zero;
            this.Base_calc_icms_substtrib = decimal.Zero;
        }
    }

    public class TCD_Tipo75 : TDataQuery
    {
        public TCD_Tipo75() { }

        public TCD_Tipo75(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        public List<Tipo75> Select(string Cd_empresa,
                                   DateTime Dt_ini,
                                   DateTime Dt_fin,
                                   DateTime? Dt_inventario)
        {
            List<Tipo75> retorno = new List<Tipo75>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", Cd_empresa);
            hs.Add("@P_DT_INI", Dt_ini);
            hs.Add("@P_DT_FIN", DateTime.Parse(Dt_fin.ToString("dd/MM/yyyy") + " 23:59:59"));
            hs.Add("@P_DT_INVENTARIO", Dt_inventario);
            System.Data.SqlClient.SqlDataReader reader = this.executarProcReader("DBO.STP_FIS_REG75", hs);
            try
            {
                while (reader.Read())
                {
                    Tipo75 reg = new Tipo75();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota_ipi")))
                        reg.Pc_aliquota_ipi = reader.GetDecimal(reader.GetOrdinal("pc_aliquota_ipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquota_icms")))
                        reg.Pc_aliquota_icms = reader.GetDecimal(reader.GetOrdinal("pc_aliquota_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_reducaobasecalc")))
                        reg.Pc_reducao_basecalcicms = reader.GetDecimal(reader.GetOrdinal("pc_reducaobasecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalcsubsttrib")))
                        reg.Base_calc_icms_substtrib = reader.GetDecimal(reader.GetOrdinal("vl_basecalcsubsttrib"));
                    retorno.Add(reg);
                }
                return retorno;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }
    }
}
