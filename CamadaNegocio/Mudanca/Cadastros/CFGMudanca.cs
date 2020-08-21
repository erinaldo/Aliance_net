using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca.Cadastros;
using Utils;

namespace CamadaNegocio.Mudanca.Cadastros
{
    public class TCN_CFGMudanca
    {
        public static TList_CFGMudanca buscar(string Cd_empresa,
                                             string TP_Duplicata,
                                             string Tp_Docto,
                                             string CFG_PedServico,
                                             string CD_ServPadrao,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(TP_Duplicata))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Duplicata";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + TP_Duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_Docto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Docto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Tp_Docto;
            }
            if (!string.IsNullOrEmpty(CFG_PedServico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CFG_PedServico";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CFG_PedServico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CD_ServPadrao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_ServPadrao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_ServPadrao.Trim() + "'";
            }

            return new TCD_CFGMudanca(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGMudanca qtb_cfg = new TCD_CFGMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGMudanca val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGMudanca qtb_cfg = new TCD_CFGMudanca();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
