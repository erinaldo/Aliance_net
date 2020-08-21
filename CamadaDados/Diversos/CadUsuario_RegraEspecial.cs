using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_Usuario_RegraEspecial : List<TRegistro_Usuario_RegraEspecial>
    { }

    
    public class TRegistro_Usuario_RegraEspecial
    {
        
        public string Login
        { get; set; }
        private decimal? id_regra;
        
        public decimal? Id_regra
        {
            get { return id_regra; }
            set
            {
                id_regra = value;
                id_regrastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_regrastr;
        
        public string Id_regrastr
        {
            get { return id_regrastr; }
            set
            {
                id_regrastr = value;
                try
                {
                    id_regra = Convert.ToDecimal(value);
                }
                catch
                { id_regra = null; }
            }
        }
        
        public string Ds_regra
        { get; set; }

        public TRegistro_Usuario_RegraEspecial()
        {
            this.Login = string.Empty;
            this.id_regra = null;
            this.id_regrastr = string.Empty;
            this.Ds_regra = string.Empty;
        }
    }

    public class TCD_Usuario_RegraEspecial : TDataQuery
    {
        public TCD_Usuario_RegraEspecial()
        { }

        public TCD_Usuario_RegraEspecial(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("Select " + strTop + " a.login, a.id_regra, a.ds_regra ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_div_usuario_x_regraespecial a ");

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

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Usuario_RegraEspecial Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Usuario_RegraEspecial lista = new TList_Usuario_RegraEspecial();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Usuario_RegraEspecial cadUser = new TRegistro_Usuario_RegraEspecial();
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        cadUser.Login = reader.GetString(reader.GetOrdinal("login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Regra")))
                        cadUser.Id_regra = reader.GetDecimal(reader.GetOrdinal("ID_Regra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Regra")))
                        cadUser.Ds_regra = reader.GetString(reader.GetOrdinal("DS_Regra"));

                    lista.Add(cadUser);
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

        public string Gravar(TRegistro_Usuario_RegraEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_REGRA", val.Id_regra);
            hs.Add("@P_DS_REGRA", val.Ds_regra);

            return this.executarProc("IA_DIV_USUARIO_X_REGRAESPECIAL", hs);
        }

        public string Excluir(TRegistro_Usuario_RegraEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_REGRA", val.Id_regra);

            return this.executarProc("EXCLUI_DIV_USUARIO_X_REGRAESPECIAL", hs);
        }
    }
}
