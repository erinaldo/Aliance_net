using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.WS_RDC
{
    public class TList_Cad_ParamClasse : List<TRegistro_Cad_ParamClasse> { }

    public class TRegistro_Cad_ParamClasse
    {
        public string NM_Param { get; set; }
        public string NM_CampoFormat { get; set; }
        public string NM_Classe { get; set; }
        public string CondicaoBusca { get; set; }
        public string CodigoCMP { get; set; }
        public string NomeCMP { get; set; }
        public string NM_DLL { get; set; }
        public string TP_Dado { get; set; }
        public string RadioCheckGroup { get; set; }
        public string St_Obrigatorio { get; set; }
        public string St_Null { get; set; }
        
        public TRegistro_Cad_ParamClasse()
        {
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
            if (string.IsNullOrWhiteSpace(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NM_ParamCaption, a.NM_CampoFormat, a.NM_Classe, a.TP_Dado, a.CondicaoBusca, a.CodigoCMP, a.NomeCmp, ");
                sql.AppendLine(" a.NM_DLL, a.RadioCheckGroup, isnull(a.ST_Obrigatorio,'N') as ST_Obrigatorio, isnull(a.ST_Null,'N') as  ST_Null ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_BIN_ParamClasse a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("ORDER BY a.NM_ParamCaption ASC");
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

                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_ParamCaption"))))
                        reg.NM_Param = reader.GetString(reader.GetOrdinal("NM_ParamCaption"));
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
            return executarProc("IA_BIN_PARAMCLASSE", hs);
        }

        public string DeletarParamClasse(TRegistro_Cad_ParamClasse val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NM_PARAM", val.NM_CampoFormat);
            return executarProc("EXCLUI_BIN_PARAMCLASSE", hs);
        }
    }
}
