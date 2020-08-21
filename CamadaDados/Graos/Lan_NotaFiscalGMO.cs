using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_Lan_NotaFiscalGMO : List<TRegistro_Lan_NotaFiscalGMO>
    { }

    
    public class TRegistro_Lan_NotaFiscalGMO
    {
        
        public decimal? id_LanctoGmo { get; set; }
        
        public string cd_Empresa { get; set; }
        
        public decimal? nr_LanctoFiscal { get; set; }
        
        public decimal? id_NfItem { get; set; }

        public TRegistro_Lan_NotaFiscalGMO()
        {
            this.id_LanctoGmo = null;
            this.cd_Empresa = string.Empty;
            this.nr_LanctoFiscal = null;
            this.id_NfItem = null;
        }
    }
    public class TCD_Lan_NotaFiscalGMO : TDataQuery
    {
        public TCD_Lan_NotaFiscalGMO()
        { }

        public TCD_Lan_NotaFiscalGMO(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop+" a.id_lanctoGMO, a.cd_empresa, a.nr_lanctoFiscal, a.id_nfItem ");
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_gro_NotaFiscalGMO a");
            
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lan_NotaFiscalGMO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lan_NotaFiscalGMO lista = new TList_Lan_NotaFiscalGMO();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lan_NotaFiscalGMO reg = new TRegistro_Lan_NotaFiscalGMO();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoGMO")))
                        reg.id_LanctoGmo = reader.GetDecimal(reader.GetOrdinal("ID_LanctoGMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_LanctoFiscal")))
                        reg.nr_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_NfItem")))
                        reg.id_NfItem = reader.GetDecimal(reader.GetOrdinal("id_NfItem"));
                    
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

        public string Grava(TRegistro_Lan_NotaFiscalGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.id_LanctoGmo);
            hs.Add("@P_CD_EMPRESA", vRegistro.cd_Empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.nr_LanctoFiscal);
            hs.Add("@P_ID_NFITEM", vRegistro.id_NfItem);
            
            return this.executarProc("IA_GRO_NOTAFISCALGMO", hs);
        }

        public string Deleta(TRegistro_Lan_NotaFiscalGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.id_LanctoGmo);
            hs.Add("@P_CD_EMPRESA", vRegistro.cd_Empresa);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.nr_LanctoFiscal);
            hs.Add("@P_ID_NFITEM", vRegistro.id_NfItem);

            return this.executarProc("EXCLUI_GRO_NOTAFISCALGMO", hs);
        }
    }
}
