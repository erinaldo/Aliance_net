using System;
using CamadaDados.Estoque.Cadastros;
using Utils;
using BancoDados;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadUnidade
    {
        public static TList_CadUnidade Busca(string vCD_Unidade, 
                                             string vDS_Unidade,
                                             string vSiglaUnidade,
                                             TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Unidade))
                Estruturas.CriarParametro(ref vBusca, "a.cd_unidade", "'" + vCD_Unidade.Trim() + "'");
            if (!string.IsNullOrEmpty(vDS_Unidade))
                Estruturas.CriarParametro(ref vBusca, "a.ds_unidade", "'%" + vDS_Unidade.Trim() + "%'", "like");
            if (!string.IsNullOrEmpty(vSiglaUnidade))
                Estruturas.CriarParametro(ref vBusca, "a.sigla_unidade", "'%" + vSiglaUnidade.Trim() + "%'", "like");
            return new TCD_CadUnidade(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadUnidade val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUnidade qtb = new TCD_CadUnidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else qtb.Banco_Dados = banco;
                string ret = qtb.Grava(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar unidade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadUnidade val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUnidade qtb = new TCD_CadUnidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else qtb.Banco_Dados = banco;
                string ret = qtb.Deleta(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir unidade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
}
