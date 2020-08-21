using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario_CFGPedido
    {
        public static TList_CadUsuario_CFGPedido Busca(string login, 
                                                       string Cfg_pedido,
                                                       string cd_empresa,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(login))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.login";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + login.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cfg_pedido";
                vBusca[vBusca.Length - 1].vVL_Busca = Cfg_pedido;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "d.cd_empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = cd_empresa;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_CadUsuario_CFGPedido(banco).Select(vBusca, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadUsuario_CFGPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_CFGPedido qtb_cfg = new TCD_CadUsuario_CFGPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.GravarUsuarioCFGPedido(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cfg pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadUsuario_CFGPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario_CFGPedido qtb_cfg = new TCD_CadUsuario_CFGPedido();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.DeletarUsuarioCFGPedido(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cfg pedido: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
