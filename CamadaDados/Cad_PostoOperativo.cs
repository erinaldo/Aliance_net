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
    public class TList_CadPosto_Operativo : List<TRegistro_CadPosto_Operativo>
    { }

    public class TRegistro_CadPosto_Operativo
    {
        private decimal id_po;
        public decimal ID_PO
        {
            get { return id_po; }
            set { id_po = value; }
        }
        private string ds_postooperativo;
        public string Ds_PostoOperativo
        {
            get { return ds_postooperativo; }
            set { ds_postooperativo = value; }
        }
        public TRegistro_CadPosto_Operativo()
        {
            this.id_po = 0;
            this.ds_postooperativo = "";
        }
    }


    public class TCD_Cad_PostoOperativo : TDataQuery
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
                sql.Append("Select " + strTop + " a.ID_PO, a.DS_PostoOperativo, a.DT_Cad, a.DT_Alt ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.Append("From TB_PRD_PostoOperativo a");
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

        public TList_CadPosto_Operativo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadPosto_Operativo lista = new TList_CadPosto_Operativo();
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
                    TRegistro_CadPosto_Operativo CadPosto_operativo = new TRegistro_CadPosto_Operativo();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PO")))
                        CadPosto_operativo.ID_PO = reader.GetDecimal(reader.GetOrdinal("ID_PO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PostoOperativo")))
                        CadPosto_operativo.Ds_PostoOperativo = reader.GetString(reader.GetOrdinal("DS_PostoOperativo"));
                    lista.Add(CadPosto_operativo);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;

        }

        public string GravarPosto_Operativo(TRegistro_CadPosto_Operativo val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_PO", val.ID_PO);
            hs.Add("@P_DS_POSTOOPERATIVO", val.Ds_PostoOperativo);
            return executarProc("IA_PRD_PostoOperativo", hs);

        }

        public string DeletarPosto_Operativo(TRegistro_CadPosto_Operativo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PO", val.ID_PO);
            return this.executarProc("EXCLUI_PRD_POSTOOPERATIVO", hs);
        }
    }
}
