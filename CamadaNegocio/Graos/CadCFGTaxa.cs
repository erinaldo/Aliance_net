using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_CFGTaxa
    {
        public static TList_CFGTaxa Buscar(string Tp_taxa,
                                           string Cfg_pedido,
                                           string Cd_produto,
                                           string Cd_moeda,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_taxa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_taxa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_taxa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cfg_pedido))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cfg_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cfg_pedido.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            return new TCD_CFGTaxa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGTaxa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGTaxa qtb_cfg = new TCD_CFGTaxa();
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
                throw new Exception("Erro gravar config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGTaxa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGTaxa qtb_cfg = new TCD_CFGTaxa();
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
                throw new Exception("Erro excluir config.: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
