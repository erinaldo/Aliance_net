using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using Utils;
using BancoDados;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadDados_Bancarios_Clifor
    {
        public static TList_CadDados_Bancarios_Clifor Busca(string vCD_Clifor,
                                                            string vNR_Agencia,
                                                            string vNR_Conta,
                                                            string vCD_Banco,
                                                            BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Agencia))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Agencia";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Agencia.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Conta))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Conta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Conta.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Banco))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Banco";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Banco.Trim() + "'";
            }
            return new TCD_CadDados_Bancarios_Clifor(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadDados_Bancarios_Clifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDados_Bancarios_Clifor qtb_Dados_Bancarios = new TCD_CadDados_Bancarios_Clifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Dados_Bancarios.CriarBanco_Dados(true);
                else
                    qtb_Dados_Bancarios.Banco_Dados = banco;

                string retorno = qtb_Dados_Bancarios.Gravar(val);

                if (st_transacao)
                    qtb_Dados_Bancarios.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Dados_Bancarios.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                if (st_transacao)
                    qtb_Dados_Bancarios.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadDados_Bancarios_Clifor val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadDados_Bancarios_Clifor qtb_Dados_Bancarios = new TCD_CadDados_Bancarios_Clifor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Dados_Bancarios.CriarBanco_Dados(true);
                else
                    qtb_Dados_Bancarios.Banco_Dados = banco;

                string retorno = qtb_Dados_Bancarios.Excluir(val);

                if (st_transacao)
                    qtb_Dados_Bancarios.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Dados_Bancarios.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                if (st_transacao)
                    qtb_Dados_Bancarios.deletarBanco_Dados();
            }
        }
    }
}