using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Licenca
    {
        public static string Gravar(TRegistro_Licenca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Licenca qtb_lic = new TCD_Licenca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lic.CriarBanco_Dados(true);
                else
                    qtb_lic.Banco_Dados = banco;
                string retorno = qtb_lic.Gravar(val);
                if (st_transacao)
                    qtb_lic.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar licenca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lic.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Licenca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Licenca qtb_lic = new TCD_Licenca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lic.CriarBanco_Dados(true);
                else
                    qtb_lic.Banco_Dados = banco;
                qtb_lic.Excluir(val);
                if (st_transacao)
                    qtb_lic.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir licenca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lic.deletarBanco_Dados();
            }
        }
    }
}
