using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;


namespace CamadaNegocio.Diversos
{
    public class TCN_CadLogEmail
    {
         public static TList_CadLogEmail Busca(string Id_log,
                                               string LoginRemetente,
                                               string vDS_Titulo, 
                                               string vMensagem,
                                               string vDS_destinatario, 
                                               string Dt_ini,
                                               string Dt_fin,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_log))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_log";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_log;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vDS_Titulo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_Titulo.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }

            if (!string.IsNullOrEmpty(vDS_destinatario))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Destinatario";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_destinatario.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vMensagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.mensagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vMensagem.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_email";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.dt_email";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(LoginRemetente))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.LoginRemetente";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + LoginRemetente.Trim() + "'";
            }

            return new TCD_CadLogEmail(banco).Select(vBusca, 0, string.Empty);
        }

         public static string Gravar(TRegistro_CadlogEmail val, BancoDados.TObjetoBanco banco)
         {
             bool st_transacao = false;
             TCD_CadLogEmail qtb_log = new TCD_CadLogEmail();
             try
             {
                 if (banco == null)
                     st_transacao = qtb_log.CriarBanco_Dados(true);
                 else
                     qtb_log.Banco_Dados = banco;
                 string retorno = qtb_log.Gravar(val);
                 if (st_transacao)
                     qtb_log.Banco_Dados.Commit_Tran();
                 return retorno;
             }
             catch (Exception ex)
             {
                 if (st_transacao)
                     qtb_log.Banco_Dados.RollBack_Tran();
                 throw new Exception("Erro gravar log email: " + ex.Message.Trim());
             }
             finally
             {
                 if (st_transacao)
                     qtb_log.deletarBanco_Dados();
             }
         }

         public static string Excluir(TRegistro_CadlogEmail val, BancoDados.TObjetoBanco banco)
         {
             bool st_transacao = false;
             TCD_CadLogEmail qtb_log = new TCD_CadLogEmail();
             try
             {
                 if (banco == null)
                     st_transacao = qtb_log.CriarBanco_Dados(true);
                 else
                     qtb_log.Banco_Dados = banco;
                 qtb_log.Excluir(val);
                 if (st_transacao)
                     qtb_log.Banco_Dados.Commit_Tran();
                 return "OK";
             }
             catch (Exception ex)
             {
                 if (st_transacao)
                     qtb_log.Banco_Dados.RollBack_Tran();
                 throw new Exception("Erro deletar log email: " + ex.Message.Trim());
             }
             finally
             {
                 if (st_transacao)
                     qtb_log.deletarBanco_Dados();
             }
         }
    }
}
