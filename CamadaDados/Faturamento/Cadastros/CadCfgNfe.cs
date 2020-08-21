using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CfgNfe : List<TRegistro_CfgNfe>, IComparer<TRegistro_CfgNfe>
    {
        #region IComparer<TRegistro_CfgNfe> Members
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

        public TList_CfgNfe()
        { }

        public TList_CfgNfe(System.ComponentModel.PropertyDescriptor Prop,
                            System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgNfe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgNfe x, TRegistro_CfgNfe y)
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
    
    public class TRegistro_CfgNfe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_uf_empresa
        { get; set; }
        public string Cd_municipio_empresa
        { get; set; }
        public string Cnpj_empresa
        { get; set; }
        public string Insc_municipal_empresa
        { get; set; }
        public string Cnpj_contador { get; set; } = string.Empty;
        public string Tp_regimetributario
        { get; set; }
        public string Path_nfe_schemas
        { get; set; }
        public string Nr_certificado_nfe
        { get; set; }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().ToUpper().Equals("H"))
                    tipo_ambiente = "HOMOLOGACAO";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_ambiente = "PRODUCAO";
            }
        }
        private string tipo_ambiente;
        public string Tipo_ambiente
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("HOMOLOGACAO"))
                    tp_ambiente = "H";
                else if (value.Trim().ToUpper().Equals("PRODUCAO"))
                    tp_ambiente = "P";
            }
        }
        private string tp_ambiente_nfes;
        public string Tp_ambiente_nfes
        {
            get { return tp_ambiente_nfes; }
            set
            {
                tp_ambiente_nfes = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_ambiente_nfes = "PRODUCAO";
                else if (value.Trim().ToUpper().Equals("H"))
                    tipo_ambiente_nfes = "HOMOLOGACAO";
            }
        }
        private string tipo_ambiente_nfes;
        public string Tipo_ambiente_nfes
        {
            get { return tipo_ambiente_nfes; }
            set
            {
                tipo_ambiente_nfes = value;
                if (value.Trim().ToUpper().Equals("PRODUCAO"))
                    tp_ambiente_nfes = "P";
                else if (value.Trim().ToUpper().Equals("HOMOLOGACAO"))
                    tp_ambiente_nfes = "H";
            }
        }
        private string tp_ambiente_nfce;
        public string Tp_ambiente_nfce
        {
            get { return tp_ambiente_nfce; }
            set
            {
                tp_ambiente_nfce = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente_nfce = "PRODUCAO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente_nfce = "HOMOLOGACAO";
                else tipo_ambiente_nfce = string.Empty;
            }
        }
        private string tipo_ambiente_nfce;
        public string Tipo_ambiente_nfce
        {
            get { return tipo_ambiente_nfce; }
            set
            {
                tipo_ambiente_nfce = value;
                if (value.Trim().ToUpper().Equals("PRODUCAO"))
                    tp_ambiente_nfce = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGACAO"))
                    tp_ambiente_nfce = "2";
                else tp_ambiente_nfce = string.Empty;
            }
        }
        private string tp_ambiente_lmc;
        public string Tp_ambiente_lmc
        {
            get { return tp_ambiente_lmc; }
            set
            {
                tp_ambiente_lmc = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente_lmc = "PRODUÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente_lmc = "HOMOLOGAÇÃO";
            }
        }
        private string tipo_ambiente_lmc;
        public string Tipo_ambiente_lmc
        {
            get { return tipo_ambiente_lmc; }
            set
            {
                tipo_ambiente_lmc = value;
                if (value.Trim().ToUpper().Equals("PRODUÇÃO"))
                    tp_ambiente_lmc = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente_lmc = "2";
            }
        }
        public string Cd_versao
        { get; set; }
        public decimal Horascancnfe
        { get; set; }
        public decimal Id_entidadenfes
        { get; set; }
        public decimal Nr_diasexpirarcert
        { get; set; }
        private string st_enviaremailcontador;
        public string St_enviaremailcontador
        {
            get { return st_enviaremailcontador; }
            set
            {
                st_enviaremailcontador = value;
                st_enviaremailcontadorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_enviaremailcontadorbool;
        public bool St_enviaremailcontadorbool
        {
            get { return st_enviaremailcontadorbool; }
            set
            {
                st_enviaremailcontadorbool = value;
                st_enviaremailcontador = value ? "S" : "N";
            }
        }
        public DateTime? Dt_avisoCert
        { get; set; }
        public DateTime? Dt_contingencia
        { get; set; }
        public string Ds_condusoCCe
        { get; set; }
        public string Cd_versaoEvento { get; set; } = string.Empty;
        public string Cd_versaocondest
        { get; set; }
        public string Cd_versaoLMC
        { get; set; }
        private string tp_ambientecont;
        public string Tp_ambientecont
        {
            get { return tp_ambientecont; }
            set
            {
                tp_ambientecont = value;
                if (value.Trim().ToUpper().Equals("N"))
                    tipo_ambientecont = "NACIONAL";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_ambientecont = "RIO GRANDE DO SUL";
            }
        }
        private string tipo_ambientecont;
        public string Tipo_ambientecont
        {
            get { return tipo_ambientecont; }
            set
            {
                tipo_ambientecont = value;
                if (value.Trim().ToUpper().Equals("NACIONAL"))
                    tp_ambientecont = "N";
                else if (value.Trim().ToUpper().Equals("RIO GRANDE DO SUL"))
                    tp_ambientecont = "R";
            }
        }
        public bool St_nfecontingencia
        { get; set; }
        public decimal Vl_limitenfce
        { get; set; }
        public decimal Vl_limitenfcenaoident
        { get; set; }
        public string Nr_csc
        { get; set; }
        public string Id_tokencsc
        { get; set; }
        public string Cd_versaonfce
        { get; set; }
        public string Url_nfce
        { get; set; }
        public string Url_chavenfce
        { get; set; }
        
        public TRegistro_CfgNfe()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_uf_empresa = string.Empty;
            Cd_municipio_empresa = string.Empty;
            Cnpj_empresa = string.Empty;
            Insc_municipal_empresa = string.Empty;
            Tp_regimetributario = string.Empty;
            Path_nfe_schemas = string.Empty;
            Nr_certificado_nfe = string.Empty;
            tp_ambiente = string.Empty;
            tipo_ambiente = string.Empty;
            tp_ambiente_nfes = string.Empty;
            tipo_ambiente_nfes = string.Empty;
            tp_ambiente_nfce = string.Empty;
            tipo_ambiente_nfce = string.Empty;
            tp_ambiente_lmc = string.Empty;
            tipo_ambiente_lmc = string.Empty;
            Cd_versao = string.Empty;
            Horascancnfe = decimal.Zero;
            Id_entidadenfes = decimal.Zero;
            Nr_diasexpirarcert = decimal.Zero;
            st_enviaremailcontador = "N";
            st_enviaremailcontadorbool = false;
            Dt_avisoCert = null;
            Dt_contingencia = null;
            Ds_condusoCCe = string.Empty;
            Cd_versaocondest = string.Empty;
            Cd_versaoLMC = string.Empty;
            tp_ambientecont = string.Empty;
            tipo_ambientecont = string.Empty;
            St_nfecontingencia = false;
            Vl_limitenfce = decimal.Zero;
            Vl_limitenfcenaoident = decimal.Zero;
            Nr_csc = string.Empty;
            Id_tokencsc = string.Empty;
            Cd_versaonfce = string.Empty;
            Url_nfce = string.Empty;
            Url_chavenfce = string.Empty;
        }
    }

    public class TCD_CfgNfe : TDataQuery
    {
        public TCD_CfgNfe()
        { }

        public TCD_CfgNfe(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, b.NM_Empresa, a.st_enviaremailcontador, ");
                sql.AppendLine("a.Path_NFE_Schemas, c.cd_cidade, a.nr_diasexpirarcert, a.dt_avisocert, ");
                sql.AppendLine("a.NR_Certificado_NFE, a.tp_ambiente, c.cd_uf, d.nr_cgc, a.tp_ambiente_lmc, ");
                sql.AppendLine("a.cd_versao, a.horascancnfe, a.tp_ambientecont, a.tp_ambiente_nfce, ");
                sql.AppendLine("a.tp_ambiente_nfes, a.id_entidadenfes, b.insc_municipal, b.TP_RegimeTributario, ");
                sql.AppendLine("a.ds_condusoCCe, a.cd_versaoevento, a.cd_versaocondest, e.NR_CGC as CNPJ_Contador, ");
                sql.AppendLine("a.vl_limitenfce, a.vl_limitenfcenaoident, a.nr_csc, a.cd_versaonfce, ");
                sql.AppendLine("a.id_tokencsc, a.url_nfce, a.url_chavenfce, a.cd_versaoLMC ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_CFGNfe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_Clifor d ");
            sql.AppendLine("on b.cd_clifor = d.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = c.cd_endereco ");
            sql.AppendLine("left outer join VTB_FIN_Clifor e ");
            sql.AppendLine("on b.CD_Escritorio_Contabil = e.cd_clifor ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CfgNfe Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CfgNfe lista = new TList_CfgNfe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CfgNfe reg = new TRegistro_CfgNfe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF")))
                        reg.Cd_uf_empresa = reader.GetString(reader.GetOrdinal("CD_UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade")))
                        reg.Cd_municipio_empresa = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj_empresa = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Municipal")))
                        reg.Insc_municipal_empresa = reader.GetString(reader.GetOrdinal("Insc_Municipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_RegimeTributario")))
                        reg.Tp_regimetributario = reader.GetString(reader.GetOrdinal("TP_RegimeTributario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CNPJ_Contador")))
                        reg.Cnpj_contador = reader.GetString(reader.GetOrdinal("CNPJ_Contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Path_NFE_Schemas")))
                        reg.Path_nfe_schemas = reader.GetString(reader.GetOrdinal("Path_NFE_Schemas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Certificado_NFE")))
                        reg.Nr_certificado_nfe = reader.GetString(reader.GetOrdinal("NR_Certificado_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("TP_Ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Ambiente_NFES")))
                        reg.Tp_ambiente_nfes = reader.GetString(reader.GetOrdinal("TP_Ambiente_NFES"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Versao")))
                        reg.Cd_versao = reader.GetString(reader.GetOrdinal("CD_Versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HorasCancNfe")))
                        reg.Horascancnfe = reader.GetDecimal(reader.GetOrdinal("HorasCancNfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_EntidadeNFES")))
                        reg.Id_entidadenfes = reader.GetDecimal(reader.GetOrdinal("ID_EntidadeNFES"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasexpirarcert")))
                        reg.Nr_diasexpirarcert = reader.GetDecimal(reader.GetOrdinal("nr_diasexpirarcert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_enviaremailcontador")))
                        reg.St_enviaremailcontador = reader.GetString(reader.GetOrdinal("st_enviaremailcontador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_avisocert")))
                        reg.Dt_avisoCert = reader.GetDateTime(reader.GetOrdinal("dt_avisocert"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condusoCCe")))
                        reg.Ds_condusoCCe = reader.GetString(reader.GetOrdinal("ds_condusoCCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaoevento")))
                        reg.Cd_versaoEvento = reader.GetString(reader.GetOrdinal("cd_versaoevento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaocondest")))
                        reg.Cd_versaocondest = reader.GetString(reader.GetOrdinal("cd_versaocondest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambientecont")))
                        reg.Tp_ambientecont = reader.GetString(reader.GetOrdinal("tp_ambientecont"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente_nfce")))
                        reg.Tp_ambiente_nfce = reader.GetString(reader.GetOrdinal("tp_ambiente_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitenfce")))
                        reg.Vl_limitenfce = reader.GetDecimal(reader.GetOrdinal("vl_limitenfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_limitenfcenaoident")))
                        reg.Vl_limitenfcenaoident = reader.GetDecimal(reader.GetOrdinal("vl_limitenfcenaoident"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_csc")))
                        reg.Nr_csc = reader.GetString(reader.GetOrdinal("nr_csc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tokencsc")))
                        reg.Id_tokencsc = reader.GetString(reader.GetOrdinal("id_tokencsc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaonfce")))
                        reg.Cd_versaonfce = reader.GetString(reader.GetOrdinal("cd_versaonfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("url_nfce")))
                        reg.Url_nfce = reader.GetString(reader.GetOrdinal("url_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("url_chavenfce")))
                        reg.Url_chavenfce = reader.GetString(reader.GetOrdinal("url_chavenfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente_lmc")))
                        reg.Tp_ambiente_lmc = reader.GetString(reader.GetOrdinal("tp_ambiente_lmc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaoLMC")))
                        reg.Cd_versaoLMC = reader.GetString(reader.GetOrdinal("cd_versaoLMC"));

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
        
        public string Gravar(TRegistro_CfgNfe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(25);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_PATH_NFE_SCHEMAS", val.Path_nfe_schemas);
            hs.Add("@P_NR_CERTIFICADO_NFE", val.Nr_certificado_nfe);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_TP_AMBIENTE_NFES", val.Tp_ambiente_nfes);
            hs.Add("@P_CD_VERSAO", val.Cd_versao);
            hs.Add("@P_HORASCANCNFE", val.Horascancnfe);
            hs.Add("@P_ID_ENTIDADENFES", val.Id_entidadenfes);
            hs.Add("@P_NR_DIASEXPIRARCERT", val.Nr_diasexpirarcert);
            hs.Add("@P_ST_ENVIAREMAILCONTADOR", val.St_enviaremailcontador);
            hs.Add("@P_DT_AVISOCERT", val.Dt_avisoCert);
            hs.Add("@P_DS_CONDUSOCCE", val.Ds_condusoCCe);
            hs.Add("@P_CD_VERSAOEVENTO", val.Cd_versaoEvento);
            hs.Add("@P_CD_VERSAOCONDEST", val.Cd_versaocondest);
            hs.Add("@P_TP_AMBIENTECONT", val.Tp_ambientecont);
            hs.Add("@P_TP_AMBIENTE_NFCE", val.Tp_ambiente_nfce);
            hs.Add("@P_VL_LIMITENFCE", val.Vl_limitenfce);
            hs.Add("@P_VL_LIMITENFCENAOIDENT", val.Vl_limitenfcenaoident);
            hs.Add("@P_NR_CSC", val.Nr_csc);
            hs.Add("@P_ID_TOKENCSC", val.Id_tokencsc);
            hs.Add("@P_CD_VERSAONFCE", val.Cd_versaonfce);
            hs.Add("@P_URL_NFCE", val.Url_nfce);
            hs.Add("@P_URL_CHAVENFCE", val.Url_chavenfce);
            hs.Add("@P_TP_AMBIENTE_LMC", val.Tp_ambiente_lmc);
            hs.Add("@P_CD_VERSAOLMC", val.Cd_versaoLMC);

            return executarProc("IA_FAT_CFGNFE", hs);
        }
        
        public string Excluir(TRegistro_CfgNfe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FAT_CFGNFE", hs);
        }
    }
}
