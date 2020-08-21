using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using System.Runtime.Serialization;

namespace CamadaDados.Fiscal
{
    [DataContract]
    public class TRegistro_MovimentoFiscal
    {
        private string cd_empresa;
        [DataMember]
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }
        
        private decimal nr_lanctomovto;
        [DataMember]
        public decimal Nr_lanctomovto
        {
            get { return nr_lanctomovto; }
            set { nr_lanctomovto = value; }
        }

        private string cd_clifor;
        [DataMember]
        public string Cd_clifor
        {
            get { return cd_clifor; }
            set { cd_clifor = value; }
        }

        private string nm_clifor;
        [DataMember]
        public string Nm_clifor
        {
            get { return nm_clifor; }
            set { nm_clifor = value; }
        }

        private string cd_cfop;
        [DataMember]
        public string Cd_cfop
        {
            get { return cd_cfop; }
            set { cd_cfop = value; }
        }
        
        private string ds_cfop;
        [DataMember]
        public string Ds_cfop
        {
            get { return ds_cfop; }
            set { ds_cfop = value; }
        }
        
        private string sg_uf;
        [DataMember]
        public string Sg_uf
        {
            get { return sg_uf; }
            set { sg_uf = value; }
        }
        
        private string nr_doctofiscal;
        [DataMember]
        public string Nr_doctofiscal
        {
            get { return nr_doctofiscal; }
            set { nr_doctofiscal = value; }
        }
        
