using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
   public class TList_Cad_RamoAtividade : List<TRegistro_Cad_RamoAtividade>
    {

    }

    
   public class TRegistro_Cad_RamoAtividade
   {
        
       private decimal ?id_RamoAtividade;
        
       public decimal ?Id_RamoAtividade
       {
           get
           {
               if (id_RamoAtividade == 0)
                   return null;
               else
                   return id_RamoAtividade;
           }

           set
           {
               id_RamoAtividade = value;
               id_RamoAtividadeString = (value.HasValue ? value.Value.ToString() : string.Empty);
           }
       }

       private string id_RamoAtividadeString;
        
       public string Id_RamoAtividadeString
       {
           get { return id_RamoAtividadeString; }
           set
           {
               id_RamoAtividadeString = value;
               try
               {
                   id_RamoAtividade = Convert.ToDecimal(value);
               }
               catch { id_RamoAtividade = null; }
           }
       }
        
       public string Ds_RamoAtividade
       { get; set; }

      public TRegistro_Cad_RamoAtividade()
       {
           this.id_RamoAtividade = null;
           this.id_RamoAtividadeString = string.Empty;
           this.Ds_RamoAtividade = string.Empty;
       }
   }
   public class TCD_CadRamoAtividade : TDataQuery
   {
       public TCD_CadRamoAtividade()
       { }

       public TCD_CadRamoAtividade(BancoDados.TObjetoBanco banco)
       { this.Banco_Dados = banco; }

       private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
       {
           string strTop = "";
           if (vTop > 0)
               strTop = " TOP" + Convert.ToString(vTop);
           StringBuilder sql = new StringBuilder();
           if (vNm_Campo.Length == 0)
           {

               sql.AppendLine("Select " + strTop + "a.id_RamoAtividade,a.ds_RamoAtividade");
           }
           else
               sql.AppendLine("Select " + strTop + "" + vNm_Campo + "");
           sql.AppendLine("From tb_fin_RamoAtividade a");

           string cond = " where ";
           if (vBusca != null)
               for (int i = 0; i < (vBusca.Length); i++)
               {
                   sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                   cond = " and ";
               }
           return sql.ToString();
       }

       public override DataTable Buscar(TpBusca[] vBusca, short vTop)
       {
           return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, ""), null);
       }

       public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
       {
           return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
       }

       public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
       {
           return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
       }

       public TList_Cad_RamoAtividade Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
       {
           TList_Cad_RamoAtividade lista = new TList_Cad_RamoAtividade();
           SqlDataReader reader = null;
           bool podeFecharBco = false;
           if (Banco_Dados == null)
           {
               this.CriarBanco_Dados(false);
               podeFecharBco = true;
           }
           try
           {
               reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
               while (reader.Read())
               {
                   TRegistro_Cad_RamoAtividade reg = new TRegistro_Cad_RamoAtividade();

                   if (!reader.IsDBNull(reader.GetOrdinal("Id_RamoAtividade")))
                       reg.Id_RamoAtividade = reader.GetDecimal(reader.GetOrdinal("Id_RamoAtividade"));
                   if (!(reader.IsDBNull(reader.GetOrdinal("Ds_RamoAtividade"))))
                       reg.Ds_RamoAtividade = reader.GetString(reader.GetOrdinal("Ds_RamoAtividade"));
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

       public string GravaCad_RamoAtividade(TRegistro_Cad_RamoAtividade val)
       {
           Hashtable hs = new Hashtable(20);
           hs.Add("@P_ID_RAMOATIVIDADE", val.Id_RamoAtividade);
           hs.Add("@P_DS_RAMOATIVIDADE", val.Ds_RamoAtividade);
           return this.executarProc("IA_FIN_RAMOATIVIDADE", hs);
       }

       public string DeletaCad_RamoAtividade(TRegistro_Cad_RamoAtividade val)
       {
           Hashtable hs = new Hashtable(2);
           hs.Add("@P_ID_RAMOATIVIDADE", val.Id_RamoAtividade);

           return this.executarProc("EXCLUI_FIN_RAMOATIVIDADE", hs);
       }
   }

}
