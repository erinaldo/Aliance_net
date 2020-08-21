using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Almoxarifado;
using Utils;

namespace CamadaNegocio.Almoxarifado
{
   public class TCN_CadSecao
    {
       public static TList_CadSecao Busca(string vId_Rua,
                                          string vId_Secao, 
                                          string vDs_Secao,
                                          BancoDados.TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (!string.IsNullOrEmpty(vId_Rua))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_rua";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vId_Rua;
           }
           if (!string.IsNullOrEmpty(vId_Secao))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_secao";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = vId_Secao;
           }
           if (!string.IsNullOrEmpty(vDs_Secao))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_secao";
               vBusca[vBusca.Length - 1].vOperador = "like";
               vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vDs_Secao.Trim() + "%'";
           }

           return new TCD_CadSecao(banco).Select(vBusca, 0, string.Empty);
       }

       public static string Gravar(TRegistro_CadSecao val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadSecao qtb_secao = new TCD_CadSecao();
           try
           {
               if (banco == null)
                   st_transacao = qtb_secao.CriarBanco_Dados(true);
               else
                   qtb_secao.Banco_Dados = banco;
               val.Id_secaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_secao.Gravar(val), "@P_ID_SECAO");
               if (st_transacao)
                   qtb_secao.Banco_Dados.Commit_Tran();
               return val.Id_secaostr;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_secao.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar seção: " + ex.Message.Trim());
           }
           finally
           {
               if(st_transacao)
                   qtb_secao.deletarBanco_Dados();
           }
       }

       public static string Excluir(TRegistro_CadSecao val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadSecao qtb_secao = new TCD_CadSecao();
           try
           {
               if (banco == null)
                   st_transacao = qtb_secao.CriarBanco_Dados(true);
               else
                   qtb_secao.Banco_Dados = banco;
               qtb_secao.Excluir(val);
               if (st_transacao)
                   qtb_secao.Banco_Dados.Commit_Tran();
               return val.Id_secaostr;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_secao.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir seção: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   qtb_secao.deletarBanco_Dados();
           }
       }
    }
}
