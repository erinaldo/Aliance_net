using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;


namespace CamadaDados.Sementes.Cadastros
{
    public class TList_TipoAnalise : List<TRegistro_TipoAnalise>
    { }

    public class TRegistro_TipoAnalise
    {
        public decimal? Id_analise
        { get; set; }
        public string Ds_analise
        { get; set; }
        public bool St_utilizarlote
        { get; set; }

        public TRegistro_TipoAnalise()
        {
            this.Id_analise = null;
            this.Ds_analise = string.Empty;
            this.St_utilizarlote = false;
        }
    }

    public class TCD_TipoAnalise : TDataQuery
    {
        public TCD_TipoAnalise()
        { }

        public TCD_TipoAnalise(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_analise, a.ds_analise ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_sem_tipoanalise a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
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

        public TList_TipoAnalise Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_TipoAnalise lista = new TList_TipoAnalise();
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
                    TRegistro_TipoAnalise reg = new TRegistro_TipoAnalise();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Analise")))
                        reg.Id_analise = reader.GetDecimal(reader.GetOrdinal("ID_Analise"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Analise")))
                        reg.Ds_analise = reader.GetString(reader.GetOrdinal("DS_Analise"));

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

        public string GravarTipoAnalise(TRegistro_TipoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ANALISE", val.Id_analise);
            hs.Add("@P_DS_ANALISE", val.Ds_analise);

            return this.executarProc("IA_SEM_TIPOANALISE", hs);
        }

        public string DeletarTipoAnalise(TRegistro_TipoAnalise val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ANALISE", val.Id_analise);

            return this.executarProc("EXCLUI_SEM_TIPOAMOSTRA", hs);
        }
    }
}
