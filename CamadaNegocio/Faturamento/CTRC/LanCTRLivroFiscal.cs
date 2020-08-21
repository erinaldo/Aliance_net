using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public static class TCN_CTRLivroFiscal
    {
        public static TList_CTRLivroFiscal Buscar(string Cd_empresa,
                                                  string Nr_lanctoctr,
                                                  string Id_livro,
                                                  short vTop,
                                                  string vNm_campo,
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
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (!string.IsNullOrEmpty(Id_livro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_livro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_livro;
            }
            return new TCD_CTRLivroFiscal(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CTRLivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRLivroFiscal qtb_ctrc = new TCD_CTRLivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Processar livro fiscal
                string retorno = qtb_ctrc.Gravar(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar livro fiscal conhecimento frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTRLivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRLivroFiscal qtb_livro = new TCD_CTRLivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                qtb_livro.Excluir(val);
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir livro fiscal conhecimento frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }
    }
}
