using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using Utils;


namespace CamadaNegocio.Financeiro.Cadastros
{
   public  class TCN_Cad_RamoAtividade
    {
       public static TList_Cad_RamoAtividade Busca(string vId_Ramo, 
                                                   string vDs_RamoAtividade,
                                                   BancoDados.TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (vId_Ramo.Trim() != "" )
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_ramoAtividade";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_Ramo + "'";
           }
           if (vDs_RamoAtividade.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_ramoAtividade";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDs_RamoAtividade + "'";
           }
           return new TCD_CadRamoAtividade(banco).Select(vBusca, 0, "");
       }

       public static string Grava_CadRamoAtividade(TRegistro_Cad_RamoAtividade val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadRamoAtividade cd = new TCD_CadRamoAtividade();
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               string retorno = cd.GravaCad_RamoAtividade(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return retorno;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }

       public static string Deleta_CadRamoAtividade(TRegistro_Cad_RamoAtividade val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadRamoAtividade cd = new TCD_CadRamoAtividade();
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               cd.DeletaCad_RamoAtividade(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return "OK";
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }
    }
}
