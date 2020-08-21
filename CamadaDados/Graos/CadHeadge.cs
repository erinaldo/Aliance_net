using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Graos
{

    public class TList_CadHeadge : List<TRegistro_CadHeadge> { }

    public class TRegistro_CadHeadge
    {
        private decimal? id_Headge;
        public decimal? ID_Headge
        {
            get { return id_Headge; }
            set
            {
                id_Headge = value;
                id_Headgestr = value.ToString();
            }
        }
        private string id_Headgestr;
        public string ID_Headgestr
        {
            get { return id_Headgestr; }
            set
            {
                id_Headgestr = value;
                try
                {
                    id_Headge = Convert.ToDecimal(value);
                }
                catch
                { id_Headge = null; }
            }
        }
        public string Ds_Headge { get; set; }
        public string Tp_Headge { get; set; }

        public TRegistro_CadHeadge()
        {
            this.ID_Headgestr = "";
            this.Ds_Headge = "";            
            this.Tp_Headge = "";
        }
    }

    public class TCD_CadHeadge : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.Id_Headge, a.ds_Headge, a.Tp_Headge ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_Headge a ");
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.ds_Headge");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadHeadge Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadHeadge lista = new TList_CadHeadge();
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
                    TRegistro_CadHeadge reg = new TRegistro_CadHeadge();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Headge")))
                        reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("Id_Headge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_Headge")))
                        reg.Ds_Headge = reader.GetString(reader.GetOrdinal("ds_Headge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Headge")))
                        reg.Tp_Headge = reader.GetString(reader.GetOrdinal("Tp_Headge"));
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

        public string Grava(TRegistro_CadHeadge vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
            hs.Add("@P_DS_HEADGE", vRegistro.Ds_Headge);            
            hs.Add("@P_TP_HEADGE", vRegistro.Tp_Headge);
            return this.executarProc("IA_GRO_HEADGE", hs);
        }

        public string Deleta(TRegistro_CadHeadge vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
            return this.executarProc("EXCLUI_GRO_HEADGE", hs);
        }

    }
}