using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.ConfigGer
{
    public class TList_RegParamGer_X_Terminal : List<TRegistro_ParamGer_X_Terminal>
    { }

    
    public class TRegistro_ParamGer_X_Terminal
    {
        private int? id_parametro;
        
        public int? Id_parametro
        {
            get { return id_parametro; }
            set 
            { 
                id_parametro = value;
                id_parametrostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }

        private string id_parametrostr;
        
        public string Id_parametrostr
        {
            get 
            {
                return id_parametrostr; 
            }
            set
            {
                id_parametrostr = value;
                try
                {
                    id_parametro = Convert.ToInt32(value);
                }
                catch
                { id_parametro = null; }
            }
        }

        private string ds_parametro;
        
        public string Ds_parametro
        {
            get { return ds_parametro; }
            set { ds_parametro = value; }
        }

        private string cd_Terminal;
        
        public string Cd_Terminal
        {
            get { return cd_Terminal; }
            set { cd_Terminal = value; }
        }

        private string nm_Terminal;
        
        public string Nm_Terminal
        {
            get { return nm_Terminal; }
            set { nm_Terminal = value; }
        }

        public TRegistro_ParamGer_X_Terminal()
        {
            this.id_parametro = null;
            this.id_parametrostr = string.Empty;
            this.ds_parametro = string.Empty;
            this.cd_Terminal = string.Empty;
            this.nm_Terminal = string.Empty;
        }
    }

    public class TCD_ParamGer_X_Terminal : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
                       
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
                strTop = "   TOP     " + Convert.ToString(vTop);
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("  Select " + strTop + " a.ID_Parametro, b.DS_Parametro, ");
                sql.AppendLine("  a.CD_Terminal, c.DS_Terminal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("   From TB_CFG_ParamGer_X_Terminal a inner join TB_CFG_ParamGer b ");
            sql.AppendLine("  On b.ID_Parametro = a.ID_Parametro ");
            sql.AppendLine("  inner join TB_DIV_Terminal c ");
            sql.AppendLine("  On c.CD_Terminal = a.CD_Terminal ");
            cond = " where ";

            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_RegParamGer_X_Terminal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegParamGer_X_Terminal lista = new TList_RegParamGer_X_Terminal();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_ParamGer_X_Terminal CadParam = new TRegistro_ParamGer_X_Terminal();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Parametro")))
                        CadParam.Id_parametro = reader.GetInt32(reader.GetOrdinal("ID_Parametro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Parametro")))
                        CadParam.Ds_parametro = reader.GetString(reader.GetOrdinal("DS_Parametro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Terminal")))
                        CadParam.Cd_Terminal = reader.GetString(reader.GetOrdinal("CD_Terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Terminal")))
                        CadParam.Nm_Terminal = reader.GetString(reader.GetOrdinal("DS_Terminal"));
                    lista.Add(CadParam);
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

        public string GravarParamGer(TRegistro_ParamGer_X_Terminal val)
        {
            Hashtable hs = new Hashtable(2);

            hs.Add("@P_ID_PARAMETRO", val.Id_parametro);
            hs.Add("@P_CD_TERMINAL", val.Cd_Terminal);

            return executarProc("IA_CFG_PARAMGER_X_TERMINAL", hs);
        }

        public string DeletarParamGer(TRegistro_ParamGer_X_Terminal val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PARAMETRO", val.Id_parametro);
            hs.Add("@P_CD_TERMINAL", val.Cd_Terminal);

            return this.executarProc("EXCLUI_CFG_PARAMGER_X_TERMINAL", hs);
        }
    }
}
