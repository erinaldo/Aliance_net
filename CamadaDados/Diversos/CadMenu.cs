using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Diversos
{
    public class TList_CadMenu : List<TRegistro_CadMenu>
    { }

    public class TRegistro_CadMenu
    {
        public string id_menu { get; set; }
        public string id_menuraiz { get; set; }
        public string ds_menu { get; set; }
        public string cd_modulo { get; set; }
        public string nm_modulo { get; set; }
        public decimal nivel { get; set; }
        public decimal ID_Report { get; set; }
        public string nm_classe { get; set; }
        public string tp_evento { get; set; }
    }

    public class TCD_CadMenu : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros); 
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.id_menu, id_menuRaiz, a.id_report, a.ds_menu, a.cd_modulo, a.nm_modulo, a.nivel, a.nm_classe, a.tp_evento");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_MENU a ");
            sql.AppendLine("WHERE ISNULL(a.ST_REGISTRO, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            if (vGroup.Trim() != string.Empty)
                sql.AppendLine("group by " + vGroup.Trim());
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }
                
        public TList_CadMenu Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_CadMenu lista = new TList_CadMenu();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), "", "", vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadMenu cadMenu = new TRegistro_CadMenu();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_menu")))
                        cadMenu.id_menu = reader.GetString(reader.GetOrdinal("id_menu")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_menuraiz")))
                        cadMenu.id_menuraiz = reader.GetString(reader.GetOrdinal("id_menuraiz")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_menu")))
                        cadMenu.ds_menu = reader.GetString(reader.GetOrdinal("ds_menu")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modulo")))
                        cadMenu.cd_modulo = reader.GetString(reader.GetOrdinal("cd_modulo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_modulo")))
                        cadMenu.nm_modulo = reader.GetString(reader.GetOrdinal("nm_modulo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        cadMenu.nivel = reader.GetDecimal((reader.GetOrdinal("nivel")));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_classe")))
                        cadMenu.nm_classe = reader.GetString(reader.GetOrdinal("nm_classe")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_evento")))
                        cadMenu.tp_evento = reader.GetString(reader.GetOrdinal("tp_evento")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Report")))
                        cadMenu.ID_Report = reader.GetDecimal((reader.GetOrdinal("ID_Report")));

                    lista.Add(cadMenu);
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

        public string GravarMenu(TRegistro_CadMenu val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_MENU", val.id_menu);
            hs.Add("@P_ID_MENURAIZ", val.id_menuraiz);
            if (val.ID_Report > 0)
                hs.Add("@P_ID_REPORT", val.ID_Report);
            hs.Add("@P_DS_MENU", val.ds_menu);
            hs.Add("@P_CD_MODULO", val.cd_modulo);
            hs.Add("@P_NM_MODULO", val.nm_modulo);
            hs.Add("@P_NIVEL", val.nivel);
            hs.Add("@P_NM_CLASSE", val.nm_classe);
            hs.Add("@P_TP_EVENTO", val.tp_evento);

            return executarProc("IA_DIV_MENU", hs);
        }

        public string DeletarMenu(TRegistro_CadMenu val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_MENU", val.id_menu);
            return this.executarProc("EXCLUI_DIV_MENU", hs);
        }

        public void DeletarTodoMenu()
        {
            StringBuilder sql = new StringBuilder();
            //sql.AppendLine("UPDATE TB_CON_REPORT SET ID_MENUBKP = ID_MENU ");
            //sql.AppendLine("UPDATE TB_CON_REPORT SET ID_MENU = NULL ");
            sql.AppendLine("DELETE TB_DIV_MENU ");
            sql.AppendLine("FROM TB_DIV_MENU A ");
            sql.AppendLine("WHERE NOT EXISTS(SELECT 1 FROM TB_DIV_ACESSO B where A.ID_MENU = B.ID_MENU) ");

            this.executarSql(sql.ToString(), new Hashtable(0));
        }

        /*public void VoltaBackupMenu()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TB_CON_REPORT SET ID_MENU = ID_MENUBKP ");

            this.executarSql(sql.ToString(), new Hashtable(0));
        }
        */
    }
}
