using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Producao.Producao
{
    public class TList_SerieDevolvida : List<TRegistro_SerieDevolvida> { }
    public class TRegistro_SerieDevolvida
    {
        private decimal? id_serie;

        public decimal? Id_serie
        {
            get { return id_serie; }
            set
            {
                id_serie = value;
                id_seriestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_seriestr;

        public string Id_seriestr
        {
            get { return id_seriestr; }
            set
            {
                id_seriestr = value;
                try
                {
                    id_serie = decimal.Parse(value);
                }
                catch { id_serie = null; }
            }
        }
        public string Cd_empresa { get; set; }
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
        private decimal? id_nfitem;

        public decimal? Id_nfitem
        {
            get { return id_nfitem; }
            set
            {
                id_nfitem = value;
                id_nfitemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_nfitemstr;

        public string Id_nfitemstr
        {
            get { return id_nfitemstr; }
            set
            {
                id_nfitemstr = value;
                try
                {
                    id_nfitem = decimal.Parse(value);
                }
                catch { id_nfitem = null; }
            }
        }

    }
    public class TCD_SerieDevolvida:TDataQuery
    {
        public TCD_SerieDevolvida() { }
        public TCD_SerieDevolvida(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("Select " + strTop + " a.id_serie, a.cd_empresa, a.nr_lanctofiscal, a.id_nfitem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PRD_SerieDevolvida a ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_SerieDevolvida Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_SerieDevolvida lista = new TList_SerieDevolvida();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SerieDevolvida reg = new TRegistro_SerieDevolvida();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_serie")))
                        reg.Id_serie = reader.GetDecimal(reader.GetOrdinal("id_serie"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
        public string Gravar(TRegistro_SerieDevolvida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_SERIE", val.Id_serie);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return executarProc("IA_PRD_SERIEDEVOLVIDA", hs);
        }
        public string Excluir(TRegistro_SerieDevolvida val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_SERIE", val.Id_serie);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return executarProc("EXCLUI_PRD_SERIEDEVOLVIDA", hs);
        }
    }
}
