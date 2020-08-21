using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;
using Utils;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadContaGer_X_Empresa
    {
        public static TList_CadContaGer_X_Empresa Busca(string vCD_ContaGer,
                                                        string vCD_Empresa,
                                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if ((vCD_ContaGer.Trim() != "") && (vCD_ContaGer.Trim() != "0"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaGer + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }

            return new TCD_CadContaGer_X_Empresa(banco).Select(filtro, 0, "");
        }

        public static string GravaContaGer_X_Empresa(TRegistro_CadContaGer_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContaGer_X_Empresa id = new TCD_CadContaGer_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = id.CriarBanco_Dados(true);
                else
                    id.Banco_Dados = banco;
                string retorno = id.GravaContaGer_X_Empresa(val);
                if (st_transacao)
                    id.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    id.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    id.deletarBanco_Dados();
            }

        }
        public static string DeletaContaGer_X_Empresa(TRegistro_CadContaGer_X_Empresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadContaGer_X_Empresa id = new TCD_CadContaGer_X_Empresa();
            try
            {
                if (banco == null)
                    st_transacao = id.CriarBanco_Dados(true);
                else
                    id.Banco_Dados = banco;
                id.DeletaContaGer_X_Empresa(val);
                if (st_transacao)
                    id.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    id.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    id.deletarBanco_Dados();
            }
        }

    }
}
