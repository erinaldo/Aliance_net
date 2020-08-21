using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
   public class TCN_CadUsuarioxTerminal
    {
       public static  TList_CadUsuarioxTerminal Busca(string vCd_Terminal,
                                                      string vLogin,
                                                      BancoDados.TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if(!string.IsNullOrEmpty(vCd_Terminal))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_Terminal";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Terminal.Trim() + "'";
           }
           if (!string.IsNullOrEmpty(vLogin))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Login";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vLogin.Trim() + "'";
           }
           
           return new TCD_CadUsuarioxTerminal(banco).Select(vBusca, 0, string.Empty);
           
       }

       public static string Gravar(TRegistro_CadUsuarioxTerminal val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadUsuarioxTerminal qtb_term = new TCD_CadUsuarioxTerminal();
           try
           {
               if (banco == null)
                   st_transacao = qtb_term.CriarBanco_Dados(true);
               else
                   qtb_term.Banco_Dados = banco;
               string retorno = qtb_term.Grava(val);
               if (st_transacao)
                   qtb_term.Banco_Dados.Commit_Tran();
               return retorno;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_term.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar terminal: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   qtb_term.deletarBanco_Dados();
           }
       }

       public static string Excluir(TRegistro_CadUsuarioxTerminal val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_CadUsuarioxTerminal qtb_term = new TCD_CadUsuarioxTerminal();
           try
           {
               if(banco == null)
                   st_transacao = qtb_term.CriarBanco_Dados(true);
               else
                   qtb_term.Banco_Dados = banco;
               qtb_term.Deleta(val);
               if(st_transacao)
                   qtb_term.Banco_Dados.Commit_Tran();
               return "OK";
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_term.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir terminal: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   qtb_term.deletarBanco_Dados();
           }
       }
    }
}

