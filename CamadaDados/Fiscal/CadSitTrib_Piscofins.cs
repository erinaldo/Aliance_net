using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace CamadaDados.Fiscal
{
    [DataContract]
    public class TRegistro_CadSitTrib_Piscofins 
    {
        [DataMember]
        public string Cd_sittrib { get; set; }
        [DataMember]
        public string Ds_sittrib { get; set; }

        public TRegistro_CadSitTrib_Piscofins()
        {
            this. Cd_sittrib = string.Empty;
            this.Ds_sittrib = string.Empty;
        }

    }

    public class TList_CadSitTrib_Piscofins : List<TRegistro_CadSitTrib_Piscofins>
    { }

    public class TCD_CadSitTrib_Piscofins : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, 0, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public string GravarCofins(TRegistro_CadSitTrib_Piscofins val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_SITTRIB", val.Cd_sittrib);
            hs.Add("@P_DS_SITTRIB", val.Ds_sittrib);
            return executarProc("IA_FIS_SITUACAOTRIB_PISCOFINS", hs);
        }

        public string DeletarCofins(TRegistro_CadSitTrib_Piscofins val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_SITTRIB", val.Cd_sittrib);
            return executarProc("EXCLUI_FIS_SITUACAOTRIB_PISCOFINS", hs);
        }

        public TList_CadSitTrib_Piscofins Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadSitTrib_Piscofins lista = new TList_CadSitTrib_Piscofins();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                if (vNm_Campo.Length > 0)
                        reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                    else
                        reader = this.ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSitTrib_Piscofins reg = new TRegistro_CadSitTrib_Piscofins();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_SitTrib"))))
                        reg.Cd_sittrib = reader.GetString(reader.GetOrdinal("CD_SitTrib"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_SitTrib"))))
                        reg.Ds_sittrib = reader.GetString(reader.GetOrdinal("DS_SitTrib"));
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

        public string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = ""; string strTop = "";
            int i;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " cd_sittrib, ds_sittrib ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fis_situacaotrib_piscofins");
            cond = " WHERE ";

            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                        if (vBusca[i].vVL_Busca != null)
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                            cond = " AND ";
                        }
            return sql.ToString();
        }
    }
}
