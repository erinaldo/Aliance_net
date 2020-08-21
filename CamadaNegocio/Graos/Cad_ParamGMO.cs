using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;
using Utils;
using BancoDados;

namespace CamadaNegocio.Graos
{
   public class TCN_Cad_ParamGMO
    {
       public static TList_Cad_ParamGMO Buscar(string vCd_empresa,
                                               string vCd_contaGer,
                                               string vHist_Pgto,
                                               string vHist_Ret,
                                               TObjetoBanco banco)
       {
           TpBusca[] vBusca = new TpBusca[0];
           if (!string.IsNullOrEmpty(vCd_empresa))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";

           }
           if (!string.IsNullOrEmpty(vCd_contaGer))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_contaGer";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_contaGer.Trim() + "'";

           }
           if (!string.IsNullOrEmpty(vHist_Pgto))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_historico_pgto";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vHist_Pgto.Trim() + "'";

           }
           if (!string.IsNullOrEmpty(vHist_Ret))
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_historico_retencao";
               vBusca[vBusca.Length - 1].vOperador = "=";
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vHist_Ret.Trim() + "'";

           }

           return new TCD_Cad_ParamGMO(banco).Select(vBusca, 0, string.Empty);
       }

       public static string GravaParamGMO(TRegistro_Cad_ParamGMO val, TObjetoBanco banco)
       {
           TCD_Cad_ParamGMO cd = new TCD_Cad_ParamGMO();
           bool st_transacao = false;
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               string retorno = cd.GravaParamGMO(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return retorno;
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro gravar config: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }

       public static string DeletaParamGMO(TRegistro_Cad_ParamGMO val, TObjetoBanco banco)
       {
           TCD_Cad_ParamGMO cd = new TCD_Cad_ParamGMO();
           bool st_transacao = false;
           try
           {
               if (banco == null)
                   st_transacao = cd.CriarBanco_Dados(true);
               else
                   cd.Banco_Dados = banco;
               cd.DeletaParamGMO(val);
               if (st_transacao)
                   cd.Banco_Dados.Commit_Tran();
               return "OK";
           }
           catch (Exception ex)
           {
               if (st_transacao)
                   cd.Banco_Dados.RollBack_Tran();
               throw new Exception("Erro excluir config: " + ex.Message.Trim());
           }
           finally
           {
               if (st_transacao)
                   cd.deletarBanco_Dados();
           }
       }
    }
    

}
