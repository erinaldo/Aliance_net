/*
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
    public class TList_CadCompromisso : List<TRegistro_CadCompromisso>
    {

    }
    public class TRegistro_CadCompromisso
    {
        private decimal? id_Compromisso;
        public decimal? Id_Compromisso
        {
            get
            {
                if (id_Compromisso == 0)
                {
                    return null;
                }
                else
                {
                    return id_Compromisso;
                }

            }
            set
            {
                id_Compromisso = value;
                _ID_Compromisso_String = value.ToString();

            }
        }

        private string _ID_Compromisso_String;
        public string ID_Compromisso_String
        {
            get { return _ID_Compromisso_String; }
            set
            {
                _ID_Compromisso_String = value;
                try
                { id_Compromisso = Convert.ToDecimal(value); }
                catch
                {
                    id_Compromisso = null;
                }

            }
        }

        private string nm_Compromisso;
        public string Nm_Compromisso
        {
            get { return nm_Compromisso; }
            set { nm_Compromisso = value;}
        }

        private string ds_Compromisso;
        public string Ds_Compromisso
        {
            get { return ds_Compromisso; }
            set { ds_Compromisso = value; }
        }

        private DateTime? dt_Compromisso;
        public DateTime? Dt_Compromisso
        {
            get { return dt_Compromisso; }
            set
            {
                dt_Compromisso = value;
                dtCompromisso = value.ToString();
            }
        }

        private string dtCompromisso;
        public string DtCompromisso
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dtCompromisso).ToString("dd/MM/yyyy");
                }
                catch
                {
                    return "";
                }

            }
            set
            {
                dtCompromisso = value;
                try
                {
                    dt_Compromisso = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_Compromisso = null;
                }
            }
        }

        private string usuarioCompromisso;
        public string UsuarioCompromisso 
        {
            get { return usuarioCompromisso;}
            set { usuarioCompromisso = value;}
        }

        private bool st_Compromisso;
        public bool St_Compromisso
        {
            get { return st_Compromisso; }
            set { st_Compromisso = value; }
        }




        public TRegistro_CadCompromisso()
        {
            id_Compromisso = null;
            nm_Compromisso = string.Empty;
            ds_Compromisso = string.Empty;
            dt_Compromisso = new DateTime();
            usuarioCompromisso = string.Empty;
            st_Compromisso = false;
        }
    }
    public class TCD_CadCompromisso : TDataQuery
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
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "and";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.sqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.sqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadCompromisso Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCompromisso lista = new TList_CadCompromisso();
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
                    TRegistro_CadCompromisso reg = new TRegistro_CadCompromisso();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_Compromisso")))
                        reg.Id_Compromisso = reader.GetDecimal(reader.GetOrdinal("id_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_Compromisso")))
                        reg.Nm_Compromisso = reader.GetString(reader.GetOrdinal("nm_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Compromisso")))
                        reg.Ds_Compromisso = reader.GetString(reader.GetOrdinal("ds_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_Compromisso")))
                        reg.Dt_Compromisso = reader.GetDateTime(reader.GetOrdinal("dt_Compromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("usuarioCompromisso")))
                        reg.UsuarioCompromisso = reader.GetString(reader.GetOrdinal("usuarioCompromisso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_Compromisso")))
                        reg.St_Compromisso = (reader.GetString(reader.GetOrdinal("st_Compromisso")) == "A");
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

        public string Grava(TRegistro_CadCompromisso vRegitro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_FERIADO", vRegitro.Id_Compromisso);
            hs.Add("@P_DS_FERIADO", vRegitro.Ds_Compromisso);
            hs.Add("@P_DT_FERIADO", vRegitro.Dt_Compromisso);
            if (vRegitro.St_Compromisso)
                hs.Add("@P_ST_REPETEANUAL", "S");
            else
                hs.Add("@P_ST_REPETEANUAL", "N");


            return this.executarProc("IA_DIV_FERIADO", hs);
        }

        public string Deleta(TRegistro_CadFeriado vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_FERIADO", vRegistro.Id_Feriado);
            return this.executarProc("EXCLUI_DIV_FERIADO", hs);
        }

    }



}*/