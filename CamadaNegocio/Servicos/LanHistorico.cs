using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_Historico
    {
        public static TList_Historico Buscar(string Id_os,
                                             string Cd_empresa,
                                             string Id_historico,
                                             string Ds_historico,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_historico;
            }
            if (!string.IsNullOrEmpty(Ds_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_historico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_historico.Trim() + "%'";
            }
            return new TCD_Historico(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Historico qtb_his = new TCD_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_his.CriarBanco_Dados(true);
                else
                    qtb_his.Banco_Dados = banco;
                string retorno = qtb_his.Gravar(val);
                if (st_transacao)
                    qtb_his.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_his.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar historico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_his.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Historico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Historico qtb_hist = new TCD_Historico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_hist.CriarBanco_Dados(true);
                else
                    qtb_hist.Banco_Dados = banco;
                qtb_hist.Excluir(val);
                if (st_transacao)
                    qtb_hist.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_hist.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir historico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_hist.deletarBanco_Dados();
            }
        }
    }
}
