using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_Requisicao_X_Negociacao
    {
        public static TList_Requisicao_X_Negociacao Buscar(string Id_requisicao,
                                                               string Id_negociacao,
                                                               int vTop,
                                                               string vNm_campo,
                                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_requisicao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "x.id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_requisicao;
            }
            if (Id_negociacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_negociacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_negociacao;
            }
            return new TCD_Requisicao_X_Negociacao(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string GravarRequisicao_X_Negociacao(TRegistro_Requisicao_X_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao_X_Negociacao qtb_neg = new TCD_Requisicao_X_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                string retorno = qtb_neg.GravarRequisicao_X_Negociacao(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }

        public static string DeletarRequisicao_X_Negociacao(TRegistro_Requisicao_X_Negociacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Requisicao_X_Negociacao qtb_neg = new TCD_Requisicao_X_Negociacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                qtb_neg.DeletarRequisicao_X_Negociacao(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }
    }
}
