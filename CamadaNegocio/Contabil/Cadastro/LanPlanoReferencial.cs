using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil.Cadastro;

namespace CamadaNegocio.Contabil.Cadastro
{
    public class TCN_PlanoReferencial
    {
        public static TList_PlanoReferencial Buscar(string Cd_referencia,
                                                    string Nome,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_referencia))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_referencia";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_referencia.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nome))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nome";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nome.Trim() + "%'";
            }
            return new TCD_PlanoReferencial(banco).Select(filtro, 0, string.Empty);
        }

        public static void Gravar(TList_PlanoReferencial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlanoReferencial qtb_plano = new TCD_PlanoReferencial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plano.CriarBanco_Dados(true);
                else qtb_plano.Banco_Dados = banco;
                val.ForEach(p => Gravar(p, qtb_plano.Banco_Dados));
                if (st_transacao)
                    qtb_plano.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plano.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plano.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_PlanoReferencial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlanoReferencial qtb_plano = new TCD_PlanoReferencial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plano.CriarBanco_Dados(true);
                else qtb_plano.Banco_Dados = banco;
                string retorno = qtb_plano.Gravar(val);
                if (st_transacao)
                    qtb_plano.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plano.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plano.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PlanoReferencial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PlanoReferencial qtb_plano = new TCD_PlanoReferencial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_plano.CriarBanco_Dados(true);
                else qtb_plano.Banco_Dados = banco;
                qtb_plano.Excluir(val);
                if (st_transacao)
                    qtb_plano.Banco_Dados.Commit_Tran();
                return val.Cd_referencia;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_plano.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_plano.deletarBanco_Dados();
            }
        }
    }
}
