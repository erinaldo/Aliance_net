using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos.Cadastros;
using BancoDados;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_OSE_ParamOS
    {
        public static TList_OSE_ParamOS Buscar(string Tp_ordem,
                                               string Cd_moeda,
                                               string Cfg_pedido_item,
                                               string Cfg_pedido_servico,
                                               string Cfg_pedido_garantia,
                                               string Cfg_pedido_transpremessa,
                                               string Cd_produtofrete,
                                               string Cd_transportadora,
                                               string Cd_enderecotransp,
                                               int vTop,
                                               string vNm_campo,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_ordem.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Ordem";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_ordem.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Cd_moeda.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido_item.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido_item";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido_item.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido_servico.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido_servico";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido_servico.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido_garantia.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido_garantia";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido_garantia.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido_transpremessa.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido_transpremessa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido_transpremessa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_produtofrete.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produtofrete";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produtofrete.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_transportadora.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_transportadora";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_transportadora.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_enderecotransp.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_enderecotransp";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_enderecotransp.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_OSE_ParamOS(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar_OSE_ParamOS(TRegistro_OSE_ParamOS val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_ParamOS qtb_OSE_ParamOS = new TCD_OSE_ParamOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_OSE_ParamOS.CriarBanco_Dados(true);
                else
                    qtb_OSE_ParamOS.Banco_Dados = banco;
                
                string retorno = qtb_OSE_ParamOS.Gravar(val);
                if (st_transacao)
                    qtb_OSE_ParamOS.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_OSE_ParamOS.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_OSE_ParamOS.deletarBanco_Dados();
            }
        }

        public static string Deletar_OSE_ParamOS(TRegistro_OSE_ParamOS val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OSE_ParamOS qtb_OSE_ParamOS = new TCD_OSE_ParamOS();
            try
            {
                if (banco == null)
                    st_transacao = qtb_OSE_ParamOS.CriarBanco_Dados(true);
                else
                    qtb_OSE_ParamOS.Banco_Dados = banco;

                qtb_OSE_ParamOS.Excluir(val);
                if (st_transacao)
                    qtb_OSE_ParamOS.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_OSE_ParamOS.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_OSE_ParamOS.deletarBanco_Dados();
            }
        }
    }
}
