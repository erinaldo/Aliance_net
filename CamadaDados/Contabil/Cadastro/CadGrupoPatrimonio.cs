using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Contabil.Cadastro
{
    public class TList_CadGrupoPatrimonio : List<TRegistro_CadGrupoPatrimonio>
    { }

    public class TRegistro_CadGrupoPatrimonio
    {
        private decimal? _ID_GrupoPatrim;
        public decimal? ID_GrupoPatrim
        {
            get
            {
                if (_ID_GrupoPatrim == 0)
                    return null;
                else
                    return _ID_GrupoPatrim;
            }
            set
            {
                _ID_GrupoPatrim = value;
                _ID_GrupoPatrim_String = value.ToString();
            }
        }

        private string _ID_GrupoPatrim_String;
        public string ID_GrupoPatrim_String
        {
            get { return _ID_GrupoPatrim_String; }
            set
            {
                _ID_GrupoPatrim_String = value;
                try
                {
                    _ID_GrupoPatrim = Convert.ToDecimal(value);
                }
                catch { _ID_GrupoPatrim = null; }

            }
        }


        private string _DS_GrupoPatrim;
        public string DS_GrupoPatrim
        {
            get { return _DS_GrupoPatrim; }
            set { _DS_GrupoPatrim = value; }
        }
        

        public TRegistro_CadGrupoPatrimonio()
        {
            _ID_GrupoPatrim = null;
            _ID_GrupoPatrim_String = null;
            _DS_GrupoPatrim = string.Empty;

        }
    }

    public class TCD_CadGrupoPatrimonio : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop);
                sql.AppendLine(" a.id_GrupoPatrim, a.DS_GrupoPatrim ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM ");
            sql.AppendLine(" TB_CTB_GrupoPatrimonio a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadGrupoPatrimonio Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadGrupoPatrimonio lista = new TList_CadGrupoPatrimonio();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadGrupoPatrimonio reg = new TRegistro_CadGrupoPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_GrupoPatrim")))
                        reg.ID_GrupoPatrim = reader.GetDecimal(reader.GetOrdinal("ID_GrupoPatrim"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoPatrim")))
                        reg.DS_GrupoPatrim = reader.GetString(reader.GetOrdinal("DS_GrupoPatrim"));
                    
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

        public string Grava(TRegistro_CadGrupoPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_GRUPOPATRIM", vRegistro.ID_GrupoPatrim);
            hs.Add("@P_DS_GRUPOPATRIM", vRegistro.DS_GrupoPatrim);
           
            return this.executarProc("IA_CTB_GRUPOPATRIMONIO", hs);
        }

        public string Deleta(TRegistro_CadGrupoPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_GRUPOPATRIM", vRegistro.ID_GrupoPatrim);
            return this.executarProc("EXCLUI_CTB_GRUPOPATRIM", hs);
        }

    }
}
