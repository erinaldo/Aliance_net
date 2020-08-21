using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CotacaoMoeda
    {
        public static TList_CotacaoMoeda Buscar(string Cd_moeda,
                                                string Cd_moedaresult,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_moeda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moeda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moeda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_moedaresult))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_moedaresult";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_moedaresult.Trim() + "'";
            }
            return new TCD_CotacaoMoeda(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarCotacao(TRegistro_CotacaoMoeda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CotacaoMoeda qtb_cotacao = new TCD_CotacaoMoeda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cotacao.CriarBanco_Dados(true);
                else
                    qtb_cotacao.Banco_Dados = banco;
                string retorno = qtb_cotacao.GravarCotacao(val);
                if (st_transacao)
                    qtb_cotacao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cotacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar cotacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cotacao.deletarBanco_Dados();
            }
        }

        public static string ExcluirCotacao(TRegistro_CotacaoMoeda val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CotacaoMoeda qtb_cotacao = new TCD_CotacaoMoeda();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cotacao.CriarBanco_Dados(true);
                else
                    qtb_cotacao.Banco_Dados = banco;
                qtb_cotacao.ExcluirCotacao(val);
                if (st_transacao)
                    qtb_cotacao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cotacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir cotacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cotacao.deletarBanco_Dados();
            }
        }

        public static decimal ConvertMoeda(string Cd_moeda_origem,
                                           string Cd_moeda_destino,
                                           DateTime Data,
                                           decimal Vl_origem)
        {
            decimal indice = decimal.Zero;
            return ConvertMoeda(Cd_moeda_origem, Cd_moeda_destino, Data, true, Vl_origem, ref indice, null);
        }

        public static decimal ConvertMoeda(string Cd_moeda_origem,
                                           string Cd_moeda_destino,
                                           DateTime Data,
                                           bool St_cotacaoMenor,
                                           decimal Vl_origem,
                                           ref decimal Indice,
                                           BancoDados.TObjetoBanco banco)
        {
            if (Cd_moeda_destino.Trim().Equals(Cd_moeda_origem.Trim()))
                return Vl_origem;
            TList_CotacaoMoeda lCotacao = new TCD_CotacaoMoeda(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_moeda",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_moeda_origem.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_Moedaresult",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_moeda_destino.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.data",
                        vOperador = St_cotacaoMenor ? "<=" : "=",
                        vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Data.ToString("yyyyMMdd")) + (St_cotacaoMenor ? " 23:59:59'" : "'")
                    }
                }, 1, string.Empty);
            if (lCotacao.Count > 0)
            {
                if (lCotacao[0].Op.Trim().Equals("*"))
                    return Vl_origem * lCotacao[0].Valor;
                else if (lCotacao[0].Op.Trim().Equals("/"))
                    return Vl_origem / lCotacao[0].Valor;
                else
                    return Vl_origem;
            }
            else
                throw new Exception("Não existe cotação para a moeda de origem " + Cd_moeda_origem.Trim() + ", \r\n" +
                                    "moeda de destino " + Cd_moeda_destino.Trim() + ", \r\n" +
                                    "data da cotação " + Data.ToString("dd/MM/yyyy"));
        }
    }
}
