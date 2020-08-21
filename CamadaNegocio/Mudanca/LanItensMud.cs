using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca;

namespace CamadaNegocio.Mudanca
{
    public class TCN_LanItensMud
    {
        public static TList_LanItensMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Id_item,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            return new TCD_LanItensMud(banco).Select(filtro, 0, string.Empty);
        }

        public static void Gravar(TList_LanItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanItensMud qtb_itens = new TCD_LanItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                val.ForEach(p => Gravar(p, qtb_itens.Banco_Dados));
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_LanItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanItensMud qtb_itens = new TCD_LanItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                string retorno = qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void Excluir(TList_LanItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanItensMud qtb_itens = new TCD_LanItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                val.ForEach(p => Excluir(p, qtb_itens.Banco_Dados));
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanItensMud qtb_itens = new TCD_LanItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_LanFotosItensMud
    {
        public static TList_LanFotosItensMud Buscar(string Cd_empresa,
                                               string Id_mudanca,
                                               string Id_item,
                                               string Id_foto,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_mudanca;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_item";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_foto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_foto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_foto;
            }
            return new TCD_LanFotosItensMud(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanFotosItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFotosItensMud qtb_itens = new TCD_LanFotosItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_fotostr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_FOTO");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_fotostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens foto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanFotosItensMud val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanFotosItensMud qtb_itens = new TCD_LanFotosItensMud();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_fotostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir itens foto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }
}
