using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_Apontamento_CustoFixo : List<TRegistro_Apontamento_CustoFixo>
    { }

    public class TRegistro_Apontamento_CustoFixo
    {
        public decimal? Id_apontamento
        { get; set; }
        public decimal? Id_custo
        { get; set; }
        public string Ds_custo
        { get; set; }
        public string Tp_custo
        { get; set; }
        public decimal Vl_custo
        { get; set; }
        public decimal Indice_monetario
        { get; set; }

        public TRegistro_Apontamento_CustoFixo()
        {
            this.Id_apontamento = null;
            this.Id_custo = null;
            this.Ds_custo = string.Empty;
            this.Tp_custo = string.Empty;
            this.Vl_custo = decimal.Zero;
            this.Indice_monetario = decimal.Zero;
        }
    }

    public class TCD_Apontamento_CustoFixo : TDataQuery
    {
        public TCD_Apontamento_CustoFixo()
        { }

        public TCD_Apontamento_CustoFixo(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_apontamento, a.id_custo, ");
                sql.AppendLine("b.ds_custo, b.tp_custo, a.vl_custo, a.indice_monetario ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_apontamento_custofixo a ");
            sql.AppendLine("inner join tb_prd_custos b ");
            sql.AppendLine("on a.id_custo = b.id_custo ");
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
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Apontamento_CustoFixo Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Apontamento_CustoFixo lista = new TList_Apontamento_CustoFixo();
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
                    TRegistro_Apontamento_CustoFixo reg = new TRegistro_Apontamento_CustoFixo();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Apontamento")))
                        reg.Id_apontamento = reader.GetDecimal(reader.GetOrdinal("ID_Apontamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Custo")))
                        reg.Id_custo = reader.GetDecimal(reader.GetOrdinal("ID_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Custo")))
                        reg.Ds_custo = reader.GetString(reader.GetOrdinal("DS_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Custo")))
                        reg.Tp_custo = reader.GetString(reader.GetOrdinal("TP_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("Vl_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Indice_monetario")))
                        reg.Indice_monetario = reader.GetDecimal(reader.GetOrdinal("Indice_monetario"));

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

        public string GravarApontamentoCustoFixo(TRegistro_Apontamento_CustoFixo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            hs.Add("@P_VL_CUSTO", val.Vl_custo);
            hs.Add("@P_INDICE_MONETARIO", val.Indice_monetario);

            return this.executarProc("IA_PRD_APONTAMENTO_CUSTOFIXO", hs);
        }

        public string DeletarApontamentoCustoFixo(TRegistro_Apontamento_CustoFixo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_APONTAMENTO", val.Id_apontamento);
            hs.Add("@P_ID_CUSTO", val.Id_custo);

            return this.executarProc("EXCLUI_PRD_APONTAMENTO_CUSTOFIXO", hs);
        }
    }

}
