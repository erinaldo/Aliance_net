using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_Faturamento_Item_X_Estoque
    {
        public static string GravarFaturamentoItem_X_Estoque(TRegistro_Faturamento_Item_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Faturamento_Item_X_Estoque qtb_fat = new TCD_Faturamento_Item_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_fat.GravarFaturamentoItem_X_Estoque(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar faturamento x estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static string DeletarFaturamentoItem_X_Estoque(TRegistro_Faturamento_Item_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Faturamento_Item_X_Estoque qtb_fat = new TCD_Faturamento_Item_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Deletar registro
                qtb_fat.DeletarFaturamentoItem_X_Estoque(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir faturamento x estoque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }
    }

    public class TCN_NFAcessorios_X_Estoque
    {
        public static string GravarNFAcessorios_X_Estoque(TRegistro_NFAcessorios_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFAcessorios_X_Estoque qtb_fat = new TCD_NFAcessorios_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_fat.GravarNFAcessorios_X_Estoque(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar faturamento acessorios: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }

        public static string DeletarNFAcessorios_X_Estoque(TRegistro_NFAcessorios_X_Estoque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_NFAcessorios_X_Estoque qtb_fat = new TCD_NFAcessorios_X_Estoque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_fat.CriarBanco_Dados(true);
                else
                    qtb_fat.Banco_Dados = banco;
                //Deletar registro
                qtb_fat.DeletarNFAcessorios_X_Estoque(val);
                if (st_transacao)
                    qtb_fat.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_fat.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir faturamento acessorios: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_fat.deletarBanco_Dados();
            }
        }
    }
}
