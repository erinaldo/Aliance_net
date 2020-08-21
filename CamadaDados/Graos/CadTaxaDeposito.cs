using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Graos
{
   
    public class TList_CadTaxaDeposito : List<TRegistro_CadTaxaDeposito>
    { }

    public class TRegistro_CadTaxaDeposito
    {
       
        public decimal Id_Taxa{set;get;}
        public string Id_Taxa_str 
        {
            get { return this.Id_Taxa + ""; }
            set { try { this.Id_Taxa = decimal.Parse(value);  } catch { } } 
        }

        public string Ds_Taxa    
        { get; set; }

        private String Tp_Taxa__;

        public string TP_Taxa
        {
            get {
                try
                {
                    return (Tp_Taxa__.Equals("V") ? "V" : (Tp_Taxa__.Equals("P") ? "P" : ""));
                }
                catch { 
                    return string.Empty;
                }
            }
            set {
                try
                {
                    Tp_Taxa__ = (value.Equals("V") ? "V" : (value.Equals("P") ? "P" : null));
                }
                catch {
                    Tp_Taxa__ = null;
                }
            } 
        }
        
        public string TP_TAXA_str
        {
            get {
                    try
                    {
                        return (Tp_Taxa__.Equals("V") ? "Valor Fixo" : (Tp_Taxa__.Equals("P") ? "Percentual" : ""));
                    }
                    catch {
                        return string.Empty;
                    }
                }


            set
            {
                try
                {
                    Tp_Taxa__ = (value.Equals("Valor Fixo") ? "V" : (value.Equals("Percentual") ? "P" : null));
                }
                catch 
                {
                    Tp_Taxa__ = string.Empty;
                }

            } 
        }


        public TRegistro_CadTaxaDeposito()
        {
           //this.Id_Taxa = null;
            this.Id_Taxa_str = string.Empty;

            this.Tp_Taxa__ = null;
            this.Ds_Taxa= string.Empty;
        }
    }

    public class TCD_CadTaxaDeposito : TDataQuery
    {
        public TCD_CadTaxaDeposito()
        { }

        public TCD_CadTaxaDeposito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine(" select " + strTop + " a.id_taxa, a.ds_taxa, a.tp_taxa ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_gro_TaxaDeposito a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
            

        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return base.Buscar(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadTaxaDeposito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadTaxaDeposito lista = new TList_CadTaxaDeposito();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadTaxaDeposito reg = new TRegistro_CadTaxaDeposito();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_taxa"))))
                        reg.Id_Taxa  = reader.GetDecimal(reader.GetOrdinal("id_taxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_taxa"))))
                        reg.Ds_Taxa = reader.GetString(reader.GetOrdinal("ds_taxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_taxa"))))
                        reg.TP_Taxa = reader.GetString(reader.GetOrdinal("tp_taxa"));
                  

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

        public string GravarTaxaDeposito(TRegistro_CadTaxaDeposito val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TAXA", val.Id_Taxa);
            hs.Add("@P_DS_TAXA", val.Ds_Taxa);
            hs.Add("@P_TP_TAXA", val.TP_Taxa);

            return this.executarProc("IA_GRO_TAXADEPOSITO", hs);
        }

        public string DeletarTaxaDeposito(TRegistro_CadTaxaDeposito val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TAXA", val.Id_Taxa);
            return this.executarProc("EXCLUI_GRO_TAXADEPOSITO", hs);
        }
    }
}
