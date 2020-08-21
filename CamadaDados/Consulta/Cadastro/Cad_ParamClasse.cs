using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_ParamClasse : List<TRegistro_Cad_ParamClasse> { }

    public class TRegistro_Cad_ParamClasse
    {
        public decimal ID_ParamClasse { get; set; }
        public string NM_Param { get; set; }
        public string NM_CampoFormat { get; set; }
        public string NM_Classe { get; set; }
        public string CondicaoBusca { get; set; }
        public string CodigoCMP { get; set; }
        public string NomeCMP { get; set; }
        public string NM_DLL { get; set; }
        public string TP_Dado { get; set; }
        public string RadioCheckGroup { get; set; }
        private string st_Obrigatorio;
        public string St_Obrigatorio
        {
            get { return st_Obrigatorio; }
            set
            {
                st_Obrigatorio = value;
                if (value.Trim().ToUpper().Equals("S"))
                {
                    status_Obrigatorio = "SIM";
                    st_ObrigatorioBool = true;
                }
                else if (value.Trim().ToUpper().Equals("N"))
                {
                    status_Obrigatorio = "NAO";
                    st_ObrigatorioBool = false;
                }
            }
        }
        private bool st_ObrigatorioBool;
        public bool St_ObrigatorioBool
        {
            get { return st_ObrigatorioBool; }
            set
            {
                st_ObrigatorioBool = value;
                if (value)
                {
                    status_Obrigatorio = "SIM";
                    st_Obrigatorio = "S";
                }
                else
                {
                    status_Obrigatorio = "NAO";
                    st_Obrigatorio = "N";
                }
            }
        }

        private string status_Obrigatorio;
        public string Status_Obrigatorio
        {
            get { return status_Obrigatorio; }
            set
            {
                status_Obrigatorio = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                {
                    st_Obrigatorio = "S";
                    st_ObrigatorioBool = true;
                }
                else if (value.Trim().ToUpper().Equals("NAO"))
                {
                    st_Obrigatorio = "N";
                    st_ObrigatorioBool = false;
                }
            }
        }

        private string st_Null;
        public string St_Null
        {
            get { return st_Null; }
            set
            {
                st_Null = value;
                if (value.Trim().ToUpper().Equals("S"))
                {
                    status_Null = "SIM";
                    st_NullBool = true;
                }
                else if (value.Trim().ToUpper().Equals("N"))
                {
                    status_Null = "NAO";
                    st_NullBool = false;
                }
            }
        }
        private bool st_NullBool;
        public bool St_NullBool
        {
            get { return st_NullBool; }
            set
            {
                st_NullBool = value;
                if (value)
                {
                    status_Null = "SIM";
                    st_Null = "S";
                }
                else
                {
                    status_Null = "NAO";
                    st_Null = "N";
                }
            }
        }

        private string status_Null;
        public string Status_Null
        {
            get { return status_Null; }
            set
            {
                status_Null = value;
                if (value.Trim().ToUpper().Equals("SIM"))
                {
                    st_Null = "S";
                    st_NullBool = true;
                }
                else if (value.Trim().ToUpper().Equals("NAO"))
                {
                    st_Null = "N";
                    st_NullBool = false;
                }
            }
        }
        
        public TRegistro_Cad_ParamClasse()
        {
            ID_ParamClasse = 0;
            NM_Param = string.Empty;
            NM_CampoFormat = string.Empty;
            NM_Classe = string.Empty;
            CondicaoBusca = string.Empty;
            CodigoCMP = string.Empty;
            NomeCMP = string.Empty;
            TP_Dado = string.Empty;
            NM_DLL = string.Empty;
            RadioCheckGroup = string.Empty;
        }
    }

    public class TCD_Cad_ParamClasse : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_ParamClasse, a.NM_ParamCaption as NM_Param, a.NM_CampoFormat, a.NM_Classe, a.TP_Dado, a.CondicaoBusca, a.CodigoCMP, a.NomeCmp, ");
                sql.AppendLine(" a.NM_DLL, a.RadioCheckGroup, isnull(a.ST_Obrigatorio,'N') as ST_Obrigatorio, isnull(a.ST_Null,'N') as  ST_Null ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CON_ParamClasse a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.ID_ParamClasse ASC");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_ParamClasse Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_ParamClasse lista = new TList_Cad_ParamClasse();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_ParamClasse reg = new TRegistro_Cad_ParamClasse();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_ParamClasse"))))
                        reg.ID_ParamClasse = reader.GetDecimal(reader.GetOrdinal("ID_ParamClasse"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Param"))))
                        reg.NM_Param = reader.GetString(reader.GetOrdinal("NM_Param"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_CampoFormat"))))
                        reg.NM_CampoFormat = reader.GetString(reader.GetOrdinal("NM_CampoFormat"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Classe"))))
                        reg.NM_Classe = reader.GetString(reader.GetOrdinal("NM_Classe"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CondicaoBusca"))))
                        reg.CondicaoBusca = reader.GetString(reader.GetOrdinal("CondicaoBusca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CodigoCMP"))))
                        reg.CodigoCMP = reader.GetString(reader.GetOrdinal("CodigoCMP"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NomeCMP"))))
                        reg.NomeCMP = reader.GetString(reader.GetOrdinal("NomeCMP"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Dado"))))
                        reg.TP_Dado = reader.GetString(reader.GetOrdinal("TP_Dado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_DLL"))))
                        reg.NM_DLL = reader.GetString(reader.GetOrdinal("NM_DLL"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("RadioCheckGroup"))))
                        reg.RadioCheckGroup = reader.GetString(reader.GetOrdinal("RadioCheckGroup"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Obrigatorio"))))
                        reg.St_Obrigatorio = reader.GetString(reader.GetOrdinal("ST_Obrigatorio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Null"))))
                        reg.St_Null = reader.GetString(reader.GetOrdinal("ST_Null"));

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

        public string GravarParamClasse(TRegistro_Cad_ParamClasse val)
        {
            Hashtable hs = new Hashtable(11);
            hs.Add("@P_ID_PARAMCLASSE", val.ID_ParamClasse);
            hs.Add("@P_NM_PARAM", val.NM_Param);
            hs.Add("@P_NM_CAMPOFORMAT", val.NM_CampoFormat);
            hs.Add("@P_NM_CLASSE", val.NM_Classe);
            hs.Add("@P_NM_DLL", val.NM_DLL);
            hs.Add("@P_CONDICAO_BUSCA", val.CondicaoBusca);
            hs.Add("@P_CODIGOCMP", val.CodigoCMP);
            hs.Add("@P_NOMECMP", val.NomeCMP);
            hs.Add("@P_TP_DADO", val.TP_Dado);
            hs.Add("@P_RADIOCHECKGROUP", val.RadioCheckGroup);
            hs.Add("@P_ST_OBRIGATORIO", val.St_Obrigatorio);
            hs.Add("@P_ST_NULL", val.St_Null);
            return executarProc("IA_CON_PARAMCLASSE", hs);
        }

        public string DeletarParamClasse(TRegistro_Cad_ParamClasse val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NM_CAMPOFORMAT", val.NM_CampoFormat);
            return executarProc("EXCLUI_CON_PARAMCLASSE", hs);
        }
    }
}

