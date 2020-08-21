using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_RegCategoriaCliFor_X_TabelaPreco : List<TRegistro_CategoriaCliFor_X_TabelaPreco>
    { }

    [DataContract]
    public class TRegistro_CategoriaCliFor_X_TabelaPreco
    {
        [DataMember]
        public string Cd_TabelaPreco
        { get; set; }

        [DataMember]
        public string DS_TabelaPreco
        { get; set; }

        private decimal? id_CategoriaCliFor;
        [DataMember]
        public decimal? Id_CategoriaCliFor
        {
            get { return id_CategoriaCliFor; }
            set
            {
                id_CategoriaCliFor = value;
                id_CategoriaCliForstr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }

        private string id_CategoriaCliForstr;
        [DataMember]
        public string Id_CategoriaCliForstr
        {
            get
            {
                return id_CategoriaCliForstr;
            }
            set
            {
                id_CategoriaCliForstr = value;
                try
                {
                    id_CategoriaCliFor = Convert.ToInt32(value);
                }
                catch
                { id_CategoriaCliFor = null; }
            }
        }

        [DataMember]
        public string Ds_CategoriaCliFor
        { get; set; }

        public TRegistro_CategoriaCliFor_X_TabelaPreco()
        {
            this.Cd_TabelaPreco = string.Empty;
            this.DS_TabelaPreco = string.Empty;
            this.id_CategoriaCliFor = null;
            this.id_CategoriaCliForstr = string.Empty;
            this.Ds_CategoriaCliFor = string.Empty;
        }
    }

    public class TCD_CategoriaCliFor_X_TabelaPreco : TDataQuery
    {
        public TCD_CategoriaCliFor_X_TabelaPreco()
        { }

        public TCD_CategoriaCliFor_X_TabelaPreco(BancoDados.TObjetoBanco banco)
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
            {
                sql.AppendLine("Select " + strTop + " a.Id_CategoriaCliFor, b.Ds_CategoriaCliFor, ");
                sql.AppendLine("a.Cd_TabelaPreco, c.Ds_TabelaPreco ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_CATEGORIACLIFOR_X_TABELAPRECO a ");
            sql.AppendLine("inner join TB_FIN_CATEGORIACLIFOR b ");
            sql.AppendLine("On b.ID_CATEGORIACLIFOR = a.ID_CATEGORIACLIFOR ");
            sql.AppendLine("inner join TB_DIV_TABELAPRECO c ");
            sql.AppendLine("On c.CD_TABELAPRECO = a.CD_TABELAPRECO ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_RegCategoriaCliFor_X_TabelaPreco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegCategoriaCliFor_X_TabelaPreco lista = new TList_RegCategoriaCliFor_X_TabelaPreco();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                while (reader.Read())
                {
                    TRegistro_CategoriaCliFor_X_TabelaPreco CadParam = new TRegistro_CategoriaCliFor_X_TabelaPreco();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_CategoriaCliFor")))
                        CadParam.Id_CategoriaCliFor = reader.GetDecimal(reader.GetOrdinal("Id_CategoriaCliFor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_CategoriaCliFor")))
                        CadParam.Ds_CategoriaCliFor = reader.GetString(reader.GetOrdinal("Ds_CategoriaCliFor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_TabelaPreco")))
                        CadParam.Cd_TabelaPreco = reader.GetString(reader.GetOrdinal("Cd_TabelaPreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_TabelaPreco")))
                        CadParam.DS_TabelaPreco = reader.GetString(reader.GetOrdinal("Ds_TabelaPreco"));
                    lista.Add(CadParam);
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

        public string GravarCategoriaCliFor_X_TabelaPreco(TRegistro_CategoriaCliFor_X_TabelaPreco val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_TabelaPreco);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_CategoriaCliFor);

            return executarProc("IA_DIV_CATEGORIACLIFOR_X_TABELAPRECO", hs);
        }

        public string DeletarCategoriaCliFor_X_TabelaPreco(TRegistro_CategoriaCliFor_X_TabelaPreco val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_TabelaPreco);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_CategoriaCliFor);

            return this.executarProc("EXCLUI_DIV_CATEGORIACLIFOR_X_TABELAPRECO", hs);
        }
    }
}
