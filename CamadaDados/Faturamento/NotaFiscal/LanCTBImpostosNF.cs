using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_CTBImpostosNF : List<TRegistro_CTBImpostosNF> { }
    public class TRegistro_CTBImpostosNF
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public decimal? Nr_lanctofiscal { get; set; } = null;
        public decimal? Id_nfitem { get; set; } = null;
        public decimal? Cd_imposto { get; set; } = null;
        public decimal? Id_lotectb_retido { get; set; } = null;
        public decimal? Id_lotectb_calculado { get; set; } = null;
    }
    public class TCD_CTBImpostosNF : TDataQuery
    {
        public TCD_CTBImpostosNF() { }
        public TCD_CTBImpostosNF(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctofiscal, a.id_nfitem, ");
                sql.AppendLine("a.cd_imposto, a.id_lotectb_retido, a.id_lotectb_calculado ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_CTBImpostosNF a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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
        public TList_CTBImpostosNF Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CTBImpostosNF lista = new TList_CTBImpostosNF();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CTBImpostosNF reg = new TRegistro_CTBImpostosNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("cd_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb_retido")))
                        reg.Id_lotectb_retido = reader.GetDecimal(reader.GetOrdinal("id_lotectb_retido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lotectb_calculado")))
                        reg.Id_lotectb_calculado = reader.GetDecimal(reader.GetOrdinal("id_lotectb_calculado"));

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
        public string Gravar(TRegistro_CTBImpostosNF val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_ID_LOTECTB_RETIDO", val.Id_lotectb_retido);
            hs.Add("@P_ID_LOTECTB_CALCULADO", val.Id_lotectb_calculado);
            return executarProc("IA_FAT_CTBIMPOSTOSNF", hs);
        }
        public string Excluir(TRegistro_CTBImpostosNF val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            return executarProc("EXCLUI_FAT_CTBIMPOSTOSNF", hs);
        }
    }
}
