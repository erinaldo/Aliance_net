using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace CamadaDados.Fazenda.Lancamento
{
    public class TList_LanPesFazenda : List<TRegistro_LanPesFazenda>  { }

    public class TRegistro_LanPesFazenda
    {

        public string CD_Empresa { get; set; }
        public decimal ID_Ticket { get; set; }        
        public string TP_Pesagem { get; set; }

        public decimal CD_Plantio { get; set; }

        public decimal CD_Talhao { get; set; }
        public string DS_Talhao { get; set; }

        public decimal CD_Fazenda { get; set; }
        public string DS_Fazenda { get; set; }

        public string AnoSafra { get; set; }
        public string DS_AnoSafra { get; set; }

        public string CD_TabelaDesconto { get; set; }
        public string DS_TabelaDesconto { get; set; }

        public string CD_Local { get; set; }
        public string DS_Local { get; set; }

        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }

        public string CD_Variedade { get; set; }
        public string DS_Variedade { get; set; }

        public decimal? ID_LanctoEstoque { get; set; }
        public decimal VLUnitario { get; set; }
        public string ST_Pesagem { get; set; }

        public TRegistro_LanPesFazenda()
        {
            this.CD_Empresa = "";
            this.ID_Ticket = 0;
            this.CD_Plantio = 0;
            this.TP_Pesagem = "";
            this.CD_Produto = "";
            this.DS_Produto = "";
            this.CD_TabelaDesconto = "";
            this.DS_TabelaDesconto = "";
            this.CD_Local = "";
            this.DS_Local = "";
            this.AnoSafra = "";
            this.DS_AnoSafra = "";
            this.ID_LanctoEstoque = 0;
            this.CD_Talhao = 0;
            this.DS_Talhao = "";
            this.CD_Fazenda = 0;
            this.DS_Fazenda = "";
            this.VLUnitario = 0;
            this.ST_Pesagem = "";
        }
    }

    public class TCD_LanPesFazenda : TDataQuery
    {

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa,a.ID_Ticket,a.TP_Pesagem,a.CD_Produto, p.ds_produto, ");
                sql.AppendLine(" a.ID_LanctoEstoque,b.CD_Talhao, t.NM_Talhao, b.CD_Fazenda, f.NM_Fazenda, a.VL_Unitario, ");
                sql.AppendLine(" a.ID_Plantio, a.CD_TabelaDesconto, d.DS_TabelaDesconto, a.CD_Local, l.ds_local, b.anosafra, s.DS_Safra, b.cd_variedade, v.ds_variedade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_BAL_PSFazenda a ");
            sql.AppendLine(" INNER JOIN TB_FAZ_Plantio b ON a.id_plantio = b.id_plantio ");
            sql.AppendLine(" INNER JOIN TB_EST_Produto p on p.cd_produto = b.cd_produto ");
            sql.AppendLine(" INNER JOIN TB_FAZ_Talhoes t on t.cd_fazenda = b.cd_fazenda and t.cd_talhao = b.cd_talhao ");
            sql.AppendLine(" INNER JOIN TB_FAZ_FAZENDA f on f.cd_fazenda = b.cd_fazenda ");
            sql.AppendLine(" INNER JOIN TB_EST_Variedade v on v.cd_variedade = b.cd_variedade ");
            sql.AppendLine(" INNER JOIN TB_GRO_TabelaDesconto d on d.cd_tabelaDesconto = a.cd_TabelaDesconto ");
            sql.AppendLine(" INNER JOIN TB_GRO_safra s on s.anosafra = b.anosafra");
            sql.AppendLine(" INNER JOIN TB_EST_LocalArm l on l.cd_local = a.cd_local");


            
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append(" Order by a.id_ticket asc ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_LanPesFazenda Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanPesFazenda lista = new TList_LanPesFazenda();
            SqlDataReader reader = null;
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
                    TRegistro_LanPesFazenda reg = new TRegistro_LanPesFazenda();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ticket")))
                        reg.ID_Ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pesagem")))
                        reg.TP_Pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque")))
                        reg.ID_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Talhao")))
                        reg.CD_Talhao = reader.GetDecimal(reader.GetOrdinal("CD_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Talhao")))
                        reg.DS_Talhao = reader.GetString(reader.GetOrdinal("NM_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.CD_Fazenda = reader.GetDecimal(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.DS_Fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                        reg.AnoSafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                        reg.DS_AnoSafra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Variedade")))
                        reg.CD_Variedade = reader.GetString(reader.GetOrdinal("CD_Variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Variedade")))
                        reg.DS_Variedade = reader.GetString(reader.GetOrdinal("DS_Variedade"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto")))
                        reg.CD_TabelaDesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaDesconto")))
                        reg.DS_TabelaDesconto = reader.GetString(reader.GetOrdinal("DS_TabelaDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.CD_Local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.DS_Local = reader.GetString(reader.GetOrdinal("DS_Local"));

                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.VLUnitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Plantio")))
                        reg.CD_Plantio = reader.GetDecimal(reader.GetOrdinal("ID_Plantio"));
                    
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

        public string Grava(TRegistro_LanPesFazenda vRegistro)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_TICKET", vRegistro.ID_Ticket);
            hs.Add("@P_TP_PESAGEM", vRegistro.TP_Pesagem);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_TabelaDesconto);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);

            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.ID_LanctoEstoque);
            hs.Add("@P_ID_PLANTIO", vRegistro.CD_Plantio);
            hs.Add("@P_VL_UNITARIO", vRegistro.VLUnitario);

            return this.executarProc("IA_BAL_PESFAZENDA", hs);
        }

        public string Deleta(TRegistro_LanPesFazenda vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_TICKET", vRegistro.ID_Ticket);
            hs.Add("@P_TP_PESAGEM", vRegistro.TP_Pesagem);

            return this.executarProc("EXCLUI_BAL_PESFAZENDA", hs);
        }

    }

}
