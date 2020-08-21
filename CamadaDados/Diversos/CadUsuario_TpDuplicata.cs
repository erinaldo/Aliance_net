using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_Usuario_TpDuplicata : List<TRegistro_Usuario_TpDuplicata>
    { }

    
    public class TRegistro_Usuario_TpDuplicata
    {
        
        public string Login
        { get; set; }
        
        public string Tp_duplicata
        { get; set; }
        
        public string Ds_tpduplicata
        { get; set; }

        public TRegistro_Usuario_TpDuplicata()
        {
            this.Login = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
        }
    }

    public class TCD_Usuario_TpDuplicata : TDataQuery
    {
        public TCD_Usuario_TpDuplicata()
        { }

        public TCD_Usuario_TpDuplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" select " + strTop + " a.login, a.tp_duplicata, b.ds_tpduplicata ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_DIV_Usuario_X_TpDuplicata a ");
            sql.AppendLine("inner join TB_FIN_TpDuplicata b ");
            sql.AppendLine("on a.tp_duplicata = b.tp_duplicata ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Usuario_TpDuplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Usuario_TpDuplicata lista = new TList_Usuario_TpDuplicata();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Usuario_TpDuplicata reg = new TRegistro_Usuario_TpDuplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));

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

        public string Gravar(TRegistro_Usuario_TpDuplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);

            return this.executarProc("IA_DIV_USUARIO_X_TPDUPLICATA", hs);
        }

        public string Excluir(TRegistro_Usuario_TpDuplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);

            return this.executarProc("EXCLUI_DIV_USUARIO_X_TPDUPLICATA", hs);
        }
    }
}
