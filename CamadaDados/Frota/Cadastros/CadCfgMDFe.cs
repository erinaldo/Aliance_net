using CamadaDados.Diversos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_CfgMDFe : List<TRegistro_CfgMDFe> { }

    public class TRegistro_CfgMDFe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Path_schemas
        { get; set; }
        public string Nr_certificado
        { get; set; }
        private string tp_ambiente;
        public string Tp_ambiente
        {
            get { return tp_ambiente; }
            set
            {
                tp_ambiente = value;
                if (value.Trim().Equals("1"))
                    tipo_ambiente = "PRODUÇÃO";
                else if (value.Trim().Equals("2"))
                    tipo_ambiente = "HOMOLOGAÇÃO";
            }
        }
        private string tipo_ambiente;
        public string Tipo_ambiente
        {
            get { return tipo_ambiente; }
            set
            {
                tipo_ambiente = value;
                if (value.Trim().ToUpper().Equals("PRODUÇÃO"))
                    tp_ambiente = "1";
                else if (value.Trim().ToUpper().Equals("HOMOLOGAÇÃO"))
                    tp_ambiente = "2";
            }
        }
        public string Cd_versaomdfe
        { get; set; }
        public string Cd_versaomodal
        { get; set; }
        public TRegistro_CadEmpresa rEmp
        { get; set; }
        public string Cnpj_contador { get; set; } = string.Empty;

        public TRegistro_CfgMDFe()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Path_schemas = string.Empty;
            Nr_certificado = string.Empty;
            tp_ambiente = string.Empty;
            tipo_ambiente = string.Empty;
            Cd_versaomdfe = string.Empty;
            Cd_versaomodal = string.Empty;
            rEmp = new TRegistro_CadEmpresa();
        }
    }

    public class TCD_CfgMDFe : TDataQuery
    {
        public TCD_CfgMDFe() { }

        public TCD_CfgMDFe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.path_schemas, a.nr_certificado, a.tp_ambiente, ");
                sql.AppendLine("a.cd_versaomdfe, a.cd_versaomodal, c.nr_cgc, d.cd_uf, d.uf, ");
                sql.AppendLine("d.insc_estadual, c.nm_clifor, c.nm_fantasia, ");
                sql.AppendLine("d.ds_endereco, d.numero, d.ds_complemento, d.bairro, ");
                sql.AppendLine("d.cd_cidade, d.ds_cidade, d.cep, d.fone, c.email, ");
                sql.AppendLine("e.nr_cgc as Cnpj_contador ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_CfgMDFe a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco d ");
            sql.AppendLine("on b.cd_clifor = d.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = d.cd_endereco ");
            sql.AppendLine("left outer join VTB_FIN_Clifor e ");
            sql.AppendLine("on b.Cd_escritorio_contabil = e.cd_clifor ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CfgMDFe Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgMDFe lista = new TList_CfgMDFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CfgMDFe reg = new TRegistro_CfgMDFe();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                    {
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        reg.rEmp.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                    {
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                        reg.rEmp.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("path_schemas")))
                        reg.Path_schemas = reader.GetString(reader.GetOrdinal("path_schemas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_certificado")))
                        reg.Nr_certificado = reader.GetString(reader.GetOrdinal("nr_certificado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaomdfe")))
                        reg.Cd_versaomdfe = reader.GetString(reader.GetOrdinal("cd_versaomdfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_versaomodal")))
                        reg.Cd_versaomodal = reader.GetString(reader.GetOrdinal("cd_versaomodal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.rEmp.rClifor.Nr_cgc = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.rEmp.rClifor.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fantasia")))
                        reg.rEmp.rClifor.Nm_fantasia = reader.GetString(reader.GetOrdinal("nm_fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        reg.rEmp.rClifor.Email = reader.GetString(reader.GetOrdinal("email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.rEmp.rEndereco.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.rEmp.rEndereco.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.rEmp.rEndereco.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.rEmp.rEndereco.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.rEmp.rEndereco.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.rEmp.rEndereco.DS_Cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        reg.rEmp.rEndereco.Cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.rEmp.rEndereco.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.rEmp.rEndereco.Cd_uf = reader.GetString(reader.GetOrdinal("cd_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.rEmp.rEndereco.UF = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.rEmp.rEndereco.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cnpj_contador")))
                        reg.Cnpj_contador = reader.GetString(reader.GetOrdinal("Cnpj_contador"));

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

        public string Gravar(TRegistro_CfgMDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_PATH_SCHEMAS", val.Path_schemas);
            hs.Add("@P_NR_CERTIFICADO", val.Nr_certificado);
            hs.Add("@P_TP_AMBIENTE", val.Tp_ambiente);
            hs.Add("@P_CD_VERSAOMDFE", val.Cd_versaomdfe);
            hs.Add("@P_CD_VERSAOMODAL", val.Cd_versaomodal);

            return executarProc("IA_FRT_CFGMDFE", hs);
        }

        public string Excluir(TRegistro_CfgMDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FRT_CFGMDFE", hs);
        }
    }
}
