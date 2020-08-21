using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_FATLivroFiscal
    {
        public static TList_FATLivroFiscal Buscar(string Cd_empresa,
                                                  string Nr_lanctofiscal,
                                                  string Id_livro,
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
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_livro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_livro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_livro;
            }

            return new TCD_FATLivroFiscal(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FATLivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FATLivroFiscal qtb_livro = new TCD_FATLivroFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_livro.CriarBanco_Dados(true);
                else
                    qtb_livro.Banco_Dados = banco;
                string retorno = qtb_livro.Gravar(val);
                if (st_transacao)
                    qtb_livro.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_livro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar livro fiscal faturamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FATLivroFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FATLivroFiscal qtb_livro = new TCD_FATLivroFiscal();
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
                throw new Exception("Erro excluir livro fiscal faturamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_livro.deletarBanco_Dados();
            }
        }
    }
}
