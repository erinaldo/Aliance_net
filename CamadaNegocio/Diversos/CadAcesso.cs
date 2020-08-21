using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadAcesso
    {
        public static TList_CadAcesso Buscar(string login,
                                             string id_menu,
                                             bool St_menuAnalitico,
                                             string vNm_campo,
                                             int vTop,
                                             string vOrder,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(login))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.LOGIN";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + login.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(id_menu))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_MENU";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_menu.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (St_menuAnalitico)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.NM_Modulo";
                vBusca[vBusca.Length - 1].vVL_Busca = "is not null";
                vBusca[vBusca.Length - 1].vOperador = "";
            }

            return new TCD_CadAcesso(banco).Select(vBusca, vTop, vNm_campo, vOrder);
        }

        public static TRegistro_CadAcesso BuscarDetalhesAcesso(string Login,
                                                        string Nm_classe)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = string.Empty;
            filtro[0].vVL_Busca = "((a.login = '" + Login.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                  "         where x.logingrp = a.login and x.loginusr = '" + Login.Trim() + "')))";
            filtro[1].vNM_Campo = "c.nm_classe";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Nm_classe.Trim().ToUpper() + "'";

            TList_CadAcesso lAcesso = new TCD_CadAcesso().Select(filtro, 0, string.Empty, string.Empty);
            if (lAcesso.Count > 0)
                return lAcesso[0];
            else
                return null;
        }

        public static TList_CadAcesso BuscarAcesso(string aLogin,
                                                   string aMenu,
                                                   BancoDados.TObjetoBanco banco)
        {
            return new TCD_CadAcesso(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.LOGIN",
                        vOperador = "=",
                        vVL_Busca = "'" + aLogin.Trim() + "' or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos x " +
                                    "         where x.logingrp = a.login and x.loginusr = '" + aLogin.Trim() + "'))"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.Id_menu",
                        vOperador = "=",
                        vVL_Busca = "'" + aMenu.Trim() + "'"
                    }
                }, 0, string.Empty, string.Empty);
        }

        public static string GravarAcesso(TRegistro_CadAcesso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAcesso qtb_acesso = new TCD_CadAcesso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acesso.CriarBanco_Dados(true);
                else
                    qtb_acesso.Banco_Dados = banco;
                string retorno = qtb_acesso.GravarAcesso(val);
                if (st_transacao)
                    qtb_acesso.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acesso.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acesso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acesso.deletarBanco_Dados();
            }
        }

        public static string DeletarAcesso(TRegistro_CadAcesso val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAcesso qtb_acesso = new TCD_CadAcesso();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acesso.CriarBanco_Dados(true);
                else
                    qtb_acesso.Banco_Dados = banco;
                System.Data.DataTable tb_acesso = new TCD_CadAcesso().BuscarAcessoRecursivoDeletar(val.Id_menu, val.Login);
                if (tb_acesso != null)
                    for (int i = 0; i < tb_acesso.Rows.Count; i++)
                    {
                        qtb_acesso.DeletarAcesso(new TRegistro_CadAcesso()
                        {
                            Login = val.Login.Trim(),
                            Id_menu = tb_acesso.Rows[i]["id_menu"].ToString().Trim()
                        });
                    }
                if (st_transacao)
                    qtb_acesso.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acesso.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir acesso: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acesso.deletarBanco_Dados();
            }
        }

        /// <summary>
        /// Método utilizado para validar se usuário possui permissão 
        /// para acessar determinada opção/menu no sistema.
        /// </summary>
        /// <param name="Id_Menu"> Número do menu desejado para validação.</param>
        /// <returns> 
        /// Retorna true, para usuário com permissão.
        /// Retorna false, para usuário sem permissão.
        /// </returns>
        public static bool AcessarMenu(int Id_Menu)
        {
            if (Parametros.pubLogin.Equals("MASTER") || Parametros.pubLogin.Equals("DESENV"))
                return true;


            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.login", "'" + Parametros.pubLogin + "'");
            Estruturas.CriarParametro(ref tps, "a.Id_menu", Id_Menu.ToString());
            object perm = new TCD_CadAcesso().BuscarEscalar(tps, "1");
            if (perm == null)
                return false;
            else return true;
        }
    }
}
