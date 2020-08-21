using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Compra.Lancamento;

namespace CamadaNegocio.Compra.Lancamento
{
    public class TCN_NegociacaoItem
    {
        public static TList_NegociacaoItem Buscar(string Id_negociacao,
                                                  string Cd_fornecedor,
                                                  string Cd_condpgto,
                                                  string Nm_vendedor,
                                                  int vTop,
                                                  string vNm_campo,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Id_negociacao.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_negociacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_negociacao;
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (Cd_condpgto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_condpgto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_condpgto.Trim() + "'";
            }
            if (Nm_vendedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_vendedor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Nm_vendedor.Trim() + "%')";
            }
            return new TCD_NegociacaoItem(banco).Select(filtro, vTop, vNm_campo, string.Empty);
        }

        public static string GravarNegociacaoItem(TRegistro_NegociacaoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NegociacaoItem qtb_neg = new TCD_NegociacaoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                string retorno = qtb_neg.GravarNegociacaoItem(val);
                val.Id_item = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ITEM"));
                //Gravar prazo entrega
                val.lPrazoEntrega.ForEach(p =>
                    {
                        p.Id_negociacao = val.Id_negociacao;
                        p.Id_item = val.Id_item;
                        TCN_PrazoEntrega.GravarPrazoEntrega(p, qtb_neg.Banco_Dados);
                    });
                //Deletar prazo entrega
                val.lPrazoEntregaDel.ForEach(p => TCN_PrazoEntrega.DeletarPrazoEntrega(p, qtb_neg.Banco_Dados));
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }

        public static string DeletarNegociacaoItem(TRegistro_NegociacaoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NegociacaoItem qtb_neg = new TCD_NegociacaoItem();
            try
            {
                if (st_transacao)
                    qtb_neg.CriarBanco_Dados(true);
                else
                    qtb_neg.Banco_Dados = banco;
                //Deletar prazo entrega
                val.lPrazoEntregaDel.ForEach(p => TCN_PrazoEntrega.DeletarPrazoEntrega(p, qtb_neg.Banco_Dados));
                val.lPrazoEntrega.ForEach(p => TCN_PrazoEntrega.DeletarPrazoEntrega(p, qtb_neg.Banco_Dados));
                //Deletar item negociacao
                qtb_neg.DeletarNegociacaoItem(val);
                if (st_transacao)
                    qtb_neg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_neg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_neg.deletarBanco_Dados();
            }
        }
    }
}
