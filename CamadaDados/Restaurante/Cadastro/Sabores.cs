using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_Sabores
    {
        public decimal? ID_Sabor { get; set; } = null;
        public string DS_Sabor { get; set; } = string.Empty;
        public string cd_grupo { get; set; } = string.Empty;
        public string ds_grupo { get; set; } = string.Empty;
        public bool st_agregar { get; set; } = false;
    }
    public class TList_Sabores : List<TRegistro_Sabores> { }

    public class TCD_Sabores : TDataQuery
    {
        public TCD_Sabores() { }

        public TCD_Sabores(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.id_sabor, a.ds_sabor  ,a.cd_grupo,b.ds_grupo ");

            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_sabores a ");
            sql.AppendLine("left join tb_est_grupoproduto b on a.cd_grupo = b.cd_grupo");



            string cond = " where ";
            //     sql.AppendLine("where  ");
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

        public TList_Sabores Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Sabores listaa = new TList_Sabores();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Sabores rega = new TRegistro_Sabores();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Sabor")))
                        rega.ID_Sabor = reader.GetDecimal(reader.GetOrdinal("ID_Sabor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Sabor")))
                        rega.DS_Sabor = reader.GetString(reader.GetOrdinal("DS_Sabor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        rega.cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        rega.ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));

                    listaa.Add(rega);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return listaa;
        }

        public string Gravar(TRegistro_Sabores val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_SABOR", val.ID_Sabor);
            hs.Add("@P_DS_SABOR", val.DS_Sabor);
            hs.Add("@P_CD_GRUPO", val.cd_grupo);

            return this.executarProc("IA_RES_SABORES", hs);
        }

        public string Excluir(TRegistro_Sabores val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_SABOR", val.ID_Sabor);
            hs.Add("@P_CD_GRUPO", val.cd_grupo);

            return this.executarProc("EXCLUI_RES_SABORES", hs);
        }
    }

    //public class 
}
