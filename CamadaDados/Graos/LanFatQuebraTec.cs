using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_FatQuebraTec : List<TRegistro_FatQuebraTec>
    { }

    
    public class TRegistro_FatQuebraTec
    {
        
        public decimal? Id_lantaxa
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lanctofiscal
        { get; set; }
        
        public decimal? Id_nfitem
        { get; set; }

        public TRegistro_FatQuebraTec()
        {
            this.Id_lantaxa = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctofiscal = null;
            this.Id_nfitem = null;
        }
    }

    public class TCD_FatQuebraTec : TDataQuery
    {
        public TCD_FatQuebraTec()
        { }

        public TCD_FatQuebraTec(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.id_lantaxa, a.cd_empresa, a.nr_lanctofiscal, a.id_nfitem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_fatquebratec a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_FatQuebraTec Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FatQuebraTec lista = new TList_FatQuebraTec();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_FatQuebraTec reg = new TRegistro_FatQuebraTec();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lantaxa")))
                        reg.Id_lantaxa = reader.GetDecimal(reader.GetOrdinal("id_lantaxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));

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

        public string Gravar(TRegistro_FatQuebraTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANTAXA", val.Id_lantaxa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("IA_GRO_FATQUEBRATEC", hs);
        }

        public string Excluir(TRegistro_FatQuebraTec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANTAXA", val.Id_lantaxa);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_NFITEM", val.Id_nfitem);

            return this.executarProc("EXCLUI_GRO_FATQUEBRATEC", hs);
        }
    }
}
