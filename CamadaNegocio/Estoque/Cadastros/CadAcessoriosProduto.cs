using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
   public  class TCN_CadAcessoriosProduto
    {
       public static TList_CadAcessoriosProduto Busca(decimal vId_Acessorio, 
                                                      string vDs_Acessorio,
                                                      string vCd_Produto)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (vId_Acessorio > 0)
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_Acessorio";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_Acessorio.ToString() + "'";
           }
           if (vCd_Produto.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_Produto";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Produto + "'";
           }
           if (vDs_Acessorio.Trim() != string.Empty)
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_acessorio";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDs_Acessorio + "'";
           }
           TCD_CadAcessoriosProduto cd = new TCD_CadAcessoriosProduto();
           return cd.Select(vBusca, 0, "");
       }
       public static string GravaCadAcessoriosProduto(TRegistro_CadAcessoriosProduto val, BancoDados.TObjetoBanco banco)
       {
           if (val.ds_Acessorio.Trim() != string.Empty)
           {
               bool st_transacao = false;
               TCD_CadAcessoriosProduto cd = new TCD_CadAcessoriosProduto();
               try
               {
                   if (banco == null)
                   {
                       cd.CriarBanco_Dados(true);
                       st_transacao = true;
                   }
                   else
                       cd.Banco_Dados = banco;
                   string retorno = cd.GravaCadAcessoriosProduto(val);
                   if (st_transacao)
                       cd.Banco_Dados.Commit_Tran();
                   return retorno;
               }
               catch (Exception ex)
               {
                   if (st_transacao)
                       cd.Banco_Dados.RollBack_Tran();
                   throw new Exception(ex.Message);
               }
               finally
               {
                   if (st_transacao)
                       cd.deletarBanco_Dados();
               }               
           }
           else
               return string.Empty;
       }
       public static string DeletaCadAcessoriosProdutos(TRegistro_CadAcessoriosProduto val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadAcessoriosProduto cd = new TCD_CadAcessoriosProduto();
           try
           {
               if (banco == null)
               {
                   cd.CriarBanco_Dados(true);
                   st_transacao = true;
               }
               else
                   cd.Banco_Dados = banco;
               cd.DeletaCadAcessoriosProduto(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return "OK";
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception(ex.Message);
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }
    }
    
}
