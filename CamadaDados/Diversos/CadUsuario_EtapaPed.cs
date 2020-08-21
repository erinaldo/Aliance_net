using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario_EtapaPed : List<TRegistro_CadUsuario_EtapaPed>
    { }


    public class TRegistro_CadUsuario_EtapaPed
    {

        public decimal IDEtapa { get; set; }

        public string Login { get; set; }

        public string LoginUsr { get; set; }

        public string Nome_usuario { get; set; }
        public string DS_Etapa { get; set; }
        public bool St_processar { get; set; }

        public TRegistro_CadUsuario_EtapaPed()
        {
            this.IDEtapa = decimal.Zero;
            this.DS_Etapa = string.Empty;
            this.Login = string.Empty;
            this.LoginUsr = string.Empty;
            this.Nome_usuario = string.Empty;
            this.St_processar = false;
        }
    }
    public class TCD_CadUsuario_EtapaPed : TDataQuery
    {
        public TCD_CadUsuario_EtapaPed()
        { }

        public TCD_CadUsuario_EtapaPed(BancoDados.TObjetoBanco banco)
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
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.Login, a.id_etapa, b.DS_Etapa, b.st_fecharped ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_div_usuario_x_etapaped a ");
            sql.AppendLine("inner join TB_FAT_etapaped b ");
            sql.AppendLine("On a.ID_Etapa = b.ID_Etapa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public CamadaDados.Faturamento.Cadastros.TList_CadEtapa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            CamadaDados.Faturamento.Cadastros.TList_CadEtapa lista = new CamadaDados.Faturamento.Cadastros.TList_CadEtapa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa reg = new CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("id_etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_etapa")))
                        reg.DS_Etapa = reader.GetString(reader.GetOrdinal("ds_etapa"));
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

        public string GravaEtapaPed(CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_LOGIN", val.Login);
            return executarProc("IA_DIV_USUARIO_X_ETAPAPED", hs);
        }

        public string DeletaEtapaPed(CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ETAPA", val.Id_etapa);
            hs.Add("@P_LOGIN", val.Login);
            return executarProc("EXCLUI_DIV_USUARIO_X_ETAPAPED", hs);
        }
    }
}
