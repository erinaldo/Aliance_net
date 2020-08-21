using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_Usuario_RegraEspecial
    {
        public static TList_Usuario_RegraEspecial Buscar(string Login,
                                                         string Id_regra,
                                                         string Ds_regra,
                                                         BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_regra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_regra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_regra;
            }
            if (!string.IsNullOrEmpty(Ds_regra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_regra";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_regra.Trim() + "%')";
            }
            return new TCD_Usuario_RegraEspecial(banco).Select(filtro, 0, string.Empty);
        }

        public static bool ValidaRegra(string vLogin, string vDS_Regra, BancoDados.TObjetoBanco banco)
        {
            if (vLogin.Trim().ToUpper().Equals("MASTER") || vLogin.Trim().ToUpper().Equals("DESENV"))
                return true;
            bool st_transacao = false;
            TCD_Usuario_RegraEspecial reg = new TCD_Usuario_RegraEspecial();
            try
            {
                if (banco == null)
                    st_transacao = reg.CriarBanco_Dados(true);
                else
                    reg.Banco_Dados = banco;
                object obj = reg.BuscarEscalar(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "((a.login = '" + vLogin + "')or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                    "         where x.logingrp = a.login and x.loginusr = '" + vLogin + "')))"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.ds_regra",
                        vOperador = "=",
                        vVL_Busca = "'" + vDS_Regra.Trim().ToUpper() + "'"
                    }
                }, "DS_Regra");

                if (obj != null)
                    return ((string)obj != "");
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro validar regra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    reg.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_Usuario_RegraEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_RegraEspecial qtb_user = new TCD_Usuario_RegraEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                string retorno = qtb_user.Gravar(val);
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Usuario_RegraEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Usuario_RegraEspecial qtb_user = new TCD_Usuario_RegraEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                qtb_user.Excluir(val);
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }
    }
}
