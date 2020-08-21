/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using Querys;
using Utils;
using System.Linq;

namespace CamadaDados.Consulta.Cadastro
{
    public class TList_Cad_Param : List<TRegistro_Cad_Param> { }

    public class TRegistro_Cad_Param
    {
        public decimal ID_ParamClasse { get; set; }
        public decimal ID_Consulta { get; set; }
        
        public TRegistro_Cad_Param()
        {
            this.ID_ParamClasse = 0;
            this.ID_Consulta = 0;
        }
    }

    public class TCD_Cad_Param : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("select " + strTop + " a.ID_ParamClasse, a.ID_Consulta ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CON_Param a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_Param Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_Param lista = new TList_Cad_Param();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_Param reg = new TRegistro_Cad_Param();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_ParamClasse"))))
                        reg.ID_ParamClasse = reader.GetDecimal(reader.GetOrdinal("ID_ParamClasse"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Consulta"))))
                        reg.ID_Consulta = reader.GetDecimal(reader.GetOrdinal("ID_Consulta"));
                    
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

        public string GravarParam(TRegistro_Cad_Param val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PARAMCLASSE", val.ID_ParamClasse);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            return this.executarProc("IA_CON_PARAM", hs);
        }

        public string DeletarParam(TRegistro_Cad_Param val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PARAMCLASSE", val.ID_ParamClasse);
            hs.Add("@P_ID_CONSULTA", val.ID_Consulta);
            return this.executarProc("EXCLUI_CON_PARAM", hs);
        }
    }
}
