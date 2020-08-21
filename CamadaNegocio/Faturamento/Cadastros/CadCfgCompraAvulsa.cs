using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CfgCompraAvulsa
    {
        public static TList_CfgCompraAvulsa Buscar(string Cd_empresa,
                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_CfgCompraAvulsa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CfgCompraAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgCompraAvulsa qtb_cfg = new TCD_CfgCompraAvulsa();
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

        public static string Excluir(TRegistro_CfgCompraAvulsa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgCompraAvulsa qtb_cfg = new TCD_CfgCompraAvulsa();
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
