using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_TabelaDesconto
    {
        public static TList_TabelaDesconto Buscar(string Cd_tabeladesconto,
                                                  string Ds_tabeladesconto,
                                                  string Padrao_qualidade,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_tabeladesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_tabeladesconto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tabeladesconto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_tabeladesconto.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Padrao_qualidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.padrao_qualidade";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Padrao_qualidade.Trim() + "%')";
            }
            return new TCD_TabelaDesconto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TabelaDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TabelaDesconto qtb_tab = new TCD_TabelaDesconto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else
                    qtb_tab.Banco_Dados = banco;
                string retorno = qtb_tab.Gravar(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TabelaDesconto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TabelaDesconto qtb_tab = new TCD_TabelaDesconto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else
                    qtb_tab.Banco_Dados = banco;
                qtb_tab.Excluir(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }
    }
}
