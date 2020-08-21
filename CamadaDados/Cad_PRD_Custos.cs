using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;
using CamadaDados.Producao.Producao;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_Cad_PRD_Custos : List<TRegistro_Cad_PRD_Custos>
    { }

    public class TRegistro_Cad_PRD_Custos
    {
        public decimal Id_custo
        { get; set; }

        public string Ds_custo
        { get; set; }

        private string tp_custo;
        public string Tp_custo
        {
            get { return tp_custo; }
            set 
            { 
                tp_custo = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_custo = "FIXO";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_custo = "VARIAVEL";
            }
        }

        private string tipo_custo;
        public string Tipo_custo
        {
            get { return tipo_custo; }
            set 
            { 
                tipo_custo = value;
                if (value.Trim().ToUpper().Equals("FIXO"))
                    tp_custo = "F";
                else if (value.Trim().ToUpper().Equals("VARIAVEL"))
                    tp_custo = "V";
            }
        }
    }

    public class TCD_Cad_PRD_Custos : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine("Select " + strTop + " id_custo, ds_custo, tp_custo ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_prd_custos ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SqlCodeBuscaCross(string vTP_Custo)
        {
            StringBuilder sql = new StringBuilder();
            DataTable tab = new TCD_PRD_CFGMPrima_Adubo().Buscar(null, 0, "");

            sql.AppendLine("Select a.id_custo, a.ds_custo ");
            for (int x = 0; x < tab.Rows.Count; x++)
            {
                if (vTP_Custo.Trim().ToUpper().Equals("F"))
                    sql.AppendLine(", (select f.vl_custostd ");
                else
                    sql.AppendLine(", (select f.pc_custostd ");
                sql.AppendLine("  from tb_prd_custo_stdfixosmprima f ");
                sql.AppendLine("  where f.id_custo = a.id_custo ");
                sql.AppendLine("   and f.cd_produto = '" + tab.Rows[x]["CD_Produto"].ToString() + "') as '"+
                                   tab.Rows[x]["CD_Produto"].ToString().PadLeft(7, '0') + tab.Rows[x]["DS_Produto"].ToString().Trim() + "'");
            };

            sql.AppendLine("From TB_PRD_Custos a ");
            sql.AppendLine("Where a.tp_custo = '"+vTP_Custo+"'");

            return sql.ToString();
        }

        public DataTable BuscarCross(string vTP_Custo)
        {
            return this.ExecutarBusca(this.SqlCodeBuscaCross(vTP_Custo), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_PRD_Custos Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_PRD_Custos lista = new TList_Cad_PRD_Custos();
            SqlDataReader reader;
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
                    TRegistro_Cad_PRD_Custos reg = new TRegistro_Cad_PRD_Custos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Custo"))))
                        reg.Id_custo = reader.GetDecimal(reader.GetOrdinal("ID_Custo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Custo"))))
                        reg.Ds_custo = reader.GetString(reader.GetOrdinal("DS_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Custo")))
                        reg.Tp_custo = reader.GetString(reader.GetOrdinal("TP_Custo"));
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string GravarPRDCustos(TRegistro_Cad_PRD_Custos val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            hs.Add("@P_DS_CUSTO", val.Ds_custo);
            hs.Add("@P_TP_CUSTO", val.Tp_custo);
            return this.executarProc("IA_PRD_CUSTOS", hs);
        }

        public string DeletarPRDCustos(TRegistro_Cad_PRD_Custos val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            return this.executarProc("EXCLUI_PRD_CUSTOS", hs);
        }
    }
}
