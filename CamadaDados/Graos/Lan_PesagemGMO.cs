using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_LanPesagemGMO : List<TRegistro_LanPesagemGMO> 
    { }

    
    public class TRegistro_LanPesagemGMO
    {
        
        public decimal? ID_LanctoGMO { get; set; }
        
        public string CD_Empresa { get; set; }
        
        public decimal? ID_Ticket { get; set; }
        
        public string TP_Pesagem { get; set; }

        public TRegistro_LanPesagemGMO()
        {
            ID_LanctoGMO = null;
            CD_Empresa = string.Empty;
            ID_Ticket = null;
            TP_Pesagem = string.Empty;
        }
    }

    public class TCD_LanPesagemGMO : TDataQuery
    {
        public TCD_LanPesagemGMO()
        { }

        public TCD_LanPesagemGMO(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.ID_LanctoGMO, a.CD_Empresa, a.ID_Ticket, a.TP_Pesagem ");
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_GRO_PesagemGMO a ");

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

        public TList_LanPesagemGMO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanPesagemGMO lista = new TList_LanPesagemGMO();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPesagemGMO reg = new TRegistro_LanPesagemGMO();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoGMO")))
                        reg.ID_LanctoGMO = reader.GetDecimal(reader.GetOrdinal("ID_LanctoGMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ticket")))
                        reg.ID_Ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pesagem")))
                        reg.TP_Pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    
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

        public string Grava(TRegistro_LanPesagemGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.ID_LanctoGMO);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_TICKET", vRegistro.ID_Ticket);
            hs.Add("@P_TP_PESAGEM", vRegistro.TP_Pesagem);
            
            return this.executarProc("IA_GRO_PESAGEMGMO", hs);
        }

        public string Deleta(TRegistro_LanPesagemGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.ID_LanctoGMO);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_TICKET", vRegistro.ID_Ticket);
            hs.Add("@P_TP_PESAGEM", vRegistro.TP_Pesagem);

            return this.executarProc("EXCLUI_GRO_PESAGEMGMO", hs);
        }
    }
}
