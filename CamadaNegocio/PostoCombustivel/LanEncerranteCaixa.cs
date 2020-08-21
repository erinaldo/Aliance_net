using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_EncerranteCaixa
    {
        public static TList_EncerranteCaixa Buscar(string Id_bico,
                                                   string Id_caixa,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_bico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bico;
            }
            if (!string.IsNullOrEmpty(Id_caixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_caixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_caixa;
            }
            return new TCD_EncerranteCaixa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EncerranteCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EncerranteCaixa qtb_enc = new TCD_EncerranteCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                string retorno = qtb_enc.Gravar(val);
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EncerranteCaixa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EncerranteCaixa qtb_enc = new TCD_EncerranteCaixa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_enc.CriarBanco_Dados(true);
                else qtb_enc.Banco_Dados = banco;
                qtb_enc.Excluir(val);
                if (st_transacao)
                    qtb_enc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_enc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_enc.deletarBanco_Dados();
            }
        }
    }
}
