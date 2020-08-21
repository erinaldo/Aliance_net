using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_FaturamentoCCusto : List<TRegistro_FaturamentoCCusto>
    { }

    public class TRegistro_FaturamentoCCusto
    {
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch { id_ccustolan = null; }
            }
        }
    }

    public class TCD_FaturamentoCCusto : TDataQuery
    {
        public TCD_FaturamentoCCusto() { }

        public TCD_FaturamentoCCusto(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctofiscal, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FIN_NotaFiscal_X_CCusto a ");

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

        public TList_FaturamentoCCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FaturamentoCCusto lista = new TList_FaturamentoCCusto();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FaturamentoCCusto reg = new TRegistro_FaturamentoCCusto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));

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

        public string Gravar(TRegistro_FaturamentoCCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("IA_FIN_NOTAFISCAL_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_FaturamentoCCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("EXCLUI_FIN_NOTAFISCAL_X_CCUSTO", hs);
        }
    }
}
