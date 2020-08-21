using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Diversos
{
    public class TList_CadParamSys : List<TRegistro_CadParamSys>
    { }

    public class TRegistro_CadParamSys
    {
        public string Nm_campo 
        { get; set; }
        private string st_auto;
        public string St_auto 
        {
            get { return st_auto; }
            set
            {
                st_auto = value;
                st_autobool = value.Trim().ToUpper().Equals("1");
            }
        }
        private bool st_autobool;
        public bool St_autobool
        {
            get { return st_autobool; }
            set
            {
                st_autobool = value;
                if (value)
                    st_auto = "1";
                else
                    st_auto = "0";
            }
        }
        public decimal Tamanho { get; set; }

        public TRegistro_CadParamSys()
        {
            Nm_campo = string.Empty;
            st_auto = "0";
            st_autobool = false;
            Tamanho = 0;
        }
    }

    public class TCD_CadParamSys : TDataQuery
    {
        public TCD_CadParamSys()
        { }

        public TCD_CadParamSys(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

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
            {
                strTop = "TOP " + Convert.ToString(vTop);
            };
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select NM_Campo, Tamanho, ST_Auto ");
            }
            else
            {
                sql.AppendLine("Select " + vNM_Campo + " ");
            };
            sql.AppendLine("FROM TB_DIV_ParamSys a");
            cond = " WHERE ";
            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            sql.Append("Order By nm_campo asc");
            return sql.ToString();
        }

        public TList_CadParamSys Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadParamSys lista = new TList_CadParamSys();
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
                    TRegistro_CadParamSys reg = new TRegistro_CadParamSys();
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Campo"))))
                        reg.Nm_campo = reader.GetString(reader.GetOrdinal("NM_Campo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Auto"))))
                        reg.St_auto = reader.GetString(reader.GetOrdinal("ST_Auto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tamanho"))))
                        reg.Tamanho = reader.GetDecimal(reader.GetOrdinal("Tamanho"));
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

        public string gravarParam(TRegistro_CadParamSys val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NM_CAMPO", val.Nm_campo);
            hs.Add("@P_ST_AUTO", val.St_auto);
            hs.Add("@P_TAMANHO", val.Tamanho);
            return executarProc("IA_DIV_PARAMSYS", hs);
        }

        public string deletarParam(TRegistro_CadParamSys val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_NM_CAMPO", val.Nm_campo);
            return executarProc("EXCLUI_DIV_PARAMSYS", hs);
        }
    }
}
