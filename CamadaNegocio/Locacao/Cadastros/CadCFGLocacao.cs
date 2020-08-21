using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Locacao.Cadastros;
using Utils;

namespace CamadaNegocio.Locacao.Cadastros
{
    public class TCN_CFGLocacao
    {
        public static TList_CFGLocacao buscar(string Cd_empresa,
                                              string Tp_ordem,
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
            if (!string.IsNullOrEmpty(Tp_ordem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_ordem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Tp_ordem;
            }

            return new TCD_CFGLocacao(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGLocacao qtb_cfglocacao = new TCD_CFGLocacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfglocacao.CriarBanco_Dados(true);
                else
                    qtb_cfglocacao.Banco_Dados = banco;
                string retorno = qtb_cfglocacao.Gravar(val);
                if (st_transacao)
                    qtb_cfglocacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfglocacao.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_cfglocacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGLocacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGLocacao qtb_cfg = new TCD_CFGLocacao();
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
