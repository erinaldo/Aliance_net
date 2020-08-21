using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
   public class TCN_Cad_Genero
    {
       public static TList_Cad_Genero buscar(string vId_genero,
                                             string vDs_genero,
                                             BancoDados.TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (!string.IsNullOrEmpty(vId_genero))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.id_genero";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_genero + "'";
           }
           if (!string.IsNullOrEmpty(vDs_genero))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_genero";
               vBusca[vBusca.Length - 1].vOperador = "like";
               vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDs_genero.Trim() + "%')";
           }
           return new TCD_Cad_Genero(banco).Select(vBusca, 0, "");
       }

       public static string GravaCad_Genero(TRegistro_Cad_Genero val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_Cad_Genero qtb_genero = new TCD_Cad_Genero();
           try
           {
               if (banco == null)
                   st_transacao = qtb_genero.CriarBanco_Dados(true);
               else
                   qtb_genero.Banco_Dados = banco;
               val.Id_genero = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_genero.GravaCad_Genero(val), "@P_ID_GENERO"));
               if (st_transacao)
                   qtb_genero.Banco_Dados.Commit_Tran();
               return val.Id_generoString;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_genero.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar genero: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   qtb_genero.deletarBanco_Dados();
           }
       }

       public static string DeletaCad_Genero(TRegistro_Cad_Genero val, BancoDados.TObjetoBanco banco)
       {
           bool st_transacao = false;
           TCD_Cad_Genero qtb_genero = new TCD_Cad_Genero();
           try
           {
               if (banco == null)
                   st_transacao = qtb_genero.CriarBanco_Dados(true);
               else
                   qtb_genero.Banco_Dados = banco;
               qtb_genero.DeletaCad_Genero(val);
               if (st_transacao)
                   qtb_genero.Banco_Dados.Commit_Tran();
               return val.Id_generoString;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   qtb_genero.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir genero: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   qtb_genero.deletarBanco_Dados();
           }
       }
    }
}
