using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadTbPreco : List<TRegistro_CadTbPreco>
    { }
    
    public class TRegistro_CadTbPreco
    {
        
        public string CD_TabelaPreco { get; set; }
        
        public string ST_Registro { get; set; }
        
        public string DS_TabelaPreco { get; set; }

        public bool St_processar { get; set; }

        public TRegistro_CadTbPreco()
        {
            this.CD_TabelaPreco = string.Empty;
            this.DS_TabelaPreco = string.Empty;
            this.ST_Registro = "A";
            this.St_processar = false;
        }
    }

    public class TCD_CadTbPreco : TDataQuery
    {
        public TCD_CadTbPreco()
        { }

        public TCD_CadTbPreco(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
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
                sql.AppendLine(" SELECT " + strTop + "a.Cd_tabelaPreco, a.DS_TabelaPreco, a.ST_Registro ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_DIV_TabelaPreco a ");
            sql.AppendLine("Where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.Append("Order by a.Cd_tabelaPreco asc");
            return sql.ToString();
        }

        public TList_CadTbPreco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTbPreco lista = new TList_CadTbPreco();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadTbPreco cadPreco = new TRegistro_CadTbPreco();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TabelaPreco"))))
                        cadPreco.CD_TabelaPreco = reader.GetString(reader.GetOrdinal("CD_TabelaPreco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        cadPreco.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TabelaPreco"))))
                        cadPreco.DS_TabelaPreco = reader.GetString(reader.GetOrdinal("DS_TabelaPreco"));

                    lista.Add(cadPreco);
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

        public string GravarPreco(TRegistro_CadTbPreco val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_TABELAPRECO", val.CD_TabelaPreco);
            hs.Add("@P_ST_REGISTRO", val.ST_Registro);
            hs.Add("@P_DS_TABELAPRECO", val.DS_TabelaPreco);

            return executarProc("IA_DIV_TABELAPRECO", hs);
        }

        public string DeletarPreco(TRegistro_CadTbPreco val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_TABELAPRECO", val.CD_TabelaPreco);

            return executarProc("EXCLUI_DIV_TABELAPRECO", hs);
        }
    }
}
