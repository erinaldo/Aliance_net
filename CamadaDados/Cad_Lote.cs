using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_CadLote : List<TRegistro_CadLote>
    { }

    public class TRegistro_CadLote
    {

        private decimal nr_loteproducao;

        public decimal Nr_loteproducao
        {
            get { return nr_loteproducao; }
            set { nr_loteproducao = value; }
        }

        private string ds_loteproducao;

        public string Ds_loteproducao
        {
            get { return ds_loteproducao; }
            set { ds_loteproducao = value; }
        }

        private string cd_loteID;

        public string Cd_loteID
        {
            get { return cd_loteID; }
            set { cd_loteID = value; }
        }

        private decimal qt_dias_Validade;

        public decimal Qt_dias_Validade
        {
            get { return qt_dias_Validade; }
            set { qt_dias_Validade = value; }
        }
              
        
        public TRegistro_CadLote()
        {
            nr_loteproducao = 0;
            ds_loteproducao = "";
            cd_loteID = "";
            qt_dias_Validade = 0;
        }
    }

    public class TCD_CadLote : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
            {
                strTop = "TOP " + Convert.ToString(vTop);
            }
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.Append(" Select " + strTop + " a.nr_loteProducao, a.ds_Loteproducao, a.cd_LoteID, ");
                sql.Append(" a.qt_Dias_Validade, ");
                sql.Append(" a.DT_Cad, a.DT_Alt ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.Append("From TB_PRD_Lote a");
            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_CadLote Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadLote lista = new TList_CadLote();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadLote CadLote = new TRegistro_CadLote();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LoteProducao")))
                        CadLote.Nr_loteproducao = reader.GetDecimal(reader.GetOrdinal("NR_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LoteProducao")))
                        CadLote.Ds_loteproducao = reader.GetString(reader.GetOrdinal("DS_LoteProducao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LoteID")))
                        CadLote.Cd_loteID = reader.GetString(reader.GetOrdinal("CD_LoteID"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Dias_Validade")))
                        CadLote.Qt_dias_Validade = reader.GetDecimal(reader.GetOrdinal("QT_Dias_Validade"));
                    lista.Add(CadLote);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;

        }

        public string GravarLote(TRegistro_CadLote val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_LOTEPRODUCAO", val.Nr_loteproducao);
            hs.Add("@P_DS_LOTEPRODUCAO", val.Ds_loteproducao);
            hs.Add("@P_CD_LOTEID", val.Cd_loteID);
            hs.Add("@P_QT_DIAS_VALIDADE", val.Qt_dias_Validade);
            return executarProc("IA_PRD_LOTE", hs);

        }

        public string DeletarLote(TRegistro_CadLote val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_LOTEPRODUCAO", val.Nr_loteproducao);
            return this.executarProc("EXCLUI_PRD_LOTE", hs);
        }

    }


}