        private string tp_movimento;
        [DataMember]
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set { tp_movimento = value; }
        }
        
        private decimal pc_aliquota_icms;
        [DataMember]
        public decimal Pc_aliquota_icms
        {
            get { return pc_aliquota_icms; }
            set { pc_aliquota_icms = value; }
        }

        private decimal pc_aliquota_ipi;
        [DataMember]
        public decimal Pc_aliquota_ipi
        {
            get { return pc_aliquota_ipi; }
            set { pc_aliquota_ipi = value; }
        }

        private string especie;
        [DataMember]
        public string Especie
        {
            get { return especie; }
            set { especie = value; }
        }

        private decimal vl_contabil;
        [DataMember]
        public decimal Vl_contabil
        {
            get { return vl_contabil; }
            set { vl_contabil = value; }
        }

        private decimal vl_isentas;
        [DataMember]
        public decimal Vl_isentas
        {
            get { return vl_isentas; }
            set { vl_isentas = value; }
        }

        private decimal vl_outras;
        [DataMember]
        public decimal Vl_outras
        {
            get { return vl_outras; }
            set { vl_outras = value; }
        }

        private decimal vl_basecalc;
        [DataMember]
        public decimal Vl_basecalc
        {
            get { return vl_basecalc; }
            set { vl_basecalc = value; }
        }

        private decimal vl_icmssubstrib;
        [DataMember]
        public decimal Vl_icmssubstrib
        {
            get { return vl_icmssubstrib; }
            set { vl_icmssubstrib = value; }
        }

        private decimal vl_basecalcsubst;
        [DataMember]
        public decimal Vl_basecalcsubst
        {
            get { return vl_basecalcsubst; }
            set { vl_basecalcsubst = value; }
        }

        private decimal vl_icm;
        [DataMember]
        public decimal Vl_icm
        {
            get { return vl_icm; }
            set { vl_icm = value; }
        }

        private decimal vl_ipi;
        [DataMember]
        public decimal Vl_ipi
        {
            get { return vl_ipi; }
            set { vl_ipi = value; }
        }

        private string st_registro;
        [DataMember]
        public string St_registro
        {
            get { return st_registro; }
            set { st_registro = value; }
        }

        private DateTime? dt_emissao;
        [DataMember]
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set { dt_emissao = value; }
        }

        private DateTime? dt_saient;
        [DataMember]
        public DateTime? Dt_saient
        {
            get { return dt_saient; }
            set { dt_saient = value; }
        }

        private string nr_serie;
        [DataMember]
        public string Nr_serie
        {
            get { return nr_serie; }
            set { nr_serie = value; }
        }

        private string ds_serienf;
        [DataMember]
        public string Ds_serienf
        {
            get { return ds_serienf; }
            set { ds_serienf = value; }
        }

        private string nm_empresa;
        [DataMember]
        public string Nm_empresa
        {
            get { return nm_empresa; }
            set { nm_empresa = value; }
        }
        
        public TRegistro_MovimentoFiscal()
        {
            this.cd_empresa = "";
            this.nm_empresa = "";
            this.nr_lanctomovto = 0;
            this.cd_cfop = "";
            this.ds_cfop = "";
            this.sg_uf = "";
            this.nr_doctofiscal = "";
            this.tp_movimento = "";
            this.pc_aliquota_icms = 0;
            this.pc_aliquota_ipi = 0;
            this.especie = "";
            this.vl_contabil = 0;
            this.vl_isentas = 0;
            this.vl_outras = 0;
            this.vl_basecalc = 0;
            this.vl_icmssubstrib = 0;
            this.vl_basecalcsubst = 0;
            this.vl_icm = 0;
            this.vl_ipi = 0;
            this.st_registro = "A";
            this.dt_emissao = null;
            this.dt_saient = null;
            this.nr_serie = "";
            this.ds_serienf = "";
            this.cd_clifor = "";
            this.nm_clifor = "";
        }
    }

    #region "Livro Fiscal Nf"
    public class TList_RegLanFiscal : List<TRegistro_LanFiscal>
    { }

    [DataContract]
    public class TRegistro_LanFiscal : TRegistro_MovimentoFiscal
    {
        private decimal nr_lanctofiscal;
        [DataMember]
        public decimal Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set { nr_lanctofiscal = value; }
        }

        public TRegistro_LanFiscal():base()
        {
            this.nr_lanctofiscal = 0;
        }
    }

    public class TCD_LanFiscal : TDataQuery
    {
        public TCD_LanFiscal()
        { }

        public TCD_LanFiscal(string vNM_ProcBusca)
        {
            this.NM_ProcSqlBusca = vNM_ProcBusca;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("SELECT " + strTop + " d.DS_CFOP, e.DS_SerieNf, c.CD_Empresa, c.NM_Empresa, a.Nr_LanctoFiscal, b.Nr_LanctoMovto, b.Nr_DoctoFiscal, b.CD_CFOP, b.SG_Uf, b.TP_Movimento, ");
                sql.AppendLine("b.Pc_aliquota_ICMS, b.Pc_Aliquota_IPI, b.Especie, b.VL_Contabil, b.VL_Isentas, b.VL_Outras, b.VL_BASECALC, b.VL_ICMsSubsTrib, ");
                sql.AppendLine("b.VL_BaseCalcSubst, b.VL_ICM, b.VL_IPI, b.ST_Registro, b.DT_Emissao, b.DT_SaiEnt, b.Nr_Serie, b.cd_clifor ");
                sql.AppendLine(" , NM_CLIFOR = (select nm_clifor from tb_fin_clifor x where b.cd_clifor = x.cd_clifor )");
                      
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_DIV_Empresa AS c INNER JOIN ");
            sql.AppendLine(" TB_FIS_MovimentoFiscal AS b ON c.CD_Empresa = b.CD_Empresa AND c.CD_Empresa = b.CD_Empresa INNER JOIN ");
            sql.AppendLine(" TB_FIS_CFOP AS d ON b.CD_CFOP = d.CD_CFOP AND b.CD_CFOP = d.CD_CFOP INNER JOIN ");
            sql.AppendLine(" TB_FAT_SerieNF AS e ON b.Nr_Serie = e.Nr_Serie AND b.Nr_Serie = e.Nr_Serie LEFT OUTER JOIN ");
            sql.AppendLine(" TB_FIS_LivroFiscal AS a ON b.CD_Empresa = a.CD_Empresa AND b.CD_Empresa = a.CD_Empresa AND b.Nr_LanctoMovto = a.Nr_LanctoMovto AND ");
            sql.AppendLine(" b.Nr_LanctoMovto = a.Nr_LanctoMovto ");
            sql.AppendLine(" left outer join tb_fat_notafiscal f on f.cd_empresa = a.cd_empresa AND f.nr_lanctofiscal = a.nr_lanctofiscal ");
            sql.AppendLine(" Where isNull(a.ST_Registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (vGroup != "")
                sql.AppendLine(" Group By " + vGroup);
            if (vOrder != "")
                sql.AppendLine(" ORDER By " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, "", "", "" }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, "", "" }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(""))
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBuscaEscalar(sql, vParametros);
            }
        }

        public TList_RegLanFiscal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanFiscal lista = new TList_RegLanFiscal();
            Boolean VCriaBanco = false;
            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                VCriaBanco = true;
            }
            try
            {
                SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, "", ""));
                while (reader.Read())
                {
                    TRegistro_LanFiscal reg = new TRegistro_LanFiscal();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoMovto"))))
                        reg.Nr_lanctomovto = reader.GetDecimal(reader.GetOrdinal("NR_LanctoMovto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CFOP"))))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CFOP"))))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("SG_UF"))))
                        reg.Sg_uf = reader.GetString(reader.GetOrdinal("SG_UF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_DoctoFiscal"))))
                        reg.Nr_doctofiscal = reader.GetString(reader.GetOrdinal("NR_DoctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Aliquota_ICMS"))))
                        reg.Pc_aliquota_icms = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota_ICMS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_Aliquota_IPI"))))
                        reg.Pc_aliquota_ipi = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota_IPI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Especie"))))
                        reg.Especie = reader.GetString(reader.GetOrdinal("Especie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Contabil"))))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("Vl_Contabil"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Isentas"))))
                        reg.Vl_isentas = reader.GetDecimal(reader.GetOrdinal("Vl_Isentas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Outras"))))
                        reg.Vl_outras = reader.GetDecimal(reader.GetOrdinal("Vl_Outras"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc"))))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_ICMSSubsTrib"))))
                        reg.Vl_icmssubstrib = reader.GetDecimal(reader.GetOrdinal("Vl_ICMSSubsTrib"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcSubst"))))
                        reg.Vl_basecalcsubst = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcSubst"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_ICM"))))
                        reg.Vl_icm = reader.GetDecimal(reader.GetOrdinal("Vl_ICM"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IPI"))))
                        reg.Vl_ipi = reader.GetDecimal(reader.GetOrdinal("Vl_IPI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt"))))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_SerieNF"))))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("DS_SerieNF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    lista.Add(reg);
                }

            }
            finally
            {
               
               
                if (VCriaBanco)
                {
                    deletarBanco_Dados();
                }
            }

            return lista;
        }

        public string GravaFiscal(TRegistro_LanFiscal val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            return this.executarProc("INCLUI_FIS_MOVTOFISCAL", hs);
        }

        public string DeletaFiscal(TRegistro_LanFiscal val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            return this.executarProc("EXCLUI_FIS_LIVROFISCAL", hs);
        }
    }
    #endregion
}
