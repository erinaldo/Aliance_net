using System;
using Utils;
using BancoDados;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_SerieDevolvida
    {
        public static TList_SerieDevolvida Buscar(string Id_serie,
                                                  string Cd_empresa,
                                                  string Nr_lanctofiscal,
                                                  string Id_nfitem,
                                                  TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            Estruturas.CriarParametro(ref filtro, "a.id_serie", Id_serie);
            Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            Estruturas.CriarParametro(ref filtro, "a.nr_lanctofiscal", Nr_lanctofiscal);
            Estruturas.CriarParametro(ref filtro, "a.id_nfitem", Id_nfitem);
            return new TCD_SerieDevolvida(banco).Select(filtro, 0, string.Empty);
        }
        public static string Gravar(TRegistro_SerieDevolvida val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SerieDevolvida qtb_serie = new TCD_SerieDevolvida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_serie.CriarBanco_Dados(true);
                else qtb_serie.Banco_Dados = banco;
                string retorno = qtb_serie.Gravar(val);
                if (st_transacao)
                    qtb_serie.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_serie.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_serie.deletarBanco_Dados();
            }
        }
        public static string Excluir(TRegistro_SerieDevolvida val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SerieDevolvida qtb_serie = new TCD_SerieDevolvida();
            try
            {
                if (banco == null)
                    st_transacao = qtb_serie.CriarBanco_Dados(true);
                else qtb_serie.Banco_Dados = banco;
                qtb_serie.Excluir(val);
                if (st_transacao)
                    qtb_serie.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb_serie.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir devolução serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_serie.deletarBanco_Dados();
            }
        }
    }
}
