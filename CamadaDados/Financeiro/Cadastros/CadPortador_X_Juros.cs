using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_Portador_X_Juros : List<TRegistro_Portador_X_Juros>
    { }

    
    public class TRegistro_Portador_X_Juros
    {
        
        public string Cd_juro
        { get; set; }
        
        public string Ds_juro
        { get; set; }
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }

        public TRegistro_Portador_X_Juros()
        {
            this.Cd_juro = string.Empty;
            this.Ds_juro = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
        }
    }

    public class TCD_Portador_X_Juros : TDataQuery
    {
        public TCD_Portador_X_Juros()
        { }

        public TCD_Portador_X_Juros(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {

                sql.AppendLine("select " + strTop + " a.cd_juro, b.ds_juro, ");
                sql.AppendLine("a.cd_portador, c.ds_portador ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_juro_x_portador a ");
            sql.AppendLine("inner join tb_fin_juro b ");
            sql.AppendLine("on a.cd_juro = b.cd_juro ");
            sql.AppendLine("inner join tb_fin_portador c ");
            sql.AppendLine("on a.cd_portador = c.cd_portador ");
            cond = " where ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_Portador_X_Juros Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Portador_X_Juros lista = new TList_Portador_X_Juros();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Portador_X_Juros reg = new TRegistro_Portador_X_Juros();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Juro"))))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("CD_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Juro"))))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("DS_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Portador"))))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));

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

        public string Gravar(TRegistro_Portador_X_Juros val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return this.executarProc("IA_FIN_JURO_X_PORTADOR", hs);
        }

        public string Excluir(TRegistro_Portador_X_Juros val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return this.executarProc("EXCLUI_FIN_JURO_X_PORTADOR", hs);
        }
    }
}
