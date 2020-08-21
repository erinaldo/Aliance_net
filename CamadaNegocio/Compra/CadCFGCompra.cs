using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra;

namespace CamadaNegocio.Compra
{
    public class TCN_CFGCompra
    {
        public static TList_CFGCompra Buscar(string Cd_empresa,
                                             string Cd_requisitantepadrao,
                                             string Cd_moeda,
                                             string Cfg_pedidocompra,
                                             string Cd_local,
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
            if (Cd_requisitantepadrao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_requisitantepadrao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_requisitantepadrao.Trim() + "'";
            }
            if (Cd_moeda.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (Cfg_pedidocompra.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedidocompra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedidocompra.Trim() + "'";
            }
            if (Cd_local.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_local.Trim() + "'";
            }

            return new TCD_CFGCompra(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCFGCompra(TRegistro_CFGCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCompra qtb_cfg = new TCD_CFGCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                //Gravar Cfg Compra
                string retorno = qtb_cfg.GravarCFGCompra(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string DeletarCFGCompra(TRegistro_CFGCompra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCompra qtb_cfg = new TCD_CFGCompra();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                //Gravar Cfg Compra
                qtb_cfg.DeletarCFGCompra(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
