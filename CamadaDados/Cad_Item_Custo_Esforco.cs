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
    public class TList_CadItem_Custo_Esforco : List<TRegistro_CadItem_Custo_Esforco>
    { }

    public class TRegistro_CadItem_Custo_Esforco
    {
        private decimal ID_ICE;
        public decimal ID_ice
        {
            get { return ID_ICE; }
            set { ID_ICE = value; }
        }

        private string DS_ItemCustoEsforco;
        public string DS_itemcustoesforco
        {
            get { return DS_ItemCustoEsforco; }
            set { DS_ItemCustoEsforco = value; }
        }

        private string Sigla;
        public string sigla
        {
            get { return Sigla; }
            set { Sigla = value; }
        }

        public TRegistro_CadItem_Custo_Esforco()
        {
            this.ID_ice = 0;
            this.DS_itemcustoesforco = "";
            this.sigla = "";
        }
    }
   
    public class TCD_CadItem_Custo_Esforco : TDataQuery
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
                sql.Append("Select " + strTop + " a.ID_ICE, a.DS_ItemCustoEsforco, ");
                sql.Append("a.Sigla, a.DT_Cad, a.DT_Alt ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.Append("From TB_PRD_Item_CustoEsforco a");
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

        public TList_CadItem_Custo_Esforco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadItem_Custo_Esforco lista = new TList_CadItem_Custo_Esforco();
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
                    TRegistro_CadItem_Custo_Esforco CadItem_Custo_Esforco = new TRegistro_CadItem_Custo_Esforco();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ICE")))
                        CadItem_Custo_Esforco.ID_ice = reader.GetDecimal(reader.GetOrdinal("ID_ICE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItemCustoEsforco")))
                        CadItem_Custo_Esforco.DS_itemcustoesforco = reader.GetString(reader.GetOrdinal("DS_ItemCustoEsforco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        CadItem_Custo_Esforco.sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    lista.Add(CadItem_Custo_Esforco);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        
        }

        public string GravarItem_Custo_Esforco(TRegistro_CadItem_Custo_Esforco val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_ID_ICE", val.ID_ice);
            hs.Add("@P_DS_ITEMCUSTOESFORCO", val.DS_itemcustoesforco);
            hs.Add("@P_SIGLA", val.sigla);
            return executarProc("IA_PRD_ITEM_CUSTOESFORCO", hs);

        }

        public string DeletarItem_Custo_Esforco(TRegistro_CadItem_Custo_Esforco val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_ID_ICE", val.ID_ice);
            return this.executarProc("EXCLUI_PRD_ITEM_CUSTOESFORCO", hs);
        }

    }

}

  
