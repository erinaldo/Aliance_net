using BancoDados;
using CamadaDados.Faturamento.Cadastros;
using System;
using Utils;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CFGVendasExterna
    {
        public static TList_CFGVendasExterna Buscar(string Cd_empresa,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            return new TCD_CFGVendasExterna(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CFGVendasExterna val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGVendasExterna qtb_cfg = new TCD_CFGVendasExterna();
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
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGVendasExterna val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGVendasExterna qtb_cfg = new TCD_CFGVendasExterna();
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
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
