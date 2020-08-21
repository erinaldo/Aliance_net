using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_PrazoEntrega
    {
        public static TList_PrazoEntrega Buscar(string Cd_empresa,
                                                string Id_negociacao,
                                                string Id_item,
                                                int vTop,
                                                string vNm_campo,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (Id_negociacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_negociacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_negociacao;
            }
            if (Id_item.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            return new TCD_PrazoEntrega(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarPrazoEntrega(TRegistro_PrazoEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrazoEntrega qtb_prazo = new TCD_PrazoEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prazo.CriarBanco_Dados(true);
                else
                    qtb_prazo.Banco_Dados = banco;
                string retorno = qtb_prazo.GravarPrazoEntrega(val);
                if (st_transacao)
                    qtb_prazo.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prazo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar prazo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prazo.deletarBanco_Dados();
            }
        }

        public static string DeletarPrazoEntrega(TRegistro_PrazoEntrega val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrazoEntrega qtb_prazo = new TCD_PrazoEntrega();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prazo.CriarBanco_Dados(true);
                else
                    qtb_prazo.Banco_Dados = banco;
                qtb_prazo.DeletarPrazoEntrega(val);
                if (st_transacao)
                    qtb_prazo.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prazo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir prazo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prazo.deletarBanco_Dados();
            }
        }
    }
}
