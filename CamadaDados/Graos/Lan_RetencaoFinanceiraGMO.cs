using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_Lan_RetencaoFinanceiraGMO : List<TRegistro_Lan_RetencaoFinanceiraGMO>
    { }

    
    public class TRegistro_Lan_RetencaoFinanceiraGMO
    {
        
        public decimal? Id_LanctoGMO { get; set; }
        
        public string  Cd_ContaGer{ get; set; }
        
        public decimal? Cd_LanctoCaixa { get; set; }
        
        public string Cd_Empresa { get; set; }
        
        public decimal? Nr_Lancto { get; set; }
        
        public decimal? Cd_Parcela { get; set; }
        
        public decimal? Id_Liquid { get; set; }
        
        public TRegistro_Lan_RetencaoFinanceiraGMO()
        {
            this.Id_LanctoGMO = null;
            this.Cd_ContaGer = string.Empty;
            this.Cd_LanctoCaixa = null;
            this.Cd_Empresa = string.Empty;
            this.Nr_Lancto = null;
            this.Cd_Parcela = null;
            this.Id_Liquid = null;
        }
    }

    public class TCD_Lan_RetencaoFinanceiraGMO : TDataQuery
    {
        public TCD_Lan_RetencaoFinanceiraGMO()
        { }

        public TCD_Lan_RetencaoFinanceiraGMO(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "  a.id_lanctoGmo, a.cd_contager, ");
                sql.AppendLine("a.cd_lanctoCaixa, a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_liquid ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_retencaoFinanceiragmo a ");
            
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

        public TList_Lan_RetencaoFinanceiraGMO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Lan_RetencaoFinanceiraGMO lista = new TList_Lan_RetencaoFinanceiraGMO();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lan_RetencaoFinanceiraGMO reg = new TRegistro_Lan_RetencaoFinanceiraGMO();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoGMO")))
                        reg.Id_LanctoGMO = reader.GetDecimal(reader.GetOrdinal("id_lanctoGMO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ContaGer")))
                        reg.Cd_ContaGer = reader.GetString(reader.GetOrdinal("Cd_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_LanctoCaixa")))
                        reg.Cd_LanctoCaixa = reader.GetDecimal(reader.GetOrdinal("Cd_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("Cd_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lancto")))
                        reg.Nr_Lancto = reader.GetDecimal(reader.GetOrdinal("Nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Parcela")))
                        reg.Cd_Parcela = reader.GetDecimal(reader.GetOrdinal("Cd_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Liquid")))
                        reg.Id_Liquid = reader.GetDecimal(reader.GetOrdinal("Id_Liquid"));
                   
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

        public string GravaRetencaoFinanceiraGMO(TRegistro_Lan_RetencaoFinanceiraGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.Id_LanctoGMO);
            hs.Add("@P_CD_CONTAGER", vRegistro.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", vRegistro.Cd_LanctoCaixa);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_Empresa);
            hs.Add("@P_NR_LANCTO", vRegistro.Nr_Lancto);
            hs.Add("@P_CD_PARCELA", vRegistro.Cd_Parcela);
            hs.Add("@P_ID_LIQUID", vRegistro.Id_Liquid);
            
            return this.executarProc("IA_GRO_RETENCAOFINANCEIRAGMO", hs);
        }

        public string DeletarRetencaoFinanceiraGMO(TRegistro_Lan_RetencaoFinanceiraGMO vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);

            hs.Add("@P_ID_LANCTOGMO", vRegistro.Id_LanctoGMO);
            hs.Add("@P_CD_CONTAGER", vRegistro.Cd_ContaGer);
            hs.Add("@P_CD_LANCTOCAIXA", vRegistro.Cd_LanctoCaixa);

            return this.executarProc("EXCLUI_GRO_RETENCAOFINANCEIRAGMO", hs);
        }
    }
}
