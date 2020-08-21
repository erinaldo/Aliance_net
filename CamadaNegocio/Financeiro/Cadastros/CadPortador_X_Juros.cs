using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_Portador_X_Juros
    {
        public static TList_Portador_X_Juros Buscar(string Cd_juro,
                                                    string Cd_portador,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_juro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_juro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_juro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_portador.Trim() + "'";
            }
            return new TCD_Portador_X_Juros(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Portador_X_Juros val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Portador_X_Juros qtb_reg = new TCD_Portador_X_Juros();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else
                    qtb_reg.Banco_Dados = banco;
                string retorno = qtb_reg.Gravar(val);
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Portador_X_Juros val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Portador_X_Juros qtb_reg = new TCD_Portador_X_Juros();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else
                    qtb_reg.Banco_Dados = banco;
                qtb_reg.Excluir(val);
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }
    }
}
