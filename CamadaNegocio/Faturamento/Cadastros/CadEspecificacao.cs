using System;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_Especificacao
    {
        public static CamadaDados.Faturamento.Cadastros.TList_Especificacao Buscar(string Id_especificacao,
                                                                                   string Ds_especificacao,
                                                                                   BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_especificacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_especificacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_especificacao;
            }
            if (!string.IsNullOrEmpty(Ds_especificacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_especificacao";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_especificacao.Trim() + "%')";
            }
            return new CamadaDados.Faturamento.Cadastros.TCD_Especificacao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(CamadaDados.Faturamento.Cadastros.TRegistro_Especificacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Faturamento.Cadastros.TCD_Especificacao qtb_esp = new CamadaDados.Faturamento.Cadastros.TCD_Especificacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_esp.CriarBanco_Dados(true);
                else
                    qtb_esp.Banco_Dados = banco;
                string retorno = qtb_esp.Gravar(val);
                if (st_transacao)
                    qtb_esp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_esp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar especificação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_esp.deletarBanco_Dados();
            }
        }

        public static string Excluir(CamadaDados.Faturamento.Cadastros.TRegistro_Especificacao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            CamadaDados.Faturamento.Cadastros.TCD_Especificacao qtb_esp = new CamadaDados.Faturamento.Cadastros.TCD_Especificacao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_esp.CriarBanco_Dados(true);
                else
                    qtb_esp.Banco_Dados = banco;
                qtb_esp.Excluir(val);
                if (st_transacao)
                    qtb_esp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_esp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir especificação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_esp.deletarBanco_Dados();
            }
        }
    }
}
        