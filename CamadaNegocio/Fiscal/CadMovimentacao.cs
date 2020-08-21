using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_CadMovimentacao
    {
        public static TList_CadMovimentacao Busca(string Cd_movimentacao, 
                                                  string Ds_movimentacao, 
                                                  string Tp_movimento,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_movimentacao";
                vBusca[vBusca.Length - 1].vVL_Busca = Cd_movimentacao;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Ds_movimentacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_movimentacao";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + Ds_movimentacao.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_movimento + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            return new TCD_CadMovimentacao(banco).Select(vBusca, 0, string.Empty);
        }
        public static string Gravar(TRegistro_CadMovimentacao val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadMovimentacao qtb_mov = new TCD_CadMovimentacao();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                string retorno = qtb_mov.Gravar(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_CadMovimentacao val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadMovimentacao qtb_mov = new TCD_CadMovimentacao();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else
                    qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimentação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }
}
