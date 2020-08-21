using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_Terminal_X_Protocolo : List<TRegistro_Terminal_X_Protocolo>
    { }

    
    public class TRegistro_Terminal_X_Protocolo
    {
        
        public string Cd_terminal
        { get; set; }
        
        public string Ds_terminal
        { get; set; }
        
        public string Cd_protocolo
        { get; set; }
        
        public string Ds_protocolo
        { get; set; }

        public TRegistro_Terminal_X_Protocolo()
        {
            this.Cd_terminal = string.Empty;
            this.Ds_terminal = string.Empty;
            this.Cd_protocolo = string.Empty;
            this.Ds_protocolo = string.Empty;
        }
    }

    public class TCD_Terminal_X_Protocolo : TDataQuery
    {
        public TCD_Terminal_X_Protocolo()
        { }

        public TCD_Terminal_X_Protocolo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cd_terminal, b.ds_terminal, ");
                sql.AppendLine("a.cd_protocolo, c.ds_protocolo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Terminal_X_Protocolo a ");
            sql.AppendLine("inner join tb_div_terminal b ");
            sql.AppendLine("on a.cd_terminal = b.cd_terminal ");
            sql.AppendLine("inner join tb_div_protocolo c ");
            sql.AppendLine("on a.cd_protocolo = c.cd_protocolo ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Terminal_X_Protocolo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Terminal_X_Protocolo lista = new TList_Terminal_X_Protocolo();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Terminal_X_Protocolo reg = new TRegistro_Terminal_X_Protocolo();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Protocolo")))
                        reg.Cd_protocolo = reader.GetString(reader.GetOrdinal("CD_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Protocolo")))
                        reg.Ds_protocolo = reader.GetString(reader.GetOrdinal("DS_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Terminal")))
                        reg.Cd_terminal = reader.GetString(reader.GetOrdinal("CD_Terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Terminal")))
                        reg.Ds_terminal = reader.GetString(reader.GetOrdinal("DS_Terminal"));

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

        public string Gravar(TRegistro_Terminal_X_Protocolo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_TERMINAL", val.Cd_terminal);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);

            return this.executarProc("IA_DIV_TERMINAL_X_PROTOCOLO", hs);
        }

        public string Excluir(TRegistro_Terminal_X_Protocolo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_TERMINAL", val.Cd_terminal);
            hs.Add("@P_CD_PROTOCOLO", val.Cd_protocolo);

            return this.executarProc("EXCLUI_DIV_TERMINAL_X_PROTOCOLO", hs);
        }
    }
}
