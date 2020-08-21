using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca.Cadastros;

namespace CamadaNegocio.Balanca.Cadastros
{
    public class TCN_CFGSeqPesagem
    {
        public static TList_CFGSeqPesagem Buscar(string Cd_empresa,
                                                 string Tp_pesagem,
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
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }
            return new TCD_CFGSeqPesagem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CFGSeqPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGSeqPesagem qtb_cfg = new TCD_CFGSeqPesagem();
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
                throw new Exception("Erro gravar seq. pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGSeqPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGSeqPesagem qtb_cfg = new TCD_CFGSeqPesagem();
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
                throw new Exception("Erro excluir seq. pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static decimal GerarIdTicket(TRegistro_CFGSeqPesagem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            decimal id_ticket = decimal.Zero;
            TCD_CFGSeqPesagem qtb_tp = new TCD_CFGSeqPesagem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                string retorno = qtb_tp.GerarIdTicket(val);
                id_ticket = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@@P_SEQ_IDTICKET"));
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return id_ticket;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gerar Id. Ticket: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
