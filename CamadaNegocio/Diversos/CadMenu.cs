using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;
using Utils;
using BancoDados;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadMenu
    {
        public static TList_CadMenu Busca(string vId_Menu, string vDS_Menu, bool vBuscaPai, string vOrder, bool vBuscaSintetico, string vTP_Evento, TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vId_Menu.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_MENU";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vId_Menu + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            if (vDS_Menu.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_MENU";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDS_Menu + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };
            
            if (vBuscaPai)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.id_menuRaiz, 'VAZIO')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'VAZIO'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            if (vBuscaSintetico)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.tp_evento, 'VAZIO')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            if (vTP_Evento.Trim().Length > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.tp_evento, 'VAZIO')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Evento.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            };

            TCD_CadMenu qtb_Menu = new TCD_CadMenu();

            if (banco != null)
                qtb_Menu.Banco_Dados = banco;

            return qtb_Menu.Select(vBusca, 0, "", vOrder);
        }

        public static string GravarMenu(TRegistro_CadMenu val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMenu qtb_Menu = new TCD_CadMenu();
            
            try
            {
                if (banco == null)
                {
                    qtb_Menu.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_Menu.Banco_Dados = banco;
                //Gravar Uf
                string retorno = qtb_Menu.GravarMenu(val);
                if (st_transacao)
                    qtb_Menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Menu.deletarBanco_Dados();
            }
            //return new TCD_CadMenu().GravarMenu(val);
        }

        public static string GravarMenu(TList_CadMenu val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMenu qtb_Menu = new TCD_CadMenu();
            try
            {
                if (banco == null)
                {
                    qtb_Menu.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_Menu.Banco_Dados;
                }
                else
                    qtb_Menu.Banco_Dados = banco;
                //Gravar Uf
                string retorno = "";

                for (int i = 0; i < val.Count; i++)
                {
                    if (val[i].nivel == 1)
                        val[i].nm_modulo = null;
                    retorno = qtb_Menu.GravarMenu(val[i]);
                }

                if (st_transacao)
                    qtb_Menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_Menu.deletarBanco_Dados();
            }
            //return new TCD_CadMenu().GravarMenu(val);
        }

        public static string GravarMenu(string lin, string modulo)
        {

            TRegistro_CadMenu reg = new TRegistro_CadMenu();
            string[] campos = lin.Split(':');
            reg.id_menu = campos[0].Trim();
            reg.id_menuraiz = (campos[1].Trim() != "NULL" ? campos[1] : null);
            reg.cd_modulo = (campos[2].Trim() != "NULL" ? campos[2] : null);
            reg.nm_classe = (campos[3].Trim() != "NULL" ? campos[3] : null);
            reg.ds_menu = (campos[4].Trim() != "NULL" ? campos[4] : null);
            reg.nm_modulo = (campos[3].Trim() != "NULL" ? modulo : null);
            if (reg.nm_classe == null)
                reg.tp_evento = "S";
            else
                reg.tp_evento = "P";

            return GravarMenu(reg, null);
        }
        
        public static string DeletarMenu(TRegistro_CadMenu val)
        {
            return new TCD_CadMenu().DeletarMenu(val);
        }

        public static string DeletarMenuAcesso(TRegistro_CadMenu val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMenu qtb_menu = new TCD_CadMenu();
            try
            {
                if (banco == null)
                {
                    qtb_menu.CriarBanco_Dados(true);
                    st_transacao = true;
                    banco = qtb_menu.Banco_Dados;
                }
                else
                    qtb_menu.Banco_Dados = banco;

                //DELETA OS ACESSOS
                new CamadaDados.TDataQuery(banco).executarSql("DELETE TB_DIV_Acesso WHERE  " +
                               "	ID_Menu = " + val.id_menu, null);

                //DELETA MENU
                string retorno = qtb_menu.DeletarMenu(val);
                
                if (st_transacao)
                    qtb_menu.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_menu.Banco_Dados.RollBack_Tran();
                else
                    throw new Exception(ex.Message);
                return "";
            }
            finally
            {
                if (st_transacao)
                    qtb_menu.deletarBanco_Dados();
            }
        }
        
        public static void DeletarTodoMenu()
        {
            TCD_CadMenu menu = new TCD_CadMenu();
            menu.DeletarTodoMenu();
        }

    }
}
