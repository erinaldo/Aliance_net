using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Terminal_X_Protocolo
    {
        public static TList_Terminal_X_Protocolo Buscar(string Cd_terminal,
                                                        string Cd_protocolo,
                                                        int vTop,
                                                        string vNm_campo,
                                                        BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_terminal.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_terminal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_terminal.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_protocolo.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_protocolo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_protocolo.Trim() + "'";
            }

            return new TCD_Terminal_X_Protocolo(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_Terminal_X_Protocolo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Terminal_X_Protocolo qtb_reg = new TCD_Terminal_X_Protocolo();
            try
            {
                if (banco == null)
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

        public static string Excluir(TRegistro_Terminal_X_Protocolo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Terminal_X_Protocolo qtb_reg = new TCD_Terminal_X_Protocolo();
            try
            {
                if (banco == null)
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
