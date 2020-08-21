using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public static class TCN_Acessorios
    {
        public static TList_Acessorios Buscar(string Id_os,
                                              string Cd_empresa,
                                              string Id_acessorio,
                                              string Ds_acessorio,
                                              int vTop,
                                              string vNm_campo,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_os.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Id_acessorio.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acessorio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_acessorio;
            }
            if (Ds_acessorio.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_acessorio";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_acessorio.Trim() + "%')";
            }
            return new TCD_Acessorios(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarAcessorios(TRegistro_Acessorios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acessorios qtb_acess = new TCD_Acessorios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acess.CriarBanco_Dados(true);
                else
                    qtb_acess.Banco_Dados = banco;
                //Gravar acessorio
                string retorno = qtb_acess.GravarAcessorios(val);
                if (st_transacao)
                    qtb_acess.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acess.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acess.deletarBanco_Dados();
            }
        }

        public static string DeletarAcessorios(TRegistro_Acessorios val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Acessorios qtb_acess = new TCD_Acessorios();
            try
            {
                if (banco == null)
                    st_transacao = qtb_acess.CriarBanco_Dados(true);
                else
                    qtb_acess.Banco_Dados = banco;
                //Deletar acessorio
                qtb_acess.DeletarAcessorios(val);
                if (st_transacao)
                    qtb_acess.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_acess.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar acessorio: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_acess.deletarBanco_Dados();
            }
        }
    }
}
