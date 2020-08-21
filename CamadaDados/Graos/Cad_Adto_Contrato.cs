using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_Adto_Contrato : List<TRegistro_Adto_Contrato> 
    { }

    
    public class TRegistro_Adto_Contrato
    {
        
        public decimal? Nr_contrato
        { get; set; }
        
        public decimal? Id_adto
        { get; set; }

        public TRegistro_Adto_Contrato()
        {
            this.Nr_contrato = null;
            this.Id_adto = null;
        }
    }

    public class TCD_Adto_Contrato : TDataQuery
    {
        public TCD_Adto_Contrato()
        { }

        public TCD_Adto_Contrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.id_adto ");
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_adto_contrato a ");

            string cond = " and ";
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

        public TList_Adto_Contrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Adto_Contrato lista = new TList_Adto_Contrato();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Adto_Contrato reg = new TRegistro_Adto_Contrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));

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

        public string Grava(TRegistro_Adto_Contrato vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CONTRATO", vRegistro.Nr_contrato);
            hs.Add("@P_ID_ADTO", vRegistro.Id_adto);

            return this.executarProc("IA_GRO_ADTO_CONTRATO", hs);
        }

        public string Exclui(TRegistro_Adto_Contrato vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CONTRATO", vRegistro.Nr_contrato);
            hs.Add("@P_ID_ADTO", vRegistro.Id_adto);

            return this.executarProc("EXCLUI_GRO_ADTO_CONTRATO", hs);
        }
    }
}
