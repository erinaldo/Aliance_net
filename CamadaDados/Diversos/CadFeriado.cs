using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Utils;
using System.Collections;

namespace CamadaDados.Diversos
{
    public class TList_CadFeriado : List<TRegistro_CadFeriado>
    {

    }
    public class TRegistro_CadFeriado
    {
        private decimal? id_Feriado;
        public decimal? Id_Feriado
        {
            get
            {
                if (id_Feriado == 0)
                {
                    return null;
                }
                else
                {
                    return id_Feriado;
                }

            }
            set
            {
                id_Feriado = value;
                _ID_Feriado_String = value.ToString();

            }
        }

        private string _ID_Feriado_String;  
        public string ID_Feriado_String
        {
            get { return _ID_Feriado_String; }
            set { _ID_Feriado_String = value;
            try
            { id_Feriado = Convert.ToDecimal(value);}
            catch
            {
                id_Feriado = null;
            }

            }
        }
            


        private string ds_Feriado;
        public string Ds_Feriado
        {
            get { return ds_Feriado; }
            set { ds_Feriado = value; }
        }

        private DateTime? dt_Feriado;
        public DateTime? Dt_Feriado
        {
            get { return dt_Feriado; }
            set { 
                dt_Feriado = value;
                dtFeriado = value.ToString();
                }
        }
                
        private string dtFeriado;
        public string DtFeriado
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dtFeriado).ToString("dd/MM/yyyy");
                }
                catch
                {
                    return "";
                }
                
            }
            set {
                dtFeriado = value;
                try
                {
                    dt_Feriado = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_Feriado = null;
                }
                }
        }

        private bool st_RepeteAnual;
        public bool St_RepeteAnual
        {
            get { return st_RepeteAnual; }
            set { st_RepeteAnual = value; }
        }

        public TRegistro_CadFeriado()
        {
            id_Feriado = 0;
            ds_Feriado = "";
            dt_Feriado = new DateTime();
            st_RepeteAnual = false;
        }
    }
    public class TCD_CadFeriado : TDataQuery
    {
        private string sqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.id_Feriado,a.ds_Feriado,a.dt_Feriado,a.st_RepeteAnual ");
            else
                sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo + "");

            sql.AppendLine("FROM tb_div_feriado a");

            string cond = "where";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length ); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "and";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, ""),null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.sqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadFeriado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadFeriado lista = new TList_CadFeriado();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.sqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadFeriado reg = new TRegistro_CadFeriado();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_Feriado")))
                        reg.Id_Feriado = reader.GetDecimal(reader.GetOrdinal("id_feriado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Feriado")))
                        reg.Ds_Feriado = reader.GetString(reader.GetOrdinal("ds_Feriado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_Feriado")))
                        reg.Dt_Feriado = reader.GetDateTime(reader.GetOrdinal("dt_Feriado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_RepeteAnual")))
                        reg.St_RepeteAnual = (reader.GetString(reader.GetOrdinal("st_RepeteAnual")) == "S");
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

        public string Grava(TRegistro_CadFeriado vRegitro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_FERIADO", vRegitro.Id_Feriado);
            hs.Add("@P_DS_FERIADO", vRegitro.Ds_Feriado);
            hs.Add("@P_DT_FERIADO", vRegitro.Dt_Feriado);
            if(vRegitro.St_RepeteAnual)
              hs.Add("@P_ST_REPETEANUAL", "S");
            else
             hs.Add("@P_ST_REPETEANUAL", "N");


            return this.executarProc("IA_DIV_FERIADO", hs);
        }

        public string Deleta(TRegistro_CadFeriado vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_FERIADO", vRegistro.Id_Feriado);
            return this.executarProc("EXCLUI_DIV_FERIADO",hs);
        }

    }
    


}
