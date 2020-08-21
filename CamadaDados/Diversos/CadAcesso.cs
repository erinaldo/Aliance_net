using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Diversos
{
    public class TList_CadAcesso : List<TRegistro_CadAcesso>
    { }

    
    public class TRegistro_CadAcesso
    {
        
        public string Login { get; set; }
        
        public string Id_menu { get; set; }
        
        public string Ds_menu { get; set; }
        private string inclui;
        
        public string Inclui 
        {
            get { return inclui; }
            set
            {
                inclui = value;
                incluibool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool incluibool;
        
        public bool Incluibool
        {
            get { return incluibool; }
            set
            {
                incluibool = value;
                if (value)
                    inclui = "S";
                else
                    inclui = "N";
            }
        }
        private string altera;
        
        public string Altera 
        {
            get { return altera; }
            set
            {
                altera = value;
                alterabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool alterabool;
        
        public bool Alterabool
        {
            get
            {
                return alterabool;
            }
            set
            {
                alterabool = value;
                if (value)
                    altera = "S";
                else
                    altera = "N";
            }
        }
        private string exclui;
        
        public string Exclui 
        {
            get { return exclui; }
            set
            {
                exclui = value;
                excluibool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool excluibool;
        
        public bool Excluibool
        {
            get { return excluibool; }
            set
            {
                excluibool = value;
                if (value)
                    exclui = "S";
                else
                    exclui = "N";
            }
        }
        
        public decimal Qtd_acesso { get; set; }

        public TRegistro_CadAcesso()
        {
            this.Login = string.Empty;
            this.Id_menu = string.Empty;
            this.Ds_menu = string.Empty;
            this.inclui = "N";
            this.incluibool = false;
            this.altera = "N";
            this.alterabool = false;
            this.exclui = "N";
            this.excluibool = false;
            this.Qtd_acesso = 0;
        }
    }

    public class TCD_CadAcesso : TDataQuery
    {
        public TCD_CadAcesso()
        { }

        public TCD_CadAcesso(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public DataTable BuscarAcessoRecursivoDeletar(string vId_menu, string vLogin)
        {
            string sql = "with relatorio (id_menu) as " +
                         "( " +
                         "select a.id_menu from tb_div_menu a " +
                         "where a.id_menu = '" + vId_menu + "' " +
                         "and exists(select 1 from tb_div_acesso b " +
                         "where b.id_menu = a.id_menu " +
                         "and b.login = '" + vLogin + "') " +
                         "union all " +
                         "select a.id_menu from tb_div_menu a " +
                         "inner join relatorio c " +
                         "on a.id_menuraiz = c.id_menu " +
                         "where exists(select 1 from tb_div_acesso b " +
                         "where b.id_menu = a.id_menu " +
                         "and b.login = '" + vLogin + "') " +
                         ") " +
                         "select * from relatorio ";
            return this.ExecutarBusca(sql.Trim(), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.Login, b.Nome_usuario, a.ID_Menu, a.qtd_acesso, ");
                sql.AppendLine("space(c.nivel * 5) + c.DS_Menu as DS_Menu, a.inclui, a.altera, a.exclui");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Acesso a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("On b.login = a.login ");
            sql.AppendLine("inner join TB_DIV_Menu c ");
            sql.AppendLine("On c.ID_Menu = a.ID_Menu");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine(" order by " + vOrder);
            return sql.ToString();
        }

        public TList_CadAcesso Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_CadAcesso lista = new TList_CadAcesso();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));

                while (reader.Read())
                {
                    TRegistro_CadAcesso reg = new TRegistro_CadAcesso();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Menu"))))
                        reg.Id_menu = reader.GetString(reader.GetOrdinal("Id_Menu"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Menu")))
                        reg.Ds_menu = reader.GetString(reader.GetOrdinal("DS_Menu"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Inclui"))))
                        reg.Inclui = reader.GetString(reader.GetOrdinal("Inclui"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Altera"))))
                        reg.Altera = reader.GetString(reader.GetOrdinal("Altera"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Exclui"))))
                        reg.Exclui = reader.GetString(reader.GetOrdinal("Exclui"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("qtd_acesso"))))
                        reg.Qtd_acesso = reader.GetDecimal(reader.GetOrdinal("qtd_acesso"));
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

        public string GravarAcesso(TRegistro_CadAcesso val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_MENU", val.Id_menu);
            hs.Add("@P_INCLUI", val.Inclui);
            hs.Add("@P_ALTERA", val.Altera);
            hs.Add("@P_EXCLUI", val.Exclui);
            hs.Add("@P_QTD_ACESSO", val.Qtd_acesso);
            return executarProc("IA_DIV_ACESSO", hs);
        }

        public string DeletarAcesso(TRegistro_CadAcesso val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_MENU", val.Id_menu);
            return this.executarProc("EXCLUI_DIV_ACESSO", hs);
        }
    }
}
